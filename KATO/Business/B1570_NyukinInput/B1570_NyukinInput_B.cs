using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.B1570_NyukinInput
{
    class B1570_NyukinInput_B
    {
        ///<summary>
        ///setGridTokusaiki
        ///得意先グリッドのデータ取得
        ///</summary>
        public DataTable getShiharaiList(List<string> lstItem)
        {
            string strSql = "";
            DataTable dtShiharaiCheakList = new DataTable();

            string fromfrom = DateTime.Parse(lstItem[0]).AddYears(-1).ToString("yyyy/MM/dd");

            strSql += "SELECT TOP 5000 S3.伝票年月日, ";
            strSql += "S3.行番号, ";
            strSql += "sz.締切日, ";
            strSql += "sz.得意先コード, ";
            strSql += "sz.得意先名,";
            strSql += "sz.入金予定日, ";
            strSql += "sz.入金日, ";
            strSql += "S3.伝票番号, ";
            strSql += "S3.取引区分コード, ";
            strSql += "dbo.f_get取引区分名(S3.取引区分コード) AS 取引区分名, ";
            strSql += "CASE WHEN Rtrim(ISNULL(S3.口座,'')) = '' THEN sz.口座種別 ELSE S3.口座 END AS 口座,";
            strSql += "CASE WHEN Rtrim(ISNULL(S3.金融機関名,'')) = '' THEN sz.銀行名 ELSE S3.金融機関名 END AS 金融機関名,";
            strSql += "CASE WHEN Rtrim(ISNULL(S3.支店名,'')) = '' THEN sz.支店名 ELSE S3.支店名 END AS 支店名,";
            strSql += "CONVERT(CHAR, ROUND(sz.入金予定額, 0), 126) AS 入金予定額,";
            strSql += "CONVERT(CHAR, ROUND(S3.入金額, 0), 126) AS 入金額, ";
            strSql += "S3.手形期日, ";
            strSql += "sz.支払月数,";
            strSql += "sz.支払条件,";
            strSql += "sz.集金区分,";
            strSql += "sz.消費税端数計算区分,";
            strSql += "S3.廻し先,";
            strSql += "S3.廻し先日付,";
            strSql += "sz.入金手形期日,";
            strSql += "S3.備考, ";
            strSql += "S3.額, ";
            strSql += "S3.登録日時";


            strSql += "  from";
            strSql += "       (SELECT S2.得意先コード,";
            strSql += "               S2.入金予定日,";
            strSql += "               SUM(S2.税込合計金額) AS 入金予定額,";
            strSql += "               S2.締切日, ";
            strSql += "               S2.得意先名,";
            strSql += "               S2.支払日 AS 入金日,";
            strSql += "               S2.支払月数, ";
            strSql += "               S2.支払条件, ";
            strSql += "               S2.集金区分, ";
            strSql += "               S2.銀行名,";
            strSql += "               S2.支店名,";
            strSql += "               S2.口座種別,";
            strSql += "               S2.消費税端数計算区分, ";
            strSql += "               S2.入金手形期日";
            strSql += "          FROM";
            strSql += "               (select S.得意先コード,";
            strSql += "                       CASE WHEN RIGHT(CONVERT(VARCHAR, DATEADD(month, T.支払月数, S.伝票年月日), 111), 2) <= RIGHT('00' + LTRIM(STR(T.支払日, 2)), 2)";
            strSql += "                            THEN";
            strSql += "                                CASE WHEN RIGHT('00' + LTRIM(STR(T.支払日, 2)), 2) > RIGHT(CONVERT(VARCHAR, dbo.f_月末日(DATEADD(month, T.支払月数, S.伝票年月日)), 111), 2)";
            strSql += "                                     THEN dbo.f_月末日(DATEADD(month, T.支払月数, S.伝票年月日))";
            strSql += "                                     ELSE LEFT(CONVERT(CHAR, DATEADD(month, T.支払月数, S.伝票年月日), 111), 8) + RIGHT('00' + LTRIM(STR(T.支払日, 2)), 2)";
            strSql += "                                END";
            strSql += "                            ELSE";
            strSql += "                                CASE WHEN RIGHT('00' + LTRIM(STR(T.支払日, 2)), 2) > RIGHT(CONVERT(VARCHAR, dbo.f_月末日(DATEADD(month, T.支払月数 + 1, S.伝票年月日)), 111), 2)";
            strSql += "                                     THEN dbo.f_月末日(DATEADD(month, T.支払月数 + 1, S.伝票年月日))";
            strSql += "                                     ELSE LEFT(CONVERT(CHAR, DATEADD(month, T.支払月数 + 1, S.伝票年月日), 111), 8) + RIGHT('00' + LTRIM(STR(T.支払日, 2)), 2)";
            strSql += "                                END";
            strSql += "                            END 入金予定日,";
            strSql += "                       S.税込合計金額,";

            strSql += "                       T.締切日, ";
            strSql += "                       T.取引先名称 AS 得意先名,";
            strSql += "                       T.支払日, ";
            strSql += "                       T.支払月数 AS 支払月数,";
            strSql += "                       T.支払条件 AS 支払条件,";
            strSql += "                       T.集金区分 AS 集金区分,";
            strSql += "                       T.銀行名,";
            strSql += "                       T.支店名,";
            strSql += "                       T.口座種別,";
            strSql += "                       T.消費税端数計算区分,";
            strSql += "                       CASE WHEN Rtrim(ISNULL(T.入金手形期日,'')) = '' THEN CONVERT(CHAR, ROUND(T.支払日, 0), 126) ELSE T.入金手形期日 END AS 入金手形期日";

            strSql += "                  from 売上ヘッダ S,";
            strSql += "                       取引先 T";
            strSql += "                 where S.削除 = 'N'";
            strSql += "                   and S.伝票年月日 >= '" + fromfrom + "'";
            strSql += "                   and T.削除 = 'N'";
            strSql += "                   and S.得意先コード = T.取引先コード) AS S2";
            strSql += "         WHERE S2.入金予定日 >= '" + lstItem[0] + "'";
            strSql += "           AND S2.入金予定日 <= '" + lstItem[1] + "'";
            strSql += "         group by S2.得意先コード, S2.入金予定日, S2.得意先名, S2.締切日, S2.支払日, S2.支払月数, S2.支払条件, S2.集金区分, S2.消費税端数計算区分, S2.入金手形期日, S2.銀行名,S2.支店名, S2.口座種別) as sz";

            strSql += "  left join";
            strSql += "(SELECT Sf.入金年月日 AS 伝票年月日, ";
            strSql += "Sf.行番号, ";
            //strSql += "T.締切日, ";
            strSql += "Sf.得意先コード, ";
            //strSql += "T.取引先名称 AS 仕入先名,";
            //strSql += "Sf.手形期日 AS 支払予定日, ";
            //strSql += "T.支払日, ";
            strSql += "Sf.伝票番号, ";
            strSql += "Sf.取引区分コード, ";
            strSql += "dbo.f_get取引区分名(Sf.取引区分コード) AS 取引区分名, ";
            strSql += "ISNULL(Sf.口座,'') AS 口座,";
            strSql += "ISNULL(Sf.金融機関名,'') AS 金融機関名,";
            strSql += "ISNULL(Sf.支店名,'') AS 支店名,";
            //strSql += "CONVERT(CHAR, ROUND(Sf.支払額, 0), 126) AS 支払予定額,";
            strSql += "Sf.入金額,";
            strSql += "Sf.手形期日, ";
            //strSql += "T.支払月数 AS 支払月数,";
            //strSql += "T.支払条件 AS 支払条件,";
            //strSql += "T.集金区分 AS 集金区分,";
            //strSql += "T.消費税端数計算区分,";
            strSql += "Sf.廻し先,";
            strSql += "Sf.廻し先日付,";
            //strSql += "CASE WHEN Rtrim(ISNULL(T.仕入手形期日,'')) = '' THEN CONVERT(CHAR, ROUND(T.支払日, 0), 126) ELSE T.仕入手形期日 END AS 仕入手形期日,";
            strSql += "Sf.備考, ";
            strSql += "Sf.入金額 AS 額, ";
            strSql += "Sf.手形発行元, ";
            strSql += "Sf.登録日時 ";
            //strSql += " FROM 支払 S, 取引先 T";
            strSql += " FROM 入金 Sf";
            strSql += " WHERE Sf.削除 ='N' ";
            //strSql += "   AND T.削除 ='N' ";
            //strSql += "   AND S.仕入先コード = T.取引先コード ";

            // 入力年月日（開始）がある場合
            if (!lstItem[0].Equals(""))
            {
                strSql += " AND CONVERT(VARCHAR(10),Sf.更新日時,111) >='" + lstItem[0] + "'";
                strSql += " AND CONVERT(VARCHAR(10),Sf.更新日時,111) <='" + lstItem[1] + "'";
            }

            // 伝票年月日（開始）がある場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND Sf.入金年月日 >='" + lstItem[2] + "'";
                strSql += " AND Sf.入金年月日 <='" + lstItem[3] + "'";
            }

            // ユーザーIDがある場合
            if (!lstItem[4].Equals(""))
            {
                strSql += " AND Sf.更新ユーザー名='" + lstItem[4] + "'";
            }

            // 仕入先コードがある場合
            if (!lstItem[5].Equals("") && !lstItem[6].Equals(""))
            {
                strSql += " AND Sf.得意先コード >='" + lstItem[5] + "'";
                strSql += " AND Sf.得意先コード <='" + lstItem[6] + "'";
            }

            if (!lstItem[7].Equals(""))
            {
                strSql += " AND Sf.取引区分コード IN (" + lstItem[7] + ")";
            }

            if (!lstItem[8].Equals(""))
            {
                strSql += " AND Sf.手形期日 >='" + lstItem[8] + "'";
            }

            if (!lstItem[9].Equals(""))
            {
                strSql += " AND Sf.手形期日 <='" + lstItem[9] + "'";
            }

            if (!lstItem[12].Equals(""))
            {
                strSql += " AND Sf.金融機関名 like '%" + lstItem[12] + "%'";
            }

            if (!lstItem[13].Equals(""))
            {
                strSql += " AND Sf.支店名 like '%" + lstItem[13] + "%'";
            }

            if (!lstItem[14].Equals(""))
            {
                strSql += " AND Sf.口座 like '%" + lstItem[14] + "%'";
            }

            strSql += ") AS S3 ";
            strSql += "  on sz.得意先コード = S3.得意先コード";
            strSql += "   AND S3.伝票年月日 >= DATEADD(month, sz.支払月数 * -1, sz.入金予定日)";
            strSql += "   AND S3.伝票年月日 <= sz.入金予定日";



            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtShiharaiCheakList = dbconnective.ReadSql(strSql);

                return dtShiharaiCheakList;
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

        // 登録
        public void addShiire(List<string[]> lsInput)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                for (int cnt = 0; cnt < lsInput.Count; cnt++)
                {
                    string[] strs = lsInput[cnt];
                    // 支払消去_PROCを実行
                    dbconnective.ReadSql("入金消去2_PROC '" + strs[0] + "', '" + strs[1] + "', '" + strs[10] + "'");

                    string strProc = "入金追加2_PROC '" + strs[0] + "', '" + strs[1] + "', '" +
                        strs[2] + "', '" + strs[3] + "', '" + strs[4] + "', '" +
                        strs[5] + "', ";

                    // 支払期日がない場合
                    if (strs[6].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[6] + "', ";
                    }

                    // 備考がない場合
                    if (strs[7].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[7] + "', ";
                    }

                    if (strs[8].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[8] + "', ";
                    }

                    if (strs[9].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[9] + "', ";
                    }



                    if (strs[10].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[10] + "', ";
                    }

                    if (strs[11].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[11] + "', ";
                    }

                    if (strs[12].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[12] + "', ";
                    }

                    if (strs[13].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[13] + "', ";
                    }

                    strProc += "'" + strs[14] + "',";

                    strProc += "'" + strs[15] + "'";

                    // 支払追加_PROCを実行
                    dbconnective.ReadSql(strProc);
                }
                // コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                // ロールバック処理
                dbconnective.Rollback();
                //new CommonException(ex);
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        // 削除
        public void delShiire(string[] strs)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                dbconnective.ReadSql("入金全削除2_PROC '" + strs[0] + "', '" + strs[1] + "', '" + strs[2] + "'");
            }
            catch (Exception ex)
            {
                // ロールバック処理
                dbconnective.Rollback();
                //new CommonException(ex);
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }
        // 伝票名から伝票番号を取得
        public string getDenpyoNo()
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@テーブル名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add("支払伝票");

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
    }
}
