using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common;
using KATO.Common.Util;
using System.Windows.Forms;
using System.Data;
using KATO.Common.Ctl;

namespace KATO.Business.F0140_TanaorosiInput_B
{
    ///<summary>
    ///F0140_TanaorosiInput_B
    ///棚卸入力
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class F0140_TanaorosiInput_B
    {
        ///<summary>
        ///setYMD
        ///最終棚卸年月日の表示
        ///</summary>
        public DataTable setYMD()
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtYMD = new DataTable();

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            string strSQLName = null;

            strSQLName = "Tanaorosi_SELECT_SetYMD";

            //データ渡し用
            lstStringSQL.Add("F0140_Tanaorosi");
            lstStringSQL.Add(strSQLName);

            try
            {
                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                strSQLInput = string.Format(strSQLInput);

                dtYMD = dbconnective.ReadSql(strSQLInput);

                dtYMD.Columns["Column1"].ColumnName = "最新棚卸年月日";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return (dtYMD);
        }

        ///<summary>
        ///addTanaoroshi
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addTanaoroshi(List<string> lstString)
        {
            string strSQLInput = null;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();

            try
            {
                strSQLInput = null;

                strSQLInput = "棚卸入力更新_PROC '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "','" + lstString[3] + "','" + lstString[4] + "','"  + lstString[5] + "','ADMIN'";

                dbconnective.RunSql(strSQLInput);

                //コミット開始
                dbconnective.Commit();

            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return;
        }

        ///<summary>
        ///setViewGrid
        ///Gridを表示させる
        ///</summary>
        public DataTable setViewGrid(List<string> lstString)
        {
            DataTable dtView = new DataTable();

            string strSQLInput = "";

            string strSQLName = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            lstStringSQL.Add("F0140_Tanaorosi");
            strSQLName = "Tanaorosi_SELECT_SetDataGridView";

            //データ渡し用
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            strSQLInput = opensql.setOpenSQL(lstStringSQL);

            if (lstString[3] != "")
            {
                strSQLInput = strSQLInput + " AND 中分類コード='" + lstString[2] + "'";
            }
            if (lstString[4] != "")
            {
                strSQLInput = strSQLInput + " AND 棚番='" + lstString[3] + "'";
            }
            if (lstString[5] != "")
            {
                strSQLInput = strSQLInput + " AND メーカーコード='" + lstString[4] + "'";
            }
            if (lstString[6] == "1")
            {
                strSQLInput = strSQLInput + " ORDER BY 品名型番";
            }
            if (lstString[6] == "2")
            {
                strSQLInput = strSQLInput + " ORDER BY メーカー名,品名型番";
            }
            if (lstString[6] == "3")
            {
                strSQLInput = strSQLInput + " ORDER BY 棚番,メーカー名,品名型番";
            }
            if (lstString[6] == "4")
            {
                strSQLInput = strSQLInput + " ORDER BY 棚番,品名型番";
            }

            //配列設定
            string[] aryStr = { lstString[0], lstString[1], lstString[2], lstString[3], lstString[4], lstString[5] };

            strSQLInput = string.Format(strSQLInput, aryStr);

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtView = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return (dtView);
        }


        ///<summary>
        ///setSelectItem
        ///データグリッドビューでの処理
        ///</summary>
        public DataTable setSelectItem(List<string> lstString)
        {
            DataTable dtSelect = null;

            string strSQLName = null;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            strSQLName = "Tanaorosi_SELECT_SetItem";

            //データ渡し用
            lstStringSQL.Add("F0140_Tanaorosi");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //配列設定
            string[] aryStr = { lstString[0], lstString[1] };

            strSQLInput = string.Format(strSQLInput, aryStr);

            try
            {
                dtSelect = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
            return (dtSelect);
        }
    }
}
