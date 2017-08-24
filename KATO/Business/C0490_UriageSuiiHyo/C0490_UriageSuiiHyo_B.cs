using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using KATO.Common.Util;
using System.Windows.Forms;

using ClosedXML.Excel;

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
        public string dbToPdf(DataTable dtSiireSuiiList, string strStartYM)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            try
            {
                CreatePdf pdf = new CreatePdf();

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
                                  group tbl
                                  by new
                                  {
                                      eigyoCd = tbl.Field<string>("営業所コード"),
                                      groupCd = tbl.Field<string>("グループコード")
                                  }
                                  into g
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
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxColCnt = dtChkList.Columns.Count;
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）

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
                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "分類別売上推移表";
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
                        headersheet.Cell("B3").Value = "得意先名";
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
                        headersheet.Column(2).Width = 28;
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
                        headersheet.PageSetup.Header.Left.AddText("（№49）");
                    }

                    // 営業所名出力
                    if (eigyoRowCnt == 0)
                    {
                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);

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
                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
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
                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
                    }

                    // 改ページ毎に担当者名出力
                    if (tantoRowCnt == 0 || xlsRowCnt == 4)
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
                        xlsRowCnt = 4;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);

                        // 改ページ毎に担当者名出力
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

                        // 得意先コードの場合
                        if (colCnt == 3)
                        {
                            // 最初の行の場合 or 前行の得意先コードが現在の得意先コードが同じでない場合
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
                    if (xlsRowCnt == 38)
                    {
                        xlsRowCnt = 3;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
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
                        tantoRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
                    {
                        xlsRowCnt = 3;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
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
                        groupRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
                    {
                        xlsRowCnt = 3;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
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
                        eigyoRowCnt = 0;
                    }

                    // 35行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 38)
                    {
                        xlsRowCnt = 3;

                        // ヘッダーシートのコピー
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, workbook.Worksheets.Count);
                    }

                    rowCnt++;
                    xlsRowCnt++;
                }

                // 最終行を出力した後、合計行を出力
                if (dtChkList.Rows.Count > 0)
                {
                    // セル結合、中央揃え
                    IXLCell sumcell = currentsheet.Cell(xlsRowCnt, 1);
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 2).Merge();
                    sumcell.Value = "■■　合　　計　■■";
                    sumcell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // 金額セルの処理（3桁毎に","を挿入する）
                    for (int cnt = 0; cnt < 13; cnt++)
                    {
                        IXLCell kingakuCell = currentsheet.Cell(xlsRowCnt, cnt + 4);
                        kingakuCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        kingakuCell.Value = string.Format("{0:#,0}", decKingaku[cnt]);
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 16).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);
                }

                // ヘッダーシート削除
                headersheet.Delete();

                // 各ページのヘッダー部を指定
                int maxPage = workbook.Worksheets.Count;
                for (int pageCnt = 1; pageCnt <= maxPage; pageCnt++)
                {
                    // ヘッダー部に指定する情報を取得
                    string strHeader = pdf.getHeader(pageCnt, maxPage, strNow);

                    // ヘッダー部の指定（コンピュータ名、日付、ページ数を出力）
                    workbook.Worksheet(pageCnt).PageSetup.Header.Right.AddText(strHeader);
                }

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // PDF化の処理
                return pdf.createPdf(strOutXlsFile, strDateTime, 1);

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
