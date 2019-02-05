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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShireJisseki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridShireJisseki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridShireJisseki.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridShireJisseki.EnableHeadersVisualStyles = false;
            this.gridShireJisseki.Location = new System.Drawing.Point(55, 57);
            this.gridShireJisseki.Name = "gridShireJisseki";
            this.gridShireJisseki.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShireJisseki.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridShireJisseki.RowHeadersVisible = false;
            this.gridShireJisseki.RowTemplate.Height = 21;
            this.gridShireJisseki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShireJisseki.Size = new System.Drawing.Size(662, 705);
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