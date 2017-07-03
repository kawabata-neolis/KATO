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
        public int getUriagezumisuryo(string strJuchuNo)
        {
            int retSuryo = 0;
            DataTable dtSuryo = null;

            string strQuery = "SELECT 売上済数量 FROM 受注 WHERE 受注番号=" + strJuchuNo + " AND 削除='N'";

            try
            {
                DBConnective dbCon = new DBConnective();
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

            try
            {
                DBConnective dbCon = new DBConnective();
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

            try
            {
                DBConnective dbCon = new DBConnective();
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

            try
            {
                DBConnective dbCon = new DBConnective();
                dbCon.RunSql("受注入力削除_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void restoreDeadStock(string strDsNo)
        {
            string strQuery = "UPDATE 受注キャンセル SET 新受注ＮＯ=NULL WHERE 管理ＮＯ=" + strDsNo;

            try
            {
                DBConnective dbCon = new DBConnective();
                dbCon.RunSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool judKakohinJuchu (string strJuchuNo)
        {
            bool retFlg = false;
            DataTable dtFlg = null;
            string strQuery = "SELECT 受注番号 FROM 発注 WHERE 受注番号 =" + strJuchuNo + " AND 削除='N' AND 加工区分='1'";

            try
            {
                DBConnective dbCon = new DBConnective();
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
                    DBConnective dbCon = new DBConnective();
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

            strQuery += "SELECT 受注年月日";
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
            strQuery += "      ,納期";
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

            try
            {
                DBConnective dbCon = new DBConnective();
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

            try
            {
                DBConnective dbCon = new DBConnective();
                dtNo = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtNo;
        }
    }
}
