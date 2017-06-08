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
    public partial class BaseTextTextSet : UserControl
    {
        private String labelName;
        public String LabelName
        {
            get
            {
                return labelName;
            }
            set
            {
                labelName = value;
                this.nameLabel.Text = labelName;
                codeTxt.Left = nameLabel.Size.Width + spaceNameCode;
                valueText.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue;
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueText.Size.Width + spaceValueAppend;
            }
        }

        public string CodeTxtText
        {
            get
            {
                return codeTxt.Text;
            }
            set
            {
                codeTxt.Text = value;
            }
        }

        public string valueTextText
        {
            get
            {
                return valueText.Text;
            }
            set
            {
                valueText.Text = value;
            }
        }

        public string AppendLabelText
        {
            get
            {
                return appendLabel.Text;
            }
            set
            {
                appendLabel.Text = value;
            }
        }

        private int spaceNameCode = 4;
        public int SpaceNameCode
        {
            get
            {
                return spaceNameCode;
            }
            set
            {
                spaceNameCode = value;
                codeTxt.Left = nameLabel.Size.Width + spaceNameCode;
                valueText.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue;
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueText.Size.Width + spaceValueAppend;
            }
        }

        private int spaceCodeValue = 4;
        public int SpaceCodeValue
        {
            get
            {
                return spaceCodeValue;
            }
            set
            {
                spaceCodeValue = value;
                valueText.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue;
            }
        }

        private int spaceValueAppend = 4;
        public int SpaceValueAppend
        {
            get
            {
                return spaceValueAppend;
            }
            set
            {
                spaceValueAppend = value;
                valueText.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue;
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueText.Size.Width + spaceValueAppend;
            }
        }

        private int codeTxtSize = 33;
        public int CodeTxtSize
        {
            get
            {
                return codeTxtSize;
            }
            set
            {
                codeTxtSize = value;
                codeTxt.Width = codeTxtSize;
                codeTxt.Left = nameLabel.Width + spaceNameCode;
                valueText.Left = nameLabel.Width + spaceNameCode + codeTxt.Width + spaceCodeValue;
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueText.Size.Width + spaceValueAppend;
            }
        }

        private int valueTextSize;
        public int ValueTextSize
        {
            get
            {
                return valueTextSize;
            }
            set
            {
                valueTextSize = value;
                valueText.Width = valueTextSize;
                valueText.Left = nameLabel.Width + spaceNameCode + codeTxt.Width + spaceCodeValue;
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueText.Size.Width + spaceValueAppend;

            }
        }

        private int appendLabelSize;
        public int AppendLabelSize
        {
            get
            {
                return appendLabelSize;
            }
            set
            {
                appendLabelSize = value;
                appendLabel.Width = appendLabelSize;
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueText.Size.Width + spaceValueAppend;

            }
        }

        private Boolean showAppendFlg;
        public Boolean ShowAppendFlg
        {
            get
            {
                return showAppendFlg;
            }
            set
            {
                showAppendFlg = value;
                appendLabel.Visible = showAppendFlg;
            }
        }

        private Boolean readOnlyANDTabStopFlg;
        public Boolean ReadOnlyANDTabStopFlg
        {
            get
            {
                return readOnlyANDTabStopFlg;
            }
            set
            {
                readOnlyANDTabStopFlg = value;
                if (readOnlyANDTabStopFlg == true)
                {
                    valueText.ReadOnly = true;
                    valueText.TabStop = false;
                }
                else
                {
                    valueText.ReadOnly = false;
                    valueText.TabStop = true;
                }
                valueText.BackColor = Color.White;
            }
        }

        public BaseTextTextSet()
        {
            InitializeComponent();
        }

        private void BaseTextTextSet_Load(object sender, EventArgs e)
        {

        }
    }
}
