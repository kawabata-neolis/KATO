﻿namespace KATO.Common.Ctl
{
    partial class BaseComboBox
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
            // BaseComboBox
            // 
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Size = new System.Drawing.Size(121, 20);
            this.SelectionChangeCommitted += new System.EventHandler(this.BaseComboBox_SelectionChangeCommitted);
            this.Enter += new System.EventHandler(this.BaseText_Enter);
            this.Leave += new System.EventHandler(this.BaseText_Leave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
