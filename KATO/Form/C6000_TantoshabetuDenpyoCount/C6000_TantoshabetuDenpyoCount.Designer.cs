namespace KATO.Form.C6000_TantoshabetuDenpyoCount
{
    partial class C6000_TantoshabetuDenpyoCount
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
            this.lblDenoyoYMD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblTantoshaCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtDenpyoOpen = new KATO.Common.Ctl.BaseCalendar();
            this.txtDenpyoClose = new KATO.Common.Ctl.BaseCalendar();
            this.lblAida1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gbViewData = new System.Windows.Forms.GroupBox();
            this.gridViewData = new KATO.Common.Ctl.BaseDataGridView();
            this.txtTanto = new KATO.Common.Ctl.BaseText();
            this.txtShuko = new KATO.Common.Ctl.BaseText();
            this.txtNyuko = new KATO.Common.Ctl.BaseText();
            this.txtUriage = new KATO.Common.Ctl.BaseText();
            this.txtShire = new KATO.Common.Ctl.BaseText();
            this.txtHachu = new KATO.Common.Ctl.BaseText();
            this.baseLabel5 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtJuchuKei = new KATO.Common.Ctl.BaseText();
            this.lblPrintCount = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtPrintCount = new KATO.Common.Ctl.BaseText();
            this.lblAida2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTantoshaCdOpen = new KATO.Common.Ctl.LabelSet_Tantousha();
            this.txtTantoshaCdClose = new KATO.Common.Ctl.LabelSet_Tantousha();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gbViewData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).BeginInit();
            this.txtTantoshaCdClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF12
            // 
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF10
            // 
            this.btnF10.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF08
            // 
            this.btnF08.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF07
            // 
            this.btnF07.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF06
            // 
            this.btnF06.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF05
            // 
            this.btnF05.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF02
            // 
            this.btnF02.Click += new System.EventHandler(this.judBtnClick);
            // 
            // lblDenoyoYMD
            // 
            this.lblDenoyoYMD.AutoSize = true;
            this.lblDenoyoYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDenoyoYMD.Location = new System.Drawing.Point(465, 12);
            this.lblDenoyoYMD.Name = "lblDenoyoYMD";
            this.lblDenoyoYMD.Size = new System.Drawing.Size(87, 15);
            this.lblDenoyoYMD.strToolTip = null;
            this.lblDenoyoYMD.TabIndex = 87;
            this.lblDenoyoYMD.Text = "伝票年月日";
            this.lblDenoyoYMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTantoshaCd
            // 
            this.lblTantoshaCd.AutoSize = true;
            this.lblTantoshaCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTantoshaCd.Location = new System.Drawing.Point(466, 42);
            this.lblTantoshaCd.Name = "lblTantoshaCd";
            this.lblTantoshaCd.Size = new System.Drawing.Size(103, 15);
            this.lblTantoshaCd.strToolTip = null;
            this.lblTantoshaCd.TabIndex = 88;
            this.lblTantoshaCd.Text = "担当者コード";
            this.lblTantoshaCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDenpyoOpen
            // 
            this.txtDenpyoOpen.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDenpyoOpen.Location = new System.Drawing.Point(575, 9);
            this.txtDenpyoOpen.Name = "txtDenpyoOpen";
            this.txtDenpyoOpen.Size = new System.Drawing.Size(90, 22);
            this.txtDenpyoOpen.TabIndex = 0;
            this.txtDenpyoOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDenpyoOpen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTantoshabetuDenpyoCount_KeyUp);
            // 
            // txtDenpyoClose
            // 
            this.txtDenpyoClose.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDenpyoClose.Location = new System.Drawing.Point(733, 9);
            this.txtDenpyoClose.Name = "txtDenpyoClose";
            this.txtDenpyoClose.Size = new System.Drawing.Size(90, 22);
            this.txtDenpyoClose.TabIndex = 1;
            this.txtDenpyoClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDenpyoClose.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTantoshabetuDenpyoCount_KeyUp);
            // 
            // lblAida1
            // 
            this.lblAida1.AutoSize = true;
            this.lblAida1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblAida1.Location = new System.Drawing.Point(688, 12);
            this.lblAida1.Name = "lblAida1";
            this.lblAida1.Size = new System.Drawing.Size(23, 15);
            this.lblAida1.strToolTip = null;
            this.lblAida1.TabIndex = 88;
            this.lblAida1.Text = "～";
            this.lblAida1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbViewData
            // 
            this.gbViewData.Controls.Add(this.gridViewData);
            this.gbViewData.Controls.Add(this.txtTanto);
            this.gbViewData.Controls.Add(this.txtShuko);
            this.gbViewData.Controls.Add(this.txtNyuko);
            this.gbViewData.Controls.Add(this.txtUriage);
            this.gbViewData.Controls.Add(this.txtShire);
            this.gbViewData.Controls.Add(this.txtHachu);
            this.gbViewData.Controls.Add(this.baseLabel5);
            this.gbViewData.Controls.Add(this.txtJuchuKei);
            this.gbViewData.Location = new System.Drawing.Point(136, 67);
            this.gbViewData.Name = "gbViewData";
            this.gbViewData.Size = new System.Drawing.Size(1147, 691);
            this.gbViewData.TabIndex = 93;
            this.gbViewData.TabStop = false;
            // 
            // gridViewData
            // 
            this.gridViewData.AllowUserToAddRows = false;
            this.gridViewData.AllowUserToResizeColumns = false;
            this.gridViewData.AllowUserToResizeRows = false;
            this.gridViewData.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewData.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewData.EnableHeadersVisualStyles = false;
            this.gridViewData.Location = new System.Drawing.Point(20, 25);
            this.gridViewData.Name = "gridViewData";
            this.gridViewData.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridViewData.RowHeadersVisible = false;
            this.gridViewData.RowTemplate.Height = 21;
            this.gridViewData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewData.Size = new System.Drawing.Size(1109, 615);
            this.gridViewData.StandardTab = true;
            this.gridViewData.TabIndex = 0;
            this.gridViewData.TabStop = false;
            // 
            // txtTanto
            // 
            this.txtTanto.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanto.Location = new System.Drawing.Point(1010, 655);
            this.txtTanto.Name = "txtTanto";
            this.txtTanto.Size = new System.Drawing.Size(100, 22);
            this.txtTanto.TabIndex = 91;
            this.txtTanto.TabStop = false;
            this.txtTanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtShuko
            // 
            this.txtShuko.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShuko.Location = new System.Drawing.Point(874, 655);
            this.txtShuko.Name = "txtShuko";
            this.txtShuko.Size = new System.Drawing.Size(100, 22);
            this.txtShuko.TabIndex = 91;
            this.txtShuko.TabStop = false;
            this.txtShuko.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNyuko
            // 
            this.txtNyuko.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtNyuko.Location = new System.Drawing.Point(737, 655);
            this.txtNyuko.Name = "txtNyuko";
            this.txtNyuko.Size = new System.Drawing.Size(100, 22);
            this.txtNyuko.TabIndex = 91;
            this.txtNyuko.TabStop = false;
            this.txtNyuko.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUriage
            // 
            this.txtUriage.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtUriage.Location = new System.Drawing.Point(601, 655);
            this.txtUriage.Name = "txtUriage";
            this.txtUriage.Size = new System.Drawing.Size(100, 22);
            this.txtUriage.TabIndex = 91;
            this.txtUriage.TabStop = false;
            this.txtUriage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtShire
            // 
            this.txtShire.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShire.Location = new System.Drawing.Point(465, 655);
            this.txtShire.Name = "txtShire";
            this.txtShire.Size = new System.Drawing.Size(100, 22);
            this.txtShire.TabIndex = 91;
            this.txtShire.TabStop = false;
            this.txtShire.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHachu
            // 
            this.txtHachu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHachu.Location = new System.Drawing.Point(329, 655);
            this.txtHachu.Name = "txtHachu";
            this.txtHachu.Size = new System.Drawing.Size(100, 22);
            this.txtHachu.TabIndex = 91;
            this.txtHachu.TabStop = false;
            this.txtHachu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // baseLabel5
            // 
            this.baseLabel5.AutoSize = true;
            this.baseLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel5.Location = new System.Drawing.Point(106, 658);
            this.baseLabel5.Name = "baseLabel5";
            this.baseLabel5.Size = new System.Drawing.Size(39, 15);
            this.baseLabel5.strToolTip = null;
            this.baseLabel5.TabIndex = 88;
            this.baseLabel5.Text = "合計";
            this.baseLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtJuchuKei
            // 
            this.txtJuchuKei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtJuchuKei.Location = new System.Drawing.Point(193, 655);
            this.txtJuchuKei.Name = "txtJuchuKei";
            this.txtJuchuKei.Size = new System.Drawing.Size(100, 22);
            this.txtJuchuKei.TabIndex = 91;
            this.txtJuchuKei.TabStop = false;
            this.txtJuchuKei.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrintCount
            // 
            this.lblPrintCount.AutoSize = true;
            this.lblPrintCount.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblPrintCount.Location = new System.Drawing.Point(1299, 739);
            this.lblPrintCount.Name = "lblPrintCount";
            this.lblPrintCount.Size = new System.Drawing.Size(71, 15);
            this.lblPrintCount.strToolTip = null;
            this.lblPrintCount.TabIndex = 88;
            this.lblPrintCount.Text = "印刷枚数";
            this.lblPrintCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrintCount
            // 
            this.txtPrintCount.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtPrintCount.Location = new System.Drawing.Point(1378, 736);
            this.txtPrintCount.Name = "txtPrintCount";
            this.txtPrintCount.Size = new System.Drawing.Size(30, 22);
            this.txtPrintCount.TabIndex = 91;
            this.txtPrintCount.TabStop = false;
            // 
            // lblAida2
            // 
            this.lblAida2.AutoSize = true;
            this.lblAida2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblAida2.Location = new System.Drawing.Point(634, 42);
            this.lblAida2.Name = "lblAida2";
            this.lblAida2.Size = new System.Drawing.Size(23, 15);
            this.lblAida2.strToolTip = null;
            this.lblAida2.TabIndex = 88;
            this.lblAida2.Text = "～";
            this.lblAida2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTantoshaCdOpen
            // 
            this.txtTantoshaCdOpen.AppendLabelSize = 0;
            this.txtTantoshaCdOpen.AppendLabelText = "";
            this.txtTantoshaCdOpen.CodeTxtSize = 40;
            this.txtTantoshaCdOpen.CodeTxtText = "";
            this.txtTantoshaCdOpen.LabelName = "";
            this.txtTantoshaCdOpen.Location = new System.Drawing.Point(571, 38);
            this.txtTantoshaCdOpen.Name = "txtTantoshaCdOpen";
            this.txtTantoshaCdOpen.ShowAppendFlg = false;
            this.txtTantoshaCdOpen.Size = new System.Drawing.Size(47, 22);
            this.txtTantoshaCdOpen.SpaceCodeValue = 4;
            this.txtTantoshaCdOpen.SpaceNameCode = 4;
            this.txtTantoshaCdOpen.SpaceValueAppend = 4;
            this.txtTantoshaCdOpen.TabIndex = 3;
            this.txtTantoshaCdOpen.ValueLabelSize = 0;
            this.txtTantoshaCdOpen.ValueLabelText = "";
            // 
            // txtTantoshaCdClose
            // 
            this.txtTantoshaCdClose.AppendLabelSize = 0;
            this.txtTantoshaCdClose.AppendLabelText = "";
            this.txtTantoshaCdClose.CodeTxtSize = 40;
            this.txtTantoshaCdClose.CodeTxtText = "";
            this.txtTantoshaCdClose.Controls.Add(this.baseLabel1);
            this.txtTantoshaCdClose.LabelName = "";
            this.txtTantoshaCdClose.Location = new System.Drawing.Point(671, 38);
            this.txtTantoshaCdClose.Name = "txtTantoshaCdClose";
            this.txtTantoshaCdClose.ShowAppendFlg = false;
            this.txtTantoshaCdClose.Size = new System.Drawing.Size(52, 22);
            this.txtTantoshaCdClose.SpaceCodeValue = 4;
            this.txtTantoshaCdClose.SpaceNameCode = 4;
            this.txtTantoshaCdClose.SpaceValueAppend = 4;
            this.txtTantoshaCdClose.TabIndex = 4;
            this.txtTantoshaCdClose.ValueLabelSize = 0;
            this.txtTantoshaCdClose.ValueLabelText = "";
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(2, 3);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(0, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 0;
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // C6000_TantoshabetuDenpyoCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.txtTantoshaCdClose);
            this.Controls.Add(this.txtTantoshaCdOpen);
            this.Controls.Add(this.gbViewData);
            this.Controls.Add(this.txtDenpyoClose);
            this.Controls.Add(this.txtPrintCount);
            this.Controls.Add(this.txtDenpyoOpen);
            this.Controls.Add(this.lblAida2);
            this.Controls.Add(this.lblAida1);
            this.Controls.Add(this.lblPrintCount);
            this.Controls.Add(this.lblTantoshaCd);
            this.Controls.Add(this.lblDenoyoYMD);
            this.Name = "C6000_TantoshabetuDenpyoCount";
            this.Text = "C6000_TantoshabetuDenpyoCount";
            this.Load += new System.EventHandler(this.C6000_TantoshabetuDenpyoCount_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.C6000_TantoshabetuDenpyoCount_KeyDown);
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
            this.Controls.SetChildIndex(this.lblDenoyoYMD, 0);
            this.Controls.SetChildIndex(this.lblTantoshaCd, 0);
            this.Controls.SetChildIndex(this.lblPrintCount, 0);
            this.Controls.SetChildIndex(this.lblAida1, 0);
            this.Controls.SetChildIndex(this.lblAida2, 0);
            this.Controls.SetChildIndex(this.txtDenpyoOpen, 0);
            this.Controls.SetChildIndex(this.txtPrintCount, 0);
            this.Controls.SetChildIndex(this.txtDenpyoClose, 0);
            this.Controls.SetChildIndex(this.gbViewData, 0);
            this.Controls.SetChildIndex(this.txtTantoshaCdOpen, 0);
            this.Controls.SetChildIndex(this.txtTantoshaCdClose, 0);
            this.gbViewData.ResumeLayout(false);
            this.gbViewData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).EndInit();
            this.txtTantoshaCdClose.ResumeLayout(false);
            this.txtTantoshaCdClose.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseLabel lblDenoyoYMD;
        private Common.Ctl.BaseLabel lblTantoshaCd;
        private Common.Ctl.BaseCalendar txtDenpyoOpen;
        private Common.Ctl.BaseCalendar txtDenpyoClose;
        private Common.Ctl.BaseLabel lblAida1;
        private System.Windows.Forms.GroupBox gbViewData;
        private Common.Ctl.BaseDataGridView gridViewData;
        private Common.Ctl.BaseText txtTanto;
        private Common.Ctl.BaseText txtShuko;
        private Common.Ctl.BaseText txtNyuko;
        private Common.Ctl.BaseText txtUriage;
        private Common.Ctl.BaseText txtShire;
        private Common.Ctl.BaseText txtHachu;
        private Common.Ctl.BaseLabel baseLabel5;
        private Common.Ctl.BaseText txtJuchuKei;
        private Common.Ctl.BaseLabel lblPrintCount;
        private Common.Ctl.BaseText txtPrintCount;
        private Common.Ctl.BaseLabel lblAida2;
        private Common.Ctl.LabelSet_Tantousha txtTantoshaCdOpen;
        private Common.Ctl.LabelSet_Tantousha txtTantoshaCdClose;
        private Common.Ctl.BaseLabel baseLabel1;
    }
}