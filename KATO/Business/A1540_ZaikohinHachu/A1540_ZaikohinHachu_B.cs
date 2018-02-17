using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.IO;

namespace KATO.Business.A1540_ZaikohinHachu
{
    ///<summary>
    ///A1540_ZaikohinHachu_B
    ///在庫品発注フォーム
    ///作成者：大河内
    ///作成日：2018/2/16
    ///更新者：大河内
    ///更新日：2018/2/16
    ///カラム論理名
    ///</summary>
    class A1540_ZaikohinHachu_B
    {
        ///<summary>
        ///getZaikohinHachuGrid
        ///取引先コードから離れた時、グリッドに記載
        ///</summary>
        public DataTable getZaikohinHachuGrid(string strHachuGrid)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A1540_ZaikohinHachu");
            lstSQL.Add("ZaikohinHachu_SELECT_GRID");

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

        ///<summary>
        ///getHachuLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable getHachuLeave(string strHachuban)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("A1540_ZaikohinHachu");
            lstSQL.Add("ZaikohinHachu_SELECT_LEAVE");

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
        ///delZaikohinHachu
        ///表示した在庫品発注データを削除する
        ///</summary>
        public void delZaikohinHachu(string strHachuban, string strUserName)
        {
            string strSQL = null;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                strSQL = "在庫品発注削除_PROC '" + strHachuban + "','" + strUserName + "'";
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
        ///getNewDenpyo
        ///伝票番号テーブルから新規伝票番号を得る(在庫品発注に登録用)
        ///</summary>
        public DataTable getNewDenpyo(string strTableName)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("A1540_ZaikohinHachu");
            lstSQL.Add("ZaikohinHachu_Denpyo_UPDATE_SELECT");

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
            lstSQL.Add("A1540_ZaikohinHachu");
            lstSQL.Add("ZaikohinHachu_SELECT_Tanka");

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
        public void addZaikoHachuInput(List<string> lstStringData, List<string> lstStringTanblename)
        {
            //SQL用に移動
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //プロシージャ（戻り値なし）用のメソッドに投げる
                dbconnective.RunSql("在庫品発注更新_PROC", CommandType.StoredProcedure, lstStringData, lstStringTanblename);

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
            lstSQL.Add("A1540_ZaikohinHachu");
            lstSQL.Add("ZaikohinHachu_TantoshaData_SELECT");

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
        ///getOpenData
        ///初期表示時のグリッド
        ///</summary>
        public DataTable getOpenData()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtTantoshaCd = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A1540_ZaikohinHachu");
            lstSQL.Add("ZaikohinHachu_SELECT_OpenGRID");

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
        ///getNewDenpyoHachu
        ///伝票番号テーブルから新規伝票番号を得る(発注に登録用)
        ///</summary>
        public DataTable getNewDenpyoHachu(string strTableName)
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
        ///updZaikohinHachu
        ///在庫品発注の削除フラグを立てる
        ///</summary>
        public void updZaikohinHachu(string strHachuban)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("A1540_ZaikohinHachu");
            lstSQL.Add("ZaikohinHachu_SakujoFlg_UPDATE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strHachuban);

                //SQL接続後、
                dbconnective.RunSql(strSQLInput);

                //コミット
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
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }
    }
}
