namespace KATO.Form.M1030_Shohin
{
    partial class M1030_Shohin
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
            this.radSet_2btn = new KATO.Common.Ctl.RadSet_2btn();
            this.labelSet_Daibunrui = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.labelSet_Chubunrui = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.labelSet_Maker = new KATO.Common.Ctl.LabelSet_Maker();
            this.txtShohinCd = new KATO.Common.Ctl.BaseText();
            this.lblShohinCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblText1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblText2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtKensaku = new KATO.Common.Ctl.BaseText();
            this.lblBaseLabelKensaku = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblGrayShohin = new KATO.Common.Ctl.BaseLabelGray();
            this.gbShohin = new System.Windows.Forms.GroupBox();
            this.gbRadio = new System.Windows.Forms.GroupBox();
            this.baseText1 = new KATO.Common.Ctl.BaseText();
            this.baseText2 = new KATO.Common.Ctl.BaseText();
            this.gbShohin.SuspendLayout();
            this.gbRadio.SuspendLayout();
            this.SuspendLayout();
            // 
            // radSet_2btn
            // 
            this.radSet_2btn.LabelTitle = " ";
            this.radSet_2btn.Location = new System.Drawing.Point(8, 20);
            this.radSet_2btn.Name = "radSet_2btn";
            this.radSet_2btn.PositionLabelTitle_X = 0;
            this.radSet_2btn.PositionLabelTitle_Y = 0;
            this.radSet_2btn.PositionRadbtn1_X = 20;
            this.radSet_2btn.PositionRadbtn1_Y = 0;
            this.radSet_2btn.PositionRadbtn2_X = 150;
            this.radSet_2btn.PositionRadbtn2_Y = 0;
            this.radSet_2btn.Radbtn1Text = "新規登録";
            this.radSet_2btn.Radbtn2Text = "修正登録";
            this.radSet_2btn.Size = new System.Drawing.Size(255, 25);
            this.radSet_2btn.TabIndex = 87;
            // 
            // labelSet_Daibunrui
            // 
            this.labelSet_Daibunrui.AppendLabelSize = 0;
            this.labelSet_Daibunrui.AppendLabelText = "";
            this.labelSet_Daibunrui.CodeTxtSize = 24;
            this.labelSet_Daibunrui.CodeTxtText = "";
            this.labelSet_Daibunrui.LabelName = "大分類コード";
            this.labelSet_Daibunrui.Location = new System.Drawing.Point(32, 78);
            this.labelSet_Daibunrui.Lschubundata = null;
            this.labelSet_Daibunrui.LsSubchubundata = null;
            this.labelSet_Daibunrui.Name = "labelSet_Daibunrui";
            this.labelSet_Daibunrui.ShowAppendFlg = false;
            this.labelSet_Daibunrui.Size = new System.Drawing.Size(416, 22);
            this.labelSet_Daibunrui.SpaceCodeValue = 10;
            this.labelSet_Daibunrui.SpaceNameCode = 4;
            this.labelSet_Daibunrui.SpaceValueAppend = 4;
            this.labelSet_Daibunrui.TabIndex = 88;
            this.labelSet_Daibunrui.ValueLabelSize = 200;
            this.labelSet_Daibunrui.ValueLabelText = "";
            // 
            // labelSet_Chubunrui
            // 
            this.labelSet_Chubunrui.AppendLabelSize = 0;
            this.labelSet_Chubunrui.AppendLabelText = "";
            this.labelSet_Chubunrui.CodeTxtSize = 24;
            this.labelSet_Chubunrui.CodeTxtText = "";
            this.labelSet_Chubunrui.LabelName = "中分類コード";
            this.labelSet_Chubunrui.Location = new System.Drawing.Point(32, 108);
            this.labelSet_Chubunrui.Name = "labelSet_Chubunrui";
            this.labelSet_Chubunrui.ShowAppendFlg = false;
            this.labelSet_Chubunrui.Size = new System.Drawing.Size(416, 22);
            this.labelSet_Chubunrui.SpaceCodeValue = 10;
            this.labelSet_Chubunrui.SpaceNameCode = 4;
            this.labelSet_Chubunrui.SpaceValueAppend = 4;
            this.labelSet_Chubunrui.strDaibunCd = null;
            this.labelSet_Chubunrui.TabIndex = 89;
            this.labelSet_Chubunrui.ValueLabelSize = 200;
            this.labelSet_Chubunrui.ValueLabelText = "";
            // 
            // labelSet_Maker
            // 
            this.labelSet_Maker.AppendLabelSize = 0;
            this.labelSet_Maker.AppendLabelText = "";
            this.labelSet_Maker.CodeTxtSize = 30;
            this.labelSet_Maker.CodeTxtText = "";
            this.labelSet_Maker.LabelName = "メーカー";
            this.labelSet_Maker.Location = new System.Drawing.Point(32, 137);
            this.labelSet_Maker.Name = "labelSet_Maker";
            this.labelSet_Maker.ShowAppendFlg = false;
            this.labelSet_Maker.Size = new System.Drawing.Size(416, 22);
            this.labelSet_Maker.SpaceCodeValue = 4;
            this.labelSet_Maker.SpaceNameCode = 36;
            this.labelSet_Maker.SpaceValueAppend = 4;
            this.labelSet_Maker.TabIndex = 90;
            this.labelSet_Maker.ValueLabelSize = 200;
            this.labelSet_Maker.ValueLabelText = "";
            // 
            // txtShohinCd
            // 
            this.txtShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShohinCd.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtShohinCd.Location = new System.Drawing.Point(594, 78);
            this.txtShohinCd.Name = "txtShohinCd";
            this.txtShohinCd.Size = new System.Drawing.Size(100, 22);
            this.txtShohinCd.TabIndex = 91;
            // 
            // lblShohinCd
            // 
            this.lblShohinCd.AutoSize = true;
            this.lblShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblShohinCd.Location = new System.Drawing.Point(485, 81);
            this.lblShohinCd.Name = "lblShohinCd";
            this.lblShohinCd.Size = new System.Drawing.Size(87, 15);
            this.lblShohinCd.TabIndex = 92;
            this.lblShohinCd.Text = "商品コード";
            this.lblShohinCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblText1
            // 
            this.lblText1.AutoSize = true;
            this.lblText1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblText1.Location = new System.Drawing.Point(414, 21);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(375, 15);
            this.lblText1.TabIndex = 93;
            this.lblText1.Text = "※型番を一部変更して新規として登録する場合は、";
            this.lblText1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblText2
            // 
            this.lblText2.AutoSize = true;
            this.lblText2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblText2.Location = new System.Drawing.Point(414, 40);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(263, 15);
            this.lblText2.TabIndex = 94;
            this.lblText2.Text = "「新規登録」を選択してください。";
            this.lblText2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKensaku
            // 
            this.txtKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensaku.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKensaku.Location = new System.Drawing.Point(139, 194);
            this.txtKensaku.Name = "txtKensaku";
            this.txtKensaku.Size = new System.Drawing.Size(322, 22);
            this.txtKensaku.TabIndex = 96;
            // 
            // lblBaseLabelKensaku
            // 
            this.lblBaseLabelKensaku.AutoSize = true;
            this.lblBaseLabelKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabelKensaku.Location = new System.Drawing.Point(34, 197);
            this.lblBaseLabelKensaku.Name = "lblBaseLabelKensaku";
            this.lblBaseLabelKensaku.Size = new System.Drawing.Size(87, 15);
            this.lblBaseLabelKensaku.TabIndex = 97;
            this.lblBaseLabelKensaku.Text = "検索文字列";
            this.lblBaseLabelKensaku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGrayShohin
            // 
            this.lblGrayShohin.AutoEllipsis = true;
            this.lblGrayShohin.BackColor = System.Drawing.Color.Gainsboro;
            this.lblGrayShohin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblGrayShohin.ForeColor = System.Drawing.Color.Blue;
            this.lblGrayShohin.Location = new System.Drawing.Point(23, 20);
            this.lblGrayShohin.Name = "lblGrayShohin";
            this.lblGrayShohin.Size = new System.Drawing.Size(518, 22);
            this.lblGrayShohin.TabIndex = 99;
            this.lblGrayShohin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbShohin
            // 
            this.gbShohin.Controls.Add(this.lblGrayShohin);
            this.gbShohin.Location = new System.Drawing.Point(477, 116);
            this.gbShohin.Name = "gbShohin";
            this.gbShohin.Size = new System.Drawing.Size(557, 53);
            this.gbShohin.TabIndex = 100;
            this.gbShohin.TabStop = false;
            this.gbShohin.Text = "商品名";
            // 
            // gbRadio
            // 
            this.gbRadio.Controls.Add(this.radSet_2btn);
            this.gbRadio.Location = new System.Drawing.Point(37, 12);
            this.gbRadio.Name = "gbRadio";
            this.gbRadio.Size = new System.Drawing.Size(272, 53);
            this.gbRadio.TabIndex = 101;
            this.gbRadio.TabStop = false;
            // 
            // baseText1
            // 
            this.baseText1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseText1.Location = new System.Drawing.Point(21, 310);
            this.baseText1.Name = "baseText1";
            this.baseText1.Size = new System.Drawing.Size(440, 22);
            this.baseText1.TabIndex = 102;
            // 
            // baseText2
            // 
            this.baseText2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseText2.Location = new System.Drawing.Point(467, 310);
            this.baseText2.Name = "baseText2";
            this.baseText2.Size = new System.Drawing.Size(210, 22);
            this.baseText2.TabIndex = 102;
            // 
            // M1030_Shohin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.baseText2);
            this.Controls.Add(this.baseText1);
            this.Controls.Add(this.gbRadio);
            this.Controls.Add(this.gbShohin);
            this.Controls.Add(this.txtKensaku);
            this.Controls.Add(this.lblBaseLabelKensaku);
            this.Controls.Add(this.lblText2);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.lblShohinCd);
            this.Controls.Add(this.txtShohinCd);
            this.Controls.Add(this.labelSet_Maker);
            this.Controls.Add(this.labelSet_Chubunrui);
            this.Controls.Add(this.labelSet_Daibunrui);
            this.Name = "M1030_Shohin";
            this.Text = "M1030_Shohin";
            this.Load += new System.EventHandler(this.M1030_Shohin_Load);
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
            this.Controls.SetChildIndex(this.labelSet_Daibunrui, 0);
            this.Controls.SetChildIndex(this.labelSet_Chubunrui, 0);
            this.Controls.SetChildIndex(this.labelSet_Maker, 0);
            this.Controls.SetChildIndex(this.txtShohinCd, 0);
            this.Controls.SetChildIndex(this.lblShohinCd, 0);
            this.Controls.SetChildIndex(this.lblText1, 0);
            this.Controls.SetChildIndex(this.lblText2, 0);
            this.Controls.SetChildIndex(this.lblBaseLabelKensaku, 0);
            this.Controls.SetChildIndex(this.txtKensaku, 0);
            this.Controls.SetChildIndex(this.gbShohin, 0);
            this.Controls.SetChildIndex(this.gbRadio, 0);
            this.Controls.SetChildIndex(this.baseText1, 0);
            this.Controls.SetChildIndex(this.baseText2, 0);
            this.gbShohin.ResumeLayout(false);
            this.gbRadio.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.RadSet_2btn radSet_2btn;
        private Common.Ctl.LabelSet_Daibunrui labelSet_Daibunrui;
        private Common.Ctl.LabelSet_Chubunrui labelSet_Chubunrui;
        private Common.Ctl.LabelSet_Maker labelSet_Maker;
        private Common.Ctl.BaseText txtShohinCd;
        private Common.Ctl.BaseLabel lblShohinCd;
        private Common.Ctl.BaseLabel lblText1;
        private Common.Ctl.BaseLabel lblText2;
        private Common.Ctl.BaseText txtKensaku;
        private Common.Ctl.BaseLabel lblBaseLabelKensaku;
        private Common.Ctl.BaseLabelGray lblGrayShohin;
        private System.Windows.Forms.GroupBox gbShohin;
        private System.Windows.Forms.GroupBox gbRadio;
        private Common.Ctl.BaseText baseText1;
        private Common.Ctl.BaseText baseText2;
    }
}