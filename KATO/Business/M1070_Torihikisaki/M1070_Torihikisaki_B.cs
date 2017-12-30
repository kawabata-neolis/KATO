using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClosedXML.Excel;
using KATO.Common.Util;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace KATO.Business.M1070_Torihikisaki
{
    ///<summary>
    ///M1070_Torihikisaki_B
    ///取引先のビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M1070_Torihikisaki_B
    {
        ///<summary>
        ///addTorihiki
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addTorihiki(List<string> lstString)
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
                    lstString[12],
                    lstString[13],
                    lstString[14],
                    lstString[15],
                    lstString[16],
                    lstString[17],
                    lstString[18],
                    lstString[19],
                    lstString[20],
                    lstString[21],
                    lstString[22],
                    lstString[23],
                    lstString[24],
                    lstString[25],
                    lstString[26],
                    lstString[27],
                    lstString[28],
                    lstString[29],
                    lstString[30],
                    lstString[31],
                    lstString[32],
                    lstString[33],
                    lstString[34],
                    lstString[35],
                    lstString[36],
                    lstString[37],
                    lstString[38],
                    lstString[39],
                    lstString[40],
                    lstString[41],
                    lstString[42],
                    lstString[43],
                    lstString[44],
                    lstString[45],
                    lstString[46],
                    lstString[47],
                    lstString[48],
                    lstString[49],
                    lstString[50],
                    lstString[51],
                    lstString[52],
                    lstString[53],
                    lstString[54],
                    lstString[55],
                    lstString[56],
                    lstString[57],
                    lstString[58],
                    lstString[59],
                    lstString[60],
                    lstString[61],
                    lstString[62],
                    lstString[63],
                    lstString[64],
                    lstString[65],
                    lstString[66],
                    lstString[67],
                    lstString[68],
                    lstString[69],
                    lstString[70],
                    lstString[71],
                    lstString[72],
                    lstString[73],
                    lstString[74],
                    "N",
                    DateTime.Now.ToString(),
                    lstString[75],
                    DateTime.Now.ToString(),
                    lstString[75]
                };

                //SQL接続、追加
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_TORIHIKISAKI_UPD, aryStr);

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
        ///delTorihiki
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delTorihiki(List<string> lstString)
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
                    lstString[12],
                    lstString[13],
                    lstString[14],
                    lstString[15],
                    lstString[16],
                    lstString[17],
                    lstString[18],
                    lstString[19],
                    lstString[20],
                    lstString[21],
                    lstString[22],
                    lstString[23],
                    lstString[24],
                    lstString[25],
                    lstString[26],
                    lstString[27],
                    lstString[28],
                    lstString[29],
                    lstString[30],
                    lstString[31],
                    lstString[32],
                    lstString[33],
                    lstString[34],
                    lstString[35],
                    lstString[36],
                    lstString[37],
                    lstString[38],
                    lstString[39],
                    lstString[40],
                    lstString[41],
                    lstString[42],
                    lstString[43],
                    lstString[44],
                    lstString[45],
                    lstString[46],
                    lstString[47],
                    lstString[48],
                    lstString[49],
                    lstString[50],
                    lstString[51],
                    lstString[52],
                    lstString[53],
                    lstString[54],
                    lstString[55],
                    lstString[56],
                    lstString[57],
                    lstString[58],
                    lstString[59],
                    lstString[60],
                    lstString[61],
                    lstString[62],
                    lstString[63],
                    lstString[64],
                    lstString[65],
                    lstString[66],
                    lstString[67],
                    lstString[68],
                    lstString[69],
                    lstString[70],
                    lstString[71],
                    lstString[72],
                    lstString[73],
                    lstString[74],
                    "Y",
                    DateTime.Now.ToString(),
                    lstString[75],
                    DateTime.Now.ToString(),
                    lstString[75]
                };

                //SQL接続、削除
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_TORIHIKISAKI_UPD, aryStr);

                //コミット開始
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getTxtTorihikiCdLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable getTxtTorihikiCdLeave(string strTorihikiCD)
        {
            //データ渡し用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Torihikisaki_SELECT_LEAVE");

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
                strSQLInput = string.Format(strSQLInput, strTorihikiCD);

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
            lstSQL.Add("M1070_Torihikisaki");
            lstSQL.Add("Torihikisaki_PrintData_SELECT");

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
        ///     メーカーのデータテーブル</param>
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
                        torihikiCd = (String)dat["取引先コード"],
                        torihikiName = dat["取引先名称"],
                        torihikiKana = dat["カナ"],
                        yubin = dat["郵便番号"],
                        jusho1 = dat["住所１"],
                        jusho2 = dat["住所２"],
                        denwa = dat["電話番号"],
                        fax = dat["ＦＡＸ番号"],
                    }).ToList();

                //リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                //各セルの縦サイズ指定
                headersheet.RowHeight = 14;

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
                        titleCell.Value = "取  引  区  分  一  覧  表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "H1").Merge();

                        //ヘッダー出力(表ヘッダー)
                        headersheet.Cell("A3").Value = "コード";
                        headersheet.Cell("B3").Value = "取引先";
                        headersheet.Cell("C3").Value = "カナ";
                        headersheet.Cell("D3").Value = "郵便番号";
                        headersheet.Cell("E3").Value = "住所１";
                        headersheet.Cell("F3").Value = "住所２";
                        headersheet.Cell("G3").Value = "電話番号";
                        headersheet.Cell("H3").Value = "ＦＡＸ";

                        //ヘッダー列
                        headersheet.Range("A3", "H3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "H3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("A3", "H3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 5;
                        headersheet.Column(2).Width = 26;
                        headersheet.Column(3).Width = 16;
                        headersheet.Column(4).Width = 8;
                        headersheet.Column(5).Width = 28;
                        headersheet.Column(6).Width = 28;
                        headersheet.Column(7).Width = 11;
                        headersheet.Column(8).Width = 11;

                        // 印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№107）");

                        //ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drSiireCheak[colCnt - 1].ToString();

                        //二桁の0パディングをさせる
                        currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("0000");

                        //左に寄せる
                        currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 8).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 34行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 34)
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///    フリガナのテキストボックスの中身をチェック</summary>
        /// <param name="target">
        ///    チェック対象の文字列</param>
        /// <returns>
        ///     ひらがな/カタカナなら半角カタカナ変換した文字列、それ以外なら"FALSE"を返す</returns>
        /// -----------------------------------------------------------------------------
        public string chkFurigana(string target)
        {
            string rtn = "";

            // 文字列"kana"に含まれる文字がすべて"ひらがな"か調べる
            // すべてひらがな(true)なら変換
            if (Regex.IsMatch(target, @"^[\p{IsHiragana}\u30FC\u30A0]+$"))
            {
                // "ひらがな"を"カタカナ"に
                rtn = Strings.StrConv(target, VbStrConv.Katakana, 0x411);
            }
            else
            {
                rtn = "FALSE";
            }
            // 文字列"kana"に含まれる文字がすべて"カタカナ"か調べる
            // すべてカタカナ(true)なら変換
            //  通常の全角カタカナの他に、カタカナフリガナ拡張、
            //  濁点と半濁点、半角カタカナもカタカナとする
            if (Regex.IsMatch(target, @"^[\p{IsKatakana}\u31F0-\u31FF\u3099-\u309C\uFF65-\uFF9F]+$"))
            {
                // 全角を半角に
                rtn = Strings.StrConv(target, VbStrConv.Narrow, 0x411);
            }
            else
            {
                rtn = "FALSE";
            }

            return rtn;
        }

    }
}
