using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;


namespace KATO.Business.JuchuInput
{
    class JuchuInput_B
    {
        public DataTable baseText1_Leave(string strBaseText1)
        {
            string strSQLName = null;

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            strSQLName = "JuchuInput_Chubun_SELECT_LEAVE";

            //データ渡し用
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //配列設定
            string[] aryStr = { strBaseText1 };

            strSQLInput = string.Format(strSQLInput, aryStr);

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            DataTable dtSetCd_B = new DataTable();

            //SQL文を直書き（＋戻り値を受け取る)
            dtSetCd_B = dbconnective.ReadSql(strSQLInput);

            return (dtSetCd_B);
        }
    }
}
