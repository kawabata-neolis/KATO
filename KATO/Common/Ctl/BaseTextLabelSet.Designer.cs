namespace KATO.Common.Ctl
{
    partial class BaseTextLabelSet
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
            this.appendLabel = new KATO.Common.Ctl.BaseLabelGray();
            this.valueLabel = new KATO.Common.Ctl.BaseLabelGray();
            this.codeTxt = new KATO.Common.Ctl.BaseText();
            this.nameLabel = new KATO.Common.Ctl.BaseLabel(this.components);
            this.SuspendLayout();
            // 
            // appendLabel
            // 
            this.appendLabel.AutoEllipsis = true;
            this.appendLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.appendLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.appendLabel.ForeColor = System.Drawing.Color.Blue;
            this.appendLabel.Location = new System.Drawing.Point(338, 0);
            this.appendLabel.Name = "appendLabel";
            this.appendLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.appendLabel.Size = new System.Drawing.Size(116, 22);
            this.appendLabel.TabIndex = 100;
            this.appendLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // valueLabel
            // 
            this.valueLabel.AutoEllipsis = true;
            this.valueLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.valueLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.valueLabel.ForeColor = System.Drawing.Color.Blue;
            this.valueLabel.Location = new System.Drawing.Point(150, 0);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.valueLabel.Size = new System.Drawing.Size(182, 22);
            this.valueLabel.TabIndex = 99;
            this.valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // codeTxt
            // 
            this.codeTxt.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.codeTxt.Location = new System.Drawing.Point(111, 0);
            this.codeTxt.Name = "codeTxt";
            this.codeTxt.Size = new System.Drawing.Size(33, 22);
            this.codeTxt.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.nameLabel.Location = new System.Drawing.Point(2, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BaseTextLabelSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.appendLabel);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.codeTxt);
            this.Controls.Add(this.nameLabel);
            this.Name = "BaseTextLabelSet";
            this.Size = new System.Drawing.Size(453, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseLabel nameLabel;
        private BaseLabelGray valueLabel;
        public BaseText codeTxt;
        private BaseLabelGray appendLabel;
    }
}
