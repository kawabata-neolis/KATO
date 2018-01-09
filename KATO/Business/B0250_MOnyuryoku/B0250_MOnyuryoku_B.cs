using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.B0250_MOnyuryoku
{
    ///<summary>
    ///B0250_MOnyuryoku_B
    ///MO入力のビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class B0250_MOnyuryoku_B
    {
        ///<summary>
        ///getViewGrid
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable getViewGrid(string strDaibunCD)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_SELECT_GetDataGridView_NOTALL");

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
                strSQLInput = string.Format(strSQLInput, strDaibunCD);

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
        ///updMO
        ///MOデータ変更の処理（戻り値は現行の名残）
        ///</summary>
        public int updMO(string strYMD,
                                string strCode,
                                object objSijisU,
                                decimal decSu,
                                decimal decTanka,
                                object objNouki,
                                object objTorihiki,
                                int intDenNo,
                                string strUserID
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

            List<string> lstDataName = new List<string>();
            lstDataName.Add(strYMD);
            lstDataName.Add(strCode);
            lstDataName.Add(objSijisU.ToString());
            lstDataName.Add(decSu.ToString());
            lstDataName.Add(decTanka.ToString());
            lstDataName.Add(objNouki.ToString());
            lstDataName.Add(objTorihiki.ToString());
            lstDataName.Add(intDenNo.ToString());
            lstDataName.Add(strUserID);

            int intExec;

            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //ＭＯデータ変更_PROCを実行
//発注担当者の登録項目を増やす必要もあり？
                intExec = int.Parse(dbconnective.RunSqlRe("ＭＯデータ変更_PROC", CommandType.StoredProcedure, lstDataName, lstTableName));

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
            return intExec;
        }

        ///<summary>
        ///delMO
        ///削除処理
        ///</summary>
        public void delMO (string strYM, string strShohinCd)
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
        ///setGridKataban2
        ///下段グリッドビューの表示
        ///</summary>
        public DataTable setGridKataban2(List<string> lstStringViewData)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtKataban = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //マイナスの型番にチェックされている場合
            if (lstStringViewData[4] == "Minus")
            {
                //lstStringViewData[6]
                lstStringViewData.Add(" AND (現在在庫数 + 発注残数量 - (売上数量*" + lstStringViewData[5] + ") )<0s");
            }
            else
            {
                lstStringViewData.Add("");
            }
            
            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_SELECT_GetDataKataban2");

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
                                            lstStringViewData[3],   //中分類コード
                                            lstStringViewData[6]    //マイナス型番にチェックされてる場合の追加WHERE
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
                                            lstStringViewData[3]   //中分類コード
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
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット(引数：[年月度],[メーカーコード],[大分類コード],[中分類コード])
                strSQLInput = string.Format(strSQLInput, lstString[0], lstString[1], lstString[2], lstString[3]);

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
                //ＭＯデータ削除_PROCを実行
                dbconnective.RunSqlRe("ＭＯデータ商品マスタチェック_PROC", CommandType.StoredProcedure, lstString, lstTableName);

                //コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw(ex);
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
                //ＭＯデータ削除_PROCを実行
                dbconnective.RunSqlRe("ＭＯデータ作成_PROC", CommandType.StoredProcedure, lstStringMOdata, lstTableName);

                //コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw(ex);
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

                //ＭＯデータ初期更新_PROCを実行
                dbconnective.RunSqlRe("ＭＯデータ初期更新_PROC", CommandType.StoredProcedure, lstDataName, lstTableName);

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

    }
}
