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

        //
        Boolean blankFlg = false;
        public Boolean BlankFlg
        {
            set
            {
                this.blankFlg = value;
            }
            get
            {
                return blankFlg;
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
        public string[] setComboBox (ArrayList arList)
        {
            string[] strList = null;

            if (blankFlg == true)
            {
                //ArrayListの先頭に空を追加
                arList.Insert(0, "");
            }

            //配列型に変換
            strList = (string[])arList.ToArray(typeof(string));

            //空だった場合
            if (!strList.Any())
            {
                strList.CopyTo(strList = new string[strList.Length + 1], 0);
                strList[0] = "";
            }

            //コンボボックスのリストに追加
            this.Items.AddRange(strList);
            return (strList);
        }
    }
}
