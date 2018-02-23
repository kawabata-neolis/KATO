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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblHuri = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTorihikisaki = new KATO.Common.Ctl.BaseText();
            this.txtHurigana = new KATO.Common.Ctl.BaseText();
            this.gridTorihikisaki = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihikisaki)).BeginInit();
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
            this.txtTorihikisaki.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTorihikisaki.Location = new System.Drawing.Point(124, 46);
            this.txtTorihikisaki.MaxLength = 30;
            this.txtTorihikisaki.Name = "txtTorihikisaki";
            this.txtTorihikisaki.Size = new System.Drawing.Size(296, 22);
            this.txtTorihikisaki.TabIndex = 1;
            this.txtTorihikisaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            this.txtTorihikisaki.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTorihikisaki_KeyUp);
            // 
            // txtHurigana
            // 
            this.txtHurigana.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHurigana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtHurigana.Location = new System.Drawing.Point(124, 18);
            this.txtHurigana.MaxLength = 15;
            this.txtHurigana.Name = "txtHurigana";
            this.txtHurigana.Size = new System.Drawing.Size(146, 22);
            this.txtHurigana.TabIndex = 0;
            this.txtHurigana.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            this.txtHurigana.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTorihikisaki_KeyUp);
            // 
            // gridTorihikisaki
            // 
            this.gridTorihikisaki.AllowUserToAddRows = false;
            this.gridTorihikisaki.AllowUserToResizeColumns = false;
            this.gridTorihikisaki.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTorihikisaki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridTorihikisaki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTorihikisaki.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridTorihikisaki.EnableHeadersVisualStyles = false;
            this.gridTorihikisaki.Location = new System.Drawing.Point(12, 84);
            this.gridTorihikisaki.Name = "gridTorihikisaki";
            this.gridTorihikisaki.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTorihikisaki.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridTorihikisaki.RowHeadersVisible = false;
            this.gridTorihikisaki.RowTemplate.Height = 21;
            this.gridTorihikisaki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTorihikisaki.Size = new System.Drawing.Size(776, 451);
            this.gridTorihikisaki.StandardTab = true;
            this.gridTorihikisaki.TabIndex = 3;
            this.gridTorihikisaki.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTorihikisaki_CellDoubleClick);
            this.gridTorihikisaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridTokuiKeyDown);
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
            // TorihikisakiList
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
            this.Controls.Add(this.gridTorihikisaki);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Name = "TorihikisakiList";
            this.Text = "TorihikisakiList";
            this.Load += new System.EventHandler(this.TantousyaList_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_KeyPress);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihikisaki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctl.BaseButton btnF12;
        private Ctl.BaseDataGridView gridTorihikisaki;
        private Ctl.BaseText txtHurigana;
        private Ctl.BaseText txtTorihikisaki;
        private Ctl.BaseLabel lblHuri;
        private Ctl.BaseLabel lblName;
        private Ctl.BaseButton btnF11;
        private Ctl.BaseLabel baseLabel2;
        private System.Windows.Forms.Label lblRecords;
    }
}