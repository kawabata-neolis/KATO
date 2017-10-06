using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.Z1500_MyMenuSet
{
    ///<summary>
    ///Z1500_MyMenuSet_B
    ///マイメニューのビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class Z1500_MyMenuSet_B
    {
        ///<summary>
        ///getMenuSet
        ///各ユーザー用のデータを取得
        ///</summary>
        public DataTable getMenuSet(string strUserID)
        {
            //データ渡し用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("Z1500_MyMenuSet");
            lstSQL.Add("MyMenuSet_MenuSet_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return(dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strUserID);

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

        ///<summary>
        ///getMenuSet
        ///各ユーザー用のデータを取得
        ///</summary>
        public void addMyMenu(List<string> lstMakerData)
        {
            //データ渡し用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("Z1500_MyMenuSet");
            lstSQL.Add("MyMenuSet_MenuSet_UPDATE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                string[] aryStr = new string[]
                {
                    lstMakerData[0],
                    lstMakerData[1],
                    lstMakerData[2]
                };

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, aryStr);

                //SQL接続後、該当データを取得
                dbconnective.RunSql(strSQLInput);

                return;
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
