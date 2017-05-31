using KATO.Common.Util;
using KATO.Form.F0140_TanaorosiInput;
using KATO.Form.M1120_Tanaban;
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
    ///TanabanList_B
    ///データグリッドビュー表示
    ///作成者：大河内
    ///作成日：2017/3/23
    ///更新者：大河内
    ///更新日：2017/3/23
    ///カラム論理名
    ///</summary>
    class TanabanList_B
    {
        string strSQLName = null;

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable setDatagridView()
        {
            DataTable dtGetTableGrid = new DataTable();

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                strSQLName = "";

                strSQLName = "TanabanList_View";

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add("CommonForm");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                strSQLInput = string.Format(strSQLInput);

                //検索データを表示
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception e)
            {
                new CommonException(e);
                throw (e);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return (dtGetTableGrid);
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        public void setEndAction(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //目的のフォームを探す
                if (intFrmKind == CommonTeisu.FRM_TANAOROSHI && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setTanabanListClose();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_TANAOROSHI_EDIT && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setTanaListCloseEdit();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_TANABAN && frm.Name == "M1120_Tanaban")
                {
                    //データを連れてくるため、newをしないこと
                    M1120_Tanaban tanaban = (M1120_Tanaban)frm;
                    tanaban.setTanabanListClose();
                    break;
                }
            }
        }
        
        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        public void setSelectItem(int intFrmKind, List<string> lstString)
        {
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //データ渡し用
                List<string> lstStringSQL = new List<string>();

                strSQLName = "C_LIST_Tanaban_SELECT_LEAVE";

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //配列設定
                string[] aryStr = { lstString[0] };

                strSQLInput = string.Format(strSQLInput, aryStr);

                dtSelectData = dbconnective.ReadSql(strSQLInput);

                //通常テキストボックスの場合に使用する
                switch (intFrmKind)
                {
                    case CommonTeisu.FRM_TANABAN:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name.Equals("M1120_Tanaban"))
                            {
                                //データを連れてくるため、newをしないこと
                                M1120_Tanaban tanaban = (M1120_Tanaban)frm;
                                tanaban.setTanabanCd(dtSelectData);
                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                new CommonException(e);
                throw (e);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }
    }
}
