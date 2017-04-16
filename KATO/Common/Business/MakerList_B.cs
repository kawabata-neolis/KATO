using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Form.M_Chubunrui;
using KATO.Form.M_Daibunrui;
using KATO.Form.M_Maker;
using KATO.Form.TanaorosiInput;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Business
{
    class MakerList_B
    {
        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        public DataTable setDatagridView()
        {
            DataTable dtGetTableGrid = new DataTable();

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();

            //検索データを表示
            dtGetTableGrid = dbConnective.ReadSql("SELECT メーカーコード, メーカー名 FROM メーカー WHERE 削除 = 'N'");

            return (dtGetTableGrid);
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        public DataTable setKensaku(string strTxtDaibun, string strTxtKensaku, int RadioBtnJud)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strWhere = null;

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();

            strWhere = "WHERE a.削除 = 'N'";

            //大分類
            if (strTxtDaibun != "")
            {
                strWhere = strWhere + " AND a.メーカーコード IN (SELECT メーカーコード FROM 商品 WHERE 削除 = 'N' AND 大分類コード = '" + strTxtDaibun + "')";
            }

            if (strTxtKensaku != "")
            {
                //現行では検索不可能だが可能になった
                strWhere = strWhere + "AND a.メーカー名 LIKE '%" + strTxtKensaku + "%'";
            }

            //並び替えボタンクリック時の動き
            if (RadioBtnJud == 1)
            {
                dtGetTableGrid = dbConnective.ReadSql("SELECT a.メーカーコード, a.メーカー名 FROM メーカー a " + strWhere + " ORDER BY a.メーカーコード");
            }
            else
            {
                dtGetTableGrid = dbConnective.ReadSql("SELECT a.メーカーコード, a.メーカー名 FROM メーカー a " + strWhere + " ORDER BY a.メーカー名");
            }
            return (dtGetTableGrid);
        }


        ///<summary>
        ///setDatagridView
        ///戻るボタンの処理
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
                if (intFrmKind == 1 && frm.Name == "M_Daibunrui")
                {
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 2 && frm.Name == "M_Cyubunrui")
                {
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 3 && frm.Name == "M_Maker")
                {
                    //データを連れてくるため、newをしないこと
                    M_Maker maker = (M_Maker)frm;
                    maker.setmakerListClose();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 5 && frm.Name == "TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    TanaorosiInput tanaorosiinput = (TanaorosiInput)frm;
                    tanaorosiinput.setMakerListClose();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 6 && frm.Name == "TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    TanaorosiInput tanaorosiinput = (TanaorosiInput)frm;
                    tanaorosiinput.setMakerListCloseEdit();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 7 && frm.Name == "ShouhinList")
                {
                    //データを連れてくるため、newをしないこと
                    ShouhinList shouhinlist = (ShouhinList)frm;
                    shouhinlist.setMakerListClose();
                    break;
                }

            }
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
        public void setSelectItem(int intFrmKind, string strSelectid)
        {
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            switch (intFrmKind)
            {
                //大分類
                case 1:
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                //中分類
                case 2:
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                //メーカー
                case 3:
                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSelectData = dbconnective.ReadSql("SELECT メーカーコード, メーカー名 FROM メーカー WHERE 削除 = 'N' AND メーカーコード = '" + strSelectid + "'");

                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "M_Maker")
                        {
                            //データを連れてくるため、newをしないこと
                            M_Maker maker = (M_Maker)frm;
                            maker.setMakerCode(dtSelectData);
                            break;
                        }
                    }
                    break;
                case 5:
                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSelectData = dbconnective.ReadSql("SELECT メーカーコード, メーカー名 FROM メーカー WHERE 削除 = 'N' AND メーカーコード = '" + strSelectid + "'");

                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "TanaorosiInput")
                        {
                            //データを連れてくるため、newをしないこと
                            TanaorosiInput tanaorosinput = (TanaorosiInput)frm;
                            tanaorosinput.setMakerCode(dtSelectData);
                            break;
                        }
                    }
                    break;
                case 6:
                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSelectData = dbconnective.ReadSql("SELECT メーカーコード, メーカー名 FROM メーカー WHERE 削除 = 'N' AND メーカーコード = '" + strSelectid + "'");

                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "TanaorosiInput")
                        {
                            //データを連れてくるため、newをしないこと
                            TanaorosiInput tanaorosinput = (TanaorosiInput)frm;
                            tanaorosinput.setMakerEdit(dtSelectData);
                            break;
                        }
                    }
                    break;
                case 7:
                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSelectData = dbconnective.ReadSql("SELECT メーカーコード, メーカー名 FROM メーカー WHERE 削除 = 'N' AND メーカーコード = '" + strSelectid + "'");

                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "ShouhinList")
                        {
                            //データを連れてくるため、newをしないこと
                            ShouhinList shouhinlist = (ShouhinList)frm;
                            shouhinlist.setMakerCode(dtSelectData);
                            break;
                        }
                    }
                    break;
            }
        }

        ///<summary>
        ///judtxtDaibunTextLeave
        ///code入力箇所からフォーカスが外れた時
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        public DataTable judtxtDaibunTextLeave(string strTxtDaibun)
        {
            DataTable dtGetTable = new DataTable();

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();

            //該当する大分類コードと名前を確保
            dtGetTable = dbConnective.ReadSql("SELECT 大分類名 FROM 大分類 WHERE 大分類コード = '" + strTxtDaibun + "' AND 削除 = 'N'");

            return (dtGetTable);
        }
    }
}
