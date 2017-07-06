namespace KATO.Common.Ctl
{
    partial class RadSet_2btn
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
            this.radbtn1 = new System.Windows.Forms.RadioButton();
            this.radbtn0 = new System.Windows.Forms.RadioButton();
            this.lblTitle = new KATO.Common.Ctl.BaseLabel(this.components);
            this.SuspendLayout();
            // 
            // radbtn1
            // 
            this.radbtn1.AutoSize = true;
            this.radbtn1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.radbtn1.Location = new System.Drawing.Point(259, -2);
            this.radbtn1.Name = "radbtn1";
            this.radbtn1.Size = new System.Drawing.Size(89, 19);
            this.radbtn1.TabIndex = 5;
            this.radbtn1.TabStop = true;
            this.radbtn1.Text = "選択肢２";
            this.radbtn1.UseVisualStyleBackColor = true;
            this.radbtn1.CheckedChanged += new System.EventHandler(this.radbtn1_CheckedChanged);
            this.radbtn1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadSet_2btn_KeyDown);
            // 
            // radbtn0
            // 
            this.radbtn0.AutoSize = true;
            this.radbtn0.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.radbtn0.Location = new System.Drawing.Point(149, -2);
            this.radbtn0.Name = "radbtn0";
            this.radbtn0.Size = new System.Drawing.Size(89, 19);
            this.radbtn0.TabIndex = 4;
            this.radbtn0.TabStop = true;
            this.radbtn0.Text = "選択肢１";
            this.radbtn0.UseVisualStyleBackColor = true;
            this.radbtn0.CheckedChanged += new System.EventHandler(this.radbtn0_CheckedChanged);
            this.radbtn0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadSet_2btn_KeyDown);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTitle.Location = new System.Drawing.Point(-3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(87, 15);
            this.lblTitle.strToolTip = null;
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "グループ名";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RadSet_2btn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.radbtn1);
            this.Controls.Add(this.radbtn0);
            this.Name = "RadSet_2btn";
            this.Size = new System.Drawing.Size(400, 100);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadSet_2btn_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseLabel lblTitle;
        public System.Windows.Forms.RadioButton radbtn1;
        public System.Windows.Forms.RadioButton radbtn0;
    }
}
