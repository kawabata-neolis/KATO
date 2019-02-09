using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using ClosedXML.Excel;
using System.IO;

namespace KATO.Business.A0100_HachuInput_B
{
    ///<summary>
    ///A0100_HachuInput_B
    ///発注入力フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2018/2/10
    ///カラム論理名
    ///</summary>
    class A0100_HachuInput_B
    {
        ///<summary>
        ///getHachuGrid
        ///取引先コードから離れた時、グリッドに記載
        ///</summary>
        public DataTable getHachuGrid(string strHachuGrid)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0100_HachuInput");
            lstSQL.Add("HachuInput_SELECT_GRID");

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
                strSQLInput = string.Format(strSQLInput, strHachuGrid);

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

        public DataTable getHachuGrid2(string strHachuGrid)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0100_HachuInput");
            lstSQL.Add("HachuInput_SELECT_GRID");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = "";

                strSQLInput += "SELECT a.発注番号,";
                strSQLInput += "       CASE WHEN a.印刷フラグ = 1 THEN '済' ELSE '' END as 印刷フラグ,";
                strSQLInput += "       a.注番,";
                strSQLInput += "       dbo.f_getメーカー名(a.メーカーコード) as メーカー名,";
                strSQLInput += "       dbo.f_get中分類名(a.大分類コード, a.中分類コード) as 中分類名,";
                strSQLInput += "       RTRIM(ISNULL(a.Ｃ１, '')) as 型番,";
                strSQLInput += "       a.発注数量,a.納期,";
                strSQLInput += "       a.仕入先名称 AS 仕入先名";
                strSQLInput += "  FROM 発注 a";
                strSQLInput += " WHERE 仕入先コード = '" + strHachuGrid  + "'";
                strSQLInput += "   AND a.削除 = 'N'";
                strSQLInput += "   AND((a.発注数量 <> 0";
                strSQLInput += "        AND((a.仕入済数量 = 0) OR (abs(a.仕入済数量) < abs(a.発注数量))))";
                strSQLInput += "    OR a.印刷フラグ != '1')";
                strSQLInput += " ORDER BY a.納期";

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
        ///getHachuLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable getHachuLeave(string strHachuban)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("A0100_HachuInput");
            lstSQL.Add("HachuInput_SELECT_LEAVE");

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
                strSQLInput = string.Format(strSQLInput, strHachuban);

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
        ///getJuchuNoCheck
        ///受注テーブルで受注番号を検索する
        ///</summary>
        public DataTable getJuchuNoCheck(string strJuchuban)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Juchu_SELECT_LEAVE");

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
                strSQLInput = string.Format(strSQLInput, strJuchuban);

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
        ///getHachuNoCheck
        ///発注テーブルの発注番号で検索する
        ///</summary>
        public DataTable getHachuNoCheck(string strHachuban)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("A0100_HachuInput");
            lstSQL.Add("HachuInput_SELECT_LEAVE");

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
                strSQLInput = string.Format(strSQLInput, strHachuban);

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
        ///delHachu
        ///表示した発注データを削除する
        ///</summary>
        public void delHachu(string strHachuban, string strUserName)
        {
            string strSQL = null;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                strSQL = "発注削除_PROC '" + strHachuban + "','" + strUserName + "'";
                dbconnective.ReadSql(strSQL);

                //コミット開始
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
                dbconnective.DB_Disconnect();
            }
        }


        ///<summary>
        ///getJuchuRenkei
        ///受注連携の場合のチェック
        ///</summary>
        public DataTable getJuchuRenkei(string strJuchuban)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("A0100_HachuInput");
            lstSQL.Add("HachuInput_JuchuRenkei");

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
                strSQLInput = string.Format(strSQLInput, strJuchuban);

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
        ///getNewDenpyo
        ///伝票番号テーブルから新規伝票番号を得る
        ///</summary>
        public DataTable getNewDenpyo(string strTableName)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("A0100_HachuInput");
            lstSQL.Add("HachuInput_Denpyo_UPDATE_SELECT");

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
                strSQLInput = string.Format(strSQLInput, strTableName);

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
        ///getTanka
        ///発注テーブルから、過去５か月間に使用した単価を５つ取得
        ///</summary>
        public DataTable getTanka(string strTableName)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("A0100_HachuInput");
            lstSQL.Add("HachuInput_SELECT_Tanka");

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
                strSQLInput = string.Format(strSQLInput, strTableName);

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
        ///getShohin
        ///商品DBの取得
        ///</summary>
        public DataTable getShohin(string strShohinCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Shohin_SELECT_LEAVE");

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
                strSQLInput = string.Format(strSQLInput, strShohinCd);

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
        ///addHachuInput
        ///データの追加
        ///</summary>
        public void addHachuInput(List<string> lstStringData, List<string> lstStringTanblename)
        {
            //SQL用に移動
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //プロシージャ（戻り値なし）用のメソッドに投げる
                dbconnective.RunSql("発注更新_PROC", CommandType.StoredProcedure, lstStringData, lstStringTanblename);

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
        ///getTantoshaCdSetUserID
        ///担当者コードの取得（ユーザーID検索）
        ///</summary>
        public DataTable getTantoshaCdSetUserID(string strUserID)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtTantoshaCd = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_Tantosha_SELECT");

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
                    return (dtTantoshaCd);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput,
                                            strUserID   //ログインＩＤ
                                            );

                //データ取得（ここから取得）
                dtTantoshaCd = dbconnective.ReadSql(strSQLInput);
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
            return (dtTantoshaCd);
        }

        ///<summary>
        ///getTantoshaCdSetTantoCd
        ///担当者コードの取得（担当者コード検索）
        ///</summary>
        public DataTable getTantoshaCdSetTantoCd(string strUserID)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtTantoshaCd = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0100_HachuInput");
            lstSQL.Add("HachuInput_TantoshaData_SELECT");

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
                    return (dtTantoshaCd);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput,
                                            strUserID   //ログインＩＤ
                                            );

                //データ取得（ここから取得）
                dtTantoshaCd = dbconnective.ReadSql(strSQLInput);
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
            return (dtTantoshaCd);
        }

        /// <summary>
        /// getHachu
        /// 未印刷の発注を取得
        /// </summary>
        public DataTable getHachu(string strHachuNo)
        {
            DataTable dtHachu = new DataTable();
            string strSql;

            strSql = "SELECT 発注年月日 AS 年月日, ";
            strSql += "仕入先コード AS 取引先コード, ";
            strSql += "仕入先名称 + '　御中' AS 取引先名 ,";
            strSql += "'TEL: ' + dbo.f_get電話番号(仕入先コード) AS 電話番号 ,";
            strSql += "'FAX: ' + dbo.f_getＦＡＸ(仕入先コード) AS FAX ,";
            strSql += "RTRIM(dbo.f_getメーカー名(メーカーコード))";
            strSql += " + ' ' + RTRIM(dbo.f_get中分類名(大分類コード,中分類コード)) ";
            strSql += " + ' ' + CHAR(13) + CHAR(10) + Rtrim(ISNULL(Ｃ１,'')) ";
            strSql += " + ' ' + Rtrim(ISNULL(Ｃ２,''))";
            strSql += " + ' ' + Rtrim(ISNULL(Ｃ３,''))";
            strSql += " + ' ' + Rtrim(ISNULL(Ｃ４,''))";
            strSql += " + ' ' + Rtrim(ISNULL(Ｃ５,''))";
            strSql += " + ' ' + Rtrim(ISNULL(Ｃ６,'')) AS 商品名,";
            strSql += "発注数量 AS 数量, ";
            strSql += "発注単価 AS 単価, ";
            strSql += "発注金額 AS 金額, ";
            strSql += "納期 AS 納期, ";
            strSql += "RTRIM(dbo.f_get注番文字FROM担当者(発注者コード)) + CAST(発注番号 AS varchar(8)) AS 注文番号, ";
            strSql += "dbo.f_get担当者名(発注者コード) AS 発注者, ";
            strSql += "注番 AS 備考,";
            strSql += "'(' + dbo.f_get営業所名(営業所コード) + ')' AS 営業所名";
            strSql += " FROM 発注 ";
            strSql += " WHERE 削除 = 'N' ";
            strSql += " AND 発注番号='" + strHachuNo + "'";

            strSql += " ORDER BY 仕入先コード,仕入先名称,発注番号";

            // DBConnectiveのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtHachu = dbconnective.ReadSql(strSql);
            }
            catch
            {
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtHachu;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// DataTableをもとにxlsxファイルを作成し、PDFファイルを作成
        /// </summary>
        /// <param name="dtHachu">発注のデータテーブル</param>
        /// <returns>結合PDFファイル</returns>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtHachu)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/A0120_ChumonShoPrint.xlsx";
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);

                IXLWorksheet templatesheet = workbook.Worksheet(1);   // テンプレートシート
                IXLWorksheet currentsheet = null;  // 処理中シート

                int pageCnt = 0;    // ページ(シート枚数)カウント
                int xlsRowCnt = 11;  // Excel出力行カウント（開始は出力行）
                Boolean blnSheetCreate = false;
                string strTorihikisakiCd = "";
                string strHachusha = "";

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drHachu in dtHachu.Rows)
                {
                    // 取引先コードが前行と違う場合、テンプレートシート作成
                    if (!strTorihikisakiCd.Equals(drHachu[1].ToString()))
                    {
                        // 取引先コードが空でない場合
                        if (!strTorihikisakiCd.Equals(""))
                        {
                            // 明細行が17行、18行の場合
                            if (xlsRowCnt == 28 || xlsRowCnt == 29)
                            {
                                // 不要な明細行、発注者行を削除
                                currentsheet.Rows(xlsRowCnt, 33).Delete();

                                pageCnt++;
                                xlsRowCnt = 11;

                                // テンプレートシートをコピーし、1つ前のシートから取引先名などをコピー
                                templatesheet.CopyTo(templatesheet.Name);
                            }

                            // 不要な明細行を削除
                            currentsheet.Rows(xlsRowCnt, 28).Delete();

                            // 発注者
                            currentsheet.Cell(xlsRowCnt + 2, "K").Value = strHachusha;
                            currentsheet.Range(xlsRowCnt + 2, 11, xlsRowCnt + 4, 11).Merge();
                        }

                        strTorihikisakiCd = drHachu[1].ToString();      // 取引先コード
                        strHachusha = drHachu[11].ToString();           // 発注者
                        pageCnt++;
                        xlsRowCnt = 11;
                        blnSheetCreate = true;

                        // テンプレートシートからコピー
                        templatesheet.CopyTo("Page" + pageCnt.ToString());
                        currentsheet = workbook.Worksheet(workbook.Worksheets.Count);
                    }

                    // 明細行が19行になった場合
                    if (xlsRowCnt == 29)
                    {
                        // 発注者行を削除
                        currentsheet.Rows(xlsRowCnt, 33).Delete();

                        pageCnt++;
                        xlsRowCnt = 11;

                        // テンプレートシートをコピーし、1つ前のシートから取引先名などをコピー
                        templatesheet.CopyTo(templatesheet.Name);
                    }

                    // 最初の明細行の場合
                    if (blnSheetCreate)
                    {
                        blnSheetCreate = false;

                        currentsheet.Cell("A4").Value = drHachu[2].ToString();       // 取引先名
                        currentsheet.Cell("B6").Value = drHachu[3].ToString();       // 電話番号
                        currentsheet.Cell("B7").Value = drHachu[4].ToString();       // FAX
                        currentsheet.Cell("E3").Value = drHachu[0].ToString();       // 年月日
                        currentsheet.Cell("K3").Value = drHachu[13].ToString();      // 営業所名
                    }

                    currentsheet.Cell(xlsRowCnt, "A").Value = drHachu[5].ToString();    // 商品名
                    currentsheet.Cell(xlsRowCnt, "E").Value = drHachu[6].ToString();    // 数量
                    currentsheet.Cell(xlsRowCnt, "F").Value = drHachu[7].ToString();    // 単価
                    currentsheet.Cell(xlsRowCnt, "G").Value = drHachu[8].ToString();    // 金額
                    currentsheet.Cell(xlsRowCnt, "I").Value = drHachu[9].ToString();    // 納期
                    currentsheet.Cell(xlsRowCnt, "J").Value = drHachu[10].ToString();    // 注文番号
                    currentsheet.Cell(xlsRowCnt, "K").Value = "'" + drHachu[12].ToString();    // 備考

                    xlsRowCnt++;
                }

                // 発注データがある場合
                if (dtHachu.Rows.Count > 0)
                {
                    // 明細行が17行、18行の場合
                    if (xlsRowCnt == 28 || xlsRowCnt == 29)
                    {
                        // 不要な明細行、発注者行を削除
                        currentsheet.Rows(xlsRowCnt, 33).Delete();

                        pageCnt++;
                        xlsRowCnt = 11;

                        // テンプレートシートをコピーし、1つ前のシートから取引先名などをコピー
                        templatesheet.CopyTo(templatesheet.Name);
                        //this.sheetCopy(ref workbook, ref currentsheet, templatesheet, pageCnt);
                    }

                    // 不要な明細行を削除
                    currentsheet.Rows(xlsRowCnt, 28).Delete();

                    // 発注者
                    currentsheet.Cell(xlsRowCnt + 2, "K").Value = strHachusha;
                    currentsheet.Range(xlsRowCnt + 2, 11, xlsRowCnt + 4, 11).Merge();
                }

                // テンプレートシート削除
                templatesheet.Delete();

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // CreatePdfのインスタンス生成
                CreatePdf pdf = new CreatePdf();

                // ロゴ貼り付け処理
                int[] topRow = { 2 };
                int[] leftColumn = { 8 };
                pdf.logoPaste(strOutXlsFile, topRow, leftColumn, 200, 850, 57);

                // PDF化の処理
                return pdf.createPdf(strOutXlsFile, strDateTime);
            }
            catch
            {
                throw;
            }
            finally
            {
                //// Workフォルダの作成日時ファイルを取得
                //string[] files = Directory.GetFiles(strWorkPath, strDateTime + "*", SearchOption.AllDirectories);
                //// Workフォルダ内のファイル削除
                //foreach (string filepath in files)
                //{
                //    File.Delete(filepath);
                //}
            }
        }

        /// <summary>
        /// updHachu
        /// 発注を更新
        /// </summary>
        public void updHachu(string strHachuCd)
        {
            string strSql;

            strSql = "UPDATE 発注 ";
            strSql += "SET 印刷フラグ = '1' ";
            strSql += " WHERE 削除 = 'N' ";
            strSql += " AND 発注番号='" + strHachuCd + "'";

            // DBConnectiveのインスタンス作成
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
    }
}
