using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.F0140_TanaorosiInput;
using KATO.Form.M1030_Shohin;
using KATO.Form.D0380_ShohinMotochoKakunin;
using KATO.Form.A0010_JuchuInput;
using KATO.Form.A0100_HachuInput;
using KATO.Form.M1210_ShohinbetsuRiekiritsuSettei;
using KATO.Form.M1160_TokuteimukesakiTanka;

namespace KATO.Common.Business
{
    ///<summary>
    ///ShouhinList_B
    ///商品リストフォーム
    ///作成者：大河内
    ///作成日：2017/3/23
    ///更新者：大河内
    ///更新日：2017/4/7
    ///カラム論理名
    ///</summary>
    class ShouhinList_B
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
                strWhere = strWhere + " AND REPLACE(( ISNULL(商品.Ｃ１,'') + ISNULL(商品.Ｃ２, '') + ISNULL(商品.Ｃ３, '') + ISNULL(商品.Ｃ４, '') + ISNULL(商品.Ｃ５, '') + ISNULL(商品.Ｃ６, '') ),' ' ,'') LIKE '%" + lstString[3] + "%'";
            }
            //検索文字列と大分類またはメーカーがあり、完全一致検索の場合
            else if (lstString[3] != "" && lstBoolean[1] == false)
            {
                strWhere = strWhere + " AND REPLACE(( ISNULL(商品.Ｃ１,'') + ISNULL(商品.Ｃ２, '') + ISNULL(商品.Ｃ３, '') + ISNULL(商品.Ｃ４, '') + ISNULL(商品.Ｃ５, '') + ISNULL(商品.Ｃ６, '') ),' ' ,'') LIKE '" + lstString[3] + "'";
            }

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("CommonForm");
            lstSQL.Add("ShohinList_View");

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
                strSQLInput = string.Format(strSQLInput, strWhere);

                //SQL発行
                dtShohin = dbConnective.ReadSql(strSQLInput);

                //データがあった場合
                if (dtShohin.Rows.Count > 0)
                {
                    //掛け率のカラム追加
                    dtShohin.Columns.Add("掛率", Type.GetType("System.String"));
                    DataRow drInsert = dtShohin.NewRow();
                    drInsert["掛率"] = "";

                    for (int intShohinCnt = 0; intShohinCnt < dtShohin.Rows.Count; intShohinCnt++)
                    {
                        //本社在庫が空でない時
                        if (dtShohin.Rows[intShohinCnt]["本社在庫"].ToString() != "")
                        {
                            //本社在庫が0の時
                            if (decimal.Parse(dtShohin.Rows[intShohinCnt]["本社在庫"].ToString()) == 0)
                            {
                                dtShohin.Rows[intShohinCnt]["本社在庫"] = DBNull.Value;
                            }
                        }

                        //本社ﾌﾘｰが空でない時
                        if (dtShohin.Rows[intShohinCnt]["本社ﾌﾘｰ"].ToString() != "")
                        {
                            //本社ﾌﾘｰが0の時
                            if (decimal.Parse(dtShohin.Rows[intShohinCnt]["本社ﾌﾘｰ"].ToString()) == 0)
                            {
                                dtShohin.Rows[intShohinCnt]["本社ﾌﾘｰ"] = DBNull.Value;
                            }
                        }

                        //岐阜在庫が空でない時
                        if (dtShohin.Rows[intShohinCnt]["岐阜在庫"].ToString() != "")
                        {
                            //岐阜在庫が0の時
                            if (decimal.Parse(dtShohin.Rows[intShohinCnt]["岐阜在庫"].ToString()) == 0)
                            {
                                dtShohin.Rows[intShohinCnt]["岐阜在庫"] = DBNull.Value;
                            }
                        }

                        //岐阜ﾌﾘｰが空でない時
                        if (dtShohin.Rows[intShohinCnt]["岐阜ﾌﾘｰ"].ToString() != "")
                        {
                            //岐阜ﾌﾘｰが0の時
                            if (decimal.Parse(dtShohin.Rows[intShohinCnt]["岐阜ﾌﾘｰ"].ToString()) == 0)
                            {
                                dtShohin.Rows[intShohinCnt]["岐阜ﾌﾘｰ"] = DBNull.Value;
                            }
                        }
                        
                        //定価を取り出す
                        string strTeika = string.Format("{0:#,0}", decimal.Parse(dtShohin.Rows[intShohinCnt]["定価"].ToString()));
                        //仕入単価を取り出す
                        string strShireTanka = string.Format("{0:#,0.00}", decimal.Parse(dtShohin.Rows[intShohinCnt]["仕入単価"].ToString()));

                        //仕入単価と定価が同じになる場合
                        if (strShireTanka == "0.00" || strTeika == "0")
                        {
                            //掛率を挿入
                            dtShohin.Rows[intShohinCnt]["掛率"] = "0";
                        }
                        else
                        {
                            //掛率を挿入
                            dtShohin.Rows[intShohinCnt]["掛率"] = ((decimal)(decimal.Parse(strShireTanka) / decimal.Parse(strTeika)) * 100).ToString("#.0");
                        }

                        //定価を挿入
                        dtShohin.Rows[intShohinCnt]["定価"] = strTeika;

                        //仕入単価を挿入
                        dtShohin.Rows[intShohinCnt]["仕入単価"] = strShireTanka;


                    }
                }
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
        ///各画面へのデータ渡し
        ///</summary>
        public DataTable getSelectItem(List<int> lstInt, List<string> lstString)
        {
            List<string> lstStringItem = new List<string>();

            List<DataTable> lstDTTana = new List<DataTable>();

            DataTable dtMaker = new DataTable();
            DataTable dtDaibun = new DataTable();
            DataTable dtChubun = new DataTable();
            DataTable dtShohin = new DataTable();

            DataTable dtShohinTanaID = new DataTable();
            DataTable dtShohinTanaIDMAX = new DataTable();
            DataTable dtShohinTanaName = new DataTable();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLNameM = null;
            string strSQLNameD = null;
            string strSQLNameC = null;
            string strSQLNameS = null;

            strSQLNameM = "C_LIST_Maker_SELECT_LEAVE_NAME";
            strSQLNameD = "C_LIST_Daibun_SELECT_LEAVE_NAME";
            strSQLNameC = "C_LIST_Chubun_SELECT_LEAVE_NAME";
            strSQLNameS = "C_LIST_Shohin_SELECT_LEAVE";

            //配列設定
            string[] aryStr = { lstString[3] };

            //Makerの処理
            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLNameM);

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                strSQLInput = string.Format(strSQLInput, aryStr);

                dtMaker = dbconnective.ReadSql(strSQLInput);

                //大分類の処理
                lstStringSQL = new List<string>();

                string[] aryStrD = { lstString[4] };

                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLNameD);

                strSQLInput = null;

                opensql = new OpenSQL();
                strSQLInput = opensql.setOpenSQL(lstStringSQL);

                strSQLInput = string.Format(strSQLInput, aryStrD);

                dtDaibun = dbconnective.ReadSql(strSQLInput);

                //中分類の処理
                lstStringSQL = new List<string>();

                string[] aryStrC = { lstString[5] };

                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLNameC);

                strSQLInput = null;

                strSQLInput = opensql.setOpenSQL(lstStringSQL);
                strSQLInput = string.Format(strSQLInput, aryStrC);

                dtChubun = dbconnective.ReadSql(strSQLInput);

                //商品の処理
                lstStringSQL = new List<string>();

                string[] aryStrS = { lstString[2] };

                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLNameS);

                strSQLInput = null;

                strSQLInput = opensql.setOpenSQL(lstStringSQL);
                strSQLInput = string.Format(strSQLInput, aryStrS);

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

                //テスト完了後復帰
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
        ///FormMove
        ///戻るボタンの処理
        ///カラム論理名
        ///</summary>
        public void FormMove(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //棚卸入力フォームを探す
                if (intFrmKind == CommonTeisu.FRM_TANAOROSHI && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setShohinClose();
                    break;
                }
                //商品フォームを探す
                else if (intFrmKind == CommonTeisu.FRM_SHOHIN && frm.Name == "M1030_Shohin")
                {
                    //データを連れてくるため、newをしないこと
                    M1030_Shohin shohin = (M1030_Shohin)frm;
                    shohin.closeShohinList();
                    break;
                }
                //商品元帳確認フォームを探す
                else if (intFrmKind == CommonTeisu.FRM_SHOHINMOTOCHOKAKUNIN && frm.Name == "D0380_ShohinMotochoKakunin")
                {
                    //データを連れてくるため、newをしないこと
                    D0380_ShohinMotochoKakunin shohinmotochokakunin = (D0380_ShohinMotochoKakunin)frm;
                    shohinmotochokakunin.setShohinClose();
                    break;
                }
                //発注入力のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_HACHUINPUT && frm.Name == "A0100_HachuInput")
                {
                    //データを連れてくるため、newをしないこと
                    A0100_HachuInput hachuinput = (A0100_HachuInput)frm;
                    hachuinput.closeShohinList();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_SHOHINBETSURIEKIRITSUSETTEI && frm.Name == "M1210_ShohinbetsuRiekiritsuSettei")
                {
                    //データを連れてくるため、newをしないこと
                    M1210_ShohinbetsuRiekiritsuSettei shohinbetsuriekiritsusettei = (M1210_ShohinbetsuRiekiritsuSettei)frm;
                    shohinbetsuriekiritsusettei.setShohinClose();
                    break;
                }
                //特定向け先単価のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_TOKUTEIMUKESAKITANKA && frm.Name == "M1160_TokuteimukesakiTanka")
                {
                    //データを連れてくるため、newをしないこと
                    M1160_TokuteimukesakiTanka tokuteimukesakitanka = (M1160_TokuteimukesakiTanka)frm;
                    tokuteimukesakitanka.setShohinClose();
                    break;
                }
            }
        }

        ///<summary>
        ///FormMove
        ///仕入単価取得用(仕入入力画面で使用)
        ///カラム論理名
        ///</summary>
        public DataTable getShireTanka(string strShohinCd)
        {
            DataTable dtShireTanka = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQLSelect = new List<string>();

            //SQLファイルのパスとファイル名を追加(メニュー権限取得)
            lstSQLSelect.Add("M1030_Shohin");
            lstSQLSelect.Add("Shohin_SELECT_ShireTanka");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得(メニュー権限取得)
                string strSQLSelect = opensql.setOpenSQL(lstSQLSelect);

                //パスがなければ返す
                if (strSQLSelect == "")
                {
                    return(dtShireTanka);
                }

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLSelect);

                return(dtShireTanka);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }
    }
}
