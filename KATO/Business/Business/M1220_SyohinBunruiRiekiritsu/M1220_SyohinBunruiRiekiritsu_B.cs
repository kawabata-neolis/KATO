using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Data;

namespace KATO.Business.M1220_SyohinBunruiRiekiritsu
{
    /// <summary>
    /// M1220_SyohinBunruiRiekiritsu_B
    /// 商品分類別利益率設定 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/6/27
    /// 更新者：多田
    /// 更新日：2017/6/27
    /// カラム論理名
    /// </summary>
    class M1220_SyohinBunruiRiekiritsu_B
    {

        /// <summary>
        /// getRiekiritsuList
        /// 商品分類別利益率を取得
        /// </summary>
        public DataTable getRiekiritsuList(List<string> lstSearchItem, List<string> lstSerachOrder)
        {
            string strSql;
            DataTable dtGetTableGrid = new DataTable();

            strSql = "SELECT d.得意先コード,";
            strSql += "dbo.f_get取引先名称(d.得意先コード) AS 得意先名,";
            strSql += "RTRIM(dbo.f_get大分類名(d.大分類コード)) AS 大分類,";
            strSql += "RTRIM(dbo.f_get中分類名(d.大分類コード,d.中分類コード)) AS 中分類,";
            strSql += "RTRIM(dbo.f_getメーカー名(d.メーカーコード)) AS メーカー,";
            strSql += "d.利益率 ,";
            strSql += "d.掛率 ,";
            strSql += "'  ' + d.設定 AS 設定,";
            strSql += "d.大分類コード,";
            strSql += "d.中分類コード,";
            strSql += "d.メーカーコード,";
            strSql += "d.ID";

            strSql += " FROM 商品分類別利益率 d ";
            strSql += " WHERE ";

            strSql += " d.削除='N' ";

            // 得意先コードがある場合
            if (!lstSearchItem[0].Equals(""))
            {
                strSql += " AND d.得意先コード='" + lstSearchItem[0] + "'";
            }

            // 担当者コードがある場合
            if (!lstSearchItem[1].Equals(""))
            {
                strSql += " AND dbo.f_get担当者コード(d.得意先コード)='" + lstSearchItem[1] + "'";
            }

            // 大分類コードがある場合
            if (!lstSearchItem[2].Equals(""))
            {
                strSql += " AND d.大分類コード='" + lstSearchItem[2] + "'";
            }

            // 中分類コードがある場合
            if (!lstSearchItem[3].Equals(""))
            {
                strSql += " AND d.中分類コード='" + lstSearchItem[3] + "'";
            }

            // メーカーがある場合
            if (!lstSearchItem[4].Equals(""))
            {
                strSql += " AND d.メーカーコード='" + lstSearchItem[4] + "'";
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
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



        /// <summary>
        /// addRiekiritsu
        /// 商品分類別利益率へ追加
        /// </summary>
        public void addRiekiritsu(List<string> lstItem)
        {
            string strProc = "商品分類別利益率設定マスタ更新_PROC ";

            // IDがない場合
            if (lstItem[0].Equals(""))
            {
                strProc += "NULL, ";
            }
            else
            {
                strProc += lstItem[0] + ", ";
            }

            strProc += "'" + lstItem[1] + "', '" + lstItem[2] + "', ";

            // 中分類がない場合
            if (lstItem[3].Equals(""))
            {
                strProc += "NULL, ";
            }
            else
            {
                strProc += "'" + lstItem[3] + "', ";
            }

            // メーカーがない場合
            if (lstItem[4].Equals(""))
            {
                strProc += "NULL, ";
            }
            else
            {
                strProc += "'" + lstItem[4] + "', ";
            }

            strProc += "'" + lstItem[5] + "', ";

            // 利益率がない場合
            if (lstItem[6].Equals(""))
            {
                strProc += "NULL, ";
            }
            else
            {
                strProc += lstItem[6] + ", ";
            }

            // 掛率がない場合
            if (lstItem[7].Equals(""))
            {
                strProc += "NULL";
            }
            else
            {
                strProc += lstItem[7] + ", ";
            }

            strProc += "'" + lstItem[8] + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 商品分類別利益率設定マスタ更新_PROCを実行
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
        }


        /// <summary>
        /// delRiekiritsu
        /// 表示中のマスタデータを削除する処理
        /// </summary>
        public void delRiekiritsu(List<string> lstDeleteItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 商品分類別利益率設定マスタ削除_PROCを実行
                dbconnective.RunSql("商品分類別利益率設定マスタ削除_PROC " + lstDeleteItem[0] + ", '" + lstDeleteItem[1] + "'");

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
        /// getDataCount
        /// 登録するデータがすでにデータベースに登録されているか確認する処理
        /// </summary>
        public DataTable getDataCount(List<string> lstItem)
        {
            string strSql;
            DataTable dtGetTable = new DataTable();

            strSql = "SELECT COUNT(*) AS 件数 FROM 商品分類別利益率 ";
            strSql += " WHERE 得意先コード='" + lstItem[0] + "'";
            strSql += " AND 大分類コード='" + lstItem[1] + "'";

            // 中分類がない場合
            if (lstItem[2].Equals("")){
                strSql += " AND 中分類コード IS NULL ";
            }
            else
            {
                strSql += " AND 中分類コード='" + lstItem[2] + "'";
            }

            // メーカーがない場合
            if (lstItem[3].Equals(""))
            {
                strSql += " AND メーカーコード IS NULL";
            }
            else
            {
                strSql += " AND メーカーコード='" + lstItem[3] + "'";
            }

            strSql += " AND 削除='N'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetTable = dbconnective.ReadSql(strSql);
            }
            catch
            {
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return dtGetTable;
        }
    }
}
