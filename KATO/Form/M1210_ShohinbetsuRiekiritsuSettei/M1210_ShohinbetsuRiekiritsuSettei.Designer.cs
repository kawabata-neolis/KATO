namespace KATO.Form.M1210_ShohinbetsuRiekiritsuSettei
{
    partial class M1210_ShohinbetsuRiekiritsuSettei
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSinamei_KatabanS = new KATO.Common.Ctl.BaseText();
            this.baseButton_kensaku = new KATO.Common.Ctl.BaseButton();
            this.lblKataban = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_TantoushaS = new KATO.Common.Ctl.LabelSet_Tantousha();
            this.labelSet_TokuisakiS = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.razioOrderS1 = new KATO.Common.Ctl.RadSet_4btn();
            this.gridShohinbetsuRiekiritsu = new KATO.Common.Ctl.BaseDataGridView();
            this.labelSet_Tokuisaki = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.labelSet_Daibunrui = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.labelSet_Chubunrui = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.labelSet_Maker = new KATO.Common.Ctl.LabelSet_Maker();
            this.lblShohinCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtShohinCd = new KATO.Common.Ctl.BaseText();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtKensakuS = new KATO.Common.Ctl.BaseText();
            this.txtKataban = new KATO.Common.Ctl.BaseText();
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel3 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel4 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel5 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtRiekiritsu = new KATO.Common.Ctl.BaseText();
            this.razioOrderS2 = new KATO.Common.Ctl.RadSet_2btn();
            this.razioSettei = new KATO.Common.Ctl.RadSet_2btn();
            this.txtTeika = new KATO.Common.Ctl.BaseTextMoney();
            this.txtTanka = new KATO.Common.Ctl.BaseTextMoney();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShohinbetsuRiekiritsu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF12
            // 
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF06
            // 
            this.btnF06.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSinamei_KatabanS);
            this.groupBox1.Controls.Add(this.baseButton_kensaku);
            this.groupBox1.Controls.Add(this.lblKataban);
            this.groupBox1.Controls.Add(this.labelSet_TantoushaS);
            this.groupBox1.Controls.Add(this.labelSet_TokuisakiS);
            this.groupBox1.Location = new System.Drawing.Point(29, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 151);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索条件";
            // 
            // txtSinamei_KatabanS
            // 
            this.txtSinamei_KatabanS.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtSinamei_KatabanS.Location = new System.Drawing.Point(108, 78);
            this.txtSinamei_KatabanS.MaxLength = 100;
            this.txtSinamei_KatabanS.Name = "txtSinamei_KatabanS";
            this.txtSinamei_KatabanS.Size = new System.Drawing.Size(353, 22);
            this.txtSinamei_KatabanS.TabIndex = 104;
            // 
            // baseButton_kensaku
            // 
            this.baseButton_kensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseButton_kensaku.Location = new System.Drawing.Point(399, 122);
            this.baseButton_kensaku.Name = "baseButton_kensaku";
            this.baseButton_kensaku.Size = new System.Drawing.Size(100, 23);
            this.baseButton_kensaku.TabIndex = 13;
            this.baseButton_kensaku.Text = "検索";
            this.baseButton_kensaku.UseVisualStyleBackColor = true;
            this.baseButton_kensaku.Click += new System.EventHandler(this.baseButton_kensaku_Click);
            // 
            // lblKataban
            // 
            this.lblKataban.AutoSize = true;
            this.lblKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKataban.Location = new System.Drawing.Point(15, 81);
            this.lblKataban.Name = "lblKataban";
            this.lblKataban.Size = new System.Drawing.Size(87, 15);
            this.lblKataban.strToolTip = null;
            this.lblKataban.TabIndex = 11;
            this.lblKataban.Text = "品名・型番";
            this.lblKataban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_TantoushaS
            // 
            this.labelSet_TantoushaS.AppendLabelSize = 0;
            this.labelSet_TantoushaS.AppendLabelText = "";
            this.labelSet_TantoushaS.CodeTxtSize = 40;
            this.labelSet_TantoushaS.CodeTxtText = "";
            this.labelSet_TantoushaS.LabelName = "担当者コード";
            this.labelSet_TantoushaS.Location = new System.Drawing.Point(7, 47);
            this.labelSet_TantoushaS.Name = "labelSet_TantoushaS";
            this.labelSet_TantoushaS.ShowAppendFlg = false;
            this.labelSet_TantoushaS.Size = new System.Drawing.Size(275, 22);
            this.labelSet_TantoushaS.SpaceCodeValue = 4;
            this.labelSet_TantoushaS.SpaceNameCode = 4;
            this.labelSet_TantoushaS.SpaceValueAppend = 4;
            this.labelSet_TantoushaS.TabIndex = 1;
            this.labelSet_TantoushaS.ValueLabelSize = 120;
            this.labelSet_TantoushaS.ValueLabelText = "";
            // 
            // labelSet_TokuisakiS
            // 
            this.labelSet_TokuisakiS.AppendLabelSize = 40;
            this.labelSet_TokuisakiS.AppendLabelText = "";
            this.labelSet_TokuisakiS.CodeTxtSize = 40;
            this.labelSet_TokuisakiS.CodeTxtText = "";
            this.labelSet_TokuisakiS.LabelName = "得意先コード";
            this.labelSet_TokuisakiS.Location = new System.Drawing.Point(7, 19);
            this.labelSet_TokuisakiS.Name = "labelSet_TokuisakiS";
            this.labelSet_TokuisakiS.ShowAppendFlg = true;
            this.labelSet_TokuisakiS.Size = new System.Drawing.Size(501, 22);
            this.labelSet_TokuisakiS.SpaceCodeValue = 4;
            this.labelSet_TokuisakiS.SpaceNameCode = 4;
            this.labelSet_TokuisakiS.SpaceValueAppend = 4;
            this.labelSet_TokuisakiS.TabIndex = 0;
            this.labelSet_TokuisakiS.ValueLabelSize = 350;
            this.labelSet_TokuisakiS.ValueLabelText = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.razioOrderS1);
            this.groupBox2.Location = new System.Drawing.Point(569, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 83);
            this.groupBox2.TabIndex = 88;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "並び順の指定";
            // 
            // razioOrderS1
            // 
            this.razioOrderS1.LabelTitle = "";
            this.razioOrderS1.Location = new System.Drawing.Point(6, 19);
            this.razioOrderS1.Name = "razioOrderS1";
            this.razioOrderS1.PositionLabelTitle_X = 0;
            this.razioOrderS1.PositionLabelTitle_Y = 0;
            this.razioOrderS1.PositionRadbtn1_X = 0;
            this.razioOrderS1.PositionRadbtn1_Y = 0;
            this.razioOrderS1.PositionRadbtn2_X = 100;
            this.razioOrderS1.PositionRadbtn2_Y = 0;
            this.razioOrderS1.PositionRadbtn3_X = 200;
            this.razioOrderS1.PositionRadbtn3_Y = 0;
            this.razioOrderS1.PositionRadbtn4_X = 300;
            this.razioOrderS1.PositionRadbtn4_Y = 0;
            this.razioOrderS1.Radbtn1Text = "得意先";
            this.razioOrderS1.Radbtn2Text = "品名";
            this.razioOrderS1.Radbtn3Text = "利益率";
            this.razioOrderS1.Radbtn4Text = "単価";
            this.razioOrderS1.Size = new System.Drawing.Size(382, 19);
            this.razioOrderS1.TabIndex = 0;
            // 
            // gridShohinbetsuRiekiritsu
            // 
            this.gridShohinbetsuRiekiritsu.AllowUserToAddRows = false;
            this.gridShohinbetsuRiekiritsu.AllowUserToResizeColumns = false;
            this.gridShohinbetsuRiekiritsu.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShohinbetsuRiekiritsu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridShohinbetsuRiekiritsu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridShohinbetsuRiekiritsu.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridShohinbetsuRiekiritsu.EnableHeadersVisualStyles = false;
            this.gridShohinbetsuRiekiritsu.Location = new System.Drawing.Point(29, 180);
            this.gridShohinbetsuRiekiritsu.Name = "gridShohinbetsuRiekiritsu";
            this.gridShohinbetsuRiekiritsu.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShohinbetsuRiekiritsu.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridShohinbetsuRiekiritsu.RowHeadersVisible = false;
            this.gridShohinbetsuRiekiritsu.RowTemplate.Height = 21;
            this.gridShohinbetsuRiekiritsu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShohinbetsuRiekiritsu.Size = new System.Drawing.Size(1131, 256);
            this.gridShohinbetsuRiekiritsu.StandardTab = true;
            this.gridShohinbetsuRiekiritsu.TabIndex = 89;
            this.gridShohinbetsuRiekiritsu.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridShohinbetsuRiekiritsu_CellDoubleClick);
            // 
            // labelSet_Tokuisaki
            // 
            this.labelSet_Tokuisaki.AppendLabelSize = 40;
            this.labelSet_Tokuisaki.AppendLabelText = "";
            this.labelSet_Tokuisaki.CodeTxtSize = 40;
            this.labelSet_Tokuisaki.CodeTxtText = "";
            this.labelSet_Tokuisaki.LabelName = "得意先コード";
            this.labelSet_Tokuisaki.Location = new System.Drawing.Point(29, 442);
            this.labelSet_Tokuisaki.Name = "labelSet_Tokuisaki";
            this.labelSet_Tokuisaki.ShowAppendFlg = true;
            this.labelSet_Tokuisaki.Size = new System.Drawing.Size(499, 22);
            this.labelSet_Tokuisaki.SpaceCodeValue = 4;
            this.labelSet_Tokuisaki.SpaceNameCode = 4;
            this.labelSet_Tokuisaki.SpaceValueAppend = 4;
            this.labelSet_Tokuisaki.TabIndex = 90;
            this.labelSet_Tokuisaki.ValueLabelSize = 350;
            this.labelSet_Tokuisaki.ValueLabelText = "";
            // 
            // labelSet_Daibunrui
            // 
            this.labelSet_Daibunrui.AppendLabelSize = 0;
            this.labelSet_Daibunrui.AppendLabelText = "";
            this.labelSet_Daibunrui.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.labelSet_Daibunrui.CodeTxtSize = 24;
            this.labelSet_Daibunrui.CodeTxtText = "";
            this.labelSet_Daibunrui.LabelName = "大分類コード";
            this.labelSet_Daibunrui.Location = new System.Drawing.Point(29, 470);
            this.labelSet_Daibunrui.Lschubundata = null;
            this.labelSet_Daibunrui.Lsmakerdata = null;
            this.labelSet_Daibunrui.LsSubchubundata = null;
            this.labelSet_Daibunrui.LsSubmakerdata = null;
            this.labelSet_Daibunrui.Name = "labelSet_Daibunrui";
            this.labelSet_Daibunrui.ShowAppendFlg = false;
            this.labelSet_Daibunrui.Size = new System.Drawing.Size(338, 22);
            this.labelSet_Daibunrui.SpaceCodeValue = 4;
            this.labelSet_Daibunrui.SpaceNameCode = 4;
            this.labelSet_Daibunrui.SpaceValueAppend = 4;
            this.labelSet_Daibunrui.TabIndex = 91;
            this.labelSet_Daibunrui.ValueLabelSize = 200;
            this.labelSet_Daibunrui.ValueLabelText = "";
            // 
            // labelSet_Chubunrui
            // 
            this.labelSet_Chubunrui.AppendLabelSize = 0;
            this.labelSet_Chubunrui.AppendLabelText = "";
            this.labelSet_Chubunrui.CodeTxtSize = 24;
            this.labelSet_Chubunrui.CodeTxtText = "";
            this.labelSet_Chubunrui.LabelName = "中分類コード";
            this.labelSet_Chubunrui.Location = new System.Drawing.Point(29, 498);
            this.labelSet_Chubunrui.Name = "labelSet_Chubunrui";
            this.labelSet_Chubunrui.ShowAppendFlg = false;
            this.labelSet_Chubunrui.Size = new System.Drawing.Size(338, 22);
            this.labelSet_Chubunrui.SpaceCodeValue = 4;
            this.labelSet_Chubunrui.SpaceNameCode = 4;
            this.labelSet_Chubunrui.SpaceValueAppend = 4;
            this.labelSet_Chubunrui.strDaibunCd = null;
            this.labelSet_Chubunrui.TabIndex = 92;
            this.labelSet_Chubunrui.ValueLabelSize = 200;
            this.labelSet_Chubunrui.ValueLabelText = "";
            // 
            // labelSet_Maker
            // 
            this.labelSet_Maker.AppendLabelSize = 0;
            this.labelSet_Maker.AppendLabelText = "";
            this.labelSet_Maker.CodeTxtSize = 30;
            this.labelSet_Maker.CodeTxtText = "";
            this.labelSet_Maker.LabelName = "メーカー";
            this.labelSet_Maker.Location = new System.Drawing.Point(29, 526);
            this.labelSet_Maker.Name = "labelSet_Maker";
            this.labelSet_Maker.ShowAppendFlg = false;
            this.labelSet_Maker.Size = new System.Drawing.Size(308, 22);
            this.labelSet_Maker.SpaceCodeValue = 4;
            this.labelSet_Maker.SpaceNameCode = 35;
            this.labelSet_Maker.SpaceValueAppend = 4;
            this.labelSet_Maker.strDaibunCd = null;
            this.labelSet_Maker.TabIndex = 93;
            this.labelSet_Maker.ValueLabelSize = 200;
            this.labelSet_Maker.ValueLabelText = "";
            // 
            // lblShohinCd
            // 
            this.lblShohinCd.AutoSize = true;
            this.lblShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblShohinCd.Location = new System.Drawing.Point(534, 501);
            this.lblShohinCd.Name = "lblShohinCd";
            this.lblShohinCd.Size = new System.Drawing.Size(87, 15);
            this.lblShohinCd.strToolTip = null;
            this.lblShohinCd.TabIndex = 95;
            this.lblShohinCd.Text = "商品コード";
            this.lblShohinCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShohinCd.Visible = false;
            // 
            // txtShohinCd
            // 
            this.txtShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShohinCd.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtShohinCd.Location = new System.Drawing.Point(627, 498);
            this.txtShohinCd.MaxLength = 5;
            this.txtShohinCd.Name = "txtShohinCd";
            this.txtShohinCd.Size = new System.Drawing.Size(119, 22);
            this.txtShohinCd.TabIndex = 94;
            this.txtShohinCd.Visible = false;
            this.txtShohinCd.Leave += new System.EventHandler(this.txtShohinCd_Leave);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(373, 533);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(87, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 97;
            this.baseLabel1.Text = "検索文字列";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKensakuS
            // 
            this.txtKensakuS.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensakuS.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKensakuS.Location = new System.Drawing.Point(466, 530);
            this.txtKensakuS.MaxLength = 40;
            this.txtKensakuS.Name = "txtKensakuS";
            this.txtKensakuS.Size = new System.Drawing.Size(297, 22);
            this.txtKensakuS.TabIndex = 96;
            this.txtKensakuS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKensaku_KeyDown);
            // 
            // txtKataban
            // 
            this.txtKataban.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKataban.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtKataban.Location = new System.Drawing.Point(132, 558);
            this.txtKataban.MaxLength = 60;
            this.txtKataban.Name = "txtKataban";
            this.txtKataban.ReadOnly = true;
            this.txtKataban.Size = new System.Drawing.Size(489, 22);
            this.txtKataban.TabIndex = 99;
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(33, 561);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(39, 15);
            this.baseLabel2.strToolTip = null;
            this.baseLabel2.TabIndex = 98;
            this.baseLabel2.Text = "品名";
            this.baseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseLabel3
            // 
            this.baseLabel3.AutoSize = true;
            this.baseLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel3.Location = new System.Drawing.Point(243, 592);
            this.baseLabel3.Name = "baseLabel3";
            this.baseLabel3.Size = new System.Drawing.Size(39, 15);
            this.baseLabel3.strToolTip = null;
            this.baseLabel3.TabIndex = 100;
            this.baseLabel3.Text = "定価";
            this.baseLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseLabel4
            // 
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel4.Location = new System.Drawing.Point(33, 620);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(39, 15);
            this.baseLabel4.strToolTip = null;
            this.baseLabel4.TabIndex = 101;
            this.baseLabel4.Text = "単価";
            this.baseLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseLabel5
            // 
            this.baseLabel5.AutoSize = true;
            this.baseLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel5.Location = new System.Drawing.Point(33, 589);
            this.baseLabel5.Name = "baseLabel5";
            this.baseLabel5.Size = new System.Drawing.Size(79, 15);
            this.baseLabel5.strToolTip = null;
            this.baseLabel5.TabIndex = 102;
            this.baseLabel5.Text = "利益率(%)";
            this.baseLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRiekiritsu
            // 
            this.txtRiekiritsu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtRiekiritsu.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtRiekiritsu.Location = new System.Drawing.Point(132, 589);
            this.txtRiekiritsu.MaxLength = 5;
            this.txtRiekiritsu.Name = "txtRiekiritsu";
            this.txtRiekiritsu.Size = new System.Drawing.Size(66, 22);
            this.txtRiekiritsu.TabIndex = 103;
            this.txtRiekiritsu.Leave += new System.EventHandler(this.txtRiekiritsu_Leave);
            // 
            // razioOrderS2
            // 
            this.razioOrderS2.LabelTitle = "";
            this.razioOrderS2.Location = new System.Drawing.Point(575, 63);
            this.razioOrderS2.Name = "razioOrderS2";
            this.razioOrderS2.PositionLabelTitle_X = 0;
            this.razioOrderS2.PositionLabelTitle_Y = 0;
            this.razioOrderS2.PositionRadbtn1_X = 0;
            this.razioOrderS2.PositionRadbtn1_Y = 0;
            this.razioOrderS2.PositionRadbtn2_X = 100;
            this.razioOrderS2.PositionRadbtn2_Y = 0;
            this.razioOrderS2.Radbtn1Text = "Ａ―Ｚ";
            this.razioOrderS2.Radbtn2Text = "Ｚ―Ａ";
            this.razioOrderS2.Size = new System.Drawing.Size(188, 18);
            this.razioOrderS2.TabIndex = 1;
            // 
            // razioSettei
            // 
            this.razioSettei.LabelTitle = "";
            this.razioSettei.Location = new System.Drawing.Point(104, 658);
            this.razioSettei.Name = "razioSettei";
            this.razioSettei.PositionLabelTitle_X = 0;
            this.razioSettei.PositionLabelTitle_Y = 0;
            this.razioSettei.PositionRadbtn1_X = 150;
            this.razioSettei.PositionRadbtn1_Y = 0;
            this.razioSettei.PositionRadbtn2_X = 250;
            this.razioSettei.PositionRadbtn2_Y = 0;
            this.razioSettei.Radbtn1Text = "設定";
            this.razioSettei.Radbtn2Text = "解除";
            this.razioSettei.Size = new System.Drawing.Size(438, 27);
            this.razioSettei.TabIndex = 104;
            // 
            // txtTeika
            // 
            this.txtTeika.blnCommaOK = true;
            this.txtTeika.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTeika.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTeika.intDeciSet = 0;
            this.txtTeika.intIntederSet = 0;
            this.txtTeika.intShishagonyu = 0;
            this.txtTeika.Location = new System.Drawing.Point(288, 589);
            this.txtTeika.MaxLength = 9;
            this.txtTeika.Name = "txtTeika";
            this.txtTeika.Size = new System.Drawing.Size(128, 22);
            this.txtTeika.TabIndex = 105;
            this.txtTeika.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTanka
            // 
            this.txtTanka.blnCommaOK = true;
            this.txtTanka.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanka.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTanka.intDeciSet = 0;
            this.txtTanka.intIntederSet = 0;
            this.txtTanka.intShishagonyu = 0;
            this.txtTanka.Location = new System.Drawing.Point(132, 617);
            this.txtTanka.MaxLength = 9;
            this.txtTanka.Name = "txtTanka";
            this.txtTanka.Size = new System.Drawing.Size(100, 22);
            this.txtTanka.TabIndex = 106;
            this.txtTanka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTanka.Leave += new System.EventHandler(this.txtTanka_Leave);
            // 
            // M1210_ShohinbetsuRiekiritsuSettei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.txtTanka);
            this.Controls.Add(this.txtTeika);
            this.Controls.Add(this.razioSettei);
            this.Controls.Add(this.razioOrderS2);
            this.Controls.Add(this.txtRiekiritsu);
            this.Controls.Add(this.baseLabel5);
            this.Controls.Add(this.baseLabel4);
            this.Controls.Add(this.baseLabel3);
            this.Controls.Add(this.txtKataban);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.txtKensakuS);
            this.Controls.Add(this.lblShohinCd);
            this.Controls.Add(this.txtShohinCd);
            this.Controls.Add(this.labelSet_Maker);
            this.Controls.Add(this.labelSet_Chubunrui);
            this.Controls.Add(this.labelSet_Daibunrui);
            this.Controls.Add(this.labelSet_Tokuisaki);
            this.Controls.Add(this.gridShohinbetsuRiekiritsu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "M1210_ShohinbetsuRiekiritsuSettei";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.M1210_ShohinbetsuRiekiritsuSettei_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1210_ShohinbetsuRiekiritsuSettei_KeyDown);
            this.Controls.SetChildIndex(this.groupBox1, 0);
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
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.gridShohinbetsuRiekiritsu, 0);
            this.Controls.SetChildIndex(this.labelSet_Tokuisaki, 0);
            this.Controls.SetChildIndex(this.labelSet_Daibunrui, 0);
            this.Controls.SetChildIndex(this.labelSet_Chubunrui, 0);
            this.Controls.SetChildIndex(this.labelSet_Maker, 0);
            this.Controls.SetChildIndex(this.txtShohinCd, 0);
            this.Controls.SetChildIndex(this.lblShohinCd, 0);
            this.Controls.SetChildIndex(this.txtKensakuS, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.baseLabel2, 0);
            this.Controls.SetChildIndex(this.txtKataban, 0);
            this.Controls.SetChildIndex(this.baseLabel3, 0);
            this.Controls.SetChildIndex(this.baseLabel4, 0);
            this.Controls.SetChildIndex(this.baseLabel5, 0);
            this.Controls.SetChildIndex(this.txtRiekiritsu, 0);
            this.Controls.SetChildIndex(this.razioOrderS2, 0);
            this.Controls.SetChildIndex(this.razioSettei, 0);
            this.Controls.SetChildIndex(this.txtTeika, 0);
            this.Controls.SetChildIndex(this.txtTanka, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridShohinbetsuRiekiritsu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Common.Ctl.LabelSet_Tantousha labelSet_TantoushaS;
        private Common.Ctl.LabelSet_Tokuisaki labelSet_TokuisakiS;
        private Common.Ctl.BaseLabel lblKataban;
        private System.Windows.Forms.GroupBox groupBox2;
        private Common.Ctl.BaseDataGridView gridShohinbetsuRiekiritsu;
        private Common.Ctl.LabelSet_Tokuisaki labelSet_Tokuisaki;
        private Common.Ctl.LabelSet_Daibunrui labelSet_Daibunrui;
        private Common.Ctl.LabelSet_Chubunrui labelSet_Chubunrui;
        private Common.Ctl.LabelSet_Maker labelSet_Maker;
        private Common.Ctl.BaseLabel lblShohinCd;
        private Common.Ctl.BaseText txtShohinCd;
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.BaseText txtKensakuS;
        private Common.Ctl.BaseText txtKataban;
        private Common.Ctl.BaseLabel baseLabel2;
        private Common.Ctl.BaseLabel baseLabel3;
        private Common.Ctl.BaseLabel baseLabel4;
        private Common.Ctl.BaseLabel baseLabel5;
        private Common.Ctl.BaseText txtRiekiritsu;
        private Common.Ctl.BaseButton baseButton_kensaku;
        private Common.Ctl.RadSet_4btn razioOrderS1;
        private Common.Ctl.RadSet_2btn razioOrderS2;
        private Common.Ctl.BaseText txtSinamei_KatabanS;
        private Common.Ctl.RadSet_2btn razioSettei;
        private Common.Ctl.BaseTextMoney txtTeika;
        private Common.Ctl.BaseTextMoney txtTanka;
    }
}