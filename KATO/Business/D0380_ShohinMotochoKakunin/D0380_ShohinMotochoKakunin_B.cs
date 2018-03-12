using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.D0380_ShohinMotochoKakunin;

namespace KATO.Business.D0380_ShohinMotochoKakunin
{
    ///<summary>
    ///D0380_ShohinMotochoKakunin_B
    ///商品元帳確認フォーム
    ///作成者：大河内
    ///作成日：2017/3/23
    ///更新者：大河内
    ///更新日：2017/4/7
    ///カラム論理名
    ///</summary>
    class D0380_ShohinMotochoKakunin_B
    {
        ///<summary>
        ///setTextBox
        ///検索データを記入
        ///</summary>
        public List<string> setTextBox(List<string> lstString)
        {
            List<string> lstStringSet = new List<string>();

            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;
            System.DateTime dateZenYMD;

            string strSQL;

            decimal decWSu1;
            decimal decWSu2;
            decimal decWSu3;
            decimal decWSu1_2;
            decimal decWSu2_2;
            decimal decWSu3_2;

            decimal decNyukoSu1;
            decimal decNyukoSu2;
            decimal decNyukoSu1_2;
            decimal decNyukoSu2_2;
            decimal decNyukoSu3;
            decimal decNyukoSu3_2;
            decimal decNyukoSu4;
            decimal decNyukoSu4_2;

            decimal decZaiko1;
            decimal decZaiko2;

            DataTable dtView;

            string strEigyosyo1;
            string strEigyosyo2;

            int intData = 0;

            strEigyosyo1 = "0001";
            strEigyosyo2 = "0002";

            dateStartYMD = DateTime.Parse(lstString[2] + "/01");

            dateEndYMD = DateTime.Parse(lstString[3] + "/01");

            dateEndYMD = dateEndYMD.AddMonths(1);
            dateEndYMD = dateEndYMD.AddDays(-1);

            dateZenYMD = dateStartYMD.AddDays(-1);


            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {

                //本社　前月在庫
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定日の在庫数( '" + strEigyosyo1 + "','" + lstString[0] + "','" + dateZenYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }

                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));
                if (intData != 0)
                {
                    lstStringSet.Add(intData.ToString());
                }
                else
                {
                    lstStringSet.Add("0");
                }

                //岐阜　前月在庫
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定日の在庫数( '" + strEigyosyo2 + "','" + lstString[0] + "','" + dateZenYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }

                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));
                if (intData != 0)
                {
                    lstStringSet.Add(intData.ToString());
                }
                else
                {
                    lstStringSet.Add("0");
                }

                //本社　入庫 1
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_仕入数量_仕入明細( '" + strEigyosyo1 + "','" + lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }

                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));
                if (intData != 0)
                {
                    decNyukoSu1 = intData;
                }
                else
                {
                    decNyukoSu1 = 0;
                }

                //岐阜　入庫 1
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_仕入数量_仕入明細( '" + strEigyosyo2 + "','" + lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }

                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));
                if (intData != 0)
                {
                    decNyukoSu1_2 = intData;
                }
                else
                {
                    decNyukoSu1_2 = 0;
                }

                //本社　入庫 2
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_移動入数_倉庫間移動( '" + strEigyosyo1 + "','" + lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }

                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));
                if (intData != 0)
                {
                    decNyukoSu2 = intData;
                }
                else
                {
                    decNyukoSu2 = 0;
                }

                //岐阜　入庫 2
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_移動入数_倉庫間移動( '" + strEigyosyo2 + "','" + lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decNyukoSu2_2 = intData;
                }
                else
                {
                    decNyukoSu2_2 = 0;
                }

                //本社　入庫 3
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_棚卸調整数_棚卸調整( '" + strEigyosyo1 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decNyukoSu3 = intData;
                }
                else
                {
                    decNyukoSu3 = 0;
                }

                //岐阜　入庫 3
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_棚卸調整数_棚卸調整( '" + strEigyosyo2 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decNyukoSu3_2 = intData;
                }
                else
                {
                    decNyukoSu3_2 = 0;
                }

                //本社　入庫 4
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_入庫数量_出庫明細( '" + strEigyosyo1 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decNyukoSu4 = intData;
                }
                else
                {
                    decNyukoSu4 = 0;
                }

                //岐阜　入庫 4
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_入庫数量_出庫明細( '" + strEigyosyo2 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decNyukoSu4_2 = intData;
                }
                else
                {
                    decNyukoSu4_2 = 0;
                }

                //本社　出庫 1
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_売上数量_売上明細( '" + strEigyosyo1 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu1 = intData;
                }
                else
                {
                    decWSu1 = 0;
                }

                //岐阜　出庫 2
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_売上数量_売上明細( '" + strEigyosyo2 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu1_2 = intData;
                }
                else
                {
                    decWSu1_2 = 0;
                }

                //本社　出庫 2
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_出庫数量_出庫明細( '" + strEigyosyo1 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu2 = intData;
                }
                else
                {
                    decWSu2 = 0;
                }

                //岐阜　出庫 2
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_出庫数量_出庫明細( '" + strEigyosyo2 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu2_2 = intData;
                }
                else
                {
                    decWSu2_2 = 0;
                }

                //本社　出庫 3
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_移動出数_倉庫間移動( '" + strEigyosyo1 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu3 = intData;
                }
                else
                {
                    decWSu3 = 0;
                }

                //岐阜　出庫 3
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_移動出数_倉庫間移動( '" + strEigyosyo2 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu3_2 = intData;
                }
                else
                {
                    decWSu3_2 = 0;
                }

//今後ロジックとDBが変わる
//以下は試しに作ったもの
                ////本社　最新在庫
                //strSQL = "";
                //dtView = dbconnective.ReadSql("SELECT dbo.f_get最新在庫数_在庫( '" + strEigyosyo1 + "','" + lstString[0] + "','" + DateTime.Today + "')");
                //if (dtView.Rows.Count < 0)
                //{
                //    return (lstStringSet);
                //}
                //intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                //if (intData != 0)
                //{
                //    decZaiko1 = intData;
                //}
                //else
                //{
                //    decZaiko1 = 0;
                //}


                ////本社　最新在庫
                //strSQL = "";
                //dtView = dbconnective.ReadSql("SELECT dbo.f_get最新在庫数_在庫( '" + strEigyosyo2 + "','" + lstString[0] + "','" + DateTime.Today + "')");
                //if (dtView.Rows.Count < 0)
                //{
                //    return (lstStringSet);
                //}
                //intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                //if (intData != 0)
                //{
                //    decZaiko2 = intData;
                //}
                //else
                //{
                //    decZaiko2 = 0;
                //}
//以上は試しに作ったもの
                
                //計算枠
                lstStringSet.Add((decNyukoSu1 + decNyukoSu2 + decNyukoSu3 + decNyukoSu4).ToString());
                lstStringSet.Add((decNyukoSu1_2 + decNyukoSu2_2 + decNyukoSu3_2 + decNyukoSu4_2).ToString());
                lstStringSet.Add((decWSu1 + decWSu2 + decWSu3).ToString());
                lstStringSet.Add((decWSu1_2 + decWSu2_2 + decWSu3_2).ToString());
                lstStringSet.Add((Decimal.Parse(lstStringSet[0]) + Decimal.Parse(lstStringSet[2]) - Decimal.Parse(lstStringSet[4])).ToString());
                lstStringSet.Add((Decimal.Parse(lstStringSet[1]) + Decimal.Parse(lstStringSet[3]) - Decimal.Parse(lstStringSet[5])).ToString());

                //lstStringSet.Add(decZaiko1.ToString());
                //lstStringSet.Add(decZaiko2.ToString());

                return (lstStringSet);
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
        ///setTxtBox
        ///検索データを記入
        ///</summary>
        public DataTable setViewGrid(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;

            dateStartYMD = DateTime.Parse(lstString[2] + "/01");

            dateEndYMD = DateTime.Parse(lstString[3] + "/01");

            dateEndYMD = dateEndYMD.AddMonths(1);
            dateEndYMD = dateEndYMD.AddDays(-1);
            
            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                string strSQLName = "";

                if (lstString[1] == "0001" || lstString[1] == "0002")
                {
                    strSQLName = "C_LIST_ShohinMotochoKakunin_SELECT_VIEW_EigyoTrue";
                }
                else
                {
                    strSQLName = "C_LIST_ShohinMotochoKakunin_SELECT_VIEW_EigyoFalse";
                }

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //配列設定
                string[] aryStr = { lstString[0], lstString[1], dateStartYMD.ToString(), dateEndYMD.ToString() };

                strSQLInput = string.Format(strSQLInput, aryStr);

                //検索データをデータテーブルに入れる
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);

                for (int intCnt = 0; intCnt < dtGetTableGrid.Rows.Count; intCnt++)
                {
                    if (StringUtl.blIsEmpty(dtGetTableGrid.Rows[intCnt]["在庫数"].ToString()) == false)
                    {
                        dtGetTableGrid.Rows[intCnt]["在庫数"] = 0;
                    }
                    if (StringUtl.blIsEmpty(dtGetTableGrid.Rows[intCnt]["入庫数"].ToString()) == false)
                    {
                        dtGetTableGrid.Rows[intCnt]["入庫数"] = 0;
                    }
                    if (StringUtl.blIsEmpty(dtGetTableGrid.Rows[intCnt]["出庫数"].ToString()) == false)
                    {
                        dtGetTableGrid.Rows[intCnt]["出庫数"] = 0;
                    }
                    if (StringUtl.blIsEmpty(dtGetTableGrid.Rows[intCnt]["単価"].ToString()) == false)
                    {
                        dtGetTableGrid.Rows[intCnt]["単価"] = 0;
                    }

                    if (intCnt == 0)
                    {
                        if (lstString[1] == "0001")
                        {
                            //本社前月在庫数が0の場合
                            if (lstString[4].ToString().Trim() == "")
                            {
                                lstString[4] = "0";
                            }

                            dtGetTableGrid.Rows[intCnt]["在庫数"] = double.Parse(lstString[4]) + double.Parse(dtGetTableGrid.Rows[intCnt]["入庫数"].ToString()) - double.Parse(dtGetTableGrid.Rows[intCnt]["出庫数"].ToString());

                        }
                        else
                        {
                            //岐阜前月在庫数が0の場合
                            if (lstString[5].ToString().Trim() == "")
                            {
                                lstString[5] = "0";
                            }

                            dtGetTableGrid.Rows[intCnt]["在庫数"] = double.Parse(lstString[5]) + double.Parse(dtGetTableGrid.Rows[intCnt]["入庫数"].ToString()) - double.Parse(dtGetTableGrid.Rows[intCnt]["出庫数"].ToString());
                        }
                    }
                    else
                    {
                        //一行前の在庫数がNULLの場合
                        if (dtGetTableGrid.Rows[intCnt - 1]["在庫数"].ToString().Trim() == "")
                        {
                            dtGetTableGrid.Rows[intCnt - 1]["在庫数"] = "0";

                            dtGetTableGrid.Rows[intCnt]["在庫数"] = double.Parse(dtGetTableGrid.Rows[intCnt - 1]["在庫数"].ToString()) + double.Parse(dtGetTableGrid.Rows[intCnt]["入庫数"].ToString()) - double.Parse(dtGetTableGrid.Rows[intCnt]["出庫数"].ToString());

                            dtGetTableGrid.Rows[intCnt - 1]["在庫数"] = DBNull.Value;
                        }
                        else
                        {
                            dtGetTableGrid.Rows[intCnt]["在庫数"] = double.Parse(dtGetTableGrid.Rows[intCnt - 1]["在庫数"].ToString()) + double.Parse(dtGetTableGrid.Rows[intCnt]["入庫数"].ToString()) - double.Parse(dtGetTableGrid.Rows[intCnt]["出庫数"].ToString());
                        }
                    }

                    //入庫数が0の場合
                    if (dtGetTableGrid.Rows[intCnt]["入庫数"].ToString() == "0")
                    {
                        dtGetTableGrid.Rows[intCnt]["入庫数"] = DBNull.Value;
                    }

                    //出庫数が0の場合
                    if (dtGetTableGrid.Rows[intCnt]["出庫数"].ToString() == "0")
                    {
                        dtGetTableGrid.Rows[intCnt]["出庫数"] = DBNull.Value;
                    }

                    //在庫数が0の場合
                    if (dtGetTableGrid.Rows[intCnt]["在庫数"].ToString() == "0")
                    {
                        dtGetTableGrid.Rows[intCnt]["在庫数"] = DBNull.Value;
                    }
                }
                return (dtGetTableGrid);
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
        ///getTantoshaCd
        ///担当者データの取得
        ///</summary>
        public DataTable getTantoshaCd(string strUserID)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtTantoshaCd = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_TantoshaCd_Select");

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtTantoshaCd);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput,
                                            strUserID   //ログインＩＤ
                                            );

                //データ取得（ここから取得）
                dtTantoshaCd = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
            return (dtTantoshaCd);
        }
    }
}
