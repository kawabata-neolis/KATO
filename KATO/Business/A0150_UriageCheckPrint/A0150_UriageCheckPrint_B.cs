using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Spire.Xls;
using ClosedXML.Excel;

//iTextSharp関連の名前空間
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.ComponentModel;
using System.IO;

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
        public void dbToPdf(DataTable dtUriageCheckList, List<string> lstItem)
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
                DataTable dtChkList = this.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                maxRowCnt += groupGoukei.Count() + tantouGoukei.Count();
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
                        unitCell.Value = "入力日：" + string.Format(lstItem[0], "yyyy年MM月dd日") + " ～ " +
                            string.Format(lstItem[1], "yyyy年MM月dd日")  + "  伝票年月日：" + 
                            string.Format(lstItem[2], "yyyy年MM月dd日") + " ～ " + string.Format(lstItem[3], "yyyy年MM月dd日");
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
                        headersheet.PageSetup.Header.Left.AddText("（№15）");

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
                        string str = drUriageCheckList[colCnt - 1].ToString();

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
                        rowCnt++;
                        tantouRowCnt = 0;
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

                // フォルダ下の"strDateTime *.pdf"ファイルをすべて取得する
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
