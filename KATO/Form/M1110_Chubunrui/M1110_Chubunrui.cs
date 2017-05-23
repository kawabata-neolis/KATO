using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Business.M1010_Daibunrui;
using KATO.Business.M1110_Chubunrui;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1110_Chubunrui
{
    ///<summary>
    ///M1110_Chubunrui
    ///中分類フォーム
    ///作成者：大河内
    ///作成日：2017/2/2
    ///更新者：大河内
    ///更新日：2017/2/2
    ///カラム論理名
    ///</summary>
    public partial class M1110_Chubunrui : BaseForm
    {
        /// <summary>
        /// M1110_Chubunrui
        /// フォーム関係の設定
        /// </summary>
        public M1110_Chubunrui(Control c)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;

            //最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;
        }

        /// <summary>
        /// M_Chubunrui_Load
        /// 読み込み時
        /// </summary>
        private void M_Chubunrui_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "中分類マスタ";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;
        }

        ///<summary>
        ///judChubunruiKeyDown
        ///キー入力判定
        ///</summary>
        private void judChubunruiKeyDown(object sender, KeyEventArgs e)
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
                    break;
                case Keys.F1:
                    this.addChubunrui();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delChubunrui();
                    break;
                case Keys.F4:
                    delText();
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
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judChubunTxtKeyDown
        ///キー入力判定
        ///</summary>
        private void judChubunTxtKeyDown(object sender, KeyEventArgs e)
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
                    this.addChubunrui();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delChubunrui();
                    break;
                case Keys.F4:
                    delText();
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
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judTxtChuTxtKeyDown
        ///キー入力判定
        ///</summary>
        private void judTxtChuTxtKeyDown(object sender, KeyEventArgs e)
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
                    this.addChubunrui();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delChubunrui();
                    break;
                case Keys.F4:
                    delText();
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
                    judtxtChubunKeyDown(sender, e);
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judBtnClick
        ///ボタンの反応
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    this.addChubunrui();
                    break;
                case STR_BTN_F03: // 削除
                    this.delChubunrui();
                    break;
                case STR_BTN_F04: // 取り消し
                    delText();
                    break;
                //case STR_BTN_F11: //印刷
                //    this.XX();
                //    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///judtxtCyokuCDKeyDown
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void judtxtChubunKeyDown(object sender, KeyEventArgs e)
        {
            //F9を押して且つ大分類コードが記載されている状態
            if (e.KeyCode == Keys.F9 && LabelSet_Daibun.CodeTxtText != "")
            {
                double dblCheck;

                if (double.TryParse(LabelSet_Daibun.CodeTxtText, out dblCheck))
                {
                    LabelSet_Chubunrui lblSetChubunSelect = new LabelSet_Chubunrui();
                    ChubunruiList chubunruilist = new ChubunruiList(this, lblSetChubunSelect, LabelSet_Daibun.CodeTxtText);
                    try
                    {
                        chubunruilist.StartPosition = FormStartPosition.Manual;
                        chubunruilist.intFrmKind = KATO.Common.Util.CommonTeisu.FRM_CYUBUNRUI;
                        chubunruilist.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        new CommonException(ex);
                    }
                }
            }
        }


        ///<summary>
        ///addChubunrui
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addChubunrui()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (StringUtl.blIsEmpty(LabelSet_Daibun.CodeTxtText) == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                LabelSet_Daibun.Focus();
                return;
            }
            //文字判定
            if (txtChubunrui.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtChubunrui.Focus();
                return;
            }
            //文字判定
            if (txtElem.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtElem.Focus();
                return;
            }

            //データ渡し用
            lstString.Add(LabelSet_Daibun.CodeTxtText);
            lstString.Add(txtChubunrui.Text);
            lstString.Add(txtElem.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動
            M1110_Chubunrui_B chubunB = new M1110_Chubunrui_B();
            try
            {
                chubunB.addChubunrui(lstString);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                LabelSet_Daibun.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除
        ///</summary>
        private void delText()
        {
            delFormClear(this);
            LabelSet_Daibun.Focus();
        }

        ///<summary>
        ///delCtyubunrui
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delChubunrui()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (StringUtl.blIsEmpty(LabelSet_Daibun.CodeTxtText) == false || txtChubunrui.blIsEmpty() == false)
            {
                return;
            }

            //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
            //YESが押された場合
            if (basemessagebox.ShowDialog() == DialogResult.No)
            {
                return;
            }

            //データ渡し用
            lstString.Add(LabelSet_Daibun.CodeTxtText);
            lstString.Add(txtChubunrui.Text);
            lstString.Add(txtElem.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動(チェック)
            M1110_Chubunrui_B chubunB = new M1110_Chubunrui_B();
            try
            {
                chubunB.delChubunrui(lstString);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                LabelSet_Daibun.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///setDaibunrui
        ///取り出したデータをテキストボックスに配置（大分類）
        ///</summary>
        public void setDaibunrui(DataTable dtSelectData)
        {
            
            LabelSet_Daibun.CodeTxtText = dtSelectData.Rows[0]["大分類コード"].ToString();
            LabelSet_Daibun.ValueLabelText = dtSelectData.Rows[0]["大分類名"].ToString();
        }

        ///<summary>
        ///setChubunrui
        ///取り出したデータをテキストボックスに配置（中分類）
        ///</summary>
        public void setChubunrui(DataTable dtSelectData)
        {
            txtChubunrui.Text = dtSelectData.Rows[0]["中分類コード"].ToString();
            txtElem.Text = dtSelectData.Rows[0]["中分類名"].ToString();
        }

        ///<summary>
        ///updTxtChubunruiLeave
        ///code入力箇所からフォーカスが外れた時（中分類）
        ///</summary>
        public void updTxtChubunruiLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            Boolean blnGood;

            if (txtChubunrui.Text == "" || String.IsNullOrWhiteSpace(txtChubunrui.Text).Equals(true))
            {
                return;
            }

            //前後の空白を取り除く
            txtChubunrui.Text = txtChubunrui.Text.Trim();

            //禁止文字チェック
            blnGood = StringUtl.JudBanChr(txtChubunrui.Text);
            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(txtChubunrui.Text, CommonTeisu.NUMBER_ONLY);

            if (blnGood == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtChubunrui.Focus();
                return;
            }
            
            if (txtChubunrui.TextLength == 1)
            {
                txtChubunrui.Text = txtChubunrui.Text.ToString().PadLeft(2, '0');
            }

            //データ渡し用
            lstString.Add(LabelSet_Daibun.CodeTxtText);
            lstString.Add(txtChubunrui.Text);

            //処理部に移動
            M1110_Chubunrui_B chubunB = new M1110_Chubunrui_B();

            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = chubunB.updTxtChubunruiLeave(lstString);

                if (dtSetCd.Rows.Count != 0)
                {
                    LabelSet_Daibun.CodeTxtText = dtSetCd.Rows[0]["大分類コード"].ToString();
                    txtChubunrui.Text = dtSetCd.Rows[0]["中分類コード"].ToString();
                    txtElem.Text = dtSetCd.Rows[0]["中分類名"].ToString();
                }
                //データの新規登録時に邪魔になるため、現段階削除予定
                //else
                //{
                //    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                //    basemessagebox.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///setDaibunruiListClose
        ///DaibunruiListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///</summary>
        public void setDaibunruiListClose()
        {
            LabelSet_Daibun.Focus();
        }

        ///<summary>
        ///setChubunruiListClose
        ///ChubunruiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setChubunruiListClose()
        {
            txtChubunrui.Focus();
        }

        ///judtxtChubunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtChubunruiKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ とタブ、エンター
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                return;
            }
            //キーボードの方向キー4つ
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            {
                return;
            }

            if (txtChubunrui.TextLength == 2)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }
    }
}
