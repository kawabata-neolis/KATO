namespace KATO.Common.Form
{
    partial class TorihikisakiList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblHuri = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTorihikisaki = new KATO.Common.Ctl.BaseText();
            this.txtHurigana = new KATO.Common.Ctl.BaseText();
            this.gridTokuisaki = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridTokuisaki)).BeginInit();
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
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblName.Location = new System.Drawing.Point(24, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 15);
            this.lblName.strToolTip = null;
            this.lblName.TabIndex = 87;
            this.lblName.Text = "取引先名";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.baseLabel2.Location = new System.Drawing.Point(433, 65);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(305, 12);
            this.baseLabel2.strToolTip = null;
            this.baseLabel2.TabIndex = 87;
            this.baseLabel2.Text = "※得意先名は「含み検索」以外は、〇〇で始まるです。";
            this.baseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHuri
            // 
            this.lblHuri.AutoSize = true;
            this.lblHuri.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHuri.Location = new System.Drawing.Point(24, 22);
            this.lblHuri.Name = "lblHuri";
            this.lblHuri.Size = new System.Drawing.Size(71, 15);
            this.lblHuri.strToolTip = null;
            this.lblHuri.TabIndex = 87;
            this.lblHuri.Text = "フリガナ";
            this.lblHuri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTorihikisaki
            // 
            this.txtTorihikisaki.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTorihikisaki.Location = new System.Drawing.Point(124, 46);
            this.txtTorihikisaki.Name = "txtTorihikisaki";
            this.txtTorihikisaki.Size = new System.Drawing.Size(296, 22);
            this.txtTorihikisaki.TabIndex = 1;
            this.txtTorihikisaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            this.txtTorihikisaki.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTorihikisaki_KeyUp);
            // 
            // txtHurigana
            // 
            this.txtHurigana.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHurigana.Location = new System.Drawing.Point(124, 18);
            this.txtHurigana.Name = "txtHurigana";
            this.txtHurigana.Size = new System.Drawing.Size(146, 22);
            this.txtHurigana.TabIndex = 0;
            this.txtHurigana.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            this.txtHurigana.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTorihikisaki_KeyUp);
            // 
            // gridTokuisaki
            // 
            this.gridTokuisaki.AllowUserToAddRows = false;
            this.gridTokuisaki.AllowUserToResizeColumns = false;
            this.gridTokuisaki.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokuisaki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridTokuisaki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTokuisaki.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridTokuisaki.EnableHeadersVisualStyles = false;
            this.gridTokuisaki.Location = new System.Drawing.Point(12, 84);
            this.gridTokuisaki.Name = "gridTokuisaki";
            this.gridTokuisaki.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokuisaki.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridTokuisaki.RowHeadersVisible = false;
            this.gridTokuisaki.RowTemplate.Height = 21;
            this.gridTokuisaki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTokuisaki.Size = new System.Drawing.Size(776, 451);
            this.gridTokuisaki.StandardTab = true;
            this.gridTokuisaki.TabIndex = 3;
            this.gridTokuisaki.DoubleClick += new System.EventHandler(this.setTokuiGridDblClick);
            this.gridTokuisaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridTokuiKeyDown);
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
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.lblHuri);
            this.Controls.Add(this.txtTorihikisaki);
            this.Controls.Add(this.txtHurigana);
            this.Controls.Add(this.gridTokuisaki);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Name = "TokuisakiList";
            this.Text = "TorihikisakiList";
            this.Load += new System.EventHandler(this.TantousyaList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridTokuisaki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctl.BaseButton btnF12;
        private Ctl.BaseDataGridView gridTokuisaki;
        private Ctl.BaseText txtHurigana;
        private Ctl.BaseText txtTorihikisaki;
        private Ctl.BaseLabel lblHuri;
        private Ctl.BaseLabel lblName;
        private Ctl.BaseButton btnF11;
        private Ctl.BaseLabel baseLabel2;
        private System.Windows.Forms.Label lblRecords;
    }
}