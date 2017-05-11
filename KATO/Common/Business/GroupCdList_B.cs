using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Form;
using KATO.Common.Util;
using System.Windows.Forms;

namespace KATO.Common.Business
{
    ///<summary>
    ///GroupCdList_B
    ///グループコードリストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class GroupCdList_B
    {
        string strSQLName = null;

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable setDatagridView()
        {
            DataTable dtGetTableGrid = new DataTable();

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                strSQLName = "";

                strSQLName = "GroupCdList_View";

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add("CommonForm");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //検索データを表示
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            return (dtGetTableGrid);
        }

        ///<summary>
        ///setEndAction
        ///元の画面に戻る
        ///</summary>
        public void setEndAction(List<int> lstInt)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                ////テキストボックスでの処理がある場合使用（要修正）
                ////目的のフォームを探す
                //if (lstInt[0] == 1 && frm.Name.Equals("M1010_Daibunrui"))
                //{
                //    //データを連れてくるため、newをしないこと
                //    M1010_Daibunrui daibunrui = (M1010_Daibunrui)frm;
                //    daibunrui.setDaibunruiListClose();
                //    break;
                //}
                //else
                //{
                //    break;
                //}
            }
        }
        
        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        public void setSelectItem(List<int> lstInt, List<string> lstString)
        {
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                strSQLName = "C_LIST_GroupCd_SELECT_LEAVE";

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //配列設定
                string[] aryStr = { lstString[0] };

                strSQLInput = string.Format(strSQLInput, aryStr);

                dtSelectData = dbconnective.ReadSql(strSQLInput);

                switch (lstInt[0])
                {
                    //////テキストボックスでの処理がある場合使用（要修正）
                    ////大分類
                    //case 1:
                    //    //全てのフォームの中から
                    //    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    //    {
                    //        //目的のフォームを探す
                    //        if (frm.Name.Equals("M1010_Daibunrui"))
                    //        {
                    //            //データを連れてくるため、newをしないこと
                    //            M1010_Daibunrui daibunrui = (M1010_Daibunrui)frm;
                    //            daibunrui.setDaibunrui(dtSelectData);
                    //            break;
                    //        }
                    //    }
                    //    break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }
    }
}
