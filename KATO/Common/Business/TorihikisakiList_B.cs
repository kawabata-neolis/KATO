using KATO.Common.Util;
using KATO.Form.F0140_TanaorosiInput;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Form.M1070_Torihikisaki;

namespace KATO.Common.Business
{
    ///<summary>
    ///TorihikisakiList_B
    ///得意先リスト（処理部）
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class TorihikisakiList_B
    {
        /// <summary>
        /// setViewGrid
        /// 読み込み時の処理
        /// </summary>
        public DataTable setViewGrid()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstStringSQL = new List<string>();

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("CommonForm");
            lstStringSQL.Add("TokuisakiList_View");

            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtGetTableGrid);
                }

                //検索データを表示
                dtGetTableGrid = dbConnective.ReadSql(strSQLInput);

                return (dtGetTableGrid);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbConnective.DB_Disconnect();
            }
        }

        /// <summary>
        /// setEndAction
        /// 戻るボタンの処理
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
                    torihikisaki.setTokuisakiListClose();
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
                lstSQL.Add("C_LIST_Torihikisaki_SELECT_LEAVE");

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
                                torihikisaki.setTorihikisaki(dtSelectData);
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
        public DataTable setKensaku(List<string> lstSelectData)
        {
            //検索データの受け取り用
            DataTable dtGetTableGrid = new DataTable();

            //SQL文を記入する用
            string strWhere = null;

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();
            try
            {
                strWhere = "WHERE a.削除 = 'N'";

                //業種コードが存在するか
                if (lstSelectData[0] != "")
                {
                    strWhere = strWhere + " AND 業種コード ='" + lstSelectData[0] + "'";
                }
                //営業担当者が存在するか
                if (lstSelectData[1] != "")
                {
                    strWhere = strWhere + " AND 営業担当者 ='" + lstSelectData[1] + "'";
                }
                //取引先名称が存在するか
                if (lstSelectData[2] != "")
                {
                    strWhere = strWhere + " AND 取引先名称 LIKE '%" + lstSelectData[2] + "%'";
                }
                //カナが存在するか
                if (lstSelectData[3] != "")
                {
                    strWhere = strWhere + " AND カナ LIKE '" + lstSelectData[3] + "%'";
                }
                //電話番号が存在するか
                if (lstSelectData[4] != "")
                {
                    strWhere = strWhere + " AND 電話番号 LIKE '" + lstSelectData[4] + "%'";
                }

                //検索データを表示
                dtGetTableGrid = dbConnective.ReadSql("SELECT a.取引先コード, a.取引先名称 FROM 取引先 a " + strWhere + " ORDER BY a.取引先コード ASC");

                return (dtGetTableGrid);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbConnective.DB_Disconnect();
            }
        }
    }
}
