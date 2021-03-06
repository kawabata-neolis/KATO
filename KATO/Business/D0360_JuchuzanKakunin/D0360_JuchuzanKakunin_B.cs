﻿using System;
using System.Data;
using System.Linq;
using KATO.Common.Util;
using System.Collections.Generic;
using ClosedXML.Excel;

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
        public DataTable getZanList(string[] listParam, bool flg)
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
            //if (int.Parse(listParam[29]) == 0 || int.Parse(listParam[29]) == 1)
            if (int.Parse(listParam[29]) == 0)
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
                strQuery += "      ,ROUND(a.受注単価, 0, 1) AS 売上単価";
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

                strQuery += "      ,dbo.f_get営業所名(dbo.f_get営業所コードFROM担当者(a.受注者コード)) AS 受注営業所";
                strQuery += "      ,dbo.f_get営業所名(dbo.f_get営業所コードFROM担当者(b.発注者コード)) AS 発注営業所";
                strQuery += "      ,CASE WHEN 差戻.承認フラグ = -1 THEN '戻' WHEN 差戻.承認フラグ = 0 THEN '申' WHEN 差戻.承認フラグ = 1 THEN '承' ELSE '' END AS 差戻";
                strQuery += "      ,CASE WHEN 値引.承認フラグ = -1 THEN '戻' WHEN 値引.承認フラグ = 0 THEN '申' WHEN 値引.承認フラグ = 1 THEN '承' ELSE '' END AS 値引";

                strQuery += "  FROM 受注 a LEFT OUTER JOIN 発注 b ON a.受注番号 = b.受注番号";

                strQuery += "   AND b.削除 = 'N'";
                strQuery += "   AND b.発注数量 <> 0";
                strQuery += "   AND b.発注番号 = dbo.f_get受注番号から最終仕入の発注番号(a.受注番号)";
                strQuery += "              LEFT OUTER JOIN 利益率承認 差戻 ON a.受注番号 = 差戻.受注番号";
                strQuery += "              LEFT OUTER JOIN 返品値引売上承認 値引 ON a.受注番号 = 値引.受注番号";

                strQuery += " WHERE a.削除 = 'N'";
                strQuery += "   AND ((a.売上済数量 = 0) OR (a.売上済数量 < a.受注数量))";
                //strQuery += "   AND b.削除 = 'N'";
                //strQuery += "   AND b.発注数量 <> 0";
                //strQuery += "   AND b.発注番号 = dbo.f_get受注番号から最終仕入の発注番号(a.受注番号)";

                if (!string.IsNullOrWhiteSpace(listParam[0]))
                {
                    strQuery += "   AND a.受注番号 = '" + listParam[0] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[20]))
                {
                    strQuery += "   AND a.大分類コード = '" + listParam[20] + "'";
                }
                if (!string.IsNullOrWhiteSpace(listParam[21]))
                {
                    strQuery += "   AND a.中分類コード = '" + listParam[21] + "'";
                }
                if (!string.IsNullOrWhiteSpace(listParam[22]))
                {
                    strQuery += "   AND a.メーカーコード = '" + listParam[22] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[18]))
                {
                    strQuery += "   AND a.得意先コード = '" + listParam[18] + "'";
                }
                if (!string.IsNullOrWhiteSpace(listParam[19]))
                {
                    strQuery += "   AND b.仕入先コード = '" + listParam[19] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[15]))
                {
                    strQuery += "   AND a.受注者コード = '" + listParam[15] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[17]))
                {
                    strQuery += "   AND dbo.f_get取引先マスタ担当者(a.得意先コード) = '" + listParam[17] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[11]))
                {
                    strQuery += "   AND a.受注年月日 >= '" + listParam[11] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[12]))
                {
                    strQuery += "   AND a.受注年月日 <= '" + listParam[12] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[5]))
                {
                    strQuery += "   AND a.納期 >= '" + listParam[5] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[6]))
                {
                    strQuery += "   AND a.納期 <= '" + listParam[6] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[2]))
                {
                    strQuery += "   AND (REPLACE(ISNULL(dbo.f_get中分類名(a.大分類コード, a.中分類コード), ''), ' ', '')  +  REPLACE(ISNULL(a.Ｃ１, ''), ' ', '' ) ";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ２, ''), ' ', '' )";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ３, ''), ' ', '' )";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ４, ''), ' ', '' )";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ５, ''), ' ', '' )";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ６, ''), ' ', '' )) LIKE '%" + listParam[2].Replace(" ", "") + "%' ";
                }

                if (!string.IsNullOrWhiteSpace(listParam[3]))
                {
                    strQuery += "   AND a.注番 LIKE '%" + listParam[3] + "%'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[25]))
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

                if (!string.IsNullOrWhiteSpace(listParam[24]))
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

                if (!string.IsNullOrWhiteSpace(listParam[26]))
                {
                    int intGroup = int.Parse(listParam[26]);
                    if (intGroup != CommonTeisu.GROUP_RADIO_ALL)
                    {
                        strQuery += "   AND dbo.f_getグループコード(a.受注者コード) = '" + CommonTeisu.LIST_GROUP[intGroup] + "'";
                    }
                }
            }

            // 受注残・発注残共に検索する場合
            //if (int.Parse(listParam[29]) == 0)
            //{
            //    strQuery += " UNION ";
            //}

            // 発注残が検索対象となる場合
            //if (int.Parse(listParam[29]) == 0 || int.Parse(listParam[29]) == 2)
            if (int.Parse(listParam[29]) == 1)
            {
                //発注残
                //strQuery += "SELECT '' AS 受注日";
                //strQuery = "SELECT '' AS 受注日";
                //strQuery += "      ,a.納期";
                //strQuery += "      ,dbo.f_getメーカー名(a.メーカーコード) AS メーカー";
                //strQuery += "      ,dbo.f_get中分類名(a.大分類コード, a.中分類コード)";
                //strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ１, '')) AS 品名";
                //strQuery += "      ,'' AS 受注数";
                //strQuery += "      ,'' AS 受注残";
                //strQuery += "      ,(a.発注数量 - a.仕入済数量) AS 発注残";
                //strQuery += "      ,'' AS 売上単価";
                //strQuery += "      ,'' AS 売上金額";
                //strQuery += "      ,'' AS 仕入単価";
                //strQuery += "      ,'' AS 仕入金額";
                //strQuery += "      ,a.注番";
                //strQuery += "      ,'' AS 仕入合計金額";
                //strQuery += "      ,'' AS 客先注番";
                //strQuery += "      ,'' AS 得意先名";
                //strQuery += "      ,'' AS 仕入日";
                //strQuery += "      ,a.仕入先名称 AS 仕入先名";
                //strQuery += "      ,'' AS 売上済";
                //strQuery += "      ,a.仕入済数量 AS 仕入済";
                //strQuery += "      ,a.発注年月日 AS 発注日";
                //strQuery += "      ,dbo.f_get受注番号_発注状態(a.受注番号) AS 状態";
                //strQuery += "      ,a.受注番号";
                //strQuery += "      ,'' AS 受注者";
                //strQuery += "      ,dbo.f_get担当者名(a.担当者コード) AS 担当者";
                //strQuery += "      ,dbo.f_get担当者名(a.発注者コード) AS 発注者";
                //strQuery += "      ,a.発注番号";

                //strQuery += "  FROM 発注 a";

                strQuery = "SELECT b.受注年月日 AS 受注日";
                strQuery += "      ,a.納期";
                //strQuery += "      ,dbo.f_getメーカー名(a.メーカーコード) AS メーカー";
                strQuery += "      ,f.メーカー名 AS メーカー";
                strQuery += "      ,dbo.f_get中分類名(a.大分類コード, a.中分類コード)";
                strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ１, '')) AS 品名";
                strQuery += "      ,b.受注数量 AS 受注数";
                strQuery += "      ,(b.受注数量 - b.売上済数量) AS 受注残";
                strQuery += "      ,(a.発注数量 - a.仕入済数量) AS 発注残";
                strQuery += "      ,ROUND(b.受注単価, 0, 1) AS 売上単価";
                strQuery += "      ,ROUND(((b.受注数量 - b.売上済数量 ) * b.受注単価), 0, 1) AS 売上金額";
                strQuery += "      ,a.発注単価 AS 仕入単価";
                //strQuery += "      ,ROUND(((b.受注数量 - b.売上済数量 ) * b.仕入単価), 0, 1) AS 仕入金額";
                //strQuery += "      ,a.発注金額 AS 仕入金額";
                strQuery += "      ,ROUND(((a.発注数量 - a.仕入済数量 ) * a.発注単価), 0, 1) AS 仕入金額";
                strQuery += "      ,a.注番";
                strQuery += "      ,'' AS 仕入合計金額";
                //strQuery += "      ,'' AS 客先注番";
                strQuery += "      ,RTRIM(dbo.f_get注番文字FROM担当者 (a.発注者コード)) + CAST(a.発注番号 AS varchar(8)) AS 客先注番";
                strQuery += "      ,b.得意先名称 AS 得意先名";
                strQuery += "      ,dbo.f_get発注番号から仕入日(a.発注番号) AS 仕入日";
                //strQuery += "      ,'' AS 仕入日";
                strQuery += "      ,a.仕入先名称 AS 仕入先名";
                strQuery += "      ,b.売上済数量 AS 売上済";
                strQuery += "      ,a.仕入済数量 AS 仕入済";
                strQuery += "      ,a.発注年月日 AS 発注日";
                //strQuery += "      ,dbo.f_get受注番号_発注状態(b.受注番号) AS 状態";
                //strQuery += "      ,CASE WHEN b.受注番号 IS NULL THEN '' ELSE dbo.f_get受注番号_発注状態(b.受注番号) END AS 状態";
                if (flg)
                {
                    strQuery += "  ,'' AS 状態";
                }
                else
                {
                    strQuery += "  ,CASE WHEN b.受注番号 IS NULL THEN '' ELSE dbo.f_get受注番号_発注状態(b.受注番号) END AS 状態";
                }
                
                strQuery += "      ,b.受注番号";
                //strQuery += "      ,dbo.f_get担当者名(b.受注者コード) AS 受注者";
                //strQuery += "      ,dbo.f_get担当者名(a.担当者コード) AS 担当者";
                //strQuery += "      ,dbo.f_get担当者名(a.発注者コード) AS 発注者";
                strQuery += "      ,c.担当者名 AS 受注者";
                strQuery += "      ,d.担当者名 AS 担当者";
                strQuery += "      ,e.担当者名 AS 発注者";
                strQuery += "      ,a.発注番号";
                strQuery += "      ,dbo.f_get営業所名(dbo.f_get営業所コードFROM担当者(b.受注者コード)) AS 受注営業所";
                strQuery += "      ,dbo.f_get営業所名(dbo.f_get営業所コードFROM担当者(a.発注者コード)) AS 発注営業所";
                strQuery += "      ,CASE WHEN 差戻.承認フラグ = -1 THEN '戻' WHEN 差戻.承認フラグ = 0 THEN '申' WHEN 差戻.承認フラグ = 1 THEN '承' ELSE '' END AS 差戻";
                strQuery += "      ,CASE WHEN 値引.承認フラグ = -1 THEN '戻' WHEN 値引.承認フラグ = 0 THEN '申' WHEN 値引.承認フラグ = 1 THEN '承' ELSE '' END AS 値引";
                strQuery += "  FROM 発注 a LEFT OUTER JOIN 受注 b ON a.受注番号 = b.受注番号 AND b.削除 = 'N'";
                strQuery += "              LEFT OUTER JOIN 担当者 c ON b.受注者コード = c.担当者コード AND c.削除 = 'N'";
                strQuery += "              LEFT OUTER JOIN 担当者 d ON a.担当者コード = d.担当者コード AND d.削除 = 'N'";
                strQuery += "              LEFT OUTER JOIN 担当者 e ON a.発注者コード = e.担当者コード AND e.削除 = 'N'";
                strQuery += "              LEFT OUTER JOIN メーカー f ON a.メーカーコード = f.メーカーコード AND f.削除 = 'N'";
                strQuery += "              LEFT OUTER JOIN 利益率承認 差戻 ON a.受注番号 = 差戻.受注番号";
                strQuery += "              LEFT OUTER JOIN 返品値引売上承認 値引 ON a.受注番号 = 値引.受注番号";

                //strQuery += "   AND a.発注番号 = dbo.f_get受注番号から最終仕入の発注番号(b.受注番号)";

                strQuery += " WHERE a.削除 = 'N'";
                strQuery += "   AND a.発注数量 <> 0 ";
                strQuery += "   AND ((a.仕入済数量 = 0) OR (abs(a.仕入済数量) < abs(a.発注数量))) ";
                //strQuery += "   AND a.仕入先コード <> '7777'";
                //strQuery += "   AND a.仕入先コード <> '9999'";
                strQuery += "   AND a.仕入先コード NOT IN ('7777', '9999')";

                if (!string.IsNullOrWhiteSpace(listParam[1]))
                {
                    strQuery += "   AND a.発注番号 = '" + listParam[1] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[20]))
                {
                    strQuery += "   AND a.大分類コード = '" + listParam[20] + "'";
                }
                if (!string.IsNullOrWhiteSpace(listParam[21]))
                {
                    strQuery += "   AND a.中分類コード = '" + listParam[21] + "'";
                }
                if (!string.IsNullOrWhiteSpace(listParam[22]))
                {
                    strQuery += "   AND a.メーカーコード = '" + listParam[22] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[16]))
                {
                    strQuery += "   AND a.発注者コード = '" + listParam[16] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[19]))
                {
                    strQuery += "   AND a.仕入先コード = '" + listParam[19] + "'";
                }
                if (!string.IsNullOrWhiteSpace(listParam[18]))
                {
                    strQuery += "   AND b.得意先コード = '" + listParam[18] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[0]))
                {
                    strQuery += "   AND a.受注番号 = '" + listParam[0] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[13]))
                {
                    strQuery += "   AND a.発注年月日 >= '" + listParam[13] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[14]))
                {
                    strQuery += "   AND a.発注年月日 <= '" + listParam[14] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[7]))
                {
                    strQuery += "   AND a.納期 >= '" + listParam[7] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[8]))
                {
                    strQuery += "   AND a.納期 <= '" + listParam[8] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[9]))
                {
                    strQuery += "   AND a.納期 >= '" + listParam[9] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[10]))
                {
                    strQuery += "   AND a.納期 <= '" + listParam[10] + "'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[25]))
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

                if (!string.IsNullOrWhiteSpace(listParam[2]))
                {
                    strQuery += "   AND (dbo.f_get中分類名(a.大分類コード, a.中分類コード)";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ１, ''), ' ', '')";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ２, ''), ' ', '')";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ３, ''), ' ', '')";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ３, ''), ' ', '')";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ３, ''), ' ', '')";
                    strQuery += "       +  REPLACE(ISNULL(a.Ｃ６, ''), ' ', '')) LIKE '%" + listParam[2].Replace(" ", "") + "%' ";
                }

                if (!string.IsNullOrWhiteSpace(listParam[3]))
                {
                    strQuery += "   AND RTRIM(dbo.f_get注番文字FROM担当者(a.発注者コード)) + CAST(発注番号 AS varchar(8)) LIKE '%" + listParam[3] + "%'";
                }

                if (!string.IsNullOrWhiteSpace(listParam[24]))
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

                if (!string.IsNullOrWhiteSpace(listParam[26]))
                {
                    int intGroup = int.Parse(listParam[26]);
                    if (intGroup != CommonTeisu.GROUP_RADIO_ALL)
                    {
                        strQuery += "   AND dbo.f_getグループコード(a.発注者コード) = '" + CommonTeisu.LIST_GROUP[intGroup] + "'";
                    }
                }
            }
            //string s = listSortItem[int.Parse(listParam[27])] + listSortOrder[int.Parse(listParam[28])];
            //strQuery += " ORDER BY " + listSortItem[int.Parse(listParam[27])] + listSortOrder[int.Parse(listParam[28])];

            string stDay = "受注日";
            if (int.Parse(listParam[29]) == 1)
            {
                stDay = "発注日";
            }

            string stOrder = listSortOrder[int.Parse(listParam[28])];

            if (int.Parse(listParam[27]) == 0)
            {
                strQuery += " ORDER BY 受注日" + stOrder + ", a.納期 ASC, a.注番 ASC";
            }
            else if (int.Parse(listParam[27]) == 1)
            {
                strQuery += " ORDER BY 発注日" + stOrder + ", a.納期 ASC, a.注番 ASC";
            }
            else if (int.Parse(listParam[27]) == 2)
            {
                strQuery += " ORDER BY a.納期" + stOrder + ", " + stDay + " ASC, a.注番 ASC";
            }
            else if (int.Parse(listParam[27]) == 3)
            {
                strQuery += " ORDER BY a.注番" + stOrder + ", a.納期 ASC, " + stDay + " ASC";
            }

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

            if (!string.IsNullOrWhiteSpace(listParam[30]))
            {
                var drs = dtZanList.AsEnumerable();
                if (listParam[31].Equals("1"))
                {
                    drs = drs
                      .OrderBy(row => row[listParam[30]]);
                }
                else
                {
                    drs = drs
                      .OrderByDescending(row => row[listParam[30]]);
                }

                if (drs != null && drs.Count() > 0)
                {
                    dtZanList = drs.CopyToDataTable();
                }
            }

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

        /// <summary>
        /// getKakoList
        /// 加工原価の取得
        /// </summary>
        public DataTable getKakoList(string strJuchuNo)
        {
            DataTable dtZanList = null;

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQLSelect = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQLSelect.Add("D0360_JuchuzanKakunin");
            lstSQLSelect.Add("D0360_JuchuzanKakunin_Kako_SELECT");

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQLSelect);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return(dtZanList);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strJuchuNo);

                //SQL接続後、該当データを取得
                dtZanList = dbconnective.ReadSql(strSQLInput);

                //データ分ループ
                for (int intCnt = 0; intCnt < dtZanList.Rows.Count; intCnt++)
                {
                    //数量が空の場合
                    if (Common.Util.StringUtl.blIsEmpty(dtZanList.Rows[intCnt]["数量"].ToString()) == false)
                    {
                        dtZanList.Rows[intCnt]["数量"] = "0";
                    }
                    //単価が空の場合
                    if (Common.Util.StringUtl.blIsEmpty(dtZanList.Rows[intCnt]["単価"].ToString()) == false)
                    {
                        dtZanList.Rows[intCnt]["単価"] = "0";
                    }
                    //仕入数量が空の場合
                    if (Common.Util.StringUtl.blIsEmpty(dtZanList.Rows[intCnt]["仕入数量"].ToString()) == false)
                    {
                        dtZanList.Rows[intCnt]["仕入数量"] = "0";
                    }
                }

                return (dtZanList);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }



        /// <summary>
        /// getZanList
        /// 受注残/発注残一覧取得
        /// </summary>
        public DataTable getZanListP(string[] listParam, bool flg)
        {
            DataTable dtZanList = null;
            string strQuery = "";
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
            // 受注残
            strQuery = "SELECT a.受注年月日 AS 受注日";
            strQuery += "      ,a.納期";
            strQuery += "      ,dbo.f_getメーカー名(a.メーカーコード) AS メーカー";
            strQuery += "      ,dbo.f_get中分類名(a.大分類コード, a.中分類コード)";
            strQuery += "          + ' ' + Rtrim(ISNULL(a.Ｃ１, '')) AS 品名";
            strQuery += "      ,a.受注数量 AS 受注数";
            strQuery += "      ,(a.受注数量 - a.売上済数量) AS 受注残";
            //strQuery += "      ,(b.発注数量 - b.仕入済数量) AS 発注残";
            strQuery += "      ,ROUND(a.受注単価, 0, 1) AS 売上単価";
            strQuery += "      ,ROUND(((a.受注数量 - a.売上済数量 ) * a.受注単価), 0, 1) AS 売上金額";
            strQuery += "      ,a.仕入単価 AS 仕入単価";
            strQuery += "      ,ROUND(((a.受注数量 - a.売上済数量 ) * a.仕入単価), 0, 1) AS 仕入金額";
            strQuery += "      ,a.注番";
            //strQuery += "      ,'' AS 仕入合計金額";
            //strQuery += "      ,'' AS 客先注番";
            strQuery += "      ,a.得意先名称 AS 得意先名";
            strQuery += "      ,dbo.f_get発注番号から仕入日(dbo.f_get受注番号から発注番号(a.受注番号, a.商品コード)) AS 仕入日";
            //strQuery += "      ,b.仕入先名称 AS 仕入先名";
            strQuery += "      ,dbo.f_get受注番号から最終に発注した仕入先名称(a.受注番号) AS 仕入先名";
            strQuery += "      ,a.売上済数量 AS 売上済";
            //strQuery += "      ,b.仕入済数量 AS 仕入済";
            //strQuery += "      ,b.発注年月日 AS 発注日";
            strQuery += "      ,dbo.f_get受注番号_発注状態(a.受注番号) AS 状態";
            strQuery += "      ,a.受注番号";
            strQuery += "      ,dbo.f_get担当者名(a.受注者コード) AS 受注者";
            strQuery += "      ,dbo.f_get担当者名(a.担当者コード) AS 担当者";
            //strQuery += "      ,dbo.f_get担当者名(b.発注者コード) AS 発注者";
            //strQuery += "  FROM 受注 a JOIN 発注 b ON a.受注番号 = b.受注番号";
            strQuery += "  FROM 受注 a";

            //strQuery += "   AND b.削除 = 'N'";
            //strQuery += "   AND b.発注数量 <> 0";
            //strQuery += "   AND b.発注番号 = dbo.f_get受注番号から最終仕入の発注番号(a.受注番号)";

            strQuery += " WHERE a.削除 = 'N'";
            strQuery += "   AND ((a.売上済数量 = 0) OR (a.売上済数量 < a.受注数量))";

            #region
            if (!string.IsNullOrWhiteSpace(listParam[0]))
            {
                strQuery += "   AND a.受注番号 = '" + listParam[0] + "'";
            }

            if (!string.IsNullOrWhiteSpace(listParam[20]))
            {
                strQuery += "   AND a.大分類コード = '" + listParam[20] + "'";
            }
            if (!string.IsNullOrWhiteSpace(listParam[21]))
            {
                strQuery += "   AND a.中分類コード = '" + listParam[21] + "'";
            }
            if (!string.IsNullOrWhiteSpace(listParam[22]))
            {
                strQuery += "   AND a.メーカーコード = '" + listParam[22] + "'";
            }

            if (!string.IsNullOrWhiteSpace(listParam[18]))
            {
                strQuery += "   AND a.得意先コード = '" + listParam[18] + "'";
            }
            //if (!string.IsNullOrWhiteSpace(listParam[19]))
            //{
            //    strQuery += "   AND b.仕入先コード = '" + listParam[19] + "'";
            //}

            if (!string.IsNullOrWhiteSpace(listParam[15]))
            {
                strQuery += "   AND a.受注者コード = '" + listParam[15] + "'";
            }

            if (!string.IsNullOrWhiteSpace(listParam[17]))
            {
                strQuery += "   AND dbo.f_get取引先マスタ担当者(a.得意先コード) = '" + listParam[17] + "'";
            }

            if (!string.IsNullOrWhiteSpace(listParam[11]))
            {
                strQuery += "   AND a.受注年月日 >= '" + listParam[11] + "'";
            }

            if (!string.IsNullOrWhiteSpace(listParam[12]))
            {
                strQuery += "   AND a.受注年月日 <= '" + listParam[12] + "'";
            }

            if (!string.IsNullOrWhiteSpace(listParam[5]))
            {
                strQuery += "   AND a.納期 >= '" + listParam[5] + "'";
            }

            if (!string.IsNullOrWhiteSpace(listParam[6]))
            {
                strQuery += "   AND a.納期 <= '" + listParam[6] + "'";
            }

            if (!string.IsNullOrWhiteSpace(listParam[2]))
            {
                strQuery += "   AND (REPLACE(ISNULL(dbo.f_get中分類名(a.大分類コード, a.中分類コード), ''), ' ', '')  +  REPLACE(ISNULL(a.Ｃ１, ''), ' ', '' ) ";
                strQuery += "       +  REPLACE(ISNULL(a.Ｃ２, ''), ' ', '' )";
                strQuery += "       +  REPLACE(ISNULL(a.Ｃ３, ''), ' ', '' )";
                strQuery += "       +  REPLACE(ISNULL(a.Ｃ４, ''), ' ', '' )";
                strQuery += "       +  REPLACE(ISNULL(a.Ｃ５, ''), ' ', '' )";
                strQuery += "       +  REPLACE(ISNULL(a.Ｃ６, ''), ' ', '' )) LIKE '%" + listParam[2].Replace(" ", "") + "%' ";
            }

            if (!string.IsNullOrWhiteSpace(listParam[3]))
            {
                strQuery += "   AND a.注番 LIKE '%" + listParam[3] + "%'";
            }

            if (!string.IsNullOrWhiteSpace(listParam[25]))
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

            if (!string.IsNullOrWhiteSpace(listParam[24]))
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

            if (!string.IsNullOrWhiteSpace(listParam[26]))
            {
                int intGroup = int.Parse(listParam[26]);
                if (intGroup != CommonTeisu.GROUP_RADIO_ALL)
                {
                    strQuery += "   AND dbo.f_getグループコード(a.受注者コード) = '" + CommonTeisu.LIST_GROUP[intGroup] + "'";
                }
            }

            string stDay = "受注日";
            string stOrder = listSortOrder[int.Parse(listParam[28])];

            if (int.Parse(listParam[27]) == 0)
            {
                strQuery += " ORDER BY 受注日" + stOrder + ", a.納期 ASC, a.注番 ASC";
            }
            else if (int.Parse(listParam[27]) == 1)
            {
                strQuery += " ORDER BY 発注日" + stOrder + ", a.納期 ASC, a.注番 ASC";
            }
            else if (int.Parse(listParam[27]) == 2)
            {
                strQuery += " ORDER BY a.納期" + stOrder + ", " + stDay + " ASC, a.注番 ASC";
            }
            else if (int.Parse(listParam[27]) == 3)
            {
                strQuery += " ORDER BY a.注番" + stOrder + ", a.納期 ASC, " + stDay + " ASC";
            }
            #endregion

            // SQL検索実行
            #region
            try
            {
                DBConnective dbCon = new DBConnective();
                dtZanList = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
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
            }
            else
            {
                dtRet = dtZanList;
            }
            #endregion

            return dtRet;
        }

        public string printReport(DataTable dt, string stJuchusha, string stTokui, string stFrom,
            string stTo, string stKata, string stChuban, int sKind)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/D0360_JuchuzanKakunin.xlsx";
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                // excelのインスタンス生成
                #region
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);
                IXLWorksheet templatesheet1 = workbook.Worksheet(1);   // テンプレートシート
                IXLWorksheet currentsheet = null;  // 処理中シート

                int pageCnt = 0;    // ページ(シート枚数)カウント
                int xlsRowCnt = 7;  // Excel出力行カウント（開始は出力行）

                templatesheet1.CopyTo("Page" + pageCnt.ToString());
                currentsheet = workbook.Worksheet(workbook.Worksheets.Count);
                #endregion

                // 4行目記載文字列作成
                #region
                string sPrm = "受注者：";
                if (sKind == 1)
                {
                    sPrm = "発注者：";
                }

                if (!string.IsNullOrWhiteSpace(stJuchusha))
                {
                    sPrm += stJuchusha;
                }
                if (sKind == 1)
                {
                    sPrm += " 仕入先：";
                }
                else
                {
                    sPrm += " 得意先：";
                }

                if (!string.IsNullOrWhiteSpace(stTokui))
                {
                    sPrm += stTokui;
                }
                sPrm += " 納期範囲：";

                if (!string.IsNullOrWhiteSpace(stFrom))
                {
                    sPrm += stFrom;
                }
                sPrm += "～";

                if (!string.IsNullOrWhiteSpace(stTo))
                {
                    sPrm += stTo;
                }
                sPrm += " 品名・型番：";

                if (!string.IsNullOrWhiteSpace(stKata))
                {
                    sPrm += stKata;
                }
                sPrm += " 注番：";

                if (!string.IsNullOrWhiteSpace(stKata))
                {
                    sPrm += stChuban;
                }
                #endregion

                currentsheet.Cell(4, "A").Value = sPrm;

                if (sKind == 1)
                {
                    currentsheet.Cell(6, "A").Value = "発注日";
                    currentsheet.Cell(6, "K").Value = "仕入済";
                }

                // ClosedXMLで1行ずつExcelに出力
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (xlsRowCnt >= 67)
                    {
                        pageCnt++;
                        xlsRowCnt = 7;

                        // テンプレートシートからコピー
                        templatesheet1.CopyTo("Page" + pageCnt.ToString());
                        currentsheet = workbook.Worksheet(workbook.Worksheets.Count);
                        currentsheet.Cell(4, "A").Value = sPrm;

                        if (sKind == 1)
                        {
                            currentsheet.Cell(6, "A").Value = "発注日";
                            currentsheet.Cell(6, "K").Value = "仕入済";
                        }
                    }

                    if (sKind != 1) {
                        currentsheet.Cell(xlsRowCnt, "A").Value = "'" + dt.Rows[i]["受注日"].ToString().Substring(2, 8);
                        currentsheet.Cell(xlsRowCnt, "B").Value = "'" + dt.Rows[i]["納期"].ToString().Substring(2, 8);
                        currentsheet.Cell(xlsRowCnt, "C").Value = "'" + dt.Rows[i]["注番"];
                        currentsheet.Cell(xlsRowCnt, "D").Value = dt.Rows[i]["メーカー"];
                        currentsheet.Cell(xlsRowCnt, "E").Value = "'" + dt.Rows[i]["品名"];
                        currentsheet.Cell(xlsRowCnt, "F").Value = dt.Rows[i]["受注数"];
                        currentsheet.Cell(xlsRowCnt, "G").Value = dt.Rows[i]["売上単価"];
                        currentsheet.Cell(xlsRowCnt, "H").Value = dt.Rows[i]["売上金額"];
                        currentsheet.Cell(xlsRowCnt, "I").Value = dt.Rows[i]["仕入単価"];
                        currentsheet.Cell(xlsRowCnt, "J").Value = dt.Rows[i]["仕入金額"];
                        currentsheet.Cell(xlsRowCnt, "K").Value = dt.Rows[i]["売上済"];
                        currentsheet.Cell(xlsRowCnt, "L").Value = dt.Rows[i]["状態"];
                        currentsheet.Cell(xlsRowCnt, "M").Value = dt.Rows[i]["受注番号"];
                        currentsheet.Cell(xlsRowCnt, "N").Value = dt.Rows[i]["得意先名"];
                        currentsheet.Cell(xlsRowCnt + 1, "N").Value = dt.Rows[i]["仕入先名"];
                        currentsheet.Cell(xlsRowCnt, "O").Value = dt.Rows[i]["受注者"];
                    }
                    else
                    {
                        currentsheet.Cell(xlsRowCnt, "A").Value = "'" + dt.Rows[i]["発注日"].ToString().Substring(2, 8);
                        currentsheet.Cell(xlsRowCnt, "B").Value = "'" + dt.Rows[i]["納期"].ToString().Substring(2, 8);
                        currentsheet.Cell(xlsRowCnt, "C").Value = "'" + dt.Rows[i]["注番"];
                        currentsheet.Cell(xlsRowCnt, "D").Value = dt.Rows[i]["メーカー"];
                        currentsheet.Cell(xlsRowCnt, "E").Value = "'" + dt.Rows[i]["品名"];
                        currentsheet.Cell(xlsRowCnt, "F").Value = dt.Rows[i]["受注数"];
                        currentsheet.Cell(xlsRowCnt, "G").Value = dt.Rows[i]["売上単価"];
                        currentsheet.Cell(xlsRowCnt, "H").Value = dt.Rows[i]["売上金額"];
                        currentsheet.Cell(xlsRowCnt, "I").Value = dt.Rows[i]["仕入単価"];
                        currentsheet.Cell(xlsRowCnt, "J").Value = dt.Rows[i]["仕入金額"];
                        currentsheet.Cell(xlsRowCnt, "K").Value = dt.Rows[i]["仕入済"];
                        currentsheet.Cell(xlsRowCnt, "L").Value = dt.Rows[i]["状態"];
                        currentsheet.Cell(xlsRowCnt, "M").Value = dt.Rows[i]["受注番号"];
                        currentsheet.Cell(xlsRowCnt, "N").Value = dt.Rows[i]["得意先名"];
                        currentsheet.Cell(xlsRowCnt + 1, "N").Value = dt.Rows[i]["仕入先名"];
                        currentsheet.Cell(xlsRowCnt, "O").Value = dt.Rows[i]["発注者"];
                    }
                    
                    xlsRowCnt = xlsRowCnt + 2;
                }

                for (int i = xlsRowCnt; i < 67; i++)
                {
                    currentsheet.Row(xlsRowCnt).Clear();
                    currentsheet.Row(xlsRowCnt).Delete();
                }

                currentsheet.Row(xlsRowCnt).InsertRowsAbove(1);

                //currentsheet.Cell(xlsRowCnt, "A").Style.Border.SetTopBorder(XLBorderStyleValues.Thin);
                //currentsheet.Cell(xlsRowCnt, "A").Style.Border.SetLeftBorder(XLBorderStyleValues.Thin);
                //currentsheet.Cell(xlsRowCnt, "A").Style.Border.SetRightBorder(XLBorderStyleValues.Thin);
                //currentsheet.Cell(xlsRowCnt, "A").Style.Border.SetBottomBorder(XLBorderStyleValues.Thin);

                currentsheet.Cell(xlsRowCnt, "H").Value = (dt.Compute("Sum(売上金額)", null)).ToString();
                currentsheet.Cell(xlsRowCnt, "J").Value = (dt.Compute("Sum(仕入金額)", null)).ToString();

                // テンプレートシート削除
                templatesheet1.Delete();

                // ページ数設定
                for (pageCnt = 1; pageCnt <= workbook.Worksheets.Count; pageCnt++)
                {
                    string s = "'" + pageCnt.ToString() + "/" + (workbook.Worksheets.Count).ToString();
                    workbook.Worksheet(pageCnt).Cell("O1").Value = s;      // No.
                }

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // ロゴ貼り付け処理
                // PDF化の処理
                CreatePdf pdf = new CreatePdf();
                return pdf.createPdf(strOutXlsFile, strDateTime, 0);
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
