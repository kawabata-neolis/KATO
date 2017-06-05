using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.M1030_Shohin
{
    ///<summary>
    ///M1030_Shohin_B
    ///商品フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class M1030_Shohin_B
    {
        ///<summary>
        ///addShohizeiritsu
        ///テキストボックス内のデータをDBに登録の下準備（商品コードが被らないようにする）
        ///</summary>
        public void updShohinNew(List<string> lstString, Boolean blnKanri)
        {
            //データ渡し用
            List<string> stringSQLAry = new List<string>();

            string strSQLName = null;

            int intNewCd;
            string strNewCd = "99999";

            if(blnKanri == true)
            {
                strSQLName = "C_LIST_Shohin_SELECT_MAXCd";
            }
            else
            {
                strSQLName = "C_LIST_Shohin_SELECT_kari_MAXCd";
            }

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
                    return;
                }

                strSQLInput = string.Format(strSQLInput);

                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                char chrNewCdHead = ' ';
                string strNewCdOther = "";

                //中身が空
                if (dtSetCd_B.Rows[0]["最新コード"].ToString() == "")
                {
                    strNewCd = "00001";
                    lstString[0] = strNewCd.ToString();
                }
                //中身がある
                else
                {
                    chrNewCdHead = dtSetCd_B.Rows[0]["最新コード"].ToString().Substring(0, 1)[0];

                    strNewCdOther = dtSetCd_B.Rows[0]["最新コード"].ToString().Substring(1);

                    //先頭以外が9999の場合
                    if (strNewCdOther == "9999")
                    {
                        strNewCdOther = "0001";

                        //先頭が9の場合
                        if (chrNewCdHead == '9')
                        {

                            chrNewCdHead = 'A';
                        }
                        else
                        {
                            //アスキーコード取得、加算
                            int intASCII = chrNewCdHead;
                            intASCII = intASCII + 1;
                            chrNewCdHead = (char)intASCII;
                        }
                        lstString[0] = chrNewCdHead + strNewCdOther;
                    }
                    else
                    {
                        intNewCd = int.Parse(strNewCdOther.Substring(1));

                        intNewCd = intNewCd + 1;

                        lstString[0] = chrNewCdHead + intNewCd.ToString().PadLeft(4, '0').ToString();
                    }
                }
                addShohin(lstString, blnKanri);
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

        ///<summary>
        ///addShohin
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addShohin(List<string> lstString, Boolean blnKanri)
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
                    "N",
                    DateTime.Now.ToString(),
                    lstString[22],
                    DateTime.Now.ToString(),
                    lstString[22]
                };

                if (blnKanri == true)
                {
                    dbconnective.RunSqlCommon(CommonTeisu.C_SQL_SHOHIN_UPD, aryStr);
                }
                else
                {
                    dbconnective.RunSqlCommon(CommonTeisu.C_SQL_SHOHIN_KARI_UPD, aryStr);
                }

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
        ///delShohin
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delShohin(List<string> lstString , Boolean blnKanri)
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
                    "Y",
                    DateTime.Now.ToString(),
                    lstString[22],
                    DateTime.Now.ToString(),
                    lstString[22]
                };

                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_SHOHIN_UPD, aryStr);

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
    }
}
