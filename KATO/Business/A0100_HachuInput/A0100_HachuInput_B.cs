using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.A0100_HachuInput_B
{
    ///<summary>
    ///A0100_HachuInput_B
    ///発注入力フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class A0100_HachuInput_B
    {
        ///<summary>
        ///setHachuGrid
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable setHachuGrid(List<string> lstString)
        {
            //データ渡し用
            List<string> stringSQLAry = new List<string>();

            string strSQLName = null;

            strSQLName = "C_LIST_HachuInput_SELECT_GRID";

            //データ渡し用
            stringSQLAry.Add("Common");
            stringSQLAry.Add(strSQLName);

            DataTable dtSetCd_B = new DataTable();
            OpenSQL opensql = new OpenSQL();
            DBConnective dbconnective = new DBConnective();
            try
            {
                string strSQLInput = opensql.setOpenSQL(stringSQLAry);

                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //配列設定
                string[] aryStr = { lstString[0] };

                strSQLInput = string.Format(strSQLInput, aryStr);

                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///setHachuLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable setHachuLeave(string strHachuban)
        {
            //データ渡し用
            List<string> stringSQLAry = new List<string>();

            string strSQLName = null;

            strSQLName = "C_LIST_HachuInput_SELECT_LEAVE";

            //データ渡し用
            stringSQLAry.Add("Common");
            stringSQLAry.Add(strSQLName);

            DataTable dtSetCd_B = new DataTable();
            OpenSQL opensql = new OpenSQL();
            DBConnective dbconnective = new DBConnective();
            try
            {
                string strSQLInput = opensql.setOpenSQL(stringSQLAry);

                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //配列設定
                string[] aryStr = { strHachuban };

                strSQLInput = string.Format(strSQLInput, aryStr);

                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }
    }
}
