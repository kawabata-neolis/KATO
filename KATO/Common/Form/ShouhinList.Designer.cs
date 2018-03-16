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
            this.radSet_2btn_Toroku = new KATO.Common.Ctl.RadSet_2btn();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblTitle = new KATO.Common.Ctl.BaseLabel(this.components);
            this.radSet_2btn_Kensaku = new KATO.Common.Ctl.RadSet_2btn();
            this.labelSet_Maker = new KATO.Common.Ctl.LabelSet_Maker();
            this.labelSet_Chubunrui = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.labelSet_Daibunrui = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.gridTorihiki = new KATO.Common.Ctl.BaseDataGridView();
            this.txtKensaku = new KATO.Common.Ctl.BaseText();
            this.lblKensaku = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtKensakuHuku = new KATO.Common.Ctl.BaseText();
            this.lblKensakuHuku = new KATO.Common.Ctl.BaseLabel(this.components);
            this.radSet_2btn_Toroku.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(13, 650);
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
            this.chkNotToroku.Location = new System.Drawing.Point(370, 14);
            this.chkNotToroku.Name = "chkNotToroku";
            this.chkNotToroku.Size = new System.Drawing.Size(394, 19);
            this.chkNotToroku.TabIndex = 107;
            this.chkNotToroku.Text = "登録されていない棚番を使用している商品のみ表示";
            this.chkNotToroku.UseVisualStyleBackColor = true;
            this.chkNotToroku.Visible = false;
            // 
            // radSet_2btn_Toroku
            // 
            this.radSet_2btn_Toroku.Controls.Add(this.baseLabel1);
            this.radSet_2btn_Toroku.Controls.Add(this.lblTitle);
            this.radSet_2btn_Toroku.intJudBtn = 0;
            this.radSet_2btn_Toroku.LabelTitle = " ";
            this.radSet_2btn_Toroku.Location = new System.Drawing.Point(919, 96);
            this.radSet_2btn_Toroku.Name = "radSet_2btn_Toroku";
            this.radSet_2btn_Toroku.PositionLabelTitle_X = 0;
            this.radSet_2btn_Toroku.PositionLabelTitle_Y = 0;
            this.radSet_2btn_Toroku.PositionRadbtn1_X = 20;
            this.radSet_2btn_Toroku.PositionRadbtn1_Y = 0;
            this.radSet_2btn_Toroku.PositionRadbtn2_X = 120;
            this.radSet_2btn_Toroku.PositionRadbtn2_Y = 0;
            this.radSet_2btn_Toroku.Radbtn1Text = "本登録";
            this.radSet_2btn_Toroku.Radbtn2Text = "仮登録";
            this.radSet_2btn_Toroku.Size = new System.Drawing.Size(217, 19);
            this.radSet_2btn_Toroku.TabIndex = 5;
            this.radSet_2btn_Toroku.TabStop = false;
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(0, 0);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(15, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 6;
            this.baseLabel1.Text = " ";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(15, 15);
            this.lblTitle.strToolTip = null;
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = " ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radSet_2btn_Kensaku
            // 
            this.radSet_2btn_Kensaku.intJudBtn = 0;
            this.radSet_2btn_Kensaku.LabelTitle = " ";
            this.radSet_2btn_Kensaku.Location = new System.Drawing.Point(696, 95);
            this.radSet_2btn_Kensaku.Name = "radSet_2btn_Kensaku";
            this.radSet_2btn_Kensaku.PositionLabelTitle_X = 0;
            this.radSet_2btn_Kensaku.PositionLabelTitle_Y = 0;
            this.radSet_2btn_Kensaku.PositionRadbtn1_X = 20;
            this.radSet_2btn_Kensaku.PositionRadbtn1_Y = 0;
            this.radSet_2btn_Kensaku.PositionRadbtn2_X = 120;
            this.radSet_2btn_Kensaku.PositionRadbtn2_Y = 0;
            this.radSet_2btn_Kensaku.Radbtn1Text = "部分一致";
            this.radSet_2btn_Kensaku.Radbtn2Text = "完全一致";
            this.radSet_2btn_Kensaku.Size = new System.Drawing.Size(217, 19);
            this.radSet_2btn_Kensaku.TabIndex = 4;
            this.radSet_2btn_Kensaku.TabStop = false;
            // 
            // labelSet_Maker
            // 
            this.labelSet_Maker.AppendLabelSize = 0;
            this.labelSet_Maker.AppendLabelText = "";
            this.labelSet_Maker.CodeTxtSize = 40;
            this.labelSet_Maker.CodeTxtText = "";
            this.labelSet_Maker.LabelName = "メーカー";
            this.labelSet_Maker.Location = new System.Drawing.Point(12, 68);
            this.labelSet_Maker.Name = "labelSet_Maker";
            this.labelSet_Maker.ShowAppendFlg = false;
            this.labelSet_Maker.Size = new System.Drawing.Size(350, 22);
            this.labelSet_Maker.SpaceCodeValue = 4;
            this.labelSet_Maker.SpaceNameCode = 24;
            this.labelSet_Maker.SpaceValueAppend = 4;
            this.labelSet_Maker.strDaibunCd = null;
            this.labelSet_Maker.TabIndex = 2;
            this.labelSet_Maker.ValueLabelSize = 200;
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
            this.labelSet_Chubunrui.Size = new System.Drawing.Size(350, 22);
            this.labelSet_Chubunrui.SpaceCodeValue = 20;
            this.labelSet_Chubunrui.SpaceNameCode = 40;
            this.labelSet_Chubunrui.SpaceValueAppend = 4;
            this.labelSet_Chubunrui.strDaibunCd = null;
            this.labelSet_Chubunrui.TabIndex = 1;
            this.labelSet_Chubunrui.ValueLabelSize = 200;
            this.labelSet_Chubunrui.ValueLabelText = "";
            this.labelSet_Chubunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            // 
            // labelSet_Daibunrui
            // 
            this.labelSet_Daibunrui.AppendLabelSize = 0;
            this.labelSet_Daibunrui.AppendLabelText = "";
            this.labelSet_Daibunrui.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.labelSet_Daibunrui.CodeTxtSize = 24;
            this.labelSet_Daibunrui.CodeTxtText = "";
            this.labelSet_Daibunrui.LabelName = "大分類";
            this.labelSet_Daibunrui.Location = new System.Drawing.Point(12, 12);
            this.labelSet_Daibunrui.Lschubundata = null;
            this.labelSet_Daibunrui.Lsmakerdata = null;
            this.labelSet_Daibunrui.LsSubchubundata = null;
            this.labelSet_Daibunrui.LsSubmakerdata = null;
            this.labelSet_Daibunrui.Name = "labelSet_Daibunrui";
            this.labelSet_Daibunrui.ShowAppendFlg = false;
            this.labelSet_Daibunrui.Size = new System.Drawing.Size(350, 22);
            this.labelSet_Daibunrui.SpaceCodeValue = 20;
            this.labelSet_Daibunrui.SpaceNameCode = 40;
            this.labelSet_Daibunrui.SpaceValueAppend = 4;
            this.labelSet_Daibunrui.TabIndex = 0;
            this.labelSet_Daibunrui.ValueLabelSize = 200;
            this.labelSet_Daibunrui.ValueLabelText = "";
            this.labelSet_Daibunrui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(1471, 40);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 5;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnKensakuClick);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(1471, 11);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 7;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // gridTorihiki
            // 
            this.gridTorihiki.AllowUserToAddRows = false;
            this.gridTorihiki.AllowUserToResizeColumns = false;
            this.gridTorihiki.AllowUserToResizeRows = false;
            this.gridTorihiki.AutoGenerateColumns = false;
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
            this.gridTorihiki.Location = new System.Drawing.Point(11, 124);
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
            this.gridTorihiki.Size = new System.Drawing.Size(1560, 513);
            this.gridTorihiki.StandardTab = true;
            this.gridTorihiki.TabIndex = 6;
            this.gridTorihiki.DoubleClick += new System.EventHandler(this.setGridTorihiki_DoubleClick);
            this.gridTorihiki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListGridKeyDown);
            // 
            // txtKensaku
            // 
            this.txtKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensaku.Location = new System.Drawing.Point(106, 96);
            this.txtKensaku.MaxLength = 24;
            this.txtKensaku.Name = "txtKensaku";
            this.txtKensaku.Size = new System.Drawing.Size(200, 22);
            this.txtKensaku.TabIndex = 3;
            this.txtKensaku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            // 
            // lblKensaku
            // 
            this.lblKensaku.AutoSize = true;
            this.lblKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKensaku.Location = new System.Drawing.Point(12, 99);
            this.lblKensaku.Name = "lblKensaku";
            this.lblKensaku.Size = new System.Drawing.Size(87, 15);
            this.lblKensaku.strToolTip = null;
            this.lblKensaku.TabIndex = 100;
            this.lblKensaku.Text = "検索文字列";
            this.lblKensaku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKensakuHuku
            // 
            this.txtKensakuHuku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensakuHuku.Location = new System.Drawing.Point(414, 96);
            this.txtKensakuHuku.MaxLength = 24;
            this.txtKensakuHuku.Name = "txtKensakuHuku";
            this.txtKensakuHuku.Size = new System.Drawing.Size(200, 22);
            this.txtKensakuHuku.TabIndex = 4;
            this.txtKensakuHuku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTokuiListTxtKeyDown);
            // 
            // lblKensakuHuku
            // 
            this.lblKensakuHuku.AutoSize = true;
            this.lblKensakuHuku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKensakuHuku.Location = new System.Drawing.Point(367, 99);
            this.lblKensakuHuku.Name = "lblKensakuHuku";
            this.lblKensakuHuku.Size = new System.Drawing.Size(39, 15);
            this.lblKensakuHuku.strToolTip = null;
            this.lblKensakuHuku.TabIndex = 100;
            this.lblKensakuHuku.Text = "副番";
            this.lblKensakuHuku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ShouhinList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 675);
            this.Controls.Add(this.radSet_2btn_Toroku);
            this.Controls.Add(this.radSet_2btn_Kensaku);
            this.Controls.Add(this.labelSet_Maker);
            this.Controls.Add(this.labelSet_Chubunrui);
            this.Controls.Add(this.labelSet_Daibunrui);
            this.Controls.Add(this.chkNotToroku);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.gridTorihiki);
            this.Controls.Add(this.txtKensakuHuku);
            this.Controls.Add(this.txtKensaku);
            this.Controls.Add(this.lblKensakuHuku);
            this.Controls.Add(this.lblKensaku);
            this.Name = "ShouhinList";
            this.Text = "ShouhinList";
            this.Load += new System.EventHandler(this.ShouhinList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judShouhinListKeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_KeyPress);
            this.radSet_2btn_Toroku.ResumeLayout(false);
            this.radSet_2btn_Toroku.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BaseText txtKensaku;
        private BaseLabel lblKensaku;
        private BaseDataGridView gridTorihiki;
        private System.Windows.Forms.Label lblRecords;
        private BaseButton btnF11;
        private BaseButton btnF12;
        private System.Windows.Forms.CheckBox chkNotToroku;
        private LabelSet_Daibunrui labelSet_Daibunrui;
        private LabelSet_Chubunrui labelSet_Chubunrui;
        private LabelSet_Maker labelSet_Maker;
        private RadSet_2btn radSet_2btn_Kensaku;
        private RadSet_2btn radSet_2btn_Toroku;
        private BaseLabel baseLabel1;
        private BaseLabel lblTitle;
        private BaseText txtKensakuHuku;
        private BaseLabel lblKensakuHuku;
    }
}