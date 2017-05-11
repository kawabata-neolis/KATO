namespace KATO.Common.Ctl
{
    partial class RadSet_4btn
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
            this.radbtn2 = new System.Windows.Forms.RadioButton();
            this.radbtn1 = new System.Windows.Forms.RadioButton();
            this.radbtn0 = new System.Windows.Forms.RadioButton();
            this.radbtn3 = new System.Windows.Forms.RadioButton();
            this.lblTitle = new KATO.Common.Ctl.BaseLabel(this.components);
            this.SuspendLayout();
            // 
            // radbtn2
            // 
            this.radbtn2.AutoSize = true;
            this.radbtn2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.radbtn2.Location = new System.Drawing.Point(375, -2);
            this.radbtn2.Name = "radbtn2";
            this.radbtn2.Size = new System.Drawing.Size(89, 19);
            this.radbtn2.TabIndex = 6;
            this.radbtn2.TabStop = true;
            this.radbtn2.Text = "選択肢３";
            this.radbtn2.UseVisualStyleBackColor = true;
            this.radbtn2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadSet_4btn_KeyDown);
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
            this.radbtn1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadSet_4btn_KeyDown);
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
            this.radbtn0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadSet_4btn_KeyDown);
            // 
            // radbtn3
            // 
            this.radbtn3.AutoSize = true;
            this.radbtn3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.radbtn3.Location = new System.Drawing.Point(487, -2);
            this.radbtn3.Name = "radbtn3";
            this.radbtn3.Size = new System.Drawing.Size(89, 19);
            this.radbtn3.TabIndex = 8;
            this.radbtn3.TabStop = true;
            this.radbtn3.Text = "選択肢４";
            this.radbtn3.UseVisualStyleBackColor = true;
            this.radbtn3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadSet_4btn_KeyDown);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTitle.Location = new System.Drawing.Point(-3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(87, 15);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "グループ名";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RadSet_4btn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radbtn3);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.radbtn2);
            this.Controls.Add(this.radbtn1);
            this.Controls.Add(this.radbtn0);
            this.Name = "RadSet_4btn";
            this.Size = new System.Drawing.Size(600, 150);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadSet_4btn_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseLabel lblTitle;
        public System.Windows.Forms.RadioButton radbtn2;
        public System.Windows.Forms.RadioButton radbtn1;
        public System.Windows.Forms.RadioButton radbtn0;
        public System.Windows.Forms.RadioButton radbtn3;
    }
}
