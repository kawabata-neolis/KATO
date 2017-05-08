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
    public partial class BaseMenuButton : Button
    {
        public BaseMenuButton()
        {
            InitializeComponent();

            //枠線色決める（未指定）
            //this.FlatAppearance.BorderColor = 
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
            this.BackColor = Color.LightYellow;
        }

    }
}
