using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Common.Business
{
    /// KakouGenkaList_B
    /// 加工原価確認 ビジネスロジック
    /// 作成者：多田
    /// 作成日：2017/7/7
    /// 更新者：多田
    /// 更新日：2017/7/7
    /// カラム論理名
    /// </summary>
    class KakouGenkaList_B
    {
        /// <summary>
        /// getDatagridView
        /// データグリッドビュー表示
        /// </summary>
        public DataTable getDatagridView(string strSetGrid)
        {
            // データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            // 接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                // SQLファイルのパスとファイル名を入れる用
                List<string> lstSQL = new List<string>();

                // SQLファイルのパスとファイル名を追加
                lstSQL.Add("Common");
                lstSQL.Add("CommonForm");
                lstSQL.Add("KakouGenkaList_View");

                // SQL発行
                OpenSQL opensql = new OpenSQL();

                // SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                // SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strSetGrid);

                // 検索データを表示
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch
            {
                throw;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
            return (dtGetTableGrid);
        }
    }
}
