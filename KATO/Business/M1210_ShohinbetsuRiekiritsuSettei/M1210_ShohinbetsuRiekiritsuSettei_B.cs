using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KATO.Common.Util;
using System.Windows.Forms;

namespace KATO.Business.M1210_ShohinbetsuRiekiritsuSettei
{
    ///<summary>
    ///M1210_ShohinbetsuRiekiritsuSettei_B
    ///商品別利益率設定
    ///作成者：太田
    ///作成日：2017/06/29
    ///更新者：
    ///更新日：
    ///カラム論理名
    class M1210_ShohinbetsuRiekiritsuSettei_B
    {
        ///<summary>
        ///getShohinbetsuRiekiritsu
        ///商品別利益率表を取得
        ///</summary>
        public DataTable getShohinbetsuRiekiritsu(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();
            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();
            
            //SQL文 商品別利益率

            strSQLInput = strSQLInput + " SELECT ";
            strSQLInput = strSQLInput + " d.得意先コード ";
            strSQLInput = strSQLInput + " , dbo.f_get取引先名称(d.得意先コード) AS 得意先名 ";
            strSQLInput = strSQLInput + " , RTRIM(dbo.f_getメーカー名(a.メーカーコード)) + ' ' + RTRIM(dbo.f_get中分類名(a.大分類コード, a.中分類コード)) + ' ' + Rtrim(ISNULL(a.Ｃ１, '')) + ' ' + Rtrim(ISNULL(a.Ｃ２, '')) + ' ' + Rtrim(ISNULL(a.Ｃ３, '')) + ' ' + Rtrim(ISNULL(a.Ｃ４, '')) + ' ' + Rtrim(ISNULL(a.Ｃ５, '')) + ' ' + Rtrim(ISNULL(a.Ｃ６, '')) AS 品名型式 ";
            strSQLInput = strSQLInput + " , d.利益率 ";
            strSQLInput = strSQLInput + " , d.単価";
            strSQLInput = strSQLInput + " , '  ' + d.設定 AS 設定 ";
            strSQLInput = strSQLInput + " , d.商品コード ";
            strSQLInput = strSQLInput + " , a.大分類コード ";
            strSQLInput = strSQLInput + " , a.中分類コード ";
            strSQLInput = strSQLInput + " , a.メーカーコード ";

            strSQLInput = strSQLInput + " FROM ";
            strSQLInput = strSQLInput + " 商品別利益率 d ";
            strSQLInput = strSQLInput + " , 商品 a ";

            strSQLInput = strSQLInput + " WHERE ";
            strSQLInput = strSQLInput + "  d.削除 = 'N' ";
            strSQLInput = strSQLInput + " AND d.商品コード = a.商品コード ";

            //得意先コードを記述した場合
            if (lstString[0] != "")
            {
                strSQLInput = strSQLInput + " AND d.得意先コード = '"+ lstString[0] +"' ";
            }

            //担当者コードを記述した場合
            if (lstString[1] != "")
            {
                strSQLInput = strSQLInput + " AND dbo.f_get担当者コード(d.得意先コード) = '" + lstString[1] + "' ";
            }

            //型名・品番を記述した場合
            if (lstString[2] != "")
            {
                strSQLInput = strSQLInput + " AND RTRIM(dbo.f_getメーカー名(a.メーカーコード)) + RTRIM(dbo.f_get中分類名(a.大分類コード, a.中分類コード)) + Rtrim(ISNULL(a.Ｃ１, '')) + Rtrim(ISNULL(a.Ｃ２, '')) + Rtrim(ISNULL(a.Ｃ３, '')) + Rtrim(ISNULL(a.Ｃ４, '')) + Rtrim(ISNULL(a.Ｃ５, '')) + Rtrim(ISNULL(a.Ｃ６, '')) LIKE '%" + lstString[2] + "%' ";
            }

            //並び順の指定　上段
            switch (lstString[3])
            {
                case "0": // 得意先
                    strSQLInput = strSQLInput + " ORDER BY 得意先コード,品名型式 ";
                    break;
                case "1": // 品名
                    strSQLInput = strSQLInput + " ORDER BY 品名型式,得意先コード ";
                    break;
                case "2": // 利益率
                    strSQLInput = strSQLInput + " ORDER BY 利益率,得意先コード,品名型式 ";
                    break;
                case "3": // 単価
                    strSQLInput = strSQLInput + " ORDER BY 単価,得意先コード,品名型式 ";
                    break;
            }

            //並び順の指定　下段
            switch (lstString[4])
            {
                case "0": // A-Z
                    strSQLInput = strSQLInput + " ASC ";
                    break;
                case "1": // Z-A
                    strSQLInput = strSQLInput + " DESC ";
                    break;
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
        ///getShohinData
        ///商品データを取得
        ///</summary>
        public DataTable getShohinData(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();
            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            //SQL文 商品別利益率

            strSQLInput = strSQLInput + " SELECT * FROM 商品 WHERE 商品コード='" +lstString[0]+ "' AND 削除='N' ";
            
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

        /// <summary>
        /// addRiekiritsu
        /// 商品別利益率へ追加
        /// </summary>
        public void addRiekiritsu(List<string> lstItem)
        {
            string strProc = "商品別利益率設定マスタ更新_PROC ";

            //得意先コード
            strProc += lstItem[0] + ", ";
            //商品CD
            strProc += "'" + lstItem[1] + "',";
            //利益率
            strProc += "'" + lstItem[2] + "',";
            //単価
            strProc += "'" + lstItem[3] + "',";
            //設定
            strProc += "'" + lstItem[4] + "',";
            //ユーザ
            strProc += "'" + lstItem[5] + "'";

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 商品分類別利益率設定マスタ更新_PROCを実行
                dbconnective.RunSql(strProc);

                // コミット
                dbconnective.Commit();

            }
            catch
            {
                // ロールバック処理
                dbconnective.Rollback();
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        /// <summary>
        /// delRiekiritsu
        /// 表示中のマスタデータを削除する処理
        /// </summary>
        public void delRiekiritsu(List<string> lstDeleteItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 商品分類別利益率設定マスタ削除_PROCを実行
                dbconnective.RunSql("商品別利益率設定マスタ削除_PROC " + lstDeleteItem[0] + ", '" + lstDeleteItem[1] + "', '" + lstDeleteItem[2] + "'");

                // コミット
                dbconnective.Commit();
            }
            catch
            {
                // ロールバック処理
                dbconnective.Rollback();
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return;
        }

    }
}
