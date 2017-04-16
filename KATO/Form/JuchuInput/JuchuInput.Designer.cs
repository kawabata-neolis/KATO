namespace KATO.Form.JuchuInput
{
    partial class JuchuInput
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
            this.baseText1 = new KATO.Common.Ctl.BaseText();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel3 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseComboBox1 = new KATO.Common.Ctl.BaseComboBox();
            this.baseComboBox2 = new KATO.Common.Ctl.BaseComboBox();
            this.baseLabelGray1 = new KATO.Common.Ctl.BaseLabelGray();
            this.money1 = new KATO.Common.Ctl.Money();
            this.baseLabel4 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.calendar1 = new KATO.Common.Ctl.Calendar();
            this.baseLabel5 = new KATO.Common.Ctl.BaseLabel(this.components);
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
            // baseText1
            // 
            this.baseText1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseText1.Location = new System.Drawing.Point(281, 24);
            this.baseText1.Name = "baseText1";
            this.baseText1.Size = new System.Drawing.Size(100, 22);
            this.baseText1.TabIndex = 85;
            this.baseText1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judJuchuInputKeyDown);
            this.baseText1.Leave += new System.EventHandler(this.baseText1_Leave);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(208, 27);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(71, 15);
            this.baseLabel1.TabIndex = 86;
            this.baseLabel1.Text = "受注番号";
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(228, 184);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(71, 15);
            this.baseLabel2.TabIndex = 86;
            this.baseLabel2.Text = "受注単価";
            // 
            // baseLabel3
            // 
            this.baseLabel3.AutoSize = true;
            this.baseLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel3.Location = new System.Drawing.Point(521, 184);
            this.baseLabel3.Name = "baseLabel3";
            this.baseLabel3.Size = new System.Drawing.Size(71, 15);
            this.baseLabel3.TabIndex = 88;
            this.baseLabel3.Text = "仕入単価";
            // 
            // baseComboBox1
            // 
            this.baseComboBox1.BlankFlg = false;
            this.baseComboBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseComboBox1.FormattingEnabled = true;
            this.baseComboBox1.Location = new System.Drawing.Point(305, 181);
            this.baseComboBox1.Name = "baseComboBox1";
            this.baseComboBox1.Size = new System.Drawing.Size(157, 23);
            this.baseComboBox1.TabIndex = 89;
            this.baseComboBox1.TextChanged += new System.EventHandler(this.baseComboBox1_SelectedIndexChanged);
            // 
            // baseComboBox2
            // 
            this.baseComboBox2.BlankFlg = false;
            this.baseComboBox2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseComboBox2.FormattingEnabled = true;
            this.baseComboBox2.Location = new System.Drawing.Point(598, 181);
            this.baseComboBox2.Name = "baseComboBox2";
            this.baseComboBox2.Size = new System.Drawing.Size(157, 23);
            this.baseComboBox2.TabIndex = 89;
            // 
            // baseLabelGray1
            // 
            this.baseLabelGray1.AutoEllipsis = true;
            this.baseLabelGray1.BackColor = System.Drawing.Color.Gainsboro;
            this.baseLabelGray1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabelGray1.ForeColor = System.Drawing.Color.Blue;
            this.baseLabelGray1.Location = new System.Drawing.Point(260, 236);
            this.baseLabelGray1.Name = "baseLabelGray1";
            this.baseLabelGray1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.baseLabelGray1.Size = new System.Drawing.Size(202, 22);
            this.baseLabelGray1.TabIndex = 99;
            this.baseLabelGray1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // money1
            // 
            this.money1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.money1.Location = new System.Drawing.Point(294, 100);
            this.money1.MaxLength = 9;
            this.money1.Name = "money1";
            this.money1.Size = new System.Drawing.Size(100, 22);
            this.money1.TabIndex = 100;
            this.money1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.money1.Enter += new System.EventHandler(this.money1_Leave);
            this.money1.Leave += new System.EventHandler(this.money1_Leave);
            // 
            // baseLabel4
            // 
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel4.Location = new System.Drawing.Point(73, 103);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(215, 15);
            this.baseLabel4.TabIndex = 86;
            this.baseLabel4.Text = "金額テキストボックステスト";
            // 
            // calendar1
            // 
            this.calendar1.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.calendar1.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.calendar1.FocusedBackColor = System.Drawing.SystemColors.Window;
            this.calendar1.FocusedForeColor = System.Drawing.SystemColors.WindowText;
            this.calendar1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.calendar1.ImeMode = true;
            this.calendar1.Location = new System.Drawing.Point(540, 64);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(100, 22);
            this.calendar1.TabIndex = 101;
            this.calendar1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // baseLabel5
            // 
            this.baseLabel5.AutoSize = true;
            this.baseLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel5.Location = new System.Drawing.Point(335, 67);
            this.baseLabel5.Name = "baseLabel5";
            this.baseLabel5.Size = new System.Drawing.Size(199, 15);
            this.baseLabel5.TabIndex = 86;
            this.baseLabel5.Text = "カレンダーボックステスト";
            // 
            // JuchuInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 831);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.money1);
            this.Controls.Add(this.baseLabelGray1);
            this.Controls.Add(this.baseComboBox2);
            this.Controls.Add(this.baseComboBox1);
            this.Controls.Add(this.baseLabel3);
            this.Controls.Add(this.baseLabel5);
            this.Controls.Add(this.baseLabel4);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.baseText1);
            this.Name = "JuchuInput";
            this.Text = "JuchuInput";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judJuchuInputKeyDown);
            this.Controls.SetChildIndex(this.baseText1, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.baseLabel2, 0);
            this.Controls.SetChildIndex(this.baseLabel4, 0);
            this.Controls.SetChildIndex(this.baseLabel5, 0);
            this.Controls.SetChildIndex(this.baseLabel3, 0);
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
            this.Controls.SetChildIndex(this.baseComboBox1, 0);
            this.Controls.SetChildIndex(this.baseComboBox2, 0);
            this.Controls.SetChildIndex(this.baseLabelGray1, 0);
            this.Controls.SetChildIndex(this.money1, 0);
            this.Controls.SetChildIndex(this.calendar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseText baseText1;
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.BaseLabel baseLabel2;
        private Common.Ctl.BaseLabel baseLabel3;
        private Common.Ctl.BaseComboBox baseComboBox1;
        private Common.Ctl.BaseComboBox baseComboBox2;
        private Common.Ctl.BaseLabelGray baseLabelGray1;
        private Common.Ctl.Money money1;
        private Common.Ctl.BaseLabel baseLabel4;
        private Common.Ctl.Calendar calendar1;
        private Common.Ctl.BaseLabel baseLabel5;
    }
}