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
using KATO.Form.JuchuInput;

namespace KATO.Common.Business
{
    ///<summary>
    ///NyukinList_B
    ///中分類リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class NyukinList_B
    {
        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable setDatagridView(string strSetGrid)
        {
            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            //f_get取引先名称実行後のデータ用
            DataTable dtTorihikiName = null;

            //フォーマットするもの用
            string strSQLInput;

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstSQL = new List<string>();

                //検索時にテキストに書かれていない場合
                if (strSetGrid == "")
                {
                    //SQLファイルのパスとファイル名を追加
                    lstSQL.Add("Common");
                    lstSQL.Add("CommonForm");
                    lstSQL.Add("NyukinList_View");

                    //SQL発行
                    OpenSQL opensql = new OpenSQL();

                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQL);

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput);
                }
                else
                {
                    //得意先コードから得意先名称を取得
                    dtTorihikiName = dbconnective.ReadSql("SELECT dbo.f_get取引先名称('" + strSetGrid + "')");

                    //SQLファイルのパスとファイル名を追加
                    lstSQL.Add("Common");
                    lstSQL.Add("C_LIST_NyukinList_SELECT");

                    //SQL発行
                    OpenSQL opensql = new OpenSQL();

                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQL);

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput, dtTorihikiName);
                }

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
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>
        public void setSelectItem(int intFrmKind, string strDenpyo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_NyukinList_SELECT_Denpyo");

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
                strSQLInput = string.Format(strSQLInput, strDenpyo);

                //SQL接続後、該当データを取得
                dtSelectData = dbconnective.ReadSql(strSQLInput);

                //移動元フォームの検索
                switch (intFrmKind)
                {
                    //テスト用
                    case CommonTeisu.FRM_TEST:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //テスト用
                            if (frm.Name == "JuchuInput_Test")
                            {
                                //データを連れてくるため、newをしないこと
                                JuchuInput_Test test = (JuchuInput_Test)frm;
                                test.setDenpyo(dtSelectData);
                                break;
                            }
                        }
                        break;
                        
                    //取得したコードを元のフォームに送るメソッド
                    ////入金リストのフォームを探す
                    //if (frm.Name == "M1100_Chokusosaki")
                    //{
                    //    //データを連れてくるため、newをしないこと
                    //    M1100_Chokusosaki chokusosaki = (M1100_Chokusosaki)frm;
                    //    chokusosaki.setChokusoCode(dtSelectData);
                    //    break;
                    //}
                    //

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
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        public void setEndAction(int intFrm)
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
            }
        }
    }
}
