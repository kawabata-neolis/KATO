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
            this.chkNotToroku = new System.Windows.Forms.CheckBox();
            this.labelSet_Maker = new KATO.Common.Ctl.LabelSet_Maker();
            this.labelSet_Chubunrui = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.labelSet_Daibunrui = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.btnGifuZaiko = new KATO.Common.Ctl.BaseButton();
            this.btnHonshaZaiko = new KATO.Common.Ctl.BaseButton();
            this.gridTorihiki = new KATO.Common.Ctl.BaseDataGridView();
            this.txtKensaku = new KATO.Common.Ctl.BaseText();
            this.lblDataFree = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblKensaku = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblGihu = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblHon = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtGihu = new KATO.Common.Ctl.BaseText();
            this.txtHon = new KATO.Common.Ctl.BaseText();
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).BeginInit();
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
            // chkNotToroku
            // 
            this.chkNotToroku.AutoSize = true;
            this.chkNotToroku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.chkNotToroku.Location = new System.Drawing.Point(326, 12);
            this.chkNotToroku.Name = "chkNotToroku";
            this.chkNotToroku.Size = new System.Drawing.Size(394, 19);
            this.chkNotToroku.TabIndex = 107;
            this.chkNotToroku.Text = "登録されていない棚番を使用している商品のみ表示";
            this.chkNotToroku.UseVisualStyleBackColor = true;
            this.chkNotToroku.Visible = false;
            // 
            // labelSet_Maker
            // 
            this.labelSet_Maker.AppendLabelSize = 0;
            this.labelSet_Maker.AppendLabelText = "";
            this.labelSet_Maker.CodeTxtSize = 40;
            this.labelSet_Maker.CodeTxtText = "";
            this.labelSet_Maker.LabelName = "メーカー";
            this.labelSet_Maker.Location = new System.Drawing.Point(12, 69);
            this.labelSet_Maker.Name = "labelSet_Maker";
            this.labelSet_Maker.ShowAppendFlg = false;
            this.labelSet_Maker.Size = new System.Drawing.Size(288, 22);
            this.labelSet_Maker.SpaceCodeValue = 4;
            this.labelSet_Maker.SpaceNameCode = 24;
            this.labelSet_Maker.SpaceValueAppend = 4;
            this.labelSet_Maker.TabIndex = 110;
            this.labelSet_Maker.ValueLabelSize = 150;
            this.labelSet_Maker.ValueLabelText = "";
            this.labelSet_Maker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            // 
            // labelSet_Chubunrui
            // 
            this.labelSet_Chubunrui.AppendLabelSize = 0;
            this.labelSet_Chubunrui.AppendLabelText = "";
            this.labelSet_Chubunrui.CodeTxtSize = 24;
            this.labelSet_Chubunrui.CodeTxtText = "";
            this.labelSet_Chubunrui.LabelName = "中分類";
            this.labelSet_Chubunrui.Location = new System.Drawing.Point(12, 40);
            this.labelSet_Chubunrui.Name = "labelSet_Chubunrui";
            this.labelSet_Chubunrui.ShowAppendFlg = false;
            this.labelSet_Chubunrui.Size = new System.Drawing.Size(293, 22);
            this.labelSet_Chubunrui.SpaceCodeValue = 18;
            this.labelSet_Chubunrui.SpaceNameCode = 40;
            this.labelSet_Chubunrui.SpaceValueAppend = 4;
            this.labelSet_Chubunrui.strDaibunCd = null;
            this.labelSet_Chubunrui.TabIndex = 109;
            this.labelSet_Chubunrui.ValueLabelSize = 150;
            this.labelSet_Chubunrui.ValueLabelText = "";
            this.labelSet_Chubunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            // 
            // labelSet_Daibunrui
            // 
            this.labelSet_Daibunrui.AppendLabelSize = 0;
            this.labelSet_Daibunrui.AppendLabelText = "";
            this.labelSet_Daibunrui.CodeTxtSize = 24;
            this.labelSet_Daibunrui.CodeTxtText = "";
            this.labelSet_Daibunrui.LabelName = "大分類";
            this.labelSet_Daibunrui.Location = new System.Drawing.Point(12, 12);
            this.labelSet_Daibunrui.Lschubundata = null;
            this.labelSet_Daibunrui.LsSubchubundata = null;
            this.labelSet_Daibunrui.Name = "labelSet_Daibunrui";
            this.labelSet_Daibunrui.ShowAppendFlg = false;
            this.labelSet_Daibunrui.Size = new System.Drawing.Size(308, 22);
            this.labelSet_Daibunrui.SpaceCodeValue = 18;
            this.labelSet_Daibunrui.SpaceNameCode = 40;
            this.labelSet_Daibunrui.SpaceValueAppend = 4;
            this.labelSet_Daibunrui.TabIndex = 108;
            this.labelSet_Daibunrui.ValueLabelSize = 150;
            this.labelSet_Daibunrui.ValueLabelText = "";
            this.labelSet_Daibunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
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
            // gridTorihiki
            // 
            this.gridTorihiki.AllowUserToAddRows = false;
            this.gridTorihiki.AllowUserToResizeColumns = false;
            this.gridTorihiki.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTorihiki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTorihiki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTorihiki.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridTorihiki.EnableHeadersVisualStyles = false;
            this.gridTorihiki.Location = new System.Drawing.Point(12, 122);
            this.gridTorihiki.Name = "gridTorihiki";
            this.gridTorihiki.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTorihiki.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTorihiki.RowHeadersVisible = false;
            this.gridTorihiki.RowTemplate.Height = 21;
            this.gridTorihiki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTorihiki.Size = new System.Drawing.Size(931, 434);
            this.gridTorihiki.StandardTab = true;
            this.gridTorihiki.TabIndex = 102;
            this.gridTorihiki.DoubleClick += new System.EventHandler(this.setGridTorihiki_DoubleClick);
            this.gridTorihiki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridToriKeyDown);
            // 
            // txtKensaku
            // 
            this.txtKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensaku.Location = new System.Drawing.Point(106, 97);
            this.txtKensaku.Name = "txtKensaku";
            this.txtKensaku.Size = new System.Drawing.Size(199, 22);
            this.txtKensaku.TabIndex = 101;
            this.txtKensaku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            // 
            // lblDataFree
            // 
            this.lblDataFree.AutoSize = true;
            this.lblDataFree.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDataFree.Location = new System.Drawing.Point(337, 98);
            this.lblDataFree.Name = "lblDataFree";
            this.lblDataFree.Size = new System.Drawing.Size(367, 15);
            this.lblDataFree.strToolTip = null;
            this.lblDataFree.TabIndex = 100;
            this.lblDataFree.Text = "※ﾌﾘｰ在庫の表示は右のボタンを押してください。";
            this.lblDataFree.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKensaku
            // 
            this.lblKensaku.AutoSize = true;
            this.lblKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKensaku.Location = new System.Drawing.Point(12, 100);
            this.lblKensaku.Name = "lblKensaku";
            this.lblKensaku.Size = new System.Drawing.Size(87, 15);
            this.lblKensaku.strToolTip = null;
            this.lblKensaku.TabIndex = 100;
            this.lblKensaku.Text = "検索文字列";
            this.lblKensaku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGihu
            // 
            this.lblGihu.AutoSize = true;
            this.lblGihu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblGihu.Location = new System.Drawing.Point(712, 56);
            this.lblGihu.Name = "lblGihu";
            this.lblGihu.Size = new System.Drawing.Size(39, 15);
            this.lblGihu.strToolTip = null;
            this.lblGihu.TabIndex = 99;
            this.lblGihu.Text = "岐阜";
            this.lblGihu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGihu.Visible = false;
            // 
            // lblHon
            // 
            this.lblHon.AutoSize = true;
            this.lblHon.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHon.Location = new System.Drawing.Point(609, 56);
            this.lblHon.Name = "lblHon";
            this.lblHon.Size = new System.Drawing.Size(39, 15);
            this.lblHon.strToolTip = null;
            this.lblHon.TabIndex = 99;
            this.lblHon.Text = "本社";
            this.lblHon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHon.Visible = false;
            // 
            // txtGihu
            // 
            this.txtGihu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtGihu.Location = new System.Drawing.Point(759, 52);
            this.txtGihu.MaxLength = 2;
            this.txtGihu.Name = "txtGihu";
            this.txtGihu.Size = new System.Drawing.Size(32, 22);
            this.txtGihu.TabIndex = 92;
            this.txtGihu.Tag = "";
            this.txtGihu.Visible = false;
            this.txtGihu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judShouhinListKeyDown);
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
            this.txtHon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judShouhinListKeyDown);
            // 
            // ShouhinList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 614);
            this.Controls.Add(this.labelSet_Maker);
            this.Controls.Add(this.labelSet_Chubunrui);
            this.Controls.Add(this.labelSet_Daibunrui);
            this.Controls.Add(this.chkNotToroku);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.btnGifuZaiko);
            this.Controls.Add(this.btnHonshaZaiko);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.gridTorihiki);
            this.Controls.Add(this.txtKensaku);
            this.Controls.Add(this.lblDataFree);
            this.Controls.Add(this.lblKensaku);
            this.Controls.Add(this.lblGihu);
            this.Controls.Add(this.lblHon);
            this.Controls.Add(this.txtGihu);
            this.Controls.Add(this.txtHon);
            this.Name = "ShouhinList";
            this.Text = "ShouhinList";
            this.Load += new System.EventHandler(this.ShouhinList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judShouhinListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BaseText txtKensaku;
        private BaseLabel lblKensaku;
        private BaseDataGridView gridTorihiki;
        private System.Windows.Forms.Label lblRecords;
        private BaseLabel lblDataFree;
        private BaseButton btnHonshaZaiko;
        private BaseButton btnGifuZaiko;
        private BaseButton btnF11;
        private BaseButton btnF12;
        private System.Windows.Forms.CheckBox chkNotToroku;
        private BaseText txtHon;
        private BaseText txtGihu;
        private BaseLabel lblHon;
        private BaseLabel lblGihu;
        private LabelSet_Daibunrui labelSet_Daibunrui;
        private LabelSet_Chubunrui labelSet_Chubunrui;
        private LabelSet_Maker labelSet_Maker;
    }
}