﻿using System;
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
        string strSQLName = null;

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable setDatagridView(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                strSQLName = "";

                strSQLName = "ChubunruiList_View";

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add("CommonForm");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //配列設定
                string[] strArray = { lstString[0] };

                strSQLInput = string.Format(strSQLInput, strArray);

                //検索データを表示
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception e)
            {
                new CommonException(e);
                throw (e);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return (dtGetTableGrid);
        }

        ///<summary>
        ///setDatagridView
        ///テキストボックスに記述
        public DataTable setText(List<string> lstString)
        {
            DataTable dtGetTableTxt = new DataTable();

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                strSQLName = "";

                strSQLName = "C_LIST_Daibun_SELECT_LEAVE";

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //配列設定
                string[] strArray = { lstString[0] };

                strSQLInput = string.Format(strSQLInput, strArray);

                //該当する大分類コードと名前を確保
                dtGetTableTxt = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception e)
            {
                new CommonException(e);
                throw (e);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return (dtGetTableTxt);
        }

        ///<summary>
        ///setName
        ///大分類名を記述
        ///</summary>
        public DataTable setName(List<string> lstString)
        {
            DataTable dtGetTableTxt = new DataTable();

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                strSQLName = "C_LIST_Daibun_SELECT_LEAVE";

                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //配列設定
                string[] strArray = { lstString[0] };

                strSQLInput = string.Format(strSQLInput, strArray);

                dtGetTableTxt = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception e)
            {
                new CommonException(e);
                throw (e);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return (dtGetTableTxt);
        }

        ///<summary>
        ///setSelectItem
        ///各画面へのデータ渡し
        ///</summary>
        public void setSelectItem(List<int> lstInt, List<string> lstString, string strdaibunCDsub)
        {
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                strSQLName = "C_LIST_Chubun_SELECT_LEAVE";

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //配列設定
                string[] strArray = { strdaibunCDsub, lstString[0] };

                strSQLInput = string.Format(strSQLInput, strArray);

                //SQL文を直書き（＋戻り値を受け取る)
                dtSelectData = dbconnective.ReadSql(strSQLInput);

                switch (lstInt[0])
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
                            if (frm.Name == "M1110_Chubunrui")
                            {
                                //データを連れてくるため、newをしないこと
                                M1110_Chubunrui chubunrui = (M1110_Chubunrui)frm;
                                chubunrui.setChubunrui(dtSelectData);
                                break;
                            }
                        }
                        break;
                    //棚卸入力（表示）
                    case 5:
                        break;
                    //棚卸入力（編集）
                    case 6:
                        break;
                    //棚卸入力（商品リスト）
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
                        break;
                }
            }
            catch (Exception e)
            {
                new CommonException(e);
                throw (e);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        public void setEndAction(List<int> lstInt)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //目的のフォームを探す
                if (lstInt[0] == 1 && frm.Name == "M1010_Daibunrui")
                {
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 2 && frm.Name == "M1110_Chubunrui")
                {
                    //データを連れてくるため、newをしないこと
                    M1110_Chubunrui chubunrui = (M1110_Chubunrui)frm;
                    chubunrui.setChubunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 5 && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setChubunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 6 && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setChubunListCloseEdit();
                    break;
                }

                //目的のフォームを探す
                else if (lstInt[0] == 6 && frm.Name == "TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    ShouhinList shouhinlist = (ShouhinList)frm;
                    shouhinlist.setChubunruiListClose();
                    break;
                }
                else
                {
                    return;
                }
            }
        }
    }
}

