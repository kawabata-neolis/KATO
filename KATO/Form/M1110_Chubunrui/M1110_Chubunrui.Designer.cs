using KATO.Common.Ctl;
using KATO.Common.Util;

namespace KATO.Form.M1110_Chubunrui
{
    partial class M1110_Chubunrui
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
            this.txtChubunrui = new KATO.Common.Ctl.BaseText();
            this.txtElem = new KATO.Common.Ctl.BaseText();
            this.lblCD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblSetDaibun = new KATO.Common.Ctl.LabelSet_Daibunrui();
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
            // txtChubunrui
            // 
            this.txtChubunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtChubunrui.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtChubunrui.Location = new System.Drawing.Point(566, 132);
            this.txtChubunrui.MaxLength = 2;
            this.txtChubunrui.Name = "txtChubunrui";
            this.txtChubunrui.Size = new System.Drawing.Size(24, 22);
            this.txtChubunrui.TabIndex = 1;
            this.txtChubunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtChuTxtKeyDown);
            this.txtChubunrui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtChubunruiKeyUp);
            this.txtChubunrui.Leave += new System.EventHandler(this.setTxtChubunruiLeave);
            // 
            // txtElem
            // 
            this.txtElem.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtElem.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtElem.Location = new System.Drawing.Point(726, 132);
            this.txtElem.MaxLength = 24;
            this.txtElem.Name = "txtElem";
            this.txtElem.Size = new System.Drawing.Size(200, 22);
            this.txtElem.TabIndex = 2;
            this.txtElem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChubunTxtKeyDown);
            this.txtElem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtChubunruiKeyUp);
            // 
            // lblCD
            // 
            this.lblCD.AutoSize = true;
            this.lblCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblCD.Location = new System.Drawing.Point(460, 135);
            this.lblCD.Name = "lblCD";
            this.lblCD.Size = new System.Drawing.Size(103, 15);
            this.lblCD.strToolTip = null;
            this.lblCD.TabIndex = 90;
            this.lblCD.Text = "中分類コード";
            this.lblCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblName.Location = new System.Drawing.Point(649, 135);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 15);
            this.lblName.strToolTip = null;
            this.lblName.TabIndex = 91;
            this.lblName.Text = "中分類名";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSetDaibun
            // 
            this.lblSetDaibun.AppendLabelSize = 0;
            this.lblSetDaibun.AppendLabelText = "";
            this.lblSetDaibun.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lblSetDaibun.CodeTxtSize = 24;
            this.lblSetDaibun.CodeTxtText = "";
            this.lblSetDaibun.LabelName = "大分類コード";
            this.lblSetDaibun.Location = new System.Drawing.Point(458, 90);
            this.lblSetDaibun.Lschubundata = null;
            this.lblSetDaibun.Lsmakerdata = null;
            this.lblSetDaibun.LsSubchubundata = null;
            this.lblSetDaibun.LsSubmakerdata = null;
            this.lblSetDaibun.Name = "lblSetDaibun";
            this.lblSetDaibun.ShowAppendFlg = false;
            this.lblSetDaibun.Size = new System.Drawing.Size(496, 22);
            this.lblSetDaibun.SpaceCodeValue = 20;
            this.lblSetDaibun.SpaceNameCode = 5;
            this.lblSetDaibun.SpaceValueAppend = 4;
            this.lblSetDaibun.TabIndex = 0;
            this.lblSetDaibun.ValueLabelSize = 200;
            this.lblSetDaibun.ValueLabelText = "";
            this.lblSetDaibun.Leave += new System.EventHandler(this.lblSetDaibun_Leave);
            // 
            // M1110_Chubunrui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 828);
            this.Controls.Add(this.lblSetDaibun);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCD);
            this.Controls.Add(this.txtElem);
            this.Controls.Add(this.txtChubunrui);
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Name = "M1110_Chubunrui";
            this.Text = "M1110_Chubunrui";
            this.Load += new System.EventHandler(this.M_Chubunrui_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChubunruiKeyDown);
            this.Controls.SetChildIndex(this.txtChubunrui, 0);
            this.Controls.SetChildIndex(this.txtElem, 0);
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
            this.Controls.SetChildIndex(this.lblSetDaibun, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BaseText txtChubunrui;
        private BaseText txtElem;
        private BaseLabel lblCD;
        private BaseLabel lblName;
        private LabelSet_Daibunrui lblSetDaibun;
    }
}