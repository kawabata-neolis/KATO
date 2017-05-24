using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Business.M1050_Tantousha;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1050_Tantousha
{
    ///<summary>
    ///M1050_Tantousha
    ///担当者フォーム
    ///作成者：大河内
    ///作成日：2017/2/2
    ///更新者：大河内
    ///更新日：2017/2/2
    ///カラム論理名
    ///</summary>
    public partial class M1050_Tantousha : BaseForm
    {
        //コード内の無限ループを抜けるためのもの
        public Boolean blnLoopOne = true;
        
        /// <summary>
        /// M1050_Tantousha
        /// フォーム関係の設定
        /// </summary>
        public M1050_Tantousha(Control c)
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
        /// M1050_Tantousha_Load
        /// 読み込み時
        /// </summary>
        private void M1050_Tantousha_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "担当者マスタ";
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
        /// judTantoushaKeyDown
        /// キー入力判定
        /// </summary>
        private void judTantoushaKeyDown(object sender, KeyEventArgs e)
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
                    this.addTantousha();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.deTantousha();
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
        /// judTantouTxtKeyDown
        /// キー入力判定
        /// </summary>
        private void judTantouTxtKeyDown(object sender, KeyEventArgs e)
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
        /// judTxtTantouTxtKeyDown
        /// キー入力判定
        /// </summary>
        private void judTxtTantouTxtKeyDown(object sender, KeyEventArgs e)
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
                    judtxtTantouKeyDown(sender, e);
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
                    this.addTantousha();
                    break;
                case STR_BTN_F03: // 削除
                    this.deTantousha();
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
        /// judtxtTantouKeyDown
        /// コード入力項目でのキー入力判定
        /// </summary>
        private void judtxtTantouKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                TantoushaList tantoushalist = new TantoushaList(this);
                try
                {
                    tantoushalist.StartPosition = FormStartPosition.Manual;
                    tantoushalist.intFrmKind = CommonTeisu.FRM_TANTOUSYA;
                    tantoushalist.ShowDialog();

                    txtMokuhyou.Focus();
                    txtTantoushaCd.Focus();
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    return;
                }
            }
        }

        /// <summary>
        /// addTantousha
        /// テキストボックス内のデータをDBに登録
        /// </summary>
        private void addTantousha()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtTantoushaCd.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTantoushaCd.Focus();
                return;
            }
            //文字判定
            if (txtTantoushaName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTantoushaName.Focus();
                return;
            }
            //文字判定
            if (txtLoginID.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtLoginID.Focus();
                return;
            }
            //文字判定
            if (StringUtl.blIsEmpty(labelSet_Eigyousho.CodeTxtText) == false )
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Eigyousho.Focus();
                return;
            }
            //文字判定
            if (txtChuban.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtChuban.Focus();
                return;
            }
            //文字判定
            if (StringUtl.blIsEmpty(labelSet_GroupCd.CodeTxtText) == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_GroupCd.Focus();
                return;
            }
            //文字判定
            if (txtMokuhyou.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtMokuhyou.Focus();
                return;
            }

            //データ渡し用
            lstString.Add(txtTantoushaCd.Text);
            lstString.Add(txtTantoushaName.Text);
            lstString.Add(txtLoginID.Text);
            lstString.Add(labelSet_Eigyousho.CodeTxtText);
            lstString.Add(txtChuban.Text);
            lstString.Add(labelSet_GroupCd.CodeTxtText);
            lstString.Add(txtMokuhyou.Text);
            lstString.Add(SystemInformation.UserName);

            M1050_Tantousha_B tantouB = new M1050_Tantousha_B();
            try
            {
                tantouB.addTantousha(lstString);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtTantoushaCd.Focus();
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
            txtTantoushaCd.Focus();
            txtMokuhyou.Text = "";
        }

        /// <summary>
        /// deTantousha
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void deTantousha()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtTantoushaCd.blIsEmpty() == false && txtTantoushaCd.blIsEmpty() == false)
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
            lstString.Add(txtTantoushaCd.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動(削除)
            M1050_Tantousha_B daibunB = new M1050_Tantousha_B();

            try
            {
                daibunB.delDaibunrui(lstString);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtTantoushaCd.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// setTantousha
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setTantousha(DataTable dtSelectData)
        {
            txtTantoushaCd.Text = dtSelectData.Rows[0]["担当者コード"].ToString();
            txtTantoushaName.Text = dtSelectData.Rows[0]["担当者名"].ToString();
            txtLoginID.Text = dtSelectData.Rows[0]["ログインID"].ToString();
            labelSet_Eigyousho.CodeTxtText = dtSelectData.Rows[0]["営業所コード"].ToString();
            txtChuban.Text = dtSelectData.Rows[0]["注番文字"].ToString();
            labelSet_GroupCd.CodeTxtText = dtSelectData.Rows[0]["グループコード"].ToString();
            txtMokuhyou.Text = dtSelectData.Rows[0]["年間売上目標"].ToString();
        }

        /// <summary>
        /// updTxtTantoushaLeave
        /// code入力箇所からフォーカスが外れた時
        /// </summary>
        public void updTxtTantoushaLeave(object sender, EventArgs e)
        {
            if (blnLoopOne == false)
            {
                blnLoopOne = true;
                return;
            }

            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            Boolean blnGood;

            //文字判定
            if (txtTantoushaCd.blIsEmpty() == false)
            {
                return;
            }

            if (txtTantoushaCd.TextLength < 4)
            {
                txtTantoushaCd.Text = txtTantoushaCd.Text.ToString().PadLeft(4, '0');
            }

            //前後の空白を取り除く
            txtTantoushaCd.Text = txtTantoushaCd.Text.Trim();

            //禁止文字チェック
            blnGood = StringUtl.JudBanChr(txtTantoushaCd.Text);
            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(txtTantoushaCd.Text, CommonTeisu.NUMBER_ONLY);

            if (blnGood == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtTantoushaCd.Focus();
                return;
            }

            //データ渡し用
            lstString.Add(txtTantoushaCd.Text);

            //処理部に移動
            M1050_Tantousha_B tantoushaB = new M1050_Tantousha_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = tantoushaB.updTxtDaibunruiLeave(lstString);

                if (dtSetCd.Rows.Count != 0)
                {
                    setTantousha(dtSetCd);
                }

                Control c = this.ActiveControl;

                txtMokuhyou.Focus();
                txtTantoushaCd.Focus();

                blnLoopOne = false;

                c.Focus();

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

        /// <summary>
        /// setTantouListClose
        /// 担当者リストが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setTantouListClose()
        {
            txtTantoushaCd.Focus();
        }

        /// <summary>
        /// judtxtTantoushaKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtTantoushaKeyUp(object sender, KeyEventArgs e)
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
