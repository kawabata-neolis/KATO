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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRecords = new System.Windows.Forms.Label();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtKensakuKana = new KATO.Common.Ctl.BaseText();
            this.lblSetDaibunrui = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.txtKensaku = new KATO.Common.Ctl.BaseText();
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gridMaker = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaker)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(29, 519);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 105;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(33, 99);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(39, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 107;
            this.baseLabel1.Text = "カナ";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKensakuKana
            // 
            this.txtKensakuKana.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensakuKana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtKensakuKana.Location = new System.Drawing.Point(36, 121);
            this.txtKensakuKana.MaxLength = 80;
            this.txtKensakuKana.Name = "txtKensakuKana";
            this.txtKensakuKana.Size = new System.Drawing.Size(410, 22);
            this.txtKensakuKana.TabIndex = 2;
            this.txtKensakuKana.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            this.txtKensakuKana.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKensaku_KeyUp);
            // 
            // lblSetDaibunrui
            // 
            this.lblSetDaibunrui.AppendLabelSize = 0;
            this.lblSetDaibunrui.AppendLabelText = "";
            this.lblSetDaibunrui.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lblSetDaibunrui.CodeTxtSize = 33;
            this.lblSetDaibunrui.CodeTxtText = "";
            this.lblSetDaibunrui.LabelName = "大分類コード";
            this.lblSetDaibunrui.Location = new System.Drawing.Point(31, 14);
            this.lblSetDaibunrui.Lschubundata = null;
            this.lblSetDaibunrui.Lsmakerdata = null;
            this.lblSetDaibunrui.LsSubchubundata = null;
            this.lblSetDaibunrui.LsSubmakerdata = null;
            this.lblSetDaibunrui.Name = "lblSetDaibunrui";
            this.lblSetDaibunrui.ShowAppendFlg = false;
            this.lblSetDaibunrui.Size = new System.Drawing.Size(309, 22);
            this.lblSetDaibunrui.SpaceCodeValue = 4;
            this.lblSetDaibunrui.SpaceNameCode = 4;
            this.lblSetDaibunrui.SpaceValueAppend = 4;
            this.lblSetDaibunrui.TabIndex = 0;
            this.lblSetDaibunrui.ValueLabelSize = 150;
            this.lblSetDaibunrui.ValueLabelText = "";
            this.lblSetDaibunrui.Leave += new System.EventHandler(this.lblSetDaibunrui_Leave);
            // 
            // txtKensaku
            // 
            this.txtKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensaku.Location = new System.Drawing.Point(36, 70);
            this.txtKensaku.MaxLength = 50;
            this.txtKensaku.Name = "txtKensaku";
            this.txtKensaku.Size = new System.Drawing.Size(410, 22);
            this.txtKensaku.TabIndex = 1;
            this.txtKensaku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            this.txtKensaku.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKensaku_KeyUp);
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(33, 47);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(87, 15);
            this.baseLabel2.strToolTip = null;
            this.baseLabel2.TabIndex = 101;
            this.baseLabel2.Text = "検索文字列";
            this.baseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridMaker
            // 
            this.gridMaker.AllowUserToAddRows = false;
            this.gridMaker.AllowUserToResizeColumns = false;
            this.gridMaker.AllowUserToResizeRows = false;
            this.gridMaker.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMaker.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMaker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMaker.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridMaker.EnableHeadersVisualStyles = false;
            this.gridMaker.Location = new System.Drawing.Point(31, 152);
            this.gridMaker.Name = "gridMaker";
            this.gridMaker.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMaker.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridMaker.RowHeadersVisible = false;
            this.gridMaker.RowTemplate.Height = 21;
            this.gridMaker.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMaker.Size = new System.Drawing.Size(474, 354);
            this.gridMaker.StandardTab = true;
            this.gridMaker.TabIndex = 4;
            this.gridMaker.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.setGridSeihinDoubleClick);
            this.gridMaker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridSeihinKeyDown);
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
            this.btnF12.TabIndex = 5;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // MakerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 554);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.txtKensakuKana);
            this.Controls.Add(this.lblSetDaibunrui);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.txtKensaku);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.gridMaker);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Name = "MakerList";
            this.Text = "MakerList";
            this.Load += new System.EventHandler(this.MakerList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judMakerListKeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseDataGridView gridMaker;
        private BaseButton btnF11;
        private BaseButton btnF12;
        private BaseLabel baseLabel2;
        private BaseText txtKensaku;
        private System.Windows.Forms.Label lblRecords;
        private LabelSet_Daibunrui lblSetDaibunrui;
        private BaseText txtKensakuKana;
        private BaseLabel baseLabel1;
    }
}