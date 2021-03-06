﻿namespace KATO.Form.M1040_Torihikikbn
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
            this.lblName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblCD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTorihikikubunName = new KATO.Common.Ctl.BaseText();
            this.txtTorihikikubunCd = new KATO.Common.Ctl.BaseText();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
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
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblName.Location = new System.Drawing.Point(630, 93);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 15);
            this.lblName.strToolTip = null;
            this.lblName.TabIndex = 87;
            this.lblName.Text = "取引区分名";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCD
            // 
            this.lblCD.AutoSize = true;
            this.lblCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblCD.Location = new System.Drawing.Point(391, 93);
            this.lblCD.Name = "lblCD";
            this.lblCD.Size = new System.Drawing.Size(119, 15);
            this.lblCD.strToolTip = null;
            this.lblCD.TabIndex = 90;
            this.lblCD.Text = "取引区分コード";
            this.lblCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTorihikikubunName
            // 
            this.txtTorihikikubunName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTorihikikubunName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTorihikikubunName.Location = new System.Drawing.Point(729, 90);
            this.txtTorihikikubunName.MaxLength = 20;
            this.txtTorihikikubunName.Name = "txtTorihikikubunName";
            this.txtTorihikikubunName.Size = new System.Drawing.Size(170, 22);
            this.txtTorihikikubunName.TabIndex = 1;
            this.txtTorihikikubunName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTorikbnTxtKeyDown);
            // 
            // txtTorihikikubunCd
            // 
            this.txtTorihikikubunCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTorihikikubunCd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtTorihikikubunCd.Location = new System.Drawing.Point(517, 90);
            this.txtTorihikikubunCd.MaxLength = 2;
            this.txtTorihikikubunCd.Name = "txtTorihikikubunCd";
            this.txtTorihikikubunCd.Size = new System.Drawing.Size(24, 22);
            this.txtTorihikikubunCd.TabIndex = 0;
            this.txtTorihikikubunCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtTorikbnTxtKeyDown);
            this.txtTorihikikubunCd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtToriKeyUp);
            this.txtTorihikikubunCd.Leave += new System.EventHandler(this.setTxtToriLeave);
            // 
            // M1040_Torihikikbn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 826);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCD);
            this.Controls.Add(this.txtTorihikikubunName);
            this.Controls.Add(this.txtTorihikikubunCd);
            this.Name = "M1040_Torihikikbn";
            this.Text = "M1040_Torihikikbn";
            this.Load += new System.EventHandler(this.M1040_Torihikikubun_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTorikbnKeyDown);
            this.Controls.SetChildIndex(this.cmbSubWinShow, 0);
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
            this.Controls.SetChildIndex(this.txtTorihikikubunCd, 0);
            this.Controls.SetChildIndex(this.txtTorihikikubunName, 0);
            this.Controls.SetChildIndex(this.lblCD, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseLabel lblName;
        private Common.Ctl.BaseLabel lblCD;
        private Common.Ctl.BaseText txtTorihikikubunName;
        private Common.Ctl.BaseText txtTorihikikubunCd;
    }
}