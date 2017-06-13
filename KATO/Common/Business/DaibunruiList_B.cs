using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Form.M1010_Daibunrui;
using KATO.Form.M1110_Chubunrui;
using KATO.Form.F0140_TanaorosiInput;

namespace KATO.Common.Business
{
    ///<summary>
    ///DaibunruiList_B
    ///大分類リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class DaibunruiList_B
    {
        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable setDatagridView()
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
                lstSQL.Add("DaibunruiList_View");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

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
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        public void setEndAction(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //大分類のフォームを探す
                if (intFrmKind == CommonTeisu.FRM_DAIBUNRUI && frm.Name.Equals("M1010_Daibunrui"))
                {
                    //データを連れてくるため、newをしないこと
                    M1010_Daibunrui daibunrui = (M1010_Daibunrui)frm;
                    daibunrui.setDaibunruiListClose();
                    break;
                }
                //中分類のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_CHUBUNRUI && frm.Name.Equals("M1110_Chubunrui"))
                {
                    //データを連れてくるため、newをしないこと
                    M1110_Chubunrui chubunrui = (M1110_Chubunrui)frm;
                    chubunrui.setDaibunruiListClose();
                    break;
                }
                //棚卸入力のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_TANAOROSHI && frm.Name.Equals("F0140_TanaorosiInput"))
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setDaibunruiListClose();
                    break;
                }
                //商品リストのフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_SHOUHINLIST && frm.Name.Equals("ShouhinList"))
                {
                    //データを連れてくるため、newをしないこと
                    ShouhinList shouhinsist = (ShouhinList)frm;
                    shouhinsist.setDaibunruiListClose();
                    break;
                }
            }
        }

        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        public void setSelectItem(int intFrmKind, string strSelectId)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstStringSQL = new List<string>();

                //SQLファイルのパスとファイル名を追加
                lstStringSQL.Add("Common");
                lstStringSQL.Add("C_LIST_Daibun_SELECT_LEAVE");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strSelectId);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQL接続後、該当データを取得
                dtSelectData = dbconnective.ReadSql(strSQLInput);

                //移動元フォームの検索
                switch (intFrmKind)
                {
                    //大分類
                    case CommonTeisu.FRM_DAIBUNRUI:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //大分類のフォームを探す
                            if (frm.Name.Equals("M1010_Daibunrui"))
                            {
                                //データを連れてくるため、newをしないこと
                                M1010_Daibunrui daibunrui = (M1010_Daibunrui)frm;
                                daibunrui.setDaibunrui(dtSelectData);
                                break;
                            }
                        }
                        break;
                    //商品リスト
                    case CommonTeisu.FRM_SHOUHINLIST:
                        //商品リストのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name.Equals("ShouhinList"))
                            {
                                //データを連れてくるため、newをしないこと
                                ShouhinList shouhinlist = (ShouhinList)frm;
                                shouhinlist.setDaibunrui(dtSelectData);
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
    }
}
