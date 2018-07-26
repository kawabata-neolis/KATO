namespace KATO.Form.M1200_Group
{
    partial class M1200_Group
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
            this.lblGroupCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblGroupName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtGroupName = new KATO.Common.Ctl.BaseText();
            this.txtGroupId = new KATO.Common.Ctl.BaseText();
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
            // lblGroupCd
            // 
            this.lblGroupCd.AutoSize = true;
            this.lblGroupCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblGroupCd.Location = new System.Drawing.Point(391, 93);
            this.lblGroupCd.Name = "lblGroupCd";
            this.lblGroupCd.Size = new System.Drawing.Size(119, 15);
            this.lblGroupCd.strToolTip = null;
            this.lblGroupCd.TabIndex = 87;
            this.lblGroupCd.Text = "グループコード";
            this.lblGroupCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroupName
            // 
            this.lblGroupName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblGroupName.Location = new System.Drawing.Point(630, 93);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(87, 15);
            this.lblGroupName.strToolTip = null;
            this.lblGroupName.TabIndex = 90;
            this.lblGroupName.Text = "グループ名";
            this.lblGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtGroupName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtGroupName.Location = new System.Drawing.Point(729, 90);
            this.txtGroupName.MaxLength = 12;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(105, 22);
            this.txtGroupName.TabIndex = 1;
            this.txtGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            this.txtGroupName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtShohizeiKeyUp);
            // 
            // txtGroupId
            // 
            this.txtGroupId.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtGroupId.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtGroupId.Location = new System.Drawing.Point(517, 90);
            this.txtGroupId.MaxLength = 4;
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.Size = new System.Drawing.Size(40, 22);
            this.txtGroupId.TabIndex = 0;
            this.txtGroupId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTorihikikubun_KeyDown);
            this.txtGroupId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtShohizeiKeyUp);
            this.txtGroupId.Leave += new System.EventHandler(this.txtGroupId_Leave);
            // 
            // M1200_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 826);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.txtGroupId);
            this.Controls.Add(this.lblGroupCd);
            this.Name = "M1200_Group";
            this.Text = "M1200_Group";
            this.Load += new System.EventHandler(this.M1200_Group_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1200_Group_KeyDown);
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
            this.Controls.SetChildIndex(this.lblGroupCd, 0);
            this.Controls.SetChildIndex(this.txtGroupId, 0);
            this.Controls.SetChildIndex(this.txtGroupName, 0);
            this.Controls.SetChildIndex(this.lblGroupName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseLabel lblGroupCd;
        private Common.Ctl.BaseLabel lblGroupName;
        private Common.Ctl.BaseText txtGroupName;
        private Common.Ctl.BaseText txtGroupId;
    }
}