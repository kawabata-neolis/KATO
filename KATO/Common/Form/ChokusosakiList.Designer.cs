using KATO.Common;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    partial class ChokusosakiList
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
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblTokuisakiCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTokuisakiCd = new KATO.Common.Ctl.BaseText();
            this.gridChoku = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridChoku)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(29, 477);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 19;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // lblTokuisakiCd
            // 
            this.lblTokuisakiCd.AutoSize = true;
            this.lblTokuisakiCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTokuisakiCd.Location = new System.Drawing.Point(39, 27);
            this.lblTokuisakiCd.Name = "lblTokuisakiCd";
            this.lblTokuisakiCd.Size = new System.Drawing.Size(103, 15);
            this.lblTokuisakiCd.strToolTip = null;
            this.lblTokuisakiCd.TabIndex = 21;
            this.lblTokuisakiCd.Text = "得意先コード";
            this.lblTokuisakiCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTokuisakiCd
            // 
            this.txtTokuisakiCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTokuisakiCd.Location = new System.Drawing.Point(150, 24);
            this.txtTokuisakiCd.MaxLength = 4;
            this.txtTokuisakiCd.Name = "txtTokuisakiCd";
            this.txtTokuisakiCd.Size = new System.Drawing.Size(40, 22);
            this.txtTokuisakiCd.TabIndex = 2;
            this.txtTokuisakiCd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChokusosakiList_KeyUp);
            // 
            // gridChoku
            // 
            this.gridChoku.AllowUserToAddRows = false;
            this.gridChoku.AllowUserToResizeColumns = false;
            this.gridChoku.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChoku.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridChoku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridChoku.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridChoku.EnableHeadersVisualStyles = false;
            this.gridChoku.Location = new System.Drawing.Point(31, 83);
            this.gridChoku.Name = "gridChoku";
            this.gridChoku.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChoku.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridChoku.RowHeadersVisible = false;
            this.gridChoku.RowTemplate.Height = 21;
            this.gridChoku.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridChoku.Size = new System.Drawing.Size(474, 381);
            this.gridChoku.StandardTab = true;
            this.gridChoku.TabIndex = 0;
            this.gridChoku.DoubleClick += new System.EventHandler(this.gridChoku_DoubleClick);
            this.gridChoku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridSeihinKeyDown);
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(405, 41);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 3;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnKensakuClick);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(405, 12);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 1;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // ChokusosakiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 524);
            this.Controls.Add(this.lblTokuisakiCd);
            this.Controls.Add(this.txtTokuisakiCd);
            this.Controls.Add(this.gridChoku);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Name = "ChokusosakiList";
            this.Text = "ChokusosakiList";
            this.Load += new System.EventHandler(this.ChokusosakiList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunruiListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridChoku)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseButton btnF11;
        private BaseButton btnF12;
        private System.Windows.Forms.Label lblRecords;
        private BaseDataGridView gridChoku;
        private BaseText txtTokuisakiCd;
        private BaseLabel lblTokuisakiCd;
    }
}