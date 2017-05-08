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
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel3 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.LabelSet_Daibun = new KATO.Common.Ctl.LabelSet_Daibunrui();
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
            this.txtChubunrui.Location = new System.Drawing.Point(566, 132);
            this.txtChubunrui.MaxLength = 2;
            this.txtChubunrui.Name = "txtChubunrui";
            this.txtChubunrui.Size = new System.Drawing.Size(33, 22);
            this.txtChubunrui.TabIndex = 1;
            this.txtChubunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtChubunKeyDown);
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
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(460, 135);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(103, 15);
            this.baseLabel2.TabIndex = 90;
            this.baseLabel2.Text = "中分類コード";
            this.baseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.baseLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelSet_Daibun
            // 
            this.LabelSet_Daibun.AppendLabelSize = 0;
            this.LabelSet_Daibun.AppendLabelText = "";
            this.LabelSet_Daibun.CodeTxtSize = 33;
            this.LabelSet_Daibun.CodeTxtText = "";
            this.LabelSet_Daibun.LabelName = "大分類コード";
            this.LabelSet_Daibun.Location = new System.Drawing.Point(458, 90);
            this.LabelSet_Daibun.Lschubundata = null;
            this.LabelSet_Daibun.Name = "LabelSet_Daibun";
            this.LabelSet_Daibun.ShowAppendFlg = false;
            this.LabelSet_Daibun.Size = new System.Drawing.Size(496, 22);
            this.LabelSet_Daibun.SpaceCodeValue = 20;
            this.LabelSet_Daibun.SpaceNameCode = 5;
            this.LabelSet_Daibun.SpaceValueAppend = 4;
            this.LabelSet_Daibun.TabIndex = 0;
            this.LabelSet_Daibun.ValueLabelSize = 200;
            this.LabelSet_Daibun.ValueLabelText = "";
            // 
            // M1110_Chubunrui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 828);
            this.Controls.Add(this.LabelSet_Daibun);
            this.Controls.Add(this.baseLabel3);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.txtElem);
            this.Controls.Add(this.txtChubunrui);
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Name = "M1110_Chubunrui";
            this.Text = "M1110_Chubunrui";
            this.Load += new System.EventHandler(this.M_Chubunrui_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChubunruiKeyDown);
            this.Controls.SetChildIndex(this.txtChubunrui, 0);
            this.Controls.SetChildIndex(this.txtElem, 0);
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
            this.Controls.SetChildIndex(this.LabelSet_Daibun, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BaseText txtChubunrui;
        private BaseText txtElem;
        private BaseLabel baseLabel2;
        private BaseLabel baseLabel3;
        private LabelSet_Daibunrui LabelSet_Daibun;
    }
}