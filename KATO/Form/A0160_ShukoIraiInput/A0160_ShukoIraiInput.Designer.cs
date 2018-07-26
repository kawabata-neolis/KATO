namespace KATO.Form.A0160_ShukoIraiInput
{
    partial class A0160_ShukoIraiInput
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
            this.txtYMD = new KATO.Common.Ctl.BaseCalendar();
            this.lblYMD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtDenpyoNo = new KATO.Common.Ctl.BaseTextMoney();
            this.lblDenpyoNo = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblsetTantosha = new KATO.Common.Ctl.LabelSet_Tantousha();
            this.lblsetEigyosho = new KATO.Common.Ctl.LabelSet_Eigyosho();
            this.lblsetShukoEigyosho = new KATO.Common.Ctl.LabelSet_Eigyosho();
            this.lblBox1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblShukohin = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblShukoiraimesai = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gridShuko = new KATO.Common.Ctl.BaseDataGridView();
            this.lblsetDaibunrui = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.lblsetChubunrui = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.lblsetMaker = new KATO.Common.Ctl.LabelSet_Maker();
            this.txtShohinCd = new KATO.Common.Ctl.BaseText();
            this.txtKensaku = new KATO.Common.Ctl.BaseText();
            this.txtHinmei = new KATO.Common.Ctl.BaseText();
            this.txtC1 = new KATO.Common.Ctl.BaseText();
            this.txtC2 = new KATO.Common.Ctl.BaseText();
            this.txtC3 = new KATO.Common.Ctl.BaseText();
            this.txtC4 = new KATO.Common.Ctl.BaseText();
            this.txtC5 = new KATO.Common.Ctl.BaseText();
            this.txtC6 = new KATO.Common.Ctl.BaseText();
            this.txtSu = new KATO.Common.Ctl.BaseTextMoney();
            this.txtTanka = new KATO.Common.Ctl.BaseTextMoney();
            this.lblShohinCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblKensaku = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblHinmei = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblSu = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblKataban = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblTanka = new KATO.Common.Ctl.BaseLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridShuko)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.TabIndex = 11;
            this.btnF01.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF12
            // 
            this.btnF12.TabStop = false;
            this.btnF12.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.TabStop = false;
            this.btnF11.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF10
            // 
            this.btnF10.TabStop = false;
            this.btnF10.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.TabStop = false;
            this.btnF09.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF08
            // 
            this.btnF08.TabStop = false;
            this.btnF08.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF07
            // 
            this.btnF07.TabStop = false;
            this.btnF07.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF06
            // 
            this.btnF06.TabStop = false;
            this.btnF06.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF05
            // 
            this.btnF05.TabIndex = 15;
            this.btnF05.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.TabIndex = 14;
            this.btnF04.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.TabIndex = 13;
            this.btnF03.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF02
            // 
            this.btnF02.TabIndex = 12;
            this.btnF02.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // txtYMD
            // 
            this.txtYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYMD.Location = new System.Drawing.Point(134, 35);
            this.txtYMD.Name = "txtYMD";
            this.txtYMD.Size = new System.Drawing.Size(88, 22);
            this.txtYMD.TabIndex = 0;
            this.txtYMD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtShukoKeyUp);
            // 
            // lblYMD
            // 
            this.lblYMD.AutoSize = true;
            this.lblYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblYMD.Location = new System.Drawing.Point(29, 38);
            this.lblYMD.Name = "lblYMD";
            this.lblYMD.Size = new System.Drawing.Size(87, 15);
            this.lblYMD.strToolTip = null;
            this.lblYMD.TabIndex = 88;
            this.lblYMD.Text = "出庫年月日";
            this.lblYMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDenpyoNo
            // 
            this.txtDenpyoNo.blnCommaOK = false;
            this.txtDenpyoNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDenpyoNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDenpyoNo.intDeciSet = 0;
            this.txtDenpyoNo.intIntederSet = 0;
            this.txtDenpyoNo.intShishagonyu = 0;
            this.txtDenpyoNo.Location = new System.Drawing.Point(380, 35);
            this.txtDenpyoNo.MaxLength = 8;
            this.txtDenpyoNo.MinusFlg = true;
            this.txtDenpyoNo.Name = "txtDenpyoNo";
            this.txtDenpyoNo.Size = new System.Drawing.Size(72, 22);
            this.txtDenpyoNo.TabIndex = 1;
            this.txtDenpyoNo.TabStop = false;
            this.txtDenpyoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDenpyoNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtShukoKeyDown);
            this.txtDenpyoNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtShukoKeyUp);
            this.txtDenpyoNo.Leave += new System.EventHandler(this.txtDenpyoNo_Leave);
            // 
            // lblDenpyoNo
            // 
            this.lblDenpyoNo.AutoSize = true;
            this.lblDenpyoNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDenpyoNo.Location = new System.Drawing.Point(294, 38);
            this.lblDenpyoNo.Name = "lblDenpyoNo";
            this.lblDenpyoNo.Size = new System.Drawing.Size(71, 15);
            this.lblDenpyoNo.strToolTip = null;
            this.lblDenpyoNo.TabIndex = 88;
            this.lblDenpyoNo.Text = "伝票番号";
            this.lblDenpyoNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblsetTantosha
            // 
            this.lblsetTantosha.AppendLabelSize = 0;
            this.lblsetTantosha.AppendLabelText = "";
            this.lblsetTantosha.CodeTxtSize = 40;
            this.lblsetTantosha.CodeTxtText = "";
            this.lblsetTantosha.LabelName = "担当者コード";
            this.lblsetTantosha.Location = new System.Drawing.Point(523, 35);
            this.lblsetTantosha.Name = "lblsetTantosha";
            this.lblsetTantosha.ShowAppendFlg = false;
            this.lblsetTantosha.Size = new System.Drawing.Size(296, 22);
            this.lblsetTantosha.SpaceCodeValue = 4;
            this.lblsetTantosha.SpaceNameCode = 4;
            this.lblsetTantosha.SpaceValueAppend = 4;
            this.lblsetTantosha.TabIndex = 2;
            this.lblsetTantosha.ValueLabelSize = 120;
            this.lblsetTantosha.ValueLabelText = "";
            // 
            // lblsetEigyosho
            // 
            this.lblsetEigyosho.AppendLabelSize = 0;
            this.lblsetEigyosho.AppendLabelText = "";
            this.lblsetEigyosho.CodeTxtSize = 40;
            this.lblsetEigyosho.CodeTxtText = "";
            this.lblsetEigyosho.LabelName = "営業所コード";
            this.lblsetEigyosho.Location = new System.Drawing.Point(863, 35);
            this.lblsetEigyosho.Name = "lblsetEigyosho";
            this.lblsetEigyosho.ShowAppendFlg = false;
            this.lblsetEigyosho.Size = new System.Drawing.Size(159, 22);
            this.lblsetEigyosho.SpaceCodeValue = 4;
            this.lblsetEigyosho.SpaceNameCode = 4;
            this.lblsetEigyosho.SpaceValueAppend = 4;
            this.lblsetEigyosho.TabIndex = 91;
            this.lblsetEigyosho.TabStop = false;
            this.lblsetEigyosho.ValueLabelSize = 0;
            this.lblsetEigyosho.ValueLabelText = "";
            this.lblsetEigyosho.Visible = false;
            // 
            // lblsetShukoEigyosho
            // 
            this.lblsetShukoEigyosho.AppendLabelSize = 0;
            this.lblsetShukoEigyosho.AppendLabelText = "";
            this.lblsetShukoEigyosho.CodeTxtSize = 40;
            this.lblsetShukoEigyosho.CodeTxtText = "";
            this.lblsetShukoEigyosho.LabelName = "出庫営業所";
            this.lblsetShukoEigyosho.Location = new System.Drawing.Point(27, 65);
            this.lblsetShukoEigyosho.Name = "lblsetShukoEigyosho";
            this.lblsetShukoEigyosho.ShowAppendFlg = false;
            this.lblsetShukoEigyosho.Size = new System.Drawing.Size(278, 22);
            this.lblsetShukoEigyosho.SpaceCodeValue = 4;
            this.lblsetShukoEigyosho.SpaceNameCode = 20;
            this.lblsetShukoEigyosho.SpaceValueAppend = 4;
            this.lblsetShukoEigyosho.TabIndex = 3;
            this.lblsetShukoEigyosho.ValueLabelSize = 100;
            this.lblsetShukoEigyosho.ValueLabelText = "";
            this.lblsetShukoEigyosho.Leave += new System.EventHandler(this.lblsetShukoEigyosho_Leave);
            // 
            // lblBox1
            // 
            this.lblBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBox1.Location = new System.Drawing.Point(23, 103);
            this.lblBox1.Name = "lblBox1";
            this.lblBox1.Size = new System.Drawing.Size(1076, 179);
            this.lblBox1.strToolTip = null;
            this.lblBox1.TabIndex = 93;
            this.lblBox1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShukohin
            // 
            this.lblShukohin.AutoSize = true;
            this.lblShukohin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShukohin.ForeColor = System.Drawing.Color.Navy;
            this.lblShukohin.Location = new System.Drawing.Point(37, 96);
            this.lblShukohin.Name = "lblShukohin";
            this.lblShukohin.Size = new System.Drawing.Size(55, 15);
            this.lblShukohin.strToolTip = null;
            this.lblShukohin.TabIndex = 94;
            this.lblShukohin.Text = "出庫品";
            this.lblShukohin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseLabel1
            // 
            this.baseLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.baseLabel1.Location = new System.Drawing.Point(23, 301);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(1375, 461);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 93;
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShukoiraimesai
            // 
            this.lblShukoiraimesai.AutoSize = true;
            this.lblShukoiraimesai.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShukoiraimesai.ForeColor = System.Drawing.Color.Navy;
            this.lblShukoiraimesai.Location = new System.Drawing.Point(37, 295);
            this.lblShukoiraimesai.Name = "lblShukoiraimesai";
            this.lblShukoiraimesai.Size = new System.Drawing.Size(103, 15);
            this.lblShukoiraimesai.strToolTip = null;
            this.lblShukoiraimesai.TabIndex = 94;
            this.lblShukoiraimesai.Text = "出庫依頼明細";
            this.lblShukoiraimesai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridShuko
            // 
            this.gridShuko.AllowUserToAddRows = false;
            this.gridShuko.AllowUserToResizeColumns = false;
            this.gridShuko.AllowUserToResizeRows = false;
            this.gridShuko.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShuko.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridShuko.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridShuko.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridShuko.EnableHeadersVisualStyles = false;
            this.gridShuko.Location = new System.Drawing.Point(35, 324);
            this.gridShuko.Name = "gridShuko";
            this.gridShuko.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShuko.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridShuko.RowHeadersVisible = false;
            this.gridShuko.RowTemplate.Height = 21;
            this.gridShuko.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShuko.Size = new System.Drawing.Size(1352, 424);
            this.gridShuko.StandardTab = true;
            this.gridShuko.TabIndex = 16;
            this.gridShuko.DoubleClick += new System.EventHandler(this.gridShuko_DoubleClick);
            this.gridShuko.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridShuko_KeyDown);
            // 
            // lblsetDaibunrui
            // 
            this.lblsetDaibunrui.AppendLabelSize = 0;
            this.lblsetDaibunrui.AppendLabelText = "";
            this.lblsetDaibunrui.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lblsetDaibunrui.CodeTxtSize = 24;
            this.lblsetDaibunrui.CodeTxtText = "";
            this.lblsetDaibunrui.LabelName = "大分類";
            this.lblsetDaibunrui.Location = new System.Drawing.Point(40, 122);
            this.lblsetDaibunrui.Lschubundata = null;
            this.lblsetDaibunrui.Lsmakerdata = null;
            this.lblsetDaibunrui.LsSubchubundata = null;
            this.lblsetDaibunrui.LsSubmakerdata = null;
            this.lblsetDaibunrui.Name = "lblsetDaibunrui";
            this.lblsetDaibunrui.ShowAppendFlg = false;
            this.lblsetDaibunrui.Size = new System.Drawing.Size(351, 22);
            this.lblsetDaibunrui.SpaceCodeValue = 20;
            this.lblsetDaibunrui.SpaceNameCode = 30;
            this.lblsetDaibunrui.SpaceValueAppend = 4;
            this.lblsetDaibunrui.TabIndex = 4;
            this.lblsetDaibunrui.ValueLabelSize = 200;
            this.lblsetDaibunrui.ValueLabelText = "";
            // 
            // lblsetChubunrui
            // 
            this.lblsetChubunrui.AppendLabelSize = 0;
            this.lblsetChubunrui.AppendLabelText = "";
            this.lblsetChubunrui.CodeTxtSize = 24;
            this.lblsetChubunrui.CodeTxtText = "";
            this.lblsetChubunrui.LabelName = "中分類";
            this.lblsetChubunrui.Location = new System.Drawing.Point(40, 150);
            this.lblsetChubunrui.Name = "lblsetChubunrui";
            this.lblsetChubunrui.ShowAppendFlg = false;
            this.lblsetChubunrui.Size = new System.Drawing.Size(351, 22);
            this.lblsetChubunrui.SpaceCodeValue = 20;
            this.lblsetChubunrui.SpaceNameCode = 30;
            this.lblsetChubunrui.SpaceValueAppend = 4;
            this.lblsetChubunrui.strDaibunCd = null;
            this.lblsetChubunrui.TabIndex = 5;
            this.lblsetChubunrui.ValueLabelSize = 200;
            this.lblsetChubunrui.ValueLabelText = "";
            // 
            // lblsetMaker
            // 
            this.lblsetMaker.AppendLabelSize = 0;
            this.lblsetMaker.AppendLabelText = "";
            this.lblsetMaker.CodeTxtSize = 40;
            this.lblsetMaker.CodeTxtText = "";
            this.lblsetMaker.LabelName = "メーカー";
            this.lblsetMaker.Location = new System.Drawing.Point(40, 178);
            this.lblsetMaker.Name = "lblsetMaker";
            this.lblsetMaker.ShowAppendFlg = false;
            this.lblsetMaker.Size = new System.Drawing.Size(351, 22);
            this.lblsetMaker.SpaceCodeValue = 4;
            this.lblsetMaker.SpaceNameCode = 14;
            this.lblsetMaker.SpaceValueAppend = 4;
            this.lblsetMaker.strDaibunCd = null;
            this.lblsetMaker.TabIndex = 6;
            this.lblsetMaker.ValueLabelSize = 200;
            this.lblsetMaker.ValueLabelText = "";
            // 
            // txtShohinCd
            // 
            this.txtShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShohinCd.Location = new System.Drawing.Point(499, 123);
            this.txtShohinCd.Name = "txtShohinCd";
            this.txtShohinCd.Size = new System.Drawing.Size(100, 22);
            this.txtShohinCd.TabIndex = 99;
            this.txtShohinCd.TabStop = false;
            this.txtShohinCd.Visible = false;
            // 
            // txtKensaku
            // 
            this.txtKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensaku.Location = new System.Drawing.Point(499, 178);
            this.txtKensaku.MaxLength = 40;
            this.txtKensaku.Name = "txtKensaku";
            this.txtKensaku.Size = new System.Drawing.Size(330, 22);
            this.txtKensaku.TabIndex = 7;
            this.txtKensaku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKensaku_KeyDown);
            this.txtKensaku.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtShukoKeyUp);
            // 
            // txtHinmei
            // 
            this.txtHinmei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHinmei.Location = new System.Drawing.Point(125, 212);
            this.txtHinmei.MaxLength = 60;
            this.txtHinmei.Name = "txtHinmei";
            this.txtHinmei.Size = new System.Drawing.Size(490, 22);
            this.txtHinmei.TabIndex = 8;
            this.txtHinmei.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtShukoKeyDown);
            this.txtHinmei.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtShukoKeyUp);
            // 
            // txtC1
            // 
            this.txtC1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtC1.Location = new System.Drawing.Point(125, 245);
            this.txtC1.Name = "txtC1";
            this.txtC1.Size = new System.Drawing.Size(150, 22);
            this.txtC1.TabIndex = 99;
            this.txtC1.TabStop = false;
            this.txtC1.Visible = false;
            // 
            // txtC2
            // 
            this.txtC2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtC2.Location = new System.Drawing.Point(281, 245);
            this.txtC2.Name = "txtC2";
            this.txtC2.Size = new System.Drawing.Size(150, 22);
            this.txtC2.TabIndex = 99;
            this.txtC2.TabStop = false;
            this.txtC2.Visible = false;
            // 
            // txtC3
            // 
            this.txtC3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtC3.Location = new System.Drawing.Point(437, 245);
            this.txtC3.Name = "txtC3";
            this.txtC3.Size = new System.Drawing.Size(150, 22);
            this.txtC3.TabIndex = 99;
            this.txtC3.TabStop = false;
            this.txtC3.Visible = false;
            // 
            // txtC4
            // 
            this.txtC4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtC4.Location = new System.Drawing.Point(594, 245);
            this.txtC4.Name = "txtC4";
            this.txtC4.Size = new System.Drawing.Size(150, 22);
            this.txtC4.TabIndex = 99;
            this.txtC4.TabStop = false;
            this.txtC4.Visible = false;
            // 
            // txtC5
            // 
            this.txtC5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtC5.Location = new System.Drawing.Point(750, 245);
            this.txtC5.Name = "txtC5";
            this.txtC5.Size = new System.Drawing.Size(150, 22);
            this.txtC5.TabIndex = 99;
            this.txtC5.TabStop = false;
            this.txtC5.Visible = false;
            // 
            // txtC6
            // 
            this.txtC6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtC6.Location = new System.Drawing.Point(906, 245);
            this.txtC6.Name = "txtC6";
            this.txtC6.Size = new System.Drawing.Size(150, 22);
            this.txtC6.TabIndex = 99;
            this.txtC6.TabStop = false;
            this.txtC6.Visible = false;
            // 
            // txtSu
            // 
            this.txtSu.blnCommaOK = true;
            this.txtSu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtSu.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSu.intDeciSet = 2;
            this.txtSu.intIntederSet = 0;
            this.txtSu.intShishagonyu = 0;
            this.txtSu.Location = new System.Drawing.Point(712, 212);
            this.txtSu.MaxLength = 8;
            this.txtSu.MinusFlg = true;
            this.txtSu.Name = "txtSu";
            this.txtSu.Size = new System.Drawing.Size(112, 22);
            this.txtSu.TabIndex = 9;
            this.txtSu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtShukoKeyDown);
            this.txtSu.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtShukoKeyUp);
            // 
            // txtTanka
            // 
            this.txtTanka.blnCommaOK = true;
            this.txtTanka.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanka.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTanka.intDeciSet = 2;
            this.txtTanka.intIntederSet = 0;
            this.txtTanka.intShishagonyu = 0;
            this.txtTanka.Location = new System.Drawing.Point(930, 212);
            this.txtTanka.MaxLength = 8;
            this.txtTanka.MinusFlg = false;
            this.txtTanka.Name = "txtTanka";
            this.txtTanka.Size = new System.Drawing.Size(114, 22);
            this.txtTanka.TabIndex = 10;
            this.txtTanka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTanka.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtShukoKeyDown);
            this.txtTanka.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtShukoKeyUp);
            // 
            // lblShohinCd
            // 
            this.lblShohinCd.AutoSize = true;
            this.lblShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblShohinCd.Location = new System.Drawing.Point(406, 126);
            this.lblShohinCd.Name = "lblShohinCd";
            this.lblShohinCd.Size = new System.Drawing.Size(87, 15);
            this.lblShohinCd.strToolTip = null;
            this.lblShohinCd.TabIndex = 101;
            this.lblShohinCd.Text = "商品コード";
            this.lblShohinCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShohinCd.Visible = false;
            // 
            // lblKensaku
            // 
            this.lblKensaku.AutoSize = true;
            this.lblKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKensaku.Location = new System.Drawing.Point(406, 181);
            this.lblKensaku.Name = "lblKensaku";
            this.lblKensaku.Size = new System.Drawing.Size(87, 15);
            this.lblKensaku.strToolTip = null;
            this.lblKensaku.TabIndex = 101;
            this.lblKensaku.Text = "検索文字列";
            this.lblKensaku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHinmei
            // 
            this.lblHinmei.AutoSize = true;
            this.lblHinmei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHinmei.Location = new System.Drawing.Point(42, 215);
            this.lblHinmei.Name = "lblHinmei";
            this.lblHinmei.Size = new System.Drawing.Size(39, 15);
            this.lblHinmei.strToolTip = null;
            this.lblHinmei.TabIndex = 101;
            this.lblHinmei.Text = "品名";
            this.lblHinmei.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSu
            // 
            this.lblSu.AutoSize = true;
            this.lblSu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSu.Location = new System.Drawing.Point(657, 215);
            this.lblSu.Name = "lblSu";
            this.lblSu.Size = new System.Drawing.Size(39, 15);
            this.lblSu.strToolTip = null;
            this.lblSu.TabIndex = 102;
            this.lblSu.Text = "数量";
            this.lblSu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKataban
            // 
            this.lblKataban.AutoSize = true;
            this.lblKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKataban.Location = new System.Drawing.Point(42, 248);
            this.lblKataban.Name = "lblKataban";
            this.lblKataban.Size = new System.Drawing.Size(39, 15);
            this.lblKataban.strToolTip = null;
            this.lblKataban.TabIndex = 103;
            this.lblKataban.Text = "型番";
            this.lblKataban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKataban.Visible = false;
            // 
            // lblTanka
            // 
            this.lblTanka.AutoSize = true;
            this.lblTanka.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTanka.Location = new System.Drawing.Point(869, 215);
            this.lblTanka.Name = "lblTanka";
            this.lblTanka.Size = new System.Drawing.Size(39, 15);
            this.lblTanka.strToolTip = null;
            this.lblTanka.TabIndex = 103;
            this.lblTanka.Text = "単価";
            this.lblTanka.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // A0160_ShukoIraiInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 826);
            this.Controls.Add(this.lblTanka);
            this.Controls.Add(this.lblKataban);
            this.Controls.Add(this.lblSu);
            this.Controls.Add(this.lblHinmei);
            this.Controls.Add(this.lblKensaku);
            this.Controls.Add(this.lblShohinCd);
            this.Controls.Add(this.txtTanka);
            this.Controls.Add(this.txtSu);
            this.Controls.Add(this.txtHinmei);
            this.Controls.Add(this.txtC6);
            this.Controls.Add(this.txtC5);
            this.Controls.Add(this.txtC4);
            this.Controls.Add(this.txtC3);
            this.Controls.Add(this.txtC2);
            this.Controls.Add(this.txtC1);
            this.Controls.Add(this.txtKensaku);
            this.Controls.Add(this.txtShohinCd);
            this.Controls.Add(this.lblsetMaker);
            this.Controls.Add(this.lblsetChubunrui);
            this.Controls.Add(this.lblsetDaibunrui);
            this.Controls.Add(this.gridShuko);
            this.Controls.Add(this.lblShukoiraimesai);
            this.Controls.Add(this.lblShukohin);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.lblBox1);
            this.Controls.Add(this.lblsetShukoEigyosho);
            this.Controls.Add(this.lblsetEigyosho);
            this.Controls.Add(this.lblsetTantosha);
            this.Controls.Add(this.txtDenpyoNo);
            this.Controls.Add(this.lblDenpyoNo);
            this.Controls.Add(this.lblYMD);
            this.Controls.Add(this.txtYMD);
            this.Name = "A0160_ShukoIraiInput";
            this.Text = "A0160_ShukoIraiInput";
            this.Load += new System.EventHandler(this.A0160_ShukoIraiInput_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.A0160_ShukoIraiInput_KeyDown);
            this.Controls.SetChildIndex(this.txtYMD, 0);
            this.Controls.SetChildIndex(this.lblYMD, 0);
            this.Controls.SetChildIndex(this.lblDenpyoNo, 0);
            this.Controls.SetChildIndex(this.txtDenpyoNo, 0);
            this.Controls.SetChildIndex(this.lblsetTantosha, 0);
            this.Controls.SetChildIndex(this.lblsetEigyosho, 0);
            this.Controls.SetChildIndex(this.lblsetShukoEigyosho, 0);
            this.Controls.SetChildIndex(this.lblBox1, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.lblShukohin, 0);
            this.Controls.SetChildIndex(this.lblShukoiraimesai, 0);
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
            this.Controls.SetChildIndex(this.gridShuko, 0);
            this.Controls.SetChildIndex(this.lblsetDaibunrui, 0);
            this.Controls.SetChildIndex(this.lblsetChubunrui, 0);
            this.Controls.SetChildIndex(this.lblsetMaker, 0);
            this.Controls.SetChildIndex(this.txtShohinCd, 0);
            this.Controls.SetChildIndex(this.txtKensaku, 0);
            this.Controls.SetChildIndex(this.txtC1, 0);
            this.Controls.SetChildIndex(this.txtC2, 0);
            this.Controls.SetChildIndex(this.txtC3, 0);
            this.Controls.SetChildIndex(this.txtC4, 0);
            this.Controls.SetChildIndex(this.txtC5, 0);
            this.Controls.SetChildIndex(this.txtC6, 0);
            this.Controls.SetChildIndex(this.txtHinmei, 0);
            this.Controls.SetChildIndex(this.txtSu, 0);
            this.Controls.SetChildIndex(this.txtTanka, 0);
            this.Controls.SetChildIndex(this.lblShohinCd, 0);
            this.Controls.SetChildIndex(this.lblKensaku, 0);
            this.Controls.SetChildIndex(this.lblHinmei, 0);
            this.Controls.SetChildIndex(this.lblSu, 0);
            this.Controls.SetChildIndex(this.lblKataban, 0);
            this.Controls.SetChildIndex(this.lblTanka, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridShuko)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseCalendar txtYMD;
        private Common.Ctl.BaseLabel lblYMD;
        private Common.Ctl.BaseTextMoney txtDenpyoNo;
        private Common.Ctl.BaseLabel lblDenpyoNo;
        private Common.Ctl.LabelSet_Tantousha lblsetTantosha;
        private Common.Ctl.LabelSet_Eigyosho lblsetEigyosho;
        private Common.Ctl.LabelSet_Eigyosho lblsetShukoEigyosho;
        private Common.Ctl.BaseLabel lblBox1;
        private Common.Ctl.BaseLabel lblShukohin;
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.BaseLabel lblShukoiraimesai;
        private Common.Ctl.BaseDataGridView gridShuko;
        private Common.Ctl.LabelSet_Daibunrui lblsetDaibunrui;
        private Common.Ctl.LabelSet_Chubunrui lblsetChubunrui;
        private Common.Ctl.LabelSet_Maker lblsetMaker;
        private Common.Ctl.BaseText txtShohinCd;
        private Common.Ctl.BaseText txtKensaku;
        private Common.Ctl.BaseText txtHinmei;
        private Common.Ctl.BaseText txtC1;
        private Common.Ctl.BaseText txtC2;
        private Common.Ctl.BaseText txtC3;
        private Common.Ctl.BaseText txtC4;
        private Common.Ctl.BaseText txtC5;
        private Common.Ctl.BaseText txtC6;
        private Common.Ctl.BaseTextMoney txtSu;
        private Common.Ctl.BaseTextMoney txtTanka;
        private Common.Ctl.BaseLabel lblShohinCd;
        private Common.Ctl.BaseLabel lblKensaku;
        private Common.Ctl.BaseLabel lblHinmei;
        private Common.Ctl.BaseLabel lblSu;
        private Common.Ctl.BaseLabel lblKataban;
        private Common.Ctl.BaseLabel lblTanka;
    }
}