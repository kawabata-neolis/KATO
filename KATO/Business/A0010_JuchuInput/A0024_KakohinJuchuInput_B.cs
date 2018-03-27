using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.A0010_JuchuInput
{
    class A0024_KakohinJuchuInput_B
    {
        DBConnective dbConGr;
        public void beginTrance()
        {
            dbConGr = new DBConnective();
            dbConGr.BeginTrans();
        }

        public void commit ()
        {
            dbConGr.Commit();
        }

        public void rollback()
        {
            dbConGr.Rollback();
        }

        public decimal getUriagezumisuryo(string strJuchuNo)
        {
            decimal retSuryo = -1;
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

            if (dtSuryo != null && dtSuryo.Rows.Count > 0)
            {
                string st = dtSuryo.Rows[0]["売上済数量"].ToString();
                if (string.IsNullOrWhiteSpace(st)) {
                    retSuryo = decimal.Parse(st);
                }
            }

            return retSuryo;
        }

        public decimal getShiirezumisuryo(string strJuchuNo)
        {
            decimal retSuryo = -1;
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
                string st = dtSuryo.Rows[0]["仕入済数量"].ToString();
                if (string.IsNullOrWhiteSpace(st)) {
                    retSuryo = decimal.Parse(st);
                }
            }

            return retSuryo;
        }

        public decimal getShiirezumisuryoH(string strHachuNo)
        {
            decimal retSuryo = -1;
            DataTable dtSuryo = null;

            string strQuery = "SELECT 仕入済数量 FROM 発注 WHERE 発注番号=" + strHachuNo + " AND 削除='N'";

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
                string st = dtSuryo.Rows[0]["仕入済数量"].ToString();
                if (!string.IsNullOrWhiteSpace(st)) {
                    retSuryo = decimal.Parse(st);
                }
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
                if (!string.IsNullOrWhiteSpace(st)) {
                    retSuryo = decimal.Parse(st);
                }
            }

            return retSuryo;
        }
        
        public string getShukkoFlg(string strJuchuNo)
        {
            String retFlg = "";
            DataTable dtFlg = null;

            string strQuery = "SELECT 出庫済フラグ FROM 出庫明細 WHERE 受注番号=" + strJuchuNo + " AND 削除='N'";

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
                retFlg = dtFlg.Rows[0]["出庫済フラグ"].ToString();
            }

            return retFlg;
        }

        //public void delJuchu(string strJuchuNo, string strUser)
        //{
        //    List<String> aryPrm = new List<string>();
        //    List<String> aryCol = new List<string>();

        //    aryCol.Add("@ユーザー名");
        //    aryCol.Add("@受注番号");

        //    aryPrm.Add(strUser);
        //    aryPrm.Add(strJuchuNo);

        //    DBConnective dbCon = new DBConnective();
        //    dbCon.DB_Connect();
        //    dbCon.BeginTrans();
        //    try
        //    {
        //        dbCon.BeginTrans();
        //        dbCon.RunSql("受注入力削除_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
                
        //        String strSQL = "";
        //        strSQL += "UPDATE 発注 ";
        //        strSQL += " SET 削除='Y' ,更新ユーザー名='" + strUser + "',更新日時=GETDATE()";
        //        strSQL += " WHERE 受注番号= " + strJuchuNo;
        //        dbCon.RunSql(strSQL);

        //        strSQL = "UPDATE 出庫ヘッダ  ";
        //        strSQL += " SET 削除='Y' ,更新ユーザー名='" + strUser + "',更新日時=GETDATE()";
        //        strSQL += " FROM 出庫明細 ";
        //        strSQL += " WHERE 出庫明細.受注番号= " + strJuchuNo;
        //        strSQL += " AND 出庫ヘッダ.伝票番号=出庫明細.伝票番号";
        //        dbCon.RunSql(strSQL);

        //        strSQL = "UPDATE 出庫明細  ";
        //        strSQL += " SET 削除='Y' ,更新ユーザー名='" + strUser + "',更新日時=GETDATE()";
        //        strSQL += " WHERE 受注番号= " + strJuchuNo;
        //        dbCon.RunSql(strSQL);
                
        //        dbCon.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        dbCon.Rollback();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbCon.DB_Disconnect();
        //    }

        //}


        public void updateShiireTanka(string strJuchuNo, string strTanka)
        {
            DBConnective dbCon = new DBConnective();
            try
            {
                dbCon.BeginTrans();

                String strSQL = "";
                strSQL += "UPDATE 受注 ";
                strSQL += " SET 仕入単価=" + strTanka;
                strSQL += " WHERE 受注番号= " + strJuchuNo + " AND 削除='N'";
                dbCon.RunSql(strSQL);

                dbCon.Commit();
            }
            catch (Exception ex)
            {
                dbCon.Rollback();
                throw ex;
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

        public bool judKakohinJuchu (string strJuchuNo)
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

            strQuery += "SELECT CONVERT(VARCHAR, a.受注年月日, 111) as 受注年月日";
            strQuery += "      ,a.受注者コード";
            strQuery += "      ,a.得意先コード";
            strQuery += "      ,a.大分類コード";
            strQuery += "      ,a.中分類コード";
            strQuery += "      ,a.メーカーコード";
            strQuery += "      ,a.Ｃ１";
            strQuery += "      ,a.Ｃ２";
            strQuery += "      ,a.Ｃ３";
            strQuery += "      ,a.Ｃ４";
            strQuery += "      ,a.Ｃ５";
            strQuery += "      ,a.Ｃ６";
            strQuery += "      ,a.受注数量";
            strQuery += "      ,a.受注単価";
            strQuery += "      ,a.仕入単価";
            strQuery += "      ,CONVERT(VARCHAR, a.納期, 111) as 納期";
            strQuery += "      ,a.注番";
            strQuery += "      ,a.営業所コード";
            strQuery += "      ,a.担当者コード";
            strQuery += "      ,a.得意先名称";
            strQuery += "      ,a.発注指示区分";
            strQuery += "      ,a.商品コード";
            strQuery += "      ,a.本社出庫数";
            strQuery += "      ,a.岐阜出庫数";
            strQuery += "      ,a.出荷指示区分";
            strQuery += "      ,a.在庫引当フラグ";
            strQuery += "      ,a.売上フラグ";
            strQuery += "      ,a.売上済数量";
            strQuery += "      ,b.定価";
            strQuery += "  FROM 受注 a left join 商品 as b on a.商品コード = b.商品コード and b.削除 = 'N'";
            strQuery += " WHERE a.受注番号 = " + strJuchuNo;
            strQuery += "   AND a.削除     = 'N'";

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

            string strQuery = "SELECT 発注番号, 仕入済数量 FROM 発注 WHERE 受注番号=" + strJuchuNo + " AND 削除='N'";

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
            strQuery += "      ,納期";
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

            strQuery = " SELECT MAX(受注年月日) AS 受注日";
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

            strQuery += "SELECT MAX(H.伝票年月日) AS 仕入日, M.仕入単価";
            strQuery += "  FROM 仕入ヘッダ H, 仕入明細 M";
            strQuery += " WHERE H.削除='N'";
            strQuery += "   AND M.削除 = 'N'";
            strQuery += "   AND H.伝票番号 = M.伝票番号";
            strQuery += "   AND M.商品コード = '" + strShohinCd + "'";
            strQuery += "   GROUP BY M.仕入単価";
            strQuery += "   ORDER BY H.仕入日 DESC";

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

            //strQuery += "SELECT 営業所コード, 在庫数, フリー在庫数";
            //strQuery += "  FROM 在庫数";
            //strQuery += " WHERE 商品コード = '" + strShohinNo + "'";
            //if (strEigyouCd != null) {
            //    strQuery += "   AND 営業所コード = '" + strEigyouCd + "'";
            //}
            if (string.IsNullOrWhiteSpace(strEigyouCd))
            {
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
            strQuery += "  FROM 商品別利益率";
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
            string strQuery = "UPDATE 受注 SET 注番 = '" + strChuban + "'WHERE 受注番号 = " + strJuchuNo;

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
            ,string strKin, string strShukkoH, string strShukkoG, string strJuchusha, string strJuchuNo
            ,string strHachuNo, string strShiireNoki)
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

            DBConnective dbCon = new DBConnective();
            try
            {
                dbCon.RunSql(strQuery);

                if (!string.IsNullOrWhiteSpace(strHachuNo))
                {
                    strQuery = " UPDATE 発注 ";
                    strQuery += " SET ";
                    strQuery += " 納期='" + strShiireNoki + "'";
                    strQuery += " WHERE 発注番号=" + strHachuNo + " AND 削除 = 'N'";
                    dbCon.RunSql(strQuery);
                    dbConGr.Commit();
                }

            }
            catch (Exception ex)
            {
                dbCon.Rollback();
                throw ex;
            }
        }

        public string getDenpyoNo(string tableName, DBConnective con)
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@テーブル名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(tableName);

            string strRet;

            try
            {
                // get伝票番号_PROC"を実行
                strRet = con.RunSqlRe("get伝票番号_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@番号");
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

        //public void updJuchu(List<String> aryPrm, DBConnective con)
        //{
        //    List<String> aryCol = new List<string>();

        //    aryCol.Add("@得意先コード");
        //    aryCol.Add("@得意先名称");
        //    aryCol.Add("@受注年月日");
        //    aryCol.Add("@受注番号");
        //    aryCol.Add("@受注者コード");
        //    aryCol.Add("@営業所コード");
        //    aryCol.Add("@担当者コード");
        //    aryCol.Add("@商品コード");
        //    aryCol.Add("@メーカーコード");
        //    aryCol.Add("@大分類コード");
        //    aryCol.Add("@中分類コード");
        //    aryCol.Add("@Ｃ１");
        //    aryCol.Add("@Ｃ２");
        //    aryCol.Add("@Ｃ３");
        //    aryCol.Add("@Ｃ４");
        //    aryCol.Add("@Ｃ５");
        //    aryCol.Add("@Ｃ６");
        //    aryCol.Add("@受注数量");
        //    aryCol.Add("@受注単価");
        //    aryCol.Add("@受注金額");
        //    aryCol.Add("@仕入単価");
        //    aryCol.Add("@粗利金額");
        //    aryCol.Add("@納期");
        //    aryCol.Add("@出荷指示区分");
        //    aryCol.Add("@在庫引当フラグ");
        //    aryCol.Add("@売上フラグ");
        //    aryCol.Add("@注番");
        //    aryCol.Add("@発注指示区分");
        //    aryCol.Add("@本社出庫数");
        //    aryCol.Add("@岐阜出庫数");
        //    aryCol.Add("@加工区分");
        //    aryCol.Add("@ユーザー名");

        //    try
        //    {
        //        con.RunSql("受注入力更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void updJuchuH(List<String> aryPrm, DBConnective con, bool kariFlg)
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
                con.RunSql("仮発注更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
                if (!kariFlg)
                {
                    con.RunSql("発注更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);

                    string strQ = "SELECT 商品コード, 営業所コード, CONVERT(VARCHAR, 発注年月日, 111) AS 発注年月日";
                    strQ += " FROM 発注";
                    strQ += " WHERE 発注番号 = " + aryPrm[2] + " AND 削除 = 'N'";

                    DataTable dt = con.ReadSql(strQ);

                    // 在庫更新
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string ymd = DateTime.Now.ToString("yyyy/MM/dd");
                            if (dr["発注年月日"] != null && dr["発注年月日"] != DBNull.Value && !string.IsNullOrWhiteSpace(dr["発注年月日"].ToString()))
                            {
                                ymd = dr["発注年月日"].ToString();
                            }
                            string strSQL = "在庫数更新_PROC '" + dr["商品コード"] + "', '" + dr["営業所コード"] + "', '" + ymd + "', '" + aryPrm[27] + "'";
                            con.ReadSql(strSQL);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updShukkoHead(List<String> aryPrm, DBConnective con, bool kariFlg)
        {
            List<String> aryCol = new List<string>();

            aryCol.Add("@伝票番号");
            aryCol.Add("@伝票年月日");
            aryCol.Add("@仕入先コード");
            aryCol.Add("@取引区分");
            aryCol.Add("@担当者コード");
            aryCol.Add("@営業所コード");
            aryCol.Add("@ユーザー名");
            aryCol.Add("@仕入先名称");

            try
            {
                con.RunSql("仮出庫ヘッダ更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
                if (!kariFlg)
                {
                    con.RunSql("出庫ヘッダ更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updNewShohin(List<String> aryPrm, DBConnective con)
        {
            List<String> aryCol = new List<string>();

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
            aryCol.Add("@発注区分");
            aryCol.Add("@標準売価");
            aryCol.Add("@仕入単価");
            aryCol.Add("@在庫管理区分");
            aryCol.Add("@棚番本社");
            aryCol.Add("@棚番岐阜");
            aryCol.Add("@メモ");
            aryCol.Add("@評価単価");
            aryCol.Add("@定価");
            aryCol.Add("@箱入数");
            aryCol.Add("@建値仕入単価");
            aryCol.Add("@コメント");
            aryCol.Add("@ユーザー名");

            try
            {
                con.RunSql("商品マスタ更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updShukkoMeisai(List<String> aryPrm, DBConnective con, bool kariFlg)
        {
            string strSQL = "仮出庫明細全削除_PROC '" + aryPrm[0] + "','" + aryPrm[18] + "'";
            con.ReadSql(strSQL);

            List<String> aryCol = new List<string>();

            aryCol.Add("@伝票番号");
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
            aryCol.Add("@数量");
            aryCol.Add("@単価");
            aryCol.Add("@備考");
            aryCol.Add("@出庫倉庫");
            aryCol.Add("@受注番号");
            aryCol.Add("@出庫予定日");
            aryCol.Add("@ユーザー名");

            try
            {
                con.RunSql("仮出庫明細更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
                if (!kariFlg)
                {
                    strSQL = "出庫明細全削除_PROC '" + aryPrm[0] + "','" + aryPrm[18] + "'";
                    con.ReadSql(strSQL);

                    con.RunSql("出庫明細更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);

                    // 在庫更新
                    string strQ = "SELECT 商品コード, 出庫倉庫, CONVERT(VARCHAR, 出庫予定日, 111) AS 出庫予定日";
                    strQ += " FROM 出庫明細";
                    strQ += " WHERE 伝票番号 = " + aryPrm[0] + " AND 削除 = 'N'";

                    DataTable dt = con.ReadSql(strQ);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string ymd = DateTime.Now.ToString("yyyy/MM/dd");
                            if (dr["出庫予定日"] != null && dr["出庫予定日"] != DBNull.Value && !string.IsNullOrWhiteSpace(dr["出庫予定日"].ToString()))
                            {
                                ymd = dr["出庫予定日"].ToString();
                            }
                            strSQL = "在庫数更新_PROC '" + dr["商品コード"] + "', '" + dr["出庫倉庫"] + "', '" + ymd + "', '" + aryPrm[18] + "'";
                            con.ReadSql(strSQL);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void delHachu(string strHachuban, string strUserName)
        //{
        //    string strSQL = null;

        //    //SQLのインスタンス作成
        //    DBConnective dbconnective = new DBConnective();

        //    //トランザクション開始
        //    dbconnective.BeginTrans();
        //    try
        //    {
        //        strSQL = "発注削除_PROC '" + strHachuban + "','" + strUserName + "'";
        //        dbconnective.ReadSql(strSQL);

        //        //コミット開始
        //        dbconnective.Commit();
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        //ロールバック開始
        //        dbconnective.Rollback();
        //        throw (ex);
        //    }
        //}

        public void delHachuS(string strHachuban, string strUserName, DBConnective con, bool hatchuFlg)
        {
            string strSQL = null;

            try
            {
                if (hatchuFlg) {
                    string strQ = "SELECT 商品コード, 営業所コード, CONVERT(VARCHAR, 発注年月日, 111) AS 発注年月日";
                    strQ += " FROM 発注";
                    strQ += " WHERE 発注番号 = " + strHachuban + " AND 削除 = 'N'";

                    DataTable dt = con.ReadSql(strQ);

                    strSQL = "仮発注削除_PROC '" + strHachuban + "','" + strUserName + "'";
                    con.ReadSql(strSQL);
                    strSQL = "発注削除_PROC '" + strHachuban + "','" + strUserName + "'";
                    con.ReadSql(strSQL);
                    
                    // 在庫更新
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string ymd = DateTime.Now.ToString("yyyy/MM/dd");
                            if (dr["発注年月日"] != null && dr["発注年月日"] != DBNull.Value && !string.IsNullOrWhiteSpace(dr["発注年月日"].ToString()))
                            {
                                ymd = dr["発注年月日"].ToString();
                            }
                            strSQL = "在庫数更新_PROC '" + dr["商品コード"] + "', '" + dr["営業所コード"] + "', '" + ymd + "', '" + strUserName + "'";
                            con.ReadSql(strSQL);
                        }
                    }
                }
                else {

                    string strQ = "SELECT 商品コード, 出庫倉庫, CONVERT(VARCHAR, 出庫予定日, 111) AS 出庫予定日";
                    strQ += " FROM 出庫明細";
                    strQ += " WHERE 伝票番号 = " + strHachuban + " AND 削除 = 'N'";

                    DataTable dt = con.ReadSql(strQ);

                    strSQL = "仮出庫ヘッダ削除_PROC '" + strHachuban + "','" + strUserName + "'";
                    con.ReadSql(strSQL);
                    strSQL = "出庫ヘッダ削除_PROC '" + strHachuban + "','" + strUserName + "'";
                    con.ReadSql(strSQL);

                    strSQL = "仮出庫明細全削除_PROC '" + strHachuban + "','" + strUserName + "'";
                    con.ReadSql(strSQL);
                    strSQL = "出庫明細全削除_PROC '" + strHachuban + "','" + strUserName + "'";
                    con.ReadSql(strSQL);

                    // 在庫更新
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string ymd = DateTime.Now.ToString("yyyy/MM/dd");
                            if (dr["出庫予定日"] != null && dr["出庫予定日"] != DBNull.Value && !string.IsNullOrWhiteSpace(dr["出庫予定日"].ToString()))
                            {
                                ymd = dr["出庫予定日"].ToString();
                            }
                            strSQL = "在庫数更新_PROC '" + dr["商品コード"] + "', '" + dr["出庫倉庫"] + "', '" + ymd + "', '" + strUserName + "'";
                            con.ReadSql(strSQL);
                        }
                    }
                }

                return;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string getChubanName(string cd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT 注番文字";
            strQuery += "  FROM 担当者";
            strQuery += " WHERE 削除     = 'N'";

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
            strQuery += "      ,dbo.f_get中分類名(a.大分類コード,a.中分類コード AS 中分類名";
            strQuery += "      ,RTRIM(ISNULL(a.Ｃ１,'')) + ' ' + ";
            strQuery += "           RTRIM(ISNULL(a.Ｃ２,'')) + ' ' + ";
            strQuery += "           RTRIM(ISNULL(a.Ｃ３,'')) + ' ' + ";
            strQuery += "           RTRIM(ISNULL(a.Ｃ４,'')) + ' ' + ";
            strQuery += "           RTRIM(ISNULL(a.Ｃ５,'')) + ' ' + ";
            strQuery += "           RTRIM(ISNULL(a.Ｃ６,'')) AS 型番";
            strQuery += "      ,a.受注数量 AS 受注数量";
            strQuery += "      ,a.納期 AS 納期";
            strQuery += "      ,a.本社出庫数 AS 本社出庫";
            strQuery += "      ,a.岐阜出庫数 AS 岐阜出庫";
            strQuery += "      ,a.発注指示区分 AS 発注指示";
            strQuery += "  FROM 受注 a";
            strQuery += " WHERE 得意先コード = '" + strCd + "'";
            strQuery += "   AND abs(a.受注数量) > abs(a.売上済数量) ";
            strQuery += "   AND a.削除 = 'N'";
            strQuery += " ORDER BY a.納期 ";

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

        public DataTable getRireki(string strJuchuNo)
        {
            DataTable dtRet = null;
            string strSelect = "";
            strSelect += " SELECT a.発注番号, a.仕入先コード, a.発注者コード, ";
            strSelect += "CASE WHEN a.加工区分='0' THEN '発注' ELSE '本加工' END AS 区分,  ";
            strSelect += "CONVERT(VARCHAR, a.発注年月日, 111) as 発注年月日,";
            strSelect += "a.大分類コード,";
            strSelect += "a.中分類コード,";
            strSelect += "a.メーカーコード,";
            strSelect += "c.棚番本社,";
            strSelect += "c.棚番岐阜,";
            strSelect += "a.注番, ";
            strSelect += "dbo.f_getメーカー名(a.メーカーコード)  ";
            strSelect += " + ' ' + dbo.f_get中分類名(a.大分類コード,a.中分類コード) +  ' '  +  Rtrim(ISNULL(a.Ｃ１,'')) ";
            strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ２,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ３,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ４,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ５,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ６,'')) AS 品名,";
            strSelect += "a.発注数量,";
            strSelect += "a.発注単価,";
            strSelect += "CONVERT(VARCHAR, a.納期, 111) as 納期,";
            strSelect += "a.仕入先名称 AS 仕入先名,";
            strSelect += "CONVERT(VARCHAR, dbo.f_get発注番号から仕入日(a.発注番号), 111) AS 仕入日,";
            strSelect += "a.仕入済数量,";
            strSelect += "CONVERT(VARCHAR, a.登録日時, 111) as 登録日時,";
            strSelect += " Rtrim(ISNULL(a.Ｃ１,'')) AS Ｃ１, ";
            strSelect += " Rtrim(ISNULL(a.Ｃ２,'')) AS Ｃ２, ";
            strSelect += " Rtrim(ISNULL(a.Ｃ３,'')) AS Ｃ３, ";
            strSelect += " Rtrim(ISNULL(a.Ｃ４,'')) AS Ｃ４, ";
            strSelect += " Rtrim(ISNULL(a.Ｃ５,'')) AS Ｃ５, ";
            strSelect += " Rtrim(ISNULL(a.Ｃ６,'')) AS Ｃ６, ";
            strSelect += " Rtrim(ISNULL(a.Ｃ１,'')) ";
            strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ２,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ３,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ４,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ５,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ６,'')) AS 型番,";
            strSelect += "a.商品コード AS 商品コード, ";
            strSelect += "a.営業所コード AS 営業所コード, ";
            strSelect += "'' AS 出庫倉庫, ";
            strSelect += "RTRIM(dbo.f_get注番文字FROM担当者 (a.発注者コード)) + CAST(a.発注番号 AS varchar(8)) AS 表注番 ";
            strSelect += " FROM 仮発注 a, 商品 c";
            strSelect += " WHERE a.受注番号 = " + strJuchuNo;
            strSelect += " AND a.削除 ='N'";
            strSelect += " AND c.削除 ='N'";
            strSelect += " AND a.商品コード = c.商品コード ";

            strSelect += "  UNION ALL ";
            strSelect += " SELECT a.伝票番号 AS 発注番号, a.仕入先コード, a.担当者コード AS 発注者コード, ";
            strSelect += "CASE a.取引区分 WHEN '41' THEN '出庫' WHEN '43' THEN '加工品出庫' END AS 区分,  ";
            strSelect += "CONVERT(VARCHAR, a.伝票年月日, 111) AS 発注年月日,";
            strSelect += "b.大分類コード,";
            strSelect += "b.中分類コード,";
            strSelect += "b.メーカーコード,";
            strSelect += "c.棚番本社,";
            strSelect += "c.棚番岐阜,";
            strSelect += "b.備考 AS 注番, ";
            strSelect += "dbo.f_getメーカー名(b.メーカーコード)  ";
            strSelect += " + ' ' + dbo.f_get中分類名(b.大分類コード,b.中分類コード) +  ' '  +  Rtrim(ISNULL(b.Ｃ１,'')) ";
            strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ２,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ３,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ４,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ５,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ６,'')) AS 品名,";
            strSelect += "b.数量 AS 発注数量,";
            strSelect += "b.単価 AS 発注単価,";
            strSelect += "CONVERT(VARCHAR, b.出庫予定日, 111) AS 納期,";
            strSelect += "a.仕入先名称 AS 仕入先名,";
            strSelect += "NULL AS 仕入日,";
            strSelect += "NULL AS 仕入済数量,";
            strSelect += "CONVERT(VARCHAR, b.登録日時, 111) as 登録日時,";
            strSelect += " Rtrim(ISNULL(b.Ｃ１,'')) AS Ｃ１, ";
            strSelect += " Rtrim(ISNULL(b.Ｃ２,'')) AS Ｃ２, ";
            strSelect += " Rtrim(ISNULL(b.Ｃ３,'')) AS Ｃ３, ";
            strSelect += " Rtrim(ISNULL(b.Ｃ４,'')) AS Ｃ４, ";
            strSelect += " Rtrim(ISNULL(b.Ｃ５,'')) AS Ｃ５, ";
            strSelect += " Rtrim(ISNULL(b.Ｃ６,'')) AS Ｃ６, ";
            strSelect += " Rtrim(ISNULL(b.Ｃ１,'')) ";
            strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ２,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ３,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ４,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ５,''))";
            strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ６,'')) AS 型番,";
            strSelect += "b.商品コード AS 商品コード, ";
            strSelect += "a.営業所コード AS 営業所コード, ";
            strSelect += "b.出庫倉庫 AS 出庫倉庫, ";
            strSelect += "'' as 表注番 ";
            strSelect += " FROM 仮出庫ヘッダ a, 仮出庫明細 b, 商品 c";
            strSelect += " WHERE a.伝票番号 = b.伝票番号 ";
            strSelect += " AND a.削除 ='N'";
            strSelect += " AND b.削除 ='N'";
            strSelect += " AND c.削除 ='N'";
            strSelect += " AND b.商品コード = c.商品コード ";
            strSelect += " AND b.受注番号 = " + strJuchuNo;
            strSelect += " AND (a.取引区分 ='41' OR a.取引区分 ='43')";

            //strSelect += "  UNION ALL ";
            //strSelect += " SELECT a.伝票番号,";
            //strSelect += "CASE a.取引区分 WHEN '42' THEN '入庫(原在)' WHEN '44' THEN '入庫(原)' END AS 区分,  ";
            //strSelect += "a.伝票年月日,";
            //strSelect += "b.備考, ";
            //strSelect += "dbo.f_getメーカー名(b.メーカーコード)  ";
            //strSelect += " + ' ' + dbo.f_get中分類名(b.大分類コード,b.中分類コード) +  ' '  +  Rtrim(ISNULL(b.Ｃ１,'')) ";
            //strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ２,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ３,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ４,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ５,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ６,'')),";
            //strSelect += "b.数量,";
            //strSelect += "b.単価,";
            //strSelect += "b.出庫予定日,";
            //strSelect += "a.仕入先名称 AS 仕入先名,";
            //strSelect += "NULL,";
            //strSelect += "NULL,";
            //strSelect += "b.登録日時,";
            //strSelect += " Rtrim(ISNULL(b.Ｃ１,'')) ";
            //strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ２,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ３,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ４,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ５,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(b.Ｃ６,'')),";
            //strSelect += "b.商品コード AS 商品コード";
            //strSelect += " FROM 出庫ヘッダ a,出庫明細 b";
            //strSelect += " WHERE a.伝票番号 = b.伝票番号 ";
            //strSelect += " AND a.削除 ='N'";
            //strSelect += " AND b.削除 ='N'";
            //strSelect += " AND b.受注番号 = " + strJuchuNo;
            //strSelect += " AND (a.取引区分 ='42' OR a.取引区分 ='44')";

            //strSelect += "  UNION ALL ";
            //strSelect += " SELECT a.発注番号,";
            //strSelect += " '仮加工' AS 区分,  ";
            //strSelect += "a.発注年月日,";
            //strSelect += "NULL AS 注番, ";
            //strSelect += "dbo.f_getメーカー名(a.メーカーコード)  ";
            //strSelect += " + ' ' + dbo.f_get中分類名(a.大分類コード,a.中分類コード) +  ' '  +  Rtrim(ISNULL(a.Ｃ１,'')) ";
            //strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ２,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ３,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ４,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ５,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ６,'')) AS 品名,";
            //strSelect += "a.発注数量,";
            //strSelect += "a.発注単価,";
            //strSelect += "a.納期,";
            //strSelect += "a.仕入先名称 AS 仕入先名,";
            //strSelect += "NULL AS 仕入日,";
            //strSelect += "NULL AS 仕入済数量,";
            //strSelect += "a.登録日時,";
            //strSelect += " Rtrim(ISNULL(a.Ｃ１,'')) ";
            //strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ２,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ３,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ４,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ５,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(a.Ｃ６,'')) AS 型番,";
            //strSelect += "a.商品コード AS 商品コード";
            //strSelect += " FROM 仮加工 a";
            //strSelect += " WHERE a.受注番号 = " + strJuchuNo;
            //strSelect += " AND a.削除 ='N'";

            strSelect = "SELECT * FROM ( " + strSelect + ") Z  ";

            strSelect += " ORDER BY 登録日時";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getHachu(string strNo)
        {
            DataTable dtRet = null;
            string strSelect = "";
            strSelect += "SELECT *";
            strSelect += "  FROM 発注";
            strSelect += " WHERE 発注番号 = " + strNo;
            strSelect += "   AND 削除 ='N'";

            strSelect += " ORDER BY 登録日時";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getShukko(string strNo, string strNoJ)
        {
            DataTable dtRet = null;
            string strSelect = "";
            strSelect += " SELECT H.*,M.* FROM";
            strSelect += " FROM 出庫ヘッダ H,出庫明細 M";
            strSelect += " WHERE H.伝票番号=M.伝票番号 ";
            strSelect += " AND H.削除 ='N'";
            strSelect += " AND M.削除 ='N'";
            strSelect += " AND H.伝票番号 = " + strNo;
            strSelect += " AND M.受注番号 = " + strNoJ;

            strSelect += " ORDER BY 登録日時";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getShukkoSu(string strNo)
        {
            DataTable dtRet = null;
            string strSelect = "";
            strSelect += " SELECT 数量 FROM";
            strSelect += " 出庫明細";
            strSelect += " WHERE 削除 ='N'";
            strSelect += " AND 伝票番号 = " + strNo;
            
            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public string getUriageTanka(string strNo, string strCd)
        {
            string ret = "0";
            DataTable dt = null;
            string strSQL = " SELECT TOP 1 M.売上単価 FROM 売上ヘッダ H, 売上明細 M ";
            strSQL += " WHERE H.得意先コード='" + strNo + "'";
            strSQL += " AND M.商品コード='" + strCd + "'";
            strSQL += " AND H.伝票番号=M.伝票番号";
            strSQL += " ORDER BY H.伝票年月日 DESC";

            DBConnective dbCon = new DBConnective();
            try
            {
                dt = dbCon.ReadSql(strSQL);

                if (dt != null && dt.Rows.Count > 0)
                {
                    ret = dt.Rows[0]["売上単価"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public DataTable getShukkoTanka(string strNo, string strCd)
        {
            DataTable dtRet = null;
            string strSelect = "";
            strSelect += " SELECT 発注単価";
            strSelect += " FROM 発注";
            strSelect += " WHERE 削除 ='N'";
            strSelect += " AND 受注番号 = " + strNo;
            strSelect += " AND 商品コード='" + strCd + "'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);
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

        public DataTable getShiire(string strNo)
        {
            DataTable dtRet = null;
            string strSelect = "";
            strSelect += "SELECT *";
            strSelect += "  FROM 仕入明細";
            strSelect += " WHERE 発注番号 = " + strNo;
            strSelect += "   AND 削除 ='N'";

            strSelect += " ORDER BY 登録日時";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public string getExecHatchu(string strNo, string kbn)
        {
            string ret = "";
            DataTable dtRet = null;
            string strSelect = "";
            strSelect += "SELECT 発注.発注番号";
            strSelect += "  FROM 発注, 仮出庫ヘッダ, 仮出庫明細";
            strSelect += " WHERE 仮出庫ヘッダ.伝票番号 = " + strNo;
            strSelect += "   AND 仮出庫ヘッダ.取引区分 = '" + kbn + "'";
            strSelect += "   AND 仮出庫ヘッダ.削除 ='N'";
            strSelect += "   AND 仮出庫明細.伝票番号 = 仮出庫ヘッダ.伝票番号";
            strSelect += "   AND 仮出庫明細.削除 ='N'";
            strSelect += "   AND 発注.受注番号 = 仮出庫明細.受注番号";
            strSelect += "   AND 発注.削除 ='N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);

                if (dtRet != null && dtRet.Rows.Count > 0)
                {
                    ret = dtRet.Rows[0]["発注番号"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public string getExecShukko(string strNo, string kbn, string stC)
        {
            string ret = "";

            string kakoKbn = "0";

            if ("43".Equals(kbn))
            {
                kakoKbn = "1";
            }

            DataTable dtRet = null;
            string strSelect = "";
            strSelect += "SELECT 仕入明細.伝票番号";
            strSelect += "  FROM 仕入明細, 発注, 仮出庫ヘッダ, 仮出庫明細";
            strSelect += " WHERE 仮出庫ヘッダ.伝票番号 = " + strNo;
            strSelect += "   AND 仮出庫ヘッダ.取引区分 = '" + kbn + "'";
            strSelect += "   AND 仮出庫ヘッダ.削除 ='N'";
            strSelect += "   AND 仮出庫明細.伝票番号 = 仮出庫ヘッダ.伝票番号";
            strSelect += "   AND 仮出庫明細.削除 ='N'";
            strSelect += "   AND 発注.受注番号 = 仮出庫明細.受注番号";
            //strSelect += "   AND Rtrim(ISNULL(発注.Ｃ１,'')) ";
            //strSelect += " + ' ' + Rtrim(ISNULL(発注.Ｃ２,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(発注.Ｃ３,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(発注.Ｃ４,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(発注.Ｃ５,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(発注.Ｃ６,'')) = '" + stC + "'";
            strSelect += "   AND 発注.削除 ='N'";
            strSelect += "   AND 発注.加工区分 ='" + kakoKbn + "'";
            strSelect += "   AND 仕入明細.発注番号 = 発注.発注番号";
            strSelect += "   AND 仕入明細.削除 ='N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);

                if (dtRet != null && dtRet.Rows.Count > 0)
                {
                    ret = dtRet.Rows[0]["伝票番号"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public void execShukko(string strNo, DBConnective con)
        {
            //DBConnective dbCon = new DBConnective();
            try
            {
                //con.BeginTrans();

                String strSQL = "";
                strSQL += "INSERT INTO 出庫ヘッダ ";
                strSQL += " SELECT * FROM 仮出庫ヘッダ";
                strSQL += " WHERE 伝票番号= " + strNo + " AND 削除='N'";
                con.RunSql(strSQL);

                strSQL = "INSERT INTO 出庫明細 ";
                strSQL += " SELECT * FROM 仮出庫明細";
                strSQL += " WHERE 伝票番号= " + strNo + " AND 削除='N'";
                con.RunSql(strSQL);

                //con.Commit();
            }
            catch (Exception ex)
            {
                //con.Rollback();
                throw ex;
            }
        }

        public DataTable getExecKako(string strNo, string stC)
        {
            DataTable dtRet = null;
            string strSelect = "";
            strSelect += "SELECT *";
            strSelect += "  FROM 出庫明細";
            strSelect += " WHERE 受注番号 = " + strNo;
            //strSelect += "   AND Rtrim(ISNULL(Ｃ１,'')) ";
            //strSelect += " + ' ' + Rtrim(ISNULL(Ｃ２,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(Ｃ３,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(Ｃ４,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(Ｃ５,''))";
            //strSelect += " + ' ' + Rtrim(ISNULL(Ｃ６,'')) = '" + stC + "'";
            strSelect += "   AND 削除 ='N'";

            strSelect += " ORDER BY 登録日時";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public void execKako(string strNo, DBConnective con)
        {
            //DBConnective dbCon = new DBConnective();
            try
            {
                //dbCon.BeginTrans();

                String strSQL = "";
                strSQL += "INSERT INTO 発注 ";
                strSQL += " SELECT * FROM 仮発注";
                strSQL += " WHERE 発注番号= " + strNo + " AND 削除='N'";
                con.RunSql(strSQL);

                //dbCon.Commit();
            }
            catch (Exception ex)
            {
                //dbCon.Rollback();
                throw ex;
            }
        }

        public DataTable getOverlapShukko(string strNo, string kbn)
        {
            DataTable dtRet = null;
            string strSelect = "";
            strSelect += "SELECT *";
            strSelect += "  FROM 出庫ヘッダ";
            strSelect += " WHERE 伝票番号 = " + strNo;
            strSelect += "   AND 取引区分 = '" + kbn + "'";
            strSelect += "   AND 削除 ='N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getHonShukko (string strNo, string kbn)
        {
            DataTable dtRet = null;
            string strSelect = "";
            strSelect += "SELECT *";
            strSelect += "  FROM 仮出庫ヘッダ";
            strSelect += " WHERE 伝票番号 = " + strNo;
            strSelect += "   AND 取引区分 = '" + kbn + "'";
            strSelect += "   AND 削除 ='N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getHonKako(string strNo)
        {
            DataTable dtRet = null;
            string strSelect = "";
            strSelect += "SELECT *";
            strSelect += "  FROM 仮発注";
            strSelect += " WHERE 発注番号 = " + strNo;
            strSelect += "   AND 削除 ='N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strSelect);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }
    }
}
