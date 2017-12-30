﻿using System;
using System.Data;
using System.Linq;
using KATO.Common.Util;

namespace KATO.Business.D0360_JuchuzanKakunin
{
    ///<summary>
    ///D0360_JuchuzanKakunin
    ///残確認画面 ビジネスロジック
    ///作成者：陶山
    ///作成日：2017/6/1
    ///更新者：陶山
    ///更新日：2017/6/1
    ///カラム論理名
    ///</summary>
    class D0360_JuchuzanKakunin_B
    {
        /// <summary>
        /// getZanList
        /// 受注残/発注残一覧取得
        /// </summary>
        public DataTable getZanList(string[] listParam)
        {
            DataTable dtZanList = null;
            string    strQuery = "";
            string[] listSortItem =
            {
                "受注日"
                ,"発注日"
                ,"納期"
                ,"注番"
            };
            string[] listSortOrder =
            {
                " ASC"
                ," DESC"
            };

            // 受注残が検索対象となる場合
            if (int.Parse(listParam[29]) == 0 || int.Parse(listParam[29]) == 1)
            {
                // 受注残
                strQuery = "SELECT a.受注年月日 AS 受注日";
                strQuery += "      ,a.納期";
                strQuery += "      ,dbo.f_getメーカー名(a.メーカーコード) AS メーカー";
                strQuery += "      ,dbo.f_get中分類名(a.大分類コード, a.中分類コード)";
                strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ１, '')) AS 品名";
                strQuery += "      ,a.受注数量 AS 受注数";
                strQuery += "      ,(a.受注数量 - a.売上済数量) AS 受注残";
                strQuery += "      ,(b.発注数量 - b.仕入済数量) AS 発注残";
                strQuery += "      ,a.受注単価 AS 売上単価";
                strQuery += "      ,ROUND(((a.受注数量 - a.売上済数量 ) * a.受注単価), 0, 1) AS 売上金額";
                strQuery += "      ,a.仕入単価 AS 仕入単価";
                strQuery += "      ,ROUND(((a.受注数量 - a.売上済数量 ) * a.仕入単価), 0, 1) AS 仕入金額";
                strQuery += "      ,a.注番";
                strQuery += "      ,'' AS 仕入合計金額";
                strQuery += "      ,'' AS 客先注番";
                strQuery += "      ,a.得意先名称 AS 得意先名";
                strQuery += "      ,dbo.f_get発注番号から仕入日(dbo.f_get受注番号から発注番号(a.受注番号, a.商品コード)) AS 仕入日";
                strQuery += "      ,b.仕入先名称 AS 仕入先名";
                strQuery += "      ,a.売上済数量 AS 売上済";
                strQuery += "      ,b.仕入済数量 AS 仕入済";
                strQuery += "      ,b.発注年月日 AS 発注日";
                strQuery += "      ,dbo.f_get受注番号_発注状態(a.受注番号) AS 状態";
                strQuery += "      ,a.受注番号";
                strQuery += "      ,dbo.f_get担当者名(a.受注者コード) AS 受注者";
                strQuery += "      ,dbo.f_get担当者名(a.担当者コード) AS 担当者";
                strQuery += "      ,dbo.f_get担当者名(b.発注者コード) AS 発注者";
                strQuery += "  FROM 受注 a LEFT OUTER JOIN 発注 b ON a.受注番号 = b.受注番号";
                strQuery += " WHERE a.削除 = 'N'";
                strQuery += "   AND ((a.売上済数量 = 0) OR (a.売上済数量 < a.受注数量))";
                strQuery += "   AND b.削除 = 'N'";
                strQuery += "   AND b.発注数量 <> 0";
                strQuery += "   AND b.発注番号 = dbo.f_get受注番号から最終仕入の発注番号(a.受注番号)";

                if (!StringUtl.blIsEmpty(listParam[0]))
                {
                    strQuery += "   AND a.受注番号 = '" + listParam[0] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[20]))
                {
                    strQuery += "   AND a.大分類コード = '" + listParam[20] + "'";
                }
                if (!StringUtl.blIsEmpty(listParam[21]))
                {
                    strQuery += "   AND a.中分類コード = '" + listParam[21] + "'";
                }
                if (!StringUtl.blIsEmpty(listParam[22]))
                {
                    strQuery += "   AND a.メーカーコード = '" + listParam[22] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[18]))
                {
                    strQuery += "   AND a.得意先コード = '" + listParam[18] + "'";
                }
                if (!StringUtl.blIsEmpty(listParam[15]))
                {
                    strQuery += "   AND a.受注者コード = '" + listParam[15] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[17]))
                {
                    strQuery += "   AND dbo.f_get取引先マスタ担当者(a.得意先コード) = '" + listParam[17] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[11]))
                {
                    strQuery += "   AND a.受注年月日 >= '" + listParam[11] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[12]))
                {
                    strQuery += "   AND a.受注年月日 <= '" + listParam[12] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[5]))
                {
                    strQuery += "   AND a.納期 >= '" + listParam[5] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[6]))
                {
                    strQuery += "   AND a.納期 <= '" + listParam[6] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[2]))
                {
                    strQuery += "   AND (dbo.f_get中分類名(a.大分類コード, a.中分類コード)  +  REPLACE(ISNULL(a.Ｃ１, ''), ' ', '' ) ";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ２, ''), ' ', '' )";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ３, ''), ' ', '' )";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ４, ''), ' ', '' )";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ５, ''), ' ', '' )";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ６, ''), ' ', '' )) LIKE '%" + listParam[2].Replace(" ", "") + "%' ";
                }

                if (!StringUtl.blIsEmpty(listParam[3]))
                {
                    strQuery += "   AND a.注番 LIKE '%" + listParam[3] + "%'";
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

                if (!StringUtl.blIsEmpty(listParam[26]))
                {
                    int intGroup = int.Parse(listParam[26]);
                    if (intGroup != CommonTeisu.GROUP_RADIO_ALL)
                    {
                        strQuery += "   AND dbo.f_getグループコード(a.受注者コード) = '" + CommonTeisu.LIST_GROUP[intGroup] + "'";
                    }
                }
            }

            // 受注残・発注残共に検索する場合
            if (int.Parse(listParam[29]) == 0)
            {
                strQuery += " UNION ";
            }

            // 発注残が検索対象となる場合
            if (int.Parse(listParam[29]) == 0 || int.Parse(listParam[29]) == 2)
            {
                //発注残
                strQuery += "SELECT '' AS 受注日";
                strQuery += "      ,a.納期";
                strQuery += "      ,dbo.f_getメーカー名(a.メーカーコード) AS メーカー";
                strQuery += "      ,dbo.f_get中分類名(a.大分類コード, a.中分類コード)";
                strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ１, ''))";
                strQuery += "      ,'' AS 受注数";
                strQuery += "      ,'' AS 受注残";
                strQuery += "      ,(a.発注数量 - a.仕入済数量) AS 発注残";
                strQuery += "      ,'' AS 売上単価";
                strQuery += "      ,'' AS 売上金額";
                strQuery += "      ,'' AS 仕入単価";
                strQuery += "      ,'' AS 仕入金額";
                strQuery += "      ,a.注番";
                strQuery += "      ,'' AS 仕入合計金額";
                strQuery += "      ,'' AS 客先注番";
                strQuery += "      ,'' AS 得意先名";
                strQuery += "      ,'' AS 仕入日";
                strQuery += "      ,a.仕入先名称 AS 仕入先名";
                strQuery += "      ,'' AS 売上済";
                strQuery += "      ,a.仕入済数量 AS 仕入済";
                strQuery += "      ,a.発注年月日 AS 発注日";
                strQuery += "      ,dbo.f_get受注番号_発注状態(a.受注番号) AS 状態";
                strQuery += "      ,a.受注番号";
                strQuery += "      ,'' AS 受注者";
                strQuery += "      ,dbo.f_get担当者名(a.担当者コード) AS 担当者";
                strQuery += "      ,dbo.f_get担当者名(a.発注者コード) AS 発注者";

                strQuery += "  FROM 発注 a";

                strQuery += " WHERE a.削除 = 'N'";
                strQuery += "   AND a.発注数量 <> 0 ";
                strQuery += "   AND ((a.仕入済数量 = 0) OR (abs(a.仕入済数量) < abs(a.発注数量))) ";
                strQuery += "   AND a.仕入先コード <> '7777'";
                strQuery += "   AND a.仕入先コード <> '9999'";

                if (!StringUtl.blIsEmpty(listParam[1]))
                {
                    strQuery += "   AND a.発注番号 = '" + listParam[1] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[20]))
                {
                    strQuery += "   AND a.大分類コード = '" + listParam[20] + "'";
                }
                if (!StringUtl.blIsEmpty(listParam[21]))
                {
                    strQuery += "   AND a.中分類コード = '" + listParam[21] + "'";
                }
                if (!StringUtl.blIsEmpty(listParam[22]))
                {
                    strQuery += "   AND a.メーカーコード = '" + listParam[22] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[16]))
                {
                    strQuery += "   AND a.発注者コード = '" + listParam[16] + "'";
                }
                if (!StringUtl.blIsEmpty(listParam[19]))
                {
                    strQuery += "   AND a.仕入先コード = '" + listParam[19] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[0]))
                {
                    strQuery += "   AND a.受注番号 = '" + listParam[0] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[13]))
                {
                    strQuery += "   AND a.発注年月日 >= '" + listParam[13] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[14]))
                {
                    strQuery += "   AND a.発注年月日 <= '" + listParam[14] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[7]))
                {
                    strQuery += "   AND a.納期 >= '" + listParam[7] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[8]))
                {
                    strQuery += "   AND a.納期 <= '" + listParam[8] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[9]))
                {
                    strQuery += "   AND a.納期 >= '" + listParam[9] + "'";
                }

                if (!StringUtl.blIsEmpty(listParam[10]))
                {
                    strQuery += "   AND a.納期 <= '" + listParam[10] + "'";
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

                if (!StringUtl.blIsEmpty(listParam[2]))
                {
                    strQuery += "   AND (dbo.f_get中分類名(a.大分類コード, a.中分類コード)";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ１, ''), ' ', '')";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ２, ''), ' ', '')";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ３, ''), ' ', '')";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ３, ''), ' ', '')";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ３, ''), ' ', '')";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ６, ''), ' ', '')) LIKE '%" + listParam[2].Replace(" ", "") + "%' ";
                }

                if (!StringUtl.blIsEmpty(listParam[3]))
                {
                    strQuery += "   AND RTRIM(dbo.f_get注番文字FROM担当者(a.発注者コード)) + CAST(発注番号 AS varchar(8)) LIKE '%" + listParam[3] + "%'";
                }

                if (!StringUtl.blIsEmpty(listParam[24]))
                {
                    if (int.Parse(listParam[24]) == 1)
                    {
                        strQuery += "   AND a.加工区分 = '0'";
                    }
                    else if (int.Parse(listParam[24]) == 2)
                    {
                        strQuery += "   AND a.加工区分 = '1'";
                    }
                }

                if (!StringUtl.blIsEmpty(listParam[26]))
                {
                    int intGroup = int.Parse(listParam[26]);
                    if (intGroup != CommonTeisu.GROUP_RADIO_ALL)
                    {
                        strQuery += "   AND dbo.f_getグループコード(a.発注者コード) = '" + CommonTeisu.LIST_GROUP[intGroup] + "'";
                    }
                }
            }

            strQuery += " ORDER BY " + listSortItem[int.Parse(listParam[27])] + listSortOrder[int.Parse(listParam[28])];

            // SQL検索実行
            try
            {
                DBConnective dbCon = new DBConnective();
                dtZanList = dbCon.ReadSql(strQuery);
            } catch (Exception ex)
            {
                throw ex;
            }

            DataTable dtRet = null;

            // 入荷済のみ表示の場合
            if (int.Parse(listParam[23]) == 1)
            {
                var drs = dtZanList.AsEnumerable()
                  .Where(x => x["状態"].ToString() == "入荷済")
                  .Select(x => x);

                if (drs != null && drs.Count() > 0)
                {
                    dtRet = drs.CopyToDataTable();
                }
            }
            // 入荷済以外のみ表示の場合
            else if (int.Parse(listParam[23]) == 2)
            {
                var drs = dtZanList.AsEnumerable()
                  .Where(x => x["状態"].ToString() != "入荷済")
                  .Select(x => x);

                if (drs != null && drs.Count() > 0)
                {
                    dtRet = drs.CopyToDataTable();
                }
            } else
            {
                dtRet = dtZanList;
            }

            return dtRet;
        }
    }
}