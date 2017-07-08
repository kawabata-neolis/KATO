namespace KATO.Common.Form
{
    partial class KakouGenkaList
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
            this.bgJuchu = new System.Windows.Forms.GroupBox();
            this.gridJuchu = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.bgJuchu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridJuchu)).BeginInit();
            this.SuspendLayout();
            // 
            // bgJuchu
            // 
            this.bgJuchu.Controls.Add(this.gridJuchu);
            this.bgJuchu.Location = new System.Drawing.Point(13, 49);
            this.bgJuchu.Name = "bgJuchu";
            this.bgJuchu.Size = new System.Drawing.Size(1399, 765);
            this.bgJuchu.TabIndex = 0;
            this.bgJuchu.TabStop = false;
            // 
            // gridJuchu
            // 
            this.gridJuchu.AllowUserToAddRows = false;
            this.gridJuchu.AllowUserToResizeColumns = false;
            this.gridJuchu.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridJuchu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridJuchu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridJuchu.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridJuchu.EnableHeadersVisualStyles = false;
            this.gridJuchu.Location = new System.Drawing.Point(16, 23);
            this.gridJuchu.Name = "gridJuchu";
            this.gridJuchu.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridJuchu.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridJuchu.RowHeadersVisible = false;
            this.gridJuchu.RowTemplate.Height = 21;
            this.gridJuchu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridJuchu.Size = new System.Drawing.Size(1369, 726);
            this.gridJuchu.StandardTab = true;
            this.gridJuchu.TabIndex = 0;
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(1298, 20);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 2;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // KakouGenkaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.bgJuchu);
            this.Name = "KakouGenkaList";
            this.Text = "KakouGenkaList";
            this.Load += new System.EventHandler(this.KakouGenkaList_Load);
            this.Shown += new System.EventHandler(this.KakouGenkaList_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KakouGenkaList_KeyDown);
            this.bgJuchu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridJuchu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox bgJuchu;
        private Ctl.BaseButton btnF12;
        private Ctl.BaseDataGridView gridJuchu;
    }
}