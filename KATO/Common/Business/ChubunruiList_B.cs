using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Windows.Forms;
using KATO.Form.M1010_Daibunrui;
using KATO.Form.F0140_TanaorosiInput;
using KATO.Common.Form;
using KATO.Form.M1110_Chubunrui;

namespace KATO.Common.Business
{
    ///<summary>
    ///ChubunruiList_B
    ///中分類リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class ChubunruiList_B
    {
        ///<summary>
        ///getDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable getDatagridView(string strDaibun)
        {
            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstSQL = new List<string>();

                //SQLファイルのパスとファイル名を追加
                lstSQL.Add("Common");
                lstSQL.Add("CommonForm");
                lstSQL.Add("ChubunruiList_View");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strDaibun);

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
        ///setDatagridView
        ///テキストボックスに記述
        public DataTable getText(string strDaibun)
        {
            //テキストボックスに入れる用
            DataTable dtGetTableTxt = new DataTable();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstSQL = new List<string>();

                //SQLファイルのパスとファイル名を追加
                lstSQL.Add("Common");
                lstSQL.Add("C_LIST_Daibun_SELECT_LEAVE");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strDaibun);

                //SQL接続後、該当データを取得
                dtGetTableTxt = dbconnective.ReadSql(strSQLInput);
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
            return (dtGetTableTxt);
        }

        ///<summary>
        ///getSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>
        public void getSelectItem(int intFrmKind, string strChubunCd, string strdaibunCDsub)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstSQL = new List<string>();

                //SQLファイルのパスとファイル名を追加
                lstSQL.Add("Common");
                lstSQL.Add("C_LIST_Chubun_SELECT_LEAVE");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strdaibunCDsub, strChubunCd);

                //SQL接続後、該当データを取得
                dtSelectData = dbconnective.ReadSql(strSQLInput);

                //移動元フォームの検索
                switch (intFrmKind)
                {
                    //中分類
                    case CommonTeisu.FRM_CHUBUNRUI:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "M1110_Chubunrui")
                            {
                                //データを連れてくるため、newをしないこと
                                M1110_Chubunrui chubunrui = (M1110_Chubunrui)frm;
                                chubunrui.setChubunrui(dtSelectData);
                                break;
                            }
                        }
                        break;
                    //棚卸入力（商品リスト）
                    case CommonTeisu.FRM_SHOUHINLIST:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "ShouhinList")
                            {
                                //データを連れてくるため、newをしないこと
                                ShouhinList shouhinlist = (ShouhinList)frm;
                                shouhinlist.setChubunrui(dtSelectData);
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
        /// getSelectItemChk
        ///  存在チェック処理
        ///</summary>
        public DataTable getSelectItemChk(string strChubunCd, string strdaibunCDsub)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstSQL = new List<string>();

                //SQLファイルのパスとファイル名を追加
                lstSQL.Add("Common");
                lstSQL.Add("C_LIST_Chubun_SELECT_LEAVE");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strdaibunCDsub, strChubunCd);

                //SQL接続後、該当データを取得
                dtSelectData = dbconnective.ReadSql(strSQLInput);


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

            return dtSelectData;
        }
        ///<summary>
        ///FormMove
        ///戻るボタンの処理
        ///</summary>
        public void FormMove(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //中分類フォームを探す
                if (intFrmKind == CommonTeisu.FRM_CHUBUNRUI && frm.Name == "M1110_Chubunrui")
                {
                    //データを連れてくるため、newをしないこと
                    M1110_Chubunrui chubunrui = (M1110_Chubunrui)frm;
                    chubunrui.setChubunListClose();
                    break;
                }
                //棚卸入力フォームを探す
                else if (intFrmKind == CommonTeisu.FRM_TANAOROSHI && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setChubunruiListClose();
                    break;
                }
                //棚卸入力（修正側）のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_TANAOROSHI_EDIT && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setChubunListCloseEdit();
                    break;
                }
                //商品リストのフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_SHOUHINLIST && frm.Name == "ShouhinList")
                {
                    //データを連れてくるため、newをしないこと
                    ShouhinList shouhinlist = (ShouhinList)frm;
                    shouhinlist.setChubunruiListClose();
                    break;
                }
            }
        }
    }
}
