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
            this.labelSet_TokuisakiCdTo = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.nameLabel = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_TokuisakiCdFrom = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.object_c546be5e_21aa_4c18_8add_ae9797538958 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_TokuisakiCdTo.SuspendLayout();
            this.labelSet_TokuisakiCdFrom.SuspendLayout();
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
            // btnF04
            // 
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(228, 170);
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
            this.txtUserID.Location = new System.Drawing.Point(333, 167);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(194, 22);
            this.txtUserID.TabIndex = 0;
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(228, 216);
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
            this.txtNyuryokuYMDstart.Location = new System.Drawing.Point(333, 213);
            this.txtNyuryokuYMDstart.MaxLength = 10;
            this.txtNyuryokuYMDstart.Name = "txtNyuryokuYMDstart";
            this.txtNyuryokuYMDstart.Size = new System.Drawing.Size(194, 22);
            this.txtNyuryokuYMDstart.TabIndex = 1;
            this.txtNyuryokuYMDstart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNyuryokuYMDend
            // 
            this.txtNyuryokuYMDend.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtNyuryokuYMDend.Location = new System.Drawing.Point(595, 213);
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
            this.baseLabel3.Location = new System.Drawing.Point(545, 216);
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
            this.baseLabel4.Location = new System.Drawing.Point(228, 271);
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
            this.txtDenpyoYMDstart.Location = new System.Drawing.Point(333, 268);
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
            this.baseLabel5.Location = new System.Drawing.Point(545, 271);
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
            this.txtDenpyoYMDend.Location = new System.Drawing.Point(595, 268);
            this.txtDenpyoYMDend.MaxLength = 10;
            this.txtDenpyoYMDend.Name = "txtDenpyoYMDend";
            this.txtDenpyoYMDend.Size = new System.Drawing.Size(194, 22);
            this.txtDenpyoYMDend.TabIndex = 4;
            this.txtDenpyoYMDend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelSet_TokuisakiCdTo
            // 
            this.labelSet_TokuisakiCdTo.AppendLabelSize = 40;
            this.labelSet_TokuisakiCdTo.AppendLabelText = "";
            this.labelSet_TokuisakiCdTo.CodeTxtSize = 40;
            this.labelSet_TokuisakiCdTo.CodeTxtText = "";
            this.labelSet_TokuisakiCdTo.Controls.Add(this.nameLabel);
            this.labelSet_TokuisakiCdTo.LabelName = "～";
            this.labelSet_TokuisakiCdTo.Location = new System.Drawing.Point(386, 307);
            this.labelSet_TokuisakiCdTo.Name = "labelSet_TokuisakiCdTo";
            this.labelSet_TokuisakiCdTo.ShowAppendFlg = false;
            this.labelSet_TokuisakiCdTo.Size = new System.Drawing.Size(82, 22);
            this.labelSet_TokuisakiCdTo.SpaceCodeValue = 4;
            this.labelSet_TokuisakiCdTo.SpaceNameCode = 4;
            this.labelSet_TokuisakiCdTo.SpaceValueAppend = 4;
            this.labelSet_TokuisakiCdTo.TabIndex = 92;
            this.labelSet_TokuisakiCdTo.ValueLabelSize = 0;
            this.labelSet_TokuisakiCdTo.ValueLabelText = "";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.nameLabel.Location = new System.Drawing.Point(2, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(23, 15);
            this.nameLabel.strToolTip = null;
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "～";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_TokuisakiCdFrom
            // 
            this.labelSet_TokuisakiCdFrom.AppendLabelSize = 40;
            this.labelSet_TokuisakiCdFrom.AppendLabelText = "";
            this.labelSet_TokuisakiCdFrom.CodeTxtSize = 40;
            this.labelSet_TokuisakiCdFrom.CodeTxtText = "";
            this.labelSet_TokuisakiCdFrom.Controls.Add(this.object_c546be5e_21aa_4c18_8add_ae9797538958);
            this.labelSet_TokuisakiCdFrom.LabelName = "得意先コード";
            this.labelSet_TokuisakiCdFrom.Location = new System.Drawing.Point(231, 307);
            this.labelSet_TokuisakiCdFrom.Name = "labelSet_TokuisakiCdFrom";
            this.labelSet_TokuisakiCdFrom.ShowAppendFlg = false;
            this.labelSet_TokuisakiCdFrom.Size = new System.Drawing.Size(159, 22);
            this.labelSet_TokuisakiCdFrom.SpaceCodeValue = 4;
            this.labelSet_TokuisakiCdFrom.SpaceNameCode = 4;
            this.labelSet_TokuisakiCdFrom.SpaceValueAppend = 4;
            this.labelSet_TokuisakiCdFrom.TabIndex = 91;
            this.labelSet_TokuisakiCdFrom.ValueLabelSize = 0;
            this.labelSet_TokuisakiCdFrom.ValueLabelText = "";
            // 
            // object_c546be5e_21aa_4c18_8add_ae9797538958
            // 
            this.object_c546be5e_21aa_4c18_8add_ae9797538958.AutoSize = true;
            this.object_c546be5e_21aa_4c18_8add_ae9797538958.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_c546be5e_21aa_4c18_8add_ae9797538958.Location = new System.Drawing.Point(2, 3);
            this.object_c546be5e_21aa_4c18_8add_ae9797538958.Name = "object_c546be5e_21aa_4c18_8add_ae9797538958";
            this.object_c546be5e_21aa_4c18_8add_ae9797538958.Size = new System.Drawing.Size(103, 15);
            this.object_c546be5e_21aa_4c18_8add_ae9797538958.strToolTip = null;
            this.object_c546be5e_21aa_4c18_8add_ae9797538958.TabIndex = 0;
            this.object_c546be5e_21aa_4c18_8add_ae9797538958.Text = "仕入先コード";
            this.object_c546be5e_21aa_4c18_8add_ae9797538958.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // A0150_UriageCheckPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.labelSet_TokuisakiCdTo);
            this.Controls.Add(this.labelSet_TokuisakiCdFrom);
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
            this.Text = "Form1";
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
            this.Controls.SetChildIndex(this.labelSet_TokuisakiCdFrom, 0);
            this.Controls.SetChildIndex(this.labelSet_TokuisakiCdTo, 0);
            this.labelSet_TokuisakiCdTo.ResumeLayout(false);
            this.labelSet_TokuisakiCdTo.PerformLayout();
            this.labelSet_TokuisakiCdFrom.ResumeLayout(false);
            this.labelSet_TokuisakiCdFrom.PerformLayout();
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
        private Common.Ctl.LabelSet_Torihikisaki labelSet_TokuisakiCdTo;
        private Common.Ctl.BaseLabel nameLabel;
        private Common.Ctl.LabelSet_Torihikisaki labelSet_TokuisakiCdFrom;
        private Common.Ctl.BaseLabel object_c546be5e_21aa_4c18_8add_ae9797538958;
    }
}