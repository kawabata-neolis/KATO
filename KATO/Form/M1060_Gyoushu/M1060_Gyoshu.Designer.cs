namespace KATO.Form.M1060_Gyoushu
{
    partial class M1060_Gyoshu
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
            this.txtGyoshu = new KATO.Common.Ctl.BaseText();
            this.lblBaseLabelCD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtName = new KATO.Common.Ctl.BaseText();
            this.lblBaseLabelName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.SuspendLayout();
            // 
            // btnF12
            // 
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            this.btnF12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // btnF11
            // 
            this.btnF11.Click += new System.EventHandler(this.judBtnClick);
            this.btnF11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // btnF10
            // 
            this.btnF10.Click += new System.EventHandler(this.judBtnClick);
            this.btnF10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // btnF09
            // 
            this.btnF09.Click += new System.EventHandler(this.judBtnClick);
            this.btnF09.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // btnF08
            // 
            this.btnF08.Click += new System.EventHandler(this.judBtnClick);
            this.btnF08.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // btnF07
            // 
            this.btnF07.Click += new System.EventHandler(this.judBtnClick);
            this.btnF07.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // btnF06
            // 
            this.btnF06.Click += new System.EventHandler(this.judBtnClick);
            this.btnF06.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // btnF05
            // 
            this.btnF05.Click += new System.EventHandler(this.judBtnClick);
            this.btnF05.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // btnF04
            // 
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            this.btnF04.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // btnF03
            // 
            this.btnF03.Click += new System.EventHandler(this.judBtnClick);
            this.btnF03.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // btnF02
            // 
            this.btnF02.Click += new System.EventHandler(this.judBtnClick);
            this.btnF02.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            this.btnF01.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            // 
            // txtGyoshu
            // 
            this.txtGyoshu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtGyoshu.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtGyoshu.Location = new System.Drawing.Point(502, 109);
            this.txtGyoshu.MaxLength = 4;
            this.txtGyoshu.Name = "txtGyoshu";
            this.txtGyoshu.Size = new System.Drawing.Size(40, 22);
            this.txtGyoshu.TabIndex = 0;
            this.txtGyoshu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGyoshuTxtKeyDown);
            this.txtGyoshu.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtGyoushuKeyUp);
            this.txtGyoshu.Leave += new System.EventHandler(this.updTxtGyoshuLeave);
            // 
            // lblBaseLabelCD
            // 
            this.lblBaseLabelCD.AutoSize = true;
            this.lblBaseLabelCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabelCD.Location = new System.Drawing.Point(388, 112);
            this.lblBaseLabelCD.Name = "lblBaseLabelCD";
            this.lblBaseLabelCD.Size = new System.Drawing.Size(87, 15);
            this.lblBaseLabelCD.TabIndex = 88;
            this.lblBaseLabelCD.Text = "業種コード";
            this.lblBaseLabelCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtName.Location = new System.Drawing.Point(756, 109);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(252, 22);
            this.txtName.TabIndex = 1;
            // 
            // lblBaseLabelName
            // 
            this.lblBaseLabelName.AutoSize = true;
            this.lblBaseLabelName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabelName.Location = new System.Drawing.Point(656, 112);
            this.lblBaseLabelName.Name = "lblBaseLabelName";
            this.lblBaseLabelName.Size = new System.Drawing.Size(55, 15);
            this.lblBaseLabelName.TabIndex = 88;
            this.lblBaseLabelName.Text = "業種名";
            this.lblBaseLabelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // M1060_Gyoshu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.lblBaseLabelName);
            this.Controls.Add(this.lblBaseLabelCD);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtGyoshu);
            this.Name = "M1060_Gyoshu";
            this.Text = "M1060_Gyoushu";
            this.Load += new System.EventHandler(this.M1060_Gyoushu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGyoshuKeyDown);
            this.Controls.SetChildIndex(this.txtGyoshu, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblBaseLabelCD, 0);
            this.Controls.SetChildIndex(this.lblBaseLabelName, 0);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseText txtGyoshu;
        private Common.Ctl.BaseLabel lblBaseLabelCD;
        private Common.Ctl.BaseText txtName;
        private Common.Ctl.BaseLabel lblBaseLabelName;
    }
}