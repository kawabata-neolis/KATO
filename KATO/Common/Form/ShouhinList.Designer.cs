using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    partial class ShouhinList
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
            this.check1 = new System.Windows.Forms.CheckBox();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.btnGifuZaiko = new KATO.Common.Ctl.BaseButton();
            this.btnHonshaZaiko = new KATO.Common.Ctl.BaseButton();
            this.dgvTorihiki = new KATO.Common.Ctl.BaseDataGridView();
            this.txtKensaku = new KATO.Common.Ctl.BaseText();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel8 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel5 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel4 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel6 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel3 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblDspMaker = new KATO.Common.Ctl.BaseLabelGray();
            this.lblDspChubunrui = new KATO.Common.Ctl.BaseLabelGray();
            this.lblDspDaibunrui = new KATO.Common.Ctl.BaseLabelGray();
            this.txtMaker = new KATO.Common.Ctl.BaseText();
            this.txtGifu = new KATO.Common.Ctl.BaseText();
            this.txtHon = new KATO.Common.Ctl.BaseText();
            this.txtChubunrui = new KATO.Common.Ctl.BaseText();
            this.txtDaibunrui = new KATO.Common.Ctl.BaseText();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTorihiki)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(20, 566);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 103;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // check1
            // 
            this.check1.AutoSize = true;
            this.check1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.check1.Location = new System.Drawing.Point(326, 12);
            this.check1.Name = "check1";
            this.check1.Size = new System.Drawing.Size(394, 19);
            this.check1.TabIndex = 107;
            this.check1.Text = "登録されていない棚番を使用している商品のみ表示";
            this.check1.UseVisualStyleBackColor = true;
            this.check1.Visible = false;
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(827, 41);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 105;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnKensakuClick);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(827, 12);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 106;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // btnGifuZaiko
            // 
            this.btnGifuZaiko.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnGifuZaiko.Location = new System.Drawing.Point(812, 93);
            this.btnGifuZaiko.Name = "btnGifuZaiko";
            this.btnGifuZaiko.Size = new System.Drawing.Size(100, 23);
            this.btnGifuZaiko.TabIndex = 104;
            this.btnGifuZaiko.Text = "岐阜在庫";
            this.btnGifuZaiko.UseVisualStyleBackColor = true;
            this.btnGifuZaiko.Click += new System.EventHandler(this.btnGifuZaikoClick);
            // 
            // btnHonshaZaiko
            // 
            this.btnHonshaZaiko.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnHonshaZaiko.Location = new System.Drawing.Point(706, 94);
            this.btnHonshaZaiko.Name = "btnHonshaZaiko";
            this.btnHonshaZaiko.Size = new System.Drawing.Size(100, 23);
            this.btnHonshaZaiko.TabIndex = 104;
            this.btnHonshaZaiko.Text = "本社在庫";
            this.btnHonshaZaiko.UseVisualStyleBackColor = true;
            this.btnHonshaZaiko.Click += new System.EventHandler(this.btnHonshaZaikoClick);
            // 
            // dgvTorihiki
            // 
            this.dgvTorihiki.AllowUserToAddRows = false;
            this.dgvTorihiki.AllowUserToResizeColumns = false;
            this.dgvTorihiki.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTorihiki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTorihiki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTorihiki.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTorihiki.EnableHeadersVisualStyles = false;
            this.dgvTorihiki.Location = new System.Drawing.Point(12, 122);
            this.dgvTorihiki.Name = "dgvTorihiki";
            this.dgvTorihiki.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTorihiki.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTorihiki.RowHeadersVisible = false;
            this.dgvTorihiki.RowTemplate.Height = 21;
            this.dgvTorihiki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTorihiki.Size = new System.Drawing.Size(931, 434);
            this.dgvTorihiki.StandardTab = true;
            this.dgvTorihiki.TabIndex = 102;
            this.dgvTorihiki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDgvToriKeyDown);
            // 
            // txtKensaku
            // 
            this.txtKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensaku.Location = new System.Drawing.Point(106, 94);
            this.txtKensaku.Name = "txtKensaku";
            this.txtKensaku.Size = new System.Drawing.Size(199, 22);
            this.txtKensaku.TabIndex = 101;
            this.txtKensaku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.setMoveOrder);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(337, 98);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(367, 15);
            this.baseLabel1.TabIndex = 100;
            this.baseLabel1.Text = "※ﾌﾘｰ在庫の表示は右のボタンを押してください。";
            // 
            // baseLabel8
            // 
            this.baseLabel8.AutoSize = true;
            this.baseLabel8.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel8.Location = new System.Drawing.Point(16, 97);
            this.baseLabel8.Name = "baseLabel8";
            this.baseLabel8.Size = new System.Drawing.Size(87, 15);
            this.baseLabel8.TabIndex = 100;
            this.baseLabel8.Text = "検索文字列";
            // 
            // baseLabel5
            // 
            this.baseLabel5.AutoSize = true;
            this.baseLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel5.Location = new System.Drawing.Point(16, 70);
            this.baseLabel5.Name = "baseLabel5";
            this.baseLabel5.Size = new System.Drawing.Size(71, 15);
            this.baseLabel5.TabIndex = 97;
            this.baseLabel5.Text = "メーカー";
            // 
            // baseLabel4
            // 
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel4.Location = new System.Drawing.Point(16, 42);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(55, 15);
            this.baseLabel4.TabIndex = 98;
            this.baseLabel4.Text = "中分類";
            // 
            // baseLabel6
            // 
            this.baseLabel6.AutoSize = true;
            this.baseLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel6.Location = new System.Drawing.Point(712, 56);
            this.baseLabel6.Name = "baseLabel6";
            this.baseLabel6.Size = new System.Drawing.Size(39, 15);
            this.baseLabel6.TabIndex = 99;
            this.baseLabel6.Text = "岐阜";
            this.baseLabel6.Visible = false;
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(609, 56);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(39, 15);
            this.baseLabel2.TabIndex = 99;
            this.baseLabel2.Text = "本社";
            this.baseLabel2.Visible = false;
            // 
            // baseLabel3
            // 
            this.baseLabel3.AutoSize = true;
            this.baseLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel3.Location = new System.Drawing.Point(16, 14);
            this.baseLabel3.Name = "baseLabel3";
            this.baseLabel3.Size = new System.Drawing.Size(55, 15);
            this.baseLabel3.TabIndex = 99;
            this.baseLabel3.Text = "大分類";
            // 
            // lblDspMaker
            // 
            this.lblDspMaker.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspMaker.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspMaker.ForeColor = System.Drawing.Color.Blue;
            this.lblDspMaker.Location = new System.Drawing.Point(144, 66);
            this.lblDspMaker.Name = "lblDspMaker";
            this.lblDspMaker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspMaker.Size = new System.Drawing.Size(161, 23);
            this.lblDspMaker.TabIndex = 94;
            this.lblDspMaker.Text = " ";
            this.lblDspMaker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDspChubunrui
            // 
            this.lblDspChubunrui.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspChubunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspChubunrui.ForeColor = System.Drawing.Color.Blue;
            this.lblDspChubunrui.Location = new System.Drawing.Point(144, 38);
            this.lblDspChubunrui.Name = "lblDspChubunrui";
            this.lblDspChubunrui.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspChubunrui.Size = new System.Drawing.Size(161, 23);
            this.lblDspChubunrui.TabIndex = 95;
            this.lblDspChubunrui.Text = " ";
            this.lblDspChubunrui.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDspDaibunrui
            // 
            this.lblDspDaibunrui.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspDaibunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspDaibunrui.ForeColor = System.Drawing.Color.Blue;
            this.lblDspDaibunrui.Location = new System.Drawing.Point(144, 10);
            this.lblDspDaibunrui.Name = "lblDspDaibunrui";
            this.lblDspDaibunrui.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspDaibunrui.Size = new System.Drawing.Size(161, 23);
            this.lblDspDaibunrui.TabIndex = 96;
            this.lblDspDaibunrui.Text = " ";
            this.lblDspDaibunrui.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaker
            // 
            this.txtMaker.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtMaker.Location = new System.Drawing.Point(106, 67);
            this.txtMaker.MaxLength = 3;
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(32, 22);
            this.txtMaker.TabIndex = 93;
            this.txtMaker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judMakerKeyDown);
            this.txtMaker.Leave += new System.EventHandler(this.judMakerLieave);
            // 
            // txtGifu
            // 
            this.txtGifu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtGifu.Location = new System.Drawing.Point(759, 52);
            this.txtGifu.MaxLength = 2;
            this.txtGifu.Name = "txtGifu";
            this.txtGifu.Size = new System.Drawing.Size(32, 22);
            this.txtGifu.TabIndex = 92;
            this.txtGifu.Tag = "";
            this.txtGifu.Visible = false;
            this.txtGifu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.setMoveOrder);
            // 
            // txtHon
            // 
            this.txtHon.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHon.Location = new System.Drawing.Point(657, 52);
            this.txtHon.MaxLength = 2;
            this.txtHon.Name = "txtHon";
            this.txtHon.Size = new System.Drawing.Size(32, 22);
            this.txtHon.TabIndex = 92;
            this.txtHon.Visible = false;
            this.txtHon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.setMoveOrder);
            // 
            // txtChubunrui
            // 
            this.txtChubunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtChubunrui.Location = new System.Drawing.Point(106, 38);
            this.txtChubunrui.MaxLength = 2;
            this.txtChubunrui.Name = "txtChubunrui";
            this.txtChubunrui.Size = new System.Drawing.Size(32, 22);
            this.txtChubunrui.TabIndex = 92;
            this.txtChubunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judChubunruiKeyDown);
            this.txtChubunrui.Leave += new System.EventHandler(this.judCyubunruiLieave);
            // 
            // txtDaibunrui
            // 
            this.txtDaibunrui.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDaibunrui.Location = new System.Drawing.Point(106, 10);
            this.txtDaibunrui.MaxLength = 2;
            this.txtDaibunrui.Name = "txtDaibunrui";
            this.txtDaibunrui.Size = new System.Drawing.Size(32, 22);
            this.txtDaibunrui.TabIndex = 91;
            this.txtDaibunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaibunruiKeyDown);
            this.txtDaibunrui.Leave += new System.EventHandler(this.judDaibunruiLieave);
            // 
            // ShouhinList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 614);
            this.Controls.Add(this.check1);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.btnGifuZaiko);
            this.Controls.Add(this.btnHonshaZaiko);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.dgvTorihiki);
            this.Controls.Add(this.txtKensaku);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.baseLabel8);
            this.Controls.Add(this.baseLabel5);
            this.Controls.Add(this.baseLabel4);
            this.Controls.Add(this.baseLabel6);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.baseLabel3);
            this.Controls.Add(this.lblDspMaker);
            this.Controls.Add(this.lblDspChubunrui);
            this.Controls.Add(this.lblDspDaibunrui);
            this.Controls.Add(this.txtMaker);
            this.Controls.Add(this.txtGifu);
            this.Controls.Add(this.txtHon);
            this.Controls.Add(this.txtChubunrui);
            this.Controls.Add(this.txtDaibunrui);
            this.Name = "ShouhinList";
            this.Text = "ShouhinList";
            this.Load += new System.EventHandler(this.ShouhinList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judShouhinListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTorihiki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseLabel baseLabel5;
        private BaseLabel baseLabel4;
        private BaseLabel baseLabel3;
        private BaseLabelGray lblDspMaker;
        private BaseLabelGray lblDspChubunrui;
        private BaseLabelGray lblDspDaibunrui;
        private BaseText txtMaker;
        private BaseText txtChubunrui;
        private BaseText txtDaibunrui;
        private BaseText txtKensaku;
        private BaseLabel baseLabel8;
        private BaseDataGridView dgvTorihiki;
        private System.Windows.Forms.Label lblRecords;
        private BaseLabel baseLabel1;
        private BaseButton btnHonshaZaiko;
        private BaseButton btnGifuZaiko;
        private BaseButton btnF11;
        private BaseButton btnF12;
        private System.Windows.Forms.CheckBox check1;
        private BaseText txtHon;
        private BaseText txtGifu;
        private BaseLabel baseLabel2;
        private BaseLabel baseLabel6;
    }
}