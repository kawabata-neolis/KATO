using KATO.Common;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    partial class NyukinList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRecords = new System.Windows.Forms.Label();
            this.gridTokui = new KATO.Common.Ctl.BaseDataGridView();
            this.lblSetTokuisaki = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridTokui)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(29, 552);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 19;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // gridTokui
            // 
            this.gridTokui.AllowUserToAddRows = false;
            this.gridTokui.AllowUserToResizeColumns = false;
            this.gridTokui.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokui.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridTokui.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTokui.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridTokui.EnableHeadersVisualStyles = false;
            this.gridTokui.Location = new System.Drawing.Point(31, 83);
            this.gridTokui.Name = "gridTokui";
            this.gridTokui.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokui.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridTokui.RowHeadersVisible = false;
            this.gridTokui.RowTemplate.Height = 21;
            this.gridTokui.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTokui.Size = new System.Drawing.Size(732, 457);
            this.gridTokui.StandardTab = true;
            this.gridTokui.TabIndex = 2;
            this.gridTokui.DoubleClick += new System.EventHandler(this.gridChoku_DoubleClick);
            this.gridTokui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridTokui_KeyDown);
            // 
            // lblSetTokuisaki
            // 
            this.lblSetTokuisaki.AppendLabelSize = 40;
            this.lblSetTokuisaki.AppendLabelText = "";
            this.lblSetTokuisaki.CodeTxtSize = 40;
            this.lblSetTokuisaki.CodeTxtText = "";
            this.lblSetTokuisaki.LabelName = "得意先";
            this.lblSetTokuisaki.Location = new System.Drawing.Point(31, 29);
            this.lblSetTokuisaki.Name = "lblSetTokuisaki";
            this.lblSetTokuisaki.ShowAppendFlg = false;
            this.lblSetTokuisaki.Size = new System.Drawing.Size(442, 22);
            this.lblSetTokuisaki.SpaceCodeValue = 4;
            this.lblSetTokuisaki.SpaceNameCode = 4;
            this.lblSetTokuisaki.SpaceValueAppend = 4;
            this.lblSetTokuisaki.TabIndex = 0;
            this.lblSetTokuisaki.ValueLabelSize = 300;
            this.lblSetTokuisaki.ValueLabelText = "";
            this.lblSetTokuisaki.Leave += new System.EventHandler(this.labelSet_Tokuisaki_Leave);
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
            // NyukinList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 587);
            this.Controls.Add(this.gridTokui);
            this.Controls.Add(this.lblSetTokuisaki);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Name = "NyukinList";
            this.Text = "ChokusosakiList";
            this.Load += new System.EventHandler(this.NyukinList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NyukinList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridTokui)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseButton btnF11;
        private BaseButton btnF12;
        private System.Windows.Forms.Label lblRecords;
        private LabelSet_Tokuisaki lblSetTokuisaki;
        private BaseDataGridView gridTokui;
    }
}