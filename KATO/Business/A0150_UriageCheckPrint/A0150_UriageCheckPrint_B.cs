using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;

namespace KATO.Business.A0150_UriageCheckPrint
{
    ///<summary>
    ///A0150_UriageCheckPrint_B
    ///売上チェックリスト
    ///作成者：太田
    ///作成日：2017/07/3
    ///更新者：
    ///更新日：
    ///カラム論理名
    class A0150_UriageCheckPrint_B
    {
        ///<summary>
        ///getUriageCheckList
        ///売上チェックリストを取得
        ///</summary>
        public DataTable getUriageCheckList(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();
            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            //SQL文 売上チェックリスト

            strSQLInput = strSQLInput + " SELECT ";
            strSQLInput = strSQLInput + " 売上ヘッダ.伝票年月日 AS 伝票年月日 ";
            strSQLInput = strSQLInput + " , 売上明細.伝票番号 AS 伝票番号 ";
            strSQLInput = strSQLInput + " , 売上明細.行番号 AS 行番号 ";
            strSQLInput = strSQLInput + " , 売上ヘッダ.得意先コード AS 得意先コード ";
            strSQLInput = strSQLInput + " , 売上ヘッダ.得意先名 AS 得意先名 ";
            strSQLInput = strSQLInput + " , 売上ヘッダ.取引区分 ";
            strSQLInput = strSQLInput + " , dbo.f_get取引区分名(売上ヘッダ.取引区分) AS 取引区分名 ";
            strSQLInput = strSQLInput + " , dbo.f_getメーカー名(売上明細.メーカーコード) AS メーカー名 ";
            strSQLInput = strSQLInput + " , RTRIM(dbo.f_get中分類名(売上明細.大分類コード, 売上明細.中分類コード)) + ' ' + Rtrim(ISNULL(売上明細.Ｃ１, '')) + ' ' + Rtrim(ISNULL(売上明細.Ｃ２, '')) + ' ' + Rtrim(ISNULL(売上明細.Ｃ３, '')) + ' ' + Rtrim(ISNULL(売上明細.Ｃ４, '')) + ' ' + Rtrim(ISNULL(売上明細.Ｃ５, '')) + ' ' + Rtrim(ISNULL(売上明細.Ｃ６, '')) AS 品名 ";
            strSQLInput = strSQLInput + " , 売上明細.数量 AS 数量 ";
            strSQLInput = strSQLInput + " , 売上明細.売上単価 AS 単価 ";
            strSQLInput = strSQLInput + " , 売上明細.売上金額 AS 金額 ";
            strSQLInput = strSQLInput + " , 売上明細.備考 AS 備考 ";
            strSQLInput = strSQLInput + " , 売上ヘッダ.税抜合計金額 AS 税抜合計金額 ";
            strSQLInput = strSQLInput + " , 売上ヘッダ.消費税 AS 消費税 ";
            strSQLInput = strSQLInput + " , 売上ヘッダ.税込合計金額 AS 税込合計金額 ";
            strSQLInput = strSQLInput + " ,dbo.f_getグループコード(売上ヘッダ.担当者コード) AS グループコード, dbo.f_getグループ名(dbo.f_getグループコード(売上ヘッダ.担当者コード)) AS グループ名 ";
            strSQLInput = strSQLInput + " ,売上ヘッダ.担当者コード AS 担当者コード, dbo.f_get担当者名(売上ヘッダ.担当者コード) AS 担当者名 ";

            strSQLInput = strSQLInput + " FROM ";
            strSQLInput = strSQLInput + " 売上ヘッダ ";
            strSQLInput = strSQLInput + ", 売上明細  ";


            strSQLInput = strSQLInput + " WHERE ";
            strSQLInput = strSQLInput + "  売上ヘッダ.削除 = 'N' ";
            strSQLInput = strSQLInput + " AND 売上ヘッダ.伝票番号 = 売上明細.伝票番号 ";
            strSQLInput = strSQLInput + " AND 売上明細.削除 = 'N'  ";

            //入力年月日を記述した場合
            if (lstString[0] != "" && lstString[1] != "")
            {
                strSQLInput = strSQLInput + " AND CONVERT(VARCHAR (10), 売上ヘッダ.更新日時, 111) >= '" + lstString[0] + "' ";
                strSQLInput = strSQLInput + " AND CONVERT(VARCHAR (10), 売上ヘッダ.更新日時, 111) <= '" + lstString[1] + "' ";
            }

            //伝票年月日を記述した場合
            if (lstString[2] != "" && lstString[3] != "")
            {
                strSQLInput = strSQLInput + " AND 売上ヘッダ.伝票年月日 >= '" + lstString[2] + "' ";
                strSQLInput = strSQLInput + " AND 売上ヘッダ.伝票年月日 <= '" + lstString[3] + "' ";
            }

            //ユーザを記述した場合
            if (lstString[4] != "")
            {
                strSQLInput = strSQLInput + " AND 売上ヘッダ.更新ユーザー名 = '" + lstString[4] + "' ";
            }

            //得意先コードを記述した場合
            if (!lstString[5].Equals("") && !lstString[6].Equals(""))
            {
                strSQLInput = strSQLInput + " AND 売上ヘッダ.得意先コード >='" + lstString[5] + "'";
                strSQLInput = strSQLInput + " AND 売上ヘッダ.得意先コード <='" + lstString[6] + "'";
            }

            strSQLInput = strSQLInput + " ORDER BY ";
            strSQLInput = strSQLInput + " グループコード, 担当者コード,売上ヘッダ.得意先コード, 売上ヘッダ.伝票年月日, 売上明細.伝票番号, 売上明細.行番号 ";


            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
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
            return (dtGetTableGrid);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtUriageCheckList">
        ///     売上チェックリストのデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtUriageCheckList, List<string> lstItem)
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
                var outDataAll = dtUriageCheckList.AsEnumerable()
                    .Select(dat => new
                    {
                        groupCd = dat["グループコード"],
                        groupName = dat["グループ名"],
                        tantoCd = dat["担当者コード"],
                        tantoName = dat["担当者名"],
                        UriageCheckCode = dat["得意先コード"],
                        UriageCheckName = dat["得意先名"],
                        denpyoYMD = dat["伝票年月日"],
                        denpyoNo = dat["伝票番号"],
                        torihikiKbnName = dat["取引区分名"],
                        sinamei = dat["品名"],
                        suuryo = dat["数量"],
                        tanka = (decimal)dat["単価"],
                        uriageKingaku = (decimal)dat["金額"],
                        bikou = dat["備考"],
                        zeinukiGoukeiKingaku = (decimal)dat["税抜合計金額"],
                        shouhizei = (decimal)dat["消費税"],
                        zeikomiGoukeiKingaku = (decimal)dat["税込合計金額"]
                    }).ToList();

                // linqで総合計、総税込み、総税込み計を算出する。
                decimal[] decKingaku = new decimal[13];
                decKingaku[0] = outDataAll.Select(gokei => gokei.zeinukiGoukeiKingaku).Sum();
                decKingaku[1] = outDataAll.Select(gokei => gokei.shouhizei).Sum();
                decKingaku[2] = outDataAll.Select(gokei => gokei.zeikomiGoukeiKingaku).Sum();

                //グループ合計
                var groupGoukei = from tbl in dtUriageCheckList.AsEnumerable()
                                  group tbl by tbl.Field<string>("グループコード") into g
                                  select new
                                  {
                                      section = g.Key,
                                      count = g.Count(),
                                      zeinukiGoukeiKingaku = g.Sum(p => p.Field<decimal>("税抜合計金額")),
                                      shouhizei = g.Sum(p => p.Field<decimal>("消費税")),
                                      zeikomiGoukeiKingaku = g.Sum(p => p.Field<decimal>("税込合計金額")),
                                  };

                // グループ計の税抜合計金額、消費税、税込み合計金額の算出
                decimal[,] decKingakuGroup = new decimal[groupGoukei.Count(), 3];
                for (int cnt = 0; cnt < groupGoukei.Count(); cnt++)
                {
                    decKingakuGroup[cnt, 0] = groupGoukei.ElementAt(cnt).zeinukiGoukeiKingaku;
                    decKingakuGroup[cnt, 1] = groupGoukei.ElementAt(cnt).shouhizei;
                    decKingakuGroup[cnt, 2] = groupGoukei.ElementAt(cnt).zeikomiGoukeiKingaku;
                }


                // 担当者計
                var tantouGoukei = from tbl in dtUriageCheckList.AsEnumerable()
                                   group tbl by tbl.Field<string>("担当者コード") into g
                                   select new
                                   {
                                       section = g.Key,
                                       count = g.Count(),
                                       zeinukiGoukeiKingaku = g.Sum(p => p.Field<decimal>("税抜合計金額")),
                                       shouhizei = g.Sum(p => p.Field<decimal>("消費税")),
                                       zeikomiGoukeiKingaku = g.Sum(p => p.Field<decimal>("税込合計金額")),
                                   };

                // 担当者計の税抜合計金額、消費税、税込み合計金額の算出
                decimal[,] decKingakuTanto = new decimal[tantouGoukei.Count(), 3];
                for (int cnt = 0; cnt < tantouGoukei.Count(); cnt++)
                {
                    decKingakuTanto[cnt, 0] = tantouGoukei.ElementAt(cnt).zeinukiGoukeiKingaku;
                    decKingakuTanto[cnt, 1] = tantouGoukei.ElementAt(cnt).shouhizei;
                    decKingakuTanto[cnt, 2] = tantouGoukei.ElementAt(cnt).zeikomiGoukeiKingaku;
                }

                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                maxRowCnt += groupGoukei.Count() * 2 + tantouGoukei.Count() * 2 + 1;
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

                
                int tantouCnt = 0;
                int tantouRowCnt = 0;
                int groupCnt = 0;
                int groupRowCnt = 0;
                string strDenpyoNo = "";

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drUriageCheckList in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "売上チェックリスト";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "M1").Merge();

                        // 入力日、伝票年月日出力（A2のセル）
                        IXLCell unitCell = headersheet.Cell("A2");
                        unitCell.Value = "入力日：" +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[0])) + " ～ " +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[1])) + "  伝票年月日：" +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[2])) + " ～ " +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[3])) +
                            " 得意先コード：" + lstItem[5] + " ～ " + lstItem[6];
                        unitCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "コード";
                        headersheet.Cell("B3").Value = "得意先名";
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
                        headersheet.Column(2).Width = 18;
                        headersheet.Column(3).Width = 9;
                        headersheet.Column(4).Width = 8;
                        headersheet.Column(5).Width = 7;
                        headersheet.Column(6).Width = 30;
                        headersheet.Column(7).Width = 6;
                        headersheet.Column(8).Width = 12;
                        headersheet.Column(9).Width = 12;
                        headersheet.Column(10).Width = 24;
                        headersheet.Column(11).Width = 10;
                        headersheet.Column(12).Width = 8;
                        headersheet.Column(13).Width = 12;

                        // フォントサイズ変更
                        headersheet.Range("B4:B38").Style.Font.FontSize = 6;
                        headersheet.Range("F4:F38").Style.Font.FontSize = 6;
                        headersheet.Range("J4:J38").Style.Font.FontSize = 6;

                        // 印刷体裁（B4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.B4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№15）");

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // グループ名出力
                    if (groupRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt, 1).Value = drUriageCheckList[1];
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Merge();

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
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 4;

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                        }
                    }

                    // 担当者名出力
                    if (tantouRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt, 1).Value = drUriageCheckList[3];
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Merge();

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
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 4;

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                        }
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 8; colCnt <= maxColCnt - 3; colCnt++)
                    {
                        string str = drUriageCheckList[colCnt - 1].ToString();

                        // 金額セルの処理
                        if (colCnt == 11 || colCnt == 13)
                        {
                            // 3桁毎に","を挿入する
                            str = string.Format("{0:#,0}", decimal.Parse(str));
                            currentsheet.Cell(xlsRowCnt, colCnt - 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 単価セルの処理
                        if (colCnt == 12)
                        {
                            // 3桁毎に","を挿入する、小数点第2位まで
                            currentsheet.Cell(xlsRowCnt, colCnt - 4).Style.NumberFormat.SetFormat("#,##0.00");
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
                            if (!drUriageCheckList[7].ToString().Equals(strDenpyoNo))
                            {
                                // 得意先コード、得意先名、年月日、伝票番号、取引区分名
                                for (int cnt = 0; cnt < 5; cnt++)
                                {
                                    currentsheet.Cell(xlsRowCnt, cnt + 1).Value = drUriageCheckList[cnt + 4].ToString();
                                }

                                // 税抜合計金額、消費税、税込合計金額
                                for (int cnt = 0; cnt < 3; cnt++)
                                {
                                    // 3桁毎に","を挿入する
                                    IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, colCnt + cnt + 3);
                                    kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                    kingakuCell.Value = string.Format("{0:#,0}", decimal.Parse(drUriageCheckList[colCnt + cnt + 6].ToString()));
                                }
                                
                                strDenpyoNo = drUriageCheckList[7].ToString();
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

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                        }
                    }

                    // 担当者計を出力
                    tantouRowCnt++;
                    if (tantouGoukei.ElementAt(tantouCnt).count == tantouRowCnt)
                    {
                        xlsRowCnt++;
                        string strTanto = "                                        " +
                            "◆ 担当者計 ◆" + string.Format("{0,14:#,0}", decKingakuTanto[tantouCnt, 0]) +
                            "        ◆消費税◆" + string.Format("{0,12:#,0}", decKingakuTanto[tantouCnt, 1]) +
                            "        ◆税込み計◆" + string.Format("{0,14:#,0}", decKingakuTanto[tantouCnt, 2]);

                        // セル結合
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Merge();
                        currentsheet.Cell(xlsRowCnt, 1).Value = strTanto;

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        tantouCnt++;
                        tantouRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
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
                        groupRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
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

                // 最終行を出力した後、合計行を出力
                if (dtChkList.Rows.Count > 0)
                {
                    string strKingaku = "                                        " +
                        "◆  総合計  ◆" + string.Format("{0,14:#,0}", decKingaku[0]) +
                        "        ◆消費税◆" + string.Format("{0,12:#,0}", decKingaku[1]) +
                        "        ◆税込み計◆" + string.Format("{0,14:#,0}", decKingaku[2]);

                    // セル結合
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 13).Merge();
                    currentsheet.Cell(xlsRowCnt, 1).Value = strKingaku;

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
