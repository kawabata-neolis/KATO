using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.ComponentModel;
using System.Data.OleDb;

using Spire.Xls;

//iTextSharp関連の名前空間
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;

using NPOI;
using NPOI.SS.UserModel;

namespace KATO.Common.Util
{
    class CreatePdf
    {
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// PDF化(Spire.xls)の処理
        /// <param name="strInXlsFile">エクセルファイル</param>
        /// <param name="strDateTime">日時</param>
        /// </summary>
        /// -----------------------------------------------------------------------------
        public string createPdf(string strInXlsFile, string strDateTime, int intPaperSizeIndex)
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

                    var i = printsheet.PageSetup.PageHeight;

                    string no = no = (sheetCnt + 1).ToString();

                    if (no.Length == 1)
                    {
                        no = "0" + no;
                    }

                    int intNo = int.Parse(no);

                    //0パディング
                    no = string.Format("{0:0000}", intNo);

                    if(intPaperSizeIndex == 4)
                    {
                        printsheet.Activate();

                        printsheet.PageSetup.PrintArea = "$A$1:$AL$11";
                    }
                    else if(intPaperSizeIndex == 3)
                    {
                        printsheet.Activate();

                        printsheet.PageSetup.PrintArea = "$A$1:$AS$18";

                        //テンプレートの印刷範囲確認用に枠線を付ける
                        //printsheet.PageSetup.IsPrintGridlines = true;
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// PDF化(Spire.xls)の処理(通常サイズ)
        /// <param name="strInXlsFile">エクセルファイル</param>
        /// <param name="strDateTime">日時</param>
        /// </summary>
        /// -----------------------------------------------------------------------------
        public string createPdf(string strInXlsFile, string strDateTime)
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

                    var i = printsheet.PageSetup.PageHeight;

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

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// PDFファイルの結合(長3,長4の場合)
        /// WritePage = 0：全ページ、WritePage = 1：全ファイルの1ページのみ
        /// WritePage = 2(3...)：全ファイルの1～2(1～3)ページ
        /// </summary>
        /// <param name="arySrcFilePath">入力ファイルパス</param>
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
        public DataTable ConvertToDataTable<T>(IList<T> data)
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ロゴ（KATO_LOGO）の貼り付け処理
        /// </summary>
        /// <param name="strInXlsFile">エクセルファイル</param>
        /// <param name="topRow">貼り付け位置（行）</param>
        /// <param name="leftColumn">貼り付け位置（列）</param>
        /// <param name="topRowOffset">貼り付け位置（行：オフセット）</param>
        /// <param name="LeftColumnOffset">貼り付け位置（列：オフセット）</param>
        /// <param name="percent">縮小サイズ</param>
        /// -----------------------------------------------------------------------------
        public void logoPaste(string strInXlsFile, int[] topRow, int[] leftColumn, int topRowOffset, int leftColumnOffset, int percent)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(strInXlsFile, ExcelVersion.Version2010);

            for (int sheetCnt = 0; sheetCnt < workbook.Worksheets.Count; sheetCnt++)
            {
                Worksheet worksheet = workbook.Worksheets[sheetCnt];

                for (int cnt = 0; cnt < topRow.Count(); cnt++)
                {
                    // 画像の貼り付け
                    ExcelPicture pic = worksheet.Pictures.Add(topRow[cnt], leftColumn[cnt], @"./Common/KATO_LOGO.jpg");
                    pic.TopRowOffset = topRowOffset;
                    pic.LeftColumnOffset = leftColumnOffset;
                    pic.Width = (int)(pic.Width * (float)percent / 100);
                    pic.Height = (int)(pic.Height * (float)percent / 100);
                }
            }

            // 保存
            workbook.Save();

            // workbookを解放
            workbook.Dispose();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ロゴ（KATO_LOGO）の貼り付け処理(1ページ目のみ)
        /// </summary>
        /// <param name="strInXlsFile">エクセルファイル</param>
        /// <param name="topRow">貼り付け位置（行）</param>
        /// <param name="leftColumn">貼り付け位置（列）</param>
        /// <param name="topRowOffset">貼り付け位置（行：オフセット）</param>
        /// <param name="LeftColumnOffset">貼り付け位置（列：オフセット）</param>
        /// <param name="percent">縮小サイズ</param>
        /// -----------------------------------------------------------------------------
        public void logoPasteOnlyTopPage(string strInXlsFile, int[] topRow, int[] leftColumn, int topRowOffset, int leftColumnOffset, int percent)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(strInXlsFile, ExcelVersion.Version2010);

            Worksheet worksheet = workbook.Worksheets[0];

            for (int cnt = 0; cnt < topRow.Count(); cnt++)
            {
                // 画像の貼り付け
                ExcelPicture pic = worksheet.Pictures.Add(topRow[cnt], leftColumn[cnt], @"./Common/KATO_LOGO.jpg");
                pic.TopRowOffset = topRowOffset;
                pic.LeftColumnOffset = leftColumnOffset;
                pic.Width = (int)(pic.Width * (float)percent / 100);
                pic.Height = (int)(pic.Height * (float)percent / 100);
            }

            // 保存
            workbook.Save();

            // workbookを解放
            workbook.Dispose();
        }

        /// <summary>
        /// ヘッダーシートをコピー
        /// <param name="workbook">参照型 ワークブック</param>
        /// <param name="headersheet">参照型 ヘッダーシート</param>
        /// <param name="currentsheet">参照型 カレントシート</param>
        /// <param name="pageCnt">ページ数</param>
        /// </summary>
        public void sheetCopy(ref XLWorkbook workbook, ref IXLWorksheet headersheet, ref IXLWorksheet currentsheet, int pageCnt)
        {
            // ヘッダーシートからコピー
            headersheet.CopyTo("Page" + pageCnt.ToString());
            currentsheet = workbook.Worksheet(pageCnt + 1);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ヘッダーシートをコピーし、ヘッダー部を指定
        /// <param name="workbook">参照型 ワークブック</param>
        /// <param name="headersheet">参照型 ヘッダーシート</param>
        /// <param name="currentsheet">参照型 カレントシート</param>
        /// <param name="page">ページ数</param>
        /// <param name="page">最大ページ数</param>
        /// <param name="strNow">現在の日付</param>
        /// </summary>
        /// -----------------------------------------------------------------------------
        public void sheetCopy(ref XLWorkbook workbook, ref IXLWorksheet headersheet, ref IXLWorksheet currentsheet, int page, int maxPage, string strNow)
        {
            // ヘッダー部に指定する情報を取得
            string strHeader = this.getHeader(page, maxPage, strNow);

            // ヘッダーシートからコピー
            headersheet.CopyTo("Page" + page.ToString());
            currentsheet = workbook.Worksheet(page + 1);

            // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
            currentsheet.PageSetup.Header.Right.AddText(strHeader);
        }

        public void sheetCopy2(ref XLWorkbook workbook, ref IXLWorksheet headersheet, ref IXLWorksheet currentsheet, int page, int maxPage, string strNow)
        {
            // ヘッダー部に指定する情報を取得
            //string strHeader = this.getHeader(page, maxPage, strNow);

            // ヘッダーシートからコピー
            headersheet.CopyTo("Page" + page.ToString());
            currentsheet = workbook.Worksheet(page + 1);

            // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
            currentsheet.PageSetup.Header.Right.AddText(page.ToString() + " / " + maxPage.ToString() + "　");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ヘッダー部に指定する情報を取得
        /// <param name="page">ページ数</param>
        /// <param name="page">最大ページ数</param>
        /// <param name="strNow">現在の日付</param>
        /// </summary>
        /// -----------------------------------------------------------------------------
        public string getHeader(int page, int maxPage, string strNow)
        {
            string strSpace = "       ";

            // コンピュータ名、日付、ページ数
            string strHeader = "（ " + System.Windows.Forms.SystemInformation.ComputerName + " ）" +
                strSpace + strNow + strSpace + page.ToString() + " / " + maxPage.ToString() + "　";

            return strHeader;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ヘッダー部に指定する情報を取得
        /// <param name="page">ページ数</param>
        /// <param name="page">最大ページ数</param>
        /// <param name="strNow">現在の日付</param>
        /// </summary>
        /// -----------------------------------------------------------------------------
        public DataTable exceltoDataTable(string xlFilePath, string strKakucho)
        {
            Workbook workbook = new Workbook();
            try
            {
                //拡張子が.xlsxの場合
                if (strKakucho == ".xlsx")
                {
                    workbook.LoadFromFile(xlFilePath, ExcelVersion.Version2013);
                }
                //拡張子が.xlsの場合
                else if (strKakucho == ".xls")
                {
                    workbook.LoadFromFile(xlFilePath, ExcelVersion.Version97to2003);
                }

                Worksheet sheet = workbook.Worksheets[0];
                DataTable dataTable = sheet.ExportDataTable(sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn, false);

                DataTable dtCloned = dataTable.Clone();
                foreach (DataColumn dc in dtCloned.Columns)
                    dc.DataType = typeof(string);
                foreach (DataRow row in dataTable.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                foreach (DataRow row in dtCloned.Rows)
                {
                    for (int i = 0; i < dtCloned.Columns.Count; i++)
                    {
                        dtCloned.Columns[i].ReadOnly = false;
                        if (string.IsNullOrEmpty(row[i].ToString()))
                            row[i] = string.Empty;
                    }
                }

                return dtCloned;
            }
            catch
            {
                throw;
            }
            finally
            {
                workbook.Dispose();
            }

        }

        public DataTable exceltoDataTablePoi(string xlFilePath, string strKakucho)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("A", Type.GetType("System.String"));
            dt.Columns.Add("B", Type.GetType("System.String"));
            dt.Columns.Add("C", Type.GetType("System.String"));
            dt.Columns.Add("D", Type.GetType("System.String"));
            dt.Columns.Add("E", Type.GetType("System.String"));
            dt.Columns.Add("F", Type.GetType("System.String"));
            dt.Columns.Add("G", Type.GetType("System.String"));

            // ファイル取得用
            FileStream fs = null;

            // ブック格納用
            IWorkbook readBook = null;

            using (fs = File.OpenRead(xlFilePath))
            {
                readBook = WorkbookFactory.Create(fs);
            }

            // 1番目のシートを取得
            ISheet readSheet = readBook.GetSheetAt(0);

            int lrow = readSheet.LastRowNum + 1;

            for (int i = 2; i < lrow; i++)
            {
                // 行オブジェクトを取得
                IRow row = readSheet.GetRow(i);
                
                DataRow dr = dt.NewRow();
                dr["A"] = "";
                dr["B"] = row.GetCell(1).StringCellValue;
                dr["C"] = row.GetCell(2).StringCellValue;
                dr["D"] = row.GetCell(3).StringCellValue;
                dr["E"] = row.GetCell(4).StringCellValue;
                dr["F"] = row.GetCell(5).NumericCellValue.ToString();
                dr["G"] = row.GetCell(6).NumericCellValue.ToString();

                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成（テンプレート無し）</summary>
        /// <param name="dt">
        ///     出力対象DataTable</param>
        /// <param name="functionName">
        ///     機能名</param>
        /// <param name="startRow">
        ///     出力開始行</param>
        /// <param name="startCol">
        ///     出力開始列</param>
        /// <param name="header">
        ///     出力するヘッダを格納した配列</param>
        /// -----------------------------------------------------------------------------
        public void DtToXls(DataTable dt, string functionName, string outXlsFile, int startRow, int startCol, string[] header)
        {
            //string xlspath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            ////string xlspath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            XLWorkbook currentWorkbook = new XLWorkbook();
            IXLWorksheet worksheet = currentWorkbook.Worksheets.Add("data");

            //string DTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            //string outXlsFile = xlspath + functionName + "_" + DTime + ".xlsx";

            try
            {
                int cntrow = 0; // 行カウント
                int cntcol = 0; // 列カウント 
                int maxcol = dt.Columns.Count;

                // DataTable を一行ずつエクセルに出力
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (cntcol < maxcol)
                        {
                            string colName = col.ColumnName.ToUpper();
                            var value = row[cntcol];
                            // 値の型取得
                            string valueType = value.GetType().Name.ToUpper();

                            #region カラム名を見て、フォーマット指定してセルに出力
                            // 金額関係
                            if (colName.IndexOf("KINGAKU") > -1)
                            {
                                // 値をdecimalにキャスト（Excel出力時に文字列扱いにさせないため）
                                decimal dValue = decimal.Parse(value.ToString());
                                // セルに値出力
                                worksheet.Cell(cntrow + startRow, cntcol + startCol).SetValue(dValue)
                                    .Style.NumberFormat.SetFormat("#,##0");
                            }
                            // 単価・原価関係
                            else if (colName.IndexOf("TANKA") > -1 || colName.IndexOf("GENKA") > -1)
                            {
                                // 値をdecimalにキャスト（Excel出力時に文字列扱いにさせないため）
                                decimal dValue = decimal.Parse(value.ToString());
                                // セルに値出力
                                worksheet.Cell(cntrow + startRow, cntcol + startCol).SetValue(dValue)
                                    .Style.NumberFormat.SetFormat("#,##0.00");
                            }
                            // 数量関係
                            else if (colName.IndexOf("SURYO") > -1)
                            {
                                // 値をdecimalにキャスト（Excel出力時に文字列扱いにさせないため）
                                decimal dValue = decimal.Parse(value.ToString());
                                // セルに値出力
                                worksheet.Cell(cntrow + startRow, cntcol + startCol).SetValue(dValue)
                                    .Style.NumberFormat.SetFormat("0.00");
                            }
                            // 日付関係の場合
                            else if (valueType.Equals("DATETIME"))
                            {
                                DateTime dtValue = DateTime.Parse(value.ToString());
                                // セルに値出力
                                worksheet.Cell(cntrow + startRow, cntcol + startCol).SetValue(dtValue)
                                    .Style.NumberFormat.SetFormat("yyyy/mm/dd");
                            }
                            // 金額・単価・数量関係以外のdecimalの場合
                            else if (valueType.Equals("DECIMAL"))
                            {
                                // 値をdecimalにキャスト（Excel出力時に文字列扱いにさせないため）
                                decimal dValue = decimal.Parse(value.ToString());
                                // セルに値出力
                                worksheet.Cell(cntrow + startRow, cntcol + startCol).SetValue(dValue)
                                    .Style.NumberFormat.SetFormat("0.00");
                            }
                            else
                            {
                                string strValue = value.ToString().TrimEnd();
                                // セルに値出力
                                worksheet.Cell(cntrow + startRow, cntcol + startCol).SetValue(strValue)
                                    .Style.NumberFormat.SetFormat("@");
                            }
                            #endregion

                            #region 型を見て、文字の配列を指定
                            // 値の型がSTRINGの場合
                            if (valueType.Equals("STRING"))
                            {
                                IXLCell targetcell = worksheet.Cell(cntrow + startRow, cntcol + startCol);
                                // 左揃え
                                targetcell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            }
                            // 値の型がINTまたはDECIMALの場合
                            else if (valueType.IndexOf("INT") > -1 || valueType.Equals("DECIMAL"))
                            {
                                IXLCell targetcell = worksheet.Cell(cntrow + startRow, cntcol + startCol);
                                // 右揃え
                                targetcell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            }
                            // 値の型がDATETIMEの場合
                            else if (valueType.IndexOf("DATETIME") > -1)
                            {
                                IXLCell targetcell = worksheet.Cell(cntrow + startRow, cntcol + startCol);
                                // 中央揃え
                                targetcell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            }
                            #endregion

                            // 列カウントアップ
                            cntcol++;
                        }

                    }
                    // 列カウントリセット
                    cntcol = 0;
                    // 行カウントアップ
                    cntrow++;
                }

                // ヘッダ挿入
                worksheet.Cell("A2").InsertData(new[] { header });
                // ヘッダ行の色を変える
                worksheet.Range(2, 1, 2, worksheet.LastColumnUsed().ColumnNumber()).Style.Fill.BackgroundColor = XLColor.LightGray;

                // 値が存在するセル範囲を取得
                var usedRange = worksheet.RangeUsed();
                // 使用している範囲のフォントサイズ指定
                usedRange.Style.Font.FontSize = 11;
                // 使用している範囲のフォントの種類を指定
                usedRange.Style.Font.FontName = "ＭＳ Ｐ明朝";
                // 全部の列の幅を自動調整
                worksheet.Columns().AdjustToContents();

                // 使用しているセルの範囲に罫線を引く
                usedRange.Style.Border.SetTopBorder(XLBorderStyleValues.Thin)
                               .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                               .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                               .Border.SetRightBorder(XLBorderStyleValues.Thin);

                // RangeUsedメソッドを使用してセルの範囲を取得するとタイトル部分まで取得してしまうため
                // タイトルのフォーマットは別で指定
                #region タイトル行の設定
                // タイトル挿入
                worksheet.Cell("A1").Value = functionName;
                // タイトルのみ大きくする
                worksheet.Cell("A1").Style.Font.FontSize = 20;
                // タイトルのフォントの種類を指定
                worksheet.Cell("A1").Style.Font.FontName = "ＭＳ Ｐ明朝";
                // タイトルセルを結合
                worksheet.Range(1, 1, 1, worksheet.LastColumnUsed().ColumnNumber()).Merge();
                #endregion

                // ヘッダとタイトルを中央揃え
                worksheet.Range(1, 1, 2, worksheet.LastColumnUsed().ColumnNumber()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // 保存
                currentWorkbook.SaveAs(outXlsFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                currentWorkbook.Dispose();
            }
        }

    }
}
