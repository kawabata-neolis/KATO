using KATO.Common;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    partial class ChubunruiList
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
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblText = new KATO.Common.Ctl.BaseLabelGray();
            this.txtDaibunrui = new KATO.Common.Ctl.BaseText();
            this.dgvSeihin = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeihin)).BeginInit();
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
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(38, 35);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(103, 15);
            this.baseLabel1.TabIndex = 100;
            this.baseLabel1.Text = "大分類コード";
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.Gainsboro;
            this.lblText.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblText.ForeColor = System.Drawing.Color.Blue;
            this.lblText.Location = new System.Drawing.Point(172, 31);
            this.lblText.Name = "lblText";
            this.lblText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblText.Size = new System.Drawing.Size(202, 23);
            this.lblText.TabIndex = 99;
            this.lblText.Text = " ";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDaibunrui
            // 
            this.txtDaibunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDaibunrui.Location = new System.Drawing.Point(144, 32);
            this.txtDaibunrui.MaxLength = 2;
            this.txtDaibunrui.Name = "txtDaibunrui";
            this.txtDaibunrui.Size = new System.Drawing.Size(22, 22);
            this.txtDaibunrui.TabIndex = 88;
            this.txtDaibunrui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDaibunrui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judDaibunruiKeyUp);
            this.txtDaibunrui.Leave += new System.EventHandler(this.judDaibunruiLeave);
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
            this.dgvSeihin.Location = new System.Drawing.Point(31, 83);
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
            this.dgvSeihin.Size = new System.Drawing.Size(474, 381);
            this.dgvSeihin.StandardTab = true;
            this.dgvSeihin.TabIndex = 0;
            this.dgvSeihin.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.setdgvSeihinDoubleClick);
            this.dgvSeihin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDgvSeihinKeyDown);
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
            this.btnF12.TabIndex = 4;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // ChubunruiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 524);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtDaibunrui);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.dgvSeihin);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Name = "ChubunruiList";
            this.Text = "CyokusousakiList";
            this.Load += new System.EventHandler(this.CyokusousakiList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunruiListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeihin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseButton btnF11;
        private BaseButton btnF12;
        private BaseDataGridView dgvSeihin;
        private System.Windows.Forms.Label lblRecords;
        private BaseText txtDaibunrui;
        private BaseLabelGray lblText;
        private BaseLabel baseLabel1;
    }
}