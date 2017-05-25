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

                strSQLName = "DaibunruiList_View";

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
                //目的のフォームを探す
                if (lstInt[0] == CommonTeisu.FRM_DAIBUNRUI && frm.Name.Equals("M1010_Daibunrui"))
                {
                    //データを連れてくるため、newをしないこと
                    M1010_Daibunrui daibunrui = (M1010_Daibunrui)frm;
                    daibunrui.setDaibunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == CommonTeisu.FRM_CHUBUNRUI && frm.Name.Equals("M1110_Chubunrui"))
                {
                    //データを連れてくるため、newをしないこと
                    M1110_Chubunrui chubunrui = (M1110_Chubunrui)frm;
                    chubunrui.setDaibunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == CommonTeisu.FRM_TANAOROSHI && frm.Name.Equals("F0140_TanaorosiInput"))
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setDaibunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == CommonTeisu.FRM_SHOUHINLIST && frm.Name.Equals("ShouhinList"))
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
        public void setSelectItem(List<int> lstInt, List<string> lstString)
        {
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                strSQLName = "C_LIST_Daibun_SELECT_LEAVE";

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
                    //大分類
                    case CommonTeisu.FRM_DAIBUNRUI:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
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
