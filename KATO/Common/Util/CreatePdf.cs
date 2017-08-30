using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.ComponentModel;

using Spire.Xls;

//iTextSharp関連の名前空間
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;

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
                strSpace + strNow + strSpace + page.ToString() + " / " + maxPage.ToString();

            return strHeader;
        }

    }
}
