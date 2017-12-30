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

            string strSQL = null;

            strSQL = strSQL + "SELECT a.発注年月日 as 発注日,a.発注番号 as 発,a.納期 as 納期,";

            strSQL = strSQL + "RTRIM(dbo.f_get注番文字FROM担当者 (発注者コード)) + CAST(発注番号 AS varchar(8)) AS 注番, ";

            strSQL = strSQL + "dbo.f_getメーカー名(a.メーカーコード) as メーカー,";

            strSQL = strSQL + "dbo.f_get中分類名(a.大分類コード,a.中分類コード) +  ' '  +  Rtrim(ISNULL(a.Ｃ１,'')) ";
            strSQL = strSQL + " + ' ' + Rtrim(ISNULL(a.Ｃ２,''))";
            strSQL = strSQL + " + ' ' + Rtrim(ISNULL(a.Ｃ３,''))";
            strSQL = strSQL + " + ' ' + Rtrim(ISNULL(a.Ｃ４,''))";
            strSQL = strSQL + " + ' ' + Rtrim(ISNULL(a.Ｃ５,''))";
            strSQL = strSQL + " + ' ' + Rtrim(ISNULL(a.Ｃ６,'')) as 品名・型式,";

            strSQL = strSQL + "a.発注数量 as 数量, a.発注単価 as 単価, a.発注金額 as 金額, a.商品コード as 商品コード, a.仕入済数量 as 仕入済,";

            strSQL = strSQL + "dbo.f_get担当者名(a.発注者コード) as 発注者,";
            strSQL = strSQL + "dbo.f_get発注の受注番号_得意先名(a.受注番号) as 引当先名,";
            strSQL = strSQL + "a.仕入先名称 as 仕入先,";

            strSQL = strSQL + "a.注番 as '注番（画面）',";

            strSQL = strSQL + "Rtrim(ISNULL(a.Ｃ１,'')) as Ｃ１, ";
            strSQL = strSQL + "a.受注番号 as 受注番号";

            //from
            strSQL =  strSQL + " FROM 発注 a ";

            strSQL = strSQL + " WHERE a.削除 = 'N'";
            strSQL = strSQL + " AND ((a.仕入済数量 = 0) OR (abs(a.仕入済数量) < abs(a.発注数量))) ";
            strSQL = strSQL + " AND a.発注数量 <> 0 ";

            //発注者コードに記入がある場合
            if (StringUtl.blIsEmpty(lstStrSQL[0].ToString()))
            {
                strSQL = strSQL + " AND a.発注者コード = '" + lstStrSQL[0].ToString() + "'";
            }

            //仕入先コードに記入がある場合
            if (StringUtl.blIsEmpty(lstStrSQL[1].ToString()))
            {
                strSQL = strSQL + " AND a.仕入先コード = '" + lstStrSQL[1].ToString() + "'";
            }

            //納期範囲開始に記入がある場合
            if (StringUtl.blIsEmpty(lstStrSQL[2].ToString()))
            {
                strSQL = strSQL + " AND a.納期 >= '" + lstStrSQL[2].ToString() + "'";
            }

            //納期範囲終了に記入がある場合
            if (StringUtl.blIsEmpty(lstStrSQL[3].ToString()))
            {
                strSQL = strSQL + " AND a.納期 <= '" + lstStrSQL[3].ToString() + "'";
            }

            //場所ボタンセットの「すべて」にチェックがある場合
            if (lstStrSQL[4].ToString() == "0")
            {
                //全選択扱い
            }
            //場所ボタンセットの「本社」にチェックがある場合
            else if (lstStrSQL[4].ToString() == "1")
            {
                strSQL = strSQL + " AND a.営業所コード = '0001'";
            }
            //場所ボタンセットの「岐阜」にチェックがある場合
            else if (lstStrSQL[4].ToString() == "2")
            {
                strSQL = strSQL + " AND a.営業所コード = '0002'";
            }

            //発注残ボタンセットの「発注残をすべて」にチェックがある場合
            if (lstStrSQL[5].ToString() == "0")
            {
                //全選択扱い
            }
            //発注残ボタンセットの「発注残で仕入済数あり」にチェックがある場合
            else if (lstStrSQL[5].ToString() == "1")
            {
                strSQL = strSQL + " AND a.仕入済数量<>0";
            }

            //品名型番が記入されている場合
            if (StringUtl.blIsEmpty(lstStrSQL[6].ToString()))
            {
                //前後の空白を取り除く
                lstStrSQL[6] = lstStrSQL[6].ToString().Trim();

                strSQL = strSQL + " AND (dbo.f_get中分類名(a.大分類コード,a.中分類コード)  +  REPLACE(ISNULL(a.Ｃ１,''),' ','' ) ";
                strSQL = strSQL + " +  REPLACE(ISNULL(a.Ｃ２,''),' ','' )";
                strSQL = strSQL + " +  REPLACE(ISNULL(a.Ｃ３,''),' ','' )";
                strSQL = strSQL + " +  REPLACE(ISNULL(a.Ｃ４,''),' ','' )";
                strSQL = strSQL + " +  REPLACE(ISNULL(a.Ｃ５,''),' ','' )";
                strSQL = strSQL + " +  REPLACE(ISNULL(a.Ｃ６,''),' ','' ) ) LIKE '%" + lstStrSQL[6].ToString() + "%' ";
            }

            //注番が記入されている場合
            if (StringUtl.blIsEmpty(lstStrSQL[7].ToString()))
            {
                //前後の空白を取り除く
                lstStrSQL[7] = lstStrSQL[7].ToString().Trim();

                strSQL = strSQL + " AND RTRIM(dbo.f_get注番文字FROM担当者 (発注者コード)) + CAST(発注番号 AS varchar(8)) LIKE '%" + lstStrSQL[7].ToString() + "%'";
            }

            strSQL = strSQL + " AND a.仕入先コード<>9999";

            strSQL = strSQL + " ORDER BY a.発注年月日 DESC,a.発注番号 DESC";

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtSetCd_B = dbconnective.ReadSql(strSQL);

                return dtSetCd_B;
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

        ///<summary>
        ///updKoushin
        ///データの更新
        ///</summary>
        public void updKoushin(string strHachusu, string strHachuID)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("A0470_Hachusuhenko");
            lstSQL.Add("Hachusuhenko_UPDATE");

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strHachusu, strHachuID);

                //SQL接続後、該当データを取得
                dbconnective.RunSql(strSQLInput);

                return;
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
    }
}
