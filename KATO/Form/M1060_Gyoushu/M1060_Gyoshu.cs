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
using KATO.Business.M1060_Gyoshu;

namespace KATO.Form.M1060_Gyoushu
{
    ///<summary>
    ///M1060_Gyoushu
    ///業種フォーム
    ///作成者：大河内
    ///作成日：2017/2/2
    ///更新者：大河内
    ///更新日：2017/2/2
    ///カラム論理名
    ///</summary>
    public partial class M1060_Gyoshu : BaseForm
    {
        /// <summary>
        /// M1060_Gyoushu
        /// フォーム関係の設定
        /// </summary>
        public M1060_Gyoshu(Control c)
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
        /// M1060_Gyoushu_Load
        /// 読み込み時
        /// </summary>
        private void M1060_Gyoushu_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "業種マスタ";
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
        /// judGyoshuKeyDown
        /// キー入力判定
        /// </summary>
        private void judGyoshuKeyDown(object sender, KeyEventArgs e)
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
                    this.addGyoushu();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delGyoushu();
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
        /// judGyoshuTxtKeyDown
        /// キー入力判定
        /// </summary>
        private void judGyoshuTxtKeyDown(object sender, KeyEventArgs e)
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

        /// <summary>
        /// judTxtGyoTxtKeyDown
        /// キー入力判定
        /// </summary>
        private void judTxtGyoTxtKeyDown(object sender, KeyEventArgs e)
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
                    judtxtGyoshuKeyDown(sender, e);
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
                    this.addGyoushu();
                    break;
                case STR_BTN_F03: // 削除
                    this.delGyoushu();
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
        /// judtxtGyoshuKeyDown
        /// コード入力項目でのキー入力判定
        /// </summary>
        private void judtxtGyoshuKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                GyoshuList gyoshulist = new GyoshuList(this);
                try
                {
                    gyoshulist.StartPosition = FormStartPosition.Manual;
                    gyoshulist.intFrmKind = CommonTeisu.FRM_GYOSHU;
                    gyoshulist.ShowDialog();
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    return;
                }
            }
        }

        /// <summary>
        /// addGyoushu
        /// テキストボックス内のデータをDBに登録
        /// </summary>
        private void addGyoushu()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtGyoshuCd.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtGyoshuCd.Focus();
                return;
            }
            //文字判定
            if (txtGyoshuName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtGyoshuName.Focus();
                return;
            }
            //データ渡し用
            lstString.Add(txtGyoshuCd.Text);
            lstString.Add(txtGyoshuName.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動
            M1060_Gyoshu_B gyoshuB = new M1060_Gyoshu_B();
            try
            {
                gyoshuB.addGyoshu(lstString);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
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
            txtGyoshuCd.Focus();
        }

        /// <summary>
        /// delGyoushu
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void delGyoushu()
        {
            //データ渡し用
            List<string> lstStringLoad = new List<string>();
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            //文字判定
            if (txtGyoshuCd.blIsEmpty() == false && txtGyoshuName.blIsEmpty() == false)
            {
                return;
            }

            //処理部に移動(削除)
            M1060_Gyoshu_B gyoshuB = new M1060_Gyoshu_B();

            try
            {
                lstStringLoad.Add(txtGyoshuCd.Text);

                //戻り値のDatatableを取り込む
                dtSetCd = gyoshuB.updTxtGyoshuLeave(lstStringLoad);

                if (dtSetCd.Rows.Count == 0)
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
                lstString.Add(txtGyoshuCd.Text);
                lstString.Add(txtGyoshuName.Text);
                lstString.Add(SystemInformation.UserName);

                gyoshuB.delGyoshu(lstString);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtGyoshuCd.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// setGyoushu
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setGyoushu(DataTable dtSelectData)
        {
            txtGyoshuCd.Text = dtSelectData.Rows[0]["業種コード"].ToString();
            txtGyoshuName.Text = dtSelectData.Rows[0]["業種名"].ToString();
        }

        /// <summary>
        /// updTxtGyoshuLeave
        /// code入力箇所からフォーカスが外れた時
        /// </summary>
        public void updTxtGyoshuLeave(object sender, EventArgs e)
        {
            Control cActive = this.ActiveControl;

            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            Boolean blnGood;

            //文字判定
            if (txtGyoshuCd.blIsEmpty() == false)
            {
                return;
            }

            if (txtGyoshuCd.TextLength < 4)
            {
                txtGyoshuCd.Text = txtGyoshuCd.Text.ToString().PadLeft(4, '0');
            }

            //前後の空白を取り除く
            txtGyoshuCd.Text = txtGyoshuCd.Text.Trim();
            
            //禁止文字チェック
            blnGood = StringUtl.JudBanChr(txtGyoshuCd.Text);
            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(txtGyoshuCd.Text, CommonTeisu.NUMBER_ONLY);

            if (blnGood == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtGyoshuCd.Focus();
                return;
            }

            //データ渡し用
            lstString.Add(txtGyoshuCd.Text);

            //処理部に移動
            M1060_Gyoshu_B daibunB = new M1060_Gyoshu_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = daibunB.updTxtGyoshuLeave(lstString);

                if (dtSetCd.Rows.Count != 0)
                {
                    txtGyoshuCd.Text = dtSetCd.Rows[0]["業種コード"].ToString();
                    txtGyoshuName.Text = dtSetCd.Rows[0]["業種名"].ToString();
                    txtGyoshuName.Focus();
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

        /// <summary>
        /// setGyoushuListClose
        /// GyoushuListが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setGyoushuListClose()
        {
            txtGyoshuCd.Focus();
        }

        /// <summary>
        /// judtxtGyoushuKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtGyoushuKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
