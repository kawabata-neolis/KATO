﻿using KATO.Common.Ctl;
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
            this.lblName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblCD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtNameKana = new KATO.Common.Ctl.BaseText();
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
            // txtMaker
            // 
            this.txtMaker.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtMaker.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMaker.Location = new System.Drawing.Point(596, 97);
            this.txtMaker.MaxLength = 4;
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(40, 22);
            this.txtMaker.TabIndex = 0;
            this.txtMaker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtMakerTxtKeyDown);
            this.txtMaker.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtMakerKeyUp);
            this.txtMaker.Leave += new System.EventHandler(this.setTxtMakerTextLeave);
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
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtMakerKeyUp);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblName.Location = new System.Drawing.Point(471, 137);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 15);
            this.lblName.strToolTip = null;
            this.lblName.TabIndex = 87;
            this.lblName.Text = "メーカー名";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCD
            // 
            this.lblCD.AutoSize = true;
            this.lblCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblCD.Location = new System.Drawing.Point(471, 100);
            this.lblCD.Name = "lblCD";
            this.lblCD.Size = new System.Drawing.Size(119, 15);
            this.lblCD.strToolTip = null;
            this.lblCD.TabIndex = 88;
            this.lblCD.Text = "メーカーコード";
            this.lblCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(471, 175);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(39, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 90;
            this.baseLabel1.Text = "カナ";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNameKana
            // 
            this.txtNameKana.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtNameKana.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtNameKana.Location = new System.Drawing.Point(596, 172);
            this.txtNameKana.MaxLength = 80;
            this.txtNameKana.Name = "txtNameKana";
            this.txtNameKana.Size = new System.Drawing.Size(391, 22);
            this.txtNameKana.TabIndex = 2;
            this.txtNameKana.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judMakerTxtKeyDown);
            this.txtNameKana.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtMakerKeyUp);
            // 
            // M1020_Maker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 828);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.txtNameKana);
            this.Controls.Add(this.lblCD);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtMaker);
            this.Name = "M1020_Maker";
            this.Text = "M1020_Maker";
            this.Load += new System.EventHandler(this.M_Maker_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judMakerKeyDown);
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
            this.Controls.SetChildIndex(this.txtMaker, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblCD, 0);
            this.Controls.SetChildIndex(this.txtNameKana, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseText txtMaker;
        private BaseText txtName;
        private BaseLabel lblName;
        private BaseLabel lblCD;
        private BaseLabel baseLabel1;
        private BaseText txtNameKana;
    }
}