using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KATO.Common.Util;

namespace KATO.Business.C0490_UriageSuiiHyo
{
    ///<summary>
    ///C0492_UriageSuiiHyoLevel3_B
    ///分類別売上推移表レベル３ビジネス層
    ///作成者：TMSOL太田
    ///作成日：2017/06/21
    ///更新者：
    ///更新日：
    ///カラム論理名
    class C0492_UriageSuiiHyoLevel3_B
    {
        ///<summary>
        ///setViewGrid
        ///検索データをグリッドビューにセット
        ///レベル３ではDISP2のみ処理される。
        ///</summary>
        public DataTable setViewGrid(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            //大分類コードが空欄の場合
            if (lstString[4] == "")
            {
                //通らないロジック
                return dtGetTableGrid;
            }
            else
            {
                //中分類が空欄の場合
                if (lstString[5] == "")
                {
                    //通らないロジック
                    return dtGetTableGrid;
                }
                else
                {
                    //メーカコードが空欄の場合
                    if (lstString[6] == "")
                    {
                        //DISP2 大分類,中分類を指定へ
                        dtGetTableGrid = this.DISP2(lstString);
                    }
                    else
                    {
                        //通らないロジック
                        return dtGetTableGrid;
                    }
                }
            }

            return dtGetTableGrid;
        }

        ///<summary>
        ///DISP2 
        ///大分類,中分類を指定 分類コードを入力かつ中分類コードを入力かつメーカコードが空欄の場合
        ///</summary>
        public DataTable DISP2(List<string> lstString)
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

            strSQLInput = strSQLInput + " SELECT z.得意先コード, dbo.f_get取引先名称(z.得意先コード) AS 得意先名, 2 AS 区分, z.大分類コード, z.中分類コード, z.メーカーコード, dbo.f_getメーカー名(z.メーカーコード) AS 分類名 ";

            //金額1～12の作成
            for (int count = 0; count <= 11; count++)
            {
                //全角数字用配列
                List<string> lstZenkakuNum = new List<string>() { "１", "２", "３", "４", "５", "６", "７", "８", "９", "１０", "１１", "１２" };
                strSQLInput = strSQLInput + " , ROUND(dbo.f_分類別売上推移表_売上高_メーカー(z.得意先コード, z.大分類コード, z.中分類コード, z.メーカーコード,'" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0) AS 金額" + lstZenkakuNum[count].ToString();
            }

            //金額合計の作成
            strSQLInput = strSQLInput + ",";
            for (int count = 0; count <= 11; count++)
            {
                //カウント0以外には先頭に＋を付与する
                if (count == 0)
                {
                    strSQLInput = strSQLInput + " ROUND(dbo.f_分類別売上推移表_売上高_メーカー(z.得意先コード, z.大分類コード, z.中分類コード, z.メーカーコード,'" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
                else
                {
                    strSQLInput = strSQLInput + "+ ROUND(dbo.f_分類別売上推移表_売上高_メーカー(z.得意先コード, z.大分類コード, z.中分類コード, z.メーカーコード,'" + dateStartYMD.AddMonths(count) + "', '" + dateGetumatuYMD.AddMonths(count) + "') / 1000, 0, 0)";
                }
            }
            strSQLInput = strSQLInput + " AS 金額合計";

            strSQLInput = strSQLInput + " FROM (SELECT DISTINCT a.得意先コード, b.大分類コード, b.中分類コード, b.メーカーコード FROM 売上ヘッダ a, 売上明細 b ";
            strSQLInput = strSQLInput + " WHERE a.削除 = 'N' AND a.伝票番号 = b.伝票番号 AND a.伝票年月日 >= '" + dateStartYMD + "' AND a.伝票年月日 <= '" + dateEndYMD + "' AND a.得意先コード >= '" + lstString[2] + "' AND a.得意先コード <= '" + lstString[3] + "' AND b.大分類コード ='" + lstString[4] + "' AND b.中分類コード ='" + lstString[5] + "'";

            strSQLInput = strSQLInput + " ) z ORDER BY z.得意先コード, z.大分類コード, z.中分類コード, z.メーカーコード ";

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
    }
}
