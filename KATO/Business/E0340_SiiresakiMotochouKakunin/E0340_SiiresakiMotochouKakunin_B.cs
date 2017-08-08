using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;

namespace KATO.Business.E0340_SiiresakiMotochouKakunin
{
    /// <summary>
    /// E0340_SiiresakiMotochouKakunin_B
    /// 仕入先元帳確認 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/12
    /// 更新者：多田
    /// 更新日：2017/7/12
    /// カラム論理名
    /// </summary>
    class E0340_SiiresakiMotochouKakunin_B
    {

        /// <summary>
        /// getSiireList
        /// 仕入を取得
        /// </summary>
        public DataTable getSiireList(List<string> lstItem, int intSqlIndex)
        {
            string strSql = "";
            DataTable dtGetTableGrid = new DataTable();

            switch (intSqlIndex)
            {
                case 1:
                    strSql = "SELECT dbo.f_get買掛残高一覧表_繰越残高FROM取引先経理情報( '" + lstItem[0] +
                        "',dbo.f_月初日('" + lstItem[1] + "'))";
                    break;
                case 2:
                    strSql = "SELECT dbo.f_get買掛残高一覧表_仕入ヘッダ_仕入高( '" + lstItem[0] + "','" + lstItem[1] + "','" + lstItem[2] + "')";
                    break;
                case 3:
                    strSql = "SELECT dbo.f_get買掛残高一覧表_仕入ヘッダ_消費税( '" + lstItem[0] + "','" + lstItem[1] + "','" + lstItem[2] + "')";
                    break;
                case 4:
                    strSql = "SELECT dbo.f_get売掛残高一覧表_月間消費税( '" + lstItem[0] + "','" + lstItem[2] + "'," + lstItem[3] + ")";
                    break;
                case 5:
                    strSql = "SELECT dbo.f_get買掛残高一覧表_支払_現金( '" + lstItem[0] + "','" + lstItem[1] + "','" + lstItem[2] + "')";
                    break;
                case 6:
                    strSql = "SELECT dbo.f_get買掛残高一覧表_支払_小切手( '" + lstItem[0] + "','" + lstItem[1] + "','" + lstItem[2] + "')";
                    break;
                case 7:
                    strSql = "SELECT dbo.f_get買掛残高一覧表_支払_振込( '" + lstItem[0] + "','" + lstItem[1] + "','" + lstItem[2] + "')";
                    break;
                case 8:
                    strSql = "SELECT dbo.f_get買掛残高一覧表_支払_手形( '" + lstItem[0] + "','" + lstItem[1] + "','" + lstItem[2] + "')";
                    break;
                case 9:
                    strSql = "SELECT dbo.f_get買掛残高一覧表_支払_相殺( '" + lstItem[0] + "','" + lstItem[1] + "','" + lstItem[2] + "')";
                    break;
                case 10:
                    strSql = "SELECT dbo.f_get買掛残高一覧表_支払_手数料( '" + lstItem[0] + "','" + lstItem[1] + "','" + lstItem[2] + "')";
                    break;
                case 11:
                    strSql = "SELECT dbo.f_get買掛残高一覧表_支払_その他( '" + lstItem[0] + "','" + lstItem[1] + "','" + lstItem[2] + "')";
                    break;
                case 12:
                    strSql = "SELECT 伝票年月日,伝票番号,行番号,取引区分名,";
                    strSql += "メーカー名,商品名,数量,";
                    strSql += "仕入単価,仕入金額,支払額,0,取引区分";
                    strSql += " FROM 仕入先元帳明細_VIEW";
                    strSql += " WHERE 仕入先コード = '" + lstItem[0] + "'";
                    strSql += " AND 伝票年月日 >='" + lstItem[1] + "'";
                    strSql += " AND 伝票年月日 <='" + lstItem[2] + "'";
                    strSql += " ORDER BY 伝票年月日,表示順,伝票番号,行番号 ";
                    break;
            }


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
