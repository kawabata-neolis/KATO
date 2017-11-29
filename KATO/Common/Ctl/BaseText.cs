using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace KATO.Common.Ctl
{
    public partial class BaseText : TextBox
    {
        //最初のクリックかの判断
        Boolean blnFirstClick = true;

        public BaseText()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);        
        }

        //
        //この場所にフォーカスされた時
        //
        private void BaseText_Enter(object sender, EventArgs e)
        {
            //背景色をシアンにする
            this.BackColor = Color.Cyan;

            //this.SelectAll();
            if (blnFirstClick == true && this.Text != "")
            {
                //全選択
                this.SelectAll();

                //クリックによる全選択を有効にする
                this.BeginInvoke(new MethodInvoker(() => this.SelectAll()));

                //二回目以降のクリックに切り替える
                blnFirstClick = false;
            }
        }

        //
        //別の場所にフォーカスされた時
        //
        private void BaseText_Leave(object sender, EventArgs e)
        {
            //背景色を白にする
            this.BackColor = Color.White;

            //フォーカスが外れたのでリセット
            blnFirstClick = true;
        }

        //
        //文字判定
        //
        public bool blIsEmpty()
        {
            Boolean good = true;

            if (this.Text == "" || String.IsNullOrWhiteSpace(this.Text).Equals(true))
            {
                good = false;
            }
            return (good);
        }

        //
        //文字数制限
        //
        private void BaseText_TextChanged(object sender, EventArgs e)
        {
            int intByteLength = 0;
            intByteLength = Encoding.GetEncoding("Shift_JIS").GetByteCount(this.Text);

            if (this.MaxLength < intByteLength)
            {
                this.Text = this.Text.Remove(this.Text.Length -1, 1);
                this.Select(this.Text.Length, 0);
            }
        }

        //
        //KeyUp()
        //
        public void judKeyUp(Control cActiveBefore, KeyEventArgs e)
        {
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

            //ファンクションキーにも対応すること（各画面で使用しているボタン以外はスルーさせる）

            if (cActiveBefore != null)
            {
                //文字コードを使用
                int intByteCnt = Encoding.GetEncoding("Shift_JIS").GetByteCount(cActiveBefore.Text);

                //コンボボックスボックスかの判定
                if (cActiveBefore.GetType().Equals(typeof(ComboBox)))
                {
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    //文字コードと最大入力数を比較
                    if (intByteCnt >= ((TextBox)cActiveBefore).MaxLength)
                    {
                        //TABボタンと同じ効果
                        SendKeys.Send("{TAB}");
                    }
                }
            }
        }

        //
        //別の場所にフォーカスされているかのチェックと背景白化(強制指示用)
        //
        public void BaseText_Leave_Check()
        {
            //背景色がシアンの場合
            if (this.BackColor == Color.Cyan)
            {
                //背景色を白にする
                this.BackColor = Color.White;
            }

            //フォーカスが外れたのでリセット
            blnFirstClick = true;
        }
    }
}
