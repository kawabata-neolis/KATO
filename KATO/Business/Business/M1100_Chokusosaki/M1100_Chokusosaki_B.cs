using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClosedXML.Excel;
using KATO.Common.Util;

namespace KATO.Business.M1100_Chokusosaki
{
    ///<summary>
    ///M1100_Chokusosaki_B
    ///直送先のビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M1100_Chokusosaki_B
    {
        ///<summary>
        ///addChokusosaki
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addChokusosaki(List<string> lstString)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] {
                    lstString[0],
                    lstString[1],
                    lstString[2],
                    lstString[3],
                    lstString[4],
                    lstString[5],
                    lstString[6],
                    lstString[7],
                    "N",
                    DateTime.Now.ToString(),
                    lstString[8],
                    DateTime.Now.ToString(),
                    lstString[8]
                };

                //SQL接続、追加
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_CHOKUSOSAKI_UPD, aryStr);

                //コミット開始
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///delChokusosaki
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delChokusosaki(List<string> lstString)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] {
                    lstString[0],
                    lstString[1],
                    lstString[2],
                    lstString[3],
                    lstString[4],
                    lstString[5],
                    lstString[6],
                    lstString[7],
                    "Y",
                    DateTime.Now.ToString(),
                    lstString[8],
                    DateTime.Now.ToString(),
                    lstString[8]
                };

                //SQL接続、削除
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_CHOKUSOSAKI_UPD, aryStr);

                //コミット開始
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///setTxtChokusoLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable setTxtChokusoLeave(List<string> lstString)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstStringSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_Chokusosaki_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstString[0], lstString[1]);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getPrintData
        ///印刷前のデータ取得
        ///</summary>
        public DataTable getPrintData()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("M1100_Chokusosaki");
            lstSQL.Add("Chokusosaki_PrintData_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtSetCd_B_Input">
        ///     メーカーのデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSetCd_B_Input)
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
                var outDataAll = dtSetCd_B_Input.AsEnumerable()
                    .Select(dat => new
                    {
                        tokuiCd = (String)dat["得意先コード"],
                        tokuiName = dat["得意先名称"],
                        torihikchokusoCd = (String)dat["直送先コード"],
                        torihikchokusoNamed = (String)dat["直送先名"],
                        yubin = dat["郵便番号"],
                        jusho1 = dat["住所１"],
                        jusho2 = dat["住所２"],
                        denwa = dat["電話番号"],
                    }).ToList();

                //リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数
                int intTokuiCd = 0; // 得意先コード確保用

                //各セルの縦サイズ指定
                headersheet.RowHeight = 14;

                //ページ数計算
                double page = 1.0 * maxRowCnt / 47;
                double decimalpart = page % 1;
                if (decimalpart != 0)
                {
                    //小数点以下が0でない場合、+1
                    maxPage = (int)Math.Floor(page) + 1;
                }
                else
                {
                    maxPage = (int)page;
                }

                //ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drSiireCheak in dtChkList.Rows)
                {
                    //1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        //タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "直  送  先  一  覧  表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "F1").Merge();

                        //ヘッダー出力(表ヘッダー)
                        headersheet.Cell("A3").Value = "コード";
                        headersheet.Cell("B3").Value = "直送先名";
                        headersheet.Cell("C3").Value = "郵便番号";
                        headersheet.Cell("D3").Value = "住所１";
                        headersheet.Cell("E3").Value = "住所２";
                        headersheet.Cell("F3").Value = "電話番号";

                        //ヘッダー列
                        headersheet.Range("A3", "F3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "F3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("A3", "F3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 5;
                        headersheet.Column(2).Width = 40;
                        headersheet.Column(3).Width = 8;
                        headersheet.Column(4).Width = 35;
                        headersheet.Column(5).Width = 35;
                        headersheet.Column(6).Width = 12;

                        // 印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№110）");

                        //ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        //得意先コードが1回目の場合
                        if (intTokuiCd != int.Parse(drSiireCheak[0].ToString()))
                        {
                            string str = drSiireCheak[colCnt - 1].ToString();

                            //得意先コード
                            if (colCnt == 1)
                            {
                                //二桁の0パディングをさせる
                                currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("0000");

                                //左に寄せる
                                currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                                currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                            }
                            //得意先名称
                            else if (colCnt == 2)
                            {
                                //マージ
                                currentsheet.Range(xlsRowCnt, 2, xlsRowCnt, 6).Merge();

                                currentsheet.Cell(xlsRowCnt, colCnt).Value = str;

                                xlsRowCnt++;
                            }
                            //直送先コード
                            else if (colCnt == 3)
                            {
                                str = drSiireCheak[2].ToString();

                                //４桁の0パディングをさせる
                                currentsheet.Cell(xlsRowCnt, 1).Style.NumberFormat.SetFormat("0000");

                                //左に寄せる
                                currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                                currentsheet.Cell(xlsRowCnt, 1).Value = str;
                            }
                            //直送先名
                            else if(colCnt == 4)
                            {
                                str = drSiireCheak[3].ToString();

                                currentsheet.Cell(xlsRowCnt, 2).Value = str;
                            }
                            //郵便番号
                            else if (colCnt == 5)
                            {
                                str = drSiireCheak[4].ToString();

                                currentsheet.Cell(xlsRowCnt, 3).Value = str;
                            }
                            //住所１
                            else if (colCnt == 6)
                            {
                                str = drSiireCheak[5].ToString();

                                currentsheet.Cell(xlsRowCnt, 4).Value = str;
                            }
                            //住所２
                            else if (colCnt == 7)
                            {
                                str = drSiireCheak[6].ToString();

                                currentsheet.Cell(xlsRowCnt, 5).Value = str;
                            }
                            //電話番号
                            else if (colCnt == 8)
                            {
                                str = drSiireCheak[7].ToString();

                                currentsheet.Cell(xlsRowCnt, 6).Value = str;
                            }
                            
                            // 1行分のセルの周囲に罫線を引く
                            currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 6).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        }
                        //得意先コードが2回目以降の場合
                        else
                        {
                            string str = drSiireCheak[colCnt - 1].ToString();

                            //直送先コード
                            if (colCnt == 3)
                            {
                                str = drSiireCheak[2].ToString();

                                //４桁の0パディングをさせる
                                currentsheet.Cell(xlsRowCnt, 1).Style.NumberFormat.SetFormat("0000");

                                //左に寄せる
                                currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                                currentsheet.Cell(xlsRowCnt, 1).Value = str;
                            }
                            //直送先名
                            else if (colCnt == 4)
                            {
                                str = drSiireCheak[3].ToString();

                                currentsheet.Cell(xlsRowCnt, 2).Value = str;
                            }
                            //郵便番号
                            else if (colCnt == 5)
                            {
                                str = drSiireCheak[4].ToString();

                                currentsheet.Cell(xlsRowCnt, 3).Value = str;
                            }
                            //住所１
                            else if (colCnt == 6)
                            {
                                str = drSiireCheak[5].ToString();

                                currentsheet.Cell(xlsRowCnt, 4).Value = str;
                            }
                            //住所２
                            else if (colCnt == 7)
                            {
                                str = drSiireCheak[6].ToString();

                                currentsheet.Cell(xlsRowCnt, 5).Value = str;
                            }
                            //電話番号
                            else if (colCnt == 8)
                            {
                                str = drSiireCheak[7].ToString();

                                currentsheet.Cell(xlsRowCnt, 6).Value = str;
                            }

                            // 1行分のセルの周囲に罫線を引く
                            currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 6).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);
                        }
                    }

                    //得意先コードを確保
                    intTokuiCd = int.Parse(drSiireCheak[0].ToString());


                    // 34行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 34)
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
            catch (Exception ex)
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
