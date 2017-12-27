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
    public partial class Form12 : BaseForm
    {
        private int intRowIdx = 0;
        public int IntRowIdx
        {
            get
            {
                return intRowIdx;
            }
            set
            {
                intRowIdx = value;
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

        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 2;

            dataGridView1.CurrentCell = dataGridView1[0, 0];
            dataGridView1.CurrentCell.Value = "大進工業";
            dataGridView1.CurrentCell = dataGridView1[1, 0];
            dataGridView1.CurrentCell.Value = "ｷﾞﾔ";
            dataGridView1.CurrentCell = dataGridView1[2, 0];
            dataGridView1.CurrentCell.Value = "1.5M24A (T15 φ19H5)";

            dataGridView1.CurrentCell = dataGridView1[0, 1];
            dataGridView1.CurrentCell.Value = "大進工業";
            dataGridView1.CurrentCell = dataGridView1[1, 1];
            dataGridView1.CurrentCell.Value = "ｷﾞﾔ";
            dataGridView1.CurrentCell = dataGridView1[2, 1];
            dataGridView1.CurrentCell.Value = "1.5M24B (28*25 φ19H5)";

            dataGridView1.CurrentCell = dataGridView1[0, 0];
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            frmParent.IntRowIdx = IntRowIdx;
            frmParent.StrDaibunrui = textBox26.Text;
            frmParent.StrChubunrui = textBox25.Text;
            frmParent.StrMaker = textBox23.Text;

            if (dataGridView1.CurrentCell != null) {
                int r = dataGridView1.CurrentCell.RowIndex;
                frmParent.StrHinmei = (dataGridView1[2, r].Value).ToString();
            }
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || (textBox1.Text).Equals(""))
            {
                textBox1.BackColor = Color.Red;
            }
            else
            {
                frmParent.IntRowIdx = IntRowIdx;
                frmParent.StrDaibunrui = textBox26.Text;
                frmParent.StrChubunrui = textBox25.Text;
                frmParent.StrMaker = textBox23.Text;
                frmParent.StrHinmei = textBox1.Text;
                this.Close();
            }
        }

        private void Form12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
            {
                this.Close();
            }
            else if (e.KeyData == Keys.F1)
            {
                if (textBox1.Text == null || (textBox1.Text).Equals(""))
                {
                    textBox1.BackColor = Color.Red;
                } else
                {
                    frmParent.IntRowIdx = IntRowIdx;
                    frmParent.StrDaibunrui = textBox26.Text;
                    frmParent.StrChubunrui = textBox25.Text;
                    frmParent.StrMaker = textBox23.Text;
                    frmParent.StrHinmei = textBox1.Text;
                    this.Close();
                }
            }
            else if (e.KeyData == Keys.F11)
            {
                dataGridView1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                frmParent.IntRowIdx = IntRowIdx;
                frmParent.StrDaibunrui = textBox26.Text;
                frmParent.StrChubunrui = textBox25.Text;
                frmParent.StrMaker = textBox23.Text;

                if (dataGridView1.CurrentCell != null)
                {
                    int r = dataGridView1.CurrentCell.RowIndex;
                    frmParent.StrHinmei = (dataGridView1[2, r].Value).ToString();
                }
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }
    }
}
