using KATO.Common.Ctl;
using KATO.Common.Util;

namespace KATO.Form.M1000_Kaishajyoken
{
    partial class M1000_Kaishajyoken
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
            this.txtKaisyaCode = new KATO.Common.Ctl.BaseText();
            this.txtKaishaName = new KATO.Common.Ctl.BaseText();
            this.txtYubinNum = new KATO.Common.Ctl.BaseText();
            this.txtJyusyo1 = new KATO.Common.Ctl.BaseText();
            this.txtJyusyo2 = new KATO.Common.Ctl.BaseText();
            this.txtDaihyosyaName = new KATO.Common.Ctl.BaseText();
            this.txtDennwaNum = new KATO.Common.Ctl.BaseText();
            this.txtGetumatsusimebi = new KATO.Common.Ctl.BaseText();
            this.lblKaisyaCode = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblKaisyaName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblYubinNum = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblJyusyo1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblJyusyo2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblDaihyosyaName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblDennwaNum = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblGetumatsusimebi = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblFaxNum = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtFaxNum = new KATO.Common.Ctl.BaseText();
            this.lblKaishiYMD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gbKaikeikimatsu = new System.Windows.Forms.GroupBox();
            this.txtShuryouYMD = new KATO.Common.Ctl.BaseCalendar();
            this.lblShuryouYMD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtKaishiYMD = new KATO.Common.Ctl.BaseCalendar();
            this.gbKaikeikimatsu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.TabIndex = 102;
            this.btnF01.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF12
            // 
            this.btnF12.TabIndex = 113;
            this.btnF12.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.TabIndex = 112;
            this.btnF11.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF10
            // 
            this.btnF10.TabIndex = 111;
            this.btnF10.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.TabIndex = 110;
            this.btnF09.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF08
            // 
            this.btnF08.TabIndex = 109;
            this.btnF08.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF07
            // 
            this.btnF07.TabIndex = 108;
            this.btnF07.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF06
            // 
            this.btnF06.TabIndex = 107;
            this.btnF06.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF05
            // 
            this.btnF05.TabIndex = 106;
            this.btnF05.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.TabIndex = 105;
            this.btnF04.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.TabIndex = 104;
            this.btnF03.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF02
            // 
            this.btnF02.TabIndex = 103;
            this.btnF02.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // txtKaisyaCode
            // 
            this.txtKaisyaCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKaisyaCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtKaisyaCode.Location = new System.Drawing.Point(295, 105);
            this.txtKaisyaCode.MaxLength = 2;
            this.txtKaisyaCode.Name = "txtKaisyaCode";
            this.txtKaisyaCode.Size = new System.Drawing.Size(24, 22);
            this.txtKaisyaCode.TabIndex = 0;
            this.txtKaisyaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judKaishajyoDetailsKeyDown);
            this.txtKaisyaCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtKeyUp);
            this.txtKaisyaCode.Leave += new System.EventHandler(this.getKaishajyokenLeave);
            // 
            // txtKaishaName
            // 
            this.txtKaishaName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKaishaName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKaishaName.Location = new System.Drawing.Point(540, 105);
            this.txtKaishaName.MaxLength = 40;
            this.txtKaishaName.Name = "txtKaishaName";
            this.txtKaishaName.Size = new System.Drawing.Size(330, 22);
            this.txtKaishaName.TabIndex = 1;
            this.txtKaishaName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judKaishajyoDetailsKeyDown);
            this.txtKaishaName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtKeyUp);
            // 
            // txtYubinNum
            // 
            this.txtYubinNum.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYubinNum.Location = new System.Drawing.Point(540, 133);
            this.txtYubinNum.MaxLength = 8;
            this.txtYubinNum.Name = "txtYubinNum";
            this.txtYubinNum.Size = new System.Drawing.Size(70, 22);
            this.txtYubinNum.TabIndex = 2;
            this.txtYubinNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judKaishajyoDetailsKeyDown);
            this.txtYubinNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtKeyUp);
            // 
            // txtJyusyo1
            // 
            this.txtJyusyo1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtJyusyo1.Location = new System.Drawing.Point(540, 160);
            this.txtJyusyo1.MaxLength = 40;
            this.txtJyusyo1.Name = "txtJyusyo1";
            this.txtJyusyo1.Size = new System.Drawing.Size(330, 22);
            this.txtJyusyo1.TabIndex = 3;
            this.txtJyusyo1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judKaishajyoDetailsKeyDown);
            this.txtJyusyo1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtKeyUp);
            // 
            // txtJyusyo2
            // 
            this.txtJyusyo2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtJyusyo2.Location = new System.Drawing.Point(540, 188);
            this.txtJyusyo2.MaxLength = 40;
            this.txtJyusyo2.Name = "txtJyusyo2";
            this.txtJyusyo2.Size = new System.Drawing.Size(330, 22);
            this.txtJyusyo2.TabIndex = 4;
            this.txtJyusyo2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judKaishajyoDetailsKeyDown);
            this.txtJyusyo2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtKeyUp);
            // 
            // txtDaihyosyaName
            // 
            this.txtDaihyosyaName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDaihyosyaName.Location = new System.Drawing.Point(540, 216);
            this.txtDaihyosyaName.MaxLength = 40;
            this.txtDaihyosyaName.Name = "txtDaihyosyaName";
            this.txtDaihyosyaName.Size = new System.Drawing.Size(330, 22);
            this.txtDaihyosyaName.TabIndex = 5;
            this.txtDaihyosyaName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judKaishajyoDetailsKeyDown);
            this.txtDaihyosyaName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtKeyUp);
            // 
            // txtDennwaNum
            // 
            this.txtDennwaNum.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDennwaNum.Location = new System.Drawing.Point(540, 244);
            this.txtDennwaNum.MaxLength = 12;
            this.txtDennwaNum.Name = "txtDennwaNum";
            this.txtDennwaNum.Size = new System.Drawing.Size(110, 22);
            this.txtDennwaNum.TabIndex = 6;
            this.txtDennwaNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judKaishajyoDetailsKeyDown);
            this.txtDennwaNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtKeyUp);
            // 
            // txtGetumatsusimebi
            // 
            this.txtGetumatsusimebi.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtGetumatsusimebi.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtGetumatsusimebi.Location = new System.Drawing.Point(540, 301);
            this.txtGetumatsusimebi.MaxLength = 2;
            this.txtGetumatsusimebi.Name = "txtGetumatsusimebi";
            this.txtGetumatsusimebi.Size = new System.Drawing.Size(24, 22);
            this.txtGetumatsusimebi.TabIndex = 8;
            this.txtGetumatsusimebi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGetumatsusimebiKeyDown);
            this.txtGetumatsusimebi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGetumatsusimebi_KeyPress);
            this.txtGetumatsusimebi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtKeyUp);
            // 
            // lblKaisyaCode
            // 
            this.lblKaisyaCode.AutoSize = true;
            this.lblKaisyaCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKaisyaCode.Location = new System.Drawing.Point(202, 105);
            this.lblKaisyaCode.Name = "lblKaisyaCode";
            this.lblKaisyaCode.Size = new System.Drawing.Size(87, 15);
            this.lblKaisyaCode.strToolTip = null;
            this.lblKaisyaCode.TabIndex = 90;
            this.lblKaisyaCode.Text = "会社コード";
            this.lblKaisyaCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKaisyaName
            // 
            this.lblKaisyaName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKaisyaName.Location = new System.Drawing.Point(431, 108);
            this.lblKaisyaName.Name = "lblKaisyaName";
            this.lblKaisyaName.Size = new System.Drawing.Size(87, 15);
            this.lblKaisyaName.strToolTip = null;
            this.lblKaisyaName.TabIndex = 91;
            this.lblKaisyaName.Text = "会社名";
            this.lblKaisyaName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblYubinNum
            // 
            this.lblYubinNum.AutoSize = true;
            this.lblYubinNum.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblYubinNum.Location = new System.Drawing.Point(431, 133);
            this.lblYubinNum.Name = "lblYubinNum";
            this.lblYubinNum.Size = new System.Drawing.Size(71, 15);
            this.lblYubinNum.strToolTip = null;
            this.lblYubinNum.TabIndex = 92;
            this.lblYubinNum.Text = "郵便番号";
            this.lblYubinNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJyusyo1
            // 
            this.lblJyusyo1.AutoSize = true;
            this.lblJyusyo1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblJyusyo1.Location = new System.Drawing.Point(431, 163);
            this.lblJyusyo1.Name = "lblJyusyo1";
            this.lblJyusyo1.Size = new System.Drawing.Size(55, 15);
            this.lblJyusyo1.strToolTip = null;
            this.lblJyusyo1.TabIndex = 93;
            this.lblJyusyo1.Text = "住所１";
            this.lblJyusyo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJyusyo2
            // 
            this.lblJyusyo2.AutoSize = true;
            this.lblJyusyo2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblJyusyo2.Location = new System.Drawing.Point(431, 191);
            this.lblJyusyo2.Name = "lblJyusyo2";
            this.lblJyusyo2.Size = new System.Drawing.Size(55, 15);
            this.lblJyusyo2.strToolTip = null;
            this.lblJyusyo2.TabIndex = 94;
            this.lblJyusyo2.Text = "住所２";
            this.lblJyusyo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDaihyosyaName
            // 
            this.lblDaihyosyaName.AutoSize = true;
            this.lblDaihyosyaName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDaihyosyaName.Location = new System.Drawing.Point(431, 219);
            this.lblDaihyosyaName.Name = "lblDaihyosyaName";
            this.lblDaihyosyaName.Size = new System.Drawing.Size(55, 15);
            this.lblDaihyosyaName.strToolTip = null;
            this.lblDaihyosyaName.TabIndex = 95;
            this.lblDaihyosyaName.Text = "代表者";
            this.lblDaihyosyaName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDennwaNum
            // 
            this.lblDennwaNum.AutoSize = true;
            this.lblDennwaNum.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDennwaNum.Location = new System.Drawing.Point(431, 247);
            this.lblDennwaNum.Name = "lblDennwaNum";
            this.lblDennwaNum.Size = new System.Drawing.Size(71, 15);
            this.lblDennwaNum.strToolTip = null;
            this.lblDennwaNum.TabIndex = 96;
            this.lblDennwaNum.Text = "電話番号";
            this.lblDennwaNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGetumatsusimebi
            // 
            this.lblGetumatsusimebi.AutoSize = true;
            this.lblGetumatsusimebi.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblGetumatsusimebi.Location = new System.Drawing.Point(431, 304);
            this.lblGetumatsusimebi.Name = "lblGetumatsusimebi";
            this.lblGetumatsusimebi.Size = new System.Drawing.Size(71, 15);
            this.lblGetumatsusimebi.strToolTip = null;
            this.lblGetumatsusimebi.TabIndex = 98;
            this.lblGetumatsusimebi.Text = "月末締日";
            this.lblGetumatsusimebi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFaxNum
            // 
            this.lblFaxNum.AutoSize = true;
            this.lblFaxNum.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblFaxNum.Location = new System.Drawing.Point(431, 276);
            this.lblFaxNum.Name = "lblFaxNum";
            this.lblFaxNum.Size = new System.Drawing.Size(87, 15);
            this.lblFaxNum.strToolTip = null;
            this.lblFaxNum.TabIndex = 97;
            this.lblFaxNum.Text = "ＦＡＸ番号";
            this.lblFaxNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFaxNum
            // 
            this.txtFaxNum.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtFaxNum.Location = new System.Drawing.Point(540, 273);
            this.txtFaxNum.MaxLength = 12;
            this.txtFaxNum.Name = "txtFaxNum";
            this.txtFaxNum.Size = new System.Drawing.Size(110, 22);
            this.txtFaxNum.TabIndex = 7;
            this.txtFaxNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judKaishajyoDetailsKeyDown);
            this.txtFaxNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtKeyUp);
            // 
            // lblKaishiYMD
            // 
            this.lblKaishiYMD.AutoSize = true;
            this.lblKaishiYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKaishiYMD.Location = new System.Drawing.Point(52, 41);
            this.lblKaishiYMD.Name = "lblKaishiYMD";
            this.lblKaishiYMD.Size = new System.Drawing.Size(87, 15);
            this.lblKaishiYMD.strToolTip = null;
            this.lblKaishiYMD.TabIndex = 100;
            this.lblKaishiYMD.Text = "開始年月日";
            this.lblKaishiYMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKaishiYMD.Visible = false;
            // 
            // gbKaikeikimatsu
            // 
            this.gbKaikeikimatsu.Controls.Add(this.txtShuryouYMD);
            this.gbKaikeikimatsu.Controls.Add(this.lblShuryouYMD);
            this.gbKaikeikimatsu.Controls.Add(this.txtKaishiYMD);
            this.gbKaikeikimatsu.Controls.Add(this.lblKaishiYMD);
            this.gbKaikeikimatsu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gbKaikeikimatsu.Location = new System.Drawing.Point(434, 329);
            this.gbKaikeikimatsu.Name = "gbKaikeikimatsu";
            this.gbKaikeikimatsu.Size = new System.Drawing.Size(564, 83);
            this.gbKaikeikimatsu.TabIndex = 99;
            this.gbKaikeikimatsu.TabStop = false;
            this.gbKaikeikimatsu.Text = "会計期間";
            // 
            // txtShuryouYMD
            // 
            this.txtShuryouYMD.BackColor = System.Drawing.SystemColors.Window;
            this.txtShuryouYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShuryouYMD.Location = new System.Drawing.Point(387, 34);
            this.txtShuryouYMD.Name = "txtShuryouYMD";
            this.txtShuryouYMD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShuryouYMD.Size = new System.Drawing.Size(90, 22);
            this.txtShuryouYMD.TabIndex = 81;
            this.txtShuryouYMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtShuryouYMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judKaishajyoDetailsKeyDown);
            this.txtShuryouYMD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtKeyUp);
            // 
            // lblShuryouYMD
            // 
            this.lblShuryouYMD.AutoSize = true;
            this.lblShuryouYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblShuryouYMD.Location = new System.Drawing.Point(294, 37);
            this.lblShuryouYMD.Name = "lblShuryouYMD";
            this.lblShuryouYMD.Size = new System.Drawing.Size(87, 15);
            this.lblShuryouYMD.strToolTip = null;
            this.lblShuryouYMD.TabIndex = 101;
            this.lblShuryouYMD.Text = "終了年月日";
            this.lblShuryouYMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShuryouYMD.Visible = false;
            // 
            // txtKaishiYMD
            // 
            this.txtKaishiYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKaishiYMD.Location = new System.Drawing.Point(145, 37);
            this.txtKaishiYMD.Name = "txtKaishiYMD";
            this.txtKaishiYMD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtKaishiYMD.Size = new System.Drawing.Size(90, 22);
            this.txtKaishiYMD.TabIndex = 80;
            this.txtKaishiYMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKaishiYMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judKaishajyoDetailsKeyDown);
            this.txtKaishiYMD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtKeyUp);
            // 
            // M1000_Kaishajyoken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 826);
            this.Controls.Add(this.lblFaxNum);
            this.Controls.Add(this.txtFaxNum);
            this.Controls.Add(this.lblGetumatsusimebi);
            this.Controls.Add(this.lblDennwaNum);
            this.Controls.Add(this.lblDaihyosyaName);
            this.Controls.Add(this.lblJyusyo2);
            this.Controls.Add(this.lblJyusyo1);
            this.Controls.Add(this.lblYubinNum);
            this.Controls.Add(this.lblKaisyaName);
            this.Controls.Add(this.lblKaisyaCode);
            this.Controls.Add(this.txtGetumatsusimebi);
            this.Controls.Add(this.txtDennwaNum);
            this.Controls.Add(this.txtDaihyosyaName);
            this.Controls.Add(this.txtJyusyo2);
            this.Controls.Add(this.txtJyusyo1);
            this.Controls.Add(this.txtYubinNum);
            this.Controls.Add(this.txtKaishaName);
            this.Controls.Add(this.txtKaisyaCode);
            this.Controls.Add(this.gbKaikeikimatsu);
            this.Name = "M1000_Kaishajyoken";
            this.Text = " ";
            this.Load += new System.EventHandler(this.M1000_Kaishajyoken_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judKaisyaCodeKeyDown);
            this.Controls.SetChildIndex(this.cmbSubWinShow, 0);
            this.Controls.SetChildIndex(this.gbKaikeikimatsu, 0);
            this.Controls.SetChildIndex(this.txtKaisyaCode, 0);
            this.Controls.SetChildIndex(this.txtKaishaName, 0);
            this.Controls.SetChildIndex(this.txtYubinNum, 0);
            this.Controls.SetChildIndex(this.txtJyusyo1, 0);
            this.Controls.SetChildIndex(this.txtJyusyo2, 0);
            this.Controls.SetChildIndex(this.txtDaihyosyaName, 0);
            this.Controls.SetChildIndex(this.txtDennwaNum, 0);
            this.Controls.SetChildIndex(this.txtGetumatsusimebi, 0);
            this.Controls.SetChildIndex(this.lblKaisyaCode, 0);
            this.Controls.SetChildIndex(this.lblKaisyaName, 0);
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
            this.Controls.SetChildIndex(this.lblYubinNum, 0);
            this.Controls.SetChildIndex(this.lblJyusyo1, 0);
            this.Controls.SetChildIndex(this.lblJyusyo2, 0);
            this.Controls.SetChildIndex(this.lblDaihyosyaName, 0);
            this.Controls.SetChildIndex(this.lblDennwaNum, 0);
            this.Controls.SetChildIndex(this.lblGetumatsusimebi, 0);
            this.Controls.SetChildIndex(this.txtFaxNum, 0);
            this.Controls.SetChildIndex(this.lblFaxNum, 0);
            this.gbKaikeikimatsu.ResumeLayout(false);
            this.gbKaikeikimatsu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BaseText txtKaisyaCode;
        private BaseText txtKaishaName;
        private BaseText txtYubinNum;
        private BaseText txtJyusyo1;
        private BaseText txtJyusyo2;
        private BaseText txtDaihyosyaName;
        private BaseText txtDennwaNum;
        private BaseText txtGetumatsusimebi;
        private BaseLabel lblKaisyaCode;
        private BaseLabel lblKaisyaName;
        private BaseLabel lblYubinNum;
        private BaseLabel lblJyusyo1;
        private BaseLabel lblJyusyo2;
        private BaseLabel lblDaihyosyaName;
        private BaseLabel lblDennwaNum;
        private BaseLabel lblGetumatsusimebi;
        private BaseLabel lblFaxNum;
        private BaseText txtFaxNum;
        private BaseLabel lblKaishiYMD;
        private System.Windows.Forms.GroupBox gbKaikeikimatsu;
        private BaseCalendar txtShuryouYMD;
        private BaseLabel lblShuryouYMD;
        private BaseCalendar txtKaishiYMD;
    }
}