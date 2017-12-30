using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common;
using KATO.Common.Util;
using System.Windows.Forms;
using System.Data;

namespace KATO.Business.TanaorosiInput
{    
    class TanaorosiInput_B
    {
        ///<summary>
        ///setYMD
        ///最終棚卸年月日の表示
        ///作成者：大河内
        ///作成日：2017/3/22
        ///更新者：大河内
        ///更新日：2017/4/10
        ///カラム論理名
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
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            strSQLInput = string.Format(strSQLInput);

            dtYMD = dbconnective.ReadSql(strSQLInput);

            dtYMD.Columns["Column1"].ColumnName = "最新棚卸年月日";

            return (dtYMD);
        }

        ///<summary>
        ///addTanaoroshi
        ///テキストボックス内のデータをDBに登録
        ///作成者：大河内
        ///作成日：2017/3/22
        ///更新者：大河内
        ///更新日：2017/4/10
        ///カラム論理名
        ///</summary>
        public void addTanaoroshi(string strTxtYMD, string strTxtEigyousyo, string strTxtShouhinCD, string strTxtTanasuu, string strTxtTanabanEdit)
        {
            string strSQLInput = null;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();

            try
            {
                strSQLInput = null;

                strSQLInput = "棚卸入力更新_PROC '" + strTxtYMD + "','" + strTxtEigyousyo + "','" + strTxtShouhinCD + "','" + strTxtTanasuu + "','" + strTxtTanabanEdit + "', 'ADMIN'";
                dbconnective.RunSql(strSQLInput);

                //コミット開始
                dbconnective.Commit();

                MessageBox.Show("登録。", "登録", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                //ロールバック開始
                dbconnective.Rollback();
                MessageBox.Show("登録失敗。", "登録", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        ///<summary>
        ///txtGridViewLieave
        ///code入力箇所からフォーカスが外れた時(Grid表示関係)
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/4/10
        ///カラム論理名
        ///</summary>
        public DataTable txtGridViewLieave(int intDBjud, List<string> lstString)
        {
            //テキストボックスのデータを確保
            string strTextCase = "";

            string strSQLName = null;

            string strSQLInput = null;

            string[] strArray = new string[] { };

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetcode_B = new DataTable();

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //どこのDBを参照するか
            switch (intDBjud)
            {
                case 1://営業所
                    if (lstString[0] == "")
                    {
                        return(dtSetcode_B);
                    }
                    else if (lstString[0].Length <= 3)
                    {
                        strTextCase = lstString[0].ToString().PadLeft(4, '0');
                    }
                    else
                    {
                        strTextCase = lstString[0];
                    }

                    strSQLName = "EigyoushoList_SELECT_DataView";

                    //データ渡し用
                    lstStringSQL.Add(strSQLName);

                    OpenSQL opensql = new OpenSQL();
                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    strArray = new string[] { strTextCase };
                    break;
                case 2://大分類

                    if (lstString[1] == "")
                    {
                        return (dtSetcode_B);
                    }
                    else if (lstString[1].Length == 1)
                    {
                        strTextCase = lstString[1].ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        strTextCase = lstString[1];
                    }

                    strSQLName = "M1010_Daibun_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add("M1010_Daibunrui");
                    lstStringSQL.Add(strSQLName);

                    opensql = new OpenSQL();
                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    strArray = new string[] { strTextCase };
                    break;
                case 3://中分類
                    if (lstString[2] == "")
                    {
                        return (dtSetcode_B);
                    }
                    else if (lstString[2].Length == 1)
                    {
                        strTextCase = lstString[2].ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        strTextCase = lstString[2];
                    }

                    strSQLName = "M1110_Chubun_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add("M1110_Chubunrui");
                    lstStringSQL.Add(strSQLName);

                    opensql = new OpenSQL();
                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    strArray = new string[] { lstString[1], strTextCase };
                    break;
                case 4://メーカー
                    if (lstString[3] == "")
                    {
                        return (dtSetcode_B);
                    }
                    else if (lstString[3].Length <= 2)
                    {
                        strTextCase = lstString[3].ToString().PadLeft(3, '0');
                    }
                    else
                    {
                        strTextCase = lstString[3];
                    }

                    strSQLName = "M1020_Maker_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add("M1020_Maker");
                    lstStringSQL.Add(strSQLName);

                    opensql = new OpenSQL();
                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    strArray = new string[] { strTextCase };
                    break;
                case 5://棚番
                    if (lstString[4] == "")
                    {
                        return (dtSetcode_B);
                    }
                    else if (lstString[4].Length <= 5)
                    {
                        //blnBtnMove = true;
                        return (dtSetcode_B);
                    }
                    else
                    {
                        strTextCase = lstString[4];
                    }
                    strSQLName = "Tanaban_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add(strSQLName);

                    opensql = new OpenSQL();
                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    strArray = new string[] { strTextCase };
                    break;
                case 6://編集中分類
                    if (lstString[5] == "")
                    {
                        return (dtSetcode_B);
                    }
                    else if (lstString[5].Length == 1)
                    {
                        strTextCase = lstString[5].ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        strTextCase = lstString[5];
                    }
                    strSQLName = "M1110_Chubun_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add("M1110_Chubunrui");
                    lstStringSQL.Add(strSQLName);

                    opensql = new OpenSQL();
                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    strArray = new string[] { lstString[1], strTextCase };
                    break;
                case 7://編集メーカー
                    if (lstString[6] == "")
                    {
                        return (dtSetcode_B);
                    }
                    else if (lstString[6].Length <= 2)
                    {
                        strTextCase = lstString[6].ToString().PadLeft(3, '0');
                    }
                    else
                    {
                        strTextCase = lstString[6];
                    }
                    strSQLName = "M1020_Maker_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add("M1020_Maker");
                    lstStringSQL.Add(strSQLName);

                    opensql = new OpenSQL();
                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    strArray = new string[] { strTextCase };
                    break;
                case 8://編集棚番
                    if (lstString[7] == "")
                    {
                        return (dtSetcode_B);
                    }
                    else if (lstString[7].Length <= 5)
                    {
                        return (dtSetcode_B);
                    }
                    else
                    {
                        strTextCase = lstString[7];
                    }
                    strSQLName = "Tanaban_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add(strSQLName);

                    opensql = new OpenSQL();
                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    strArray = new string[] { strTextCase };
                    break;
                default:
                    return(dtSetcode_B);
            }

            strSQLInput = string.Format(strSQLInput, strArray);

            //SQL文を直書き（＋戻り値を受け取る)
            dtSetcode_B = dbconnective.ReadSql(strSQLInput);

            return (dtSetcode_B);
        }

        ///<summary>
        ///setViewGrid
        ///Gridを表示させる
        ///作成者：大河内
        ///作成日：2017/3/28
        ///更新者：大河内
        ///更新日：2017/4/10
        ///カラム論理名
        ///</summary>
        public DataTable setViewGrid(List<string> lstString)
        {
            DataTable dtView = new DataTable();

            string strSQLInput = null;

            //初期化
            strSQLInput = "";

            string strSQLName = null;

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

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
            string[] strArray = { lstString[0], lstString[1], lstString[2], lstString[3], lstString[4], lstString[5] };

            strSQLInput = string.Format(strSQLInput, strArray);

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            dtView = dbconnective.ReadSql(strSQLInput);

            return (dtView);
        }


        ///<summary>
        ///setSelectItem
        ///データグリッドビューの処理
        ///作成者：大河内
        ///作成日：2017/3/28
        ///更新者：大河内
        ///更新日：2017/4/10
        ///カラム論理名
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
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //配列設定
            string[] strArray = { lstString[0], lstString[1] };

            strSQLInput = string.Format(strSQLInput, strArray);

            dtSelect = dbconnective.ReadSql(strSQLInput);

            return (dtSelect);

        }
    }
    }
