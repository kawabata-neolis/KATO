using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.Z0000_B
{
    ///<summary>
    ///Z0000_B
    ///メインメニューのビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class Z0000_B
    {
        ///<summary>
        ///getComment
        ///コメントの取り出し
        ///</summary>
        public DataTable getComment()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Z0000");
            lstSQL.Add("MainMenu_Comment_SELECT");

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

        ///<summary>
        ///getMyMenu
        ///データの取り出し
        ///</summary>
        public DataTable getMyMenu()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Z1500_MyMenuSet");
            lstSQL.Add("MyMenuSet_MenuSet_UPDATE");

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


        ///<summary>
        ///getData
        ///データの取り出し
        ///</summary>
        public DataTable getData(string strUserID)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Z0000");
            lstSQL.Add("MainMenu_Data_SELECT");

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
                strSQLInput = string.Format(strSQLInput, strUserID);

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
        ///getTantoshaCd
        ///担当者コードの取り出し
        ///</summary>
        public string getTantoshaCd(string strUserID)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            string strTantoshaCd = null;

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Z0000");
            lstSQL.Add("MainMenu_TantoshaCd_SELECT");

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
                    return (strTantoshaCd);
                }

//テスト
                //strUserID = "a.kato";

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strUserID);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd_B.Rows.Count > 0)
                {
                    strTantoshaCd = dtSetCd_B.Rows[0]["担当者コード"].ToString();
                }

                return (strTantoshaCd);
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
        ///getDataKengen
        ///データの取り出し(権限テーブル)
        ///</summary>
        public DataTable getDataKengen(string strTantoshaCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Z0000");
            lstSQL.Add("MainMenu_Kengen_SELECT_ALL");

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
                strSQLInput = string.Format(strSQLInput, strTantoshaCd);

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
        ///getKengen
        ///権限情報を取り出し
        ///</summary>
        public string getKengen(string strTantoshaCd, string strPGNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            string strKengen = null;

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Z0000");
            lstSQL.Add("MainMenu_Kengen_SELECT");

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
                    return (strKengen);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strTantoshaCd, strPGNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd_B.Rows.Count > 0)
                {
                    strKengen = dtSetCd_B.Rows[0]["権限"].ToString();
                }

                return (strKengen);
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
        ///updHiduke
        ///日付制限更新(一日一回)
        ///</summary>
        public void updHiduke()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();
            List<string> lstSQLUpd = new List<string>();

            //SQLファイルのパス用（Select：フォーマット前）
            string strSQLInputSel = "";

            //SQLファイルのパス用（Update：フォーマット前）
            string strSQLInputUpd = "";

            //SQLファイルのパス用（Select：フォーマット後）
            string strSqLInputSelAfter = "";

            //SQLファイルのパス用（Update：フォーマット後）
            string strSqLInputUpdAfter = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Z0000");
            lstSQL.Add("MainMenu_HidukeSeigen_SELECT");

            lstSQLUpd.Add("Z0000");
            lstSQLUpd.Add("MainMenu_HidukeSeigen_UPDATE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B_HonUri = new DataTable();
            DataTable dtSetCd_B_HonShi = new DataTable();
            DataTable dtSetCd_B_GifuUri = new DataTable();
            DataTable dtSetCd_B_GifuShi = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                //SQLファイルのパス取得
                strSQLInputSel = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInputSel == "")
                {
                    throw new Exception();
                }

                //SQLファイルのパス取得
                strSQLInputUpd = opensql.setOpenSQL(lstSQLUpd);

                //パスがなければ返す
                if (strSQLInputUpd == "")
                {
                    throw new Exception();
                }

                //SQLファイルと該当コードでフォーマット
                strSqLInputSelAfter = string.Format(strSQLInputSel, "2", "0001");

                //SQL接続後、該当データを取得（本社：売上入力）
                dtSetCd_B_HonUri = dbconnective.ReadSql(strSqLInputSelAfter);

                //初期化
                strSqLInputSelAfter = "";

                //SQLファイルと該当コードでフォーマット
                strSqLInputSelAfter = string.Format(strSQLInputSel, "3", "0001");

                //SQL接続後、該当データを取得（本社：仕入入力）
                dtSetCd_B_HonShi = dbconnective.ReadSql(strSqLInputSelAfter);

                //初期化
                strSqLInputSelAfter = "";

                //SQLファイルと該当コードでフォーマット
                strSqLInputSelAfter = string.Format(strSQLInputSel, "2", "0002");

                //SQL接続後、該当データを取得（岐阜：売上入力）
                dtSetCd_B_GifuUri = dbconnective.ReadSql(strSqLInputSelAfter);

                //初期化
                strSqLInputSelAfter = "";

                //SQLファイルと該当コードでフォーマット
                strSqLInputSelAfter = string.Format(strSQLInputSel, "3", "0002");

                //SQL接続後、該当データを取得（岐阜：仕入入力）
                dtSetCd_B_GifuShi = dbconnective.ReadSql(strSqLInputSelAfter);
                
                //本社売上の更新日時がある場合
                if (dtSetCd_B_HonUri.Rows.Count > 0)
                {
                    //年月日が違う場合
                    if (DateTime.Now.ToString("yyyy/MM/dd") != DateTime.Parse(dtSetCd_B_HonUri.Rows[0][0].ToString()).ToString("yyyy/MM/dd"))
                    {

                        //SQLファイルと該当コードでフォーマット
                        strSqLInputUpdAfter = string.Format(strSQLInputUpd, "2", 
                                                                 "0001", 
                                                                 DateTime.Now.ToString("yyyy/MM/dd"), 
                                                                 DateTime.Now.AddDays(8).ToString("yyyy/MM/dd"),
                                                                 DateTime.Now
                                                                 );

                        //SQL接続後、該当データ更新（本社：売上入力）
                        dbconnective.RunSql(strSqLInputUpdAfter);
                    }
                }
                else
                {
                    throw new Exception();
                }

                //初期化
                strSqLInputUpdAfter = "";

                //本社仕入の更新日時がある場合
                if (dtSetCd_B_HonShi.Rows.Count > 0)
                {
                    //年月日が違う場合
                    if (DateTime.Now.ToString("yyyy/MM/dd") != DateTime.Parse(dtSetCd_B_HonShi.Rows[0][0].ToString()).ToString("yyyy/MM/dd"))
                    {

                        //SQLファイルと該当コードでフォーマット
                        strSqLInputUpdAfter = string.Format(strSQLInputUpd, "3",
                                                                 "0001",
                                                                 DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd"),
                                                                 DateTime.Now.ToString("yyyy/MM/dd"),
                                                                 DateTime.Now
                                                                 );

                        //SQL接続後、該当データ更新（本社：仕入入力）
                        dbconnective.RunSql(strSqLInputUpdAfter);
                    }
                }
                else
                {
                    throw new Exception();
                }

                //初期化
                strSqLInputUpdAfter = "";

                //岐阜売上の更新日時がある場合
                if (dtSetCd_B_GifuUri.Rows.Count > 0)
                {
                    //年月日が違う場合
                    if (DateTime.Now.ToString("yyyy/MM/dd") != DateTime.Parse(dtSetCd_B_GifuUri.Rows[0][0].ToString()).ToString("yyyy/MM/dd"))
                    {
                        //SQLファイルと該当コードでフォーマット
                        strSqLInputUpdAfter = string.Format(strSQLInputUpd, "2",
                                                                 "0002",
                                                                 DateTime.Now.ToString("yyyy/MM/dd"),
                                                                 DateTime.Now.AddDays(8).ToString("yyyy/MM/dd"),
                                                                 DateTime.Now
                                                                 );

                        //SQL接続後、該当データ更新（岐阜：売上入力）
                        dbconnective.RunSql(strSqLInputUpdAfter);
                    }
                }
                else
                {
                    throw new Exception();
                }

                //初期化
                strSqLInputUpdAfter = "";

                //岐阜仕入の更新日時がある場合
                if (dtSetCd_B_GifuShi.Rows.Count > 0)
                {
                    //年月日が違う場合
                    if (DateTime.Now.ToString("yyyy/MM/dd") != DateTime.Parse(dtSetCd_B_GifuShi.Rows[0][0].ToString()).ToString("yyyy/MM/dd"))
                    {
                        //SQLファイルと該当コードでフォーマット
                        strSqLInputUpdAfter = string.Format(strSQLInputUpd, "3",
                                                                 "0002",
                                                                 DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd"),
                                                                 DateTime.Now.ToString("yyyy/MM/dd"),
                                                                 DateTime.Now
                                                                 );

                        //SQL接続後、該当データ更新（岐阜：仕入入力）
                        dbconnective.RunSql(strSqLInputUpdAfter);
                    }
                }
                else
                {
                    throw new Exception();
                }

                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                // ロールバック処理
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
