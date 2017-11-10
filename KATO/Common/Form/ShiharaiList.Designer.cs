namespace KATO.Common.Form
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridTokui = new KATO.Common.Ctl.BaseDataGridView();
            this.labelSet_Tokuisaki = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.nameLabel = new KATO.Common.Ctl.BaseLabel(this.components);
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.lblRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridTokui)).BeginInit();
            this.labelSet_Tokuisaki.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridTokui
            // 
            this.gridTokui.AllowUserToAddRows = false;
            this.gridTokui.AllowUserToResizeColumns = false;
            this.gridTokui.AllowUserToResizeRows = false;
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
            // labelSet_Tokuisaki
            // 
            this.labelSet_Tokuisaki.AppendLabelSize = 40;
            this.labelSet_Tokuisaki.AppendLabelText = "";
            this.labelSet_Tokuisaki.CodeTxtSize = 40;
            this.labelSet_Tokuisaki.CodeTxtText = "";
            this.labelSet_Tokuisaki.Controls.Add(this.nameLabel);
            this.labelSet_Tokuisaki.LabelName = "仕入先";
            this.labelSet_Tokuisaki.Location = new System.Drawing.Point(31, 29);
            this.labelSet_Tokuisaki.Name = "labelSet_Tokuisaki";
            this.labelSet_Tokuisaki.ShowAppendFlg = false;
            this.labelSet_Tokuisaki.Size = new System.Drawing.Size(442, 22);
            this.labelSet_Tokuisaki.SpaceCodeValue = 4;
            this.labelSet_Tokuisaki.SpaceNameCode = 4;
            this.labelSet_Tokuisaki.SpaceValueAppend = 4;
            this.labelSet_Tokuisaki.TabIndex = 0;
            this.labelSet_Tokuisaki.ValueLabelSize = 300;
            this.labelSet_Tokuisaki.ValueLabelText = "";
            this.labelSet_Tokuisaki.Leave += new System.EventHandler(this.labelSet_Tokuisaki_Leave);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.nameLabel.Location = new System.Drawing.Point(2, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(55, 15);
            this.nameLabel.strToolTip = null;
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "得意先";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // ShiharaiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 587);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.labelSet_Tokuisaki);
            this.Controls.Add(this.gridTokui);
            this.Name = "ShiharaiList";
            this.Text = "ShiharaiList";
            this.Load += new System.EventHandler(this.ShiharaiList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShiharaiList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridTokui)).EndInit();
            this.labelSet_Tokuisaki.ResumeLayout(false);
            this.labelSet_Tokuisaki.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctl.BaseDataGridView gridTokui;
        private Ctl.LabelSet_Tokuisaki labelSet_Tokuisaki;
        private Ctl.BaseLabel nameLabel;
        private Ctl.BaseButton btnF12;
        private Ctl.BaseButton btnF11;
        private System.Windows.Forms.Label lblRecords;
    }
}