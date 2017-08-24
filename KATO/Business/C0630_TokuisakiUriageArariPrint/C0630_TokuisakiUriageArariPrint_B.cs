using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;

namespace KATO.Business.C0630_TokuisakiUriageArariPrint
{
    /// <summary>
    /// A0090_SiireCheakPrint_B
    /// 得意先別売上管理表 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/28
    /// 更新者：多田
    /// 更新日：2017/7/28
    /// カラム論理名
    /// </summary>
    class C0630_TokuisakiUriageArariPrint_B
    {
        /// <summary>
        /// getUriage
        /// 得意先別売上管理表_PROCを実行
        /// </summary>
        public DataTable getUriage(List<string> lstDataName)
        {
            DataTable dtRet = new DataTable();

            List<string> lstTableName = new List<string>();
            lstTableName.Add("@開始年月日");
            lstTableName.Add("@終了年月日");
            lstTableName.Add("@開始グループコード");
            lstTableName.Add("@終了グループコード");
            lstTableName.Add("@開始担当者コード");
            lstTableName.Add("@終了担当者コード");
            lstTableName.Add("@開始得意先コード");
            lstTableName.Add("@終了得意先コード");

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 請求明細書_PROCを実行
                dtRet = dbconnective.RunSqlReDT("得意先別売上管理表_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@結果");

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
        public string dbToPdf(DataTable dtUriage, List<string> lstItem)
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
                var outDataAll = dtUriage.AsEnumerable()
                    .Select(dat => new
                    {
                        groupCd = dat["グループコード"],
                        groupName = dat["グループ名"],
                        tantoCd = dat["担当者コード"],
                        tantoName = dat["担当者名"],
                        tokuisakiCd = dat["得意先コード"],
                        tokuisakiName = dat["得意先名"],
                        uriage = (decimal)dat["売上額"],
                        arari = (decimal)dat["粗利額"],
                        arariRitsu = (decimal)dat["粗利率"],
                        getsumatsuUriage = (decimal)dat["月末迄受注残売上"],
                        getsumatsuArari = (decimal)dat["月末迄受注残粗利"],
                        yokugetsuUriage = (decimal)dat["翌月以降受注残売上"],
                        yokugetsuArari = (decimal)dat["翌月以降受注残粗利"],
                        getsumatsuUrikake= (decimal)dat["月末売掛金残"],
                        nyukin = (decimal)dat["当月入金額"]
                    }).ToList();

                // linqで合計算出
                decimal[] decKingaku = new decimal[9];
                decKingaku[0] = outDataAll.Select(gokei => gokei.uriage).Sum();
                decKingaku[1] = outDataAll.Select(gokei => gokei.arari).Sum();
                decKingaku[2] = outDataAll.Select(gokei => gokei.arariRitsu).Sum();
                decKingaku[3] = outDataAll.Select(gokei => gokei.getsumatsuUriage).Sum();
                decKingaku[4] = outDataAll.Select(gokei => gokei.getsumatsuArari).Sum();
                decKingaku[5] = outDataAll.Select(gokei => gokei.yokugetsuUriage).Sum();
                decKingaku[6] = outDataAll.Select(gokei => gokei.yokugetsuArari).Sum();
                decKingaku[7] = outDataAll.Select(gokei => gokei.getsumatsuUrikake).Sum();
                decKingaku[8] = outDataAll.Select(gokei => gokei.nyukin).Sum();

                // 担当者計
                var tantoGoukei = from tbl in dtUriage.AsEnumerable()
                                  group tbl by tbl.Field<string>("担当者コード") into g
                                  select new
                                  {
                                      section = g.Key,
                                      count = g.Count(),
                                      uriage = g.Sum(p => p.Field<decimal>("売上額")),
                                      arari = g.Sum(p => p.Field<decimal>("粗利額")),
                                      arariRitsu = g.Sum(p => p.Field<decimal>("粗利率")),
                                      getsumatsuUriage = g.Sum(p => p.Field<decimal>("月末迄受注残売上")),
                                      getsumatsuArari = g.Sum(p => p.Field<decimal>("月末迄受注残粗利")),
                                      yokugetsuUriage = g.Sum(p => p.Field<decimal>("翌月以降受注残売上")),
                                      yokugetsuArari = g.Sum(p => p.Field<decimal>("翌月以降受注残粗利")),
                                      getsumatsuUrikake = g.Sum(p => p.Field<decimal>("月末売掛金残")),
                                      nyukin = g.Sum(p => p.Field<decimal>("当月入金額"))
                                  };

                // 担当者計の合計算出
                decimal[,] decKingakuTanto = new decimal[tantoGoukei.Count(), 9];
                for (int cnt = 0; cnt < tantoGoukei.Count(); cnt++)
                {
                    decKingakuTanto[cnt, 0] = tantoGoukei.ElementAt(cnt).uriage;
                    decKingakuTanto[cnt, 1] = tantoGoukei.ElementAt(cnt).arari;
                    decKingakuTanto[cnt, 2] = tantoGoukei.ElementAt(cnt).arariRitsu;
                    decKingakuTanto[cnt, 3] = tantoGoukei.ElementAt(cnt).getsumatsuUriage;
                    decKingakuTanto[cnt, 4] = tantoGoukei.ElementAt(cnt).getsumatsuArari;
                    decKingakuTanto[cnt, 5] = tantoGoukei.ElementAt(cnt).yokugetsuUriage;
                    decKingakuTanto[cnt, 6] = tantoGoukei.ElementAt(cnt).yokugetsuArari;
                    decKingakuTanto[cnt, 7] = tantoGoukei.ElementAt(cnt).getsumatsuUrikake;
                    decKingakuTanto[cnt, 8] = tantoGoukei.ElementAt(cnt).nyukin;
                }

                // グループ計
                var groupGoukei = from tbl in dtUriage.AsEnumerable()
                                  group tbl by tbl.Field<string>("グループコード") into g
                                  select new
                                  {
                                      section = g.Key,
                                      count = g.Count(),
                                      uriage = g.Sum(p => p.Field<decimal>("売上額")),
                                      arari = g.Sum(p => p.Field<decimal>("粗利額")),
                                      arariRitsu = g.Sum(p => p.Field<decimal>("粗利率")),
                                      getsumatsuUriage = g.Sum(p => p.Field<decimal>("月末迄受注残売上")),
                                      getsumatsuArari = g.Sum(p => p.Field<decimal>("月末迄受注残粗利")),
                                      yokugetsuUriage = g.Sum(p => p.Field<decimal>("翌月以降受注残売上")),
                                      yokugetsuArari = g.Sum(p => p.Field<decimal>("翌月以降受注残粗利")),
                                      getsumatsuUrikake = g.Sum(p => p.Field<decimal>("月末売掛金残")),
                                      nyukin = g.Sum(p => p.Field<decimal>("当月入金額"))
                                  };

                // グループ計の合計算出
                decimal[,] decKingakuGroup = new decimal[groupGoukei.Count(), 9];
                for (int cnt = 0; cnt < groupGoukei.Count(); cnt++)
                {
                    decKingakuGroup[cnt, 0] = groupGoukei.ElementAt(cnt).uriage;
                    decKingakuGroup[cnt, 1] = groupGoukei.ElementAt(cnt).arari;
                    decKingakuGroup[cnt, 2] = groupGoukei.ElementAt(cnt).arariRitsu;
                    decKingakuGroup[cnt, 3] = groupGoukei.ElementAt(cnt).getsumatsuUriage;
                    decKingakuGroup[cnt, 4] = groupGoukei.ElementAt(cnt).getsumatsuArari;
                    decKingakuGroup[cnt, 5] = groupGoukei.ElementAt(cnt).yokugetsuUriage;
                    decKingakuGroup[cnt, 6] = groupGoukei.ElementAt(cnt).yokugetsuArari;
                    decKingakuGroup[cnt, 7] = groupGoukei.ElementAt(cnt).getsumatsuUrikake;
                    decKingakuGroup[cnt, 8] = groupGoukei.ElementAt(cnt).nyukin;
                }

                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxColCnt = dtChkList.Columns.Count;
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 5;  // Excel出力行カウント（開始は出力行）

                int tantoCnt = 0;
                int tantoRowCnt = 0;
                int groupCnt = 0;
                int groupRowCnt = 0;

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drUriage in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "得意先別売上管理表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "M1").Merge();

                        // 開始年月日、終了年月日出力（A3のセル）
                        IXLCell unitCell = headersheet.Cell("A3");
                        unitCell.Value = "期間：：" +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[0])) + "～" +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[1]));
                        unitCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("H3").Value = "指定期間内受注残";
                        headersheet.Range("H3", "I3").Merge();
                        headersheet.Cell("J3").Value = "指定期間以降受注残";
                        headersheet.Range("J3", "K3").Merge();

                        // ヘッダー出力（4行目のセル）
                        headersheet.Cell("A4").Value = "グループ名";
                        headersheet.Cell("B4").Value = "担当者名";
                        headersheet.Cell("C4").Value = "コード";
                        headersheet.Cell("D4").Value = "得意先名";
                        headersheet.Cell("E4").Value = "売上額";
                        headersheet.Cell("F4").Value = "粗利額";
                        headersheet.Cell("G4").Value = "粗利率";
                        headersheet.Cell("H4").Value = "金　額";
                        headersheet.Cell("I4").Value = "粗　利";
                        headersheet.Cell("J4").Value = "金　額";
                        headersheet.Cell("K4").Value = "粗　利";
                        headersheet.Cell("L4").Value = "月末売掛金残";
                        headersheet.Cell("M4").Value = "当月入金額";

                        // ヘッダー列
                        headersheet.Range("H3", "K3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        headersheet.Range("A4", "M4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("H3", "K3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);
                        headersheet.Range("A4", "M4").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("H3", "K3").Style.Fill.BackgroundColor = XLColor.LightGray;
                        headersheet.Range("A4", "M4").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 10;
                        headersheet.Column(2).Width = 10;
                        headersheet.Column(3).Width = 5;
                        headersheet.Column(4).Width = 30;
                        headersheet.Column(5).Width = 12;
                        headersheet.Column(6).Width = 12;
                        headersheet.Column(7).Width = 8;
                        for (int cnt = 8; cnt <= 13; cnt++)
                        {
                            headersheet.Column(cnt).Width = 12;
                        }

                        // 印刷体裁（B4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.B4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№63）");
                    }

                    // グループ名出力
                    if (groupRowCnt == 0)
                    {
                        xlsRowCnt = 5;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);

                        currentsheet.Cell(xlsRowCnt, 1).Value = drUriage[1];
                    }

                    // 担当者名出力
                    if (tantoRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt, 2).Value = drUriage[3];

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        xlsRowCnt++;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 39)
                    {
                        xlsRowCnt = 5;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 4; colCnt < maxColCnt; colCnt++)
                    {
                        string str = drUriage[colCnt].ToString();

                        // 金額セルの処理
                        if (colCnt == 6 || colCnt == 7 || colCnt >= 9 && colCnt <= 14)
                        {
                            // 3桁毎に","を挿入する
                            str = string.Format("{0:#,0}", decimal.Parse(str));
                            currentsheet.Cell(xlsRowCnt, colCnt - 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 粗利率セルの処理
                        if (colCnt == 8)
                        {
                            // 3桁毎に","を挿入する、小数点第2位まで
                            currentsheet.Cell(xlsRowCnt, colCnt - 1).Style.NumberFormat.SetFormat("#,##0.00");
                            currentsheet.Cell(xlsRowCnt, colCnt - 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        currentsheet.Cell(xlsRowCnt, colCnt - 1).Value = str;
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
                    {
                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
                    }

                    // 担当者計を出力
                    tantoRowCnt++;
                    if (tantoGoukei.ElementAt(tantoCnt).count == tantoRowCnt)
                    {
                        xlsRowCnt++;

                        // セル結合
                        currentsheet.Range(xlsRowCnt, 2, xlsRowCnt, 3).Merge();

                        currentsheet.Cell(xlsRowCnt, 4).Value = "◆担当者計◆";
                        for (int cnt = 0; cnt < 9; cnt++)
                        {
                            // 粗利率の場合
                            if (cnt == 2)
                            {
                                // 売上額が0でない場合
                                if (decKingakuTanto[tantoCnt, 0] != 0)
                                {
                                    decKingakuTanto[tantoCnt, cnt] = decKingakuTanto[tantoCnt, 1] / decKingakuTanto[tantoCnt, 0] * 100;
                                }
                                else
                                {
                                    decKingakuTanto[tantoCnt, cnt] = 0;
                                }
                                currentsheet.Cell(xlsRowCnt, cnt + 5).Value = decKingakuTanto[tantoCnt, cnt].ToString();
                                currentsheet.Cell(xlsRowCnt, cnt + 5).Style.NumberFormat.SetFormat("#,##0.00");
                            }
                            else
                            {
                                currentsheet.Cell(xlsRowCnt, cnt + 5).Value = string.Format("{0:#,0}", decKingakuTanto[tantoCnt, cnt]);
                            }
                            currentsheet.Cell(xlsRowCnt, cnt + 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        tantoCnt++;
                        tantoRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
                    {
                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
                    }

                    // グループ計を出力
                    groupRowCnt++;
                    if (groupGoukei.ElementAt(groupCnt).count == groupRowCnt)
                    {
                        xlsRowCnt++;

                        // セル結合
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 3).Merge();

                        currentsheet.Cell(xlsRowCnt, 4).Value = "◆グループ計◆";
                        for (int cnt = 0; cnt < 9; cnt++)
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
                                currentsheet.Cell(xlsRowCnt, cnt + 5).Value = decKingakuGroup[groupCnt, cnt].ToString();
                                currentsheet.Cell(xlsRowCnt, cnt + 5).Style.NumberFormat.SetFormat("#,##0.00");
                            }
                            else
                            {
                                currentsheet.Cell(xlsRowCnt, cnt + 5).Value = string.Format("{0:#,0}", decKingakuGroup[groupCnt, cnt]);
                            }
                            currentsheet.Cell(xlsRowCnt, cnt + 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
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
                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
                    }

                    rowCnt++;
                    xlsRowCnt++;
                }

                // 最終行を出力した後、合計行を出力
                if (dtChkList.Rows.Count > 0)
                {
                    // セル結合
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 3).Merge();

                    currentsheet.Cell(xlsRowCnt, 4).Value = "◆総合計◆";
                    for (int cnt = 0; cnt < 9; cnt++)
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
                            currentsheet.Cell(xlsRowCnt, cnt + 5).Value = decKingaku[cnt].ToString();
                            currentsheet.Cell(xlsRowCnt, cnt + 5).Style.NumberFormat.SetFormat("#,##0.00");
                        }
                        else
                        {
                            currentsheet.Cell(xlsRowCnt, cnt + 5).Value = string.Format("{0:#,0}", decKingaku[cnt]);
                        }
                        currentsheet.Cell(xlsRowCnt, cnt + 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);
                }

                // ヘッダーシート削除
                headersheet.Delete();

                // 各ページのヘッダー部を指定
                int maxPage = workbook.Worksheets.Count;
                for (int pageCnt = 1; pageCnt <= maxPage; pageCnt++)
                {
                    // ヘッダー部に指定する情報を取得
                    string strHeader = pdf.getHeader(pageCnt, maxPage, strNow);

                    // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
                    workbook.Worksheet(pageCnt).PageSetup.Header.Right.AddText(strHeader);
                }

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // PDF化の処理
                return pdf.createPdf(strOutXlsFile, strDateTime, 0);

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
