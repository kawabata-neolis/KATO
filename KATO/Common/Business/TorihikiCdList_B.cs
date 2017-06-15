using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.M1070_Torihikisaki;

namespace KATO.Common.Business
{
    ///<summary>
    ///TorihikiCdList
    ///取引コードリスト
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class TorihikiCdList_B
    {
        /// <summary>
        /// setEndAction
        /// 終了時の処理
        /// </summary>
        public void setEndAction(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //取引先のフォームを探す
                if (intFrmKind == CommonTeisu.FRM_TORIHIKISAKI && frm.Name.Equals("M1070_Torihikisaki"))
                {
                    //データを連れてくるため、newをしないこと
                    M1070_Torihikisaki torihikisaki = (M1070_Torihikisaki)frm;
                    torihikisaki.setTorihikiCdListClose();
                    break;
                }
            }
        }

        /// <summary>
        /// setSelectItem
        /// データグリッドビュー内のデータ選択後の処理
        /// </summary>
        public void setSelectItem(int intFrmKind, string strSelectId)
        {
            //検索データの受け取り用
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstSQL = new List<string>();

                //SQLファイルのパスとファイル名を追加
                lstSQL.Add("Common");
                lstSQL.Add("C_LIST_TorihikisakiKensaku_SELECT_LEAVE");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strSelectId);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQL接続後、該当データを取得
                dtSelectData = dbconnective.ReadSql(strSQLInput);

                //移動元フォームの検索
                switch (intFrmKind)
                {
                    //取引先
                    case CommonTeisu.FRM_TORIHIKISAKI:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name.Equals("M1070_Torihikisaki"))
                            {
                                //データを連れてくるため、newをしないこと
                                M1070_Torihikisaki torihikisaki = (M1070_Torihikisaki)frm;
                                torihikisaki.setTorihikisakiCd(dtSelectData);
                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }
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
        ///setKensaku
        ///検索時の処理
        ///</summary>
        public DataTable setKensaku(List<Boolean> lstBoolean)
        {
            //データグリッドビューに表示する用
            DataTable dtGetTableGrid = new DataTable();

            //選ばれたデータの最小値を入れる用
            DataTable dtSelectMin = new DataTable();

            //選ばれたデータの最大値を入れる用
            DataTable dtSelectMax = new DataTable();
            
            string strSQL;
            string kana = "ｱ";
            string MinCode;
            string MaxCode;

            //各ボタンが押されているかどうかの判定
            if (lstBoolean[0] == true)
              kana = "ｱ";
            if (lstBoolean[1] == true)
              kana = "ｶ";
            if (lstBoolean[2] == true)
              kana = "ｻ";
            if (lstBoolean[3] == true)
              kana = "ﾀ";
            if (lstBoolean[4] == true)
              kana = "ﾅ";
            if (lstBoolean[5] == true)
              kana = "ﾊ";
            if (lstBoolean[6] == true)
              kana = "ﾏ";
            if (lstBoolean[7] == true)
              kana = "ﾔ";
            if (lstBoolean[8] == true)
              kana = "ﾗ";
            if (lstBoolean[9] == true)
              kana = "ﾜ";

            MinCode = "1101";
            MaxCode = "9999";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //該当データの最小値を取得
                strSQL = "";
                strSQL = strSQL + " SELECT MIN(取引先コード) ";
                strSQL = strSQL + " FROM 取引先コード検索";
                strSQL = strSQL + " WHERE カナ LIKE '" + kana + "%'";

                //検索データを取得
                dtSelectMin = dbconnective.ReadSql(strSQL);

                //検索結果が１件以上あった場合
                if (dtSelectMin.Rows.Count > 0)
                {
                    MinCode = dtSelectMin.Rows[0][0].ToString();
                }

                //該当データの最大値を取得
                strSQL = "";
                strSQL = strSQL + " SELECT MAX(取引先コード) ";
                strSQL = strSQL + " FROM 取引先コード検索";
                strSQL = strSQL + " WHERE カナ LIKE '" + kana + "%'";

                //検索データを取得
                dtSelectMax = dbconnective.ReadSql(strSQL);

                //検索結果が１件以上あった場合
                if (dtSelectMax.Rows.Count > 0)
                {
                    MaxCode = dtSelectMax.Rows[0][0].ToString();
                }

                //検索内で使用していない取引コードを取得を
                string StrWhere;
                StrWhere = "";
                StrWhere = StrWhere + " 取引先コード >= '" + MinCode + "'";
                StrWhere = StrWhere + " AND 取引先コード <= '" + MaxCode + "'";
                StrWhere = StrWhere + " AND 取引先名称 is NULL  ";
                StrWhere = " SELECT 取引先コード FROM 取引先コード検索 WHERE " + StrWhere + "ORDER BY 取引先コード ASC";

                //検索データを取得
                dtGetTableGrid = dbconnective.ReadSql(StrWhere);

                //カラム名の修正
                dtGetTableGrid.Columns["取引先コード"].ColumnName = "コード";

                return (dtGetTableGrid);
            }
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
