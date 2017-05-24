using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Ctl
{
    public partial class BaseLabel : Label
    {

        private String strtooltip;
        public String strToolTip {
            get
            {
                return strtooltip;
            }
            set
            {
                strtooltip = value;
                toolTip1.SetToolTip(this, strtooltip);
            } 
        }

        public BaseLabel()
        {
            InitializeComponent();
        }

        public BaseLabel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
