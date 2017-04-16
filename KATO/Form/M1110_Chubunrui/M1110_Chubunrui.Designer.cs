using KATO.Common.Ctl;
using KATO.Common.Util;

namespace KATO.Form.M_Chubunrui
{
    partial class M_Chubunrui
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
//        private void InitializeComponent()
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtDaibunrui = new KATO.Common.Ctl.BaseText();
            this.txtChubunrui = new KATO.Common.Ctl.BaseText();
            this.txtElem = new KATO.Common.Ctl.BaseText();
            this.lblDsp = new KATO.Common.Ctl.BaseLabelGray();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel3 = new KATO.Common.Ctl.BaseLabel(this.components);
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
            // txtDaibunrui
            // 
            this.txtDaibunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDaibunrui.Location = new System.Drawing.Point(566, 91);
            this.txtDaibunrui.MaxLength = 2;
            this.txtDaibunrui.Name = "txtDaibunrui";
            this.txtDaibunrui.Size = new System.Drawing.Size(33, 22);
            this.txtDaibunrui.TabIndex = 0;
            this.txtDaibunrui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDaibunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtCDKeyDown);
            this.txtDaibunrui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtDaibunruiKeyUp);
            this.txtDaibunrui.Leave += new System.EventHandler(this.judtxtDaibunruiLeave);
            // 
            // txtChubunrui
            // 
            this.txtChubunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtChubunrui.Location = new System.Drawing.Point(566, 132);
            this.txtChubunrui.MaxLength = 2;
            this.txtChubunrui.Name = "txtChubunrui";
            this.txtChubunrui.Size = new System.Drawing.Size(33, 22);
            this.txtChubunrui.TabIndex = 1;
            this.txtChubunrui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChubunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtCyokuCDKeyDown);
            this.txtChubunrui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtChubunruiKeyUp);
            this.txtChubunrui.Leave += new System.EventHandler(this.judtxtChubunruiLeave);
            // 
            // txtElem
            // 
            this.txtElem.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtElem.Location = new System.Drawing.Point(726, 132);
            this.txtElem.MaxLength = 40;
            this.txtElem.Name = "txtElem";
            this.txtElem.Size = new System.Drawing.Size(228, 22);
            this.txtElem.TabIndex = 2;
            // 
            // lblDsp
            // 
            this.lblDsp.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDsp.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDsp.ForeColor = System.Drawing.Color.Blue;
            this.lblDsp.Location = new System.Drawing.Point(624, 91);
            this.lblDsp.Name = "lblDsp";
            this.lblDsp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDsp.Size = new System.Drawing.Size(202, 23);
            this.lblDsp.TabIndex = 88;
            this.lblDsp.Text = " ";
            this.lblDsp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(457, 95);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(103, 15);
            this.baseLabel1.TabIndex = 89;
            this.baseLabel1.Text = "大分類コード";
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(460, 135);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(103, 15);
            this.baseLabel2.TabIndex = 90;
            this.baseLabel2.Text = "中分類コード";
            // 
            // baseLabel3
            // 
            this.baseLabel3.AutoSize = true;
            this.baseLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel3.Location = new System.Drawing.Point(649, 135);
            this.baseLabel3.Name = "baseLabel3";
            this.baseLabel3.Size = new System.Drawing.Size(71, 15);
            this.baseLabel3.TabIndex = 91;
            this.baseLabel3.Text = "中分類名";
            // 
            // M_Chubunrui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 831);
            this.Controls.Add(this.baseLabel3);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.lblDsp);
            this.Controls.Add(this.txtElem);
            this.Controls.Add(this.txtChubunrui);
            this.Controls.Add(this.txtDaibunrui);
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Name = "M_Chubunrui";
            this.Text = "Cyubunrui";
            this.Load += new System.EventHandler(this.M_Chubunrui_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judCyubunruiKeyDown);
            this.Controls.SetChildIndex(this.txtDaibunrui, 0);
            this.Controls.SetChildIndex(this.txtChubunrui, 0);
            this.Controls.SetChildIndex(this.txtElem, 0);
            this.Controls.SetChildIndex(this.lblDsp, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.baseLabel2, 0);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BaseText txtDaibunrui;
        private BaseText txtChubunrui;
        private BaseText txtElem;
        private BaseLabelGray lblDsp;
        private BaseLabel baseLabel1;
        private BaseLabel baseLabel2;
        private BaseLabel baseLabel3;
    }
}