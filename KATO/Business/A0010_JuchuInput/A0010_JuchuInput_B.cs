using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.A0010_JuchuInput
{
    class A0010_JuchuInput_B
    {
        DBConnective dbConGr;
        public void beginTrance()
        {
            dbConGr = new DBConnective();
            dbConGr.BeginTrans();
        }

        public void commit()
        {
            dbConGr.Commit();
            dbConGr.DB_Disconnect();
        }

        public void rollback()
        {
            dbConGr.Rollback();
            dbConGr.DB_Disconnect();
        }

        public DataTable getUriagezumisuryo(string strJuchuNo)
        {
            DataTable dtSuryo = null;

            string strQuery = "SELECT 売上済数量 FROM 受注 WHERE 受注番号=" + strJuchuNo + " AND 削除='N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtSuryo = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtSuryo;
        }

        public int getShiirezumisuryo(string strJuchuNo)
        {
            int retSuryo = 0;
            DataTable dtSuryo = null;

            string strQuery = "SELECT 仕入済数量 FROM 発注 WHERE 受注番号=" + strJuchuNo + " AND 削除='N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtSuryo = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dtSuryo != null && dtSuryo.Rows.Count > 0)
            {
                decimal d = 0;
                if (dtSuryo.Rows[0]["仕入済数量"] != null)
                {
                    d = decimal.Parse(dtSuryo.Rows[0]["仕入済数量"].ToString());
                }
                retSuryo = int.Parse((decimal.Round(d,0)).ToString());
            }

            return retSuryo;
        }

        public string getZaikoHikiateFlg(string strJuchuNo)
        {
            String retFlg = "";
            DataTable dtFlg = null;

            string strQuery = "SELECT 在庫引当フラグ FROM 受注 WHERE 受注番号=" + strJuchuNo + " AND 削除='N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtFlg = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dtFlg != null && dtFlg.Rows.Count > 0)
            {
                retFlg = dtFlg.Rows[0]["在庫引当フラグ"].ToString();
            }

            return retFlg;
        }

        public void delJuchu(string strJuchuNo, string strUser, DBConnective con)
        {
            List<String> aryPrm = new List<string>();
            List<String> aryCol = new List<string>();

            aryCol.Add("@ユーザー名");
            aryCol.Add("@受注番号");

            aryPrm.Add(strUser);
            aryPrm.Add(strJuchuNo);

            try
            {
                con.RunSql("受注入力削除_PROC", CommandType.StoredProcedure, aryPrm, aryCol);

                // 加工品受注情報を削除
                String strSQL = "";

                strSQL = "UPDATE 仮発注 ";
                strSQL += " SET 削除='Y' ,更新ユーザー名='" + strUser + "',更新日時=GETDATE()";
                strSQL += " WHERE 受注番号= " + strJuchuNo;
                con.RunSql(strSQL);

                strSQL = "UPDATE 発注 ";
                strSQL += " SET 削除='Y' ,更新ユーザー名='" + strUser + "',更新日時=GETDATE()";
                strSQL += " WHERE 受注番号= " + strJuchuNo;
                con.RunSql(strSQL);

                strSQL = "UPDATE 仮出庫ヘッダ  ";
                strSQL += " SET 削除='Y' ,更新ユーザー名='" + strUser + "',更新日時=GETDATE()";
                strSQL += " FROM 仮出庫明細 ";
                strSQL += " WHERE 仮出庫明細.受注番号= " + strJuchuNo;
                strSQL += " AND 仮出庫ヘッダ.伝票番号=仮出庫明細.伝票番号";
                con.RunSql(strSQL);

                strSQL = "UPDATE 出庫ヘッダ  ";
                strSQL += " SET 削除='Y' ,更新ユーザー名='" + strUser + "',更新日時=GETDATE()";
                strSQL += " FROM 出庫明細 ";
                strSQL += " WHERE 出庫明細.受注番号= " + strJuchuNo;
                strSQL += " AND 出庫ヘッダ.伝票番号=出庫明細.伝票番号";
                con.RunSql(strSQL);

                strSQL = "UPDATE 仮出庫明細  ";
                strSQL += " SET 削除='Y' ,更新ユーザー名='" + strUser + "',更新日時=GETDATE()";
                strSQL += " WHERE 受注番号= " + strJuchuNo;
                con.RunSql(strSQL);

                strSQL = "UPDATE 出庫明細  ";
                strSQL += " SET 削除='Y' ,更新ユーザー名='" + strUser + "',更新日時=GETDATE()";
                strSQL += " WHERE 受注番号= " + strJuchuNo;
                con.RunSql(strSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void delHachu(string strHachuban, string strUserName, DBConnective con)
        {
            string strSQL = "発注削除_PROC '" + strHachuban + "','" + strUserName + "'";

            try
            {
                con.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void restoreDeadStock(string strDsNo)
        {
            string strQuery = "UPDATE 受注キャンセル SET 新受注ＮＯ=NULL WHERE 管理ＮＯ=" + strDsNo;

            DBConnective dbCon = new DBConnective();
            dbCon.BeginTrans();
            try
            {
                dbCon.RunSql(strQuery);
                dbCon.Commit();
            }
            catch (Exception ex)
            {
                dbCon.Rollback();
                throw ex;
            }
        }

        public bool judKakohinJuchu(string strJuchuNo)
        {
            bool retFlg = false;
            DataTable dtFlg = null;
            string strQuery = "SELECT 受注番号 FROM 受注 WHERE 受注番号 =" + strJuchuNo + " AND 削除='N' AND 加工区分='1'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtFlg = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dtFlg != null && dtFlg.Rows.Count > 0)
            {
                retFlg = true;
            }
            else
            {
                strQuery = "SELECT 受注番号 FROM 出庫明細 WHERE 受注番号=" + strJuchuNo + " AND 削除='N'";

                try
                {
                    dbCon = new DBConnective();
                    dtFlg = dbCon.ReadSql(strQuery);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (dtFlg != null && dtFlg.Rows.Count > 0)
                {
                    retFlg = true;
                }
            }

            return retFlg;
        }
        public DataTable getJuchuNoInfo(string strJuchuNo)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT CONVERT(VARCHAR, 受注年月日, 111) as 受注年月日";
            strQuery += "      ,受注者コード";
            strQuery += "      ,得意先コード";
            strQuery += "      ,大分類コード";
            strQuery += "      ,中分類コード";
            strQuery += "      ,メーカーコード";
            strQuery += "      ,Ｃ１";
            strQuery += "      ,Ｃ２";
            strQuery += "      ,Ｃ３";
            strQuery += "      ,Ｃ４";
            strQuery += "      ,Ｃ５";
            strQuery += "      ,Ｃ６";
            strQuery += "      ,受注数量";
            strQuery += "      ,受注単価";
            strQuery += "      ,仕入単価";
            strQuery += "      ,CONVERT(VARCHAR, 納期, 111) as 納期";
            strQuery += "      ,注番";
            strQuery += "      ,営業所コード";
            strQuery += "      ,担当者コード";
            strQuery += "      ,得意先名称";
            strQuery += "      ,発注指示区分";
            strQuery += "      ,商品コード";
            strQuery += "      ,本社出庫数";
            strQuery += "      ,岐阜出庫数";
            strQuery += "      ,出荷指示区分";
            strQuery += "      ,在庫引当フラグ";
            strQuery += "      ,売上フラグ";
            strQuery += "      ,売上済数量";
            strQuery += "  FROM 受注";
            strQuery += " WHERE 受注番号 = " + strJuchuNo;
            strQuery += "   AND 削除     = 'N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getHatchuNoInfo(string strJuchuNo)
        {
            DataTable dtNo = null;

            string strQuery = "SELECT CONVERT(VARCHAR, 発注年月日, 111) as 発注年月日, 発注番号, 発注数量, 仕入済数量 FROM 発注 WHERE 受注番号=" + strJuchuNo + " AND 削除='N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtNo = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtNo;
        }

        public DataTable getHatchuData(string strHatchuNo)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT 発注数量";
            strQuery += "      ,仕入先コード";
            strQuery += "      ,CONVERT(VARCHAR, 納期, 111) as 納期";
            strQuery += "      ,注番";
            strQuery += "      ,担当者コード";
            strQuery += "      ,仕入先名称";
            strQuery += "  FROM 発注";
            strQuery += " WHERE 発注番号 = " + strHatchuNo;
            strQuery += "   AND 削除     = 'N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getShiireSuryouNoki(string strJuchuNo)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT 仕入済数量";
            strQuery += "  FROM 発注";
            strQuery += " WHERE 受注番号 = " + strJuchuNo;
            strQuery += "   AND 削除     = 'N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getShohin(string strShohinCd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT *";
            strQuery += "  FROM 商品";
            strQuery += " WHERE 商品コード = '" + strShohinCd + "'";
            strQuery += "   AND 削除     = 'N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getKinShiireTanka(string strShohinCd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT CONVERT(VARCHAR, H.伝票年月日, 111) as 伝票年月日, M.仕入単価, N.取引先名称";
            strQuery += "  FROM 仕入ヘッダ H, 仕入明細 M, 取引先 N";
            strQuery += " WHERE H.削除='N'";
            strQuery += "   AND M.削除 = 'N'";
            strQuery += "   AND N.削除 = 'N'";
            strQuery += "   AND H.伝票番号 = M.伝票番号";
            strQuery += "   AND H.仕入先コード = N.取引先コード";
            strQuery += "   AND M.商品コード = '" + strShohinCd + "'";
            strQuery += "   ORDER BY 伝票年月日 DESC";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getJuchuTanka(string strShohinCd, string strTokuCd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery = " SELECT CONVERT(VARCHAR, MAX(受注年月日), 111) AS 受注日";
            strQuery += "      ,受注単価";
            strQuery += "  FROM 受注";
            strQuery += " WHERE 削除 = 'N'";
            strQuery += "   AND 得意先コード = '" + strTokuCd + "'";
            strQuery += "   AND 商品コード = '" + strShohinCd + "'";
            strQuery += " GROUP BY 受注単価";
            strQuery += " ORDER BY 受注日 desc";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getShiireTanka(string strShohinCd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT CONVERT(VARCHAR, MAX(H.伝票年月日), 111) AS 仕入日, M.仕入単価";
            strQuery += "  FROM 仕入ヘッダ H, 仕入明細 M";
            strQuery += " WHERE H.削除='N'";
            strQuery += "   AND M.削除 = 'N'";
            strQuery += "   AND H.伝票番号 = M.伝票番号";
            strQuery += "   AND M.商品コード = '" + strShohinCd + "'";
            strQuery += "   GROUP BY M.仕入単価";
            strQuery += "   ORDER BY 仕入日 DESC";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getHikiate(string strJuchuNo)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT 在庫引当フラグ";
            strQuery += "  FROM 受注";
            strQuery += " WHERE 削除 = 'N'";
            strQuery += "   AND 受注番号 = '" + strJuchuNo + "'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getZaiko(string strEigyouCd, string strShohinNo)
        {
            DataTable dtRet = null;
            string strQuery = "";

            //strQuery += "SELECT 営業所コード, 在庫数, フリー在庫数, 在庫数未来, フリー在庫数未来";
            //strQuery += "  FROM 在庫数";
            //strQuery += " WHERE 商品コード = '" + strShohinNo + "'";
            //if (strEigyouCd != null)
            //{
            //    strQuery += "   AND 営業所コード = '" + strEigyouCd + "'";
            //}

            if (string.IsNullOrWhiteSpace(strEigyouCd)) {
                strQuery += "SELECT dbo.f_get指定日の在庫数('0001', '" + strShohinNo + "', '2050/12/31') + dbo.f_get指定日の在庫数('0002', '" + strShohinNo + "', '2050/12/31') AS 在庫数";
                strQuery += "      ,dbo.f_get指定日のフリー在庫数Ｂ(NULL, '" + strShohinNo + "' ,'2050/12/31') AS フリー在庫数";
                strQuery += "  FROM 商品 where 商品コード = '" + strShohinNo + "'";
            }
            else
            {
                strQuery += "SELECT dbo.f_get指定日の在庫数('" + strEigyouCd + "', '" + strShohinNo + "', '2050/12/31') AS 在庫数";
                strQuery += "      ,dbo.f_get指定日のフリー在庫数Ｂ('" + strEigyouCd + "', '" + strShohinNo + "' ,'2050/12/31') AS フリー在庫数";
                strQuery += "  FROM 商品 where 商品コード = '" + strShohinNo + "'";
            }

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getRiekiritsu(string strTokuisaki, string strShohin, string strDaibunrui, string strChubunrui, string strMaker)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT *";

            if (strShohin != null)
            {
                strQuery += "  FROM 商品別利益率";
            }
            else
            {
                strQuery += "  FROM 商品分類別利益率";
            }
            strQuery += " WHERE 削除 = 'N'";
            strQuery += "   AND 設定 = '1'";
            strQuery += "   AND 得意先コード = '" + strTokuisaki + "'";
            if (strShohin != null)
            {
                strQuery += "   AND 商品コード = '" + strShohin + "'";
            }
            else
            {
                if (strDaibunrui != null)
                {
                    strQuery += "   AND 大分類コード = '" + strDaibunrui + "'";
                }

                if (strChubunrui != null)
                {
                    strQuery += "   AND 中分類コード = '" + strChubunrui + "'";
                }
                else
                {
                    strQuery += "   AND 中分類コード IS NULL";
                }

                if (strMaker != null)
                {
                    strQuery += "   AND メーカーコード = '" + strMaker + "'";
                }
                else
                {
                    strQuery += "   AND メーカーコード IS NULL";
                }

            }

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getCodesFromShohin(string strShohinCd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT 大分類コード, 中分類コード, メーカーコード";
            strQuery += "  FROM 商品";
            strQuery += " WHERE 削除 = 'N'";
            strQuery += "   AND 商品コード = '" + strShohinCd + "'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public void updChubanOnly(string strJuchuNo, string strChuban)
        {
            string strQuery = "UPDATE 受注 SET 注番 = '" + strChuban + "' WHERE 受注番号 = " + strJuchuNo + " AND 削除 = 'N'";

            DBConnective dbCon = new DBConnective();
            dbCon.BeginTrans();
            try
            {
                dbCon.RunSql(strQuery);
                dbCon.Commit();
            }
            catch (Exception ex)
            {
                dbCon.Rollback();
                throw ex;
            }
        }

        public void updNokiOnly(string strChuban, string strNoki, string strSuryo, string strTanka
            , string strKin, string strShukkoH, string strShukkoG, string strJuchusha, string strJuchuNo
            , string strHachuNo, string strShiireNoki, DBConnective con)
        {

            string strQuery = " UPDATE 受注 ";
            strQuery += " SET ";
            strQuery += " 注番='" + strChuban + "',";
            strQuery += " 納期='" + strNoki + "',";
            strQuery += " 受注数量=" + strSuryo + ",";
            strQuery += " 受注単価=" + strTanka + ",";
            strQuery += " 受注金額=" + strKin + ",";
            strQuery += " 本社出庫数=" + strShukkoH + ",";
            strQuery += " 岐阜出庫数=" + strShukkoG + ",";
            strQuery += " 受注者コード='" + strJuchusha + "'";
            strQuery += " WHERE 受注番号=" + strJuchuNo + " AND 削除 = 'N'";

            try
            {
                con.RunSql(strQuery);

                if (!string.IsNullOrWhiteSpace(strHachuNo))
                {
                    strQuery = " UPDATE 発注 ";
                    strQuery += " SET ";
                    strQuery += " 納期='" + strShiireNoki + "'";
                    strQuery += " WHERE 発注番号=" + strHachuNo + " AND 削除 = 'N'";
                    con.RunSql(strQuery);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getDenpyoNo(string tableName)
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@テーブル名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(tableName);

            string strRet;

            DBConnective dbconnective = new DBConnective();
            try
            {
                // get伝票番号_PROC"を実行
                strRet = dbconnective.RunSqlRe("get伝票番号_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@番号");
            }
            catch
            {
                throw;
            }

            return strRet;
        }

        public DataTable getShohinForUpd(string strDaibunrui, string strChubunrui, string strMaker, string strHinmei)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT *";
            strQuery += "  FROM 商品";
            strQuery += " WHERE 削除     = 'N'";
            strQuery += "   AND 大分類コード = '" + strDaibunrui + "'";
            strQuery += "   AND 中分類コード = '" + strChubunrui + "'";
            strQuery += "   AND メーカーコード = '" + strMaker + "'";
            strQuery += "   AND REPLACE(ISNULL(Ｃ１,'')+ISNULL(Ｃ２,'')+ISNULL(Ｃ３,'')+ISNULL(Ｃ４,'')+ISNULL(Ｃ５,'')+ISNULL(Ｃ６,'') ,' ' ,'') = '" + strHinmei + "'";

            try
            {
                dtRet = dbConGr.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public void updJuchu(List<String> aryPrm, DBConnective con)
        {
            List<String> aryCol = new List<string>();

            aryCol.Add("@得意先コード");
            aryCol.Add("@得意先名称");
            aryCol.Add("@受注年月日");
            aryCol.Add("@受注番号");
            aryCol.Add("@受注者コード");
            aryCol.Add("@営業所コード");
            aryCol.Add("@担当者コード");
            aryCol.Add("@商品コード");
            aryCol.Add("@メーカーコード");
            aryCol.Add("@大分類コード");
            aryCol.Add("@中分類コード");
            aryCol.Add("@Ｃ１");
            aryCol.Add("@Ｃ２");
            aryCol.Add("@Ｃ３");
            aryCol.Add("@Ｃ４");
            aryCol.Add("@Ｃ５");
            aryCol.Add("@Ｃ６");
            aryCol.Add("@受注数量");
            aryCol.Add("@受注単価");
            aryCol.Add("@受注金額");
            aryCol.Add("@仕入単価");
            aryCol.Add("@粗利金額");
            aryCol.Add("@納期");
            aryCol.Add("@出荷指示区分");
            aryCol.Add("@在庫引当フラグ");
            aryCol.Add("@売上フラグ");
            aryCol.Add("@注番");
            aryCol.Add("@発注指示区分");
            aryCol.Add("@本社出庫数");
            aryCol.Add("@岐阜出庫数");
            aryCol.Add("@加工区分");
            aryCol.Add("@社内メモ");
            aryCol.Add("@ユーザー名");

            try
            {
                con.RunSql("受注入力更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updJuchuH(List<String> aryPrm, DBConnective con)
        {
            List<String> aryCol = new List<string>();

            aryCol.Add("@仕入先コード");
            aryCol.Add("@発注年月日");
            aryCol.Add("@発注番号");
            aryCol.Add("@発注者コード");
            aryCol.Add("@営業所コード");
            aryCol.Add("@担当者コード");
            aryCol.Add("@受注番号");
            aryCol.Add("@出庫番号");
            aryCol.Add("@行番号");
            aryCol.Add("@商品コード");
            aryCol.Add("@メーカーコード");
            aryCol.Add("@大分類コード");
            aryCol.Add("@中分類コード");
            aryCol.Add("@Ｃ１");
            aryCol.Add("@Ｃ２");
            aryCol.Add("@Ｃ３");
            aryCol.Add("@Ｃ４");
            aryCol.Add("@Ｃ５");
            aryCol.Add("@Ｃ６");
            aryCol.Add("@発注数量");
            aryCol.Add("@発注単価");
            aryCol.Add("@発注金額");
            aryCol.Add("@納期");
            aryCol.Add("@発注フラグ");
            aryCol.Add("@注番");
            aryCol.Add("@加工区分");
            aryCol.Add("@仕入先名称");
            aryCol.Add("@ユーザー名");

            try
            {
                con.RunSql("発注更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getChubanName(string cd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT 注番文字";
            strQuery += "  FROM 担当者";
            strQuery += " WHERE 削除     = 'N'";
            strQuery += "   AND 担当者コード     = '" + cd + "'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCon.DB_Disconnect();
            }

            string ret = ".";

            if (dtRet != null && dtRet.Rows.Count > 0)
            {
                ret = dtRet.Rows[0]["注番文字"].ToString();
            }

            return ret;
        }

        public DataTable getZaikoInfo(string strShohinNo)
        {
            DataTable dtRet = null;
            string strQuery = "";

            //strQuery += "SELECT b.営業所名 AS 営業所, a.在庫数 AS 在庫数";
            //strQuery += "      ,dbo.f_get商品別受注残数(b.営業所コード,'" + strShohinNo + "') AS 受注残";
            //strQuery += "      ,dbo.f_get商品別発注残数(b.営業所コード,'" + strShohinNo + "') AS 発注残";
            ////strQuery += "      ,dbo.f_get商品別受注残数加工品材料分(b.営業所コード,'" + strShohinNo + "')";
            //strQuery += "      ,dbo.f_get商品別発注残数受注有り(b.営業所コード,'" + strShohinNo + "') AS 発注残受";
            //strQuery += "      ,a.フリー在庫数 AS ﾌﾘｰ在庫";
            //strQuery += "  FROM 在庫数 a, 営業所 b";
            //strQuery += " WHERE a.商品コード = '" + strShohinNo + "'";
            //strQuery += "   AND a.営業所コード = b.営業所コード";
            //strQuery += "   AND b.削除 = 'N'";
            //strQuery += " ORDER BY b.営業所コード ";

            strQuery += "SELECT b.営業所名 AS 営業所";
            strQuery += "      ,dbo.f_get指定日の在庫数(b.営業所コード,'" + strShohinNo + "','2050/12/31') AS 在庫数";
            strQuery += "      ,dbo.f_get商品別受注残数(b.営業所コード,'" + strShohinNo + "') AS 受注残";
            strQuery += "      ,dbo.f_get商品別発注残数(b.営業所コード,'" + strShohinNo + "') AS 発注残";
            strQuery += "      ,dbo.f_get商品別発注残数受注有り(b.営業所コード,'" + strShohinNo + "') AS 発注残受";
            strQuery += "      ,dbo.f_get指定日のフリー在庫数Ｂ(b.営業所コード,'" + strShohinNo + "','2050/12/31') AS ﾌﾘｰ在庫";
            strQuery += "  FROM 営業所 b";
            strQuery += " WHERE b.削除 = 'N'";
            strQuery += " ORDER BY b.営業所コード ";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getJuchuZanInfo(string strCd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT a.受注番号 AS 受注番号";
            strQuery += "      ,a.注番 AS 注番";
            strQuery += "      ,dbo.f_getメーカー名(a.メーカーコード) AS メーカー";
            strQuery += "      ,dbo.f_get中分類名(a.大分類コード,a.中分類コード) AS 中分類名";
            //strQuery += "      ,RTRIM(ISNULL(a.Ｃ１,'')) + ' ' + ";
            //strQuery += "           RTRIM(ISNULL(a.Ｃ２,'')) + ' ' + ";
            //strQuery += "           RTRIM(ISNULL(a.Ｃ３,'')) + ' ' + ";
            //strQuery += "           RTRIM(ISNULL(a.Ｃ４,'')) + ' ' + ";
            //strQuery += "           RTRIM(ISNULL(a.Ｃ５,'')) + ' ' + ";
            //strQuery += "           RTRIM(ISNULL(a.Ｃ６,'')) AS 型番";
            strQuery += "      ,RTRIM(ISNULL(a.Ｃ１,'')) AS 型番";
            strQuery += "      ,a.受注数量 AS 受注数量";
            strQuery += "      ,CONVERT(VARCHAR, a.納期, 111) as 納期";
            strQuery += "      ,a.本社出庫数 AS 本社出庫";
            strQuery += "      ,a.岐阜出庫数 AS 岐阜出庫";
            strQuery += "      ,a.発注指示区分 AS 発注指示";
            strQuery += "  FROM 受注 a";
            strQuery += " WHERE a.得意先コード = '" + strCd + "'";
            strQuery += "   AND abs(a.受注数量) > abs(a.売上済数量) ";
            strQuery += "   AND a.削除 = 'N'";
            strQuery += " ORDER BY 納期, 受注番号";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getUserInfo(string strCd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT *";
            strQuery += "  FROM 担当者";
            strQuery += " WHERE ログインＩＤ = '" + strCd + "'";
            strQuery += "   AND 削除 = 'N'";


            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getUserInfoFromCd(string strCd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT *";
            strQuery += "  FROM 担当者";
            strQuery += " WHERE 担当者コード = '" + strCd + "'";
            strQuery += "   AND 削除 = 'N'";


            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public void updZaiko(bool bPlus, string eigyo, string shohin, string sSu, DBConnective con)
        {
            string strQuery = "";

            strQuery = "SELECT * FROM 在庫数";
            strQuery += " WHERE 商品コード = '" + shohin + "'";
            strQuery += "   AND 営業所コード = '" + eigyo + "'";

            try
            {
                DataTable dt = con.ReadSql(strQuery);
                if (dt == null || dt.Rows.Count == 0)
                {
                    strQuery = "INSERT INTO 在庫数";
                    strQuery += "(商品コード, 営業所コード, 在庫数, フリー在庫数, 在庫数未来, フリー在庫数未来, 登録日時, 登録ユーザー名, 更新日時, 更新ユーザー名) ";
                    strQuery += " VALUES ";
                    if (bPlus)
                    {
                        strQuery += "('" + shohin + "', '" + eigyo + "', " + sSu + ", " + sSu + ", 0, 0, '" + DateTime.Now.ToString() + "', '" + Environment.UserName + "', '" + DateTime.Now.ToString() + "', '" + Environment.UserName + "')";
                    }
                    else
                    {
                        strQuery += "('" + shohin + "', '" + eigyo + "', -" + sSu + ", -" + sSu + ", 0, 0, '" + DateTime.Now.ToString() + "', '" + Environment.UserName + "', '" + DateTime.Now.ToString() + "', '" + Environment.UserName + "')";
                    }
                }
                else
                {
                    strQuery = "UPDATE 在庫数 SET ";
                    if (bPlus)
                    {
                        strQuery += "在庫数 = 在庫数 + " + sSu;
                        strQuery += ", フリー在庫数 = フリー在庫数 + " + sSu;
                    }
                    else
                    {
                        strQuery += "在庫数 = 在庫数 - " + sSu;
                        strQuery += ", フリー在庫数 = フリー在庫数 - " + sSu;
                    }
                    strQuery += " WHERE 商品コード = '" + shohin + "'";
                    strQuery += "   AND 営業所コード = '" + eigyo + "'";
                }

                con.RunSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updZaiko(string shohin, string eigyo, string date, string user, DBConnective con)
        {
            string strSQL = "在庫数更新_PROC '" + shohin + "', '" + eigyo + "', '" + date + "', '" + user + "'";

            try
            {
                con.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public decimal getShukkoToroku(string strJuchuNo)
        {
            decimal retSuryo = 0;
            DataTable dtSuryo = null;

            string strQuery = "SELECT COUNT(*) AS 数 FROM 出庫明細 WHERE 受注番号=" + strJuchuNo + " AND 削除='N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtSuryo = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dtSuryo != null)
            {
                string st = dtSuryo.Rows[0]["数"].ToString();
                if (!string.IsNullOrWhiteSpace(st))
                {
                    retSuryo = decimal.Parse(st);
                }
            }

            return retSuryo;
        }

        public DataTable getTanto(string s)
        {
            DataTable dt = null;

            string strQuery = "";

            strQuery += "SELECT 担当者コード FROM 取引先 WHERE 削除 = 'N' AND 取引先コード = '" + s + "'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dt = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public void insAccept(string stNo, string user, DBConnective con)
        {
            string strQuery = "";

            strQuery += "SELECT * FROM 利益率承認 WHERE 受注番号 = " + stNo;
            DataTable dt = null;

            try
            {
                dt = con.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (dt != null && dt.Rows.Count > 0)
            {
                strQuery  = "UPDATE 利益率承認 SET 更新日時 = '" + DateTime.Now.ToString() + "', 更新ユーザー名 = '" + user + "'";
                strQuery += "WHERE 受注番号 = " + stNo;
            }
            else
            {
                strQuery  = "INSERT INTO 利益率承認";
                strQuery += " VALUES (";
                strQuery += stNo + ", 0, '" + DateTime.Now.ToString() + "', '" + user + "', '" + DateTime.Now.ToString() + "', '" + user + "')";
            }

            try
            {
                con.RunSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
