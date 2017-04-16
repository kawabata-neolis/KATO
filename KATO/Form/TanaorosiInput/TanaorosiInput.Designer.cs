using KATO.Common;
using KATO.Common.Ctl;

namespace KATO.Form.TanaorosiInput
{
    partial class TanaorosiInput
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
            this.txtEigyousyo = new KATO.Common.Ctl.BaseText();
            this.txtDaibunrui = new KATO.Common.Ctl.BaseText();
            this.txtChubunrui = new KATO.Common.Ctl.BaseText();
            this.txtMaker = new KATO.Common.Ctl.BaseText();
            this.txtTanaban = new KATO.Common.Ctl.BaseText();
            this.lblDspEigyousyo = new KATO.Common.Ctl.BaseLabelGray();
            this.lblDspDaibunrui = new KATO.Common.Ctl.BaseLabelGray();
            this.lblDspChubunrui = new KATO.Common.Ctl.BaseLabelGray();
            this.lblDspMaker = new KATO.Common.Ctl.BaseLabelGray();
            this.lblDspTanaban = new KATO.Common.Ctl.BaseLabelGray();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel3 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel4 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel5 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel6 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.dgvRireki = new KATO.Common.Ctl.BaseDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.baseLabel10 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnViewGrid = new KATO.Common.Ctl.BaseButton();
            this.lblRecords = new KATO.Common.Ctl.BaseLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDspTanabanEdit = new KATO.Common.Ctl.BaseLabelGray();
            this.lblDspMakerEdit = new KATO.Common.Ctl.BaseLabelGray();
            this.lblDspChubunEdit = new KATO.Common.Ctl.BaseLabelGray();
            this.lblDspShouhin = new KATO.Common.Ctl.BaseLabelGray();
            this.txtTanabanEdit = new KATO.Common.Ctl.BaseText();
            this.txtTyoubosuu = new KATO.Common.Ctl.BaseText();
            this.txtTanasuu = new KATO.Common.Ctl.BaseText();
            this.txtMakerEdit = new KATO.Common.Ctl.BaseText();
            this.txtChubunruiEdit = new KATO.Common.Ctl.BaseText();
            this.txtKensaku = new KATO.Common.Ctl.BaseText();
            this.baseLabel9 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel13 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel15 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel12 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel14 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel11 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel8 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtShouhinCD = new KATO.Common.Ctl.BaseText();
            this.baseLabel7 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtYMD = new KATO.Common.Ctl.Calendar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRireki)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnF12
            // 
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
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
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // txtEigyousyo
            // 
            this.txtEigyousyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtEigyousyo.Location = new System.Drawing.Point(114, 60);
            this.txtEigyousyo.MaxLength = 4;
            this.txtEigyousyo.Name = "txtEigyousyo";
            this.txtEigyousyo.Size = new System.Drawing.Size(57, 22);
            this.txtEigyousyo.TabIndex = 1;
            this.txtEigyousyo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judEigyousyoKeyDown);
            this.txtEigyousyo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judEigyousyoKeyUp);
            this.txtEigyousyo.Leave += new System.EventHandler(this.judEigyousyoLeave);
            // 
            // txtDaibunrui
            // 
            this.txtDaibunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDaibunrui.Location = new System.Drawing.Point(114, 88);
            this.txtDaibunrui.MaxLength = 2;
            this.txtDaibunrui.Name = "txtDaibunrui";
            this.txtDaibunrui.Size = new System.Drawing.Size(32, 22);
            this.txtDaibunrui.TabIndex = 2;
            this.txtDaibunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaibunruiKeyDown);
            this.txtDaibunrui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judDaibunruiKeyUp);
            this.txtDaibunrui.Leave += new System.EventHandler(this.judDaibunruiLieave);
            // 
            // txtChubunrui
            // 
            this.txtChubunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtChubunrui.Location = new System.Drawing.Point(114, 116);
            this.txtChubunrui.MaxLength = 2;
            this.txtChubunrui.Name = "txtChubunrui";
            this.txtChubunrui.Size = new System.Drawing.Size(32, 22);
            this.txtChubunrui.TabIndex = 3;
            this.txtChubunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChubunruiKeyDown);
            this.txtChubunrui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judChubunruiKeyUp);
            this.txtChubunrui.Leave += new System.EventHandler(this.judCyubunruiLieave);
            // 
            // txtMaker
            // 
            this.txtMaker.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtMaker.Location = new System.Drawing.Point(114, 144);
            this.txtMaker.MaxLength = 3;
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(48, 22);
            this.txtMaker.TabIndex = 4;
            this.txtMaker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judMakerKeyDown);
            this.txtMaker.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judMakerKeyUp);
            this.txtMaker.Leave += new System.EventHandler(this.judMakerLieave);
            // 
            // txtTanaban
            // 
            this.txtTanaban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanaban.Location = new System.Drawing.Point(114, 172);
            this.txtTanaban.MaxLength = 6;
            this.txtTanaban.Name = "txtTanaban";
            this.txtTanaban.Size = new System.Drawing.Size(70, 22);
            this.txtTanaban.TabIndex = 5;
            this.txtTanaban.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTanabanKeyDown);
            this.txtTanaban.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judTanabanKeyUp);
            this.txtTanaban.Leave += new System.EventHandler(this.judTanabanLieave);
            // 
            // lblDspEigyousyo
            // 
            this.lblDspEigyousyo.AutoEllipsis = true;
            this.lblDspEigyousyo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspEigyousyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspEigyousyo.ForeColor = System.Drawing.Color.Blue;
            this.lblDspEigyousyo.Location = new System.Drawing.Point(177, 60);
            this.lblDspEigyousyo.Name = "lblDspEigyousyo";
            this.lblDspEigyousyo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspEigyousyo.Size = new System.Drawing.Size(139, 23);
            this.lblDspEigyousyo.TabIndex = 89;
            this.lblDspEigyousyo.Text = " ";
            this.lblDspEigyousyo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDspDaibunrui
            // 
            this.lblDspDaibunrui.AutoEllipsis = true;
            this.lblDspDaibunrui.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspDaibunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspDaibunrui.ForeColor = System.Drawing.Color.Blue;
            this.lblDspDaibunrui.Location = new System.Drawing.Point(155, 88);
            this.lblDspDaibunrui.Name = "lblDspDaibunrui";
            this.lblDspDaibunrui.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspDaibunrui.Size = new System.Drawing.Size(161, 23);
            this.lblDspDaibunrui.TabIndex = 89;
            this.lblDspDaibunrui.Text = " ";
            this.lblDspDaibunrui.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDspChubunrui
            // 
            this.lblDspChubunrui.AutoEllipsis = true;
            this.lblDspChubunrui.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspChubunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspChubunrui.ForeColor = System.Drawing.Color.Blue;
            this.lblDspChubunrui.Location = new System.Drawing.Point(152, 116);
            this.lblDspChubunrui.Name = "lblDspChubunrui";
            this.lblDspChubunrui.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspChubunrui.Size = new System.Drawing.Size(164, 23);
            this.lblDspChubunrui.TabIndex = 89;
            this.lblDspChubunrui.Text = " ";
            this.lblDspChubunrui.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDspMaker
            // 
            this.lblDspMaker.AutoEllipsis = true;
            this.lblDspMaker.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspMaker.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspMaker.ForeColor = System.Drawing.Color.Blue;
            this.lblDspMaker.Location = new System.Drawing.Point(177, 143);
            this.lblDspMaker.Name = "lblDspMaker";
            this.lblDspMaker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspMaker.Size = new System.Drawing.Size(139, 23);
            this.lblDspMaker.TabIndex = 89;
            this.lblDspMaker.Text = " ";
            this.lblDspMaker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDspTanaban
            // 
            this.lblDspTanaban.AutoEllipsis = true;
            this.lblDspTanaban.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspTanaban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspTanaban.ForeColor = System.Drawing.Color.Blue;
            this.lblDspTanaban.Location = new System.Drawing.Point(190, 172);
            this.lblDspTanaban.Name = "lblDspTanaban";
            this.lblDspTanaban.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspTanaban.Size = new System.Drawing.Size(126, 23);
            this.lblDspTanaban.TabIndex = 89;
            this.lblDspTanaban.Text = " ";
            this.lblDspTanaban.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(9, 35);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(87, 15);
            this.baseLabel1.TabIndex = 90;
            this.baseLabel1.Text = "棚卸年月日";
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(9, 64);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(103, 15);
            this.baseLabel2.TabIndex = 90;
            this.baseLabel2.Text = "営業所コード";
            // 
            // baseLabel3
            // 
            this.baseLabel3.AutoSize = true;
            this.baseLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel3.Location = new System.Drawing.Point(9, 92);
            this.baseLabel3.Name = "baseLabel3";
            this.baseLabel3.Size = new System.Drawing.Size(103, 15);
            this.baseLabel3.TabIndex = 90;
            this.baseLabel3.Text = "大分類コード";
            // 
            // baseLabel4
            // 
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel4.Location = new System.Drawing.Point(9, 120);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(103, 15);
            this.baseLabel4.TabIndex = 90;
            this.baseLabel4.Text = "中分類コード";
            // 
            // baseLabel5
            // 
            this.baseLabel5.AutoSize = true;
            this.baseLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel5.Location = new System.Drawing.Point(9, 147);
            this.baseLabel5.Name = "baseLabel5";
            this.baseLabel5.Size = new System.Drawing.Size(71, 15);
            this.baseLabel5.TabIndex = 90;
            this.baseLabel5.Text = "メーカー";
            // 
            // baseLabel6
            // 
            this.baseLabel6.AutoSize = true;
            this.baseLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel6.Location = new System.Drawing.Point(9, 175);
            this.baseLabel6.Name = "baseLabel6";
            this.baseLabel6.Size = new System.Drawing.Size(39, 15);
            this.baseLabel6.TabIndex = 90;
            this.baseLabel6.Text = "棚番";
            // 
            // dgvRireki
            // 
            this.dgvRireki.AllowUserToAddRows = false;
            this.dgvRireki.AllowUserToResizeColumns = false;
            this.dgvRireki.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRireki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRireki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRireki.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRireki.EnableHeadersVisualStyles = false;
            this.dgvRireki.Location = new System.Drawing.Point(332, 35);
            this.dgvRireki.Name = "dgvRireki";
            this.dgvRireki.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRireki.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRireki.RowHeadersVisible = false;
            this.dgvRireki.RowTemplate.Height = 21;
            this.dgvRireki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRireki.Size = new System.Drawing.Size(1080, 631);
            this.dgvRireki.StandardTab = true;
            this.dgvRireki.TabIndex = 7;
            this.dgvRireki.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.setdgvSeihinDoubleClick);
            this.dgvRireki.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.judDGVCellChanged);
            this.dgvRireki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judRirekiKeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.baseLabel10);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 152);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出力順の選択";
            // 
            // baseLabel10
            // 
            this.baseLabel10.AutoSize = true;
            this.baseLabel10.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel10.Location = new System.Drawing.Point(63, 662);
            this.baseLabel10.Name = "baseLabel10";
            this.baseLabel10.Size = new System.Drawing.Size(87, 15);
            this.baseLabel10.TabIndex = 0;
            this.baseLabel10.Text = "検索文字列";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(13, 116);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(153, 19);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "棚番・品名の昇順";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(13, 87);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(233, 19);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "棚番・メーカー・品名の昇順";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 59);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(185, 19);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "メーカー・品名の昇順";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 29);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(105, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "品名の昇順";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnViewGrid
            // 
            this.btnViewGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnViewGrid.Location = new System.Drawing.Point(32, 405);
            this.btnViewGrid.Name = "btnViewGrid";
            this.btnViewGrid.Size = new System.Drawing.Size(100, 23);
            this.btnViewGrid.TabIndex = 6;
            this.btnViewGrid.Text = "検索表示";
            this.btnViewGrid.UseVisualStyleBackColor = true;
            this.btnViewGrid.Click += new System.EventHandler(this.btnView);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblRecords.Location = new System.Drawing.Point(138, 409);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(87, 15);
            this.lblRecords.TabIndex = 94;
            this.lblRecords.Text = "該当件数：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDspTanabanEdit);
            this.groupBox2.Controls.Add(this.lblDspMakerEdit);
            this.groupBox2.Controls.Add(this.lblDspChubunEdit);
            this.groupBox2.Controls.Add(this.lblDspShouhin);
            this.groupBox2.Controls.Add(this.txtTanabanEdit);
            this.groupBox2.Controls.Add(this.txtTyoubosuu);
            this.groupBox2.Controls.Add(this.txtTanasuu);
            this.groupBox2.Controls.Add(this.txtMakerEdit);
            this.groupBox2.Controls.Add(this.txtChubunruiEdit);
            this.groupBox2.Controls.Add(this.txtKensaku);
            this.groupBox2.Controls.Add(this.baseLabel9);
            this.groupBox2.Controls.Add(this.baseLabel13);
            this.groupBox2.Controls.Add(this.baseLabel15);
            this.groupBox2.Controls.Add(this.baseLabel12);
            this.groupBox2.Controls.Add(this.baseLabel14);
            this.groupBox2.Controls.Add(this.baseLabel11);
            this.groupBox2.Controls.Add(this.baseLabel8);
            this.groupBox2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.groupBox2.Location = new System.Drawing.Point(10, 661);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1402, 116);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "";
            this.groupBox2.Text = "新規に入力";
            // 
            // lblDspTanabanEdit
            // 
            this.lblDspTanabanEdit.AutoEllipsis = true;
            this.lblDspTanabanEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspTanabanEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspTanabanEdit.ForeColor = System.Drawing.Color.Blue;
            this.lblDspTanabanEdit.Location = new System.Drawing.Point(1230, 55);
            this.lblDspTanabanEdit.Name = "lblDspTanabanEdit";
            this.lblDspTanabanEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspTanabanEdit.Size = new System.Drawing.Size(136, 23);
            this.lblDspTanabanEdit.TabIndex = 96;
            this.lblDspTanabanEdit.Text = " ";
            this.lblDspTanabanEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDspTanabanEdit.Leave += new System.EventHandler(this.txtTanabanEditLieave);
            // 
            // lblDspMakerEdit
            // 
            this.lblDspMakerEdit.AutoEllipsis = true;
            this.lblDspMakerEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspMakerEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspMakerEdit.ForeColor = System.Drawing.Color.Blue;
            this.lblDspMakerEdit.Location = new System.Drawing.Point(1192, 26);
            this.lblDspMakerEdit.Name = "lblDspMakerEdit";
            this.lblDspMakerEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspMakerEdit.Size = new System.Drawing.Size(174, 23);
            this.lblDspMakerEdit.TabIndex = 96;
            this.lblDspMakerEdit.Text = " ";
            this.lblDspMakerEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDspMakerEdit.Leave += new System.EventHandler(this.judMakerEditLieave);
            // 
            // lblDspChubunEdit
            // 
            this.lblDspChubunEdit.AutoEllipsis = true;
            this.lblDspChubunEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspChubunEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspChubunEdit.ForeColor = System.Drawing.Color.Blue;
            this.lblDspChubunEdit.Location = new System.Drawing.Point(744, 27);
            this.lblDspChubunEdit.Name = "lblDspChubunEdit";
            this.lblDspChubunEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspChubunEdit.Size = new System.Drawing.Size(184, 23);
            this.lblDspChubunEdit.TabIndex = 96;
            this.lblDspChubunEdit.Text = " ";
            this.lblDspChubunEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDspShouhin
            // 
            this.lblDspShouhin.AutoEllipsis = true;
            this.lblDspShouhin.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspShouhin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspShouhin.ForeColor = System.Drawing.Color.Blue;
            this.lblDspShouhin.Location = new System.Drawing.Point(121, 55);
            this.lblDspShouhin.Name = "lblDspShouhin";
            this.lblDspShouhin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspShouhin.Size = new System.Drawing.Size(341, 23);
            this.lblDspShouhin.TabIndex = 96;
            this.lblDspShouhin.Text = " ";
            this.lblDspShouhin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTanabanEdit
            // 
            this.txtTanabanEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanabanEdit.Location = new System.Drawing.Point(1155, 56);
            this.txtTanabanEdit.Name = "txtTanabanEdit";
            this.txtTanabanEdit.Size = new System.Drawing.Size(69, 22);
            this.txtTanabanEdit.TabIndex = 2;
            this.txtTanabanEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTanaEditKeyDown);
            this.txtTanabanEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judTanabanEditKeyUp);
            this.txtTanabanEdit.Leave += new System.EventHandler(this.txtTanabanEditLieave);
            // 
            // txtTyoubosuu
            // 
            this.txtTyoubosuu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTyoubosuu.Location = new System.Drawing.Point(765, 84);
            this.txtTyoubosuu.Name = "txtTyoubosuu";
            this.txtTyoubosuu.Size = new System.Drawing.Size(163, 22);
            this.txtTyoubosuu.TabIndex = 1;
            // 
            // txtTanasuu
            // 
            this.txtTanasuu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanasuu.Location = new System.Drawing.Point(765, 56);
            this.txtTanasuu.Name = "txtTanasuu";
            this.txtTanasuu.Size = new System.Drawing.Size(163, 22);
            this.txtTanasuu.TabIndex = 1;
            // 
            // txtMakerEdit
            // 
            this.txtMakerEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtMakerEdit.Location = new System.Drawing.Point(1155, 27);
            this.txtMakerEdit.Name = "txtMakerEdit";
            this.txtMakerEdit.Size = new System.Drawing.Size(31, 22);
            this.txtMakerEdit.TabIndex = 86;
            this.txtMakerEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judMakerEditKeyDown);
            this.txtMakerEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judMakerEditKeyUp);
            this.txtMakerEdit.Leave += new System.EventHandler(this.judMakerEditLieave);
            // 
            // txtChubunruiEdit
            // 
            this.txtChubunruiEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtChubunruiEdit.Location = new System.Drawing.Point(707, 27);
            this.txtChubunruiEdit.Name = "txtChubunruiEdit";
            this.txtChubunruiEdit.Size = new System.Drawing.Size(31, 22);
            this.txtChubunruiEdit.TabIndex = 85;
            this.txtChubunruiEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChubunEditKeyDown);
            this.txtChubunruiEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judChubunruiEditKeyUp);
            this.txtChubunruiEdit.Leave += new System.EventHandler(this.judCyubunruiEditLieave);
            // 
            // txtKensaku
            // 
            this.txtKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensaku.Location = new System.Drawing.Point(120, 27);
            this.txtKensaku.Name = "txtKensaku";
            this.txtKensaku.Size = new System.Drawing.Size(186, 22);
            this.txtKensaku.TabIndex = 0;
            this.txtKensaku.Leave += new System.EventHandler(this.txtKensakuLeave);
            // 
            // baseLabel9
            // 
            this.baseLabel9.AutoSize = true;
            this.baseLabel9.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel9.Location = new System.Drawing.Point(19, 59);
            this.baseLabel9.Name = "baseLabel9";
            this.baseLabel9.Size = new System.Drawing.Size(87, 15);
            this.baseLabel9.TabIndex = 0;
            this.baseLabel9.Text = "品名・型番";
            // 
            // baseLabel13
            // 
            this.baseLabel13.AutoSize = true;
            this.baseLabel13.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel13.Location = new System.Drawing.Point(672, 87);
            this.baseLabel13.Name = "baseLabel13";
            this.baseLabel13.Size = new System.Drawing.Size(87, 15);
            this.baseLabel13.TabIndex = 0;
            this.baseLabel13.Text = "帳簿在庫数";
            // 
            // baseLabel15
            // 
            this.baseLabel15.AutoSize = true;
            this.baseLabel15.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel15.Location = new System.Drawing.Point(1078, 59);
            this.baseLabel15.Name = "baseLabel15";
            this.baseLabel15.Size = new System.Drawing.Size(39, 15);
            this.baseLabel15.TabIndex = 0;
            this.baseLabel15.Text = "棚番";
            // 
            // baseLabel12
            // 
            this.baseLabel12.AutoSize = true;
            this.baseLabel12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel12.Location = new System.Drawing.Point(672, 59);
            this.baseLabel12.Name = "baseLabel12";
            this.baseLabel12.Size = new System.Drawing.Size(55, 15);
            this.baseLabel12.TabIndex = 0;
            this.baseLabel12.Text = "棚卸数";
            // 
            // baseLabel14
            // 
            this.baseLabel14.AutoSize = true;
            this.baseLabel14.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel14.Location = new System.Drawing.Point(1062, 30);
            this.baseLabel14.Name = "baseLabel14";
            this.baseLabel14.Size = new System.Drawing.Size(71, 15);
            this.baseLabel14.TabIndex = 0;
            this.baseLabel14.Text = "メーカー";
            // 
            // baseLabel11
            // 
            this.baseLabel11.AutoSize = true;
            this.baseLabel11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel11.Location = new System.Drawing.Point(605, 30);
            this.baseLabel11.Name = "baseLabel11";
            this.baseLabel11.Size = new System.Drawing.Size(103, 15);
            this.baseLabel11.TabIndex = 0;
            this.baseLabel11.Text = "中分類コード";
            // 
            // baseLabel8
            // 
            this.baseLabel8.AutoSize = true;
            this.baseLabel8.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel8.Location = new System.Drawing.Point(19, 30);
            this.baseLabel8.Name = "baseLabel8";
            this.baseLabel8.Size = new System.Drawing.Size(87, 15);
            this.baseLabel8.TabIndex = 0;
            this.baseLabel8.Text = "検索文字列";
            // 
            // txtShouhinCD
            // 
            this.txtShouhinCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShouhinCD.Location = new System.Drawing.Point(114, 539);
            this.txtShouhinCD.Name = "txtShouhinCD";
            this.txtShouhinCD.Size = new System.Drawing.Size(81, 22);
            this.txtShouhinCD.TabIndex = 1;
            this.txtShouhinCD.Visible = false;
            this.txtShouhinCD.Leave += new System.EventHandler(this.txtKensakuLeave);
            // 
            // baseLabel7
            // 
            this.baseLabel7.AutoSize = true;
            this.baseLabel7.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel7.Location = new System.Drawing.Point(25, 542);
            this.baseLabel7.Name = "baseLabel7";
            this.baseLabel7.Size = new System.Drawing.Size(87, 15);
            this.baseLabel7.TabIndex = 94;
            this.baseLabel7.Text = "商品コード";
            this.baseLabel7.Visible = false;
            // 
            // txtYMD
            // 
            this.txtYMD.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.txtYMD.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYMD.FocusedBackColor = System.Drawing.SystemColors.Window;
            this.txtYMD.FocusedForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYMD.ImeMode = true;
            this.txtYMD.Location = new System.Drawing.Point(114, 31);
            this.txtYMD.Name = "txtYMD";
            this.txtYMD.Size = new System.Drawing.Size(96, 22);
            this.txtYMD.TabIndex = 97;
            this.txtYMD.Text = "2017/03/27";
            this.txtYMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TanaorosiInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 831);
            this.Controls.Add(this.txtYMD);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.baseLabel7);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnViewGrid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvRireki);
            this.Controls.Add(this.baseLabel6);
            this.Controls.Add(this.baseLabel5);
            this.Controls.Add(this.baseLabel4);
            this.Controls.Add(this.baseLabel3);
            this.Controls.Add(this.txtShouhinCD);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.lblDspTanaban);
            this.Controls.Add(this.lblDspMaker);
            this.Controls.Add(this.lblDspChubunrui);
            this.Controls.Add(this.lblDspDaibunrui);
            this.Controls.Add(this.lblDspEigyousyo);
            this.Controls.Add(this.txtTanaban);
            this.Controls.Add(this.txtMaker);
            this.Controls.Add(this.txtChubunrui);
            this.Controls.Add(this.txtDaibunrui);
            this.Controls.Add(this.txtEigyousyo);
            this.Name = "TanaorosiInput";
            this.Text = "TanaorosiInput";
            this.Load += new System.EventHandler(this.TanaorosiInput_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTanaorosiKeyDown);
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
            this.Controls.SetChildIndex(this.txtEigyousyo, 0);
            this.Controls.SetChildIndex(this.txtDaibunrui, 0);
            this.Controls.SetChildIndex(this.txtChubunrui, 0);
            this.Controls.SetChildIndex(this.txtMaker, 0);
            this.Controls.SetChildIndex(this.txtTanaban, 0);
            this.Controls.SetChildIndex(this.lblDspEigyousyo, 0);
            this.Controls.SetChildIndex(this.lblDspDaibunrui, 0);
            this.Controls.SetChildIndex(this.lblDspChubunrui, 0);
            this.Controls.SetChildIndex(this.lblDspMaker, 0);
            this.Controls.SetChildIndex(this.lblDspTanaban, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.baseLabel2, 0);
            this.Controls.SetChildIndex(this.txtShouhinCD, 0);
            this.Controls.SetChildIndex(this.baseLabel3, 0);
            this.Controls.SetChildIndex(this.baseLabel4, 0);
            this.Controls.SetChildIndex(this.baseLabel5, 0);
            this.Controls.SetChildIndex(this.baseLabel6, 0);
            this.Controls.SetChildIndex(this.dgvRireki, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnViewGrid, 0);
            this.Controls.SetChildIndex(this.lblRecords, 0);
            this.Controls.SetChildIndex(this.baseLabel7, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txtYMD, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRireki)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BaseText txtEigyousyo;
        private BaseText txtDaibunrui;
        private BaseText txtChubunrui;
        private BaseText txtMaker;
        private BaseText txtTanaban;
        private BaseLabelGray lblDspEigyousyo;
        private BaseLabelGray lblDspDaibunrui;
        private BaseLabelGray lblDspChubunrui;
        private BaseLabelGray lblDspMaker;
        private BaseLabelGray lblDspTanaban;
        private BaseLabel baseLabel1;
        private BaseLabel baseLabel2;
        private BaseLabel baseLabel3;
        private BaseLabel baseLabel4;
        private BaseLabel baseLabel5;
        private BaseLabel baseLabel6;
        private BaseDataGridView dgvRireki;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private BaseButton btnViewGrid;
        private BaseLabel lblRecords;
        private System.Windows.Forms.GroupBox groupBox2;
        private BaseLabel baseLabel10;
        private BaseText txtKensaku;
        private BaseLabel baseLabel9;
        private BaseLabel baseLabel8;
        private BaseLabelGray lblDspShouhin;
        private BaseLabel baseLabel11;
        private BaseLabelGray lblDspChubunEdit;
        private BaseText txtChubunruiEdit;
        private BaseLabel baseLabel13;
        private BaseLabel baseLabel12;
        private BaseLabelGray lblDspTanabanEdit;
        private BaseLabelGray lblDspMakerEdit;
        private BaseText txtTanabanEdit;
        private BaseText txtTyoubosuu;
        private BaseText txtTanasuu;
        private BaseText txtMakerEdit;
        private BaseLabel baseLabel15;
        private BaseLabel baseLabel14;
        private BaseText txtShouhinCD;
        private BaseLabel baseLabel7;
        private Calendar txtYMD;
    }
}