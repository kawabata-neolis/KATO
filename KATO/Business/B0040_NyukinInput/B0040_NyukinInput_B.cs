using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KATO.Common.Util;
using System.Windows.Forms;

namespace KATO.Business.B0040_NyukinInput
{


    /// <summary>
    /// B0040_NyukinInput_B
    /// 入金入力ビジネス層
    /// 作成者：TMSOL太田
    /// 作成日：2017/06/26
    /// 更新者：大河内
    /// 更新日：2018/01/24
    /// カラム論理名
    class B0040_NyukinInput_B
    {
        /// <summary>
        /// addNyukin
        /// 表示中の入金を追加する処理
        /// </summary>
        public void addNyukin(string[] strCommonItem, string[,] strInsertItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 入金消去_PROCを実行
                dbconnective.ReadSql("入金消去_PROC '" + strCommonItem[0] + "', '" + strCommonItem[1] + "'");

                for (int cnt = 0; cnt <= 9; cnt++)
                {
                    // 取引コードがある場合
                    if (!strInsertItem[cnt, 0].Equals(""))
                    {

                        string strProc = "入金追加_PROC '" + strCommonItem[0] + "', '" + (cnt + 1).ToString() + "', '" +
                            strCommonItem[2] + "', '" + strCommonItem[3] + "', '" + strInsertItem[cnt, 0] + "', '" +
                            strInsertItem[cnt, 1] + "', ";

                        // 入金期日がない場合
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

                        // 入金追加_PROCを実行
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
                // new CommonException(ex);
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return;
        }

        /// <summary>
        /// delNyukin
        /// 表示中の入金を全削除する処理
        /// </summary>
        public void delNyukin(string[] strDeleteItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 支払全削除_PROCを実行
                DataTable dtRet = dbconnective.ReadSql("入金全削除_PROC '" + strDeleteItem[0] + "', '" + strDeleteItem[1] + "'");

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
        /// getSeikyuRireki
        /// 請求履歴を取得
        /// </summary>
        public DataTable getSeikyuRireki(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            // データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 請求履歴

            strSQLInput = strSQLInput + " SELECT 請求年月日, 入金予定年月日, 前回請求額, 入金額, 繰越額, 売上額, 消費税, 今回請求額 ";

            strSQLInput = strSQLInput + " FROM 請求履歴 WHERE 得意先コード = '"+ lstString[0] + "' ORDER BY 請求年月日 DESC ";

            // SQLのインスタンス作成
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

        /// <summary>
        /// getTorihikisakiData
        /// 取引先データを取得
        /// </summary>
        public DataTable getTorihikisakiData(List<string> lstString)
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

            // WHERE条件に入力得意先コードをバインド
            strSQLInput = string.Format(strSQLInput,lstString[0]);

            // SQLのインスタンス作成
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

        /// <summary>
        /// getTokuisakiCd
        /// 入金テーブルから得意先コードを取得する。
        /// </summary>
        public DataTable getTokuisakiCd(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            // データ渡し用
            List<string> lstStringSQL = new List<string>();


            // SQL文 請求履歴

            strSQLInput = strSQLInput + " SELECT DISTINCT 得意先コード";

            strSQLInput = strSQLInput + " FROM 入金 WHERE 伝票番号 = '"+lstString[0]+"' AND 削除 = 'N' ";

            // SQLのインスタンス作成
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


        /// <summary>
        /// getNyukinData
        /// 入金テーブルから全データを取得する。
        /// </summary>
        public DataTable getNyukinData(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            // データ渡し用
            List<string> lstStringSQL = new List<string>();


            // SQL文 請求履歴

            strSQLInput = strSQLInput + " SELECT * ";

            strSQLInput = strSQLInput + " FROM 入金 WHERE 伝票番号 = '"+lstString[0]+"' AND 削除 = 'N' ORDER BY 行番号 ";

            // SQLのインスタンス作成
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
        
        /// <summary>
        /// getDenpyoNo
        /// 伝票名から伝票番号を取得する処理
        /// </summary>
        public string getDenpyoNo()
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@テーブル名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add("入金伝票");

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
        /// getMinDenpyoNo
        /// 伝票番号の最小値を取得
        /// </summary>
        public DataTable getMinDenpyoNo(string strDenpyoNo)
        {
            DataTable dtGetDenpyoNo = new DataTable();

            // 伝票番号がある場合
            if (!strDenpyoNo.Equals(""))
            {
                string strSql = "SELECT MIN(伝票番号) AS 最小値 FROM 入金 WHERE  削除='N' AND 伝票番号 > " + strDenpyoNo;

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
        /// getMaxDenpyoNo
        /// 伝票番号の最大値を取得
        /// </summary>
        public DataTable getMaxDenpyoNo(string strDenpyoNo)
        {
            DataTable dtGetDenpyoNo = new DataTable();

            string strSql = "SELECT MAX(伝票番号) AS 最大値 FROM 入金 WHERE  削除='N'";

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
            strSql += "WHERE 画面ＮＯ ='4' ";
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
