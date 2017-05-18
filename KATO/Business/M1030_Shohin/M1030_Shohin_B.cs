using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.M1030_Shohin
{
    ///<summary>
    ///M1030_Shohin_B
    ///商品フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M1030_Shohin_B
    {
        /// <summary>
        /// labelSet_Daibunrui_Leave
        /// C1からC2のラベルを表示
        /// </summary>
        public DataTable labelSet_Daibunrui_Leave(List<string> lstString)
        {
            //データ渡し用
            List<string> stringSQLAry = new List<string>();

            DataTable dtCset = new DataTable();

            string strSQLName = null;

            strSQLName = "Shohin_SELECT_SetC";

            //データ渡し用
            stringSQLAry.Add("M1030_Shohin");
            stringSQLAry.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            DBConnective dbconnective = new DBConnective();
            try
            {
                string strSQLInput = opensql.setOpenSQL(stringSQLAry);

                if (strSQLInput == "")
                {
                    return (dtCset);
                }

                //配列設定
                string[] aryStr = { lstString[0] };

                strSQLInput = string.Format(strSQLInput, aryStr);

                dtCset = dbconnective.ReadSql(strSQLInput);

                return (dtCset);
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
