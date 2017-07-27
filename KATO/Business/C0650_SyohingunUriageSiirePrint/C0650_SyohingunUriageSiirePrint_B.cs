using System;
using System.Collections.Generic;
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
using System.Data;
using KATO.Common.Util;

namespace KATO.Business.C0650_SyohingunUriageSiirePrint
{
    class C0650_SyohingunUriageSiirePrint_B
    {
        /// <summary>
        /// getSyohingunUriageSiireItiran
        /// 商品群売上仕入一覧を取得
        /// </summary>
        public DataTable getSyohingunUriageSiireItiran(List<string> lstString)
        {
            DataTable DtRet = new DataTable();

            List<string> lstTableName = new List<string>();
            lstTableName.Add("@上期開始年月日");
            lstTableName.Add("@上期終了年月日");
            lstTableName.Add("@下期開始年月日");
            lstTableName.Add("@下期終了年月日");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(lstString[0]);
            lstDataName.Add(lstString[1]);
            lstDataName.Add(lstString[2]);
            lstDataName.Add(lstString[3]);

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                //請求一覧表_PROCを実行
                DtRet = dbconnective.RunSqlReDT("商品群別売上仕入管理表_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, null);


                // コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                new CommonException(ex);

                // ロールバック処理
                dbconnective.Rollback();
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return DtRet;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtSyohingunUriageSiire">
        ///     仕入推移表のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSyohingunUriageSiire)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                string strHeader = "";
                string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                string strSpace = "       ";
                string strComputerName = System.Windows.Forms.SystemInformation.ComputerName;

                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled);

                // ワークブックのデフォルトフォント、フォントサイズの指定
                XLWorkbook.DefaultStyle.Font.FontName = "ＭＳ 明朝";
                XLWorkbook.DefaultStyle.Font.FontSize = 9;

                IXLWorksheet worksheet = workbook.Worksheets.Add("Header");
                IXLWorksheet headersheet = worksheet;   // ヘッダーシート
                IXLWorksheet currentsheet = worksheet;  // 処理中シート


                //Linqで必要なデータをselect
                var outDataAll = dtSyohingunUriageSiire.AsEnumerable()
                    .Select(dat => new
                    {
                        daibunruiCd = dat["大分類コード"],
                        daibunruiName = dat["大分類名"],
                        chubunruiName = dat["中分類名"],
                        kamikiUriagegaku = (decimal)dat["上期売上額"],
                        kamikiSiiregaku = (decimal)dat["上期仕入額"],
                        simokiUriagegaku = (decimal)dat["下期売上額"],
                        simokiSiiregaku = (decimal)dat["下期仕入額"],
                        goukeiUriagegaku = (decimal)dat["合計売上額"],
                        goukeiSiiregaku = (decimal)dat["合計仕入額"],
                    }).ToList();

                // linqで売上額（上期、下期、合計）、仕入額（上期、下期、合計）を算出
                decimal[] decKingaku = new decimal[13];
                decKingaku[0] = outDataAll.Select(gokei => gokei.kamikiUriagegaku).Sum();
                decKingaku[1] = outDataAll.Select(gokei => gokei.kamikiSiiregaku).Sum();
                decKingaku[2] = outDataAll.Select(gokei => gokei.simokiUriagegaku).Sum();
                decKingaku[3] = outDataAll.Select(gokei => gokei.simokiSiiregaku).Sum();
                decKingaku[4] = outDataAll.Select(gokei => gokei.goukeiUriagegaku).Sum();
                decKingaku[5] = outDataAll.Select(gokei => gokei.goukeiSiiregaku).Sum();

                // 大分類計（小計）
                var daibunruiGoukei = from tbl in dtSyohingunUriageSiire.AsEnumerable()
                                  group tbl by tbl.Field<string>("大分類コード") into g
                                  select new
                                  {
                                      section = g.Key,
                                      count = g.Count(),
                                      kamikiUriagegaku = g.Sum(p => p.Field<decimal>("上期売上額")),
                                      kamikiSiiregaku = g.Sum(p => p.Field<decimal>("上期仕入額")),
                                      simokiUriagegaku = g.Sum(p => p.Field<decimal>("下期売上額")),
                                      simokiSiiregaku = g.Sum(p => p.Field<decimal>("下期仕入額")),
                                      goukeiUriagegaku = g.Sum(p => p.Field<decimal>("合計売上額")),
                                      goukeiSiiregaku = g.Sum(p => p.Field<decimal>("合計仕入額")),
                                  };

                // 大分類計（小計）の売上額（上期、下期、合計）、仕入額（上期、下期、合計）を算出
                decimal[,] decKingakuDaibunrui = new decimal[daibunruiGoukei.Count(), 13];
                for (int cnt = 0; cnt < daibunruiGoukei.Count(); cnt++)
                {
                    decKingakuDaibunrui[cnt, 0] = daibunruiGoukei.ElementAt(cnt).kamikiUriagegaku;
                    decKingakuDaibunrui[cnt, 1] = daibunruiGoukei.ElementAt(cnt).kamikiSiiregaku;
                    decKingakuDaibunrui[cnt, 2] = daibunruiGoukei.ElementAt(cnt).simokiUriagegaku;
                    decKingakuDaibunrui[cnt, 3] = daibunruiGoukei.ElementAt(cnt).simokiSiiregaku;
                    decKingakuDaibunrui[cnt, 4] = daibunruiGoukei.ElementAt(cnt).goukeiUriagegaku;
                    decKingakuDaibunrui[cnt, 5] = daibunruiGoukei.ElementAt(cnt).goukeiSiiregaku;
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
                maxRowCnt += daibunruiGoukei.Count() + 1;
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

                int daibunruiCnt = 0;
                int daibunruiRowCnt = 0;
                
                string strSiireCode = "";

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drSyohingunUriageSiire in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "商品群別売上仕入管理表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 14;
                        headersheet.Range("A1", "H1").Merge();
                        
                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "大分類名";
                        headersheet.Cell("B3").Value = "中分類名";
                        headersheet.Cell("C3").Value = "上期売上高";
                        headersheet.Cell("D3").Value = "上期仕入高";
                        headersheet.Cell("E3").Value = "下期売上高";
                        headersheet.Cell("F3").Value = "下期仕入高";
                        headersheet.Cell("G3").Value = "合計売上高";
                        headersheet.Cell("H3").Value = "合計仕入高";
                        
                        // ヘッダー列
                        headersheet.Range("A3", "H3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "H3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // 列幅の指定
                        headersheet.Column(1).Width = 20;
                        headersheet.Column(2).Width = 20;
                        headersheet.Column(3).Width = 20;
                        headersheet.Column(4).Width = 20;
                        headersheet.Column(5).Width = 20;
                        headersheet.Column(6).Width = 20;
                        headersheet.Column(7).Width = 20;
                        headersheet.Column(8).Width = 20;

                        // 印刷体裁（B4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.B4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№65）");

                        // ヘッダーシートからコピー
                        headersheet.CopyTo("Page1");
                        currentsheet = workbook.Worksheet(2);

                        // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
                        strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                            pageCnt.ToString() + " / " + maxPage.ToString();
                        currentsheet.PageSetup.Header.Right.AddText(strHeader);

                    }

                    
                    // 大分類名出力
                    if (daibunruiRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt, 1).Value = drSyohingunUriageSiire[1];
                    }
                    
                    // 1セルずつデータ出力
                    for (int colCnt = 2; colCnt < maxColCnt; colCnt++)
                    {
                        string str = drSyohingunUriageSiire[colCnt].ToString();

                        // 金額セルの処理
                        if (colCnt >= 3 && colCnt <= 8)
                        {
                            // 3桁毎に","を挿入する
                            str = string.Format("{0:#,0}", decimal.Parse(str));
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, colCnt);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = str;
                        }
                        
                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;

                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt,8).Style
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

                            // コンピュータ名、日付、ページ数を取得
                            strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                                pageCnt.ToString() + " / " + maxPage.ToString();

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, strHeader);
                        }
                    }

                    // 大分類計(小計)を出力
                    daibunruiRowCnt++;
                    if (daibunruiGoukei.ElementAt(daibunruiCnt).count == daibunruiRowCnt)
                    {
                        xlsRowCnt++;
                        // セル結合、中央揃え
                        IXLCell tantocell = currentsheet.Cell(xlsRowCnt, 1);
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 2).Merge();
                        tantocell.Value = "◆　小　計　◆";
                        tantocell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                        // 金額セルの処理（3桁毎に","を挿入する）
                        for (int cnt = 0; cnt < 6; cnt++)
                        {
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, cnt + 3);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = string.Format("{0:#,0}", decKingakuDaibunrui[daibunruiCnt, cnt]);
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 8).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        daibunruiCnt++;
                        daibunruiRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
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
                    // セル結合、中央揃え
                    IXLCell sumcell = currentsheet.Cell(xlsRowCnt, 1);
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 2).Merge();
                    sumcell.Value = "◆　合　計　◆";
                    sumcell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                    // 金額セルの処理（3桁毎に","を挿入する）
                    for (int cnt = 0; cnt < 6; cnt++)
                    {
                        IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, cnt + 3);
                        kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        kingakuCell.Value = string.Format("{0:#,0}", decKingaku[cnt]);
                    }

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
            catch (Exception ex)
            {
                new CommonException(ex);
                throw ex;
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
                strJoinPdfFile = strPdfPath + strDateTime + ".pdf";

                // PDFファイル数が0でなければ結合
                if (filesMax != 0)
                {
                    fnJoinPdf(strFiles, strJoinPdfFile, 1);
                }

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw ex;
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
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                throw ex;
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
