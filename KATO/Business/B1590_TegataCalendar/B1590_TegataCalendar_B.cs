using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.B1590_TegataCalendar
{
    class B1590_TegataCalendar_B
    {

        public DataTable getCalendarShiharai (string from, string to)
        {
            DataTable dt = null;
            string strSql = "";

            string fromfrom = DateTime.Parse(from).AddYears(-1).ToString("yyyy/MM/dd");

            strSql += "select CASE WHEN ISNULL(S3.支払額, '') != '' THEN '〇' ELSE '' END AS チェック,";
            strSql += "       sz.仕入先コード, sz.取引先名称 AS 仕入先名, sz.支払予定日, sz.支払予定額, S3.支払額, S3.手形期日";
            strSql += "  from";
            strSql += "       (SELECT S2.仕入先コード, S2.取引先名称, S2.支払予定日, SUM(S2.税込合計金額) AS 支払予定額";
            strSql += "          FROM";
            strSql += "               (select S.仕入先コード,";
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
            strSql += "                            END 支払予定日,";
            strSql += "                       S.税込合計金額,";
            strSql += "                       T.取引先名称";
            strSql += "                  from 仕入ヘッダ S,";
            strSql += "                       取引先 T";
            strSql += "                 where S.削除 = 'N'";
            strSql += "                   and S.伝票年月日 >= '" + fromfrom + "'";
            strSql += "                   and T.削除 = 'N'";
            strSql += "                   and S.仕入先コード = T.取引先コード) AS S2";
            strSql += "         WHERE S2.支払予定日 >= '" + from + "'";
            strSql += "           AND S2.支払予定日 <= '" + to + "'";
            strSql += "         group by S2.仕入先コード, S2.支払予定日, S2.取引先名称) as sz";
            strSql += "  left join";
            strSql += "       (select 仕入先コード, sum(支払額) as 支払額, 手形期日";
            strSql += "          from 支払 sa";
            strSql += "         where sa.削除 = 'N'";
            strSql += "           and sa.支払年月日 >= '" + from + "'";
            strSql += "           and sa.支払年月日 <= '" + to + "'";
            strSql += "         group by 仕入先コード, 手形期日) S3";
            strSql += "  on sz.仕入先コード = S3.仕入先コード";


            


            strSql += " order by sz.仕入先コード, sz.支払予定日";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dt = dbconnective.ReadSql(strSql);

                return dt;
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

        public DataTable getCalendarShiharai2(string from, string to)
        {
            DataTable dt = null;
            string strSql = "";

            string fromfrom = DateTime.Parse(from).AddYears(-1).ToString("yyyy/MM/dd");

            strSql += "select CASE WHEN ISNULL(S3.支払額, '') != '' THEN '〇' ELSE '' END AS チェック,";
            strSql += "       sz.仕入先コード, sz.取引先名称 AS 仕入先名, sz.支払予定日, sz.支払予定額, S3.支払額, S3.手形期日";
            strSql += "  from";
            strSql += "       (select 仕入先コード, sum(支払額) as 支払額, 手形期日";
            strSql += "          from 支払 sa";
            strSql += "         where sa.削除 = 'N'";
            strSql += "           and sa.手形期日 >= '" + from + "'";
            strSql += "           and sa.手形期日 <= '" + to + "'";
            strSql += "         group by 仕入先コード, 手形期日) S3";
            strSql += "  left join";
            strSql += "       (SELECT S2.仕入先コード, S2.取引先名称, S2.支払予定日, SUM(S2.税込合計金額) AS 支払予定額";
            strSql += "          FROM";
            strSql += "               (select S.仕入先コード,";
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
            strSql += "                            END 支払予定日,";
            strSql += "                       S.税込合計金額,";
            strSql += "                       T.取引先名称";
            strSql += "                  from 仕入ヘッダ S,";
            strSql += "                       取引先 T";
            strSql += "                 where S.削除 = 'N'";
            strSql += "                   and S.伝票年月日 >= '" + fromfrom + "'";
            strSql += "                   and T.削除 = 'N'";
            strSql += "                   and S.仕入先コード = T.取引先コード) AS S2";
            strSql += "         WHERE S2.支払予定日 >= '" + from + "'";
            strSql += "           AND S2.支払予定日 <= '" + to + "'";
            strSql += "         group by S2.仕入先コード, S2.支払予定日, S2.取引先名称) as sz";
            
            strSql += "  on sz.仕入先コード = S3.仕入先コード";


            strSql += " order by sz.仕入先コード, sz.支払予定日";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dt = dbconnective.ReadSql(strSql);

                return dt;
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

        public DataTable getListShiharai(string from, string to, string from2, string to2)
        {
            DataTable dt = null;
            string strSql = "";

            string fromfrom = DateTime.Parse(from).AddYears(-1).ToString("yyyy/MM/dd");

            strSql += "select CASE WHEN ISNULL(S3.支払額, '') != '' THEN '〇' ELSE '' END AS チェック,";
            strSql += "       sz.仕入先コード, sz.取引先名称 AS 仕入先名, sz.支払予定日, sz.支払予定額, S3.支払額, S3.手形期日";
            strSql += "  from";
            strSql += "       (SELECT S2.仕入先コード, S2.取引先名称, S2.支払予定日, SUM(S2.税込合計金額) AS 支払予定額";
            strSql += "          FROM";
            strSql += "               (select S.仕入先コード,";
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
            strSql += "                            END 支払予定日,";
            strSql += "                       S.税込合計金額,";
            strSql += "                       T.取引先名称";
            strSql += "                  from 仕入ヘッダ S,";
            strSql += "                       取引先 T";
            strSql += "                 where S.削除 = 'N'";
            strSql += "                   and S.伝票年月日 >= '" + fromfrom + "'";
            strSql += "                   and T.削除 = 'N'";
            strSql += "                   and S.仕入先コード = T.取引先コード) AS S2";
            strSql += "         WHERE S2.支払予定日 >= '" + from + "'";
            strSql += "           AND S2.支払予定日 <= '" + to + "'";
            strSql += "         group by S2.仕入先コード, S2.支払予定日, S2.取引先名称) as sz";
            strSql += "  left join";
            strSql += "       (select 仕入先コード, sum(支払額) as 支払額, 手形期日";
            strSql += "          from 支払 sa";
            strSql += "         where sa.削除 = 'N'";
            strSql += "           and sa.支払年月日 >= '" + from2 + "'";
            strSql += "           and sa.支払年月日 <= '" + to2 + "'";
            strSql += "         group by 仕入先コード, 手形期日) S3";
            strSql += "  on sz.仕入先コード = S3.仕入先コード";


            strSql += " UNION ";
            strSql += "select CASE WHEN ISNULL(S3.支払額, '') != '' THEN '手' ELSE '' END AS チェック,";
            strSql += "       S3.仕入先コード, dbo.f_get取引先名称(S3.仕入先コード) AS 仕入先名, sz.支払予定日, sz.支払予定額, S3.支払額, S3.手形期日";
            strSql += "  from";
            strSql += "       (select 仕入先コード, sum(支払額) as 支払額, 手形期日";
            strSql += "          from 支払 sa";
            strSql += "         where sa.削除 = 'N'";
            strSql += "           and sa.手形期日 >= '" + from + "'";
            strSql += "           and sa.手形期日 <= '" + to + "'";
            strSql += "         group by 仕入先コード, 手形期日) S3";
            strSql += "  left join";
            strSql += "       (SELECT S2.仕入先コード, S2.取引先名称, S2.支払予定日, SUM(S2.税込合計金額) AS 支払予定額";
            strSql += "          FROM";
            strSql += "               (select S.仕入先コード,";
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
            strSql += "                            END 支払予定日,";
            strSql += "                       S.税込合計金額,";
            strSql += "                       T.取引先名称";
            strSql += "                  from 仕入ヘッダ S,";
            strSql += "                       取引先 T";
            strSql += "                 where S.削除 = 'N'";
            strSql += "                   and S.伝票年月日 >= '" + fromfrom + "'";
            strSql += "                   and T.削除 = 'N'";
            strSql += "                   and S.仕入先コード = T.取引先コード) AS S2";
            strSql += "         WHERE S2.支払予定日 >= '" + from + "'";
            strSql += "           AND S2.支払予定日 <= '" + to + "'";
            strSql += "         group by S2.仕入先コード, S2.支払予定日, S2.取引先名称) as sz";
            strSql += "  on sz.仕入先コード = S3.仕入先コード";

            strSql += " order by sz.仕入先コード, sz.支払予定日";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dt = dbconnective.ReadSql(strSql);

                return dt;
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

        public DataTable getCalendarNyukin(string from, string to)
        {
            DataTable dt = null;
            string strSql = "";

            string fromfrom = DateTime.Parse(from).AddYears(-1).ToString("yyyy/MM/dd");

            strSql += "select CASE WHEN ISNULL(S3.入金額, '') != '' THEN '〇' ELSE '' END AS チェック,";
            strSql += "       sz.得意先コード, sz.取引先名称 AS 得意先名, sz.入金予定日, sz.入金予定額, S3.入金額, S3.手形期日";
            strSql += "  from";
            strSql += "       (SELECT S2.得意先コード, S2.取引先名称, S2.入金予定日, SUM(S2.税込合計金額) AS 入金予定額";
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
            strSql += "                       T.取引先名称";
            strSql += "                  from 売上ヘッダ S,";
            strSql += "                       取引先 T";
            strSql += "                 where S.削除 = 'N'";
            strSql += "                   and S.伝票年月日 >= '" + fromfrom + "'";
            strSql += "                   and T.削除 = 'N'";
            strSql += "                   and S.得意先コード = T.取引先コード) AS S2";
            strSql += "         WHERE S2.入金予定日 >= '" + from + "'";
            strSql += "           AND S2.入金予定日 <= '" + to + "'";
            strSql += "         group by S2.得意先コード, S2.入金予定日, S2.取引先名称) as sz";
            strSql += "  left join";
            strSql += "       (select 得意先コード, sum(入金額) as 入金額, 手形期日";
            strSql += "          from 入金 sa";
            strSql += "         where sa.削除 = 'N'";
            strSql += "           and sa.入金年月日 >= '" + from + "'";
            strSql += "           and sa.入金年月日 <= '" + to + "'";
            strSql += "         group by 得意先コード, 手形期日) S3";
            strSql += "  on sz.得意先コード = S3.得意先コード";





            strSql += " order by sz.得意先コード, sz.入金予定日";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dt = dbconnective.ReadSql(strSql);

                return dt;
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

        public DataTable getCalendarNyukin2(string from, string to)
        {
            DataTable dt = null;
            string strSql = "";

            string fromfrom = DateTime.Parse(from).AddYears(-1).ToString("yyyy/MM/dd");

            strSql += "select CASE WHEN ISNULL(S3.入金額, '') != '' THEN '〇' ELSE '' END AS チェック,";
            strSql += "       sz.得意先コード, sz.取引先名称 AS 得意先名, sz.入金予定日, sz.入金予定額, S3.入金額, S3.手形期日";
            strSql += "  from";
            strSql += "       (select 得意先コード, sum(入金額) as 入金額, 手形期日";
            strSql += "          from 入金 sa";
            strSql += "         where sa.削除 = 'N'";
            strSql += "           and sa.手形期日 >= '" + from + "'";
            strSql += "           and sa.手形期日 <= '" + to + "'";
            strSql += "         group by 得意先コード, 手形期日) S3";
            strSql += "  left join";
            strSql += "       (SELECT S2.得意先コード, S2.取引先名称, S2.入金予定日, SUM(S2.税込合計金額) AS 入金予定額";
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
            strSql += "                       T.取引先名称";
            strSql += "                  from 売上ヘッダ S,";
            strSql += "                       取引先 T";
            strSql += "                 where S.削除 = 'N'";
            strSql += "                   and S.伝票年月日 >= '" + fromfrom + "'";
            strSql += "                   and T.削除 = 'N'";
            strSql += "                   and S.得意先コード = T.取引先コード) AS S2";
            strSql += "         WHERE S2.入金予定日 >= '" + from + "'";
            strSql += "           AND S2.入金予定日 <= '" + to + "'";
            strSql += "         group by S2.得意先コード, S2.入金予定日, S2.取引先名称) as sz";

            strSql += "  on sz.得意先コード = S3.得意先コード";


            strSql += " order by sz.得意先コード, sz.入金予定日";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dt = dbconnective.ReadSql(strSql);

                return dt;
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

        public DataTable getListNyukin(string from, string to, string from2, string to2)
        {
            DataTable dt = null;
            string strSql = "";

            string fromfrom = DateTime.Parse(from).AddYears(-1).ToString("yyyy/MM/dd");

            strSql += "select CASE WHEN ISNULL(S3.入金額, '') != '' THEN '〇' ELSE '' END AS チェック,";
            strSql += "       sz.得意先コード, sz.取引先名称 AS 得意先名, sz.入金予定日, sz.入金予定額, S3.入金額, S3.手形期日";
            strSql += "  from";
            strSql += "       (SELECT S2.得意先コード, S2.取引先名称, S2.入金予定日, SUM(S2.税込合計金額) AS 入金予定額";
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
            strSql += "                       T.取引先名称";
            strSql += "                  from 売上ヘッダ S,";
            strSql += "                       取引先 T";
            strSql += "                 where S.削除 = 'N'";
            strSql += "                   and S.伝票年月日 >= '" + fromfrom + "'";
            strSql += "                   and T.削除 = 'N'";
            strSql += "                   and S.得意先コード = T.取引先コード) AS S2";
            strSql += "         WHERE S2.入金予定日 >= '" + from + "'";
            strSql += "           AND S2.入金予定日 <= '" + to + "'";
            strSql += "         group by S2.得意先コード, S2.入金予定日, S2.取引先名称) as sz";
            strSql += "  left join";
            strSql += "       (select 得意先コード, sum(入金額) as 入金額, 手形期日";
            strSql += "          from 入金 sa";
            strSql += "         where sa.削除 = 'N'";
            strSql += "           and sa.入金年月日 >= '" + from2 + "'";
            strSql += "           and sa.入金年月日 <= '" + to2 + "'";
            strSql += "         group by 得意先コード, 手形期日) S3";
            strSql += "  on sz.得意先コード = S3.得意先コード";


            strSql += " UNION ";
            strSql += "select CASE WHEN ISNULL(S3.入金額, '') != '' THEN '手' ELSE '' END AS チェック,";
            strSql += "       S3.得意先コード, dbo.f_get取引先名称(S3.得意先コード) AS 得意先名, sz.入金予定日, sz.入金予定額, S3.入金額, S3.手形期日";
            strSql += "  from";
            strSql += "       (select 得意先コード, sum(入金額) as 入金額, 手形期日";
            strSql += "          from 入金 sa";
            strSql += "         where sa.削除 = 'N'";
            strSql += "           and sa.手形期日 >= '" + from + "'";
            strSql += "           and sa.手形期日 <= '" + to + "'";
            strSql += "         group by 得意先コード, 手形期日) S3";
            strSql += "  left join";
            strSql += "       (SELECT S2.得意先コード, S2.取引先名称, S2.入金予定日, SUM(S2.税込合計金額) AS 入金予定額";
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
            strSql += "                       T.取引先名称";
            strSql += "                  from 売上ヘッダ S,";
            strSql += "                       取引先 T";
            strSql += "                 where S.削除 = 'N'";
            strSql += "                   and S.伝票年月日 >= '" + fromfrom + "'";
            strSql += "                   and T.削除 = 'N'";
            strSql += "                   and S.得意先コード = T.取引先コード) AS S2";
            strSql += "         WHERE S2.入金予定日 >= '" + from + "'";
            strSql += "           AND S2.入金予定日 <= '" + to + "'";
            strSql += "         group by S2.得意先コード, S2.入金予定日, S2.取引先名称) as sz";
            strSql += "  on sz.得意先コード = S3.得意先コード";

            strSql += " order by sz.得意先コード, sz.入金予定日";


            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dt = dbconnective.ReadSql(strSql);

                return dt;
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
