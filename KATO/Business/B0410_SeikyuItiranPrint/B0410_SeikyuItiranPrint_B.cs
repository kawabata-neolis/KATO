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

namespace KATO.Business.B0410_SeikyuItiranPrint
{
    /// <summary>
    /// B0410_SeikyuItiranPrint_B
    /// 支払チェックリスト ビジネスロジック
    /// 作成者：
    /// 作成日：2017/7/25
    /// 更新者：
    /// 更新日：2017/7/25
    /// カラム論理名
    /// </summary>
    class B0410_SeikyuItiranPrint_B
    {
        /// <summary>
        /// getZengetuYokugetuSyutoku
        /// 締切年月日の前月翌月を取得
        /// </summary>
        public DataTable getZengetuYokugetuSyutoku(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            // データ渡し用
            List<string> lstStringSQL = new List<string>();


            // SQL文 請求履歴

            strSQLInput = strSQLInput + " SELECT dbo.f_前月翌日('"+lstString[0]+"') AS 前月翌月 ";

            // SQLのインスタンス作成
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

            return dtGetTableGrid;
        }

        /// <summary>
        /// getSeikyuItiran
        /// 請求書の一覧を取得
        /// </summary>
        public DataTable getSeikyuItiran(List<string> lstString)
        {
            DataTable DtRet = new DataTable();

            List<string> lstTableName = new List<string>();
            lstTableName.Add("@年月日");
            lstTableName.Add("@開始年月日");
            lstTableName.Add("@開始コード");
            lstTableName.Add("@終了コード");
            lstTableName.Add("@締切日");
            lstTableName.Add("@出力順");
            lstTableName.Add("@ユーザー名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(lstString[0]);
            lstDataName.Add(lstString[1]);
            lstDataName.Add(lstString[2]);
            lstDataName.Add(lstString[3]);
            lstDataName.Add(lstString[4]);
            lstDataName.Add(lstString[5]);
            lstDataName.Add(lstString[6]);

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 請求一覧表_PROCを実行
                DtRet = dbconnective.RunSqlReDT("請求一覧表_PROC",CommandType.StoredProcedure, lstDataName , lstTableName,null);


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
        /// <param name="dtSeikyuList">
        ///     請求一覧表のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSeikyuList, List<string> lstItem)
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


                // Linqで必要なデータをselect
                var outDataAll = dtSeikyuList.AsEnumerable()
                    .Select(dat => new
                    {
                        TokuisakiCd = dat["得意先コード"],
                        TokuisakiName = dat["得意先名"],
                        ZengetuUrikakezan = (decimal)dat["前月売掛残"],
                        NyukinGenkin = (decimal)dat["入金現金"],
                        NyukinKogitte = (decimal)dat["入金小切手"],
                        NyukinHurikomi = (decimal)dat["入金振込"],
                        NyukinTegata = (decimal)dat["入金手形"],
                        NyukinSousatu = (decimal)dat["入金相殺"],
                        NyukinTesuuryou = (decimal)dat["入金手数料"],
                        Nyukinsonota = (decimal)dat["入金その他"],
                        Kurikosizandaka = (decimal)dat["繰越残高"],
                        TougetuUriagedaka = (decimal)dat["当月売上高"],
                        TougetuSyohizei = (decimal)dat["当月消費税"],
                        TougetuZandaka = (decimal)dat["当月残高"],
                        Zeiku = dat["税区"]
                    }).ToList();

                // linqで前月売掛金、入金現金、入金小切手、入金振込、入金手形、入金相殺、入金手数料、
                // 入金その他、繰越残高、当月売上高、当月消費税、当月残高の合計算出
                decimal[] decKingaku = new decimal[13];
                decKingaku[0] = outDataAll.Select(gokei => gokei.ZengetuUrikakezan).Sum();
                decKingaku[1] = outDataAll.Select(gokei => gokei.NyukinGenkin).Sum();
                decKingaku[2] = outDataAll.Select(gokei => gokei.NyukinKogitte).Sum();
                decKingaku[3] = outDataAll.Select(gokei => gokei.NyukinHurikomi).Sum();
                decKingaku[4] = outDataAll.Select(gokei => gokei.NyukinTegata).Sum();
                decKingaku[5] = outDataAll.Select(gokei => gokei.NyukinSousatu).Sum();
                decKingaku[6] = outDataAll.Select(gokei => gokei.NyukinTesuuryou).Sum();
                decKingaku[7] = outDataAll.Select(gokei => gokei.Nyukinsonota).Sum();
                decKingaku[8] = outDataAll.Select(gokei => gokei.Kurikosizandaka).Sum();
                decKingaku[9] = outDataAll.Select(gokei => gokei.TougetuUriagedaka).Sum();
                decKingaku[10] = outDataAll.Select(gokei => gokei.TougetuSyohizei).Sum();
                decKingaku[11] = outDataAll.Select(gokei => gokei.TougetuZandaka).Sum();

                // リストをデータテーブルに変換
                DataTable dtChkList = this.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                double page = 1.0 * maxRowCnt / 37;
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
                foreach (DataRow dtSeikyuItiran in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "請求一覧表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "O1").Merge();

                        // 入力日、伝票年月日出力（A2のセル）
                        IXLCell unitCell = headersheet.Cell("A2");
                        unitCell.Value = "締切日：" + string.Format(lstItem[0], "yyyy年MM月dd日");
                        unitCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "コード";
                        headersheet.Cell("B3").Value = "得意先名";
                        headersheet.Cell("C3").Value = "前月売掛残";
                        headersheet.Cell("D3").Value = "入金現金";
                        headersheet.Cell("E3").Value = "入金小切手";
                        headersheet.Cell("F3").Value = "入金振込";
                        headersheet.Cell("G3").Value = "入金手形";
                        headersheet.Cell("H3").Value = "入金相殺";
                        headersheet.Cell("I3").Value = "入金手数料";
                        headersheet.Cell("J3").Value = "入金その他";
                        headersheet.Cell("K3").Value = "繰越残高";
                        headersheet.Cell("L3").Value = "当月売上高";
                        headersheet.Cell("M3").Value = "当月消費税";
                        headersheet.Cell("N3").Value = "当月残高";
                        headersheet.Cell("O3").Value = "税区分";

                        // ヘッダー列
                        headersheet.Range("A3", "O3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "O3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("A3", "O3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 5;
                        headersheet.Column(2).Width = 25;
                        headersheet.Column(3).Width = 10;
                        headersheet.Column(4).Width = 10;
                        headersheet.Column(5).Width = 10;
                        headersheet.Column(6).Width = 10;
                        headersheet.Column(7).Width = 10;
                        headersheet.Column(8).Width = 10;
                        headersheet.Column(9).Width = 10;
                        headersheet.Column(10).Width = 10;
                        headersheet.Column(11).Width = 10;
                        headersheet.Column(12).Width = 10;
                        headersheet.Column(13).Width = 10;
                        headersheet.Column(14).Width = 10;
                        headersheet.Column(15).Width = 7;

                        // 印刷体裁（B4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.B4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№41）");

                        // ヘッダーシートからコピー
                        headersheet.CopyTo("Page1");
                        currentsheet = workbook.Worksheet(2);

                        // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
                        strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                            pageCnt.ToString() + " / " + maxPage.ToString();
                        currentsheet.PageSetup.Header.Right.AddText(strHeader);

                    }


                    // ヘッダー行の場合
                    if (xlsRowCnt == 3)
                    {
                        // 出力行へ移動
                        xlsRowCnt++;
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = dtSeikyuItiran[colCnt - 1].ToString();
                        currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                        // 金額セルの処理
                        if (colCnt >= 3 && colCnt <= 14)
                        {
                            // 3桁毎に","を挿入する
                            str = string.Format("{0:#,0}", decimal.Parse(str));
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;

                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 15).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 44行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 40)
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


                    //// 44行毎（ヘッダーを除いた行数）にシート作成
                    //if (xlsRowCnt == 40)
                    //{
                    //    pageCnt++;
                    //    if (pageCnt <= maxPage)
                    //    {
                    //        xlsRowCnt = 3;

                    //        // コンピュータ名、日付、ページ数を取得
                    //        strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                    //            pageCnt.ToString() + " / " + maxPage.ToString();

                    //        // ヘッダーシートのコピー、ヘッダー部の指定
                    //        sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, strHeader);
                    //    }
                    //}

                    // 最終行を出力した後、合計行を出力
                    if (maxRowCnt == rowCnt)
                    {

                        // セル結合
                        currentsheet.Range(xlsRowCnt + 1, 1, xlsRowCnt + 1, 2).Merge();

                        currentsheet.Cell(xlsRowCnt + 1, 1).Value = "◆◆◆　合　計　◆◆◆";
                        currentsheet.Cell(xlsRowCnt + 1, 3).Value = string.Format("{0,14:#,0}", decKingaku[0]);
                        currentsheet.Cell(xlsRowCnt + 1, 4).Value = string.Format("{0,14:#,0}", decKingaku[1]);
                        currentsheet.Cell(xlsRowCnt + 1, 5).Value = string.Format("{0,14:#,0}", decKingaku[2]);
                        currentsheet.Cell(xlsRowCnt + 1, 6).Value = string.Format("{0,14:#,0}", decKingaku[3]);
                        currentsheet.Cell(xlsRowCnt + 1, 7).Value = string.Format("{0,14:#,0}", decKingaku[4]);
                        currentsheet.Cell(xlsRowCnt + 1, 8).Value = string.Format("{0,14:#,0}", decKingaku[5]);
                        currentsheet.Cell(xlsRowCnt + 1, 9).Value = string.Format("{0,14:#,0}", decKingaku[6]);
                        currentsheet.Cell(xlsRowCnt + 1, 10).Value = string.Format("{0,14:#,0}", decKingaku[7]);
                        currentsheet.Cell(xlsRowCnt + 1, 11).Value = string.Format("{0,14:#,0}", decKingaku[8]);
                        currentsheet.Cell(xlsRowCnt + 1, 12).Value = string.Format("{0,14:#,0}", decKingaku[9]);
                        currentsheet.Cell(xlsRowCnt + 1, 13).Value = string.Format("{0,14:#,0}", decKingaku[10]);
                        currentsheet.Cell(xlsRowCnt + 1, 14).Value = string.Format("{0,14:#,0}", decKingaku[11]);
                        currentsheet.Cell(xlsRowCnt + 1, 15).Value = "";

                        currentsheet.Cell(xlsRowCnt + 1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        currentsheet.Cell(xlsRowCnt + 1, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 1, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 1, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 1, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 1, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 1, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 1, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 1, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 1, 11).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 1, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 1, 13).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        currentsheet.Cell(xlsRowCnt + 1, 14).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt + 1, 1, xlsRowCnt + 1, 15).Style
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
