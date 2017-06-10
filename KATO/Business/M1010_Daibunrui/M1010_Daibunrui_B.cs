using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Data;

namespace KATO.Business.M1010_Daibunrui
{
    ///<summary>
    ///M1010_Daibunrui_B
    ///大分類のビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M1010_Daibunrui_B
    {
        ///<summary>
        ///addDaibunrui
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addDaibunrui(List<string> lstString)
        {
            //
            //共通化されるので修正しないでください
            //

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

                //SQL接続、追加
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_DAIBUNRUI_UPD, aryStr);

                //コミット開始
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///delDaibunrui
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delDaibunrui(List<string> lstString)
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
                    "Y",
                    DateTime.Now.ToString(),
                    lstString[8],
                    DateTime.Now.ToString(),
                    lstString[8]
                };

                //SQL接続、削除
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_DAIBUNRUI_UPD, aryStr);

                //コミット開始
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();                
            }
        }

        ///<summary>
        ///updTxtDaibunruiLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable updTxtDaibunruiLeave(string strDaibunCD)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Daibun_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strDaibunCD);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }
    }
}
