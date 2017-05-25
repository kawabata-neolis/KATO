using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.F0140_TanaorosiInput;
using KATO.Form.M1050_Tantousha;

namespace KATO.Common.Business
{
    ///<summary>
    ///TantoushaList_B
    ///担当者リスト
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class TantoushaList_B
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
            DBConnective dbConnective = new DBConnective();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();
            try
            {
                strSQLName = "";

                strSQLName = "TantoushaList_View";

                //データ渡し用
                lstStringSQL.Add("Common");
                lstStringSQL.Add("CommonForm");
                lstStringSQL.Add(strSQLName);

                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //検索データを表示
                dtGetTableGrid = dbConnective.ReadSql(strSQLInput);

                return (dtGetTableGrid);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
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
                if (lstInt[0] == 4 && frm.Name.Equals("M1050_Tantousha"))
                {
                    //データを連れてくるため、newをしないこと
                    M1050_Tantousha tantousha = (M1050_Tantousha)frm;
                    tantousha.setTantouListClose();
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

            strSQLName = "C_LIST_Tantousha_SELECT_LEAVE";

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
                case CommonTeisu.FRM_TANTOUSHA:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name.Equals("M1050_Tantousha"))
                        {
                            //データを連れてくるため、newをしないこと
                            M1050_Tantousha tantousha = (M1050_Tantousha)frm;
                            tantousha.setTantousha(dtSelectData);
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }        
    }
}
