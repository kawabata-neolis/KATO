namespace KATO.Form.M1090_Eigyosho
{
    partial class M1090_Eigyosho
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
            this.txtEigyoshoCd = new KATO.Common.Ctl.BaseText();
            this.txtEigyoshoName = new KATO.Common.Ctl.BaseText();
            this.lblEigyoshoName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lbl = new KATO.Common.Ctl.BaseLabel(this.components);
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
            // txtEigyoshoCd
            // 
            this.txtEigyoshoCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtEigyoshoCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtEigyoshoCd.Location = new System.Drawing.Point(552, 141);
            this.txtEigyoshoCd.MaxLength = 4;
            this.txtEigyoshoCd.Name = "txtEigyoshoCd";
            this.txtEigyoshoCd.Size = new System.Drawing.Size(40, 22);
            this.txtEigyoshoCd.TabIndex = 0;
            this.txtEigyoshoCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEigyoshoCd_KeyDown);
            this.txtEigyoshoCd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtEigyoKeyUp);
            this.txtEigyoshoCd.Leave += new System.EventHandler(this.setTxtEigyoTxtLeave);
            // 
            // txtEigyoshoName
            // 
            this.txtEigyoshoName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtEigyoshoName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtEigyoshoName.Location = new System.Drawing.Point(717, 141);
            this.txtEigyoshoName.MaxLength = 30;
            this.txtEigyoshoName.Name = "txtEigyoshoName";
            this.txtEigyoshoName.Size = new System.Drawing.Size(250, 22);
            this.txtEigyoshoName.TabIndex = 1;
            this.txtEigyoshoName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judEigyoTxtKeyDown);
            this.txtEigyoshoName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtEigyoKeyUp);
            // 
            // lblEigyoshoName
            // 
            this.lblEigyoshoName.AutoSize = true;
            this.lblEigyoshoName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblEigyoshoName.Location = new System.Drawing.Point(640, 144);
            this.lblEigyoshoName.Name = "lblEigyoshoName";
            this.lblEigyoshoName.Size = new System.Drawing.Size(71, 15);
            this.lblEigyoshoName.TabIndex = 88;
            this.lblEigyoshoName.Text = "営業所名";
            this.lblEigyoshoName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl.Location = new System.Drawing.Point(443, 144);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(103, 15);
            this.lbl.TabIndex = 88;
            this.lbl.Text = "営業所コード";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // M1090_Eigyosho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblEigyoshoName);
            this.Controls.Add(this.txtEigyoshoName);
            this.Controls.Add(this.txtEigyoshoCd);
            this.Name = "M1090_Eigyosho";
            this.Text = "M1090_Eigyosho";
            this.Load += new System.EventHandler(this.M1090_Eigyosho_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1090_Eigyosho_KeyDown);
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
            this.Controls.SetChildIndex(this.txtEigyoshoCd, 0);
            this.Controls.SetChildIndex(this.txtEigyoshoName, 0);
            this.Controls.SetChildIndex(this.lblEigyoshoName, 0);
            this.Controls.SetChildIndex(this.lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseText txtEigyoshoCd;
        private Common.Ctl.BaseText txtEigyoshoName;
        private Common.Ctl.BaseLabel lblEigyoshoName;
        private Common.Ctl.BaseLabel lbl;
    }
}