﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Form;
using KATO.Common.Util;
using System.Windows.Forms;
using KATO.Form.M1200_Group;

namespace KATO.Common.Business
{
    ///<summary>
    ///GroupCdList_B
    ///グループコードリストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class GroupCdList_B
    {
        ///<summary>
        ///getDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable getDatagridView()
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
                lstStringSQL.Add("GroupCdList_View");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

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
        ///FormMove
        ///元の画面に戻る
        ///</summary>
        public void FormMove(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //グループのフォームを探す
                if (intFrmKind == 1 && frm.Name.Equals("M1200_Group"))
                {
                    //データを連れてくるため、newをしないこと
                    M1200_Group group = (M1200_Group)frm;
                    group.setGroupListClose();
                    break;
                }
                else
                {
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
                lstStringSQL.Add("C_LIST_GroupCd_SELECT_LEAVE");

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
                    //グループ
                    case CommonTeisu.FRM_GROUP:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //グループマスタのフォームを探す
                            if (frm.Name.Equals("M1200_Group"))
                            {
                                //データを連れてくるため、newをしないこと
                                M1200_Group group = (M1200_Group)frm;
                                group.setGroup(dtSelectData);
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
