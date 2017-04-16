using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Form.M_Chubunrui;
using KATO.Form.M_Daibunrui;
using KATO.Form.TanaorosiInput;

namespace KATO.Common.Business
{
    class DaibunruiList_B
    {

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///作成者：大河内
        ///作成日：2017/3/22
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
            dtGetTableGrid = dbConnective.ReadSql("SELECT 大分類コード, 大分類名 FROM 大分類 WHERE 削除 = 'N'");

            return (dtGetTableGrid);
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
                if (intFrmKind == 1 && frm.Name.Equals("M_Daibunrui"))
                {
                    //データを連れてくるため、newをしないこと
                    M_Daibunrui daibunrui = (M_Daibunrui)frm;
                    daibunrui.setDaibunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 2 && frm.Name.Equals("M_Chubunrui"))
                {
                    //データを連れてくるため、newをしないこと
                    M_Chubunrui daibunrui = (M_Chubunrui)frm;
                    daibunrui.setDaibunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 5 && frm.Name == "TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    TanaorosiInput tanaorosiinput = (TanaorosiInput)frm;
                    tanaorosiinput.setDaibunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 7 && frm.Name == "ShouhinList")
                {
                    //データを連れてくるため、newをしないこと
                    ShouhinList shouhinsist = (ShouhinList)frm;
                    shouhinsist.setDaibunruiListClose();
                    break;
                }
            }

        }

        ///<summary>
        ///setdgvSeihinDoubleClick
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
                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSelectData = dbconnective.ReadSql("SELECT 大分類コード, 大分類名,ラベル名１,ラベル名２,ラベル名３,ラベル名４,ラベル名５,ラベル名６ FROM 大分類 WHERE 大分類コード = '" + strSelectid + "'");

                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name.Equals("M_Daibunrui"))
                        {
                            //データを連れてくるため、newをしないこと
                            M_Daibunrui daibunrui = (M_Daibunrui)frm;
                            daibunrui.setDaibunrui(dtSelectData);
                            break;
                        }
                    }
                    break;

                //中分類
                case 2:
                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSelectData = dbconnective.ReadSql("SELECT 大分類コード, 大分類名 FROM 大分類 WHERE 大分類コード = '" + strSelectid + "'");

                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name.Equals("M_Chubunrui"))
                        {
                            //データを連れてくるため、newをしないこと
                            M_Chubunrui daibunrui = (M_Chubunrui)frm;
                            daibunrui.setDaibunrui(dtSelectData);
                            break;
                        }
                    }
                    break;
                //棚番
                case 5:
                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSelectData = dbconnective.ReadSql("SELECT 大分類コード, 大分類名 FROM 大分類 WHERE 大分類コード = '" + strSelectid + "'");

                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name.Equals("TanaorosiInput"))
                        {
                            //データを連れてくるため、newをしないこと
                            TanaorosiInput tanaorosinput = (TanaorosiInput)frm;
                            tanaorosinput.setDaibunrui(dtSelectData);
                            break;
                        }
                    }
                    break;
                //商品リスト
                case 7:
                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSelectData = dbconnective.ReadSql("SELECT 大分類コード, 大分類名 FROM 大分類 WHERE 大分類コード = '" + strSelectid + "'");

                    //全てのフォームの中から
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
            }
        }
    }
}
