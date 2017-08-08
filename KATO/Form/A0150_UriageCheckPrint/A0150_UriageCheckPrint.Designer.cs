namespace KATO.Form.A0150_UriageCheckPrint
{
    partial class A0150_UriageCheckPrint
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
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtUserID = new KATO.Common.Ctl.BaseText();
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtNyuryokuYMDstart = new KATO.Common.Ctl.BaseCalendar();
            this.txtNyuryokuYMDend = new KATO.Common.Ctl.BaseCalendar();
            this.baseLabel3 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel4 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtDenpyoYMDstart = new KATO.Common.Ctl.BaseCalendar();
            this.baseLabel5 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtDenpyoYMDend = new KATO.Common.Ctl.BaseCalendar();
            this.SuspendLayout();
            // 
            // btnF10
            // 
            this.btnF10.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(233, 48);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(87, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 87;
            this.baseLabel1.Text = "ユーザＩＤ";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtUserID.Location = new System.Drawing.Point(338, 45);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(194, 22);
            this.txtUserID.TabIndex = 0;
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(233, 94);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(87, 15);
            this.baseLabel2.strToolTip = null;
            this.baseLabel2.TabIndex = 87;
            this.baseLabel2.Text = "入力年月日";
            this.baseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNyuryokuYMDstart
            // 
            this.txtNyuryokuYMDstart.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtNyuryokuYMDstart.Location = new System.Drawing.Point(338, 91);
            this.txtNyuryokuYMDstart.MaxLength = 10;
            this.txtNyuryokuYMDstart.Name = "txtNyuryokuYMDstart";
            this.txtNyuryokuYMDstart.Size = new System.Drawing.Size(194, 22);
            this.txtNyuryokuYMDstart.TabIndex = 1;
            this.txtNyuryokuYMDstart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNyuryokuYMDend
            // 
            this.txtNyuryokuYMDend.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtNyuryokuYMDend.Location = new System.Drawing.Point(600, 91);
            this.txtNyuryokuYMDend.MaxLength = 10;
            this.txtNyuryokuYMDend.Name = "txtNyuryokuYMDend";
            this.txtNyuryokuYMDend.Size = new System.Drawing.Size(194, 22);
            this.txtNyuryokuYMDend.TabIndex = 2;
            this.txtNyuryokuYMDend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // baseLabel3
            // 
            this.baseLabel3.AutoSize = true;
            this.baseLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel3.Location = new System.Drawing.Point(550, 94);
            this.baseLabel3.Name = "baseLabel3";
            this.baseLabel3.Size = new System.Drawing.Size(23, 15);
            this.baseLabel3.strToolTip = null;
            this.baseLabel3.TabIndex = 90;
            this.baseLabel3.Text = "～";
            this.baseLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseLabel4
            // 
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel4.Location = new System.Drawing.Point(233, 149);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(87, 15);
            this.baseLabel4.strToolTip = null;
            this.baseLabel4.TabIndex = 87;
            this.baseLabel4.Text = "伝票年月日";
            this.baseLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDenpyoYMDstart
            // 
            this.txtDenpyoYMDstart.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDenpyoYMDstart.Location = new System.Drawing.Point(338, 146);
            this.txtDenpyoYMDstart.MaxLength = 10;
            this.txtDenpyoYMDstart.Name = "txtDenpyoYMDstart";
            this.txtDenpyoYMDstart.Size = new System.Drawing.Size(194, 22);
            this.txtDenpyoYMDstart.TabIndex = 3;
            this.txtDenpyoYMDstart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // baseLabel5
            // 
            this.baseLabel5.AutoSize = true;
            this.baseLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel5.Location = new System.Drawing.Point(550, 149);
            this.baseLabel5.Name = "baseLabel5";
            this.baseLabel5.Size = new System.Drawing.Size(23, 15);
            this.baseLabel5.strToolTip = null;
            this.baseLabel5.TabIndex = 90;
            this.baseLabel5.Text = "～";
            this.baseLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDenpyoYMDend
            // 
            this.txtDenpyoYMDend.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDenpyoYMDend.Location = new System.Drawing.Point(600, 146);
            this.txtDenpyoYMDend.MaxLength = 10;
            this.txtDenpyoYMDend.Name = "txtDenpyoYMDend";
            this.txtDenpyoYMDend.Size = new System.Drawing.Size(194, 22);
            this.txtDenpyoYMDend.TabIndex = 4;
            this.txtDenpyoYMDend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // A0150_UriageCheckPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.txtDenpyoYMDend);
            this.Controls.Add(this.baseLabel5);
            this.Controls.Add(this.txtNyuryokuYMDend);
            this.Controls.Add(this.txtDenpyoYMDstart);
            this.Controls.Add(this.baseLabel3);
            this.Controls.Add(this.txtNyuryokuYMDstart);
            this.Controls.Add(this.baseLabel4);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.baseLabel1);
            this.Name = "A0150_UriageCheckPrint";
            this.Text = "売上チェックリスト";
            this.Load += new System.EventHandler(this.A0150_UriageCheckPrint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.C0490_UriageSuiiHyo_KeyDown);
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
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.baseLabel2, 0);
            this.Controls.SetChildIndex(this.txtUserID, 0);
            this.Controls.SetChildIndex(this.baseLabel4, 0);
            this.Controls.SetChildIndex(this.txtNyuryokuYMDstart, 0);
            this.Controls.SetChildIndex(this.baseLabel3, 0);
            this.Controls.SetChildIndex(this.txtDenpyoYMDstart, 0);
            this.Controls.SetChildIndex(this.txtNyuryokuYMDend, 0);
            this.Controls.SetChildIndex(this.baseLabel5, 0);
            this.Controls.SetChildIndex(this.txtDenpyoYMDend, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.BaseText txtUserID;
        private Common.Ctl.BaseLabel baseLabel2;
        private Common.Ctl.BaseCalendar txtNyuryokuYMDstart;
        private Common.Ctl.BaseCalendar txtNyuryokuYMDend;
        private Common.Ctl.BaseLabel baseLabel3;
        private Common.Ctl.BaseLabel baseLabel4;
        private Common.Ctl.BaseCalendar txtDenpyoYMDstart;
        private Common.Ctl.BaseLabel baseLabel5;
        private Common.Ctl.BaseCalendar txtDenpyoYMDend;
    }
}