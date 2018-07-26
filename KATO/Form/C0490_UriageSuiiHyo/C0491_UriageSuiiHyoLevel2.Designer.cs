namespace KATO.Form.C0491_UriageSuiiHyo
{
    partial class C0491_UriageSuiiHyoLevel2
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
            this.gridUriageSuii = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridUriageSuii)).BeginInit();
            this.SuspendLayout();
            // 
            // gridUriageSuii
            // 
            this.gridUriageSuii.AllowUserToAddRows = false;
            this.gridUriageSuii.AllowUserToDeleteRows = false;
            this.gridUriageSuii.AllowUserToResizeColumns = false;
            this.gridUriageSuii.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUriageSuii.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridUriageSuii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridUriageSuii.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridUriageSuii.EnableHeadersVisualStyles = false;
            this.gridUriageSuii.Location = new System.Drawing.Point(12, 105);
            this.gridUriageSuii.MultiSelect = false;
            this.gridUriageSuii.Name = "gridUriageSuii";
            this.gridUriageSuii.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUriageSuii.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridUriageSuii.RowHeadersVisible = false;
            this.gridUriageSuii.RowTemplate.Height = 21;
            this.gridUriageSuii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUriageSuii.Size = new System.Drawing.Size(1395, 672);
            this.gridUriageSuii.StandardTab = true;
            this.gridUriageSuii.TabIndex = 130;
            this.gridUriageSuii.TabStop = false;
            this.gridUriageSuii.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridUriageSuii_CellMouseDoubleClick);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(1107, 49);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(117, 30);
            this.btnF12.TabIndex = 131;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.backFormButton_Click);
            // 
            // C0491_UriageSuiiHyoLevel2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 826);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.gridUriageSuii);
            this.Name = "C0491_UriageSuiiHyoLevel2";
            this.Text = "C0490_UriageSuiiHyoLevel2";
            this.Load += new System.EventHandler(this.C0490_UriageSuiiHyoLevel2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.C0491_UriageSuiiHyo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridUriageSuii)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Ctl.BaseDataGridView gridUriageSuii;
        private Common.Ctl.BaseButton btnF12;
    }
}