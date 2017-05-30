using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.M1100_Chokusosaki
{
    ///<summary>
    ///M1100_Chokusosaki_B
    ///直送先フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M1100_Chokusosaki_B
    {
        ///<summary>
        ///addChokusosaki
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addChokusosaki(List<string> lstString)
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
                    lstString[2],
                    lstString[3],
                    lstString[4],
                    lstString[5],
                    lstString[6],
                    lstString[7],
                    "N",
                    DateTime.Now.ToString(),
                    lstString[8],
                    DateTime.Now.ToString(),
                    lstString[8]
                };

                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_CHOKUSOSAKI_UPD, aryStr);

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
        ///delChokusosaki
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delChokusosaki(List<string> lstString)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] {
                    lstString[0],
                    lstString[1],
                    lstString[2],
                    lstString[3],
                    lstString[4],
                    lstString[5],
                    lstString[6],
                    lstString[7],
                    "Y",
                    DateTime.Now.ToString(),
                    lstString[8],
                    DateTime.Now.ToString(),
                    lstString[8]
                };

                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_CHOKUSOSAKI_UPD, aryStr);

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
        ///updTxtChokusoLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable updTxtChokusoLeave(List<string> lstString)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLName = null;

            strSQLName = "C_LIST_Chokusosaki_SELECT_LEAVE";

            //データ渡し用
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
