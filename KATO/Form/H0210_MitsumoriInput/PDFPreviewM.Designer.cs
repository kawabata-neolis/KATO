namespace KATO.Form.H0210_MitsumoriInput
{
    partial class PDFPreviewM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFPreviewM));
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.baseButton1 = new KATO.Common.Ctl.BaseButton();
            this.baseButton2 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(1049, 826);
            this.axAcroPDF1.TabIndex = 0;
            this.axAcroPDF1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.axAcroPDF1_PreviewKeyDown);
            // 
            // baseButton1
            // 
            this.baseButton1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseButton1.Location = new System.Drawing.Point(1055, 12);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.Size = new System.Drawing.Size(100, 23);
            this.baseButton1.TabIndex = 1;
            this.baseButton1.Text = "印刷(F11)";
            this.baseButton1.UseVisualStyleBackColor = true;
            // 
            // baseButton2
            // 
            this.baseButton2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.baseButton2.Location = new System.Drawing.Point(1055, 41);
            this.baseButton2.Name = "baseButton2";
            this.baseButton2.Size = new System.Drawing.Size(100, 23);
            this.baseButton2.TabIndex = 2;
            this.baseButton2.Text = "閉じる(F12)";
            this.baseButton2.UseVisualStyleBackColor = true;
            // 
            // PDFPreviewM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1162, 826);
            this.Controls.Add(this.baseButton2);
            this.Controls.Add(this.baseButton1);
            this.Controls.Add(this.axAcroPDF1);
            this.KeyPreview = true;
            this.Name = "PDFPreviewM";
            this.Text = "プレビュー";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PDFPreview_KeyDown);
            this.Resize += new System.EventHandler(this.PDFPreview_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private Common.Ctl.BaseButton baseButton1;
        private Common.Ctl.BaseButton baseButton2;
    }
}