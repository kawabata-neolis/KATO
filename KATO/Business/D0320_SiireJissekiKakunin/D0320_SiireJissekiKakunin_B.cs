using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.Text;

using Spire.Xls;
using ClosedXML.Excel;

//iTextSharp関連の名前空間
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace KATO.Business.D0320_SiireJissekiKakunin
{
    /// D0320_SiireJissekiKakunin_B
    /// 仕入実績確認 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/5
    /// 更新者：多田
    /// 更新日：2017/7/5
    /// カラム論理名
    /// </summary>
    class D0320_SiireJissekiKakunin_B
    {

        /// <summary>
        /// getSiireJissekiList
        /// 仕入実績を取得
        /// </summary>
        public DataTable getSiireJissekiList(List<string> lstItem)
        {
            string strSql;
            DataTable dtGetTableGrid = new DataTable();


            strSql = "SELECT a.伝票年月日,a.伝票番号,b.行番号,";
            strSql += "c.メーカー名 AS メーカー,";
            strSql += "RTRIM(ISNULL(d.中分類名,'')) +  ' '  +  Rtrim(ISNULL(b.Ｃ１,'')) ";
            strSql += " + ' ' + Rtrim(ISNULL(b.Ｃ２,''))";
            strSql += " + ' ' + Rtrim(ISNULL(b.Ｃ３,''))";
            strSql += " + ' ' + Rtrim(ISNULL(b.Ｃ４,''))";
            strSql += " + ' ' + Rtrim(ISNULL(b.Ｃ５,''))";
            strSql += " + ' ' + Rtrim(ISNULL(b.Ｃ６,'')) AS 品名型式 ,";
            strSql += "b.数量,b.仕入単価,b.仕入金額,b.備考,";
            strSql += "dbo.f_get受注番号_得意先名FROM受注 (dbo.f_get発注番号_受注番号FROM発注(b.発注番号)) AS 出荷先名,";
            strSql += "a.仕入先名,";
            strSql += "b.発注番号,";
            strSql += "b.備考,";
            strSql += "dbo.f_get発注番号から発注担当者(b.発注番号) AS 発注担当,";
            strSql += "dbo.f_get担当者名(a.担当者コード) AS 仕入担当,";
            strSql += "dbo.f_get発注番号_受注番号FROM発注(b.発注番号) AS 受注番号,";
            strSql += "dbo.f_get受注番号から受注単価(dbo.f_get発注番号_受注番号FROM発注(b.発注番号)) AS 受注単価,";
            strSql += "dbo.f_get受注番号から受注金額(dbo.f_get発注番号_受注番号FROM発注(b.発注番号)) AS 受注金額";

            strSql += " FROM 仕入ヘッダ a ,仕入明細 b, メーカー c, 中分類 d ";

            strSql += " WHERE a.削除 = 'N' AND a.伝票番号 = b.伝票番号 ";
            strSql += " AND b.メーカーコード = c.メーカーコード ";
            strSql += " AND b.大分類コード = d.大分類コード ";
            strSql += " AND b.中分類コード = d.中分類コード ";
            strSql += " AND a.伝票年月日 >='" + lstItem[0] + "'";
            strSql += " AND a.伝票年月日 <='" + lstItem[1] + "'";

            // 発注担当者がある場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND dbo.f_get発注番号から発注担当者(b.発注番号) = '" + lstItem[2] + "'";
            }

            // 仕入先コードがある場合
            if (!lstItem[3].Equals(""))
            {
                strSql += " AND a.仕入先コード = '" + lstItem[3] + "'";
            }

            // 大分類コードがある場合
            if (!lstItem[4].Equals(""))
            {
                strSql += " AND b.大分類コード = '" + lstItem[4] + "'";
            }

            // 中分類コードがある場合
            if (!lstItem[5].Equals(""))
            {
                strSql += " AND b.中分類コード = '" + lstItem[5] + "'";
            }

            // 型番がある場合
            if (!lstItem[6].Equals(""))
            {
                strSql += " AND (RTRIM(ISNULL(d.中分類名,'')) +  Rtrim(ISNULL(b.Ｃ１,'')) ";
                strSql += " +  Rtrim(ISNULL(b.Ｃ２,''))";
                strSql += " +  Rtrim(ISNULL(b.Ｃ３,''))";
                strSql += " +  Rtrim(ISNULL(b.Ｃ４,''))";
                strSql += " +  Rtrim(ISNULL(b.Ｃ５,''))";
                strSql += " +  Rtrim(ISNULL(b.Ｃ６,'')) ) LIKE '%" + lstItem[6] + "%' ";
            }

            // 備考がある場合
            if (!lstItem[7].Equals(""))
            {
                strSql += " AND b.備考 LIKE '%" + lstItem[7] + "%'";
            }


            // 得意先がある場合
            if (!lstItem[8].Equals(""))
            {
                strSql += " AND dbo.f_get受注番号_得意先コードFROM受注(dbo.f_get発注番号_受注番号FROM発注(b.発注番号)) = '" + lstItem[8] + "'";
            }

            // 営業所が本社の場合
            if (lstItem[9].Equals("1"))
            {
                strSql += " AND dbo.f_get発注番号から営業所コード(b.発注番号)='0001' ";
            }
            // 営業所が岐阜の場合
            else if (lstItem[9].Equals("2"))
            {
                strSql += " AND dbo.f_get発注番号から営業所コード(b.発注番号)='0002' ";
            }

            // 並び順（仕入日）の場合
            if (lstItem[10].Equals("0"))
            {
                // 並び順（A-Z）の場合
                if (lstItem[11].Equals("0"))
                {
                    strSql += " ORDER BY a.伝票年月日 ,b.発注番号,b.メーカーコード," +
                        "dbo.f_get中分類名(b.大分類コード,b.中分類コード) +  Rtrim(ISNULL(b.Ｃ１,''))" +
                        " + Rtrim(ISNULL(b.Ｃ２,''))  + Rtrim(ISNULL(b.Ｃ３,'')) + Rtrim(ISNULL(b.Ｃ４,''))" +
                        " + Rtrim(ISNULL(b.Ｃ５,'')) + Rtrim(ISNULL(b.Ｃ６,''))";
                }
                else
                {
                    strSql += " ORDER BY a.伝票年月日 DESC,b.発注番号,b.メーカーコード," +
                        "dbo.f_get中分類名(b.大分類コード,b.中分類コード) +  Rtrim(ISNULL(b.Ｃ１,''))" +
                        " + Rtrim(ISNULL(b.Ｃ２,''))  + Rtrim(ISNULL(b.Ｃ３,'')) + Rtrim(ISNULL(b.Ｃ４,''))" +
                        " + Rtrim(ISNULL(b.Ｃ５,'')) + Rtrim(ISNULL(b.Ｃ６,''))";
                }
            }
            // 並び順（注番）
            else if (lstItem[10].Equals("1"))
            {
                // 並び順（A-Z）の場合
                if (lstItem[11].Equals("0"))
                {
                    strSql += " ORDER BY b.発注番号 ,b.メーカーコード," +
                        "dbo.f_get中分類名(b.大分類コード,b.中分類コード) +  Rtrim(ISNULL(b.Ｃ１,''))" +
                        " + Rtrim(ISNULL(b.Ｃ２,''))  + Rtrim(ISNULL(b.Ｃ３,'')) + Rtrim(ISNULL(b.Ｃ４,''))" +
                        " + Rtrim(ISNULL(b.Ｃ５,'')) + Rtrim(ISNULL(b.Ｃ６,''))";
                }
                else
                {
                    strSql += " ORDER BY b.発注番号  DESC,b.メーカーコード," +
                        "dbo.f_get中分類名(b.大分類コード,b.中分類コード) +  Rtrim(ISNULL(b.Ｃ１,''))" +
                        " + Rtrim(ISNULL(b.Ｃ２,''))  + Rtrim(ISNULL(b.Ｃ３,'')) + Rtrim(ISNULL(b.Ｃ４,''))" +
                        " + Rtrim(ISNULL(b.Ｃ５,'')) + Rtrim(ISNULL(b.Ｃ６,''))";
                }
            }
            // 並び順（金額）
            else if (lstItem[10].Equals("2"))
            {
                // 並び順（A-Z）の場合
                if (lstItem[11].Equals("0"))
                {
                    strSql += " ORDER BY b.仕入金額,a.仕入先コード,dbo.f_get発注番号から発注担当者(b.発注番号)";
                }
                else
                {
                    strSql += " ORDER BY b.仕入金額 DESC,a.仕入先コード,dbo.f_get発注番号から発注担当者(b.発注番号)";
                }
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをデータテーブルへ格納
                dtGetTableGrid = dbconnective.ReadSql(strSql);

                return dtGetTableGrid;
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
        /// <param name="dtSiireJisseki">
        ///     仕入実績確認のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public void dbToPdf(DataTable dtSiireJisseki, List<string> lstItem)
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
                var outDataAll = dtSiireJisseki.AsEnumerable()
                    .Select(dat => new
                    {
                        denpyoYmd = dat["伝票年月日"],
                        denpyoNo = dat["伝票番号"],
                        maker = dat["メーカー"],
                        tantoName = dat["品名型式"],
                        suuryo = (decimal)dat["数量"],
                        tanka = (decimal)dat["仕入単価"],
                        kingaku = (decimal)dat["仕入金額"],
                        bikou = dat["備考"],
                        syukaName = dat["出荷先名"],
                        siireName = dat["仕入先名"],
                        hachuNo = dat["発注番号"],
                        hachuTanto = dat["発注担当"],
                        siireTanto = dat["仕入担当"],
                        juchuNo = dat["受注番号"]
                    }).ToList();

                // linqで仕入金額の合計算出
                decimal decKingaku = outDataAll.Select(gokei => gokei.kingaku).Sum();

                // リストをデータテーブルに変換
                DataTable dtChkList = this.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
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

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drSiireCheak in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "仕　入　実　績　確　認　表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "N1").Merge();

                        // 担当者名、仕入先名、伝票年月日、大分類名、中分類名、品名・型番、備考出力（A2のセル）
                        IXLCell unitCell = headersheet.Cell("A2");
                        unitCell.Value = "担当者：" + lstItem[2] + " 仕入先：" + lstItem[12] +
                            " 伝票年月日：" + lstItem[0] + "～" + lstItem[1] + " 大分類：" + lstItem[13] +
                            " 中分類：" + lstItem[14] + " 品名・型番：" + lstItem[6] + " 備考：" + lstItem[7];
                        unitCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "仕入日";
                        headersheet.Cell("B3").Value = "伝票番号";
                        headersheet.Cell("C3").Value = "メーカー";
                        headersheet.Cell("D3").Value = "品名･型式";
                        headersheet.Cell("E3").Value = "数量";
                        headersheet.Cell("F3").Value = "仕入単価";
                        headersheet.Cell("G3").Value = "仕入金額";
                        headersheet.Cell("H3").Value = "備考";
                        headersheet.Cell("I3").Value = "出荷先";
                        headersheet.Cell("J3").Value = "仕入先";
                        headersheet.Cell("K3").Value = "発注番号";
                        headersheet.Cell("L3").Value = "発注担当";
                        headersheet.Cell("M3").Value = "仕入担当";
                        headersheet.Cell("N3").Value = "受注番号";

                        // ヘッダー列
                        headersheet.Range("A3", "N3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "N3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("A3", "N3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 9;
                        headersheet.Column(2).Width = 8;
                        headersheet.Column(3).Width = 14;
                        headersheet.Column(4).Width = 50;
                        headersheet.Column(5).Width = 6;
                        headersheet.Column(6).Width = 8;
                        headersheet.Column(7).Width = 12;
                        headersheet.Column(8).Width = 8;
                        headersheet.Column(9).Width = 29;
                        headersheet.Column(10).Width = 29;
                        headersheet.Column(11).Width = 8;
                        headersheet.Column(12).Width = 10;
                        headersheet.Column(13).Width = 10;
                        headersheet.Column(14).Width = 8;

                        // 印刷体裁（A3横、印刷範囲、余白）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A3Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
                        headersheet.PageSetup.Margins.Left = 0.25;
                        headersheet.PageSetup.Margins.Right = 0.25;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№32）");

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
                        string str = drSiireCheak[colCnt - 1].ToString();

                        // 数量、金額セルの処理
                        if (colCnt >= 5 && colCnt <= 7)
                        {
                            // 3桁毎に","を挿入する
                            str = string.Format("{0:#,0}", decimal.Parse(str));
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 備考の場合、出力しないため何もしない
                        if (colCnt == 8)
                        {
                        }
                        else
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                        }
                        
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 14).Style
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

                    // 最終行を出力した後、合計行を出力
                    if (maxRowCnt == rowCnt)
                    {
                        // 3桁毎に","を挿入する
                        IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt + 1, 7);
                        kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        kingakuCell.Value = string.Format("{0:#,0}", decKingaku);

                        // セルの結合
                        currentsheet.Range(xlsRowCnt + 1, 1, xlsRowCnt + 1, 6).Merge();
                        currentsheet.Range(xlsRowCnt + 1, 8, xlsRowCnt + 1, 14).Merge();

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt + 1, 1, xlsRowCnt + 1, 14).Style
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにcsvファイルを作成</summary>
        /// <param name="dtSiireJisseki">
        ///     仕入実績確認のデータテーブル</param>
        /// <param name="strCsvPath">CSV出力パス</param>
        /// -----------------------------------------------------------------------------
        public void dbToCsv(DataTable dtSiireJisseki, string strCsvPath)
        {
            try
            {
                // 書き込むファイルを開く
                StreamWriter sw = new StreamWriter(strCsvPath, false, Encoding.GetEncoding("Shift_JIS"));

                // ヘッダー
                string strHeader = "仕入日,伝票番号,メーカー,品名・型式,数量,仕入単価,仕入金額," +
                    "備考,出荷先,仕入先,発注番号,発注担当,仕入担当,受注番号";

                sw.Write(strHeader);
                sw.Write("\r\n");

                string strDetail;

                // レコード
                foreach (DataRow drSiireJisseki in dtSiireJisseki.Rows)
                {
                    strDetail = string.Format("{0:yyyy/MM/dd}", drSiireJisseki["伝票年月日"].ToString()).Substring(0, 10) + ",";
                    strDetail += drSiireJisseki["伝票番号"].ToString() + ",";
                    strDetail += drSiireJisseki["メーカー"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["品名型式"].ToString().Trim() + ",";
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["数量"].ToString())) + ",";
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["仕入単価"].ToString())) + ",";
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["仕入金額"].ToString())) + ",";
                    strDetail += drSiireJisseki["備考"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["出荷先名"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["仕入先名"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["発注番号"].ToString() + ",";
                    strDetail += drSiireJisseki["発注担当"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["仕入担当"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["受注番号"].ToString();

                    sw.Write(strDetail);
                    sw.Write("\r\n");
                }

                // 閉じる
                sw.Close();
            }
            catch
            {
                throw;
            }

            return;
        }

    }
}
