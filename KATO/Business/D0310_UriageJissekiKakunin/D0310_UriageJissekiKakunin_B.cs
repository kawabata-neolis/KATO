using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;

using ClosedXML.Excel;


namespace KATO.Business.D0310_UriageJissekiKakunin
{
    /// <summary>
    /// D0310_UriageJissekiKakunin_B
    /// 売上実績確認 ビジネスロジック
    /// 作成者：
    /// 作成日：2017/7/20
    /// 更新者：
    /// 更新日：2017/7/20
    /// カラム論理名
    /// </summary>
    class D0310_UriageJissekiKakunin_B
    {
        /// <summary>
        /// getEigyoCd
        /// 営業コードを取得
        /// </summary>
        public DataTable getEigyoCd(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();
            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            //SQL文 営業所コード

            strSQLInput = strSQLInput + " SELECT ";
            strSQLInput = strSQLInput + " 営業所コード ";
            
            strSQLInput = strSQLInput + " FROM ";
            strSQLInput = strSQLInput + " 担当者  ";

            strSQLInput = strSQLInput + " WHERE ";
            strSQLInput = strSQLInput + " ログインＩＤ= '" + lstString[0] + "' ";
            strSQLInput = strSQLInput + " AND 削除='N' ";
            
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
            return (dtGetTableGrid);
        }

        /// <summary>
        /// getUriageJisseki
        /// 売上実績のグリッドビューを表示する。
        /// </summary>
        /// <param name="lstItem">
        ///     検索条件List  
        ///     lstItem[0]  伝票年月日Start,
        ///     lstItem[1]  伝票年月日End,
        ///     lstItem[2]  入力者コード,
        ///     lstItem[3]  受注者コード,
        ///     lstItem[4]  営業担当者コード,
        ///     lstItem[5]  仕入先コード,
        ///     lstItem[6]  大分類,
        ///     lstItem[7]  中分類,
        ///     lstItem[8]  品名・型番,
        ///     lstItem[9]  備考,
        ///     lstItem[10] 得意先,
        ///     lstItem[11] メーカー,
        ///     lstItem[12] 受注番号,
        ///     lstItem[13] 発注番号
        /// </param>
        /// <param name="lstItem2">
        ///     検索条件（ラジオボタン・チェックボックス）List
        ///     各要素の詳細は"param"タグに記載
        ///     lstItem[0]  営業所ラジオボタン,
        ///     lstItem[1]  グループコードラジオボタン,
        ///     lstItem[2]  出力順,
        ///     lstItem[3]  出力順（A-Z, Z-A）,
        ///     lstItem[4]  チェックボックス,
        ///     lstItem[5]  受注タイプ（加工区分）
        /// </param>
        /// <param name="arrDispEigyo">
        ///     表示条件（営業所）
        ///     arrDispEigyo[0] すべて,
        ///     arrDispEigyo[0] 本社,
        ///     arrDispEigyo[0] 岐阜
        /// </param>
        /// <param name="arrDispGroup">
        ///     表示条件（グループコード）
        ///     arrDispGroup[0] すべて,
        ///     arrDispGroup[1] 共通,
        ///     arrDispGroup[2] １,
        ///     arrDispGroup[3] ２,
        ///     arrDispGroup[4] ３
        /// </param>
        /// <param name="arrOrder">
        ///     並び順
        ///     arrOrder[0] 売上日,
        ///     arrOrder[1] 仕入日
        /// </param>
        /// <param name="arrOrderAtoZ">
        ///     並び順（A-Z, Z-A）
        ///     arrOrderAtoZ[0] A-Z,
        ///     arrOrderAtoZ[1] Z-A
        /// </param>
        /// <param name="arrCheckBox">
        ///     arrCheckBox[0] 逆鞘分のみ
        /// </param>
        /// <param name="arrJuchuType">
        ///     加工区分
        ///     arrJuchuType[0] 両方,
        ///     arrJuchuType[1] 通常受注,
        ///     arrJuchuType[2] 加工受注
        /// </param>
        public DataTable getUriageJisseki(List<string> lstItem, List<Array> lstItem2)
        {
            // 表示条件取得用(営業所)
            string[] arrDispEigyo = (string[])lstItem2[0];
            // 表示条件取得用(グループコード)
            string[] arrDispGroup = (string[])lstItem2[1];
            // 出力順条件取得用
            string[] arrOrder = (string[])lstItem2[2];
            // 出力順条件取得用(A-Z,Z-A)
            string[] arrOrderAtoZ = (string[])lstItem2[3];
            // チェックボックス用
            string[] arrCheckBox = (string[])lstItem2[4];
            // 受注タイプ
            string[] arrJuchuType = (string[])lstItem2[5];

            string andSql = "";
            string orderbySql = "";

            DataTable dtGetTableGrid = new DataTable();

            // 伝票年月日のStartとEnd取得
            string startYmd = lstItem[0];
            string endYmd = lstItem[1];

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("D0310_UriageJissekiKakunin");
            listSqlPath.Add("D0310_UriageJissekiKakunin_SELECT");

            // 受注者コードがある場合
            if (!lstItem[2].Equals(""))
            {
                andSql += " AND dbo.f_get受注番号_受注者コードFROM受注(um.受注番号) = '" + lstItem[2] + "'";
            }

            // 営業担当者コードがある場合
            if (!lstItem[3].Equals(""))
            {
                andSql += " AND t.担当者コード = '" + lstItem[3] + "'";
            }

            // 入力者コードがある場合
            if (!lstItem[4].Equals(""))
            {
                andSql += " AND uh.担当者コード = '" + lstItem[4] + "'";
            }

            // 仕入先コードがある場合
            if (!lstItem[5].Equals(""))
            {
                andSql += " AND dbo.f_get受注番号_発注先コードFROM発注(um.受注番号) = '" + lstItem[5] + "' ";
            }

            // 大分類コードがある場合
            if (!lstItem[6].Equals(""))
            {
                andSql += " AND um.大分類コード = '" + lstItem[6] + "' ";
            }

            // 中分類コードがある場合
            if (!lstItem[7].Equals(""))
            {
                andSql += " AND um.中分類コード = '" + lstItem[7] + "' ";
            }

            // 品名・型番がある場合
            if (!lstItem[8].Equals(""))
            {
                andSql += " AND ( (REPLACE(ISNULL(cb.中分類名,''), ' ', '') + REPLACE(ISNULL(um.Ｃ１, ''), ' ', '' ) ";
                andSql += " +  REPLACE(ISNULL(um.Ｃ２, ''), ' ', '' )";
                andSql += " +  REPLACE(ISNULL(um.Ｃ３, ''), ' ', '' )";
                andSql += " +  REPLACE(ISNULL(um.Ｃ４, ''), ' ', '' )";
                andSql += " +  REPLACE(ISNULL(um.Ｃ５, ''), ' ', '' )";
                andSql += " +  REPLACE(ISNULL(um.Ｃ６, ''), ' ', '' ) ) LIKE '%" + lstItem[8].Replace(" ", "") + "%' )";
            }

            // 備考がある場合
            if (!lstItem[9].Equals(""))
            {
                andSql += " AND um.備考 LIKE '%" + lstItem[9] + "%' ";
            }

            // 得意先コードがある場合
            if (!lstItem[10].Equals(""))
            {
                andSql += " AND uh.得意先コード = '" + lstItem[10] + "'";
            }

            // メーカーコードがある場合
            if (!lstItem[11].Equals(""))
            {
                andSql += " AND um.メーカーコード = '" + lstItem[11] + "'";
            }

            // 受注番号がある場合
            if (!lstItem[12].Equals(""))
            {
                andSql += " AND um.受注番号 = '" + lstItem[12] + "'";
            }

            // 発注番号がある場合
            if (!lstItem[13].Equals(""))
            {
                andSql += " AND dbo.f_get受注番号から発注番号FROM発注(um.受注番号) = '" + lstItem[13] + "'";
            }

            // 逆鞘分のみをチェックした場合
            if (arrCheckBox[0].Equals("TRUE"))
            {
                andSql += " AND (um.売上金額 - um.数量 * dbo.f_get受注番号_仕入単価FROM受注(um.受注番号)) < 0 ";
            }

            // 営業所が本社の場合
            if (arrDispEigyo[1].Equals("TRUE"))
            {
                andSql += " AND uh.営業所コード = '0001' ";
            }
            // 営業所が岐阜の場合
            else if (arrDispEigyo[2].Equals("TRUE"))
            {
                andSql += " AND uh.営業所コード = '0002' ";
            }

            // グループコードが共通の場合
            if (arrDispGroup[1].Equals("TRUE"))
            {
                andSql += " AND dbo.f_getグループコード(dbo.f_get受注番号_受注者コードFROM受注(um.受注番号)) = '0000' ";
            }
            // グループコードが１の場合
            else if (arrDispGroup[2].Equals("TRUE"))
            {
                andSql += " AND dbo.f_getグループコード(dbo.f_get受注番号_受注者コードFROM受注(um.受注番号)) = '0001' ";
            }
            // グループコードが２の場合
            else if (arrDispGroup[3].Equals("TRUE"))
            {
                andSql += " AND dbo.f_getグループコード(dbo.f_get受注番号_受注者コードFROM受注(um.受注番号)) = '0002' ";
            }
            // グループコードが３の場合
            else if (arrDispGroup[4].Equals("TRUE"))
            {
                andSql += " AND dbo.f_getグループコード(dbo.f_get受注番号_受注者コードFROM受注(um.受注番号)) = '0003' ";
            }

            // ラジオボタンで通常受注を選択した場合
            if (arrJuchuType[1].Equals("TRUE"))
            {
                andSql += " AND dbo.f_get受注番号から加工区分(um.受注番号)='0' ";
            }
            // ラジオボタンで加工品受注を選択した場合
            else if (arrJuchuType[2].Equals("TRUE"))
            {
                andSql += " AND dbo.f_get受注番号から加工区分(um.受注番号)='1' ";
            }

            //ラジオボタン並び順の指定（上段は名前を取得、下段：[0]A-Z、[1]Z-A）

            // 並び順（売上日）
            if (arrOrder[0].Equals("TRUE"))
            {
                // 並び順（A-Z）の場合
                if (arrOrderAtoZ[0].Equals("TRUE"))
                {
                    orderbySql += " ORDER BY TBL.伝票年月日, TBL.メーカーコード, TBL.品名型式";
                }
                else
                {
                    orderbySql += " ORDER BY TBL.伝票年月日 DESC, TBL.メーカーコード, TBL.品名型式";
                }
            }
            // 並び順（仕入日）
            else if (arrOrder[1].Equals("TRUE"))
            {
                // 並び順（A-Z）の場合
                if (arrOrderAtoZ[0].Equals("TRUE"))
                {
                    orderbySql += " ORDER BY TBL.仕入日, TBL.メーカーコード, TBL.品名型式";
                }
                else
                {
                    orderbySql += " ORDER BY TBL.仕入日 DESC, TBL.メーカーコード, TBL.品名型式";
                }
            }
            
            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, startYmd, endYmd, andSql, orderbySql);

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
            return (dtGetTableGrid);
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
                string strHeader = "売上日,伝票番号,メーカー,品名・型式,数量,単価,売上金額,原価,原価金額," +
                    "粗利額,運賃,備考,仕入先,得意先,受注番号,担当者名";

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
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["単価"].ToString())) + ",";
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["売上金額"].ToString())) + ",";
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["原価"].ToString())) + ",";
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["原価金額"].ToString())) + ",";
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["粗利額"].ToString())) + ",";
                    strDetail += string.Format("{0:#}", decimal.Parse(drSiireJisseki["運賃"].ToString())) + ",";
                    strDetail += drSiireJisseki["備考"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["仕入先名"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["得意先名"].ToString() + ",";
                    strDetail += drSiireJisseki["受注番号"].ToString().Trim() + ",";
                    strDetail += drSiireJisseki["受注担当"].ToString();

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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtUriageJisseki">
        ///     売上実績確認のデータテーブル</param>
        /// <param name="lstItem">
        ///     検索条件List  
        ///     lstItem[0]  伝票年月日Start,
        ///     lstItem[1]  伝票年月日End,
        ///     lstItem[2]  受注者コード,
        ///     lstItem[3]  営業担当者コード,
        ///     lstItem[4]  担当者コード,
        ///     lstItem[5]  仕入先コード,
        ///     lstItem[6]  大分類,
        ///     lstItem[7]  中分類,
        ///     lstItem[8]  品名・型番,
        ///     lstItem[9]  備考,
        ///     lstItem[10] 得意先,
        ///     lstItem[11] メーカー,
        ///     lstItem[12] 受注番号,
        ///     lstItem[13] 発注番号
        /// </param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtUriageJisseki, List<string> lstItem)
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
                var outDataAll = dtUriageJisseki.AsEnumerable()
                    .Select(dat => new
                    {
                        denpyoYMD = dat["伝票年月日"],
                        denpyoNo = dat["伝票番号"],
                        maker = dat["メーカー"],
                        sinameikatasiki = dat["品名型式"],
                        suuryo = dat["数量"],
                        tanaka = (decimal)dat["単価"],
                        uriagekingaku = (decimal)dat["売上金額"],
                        genka = (decimal)dat["原価"],
                        genkakingaku = (decimal)dat["原価金額"],
                        ararigaku = (decimal)dat["粗利額"],
                        untin = (decimal)dat["運賃"],
                        bikou = dat["備考"],
                        siiresakimei = dat["仕入先名"],
                        tokuisakimei = dat["得意先名"],
                        juchuNo = dat["受注番号"],
                        tantousyamei = dat["受注担当"]  //グリッドビューの表記は担当者
                    }).ToList();

                // linqで売上合計、原価合計、粗利額合計、運賃合計を算出する。
                decimal[] decKingaku = new decimal[13];
                decKingaku[0] = outDataAll.Select(gokei => gokei.uriagekingaku).Sum();
                decKingaku[1] = outDataAll.Select(gokei => gokei.genkakingaku).Sum();
                decKingaku[2] = outDataAll.Select(gokei => gokei.ararigaku).Sum();
                decKingaku[3] = outDataAll.Select(gokei => gokei.untin).Sum();
                
                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                double page = 1.0 * maxRowCnt / 38;
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
                foreach (DataRow drUriageCheckList in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "売　上　実　績　確　認　表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "O1").Merge();

                        // 入力日、伝票年月日出力（A2のセル）
                        IXLCell unitCell = headersheet.Cell("A2");
                        unitCell.Value = "  担当者：" + lstItem[2] 
                            + " 得意先: "+ lstItem[10] 
                            + "伝票年月日：" 
                            + string.Format(lstItem[0], "yyyy年MM月dd日") + " ～ "
                            + string.Format(lstItem[1], "yyyy年MM月dd日")
                            + " 大分類 ：" + lstItem[6]
                            + " 中分類 ：" + lstItem[7]
                            + " 品名・型番：" + lstItem[8]
                            + " 備考：" + lstItem[9];
                        unitCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "売上日";
                        headersheet.Cell("B3").Value = "伝票番号";
                        headersheet.Cell("C3").Value = "メーカー";
                        headersheet.Cell("D3").Value = "品名・型式";
                        headersheet.Cell("E3").Value = "数量";
                        headersheet.Cell("F3").Value = "単価";
                        headersheet.Cell("G3").Value = "売上金額";
                        headersheet.Cell("H3").Value = "原価";
                        headersheet.Cell("I3").Value = "原価金額";
                        headersheet.Cell("J3").Value = "粗利額";
                        headersheet.Cell("K3").Value = "運賃";
                        headersheet.Cell("L3").Value = "備考";
                        headersheet.Cell("M3").Value = "得意先名/仕入先名";
                        headersheet.Cell("N3").Value = "受注番号";
                        headersheet.Cell("O3").Value = "担当者名";

                        // ヘッダー列
                        headersheet.Range("A3", "O3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "O3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("A3", "O3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 10;
                        headersheet.Column(2).Width = 10;
                        headersheet.Column(3).Width = 10;
                        headersheet.Column(4).Width = 30;
                        headersheet.Column(5).Width = 5;
                        headersheet.Column(6).Width = 12;
                        headersheet.Column(7).Width = 10;
                        headersheet.Column(8).Width = 10;
                        headersheet.Column(9).Width = 10;
                        headersheet.Column(10).Width = 10;
                        headersheet.Column(11).Width = 10;
                        headersheet.Column(12).Width = 30;
                        headersheet.Column(13).Width = 24;
                        headersheet.Column(14).Width = 10;
                        headersheet.Column(15).Width = 11;

                        // 行の高さの指定
                        headersheet.Rows(4, 41).Height = 18;

                        // フォントサイズ変更
                        headersheet.Range("D4:D41").Style.Font.FontSize = 6;
                        headersheet.Range("L4:L41").Style.Font.FontSize = 6;
                        headersheet.Range("M4:M41").Style.Font.FontSize = 6;

                        // 印刷体裁（A3横、印刷範囲、余白）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A3Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
                        headersheet.PageSetup.Margins.Left = 0.5;
                        headersheet.PageSetup.Margins.Right = 0.5;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№31）");

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drUriageCheckList[colCnt-1].ToString();
                        //基本は左詰め
                        currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                        // 伝票番号の場合
                        if (colCnt == 2)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 金額セルの処理
                        if (colCnt == 5 || colCnt >= 7 && colCnt <= 11)
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

                        // 備考の場合
                        if (colCnt == 12)
                        {
                            currentsheet.Cell(xlsRowCnt, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        // 仕入先名の場合
                        if (colCnt == 13)
                        {
                            //得意先名/仕入先名とする。
                            str = drUriageCheckList[13].ToString() + "\r\n-----------------------------------------\r\n" +
                                drUriageCheckList[12].ToString();
                            currentsheet.Cell(xlsRowCnt, 13).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                            currentsheet.Cell(xlsRowCnt, 13).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        // 受注番号の場合
                        if (colCnt == 15)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt - 1).Value = str;
                            currentsheet.Cell(xlsRowCnt, colCnt - 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }
                        // 担当者名の場合
                        else if (colCnt == 16)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt - 1).Value = str;
                        }
                        // 得意先名の場合、仕入先名の処理で行っているため何もしない
                        else if (colCnt == 14)
                        {

                        }
                        else
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                        }

                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 15).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 38行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 41)
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

                    // セル結合
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 6).Merge();
                    currentsheet.Range(xlsRowCnt, 12, xlsRowCnt, 15).Merge();

                    //合計金額設定
                    currentsheet.Cell(xlsRowCnt, 7).Value = string.Format("{0,14:#,0}", decKingaku[0]);
                    currentsheet.Cell(xlsRowCnt, 8).Value = "";
                    currentsheet.Cell(xlsRowCnt, 9).Value = string.Format("{0,14:#,0}", decKingaku[1]);
                    currentsheet.Cell(xlsRowCnt, 10).Value = string.Format("{0,14:#,0}", decKingaku[2]);
                    currentsheet.Cell(xlsRowCnt, 11).Value = string.Format("{0,14:#,0}", decKingaku[3]);

                    //文字を右詰め
                    currentsheet.Cell(xlsRowCnt, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    currentsheet.Cell(xlsRowCnt, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    currentsheet.Cell(xlsRowCnt, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    currentsheet.Cell(xlsRowCnt, 11).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 15).Style
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
    }
}
