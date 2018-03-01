using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace KATO.Business.M1160_TokuteimukesakiTanka
{
    /// <summary>
    /// M1160_TokuteimukesakiTanka_B
    /// 特定向先単価マスタ
    /// 作成者：
    /// 作成日：2017/5/1
    /// 更新者：
    /// 更新日：2017/5/1
    /// カラム論理名
    /// </summary>
    class M1160_TokuteimukesakiTanka_B
    {
        /// <summary>
        /// getMaster
        /// 特定向先単価マスタを取得
        /// </summary>
        public DataTable getMaster(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();
            string strSQLInput = "";

            // データ渡し用
            List<string> lstStringSQL = new List<string>();

            // SQL文 商品別利益率

            strSQLInput = strSQLInput + " SELECT ";
            strSQLInput = strSQLInput + " 得意先コード ";
            strSQLInput = strSQLInput + " , dbo.f_get取引先名称(得意先コード) AS 仕向先 ";
            strSQLInput = strSQLInput + " , dbo.f_getメーカー名(dbo.f_get商品コードからメーカーコード(商品コード)) AS ﾒｰｶｰ ";
            strSQLInput = strSQLInput + " , 型番 ";
            strSQLInput = strSQLInput + " , 単価";
            strSQLInput = strSQLInput + " , dbo.f_get商品コードから最終仕入日(商品コード) AS 最終仕入日 ";
            strSQLInput = strSQLInput + " , 仕入先コード ";
            strSQLInput = strSQLInput + " , 商品コード ";
            
            strSQLInput = strSQLInput + " FROM ";
            strSQLInput = strSQLInput + " 特定向先単価  ";

            strSQLInput = strSQLInput + " WHERE ";
            strSQLInput = strSQLInput + " 削除 = 'N' ";

            // 仕入先コードを記述した場合
            if (lstString[0] != "")
            {
                strSQLInput = strSQLInput + " AND 仕入先コード = '" + lstString[0] + "' ";
            }

            // 得意先コードを記述した場合
            if (lstString[1] != "")
            {
                strSQLInput = strSQLInput + " AND 得意先コード = '" + lstString[1] + "' ";
            }

            // 商品コードを記述した場合
            if (lstString[2] != "")
            {
                strSQLInput = strSQLInput + " AND 商品コード= '" + lstString[2] + "' ";
            }

            strSQLInput = strSQLInput + " ORDER BY 型番, 単価, 仕入先コード ASC ";


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
            return (dtGetTableGrid);
        }

        /// <summary>
        /// getShohinData
        /// 商品データを取得
        /// </summary>
        public DataTable getShohinData(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();
            string strSQLInput = "";

            // データ渡し用
            List<string> lstStringSQL = new List<string>();

            // SQL文 商品別利益率

            strSQLInput = strSQLInput + " SELECT * FROM 商品 WHERE 商品コード='" + lstString[0] + "' AND 削除='N' ";

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
            return (dtGetTableGrid);
        }

        /// <summary>
        /// addTokuteimukesakiTanka
        /// 特定向先単価マスタへ追加
        /// </summary>
        public void addTokuteimukesakiTanka(List<string> lstItem)
        {
            string strProc = "特定向先単価マスタ更新_PROC ";

            
            strProc += lstItem[0] + ", ";
            strProc += lstItem[1] + ", ";
            strProc += lstItem[2] + ", ";
            strProc += lstItem[3] + ", ";
            strProc += lstItem[4] + ", ";
            strProc += lstItem[5];



            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 商品分類別利益率設定マスタ更新_PROCを実行
                dbconnective.RunSql(strProc);

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
        }

        /// <summary>
        /// delTokuteimukesakiTanka
        /// 表示中のマスタデータを削除する処理
        /// </summary>
        public void delTokuteimukesakiTanka(List<string> lstDeleteItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 商品分類別利益率設定マスタ削除_PROCを実行
                dbconnective.RunSql("特定向先単価マスタ削除_PROC " + lstDeleteItem[0] + ", '" + lstDeleteItem[1] + "', '" + lstDeleteItem[2] + "', '" + lstDeleteItem[3] + "'");

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

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// DataTableをもとにxlsxファイルを作成し、PDFファイルを作成
        /// </summary>
        /// <param name="dtHachu">発注のデータテーブル</param>
        /// <returns>結合PDFファイル</returns>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtPrintData, List<string> lstlstTorihiki)
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
                var outDataAll = dtPrintData.AsEnumerable()
                    .Select(dat => new
                    {
                        TokuSakiKataban = dat["型番"],
                        TokuSakiTanka = dat["単価"],
                        TokuSakiShimukesaki = dat["仕向先"],
                        TokuSakiSaishuShirebi = dat["最終仕入日"]
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
                double page = 1.0 * maxRowCnt / 22;
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
                foreach (DataRow drTokuteCheak in dtChkList.Rows)
                {
                    //1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        //タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "特 定 向 け 先 単 価 一 覧 表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "C1").Merge();

                        //ヘッダー出力(表ヘッダー)
                        headersheet.Cell("A3").Value = "型  番";
                        headersheet.Cell("B3").Value = "単  価";
                        headersheet.Cell("C3").Value = "仕向先";
                        headersheet.Cell("D3").Value = "最終仕入日";

                        //ヘッダー列
                        headersheet.Range("A3", "D3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // 列幅の指定
                        headersheet.Column(1).Width = 60;
                        headersheet.Column(2).Width = 20;
                        headersheet.Column(3).Width = 50;
                        headersheet.Column(4).Width = 110;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "D3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // 印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№116）");

                        //ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drTokuteCheak[colCnt - 1].ToString();

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;

                        ////縦の中央に寄せる(未作成)
                        //currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                        ////数量の場合
                        //if (colCnt == 2)
                        //{
                        //    currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.Format = "#,0.00";
                        //}
                    }


                    //行の高さ指定
                    currentsheet.Row(xlsRowCnt).Height = 20;

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 4).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 22行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 22)
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
