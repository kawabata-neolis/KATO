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
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.M1040_Torihikikbn;

namespace KATO.Form.M1040_Torihikikbn
{
    ///<summary>
    ///M1040_Torihikikubun
    ///取引区分フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class M1040_Torihikikbn : BaseForm
    {
        /// <summary>
        /// M1040_Torihikikubun
        /// フォーム関係の設定
        /// </summary>
        public M1040_Torihikikbn(Control c)
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
        /// M1010_Daibunrui_Load
        /// 読み込み時
        /// </summary>
        private void M1040_Torihikikubun_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "取引区分マスタ";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;
        }

        /// <summary>
        /// judTorikubunKeyDown
        /// キー入力判定
        /// </summary>
        private void judTorikubunKeyDown(object sender, KeyEventArgs e)
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
                    this.addTorikubun();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delTorikubun();
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

        /// <summary>
        /// judBtnClick
        /// ボタンの反応
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    this.addTorikubun();
                    break;
                case STR_BTN_F03: // 削除
                    this.delTorikubun();
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

        /// <summary>
        /// judtxtToriKeyDown
        /// コード入力項目でのキー入力判定
        /// </summary>
        private void judtxtToriKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                TorihikikbnList torihikikbnList = new TorihikikbnList(this);
                try
                {
                    torihikikbnList.StartPosition = FormStartPosition.Manual;
                    torihikikbnList.intFrmKind = CommonTeisu.FRM_TORIHIKIKBN;
                    torihikikbnList.ShowDialog();
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    return;
                }
            }
        }

        /// <summary>
        /// addTorikubun
        /// テキストボックス内のデータをDBに登録
        /// </summary>
        private void addTorikubun()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtTorihikikubun.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTorihikikubun.Focus();
                return;
            }
            //文字判定
            if (txtName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtName.Focus();
                return;
            }

            //データ渡し用
            lstString.Add(txtTorihikikubun.Text);
            lstString.Add(txtName.Text);

            lstString.Add(SystemInformation.UserName);

            //処理部に移動
            M1040_Torihikikbn_B torikbnB = new M1040_Torihikikbn_B();
            try
            {
                torikbnB.addTorihikikubun(lstString);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtTorihikikubun.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            delFormClear(this);
            txtTorihikikubun.Focus();
        }

        /// <summary>
        /// delTorikubun
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void delTorikubun()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtTorihikikubun.blIsEmpty() == false && txtName.blIsEmpty() == false)
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
            lstString.Add(txtTorihikikubun.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動(削除)
            M1040_Torihikikbn_B torikbnB = new M1040_Torihikikbn_B();

            try
            {
                torikbnB.delTorihikikubun(lstString);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtTorihikikubun.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// setTorikubun
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setTorikubun(DataTable dtSelectData)
        {
            txtTorihikikubun.Text = dtSelectData.Rows[0]["取引区分コード"].ToString();
            txtName.Text = dtSelectData.Rows[0]["取引区分名"].ToString();
        }

        /// <summary>
        /// updTxtToriLeave
        /// code入力箇所からフォーカスが外れた時
        /// </summary>
        public void updTxtToriLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            Boolean blnGood;

            //文字判定
            if (txtTorihikikubun.blIsEmpty() == false)
            {
                return;
            }

            //前後の空白を取り除く
            txtTorihikikubun.Text = txtTorihikikubun.Text.Trim();

            if (txtTorihikikubun.TextLength == 1)
            {
                txtTorihikikubun.Text = txtTorihikikubun.Text.ToString().PadLeft(2, '0');
            }

            //禁止文字チェック
            blnGood = StringUtl.JudBanChr(txtTorihikikubun.Text);
            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(txtTorihikikubun.Text, CommonTeisu.NUMBER_ONLY);

            if (blnGood == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtTorihikikubun.Focus();
                return;
            }

            //データ渡し用
            lstString.Add(txtTorihikikubun.Text);

            M1040_Torihikikbn_B torikbn_B = new M1040_Torihikikbn_B();      
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = torikbn_B.updTxtTorikbnLeave(lstString);

                if (dtSetCd.Rows.Count != 0)
                {
                    txtTorihikikubun.Text = dtSetCd.Rows[0]["取引区分コード"].ToString();
                    txtName.Text = dtSetCd.Rows[0]["取引区分名"].ToString();
                }
                //データの新規登録時に邪魔になるため、現段階削除予定
                //else
                //{
                ////メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                //BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                //basemessagebox.ShowDialog();
                //txtTorihikikubun.Focus();
                //}
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// setToriListClose
        /// DaibunruiListが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setToriListClose()
        {
            txtTorihikikubun.Focus();
        }

        /// <summary>
        /// judtxtToriKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtToriKeyUp(object sender, KeyEventArgs e)
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

            if (txtTorihikikubun.TextLength == 2)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }
    }
}
