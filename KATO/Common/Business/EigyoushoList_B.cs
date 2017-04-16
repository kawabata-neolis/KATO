using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Windows.Forms;
using KATO.Form.TanaorosiInput;

namespace KATO.Common.Business
{
    class EigyoushoList_B
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
            dtGetTableGrid = dbConnective.ReadSql("SELECT 営業所コード, 営業所名 FROM 営業所 WHERE 削除 = 'N'");

            dtGetTableGrid.Columns["営業所コード"].ColumnName = "業種コード";
            dtGetTableGrid.Columns["営業所名"].ColumnName = "業種名";

            return (dtGetTableGrid);
        }

        ///<summary>
        ///setEndAction
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
                if (intFrmKind == 1 && frm.Name.Equals("Daibunrui"))
                {
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 2 && frm.Name.Equals("Cyubunrui"))
                {
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 5 && frm.Name == "TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    TanaorosiInput tanaorosiinput = (TanaorosiInput)frm;
                    tanaorosiinput.setEigyoushoListClose();
                    break;
                }
            }
        }

        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
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
                    break;
                //中分類
                case 2:
                    break;
                //棚番
                case 5:
                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSelectData = dbconnective.ReadSql("SELECT 営業所コード, 営業所名 FROM 営業所 WHERE 営業所コード = '" + strSelectid + "'");

                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "TanaorosiInput")
                        {
                            //データを連れてくるため、newをしないこと
                            TanaorosiInput tanaorosinput = (TanaorosiInput)frm;
                            tanaorosinput.setEigyousho(dtSelectData);
                            break;
                        }
                    }
                    break;
            }
        }
    }
}
