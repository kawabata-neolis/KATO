namespace KATO.Common.Ctl
{
    partial class LabelSet_Menu
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
            this.codeTxt.Location = new System.Drawing.Point(19, 0);
            this.codeTxt.MaxLength = 3;
            this.codeTxt.Size = new System.Drawing.Size(40, 22);
            this.codeTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codeTxt_KeyDown);
            this.codeTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.codeTxt_KeyUp);
            this.codeTxt.Leave += new System.EventHandler(this.codeTxt_Leave);
            // 
            // LabelSet_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CodeTxtSize = 40;
            this.LabelName = "0";
            this.Name = "LabelSet_Menu";
            this.Size = new System.Drawing.Size(637, 22);
            this.ValueLabelSize = 300;
            this.EnabledChanged += new System.EventHandler(this.LabelSet_Torihikisaki_EnabledChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
