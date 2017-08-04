namespace KATO.Form.F0570_TanaorosiKinyuhyoPrint
{
    partial class F0570_TanaorosiKinyuhyoPrint
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
            this.labelSet_Eigyosho = new KATO.Common.Ctl.LabelSet_Eigyosho();
            this.labelSet_Daibunrui = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.txtYmd = new KATO.Common.Ctl.BaseCalendar();
            this.lblYmd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Chubunrui = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.labelSet_Maker = new KATO.Common.Ctl.LabelSet_Maker();
            this.txtTanabanFrom = new KATO.Common.Ctl.BaseText();
            this.lblTanaban = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblTanabanKara = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTanabanTo = new KATO.Common.Ctl.BaseText();
            this.bgSort = new System.Windows.Forms.GroupBox();
            this.radSort = new KATO.Common.Ctl.RadSet_4btn();
            this.lblSort = new KATO.Common.Ctl.BaseLabel(this.components);
            this.chkPrintOnly = new KATO.Common.Ctl.BaseCheckBox();
            this.lblSearchSetsumei = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblPrintSetsumei = new KATO.Common.Ctl.BaseLabel(this.components);
            this.bgSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnF12
            // 
            this.btnF12.TabIndex = 11;
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.TabIndex = 10;
            this.btnF11.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF10
            // 
            this.btnF10.TabStop = false;
            this.btnF10.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.TabStop = false;
            this.btnF09.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF08
            // 
            this.btnF08.TabStop = false;
            this.btnF08.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF07
            // 
            this.btnF07.TabStop = false;
            this.btnF07.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF06
            // 
            this.btnF06.TabStop = false;
            this.btnF06.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF05
            // 
            this.btnF05.TabStop = false;
            this.btnF05.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.TabIndex = 12;
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.TabStop = false;
            this.btnF03.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF02
            // 
            this.btnF02.TabStop = false;
            this.btnF02.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF01
            // 
            this.btnF01.TabStop = false;
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // labelSet_Eigyosho
            // 
            this.labelSet_Eigyosho.AppendLabelSize = 0;
            this.labelSet_Eigyosho.AppendLabelText = "";
            this.labelSet_Eigyosho.CodeTxtSize = 40;
            this.labelSet_Eigyosho.CodeTxtText = "";
            this.labelSet_Eigyosho.LabelName = "営業所コード";
            this.labelSet_Eigyosho.Location = new System.Drawing.Point(441, 155);
            this.labelSet_Eigyosho.Name = "labelSet_Eigyosho";
            this.labelSet_Eigyosho.ShowAppendFlg = false;
            this.labelSet_Eigyosho.Size = new System.Drawing.Size(410, 22);
            this.labelSet_Eigyosho.SpaceCodeValue = 4;
            this.labelSet_Eigyosho.SpaceNameCode = 4;
            this.labelSet_Eigyosho.SpaceValueAppend = 4;
            this.labelSet_Eigyosho.TabIndex = 2;
            this.labelSet_Eigyosho.ValueLabelSize = 250;
            this.labelSet_Eigyosho.ValueLabelText = "";
            // 
            // labelSet_Daibunrui
            // 
            this.labelSet_Daibunrui.AppendLabelSize = 0;
            this.labelSet_Daibunrui.AppendLabelText = "";
            this.labelSet_Daibunrui.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.labelSet_Daibunrui.CodeTxtSize = 24;
            this.labelSet_Daibunrui.CodeTxtText = "";
            this.labelSet_Daibunrui.LabelName = "大分類コード";
            this.labelSet_Daibunrui.Location = new System.Drawing.Point(441, 196);
            this.labelSet_Daibunrui.Lschubundata = null;
            this.labelSet_Daibunrui.Lsmakerdata = null;
            this.labelSet_Daibunrui.LsSubchubundata = null;
            this.labelSet_Daibunrui.LsSubmakerdata = null;
            this.labelSet_Daibunrui.Name = "labelSet_Daibunrui";
            this.labelSet_Daibunrui.ShowAppendFlg = false;
            this.labelSet_Daibunrui.Size = new System.Drawing.Size(350, 22);
            this.labelSet_Daibunrui.SpaceCodeValue = 4;
            this.labelSet_Daibunrui.SpaceNameCode = 4;
            this.labelSet_Daibunrui.SpaceValueAppend = 4;
            this.labelSet_Daibunrui.TabIndex = 3;
            this.labelSet_Daibunrui.ValueLabelSize = 200;
            this.labelSet_Daibunrui.ValueLabelText = "";
            // 
            // txtYmd
            // 
            this.txtYmd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYmd.Location = new System.Drawing.Point(535, 117);
            this.txtYmd.MaxLength = 10;
            this.txtYmd.Name = "txtYmd";
            this.txtYmd.Size = new System.Drawing.Size(90, 22);
            this.txtYmd.TabIndex = 1;
            this.txtYmd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblYmd
            // 
            this.lblYmd.AutoSize = true;
            this.lblYmd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblYmd.Location = new System.Drawing.Point(442, 120);
            this.lblYmd.Name = "lblYmd";
            this.lblYmd.Size = new System.Drawing.Size(87, 15);
            this.lblYmd.strToolTip = null;
            this.lblYmd.TabIndex = 120;
            this.lblYmd.Text = "棚卸年月日";
            this.lblYmd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Chubunrui
            // 
            this.labelSet_Chubunrui.AppendLabelSize = 0;
            this.labelSet_Chubunrui.AppendLabelText = "";
            this.labelSet_Chubunrui.CodeTxtSize = 24;
            this.labelSet_Chubunrui.CodeTxtText = "";
            this.labelSet_Chubunrui.LabelName = "中分類コード";
            this.labelSet_Chubunrui.Location = new System.Drawing.Point(441, 238);
            this.labelSet_Chubunrui.Name = "labelSet_Chubunrui";
            this.labelSet_Chubunrui.ShowAppendFlg = false;
            this.labelSet_Chubunrui.Size = new System.Drawing.Size(350, 22);
            this.labelSet_Chubunrui.SpaceCodeValue = 4;
            this.labelSet_Chubunrui.SpaceNameCode = 4;
            this.labelSet_Chubunrui.SpaceValueAppend = 4;
            this.labelSet_Chubunrui.strDaibunCd = null;
            this.labelSet_Chubunrui.TabIndex = 4;
            this.labelSet_Chubunrui.ValueLabelSize = 200;
            this.labelSet_Chubunrui.ValueLabelText = "";
            // 
            // labelSet_Maker
            // 
            this.labelSet_Maker.AppendLabelSize = 0;
            this.labelSet_Maker.AppendLabelText = "";
            this.labelSet_Maker.CodeTxtSize = 40;
            this.labelSet_Maker.CodeTxtText = "";
            this.labelSet_Maker.LabelName = "メーカー";
            this.labelSet_Maker.Location = new System.Drawing.Point(441, 275);
            this.labelSet_Maker.Name = "labelSet_Maker";
            this.labelSet_Maker.ShowAppendFlg = false;
            this.labelSet_Maker.Size = new System.Drawing.Size(331, 22);
            this.labelSet_Maker.SpaceCodeValue = 4;
            this.labelSet_Maker.SpaceNameCode = 4;
            this.labelSet_Maker.SpaceValueAppend = 4;
            this.labelSet_Maker.strDaibunCd = null;
            this.labelSet_Maker.TabIndex = 5;
            this.labelSet_Maker.ValueLabelSize = 200;
            this.labelSet_Maker.ValueLabelText = "";
            // 
            // txtTanabanFrom
            // 
            this.txtTanabanFrom.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanabanFrom.Location = new System.Drawing.Point(487, 317);
            this.txtTanabanFrom.MaxLength = 6;
            this.txtTanabanFrom.Name = "txtTanabanFrom";
            this.txtTanabanFrom.Size = new System.Drawing.Size(60, 22);
            this.txtTanabanFrom.TabIndex = 6;
            // 
            // lblTanaban
            // 
            this.lblTanaban.AutoSize = true;
            this.lblTanaban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTanaban.Location = new System.Drawing.Point(442, 320);
            this.lblTanaban.Name = "lblTanaban";
            this.lblTanaban.Size = new System.Drawing.Size(39, 15);
            this.lblTanaban.strToolTip = null;
            this.lblTanaban.TabIndex = 124;
            this.lblTanaban.Text = "棚番";
            this.lblTanaban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTanabanKara
            // 
            this.lblTanabanKara.AutoSize = true;
            this.lblTanabanKara.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTanabanKara.Location = new System.Drawing.Point(555, 320);
            this.lblTanabanKara.Name = "lblTanabanKara";
            this.lblTanabanKara.Size = new System.Drawing.Size(23, 15);
            this.lblTanabanKara.strToolTip = null;
            this.lblTanabanKara.TabIndex = 124;
            this.lblTanabanKara.Text = "～";
            this.lblTanabanKara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTanabanTo
            // 
            this.txtTanabanTo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanabanTo.Location = new System.Drawing.Point(584, 317);
            this.txtTanabanTo.MaxLength = 6;
            this.txtTanabanTo.Name = "txtTanabanTo";
            this.txtTanabanTo.Size = new System.Drawing.Size(60, 22);
            this.txtTanabanTo.TabIndex = 7;
            // 
            // bgSort
            // 
            this.bgSort.Controls.Add(this.radSort);
            this.bgSort.Controls.Add(this.lblSort);
            this.bgSort.Location = new System.Drawing.Point(405, 456);
            this.bgSort.Name = "bgSort";
            this.bgSort.Size = new System.Drawing.Size(425, 158);
            this.bgSort.TabIndex = 101;
            this.bgSort.TabStop = false;
            // 
            // radSort
            // 
            this.radSort.LabelTitle = "";
            this.radSort.Location = new System.Drawing.Point(38, 33);
            this.radSort.Name = "radSort";
            this.radSort.PositionLabelTitle_X = 0;
            this.radSort.PositionLabelTitle_Y = 0;
            this.radSort.PositionRadbtn1_X = 0;
            this.radSort.PositionRadbtn1_Y = 0;
            this.radSort.PositionRadbtn2_X = 0;
            this.radSort.PositionRadbtn2_Y = 30;
            this.radSort.PositionRadbtn3_X = 0;
            this.radSort.PositionRadbtn3_Y = 60;
            this.radSort.PositionRadbtn4_X = 0;
            this.radSort.PositionRadbtn4_Y = 90;
            this.radSort.Radbtn1Text = "品名の昇順";
            this.radSort.Radbtn2Text = "メーカー・品名の昇順";
            this.radSort.Radbtn3Text = "棚番・メーカー・品名の昇順";
            this.radSort.Radbtn4Text = "棚番・品名の昇順";
            this.radSort.Size = new System.Drawing.Size(256, 116);
            this.radSort.TabIndex = 0;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSort.Location = new System.Drawing.Point(6, 0);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(103, 15);
            this.lblSort.strToolTip = null;
            this.lblSort.TabIndex = 124;
            this.lblSort.Text = "出力順の選択";
            this.lblSort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkPrintOnly
            // 
            this.chkPrintOnly.AutoSize = true;
            this.chkPrintOnly.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.chkPrintOnly.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPrintOnly.FocusedBackColor = System.Drawing.SystemColors.Control;
            this.chkPrintOnly.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPrintOnly.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.chkPrintOnly.Location = new System.Drawing.Point(443, 411);
            this.chkPrintOnly.Name = "chkPrintOnly";
            this.chkPrintOnly.Size = new System.Drawing.Size(90, 19);
            this.chkPrintOnly.TabIndex = 102;
            this.chkPrintOnly.Text = "印刷のみ";
            this.chkPrintOnly.UseVisualStyleBackColor = true;
            // 
            // lblSearchSetsumei
            // 
            this.lblSearchSetsumei.AutoSize = true;
            this.lblSearchSetsumei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSearchSetsumei.Location = new System.Drawing.Point(464, 362);
            this.lblSearchSetsumei.Name = "lblSearchSetsumei";
            this.lblSearchSetsumei.Size = new System.Drawing.Size(327, 15);
            this.lblSearchSetsumei.strToolTip = null;
            this.lblSearchSetsumei.TabIndex = 124;
            this.lblSearchSetsumei.Text = "（省略した場合は全てが対象になります。）";
            this.lblSearchSetsumei.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrintSetsumei
            // 
            this.lblPrintSetsumei.AutoSize = true;
            this.lblPrintSetsumei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblPrintSetsumei.Location = new System.Drawing.Point(553, 412);
            this.lblPrintSetsumei.Name = "lblPrintSetsumei";
            this.lblPrintSetsumei.Size = new System.Drawing.Size(439, 15);
            this.lblPrintSetsumei.strToolTip = null;
            this.lblPrintSetsumei.TabIndex = 124;
            this.lblPrintSetsumei.Text = "※データの作成は行わず、前回作成した内容を印刷します。";
            this.lblPrintSetsumei.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // F0570_TanaorosiKinyuhyoPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.chkPrintOnly);
            this.Controls.Add(this.bgSort);
            this.Controls.Add(this.txtTanabanTo);
            this.Controls.Add(this.txtTanabanFrom);
            this.Controls.Add(this.lblTanabanKara);
            this.Controls.Add(this.lblPrintSetsumei);
            this.Controls.Add(this.lblSearchSetsumei);
            this.Controls.Add(this.lblTanaban);
            this.Controls.Add(this.labelSet_Maker);
            this.Controls.Add(this.labelSet_Chubunrui);
            this.Controls.Add(this.txtYmd);
            this.Controls.Add(this.lblYmd);
            this.Controls.Add(this.labelSet_Daibunrui);
            this.Controls.Add(this.labelSet_Eigyosho);
            this.Name = "F0570_TanaorosiKinyuhyoPrint";
            this.Text = "F0570_TanaorosiKinyuhyoPrint";
            this.Load += new System.EventHandler(this.F0570_TanaorosiKinyuhyoPrint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F0570_TanaorosiKinyuhyoPrint_KeyDown);
            this.Controls.SetChildIndex(this.labelSet_Eigyosho, 0);
            this.Controls.SetChildIndex(this.labelSet_Daibunrui, 0);
            this.Controls.SetChildIndex(this.lblYmd, 0);
            this.Controls.SetChildIndex(this.txtYmd, 0);
            this.Controls.SetChildIndex(this.labelSet_Chubunrui, 0);
            this.Controls.SetChildIndex(this.labelSet_Maker, 0);
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
            this.Controls.SetChildIndex(this.lblTanaban, 0);
            this.Controls.SetChildIndex(this.lblSearchSetsumei, 0);
            this.Controls.SetChildIndex(this.lblPrintSetsumei, 0);
            this.Controls.SetChildIndex(this.lblTanabanKara, 0);
            this.Controls.SetChildIndex(this.txtTanabanFrom, 0);
            this.Controls.SetChildIndex(this.txtTanabanTo, 0);
            this.Controls.SetChildIndex(this.bgSort, 0);
            this.Controls.SetChildIndex(this.chkPrintOnly, 0);
            this.bgSort.ResumeLayout(false);
            this.bgSort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.LabelSet_Eigyosho labelSet_Eigyosho;
        private Common.Ctl.LabelSet_Daibunrui labelSet_Daibunrui;
        private Common.Ctl.BaseCalendar txtYmd;
        private Common.Ctl.BaseLabel lblYmd;
        private Common.Ctl.LabelSet_Chubunrui labelSet_Chubunrui;
        private Common.Ctl.LabelSet_Maker labelSet_Maker;
        private Common.Ctl.BaseText txtTanabanFrom;
        private Common.Ctl.BaseLabel lblTanaban;
        private Common.Ctl.BaseLabel lblTanabanKara;
        private Common.Ctl.BaseText txtTanabanTo;
        private System.Windows.Forms.GroupBox bgSort;
        private Common.Ctl.RadSet_4btn radSort;
        private Common.Ctl.BaseCheckBox chkPrintOnly;
        private Common.Ctl.BaseLabel lblSearchSetsumei;
        private Common.Ctl.BaseLabel lblSort;
        private Common.Ctl.BaseLabel lblPrintSetsumei;
    }
}