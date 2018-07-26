using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Form.A0110_KakohinTehaiInput;

namespace KATO.Business.A0110_KakohinTehaiInput
{
    class A0110_KakohinTehaiInput_B
    {
        ///<summary>
        ///getTantoshaCd
        ///担当者データの取得
        ///</summary>
        public DataTable getTantoshaCd(string strUserID)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtTantoshaCd = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_Tantosha_SELECT");

            //SQL発行
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
                    return (dtTantoshaCd);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput,
                                            strUserID   //ログインＩＤ
                                            );

                //データ取得（ここから取得）
                dtTantoshaCd = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
            return (dtTantoshaCd);
        }

        ///<summary>
        ///getDenpyoData
        ///伝票データの取得
        ///</summary>
        public DataTable getDenpyoData(string s)
        {
            DataTable dt = null;

            //接続用クラスのインスタンス作成
            DBConnective con = new DBConnective();
            try
            {
                string strSQL = "SELECT 伝票番号, CONVERT(VARCHAR, 伝票年月日, 111) as 伝票年月日, 仕入先コード, 取引区分, 担当者コード, 営業所コード FROM 出庫ヘッダ WHERE 伝票番号= " + s + " AND 削除='N'";

                dt = con.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                //ロールバック開始
                con.Rollback();
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                con.DB_Disconnect();
            }
            return dt;
        }

        ///<summary>
        ///getDenpyoMeisai
        ///伝票明細の取得
        ///</summary>
        public DataTable getDenpyoMeisai(string s)
        {
            DataTable dt = null;

            //接続用クラスのインスタンス作成
            DBConnective con = new DBConnective();
            try
            {
                string strSQL = "SELECT * FROM 出庫明細 WHERE 伝票番号= " + s + " AND 削除='N' ORDER BY 行番号";

                dt = con.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                //ロールバック開始
                con.Rollback();
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                con.DB_Disconnect();
            }
            return dt;
        }

        ///<summary>
        ///getHatchuData
        ///発注データの取得
        ///</summary>
        public DataTable getHatchuData(string s)
        {
            DataTable dt = null;

            //接続用クラスのインスタンス作成
            DBConnective con = new DBConnective();
            try
            {
                string strSQL = "SELECT 仕入先コード," +
                                "CONVERT(VARCHAR, 発注年月日, 111) as 発注年月日," +
                                "発注番号," +
                                "発注者コード," +
                                "営業所コード," +
                                "担当者コード," +
                                "受注番号," +
                                "出庫番号," +
                                "行番号," +
                                "商品コード," +
                                "メーカーコード," +
                                "大分類コード," +
                                "中分類コード," +
                                "Ｃ１," +
                                "Ｃ２," +
                                "Ｃ３," +
                                "Ｃ４," +
                                "Ｃ５," +
                                "Ｃ６," +
                                "発注数量," +
                                "発注単価," +
                                "発注金額," +
                                "CONVERT(VARCHAR, 納期, 111) as 納期," +
                                "発注フラグ," +
                                "注番," +
                                "仕入済数量," +
                                "印刷フラグ," +
                                "加工区分," +
                                "仕入先名称 " +
                                "FROM 発注 WHERE 出庫番号= " + s + " AND 削除='N' ORDER BY 行番号";

                dt = con.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                //ロールバック開始
                con.Rollback();
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                con.DB_Disconnect();
            }
            return dt;
        }

        public DataTable getZaiko(string strEigyouCd, string strShohinNo)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT dbo.f_get指定日の在庫数('" + strEigyouCd + "', '" + strShohinNo + "', '2050/12/31') AS 在庫数";
            strQuery += "      ,dbo.f_get指定日のフリー在庫数Ｂ('" + strEigyouCd + "', '" + strShohinNo + "' ,'2050/12/31') AS フリー在庫数";
            strQuery += "  FROM 商品 where 商品コード = '" + strShohinNo + "'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public decimal getShukko(string denNo, string gyo)
        {
            decimal ret = 0;
            DataTable dtRet = null;
            string strQuery = "";

            strQuery  = "SELECT 数量 FROM  出庫明細";
            strQuery += " WHERE 伝票番号 = " + denNo;
            strQuery += " AND 行番号 = " + gyo;
            strQuery += " AND 削除 = 'N'";

            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);

                if (dtRet != null && dtRet.Rows.Count > 0)
                {
                    if (dtRet.Rows[0]["数量"] != null && dtRet.Rows[0]["数量"] != DBNull.Value)
                    {
                        ret = Decimal.Parse(dtRet.Rows[0]["数量"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public void addShukkoHead(DBConnective con, string[] updShukkoHeaderItem)
        {
            try
            {
                string strProc = "出庫ヘッダ更新_PROC "
                            + updShukkoHeaderItem[0] + ", "
                            + "'" + updShukkoHeaderItem[1] + "', "
                            + "'" + updShukkoHeaderItem[2] + "', "
                            + "'" + updShukkoHeaderItem[3] + "', "
                            + "'" + updShukkoHeaderItem[4] + "', "
                            + "'" + updShukkoHeaderItem[5] + "', "
                            + "'" + updShukkoHeaderItem[6] + "', "
                            + "'" + updShukkoHeaderItem[7] + "'";

                // 出庫ヘッダ更新_PROC
                con.ReadSql(strProc);
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        public void delShukkoMeisai(DBConnective con, string s)
        {
            try
            {
                string strProc = "出庫明細消去_PROC " + s;

                // 出庫明細削除_PROC
                con.ReadSql(strProc);
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        public void addShukkoMeisai(DBConnective con, string[] updShukkoMeisaiItem)
        {
            try
            {
                string strProc = "出庫明細更新_PROC "
                            + updShukkoMeisaiItem[0] + ", "
                            + updShukkoMeisaiItem[1] + ", "
                            + "'" + updShukkoMeisaiItem[2] + "', "
                            + "'" + updShukkoMeisaiItem[3] + "', "
                            + "'" + updShukkoMeisaiItem[4] + "', "
                            + "'" + updShukkoMeisaiItem[5] + "', "
                            + "'" + updShukkoMeisaiItem[6] + "', "
                            + "'" + updShukkoMeisaiItem[7] + "', "
                            + "'" + updShukkoMeisaiItem[8] + "', "
                            + "'" + updShukkoMeisaiItem[9] + "', "
                            + "'" + updShukkoMeisaiItem[10] + "', "
                            + "'" + updShukkoMeisaiItem[11] + "', "
                            + updShukkoMeisaiItem[12] + ", "
                            + updShukkoMeisaiItem[13] + ", "
                            + "'" + updShukkoMeisaiItem[14] + "', "
                            + "'" + updShukkoMeisaiItem[15] + "', "
                            + updShukkoMeisaiItem[16] + ", "
                            + "'" + updShukkoMeisaiItem[17] + "',"
                            + "'" + updShukkoMeisaiItem[18] + "'";


                // 出庫ヘッダ更新_PROC
                con.ReadSql(strProc);
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        public void addHatchu(DBConnective con, string[] updHatchuItem)
        {
            try
            {
                string strProc = "発注更新_PROC "
                            + "'" + updHatchuItem[0] + "', "
                            + "'" + updHatchuItem[1] + "', "
                            + updHatchuItem[2] + ", "
                            + "'" + updHatchuItem[3] + "', "
                            + "'" + updHatchuItem[4] + "', "
                            + "'" + updHatchuItem[5] + "', "
                            + updHatchuItem[6] + ", "
                            + updHatchuItem[7] + ", "
                            + updHatchuItem[8] + ", "
                            + "'" + updHatchuItem[9] + "', "
                            + "'" + updHatchuItem[10] + "', "
                            + "'" + updHatchuItem[11] + "', "
                            + "'" + updHatchuItem[12] + "', "
                            + "'" + updHatchuItem[13] + "', "
                            + "'" + updHatchuItem[14] + "', "
                            + "'" + updHatchuItem[15] + "', "
                            + "'" + updHatchuItem[16] + "', "
                            + "'" + updHatchuItem[17] + "', "
                            + "'" + updHatchuItem[18] + "', "
                            + updHatchuItem[19] + ", "
                            + updHatchuItem[20] + ", "
                            + updHatchuItem[21] + ", "
                            + "'" + updHatchuItem[22] + "', "
                            + updHatchuItem[23] + ", "
                            + "'" + updHatchuItem[24] + "', "
                            + updHatchuItem[25] + ", "
                            + "'" + updHatchuItem[26] + "', "
                            + "'" + updHatchuItem[27] + "'";

                // 発注更新_PROC
                con.ReadSql(strProc);
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        public void delData(string denNo, string user)
        {
            DBConnective con = new DBConnective();
            string strSQL = "";

            try
            {
                con.BeginTrans();

                strSQL = "SELECT DISTINCT 発注番号 FROM 発注 WHERE 出庫番号= " + denNo + " AND 削除 = 'N'";
                DataTable dt =  con.ReadSql(strSQL);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //strSQL = "発注削除_PROC " + dt.Rows[i]["発注番号"] + ", '" + user + "'";
                        //con.ReadSql(strSQL);
                        delHaychu(con, dt.Rows[i]["発注番号"].ToString(), user);
                    }
                }

                strSQL = "出庫ヘッダ削除_PROC " + denNo + ", '" + user + "'";
                con.ReadSql(strSQL);

                strSQL = "出庫明細全削除_PROC " + denNo + ", '" + user + "'";
                con.ReadSql(strSQL);

                con.Commit();
            }
            catch
            {
                con.Rollback();
                throw;
            }
            finally
            {
                con.DB_Disconnect();
            }
        }

        public void delHaychu(DBConnective con, string no, string user)
        {
            string strSQL = "";

            try
            {
                strSQL = "発注削除_PROC " + no + ", '" + user + "'";
                con.ReadSql(strSQL);
            }
            catch
            {
                throw;
            }
        }

        public string getDenpyoNo(string tableName)
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@テーブル名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(tableName);

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

            return strRet;
        }

        public DataTable searchList(string shiire, string tanto, string hinmei)
        {
            DataTable dtRet = null;
            string strQuery = "";

            DBConnective dbCon = new DBConnective();
            try
            {
                strQuery += "SELECT H.伝票番号";
                strQuery += "     , CONVERT(VARCHAR, H.伝票年月日, 111) AS 年月日";
                strQuery += "     , dbo.f_get取引先名称(H.仕入先コード) AS 仕入先名";
                strQuery += "     , (ISNULL(M.Ｃ１,'') + ' '";
                strQuery += "           + ISNULL(M.Ｃ２,'') + ' '";
                strQuery += "           + ISNULL(M.Ｃ３,'') + ' '";
                strQuery += "           + ISNULL(M.Ｃ４,'') + ' '";
                strQuery += "           + ISNULL(M.Ｃ５,'') + ' '";
                strQuery += "           + ISNULL(M.Ｃ６,'')) AS 品名";
                strQuery += "     , M.数量";
                strQuery += "  FROM 出庫ヘッダ H";
                strQuery += "     , 出庫明細 M";
                strQuery += " WHERE H.削除 = 'N'";
                strQuery += "   AND M.削除 = 'N'";
                strQuery += "   AND H.伝票番号 = M.伝票番号";

                if (!string.IsNullOrWhiteSpace(shiire))
                {
                    strQuery += "   AND H.仕入先コード = '" + shiire + "'";
                }
                if (!string.IsNullOrWhiteSpace(tanto))
                {
                    strQuery += "   AND H.担当者コード = '" + tanto + "'";
                }
                if (!string.IsNullOrWhiteSpace(hinmei))
                {
                    strQuery += "   AND (RTRIM(ISNULL(M.Ｃ１, ''))";
                    strQuery += "           + RTRIM(ISNULL(M.Ｃ２, ''))";
                    strQuery += "           + RTRIM(ISNULL(M.Ｃ３, ''))";
                    strQuery += "           + RTRIM(ISNULL(M.Ｃ４, ''))";
                    strQuery += "           + RTRIM(ISNULL(M.Ｃ５, ''))";
                    strQuery += "           + RTRIM(ISNULL(M.Ｃ６, ''))) LIKE '%" + hinmei + "%'";
                }
                strQuery += " ORDER BY H.伝票年月日 DESC, H.仕入先コード";

                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }
    }
}
