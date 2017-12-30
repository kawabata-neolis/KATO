using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Form;
using KATO.Common;
using KATO.Common.Util;
using System.Windows.Forms;
using System.Data;
using KATO.Common.Ctl;

namespace KATO.Business.M1000_Kaishajyoken
{
    /// <summary>
    /// M1000_Kaishajyoken_B
    /// 会社条件画面のビジネス層
    /// 作成者：宇津野
    /// 作成日：2017/7/8
    /// 更新者：宇津野
    /// 更新日：2017/7/8
    /// </summary>
    class M1000_Kaishajyoken_B
    {
        /// <summary>
        /// addKaishajyoken
        /// 会社条件情報をDB【会社処理条件テーブル】に登録及び更新
        /// </summary>
        public void addKaishajyoken(List<string> lstString)
        {
            //
            // 共通化されるので修正しないでください
            //
            // 接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            // トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                // 会社条件情報を会社処理条件テーブル用に再格納
                string[] aryStr = new string[] {
                    lstString[0],                // 会社コード
                    lstString[1],                // 会社名
                    lstString[2],                // 郵便番号
                    lstString[3],                // 住所１
                    lstString[4],                // 住所２
                    lstString[5],                // 代表者名
                    lstString[6],                // 電話番号
                    lstString[7],                // ＦＡＸ
                    lstString[8],                // 期首月
                    lstString[9],                // 開始年月日
                    lstString[10],               // 終了年月日
                    "N",                         // 削除
                    DateTime.Now.ToString(),     // 登録日時
                    lstString[11],               // 登録ユーザ名
                    DateTime.Now.ToString(),     // 更新日時
                    lstString[11]                // 更新ユーザ名
                };

                // ＳＱＬ発行（会社処理条件テーブル登録及び更新）
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_KAISHAJOKEN_UPD, aryStr);

                //コミット開始
                dbconnective.Commit();
            }
            // ＤＢコネクション例外処理
            catch (Exception ex)
            {
                // ロールバック開始
                dbconnective.Rollback();

                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        /// <summary>
        /// delDaibunrui
        /// 会社条件情報をDB【会社処理条件テーブル】に削除
        /// </summary>
        public void delKaishajyoken(List<string> lstString)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                // 会社条件情報を会社処理条件テーブル用に再格納
                string[] aryStr = new string[] {
                    lstString[0],                // 会社コード
                    lstString[1],                // 会社名
                    lstString[2],                // 郵便番号
                    lstString[3],                // 住所１
                    lstString[4],                // 住所２
                    lstString[5],                // 代表者名
                    lstString[6],                // 電話番号
                    lstString[7],                // ＦＡＸ
                    lstString[8],                // 期首月
                    lstString[9],                // 開始年月日
                    lstString[10],               // 終了年月日
                    "Y",                         // 削除
                    DateTime.Now.ToString(),     // 登録日時
                    lstString[11],               // 登録ユーザ名
                    DateTime.Now.ToString(),     // 更新日時
                    lstString[11]                // 更新ユーザ名
                };

                // SQL発行（会社処理条件テーブル削除）
                dbconnective.RunSqlCommon(CommonTeisu.C_SQL_KAISHAJOKEN_UPD, aryStr);

                // コミット開始
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

        /// <summary>
        /// getKaishajyoken
        /// 会社処理条件情報取得処理
        /// </summary>
        public DataTable getKaishajyoken(string strKaisyaCode)
        {
            // ＳＱＬ埋め込み用リスト生成
            List<string> stringSQLAry = new List<string>();

            // ＳＱＬファイル名格納
            string strSQLName = "M1000_Kaishajyoken_SELECT_LEAVE";

            //ＳＱＬファイル情報格納
            stringSQLAry.Add("M1000_Kaishajyoken");
            stringSQLAry.Add(strSQLName);

            // 会社処理条件情報格納用DataTable生成
            DataTable dtKaishajyokenInfo = new DataTable();

            // データベース接続用クラス宣言
            OpenSQL opensql = new OpenSQL();
            DBConnective dbconnective = new DBConnective();

            try
            {
                // ＳＱＬファイル内容取得
                string strSQLInput = opensql.setOpenSQL(stringSQLAry);

                if (strSQLInput == "")
                {
                    return (dtKaishajyokenInfo);
                }

                //配列設定
                string[] aryStr = { strKaisyaCode };

                // 会社処理条件情報用ＳＱＬ文作成
                strSQLInput = string.Format(strSQLInput, aryStr);

                // 会社処理条件情報取得
                dtKaishajyokenInfo = dbconnective.ReadSql(strSQLInput);

                return (dtKaishajyokenInfo);
            }
            // データベース例外処理をキャッチ
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }
    }
}
