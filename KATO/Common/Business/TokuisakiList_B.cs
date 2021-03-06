﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Form;
using KATO.Common.Util;
using System.Windows.Forms;

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
        ///<summary>
        ///setViewGrid
        ///読み込み時の処理
        ///</summary>
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

        ///<summary>
        ///FormMove
        ///戻るボタンの処理
        ///</summary>
        public void FormMove(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //例
                ////取引先のフォームを探す
                //if (intFrmKind == CommonTeisu.FRM_TORIHIKISAKI && frm.Name.Equals("M1070_Torihikisaki"))
                //{
                //    //データを連れてくるため、newをしないこと
                //    M1070_Torihikisaki torihikisaki = (M1070_Torihikisaki)frm;
                //    torihikisaki.setTokuisakiListClose();
                //    break;
                //}
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
                    //例
                    ////取引先
                    //case CommonTeisu.FRM_TORIHIKISAKI:
                    //    //全てのフォームの中から
                    //    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    //    {
                    //        //目的のフォームを探す
                    //        if (frm.Name.Equals("M1070_Torihikisaki"))
                    //        {
                    //            //データを連れてくるため、newをしないこと
                    //            M1070_Torihikisaki torihikisaki = (M1070_Torihikisaki)frm;
                    //            torihikisaki.setTorihikisaki(dtSelectData);
                    //            break;
                    //        }
                    //    }
                    //    break;
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
        ///getKensaku
        ///検索時の処理
        ///</summary>
        public DataTable getTokuisaki(string tokuiName)
        {
            //検索データの受け取り用
            DataTable dtGetTableGrid = new DataTable();

            //SQL文を記入する用
            string strWhere = null;

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();
            try
            {
                //業種コードが存在するか
                if (tokuiName != "")
                {
                    strWhere = strWhere + " WHERE 得意先名 LIKE '%" + tokuiName + "%'";
                }

                //検索データを表示
                dtGetTableGrid = dbConnective.ReadSql("SELECT a.得意先コード, a.得意先名 FROM AS400得意先名_VIEW a " + strWhere + " ORDER BY a.得意先コード ASC");

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
