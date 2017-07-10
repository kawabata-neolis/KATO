using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KATO.Common.Util;

namespace KATO.Business.M1020_Maker_B
{
    ///<summary>
    ///M1020_Maker_B
    ///メーカーのビジネス層
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
        public void addMaker(List<string> lstMakerData)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] {
                    lstMakerData[0],
                    lstMakerData[1],
                    "N",
                    DateTime.Now.ToString(),
                    lstMakerData[2],
                    DateTime.Now.ToString(),
                    lstMakerData[2]
                };

                //SQL接続、追加
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_MAKER_UPD, aryStr);

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

                //SQL接続、削除
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_MAKER_UPD, aryStr);

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
        ///getTxtMakerTextLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable getTxtMakerTextLeave(string strMakerCD)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Maker_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL発行
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
                strSQLInput = string.Format(strSQLInput, strMakerCD);

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
