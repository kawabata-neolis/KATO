namespace KATO.Common.Form
{
    partial class UriageList
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
            this.lblRecords = new System.Windows.Forms.Label();
            this.gridUriage = new KATO.Common.Ctl.BaseDataGridView();
            this.txtCalendarClose = new KATO.Common.Ctl.BaseCalendar();
            this.txtCalendarOpen = new KATO.Common.Ctl.BaseCalendar();
            this.txtHin = new KATO.Common.Ctl.BaseText();
            this.lblHin = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblSukima = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblYMD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Torihikisaki = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.labelSet_Tantousha = new KATO.Common.Ctl.LabelSet_Tantousha();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridUriage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(20, 566);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 112;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // gridUriage
            // 
            this.gridUriage.AllowUserToAddRows = false;
            this.gridUriage.AllowUserToResizeColumns = false;
            this.gridUriage.AllowUserToResizeRows = false;
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
            this.gridUriage.Location = new System.Drawing.Point(12, 117);
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
            this.gridUriage.Size = new System.Drawing.Size(931, 434);
            this.gridUriage.StandardTab = true;
            this.gridUriage.TabIndex = 6;
            this.gridUriage.DoubleClick += new System.EventHandler(this.gridUriage_DoubleClick);
            this.gridUriage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridUriageKeyDown);
            // 
            // txtCalendarClose
            // 
            this.txtCalendarClose.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtCalendarClose.Location = new System.Drawing.Point(253, 63);
            this.txtCalendarClose.Name = "txtCalendarClose";
            this.txtCalendarClose.Size = new System.Drawing.Size(90, 22);
            this.txtCalendarClose.TabIndex = 3;
            this.txtCalendarClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCalendarOpen
            // 
            this.txtCalendarOpen.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtCalendarOpen.Location = new System.Drawing.Point(117, 63);
            this.txtCalendarOpen.Name = "txtCalendarOpen";
            this.txtCalendarOpen.Size = new System.Drawing.Size(90, 22);
            this.txtCalendarOpen.TabIndex = 2;
            this.txtCalendarOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHin
            // 
            this.txtHin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHin.Location = new System.Drawing.Point(117, 89);
            this.txtHin.MaxLength = 40;
            this.txtHin.Name = "txtHin";
            this.txtHin.Size = new System.Drawing.Size(417, 22);
            this.txtHin.TabIndex = 4;
            this.txtHin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judUriListTxtKeyDown);
            this.txtHin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUriage_KeyUp);
            // 
            // lblHin
            // 
            this.lblHin.AutoSize = true;
            this.lblHin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHin.Location = new System.Drawing.Point(12, 92);
            this.lblHin.Name = "lblHin";
            this.lblHin.Size = new System.Drawing.Size(87, 15);
            this.lblHin.strToolTip = null;
            this.lblHin.TabIndex = 111;
            this.lblHin.Text = "品名・型番";
            this.lblHin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSukima
            // 
            this.lblSukima.AutoSize = true;
            this.lblSukima.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSukima.Location = new System.Drawing.Point(218, 66);
            this.lblSukima.Name = "lblSukima";
            this.lblSukima.Size = new System.Drawing.Size(23, 15);
            this.lblSukima.strToolTip = null;
            this.lblSukima.TabIndex = 111;
            this.lblSukima.Text = "～";
            this.lblSukima.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblYMD
            // 
            this.lblYMD.AutoSize = true;
            this.lblYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblYMD.Location = new System.Drawing.Point(12, 66);
            this.lblYMD.Name = "lblYMD";
            this.lblYMD.Size = new System.Drawing.Size(87, 15);
            this.lblYMD.strToolTip = null;
            this.lblYMD.TabIndex = 111;
            this.lblYMD.Text = "伝票年月日";
            this.lblYMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Torihikisaki
            // 
            this.labelSet_Torihikisaki.AppendLabelSize = 0;
            this.labelSet_Torihikisaki.AppendLabelText = "";
            this.labelSet_Torihikisaki.CodeTxtSize = 40;
            this.labelSet_Torihikisaki.CodeTxtText = "";
            this.labelSet_Torihikisaki.LabelName = "得意先";
            this.labelSet_Torihikisaki.Location = new System.Drawing.Point(12, 38);
            this.labelSet_Torihikisaki.Name = "labelSet_Torihikisaki";
            this.labelSet_Torihikisaki.ShowAppendFlg = false;
            this.labelSet_Torihikisaki.Size = new System.Drawing.Size(472, 22);
            this.labelSet_Torihikisaki.SpaceCodeValue = 4;
            this.labelSet_Torihikisaki.SpaceNameCode = 50;
            this.labelSet_Torihikisaki.SpaceValueAppend = 4;
            this.labelSet_Torihikisaki.TabIndex = 1;
            this.labelSet_Torihikisaki.ValueLabelSize = 300;
            this.labelSet_Torihikisaki.ValueLabelText = "";
            // 
            // labelSet_Tantousha
            // 
            this.labelSet_Tantousha.AppendLabelSize = 0;
            this.labelSet_Tantousha.AppendLabelText = "";
            this.labelSet_Tantousha.CodeTxtSize = 40;
            this.labelSet_Tantousha.CodeTxtText = "";
            this.labelSet_Tantousha.LabelName = "担当者";
            this.labelSet_Tantousha.Location = new System.Drawing.Point(12, 12);
            this.labelSet_Tantousha.Name = "labelSet_Tantousha";
            this.labelSet_Tantousha.ShowAppendFlg = false;
            this.labelSet_Tantousha.Size = new System.Drawing.Size(295, 22);
            this.labelSet_Tantousha.SpaceCodeValue = 4;
            this.labelSet_Tantousha.SpaceNameCode = 50;
            this.labelSet_Tantousha.SpaceValueAppend = 4;
            this.labelSet_Tantousha.TabIndex = 0;
            this.labelSet_Tantousha.ValueLabelSize = 120;
            this.labelSet_Tantousha.ValueLabelText = "";
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(827, 41);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 5;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnKensakuClick);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(827, 12);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 7;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // UriageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 614);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.gridUriage);
            this.Controls.Add(this.txtCalendarClose);
            this.Controls.Add(this.txtCalendarOpen);
            this.Controls.Add(this.txtHin);
            this.Controls.Add(this.lblHin);
            this.Controls.Add(this.lblSukima);
            this.Controls.Add(this.lblYMD);
            this.Controls.Add(this.labelSet_Torihikisaki);
            this.Controls.Add(this.labelSet_Tantousha);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Name = "UriageList";
            this.Text = "UriageList";
            this.Load += new System.EventHandler(this.UriageList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UriageList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridUriage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctl.BaseButton btnF11;
        private Ctl.BaseButton btnF12;
        private Ctl.LabelSet_Tantousha labelSet_Tantousha;
        private Ctl.LabelSet_Torihikisaki labelSet_Torihikisaki;
        private Ctl.BaseLabel lblYMD;
        private Ctl.BaseLabel lblHin;
        private Ctl.BaseText txtHin;
        private Ctl.BaseCalendar txtCalendarOpen;
        private Ctl.BaseCalendar txtCalendarClose;
        private Ctl.BaseLabel lblSukima;
        private Ctl.BaseDataGridView gridUriage;
        private System.Windows.Forms.Label lblRecords;
    }
}