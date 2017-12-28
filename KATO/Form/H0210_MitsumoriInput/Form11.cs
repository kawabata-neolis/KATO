using KATO.Common.Util;
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

namespace KATO.Form.H0210_MitsumoriInput
{
    public partial class Form11 : BaseForm
    {
        private string[] strHinmeis;
        public string[] StrHinmeis
        {
            get
            {
                return strHinmeis;
            }
            set
            {
                strHinmeis = value;
            }
        }

        private H0210_MitsumoriInput frmParent;
        public H0210_MitsumoriInput FrmParent
        {
            get
            {
                return frmParent;
            }
            set
            {
                frmParent = value;
            }
        }

        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean f = true;

            foreach (Control cc in tableLayoutPanel1.Controls)
            {
                UserControl2 uc = (UserControl2)cc;
                f = inputCheck(uc.textBox26, f);
                f = inputCheck(uc.textBox25, f);
                f = inputCheck(uc.textBox23, f);
            }

            if (f)
            {
                FrmParent.PrintFlg = true;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                Boolean f = true;

                foreach (Control cc in tableLayoutPanel1.Controls)
                {
                    UserControl2 uc = (UserControl2)cc;
                    f = inputCheck(uc.textBox26, f);
                    f = inputCheck(uc.textBox25, f);
                    f = inputCheck(uc.textBox23, f);
                }

                if (f) {
                    FrmParent.PrintFlg = true;
                    this.Close();
                }
            }
            else if (e.KeyData == Keys.F12)
            {
                this.Close();
            }
        }

        private Boolean inputCheck(TextBox tb, Boolean b)
        {
            Boolean ret = b;

            if (isNullBlank(tb.Text))
            {
                ret = false;
                tb.BackColor = Color.Red;
            } else
            {
                tb.BackColor = Color.White;
            }
            return ret;
        }

        private Boolean isNullBlank(String s)
        {
            Boolean ret = false;

            if (s == null)
            {
                ret = true;
            } else if (s.Equals(""))
            {
                ret = true;
            }

            return ret;
        }

        private void inputLbl(TextBox tb, TextBox lbl)
        {
            if (!isNullBlank(tb.Text)) {
                lbl.Text = "ﾃｽﾄ用ﾀﾞﾐｰｺｰﾄﾞ";
            }
        }
    }
}
