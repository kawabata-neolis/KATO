namespace KATO.Common.Form
{
    partial class PrintForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.prtList = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new KATO.Common.Ctl.BaseButton();
            this.btnPrint = new KATO.Common.Ctl.BaseButton();
            this.btnPreview = new KATO.Common.Ctl.BaseButton();
            this.lblPage = new KATO.Common.Ctl.BaseLabelGray();
            this.rdPage3 = new KATO.Common.Ctl.BaseRadioButton();
            this.rdPage2 = new KATO.Common.Ctl.BaseRadioButton();
            this.rdPage1 = new KATO.Common.Ctl.BaseRadioButton();
            this.rdPage0 = new KATO.Common.Ctl.BaseRadioButton();
            this.btnPrt = new KATO.Common.Ctl.BaseButton();
            this.txtPrt = new KATO.Common.Ctl.BaseText();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPrt);
            this.groupBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(21, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "使用するプリンタ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.prtList);
            this.groupBox2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(21, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 124);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "プリンタの選択";
            // 
            // prtList
            // 
            this.prtList.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.prtList.FormattingEnabled = true;
            this.prtList.ItemHeight = 15;
            this.prtList.Location = new System.Drawing.Point(8, 22);
            this.prtList.Name = "prtList";
            this.prtList.Size = new System.Drawing.Size(279, 94);
            this.prtList.TabIndex = 4;
            this.prtList.SelectedIndexChanged += new System.EventHandler(this.prtList_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblPage);
            this.groupBox3.Controls.Add(this.rdPage3);
            this.groupBox3.Controls.Add(this.rdPage2);
            this.groupBox3.Controls.Add(this.rdPage1);
            this.groupBox3.Controls.Add(this.rdPage0);
            this.groupBox3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(336, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 136);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "出力用紙";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnCancel.Location = new System.Drawing.Point(223, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.baseButton3_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnPrint.Location = new System.Drawing.Point(122, 260);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "一括印刷";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnPreview.Location = new System.Drawing.Point(21, 260);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(95, 23);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "プレビュー";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblPage
            // 
            this.lblPage.AutoEllipsis = true;
            this.lblPage.BackColor = System.Drawing.Color.Gainsboro;
            this.lblPage.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblPage.ForeColor = System.Drawing.Color.Blue;
            this.lblPage.Location = new System.Drawing.Point(119, 22);
            this.lblPage.Name = "lblPage";
            this.lblPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPage.Size = new System.Drawing.Size(80, 22);
            this.lblPage.TabIndex = 99;
            this.lblPage.Text = "B4横";
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdPage3
            // 
            this.rdPage3.AutoSize = true;
            this.rdPage3.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.rdPage3.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.rdPage3.FocusedBackColor = System.Drawing.SystemColors.Control;
            this.rdPage3.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.rdPage3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.rdPage3.Location = new System.Drawing.Point(8, 101);
            this.rdPage3.Name = "rdPage3";
            this.rdPage3.Size = new System.Drawing.Size(105, 19);
            this.rdPage3.TabIndex = 3;
            this.rdPage3.TabStop = true;
            this.rdPage3.Text = "Ｂ４に印刷";
            this.rdPage3.UseVisualStyleBackColor = true;
            // 
            // rdPage2
            // 
            this.rdPage2.AutoSize = true;
            this.rdPage2.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.rdPage2.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.rdPage2.FocusedBackColor = System.Drawing.SystemColors.Control;
            this.rdPage2.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.rdPage2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.rdPage2.Location = new System.Drawing.Point(8, 74);
            this.rdPage2.Name = "rdPage2";
            this.rdPage2.Size = new System.Drawing.Size(105, 19);
            this.rdPage2.TabIndex = 2;
            this.rdPage2.TabStop = true;
            this.rdPage2.Text = "Ａ４に印刷";
            this.rdPage2.UseVisualStyleBackColor = true;
            // 
            // rdPage1
            // 
            this.rdPage1.AutoSize = true;
            this.rdPage1.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.rdPage1.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.rdPage1.FocusedBackColor = System.Drawing.SystemColors.Control;
            this.rdPage1.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.rdPage1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.rdPage1.Location = new System.Drawing.Point(8, 49);
            this.rdPage1.Name = "rdPage1";
            this.rdPage1.Size = new System.Drawing.Size(105, 19);
            this.rdPage1.TabIndex = 1;
            this.rdPage1.TabStop = true;
            this.rdPage1.Text = "Ｂ５に印刷";
            this.rdPage1.UseVisualStyleBackColor = true;
            // 
            // rdPage0
            // 
            this.rdPage0.AutoSize = true;
            this.rdPage0.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.rdPage0.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.rdPage0.FocusedBackColor = System.Drawing.SystemColors.Control;
            this.rdPage0.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.rdPage0.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.rdPage0.Location = new System.Drawing.Point(8, 24);
            this.rdPage0.Name = "rdPage0";
            this.rdPage0.Size = new System.Drawing.Size(105, 19);
            this.rdPage0.TabIndex = 0;
            this.rdPage0.TabStop = true;
            this.rdPage0.Text = "原稿サイズ";
            this.rdPage0.UseVisualStyleBackColor = true;
            // 
            // btnPrt
            // 
            this.btnPrt.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnPrt.Location = new System.Drawing.Point(21, 93);
            this.btnPrt.Name = "btnPrt";
            this.btnPrt.Size = new System.Drawing.Size(111, 23);
            this.btnPrt.TabIndex = 3;
            this.btnPrt.Text = "他のプリンタ";
            this.btnPrt.UseVisualStyleBackColor = true;
            // 
            // txtPrt
            // 
            this.txtPrt.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtPrt.Location = new System.Drawing.Point(8, 21);
            this.txtPrt.Name = "txtPrt";
            this.txtPrt.Size = new System.Drawing.Size(279, 22);
            this.txtPrt.TabIndex = 1;
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 312);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnPrt);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PrintForm";
            this.Text = "PrintForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Ctl.BaseText txtPrt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox prtList;
        private Ctl.BaseButton btnPrt;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ctl.BaseRadioButton rdPage0;
        private Ctl.BaseLabelGray lblPage;
        private Ctl.BaseRadioButton rdPage3;
        private Ctl.BaseRadioButton rdPage2;
        private Ctl.BaseRadioButton rdPage1;
        private Ctl.BaseButton btnPreview;
        private Ctl.BaseButton btnPrint;
        private Ctl.BaseButton btnCancel;
    }
}