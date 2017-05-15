using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;

namespace KATO.Business.D0360_JuchuzanKakunin
{
    class D0360_JuchuzanKakunin_B
    {
        public DataTable getZanList(string[] listParam)
        {
            DataTable dtZanList = null;
            string    strQuery;

            strQuery  = "SELECT a.受注年月日 AS 受注日";
            strQuery += "      ,a.納期";
            strQuery += "      ,dbo.f_getメーカー名(a.メーカーコード) AS メーカー";
            strQuery += "      ,dbo.f_get中分類名(a.大分類コード,a.中分類コード)";
            strQuery += "          + ' ' +  Rtrim(ISNULL(a.Ｃ１,'')) ";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ２,''))";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ３,''))";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ４,''))";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ５,''))";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ６,'')) AS 品名";
            strQuery += "      ,a.受注数量 AS 受注数";
            strQuery += "      ,(a.受注数量 - a.売上済数量 ) AS 受注残";
            strQuery += "      ,0 AS 発注残";
            strQuery += "      ,a.受注単価 AS 売上単価";
            strQuery += "      ,ROUND(((a.受注数量 - a.売上済数量 )*a.受注単価 ),0,1) AS 売上金額";
            strQuery += "      ,a.仕入単価 AS 仕入単価,";
            strQuery += "      ,ROUND(((a.受注数量 - a.売上済数量 )*a.仕入単価),0,1)  AS 仕入金額";
            strQuery += "      ,a.注番";
            strQuery += "      ,0 AS 仕入合計金額";
            strQuery += "      ,'' AS 客先注番";
            strQuery += "      ,a.得意先名称 AS 得意先名,";
            strQuery += "      ,'' AS 仕入日";
            strQuery += "      ,dbo.f_get受注番号から最終に発注した仕入先名称(a.受注番号)  AS 仕入先名";
            strQuery += "      ,a.売上済数量 AS 売上済";
            strQuery += "      ,0 AS 仕入済";
            strQuery += "      ,'' AS 発注日";
            strQuery += "      ,dbo.f_get受注番号_発注状態(a.受注番号) AS 状態";
            strQuery += "      ,a.受注番号";
            strQuery += "      ,dbo.f_get担当者名(a.受注者コード) AS 受注者";
            strQuery += "      ,dbo.f_get担当者名(a.担当者コード) AS 担当者";
            strQuery += "      ,'' AS 発注者";
            strQuery += "  FROM 受注 a";
            strQuery += " WHERE a.削除 = 'N'";
            strQuery += "   AND ((a.売上済数量 = 0) OR (a.売上済数量 < a.受注数量))";

            if (!StringUtl.blIsEmpty(listParam[18]))
            {
                strQuery += "   AND a.得意先コード = " + listParam[18];
            }
            if (!StringUtl.blIsEmpty(listParam[15]))
            {
                strQuery += "   AND a.担当者コード = " + listParam[15];
            }
            if (!StringUtl.blIsEmpty(listParam[17]))
            {
                strQuery += "   AND dbo.f_get取引先マスタ担当者(a.得意先コード) = " + listParam[17];
            }

            if (!StringUtl.blIsEmpty(listParam[5]))
            {
                strQuery += "   AND a.納期 >= " + listParam[5];
            }

            if (!StringUtl.blIsEmpty(listParam[6]))
            {
                strQuery += "   AND a.納期 <= " + listParam[6];
            }

            if (!StringUtl.blIsEmpty(listParam[2]))
            {
                strQuery += "   AND (dbo.f_get中分類名(a.大分類コード,a.中分類コード)  +  REPLACE(ISNULL(a.Ｃ１,''),' ','' ) ";
                strQuery += "       +  REPLACE(ISNULL(a.Ｃ２,''),' ','' )";
                strQuery += "       +  REPLACE(ISNULL(a.Ｃ３,''),' ','' )";
                strQuery += "       +  REPLACE(ISNULL(a.Ｃ３,''),' ','' )";
                strQuery += "       +  REPLACE(ISNULL(a.Ｃ３,''),' ','' )";
                strQuery += "       +  REPLACE(ISNULL(a.Ｃ６,''),' ','' ) ) LIKE '%" + listParam[2].Replace(" ", "") + "%' ";
            }

            if (!StringUtl.blIsEmpty(listParam[3]))
            {
                strQuery += "   AND a.注番 LIKE " + listParam[3];
            }

            if (!StringUtl.blIsEmpty(listParam[25]))
            {
                if (int.Parse(listParam[25]) == 1)
                {
                    strQuery += "   AND a.営業所コード = '0001'";
                }
                else if (int.Parse(listParam[25]) == 2)
                {
                    strQuery += "   AND a.営業所コード = '0002'";
                }
            }

            if (!StringUtl.blIsEmpty(listParam[0]))
            {
                strQuery += "   AND a.受注番号 = " + listParam[0];
            }

            if (!StringUtl.blIsEmpty(listParam[24]))
            {
                if (int.Parse(listParam[24]) == 1)
                {
                    strQuery += "   AND dbo.f_get受注番号から加工区分(a.受注番号) = '0'";
                }
                else if (int.Parse(listParam[24]) == 2)
                {
                    strQuery += "   AND dbo.f_get受注番号から加工区分(a.受注番号) = '1'";
                }
            }

            strQuery += " UNION ";

            /*
                受注日
                納期
                メーカー
                品名・型式
                受注数
                受注残
                発注残
                売上単価
                売上金額
                仕入単価
                仕入金額
                注番
                仕入合計金額　　（加工品の場合のみ）
                客先注番
                得意先名
                仕入日
                仕入先名
                売上済
                仕入済
                発注日
                状態　　　　　　発注済・入荷済・一部入荷　
                受注番号
                受注者
                担当者
                発注者
             */
            strQuery += "SELECT b.受注年月日 AS 受注日";
            strQuery += "      ,a.納期";
            strQuery += "      ,dbo.f_getメーカー名(a.メーカーコード) AS メーカー";
            strQuery += "      ,dbo.f_get中分類名(a.大分類コード, a.中分類コード)";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ１,'')) ";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ２,''))";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ３,''))";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ４,''))";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ５,''))";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ６,'')) AS 品名";
            strQuery += "      ,a.受注数量 AS 受注数";
            strQuery += "      ,(b.受注数量 - b.売上済数量 ) AS 受注残";
            strQuery += "      ,(a.発注数量 - a.仕入済数量) AS AS 発注残";
            strQuery += "      ,a.受注単価 AS 売上単価";
            strQuery += "      ,ROUND(((b.受注数量 - b.売上済数量 ) * b.受注単価 ), 0, 1) AS 売上金額";
            strQuery += "      ,a.仕入単価 AS 仕入単価,";
            strQuery += "      ,ROUND(((b.受注数量 - b.売上済数量 ) * b.仕入単価), 0, 1)  AS 仕入金額";
            strQuery += "      ,a.注番";
            strQuery += "      ,0 AS 仕入合計金額";
            strQuery += "      ,'' AS 客先注番";
            strQuery += "      ,a.得意先名称 AS 得意先名,";
            strQuery += "      ,'' AS 仕入日";
            strQuery += "      ,a.仕入先名称 AS 仕入先名";
            strQuery += "      ,a.売上済数量 AS 売上済";
            strQuery += "      ,a.仕入済数量 AS 仕入済";
            strQuery += "      ,b.発注年月日 AS 発注日";
            strQuery += "      ,dbo.f_get受注番号_発注状態(a.受注番号) AS 状態";
            strQuery += "      ,a.受注番号";
            strQuery += "      ,dbo.f_get担当者名(b.受注者コード) AS 受注者";
            strQuery += "      ,dbo.f_get担当者名(a.担当者コード) AS 担当者";
            strQuery += "      ,dbo.f_get担当者名(a.発注者コード) AS 発注者";


            strQuery += "SELECT a.発注年月日";
            strQuery += "      ,a.発注番号";
            strQuery += "      ,a.納期";
            strQuery += "      ,RTRIM(dbo.f_get注番文字FROM担当者 (発注者コード)) + CAST(発注番号 AS varchar(8)) AS 注番";
            strQuery += "      ,dbo.f_getメーカー名(a.メーカーコード),";
            strQuery += "      ,dbo.f_get中分類名(a.大分類コード, a.中分類コード)";
            strQuery += "           + ' ' + Rtrim(ISNULL(a.Ｃ１,''))";
            strQuery += "           + ' ' + Rtrim(ISNULL(a.Ｃ２,''))";
            strQuery += "           + ' ' + Rtrim(ISNULL(a.Ｃ３,''))";
            strQuery += "           + ' ' + Rtrim(ISNULL(a.Ｃ４,''))";
            strQuery += "           + ' ' + Rtrim(ISNULL(a.Ｃ５,''))";
            strQuery += "           + ' ' + Rtrim(ISNULL(a.Ｃ６,'')) AS 品名";
            strQuery += "      ,(a.発注数量-a.仕入済数量) AS 数量";
            strQuery += "      ,a.発注単価";
            strQuery += "      ,ROUND(((a.発注数量 - a.仕入済数量 )*a.発注単価 ),0,1)  AS 発注金額";
            strQuery += "      ,a.商品コード";
            strQuery += "      ,a.仕入済数量";
            strQuery += "      ,dbo.f_get担当者名(a.発注者コード) AS 発注者";
            strQuery += "      ,dbo.f_get発注の受注番号_得意先名(a.受注番号)";
            strQuery += "      ,a.仕入先名称";
            strQuery += "      ,a.注番 AS 注番受注";
            strQuery += "      ,Rtrim(ISNULL(a.Ｃ１,''))";
            strQuery += "      ,a.受注番号";

            strQuery += "  FROM 発注 a LEFT OUTER JOIN 受注 b  ON a.受注番号 = b.受注番号";


    //strWhere = " a.削除 = 'N'"
    //strWhere = strWhere & " AND ((a.仕入済数量 = 0) OR (abs(a.仕入済数量) < abs(a.発注数量))) "
    //strWhere = strWhere & " AND a.発注数量 <> 0 "
    //strWhere = strWhere & " AND a.仕入先コード<>'7777'"     '2011.4.11
    //strWhere = strWhere & " AND a.仕入先コード<>'9999'"     '2011.4.11


            return dtZanList;
        }

    }
}
