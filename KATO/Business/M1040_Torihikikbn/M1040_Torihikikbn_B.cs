using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.M1040_Torihikikbn
{
    ///<summary>
    ///M1040_Torihikikubun_B
    ///取引区分の処理部
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M1040_Torihikikbn_B
    {
        ///<summary>
        ///addDaibunrui
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addTorihikikubun(List<string> lstString)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] {
                    lstString[0],
                    lstString[1],
                    "N",
                    DateTime.Now.ToString(),
                    lstString[2],
                    DateTime.Now.ToString(),
                    lstString[2] };

                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_TORIHIKIKBN_UPD, aryStr);

                //コミット開始
                dbconnective.Commit();
            }

            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();

                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///delDaibunrui
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delTorihikikubun(List<string> lstString)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] {
                    lstString[0],
                    lstString[1],
                    "Y",
                    DateTime.Now.ToString(),
                    lstString[2],
                    DateTime.Now.ToString(),
                    lstString[2] };

                    dbconnective.RunSqlCommon(CommonTeisu.C_SQL_TORIHIKIKBN_UPD, aryStr);

                    //コミット開始
                    dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();

                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///updTxtTorikbnLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable updTxtTorikbnLeave(string strTorihikikbn)
        {
            //データ渡し用
            List<string> stringSQLAry = new List<string>();

            //データ渡し用
            stringSQLAry.Add("Common");
            stringSQLAry.Add("C_LIST_Torihikikbn_SELECT_LEAVE");

            DataTable dtSetCd_B = new DataTable();
            OpenSQL opensql = new OpenSQL();
            DBConnective dbconnective = new DBConnective();
            try
            {
                string strSQLInput = opensql.setOpenSQL(stringSQLAry);

                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                strSQLInput = string.Format(strSQLInput, strTorihikikbn);

                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
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
        }
    }
}
