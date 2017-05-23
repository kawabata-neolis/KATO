using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.M1070_Torihikisaki
{
    ///<summary>
    ///M1070_Torihikisaki_B
    ///取引先フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M1070_Torihikisaki_B
    {
        ///<summary>
        ///addTorihiki
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addTorihiki(List<string> lstString)
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
                    lstString[2],
                    lstString[3],
                    lstString[4],
                    lstString[5],
                    lstString[6],
                    lstString[7],
                    lstString[8],
                    lstString[9],
                    lstString[10],
                    lstString[11],
                    lstString[12],
                    lstString[13],
                    lstString[14],
                    lstString[15],
                    lstString[16],
                    lstString[17],
                    lstString[18],
                    lstString[19],
                    lstString[20],
                    lstString[21],
                    lstString[22],
                    lstString[23],
                    lstString[24],
                    lstString[25],
                    lstString[26],
                    lstString[27],
                    lstString[28],
                    lstString[29],
                    lstString[30],
                    lstString[31],
                    lstString[32],
                    lstString[33],
                    lstString[34],
                    lstString[35],
                    lstString[36],
                    lstString[37],
                    lstString[38],
                    lstString[39],
                    lstString[40],
                    lstString[41],
                    lstString[42],
                    lstString[43],
                    lstString[44],
                    lstString[45],
                    lstString[46],
                    lstString[47],
                    lstString[48],
                    lstString[49],
                    lstString[50],
                    lstString[51],
                    lstString[52],
                    lstString[53],
                    lstString[54],
                    lstString[55],
                    lstString[56],
                    lstString[57],
                    lstString[58],
                    lstString[59],
                    lstString[60],
                    lstString[61],
                    lstString[62],
                    lstString[63],
                    lstString[64],
                    lstString[65],
                    lstString[66],
                    lstString[67],
                    lstString[68],
                    lstString[69],
                    lstString[70],
                    lstString[71],
                    lstString[72],
                    "N",
                    DateTime.Now.ToString(),
                    lstString[73],
                    DateTime.Now.ToString(),
                    lstString[73]
                };
                
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_TORIHIKISAKI_UPD, aryStr);
            
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
        ///delTorihiki
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delTorihiki(List<string> lstString)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] { lstString[0] };

                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_TORIHIKISAKI_DEL, aryStr);

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
        ///updTxtTorihikiCdLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable updTxtTorihikiCdLeave(List<string> lstString)
        {
            //データ渡し用
            List<string> stringSQLAry = new List<string>();

            string strSQLName = null;

            strSQLName = "C_LIST_Torihikisaki_SELECT_LEAVE";

            //データ渡し用
            stringSQLAry.Add("Common");
            stringSQLAry.Add(strSQLName);

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

                //配列設定
                string[] aryStr = { lstString[0] };

                strSQLInput = string.Format(strSQLInput, aryStr);

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
