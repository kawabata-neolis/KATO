namespace KATO.Form.M1490_Menukengen2
{
    partial class M1490_Menukengen2
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
            this.txtMenukengen2 = new KATO.Common.Ctl.BaseText();
            this.lblMenuName = new KATO.Common.Ctl.BaseLabelGray();
            this.lblPgno = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gridKengen = new KATO.Common.Ctl.BaseDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridKengen)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMenukengen2
            // 
            this.txtMenukengen2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtMenukengen2.Location = new System.Drawing.Point(168, 63);
            this.txtMenukengen2.MaxLength = 3;
            this.txtMenukengen2.Name = "txtMenukengen2";
            this.txtMenukengen2.Size = new System.Drawing.Size(100, 22);
            this.txtMenukengen2.TabIndex = 87;
            this.txtMenukengen2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMenukengen2_KeyDown);
            // 
            // lblMenuName
            // 
            this.lblMenuName.AutoEllipsis = true;
            this.lblMenuName.BackColor = System.Drawing.Color.Gainsboro;
            this.lblMenuName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblMenuName.ForeColor = System.Drawing.Color.Blue;
            this.lblMenuName.Location = new System.Drawing.Point(274, 63);
            this.lblMenuName.Name = "lblMenuName";
            this.lblMenuName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMenuName.Size = new System.Drawing.Size(202, 22);
            this.lblMenuName.TabIndex = 99;
            this.lblMenuName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPgno
            // 
            this.lblPgno.AutoSize = true;
            this.lblPgno.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblPgno.Location = new System.Drawing.Point(82, 66);
            this.lblPgno.Name = "lblPgno";
            this.lblPgno.Size = new System.Drawing.Size(47, 15);
            this.lblPgno.strToolTip = null;
            this.lblPgno.TabIndex = 100;
            this.lblPgno.Text = "PGNo.";
            this.lblPgno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridKengen
            // 
            this.gridKengen.AllowUserToAddRows = false;
            this.gridKengen.AllowUserToResizeColumns = false;
            this.gridKengen.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridKengen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridKengen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridKengen.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridKengen.EnableHeadersVisualStyles = false;
            this.gridKengen.Location = new System.Drawing.Point(168, 120);
            this.gridKengen.Name = "gridKengen";
            this.gridKengen.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridKengen.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridKengen.RowHeadersVisible = false;
            this.gridKengen.RowTemplate.Height = 21;
            this.gridKengen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridKengen.Size = new System.Drawing.Size(498, 630);
            this.gridKengen.StandardTab = true;
            this.gridKengen.TabIndex = 101;
            this.gridKengen.DoubleClick += new System.EventHandler(this.gridKengen_DblClick);
            this.gridKengen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridKengen_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 12);
            this.label1.TabIndex = 102;
            this.label1.Text = "※権限　Ｙ：使用可　Ｎ：使用不可";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 12);
            this.label2.TabIndex = 103;
            this.label2.Text = "※権限の切り替えは、";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 12);
            this.label3.TabIndex = 104;
            this.label3.Text = "　 変更したい行でダブルクリックします。";
            // 
            // M1490_Menukengen2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridKengen);
            this.Controls.Add(this.lblPgno);
            this.Controls.Add(this.lblMenuName);
            this.Controls.Add(this.txtMenukengen2);
            this.Name = "M1490_Menukengen2";
            this.Text = "M1490_Menukengen2";
            this.Load += new System.EventHandler(this.M1490_Menukengen2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1490_Menukengen2_KeyDown);
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
            this.Controls.SetChildIndex(this.txtMenukengen2, 0);
            this.Controls.SetChildIndex(this.lblMenuName, 0);
            this.Controls.SetChildIndex(this.lblPgno, 0);
            this.Controls.SetChildIndex(this.gridKengen, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridKengen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseText txtMenukengen2;
        private Common.Ctl.BaseLabelGray lblMenuName;
        private Common.Ctl.BaseLabel lblPgno;
        private Common.Ctl.BaseDataGridView gridKengen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}