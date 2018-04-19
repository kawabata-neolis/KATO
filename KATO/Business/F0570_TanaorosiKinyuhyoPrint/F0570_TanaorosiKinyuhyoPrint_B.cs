using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;
using System.Runtime.InteropServices;

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
        public string dbToPdf(DataTable dtTanaorosi, List<string> lstItem, string p)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/F0570_TanaoroshiPreSheet.xlsx";
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbooks objWorkBooks = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkBook = null;
            Microsoft.Office.Interop.Excel.Worksheet objWorkSheet = null;
            Microsoft.Office.Interop.Excel.Range objRange = null;


            try
            {
                CreatePdf pdf = new CreatePdf();

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

                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);
                IXLWorksheet templatesheet1 = workbook.Worksheet(1);   // テンプレートシート
                IXLWorksheet currentsheet = null;  // 処理中シート

                int pageCnt = 0;    // ページ(シート枚数)カウント
                int xlsRowCnt = 6;  // Excel出力行カウント（開始は出力行）

                templatesheet1.CopyTo("Page" + pageCnt.ToString());
                currentsheet = workbook.Worksheet(1);

                currentsheet.Cell(2, "A").Value = "棚卸プレシート";
                currentsheet.Cell(4, "A").Value = "  " + dtChkList.Rows[0][6].ToString() + "    " + dtChkList.Rows[0][7].ToString().Trim();
                currentsheet.Cell(4, "E").Value = "棚卸日：" + string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[0]));

                string strDaibunruiCd = "";

                foreach (DataRow drTanaorosi in dtChkList.Rows)
                {
                    // 大分類コードが違う場合
                    if (!string.IsNullOrWhiteSpace(strDaibunruiCd) && !strDaibunruiCd.Equals(drTanaorosi[5].ToString()))
                    {
                        pageCnt++;
                        xlsRowCnt = 6;
                        strDaibunruiCd = drTanaorosi[5].ToString();

                        // テンプレートシートからコピー
                        templatesheet1.CopyTo("Page" + pageCnt.ToString());
                        currentsheet = workbook.Worksheet(workbook.Worksheets.Count);

                        currentsheet.Cell(2, "A").Value = "棚卸プレシート";
                        currentsheet.Cell(4, "A").Value = "  " + drTanaorosi[6].ToString() + "    " + drTanaorosi[7].ToString().Trim();
                        currentsheet.Cell(4, "E").Value = "棚卸日：" + string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[0]));
                    }

                    if (xlsRowCnt >= 51)
                    {
                        pageCnt++;
                        xlsRowCnt = 6;
                        strDaibunruiCd = drTanaorosi[5].ToString();

                        // テンプレートシートからコピー
                        templatesheet1.CopyTo("Page" + pageCnt.ToString());
                        currentsheet = workbook.Worksheet(workbook.Worksheets.Count);

                        currentsheet.Cell(2, "A").Value = "棚卸プレシート";
                        currentsheet.Cell(4, "A").Value = "  " + drTanaorosi[6].ToString() + "    " + drTanaorosi[7].ToString().Trim();
                        currentsheet.Cell(4, "E").Value = "棚卸日：" + string.Format("{0:yyyy年MM月dd日}", DateTime.Parse(lstItem[0]));
                    }

                    currentsheet.Cell(xlsRowCnt, "A").Value = drTanaorosi[0].ToString();
                    currentsheet.Cell(xlsRowCnt, "B").Value = drTanaorosi[1].ToString();
                    currentsheet.Cell(xlsRowCnt, "C").Value = drTanaorosi[2].ToString();
                    currentsheet.Cell(xlsRowCnt, "D").Value = drTanaorosi[3].ToString();
                    currentsheet.Cell(xlsRowCnt, "E").Value = drTanaorosi[4].ToString();

                    xlsRowCnt++;
                }

                // テンプレートシート削除
                templatesheet1.Delete();

                // ページ数設定
                for (pageCnt = 1; pageCnt <= workbook.Worksheets.Count; pageCnt++)
                {
                    string s = "'" + pageCnt.ToString() + "/" + (workbook.Worksheets.Count).ToString();
                    workbook.Worksheet(pageCnt).Cell("E1").Value = s;      // No.
                }

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                objExcel = new Microsoft.Office.Interop.Excel.Application();

                objExcel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized;
                objExcel.Visible = false;
                objExcel.DisplayAlerts = false;

                objWorkBooks = objExcel.Workbooks;

                String strP = System.IO.Path.GetFullPath(strOutXlsFile);

                objWorkBook = objWorkBooks.Open(strP, //_xslFile,     // FileName:ファイル名
                                                Type.Missing, // UpdateLinks:ファイル内の外部参照の更新方法
                                                Type.Missing, // ReadOnly:ReadOnlyにするかどうか
                                                Type.Missing, // Format: テキストファイルを開く場合に区切り文字を指定する
                                                Type.Missing, // Password:開く際にパスワードがある場合にパスワードを入力
                                                Type.Missing, // WriteResPassword:書き込む際にパスワードがある場合にパスワードを入力
                                                Type.Missing, // IgnoreReadOnlyRecommended:[読み取り専用を推奨する]チェックがオンの場合でも[読み取り専用を推奨する]メッセージを非表示
                                                Type.Missing, // Origin:テキストファイルの場合、プラットフォームを指定
                                                Type.Missing, // Delimiter:テキストファイルで且つ引数Formatが6の場合に区切り文字を指定
                                                Type.Missing, // Editable:Excel4.0アドインの場合、アドインウィンドウを出すか指定
                                                Type.Missing, // Notify:ファイルが読み取りor書き込みモードで開けない場合に通知リストに追加するか指定
                                                Type.Missing, // Converter:ファイルを開くときに最初に使用するファイルコンバーターのインデックス番号を指定
                                                Type.Missing, // AddToMru:最近使用したファイルの一覧にブックを追加するか指定
                                                Type.Missing, // Local:Excel言語設定に合わせてファイルを保存するか指定
                                                Type.Missing  // CorruptLoad:使用できる定数は[xlNormalLoad][xlRepairFile][xlExtractData]。指定がない場合のは[xlNormalLoad]になりOMを通じて開始するときに回復は行われません。
                                                );


                if (p != null)
                {
                    objWorkBook.PrintOut(Type.Missing, // From:印刷開始のページ番号
                                          Type.Missing, // To:印刷終了のページ番号
                                          1,            // Copies:印刷部数
                                          Type.Missing, // Preview:印刷プレビューをするか指定
                                          p, // ActivePrinter:プリンターの名称
                                          Type.Missing, // PrintToFile:ファイル出力をするか指定
                                          true,         // Collate:部単位で印刷するか指定
                                          Type.Missing  // PrToFileName	:出力先ファイルの名前を指定するかどうか
                                          );
                }

                //for (int i = 0; i < objWorkBook.Sheets.Count; i++)
                //{
                //    objWorkSheet = objWorkBook.Sheets[i + 1];

                //    if (p != null)
                //    {
                //        objWorkSheet.PrintOut(Type.Missing, // From:印刷開始のページ番号
                //                          Type.Missing, // To:印刷終了のページ番号
                //                          1,            // Copies:印刷部数
                //                          Type.Missing, // Preview:印刷プレビューをするか指定
                //                          p, // ActivePrinter:プリンターの名称
                //                          Type.Missing, // PrintToFile:ファイル出力をするか指定
                //                          true,         // Collate:部単位で印刷するか指定
                //                          Type.Missing  // PrToFileName	:出力先ファイルの名前を指定するかどうか
                //                          );
                //    }
                //}

                string ret = "";
                // PDF化の処理
                if (p == null)
                {
                    ret = pdf.createPdf(strOutXlsFile, strDateTime, 0);
                }
                //return pdf.createPdf(strOutXlsFile, strDateTime, 0);
                return ret;

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                throw;
            }
            finally
            {
                // EXCEL終了処理
                if (objWorkSheet != null)
                {
                    Marshal.ReleaseComObject(objWorkSheet);     // オブジェクト参照を解放
                    objWorkSheet = null;                        // オブジェクト解放
                }

                if (objWorkBook != null)
                {
                    objWorkBook.Close(false,
                        Type.Missing, Type.Missing);            //ファイルを閉じる
                    Marshal.ReleaseComObject(objWorkBook);      // オブジェクト参照を解放
                    objWorkBook = null;                         // オブジェクト解放
                }

                if (objWorkBooks != null)
                {
                    Marshal.ReleaseComObject(objWorkBooks);     // オブジェクト参照を解放
                    objWorkBooks = null;                        // オブジェクト解放
                }
                if (objExcel != null)
                {
                    objExcel.Quit();                            // EXCELを閉じる

                    Marshal.ReleaseComObject(objExcel);         // オブジェクト参照を解放
                    objExcel = null;                            // オブジェクト解放
                }

                System.GC.Collect();                            // オブジェクトを確実に削除
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
