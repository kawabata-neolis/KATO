using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KATO.Common.Util;
using System.IO;
using System.ComponentModel;

using Spire.Xls;
using ClosedXML.Excel;

//iTextSharp関連の名前空間
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace KATO.Business.C0480_SiireSuiiHyo
{
    /// <summary>
    /// C0480_SiireSuiiHyo_B
    /// 分類別仕入推移表 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/6/14
    /// 更新者：多田
    /// 更新日：2017/6/14
    /// カラム論理名
    /// </summary>
    class C0480_SiireSuiiHyo_B
    {
        /// <summary>
        /// setTxtBox
        /// 仕入推移を取得
        /// </summary>
        public DataTable getSiireSuiiList(List<string> lstSearchItem, string strType)
        {
            string strSql;
            DataTable dtGetTableGrid = new DataTable();

            // 大分類の指定がない場合
            if (lstSearchItem[7].Equals(""))
            {
                // メーカーの指定がない場合
                if (lstSearchItem[9].Equals(""))
                {
                    // 無指定のSQL文を取得
                    strSql = getSqlDefault(lstSearchItem, strType);
                }
                else
                {
                    // メーカーの指定のSQL文を取得
                    strSql = getSqlMaker(lstSearchItem, strType);
                }
            }
            else
            {
                // 中分類の指定がない場合
                if (lstSearchItem[8].Equals(""))
                {
                    // 大分類の指定のSQL文を取得
                    strSql = getSqlDaibunrui(lstSearchItem, strType);
                }
                else
                {
                    // メーカーの指定がない場合
                    if (lstSearchItem[9].Equals(""))
                    {
                        // 大分類,中分類の指定のSQL文を取得
                        strSql = getSqlDaiChubunrui(lstSearchItem, strType);
                    }
                    else
                    {
                        // 大分類,中分類,メーカーの指定のSQL文を取得
                        strSql = getSqlAll(lstSearchItem, strType);
                    }
                }
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtGetTableGrid = dbconnective.ReadSql(strSql);

                return dtGetTableGrid;
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }


        /// <summary>
        /// getSqlDefault
        /// 無指定のSQL文を取得
        /// </summary>
        private string getSqlDefault(List<string> lstSearchItem, string strType)
        {
            string strSql;
            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;

            dateStartYMD = DateTime.Parse(lstSearchItem[0] + "/01");
            dateEndYMD = DateTime.Parse(lstSearchItem[1] + "/01");
            dateEndYMD = dateEndYMD.AddMonths(1).AddDays(-1);

            strSql = " SELECT ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSql += "仕入先コード,";
                strSql += "仕入先名,";
                strSql += "区分,";
                strSql += "大分類コード,";
                strSql += "中分類コード,";
                strSql += "メーカーコード,";
                strSql += "分類名 ,";
                strSql += "SUM(金額１) AS 金額１ ,";
                strSql += "SUM(金額２) AS 金額２ ,";
                strSql += "SUM(金額３) AS 金額３ ,";
                strSql += "SUM(金額４) AS 金額４ ,";
                strSql += "SUM(金額５) AS 金額５ ,";
                strSql += "SUM(金額６) AS 金額６ ,";
                strSql += "SUM(金額７) AS 金額７ ,";
                strSql += "SUM(金額８) AS 金額８ ,";
                strSql += "SUM(金額９) AS 金額９ ,";
                strSql += "SUM(金額１０) AS 金額１０ ,";
                strSql += "SUM(金額１１) AS 金額１１ ,";
                strSql += "SUM(金額１２) AS 金額１２ ,";
                strSql += "SUM(金額合計) AS 金額合計 ";
                strSql += " FROM (";
                strSql += " SELECT ";
            }

            strSql += "z.営業所コード,";
            strSql += "dbo.f_get営業所名(z.営業所コード) AS 営業所名,";
            strSql += "z.グループコード,";
            strSql += "dbo.f_getグループ名(z.グループコード) AS グループ名,";
            strSql += "z.担当者コード,";
            strSql += "dbo.f_get担当者名(z.担当者コード) AS 担当者名,";
            strSql += "z.仕入先コード,";
            strSql += "dbo.f_get取引先名称(z.仕入先コード) AS 仕入先名,";
            strSql += "0 AS 区分,";

            strSql += "z.大分類コード,";
            strSql += "NULL AS 中分類コード,";
            strSql += "NULL AS メーカーコード,";
            strSql += "dbo.f_get大分類名(z.大分類コード) AS 分類名,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(0).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(1).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額２,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(2).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額３,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(3).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(4).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額４,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(4).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(5).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額５,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(5).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(6).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額６,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(6).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(7).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額７,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(7).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(8).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額８,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(8).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(9).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額９,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(9).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(10).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１０,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(10).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(11).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１１,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(11).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(12).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１２,";

            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(0).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(1).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(2).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(3).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(4).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(4).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(5).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(5).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(6).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(6).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(7).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(7).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(8).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(8).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(9).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(9).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(10).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(10).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(11).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_大分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,'" + dateStartYMD.AddMonths(11).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(12).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額合計 ";

            strSql += " FROM ";
            strSql += " ( SELECT DISTINCT d.営業所コード, d.グループコード, d.担当者コード, a.仕入先コード,b.大分類コード ";
            strSql += " FROM 仕入ヘッダ a ,仕入明細 b , 担当者 d , グループ e";
            strSql += " WHERE a.削除 = 'N' ";
            strSql += " AND a.伝票番号 = b.伝票番号 ";
            strSql += " AND a.伝票年月日 >='" + dateStartYMD.ToString("yyyy/MM/dd") + "'";
            strSql += " AND a.伝票年月日 <='" + dateEndYMD.ToString("yyyy/MM/dd") + "'";
            strSql += " AND a.仕入先コード >='" + lstSearchItem[4] + "'";
            strSql += " AND a.仕入先コード <='" + lstSearchItem[5] + "'";
            strSql += " AND d.担当者コード = a.担当者コード";
            strSql += " AND e.グループコード = d.グループコード ";

            if (!lstSearchItem[2].Equals(""))
            {
                strSql += " AND d.営業所コード = '" + lstSearchItem[2] + "'";
            }
            if (!lstSearchItem[3].Equals(""))
            {
                strSql += " AND d.グループコード = '" + lstSearchItem[3] + "'";
            }
            if (!lstSearchItem[6].Equals(""))
            {
                strSql += " AND a.担当者コード = '" + lstSearchItem[6] + "'";
            }

            strSql += " ) z ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSql += " ) y ";
                strSql += " GROUP BY 仕入先コード,仕入先名,区分,大分類コード,中分類コード,メーカーコード,分類名";
                strSql += " ORDER BY 仕入先コード,大分類コード,中分類コード,メーカーコード";
            }
            else
            {
                strSql += " ORDER BY Z.営業所コード, z.グループコード, z.担当者コード, z.仕入先コード, z.大分類コード";
            }

            return strSql;
        }

        /// <summary>
        /// getSqlDaibunrui
        /// 大分類の指定のSQL文を取得
        /// </summary>
        private string getSqlDaibunrui(List<string> lstSearchItem, string strType)
        {
            string strSql;
            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;

            dateStartYMD = DateTime.Parse(lstSearchItem[0] + "/01");
            dateEndYMD = DateTime.Parse(lstSearchItem[1] + "/01");
            dateEndYMD = dateEndYMD.AddMonths(1).AddDays(-1);

            strSql = " SELECT ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSql += "仕入先コード,";
                strSql += "仕入先名,";
                strSql += "区分,";
                strSql += "大分類コード,";
                strSql += "中分類コード,";
                strSql += "メーカーコード,";
                strSql += "分類名 ,";
                strSql += "SUM(金額１) AS 金額１ ,";
                strSql += "SUM(金額２) AS 金額２ ,";
                strSql += "SUM(金額３) AS 金額３ ,";
                strSql += "SUM(金額４) AS 金額４ ,";
                strSql += "SUM(金額５) AS 金額５ ,";
                strSql += "SUM(金額６) AS 金額６ ,";
                strSql += "SUM(金額７) AS 金額７ ,";
                strSql += "SUM(金額８) AS 金額８ ,";
                strSql += "SUM(金額９) AS 金額９ ,";
                strSql += "SUM(金額１０) AS 金額１０ ,";
                strSql += "SUM(金額１１) AS 金額１１ ,";
                strSql += "SUM(金額１２) AS 金額１２ ,";
                strSql += "SUM(金額合計) AS 金額合計 ";
                strSql += " FROM (";
                strSql += " SELECT ";
            }

            strSql += "z.営業所コード,";
            strSql += "dbo.f_get営業所名(z.営業所コード) AS 営業所名,";
            strSql += "z.グループコード,";
            strSql += "dbo.f_getグループ名(z.グループコード) AS グループ名,";
            strSql += "z.担当者コード,";
            strSql += "dbo.f_get担当者名(z.担当者コード) AS 担当者名,";
            strSql += "z.仕入先コード,";
            strSql += "dbo.f_get取引先名称(z.仕入先コード) AS 仕入先名,";
            strSql += "1 AS 区分,";

            strSql += "z.大分類コード,";
            strSql += "z.中分類コード,";
            strSql += "NULL AS メーカーコード,";
            strSql += "dbo.f_get中分類名(z.大分類コード,z.中分類コード) AS 分類名 ,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(0).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(1).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額２,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(2).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額３,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(3).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(4).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額４,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(4).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(5).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額５,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(5).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(6).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額６,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(6).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(7).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額７,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(7).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(8).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額８,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(8).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(9).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額９,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(9).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(10).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１０,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(10).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(11).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１１,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(11).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(12).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１２,";

            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(0).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(1).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(2).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(3).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(4).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(4).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(5).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(5).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(6).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(6).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(7).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(7).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(8).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(8).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(9).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(9).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(10).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(10).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(11).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_中分類_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,'" + dateStartYMD.AddMonths(11).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(12).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額合計";

            strSql += " FROM ";
            strSql += " ( SELECT DISTINCT d.営業所コード, d.グループコード, d.担当者コード, a.仕入先コード,b.大分類コード,b.中分類コード ";
            strSql += " FROM 仕入ヘッダ a ,仕入明細 b , 担当者 d , グループ e";
            strSql += " WHERE a.削除 = 'N' ";
            strSql += " AND a.伝票番号 = b.伝票番号 ";
            strSql += " AND a.伝票年月日 >='" + dateStartYMD.ToString("yyyy/MM/dd") + "'";
            strSql += " AND a.伝票年月日 <='" + dateEndYMD.ToString("yyyy/MM/dd") + "'";
            strSql += " AND a.仕入先コード >='" + lstSearchItem[4] + "'";
            strSql += " AND a.仕入先コード <='" + lstSearchItem[5] + "'";
            strSql += " AND b.大分類コード ='" + lstSearchItem[7] + "' ";
            strSql += " AND d.担当者コード = a.担当者コード";
            strSql += " AND e.グループコード = d.グループコード ";

            if (!lstSearchItem[2].Equals(""))
            {
                strSql += " AND d.営業所コード = '" + lstSearchItem[2] + "'";
            }
            if (!lstSearchItem[3].Equals(""))
            {
                strSql += " AND d.グループコード = '" + lstSearchItem[3] + "'";
            }
            if (!lstSearchItem[6].Equals(""))
            {
                strSql += " AND a.担当者コード = '" + lstSearchItem[6] + "'";
            }

            strSql += " ) z ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSql += " ) y ";
                strSql += " GROUP BY 仕入先コード,仕入先名,区分,大分類コード,中分類コード,メーカーコード,分類名";
                strSql += " ORDER BY 仕入先コード,大分類コード,中分類コード,メーカーコード";
            }
            else
            {
                strSql += " ORDER BY Z.営業所コード, z.グループコード, z.担当者コード, z.仕入先コード, z.大分類コード,z.中分類コード";
            }

            return strSql;
        }

        /// <summary>
        /// getSqlDaiChubunrui
        /// 大分類,中分類の指定のSQL文を取得
        /// </summary>
        private string getSqlDaiChubunrui(List<string> lstSearchItem, string strType)
        {
            string strSql;
            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;

            dateStartYMD = DateTime.Parse(lstSearchItem[0] + "/01");
            dateEndYMD = DateTime.Parse(lstSearchItem[1] + "/01");
            dateEndYMD = dateEndYMD.AddMonths(1).AddDays(-1);

            strSql = " SELECT ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSql += "仕入先コード,";
                strSql += "仕入先名,";
                strSql += "区分,";
                strSql += "大分類コード,";
                strSql += "中分類コード,";
                strSql += "メーカーコード,";
                strSql += "分類名 ,";
                strSql += "SUM(金額１) AS 金額１ ,";
                strSql += "SUM(金額２) AS 金額２ ,";
                strSql += "SUM(金額３) AS 金額３ ,";
                strSql += "SUM(金額４) AS 金額４ ,";
                strSql += "SUM(金額５) AS 金額５ ,";
                strSql += "SUM(金額６) AS 金額６ ,";
                strSql += "SUM(金額７) AS 金額７ ,";
                strSql += "SUM(金額８) AS 金額８ ,";
                strSql += "SUM(金額９) AS 金額９ ,";
                strSql += "SUM(金額１０) AS 金額１０ ,";
                strSql += "SUM(金額１１) AS 金額１１ ,";
                strSql += "SUM(金額１２) AS 金額１２ ,";
                strSql += "SUM(金額合計) AS 金額合計 ";
                strSql += " FROM (";
                strSql += " SELECT ";
            }

            strSql += "z.営業所コード,";
            strSql += "dbo.f_get営業所名(z.営業所コード) AS 営業所名,";
            strSql += "z.グループコード,";
            strSql += "dbo.f_getグループ名(z.グループコード) AS グループ名,";
            strSql += "z.担当者コード,";
            strSql += "dbo.f_get担当者名(z.担当者コード) AS 担当者名,";
            strSql += "z.仕入先コード,";
            strSql += "dbo.f_get取引先名称(z.仕入先コード) AS 仕入先名,";
            strSql += "2 AS 区分,"; ;

            strSql += "z.大分類コード,";
            strSql += "z.中分類コード,";
            strSql += "z.メーカーコード,";
            strSql += "dbo.f_getメーカー名(z.メーカーコード) AS 分類名 ,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(0).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(1).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額２,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(2).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額３,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(3).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(4).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額４,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(4).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(5).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額５,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(5).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(6).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額６,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(6).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(7).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額７,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(7).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(8).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額８,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(8).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(9).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額９,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(9).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(10).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１０,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(10).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(11).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１１,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(11).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(12).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１２,";


            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(0).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(1).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(2).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(3).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(4).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(4).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(5).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(5).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(6).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(6).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(7).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(7).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(8).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(8).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(9).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(9).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(10).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(10).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(11).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(11).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(12).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額合計";


            strSql += " FROM ";
            strSql += " ( SELECT DISTINCT d.営業所コード, d.グループコード, d.担当者コード, a.仕入先コード,b.大分類コード,b.中分類コード,b.メーカーコード ";
            strSql += " FROM 仕入ヘッダ a ,仕入明細 b , 担当者 d , グループ e";


            strSql += " WHERE a.削除 = 'N' ";
            strSql += " AND a.伝票番号 = b.伝票番号 ";
            strSql += " AND a.伝票年月日 >='" + dateStartYMD.ToString("yyyy/MM/dd") + "'";
            strSql += " AND a.伝票年月日 <='" + dateEndYMD.ToString("yyyy/MM/dd") + "'";
            strSql += " AND a.仕入先コード >='" + lstSearchItem[4] + "'";
            strSql += " AND a.仕入先コード <='" + lstSearchItem[5] + "'";
            strSql += " AND b.大分類コード ='" + lstSearchItem[7] + "' ";
            strSql += " AND b.中分類コード ='" + lstSearchItem[8] + "' ";

            strSql += " AND d.担当者コード = a.担当者コード";
            strSql += " AND e.グループコード = d.グループコード ";

            if (!lstSearchItem[2].Equals(""))
            {
                strSql += " AND d.営業所コード = '" + lstSearchItem[2] + "'";
            }
            if (!lstSearchItem[3].Equals(""))
            {
                strSql += " AND d.グループコード = '" + lstSearchItem[3] + "'";
            }
            if (!lstSearchItem[6].Equals(""))
            {
                strSql += " AND a.担当者コード = '" + lstSearchItem[6] + "'";
            }

            strSql += " ) z ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSql += " ) y ";
                strSql += " GROUP BY 仕入先コード,仕入先名,区分,大分類コード,中分類コード,メーカーコード,分類名";
                strSql += " ORDER BY 仕入先コード,大分類コード,中分類コード,メーカーコード";
            }
            else
            {
                strSql += " ORDER BY Z.営業所コード, z.グループコード, z.担当者コード, z.仕入先コード, z.大分類コード,z.中分類コード,z.メーカーコード";
            }

            return strSql;
        }

        /// <summary>
        /// getSqlAll
        /// 大分類,中分類,メーカーの指定のSQL文を取得 
        /// </summary>
        private string getSqlAll(List<string> lstSearchItem, string strType)
        {
            string strSql;
            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;

            dateStartYMD = DateTime.Parse(lstSearchItem[0] + "/01");
            dateEndYMD = DateTime.Parse(lstSearchItem[1] + "/01");
            dateEndYMD = dateEndYMD.AddMonths(1).AddDays(-1);

            strSql = " SELECT ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSql += "仕入先コード,";
                strSql += "仕入先名,";
                strSql += "区分,";
                strSql += "大分類コード,";
                strSql += "中分類コード,";
                strSql += "メーカーコード,";
                strSql += "分類名 ,";
                strSql += "SUM(金額１) AS 金額１ ,";
                strSql += "SUM(金額２) AS 金額２ ,";
                strSql += "SUM(金額３) AS 金額３ ,";
                strSql += "SUM(金額４) AS 金額４ ,";
                strSql += "SUM(金額５) AS 金額５ ,";
                strSql += "SUM(金額６) AS 金額６ ,";
                strSql += "SUM(金額７) AS 金額７ ,";
                strSql += "SUM(金額８) AS 金額８ ,";
                strSql += "SUM(金額９) AS 金額９ ,";
                strSql += "SUM(金額１０) AS 金額１０ ,";
                strSql += "SUM(金額１１) AS 金額１１ ,";
                strSql += "SUM(金額１２) AS 金額１２ ,";
                strSql += "SUM(金額合計) AS 金額合計 ";
                strSql += " FROM (";
                strSql += " SELECT ";
            }

            strSql += "z.営業所コード,";
            strSql += "dbo.f_get営業所名(z.営業所コード) AS 営業所名,";
            strSql += "z.グループコード,";
            strSql += "dbo.f_getグループ名(z.グループコード) AS グループ名,";
            strSql += "z.担当者コード,";
            strSql += "dbo.f_get担当者名(z.担当者コード) AS 担当者名,";
            strSql += "z.仕入先コード,";
            strSql += "dbo.f_get取引先名称(z.仕入先コード) AS 仕入先名,";
            strSql += "3 AS 区分,";


            strSql += "z.大分類コード,";
            strSql += "z.中分類コード,";
            strSql += "z.メーカーコード,";
            strSql += "dbo.f_getメーカー名(z.メーカーコード) AS 分類名 ,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(0).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(1).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額２,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(2).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額３,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(3).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(4).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額４,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(4).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(5).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額５,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(5).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(6).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額６,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(6).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(7).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額７,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(7).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(8).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額８,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(8).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(9).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額９,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(9).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(10).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１０,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(10).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(11).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１１,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(11).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(12).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１２,";


            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(0).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(1).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(2).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(3).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(4).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(4).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(5).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(5).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(6).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(6).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(7).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(7).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(8).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(8).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(9).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(9).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(10).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(10).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(11).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.大分類コード,z.中分類コード,z.メーカーコード,'" + dateStartYMD.AddMonths(11).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(12).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額合計";


            strSql += " FROM ";
            strSql += " ( SELECT DISTINCT d.営業所コード, d.グループコード, d.担当者コード, a.仕入先コード,b.大分類コード,b.中分類コード,b.メーカーコード ";
            strSql += " FROM 仕入ヘッダ a ,仕入明細 b , 担当者 d , グループ e";


            strSql += " WHERE a.削除 = 'N' ";
            strSql += " AND a.伝票番号 = b.伝票番号 ";
            strSql += " AND a.伝票年月日 >='" + dateStartYMD.ToString("yyyy/MM/dd") + "'";
            strSql += " AND a.伝票年月日 <='" + dateEndYMD.ToString("yyyy/MM/dd") + "'";
            strSql += " AND a.仕入先コード >='" + lstSearchItem[4] + "'";
            strSql += " AND a.仕入先コード <='" + lstSearchItem[5] + "'";
            strSql += " AND b.大分類コード ='" + lstSearchItem[7] + "' ";
            strSql += " AND b.中分類コード ='" + lstSearchItem[8] + "' ";
            strSql += " AND b.メーカーコード ='" + lstSearchItem[9] + "' ";
            strSql += " AND d.担当者コード = a.担当者コード";
            strSql += " AND e.グループコード = d.グループコード ";

            if (!lstSearchItem[2].Equals(""))
            {
                strSql += " AND d.営業所コード = '" + lstSearchItem[2] + "'";
            }
            if (!lstSearchItem[3].Equals(""))
            {
                strSql += " AND d.グループコード = '" + lstSearchItem[3] + "'";
            }
            if (!lstSearchItem[6].Equals(""))
            {
                strSql += " AND a.担当者コード = '" + lstSearchItem[6] + "'";
            }

            strSql += " ) z ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSql += " ) y ";
                strSql += " GROUP BY 仕入先コード,仕入先名,区分,大分類コード,中分類コード,メーカーコード,分類名";
                strSql += " ORDER BY 仕入先コード,大分類コード,中分類コード,メーカーコード";
            }
            else
            {
                strSql += " ORDER BY Z.営業所コード, z.グループコード, z.担当者コード, z.仕入先コード, z.大分類コード,z.中分類コード,z.メーカーコード";
            }

            return strSql;
        }

        /// <summary>
        /// getSqlMaker
        /// メーカーの指定のSQL文を取得
        /// </summary>
        private string getSqlMaker(List<string> lstSearchItem, string strType)
        {
            string strSql;
            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;

            dateStartYMD = DateTime.Parse(lstSearchItem[0] + "/01");
            dateEndYMD = DateTime.Parse(lstSearchItem[1] + "/01");
            dateEndYMD = dateEndYMD.AddMonths(1).AddDays(-1);

            strSql = " SELECT ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSql += "仕入先名,";
                strSql += "区分,";
                strSql += "大分類コード,";
                strSql += "中分類コード,";
                strSql += "メーカーコード,";
                strSql += "分類名 ,";
                strSql += "SUM(金額１) AS 金額１ ,";
                strSql += "SUM(金額２) AS 金額２ ,";
                strSql += "SUM(金額３) AS 金額３ ,";
                strSql += "SUM(金額４) AS 金額４ ,";
                strSql += "SUM(金額５) AS 金額５ ,";
                strSql += "SUM(金額６) AS 金額６ ,";
                strSql += "SUM(金額７) AS 金額７ ,";
                strSql += "SUM(金額８) AS 金額８ ,";
                strSql += "SUM(金額９) AS 金額９ ,";
                strSql += "SUM(金額１０) AS 金額１０ ,";
                strSql += "SUM(金額１１) AS 金額１１ ,";
                strSql += "SUM(金額１２) AS 金額１２ ,";
                strSql += "SUM(金額合計) AS 金額合計 ";
                strSql += " FROM (";
                strSql += " SELECT ";
            }

            strSql += "z.営業所コード,";
            strSql += "dbo.f_get営業所名(z.営業所コード) AS 営業所名,";
            strSql += "z.グループコード,";
            strSql += "dbo.f_getグループ名(z.グループコード) AS グループ名,";
            strSql += "z.担当者コード,";
            strSql += "dbo.f_get担当者名(z.担当者コード) AS 担当者名,";
            strSql += "z.仕入先コード,";
            strSql += "dbo.f_get取引先名称(z.仕入先コード) AS 仕入先名,";
            strSql += "4 AS 区分,";


            strSql += "NULL AS 大分類コード,";
            strSql += "NULL AS 中分類コード,";
            strSql += "z.メーカーコード,";
            strSql += "dbo.f_getメーカー名(z.メーカーコード) AS 分類名 ,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(0).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(1).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額２,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(2).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額３,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(3).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(4).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額４,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(4).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(5).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額５,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(5).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(6).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額６,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(6).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(7).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額７,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(7).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(8).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額８,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(8).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(9).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額９,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(9).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(10).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１０,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(10).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(11).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１１,";
            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(11).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(12).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額１２,";


            strSql += "ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(0).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(1).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(2).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(3).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(4).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(4).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(5).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(5).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(6).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(6).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(7).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(7).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(8).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(8).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(9).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(9).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(10).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(10).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(11).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) ";
            strSql += " + ROUND(dbo.f_分類別仕入推移表_仕入高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード,z.担当者コード,z.仕入先コード,z.メーカーコード,'" + dateStartYMD.AddMonths(11).ToString("yyyy/MM/dd") + "','" + dateStartYMD.AddMonths(12).AddDays(-1).ToString("yyyy/MM/dd") + "')/1000 ,0,0) AS 金額合計";


            strSql += " FROM ";
            strSql += " ( SELECT DISTINCT d.営業所コード, d.グループコード, d.担当者コード, a.仕入先コード,b.メーカーコード ";
            strSql += " FROM 仕入ヘッダ a ,仕入明細 b , 担当者 d , グループ e";


            strSql += " WHERE a.削除 = 'N' ";
            strSql += " AND a.伝票番号 = b.伝票番号 ";
            strSql += " AND a.伝票年月日 >='" + dateStartYMD.ToString("yyyy/MM/dd") + "'";
            strSql += " AND a.伝票年月日 <='" + dateEndYMD.ToString("yyyy/MM/dd") + "'";
            strSql += " AND a.仕入先コード >='" + lstSearchItem[4] + "'";
            strSql += " AND a.仕入先コード <='" + lstSearchItem[5] + "'";
            strSql += " AND b.メーカーコード ='" + lstSearchItem[9] + "' ";
            strSql += " AND d.担当者コード = a.担当者コード";
            strSql += " AND e.グループコード = d.グループコード ";

            if (!lstSearchItem[2].Equals(""))
            {
                strSql += " AND d.営業所コード = '" + lstSearchItem[2] + "'";
            }
            if (!lstSearchItem[3].Equals(""))
            {
                strSql += " AND d.グループコード = '" + lstSearchItem[3] + "'";
            }
            if (!lstSearchItem[6].Equals(""))
            {
                strSql += " AND a.担当者コード = '" + lstSearchItem[6] + "'";
            }

            strSql += " ) z ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSql += " ) y ";
                strSql += " GROUP BY 仕入先コード,仕入先名,区分,大分類コード,中分類コード,メーカーコード,分類名";
                strSql += " ORDER BY 仕入先コード,メーカーコード";
            }
            else
            {
                strSql += " ORDER BY Z.営業所コード, z.グループコード, z.担当者コード, z.仕入先コード, z.メーカーコード";
            }

            return strSql;
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtSiireSuiiList">
        ///     仕入推移表のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSiireSuiiList, string strStartYM)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                string strHeader = "";
                string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                string strSpace = "       ";
                string strComputerName = System.Windows.Forms.SystemInformation.ComputerName;

                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled);

                // ワークブックのデフォルトフォント、フォントサイズの指定
                XLWorkbook.DefaultStyle.Font.FontName = "ＭＳ 明朝";
                XLWorkbook.DefaultStyle.Font.FontSize = 9;

                IXLWorksheet worksheet = workbook.Worksheets.Add("Header");
                IXLWorksheet headersheet = worksheet;   // ヘッダーシート
                IXLWorksheet currentsheet = worksheet;  // 処理中シート


                //Linqで必要なデータをselect
                var outDataAll = dtSiireSuiiList.AsEnumerable()
                    .Select(dat => new
                    {
                        eigyoName = dat["営業所名"],
                        groupName = dat["グループ名"],
                        tantoName = dat["担当者名"],
                        siireCode = dat["仕入先コード"],
                        siireName = dat["仕入先名"],
                        bunruiName = dat["分類名"],
                        kingaku1 = (decimal)dat["金額１"],
                        kingaku2 = (decimal)dat["金額２"],
                        kingaku3 = (decimal)dat["金額３"],
                        kingaku4 = (decimal)dat["金額４"],
                        kingaku5 = (decimal)dat["金額５"],
                        kingaku6 = (decimal)dat["金額６"],
                        kingaku7 = (decimal)dat["金額７"],
                        kingaku8 = (decimal)dat["金額８"],
                        kingaku9 = (decimal)dat["金額９"],
                        kingaku10 = (decimal)dat["金額１０"],
                        kingaku11 = (decimal)dat["金額１１"],
                        kingaku12 = (decimal)dat["金額１２"],
                        kingakuGoukei = (decimal)dat["金額合計"]
                    }).ToList();

                // linqで金額１～金額１２、金額合計の合計算出
                decimal[] decKingaku = new decimal[13];
                decKingaku[0] = outDataAll.Select(gokei => gokei.kingaku1).Sum();
                decKingaku[1] = outDataAll.Select(gokei => gokei.kingaku2).Sum();
                decKingaku[2] = outDataAll.Select(gokei => gokei.kingaku3).Sum();
                decKingaku[3] = outDataAll.Select(gokei => gokei.kingaku4).Sum();
                decKingaku[4] = outDataAll.Select(gokei => gokei.kingaku5).Sum();
                decKingaku[5] = outDataAll.Select(gokei => gokei.kingaku6).Sum();
                decKingaku[6] = outDataAll.Select(gokei => gokei.kingaku7).Sum();
                decKingaku[7] = outDataAll.Select(gokei => gokei.kingaku8).Sum();
                decKingaku[8] = outDataAll.Select(gokei => gokei.kingaku9).Sum();
                decKingaku[9] = outDataAll.Select(gokei => gokei.kingaku10).Sum();
                decKingaku[10] = outDataAll.Select(gokei => gokei.kingaku11).Sum();
                decKingaku[11] = outDataAll.Select(gokei => gokei.kingaku12).Sum();
                decKingaku[12] = outDataAll.Select(gokei => gokei.kingakuGoukei).Sum();

                // 担当者計
                var tantoGoukei = from tbl in dtSiireSuiiList.AsEnumerable()
                                  group tbl by tbl.Field<string>("担当者コード") into g
                                  select new
                                  {
                                      section = g.Key,
                                      count = g.Count(),
                                      kingaku1 = g.Sum(p => p.Field<decimal>("金額１")),
                                      kingaku2 = g.Sum(p => p.Field<decimal>("金額２")),
                                      kingaku3 = g.Sum(p => p.Field<decimal>("金額３")),
                                      kingaku4 = g.Sum(p => p.Field<decimal>("金額４")),
                                      kingaku5 = g.Sum(p => p.Field<decimal>("金額５")),
                                      kingaku6 = g.Sum(p => p.Field<decimal>("金額６")),
                                      kingaku7 = g.Sum(p => p.Field<decimal>("金額７")),
                                      kingaku8 = g.Sum(p => p.Field<decimal>("金額８")),
                                      kingaku9 = g.Sum(p => p.Field<decimal>("金額９")),
                                      kingaku10 = g.Sum(p => p.Field<decimal>("金額１０")),
                                      kingaku11 = g.Sum(p => p.Field<decimal>("金額１１")),
                                      kingaku12 = g.Sum(p => p.Field<decimal>("金額１２")),
                                      kingakuGoukei = g.Sum(p => p.Field<decimal>("金額合計"))
                                  };

                // 担当者計の金額１～金額１２、金額合計の合計算出
                decimal[,] decKingakuTanto = new decimal[tantoGoukei.Count(), 13];
                for (int cnt = 0; cnt < tantoGoukei.Count(); cnt++)
                {
                    decKingakuTanto[cnt, 0] = tantoGoukei.ElementAt(cnt).kingaku1;
                    decKingakuTanto[cnt, 1] = tantoGoukei.ElementAt(cnt).kingaku2;
                    decKingakuTanto[cnt, 2] = tantoGoukei.ElementAt(cnt).kingaku3;
                    decKingakuTanto[cnt, 3] = tantoGoukei.ElementAt(cnt).kingaku4;
                    decKingakuTanto[cnt, 4] = tantoGoukei.ElementAt(cnt).kingaku5;
                    decKingakuTanto[cnt, 5] = tantoGoukei.ElementAt(cnt).kingaku6;
                    decKingakuTanto[cnt, 6] = tantoGoukei.ElementAt(cnt).kingaku7;
                    decKingakuTanto[cnt, 7] = tantoGoukei.ElementAt(cnt).kingaku8;
                    decKingakuTanto[cnt, 8] = tantoGoukei.ElementAt(cnt).kingaku9;
                    decKingakuTanto[cnt, 9] = tantoGoukei.ElementAt(cnt).kingaku10;
                    decKingakuTanto[cnt, 10] = tantoGoukei.ElementAt(cnt).kingaku11;
                    decKingakuTanto[cnt, 11] = tantoGoukei.ElementAt(cnt).kingaku12;
                    decKingakuTanto[cnt, 12] = tantoGoukei.ElementAt(cnt).kingakuGoukei;
                }


                // グループ計
                var groupGoukei = from tbl in dtSiireSuiiList.AsEnumerable()
                                  group tbl by tbl.Field<string>("グループコード") into g
                                  select new
                                  {
                                      section = g.Key,
                                      count = g.Count(),
                                      kingaku1 = g.Sum(p => p.Field<decimal>("金額１")),
                                      kingaku2 = g.Sum(p => p.Field<decimal>("金額２")),
                                      kingaku3 = g.Sum(p => p.Field<decimal>("金額３")),
                                      kingaku4 = g.Sum(p => p.Field<decimal>("金額４")),
                                      kingaku5 = g.Sum(p => p.Field<decimal>("金額５")),
                                      kingaku6 = g.Sum(p => p.Field<decimal>("金額６")),
                                      kingaku7 = g.Sum(p => p.Field<decimal>("金額７")),
                                      kingaku8 = g.Sum(p => p.Field<decimal>("金額８")),
                                      kingaku9 = g.Sum(p => p.Field<decimal>("金額９")),
                                      kingaku10 = g.Sum(p => p.Field<decimal>("金額１０")),
                                      kingaku11 = g.Sum(p => p.Field<decimal>("金額１１")),
                                      kingaku12 = g.Sum(p => p.Field<decimal>("金額１２")),
                                      kingakuGoukei = g.Sum(p => p.Field<decimal>("金額合計"))
                                  };

                // グループ計の金額１～金額１２、金額合計の合計算出
                decimal[,] decKingakuGroup = new decimal[groupGoukei.Count(), 13];
                for (int cnt = 0; cnt < groupGoukei.Count(); cnt++)
                {
                    decKingakuGroup[cnt, 0] = groupGoukei.ElementAt(cnt).kingaku1;
                    decKingakuGroup[cnt, 1] = groupGoukei.ElementAt(cnt).kingaku2;
                    decKingakuGroup[cnt, 2] = groupGoukei.ElementAt(cnt).kingaku3;
                    decKingakuGroup[cnt, 3] = groupGoukei.ElementAt(cnt).kingaku4;
                    decKingakuGroup[cnt, 4] = groupGoukei.ElementAt(cnt).kingaku5;
                    decKingakuGroup[cnt, 5] = groupGoukei.ElementAt(cnt).kingaku6;
                    decKingakuGroup[cnt, 6] = groupGoukei.ElementAt(cnt).kingaku7;
                    decKingakuGroup[cnt, 7] = groupGoukei.ElementAt(cnt).kingaku8;
                    decKingakuGroup[cnt, 8] = groupGoukei.ElementAt(cnt).kingaku9;
                    decKingakuGroup[cnt, 9] = groupGoukei.ElementAt(cnt).kingaku10;
                    decKingakuGroup[cnt, 10] = groupGoukei.ElementAt(cnt).kingaku11;
                    decKingakuGroup[cnt, 11] = groupGoukei.ElementAt(cnt).kingaku12;
                    decKingakuGroup[cnt, 12] = groupGoukei.ElementAt(cnt).kingakuGoukei;
                }


                // 営業所計
                var eigyoGoukei = from tbl in dtSiireSuiiList.AsEnumerable()
                                  group tbl by tbl.Field<string>("営業所コード") into g
                                  select new
                                  {
                                      section = g.Key,
                                      count = g.Count(),
                                      kingaku1 = g.Sum(p => p.Field<decimal>("金額１")),
                                      kingaku2 = g.Sum(p => p.Field<decimal>("金額２")),
                                      kingaku3 = g.Sum(p => p.Field<decimal>("金額３")),
                                      kingaku4 = g.Sum(p => p.Field<decimal>("金額４")),
                                      kingaku5 = g.Sum(p => p.Field<decimal>("金額５")),
                                      kingaku6 = g.Sum(p => p.Field<decimal>("金額６")),
                                      kingaku7 = g.Sum(p => p.Field<decimal>("金額７")),
                                      kingaku8 = g.Sum(p => p.Field<decimal>("金額８")),
                                      kingaku9 = g.Sum(p => p.Field<decimal>("金額９")),
                                      kingaku10 = g.Sum(p => p.Field<decimal>("金額１０")),
                                      kingaku11 = g.Sum(p => p.Field<decimal>("金額１１")),
                                      kingaku12 = g.Sum(p => p.Field<decimal>("金額１２")),
                                      kingakuGoukei = g.Sum(p => p.Field<decimal>("金額合計"))
                                  };

                // 営業所計の金額１～金額１２、金額合計の合計算出
                decimal[,] decKingakuEigyo = new decimal[eigyoGoukei.Count(), 13];
                for (int cnt = 0; cnt < eigyoGoukei.Count(); cnt++)
                {
                    decKingakuEigyo[cnt, 0] = eigyoGoukei.ElementAt(cnt).kingaku1;
                    decKingakuEigyo[cnt, 1] = eigyoGoukei.ElementAt(cnt).kingaku2;
                    decKingakuEigyo[cnt, 2] = eigyoGoukei.ElementAt(cnt).kingaku3;
                    decKingakuEigyo[cnt, 3] = eigyoGoukei.ElementAt(cnt).kingaku4;
                    decKingakuEigyo[cnt, 4] = eigyoGoukei.ElementAt(cnt).kingaku5;
                    decKingakuEigyo[cnt, 5] = eigyoGoukei.ElementAt(cnt).kingaku6;
                    decKingakuEigyo[cnt, 6] = eigyoGoukei.ElementAt(cnt).kingaku7;
                    decKingakuEigyo[cnt, 7] = eigyoGoukei.ElementAt(cnt).kingaku8;
                    decKingakuEigyo[cnt, 8] = eigyoGoukei.ElementAt(cnt).kingaku9;
                    decKingakuEigyo[cnt, 9] = eigyoGoukei.ElementAt(cnt).kingaku10;
                    decKingakuEigyo[cnt, 10] = eigyoGoukei.ElementAt(cnt).kingaku11;
                    decKingakuEigyo[cnt, 11] = eigyoGoukei.ElementAt(cnt).kingaku12;
                    decKingakuEigyo[cnt, 12] = eigyoGoukei.ElementAt(cnt).kingakuGoukei;
                }

                // リストをデータテーブルに変換
                DataTable dtChkList = this.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                maxRowCnt += tantoGoukei.Count() + groupGoukei.Count() + eigyoGoukei.Count();
                double page = 1.0 * maxRowCnt / 35;
                double decimalpart = page % 1;
                if (decimalpart != 0)
                {
                    // 小数点以下が0でない場合、+1
                    maxPage = (int)Math.Floor(page) + 1;
                }
                else
                {
                    maxPage = (int)page;
                }

                int tantoCnt = 0;
                int tantoRowCnt = 0;
                int groupCnt = 0;
                int groupRowCnt = 0;
                int eigyoCnt = 0;
                int eigyoRowCnt = 0;
                string strSiireCode = "";

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drSiireSuii in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "分類別仕入推移表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 14;
                        headersheet.Range("A1", "P1").Merge();

                        // 単位出力（P3のセル、右揃え）
                        IXLCell unitCell = headersheet.Cell("P2");
                        unitCell.Value = "（単位：千円）";
                        unitCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                        System.DateTime dateStartYMD = DateTime.Parse(strStartYM + "/01");

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "コード";
                        headersheet.Cell("B3").Value = "仕入先名";
                        headersheet.Cell("C3").Value = "分類名";
                        headersheet.Cell("D3").Value = dateStartYMD.AddMonths(0);
                        headersheet.Cell("E3").Value = dateStartYMD.AddMonths(1);
                        headersheet.Cell("F3").Value = dateStartYMD.AddMonths(2);
                        headersheet.Cell("G3").Value = dateStartYMD.AddMonths(3);
                        headersheet.Cell("H3").Value = dateStartYMD.AddMonths(4);
                        headersheet.Cell("I3").Value = dateStartYMD.AddMonths(5);
                        headersheet.Cell("J3").Value = dateStartYMD.AddMonths(6);
                        headersheet.Cell("K3").Value = dateStartYMD.AddMonths(7);
                        headersheet.Cell("L3").Value = dateStartYMD.AddMonths(8);
                        headersheet.Cell("M3").Value = dateStartYMD.AddMonths(9);
                        headersheet.Cell("N3").Value = dateStartYMD.AddMonths(10);
                        headersheet.Cell("O3").Value = dateStartYMD.AddMonths(11);
                        headersheet.Cell("P3").Value = "合計";

                        // 各月
                        headersheet.Range("D3", "O3").Style.DateFormat.Format = "M月";

                        // ヘッダー列
                        headersheet.Range("A3", "P3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "P3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // 列幅の指定
                        headersheet.Column(1).Width = 6;
                        headersheet.Column(2).Width = 26;
                        headersheet.Column(3).Width = 16;
                        for (int cnt = 4; cnt < 15; cnt++)
                        {
                            headersheet.Column(cnt).Width = 8;
                        }
                        headersheet.Column(16).Width = 10;

                        // 印刷体裁（B4横、印刷範囲）
                        headersheet.PageSetup.PaperSize = XLPaperSize.B4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№48）");

                        // ヘッダーシートからコピー
                        headersheet.CopyTo("Page1");
                        currentsheet = workbook.Worksheet(2);

                        // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
                        strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                            pageCnt.ToString() + " / " + maxPage.ToString();
                        currentsheet.PageSetup.Header.Right.AddText(strHeader);

                    }

                    // 営業所名出力
                    if (eigyoRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt, 1).Value = drSiireSuii[0];
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Merge();

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        xlsRowCnt++;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 39)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // コンピュータ名、日付、ページ数を取得
                            strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                                pageCnt.ToString() + " / " + maxPage.ToString();

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, strHeader);
                        }
                    }

                    // グループ名出力
                    if (groupRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt, 1).Value = drSiireSuii[1];
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Merge();

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        xlsRowCnt++;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 39)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // コンピュータ名、日付、ページ数を取得
                            strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                                pageCnt.ToString() + " / " + maxPage.ToString();

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, strHeader);
                        }
                    }

                    // 担当者名出力
                    if (tantoRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt, 1).Value = drSiireSuii[2];
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Merge();

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        xlsRowCnt++;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 39)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // コンピュータ名、日付、ページ数を取得
                            strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                                pageCnt.ToString() + " / " + maxPage.ToString();

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, strHeader);
                        }
                    }

                    // ヘッダー行の場合
                    if (xlsRowCnt == 3)
                    {
                        // 出力行へ移動
                        xlsRowCnt++;
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 3; colCnt < maxColCnt; colCnt++)
                    {
                        string str = drSiireSuii[colCnt].ToString();

                        // 金額セルの処理
                        if (colCnt >= 6 && colCnt <= 18)
                        {
                            // 3桁毎に","を挿入する
                            str = string.Format("{0:#,0}", decimal.Parse(str));
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, colCnt - 3 + 1);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = str;
                        }

                        // 仕入先コードの場合
                        if (colCnt == 3)
                        {
                            // 最初の行の場合 or 前行の仕入先コードが現在の仕入先コードが同じでない場合
                            if (!drSiireSuii[3].ToString().Equals(strSiireCode))
                            {
                                currentsheet.Cell(xlsRowCnt, colCnt - 3 + 1).Value = str;
                                colCnt++;
                                currentsheet.Cell(xlsRowCnt, colCnt - 3 + 1).Value = drSiireSuii[4].ToString();
                                strSiireCode = drSiireSuii[3].ToString();
                            }
                        }
                        // 仕入先名の場合、仕入先コードの処理で行っているため何もしない
                        else if (colCnt == 4)
                        {
                        }
                        else
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt - 3 + 1).Value = str;
                        }

                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 39)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // コンピュータ名、日付、ページ数を取得
                            strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                                pageCnt.ToString() + " / " + maxPage.ToString();

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, strHeader);
                        }
                    }

                    // 担当者計を出力
                    tantoRowCnt++;
                    if (tantoGoukei.ElementAt(tantoCnt).count == tantoRowCnt)
                    {
                        xlsRowCnt++;
                        // セル結合、中央揃え
                        IXLCell tantocell = currentsheet.Cell(xlsRowCnt, 1);
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 2).Merge();
                        tantocell.Value = "■■　担当者計　■■";
                        tantocell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // 金額セルの処理（3桁毎に","を挿入する）
                        for (int cnt = 0; cnt < 13; cnt++)
                        {
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, cnt + 4);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = string.Format("{0:#,0}", decKingakuTanto[tantoCnt, cnt]);
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        tantoCnt++;
                        rowCnt++;
                        tantoRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 39)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // コンピュータ名、日付、ページ数を取得
                            strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                                pageCnt.ToString() + " / " + maxPage.ToString();

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, strHeader);
                        }
                    }

                    // グループ計を出力
                    groupRowCnt++;
                    if (groupGoukei.ElementAt(groupCnt).count == groupRowCnt)
                    {
                        xlsRowCnt++;
                        // セル結合、中央揃え
                        IXLCell groupcell = currentsheet.Cell(xlsRowCnt, 1);
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 2).Merge();
                        groupcell.Value = "■■　グループ計　■■";
                        groupcell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // 金額セルの処理（3桁毎に","を挿入する）
                        for (int cnt = 0; cnt < 13; cnt++)
                        {
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, cnt + 4);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = string.Format("{0:#,0}", decKingakuGroup[groupCnt, cnt]);
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        groupCnt++;
                        rowCnt++;
                        groupRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 39)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // コンピュータ名、日付、ページ数を取得
                            strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                                pageCnt.ToString() + " / " + maxPage.ToString();

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, strHeader);
                        }
                    }

                    // 営業所計を出力
                    eigyoRowCnt++;
                    if (eigyoGoukei.ElementAt(eigyoCnt).count == eigyoRowCnt)
                    {
                        xlsRowCnt++;
                        // セル結合、中央揃え
                        IXLCell eigyocell = currentsheet.Cell(xlsRowCnt, 1);
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 2).Merge();
                        eigyocell.Value = "■■　営業所計　■■";
                        eigyocell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // 金額セルの処理（3桁毎に","を挿入する）
                        for (int cnt = 0; cnt < 13; cnt++)
                        {
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, cnt + 4);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = string.Format("{0:#,0}", decKingakuEigyo[eigyoCnt, cnt]);
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        eigyoCnt++;
                        rowCnt++;
                        eigyoRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 39)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // コンピュータ名、日付、ページ数を取得
                            strHeader = "（ " + strComputerName + " ）" + strSpace + strNow + strSpace +
                                pageCnt.ToString() + " / " + maxPage.ToString();

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, strHeader);
                        }
                    }

                    // 最終行を出力した後、合計行を出力
                    if (maxRowCnt == rowCnt)
                    {
                        // セル結合、中央揃え
                        IXLCell sumcell = currentsheet.Cell(xlsRowCnt + 1, 1);
                        currentsheet.Range(xlsRowCnt + 1, 1, xlsRowCnt + 1, 2).Merge();
                        sumcell.Value = "■■　合　　計　■■";
                        sumcell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // 金額セルの処理（3桁毎に","を挿入する）
                        for (int cnt = 0; cnt < 13; cnt++)
                        {
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt + 1, cnt + 4);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = string.Format("{0:#,0}", decKingaku[cnt]);
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(xlsRowCnt + 1, 1, xlsRowCnt + 1, 16).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);
                    }

                    rowCnt++;
                    xlsRowCnt++;
                }

                // ヘッダーシート削除
                headersheet.Delete();

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // PDF化の処理
                return createPdf(strOutXlsFile, strDateTime);

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw ex;
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

        /// <summary>
        /// ヘッダーシートをコピーし、ヘッダー部を指定
        /// <param name="workbook">参照型 ワークブック</param>
        /// <param name="headersheet">参照型 ヘッダーシート</param>
        /// <param name="currentsheet">参照型 カレントシート</param>
        /// <param name="pageCnt">ページ数</param>
        /// <param name="strHeader">コンピュータ名、日付、ページ数</param>
        /// </summary>
        private void sheetCopy(ref XLWorkbook workbook, ref IXLWorksheet headersheet, ref IXLWorksheet currentsheet, int pageCnt, string strHeader)
        {
            // ヘッダーシートからコピー
            headersheet.CopyTo("Page" + pageCnt.ToString());
            currentsheet = workbook.Worksheet(pageCnt + 1);

            // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
            currentsheet.PageSetup.Header.Right.AddText(strHeader);
        }

        /// 【共通化可能】
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// PDF化(Spire.xls)の処理
        /// <param name="strInXlsFile">エクセルファイル</param>
        /// <param name="strDateTime">日時</param>
        /// </summary>
        /// -----------------------------------------------------------------------------
        private string createPdf(string strInXlsFile, string strDateTime)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strPdfPath = System.Configuration.ConfigurationManager.AppSettings["pdfpath"];
            string strJoinPdfFile;

            try
            {

                Workbook printbook = new Workbook();
                printbook.LoadFromFile(strInXlsFile, ExcelVersion.Version2010);
                int sheetMax = printbook.Worksheets.Count;

                // Excelシートの枚数分PDF化
                for (int sheetCnt = 0; sheetCnt < sheetMax; sheetCnt++)
                {
                    // pdf化するシートを取得
                    Worksheet printsheet = printbook.Worksheets[sheetCnt];

                    string no = no = (sheetCnt + 1).ToString();
                    if (no.Length == 1)
                    {
                        no = "0" + no;
                    }

                    string strPdfFile = strWorkPath + strDateTime + "_" + no + ".pdf";

                    // 出力したいシートをPDFで保存
                    printsheet.SaveToPdf(strPdfFile);

                    // シートカウントが0の場合結合用のPDFを保存
                    if (sheetCnt == 0)
                    {
                        string strJoinyouPdfFile = strPdfPath + strDateTime + ".pdf";

                        // 出力したいシートをPDFで保存
                        printsheet.SaveToPdf(strJoinyouPdfFile);
                    }
                }
                // printbookを解放
                printbook.Dispose();

                // フォルダ下の作成日時".pdf"ファイルをすべて取得する
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strWorkPath);
                System.IO.FileInfo[] fiFiles = di.GetFiles(strDateTime + "*.pdf", System.IO.SearchOption.AllDirectories);
                Array.Sort<FileInfo>(fiFiles, delegate (FileInfo f1, FileInfo f2)
                {
                    // ファイル名でソート
                    return f1.Name.CompareTo(f2.Name);
                });
                int filesMax = fiFiles.Count();
                string[] strFiles = new string[filesMax];

                // FileInfo配列をstring配列に
                for (int fileCnt = 0; fileCnt < filesMax; fileCnt++)
                {
                    strFiles[fileCnt] = strWorkPath + fiFiles[fileCnt].Name;
                }

                // 結合PDFオブジェクト
                strJoinPdfFile = strPdfPath + strDateTime + ".pdf";

                // PDFファイル数が0でなければ結合
                if (filesMax != 0)
                {
                    fnJoinPdf(strFiles, strJoinPdfFile, 1);
                }

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw ex;
            }
            return strJoinPdfFile;
        }


        /// 【共通化可能】
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// PDFファイルの結合
        /// WritePage = 0：全ページ、WritePage = 1：全ファイルの1ページのみ
        /// WritePage = 2(3...)：全ファイルの1～2(1～3)ページ
        /// </summary>
        /// <param name="sSrcFilePath1">入力ファイルパス1</param>
        /// <param name="sSrcFilePath2">入力ファイルパス2</param>
        /// <param name="sJoinFilePath">結合ファイルパス</param>
        /// <param name="WritePage">結合ページ数</param>
        /// -----------------------------------------------------------------------------
        private void fnJoinPdf(string[] arySrcFilePath, string sJoinFilePath, int WritePage)
        {
            Document doc = null;    // 出力ファイルDocument
            PdfCopy copy = null;    // 出力ファイルPdfCopy

            try
            {
                //-------------------------------------------------------------------------------------
                // ファイル件数分、ファイル結合
                //-------------------------------------------------------------------------------------
                for (int i = 0; i < arySrcFilePath.Length; i++)
                {
                    // リーダー取得
                    PdfReader reader = new PdfReader(arySrcFilePath[i]);
                    // 入力ファイル1を出力ファイルの雛形にする
                    if (i == 0)
                    {
                        // Document作成
                        doc = new Document(reader.GetPageSizeWithRotation(1));
                        // 出力ファイルPdfCopy作成
                        copy = new PdfCopy(doc, new FileStream(sJoinFilePath, FileMode.Create));
                        // 出力ファイルDocumentを開く
                        doc.Open();
                        // 文章プロパティ設定
                        //doc.AddKeywords((string)reader.Info["Keywords"]);
                        //doc.AddAuthor((string)reader.Info["Author"]);
                        //doc.AddTitle((string)reader.Info["Title"]);
                        //doc.AddCreator((string)reader.Info["Creator"]);
                        //doc.AddSubject((string)reader.Info["Subject"]);
                    }
                    // 結合するPDFのページ数
                    if (WritePage == 0) WritePage = reader.NumberOfPages;
                    if (WritePage > reader.NumberOfPages) WritePage = reader.NumberOfPages;

                    // PDFコンテンツを取得、copyオブジェクトに追加
                    for (int iPageCnt = 1; iPageCnt <= WritePage; iPageCnt++)
                    {
                        PdfImportedPage page = copy.GetImportedPage(reader, iPageCnt);
                        copy.AddPage(page);
                    }
                    // フォーム入力を結合
                    PRAcroForm form = reader.AcroForm;
                    if (form != null)
                        copy.AddDocument(reader);
                    // リーダーを閉じる
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                throw ex;
            }
            finally
            {
                if (copy != null)
                    copy.Close();
                if (doc != null)
                    doc.Close();
            }
        }


        /// -----------------------------------------------------------------------------------------
        /// <summary>
        /// ListをDataTableへ変換
        /// </summary>
        /// -----------------------------------------------------------------------------------------
        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

    }
}
