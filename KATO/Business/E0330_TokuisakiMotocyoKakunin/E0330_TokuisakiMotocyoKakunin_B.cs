﻿using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.E0330_TokuisakiMotocyoKakunin
{
    /// E0330_TokuisakiMotocyoKakunin_B
    /// 得意先元帳確認
    /// 作成者：太田
    /// 作成日：2017/6/30
    /// 更新者：大河内
    /// 更新日：2018/02/03
    /// カラム論理名
    /// </summary>
    class E0330_TokuisakiMotocyoKakunin_B
    {
        public DataTable getTokuisakiInfo(string tCode)
        {
            DataTable dtTokuisakiInfo = new DataTable();

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("E0330_TokuisakiMotocyoKakunin");
            listSqlPath.Add("E0330_TokuisakiMotocyoKakunin_TokuisakiSELECT");

            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, tCode);

                dtTokuisakiInfo = dbconnective.ReadSql(sql);
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
            return (dtTokuisakiInfo);
        }


        /// <summary>
        ///     getZenzan
        ///     前月残高を取得
        /// </summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getZenzan(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 請求履歴

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_繰越残高FROM取引先経理情報( '"+ lstString[0] +"'" + ",dbo.f_月初日('" +lstString[1]+ "')) AS 前月残高 ";
            
            //SQLのインスタンス作成
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

            return dtGetTableGrid;
        }


        ///<summary>
        ///getUriage
        ///売上金額を取得
        ///</summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getUriage(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 売上金額

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_売上ヘッダ_売上高( '" + lstString[0] + "','" + lstString[1] +  "','" + lstString[2] + "') AS 売上金額 ";

            //SQLのインスタンス作成
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

            return dtGetTableGrid;
        }

        ///<summary>
        ///getZei
        ///消費税額を取得
        ///</summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getZei(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 消費税額

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_売上ヘッダ_消費税( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 消費税額 ";

            //SQLのインスタンス作成
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

            return dtGetTableGrid;
        }

        ///<summary>
        ///getSotozei
        ///外税を取得
        ///</summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getSotozei(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 外税

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_月間消費税( '" + lstString[0] + "','" + lstString[2] + "'," + lstString[3] + ") AS 請求消費税 ";

            //SQLのインスタンス作成
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

            return dtGetTableGrid;
        }


        ///<summary>
        ///getNyukinGenkin
        ///入金現金を取得
        ///</summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getNyukinGenkin(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 外税

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_現金( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 入金現金 ";

            //SQLのインスタンス作成
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

            return dtGetTableGrid;
        }

        ///<summary>
        ///getNyukinKogitte
        ///入金小切手を取得
        ///</summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getNyukinKogitte(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金小切手

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_小切手( '" + lstString[0] + "','" + lstString[1] +  "','" + lstString[2] + "') AS 入金小切手 ";

            //SQLのインスタンス作成
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

            return dtGetTableGrid;
        }


        ///<summary>
        ///getNyukinHurikomi
        ///入金振込を取得
        ///</summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getNyukinHurikomi(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金振込

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_振込( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 入金振込 ";

            //SQLのインスタンス作成
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

            return dtGetTableGrid;
        }



        ///<summary>
        ///getNyukinTegata
        ///入金手形を取得
        ///</summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getNyukinTegata(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金手形

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_手形( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 入金手形 ";

            //SQLのインスタンス作成
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

            return dtGetTableGrid;
        }


        ///<summary>
        ///getNyukinSousatu
        ///入金相殺を取得
        ///</summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getNyukinSousatu(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金相殺

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_相殺( '" + lstString[0] +  "','" + lstString[1] + "','" + lstString[2] + "') AS 入金相殺 ";

            //SQLのインスタンス作成
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

            return dtGetTableGrid;
        }


        ///<summary>
        ///getNyukinTesuryou
        ///入金手数料を取得
        ///</summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getNyukinTesuryou(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金手数料

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_手数料( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 入金手数料 ";

            //SQLのインスタンス作成
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

            return dtGetTableGrid;
        }


        ///<summary>
        ///getNyukinSonota
        ///入金その他を取得
        ///</summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getNyukinSonota(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金その他

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_その他( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 入金その他 ";

            //SQLのインスタンス作成
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

            return dtGetTableGrid;
        }

        ///<summary>
        ///getTokuisakiMotocyo
        ///得意先元帳を取得
        ///</summary>
        /// <param name="lstString">
        ///     listString[0]:得意先コードStart
        ///     listString[1]:日付Start
        ///     listString[2]:日付End
        /// </param>
        public DataTable getTokuisakiMotocyo(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();
            string tokuiCode = lstString[0];
            string ymdStart = lstString[1];
            string ymdEnd = lstString[2];

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("E0330_TokuisakiMotocyoKakunin");
            listSqlPath.Add("E0330_TokuisakiMotocyoKakunin_SELECT");

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, tokuiCode, ymdStart, ymdEnd);

                dtGetTableGrid = dbconnective.ReadSql(sql);
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

            return dtGetTableGrid;
        }

        ///<summary>
        ///getPrintData
        ///得意先コードの範囲内の取引先データを取得
        ///</summary>
        public DataTable getPrintData(List<string> lstPrintData)
        {
            DataTable dtGetData_B = new DataTable();

            List<string> lstTableName = new List<string>();
            lstTableName.Add("@開始得意先コード");
            lstTableName.Add("@終了得意先コード");
            lstTableName.Add("@開始年月日");
            lstTableName.Add("@終了年月日");
            lstTableName.Add("@印刷フラグ");         //[0]=範囲指定あり、[1]=全て

            List<string> lstDataName = new List<string>();
            lstDataName.Add(lstPrintData[0]);       //開始得意先コード
            lstDataName.Add(lstPrintData[1]);       //終了得意先コード
            lstDataName.Add(lstPrintData[2]);       //開始年月日
            lstDataName.Add(lstPrintData[3]);       //終了年月日
            lstDataName.Add(lstPrintData[4]);       //印刷フラグ

            DBConnective dbconnective = new DBConnective();

            // トランザクション開始
            dbconnective.BeginTrans();

            try
            {

                //売上伝票印刷_PROC
                dtGetData_B = dbconnective.RunSqlReDT("得意先元帳印刷_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, null);

                // コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                new CommonException(ex);

                // ロールバック処理
                dbconnective.Rollback();
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return dtGetData_B;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtSetCd_B_Input">
        ///     得意先元帳確認の印刷データテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSetCd_B_Input, List<string> lstPrintData)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            //合計値の確保用
            decimal decUriKin = 0;  //売上金額
            decimal decNyukin = 0;  //入金金額

            //得意先コードの表示とページ変えのチェック用
            string strTokuiCd = "";

            //得意先名の表示用
            string strTokuiName = "";

            //担当者名の表示用
            string strTantoName = "";

            try
            {
                CreatePdf pdf = new CreatePdf();

                // ワークブックのデフォルトフォント、フォントサイズの指定
                XLWorkbook.DefaultStyle.Font.FontName = "ＭＳ ゴシック";
                XLWorkbook.DefaultStyle.Font.FontSize = 7.5;


                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled);

                IXLWorksheet worksheet = workbook.Worksheets.Add("Header");
                IXLWorksheet headersheet = worksheet;   // ヘッダーシート
                IXLWorksheet currentsheet = worksheet;  // 処理中シート

                // Linqで必要なデータをselect
                var outDataAll = dtSetCd_B_Input.AsEnumerable()
                    .Select(dat => new
                    {
                        TokuiCd = dat["得意先コード"],     //[0]ヘッダー表示のみ使用
                        TokuiName = dat["得意先名"],       //[1]ヘッダー表示のみ使用
                        TokuiYMD = dat["年月日"],          //[2]
                        Tokuikbn = dat["取引区分名"],      //[3]
                        TokuiShohinName = dat["商品名"],   //[4]
                        TokuiSu = dat["数量"],             //[5]
                        TokuiTanka = dat["売上単価"],      //[6]
                        TokuiUrikin = dat["売上金額"],     //[7]
                        TokuiNyukin = dat["入金金額"],     //[8]
                        TokuiSashiZan = dat["差引残高"],   //[9]
                        TokuiTantoName = dat["担当者名"],  //[10]ヘッダー表示のみ使用
                        TokuiBiko = dat["備考"],           //[11]
                    }).ToList();

                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 5;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // 最大ページ数の行数カウント用
                int rowCntMaxPage = 1;
                int xlsRowCntMaxPage = 5;


                // 最大ページ数の取得
                foreach (DataRow drTokuiCheak in dtChkList.Rows)
                {
                    // 2ページ目以降
                    if (rowCntMaxPage > 1)
                    {
                        // 次の得意先が違う場合にシート作成
                        if (strTokuiCd != drTokuiCheak[0].ToString())
                        {
                            strTokuiCd = drTokuiCheak[0].ToString();
                            //合計分の行を追加
                            maxPage++;
                            xlsRowCntMaxPage = 5;
                        }
                    }

                    // 1ページ目のシート作成
                    if (rowCntMaxPage == 1)
                    {
                        maxPage++;
                        strTokuiCd = drTokuiCheak[0].ToString();
                    }

                    //44行に達した場合
                    if (xlsRowCntMaxPage == 44)
                    {
                        maxPage++;

                        xlsRowCntMaxPage = 4;
                    }
                    //maxPage++;
                    rowCntMaxPage++;
                    xlsRowCntMaxPage++;
                }

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drTokuiCheak in dtChkList.Rows)
                {
                    //2ページ目以降
                    if (rowCnt > 1)
                    {
                        //次の得意先が違う場合にシート作成
                        if (strTokuiCd != drTokuiCheak[0].ToString())
                        {
                            //マージ
                            currentsheet.Range("A" + xlsRowCnt, "E" + xlsRowCnt).Merge();
                            currentsheet.Range("H" + xlsRowCnt, "I" + xlsRowCnt).Merge();

                            currentsheet.Row(xlsRowCnt).Height = 10;

                            currentsheet.Cell(xlsRowCnt, 1).Value = "■■■ 合 計 ■■■";
                            currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            currentsheet.Cell(xlsRowCnt, 6).Value = decUriKin.ToString();    //売上金額
                            currentsheet.Cell(xlsRowCnt, 7).Value = decNyukin.ToString();    //入金金額

                            //最終行、各項目のカンマ処理と文字寄せ
                            for (int intCnt = 6; intCnt < 8; intCnt++)
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

                            //初期化
                            decUriKin = 0;
                            decNyukin = 0;

                            //得意先コードと名前の確保
                            strTokuiCd = drTokuiCheak[0].ToString();
                            strTokuiName = drTokuiCheak[1].ToString();
                            strTantoName = drTokuiCheak[10].ToString();

                            pageCnt++;

                            // ヘッダー出力(表ヘッダー上）
                            headersheet.Cell("A3").Value = strTokuiCd.Trim() + " " + strTokuiName.Trim();   //取引先名と取引先コード
                            headersheet.Cell("D3").Value = "担当者： " + strTantoName.Trim();   //担当者名

                            xlsRowCnt = 5;

                            //ヘッダーシートのコピー、ヘッダー部の指定
                            pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                        }
                    }

                    //1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        //得意先コードと名前の確保
                        strTokuiCd = drTokuiCheak[0].ToString();
                        strTokuiName = drTokuiCheak[1].ToString();
                        strTantoName = drTokuiCheak[10].ToString();

                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "得 意 先 元 帳";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "I1").Merge();

                        // ヘッダー出力(表ヘッダー)
                        headersheet.Cell("A4").Value = "年月日";
                        headersheet.Cell("B4").Value = "区分";
                        headersheet.Cell("C4").Value = "商 品 名";
                        headersheet.Cell("D4").Value = "数 量";
                        headersheet.Cell("E4").Value = "単 価";
                        headersheet.Cell("F4").Value = "売上金額";
                        headersheet.Cell("G4").Value = "入金金額";
                        headersheet.Cell("H4").Value = "差引残高";
                        headersheet.Cell("I4").Value = "備考";

                        //行高さの指定
                        headersheet.Row(4).Height = 10;

                        // 列幅の指定
                        headersheet.Column(1).Width = 10;   //年月日
                        headersheet.Column(2).Width = 9;   //区分
                        headersheet.Column(3).Width = 80;   //商品名
                        headersheet.Column(4).Width = 11.5;   //数量
                        headersheet.Column(5).Width = 11.5;   //単価
                        headersheet.Column(6).Width = 11.5;   //売上金額
                        headersheet.Column(7).Width = 11.5;   //入金金額
                        headersheet.Column(8).Width = 11.5;   //差引残高
                        headersheet.Column(9).Width = 30;   //備考

                        //ヘッダー文字位置の指定
                        headersheet.Column(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //年月日   
                        headersheet.Column(2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //区分 
                        headersheet.Column(3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //商品名 
                        headersheet.Column(4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //数量 
                        headersheet.Column(5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //単価 
                        headersheet.Column(6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //売上金額 
                        headersheet.Column(7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //入金金額 
                        headersheet.Column(8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //差引残高                                                                                                                                                                                                                                                                                                                                                                                                                                
                        headersheet.Column(9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  //備考

                        // セルの周囲に罫線を引く
                        headersheet.Range("A4", "I4").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        //背景を灰色にする
                        headersheet.Range("A4", "I4").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№33）");

                        //マージ
                        currentsheet.Range("A3", "C3").Merge();
                        currentsheet.Range("D3", "E3").Merge();
                        currentsheet.Range("F3", "G3").Merge();

                        // ヘッダー出力(表ヘッダー上）
                        headersheet.Cell("A3").Value = strTokuiCd + " " + strTokuiName;   //取引先名と取引先コード
                        headersheet.Cell("D3").Value = "担当者： " + strTantoName;   //担当者名
                        headersheet.Cell("F3").Value = "（外税 請求単位）";   //（外税 請求単位）の記入
                        headersheet.Cell("I3").Value = "対象期間："+ lstPrintData[2] + " ～ " + lstPrintData[3];   //対象期間

                        // ヘッダー列
                        headersheet.Range("A3", "C3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        headersheet.Range("D3", "F3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        headersheet.Range("I3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                        //ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drTokuiCheak[colCnt - 1].ToString();

                        //行の高さ指定
                        currentsheet.Row(xlsRowCnt).Height = 10;

                        //数量、単価の場合
                        if (colCnt == 6 || colCnt == 7)
                        {
                            //空白以外の場合
                            if (str != "")
                            {
                                //小数点以下第二位まで表示
                                currentsheet.Cell(xlsRowCnt, colCnt - 2).Style.NumberFormat.Format = "#,0.00";
                            }

                            currentsheet.Cell(xlsRowCnt, colCnt - 2).Value = str;
                            currentsheet.Cell(xlsRowCnt, colCnt - 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                            //0の場合
                            if (currentsheet.Cell(xlsRowCnt, colCnt - 2).Value.ToString() == "0")
                            {
                                //空にする
                                currentsheet.Cell(xlsRowCnt, colCnt - 2).Value = "";
                            }

                        }
                        //売上金額、入金金額、割引残高の場合
                        else if (colCnt >= 8 && colCnt <= 10)
                        {
                            //空白以外の場合
                            if (str != "")
                            {
                                //余計な小数点以下数値を取り除く
                                str = Math.Floor(decimal.Parse(str)).ToString();

                                //空白以外の場合
                                if (str != "0")
                                {
                                    //カンマつけ
                                    currentsheet.Cell(xlsRowCnt, colCnt - 2).Style.NumberFormat.Format = "#,0";
                                }
                                //0の場合は空白
                                else if (str == "0")
                                {
                                    str = "";
                                }
                            }

                            currentsheet.Cell(xlsRowCnt, colCnt-2).Value = str;
                            currentsheet.Cell(xlsRowCnt, colCnt-2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                            //0の場合
                            if (currentsheet.Cell(xlsRowCnt, colCnt - 2).ToString() == "0")
                            {
                                //空にする
                                currentsheet.Cell(xlsRowCnt, colCnt - 2).Value = "";
                            }
                        }
                        //得意先コード、得意先名、担当者名はスルー
                        else if (colCnt == 1 || colCnt == 2 || colCnt == 11)
                        {
                            //スルー
                        }
                        //備考
                        else if (colCnt == 12)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt-3).Value = str;
                            currentsheet.Cell(xlsRowCnt, colCnt-3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                        //年月日、区分、商品名の場合
                        else
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt-2).Value = str;
                            currentsheet.Cell(xlsRowCnt, colCnt-2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 9).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 44行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 44)
                    {
                        pageCnt++;

                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    rowCnt++;
                    xlsRowCnt++;

                    //各合計値を入れる
                    decUriKin = decUriKin + decimal.Parse(drTokuiCheak[7].ToString());
                    decNyukin = decNyukin + decimal.Parse(drTokuiCheak[8].ToString());

                    //最終行の場合
                    if (rowCnt > dtChkList.Rows.Count)
                    {
                        //マージ
                        currentsheet.Range("A" + xlsRowCnt, "E" + xlsRowCnt).Merge();

                        currentsheet.Row(xlsRowCnt).Height = 10;

                        currentsheet.Cell(xlsRowCnt, 1).Value = "◆◆◆ 合 計 ◆◆◆";
                        currentsheet.Cell(xlsRowCnt, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        currentsheet.Cell(xlsRowCnt, 6).Value = decUriKin.ToString();    //売上金額
                        currentsheet.Cell(xlsRowCnt, 7).Value = decNyukin.ToString();    //入金金額

                        //最終行、各項目のカンマ処理と文字寄せ
                        for (int intCnt = 6; intCnt < 8; intCnt++)
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

                        //初期化
                        decUriKin = 0;
                        decNyukin = 0;
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
            }
        }
    }
}
