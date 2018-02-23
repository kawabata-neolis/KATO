namespace KATO.Form.A0170_ShukoShoninInput
{
    partial class A0170_ShukoShoninInput
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
            this.lblset_Eigyosho = new KATO.Common.Ctl.LabelSet_Eigyosho();
            this.txtYMD = new KATO.Common.Ctl.BaseCalendar();
            this.lblYMD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblHelp = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblShukoiraimesai = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblBox1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gridShukoiraimesai = new KATO.Common.Ctl.BaseDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridShukoiraimesai)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.TabIndex = 3;
            // 
            // btnF12
            // 
            this.btnF12.TabStop = false;
            // 
            // btnF11
            // 
            this.btnF11.TabStop = false;
            // 
            // btnF10
            // 
            this.btnF10.TabStop = false;
            // 
            // btnF09
            // 
            this.btnF09.TabStop = false;
            // 
            // btnF08
            // 
            this.btnF08.TabStop = false;
            // 
            // btnF07
            // 
            this.btnF07.TabStop = false;
            // 
            // btnF06
            // 
            this.btnF06.TabStop = false;
            // 
            // btnF05
            // 
            this.btnF05.TabIndex = 7;
            // 
            // btnF04
            // 
            this.btnF04.TabIndex = 6;
            // 
            // btnF03
            // 
            this.btnF03.TabIndex = 5;
            // 
            // btnF02
            // 
            this.btnF02.TabIndex = 4;
            // 
            // lblset_Eigyosho
            // 
            this.lblset_Eigyosho.AppendLabelSize = 0;
            this.lblset_Eigyosho.AppendLabelText = "";
            this.lblset_Eigyosho.CodeTxtSize = 40;
            this.lblset_Eigyosho.CodeTxtText = "";
            this.lblset_Eigyosho.LabelName = "営業所コード";
            this.lblset_Eigyosho.Location = new System.Drawing.Point(365, 26);
            this.lblset_Eigyosho.Name = "lblset_Eigyosho";
            this.lblset_Eigyosho.ShowAppendFlg = false;
            this.lblset_Eigyosho.Size = new System.Drawing.Size(413, 22);
            this.lblset_Eigyosho.SpaceCodeValue = 4;
            this.lblset_Eigyosho.SpaceNameCode = 4;
            this.lblset_Eigyosho.SpaceValueAppend = 4;
            this.lblset_Eigyosho.TabIndex = 1;
            this.lblset_Eigyosho.ValueLabelSize = 250;
            this.lblset_Eigyosho.ValueLabelText = "";
            this.lblset_Eigyosho.Leave += new System.EventHandler(this.lblset_Eigyosho_Leave);
            // 
            // txtYMD
            // 
            this.txtYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYMD.Location = new System.Drawing.Point(185, 26);
            this.txtYMD.MaxLength = 10;
            this.txtYMD.Name = "txtYMD";
            this.txtYMD.Size = new System.Drawing.Size(100, 22);
            this.txtYMD.TabIndex = 0;
            this.txtYMD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtShukoKeyUp);
            // 
            // lblYMD
            // 
            this.lblYMD.AutoSize = true;
            this.lblYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblYMD.Location = new System.Drawing.Point(80, 29);
            this.lblYMD.Name = "lblYMD";
            this.lblYMD.Size = new System.Drawing.Size(87, 15);
            this.lblYMD.strToolTip = null;
            this.lblYMD.TabIndex = 89;
            this.lblYMD.Text = "出庫年月日";
            this.lblYMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHelp.ForeColor = System.Drawing.Color.Navy;
            this.lblHelp.Location = new System.Drawing.Point(1035, 39);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(247, 15);
            this.lblHelp.strToolTip = null;
            this.lblHelp.TabIndex = 90;
            this.lblHelp.Text = "承認欄をダブルクリックします。";
            this.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShukoiraimesai
            // 
            this.lblShukoiraimesai.AutoSize = true;
            this.lblShukoiraimesai.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShukoiraimesai.ForeColor = System.Drawing.Color.Navy;
            this.lblShukoiraimesai.Location = new System.Drawing.Point(48, 65);
            this.lblShukoiraimesai.Name = "lblShukoiraimesai";
            this.lblShukoiraimesai.Size = new System.Drawing.Size(103, 15);
            this.lblShukoiraimesai.strToolTip = null;
            this.lblShukoiraimesai.TabIndex = 96;
            this.lblShukoiraimesai.Text = "出庫依頼明細";
            this.lblShukoiraimesai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBox1
            // 
            this.lblBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBox1.Location = new System.Drawing.Point(34, 73);
            this.lblBox1.Name = "lblBox1";
            this.lblBox1.Size = new System.Drawing.Size(1353, 685);
            this.lblBox1.strToolTip = null;
            this.lblBox1.TabIndex = 95;
            this.lblBox1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridShukoiraimesai
            // 
            this.gridShukoiraimesai.AllowUserToAddRows = false;
            this.gridShukoiraimesai.AllowUserToResizeColumns = false;
            this.gridShukoiraimesai.AllowUserToResizeRows = false;
            this.gridShukoiraimesai.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShukoiraimesai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridShukoiraimesai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridShukoiraimesai.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridShukoiraimesai.EnableHeadersVisualStyles = false;
            this.gridShukoiraimesai.Location = new System.Drawing.Point(51, 95);
            this.gridShukoiraimesai.Name = "gridShukoiraimesai";
            this.gridShukoiraimesai.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShukoiraimesai.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridShukoiraimesai.RowHeadersVisible = false;
            this.gridShukoiraimesai.RowTemplate.Height = 21;
            this.gridShukoiraimesai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShukoiraimesai.Size = new System.Drawing.Size(1313, 647);
            this.gridShukoiraimesai.StandardTab = true;
            this.gridShukoiraimesai.TabIndex = 2;
            this.gridShukoiraimesai.DoubleClick += new System.EventHandler(this.gridShukoiraimesai_DoubleClick);
            this.gridShukoiraimesai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridShukoiraimesai_KeyDown);
            // 
            // A0170_ShukoShoninInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.gridShukoiraimesai);
            this.Controls.Add(this.lblShukoiraimesai);
            this.Controls.Add(this.lblBox1);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblYMD);
            this.Controls.Add(this.txtYMD);
            this.Controls.Add(this.lblset_Eigyosho);
            this.Name = "A0170_ShukoShoninInput";
            this.Text = "A0170_ShukoShoninInput";
            this.Load += new System.EventHandler(this.A0170_ShukoShoninInput_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.A0170_ShukoShoninInput_KeyDown);
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
            this.Controls.SetChildIndex(this.cmbSubWinShow, 0);
            this.Controls.SetChildIndex(this.lblset_Eigyosho, 0);
            this.Controls.SetChildIndex(this.txtYMD, 0);
            this.Controls.SetChildIndex(this.lblYMD, 0);
            this.Controls.SetChildIndex(this.lblHelp, 0);
            this.Controls.SetChildIndex(this.lblBox1, 0);
            this.Controls.SetChildIndex(this.lblShukoiraimesai, 0);
            this.Controls.SetChildIndex(this.gridShukoiraimesai, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridShukoiraimesai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.LabelSet_Eigyosho lblset_Eigyosho;
        private Common.Ctl.BaseCalendar txtYMD;
        private Common.Ctl.BaseLabel lblYMD;
        private Common.Ctl.BaseLabel lblHelp;
        private Common.Ctl.BaseLabel lblShukoiraimesai;
        private Common.Ctl.BaseLabel lblBox1;
        private Common.Ctl.BaseDataGridView gridShukoiraimesai;
    }
}