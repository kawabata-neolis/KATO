using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.M0620_HushoAtenaInsatsu
{
    ///<summary>
    ///M0620_HushoAtenaInsatsu_B
    ///封書宛名印刷のビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M0620_HushoAtenaInsatsu_B
    {

        ///<summary>
        ///getEigyoshoTextLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable getEigyoshoTextLeave(string strEighoshoCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("M0620_HushoAtenaInsatsu");
            lstSQL.Add("HushoAtenaInsatsu_EigyoshoCd_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

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
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strEighoshoCd);

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
        ///getAtenaInsatsuData
        ///印刷用データの取得
        ///</summary>
        public DataTable getAtenaInsatsuData (List<string> lstAtenaInsatsu)
        {

            List<string> lstAtenaInsatsuName = new List<string>();
            lstAtenaInsatsuName.Add("取引先コード");
            lstAtenaInsatsuName.Add("パターン");
            lstAtenaInsatsuName.Add("敬称");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                dtSetCd_B = dbconnective.RunSqlReDT("宛名印刷_PROC", CommandType.StoredProcedure, lstAtenaInsatsu, lstAtenaInsatsuName, null);

                return dtSetCd_B;
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
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtSeikyuMeisai">
        ///     請求明細書のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSetCd_B_Input, bool blNaga4)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "";
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            int intPaperSizeIndex = 0;

            if (blNaga4 == true)
            {
                strFilePath = "./Template/M0620_HushoAtenaInsatsu_Naga4.xlsx";
            }
            else
            {
                strFilePath = "./Template/M0620_HushoAtenaInsatsu_Naga3.xlsx";
            }

            try
            {
                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);

                IXLWorksheet templatesheet1 = workbook.Worksheet(1);   // テンプレートシート
                IXLWorksheet currentsheet = null;  // 処理中シート

                int pageCnt = 0;    // ページ(シート枚数)カウント

                // テンプレートシートからコピー
                templatesheet1.CopyTo("Page" + pageCnt.ToString());
                currentsheet = workbook.Worksheet(workbook.Worksheets.Count);

                if (blNaga4 == true)
                {
                    currentsheet.Cell("D2").Value = dtSetCd_B_Input.Rows[0]["郵便番号"];      // 郵便番号
                    currentsheet.Cell("L4").Value = dtSetCd_B_Input.Rows[0]["住所１"];      // 住所１
                    currentsheet.Cell("L6").Value = dtSetCd_B_Input.Rows[0]["住所２"];      // 住所２
                    currentsheet.Cell("R7").Value = dtSetCd_B_Input.Rows[0]["名称"];      // 名称
                }
                else
                {
                    currentsheet.Cell("F2").Value = dtSetCd_B_Input.Rows[0]["郵便番号"];      // 郵便番号
                    currentsheet.Cell("H4").Value = dtSetCd_B_Input.Rows[0]["住所１"];      // 住所１
                    currentsheet.Cell("H5").Value = dtSetCd_B_Input.Rows[0]["住所２"];      // 住所２
                    currentsheet.Cell("I8").Value = dtSetCd_B_Input.Rows[0]["名称"];      // 名称
                }


                // テンプレートシート削除
                templatesheet1.Delete();

                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";

                //横にする
                workbook.PageOptions.PageOrientation = XLPageOrientation.Landscape;

                // workbookを保存
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                if (blNaga4 == true)
                {
                    intPaperSizeIndex = 4;
                }
                else
                {
                    intPaperSizeIndex = 3;
                }

                CreatePdf pdf = new CreatePdf();

                // PDF化の処理
                return pdf.createPdf(strOutXlsFile, strDateTime, intPaperSizeIndex);
                //return pdf.createPdf(strOutXlsFile, strDateTime);
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
