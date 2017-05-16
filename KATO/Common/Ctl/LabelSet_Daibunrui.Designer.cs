namespace KATO.Common.Ctl
{
    partial class LabelSet_Daibunrui
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
            this.SuspendLayout();
            // 
            // codeTxt
            // 
            this.codeTxt.Location = new System.Drawing.Point(107, 0);
            this.codeTxt.MaxLength = 2;
            this.codeTxt.Size = new System.Drawing.Size(24, 22);
            this.codeTxt.TextChanged += new System.EventHandler(this.codeTxt_TextChanged);
            this.codeTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaibunruiKeyDown);
            this.codeTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtDaibunruiKeyUp);
            this.codeTxt.Leave += new System.EventHandler(this.updTxtDaibunruiLeave);
            // 
            // LabelSet_Daibunrui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.CodeTxtSize = 24;
            this.LabelName = "大分類コード";
            this.Name = "LabelSet_Daibunrui";
            this.ValueLabelSize = 150;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
