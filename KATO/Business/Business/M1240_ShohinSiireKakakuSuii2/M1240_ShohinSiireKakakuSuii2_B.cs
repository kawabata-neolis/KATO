using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using ClosedXML.Excel;

namespace KATO.Business.M1240_ShohinSiireKakakuSuii2
{
    /// <summary>
    /// M1240_ShohinSiireKakakuSuii2_B
    /// 商品仕入単価推移２ ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/8/4
    /// 更新者：多田
    /// 更新日：2017/8/4
    /// カラム論理名
    /// </summary>
    class M1240_ShohinSiireKakakuSuii2_B
    {
        /// <summary>
        ///     getMaxZaikoDate
        ///     在庫年月日の最大値を取得
        /// </summary>
        public DataTable getMaxZaikoDate()
        {
            DataTable dtKijunYmd = new DataTable();

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_SELECT_kijun");

            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);

                // SELECT結果をDataTableへ
                dtKijunYmd = dbconnective.ReadSql(strSqltxt);

                return dtKijunYmd;
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
        ///     updCyokkinTanka_Proc
        ///     商品仕入価格推移2_直近仕入単価更新を実行
        /// </summary>
        ///  <param name = "lstUpdateItem">
        ///     検索条件格納しているLIST
        ///     lstItem[0] 基準在庫日, 
        ///     lstItem[1] 期間From, 
        ///     lstItem[2] 期間To, 
        ///     lstItem[3] ユーザー名
        /// </param>
        public void updCyokkinTanka_Proc(List<string> lstUpdateItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "商品仕入価格推移2_直近仕入単価更新 '" + lstUpdateItem[0] + "', '" + lstUpdateItem[1] +
                    "', '" + lstUpdateItem[2] + "', '" + lstUpdateItem[3] + "'";

                // 商品仕入価格推移2_直近仕入単価更新を実行
                dbconnective.RunSql(strProc);

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
            return;
        }

        /// <summary>
        ///     getShohin
        ///     履歴から商品単価を取得
        /// </summary>
        /// <param name = "lstItem">
        ///     検索条件格納しているLIST
        ///     lstItem[0] 基準在庫日, 
        ///     lstItem[1] 大分類コード, 
        ///     lstItem[2] 中分類コード, 
        ///     lstItem[3] メーカーコード, 
        ///     lstItem[4] 全項目チェックボックス, 
        ///     lstItem[5] 期間内売上あり・なしラジオボタン, 
        ///     lstItem[6] 期間内仕入あり・なしラジオボタン, 
        ///     lstItem[7] 在庫あり・なしラジオボタン
        /// </param>
        public DataTable getShohin(List<string> lstItem)
        {
            // AND条件用
            string andSql = "";
            DataTable dtRireki = new DataTable();
            // 基準在庫日取得
            string kijunYmd = lstItem[0];

            // 全項目にチェックが入っていない場合
            if (bool.Parse(lstItem[4]) == false)
            {
                // 期間内売上ありの場合
                if (lstItem[5].Equals("0"))
                {
                    andSql += " AND a.最終売上日 IS NOT NULL";
                }
                // 期間内売上なしの場合
                else if (lstItem[5].Equals("1"))
                {
                    andSql += " AND a.最終売上日 IS NULL";
                }

                // 期間内仕入ありの場合
                if (lstItem[6].Equals("0"))
                {
                    andSql += " AND a.最終仕入日 IS NOT NULL";
                }
                // 期間内仕入なしの場合
                else if (lstItem[6].Equals("1"))
                {
                    andSql += " AND a.最終仕入日 IS NULL";
                }
            }

            // 大分類コードが空でない場合
            if (!lstItem[1].Equals(""))
            {
                //strSql += " AND dbo.f_get大分類コード(商品コード)='" + lstItem[1] + "'";
                andSql += " AND b.大分類コード='" + lstItem[1] + "'";
            }

            // 中分類コードが空でない場合
            if (!lstItem[2].Equals(""))
            {
                //strSql += " AND dbo.f_get中分類コード(商品コード)='" + lstItem[2] + "'";
                andSql += " AND b.中分類コード='" + lstItem[2] + "'";
            }

            // メーカーコードが空でない場合
            if (!lstItem[3].Equals(""))
            {
                //strSql += " AND dbo.f_getメーカーコード(商品コード)='" + lstItem[3] + "'";
                andSql += " AND b.メーカーコード='" + lstItem[3] + "'";
            }

            // 在庫ありの場合
            if (lstItem[7].Equals("1"))
            {
                andSql += " AND a.在庫数量>0";
            }
            // 在庫なしの場合
            else if (lstItem[7].Equals("2"))
            {
                andSql += " AND a.在庫数量=0";
            }

            DBConnective dbconnective = new DBConnective();

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_SELECT");
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, kijunYmd, andSql);

                // SELECT結果をDataTableへ
                dtRireki = dbconnective.ReadSql(sql);

                return dtRireki;
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
        ///     getZaikoKingaku
        ///     在庫金額を取得
        /// </summary>
        /// <param name = "strKijunYmd">
        ///     基準在庫日
        /// </param>
        public DataTable getZaikoKingaku(string strKijunYmd)
        {
            DataTable dtKingaku = new DataTable();

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_SELECT_kingaku");

            //strSql = "SELECT ";
            //strSql += " SUM(在庫数量*評価単価) AS 評価金額, ";
            //strSql += " SUM(在庫数量*仮単価) AS 仮金額 ";
            //strSql += " FROM 商品仕入単価履歴TMP2 ";
            //strSql += " WHERE 在庫年月日='" + strKijunYmd + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, strKijunYmd);

                // SELECT結果をDataTableへ
                dtKingaku = dbconnective.ReadSql(sql);

                return dtKingaku;
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
        ///     getZaikoKingakuSettei
        ///     在庫金額を取得
        /// </summary>
        /// <param name = "strKijunYmd">
        ///     基準在庫日
        /// </param>
        public DataTable getZaikoKingakuSettei(string strKijunYmd)
        {
            DataTable dtSettei = new DataTable();

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_SELECT_setteitanka");

            //strSql = "SELECT ";
            //strSql += " SUM(在庫数量*仮単価) AS 仮金額 ";
            //strSql += " FROM 商品仕入単価履歴TMP2 ";
            //strSql += " WHERE 在庫年月日='" + strKijunYmd + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, strKijunYmd);

                // SELECT結果をDataTableへ
                dtSettei = dbconnective.ReadSql(sql);

                return dtSettei;
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
        ///     getCyokkinKingaku
        ///     直近金額を取得
        /// </summary>
        /// <param name = "lstItem">
        ///     検索条件格納しているLIST
        ///     lstItem[0] 基準在庫日, 
        ///     lstItem[1] 大分類コード, 
        ///     lstItem[2] 中分類コード, 
        ///     lstItem[3] メーカーコード
        /// </param>
        public DataTable getCyokkinKingaku(List<string> lstItem)
        {
            string andSql = "";
            DataTable dtChokkin = new DataTable();
            // 基準在庫日取得
            string kijunYmd = lstItem[0];

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_SELECT_chokkin");

            //strSql = "SELECT ";
            //strSql += " SUM(在庫数量*直近仕入単価) AS 直近仕入金額 ";
            //strSql += " FROM 商品仕入単価履歴TMP2 ";
            //strSql += " WHERE 在庫年月日='" + lstItem[0] + "'";

            // 大分類コードが空でない場合
            if (!lstItem[1].Equals(""))
            {
                andSql += " AND b.大分類コード='" + lstItem[1] + "'";
            }

            // 中分類コードが空でない場合
            if (!lstItem[2].Equals(""))
            {
                andSql += " AND b.中分類コード='" + lstItem[2] + "'";
            }

            // メーカーコードが空でない場合
            if (!lstItem[3].Equals(""))
            {
                andSql += " AND b.メーカーコード='" + lstItem[3] + "'";
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, kijunYmd, andSql);

                // SELECT結果をDataTableへ
                dtChokkin = dbconnective.ReadSql(sql);

                return dtChokkin;
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
        ///     getKariKingaku
        ///     仮金額を取得
        /// </summary>
        /// <param name = "lstItem">
        ///     検索条件格納しているLIST
        ///     lstItem[0] 基準在庫日, 
        ///     lstItem[1] 大分類コード, 
        ///     lstItem[2] 中分類コード, 
        ///     lstItem[3] メーカーコード
        /// </param>
        public DataTable getKariKingaku(List<string> lstItem)
        {
            string andSql = "";
            DataTable dtKari = new DataTable();
            // 基準在庫日取得
            string kijunYmd = lstItem[0];

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_SELECT_kari");

            //strSql = "SELECT ";
            //strSql += " SUM(在庫数量*仮単価) AS 仮金額 ";
            //strSql += " FROM 商品仕入単価履歴TMP2 ";
            //strSql += " WHERE 在庫年月日='" + lstItem[0] + "'";
            //strSql += " AND 商品コード NOT IN(";
            //strSql += " SELECT 商品コード FROM 商品仕入単価履歴TMP2 ";
            //strSql += " WHERE 在庫年月日='" + lstItem[0] + "'";

            // 大分類コードが空でない場合
            if (!lstItem[1].Equals(""))
            {
                //strSql += " AND dbo.f_get大分類コード(商品コード)='" + lstItem[1] + "'";
                andSql += " AND b.大分類コード='" + lstItem[1] + "'";
            }

            // 中分類コードが空でない場合
            if (!lstItem[2].Equals(""))
            {
                //strSql += " AND dbo.f_get中分類コード(商品コード)='" + lstItem[2] + "'";
                andSql += " AND b.中分類コード='" + lstItem[2] + "'";
            }

            // メーカーコードが空でない場合
            if (!lstItem[3].Equals(""))
            {
                //strSql += " AND dbo.f_getメーカーコード(商品コード)='" + lstItem[3] + "'";
                andSql += " AND b.メーカーコード='" + lstItem[3] + "'";
            }

            //strSql += ")";

            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, kijunYmd, andSql);

                // SELECT結果をDataTableへ
                dtKari = dbconnective.ReadSql(sql);

                return dtKari;
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
        ///     updSetteiTanka
        ///     設定単価を更新
        /// </summary>
        /// <param name = "lstItem">
        ///     検索条件格納しているLIST
        ///     lstItem[0] 基準在庫日, 
        ///     lstItem[1] 設定単価, 
        ///     lstItem[2] 仮掛率, 
        ///     lstItem[3] 商品コード
        /// </param>
        public void updSetteiTanka(List<string> lstItem)
        {
            string setSql = "";
            string kijunYmd = lstItem[0];   // 基準在庫日
            string settei = lstItem[1];     // 設定単価
            string karikake = lstItem[2];   // 仮掛率
            string shohinCd = lstItem[3];   // 商品コード

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_UPDATE_setteitanka");

            //strSql = " UPDATE 商品仕入単価履歴TMP2";
            //strSql += " SET 仮単価 = " + decimal.Parse(lstItem[1]).ToString();

            // 仮掛率が空でない場合
            if (!karikake.Equals(""))
            {
                setSql += " ,仮掛率 = " + karikake;
            }

            //strSql += " WHERE 在庫年月日='" + lstItem[0] + "'";
            //strSql += " AND 商品コード='" + lstItem[3] + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, kijunYmd, settei, setSql, shohinCd);

                // 更新
                dbconnective.RunSql(sql);

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

        /// <summary>
        ///     updCyokkinTanka
        ///     直近単価を更新
        /// </summary>
        /// <param name = "lstItem">
        ///     検索条件格納しているLIST
        ///     lstItem[0] 基準在庫日, 
        ///     lstItem[1] 大分類コード, 
        ///     lstItem[2] 中分類コード, 
        ///     lstItem[3] メーカーコード
        /// </param>
        public void updCyokkinTanka(List<string> lstItem)
        {
            string andSql = "";
            // 基準在庫日取得
            string kijunYmd = lstItem[0];

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_UPDATE_chokkin");

            //strSql = " UPDATE 商品仕入単価履歴TMP2";
            //strSql += " SET 仮単価 = 直近仕入単価";
            //strSql += " WHERE 在庫年月日='" + lstItem[0] + "'";

            // 大分類コードが空でない場合
            if (!lstItem[1].Equals(""))
            {
                andSql += " AND 商品.大分類コード = '" + lstItem[1] + "'";
            }

            // 中分類コードが空でない場合
            if (!lstItem[2].Equals(""))
            {
                andSql += " AND 商品.中分類コード = '" + lstItem[2] + "'";
            }

            // メーカーコードが空でない場合
            if (!lstItem[3].Equals(""))
            {
                andSql += " AND 商品.メーカーコード = '" + lstItem[3] + "'";
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, kijunYmd, andSql);

                // 更新
                dbconnective.RunSql(sql);

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

        /// <summary>
        ///     getSiire
        ///     仕入日、仕入単価を取得
        /// </summary>
        /// <param name = "strShohinCd">
        ///     商品コード
        /// </param>
        public DataTable getSiire(string strShohinCd)
        {
            DataTable dtSiire = new DataTable();

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_SELECT_siire");

            //strSql = "SELECT ";
            //strSql += " 商品コード,仕入日,仕入単価 ";
            //strSql += " FROM 商品仕入履歴ＴＭＰ ";
            //strSql += " WHERE 商品コード='" + strShohinCd + "'";
            //strSql += " ORDER BY 仕入日 DESC";

            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, strShohinCd);

                // SELECT結果をDataTableへ
                dtSiire = dbconnective.ReadSql(sql);

                return dtSiire;
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
        ///     getUriage
        ///     売上日、売上単価を取得
        /// </summary>
        /// <param name = "strShohinCd">
        ///     商品コード
        /// </param>
        public DataTable getUriage(string strShohinCd)
        {
            DataTable dtUriage = new DataTable();

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_SELECT_uriage");

            //strSql = "SELECT ";
            //strSql += " 商品コード,売上日,売上単価 ";
            //strSql += " FROM 商品売上履歴ＴＭＰ ";
            //strSql += " WHERE 商品コード='" + strShohinCd + "'";
            //strSql += " ORDER BY 売上日 DESC";

            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, strShohinCd);

                // SELECT結果をDataTableへ
                dtUriage = dbconnective.ReadSql(sql);

                return dtUriage;
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
        ///     getCount
        ///     件数を取得
        /// </summary>
        /// <param name = "strKijunYmd">
        ///     基準在庫日
        /// </param>
        public int getRecordCount(string strKijunYmd)
        {
            int cnt = 0;
            DataTable dtCnt = new DataTable();

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
            listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_COUNT");

            //strSql = "SELECT COUNT(商品コード)";
            //strSql += " FROM 商品仕入単価履歴TMP2 ";
            //strSql += " WHERE 在庫年月日='" + strKijunYmd + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, strKijunYmd);

                // SELECT結果をDataTableへ
                dtCnt = dbconnective.ReadSql(sql);
                // カウント数取得
                cnt = int.Parse(dtCnt.Rows[0][0].ToString());
                return cnt;
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
        ///     updCyokkinTanka_Proc
        ///     在庫一覧データ作成_PROCを実行
        /// </summary>
        /// <param name = "strKijunYmd">
        ///     基準在庫日
        /// </param>
        public void addZaikoData_Proc(string strKijunYmd)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 在庫一覧データ作成_PROCを実行
                dbconnective.RunSql("在庫一覧データ作成_PROC '" + strKijunYmd + "'");

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
            return;
        }

        /// <summary>
        ///     suii2_Proc
        ///     商品仕入価格推移2_PROCを実行
        /// </summary>
        /// <param name = "lstItem">
        ///     検索条件格納しているLIST
        ///     lstItem[0] 基準在庫日, 
        ///     lstItem[1] 期間From, 
        ///     lstItem[2] 期間To, 
        ///     lstItem[3] ユーザー名
        /// </param>
        public void suii2_Proc(List<string> lstItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "商品仕入価格推移2_PROC '" + lstItem[0] + "', '" + lstItem[1] +
                    "', '" + lstItem[2] + "', '" + lstItem[3] + "'";

                // 商品仕入価格推移2_PROCを実行
                dbconnective.RunSql(strProc);

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
            return;
        }

        /// <summary>
        ///     updHyokaTanaka
        ///     評価単価を更新
        /// </summary>
        /// <param name = "strKijunYmd">
        ///     基準在庫日
        /// </param>
        public void updHyokaTanaka(string strKijunYmd)
        {
            DBConnective dbconnective = new DBConnective();
            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            try
            {
                listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
                listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_SELECT_karitanka");

                // トランザクション開始
                dbconnective.BeginTrans();

                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                // SQL文作成
                string sql = string.Format(strSqltxt, strKijunYmd);

                //strSql = "SELECT 商品コード,仮単価";
                //strSql += " FROM 商品仕入単価履歴TMP2 ";
                //strSql += " WHERE 在庫年月日='" + strKijunYmd + "'";
                //strSql += " ORDER BY 商品コード";

                // 商品仕入単価履歴TMP2テーブルの仮単価取得
                DataTable dtKariTanka = dbconnective.ReadSql(sql);

                if (dtKariTanka != null)
                {
                    listSqlPath = new List<string>();
                    listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
                    listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_SELECT_hyoka");

                    foreach (DataRow dr in dtKariTanka.Rows)
                    {
                        // 変数初期化
                        string syohinCd = "";
                        strSqltxt = "";
                        sql = "";

                        // 商品コード取得
                        syohinCd = dr["商品コード"].ToString().Trim();

                        // sqlファイルからSQL文を取得
                        strSqltxt = opensql.setOpenSQL(listSqlPath);
                        // SQL文作成
                        sql = string.Format(strSqltxt, syohinCd);

                        //strSql = "SELECT 評価単価";
                        //strSql += " FROM 商品";
                        //strSql += " WHERE 商品コード='" + dr["商品コード"].ToString().Trim() + "'";

                        // 商品テーブルの評価単価取得
                        DataTable dtHyokaTanka = dbconnective.ReadSql(sql);

                        if (dtHyokaTanka != null && dtHyokaTanka.Rows.Count > 0)
                        {
                            string karitanka = "";
                            string hyokatanka = "";
                            string shohinCd = "";
                            string updateYmd = "";
                            string userName = "";

                            karitanka = dr["仮単価"].ToString();
                            hyokatanka = dtHyokaTanka.Rows[0]["評価単価"].ToString();
                            shohinCd = dr["商品コード"].ToString().Trim();
                            updateYmd = DateTime.Now.ToString();
                            userName = Environment.UserName.ToString();

                            if (karitanka != "" && hyokatanka != "")
                            {
                                // 商品仕入単価履歴TMP2テーブルの仮単価と商品テーブルの評価単価が違う場合、商品テーブルの評価単価更新
                                if (decimal.Parse(karitanka) != decimal.Parse(hyokatanka))
                                {
                                    strSqltxt = "";
                                    sql = "";

                                    listSqlPath = new List<string>();
                                    listSqlPath.Add("M1240_ShohinSiireKakakuSuii2");
                                    listSqlPath.Add("M1240_ShohinSiireKakakuSuii2_UPDATE_hyokatanka");

                                    // sqlファイルからSQL文を取得
                                    strSqltxt = opensql.setOpenSQL(listSqlPath);
                                    // SQL文作成
                                    sql = string.Format(strSqltxt, syohinCd, karitanka, updateYmd, userName);

                                    //strSql = " UPDATE 商品";
                                    //strSql += " SET ";
                                    //strSql += " 評価単価=" + dr["仮単価"].ToString() + ",";
                                    //strSql += " 更新日時='" + DateTime.Now + "',";
                                    //strSql += " 更新ユーザー名='" + Environment.UserName + "'";
                                    //strSql += " WHERE ";
                                    //strSql += " 商品コード='" + dr["商品コード"].ToString().Trim() + "'";

                                    // 更新
                                    dbconnective.RunSql(sql);
                                }
                            }


                        }
                    }
                }

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
            return;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成
        /// </summary>
        /// <param name="dtShohin">
        ///     商品仕入単価履歴TMP2のデータテーブル
        /// </param>
        /// <param name="lstItem">
        ///     Excel出力用データ
        /// </param>
        /// <param name="strExcelFilePath">
        ///     Excel出力ファイルパス
        /// </param>
        /// -----------------------------------------------------------------------------
        public bool dbToExcel(DataTable dtShohin, List<string> lstItem, string strExcelFilePath)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/商品単価一覧.xlsx";
            string strShu = "";

            // テンプレートが存在すれば処理
            if (System.IO.File.Exists(strFilePath))
            {
                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);

                try
                {
                    IXLWorksheet currentsheet = workbook.Worksheet(1);   // 処理中シート

                    int xlsRowCnt = 14;  // Excel出力行カウント（開始は出力行）

                    currentsheet.Cell("F3").Value = lstItem[0].ToString();  // 大分類
                    currentsheet.Cell("H3").Value = lstItem[1].ToString();  // 中分類
                    currentsheet.Cell("K3").Value = lstItem[2].ToString();  // メーカー
                    currentsheet.Cell("G5").Value = lstItem[3].ToString();  // 期間From
                    currentsheet.Cell("I5").Value = lstItem[4].ToString();  // 期間To
                    currentsheet.Cell("G6").Value = lstItem[5].ToString();  // 基準在庫日

                    // 全項目にチェックが入っている場合
                    if (bool.Parse(lstItem[6]) == true)
                    {
                        strShu += "全項目";
                    }
                    else
                    {
                        // 期間内売上ありの場合
                        if (lstItem[7].Equals("0"))
                        {
                            strShu += " 期間内売上あり";
                        }
                        // 期間内売上なしの場合
                        else if (lstItem[7].Equals("1"))
                        {
                            strShu += " 期間内売上なし";
                        }

                        // 期間内仕入ありの場合
                        if (lstItem[8].Equals("0"))
                        {
                            strShu += " 期間内仕入あり";
                        }
                        // 期間内仕入なしの場合
                        else if (lstItem[8].Equals("1"))
                        {
                            strShu += " 期間内仕入なし";
                        }
                    }

                    currentsheet.Cell("K5").Value = strShu;                     // 検索条件
                    currentsheet.Cell("H9").Value = lstItem[9].ToString();      // 在庫金額合計（商品マスタ評価単価）
                    currentsheet.Cell("H10").Value = lstItem[10].ToString();    // 在庫金額合計（設定単価）
                    currentsheet.Cell("H11").Value = lstItem[11].ToString();    // 在庫金額合計（直近仕入単価）

                    // 出力に必要な分Excelに行を追加
                    for (int rowCnt = 1; rowCnt < dtShohin.Rows.Count; rowCnt++)
                    {
                        currentsheet.Range(14, 1, 14, 16).CopyTo(currentsheet.Range(14 + rowCnt, 1, 14 + rowCnt, 16));
                    }

                    // ClosedXMLで1行ずつExcelに出力
                    foreach (DataRow drShohin in dtShohin.Rows)
                    {
                        for (int columnCnt = 1; columnCnt <= 16; columnCnt++)
                        {
                            currentsheet.Cell(xlsRowCnt, columnCnt).Value = drShohin[columnCnt].ToString();
                        }

                        xlsRowCnt++;
                    }

                    // workbookを保存
                    workbook.SaveAs(strExcelFilePath);

                    return true;

                }
                catch
                {
                    throw;
                }
                finally
                {
                    // workbookを解放
                    workbook.Dispose();
                }
            }
            else
            {
                return false;
            }

        }
    }
}
