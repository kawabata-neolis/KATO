namespace KATO.Form.E0330_TokuisakiMotocyoKakunin
{
    partial class E0330_TokuisakiMotocyoKakunin
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
            this.labelSet_Tokuisaki = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.baseLabel3 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtStartYM = new KATO.Common.Ctl.BaseCalendarYM();
            this.baseLabel4 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtEndYM = new KATO.Common.Ctl.BaseCalendarYM();
            this.baseLabel5 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtZenZan = new KATO.Common.Ctl.BaseText();
            this.baseLabel6 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtNyukin = new KATO.Common.Ctl.BaseText();
            this.baseLabel7 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtUriage = new KATO.Common.Ctl.BaseText();
            this.baseLabel8 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtZei = new KATO.Common.Ctl.BaseText();
            this.baseLabel9 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtZandaka = new KATO.Common.Ctl.BaseText();
            this.gridTorihiki = new KATO.Common.Ctl.BaseDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.TabIndex = 3;
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF12
            // 
            this.btnF12.TabIndex = 10;
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.TabIndex = 4;
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // labelSet_Tokuisaki
            // 
            this.labelSet_Tokuisaki.AppendLabelSize = 60;
            this.labelSet_Tokuisaki.AppendLabelText = "";
            this.labelSet_Tokuisaki.CodeTxtSize = 40;
            this.labelSet_Tokuisaki.CodeTxtText = "";
            this.labelSet_Tokuisaki.LabelName = "得意先コード";
            this.labelSet_Tokuisaki.Location = new System.Drawing.Point(29, 15);
            this.labelSet_Tokuisaki.Name = "labelSet_Tokuisaki";
            this.labelSet_Tokuisaki.ShowAppendFlg = true;
            this.labelSet_Tokuisaki.Size = new System.Drawing.Size(518, 22);
            this.labelSet_Tokuisaki.SpaceCodeValue = 4;
            this.labelSet_Tokuisaki.SpaceNameCode = 4;
            this.labelSet_Tokuisaki.SpaceValueAppend = 4;
            this.labelSet_Tokuisaki.TabIndex = 0;
            this.labelSet_Tokuisaki.ValueLabelSize = 300;
            this.labelSet_Tokuisaki.ValueLabelText = "";
            // 
            // baseLabel3
            // 
            this.baseLabel3.AutoSize = true;
            this.baseLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel3.Location = new System.Drawing.Point(30, 77);
            this.baseLabel3.Name = "baseLabel3";
            this.baseLabel3.Size = new System.Drawing.Size(103, 15);
            this.baseLabel3.strToolTip = null;
            this.baseLabel3.TabIndex = 88;
            this.baseLabel3.Text = "検索開始年月";
            this.baseLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStartYM
            // 
            this.txtStartYM.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtStartYM.Location = new System.Drawing.Point(136, 74);
            this.txtStartYM.MaxLength = 7;
            this.txtStartYM.Name = "txtStartYM";
            this.txtStartYM.Size = new System.Drawing.Size(65, 22);
            this.txtStartYM.TabIndex = 1;
            this.txtStartYM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // baseLabel4
            // 
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel4.Location = new System.Drawing.Point(208, 77);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(23, 15);
            this.baseLabel4.strToolTip = null;
            this.baseLabel4.TabIndex = 88;
            this.baseLabel4.Text = "～";
            this.baseLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEndYM
            // 
            this.txtEndYM.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtEndYM.Location = new System.Drawing.Point(236, 74);
            this.txtEndYM.MaxLength = 7;
            this.txtEndYM.Name = "txtEndYM";
            this.txtEndYM.Size = new System.Drawing.Size(65, 22);
            this.txtEndYM.TabIndex = 2;
            this.txtEndYM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // baseLabel5
            // 
            this.baseLabel5.AutoSize = true;
            this.baseLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel5.Location = new System.Drawing.Point(394, 51);
            this.baseLabel5.Name = "baseLabel5";
            this.baseLabel5.Size = new System.Drawing.Size(71, 15);
            this.baseLabel5.strToolTip = null;
            this.baseLabel5.TabIndex = 88;
            this.baseLabel5.Text = "前月残高";
            this.baseLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtZenZan
            // 
            this.txtZenZan.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtZenZan.Location = new System.Drawing.Point(383, 74);
            this.txtZenZan.MaxLength = 12;
            this.txtZenZan.Name = "txtZenZan";
            this.txtZenZan.Size = new System.Drawing.Size(91, 22);
            this.txtZenZan.TabIndex = 5;
            this.txtZenZan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // baseLabel6
            // 
            this.baseLabel6.AutoSize = true;
            this.baseLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel6.Location = new System.Drawing.Point(508, 51);
            this.baseLabel6.Name = "baseLabel6";
            this.baseLabel6.Size = new System.Drawing.Size(71, 15);
            this.baseLabel6.strToolTip = null;
            this.baseLabel6.TabIndex = 88;
            this.baseLabel6.Text = "入金金額";
            this.baseLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNyukin
            // 
            this.txtNyukin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtNyukin.Location = new System.Drawing.Point(500, 74);
            this.txtNyukin.MaxLength = 12;
            this.txtNyukin.Name = "txtNyukin";
            this.txtNyukin.Size = new System.Drawing.Size(91, 22);
            this.txtNyukin.TabIndex = 6;
            this.txtNyukin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // baseLabel7
            // 
            this.baseLabel7.AutoSize = true;
            this.baseLabel7.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel7.Location = new System.Drawing.Point(627, 51);
            this.baseLabel7.Name = "baseLabel7";
            this.baseLabel7.Size = new System.Drawing.Size(71, 15);
            this.baseLabel7.strToolTip = null;
            this.baseLabel7.TabIndex = 88;
            this.baseLabel7.Text = "売上金額";
            this.baseLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUriage
            // 
            this.txtUriage.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtUriage.Location = new System.Drawing.Point(619, 74);
            this.txtUriage.MaxLength = 12;
            this.txtUriage.Name = "txtUriage";
            this.txtUriage.Size = new System.Drawing.Size(91, 22);
            this.txtUriage.TabIndex = 7;
            this.txtUriage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // baseLabel8
            // 
            this.baseLabel8.AutoSize = true;
            this.baseLabel8.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel8.Location = new System.Drawing.Point(746, 51);
            this.baseLabel8.Name = "baseLabel8";
            this.baseLabel8.Size = new System.Drawing.Size(71, 15);
            this.baseLabel8.strToolTip = null;
            this.baseLabel8.TabIndex = 88;
            this.baseLabel8.Text = "消費税額";
            this.baseLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtZei
            // 
            this.txtZei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtZei.Location = new System.Drawing.Point(737, 74);
            this.txtZei.MaxLength = 12;
            this.txtZei.Name = "txtZei";
            this.txtZei.Size = new System.Drawing.Size(91, 22);
            this.txtZei.TabIndex = 8;
            this.txtZei.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // baseLabel9
            // 
            this.baseLabel9.AutoSize = true;
            this.baseLabel9.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel9.Location = new System.Drawing.Point(866, 51);
            this.baseLabel9.Name = "baseLabel9";
            this.baseLabel9.Size = new System.Drawing.Size(71, 15);
            this.baseLabel9.strToolTip = null;
            this.baseLabel9.TabIndex = 88;
            this.baseLabel9.Text = "当月残高";
            this.baseLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtZandaka
            // 
            this.txtZandaka.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtZandaka.Location = new System.Drawing.Point(856, 74);
            this.txtZandaka.MaxLength = 12;
            this.txtZandaka.Name = "txtZandaka";
            this.txtZandaka.Size = new System.Drawing.Size(91, 22);
            this.txtZandaka.TabIndex = 9;
            this.txtZandaka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gridTorihiki
            // 
            this.gridTorihiki.AllowUserToAddRows = false;
            this.gridTorihiki.AllowUserToDeleteRows = false;
            this.gridTorihiki.AllowUserToResizeColumns = false;
            this.gridTorihiki.AllowUserToResizeRows = false;
            this.gridTorihiki.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTorihiki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTorihiki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTorihiki.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridTorihiki.EnableHeadersVisualStyles = false;
            this.gridTorihiki.Location = new System.Drawing.Point(36, 110);
            this.gridTorihiki.Name = "gridTorihiki";
            this.gridTorihiki.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTorihiki.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTorihiki.RowHeadersVisible = false;
            this.gridTorihiki.RowTemplate.Height = 21;
            this.gridTorihiki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTorihiki.Size = new System.Drawing.Size(1347, 648);
            this.gridTorihiki.StandardTab = true;
            this.gridTorihiki.TabIndex = 92;
            // 
            // E0330_TokuisakiMotocyoKakunin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.gridTorihiki);
            this.Controls.Add(this.txtZandaka);
            this.Controls.Add(this.txtZei);
            this.Controls.Add(this.txtUriage);
            this.Controls.Add(this.txtNyukin);
            this.Controls.Add(this.txtZenZan);
            this.Controls.Add(this.txtEndYM);
            this.Controls.Add(this.txtStartYM);
            this.Controls.Add(this.baseLabel9);
            this.Controls.Add(this.baseLabel8);
            this.Controls.Add(this.baseLabel7);
            this.Controls.Add(this.baseLabel6);
            this.Controls.Add(this.baseLabel4);
            this.Controls.Add(this.baseLabel5);
            this.Controls.Add(this.baseLabel3);
            this.Controls.Add(this.labelSet_Tokuisaki);
            this.Name = "E0330_TokuisakiMotocyoKakunin";
            this.Text = "";
            this.Load += new System.EventHandler(this.E0330_TokuisakiMotocyoKakunin_Load);
            this.Shown += new System.EventHandler(this.E0330_TokuisakiMotocyoKakunin_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.E0330_TokuisakiMotocyoKakunin_KeyDown);
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
            this.Controls.SetChildIndex(this.labelSet_Tokuisaki, 0);
            this.Controls.SetChildIndex(this.baseLabel3, 0);
            this.Controls.SetChildIndex(this.baseLabel5, 0);
            this.Controls.SetChildIndex(this.baseLabel4, 0);
            this.Controls.SetChildIndex(this.baseLabel6, 0);
            this.Controls.SetChildIndex(this.baseLabel7, 0);
            this.Controls.SetChildIndex(this.baseLabel8, 0);
            this.Controls.SetChildIndex(this.baseLabel9, 0);
            this.Controls.SetChildIndex(this.txtStartYM, 0);
            this.Controls.SetChildIndex(this.txtEndYM, 0);
            this.Controls.SetChildIndex(this.txtZenZan, 0);
            this.Controls.SetChildIndex(this.txtNyukin, 0);
            this.Controls.SetChildIndex(this.txtUriage, 0);
            this.Controls.SetChildIndex(this.txtZei, 0);
            this.Controls.SetChildIndex(this.txtZandaka, 0);
            this.Controls.SetChildIndex(this.gridTorihiki, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.LabelSet_Torihikisaki labelSet_Tokuisaki;
        private Common.Ctl.BaseLabel baseLabel3;
        private Common.Ctl.BaseCalendarYM txtStartYM;
        private Common.Ctl.BaseLabel baseLabel4;
        private Common.Ctl.BaseCalendarYM txtEndYM;
        private Common.Ctl.BaseLabel baseLabel5;
        private Common.Ctl.BaseText txtZenZan;
        private Common.Ctl.BaseLabel baseLabel6;
        private Common.Ctl.BaseText txtNyukin;
        private Common.Ctl.BaseLabel baseLabel7;
        private Common.Ctl.BaseText txtUriage;
        private Common.Ctl.BaseLabel baseLabel8;
        private Common.Ctl.BaseText txtZei;
        private Common.Ctl.BaseLabel baseLabel9;
        private Common.Ctl.BaseText txtZandaka;
        private Common.Ctl.BaseDataGridView gridTorihiki;
    }
}