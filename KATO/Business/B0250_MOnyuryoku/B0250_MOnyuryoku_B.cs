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

        /// <summary>
        /// getExecSProc
        /// MOデータ変更の判定
        /// </summary>
        public int getExecSProc(string strYMD,
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
            try
            {
                // get伝票番号_PROC"を実行
                intExec = int.Parse(dbconnective.RunSqlRe("get伝票番号_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@番号"));
            }
            catch
            {
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return intExec;

        }

        ///<summary>
        ///setGridKataban2
        ///グリッドビュー2の表示
        ///</summary>
        public DataTable setGridKataban2(List<string> lstStringViewData)
        {
            DataTable dtKataban = new DataTable();

            string strSQLInput = "";

            strSQLInput = strSQLInput + "SELECT";
            strSQLInput = strSQLInput + " " + "Rtrim(ISNULL(Ｃ１, '')) AS 型番,";

            //C2~C6あり版
            //strSQLInput = strSQLInput + " " + "Rtrim(ISNULL(Ｃ１, '')) +";
            //strSQLInput = strSQLInput + " " + "Rtrim(ISNULL(Ｃ２, '')) +";
            //strSQLInput = strSQLInput + " " + "Rtrim(ISNULL(Ｃ３, '')) +";
            //strSQLInput = strSQLInput + " " + "Rtrim(ISNULL(Ｃ４, '')) +";
            //strSQLInput = strSQLInput + " " + "Rtrim(ISNULL(Ｃ５, '')) +";
            //strSQLInput = strSQLInput + " " + "Rtrim(ISNULL(Ｃ６, '')) AS 型番,";

            strSQLInput = strSQLInput + "現在在庫数 AS ﾌﾘ在庫,";
            strSQLInput = strSQLInput + "売上数量 AS 売上数,";
            strSQLInput = strSQLInput + "仕入数量 AS 仕入数,";
            strSQLInput = strSQLInput + "発注残数量 AS 発注残,";
            strSQLInput = strSQLInput + "ＭＯ発注指示数 AS 発注指,";
            strSQLInput = strSQLInput + "ＭＯ発注数 AS 発注数,";
            strSQLInput = strSQLInput + "ＭＯ発注単価 AS 単価,";
            strSQLInput = strSQLInput + "ROUND(ＭＯ発注数*ＭＯ発注単価,0,0) AS 金額,";
            strSQLInput = strSQLInput + "納期,";
            strSQLInput = strSQLInput + "取引先コード AS ｺｰﾄﾞ,";
            strSQLInput = strSQLInput + "dbo.f_get取引先名称(取引先コード) AS 仕向け先名,";
            strSQLInput = strSQLInput + "RTRIM(dbo.f_get注番文字FROM担当者('0003')) + CAST(発注番号 AS varchar(8)) AS 発注番号, ";
            strSQLInput = strSQLInput + "発注番号 AS 発注番号2,";
            strSQLInput = strSQLInput + "商品コード,";

            strSQLInput = strSQLInput + "Rtrim(ISNULL(Ｃ１,'')) AS Ｃ１,";
            strSQLInput = strSQLInput + "Rtrim(ISNULL(Ｃ２,'')) AS Ｃ２,";
            strSQLInput = strSQLInput + "Rtrim(ISNULL(Ｃ３,'')) AS Ｃ３,";
            strSQLInput = strSQLInput + "Rtrim(ISNULL(Ｃ４,'')) AS Ｃ４,";
            strSQLInput = strSQLInput + "Rtrim(ISNULL(Ｃ５,'')) AS Ｃ５,";
            strSQLInput = strSQLInput + "Rtrim(ISNULL(Ｃ６,'')) AS Ｃ６,";
            strSQLInput = strSQLInput + "dbo.f_get商品箱入数(商品コード) AS 箱入数,";
            strSQLInput = strSQLInput + "dbo.f_get商品コードから最終仕入日(商品コード) AS 最終仕入日 ";

            strSQLInput = strSQLInput + "FROM ＭＯ";

            strSQLInput = strSQLInput + " WHERE 年月度 = '" + lstStringViewData[0] + "'";
            strSQLInput = strSQLInput + " AND メーカーコード = '" + lstStringViewData[1] + "'";
            strSQLInput = strSQLInput + " AND 大分類コード = '" + lstStringViewData[2] + "'";
            strSQLInput = strSQLInput + " AND 中分類コード = '" + lstStringViewData[3] + "'";
            strSQLInput = strSQLInput + " AND 確定フラグ = '0'";
            strSQLInput = strSQLInput + " AND 削除 = 'N'";

            //マイナスの型番にチェックされている場合
            if (lstStringViewData[4] == "Minus")
            {
                strSQLInput = strSQLInput + " AND (現在在庫数 + 発注残数量 - (売上数量*" + lstStringViewData[5] + ") )<0s";
            }

            strSQLInput = strSQLInput + " " + "ORDER BY Rtrim(ISNULL(Ｃ１,''))";

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
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
        ///getDataCnt
        ///データのカウント取得とＭＯデータのチェック
        ///</summary>
        public DataTable getDataCnt(List<string> lstStringViewData)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //MOマスタチェック
            string strSQLMOmasterCheck = null;

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

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstStringViewData[0], lstStringViewData[1], lstStringViewData[2], lstStringViewData[3]);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //既にデータがある場合
                if (dtSetCd_B.Rows[0][0].ToString() == "0")
                {
                    //すでにデータが存在する場合は
                    //砂時計処理
                    //waitCursor(true);

                    strSQLMOmasterCheck = "ＭＯデータ商品マスタチェック_PROC '" +
                                          lstStringViewData[0] + "','" +
                                          lstStringViewData[1] + "','" +
                                          lstStringViewData[2] + "','" +
                                          lstStringViewData[3] + "','" +
                                          lstStringViewData[4] + "'";

                    dbconnective.ReadSql(strSQLMOmasterCheck);

                    //コミット開始
                    dbconnective.Commit();
                    return (dtSetCd_B);
                }
                else
                {

                }

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
        ///updMOdata
        ///MOデータの作成
        ///</summary>
        public DataTable updMOdata(List<string> lstStringMOdata)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //MOマスタチェック
            string strSQLMOCreate = null;

            strSQLMOCreate = "ＭＯデータ作成_PROC '" +
                  lstStringMOdata[0] + "','" +
                  lstStringMOdata[1] + "','" +
                  lstStringMOdata[2] + "','" +
                  lstStringMOdata[3] + "','" +
                  lstStringMOdata[4] + "'";

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                dbconnective.ReadSql(strSQLMOCreate);

                //コミット開始
                dbconnective.Commit();
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
        ///getRirekiData
        ///履歴情報の確保
        ///</summary>
        public DataTable getRirekiData(string strOpenYMD, string strEndYMD)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQL実行時に取り出した売上数データを入れる用
            DataTable dtSetRireki = new DataTable();

            //履歴DataBoxにカラム追加
            dtSetRireki.Columns.Add("年月", typeof(string));
            dtSetRireki.Columns.Add("商品コード", typeof(string));   //表示時には消える
            dtSetRireki.Columns.Add("売上", typeof(string));
            dtSetRireki.Columns.Add("出庫", typeof(string));
            dtSetRireki.Columns.Add("仕入", typeof(string));
            dtSetRireki.Columns.Add("入庫", typeof(string));
            dtSetRireki.Columns.Add("発注残", typeof(string));
            dtSetRireki.Columns.Add("受注残", typeof(string));
            
            //SQL実行時に取り出した売上数データを入れる用
            DataTable dtSetUriagesu = new DataTable();

            //履歴dt入れる用の年月
            string strYM = "";

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を追加（売上数）
                lstSQL.Add("B0250_MOnyuryoku");
                lstSQL.Add("MOnyuryoku_SELECT_GetRirekiUriagesu");

                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetRireki);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strOpenYMD, strEndYMD);

                //SQL接続後、該当データを取得
                dtSetUriagesu = dbconnective.ReadSql(strSQLInput);

                //履歴テーブルに入れる
                for (int intCnt = 0; intCnt <= dtSetUriagesu.Rows.Count; intCnt++)
                {
                    //dt履歴に新しい行の追加
                    dtSetRireki.Rows.Add("");

                    //履歴dtに商品コードを入れる
                    dtSetRireki.Rows[intCnt]["商品コード"] = dtSetUriagesu.Rows[intCnt]["商品コード"].ToString();

                    //年月のみの抜き取り
                    strYM = getYM(DateTime.Parse(dtSetUriagesu.Rows[intCnt]["伝票年月日"].ToString()));
                    
                    //履歴dtに年月を入れる
                    dtSetRireki.Rows[intCnt]["年月"] = strYM;

                    //履歴dt売上数を入れる
                    dtSetRireki.Rows[intCnt]["売上数"] = dtSetUriagesu.Rows[intCnt]["売上数"].ToString();
                }

                return (dtSetRireki);
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

    }
}
