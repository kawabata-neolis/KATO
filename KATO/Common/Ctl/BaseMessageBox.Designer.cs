namespace KATO.Common.Ctl
{
    partial class BaseMessageBox
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseButtonG3_CANCEL = new KATO.Common.Ctl.BaseButton();
            this.baseButtonG3_NO = new KATO.Common.Ctl.BaseButton();
            this.baseButtonG3_YES = new KATO.Common.Ctl.BaseButton();
            this.baseButtonG2_NO = new KATO.Common.Ctl.BaseButton();
            this.baseButtonG2_YES = new KATO.Common.Ctl.BaseButton();
            this.baseButtonG1_OK = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(26, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 35);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // baseLabel1
            // 
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.baseLabel1.Location = new System.Drawing.Point(57, 57);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(383, 54);
            this.baseLabel1.TabIndex = 1;
            this.baseLabel1.Text = "baseLabel1";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // baseButtonG3_CANCEL
            // 
            this.baseButtonG3_CANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.baseButtonG3_CANCEL.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseButtonG3_CANCEL.Location = new System.Drawing.Point(338, 124);
            this.baseButtonG3_CANCEL.Name = "baseButtonG3_CANCEL";
            this.baseButtonG3_CANCEL.Size = new System.Drawing.Size(96, 23);
            this.baseButtonG3_CANCEL.TabIndex = 1;
            this.baseButtonG3_CANCEL.Text = "キャンセル";
            this.baseButtonG3_CANCEL.UseVisualStyleBackColor = true;
            this.baseButtonG3_CANCEL.Visible = false;
            this.baseButtonG3_CANCEL.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // baseButtonG3_NO
            // 
            this.baseButtonG3_NO.DialogResult = System.Windows.Forms.DialogResult.No;
            this.baseButtonG3_NO.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseButtonG3_NO.Location = new System.Drawing.Point(197, 124);
            this.baseButtonG3_NO.Name = "baseButtonG3_NO";
            this.baseButtonG3_NO.Size = new System.Drawing.Size(96, 23);
            this.baseButtonG3_NO.TabIndex = 0;
            this.baseButtonG3_NO.Text = "いいえ";
            this.baseButtonG3_NO.UseVisualStyleBackColor = true;
            this.baseButtonG3_NO.Visible = false;
            this.baseButtonG3_NO.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // baseButtonG3_YES
            // 
            this.baseButtonG3_YES.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.baseButtonG3_YES.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseButtonG3_YES.Location = new System.Drawing.Point(58, 124);
            this.baseButtonG3_YES.Name = "baseButtonG3_YES";
            this.baseButtonG3_YES.Size = new System.Drawing.Size(96, 23);
            this.baseButtonG3_YES.TabIndex = 2;
            this.baseButtonG3_YES.Text = "はい";
            this.baseButtonG3_YES.UseVisualStyleBackColor = true;
            this.baseButtonG3_YES.Visible = false;
            this.baseButtonG3_YES.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // baseButtonG2_NO
            // 
            this.baseButtonG2_NO.DialogResult = System.Windows.Forms.DialogResult.No;
            this.baseButtonG2_NO.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseButtonG2_NO.Location = new System.Drawing.Point(268, 124);
            this.baseButtonG2_NO.Name = "baseButtonG2_NO";
            this.baseButtonG2_NO.Size = new System.Drawing.Size(96, 23);
            this.baseButtonG2_NO.TabIndex = 0;
            this.baseButtonG2_NO.Text = "いいえ";
            this.baseButtonG2_NO.UseVisualStyleBackColor = true;
            this.baseButtonG2_NO.Visible = false;
            this.baseButtonG2_NO.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // baseButtonG2_YES
            // 
            this.baseButtonG2_YES.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.baseButtonG2_YES.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseButtonG2_YES.Location = new System.Drawing.Point(128, 124);
            this.baseButtonG2_YES.Name = "baseButtonG2_YES";
            this.baseButtonG2_YES.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.baseButtonG2_YES.Size = new System.Drawing.Size(96, 23);
            this.baseButtonG2_YES.TabIndex = 1;
            this.baseButtonG2_YES.Text = "はい";
            this.baseButtonG2_YES.UseVisualStyleBackColor = true;
            this.baseButtonG2_YES.Visible = false;
            this.baseButtonG2_YES.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // baseButtonG1_OK
            // 
            this.baseButtonG1_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.baseButtonG1_OK.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseButtonG1_OK.Location = new System.Drawing.Point(197, 124);
            this.baseButtonG1_OK.Name = "baseButtonG1_OK";
            this.baseButtonG1_OK.Size = new System.Drawing.Size(96, 23);
            this.baseButtonG1_OK.TabIndex = 0;
            this.baseButtonG1_OK.Text = "OK";
            this.baseButtonG1_OK.UseVisualStyleBackColor = true;
            this.baseButtonG1_OK.Visible = false;
            this.baseButtonG1_OK.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // BaseMessageBox
            // 
            this.ClientSize = new System.Drawing.Size(489, 161);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.baseButtonG3_CANCEL);
            this.Controls.Add(this.baseButtonG3_NO);
            this.Controls.Add(this.baseButtonG3_YES);
            this.Controls.Add(this.baseButtonG2_NO);
            this.Controls.Add(this.baseButtonG2_YES);
            this.Controls.Add(this.baseButtonG1_OK);
            this.Name = "BaseMessageBox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseButton baseButtonG1_OK;
        private BaseLabel baseLabel1;
        private BaseButton baseButtonG2_YES;
        private BaseButton baseButtonG2_NO;
        private BaseButton baseButtonG3_NO;
        private BaseButton baseButtonG3_YES;
        private BaseButton baseButtonG3_CANCEL;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
