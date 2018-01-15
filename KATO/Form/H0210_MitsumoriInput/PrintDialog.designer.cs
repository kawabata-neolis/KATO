namespace KATO.Form.H0210_MitsumoriInput
{
    partial class PrintDialog
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
            this.btnPrintS = new System.Windows.Forms.Button();
            this.btnPrintD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrintS
            // 
            this.btnPrintS.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrintS.Location = new System.Drawing.Point(170, 39);
            this.btnPrintS.Name = "btnPrintS";
            this.btnPrintS.Size = new System.Drawing.Size(91, 45);
            this.btnPrintS.TabIndex = 304;
            this.btnPrintS.Text = "見積書\r\n印刷";
            this.btnPrintS.UseVisualStyleBackColor = true;
            this.btnPrintS.Click += new System.EventHandler(this.btnPrintS_Click);
            // 
            // btnPrintD
            // 
            this.btnPrintD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrintD.Location = new System.Drawing.Point(12, 39);
            this.btnPrintD.Name = "btnPrintD";
            this.btnPrintD.Size = new System.Drawing.Size(152, 45);
            this.btnPrintD.TabIndex = 303;
            this.btnPrintD.Text = "見積書＋仕入詳細\r\n印刷";
            this.btnPrintD.UseVisualStyleBackColor = true;
            this.btnPrintD.Click += new System.EventHandler(this.btnPrintD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(104, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 15);
            this.label1.TabIndex = 305;
            this.label1.Text = "登録が完了しました。";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(267, 39);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 45);
            this.btnClose.TabIndex = 306;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // PrintDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 101);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrintS);
            this.Controls.Add(this.btnPrintD);
            this.Name = "PrintDialog";
            this.Text = "印刷";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintS;
        private System.Windows.Forms.Button btnPrintD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}