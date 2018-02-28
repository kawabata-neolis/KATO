using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;

using ClosedXML.Excel;

namespace KATO.Business.D0280_SoukoIdouKakunin
{

    /// <summary>
    /// D0280_SoukoIdouKakunin_B
    /// 倉庫移動確認フォーム
    /// 作成者：宇津野
    /// 作成日：2018/02/21
    /// 更新者：宇津野
    /// 更新日：2018/02/21
    /// カラム論理名
    /// </summary>
    class D0280_SoukoIdouKakunin_B
    {

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     getSiireJissekiList
        ///     倉庫間移動情報を取得
        /// </summary>
        /// <param name="lstItem">
        ///     検索条件List  
        ///     lstItem[0]  営業所コード,
        ///     lstItem[1]  移動年月日Start,
        ///     lstItem[2]  移動年月日End,
        ///     lstItem[3]  大分類コード,
        ///     lstItem[4]  中分類コード,
        ///     lstItem[5]  メーカーコード,
        ///     lstItem[6]  型番,
        ///     lstItem[7]  備考,
        ///     lstItem[8]  伝票番号,
        ///     lstItem[9]  担当者コード,
        ///     lstItem[10] 入力者コード
        /// </param>
        /// <param name="lstItem2">
        ///     検索条件（ラジオボタン）List
        ///     各要素の詳細は"param"タグに記載
        ///     lstItem[0]  受注残ラジオボタン,
        ///     lstItem[1]  処理名ラジオボタン,
        ///     lstItem[2]  区分名ラジオボタン
        /// </param>
        /// <param name="arrDispJuchuzan">
        ///     出力条件（受注残）
        ///     arrDispJuchuzan[0] すべて,
        ///     arrDispJuchuzan[1] 受注残のみ
        /// </param>
        /// <param name="arrDispSyoriName">
        ///     出力条件（処理名）
        ///     arrDispSyoriName[0] すべて,
        ///     arrDispSyoriName[1] 受注,
        ///     arrDispSyoriName[2] 依頼
        /// </param>
        /// <param name="arrDispKubunName">
        ///     出力条件（区分名）
        ///     arrDispKubunName[0] すべて,
        ///     arrDispKubunName[1] 移動出,
        ///     arrDispKubunName[2] 入庫分,
        ///     arrDispKubunName[3] 移動入,
        ///     arrDispKubunName[4] 出庫分,
        /// </param>
        /// <param name="dataFlag">
        ///     処理フラグ
        ///     1:表示,
        ///     2:印刷
        /// </param>
        /// -----------------------------------------------------------------------------
        public DataTable getSoukoIdouList(List<string> lstItem, List<Array> lstItem2, int dataFlag)
        {
            string allSql = "";

            DataTable dtGetTableGrid = new DataTable();

            // 出力条件取得用(受注残)
            string[] arrDispJuchuzan = (string[])lstItem2[0];
            // 出力条件取得用(処理名)
            string[] arrDispSyoriName = (string[])lstItem2[1];
            // 出力条件取得用(区分名)
            string[] arrDispKubunName = (string[])lstItem2[2];

            if(dataFlag == 1)
            {
                // 区分名の場合(入庫)
                if ("TRUE".Equals(arrDispKubunName[2]))
                {
                    // 入庫出庫取得用SQL作成
                    allSql = getSQLNyuSyukko(lstItem, lstItem2, 1);
                }
                // 区分名の場合(出庫)
                else if (arrDispKubunName[4].Equals("TRUE"))
                {
                    // 入庫出庫取得用SQL作成
                    allSql = getSQLNyuSyukko(lstItem, lstItem2, 2);
                }
                // 区分名の場合(倉庫)
                else
                {
                    // 倉庫移動及び入庫出庫取得用SQL作成
                    allSql = getSQLSoukoIdou(lstItem, lstItem2);
                }
            }
            else
            {
                // 倉庫移動及び入庫出庫取得用SQL作成
                allSql = getSQLSoukoIdou(lstItem, lstItem2);
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをデータテーブルへ格納
                dtGetTableGrid = dbconnective.ReadSql(allSql);

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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     入庫出庫取得用SQL作成</summary>
        /// <param name="lstItem">
        ///     検索条件List  
        ///     lstItem[0]  営業所コード,
        ///     lstItem[1]  移動年月日Start,
        ///     lstItem[2]  移動年月日End,
        ///     lstItem[3]  大分類コード,
        ///     lstItem[4]  中分類コード,
        ///     lstItem[5]  メーカーコード,
        ///     lstItem[6]  型番,
        ///     lstItem[7]  備考,
        ///     lstItem[8]  伝票番号,
        ///     lstItem[9]  担当者コード,
        ///     lstItem[10] 入力者コード
        /// </param>
        /// <param name="lstItem2">
        ///     検索条件（ラジオボタン）List
        ///     各要素の詳細は"param"タグに記載
        ///     lstItem[0]  受注残ラジオボタン,
        ///     lstItem[1]  処理名ラジオボタン,
        ///     lstItem[2]  区分名ラジオボタン
        /// </param>
        /// <param name="arrDispJuchuzan">
        ///     出力条件（受注残）
        ///     arrDispJuchuzan[0] すべて,
        ///     arrDispJuchuzan[1] 受注残のみ
        /// </param>
        /// <param name="arrDispSyoriName">
        ///     出力条件（処理名）
        ///     arrDispSyoriName[0] すべて,
        ///     arrDispSyoriName[1] 受注,
        ///     arrDispSyoriName[2] 依頼
        /// </param>
        /// <param name="arrDispKubunName">
        ///     出力条件（区分名）
        ///     arrDispKubunName[0] すべて,
        ///     arrDispKubunName[1] 移動出,
        ///     arrDispKubunName[2] 入庫分,
        ///     arrDispKubunName[3] 移動入,
        ///     arrDispKubunName[4] 出庫分,
        /// </param>
        /// -----------------------------------------------------------------------------
        private string getSQLSoukoIdou(List<string> lstItem, List<Array> lstItem2)
        {

            string allSql = "";
            // 出力条件取得用(受注残)
            string[] arrDispJuchuzan = (string[])lstItem2[0];
            // 出力条件取得用(処理名)
            string[] arrDispSyoriName = (string[])lstItem2[1];
            // 出力条件取得用(区分名)
            string[] arrDispKubunName = (string[])lstItem2[2];

            // 倉庫間移動
            allSql += " SELECT ";
            allSql += "伝票年月日 AS 年月日,伝票番号,";
            allSql += "CASE WHEN 処理番号 = 1 THEN '受注' ELSE '依頼' END AS 処理名,";
            allSql += "RTRIM(dbo.f_get取引区分名(取引区分)) AS 区分名,";
            allSql += "RTRIM(dbo.f_getメーカー名(メーカーコード)) AS メーカー,";
            allSql += "RTRIM(dbo.f_get中分類名(大分類コード,中分類コード)) ";
            allSql += " + ' '  +  Rtrim(ISNULL(Ｃ１,'')) AS 品名型式,";
            allSql += "数量,";
            allSql += "dbo.f_get受注番号から受注単価(伝票番号) AS 単価,";
            allSql += "dbo.f_get受注番号から受注金額(伝票番号) AS 金額,";
            allSql += "CASE WHEN 取引区分 = 51 THEN ";
            allSql += "   CASE WHEN 移動元倉庫='0001' THEN '本社' ELSE '岐阜' END ";
            allSql += "ELSE ";
            allSql += "   CASE WHEN 倉庫コード='0001' THEN '本社' ELSE '岐阜' END ";
            allSql += "END AS 出庫先,";
            allSql += "RTRIM(dbo.f_get担当者名(担当者コード)) AS 依頼者名,";
            allSql += "商品コード,";
            allSql += "伝票番号 AS 受注番号,";
            allSql += "0 AS 行番";
            allSql += " FROM ";
            allSql += " 倉庫間移動 ";
            allSql += " WHERE ";
            // 移動年月日start
            allSql += " 伝票年月日 >='" + lstItem[1] + "'";
            // 移動年月日End
            allSql += " AND 伝票年月日 <='" + lstItem[2] + "'";

            // 営業所コードの存在チェック
            if (!"".Equals(lstItem[0]))
            {
                // 営業所コード
                allSql += " AND 倉庫コード ='" + lstItem[0] + "'";
            }

            // 大分類コードの存在チェック
            if (!"".Equals(lstItem[3]))
            {
                // 大分類コード
                allSql += " AND 大分類コード ='" + lstItem[3] + "'";
            }

            // 中分類コードの存在チェック
            if (!"".Equals(lstItem[4]))
            {
                // 中分類コード
                allSql += " AND 中分類コード ='" + lstItem[4] + "'";
            }
            // メーカーコードの存在チェック
            if (!"".Equals(lstItem[5]))
            {
                // メーカーコード
                allSql += " AND メーカーコード ='" + lstItem[5] + "'";
            }

            // 型番の存在チェック
            if (!"".Equals(lstItem[6]))
            {
                // 型番
                allSql += " AND (RTRIM(dbo.f_get中分類名(大分類コード,中分類コード))  ";
                allSql += " +  Rtrim(ISNULL(Ｃ１,''))";
                allSql += " +  Rtrim(ISNULL(Ｃ２,''))";
                allSql += " +  Rtrim(ISNULL(Ｃ３,''))";
                allSql += " +  Rtrim(ISNULL(Ｃ４,''))";
                allSql += " +  Rtrim(ISNULL(Ｃ５,''))";
                allSql += " +  Rtrim(ISNULL(Ｃ６,'')) ) LIKE '%" + lstItem[6] + "%' )";
            }

            // 伝票番号の存在チェック
            if (!"".Equals(lstItem[8]))
            {
                // 伝票番号
                allSql += " AND 伝票番号 ='" + lstItem[8] + "'";
            }

            // 営業担当者コードの存在チェック
            if (!"".Equals(lstItem[9]))
            {
                // 営業担当者コード
                allSql += " and dbo.f_get担当者コード(dbo.f_get受注番号から得意先コード(倉庫間移動.伝票番号)) ='" + lstItem[9] + "'";
            }

            // 入力担当者コードの存在チェック
            if (!"".Equals(lstItem[10]))
            {
                // 入力担当者コード
                allSql += " AND 担当者コード ='" + lstItem[10] + "'";
            }

            // 処理名
            if ("TRUE".Equals(arrDispSyoriName[1]))
            {
                // 
                allSql += " AND 処理番号 = 1";
            }
            else if ("TRUE".Equals(arrDispSyoriName[2]))
            {
                allSql += " AND 処理番号 = 2";
            }

            // 区分名
            if ("TRUE".Equals(arrDispKubunName[1]) || "TRUE".Equals(arrDispKubunName[4]))
            {
                // 移動出・出庫分
                allSql += " AND 取引区分 = 51";
            }
            else if ("TRUE".Equals(arrDispKubunName[2]) || "TRUE".Equals(arrDispKubunName[3]))
            {
                // 移動入・入庫分
                allSql += " AND 取引区分 = 52";
            }

            // 受注残ラジオボタン
            if ("TRUE".Equals(arrDispJuchuzan[1]))
            {
                allSql += " AND dbo.f_get受注残数_受注(伝票番号) > 0 ";
            }

            // 処理名 移動出・移動入の場合、SQL完成させる。
            if ("TRUE".Equals(arrDispKubunName[1]) || "TRUE".Equals(arrDispKubunName[3]))
            {
                allSql += " ORDER BY 伝票年月日 DESC,処理番号,伝票番号";

                return allSql;
            }

            // 入庫分
            allSql += " UNION ALL  SELECT ";
            allSql += " H.伝票年月日 AS 年月日,H.伝票番号,";
            allSql += " '加工品入庫' AS 処理名,";
            allSql += " RTRIM(dbo.f_get取引区分名(H.取引区分)) AS 区分名,";
            allSql += " RTRIM(dbo.f_getメーカー名(M.メーカーコード)) AS メーカー,";
            allSql += " RTRIM(dbo.f_get中分類名(M.大分類コード,M.中分類コード)) ";
            allSql += "  + ' '  +  Rtrim(ISNULL(M.Ｃ１,'')) AS 品名型式,";
            allSql += " M.数量,";
            allSql += " dbo.f_get受注番号から受注単価(M.受注番号) AS 単価,";
            allSql += " dbo.f_get受注番号から受注金額(M.受注番号) AS 金額,";
            allSql += " CASE WHEN H.営業所コード='0001' THEN '本社' ELSE '岐阜' END AS 出庫先,";
            allSql += " RTRIM(dbo.f_get担当者名(H.担当者コード)) AS 依頼者名,";
            allSql += " M.商品コード,";
            allSql += " M.受注番号 AS 受注番号,";
            allSql += " M.行番号 AS 行番";
            allSql += " FROM ";
            allSql += " 出庫ヘッダ H,出庫明細 M ";
            allSql += " WHERE ";
            allSql += " H.削除='N' AND M.削除='N' ";
            allSql += " AND H.伝票番号=M.伝票番号";
            // 取引区分
            allSql += " AND (H.取引区分='42' OR H.取引区分='44' )";
            // 移動年月日start
            allSql += " AND H.伝票年月日 >='" + lstItem[1] + "'";
            // 移動年月日End
            allSql += " AND H.伝票年月日 <='" + lstItem[2] + "'";

            // 営業所コードの存在チェック
            if (!"".Equals(lstItem[0]))
            {
                // 営業所コード
                allSql += " AND H.営業所コード ='" + lstItem[0] + "'";
            }

            // 大分類コードの存在チェック
            if (!"".Equals(lstItem[3]))
            {
                // 大分類コード
                allSql += " AND M.大分類コード ='" + lstItem[3] + "'";
            }

            // 中分類コードの存在チェック
            if (!"".Equals(lstItem[4]))
            {
                // 中分類コード
                allSql += " AND M.中分類コード ='" + lstItem[4] + "'";
            }
            // メーカーコードの存在チェック
            if (!"".Equals(lstItem[5]))
            {
                // メーカーコード
                allSql += " AND M.メーカーコード ='" + lstItem[5] + "'";
            }

            // 型番の存在チェック
            if (!"".Equals(lstItem[6]))
            {
                // 型番
                allSql += " AND (RTRIM(dbo.f_get中分類名(M.大分類コード,M.中分類コード))  ";
                allSql += " +  Rtrim(ISNULL(M.Ｃ１,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ２,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ３,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ４,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ５,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ６,'')) ) LIKE '%" + lstItem[6] + "%' )";
            }

            // 伝票番号の存在チェック
            if (!"".Equals(lstItem[8]))
            {
                // 伝票番号
                allSql += " AND H.伝票番号 ='" + lstItem[8] + "'";
            }

            // 営業担当者コードの存在チェック
            if (!"".Equals(lstItem[9]))
            {
                // 営業担当者コード
                allSql += "and dbo.f_get担当者コード(dbo.f_get受注番号から得意先コード(H.伝票番号)) ='" + lstItem[9] + "'";
            }

            // 入力担当者コードの存在チェック
            if (!"".Equals(lstItem[10]))
            {
                // 入力担当者コード
                allSql += " AND H.担当者コード ='" + lstItem[10] + "'";
            }

            // 受注残ラジオボタン
            if ("TRUE".Equals(arrDispJuchuzan[1]))
            {
                allSql += " AND dbo.f_get受注残数_受注(M.受注番号) > 0 ";
            }

            // 出庫分
            allSql += " UNION ALL  SELECT ";
            allSql += " M.出庫予定日 AS 年月日,H.伝票番号,";
            allSql += " '加工品出庫' AS 処理名,";
            allSql += " RTRIM(dbo.f_get取引区分名(H.取引区分)) AS 区分名,";
            allSql += " RTRIM(dbo.f_getメーカー名(M.メーカーコード)) AS メーカー,";
            allSql += " RTRIM(dbo.f_get中分類名(M.大分類コード,M.中分類コード)) ";
            allSql += "  + ' '  +  Rtrim(ISNULL(M.Ｃ１,'')) AS 品名型式,";
            allSql += " M.数量,";
            allSql += " dbo.f_get受注番号から受注単価(M.受注番号) AS 単価,";
            allSql += " dbo.f_get受注番号から受注金額(M.受注番号) AS 金額,";
            allSql += " CASE WHEN H.営業所コード = '0001' THEN '岐阜' ELSE '本社' END AS 出庫先,";
            allSql += " RTRIM(dbo.f_get担当者名(H.担当者コード)) AS 依頼者名,";
            allSql += " M.商品コード,";
            allSql += " M.受注番号 AS 受注番号,";
            allSql += " M.行番号 AS 行番";
            allSql += " FROM ";
            allSql += " 出庫ヘッダ H,出庫明細 M ";
            allSql += " WHERE ";
            allSql += " H.削除='N' AND M.削除='N' ";
            allSql += " AND H.伝票番号=M.伝票番号";
            // 取引区分
            allSql += " AND (H.取引区分='41' OR H.取引区分='43' )";
            // 移動年月日start
            allSql += " AND M.出庫予定日 >='" + lstItem[1] + "'";
            // 移動年月日End
            allSql += " AND M.出庫予定日 <='" + lstItem[2] + "'";

            // 営業所コードの存在チェック
            if (!"".Equals(lstItem[0]))
            {
                // 営業所コード
                allSql += " AND H.営業所コード ='" + lstItem[0] + "'";
            }

            // 大分類コードの存在チェック
            if (!"".Equals(lstItem[3]))
            {
                // 大分類コード
                allSql += " AND M.大分類コード ='" + lstItem[3] + "'";
            }

            // 中分類コードの存在チェック
            if (!"".Equals(lstItem[4]))
            {
                // 中分類コード
                allSql += " AND M.中分類コード ='" + lstItem[4] + "'";
            }
            // メーカーコードの存在チェック
            if (!"".Equals(lstItem[5]))
            {
                // メーカーコード
                allSql += " AND M.メーカーコード ='" + lstItem[5] + "'";
            }

            // 型番の存在チェック
            if (!"".Equals(lstItem[6]))
            {
                // 型番
                allSql += " AND (RTRIM(dbo.f_get中分類名(M.大分類コード,M.中分類コード))  ";
                allSql += " +  Rtrim(ISNULL(M.Ｃ１,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ２,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ３,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ４,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ５,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ６,'')) ) LIKE '%" + lstItem[6] + "%' )";
            }

            // 伝票番号の存在チェック
            if (!"".Equals(lstItem[8]))
            {
                // 伝票番号
                allSql += " AND H.伝票番号 ='" + lstItem[8] + "'";
            }

            // 営業担当者コードの存在チェック
            if (!"".Equals(lstItem[9]))
            {
                // 営業担当者コード
                allSql += "and dbo.f_get担当者コード(dbo.f_get受注番号から得意先コード(H.伝票番号)) ='" + lstItem[9] + "'";
            }

            // 入力担当者コードの存在チェック
            if (!"".Equals(lstItem[10]))
            {
                // 入力担当者コード
                allSql += " AND H.担当者コード ='" + lstItem[10] + "'";
            }

            // 受注残ラジオボタン
            if ("TRUE".Equals(arrDispJuchuzan[1]))
            {
                allSql += " AND dbo.f_get受注残数_受注(M.受注番号) > 0 ";
            }

            allSql = "SELECT Z.* FROM (" + allSql + ") Z  ORDER BY 年月日 DESC,伝票番号,行番";

            return allSql;
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     入庫出庫取得用SQL作成</summary>
        /// <param name="lstItem">
        ///     検索条件List  
        ///     lstItem[0]  営業所コード,
        ///     lstItem[1]  移動年月日Start,
        ///     lstItem[2]  移動年月日End,
        ///     lstItem[3]  大分類コード,
        ///     lstItem[4]  中分類コード,
        ///     lstItem[5]  メーカーコード,
        ///     lstItem[6]  型番,
        ///     lstItem[7]  備考,
        ///     lstItem[8]  伝票番号,
        ///     lstItem[9]  担当者コード,
        ///     lstItem[10] 入力者コード
        /// </param>
        /// <param name="lstItem2">
        ///     検索条件（ラジオボタン）List
        ///     各要素の詳細は"param"タグに記載
        ///     lstItem[0]  受注残ラジオボタン,
        ///     lstItem[1]  処理名ラジオボタン,
        ///     lstItem[2]  区分名ラジオボタン
        /// </param>
        /// <param name="arrDispJuchuzan">
        ///     出力条件（受注残）
        ///     arrDispJuchuzan[0] すべて,
        ///     arrDispJuchuzan[1] 受注残のみ
        /// </param>
        /// <param name="arrDispSyoriName">
        ///     出力条件（処理名）
        ///     arrDispSyoriName[0] すべて,
        ///     arrDispSyoriName[1] 受注,
        ///     arrDispSyoriName[2] 依頼
        /// </param>
        /// <param name="arrDispKubunName">
        ///     出力条件（区分名）
        ///     arrDispKubunName[0] すべて,
        ///     arrDispKubunName[1] 移動出,
        ///     arrDispKubunName[2] 入庫分,
        ///     arrDispKubunName[3] 移動入,
        ///     arrDispKubunName[4] 出庫分,
        /// </param>
        /// <param name="NyuSyukkoFlag">
        /// 　　1：入庫
        /// 　　2：出庫
        /// </param>
        /// -----------------------------------------------------------------------------
        private string getSQLNyuSyukko(List<string> lstItem, List<Array> lstItem2, int NyuSyukkoFlag)
        {

            string allSql = "";
            // 出力条件取得用(受注残)
            string[] arrDispJuchuzan = (string[])lstItem2[0];
            // 出力条件取得用(処理名)
            string[] arrDispSyoriName = (string[])lstItem2[1];
            // 出力条件取得用(区分名)
            string[] arrDispKubunName = (string[])lstItem2[2];

            allSql += " SELECT ";


            // 入出庫フラグの１は入庫
            if(NyuSyukkoFlag == 1)
            {
                allSql += " H.伝票年月日 AS 年月日,H.伝票番号,";
                allSql += " '加工品入庫' AS 処理名,";
            }
            // 入出庫フラグの２は出庫
            else
            {
                allSql += " M.出庫予定日 AS 年月日,H.伝票番号,";
                allSql += " '加工品出庫' AS 処理名,";
            }
            allSql += " RTRIM(dbo.f_get取引区分名(H.取引区分)) AS 区分名,";
            allSql += " RTRIM(dbo.f_getメーカー名(M.メーカーコード)) AS メーカー,";
            allSql += " RTRIM(dbo.f_get中分類名(M.大分類コード,M.中分類コード)) ";
            allSql += "  + ' '  +  Rtrim(ISNULL(M.Ｃ１,'')) AS 品名型式,";
            allSql += " M.数量,";
            allSql += " dbo.f_get受注番号から受注単価(M.受注番号) AS 単価,";
            allSql += " dbo.f_get受注番号から受注金額(M.受注番号) AS 金額,";

            // 入出庫フラグの１は入庫
            if (NyuSyukkoFlag == 1)
            {
                allSql += " CASE WHEN H.営業所コード='0001' THEN '本社' ELSE '岐阜' END AS 出庫先,";
            }
            else
            {
                allSql += " CASE WHEN H.営業所コード = '0001' THEN '岐阜' ELSE '本社' END AS 出庫先,";
                
            }
            allSql += " RTRIM(dbo.f_get担当者名(H.担当者コード)) AS 依頼者名,";
            allSql += " M.商品コード,";
            allSql += " M.受注番号 AS 受注番号";
            allSql += " FROM ";
            allSql += " 出庫ヘッダ H,出庫明細 M ";
            allSql += " WHERE ";
            allSql += " H.削除='N' AND M.削除='N' ";
            allSql += " AND H.伝票番号=M.伝票番号";
            // 営業所コード
            allSql += " AND H.営業所コード ='" + lstItem[0] + "'";

            // 入出庫フラグの１は入庫
            if (NyuSyukkoFlag == 1)
            {
                // 取引区分
                allSql += " AND (H.取引区分='42' OR H.取引区分='44' )";
                // 移動年月日start
                allSql += " AND H.伝票年月日 >='" + lstItem[1] + "'";
                // 移動年月日End
                allSql += " AND H.伝票年月日 <='" + lstItem[2] + "'";

            }
            else
            {
                // 取引区分
                allSql += " AND (H.取引区分='41' OR H.取引区分='43' )";
                // 移動年月日start
                allSql += " AND M.出庫予定日 >='" + lstItem[1] + "'";
                // 移動年月日End
                allSql += " AND M.出庫予定日 <='" + lstItem[2] + "'";
            }

            // 大分類コードの存在チェック
            if (!"".Equals(lstItem[3]))
            {
                // 大分類コード
                allSql += " AND M.大分類コード ='" + lstItem[3] + "'";
            }

            // 中分類コードの存在チェック
            if (!"".Equals(lstItem[4]))
            {
                // 中分類コード
                allSql += " AND M.中分類コード ='" + lstItem[4] + "'";
            }
            // メーカーコードの存在チェック
            if (!"".Equals(lstItem[5]))
            {
                // メーカーコード
                allSql += " AND M.メーカーコード ='" + lstItem[5] + "'";
            }

            // 型番の存在チェック
            if (!"".Equals(lstItem[6]))
            {
                // 型番
                allSql += " AND (RTRIM(dbo.f_get中分類名(M.大分類コード,M.中分類コード))  ";
                allSql += " +  Rtrim(ISNULL(M.Ｃ１,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ２,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ３,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ４,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ５,''))";
                allSql += " +  Rtrim(ISNULL(M.Ｃ６,'')) ) LIKE '%" + lstItem[6] + "%' )";
            }

            // 伝票番号の存在チェック
            if (!"".Equals(lstItem[8]))
            {
                // 伝票番号
                allSql += " AND H.伝票番号 ='" + lstItem[8] + "'";
            }

            // 営業担当者コードの存在チェック
            if (!"".Equals(lstItem[9]))
            {
                // 営業担当者コード
                allSql += "and dbo.f_get担当者コード(dbo.f_get受注番号から得意先コード(H.伝票番号)) ='" + lstItem[9] + "'";
            }

            // 入力担当者コードの存在チェック
            if (!"".Equals(lstItem[10]))
            {
                // 入力担当者コード
                allSql += " and f_get担当者コード(" + lstItem[9] + ")";
            }

            // 受注残ラジオボタン
            if ("TRUE".Equals(arrDispJuchuzan[1]))
            {
                allSql += " AND dbo.f_get受注残数_受注(M.受注番号) > 0 ";
            }

            // 入出庫フラグの１は入庫
            if (NyuSyukkoFlag == 1)
            {
                allSql += " ORDER BY H.伝票年月日 DESC,H.伝票番号,M.行番号";
            }
            else
            {
                allSql += " ORDER BY M.出庫予定日 DESC,H.伝票番号,M.行番号";
            }
            
            return allSql;

        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     DataTableをもとにxlsxファイルを作成しPDF化</summary>
        /// <param name="dtSoukoIdou">
        ///     倉庫移動確認のデータテーブル</param>
        /// <param name="lstItem">
        ///     検索条件List  
        ///     lstItem[0]  営業所,
        ///     lstItem[1]  伝票年月日Start,
        ///     lstItem[2]  伝票年月日End,
        ///     lstItem[3]  大分類名称,
        ///     lstItem[4]  品名・型番,
        ///     lstItem[5]  備考,
        /// </param>
        /// -----------------------------------------------------------------------------
        public string dbToPdf(DataTable dtSoukoIdou, List<string> lstItem)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            try
            {
                CreatePdf pdf = new CreatePdf();

                // ワークブックのデフォルトフォント、フォントサイズの指定
                XLWorkbook.DefaultStyle.Font.FontName = "ＭＳ 明朝";
                XLWorkbook.DefaultStyle.Font.FontSize = 10;

                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled);

                IXLWorksheet worksheet = workbook.Worksheets.Add("Header");
                IXLWorksheet headersheet = worksheet;   // ヘッダーシート
                IXLWorksheet currentsheet = worksheet;  // 処理中シート


                //Linqで必要なデータをselect
                var outDataAll = dtSoukoIdou.AsEnumerable()
                    .Select(dat => new
                    {
                        denpyoYmd = dat["年月日"],
                        denpyoNo = dat["伝票番号"],
                        syoriName = dat["処理名"],
                        syukaName = dat["区分名"],
                        maker = dat["メーカー"],
                        kataban = dat["品名型式"],
                        suuryo = (decimal)dat["数量"],
                        iraiName = dat["依頼者名"],
                        juchuNo = dat["受注番号"]
                    }).ToList();
                
                // リストをデータテーブルに変換
                DataTable dtChkList = pdf.ConvertToDataTable(outDataAll);

                int maxRowCnt = dtChkList.Rows.Count + 1;
                int maxColCnt = dtChkList.Columns.Count;
                int pageCnt = 0;    // ページ(シート枚数)カウント
                int rowCnt = 1;     // datatable処理行カウント
                int xlsRowCnt = 4;  // Excel出力行カウント（開始は出力行）
                int maxPage = 0;    // 最大ページ数

                // ページ数計算
                double page = 1.0 * maxRowCnt / 44;
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

                // ClosedXMLで1行ずつExcelに出力
                foreach (DataRow drSiireCheak in dtChkList.Rows)
                {
                    // 1ページ目のシート作成
                    if (rowCnt == 1)
                    {
                        pageCnt++;

                        // タイトル出力（中央揃え、セル結合）
                        IXLCell titleCell = headersheet.Cell("A1");
                        titleCell.Value = "倉　庫　移　動　確　認　表";
                        titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titleCell.Style.Font.FontSize = 16;
                        headersheet.Range("A1", "I1").Merge();

                        // 担当者名、仕入先名、伝票年月日、大分類名、中分類名、品名・型番、備考出力（A2のセル）
                        IXLCell unitCell = headersheet.Cell("A2");
                        unitCell.Value = "営業所：" + lstItem[0] + " 伝票年月日：" + lstItem[1] + "～" + lstItem[2] + 
                            " 大分類：" + lstItem[3] + " 品名・型番：" + lstItem[4] + " 備考：" + lstItem[5];
                        unitCell.Style.Font.FontSize = 10;

                        // ヘッダー出力（3行目のセル）
                        headersheet.Cell("A3").Value = "日付";
                        headersheet.Cell("B3").Value = "伝票番号";
                        headersheet.Cell("C3").Value = "処理名";
                        headersheet.Cell("D3").Value = "区分名";
                        headersheet.Cell("E3").Value = "メーカー";
                        headersheet.Cell("F3").Value = "品名･型式";
                        headersheet.Cell("G3").Value = "数量";
                        headersheet.Cell("H3").Value = "依頼者名";
                        headersheet.Cell("I3").Value = "受注番号";
                        // ヘッダー列
                        headersheet.Range("A3", "I3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // セルの周囲に罫線を引く
                        headersheet.Range("A3", "I3").Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                            .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                            .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                            .Border.SetRightBorder(XLBorderStyleValues.Thin);

                        // セルの背景色
                        headersheet.Range("A3", "I3").Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 列幅の指定
                        headersheet.Column(1).Width = 12;         // 日付
                        headersheet.Column(2).Width = 8;          // 伝票番号
                        headersheet.Column(3).Width = 14;         // 処理名
                        headersheet.Column(4).Width = 14;         // 区分名
                        headersheet.Column(5).Width = 14;         // メーカー
                        headersheet.Column(6).Width = 40;         // 品名･型式
                        headersheet.Column(7).Width = 8;          // 数量
                        headersheet.Column(8).Width = 14;         // 依頼者名
                        headersheet.Column(9).Width = 8;          // 受注番号
                         
                        // 印刷体裁（A3横、印刷範囲、余白）
                        headersheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        headersheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
                        headersheet.PageSetup.Margins.Left = 0.7;
                        headersheet.PageSetup.Margins.Right = 0.7;

                        // ヘッダー部の指定（番号）
                        headersheet.PageSetup.Header.Left.AddText("（№28）");

                        // ヘッダーシートのコピー、ヘッダー部の指定
                        pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                    }

                    // 1セルずつデータ出力
                    for (int colCnt = 1; colCnt <= maxColCnt; colCnt++)
                    {
                        string str = drSiireCheak[colCnt - 1].ToString();

                        // 数量、金額セルの処理
                        if (colCnt == 7)
                        {
                            // 3桁毎に","を挿入する
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.NumberFormat.SetFormat("#,##0.00");
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        // 伝票番号、発注番号、受注番号の場合
                        if (colCnt == 2 || colCnt == 9)
                        {
                            currentsheet.Cell(xlsRowCnt, colCnt).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }

                        currentsheet.Cell(xlsRowCnt, colCnt).Value = str;
                        
                    }

                    // 1行分のセルの周囲に罫線を引く
                    currentsheet.Range(xlsRowCnt, 1, xlsRowCnt, 9).Style
                            .Border.SetTopBorder(XLBorderStyleValues.Thin)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin);

                    // 44行毎（ヘッダーを除いた行数）にシート作成
                    if (xlsRowCnt == 48)
                    {
                        pageCnt++;
                        if (pageCnt <= maxPage)
                        {
                            xlsRowCnt = 3;

                            // ヘッダーシートのコピー、ヘッダー部の指定
                            pdf.sheetCopy(ref workbook, ref headersheet, ref currentsheet, pageCnt, maxPage, strNow);
                        }
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
