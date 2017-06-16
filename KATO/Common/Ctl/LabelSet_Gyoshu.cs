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
    ///LabelSet_GyoshuCd
    ///ラベルセット得意先（業種）
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class LabelSet_Gyoshu : BaseTextLabelSet
    {
        /// <summary>
        /// LabelSet_GyoshuCd
        /// 読み込み時
        /// </summary>
        public LabelSet_Gyoshu()
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
        ///judGyoshuKeyDown
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void judGyoshuKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (this.Parent is GroupBox)
                {
                    GyoshuList GyoshuList = new GyoshuList(this.Parent.Parent, this);
                    GyoshuList.StartPosition = FormStartPosition.Manual;
                    GyoshuList.intFrmKind = CommonTeisu.FRM_GYOSHU;
                    GyoshuList.ShowDialog();
                }
                else
                {
                    GyoshuList GyoshuList = new GyoshuList(this.Parent, this);
                    GyoshuList.StartPosition = FormStartPosition.Manual;
                    GyoshuList.intFrmKind = CommonTeisu.FRM_GYOSHU;
                    GyoshuList.ShowDialog();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }

        ///<summary>
        ///updTxtGyoshuLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public void updTxtGyoshuLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            Boolean blnGood;

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
                this.ValueLabelText = "";

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
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

            if (this.CodeTxtText.Length <= 3)
            {
                this.CodeTxtText = this.CodeTxtText.ToString().PadLeft(4, '0');
            }

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_Gyoshu_SELECT_LEAVE");

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
                    this.CodeTxtText = dtSetCd.Rows[0]["業種コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["業種名"].ToString();
                }
                else
                {
                    this.ValueLabelText = "";

                    //グループボックス内にいる場合
                    if (this.Parent is GroupBox)
                    {
                        //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
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

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
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

        ///judGyoshuKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judGyoshuKeyUp(object sender, KeyEventArgs e)
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
            
            strSQLName = "C_LIST_Gyoshu_SELECT_LEAVE";

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
                    this.CodeTxtText = dtSetCd.Rows[0]["業種コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["業種名"].ToString();
                }
                return;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
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
    }
}
