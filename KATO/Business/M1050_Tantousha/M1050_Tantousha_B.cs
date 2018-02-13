using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClosedXML.Excel;
using KATO.Common.Util;

namespace KATO.Business.M1050_Tantousha
{

    ///<summary>
    ///M1050_Tantousha_B
    ///担当者のビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M1050_Tantousha_B
    {
        ///<summary>
        ///addDaibunrui
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addTantousha(List<string> lstString, bool dataFlag)
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
                    lstString[8],
                    lstString[9],
                    lstString[10],
                    lstString[11],
                    "N",
                    DateTime.Now.ToString(),
                    lstString[12],
                    DateTime.Now.ToString(),
                    lstString[12]
                };

                //SQL接続、追加
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_TANTOSHA_UPD, aryStr);

                //コミット開始
                dbconnective.Commit();

                //新規でメニュー権限を追加
                if (dataFlag)
                {
                    addKengen(lstString);
                }
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
        ///addKengen
        ///新規でメニュー権限を追加
        ///</summary>
        public void addKengen(List<string> lstString)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQLSelect = new List<string>();

            //SQLファイルのパスとファイル名を追加(メニュー権限取得)
            lstSQLSelect.Add("M1050_Tantousha");
            lstSQLSelect.Add("Tantousha_MenuKengen_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得(メニュー権限取得)
                string strSQLSelect = opensql.setOpenSQL(lstSQLSelect);

                //パスがなければ返す
                if (strSQLSelect == "")
                {
                    return;
                }

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLSelect);
                                
                //取得したメニュー権限分ループ
                for (int intCnt = 0; intCnt < dtSetCd_B.Rows.Count; intCnt++)
                {
                    string[] aryStrInsert = new string[] {
                    lstString[0],
                    dtSetCd_B.Rows[intCnt]["ＰＧ番号"].ToString(),
                    dtSetCd_B.Rows[intCnt]["ＰＧ名"].ToString(),
                    dtSetCd_B.Rows[intCnt]["権限"].ToString()
                    };

                    //SQL接続後、該当データを登録
                    dbconnective.RunSqlCommon("C_SQL_MENUKENGEN_UPD", aryStrInsert);
                }

                return;
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
        ///delTantosha
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delTantosha(List<string> lstString)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] {
                    lstString[0],                           // [担当者コード]
                    lstString[1],                           // [担当者名]
                    lstString[2],                           // [ログインＩＤ]
                    lstString[3],                           // [営業所コード]
                    lstString[4],                           // [注番文字]
                    lstString[5],                           // [グループコード]
                    lstString[6],                           // [年間売上目標]
                    lstString[7],                           // [マスタ権限]
                    lstString[8],                           // [閲覧権限]
                    lstString[9],                           // [利益率権限]
                    lstString[10],                          // [役職コード]
                    lstString[11],                          // [表示]
                    "Y",                                    // [削除]
                    DateTime.Now.ToString(),                // [登録日時]
                    lstString[12],                          // [登録ユーザー名]
                    DateTime.Now.ToString(),                // [更新日時]
                    lstString[12]                           // [更新ユーザー名]
                };

                //SQL接続、削除
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_TANTOSHA_UPD, aryStr);

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
        ///getTxtTantoshaLeave
        ///担当者code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable getTxtTantoshaLeave(string strTantousha)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Tantousha_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strTantousha);

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
        ///getTxtYakushokuLeave
        ///役職code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable getTxtYakushokuLeave(string strYakushokuCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Yakushoku_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strYakushokuCd);

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
            lstSQL.Add("M1050_Tantousha");
            lstSQL.Add("Tantousha_PrintData_SELECT");

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
        ///     担当者のデータテーブル</param>
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
                XLWorkbook.DefaultStyle.Font.FontName = "ＭＳ ゴシック";
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
                        tantoushaCd = dat["担当者コード"],
                        tantoushaName = dat["担当者名"],
                        loginID = dat["営業所名"],
                        eigyoshoCd = dat["グループ名"],
                        chubanmoji = dat["年間売上目標"],
                        groupCd = dat["注番文字"],
                    }).ToList();

                //リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

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
                        titleCell.Value = "担当者マスタリスト";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "C1").Merge();

                        //ヘッダー出力(表ヘッダー)
                        headersheet.Cell("A3").Value = "コード";
                        headersheet.Cell("B3").Value = "担当者名";
                        headersheet.Cell("C3").Value = "営業所名";
                        headersheet.Cell("D3").Value = "グループ名";
                        headersheet.Cell("E3").Value = "年間目標金額";
                        headersheet.Cell("F3").Value = "注番文字";

                        //ヘッダー列
                        headersheet.Range("A3", "F3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // 列幅の指定
                        headersheet.Column(1).Width = 12;
                        headersheet.Column(2).Width = 20;
                        headersheet.Column(3).Width = 17;
                        headersheet.Column(4).Width = 17;
                        headersheet.Column(5).Width = 17;
                        headersheet.Column(6).Width = 17;

                        // セルの周囲に罫線を引く(細い方)
                        headersheet.Range("A3", "C3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin);
                            //.Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの周囲に罫線を引く(太い方)
                        headersheet.Range("D3", "F3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Medium)
                            .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                            .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                            .Border.SetRightBorder(XLBorderStyleValues.Medium);

                        // 印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Default;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№104）");

                        //ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drSiireCheak[colCnt - 1].ToString();

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;

                        //コードのカラムの場合
                        if (colCnt == 1)
                        {
                            //二桁の0パディングをさせる
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("0000");

                            //中心にする
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        //年間目標金額のカラムの場合
                        if (colCnt == 5)
                        {
                            //二桁の0パディングをさせる
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("#,0");
                        }

                        string strKari = currentsheet.Cell(xlsRowCnt, colCnt).Value.ToString();
                    }

                    // 1行分のセルの周囲に罫線を引く(細い方)
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 3).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin);

                    // 1行分のセルの周囲に罫線を引く(太い方)
                    currentsheet.Range(xlsRowCnt, 4, xlsRowCnt, 6).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Medium)
                            .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                            .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                            .Border.SetRightBorder(XLBorderStyleValues.Medium);
                    
                    // 47行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 47)
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
