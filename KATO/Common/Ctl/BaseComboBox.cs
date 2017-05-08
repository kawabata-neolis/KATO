using System;
using System.Collections;
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
    public partial class BaseComboBox : ComboBox
    {
        //最初のクリックかの判断
        Boolean firstclickjud = true;

        Boolean blnNull;


        Boolean blankFlg;
        public Boolean blnBlankFlg
        {
            get
            {
                return this.blankFlg;
            }
            set
            {
                this.blankFlg = value;
            }
        }

        public BaseComboBox()
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

        //
        //コンボボックスのリストに入れる
        //
        public Boolean setComboBox(KeyValuePair<int, string>[] kvpComboBox)
        {
            //コンボボックス内にデータを入れる
            this.DataSource = kvpComboBox;
            this.DisplayMember = "Value";
            this.ValueMember = "Key";

            if (this.DataSource == null)
            {
                blnNull = true;
            }

            if (blankFlg == true)
            {
                blnNull = true;
            }

            return (blnNull);
        }
    }
}
