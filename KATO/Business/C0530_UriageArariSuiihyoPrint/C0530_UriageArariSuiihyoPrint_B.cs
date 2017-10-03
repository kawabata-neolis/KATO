using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;

namespace KATO.Business.C0530_UriageArariSuiihyoPrint
{
    /// <summary>
    /// A0090_SiireCheakPrint_B
    /// 得意先別売上粗利推移表 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/20
    /// 更新者：多田
    /// 更新日：2017/7/20
    /// カラム論理名
    /// </summary>
    class C0530_UriageArariSuiihyoPrint_B
    {
        /// <summary>
        /// getKikanDate
        /// 仕入チェックリストを取得
        /// </summary>
        public DataTable getKikanDate()
        {
            DataTable dtKikanDate = new DataTable();

            string strSql = "SELECT 開始年月日, 終了年月日 FROM 会社処理条件 WHERE 会社コード='01' AND 削除='N'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtKikanDate = dbconnective.ReadSql(strSql);

                return dtKikanDate;
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
        /// getSuiihyo
        /// 推移表を取得
        /// </summary>
        public DataTable getSuiihyo(List<string> lstItem)
        {
            string strSql;
            string strGroup = "";
            DataTable dtKikanDate = new DataTable();

            // グループ
            int intGroup = int.Parse(lstItem[6]);
            if (intGroup != CommonTeisu.GROUP_RADIO_ALL)
            {
                strGroup = CommonTeisu.LIST_GROUP[intGroup];
            }

            // 出力先の選択が得意先別売上推移表の場合
            if (lstItem[7].Equals("0"))
            {
                strSql = "得意先別売上推移表_PROC '" + lstItem[0] + "', '" + lstItem[2] + "', '" +
                    lstItem[3] + "', '" + lstItem[4] + "', '" + lstItem[5] + "', '" + strGroup + "'";
            }
            else
            {
                strSql = "得意先別粗利推移表_PROC '" + lstItem[0] + "', '" + lstItem[2] + "', '" +
                    lstItem[3] + "', '" + lstItem[4] + "', '" + lstItem[5] + "', '" + strGroup + "'";
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtKikanDate = dbconnective.ReadSql(strSql);

                return dtKikanDate;
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
        /// <param name="lstDtSuiihyo">
        ///     推移表のデータテーブルのリスト</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(List<DataTable> lstDtSuiihyo, List<string> lstItem)
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

                int maxPage;    // 最大ページ数

                // リストに格納しているデータテーブルすべてを実行
                for (int listCnt = 0; listCnt < lstDtSuiihyo.Count; listCnt++)
                {
                    DataTable dtSuiihyo = lstDtSuiihyo[listCnt];

                    if (dtSuiihyo == null || dtSuiihyo.Rows.Count == 0)
                    {
                        break;
                    }

                    //Linqで必要なデータをselect
                    var outDataAll = dtSuiihyo.AsEnumerable()
                        .Select(dat => new
                        {
                            tantoCd = dat["担当者コード"],
                            tantoName = dat["担当者名"],
                            tokuisakiCd = dat["得意先コード"],
                            tokuisakiName = dat["得意先名"],
                            zenUriage1 = (decimal)dat["前売上１"],
                            zenUriage2 = (decimal)dat["前売上２"],
                            zenUriage3 = (decimal)dat["前売上３"],
                            zenUriage4 = (decimal)dat["前売上４"],
                            zenUriage5 = (decimal)dat["前売上５"],
                            zenUriage6 = (decimal)dat["前売上６"],
                            zenUriage7 = (decimal)dat["前売上７"],
                            zenUriage8 = (decimal)dat["前売上８"],
                            zenUriage9 = (decimal)dat["前売上９"],
                            zenUriage10 = (decimal)dat["前売上１０"],
                            zenUriage11 = (decimal)dat["前売上１１"],
                            zenUriage12 = (decimal)dat["前売上１２"],
                            zenUriageGoukei = (decimal)dat["前売上合計"],
                            honUriage1 = (decimal)dat["本売上１"],
                            honUriage2 = (decimal)dat["本売上２"],
                            honUriage3 = (decimal)dat["本売上３"],
                            honUriage4 = (decimal)dat["本売上４"],
                            honUriage5 = (decimal)dat["本売上５"],
                            honUriage6 = (decimal)dat["本売上６"],
                            honUriage7 = (decimal)dat["本売上７"],
                            honUriage8 = (decimal)dat["本売上８"],
                            honUriage9 = (decimal)dat["本売上９"],
                            honUriage10 = (decimal)dat["本売上１０"],
                            honUriage11 = (decimal)dat["本売上１１"],
                            honUriage12 = (decimal)dat["本売上１２"],
                            honUriageGoukei = (decimal)dat["本売上合計"]
                        }).ToList();

                    // linqで前売上１～前売上１２、前売上合計、本売上１～本売上１２、本売上合計の合計算出
                    decimal[,] decKingaku = new decimal[2, 13];
                    decKingaku[0, 0] = outDataAll.Select(gokei => gokei.zenUriage1).Sum();
                    decKingaku[0, 1] = outDataAll.Select(gokei => gokei.zenUriage2).Sum();
                    decKingaku[0, 2] = outDataAll.Select(gokei => gokei.zenUriage3).Sum();
                    decKingaku[0, 3] = outDataAll.Select(gokei => gokei.zenUriage4).Sum();
                    decKingaku[0, 4] = outDataAll.Select(gokei => gokei.zenUriage5).Sum();
                    decKingaku[0, 5] = outDataAll.Select(gokei => gokei.zenUriage6).Sum();
                    decKingaku[0, 6] = outDataAll.Select(gokei => gokei.zenUriage7).Sum();
                    decKingaku[0, 7] = outDataAll.Select(gokei => gokei.zenUriage8).Sum();
                    decKingaku[0, 8] = outDataAll.Select(gokei => gokei.zenUriage9).Sum();
                    decKingaku[0, 9] = outDataAll.Select(gokei => gokei.zenUriage10).Sum();
                    decKingaku[0, 10] = outDataAll.Select(gokei => gokei.zenUriage11).Sum();
                    decKingaku[0, 11] = outDataAll.Select(gokei => gokei.zenUriage12).Sum();
                    decKingaku[0, 12] = outDataAll.Select(gokei => gokei.zenUriageGoukei).Sum();
                    decKingaku[1, 0] = outDataAll.Select(gokei => gokei.honUriage1).Sum();
                    decKingaku[1, 1] = outDataAll.Select(gokei => gokei.honUriage2).Sum();
                    decKingaku[1, 2] = outDataAll.Select(gokei => gokei.honUriage3).Sum();
                    decKingaku[1, 3] = outDataAll.Select(gokei => gokei.honUriage4).Sum();
                    decKingaku[1, 4] = outDataAll.Select(gokei => gokei.honUriage5).Sum();
                    decKingaku[1, 5] = outDataAll.Select(gokei => gokei.honUriage6).Sum();
                    decKingaku[1, 6] = outDataAll.Select(gokei => gokei.honUriage7).Sum();
                    decKingaku[1, 7] = outDataAll.Select(gokei => gokei.honUriage8).Sum();
                    decKingaku[1, 8] = outDataAll.Select(gokei => gokei.honUriage9).Sum();
                    decKingaku[1, 9] = outDataAll.Select(gokei => gokei.honUriage10).Sum();
                    decKingaku[1, 10] = outDataAll.Select(gokei => gokei.honUriage11).Sum();
                    decKingaku[1, 11] = outDataAll.Select(gokei => gokei.honUriage12).Sum();
                    decKingaku[1, 12] = outDataAll.Select(gokei => gokei.honUriageGoukei).Sum();

                    // 担当者計
                    var tantoGoukei = from tbl in dtSuiihyo.AsEnumerable()
                                      group tbl by tbl.Field<string>("担当者コード") into g
                                      select new
                                      {
                                          section = g.Key,
                                          count = g.Count(),
                                          zenUriage1 = g.Sum(p => p.Field<decimal>("前売上１")),
                                          zenUriage2 = g.Sum(p => p.Field<decimal>("前売上２")),
                                          zenUriage3 = g.Sum(p => p.Field<decimal>("前売上３")),
                                          zenUriage4 = g.Sum(p => p.Field<decimal>("前売上４")),
                                          zenUriage5 = g.Sum(p => p.Field<decimal>("前売上５")),
                                          zenUriage6 = g.Sum(p => p.Field<decimal>("前売上６")),
                                          zenUriage7 = g.Sum(p => p.Field<decimal>("前売上７")),
                                          zenUriage8 = g.Sum(p => p.Field<decimal>("前売上８")),
                                          zenUriage9 = g.Sum(p => p.Field<decimal>("前売上９")),
                                          zenUriage10 = g.Sum(p => p.Field<decimal>("前売上１０")),
                                          zenUriage11 = g.Sum(p => p.Field<decimal>("前売上１１")),
                                          zenUriage12 = g.Sum(p => p.Field<decimal>("前売上１２")),
                                          zenUriageGoukei = g.Sum(p => p.Field<decimal>("前売上合計")),
                                          honUriage1 = g.Sum(p => p.Field<decimal>("本売上１")),
                                          honUriage2 = g.Sum(p => p.Field<decimal>("本売上２")),
                                          honUriage3 = g.Sum(p => p.Field<decimal>("本売上３")),
                                          honUriage4 = g.Sum(p => p.Field<decimal>("本売上４")),
                                          honUriage5 = g.Sum(p => p.Field<decimal>("本売上５")),
                                          honUriage6 = g.Sum(p => p.Field<decimal>("本売上６")),
                                          honUriage7 = g.Sum(p => p.Field<decimal>("本売上７")),
                                          honUriage8 = g.Sum(p => p.Field<decimal>("本売上８")),
                                          honUriage9 = g.Sum(p => p.Field<decimal>("本売上９")),
                                          honUriage10 = g.Sum(p => p.Field<decimal>("本売上１０")),
                                          honUriage11 = g.Sum(p => p.Field<decimal>("本売上１１")),
                                          honUriage12 = g.Sum(p => p.Field<decimal>("本売上１２")),
                                          honUriageGoukei = g.Sum(p => p.Field<decimal>("本売上合計"))
                                      };

                    // 担当者計の前売上１～前売上１２、前売上合計、本売上１～本売上１２、本売上合計の合計算出
                    decimal[,,] decKingakuTanto = new decimal[tantoGoukei.Count(), 2, 13];
                    for (int cnt = 0; cnt < tantoGoukei.Count(); cnt++)
                    {
                        decKingakuTanto[cnt, 0, 0] = tantoGoukei.ElementAt(cnt).zenUriage1;
                        decKingakuTanto[cnt, 0, 1] = tantoGoukei.ElementAt(cnt).zenUriage2;
                        decKingakuTanto[cnt, 0, 2] = tantoGoukei.ElementAt(cnt).zenUriage3;
                        decKingakuTanto[cnt, 0, 3] = tantoGoukei.ElementAt(cnt).zenUriage4;
                        decKingakuTanto[cnt, 0, 4] = tantoGoukei.ElementAt(cnt).zenUriage5;
                        decKingakuTanto[cnt, 0, 5] = tantoGoukei.ElementAt(cnt).zenUriage6;
                        decKingakuTanto[cnt, 0, 6] = tantoGoukei.ElementAt(cnt).zenUriage7;
                        decKingakuTanto[cnt, 0, 7] = tantoGoukei.ElementAt(cnt).zenUriage8;
                        decKingakuTanto[cnt, 0, 8] = tantoGoukei.ElementAt(cnt).zenUriage9;
                        decKingakuTanto[cnt, 0, 9] = tantoGoukei.ElementAt(cnt).zenUriage10;
                        decKingakuTanto[cnt, 0, 10] = tantoGoukei.ElementAt(cnt).zenUriage11;
                        decKingakuTanto[cnt, 0, 11] = tantoGoukei.ElementAt(cnt).zenUriage12;
                        decKingakuTanto[cnt, 0, 12] = tantoGoukei.ElementAt(cnt).zenUriageGoukei;
                        decKingakuTanto[cnt, 1, 0] = tantoGoukei.ElementAt(cnt).honUriage1;
                        decKingakuTanto[cnt, 1, 1] = tantoGoukei.ElementAt(cnt).honUriage2;
                        decKingakuTanto[cnt, 1, 2] = tantoGoukei.ElementAt(cnt).honUriage3;
                        decKingakuTanto[cnt, 1, 3] = tantoGoukei.ElementAt(cnt).honUriage4;
                        decKingakuTanto[cnt, 1, 4] = tantoGoukei.ElementAt(cnt).honUriage5;
                        decKingakuTanto[cnt, 1, 5] = tantoGoukei.ElementAt(cnt).honUriage6;
                        decKingakuTanto[cnt, 1, 6] = tantoGoukei.ElementAt(cnt).honUriage7;
                        decKingakuTanto[cnt, 1, 7] = tantoGoukei.ElementAt(cnt).honUriage8;
                        decKingakuTanto[cnt, 1, 8] = tantoGoukei.ElementAt(cnt).honUriage9;
                        decKingakuTanto[cnt, 1, 9] = tantoGoukei.ElementAt(cnt).honUriage10;
                        decKingakuTanto[cnt, 1, 10] = tantoGoukei.ElementAt(cnt).honUriage11;
                        decKingakuTanto[cnt, 1, 11] = tantoGoukei.ElementAt(cnt).honUriage12;
                        decKingakuTanto[cnt, 1, 12] = tantoGoukei.ElementAt(cnt).honUriageGoukei;
                    }

                    // リストをデータテーブルに変換
                    DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                    int maxRowCnt = (dtChkList.Rows.Count + tantoGoukei.Count() + 1) * 3;
                    int maxColCnt = dtChkList.Columns.Count;
                    int pageCnt = 0;    // ページ(シート枚数)カウント
                    int rowCnt = 1;     // datatable処理行カウント
                    int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                    maxPage = 0;    // 最大ページ数

                    // ページ数計算
                    double page = 1.0 * maxRowCnt / 33;
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

                    // 期間の月数を計算
                    int intMonthFrom = int.Parse(lstItem[0].Substring(5, 2));
                    int intMonthTo = int.Parse(lstItem[1].Substring(5, 2));
                    if (intMonthFrom > intMonthTo)
                    {
                        intMonthTo += 12;
                    }
                    int intMonthDiff = intMonthTo - intMonthFrom;

                    Boolean blnDiff = false;

                    // 最後のリストに格納されているデータテーブルの場合、かつ、期間の開始から終了までの差が11カ月未満の場合
                    if (listCnt + 1 == lstDtSuiihyo.Count && intMonthDiff < 11)
                    {
                        blnDiff = true;
                    }

                    if (blnDiff)
                    {
                        // 担当者計の処理
                        for (int cnt = 0; cnt < tantoGoukei.Count(); cnt++)
                        {
                            decKingakuTanto[cnt, 0, 12] = 0;
                            decKingakuTanto[cnt, 1, 12] = 0;
                            for (int column = 0; column < 12; column++)
                            {
                                // 期間終了月の翌月以降の場合、0をセット
                                if (intMonthDiff < column)
                                {
                                    decKingakuTanto[cnt, 0, column] = 0;
                                    decKingakuTanto[cnt, 1, column] = 0;
                                }
                                else
                                {
                                    decKingakuTanto[cnt, 0, 12] += decKingakuTanto[cnt, 0, column];
                                    decKingakuTanto[cnt, 1, 12] += decKingakuTanto[cnt, 1, column];
                                }
                            }
                        }

                        // 合計の処理
                        decKingaku[0, 12] = 0;
                        decKingaku[1, 12] = 0;
                        for (int column = 0; column < 12; column++)
                        {
                            // 期間終了月の翌月以降の場合、0をセット
                            if (intMonthDiff < column)
                            {
                                decKingaku[0, column] = 0;
                                decKingaku[1, column] = 0;
                            }
                            else
                            {
                                decKingaku[0, 12] += decKingaku[0, column];
                                decKingaku[1, 12] += decKingaku[1, column];
                            }
                        }
                    }

                    int tantoCnt = 0;
                    int tantoRowCnt = 0;

                    // ClosedXMLで1行ずつExcelに出力
                    foreach (DataRow drSuiihyo in dtChkList.Rows)
                    {
                        // 1ページ目のシート作成
                        if (rowCnt == 1)
                        {
                            DateTime dtYmdFrom = DateTime.Parse(lstItem[0]);
                            pageCnt++;

                            // Headerページのみの場合
                            if (workbook.Worksheets.Count == 1)
                            {
                                // タイトル出力（中央揃え、セル結合）
                                IXLCell titleCell = headersheet.Cell("A1");

                                // 出力先の選択が得意先別売上推移表の場合
                                if (lstItem[7].Equals("0"))
                                {
                                    titleCell.Value = "得意先別売上推移表";
                                }
                                else
                                {
                                    titleCell.Value = "得意先別粗利推移表";
                                }
                                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                titleCell.Style.Font.FontSize = 14;
                                headersheet.Range("A1", "P1").Merge();

                                // 単位出力（P2のセル、右揃え）
                                IXLCell unitCell = headersheet.Cell("P2");
                                unitCell.Value = "（単位：千円）";
                                unitCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                                // ヘッダー出力（3行目のセル）
                                headersheet.Cell("A3").Value = "コード";
                                headersheet.Cell("B3").Value = "得意先名";
                                headersheet.Range("B3", "C3").Merge();
                                headersheet.Cell("D3").Value = dtYmdFrom.AddMonths(0);
                                headersheet.Cell("E3").Value = dtYmdFrom.AddMonths(1);
                                headersheet.Cell("F3").Value = dtYmdFrom.AddMonths(2);
                                headersheet.Cell("G3").Value = dtYmdFrom.AddMonths(3);
                                headersheet.Cell("H3").Value = dtYmdFrom.AddMonths(4);
                                headersheet.Cell("I3").Value = dtYmdFrom.AddMonths(5);
                                headersheet.Cell("J3").Value = dtYmdFrom.AddMonths(6);
                                headersheet.Cell("K3").Value = dtYmdFrom.AddMonths(7);
                                headersheet.Cell("L3").Value = dtYmdFrom.AddMonths(8);
                                headersheet.Cell("M3").Value = dtYmdFrom.AddMonths(9);
                                headersheet.Cell("N3").Value = dtYmdFrom.AddMonths(10);
                                headersheet.Cell("O3").Value = dtYmdFrom.AddMonths(11);
                                headersheet.Cell("P3").Value = "合計";

                                // 各月
                                headersheet.Cell("D3").Style.DateFormat.Format = "yyyy年M月";
                                headersheet.Range("E3", "O3").Style.DateFormat.Format = "M月";

                                // ヘッダー列
                                headersheet.Range("A3", "P3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                                // セルの周囲に罫線を引く
                                headersheet.Range("A3", "P3").Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                                // 列幅の指定
                                headersheet.Column(1).Width = 6;
                                headersheet.Column(2).Width = 28;
                                headersheet.Column(3).Width = 6;
                                for (int cnt = 4; cnt < 15; cnt++)
                                {
                                    headersheet.Column(cnt).Width = 9;
                                }
                                headersheet.Column(16).Width = 10;

                                // 印刷体裁（B4横、印刷範囲）
                                headersheet.PageSetup.PaperSize = XLPaperSize.B4Paper;
                                headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                                // ヘッダー部の指定（番号）
                                headersheet.PageSetup.Header.Left.AddText("（№53）");

                                // ヘッダーシートのコピー
                                pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
                            }
                            else
                            {
                                // 開始年を変更
                                dtYmdFrom = DateTime.Parse(lstItem[0]);
                                headersheet.Cell("D3").Value = dtYmdFrom.AddYears(listCnt);

                                // ヘッダーシートのコピー
                                pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
                            }

                        }

                        // 得意先コードを出力
                        currentsheet.Cell(xlsRowCnt, 1).Value = drSuiihyo[2].ToString();
                        currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;

                        // 得意先名を出力
                        currentsheet.Cell(xlsRowCnt, 2).Value = drSuiihyo[3].ToString();
                        currentsheet.Cell(xlsRowCnt, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                        currentsheet.Cell(xlsRowCnt, 2).Style.Alignment.WrapText = true;

                        // セルの結合
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt + 2, 1).Merge();
                        currentsheet.Range(xlsRowCnt, 2, xlsRowCnt + 2, 2).Merge();

                        // 行タイトル（前年、本年、達成率）を出力
                        currentsheet.Cell(xlsRowCnt, 3).Value = "前年";
                        currentsheet.Cell(xlsRowCnt + 1, 3).Value = "本年";
                        currentsheet.Cell(xlsRowCnt + 2, 3).Value = "達成率";

                        // 期間の開始から終了までの差が11カ月未満の場合
                        if (blnDiff)
                        {
                            drSuiihyo[16] = 0;
                            drSuiihyo[29] = 0;
                        }

                        // 1セルずつデータ出力
                        for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                        {
                            string str = drSuiihyo[colCnt - 1].ToString();

                            // 前売上１～１２セルの処理
                            if (colCnt >= 5 && colCnt <= 16)
                            {
                                // 3桁毎に","を挿入する
                                currentsheet.Cell(xlsRowCnt, colCnt - 1).Style.NumberFormat.SetFormat("#,##0");
                                currentsheet.Cell(xlsRowCnt, colCnt - 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                                // 期間終了月の翌月以降の場合、0をセット
                                if (blnDiff && intMonthDiff < (colCnt - 5))
                                {
                                    currentsheet.Cell(xlsRowCnt, colCnt - 1).Value = 0;
                                }
                                else
                                {
                                    currentsheet.Cell(xlsRowCnt, colCnt - 1).Value = str;

                                    // 期間の開始から終了までの差が11カ月未満の場合
                                    if (blnDiff)
                                    {
                                        drSuiihyo[16] = (decimal)drSuiihyo[16] + (decimal)drSuiihyo[colCnt - 1];
                                    }
                                }
                            }

                            // 前売上合計セルの処理
                            if (colCnt == 17)
                            {
                                // 3桁毎に","を挿入する
                                currentsheet.Cell(xlsRowCnt, colCnt - 1).Style.NumberFormat.SetFormat("#,##0");
                                currentsheet.Cell(xlsRowCnt, colCnt - 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                currentsheet.Cell(xlsRowCnt, colCnt - 1).Value = str;
                            }

                            // 本売上１～１２セルの処理
                            if (colCnt >= 18 && colCnt <= 29)
                            {
                                // 3桁毎に","を挿入する
                                currentsheet.Cell(xlsRowCnt + 1, colCnt - 14).Style.NumberFormat.SetFormat("#,##0");
                                currentsheet.Cell(xlsRowCnt + 1, colCnt - 14).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                                // 期間終了月の翌月以降の場合、0をセット
                                if (blnDiff && intMonthDiff < (colCnt - 18))
                                {
                                    currentsheet.Cell(xlsRowCnt + 1, colCnt - 14).Value = 0;
                                }
                                else
                                {
                                    currentsheet.Cell(xlsRowCnt + 1, colCnt - 14).Value = str;

                                    // 期間の開始から終了までの差が11カ月未満の場合
                                    if (blnDiff)
                                    {
                                        drSuiihyo[29] = (decimal)drSuiihyo[29] + (decimal)drSuiihyo[colCnt - 1];
                                    }
                                }
                            }

                            // 本売上合計セルの処理
                            if (colCnt == 30)
                            {
                                // 3桁毎に","を挿入する
                                currentsheet.Cell(xlsRowCnt + 1, colCnt - 14).Style.NumberFormat.SetFormat("#,##0");
                                currentsheet.Cell(xlsRowCnt + 1, colCnt - 14).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                currentsheet.Cell(xlsRowCnt + 1, colCnt - 14).Value = str;
                            }
                        }

                        // 達成率の計算、出力
                        for (int column = 0; column < 12; column++)
                        {
                            decimal decZennen = 0;
                            decimal decHonnen = 0;
                            double dblRitsu;

                            for (int cnt = 0; cnt <= column; cnt++)
                            {
                                // 期間の開始から終了までの差が11カ月未満でない場合、or
                                // 期間の開始から終了までの差が11カ月未満の場合、かつ、月数の差が列数以下の場合
                                if (!blnDiff || blnDiff && intMonthDiff >= column)
                                {
                                    decZennen += decimal.Parse(drSuiihyo[cnt + 4].ToString());
                                    decHonnen += decimal.Parse(drSuiihyo[cnt + 17].ToString());
                                }
                            }

                            if (decZennen == 0 || decHonnen == 0)
                            {
                                dblRitsu = 0;
                            }
                            else
                            {
                                dblRitsu = ((double)decHonnen / (double)decZennen) * 100;
                            }

                            // 3桁毎に","を挿入する、小数点第2位まで
                            currentsheet.Cell(xlsRowCnt + 2, column + 4).Style.NumberFormat.SetFormat("#,##0.00");
                            currentsheet.Cell(xlsRowCnt + 2, column + 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            currentsheet.Cell(xlsRowCnt + 2, column + 4).Value = dblRitsu.ToString();
                        }

                        // 達成率の合計出力
                        // 3桁毎に","を挿入する、小数点第2位まで
                        currentsheet.Cell(xlsRowCnt + 2, 16).Style.NumberFormat.SetFormat("#,##0.00");
                        currentsheet.Cell(xlsRowCnt + 2, 16).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 2, 16).Value = currentsheet.Cell(xlsRowCnt + 2, intMonthDiff + 4).Value;

                        // 3行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt + 2, 16).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // 33行毎（ヘッダーを除いた行数）にシート作成
                        if (xlsRowCnt == 37)
                        {
                            pageCnt++;
                            if (pageCnt <= maxPage)
                            {
                                xlsRowCnt = 1;

                                // ヘッダーシートのコピー
                                pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
                            }
                        }

                        // 担当者計を出力
                        tantoRowCnt++;
                        if (tantoGoukei.ElementAt(tantoCnt).count == tantoRowCnt)
                        {
                            xlsRowCnt += 3;

                            // 縦中央
                            IXLCell tantocell = currentsheet.Cell(xlsRowCnt, 1);
                            tantocell.Value = drSuiihyo[1].ToString();
                            tantocell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                            // セル結合、セルの背景色
                            IXLRange tantorange = currentsheet.Range(xlsRowCnt, 1, xlsRowCnt + 2, 2);
                            tantorange.Merge();
                            tantorange.Style.Fill.BackgroundColor = XLColor.LightGray;

                            // 行タイトル（前年、本年、達成率）を出力
                            currentsheet.Cell(xlsRowCnt, 3).Value = "前年";
                            currentsheet.Cell(xlsRowCnt + 1, 3).Value = "本年";
                            currentsheet.Cell(xlsRowCnt + 2, 3).Value = "達成率";

                            // 前年、本年、達成率セルの処理
                            for (int column = 0; column < 13; column++)
                            {
                                // 前年と本年を出力
                                for (int cnt = 0; cnt < 2; cnt++)
                                {
                                    // 3桁毎に","を挿入する
                                    IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt + cnt, column + 4);
                                    kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                    kingakuCell.Style.NumberFormat.SetFormat("#,##0");
                                    kingakuCell.Value = decKingakuTanto[tantoCnt, cnt, column].ToString();
                                }

                                // 達成率の計算、出力
                                double dblRitsu;

                                if (decKingakuTanto[tantoCnt, 0, column] == 0 || decKingakuTanto[tantoCnt, 1, column] == 0)
                                {
                                    dblRitsu = 0;
                                }
                                else
                                {
                                    dblRitsu = ((double)decKingakuTanto[tantoCnt, 1, column] / (double)decKingakuTanto[tantoCnt, 0, column]) * 100;
                                }

                                // 3桁毎に","を挿入する、小数点第2位まで
                                currentsheet.Cell(xlsRowCnt + 2, column + 4).Style.NumberFormat.SetFormat("#,##0.00");
                                currentsheet.Cell(xlsRowCnt + 2, column + 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                currentsheet.Cell(xlsRowCnt + 2, column + 4).Value = dblRitsu.ToString();
                            }

                            // 3行分のセルの周囲に罫線を引く
                            currentsheet.Range(xlsRowCnt, 1, xlsRowCnt + 2, 16).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                        .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                        .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                        .Border.SetRightBorder(XLBorderStyleValues.Thin);

                            tantoCnt++;
                            tantoRowCnt = 0;
                        }

                        // 33行毎（ヘッダーを除いた行数）にシート作成
                        if (xlsRowCnt == 37)
                        {
                            pageCnt++;
                            if (pageCnt <= maxPage)
                            {
                                xlsRowCnt = 1;

                                // ヘッダーシートのコピー
                                pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
                            }
                        }

                        rowCnt++;
                        xlsRowCnt += 3;
                    }

                    // 最終行を出力した後、合計行を出力
                    if (dtChkList.Rows.Count > 0)
                    {
                        // 前年と本年の合計を出力
                        for (int row = 0; row < 2; row++)
                        {
                            for (int column = 0; column < 13; column++)
                            {
                                // 3桁毎に","を挿入する
                                IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt + row, 4 + column);
                                kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                kingakuCell.Style.NumberFormat.SetFormat("#,##0");
                                kingakuCell.Value = decKingaku[row, column].ToString();
                            }
                        }

                        // 合計タイトルを出力
                        currentsheet.Cell(xlsRowCnt, 1).Value = "■■　合　　計　■■";
                        currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    
                        // セルの結合
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt + 2, 2).Merge();

                        // 行タイトル（前年、本年、達成率）を出力
                        currentsheet.Cell(xlsRowCnt, 3).Value = "前年";
                        currentsheet.Cell(xlsRowCnt + 1, 3).Value = "本年";
                        currentsheet.Cell(xlsRowCnt + 2, 3).Value = "達成率";

                        // 達成率の計算、出力
                        for (int column = 0; column < 13; column++)
                        {
                            double dblRitsu;

                            if (decKingaku[0, column] == 0 || decKingaku[1, column] == 0)
                            {
                                dblRitsu = 0;
                            }
                            else
                            {
                                dblRitsu = ((double)decKingaku[1, column] / (double)decKingaku[0, column]) * 100;
                            }

                            // 3桁毎に","を挿入する、小数点第2位まで
                            currentsheet.Cell(xlsRowCnt + 2, column + 4).Style.NumberFormat.SetFormat("#,##0.00");
                            currentsheet.Cell(xlsRowCnt + 2, column + 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            currentsheet.Cell(xlsRowCnt + 2, column + 4).Value = dblRitsu.ToString();
                        }

                        // 3行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt + 2, 16).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);
                    }

                }

                // ヘッダーシート削除
                headersheet.Delete();

                // 各ページのヘッダー部を指定
                maxPage = workbook.Worksheets.Count;
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
                return pdf.createPdf(strOutXlsFile, strDateTime, 1);

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
