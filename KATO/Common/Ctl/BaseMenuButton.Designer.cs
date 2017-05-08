namespace KATO.Common.Ctl
{
    partial class BaseMenuButton
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
            // BaseMenuButton
            // 
            this.BackColor = System.Drawing.Color.LightYellow;
            this.Size = new System.Drawing.Size(280, 40);
            this.UseVisualStyleBackColor = false;
            this.Enter += new System.EventHandler(this.BaseButton_Enter);
            this.Leave += new System.EventHandler(this.BaseButton_Leave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
