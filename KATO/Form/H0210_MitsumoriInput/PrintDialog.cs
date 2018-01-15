using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Form.H0210_MitsumoriInput
{
    public partial class PrintDialog : System.Windows.Forms.Form
    {
        H0210_MitsumoriInput frm;
        public PrintDialog(H0210_MitsumoriInput f)
        {
            frm = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm.intPrint = 0;
            this.Close();
        }

        private void btnPrintD_Click(object sender, EventArgs e)
        {
            frm.intPrint = 2;
            this.Close();

        }

        private void btnPrintS_Click(object sender, EventArgs e)
        {
            frm.intPrint = 1;
            this.Close();

        }
    }
}
