using KATO.Common.Ctl;
using KATO.Common.Util;

namespace KATO.Form.M1010_Daibunrui
{
    partial class M1010_Daibunrui
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
            this.txtDaibunrui = new KATO.Common.Ctl.BaseText();
            this.txtName = new KATO.Common.Ctl.BaseText();
            this.txtLabel1 = new KATO.Common.Ctl.BaseText();
            this.txtLabel2 = new KATO.Common.Ctl.BaseText();
            this.txtLabel3 = new KATO.Common.Ctl.BaseText();
            this.txtLabel4 = new KATO.Common.Ctl.BaseText();
            this.txtLabel5 = new KATO.Common.Ctl.BaseText();
            this.txtLabel6 = new KATO.Common.Ctl.BaseText();
            this.lblCD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lbl1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lbl2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lbl3 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lbl4 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lbl5 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lbl6 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.SuspendLayout();
            // 
            // btnF12
            // 
            this.btnF12.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF10
            // 
            this.btnF10.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF08
            // 
            this.btnF08.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF07
            // 
            this.btnF07.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF06
            // 
            this.btnF06.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF05
            // 
            this.btnF05.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF02
            // 
            this.btnF02.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // txtDaibunrui
            // 

            this.txtDaibunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDaibunrui.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDaibunrui.Location = new System.Drawing.Point(595, 97);
            this.txtDaibunrui.MaxLength = 2;
            this.txtDaibunrui.Name = "txtDaibunrui";
            this.txtDaibunrui.Size = new System.Drawing.Size(24, 22);
            this.txtDaibunrui.TabIndex = 0;
            this.txtDaibunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtDaiTxtKeyDown);
            this.txtDaibunrui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtDaibunruiKeyUp);
            this.txtDaibunrui.Leave += new System.EventHandler(this.setTxtDaibunruiLeave);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtName.Location = new System.Drawing.Point(595, 132);
            this.txtName.MaxLength = 24;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunTxtKeyDown);
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtDaibunruiKeyUp);
            // 
            // txtLabel1
            // 
            this.txtLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtLabel1.Location = new System.Drawing.Point(595, 181);
            this.txtLabel1.Name = "txtLabel1";
            this.txtLabel1.Size = new System.Drawing.Size(100, 22);
            this.txtLabel1.TabIndex = 2;
            this.txtLabel1.Visible = false;
            this.txtLabel1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunTxtKeyDown);
            // 
            // txtLabel2
            // 
            this.txtLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtLabel2.Location = new System.Drawing.Point(595, 221);
            this.txtLabel2.Name = "txtLabel2";
            this.txtLabel2.Size = new System.Drawing.Size(100, 22);
            this.txtLabel2.TabIndex = 3;
            this.txtLabel2.Visible = false;
            this.txtLabel2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunTxtKeyDown);
            // 
            // txtLabel3
            // 
            this.txtLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtLabel3.Location = new System.Drawing.Point(595, 262);
            this.txtLabel3.Name = "txtLabel3";
            this.txtLabel3.Size = new System.Drawing.Size(100, 22);
            this.txtLabel3.TabIndex = 4;
            this.txtLabel3.Visible = false;
            this.txtLabel3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunTxtKeyDown);
            // 
            // txtLabel4
            // 
            this.txtLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtLabel4.Location = new System.Drawing.Point(595, 303);
            this.txtLabel4.Name = "txtLabel4";
            this.txtLabel4.Size = new System.Drawing.Size(100, 22);
            this.txtLabel4.TabIndex = 5;
            this.txtLabel4.Visible = false;
            this.txtLabel4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunTxtKeyDown);
            // 
            // txtLabel5
            // 
            this.txtLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtLabel5.Location = new System.Drawing.Point(595, 342);
            this.txtLabel5.Name = "txtLabel5";
            this.txtLabel5.Size = new System.Drawing.Size(100, 22);
            this.txtLabel5.TabIndex = 6;
            this.txtLabel5.Visible = false;
            this.txtLabel5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunTxtKeyDown);
            // 
            // txtLabel6
            // 
            this.txtLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtLabel6.Location = new System.Drawing.Point(595, 381);
            this.txtLabel6.Name = "txtLabel6";
            this.txtLabel6.Size = new System.Drawing.Size(100, 22);
            this.txtLabel6.TabIndex = 7;
            this.txtLabel6.Visible = false;
            this.txtLabel6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunTxtKeyDown);
            // 
            // lblCD
            // 
            this.lblCD.AutoSize = true;
            this.lblCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblCD.Location = new System.Drawing.Point(486, 100);
            this.lblCD.Name = "lblCD";
            this.lblCD.Size = new System.Drawing.Size(103, 15);
            this.lblCD.TabIndex = 86;
            this.lblCD.Text = "大分類コード";
            this.lblCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblName.Location = new System.Drawing.Point(486, 135);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "大分類名";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl1.Location = new System.Drawing.Point(486, 184);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(87, 15);
            this.lbl1.TabIndex = 87;
            this.lbl1.Text = "ラベル名１";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl1.Visible = false;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl2.Location = new System.Drawing.Point(486, 224);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(87, 15);
            this.lbl2.TabIndex = 88;
            this.lbl2.Text = "ラベル名２";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl2.Visible = false;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl3.Location = new System.Drawing.Point(486, 265);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(87, 15);
            this.lbl3.TabIndex = 89;
            this.lbl3.Text = "ラベル名３";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl3.Visible = false;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl4.Location = new System.Drawing.Point(486, 306);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(87, 15);
            this.lbl4.TabIndex = 90;
            this.lbl4.Text = "ラベル名４";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl4.Visible = false;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl5.Location = new System.Drawing.Point(486, 345);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(87, 15);
            this.lbl5.TabIndex = 91;
            this.lbl5.Text = "ラベル名５";
            this.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl5.Visible = false;
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl6.Location = new System.Drawing.Point(486, 384);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(87, 15);
            this.lbl6.TabIndex = 92;
            this.lbl6.Text = "ラベル名６";
            this.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl6.Visible = false;
            // 
            // M1010_Daibunrui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 828);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCD);
            this.Controls.Add(this.txtLabel6);
            this.Controls.Add(this.txtLabel5);
            this.Controls.Add(this.txtLabel4);
            this.Controls.Add(this.txtLabel3);
            this.Controls.Add(this.txtLabel2);
            this.Controls.Add(this.txtLabel1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDaibunrui);
            this.Name = "M1010_Daibunrui";
            this.Text = "s";
            this.Load += new System.EventHandler(this.M1010_Daibunrui_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunruiKeyDown);
            this.Controls.SetChildIndex(this.txtDaibunrui, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.txtLabel1, 0);
            this.Controls.SetChildIndex(this.txtLabel2, 0);
            this.Controls.SetChildIndex(this.txtLabel3, 0);
            this.Controls.SetChildIndex(this.txtLabel4, 0);
            this.Controls.SetChildIndex(this.txtLabel5, 0);
            this.Controls.SetChildIndex(this.txtLabel6, 0);
            this.Controls.SetChildIndex(this.lblCD, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
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
            this.Controls.SetChildIndex(this.lbl1, 0);
            this.Controls.SetChildIndex(this.lbl2, 0);
            this.Controls.SetChildIndex(this.lbl3, 0);
            this.Controls.SetChildIndex(this.lbl4, 0);
            this.Controls.SetChildIndex(this.lbl5, 0);
            this.Controls.SetChildIndex(this.lbl6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BaseText txtDaibunrui;
        private BaseText txtName;
        private BaseText txtLabel1;
        private BaseText txtLabel2;
        private BaseText txtLabel3;
        private BaseText txtLabel4;
        private BaseText txtLabel5;
        private BaseText txtLabel6;
        private BaseLabel lblCD;
        private BaseLabel lblName;
        private BaseLabel lbl1;
        private BaseLabel lbl2;
        private BaseLabel lbl3;
        private BaseLabel lbl4;
        private BaseLabel lbl5;
        private BaseLabel lbl6;
    }
}