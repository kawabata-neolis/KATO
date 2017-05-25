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
using KATO.Common.Util;
using KATO.Common.Form;
using KATO.Business.M1100_Chokusosaki;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1100_Chokusosaki
{
    ///<summary>
    ///M1100_Chokusosaki
    ///直送先フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class M1100_Chokusosaki : BaseForm
    {
        /// <summary>
        /// M1100_Chokusosaki
        /// フォーム関係の設定
        /// </summary>
        public M1100_Chokusosaki(Control c)
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
        /// M1100_Chokusosaki_Load
        /// 読み込み時
        /// </summary>
        private void M1100_Chokusosaki_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "直送先マスタ";
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
        ///M1090_Eigyosho_KeyDown
        ///キー入力判定
        ///</summary>
        private void M1100_Chokusosaki_KeyDown(object sender, KeyEventArgs e)
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
                    this.addChokusosaki();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delChokusosaki();
                    break;
                case Keys.F4:
                    this.delText();
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
        ///judChokuTxtKeyDown
        ///キー入力判定
        ///</summary>
        private void judChokuTxtKeyDown(object sender, KeyEventArgs e)
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
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judTxtChoTxtKeyDown
        ///キー入力判定
        ///</summary>
        private void judTxtChoTxtKeyDown(object sender, KeyEventArgs e)
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
                    txtChokusoKeyDown(sender, e);
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
                    this.addChokusosaki();
                    break;
                case STR_BTN_F03: // 削除
                    this.delChokusosaki();
                    break;
                case STR_BTN_F04: // 取り消し
                    this.delText();
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
        ///txtChokusoKeyDown
        ///キー入力判定
        ///</summary>
        private void txtChokusoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9 && labelSet_Tokuisaki.CodeTxtText != "")
            {
                string strTokuisaki = "";

                strTokuisaki = labelSet_Tokuisaki.CodeTxtText;

                ChokusosakiList chokusosakilist = new ChokusosakiList(this, strTokuisaki);
                try
                {
                    chokusosakilist.StartPosition = FormStartPosition.Manual;
                    chokusosakilist.intFrmKind = KATO.Common.Util.CommonTeisu.FRM_CHOKUSOSAKI;
                    chokusosakilist.ShowDialog();
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                }
            }

            //if (e.KeyCode == Keys.F9 && labelSet_Tokuisaki.CodeTxtText != "")
            //{
            //    double dblCheck;
            //    if (double.TryParse(labelSet_Tokuisaki.CodeTxtText, out dblCheck))
            //    {
            //        //LabelSet_Tokuisaki lblSetTokuiSelect = new LabelSet_Tokuisaki();
            //        //ChokusosakiList chokusosakilist = new ChokusosakiList(this, lblSetTokuiSelect, labelSet_Tokuisaki.CodeTxtText);
            //        //try
            //        //{
            //        //    chokusosakilist.StartPosition = FormStartPosition.Manual;
            //        //    chokusosakilist.intFrmKind = CommonTeisu.FRM_TORIHIKISAKI;
            //        //    chokusosakilist.ShowDialog();

            //        //}
            //        //catch (Exception ex)
            //        //{
            //        //    new CommonException(ex);
            //        //    return;
            //        //}

            //    }
            //}
        }

        /////<summary>
        /////txtTokuisakiKeyDown
        /////キー入力判定
        /////</summary>
        //private void txtKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F9)
        //    {
        //        TokuisakiList tokuisakilist = new TokuisakiList(this);
        //        try
        //        {
        //            tokuisakilist.StartPosition = FormStartPosition.Manual;
        //            tokuisakilist.intFrmKind = CommonTeisu.FRM_TORIHIKISAKI;
        //            tokuisakilist.ShowDialog();

        //        }
        //        catch (Exception ex)
        //        {
        //            new CommonException(ex);
        //            return;
        //        }
        //    }
        //}

        ///<summary>
        ///addChokusosaki
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addChokusosaki()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (StringUtl.blIsEmpty(labelSet_Tokuisaki.CodeTxtText) == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tokuisaki.Focus();
                return;
            }
            if (txtChokusoCd.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtChokusoCd.Focus();
                return;
            }
            if (txtChokusoName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtChokusoName.Focus();
                return;
            }

            //取引先
            lstString.Add(labelSet_Tokuisaki.codeTxt.Text);
            lstString.Add(txtChokusoCd.Text);
            lstString.Add(txtChokusoName.Text);
            lstString.Add(txtYubin.Text);
            lstString.Add(txtJusho1.Text);
            lstString.Add(txtJusho2.Text);
            lstString.Add(txtDenwa.Text);

            //ユーザー名
            lstString.Add(SystemInformation.UserName);

            M1100_Chokusosaki_B chokusosakiB = new M1100_Chokusosaki_B();
            try
            {
                chokusosakiB.addChokusosaki(lstString);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                string strTokuiSub = "";
                strTokuiSub = labelSet_Tokuisaki.CodeTxtText;

                //テキストボックスを白紙にする
                delText();

                labelSet_Tokuisaki.CodeTxtText = strTokuiSub;
                labelSet_Tokuisaki.Focus();
                txtChokusoCd.Focus();

            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除、ボタンの機能を消す
        ///</summary>
        private void delText()
        {
            delFormClear(this);
            labelSet_Tokuisaki.Focus();
        }

        ///<summary>
        ///delChokusosaki
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delChokusosaki()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (StringUtl.blIsEmpty(labelSet_Tokuisaki.CodeTxtText) == false || txtChokusoCd.blIsEmpty() == false)
            {
                return;
            }

            //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
            //NOが押された場合
            if (basemessagebox.ShowDialog() == DialogResult.No)
            {
                return;
            }

            //データ渡し用
            lstString.Add(labelSet_Tokuisaki.CodeTxtText);
            lstString.Add(txtChokusoCd.Text);

            //処理部に移動(削除)
            M1100_Chokusosaki_B chokusosakiB = new M1100_Chokusosaki_B();

            try
            {
                chokusosakiB.delChokusosaki(lstString);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                string strTokuiSub = "";
                strTokuiSub = labelSet_Tokuisaki.CodeTxtText;

                //テキストボックスを白紙にする
                delText();

                labelSet_Tokuisaki.CodeTxtText = strTokuiSub;
                labelSet_Tokuisaki.Focus();
                txtChokusoCd.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///setChokusoCode
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setChokusoCode(DataTable dtSelectData)
        {
            txtChokusoCd.Text = dtSelectData.Rows[0]["直送先コード"].ToString();
            txtChokusoName.Text = dtSelectData.Rows[0]["直送先名"].ToString();
            txtYubin.Text = dtSelectData.Rows[0]["郵便番号"].ToString();
            txtJusho1.Text = dtSelectData.Rows[0]["住所１"].ToString();
            txtJusho2.Text = dtSelectData.Rows[0]["住所２"].ToString();
            txtDenwa.Text = dtSelectData.Rows[0]["電話番号"].ToString();
        }

        ///<summary>
        ///updTxtChokuTxtLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public void updTxtChokuTxtLeave(object sender, EventArgs e)
        {
            Control cActive = this.ActiveControl;

            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            //文字判定
            if (txtChokusoCd.blIsEmpty() == false || labelSet_Tokuisaki.codeTxt.blIsEmpty() == false)
            {
                return;
            }

            //前後の空白を取り除く
            txtChokusoCd.Text = txtChokusoCd.Text.Trim();

            if (txtChokusoCd.TextLength < 4)
            {
                txtChokusoCd.Text = txtChokusoCd.Text.ToString().PadLeft(4, '0');
            }

            //データ渡し用
            lstString.Add(labelSet_Tokuisaki.CodeTxtText);
            lstString.Add(txtChokusoCd.Text);

            //処理部に移動
            M1100_Chokusosaki_B chokusosakiB = new M1100_Chokusosaki_B();

            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = chokusosakiB.updTxtChokusoLeave(lstString);

                if (dtSetCd.Rows.Count != 0)
                {
                    txtChokusoCd.Text = dtSetCd.Rows[0]["直送先コード"].ToString();
                    txtChokusoName.Text = dtSetCd.Rows[0]["直送先名"].ToString();
                    txtYubin.Text = dtSetCd.Rows[0]["郵便番号"].ToString();
                    txtJusho1.Text = dtSetCd.Rows[0]["住所１"].ToString();
                    txtJusho2.Text = dtSetCd.Rows[0]["住所２"].ToString();
                    txtDenwa.Text = dtSetCd.Rows[0]["電話番号"].ToString();
                }
                //データの新規登録時に邪魔になるため、現段階削除予定
                //else
                //{
                //    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                //    basemessagebox.ShowDialog();
                //}

                cActive.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///setTokuiListClose
        ///TokuisakiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setTokuiListClose()
        {

        }

        ///<summary>
        ///setChokuListClose
        ///ChokusosakiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setChokuListClose()
        {

        }
        
        /// <summary>
        /// judtxtChokuKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtChokuKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ とタブ、エンター
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter || e.KeyCode == Keys.F12)
            {
                return;
            }
            //キーボードの方向キー4つ
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            {
                return;
            }

            //変換して扱う（これは該当がテキストボックスのみ場合は可能、他のツールを使用していると不可能）
            if (cActiveBefore.Text.Length == ((TextBox)cActiveBefore).MaxLength)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }
    }
}
