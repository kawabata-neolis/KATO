﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Common.Util;

namespace KATO.Common.Ctl
{
    ///<summary>
    ///LabelSet_Torihikisaki
    ///ラベルセット取引先
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class LabelSet_Torihikisaki : BaseTextLabelSet
    {
        //エラーメッセージを表示したかどうか
        public bool blMessageOn = false;

        /// <summary>
        /// searchOn
        /// 存在チェックを行う場合 true 
        /// 存在チェックを行わない場合 false
        /// </summary>
        public bool SearchOn = true;

        /// <summary>
        /// LabelSet_Torihikisaki
        /// 読み込み時
        /// </summary>
        public LabelSet_Torihikisaki()
        {
            InitializeComponent();
        }

        ///<summary>
        ///codeTxt_KeyDown
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void codeTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    TorihikisakiList torihikisakiList = new TorihikisakiList(this.Parent.Parent, this);
                    torihikisakiList.StartPosition = FormStartPosition.Manual;
                    torihikisakiList.intFrmKind = CommonTeisu.FRM_TOKUISAKI;
                    torihikisakiList.ShowDialog();
                }
                //親画面がBaseFormの場合
                else if (this.Parent is BaseForm)
                {
                    TorihikisakiList torihikisakiList = new TorihikisakiList(this.Parent, this);
                    torihikisakiList.StartPosition = FormStartPosition.Manual;
                    torihikisakiList.intFrmKind = CommonTeisu.FRM_TOKUISAKI;
                    torihikisakiList.ShowDialog();
                }
                //親画面がLIST画面の場合
                else
                {
                    //他と判別させるために空のオブジェクトを作成する
                    object obj = new object();

                    TorihikisakiList torihikisakiList = new TorihikisakiList(this.Parent, this, obj);
                    torihikisakiList.StartPosition = FormStartPosition.Manual;
                    torihikisakiList.intFrmKind = CommonTeisu.FRM_TOKUISAKI;
                    torihikisakiList.ShowDialog();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }

        ///<summary>
        ///codeTxt_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void codeTxt_Leave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
                this.AppendLabelText = "";
                return;
            }

            //前後の空白を取り除く
            this.CodeTxtText = this.CodeTxtText.Trim();

            //禁止文字チェック
            if (StringUtl.JudBanSQL(this.CodeTxtText) == false)
            {
                //Parent 内のすべてのコントロールを列挙する
                foreach (Control cControl in Parent.Controls)
                {
                    //列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                    if (cControl is BaseButton)
                    {
                        if (cControl.Text == "F12:戻る")
                        {
                            //フォーカスがボタンを指している場合
                            Control ctrlParent = ParentForm.ActiveControl;

                            if (ctrlParent.Name == "btnF12")
                            {
                                //全てのフォームの中から
                                foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                                {
                                    //商品のフォームを探す
                                    if (frm.Name == Parent.Name)
                                    {
                                        //仕入リストの場合
                                        if (frm.Name == "ShireList")
                                        {
                                            //データを連れてくるため、newをしないこと
                                            ShireList shirelist = (ShireList)frm;
                                            shirelist.btnEndClick(sender, e);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(Parent.Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    SendKeys.Send("+{TAB}");
                }
                else
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    SendKeys.Send("+{TAB}");
                }

                this.ValueLabelText = "";
                this.CodeTxtText = "";
                this.AppendLabelText = "";

                //エラーメッセージを表示された
                blMessageOn = true;
                return;
            }


            // 全角数字を半角数字に変換
            this.CodeTxtText = StringUtl.JudZenToHanNum(this.CodeTxtText);

            // 数値チェック
            if (StringUtl.JudBanSelect(this.CodeTxtText, CommonTeisu.NUMBER_ONLY) == true)
            {
                //4文字以下の場合0パティング
                if (this.CodeTxtText.Length < 4)
                {
                    this.CodeTxtText = this.CodeTxtText.ToString().PadLeft(4, '0');
                }
            }

            // 存在チェックを行い
            if (SearchOn == false)
            {
                return;
            }

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_Torihikisaki_SELECT_LEAVE");

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                if (strSQLInput == "")
                {
                    return;
                }

                strSQLInput = string.Format(strSQLInput, this.CodeTxtText);

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count != 0)
                {
                    string strZeikubun = "";

                    if (dtSetCd.Rows[0]["消費税区分"].ToString().Equals("0"))
                    {
                        strZeikubun = "外税";
                    }
                    else
                    {
                        strZeikubun = "内税";
                    }

                    this.CodeTxtText = dtSetCd.Rows[0]["取引先コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["取引先名称"].ToString();
                    this.AppendLabelText = strZeikubun;

                    blMessageOn = false;
                }
                else
                {

                    //グループボックスかパネル内にいる場合
                    if (this.Parent is GroupBox || this.Parent is Panel)
                    {
                        //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        SendKeys.Send("+{TAB}");
                    }
                    else
                    {
                        //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        SendKeys.Send("+{TAB}");
                    }

                    this.ValueLabelText = "";
                    this.CodeTxtText = "";
                    this.AppendLabelText = "";

                    blMessageOn = true;
                }
                return;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    SendKeys.Send("+{TAB}");
                    return;
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    SendKeys.Send("+{TAB}");
                    return;
                }
            }
        }

        ///<summary>
        /// chkTxtTorihikisaki
        /// ファンクション機能の取引先コードエラーチェック処理
        /// 引数　：なし
        /// 戻り値：エラー発生【true】
        ///</summary>
        public bool chkTxtTorihikisaki()
        {
            // データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
                this.AppendLabelText = "";
                return false;
            }

            // 前後の空白を取り除く
            this.CodeTxtText = this.CodeTxtText.Trim();

            // 禁止文字チェック
            if (StringUtl.JudBanSQL(this.CodeTxtText) == false)
            {
                // メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                this.ValueLabelText = "";
                this.AppendLabelText = "";
                this.CodeTxtText = "";

                return true;
            }


            // 全角数字を半角数字に変換
            this.CodeTxtText = StringUtl.JudZenToHanNum(this.CodeTxtText);

            // 数値チェック
            if (StringUtl.JudBanSelect(this.CodeTxtText, CommonTeisu.NUMBER_ONLY) == true)
            {
                // 4文字以下の場合0パティング
                if (this.CodeTxtText.Length < 4)
                {
                    this.CodeTxtText = this.CodeTxtText.ToString().PadLeft(4, '0');
                }
            }
 
            // 存在チェックを行い
            if (SearchOn == false)
            {
                return false;
            }

            // データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_Torihikisaki_SELECT_LEAVE");

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                if (strSQLInput == "")
                {
                    return false;
                }

                strSQLInput = string.Format(strSQLInput, this.CodeTxtText);

                // SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                // SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count != 0)
                {
                    string strZeikubun = "";

                    if (dtSetCd.Rows[0]["消費税区分"].ToString().Equals("0"))
                    {
                        strZeikubun = "外税";
                    }
                    else
                    {
                        strZeikubun = "内税";
                    }

                    this.CodeTxtText = dtSetCd.Rows[0]["取引先コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["取引先名称"].ToString();
                    this.AppendLabelText = strZeikubun;

                }
                else
                {
                    // メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    this.ValueLabelText = "";
                    this.AppendLabelText = "";
                    this.CodeTxtText = "";

                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {
                // データロギング
                new CommonException(ex);

                // 例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return true;

            }
        }

        ///codeTxt_KeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void codeTxt_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///codeTxt_TextChanged
        ///入力項目に変更があった場合
        ///</summary>
        private void codeTxt_TextChanged(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            string strSQLName = null;

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
                this.AppendLabelText = "";
                return;
            }

            //文字数が4以下の場合
            if (this.CodeTxtText.Length < 4)
            {
                return;
            }

            strSQLName = "C_LIST_Torihikisaki_SELECT_LEAVE";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                if (strSQLInput == "")
                {
                    return;
                }

                //配列設定
                string[] aryStr = { this.CodeTxtText };

                strSQLInput = string.Format(strSQLInput, aryStr);

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count != 0)
                {
                    string strZeikubun = "";

                    if (dtSetCd.Rows[0]["消費税区分"].ToString().Equals("0"))
                    {
                        strZeikubun = "外税";
                    }
                    else
                    {
                        strZeikubun = "内税";
                    }

                    this.CodeTxtText = dtSetCd.Rows[0]["取引先コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["取引先名称"].ToString();
                    this.AppendLabelText = strZeikubun;
                }
                return;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }
        }

        ///<summary>
        ///LabelSet_Torihikisaki_EnabledChanged
        ///Enabledが変更になった場合と解除
        ///</summary>
        private void LabelSet_Torihikisaki_EnabledChanged(object sender, EventArgs e)
        {
            //EnabledがFalseになった場合
            if (this.Enabled == false)
            {
                this.codeTxt.BackColor = SystemColors.Control;
            }
            else
            {
                this.codeTxt.BackColor = Color.White;
            }
        }
    }
}
