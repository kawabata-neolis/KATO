using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.C0500_UrikakekinZandakaIchiranKakunin_B
{
    ///<summary>
    ///C0500_UrikakekinZandakaIchiranKakunin_B
    ///売掛金残高一覧確認
    ///作成者：大河内
    ///作成日：2018/01/28
    ///更新者：大河内
    ///更新日：2018/01/28
    ///</summary>
    class C0500_UrikakekinZandakaIchiranKakunin_B
    {
        ///<summary>
        ///setGridTokusaiki
        ///得意先グリッドのデータ取得
        ///</summary>
        public DataTable setGridTokusaiki(List<string> lstStringViewData)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtKataban = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("C0500_UrikakekinZandakaIchiranKakunin");
            lstSQL.Add("C0500_UrikakekinZan_SELECT");

            //SQL発行
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
                    return (dtKataban);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput,
                                            lstStringViewData[0],   //得意先コード(開始)
                                            lstStringViewData[1],   //得意先コード(終了)
                                            lstStringViewData[2],   //年月度(開始)
                                            lstStringViewData[3]    //年月度(終了)
                                            );

                //データ取得（ここから取得）
                dtKataban = dbconnective.ReadSql(strSQLInput);

                return (dtKataban);
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

        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        ///// <param name="dtSetCd_B_Input">
        /////     ＭＯの印刷データテーブル</param>
        ///// -----------------------------------------------------------------------------
        //public string dbToPdf(DataTable dtSetCd_B_Input, List<string> lstPrintHeader)
        //{
        //    string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
        //    string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        //    string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

        //    try
        //    {
        //        CreatePdf pdf = new CreatePdf();

        //        // ワークブックのデフォルトフォント、フォントサイズの指定
        //        XLWorkbook.DefaultStyle.Font.FontName = "ＭＳ ゴシック";
        //        XLWorkbook.DefaultStyle.Font.FontSize = 9;


        //        // excelのインスタンス生成
        //        XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled);

        //        IXLWorksheet worksheet = workbook.Worksheets.Add("Header");
        //        IXLWorksheet headersheet = worksheet;   // ヘッダーシート
        //        IXLWorksheet currentsheet = worksheet;  // 処理中シート

        //        // Linqで必要なデータをselect
        //        var outDataAll = dtSetCd_B_Input.AsEnumerable()
        //            .Select(dat => new
        //            {
        //                MOHin = dat["品名規格"],
        //                MOSu = dat["数量"],
        //                MOHachuTanka = dat["発注単価"],
        //                MONoki = dat["納期"],
        //                MOShimukesaki = dat["仕向け先"],
        //                MOChuban = dat["注番"],
        //            }).ToList();

        //        // リストをデータテーブルに変換
        //        DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

        //        int maxRowCnt = dtChkList.Rows.Count + 1;
        //        int maxColCnt = dtChkList.Columns.Count;
        //        int pageCnt = 0;    // ページ(シート枚数)カウント
        //        int rowCnt = 1;     // datatable処理行カウント
        //        int xlsRowCnt = 5;  // Excel出力行カウント（開始は出力行）
        //        int maxPage = 0;    // 最大ページ数

        //        // ページ数計算
        //        double page = 1.0 * maxRowCnt / 47;
        //        double decimalpart = page % 1;
        //        if (decimalpart != 0)
        //        {
        //            //小数点以下が0でない場合、+1
        //            maxPage = (int)Math.Floor(page) + 1;
        //        }
        //        else
        //        {
        //            maxPage = (int)page;
        //        }

        //        // ClosedXMLで1行ずつExcelに出力
        //        foreach (DataRow drSiireCheak in dtChkList.Rows)
        //        {
        //            //1ページ目のシート作成
        //            if (rowCnt == 1)
        //            {
        //                pageCnt++;

        //                // タイトル出力（中央揃え、セル結合）
        //                IXLCell titleCell = headersheet.Cell("A1");
        //                titleCell.Value = "ＭＯリスト";
        //                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //                titleCell.Style.Font.FontSize = 16;
        //                headersheet.Range("A1", "H1").Merge();

        //                // ヘッダー出力(表ヘッダー上）
        //                headersheet.Cell("A3").Value = lstPrintHeader[0];   //年月度
        //                headersheet.Cell("B3").Value = lstPrintHeader[1];   //仕向け元名

        //                // ヘッダー出力(表ヘッダー)
        //                headersheet.Cell("A4").Value = "品   名   ・   規   格";
        //                headersheet.Cell("D4").Value = "数 量";
        //                headersheet.Cell("E4").Value = "発注単価";
        //                headersheet.Cell("F4").Value = "納 期";
        //                headersheet.Cell("G4").Value = "仕 向 け 先";
        //                headersheet.Cell("H4").Value = "注 番";

        //                headersheet.Range("A4", "C4").Merge();

        //                // ヘッダー列
        //                headersheet.Range("A3", "B3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
        //                headersheet.Range("A4", "H4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        //                // 列幅の指定
        //                headersheet.Column(1).Width = 20;
        //                headersheet.Column(2).Width = 20;
        //                headersheet.Column(3).Width = 20;
        //                headersheet.Column(4).Width = 10;
        //                headersheet.Column(5).Width = 15;
        //                headersheet.Column(6).Width = 11;
        //                headersheet.Column(7).Width = 50;
        //                headersheet.Column(8).Width = 11;

        //                // セルの周囲に罫線を引く
        //                headersheet.Range("A4", "H4").Style
        //                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
        //                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
        //                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
        //                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

        //                //背景を灰色にする
        //                headersheet.Range("A4", "H4").Style.Fill.BackgroundColor = XLColor.LightGray;

        //                // 印刷体裁（A4横、印刷範囲）
        //                headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
        //                headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

        //                // ヘッダー部の指定（番号）
        //                headersheet.PageSetup.Header.Left.AddText("（№26）");

        //                //ヘッダーシートのコピー、ヘッダー部の指定
        //                pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
        //            }

        //            // 1セルずつデータ出力
        //            for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
        //            {
        //                //マージ
        //                currentsheet.Range("A" + xlsRowCnt, "C" + xlsRowCnt).Merge();

        //                string str = drSiireCheak[colCnt - 1].ToString();

        //                //行の高さ指定
        //                currentsheet.Row(xlsRowCnt).Height = 20;

        //                //品名・規格の場合
        //                if (colCnt == 1)
        //                {
        //                    currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
        //                    currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
        //                }
        //                //数量、発注単価の場合
        //                else if (colCnt == 2 || colCnt == 3)
        //                {
        //                    //小数点以下第二位まで表示
        //                    currentsheet.Cell(xlsRowCnt, colCnt + 2).Style.NumberFormat.Format = "#,0.00";

        //                    //マージされた分をずらす
        //                    currentsheet.Cell(xlsRowCnt, colCnt + 2).Value = str;
        //                    currentsheet.Cell(xlsRowCnt, colCnt + 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
        //                }
        //                //納期、仕向け先、注番の場合
        //                else
        //                {
        //                    //マージされた分をずらす
        //                    currentsheet.Cell(xlsRowCnt, colCnt + 2).Value = str;
        //                    currentsheet.Cell(xlsRowCnt, colCnt + 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
        //                }
        //            }

        //            // 1行分のセルの周囲に罫線を引く
        //            currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 8).Style
        //                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
        //                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
        //                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
        //                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

        //            // 24行毎（ヘッダーを除いた行数）にシート作成
        //            if (xlsRowCnt == 24)
        //            {
        //                pageCnt++;

        //                xlsRowCnt = 4;

        //                // ヘッダーシートのコピー、ヘッダー部の指定
        //                pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
        //            }

        //            rowCnt++;
        //            xlsRowCnt++;
        //        }

        //        // ヘッダーシート削除
        //        headersheet.Delete();

        //        // workbookを保存
        //        string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
        //        workbook.SaveAs(strOutXlsFile);

        //        // workbookを解放
        //        workbook.Dispose();

        //        // PDF化の処理
        //        return pdf.createPdf(strOutXlsFile, strDateTime, 1);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        // Workフォルダの全ファイルを取得
        //        string[] files = System.IO.Directory.GetFiles(strWorkPath, "*", System.IO.SearchOption.AllDirectories);
        //        // Workフォルダ内のファイル削除
        //        foreach (string filepath in files)
        //        {
        //            //File.Delete(filepath);
        //        }
        //    }
        //}
    }
}
