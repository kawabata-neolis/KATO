using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KATO.Common.Util;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Spire.Xls;
using ClosedXML.Excel;

//iTextSharp関連の名前空間
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.ComponentModel;
using System.IO;

namespace KATO.Business.C0490_UriageSuiiHyo
{
    ///<summary>
    ///C0490_UriageSuiiHyo_B
    ///分類別売上推移表ビジネス層
    ///作成者：TMSOL太田
    ///作成日：2017/06/15
    ///更新者：
    ///更新日：
    ///カラム論理名
    class C0490_UriageSuiiHyo_B
    {
        ///<summary>
        ///getUriageSuiiList
        ///売上推移を取得
        ///</summary>
        public DataTable getUriageSuiiList(List<string> lstString, string strType)
        {
            DataTable dtGetTableGrid = new DataTable();

            //大分類コードが空欄の場合
            if (lstString[4] == "")
            {
                //メーカコードが空欄の場合
                if (lstString[10] == "")
                {
                    //DISP0 無指定へ
                    dtGetTableGrid = this.DISP0(lstString, strType);
                }
                else
                {
                    //DISP4 メーカーのみを指定へ
                    dtGetTableGrid = this.DISP4(lstString, strType);
                }
            }
            else
            {
                //中分類が空欄の場合
                if (lstString[7] == "")
                {
                    //DISP1 大分類を指定へ
                    dtGetTableGrid = this.DISP1(lstString, strType);
                }
                else
                {
                    //メーカコードが空欄の場合
                    if (lstString[10] == "")
                    {
                        //DISP2 大分類,中分類を指定へ
                        dtGetTableGrid = this.DISP2(lstString, strType);
                    }
                    else
                    {
                        //DISP3 大分類,中分類,メーカーを指定へ
                        dtGetTableGrid = this.DISP3(lstString, strType);
                    }
                }
            }

            return dtGetTableGrid;
        }

        ///<summary>
        ///DISP0 無指定
        ///分類コードが空欄かつ、メーカーコードが空欄
        ///</summary>
        public DataTable DISP0(List<string> lstString, string strType)
        {
            DataTable dtGetTableGrid = new DataTable();

            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;
            System.DateTime dateGetumatuYMD;

            dateStartYMD = DateTime.Parse(lstString[0] + "/01");

            dateEndYMD = DateTime.Parse(lstString[1] + "/01");

            dateGetumatuYMD = dateStartYMD.AddMonths(1);
            dateGetumatuYMD = dateGetumatuYMD.AddDays(-1);    //月末

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文　DISP0　無指定

            strSQLInput = strSQLInput + " SELECT ";

            //表示の場合
            if (strType.Equals("disp"))
            {
                strSQLInput = strSQLInput + " 得意先コード, 得意先名, 区分, 大分類コード, 中分類コード, メーカーコード, 分類名, SUM(金額１) AS 金額１, SUM(金額２) AS 金額２, SUM(金額３) AS 金額３, SUM(金額４) AS 金額４, SUM(金額５) AS 金額５, SUM(金額６) AS 金額６, SUM(金額７) AS 金額７, SUM(金額８) AS 金額８, SUM(金額９) AS 金額９, SUM(金額１０) AS 金額１０, SUM(金額１１) AS 金額１１, SUM(金額１２) AS 金額１２, SUM(金額合計) AS 金額合計 FROM( SELECT ";
            }
                strSQLInput = strSQLInput + " z.営業所コード, dbo.f_get営業所名(z.営業所コード) AS 営業所名, z.グループコード, dbo.f_getグループ名(z.グループコード) AS グループ名, z.担当者コード, dbo.f_get担当者名(z.担当者コード) AS 担当者名, z.得意先コード, dbo.f_get取引先名称(z.得意先コード) AS 得意先名, 0 AS 区分, z.大分類コード, NULL AS 中分類コード, NULL AS メーカーコード, dbo.f_get大分類名(z.大分類コード) AS 分類名 ";

            //金額1～12の作成
            for (int count = 0; count <= 11; count++)
            {
                //全角数字用配列
                List<string> lstZenkakuNum = new List<string>() { "１", "２", "３", "４", "５", "６", "７", "８", "９", "１０", "１１", "１２" };
                strSQLInput = strSQLInput + " , ROUND(dbo.f_分類別売上推移表_売上高_大分類_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0) AS 金額" + lstZenkakuNum[count].ToString();
            }

            //金額合計の作成
            strSQLInput = strSQLInput + ",";
            for (int count = 0; count <= 11; count++)
            {
                //カウント0以外には先頭に＋を付与する
                if (count == 0)
                {
                    strSQLInput = strSQLInput + " ROUND(dbo.f_分類別売上推移表_売上高_大分類_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
                else
                {
                    strSQLInput = strSQLInput + "+ ROUND(dbo.f_分類別売上推移表_売上高_大分類_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
            }
            strSQLInput = strSQLInput + " AS 金額合計";

            strSQLInput = strSQLInput + " FROM( SELECT DISTINCT d.営業所コード, d.グループコード, d.担当者コード, a.得意先コード, b.大分類コード FROM 売上ヘッダ a, 売上明細 b, 取引先 c, 担当者 d, グループ e ";
            strSQLInput = strSQLInput + " WHERE a.削除 = 'N' AND a.伝票番号 = b.伝票番号 AND a.伝票年月日 >= '" + dateStartYMD + "' AND a.伝票年月日 <= '" + dateEndYMD + "' AND a.得意先コード >= '" + lstString[2] + "' AND a.得意先コード <= '" + lstString[3] + "' AND c.取引先コード = a.得意先コード AND d.担当者コード = c.担当者コード AND e.グループコード = d.グループコード ";

            if (lstString[5] != "")
            {
                strSQLInput = strSQLInput + " AND d.営業所コード ='" + lstString[5] + "'";
            }

            if (lstString[8] != "")
            {
                strSQLInput = strSQLInput + " AND d.グループコード='" + lstString[8] + "'";
            }

            if (lstString[6] != "")
            {
                strSQLInput = strSQLInput + " AND d.担当者コード ='" + lstString[6] + "'";
            }

            if (lstString[9] != "")
            {
                strSQLInput = strSQLInput + " AND a.担当者コード='" + lstString[9] + "'";
            }

            strSQLInput = strSQLInput + " ) z ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSQLInput = strSQLInput + ") y GROUP BY 得意先コード, 得意先名, 区分, 大分類コード, 中分類コード, メーカーコード, 分類名 ORDER BY 得意先コード, 大分類コード, 中分類コード, メーカーコード ";
            }
            else
            {
                strSQLInput = strSQLInput + " ORDER BY Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード ";
            }

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                //テスト
                MessageBox.Show("エラーが発生しました。前回の検索結果を表示します\r\n"+ex,
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return (dtGetTableGrid);

        }

        ///<summary>
        ///DISP1 大分類を指定
        ///分類コードを入力かつ中分類コードが空欄の場合
        ///</summary>
        public DataTable DISP1(List<string> lstString, string strType)
        {
            DataTable dtGetTableGrid = new DataTable();

            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;
            System.DateTime dateGetumatuYMD;

            dateStartYMD = DateTime.Parse(lstString[0] + "/01");

            dateEndYMD = DateTime.Parse(lstString[1] + "/01");

            dateGetumatuYMD = dateStartYMD.AddMonths(1);
            dateGetumatuYMD = dateGetumatuYMD.AddDays(-1);    //月末

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文　DISP1

            strSQLInput = strSQLInput + " SELECT ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSQLInput = strSQLInput + " 得意先コード, 得意先名, 区分, 大分類コード, 中分類コード, メーカーコード, 分類名, SUM(金額１) AS 金額１, SUM(金額２) AS 金額２, SUM(金額３) AS 金額３, SUM(金額４) AS 金額４, SUM(金額５) AS 金額５, SUM(金額６) AS 金額６, SUM(金額７) AS 金額７, SUM(金額８) AS 金額８, SUM(金額９) AS 金額９, SUM(金額１０) AS 金額１０, SUM(金額１１) AS 金額１１, SUM(金額１２) AS 金額１２, SUM(金額合計) AS 金額合計 FROM (SELECT ";
            }
            strSQLInput = strSQLInput + " z.営業所コード, dbo.f_get営業所名(z.営業所コード) AS 営業所名, z.グループコード, dbo.f_getグループ名(z.グループコード) AS グループ名, z.担当者コード, dbo.f_get担当者名(z.担当者コード) AS 担当者名, z.得意先コード, dbo.f_get取引先名称(z.得意先コード) AS 得意先名, 1 AS 区分, z.大分類コード, z.中分類コード, NULL AS メーカーコード, dbo.f_get中分類名(z.大分類コード, z.中分類コード) AS 分類名 ";

            //金額1～12の作成
            for (int count = 0; count <= 11; count++)
            {
                //全角数字用配列
                List<string> lstZenkakuNum = new List<string>() { "１", "２", "３", "４", "５", "６", "７", "８", "９", "１０", "１１", "１２" };
                strSQLInput = strSQLInput + " , ROUND(dbo.f_分類別売上推移表_売上高_中分類_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, z.中分類コード, '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0) AS 金額" + lstZenkakuNum[count].ToString();
            }

            //金額合計の作成
            strSQLInput = strSQLInput + ",";
            for (int count = 0; count <= 11; count++)
            {
                //カウント0以外には先頭に＋を付与する
                if (count == 0)
                {
                    strSQLInput = strSQLInput + " ROUND(dbo.f_分類別売上推移表_売上高_中分類_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, z.中分類コード,  '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
                else
                {
                    strSQLInput = strSQLInput + "+ ROUND(dbo.f_分類別売上推移表_売上高_中分類_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, z.中分類コード,  '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
            }
            strSQLInput = strSQLInput + " AS 金額合計";

            strSQLInput = strSQLInput + " FROM (SELECT DISTINCT d.営業所コード, d.グループコード, d.担当者コード, a.得意先コード, b.大分類コード, b.中分類コード FROM 売上ヘッダ a, 売上明細 b, 取引先 c, 担当者 d, グループ e ";
            strSQLInput = strSQLInput + " WHERE a.削除 = 'N' AND a.伝票番号 = b.伝票番号 AND a.伝票年月日 >= '" + dateStartYMD + "' AND a.伝票年月日 <= '" + dateEndYMD + "' AND a.得意先コード >= '" + lstString[2] + "' AND a.得意先コード <= '" + lstString[3] + "' AND b.大分類コード ='"+lstString[4]+"'  AND c.取引先コード = a.得意先コード AND d.担当者コード = c.担当者コード AND e.グループコード = d.グループコード ";

            if (lstString[5] != "")
            {
                strSQLInput = strSQLInput + " AND d.営業所コード ='" + lstString[5] + "'";
            }

            if (lstString[8] != "")
            {
                strSQLInput = strSQLInput + " AND d.グループコード='" + lstString[8] + "'";
            }

            if (lstString[6] != "")
            {
                strSQLInput = strSQLInput + " AND d.担当者コード ='" + lstString[6] + "'";
            }

            if (lstString[9] != "")
            {
                strSQLInput = strSQLInput + " AND a.担当者コード='" + lstString[9] + "'";
            }

            strSQLInput = strSQLInput + " ) z ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSQLInput = strSQLInput + " )y GROUP BY 得意先コード, 得意先名, 区分, 大分類コード, 中分類コード, メーカーコード, 分類名 ORDER BY 得意先コード, 大分類コード, 中分類コード, メーカーコード ";
            }
            else
            {
                strSQLInput = strSQLInput + " ORDER BY Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード,z.中分類コード ";
            }

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
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
            return (dtGetTableGrid);

        }

        ///<summary>
        ///DISP2 大分類,中分類を指定
        ///分類コードを入力かつ中分類コードを入力かつメーカコードが空欄の場合
        ///</summary>
        public DataTable DISP2(List<string> lstString, string strType)
        {
            DataTable dtGetTableGrid = new DataTable();

            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;
            System.DateTime dateGetumatuYMD;

            dateStartYMD = DateTime.Parse(lstString[0] + "/01");

            dateEndYMD = DateTime.Parse(lstString[1] + "/01");

            dateGetumatuYMD = dateStartYMD.AddMonths(1);
            dateGetumatuYMD = dateGetumatuYMD.AddDays(-1);    //月末

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文　DISP2

            strSQLInput = strSQLInput + " SELECT ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSQLInput = strSQLInput + " 得意先コード, 得意先名, 区分, 大分類コード, 中分類コード, メーカーコード, 分類名, SUM(金額１) AS 金額１, SUM(金額２) AS 金額２, SUM(金額３) AS 金額３, SUM(金額４) AS 金額４, SUM(金額５) AS 金額５, SUM(金額６) AS 金額６, SUM(金額７) AS 金額７, SUM(金額８) AS 金額８, SUM(金額９) AS 金額９, SUM(金額１０) AS 金額１０, SUM(金額１１) AS 金額１１, SUM(金額１２) AS 金額１２, SUM(金額合計) AS 金額合計 FROM (SELECT ";
            }
                strSQLInput = strSQLInput + " z.営業所コード, dbo.f_get営業所名(z.営業所コード) AS 営業所名, z.グループコード, dbo.f_getグループ名(z.グループコード) AS グループ名, z.担当者コード, dbo.f_get担当者名(z.担当者コード) AS 担当者名, z.得意先コード, dbo.f_get取引先名称(z.得意先コード) AS 得意先名, 2 AS 区分, z.大分類コード, z.中分類コード, z.メーカーコード, dbo.f_getメーカー名(z.メーカーコード) AS 分類名 ";

            //金額1～12の作成
            for (int count = 0; count <= 11; count++)
            {
                //全角数字用配列
                List<string> lstZenkakuNum = new List<string>() { "１", "２", "３", "４", "５", "６", "７", "８", "９", "１０", "１１", "１２" };
                strSQLInput = strSQLInput + " , ROUND(dbo.f_分類別売上推移表_売上高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, z.中分類コード, z.メーカーコード,  '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0) AS 金額" + lstZenkakuNum[count].ToString();
            }

            //金額合計の作成
            strSQLInput = strSQLInput + ",";
            for (int count = 0; count <= 11; count++)
            {
                //カウント0以外には先頭に＋を付与する
                if (count == 0)
                {
                    strSQLInput = strSQLInput + " ROUND(dbo.f_分類別売上推移表_売上高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, z.中分類コード, z.メーカーコード,   '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
                else
                {
                    strSQLInput = strSQLInput + "+ ROUND(dbo.f_分類別売上推移表_売上高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, z.中分類コード, z.メーカーコード,   '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
            }
            strSQLInput = strSQLInput + " AS 金額合計";

            strSQLInput = strSQLInput + " FROM (SELECT DISTINCT d.営業所コード, d.グループコード, d.担当者コード, a.得意先コード, b.大分類コード, b.中分類コード, b.メーカーコード FROM 売上ヘッダ a, 売上明細 b, 取引先 c, 担当者 d, グループ e ";
            strSQLInput = strSQLInput + " WHERE a.削除 = 'N' AND a.伝票番号 = b.伝票番号 AND a.伝票年月日 >= '" + dateStartYMD + "' AND a.伝票年月日 <= '" + dateEndYMD + "' AND a.得意先コード >= '" + lstString[2] + "' AND a.得意先コード <= '" + lstString[3] + "' AND b.大分類コード ='" + lstString[4] + "' AND b.中分類コード ='"+lstString[7]+"'  AND c.取引先コード = a.得意先コード AND d.担当者コード = c.担当者コード AND e.グループコード = d.グループコード ";

            if (lstString[5] != "")
            {
                strSQLInput = strSQLInput + " AND d.営業所コード ='" + lstString[5] + "'";
            }

            if (lstString[8] != "")
            {
                strSQLInput = strSQLInput + " AND d.グループコード='" + lstString[8] + "'";
            }

            if (lstString[6] != "")
            {
                strSQLInput = strSQLInput + " AND d.担当者コード ='" + lstString[6] + "'";
            }

            if (lstString[9] != "")
            {
                strSQLInput = strSQLInput + " AND a.担当者コード='" + lstString[9] + "'";
            }

            strSQLInput = strSQLInput + " ) z ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSQLInput = strSQLInput + ") y GROUP BY 得意先コード, 得意先名, 区分, 大分類コード, 中分類コード, メーカーコード, 分類名 ORDER BY 得意先コード, 大分類コード, 中分類コード, メーカーコード ";
            }
            else
            {
                strSQLInput = strSQLInput + " ORDER BY Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード,z.中分類コード,z.メーカーコード ";
            }


            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
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
            return (dtGetTableGrid);

        }

        ///<summary>
        ///DISP3 大分類,中分類,メーカーを指定
        ///分類コードを入力かつ中分類コードを入力かつメーカコードを入力した場合
        ///</summary>
        public DataTable DISP3(List<string> lstString, string strType)
        {
            DataTable dtGetTableGrid = new DataTable();

            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;
            System.DateTime dateGetumatuYMD;

            dateStartYMD = DateTime.Parse(lstString[0] + "/01");

            dateEndYMD = DateTime.Parse(lstString[1] + "/01");

            dateGetumatuYMD = dateStartYMD.AddMonths(1);
            dateGetumatuYMD = dateGetumatuYMD.AddDays(-1);    //月末

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文　DISP3

            strSQLInput = strSQLInput + " SELECT ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSQLInput = strSQLInput + " 得意先コード, 得意先名, 区分, 大分類コード, 中分類コード, メーカーコード, 分類名, SUM(金額１) AS 金額１, SUM(金額２) AS 金額２, SUM(金額３) AS 金額３, SUM(金額４) AS 金額４, SUM(金額５) AS 金額５, SUM(金額６) AS 金額６, SUM(金額７) AS 金額７, SUM(金額８) AS 金額８, SUM(金額９) AS 金額９, SUM(金額１０) AS 金額１０, SUM(金額１１) AS 金額１１, SUM(金額１２) AS 金額１２, SUM(金額合計) AS 金額合計 FROM (SELECT ";
            }

            strSQLInput = strSQLInput + " z.営業所コード, dbo.f_get営業所名(z.営業所コード) AS 営業所名, z.グループコード, dbo.f_getグループ名(z.グループコード) AS グループ名, z.担当者コード, dbo.f_get担当者名(z.担当者コード) AS 担当者名, z.得意先コード, dbo.f_get取引先名称(z.得意先コード) AS 得意先名, 3 AS 区分, z.大分類コード, z.中分類コード, z.メーカーコード, dbo.f_getメーカー名(z.メーカーコード) AS 分類名 ";

            //金額1～12の作成
            for (int count = 0; count <= 11; count++)
            {
                //全角数字用配列
                List<string> lstZenkakuNum = new List<string>() { "１", "２", "３", "４", "５", "６", "７", "８", "９", "１０", "１１", "１２" };
                strSQLInput = strSQLInput + " , ROUND(dbo.f_分類別売上推移表_売上高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, z.中分類コード, z.メーカーコード, '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0) AS 金額" + lstZenkakuNum[count].ToString();
            }

            //金額合計の作成
            strSQLInput = strSQLInput + ",";
            for (int count = 0; count <= 11; count++)
            {
                //カウント0以外には先頭に＋を付与する
                if (count == 0)
                {
                    strSQLInput = strSQLInput + " ROUND(dbo.f_分類別売上推移表_売上高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, z.中分類コード, z.メーカーコード, '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
                else
                {
                    strSQLInput = strSQLInput + "+ ROUND(dbo.f_分類別売上推移表_売上高_メーカー_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード, z.中分類コード, z.メーカーコード,  '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
            }
            strSQLInput = strSQLInput + " AS 金額合計";

            strSQLInput = strSQLInput + " FROM (SELECT DISTINCT d.営業所コード, d.グループコード, d.担当者コード, a.得意先コード, b.大分類コード, b.中分類コード, b.メーカーコード FROM 売上ヘッダ a, 売上明細 b, 取引先 c, 担当者 d, グループ e";
            strSQLInput = strSQLInput + " WHERE a.削除 = 'N' AND a.伝票番号 = b.伝票番号 AND a.伝票年月日 >= '" + dateStartYMD + "' AND a.伝票年月日 <= '" + dateEndYMD + "' AND a.得意先コード >= '" + lstString[2] + "' AND a.得意先コード <= '" + lstString[3] + "' AND b.大分類コード ='" + lstString[4] + "' AND b.中分類コード ='" + lstString[7] + "'　AND b.メーカーコード ='"+lstString[10]+"'  AND c.取引先コード = a.得意先コード AND d.担当者コード = c.担当者コード AND e.グループコード = d.グループコード ";

            if (lstString[5] != "")
            {
                strSQLInput = strSQLInput + " AND d.営業所コード ='" + lstString[5] + "'";
            }

            if (lstString[8] != "")
            {
                strSQLInput = strSQLInput + " AND d.グループコード='" + lstString[8] + "'";
            }

            if (lstString[6] != "")
            {
                strSQLInput = strSQLInput + " AND d.担当者コード ='" + lstString[6] + "'";
            }

            if (lstString[9] != "")
            {
                strSQLInput = strSQLInput + " AND a.担当者コード='" + lstString[9] + "'";
            }

            strSQLInput = strSQLInput + " ) z ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSQLInput = strSQLInput + ") y GROUP BY 得意先コード, 得意先名, 区分, 大分類コード, 中分類コード, メーカーコード, 分類名 ORDER BY 得意先コード, 大分類コード, 中分類コード, メーカーコード ";
            }
            else
            {
                strSQLInput = strSQLInput + " ORDER BY Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.大分類コード,z.中分類コード,z.メーカーコード ";
            }

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
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
            return (dtGetTableGrid);

        }

        ///<summary>
        ///DISP4 メーカーのみを指定へ
        ///分類コードが空欄かつ、メーカーコードを指定の場合
        ///</summary>
        public DataTable DISP4(List<string> lstString, string strType)
        {
            DataTable dtGetTableGrid = new DataTable();

            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;
            System.DateTime dateGetumatuYMD;

            dateStartYMD = DateTime.Parse(lstString[0] + "/01");

            dateEndYMD = DateTime.Parse(lstString[1] + "/01");

            dateGetumatuYMD = dateStartYMD.AddMonths(1);
            dateGetumatuYMD = dateGetumatuYMD.AddDays(-1);    //月末

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文　DISP4　メーカーのみを指定へ

            strSQLInput = strSQLInput + " SELECT ";

            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSQLInput = strSQLInput + " 得意先コード, 得意先名, 区分, 大分類コード, 中分類コード, メーカーコード, 分類名, SUM(金額１) AS 金額１, SUM(金額２) AS 金額２, SUM(金額３) AS 金額３, SUM(金額４) AS 金額４, SUM(金額５) AS 金額５, SUM(金額６) AS 金額６, SUM(金額７) AS 金額７, SUM(金額８) AS 金額８, SUM(金額９) AS 金額９, SUM(金額１０) AS 金額１０, SUM(金額１１) AS 金額１１, SUM(金額１２) AS 金額１２, SUM(金額合計) AS 金額合計 FROM (SELECT ";
            }

            strSQLInput = strSQLInput + " z.営業所コード, dbo.f_get営業所名(z.営業所コード) AS 営業所名, z.グループコード, dbo.f_getグループ名(z.グループコード) AS グループ名, z.担当者コード, dbo.f_get担当者名(z.担当者コード) AS 担当者名, z.得意先コード, dbo.f_get取引先名称(z.得意先コード) AS 得意先名, 4 AS 区分, NULL AS 大分類コード, NULL AS 中分類コード, z.メーカーコード, dbo.f_getメーカー名(z.メーカーコード) AS 分類名 ";

            //金額1～12の作成
            for (int count = 0; count <= 11; count++)
            {
                //全角数字用配列
                List<string> lstZenkakuNum = new List<string>() { "１", "２", "３", "４", "５", "６", "７", "８", "９", "１０", "１１", "１２" };
                strSQLInput = strSQLInput + " , ROUND(dbo.f_分類別売上推移表_売上高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.メーカーコード, '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0) AS 金額" + lstZenkakuNum[count].ToString();
            }

            //金額合計の作成
            strSQLInput = strSQLInput + ",";
            for (int count = 0; count <= 11; count++)
            {
                //カウント0以外には先頭に＋を付与する
                if (count == 0)
                {
                    strSQLInput = strSQLInput + " ROUND(dbo.f_分類別売上推移表_売上高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.メーカーコード, '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
                else
                {
                    strSQLInput = strSQLInput + "+ ROUND(dbo.f_分類別売上推移表_売上高_メーカーのみ_拠点グループ別(Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.メーカーコード, '" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
            }
            strSQLInput = strSQLInput + " AS 金額合計";

            strSQLInput = strSQLInput + " FROM (SELECT DISTINCT d.営業所コード, d.グループコード, d.担当者コード, a.得意先コード, b.メーカーコード FROM 売上ヘッダ a, 売上明細 b, 取引先 c, 担当者 d, グループ e ";
            strSQLInput = strSQLInput + " WHERE a.削除 = 'N' AND a.伝票番号 = b.伝票番号 AND a.伝票年月日 >= '" + dateStartYMD + "' AND a.伝票年月日 <= '" + dateEndYMD + "' AND a.得意先コード >= '" + lstString[2] + "' AND a.得意先コード <= '" + lstString[3] + "' AND b.メーカーコード = '"+lstString[10]+"' AND c.取引先コード = a.得意先コード AND d.担当者コード = c.担当者コード AND e.グループコード = d.グループコード ";

            if (lstString[5] != "")
            {
                strSQLInput = strSQLInput + " AND d.営業所コード ='" + lstString[5] + "'";
            }

            if (lstString[8] != "")
            {
                strSQLInput = strSQLInput + " AND d.グループコード='" + lstString[8] + "'";
            }

            if (lstString[6] != "")
            {
                strSQLInput = strSQLInput + " AND d.担当者コード ='" + lstString[6] + "'";
            }

            if (lstString[9] != "")
            {
                strSQLInput = strSQLInput + " AND a.担当者コード='" + lstString[9] + "'";
            }

            strSQLInput = strSQLInput + " ) z ";
            // 表示の場合
            if (strType.Equals("disp"))
            {
                strSQLInput = strSQLInput + " ) y GROUP BY 得意先コード, 得意先名, 区分, 大分類コード, 中分類コード, メーカーコード, 分類名 ORDER BY 得意先コード, 大分類コード, 中分類コード, メーカーコード ";
            }
            else
            {
                strSQLInput = strSQLInput + " ORDER BY Z.営業所コード, z.グループコード, z.担当者コード, z.得意先コード, z.メーカーコード ";
            }


            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
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
            return (dtGetTableGrid);

        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtSiireSuiiList">
        ///     仕入推移表のデータテーブル</param>
        /// -----------------------------------------------------------------------------
        public void dbToPdf(DataTable dtSiireSuiiList, string strStartYM)
        {
            string strTmpPath = System.Configuration.ConfigurationManager.AppSettings["tmppath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {

                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled);
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
                        siireCode = dat["得意先コード"],
                        siireName = dat["得意先名"],
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

                // リストをデータテーブルに変換
                DataTable dtChkList = this.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 1;  // Excel出力行カウント     1から5に変更すること
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                double page = 1.0 * maxRowCnt / 30;
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

                maxRowCnt += tantoGoukei.Count() + groupGoukei.Count() + eigyoGoukei.Count();
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
                        titleCell.Value = "分類別売上推移表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        headersheet.Range("A1", "P1").Merge();

                        // 単位出力（P3のセル、右揃え）
                        IXLCell unitCell = headersheet.Cell("P3");
                        unitCell.Value = "（単位：千円）";
                        unitCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                        System.DateTime dateStartYMD = DateTime.Parse(strStartYM + "/01");

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A4").Value = "コード";
                        headersheet.Cell("B4").Value = "得意先名";
                        headersheet.Cell("C4").Value = "分類名";
                        headersheet.Cell("D4").Value = dateStartYMD.AddMonths(0);  // 金額１
                        headersheet.Cell("D4").Style.DateFormat.Format = "M月";
                        headersheet.Cell("E4").Value = dateStartYMD.AddMonths(1);
                        headersheet.Cell("F4").Value = dateStartYMD.AddMonths(2);
                        headersheet.Cell("G4").Value = dateStartYMD.AddMonths(3);
                        headersheet.Cell("H4").Value = dateStartYMD.AddMonths(4);
                        headersheet.Cell("I4").Value = dateStartYMD.AddMonths(5);
                        headersheet.Cell("J4").Value = dateStartYMD.AddMonths(6);
                        headersheet.Cell("K4").Value = dateStartYMD.AddMonths(7);
                        headersheet.Cell("L4").Value = dateStartYMD.AddMonths(8);
                        headersheet.Cell("M4").Value = dateStartYMD.AddMonths(9);
                        headersheet.Cell("N4").Value = dateStartYMD.AddMonths(10);
                        headersheet.Cell("O4").Value = dateStartYMD.AddMonths(11);
                        headersheet.Cell("P4").Value = "合計";  // 金額合計

                        // セルの周囲に罫線を引く
                        headersheet.Range("A4", "P4").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // 印刷体裁（横、印刷範囲）
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;

                        // ヘッダーシートからコピー
                        headersheet.CopyTo("Page1");
                        currentsheet = workbook.Worksheet(2);

                        // ページ数出力（P2のセル）
                        currentsheet.Cell("P2").Value = "'" + pageCnt.ToString() + " / " + maxPage.ToString();

                    }

                    // 営業所名出力
                    if (eigyoRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt + 4, 1).Value = drSiireSuii[0];
                        currentsheet.Range(xlsRowCnt + 4, 1, xlsRowCnt + 4, 16).Merge();

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(currentsheet.Cell(xlsRowCnt + 4, 1), (currentsheet.Cell(xlsRowCnt + 4, 16))).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        xlsRowCnt++;
                    }

                    // グループ名出力
                    if (groupRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt + 4, 1).Value = drSiireSuii[1];
                        currentsheet.Range(xlsRowCnt + 4, 1, xlsRowCnt + 4, 16).Merge();

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(currentsheet.Cell(xlsRowCnt + 4, 1), (currentsheet.Cell(xlsRowCnt + 4, 16))).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        xlsRowCnt++;
                    }

                    // 担当者名出力
                    if (tantoRowCnt == 0)
                    {
                        currentsheet.Cell(xlsRowCnt + 4, 1).Value = drSiireSuii[2];
                        currentsheet.Range(xlsRowCnt + 4, 1, xlsRowCnt + 4, 16).Merge();

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(currentsheet.Cell(xlsRowCnt + 4, 1), (currentsheet.Cell(xlsRowCnt + 4, 16))).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

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
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt + 4, colCnt - 3 + 1);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = str;
                        }

                        // 得意先コードと得意先名の場合
                        if (colCnt == 3)
                        {
                            // 最初の行の場合 or 前行の得意先コードが現在の得意先コードが同じでない場合
                            if (!drSiireSuii[3].ToString().Equals(strSiireCode))
                            {
                                currentsheet.Cell(xlsRowCnt + 4, colCnt - 3 + 1).Value = str;
                                colCnt++;
                                currentsheet.Cell(xlsRowCnt + 4, colCnt - 3 + 1).Value = drSiireSuii[4].ToString();
                                strSiireCode = drSiireSuii[3].ToString();
                            }
                        }
                        else
                        {
                            currentsheet.Cell(xlsRowCnt + 4, colCnt - 3 + 1).Value = str;
                        }

                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(currentsheet.Cell(xlsRowCnt + 4, 1), (currentsheet.Cell(xlsRowCnt + 4, 16))).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 30行毎にシート作成
                    if (rowCnt % 30 == 0)
                    {
                        pageCnt++;

                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 0;  // 0から4に変更すること

                            // ヘッダーシートからコピー
                            headersheet.CopyTo("Page" + pageCnt.ToString());
                            currentsheet = workbook.Worksheet(pageCnt + 1);

                            // ページ数出力（P2のセル）
                            currentsheet.Cell("P2").Value = "'" + pageCnt.ToString() + " / " + maxPage.ToString();

                        }
                    }

                    // 担当者計を出力
                    tantoRowCnt++;
                    if (tantoGoukei.ElementAt(tantoCnt).count == tantoRowCnt)
                    {
                        xlsRowCnt++;
                        // セル結合、中央揃え
                        IXLCell tantocell = currentsheet.Cell(xlsRowCnt + 4, 1);
                        currentsheet.Range(xlsRowCnt + 4, 1, xlsRowCnt + 4, 2).Merge();
                        tantocell.Value = "■■　担当者計　■■";
                        tantocell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // 金額セルの処理（3桁毎に","を挿入する）
                        for (int intCount = 0; intCount < 13; intCount++)
                        {
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt + 4, intCount + 4);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = string.Format("{0:#,0}", decKingakuTanto[tantoCnt, intCount]);
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(currentsheet.Cell(xlsRowCnt + 4, 1), (currentsheet.Cell(xlsRowCnt + 4, 16))).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        tantoCnt++;
                        rowCnt++;
                        tantoRowCnt = 0;
                    }

                    // グループ計を出力
                    groupRowCnt++;
                    if (groupGoukei.ElementAt(groupCnt).count == groupRowCnt)
                    {
                        xlsRowCnt++;
                        // セル結合、中央揃え
                        IXLCell groupcell = currentsheet.Cell(xlsRowCnt + 4, 1);
                        currentsheet.Range(xlsRowCnt + 4, 1, xlsRowCnt + 4, 2).Merge();
                        groupcell.Value = "■■　グループ計　■■";
                        groupcell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // 金額セルの処理（3桁毎に","を挿入する）
                        for (int intCount = 0; intCount < 13; intCount++)
                        {
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt + 4, intCount + 4);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = string.Format("{0:#,0}", decKingakuGroup[groupCnt, intCount]);
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(currentsheet.Cell(xlsRowCnt + 4, 1), (currentsheet.Cell(xlsRowCnt + 4, 16))).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        groupCnt++;
                        rowCnt++;
                        groupRowCnt = 0;
                    }

                    // 営業所計を出力
                    eigyoRowCnt++;
                    if (eigyoGoukei.ElementAt(eigyoCnt).count == eigyoRowCnt)
                    {
                        xlsRowCnt++;
                        // セル結合、中央揃え
                        IXLCell eigyocell = currentsheet.Cell(xlsRowCnt + 4, 1);
                        currentsheet.Range(xlsRowCnt + 4, 1, xlsRowCnt + 4, 2).Merge();
                        eigyocell.Value = "■■　営業所計　■■";
                        eigyocell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // 金額セルの処理（3桁毎に","を挿入する）
                        for (int intCount = 0; intCount < 13; intCount++)
                        {
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt + 4, intCount + 4);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = string.Format("{0:#,0}", decKingakuEigyo[eigyoCnt, intCount]);
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(currentsheet.Cell(xlsRowCnt + 4, 1), (currentsheet.Cell(xlsRowCnt + 4, 16))).Style
                                    .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                    .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                    .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                    .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        eigyoCnt++;
                        rowCnt++;
                        eigyoRowCnt = 0;
                    }

                    // 最終行を出力した後、合計行を出力
                    if (maxRowCnt == rowCnt)
                    {
                        // セル結合、中央揃え
                        IXLCell sumcell = currentsheet.Cell(xlsRowCnt + 5, 1);
                        currentsheet.Range(xlsRowCnt + 5, 1, xlsRowCnt + 5, 2).Merge();
                        sumcell.Value = "■■　合　　計　■■";
                        sumcell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // 金額セルの処理（3桁毎に","を挿入する）
                        for (int cnt = 0; cnt < 13; cnt++)
                        {
                            IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt + 5, cnt + 4);
                            kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            kingakuCell.Value = decKingaku[cnt].ToString("#,0");
                            //kingakuCell.Value = string.Format("{0:#,0}", decKingaku[cnt]);
                        }

                        // 1行分のセルの周囲に罫線を引く
                        currentsheet.Range(currentsheet.Cell(xlsRowCnt + 5, 1), (currentsheet.Cell(xlsRowCnt + 5, 16))).Style
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
                string strOutXlsFile = strTmpPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // PDF化の処理
                createPdf(strOutXlsFile, strDateTime);

            }
            catch (Exception ex)
            {

                // エラーロギング
                new CommonException(ex);
                return;
            }
            finally
            {
                // tmpフォルダの全ファイルを取得
                string[] files = System.IO.Directory.GetFiles(strTmpPath, "*", System.IO.SearchOption.AllDirectories);
                // tmpフォルダ内のファイル削除
                foreach (string filepath in files)
                {
                    //File.Delete(filepath);
                }
            }

        }

        /// 【共通化可能】
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// PDF化(Spire.xls)の処理
        /// <param name="strInXlsFile">エクセルファイル</param>
        /// </summary>
        private void createPdf(string strInXlsFile, string strDateTime)
        {
            string strTmpPath = System.Configuration.ConfigurationManager.AppSettings["tmppath"];
            string strPdfPath = System.Configuration.ConfigurationManager.AppSettings["pdfpath"];

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

                    string strPdfFile = strTmpPath + strDateTime + "_" + no + ".pdf";

                    // 出力したいシートをPDFで保存
                    printsheet.SaveToPdf(strPdfFile);

                }
                // printbookを解放
                printbook.Dispose();

                // フォルダ下の".pdf"ファイルをすべて取得する
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strTmpPath);
                System.IO.FileInfo[] fiFiles = di.GetFiles("*.pdf", System.IO.SearchOption.AllDirectories);
                Array.Sort<System.IO.FileInfo>(fiFiles, delegate (FileInfo f1, FileInfo f2)
                {
                    // ファイル名でソート
                    return f1.Name.CompareTo(f2.Name);
                });
                int filesMax = fiFiles.Count();
                string[] strFiles = new string[filesMax];

                // FileInfo配列をstring配列に
                for (int fileCnt = 0; fileCnt < filesMax; fileCnt++)
                {
                    strFiles[fileCnt] = strTmpPath + fiFiles[fileCnt].Name;
                }

                // 結合PDFオブジェクト
                string strJoinPdfFile = strPdfPath + strDateTime + ".pdf";

                // PDFファイル数が0でなければ結合
                if (filesMax != 0)
                {
                    fnJoinPdf(strFiles, strJoinPdfFile, 1);
                }

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
            }
            return;
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
