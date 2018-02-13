using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.B0060_ShiharaiInput_B
{

    /// <summary>
    /// B0060_ShiharaiInput_B
    /// 支払入力 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/6/23
    /// 更新者：大河内
    /// 更新日：2018/01/30
    /// カラム論理名
    /// </summary>
    class B0060_ShiharaiInput_B
    {
        /// <summary>
        /// addShiharai
        /// 表示中の支払を追加する処理
        /// </summary>
        public void addShiharai(string[] strCommonItem, string[,] strInsertItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 支払消去_PROCを実行
                dbconnective.ReadSql("支払消去_PROC '" + strCommonItem[0] + "', '" + strCommonItem[1] + "'");

                for (int cnt = 0; cnt <= 9; cnt++)
                {
                    // 取引コードがある場合
                    if (!strInsertItem[cnt, 0].Equals(""))
                    {

                        string strProc = "支払追加_PROC '" + strCommonItem[0] + "', '" + (cnt + 1).ToString() + "', '" +
                            strCommonItem[2] + "', '" + strCommonItem[3] + "', '" + strInsertItem[cnt, 0] + "', '" +
                            strInsertItem[cnt, 1] + "', ";

                        // 支払期日がない場合
                        if (strInsertItem[cnt, 2].Equals(""))
                        {
                            strProc += "NULL, ";
                        }
                        else
                        {
                            strProc += "'" + strInsertItem[cnt, 2] + "', ";
                        }

                        // 備考がない場合
                        if (strInsertItem[cnt, 3].Equals(""))
                        {
                            strProc += "NULL, ";
                        }
                        else
                        {
                            strProc += "'" + strInsertItem[cnt, 3] + "', ";
                        }

                        strProc += "'" + strCommonItem[1] + "'";

                        // 支払追加_PROCを実行
                        dbconnective.ReadSql(strProc);
                    }
                }

                // コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                // ロールバック処理
                dbconnective.Rollback();
                //new CommonException(ex);
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return;
        }


        /// <summary>
        /// delShiharai
        /// 表示中の支払を全削除する処理
        /// </summary>
        public void delShiharai(string[] strDeleteItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 支払全削除_PROCを実行
                DataTable dtRet = dbconnective.ReadSql("支払全削除_PROC '" + strDeleteItem[0] + "', '" + strDeleteItem[1] + "'");

                // コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                // ロールバック処理
                dbconnective.Rollback();
                new CommonException(ex);
                //throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return;
        }


        /// <summary>
        /// getShiharai
        /// 伝票番号から支払を取得する処理
        /// </summary>
        public DataTable getShiharai(string strDenpyoNo)
        {
            DataTable dtGetShiharai = new DataTable();
            string strSql = " SELECT * FROM 支払 WHERE 伝票番号= '" + strDenpyoNo + "' AND 削除='N' ORDER BY 行番号";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetShiharai = dbconnective.ReadSql(strSql);

                return dtGetShiharai;
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
        /// getShiharai
        /// 伝票名から伝票番号を取得する処理
        /// </summary>
        public string getDenpyoNo()
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@テーブル名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add("支払伝票");

            string strRet;

            DBConnective dbconnective = new DBConnective();
            try
            {
                // get伝票番号_PROC"を実行
                strRet = dbconnective.RunSqlRe("get伝票番号_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@番号");
            }
            catch
            {
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return strRet;

        }


        /// <summary>
        /// getShiharai
        /// 伝票番号の最小値を取得
        /// </summary>
        public DataTable getMinDenpyoNo(string strDenpyoNo)
        {
            DataTable dtGetDenpyoNo = new DataTable();

            // 伝票番号がある場合
            if (!strDenpyoNo.Equals(""))
            {
                string strSql = "SELECT MIN(伝票番号) AS 最小値 FROM 支払 WHERE  削除='N' AND 伝票番号 > " + strDenpyoNo;

                DBConnective dbconnective = new DBConnective();
                try
                {
                    // 検索データをテーブルへ格納
                    dtGetDenpyoNo = dbconnective.ReadSql(strSql);
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
            return dtGetDenpyoNo;

        }

        /// <summary>
        /// getShiharai
        /// 伝票番号の最大値を取得
        /// </summary>
        public DataTable getMaxDenpyoNo(string strDenpyoNo)
        {
            DataTable dtGetDenpyoNo = new DataTable();

            string strSql = "SELECT MAX(伝票番号) AS 最大値 FROM 支払 WHERE  削除='N'";

            // 伝票番号がある場合
            if (!strDenpyoNo.Equals(""))
            {
                strSql += " AND 伝票番号 < " + strDenpyoNo;
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetDenpyoNo = dbconnective.ReadSql(strSql);
            }
            catch
            {
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetDenpyoNo;

        }

        /// <summary>
        /// getDate
        /// 日付制限テーブルから最小年月日、最大年月日を取得
        /// </summary>
        public DataTable getDate(string strEigyoshoCd)
        {
            DataTable dtGetShiharai = new DataTable();
            string strSql;
            
            strSql = "SELECT 最小年月日, 最大年月日 FROM 日付制限 ";
            strSql += "WHERE 画面ＮＯ ='6' ";
            strSql += "AND 営業所コード ='" + strEigyoshoCd + "' ";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetShiharai = dbconnective.ReadSql(strSql);

                return dtGetShiharai;
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
        /// getSiiresakiData
        /// 取引先データを取得
        /// </summary>
        public DataTable getSiiresakiData(List<string> lstItem)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            OpenSQL opensql = new OpenSQL();

            // データ渡し用
            List<string> lstStringSQL = new List<string>();


            // SQL文 請求履歴

            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_Torihikisaki_SELECT_LEAVE");

            strSQLInput = opensql.setOpenSQL(lstStringSQL);

            // WHERE条件に入力仕入先コードをバインド
            strSQLInput = string.Format(strSQLInput, lstItem[0]);

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

            return dtGetTableGrid;
        }

        /// <summary>
        /// getSiireJissekiList
        /// 仕入実績を取得
        /// </summary>
        public DataTable getSiireJissekiList(List<string> lstItem)
        {
            string strSql;
            DataTable dtGetTableGrid = new DataTable();

            strSql = "SELECT ";

            // 締切日が31の場合
            if (lstItem[1].Equals("31"))
            {
                strSql += " CONVERT(VARCHAR(7), 伝票年月日, 111) AS 年月,";
            }
            else
            {
                strSql += " CONVERT(VARCHAR(7),DATEADD(MONTH, 1, DATEADD(DAY, -" + lstItem[1] + ", 伝票年月日), 111) AS 年月,";
            }

            strSql += " SUM(税抜合計金額) AS 税抜合計金額,";
            strSql += " SUM(消費税) AS 消費税,";
            strSql += " SUM(税抜合計金額 + 消費税) AS 税込合計金額";
            strSql += " FROM";
            strSql += " (SELECT 伝票年月日, 税抜合計金額,";
            strSql += "  CASE dbo.f_get消費税計算区分('" + lstItem[0] + "')";
            strSql += "  WHEN '0' THEN IsNull(消費税, 0)";
            strSql += "  WHEN '1' THEN IsNull(消費税, 0)";
            strSql += "  WHEN '2' THEN";
            strSql += "   CASE '" + lstItem[2] + "'";
            strSql += "   WHEN '0' THEN IsNull(FLOOR(税抜合計金額 * dbo.f_get消費税率(伝票年月日) / 100), '0')";
            strSql += "   WHEN '1' THEN IsNull(ROUND(税抜合計金額 * dbo.f_get消費税率(伝票年月日) / 100, 0), '0')";
            strSql += "   WHEN '2' THEN IsNull(CEILING(税抜合計金額 * dbo.f_get消費税率(伝票年月日) / 100), '0')";
            strSql += "   END";
            strSql += "  END AS 消費税";
            strSql += "  FROM 仕入ヘッダ";
            strSql += "  WHERE 仕入先コード = '" + lstItem[0] + "'";

            // 締切日が31の場合
            if (lstItem[1].Equals("31"))
            {
                strSql += "  AND 伝票年月日 >= DATEADD(YEAR, -3, GETDATE())";
            }
            else
            {
                strSql += "  AND 伝票年月日 >= DATEADD(MONTH, -1, DATEADD(YEAR, -3, GETDATE()))";
            }

            strSql += "  AND 伝票年月日 <= GETDATE()";
            strSql += " ) AS Z";

            // 締切日が31の場合
               if (lstItem[1].Equals("31"))
               {
                   strSql += " GROUP BY CONVERT(VARCHAR(7), 伝票年月日, 111)";
               }
               else
               {
                   strSql += " GROUP BY CONVERT(VARCHAR(7),DATEADD(MONTH, 1, DATEADD(DAY, -" + lstItem[1] + ", 伝票年月日), 111)";
               }
            strSql += " ORDER BY 年月 DESC";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをデータテーブルへ格納
                dtGetTableGrid = dbconnective.ReadSql(strSql);

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

        ///<summary>
        ///getTantoshaCd
        ///担当者データの取得
        ///</summary>
        public DataTable getTantoshaCd(string strUserID)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtTantoshaCd = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_TantoshaCd_Select");

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
    }
}
