using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Form.M1100_Chokusosaki;
using KATO.Form.A0020_UriageInput;

namespace KATO.Common.Business
{
    ///<summary>
    ///ChokusosakiList_B
    ///中分類リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class ChokusosakiList_B
    {
        ///<summary>
        ///getDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable getDatagridView(string strSetGrid)
        {
            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstSQL = new List<string>();

                //SQLファイルのパスとファイル名を追加
                lstSQL.Add("Common");
                lstSQL.Add("CommonForm");
                lstSQL.Add("ChokusosakiList_View");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strSetGrid);

                //検索データを表示
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
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
            return (dtGetTableGrid);
        }

        ///<summary>
        ///getSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>
        public void getSelectItem(int intFrmKind, string strChokusoCd, string strTokuiCdsub)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Chokusosaki_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSelectData = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strTokuiCdsub, strChokusoCd);

                //SQL接続後、該当データを取得
                dtSelectData = dbconnective.ReadSql(strSQLInput);

                //移動元フォームの検索
                switch (intFrmKind)
                {
                    //直送先
                    case CommonTeisu.FRM_CHOKUSOSAKI:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "M1100_Chokusosaki")
                            {
                                //データを連れてくるため、newをしないこと
                                M1100_Chokusosaki chokusosaki = (M1100_Chokusosaki)frm;
                                chokusosaki.setChokusoCode(dtSelectData);
                                break;
                            }
                        }
                        break;

                    //売上入力
                    case CommonTeisu.FRM_URIAGEINPUT:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "A0020_UriageInput")
                            {
                                //データを連れてくるため、newをしないこと
                                A0020_UriageInput uriageinput = (A0020_UriageInput)frm;
                                uriageinput.setChokusoCode(dtSelectData);
                                break;
                            }
                        }
                        break;

                    default:
                        break;
                }
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

        ///<summary>
        ///FormMove
        ///戻るボタンの処理
        ///</summary>
        public void FormMove(int intFrm)
        {
            //全てのフォームの中から移動元フォームの検索
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //直送先のフォームを探す
                if (intFrm == CommonTeisu.FRM_CHOKUSOSAKI && frm.Name == "M1100_Chokusosaki")
                {
                    //データを連れてくるため、newをしないこと
                    M1100_Chokusosaki chokusosaki = (M1100_Chokusosaki)frm;
                    chokusosaki.setChokuListClose();
                    break;
                }

                //売上入力のフォームを探す
                if (intFrm == CommonTeisu.FRM_URIAGEINPUT && frm.Name == "A0020_UriageInput")
                {
                    //データを連れてくるため、newをしないこと
                    A0020_UriageInput chokusosaki = (A0020_UriageInput)frm;
                    chokusosaki.setChokuListClose();
                    break;
                }
            }
        }
    }
}
