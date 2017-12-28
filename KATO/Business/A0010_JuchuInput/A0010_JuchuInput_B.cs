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

        public void commit ()
        {
            dbConGr.Commit();
        }

        public void rollback()
        {
            dbConGr.Rollback();
        }

        public int getUriagezumisuryo(string strJuchuNo)
        {
            int retSuryo = 0;
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
                retSuryo = dtSuryo.Rows[0].Field<int>("売上済数量");
            }

            return retSuryo;
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
                retSuryo = (int)dtSuryo.Rows[0]["仕入済数量"];
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

        public void delJuchu(string strJuchuNo, string strUser)
        {
            List<String> aryPrm = new List<string>();
            List<String> aryCol = new List<string>();

            aryCol.Add("@ユーザー名");
            aryCol.Add("@受注番号");

            aryPrm.Add(strUser);
            aryPrm.Add(strJuchuNo);

            DBConnective dbCon = new DBConnective();
            try
            {
                dbCon.BeginTrans();
                dbCon.RunSql("受注入力削除_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
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
            string strQuery = "SELECT 受注番号 FROM 発注 WHERE 受注番号 =" + strJuchuNo + " AND 削除='N' AND 加工区分='1'";

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

            strQuery += "SELECT FORMAT(受注年月日, 'yyyy/MM/dd') as 受注年月日";
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
            strQuery += "      ,FORMAT(納期, 'yyyy/MM/dd') as 納期";
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

            strQuery += "SELECT FORMAT(H.伝票年月日, 'yyyy/MM/dd') as 伝票年月日, M.仕入単価, N.仕入先名称";
            strQuery += "  FROM 仕入ヘッダ H, 仕入明細 M, 仕入先 N";
            strQuery += " WHERE H.削除='N'";
            strQuery += "   AND M.削除 = 'N'";
            strQuery += "   AND N.削除 = 'N'";
            strQuery += "   AND H.伝票番号 = M.伝票番号";
            strQuery += "   AND H.仕入先コード = N.仕入先コード";
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

            strQuery += "SELECT 営業所コード, 在庫数, フリー在庫数";
            strQuery += "  FROM 在庫数";
            strQuery += " WHERE 商品コード = '" + strShohinNo + "'";
            if (strEigyouCd != null) {
                strQuery += "   AND 営業所コード = '" + strEigyouCd + "'";
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

        public void updJuchu(List<String> aryPrm)
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
            aryCol.Add("@ユーザー名");

            try
            {
                dbConGr.RunSql("受注入力削除_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updJuchuH(List<String> aryPrm)
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
                dbConGr.RunSql("発注更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delHachu(string strHachuban, string strUserName)
        {
            string strSQL = null;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                strSQL = "発注削除_PROC '" + strHachuban + "','" + strUserName + "'";
                dbconnective.ReadSql(strSQL);

                //コミット開始
                dbconnective.Commit();
                return;
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
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

            strQuery += "SELECT b.営業所名 AS 営業所, a.在庫数 AS 在庫数";
            strQuery += "      ,dbo.f_get商品別受注残数(b.営業所コード,'" + strShohinNo + "') AS 受注残";
            strQuery += "      ,dbo.f_get商品別発注残数(b.営業所コード,'" + strShohinNo + "') AS 発注残";
            //strQuery += "      ,dbo.f_get商品別受注残数加工品材料分(b.営業所コード,'" + strShohinNo + "')";
            strQuery += "      ,dbo.f_get商品別発注残数受注有り(b.営業所コード,'" + strShohinNo + "') AS 発注残受";
            strQuery += "      ,a.フリー在庫数 AS ﾌﾘｰ在庫";
            strQuery += "  FROM 在庫数 a, 営業所 b";
            strQuery += " WHERE a.商品コード = '" + strShohinNo + "'";
            strQuery += "   AND a.営業所コード = b.営業所コード";
            strQuery += "   AND b.削除 = 'N'";
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
    }
}
