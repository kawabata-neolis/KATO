using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.C0520_KaikakekinZandakaIchiranKakunin_B
{
    ///<summary>
    ///C0520_KaikakekinZandakaIchiranKakunin_B
    ///買掛金残高一覧確認
    ///作成者：大河内
    ///作成日：2018/01/30
    ///更新者：大河内
    ///更新日：2018/01/30
    ///</summary>
    class C0520_KaikakekinZandakaIchiranKakunin_B
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
            lstSQL.Add("C0520_KaikakekinZandakaIchiranKakunin");
            lstSQL.Add("C0520_KaikakekinZan_SELECT");

            //出力順の設定
            string strShuturyoku = "";

            if (lstStringViewData[4].ToString() == "Tokuisaki")
            {
                strShuturyoku = "T.取引先コード,K.年月日";
            }
            else
            {
                strShuturyoku = "T.カナ,K.年月日";
            }

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
                                            lstStringViewData[3],    //年月度(終了)
                                            strShuturyoku           //出力順
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

        ///<summary>
        ///getPrintData
        ///印刷用のデータ取得
        ///</summary>
        public DataTable getPrintData(List<string> lstStringViewData)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtKataban = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("C0520_KaikakekinZandakaIchiranKakunin");
            lstSQL.Add("C0520_KaikakekinZan_Print_SELECT");

            //出力順の設定
            string strShuturyoku = "";

            if (lstStringViewData[4].ToString() == "Tokuisaki")
            {
                strShuturyoku = "A.コード,A.年月";
            }
            else
            {
                strShuturyoku = "A.フリガナ,A.年月";
            }

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
                                            lstStringViewData[3],   //年月度(終了)
                                            strShuturyoku           //出力順
                                            );

                //データ取得（ここから取得）
                dtKataban = dbconnective.ReadSql(strSQLInput);

                //データ存在チェック
                if (dtKataban.Rows.Count == 0)
                {
                    return (dtKataban);
                }



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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化と取引先経理情報DBへの追加</summary>
        /// <param name="dtSetCd_B_Input">
        ///     買掛金残高一覧確認の印刷データテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSetCd_B_Input, List<string> lstlstTorihiki)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            //合計値の確保用
            decimal decUriYM = 0;
            decimal decZenUrikakeZan = 0;
            decimal decNyukinGenkin = 0;
            decimal decNyukinKogitte = 0;
            decimal decNyukinHurikomi = 0;
            decimal decNyukinTegata = 0;
            decimal decNyukinSosai = 0;
            decimal decNyukinTesuryo = 0;
            decimal decNyukinSonota = 0;
            decimal decKurikoshiZan = 0;
            decimal decTogetuUriage = 0;
            decimal decTogetuShohizei = 0;
            decimal decTogetuZan = 0;

            //締め日用（月の最終日）
            DateTime dateYMDLastDay = new DateTime();

            //締め日用（その月の日数）
            int intDays = 0;

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("C0520_KaikakekinZandakaIchiranKakunin");
            lstSQL.Add("C0520_KaikakekinZan_DELETE_INSERT");

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                CreatePdf pdf = new CreatePdf();

                // ワークブックのデフォルトフォント、フォントサイズの指定
                XLWorkbook.DefaultStyle.Font.FontName = "ＭＳ ゴシック";
                XLWorkbook.DefaultStyle.Font.FontSize = 6.9;


                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled);

                IXLWorksheet worksheet = workbook.Worksheets.Add("Header");
                IXLWorksheet headersheet = worksheet;   // ヘッダーシート
                IXLWorksheet currentsheet = worksheet;  // 処理中シート

                // Linqで必要なデータをselect
                var outDataAll = dtSetCd_B_Input.AsEnumerable()
                    .Select(dat => new
                    {
                        UriCd = dat["コード"],
                        UriTokuiName = dat["得意先名"],
                        UriYM = dat["年月"],
                        UriZenUrikakeZan = dat["前月買掛残"],
                        UriNyukinGenkin = dat["支払現金"],
                        UriNyukinKogitte = dat["支払小切手"],
                        UriNyukinHurikomi = dat["支払振込"],
                        UriNyukinTegata = dat["支払手形"],
                        UriNyukinSosai = dat["支払相殺"],
                        UriNyukinTesuryo = dat["支払手数料"],
                        UriNyukinSonota = dat["支払その他"],
                        UriKurikoshiZan = dat["繰越残高"],
                        UriTogetuUriage = dat["当月仕入高"],
                        UriTogetuShohizei = dat["当月消費税"],
                        UriTogetuZan = dat["当月残高"],
                        UriZeiku = dat["税区"],
                    }).ToList();

                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
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
                    //小数点以下が0でない場合、+1
                    maxPage = (int)Math.Floor(page) + 1;
                }
                else
                {
                    maxPage = (int)page;
                }

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drTokuisakiCheak in dtChkList.Rows)
                {
                    //1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "買掛金残高一覧表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "P1").Merge();

                        // ヘッダー出力(表ヘッダー)
                        headersheet.Cell("A3").Value = "ｺｰﾄﾞ";
                        headersheet.Cell("B3").Value = "得意先名";
                        headersheet.Cell("C3").Value = "年月";
                        headersheet.Cell("D3").Value = "前月買掛残";
                        headersheet.Cell("E3").Value = "支払現金";

                        headersheet.Cell("F3").Value = "支払小切手";
                        headersheet.Cell("G3").Value = "支払振込";
                        headersheet.Cell("H3").Value = "支払手形";
                        headersheet.Cell("I3").Value = "支払相殺";
                        headersheet.Cell("J3").Value = "支払手数料";

                        headersheet.Cell("K3").Value = "支払その他";
                        headersheet.Cell("M3").Value = "繰越残高";
                        headersheet.Cell("L3").Value = "当月仕入高";
                        headersheet.Cell("N3").Value = "当月消費税";
                        headersheet.Cell("O3").Value = "当月残高";

                        headersheet.Cell("P3").Value = "税区";

                        //行高さの指定
                        headersheet.Row(3).Height = 10;

                        //列幅の指定
                        headersheet.Column(1).Width = 5;    //ｺｰﾄﾞ
                        headersheet.Column(2).Width = 30;   //得意先名
                        headersheet.Column(3).Width = 7;    //年月
                        headersheet.Column(4).Width = 11;   //前月買掛残
                        headersheet.Column(5).Width = 11;   //支払現金
                        headersheet.Column(6).Width = 11;   //支払小切手
                        headersheet.Column(7).Width = 11;   //支払振込
                        headersheet.Column(8).Width = 11;   //支払手形
                        headersheet.Column(9).Width = 11;   //支払相殺
                        headersheet.Column(10).Width = 11;  //支払手数料
                        headersheet.Column(11).Width = 11;  //支払その他
                        headersheet.Column(12).Width = 11;  //繰越残高
                        headersheet.Column(13).Width = 11;  //当月仕入高
                        headersheet.Column(14).Width = 11;  //当月消費税
                        headersheet.Column(15).Width = 11;  //当月残高
                        headersheet.Column(16).Width = 4;   //税区

                        //ヘッダー文字位置の指定
                        headersheet.Column(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;   //ｺｰﾄﾞ
                        headersheet.Column(2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;   //得意先名
                        headersheet.Column(3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;   //年月
                        headersheet.Column(4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;   //前月買掛残
                        headersheet.Column(5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;   //支払現金
                        headersheet.Column(6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;   //支払小切手
                        headersheet.Column(7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;   //支払振込
                        headersheet.Column(8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;   //支払手形
                        headersheet.Column(9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;   //支払相殺
                        headersheet.Column(10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //支払手数料
                        headersheet.Column(11).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //支払その他
                        headersheet.Column(12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //繰越残高
                        headersheet.Column(13).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //当月仕入高
                        headersheet.Column(14).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //当月消費税
                        headersheet.Column(15).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //当月残高
                        headersheet.Column(16).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //税区

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "P3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        //背景を灰色にする
                        headersheet.Range("A3", "P3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№52）");

                        //ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drTokuisakiCheak[colCnt - 1].ToString();

                        //行の高さ指定
                        currentsheet.Row(xlsRowCnt).Height = 10;

                        //年月の場合
                        if (colCnt == 3)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.DateFormat.Format = "yyyy/MM";
                            currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                        else if (colCnt == 4 ||     //前月買掛残
                                 colCnt == 5 ||     //支払現金
                                 colCnt == 6 ||     //支払小切手
                                 colCnt == 7 ||     //支払振込
                                 colCnt == 8 ||     //支払手形
                                 colCnt == 9 ||     //支払相殺
                                 colCnt == 10 ||    //支払手数料
                                 colCnt == 11 ||    //支払その他
                                 colCnt == 12 ||    //繰越残高
                                 colCnt == 13 ||    //当月仕入高
                                 colCnt == 14 ||    //当月消費税
                                 colCnt == 15)      //当月残高
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Value = str;

                            //カンマ処理
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.Format = "#,0";
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }
                        else
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 40行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 40)
                    {
                        pageCnt++;

                        xlsRowCnt = 3;

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    //各合計値を入れる
                    decZenUrikakeZan = decZenUrikakeZan + decimal.Parse(drTokuisakiCheak[3].ToString());
                    decNyukinGenkin = decNyukinGenkin + decimal.Parse(drTokuisakiCheak[4].ToString());
                    decNyukinKogitte = decNyukinKogitte + decimal.Parse(drTokuisakiCheak[5].ToString());
                    decNyukinHurikomi = decNyukinHurikomi + decimal.Parse(drTokuisakiCheak[6].ToString());
                    decNyukinTegata = decNyukinTegata + decimal.Parse(drTokuisakiCheak[7].ToString());
                    decNyukinSosai = decNyukinSosai + decimal.Parse(drTokuisakiCheak[8].ToString());
                    decNyukinTesuryo = decNyukinTesuryo + decimal.Parse(drTokuisakiCheak[9].ToString());
                    decNyukinSonota = decNyukinSonota + decimal.Parse(drTokuisakiCheak[10].ToString());
                    decKurikoshiZan = decKurikoshiZan + decimal.Parse(drTokuisakiCheak[11].ToString());
                    decTogetuUriage = decTogetuUriage + decimal.Parse(drTokuisakiCheak[12].ToString());
                    decTogetuShohizei = decTogetuShohizei + decimal.Parse(drTokuisakiCheak[13].ToString());
                    decTogetuZan = decTogetuZan + decimal.Parse(drTokuisakiCheak[14].ToString());

                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQL);

                    //パスがなければ返す
                    if (strSQLInput == "")
                    {
                        return ("");
                    }

                    //その月の日数を作成
                    intDays = DateTime.DaysInMonth(DateTime.Parse(drTokuisakiCheak[2].ToString()).Year,
                                                   DateTime.Parse(drTokuisakiCheak[2].ToString()).Month);
                    //その月の最終日を作成
                    dateYMDLastDay = new DateTime(DateTime.Parse(drTokuisakiCheak[2].ToString()).Year,
                                                   DateTime.Parse(drTokuisakiCheak[2].ToString()).Month,
                                                   intDays);

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput,
                                                dateYMDLastDay,                                 //年月日[0]
                                                drTokuisakiCheak[0].ToString(),                 //コード[1]
                                                drTokuisakiCheak[14].ToString(),                //残高[2]
                                                drTokuisakiCheak[12].ToString(),                //金額１[3]
                                                drTokuisakiCheak[13].ToString(),                //金額２[4]
                                                decimal.Parse(drTokuisakiCheak[4].ToString())+
                                                decimal.Parse(drTokuisakiCheak[5].ToString()) +
                                                decimal.Parse(drTokuisakiCheak[6].ToString()) +
                                                decimal.Parse(drTokuisakiCheak[7].ToString()) +
                                                decimal.Parse(drTokuisakiCheak[8].ToString()) +
                                                decimal.Parse(drTokuisakiCheak[9].ToString()) +
                                                decimal.Parse(drTokuisakiCheak[10].ToString()), //金額３[5]
                                                lstlstTorihiki[0],                              //登録日、更新日[6]
                                                lstlstTorihiki[1]                               //登録ユーザー名、更新ユーザー名[7]
                                                );

                    //SQL接続、追加
                    dbconnective.RunSql(strSQLInput);

                    rowCnt++;
                    xlsRowCnt++;

                    //最終行の場合
                    if (rowCnt > dtChkList.Rows.Count)
                    {

                        //マージ
                        currentsheet.Range("A" + xlsRowCnt, "B" + xlsRowCnt).Merge();

                        currentsheet.Row(xlsRowCnt).Height = 10;

                        currentsheet.Cell(xlsRowCnt, 1).Value = "◆◆◆ 合 計 ◆◆◆";
                        currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        currentsheet.Cell(xlsRowCnt, 3).Value = decUriYM.ToString();            //年月(必然的に0)
                        currentsheet.Cell(xlsRowCnt, 4).Value = decZenUrikakeZan.ToString();    //前月買掛残
                        currentsheet.Cell(xlsRowCnt, 5).Value = decNyukinGenkin.ToString();     //支払現金
                        currentsheet.Cell(xlsRowCnt, 6).Value = decNyukinKogitte.ToString();    //支払小切手
                        currentsheet.Cell(xlsRowCnt, 7).Value = decNyukinHurikomi.ToString();   //支払振込
                        currentsheet.Cell(xlsRowCnt, 8).Value = decNyukinTegata.ToString();     //支払手形
                        currentsheet.Cell(xlsRowCnt, 9).Value = decNyukinSosai.ToString();      //支払相殺
                        currentsheet.Cell(xlsRowCnt, 10).Value = decNyukinTesuryo.ToString();   //支払手数料
                        currentsheet.Cell(xlsRowCnt, 11).Value = decNyukinSonota.ToString();    //支払その他
                        currentsheet.Cell(xlsRowCnt, 12).Value = decKurikoshiZan.ToString();    //繰越残高
                        currentsheet.Cell(xlsRowCnt, 13).Value = decTogetuUriage.ToString();    //当月仕入高
                        currentsheet.Cell(xlsRowCnt, 14).Value = decTogetuShohizei.ToString();  //当月消費税
                        currentsheet.Cell(xlsRowCnt, 15).Value = decTogetuZan.ToString();       //当月残高

                        //最終行、各項目のカンマ処理と文字寄せ
                        for (int intCnt = 3; intCnt < 16; intCnt++)
                        {
                            currentsheet.Cell(xlsRowCnt, intCnt).Style.NumberFormat.Format = "#,0";
                            currentsheet.Cell(xlsRowCnt, intCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    }
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
                //ロールバック開始
                dbconnective.Rollback();
                throw (ex);
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

                //コミット開始
                dbconnective.Commit();
            }
        }
    }
}
