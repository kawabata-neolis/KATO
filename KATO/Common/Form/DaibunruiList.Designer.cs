using KATO.Common;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    partial class DaibunruiList
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
            this.大分類コードDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.大分類名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRecords = new System.Windows.Forms.Label();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.gridSeihin = new KATO.Common.Ctl.BaseDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeihin)).BeginInit();
            this.SuspendLayout();
            // 
            // 大分類コードDataGridViewTextBoxColumn
            // 
            this.大分類コードDataGridViewTextBoxColumn.DataPropertyName = "大分類コード";
            this.大分類コードDataGridViewTextBoxColumn.HeaderText = "大分類コード";
            this.大分類コードDataGridViewTextBoxColumn.Name = "大分類コードDataGridViewTextBoxColumn";
            this.大分類コードDataGridViewTextBoxColumn.ReadOnly = true;
            this.大分類コードDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 大分類名DataGridViewTextBoxColumn
            // 
            this.大分類名DataGridViewTextBoxColumn.DataPropertyName = "大分類名";
            this.大分類名DataGridViewTextBoxColumn.HeaderText = "大分類名";
            this.大分類名DataGridViewTextBoxColumn.Name = "大分類名DataGridViewTextBoxColumn";
            this.大分類名DataGridViewTextBoxColumn.ReadOnly = true;
            this.大分類名DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1DataGridViewTextBoxColumn
            // 
            this.label1DataGridViewTextBoxColumn.DataPropertyName = "label1";
            this.label1DataGridViewTextBoxColumn.HeaderText = "label1";
            this.label1DataGridViewTextBoxColumn.Name = "label1DataGridViewTextBoxColumn";
            this.label1DataGridViewTextBoxColumn.ReadOnly = true;
            this.label1DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label2DataGridViewTextBoxColumn
            // 
            this.label2DataGridViewTextBoxColumn.DataPropertyName = "label2";
            this.label2DataGridViewTextBoxColumn.HeaderText = "label2";
            this.label2DataGridViewTextBoxColumn.Name = "label2DataGridViewTextBoxColumn";
            this.label2DataGridViewTextBoxColumn.ReadOnly = true;
            this.label2DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label3DataGridViewTextBoxColumn
            // 
            this.label3DataGridViewTextBoxColumn.DataPropertyName = "label3";
            this.label3DataGridViewTextBoxColumn.HeaderText = "label3";
            this.label3DataGridViewTextBoxColumn.Name = "label3DataGridViewTextBoxColumn";
            this.label3DataGridViewTextBoxColumn.ReadOnly = true;
            this.label3DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label4DataGridViewTextBoxColumn
            // 
            this.label4DataGridViewTextBoxColumn.DataPropertyName = "label4";
            this.label4DataGridViewTextBoxColumn.HeaderText = "label4";
            this.label4DataGridViewTextBoxColumn.Name = "label4DataGridViewTextBoxColumn";
            this.label4DataGridViewTextBoxColumn.ReadOnly = true;
            this.label4DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label5DataGridViewTextBoxColumn
            // 
            this.label5DataGridViewTextBoxColumn.DataPropertyName = "label5";
            this.label5DataGridViewTextBoxColumn.HeaderText = "label5";
            this.label5DataGridViewTextBoxColumn.Name = "label5DataGridViewTextBoxColumn";
            this.label5DataGridViewTextBoxColumn.ReadOnly = true;
            this.label5DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label6DataGridViewTextBoxColumn
            // 
            this.label6DataGridViewTextBoxColumn.DataPropertyName = "label6";
            this.label6DataGridViewTextBoxColumn.HeaderText = "label6";
            this.label6DataGridViewTextBoxColumn.Name = "label6DataGridViewTextBoxColumn";
            this.label6DataGridViewTextBoxColumn.ReadOnly = true;
            this.label6DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(29, 477);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 20;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(405, 12);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 2;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // gridSeihin
            // 
            this.gridSeihin.AllowUserToAddRows = false;
            this.gridSeihin.AllowUserToResizeColumns = false;
            this.gridSeihin.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSeihin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSeihin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSeihin.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridSeihin.EnableHeadersVisualStyles = false;
            this.gridSeihin.Location = new System.Drawing.Point(31, 54);
            this.gridSeihin.Name = "gridSeihin";
            this.gridSeihin.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSeihin.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSeihin.RowHeadersVisible = false;
            this.gridSeihin.RowTemplate.Height = 21;
            this.gridSeihin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSeihin.Size = new System.Drawing.Size(474, 410);
            this.gridSeihin.StandardTab = true;
            this.gridSeihin.TabIndex = 0;
            this.gridSeihin.DoubleClick += new System.EventHandler(this.GridSeiDblClick);
            this.gridSeihin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridSeihinKeyDown);
            // 
            // DaibunruiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 524);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.gridSeihin);
            this.Name = "DaibunruiList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DaiBunruiList";
            this.Load += new System.EventHandler(this.DaiBunruiList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunruiListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridSeihin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn 大分類コードDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 大分類名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label6DataGridViewTextBoxColumn;
        private BaseDataGridView gridSeihin;
        private BaseButton btnF12;
        private System.Windows.Forms.Label lblRecords;
    }
}