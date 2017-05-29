﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.M1130_Shohizeiritsu;

namespace KATO.Common.Business
{
    ///<summary>
    ///ShohizeiritsuList_B
    ///データグリッドビュー表示
    ///作成者：大河内
    ///作成日：2017/3/23
    ///更新者：大河内
    ///更新日：2017/3/23
    ///カラム論理名
    ///</summary>
    class ShohizeiritsuList_B
    {
        string strSQLName = null;

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable setDatagridView(Boolean blnAll)
        {
            DataTable dtGetTableGrid = new DataTable();

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                strSQLName = "";

                //削除されているもの以外
                if (blnAll == false)
                {
                    strSQLName = "ShohizeiritsuList_View";
                }
                //全て
                else{
                    strSQLName = "ShohizeiritsuListAll_View";
                }


                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add("CommonForm");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                strSQLInput = string.Format(strSQLInput);

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
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        public void setEndAction(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //目的のフォームを探す
                if (intFrmKind == CommonTeisu.FRM_SHOHIZEIRITSU && frm.Name.Equals("M1130_Shohizeiritsu"))
                {
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
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                strSQLName = "C_LIST_Shohizeiritsu_SELECT_LEAVE";

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //配列設定
                string[] aryStr = { lstString[0] };

                strSQLInput = string.Format(strSQLInput, aryStr);

                dtSelectData = dbconnective.ReadSql(strSQLInput);
                
                DateTime dateSelect;

                string strSelect;                

                strSelect = dtSelectData.Rows[0]["適用開始年月日"].ToString();

                dateSelect = DateTime.Parse(strSelect);

                string strSelectMonth = "";

                //月データ
                strSelectMonth = strSelectMonth = dateSelect.Month.ToString();

                if (strSelectMonth.Length == 1)
                {
                    strSelectMonth = dateSelect.Month.ToString().PadLeft(2, '0');
                }

                string strSelectDay = "";

                //日付データ
                strSelectDay = dateSelect.Day.ToString();

                if (strSelectDay.Length == 1)
                {
                    strSelectDay = dateSelect.Day.ToString().PadLeft(2, '0');
                }

                dtSelectData.Rows[0]["適用開始年月日"] = (dateSelect.Year + "/" + strSelectMonth + "/" + strSelectDay).ToString();

                dtSelectData.Rows[0]["消費税率"] = StringUtl.updShishagonyu(dtSelectData.Rows[0]["消費税率"].ToString(), 1);

                //通常テキストボックスの場合に使用する
                switch (intFrmKind)
                {
                    case CommonTeisu.FRM_SHOHIZEIRITSU:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name.Equals("M1130_Shohizeiritsu"))
                            {
                                //データを連れてくるため、newをしないこと
                                M1130_Shohizeiritsu shohizeiritsu = (M1130_Shohizeiritsu)frm;
                                shohizeiritsu.setShohizeiritsu(dtSelectData);
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
    }
}
