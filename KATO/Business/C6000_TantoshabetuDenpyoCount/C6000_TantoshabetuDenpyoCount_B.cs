using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using KATO.Common.Util;

namespace KATO.Business.C6000_TantoshabetuDenpyoCount
{
    /// <summary>
    /// C6000_TantoshabetuDenpyoCount_B
    /// 担当者別伝票処理件数 ビジネスロジック
    /// 作成者：
    /// 作成日：2017/7/20
    /// 更新者：
    /// 更新日：2017/7/20
    /// カラム論理名
    /// </summary>
    class C6000_TantoshabetuDenpyoCount_B
    {
        ///<summary>
        ///getData
        ///データの取得
        ///</summary>
        public DataTable getData(string strDenpyoOpen, string strDenpyoClose, string strTantoshaCdOpen, string strTantoshaCdClose)
        {
            //データ渡し用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("C6000_TantoshabetuDenpyoCount");
            lstSQL.Add("DenpyoCount_SELECT_SetDataGridView");

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
                strSQLInput = string.Format(strSQLInput, strDenpyoOpen, strDenpyoClose, strTantoshaCdOpen, strTantoshaCdClose);
                
                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                // 1セルずつ空チェック
                for (int intRcnt = 0; intRcnt < dtSetCd_B.Rows.Count; intRcnt++)
                {
                    // 担当者名カラムを除くため、カウントは1からスタート
                    for (int intCcnt = 1; intCcnt < dtSetCd_B.Columns.Count; intCcnt++)
                    {
                        string value = dtSetCd_B.Rows[intRcnt][intCcnt].ToString();
                        // 空の場合"0"を入れる(Form側で合計を計算するため)
                        if (value.Equals(""))
                        {
                            dtSetCd_B.Rows[intRcnt][intCcnt] = "0";
                        }
                    }
                }

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
        ///     担当者別伝票処理件数のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSetCd_B_Input, DateTime dateOpen, DateTime dateClose, string strTantoshaCdOpen, string strTantoshaCdClose, List<string> lstKei)
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
                        tantoName = (String)dat["担当者名"],
                        juchu = dat["受注計"],
                        hachu = dat["発注計"],
                        shire = dat["仕入計"],
                        uriage = dat["売上計"],
                        nyuko = dat["入庫計"],
                        shuko = dat["出庫計"],
                        tanto = dat["担当計"],
                    }).ToList();

                //リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 5;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                //各セルの縦サイズ指定
                headersheet.RowHeight = 14;

                //ページ数計算
                double page = 1.0 * maxRowCnt / 30;
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
                foreach (DataRow row in dtChkList.Rows)
                {
                    //1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        //タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "担当者別伝票処理件数";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "H1").Merge();
                        
                        //タイトル出力（中央揃え、セル結合）
                        IXLCell YMDtitle = headersheet.Cell("A3");
                        YMDtitle.Value = "伝票年月日：" + dateOpen.ToString("yyyy年MM月dd日") + " ～ " + dateClose.ToString("yyyy年MM月dd日") + "  担当者コード：" + strTantoshaCdOpen + " ～ " + strTantoshaCdClose;
                        YMDtitle.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        YMDtitle.Style.Font.FontSize = 9;
                        headersheet.Range("A3", "E3").Merge();
                        
                        //ヘッダー出力(表ヘッダー)
                        headersheet.Cell("A4").Value = "担当者名";
                        headersheet.Cell("B4").Value = "受注計";
                        headersheet.Cell("C4").Value = "発注計";
                        headersheet.Cell("D4").Value = "仕入計";
                        headersheet.Cell("E4").Value = "売上計";
                        headersheet.Cell("F4").Value = "入庫計";
                        headersheet.Cell("G4").Value = "出庫計";
                        headersheet.Cell("H4").Value = "担当計";

                        //ヘッダー列
                        headersheet.Range("A4", "H4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        //セルの周囲に罫線を引く
                        headersheet.Range("A4", "H4").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        //セルの背景色
                        headersheet.Range("A4", "H4").Style.Fill.BackgroundColor = XLColor.LightGray;

                        //列幅の指定
                        headersheet.Column(1).Width = 20;
                        headersheet.Column(2).Width = 16;
                        headersheet.Column(3).Width = 16;
                        headersheet.Column(4).Width = 16;
                        headersheet.Column(5).Width = 16;
                        headersheet.Column(6).Width = 16;
                        headersheet.Column(7).Width = 16;
                        headersheet.Column(8).Width = 16;

                        //印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        //ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№5）");

                        //ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    //1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        // 担当者名の行を左寄せ
                        currentsheet.Cell("A" + (rowCnt + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        string str = row[colCnt - 1].ToString();

                        //decimalに変換できるかどうかを見る用
                        decimal decTry = 0;

                        //decimal型に変換できるか
                        if (decimal.TryParse(str, out decTry))
                        {
                            str = ((int)Math.Floor(decimal.Parse(str))).ToString();

                            //0の場合空白文字に
                            if (str == "0")
                            {
                                str = "";
                            }
                            else
                            {
                                int intChange = (int)Math.Floor(double.Parse(str));
                                str = string.Format("{0:#,0}", intChange);
                            }
                        }
                        
                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                        currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    }

                    //1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 8).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    //34行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 31)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 4;

                            //ヘッダーシートのコピー、ヘッダー部の指定
                            pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                        }
                    }

                    rowCnt++;
                    xlsRowCnt++;
                }

                if (dtChkList.Rows.Count > 0)
                {
                    //セル結合、中央揃え
                    IXLCell sumcell = currentsheet.Cell(xlsRowCnt, 1);
                    sumcell.Value = "◆◆  合  計  ◆◆";

                    //金額セルの処理（3桁毎に","を挿入する）
                    for (int cnt = 0; cnt < 7; cnt++)
                    {
                        IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, cnt + 2);
                        kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                        int intChange = (int)Math.Floor(double.Parse(lstKei[cnt]));
                        kingakuCell.Value = string.Format("{0:#,0}", intChange);
                    }

                    //1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 8).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);
                }

                //ヘッダーシート削除
                headersheet.Delete();

                //workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                //workbookを解放
                workbook.Dispose();

                //PDF化の処理
                return pdf.createPdf(strOutXlsFile, strDateTime, 1);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //Workフォルダの全ファイルを取得
                string[] files = System.IO.Directory.GetFiles(strWorkPath, "*", System.IO.SearchOption.AllDirectories);
                //Workフォルダ内のファイル削除
                foreach (string filepath in files)
                {
                    //File.Delete(filepath);
                }
            }
        }
    }
}
