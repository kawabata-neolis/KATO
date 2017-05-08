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
    public partial class BaseTextLabelSet : UserControl
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
                valueLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue;
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueLabel.Size.Width + spaceValueAppend;
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

        public string ValueLabelText
        {
            get
            {
                return valueLabel.Text;
            }
            set
            {
                valueLabel.Text = value;
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
                valueLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue;
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueLabel.Size.Width + spaceValueAppend;
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
                valueLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue;
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
                valueLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue;
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueLabel.Size.Width + spaceValueAppend;
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
                valueLabel.Left = nameLabel.Width + spaceNameCode + codeTxt.Width + spaceCodeValue;
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueLabel.Size.Width + spaceValueAppend;
            }
        }

        private int valueLabelSize;
        public int ValueLabelSize
        {
            get
            {
                return valueLabelSize;
            }
            set
            {
                valueLabelSize = value;
                valueLabel.Width = valueLabelSize;
                valueLabel.Left = nameLabel.Width + spaceNameCode + codeTxt.Width + spaceCodeValue;
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueLabel.Size.Width + spaceValueAppend;

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
                appendLabel.Left = nameLabel.Size.Width + spaceNameCode + codeTxt.Size.Width + spaceCodeValue + valueLabel.Size.Width + spaceValueAppend;

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

        public BaseTextLabelSet()
        {
            InitializeComponent();
        }
    }
}
