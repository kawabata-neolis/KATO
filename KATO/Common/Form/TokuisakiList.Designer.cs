namespace KATO.Common.Form
{
    partial class TokuisakiList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridShiresaki = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.lblName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTokuisaki = new KATO.Common.Ctl.BaseText();
            this.lblRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridShiresaki)).BeginInit();
            this.SuspendLayout();
            // 
            // gridShiresaki
            // 
            this.gridShiresaki.AllowUserToAddRows = false;
            this.gridShiresaki.AllowUserToResizeColumns = false;
            this.gridShiresaki.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShiresaki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridShiresaki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridShiresaki.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridShiresaki.EnableHeadersVisualStyles = false;
            this.gridShiresaki.Location = new System.Drawing.Point(12, 84);
            this.gridShiresaki.Name = "gridShiresaki";
            this.gridShiresaki.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShiresaki.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridShiresaki.RowHeadersVisible = false;
            this.gridShiresaki.RowTemplate.Height = 21;
            this.gridShiresaki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShiresaki.Size = new System.Drawing.Size(776, 451);
            this.gridShiresaki.StandardTab = true;
            this.gridShiresaki.TabIndex = 96;
            this.gridShiresaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridTokuiKeyDown);
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(663, 38);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 97;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnKensakuClick);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(663, 12);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 98;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblName.Location = new System.Drawing.Point(24, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 15);
            this.lblName.strToolTip = null;
            this.lblName.TabIndex = 101;
            this.lblName.Text = "得意先名";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTokuisaki
            // 
            this.txtTokuisaki.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTokuisaki.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTokuisaki.Location = new System.Drawing.Point(124, 30);
            this.txtTokuisaki.MaxLength = 30;
            this.txtTokuisaki.Name = "txtTokuisaki";
            this.txtTokuisaki.Size = new System.Drawing.Size(296, 22);
            this.txtTokuisaki.TabIndex = 100;
            this.txtTokuisaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiTxtKeyDown);
            this.txtTokuisaki.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTokuisaki_KeyUp);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(29, 549);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 103;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // TokuisakiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 587);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtTokuisaki);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.gridShiresaki);
            this.Name = "TokuisakiList";
            this.Text = "TokuisakiList";
            this.Load += new System.EventHandler(this.TokuisakiList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridShiresaki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctl.BaseDataGridView gridShiresaki;
        private Ctl.BaseButton btnF11;
        private Ctl.BaseButton btnF12;
        private Ctl.BaseLabel lblName;
        private Ctl.BaseText txtTokuisaki;
        private System.Windows.Forms.Label lblRecords;
    }
}