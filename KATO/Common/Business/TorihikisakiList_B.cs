using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Form.M1070_Torihikisaki;
using KATO.Form.M1071_TorihikisakiInfo;
using KATO.Common.Util;
using KATO.Form.A0030_ShireInput;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace KATO.Common.Business
{
    ///<summary>
    ///TorihikisakiList_B
    ///取引先リスト（処理部）
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：山本
    ///更新日：2017/12/28
    ///</summary>
    class TorihikisakiList_B
    {
        ///<summary>
        ///FormMove
        ///戻るボタンの処理
        ///</summary>
        public void FormMove(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //取引先のフォームを探す
                if (intFrmKind == CommonTeisu.FRM_TORIHIKISAKI && frm.Name.Equals("M1070_Torihikisaki"))
                {
                    //データを連れてくるため、newをしないこと
                    M1070_Torihikisaki torihikisaki = (M1070_Torihikisaki)frm;
                    torihikisaki.CloseTorihikisakiList();
                    break;
                }
                else if (intFrmKind == CommonTeisu.FRM_TORIHIKISAKI_INFO && frm.Name.Equals("M1071_TorihikisakiInfo"))
                {
                    M1071_TorihikisakiInfo torihikisaki = (M1071_TorihikisakiInfo)frm;
                    torihikisaki.CloseTorihikisakiList();
                }
                //仕入入力のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_SHIREINPUT && frm.Name.Equals("A0030_ShireInput"))
                {
                    //データを連れてくるため、newをしないこと
                    A0030_ShireInput shireinput = (A0030_ShireInput)frm;
                    shireinput.setTokuisakiListClose();
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
                    //取引先
                    case CommonTeisu.FRM_TORIHIKISAKI:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name.Equals("M1070_Torihikisaki"))
                            {
                                //データを連れてくるため、newをしないこと
                                M1070_Torihikisaki torihikisaki = (M1070_Torihikisaki)frm;
                                torihikisaki.setTorihikisaki(dtSelectData);
                                break;
                            }
                        }
                        break;
                    //仕入入力
                    case CommonTeisu.FRM_SHIREINPUT:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name.Equals("A0030_ShireInput"))
                            {
                                //データを連れてくるため、newをしないこと
                                A0030_ShireInput shireinput = (A0030_ShireInput)frm;
                                shireinput.setTorihikisaki(dtSelectData);
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

        /// <summary>
        /// gridに表示する取引先データ取得</summary>
        /// <param name="lstSelectData">
        ///     検索文字列用List</param>
        /// <returns>
        ///     検索結果をDataTableで返す</returns>
        public DataTable getTorihikisaki(List<string> lstSelectData)
        {
            DataTable dt = new DataTable();

            // AND条件用変数
            string andSql = "";

            // DBコネクションのインスタンス生成
            DBConnective dbConnective = new DBConnective();
            try
            {
                // フリガナが入力されている場合
                if (lstSelectData[0] != "")
                {
                    string kana = lstSelectData[0];

                    // 文字列"kana"に含まれる文字がすべて"ひらがな"か調べる
                    // すべてひらがな(true)なら変換
                    if (Regex.IsMatch(kana, @"^[\p{IsHiragana}\u30FC\u30A0]+$"))
                    {
                        // "ひらがな"を"カタカナ"に
                        kana = Strings.StrConv(kana, VbStrConv.Katakana, 0x411);
                    }
                    // 文字列"kana"に含まれる文字がすべて"カタカナ"か調べる
                    // すべてカタカナ(true)なら変換
                    //  通常の全角カタカナの他に、カタカナフリガナ拡張、
                    //  濁点と半濁点、半角カタカナもカタカナとする
                    if (Regex.IsMatch(kana, @"^[\p{IsKatakana}\u31F0-\u31FF\u3099-\u309C\uFF65-\uFF9F]+$"))
                    {
                        // 全角を半角に
                        kana = Strings.StrConv(kana, VbStrConv.Narrow, 0x411);
                    }

                    andSql += " AND カナ LIKE '%" + kana + "%'";
                }

                // 取引先名称が入力されている場合
                if (lstSelectData[1] != "")
                {
                    andSql +=  " AND 取引先名称 LIKE '%" + lstSelectData[1] + "%'";
                }

                // SQLのパス指定用List
                List<string> listSqlPath = new List<string>();
                listSqlPath.Add("Common");
                listSqlPath.Add("C_LIST_Torihikisaki_SELECT");

                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, andSql);

                // SQL実行
                dt = dbConnective.ReadSql(sql);

                return (dt);
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
