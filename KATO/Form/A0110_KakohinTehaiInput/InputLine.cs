using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Util;
using KATO.Business.A0110_KakohinTehaiInput;

namespace KATO.Form.A0110_KakohinTehaiInput
{
    public partial class InputLine : UserControl
    {

        public BaseText txtShohin;
        public BaseText txtC1;
        public BaseText txtC2;
        public BaseText txtC3;
        public BaseText txtC4;
        public BaseText txtC5;
        public BaseText txtC6;
        public BaseText txtHNo;
        public BaseText txtShiireMei;

        public InputLine()
        {
            InitializeComponent();
            txtShohin = new BaseText();
            txtC1 = new BaseText();
            txtC2 = new BaseText();
            txtC3 = new BaseText();
            txtC4 = new BaseText();
            txtC5 = new BaseText();
            txtC6 = new BaseText();
            txtHNo = new BaseText();
            txtShiireMei = new BaseText();
            lsDaibun.Lschubundata = lsChubun;
            lsDaibun.Lsmakerdata = lsMaker;
        }

        ///<summary>
        ///txtKeyDown
        ///キー入力判定（各テキストボックス）
        ///</summary>
        private void txtKeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    break;
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    break;
                default:
                    break;
            }
        }

        private void serchKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    showShohin();
                    break;
                default:
                    break;
            }
        }

        ///<summary>
        ///showShohin
        ///商品リスト展開
        ///</summary>
        private void showShohin()
        {
            string old = txtShohin.Text;

            KATO.Common.Form.ShouhinList shohinList = new KATO.Common.Form.ShouhinList(this);
            //shohinList.intFrmKind = CommonTeisu.FRM_JUCHUINPUT;
            shohinList.intFrmKind = 1;
            shohinList.blKensaku = false;
            shohinList.lsDaibunrui = lsDaibun;
            shohinList.lsChubunrui = lsChubun;
            shohinList.lsMaker = lsMaker;
            shohinList.btxtKensaku = txtKensaku;
            shohinList.btxtShohinCd = txtShohin;
            shohinList.btxtHinC1Hinban = txtHinban;
            shohinList.btxtHinC1 = txtC1;
            shohinList.btxtHinC2 = txtC2;
            shohinList.btxtHinC3 = txtC3;
            shohinList.btxtHinC4 = txtC4;
            shohinList.btxtHinC5 = txtC5;
            shohinList.btxtHinC6 = txtC6;
            shohinList.bmtxtShireTanka = txtTanka;

            if (!String.IsNullOrWhiteSpace(lsDaibun.CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(lsChubun.CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(lsMaker.CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(txtKensaku.Text))
            {
                shohinList.blKensaku = true;
            }

            shohinList.ShowDialog();
            txtKensaku.Text = "";

            if (!string.IsNullOrWhiteSpace(txtShohin.Text) && !old.Equals(txtShohin.Text))
            {
                txtSuryo.Focus();
            }
            shohinList.Dispose();

        }

        ///<summary>
        ///chkInput
        ///入力データチェック
        ///</summary>
        ///
        public bool chkInput(string denNo, bool hathuFlg)
        {
            // 品名のない行は登録対象外
            if (string.IsNullOrWhiteSpace(txtHinban.Text))
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(txtShohin.Text)) {
                // 大分類
                if (string.IsNullOrWhiteSpace(lsDaibun.CodeTxtText))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    this.lsDaibun.codeTxt.Focus();
                    return false;
                }

                // 中分類
                if (string.IsNullOrWhiteSpace(lsChubun.CodeTxtText))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    this.lsChubun.codeTxt.Focus();
                    return false;
                }

                // メーカー
                if (string.IsNullOrWhiteSpace(lsMaker.CodeTxtText))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    this.lsMaker.codeTxt.Focus();
                    return false;
                }
            }

            // 数量
            if (string.IsNullOrWhiteSpace(txtSuryo.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                this.txtSuryo.Focus();
                return false;
            }

            // 単価
            if (string.IsNullOrWhiteSpace(txtTanka.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                this.txtTanka.Focus();
                return false;
            }

            if (!hathuFlg) {
                // 出庫倉庫
                if (string.IsNullOrWhiteSpace(lsSouko.CodeTxtText))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    this.lsSouko.codeTxt.Focus();
                    return false;
                }
            }
            else
            {
                // 納期
                if (string.IsNullOrWhiteSpace(txtNoki.Text))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    this.txtNoki.Focus();
                    return false;
                }
            }

            // 在庫チェック(支給品(出庫)のみ)
            if (!hathuFlg && string.IsNullOrWhiteSpace(txtShohin.Text))
            {
                return true;
            }
            if (!hathuFlg && !(txtShohin.Text).Equals("88888") && !(lsDaibun.CodeTxtText).Equals("28"))
            {
                A0110_KakohinTehaiInput_B bis = new A0110_KakohinTehaiInput_B();

                try
                {
                    DataTable dt = bis.getZaiko(lsSouko.CodeTxtText, txtShohin.Text);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        decimal su = 0;
                        if (dt.Rows[0]["フリー在庫数"] != null && dt.Rows[0]["フリー在庫数"] != DBNull.Value)
                        {
                            su = decimal.Parse(dt.Rows[0]["フリー在庫数"].ToString());
                        }

                        // 更新の場合は出庫数も換算する
                        if (!string.IsNullOrWhiteSpace(denNo))
                        {
                            su = su + bis.getShukko(lsSouko.CodeTxtText, txtNo.Text);
                        }

                        if (su.CompareTo(decimal.Parse(txtSuryo.Text)) < 0)
                        {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "フリー在庫数を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();
                            this.txtSuryo.Focus();
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return true;
        }

        ///<summary>
        ///copyInput
        ///行コピー
        ///</summary>
        ///
        public void copyInput(InputLine c)
        {
            if (c == null)
            {
                return;
            }

            lsDaibun.CodeTxtText    = c.lsDaibun.CodeTxtText;
            lsDaibun.ValueLabelText = c.lsDaibun.ValueLabelText;
            lsChubun.CodeTxtText    = c.lsChubun.CodeTxtText;
            lsChubun.ValueLabelText = c.lsChubun.ValueLabelText;
            lsChubun.strDaibunCd    = c.lsChubun.strDaibunCd;
            lsMaker.CodeTxtText     = c.lsMaker.CodeTxtText;
            lsMaker.ValueLabelText  = c.lsMaker.ValueLabelText;
            lsMaker.strDaibunCd     = c.lsMaker.strDaibunCd;
            txtKensaku.Text         = c.txtKensaku.Text;
            txtHinban.Text          = c.txtHinban.Text;
            txtSuryo.Text           = c.txtSuryo.Text;
            txtTanka.Text           = c.txtTanka.Text;
            txtBiko.Text            = c.txtBiko.Text;
            lsSouko.CodeTxtText     = c.lsSouko.CodeTxtText;
            lsSouko.ValueLabelText  = c.lsSouko.ValueLabelText;
            txtShohin.Text          = c.txtShohin.Text;
            txtC1.Text              = c.txtC1.Text;
            txtC2.Text              = c.txtC2.Text;
            txtC3.Text              = c.txtC3.Text;
            txtC4.Text              = c.txtC4.Text;
            txtC5.Text              = c.txtC5.Text;
            txtC6.Text              = c.txtC6.Text;
            txtHNo.Text             = c.txtHNo.Text;
            txtNoki.Text            = c.txtNoki.Text;
            txtShiireMei.Text       = c.txtShiireMei.Text;
            // コピー元の行をクリア
            c.clearInput();
        }

        ///<summary>
        /// 入力クリア
        ///
        public void clearInput()
        {
            lsDaibun.CodeTxtText = "";
            lsDaibun.ValueLabelText = "";
            lsChubun.CodeTxtText = "";
            lsChubun.ValueLabelText = "";
            lsChubun.strDaibunCd = "";
            lsMaker.CodeTxtText = "";
            lsMaker.ValueLabelText = "";
            lsMaker.strDaibunCd = "";
            txtKensaku.Text = "";
            txtHinban.Text = "";
            txtSuryo.Text = "";
            txtTanka.Text = "";
            txtBiko.Text = "";
            lsSouko.CodeTxtText = "";
            lsSouko.ValueLabelText = "";
            txtShohin.Text = "";
            txtC1.Text = "";
            txtC2.Text = "";
            txtC3.Text = "";
            txtC4.Text = "";
            txtC5.Text = "";
            txtC6.Text = "";
            txtHNo.Text = "";
            txtNoki.Text = "";
            txtShiireMei.Text = "";
        }

    }
}
