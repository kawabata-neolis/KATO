using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Data;

namespace KATO.Business.A0670_SiiresakiSiirekakunin
{
    /// <summary>
    /// 検収、未検収合計結果格納用</summary>
    public class Kingaku
    {
        public string kensyu { get; set; }
        public string mikensyu { get; set; }
    }

    class A0670_SiiresakiSiirekakunin_B
    {
        /// <summary>
        /// gridに表示するデータ取得</summary>
        /// <param name="arrSearch">
        ///     検索文字列用配列</param>
        /// <param name="arrOrder">
        ///     出力順用配列</param>
        /// <param name="arrDisplay">
        ///     表示選択用配列</param>
        public DataTable getSiireData(string[] arrSearch, string[] arrOrder, string[] arrDisplay)
        {
            DataTable dt = new DataTable();

            try
            {
                // DBコネクションのインスタンス生成
                DBConnective dbconnective = new DBConnective();
                // AND条件用変数
                string andSql = "";
                // ORDER BY用変数
                string orderSql = "";

                string sCode = arrSearch[0];        // 仕入先コード
                string startYmd = arrSearch[1];     // 伝票年月日start
                string endYmd = arrSearch[2];       // 伝票年月日end

                // 大分類コードが入力されている場合
                if (arrSearch[3] != "")
                {
                    andSql += " AND b.大分類コード = '" + arrSearch[3] + "'";
                }

                // 中分類コードが入力されている場合
                if (arrSearch[4] != "")
                {
                    andSql += " AND b.中分類コード = '" + arrSearch[4] + "'";
                }

                // 品名・型番が入力されている場合
                if (arrSearch[5] != "")
                {
                    andSql += " AND (RTRIM(ISNULL(dbo.f_get中分類名(b.大分類コード,b.中分類コード),'')) +  Rtrim(ISNULL(b.Ｃ１,'')) ";
                    andSql += " +  Rtrim(ISNULL(b.Ｃ２,''))";
                    andSql += " +  Rtrim(ISNULL(b.Ｃ３,''))";
                    andSql += " +  Rtrim(ISNULL(b.Ｃ４,''))";
                    andSql += " +  Rtrim(ISNULL(b.Ｃ５,''))";
                    andSql += " +  Rtrim(ISNULL(b.Ｃ６,'')) ) LIKE '%" + arrSearch[5] + "%' AS 品名型番";
                }

                // 備考が入力されている場合
                if (arrSearch[6] != "")
                {
                    andSql += " AND 備考 LIKE '%" + arrSearch[6] + "%'";
                }

                // 表示選択
                // arrDisplay[0]="TRUE"の場合は「すべて」にチェックのため条件指定なし
                if (arrDisplay[1].Equals("TRUE"))
                {
                    // 未検収のみ表示の場合
                    andSql += " AND dbo.f_get検収仕入フラグ(a.伝票番号,b.行番号) IS NULL ";
                }
                else if (arrDisplay[2].Equals("TRUE"))
                {
                    // 検収済のみ表示の場合
                    andSql += " AND dbo.f_get検収仕入フラグ(a.伝票番号,b.行番号) = '済' ";
                }

                // 出力順
                if (arrOrder[0].Equals("TRUE"))
                {
                    // 日付・伝票番号順
                    orderSql += " ORDER BY a.伝票年月日,b.伝票番号,b.行番号 ";
                }
                else
                {
                    // 日付・伝票番号順
                    orderSql += " ORDER BY ";
                    orderSql += "b.Ｃ１,b.Ｃ２,b.Ｃ３,b.Ｃ４,b.Ｃ５,b.Ｃ６,";
                    orderSql += "a.伝票年月日,b.伝票番号,b.行番号";
                }
                
                // SQLのパス指定用List
                List<string> listSqlPath = new List<string>();
                listSqlPath.Add("A0670_SiiresakiSiirekakunin");
                listSqlPath.Add("A0670_SiiresakiSiirekakunin_SELECT");

                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, sCode, startYmd, endYmd, andSql, orderSql);

                dt = dbconnective.ReadSql(sql);
            }
            catch (Exception ex)
            {
                throw;
            }

            return dt;
        }

        #region カンマ付きの金額を計算し、結果をListで返す(２種)
        /// <summary>
        ///     カンマ付きの金額を計算し、結果をListで返す（個別）
        /// </summary>
        /// <param name="siire">
        ///     仕入金額</param>
        /// <param name="kensyu">
        ///     検収合計金額</param>
        /// <param name="mikensyu">
        ///     未検収合計金額</param>
        /// <param name="flg">
        ///     flg=0：済にした場合　flg=1：済を解除した場合</param>
        /// <returns>
        ///     検収、未検収の合計結果をListで返す</returns>
        public List<Kingaku> kingakuCalculation(string siire, string kensyu, string mikensyu, int flg)
        {
            List<Kingaku> lstKingaku = new List<Kingaku>();

            int iSiire = int.Parse(siire, System.Globalization.NumberStyles.AllowThousands);
            int iKensyu = int.Parse(kensyu, System.Globalization.NumberStyles.AllowThousands);
            int iMikensyu = int.Parse(mikensyu, System.Globalization.NumberStyles.AllowThousands);

            // flg=0：済にした場合　flg=1：済を解除した場合
            if (flg == 0)
            {
                iKensyu = iKensyu + iSiire;
                iMikensyu = iMikensyu - iSiire;
            }
            else
            {
                iKensyu = iKensyu - iSiire;
                iMikensyu = iMikensyu + iSiire;
            }

            // Listに要素追加（検収金額、未検収金額）
            lstKingaku.Add(new Kingaku(){
                kensyu = String.Format("{0:#,0}", iKensyu),
                mikensyu = String.Format("{0:#,0}", iMikensyu)
            });

            return lstKingaku;
        }
        /// <summary>
        ///     カンマ付きの金額を計算し、結果をListで返す（すべて）
        /// </summary>
        /// <param name="kensyu">
        ///     検収合計金額</param>
        /// <param name="mikensyu">
        ///     未検収合計金額</param>
        /// <param name="flg">
        ///     flg=0：済にした場合　flg=1：済を解除した場合</param>
        /// <returns>
        ///     検収、未検収の合計結果をListで返す</returns>
        public List<Kingaku> kingakuCalculation(string kensyu, string mikensyu, int flg)
        {
            List<Kingaku> lstKingaku = new List<Kingaku>();

            int iKensyu = int.Parse(kensyu, System.Globalization.NumberStyles.AllowThousands);
            int iMikensyu = int.Parse(mikensyu, System.Globalization.NumberStyles.AllowThousands);

            // flg=0：済にした場合　flg=1：済を解除した場合
            if (flg == 0)
            {
                iKensyu = iKensyu + iMikensyu;
                iMikensyu = 0;
            }
            else
            {
                iMikensyu = iMikensyu + iKensyu;
                iKensyu = 0;
            }

            // Listに要素追加（検収金額、未検収金額）
            lstKingaku.Add(new Kingaku()
            {
                kensyu = String.Format("{0:#,0}", iKensyu),
                mikensyu = String.Format("{0:#,0}", iMikensyu)
            });

            return lstKingaku;
        }
        #endregion

        /// <summary>
        ///     検収済仕入明細テーブル更新(検収済仕入明細更新_PROC実行)
        /// </summary>
        /// <param name="dt">
        ///     更新対象データ（DataGridView内のデータ）</param>
        /// <param name="userName">
        ///     ユーザ名</param>
        /// <returns>
        ///     </returns>
        public void UpdateKnesyuSiire(DataTable dt, string userName)
        {
            // DBコネクションのインスタンス生成
            DBConnective dbconnective = new DBConnective();

            foreach (DataRow row in dt.Rows)
            {
                string denNo = "";
                string rowNo = "";
                string status = "";
                try
                {
                    // トランザクション開始
                    dbconnective.BeginTrans();

                    denNo = row["伝票番号"].ToString();
                    rowNo = row["行番号"].ToString();
                    status = row["検収状態"].ToString();

                    string strProc = "検収済仕入明細更新_PROC '" 
                        + denNo + "' ,'"
                        + rowNo + "' ,'"
                        + status + "' ,'"
                        + userName + "'";

                    // ストアド実行
                    dbconnective.ReadSql(strProc);

                    dbconnective.Commit();
                }
                catch (Exception ex)
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

        }
    }
}
