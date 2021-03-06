﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Form.M1490_Menukengen2;
using System.Windows.Forms;

namespace KATO.Common.Business
{
    ///<summary>
    ///MenuList_B
    ///メニューリスト（処理部）
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class MenuList_B
    {
        /// <summary>
        /// FormMove
        /// 戻るボタンの処理
        /// </summary>
        public void FormMove(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                // 戻るフォームを指定
                if (intFrmKind == CommonTeisu.FRM_MENUKENGEN2 && frm.Name.Equals("M1490_Menukengen2"))
                {
                    //データを連れてくるため、newをしないこと
                    M1490_Menukengen2 menukengen2 = (M1490_Menukengen2)frm;
                    menukengen2.CloseMenuList();
                    break;
                }
            }
        }

        ///<summary>
        ///getViewGrid
        ///読み込み時の処理
        ///</summary>
        public DataTable getViewGrid()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //データ渡し用
            lstSQL.Add("Common");
            lstSQL.Add("CommonForm");
            lstSQL.Add("MenuList_View");

            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

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
        /// getSelectItem
        /// データグリッドビュー内のデータ選択後の処理
        /// </summary>
        public void getSelectItem(int intFrmKind, string strSelectNo)
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
                lstSQL.Add("C_LIST_MenuList_SELECT_LEAVE");

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strSelectNo);

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
                    //例
                    //仕入先
                    //case CommonTeisu.FRM_TORIHIKISAKI:
                    //    //全てのフォームの中から
                    //    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    //    {
                    //例
                    ////目的のフォームを探す
                    //if (frm.Name.Equals("M1070_Torihikisaki"))
                    //{
                    //    //データを連れてくるため、newをしないこと
                    //    M1070_Torihikisaki torihikisaki = (M1070_Torihikisaki)frm;
                    //    torihikisaki.setTorihikisaki(dtSelectData);
                    //    break;
                    //}
                    //}
                    //break;
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
