using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;

namespace KATO.Business.M1240_ShohinSiireKakakuSuii2
{
    /// <summary>
    /// M1240_ShohinSiireKakakuSuii2_B
    /// 商品仕入単価推移２ ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/8/4
    /// 更新者：多田
    /// 更新日：2017/8/4
    /// カラム論理名
    /// </summary>
    class M1240_ShohinSiireKakakuSuii2_B
    {
        /// <summary>
        /// getMaxZaikoDate
        /// 在庫年月日の最大値を取得
        /// </summary>
        public DataTable getMaxZaikoDate()
        {
            DataTable dtRireki = new DataTable();

            string strSql = "SELECT MAX(在庫年月日) FROM 商品仕入単価履歴TMP2";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtRireki = dbconnective.ReadSql(strSql);

                return dtRireki;
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
        /// updCyokkinTanka_Proc
        /// 商品仕入価格推移2_直近仕入単価更新を実行
        /// </summary>
        public void updCyokkinTanka_Proc(List<string> lstUpdateItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "商品仕入価格推移2_直近仕入単価更新 '" + lstUpdateItem[0] + "', '" + lstUpdateItem[1] +
                    "', '" + lstUpdateItem[2] + "', '" + lstUpdateItem[3] + "'";

                // 商品仕入価格推移2_直近仕入単価更新を実行
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
            return;
        }

        /// <summary>
        /// getShohin
        /// 履歴から商品単価を取得
        /// </summary>
        public DataTable getShohin(List<string> lstItem)
        {
            string strSql;
            DataTable dtRireki = new DataTable();

            strSql = "SELECT";
            strSql += " 商品コード,";
            strSql += " 売上,";
            strSql += " 仕入,";
            strSql += " dbo.f_getメーカー名(dbo.f_get商品コードからメーカーコード(商品コード)) AS メーカー名,";
            strSql += " 型番,";
            strSql += " 在庫数量,";
            strSql += " 定価,";
            strSql += " 評価単価,";
            strSql += " 掛率,";
            strSql += " 仮単価,";
            strSql += " 仮掛率,";
            strSql += " 最終売上単価,";
            strSql += " 売掛率,";
            strSql += " 最終売上日,";
            strSql += " 最終仕入単価,";
            strSql += " 入掛率,";
            strSql += " 最終仕入日";
            strSql += " FROM 商品仕入単価履歴TMP2 ";
            strSql += " WHERE 在庫年月日='" + lstItem[0] + "'";

            // 全項目にチェックが入っていない場合
            if (bool.Parse(lstItem[4]) == false)
            {
                // 期間内売上ありの場合
                if (lstItem[5].Equals("0"))
                {
                    strSql += " AND 最終売上日 IS NOT NULL";
                }
                // 期間内売上なしの場合
                else if (lstItem[5].Equals("1"))
                {
                    strSql += " AND 最終売上日 IS NULL";
                }

                // 期間内仕入ありの場合
                if (lstItem[6].Equals("0"))
                {
                    strSql += " AND 最終仕入日 IS NOT NULL";
                }
                // 期間内仕入なしの場合
                else if (lstItem[6].Equals("1"))
                {
                    strSql += " AND 最終仕入日 IS NULL";
                }
            }

            // 大分類コードが空でない場合
            if (!lstItem[1].Equals(""))
            {
                strSql += " AND dbo.f_get大分類コード(商品コード)='" + lstItem[1] + "'";
            }

            // 中分類コードが空でない場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND dbo.f_get中分類コード(商品コード)='" + lstItem[2] + "'";
            }

            // メーカーコードが空でない場合
            if (!lstItem[3].Equals(""))
            {
                strSql += " AND dbo.f_getメーカーコード(商品コード)='" + lstItem[3] + "'";
            }

            // 在庫ありの場合
            if (lstItem[7].Equals("1"))
            {
                strSql += " AND 在庫数量>0";
            }
            // 在庫なしの場合
            else if (lstItem[7].Equals("2"))
            {
                strSql += " AND 在庫数量=0";
            }

            strSql += " ORDER BY dbo.f_get大分類コード(商品コード),dbo.f_get中分類コード(商品コード),型番";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtRireki = dbconnective.ReadSql(strSql);

                return dtRireki;
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
        /// getZaikoKingaku
        /// 在庫金額を取得
        /// </summary>
        public DataTable getZaikoKingaku(string strKijunYmd)
        {
            string strSql = "";
            DataTable dtRireki = new DataTable();

            strSql = "SELECT ";
            strSql += " SUM(在庫数量*評価単価) AS 評価金額, ";
            strSql += " SUM(在庫数量*仮単価) AS 仮金額 ";
            strSql += " FROM 商品仕入単価履歴TMP2 ";
            strSql += " WHERE 在庫年月日='" + strKijunYmd + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtRireki = dbconnective.ReadSql(strSql);

                return dtRireki;
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
        /// getZaikoKingakuSettei
        /// 在庫金額を取得
        /// </summary>
        public DataTable getZaikoKingakuSettei(string strKijunYmd)
        {
            string strSql = "";
            DataTable dtRireki = new DataTable();

            strSql = "SELECT ";
            strSql += " SUM(在庫数量*仮単価) AS 仮金額 ";
            strSql += " FROM 商品仕入単価履歴TMP2 ";
            strSql += " WHERE 在庫年月日='" + strKijunYmd + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtRireki = dbconnective.ReadSql(strSql);

                return dtRireki;
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
        /// getCyokkinKingaku
        /// 直近金額を取得
        /// </summary>
        public DataTable getCyokkinKingaku(List<string> lstItem)
        {
            string strSql = "";
            DataTable dtRireki = new DataTable();

            strSql = "SELECT ";
            strSql += " SUM(在庫数量*直近仕入単価) AS 直近仕入金額 ";
            strSql += " FROM 商品仕入単価履歴TMP2 ";
            strSql += " WHERE 在庫年月日='" + lstItem[0] + "'";

            // 大分類コードが空でない場合
            if (!lstItem[1].Equals(""))
            {
                strSql += " AND dbo.f_get大分類コード(商品コード)='" + lstItem[1] + "'";
            }

            // 中分類コードが空でない場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND dbo.f_get中分類コード(商品コード)='" + lstItem[2] + "'";
            }

            // メーカーコードが空でない場合
            if (!lstItem[3].Equals(""))
            {
                strSql += " AND dbo.f_getメーカーコード(商品コード)='" + lstItem[3] + "'";
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtRireki = dbconnective.ReadSql(strSql);

                return dtRireki;
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
        /// getKariKingaku
        /// 仮金額を取得
        /// </summary>
        public DataTable getKariKingaku(List<string> lstItem)
        {
            string strSql = "";
            DataTable dtRireki = new DataTable();

            strSql = "SELECT ";
            strSql += " SUM(在庫数量*仮単価) AS 仮金額 ";
            strSql += " FROM 商品仕入単価履歴TMP2 ";
            strSql += " WHERE 在庫年月日='" + lstItem[0] + "'";
            strSql += " AND 商品コード NOT IN(";
            strSql += " SELECT 商品コード FROM 商品仕入単価履歴TMP2 ";
            strSql += " WHERE 在庫年月日='" + lstItem[0] + "'";

            // 大分類コードが空でない場合
            if (!lstItem[1].Equals(""))
            {
                strSql += " AND dbo.f_get大分類コード(商品コード)='" + lstItem[1] + "'";
            }

            // 中分類コードが空でない場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND dbo.f_get中分類コード(商品コード)='" + lstItem[2] + "'";
            }

            // メーカーコードが空でない場合
            if (!lstItem[3].Equals(""))
            {
                strSql += " AND dbo.f_getメーカーコード(商品コード)='" + lstItem[3] + "'";
            }

            strSql += ")";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtRireki = dbconnective.ReadSql(strSql);

                return dtRireki;
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
        /// updSetteiTanka
        /// 設定単価を更新
        /// </summary>
        public void updSetteiTanka(List<string> lstItem)
        {
            string strSql = "";

            strSql = " UPDATE 商品仕入単価履歴TMP2";
            strSql += " SET 仮単価 = " + decimal.Parse(lstItem[1]).ToString();

            // が空でない場合
            if (!lstItem[2].Equals(""))
            {
                strSql += "     ,仮掛率=" + lstItem[2];
            }

            strSql += " WHERE 在庫年月日='" + lstItem[0] + "'";
            strSql += " AND 商品コード='" + lstItem[3] + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 更新
                dbconnective.RunSql(strSql);

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
        /// updCyokkinTanka
        /// 直近単価を更新
        /// </summary>
        public void updCyokkinTanka(List<string> lstItem)
        {
            string strSql = "";

            strSql = " UPDATE 商品仕入単価履歴TMP2";
            strSql += " SET 仮単価 = 直近仕入単価";
            strSql += " WHERE 在庫年月日='" + lstItem[0] + "'";

            // 大分類コードが空でない場合
            if (!lstItem[1].Equals(""))
            {
                strSql += " AND dbo.f_get大分類コード(商品コード)='" + lstItem[1] + "'";
            }

            // 中分類コードが空でない場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND dbo.f_get中分類コード(商品コード)='" + lstItem[2] + "'";
            }

            // メーカーコードが空でない場合
            if (!lstItem[3].Equals(""))
            {
                strSql += " AND dbo.f_getメーカーコード(商品コード)='" + lstItem[3] + "'";
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 更新
                dbconnective.RunSql(strSql);

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
        /// getSiire
        /// 仕入日、仕入単価を取得
        /// </summary>
        public DataTable getSiire(string strShohinCd)
        {
            string strSql = "";
            DataTable dtRireki = new DataTable();

            strSql = "SELECT ";
            strSql += " 商品コード,仕入日,仕入単価 ";
            strSql += " FROM 商品仕入履歴ＴＭＰ ";
            strSql += " WHERE 商品コード='" + strShohinCd + "'";
            strSql += " ORDER BY 仕入日 DESC";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtRireki = dbconnective.ReadSql(strSql);

                return dtRireki;
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
        /// getUriage
        /// 売上日、売上単価を取得
        /// </summary>
        public DataTable getUriage(string strShohinCd)
        {
            string strSql = "";
            DataTable dtRireki = new DataTable();

            strSql = "SELECT ";
            strSql += " 商品コード,売上日,売上単価 ";
            strSql += " FROM 商品売上履歴ＴＭＰ ";
            strSql += " WHERE 商品コード='" + strShohinCd + "'";
            strSql += " ORDER BY 売上日 DESC";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtRireki = dbconnective.ReadSql(strSql);

                return dtRireki;
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
        /// getCount
        /// 件数を取得
        /// </summary>
        public DataTable getCount(string strKijunYmd)
        {
            string strSql = "";
            DataTable dtRireki = new DataTable();

            strSql = "SELECT COUNT(商品コード)";
            strSql += " FROM 商品仕入単価履歴TMP2 ";
            strSql += " WHERE 在庫年月日='" + strKijunYmd + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtRireki = dbconnective.ReadSql(strSql);

                return dtRireki;
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
        /// updCyokkinTanka_Proc
        /// 在庫一覧データ作成_PROCを実行
        /// </summary>
        public void addZaikoData_Proc(string strKijunYmd)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 在庫一覧データ作成_PROCを実行
                dbconnective.RunSql("在庫一覧データ作成_PROC '" + strKijunYmd + "'");

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

        /// <summary>
        /// suii2_Proc
        /// 商品仕入価格推移2_PROCを実行
        /// </summary>
        public void suii2_Proc(List<string> lstItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "商品仕入価格推移2_PROC '" + lstItem[0] + "', '" + lstItem[1] +
                    "', '" + lstItem[2] + "', '" + lstItem[3] + "'";

                // 商品仕入価格推移2_PROCを実行
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
            return;
        }

        /// <summary>
        /// updHyokaTanaka
        /// 評価単価を更新
        /// </summary>
        public void updHyokaTanaka(string strKijunYmd)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                string strSql;

                // トランザクション開始
                dbconnective.BeginTrans();

                strSql = "SELECT 商品コード,仮単価";
                strSql += " FROM 商品仕入単価履歴TMP2 ";
                strSql += " WHERE 在庫年月日='" + strKijunYmd + "'";
                strSql += " ORDER BY 商品コード";

                DataTable dtKariTanka = dbconnective.ReadSql(strSql);

                if (dtKariTanka != null)
                {
                    foreach (DataRow dr in dtKariTanka.Rows)
                    {
                        strSql = "SELECT 評価単価";
                        strSql += " FROM 商品";
                        strSql += " WHERE 商品コード='" + dr["商品コード"].ToString().Trim() + "'";

                        DataTable dtHyokaTanka = dbconnective.ReadSql(strSql);

                        if (dtHyokaTanka != null && dtHyokaTanka.Rows.Count > 0)
                        {
                            // 商品仕入単価履歴TMP2テーブルの仮単価と商品テーブルの評価単価が違う場合
                            if (decimal.Parse(dr["仮単価"].ToString()) != decimal.Parse(dtHyokaTanka.Rows[0]["評価単価"].ToString()))
                            {
                                strSql = " UPDATE 商品";
                                strSql += " SET ";
                                strSql += " 評価単価=" + dr["仮単価"].ToString() + ",";
                                strSql += " 更新日時='" + DateTime.Now + "',";
                                strSql += " 更新ユーザー名='" + Environment.UserName + "'";
                                strSql += " WHERE ";
                                strSql += " 商品コード='" + dr["商品コード"].ToString().Trim() + "'";

                                // 更新
                                dbconnective.RunSql(strSql);
                            }
                        }
                    }
                }

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
        ///     DataTableをもとにxlsxファイルを作成</summary>
        /// <param name="dtShohin">
        ///     商品仕入単価履歴TMP2のデータテーブル</param>
        /// <param name="lstItem">Excel出力用データ</param>
        /// <param name="strExcelFilePath">Excel出力ファイルパス</param>
        /// -----------------------------------------------------------------------------
        public void dbToExcel(DataTable dtShohin, List<string> lstItem, string strExcelFilePath)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/商品単価一覧.xlsx";
            string strShu = "";

            try
            {
                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);

                IXLWorksheet currentsheet = workbook.Worksheet(1);   // 処理中シート

                int xlsRowCnt = 14;  // Excel出力行カウント（開始は出力行）

                currentsheet.Cell("F3").Value = lstItem[0].ToString();
                currentsheet.Cell("H3").Value = lstItem[1].ToString();
                currentsheet.Cell("K3").Value = lstItem[2].ToString();
                currentsheet.Cell("G5").Value = lstItem[3].ToString();
                currentsheet.Cell("I5").Value = lstItem[4].ToString();
                currentsheet.Cell("G6").Value = lstItem[5].ToString();

                // 全項目にチェックが入っている場合
                if (bool.Parse(lstItem[6]) == true)
                {
                    strShu += "全項目";
                }
                else
                {
                    // 期間内売上ありの場合
                    if (lstItem[7].Equals("0"))
                    {
                        strShu += " 期間内売上あり";
                    }
                    // 期間内売上なしの場合
                    else if (lstItem[7].Equals("1"))
                    {
                        strShu += " 期間内売上なし";
                    }

                    // 期間内仕入ありの場合
                    if (lstItem[8].Equals("0"))
                    {
                        strShu += " 期間内仕入あり";
                    }
                    // 期間内仕入なしの場合
                    else if (lstItem[8].Equals("1"))
                    {
                        strShu += " 期間内仕入なし";
                    }
                }

                currentsheet.Cell("K5").Value = strShu;
                currentsheet.Cell("H9").Value = lstItem[9].ToString();
                currentsheet.Cell("H10").Value = lstItem[10].ToString();
                currentsheet.Cell("H11").Value = lstItem[11].ToString();

                for (int rowCnt = 1; rowCnt < dtShohin.Rows.Count; rowCnt++)
                {
                    currentsheet.Range(14, 1, 14, 16).CopyTo(currentsheet.Range(14 + rowCnt, 1, 14 + rowCnt, 16));
                }

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drShohin in dtShohin.Rows)
                {
                    for (int columnCnt = 1; columnCnt <= 16; columnCnt++)
                    {
                        currentsheet.Cell(xlsRowCnt, columnCnt).Value = drShohin[columnCnt].ToString();
                    }

                    xlsRowCnt++;
                }

                // workbookを保存
                workbook.SaveAs(strExcelFilePath);

                // workbookを解放
                workbook.Dispose();
            }
            catch
            {
                throw;
            }
        }

    }
}
