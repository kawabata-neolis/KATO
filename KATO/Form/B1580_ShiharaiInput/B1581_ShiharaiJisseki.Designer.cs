namespace KATO.Form.B1580_ShiharaiInput
{
    partial class B1581_ShiharaiJisseki
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridShireJisseki = new KATO.Common.Ctl.BaseDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridShireJisseki)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF12
            // 
            this.btnF12.Text = "F12:終了";
            this.btnF12.Click += new System.EventHandler(this.btnF12_Click);
            // 
            // gridShireJisseki
            // 
            this.gridShireJisseki.AllowUserToAddRows = false;
            this.gridShireJisseki.AllowUserToResizeColumns = false;
            this.gridShireJisseki.AllowUserToResizeRows = false;
            this.gridShireJisseki.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShireJisseki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridShireJisseki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridShireJisseki.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridShireJisseki.EnableHeadersVisualStyles = false;
            this.gridShireJisseki.Location = new System.Drawing.Point(55, 57);
            this.gridShireJisseki.Name = "gridShireJisseki";
            this.gridShireJisseki.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShireJisseki.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridShireJisseki.RowHeadersVisible = false;
            this.gridShireJisseki.RowTemplate.Height = 21;
            this.gridShireJisseki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShireJisseki.Size = new System.Drawing.Size(924, 382);
            this.gridShireJisseki.StandardTab = true;
            this.gridShireJisseki.TabIndex = 124;
            this.gridShireJisseki.TabStop = false;
            // 
            // B1581_ShiharaiJisseki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 826);
            this.Controls.Add(this.gridShireJisseki);
            this.Name = "B1581_ShiharaiJisseki";
            this.Text = "支払実績";
            this.Load += new System.EventHandler(this.B1581_ShiharaiJisseki_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.B1581_ShiharaiJisseki_KeyDown);
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
            this.Controls.SetChildIndex(this.cmbSubWinShow, 0);
            this.Controls.SetChildIndex(this.gridShireJisseki, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridShireJisseki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Common.Ctl.BaseDataGridView gridShireJisseki;
    }
}