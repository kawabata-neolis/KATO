using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Form.M1100_Chokusosaki;
using KATO.Form.A0030_ShireInput;
using KATO.Form.A0020_UriageInput;

namespace KATO.Common.Business
{
    ///<summary>
    ///UriageList_B
    ///売上リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class UriageList_B
    {
        ///<summary>
        ///getDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable getDatagridView(List<string> lstUriageView)
        {
            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            string strWhere;

            strWhere = "WHERE H.削除 = 'N' AND M.削除 = 'N' AND H.伝票番号=M.伝票番号 ";

            //担当者に記入がある場合
            if (StringUtl.blIsEmpty(lstUriageView[0]))
            {
                strWhere = strWhere + " AND 担当者コード ='" + lstUriageView[0] + "'";
            }

            //取引先（表示は得意先）に記入がある場合
            if (StringUtl.blIsEmpty(lstUriageView[1]))
            {
                strWhere = strWhere + " AND 得意先コード ='" + lstUriageView[1] + "'";
            }

            strWhere = strWhere + " AND 伝票年月日 >='" + lstUriageView[2] + "'";
            strWhere = strWhere + " AND 伝票年月日 <='" + lstUriageView[3] + "'";

            //品名・型番に記入がある場合
            if (StringUtl.blIsEmpty(lstUriageView[4]))
            {
                strWhere = strWhere + " AND (Rtrim(ISNULL(M.Ｃ１,'')) ";
                strWhere = strWhere + " +  Rtrim(ISNULL(M.Ｃ２,''))";
                strWhere = strWhere + " +  Rtrim(ISNULL(M.Ｃ３,''))";
                strWhere = strWhere + " +  Rtrim(ISNULL(M.Ｃ４,''))";
                strWhere = strWhere + " +  Rtrim(ISNULL(M.Ｃ５,''))";
                strWhere = strWhere + " +  Rtrim(ISNULL(M.Ｃ６,'')) ) LIKE '%" + lstUriageView[4] + "%' ";
            }

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                dtGetTableGrid = dbconnective.ReadSql("SELECT H.伝票番号,H.伝票年月日,H.得意先名," +
                                                      "RTRIM(ISNULL(M.Ｃ１,'')) + ' ' + RTRIM(ISNULL(M.Ｃ２,'')) + ' ' + RTRIM(ISNULL(M.Ｃ３,'')) + ' ' + RTRIM(ISNULL(M.Ｃ４,'')) + ' ' + RTRIM(ISNULL(M.Ｃ５,'')) + ' ' + RTRIM(ISNULL(M.Ｃ６,'')) + ' ' AS 品名・型番," +
                                                      "M.数量,M.売上単価,M.備考," +
                                                      "dbo.f_get担当者名(H.担当者コード) AS 担当者 " +
                                                      "FROM 売上ヘッダ H,売上明細 M " +
                                                      strWhere +
                                                      " ORDER BY H.伝票年月日 DESC, H.得意先コード");
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            return (dtGetTableGrid);
        }

        ///<summary>
        ///getSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>
        public void setSelectItem(int intFrmKind, string strDenpyo)
        {

            //移動元フォームの検索
            switch (intFrmKind)
            {
                //仕入入力
                case CommonTeisu.FRM_SHIREINPUT:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "A0030_ShireInput")
                        {
                            ////データを連れてくるため、newをしないこと
                            //A0030_ShireInput shireinput = (A0030_ShireInput)frm;
                            //shireinput.setDenpyo_Uriage(strDenpyo);
                            break;
                        }
                    }
                    break;

                //売上入力
                case CommonTeisu.FRM_URIAGEINPUT:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {

                        //目的のフォームを探す
                        if (frm.Name == "A0020_UriageInput")
                        {
                            //データを連れてくるため、newをしないこと
                            A0020_UriageInput uriageinput = (A0020_UriageInput)frm;
                            uriageinput.setDenpyo_Uriage(strDenpyo);
                            break;
                        }
                    }
                    break;


                default:
                    break;
            }
        }

        ///<summary>
        ///FormMove
        ///戻るボタンの処理
        ///</summary>
        public void FormMove(int intFrm)
        {
            //全てのフォームの中から移動元フォームの検索
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //直送先のフォームを探す
                if (intFrm == CommonTeisu.FRM_CHOKUSOSAKI && frm.Name == "A0030_ShireInput")
                {
                    ////データを連れてくるため、newをしないこと
                    //A0030_ShireInput shireinput = (A0030_ShireInput)frm;
                    //shireinput.setUriageListClose();
                    break;
                }

                //直送先のフォームを探す
                if (intFrm == CommonTeisu.FRM_CHOKUSOSAKI && frm.Name == "A0020_UriageInput")
                {
                    //データを連れてくるため、newをしないこと
                    A0020_UriageInput shireinput = (A0020_UriageInput)frm;
                    shireinput.setUriageListClose();
                    break;
                }
            }
        }
    }
}
