using KATO.Common.Ctl;
using KATO.Common.Util;

namespace KATO.Form.M1020_Maker
{
    partial class M1020_Maker
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
            this.txtMaker = new KATO.Common.Ctl.BaseText();
            this.txtName = new KATO.Common.Ctl.BaseText();
            this.lblBaseLabelName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblBaseLabelCD = new KATO.Common.Ctl.BaseLabel(this.components);
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
            // txtMaker
            // 
            this.txtMaker.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtMaker.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMaker.Location = new System.Drawing.Point(596, 97);
            this.txtMaker.MaxLength = 3;
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(30, 22);
            this.txtMaker.TabIndex = 0;
            this.txtMaker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtMakerTxtKeyDown);
            this.txtMaker.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtMakerKeyUp);
            this.txtMaker.Leave += new System.EventHandler(this.updTxtMakerTextLeave);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtName.Location = new System.Drawing.Point(596, 134);
            this.txtName.MaxLength = 24;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judMakerTxtKeyDown);
            // 
            // lblBaseLabelName
            // 
            this.lblBaseLabelName.AutoSize = true;
            this.lblBaseLabelName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabelName.Location = new System.Drawing.Point(471, 137);
            this.lblBaseLabelName.Name = "lblBaseLabelName";
            this.lblBaseLabelName.Size = new System.Drawing.Size(87, 15);
            this.lblBaseLabelName.TabIndex = 87;
            this.lblBaseLabelName.Text = "メーカー名";
            this.lblBaseLabelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaseLabelCD
            // 
            this.lblBaseLabelCD.AutoSize = true;
            this.lblBaseLabelCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabelCD.Location = new System.Drawing.Point(471, 100);
            this.lblBaseLabelCD.Name = "lblBaseLabelCD";
            this.lblBaseLabelCD.Size = new System.Drawing.Size(119, 15);
            this.lblBaseLabelCD.TabIndex = 88;
            this.lblBaseLabelCD.Text = "メーカーコード";
            this.lblBaseLabelCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // M1020_Maker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 828);
            this.Controls.Add(this.lblBaseLabelCD);
            this.Controls.Add(this.lblBaseLabelName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtMaker);
            this.Name = "M1020_Maker";
            this.Text = "M1020_Maker";
            this.Load += new System.EventHandler(this.M_Maker_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judMakerKeyDown);
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
            this.Controls.SetChildIndex(this.txtMaker, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblBaseLabelName, 0);
            this.Controls.SetChildIndex(this.lblBaseLabelCD, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseText txtMaker;
        private BaseText txtName;
        private BaseLabel lblBaseLabelName;
        private BaseLabel lblBaseLabelCD;
    }
}