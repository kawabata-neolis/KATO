namespace KATO.Form.A0010_JuchuInput
{
    partial class Form6
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.gridZaiko = new KATO.Common.Ctl.BaseDataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSearchStr = new KATO.Common.Ctl.BaseText();
            this.label20 = new System.Windows.Forms.Label();
            this.txtHinmei = new KATO.Common.Ctl.BaseText();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.txtJuchuYMD = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lsDaibunruiM = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.nameLabel = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lsChubunruiM = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.object_cb750ffa_609a_4cea_a625_b693587a1341 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lsMakerM = new KATO.Common.Ctl.LabelSet_Maker();
            this.object_673b3833_2995_43df_b2c7_78bfee9dd2c6 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtShohinCd = new KATO.Common.Ctl.BaseText();
            this.txtOldStr = new KATO.Common.Ctl.BaseText();
            ((System.ComponentModel.ISupportInitialize)(this.gridZaiko)).BeginInit();
            this.lsDaibunruiM.SuspendLayout();
            this.lsChubunruiM.SuspendLayout();
            this.lsMakerM.SuspendLayout();
            this.SuspendLayout();
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label24.Location = new System.Drawing.Point(495, 113);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 30);
            this.label24.TabIndex = 123;
            this.label24.Text = "ﾌﾘｰ在庫\r\n合計";
            // 
            // textBox28
            // 
            this.textBox28.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox28.Location = new System.Drawing.Point(495, 146);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(63, 22);
            this.textBox28.TabIndex = 10;
            this.textBox28.Text = "0.00";
            this.textBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gridZaiko
            // 
            this.gridZaiko.AllowUserToAddRows = false;
            this.gridZaiko.AllowUserToResizeColumns = false;
            this.gridZaiko.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gridZaiko.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridZaiko.AutoGenerateColumns = false;
            this.gridZaiko.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.gridZaiko.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridZaiko.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridZaiko.ColumnHeadersHeight = 19;
            this.gridZaiko.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridZaiko.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridZaiko.EnableHeadersVisualStyles = false;
            this.gridZaiko.Location = new System.Drawing.Point(53, 115);
            this.gridZaiko.Name = "gridZaiko";
            this.gridZaiko.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridZaiko.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridZaiko.RowHeadersVisible = false;
            this.gridZaiko.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gridZaiko.RowTemplate.Height = 21;
            this.gridZaiko.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridZaiko.Size = new System.Drawing.Size(432, 63);
            this.gridZaiko.StandardTab = true;
            this.gridZaiko.TabIndex = 121;
            this.gridZaiko.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(12, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 94;
            this.label7.Text = "今回依頼内容";
            // 
            // txtSearchStr
            // 
            this.txtSearchStr.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSearchStr.Location = new System.Drawing.Point(877, 59);
            this.txtSearchStr.Name = "txtSearchStr";
            this.txtSearchStr.Size = new System.Drawing.Size(271, 22);
            this.txtSearchStr.TabIndex = 4;
            this.txtSearchStr.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label20.Location = new System.Drawing.Point(66, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 15);
            this.label20.TabIndex = 228;
            this.label20.Text = "品名";
            // 
            // txtHinmei
            // 
            this.txtHinmei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtHinmei.Location = new System.Drawing.Point(111, 87);
            this.txtHinmei.Name = "txtHinmei";
            this.txtHinmei.Size = new System.Drawing.Size(331, 22);
            this.txtHinmei.TabIndex = 7;
            this.txtHinmei.Visible = false;
            // 
            // textBox32
            // 
            this.textBox32.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox32.Location = new System.Drawing.Point(448, 87);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(169, 22);
            this.textBox32.TabIndex = 8;
            this.textBox32.Visible = false;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button13.Location = new System.Drawing.Point(285, 30);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(100, 23);
            this.button13.TabIndex = 10;
            this.button13.Text = "発注";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button14.Location = new System.Drawing.Point(403, 30);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(100, 23);
            this.button14.TabIndex = 11;
            this.button14.Text = "出庫";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button15.Location = new System.Drawing.Point(639, 30);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(100, 23);
            this.button15.TabIndex = 13;
            this.button15.Text = "加工品出庫";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button16.Location = new System.Drawing.Point(521, 30);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(100, 23);
            this.button16.TabIndex = 12;
            this.button16.Text = "本加工";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // txtJuchuYMD
            // 
            this.txtJuchuYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtJuchuYMD.Location = new System.Drawing.Point(111, 31);
            this.txtJuchuYMD.Name = "txtJuchuYMD";
            this.txtJuchuYMD.Size = new System.Drawing.Size(85, 22);
            this.txtJuchuYMD.TabIndex = 0;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label27.Location = new System.Drawing.Point(50, 34);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 15);
            this.label27.TabIndex = 247;
            this.label27.Text = "年月日";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(784, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 278;
            this.label5.Text = "検索文字列";
            this.label5.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 184);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1424, 599);
            this.tableLayoutPanel1.TabIndex = 279;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox1.Location = new System.Drawing.Point(634, 89);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(154, 19);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "入力内容をを転記";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // lsDaibunruiM
            // 
            this.lsDaibunruiM.AppendLabelSize = 0;
            this.lsDaibunruiM.AppendLabelText = "";
            this.lsDaibunruiM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lsDaibunruiM.CodeTxtSize = 30;
            this.lsDaibunruiM.CodeTxtText = "";
            this.lsDaibunruiM.Controls.Add(this.nameLabel);
            this.lsDaibunruiM.LabelName = "大分類";
            this.lsDaibunruiM.Location = new System.Drawing.Point(49, 59);
            this.lsDaibunruiM.Lschubundata = null;
            this.lsDaibunruiM.Lsmakerdata = null;
            this.lsDaibunruiM.LsSubchubundata = null;
            this.lsDaibunruiM.LsSubmakerdata = null;
            this.lsDaibunruiM.Name = "lsDaibunruiM";
            this.lsDaibunruiM.ShowAppendFlg = false;
            this.lsDaibunruiM.Size = new System.Drawing.Size(255, 22);
            this.lsDaibunruiM.SpaceCodeValue = 7;
            this.lsDaibunruiM.SpaceNameCode = 7;
            this.lsDaibunruiM.SpaceValueAppend = 4;
            this.lsDaibunruiM.TabIndex = 88;
            this.lsDaibunruiM.ValueLabelSize = 129;
            this.lsDaibunruiM.ValueLabelText = "";
            this.lsDaibunruiM.Visible = false;
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
            this.nameLabel.Text = "大分類";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lsChubunruiM
            // 
            this.lsChubunruiM.AppendLabelSize = 0;
            this.lsChubunruiM.AppendLabelText = "";
            this.lsChubunruiM.CodeTxtSize = 30;
            this.lsChubunruiM.CodeTxtText = "";
            this.lsChubunruiM.Controls.Add(this.object_cb750ffa_609a_4cea_a625_b693587a1341);
            this.lsChubunruiM.LabelName = "中分類";
            this.lsChubunruiM.Location = new System.Drawing.Point(286, 59);
            this.lsChubunruiM.Name = "lsChubunruiM";
            this.lsChubunruiM.ShowAppendFlg = false;
            this.lsChubunruiM.Size = new System.Drawing.Size(255, 22);
            this.lsChubunruiM.SpaceCodeValue = 7;
            this.lsChubunruiM.SpaceNameCode = 7;
            this.lsChubunruiM.SpaceValueAppend = 4;
            this.lsChubunruiM.strDaibunCd = null;
            this.lsChubunruiM.TabIndex = 2147483647;
            this.lsChubunruiM.ValueLabelSize = 129;
            this.lsChubunruiM.ValueLabelText = "";
            this.lsChubunruiM.Visible = false;
            // 
            // object_cb750ffa_609a_4cea_a625_b693587a1341
            // 
            this.object_cb750ffa_609a_4cea_a625_b693587a1341.AutoSize = true;
            this.object_cb750ffa_609a_4cea_a625_b693587a1341.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_cb750ffa_609a_4cea_a625_b693587a1341.Location = new System.Drawing.Point(2, 3);
            this.object_cb750ffa_609a_4cea_a625_b693587a1341.Name = "object_cb750ffa_609a_4cea_a625_b693587a1341";
            this.object_cb750ffa_609a_4cea_a625_b693587a1341.Size = new System.Drawing.Size(55, 15);
            this.object_cb750ffa_609a_4cea_a625_b693587a1341.strToolTip = null;
            this.object_cb750ffa_609a_4cea_a625_b693587a1341.TabIndex = 0;
            this.object_cb750ffa_609a_4cea_a625_b693587a1341.Text = "中分類";
            this.object_cb750ffa_609a_4cea_a625_b693587a1341.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lsMakerM
            // 
            this.lsMakerM.AppendLabelSize = 0;
            this.lsMakerM.AppendLabelText = "";
            this.lsMakerM.CodeTxtSize = 38;
            this.lsMakerM.CodeTxtText = "";
            this.lsMakerM.Controls.Add(this.object_673b3833_2995_43df_b2c7_78bfee9dd2c6);
            this.lsMakerM.LabelName = "メーカー";
            this.lsMakerM.Location = new System.Drawing.Point(523, 59);
            this.lsMakerM.Name = "lsMakerM";
            this.lsMakerM.ShowAppendFlg = false;
            this.lsMakerM.Size = new System.Drawing.Size(255, 22);
            this.lsMakerM.SpaceCodeValue = 7;
            this.lsMakerM.SpaceNameCode = 7;
            this.lsMakerM.SpaceValueAppend = 4;
            this.lsMakerM.strDaibunCd = null;
            this.lsMakerM.TabIndex = 2147483647;
            this.lsMakerM.ValueLabelSize = 129;
            this.lsMakerM.ValueLabelText = "";
            this.lsMakerM.Visible = false;
            // 
            // object_673b3833_2995_43df_b2c7_78bfee9dd2c6
            // 
            this.object_673b3833_2995_43df_b2c7_78bfee9dd2c6.AutoSize = true;
            this.object_673b3833_2995_43df_b2c7_78bfee9dd2c6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_673b3833_2995_43df_b2c7_78bfee9dd2c6.Location = new System.Drawing.Point(2, 3);
            this.object_673b3833_2995_43df_b2c7_78bfee9dd2c6.Name = "object_673b3833_2995_43df_b2c7_78bfee9dd2c6";
            this.object_673b3833_2995_43df_b2c7_78bfee9dd2c6.Size = new System.Drawing.Size(71, 15);
            this.object_673b3833_2995_43df_b2c7_78bfee9dd2c6.strToolTip = null;
            this.object_673b3833_2995_43df_b2c7_78bfee9dd2c6.TabIndex = 0;
            this.object_673b3833_2995_43df_b2c7_78bfee9dd2c6.Text = "メーカー";
            this.object_673b3833_2995_43df_b2c7_78bfee9dd2c6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtShohinCd
            // 
            this.txtShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShohinCd.Location = new System.Drawing.Point(654, 146);
            this.txtShohinCd.Name = "txtShohinCd";
            this.txtShohinCd.Size = new System.Drawing.Size(100, 22);
            this.txtShohinCd.TabIndex = 2147483647;
            this.txtShohinCd.Visible = false;
            this.txtShohinCd.TextChanged += new System.EventHandler(this.shohinChange);
            // 
            // txtOldStr
            // 
            this.txtOldStr.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtOldStr.Location = new System.Drawing.Point(787, 146);
            this.txtOldStr.Name = "txtOldStr";
            this.txtOldStr.Size = new System.Drawing.Size(100, 22);
            this.txtOldStr.TabIndex = 280;
            this.txtOldStr.Visible = false;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 838);
            this.Controls.Add(this.txtOldStr);
            this.Controls.Add(this.txtShohinCd);
            this.Controls.Add(this.lsMakerM);
            this.Controls.Add(this.lsChubunruiM);
            this.Controls.Add(this.lsDaibunruiM);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtJuchuYMD);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.textBox32);
            this.Controls.Add(this.txtHinmei);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtSearchStr);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBox28);
            this.Controls.Add(this.gridZaiko);
            this.Controls.Add(this.label7);
            this.KeyPreview = true;
            this.Name = "Form6";
            this.Text = "販売管理 - [加工品受注入力]";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form6_KeyDown);
            this.Controls.SetChildIndex(this.cmbSubWinShow, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.gridZaiko, 0);
            this.Controls.SetChildIndex(this.textBox28, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.txtSearchStr, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.txtHinmei, 0);
            this.Controls.SetChildIndex(this.textBox32, 0);
            this.Controls.SetChildIndex(this.button13, 0);
            this.Controls.SetChildIndex(this.button14, 0);
            this.Controls.SetChildIndex(this.button16, 0);
            this.Controls.SetChildIndex(this.button15, 0);
            this.Controls.SetChildIndex(this.label27, 0);
            this.Controls.SetChildIndex(this.txtJuchuYMD, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
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
            this.Controls.SetChildIndex(this.lsDaibunruiM, 0);
            this.Controls.SetChildIndex(this.lsChubunruiM, 0);
            this.Controls.SetChildIndex(this.lsMakerM, 0);
            this.Controls.SetChildIndex(this.txtShohinCd, 0);
            this.Controls.SetChildIndex(this.txtOldStr, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridZaiko)).EndInit();
            this.lsDaibunruiM.ResumeLayout(false);
            this.lsDaibunruiM.PerformLayout();
            this.lsChubunruiM.ResumeLayout(false);
            this.lsChubunruiM.PerformLayout();
            this.lsMakerM.ResumeLayout(false);
            this.lsMakerM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox28;
        private KATO.Common.Ctl.BaseDataGridView gridZaiko;
        private System.Windows.Forms.Label label7;
        private KATO.Common.Ctl.BaseText txtSearchStr;
        private System.Windows.Forms.Label label20;
        private Common.Ctl.BaseText txtHinmei;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.TextBox txtJuchuYMD;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private Common.Ctl.LabelSet_Daibunrui lsDaibunruiM;
        private Common.Ctl.BaseLabel nameLabel;
        private Common.Ctl.LabelSet_Chubunrui lsChubunruiM;
        private Common.Ctl.BaseLabel object_cb750ffa_609a_4cea_a625_b693587a1341;
        private Common.Ctl.LabelSet_Maker lsMakerM;
        private Common.Ctl.BaseLabel object_673b3833_2995_43df_b2c7_78bfee9dd2c6;
        private Common.Ctl.BaseText txtShohinCd;
        private Common.Ctl.BaseText txtOldStr;
    }
}