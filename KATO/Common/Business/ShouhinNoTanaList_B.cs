using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Common.Business
{
    ///<summary>
    ///ShouhinNoTanaList_B
    ///棚番なし商品リストフォーム
    ///作成者：大河内
    ///作成日：2018/02/15
    ///更新者：大河内
    ///更新日：2018/02/15
    ///カラム論理名
    ///</summary>
    class ShouhinNoTanaList_B
    {
        string strSQLName = null;

        ///<summary>
        ///getShohinView
        ///検索データを記入
        ///</summary>
        public DataTable getShohinView(List<int> lstInt, List<string> lstString, List<Boolean> lstBoolean, Boolean blnZaikoKensaku)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //分岐WHERE分用
            string strWhere = "";

            //本登録データの場合
            if (lstBoolean[2] == true)
            {
                //大分類あり
                if (lstString[0] != "")
                {
                    strWhere = strWhere + " AND 商品.大分類コード = " + lstString[0];
                }

                //大分類と中分類共に記入されている場合
                if (lstString[0] != "" && lstString[1] != "")
                {
                    strWhere = strWhere + " AND 商品.中分類コード = " + lstString[1];
                }

                //メーカーと大分類あり
                if (lstString[2] != "")
                {
                    strWhere = strWhere + " AND 商品.メーカーコード = " + lstString[2];
                }

                //検索文字列と大分類またはメーカーがあり、部分検索の場合
                if (lstString[3] != "" && lstBoolean[1] == true)
                {
                    strWhere = strWhere + " AND REPLACE( ISNULL(商品.Ｃ１,''),' ' ,'') LIKE '%" + lstString[3] + "%'";
                }
                //検索文字列と大分類またはメーカーがあり、完全一致検索の場合
                else if (lstString[3] != "" && lstBoolean[1] == false)
                {
                    strWhere = strWhere + " AND REPLACE( ISNULL(商品.Ｃ１,''),' ' ,'') LIKE '" + lstString[3] + "'";
                }
                else
                {
                    strWhere = strWhere + "";
                }

                //副番と大分類またはメーカーがあり、部分検索の場合
                if (lstString[4] != "" && lstBoolean[1] == true)
                {
                    strWhere = strWhere + " AND REPLACE((ISNULL(商品.Ｃ２, '') + ISNULL(商品.Ｃ３, '') + ISNULL(商品.Ｃ４, '') + ISNULL(商品.Ｃ５, '') + ISNULL(商品.Ｃ６, '') ),' ' ,'') LIKE '%" + lstString[4] + "%'";
                }
                //副番と大分類またはメーカーがあり、完全一致検索の場合
                else if (lstString[4] != "" && lstBoolean[1] == false)
                {
                    strWhere = strWhere + " AND REPLACE((ISNULL(商品.Ｃ２, '') + ISNULL(商品.Ｃ３, '') + ISNULL(商品.Ｃ４, '') + ISNULL(商品.Ｃ５, '') + ISNULL(商品.Ｃ６, '') ),' ' ,'') LIKE '" + lstString[4] + "'";
                }
                else
                {
                    strWhere = strWhere + "";
                }

                //未登録棚の場合
                if (lstBoolean[0] == true)
                {
                    strWhere = strWhere + "AND  (";
                    strWhere = strWhere + " ((SELECT 棚番名 FROM 棚番 WHERE 商品.棚番本社=棚番.棚番)  IS NULL)";
                    strWhere = strWhere + " OR ((SELECT 棚番名 FROM 棚番 WHERE 商品.棚番岐阜=棚番.棚番)  IS NULL)";
                    strWhere = strWhere + " )";
                }

                //SQLファイルのパスとファイル名を追加
                lstSQL.Add("Common");
                lstSQL.Add("CommonForm");
                lstSQL.Add("ShohinNoTanaList_View");
            }
            //仮登録データの場合
            else
            {
                //大分類あり
                if (lstString[0] != "")
                {
                    strWhere = strWhere + " AND 仮商品.大分類コード = " + lstString[0];
                }

                //大分類と中分類共に記入されている場合
                if (lstString[0] != "" && lstString[1] != "")
                {
                    strWhere = strWhere + " AND 仮商品.中分類コード = " + lstString[1];
                }

                //メーカーと大分類あり
                if (lstString[2] != "")
                {
                    strWhere = strWhere + " AND 仮商品.メーカーコード = " + lstString[2];
                }

                //検索文字列と大分類またはメーカーがあり、部分検索の場合
                if (lstString[3] != "" && lstBoolean[1] == true)
                {
                    strWhere = strWhere + " AND REPLACE( ISNULL(仮商品.Ｃ１,''),' ' ,'') LIKE '%" + lstString[3] + "%'";
                }
                //検索文字列と大分類またはメーカーがあり、完全一致検索の場合
                else if (lstString[3] != "" && lstBoolean[1] == false)
                {
                    strWhere = strWhere + " AND REPLACE( ISNULL(仮商品.Ｃ１,''),' ' ,'') LIKE '" + lstString[3] + "'";
                }
                else
                {
                    strWhere = strWhere + "";
                }

                //副番と大分類またはメーカーがあり、部分検索の場合
                if (lstString[4] != "" && lstBoolean[1] == true)
                {
                    strWhere = strWhere + " AND REPLACE((ISNULL(仮商品.Ｃ２, '') + ISNULL(仮商品.Ｃ３, '') + ISNULL(仮商品.Ｃ４, '') + ISNULL(仮商品.Ｃ５, '') + ISNULL(仮商品.Ｃ６, '') ),' ' ,'') LIKE '%" + lstString[4] + "%'";
                }
                //副番と大分類またはメーカーがあり、完全一致検索の場合
                else if (lstString[4] != "" && lstBoolean[1] == false)
                {
                    strWhere = strWhere + " AND REPLACE((ISNULL(仮商品.Ｃ２, '') + ISNULL(仮商品.Ｃ３, '') + ISNULL(仮商品.Ｃ４, '') + ISNULL(仮商品.Ｃ５, '') + ISNULL(仮商品.Ｃ６, '') ),' ' ,'') LIKE '" + lstString[4] + "'";
                }
                else
                {
                    strWhere = strWhere + "";
                }

                //未登録棚の場合
                if (lstBoolean[0] == true)
                {
                    strWhere = strWhere + "AND  (";
                    strWhere = strWhere + " ((SELECT 棚番名 FROM 棚番 WHERE 仮商品.棚番本社=棚番.棚番)  IS NULL)";
                    strWhere = strWhere + " OR ((SELECT 棚番名 FROM 棚番 WHERE 仮商品.棚番岐阜=棚番.棚番)  IS NULL)";
                    strWhere = strWhere + " )";
                }

                strWhere += " ORDER BY 見積, 仮商品.商品コード, 仮商品.登録日時";

                //SQLファイルのパスとファイル名を追加
                lstSQL.Add("Common");
                lstSQL.Add("CommonForm");
                lstSQL.Add("ShohinNoTanaList_Kari_View");
            }

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();

            //商品テーブルから取り出すデータ
            DataTable dtShohin = new DataTable();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtShohin);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strWhere, lstString[4]);

                //SQL発行
                dtShohin = dbConnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            return (dtShohin);
        }

        ///<summary>
        ///getLabel
        ///textboxのデータをlabelに記入
        ///</summary>
        public DataTable getLabel(List<string> lstString, List<int> lstint)
        {
            //SQL出力後のデータテーブル
            DataTable dtSetData = null;

            //テキストボックスのデータを確保
            string strTextCase = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();
            OpenSQL opensql = new OpenSQL();

            //どこのDBを参照するか
            switch (lstint[0])
            {
                case CommonTeisu.FRM_DAIBUNRUI://大分類

                    if (lstString[0] == "")
                    {
                        lstString[0] = "";
                        return (dtSetData);
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
                    string[] aryStr = { lstString[0] };

                    strSQLInput = string.Format(strSQLInput, aryStr);

                    //SQLのインスタンス作成
                    DBConnective dbconnective = new DBConnective();

                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSetData = dbconnective.ReadSql(strSQLInput);
                    break;
                case CommonTeisu.FRM_CHUBUNRUI://中分類
                    if (lstString[1] == "")
                    {
                        lstString[1] = "";
                        return (dtSetData);
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
                case CommonTeisu.FRM_MAKER://メーカー
                    if (lstString[2] == "")
                    {
                        lstString[2] = "";
                        return (dtSetData);
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
                    return (dtSetData);
            }
            return (dtSetData);
        }

        ///<summary>
        ///getSelectItem
        ///商品データの取得
        ///</summary>
        public DataTable getSelectItem(string strSelectShohinCD, bool blHontorokuData)
        {
            DataTable dtShohin = new DataTable();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            //商品の処理
            lstStringSQL = new List<string>();

            lstStringSQL.Add("Common");

            //本登録データ登録の場合
            if (blHontorokuData)
            {
                lstStringSQL.Add("C_LIST_Shohin_SELECT_LEAVE");
            }
            else
            {
                lstStringSQL.Add("C_LIST_Shohin_Kari_SELECT_LEAVE");
            }

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                strSQLInput = opensql.setOpenSQL(lstStringSQL);
                strSQLInput = string.Format(strSQLInput, strSelectShohinCD); //商品コード

                dtShohin = dbconnective.ReadSql(strSQLInput);

                //加工
                //指定日在庫、棚卸数量の小数点切りすて
                for (int cnt = 0; cnt < dtShohin.Rows.Count; cnt++)
                {
                    decimal decTyoubosuu = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["標準売価"].ToString()));
                    dtShohin.Rows[cnt]["標準売価"] = decTyoubosuu.ToString();
                    decimal decTanasuu = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["仕入単価"].ToString()));
                    dtShohin.Rows[cnt]["仕入単価"] = decTanasuu.ToString();
                    decimal decHyoka = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["評価単価"].ToString()));
                    dtShohin.Rows[cnt]["評価単価"] = decHyoka.ToString();
                    decimal decTeka = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["定価"].ToString()));
                    dtShohin.Rows[cnt]["定価"] = decTeka.ToString();
                    decimal decHako = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["箱入数"].ToString()));
                    dtShohin.Rows[cnt]["箱入数"] = decHako.ToString();
                    decimal decTatene = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["建値仕入単価"].ToString()));
                    dtShohin.Rows[cnt]["建値仕入単価"] = decTatene.ToString();
                }

                return (dtShohin);
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

        ///<summary>
        ///getTanabanCnt
        ///棚番がある場合にカウント
        ///</summary>
        public DataTable getTanabanCnt(string strTanaban)
        {
            DataTable dtGetTanaCnt = new DataTable();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            //商品の処理
            lstStringSQL = new List<string>();

            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_ShohinList_SELECT_TanaCnt");

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                strSQLInput = opensql.setOpenSQL(lstStringSQL);
                strSQLInput = string.Format(strSQLInput, strTanaban); //棚番

                dtGetTanaCnt = dbconnective.ReadSql(strSQLInput);

                return (dtGetTanaCnt);
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
