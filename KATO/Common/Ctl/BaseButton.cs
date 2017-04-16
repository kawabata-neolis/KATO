using System;
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
    public partial class BaseButton : Button
    {
        public BaseButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void BaseButton_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.Cyan;
        }

        private void BaseButton_Leave(object sender, EventArgs e)
        {
            UseVisualStyleBackColor = true;
        }
    }
}
