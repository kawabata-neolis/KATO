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
            this.lblBaseLabelCD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblBaseLabelName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblBaseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblBaseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblBaseLabel3 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblBaseLabel4 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblBaseLabel5 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblBaseLabel6 = new KATO.Common.Ctl.BaseLabel(this.components);
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
            this.txtDaibunrui.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDaibunrui.Location = new System.Drawing.Point(595, 97);
            this.txtDaibunrui.MaxLength = 2;
            this.txtDaibunrui.Name = "txtDaibunrui";
            this.txtDaibunrui.Size = new System.Drawing.Size(24, 22);
            this.txtDaibunrui.TabIndex = 0;
            this.txtDaibunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtDaibunKeyDown);
            this.txtDaibunrui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtDaibunruiKeyUp);
            this.txtDaibunrui.Leave += new System.EventHandler(this.updTxtDaibunruiLeave);
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
            // lblBaseLabelCD
            // 
            this.lblBaseLabelCD.AutoSize = true;
            this.lblBaseLabelCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabelCD.Location = new System.Drawing.Point(486, 100);
            this.lblBaseLabelCD.Name = "lblBaseLabelCD";
            this.lblBaseLabelCD.Size = new System.Drawing.Size(103, 15);
            this.lblBaseLabelCD.TabIndex = 86;
            this.lblBaseLabelCD.Text = "大分類コード";
            this.lblBaseLabelCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaseLabelName
            // 
            this.lblBaseLabelName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabelName.Location = new System.Drawing.Point(486, 135);
            this.lblBaseLabelName.Name = "lblBaseLabelName";
            this.lblBaseLabelName.Size = new System.Drawing.Size(87, 15);
            this.lblBaseLabelName.TabIndex = 0;
            this.lblBaseLabelName.Text = "大分類名";
            this.lblBaseLabelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaseLabel1
            // 
            this.lblBaseLabel1.AutoSize = true;
            this.lblBaseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabel1.Location = new System.Drawing.Point(486, 184);
            this.lblBaseLabel1.Name = "lblBaseLabel1";
            this.lblBaseLabel1.Size = new System.Drawing.Size(87, 15);
            this.lblBaseLabel1.TabIndex = 87;
            this.lblBaseLabel1.Text = "ラベル名１";
            this.lblBaseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaseLabel1.Visible = false;
            // 
            // lblBaseLabel2
            // 
            this.lblBaseLabel2.AutoSize = true;
            this.lblBaseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabel2.Location = new System.Drawing.Point(486, 224);
            this.lblBaseLabel2.Name = "lblBaseLabel2";
            this.lblBaseLabel2.Size = new System.Drawing.Size(87, 15);
            this.lblBaseLabel2.TabIndex = 88;
            this.lblBaseLabel2.Text = "ラベル名２";
            this.lblBaseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaseLabel2.Visible = false;
            // 
            // lblBaseLabel3
            // 
            this.lblBaseLabel3.AutoSize = true;
            this.lblBaseLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabel3.Location = new System.Drawing.Point(486, 265);
            this.lblBaseLabel3.Name = "lblBaseLabel3";
            this.lblBaseLabel3.Size = new System.Drawing.Size(87, 15);
            this.lblBaseLabel3.TabIndex = 89;
            this.lblBaseLabel3.Text = "ラベル名３";
            this.lblBaseLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaseLabel3.Visible = false;
            // 
            // lblBaseLabel4
            // 
            this.lblBaseLabel4.AutoSize = true;
            this.lblBaseLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabel4.Location = new System.Drawing.Point(486, 306);
            this.lblBaseLabel4.Name = "lblBaseLabel4";
            this.lblBaseLabel4.Size = new System.Drawing.Size(87, 15);
            this.lblBaseLabel4.TabIndex = 90;
            this.lblBaseLabel4.Text = "ラベル名４";
            this.lblBaseLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaseLabel4.Visible = false;
            // 
            // lblBaseLabel5
            // 
            this.lblBaseLabel5.AutoSize = true;
            this.lblBaseLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabel5.Location = new System.Drawing.Point(486, 345);
            this.lblBaseLabel5.Name = "lblBaseLabel5";
            this.lblBaseLabel5.Size = new System.Drawing.Size(87, 15);
            this.lblBaseLabel5.TabIndex = 91;
            this.lblBaseLabel5.Text = "ラベル名５";
            this.lblBaseLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaseLabel5.Visible = false;
            // 
            // lblBaseLabel6
            // 
            this.lblBaseLabel6.AutoSize = true;
            this.lblBaseLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabel6.Location = new System.Drawing.Point(486, 384);
            this.lblBaseLabel6.Name = "lblBaseLabel6";
            this.lblBaseLabel6.Size = new System.Drawing.Size(87, 15);
            this.lblBaseLabel6.TabIndex = 92;
            this.lblBaseLabel6.Text = "ラベル名６";
            this.lblBaseLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaseLabel6.Visible = false;
            // 
            // M1010_Daibunrui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 828);
            this.Controls.Add(this.lblBaseLabel6);
            this.Controls.Add(this.lblBaseLabel5);
            this.Controls.Add(this.lblBaseLabel4);
            this.Controls.Add(this.lblBaseLabel3);
            this.Controls.Add(this.lblBaseLabel2);
            this.Controls.Add(this.lblBaseLabel1);
            this.Controls.Add(this.lblBaseLabelName);
            this.Controls.Add(this.lblBaseLabelCD);
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
            this.Controls.SetChildIndex(this.lblBaseLabel1, 0);
            this.Controls.SetChildIndex(this.lblBaseLabel2, 0);
            this.Controls.SetChildIndex(this.lblBaseLabel3, 0);
            this.Controls.SetChildIndex(this.lblBaseLabel4, 0);
            this.Controls.SetChildIndex(this.lblBaseLabel5, 0);
            this.Controls.SetChildIndex(this.lblBaseLabel6, 0);
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
        private BaseLabel lblBaseLabelCD;
        private BaseLabel lblBaseLabelName;
        private BaseLabel lblBaseLabel1;
        private BaseLabel lblBaseLabel2;
        private BaseLabel lblBaseLabel3;
        private BaseLabel lblBaseLabel4;
        private BaseLabel lblBaseLabel5;
        private BaseLabel lblBaseLabel6;
    }
}