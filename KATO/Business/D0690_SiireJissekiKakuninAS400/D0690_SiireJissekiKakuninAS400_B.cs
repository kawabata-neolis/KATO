using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Data;

namespace KATO.Business.D0690_SiireJissekiKakuninAS400
{
    /// D0690_SiireJissekiKakuninAS400_B
    /// 仕入実績確認（AS400） ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/6/30
    /// 更新者：多田
    /// 更新日：2017/6/30
    /// カラム論理名
    /// </summary>
    class D0690_SiireJissekiKakuninAS400_B
    {

        /// <summary>
        /// getSiireJissekiList
        /// 仕入実績を取得
        /// </summary>
        public DataTable getSiireJissekiList(List<string> lstItem)
        {
            string strSql;
            DataTable dtGetTableGrid = new DataTable();

            strSql = "SELECT 処理日付, 伝票番号,";
            strSql += " RTRIM(ISNULL(手打品名,''))";
            strSql += " + ' ' + Rtrim(ISNULL(型番,''))";
            strSql += " + ' ' + Rtrim(ISNULL(枝,'')) AS 型番,";
            strSql += " 数量, 仕入単価, 仕入金額, 備考, 摘要, 仕入先名";
            strSql += " FROM AS400仕入明細";
            strSql += " WHERE 処理日付 >='" + lstItem[1] + "'";
            strSql += " AND 処理日付 <='" + lstItem[2] + "'";

            // 仕入先コードがある場合
            if (!lstItem[0].Equals(""))
            {
                strSql += " AND 仕入先コード = '" + lstItem[0] + "'";
            }

            // 型番がある場合
            if (!lstItem[3].Equals(""))
            {
                strSql += " AND (RTRIM(ISNULL(手打品名,''))";
                strSql += " + Rtrim(ISNULL(型番,''))";
                strSql += " + Rtrim(ISNULL(枝,'')) ) LIKE '%" + lstItem[3] + "%' ";
            }

            // 備考がある場合
            if (!lstItem[4].Equals(""))
            {
                strSql += " AND ( 備考 LIKE '%" + lstItem[4] + "%'";
                strSql += " OR 摘要 LIKE '%" + lstItem[4] + "%')";
            }

            strSql += " ORDER BY 処理日付 DESC, 伝票番号";

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
    }
}
