namespace KATO.Common.Ctl
{
    partial class LabelSet_Eigyosho
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
            this.codeTxt.MaxLength = 4;
            this.codeTxt.Size = new System.Drawing.Size(40, 22);
            this.codeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.codeTxt.EnabledChanged += new System.EventHandler(this.codeTxt_EnabledChanged);
            this.codeTxt.TextChanged += new System.EventHandler(this.codeTxt_TextChanged);
            this.codeTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judEigyoushoKeyDown);
            this.codeTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judEigyousyoKeyUp);
            this.codeTxt.Leave += new System.EventHandler(this.updTxtEigyoushoLeave);
            // 
            // LabelSet_Eigyosho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.CodeTxtSize = 40;
            this.LabelName = "営業所コード";
            this.Name = "LabelSet_Eigyosho";
            this.Size = new System.Drawing.Size(624, 22);
            this.ValueLabelSize = 250;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
