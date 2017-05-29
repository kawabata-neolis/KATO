using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common;
using KATO.Common.Util;
using System.Windows.Forms;
using System.Data;

namespace KATO.Business.M1020_Maker_B
{
    ///<summary>
    ///M1020_Maker_B
    ///メーカーの処理部
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M1020_Maker_B
    {
        ///<summary>
        ///addMaker
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addMaker(List<string> lstString)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] {
                    lstString[0],
                    lstString[1],
                    "N",
                    DateTime.Now.ToString(),
                    lstString[2],
                    DateTime.Now.ToString(),
                    lstString[2]
                };

                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_MAKER_UPD, aryStr);

                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();

                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///delMaker
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delMaker(List<string> lstString)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] {
                    lstString[0],
                    lstString[1],
                    "Y",
                    DateTime.Now.ToString(),
                    lstString[2],
                    DateTime.Now.ToString(),
                    lstString[2]
                };

                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_MAKER_UPD, aryStr);

                //コミット開始
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();

                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///updTxtMakerTextLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable updTxtMakerTextLeave(List<string> lstString)
        {
            //データ渡し用
            List<string> stringSQLAry = new List<string>();

            string strSQLName = null;

            strSQLName = "C_LIST_Maker_SELECT_LEAVE";

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
    }
}
