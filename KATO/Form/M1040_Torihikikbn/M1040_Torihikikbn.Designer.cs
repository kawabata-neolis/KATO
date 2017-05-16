namespace KATO.Form.M1040_Torihikikbn
{
    partial class M1040_Torihikikbn
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
            this.lblBaseLabelName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblBaseLabelCD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtName = new KATO.Common.Ctl.BaseText();
            this.txtTorihikikubun = new KATO.Common.Ctl.BaseText();
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
            // lblBaseLabelName
            // 
            this.lblBaseLabelName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabelName.Location = new System.Drawing.Point(630, 93);
            this.lblBaseLabelName.Name = "lblBaseLabelName";
            this.lblBaseLabelName.Size = new System.Drawing.Size(87, 15);
            this.lblBaseLabelName.TabIndex = 87;
            this.lblBaseLabelName.Text = "取引区分名";
            this.lblBaseLabelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaseLabelCD
            // 
            this.lblBaseLabelCD.AutoSize = true;
            this.lblBaseLabelCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabelCD.Location = new System.Drawing.Point(391, 93);
            this.lblBaseLabelCD.Name = "lblBaseLabelCD";
            this.lblBaseLabelCD.Size = new System.Drawing.Size(119, 15);
            this.lblBaseLabelCD.TabIndex = 90;
            this.lblBaseLabelCD.Text = "取引区分コード";
            this.lblBaseLabelCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtName.Location = new System.Drawing.Point(729, 90);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(336, 22);
            this.txtName.TabIndex = 1;
            // 
            // txtTorihikikubun
            // 
            this.txtTorihikikubun.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTorihikikubun.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTorihikikubun.Location = new System.Drawing.Point(517, 90);
            this.txtTorihikikubun.MaxLength = 2;
            this.txtTorihikikubun.Name = "txtTorihikikubun";
            this.txtTorihikikubun.Size = new System.Drawing.Size(24, 22);
            this.txtTorihikikubun.TabIndex = 0;
            this.txtTorihikikubun.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtToriKeyDown);
            this.txtTorihikikubun.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtToriKeyUp);
            this.txtTorihikikubun.Leave += new System.EventHandler(this.updTxtToriLeave);
            // 
            // M1040_Torihikikbn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.lblBaseLabelName);
            this.Controls.Add(this.lblBaseLabelCD);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtTorihikikubun);
            this.Name = "M1040_Torihikikbn";
            this.Text = "M1040_Torihikikbn";
            this.Load += new System.EventHandler(this.M1040_Torihikikubun_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTorikubunKeyDown);
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
            this.Controls.SetChildIndex(this.txtTorihikikubun, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblBaseLabelCD, 0);
            this.Controls.SetChildIndex(this.lblBaseLabelName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseLabel lblBaseLabelName;
        private Common.Ctl.BaseLabel lblBaseLabelCD;
        private Common.Ctl.BaseText txtName;
        private Common.Ctl.BaseText txtTorihikikubun;
    }
}