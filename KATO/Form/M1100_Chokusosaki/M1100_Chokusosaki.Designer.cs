namespace KATO.Form.M1100_Chokusosaki
{
    partial class M1100_Chokusosaki
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
            this.labelSet_Tokuisaki = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.txtChokusoCd = new KATO.Common.Ctl.BaseText();
            this.lblChokusoCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblChokusoName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblYubin = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblJusho1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblJusho2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblDenwa = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtChokusoName = new KATO.Common.Ctl.BaseText();
            this.txtYubin = new KATO.Common.Ctl.BaseText();
            this.txtJusho1 = new KATO.Common.Ctl.BaseText();
            this.txtJusho2 = new KATO.Common.Ctl.BaseText();
            this.txtDenwa = new KATO.Common.Ctl.BaseText();
            this.txtBushoName = new KATO.Common.Ctl.BaseText();
            this.lblBushoName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.SuspendLayout();
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
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // labelSet_Tokuisaki
            // 
            this.labelSet_Tokuisaki.AppendLabelSize = 40;
            this.labelSet_Tokuisaki.AppendLabelText = "";
            this.labelSet_Tokuisaki.CodeTxtSize = 40;
            this.labelSet_Tokuisaki.CodeTxtText = "";
            this.labelSet_Tokuisaki.LabelName = "得意先コード";
            this.labelSet_Tokuisaki.Location = new System.Drawing.Point(389, 107);
            this.labelSet_Tokuisaki.Name = "labelSet_Tokuisaki";
            this.labelSet_Tokuisaki.ShowAppendFlg = false;
            this.labelSet_Tokuisaki.Size = new System.Drawing.Size(642, 22);
            this.labelSet_Tokuisaki.SpaceCodeValue = 20;
            this.labelSet_Tokuisaki.SpaceNameCode = 4;
            this.labelSet_Tokuisaki.SpaceValueAppend = 4;
            this.labelSet_Tokuisaki.TabIndex = 0;
            this.labelSet_Tokuisaki.ValueLabelSize = 330;
            this.labelSet_Tokuisaki.ValueLabelText = "";
            // 
            // txtChokusoCd
            // 
            this.txtChokusoCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtChokusoCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtChokusoCd.Location = new System.Drawing.Point(496, 145);
            this.txtChokusoCd.MaxLength = 4;
            this.txtChokusoCd.Name = "txtChokusoCd";
            this.txtChokusoCd.Size = new System.Drawing.Size(40, 22);
            this.txtChokusoCd.TabIndex = 1;
            this.txtChokusoCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtChoTxtKeyDown);
            this.txtChokusoCd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtChokuKeyUp);
            this.txtChokusoCd.Leave += new System.EventHandler(this.updTxtChokuTxtLeave);
            // 
            // lblChokusoCd
            // 
            this.lblChokusoCd.AutoSize = true;
            this.lblChokusoCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblChokusoCd.Location = new System.Drawing.Point(391, 148);
            this.lblChokusoCd.Name = "lblChokusoCd";
            this.lblChokusoCd.Size = new System.Drawing.Size(103, 15);
            this.lblChokusoCd.strToolTip = null;
            this.lblChokusoCd.TabIndex = 89;
            this.lblChokusoCd.Text = "直送先コード";
            this.lblChokusoCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChokusoName
            // 
            this.lblChokusoName.AutoSize = true;
            this.lblChokusoName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblChokusoName.Location = new System.Drawing.Point(555, 148);
            this.lblChokusoName.Name = "lblChokusoName";
            this.lblChokusoName.Size = new System.Drawing.Size(87, 15);
            this.lblChokusoName.strToolTip = null;
            this.lblChokusoName.TabIndex = 89;
            this.lblChokusoName.Text = "直送先名称";
            this.lblChokusoName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblYubin
            // 
            this.lblYubin.AutoSize = true;
            this.lblYubin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblYubin.Location = new System.Drawing.Point(555, 177);
            this.lblYubin.Name = "lblYubin";
            this.lblYubin.Size = new System.Drawing.Size(71, 15);
            this.lblYubin.strToolTip = null;
            this.lblYubin.TabIndex = 89;
            this.lblYubin.Text = "郵便番号";
            this.lblYubin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJusho1
            // 
            this.lblJusho1.AutoSize = true;
            this.lblJusho1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblJusho1.Location = new System.Drawing.Point(555, 205);
            this.lblJusho1.Name = "lblJusho1";
            this.lblJusho1.Size = new System.Drawing.Size(55, 15);
            this.lblJusho1.strToolTip = null;
            this.lblJusho1.TabIndex = 89;
            this.lblJusho1.Text = "住所１";
            this.lblJusho1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJusho2
            // 
            this.lblJusho2.AutoSize = true;
            this.lblJusho2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblJusho2.Location = new System.Drawing.Point(555, 233);
            this.lblJusho2.Name = "lblJusho2";
            this.lblJusho2.Size = new System.Drawing.Size(55, 15);
            this.lblJusho2.strToolTip = null;
            this.lblJusho2.TabIndex = 89;
            this.lblJusho2.Text = "住所２";
            this.lblJusho2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDenwa
            // 
            this.lblDenwa.AutoSize = true;
            this.lblDenwa.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDenwa.Location = new System.Drawing.Point(555, 262);
            this.lblDenwa.Name = "lblDenwa";
            this.lblDenwa.Size = new System.Drawing.Size(71, 15);
            this.lblDenwa.strToolTip = null;
            this.lblDenwa.TabIndex = 89;
            this.lblDenwa.Text = "電話番号";
            this.lblDenwa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChokusoName
            // 
            this.txtChokusoName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtChokusoName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtChokusoName.Location = new System.Drawing.Point(648, 145);
            this.txtChokusoName.MaxLength = 30;
            this.txtChokusoName.Name = "txtChokusoName";
            this.txtChokusoName.Size = new System.Drawing.Size(250, 22);
            this.txtChokusoName.TabIndex = 2;
            this.txtChokusoName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChokuTxtKeyDown);
            this.txtChokusoName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtChokuKeyUp);
            // 
            // txtYubin
            // 
            this.txtYubin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYubin.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtYubin.Location = new System.Drawing.Point(648, 174);
            this.txtYubin.MaxLength = 8;
            this.txtYubin.Name = "txtYubin";
            this.txtYubin.Size = new System.Drawing.Size(75, 22);
            this.txtYubin.TabIndex = 3;
            this.txtYubin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChokuTxtKeyDown);
            this.txtYubin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtChokuKeyUp);
            // 
            // txtJusho1
            // 
            this.txtJusho1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtJusho1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtJusho1.Location = new System.Drawing.Point(648, 202);
            this.txtJusho1.MaxLength = 30;
            this.txtJusho1.Name = "txtJusho1";
            this.txtJusho1.Size = new System.Drawing.Size(250, 22);
            this.txtJusho1.TabIndex = 4;
            this.txtJusho1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChokuTxtKeyDown);
            this.txtJusho1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtChokuKeyUp);
            // 
            // txtJusho2
            // 
            this.txtJusho2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtJusho2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtJusho2.Location = new System.Drawing.Point(648, 230);
            this.txtJusho2.MaxLength = 30;
            this.txtJusho2.Name = "txtJusho2";
            this.txtJusho2.Size = new System.Drawing.Size(250, 22);
            this.txtJusho2.TabIndex = 5;
            this.txtJusho2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChokuTxtKeyDown);
            this.txtJusho2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtChokuKeyUp);
            // 
            // txtDenwa
            // 
            this.txtDenwa.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDenwa.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDenwa.Location = new System.Drawing.Point(648, 259);
            this.txtDenwa.MaxLength = 12;
            this.txtDenwa.Name = "txtDenwa";
            this.txtDenwa.Size = new System.Drawing.Size(105, 22);
            this.txtDenwa.TabIndex = 6;
            this.txtDenwa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChokuTxtKeyDown);
            this.txtDenwa.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtChokuKeyUp);
            // 
            // txtBushoName
            // 
            this.txtBushoName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtBushoName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtBushoName.Location = new System.Drawing.Point(648, 287);
            this.txtBushoName.MaxLength = 30;
            this.txtBushoName.Name = "txtBushoName";
            this.txtBushoName.Size = new System.Drawing.Size(250, 22);
            this.txtBushoName.TabIndex = 7;
            this.txtBushoName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChokuTxtKeyDown);
            this.txtBushoName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtChokuKeyUp);
            // 
            // lblBushoName
            // 
            this.lblBushoName.AutoSize = true;
            this.lblBushoName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBushoName.Location = new System.Drawing.Point(555, 290);
            this.lblBushoName.Name = "lblBushoName";
            this.lblBushoName.Size = new System.Drawing.Size(55, 15);
            this.lblBushoName.strToolTip = null;
            this.lblBushoName.TabIndex = 89;
            this.lblBushoName.Text = "部署名";
            this.lblBushoName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // M1100_Chokusosaki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.lblBushoName);
            this.Controls.Add(this.lblDenwa);
            this.Controls.Add(this.lblJusho2);
            this.Controls.Add(this.lblJusho1);
            this.Controls.Add(this.lblYubin);
            this.Controls.Add(this.lblChokusoName);
            this.Controls.Add(this.lblChokusoCd);
            this.Controls.Add(this.txtBushoName);
            this.Controls.Add(this.txtDenwa);
            this.Controls.Add(this.txtJusho2);
            this.Controls.Add(this.txtJusho1);
            this.Controls.Add(this.txtYubin);
            this.Controls.Add(this.txtChokusoName);
            this.Controls.Add(this.txtChokusoCd);
            this.Controls.Add(this.labelSet_Tokuisaki);
            this.Name = "M1100_Chokusosaki";
            this.Text = "M1100_Chokusosaki";
            this.Load += new System.EventHandler(this.M1100_Chokusosaki_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1100_Chokusosaki_KeyDown);
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
            this.Controls.SetChildIndex(this.txtChokusoCd, 0);
            this.Controls.SetChildIndex(this.txtChokusoName, 0);
            this.Controls.SetChildIndex(this.txtYubin, 0);
            this.Controls.SetChildIndex(this.txtJusho1, 0);
            this.Controls.SetChildIndex(this.txtJusho2, 0);
            this.Controls.SetChildIndex(this.txtDenwa, 0);
            this.Controls.SetChildIndex(this.txtBushoName, 0);
            this.Controls.SetChildIndex(this.lblChokusoCd, 0);
            this.Controls.SetChildIndex(this.lblChokusoName, 0);
            this.Controls.SetChildIndex(this.lblYubin, 0);
            this.Controls.SetChildIndex(this.lblJusho1, 0);
            this.Controls.SetChildIndex(this.lblJusho2, 0);
            this.Controls.SetChildIndex(this.lblDenwa, 0);
            this.Controls.SetChildIndex(this.lblBushoName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.LabelSet_Tokuisaki labelSet_Tokuisaki;
        private Common.Ctl.BaseText txtChokusoCd;
        private Common.Ctl.BaseLabel lblChokusoCd;
        private Common.Ctl.BaseLabel lblChokusoName;
        private Common.Ctl.BaseLabel lblYubin;
        private Common.Ctl.BaseLabel lblJusho1;
        private Common.Ctl.BaseLabel lblJusho2;
        private Common.Ctl.BaseLabel lblDenwa;
        private Common.Ctl.BaseText txtChokusoName;
        private Common.Ctl.BaseText txtYubin;
        private Common.Ctl.BaseText txtJusho1;
        private Common.Ctl.BaseText txtJusho2;
        private Common.Ctl.BaseText txtDenwa;
        private Common.Ctl.BaseText txtBushoName;
        private Common.Ctl.BaseLabel lblBushoName;
    }
}