using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.ComponentModel;

using Spire.Xls;
using ClosedXML.Excel;

//iTextSharp関連の名前空間
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace KATO.Business.D0300_ZaikoIchiranKakunin
{
    /// <summary>
    /// D0300_ZaikoIchiranKakunin_B
    /// 在庫一覧確認 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/20
    /// 更新者：多田
    /// 更新日：2017/7/20
    /// カラム論理名
    /// </summary>
    class D0300_ZaikoIchiranKakunin_B
    {

        /// <summary>
        /// delShiharai
        /// 在庫一覧表データ作成処理
        /// </summary>
        public void addZaikoIchiranCreate(List<string> lstItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "在庫一覧表データ作成_PROC '" + lstItem[0] + "', '" + lstItem[1] + "', '" +
                    lstItem[2] + "', '" + lstItem[3] + "', '" + lstItem[4] + "'";

                // 在庫一覧表データ作成_PROCを実行
                dbconnective.ReadSql(strProc);

                // コミット
                dbconnective.Commit();
            }
            catch
            {
                // ロールバック処理
                dbconnective.Rollback();
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return;
        }

        /// <summary>
        /// getZaikoIchiran
        /// 在庫一覧を取得
        /// </summary>
        public DataTable getZaikoIchiran(List<string> lstItem)
        {
            string strSql;
            DataTable dtZaikoIchiran = new DataTable();

            DateTime dtYmd = DateTime.Parse(lstItem[0]);
            dtYmd = dtYmd.AddDays(-1);

            // 営業所コードが本社の場合
            if (lstItem[2].Equals("0001"))
            {
                strSql = "SELECT 棚番本社 AS 棚番,";
            }
            else
            {
                strSql = "SELECT 棚番岐阜 AS 棚番,";
            }

            strSql += "dbo.f_getメーカー名(メーカーコード)  AS メーカー名 ,";
            strSql += "RTRIM(dbo.f_get中分類名(大分類コード,中分類コード)) + ' ' +";
            strSql += "RTRIM(ISNULL(商品.Ｃ１,'')) + ' ' +";
            strSql += "RTRIM(ISNULL(商品.Ｃ２,'')) + ' ' +";
            strSql += "RTRIM(ISNULL(商品.Ｃ３,'')) + ' ' +";
            strSql += "RTRIM(ISNULL(商品.Ｃ４,'')) + ' ' +";
            strSql += "RTRIM(ISNULL(商品.Ｃ５,'')) + ' ' +";
            strSql += "RTRIM(ISNULL(商品.Ｃ６,'')) AS 品名,";
            strSql += "仕入単価,評価単価,建値仕入単価,";

            // 前月在庫
            strSql += "dbo.f_get指定日の在庫数_棚卸専用('" + lstItem[2] + "', 商品コード, '" + dtYmd + "') AS 前月在庫,";
            
            // 入庫数
            strSql += "dbo.f_get指定期間_仕入数量_仕入明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_入庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動入数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_棚卸調整数_棚卸調整_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') AS 入庫数,";
            
            // 出庫数
            strSql += "dbo.f_get指定期間_売上数量_売上明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_出庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動出数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') AS 出庫数,";

            // 現在庫数
            strSql += "(dbo.f_get指定日の在庫数_棚卸専用('" + lstItem[2] + "', 商品コード, '" + dtYmd + "') ) +";
            strSql += "(dbo.f_get指定期間_仕入数量_仕入明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_入庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動入数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_棚卸調整数_棚卸調整_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) - ";
            strSql += "(dbo.f_get指定期間_売上数量_売上明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_出庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動出数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) AS 現在庫数,";

            // 在庫金額（仕入金額）
            strSql += " CASE WHEN ";
            strSql += "(dbo.f_get指定日の在庫数_棚卸専用('" + lstItem[2] + "', 商品コード, '" + dtYmd + "') ) +";
            strSql += "(dbo.f_get指定期間_仕入数量_仕入明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_入庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動入数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_棚卸調整数_棚卸調整_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) - ";
            strSql += "(dbo.f_get指定期間_売上数量_売上明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_出庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動出数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) <= 0 ";
            strSql += " THEN 0 ELSE ";

            strSql += "ROUND(((dbo.f_get指定日の在庫数_棚卸専用('" + lstItem[2] + "', 商品コード, '" + dtYmd + "') ) +";

            strSql += "(dbo.f_get指定期間_仕入数量_仕入明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_入庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動入数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_棚卸調整数_棚卸調整_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) - ";

            strSql += "(dbo.f_get指定期間_売上数量_売上明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_出庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動出数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')))  ";
            strSql += " * 仕入単価,0,1) END  AS 在庫仕入金額,";

            // 在庫金額（評価金額）
            strSql += " CASE WHEN ";
            strSql += "(dbo.f_get指定日の在庫数_棚卸専用('" + lstItem[2] + "', 商品コード, '" + dtYmd + "') ) +";
            strSql += "(dbo.f_get指定期間_仕入数量_仕入明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_入庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動入数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_棚卸調整数_棚卸調整_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) - ";
            strSql += "(dbo.f_get指定期間_売上数量_売上明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_出庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動出数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) <= 0 ";
            strSql += " THEN 0 ELSE ";

            strSql += "ROUND(((dbo.f_get指定日の在庫数_棚卸専用('" + lstItem[2] + "', 商品コード, '" + dtYmd + "') ) +";

            strSql += "(dbo.f_get指定期間_仕入数量_仕入明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_入庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動入数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_棚卸調整数_棚卸調整_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) - ";

            strSql += "(dbo.f_get指定期間_売上数量_売上明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_出庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動出数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')))  ";
            strSql += " * 評価単価,0,1) END  AS 在庫評価金額,";

            // 在庫金額（建値金額）
            strSql += " CASE WHEN ";
            strSql += "(dbo.f_get指定日の在庫数_棚卸専用('" + lstItem[2] + "', 商品コード, '" + dtYmd + "') ) +";
            strSql += "(dbo.f_get指定期間_仕入数量_仕入明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_入庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動入数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_棚卸調整数_棚卸調整_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) - ";
            strSql += "(dbo.f_get指定期間_売上数量_売上明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_出庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動出数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) <= 0 ";
            strSql += " THEN 0 ELSE ";

            strSql += "ROUND(((dbo.f_get指定日の在庫数_棚卸専用('" + lstItem[2] + "', 商品コード, '" + dtYmd + "') ) +";

            strSql += "(dbo.f_get指定期間_仕入数量_仕入明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_入庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動入数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_棚卸調整数_棚卸調整_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) - ";

            strSql += "(dbo.f_get指定期間_売上数量_売上明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_出庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += "dbo.f_get指定期間_移動出数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')))  ";
            strSql += " * 建値仕入単価,0,1) END  AS 在庫建値金額,";

            strSql += " 大分類コード,";
            strSql += "dbo.f_get大分類名(大分類コード) AS 大分類名,";
            strSql += "dbo.f_get営業所名('" + lstItem[2] + "') AS 営業所名";

            strSql += " FROM 商品";
            strSql += " WHERE 削除 = 'N'";

            // 大分類コードがある場合
            if (!lstItem[3].Equals(""))
            {
                strSql += " AND 大分類コード    = '" + lstItem[3] + "'";
            }

            // 中分類コードがある場合
            if (!lstItem[4].Equals(""))
            {
                strSql += " AND 中分類コード='" + lstItem[4] + "'";
            }

            // メーカーコードがある場合
            if (!lstItem[5].Equals(""))
            {
                strSql += " AND メーカーコード='" + lstItem[5] + "'";
            }

            //前月在庫<>0 入庫数<>0 出庫数<>0
            strSql += " AND ( (dbo.f_get指定日の在庫数_棚卸専用('" + lstItem[2] + "', 商品コード, '" + dtYmd + "') <>0 ) ";
            strSql += " OR ((dbo.f_get指定期間_仕入数量_仕入明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += " dbo.f_get指定期間_入庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += " dbo.f_get指定期間_移動入数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += " dbo.f_get指定期間_棚卸調整数_棚卸調整_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) <> 0 ) ";
            strSql += " OR ((dbo.f_get指定期間_売上数量_売上明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += " dbo.f_get指定期間_出庫数量_出庫明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') +";
            strSql += " dbo.f_get指定期間_移動出数_倉庫間移動_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "')) <> 0) ) ";

            // 期間中に仕入がある場合
            if (lstItem[7].Equals("0"))
            {
                strSql += " AND dbo.f_get指定期間_仕入数量_仕入明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') <> 0 ";
            }
            // 期間中に仕入がない場合
            else if (lstItem[7].Equals("1"))
            {
                strSql += " AND dbo.f_get指定期間_仕入数量_仕入明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') =0 ";
            }

            // 期間中に売上がある場合
            if (lstItem[8].Equals("0"))
            {
                strSql += " AND dbo.f_get指定期間_売上数量_売上明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') <> 0 ";
            }
            // 期間中に売上がない場合
            else if (lstItem[8].Equals("1"))
            {
                strSql += " AND dbo.f_get指定期間_売上数量_売上明細_在庫一覧専用('" + lstItem[2] + "',商品コード, '" + lstItem[0] + "', '" + lstItem[1] + "') =0 ";
            }

            // 棚番がある場合
            if (!lstItem[6].Equals(""))
            {
                strSql += " AND ((棚番本社 LIKE '" + lstItem[6] + "%') OR (棚番岐阜 LIKE '" + lstItem[6] + "%'))";
            }

            // 営業所コードが空でない場合、SQL文で並び替え
            if (lstItem[10].Equals("1"))
            {
                // 並び順の指定
                if (lstItem[9].Equals("0"))
                {
                    strSql += "  ORDER BY 大分類コード, 品名";
                }
                else if (lstItem[9].Equals("1"))
                {
                    strSql += "  ORDER BY 大分類コード, メーカー名, 品名";
                }
                else if (lstItem[9].Equals("2"))
                {
                    strSql += "  ORDER BY 大分類コード, 棚番, メーカー名, 品名";
                }
                else if (lstItem[9].Equals("3"))
                {
                    strSql += "  ORDER BY 大分類コード, 棚番, 品名";
                }
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtZaikoIchiran = dbconnective.ReadSql(strSql);

                return dtZaikoIchiran;
            }
            catch
            {
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtSiireCheakList">
        ///     仕入推移表のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtZaikoIchiran, List<string> lstItem)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                string strHeader = "";
                string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                string strSpace = "       ";
                string strComputerName = System.Windows.Forms.SystemInformation.ComputerName;

                // ワークブックのデフォルトフォント、フォントサイズの指定
                XLWorkbook.DefaultStyle.Font.FontName = "ＭＳ 明朝";
                XLWorkbook.DefaultStyle.Font.FontSize = 9;

                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled);

                IXLWorksheet worksheet = workbook.Worksheets.Add("Header");
                IXLWorksheet headersheet = worksheet;   // ヘッダーシート
                IXLWorksheet currentsheet = worksheet;  // 処理中シート


                //Linqで必要なデータをselect
                var outDataAll = dtZaikoIchiran.AsEnumerable()
                    .Select(dat => new
                    {
                        tanaban = dat["棚番"],
                        maker = dat["メーカー名"],
                        hinmei = dat["品名"],
                        siireTanka = (decimal)dat["仕入単価"],
                        hyokaTanka = (decimal)dat["評価単価"],
                        tateneTanka = (decimal)dat["建値仕入単価"],
                        zengetsu = (decimal)dat["前月在庫"],
                        nyuko = (decimal)dat["入庫数"],
                        syuko = (decimal)dat["出庫数"],
                        zaiko = (decimal)dat["現在庫数"],
                        siireKingaku = (decimal)dat["在庫仕入金額"],
                        hyokaKingaku = (decimal)dat["在庫評価金額"],
                        tateneKingaku = (decimal)dat["在庫建値金額"],
                        daibunrui = dat["大分類名"],
                        eigyoshoName = dat["営業所名"]
                    }).ToList();

                // linqで在庫仕入金額、在庫評価金額、在庫建値金額の合計算出
                decimal[] decKingaku = new decimal[3];
                decKingaku[0] = outDataAll.Select(gokei => gokei.siireKingaku).Sum();
                decKingaku[1] = outDataAll.Select(gokei => gokei.hyokaKingaku).Sum();
                decKingaku[2] = outDataAll.Select(gokei => gokei.tateneKingaku).Sum();

                // リストをデータテーブルに変換
                DataTable dtChkList = this.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                double page = 1.0 * maxRowCnt / 29;
                double decimalpart = page % 1;
                if (decimalpart != 0)
                {
                    // 小数点以下が0でない場合、+1
                    maxPage = (int)Math.Floor(page) + 1;
                }
                else
                {
                    maxPage = (int)page;
                }

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drZaiko in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "在　庫　一　覧　表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "M1").Merge();

                        // 営業所出力（A2のセル）
                        // 営業所コードが空でない場合
                        if (lstItem[10].Equals("1"))
                        {
                            headersheet.Cell("A2").Value = " " + drZaiko[14].ToString();
                        }
                        else
                        {
                            headersheet.Cell("A2").Value = " 本社、岐阜";
                        }

                        // 大分類名出力（C2のセル）
                        headersheet.Cell("C2").Value = " " + drZaiko[13].ToString();

                        // 在庫期間出力（M2のセル）
                        IXLCell kikanCell = headersheet.Cell("M2");
                        kikanCell.Value = "在庫期間：：" + string.Format(lstItem[0], "yyyy年MM月dd日") + "～" +
                            string.Format(lstItem[1], "yyyy年MM月dd日");
                        kikanCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "棚番";
                        headersheet.Cell("B3").Value = "メーカー名";
                        headersheet.Cell("C3").Value = "品　　名　･　型　　番";
                        headersheet.Cell("D3").Value = "仕入単価";
                        headersheet.Cell("E3").Value = "評価単価";
                        headersheet.Cell("F3").Value = "建値仕入単価";
                        headersheet.Cell("G3").Value = "前月在庫";
                        headersheet.Cell("H3").Value = "入庫数";
                        headersheet.Cell("I3").Value = "出庫数";
                        headersheet.Cell("J3").Value = "現在個数";
                        headersheet.Cell("K3").Value = "在庫仕入金額";
                        headersheet.Cell("L3").Value = "在庫評価金額";
                        headersheet.Cell("M3").Value = "在庫建値金額";

                        // ヘッダー列
                        headersheet.Range("A3", "M3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "M3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // 列幅の指定
                        headersheet.Column(1).Width = 6;
                        headersheet.Column(2).Width = 12;
                        headersheet.Column(3).Width = 30;
                        headersheet.Column(4).Width = 11;
                        headersheet.Column(5).Width = 11;
                        headersheet.Column(6).Width = 11;
                        headersheet.Column(7).Width = 8;
                        headersheet.Column(8).Width = 6;
                        headersheet.Column(9).Width = 6;
                        headersheet.Column(10).Width = 8;
                        headersheet.Column(11).Width = 11;
                        headersheet.Column(12).Width = 11;
                        headersheet.Column(13).Width = 11;

                        // フォントサイズ変更
                        headersheet.Range("B4:C32").Style.Font.FontSize = 6;

                        // 印刷体裁（A4横、印刷範囲、余白）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
                        headersheet.PageSetup.Margins.Left = 0.2;
                        headersheet.PageSetup.Margins.Right = 0.2;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№30）");

                        // ヘッダーシートからコピー
                        headersheet.CopyTo("Page1");
                        currentsheet = workbook.Worksheet(2);

                        // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
                        strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                            pageCnt.ToString() + " / " + maxPage.ToString();
                        currentsheet.PageSetup.Header.Right.AddText(strHeader);

                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt - 2; colCnt++)
                    {
                        string str = drZaiko[colCnt - 1].ToString();

                        // 数値、金額セルの処理
                        if (colCnt >= 7 && colCnt <= 13)
                        {
                            // 3桁毎に","を挿入する
                            //str = string.Format("{0:#,0}", decimal.Parse(str));
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("#,##0");
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 単価セルの処理
                        if (colCnt >= 4 && colCnt <= 6)
                        {
                            // 3桁毎に","を挿入する、小数点第2位まで
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("#,##0.00");
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 29行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 32)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // コンピュータ名、日付、ページ数を取得
                            strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                                pageCnt.ToString() + " / " + maxPage.ToString();

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, strHeader);
                        }
                    }

                    rowCnt++;
                    xlsRowCnt++;
                }

                // 最終行を出力した後、合計行を出力
                if (dtChkList.Rows.Count > 0)
                {
                    for (int cnt = 0; cnt < 3; cnt++)
                    {
                        // 3桁毎に","を挿入する
                        currentsheet.Cell(xlsRowCnt, 11 + cnt).Value = string.Format("{0:#,0}", decKingaku[cnt]);
                        currentsheet.Cell(xlsRowCnt, 11 + cnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    }

                    // セル結合
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 10).Merge();
                    currentsheet.Cell(xlsRowCnt, 1).Value = "合計金額：";
                    currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);
                }

                // ヘッダーシート削除
                headersheet.Delete();

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // PDF化の処理
                return createPdf(strOutXlsFile, strDateTime);

            }
            catch
            {
                throw;
            }
            finally
            {
                // Workフォルダの全ファイルを取得
                string[] files = System.IO.Directory.GetFiles(strWorkPath, "*", System.IO.SearchOption.AllDirectories);
                // Workフォルダ内のファイル削除
                foreach (string filepath in files)
                {
                    //File.Delete(filepath);
                }
            }

        }

        /// <summary>
        /// ヘッダーシートをコピーし、ヘッダー部を指定
        /// <param name="workbook">参照型 ワークブック</param>
        /// <param name="headersheet">参照型 ヘッダーシート</param>
        /// <param name="currentsheet">参照型 カレントシート</param>
        /// <param name="pageCnt">ページ数</param>
        /// <param name="strHeader">コンピュータ名、日付、ページ数</param>
        /// </summary>
        private void sheetCopy(ref XLWorkbook workbook, ref IXLWorksheet headersheet, ref IXLWorksheet currentsheet, int pageCnt, string strHeader)
        {
            // ヘッダーシートからコピー
            headersheet.CopyTo("Page" + pageCnt.ToString());
            currentsheet = workbook.Worksheet(pageCnt + 1);

            // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
            currentsheet.PageSetup.Header.Right.AddText(strHeader);
        }

        /// 【共通化可能】
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// PDF化(Spire.xls)の処理
        /// <param name="strInXlsFile">エクセルファイル</param>
        /// <param name="strDateTime">日時</param>
        /// </summary>
        /// -----------------------------------------------------------------------------
        private string createPdf(string strInXlsFile, string strDateTime)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strPdfPath = System.Configuration.ConfigurationManager.AppSettings["pdfpath"];
            string strJoinPdfFile;

            try
            {

                Workbook printbook = new Workbook();
                printbook.LoadFromFile(strInXlsFile, ExcelVersion.Version2010);
                int sheetMax = printbook.Worksheets.Count;

                // Excelシートの枚数分PDF化
                for (int sheetCnt = 0; sheetCnt < sheetMax; sheetCnt++)
                {
                    // pdf化するシートを取得
                    Worksheet printsheet = printbook.Worksheets[sheetCnt];

                    string no = no = (sheetCnt + 1).ToString();
                    if (no.Length == 1)
                    {
                        no = "0" + no;
                    }

                    string strPdfFile = strWorkPath + strDateTime + "_" + no + ".pdf";

                    // 出力したいシートをPDFで保存
                    printsheet.SaveToPdf(strPdfFile);

                    // シートカウントが0の場合結合用のPDFを保存
                    if (sheetCnt == 0)
                    {
                        string strJoinyouPdfFile = strPdfPath + strDateTime + ".pdf";

                        // 出力したいシートをPDFで保存
                        printsheet.SaveToPdf(strJoinyouPdfFile);
                    }
                }
                // printbookを解放
                printbook.Dispose();

                // フォルダ下の作成日時".pdf"ファイルをすべて取得する
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strWorkPath);
                System.IO.FileInfo[] fiFiles = di.GetFiles(strDateTime + "*.pdf", System.IO.SearchOption.AllDirectories);
                Array.Sort<FileInfo>(fiFiles, delegate (FileInfo f1, FileInfo f2)
                {
                    // ファイル名でソート
                    return f1.Name.CompareTo(f2.Name);
                });
                int filesMax = fiFiles.Count();
                string[] strFiles = new string[filesMax];

                // FileInfo配列をstring配列に
                for (int fileCnt = 0; fileCnt < filesMax; fileCnt++)
                {
                    strFiles[fileCnt] = strWorkPath + fiFiles[fileCnt].Name;
                }

                // 結合PDFオブジェクト
                strJoinPdfFile = strPdfPath + strDateTime + ".pdf";

                // PDFファイル数が0でなければ結合
                if (filesMax != 0)
                {
                    fnJoinPdf(strFiles, strJoinPdfFile, 1);
                }

            }
            catch
            {
                throw;
            }
            return strJoinPdfFile;
        }


        /// 【共通化可能】
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// PDFファイルの結合
        /// WritePage = 0：全ページ、WritePage = 1：全ファイルの1ページのみ
        /// WritePage = 2(3...)：全ファイルの1～2(1～3)ページ
        /// </summary>
        /// <param name="sSrcFilePath1">入力ファイルパス1</param>
        /// <param name="sSrcFilePath2">入力ファイルパス2</param>
        /// <param name="sJoinFilePath">結合ファイルパス</param>
        /// <param name="WritePage">結合ページ数</param>
        /// -----------------------------------------------------------------------------
        private void fnJoinPdf(string[] arySrcFilePath, string sJoinFilePath, int WritePage)
        {
            Document doc = null;    // 出力ファイルDocument
            PdfCopy copy = null;    // 出力ファイルPdfCopy

            try
            {
                //-------------------------------------------------------------------------------------
                // ファイル件数分、ファイル結合
                //-------------------------------------------------------------------------------------
                for (int i = 0; i < arySrcFilePath.Length; i++)
                {
                    // リーダー取得
                    PdfReader reader = new PdfReader(arySrcFilePath[i]);
                    // 入力ファイル1を出力ファイルの雛形にする
                    if (i == 0)
                    {
                        // Document作成
                        doc = new Document(reader.GetPageSizeWithRotation(1));
                        // 出力ファイルPdfCopy作成
                        copy = new PdfCopy(doc, new FileStream(sJoinFilePath, FileMode.Create));
                        // 出力ファイルDocumentを開く
                        doc.Open();
                        // 文章プロパティ設定
                        //doc.AddKeywords((string)reader.Info["Keywords"]);
                        //doc.AddAuthor((string)reader.Info["Author"]);
                        //doc.AddTitle((string)reader.Info["Title"]);
                        //doc.AddCreator((string)reader.Info["Creator"]);
                        //doc.AddSubject((string)reader.Info["Subject"]);
                    }
                    // 結合するPDFのページ数
                    if (WritePage == 0) WritePage = reader.NumberOfPages;
                    if (WritePage > reader.NumberOfPages) WritePage = reader.NumberOfPages;

                    // PDFコンテンツを取得、copyオブジェクトに追加
                    for (int iPageCnt = 1; iPageCnt <= WritePage; iPageCnt++)
                    {
                        PdfImportedPage page = copy.GetImportedPage(reader, iPageCnt);
                        copy.AddPage(page);
                    }
                    // フォーム入力を結合
                    PRAcroForm form = reader.AcroForm;
                    if (form != null)
                        copy.AddDocument(reader);
                    // リーダーを閉じる
                    reader.Close();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (copy != null)
                    copy.Close();
                if (doc != null)
                    doc.Close();
            }
        }


        /// -----------------------------------------------------------------------------------------
        /// <summary>
        /// ListをDataTableへ変換
        /// </summary>
        /// -----------------------------------------------------------------------------------------
        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }






    }
}
