using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;

namespace KATO.Business.D1550_ShohinZaikoKakunin
{
    ///<summary>
    ///D1550_ShohinZaikoKakunin_B
    ///商品在庫確認
    ///作成者：大河内
    ///作成日：2018/04/12
    ///更新者：大河内
    ///更新日：2018/04/12
    ///カラム論理名
    ///</summary>
    class D1550_ShohinZaikoKakunin_B
    {
        ///<summary>
        ///getShohinView
        ///検索データを記入
        ///</summary>
        public DataTable getShohinView(List<string> lstString)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //分岐WHERE分用
            string strWhere = "";

            //商品コードがある場合
            if (lstString[4] != "")
            {
                strWhere = strWhere + " AND 商品.商品コード = '" + lstString[4] + "'";
            }
            else
            {
                //大分類あり
                if (lstString[0] != "")
                {
                    strWhere = strWhere + " AND 商品.大分類コード = '" + lstString[0] + "'";
                }

                //大分類と中分類共に記入されている場合
                if (lstString[0] != "" && lstString[1] != "")
                {
                    strWhere = strWhere + " AND 商品.中分類コード = '" + lstString[1] + "'";
                }

                //メーカーと大分類あり
                if (lstString[2] != "")
                {
                    strWhere = strWhere + " AND 商品.メーカーコード = '" + lstString[2] + "'";
                }

                //検索文字列がある場合
                if (lstString[3] != "")
                {
                    strWhere = strWhere + " AND REPLACE( ISNULL(商品.Ｃ１,'') + (ISNULL(商品.Ｃ２, '') + ISNULL(商品.Ｃ３, '') + ISNULL(商品.Ｃ４, '') + ISNULL(商品.Ｃ５, '') + ISNULL(商品.Ｃ６, '') ),' ' ,'') LIKE '%" + lstString[3] + "%'";
                }
            }

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("D1550_ShohinZaikokakunin");
            lstSQL.Add("D1550_ShohinZaikokakunin_ShohinView");

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
                            else
                            {
                                dtShohin.Rows[intShohinCnt]["本社在庫"] = string.Format("{0:#,0}", decimal.Parse(dtShohin.Rows[intShohinCnt]["本社在庫"].ToString()));
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
                            else
                            {
                                dtShohin.Rows[intShohinCnt]["本社ﾌﾘｰ"] = string.Format("{0:#,0}", decimal.Parse(dtShohin.Rows[intShohinCnt]["本社ﾌﾘｰ"].ToString()));
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
                            else
                            {
                                dtShohin.Rows[intShohinCnt]["岐阜在庫"] = string.Format("{0:#,0}", decimal.Parse(dtShohin.Rows[intShohinCnt]["岐阜在庫"].ToString()));
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
                            else
                            {
                                dtShohin.Rows[intShohinCnt]["岐阜ﾌﾘｰ"] = string.Format("{0:#,0}", decimal.Parse(dtShohin.Rows[intShohinCnt]["岐阜ﾌﾘｰ"].ToString()));
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
        ///getSelectItem
        ///商品データの取得
        ///</summary>
        public DataTable getSelectItem(string strSelectShohinCD, DBConnective con)
        {
            DataTable dtShohin = new DataTable();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            //商品の処理
            lstStringSQL = new List<string>();

            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_Shohin_SELECT_LEAVE");

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            strSQLInput = opensql.setOpenSQL(lstStringSQL);
            strSQLInput = string.Format(strSQLInput, strSelectShohinCD); //商品コード

            dtShohin = con.ReadSql(strSQLInput);

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
    }
}
