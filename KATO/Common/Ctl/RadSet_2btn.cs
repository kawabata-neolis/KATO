using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Ctl
{
    public partial class RadSet_2btn : UserControl
    {
        private String labelTitle;
        public String LabelTitle
        {
            get
            {
                return labelTitle;
            }
            set
            {
                labelTitle = value;
                this.lblTitle.Text = labelTitle;
                lblTitle.Left = positionLabelTitle_X;
                lblTitle.Top = positionLabelTitle_Y;
            }
        }

        public string Radbtn1Text
        {
            get
            {
                return radbtn0.Text;
            }
            set
            {
                this.radbtn0.Text = value;
            }
        }

        public string Radbtn2Text
        {
            get
            {
                return radbtn1.Text;
            }
            set
            {
                this.radbtn1.Text = value;
            }
        }

        private int positionLabelTitle_X;
        public int PositionLabelTitle_X
        {
            get
            {
                return positionLabelTitle_X;
            }
            set
            {
                positionLabelTitle_X = value;
                lblTitle.Left = positionLabelTitle_X;
            }
        }

        private int positionLabelTitle_Y;
        public int PositionLabelTitle_Y
        {
            get
            {
                return positionLabelTitle_Y;
            }
            set
            {
                positionLabelTitle_Y = value;
                lblTitle.Top = positionLabelTitle_Y;
            }
        }

        private int positionRadbtn1_X = 150;
        public int PositionRadbtn1_X
        {
            get
            {
                return positionRadbtn1_X;
            }
            set
            {
                positionRadbtn1_X = value;
                radbtn0.Left = positionRadbtn1_X;
            }
        }

        private int positionRadbtn1_Y = 0;
        public int PositionRadbtn1_Y
        {
            get
            {
                return positionRadbtn1_Y;
            }
            set
            {
                positionRadbtn1_Y = value;
                radbtn0.Top = positionRadbtn1_Y;
            }
        }

        private int positionRadbtn2_X = 250;
        public int PositionRadbtn2_X
        {
            get
            {
                return positionRadbtn2_X;
            }
            set
            {
                positionRadbtn2_X = value;
                radbtn1.Left = positionRadbtn2_X;
            }
        }

        private int positionRadbtn2_Y = 0;
        public int PositionRadbtn2_Y
        {
            get
            {
                return positionRadbtn2_Y;
            }
            set
            {
                positionRadbtn2_Y = value;
                radbtn1.Top = positionRadbtn2_Y;
            }
        }

        public RadSet_2btn()
        {
            InitializeComponent();
            radbtn0.Checked = true;
        }

        public int judCheckBtn()
        {
            int intCheckBtn;

            if (radbtn0.Checked == true)
            {
                intCheckBtn = 0;
            }
            else if (radbtn1.Checked == true)
            {
                intCheckBtn = 1;
            }
            else
            {
                intCheckBtn = -1;
            }
            return (intCheckBtn);
        }

        private void RadSet_2btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                //閉じる
                this.Parent.Dispose();
            }
        }
    }
}
