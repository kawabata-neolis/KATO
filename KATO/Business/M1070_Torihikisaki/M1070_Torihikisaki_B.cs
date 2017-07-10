using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;

namespace KATO.Business.M1070_Torihikisaki
{
    ///<summary>
    ///M1070_Torihikisaki_B
    ///取引先のビジネス層
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
                    lstString[73],
                    lstString[74],
                    "N",
                    DateTime.Now.ToString(),
                    lstString[75],
                    DateTime.Now.ToString(),
                    lstString[75]
                };

                //SQL接続、追加
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_TORIHIKISAKI_UPD, aryStr);

                //コミット開始
                dbconnective.Commit();
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
                    lstString[73],
                    lstString[74],
                    "Y",
                    DateTime.Now.ToString(),
                    lstString[75],
                    DateTime.Now.ToString(),
                    lstString[75]
                };

                //SQL接続、削除
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_TORIHIKISAKI_UPD, aryStr);

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
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getTxtTorihikiCdLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public DataTable getTxtTorihikiCdLeave(string strTorihikiCD)
        {
            //データ渡し用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Torihikisaki_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

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
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strTorihikiCD);

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
    }
}
