﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.M1050_Tantousha;
using KATO.Form.M1070_Torihikisaki;
using KATO.Form.B0250_MOnyuryoku;
using KATO.Form.C6000_TantoshabetuDenpyoCount;

namespace KATO.Common.Business
{
    ///<summary>
    ///TantoushaList_B
    ///担当者リスト
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class TantoushaList_B
    {
        //担当者別伝票処理件数画面内にある複数のテキストボックスの判断
        int intSelectTextBox = 0;

        // 表示カラムの表示フラグ
        bool blShowFlag = false;

        ///<summary>
        /// 担当者リストコンストラクタ
        /// 表示コントロール
        ///</summary>
        public TantoushaList_B(bool blFlag)
        {
            // 表示カラムのコントロール
            blShowFlag = blFlag;

        }

        ///<summary>
        ///getViewGrid
        ///読み込み時の処理
        ///</summary>
        public DataTable getViewGrid()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();
            string strAddWhile = "";

            //データ渡し用
            lstSQL.Add("Common");
            lstSQL.Add("CommonForm");
            lstSQL.Add("TantoushaList_View");

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

                // 表示コントロール
                if (blShowFlag == false)
                {
                    strAddWhile = " AND 担当者.表示 = '1' ";
                }
                else
                { 
                    strAddWhile = "";
                }

                string sql = string.Format(strSQLInput, strAddWhile);

                //検索データを表示
                dtGetTableGrid = dbConnective.ReadSql(sql);

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
        public void FormMove(int intFrmKind, int intSelectTextBox)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //担当者のフォームを探す
                if (intFrmKind == CommonTeisu.FRM_TANTOUSHA && frm.Name.Equals("M1050_Tantousha"))
                {
                    //データを連れてくるため、newをしないこと
                    M1050_Tantousha tantousha = (M1050_Tantousha)frm;
                    tantousha.CloseTantoshaList();
                    break;
                }
                else if (intFrmKind == CommonTeisu.FRM_TORIHIKISAKI && frm.Name.Equals("M1070_Torihikisaki"))
                {
                    //データを連れてくるため、newをしないこと
                    M1070_Torihikisaki torihikisaki = (M1070_Torihikisaki)frm;
                    torihikisaki.CloseTantoshaList();
                    break;
                }
            }
        }

        ///<summary>
        ///getSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>
        public void getSelectItem(int intFrmKind, string strSelectId, int intSelectTextBox)
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
                lstSQL.Add("C_LIST_Tantousha_SELECT_LEAVE");

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
                    //担当者
                    case CommonTeisu.FRM_TANTOUSHA:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name.Equals("M1050_Tantousha"))
                            {
                                //データを連れてくるため、newをしないこと
                                M1050_Tantousha tantousha = (M1050_Tantousha)frm;
                                tantousha.setTantousha(dtSelectData);
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
