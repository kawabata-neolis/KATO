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
    public partial class M1050_Tantousha : BaseForm
    {
        //修正中

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
        private void judtantoushaKeyDown(object sender, KeyEventArgs e)
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
        /// judtxtDaibunruiKeyDown
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
        private void addTantousha()
        {

        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            delFormClear(this);
            txtTantoushaCd.Focus();
        }

        /// <summary>
        /// delDaibunrui
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void deTantousha()
        {
        }

        /// <summary>
        /// setDaibunrui
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setTantousha(DataTable dtSelectData)
        {
            txtTantoushaCd.Text = dtSelectData.Rows[0]["担当者コード"].ToString();
            txtTantoushaName.Text = dtSelectData.Rows[0]["担当者名"].ToString();
            txtLoginID.Text = dtSelectData.Rows[0]["ログインID"].ToString();
            labelSet_Eigyousho.codeTxt.Text = dtSelectData.Rows[0]["営業所コード"].ToString();
            txtChuban.Text = dtSelectData.Rows[0]["担当者コード"].ToString();
            labelSet_GroupCd.codeTxt.Text = dtSelectData.Rows[0]["グループコード"].ToString();
            txtMokuhyou.Text = dtSelectData.Rows[0]["年間売上目標"].ToString();
        }

        /// <summary>
        /// updTxtTantoushaLeave
        /// code入力箇所からフォーカスが外れた時
        /// </summary>
        public void updTxtTantoushaLeave(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// setTantouListClose
        /// DaibunruiListが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setTantouListClose()
        {
            labelSet_Eigyousho.Focus();
            labelSet_GroupCd.Focus();
            txtTantoushaCd.Focus();
        }

        /// <summary>
        /// judtxtTantoushaKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtTantoushaKeyUp(object sender, KeyEventArgs e)
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
            if (txtTantoushaCd.TextLength == 4)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }
    }
}
