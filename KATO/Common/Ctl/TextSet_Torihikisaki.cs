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

namespace KATO.Common.Ctl
{
    ///<summary>
    ///TextSet_Torihikisaki
    ///ラベルセット得意先（取引先）
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class TextSet_Torihikisaki : BaseTextTextSet
    {
        /// <summary>
        /// LabelSet_Tokuisaki
        /// 読み込み時
        /// </summary>
        public TextSet_Torihikisaki()
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
        ///judTokuisakiKeyDown
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void judTokuisakiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    TorihikisakiList torihikisakiList = new TorihikisakiList(this.Parent.Parent, this);
                    torihikisakiList.StartPosition = FormStartPosition.Manual;
                    torihikisakiList.intFrmKind = CommonTeisu.FRM_TOKUISAKI;
                    torihikisakiList.ShowDialog();
                }
                else
                {
                    TorihikisakiList torihikisakiList = new TorihikisakiList(this.Parent, this);
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
        ///updTxtTokuisakiLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public void updTxtTokuisakiLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            string strSQLName = null;

            Boolean blnGood;

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.valueTextText = "";
                this.AppendLabelText = "";
                return;
            }

            //禁止文字チェック
            blnGood = StringUtl.JudBanChr(this.CodeTxtText);
            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(this.CodeTxtText, CommonTeisu.NUMBER_ONLY);

            if (blnGood == false)
            {
                this.valueTextText = "";

                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(Parent.Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
                else
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }

            //前後の空白を取り除く
            this.CodeTxtText = this.CodeTxtText.Trim();

            if (this.CodeTxtText.Length < 4)
            {
                this.CodeTxtText = this.CodeTxtText.ToString().PadLeft(4, '0');
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

                    if (dtSetCd.Rows[0]["消費税計算区分"].ToString() == "0" || dtSetCd.Rows[0]["消費税計算区分"].ToString() == "2")
                    {
                        strZeikubun = "外税";
                    }
                    else if (dtSetCd.Rows[0]["消費税計算区分"].ToString() == "1")
                    {
                        strZeikubun = "内税";
                    }

                    this.CodeTxtText = dtSetCd.Rows[0]["取引先コード"].ToString();
                    this.valueTextText = dtSetCd.Rows[0]["取引先名称"].ToString();
                    this.AppendLabelText = strZeikubun;
                }
                else
                {
                    this.valueTextText = "";

                    //グループボックスかパネル内にいる場合
                    if (this.Parent is GroupBox || this.Parent is Panel)
                    {
                        //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return;
                    }
                    else
                    {
                        //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return;
                    }
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

        ///judTokuisakiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judTokuisakiKeyUp(object sender, KeyEventArgs e)
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

            Boolean blnGood;

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.valueTextText = "";
                this.AppendLabelText = "";
                return;
            }

            //禁止文字チェック
            blnGood = StringUtl.JudBanChr(this.CodeTxtText);
            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(this.CodeTxtText, CommonTeisu.NUMBER_ONLY);

            if (blnGood == false)
            {
                this.valueTextText = "";

                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(Parent.Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
                else
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }

            //前後の空白を取り除く
            this.CodeTxtText = this.CodeTxtText.Trim();

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

                    if (dtSetCd.Rows[0]["消費税計算区分"].ToString() == "0" || dtSetCd.Rows[0]["消費税計算区分"].ToString() == "2")
                    {
                        strZeikubun = "外税";
                    }
                    else if (dtSetCd.Rows[0]["消費税計算区分"].ToString() == "1")
                    {
                        strZeikubun = "内税";
                    }

                    this.CodeTxtText = dtSetCd.Rows[0]["取引先コード"].ToString();
                    this.valueTextText = dtSetCd.Rows[0]["取引先名称"].ToString();
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
        ///codeTxt_EnabledChanged
        ///Enabledが変更になった場合と解除
        ///</summary>
        private void codeTxt_EnabledChanged(object sender, EventArgs e)
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

        ///<summary>
        ///valueText_KeyDown
        ///名称入力項目でのキー入力判定
        ///</summary>
        private void valueText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }
    }
}
