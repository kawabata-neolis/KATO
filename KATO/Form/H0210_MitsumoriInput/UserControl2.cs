using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Form.H0210_MitsumoriInput
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void textBox26_Leave(object sender, EventArgs e)
        {
            inputLbl(textBox26, textBox21);
        }

        private void textBox25_Leave(object sender, EventArgs e)
        {
            inputLbl(textBox25, textBox20);
        }

        private void textBox23_Leave(object sender, EventArgs e)
        {
            inputLbl(textBox23, textBox13);
        }

        private void inputLbl(TextBox tb, TextBox lbl)
        {
            if (!isNullBlank(tb.Text))
            {
                lbl.Text = "ﾃｽﾄ用ﾀﾞﾐｰｺｰﾄﾞ";
            }
        }

        private Boolean isNullBlank(String s)
        {
            Boolean ret = false;

            if (s == null)
            {
                ret = true;
            }
            else if (s.Equals(""))
            {
                ret = true;
            }

            return ret;
        }
    }
}
