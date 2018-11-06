namespace KATO.Form.C1530_TantouUriageArariNenkan
{
    partial class C1530_TantouUriageArariNenkan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblYear = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gridUriage = new KATO.Common.Ctl.BaseDataGridView();
            this.txtYear = new KATO.Common.Ctl.BaseTextMoney();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lsTantoF = new KATO.Common.Ctl.LabelSet_Tantousha();
            this.lsTantoT = new KATO.Common.Ctl.LabelSet_Tantousha();
            this.nameLabel = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridUriage)).BeginInit();
            this.lsTantoT.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.TabIndex = 4;
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF12
            // 
            this.btnF12.TabIndex = 11;
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.TabIndex = 10;
            this.btnF11.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF10
            // 
            this.btnF10.TabStop = false;
            this.btnF10.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.TabStop = false;
            this.btnF09.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF08
            // 
            this.btnF08.TabStop = false;
            this.btnF08.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF07
            // 
            this.btnF07.TabStop = false;
            this.btnF07.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF06
            // 
            this.btnF06.TabStop = false;
            this.btnF06.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF05
            // 
            this.btnF05.TabStop = false;
            this.btnF05.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.TabIndex = 12;
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.TabStop = false;
            this.btnF03.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF02
            // 
            this.btnF02.TabStop = false;
            this.btnF02.Click += new System.EventHandler(this.judBtnClick);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblYear.Location = new System.Drawing.Point(103, 24);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(23, 15);
            this.lblYear.strToolTip = null;
            this.lblYear.TabIndex = 87;
            this.lblYear.Text = "年";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridUriage
            // 
            this.gridUriage.AllowUserToAddRows = false;
            this.gridUriage.AllowUserToResizeColumns = false;
            this.gridUriage.AllowUserToResizeRows = false;
            this.gridUriage.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUriage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridUriage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridUriage.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridUriage.EnableHeadersVisualStyles = false;
            this.gridUriage.Location = new System.Drawing.Point(12, 60);
            this.gridUriage.Name = "gridUriage";
            this.gridUriage.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUriage.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridUriage.RowHeadersVisible = false;
            this.gridUriage.RowTemplate.Height = 21;
            this.gridUriage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUriage.Size = new System.Drawing.Size(1555, 717);
            this.gridUriage.StandardTab = true;
            this.gridUriage.TabIndex = 88;
            // 
            // txtYear
            // 
            this.txtYear.blnCommaOK = false;
            this.txtYear.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYear.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtYear.intDeciSet = 0;
            this.txtYear.intIntederSet = 0;
            this.txtYear.intShishagonyu = 0;
            this.txtYear.Location = new System.Drawing.Point(57, 21);
            this.txtYear.MaxLength = 4;
            this.txtYear.MinusFlg = false;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(40, 22);
            this.txtYear.TabIndex = 1;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYear_KeyDown);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(148, 24);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(55, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 91;
            this.baseLabel1.Text = "担当者";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lsTantoF
            // 
            this.lsTantoF.AppendLabelSize = 0;
            this.lsTantoF.AppendLabelText = "";
            this.lsTantoF.CodeTxtSize = 40;
            this.lsTantoF.CodeTxtText = "";
            this.lsTantoF.LabelName = "";
            this.lsTantoF.Location = new System.Drawing.Point(209, 21);
            this.lsTantoF.Name = "lsTantoF";
            this.lsTantoF.ShowAppendFlg = false;
            this.lsTantoF.Size = new System.Drawing.Size(172, 22);
            this.lsTantoF.SpaceCodeValue = 4;
            this.lsTantoF.SpaceNameCode = 4;
            this.lsTantoF.SpaceValueAppend = 4;
            this.lsTantoF.TabIndex = 2;
            this.lsTantoF.ValueLabelSize = 120;
            this.lsTantoF.ValueLabelText = "";
            this.lsTantoF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.baseText1_KeyDown);
            // 
            // lsTantoT
            // 
            this.lsTantoT.AppendLabelSize = 0;
            this.lsTantoT.AppendLabelText = "";
            this.lsTantoT.CodeTxtSize = 40;
            this.lsTantoT.CodeTxtText = "";
            this.lsTantoT.Controls.Add(this.nameLabel);
            this.lsTantoT.LabelName = "";
            this.lsTantoT.Location = new System.Drawing.Point(416, 21);
            this.lsTantoT.Name = "lsTantoT";
            this.lsTantoT.ShowAppendFlg = false;
            this.lsTantoT.Size = new System.Drawing.Size(180, 22);
            this.lsTantoT.SpaceCodeValue = 4;
            this.lsTantoT.SpaceNameCode = 4;
            this.lsTantoT.SpaceValueAppend = 4;
            this.lsTantoT.TabIndex = 3;
            this.lsTantoT.ValueLabelSize = 120;
            this.lsTantoT.ValueLabelText = "";
            this.lsTantoT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.baseText2_KeyDown);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.nameLabel.Location = new System.Drawing.Point(2, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 15);
            this.nameLabel.strToolTip = null;
            this.nameLabel.TabIndex = 0;
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(387, 24);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(23, 15);
            this.baseLabel2.strToolTip = null;
            this.baseLabel2.TabIndex = 95;
            this.baseLabel2.Text = "～";
            this.baseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // C1530_TantouUriageArariNenkan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 826);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.lsTantoT);
            this.Controls.Add(this.lsTantoF);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.gridUriage);
            this.Controls.Add(this.lblYear);
            this.Name = "C1530_TantouUriageArariNenkan";
            this.Text = "C0140_TantouUriageArariNenkan";
            this.Load += new System.EventHandler(this.C0140_TantouUriageArariNenkan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.C0140_TantouUriageArariNenkan_KeyDown);
            this.Controls.SetChildIndex(this.cmbSubWinShow, 0);
            this.Controls.SetChildIndex(this.btnF01, 0);
            this.Controls.SetChildIndex(this.btnF02, 0);
            this.Controls.SetChildIndex(this.btnF03, 0);
            this.Controls.SetChildIndex(this.btnF04, 0);
            this.Controls.SetChildIndex(this.btnF05, 0);
            this.Controls.SetChildIndex(this.btnF06, 0);
            this.Controls.SetChildIndex(this.btnF07, 0);
            this.Controls.SetChildIndex(this.btnF08, 0);
            this.Controls.SetChildIndex(this.btnF09, 0);
            this.Controls.SetChildIndex(this.btnF10, 0);
            this.Controls.SetChildIndex(this.btnF11, 0);
            this.Controls.SetChildIndex(this.btnF12, 0);
            this.Controls.SetChildIndex(this.lblYear, 0);
            this.Controls.SetChildIndex(this.gridUriage, 0);
            this.Controls.SetChildIndex(this.txtYear, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.lsTantoF, 0);
            this.Controls.SetChildIndex(this.lsTantoT, 0);
            this.Controls.SetChildIndex(this.baseLabel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridUriage)).EndInit();
            this.lsTantoT.ResumeLayout(false);
            this.lsTantoT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.Ctl.BaseLabel lblYear;
        private Common.Ctl.BaseDataGridView gridUriage;
        private Common.Ctl.BaseTextMoney txtYear;
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.LabelSet_Tantousha lsTantoF;
        private Common.Ctl.LabelSet_Tantousha lsTantoT;
        private Common.Ctl.BaseLabel nameLabel;
        private Common.Ctl.BaseLabel baseLabel2;
    }
}