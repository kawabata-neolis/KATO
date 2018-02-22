namespace KATO.Common.Form
{
    partial class ShiresakiList
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
            this.lblName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTorihikisaki = new KATO.Common.Ctl.BaseText();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.gridShiresaki = new KATO.Common.Ctl.BaseDataGridView();
            this.lblRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridShiresaki)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblName.Location = new System.Drawing.Point(24, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 15);
            this.lblName.strToolTip = null;
            this.lblName.TabIndex = 92;
            this.lblName.Text = "仕入先名";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTorihikisaki
            // 
            this.txtTorihikisaki.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTorihikisaki.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTorihikisaki.Location = new System.Drawing.Point(123, 30);
            this.txtTorihikisaki.MaxLength = 30;
            this.txtTorihikisaki.Name = "txtTorihikisaki";
            this.txtTorihikisaki.Size = new System.Drawing.Size(296, 22);
            this.txtTorihikisaki.TabIndex = 89;
            this.txtTorihikisaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judSireListTxtKeyDown);
            this.txtTorihikisaki.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtShiresaki_KeyUp);
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(663, 38);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 90;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnKensakuClick);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(663, 12);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 91;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // gridShiresaki
            // 
            this.gridShiresaki.AllowUserToAddRows = false;
            this.gridShiresaki.AllowUserToResizeColumns = false;
            this.gridShiresaki.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShiresaki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridShiresaki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridShiresaki.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridShiresaki.EnableHeadersVisualStyles = false;
            this.gridShiresaki.Location = new System.Drawing.Point(12, 84);
            this.gridShiresaki.Name = "gridShiresaki";
            this.gridShiresaki.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShiresaki.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridShiresaki.RowHeadersVisible = false;
            this.gridShiresaki.RowTemplate.Height = 21;
            this.gridShiresaki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShiresaki.Size = new System.Drawing.Size(776, 451);
            this.gridShiresaki.StandardTab = true;
            this.gridShiresaki.TabIndex = 95;
            this.gridShiresaki.DoubleClick += new System.EventHandler(this.setShireGridDblClick);
            this.gridShiresaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridSireKeyDown);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(29, 549);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 96;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // ShiresakiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 587);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.gridShiresaki);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtTorihikisaki);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Name = "ShiresakiList";
            this.Text = "ShiresakiList";
            this.Load += new System.EventHandler(this.ShiresakiList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judSireListKeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gridShiresaki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctl.BaseLabel lblName;
        private Ctl.BaseText txtTorihikisaki;
        private Ctl.BaseButton btnF11;
        private Ctl.BaseButton btnF12;
        private Ctl.BaseDataGridView gridShiresaki;
        private System.Windows.Forms.Label lblRecords;
    }
}