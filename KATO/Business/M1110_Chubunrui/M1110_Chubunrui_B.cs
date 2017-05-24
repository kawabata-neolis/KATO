using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common;
using KATO.Common.Util;
using System.Windows.Forms;
using System.Data;

namespace KATO.Business.M1110_Chubunrui
{
    ///<summary>
    ///M1110_Chubunrui_B
    ///中分類フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M1110_Chubunrui_B
    {
        ///<summary>
        ///addChubunrui
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addChubunrui(List<string> lstString)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] { lstString[0], lstString[1], lstString[2], "N", DateTime.Now.ToString(), lstString[3], DateTime.Now.ToString(), lstString[3] };

                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_CHUBUNRUI_UPD, aryStr);

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
        ///delChubunrui
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delChubunrui(List<string> lstString)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] { lstString[0], lstString[1]};

                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_CHUBUNRUI_DEL, aryStr);

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
        ///updTxtChubunruiLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable updTxtChubunruiLeave(List<string> lstString)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLName = null;

            strSQLName = "C_LIST_Chubun_SELECT_LEAVE";

            //データ渡し用s
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLName);

            DataTable dtSetCd_B = new DataTable();
            OpenSQL opensql = new OpenSQL();
            DBConnective dbconnective = new DBConnective();
            try
            {
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //配列設定
                string[] aryStr = { lstString[0], lstString[1] };

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
