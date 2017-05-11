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
    public partial class RadSet_4btn : UserControl
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

        public string Radbtn3Text
        {
            get
            {
                return radbtn2.Text;
            }
            set
            {
                this.radbtn2.Text = value;
            }
        }

        public string Radbtn4Text
        {
            get
            {
                return radbtn3.Text;
            }
            set
            {
                this.radbtn3.Text = value;
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

        private int positionRadbtn3_X = 350;
        public int PositionRadbtn3_X
        {
            get
            {
                return positionRadbtn3_X;
            }
            set
            {
                positionRadbtn3_X = value;
                radbtn2.Left = positionRadbtn3_X;
            }
        }

        private int positionRadbtn3_Y = 0;
        public int PositionRadbtn3_Y
        {
            get
            {
                return positionRadbtn3_Y;
            }
            set
            {
                positionRadbtn3_Y = value;
                radbtn2.Top = positionRadbtn3_Y;
            }
        }

        private int positionRadbtn4_X = 450;
        public int PositionRadbtn4_X
        {
            get
            {
                return positionRadbtn4_X;
            }
            set
            {
                positionRadbtn4_X = value;
                radbtn3.Left = positionRadbtn4_X;
            }
        }

        private int positionRadbtn4_Y = 0;
        public int PositionRadbtn4_Y
        {
            get
            {
                return positionRadbtn4_Y;
            }
            set
            {
                positionRadbtn4_Y = value;
                radbtn3.Top = positionRadbtn4_Y;
            }
        }


        public RadSet_4btn()
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
            else if (radbtn2.Checked == true)
            {
                intCheckBtn = 2;
            }
            else if (radbtn3.Checked == true)
            {
                intCheckBtn = 3;
            }
            else
            {
                intCheckBtn = -1;
            }
            return (intCheckBtn);
        }

        private void RadSet_4btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                //閉じる
                this.Parent.Dispose();
            }
        }
    }
}
