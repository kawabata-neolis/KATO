namespace textbox_0220_02
{
    partial class Calendar
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
            // Calendar
            // 
            this.Format = CustomControls.CustomCommon.enuDateFormat.YYYYsMMsDD;
            this.Enter += new System.EventHandler(this.updCalendarEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.setCalendarKeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.setCalendarKeyPress);
            this.Leave += new System.EventHandler(this.updCalendarLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
