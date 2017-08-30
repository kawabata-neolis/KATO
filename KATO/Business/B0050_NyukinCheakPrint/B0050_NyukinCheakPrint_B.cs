using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;

namespace KATO.Business.B0050_NyukinCheakPrint
{
    /// <summary>
    /// B0050_NyukinCheakPrint_B
    /// 入金チェックリスト ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/25
    /// 更新者：多田
    /// 更新日：2017/7/25
    /// カラム論理名
    /// </summary>
    class B0050_NyukinCheakPrint_B
    {
        /// <summary>
        /// getNyukinCheakList
        /// 入金チェックリストを取得
        /// </summary>
        public DataTable getNyukinCheakList(List<string> lstItem)
        {
            string strSql;
            DataTable dtNyukinCheakList = new DataTable();

            strSql = "SELECT 入金年月日, ";
            strSql += "伝票番号, ";
            strSql += "行番号, ";
            strSql += "得意先コード, ";
            strSql += "dbo.f_get取引先名称(得意先コード) AS 取引先名, ";
            strSql += "取引区分コード, ";
            strSql += "dbo.f_get取引区分名(取引区分コード) AS 取引区分名, ";
            strSql += "入金額, ";
            strSql += "手形期日, ";
            strSql += "備考 ";
            strSql += " FROM 入金 ";
            strSql += " WHERE 削除 ='N' ";

            // 入力年月日（開始）がある場合
            if (!lstItem[0].Equals(""))
            {
                strSql += " AND CONVERT(VARCHAR(10),更新日時,111) >='" + lstItem[0] + "'";
                strSql += " AND CONVERT(VARCHAR(10),更新日時,111) <='" + lstItem[1] + "'";
            }

            // 伝票年月日（開始）がある場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND 入金年月日 >='" + lstItem[2] + "'";
                strSql += " AND 入金年月日 <='" + lstItem[3] + "'";
            }

            // ユーザーIDがある場合
            if (!lstItem[4].Equals(""))
            {
                strSql += " AND 更新ユーザー名='" + lstItem[4] + "'";
            }

            // 得意先コードがある場合
            if (!lstItem[5].Equals("") && !lstItem[6].Equals(""))
            {
                strSql += " AND 得意先コード >='" + lstItem[5] + "'";
                strSql += " AND 得意先コード <='" + lstItem[6] + "'";
            }

            strSql += " ORDER BY 入金年月日,伝票番号,行番号";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtNyukinCheakList = dbconnective.ReadSql(strSql);

                return dtNyukinCheakList;
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
        /// <param name="dtNyukinCheakList">
        ///     仕入推移表のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtNyukinCheakList, List<string> lstItem)
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
                var outDataAll = dtNyukinCheakList.AsEnumerable()
                    .Select(dat => new
                    {
                        tokuisakiCd = dat["得意先コード"],
                        tokuisakiName = dat["取引先名"],
                        nyukinYmd = dat["入金年月日"],
                        denpyoNo = dat["伝票番号"],
                        bunruiName = dat["取引区分名"],
                        kingaku = (decimal)dat["入金額"],
                        kijitsu = dat["手形期日"],
                        bikou = dat["備考"]
                    }).ToList();

                // linqで税抜合計金額、消費税、税込合計金額の合計算出
                decimal decKingaku = outDataAll.Select(gokei => gokei.kingaku).Sum();

                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

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
                foreach (DataRow drSiireCheak in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "入金チェックリスト";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "H1").Merge();

                        // 入力日、伝票年月日出力（A2のセル）
                        IXLCell unitCell = headersheet.Cell("A2");
                        unitCell.Value = "入力日：" +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[0])) + " ～ " +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[1])) + "  伝票年月日：" +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[2])) + " ～ " +
                            string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[3])) +
                            "  得意先コード：" + lstItem[5] + " ～ " + lstItem[6];
                        unitCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "コード";
                        headersheet.Cell("B3").Value = "得意先名";
                        headersheet.Cell("C3").Value = "入金日";
                        headersheet.Cell("D3").Value = "伝票番号";
                        headersheet.Cell("E3").Value = "取引区分";
                        headersheet.Cell("F3").Value = "入金額";
                        headersheet.Cell("G3").Value = "手形期日";
                        headersheet.Cell("H3").Value = "備　　考";

                        // ヘッダー列
                        headersheet.Range("A3", "H3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "H3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("A3", "H3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 5;
                        headersheet.Column(2).Width = 38;
                        headersheet.Column(3).Width = 11;
                        headersheet.Column(4).Width = 8;
                        headersheet.Column(5).Width = 10;
                        headersheet.Column(6).Width = 12;
                        headersheet.Column(7).Width = 11;
                        headersheet.Column(8).Width = 38;

                        // 印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№5）");

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drSiireCheak[colCnt - 1].ToString();

                        // 入金日、手形期日セルの場合
                        if (colCnt == 3 || colCnt == 7)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.DateFormat.SetFormat("yyyy/MM/dd");
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }

                        // 伝票番号セルの処理
                        if (colCnt == 4)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 入金額セルの処理
                        if (colCnt == 6)
                        {
                            // 3桁毎に","を挿入する
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("#,##0");
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 備考セルの場合
                        if (colCnt == 8)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            str = "'" + str;
                        }

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 8).Style
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
                    // セル結合
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 5).Merge();
                    currentsheet.Cell(xlsRowCnt, 1).Value = "◆◆◆　合　計　◆◆◆";
                    currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // 入金額
                    currentsheet.Cell(xlsRowCnt, 6).Value = string.Format("{0:#,0}", decKingaku);
                    currentsheet.Cell(xlsRowCnt, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 8).Style
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
