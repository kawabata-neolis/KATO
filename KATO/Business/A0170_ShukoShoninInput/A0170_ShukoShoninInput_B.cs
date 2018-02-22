using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;

namespace KATO.Business.A0170_ShukoShoninInput
{
    ///<summary>
    ///A0170_ShukoShoninInput_B
    ///出庫承認入力
    ///作成者：大河内
    ///作成日：2017/02/22
    ///更新者：
    ///更新日：
    ///カラム論理名
    class A0170_ShukoShoninInput_B
    {
        ///<summary>
        ///getTantoshaCdSetUserID
        ///担当者コードの取得（ユーザーID検索）
        ///</summary>
        public DataTable getShukoGrid(string strUserID)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0170_ShukoShoninInput");
            lstSQL.Add("ShukoShoninInput_SELECT_GRID");

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
        ///addHachuInput
        ///データの追加
        ///</summary>
        public void updShukoShonin(List<Array> lstDenpyoNo, List<string> lstTableName, string strYMD, string strUserName)
        {
            //SQL用に移動
            DBConnective dbconnective = new DBConnective();

            //strGetData = (String[])lstDenpyoNo[intCnt];

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //データ分ループ
                for (int intCnt = 0; intCnt <= lstDenpyoNo.Count; intCnt ++)
                {
                    List<string> lstUpdData = new List<string>();
                    //lstUpdData.Add(lstDenpyoNo[intCnt]);
                    //lstUpdData.Add(DateTime.Parse(strYMD).ToString());
                    //lstUpdData.Add(lstShoninFlg[intCnt]);
                    //lstUpdData.Add();

                    //プロシージャ（戻り値なし）用のメソッドに投げる
                    dbconnective.RunSql("出庫依頼承認_PROC", CommandType.StoredProcedure, lstUpdData, lstTableName);
                }

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

    }
}
