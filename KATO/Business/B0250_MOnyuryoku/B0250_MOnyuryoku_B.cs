using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.B0250_MOnyuryoku
{
    ///<summary>
    ///B0250_MOnyuryoku_B
    ///MO入力のビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class B0250_MOnyuryoku_B
    {
        ///<summary>
        ///getViewGrid
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable getViewGrid(string strDaibunCD)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_SELECT_GetDataGridView_NOTALL");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strDaibunCD);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
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

        /// <summary>
        /// getExecSProc
        /// MOデータ変更の判定
        /// </summary>
        public int getExecSProc(string strYMD, 
                                   string strCode, 
                                   object objSijisU, 
                                   decimal decSu, 
                                   decimal decTanka, 
                                   object objNouki,
                                   object objTorihiki,
                                   int intDenNo,
                                   string strUserID
                                   )
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@年月度");
            lstTableName.Add("@商品コード");
            lstTableName.Add("@ＭＯ発注指示数");
            lstTableName.Add("@ＭＯ発注数");
            lstTableName.Add("@ＭＯ発注単価");
            lstTableName.Add("@納期");
            lstTableName.Add("@取引先コード");
            lstTableName.Add("@発注番号");
            lstTableName.Add("@ユーザー名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(strYMD);
            lstDataName.Add(strCode);
            lstDataName.Add(objSijisU.ToString());
            lstDataName.Add(decSu.ToString());
            lstDataName.Add(decTanka.ToString());
            lstDataName.Add(objNouki.ToString());
            lstDataName.Add(objTorihiki.ToString());
            lstDataName.Add(intDenNo.ToString());
            lstDataName.Add(strUserID);

            int intExec;

            DBConnective dbconnective = new DBConnective();
            try
            {
                // get伝票番号_PROC"を実行
                intExec = int.Parse(dbconnective.RunSqlRe("get伝票番号_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@番号"));
            }
            catch
            {
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return intExec;

        }
    }
}
