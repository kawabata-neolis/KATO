using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;
using System.Runtime.InteropServices;

namespace KATO.Business.C0130_TantouUriageArariPrint
{
    /// <summary>
    /// C0130_TantouUriageArariPrint_B
    /// 担当者別売上管理表 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/31
    /// 更新者：多田
    /// 更新日：2017/7/31
    /// カラム論理名
    /// </summary>
    class C0130_TantouUriageArariPrint_B
    {
        /// <summary>
        /// getUriage
        /// 担当者別売上管理表_PROCを実行
        /// </summary>
        public DataTable getUriage(List<string> lstDataName)
        {
            DataTable dtRet = new DataTable();

            List<string> lstTableName = new List<string>();
            lstTableName.Add("@開始年月日");
            lstTableName.Add("@終了年月日");
            lstTableName.Add("@開始営業所コード");
            lstTableName.Add("@終了営業所コード");
            lstTableName.Add("@開始グループコード");
            lstTableName.Add("@終了グループコード");
            lstTableName.Add("@開始担当者コード");
            lstTableName.Add("@終了担当者コード");
            lstTableName.Add("@経過月数");

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 請求明細書_PROCを実行
                dtRet = dbconnective.RunSqlReDT("担当者別売上管理表_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@結果");

                return dtRet;
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
        /// <param name="dtUriage">
        ///     売上管理表のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtUriage, List<string> lstItem, string pr, int num)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbooks objWorkBooks = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkBook = null;
            Microsoft.Office.Interop.Excel.Worksheet objWorkSheet = null;
            Microsoft.Office.Interop.Excel.Range objRange = null;

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


                // Linqで必要なデータをselect
                var outDataAll = dtUriage.AsEnumerable()
                    .Select(dat => new
                    {
                        eigyoCd = dat["営業所コード"],
                        eigyoName = dat["営業所名"],
                        groupCd = dat["グループコード"],
                        groupName = dat["グループ名"],
                        tantoCd = dat["担当者コード"],
                        tantoName = dat["担当者名"],
                        uriage = (decimal)dat["売上額"],
                        arari = (decimal)dat["粗利額"],
                        arariRitsu = (decimal)dat["粗利率"],
                        getsumatsuUriage = (decimal)dat["月末迄受注残売上"],
                        getsumatsuArari = (decimal)dat["月末迄受注残粗利"],
                        yokugetsuUriage = (decimal)dat["翌月以降受注残売上"],
                        yokugetsuArari = (decimal)dat["翌月以降受注残粗利"],
                        getsumatsuUrikake= (decimal)dat["月末売掛金残"],
                        nyukin = (decimal)dat["当月入金額"],
                        uriageMokuhyo = (decimal)dat["年間売上目標"],
                        tassei = (decimal)dat["達成率"]
                    }).ToList();

                // linqで合計算出
                decimal[] decKingaku = new decimal[11];
                decKingaku[0] = outDataAll.Select(gokei => gokei.uriage).Sum();
                decKingaku[1] = outDataAll.Select(gokei => gokei.arari).Sum();
                decKingaku[2] = 0;
                decKingaku[3] = outDataAll.Select(gokei => gokei.getsumatsuUriage).Sum();
                decKingaku[4] = outDataAll.Select(gokei => gokei.getsumatsuArari).Sum();
                decKingaku[5] = outDataAll.Select(gokei => gokei.yokugetsuUriage).Sum();
                decKingaku[6] = outDataAll.Select(gokei => gokei.yokugetsuArari).Sum();
                decKingaku[7] = outDataAll.Select(gokei => gokei.getsumatsuUrikake).Sum();
                decKingaku[8] = outDataAll.Select(gokei => gokei.nyukin).Sum();
                decKingaku[9] = outDataAll.Select(gokei => gokei.uriageMokuhyo).Sum();
                decKingaku[10] = 0;

                // グループ計
                var groupGoukei = from tbl in dtUriage.AsEnumerable()
                                  group tbl
                                  by new
                                  {
                                      eigyoCd = tbl.Field<string>("営業所コード"),
                                      groupCd = tbl.Field<string>("グループコード")
                                  }
                                  into g
                                  select new
                                  {
                                      section = g.Key,
                                      count = g.Count(),
                                      uriage = g.Sum(p => p.Field<decimal>("売上額")),
                                      arari = g.Sum(p => p.Field<decimal>("粗利額")),
                                      getsumatsuUriage = g.Sum(p => p.Field<decimal>("月末迄受注残売上")),
                                      getsumatsuArari = g.Sum(p => p.Field<decimal>("月末迄受注残粗利")),
                                      yokugetsuUriage = g.Sum(p => p.Field<decimal>("翌月以降受注残売上")),
                                      yokugetsuArari = g.Sum(p => p.Field<decimal>("翌月以降受注残粗利")),
                                      getsumatsuUrikake = g.Sum(p => p.Field<decimal>("月末売掛金残")),
                                      nyukin = g.Sum(p => p.Field<decimal>("当月入金額")),
                                      uriageMokuhyo = g.Sum(p => p.Field<decimal>("年間売上目標"))
                                  };

                // グループ計の合計算出
                decimal[,] decKingakuGroup = new decimal[groupGoukei.Count(), 11];
                for (int cnt = 0; cnt < groupGoukei.Count(); cnt++)
                {
                    decKingakuGroup[cnt, 0] = groupGoukei.ElementAt(cnt).uriage;
                    decKingakuGroup[cnt, 1] = groupGoukei.ElementAt(cnt).arari;
                    decKingakuGroup[cnt, 2] = 0;
                    decKingakuGroup[cnt, 3] = groupGoukei.ElementAt(cnt).getsumatsuUriage;
                    decKingakuGroup[cnt, 4] = groupGoukei.ElementAt(cnt).getsumatsuArari;
                    decKingakuGroup[cnt, 5] = groupGoukei.ElementAt(cnt).yokugetsuUriage;
                    decKingakuGroup[cnt, 6] = groupGoukei.ElementAt(cnt).yokugetsuArari;
                    decKingakuGroup[cnt, 7] = groupGoukei.ElementAt(cnt).getsumatsuUrikake;
                    decKingakuGroup[cnt, 8] = groupGoukei.ElementAt(cnt).nyukin;
                    decKingakuGroup[cnt, 9] = groupGoukei.ElementAt(cnt).uriageMokuhyo;
                    decKingakuGroup[cnt, 10] = 0;
                }

                // 営業所計
                var eigyoGoukei = from tbl in dtUriage.AsEnumerable()
                                  group tbl by tbl.Field<string>("営業所コード") into g
                                  select new
                                  {
                                      section = g.Key,
                                      count = g.Count(),
                                      uriage = g.Sum(p => p.Field<decimal>("売上額")),
                                      arari = g.Sum(p => p.Field<decimal>("粗利額")),
                                      getsumatsuUriage = g.Sum(p => p.Field<decimal>("月末迄受注残売上")),
                                      getsumatsuArari = g.Sum(p => p.Field<decimal>("月末迄受注残粗利")),
                                      yokugetsuUriage = g.Sum(p => p.Field<decimal>("翌月以降受注残売上")),
                                      yokugetsuArari = g.Sum(p => p.Field<decimal>("翌月以降受注残粗利")),
                                      getsumatsuUrikake = g.Sum(p => p.Field<decimal>("月末売掛金残")),
                                      nyukin = g.Sum(p => p.Field<decimal>("当月入金額")),
                                      uriageMokuhyo = g.Sum(p => p.Field<decimal>("年間売上目標"))
                                  };

                // 営業所計の合計算出
                decimal[,] decKingakuEigyo = new decimal[eigyoGoukei.Count(), 11];
                for (int cnt = 0; cnt < eigyoGoukei.Count(); cnt++)
                {
                    decKingakuEigyo[cnt, 0] = eigyoGoukei.ElementAt(cnt).uriage;
                    decKingakuEigyo[cnt, 1] = eigyoGoukei.ElementAt(cnt).arari;
                    decKingakuEigyo[cnt, 2] = 0;
                    decKingakuEigyo[cnt, 3] = eigyoGoukei.ElementAt(cnt).getsumatsuUriage;
                    decKingakuEigyo[cnt, 4] = eigyoGoukei.ElementAt(cnt).getsumatsuArari;
                    decKingakuEigyo[cnt, 5] = eigyoGoukei.ElementAt(cnt).yokugetsuUriage;
                    decKingakuEigyo[cnt, 6] = eigyoGoukei.ElementAt(cnt).yokugetsuArari;
                    decKingakuEigyo[cnt, 7] = eigyoGoukei.ElementAt(cnt).getsumatsuUrikake;
                    decKingakuEigyo[cnt, 8] = eigyoGoukei.ElementAt(cnt).nyukin;
                    decKingakuEigyo[cnt, 9] = eigyoGoukei.ElementAt(cnt).uriageMokuhyo;
                    decKingakuEigyo[cnt, 10] = 0;
                }

                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 5;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                maxRowCnt += groupGoukei.Count() * 2 + eigyoGoukei.Count() + 1;
                double page = 1.0 * maxRowCnt / 34;
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

                int groupCnt = 0;
                int groupRowCnt = 0;
                int eigyoCnt = 0;
                int eigyoRowCnt = 0;

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drUriage in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "担当者別売上管理表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "N1").Merge();

                        // 開始年月日、終了年月日出力（A3のセル）
                        IXLCell unitCell = headersheet.Cell("A3");
                        unitCell.Value = "期間：：" +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[0])) + "～" +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[1]));
                        unitCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("G3").Value = "指定期間内受注残";
                        headersheet.Range("G3", "H3").Merge();
                        headersheet.Cell("I3").Value = "指定期間以降受注残";
                        headersheet.Range("I3", "J3").Merge();

                        // ヘッダー出力（4行目のセル）
                        headersheet.Cell("A4").Value = "営業所名";
                        headersheet.Cell("B4").Value = "グループ名";
                        headersheet.Cell("C4").Value = "担当者名";
                        headersheet.Cell("D4").Value = "売上額";
                        headersheet.Cell("E4").Value = "粗利額";
                        headersheet.Cell("F4").Value = "粗利率";
                        headersheet.Cell("G4").Value = "金　額";
                        headersheet.Cell("H4").Value = "粗　利";
                        headersheet.Cell("I4").Value = "金　額";
                        headersheet.Cell("J4").Value = "粗　利";
                        headersheet.Cell("K4").Value = "月末売掛金残";
                        headersheet.Cell("L4").Value = "当月入金額";
                        headersheet.Cell("M4").Value = "月目標";
                        headersheet.Cell("N4").Value = "期間達成率";

                        // ヘッダー列
                        headersheet.Range("G3", "J3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        headersheet.Range("A4", "N4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("G3", "J3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);
                        headersheet.Range("A4", "N4").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("G3", "J3").Style.Fill.BackgroundColor = XLColor.LightGray;
                        headersheet.Range("A4", "N4").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        //headersheet.Column(1).Width = 10;
                        headersheet.Column(1).Width = 8.1;
                        //headersheet.Column(2).Width = 10;
                        headersheet.Column(2).Width = 10;
                        //headersheet.Column(3).Width = 14;
                        headersheet.Column(3).Width = 12.7;
                        //headersheet.Column(4).Width = 12;
                        headersheet.Column(4).Width = 12.7;
                        //headersheet.Column(5).Width = 12;
                        headersheet.Column(5).Width = 12.7;
                        //headersheet.Column(6).Width = 8;
                        headersheet.Column(6).Width = 7;
                        //for (int cnt = 7; cnt <= 13; cnt++)
                        //{
                        //    headersheet.Column(cnt).Width = 12;
                        //}
                        headersheet.Column(7).Width = 12.7;
                        headersheet.Column(8).Width = 12.7;
                        headersheet.Column(9).Width = 12.7;
                        headersheet.Column(10).Width = 12.7;
                        headersheet.Column(11).Width = 12.7;
                        headersheet.Column(12).Width = 12.7;
                        headersheet.Column(13).Width = 12.7;

                        headersheet.Column(14).Width = 10.1;

                        // 印刷体裁（B4横、印刷範囲）
                        //headersheet.PageSetup.PaperSize = XLPaperSize.B4Paper;
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
                        headersheet.PageSetup.Margins.Left = 0.2;
                        headersheet.PageSetup.Margins.Right = 0.2;
                        headersheet.PageSetup.Margins.Top = 0.4;
                        headersheet.PageSetup.Margins.Bottom = 0.3;

                        for (int ir = 3; ir < 39; ir++)
                        {
                            headersheet.Row(ir).Height = 13.2;
                        }

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№13）");

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 営業所名出力
                    if (eigyoRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt, 1).Value = drUriage[1];
                    }

                    // グループ名出力
                    if (groupRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt, 2).Value = drUriage[3];

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 14).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        xlsRowCnt++;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 39)
                    {
                        pageCnt++;
                        xlsRowCnt = 5;

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 5; colCnt < maxColCnt; colCnt++)
                    {
                        string str = drUriage[colCnt].ToString();

                        // 金額セルの処理
                        if (colCnt == 6 || colCnt == 7 || colCnt >= 9 && colCnt <= 15)
                        {
                            // 3桁毎に","を挿入する
                            str = string.Format("{0:#,0}", decimal.Parse(str));
                            currentsheet.Cell(xlsRowCnt, colCnt - 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 粗利率、期間達成率セルの処理
                        if (colCnt == 8 || colCnt == 16)
                        {
                            // 3桁毎に","を挿入する、小数点第2位まで
                            currentsheet.Cell(xlsRowCnt, colCnt - 2).Style.NumberFormat.SetFormat("#,##0.00");
                            currentsheet.Cell(xlsRowCnt, colCnt - 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        currentsheet.Cell(xlsRowCnt, colCnt - 2).Value = str;
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 14).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
                    {
                        pageCnt++;
                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // グループ計を出力
                    groupRowCnt++;
                    if (groupGoukei.ElementAt(groupCnt).count == groupRowCnt)
                    {
                        xlsRowCnt++;

                        // セル結合
                        currentsheet.Range(xlsRowCnt, 2, xlsRowCnt, 3).Merge();

                        currentsheet.Cell(xlsRowCnt, 2).Value = "　　　　 ◆グループ計◆";
                        for (int cnt = 0; cnt < 11; cnt++)
                        {
                            // 粗利率の場合
                            if (cnt == 2)
                            {
                                // 売上額が0でない場合
                                if (decKingakuGroup[groupCnt, 0] != 0)
                                {
                                    decKingakuGroup[groupCnt, cnt] = decKingakuGroup[groupCnt, 1] / decKingakuGroup[groupCnt, 0] * 100;
                                }
                                else
                                {
                                    decKingakuGroup[groupCnt, cnt] = 0;
                                }
                                currentsheet.Cell(xlsRowCnt, cnt + 4).Value = decKingakuGroup[groupCnt, cnt].ToString();
                                currentsheet.Cell(xlsRowCnt, cnt + 4).Style.NumberFormat.SetFormat("#,##0.00");
                            }
                            // 期間達成率の場合
                            else if (cnt == 10)
                            {
                                // 年間売上目標が0でない場合
                                if (decKingakuGroup[groupCnt, 9] != 0)
                                {
                                    decKingakuGroup[groupCnt, cnt] = decKingakuGroup[groupCnt, 0] / decKingakuGroup[groupCnt, 9] * 100;
                                }
                                else
                                {
                                    decKingakuGroup[groupCnt, cnt] = 0;
                                }
                                currentsheet.Cell(xlsRowCnt, cnt + 4).Value = decKingakuGroup[groupCnt, cnt].ToString();
                                currentsheet.Cell(xlsRowCnt, cnt + 4).Style.NumberFormat.SetFormat("#,##0.00");
                            }
                            else
                            {
                                currentsheet.Cell(xlsRowCnt, cnt + 4).Value = string.Format("{0:#,0}", decKingakuGroup[groupCnt, cnt]);
                            }
                            currentsheet.Cell(xlsRowCnt, cnt + 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 14).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        groupCnt++;
                        groupRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
                    {
                        pageCnt++;
                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 営業所計を出力
                    eigyoRowCnt++;
                    if (eigyoGoukei.ElementAt(eigyoCnt).count == eigyoRowCnt)
                    {
                        xlsRowCnt++;

                        // セル結合
                        currentsheet.Range(xlsRowCnt, 2, xlsRowCnt, 3).Merge();

                        currentsheet.Cell(xlsRowCnt, 2).Value = "　　　　 ◆営業所計◆";
                        for (int cnt = 0; cnt < 11; cnt++)
                        {
                            // 粗利率の場合
                            if (cnt == 2)
                            {
                                // 売上額が0でない場合
                                if (decKingakuEigyo[eigyoCnt, 0] != 0)
                                {
                                    decKingakuEigyo[eigyoCnt, cnt] = decKingakuEigyo[eigyoCnt, 1] / decKingakuEigyo[eigyoCnt, 0] * 100;
                                }
                                else
                                {
                                    decKingakuEigyo[eigyoCnt, cnt] = 0;
                                }
                                currentsheet.Cell(xlsRowCnt, cnt + 4).Value = decKingakuEigyo[eigyoCnt, cnt].ToString();
                                currentsheet.Cell(xlsRowCnt, cnt + 4).Style.NumberFormat.SetFormat("#,##0.00");
                            }
                            // 期間達成率の場合
                            else if (cnt == 10)
                            {
                                // 年間売上目標が0でない場合
                                if (decKingakuEigyo[eigyoCnt, 9] != 0)
                                {
                                    decKingakuEigyo[eigyoCnt, cnt] = decKingakuEigyo[eigyoCnt, 0] / decKingakuEigyo[eigyoCnt, 9] * 100;
                                }
                                else
                                {
                                    decKingakuEigyo[eigyoCnt, cnt] = 0;
                                }
                                currentsheet.Cell(xlsRowCnt, cnt + 4).Value = decKingakuEigyo[eigyoCnt, cnt].ToString();
                                currentsheet.Cell(xlsRowCnt, cnt + 4).Style.NumberFormat.SetFormat("#,##0.00");
                            }
                            else
                            {
                                currentsheet.Cell(xlsRowCnt, cnt + 4).Value = string.Format("{0:#,0}", decKingakuEigyo[eigyoCnt, cnt]);
                            }
                            currentsheet.Cell(xlsRowCnt, cnt + 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 14).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        eigyoCnt++;
                        eigyoRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
                    {
                        pageCnt++;
                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    rowCnt++;
                    xlsRowCnt++;
                }

                // 最終行を出力した後、合計行を出力
                if (dtChkList.Rows.Count > 0)
                {
                    // セル結合
                    currentsheet.Range(xlsRowCnt, 2, xlsRowCnt, 3).Merge();

                    currentsheet.Cell(xlsRowCnt, 2).Value = "　　　　 ◆総合計◆";
                    for (int cnt = 0; cnt < 11; cnt++)
                    {
                        // 粗利率の場合
                        if (cnt == 2)
                        {
                            // 売上額が0でない場合
                            if (decKingaku[0] != 0)
                            {
                                decKingaku[cnt] = decKingaku[1] / decKingaku[0] * 100;
                            }
                            else
                            {
                                decKingaku[cnt] = 0;
                            }
                            currentsheet.Cell(xlsRowCnt, cnt + 4).Value = decKingaku[cnt].ToString();
                            currentsheet.Cell(xlsRowCnt, cnt + 4).Style.NumberFormat.SetFormat("#,##0.00");
                        }
                        // 期間達成率の場合
                        else if (cnt == 10)
                        {
                            // 年間売上目標が0でない場合
                            if (decKingaku[9] != 0)
                            {
                                decKingaku[cnt] = decKingaku[0] / decKingaku[9] * 100;
                            }
                            else
                            {
                                decKingaku[cnt] = 0;
                            }
                            currentsheet.Cell(xlsRowCnt, cnt + 4).Value = decKingaku[cnt].ToString();
                            currentsheet.Cell(xlsRowCnt, cnt + 4).Style.NumberFormat.SetFormat("#,##0.00");
                        }
                        else
                        {
                            currentsheet.Cell(xlsRowCnt, cnt + 4).Value = string.Format("{0:#,0}", decKingaku[cnt]);
                        }
                        currentsheet.Cell(xlsRowCnt, cnt + 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 14).Style
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
                //return pdf.createPdf(strOutXlsFile, strDateTime, 0);

                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objExcel.Visible = false;

                if (pr != null)
                {
                    objExcel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized;
                }
                else
                {
                    objExcel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized;
                }

                objExcel.DisplayAlerts = false;

                objWorkBooks = objExcel.Workbooks;

                String strP = System.IO.Path.GetFullPath(strOutXlsFile);

                objWorkBook = objWorkBooks.Open(strP, //_xslFile,     // FileName:ファイル名
                                                Type.Missing, // UpdateLinks:ファイル内の外部参照の更新方法
                                                Type.Missing, // ReadOnly:ReadOnlyにするかどうか
                                                Type.Missing, // Format: テキストファイルを開く場合に区切り文字を指定する
                                                Type.Missing, // Password:開く際にパスワードがある場合にパスワードを入力
                                                Type.Missing, // WriteResPassword:書き込む際にパスワードがある場合にパスワードを入力
                                                Type.Missing, // IgnoreReadOnlyRecommended:[読み取り専用を推奨する]チェックがオンの場合でも[読み取り専用を推奨する]メッセージを非表示
                                                Type.Missing, // Origin:テキストファイルの場合、プラットフォームを指定
                                                Type.Missing, // Delimiter:テキストファイルで且つ引数Formatが6の場合に区切り文字を指定
                                                Type.Missing, // Editable:Excel4.0アドインの場合、アドインウィンドウを出すか指定
                                                Type.Missing, // Notify:ファイルが読み取りor書き込みモードで開けない場合に通知リストに追加するか指定
                                                Type.Missing, // Converter:ファイルを開くときに最初に使用するファイルコンバーターのインデックス番号を指定
                                                Type.Missing, // AddToMru:最近使用したファイルの一覧にブックを追加するか指定
                                                Type.Missing, // Local:Excel言語設定に合わせてファイルを保存するか指定
                                                Type.Missing  // CorruptLoad:使用できる定数は[xlNormalLoad][xlRepairFile][xlExtractData]。指定がない場合のは[xlNormalLoad]になりOMを通じて開始するときに回復は行われません。
                                                );

                if (pr != null)
                {
                    for (int ip = 0; ip < num; ip ++) {
                        objWorkBook.PrintOut(Type.Missing, // From:印刷開始のページ番号
                                              Type.Missing, // To:印刷終了のページ番号
                                              1,            // Copies:印刷部数
                                              Type.Missing, // Preview:印刷プレビューをするか指定
                                              pr, // ActivePrinter:プリンターの名称
                                              Type.Missing, // PrintToFile:ファイル出力をするか指定
                                              true,         // Collate:部単位で印刷するか指定
                                              Type.Missing  // PrToFileName	:出力先ファイルの名前を指定するかどうか
                                              );
                    }
                }
                else
                {
                    objWorkBook.PrintOut(Type.Missing, // From:印刷開始のページ番号
                                          Type.Missing, // To:印刷終了のページ番号
                                          1,            // Copies:印刷部数
                                          true, // Preview:印刷プレビューをするか指定
                                          pr, // ActivePrinter:プリンターの名称
                                          Type.Missing, // PrintToFile:ファイル出力をするか指定
                                          true,         // Collate:部単位で印刷するか指定
                                          Type.Missing  // PrToFileName	:出力先ファイルの名前を指定するかどうか
                                          );
                    objExcel.Visible = true;
                    objWorkBook.Activate();

                }

                return "";

            }
            catch
            {
                throw;
            }
            finally
            {
                // EXCEL終了処理
                if (objWorkSheet != null)
                {
                    Marshal.ReleaseComObject(objWorkSheet);     // オブジェクト参照を解放
                    objWorkSheet = null;                        // オブジェクト解放
                }

                if (objWorkBook != null)
                {
                    objWorkBook.Close(false,
                        Type.Missing, Type.Missing);            //ファイルを閉じる
                    Marshal.ReleaseComObject(objWorkBook);      // オブジェクト参照を解放
                    objWorkBook = null;                         // オブジェクト解放
                }

                if (objWorkBooks != null)
                {
                    Marshal.ReleaseComObject(objWorkBooks);     // オブジェクト参照を解放
                    objWorkBooks = null;                        // オブジェクト解放
                }
                if (objExcel != null)
                {
                    objExcel.Quit();                            // EXCELを閉じる

                    Marshal.ReleaseComObject(objExcel);         // オブジェクト参照を解放
                    objExcel = null;                            // オブジェクト解放
                }

                System.GC.Collect();
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
