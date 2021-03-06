﻿using System;
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

namespace KATO.Common.Business
{
    ///<summary>
    ///ShireList_B
    ///売上リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class ShireList_B
    {
        ///<summary>
        ///getDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable getDatagridView(List<string> lstShireView)
        {
            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            string strWhere;

            strWhere = "WHERE H.削除 = 'N' AND M.削除 = 'N' AND H.伝票番号=M.伝票番号 ";

            //担当者に記入がある場合
            if (StringUtl.blIsEmpty(lstShireView[0]))
            {
                strWhere = strWhere + " AND H.担当者コード ='" + lstShireView[0] + "'";
            }

            //取引先（表示は得意先）に記入がある場合
            if (StringUtl.blIsEmpty(lstShireView[1]))
            {
                strWhere = strWhere + " AND H.仕入先コード ='" + lstShireView[1] + "'";
            }

            //伝票年月日（開始）
            if (StringUtl.blIsEmpty(lstShireView[2]))
            {
                strWhere = strWhere + " AND H.伝票年月日 >='" + lstShireView[2] + "'";
            }
            //伝票年月日（終了）
            if (StringUtl.blIsEmpty(lstShireView[3]))
            {
                strWhere = strWhere + " AND H.伝票年月日 <='" + lstShireView[3] + "'";
            }
            
            //品名・型番に記入がある場合
            if (StringUtl.blIsEmpty(lstShireView[4]))
            {
                strWhere = strWhere + " AND (Rtrim(ISNULL(M.Ｃ１,'')) ";
                strWhere = strWhere + " +  Rtrim(ISNULL(M.Ｃ２,''))";
                strWhere = strWhere + " +  Rtrim(ISNULL(M.Ｃ３,''))";
                strWhere = strWhere + " +  Rtrim(ISNULL(M.Ｃ４,''))";
                strWhere = strWhere + " +  Rtrim(ISNULL(M.Ｃ５,''))";
                strWhere = strWhere + " +  Rtrim(ISNULL(M.Ｃ６,'')) ) LIKE '%" + lstShireView[4] + "%' ";
            }

            //発注番号（表示は注文番号）に記入がある場合
            if (StringUtl.blIsEmpty(lstShireView[5]))
            {
                strWhere = strWhere + " AND M.発注番号 ='" + lstShireView[5] + "'";
            }

            strWhere = strWhere + lstShireView[6];

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                string s = "SELECT H.伝票番号,H.伝票年月日,dbo.f_get取引先名称(H.仕入先コード) AS 仕入先名," +
                                                      "RTRIM(ISNULL(M.Ｃ１,'')) AS 品名型番," +
                                                      "M.数量,M.仕入単価 AS 売上単価,M.備考," +
                                                      "dbo.f_get担当者名(H.担当者コード) AS 担当者," +
                                                      "M.発注番号 AS 注文番号, CASE WHEN H.仮登録 = '1' THEN '仮' ELSE '' END AS 登録 " +
                                                      "FROM 仕入ヘッダ H,仕入明細 M " +
                                                      strWhere +
                                                      " ORDER BY H.伝票年月日 DESC, H.仕入先コード";

                dtGetTableGrid = dbconnective.ReadSql(s);
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
                            //データを連れてくるため、newをしないこと
                            A0030_ShireInput shireinput = (A0030_ShireInput)frm;
                            shireinput.setDenpyoShire(strDenpyo);
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
                    //データを連れてくるため、newをしないこと
                    A0030_ShireInput shireinput = (A0030_ShireInput)frm;
                    shireinput.setShireListClose();
                    break;
                }
            }
        }
    }
}
