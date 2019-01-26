using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.B1580_ShiharaiInput
{
    class B1580_ShiharaiInput_B
    {

        ///<summary>
        ///setGridTokusaiki
        ///得意先グリッドのデータ取得
        ///</summary>
        public DataTable getShiharaiList(List<string> lstItem)
        {
            string strSql;
            DataTable dtShiharaiCheakList = new DataTable();

            strSql = "SELECT TOP 5000 S.支払年月日 AS 伝票年月日, ";
            strSql += "S.行番号, ";
            strSql += "T.締切日, ";
            strSql += "S.仕入先コード, ";
            strSql += "T.取引先名称 AS 仕入先名,";
            strSql += "S.手形期日 AS 支払予定日, ";
            strSql += "T.支払日, ";
            strSql += "S.伝票番号, ";
            strSql += "S.取引区分コード, ";
            strSql += "dbo.f_get取引区分名(S.取引区分コード) AS 取引区分名, ";
            strSql += "CASE WHEN Rtrim(ISNULL(S.口座,'')) = '' THEN '当' ELSE S.口座 END AS 口座,";
            strSql += "CASE WHEN Rtrim(ISNULL(S.金融機関名,'')) = '' THEN '第三銀行' ELSE S.金融機関名 END AS 金融機関名,";
            strSql += "CASE WHEN Rtrim(ISNULL(S.支店名,'')) = '' THEN '中川' ELSE S.支店名 END AS 支店名,";
            strSql += "CONVERT(CHAR, ROUND(S.支払額, 0), 126) AS 支払予定額,";
            strSql += "CONVERT(CHAR, ROUND(S.支払額, 0), 126) AS 支払額, ";
            strSql += "S.手形期日, ";
            strSql += "T.支払月数 AS 支払月数,";
            strSql += "T.支払条件 AS 支払条件,";
            strSql += "T.集金区分 AS 集金区分,";
            strSql += "T.消費税端数計算区分,";
            strSql += "S.廻し先,";
            strSql += "S.廻し先日付,";
            strSql += "S.備考, ";
            strSql += "S.支払額 AS 額 ";
            strSql += " FROM 支払 S, 取引先 T";
            strSql += " WHERE S.削除 ='N' ";
            strSql += "   AND T.削除 ='N' ";
            strSql += "   AND S.仕入先コード = T.取引先コード ";

            // 入力年月日（開始）がある場合
            if (!lstItem[0].Equals(""))
            {
                strSql += " AND CONVERT(VARCHAR(10),S.更新日時,111) >='" + lstItem[0] + "'";
                strSql += " AND CONVERT(VARCHAR(10),S.更新日時,111) <='" + lstItem[1] + "'";
            }

            // 伝票年月日（開始）がある場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND S.支払年月日 >='" + lstItem[2] + "'";
                strSql += " AND S.支払年月日 <='" + lstItem[3] + "'";
            }

            // ユーザーIDがある場合
            if (!lstItem[4].Equals(""))
            {
                strSql += " AND S.更新ユーザー名='" + lstItem[4] + "'";
            }

            // 仕入先コードがある場合
            if (!lstItem[5].Equals("") && !lstItem[6].Equals(""))
            {
                strSql += " AND S.仕入先コード >='" + lstItem[5] + "'";
                strSql += " AND S.仕入先コード <='" + lstItem[6] + "'";
            }

            if (!lstItem[7].Equals(""))
            {
                strSql += " AND S.取引区分コード IN (" + lstItem[7] + ")";
            }

            if (!lstItem[8].Equals(""))
            {
                strSql += " AND S.手形期日 >='" + lstItem[8] + "'";
            }

            if (!lstItem[9].Equals(""))
            {
                strSql += " AND S.手形期日 <='" + lstItem[9] + "'";
            }

            if (!lstItem[12].Equals(""))
            {
                strSql += " AND S.金融機関名 like '%" + lstItem[12] + "%'";
            }

            if (!lstItem[13].Equals(""))
            {
                strSql += " AND S.支店名 like '%" + lstItem[13] + "%'";
            }

            if (!lstItem[14].Equals(""))
            {
                strSql += " AND S.口座 like '%" + lstItem[14] + "%'";
            }

            strSql += " ORDER BY S.支払年月日,S.伝票番号,S.行番号";



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

        // 登録
        public void addShiire(List<string[]> lsInput)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                for (int cnt = 0; cnt < lsInput.Count; cnt++)
                {
                    string[] strs = lsInput[cnt];
                    // 支払消去_PROCを実行
                    dbconnective.ReadSql("支払消去2_PROC '" + strs[0] + "', '" + strs[1] + "', '" + strs[10] + "'");

                    string strProc = "支払追加2_PROC '" + strs[0] + "', '" + strs[1] + "', '" +
                        strs[2] + "', '" + strs[3] + "', '" + strs[4] + "', '" +
                        strs[5] + "', ";

                    // 支払期日がない場合
                    if (strs[6].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[6] + "', ";
                    }

                    // 備考がない場合
                    if (strs[7].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[7] + "', ";
                    }

                    if (strs[8].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[8] + "', ";
                    }

                    if (strs[9].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[9] + "', ";
                    }



                    if (strs[10].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[10] + "', ";
                    }

                    if (strs[11].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[11] + "', ";
                    }

                    if (strs[12].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[12] + "', ";
                    }

                    strProc += "'" + strs[13] + "'";

                    // 支払追加_PROCを実行
                    dbconnective.ReadSql(strProc);
                }
                // コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                // ロールバック処理
                dbconnective.Rollback();
                //new CommonException(ex);
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        // 削除
        public void delShiire(string[] strs)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                dbconnective.ReadSql("支払全削除2_PROC '" + strs[0] + "', '" + strs[1] + "', '" + strs[2] + "'");
                // コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                // ロールバック処理
                dbconnective.Rollback();
                //new CommonException(ex);
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        // 印刷用ファイル作成
        public string dbToPdf(DataTable dtShiharaiCheakList, List<string> lstItem)
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
                var outDataAll = dtShiharaiCheakList.AsEnumerable()
                    .Select(dat => new
                    {
                        siiresakiCd = dat["仕入先コード"],
                        siiresakiName = dat["仕入先名"],
                        shiharaiYmd = dat["伝票年月日"],
                        denpyoNo = dat["伝票番号"],
                        bunruiName = dat["取引区分名"],
                        koza = dat["口座"],
                        kinyuKikan = dat["金融機関名"],
                        kingaku = dat["支払額"],
                        kijitsu = dat["手形期日"],
                        bikou = dat["備考"],
                        gaku = (decimal)dat["額"]
                    }).ToList();

                // linqで税抜合計金額、消費税、税込合計金額の合計算出
                decimal decKingaku = outDataAll.Select(gokei => gokei.gaku).Sum();

                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count - 1;
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
                        headersheet.Range("A1", "J1").Merge();

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

                        headersheet.Cell("F3").Value = "口座";
                        headersheet.Cell("G3").Value = "金融機関";

                        headersheet.Cell("H3").Value = "支払額";
                        headersheet.Cell("I3").Value = "手形期日";
                        headersheet.Cell("J3").Value = "備　　考";

                        // ヘッダー列
                        headersheet.Range("A3", "J3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "J3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("A3", "J3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 5;
                        headersheet.Column(2).Width = 30;
                        headersheet.Column(3).Width = 11;
                        headersheet.Column(4).Width = 8;
                        headersheet.Column(5).Width = 10;
                        headersheet.Column(6).Width = 4;
                        headersheet.Column(7).Width = 13;
                        headersheet.Column(8).Width = 12;
                        headersheet.Column(9).Width = 11;
                        headersheet.Column(10).Width = 27;

                        // 印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№7）");

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drSiireCheak[colCnt - 1].ToString();

                        // 支払日、手形期日セルの場合
                        if (colCnt == 3 || colCnt == 9)
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
                        if (colCnt == 8)
                        {
                            // 3桁毎に","を挿入する
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("#,##0");
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 備考セルの場合
                        if (colCnt == 10)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            str = "'" + str;
                        }

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 10).Style
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

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                        }
                    }

                    rowCnt++;
                    xlsRowCnt++;
                }

                // 最終行を出力した後、合計行を出力
                if (dtChkList.Rows.Count > 0)
                {
                    // セル結合
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 7).Merge();
                    currentsheet.Cell(xlsRowCnt, 1).Value = "◆◆◆　合　計　◆◆◆";
                    currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // 入金額
                    currentsheet.Cell(xlsRowCnt, 8).Value = string.Format("{0:#,0}", decKingaku);
                    currentsheet.Cell(xlsRowCnt, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 10).Style
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
                return pdf.createPdf(strOutXlsFile, strDateTime, 1);

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

        // 印刷用ファイル作成
        public void dbToXls(DataTable dtShiharaiCheakList, List<string> lstItem, string fn)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string std = DateTime.Now.ToString("_yyyy_MM_dd_HH_mm");
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
                var outDataAll = dtShiharaiCheakList.AsEnumerable()
                    .Select(dat => new
                    {
                        siiresakiCd = dat["仕入先コード"],
                        siiresakiName = dat["仕入先名"],
                        shiharaiYmd = dat["伝票年月日"],
                        denpyoNo = dat["伝票番号"],
                        bunruiName = dat["取引区分名"],
                        koza = dat["口座"],
                        kinyuKikan = dat["金融機関名"],
                        kingaku = dat["支払額"],
                        kijitsu = dat["手形期日"],
                        bikou = dat["備考"],
                        gaku = (decimal)dat["額"]
                    }).ToList();

                // linqで税抜合計金額、消費税、税込合計金額の合計算出
                decimal decKingaku = outDataAll.Select(gokei => gokei.gaku).Sum();

                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count - 1;
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
                        headersheet.Range("A1", "J1").Merge();

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

                        headersheet.Cell("F3").Value = "口座";
                        headersheet.Cell("G3").Value = "金融機関";

                        headersheet.Cell("H3").Value = "支払額";
                        headersheet.Cell("I3").Value = "手形期日";
                        headersheet.Cell("J3").Value = "備　　考";

                        // ヘッダー列
                        headersheet.Range("A3", "J3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "J3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("A3", "J3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        //headersheet.Column(1).Width = 5;
                        //headersheet.Column(2).Width = 38;
                        //headersheet.Column(3).Width = 11;
                        //headersheet.Column(4).Width = 8;
                        //headersheet.Column(5).Width = 10;
                        //headersheet.Column(6).Width = 5;
                        //headersheet.Column(7).Width = 38;
                        //headersheet.Column(8).Width = 12;
                        //headersheet.Column(9).Width = 11;
                        //headersheet.Column(10).Width = 38;
                        headersheet.Column(1).Width = 5;
                        headersheet.Column(2).Width = 30;
                        headersheet.Column(3).Width = 11;
                        headersheet.Column(4).Width = 8;
                        headersheet.Column(5).Width = 10;
                        headersheet.Column(6).Width = 4;
                        headersheet.Column(7).Width = 13;
                        headersheet.Column(8).Width = 12;
                        headersheet.Column(9).Width = 11;
                        headersheet.Column(10).Width = 27;

                        // 印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№7）");

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drSiireCheak[colCnt - 1].ToString();

                        // 支払日、手形期日セルの場合
                        if (colCnt == 3 || colCnt == 9)
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
                        if (colCnt == 8)
                        {
                            // 3桁毎に","を挿入する
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("#,##0");
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 備考セルの場合
                        if (colCnt == 10)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            str = "'" + str;
                        }

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 10).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    //// 29行毎（ヘッダーを除いた行数）にシート作成
                    //if (xlsRowCnt == 32)
                    //{
                    //    pageCnt++;
                    //    if (pageCnt <= maxPage)
                    //    {
                    //        xlsRowCnt = 3;

                    //        // ヘッダーシートのコピー、ヘッダー部の指定
                    //        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    //    }
                    //}

                    rowCnt++;
                    xlsRowCnt++;
                }

                // 最終行を出力した後、合計行を出力
                if (dtChkList.Rows.Count > 0)
                {
                    // セル結合
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 7).Merge();
                    currentsheet.Cell(xlsRowCnt, 1).Value = "◆◆◆　合　計　◆◆◆";
                    currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // 入金額
                    currentsheet.Cell(xlsRowCnt, 8).Value = string.Format("{0:#,0}", decKingaku);
                    currentsheet.Cell(xlsRowCnt, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 10).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);
                }

                // ヘッダーシート削除
                headersheet.Delete();

                // workbookを保存
                //string strOutXlsFile = strWorkPath + "支払チェックリスト" + std + ".xlsx";
                string strOutXlsFile = fn;
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                //// PDF化の処理
                //return pdf.createPdf(strOutXlsFile, strDateTime, 1);

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

        // 伝票名から伝票番号を取得
        public string getDenpyoNo()
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@テーブル名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add("支払伝票");

            string strRet;

            DBConnective dbconnective = new DBConnective();
            try
            {
                // get伝票番号_PROC"を実行
                strRet = dbconnective.RunSqlRe("get伝票番号_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@番号");
            }
            catch
            {
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return strRet;
        }
    }
}
