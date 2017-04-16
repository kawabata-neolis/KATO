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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.大分類コードDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.大分類名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.dgvSeihin = new KATO.Common.Ctl.BaseDataGridView();
            this.lblRecords = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeihin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(30, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 82);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出力順";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.radioButton2.Location = new System.Drawing.Point(33, 47);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(137, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "大分類名の昇順";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.radioButton1.Location = new System.Drawing.Point(33, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(169, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "大分類コードの昇順";
            this.radioButton1.UseVisualStyleBackColor = true;
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
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(405, 41);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 1;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnKensakuClick);
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
            // dgvSeihin
            // 
            this.dgvSeihin.AllowUserToAddRows = false;
            this.dgvSeihin.AllowUserToResizeColumns = false;
            this.dgvSeihin.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSeihin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSeihin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeihin.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSeihin.EnableHeadersVisualStyles = false;
            this.dgvSeihin.Location = new System.Drawing.Point(31, 115);
            this.dgvSeihin.Name = "dgvSeihin";
            this.dgvSeihin.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSeihin.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSeihin.RowHeadersVisible = false;
            this.dgvSeihin.RowTemplate.Height = 21;
            this.dgvSeihin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeihin.Size = new System.Drawing.Size(474, 349);
            this.dgvSeihin.StandardTab = true;
            this.dgvSeihin.TabIndex = 0;
            this.dgvSeihin.DoubleClick += new System.EventHandler(this.setdgvSeihinDoubleClick);
            this.dgvSeihin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDgvSeihinKeyDown);
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
            // DaibunruiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 524);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.dgvSeihin);
            this.Controls.Add(this.groupBox1);
            this.Name = "DaibunruiList";
            this.Text = "DaiBunruiList";
            this.Load += new System.EventHandler(this.DaiBunruiList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunruiListKeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeihin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 大分類コードDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 大分類名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn label6DataGridViewTextBoxColumn;
        private BaseDataGridView dgvSeihin;
        private BaseButton btnF12;
        private BaseButton btnF11;
        private System.Windows.Forms.Label lblRecords;
    }
}