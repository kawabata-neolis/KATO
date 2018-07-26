namespace KATO.Form.M1120_Tanaban
{
    partial class M1120_Tanaban
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
            this.txtTanabanName = new KATO.Common.Ctl.BaseText();
            this.lblTanabanName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTanabanCd = new KATO.Common.Ctl.BaseText();
            this.lblTanabanCd = new KATO.Common.Ctl.BaseLabel(this.components);
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
            // txtTanabanName
            // 
            this.txtTanabanName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanabanName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTanabanName.Location = new System.Drawing.Point(608, 134);
            this.txtTanabanName.MaxLength = 24;
            this.txtTanabanName.Name = "txtTanabanName";
            this.txtTanabanName.Size = new System.Drawing.Size(200, 22);
            this.txtTanabanName.TabIndex = 1;
            this.txtTanabanName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTanabanName_KeyDown);
            this.txtTanabanName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtTanabanKeyUp);
            // 
            // lblTanabanName
            // 
            this.lblTanabanName.AutoSize = true;
            this.lblTanabanName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTanabanName.Location = new System.Drawing.Point(522, 137);
            this.lblTanabanName.Name = "lblTanabanName";
            this.lblTanabanName.Size = new System.Drawing.Size(55, 15);
            this.lblTanabanName.strToolTip = null;
            this.lblTanabanName.TabIndex = 88;
            this.lblTanabanName.Text = "棚番名";
            this.lblTanabanName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTanabanCd
            // 
            this.txtTanabanCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanabanCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTanabanCd.Location = new System.Drawing.Point(608, 78);
            this.txtTanabanCd.MaxLength = 6;
            this.txtTanabanCd.Name = "txtTanabanCd";
            this.txtTanabanCd.Size = new System.Drawing.Size(55, 22);
            this.txtTanabanCd.TabIndex = 0;
            this.txtTanabanCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTanabanCd_KeyDown);
            this.txtTanabanCd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtTanabanKeyUp);
            this.txtTanabanCd.Leave += new System.EventHandler(this.txtTanabanCd_Leave);
            // 
            // lblTanabanCd
            // 
            this.lblTanabanCd.AutoSize = true;
            this.lblTanabanCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTanabanCd.Location = new System.Drawing.Point(522, 81);
            this.lblTanabanCd.Name = "lblTanabanCd";
            this.lblTanabanCd.Size = new System.Drawing.Size(39, 15);
            this.lblTanabanCd.strToolTip = null;
            this.lblTanabanCd.TabIndex = 88;
            this.lblTanabanCd.Text = "棚番";
            this.lblTanabanCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // M1120_Tanaban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 826);
            this.Controls.Add(this.lblTanabanCd);
            this.Controls.Add(this.lblTanabanName);
            this.Controls.Add(this.txtTanabanCd);
            this.Controls.Add(this.txtTanabanName);
            this.Name = "M1120_Tanaban";
            this.Text = "M1120_Tanaban";
            this.Load += new System.EventHandler(this.M1120_Tanaban_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1120_Tanaban_KeyDown);
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
            this.Controls.SetChildIndex(this.txtTanabanName, 0);
            this.Controls.SetChildIndex(this.txtTanabanCd, 0);
            this.Controls.SetChildIndex(this.lblTanabanName, 0);
            this.Controls.SetChildIndex(this.lblTanabanCd, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseText txtTanabanName;
        private Common.Ctl.BaseLabel lblTanabanName;
        private Common.Ctl.BaseText txtTanabanCd;
        private Common.Ctl.BaseLabel lblTanabanCd;
    }
}