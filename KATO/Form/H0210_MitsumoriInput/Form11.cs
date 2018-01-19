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

        public string strMitsuNo = null;
        public string strMitsuYMD = null;
        public string strMitsuTitle = null;
        public string strTantoName = null;
        public string strNoki = null;
        public string strJoken = null;
        public string strKigen = null;
        public string strBiko = null;
        public string strToriCd = null;
        public string strToriName = null;
        public string strTantoCd = null;
        public string strEigyoCd = null;
        public string strUriTotal = null;
        public string strArariTotal = null;
        public string strNonyuCd = null;
        public string strNonyuName = null;

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
                f = inputCheck(uc.lsDaibun.codeTxt, f, uc.cD);
                f = inputCheck(uc.lsChubun.codeTxt, f, uc.cC);
                f = inputCheck(uc.lsMaker.codeTxt, f, uc.cM);
            }

            if (f)
            {
                FrmParent.UpdFlg = true;
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
                    f = inputCheck(uc.lsDaibun.codeTxt, f, uc.cD);
                    f = inputCheck(uc.lsChubun.codeTxt, f, uc.cC);
                    f = inputCheck(uc.lsMaker.codeTxt, f, uc.cM);
                }

                if (f) {
                    FrmParent.UpdFlg = true;
                    this.Close();
                }
            }
            else if (e.KeyData == Keys.F12)
            {
                FrmParent.UpdFlg = false;
                this.Close();
            }
        }

        private Boolean inputCheck(BaseText tb, Boolean b, DataGridViewCell c)
        {
            Boolean ret = b;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                ret = false;
                tb.BackColor = Color.Red;
            } else
            {
                tb.BackColor = Color.White;
                c.Value = tb.Text;

            }
            return ret;
        }

    }
}
