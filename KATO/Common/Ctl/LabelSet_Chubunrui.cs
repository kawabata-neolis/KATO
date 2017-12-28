using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Form.F0140_TanaorosiInput;

namespace KATO.Common.Ctl
{
    ///<summary>
    ///LabelSet_Chubunrui
    ///ラベルセット中分類
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class LabelSet_Chubunrui : BaseTextLabelSet
    {
        //大分類コード確保用
        string strdaibunCd;

        //エラーメッセージを表示したかどうか
        public bool blMessageOn = false;

        /// <summary>
        /// strDaibunCd
        /// プロパティの設定（大分類コード）
        /// </summary>
        public string strDaibunCd
        {
            get
            {
                return this.strdaibunCd;
            }
            set
            {
                this.strdaibunCd = value;
            }
        }

        /// <summary>
        /// LabelSet_Chubunrui
        /// 読み込み時
        /// </summary>
        public LabelSet_Chubunrui()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OnPaint
        /// control.paintのイベント発生
        /// </summary>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        ///<summary>
        ///judChubunruiKeyDown
        ///コード入力項目でのキー入力判定（中分類）
        ///</summary>
        private void judChubunruiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                //大分類の値がない場合
                if (this.strdaibunCd == null)
                {
                    return;
                }

                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    ChubunruiList chubunruiList = new ChubunruiList(this.Parent.Parent, this, strdaibunCd);
                    chubunruiList.Show();
                }
                //親画面がBaseFormの場合
                else
                {
                    ChubunruiList chubunruiList = new ChubunruiList(this.Parent, this, strdaibunCd);
                    chubunruiList.Show();

                }

            }
            else if (e.KeyCode == Keys.Enter)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }

        ///<summary>
        ///updTxtChubunruiLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void updTxtChubunruiLeave(object sender, EventArgs e)
        {
            setTxtChubunruiLeave();
        }

        ///<summary>
        ///updTxtChubunruiLeave
        ///code入力箇所からフォーカスが外れた時の処理
        ///</summary>
        public void setTxtChubunruiLeave()
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            Boolean blnGood;

            if (this.strdaibunCd == null)
            {
                return;
            }

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
                this.AppendLabelText = "";

                return;
            }

            //禁止文字チェック
            blnGood = StringUtl.JudBanChr(this.CodeTxtText);
            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(this.CodeTxtText, CommonTeisu.NUMBER_ONLY);

            if (blnGood == false)
            {
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

            //前後の空白を取り除く
            this.CodeTxtText = this.CodeTxtText.Trim();

            if (this.CodeTxtText.Length == 1)
            {
                CodeTxtText = CodeTxtText.ToString().PadLeft(2, '0');
            }

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_Chubun_SELECT_LEAVE");

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                if (strSQLInput == "")
                {
                    return;
                }

                //配列設定
                string[] aryStr = { this.strdaibunCd, this.CodeTxtText };

                strSQLInput = string.Format(strSQLInput, aryStr);

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count != 0)
                {
                    this.CodeTxtText = dtSetCd.Rows[0]["中分類コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["中分類名"].ToString();

                    blMessageOn = false;
                }
                else
                {
                    //グループボックスかパネル内にいる場合
                    if (this.Parent is GroupBox || this.Parent is Panel)
                    {
                        //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
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

                    //空にする
                    this.ValueLabelText = "";
                    this.CodeTxtText = "";
                    this.AppendLabelText = "";

                    blMessageOn = true;
                    return;
                }
            }
            catch (Exception ex)
            {
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
        /// chkTxtChubunrui
        /// ファンクション機能の中分類コードエラーチェック処理
        /// 引数　：大分類コード
        /// 戻り値：エラー発生【true】
        ///</summary>
        public bool chkTxtChubunrui(string daibunrui)
        {
            // データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            Boolean blnGood;

            if (daibunrui == null)
            {
                return false;
            }

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
                this.CodeTxtText = "";
                this.AppendLabelText = "";
                return false;
            }

            // 禁止文字チェック
            blnGood = StringUtl.JudBanChr(this.CodeTxtText);
            // 数字のみを許可する
            blnGood = StringUtl.JudBanSelect(this.CodeTxtText, CommonTeisu.NUMBER_ONLY);

            if (blnGood == false)
            {

                // メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                // 空にする
                this.ValueLabelText = "";
                this.CodeTxtText = "";
                this.AppendLabelText = "";

                return true;
            }

            // 前後の空白を取り除く
            this.CodeTxtText = this.CodeTxtText.Trim();

            if (this.CodeTxtText.Length == 1)
            {
                this.CodeTxtText = CodeTxtText.ToString().PadLeft(2, '0');
            }

            // データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_Chubun_SELECT_LEAVE");

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                if (strSQLInput == "")
                {
                    return false;
                }

                // 配列設定
                string[] aryStr = { daibunrui, this.CodeTxtText };

                strSQLInput = string.Format(strSQLInput, aryStr);

                // SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                // SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count != 0)
                {
                    this.CodeTxtText = dtSetCd.Rows[0]["中分類コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["中分類名"].ToString();
                }
                else
                {
                    // メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    // 空にする
                    this.ValueLabelText = "";
                    this.CodeTxtText = "";
                    this.AppendLabelText = "";

                    return true;
                }
            }
            catch (Exception ex)
            {

                // 例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return true;

            }
            return false;
        }

        ///<summary>
        ///judtxtChubunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtChubunruiKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///LabelSet_Chubunrui_EnabledChanged
        ///Enabledが変更になった場合と解除
        ///</summary>
        private void LabelSet_Chubunrui_EnabledChanged(object sender, EventArgs e)
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
