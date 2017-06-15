using KATO.Common.Util;
using KATO.Form.F0140_TanaorosiInput;
using KATO.Form.M1120_Tanaban;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Business
{
    ///<summary>
    ///TanabanList_B
    ///棚番リストフォーム
    ///作成者：大河内
    ///作成日：2017/3/23
    ///更新者：大河内
    ///更新日：2017/3/23
    ///カラム論理名
    ///</summary>
    class TanabanList_B
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
                lstSQL.Add("TanabanList_View");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //検索データを表示
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);

                return (dtGetTableGrid);
            }
            catch (Exception e)
            {
                throw (e);
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
        public void setEndAction(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //棚卸入力のフォームを探す
                if (intFrmKind == CommonTeisu.FRM_TANAOROSHI && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setTanabanListClose();
                    break;
                }
                //棚卸入力（修正）のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_TANAOROSHI_EDIT && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setTanaListCloseEdit();
                    break;
                }
                //棚番のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_TANABAN && frm.Name == "M1120_Tanaban")
                {
                    //データを連れてくるため、newをしないこと
                    M1120_Tanaban tanaban = (M1120_Tanaban)frm;
                    tanaban.setTanabanListClose();
                    break;
                }
            }
        }
        
        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        public void setSelectItem(int intFrmKind, List<string> lstString)
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
                lstSQL.Add("C_LIST_Tanaban_SELECT_LEAVE");

                //SQL発行
                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //SQLファイルのパス取得
                string[] aryStr = { lstString[0] };

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, aryStr);

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
                    //棚番
                    case CommonTeisu.FRM_TANABAN:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name.Equals("M1120_Tanaban"))
                            {
                                //データを連れてくるため、newをしないこと
                                M1120_Tanaban tanaban = (M1120_Tanaban)frm;
                                tanaban.setTanabanCd(dtSelectData);
                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }
    }
}
