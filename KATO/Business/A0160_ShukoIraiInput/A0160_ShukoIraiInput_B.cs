using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;

namespace KATO.Business.A0160_ShukoIraiInput
{
    ///<summary>
    ///A0160_ShukoIraiInput_B
    ///出庫依頼入力
    ///作成者：大河内
    ///作成日：2017/02/20
    ///更新者：
    ///更新日：
    ///カラム論理名
    class A0160_ShukoIraiInput_B
    {
        ///<summary>
        ///getTantoshaCdSetUserID
        ///担当者コードの取得（ユーザーID検索）
        ///</summary>
        public DataTable getTantoshaCdSetUserID(string strUserID)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtTantoshaCd = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0160_ShukoIraiInput");
            lstSQL.Add("ShukoIraiInput_TantoshaData_SELECT");

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
        ///getNewDenpyo
        ///伝票番号テーブルから新規伝票番号を得る
        ///</summary>
        public DataTable getNewDenpyo(string strTableName)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("A0100_HachuInput");
            lstSQL.Add("HachuInput_Denpyo_UPDATE_SELECT");

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
                strSQLInput = string.Format(strSQLInput, strTableName);

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
        ///addShukoInput
        ///データの追加
        ///</summary>
        public void addShukoInput(List<string> lstStringData, List<string> lstStringTanblename)
        {
            //SQL用に移動
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //プロシージャ（戻り値なし）用のメソッドに投げる
                dbconnective.RunSql("出庫依頼入力更新_PROC", CommandType.StoredProcedure, lstStringData, lstStringTanblename);

                //コミット
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
            return;
        }

        ///<summary>
        ///updShukoInputDel
        ///データの削除
        ///</summary>
        public void updShukoInputDel(List<string> lstStringData, List<string> lstStringTanblename)
        {
            //SQL用に移動
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //プロシージャ（戻り値なし）用のメソッドに投げる
                dbconnective.RunSql("出庫依頼入力削除_PROC", CommandType.StoredProcedure, lstStringData, lstStringTanblename);

                //コミット
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
            return;
        }

        ///<summary>
        ///getShukoGrid
        ///出庫依頼明細グリッド表示用のデータを取得
        ///</summary>
        public DataTable getShukoGrid(string strTantoshaCd, string strShukoEigyosho)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();
            
            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0160_ShukoIraiInput");
            lstSQL.Add("ShukoIraiInput_SELECT_GRID");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //追加WHERE
            string strSQLadd = "";

            //担当者コードがある場合
            if (strTantoshaCd != "")
            {
                strSQLadd = strSQLadd + "AND 担当者コード = '" + strTantoshaCd + "'";
            }

            //出庫営業所コードがある場合
            if (strShukoEigyosho != "")
            {
                strSQLadd = strSQLadd + "AND 出庫倉庫 = '" + strShukoEigyosho + "'";
            }

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
                strSQLInput = string.Format(strSQLInput, strSQLadd);

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
        ///strDenpyoNo
        ///伝票番号から出庫依頼データを取得
        ///</summary>
        public DataTable getShukoData(string strDenpyoNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0160_ShukoIraiInput");
            lstSQL.Add("ShukoIraiInput_SELECT_LEAVE");

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
    }
}
