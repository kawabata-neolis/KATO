using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Form.M1010_Daibunrui;
using KATO.Form.M1110_Chubunrui;
using KATO.Form.M1020_Maker;
using KATO.Form.F0140_TanaorosiInput;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Business
{
    ///<summary>
    ///MakerList_B
    ///メーカーリストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class MakerList_B
    {
        ///<summary>
        ///getDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable getDatagridView()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("CommonForm");
            lstSQL.Add("MakerList_View");

            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbConnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return(dtGetTableGrid);
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

        ///<summary>
        ///getKensaku
        ///検索
        ///</summary>
        public DataTable getKensaku(List<string> lstSearch)
        {
            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            //SQL文を入れる
            string strWhere = null;

            //接続用クラスのインスタンス作成
            DBConnective dbConnective = new DBConnective();
            try
            {
                strWhere = "WHERE a.削除 = 'N'";

                //大分類部
                if (lstSearch[0] != "")
                {
                    strWhere = strWhere + " AND a.メーカーコード IN (SELECT メーカーコード FROM 商品 WHERE 削除 = 'N' AND 大分類コード = '" + lstSearch[0] + "')";
                }

                //検索文字列部
                if (lstSearch[1] != "")
                {
                    //現行では検索不可能だが可能になった
                    strWhere = strWhere + "AND a.メーカー名 LIKE '%" + lstSearch[1] + "%'";
                }

                strWhere = strWhere + "ORDER BY メーカーコード ";

                dtGetTableGrid = dbConnective.ReadSql("SELECT a.メーカーコード, a.メーカー名 FROM メーカー a " + strWhere);
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
            return (dtGetTableGrid);
        }

        ///<summary>
        ///FormMove
        ///戻るボタンの処理
        ///</summary>
        public void FormMove(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //メーカーのフォームを探す
                if (intFrmKind == CommonTeisu.FRM_MAKER && frm.Name == "M1020_Maker")
                {
                    //データを連れてくるため、newをしないこと
                    M1020_Maker maker = (M1020_Maker)frm;
                    maker.closeMakerList();
                    break;
                }
                //棚卸入力のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_TANAOROSHI && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setMakerListClose();
                    break;
                }
                //棚卸入力（修正）のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_TANAOROSHI_EDIT && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setMakerListCloseEdit();
                    break;
                }
                //商品リストのフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_SHOUHINLIST && frm.Name == "ShouhinList")
                {
                    //データを連れてくるため、newをしないこと
                    ShouhinList shouhinlist = (ShouhinList)frm;
                    shouhinlist.setMakerListClose();
                    break;
                }
            }
        }

        ///<summary>
        ///getSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>
        public void getSelectItem(int intFrmKind, string strSelectId)
        {
            //検索データの受け取り用
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbConnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstStringSQL = new List<string>();

                //SQLファイルのパスとファイル名を追加
                lstStringSQL.Add("Common");
                lstStringSQL.Add("C_LIST_Maker_SELECT_LEAVE");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strSelectId);

                //SQL文を直書き（＋戻り値を受け取る)
                dtSelectData = dbConnective.ReadSql(strSQLInput);

                //移動元フォームの検索
                switch (intFrmKind)
                {
                    //メーカー
                    case CommonTeisu.FRM_MAKER:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "M1020_Maker")
                            {
                                //データを連れてくるため、newをしないこと
                                M1020_Maker maker = (M1020_Maker)frm;
                                maker.setMakerCode(dtSelectData);
                                break;
                            }
                        }
                        break;
                    //商品リスト
                    case CommonTeisu.FRM_SHOUHINLIST:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "ShouhinList")
                            {
                                //データを連れてくるため、newをしないこと
                                ShouhinList shouhinlist = (ShouhinList)frm;
                                shouhinlist.setMakerCode(dtSelectData);
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
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbConnective.DB_Disconnect();
            }
        }
    }
}
