using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.C0500_UrikakekinZandakaIchiranKakunin_B
{
    class C0500_UrikakekinZandakaIchiranKakunin_B
    {

        ///<summary>
        ///setGridTokusaiki
        ///得意先グリッドのデータ取得
        ///</summary>
        public DataTable setGridTokusaiki(List<string> lstStringViewData)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtKataban = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("MOnyuryoku_SELECT_GetDataKataban");

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
                    return (dtKataban);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput,
                                            lstStringViewData[0],   //年月度
                                            lstStringViewData[1],   //メーカーコード
                                            lstStringViewData[2],   //大分類コード
                                            lstStringViewData[3]   //中分類コード
                                            );

                //データ取得（ここから取得）
                dtKataban = dbconnective.ReadSql(strSQLInput);
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
            return (dtKataban);
        }

         

    }
}
