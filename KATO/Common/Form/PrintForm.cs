using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Form
{
    public partial class PrintForm : System.Windows.Forms.Form
    {
        System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

        private int _action = 2;
        public int action
        {
            set
            {
                _action = value;
            }
            get
            {
                return _action;
            }
        }

        public PrintForm(Control c)
        {
            InitializeComponent();

            PrinterSettings.StringCollection oPrinter;
            oPrinter = PrinterSettings.InstalledPrinters;

            int intIdx = 0;
            foreach (string item in oPrinter)
            {
                prtList.Items.Add(item);
                if (item.Equals(pd.PrinterSettings.PrinterName))
                {
                    prtList.SelectedIndex = intIdx;
                    txtPrt.Text = item;
                }
                intIdx++;
            }
            rdPage0.Checked = true;
        }

        private void prtList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrt.Text = prtList.Items[prtList.SelectedIndex].ToString();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            _action = 0;
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            _action = 1;
            this.Close();
        }

        private void baseButton3_Click(object sender, EventArgs e)
        {
            _action = 2;
            this.Close();
        }


    }
}
