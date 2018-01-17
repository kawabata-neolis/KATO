using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.H0210_MitsumoriInput
{
    class H0210_MitsumoriInput_B
    {
        DBConnective con;
        public void beginTrance()
        {
            con = new DBConnective();
            con.BeginTrans();
        }

        public void commit()
        {
            con.Commit();
            con.DB_Disconnect();
        }

        public void rollback()
        {
            con.Rollback();
            con.DB_Disconnect();
        }

        public DataTable getUserInfo(string strCd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT *";
            strQuery += "  FROM 担当者";
            strQuery += " WHERE ログインＩＤ = '" + strCd + "'";
            strQuery += "   AND 削除 = 'N'";


            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getMitsumoriInfo(string strNum)
        {
            DataTable dt = null;

            string strSQL = "";
            strSQL += "SELECT ";
            strSQL += " CONVERT(VARCHAR, 見積年月日, 111) as 見積年月日,標題,担当者名,納期,支払条件,有効期限,備考,";
            strSQL += " 得意先コード,得意先名称,担当者コード,営業所コード,";
            strSQL += " 売上金額,納入先コード,納入先名称, 社内メモ";
            strSQL += " FROM 見積ヘッド ";
            strSQL += " WHERE 削除 = 'N' ";
            strSQL += " AND 見積書番号=" + strNum;

            DBConnective dbCon = new DBConnective();
            try
            {
                dt = dbCon.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable getMitsumoriDetail(string strNum)
        {
            DataTable dt = null;

            string strSQL = "";

            //strSQL += "SELECT ";
            //strSQL += " 行番号,商品コード,メーカーコード,大分類コード,中分類コード,";
            //strSQL += " Ｃ１, Ｃ２, Ｃ３,Ｃ４, Ｃ５,Ｃ６, ";
            //strSQL += " 品名型式,数量,単位, 売上単価, 売上金額,仕入単価, 粗利金額,率,備考,仕入先コード,仕入先名,印刷フラグ, ";
            //strSQL += " 仕入先コード１,仕入先名１,仕入単価１,仕入金額１,粗利１,粗利率１,仕入先コード２,仕入先名２, 仕入単価２,仕入金額２,粗利２,粗利率２,仕入先コード３,仕入先名３,仕入単価３,仕入金額３,粗利３,粗利率３";
            //strSQL += " FROM 見積明細 ";
            //strSQL += " WHERE 削除 = 'N' ";
            //strSQL += " AND 伝票番号=" + strNum;
            //strSQL += " ORDER BY 行番号";

            strSQL += "select 行番号,";
            strSQL += "       null as 印,";
            strSQL += "       品名型式,";
            strSQL += "       数量,";
            strSQL += "       定価,";
            strSQL += "       null as 見積単価,";
            strSQL += "       0.0 as 掛率,";
            strSQL += "       null as 金額,";
            strSQL += "       a.仕入単価,";
            strSQL += "       ROUND(粗利金額, 0) as 粗利金額,";
            strSQL += "       ROUND(率, 1) as 率,";
            strSQL += "       備考,";
            strSQL += "       仕入先名,";
            strSQL += "       印刷フラグ,";
            strSQL += "       仕入先コード１,";
            strSQL += "       仕入先名１,";
            strSQL += "       ROUND(仕入単価１, 0) as 仕入単価１,";
            strSQL += "       ROUND(仕入金額１, 0) as 仕入金額１,";
            strSQL += "       ROUND(粗利１, 0) as 粗利１,";
            strSQL += "       ROUND(粗利率１, 0) as 粗利率１,";
            strSQL += "       仕入先コード２,";
            strSQL += "       仕入先名２,";
            strSQL += "       ROUND(仕入単価２, 0) as 仕入単価２,";
            strSQL += "       ROUND(仕入金額２, 0) as 仕入金額２,";
            strSQL += "       ROUND(粗利２, 0) as 粗利２,";
            strSQL += "       ROUND(粗利率２, 0) as 粗利率２,";
            strSQL += "       仕入先コード３,";
            strSQL += "       仕入先名３,";
            strSQL += "       ROUND(仕入単価３, 0) as 仕入単価３,";
            strSQL += "       ROUND(仕入金額３, 0) as 仕入金額３,";
            strSQL += "       ROUND(粗利３, 0) as 粗利３,";
            strSQL += "       ROUND(粗利率３, 1) as 粗利率３,";
            strSQL += "       仕入先コード４,";
            strSQL += "       仕入先名４,";
            strSQL += "       ROUND(仕入単価４, 0) as 仕入単価４,";
            strSQL += "       ROUND(仕入金額４, 0) as 仕入金額４,";
            strSQL += "       ROUND(粗利４, 0) as 粗利４,";
            strSQL += "       ROUND(粗利率４, 1) as 粗利率４,";
            strSQL += "       仕入先コード５,";
            strSQL += "       仕入先名５,";
            strSQL += "       ROUND(仕入単価５, 0) as 仕入単価５,";
            strSQL += "       ROUND(仕入金額５, 0) as 仕入金額５,";
            strSQL += "       ROUND(粗利５, 0) as 粗利５,";
            strSQL += "       ROUND(粗利率５, 1) as 粗利率５,";
            strSQL += "       仕入先コード６,";
            strSQL += "       仕入先名６,";
            strSQL += "       ROUND(仕入単価６, 0) as 仕入単価６,";
            strSQL += "       ROUND(仕入金額６, 0) as 仕入金額６,";
            strSQL += "       ROUND(粗利６, 0) as 粗利６,";
            strSQL += "       ROUND(粗利率６, 1) as 粗利率６,";
            strSQL += "       加工仕入先コード１,";
            strSQL += "       加工仕入先名１,";
            strSQL += "       ROUND(加工仕入単価１, 0) as 加工仕入単価１,";
            strSQL += "       ROUND(加工仕入金額１, 0) as 加工仕入金額１,";
            strSQL += "       ROUND(加工粗利１, 0) as 加工粗利１,";
            strSQL += "       ROUND(加工粗利率１, 1) as 加工粗利率１,";
            strSQL += "       加工仕入先コード２,";
            strSQL += "       加工仕入先名２,";
            strSQL += "       ROUND(加工仕入単価２, 0) as 加工仕入単価２,";
            strSQL += "       ROUND(加工仕入金額２, 0) as 加工仕入金額２,";
            strSQL += "       ROUND(加工粗利２, 0) as 加工粗利２,";
            strSQL += "       ROUND(加工粗利率２, 1) as 加工粗利率２,";
            strSQL += "       加工仕入先コード３,";
            strSQL += "       加工仕入先名３,";
            strSQL += "       ROUND(加工仕入単価３, 0) as 加工仕入単価３,";
            strSQL += "       ROUND(加工仕入金額３, 0) as 加工仕入金額３,";
            strSQL += "       ROUND(加工粗利３, 0) as 加工粗利３,";
            strSQL += "       ROUND(加工粗利率３, 1) as 加工粗利率３,";
            strSQL += "       加工仕入先コード４,";
            strSQL += "       加工仕入先名４,";
            strSQL += "       ROUND(加工仕入単価４, 0) as 加工仕入単価４,";
            strSQL += "       ROUND(加工仕入金額４, 0) as 加工仕入金額４,";
            strSQL += "       ROUND(加工粗利４, 0) as 加工粗利４,";
            strSQL += "       ROUND(加工粗利率４, 1) as 加工粗利率４,";
            strSQL += "       加工仕入先コード５,";
            strSQL += "       加工仕入先名５,";
            strSQL += "       ROUND(加工仕入単価５, 0) as 加工仕入単価５,";
            strSQL += "       ROUND(加工仕入金額５, 0) as 加工仕入金額５,";
            strSQL += "       ROUND(加工粗利５, 0) as 加工粗利５,";
            strSQL += "       ROUND(加工粗利率５, 1) as 加工粗利率５,";
            strSQL += "       加工仕入先コード６,";
            strSQL += "       加工仕入先名６,";
            strSQL += "       ROUND(加工仕入単価６, 0) as 加工仕入単価６,";
            strSQL += "       ROUND(加工仕入金額６, 0) as 加工仕入金額６,";
            strSQL += "       ROUND(加工粗利６, 0) as 加工粗利６,";
            strSQL += "       ROUND(加工粗利率６, 1) as 加工粗利率６,";
            strSQL += "       a.商品コード,";
            strSQL += "       a.大分類コード,";
            strSQL += "       a.中分類コード,";
            strSQL += "       a.メーカーコード,";
            strSQL += "       ROUND(b.定価, 0) as 定価1,";
            strSQL += "       ROUND(b.定価, 0) as 定価2,";
            strSQL += "       ROUND(b.定価, 0) as 定価3,";
            strSQL += "       a.Ｃ１,";
            strSQL += "       a.Ｃ２,";
            strSQL += "       a.Ｃ３,";
            strSQL += "       a.Ｃ４,";
            strSQL += "       a.Ｃ５,";
            strSQL += "       a.Ｃ６";
            strSQL += "  from 見積明細 as a left join 商品 as b on a.商品コード = b.商品コード and b.削除 = 'N'";
            strSQL += " where a.削除 = 'N'";
            strSQL += "   and 伝票番号 = " + strNum;
            strSQL += " order by 行番号";

            DBConnective dbCon = new DBConnective();
            try
            {
                dt = dbCon.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public string getDenpyoNo(string tableName)
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@テーブル名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(tableName);

            string strRet;

            try
            {
                // get伝票番号_PROC"を実行
                strRet = con.RunSqlRe("get伝票番号_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@番号");
            }
            catch
            {
                throw;
            }

            return strRet;
        }

        public void updMitsumoriH(List<String> aryPrm)
        {
            List<String> aryCol = new List<string>();

            aryCol.Add("@見積書番号");
            aryCol.Add("@見積年月日");
            aryCol.Add("@標題");
            aryCol.Add("@担当者名");
            aryCol.Add("@納期");
            aryCol.Add("@支払条件");
            aryCol.Add("@有効期限");
            aryCol.Add("@備考");
            aryCol.Add("@得意先コード");
            aryCol.Add("@得意先名称");
            aryCol.Add("@担当者コード");
            aryCol.Add("@営業所コード");
            aryCol.Add("@売上金額");
            aryCol.Add("@粗利額");
            aryCol.Add("@納入先コード");
            aryCol.Add("@納入先名称");
            aryCol.Add("@社内メモ");
            aryCol.Add("@ユーザー名");

            try
            {
                con.RunSql("見積ヘッド更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updMitsumoriM(List<String> aryPrm)
        {
            List<String> aryCol = new List<string>();

            aryCol.Add("@伝票番号");
            aryCol.Add("@行番号");
            aryCol.Add("@商品コード");
            aryCol.Add("@メーカーコード");
            aryCol.Add("@大分類コード");
            aryCol.Add("@中分類コード");
            aryCol.Add("@Ｃ１");
            aryCol.Add("@Ｃ２");
            aryCol.Add("@Ｃ３");
            aryCol.Add("@Ｃ４");
            aryCol.Add("@Ｃ５");
            aryCol.Add("@Ｃ６");
            aryCol.Add("@品名型式");
            aryCol.Add("@数量");
            aryCol.Add("@単位");
            aryCol.Add("@売上単価");
            aryCol.Add("@売上金額");
            aryCol.Add("@仕入単価");
            aryCol.Add("@粗利金額");
            aryCol.Add("@率");
            aryCol.Add("@備考");
            aryCol.Add("@仕入先コード");
            aryCol.Add("@仕入先名");
            aryCol.Add("@印刷フラグ");
            aryCol.Add("@仕入先コード１");
            aryCol.Add("@仕入先名１");
            aryCol.Add("@仕入単価１");
            aryCol.Add("@仕入金額１");
            aryCol.Add("@粗利１");
            aryCol.Add("@粗利率１");
            aryCol.Add("@仕入先コード２");
            aryCol.Add("@仕入先名２");
            aryCol.Add("@仕入単価２");
            aryCol.Add("@仕入金額２");
            aryCol.Add("@粗利２");
            aryCol.Add("@粗利率２");
            aryCol.Add("@仕入先コード３");
            aryCol.Add("@仕入先名３");
            aryCol.Add("@仕入単価３");
            aryCol.Add("@仕入金額３");
            aryCol.Add("@粗利３");
            aryCol.Add("@粗利率３");
            aryCol.Add("@仕入先コード４");
            aryCol.Add("@仕入先名４");
            aryCol.Add("@仕入単価４");
            aryCol.Add("@仕入金額４");
            aryCol.Add("@粗利４");
            aryCol.Add("@粗利率４");
            aryCol.Add("@仕入先コード５");
            aryCol.Add("@仕入先名５");
            aryCol.Add("@仕入単価５");
            aryCol.Add("@仕入金額５");
            aryCol.Add("@粗利５");
            aryCol.Add("@粗利率５");
            aryCol.Add("@仕入先コード６");
            aryCol.Add("@仕入先名６");
            aryCol.Add("@仕入単価６");
            aryCol.Add("@仕入金額６");
            aryCol.Add("@粗利６");
            aryCol.Add("@粗利率６");
            aryCol.Add("@加工仕入先コード１");
            aryCol.Add("@加工仕入先名１");
            aryCol.Add("@加工仕入単価１");
            aryCol.Add("@加工仕入金額１");
            aryCol.Add("@加工粗利１");
            aryCol.Add("@加工粗利率１");
            aryCol.Add("@加工仕入先コード２");
            aryCol.Add("@加工仕入先名２");
            aryCol.Add("@加工仕入単価２");
            aryCol.Add("@加工仕入金額２");
            aryCol.Add("@加工粗利２");
            aryCol.Add("@加工粗利率２");
            aryCol.Add("@加工仕入先コード３");
            aryCol.Add("@加工仕入先名３");
            aryCol.Add("@加工仕入単価３");
            aryCol.Add("@加工仕入金額３");
            aryCol.Add("@加工粗利３");
            aryCol.Add("@加工粗利率３");
            aryCol.Add("@加工仕入先コード４");
            aryCol.Add("@加工仕入先名４");
            aryCol.Add("@加工仕入単価４");
            aryCol.Add("@加工仕入金額４");
            aryCol.Add("@加工粗利４");
            aryCol.Add("@加工粗利率４");
            aryCol.Add("@加工仕入先コード５");
            aryCol.Add("@加工仕入先名５");
            aryCol.Add("@加工仕入単価５");
            aryCol.Add("@加工仕入金額５");
            aryCol.Add("@加工粗利５");
            aryCol.Add("@加工粗利率５");
            aryCol.Add("@加工仕入先コード６");
            aryCol.Add("@加工仕入先名６");
            aryCol.Add("@加工仕入単価６");
            aryCol.Add("@加工仕入金額６");
            aryCol.Add("@加工粗利６");
            aryCol.Add("@加工粗利率６");
            aryCol.Add("@ユーザー名");

            try
            {
                con.RunSql("見積明細更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delMitsumoriH(string strNum, string strUserName)
        {
            string strSQL = null;

            try
            {
                strSQL = "見積ヘッド削除_PROC '" + strNum + "','" + strUserName + "'";
                con.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void delMitsumoriM(string strNum, string strUserName)
        {
            string strSQL = null;

            try
            {
                strSQL = "見積明細全削除_PROC '" + strNum + "','" + strUserName + "'";
                con.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DataTable getMitsumoriH(List<String> aryPrm)
        {
            DataTable dt = null;

            DBConnective dbCon = new DBConnective();

            try
            {
                List<String> aryCol = new List<string>();

                aryCol.Add("@見積書番号");
                aryCol.Add("@表示フラグ");
                aryCol.Add("@宛先フラグ");
                aryCol.Add("@メーカー印刷フラグ");
                aryCol.Add("@中分類名印刷フラグ");

                dt = dbCon.RunSqlReDT("見積書印刷_PROC", CommandType.StoredProcedure, aryPrm, aryCol, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }




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
                int[] topRow = { 6 };
                int[] leftColumn = { 15 };
                pdf.logoPaste(strOutXlsFile, topRow, leftColumn, 200, 850, 88);

                // PDF化の処理
                return pdf.createPdf(strOutXlsFile, strDateTime, 0);
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

        public DataTable getMitsumoriList(string strF, string strT, string strTan, string strTok,
            string strTan2, string strKen, string strBik, string strKat, int s)
        {
            DataTable dt = null;

            string strSQL = "";

            strSQL += "SELECT distinct";
            strSQL += " a.承認フラグ, a.見積書番号, CONVERT(VARCHAR, a.見積年月日, 111) as 見積年月日,a.得意先コード,a.得意先名称,a.標題,a.売上金額";
            strSQL += " FROM 見積ヘッド a, 見積明細 b";
            strSQL += " WHERE a.削除 = 'N' ";
            strSQL += "   AND a.見積書番号 = b.伝票番号 ";

            if (!string.IsNullOrWhiteSpace(strF))
            {
                strSQL += "   AND CONVERT(VARCHAR, a.見積年月日, 111) >= '" + strF + "/01" + "'";
            }
            if (!string.IsNullOrWhiteSpace(strT))
            {
                strSQL += "   AND CONVERT(VARCHAR, a.見積年月日, 111) <= '" + strT + "/31" + "'";
            }
            if (!string.IsNullOrWhiteSpace(strTan))
            {
                strSQL += "   AND a.担当者コード = '" + strTan + "'";
            }
            if (!string.IsNullOrWhiteSpace(strTok))
            {
                strSQL += "   AND a.得意先コード = '" + strTok + "'";
            }
            if (!string.IsNullOrWhiteSpace(strTan2))
            {
                strSQL += "   AND a.担当者名 like '%" + strTan2 + "%'";
            }
            if (!string.IsNullOrWhiteSpace(strBik))
            {
                strSQL += "   AND a.備考 like '%" + strBik + "%'";
            }
            if (!string.IsNullOrWhiteSpace(strBik))
            {
                strSQL += "   AND b.品名型式 like '%" + strKat + "%'";
            }
            if (s == 1)
            {
                strSQL += " ORDER BY 見積書番号 DESC";
            }
            else
            {
                strSQL += " ORDER BY 得意先コード ASC, 見積書番号 DESC";
            }


            DBConnective dbCon = new DBConnective();
            try
            {
                dt = dbCon.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
