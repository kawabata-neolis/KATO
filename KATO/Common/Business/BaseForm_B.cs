using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Common.Ctl;

namespace KATO.Common.Business
{
    ///<summary>
    ///UriageList_B
    ///BaseForm_B
    ///作成者：大河内
    ///作成日：2018/02/02
    ///更新者：大河内
    ///更新日：2018/02/02
    ///カラム論理名
    ///</summary>
    class BaseForm_B
    {
        ///<summary>
        ///getTantoKengen
        ///担当者の権限を取得
        ///</summary>
        public DataTable getTantoKengen(string strLoginID)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtTantoKengen = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_TantoshaKengen_Select");

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
                    return (dtTantoKengen);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput,strLoginID);

                //データ取得（ここから取得）
                dtTantoKengen = dbconnective.ReadSql(strSQLInput);

                return (dtTantoKengen);
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
    }
}
