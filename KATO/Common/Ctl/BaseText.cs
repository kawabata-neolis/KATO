using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Ctl
{
    public partial class BaseText : TextBox
    {
        //最初のクリックかの判断
        Boolean firstclickjud = true;

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
            if (firstclickjud == true && this.Text != "")
            {
                //全選択
                this.SelectAll();

                //クリックによる全選択を有効にする
                this.BeginInvoke(new MethodInvoker(() => this.SelectAll()));

                //二回目以降のクリックに切り替える
                firstclickjud = false;
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
            firstclickjud = true;
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
    }
}
