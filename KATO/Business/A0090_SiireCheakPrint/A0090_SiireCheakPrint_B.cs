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

namespace KATO.Business.A0090_SiireCheakPrint
{
    /// <summary>
    /// A0090_SiireCheakPrint_B
    /// 仕入チェックリスト ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/1
    /// 更新者：多田
    /// 更新日：2017/7/1
    /// カラム論理名
    /// </summary>
    class A0090_SiireCheakPrint_B
    {

        /// <summary>
        /// getSiireCheakList
        /// 仕入チェックリストを取得
        /// </summary>
        public DataTable getSiireCheakList(List<string> lstItem)
        {
            string strSql;
            DataTable dtSiireCheakList = new DataTable();

            strSql = "SELECT dbo.f_getグループコード(仕入ヘッダ.担当者コード) AS グループコード, ";
            strSql += "dbo.f_getグループ名(dbo.f_getグループコード(仕入ヘッダ.担当者コード)) AS グループ名, ";
            strSql += "仕入ヘッダ.担当者コード, ";
            strSql += "dbo.f_get担当者名(仕入ヘッダ.担当者コード) AS 担当者名,";

            strSql += "仕入ヘッダ.伝票年月日 AS 伝票年月日, ";
            strSql += "仕入明細.伝票番号 AS 伝票番号, ";
            strSql += "仕入明細.行番号 AS 行番号, ";
            strSql += "仕入ヘッダ.仕入先コード AS 仕入先コード, ";
            strSql += "仕入ヘッダ.仕入先名 AS 仕入先名 ,";

            strSql += "仕入ヘッダ.取引区分, ";
            strSql += "dbo.f_get取引区分名(仕入ヘッダ.取引区分) AS 取引区分名, ";

            strSql +=  "dbo.f_getメーカー名(仕入明細.メーカーコード) AS メーカー名,";

            strSql += "RTRIM(dbo.f_get中分類名(仕入明細.大分類コード,仕入明細.中分類コード)) ";
            strSql += " + ' ' + Rtrim(ISNULL(仕入明細.Ｃ１,'')) ";
            strSql += " + ' ' + Rtrim(ISNULL(仕入明細.Ｃ２,''))";
            strSql += " + ' ' + Rtrim(ISNULL(仕入明細.Ｃ３,''))";
            strSql += " + ' ' + Rtrim(ISNULL(仕入明細.Ｃ４,''))";
            strSql += " + ' ' + Rtrim(ISNULL(仕入明細.Ｃ５,''))";
            strSql += " + ' ' + Rtrim(ISNULL(仕入明細.Ｃ６,'')) AS 品名,";

            strSql += "仕入明細.数量 AS 数量, ";
            strSql += "仕入明細.仕入単価 AS 仕入単価, ";
            strSql += "仕入明細.仕入金額 AS 仕入金額, ";
            strSql += "仕入明細.備考 AS 備考, ";
            strSql += "仕入ヘッダ.税抜合計金額 AS 税抜合計金額, ";
            strSql += "仕入ヘッダ.消費税 AS 消費税, ";
            strSql += "仕入ヘッダ.税込合計金額 AS 税込合計金額";

            strSql += " FROM 仕入ヘッダ,仕入明細  ";
            strSql += " WHERE 仕入ヘッダ.削除 = 'N' ";
            strSql += " AND 仕入ヘッダ.伝票番号 = 仕入明細.伝票番号 ";
            strSql += " AND 仕入明細.削除 = 'N'";

            // 入力年月日（開始）がある場合
            if (!lstItem[0].Equals(""))
            {
                strSql += " AND CONVERT(VARCHAR(10),仕入ヘッダ.更新日時,111) >='" + lstItem[0] + "'";
                strSql += " AND CONVERT(VARCHAR(10),仕入ヘッダ.更新日時,111) <='" + lstItem[1] + "'";
            }

            // 伝票年月日（開始）がある場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND 仕入ヘッダ.伝票年月日 >='" + lstItem[2] + "'";
                strSql += " AND 仕入ヘッダ.伝票年月日 <='" + lstItem[3] + "'";
            }

            // ユーザーIDがある場合
            if (!lstItem[4].Equals(""))
            {
                strSql += " AND 仕入ヘッダ.更新ユーザー名='" + lstItem[4] + "'";
            }

            // 仕入先コードがある場合
            if (!lstItem[5].Equals("") && !lstItem[6].Equals(""))
            {
                strSql += " AND 仕入ヘッダ.仕入先コード >='" + lstItem[5] + "'";
                strSql += " AND 仕入ヘッダ.仕入先コード <='" + lstItem[6] + "'";
            }

            strSql += " ORDER BY グループコード, 担当者コード, 仕入ヘッダ.仕入先コード,仕入ヘッダ.伝票年月日,仕入明細.伝票番号,仕入明細.行番号";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtSiireCheakList = dbconnective.ReadSql(strSql);

                return dtSiireCheakList;
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
        public void dbToPdf(DataTable dtSiireCheakList, List<string> lstItem)
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
                var outDataAll = dtSiireCheakList.AsEnumerable()
                    .Select(dat => new
                    {
                        groupCd = dat["グループコード"],
                        groupName = dat["グループ名"],
                        tantoCd = dat["担当者コード"],
                        tantoName = dat["担当者名"],
                        siireCd = dat["仕入先コード"],
                        siireName = dat["仕入先名"],
                        denpyoYmd = dat["伝票年月日"],
                        denpyoNo = dat["伝票番号"],
                        bunruiName = dat["取引区分名"],
                        hinmei = dat["品名"],
                        suuryo = (decimal)dat["数量"],
                        tanka = (decimal)dat["仕入単価"],
                        kingaku = (decimal)dat["仕入金額"],
                        bikou = dat["備考"],
                        zeinuki = (decimal)dat["税抜合計金額"],
                        zei = (decimal)dat["消費税"],
                        zeikomi = (decimal)dat["税込合計金額"]

                    }).ToList();

                // linqで税抜合計金額、消費税、税込合計金額の合計算出
                decimal[] decKingaku = new decimal[3];
                decKingaku[0] = outDataAll.Select(gokei => gokei.zeinuki).Sum();
                decKingaku[1] = outDataAll.Select(gokei => gokei.zei).Sum();
                decKingaku[2] = outDataAll.Select(gokei => gokei.zeikomi).Sum();

                // 担当者計
                var tantoGoukei = from tbl in dtSiireCheakList.AsEnumerable()
                                  group tbl by tbl.Field<string>("担当者コード") into g
                                  select new
                                  {
                                      section = g.Key,
                                      count = g.Count(),
                                      zeinuki = g.Sum(p => p.Field<decimal>("税抜合計金額")),
                                      zei = g.Sum(p => p.Field<decimal>("消費税")),
                                      zeikomi = g.Sum(p => p.Field<decimal>("税込合計金額"))
                                  };

                // 担当者計の税抜合計金額、消費税、税込合計金額の合計算出
                decimal[,] decKingakuTanto = new decimal[tantoGoukei.Count(), 3];
                for (int cnt = 0; cnt < tantoGoukei.Count(); cnt++)
                {
                    decKingakuTanto[cnt, 0] = tantoGoukei.ElementAt(cnt).zeinuki;
                    decKingakuTanto[cnt, 1] = tantoGoukei.ElementAt(cnt).zei;
                    decKingakuTanto[cnt, 2] = tantoGoukei.ElementAt(cnt).zeikomi;
                }


                // グループ計
                var groupGoukei = from tbl in dtSiireCheakList.AsEnumerable()
                                  group tbl by tbl.Field<string>("グループコード") into g
                                  select new
                                  {
                                      section = g.Key,
                                      count = g.Count(),
                                      zeinuki = g.Sum(p => p.Field<decimal>("税抜合計金額")),
                                      zei = g.Sum(p => p.Field<decimal>("消費税")),
                                      zeikomi = g.Sum(p => p.Field<decimal>("税込合計金額"))
                                  };

                // グループ計の税抜合計金額、消費税、税込合計金額の合計算出
                decimal[,] decKingakuGroup = new decimal[groupGoukei.Count(), 3];
                for (int cnt = 0; cnt < groupGoukei.Count(); cnt++)
                {
                    decKingakuGroup[cnt, 0] = groupGoukei.ElementAt(cnt).zeinuki;
                    decKingakuGroup[cnt, 1] = groupGoukei.ElementAt(cnt).zei;
                    decKingakuGroup[cnt, 2] = groupGoukei.ElementAt(cnt).zeikomi;
                }

                // リストをデータテーブルに変換
                DataTable dtChkList = this.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                maxRowCnt += tantoGoukei.Count() + groupGoukei.Count();
                double page = 1.0 * maxRowCnt / 44;
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

                int tantoCnt = 0;
                int tantoRowCnt = 0;
                int groupCnt = 0;
                int groupRowCnt = 0;
                string strDenpyoNo = "";

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drSiireCheak in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "仕入チェックリスト";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "M1").Merge();

                        // 入力日、伝票年月日出力（A2のセル）
                        IXLCell unitCell = headersheet.Cell("A2");
                        unitCell.Value = "入力日：" + string.Format(lstItem[0], "yyyy年MM月dd日") + " ～ " +
                            string.Format(lstItem[1], "yyyy年MM月dd日")  + "  伝票年月日：" + 
                            string.Format(lstItem[2], "yyyy年MM月dd日") + " ～ " + string.Format(lstItem[3], "yyyy年MM月dd日");
                        unitCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "コード";
                        headersheet.Cell("B3").Value = "仕入先名";
                        headersheet.Cell("C3").Value = "年月日";
                        headersheet.Cell("D3").Value = "伝票番号";
                        headersheet.Cell("E3").Value = "取引区分";
                        headersheet.Cell("F3").Value = "品　　名　･　型　　番";
                        headersheet.Cell("G3").Value = "数量";
                        headersheet.Cell("H3").Value = "単価";
                        headersheet.Cell("I3").Value = "金額";
                        headersheet.Cell("J3").Value = "備　　考";
                        headersheet.Cell("K3").Value = "伝票合計";
                        headersheet.Cell("L3").Value = "消費税";
                        headersheet.Cell("M3").Value = "税込み計";

                        // ヘッダー列
                        headersheet.Range("A3", "M3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "M3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("A3", "M3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 5;
                        headersheet.Column(2).Width = 26;
                        headersheet.Column(3).Width = 9;
                        headersheet.Column(4).Width = 8;
                        headersheet.Column(5).Width = 8;
                        headersheet.Column(6).Width = 50;
                        headersheet.Column(7).Width = 6;
                        headersheet.Column(8).Width = 10;
                        headersheet.Column(9).Width = 12;
                        headersheet.Column(10).Width = 32;
                        headersheet.Column(11).Width = 10;
                        headersheet.Column(12).Width = 8;
                        headersheet.Column(13).Width = 12;

                        // 印刷体裁（A3横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A3Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№9）");

                        // ヘッダーシートからコピー
                        headersheet.CopyTo("Page1");
                        currentsheet = workbook.Worksheet(2);

                        // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
                        strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                            pageCnt.ToString() + " / " + maxPage.ToString();
                        currentsheet.PageSetup.Header.Right.AddText(strHeader);

                    }

                    // グループ名出力
                    if (groupRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt, 1).Value = drSiireCheak[1];
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Merge();

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        xlsRowCnt++;
                    }

                    // 44行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 48)
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

                    // 担当者名出力
                    if (tantoRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt, 1).Value = drSiireCheak[3];
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Merge();

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        xlsRowCnt++;
                    }

                    // 44行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 48)
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

                    // ヘッダー行の場合
                    if (xlsRowCnt == 3)
                    {
                        // 出力行へ移動
                        xlsRowCnt++;
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 8; colCnt <= maxColCnt - 3; colCnt++)
                    {
                        string str = drSiireCheak[colCnt - 1].ToString();

                        // 金額セルの処理
                        if (colCnt >= 11 && colCnt <= 13)
                        {
                            // 3桁毎に","を挿入する
                            str = string.Format("{0:#,0}", decimal.Parse(str));
                            currentsheet.Cell(xlsRowCnt, colCnt - 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 備考の場合
                        if (colCnt == 14)
                        {
                            currentsheet.Cell(xlsRowCnt, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        // 伝票番号の場合
                        if (colCnt == 8)
                        {
                            // 最初の行の場合 or 前行の伝票番号が現在の伝票番号と同じでない場合
                            if (!drSiireCheak[7].ToString().Equals(strDenpyoNo))
                            {
                                // 仕入先コード、仕入先名、年月日、伝票番号、取引区分名
                                for (int cnt = 0; cnt < 5; cnt++)
                                {
                                    currentsheet.Cell(xlsRowCnt, cnt + 1).Value = drSiireCheak[cnt + 4].ToString();
                                }

                                // 税抜合計金額、消費税、税込合計金額
                                for (int cnt = 0; cnt < 3; cnt++)
                                {
                                    // 3桁毎に","を挿入する
                                    IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, colCnt + cnt + 3);
                                    kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                    kingakuCell.Value = string.Format("{0:#,0}", decimal.Parse(drSiireCheak[colCnt + cnt + 6].ToString()));
                                }
                                
                                strDenpyoNo = drSiireCheak[7].ToString();
                            }
                        }
                        // 取引区分名の場合、伝票番号の処理で行っているため何もしない
                        else if (colCnt == 9)
                        {
                        }
                        else
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt - 4).Value = str;
                        }

                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 44行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 48)
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

                    // 担当者計を出力
                    tantoRowCnt++;
                    if (tantoGoukei.ElementAt(tantoCnt).count == tantoRowCnt)
                    {
                        xlsRowCnt++;
                        string strTanto = "                                        " +
                            "◆ 担当者計 ◆" + string.Format("{0,14:#,0}", decKingakuTanto[tantoCnt, 0]) +
                            "        ◆消費税◆" + string.Format("{0,12:#,0}", decKingakuTanto[tantoCnt, 1]) +
                            "        ◆税込み計◆" + string.Format("{0,14:#,0}", decKingakuTanto[tantoCnt, 2]);

                        // セル結合
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Merge();
                        currentsheet.Cell(xlsRowCnt, 1).Value = strTanto;

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        tantoCnt++;
                        rowCnt++;
                        tantoRowCnt = 0;
                    }

                    // 44行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 48)
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

                    // グループ計を出力
                    groupRowCnt++;
                    if (groupGoukei.ElementAt(groupCnt).count == groupRowCnt)
                    {
                        xlsRowCnt++;
                        string strGroup = "                                        " +
                            "◆グループ計◆" + string.Format("{0,14:#,0}", decKingakuGroup[groupCnt, 0]) +
                            "        ◆消費税◆" + string.Format("{0,12:#,0}", decKingakuGroup[groupCnt, 1]) +
                            "        ◆税込み計◆" + string.Format("{0,14:#,0}", decKingakuGroup[groupCnt, 2]);

                        // セル結合
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Merge();
                        currentsheet.Cell(xlsRowCnt, 1).Value = strGroup;

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        groupCnt++;
                        rowCnt++;
                        groupRowCnt = 0;
                    }

                    // 44行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 48)
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

                    // 44行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 48)
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

                    // 最終行を出力した後、合計行を出力
                    if (maxRowCnt == rowCnt)
                    {
                        string strKingaku = "                                        " +
                            "◆  総合計  ◆" + string.Format("{0,14:#,0}", decKingaku[0]) +
                            "        ◆消費税◆" + string.Format("{0,12:#,0}", decKingaku[1]) +
                            "        ◆税込み計◆" + string.Format("{0,14:#,0}", decKingaku[2]);

                        // セル結合
                        currentsheet.Range(xlsRowCnt + 1, 1, xlsRowCnt + 1, 13).Merge();
                        currentsheet.Cell(xlsRowCnt + 1, 1).Value = strKingaku;

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt + 1, 1, xlsRowCnt + 1, 13).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);
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
                createPdf(strOutXlsFile, strDateTime);

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
        private void createPdf(string strInXlsFile, string strDateTime)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strPdfPath = System.Configuration.ConfigurationManager.AppSettings["pdfpath"];

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
                string strJoinPdfFile = strPdfPath + strDateTime + ".pdf";

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
            return;
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
