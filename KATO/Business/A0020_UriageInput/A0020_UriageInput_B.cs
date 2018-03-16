using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;
using System.Runtime.InteropServices;

//using System.Runtime.InteropServices;

//using NetOffice.ExcelApi;

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
        public DataTable getShohin(string strShohinCd, DBConnective con)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT *";
            strQuery += "  FROM 商品";
            strQuery += " WHERE 商品コード = '" + strShohinCd + "'";
            strQuery += "   AND 削除     = 'N'";

            try
            {
                dtRet = con.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        /// <summary>
        /// updUriageHeader
        /// 売上ヘッダをプロシージャーで更新する。
        /// </summary>
        public void updUriageHeader(List<string> updUriageHeaderItem, DBConnective con)
        {

            try
            {

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
                con.ReadSql(strProc);


            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }


        public DataTable getShohins (string stNo, DBConnective con)
        {
            DataTable dt = null;

            try
            {
                string strQ = "SELECT 商品コード FROM 売上明細 WHERE 伝票番号 = " + stNo + " AND 削除 = 'N'";

                dt = con.ReadSql(strQ);
            }
            catch
            {
                throw;
            }
            finally
            {
            }
            return dt;
        }

        /// <summary>
        /// delUriageData
        /// 売上データを削除する。
        /// </summary>
        public void delUriageData(List<string> delUriageItem, DBConnective con)
        {

            try
            {

                string strProc = "売上ヘッダ削除_PROC '"
                            + delUriageItem[0] + "', '"
                            + delUriageItem[1] + "'";

                // 売上ヘッダ削除_PROC
                con.ReadSql(strProc);

                 strProc = "受注_売上数_戻し更新_PROC '"
                            + delUriageItem[0] + "', '"
                            + delUriageItem[1] + "'";

                // 受注_売上数_戻し更新_PROC
                con.ReadSql(strProc);

                 strProc = "売上明細削除_PROC '"
                            + delUriageItem[0] + "', '"
                            + delUriageItem[1] + "'";

                // 売上明細削除_PROC
                con.ReadSql(strProc);


            }
            catch
            {
                throw;
            }
            finally
            {
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

                //string strProc = "売上伝票印刷済フラグセット_PROC '"
                //            + UserName + "', '"
                //            + DBNull.Value + "', '"
                //            + DBNull.Value + "', '"
                //            + DBNull.Value + "', '"
                //            + DBNull.Value + "', '"
                //            + Denno+ "', '"
                //            + Denno + "', '"
                //            + UserName + "', '"
                //            + Flag + "'";
                string s1 = (DateTime.Now.AddYears(-20)).ToString("yyyy/MM/dd");
                string s2 = (DateTime.Now.AddYears(20)).ToString("yyyy/MM/dd");
                string strProc = "売上伝票印刷済フラグセット_PROC '"
                            + UserName + "', '"
                            + s1 + "', '"
                            + s2 + "', '"
                            + s1 + "', '"
                            + s2 + "', '"
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
        public void updSyohinMastr(List<string> lstitem ,String SyohinCD, DBConnective con)
        {

            try
            {

                string strProc = "商品マスタ更新_PROC '"
                            + SyohinCD + "', '"
                            + lstitem[12] + "', '"
                            + lstitem[13] + "', '"
                            + lstitem[14] + "', '"
                            + lstitem[15] + "', '"
                            + "" + "', '"
                            + "" + "', '"
                            + "" + "', '"
                            + "" + "', '"
                            + "" + "', '"
                            + "Y" + "', '"
                            + 0 + "', '"
                            + lstitem[5] + "', '"
                            + "0" + "', '"
                            + "000000" + "', '"
                            + "000000" + "', '"
                            + "" + "', '"
                            + lstitem[5] + "', '"
                            + 0 + "', '"
                            + 1 + "', '"
                            + "0" + "', '"
                            + "" + "', '"
                            + lstitem[0] + "'";

                // 商品マスタ更新_PROC
                con.ReadSql(strProc);


            }
            catch
            {
                // ロールバック処理
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// updUriageMeisai
        /// 売上明細更新（プロシージャー）
        /// </summary>
        public void updUriageMeisai(List<string> lstitem, String SyohinCD,string Denno,string gyoNo, DBConnective con)
        {

            try
            {
                // トランザクション開始

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
                con.ReadSql(strProc);

            }
            catch
            {
                // ロールバック処理
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// updUriagesuuModosi
        /// 受注＿売上数＿戻し更新
        /// </summary>
        public void updUriagesuuModosi(List<string> updUriageHeaderItem, DBConnective con)
        {

            try
            {

                string strProc = "受注_売上数_戻し更新_PROC '"
                            + updUriageHeaderItem[0] + "', '"
                            + updUriageHeaderItem[21] + "'";

                // 受注_売上数_戻し更新_PROC
                con.ReadSql(strProc);


            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// delUriageMeisai
        /// 売上明細削除
        /// </summary>
        public void delUriageMeisai(List<string> updUriageHeaderItem, DBConnective con)
        {

            try
            {

                string strProc = "売上明細消去_PROC '"
                            + updUriageHeaderItem[0] + "'";

                // 売上明細消去_PROC
                con.ReadSql(strProc);


            }
            catch
            {
                throw;
            }
            finally
            {
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
        public DataTable GetCyokuCode(List<string> lstString, DBConnective con)
        {
            DataTable dtGetCyokuCd = new DataTable();
            string strSql = "SELECT COUNT(*) AS 直送先コードカウント FROM 直送先 WHERE 得意先コード = "+lstString[0]+"  AND 直送先コード = "+lstString[1];

            try
            {
                // 検索データをテーブルへ格納
                dtGetCyokuCd = con.ReadSql(strSql);

                return dtGetCyokuCd;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// updCyokusousaki
        /// 直送先の更新
        /// </summary>
        public void updCyokusousaki(List<string> CyokuItem, DBConnective con)
        {

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
                con.RunSql(strSql);

            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// insCyokusousaki
        /// 直送先の登録
        /// </summary>
        public void insCyokusousaki(List<string> CyokuItem, DBConnective con)
        {

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
                con.RunSql(strSql);

            }
            catch
            {
                // ロールバック処理
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// GetTantouCode
        /// ログインＩＤから担当者コードを得る
        /// </summary>
        public DataTable GetTantouCode(List<string> lstString )
        {
            DataTable dtGetTantouCd = new DataTable();
            string strSql = "SELECT 担当者コード, 営業所コード FROM 担当者 WHERE ログインＩＤ='" + lstString[0] + "'  AND 削除='N'";

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

        public DataTable GetTantouCode2(List<string> lstString)
        {
            DataTable dtGetTantouCd = new DataTable();
            string strSql = "SELECT 担当者コード, 営業所コード FROM 担当者 WHERE 担当者コード='" + lstString[0] + "'  AND 削除='N'";

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
        public DataTable getSyohinCd(List<string> lstString,string Kataban, DBConnective con)
        {
            DataTable dtGetTantouCd = new DataTable();
            string strSql = "SELECT 商品コード FROM 商品 ";
            strSql += " WHERE 削除='N'";
            strSql += " AND メーカーコード='" + lstString[12] + "' ";
            strSql += " AND 大分類コード='" + lstString[13] + "' ";
            strSql += " AND 中分類コード='" + lstString[14] + "' ";
            strSql += " AND REPLACE(ISNULL(Ｃ１,'')+ISNULL(Ｃ２,'')+ISNULL(Ｃ３,'')+ISNULL(Ｃ４,'')+ISNULL(Ｃ５,'')+ISNULL(Ｃ６,'') ,' ' ,'')= '" + Kataban + "' ";

            try
            {
                // 検索データをテーブルへ格納
                dtGetTantouCd = con.ReadSql(strSql);

                return dtGetTantouCd;
            }
            catch
            {
                throw;
            }
            finally
            {
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
        public void DC_Syukko_Nyuuko(List<string> SyukkoyouItem, List<string> NyuukoyouItem, DBConnective con)
        {

            try
            {
                string strProc = "倉庫間移動更新_PROC '"
                            + SyukkoyouItem[0] + "',"
                            + SyukkoyouItem[1] + ","
                            + SyukkoyouItem[2] + ", '"
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
                            + SyukkoyouItem[16] + "', "
                            + SyukkoyouItem[17] + ", "
                            + SyukkoyouItem[18] + ", '"
                            + SyukkoyouItem[19] + "', '"
                            + SyukkoyouItem[20] + "'"; ;

                // 倉庫間移動更新_PROC(出庫)
                con.ReadSql(strProc);

                 strProc = "倉庫間移動更新_PROC '"
                            + NyuukoyouItem[0] + "',"
                            + NyuukoyouItem[1] + ","
                            + NyuukoyouItem[2] + ", '"
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
                            + NyuukoyouItem[16] + "', "
                            + NyuukoyouItem[17] + ", "
                            + NyuukoyouItem[18] + ", '"
                            + NyuukoyouItem[19] + "', '"
                            + NyuukoyouItem[20] + "'"; ;

                // 倉庫間移動更新_PROC(入庫)
                con.ReadSql(strProc);

            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// DC_updHikiateflg
        /// 倉庫間移動データ作成済セット
        /// </summary>
        public void DC_updHikiateflg(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "UPDATE 受注 ";
            strSql = strSql + " SET 在庫引当フラグ = 1  ";
            strSql = strSql + " WHERE 在庫引当フラグ <> 1 ";
            strSql = strSql + " AND   受注番号=" + lstString[0];


            try
            {
                // 検索データをテーブルへ格納
                 con.RunSql(strSql);

                return ;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// updSyohinCD
        /// 受注テーブルの商品コードを更新する。
        /// </summary>
        public void updJTableSyohinCD(List<string> lstString,string SyohinCD, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + " UPDATE 受注 ";
            strSql = strSql + " SET 商品コード='" + SyohinCD + "'";
            strSql = strSql + " WHERE 受注番号=" + lstString[2];


            try
            {
                // 検索データをテーブルへ格納
                con.RunSql(strSql);


                return;
            }
            catch
            {
                // ロールバック処理
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// updSyohinCD
        /// 発注テーブルの商品コードを更新する。
        /// </summary>
        public void updHTableSyohinCD(List<string> lstString, string SyohinCD,string Kataban, DBConnective con)
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

            try
            {
                // 検索データをテーブルへ格納
                con.RunSql(strSql);

                return;
            }
            catch
            {
                // ロールバック処理
                throw;
            }
            finally
            {
            }
        }


        /// <summary>
        /// updJTableTokuisakiName
        /// 受注テーブルの得意先名称を更新する。
        /// </summary>
        public void updJTableTokuisakiName(List<string> UriageMeisaiItem,List<string> UriageInputItem, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + " UPDATE 受注 ";
            strSql = strSql + " SET 得意先名称='" + UriageInputItem[3] + "'";
            strSql = strSql + " WHERE 受注番号=" + UriageMeisaiItem[2];

            try
            {
                // 検索データをテーブルへ格納
                con.RunSql(strSql);


                return;
            }
            catch
            {
                // ロールバック処理
                throw;
            }
            finally
            {
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
        public DataTable getJucyuSuuryo(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT 受注数量 FROM 受注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];


            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getSumUriageSuuryo
        /// 売上明細から売上数量の合計を取得する。
        /// </summary>
        public DataTable getSumUriageSuuryo(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT SUM(数量) AS 合計売上数量 FROM 売上明細 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];


            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getCurrentRowUriageSuuryo
        /// 売上明細から現在行の数量を取得する
        /// </summary>
        public DataTable getCurrentRowUriageSuuryo(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT 数量 FROM 売上明細 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 伝票番号=" + lstString[0];
            strSql = strSql + " AND 行番号=" + lstString[1];


            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getJucyu
        /// 受注番号から受注データを取得する。
        /// </summary>
        public DataTable getJucyu(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT 得意先コード,商品コード,メーカーコード,大分類コード,中分類コード,Ｃ１,Ｃ２,Ｃ３,Ｃ４,Ｃ５,Ｃ６,";
            strSql = strSql + "受注数量,受注単価,仕入単価,納期,注番,売上フラグ,売上済数量,得意先名称,本社出庫数,岐阜出庫数,営業所コード";
            strSql = strSql + " FROM 受注";
            strSql = strSql + " WHERE 受注番号=" + lstString[0];


            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getHacyusijiKbn
        /// 受注番号から発注指示区分を取得する。
        /// </summary>
        public DataTable getHacyusijiKbn(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT 発注指示区分 FROM 受注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];


            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getSaisyuSiirebi
        /// 受注番号から最終仕入先日
        /// </summary>
        public DataTable getSaisyuSiirebi(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT dbo.f_get受注番号から最終仕入先日(" +lstString[0]+ ") AS 最終仕入先日  ";

            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getTokuisakiCd
        /// 受注番号から得意先コードを取得する。
        /// </summary>
        public DataTable getTokuisakiCd(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT J.得意先コード AS 得意先コード FROM 受注 J,発注 H ";
            strSql = strSql + " WHERE J.削除='N'";
            strSql = strSql + " AND H.削除='N'";
            strSql = strSql + " AND J.受注番号=" + lstString[0];
            strSql = strSql + " AND J.受注番号=H.受注番号";
            strSql = strSql + " AND H.仕入先コード='7777'";


            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getKakouHacyuCount
        /// 加工区分が1の発注データをカウントする。
        /// </summary>
        public DataTable getKakouHacyuCount(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) AS 加工品発注カウント FROM 発注 WHERE 受注番号=" +lstString[0]+ " AND 削除='N' AND 加工区分='1' ";
            
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
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
        public DataTable getzaikosuu(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT dbo.f_get指定日の在庫数('" + lstString[0] + "' ,'" + lstString[1] + "' ,'"+DateTime.Parse(lstString[2]).ToString("yyyy/MM/dd")+"') AS 指定日の在庫数 ";
             
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getHacyuCount
        /// 受注番号から発注データをカウントする。
        /// </summary>
        public DataTable getHacyuCount(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) AS 発注カウント FROM 発注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];


            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getKatbanHacyuCount
        /// 受注番号と型番から発注データをカウントする。
        /// </summary>
        public DataTable getKatbanHacyuCount(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) AS 型番発注カウント  FROM 発注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];
            strSql = strSql + " AND REPLACE(ISNULL(Ｃ１,'')+ISNULL(Ｃ２,'')+ISNULL(Ｃ３,'')+ISNULL(Ｃ４,'')+ISNULL(Ｃ５,'')+ISNULL(Ｃ６,'') ,' ' ,'')= '" + lstString[1] + "' ";


            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getKatbanHacyuCount
        /// 受注番号と仕入先コードの指定から発注データをカウントする。
        /// </summary>
        public DataTable getSiiresakiSiteiHacyuCount(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) AS 仕入先指定発注カウント FROM 発注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];
            strSql = strSql + " AND 仕入先コード<>'9999'";           //2006.6.13  返品口座は除く
            strSql = strSql + " AND 仕入先コード<>'7777'";           //2006.6.15  仕入先手数料口座は除く

            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// SiirezumiSuuryoHacyuCount
        /// 仕入済数量が０の発注データをカウントする。
        /// </summary>
        public DataTable SiirezumiSuuryoHacyuCount(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) AS 仕入済数量発注カウント FROM 発注 ";
            strSql = strSql + " WHERE 削除='N'";
            strSql = strSql + " AND 受注番号=" + lstString[0];
            strSql = strSql + " AND 仕入済数量=0";
            strSql = strSql + " AND 仕入先コード<>'9999'";           //2006.6.13  返品口座は除く
            strSql = strSql + " AND 仕入先コード<>'7777'";           //2006.6.15  仕入先手数料口座は除く

            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getSuryoSiteiJuhacyu
        /// 数量が0未満の受発注データをカウントする。
        /// </summary>
        public DataTable getSuryoSiteiJuhacyu(List<string> lstString, DBConnective con)
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


            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getJucyuSuryositeiJuhacyuCount
        /// 受注数量が0未満の受発注データをカウントする。
        /// </summary>
        public DataTable getJucyuSuryositeiJuhacyuCount(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT COUNT(*) 受注数量0未満受発注カウント FROM 受注 J,発注 H ";
            strSql = strSql + " WHERE J.削除='N'";
            strSql = strSql + " AND H.削除='N'";
            strSql = strSql + " AND J.受注番号=" + lstString[0];
            strSql = strSql + " AND J.受注番号=H.受注番号";
            strSql = strSql + " AND J.受注数量<0 ";


            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// getSuryoSiteiJuhacyu
        /// 返品値引き売上承認フラグを取得する。
        /// </summary>
        public DataTable getHenpinNebikiUriageSyoninFlg(List<string> lstString, DBConnective con)
        {

            DataTable dtGetData = new DataTable();
            string strSql = "";

            strSql = strSql + "SELECT dbo.f_get返品値引売上承認フラグ(" + lstString[0] + ") AS 返品値引売上承認フラグ";
            
            try
            {
                // 検索データをテーブルへ格納
                dtGetData = con.ReadSql(strSql);

                return dtGetData;
            }
            catch
            {
                throw;
            }
            finally
            {
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

            A0020_UriageInput_B uriB = new A0020_UriageInput_B();
            try
            {
                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);
                
                IXLWorksheet currentsheet = workbook.Worksheet(1);  // 処理中シート

                int pageCnt = 0;    // ページ(シート枚数)カウント
                int xlsRowCnt = 15;  // Excel出力行カウント（開始は出力行）
                Boolean blnSheetCreate = true;

                string blPrint = "";
                string rePrint = "";

                // ClosedXMLで1行ずつExcelに出力
                //納品書控えの出力
                foreach (DataRow drNouhinHikae in dtNouhinHikae.Rows)
                {
                    // 最初の明細行の場合
                    if (blnSheetCreate)
                    {
                        blnSheetCreate = false;
                        List<string> stL = new List<string>();
                        stL.Add(drNouhinHikae[8].ToString());

                        DataTable dt =  uriB.GetUriageInput(stL);

                        // 再発行時はタイトルに再発行を付ける
                        blPrint = "";
                        rePrint = "";
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            blPrint = dt.Rows[0]["伝票発行フラグ"].ToString();
                            if (!string.IsNullOrWhiteSpace(blPrint) && blPrint.Equals("1"))
                            {
                                rePrint = " 【再発行】";
                            }
                        }

                        //得意先コードが８８８８だった場合は納品書の文言変更
                        if (lstItem[4] == "8888")
                        {
                            currentsheet.Cell("H3").Value = "納品書（控）現金売り" + rePrint;       // 見出し
                        }
                        else
                        {
                            currentsheet.Cell("H3").Value = "納　品　書（控）" + rePrint;       // 見出し
                        }

                        currentsheet.Cell("B6").Value = drNouhinHikae[2].ToString();       // 郵便番号
                        currentsheet.Cell("B7").Value = drNouhinHikae[3].ToString();       // 住所１
                        currentsheet.Cell("B8").Value = drNouhinHikae[4].ToString();       // 住所２
                        currentsheet.Cell("B10").Value = drNouhinHikae[1].ToString();      // 得意先名
                        currentsheet.Cell("H6").Value = drNouhinHikae[7].ToString();       // 伝票年月日
                        currentsheet.Cell("R3").Value = drNouhinHikae[8].ToString();       // 伝票番号

                        currentsheet.Cell("N25").Value = drNouhinHikae[17].ToString();       // 税抜合計金額
                        currentsheet.Cell("N27").Value = drNouhinHikae[18].ToString();      // 消費税
                        currentsheet.Cell("N29").Value = drNouhinHikae[19].ToString();       // 税込合計金額
                        currentsheet.Cell("D25").Value = drNouhinHikae[20].ToString();       // 摘要欄
                        currentsheet.Cell("B28").Value = drNouhinHikae[21].ToString();       // 納入方法

                        //通常・代納のチェックの状態によって値を変更する。
                        if (lstItem[3] == "0")
                        {
                            currentsheet.Cell("B30").Value = "";       // 直送先
                        }
                        else
                        {
                            //直送先名称が空欄の場合はSKIP
                            if (lstItem[5] != "")
                            {
                                currentsheet.Cell("B30").Value = lstItem[5] + "様 直送";       // 直送先
                            }
                        }

                        currentsheet.Cell("R27").Value = drNouhinHikae[5].ToString();      // 担当者名
                        currentsheet.Cell("T27").Value = drNouhinHikae[6].ToString();       // 発行者
                        
                    }

                    currentsheet.Cell(xlsRowCnt, "B").Value = drNouhinHikae[11].ToString();    // 商品名M
                    currentsheet.Cell(xlsRowCnt, "I").Value = drNouhinHikae[12].ToString();    // 棚番号
                    currentsheet.Cell(xlsRowCnt, "J").Value = drNouhinHikae[13].ToString();    // 数量
                    currentsheet.Cell(xlsRowCnt, "M").Value = drNouhinHikae[14].ToString();    // 売上単価
                    currentsheet.Cell(xlsRowCnt, "N").Value = drNouhinHikae[15].ToString();    // 売上金額
                    currentsheet.Cell(xlsRowCnt, "P").Value = drNouhinHikae[16].ToString();    // 備考

                    xlsRowCnt += 2;
                }

                
                 xlsRowCnt = 46;  // Excel出力行カウント（開始は出力行）
                blnSheetCreate = true;

                // ClosedXMLで1行ずつExcelに出力
                //納品書の出力
                foreach (DataRow drNouhinHikae in dtNouhin.Rows)
                {
                    // 最初の明細行の場合
                    if (blnSheetCreate)
                    {
                        blnSheetCreate = false;

                        currentsheet.Cell("B37").Value = drNouhinHikae[2].ToString();       // 郵便番号
                        currentsheet.Cell("B38").Value = drNouhinHikae[3].ToString();       // 住所１
                        currentsheet.Cell("B39").Value = drNouhinHikae[4].ToString();       // 住所２
                        currentsheet.Cell("B41").Value = drNouhinHikae[1].ToString();      // 得意先名
                        currentsheet.Cell("H37").Value = drNouhinHikae[7].ToString();       // 伝票年月日
                        currentsheet.Cell("R34").Value = drNouhinHikae[8].ToString();       // 伝票番号

                        currentsheet.Cell("N56").Value = drNouhinHikae[17].ToString();       // 税抜合計金額
                        currentsheet.Cell("N58").Value = drNouhinHikae[18].ToString();      // 消費税
                        currentsheet.Cell("N60").Value = drNouhinHikae[19].ToString();       // 税込合計金額
                        currentsheet.Cell("D56").Value = drNouhinHikae[20].ToString();       // 摘要欄
                        currentsheet.Cell("B59").Value = drNouhinHikae[21].ToString();       // 納入方法

                        //通常・代納のチェックの状態によって値を変更する。
                        if (lstItem[3] == "0")
                        {
                            currentsheet.Cell("B61").Value = "";       // 直送先
                        }
                        else
                        {
                            //代納の場合は以下の値を空欄にする。
                            //currentsheet.Cell("B37").Value = "";      // 郵便番号
                            //currentsheet.Cell("B38").Value = "";      // 住所１
                            //currentsheet.Cell("B39").Value = "";      // 住所２
                            //currentsheet.Cell("B41").Value = "";      // 得意先名
                            currentsheet.Cell("N56").Value = "";      // 税抜合計金額
                            currentsheet.Cell("N58").Value = "";      // 消費税
                            currentsheet.Cell("N60").Value = "";      // 税込合計金額
                        }

                        currentsheet.Cell("R58").Value = drNouhinHikae[5].ToString();      // 担当者名
                        currentsheet.Cell("T58").Value = drNouhinHikae[6].ToString();       // 発行者

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

                xlsRowCnt = 77;  // Excel出力行カウント（開始は出力行）
                blnSheetCreate = true;

                // ClosedXMLで1行ずつExcelに出力
                //受領書の出力
                foreach (DataRow drNouhinHikae in dtJuryo.Rows)
                {
                    // 最初の明細行の場合
                    if (blnSheetCreate)
                    {
                        blnSheetCreate = false;

                        currentsheet.Cell("B68").Value = drNouhinHikae[2].ToString();       // 郵便番号
                        currentsheet.Cell("B69").Value = drNouhinHikae[3].ToString();       // 住所１
                        currentsheet.Cell("B70").Value = drNouhinHikae[4].ToString();       // 住所２
                        currentsheet.Cell("B72").Value = drNouhinHikae[1].ToString();      // 得意先名
                        currentsheet.Cell("H68").Value = drNouhinHikae[7].ToString();       // 伝票年月日
                        currentsheet.Cell("R65").Value = drNouhinHikae[8].ToString();       // 伝票番号
                        
                        currentsheet.Cell("D87").Value = drNouhinHikae[20].ToString();       // 摘要欄
                        currentsheet.Cell("B91").Value = drNouhinHikae[21].ToString();       // 納入方法

                        //通常・代納のチェックの状態によって値を変更する。
                        if (lstItem[3] == "0")
                        {
                            currentsheet.Cell("B93").Value = "";       // 直送先
                        }
                        else
                        {
                            //代納の場合は以下の値を空欄にする。
                            //currentsheet.Cell("B68").Value = "";       // 郵便番号
                            //currentsheet.Cell("B69").Value = "";       // 住所１
                            //currentsheet.Cell("B70").Value = "";       // 住所２
                            //currentsheet.Cell("B72").Value = "";      // 得意先名
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
                int[] topRow = { 5,36,67 };
                int[] leftColumn = { 15,15,15};
                pdf.logoPaste(strOutXlsFile, topRow, leftColumn, 200, 850, 60);

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

        ///------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化
        /// </summary>
        ///// <param name="dtNouhinHikae">納品書（控）のデータテーブル</param>
        ///// <param name="dtNouhin">納品書のデータテーブル</param>
        ///// <param name="dtJuryo">受領書のデータテーブル</param>
        ///// <param name="lstItem">検索に使用するデータリスト</param>
        /// <returns>ファイルパス</returns>
        /// -----------------------------------------------
        public void dbToExcel()
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/A0020_UriageInput.xlsx";
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");


            //Ex

            try
            {
                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);

                IXLWorksheet currentsheet = workbook.Worksheet(1);  // 処理中シート

                //int pageCnt = 0;    // ページ(シート枚数)カウント
                //int xlsRowCnt = 15;  // Excel出力行カウント（開始は出力行）
                //Boolean blnSheetCreate = true;


                

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












        public void printGenpinhyo(string stDenno, bool blNotPrintedOnly)
        {
            try
            {
                DataTable dt = getGenpinhyoInfo(stDenno, blNotPrintedOnly);

                String strDenpyoNo = "";                 // 伝票番号
                String strGyoNo = "";                    // 行番号
                String strJuchusaki = "";                // 受注先
                String strNohinsaki = "";                // 納品先
                String strNohinbi = "";                  // 納品日
                String strKataban = "";                  // 型番
                String strTanaban = "";                  // 棚番
                String strSu = "";                       // 数量
                String strBiko = "";                     // 備考
                String strNonyu = "";                    // 納入方法
                String strTekiyo = "";                   // 摘要欄
                String strShoCd = "";                    // 商品コード
                String strShukko = "";                   // 出庫倉庫

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];

                        strJuchusaki = dt.Rows[i]["得意先名"].ToString();
                        strNohinsaki = dt.Rows[i]["直送先名"].ToString();
                        if (string.IsNullOrWhiteSpace(strNohinsaki))
                        {
                            strNohinsaki = strJuchusaki;
                        }
                        strNohinsaki += " 殿";
                        strNohinbi = dt.Rows[i]["伝票年月日"].ToString();
                        strKataban = dt.Rows[i]["型番"].ToString();
                        strTanaban = dt.Rows[i]["棚番"].ToString();
                        strSu = dt.Rows[i]["数量"].ToString();
                        strBiko = dt.Rows[i]["備考"].ToString();
                        strNonyu = dt.Rows[i]["納入方法"].ToString();
                        if (string.IsNullOrWhiteSpace(strNonyu))
                        {
                            strNonyu = "";
                        }
                        else
                        {
                            strNonyu = strNonyu.TrimEnd();
                        }
                        strTekiyo = dt.Rows[i]["摘要欄"].ToString();
                        strShoCd = dt.Rows[i]["商品コード"].ToString();
                        strShukko = dt.Rows[i]["出庫倉庫"].ToString();
                        strDenpyoNo = dt.Rows[i]["伝票番号"].ToString();
                        strGyoNo = dt.Rows[i]["行番号"].ToString();

                        string stGPrt = getGPDriver(strShoCd, strShukko);

                        printout(stGPrt, strDenpyoNo, strGyoNo, strJuchusaki, strNohinsaki, strNohinbi, strKataban, strTanaban, strSu, strBiko, strNonyu, strTekiyo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable getGenpinhyoInfo(string stDenno, bool blNotPrintedOnly)
        {
            DataTable dt = null;

            string strSQL = "";
            strSQL += "SELECT 売上ヘッダ.伝票番号";
            strSQL += "      ,売上明細.行番号";
            strSQL += "      ,RTRIM(売上ヘッダ.得意先名) AS 得意先名";
            strSQL += "      ,RTRIM(売上ヘッダ.直送先名) AS 直送先名";
            strSQL += "      ,売上ヘッダ.摘要欄";
            strSQL += "      ,売上ヘッダ.納入方法";
            strSQL += "      ,CONVERT(VARCHAR, 売上ヘッダ.伝票年月日, 111) as 伝票年月日";
            //strSQL += "      ,dbo.f_get中分類名(売上明細.大分類コード,売上明細.中分類コード) + ' ' +  RTRIM(ISNULL(売上明細.Ｃ１,'')) AS 型番";
            strSQL += "      ,dbo.f_get中分類名(売上明細.大分類コード,売上明細.中分類コード) + NCHAR(13) + NCHAR(10) +  RTRIM(ISNULL(売上明細.Ｃ１,'')) AS 型番";
            strSQL += "      ,dbo.f_get商品コードから棚番(売上明細.商品コード, dbo.f_get受注時の出庫場所(売上明細.受注番号)) AS 棚番";
            strSQL += "      ,売上明細.数量";
            strSQL += "      ,売上明細.備考";
            strSQL += "      ,売上明細.商品コード";
            strSQL += "      ,売上明細.出庫倉庫";
            strSQL += "  FROM 売上ヘッダ, 売上明細";
            strSQL += " WHERE 売上ヘッダ.削除 = 'N'";
            strSQL += "   AND 売上明細.削除 = 'N'";
            strSQL += "   AND 売上ヘッダ.伝票番号 = 売上明細.伝票番号";

            if (!string.IsNullOrWhiteSpace(stDenno))
            {
                strSQL += "   AND 売上ヘッダ.伝票番号 = " + stDenno;
            }

            if (blNotPrintedOnly)
            {
                strSQL += "   AND 売上ヘッダ.伝票発行フラグ = '0'";
            }

            DBConnective dtCon = new DBConnective();
            try
            {
                dt = dtCon.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public void printout(string stGPrt, String strDenpyoNo, String strGyoNo, String strJuchusaki, String strNohinsaki,
            String strNohinbi, String strKataban, String strTanaban, String strSu, String strBiko, String strNonyu, String strTekiyo)
        {

            //String _xslFile = @"C:\Users\admin\Desktop\KATO\やること_画面別\現品票\現品票(Temp).xls";  // XLSファイル名
            int _sheetNo = 1;                        // シートNo.
            int _col = 2;                            // データ書き込みカラム
            int _line = 2;                           // データ書き込み開始行
            String _printer = stGPrt;    // 出力プリンター

            //String strJuchusaki = "";                // 受注先
            //String strNohinsaki = "";                // 納品先
            //String strNohinbi = "";                  // 納品日
            //String strKataban = "";                  // 型番
            //String strTanaban = "";                  // 棚番
            //String strSu = "";                       // 数量
            //String strBiko = "";                     // 備考


            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/A0020_Genpinhyo.xls";


            // Excel.Applicationを有効にするため参照の追加を行なってください
            // [参照の追加],[COM],[Microsoft Excel *.* Object Library]
            // 参照設定に[Excel](ファイル名:Interop.Excel.dll)が追加されます
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbooks objWorkBooks = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkBook = null;
            Microsoft.Office.Interop.Excel.Worksheet objWorkSheet = null;
            Microsoft.Office.Interop.Excel.Range objRange = null;
            object objCell = null;

            try
            {
                // EXCEL開始処理
                try
                {
                    objExcel = new Microsoft.Office.Interop.Excel.Application();
                }
                catch
                {
                    throw new Exception(
                        "Microsoft Office Excelがインストールされていないため\n" +
                        "印刷できません。");
                }

                objExcel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized;
                objExcel.Visible = false;
                objExcel.DisplayAlerts = false;

                objWorkBooks = objExcel.Workbooks;

                strFilePath = System.IO.Path.GetFullPath(strFilePath);

                objWorkBook = objWorkBooks.Open(strFilePath, //_xslFile,     // FileName:ファイル名
                                                Type.Missing, // UpdateLinks:ファイル内の外部参照の更新方法
                                                Type.Missing, // ReadOnly:ReadOnlyにするかどうか
                                                Type.Missing, // Format: テキストファイルを開く場合に区切り文字を指定する
                                                Type.Missing, // Password:開く際にパスワードがある場合にパスワードを入力
                                                Type.Missing, // WriteResPassword:書き込む際にパスワードがある場合にパスワードを入力
                                                Type.Missing, // IgnoreReadOnlyRecommended:[読み取り専用を推奨する]チェックがオンの場合でも[読み取り専用を推奨する]メッセージを非表示
                                                Type.Missing, // Origin:テキストファイルの場合、プラットフォームを指定
                                                Type.Missing, // Delimiter:テキストファイルで且つ引数Formatが6の場合に区切り文字を指定
                                                Type.Missing, // Editable:Excel4.0アドインの場合、アドインウィンドウを出すか指定
                                                Type.Missing, // Notify:ファイルが読み取りor書き込みモードで開けない場合に通知リストに追加するか指定
                                                Type.Missing, // Converter:ファイルを開くときに最初に使用するファイルコンバーターのインデックス番号を指定
                                                Type.Missing, // AddToMru:最近使用したファイルの一覧にブックを追加するか指定
                                                Type.Missing, // Local:Excel言語設定に合わせてファイルを保存するか指定
                                                Type.Missing  // CorruptLoad:使用できる定数は[xlNormalLoad][xlRepairFile][xlExtractData]。指定がない場合のは[xlNormalLoad]になりOMを通じて開始するときに回復は行われません。
                                                );

                objWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkBook.Sheets[_sheetNo];

                // EXCEL出力処理
                //objCell = objWorkSheet.Cells[_line + 0, _col];          // 受注先
                //objRange = objWorkSheet.get_Range(objCell, objCell);
                //objRange.Value2 = strJuchusaki;
                //Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                //Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line - 1, _col - 1];          // 伝票番号＋行番号
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = strDenpyoNo + "-" + strGyoNo;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line + 1, _col];          // 納品先
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = strNohinsaki;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line + 2, _col];          // 納品日
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = strNohinbi;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line + 2, _col + 1];          // 摘要
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = strTekiyo;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line + 3, _col];          // 型番
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = strKataban;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line + 4, _col];          // 棚番
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = strTanaban;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line - 1, _col + 2];          // 納入方法
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = "[" + strNonyu + "] " + DateTime.Now.ToString("yyyy.MM.dd");
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line + 5, _col];          // 数量
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = strSu;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line + 7, _col];          // 備考
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = strBiko;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                // 印刷実行
                objWorkSheet.PrintOut(Type.Missing, // From:印刷開始のページ番号
                                      Type.Missing, // To:印刷終了のページ番号
                                      1,            // Copies:印刷部数
                                      Type.Missing, // Preview:印刷プレビューをするか指定
                                      _printer, // ActivePrinter:プリンターの名称
                                      Type.Missing, // PrintToFile:ファイル出力をするか指定
                                      true,         // Collate:部単位で印刷するか指定
                                      Type.Missing  // PrToFileName	:出力先ファイルの名前を指定するかどうか
                                      );

                objWorkBook.Saved = true;   // 保存済みとする
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // EXCEL終了処理
                if (objWorkSheet != null)
                {
                    Marshal.ReleaseComObject(objWorkSheet);     // オブジェクト参照を解放
                    objWorkSheet = null;                        // オブジェクト解放
                }

                if (objWorkBook != null)
                {
                    objWorkBook.Close(false,
                        Type.Missing, Type.Missing);            //ファイルを閉じる
                    Marshal.ReleaseComObject(objWorkBook);      // オブジェクト参照を解放
                    objWorkBook = null;                         // オブジェクト解放
                }

                if (objWorkBooks != null)
                {
                    Marshal.ReleaseComObject(objWorkBooks);     // オブジェクト参照を解放
                    objWorkBooks = null;                        // オブジェクト解放
                }
                if (objExcel != null)
                {
                    objExcel.Quit();                            // EXCELを閉じる

                    Marshal.ReleaseComObject(objExcel);         // オブジェクト参照を解放
                    objExcel = null;                            // オブジェクト解放
                }

                System.GC.Collect();                            // オブジェクトを確実に削除
            }
        }

        ///<summary>
        ///updUriagesakujo
        ///売上削除承認入力の登録
        ///引数　：List[0](受注番号),[1](環境ユーザ)
        ///戻り値：なし
        ///</summary>
        public void updUriageSakujoShonin(List<string> UriageInputItem, DBConnective con)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQLSelect = new List<string>();
            List<string> lstSQLUpdate = new List<string>();
            List<string> lstSQLInsert = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQLSelect.Add("A1520_Uriageshonin");
            lstSQLSelect.Add("Uriageshonin_Uriagesakujo_SELECT");

            lstSQLUpdate.Add("A1520_Uriageshonin");
            lstSQLUpdate.Add("Uriageshonin_Uriagesakujo_UPDATE");

            lstSQLInsert.Add("A1520_Uriageshonin");
            lstSQLInsert.Add("Uriageshonin_Uriagesakujo_INSERT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            try
            {

                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQLSelect);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    throw new Exception();
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, UriageInputItem[0]);

                //SQL接続後、該当データを取得
                dtSetCd_B = con.ReadSql(strSQLInput);

                //データがなければ
                if (dtSetCd_B.Rows.Count == 0)
                {
                    //INSERT
                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQLInsert);

                    //パスがなければ返す
                    if (strSQLInput == "")
                    {
                        throw new Exception();
                    }

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput, UriageInputItem[0],        //受注番号
                                                             "N",                       //承認フラグ
                                                             DateTime.Now.ToString(),   //登録日時
                                                             UriageInputItem[1],        //登録ユーザー名
                                                             DateTime.Now.ToString(),   //更新日時
                                                             UriageInputItem[1]);       //更新ユーザー名

                    //SQL接続後、該当データを更新
                    con.RunSql(strSQLInput);
                }
                else
                {
                    //UPDATE
                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQLUpdate);

                    //パスがなければ返す
                    if (strSQLInput == "")
                    {
                        throw new Exception();
                    }

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput, UriageInputItem[0],        //受注番号
                                                             "N",                       //承認フラグ
                                                             DateTime.Now.ToString(),   //更新日時
                                                             UriageInputItem[1]);       //更新ユーザー名

                    //SQL接続後、該当データを更新
                    con.RunSql(strSQLInput);

                }

                return;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
            }
        }

        public int getRiekiAccept (string stNo)
        {
            int ret = 0;

            if (string.IsNullOrWhiteSpace(stNo))
            {
                return ret;
            }

            DBConnective dtCon = new DBConnective();
            DataTable dt = null;
            try
            {
                string strSQL = "SELECT * FROM 利益率承認 WHERE 受注番号 = " + stNo + " AND 承認フラグ = 1";
                dt = dtCon.ReadSql(strSQL);

                if (dt != null && dt.Rows.Count > 0)
                {
                    ret = 1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ret;
        }

        private string getGPDriver(string stShoCd, string stShukko)
        {
            // 出力先は2F限定（暫定
            //string ret = System.Configuration.ConfigurationManager.AppSettings["PRINTER_GENPIN_DRIVER1"];
            string ret = System.Configuration.ConfigurationManager.AppSettings["PRINTER_GENPIN_DRIVER2"];
            string colTana = "棚番本社";
            string strSQL = "";
            DataTable dt = null;

            if ("0002".Equals(stShukko))
            {
                colTana = "棚番岐阜";
            }

            strSQL += "SELECT " + colTana;
            strSQL += "  FROM 商品";
            strSQL += " WHERE 商品コード = '" + stShoCd + "'";
            strSQL += "   AND 削除 = 'N'";


            //棚番の階層で出力先のプリンタを振り分ける
            DBConnective dtCon = new DBConnective();
            try
            {
                dt = dtCon.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                string stFloor = "";
                if (dt.Rows[0][colTana] != null)
                {
                    stFloor = dt.Rows[0][colTana].ToString();
                }

                if (string.IsNullOrWhiteSpace(stFloor) && stFloor.Length > 1)
                {
                    stFloor = stFloor.Substring(0, 2);
                }
                // 棚番が本社2階のものである場合、出力先を2階のラベルプリンタにする
                if (stFloor.Equals("2A") || stFloor.Equals("A2"))
                {
                    ret = System.Configuration.ConfigurationManager.AppSettings["PRINTER_GENPIN_DRIVER2"];
                }
            }

            return ret;
        }
    }
}
