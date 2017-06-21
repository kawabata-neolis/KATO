namespace KATO.Form.C0481_SiireSuiiHyo
{
    partial class C0481_SiireSuiiHyoLevel2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridSiireSuii = new KATO.Common.Ctl.BaseDataGridView();
            this.backFormButton = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridSiireSuii)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF12
            // 
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // gridSiireSuii
            // 
            this.gridSiireSuii.AllowUserToAddRows = false;
            this.gridSiireSuii.AllowUserToDeleteRows = false;
            this.gridSiireSuii.AllowUserToResizeColumns = false;
            this.gridSiireSuii.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSiireSuii.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSiireSuii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSiireSuii.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridSiireSuii.EnableHeadersVisualStyles = false;
            this.gridSiireSuii.Location = new System.Drawing.Point(12, 105);
            this.gridSiireSuii.MultiSelect = false;
            this.gridSiireSuii.Name = "gridSiireSuii";
            this.gridSiireSuii.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSiireSuii.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSiireSuii.RowHeadersVisible = false;
            this.gridSiireSuii.RowTemplate.Height = 21;
            this.gridSiireSuii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSiireSuii.Size = new System.Drawing.Size(1323, 672);
            this.gridSiireSuii.StandardTab = true;
            this.gridSiireSuii.TabIndex = 130;
            this.gridSiireSuii.TabStop = false;
            this.gridSiireSuii.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridSiireSuii_CellMouseDoubleClick);
            // 
            // backFormButton
            // 
            this.backFormButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.backFormButton.Location = new System.Drawing.Point(1107, 49);
            this.backFormButton.Name = "backFormButton";
            this.backFormButton.Size = new System.Drawing.Size(117, 30);
            this.backFormButton.TabIndex = 131;
            this.backFormButton.Text = "戻る(F12)";
            this.backFormButton.UseVisualStyleBackColor = true;
            this.backFormButton.Click += new System.EventHandler(this.backFormButton_Click);
            // 
            // C0481_SiireSuiiHyoLevel2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.backFormButton);
            this.Controls.Add(this.gridSiireSuii);
            this.Name = "C0481_SiireSuiiHyoLevel2";
            this.Text = "C0481_SiireSuiiHyoLevel2";
            this.Load += new System.EventHandler(this.C0480_SiireSuiiHyoLevel2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.C0481_SiireSuiiHyo_KeyDown);
            this.Controls.SetChildIndex(this.btnF01, 0);
            this.Controls.SetChildIndex(this.btnF02, 0);
            this.Controls.SetChildIndex(this.btnF03, 0);
            this.Controls.SetChildIndex(this.btnF04, 0);
            this.Controls.SetChildIndex(this.btnF05, 0);
            this.Controls.SetChildIndex(this.btnF06, 0);
            this.Controls.SetChildIndex(this.btnF07, 0);
            this.Controls.SetChildIndex(this.btnF08, 0);
            this.Controls.SetChildIndex(this.btnF09, 0);
            this.Controls.SetChildIndex(this.btnF10, 0);
            this.Controls.SetChildIndex(this.btnF11, 0);
            this.Controls.SetChildIndex(this.btnF12, 0);
            this.Controls.SetChildIndex(this.gridSiireSuii, 0);
            this.Controls.SetChildIndex(this.backFormButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridSiireSuii)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseDataGridView gridSiireSuii;
        private Common.Ctl.BaseButton backFormButton;
    }
}