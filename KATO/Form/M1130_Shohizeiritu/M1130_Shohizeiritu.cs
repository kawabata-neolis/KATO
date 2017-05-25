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
using KATO.Business.M1130_Shohizeiritu;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1130_Shohizeiritu
{
    ///<summary>
    ///M1130_Shohizeiritu
    ///消費税率フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class M1130_Shohizeiritu : BaseForm
    {
        /// <summary>
        /// M1130_Shohizeiritu
        /// フォーム関係の設定
        /// </summary>
        public M1130_Shohizeiritu(Control c)
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
        /// M1130_Shohizeiritu_Load
        /// 読み込み時
        /// </summary>
        private void M1130_Shohizeiritu_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "消費税率マスタ";
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
        ///M1130_Shohizeiritu_KeyDown
        ///キー入力判定
        ///</summary>
        private void M1130_Shohizeiritu_KeyDown(object sender, KeyEventArgs e)
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
                    this.addShohizeiritu();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delShohizeiritu();
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
        ///baseCalendar1_TextChanged
        ///キー入力判定
        ///</summary>
        private void txtTekiyoYMD_KeyDown(object sender, KeyEventArgs e)
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
        ///baseTextMoney_TextChanged
        ///キー入力判定
        ///</summary>
        private void txtShohizeiritu_KeyDown(object sender, KeyEventArgs e)
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
                    txtShohizeiKeyDown(sender, e);
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
                    this.addShohizeiritu();
                    break;
                case STR_BTN_F03: // 削除
                    this.delShohizeiritu();
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
        ///txtShohizeiKeyDown
        ///キー入力判定
        ///</summary>
        private void txtShohizeiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                //TanabanList tanabanlist = new TanabanList(this);
                //try
                //{
                //    tanabanlist.intFrmKind = CommonTeisu.FRM_TANABAN;
                //    tanabanlist.ShowDialog();
                //}
                //catch (Exception ex)
                //{
                //    new CommonException(ex);
                //    return;
                //}
            }
        }

        ///<summary>
        ///addShohizeiritu
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addShohizeiritu()
        {

        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除、ボタンの機能を消す
        ///</summary>
        private void delText()
        {
            delFormClear(this);
            //txtTanabanCd.Focus();
        }

        ///<summary>
        ///delShohizeiritu
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delShohizeiritu()
        {

        }

        ///<summary>
        ///setShohizeiritu
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setShohizeiritu(DataTable dtSelectData)
        {
            txtTekiyoYMD.Text = dtSelectData.Rows[0]["適用開始年月日"].ToString();
            txtShohizeiritu.Text = dtSelectData.Rows[0]["消費税率"].ToString();

            //txtShohizeiritu.Text = 

            //int intZeroPosi = txtShohizeiritu.Text.LastIndexOf('0');

            ////ピリオドの位置の確保
            //int intPeriodPosi = this.Text.IndexOf('.');

            //string strIntArea = "";

            //string strDeciArea = "";

            ////ピリオドがない場合
            //if (intPeriodPosi == -1)
            //{
            //    strIntArea = txtShohizeiritu.Text;
            //}
            //else
            //{
            //    //整数部のみを取り出す
            //    strIntArea = this.Text.Substring(0, intPeriodPosi);

            //    //小数点以下部のみを取り出す
            //    strDeciArea = this.Text.Substring(intPeriodPosi + 1);
            //}


            //for (int intcnt = 0; intcnt < txtShohizeiritu.TextLength; intcnt++ )
            //{

            //}
        }

        ///<summary>
        ///txtTekiyoYMD_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void txtTekiyoYMD_Leave(object sender, EventArgs e)
        {
            Control cActive = this.ActiveControl;

            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            //文字判定
            if (txtTekiyoYMD.blIsEmpty() == false)
            {
                return;
            }

            //前後の空白を取り除く
            txtTekiyoYMD.Text = txtTekiyoYMD.Text.Trim();

            //データ渡し用
            lstString.Add(txtTekiyoYMD.Text);

            //処理部に移動
            M1130_Shohizeiritu_B shohizeirituB = new M1130_Shohizeiritu_B();

            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = shohizeirituB.updTxtShohizeiLeave(lstString);

                if (dtSetCd.Rows.Count != 0)
                {
                    setShohizeiritu(dtSetCd);
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
        ///setShohizeiListClose
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setShohizeiListClose()
        {
            //txtTanabanCd.Focus();
        }

        /// <summary>
        /// judtxtShohizeiKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtShohizeiKeyUp(object sender, KeyEventArgs e)
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
