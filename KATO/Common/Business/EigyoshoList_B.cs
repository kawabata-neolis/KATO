using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Windows.Forms;
using KATO.Form.F0140_TanaorosiInput;
using KATO.Form.M1090_Eigyosho;

namespace KATO.Common.Business
{
    ///<summary>
    ///EigyoushoList_B
    ///営業所リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class EigyoshoList_B
    {
        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable setDatagridView()
        {
            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstStringSQL = new List<string>();

                //SQLファイルのパスとファイル名を追加
                lstStringSQL.Add("Common");
                lstStringSQL.Add("CommonForm");
                lstStringSQL.Add("EigyoushoList_View");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput);

                //検索データを表示
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
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
            return (dtGetTableGrid);
        }

        ///<summary>
        ///EndAction
        ///戻るボタンの処理
        ///</summary>
        public void EndAction(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //棚卸入力のフォームを探す
                if (intFrmKind == CommonTeisu.FRM_TANAOROSHI && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setEigyoushoListClose();
                    break;
                }
                //営業所のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_EIGYOSHO && frm.Name == "M1090_Eigyosho")
                {
                    //データを連れてくるため、newをしないこと
                    M1090_Eigyosho eigyosho = (M1090_Eigyosho)frm;
                    eigyosho.CloseEigyoList();
                    break;
                }
            }
        }

        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        public void setSelectItem(int intFrmKind, string strSelectId)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstStringSQL = new List<string>();

                //SQLファイルのパスとファイル名を追加
                lstStringSQL.Add("Common");
                lstStringSQL.Add("C_LIST_Eigyosho_SELECT_LEAVE");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

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
                    //営業所
                    case CommonTeisu.FRM_EIGYOSHO:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //営業所のフォームを探す
                            if (frm.Name.Equals("M1090_Eigyosho"))
                            {
                                //データを連れてくるため、newをしないこと
                                M1090_Eigyosho eigyo = (M1090_Eigyosho)frm;
                                eigyo.setEigyoshoCode(dtSelectData);
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
    }
}
