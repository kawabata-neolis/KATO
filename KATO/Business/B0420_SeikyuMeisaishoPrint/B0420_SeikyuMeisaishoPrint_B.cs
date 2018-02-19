using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;

using Spire.Xls;
using ClosedXML.Excel;


namespace KATO.Business.B0420_SeikyuMeisaishoPrint
{
    /// B0420_SeikyuMeisaishoPrint_B
    /// 請求明細書 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/25
    /// 更新者：多田
    /// 更新日：2017/7/25
    /// カラム論理名
    /// </summary>
    class B0420_SeikyuMeisaishoPrint_B
    {
        /// <summary>
        /// getSeikyuRireki
        /// 請求履歴を取得
        /// </summary>
        public DataTable getSeikyuRireki(List<string> lstItem)
        {
            string strSql;
            DataTable dtSeikyuRireki = new DataTable();

            strSql = " SELECT COUNT(*) FROM 請求履歴 ";
            strSql += " WHERE 得意先コード>= '" + lstItem[0] + "'";
            strSql += " AND 得意先コード<= '" + lstItem[1] + "'";
            strSql += " AND 請求年月日= '" + lstItem[2] + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtSeikyuRireki = dbconnective.ReadSql(strSql);

                return dtSeikyuRireki;
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
        /// getGetsumatsu
        /// 月末を取得
        /// </summary>
        public DataTable getGetsumatsu(string strSimekiriYmd)
        {
            string strSql;
            DataTable dtGetsumatsu = new DataTable();

            strSql = " SELECT dbo.f_前月翌日('" + strSimekiriYmd + "') ";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetsumatsu = dbconnective.ReadSql(strSql);

                return dtGetsumatsu;
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
        /// addSeikyuMeisaisho
        /// 請求明細書_PROCを実行
        /// </summary>
        public DataTable addSeikyuMeisaisho(List<string> lstDataName)
        {
            DataTable dtRet = new DataTable();

            List<string> lstTableName = new List<string>();
            lstTableName.Add("@請求年月日");
            lstTableName.Add("@開始年月日");
            lstTableName.Add("@締切日");
            lstTableName.Add("@開始得意先コード");
            lstTableName.Add("@終了得意先コード");
            lstTableName.Add("@ユーザー名");

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 請求明細書_PROCを実行
                dtRet = dbconnective.RunSqlReDT("請求明細書_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@結果");

                // コミット
                dbconnective.Commit();

                return dtRet;
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtSeikyuMeisai">
        ///     請求明細書のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSeikyuMeisai)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/B0420_SeikyuMeisaishoPrint.xlsx";
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);

                IXLWorksheet templatesheet1 = workbook.Worksheet(1);   // テンプレートシート
                IXLWorksheet templatesheet2 = workbook.Worksheet(2);   // テンプレートシート（明細行のみ）
                IXLWorksheet currentsheet = null;  // 処理中シート

                int pageCnt = 0;    // ページ(シート枚数)カウント
                int xlsRowCnt = 21;  // Excel出力行カウント（開始は出力行）
                Boolean blnSheetCreate = false;
                string strTokuisakiCd = "";

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drSeikyuMeisai in dtSeikyuMeisai.Rows)
                {
                    // 得意先コードが前行と同じ場合、かつ、43行目になった場合、テンプレートシート（明細行のみ）作成
                    if (strTokuisakiCd.Equals(drSeikyuMeisai[0].ToString()) && xlsRowCnt == 43)
                    {
                        pageCnt++;
                        xlsRowCnt = 15;
                        blnSheetCreate = true;

                        // テンプレートシート（明細行のみ）からコピー
                        templatesheet2.CopyTo("Page" + pageCnt.ToString());
                        currentsheet = workbook.Worksheet(workbook.Worksheets.Count);
                    }

                    // 得意先コードが前行と違う場合、テンプレートシート作成
                    if (!strTokuisakiCd.Equals(drSeikyuMeisai[0].ToString()))
                    {
                        strTokuisakiCd = drSeikyuMeisai[0].ToString();
                        pageCnt++;
                        xlsRowCnt = 21;
                        blnSheetCreate = true;

                        // テンプレートシートからコピー
                        templatesheet1.CopyTo("Page" + pageCnt.ToString());
                        currentsheet = workbook.Worksheet(workbook.Worksheets.Count);

                        currentsheet.Cell("A18").Value = drSeikyuMeisai[7].ToString();      // 前月御請求額
                        currentsheet.Cell("C18").Value = drSeikyuMeisai[8].ToString();      // 当月入金額
                        currentsheet.Cell("F18").Value = drSeikyuMeisai[9].ToString();      // 御支払残高
                        currentsheet.Cell("G18").Value = drSeikyuMeisai[10].ToString();     // 当月御買上額
                        currentsheet.Cell("H17").Value = drSeikyuMeisai[11].ToString();     // 内税
                        currentsheet.Cell("H18").Value = drSeikyuMeisai[12].ToString();     // 消費税額
                        currentsheet.Cell("I18").Value = drSeikyuMeisai[13].ToString();     // 当月御請求額
                    }

                    // 最初の明細行の場合
                    if (blnSheetCreate)
                    {
                        blnSheetCreate = false;

                        currentsheet.Cell("B4").Value = drSeikyuMeisai[2].ToString();       // 郵便番号
                        currentsheet.Cell("B6").Value = drSeikyuMeisai[3].ToString();       // 住所１
                        currentsheet.Cell("B8").Value = drSeikyuMeisai[4].ToString();       // 住所２
                        currentsheet.Cell("B10").Value = drSeikyuMeisai[1].ToString();      // 顧客名
                        currentsheet.Cell("H6").Value = drSeikyuMeisai[5].ToString();       // 請求年月日
                    }

                    currentsheet.Cell(xlsRowCnt, "A").Value = drSeikyuMeisai[14].ToString();    // 日付
                    currentsheet.Cell(xlsRowCnt, "B").Value = drSeikyuMeisai[15].ToString();    // 伝票No.
                    currentsheet.Cell(xlsRowCnt, "D").Value = drSeikyuMeisai[18].ToString();    // 取区
                    currentsheet.Cell(xlsRowCnt, "E").Value = drSeikyuMeisai[19].ToString();    // 商品名
                    currentsheet.Cell(xlsRowCnt, "J").Value = drSeikyuMeisai[20].ToString();    // 数量
                    currentsheet.Cell(xlsRowCnt, "K").Value = drSeikyuMeisai[21].ToString();    // 単価
                    currentsheet.Cell(xlsRowCnt, "N").Value = drSeikyuMeisai[22].ToString();    // 金額
                    currentsheet.Cell(xlsRowCnt, "P").Value = drSeikyuMeisai[23].ToString();    // 入金金額
                    currentsheet.Cell(xlsRowCnt, "Q").Value = "'" + drSeikyuMeisai[24].ToString();    // 備考

                    xlsRowCnt++;
                }

                // テンプレートシート削除
                templatesheet1.Delete();
                templatesheet2.Delete();

                // ページ数設定
                for (pageCnt = 1; pageCnt <= workbook.Worksheets.Count; pageCnt++)
                {
                    workbook.Worksheet(pageCnt).Cell("R2").Value = pageCnt.ToString();      // No.
                }

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // ロゴ貼り付け処理
                CreatePdf pdf = new CreatePdf();
                int[] topRow = { 5 };
                int[] leftColumn = { 15 };
                pdf.logoPaste(strOutXlsFile, topRow, leftColumn, 200, 850, 57);

                // PDF化の処理
                return pdf.createPdf(strOutXlsFile, strDateTime , 0);
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

    }
}
