using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;

namespace KATO.Business.C0140_TantouUriageArariNenkan
{
    /// <summary>
    /// C0140_TantouUriageArariNenkan_B
    /// 担当者別売上管理表（年間） ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/8/3
    /// 更新者：多田
    /// 更新日：2017/8/3
    /// カラム論理名
    /// </summary>
    class C0140_TantouUriageArariNenkan_B
    {
        /// <summary>
        /// getUriage
        /// 売上データを取得
        /// </summary>
        public DataTable getUriage(List<string> lstItem)
        {
            DataTable dtUriage = new DataTable();
            string strSql;
            string strDate;
            string strZennenDate;
            DateTime dt = new DateTime(int.Parse(lstItem[0]), 5, 1);

            strSql = "SELECT グループコード, グループ名, 担当者コード, 担当者名,";

            for (int cnt = 1; cnt <=12; cnt++)
            {
                strSql += " 売上額" + cnt.ToString() + ", 粗利額" + cnt.ToString() + ", ";
                strSql += " 前年売上額" + cnt.ToString() + ", 前年粗利額" + cnt.ToString() + ", ";
                strSql += " CASE WHEN 前年粗利額" + cnt.ToString() + " = 0 THEN 0";
                strSql += " ELSE 粗利額" + cnt.ToString() + " / 前年粗利額" + cnt.ToString();
                strSql += " END AS 前年比率" + cnt.ToString() + ",";
            }

            strSql += " 上期売上額, 上期粗利額, 上期前年売上額, 上期前年粗利額,";
            strSql += " CASE WHEN 上期前年粗利額 = 0 THEN 0";
            strSql += " ELSE 上期粗利額 / 上期前年粗利額";
            strSql += " END AS 上期前年比率,";

            strSql += " 下期売上額, 下期粗利額, 下期前年売上額, 下期前年粗利額,";
            strSql += " CASE WHEN 下期前年粗利額 = 0 THEN 0";
            strSql += " ELSE 下期粗利額 / 下期前年粗利額";
            strSql += " END AS 下期前年比率";

            strSql += " FROM";
            strSql += " (SELECT グループコード,";
            strSql += " dbo.f_getグループ名(グループコード) AS グループ名,";
            strSql += " 担当者コード,";
            strSql += " 担当者名,";

            // 5月～12月、翌年の1月～4月
            for (int intMonth = 0; intMonth < 12; intMonth++)
            {
                strDate = dt.AddMonths(intMonth).ToString("yyyy/MM/dd");
                strZennenDate = dt.AddYears(-1).AddMonths(intMonth).ToString("yyyy/MM/dd");
                strSql += " ROUND(dbo.f_get担当者別売上管理表_売上高_売上ヘッダ(担当者コード, dbo.f_月初日('" + strDate + "'), dbo.f_月末日('" + strDate + "')) / 1000, 0) AS 売上額" + (intMonth + 1).ToString() + ",";
                strSql += " ROUND(dbo.f_get担当者別売上管理表_売上高_売上ヘッダ(担当者コード, dbo.f_月初日('" + strZennenDate + "'), dbo.f_月末日('" + strZennenDate + "')) / 1000, 0) AS 前年売上額" + (intMonth + 1).ToString() + ",";
                strSql += " ROUND(dbo.f_get担当者別売上管理表_粗利額_売上ヘッダ(担当者コード, dbo.f_月初日('" + strDate + "'), dbo.f_月末日('" + strDate + "')) / 1000, 0) AS 粗利額" + (intMonth + 1).ToString() + ",";
                strSql += " ROUND(dbo.f_get担当者別売上管理表_粗利額_売上ヘッダ(担当者コード, dbo.f_月初日('" + strZennenDate + "'), dbo.f_月末日('" + strZennenDate + "')) / 1000, 0) AS 前年粗利額" + (intMonth + 1).ToString() + ",";
            }

            // 上期売上額合計（5月～10月）
            for (int intMonth = 0; intMonth < 5; intMonth++)
            {
                strDate = dt.AddMonths(intMonth).ToString("yyyy/MM/dd");
                strSql += " ROUND(dbo.f_get担当者別売上管理表_売上高_売上ヘッダ(担当者コード, dbo.f_月初日('" + strDate + "'), dbo.f_月末日('" + strDate + "')) / 1000, 0) +";
            }
            strDate = dt.AddMonths(5).ToString("yyyy/MM/dd");
            strSql += " ROUND(dbo.f_get担当者別売上管理表_売上高_売上ヘッダ(担当者コード, dbo.f_月初日('" + strDate + "'), dbo.f_月末日('" + strDate + "')) / 1000, 0) AS 上期売上額,";

            // 上期前年売上額合計（5月～10月）
            for (int intMonth = 0; intMonth < 5; intMonth++)
            {
                strZennenDate = dt.AddYears(-1).AddMonths(intMonth).ToString("yyyy/MM/dd");
                strSql += " ROUND(dbo.f_get担当者別売上管理表_売上高_売上ヘッダ(担当者コード, dbo.f_月初日('" + strZennenDate + "'), dbo.f_月末日('" + strZennenDate + "')) / 1000, 0) +";
            }
            strZennenDate = dt.AddYears(-1).AddMonths(5).ToString("yyyy/MM/dd");
            strSql += " ROUND(dbo.f_get担当者別売上管理表_売上高_売上ヘッダ(担当者コード, dbo.f_月初日('" + strZennenDate + "'), dbo.f_月末日('" + strZennenDate + "')) / 1000, 0) AS 上期前年売上額,";

            // 上期粗利額合計（5月～10月）
            for (int intMonth = 0; intMonth < 5; intMonth++)
            {
                strDate = dt.AddMonths(intMonth).ToString("yyyy/MM/dd");
                strSql += " ROUND(dbo.f_get担当者別売上管理表_粗利額_売上ヘッダ(担当者コード, dbo.f_月初日('" + strDate + "'), dbo.f_月末日('" + strDate + "')) / 1000, 0) +";
            }
            strDate = dt.AddMonths(5).ToString("yyyy/MM/dd");
            strSql += " ROUND(dbo.f_get担当者別売上管理表_粗利額_売上ヘッダ(担当者コード, dbo.f_月初日('" + strDate + "'), dbo.f_月末日('" + strDate + "')) / 1000, 0) AS 上期粗利額,";

            // 上期前年粗利額合計（5月～10月）
            for (int intMonth = 0; intMonth < 5; intMonth++)
            {
                strZennenDate = dt.AddYears(-1).AddMonths(intMonth).ToString("yyyy/MM/dd");
                strSql += " ROUND(dbo.f_get担当者別売上管理表_粗利額_売上ヘッダ(担当者コード, dbo.f_月初日('" + strZennenDate + "'), dbo.f_月末日('" + strZennenDate + "')) / 1000, 0) +";
            }
            strZennenDate = dt.AddYears(-1).AddMonths(5).ToString("yyyy/MM/dd");
            strSql += " ROUND(dbo.f_get担当者別売上管理表_粗利額_売上ヘッダ(担当者コード, dbo.f_月初日('" + strZennenDate + "'), dbo.f_月末日('" + strZennenDate + "')) / 1000, 0) AS 上期前年粗利額,";

            // 下期売上額合計（11月～12月、翌年の1月～4月）
            for (int intMonth = 6; intMonth < 11; intMonth++)
            {
                strDate = dt.AddMonths(intMonth).ToString("yyyy/MM/dd");
                strSql += " ROUND(dbo.f_get担当者別売上管理表_売上高_売上ヘッダ(担当者コード, dbo.f_月初日('" + strDate + "'), dbo.f_月末日('" + strDate + "')) / 1000, 0) +";
            }
            strDate = dt.AddMonths(11).ToString("yyyy/MM/dd");
            strSql += " ROUND(dbo.f_get担当者別売上管理表_売上高_売上ヘッダ(担当者コード, dbo.f_月初日('" + strDate + "'), dbo.f_月末日('" + strDate + "')) / 1000, 0) AS 下期売上額,";

            // 下期前年売上額合計（11月～12月、翌年の1月～4月）
            for (int intMonth = 6; intMonth < 11; intMonth++)
            {
                strDate = dt.AddMonths(intMonth).ToString("yyyy/MM/dd");
                strSql += " ROUND(dbo.f_get担当者別売上管理表_売上高_売上ヘッダ(担当者コード, dbo.f_月初日('" + strZennenDate + "'), dbo.f_月末日('" + strZennenDate + "')) / 1000, 0) +";
            }
            strZennenDate = dt.AddYears(-1).AddMonths(11).ToString("yyyy/MM/dd");
            strSql += " ROUND(dbo.f_get担当者別売上管理表_売上高_売上ヘッダ(担当者コード, dbo.f_月初日('" + strZennenDate + "'), dbo.f_月末日('" + strZennenDate + "')) / 1000, 0) AS 下期前年売上額,";

            // 下期粗利額合計（11月～12月、翌年の1月～4月）
            for (int intMonth = 6; intMonth < 11; intMonth++)
            {
                strZennenDate = dt.AddYears(-1).AddMonths(intMonth).ToString("yyyy/MM/dd");
                strSql += " ROUND(dbo.f_get担当者別売上管理表_粗利額_売上ヘッダ(担当者コード, dbo.f_月初日('" + strDate + "'), dbo.f_月末日('" + strDate + "')) / 1000, 0) +";
            }
            strDate = dt.AddMonths(11).ToString("yyyy/MM/dd");
            strSql += " ROUND(dbo.f_get担当者別売上管理表_粗利額_売上ヘッダ(担当者コード, dbo.f_月初日('" + strDate + "'), dbo.f_月末日('" + strDate + "')) / 1000, 0) AS 下期粗利額,";

            // 下期前年粗利額合計（11月～12月、翌年の1月～4月）
            for (int intMonth = 6; intMonth < 11; intMonth++)
            {
                strZennenDate = dt.AddYears(-1).AddMonths(intMonth).ToString("yyyy/MM/dd");
                strSql += " ROUND(dbo.f_get担当者別売上管理表_粗利額_売上ヘッダ(担当者コード, dbo.f_月初日('" + strZennenDate + "'), dbo.f_月末日('" + strZennenDate + "')) / 1000, 0) +";
            }
            strZennenDate = dt.AddYears(-1).AddMonths(11).ToString("yyyy/MM/dd");
            strSql += " ROUND(dbo.f_get担当者別売上管理表_粗利額_売上ヘッダ(担当者コード, dbo.f_月初日('" + strZennenDate + "'), dbo.f_月末日('" + strZennenDate + "')) / 1000, 0) AS 下期前年粗利額";

            strSql += " FROM 担当者";
            strSql += " WHERE 削除 = 'N'";
            strSql += " ) AS Z";
            strSql += " ORDER BY グループコード, 担当者コード";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtUriage = dbconnective.ReadSql(strSql);

                return dtUriage;
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtUriage">
        ///     売上管理表のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtUriage, List<string> lstItem)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/C0140_TantouUriageArariNenkan.xlsx";
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            try
            {
                CreatePdf pdf = new CreatePdf();

                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);

                IXLWorksheet templatesheet = workbook.Worksheet(1);   // テンプレートシート
                IXLWorksheet currentsheet = null;  // 処理中シート

                DataTable dtChkList = null;
                int[] groupRowsCnt = null;
                int groupsCnt = 0;

                // 総合計を取得
                decimal[] decKingaku = getGoukeiKingaku(dtUriage, ref dtChkList);

                // グループ合計を取得
                decimal[,] decKingakuGroup = getGroupKingaku(dtUriage, ref groupRowsCnt, ref groupsCnt);

                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 5;  // Excel出力行カウント（開始は出力行）

                int groupCnt = 0;
                int groupRowCnt = 0;

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drUriage in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;
                        xlsRowCnt = 5;

                        // テンプレートシートからコピー
                        templatesheet.CopyTo("Page" + pageCnt.ToString());
                        currentsheet = workbook.Worksheet(workbook.Worksheets.Count);

                        currentsheet.Cell("A1").Value = lstItem[0].ToString() + currentsheet.Cell("A1").Value;
                    }

                   // 担当者セルのデータ出力
                    currentsheet.Cell(xlsRowCnt, 1).Value = drUriage[1].ToString();
                    currentsheet.Cell(xlsRowCnt, 23).Value = drUriage[1].ToString();

                    // 5月～10月、上期合計セルのデータ出力
                    for (int colCnt = 2; colCnt <= 22; colCnt++)
                    {
                        currentsheet.Cell(xlsRowCnt, colCnt).Value = drUriage[colCnt].ToString();
                    }

                    // 11月～12月、翌年の1月～4月、下期合計セルのデータ出力
                    for (int colCnt = 23; colCnt <= 43; colCnt++)
                    {
                        currentsheet.Cell(xlsRowCnt, colCnt + 1).Value = drUriage[colCnt].ToString();
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 44).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);


                    // グループ計を出力
                    groupRowCnt++;
                    if (groupRowsCnt[groupCnt] == groupRowCnt)
                    {
                        xlsRowCnt++;

                        // 担当者セルの出力
                        currentsheet.Cell(xlsRowCnt, 1).Value = drUriage[0].ToString();
                        currentsheet.Cell(xlsRowCnt, 23).Value = drUriage[0].ToString();

                        // 5月～10月、上期合計セルのデータ出力
                        for (int colCnt = 0; colCnt <= 20; colCnt++)
                        {
                            // 前年粗利額の場合
                            if (colCnt % 3 == 2)
                            {
                                decimal decHiritsu;
                                if (decKingakuGroup[groupCnt, colCnt] == 0)
                                {
                                    decHiritsu = 0;
                                }
                                else
                                {
                                    decHiritsu = decKingakuGroup[groupCnt, colCnt - 1] / decKingakuGroup[groupCnt, colCnt];
                                }
                                currentsheet.Cell(xlsRowCnt, colCnt + 2).Value = decHiritsu.ToString();
                            }
                            else
                            {
                                currentsheet.Cell(xlsRowCnt, colCnt + 2).Value = decKingakuGroup[groupCnt, colCnt].ToString();
                            }
                        }

                        // 11月～12月、翌年の1月～4月、下期合計セルのデータ出力
                        for (int colCnt = 21; colCnt <= 41; colCnt++)
                        {
                            // 前年粗利額の場合
                            if (colCnt % 3 == 2)
                            {
                                decimal decHiritsu;
                                if (decKingakuGroup[groupCnt, colCnt] == 0)
                                {
                                    decHiritsu = 0;
                                }
                                else
                                {
                                    decHiritsu = decKingakuGroup[groupCnt, colCnt - 1] / decKingakuGroup[groupCnt, colCnt];
                                }
                                currentsheet.Cell(xlsRowCnt, colCnt + 3).Value = decHiritsu.ToString();
                            }
                            else
                            {
                                currentsheet.Cell(xlsRowCnt, colCnt + 3).Value = decKingakuGroup[groupCnt, colCnt].ToString();
                            }
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 44).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        groupCnt++;
                        groupRowCnt = 0;
                    }

                    rowCnt++;
                    xlsRowCnt++;
                }

                // 最終行を出力した後、合計行を出力
                if (dtChkList.Rows.Count > 0)
                {
                    // 担当者セルの出力
                    currentsheet.Cell(xlsRowCnt, 1).Value = "総合計";
                    currentsheet.Cell(xlsRowCnt, 23).Value = "総合計";

                    // 5月～10月、上期合計セルのデータ出力
                    for (int colCnt = 0; colCnt <= 20; colCnt++)
                    {
                        // 前年粗利額の場合
                        if (colCnt % 3 == 2)
                        {
                            decimal decHiritsu;
                            if(decKingaku[colCnt] == 0)
                            {
                                decHiritsu = 0;
                            }
                            else
                            {
                                decHiritsu = decKingaku[colCnt - 1] / decKingaku[colCnt];
                            }
                            currentsheet.Cell(xlsRowCnt, colCnt + 2).Value = decHiritsu.ToString();
                        }
                        else
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt + 2).Value = decKingaku[colCnt].ToString();
                        }
                    }

                    // 11月～12月、翌年の1月～4月、下期合計セルのデータ出力
                    for (int colCnt = 21; colCnt <= 41; colCnt++)
                    {
                        // 前年粗利額の場合
                        if (colCnt % 3 == 2)
                        {
                            decimal decHiritsu;
                            if (decKingaku[colCnt] == 0)
                            {
                                decHiritsu = 0;
                            }
                            else
                            {
                                decHiritsu = decKingaku[colCnt - 1] / decKingaku[colCnt];
                            }
                            currentsheet.Cell(xlsRowCnt, colCnt + 3).Value = decHiritsu;
                        }
                        else
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt + 3).Value = decKingaku[colCnt].ToString();
                        }
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 44).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);
                }

                // ヘッダーシート削除
                templatesheet.Delete();

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // PDF化の処理
                return pdf.createPdf(strOutXlsFile, strDateTime, 1);

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

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// 総合計を取得
        /// </summary>
        /// <param name="dtUriage">売上のデータテーブル</param>
        /// <param name="dtList">参照型 データテーブル</param>
        /// -----------------------------------------------------------------------------
        public decimal[] getGoukeiKingaku(DataTable dtUriage, ref DataTable dtList)
        {
            //Linqで必要なデータをselect
            var outDataAll = dtUriage.AsEnumerable()
                .Select(dat => new
                {
                    groupName = dat["グループ名"],
                    tantoName = dat["担当者名"],
                    uriage1 = (decimal)dat["売上額1"],
                    arari1 = (decimal)dat["粗利額1"],
                    hiritsu1 = (decimal)dat["前年比率1"],
                    uriage2 = (decimal)dat["売上額2"],
                    arari2 = (decimal)dat["粗利額2"],
                    hiritsu2 = (decimal)dat["前年比率2"],
                    uriage3 = (decimal)dat["売上額3"],
                    arari3 = (decimal)dat["粗利額3"],
                    hiritsu3 = (decimal)dat["前年比率3"],
                    uriage4 = (decimal)dat["売上額4"],
                    arari4 = (decimal)dat["粗利額4"],
                    hiritsu4 = (decimal)dat["前年比率4"],
                    uriage5 = (decimal)dat["売上額5"],
                    arari5 = (decimal)dat["粗利額5"],
                    hiritsu5 = (decimal)dat["前年比率5"],
                    uriage6 = (decimal)dat["売上額6"],
                    arari6 = (decimal)dat["粗利額6"],
                    hiritsu6 = (decimal)dat["前年比率6"],
                    uriageKamiki = (decimal)dat["上期売上額"],
                    arariKamiki = (decimal)dat["上期粗利額"],
                    hiritsuKamiki = (decimal)dat["上期前年比率"],
                    uriage7 = (decimal)dat["売上額7"],
                    arari7 = (decimal)dat["粗利額7"],
                    hiritsu7 = (decimal)dat["前年比率7"],
                    uriage8 = (decimal)dat["売上額8"],
                    arari8 = (decimal)dat["粗利額8"],
                    hiritsu8 = (decimal)dat["前年比率8"],
                    uriage9 = (decimal)dat["売上額9"],
                    arari9 = (decimal)dat["粗利額9"],
                    hiritsu9 = (decimal)dat["前年比率9"],
                    uriage10 = (decimal)dat["売上額10"],
                    arari10 = (decimal)dat["粗利額10"],
                    hiritsu10 = (decimal)dat["前年比率10"],
                    uriage11 = (decimal)dat["売上額11"],
                    arari11 = (decimal)dat["粗利額11"],
                    hiritsu11 = (decimal)dat["前年比率11"],
                    uriage12 = (decimal)dat["売上額12"],
                    arari12 = (decimal)dat["粗利額12"],
                    hiritsu12 = (decimal)dat["前年比率12"],
                    uriageSimoki = (decimal)dat["下期売上額"],
                    arariSimoki = (decimal)dat["下期粗利額"],
                    hiritsuSimoki = (decimal)dat["下期前年比率"],
                    arariZen1 = (decimal)dat["前年粗利額1"],
                    arariZen2 = (decimal)dat["前年粗利額2"],
                    arariZen3 = (decimal)dat["前年粗利額3"],
                    arariZen4 = (decimal)dat["前年粗利額4"],
                    arariZen5 = (decimal)dat["前年粗利額5"],
                    arariZen6 = (decimal)dat["前年粗利額6"],
                    arariZen7 = (decimal)dat["前年粗利額7"],
                    arariZen8 = (decimal)dat["前年粗利額8"],
                    arariZen9 = (decimal)dat["前年粗利額9"],
                    arariZen10 = (decimal)dat["前年粗利額10"],
                    arariZen11 = (decimal)dat["前年粗利額11"],
                    arariZen12 = (decimal)dat["前年粗利額12"],
                    arariZenKamiki = (decimal)dat["上期前年粗利額"],
                    arariZenSimoki = (decimal)dat["下期前年粗利額"]
                }).ToList();

            // linqで合計算出
            decimal[] decKingaku = new decimal[42];
            decKingaku[0] = outDataAll.Select(gokei => gokei.uriage1).Sum();
            decKingaku[1] = outDataAll.Select(gokei => gokei.arari1).Sum();
            decKingaku[2] = outDataAll.Select(gokei => gokei.arariZen1).Sum();
            decKingaku[3] = outDataAll.Select(gokei => gokei.uriage2).Sum();
            decKingaku[4] = outDataAll.Select(gokei => gokei.arari2).Sum();
            decKingaku[5] = outDataAll.Select(gokei => gokei.arariZen2).Sum();
            decKingaku[6] = outDataAll.Select(gokei => gokei.uriage3).Sum();
            decKingaku[7] = outDataAll.Select(gokei => gokei.arari3).Sum();
            decKingaku[8] = outDataAll.Select(gokei => gokei.arariZen3).Sum();
            decKingaku[9] = outDataAll.Select(gokei => gokei.uriage4).Sum();
            decKingaku[10] = outDataAll.Select(gokei => gokei.arari4).Sum();
            decKingaku[11] = outDataAll.Select(gokei => gokei.arariZen4).Sum();
            decKingaku[12] = outDataAll.Select(gokei => gokei.uriage5).Sum();
            decKingaku[13] = outDataAll.Select(gokei => gokei.arari5).Sum();
            decKingaku[14] = outDataAll.Select(gokei => gokei.arariZen5).Sum();
            decKingaku[15] = outDataAll.Select(gokei => gokei.uriage6).Sum();
            decKingaku[16] = outDataAll.Select(gokei => gokei.arari6).Sum();
            decKingaku[17] = outDataAll.Select(gokei => gokei.arariZen6).Sum();
            decKingaku[18] = outDataAll.Select(gokei => gokei.uriageKamiki).Sum();
            decKingaku[19] = outDataAll.Select(gokei => gokei.arariKamiki).Sum();
            decKingaku[20] = outDataAll.Select(gokei => gokei.arariZenKamiki).Sum();
            decKingaku[21] = outDataAll.Select(gokei => gokei.uriage7).Sum();
            decKingaku[22] = outDataAll.Select(gokei => gokei.arari7).Sum();
            decKingaku[23] = outDataAll.Select(gokei => gokei.arariZen7).Sum();
            decKingaku[24] = outDataAll.Select(gokei => gokei.uriage8).Sum();
            decKingaku[25] = outDataAll.Select(gokei => gokei.arari8).Sum();
            decKingaku[26] = outDataAll.Select(gokei => gokei.arariZen8).Sum();
            decKingaku[27] = outDataAll.Select(gokei => gokei.uriage9).Sum();
            decKingaku[28] = outDataAll.Select(gokei => gokei.arari9).Sum();
            decKingaku[29] = outDataAll.Select(gokei => gokei.arariZen9).Sum();
            decKingaku[30] = outDataAll.Select(gokei => gokei.uriage10).Sum();
            decKingaku[31] = outDataAll.Select(gokei => gokei.arari10).Sum();
            decKingaku[32] = outDataAll.Select(gokei => gokei.arariZen10).Sum();
            decKingaku[33] = outDataAll.Select(gokei => gokei.uriage11).Sum();
            decKingaku[34] = outDataAll.Select(gokei => gokei.arari11).Sum();
            decKingaku[35] = outDataAll.Select(gokei => gokei.arariZen11).Sum();
            decKingaku[36] = outDataAll.Select(gokei => gokei.uriage12).Sum();
            decKingaku[37] = outDataAll.Select(gokei => gokei.arari12).Sum();
            decKingaku[38] = outDataAll.Select(gokei => gokei.arariZen12).Sum();
            decKingaku[39] = outDataAll.Select(gokei => gokei.uriageSimoki).Sum();
            decKingaku[40] = outDataAll.Select(gokei => gokei.arariSimoki).Sum();
            decKingaku[41] = outDataAll.Select(gokei => gokei.arariZenSimoki).Sum();

            // リストをデータテーブルに変換
            CreatePdf pdf = new CreatePdf();
            dtList = pdf.ConvertToDataTable(outDataAll);

            return decKingaku;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// グループ合計を取得
        /// </summary>
        /// <param name="dtUriage">売上のデータテーブル</param>
        /// <param name="groupRowsCnt">参照型 各グループの行数</param>
        /// <param name="groupsCnt">参照型 グループ数</param>
        /// -----------------------------------------------------------------------------
        public decimal[,] getGroupKingaku(DataTable dtUriage, ref int[] groupRowsCnt, ref int groupsCnt)
        {
            // グループ計
            var groupGoukei = from tbl in dtUriage.AsEnumerable()
                              group tbl by tbl.Field<string>("グループコード") into g
                              select new
                              {
                                  section = g.Key,
                                  count = g.Count(),
                                  uriage1 = g.Sum(p => p.Field<decimal>("売上額1")),
                                  arari1 = g.Sum(p => p.Field<decimal>("粗利額1")),
                                  arariZen1 = g.Sum(p => p.Field<decimal>("前年粗利額1")),
                                  uriage2 = g.Sum(p => p.Field<decimal>("売上額2")),
                                  arari2 = g.Sum(p => p.Field<decimal>("粗利額2")),
                                  arariZen2 = g.Sum(p => p.Field<decimal>("前年粗利額2")),
                                  uriage3 = g.Sum(p => p.Field<decimal>("売上額3")),
                                  arari3 = g.Sum(p => p.Field<decimal>("粗利額3")),
                                  arariZen3 = g.Sum(p => p.Field<decimal>("前年粗利額3")),
                                  uriage4 = g.Sum(p => p.Field<decimal>("売上額4")),
                                  arari4 = g.Sum(p => p.Field<decimal>("粗利額4")),
                                  arariZen4 = g.Sum(p => p.Field<decimal>("前年粗利額4")),
                                  uriage5 = g.Sum(p => p.Field<decimal>("売上額5")),
                                  arari5 = g.Sum(p => p.Field<decimal>("粗利額5")),
                                  arariZen5 = g.Sum(p => p.Field<decimal>("前年粗利額5")),
                                  uriage6 = g.Sum(p => p.Field<decimal>("売上額6")),
                                  arari6 = g.Sum(p => p.Field<decimal>("粗利額6")),
                                  arariZen6 = g.Sum(p => p.Field<decimal>("前年粗利額6")),
                                  uriageKamiki = g.Sum(p => p.Field<decimal>("上期売上額")),
                                  arariKamiki = g.Sum(p => p.Field<decimal>("上期粗利額")),
                                  arariZenKamiki = g.Sum(p => p.Field<decimal>("上期前年粗利額")),
                                  uriage7 = g.Sum(p => p.Field<decimal>("売上額7")),
                                  arari7 = g.Sum(p => p.Field<decimal>("粗利額7")),
                                  arariZen7 = g.Sum(p => p.Field<decimal>("前年粗利額7")),
                                  uriage8 = g.Sum(p => p.Field<decimal>("売上額8")),
                                  arari8 = g.Sum(p => p.Field<decimal>("粗利額8")),
                                  arariZen8 = g.Sum(p => p.Field<decimal>("前年粗利額8")),
                                  uriage9 = g.Sum(p => p.Field<decimal>("売上額9")),
                                  arari9 = g.Sum(p => p.Field<decimal>("粗利額9")),
                                  arariZen9 = g.Sum(p => p.Field<decimal>("前年粗利額9")),
                                  uriage10 = g.Sum(p => p.Field<decimal>("売上額10")),
                                  arari10 = g.Sum(p => p.Field<decimal>("粗利額10")),
                                  arariZen10 = g.Sum(p => p.Field<decimal>("前年粗利額10")),
                                  uriage11 = g.Sum(p => p.Field<decimal>("売上額11")),
                                  arari11 = g.Sum(p => p.Field<decimal>("粗利額11")),
                                  arariZen11 = g.Sum(p => p.Field<decimal>("前年粗利額11")),
                                  uriage12 = g.Sum(p => p.Field<decimal>("売上額12")),
                                  arari12 = g.Sum(p => p.Field<decimal>("粗利額12")),
                                  arariZen12 = g.Sum(p => p.Field<decimal>("前年粗利額12")),
                                  uriageSimoki = g.Sum(p => p.Field<decimal>("下期売上額")),
                                  arariSimoki = g.Sum(p => p.Field<decimal>("下期粗利額")),
                                  arariZenSimoki = g.Sum(p => p.Field<decimal>("下期前年粗利額"))
                              };

            // グループ計の合計算出
            decimal[,] decKingakuGroup = new decimal[groupGoukei.Count(), 42];
            for (int cnt = 0; cnt < groupGoukei.Count(); cnt++)
            {
                decKingakuGroup[cnt, 0] = groupGoukei.ElementAt(cnt).uriage1;
                decKingakuGroup[cnt, 1] = groupGoukei.ElementAt(cnt).arari1;
                decKingakuGroup[cnt, 2] = groupGoukei.ElementAt(cnt).arariZen1;
                decKingakuGroup[cnt, 3] = groupGoukei.ElementAt(cnt).uriage2;
                decKingakuGroup[cnt, 4] = groupGoukei.ElementAt(cnt).arari2;
                decKingakuGroup[cnt, 5] = groupGoukei.ElementAt(cnt).arariZen2;
                decKingakuGroup[cnt, 6] = groupGoukei.ElementAt(cnt).uriage3;
                decKingakuGroup[cnt, 7] = groupGoukei.ElementAt(cnt).arari3;
                decKingakuGroup[cnt, 8] = groupGoukei.ElementAt(cnt).arariZen3;
                decKingakuGroup[cnt, 9] = groupGoukei.ElementAt(cnt).uriage4;
                decKingakuGroup[cnt, 10] = groupGoukei.ElementAt(cnt).arari4;
                decKingakuGroup[cnt, 11] = groupGoukei.ElementAt(cnt).arariZen4;
                decKingakuGroup[cnt, 12] = groupGoukei.ElementAt(cnt).uriage5;
                decKingakuGroup[cnt, 13] = groupGoukei.ElementAt(cnt).arari5;
                decKingakuGroup[cnt, 14] = groupGoukei.ElementAt(cnt).arariZen5;
                decKingakuGroup[cnt, 15] = groupGoukei.ElementAt(cnt).uriage6;
                decKingakuGroup[cnt, 16] = groupGoukei.ElementAt(cnt).arari6;
                decKingakuGroup[cnt, 17] = groupGoukei.ElementAt(cnt).arariZen6;
                decKingakuGroup[cnt, 18] = groupGoukei.ElementAt(cnt).uriageKamiki;
                decKingakuGroup[cnt, 19] = groupGoukei.ElementAt(cnt).arariKamiki;
                decKingakuGroup[cnt, 20] = groupGoukei.ElementAt(cnt).arariZenKamiki;
                decKingakuGroup[cnt, 21] = groupGoukei.ElementAt(cnt).uriage7;
                decKingakuGroup[cnt, 22] = groupGoukei.ElementAt(cnt).arari7;
                decKingakuGroup[cnt, 23] = groupGoukei.ElementAt(cnt).arariZen7;
                decKingakuGroup[cnt, 24] = groupGoukei.ElementAt(cnt).uriage8;
                decKingakuGroup[cnt, 25] = groupGoukei.ElementAt(cnt).arari8;
                decKingakuGroup[cnt, 26] = groupGoukei.ElementAt(cnt).arariZen8;
                decKingakuGroup[cnt, 27] = groupGoukei.ElementAt(cnt).uriage9;
                decKingakuGroup[cnt, 28] = groupGoukei.ElementAt(cnt).arari9;
                decKingakuGroup[cnt, 29] = groupGoukei.ElementAt(cnt).arariZen9;
                decKingakuGroup[cnt, 30] = groupGoukei.ElementAt(cnt).uriage10;
                decKingakuGroup[cnt, 31] = groupGoukei.ElementAt(cnt).arari10;
                decKingakuGroup[cnt, 32] = groupGoukei.ElementAt(cnt).arariZen10;
                decKingakuGroup[cnt, 33] = groupGoukei.ElementAt(cnt).uriage11;
                decKingakuGroup[cnt, 34] = groupGoukei.ElementAt(cnt).arari11;
                decKingakuGroup[cnt, 35] = groupGoukei.ElementAt(cnt).arariZen11;
                decKingakuGroup[cnt, 36] = groupGoukei.ElementAt(cnt).uriage12;
                decKingakuGroup[cnt, 37] = groupGoukei.ElementAt(cnt).arari12;
                decKingakuGroup[cnt, 38] = groupGoukei.ElementAt(cnt).arariZen12;
                decKingakuGroup[cnt, 39] = groupGoukei.ElementAt(cnt).uriageSimoki;
                decKingakuGroup[cnt, 40] = groupGoukei.ElementAt(cnt).arariSimoki;
                decKingakuGroup[cnt, 41] = groupGoukei.ElementAt(cnt).arariZenSimoki;
            }

            // グループ数
            groupsCnt = groupGoukei.Count();

            // 各グループの行数
            groupRowsCnt = new int[groupGoukei.Count()];
            for (int cnt = 0; cnt < groupGoukei.Count(); cnt++)
            {
                groupRowsCnt[cnt] = groupGoukei.ElementAt(cnt).count;
            }

            return decKingakuGroup;
        }

    }
}
