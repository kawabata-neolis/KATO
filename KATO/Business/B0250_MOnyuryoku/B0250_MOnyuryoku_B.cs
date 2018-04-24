using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.B0250_MOnyuryoku
{
    ///<summary>
    ///B0250_MOnyuryoku_B
    ///MO入力のビジネス層
    ///作成者：大河内
    ///作成日：2017/1/15
    ///更新者：大河内
    ///更新日：2017/1/23
    ///カラム論理名
    ///</summary>
    class B0250_MOnyuryoku_B
    {
        /////<summary>
        /////getViewGrid
        /////code入力箇所からフォーカスが外れた時
        /////</summary>
        //public DataTable getViewGrid(string strDaibunCD)
        //{
        //    //SQLファイルのパスとファイル名を入れる用
        //    List<string> lstSQL = new List<string>();

        //    //SQLファイルのパス用（フォーマット後）
        //    string strSQLInput = "";

        //    //SQLファイルのパスとファイル名を追加
        //    lstSQL.Add("B0250_MOnyuryoku");
        //    lstSQL.Add("MOnyuryoku_SELECT_GetDataGridView_NOTALL");

        //    //SQL実行時に取り出したデータを入れる用
        //    DataTable dtSetCd_B = new DataTable();

        //    //SQL接続
        //    OpenSQL opensql = new OpenSQL();

        //    //接続用クラスのインスタンス作成
        //    DBConnective dbconnective = new DBConnective();
        //    try
        //    {
        //        //SQLファイルのパス取得
        //        strSQLInput = opensql.setOpenSQL(lstSQL);

        //        //パスがなければ返す
        //        if (strSQLInput == "")
        //        {
        //            return (dtSetCd_B);
        //        }

        //        //SQLファイルと該当コードでフォーマット
        //        strSQLInput = string.Format(strSQLInput, strDaibunCD);

        //        //SQL接続後、該当データを取得
        //        dtSetCd_B = dbconnective.ReadSql(strSQLInput);

        //        return (dtSetCd_B);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        //トランザクション終了
        //        dbconnective.DB_Disconnect();
        //    }
        //}

        ///<summary>
        ///updMO
        ///MOデータ変更の処理（戻り値は現行の名残）
        ///</summary>
        public void updMO(string strYMD,
                                string strCode,
                                string strSijisU,
                                decimal decSu,
                                decimal decTanka,
                                string strNouki,
                                string strTorihiki,
                                int intDenNo,
                                string strUserID,
                                string strHachutantoCd
                                )
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@年月度");
            lstTableName.Add("@商品コード");
            lstTableName.Add("@ＭＯ発注指示数");
            lstTableName.Add("@ＭＯ発注数");
            lstTableName.Add("@ＭＯ発注単価");
            lstTableName.Add("@納期");
            lstTableName.Add("@取引先コード");
            lstTableName.Add("@発注番号");
            lstTableName.Add("@ユーザー名");
            lstTableName.Add("@発注担当者コード");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(strYMD);
            lstDataName.Add(strCode);
            lstDataName.Add(strSijisU.ToString());
            lstDataName.Add(decSu.ToString());
            lstDataName.Add(decTanka.ToString());
            lstDataName.Add(strNouki.ToString());
            lstDataName.Add(strTorihiki.ToString());
            lstDataName.Add(intDenNo.ToString());
            lstDataName.Add(strUserID);
            lstDataName.Add(strHachutantoCd);

            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //ＭＯデータ変更_PROCを実行
                dbconnective.RunSqlRe("ＭＯデータ変更_PROC", CommandType.StoredProcedure, lstDataName, lstTableName);

                //コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
            return;
        }

        ///<summary>
        ///delMO
        ///削除処理
        ///</summary>
        public void delMO(string strYM, string strShohinCd)
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@年月度");
            lstTableName.Add("@商品コード");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(strYM);
            lstDataName.Add(strShohinCd);

            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //ＭＯデータ削除_PROCを実行
                dbconnective.RunSqlRe("ＭＯデータ削除_PROC", CommandType.StoredProcedure, lstDataName, lstTableName);

                //コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///setGridKataban2
        ///下段グリッドビューの表示
        ///</summary>
        public DataTable setGridKataban2(List<string> lstStringViewData)
        {
            //SQL実行時に取り出したデータを入れる用(グリッドデータ取り出しに必要なデータ用)
            DataTable dtChuban = new DataTable();

            //SQL実行時に取り出したデータを入れる用(グリッド取り出し用)
            DataTable dtKataban = new DataTable();

            //SQLファイルのパスとファイル名を入れる用(グリッドデータ取り出しに必要なデータ用)
            List<string> lstSQLChuban = new List<string>();

            //SQLファイルのパスとファイル名を入れる用(グリッドデータ取り出し用)
            List<string> lstSQLKataban2 = new List<string>();

            //中分類コード用SQL
            string strSQLChubun = "";

            //中分類コードがある場合
            if (lstStringViewData[3].ToString().Trim() != "")
            {
                strSQLChubun = "AND ＭＯ.中分類コード= '" + lstStringViewData[3] + "'";
            }

            //マイナスの型番にチェックされている場合
            if (lstStringViewData[4] == "Minus")
            {
                //lstStringViewData[6]
                lstStringViewData.Add(" AND (現在在庫数 + 発注残数量 - (売上数量*" + lstStringViewData[5] + ") )<0");
            }
            else
            {
                lstStringViewData.Add("");
            }

            //SQLファイルのパス用（フォーマット後）
            string strSQLInputChuban = "";
            string strSQLInputKata2 = "";

            //SQLファイルのパスとファイル名を追加
            lstSQLChuban.Add("B0250_MOnyuryoku");
            lstSQLChuban.Add("MOnyuryoku_SELECT_Chuban");

            lstSQLKataban2.Add("B0250_MOnyuryoku");
            lstSQLKataban2.Add("MOnyuryoku_SELECT_GetDataKataban2");

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInputChuban = opensql.setOpenSQL(lstSQLChuban);

                //パスがなければ返す
                if (strSQLInputChuban == "")
                {
                    return (dtKataban);
                }

                //データ取得（ここから取得）
                dtChuban = dbconnective.ReadSql(strSQLInputChuban);

                //取り出しデータが空白込みでデータがある場合
                if (dtChuban.Rows.Count > 0)
                {
                    //データが空白の場合
                    if (dtChuban.Rows[0]["注番文字"].ToString() == "")
                    {
                        return (dtKataban);
                    }
                }

                //SQLファイルのパス取得
                strSQLInputKata2 = opensql.setOpenSQL(lstSQLKataban2);

                //パスがなければ返す
                if (strSQLInputKata2 == "")
                {
                    return (dtKataban);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInputKata2 = string.Format(strSQLInputKata2,
                                            lstStringViewData[0],                   //年月度
                                            lstStringViewData[1],                   //メーカーコード
                                            lstStringViewData[2],                   //大分類コード
                                            strSQLChubun,                           //中分類コード
                                            lstStringViewData[6],                   //マイナス型番にチェックされてる場合の追加WHERE
                                            dtChuban.Rows[0]["注番文字"].ToString() //注番文字
                                            );

                //データ取得（ここから取得）
                dtKataban = dbconnective.ReadSql(strSQLInputKata2);
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
            return (dtKataban);
        }

        ///<summary>
        ///setGridKataban1
        ///上段グリッドビューの表示
        ///</summary>
        public DataTable setGridKataban1(List<string> lstStringViewData)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtKataban = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_SELECT_GetDataKataban");

            //中分類コード用SQL
            string strSQLChubun = "";

            //中分類コードがある場合
            if (lstStringViewData[3].ToString().Trim() != "")
            {
                strSQLChubun = "AND 中分類コード= '" + lstStringViewData[3] + "'";
            }

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
                    return (dtKataban);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput,
                                            lstStringViewData[0],   //年月度
                                            lstStringViewData[1],   //メーカーコード
                                            lstStringViewData[2],   //大分類コード
                                            strSQLChubun   //中分類コード
                                            );

                //データ取得（ここから取得）
                dtKataban = dbconnective.ReadSql(strSQLInput);
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
            return (dtKataban);
        }

        ///<summary>
        ///getDataCount
        ///データのカウント取得とＭＯデータのチェック
        ///</summary>
        public DataTable getDataCount(List<string> lstString)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //中分類コード用SQL
            string strSQLChubun = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_SELECT_GetDataCnt");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //中分類コードがある場合
            if (lstString[3].ToString().Trim() != "")
            {
                strSQLChubun = "AND 中分類コード= '" + lstString[3] + "'";
            }

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

                //SQLファイルと該当コードでフォーマット(引数：[年月度],[メーカーコード],[大分類コード],[中分類コード])
                strSQLInput = string.Format(strSQLInput, lstString[0], lstString[1], lstString[2], strSQLChubun);

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
        ///updMOMasterCheck
        ///ＭＯデータ商品マスタチェック_PROC実行処理
        ///</summary>
        public void updMOMasterCheck(List<string> lstString)
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@年月");
            lstTableName.Add("@メーカーコード");
            lstTableName.Add("@大分類コード");
            lstTableName.Add("@中分類コード");
            lstTableName.Add("@ユーザー名");

            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //中分類が空の場合
                if (lstString[3].Trim() == "")
                {
                    string strSQL = "ＭＯデータ商品マスタチェック_PROC '" + lstString[0] +
                                                                    "','" + lstString[1] +
                                                                    "','" + lstString[2] +
                                                                    "', NULL" +
                                                                    ",'" + lstString[4] + "'";

                    dbconnective.RunSql(strSQL);
                }
                else
                {
                    //ＭＯデータ商品マスタチェック_PROCを実行
                    dbconnective.RunSqlRe("ＭＯデータ商品マスタチェック_PROC", CommandType.StoredProcedure, lstString, lstTableName);
                }

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
        ///updMOdata
        ///MOデータの作成
        ///</summary>
        public void updMOdata(List<string> lstStringMOdata)
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@在庫年月日");
            lstTableName.Add("@年月");
            lstTableName.Add("@月数");
            lstTableName.Add("@メーカーコード");
            lstTableName.Add("@大分類コード");
            lstTableName.Add("@中分類コード");
            lstTableName.Add("@仕入先コード");
            lstTableName.Add("@ユーザー名");

            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //中分類が空の場合
                if (lstStringMOdata[5].Trim() == "")
                {
                    string strSQL = "ＭＯデータ作成_PROC '" + lstStringMOdata[0] +
                                                "','" + lstStringMOdata[1] +
                                                "','" + lstStringMOdata[2] +
                                                "','" + lstStringMOdata[3] +
                                                "','" + lstStringMOdata[4] +
                                                "', NULL" +
                                                ",'" + lstStringMOdata[6] +
                                                "','" + lstStringMOdata[7] + "'";
                    dbconnective.RunSql(strSQL);
                }
                else
                {
                    //ＭＯデータ削除_PROCを実行
                    dbconnective.RunSql("ＭＯデータ作成_PROC", CommandType.StoredProcedure, lstStringMOdata, lstTableName);
                }

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
        ///setRirekiData
        ///履歴データの削除と保存
        ///</summary>
        public void setRirekiData(List<string> lstString)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を追加
                lstSQL.Add("B0250_MOnyuryoku");
                lstSQL.Add("MOnyuryoku_DELETE_INSERT_MOtukibetu");

                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstString[0], lstString[1], lstString[2], lstString[3]);

                //SQL接続後、該当データを取得
                dbconnective.RunSql(strSQLInput);

                return;
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
        ///setMOshoki
        ///データの数確認とＭＯデータの初期更新
        ///</summary>
        public void setMOshoki(List<string> lstString)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_SELECT_GetDataCnt");

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
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstString[1], lstString[3], lstString[4], lstString[5]);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //既にデータがある場合
                if (dtSetCd_B.Rows[0][0].ToString() == "0")
                {
                    return;
                }

                List<string> lstTableName = new List<string>();
                lstTableName.Add("@在庫年月日");
                lstTableName.Add("@年月");
                lstTableName.Add("@月数");
                lstTableName.Add("@メーカーコード");
                lstTableName.Add("@大分類コード");
                lstTableName.Add("@中分類コード");
                lstTableName.Add("@仕入先コード");
                lstTableName.Add("@ユーザー名");

                List<string> lstDataName = new List<string>();
                lstDataName.Add(lstString[0]);
                lstDataName.Add(lstString[1]);
                lstDataName.Add(lstString[2]);
                lstDataName.Add(lstString[3]);
                lstDataName.Add(lstString[4]);
                lstDataName.Add(lstString[5]);
                lstDataName.Add(lstString[6]);
                lstDataName.Add(lstString[7]);

                //中分類が空の場合
                if (lstDataName[5].Trim() == "")
                {
                    string strSQL = "ＭＯデータ初期更新_PROC '" + lstDataName[0] +
                                                "','" + lstDataName[1] +
                                                "','" + lstDataName[2] +
                                                "','" + lstDataName[3] +
                                                "','" + lstDataName[4] +
                                                "', NULL" +
                                                ",'" + lstDataName[6] +
                                                "','" + lstDataName[7] + "'";
                    dbconnective.RunSql(strSQL);
                }
                else
                {
                    //ＭＯデータ初期更新_PROCを実行
                    dbconnective.RunSqlRe("ＭＯデータ初期更新_PROC", CommandType.StoredProcedure, lstDataName, lstTableName);
                }


                //コミット
                dbconnective.Commit();
            }
            catch
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///setRirekiData
        ///履歴データの取り出し
        ///</summary>
        public DataTable getRirekiData(string strShohinCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_SELECT_GetDataGridView_Rireki");

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
        ///getYM
        ///年月情報のみの抜き取り
        ///</summary>
        private string getYM(DateTime dateYMD)
        {
            string strYM = "";

            string strY = "";
            string strM = "";

            //年の変換
            strY = dateYMD.Year.ToString();
            //月の変換
            strM = dateYMD.Month.ToString();

            //月の桁数が1の場合
            if (strM.Length < 2)
            {
                //0埋め
                strM = "0" + strM;
            }

            //売上数dtの伝票年月日をYMのみにする
            strYM = (strY + "/" + strM);

            return (strYM);
        }

        ///<summary>
        ///getTorihikiHasu
        ///取引先の端数区分を得る
        ///</summary>
        public DataTable getTorihikiHasu(string strTorihikiCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_SELECT_GetTorihikiHasu");

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
                strSQLInput = string.Format(strSQLInput, strTorihikiCd);

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
        ///updTorikeshi
        ///取り消し項目を反映
        ///</summary>
        public void updTorikeshi(string strYM, string strShohinCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_UPDATE_Torikeshi");

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strYM, strShohinCd);

                //SQL接続、追加
                dbconnective.RunSql(strSQLInput);

                //コミット開始
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
        ///updHachukoshin
        ///発注更新処理
        ///</summary>
        public void updHachukoshin(List<string> lstStringHachukoshin, List<string> lstStringMOkakuteiChubun)
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@仕入先コード");
            lstTableName.Add("@発注年月日");
            lstTableName.Add("@発注番号");
            lstTableName.Add("@発注者コード");
            lstTableName.Add("@営業所コード");
            lstTableName.Add("@担当者コード");
            lstTableName.Add("@受注番号");
            lstTableName.Add("@出庫番号");
            lstTableName.Add("@行番号");
            lstTableName.Add("@商品コード");
            lstTableName.Add("@メーカーコード");
            lstTableName.Add("@大分類コード");
            lstTableName.Add("@中分類コード");
            lstTableName.Add("@Ｃ１");
            lstTableName.Add("@Ｃ２");
            lstTableName.Add("@Ｃ３");
            lstTableName.Add("@Ｃ４");
            lstTableName.Add("@Ｃ５");
            lstTableName.Add("@Ｃ６");
            lstTableName.Add("@発注数量");
            lstTableName.Add("@発注単価");
            lstTableName.Add("@発注金額");
            lstTableName.Add("@納期");
            lstTableName.Add("@発注フラグ");
            lstTableName.Add("@注番");
            lstTableName.Add("@加工区分");
            lstTableName.Add("@仕入先名称");
            lstTableName.Add("@ユーザー名");

            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                for (int intCntRow = 0; intCntRow < lstStringMOkakuteiChubun.Count; intCntRow++)
                {
                    lstStringHachukoshin[12] = lstStringMOkakuteiChubun[intCntRow];

                    //ＭＯデータの確定処理
                    dbconnective.RunSqlRe("発注更新_PROC", CommandType.StoredProcedure, lstStringHachukoshin, lstTableName);
                }

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
        ///updMOdataKakutei
        ///ＭＯデータ確定処理
        ///</summary>
        public void updMOdataKakutei(List<string> lstStringMOKakutei)
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@年月度");
            lstTableName.Add("@商品コード");
            lstTableName.Add("@ユーザー名");

            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //ＭＯデータ削除_PROCを実行
                dbconnective.RunSqlRe("ＭＯデータ確定_PROC", CommandType.StoredProcedure, lstStringMOKakutei, lstTableName);

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
        ///getPrintData
        ///印刷情報確保
        ///</summary>
        public void setExcelData(string strDirectoryPath, string strNasiKataban)
        {
            //メモ帳を書き込むパスとファイル名
            StreamWriter sw = new System.IO.StreamWriter(strDirectoryPath + "\\未登録型番リスト.txt",
                                                     false,
                                                     System.Text.Encoding.GetEncoding("shift_jis"));
            try
            {
                //型番無しをテキストに書き込み
                sw.WriteLine(strNasiKataban);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                sw.Close();

                //ファイルを指定してメモ帳を起動する
                System.Diagnostics.Process.Start("Notepad", strDirectoryPath + "\\未登録型番リスト.txt");
            }
        }

        ///<summary>
        ///getPrintData
        ///印刷情報確保
        ///</summary>
        public DataTable getPrintData(List<string> lstPrintData)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_SELECT_GetPrintData");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //中分類コード用SQL
            string strSQLChubun = "";

            //中分類コードがある場合
            if (lstPrintData[3].ToString().Trim() != "")
            {
                strSQLChubun = "AND 中分類コード= '" + lstPrintData[3] + "'";
            }

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
                strSQLInput = string.Format(strSQLInput, lstPrintData[0], lstPrintData[1], lstPrintData[2], strSQLChubun);

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
        ///getMOData
        ///年月でMOデータを取得
        ///</summary>
        public DataTable getMOData(string strYMD)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_SELECT_YM");

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
                strSQLInput = string.Format(strSQLInput, strYMD);

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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtSetCd_B_Input">
        ///     ＭＯの印刷データテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSetCd_B_Input, List<string> lstPrintHeader)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            try
            {
                CreatePdf pdf = new CreatePdf();

                // ワークブックのデフォルトフォント、フォントサイズの指定
                XLWorkbook.DefaultStyle.Font.FontName = "ＭＳ ゴシック";
                XLWorkbook.DefaultStyle.Font.FontSize = 9;


                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled);

                IXLWorksheet worksheet = workbook.Worksheets.Add("Header");
                IXLWorksheet headersheet = worksheet;   // ヘッダーシート
                IXLWorksheet currentsheet = worksheet;  // 処理中シート

                // Linqで必要なデータをselect
                var outDataAll = dtSetCd_B_Input.AsEnumerable()
                    .Select(dat => new
                    {
                        MOHin = dat["品名規格"],
                        MOSu = dat["数量"],
                        MOHachuTanka = dat["発注単価"],
                        MONoki = dat["納期"],
                        MOShimukesaki = dat["仕向け先"],
                        MOChuban = dat["注番"],
                    }).ToList();

                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 5;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                double page = 1.0 * maxRowCnt / 47;
                double decimalpart = page % 1;
                if (decimalpart != 0)
                {
                    //小数点以下が0でない場合、+1
                    maxPage = (int)Math.Floor(page) + 1;
                }
                else
                {
                    maxPage = (int)page;
                }

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drSiireCheak in dtChkList.Rows)
                {
                    //1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "ＭＯリスト";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "H1").Merge();

                        // ヘッダー出力(表ヘッダー上）
                        headersheet.Cell("A3").Value = lstPrintHeader[0];   //年月度
                        headersheet.Cell("B3").Value = lstPrintHeader[1];   //仕向け元名

                        // ヘッダー出力(表ヘッダー)
                        headersheet.Cell("A4").Value = "品   名   ・   規   格";
                        headersheet.Cell("D4").Value = "数 量";
                        headersheet.Cell("E4").Value = "発注単価";
                        headersheet.Cell("F4").Value = "納 期";
                        headersheet.Cell("G4").Value = "仕 向 け 先";
                        headersheet.Cell("H4").Value = "注 番";

                        headersheet.Range("A4", "C4").Merge();

                        // ヘッダー列
                        headersheet.Range("A3", "B3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        headersheet.Range("A4", "H4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // 列幅の指定
                        headersheet.Column(1).Width = 20;
                        headersheet.Column(2).Width = 20;
                        headersheet.Column(3).Width = 20;
                        headersheet.Column(4).Width = 10;
                        headersheet.Column(5).Width = 15;
                        headersheet.Column(6).Width = 11;
                        headersheet.Column(7).Width = 50;
                        headersheet.Column(8).Width = 11;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A4", "H4").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        //背景を灰色にする
                        headersheet.Range("A4", "H4").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 印刷体裁（A4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№26）");

                        //ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        //マージ
                        currentsheet.Range("A" + xlsRowCnt, "C" + xlsRowCnt).Merge();

                        string str = drSiireCheak[colCnt - 1].ToString();

                        //行の高さ指定
                        currentsheet.Row(xlsRowCnt).Height = 20;

                        //品名・規格の場合
                        if (colCnt == 1)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                        //数量、発注単価の場合
                        else if (colCnt == 2 || colCnt == 3)
                        {
                            //小数点以下第二位まで表示
                            currentsheet.Cell(xlsRowCnt, colCnt + 2).Style.NumberFormat.Format = "#,0.00";

                            //マージされた分をずらす
                            currentsheet.Cell(xlsRowCnt, colCnt + 2).Value = str;
                            currentsheet.Cell(xlsRowCnt, colCnt + 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }
                        //納期、仕向け先、注番の場合
                        else
                        {
                            //マージされた分をずらす
                            currentsheet.Cell(xlsRowCnt, colCnt + 2).Value = str;
                            currentsheet.Cell(xlsRowCnt, colCnt + 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 8).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 24行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 24)
                    {
                        pageCnt++;

                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    rowCnt++;
                    xlsRowCnt++;
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
