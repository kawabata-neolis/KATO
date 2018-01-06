using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.TokuteimukesakiTankaList_B
{
    ///<summary>
    ///TokuteimukesakiTankaList_B
    ///特定向け先単価リストのビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class TokuteimukesakiTankaList_B
    {
        ///<summary>
        ///getDatagridView
        ///データ検索
        ///</summary>
        public DataTable getDatagridView(string strKataban, string strShiresakiCd, string strShohinCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパス用（追加WHERE用）
            string strSQLInputAdd = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B0250_MOnyuryoku");
            lstSQL.Add("TokuteimukesakiTankaList_SELECT_GetDataGridView");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //仕入先コードがある場合
            if (StringUtl.blIsEmpty(strShiresakiCd))
            {
                strSQLInputAdd = strSQLInputAdd + "AND 仕入先コード = '" + strShiresakiCd + "' ";
            }

            //商品コードがある場合
            if (StringUtl.blIsEmpty(strShohinCd))
            {
                strSQLInputAdd = strSQLInputAdd + "AND 商品コード = '" + strShohinCd + "' ";
            }

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
                strSQLInput = string.Format(strSQLInput, strSQLInputAdd);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

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

            return (dtSetCd_B);
        }
    }
}
