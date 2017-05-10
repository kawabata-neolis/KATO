using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.F0140_TanaorosiInput;

namespace KATO.Common.Business
{
    class ShouhinList_B
    {
        string strSQLName = null;

        ///<summary>
        ///setKensaku
        ///検索データを記入
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public DataTable setShohinView(List<int> lstInt, List<string> lstString, List<Boolean> lstBoolean)
        {
            string strWhere = "";

            strWhere = "WHERE 削除 = 'N'";

            if (lstString[0] != "")
            {
                strWhere = strWhere + " AND 大分類コード='" + lstString[0] + "'";
            }
            if (lstString[1] != "")
            {
                strWhere = strWhere + " AND 中分類コード='" + lstString[1] + "'";
            }
            if (lstString[2] != "")
            {
                strWhere = strWhere + " AND メーカーコード='" + lstString[2] + "'";
            }
            if (lstString[3] != "")
            {
                strWhere = strWhere + " AND REPLACE(( ISNULL(Ｃ１,'') + ISNULL(Ｃ２,'') + ISNULL(Ｃ３,'') + ISNULL(Ｃ４,'') + ISNULL(Ｃ５,'') + ISNULL(Ｃ６,'') ),' ' ,'') LIKE '%" + lstString[3] + "%'";
            }
            if (lstBoolean[0] == true)
            {
                strWhere = strWhere + "  AND (";
                strWhere = strWhere + " ((SELECT 棚番名 FROM 棚番 WHERE 商品.棚番本社=棚番.棚番)  IS NULL)";
                strWhere = strWhere + " OR ((SELECT 棚番名 FROM 棚番 WHERE 商品.棚番岐阜=棚番.棚番)  IS NULL)";
                strWhere = strWhere + " )";
            }

            //他画面からなので現在編集停止
            if (lstInt[0] == 9)
            {
                ////SQLのインスタンス作成
                //DBConnective dbconnective = new DBConnective();

                //gridTorihiki.DataSource = dbconnective.ReadSql("商品コード,dbo.f_getメーカー名(メーカーコード),dbo.f_get大分類名(大分類コード),dbo.f_get中分類名(大分類コード,中分類コード), ISNULL(Ｃ１,'')+' ' +ISNULL(Ｃ２,'')+' ' +ISNULL(Ｃ３,'')+' ' +ISNULL(Ｃ４,'')+' ' +ISNULL(Ｃ５,'')+' ' +ISNULL(Ｃ６,'')," + "メモ, 棚番本社,棚番岐阜", "商品", strWhere, " ORDER BY 大分類コード,中分類コード,メーカーコード,Ｃ１,Ｃ２,Ｃ３,Ｃ４,Ｃ５,Ｃ６ ");


                //LblRecords.Text = "該当件数（ " + grdTorihiki.rowCount + "件)";
                //if (grdTorihiki.rowCount > 0)
                //{
                //    grdTorihiki.Focus();
                //}

                //for (i = 1; i <= grdTorihiki.rowCount; i++)
                //{
                //    System.Drawing.ColorTranslator.ToOle(grdTorihiki.cellBackColor)(7, i) = System.Drawing.Color.White;

                //    //UPGRADE_WARNING: UserControl メソッド grdTorihiki.cellData には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
                //    //UPGRADE_WARNING: オブジェクト grdTorihiki.cellData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //    strSQL = "SELECT COUNT(*) FROM 棚番 WHERE 削除='N' AND 棚番='" + grdTorihiki.cellData(7, i) + "'";
                //    rs = new ADODB.Recordset();
                //    rs = gCon.Execute(strSQL, , ADODB.CommandTypeEnum.adCmdText);
                //    if (rs.Fields(0).Value == 0)
                //    {
                //        System.Drawing.ColorTranslator.ToOle(grdTorihiki.cellBackColor)(7, i) = System.Drawing.Color.Red;
                //    }

                //    System.Drawing.ColorTranslator.ToOle(grdTorihiki.cellBackColor)(8, i) = System.Drawing.Color.White;

                //    //UPGRADE_WARNING: UserControl メソッド grdTorihiki.cellData には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
                //    //UPGRADE_WARNING: オブジェクト grdTorihiki.cellData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //    strSQL = "SELECT COUNT(*) FROM 棚番 WHERE 削除='N' AND 棚番='" + grdTorihiki.cellData(8, i) + "'";
                //    rs = new ADODB.Recordset();
                //    rs = gCon.Execute(strSQL, , ADODB.CommandTypeEnum.adCmdText);
                //    if (rs.Fields(0).Value == 0)
                //    {
                //        System.Drawing.ColorTranslator.ToOle(grdTorihiki.cellBackColor)(8, i) = System.Drawing.Color.Red;
                //    }

                //}
                //return;
            }


            if (lstString[4] == "" && lstString[5] == "")
            {
                lstInt[1] = 0;
            }
            else if (lstString[5] == "")
            {
                lstInt[1] = 1;
            }
            else if (lstString[4] == "")
            {
                lstInt[1] = 2;
            }
            else
            {
                lstInt[1] = 3;
            }

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();

            DataTable dtView = new DataTable();

            switch (lstInt[1])
            {
                case 0:
                    dtView = dbconnective.ReadSql("SELECT 商品コード コード,dbo.f_getメーカー名(メーカーコード) メーカー,dbo.f_get大分類名(大分類コード) 大分類名,dbo.f_get中分類名(大分類コード,中分類コード) 中分類名, ISNULL(Ｃ１,'')+' ' +ISNULL(Ｃ２,'')+' ' +ISNULL(Ｃ３,'')+' ' +ISNULL(Ｃ４,'')+' ' +ISNULL(Ｃ５,'')+' ' +ISNULL(Ｃ６,'') 品名,メモ メモ FROM 商品 " + strWhere + " ORDER BY 大分類コード,中分類コード,メーカーコード,Ｃ１,Ｃ２,Ｃ３,Ｃ４,Ｃ５,Ｃ６ ");
                    break;
                case 1:
                    dtView = dbconnective.ReadSql("SELECT 商品コード コード,dbo.f_getメーカー名(メーカーコード) メーカー,dbo.f_get大分類名(大分類コード) 大分類名,dbo.f_get中分類名(大分類コード,中分類コード) 中分類名, ISNULL(Ｃ１,'')+' ' +ISNULL(Ｃ２,'')+' ' +ISNULL(Ｃ３,'')+' ' +ISNULL(Ｃ４,'')+' ' +ISNULL(Ｃ５,'')+' ' +ISNULL(Ｃ６,'') 品名,メモ メモ, dbo.f_get指定日のフリー在庫数Ｂ('0001', 商品コード, '2050/12/31') FROM 商品 " + strWhere + " ORDER BY 大分類コード,中分類コード,メーカーコード,Ｃ１,Ｃ２,Ｃ３,Ｃ４,Ｃ５,Ｃ６ ");
                    break;
                case 2:
                    dtView = dbconnective.ReadSql("SELECT 商品コード コード,dbo.f_getメーカー名(メーカーコード) メーカー,dbo.f_get大分類名(大分類コード) 大分類名,dbo.f_get中分類名(大分類コード,中分類コード) 中分類名, ISNULL(Ｃ１,'')+' ' +ISNULL(Ｃ２,'')+' ' +ISNULL(Ｃ３,'')+' ' +ISNULL(Ｃ４,'')+' ' +ISNULL(Ｃ５,'')+' ' +ISNULL(Ｃ６,'') 品名,メモ メモ, dbo.f_get指定日のフリー在庫数Ｂ('0002',商品コード,'2050/12/31') FROM 商品 " + strWhere + " ORDER BY 大分類コード,中分類コード,メーカーコード,Ｃ１,Ｃ２,Ｃ３,Ｃ４,Ｃ５,Ｃ６ ");
                    break;
                case 3:
                    dtView = dbconnective.ReadSql("SELECT 商品コード コード,dbo.f_getメーカー名(メーカーコード) メーカー,dbo.f_get大分類名(大分類コード) 大分類名,dbo.f_get中分類名(大分類コード,中分類コード) 中分類名, ISNULL(Ｃ１,'')+' ' +ISNULL(Ｃ２,'')+' ' +ISNULL(Ｃ３,'')+' ' +ISNULL(Ｃ４,'')+' ' +ISNULL(Ｃ５,'')+' ' +ISNULL(Ｃ６,'') 品名,メモ メモ, dbo.f_get指定日のフリー在庫数Ｂ('0002',商品コード,'2050/12/31'), dbo.f_get指定日のフリー在庫数Ｂ('0002',商品コード,'2050/12/31') FROM 商品 " + strWhere + " ORDER BY 大分類コード,中分類コード,メーカーコード,Ｃ１,Ｃ２,Ｃ３,Ｃ４,Ｃ５,Ｃ６ ");
                    break;
            }

            if (lstInt[1] == 9)
            {
                dtView.Columns.Add("棚番本社", typeof(int));
                dtView.Columns.Add("棚番岐阜", typeof(int));
            }
            else
            {
                dtView.Columns.Add("本社在庫", typeof(int));
                dtView.Columns.Add("岐阜在庫", typeof(int));
            }
            return (dtView);
        }

        ///<summary>
        ///setLabel
        ///textboxのデータをlabelに記入
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public DataTable setLabel(List<string> lstString, List<int> lstint)
        {
            //SQL出力後のデータテーブル
            DataTable dtSetData = null;

            //テキストボックスのデータを確保
            string strTextCase = "";

            //SQL文の確保
            string strSQL = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();
            OpenSQL opensql = new OpenSQL();

            //どこのDBを参照するか
            switch (lstint[0])
            {
                case 1://大分類

                    if (lstString[0] == "")
                    {
                        lstString[0] = "";
                        return(dtSetData);
                    }
                    else if (lstString[0].Length == 1)
                    {
                        lstString[0] = lstString[0].ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        strTextCase = lstString[0];
                    }

                    strSQLName = "C_LIST_Daibun_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add("Common");
                    lstStringSQL.Add(strSQLName);

                    string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    string[] aryStr = { lstString[0]};

                    strSQLInput = string.Format(strSQLInput, aryStr);

                    //SQLのインスタンス作成
                    DBConnective dbconnective = new DBConnective();

                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSetData = dbconnective.ReadSql(strSQLInput);
                    break;
                case 2://中分類
                    if (lstString[1] == "")
                    {
                        lstString[1] = "";
                        return(dtSetData);
                    }
                    else if (lstString[1].Length == 1)
                    {
                        strTextCase = lstString[1].ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        strTextCase = lstString[1];
                    }

                    strSQLName = "C_LIST_Chubun_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add("Common");
                    lstStringSQL.Add(strSQLName);

                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    aryStr = new string[] { lstString[0], strTextCase };

                    strSQLInput = string.Format(strSQLInput, aryStr);

                    //SQLのインスタンス作成
                    dbconnective = new DBConnective();

                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSetData = dbconnective.ReadSql(strSQLInput);
                    break;
                case 3://メーカー
                    if (lstString[2] == "")
                    {
                        lstString[2] = "";
                        return(dtSetData);
                    }
                    else if (lstString[2].Length <= 2)
                    {
                        strTextCase = lstString[2].ToString().PadLeft(3, '0');
                    }
                    else
                    {
                        strTextCase = lstString[2];
                    }

                    strSQLName = "M1020_Maker_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add("Common");
                    lstStringSQL.Add(strSQLName);

                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    aryStr = new string[] { strTextCase };

                    strSQLInput = string.Format(strSQLInput, aryStr);

                    //SQLのインスタンス作成
                    dbconnective = new DBConnective();

                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSetData = dbconnective.ReadSql(strSQLInput);
                    break;
                default:
                    return(dtSetData);
            }
            return (dtSetData);
        }

        ///<summary>
        ///setSelectItem
        ///各画面へのデータ渡し
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/4/12
        ///カラム論理名
        ///</summary>
        public void setSelectItem(List<int> lstInt, List<string> lstString)
        {
            List<string> lstStringTana = new List<string>();
            List<DataTable> lstDTTana = new List<DataTable>();

            DataTable dtMaker = new DataTable();
            DataTable dtDaibun = new DataTable();
            DataTable dtChubun = new DataTable();

            DataTable dtShohinTanaID = new DataTable();
            DataTable dtShohinTanaIDMAX = new DataTable();
            DataTable dtShohinTanaName = new DataTable();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLNameM = null;
            string strSQLNameD = null;
            string strSQLNameC = null;

            strSQLNameM = "C_LIST_Maker_SELECT_LEAVE";
            strSQLNameD = "C_LIST_Daibun_SELECT_LEAVE";
            strSQLNameC = "C_LIST_Chubun_SELECT_LEAVE";

            //配列設定
            string[] aryStr = { lstString[3] };

            //Makerの処理
            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLNameM);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            strSQLInput = string.Format(strSQLInput, aryStr);

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            dtMaker = dbconnective.ReadSql(strSQLInput);

            //大分類の処理
            lstStringSQL = new List<string>();

            string[] aryStrD = { lstString[4] };

            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLNameD);

            strSQLInput = null;

            strSQLInput = opensql.setOpenSQL(lstStringSQL);
            strSQLInput = string.Format(strSQLInput, aryStrD);

            dtDaibun = dbconnective.ReadSql(strSQLInput);


            ////中分類の処理
            //lstStringSQL = new List<string>();

//大分類名で調べるSQLが必要
            string[] aryStrC = { dtDaibun.Rows[0]["大分類コード"].ToString(), lstString[5] };

            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLNameC);

            strSQLInput = null;

            strSQLInput = opensql.setOpenSQL(lstStringSQL);
            strSQLInput = string.Format(strSQLInput, aryStrC);

            dtChubun = dbconnective.ReadSql(strSQLInput);

//テストから
            dtShohinTanaID = dbconnective.ReadSql("SELECT 棚番, 棚卸年月日, 指定日在庫, 棚卸数量 FROM 棚卸記入表 WHERE 商品コード = '" + lstString[2] + "'AND 営業所コード = '" + lstString[1] + "'ORDER BY 棚卸年月日 DESC");

            dtShohinTanaName = dbconnective.ReadSql("SELECT 棚番名 FROM 棚番 WHERE 棚番 = '" + dtShohinTanaID.Rows[0]["棚番"].ToString() + "'");

            //指定日在庫、棚卸数量の小数点切り下げ
            for (int cnt = 0; cnt < dtShohinTanaID.Rows.Count; cnt++)
            {
                decimal decTyoubosuu = Math.Floor(decimal.Parse(dtShohinTanaID.Rows[cnt]["棚卸数量"].ToString()));
                dtShohinTanaID.Rows[cnt]["棚卸数量"] = decTyoubosuu.ToString();
                decimal decTanasuu = Math.Floor(decimal.Parse(dtShohinTanaID.Rows[cnt]["指定日在庫"].ToString()));
                dtShohinTanaID.Rows[cnt]["指定日在庫"] = decTanasuu.ToString();
            }

            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //目的のフォームを探す
                if (frm.Name == "F0140_TanaorosiInput")
                {
                    //データ渡し用
                    lstStringTana.Add(lstString[2]);
                    lstStringTana.Add(lstString[6]);

                    lstDTTana.Add(dtDaibun);
                    lstDTTana.Add(dtChubun);
                    lstDTTana.Add(dtMaker);
                    lstDTTana.Add(dtShohinTanaID);
                    lstDTTana.Add(dtShohinTanaName);

                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setShouhin(lstStringTana, lstDTTana);
                    break;
                }
            }
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/4/11
        ///カラム論理名
        ///</summary>
        public void setEndAction(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //目的のフォームを探す
                if (intFrmKind == 1 && frm.Name.Equals("M1010_Daibunrui"))
                {
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 2 && frm.Name.Equals("M1110_Chubunrui"))
                {
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == 5 && frm.Name == "F0140_TanaorosiInput")
                {
                    ////データを連れてくるため、newをしないこと
                    //TanaorosiInput tanaorosiinput = (TanaorosiInput)frm;
                    //tanaorosiinput.setShohinListClose();
                    //break;
                }
            }
        }

        ///<summary>
        ///ZaikoClick
        ///在庫ボタン処理
        ///作成者：大河内
        ///作成日：2017/4/7
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public void ZaikoClick(List<string> lstString)
        {

        }


        }
    }
