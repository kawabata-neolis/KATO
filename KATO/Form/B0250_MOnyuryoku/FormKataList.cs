using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Form.B0250_MOnyuryoku
{
    public partial class FormKataList : System.Windows.Forms.Form
    {
        B0250_MOnyuryoku MOnyuryoku = null;
        string stSu;

        public FormKataList(B0250_MOnyuryoku b, string st)
        {
            InitializeComponent();
            MOnyuryoku = b;
            stSu = st;
        }

        private void baseDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (setval())
            {
                this.Close();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool setval()
        {
            int i = baseDataGridView1.CurrentCell.RowIndex;
            //if (i == 0)
            //{
            //    return false;
            //}
            int r = int.Parse(baseDataGridView1.Rows[i].Cells["列番"].Value.ToString());
            MOnyuryoku.gridKataban2.Rows[r].Cells["発注指"].Value = stSu;
            MOnyuryoku.ari = true;
            return true;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (setval())
            {
                this.Close();
            }
        }
    }
}
