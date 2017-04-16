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
using KATO.Business.M_Daibunrui;
using KATO.Business.M1110_Chubunrui;
using static KATO.Common.Util.CommonTeisu;


namespace KATO.Form.M_Chubunrui
{
    public partial class M_Chubunrui : BaseForm
    {
        public M_Chubunrui()
        {
            InitializeComponent();
        }

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
        ///judCyubunruiKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/3
        ///カラム論理名
        ///</summary>
        private void judCyubunruiKeyDown(object sender, KeyEventArgs e)
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
//印刷
//PrintReport();
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
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/28
        ///カラム論理名
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
        ///addCyubunrui
        ///テキストボックス内のデータをDBに登録
        ///作成者：大河内
        ///作成日：2017/3/9
        ///更新者：大河内
        ///更新日：2017/4/6
        ///カラム論理名
        ///</summary>
        private void addChubunrui()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtDaibunrui.blIsEmpty() == false || txtChubunrui.blIsEmpty() == false)
            {
                MessageBox.Show("項目が空です。文字を入力してください。", "入力項目", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //データ渡し用
            lstString.Add(txtDaibunrui.Text);
            lstString.Add(txtChubunrui.Text);
            lstString.Add(txtElem.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動
            M1110_Chubunrui_B chubunB = new M1110_Chubunrui_B();
            chubunB.addChubunrui(lstString);

            txtChubunrui.Text = "";
            txtElem.Text = "";
            lblDsp.Text = "";
            txtChubunrui.Focus();
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除
        ///作成者：大河内
        ///作成日：2017/3/6
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void delText()
        {
            BaseForm formreset = new BaseForm();
            formreset.delFormClear(this);
            txtDaibunrui.Focus();
        }

        ///<summary>
        ///delCtyubunrui
        ///テキストボックス内のデータをDBから削除
        ///作成者：大河内
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        public void delChubunrui()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            bool blDelFinish = false;

            //文字判定
            if (txtDaibunrui.blIsEmpty() == false || txtChubunrui.blIsEmpty() == false)
            {
                return;
            }

            //データ渡し用
            lstString.Add(txtDaibunrui.Text);
            lstString.Add(txtChubunrui.Text);
            lstString.Add(txtElem.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動
            M1110_Chubunrui_B chubunB = new M1110_Chubunrui_B();
            blDelFinish = chubunB.delChubunrui(lstString);

            if(blDelFinish == true)
            {
                //大分類コード以外白紙にする
                txtChubunrui.Text = "";
                txtElem.Text = "";
                lblDsp.Text = "";
                txtDaibunrui.Focus();
            }
        }

        ///<summary>
        ///setDaibunrui
        ///取り出したデータをテキストボックスに配置（大分類）
        ///作成者：大河内
        ///作成日：2017/3/1
        ///更新者：大河内
        ///更新日：2017/3/2
        ///カラム論理名
        ///</summary>
        public void setDaibunrui(DataTable dtSelectData)
        {
            txtDaibunrui.Text = dtSelectData.Rows[0]["大分類コード"].ToString();
            lblDsp.Text = dtSelectData.Rows[0]["大分類名"].ToString();
        }

        ///<summary>
        ///setCyoku
        ///取り出したデータをテキストボックスに配置（中分類）
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/3
        ///カラム論理名
        ///</summary>
        public void setChubunrui(DataTable dtSelectData)
        {
            txtChubunrui.Text = dtSelectData.Rows[0]["中分類コード"].ToString();
            txtElem.Text = dtSelectData.Rows[0]["中分類名"].ToString();
        }


        ///<summary>
        ///judtxtCDKeyDown
        ///コード入力項目でのキー入力判定
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/3
        ///カラム論理名
        ///</summary>
        private void judtxtCDKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                DaibunruiList daibunruiList = new DaibunruiList();
                daibunruiList.Left = 100;
                daibunruiList.StartPosition = FormStartPosition.Manual;
                daibunruiList.intFrmKind = KATO.Common.Util.CommonTeisu.FRM_CYUBUNRUI;
                daibunruiList.Show();
            }
        }


        ///<summary>
        ///judtxtCyokuCDKeyDown
        ///コード入力項目でのキー入力判定
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/2
        ///カラム論理名
        ///</summary>
        private void judtxtCyokuCDKeyDown(object sender, KeyEventArgs e)
        {
            //F9を押して且つ大分類コードが記載されている状態
            if (e.KeyCode == Keys.F9 && txtDaibunrui.Text != "")
            {
                ChubunruiList cyokusousakilist = new ChubunruiList();
                cyokusousakilist.Left = 100;
                cyokusousakilist.StartPosition = FormStartPosition.Manual;
                cyokusousakilist.intFrmKind = KATO.Common.Util.CommonTeisu.FRM_CYUBUNRUI;
                cyokusousakilist.strDaibunruiCode = txtDaibunrui.Text;
                cyokusousakilist.Show();
            }
        }

        ///<summary>
        ///judtxtDaibunruiLeave
        ///code入力箇所からフォーカスが外れた時（大分類）
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/27
        ///カラム論理名
        ///</summary>
        public void judtxtDaibunruiLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetcode;

            if (txtDaibunrui.Text == "" || String.IsNullOrWhiteSpace(txtDaibunrui.Text).Equals(true))
            {
                lblDsp.Text = "";
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
            Daibunrui_B daibunB = new Daibunrui_B();
            //戻り値のDatatableを取り込む
            dtSetcode = daibunB.judTxtDaibunruiLeave(lstString);
        
            if (dtSetcode.Rows.Count == 0)
            {
            }
            else
            {
                txtDaibunrui.Text = dtSetcode.Rows[0]["大分類コード"].ToString();
                lblDsp.Text = dtSetcode.Rows[0]["大分類名"].ToString();
            }
        }

        ///<summary>
        ///judtxtChubunruiLeave
        ///code入力箇所からフォーカスが外れた時（中分類）
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/4/6
        ///カラム論理名
        ///</summary>
        public void judtxtChubunruiLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable DtSetcode;

            if (txtChubunrui.Text == "" || String.IsNullOrWhiteSpace(txtChubunrui.Text).Equals(true))
            {
                return;
            }

            //前後の空白を取り除く
            txtChubunrui.Text = txtChubunrui.Text.Trim();

            if (txtChubunrui.TextLength == 1)
            {
                txtChubunrui.Text = txtChubunrui.Text.ToString().PadLeft(2, '0');
            }

            //データ渡し用
            lstString.Add(txtDaibunrui.Text);
            lstString.Add(txtChubunrui.Text);

            //処理部に移動
            M1110_Chubunrui_B chubunB = new M1110_Chubunrui_B();
            //戻り値のDatatableを取り込む
            DtSetcode = chubunB.judTxtChubunruiLeave(lstString);

            if (DtSetcode.Rows.Count == 0)
            {
            }
            else
            {
                txtDaibunrui.Text = DtSetcode.Rows[0]["大分類コード"].ToString();
                txtChubunrui.Text = DtSetcode.Rows[0]["中分類コード"].ToString();
                txtElem.Text = DtSetcode.Rows[0]["中分類名"].ToString();
            }
        }

        ///<summary>
        ///setDaibunruiListClose
        ///DaibunruiListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/3
        ///カラム論理名
        ///</summary>
        public void setDaibunruiListClose()
        {
            txtDaibunrui.Focus();
        }

        ///<summary>
        ///setChubunruiListClose
        ///ChubunruiListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/3
        ///カラム論理名
        ///</summary>
        public void setChubunruiListClose()
        {
            txtChubunrui.Focus();
        }

        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judtxtDaibunruiKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtDaibunrui.TextLength == 2)
            {
                judtxtDaibunruiLeave(sender, e);
            }

        }

        ///judtxtChubunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judtxtChubunruiKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtChubunrui.TextLength == 2)
            {
                judtxtChubunruiLeave(sender, e);
            }
        }
    }
}
