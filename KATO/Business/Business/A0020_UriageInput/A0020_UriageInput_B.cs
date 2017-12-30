using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;

namespace KATO.Business.A0020_UriageInput
{
    ///<summary>
    ///A0020_UriageInput_B
    ///売上入力のビジネス層
    ///作成者：
    ///作成日：2017/5/1
    ///更新者：
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class A0020_UriageInput_B
    {
        /// <summary>
        /// updUriageHeader
        /// 売上ヘッダをプロシージャーで更新する。
        /// </summary>
        public void updUriageHeader(List<string> updUriageHeaderItem)
        {

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "売上ヘッダ更新_PROC '"
                            + updUriageHeaderItem[0] + "', '"
                            + updUriageHeaderItem[1] + "', '"
                            + updUriageHeaderItem[2] + "', '"
                            + updUriageHeaderItem[3] + "', '"
                            + updUriageHeaderItem[4] + "', '"
                            + updUriageHeaderItem[5] + "', '"
                            + updUriageHeaderItem[6] + "', '"
                            + updUriageHeaderItem[7] + "', '"
                            + updUriageHeaderItem[8] + "', '"
                            + updUriageHeaderItem[9] + "', '"
                            + "" + "', '"
                            + updUriageHeaderItem[10] + "', '"
                            + updUriageHeaderItem[11] + "', '"
                            + updUriageHeaderItem[12] + "', '"
                            + updUriageHeaderItem[13] + "', '"
                            + updUriageHeaderItem[14] + "', '"
                            + updUriageHeaderItem[15] + "', '"
                            + updUriageHeaderItem[16] + "', '"
                            + updUriageHeaderItem[17] + "', '"
                            + updUriageHeaderItem[18] + "', '"
                            + updUriageHeaderItem[19] + "', '"
                            + updUriageHeaderItem[20] + "', '"
                            + updUriageHeaderItem[21] + "'";

                // 売上ヘッダ更新_PROC
                dbconnective.ReadSql(strProc);

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
        /// delUriageData
        /// 売上データを削除する。
        /// </summary>
        public void delUriageData(List<string> delUriageItem)
        {

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "売上ヘッダ削除_PROC '"
                            + delUriageItem[0] + "', '"
                            + delUriageItem[1] + "'";

                // 売上ヘッダ削除_PROC
                dbconnective.ReadSql(strProc);

                 strProc = "受注_売上数_戻し更新_PROC '"
                            + delUriageItem[0] + "', '"
                            + delUriageItem[1] + "'";

                // 受注_売上数_戻し更新_PROC
                dbconnective.ReadSql(strProc);

                 strProc = "売上明細削除_PROC '"
                            + delUriageItem[0] + "', '"
                            + delUriageItem[1] + "'";

                // 売上明細削除_PROC
                dbconnective.ReadSql(strProc);

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
        /// updInsatuzumi
        /// 伝票番号に対応する明細を印刷済みを設定する。
        /// </summary>
        public void updInsatuzumi(string Denno, string UserName, int Flag)
        {

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "売上伝票印刷済フラグセット_PROC '"
                            + UserName + "', '"
                            + DBNull.Value + "', '"
                            + DBNull.Value + "', '"
                            + DBNull.Value + "', '"
                            + DBNull.Value + "', '"
                            + Denno+ "', '"
                            + Denno + "', '"
                            + UserName + "', '"
                            + Flag + "'";

                // 売上伝票印刷済フラグセット_PROC
                dbconnective.ReadSql(strProc);

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
        /// updSyohinMastr
        /// 商品マスタ更新（プロシージャー）
        /// </summary>
        public void updSyohinMastr(List<string> lstitem ,String SyohinCD)
        {

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "商品マスタ更新_PROC '"
                            + SyohinCD + "', '"
                            + lstitem[12] + "', '"
                            + lstitem[13] + "', '"
                            + lstitem[14] + "', '"
                            + lstitem[15] + "', '"
                            + null + "', '"
                            + null + "', '"
                            + null + "', '"
                            + null + "', '"
                            + null + "', '"
                            + "Y" + "', '"
                            + 0 + "', '"
                            + lstitem[5] + "', '"
                            + "0" + "', '"
                            + "000000" + "', '"
                            + "000000" + "', '"
                            + null + "', '"
                            + lstitem[5] + "', '"
                            + 0 + "', '"
                            + 1 + "', '"
                            + lstitem[0] + "'";

                // 商品マスタ更新_PROC
                dbconnective.ReadSql(strProc);

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
        /// updUriageMeisai
        /// 売上明細更新（プロシージャー）
        /// </summary>
        public void updUriageMeisai(List<string> lstitem, String SyohinCD,string Denno,string gyoNo)
        {

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "売上明細更新_PROC '"
                            + Denno + "', '"
                            + gyoNo + "', '"
                            + lstitem[2] + "', '"
                            + SyohinCD + "', '"
                            + lstitem[12] + "', '"
                            + lstitem[13] + "', '"
                            + lstitem[14] + "', '"
                            + lstitem[15] + "', '"
                            + lstitem[16] + "', '"
                            + lstitem[17] + "', '"
                            + lstitem[18] + "', '"
                            + lstitem[19] + "', '"
                            + lstitem[20] + "', '"
                            + lstitem[4] + "', '"
                            + lstitem[5] + "', '"
                            + lstitem[6] + "', '"
                            + lstitem[7] + "', '"
                            + lstitem[8] + "', '"
                            + lstitem[9] + "', '"
                            + lstitem[10] + "', '"
                            + lstitem[0] + "'";

                // 売上明細更新_PROC
                dbconnective.ReadSql(strProc);

                //売上明細まで登録した場合はコミット！
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
        /// updUriagesuuModosi
        /// 受注＿売上数＿戻し更新
        /// </summary>
        public void updUriagesuuModosi(List<string> updUriageHeaderItem)
        {

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "受注_売上数_戻し更新_PROC '"
                            + updUriageHeaderItem[0] + "', '"
                            + updUriageHeaderItem[21] + "'";

                // 受注_売上数_戻し更新_PROC
                dbconnective.ReadSql(strProc);

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
        /// delUriageMeisai
        /// 売上明細削除
        /// </summary>
        public void delUriageMeisai(List<string> updUriageHeaderItem)
        {

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "売上明細消去_PROC '"
                            + updUriageHeaderItem[0] + "'";

                // 売上明細消去_PROC
                dbconnective.ReadSql(strProc);

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
        /// getUriageDenpyoPrint1
        /// 売上伝票印刷用のデータを取得
        /// </summary>
        public DataTable getUriageDenpyoPrint(string Denno,string UserName,int Flag,int ChokusoFLG = 0)
        {
            DataTable DtRet = new DataTable();

            List<string> lstTableName = new List<string>();
            lstTableName.Add("@ユーザーＩＤ");
            lstTableName.Add("@開始入力年月日");
            lstTableName.Add("@終了入力年月日");
            lstTableName.Add("@開始伝票年月日");
            lstTableName.Add("@終了伝票年月日");
            lstTableName.Add("@開始伝票番号");
            lstTableName.Add("@終了伝票番号");
            lstTableName.Add("@ログインＩＤ");
            lstTableName.Add("@再印刷");
            lstTableName.Add("@代納");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(null);
            lstDataName.Add(null);
            lstDataName.Add(null);
            lstDataName.Add(null);
            lstDataName.Add(null);
            lstDataName.Add(Denno);
            lstDataName.Add(Denno);
            lstDataName.Add(UserName);
            lstDataName.Add(Flag.ToString());
            lstDataName.Add(ChokusoFLG.ToString());

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                //売上伝票印刷_PROC
                DtRet = dbconnective.RunSqlReDT("売上伝票印刷_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, null);

                // コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                new CommonException(ex);

                // ロールバック処理
                dbconnective.Rollback();
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return DtRet;
        }

        /// <summary>
        /// GetCyokuCode
        /// 入力した直送先コードに該当するコードの有無をチェック
        /// </summary>
        public DataTable GetCyokuCode(List<string> lstString)
        {
            DataTable dtGetCyokuCd = new DataTable();
            string strSql = "SELECT COUNT(*) AS 直送先コードカウント FROM 直送先 WHERE 得意先コード = "+lstString[0]+"  AND 直送先コード = "+lstString[1];

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetCyokuCd = dbconnective.ReadSql(strSql);

                return dtGetCyokuCd;
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
        /// updCyokusousaki
        /// 直送先の更新
        /// </summary>
        public void updCyokusousaki(List<string> CyokuItem)
        {

            DBConnective dbconnective = new DBConnective();
            try
            {
                DataTable dtGetData = new DataTable();
                string strSql = "";

                strSql = strSql + " UPDATE 直送先 ";
                strSql = strSql + " SET	直送先名	= '" + CyokuItem[2] + "', ";
                strSql = strSql + "     郵便番号	= '" + CyokuItem[3] + "', ";
                strSql = strSql + "     住所１		= '" + CyokuItem[4] + "', ";
                strSql = strSql + "     住所２		= '" + CyokuItem[5] + "', ";
                strSql = strSql + "     電話番号	= '" + CyokuItem[6] + "', ";
                strSql = strSql + "     部署名		= '" + CyokuItem[7] + "', ";
                strSql = strSql + "     削除		= 'N', ";
                strSql = strSql + "     更新日時	= GETDATE(), ";
                strSql = strSql + "     更新ユーザー名	= '" + CyokuItem[8] + "' ";
                strSql = strSql + " WHERE	得意先コード	= '" + CyokuItem[0] + "' ";
                strSql = strSql + " AND	直送先コード	= '" + CyokuItem[1] + "' ";


                // 更新文実行
                dbconnective.RunSql(strSql);

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
        /// insCyokusousaki
        /// 直送先の登録
        /// </summary>
        public void insCyokusousaki(List<string> CyokuItem)
        {

            DBConnective dbconnective = new DBConnective();
            try
            {
                DataTable dtGetData = new DataTable();
                string strSql = "";

                strSql = strSql + "INSERT INTO 直送先 ";
                strSql = strSql + " VALUES(  ";
                strSql = strSql + " '" + CyokuItem[0] + "', ";
                strSql = strSql + " '" + CyokuItem[1] + "', ";
                strSql = strSql + " '" + CyokuItem[2] + "', ";
                strSql = strSql + " '" + CyokuItem[3] + "', ";
                strSql = strSql + " '" + CyokuItem[4] + "', ";
                strSql = strSql + " '" + CyokuItem[5] + "', ";
                strSql = strSql + " '" + CyokuItem[6] + "', ";
                strSql = strSql + " '" + CyokuItem[7] + "', ";
                strSql = strSql + " 'N', ";
                strSql = strSql + " GETDATE(), ";
                strSql = strSql + " '" + CyokuItem[8] + "', ";
                strSql = strSql + " GETDATE(), ";
                strSql = strSql + " '" + CyokuItem[8] + "' ";
                strSql = strSql + " ) ";

                // 更新文実行
                dbconnective.RunSql(strSql);

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
        /// GetTantouCode
        /// ログインＩＤから担当者コードを得る
        /// </summary>
        public DataTable GetTantouCode(List<string> lstString )
        {
            DataTable dtGetTantouCd = new DataTable();
            string strSql = "SELECT 担当者コード FROM 担当者 WHERE ログインＩＤ='" + lstString[0] + "'  and 削除='N'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetTantouCd = dbconnective.ReadSql(strSql);

                return dtGetTantouCd;
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
        /// getSyohinCd
        /// 型番から商品コードを得る。
        /// </summary>
        public DataTable getSyohinCd(List<string> lstString,string Kataban)
        {
            DataTable dtGetTantouCd = new DataTable();
            string strSql = "SELECT 商品コード FROM 商品 ";
            strSql += " WHERE 削除='N'";
            strSql += " AND メーカーコード='" + lstString[12] + "' ";
            strSql += " AND 大分類コード='" + lstString[13] + "' ";
            strSql += " AND 中分類コード='" + lstString[14] + "' ";
            strSql += " AND REPLACE(ISNULL(Ｃ１,'')+ISNULL(Ｃ２,'')+ISNULL(Ｃ３,'')+ISNULL(Ｃ４,'')+ISNULL(Ｃ５,'')+ISNULL(Ｃ６,'') ,' ' ,'')= '" + Kataban + "' ";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetTantouCd = dbconnective.ReadSql(strSql);

                return dtGetTantouCd;
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
        /// getMaxSyohinCd
        /// 商品コードの最大値を取得する。
        /// </summary>
        public DataTable getMaxSyohinCd()
        {
            DataTable dtGetTantouCd = new DataTable();
            string strSql = " SELECT MAX(商品コード) AS MAX商品コード FROM 商品 ";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetTantouCd = dbconnective.ReadSql(strSql);

                return dtGetTantouCd;
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
        /// getTorihikisakiData
        /// 取引先データを取得する。
        /// </summary>
        public DataTable getTorihikisakiData(List<string> lstString)
        {
            DataTable dtSetView = new DataTable();
            string strSql = "SELECT * FROM 取引先 WHERE 取引先コード='" + lstString[0] + "'  and 削除='N'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtSetView = dbconnective.ReadSql(strSql);

                return dtSetView;
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
        /// GetDateCheck
        /// 画面IDから日付範囲を得る。
        /// </summary>
        public DataTable GetDateCheck(List<string> lstString)
        {
            DataTable dtGetTantouCd = new DataTable();
            string strSql = "";
            strSql = strSql + "SELECT 最小年月日,最大年月日 FROM 日付制限 ";
            strSql = strSql + "WHERE 画面ＮＯ ='" + lstString[0] + "' ";
            strSql = strSql + "AND 営業所コード ='" + lstString[1] + "' ";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetTantouCd = dbconnective.ReadSql(strSql);

                return dtGetTantouCd;
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
        /// GetNextDenpyo
        /// 売上伝票において、指定した次の伝票番号を得る。
        /// </summary>
        public DataTable GetNextDenpyo(List<string> lstString)
        {
            DataTable dtGetTantouCd = new DataTable();
            string strSql = "";
            strSql = strSql + " SELECT MIN(伝票番号) AS 次伝票番号 FROM 売上ヘッダ WHERE 削除 = 'N' AND 伝票番号 >"+ lstString[0];

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetTantouCd = dbconnective.ReadSql(strSql);

                return dtGetTantouCd;
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
        /// GetPrevDenpyo
        /// 売上伝票において、指定した前の伝票番号を得る。
        /// </summary>
        public DataTable GetPrevDenpyo(string DenpyoNo = "")
        {
            
            DataTable dtGetTantouCd = new DataTable();
            string strSql = "";

            //伝票番号の入力値により、SQL文を変更
            if (DenpyoNo == "")
            {
                strSql = strSql + " SELECT MAX(伝票番号) AS 前伝票番号 FROM 売上ヘッダ WHERE 削除 = 'N' ";
            }
            else
            {
                strSql = strSql + " SELECT MAX(伝票番号) AS 前伝票番号 FROM 売上ヘッダ WHERE 削除 = 'N' AND 伝票番号 < " + DenpyoNo;
            }


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetTantouCd = dbconnective.ReadSql(strSql);

                return dtGetTantouCd;
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
        /// GetCyokusousakiDateCheck
        /// 直送先データリストの取得。
        /// </summary>
        public DataTable GetCyokusousakiDateCheck(List<string> lstString)
        {

            DataTable dtGetTantouCd = new DataTable();
            string strSql = "";
            
            strSql = strSql + "SELECT * FROM 直送先 ";
            strSql = strSql + "WHERE 得意先コード='" +lstString[0]+ "'";
            strSql = strSql + " AND 直送先コード='" +lstString[1]+ "'";
            strSql = strSql + " AND 削除='N'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetTantouCd = dbconnective.ReadSql(strSql);

                return dtGetTantouCd;
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
        /// DC_getEigyosyoCd
        /// 受注Noから営業所コードを取得する。
        /// </summary>
        public DataTable DC_getEigyosyoCd(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT 営業所コード ";
            strSql = strSql + " FROM 受注  ";
            strSql = strSql + " WHERE 削除 = 'N' ";
            strSql = strSql + " AND 受注番号=" + lstString[0];

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// DC_getJucyu
        /// 受注Noと営業所コードから受注データを取得する。
        /// </summary>
        public DataTable DC_getJucyu(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT * ";
            strSql = strSql + " FROM 受注  ";
            strSql = strSql + " WHERE 削除 = 'N' ";
            strSql = strSql + " AND 在庫引当フラグ IN (0,2) ";
            strSql = strSql + " AND 発注指示区分=0";
            strSql = strSql + " AND 営業所コード='" + lstString[1] + "'";
            strSql = strSql + " AND 受注番号=" + lstString[0];

            if (lstString[1] == "0001")
            {
                strSql = strSql + " AND 岐阜出庫数 >0 ";
            }
            else
            {
                strSql = strSql + " AND 本社出庫数 >0 ";
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// DC_Syukko_Nyuuko
        /// 出庫データ作成 処理区分　⇒　１：受注　２：出庫依頼　取引区分　⇒　５１：庫間出　５２：庫間入
        /// 入庫データ作成
        /// </summary>
        public void DC_Syukko_Nyuuko(List<string> SyukkoyouItem, List<string> NyuukoyouItem)
        {

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "倉庫間移動更新_PROC '" + "', '" 
                            + SyukkoyouItem[0] + "', '" 
                            + SyukkoyouItem[1] + "', '"
                            + SyukkoyouItem[2] + "', '"
                            + SyukkoyouItem[3] + "', '"
                            + SyukkoyouItem[4] + "', '"
                            + SyukkoyouItem[5] + "', '"
                            + SyukkoyouItem[6] + "', '"
                            + SyukkoyouItem[7] + "', '"
                            + SyukkoyouItem[8] + "', '"
                            + SyukkoyouItem[9] + "', '"
                            + SyukkoyouItem[10] + "', '"
                            + SyukkoyouItem[11] + "', '"
                            + SyukkoyouItem[12] + "', '"
                            + SyukkoyouItem[13] + "', '"
                            + SyukkoyouItem[14] + "', '"
                            + SyukkoyouItem[15] + "', '"
                            + SyukkoyouItem[16] + "', '"
                            + SyukkoyouItem[17] + "', '"
                            + SyukkoyouItem[18] + "', '"
                            + SyukkoyouItem[19] + "', '"
                            + SyukkoyouItem[20];

                // 倉庫間移動更新_PROC(出庫)
                dbconnective.ReadSql(strProc);

                 strProc = "倉庫間移動更新_PROC '" + "', '"
                            + NyuukoyouItem[0] + "', '"
                            + NyuukoyouItem[1] + "', '"
                            + NyuukoyouItem[2] + "', '"
                            + NyuukoyouItem[3] + "', '"
                            + NyuukoyouItem[4] + "', '"
                            + NyuukoyouItem[5] + "', '"
                            + NyuukoyouItem[6] + "', '"
                            + NyuukoyouItem[7] + "', '"
                            + NyuukoyouItem[8] + "', '"
                            + NyuukoyouItem[9] + "', '"
                            + NyuukoyouItem[10] + "', '"
                            + NyuukoyouItem[11] + "', '"
                            + NyuukoyouItem[12] + "', '"
                            + NyuukoyouItem[13] + "', '"
                            + NyuukoyouItem[14] + "', '"
                            + NyuukoyouItem[15] + "', '"
                            + NyuukoyouItem[16] + "', '"
                            + NyuukoyouItem[17] + "', '"
                            + NyuukoyouItem[18] + "', '"
                            + NyuukoyouItem[19] + "', '"
                            + NyuukoyouItem[20];

                // 倉庫間移動更新_PROC(入庫)
                dbconnective.ReadSql(strProc);

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
        /// DC_updHikiateflg
        /// 倉庫間移動データ作成済セット
        /// </summary>
        public void DC_updHikiateflg(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "UPDATE 受注 ";
            strSql = strSql + " SET 在庫引当フラグ = 1  ";
            strSql = strSql + " WHERE 在庫引当フラグ <> 1 ";
            strSql = strSql + " AND   受注番号=" + lstString[0];


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                 dbconnective.RunSql(strSql);

                 dbconnective.Commit();

                return ;
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
        /// updSyohinCD
        /// 受注テーブルの商品コードを更新する。
        /// </summary>
        public void updJTableSyohinCD(List<string> lstString,string SyohinCD)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + " UPDATE 受注 ";
            strSql = strSql + " SET 商品コード='" + SyohinCD + "'";
            strSql = strSql + " WHERE 受注番号=" + lstString[2];


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dbconnective.RunSql(strSql);

                dbconnective.Commit();

                return;
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
        /// updSyohinCD
        /// 発注テーブルの商品コードを更新する。
        /// </summary>
        public void updHTableSyohinCD(List<string> lstString, string SyohinCD,string Kataban)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + " UPDATE 発注 ";
            strSql = strSql + " SET 商品コード='" + SyohinCD + "'";
            strSql = strSql + " WHERE 受注番号=" + lstString[2];
            strSql = strSql + " AND     商品コード='88888'";
            strSql = strSql + " AND     仕入先コード='9999'";
            strSql = strSql + " AND REPLACE(ISNULL(Ｃ１,'')+ISNULL(Ｃ２,'')+ISNULL(Ｃ３,'')+ISNULL(Ｃ４,'')+ISNULL(Ｃ５,'')+ISNULL(Ｃ６,'') ,' ' ,'')= '" + Kataban + "' ";
            strSql = strSql + " AND     削除='N'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dbconnective.RunSql(strSql);

                dbconnective.Commit();
                return;
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
        /// updJTableTokuisakiName
        /// 受注テーブルの得意先名称を更新する。
        /// </summary>
        public void updJTableTokuisakiName(List<string> UriageMeisaiItem,List<string> UriageInputItem)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + " UPDATE 受注 ";
            strSql = strSql + " SET 得意先名称='" + UriageInputItem[3] + "'";
            strSql = strSql + " WHERE 受注番号=" + UriageMeisaiItem[2];

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dbconnective.RunSql(strSql);

                dbconnective.Commit();

                return;
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
        /// getShiharai
        /// 伝票名から伝票番号を取得する処理
        /// </summary>
        public string getDenpyoNo(string DenName)
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@テーブル名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(DenName);

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
        /// DBROLLBACK
        /// データベースをロールバックする。
        /// </summary>
        public void DBROLLBACK()
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // ロールバック処理
                dbconnective.Rollback();
                return;
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
        /// getJucyuSuuryo
        /// 受注Noから受注数量を取得する。
        /// </summary>
        public DataTable getJucyuSuuryo(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT 受注数量 FROM 受注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getSumUriageSuuryo
        /// 売上明細から売上数量の合計を取得する。
        /// </summary>
        public DataTable getSumUriageSuuryo(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT SUM(数量) AS 合計売上数量 FROM 売上明細 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getCurrentRowUriageSuuryo
        /// 売上明細から現在行の数量を取得する
        /// </summary>
        public DataTable getCurrentRowUriageSuuryo(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT 数量 FROM 売上明細 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 伝票番号=" + lstString[0];
            strSql = strSql + " AND 行番号=" + lstString[1];


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getJucyu
        /// 受注番号から受注データを取得する。
        /// </summary>
        public DataTable getJucyu(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT 得意先コード,商品コード,メーカーコード,大分類コード,中分類コード,Ｃ１,Ｃ２,Ｃ３,Ｃ４,Ｃ５,Ｃ６,";
            strSql = strSql + "受注数量,受注単価,仕入単価,納期,注番,売上フラグ,売上済数量,得意先名称,本社出庫数,岐阜出庫数,営業所コード";
            strSql = strSql + " FROM 受注";
            strSql = strSql + " WHERE 受注番号=" + lstString[0];


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getHacyusijiKbn
        /// 受注番号から発注指示区分を取得する。
        /// </summary>
        public DataTable getHacyusijiKbn(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT 発注指示区分 FROM 受注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getSaisyuSiirebi
        /// 受注番号から最終仕入先日
        /// </summary>
        public DataTable getSaisyuSiirebi(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT dbo.f_get受注番号から最終仕入先日(" +lstString[0]+ ") AS 最終仕入先日  ";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getTokuisakiCd
        /// 受注番号から得意先コードを取得する。
        /// </summary>
        public DataTable getTokuisakiCd(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT J.得意先コード AS 得意先コード FROM 受注 J,発注 H ";
            strSql = strSql + " WHERE J.削除='N'";
            strSql = strSql + " AND H.削除='N'";
            strSql = strSql + " AND J.受注番号=" + lstString[0];
            strSql = strSql + " AND J.受注番号=H.受注番号";
            strSql = strSql + " AND H.仕入先コード='7777'";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getKakouHacyuCount
        /// 加工区分が1の発注データをカウントする。
        /// </summary>
        public DataTable getKakouHacyuCount(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) AS 加工品発注カウント FROM 発注 WHERE 受注番号=" +lstString[0]+ " AND 削除='N' AND 加工区分='1' ";
            
            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getSyohinbeturiekiritu
        /// 商品別利益率情報を取得する。
        /// </summary>
        public DataTable getSyohinbeturiekiritu(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT * FROM 商品別利益率 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 設定='1'";
            strSql = strSql + " AND 得意先コード='" + lstString[0] + "'";
            strSql = strSql + " AND 商品コード='" + lstString[1] + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getBunruiMaker
        /// 商品コードから大分類・中分類・メーカコードを取得する。
        /// </summary>
        public DataTable getBunruiMaker(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT 大分類コード,中分類コード,メーカーコード FROM 商品 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 商品コード='" +lstString[1]+ "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getSyohinbunruiriekiritu3items
        /// 大分類・中分類・メーカから商品分類別利益率を取得する。
        /// </summary>
        public DataTable getSyohinbunruiriekiritu3items(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT * FROM 商品分類別利益率 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 設定='1'";
            strSql = strSql + " AND 得意先コード='" +lstString[0] + "'";
            strSql = strSql + " AND 大分類コード='" + lstString[2] + "'";
            strSql = strSql + " AND 中分類コード='" + lstString[3] + "'";
            strSql = strSql + " AND メーカーコード='" + lstString[4] + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getSyohinbunruiriekirituDaiCyu
        /// 大分類・中分類から商品分類別利益率を取得する。
        /// </summary>
        public DataTable getSyohinbunruiriekirituDaiCyu(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT * FROM 商品分類別利益率 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 設定='1'";
            strSql = strSql + " AND 得意先コード='" + lstString[0] + "'";
            strSql = strSql + " AND 大分類コード='" + lstString[2] + "'";
            strSql = strSql + " AND 中分類コード='" + lstString[3] + "'";
            strSql = strSql + " AND メーカーコード IS NULL ";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getSyohinbunruiriekirituDaiMaker
        /// 大分類・メーカコードから商品分類別利益率を取得する。
        /// </summary>
        public DataTable getSyohinbunruiriekirituDaiMaker(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT * FROM 商品分類別利益率 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 設定='1'";
            strSql = strSql + " AND 得意先コード='" + lstString[0] + "'"; 
            strSql = strSql + " AND 大分類コード='" + lstString[2] + "'";
            strSql = strSql + " AND 中分類コード IS NULL ";
            strSql = strSql + " AND メーカーコード='" + lstString[4] + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getzaikosuu
        /// 指定日の在庫数を取得する。
        /// </summary>
        public DataTable getzaikosuu(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT dbo.f_get指定日の在庫数('" + lstString[0] + "' ,'" + lstString[1] + "' ,'"+DateTime.Parse(lstString[2]).ToString("yyyy/MM/dd")+"') AS 指定日の在庫数 ";
             
            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getHacyuCount
        /// 受注番号から発注データをカウントする。
        /// </summary>
        public DataTable getHacyuCount(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) AS 発注カウント FROM 発注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getKatbanHacyuCount
        /// 受注番号と型番から発注データをカウントする。
        /// </summary>
        public DataTable getKatbanHacyuCount(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) AS 型番発注カウント  FROM 発注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];
            strSql = strSql + " AND REPLACE(ISNULL(Ｃ１,'')+ISNULL(Ｃ２,'')+ISNULL(Ｃ３,'')+ISNULL(Ｃ４,'')+ISNULL(Ｃ５,'')+ISNULL(Ｃ６,'') ,' ' ,'')= '" + lstString[1] + "' ";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getKatbanHacyuCount
        /// 受注番号と仕入先コードの指定から発注データをカウントする。
        /// </summary>
        public DataTable getSiiresakiSiteiHacyuCount(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) AS 仕入先指定発注カウント FROM 発注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];
            strSql = strSql + " AND 仕入先コード<>'9999'";           //2006.6.13  返品口座は除く
            strSql = strSql + " AND 仕入先コード<>'7777'";           //2006.6.15  仕入先手数料口座は除く

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// SiirezumiSuuryoHacyuCount
        /// 仕入済数量が０の発注データをカウントする。
        /// </summary>
        public DataTable SiirezumiSuuryoHacyuCount(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) AS 仕入済数量発注カウント FROM 発注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];
            strSql = strSql + " AND 仕入済数量=0";
            strSql = strSql + " AND 仕入先コード<>'9999'";           //2006.6.13  返品口座は除く
            strSql = strSql + " AND 仕入先コード<>'7777'";           //2006.6.15  仕入先手数料口座は除く

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getSuryoSiteiJuhacyu
        /// 数量が0未満の受発注データをカウントする。
        /// </summary>
        public DataTable getSuryoSiteiJuhacyu(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) 数量0未満受発注カウント FROM 受注 J,発注 H ";
            strSql = strSql + " WHERE J.削除='N'";
            strSql = strSql + " AND H.削除='N'";
            strSql = strSql + " AND 仕入済数量=0";
            strSql = strSql + " AND J.受注番号=" +lstString[0];
            strSql = strSql + " AND J.受注番号=H.受注番号";
            strSql = strSql + " AND ( (" + lstString[1] + "<0) ) ";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getJucyuSuryositeiJuhacyuCount
        /// 受注数量が0未満の受発注データをカウントする。
        /// </summary>
        public DataTable getJucyuSuryositeiJuhacyuCount(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) 受注数量0未満受発注カウント FROM 受注 J,発注 H ";
            strSql = strSql + " WHERE J.削除='N'";
            strSql = strSql + " AND H.削除='N'";
            strSql = strSql + " AND J.受注番号=" + lstString[0];
            strSql = strSql + " AND J.受注番号=H.受注番号";
            strSql = strSql + " AND J.受注数量<0 ";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// getSuryoSiteiJuhacyu
        /// 返品値引き売上承認フラグを取得する。
        /// </summary>
        public DataTable getHenpinNebikiUriageSyoninFlg(List<string> lstString)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT dbo.f_get返品値引売上承認フラグ(" + lstString[0] + ") AS 返品値引売上承認フラグ";
            
            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = dbconnective.ReadSql(strSql);

                return dtGetData;
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
        /// GetUriageInput
        /// 伝票NOから売上データを取得する。
        /// </summary>
        public DataTable GetUriageInput(List<string> lstString)
        {
            DataTable dtUriageInput = new DataTable();
            string strSql = " SELECT * FROM 売上ヘッダ WHERE 伝票番号= '" + lstString[0] + "' AND 削除='N'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtUriageInput = dbconnective.ReadSql(strSql);

                return dtUriageInput;
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
        /// GetKensyuzumiUriagemeisai
        /// 検収済の売上明細を取得する。
        /// </summary>
        public DataTable GetKensyuzumiUriagemeisai(List<string> lstString)
        {
            DataTable dtUriageInput = new DataTable();
            string strSql = "SELECT COUNT(*) AS 検収済カウント FROM 検収済売上明細 WHERE 伝票番号=" +lstString[0]+ " AND 検収済='済'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtUriageInput = dbconnective.ReadSql(strSql);

                return dtUriageInput;
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
        /// GetJucyuMeisai
        /// 伝票Noから受注明細を取得する。
        /// </summary>
        public DataTable GetJucyuMeisai(List<string> lstString)
        {
            DataTable dtJucyuMeisai = new DataTable();
            string strSql = " SELECT *,dbo.f_getメーカー名(売上明細.メーカーコード) AS メーカー名 FROM 売上明細 WHERE 伝票番号= '" + lstString[0] + "' AND 削除='N' ORDER BY 行番号";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtJucyuMeisai = dbconnective.ReadSql(strSql);

                return dtJucyuMeisai;
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
        /// GeUriageSakujoCheckt
        /// 伝票Noから売上削除確認を行う。
        /// </summary>
        public DataTable GeUriageSakujoCheckt(List<string> lstString)
        {
            DataTable dtJucyuMeisai = new DataTable();
            string strSql = "SELECT 承認 FROM 売上削除承認 WHERE 伝票番号=" + lstString[0];

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtJucyuMeisai = dbconnective.ReadSql(strSql);

                return dtJucyuMeisai;
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

        ///------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化
        /// </summary>
        /// <param name="dtNouhinHikae">納品書（控）のデータテーブル</param>
        /// <param name="dtNouhin">納品書のデータテーブル</param>
        /// <param name="dtJuryo">受領書のデータテーブル</param>
        /// <param name="lstItem">検索に使用するデータリスト</param>
        /// <returns>ファイルパス</returns>
        /// -----------------------------------------------
        public string dbToPdf(DataTable dtNouhinHikae, DataTable dtNouhin, DataTable dtJuryo, List<string> lstItem)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/A0020_UriageInput.xlsx";
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);
                
                IXLWorksheet currentsheet = workbook.Worksheet(1);  // 処理中シート

                int pageCnt = 0;    // ページ(シート枚数)カウント
                int xlsRowCnt = 15;  // Excel出力行カウント（開始は出力行）
                Boolean blnSheetCreate = true;

                // ClosedXMLで1行ずつExcelに出力
                //納品書控えの出力
                foreach (DataRow drNouhinHikae in dtNouhinHikae.Rows)
                {
                    // 最初の明細行の場合
                    if (blnSheetCreate)
                    {
                        blnSheetCreate = false;

                        //得意先コードが８８８８だった場合は納品書の文言変更
                        if (lstItem[4] == "8888")
                        {
                            currentsheet.Cell("A3").Value = "納品書（控）現金売り";       // 見出し
                        }
                        else
                        {
                            currentsheet.Cell("A3").Value = "納　品　書（控）";       // 見出し
                        }

                        currentsheet.Cell("B6").Value = drNouhinHikae[2].ToString();       // 郵便番号
                        currentsheet.Cell("B7").Value = drNouhinHikae[3].ToString();       // 住所１
                        currentsheet.Cell("B8").Value = drNouhinHikae[4].ToString();       // 住所２
                        currentsheet.Cell("B10").Value = drNouhinHikae[1].ToString();      // 得意先名
                        currentsheet.Cell("H6").Value = drNouhinHikae[7].ToString();       // 伝票年月日
                        currentsheet.Cell("R2").Value = drNouhinHikae[8].ToString();       // 伝票番号

                        currentsheet.Cell("N25").Value = drNouhinHikae[17].ToString();       // 税抜合計金額
                        currentsheet.Cell("N26").Value = drNouhinHikae[18].ToString();      // 消費税
                        currentsheet.Cell("N28").Value = drNouhinHikae[19].ToString();       // 税込合計金額
                        currentsheet.Cell("D25").Value = drNouhinHikae[20].ToString();       // 摘要欄
                        currentsheet.Cell("B27").Value = drNouhinHikae[21].ToString();       // 納入方法

                        //通常・代納のチェックの状態によって値を変更する。
                        if (lstItem[3] == "0")
                        {
                            currentsheet.Cell("B29").Value = "";       // 直送先
                        }
                        else
                        {
                            //直送先名称が空欄の場合はSKIP
                            if (lstItem[5] != "")
                            {
                                currentsheet.Cell("B29").Value = lstItem[5] + "様 直送";       // 直送先
                            }
                        }

                        currentsheet.Cell("R27").Value = drNouhinHikae[5].ToString();      // 担当者名
                        currentsheet.Cell("S27").Value = drNouhinHikae[6].ToString();       // 発行者
                        
                    }

                    currentsheet.Cell(xlsRowCnt, "B").Value = drNouhinHikae[11].ToString();    // 商品名M
                    currentsheet.Cell(xlsRowCnt, "I").Value = drNouhinHikae[12].ToString();    // 棚番号
                    currentsheet.Cell(xlsRowCnt, "J").Value = drNouhinHikae[13].ToString();    // 数量
                    currentsheet.Cell(xlsRowCnt, "M").Value = drNouhinHikae[14].ToString();    // 売上単価
                    currentsheet.Cell(xlsRowCnt, "N").Value = drNouhinHikae[15].ToString();    // 売上金額
                    currentsheet.Cell(xlsRowCnt, "P").Value = drNouhinHikae[16].ToString();    // 備考

                    xlsRowCnt += 2;
                }

                
                 xlsRowCnt = 45;  // Excel出力行カウント（開始は出力行）
                blnSheetCreate = true;

                // ClosedXMLで1行ずつExcelに出力
                //納品書の出力
                foreach (DataRow drNouhinHikae in dtNouhinHikae.Rows)
                {
                    // 最初の明細行の場合
                    if (blnSheetCreate)
                    {
                        blnSheetCreate = false;

                        currentsheet.Cell("B36").Value = drNouhinHikae[2].ToString();       // 郵便番号
                        currentsheet.Cell("B37").Value = drNouhinHikae[3].ToString();       // 住所１
                        currentsheet.Cell("B38").Value = drNouhinHikae[4].ToString();       // 住所２
                        currentsheet.Cell("B40").Value = drNouhinHikae[1].ToString();      // 得意先名
                        currentsheet.Cell("H36").Value = drNouhinHikae[7].ToString();       // 伝票年月日
                        currentsheet.Cell("R32").Value = drNouhinHikae[8].ToString();       // 伝票番号

                        currentsheet.Cell("N55").Value = drNouhinHikae[17].ToString();       // 税抜合計金額
                        currentsheet.Cell("N56").Value = drNouhinHikae[18].ToString();      // 消費税
                        currentsheet.Cell("N58").Value = drNouhinHikae[19].ToString();       // 税込合計金額
                        currentsheet.Cell("D55").Value = drNouhinHikae[20].ToString();       // 摘要欄
                        currentsheet.Cell("B57").Value = drNouhinHikae[21].ToString();       // 納入方法

                        //通常・代納のチェックの状態によって値を変更する。
                        if (lstItem[3] == "0")
                        {
                            currentsheet.Cell("B59").Value = "";       // 直送先
                        }
                        else
                        {
                            //代納の場合は以下の値を空欄にする。
                            currentsheet.Cell("B36").Value = "";      // 郵便番号
                            currentsheet.Cell("B37").Value = "";      // 住所１
                            currentsheet.Cell("B38").Value = "";      // 住所２
                            currentsheet.Cell("B40").Value = "";      // 得意先名
                            currentsheet.Cell("N55").Value = "";      // 税抜合計金額
                            currentsheet.Cell("N56").Value = "";      // 消費税
                            currentsheet.Cell("N58").Value = "";      // 税込合計金額
                        }

                        currentsheet.Cell("R57").Value = drNouhinHikae[5].ToString();      // 担当者名
                        currentsheet.Cell("S57").Value = drNouhinHikae[6].ToString();       // 発行者

                    }

                    currentsheet.Cell(xlsRowCnt, "B").Value = drNouhinHikae[10].ToString();    // 商品名
                    currentsheet.Cell(xlsRowCnt, "J").Value = drNouhinHikae[13].ToString();    // 数量
                    //代納の場合は単価・金額はSKIP                                                                           //通常・代納のチェックの状態によって値を変更する。
                    if (lstItem[3] == "0")
                    {
                        currentsheet.Cell(xlsRowCnt, "M").Value = drNouhinHikae[14].ToString();    // 売上単価
                        currentsheet.Cell(xlsRowCnt, "N").Value = drNouhinHikae[15].ToString();    // 売上金額
                    }
                    currentsheet.Cell(xlsRowCnt, "P").Value = drNouhinHikae[16].ToString();    // 備考

                    xlsRowCnt += 2;
                }

                xlsRowCnt = 75;  // Excel出力行カウント（開始は出力行）
                blnSheetCreate = true;

                // ClosedXMLで1行ずつExcelに出力
                //受領書の出力
                foreach (DataRow drNouhinHikae in dtNouhinHikae.Rows)
                {
                    // 最初の明細行の場合
                    if (blnSheetCreate)
                    {
                        blnSheetCreate = false;

                        currentsheet.Cell("B66").Value = drNouhinHikae[2].ToString();       // 郵便番号
                        currentsheet.Cell("B67").Value = drNouhinHikae[3].ToString();       // 住所１
                        currentsheet.Cell("B68").Value = drNouhinHikae[4].ToString();       // 住所２
                        currentsheet.Cell("B70").Value = drNouhinHikae[1].ToString();      // 得意先名
                        currentsheet.Cell("H66").Value = drNouhinHikae[7].ToString();       // 伝票年月日
                        currentsheet.Cell("R62").Value = drNouhinHikae[8].ToString();       // 伝票番号
                        
                        currentsheet.Cell("D85").Value = drNouhinHikae[20].ToString();       // 摘要欄
                        currentsheet.Cell("B87").Value = drNouhinHikae[21].ToString();       // 納入方法

                        //通常・代納のチェックの状態によって値を変更する。
                        if (lstItem[3] == "0")
                        {
                            currentsheet.Cell("B89").Value = "";       // 直送先
                        }
                        else
                        {
                            //代納の場合は以下の値を空欄にする。
                            currentsheet.Cell("B66").Value = "";       // 郵便番号
                            currentsheet.Cell("B67").Value = "";       // 住所１
                            currentsheet.Cell("B68").Value = "";       // 住所２
                            currentsheet.Cell("B70").Value = "";      // 得意先名
                        }

                    }

                    currentsheet.Cell(xlsRowCnt, "B").Value = drNouhinHikae[10].ToString();    // 商品名
                    currentsheet.Cell(xlsRowCnt, "J").Value = drNouhinHikae[13].ToString();    // 数量

                    currentsheet.Cell(xlsRowCnt, "P").Value = drNouhinHikae[16].ToString();    // 備考

                    xlsRowCnt += 2;
                }

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // ロゴ貼り付け処理
                CreatePdf pdf = new CreatePdf();
                int[] topRow = { 6,36,66 };
                int[] leftColumn = { 15,15,15};
                pdf.logoPaste(strOutXlsFile, topRow, leftColumn, 200, 850, 88);

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
