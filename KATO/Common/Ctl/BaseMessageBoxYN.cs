using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Common.Ctl
{
    public partial class BaseMessageBoxYN : System.Windows.Forms.Form
    {
        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //何のメッセージを表示するかの判定
        public int intMessageJud = 0;

        public BaseMessageBoxYN()
        {
            InitializeComponent();
        }


        public BaseMessageBoxYN(String strText, String strLabel)
        {
            InitializeComponent();

            this.Text = strText;
            baseLabel1.Text = strLabel;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        // タイトルバーの閉じるボタン、コントロールボックスの「閉じる」、Alt + F4 を無効
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.Demand,
                Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                const int FRM_NOCLOSE = 0x200;
                CreateParams cpForm = base.CreateParams;
                cpForm.ClassStyle = cpForm.ClassStyle | FRM_NOCLOSE;

                return cpForm;
            }
        }

        //private Boolean baseButton1_Click(object sender, EventArgs e)
        private void baseButton1_Click(object sender, EventArgs e)
        {
            Boolean blnYes = true;
            this.Close();
            //return (blnYes);
        }

        //private Boolean baseButton2_Click(object sender, EventArgs e)
        private void baseButton2_Click(object sender, EventArgs e)
        {
            Boolean blnYes = false;
            this.Close();
            //return (blnYes);
        }
    }
}
