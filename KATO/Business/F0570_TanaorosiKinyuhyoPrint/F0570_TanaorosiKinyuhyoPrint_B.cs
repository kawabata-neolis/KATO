using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;

namespace KATO.Business.F0570_TanaorosiKinyuhyoPrint
{
    /// <summary>
    /// F0570_TanaorosiKinyuhyoPrint_B
    /// 棚卸プレシート ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/31
    /// 更新者：多田
    /// 更新日：2017/7/31
    /// カラム論理名
    /// </summary>
    class F0570_TanaorosiKinyuhyoPrint_B
    {
        /// <summary>
        /// getTanaorosiCount
        /// 棚卸記入表の件数を取得
        /// </summary>
        public DataTable getTanaorosiCount(List<string> lstItem)
        {
            string strSql;
            DataTable dtTanaorosi = new DataTable();

            strSql = "SELECT COUNT(*) FROM 棚卸記入表 ";
            strSql += " WHERE 棚卸年月日 ='" + lstItem[0] + "'";
            strSql += " AND  営業所コード ='" + lstItem[1] + "'";

            // 大分類コードがある場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND 大分類コード ='" + lstItem[2] + "'";
            }

            // 中分類コードがある場合
            if (!lstItem[3].Equals(""))
            {
                strSql += " AND 中分類コード ='" + lstItem[3] + "'";
            }

            // メーカーコードがある場合
            if (!lstItem[4].Equals(""))
            {
                strSql += " AND メーカーコード ='" + lstItem[4] + "'";
            }

            // 棚番がある場合
            if (!lstItem[5].Equals("") && !lstItem[6].Equals(""))
            {
                strSql += " AND 棚番 >='" + lstItem[5] + "'";
                strSql += " AND 棚番 <='" + lstItem[6] + "'";
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtTanaorosi = dbconnective.ReadSql(strSql);

                return dtTanaorosi;
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

        /// <summary>
        /// getTanaorosi
        /// 棚卸記入表_PROCを実行
        /// </summary>
        public DataTable getTanaorosi(List<string> lstItem)
        {
            DataTable dtTanaorosi = new DataTable();

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 棚卸記入表_PROCを実行
                string strProc = "棚卸記入表_PROC '" + lstItem[0] + "', '" + lstItem[1] + "', ";

                // 大分類コードが空の場合
                if (lstItem[2].Equals(""))
                {
                    strProc += "NULL, ";
                }
                else
                {
                    strProc += "'" + lstItem[2] + "', ";
                }

                strProc += lstItem[3];

                // 棚卸記入表データ作成_PROCを実行
                dtTanaorosi = dbconnective.ReadSql(strProc);

                return dtTanaorosi;
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

        /// <summary>
        /// addTanaorosi
        /// 棚卸記入表データ作成_PROCを実行
        /// </summary>
        public void addTanaorosi(List<string> lstItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "棚卸記入表データ作成_PROC '" + lstItem[0] + "', '" + lstItem[1] + "', ";

                // 大分類コードが空の場合
                if (lstItem[2].Equals(""))
                {
                    strProc += "NULL, ";
                }
                else
                {
                    strProc += "'" + lstItem[2] + "', ";
                }

                strProc += "'" + Environment.UserName + "', ";

                // 中分類コードが空の場合
                if (lstItem[3].Equals(""))
                {
                    strProc += "NULL, ";
                }
                else
                {
                    strProc += "'" + lstItem[3] + "', ";
                }

                // メーカーコードが空の場合
                if (lstItem[4].Equals(""))
                {
                    strProc += "NULL, ";
                }
                else
                {
                    strProc += "'" + lstItem[4] + "', ";
                }

                // 棚番（開始）が空の場合
                if (lstItem[5].Equals(""))
                {
                    strProc += "NULL, ";
                }
                else
                {
                    strProc += "'" + lstItem[5] + "', ";
                }

                // 棚番（終了）が空の場合
                if (lstItem[6].Equals(""))
                {
                    strProc += "NULL";
                }
                else
                {
                    strProc += "'" + lstItem[6] + "'";
                }

                // 棚卸記入表データ作成_PROCを実行
                dbconnective.ReadSqlDelay(strProc, 1800);

                // コミット
                dbconnective.Commit();
            }
            catch
            {
                // ロールバック処理
                dbconnective.Rollback();
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return;
        }

        /// <summary>
        /// judTanaData
        /// 棚卸データの取得、判定
        /// </summary>
        public int judTanaData(string strYMD)
        {
            //本社データ確認用
            string strSQLHonSel = "";
            //本社データ確認用
            string strSQLGifuSel = "";

            //取り出したデータの確保用
            DataTable dtGetData = new DataTable();

            DBConnective dbconnective = new DBConnective();
            try
            {
                strSQLHonSel = "SELECT COUNT(*) FROM 棚卸記入表 ";
                strSQLHonSel = strSQLHonSel + " WHERE 営業所コード='0001' ";
                strSQLHonSel = strSQLHonSel + " AND 棚卸年月日='" + strYMD + "' ";

                // 本社棚卸データの検索を実行
                dtGetData = dbconnective.ReadSql(strSQLHonSel);

                //本社棚卸データがない場合
                if (dtGetData.Rows[0][0].ToString() == "0")
                {
                    return (1);
                }

                strSQLGifuSel = "SELECT COUNT(*) FROM 棚卸記入表 ";
                strSQLGifuSel = strSQLGifuSel + " WHERE 営業所コード='0002' ";
                strSQLGifuSel = strSQLGifuSel + " AND 棚卸年月日='" + strYMD + "' ";

                // 本社棚卸データの検索を実行
                dtGetData = dbconnective.ReadSql(strSQLGifuSel);

                //本社棚卸データがない場合
                if (dtGetData.Rows[0][0].ToString() == "0")
                {
                    return (2);
                }
                return (3);
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

        /// <summary>
        /// updTanaData
        /// 棚卸データの更新
        /// </summary>
        public void updTanaData(string strYMD, string strUser)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 棚卸更新_PROC(本社)を実行
                dbconnective.RunSql("棚卸更新_PROC '" + strYMD + "','" +
                                                          "0001" + "','" +
                                                          strUser + "'");

                // 棚卸更新_PROC(岐阜)を実行
                dbconnective.RunSql("棚卸更新_PROC '" + strYMD + "','" +
                                                          "0002" + "','" +
                                                          strUser + "'");

                // 棚卸更新_補足追加_PROCを実行
                dbconnective.RunSql("棚卸更新_補足追加_PROC '" + strYMD + "','" +
                                                          strUser + "'");

                // コミット
                dbconnective.Commit();

            }
            catch (Exception ex)
            {
                // ロールバック処理
                dbconnective.Rollback();
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtTanaorosi">
        ///     棚卸記入表のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtTanaorosi, List<string> lstItem)
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
                var outDataAll = dtTanaorosi.AsEnumerable()
                    .Select(dat => new
                    {
                        tanaban = dat["棚番"],
                        maker = dat["メーカー名"],
                        kataban = dat["品名型番"],
                        zaiko = (decimal)dat["指定日在庫"],
                        suryo = (decimal)dat["棚卸数量"],
                        daibunruiCd = dat["大分類コード"],
                        eigyo = dat["営業所名"],
                        daibunruiName = dat["大分類名"],
                        chubunruiName = dat["中分類名"]
                    }).ToList();

                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxColCnt = dtChkList.Columns.Count;
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 5;  // Excel出力行カウント（開始は出力行）

                string strDaibunruiCd = "";

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drTanaorosi in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "棚卸プレシート";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 14.5;
                        headersheet.Range("A1", "E1").Merge();

                        // 棚卸日出力（E3のセル）
                        IXLCell dateCell = headersheet.Cell("E3");
                        dateCell.Value = "棚卸日：" + string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[0]));
                        dateCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        dateCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（4行目のセル）
                        headersheet.Cell("A4").Value = "棚番";
                        headersheet.Cell("B4").Value = "メーカー名";
                        headersheet.Cell("C4").Value = "品　名　・　型　番";
                        headersheet.Cell("D4").Value = "帳簿在庫数";
                        headersheet.Cell("E4").Value = "棚　卸　数";

                        // ヘッダー列
                        headersheet.Range("A4", "E4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A4", "E4").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // 列幅の指定
                        headersheet.Column(1).Width = 10;
                        headersheet.Column(2).Width = 12;
                        headersheet.Column(3).Width = 50;
                        headersheet.Column(4).Width = 12;
                        headersheet.Column(5).Width = 12;

                        // 印刷体裁（A4縦、印刷範囲、余白）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Portrait;
                        headersheet.PageSetup.Margins.Left = 0.5;
                        headersheet.PageSetup.Margins.Right = 0.5;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№57）");
                    }

                    // 大分類コードが違う場合
                    if (!strDaibunruiCd.Equals(drTanaorosi[5].ToString()))
                    {
                        xlsRowCnt = 5;
                        strDaibunruiCd = drTanaorosi[5].ToString();

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);

                        // 営業所名、大分類名出力（A3のセル）
                        IXLCell unitCell = currentsheet.Cell("A3");
                        unitCell.Value = "  " + drTanaorosi[6].ToString() + "    " + drTanaorosi[7].ToString().Trim();
                        unitCell.Style.Font.FontSize = 10;
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt - 4; colCnt++)
                    {
                        string str = drTanaorosi[colCnt - 1].ToString();

                        // 入金額セルの処理
                        if (colCnt == 4 || colCnt == 5)
                        {
                            // 3桁毎に","を挿入する
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("#,##0");
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 5).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 45行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 49)
                    {
                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);

                        // 営業所名、大分類名出力（A3のセル）
                        IXLCell unitCell = currentsheet.Cell("A3");
                        unitCell.Value = "  " + drTanaorosi[6].ToString() + "    " + drTanaorosi[7].ToString().Trim();
                        unitCell.Style.Font.FontSize = 10;
                    }

                    rowCnt++;
                    xlsRowCnt++;
                }

                // ヘッダーシート削除
                headersheet.Delete();

                // 各ページのヘッダー部を指定
                int maxPage = workbook.Worksheets.Count;
                for (int pageCnt = 1; pageCnt <= maxPage; pageCnt++)
                {
                    // ヘッダー部に指定する情報を取得
                    string strHeader = pdf.getHeader(pageCnt, maxPage, strNow);

                    // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
                    workbook.Worksheet(pageCnt).PageSetup.Header.Right.AddText(strHeader);
                }

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // PDF化の処理
                return pdf.createPdf(strOutXlsFile, strDateTime, 0);

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
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
