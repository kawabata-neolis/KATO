using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Business.M1010_Daibunrui;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1010_Daibunrui
{
    ///<summary>
    ///M1010_Daibunrui
    ///大分類フォーム
    ///作成者：大河内
    ///作成日：2017/2/2
    ///更新者：大河内
    ///更新日：2017/2/2
    ///カラム論理名
    ///</summary>
    public partial class M1010_Daibunrui : BaseForm
    {
        /// <summary>
        /// M1010_Daibunrui
        /// フォーム関係の設定
        /// </summary>
        public M1010_Daibunrui(Control c)
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
        private void M1010_Daibunrui_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "大分類マスタ";
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
        /// judDaiBunruiKeyDown
        /// キー入力判定
        /// </summary>
        private void judDaiBunruiKeyDown(object sender, KeyEventArgs e)
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
                    this.addDaibunrui();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delDaibunrui();
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
                    this.addDaibunrui();
                    break;
                case STR_BTN_F03: // 削除
                    this.delDaibunrui();
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
        /// judtxtDaibunruiKeyDown
        /// コード入力項目でのキー入力判定
        /// </summary>
        private void judtxtDaibunKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                DaibunruiList daibunruiList = new DaibunruiList(this);
                try
                {
                    daibunruiList.StartPosition = FormStartPosition.Manual;
                    daibunruiList.intFrmKind = CommonTeisu.FRM_DAIBUNRUI;
                    daibunruiList.ShowDialog();
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    return;
                }
            }
        }

        /// <summary>
        /// addDaibunrui
        /// テキストボックス内のデータをDBに登録
        /// </summary>
        private void addDaibunrui()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtDaibunrui.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtDaibunrui.Focus();
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
            lstString.Add(txtDaibunrui.Text);
            lstString.Add(txtName.Text);
            lstString.Add(txtLabel1.Text);
            lstString.Add(txtLabel2.Text);
            lstString.Add(txtLabel3.Text);
            lstString.Add(txtLabel4.Text);
            lstString.Add(txtLabel5.Text);
            lstString.Add(txtLabel6.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動
            M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();

            try
            {
                daibunB.addDaibunrui(lstString);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtDaibunrui.Focus();
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
            txtDaibunrui.Focus();
        }

        /// <summary>
        /// delDaibunrui
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void delDaibunrui()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtDaibunrui.blIsEmpty() == false && txtName.blIsEmpty() == false)
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
            lstString.Add(txtDaibunrui.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動(削除)
            M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();

            try
            {
                daibunB.delDaibunrui(lstString);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtDaibunrui.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// setDaibunrui
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setDaibunrui(DataTable dtSelectData)
        {
            txtDaibunrui.Text = dtSelectData.Rows[0]["大分類コード"].ToString();
            txtName.Text = dtSelectData.Rows[0]["大分類名"].ToString();
            txtLabel1.Text = dtSelectData.Rows[0]["ラベル名１"].ToString();
            txtLabel2.Text = dtSelectData.Rows[0]["ラベル名２"].ToString();
            txtLabel3.Text = dtSelectData.Rows[0]["ラベル名３"].ToString();
            txtLabel4.Text = dtSelectData.Rows[0]["ラベル名４"].ToString();
            txtLabel5.Text = dtSelectData.Rows[0]["ラベル名５"].ToString();
            txtLabel6.Text = dtSelectData.Rows[0]["ラベル名６"].ToString();
        }


        /// <summary>
        /// updTxtDaibunruiLeave
        /// code入力箇所からフォーカスが外れた時
        /// </summary>
        public void updTxtDaibunruiLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            //文字判定
            if (txtDaibunrui.blIsEmpty() == false)
            {
                return;
            }

            //前後の空白を取り除く
            txtDaibunrui.Text = txtDaibunrui.Text.Trim();

            if (txtDaibunrui.TextLength == 1)
            {
                txtDaibunrui.Text = txtDaibunrui.Text.ToString().PadLeft(2, '0');
            }

            //データ渡し用
            lstString.Add(txtDaibunrui.Text);

            //処理部に移動
            M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();

            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = daibunB.updTxtDaibunruiLeave(lstString);

                if (dtSetCd.Rows.Count != 0)
                {
                    txtDaibunrui.Text = dtSetCd.Rows[0]["大分類コード"].ToString();
                    txtName.Text = dtSetCd.Rows[0]["大分類名"].ToString();
                    txtLabel1.Text = dtSetCd.Rows[0]["ラベル名１"].ToString();
                    txtLabel2.Text = dtSetCd.Rows[0]["ラベル名２"].ToString();
                    txtLabel3.Text = dtSetCd.Rows[0]["ラベル名３"].ToString();
                    txtLabel4.Text = dtSetCd.Rows[0]["ラベル名４"].ToString();
                    txtLabel5.Text = dtSetCd.Rows[0]["ラベル名５"].ToString();
                    txtLabel6.Text = dtSetCd.Rows[0]["ラベル名６"].ToString();
                    txtName.Focus();
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

        /// <summary>
        /// setDaibunruiListClose
        /// DaibunruiListが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setDaibunruiListClose()
        {
            txtDaibunrui.Focus();
        }

        /// <summary>
        /// judtxtDaibunruiKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtDaibunruiKeyUp(object sender, KeyEventArgs e)
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
            if (txtDaibunrui.TextLength == 2)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }
    }
}
