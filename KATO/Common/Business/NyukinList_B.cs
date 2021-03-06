﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Form.B0040_NyukinInput;

namespace KATO.Common.Business
{
    ///<summary>
    ///NyukinList_B
    ///入金リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class NyukinList_B
    {
        ///<summary>
        ///getDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable getDatagridView(string strSetGrid)
        {
            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            //フォーマットするもの用
            string strSQLInput;

            //空文字を削除
            strSetGrid = strSetGrid.Trim();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstSQL = new List<string>();

                //検索時にテキストに書かれていない場合
                if (strSetGrid == "")
                {
                    //SQLファイルのパスとファイル名を追加
                    lstSQL.Add("Common");
                    lstSQL.Add("CommonForm");
                    lstSQL.Add("NyukinList_View");

                    //SQL発行
                    OpenSQL opensql = new OpenSQL();

                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQL);

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput);
                }
                else
                {
                    //SQLファイルのパスとファイル名を追加
                    lstSQL.Add("Common");
                    lstSQL.Add("C_LIST_NyukinList_SELECT");

                    //SQL発行
                    OpenSQL opensql = new OpenSQL();

                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQL);

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput, strSetGrid);
                }

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
        ///getSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>
        public DataTable getSelectItem(int intFrmKind, string strDenpyo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_NyukinList_SELECT_Denpyo");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSelectData = new DataTable();

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return(dtSelectData);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strDenpyo);

                //SQL接続後、該当データを取得
                dtSelectData = dbconnective.ReadSql(strSQLInput);

                return (dtSelectData);
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
