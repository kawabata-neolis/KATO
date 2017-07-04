using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.M1160_TokuteimukesakiTanka
{
    class M1160_TokuteimukesakiTanka_B
    {
        ///<summary>
        ///getMaster
        ///特定向先単価マスタを取得
        ///</summary>
        public DataTable getMaster(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();
            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            //SQL文 商品別利益率

            strSQLInput = strSQLInput + " SELECT ";
            strSQLInput = strSQLInput + " 得意先コード ";
            strSQLInput = strSQLInput + " , dbo.f_get取引先名称(得意先コード) AS 仕向先 ";
            strSQLInput = strSQLInput + " , dbo.f_getメーカー名(dbo.f_get商品コードからメーカーコード(商品コード)) AS ﾒｰｶｰ ";
            strSQLInput = strSQLInput + " , 型番 ";
            strSQLInput = strSQLInput + " , 単価";
            strSQLInput = strSQLInput + " , dbo.f_get商品コードから最終仕入日(商品コード) AS 最終仕入日 ";
            strSQLInput = strSQLInput + " , 仕入先コード ";
            strSQLInput = strSQLInput + " , 商品コード ";
            
            strSQLInput = strSQLInput + " FROM ";
            strSQLInput = strSQLInput + " 特定向先単価  ";

            strSQLInput = strSQLInput + " WHERE ";
            strSQLInput = strSQLInput + " 削除 = 'N' ";

            //仕入先コードを記述した場合
            if (lstString[0] != "")
            {
                strSQLInput = strSQLInput + " AND 仕入先コード = '" + lstString[0] + "' ";
            }

            //得意先コードを記述した場合
            if (lstString[1] != "")
            {
                strSQLInput = strSQLInput + " AND 得意先コード = '" + lstString[1] + "' ";
            }

            //商品コードを記述した場合
            if (lstString[2] != "")
            {
                strSQLInput = strSQLInput + " AND 商品コード= '" + lstString[2] + "' ";
            }

            strSQLInput = strSQLInput + " ORDER BY 型番, 単価, 仕入先コード ASC ";


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

            strSQLInput = strSQLInput + " SELECT * FROM 商品 WHERE 商品コード='" + lstString[0] + "' AND 削除='N' ";

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
        /// addTokuteimukesakiTanka
        /// 特定向先単価マスタへ追加
        /// </summary>
        public void addTokuteimukesakiTanka(List<string> lstItem)
        {
            string strProc = "特定向先単価マスタ更新_PROC ";

            
            strProc += lstItem[0] + ", ";
            strProc += lstItem[1] + ", ";
            strProc += lstItem[2] + ", ";
            strProc += lstItem[3] + ", ";
            strProc += lstItem[4] + ", ";
            strProc += lstItem[5];



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
        /// delTokuteimukesakiTanka
        /// 表示中のマスタデータを削除する処理
        /// </summary>
        public void delTokuteimukesakiTanka(List<string> lstDeleteItem)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // 商品分類別利益率設定マスタ削除_PROCを実行
                dbconnective.RunSql("特定向先単価マスタ削除_PROC " + lstDeleteItem[0] + ", '" + lstDeleteItem[1] + "', '" + lstDeleteItem[2] + "', '" + lstDeleteItem[3] + "'");

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
