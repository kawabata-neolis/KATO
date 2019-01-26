using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.B1570_NyukinInput
{
    class B1570_NyukinInput_B
    {
        ///<summary>
        ///setGridTokusaiki
        ///得意先グリッドのデータ取得
        ///</summary>
        public DataTable getShiharaiList(List<string> lstItem)
        {
            string strSql;
            DataTable dtShiharaiCheakList = new DataTable();

            strSql = "SELECT S.入金年月日 AS 伝票年月日, ";
            strSql += "S.行番号, ";
            strSql += "T.締切日, ";
            strSql += "S.得意先コード, ";
            strSql += "T.取引先名称 AS 得意先名,";
            strSql += "S.手形期日 AS 入金予定日, ";
            strSql += "T.支払日 AS 入金日, ";
            strSql += "S.伝票番号, ";
            strSql += "S.取引区分コード, ";
            strSql += "dbo.f_get取引区分名(S.取引区分コード) AS 取引区分名, ";
            strSql += "T.口座種別 AS 口座,";
            strSql += "T.銀行名 AS 金融機関名,";
            strSql += "T.支店名 AS 支店名,";
            strSql += "CONVERT(CHAR, ROUND(S.入金額, 0), 126) AS 入金予定額,";
            strSql += "CONVERT(CHAR, ROUND(S.入金額, 0), 126) AS 入金額, ";
            strSql += "S.手形期日, ";
            strSql += "T.支払月数 AS 支払月数,";
            strSql += "T.支払条件 AS 支払条件,";
            strSql += "T.集金区分 AS 集金区分,";
            strSql += "T.消費税端数計算区分,";
            strSql += "S.備考 ";
            strSql += " FROM 入金 S, 取引先 T";
            strSql += " WHERE S.削除 ='N' ";
            strSql += "   AND T.削除 ='N' ";
            strSql += "   AND S.得意先コード = T.取引先コード ";

            // 入力年月日（開始）がある場合
            if (!lstItem[0].Equals(""))
            {
                strSql += " AND CONVERT(VARCHAR(10),S.更新日時,111) >='" + lstItem[0] + "'";
                strSql += " AND CONVERT(VARCHAR(10),S.更新日時,111) <='" + lstItem[1] + "'";
            }

            // 伝票年月日（開始）がある場合
            if (!lstItem[2].Equals(""))
            {
                strSql += " AND S.支払年月日 >='" + lstItem[2] + "'";
                strSql += " AND S.支払年月日 <='" + lstItem[3] + "'";
            }

            // ユーザーIDがある場合
            if (!lstItem[4].Equals(""))
            {
                strSql += " AND S.更新ユーザー名='" + lstItem[4] + "'";
            }

            // 仕入先コードがある場合
            if (!lstItem[5].Equals("") && !lstItem[6].Equals(""))
            {
                strSql += " AND S.得意先コード >='" + lstItem[5] + "'";
                strSql += " AND S.得意先コード <='" + lstItem[6] + "'";
            }

            if (!lstItem[7].Equals(""))
            {
                strSql += " AND S.取引区分コード IN (" + lstItem[7] + ")";
            }

            if (!lstItem[8].Equals(""))
            {
                strSql += " AND S.手形期日 >='" + lstItem[8] + "'";
            }

            if (!lstItem[9].Equals(""))
            {
                strSql += " AND S.手形期日 <='" + lstItem[9] + "'";
            }

            if (!lstItem[12].Equals(""))
            {
                strSql += " AND S.金融機関名 like '%" + lstItem[12] + "%'";
            }

            if (!lstItem[13].Equals(""))
            {
                strSql += " AND S.支店名 like '%" + lstItem[13] + "%'";
            }

            if (!lstItem[14].Equals(""))
            {
                strSql += " AND S.口座 like '%" + lstItem[14] + "%'";
            }

            strSql += " ORDER BY S.入金年月日,S.伝票番号,S.行番号";



            DBConnective dbconnective = new DBConnective();
            try
            {
                // 検索データをテーブルへ格納
                dtShiharaiCheakList = dbconnective.ReadSql(strSql);

                return dtShiharaiCheakList;
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

        // 登録
        public void addShiire(List<string[]> lsInput)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                for (int cnt = 0; cnt < lsInput.Count; cnt++)
                {
                    string[] strs = lsInput[cnt];
                    // 支払消去_PROCを実行
                    dbconnective.ReadSql("入金消去2_PROC '" + strs[0] + "', '" + strs[1] + "', '" + strs[10] + "'");

                    string strProc = "入金追加2_PROC '" + strs[0] + "', '" + strs[1] + "', '" +
                        strs[2] + "', '" + strs[3] + "', '" + strs[4] + "', '" +
                        strs[5] + "', ";

                    // 支払期日がない場合
                    if (strs[6].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[6] + "', ";
                    }

                    // 備考がない場合
                    if (strs[7].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[7] + "', ";
                    }

                    if (strs[8].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[8] + "', ";
                    }

                    if (strs[9].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[9] + "', ";
                    }



                    if (strs[10].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[10] + "', ";
                    }

                    if (strs[11].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[11] + "', ";
                    }

                    if (strs[12].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[12] + "', ";
                    }

                    if (strs[13].Equals(""))
                    {
                        strProc += "NULL, ";
                    }
                    else
                    {
                        strProc += "'" + strs[13] + "', ";
                    }

                    strProc += "'" + strs[14] + "'";

                    // 支払追加_PROCを実行
                    dbconnective.ReadSql(strProc);
                }
                // コミット
                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                // ロールバック処理
                dbconnective.Rollback();
                //new CommonException(ex);
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        // 削除
        public void delShiire(string[] strs)
        {
            DBConnective dbconnective = new DBConnective();
            try
            {
                dbconnective.ReadSql("入金全削除2_PROC '" + strs[0] + "', '" + strs[1] + "', '" + strs[2] + "'");
            }
            catch (Exception ex)
            {
                // ロールバック処理
                dbconnective.Rollback();
                //new CommonException(ex);
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }
        // 伝票名から伝票番号を取得
        public string getDenpyoNo()
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@テーブル名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add("支払伝票");

            string strRet;

            DBConnective dbconnective = new DBConnective();
            try
            {
                // get伝票番号_PROC"を実行
                strRet = dbconnective.RunSqlRe("get伝票番号_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@番号");
            }
            catch
            {
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return strRet;
        }
    }
}
