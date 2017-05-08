namespace KATO.Common.Ctl
{
    partial class BaseMessageBoxYN
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
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseButton1 = new KATO.Common.Ctl.BaseButton();
            this.baseButton2 = new KATO.Common.Ctl.BaseButton();
            this.SuspendLayout();
            // 
            // baseLabel1
            // 
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(12, 59);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(310, 38);
            this.baseLabel1.TabIndex = 1;
            this.baseLabel1.Text = "baseLabel1";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // baseButton1
            // 
            this.baseButton1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseButton1.Location = new System.Drawing.Point(54, 147);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.Size = new System.Drawing.Size(101, 23);
            this.baseButton1.TabIndex = 0;
            this.baseButton1.Text = "はい";
            this.baseButton1.UseVisualStyleBackColor = true;
            this.baseButton1.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // baseButton2
            // 
            this.baseButton2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseButton2.Location = new System.Drawing.Point(184, 147);
            this.baseButton2.Name = "baseButton2";
            this.baseButton2.Size = new System.Drawing.Size(101, 23);
            this.baseButton2.TabIndex = 0;
            this.baseButton2.Text = "キャンセル";
            this.baseButton2.UseVisualStyleBackColor = true;
            this.baseButton2.Click += new System.EventHandler(this.baseButton2_Click);
            // 
            // BaseMessageBoxYN
            // 
            this.ClientSize = new System.Drawing.Size(334, 185);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.baseButton2);
            this.Controls.Add(this.baseButton1);
            this.Name = "BaseMessageBoxYN";
            this.ResumeLayout(false);

        }

        #endregion

        private BaseButton baseButton1;
        private BaseLabel baseLabel1;
        private BaseButton baseButton2;
    }
}
