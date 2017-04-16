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
    class M1020_Maker_B
    {
        ///<summary>
        ///addChubunrui
        ///テキストボックス内のデータをDBに登録
        ///作成者：大河内
        ///作成日：2017/3/22
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public void addMaker(List<string> lstString)
        {
            string strSQLName = null;

            //接続用クラスのインスタンス作成
            DBConnective dbConnective = new DBConnective();

            //トランザクション開始
            dbConnective.BeginTrans();

            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                strSQLName = "M1020_Maker_SELECT_Kaburi_ADD";

                //データ渡し用
                lstStringSQL.Add("M1020_Maker");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //配列設定
                string[] strArray = { lstString[0] };

                strSQLInput = string.Format(strSQLInput, strArray);

                lstStringSQL.Clear();

                //検索件数を表示
                int CoverCnt = int.Parse(dbConnective.ReadSql(strSQLInput).Rows[0][0].ToString());

                if (CoverCnt == 0)
                {
                    if (lstString[1] == "")
                    {
                        strSQLName = "M1020_Maker_INSERT";

                        //データ渡し用
                        lstStringSQL.Add("M1020_Maker");
                        lstStringSQL.Add(strSQLName);

                        opensql = new OpenSQL();
                        strSQLInput = opensql.setOpenSQL(lstStringSQL);

                        //配列初期化、再設定
                        strArray = new string[] { lstString[0], null, "N", DateTime.Now.ToString(), lstString[1], DateTime.Now.ToString(), lstString[2] };
                    }
                    else
                    {
                        strSQLName = "M1020_Maker_INSERT";

                        //データ渡し用
                        lstStringSQL.Add("M1020_Maker");
                        lstStringSQL.Add(strSQLName);

                        opensql = new OpenSQL();
                        strSQLInput = opensql.setOpenSQL(lstStringSQL);

                        //配列初期化、再設定
                        strArray = new string[] { lstString[0], lstString[1], "N", DateTime.Now.ToString(), lstString[2], DateTime.Now.ToString(), lstString[2] };
                    }
                }
                else if (CoverCnt == 1)
                {
                    if (lstString[1] == "")
                    {
                        strSQLName = "M1020_Maker_UPDATE";

                        //データ渡し用
                        lstStringSQL.Add("M1020_Maker");
                        lstStringSQL.Add(strSQLName);

                        opensql = new OpenSQL();
                        strSQLInput = opensql.setOpenSQL(lstStringSQL);

                        //配列初期化、再設定
                        strArray = new string[] { lstString[0], null, "N", DateTime.Now.ToString(), lstString[2] };
                    }
                    else
                    {
                        strSQLName = "M1020_Maker_UPDATE";

                        //データ渡し用
                        lstStringSQL.Add("M1020_Maker");
                        lstStringSQL.Add(strSQLName);

                        opensql = new OpenSQL();
                        strSQLInput = opensql.setOpenSQL(lstStringSQL);

                        //配列初期化、再設定
                        strArray = new string[] { lstString[0], lstString[1], "N", DateTime.Now.ToString(), lstString[2] };
                    }
                }

                strSQLInput = string.Format(strSQLInput, strArray);

                dbConnective.RunSql(strSQLInput);

                //コミット開始
                dbConnective.Commit();

                MessageBox.Show("正常に登録されました。", "登録", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                //ロールバック開始
                dbConnective.Rollback();
            }
            finally
            {
                //closeが入る
            }

        }

        ///<summary>
        ///delMaker
        ///テキストボックス内のデータをDBから削除
        ///作成者：大河内
        ///作成日：2017/3/22
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public bool delMaker(List<string> lstString)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            bool blDelFinish = false;

            string strSQLName = null;

            //接続用クラスのインスタンス作成
            DBConnective dbConnective = new DBConnective();

            //トランザクション開始
            dbConnective.BeginTrans();

            strSQLName = "M1020_Maker_SELECT_Kaburi_DEL";

            //データ渡し用
            lstStringSQL.Add("M1020_Maker");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //配列設定
            string[] strArray = { lstString[0]};

            strSQLInput = string.Format(strSQLInput, strArray);

            lstStringSQL.Clear();

            //検索件数を表示
            int CoverCnt = int.Parse(dbConnective.ReadSql(strSQLInput).Rows[0][0].ToString());

            if (CoverCnt == 0)
            {
                //該当するものが無い、ボタンの機能がない場合
                return (blDelFinish);
            }
            else if (CoverCnt == 1)
            {
                try
                {
                    if (DialogResult.OK == MessageBox.Show("表示中のレコードを削除します。よろしいですか。",
                        "削除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        strSQLName = "M1020_Maker_UPDATE_DELETE";

                        //データ渡し用
                        lstStringSQL.Add("M1020_Maker");
                        lstStringSQL.Add(strSQLName);

                        opensql = new OpenSQL();
                        strSQLInput = opensql.setOpenSQL(lstStringSQL);

                        //配列初期化、再設定
                        strArray = new string[] { lstString[0], DateTime.Now.ToString(), lstString[1]};

                        strSQLInput = string.Format(strSQLInput, strArray);

                        dbConnective.RunSql(strSQLInput);

                        //コミット開始
                        dbConnective.Commit();

                        MessageBox.Show("正常に削除されました。", "削除", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        blDelFinish = true;
                    }
                }
                catch
                {
                    //ロールバック開始
                    dbConnective.Rollback();
                }
                finally
                {
                    //closeが入る
                }
            }
            return (blDelFinish);
        }

        ///<summary>
        ///judtxtDaibunTextLeave
        ///code入力箇所からフォーカスが外れた時
        ///作成者：大河内
        ///作成日：2017/3/22
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public DataTable judtxtMakerTextLeave(List<string> lstString)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLName = null;

            strSQLName = "M1020_Maker_SELECT_LEAVE";

            //データ渡し用
            lstStringSQL.Add("M1020_Maker");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //配列設定
            string[] strArray = { lstString[0] };

            strSQLInput = string.Format(strSQLInput, strArray);

            DataTable dtsetcode_B;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //SQL文を直書き（＋戻り値を受け取る)
            dtsetcode_B = dbconnective.ReadSql(strSQLInput);

            return (dtsetcode_B);
        }
    }
}
