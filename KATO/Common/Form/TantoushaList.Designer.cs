using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    partial class TantoushaList
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
            this.lblRecords = new System.Windows.Forms.Label();
            this.gridTantousha = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridTantousha)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(29, 549);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 20;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // gridTantousha
            // 
            this.gridTantousha.AllowUserToAddRows = false;
            this.gridTantousha.AllowUserToResizeColumns = false;
            this.gridTantousha.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTantousha.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTantousha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTantousha.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridTantousha.EnableHeadersVisualStyles = false;
            this.gridTantousha.Location = new System.Drawing.Point(12, 84);
            this.gridTantousha.Name = "gridTantousha";
            this.gridTantousha.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTantousha.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTantousha.RowHeadersVisible = false;
            this.gridTantousha.RowTemplate.Height = 21;
            this.gridTantousha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTantousha.Size = new System.Drawing.Size(776, 451);
            this.gridTantousha.StandardTab = true;
            this.gridTantousha.TabIndex = 0;
            this.gridTantousha.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTantousha_CellDoubleClick);
            this.gridTantousha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridTantouKeyDown);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(663, 12);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 1;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            this.btnF12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTantouListKeyDown);
            // 
            // TantoushaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 587);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.gridTantousha);
            this.Controls.Add(this.btnF12);
            this.Name = "TantoushaList";
            this.Text = "tantousyaList";
            this.Load += new System.EventHandler(this.TantousyaList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTantouListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridTantousha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BaseButton btnF12;
        private BaseDataGridView gridTantousha;
        private System.Windows.Forms.Label lblRecords;
    }
}