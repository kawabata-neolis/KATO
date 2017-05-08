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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblBaseLabelName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblBaseLabelHuri = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTorihikisaki = new KATO.Common.Ctl.BaseText();
            this.txtHurigana = new KATO.Common.Ctl.BaseText();
            this.TokuisakiGrid = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.TokuisakiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(29, 549);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 88;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // lblBaseLabelName
            // 
            this.lblBaseLabelName.AutoSize = true;
            this.lblBaseLabelName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabelName.Location = new System.Drawing.Point(33, 59);
            this.lblBaseLabelName.Name = "lblBaseLabelName";
            this.lblBaseLabelName.Size = new System.Drawing.Size(71, 15);
            this.lblBaseLabelName.TabIndex = 87;
            this.lblBaseLabelName.Text = "取引先名";
            this.lblBaseLabelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.baseLabel2.Location = new System.Drawing.Point(433, 64);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(305, 12);
            this.baseLabel2.TabIndex = 87;
            this.baseLabel2.Text = "※得意先名は「含み検索」以外は、〇〇で始まるです。";
            this.baseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaseLabelHuri
            // 
            this.lblBaseLabelHuri.AutoSize = true;
            this.lblBaseLabelHuri.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBaseLabelHuri.Location = new System.Drawing.Point(33, 32);
            this.lblBaseLabelHuri.Name = "lblBaseLabelHuri";
            this.lblBaseLabelHuri.Size = new System.Drawing.Size(71, 15);
            this.lblBaseLabelHuri.TabIndex = 87;
            this.lblBaseLabelHuri.Text = "フリガナ";
            this.lblBaseLabelHuri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTorihikisaki
            // 
            this.txtTorihikisaki.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTorihikisaki.Location = new System.Drawing.Point(133, 56);
            this.txtTorihikisaki.Name = "txtTorihikisaki";
            this.txtTorihikisaki.Size = new System.Drawing.Size(296, 22);
            this.txtTorihikisaki.TabIndex = 1;
            this.txtTorihikisaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListKeyDown);
            // 
            // txtHurigana
            // 
            this.txtHurigana.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHurigana.Location = new System.Drawing.Point(133, 28);
            this.txtHurigana.Name = "txtHurigana";
            this.txtHurigana.Size = new System.Drawing.Size(146, 22);
            this.txtHurigana.TabIndex = 0;
            this.txtHurigana.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListKeyDown);
            // 
            // TokuisakiGrid
            // 
            this.TokuisakiGrid.AllowUserToAddRows = false;
            this.TokuisakiGrid.AllowUserToResizeColumns = false;
            this.TokuisakiGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TokuisakiGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TokuisakiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TokuisakiGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.TokuisakiGrid.EnableHeadersVisualStyles = false;
            this.TokuisakiGrid.Location = new System.Drawing.Point(12, 84);
            this.TokuisakiGrid.Name = "TokuisakiGrid";
            this.TokuisakiGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TokuisakiGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.TokuisakiGrid.RowHeadersVisible = false;
            this.TokuisakiGrid.RowTemplate.Height = 21;
            this.TokuisakiGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TokuisakiGrid.Size = new System.Drawing.Size(776, 451);
            this.TokuisakiGrid.StandardTab = true;
            this.TokuisakiGrid.TabIndex = 3;
            this.TokuisakiGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.setTanGridDblClick);
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(663, 38);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 2;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnKensakuClick);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(663, 12);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 4;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // TokuisakiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 587);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.lblBaseLabelName);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.lblBaseLabelHuri);
            this.Controls.Add(this.txtTorihikisaki);
            this.Controls.Add(this.txtHurigana);
            this.Controls.Add(this.TokuisakiGrid);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Name = "TokuisakiList";
            this.Text = "TokuisakiList";
            this.Load += new System.EventHandler(this.TantousyaList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TokuisakiGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctl.BaseButton btnF12;
        private Ctl.BaseDataGridView TokuisakiGrid;
        private Ctl.BaseText txtHurigana;
        private Ctl.BaseText txtTorihikisaki;
        private Ctl.BaseLabel lblBaseLabelHuri;
        private Ctl.BaseLabel lblBaseLabelName;
        private Ctl.BaseButton btnF11;
        private Ctl.BaseLabel baseLabel2;
        private System.Windows.Forms.Label lblRecords;
    }
}