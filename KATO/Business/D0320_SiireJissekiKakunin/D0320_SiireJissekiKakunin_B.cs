using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;

using ClosedXML.Excel;

namespace KATO.Business.D0320_SiireJissekiKakunin
{

    /// D0320_SiireJissekiKakunin_B
    /// 仕入実績確認 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/5
    /// 更新者：多田
    /// 更新日：2017/7/5
    /// カラム論理名
    /// </summary>
    class D0320_SiireJissekiKakunin_B
    {
        /// <summary>
        /// getEigyoCd
        /// 営業コードを取得
        /// </summary>
        public DataTable getEigyoCd(string strUserId)
        {
            DataTable dtGetTableGrid = new DataTable();
            string strSQLInput = "";

            // SQL文 営業所コード
            strSQLInput = strSQLInput + " SELECT ";
            strSQLInput = strSQLInput + " 営業所コード ";

            strSQLInput = strSQLInput + " FROM ";
            strSQLInput = strSQLInput + " 担当者  ";

            strSQLInput = strSQLInput + " WHERE ";
            strSQLInput = strSQLInput + " ログインＩＤ= '" + strUserId + "' ";
            strSQLInput = strSQLInput + " AND 削除='N' ";

            // SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch
            {
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return (dtGetTableGrid);
        }

        /// <summary>
        ///     getSiireJissekiList
        ///     仕入実績を取得
        /// </summary>
        /// <param name="lstItem">
        ///     検索条件List  
        ///     lstItem[0]  伝票年月日Start,
        ///     lstItem[1]  伝票年月日End,
        ///     lstItem[2]  営業担当者コード,
        ///     lstItem[3]  発注者コード,
        ///     lstItem[4]  受注者コード,
        ///     lstItem[5]  仕入先コード,
        ///     lstItem[6]  大分類,
        ///     lstItem[7]  中分類,
        ///     lstItem[8]  型番１,
        ///     lstItem[9]  型番２,
        ///     lstItem[10] 型番３,
        ///     lstItem[11] 備考,
        ///     lstItem[12] 得意先コード
        /// </param>
        /// <param name="lstItem2">
        ///     検索条件（ラジオボタン）List
        ///     各要素の詳細は"param"タグに記載
        ///     lstItem[0]  営業所ラジオボタン,
        ///     lstItem[1]  グループコードラジオボタン,
        ///     lstItem[2]  出力順,
        ///     lstItem[3]  出力順（A-Z, Z-A）
        /// </param>
        /// <param name="arrDispEigyo">
        ///     表示条件（営業所）
        ///     arrDispEigyo[0] すべて,
        ///     arrDispEigyo[0] 本社,
        ///     arrDispEigyo[0] 岐阜,
        /// </param>
        /// <param name="arrDispGroup">
        ///     表示条件（グループコード）
        ///     arrDispGroup[0] すべて,
        ///     arrDispGroup[1] 共通,
        ///     arrDispGroup[2] １,
        ///     arrDispGroup[3] ２,
        ///     arrDispGroup[4] ３,
        /// </param>
        /// <param name="arrOrder">
        ///     並び順
        ///     arrOrder[0] 仕入日,
        ///     arrOrder[1] 注番,
        ///     arrOrder[2] 金額,
        ///     arrOrder[3] 受注日,
        /// </param>
        /// <param name="arrOrderAtoZ">
        ///     並び順（A-Z, Z-A）
        ///     arrOrderAtoZ[0] A-Z,
        ///     arrOrderAtoZ[1] Z-A
        /// </param>
        public DataTable getSiireJissekiList(List<string> lstItem, List<Array> lstItem2)
        {
            string andSql = "";
            string orderbySql = "";
            //string kataban2 = "";
            //string kataban3 = "";

            // 表示条件取得用(営業所)
            string[] arrDispEigyo = (string[])lstItem2[0];
            // 表示条件取得用(グループコード)
            string[] arrDispGroup = (string[])lstItem2[1];
            // 出力順条件取得用
            string[] arrOrder = (string[])lstItem2[2];
            // 出力順条件取得用(A-Z,Z-A)
            string[] arrOrderAtoZ = (string[])lstItem2[3];

            DataTable dtGetTableGrid = new DataTable();

            // 伝票年月日のStartとEnd取得
            string startYmd = lstItem[0];
            string endYmd = lstItem[1];

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("D0320_SiireJissekiKakunin");
            listSqlPath.Add("D0320_SiireJissekiKakunin_SELECT");

            // 営業担当者コードがある場合
            if (!lstItem[2].Equals(""))
            {
                andSql += " AND t.担当者コード = '" + lstItem[2] + "'";
            }

            // 発注者コードがある場合
            if (!lstItem[3].Equals(""))
            {
                andSql += " AND dbo.f_get発注番号から発注者コード(sm.発注番号) = '" + lstItem[3] + "'";
            }

            // 受注者コードがある場合
            if (!lstItem[4].Equals(""))
            {
                andSql += " AND dbo.f_get受注番号_受注者コードFROM受注(dbo.f_get発注番号_受注番号FROM発注(sm.発注番号)) = '" + lstItem[4] + "'";
            }

            // 仕入先コードがある場合
            if (!lstItem[5].Equals(""))
            {
                andSql += " AND sh.仕入先コード = '" + lstItem[5] + "'";
            }

            // 大分類コードがある場合
            if (!lstItem[6].Equals(""))
            {
                andSql += " AND sm.大分類コード = '" + lstItem[6] + "'";
            }

            // 中分類コードがある場合
            if (!lstItem[7].Equals(""))
            {
                andSql += " AND sm.中分類コード = '" + lstItem[7] + "'";
            }

            // メーカーコードがある場合
            if (!lstItem[8].Equals(""))
            {
                andSql += " AND sm.メーカーコード = '" + lstItem[8] + "'";
            }

            // 型番がある場合
            if (!lstItem[9].Equals(""))
            {
                andSql += " AND ( (RTRIM(ISNULL(cb.中分類名,'')) +  Rtrim(ISNULL(sm.Ｃ１,'')) ";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ２,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ３,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ４,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ５,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ６,'')) ) LIKE '%" + lstItem[9] + "%' )";
            }

            if (!lstItem[10].Equals(""))
            {
                andSql += " AND ( (RTRIM(ISNULL(cb.中分類名,'')) +  Rtrim(ISNULL(sm.Ｃ１,'')) ";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ２,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ３,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ４,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ５,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ６,'')) ) LIKE '%" + lstItem[10] + "%' )";
            }

            if (!lstItem[11].Equals(""))
            {
                andSql += " AND ( (RTRIM(ISNULL(cb.中分類名,'')) +  Rtrim(ISNULL(sm.Ｃ１,'')) ";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ２,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ３,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ４,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ５,''))";
                andSql += " +  Rtrim(ISNULL(sm.Ｃ６,'')) ) LIKE '%" + lstItem[11] + "%' )";
            }
            // AND条件にkataban2とkataban3のOR条件を反映
            //andSql = string.Format(andSql, kataban2, kataban3);

            // 備考がある場合
            if (!lstItem[12].Equals(""))
            {
                andSql += " AND sm.備考 LIKE '%" + lstItem[12] + "%'";
            }

            // 得意先がある場合
            if (!lstItem[13].Equals(""))
            {
                andSql += " AND dbo.f_get受注番号_得意先コードFROM受注(dbo.f_get発注番号_受注番号FROM発注(sm.発注番号)) = '" + lstItem[13] + "'";
            }

            // 営業所が本社の場合
            if (arrDispEigyo[1].Equals("TRUE"))
            {
                andSql += " AND dbo.f_get発注番号から営業所コード(sm.発注番号)='0001' ";
            }
            // 営業所が岐阜の場合
            else if (arrDispEigyo[2].Equals("TRUE"))
            {
                andSql += " AND dbo.f_get発注番号から営業所コード(sm.発注番号)='0002' ";
            }

            // グループコードが共通の場合
            if (arrDispGroup[1].Equals("TRUE"))
            {
                andSql += " AND dbo.f_getグループコード(kato.dbo.f_get発注番号から発注者コード(sm.発注番号)) = '0000' ";
            }
            // グループコードが１の場合
            else if (arrDispGroup[2].Equals("TRUE"))
            {
                andSql += " AND dbo.f_getグループコード(kato.dbo.f_get発注番号から発注者コード(sm.発注番号)) = '0001' ";
            }
            // グループコードが２の場合
            else if (arrDispGroup[3].Equals("TRUE"))
            {
                andSql += " AND dbo.f_getグループコード(kato.dbo.f_get発注番号から発注者コード(sm.発注番号)) = '0002' ";
            }
            // グループコードが３の場合
            else if (arrDispGroup[4].Equals("TRUE"))
            {
                andSql += " AND dbo.f_getグループコード(kato.dbo.f_get発注番号から発注者コード(sm.発注番号)) = '0003' ";
            }

            // 並び順（仕入日）の場合
            if (arrOrder[0].Equals("TRUE"))
            {
                // 並び順（A-Z）の場合
                if (arrOrderAtoZ[0].Equals("TRUE"))
                {
                    orderbySql += " ORDER BY TBL.伝票年月日, TBL.発注番号, TBL.メーカーコード, TBL.品名型式";
                }
                else
                {
                    orderbySql += " ORDER BY TBL.伝票年月日 DESC, TBL.発注番号, TBL.メーカーコード, TBL.品名型式";
                }
            }
            // 並び順（注番）
            else if (arrOrder[1].Equals("TRUE"))
            {
                // 並び順（A-Z）の場合
                if (arrOrderAtoZ[0].Equals("TRUE"))
                {
                    orderbySql += " ORDER BY TBL.発注番号, TBL.メーカーコード, TBL.品名型式";
                }
                else
                {
                    orderbySql += " ORDER BY TBL.発注番号 DESC, TBL.メーカーコード, TBL.品名型式";
                }
            }
            // 並び順（金額）
            else if (arrOrder[2].Equals("TRUE"))
            {
                // 並び順（A-Z）の場合
                if (arrOrderAtoZ[0].Equals("TRUE"))
                {
                    orderbySql += " ORDER BY TBL.仕入金額, TBL.仕入先コード, TBL.発注担当";
                }
                else
                {
                    orderbySql += " ORDER BY TBL.仕入金額 DESC, TBL.仕入先コード, TBL.発注担当";
                }
            }
            // 並び順（受注日）
            else if (arrOrder[3].Equals("TRUE"))
            {
                // 並び順（A-Z）の場合
                if (arrOrderAtoZ[0].Equals("TRUE"))
                {
                    // 受注日がNULLのレコードは最下部に表示させるORDER BY
                    //orderbySql += " ORDER BY CASE WHEN TBL.受注日 IS NULL THEN 0 ELSE 1 END DESC, "
                    //    + "TBL.受注日 ,TBL.発注番号, TBL.メーカーコード, TBL.品名型式";

                    orderbySql += "ORDER BY TBL.受注日 ,TBL.発注番号, TBL.メーカーコード, TBL.品名型式";
                }
                else
                {
                    // 受注日がNULLのレコードは最下部に表示させるORDER BY
                    //orderbySql += " ORDER BY CASE WHEN TBL.受注日 IS NULL THEN 0 ELSE 1 END DESC, "
                    //    + "TBL.受注日 DESC ,TBL.発注番号, TBL.メーカーコード, TBL.品名型式";

                    orderbySql += "ORDER BY TBL.受注日 DESC,TBL.発注番号, TBL.メーカーコード, TBL.品名型式";
                }
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, startYmd, endYmd, andSql, orderbySql);

                // 検索データをデータテーブルへ格納
                dtGetTableGrid = dbconnective.ReadSql(sql);

                return dtGetTableGrid;
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
        /// <param name="dtSiireJisseki">
        ///     仕入実績確認のデータテーブル</param>
        /// <param name="lstItem">
        ///     検索条件List  
        ///     lstItem[0]  伝票年月日Start,
        ///     lstItem[1]  伝票年月日End,
        ///     lstItem[2]  営業担当者名,
        ///     lstItem[3]  発注者名,
        ///     lstItem[4]  受注者名,
        ///     lstItem[5]  仕入先名称,
        ///     lstItem[6]  大分類名称,
        ///     lstItem[7]  中分類名称,
        ///     lstItem[8]  品名・型番１,
        ///     lstItem[9]  品名・型番２,
        ///     lstItem[10] 品名・型番３,
        ///     lstItem[11] 備考,
        ///     lstItem[12] 得意先名称
        /// </param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSiireJisseki, List<string> lstItem)
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
                var outDataAll = dtSiireJisseki.AsEnumerable()
                    .Select(dat => new
                    {
                        denpyoYmd = dat["伝票年月日"],
                        denpyoNo = dat["伝票番号"],
                        maker = dat["メーカー"],
                        tantoName = dat["品名型式"],
                        suuryo = (decimal)dat["数量"],
                        tanka = (decimal)dat["仕入単価"],
                        kingaku = (decimal)dat["仕入金額"],
                        bikou = dat["備考"],
                        syukaName = dat["出荷先名"],
                        siireName = dat["仕入先名"],
                        hachuNo = dat["発注番号"],
                        hachuTanto = dat["発注担当"],
                        siireTanto = dat["仕入担当"],
                        juchuNo = dat["受注番号"]
                    }).ToList();

                // linqで仕入金額の合計算出
                decimal decKingaku = outDataAll.Select(gokei => gokei.kingaku).Sum();

                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                double page = 1.0 * maxRowCnt / 44;
                double decimalpart = page % 1;
                if (decimalpart != 0)
                {
                    // 小数点以下が0でない場合、+1
                    maxPage = (int)Math.Floor(page) + 1;
                }
                else
                {
                    maxPage = (int)page;
                }

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drSiireCheak in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "仕　入　実　績　確　認　表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "N1").Merge();

                        // 担当者名、仕入先名、伝票年月日、大分類名、中分類名、品名・型番、備考出力（A2のセル）
                        IXLCell unitCell = headersheet.Cell("A2");
                        unitCell.Value = "担当者：" + lstItem[3] + " 仕入先：" + lstItem[5] +
                            " 伝票年月日：" + lstItem[0] + "～" + lstItem[1] + " 大分類：" + lstItem[6] +
                            " 中分類：" + lstItem[7] + " 品名・型番1：" + lstItem[8] + " 品名・型番2：" + lstItem[9] + " 品名・型番3：" + lstItem[10] + 
                            " 備考：" + lstItem[11];
                        unitCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "仕入日";
                        headersheet.Cell("B3").Value = "伝票番号";
                        headersheet.Cell("C3").Value = "メーカー";
                        headersheet.Cell("D3").Value = "品名･型式";
                        headersheet.Cell("E3").Value = "数量";
                        headersheet.Cell("F3").Value = "仕入単価";
                        headersheet.Cell("G3").Value = "仕入金額";
                        headersheet.Cell("H3").Value = "備考";
                        headersheet.Cell("I3").Value = "出荷先";
                        headersheet.Cell("J3").Value = "仕入先";
                        headersheet.Cell("K3").Value = "発注番号";
                        headersheet.Cell("L3").Value = "発注担当";
                        headersheet.Cell("M3").Value = "仕入担当";
                        headersheet.Cell("N3").Value = "受注番号";

                        // ヘッダー列
                        headersheet.Range("A3", "N3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "N3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("A3", "N3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 9;
                        headersheet.Column(2).Width = 8;
                        headersheet.Column(3).Width = 14;
                        headersheet.Column(4).Width = 30;
                        headersheet.Column(5).Width = 6;
                        headersheet.Column(6).Width = 12;
                        headersheet.Column(7).Width = 12;
                        headersheet.Column(8).Width = 30;
                        headersheet.Column(9).Width = 20;
                        headersheet.Column(10).Width = 20;
                        headersheet.Column(11).Width = 8;
                        headersheet.Column(12).Width = 10;
                        headersheet.Column(13).Width = 10;
                        headersheet.Column(14).Width = 8;

                        // フォントサイズ変更
                        headersheet.Range("D4:D48").Style.Font.FontSize = 6;
                        headersheet.Range("H4:H48").Style.Font.FontSize = 6;
                        headersheet.Range("I4:I48").Style.Font.FontSize = 6;
                        headersheet.Range("J4:J48").Style.Font.FontSize = 6;

                        // 印刷体裁（A3横、印刷範囲、余白）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A3Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
                        headersheet.PageSetup.Margins.Left = 0.7;
                        headersheet.PageSetup.Margins.Right = 0.7;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№32）");

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drSiireCheak[colCnt - 1].ToString();

                        // 数量、金額セルの処理
                        if (colCnt == 5 || colCnt == 7)
                        {
                            // 3桁毎に","を挿入する
                            str = string.Format("{0:#,0}", decimal.Parse(str));
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 単価セルの処理
                        if (colCnt == 6)
                        {
                            // 3桁毎に","を挿入する、小数点第2位まで
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("#,##0.00");
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 伝票番号、発注番号、受注番号の場合
                        if (colCnt == 2 || colCnt == 11 || colCnt == 14)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 備考の場合
                        if (colCnt == 8)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                        
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 14).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 44行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 48)
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

                // 最終行を出力した後、合計行を出力
                if (dtChkList.Rows.Count > 0)
                {
                    // 3桁毎に","を挿入する
                    IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, 7);
                    kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    kingakuCell.Value = string.Format("{0:#,0}", decKingaku);

                    // セルの結合
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 6).Merge();
                    currentsheet.Range(xlsRowCnt, 8, xlsRowCnt, 14).Merge();

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 14).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);
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
        ///     DataTableをもとにcsvファイルを作成</summary>
        /// <param name="dtSiireJisseki">
        ///     仕入実績確認のデータテーブル</param>
        /// <param name="strCsvPath">CSV出力パス</param>
        /// -----------------------------------------------------------------------------
        public void dbToCsv(DataTable dtSiireJisseki, string strCsvPath)
        {
            try
            {
                // 書き込むファイルを開く
                StreamWriter sw = new StreamWriter(strCsvPath, false, Encoding.GetEncoding("Shift_JIS"));

                // ヘッダー
                string strHeader = "仕入日,伝票番号,メーカー,品名・型式,数量,仕入単価,仕入金額," +
                    "備考,出荷先,仕入先,発注番号,発注担当,仕入担当,受注番号";

                sw.Write(strHeader);
                sw.Write("\r\n");

                string strDetail;

                // レコード
                foreach (DataRow drSiireJisseki in dtSiireJisseki.Rows)
                {
                    strDetail = string.Format("{0:yyyy/MM/dd}", drSiireJisseki["伝票年月日"].ToString()).Substring(0, 10) + ",";
                    strDetail += drSiireJisseki["伝票番号"].ToString() + ",";
                    strDetail += drSiireJisseki["メーカー"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["品名型式"].ToString().Trim() + ",";
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["数量"].ToString())) + ",";
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["仕入単価"].ToString())) + ",";
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["仕入金額"].ToString())) + ",";
                    strDetail += drSiireJisseki["備考"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["出荷先名"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["仕入先名"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["発注番号"].ToString() + ",";
                    strDetail += drSiireJisseki["発注担当"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["仕入担当"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["受注番号"].ToString();

                    sw.Write(strDetail);
                    sw.Write("\r\n");
                }

                // 閉じる
                sw.Close();
            }
            catch
            {
                throw;
            }

            return;
        }
    }
}
