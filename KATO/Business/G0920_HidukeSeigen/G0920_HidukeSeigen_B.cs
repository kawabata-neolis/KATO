using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.G0920_HidukeSeigen
{
    /// <summary>
    /// B0060_ShiharaiInput_B
    /// 日付制限 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/6/29
    /// 更新者：多田
    /// 更新日：2017/6/29
    /// カラム論理名
    /// </summary>
    class G0920_HidukeSeigen_B
    {
        /// <summary>
        /// addHidukeSeigen
        /// 表示中の日付制限を追加する処理
        /// </summary>
        public void addHidukeSeigen(List<string> lstItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                string strProc = "日付制限更新_PROC " + lstItem[0] + ", '" + lstItem[1] + "', '" +
                    lstItem[2] + "', '" + lstItem[3] + "', '" + lstItem[4] + "'";

                // 日付制限更新_PROCを実行
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
        /// delShiharai
        /// 表示中の日付制限を削除する処理
        /// </summary>
        public void delHidukeSeigen(List<string> lstItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 日付制限削除_PROCを実行
                dbconnective.RunSql("日付制限削除_PROC " + lstItem[0] + ", '" + lstItem[1] + "', '" + lstItem[2] + "'");

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
        /// getRiekiritsuList
        /// 日付制限を取得
        /// </summary>
        public DataTable getHidukeSeigenList()
        {
            string strSql;
            DataTable dtGetTableGrid = new DataTable();

            strSql = "SELECT a.画面ＮＯ, b.ＰＧ名, a.営業所コード, dbo.f_get営業所名(a.営業所コード) AS 営業所名, a.最小年月日, a.最大年月日";
            strSql += " FROM 日付制限 a, メニュー b";
            strSql += " WHERE a.削除='N' and b.ＰＧ番号 = a.画面ＮＯ";
            strSql += " ORDER BY 画面ＮＯ";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをデータテーブルへ格納
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
        /// getGamenList
        /// 画面No、画面名を取得
        /// </summary>
        public DataTable getGamenList(string strGamenNo)
        {
            DataTable dtGetTable = new DataTable();

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをデータテーブルへ格納
                dtGetTable = dbconnective.ReadSql("SELECT ＰＧ番号, ＰＧ名 FROM メニュー WHERE ＰＧ番号=" + strGamenNo);

                return dtGetTable;
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
    }
}
