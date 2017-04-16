using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Windows.Forms;
using KATO.Form.M_Chubunrui;
using KATO.Form.TanaorosiInput;
using KATO.Common.Form;

namespace KATO.Common.Business
{
    class ChubunruiList_B
    {

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///作成者：大河内
        ///作成日：2017/3/22
        ///更新者：大河内
        ///更新日：2017/3/22
        ///カラム論理名
        ///</summary>
        public DataTable setDatagridView(string strDaibunruiCode)
        {
            DataTable dtGetTableGrid = new DataTable();

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();

            //該当する中分類の一覧を表示
            dtGetTableGrid = dbConnective.ReadSql("SELECT 中分類コード, 中分類名 FROM 中分類 WHERE 削除 = 'N' AND 大分類コード = '" + strDaibunruiCode + "'");

            return (dtGetTableGrid);
        }

        ///<summary>
        ///setDatagridView
        ///テキストボックスに記述
        ///作成者：大河内
        ///作成日：2017/3/22
        ///更新者：大河内
        ///更新日：2017/3/22
        ///カラム論理名
        ///</summary>
        public DataTable setText(string strtxtCD)
        {
            DataTable dtGetTableTxt = new DataTable();

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();

            //該当する大分類コードと名前を確保
            dtGetTableTxt = dbConnective.ReadSql("SELECT 大分類コード, 大分類名 FROM 大分類 WHERE 大分類コード = '" + strtxtCD + "'");

            return (dtGetTableTxt);
        }

        ///<summary>
        ///setName
        ///大分類名を記述
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        public DataTable setName(string strtxtCD)
        {
            DataTable dtGetTableTxt = new DataTable();

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //SQL文を直書き（＋戻り値を受け取る)
            dtGetTableTxt = dbconnective.ReadSql("SELECT 大分類名 FROM 大分類 WHERE 大分類コード = '" + strtxtCD + "'");

            return (dtGetTableTxt);
        }

        ///<summary>
        ///setSelectItem
        ///各画面へのデータ渡し
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        public void setSelectItem(int intFrmKind, string strTxtCD, string strSelectid)
        {
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //SQL文を直書き（＋戻り値を受け取る)
            dtSelectData = dbconnective.ReadSql("SELECT 中分類コード, 中分類名 FROM 中分類 WHERE 削除 = 'N' AND 大分類コード = '" + strTxtCD + "' AND 中分類コード = '" + strSelectid + "'");

            switch (intFrmKind)
            {
                //大分類
                case 1:
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                //中分類
                case 2:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "M_Chubunrui")
                        {
                            //データを連れてくるため、newをしないこと
                            M_Chubunrui chubunrui = (M_Chubunrui)frm;
                            chubunrui.setChubunrui(dtSelectData);
                            break;
                        }
                    }
                    break;
                case 5:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "TanaorosiInput")
                        {
                            //データを連れてくるため、newをしないこと
                            TanaorosiInput tanaorosinput = (TanaorosiInput)frm;
                            tanaorosinput.setCyubunrui(dtSelectData);
                            break;
                        }
                    }
                    break;
                case 6:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "TanaorosiInput")
                        {
                            //データを連れてくるため、newをしないこと
                            TanaorosiInput tanaorosinput = (TanaorosiInput)frm;
                            tanaorosinput.setChubunEdit(dtSelectData);
                            break;
                        }
                    }
                    break;

                case 7:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "ShouhinList")
                        {
                            //データを連れてくるため、newをしないこと
                            ShouhinList shouhinlist = (ShouhinList)frm;
                            shouhinlist.setCyubunrui(dtSelectData);
                            break;
                        }
                    }
                    break;

                default:
                    return;
            }
        }

        ///<summary>
        ///setEndAction
        ///元の画面に戻る
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        public void setEndAction(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //目的のフォームを探す
                if (intFrmKind == 1 && frm.Name == "Daibunrui")
                {
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 2 && frm.Name == "M_Chubunrui")
                {
                    //データを連れてくるため、newをしないこと
                    M_Chubunrui daibunrui = (M_Chubunrui)frm;
                    daibunrui.setChubunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 5 && frm.Name == "TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    TanaorosiInput tanaorosiinput = (TanaorosiInput)frm;
                    tanaorosiinput.setChubunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 6 && frm.Name == "TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    TanaorosiInput tanaorosiinput = (TanaorosiInput)frm;
                    tanaorosiinput.setChubunListCloseEdit();
                    break;
                }

                //目的のフォームを探す
                else if (intFrmKind == 6 && frm.Name == "TanaorosiInput")
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

