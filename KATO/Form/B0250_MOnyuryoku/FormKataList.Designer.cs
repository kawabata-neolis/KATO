namespace KATO.Form.B0250_MOnyuryoku
{
    partial class FormKataList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseDataGridView1 = new KATO.Common.Ctl.BaseDataGridView();
            this.ButtonCancel = new KATO.Common.Ctl.BaseButton();
            this.ButtonOk = new KATO.Common.Ctl.BaseButton();
            this.型番 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.列番 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(11, 9);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(103, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 3;
            this.baseLabel1.Text = "型番を選択：";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseDataGridView1
            // 
            this.baseDataGridView1.AllowUserToAddRows = false;
            this.baseDataGridView1.AllowUserToDeleteRows = false;
            this.baseDataGridView1.AllowUserToResizeColumns = false;
            this.baseDataGridView1.AllowUserToResizeRows = false;
            this.baseDataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.baseDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.baseDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.baseDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.型番,
            this.列番});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.baseDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.baseDataGridView1.EnableHeadersVisualStyles = false;
            this.baseDataGridView1.Location = new System.Drawing.Point(12, 28);
            this.baseDataGridView1.Name = "baseDataGridView1";
            this.baseDataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.baseDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.baseDataGridView1.RowHeadersVisible = false;
            this.baseDataGridView1.RowTemplate.Height = 21;
            this.baseDataGridView1.RowTemplate.ReadOnly = true;
            this.baseDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.baseDataGridView1.Size = new System.Drawing.Size(471, 484);
            this.baseDataGridView1.StandardTab = true;
            this.baseDataGridView1.TabIndex = 2;
            this.baseDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.baseDataGridView1_CellDoubleClick);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.ButtonCancel.Location = new System.Drawing.Point(384, 526);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(100, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "キャンセル";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.ButtonOk.Location = new System.Drawing.Point(278, 526);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(100, 23);
            this.ButtonOk.TabIndex = 0;
            this.ButtonOk.Text = "選択";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // 型番
            // 
            this.型番.HeaderText = "型番";
            this.型番.Name = "型番";
            this.型番.ReadOnly = true;
            this.型番.Width = 448;
            // 
            // 列番
            // 
            this.列番.HeaderText = "列番";
            this.列番.Name = "列番";
            this.列番.ReadOnly = true;
            this.列番.Visible = false;
            // 
            // FormKataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 561);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.baseDataGridView1);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Name = "FormKataList";
            this.Text = "FormKataList";
            ((System.ComponentModel.ISupportInitialize)(this.baseDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Common.Ctl.BaseButton ButtonOk;
        public Common.Ctl.BaseButton ButtonCancel;
        public Common.Ctl.BaseDataGridView baseDataGridView1;
        public Common.Ctl.BaseLabel baseLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 型番;
        private System.Windows.Forms.DataGridViewTextBoxColumn 列番;
    }
}