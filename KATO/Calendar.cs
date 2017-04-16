using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textbox_0220_02
{
    public partial class Calendar : CustomControls.CustomDateTextBox
    {
        //最初のクリックかの判断
        Boolean blnFirstclick = true;

        //記入の可不可
        Boolean blnEntry = true;

        public Calendar()
        {
            InitializeComponent();

            //初期値は本日の日付
            this.Text = (DateTime.Today).ToString().Substring(0, 10);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        //
        //この場所にフォーカスされた時
        //
        private void updCalendarEnter(object sender, EventArgs e)
        {
            //背景色をシアンにする
            this.BackColor = Color.Cyan;

            //this.SelectAll();
            if (blnFirstclick == true && this.Text != "")
            {
                //全選択
                this.SelectAll();

                //クリックによる全選択を有効にする
                this.BeginInvoke(new MethodInvoker(() => this.SelectAll()));

                //二回目以降のクリックに切り替える
                blnFirstclick = false;
            }
        }

        //
        //別の場所にフォーカス移動された時
        //
        private void updCalendarLeave(object sender, EventArgs e)
        {
            DateTime tmdjud;

            //背景色を白にする
            this.BackColor = Color.White;

            //フォーカスが外れたのでリセット
            blnFirstclick = true;

            if (DateTime.TryParse(this.Text, out tmdjud) == false && this.Text.Length == 8)
            {
                this.Text = this.Text.Substring(0, 4) + '/' + this.Text.Substring(4, 2) + '/' + this.Text.Substring(6);
            }
        }

        //
        //キー入力された場合
        //
        private void setCalendarKeyDown(object sender, KeyEventArgs e)
        {
            //flg情報初期化
            blnEntry = true;

            //MessageBox.Show(e.KeyCode.ToString() + "_Down");

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

        //
        //textboxに入力された場合
        //
        private void setCalendarKeyPress(object sender, KeyPressEventArgs e)
        {
            blnEntry = true;

            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '/')
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                blnEntry = false;
            }

            //最終的な入力判定
            if (blnEntry == false)
            {
                e.Handled = true;
            }
        }

    }
}
