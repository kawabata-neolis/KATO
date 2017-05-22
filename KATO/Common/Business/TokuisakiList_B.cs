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
    ///TokuisakiList_B
    ///得意先リスト（処理部）
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class TokuisakiList_B
    {
        string strSQLName = null;

        /// <summary>
        /// setViewGrid
        /// 読み込み時の処理
        /// </summary>
        public DataTable setViewGrid()
        {
            DataTable dtGetTableGrid = new DataTable();

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            try
            {
                strSQLName = "";

                strSQLName = "TokuisakiList_View";

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add("CommonForm");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //検索データを表示
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);

                return (dtGetTableGrid);

            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
            return (dtGetTableGrid);
        }

        /// <summary>
        /// setEndAction
        /// 終了時の処理
        /// </summary>
        public void setEndAction(List<int> lstInt)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //目的のフォームを探す
                if (lstInt[0] == 5 && frm.Name.Equals("F0140_TanaorosiInput"))
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaoroshi = (F0140_TanaorosiInput)frm;
                    tanaoroshi.setDaibunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 12 && frm.Name.Equals("M1070_Torihikisaki"))
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
        /// 選択後の処理
        /// </summary>
        public void setSelectItem(List<int> lstInt, List<string> lstString)
        {
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            strSQLName = "C_LIST_Torihikisaki_SELECT_LEAVE";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //配列設定
            string[] aryStr = { lstString[0] };

            strSQLInput = string.Format(strSQLInput, aryStr);

            dtSelectData = dbconnective.ReadSql(strSQLInput);

            switch (lstInt[0])
            {
                //大分類
                case 1:
                    break;
                //中分類
                case 2:
                    break;
                //取引先
                case 12:
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

        ///<summary>
        ///setKensaku
        ///検索時の処理
        ///</summary>
        public DataTable setKensaku(List<int> lstInt, List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strWhere = null;

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();

            strWhere = "WHERE a.削除 = 'N'";

            if (lstString[0] != "")
            {
                strWhere = strWhere + " AND 業種コード ='" + lstString[0] + "'";
            }

            if (lstString[1] != "")
            {
                strWhere = strWhere + " AND 営業担当者 ='" + lstString[1] + "'";
            }

            if (lstString[2] != "")
            {
                strWhere = strWhere + " AND 取引先名称 LIKE '%" + lstString[2] + "%'";
            }

            if (lstString[3] != "")
            {
                strWhere = strWhere + " AND カナ LIKE '" + lstString[3] + "%'";
            }

            if (lstString[4] != "")
            {
                strWhere = strWhere + " AND 電話番号 LIKE '" + lstString[4] + "%'";
            }

            dtGetTableGrid = dbconnective.ReadSql("SELECT a.取引先コード, a.取引先名称 FROM 取引先 a " + strWhere + " ORDER BY a.取引先コード ASC");

            return (dtGetTableGrid);
        }
    }
}
