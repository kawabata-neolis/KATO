using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.A0030_ShireInput
{
    ///<summary>
    ///A0030_ShireInput_B
    ///仕入入力のビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class A0030_ShireInput_B
    {
        ///<summary>
        ///getHidukeseigen
        ///日付制限の確保
        ///</summary>
        public DataTable getHidukeseigen(string strGamenID, string strEigyoshoCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_GDateCheckEG");

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
                strSQLInput = string.Format(strSQLInput, strGamenID, strEigyoshoCd);

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
        ///delShireInput
        ///仕入入力情報の削除
        ///</summary>
        public void delShireInput(string strDenpyoNo, string strUserID)
        {
            string strSQL = null;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                strSQL = "仕入ヘッダ削除_PROC '" + strDenpyoNo + "','" + strUserID + "'";
                dbconnective.ReadSql(strSQL);

                //コミット開始
                dbconnective.Commit();

                strSQL = "発注_仕入数_戻し更新_PROC '" + strDenpyoNo + "','" + strUserID + "'";
                dbconnective.ReadSql(strSQL);

                //コミット開始
                dbconnective.Commit();

                strSQL = "仕入明細削除_PROC '" + strDenpyoNo + "','" + strUserID + "'";
                dbconnective.ReadSql(strSQL);

                //コミット開始
                dbconnective.Commit();

                strSQL = "運賃消去_PROC '" + strDenpyoNo + "','" + strUserID + "'";
                dbconnective.ReadSql(strSQL);

                //コミット開始
                dbconnective.Commit();

                return;
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getShireHeader
        ///仕入ヘッダテーブル上のデータを確保
        ///</summary>
        public DataTable getShireHeader(string strDenpyoNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_ShireHeader_SELECT");

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
                strSQLInput = string.Format(strSQLInput, strDenpyoNo);

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
        ///getKenshuShire
        ///仕入ヘッダテーブル上のデータを確保
        ///</summary>
        public DataTable getKenshuShire(string strDenpyoNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_KenshuzumiShire_SELECT_COUNT");

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
                strSQLInput = string.Format(strSQLInput, strDenpyoNo);

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
        ///getShireMesai
        ///仕入ヘッダテーブル上のデータを確保
        ///</summary>
        public DataTable getShireMesai(string strDenpyoNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_Shiremeisai_SELECT");

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
                strSQLInput = string.Format(strSQLInput, strDenpyoNo);

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
        ///getHachuJuchu
        ///発注受注データを記入
        ///</summary>
        public DataTable getHachuJuchu(string strHNo)
        {
            DataTable dtHachuJuchu;

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                dtHachuJuchu = dbconnective.ReadSql("SELECT dbo.f_get発注番号_受注番号FROM発注('" + strHNo + "')");

                return dtHachuJuchu;
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
        ///getJuchuTanka
        ///受注単価データを記入
        ///</summary>
        public DataTable getJuchuTanka(string strJuchuNo)
        {
            DataTable dtHachuJuchu;

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                dtHachuJuchu = dbconnective.ReadSql("SELECT dbo.f_get受注番号から受注単価('" + strJuchuNo + "')");

                return dtHachuJuchu;
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