using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.M1130_Shohizeiritsu;

namespace KATO.Common.Business
{
    ///<summary>
    ///ShohizeiritsuList_B
    ///データグリッドビュー表示
    ///作成者：大河内
    ///作成日：2017/3/23
    ///更新者：大河内
    ///更新日：2017/3/23
    ///カラム論理名
    ///</summary>
    class ShohizeiritsuList_B
    {
        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public DataTable setDatagridView(Boolean blnAll)
        {
            //データグリッドビューを入れる用
            DataTable dtGetTableGrid = new DataTable();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstStringSQL = new List<string>();

                //SQL文のタイトルを取得
                string strSQLName = "";

                //削除されているもの以外
                if (blnAll == false)
                {
                    strSQLName = "ShohizeiritsuList_View";
                }
                //全て
                else{
                    strSQLName = "ShohizeiritsuListAll_View";
                }

                //SQLファイルのパスとファイル名を追加
                lstStringSQL.Add("Common");
                lstStringSQL.Add("CommonForm");
                lstStringSQL.Add(strSQLName);

                //SQL発行
                OpenSQL opensql = new OpenSQL();

                //SQLファイルのパス取得
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput);

                //検索データを表示
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);

                return (dtGetTableGrid);
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        public void setEndAction(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //消費税率のフォームを探す
                if (intFrmKind == CommonTeisu.FRM_SHOHIZEIRITSU && frm.Name.Equals("M1130_Shohizeiritsu"))
                {
                    break;
                }
            }
        }
        
        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        public void setSelectItem(int intFrmKind, string strSelectId)
        {
            //検索データの受け取り用
            DataTable dtSelectData;

            //適用開始年月日の修正データ用
            DateTime dateSelect;
            
            //適用開始年月日の修正に使う変数
            string strSelectDate;

            //適用開始年月日の月を取得
            string strSelectMonth = "";

            //適用開始年月日の日を取得
            string strSelectDay = "";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を入れる用
                List<string> lstStringSQL = new List<string>();

                //SQLファイルのパスとファイル名を追加
                lstStringSQL.Add("Common");
                lstStringSQL.Add("C_LIST_Shohizeiritsu_SELECT_LEAVE");

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

                //適用開始年月日を取得
                strSelectDate = dtSelectData.Rows[0]["適用開始年月日"].ToString();

                //適用開始年月日をDate型に変換
                dateSelect = DateTime.Parse(strSelectDate);
                
                //月データ
                strSelectMonth = dateSelect.Month.ToString();

                //文字数が１桁の場合、0パディング
                if (strSelectMonth.Length == 1)
                {
                    strSelectMonth = dateSelect.Month.ToString().PadLeft(2, '0');
                }
                
                //日付データ
                strSelectDay = dateSelect.Day.ToString();

                //文字数が１桁の場合、0パディング
                if (strSelectDay.Length == 1)
                {
                    strSelectDay = dateSelect.Day.ToString().PadLeft(2, '0');
                }

                //適用開始年月日を再取り込み
                dtSelectData.Rows[0]["適用開始年月日"] = (dateSelect.Year + "/" + strSelectMonth + "/" + strSelectDay).ToString();

                //消費税率の桁数修正、再取り込み
                dtSelectData.Rows[0]["消費税率"] = StringUtl.updShishagonyu(dtSelectData.Rows[0]["消費税率"].ToString(), 1);

                //通常テキストボックスの場合に使用する
                switch (intFrmKind)
                {
                    case CommonTeisu.FRM_SHOHIZEIRITSU:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name.Equals("M1130_Shohizeiritsu"))
                            {
                                //データを連れてくるため、newをしないこと
                                M1130_Shohizeiritsu shohizeiritsu = (M1130_Shohizeiritsu)frm;
                                shohizeiritsu.setShohizeiritsu(dtSelectData);
                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }
    }
}
