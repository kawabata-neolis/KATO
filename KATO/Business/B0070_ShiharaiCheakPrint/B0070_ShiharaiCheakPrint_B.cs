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

namespace KATO.Business.B0070_ShiharaiCheakPrint
{
    /// <summary>
    /// B0070_ShiharaiCheakPrint_B
    /// 支払チェックリスト ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/25
    /// 更新者：多田
    /// 更新日：2017/7/25
    /// カラム論理名
    /// </summary>
    class B0070_ShiharaiCheakPrint_B
    {

        /// <summary>
        /// getShiharaiCheakList
        /// 支払チェックリストを取得
        /// </summary>
        public DataTable getShiharaiCheakList(List<string> lstItem)
        {
            string strSql;
            DataTable dtShiharaiCheakList = new DataTable();

            strSql = "SELECT 支払年月日, ";
            strSql += "伝票番号, ";
            strSql += "行番号, ";
            strSql += "仕入先コード, ";
            strSql += "dbo.f_get取引先名称(仕入先コード) AS 取引先名, ";
            strSql += "取引区分コード, ";
            strSql += "dbo.f_get取引区分名(取引区分コード) AS 取引区分名, ";
            strSql += "支払額, ";
            strSql += "手形期日, ";
            strSql += "備考 ";
            strSql += " FROM 支払 ";
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
                strSql += " AND 支払年月日 >='" + lstItem[2] + "'";
                strSql += " AND 支払年月日 <='" + lstItem[3] + "'";
            }

            // ユーザーIDがある場合
            if (!lstItem[4].Equals(""))
            {
                strSql += " AND 更新ユーザー名='" + lstItem[4] + "'";
            }

            // 仕入先コードがある場合
            if (!lstItem[5].Equals("") && !lstItem[6].Equals(""))
            {
                strSql += " AND 仕入先コード >='" + lstItem[5] + "'";
                strSql += " AND 仕入先コード <='" + lstItem[6] + "'";
            }

            strSql += " ORDER BY 支払年月日,伝票番号,行番号";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtShiharaiCheakList = dbconnective.ReadSql(strSql);

                return dtShiharaiCheakList;
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
        /// <param name="dtShiharaiCheakList">
        ///     仕入推移表のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtShiharaiCheakList, List<string> lstItem)
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
                var outDataAll = dtShiharaiCheakList.AsEnumerable()
                    .Select(dat => new
                    {
                        siiresakiCd = dat["仕入先コード"],
                        siiresakiName = dat["取引先名"],
                        shiharaiYmd = dat["支払年月日"],
                        denpyoNo = dat["伝票番号"],
                        bunruiName = dat["取引区分名"],
                        kingaku = (decimal)dat["支払額"],
                        kijitsu = dat["手形期日"],
                        bikou = dat["備考"]
                    }).ToList();

                // linqで税抜合計金額、消費税、税込合計金額の合計算出
                decimal decKingaku = outDataAll.Select(gokei => gokei.kingaku).Sum();

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
                foreach (DataRow drSiireCheak in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "支払チェックリスト";
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
                            "  仕入先コード：" + lstItem[5] + " ～ " + lstItem[6];
                        unitCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "コード";
                        headersheet.Cell("B3").Value = "仕入先名";
                        headersheet.Cell("C3").Value = "支払日";
                        headersheet.Cell("D3").Value = "伝票番号";
                        headersheet.Cell("E3").Value = "取引区分";
                        headersheet.Cell("F3").Value = "支払額";
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
                        headersheet.PageSetup.Header.Left.AddText("（№7）");

                        // ヘッダーシートからコピー
                        headersheet.CopyTo("Page1");
                        currentsheet = workbook.Worksheet(2);

                        // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
                        strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                            pageCnt.ToString() + " / " + maxPage.ToString();
                        currentsheet.PageSetup.Header.Right.AddText(strHeader);

                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drSiireCheak[colCnt - 1].ToString();

                        // 支払日、手形期日セルの場合
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

                        // 支払額セルの処理
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
