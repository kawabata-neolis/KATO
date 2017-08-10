using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;

namespace KATO.Business.M1150_ShohinTankaIkkatsuUpdate
{
    /// <summary>
    /// M1150_ShohinTankaIkkatsuUpdate_B
    /// 商品マスタ単価一括更新 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/7
    /// 更新者：多田
    /// 更新日：2017/7/7
    /// カラム論理名
    /// </summary>
    class M1150_ShohinTankaIkkatsuUpdate_B
    {

        /// <summary>
        /// getShohinList
        /// 商品マスタを取得
        /// </summary>
        public DataTable getShohinList(List<string> lstItem)
        {
            string strSql;
            DataTable dtGetTableGrid = new DataTable();

            strSql = "SELECT 商品コード,";
            strSql += " dbo.f_get大分類名(大分類コード) AS 大分類名, ";
            strSql += " dbo.f_get中分類名(大分類コード,中分類コード) AS 中分類名, ";
            strSql += " dbo.f_getメーカー名(メーカーコード) AS メーカー名, ";
            strSql += " Rtrim(ISNULL(Ｃ１,'')) ";
            strSql += " + ' ' + Rtrim(ISNULL(Ｃ２,''))";
            strSql += " + ' ' + Rtrim(ISNULL(Ｃ３,''))";
            strSql += " + ' ' + Rtrim(ISNULL(Ｃ４,''))";
            strSql += " + ' ' + Rtrim(ISNULL(Ｃ５,''))";
            strSql += " + ' ' + Rtrim(ISNULL(Ｃ６,'')) AS 品名型式,";
            strSql += " 定価,";
            strSql += " 標準売価,";
            strSql += " 仕入単価,";
            strSql += " 評価単価,";
            strSql += " 建値仕入単価,";
            strSql += " 棚番本社,";
            strSql += " 棚番岐阜,";
            strSql += " 在庫管理区分";
            strSql += " FROM 商品";
            strSql += " WHERE 削除='N'";

            // 大分類コードがある場合
            if (!lstItem[0].Equals(""))
            {
                strSql += " AND 大分類コード='" + lstItem[0] + "'";
            }

            // 中分類コードがある場合
            if (!lstItem[1].Equals(""))
            {
                strSql += " AND 中分類コード='" + lstItem[1] + "'";
            }

            // メーカーコードがある場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND メーカーコード='" + lstItem[2] + "'";
            }

            // 棚番本社がある場合
            if (!lstItem[3].Equals(""))
            {
                strSql += " AND (棚番本社='" + lstItem[3] + "')";
            }

            // 棚番岐阜がある場合
            if (!lstItem[4].Equals(""))
            {
                strSql += " AND (棚番岐阜='" + lstItem[4] + "')";
            }

            // 型番がある場合
            if (!lstItem[5].Equals(""))
            {
                strSql += " AND (Rtrim(ISNULL(Ｃ１,'')) + Rtrim(ISNULL(Ｃ２,'')) + Rtrim(ISNULL(Ｃ３,'')) " +
                    " + Rtrim(ISNULL(Ｃ４,''))  + Rtrim(ISNULL(Ｃ５,''))  + Rtrim(ISNULL(Ｃ６,''))) " +
                    " LIKE '%" + lstItem[5] + "%'";
            }

            // 並び替えが品名順の場合
            if (lstItem[6].Equals("0"))
            {
                strSql += " ORDER BY 大分類コード,中分類コード,品名型式";
            }
            else
            {
                strSql += " ORDER BY 棚番本社,棚番岐阜,大分類コード,中分類コード,品名型式";
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをデータテーブルへ格納
                dtGetTableGrid = dbconnective.ReadSql(strSql);

                return dtGetTableGrid;
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




        /// <summary>
        /// addHidukeSeigen
        /// 表示中の商品マスタを更新する処理
        /// </summary>
        public void updShohinMaster(DataTable dtShohinList, string strUserId)
        {
            string strSql;

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                foreach (DataRow dr in dtShohinList.Rows)
                {

                    strSql = " UPDATE 商品";
                    strSql += " SET ";
                    strSql += " 定価=" + dr["定価"] + ",";
                    strSql += " 標準売価=" + dr["標準売価"] + ",";
                    strSql += " 仕入単価=" + dr["仕入単価"] + ",";
                    strSql += " 評価単価=" + dr["評価単価"] + ",";
                    strSql += " 建値仕入単価=" + dr["建値仕入単価"] + ",";
                    strSql += " 棚番本社='" + dr["棚番本社"] + "',";
                    strSql += " 棚番岐阜='" + dr["棚番岐阜"] + "',";
                    strSql += " 在庫管理区分='" + dr["在庫管理区分"] + "',";
                    strSql += " 更新日時=GETDATE(),";
                    strSql += " 更新ユーザー名='" + strUserId + "'";
                    strSql += " WHERE ";
                    strSql += " 商品コード='" + dr["商品コード"] + "'";

                    // 更新を実行
                    dbconnective.RunSql(strSql);
                }

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



        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtShohinList">
        ///     仕入実績確認のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtShohinList, List<string> lstItem)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            try
            {
                CreatePdf pdf = new CreatePdf();

                // ワークブックのデフォルトフォント、フォントサイズの指定
                XLWorkbook.DefaultStyle.Font.FontName = "ＭＳ 明朝";
                XLWorkbook.DefaultStyle.Font.FontSize = 9;

                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled);

                IXLWorksheet worksheet = workbook.Worksheets.Add("Header");
                IXLWorksheet headersheet = worksheet;   // ヘッダーシート
                IXLWorksheet currentsheet = worksheet;  // 処理中シート

                //Linqで必要なデータをselect
                var outDataAll = dtShohinList.AsEnumerable()
                    .Select(dat => new
                    {
                        daibunrui = dat["大分類名"],
                        chubunrui = dat["中分類名"],
                        maker = dat["メーカー名"],
                        kataban = dat["品名型式"],
                        teika = (decimal)dat["定価"],
                        baika = (decimal)dat["標準売価"],
                        siireTanak = (decimal)dat["仕入単価"],
                        hyokaTanka = (decimal)dat["評価単価"],
                        tateneTanka = (decimal)dat["建値仕入単価"],
                        tanabanHonsha = dat["棚番本社"],
                        tanabanGifu = dat["棚番岐阜"],
                    }).ToList();

                // リストをデータテーブルに変換
                DataTable dtShohin = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtShohin.Rows.Count;
                int maxColCnt = dtShohin.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                double page = 1.0 * maxRowCnt / 35;
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
                foreach (DataRow drShohin in dtShohin.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "商品単価一覧";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 14.5;
                        headersheet.Range("A1", "K1").Merge();

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "大分類";
                        headersheet.Cell("B3").Value = "中分類";
                        headersheet.Cell("C3").Value = "メーカー名";
                        headersheet.Cell("D3").Value = "品名・型番";
                        headersheet.Cell("E3").Value = "定価";
                        headersheet.Cell("F3").Value = "標準売価";
                        headersheet.Cell("G3").Value = "仕入単価";
                        headersheet.Cell("H3").Value = "評価単価";
                        headersheet.Cell("I3").Value = "建値単価";
                        headersheet.Cell("J3").Value = "本社棚番";
                        headersheet.Cell("K3").Value = "岐阜棚番";

                        // ヘッダー列
                        headersheet.Range("A3", "K3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "K3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // 列幅の指定
                        headersheet.Column(1).Width = 14;
                        headersheet.Column(2).Width = 14;
                        headersheet.Column(3).Width = 14;
                        headersheet.Column(4).Width = 40;
                        headersheet.Column(5).Width = 12;
                        headersheet.Column(6).Width = 12;
                        headersheet.Column(7).Width = 12;
                        headersheet.Column(8).Width = 12;
                        headersheet.Column(9).Width = 12;
                        headersheet.Column(10).Width = 10;
                        headersheet.Column(11).Width = 10;

                        // 印刷体裁（B4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.B4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№115）");

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drShohin[colCnt - 1].ToString();

                        // 品名・型式セルの処理
                        if (colCnt == 4)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        // 金額セルの処理
                        if (colCnt >= 5 && colCnt <= 6)
                        {
                            // 3桁毎に","を挿入する
                            str = string.Format("{0:#,0}", decimal.Parse(str));
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 単価セルの処理
                        if (colCnt >= 7 && colCnt <= 9)
                        {
                            // 3桁毎に","を挿入する、小数点第2位まで
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("#,##0.00");
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 棚番セルの処理
                        if (colCnt == 10 || colCnt == 11)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;

                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 11).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 39)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                        }
                    }

                    rowCnt++;
                    xlsRowCnt++;
                }

                // ヘッダーシート削除
                headersheet.Delete();

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // PDF化の処理
                return pdf.createPdf(strOutXlsFile, strDateTime);

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

    }
}
