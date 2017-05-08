using KATO.Common;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    partial class MakerList
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
            this.lblRecords = new System.Windows.Forms.Label();
            this.labelSet_Daibunrui1 = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.txtKensaku = new KATO.Common.Ctl.BaseText();
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
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
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 105;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // labelSet_Daibunrui1
            // 
            this.labelSet_Daibunrui1.AppendLabelSize = 0;
            this.labelSet_Daibunrui1.AppendLabelText = "";
            this.labelSet_Daibunrui1.CodeTxtSize = 33;
            this.labelSet_Daibunrui1.CodeTxtText = "";
            this.labelSet_Daibunrui1.LabelName = "大分類コード";
            this.labelSet_Daibunrui1.Location = new System.Drawing.Point(31, 14);
            this.labelSet_Daibunrui1.Lschubundata = null;
            this.labelSet_Daibunrui1.LsSubchubundata = null;
            this.labelSet_Daibunrui1.Name = "labelSet_Daibunrui1";
            this.labelSet_Daibunrui1.ShowAppendFlg = false;
            this.labelSet_Daibunrui1.Size = new System.Drawing.Size(309, 22);
            this.labelSet_Daibunrui1.SpaceCodeValue = 4;
            this.labelSet_Daibunrui1.SpaceNameCode = 4;
            this.labelSet_Daibunrui1.SpaceValueAppend = 4;
            this.labelSet_Daibunrui1.TabIndex = 0;
            this.labelSet_Daibunrui1.ValueLabelSize = 150;
            this.labelSet_Daibunrui1.ValueLabelText = "";
            // 
            // txtKensaku
            // 
            this.txtKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensaku.Location = new System.Drawing.Point(138, 44);
            this.txtKensaku.MaxLength = 50;
            this.txtKensaku.Name = "txtKensaku";
            this.txtKensaku.Size = new System.Drawing.Size(164, 22);
            this.txtKensaku.TabIndex = 1;
            this.txtKensaku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.setMoveOrder);
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(33, 47);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(87, 15);
            this.baseLabel2.TabIndex = 101;
            this.baseLabel2.Text = "検索文字列";
            this.baseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvSeihin
            // 
            this.dgvSeihin.AllowUserToAddRows = false;
            this.dgvSeihin.AllowUserToResizeColumns = false;
            this.dgvSeihin.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSeihin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSeihin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeihin.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSeihin.EnableHeadersVisualStyles = false;
            this.dgvSeihin.Location = new System.Drawing.Point(31, 86);
            this.dgvSeihin.Name = "dgvSeihin";
            this.dgvSeihin.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSeihin.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSeihin.RowHeadersVisible = false;
            this.dgvSeihin.RowTemplate.Height = 21;
            this.dgvSeihin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeihin.Size = new System.Drawing.Size(474, 378);
            this.dgvSeihin.StandardTab = true;
            this.dgvSeihin.TabIndex = 3;
            this.dgvSeihin.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.setdgvSeihinDoubleClick);
            this.dgvSeihin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDgvSeihinKeyDown);
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(405, 41);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 2;
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
            // MakerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 524);
            this.Controls.Add(this.labelSet_Daibunrui1);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.txtKensaku);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.dgvSeihin);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Name = "MakerList";
            this.Text = "MakerList";
            this.Load += new System.EventHandler(this.MakerList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judMakerListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeihin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseDataGridView dgvSeihin;
        private BaseButton btnF11;
        private BaseButton btnF12;
        private BaseLabel baseLabel2;
        private BaseText txtKensaku;
        private System.Windows.Forms.Label lblRecords;
        private LabelSet_Daibunrui labelSet_Daibunrui1;
    }
}