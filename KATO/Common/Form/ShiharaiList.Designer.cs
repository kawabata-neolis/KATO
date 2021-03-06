﻿namespace KATO.Common.Form
{
    partial class ShiharaiList
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
            this.gridTokui = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblset_Shiresaki = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            ((System.ComponentModel.ISupportInitialize)(this.gridTokui)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTokui
            // 
            this.gridTokui.AllowUserToAddRows = false;
            this.gridTokui.AllowUserToResizeColumns = false;
            this.gridTokui.AllowUserToResizeRows = false;
            this.gridTokui.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokui.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTokui.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTokui.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridTokui.EnableHeadersVisualStyles = false;
            this.gridTokui.Location = new System.Drawing.Point(31, 83);
            this.gridTokui.Name = "gridTokui";
            this.gridTokui.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokui.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTokui.RowHeadersVisible = false;
            this.gridTokui.RowTemplate.Height = 21;
            this.gridTokui.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTokui.Size = new System.Drawing.Size(732, 457);
            this.gridTokui.StandardTab = true;
            this.gridTokui.TabIndex = 2;
            this.gridTokui.DoubleClick += new System.EventHandler(this.gridTokui_DoubleClick);
            this.gridTokui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridTokui_KeyDown);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(663, 12);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 3;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(663, 41);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 1;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnKensakuClick);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(29, 552);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 20;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // lblset_Shiresaki
            // 
            this.lblset_Shiresaki.AppendLabelSize = 0;
            this.lblset_Shiresaki.AppendLabelText = "";
            this.lblset_Shiresaki.CodeTxtSize = 40;
            this.lblset_Shiresaki.CodeTxtText = "";
            this.lblset_Shiresaki.LabelName = "取引先コード";
            this.lblset_Shiresaki.Location = new System.Drawing.Point(31, 22);
            this.lblset_Shiresaki.Name = "lblset_Shiresaki";
            this.lblset_Shiresaki.ShowAppendFlg = false;
            this.lblset_Shiresaki.Size = new System.Drawing.Size(472, 22);
            this.lblset_Shiresaki.SpaceCodeValue = 4;
            this.lblset_Shiresaki.SpaceNameCode = 4;
            this.lblset_Shiresaki.SpaceValueAppend = 4;
            this.lblset_Shiresaki.TabIndex = 0;
            this.lblset_Shiresaki.ValueLabelSize = 300;
            this.lblset_Shiresaki.ValueLabelText = "";
            // 
            // ShiharaiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 587);
            this.Controls.Add(this.lblset_Shiresaki);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.gridTokui);
            this.Name = "ShiharaiList";
            this.Text = "ShiharaiList";
            this.Load += new System.EventHandler(this.ShiharaiList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShiharaiList_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gridTokui)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctl.BaseDataGridView gridTokui;
        private Ctl.BaseButton btnF12;
        private Ctl.BaseButton btnF11;
        private System.Windows.Forms.Label lblRecords;
        private Ctl.LabelSet_Torihikisaki lblset_Shiresaki;
    }
}