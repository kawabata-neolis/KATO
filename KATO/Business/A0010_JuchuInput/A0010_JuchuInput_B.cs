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
                retSuryo = dtSuryo.Rows[0].Field<int>("仕入済数量");
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
                retFlg = dtFlg.Rows[0].Field<string>("在庫引当フラグ");
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
    }
}
