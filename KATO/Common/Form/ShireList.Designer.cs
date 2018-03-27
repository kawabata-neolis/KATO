namespace KATO.Common.Form
{
    partial class ShireList
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
            this.gridShire = new KATO.Common.Ctl.BaseDataGridView();
            this.txtCalendarClose = new KATO.Common.Ctl.BaseCalendar();
            this.txtCalendarOpen = new KATO.Common.Ctl.BaseCalendar();
            this.txtHachuNo = new KATO.Common.Ctl.BaseText();
            this.lblHachuNo = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtHin = new KATO.Common.Ctl.BaseText();
            this.lblHin = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblSukima = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblYMD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Torihikisaki = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.nameLabel = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Tantousha = new KATO.Common.Ctl.LabelSet_Tantousha();
            this.object_641ac0e1_3bc7_4d87_a3ae_64129b936786 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridShire)).BeginInit();
            this.labelSet_Torihikisaki.SuspendLayout();
            this.labelSet_Tantousha.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(20, 675);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 124;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // gridShire
            // 
            this.gridShire.AllowUserToAddRows = false;
            this.gridShire.AllowUserToResizeColumns = false;
            this.gridShire.AllowUserToResizeRows = false;
            this.gridShire.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShire.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridShire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridShire.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridShire.EnableHeadersVisualStyles = false;
            this.gridShire.Location = new System.Drawing.Point(12, 143);
            this.gridShire.Name = "gridShire";
            this.gridShire.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShire.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridShire.RowHeadersVisible = false;
            this.gridShire.RowTemplate.Height = 21;
            this.gridShire.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShire.Size = new System.Drawing.Size(1356, 518);
            this.gridShire.StandardTab = true;
            this.gridShire.TabIndex = 6;
            this.gridShire.DoubleClick += new System.EventHandler(this.gridUriage_DoubleClick);
            this.gridShire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridUriage_KeyDown);
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
            // txtHachuNo
            // 
            this.txtHachuNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHachuNo.Location = new System.Drawing.Point(117, 115);
            this.txtHachuNo.MaxLength = 7;
            this.txtHachuNo.Name = "txtHachuNo";
            this.txtHachuNo.Size = new System.Drawing.Size(65, 22);
            this.txtHachuNo.TabIndex = 5;
            this.txtHachuNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHachuNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judShiListTxtKeyDown);
            this.txtHachuNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtShireList_KeyUp);
            // 
            // lblHachuNo
            // 
            this.lblHachuNo.AutoSize = true;
            this.lblHachuNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHachuNo.Location = new System.Drawing.Point(12, 118);
            this.lblHachuNo.Name = "lblHachuNo";
            this.lblHachuNo.Size = new System.Drawing.Size(71, 15);
            this.lblHachuNo.strToolTip = null;
            this.lblHachuNo.TabIndex = 121;
            this.lblHachuNo.Text = "注文番号";
            this.lblHachuNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHin
            // 
            this.txtHin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHin.Location = new System.Drawing.Point(117, 89);
            this.txtHin.MaxLength = 40;
            this.txtHin.Name = "txtHin";
            this.txtHin.Size = new System.Drawing.Size(417, 22);
            this.txtHin.TabIndex = 4;
            this.txtHin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judShiListTxtKeyDown);
            // 
            // lblHin
            // 
            this.lblHin.AutoSize = true;
            this.lblHin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHin.Location = new System.Drawing.Point(12, 92);
            this.lblHin.Name = "lblHin";
            this.lblHin.Size = new System.Drawing.Size(87, 15);
            this.lblHin.strToolTip = null;
            this.lblHin.TabIndex = 121;
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
            this.lblSukima.TabIndex = 122;
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
            this.lblYMD.TabIndex = 123;
            this.lblYMD.Text = "伝票年月日";
            this.lblYMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Torihikisaki
            // 
            this.labelSet_Torihikisaki.AppendLabelSize = 0;
            this.labelSet_Torihikisaki.AppendLabelText = "";
            this.labelSet_Torihikisaki.CodeTxtSize = 40;
            this.labelSet_Torihikisaki.CodeTxtText = "";
            this.labelSet_Torihikisaki.Controls.Add(this.nameLabel);
            this.labelSet_Torihikisaki.LabelName = "仕入先";
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
            this.labelSet_Torihikisaki.Leave += new System.EventHandler(this.labelSet_Torihikisaki_Leave);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.nameLabel.Location = new System.Drawing.Point(2, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(55, 15);
            this.nameLabel.strToolTip = null;
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "得意先";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Tantousha
            // 
            this.labelSet_Tantousha.AppendLabelSize = 0;
            this.labelSet_Tantousha.AppendLabelText = "";
            this.labelSet_Tantousha.CodeTxtSize = 40;
            this.labelSet_Tantousha.CodeTxtText = "";
            this.labelSet_Tantousha.Controls.Add(this.object_641ac0e1_3bc7_4d87_a3ae_64129b936786);
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
            this.labelSet_Tantousha.Leave += new System.EventHandler(this.labelSet_Tantousha_Leave);
            // 
            // object_641ac0e1_3bc7_4d87_a3ae_64129b936786
            // 
            this.object_641ac0e1_3bc7_4d87_a3ae_64129b936786.AutoSize = true;
            this.object_641ac0e1_3bc7_4d87_a3ae_64129b936786.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_641ac0e1_3bc7_4d87_a3ae_64129b936786.Location = new System.Drawing.Point(2, 3);
            this.object_641ac0e1_3bc7_4d87_a3ae_64129b936786.Name = "object_641ac0e1_3bc7_4d87_a3ae_64129b936786";
            this.object_641ac0e1_3bc7_4d87_a3ae_64129b936786.Size = new System.Drawing.Size(55, 15);
            this.object_641ac0e1_3bc7_4d87_a3ae_64129b936786.strToolTip = null;
            this.object_641ac0e1_3bc7_4d87_a3ae_64129b936786.TabIndex = 0;
            this.object_641ac0e1_3bc7_4d87_a3ae_64129b936786.Text = "担当者";
            this.object_641ac0e1_3bc7_4d87_a3ae_64129b936786.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(1258, 41);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 5;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnKensakuClick);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(1258, 12);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 7;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // ShireList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 717);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.gridShire);
            this.Controls.Add(this.txtCalendarClose);
            this.Controls.Add(this.txtCalendarOpen);
            this.Controls.Add(this.txtHachuNo);
            this.Controls.Add(this.lblHachuNo);
            this.Controls.Add(this.txtHin);
            this.Controls.Add(this.lblHin);
            this.Controls.Add(this.lblSukima);
            this.Controls.Add(this.lblYMD);
            this.Controls.Add(this.labelSet_Torihikisaki);
            this.Controls.Add(this.labelSet_Tantousha);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Name = "ShireList";
            this.Text = "ShireList";
            this.Load += new System.EventHandler(this.ShireList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShireList_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gridShire)).EndInit();
            this.labelSet_Torihikisaki.ResumeLayout(false);
            this.labelSet_Torihikisaki.PerformLayout();
            this.labelSet_Tantousha.ResumeLayout(false);
            this.labelSet_Tantousha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecords;
        private Ctl.BaseDataGridView gridShire;
        private Ctl.BaseCalendar txtCalendarClose;
        private Ctl.BaseCalendar txtCalendarOpen;
        private Ctl.BaseText txtHin;
        private Ctl.BaseLabel lblHin;
        private Ctl.BaseLabel lblSukima;
        private Ctl.BaseLabel lblYMD;
        private Ctl.LabelSet_Torihikisaki labelSet_Torihikisaki;
        private Ctl.BaseLabel nameLabel;
        private Ctl.LabelSet_Tantousha labelSet_Tantousha;
        private Ctl.BaseLabel object_641ac0e1_3bc7_4d87_a3ae_64129b936786;
        private Ctl.BaseButton btnF11;
        private Ctl.BaseButton btnF12;
        private Ctl.BaseLabel lblHachuNo;
        private Ctl.BaseText txtHachuNo;
    }
}