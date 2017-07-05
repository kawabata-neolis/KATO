using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;

namespace KATO.Business.A0470_Hachusuhenko
{
    ///<summary>
    ///A0470_Hachusuhenko_B
    ///発注数変更フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class A0470_Hachusuhenko_B
    {
        ///<summary>
        ///setHachusuhenkoGrid
        ///グリッドビューに表示
        ///</summary>
        public DataTable setHachusuhenkoGrid(List<string> lstStrSQL)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //以下ビジネス層で書き直し

            string strSelect = null;
            string strFrom = null;
            string strWhere = null;
            string strOrder = null;

            strSelect = strSelect + "SELECT a.発注年月日,a.発注番号,a.納期,";

            strSelect = strSelect + "RTRIM(dbo.f_get注番文字FROM担当者 (発注者コード)) + CAST(発注番号 AS varchar(8)) AS 注番, ";

            strSelect = strSelect + "dbo.f_getメーカー名(a.メーカーコード),";

            strSelect = strSelect + "dbo.f_get中分類名(a.大分類コード,a.中分類コード) +  ' '  +  Rtrim(ISNULL(a.Ｃ１,'')) ";
            strSelect = strSelect + " + ' ' + Rtrim(ISNULL(a.Ｃ２,''))";
            strSelect = strSelect + " + ' ' + Rtrim(ISNULL(a.Ｃ３,''))";
            strSelect = strSelect + " + ' ' + Rtrim(ISNULL(a.Ｃ４,''))";
            strSelect = strSelect + " + ' ' + Rtrim(ISNULL(a.Ｃ５,''))";
            strSelect = strSelect + " + ' ' + Rtrim(ISNULL(a.Ｃ６,'')),";

            strSelect = strSelect + "a.発注数量,a.発注単価,a.発注金額,a.商品コード,a.仕入済数量,";

            strSelect = strSelect + "dbo.f_get担当者名(a.発注者コード),";
            strSelect = strSelect + "dbo.f_get発注の受注番号_得意先名(a.受注番号),";
            strSelect = strSelect + "a.仕入先名称,";

            strSelect = strSelect + "a.注番,";

            strSelect = strSelect + "Rtrim(ISNULL(a.Ｃ１,'')), ";
            strSelect = strSelect + "a.受注番号";

            //from
            strFrom = " FROM 発注 a ";

            strWhere = " WHERE a.削除 = 'N'";
            strWhere = strWhere + " AND ((a.仕入済数量 = 0) OR (abs(a.仕入済数量) < abs(a.発注数量))) ";
            strWhere = strWhere + " AND a.発注数量 <> 0 ";

            //発注者コードに記入がある場合
            if (StringUtl.blIsEmpty(lstStrSQL[0].ToString()))
            {
                strWhere = strWhere + " AND a.発注者コード = '" + lstStrSQL[0].ToString() + "'";
            }

            //仕入先コードに記入がある場合
            if (StringUtl.blIsEmpty(lstStrSQL[1].ToString()))
            {
                strWhere = strWhere + " AND a.仕入先コード = '" + lstStrSQL[1].ToString() + "'";
            }

            //納期範囲開始に記入がある場合
            if (StringUtl.blIsEmpty(lstStrSQL[2].ToString()))
            {
                strWhere = strWhere + " AND a.納期 >= '" + lstStrSQL[2].ToString() + "'";
            }

            //納期範囲終了に記入がある場合
            if (StringUtl.blIsEmpty(lstStrSQL[3].ToString()))
            {
                strWhere = strWhere + " AND a.納期 <= '" + lstStrSQL[3].ToString() + "'";
            }

            //場所ボタンセットの「すべて」にチェックがある場合
            if (lstStrSQL[4].ToString() == "0")
            {
                //全選択扱い
            }
            //場所ボタンセットの「本社」にチェックがある場合
            else if (lstStrSQL[4].ToString() == "1")
            {
                strWhere = strWhere + " AND a.営業所コード = '0001'";
            }
            //場所ボタンセットの「岐阜」にチェックがある場合
            else if (lstStrSQL[4].ToString() == "2")
            {
                strWhere = strWhere + " AND a.営業所コード = '0002'";
            }

            //発注残ボタンセットの「発注残をすべて」にチェックがある場合
            if (lstStrSQL[5].ToString() == "0")
            {
                //全選択扱い
            }
            //発注残ボタンセットの「発注残で仕入済数あり」にチェックがある場合
            else if (lstStrSQL[5].ToString() == "1")
            {
                strWhere = strWhere + " AND a.仕入済数量<>0";
            }

            //品名型番が記入されている場合
            if (StringUtl.blIsEmpty(lstStrSQL[6].ToString()))
            {
                //前後の空白を取り除く
                lstStrSQL[6] = lstStrSQL[6].ToString().Trim();

                strWhere = strWhere + " AND (dbo.f_get中分類名(a.大分類コード,a.中分類コード)  +  REPLACE(ISNULL(a.Ｃ１,''),' ','' ) ";
                strWhere = strWhere + " +  REPLACE(ISNULL(a.Ｃ２,''),' ','' )";
                strWhere = strWhere + " +  REPLACE(ISNULL(a.Ｃ３,''),' ','' )";
                strWhere = strWhere + " +  REPLACE(ISNULL(a.Ｃ４,''),' ','' )";
                strWhere = strWhere + " +  REPLACE(ISNULL(a.Ｃ５,''),' ','' )";
                strWhere = strWhere + " +  REPLACE(ISNULL(a.Ｃ６,''),' ','' ) ) LIKE '%" + lstStrSQL[6].ToString() + "%' ";
            }

            //注番が記入されている場合
            if (StringUtl.blIsEmpty(lstStrSQL[7].ToString()))
            {
                //前後の空白を取り除く
                lstStrSQL[7] = lstStrSQL[7].ToString().Trim();

                strWhere = strWhere + " AND RTRIM(dbo.f_get注番文字FROM担当者 (発注者コード)) + CAST(発注番号 AS varchar(8)) LIKE '%" + lstStrSQL[7].ToString() + "%'";
            }

            strWhere = strWhere + " AND a.仕入先コード<>9999";

            strOrder = " ORDER BY a.発注年月日 DESC,a.発注番号 DESC";


            //gridHachusuhenko.(strSelect, strFrom, strWhere, strOrder);

            //以上ビジネス層で書き直し


            return (dtSetCd_B);
        }

    }
}
