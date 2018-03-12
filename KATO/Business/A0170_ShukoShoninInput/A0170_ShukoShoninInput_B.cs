using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using ClosedXML.Excel;

namespace KATO.Business.A0170_ShukoShoninInput
{
    ///<summary>
    ///A0170_ShukoShoninInput_B
    ///出庫承認入力
    ///作成者：大河内
    ///作成日：2017/02/22
    ///更新者：
    ///更新日：
    ///カラム論理名
    class A0170_ShukoShoninInput_B
    {
        ///<summary>
        ///getShukoGrid
        ///出庫データの取得
        ///</summary>
        public DataTable getShukoGrid(string strEigyoCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0170_ShukoShoninInput");
            lstSQL.Add("ShukoShoninInput_SELECT_GRID");

            //追加のWHERE句を入れる用
            string strSQLadd = "";

            //営業所コードがある場合
            if (strEigyoCd != "")
            {
                strSQLadd = "AND 出庫倉庫 = '" + strEigyoCd + "'";
            }

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
                strSQLInput = string.Format(strSQLInput, strSQLadd);

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
        ///updShukoShonin
        ///データの追加
        ///</summary>
        public void updShukoShonin(List<Array> lstDenpyoNo, List<string> lstTableName, string strYMD, string strUserName)
        {
            //SQL用に移動
            DBConnective dbconnective = new DBConnective();

            //データ取り出し用配列
            string[] strGetData = null;

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //データ分ループ
                for (int intCnt = 0; intCnt < lstDenpyoNo.Count; intCnt ++)
                {
                    //新しく配列を作成(2列)
                    strGetData = new string[2];
                    //各データを逐次入れる
                    strGetData = (String[])lstDenpyoNo[intCnt];

                    List<string> lstUpdData = new List<string>();
                    lstUpdData.Add(strGetData[0]);                      //伝票番号
                    lstUpdData.Add(DateTime.Parse(strYMD).ToString());  //出庫年月日
                    lstUpdData.Add(strGetData[1]);                      //承認
                    lstUpdData.Add(strUserName);                        //ユーザー名

                    //プロシージャ（戻り値なし）用のメソッドに投げる
                    dbconnective.RunSql("出庫依頼承認_PROC", CommandType.StoredProcedure, lstUpdData, lstTableName);

                    string strQ = "SELECT * FROM 出庫依頼 WHERE 伝票番号 = " + strGetData[0] + " AND 削除 = 'N'";
                    DataTable dt = dbconnective.ReadSql(strQ);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string strSQL = "在庫数更新_PROC '" + dr["商品コード"] + "', '" + dr["出庫倉庫"] + "', '" + DateTime.Parse(strYMD).ToString() + "', '" + strUserName + "'";
                            dbconnective.ReadSql(strSQL);
                        }
                    }
                }

                //コミット
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
            return;
        }

        ///<summary>
        ///getPrintData
        ///印刷データの取得
        ///</summary>
        public DataTable getPrintData()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0170_ShukoShoninInput");
            lstSQL.Add("ShukoShoninInput_PrintData_SELECT");

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
        /// DataTableをもとにxlsxファイルを作成し、PDFファイルを作成
        /// </summary>
        /// <param name="dtHachu">発注のデータテーブル</param>
        /// <returns>結合PDFファイル</returns>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtShukoShonin)
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
                var outDataAll = dtShukoShonin.AsEnumerable()
                    .Select(dat => new
                    {
                        ShuhoShohinName = dat["商品名"],
                        ShukoSu = dat["数量"],
                        ShukoTokuisakiName = dat["得意先名"],
                        ShukoNoki = dat["納期"],
                        ShukoJuchusha = dat["受注者"]
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
                foreach (DataRow drSiireCheak in dtChkList.Rows)
                {
                    //1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        //タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "出庫指示書 (依頼分)";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "C1").Merge();

                        //ヘッダー出力(表ヘッダー)
                        headersheet.Cell("A3").Value = "品  名  ・  型  番";
                        headersheet.Cell("B3").Value = "数  量";
                        headersheet.Cell("C3").Value = "仕  向  け  先";
                        headersheet.Cell("D3").Value = "承認日";
                        headersheet.Cell("E3").Value = "受注者";

                        //ヘッダー列
                        headersheet.Range("A3", "E3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        //背景を灰色にする
                        headersheet.Range("A3", "E3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 65;
                        headersheet.Column(2).Width = 11;
                        headersheet.Column(3).Width = 50;
                        headersheet.Column(4).Width = 11;
                        headersheet.Column(5).Width = 20;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "E3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // 印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№17）");

                        //ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drSiireCheak[colCnt - 1].ToString();

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;

                        //縦の中央に寄せる
                        currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                        //数量の場合
                        if (colCnt == 2)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.Format = "#,0";
                        }
                    }

                    //行の高さ指定
                    currentsheet.Row(xlsRowCnt).Height = 20;

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 5).Style
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

                // ロゴ貼り付け処理
                int[] topRow = { 1 };
                int[] leftColumn = { 4 };
                pdf.logoPaste(strOutXlsFile, topRow, leftColumn, 0, 0, 57);

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

        ///<summary>
        ///addPrintAfter
        ///処理済の更新＆倉庫間移動データの追加
        ///</summary>
        public void addPrintAfter(string strYMD, string strShukoSouko, List<string> lstTableName, List<string> lstTableNameShorizumi, string strUserName)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ追加用（データ内容）
            List<string> lstData = new List<string>();
            List<string> lstDataShorizumi = new List<string>();

            //登録時の移動元を入れる用
            string strIdouMoto = "";

            //登録時の移動先を入れる用
            string strIdouSaki = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0170_ShukoShoninInput");
            lstSQL.Add("ShukoShoninInput_PrintAfterData_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    throw new Exception();
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strShukoSouko);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);
                
                //取得データ行数分ループ
                for (int intCnt = 0; intCnt < dtSetCd_B.Rows.Count; intCnt++)
                {
                    //出庫倉庫が本社の場合
                    if (dtSetCd_B.Rows[intCnt]["出庫倉庫"].ToString() == "0001")
                    {
                        strIdouMoto = "0001";
                        strIdouSaki = "0002";
                    }
                    else
                    {
                        strIdouMoto = "0002";
                        strIdouSaki = "0001";
                    }

                    lstData = new List<string>();
                    lstData.Add(strYMD);                                                //伝票年月日
                    lstData.Add(dtSetCd_B.Rows[intCnt]["伝票番号"].ToString());         //伝票番号
                    lstData.Add("2");                                                   //処理番号
                    lstData.Add(strIdouMoto);                                           //倉庫コード
                    lstData.Add("51");                                                  //取引区分
                    lstData.Add(dtSetCd_B.Rows[intCnt]["担当者コード"].ToString());     //担当者コード
                    lstData.Add(dtSetCd_B.Rows[intCnt]["営業所コード"].ToString());     //営業所コード
                    lstData.Add(dtSetCd_B.Rows[intCnt]["商品コード"].ToString());       //商品コード
                    lstData.Add(dtSetCd_B.Rows[intCnt]["メーカーコード"].ToString());   //メーカーコード
                    lstData.Add(dtSetCd_B.Rows[intCnt]["大分類コード"].ToString());     //大分類コード
                    lstData.Add(dtSetCd_B.Rows[intCnt]["中分類コード"].ToString());     //中分類コード
                    lstData.Add(dtSetCd_B.Rows[intCnt]["Ｃ１"].ToString() + " " +
                                dtSetCd_B.Rows[intCnt]["Ｃ２"].ToString() + " " +
                                dtSetCd_B.Rows[intCnt]["Ｃ３"].ToString() + " " +
                                dtSetCd_B.Rows[intCnt]["Ｃ４"].ToString() + " " +
                                dtSetCd_B.Rows[intCnt]["Ｃ５"].ToString() + " " +
                                dtSetCd_B.Rows[intCnt]["Ｃ６"].ToString());             //Ｃ１
                    lstData.Add("");                                                    //Ｃ２
                    lstData.Add("");                                                    //Ｃ３
                    lstData.Add("");                                                    //Ｃ４
                    lstData.Add("");                                                    //Ｃ５
                    lstData.Add("");                                                    //Ｃ６
                    lstData.Add(dtSetCd_B.Rows[intCnt]["数量"].ToString());             //数量
                    lstData.Add(dtSetCd_B.Rows[intCnt]["単価"].ToString());             //単価
                    lstData.Add(strIdouSaki);                                           //移動元倉庫
                    lstData.Add(strUserName);                                           //ユーザー名

                    //プロシージャ（戻り値なし）用のメソッドに投げる
                    dbconnective.RunSql("倉庫間移動更新_PROC", CommandType.StoredProcedure, lstData, lstTableName);

                    //取引区分を52の登録用に修正
                    lstData[3] = strIdouSaki;                                           //倉庫コード
                    lstData[4] = "52";                                                  //取引区分
                    lstData[19] = strIdouMoto;                                          //移動元倉庫

                    //プロシージャ（戻り値なし）用のメソッドに投げる
                    dbconnective.RunSql("倉庫間移動更新_PROC", CommandType.StoredProcedure, lstData, lstTableName);

                    lstDataShorizumi = new List<string>();
                    lstDataShorizumi.Add(strIdouMoto);
                    lstDataShorizumi.Add(strUserName);

                    //プロシージャ（戻り値なし）用のメソッドに投げる
                    dbconnective.RunSql("倉庫間移動作成済フラグセット_PROC", CommandType.StoredProcedure, lstDataShorizumi, lstTableNameShorizumi);

                }



                //コミット
                dbconnective.Commit();

                return;
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
    }
}
