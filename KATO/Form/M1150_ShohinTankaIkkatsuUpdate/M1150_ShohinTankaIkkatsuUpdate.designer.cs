using System;

namespace KATO.Form.M1150_ShohinTankaIkkatsuUpdate
{
    partial class M1150_ShohinTankaIkkatsuUpdate
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
            this.labelSet_Daibunrui = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.labelSet_Chubunrui = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.labelSet_Maker = new KATO.Common.Ctl.LabelSet_Maker();
            this.lblTanabanHonsha = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTanabanHonsha = new KATO.Common.Ctl.BaseText();
            this.lblTanabanGifu = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTanabanGifu = new KATO.Common.Ctl.BaseText();
            this.lblKataban = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtKataban = new KATO.Common.Ctl.BaseText();
            this.lblHyojun = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtHyojun = new KATO.Common.Ctl.BaseText();
            this.lblSiire = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtSiire = new KATO.Common.Ctl.BaseText();
            this.lblHyoka = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtHyoka = new KATO.Common.Ctl.BaseText();
            this.lblTatene = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTatene = new KATO.Common.Ctl.BaseText();
            this.bgSort = new System.Windows.Forms.GroupBox();
            this.radSet_2btn = new KATO.Common.Ctl.RadSet_2btn();
            this.lblSort = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblKanri = new KATO.Common.Ctl.BaseLabel(this.components);
            this.btnHyoji = new KATO.Common.Ctl.BaseButton();
            this.btnKeisan = new KATO.Common.Ctl.BaseButton();
            this.lblHyokaKingaku = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblSiireKingaku = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblTateneKingaku = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gridShohin = new KATO.Common.Ctl.BaseDataGridViewEdit();
            this.txtSiireKingaku = new KATO.Common.Ctl.BaseTextMoney();
            this.txtHyokaKingaku = new KATO.Common.Ctl.BaseTextMoney();
            this.txtTateneKingaku = new KATO.Common.Ctl.BaseTextMoney();
            this.bgSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShohin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF12
            // 
            this.btnF12.TabStop = false;
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.TabStop = false;
            this.btnF11.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF10
            // 
            this.btnF10.TabStop = false;
            this.btnF10.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.TabStop = false;
            this.btnF09.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF08
            // 
            this.btnF08.TabStop = false;
            this.btnF08.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF07
            // 
            this.btnF07.TabStop = false;
            this.btnF07.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF06
            // 
            this.btnF06.TabStop = false;
            this.btnF06.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF05
            // 
            this.btnF05.TabStop = false;
            this.btnF05.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.TabStop = false;
            this.btnF03.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF02
            // 
            this.btnF02.TabStop = false;
            this.btnF02.Click += new System.EventHandler(this.judBtnClick);
            // 
            // labelSet_Daibunrui
            // 
            this.labelSet_Daibunrui.AppendLabelSize = 0;
            this.labelSet_Daibunrui.AppendLabelText = "";
            this.labelSet_Daibunrui.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.labelSet_Daibunrui.CodeTxtSize = 24;
            this.labelSet_Daibunrui.CodeTxtText = "";
            this.labelSet_Daibunrui.LabelName = "大分類コード";
            this.labelSet_Daibunrui.Location = new System.Drawing.Point(32, 36);
            this.labelSet_Daibunrui.Lschubundata = null;
            this.labelSet_Daibunrui.Lsmakerdata = null;
            this.labelSet_Daibunrui.LsSubchubundata = null;
            this.labelSet_Daibunrui.LsSubmakerdata = null;
            this.labelSet_Daibunrui.Name = "labelSet_Daibunrui";
            this.labelSet_Daibunrui.ShowAppendFlg = false;
            this.labelSet_Daibunrui.Size = new System.Drawing.Size(351, 22);
            this.labelSet_Daibunrui.SpaceCodeValue = 4;
            this.labelSet_Daibunrui.SpaceNameCode = 4;
            this.labelSet_Daibunrui.SpaceValueAppend = 4;
            this.labelSet_Daibunrui.TabIndex = 1;
            this.labelSet_Daibunrui.ValueLabelSize = 200;
            this.labelSet_Daibunrui.ValueLabelText = "";
            // 
            // labelSet_Chubunrui
            // 
            this.labelSet_Chubunrui.AppendLabelSize = 0;
            this.labelSet_Chubunrui.AppendLabelText = "";
            this.labelSet_Chubunrui.CodeTxtSize = 24;
            this.labelSet_Chubunrui.CodeTxtText = "";
            this.labelSet_Chubunrui.LabelName = "中分類コード";
            this.labelSet_Chubunrui.Location = new System.Drawing.Point(32, 77);
            this.labelSet_Chubunrui.Name = "labelSet_Chubunrui";
            this.labelSet_Chubunrui.ShowAppendFlg = false;
            this.labelSet_Chubunrui.Size = new System.Drawing.Size(339, 22);
            this.labelSet_Chubunrui.SpaceCodeValue = 4;
            this.labelSet_Chubunrui.SpaceNameCode = 4;
            this.labelSet_Chubunrui.SpaceValueAppend = 4;
            this.labelSet_Chubunrui.strDaibunCd = null;
            this.labelSet_Chubunrui.TabIndex = 2;
            this.labelSet_Chubunrui.ValueLabelSize = 200;
            this.labelSet_Chubunrui.ValueLabelText = "";
            // 
            // labelSet_Maker
            // 
            this.labelSet_Maker.AppendLabelSize = 0;
            this.labelSet_Maker.AppendLabelText = "";
            this.labelSet_Maker.CodeTxtSize = 40;
            this.labelSet_Maker.CodeTxtText = "";
            this.labelSet_Maker.LabelName = "メーカー";
            this.labelSet_Maker.Location = new System.Drawing.Point(32, 117);
            this.labelSet_Maker.Name = "labelSet_Maker";
            this.labelSet_Maker.ShowAppendFlg = false;
            this.labelSet_Maker.Size = new System.Drawing.Size(329, 22);
            this.labelSet_Maker.SpaceCodeValue = 4;
            this.labelSet_Maker.SpaceNameCode = 4;
            this.labelSet_Maker.SpaceValueAppend = 4;
            this.labelSet_Maker.strDaibunCd = null;
            this.labelSet_Maker.TabIndex = 3;
            this.labelSet_Maker.ValueLabelSize = 200;
            this.labelSet_Maker.ValueLabelText = "";
            // 
            // lblTanabanHonsha
            // 
            this.lblTanabanHonsha.AutoSize = true;
            this.lblTanabanHonsha.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTanabanHonsha.Location = new System.Drawing.Point(410, 41);
            this.lblTanabanHonsha.Name = "lblTanabanHonsha";
            this.lblTanabanHonsha.Size = new System.Drawing.Size(103, 15);
            this.lblTanabanHonsha.strToolTip = null;
            this.lblTanabanHonsha.TabIndex = 90;
            this.lblTanabanHonsha.Text = "本社棚番検索";
            this.lblTanabanHonsha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTanabanHonsha
            // 
            this.txtTanabanHonsha.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanabanHonsha.Location = new System.Drawing.Point(517, 38);
            this.txtTanabanHonsha.MaxLength = 10;
            this.txtTanabanHonsha.Name = "txtTanabanHonsha";
            this.txtTanabanHonsha.Size = new System.Drawing.Size(100, 22);
            this.txtTanabanHonsha.TabIndex = 4;
            // 
            // lblTanabanGifu
            // 
            this.lblTanabanGifu.AutoSize = true;
            this.lblTanabanGifu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTanabanGifu.Location = new System.Drawing.Point(410, 86);
            this.lblTanabanGifu.Name = "lblTanabanGifu";
            this.lblTanabanGifu.Size = new System.Drawing.Size(103, 15);
            this.lblTanabanGifu.strToolTip = null;
            this.lblTanabanGifu.TabIndex = 90;
            this.lblTanabanGifu.Text = "岐阜棚番検索";
            this.lblTanabanGifu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTanabanGifu
            // 
            this.txtTanabanGifu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanabanGifu.Location = new System.Drawing.Point(517, 82);
            this.txtTanabanGifu.MaxLength = 10;
            this.txtTanabanGifu.Name = "txtTanabanGifu";
            this.txtTanabanGifu.Size = new System.Drawing.Size(100, 22);
            this.txtTanabanGifu.TabIndex = 5;
            // 
            // lblKataban
            // 
            this.lblKataban.AutoSize = true;
            this.lblKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKataban.Location = new System.Drawing.Point(410, 127);
            this.lblKataban.Name = "lblKataban";
            this.lblKataban.Size = new System.Drawing.Size(71, 15);
            this.lblKataban.strToolTip = null;
            this.lblKataban.TabIndex = 90;
            this.lblKataban.Text = "型番検索";
            this.lblKataban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKataban
            // 
            this.txtKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKataban.Location = new System.Drawing.Point(517, 121);
            this.txtKataban.MaxLength = 10;
            this.txtKataban.Name = "txtKataban";
            this.txtKataban.Size = new System.Drawing.Size(100, 22);
            this.txtKataban.TabIndex = 6;
            // 
            // lblHyojun
            // 
            this.lblHyojun.AutoSize = true;
            this.lblHyojun.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHyojun.Location = new System.Drawing.Point(854, 42);
            this.lblHyojun.Name = "lblHyojun";
            this.lblHyojun.Size = new System.Drawing.Size(87, 15);
            this.lblHyojun.strToolTip = null;
            this.lblHyojun.TabIndex = 90;
            this.lblHyojun.Text = "標準売価％";
            this.lblHyojun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHyojun
            // 
            this.txtHyojun.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHyojun.Location = new System.Drawing.Point(948, 38);
            this.txtHyojun.MaxLength = 5;
            this.txtHyojun.Name = "txtHyojun";
            this.txtHyojun.Size = new System.Drawing.Size(50, 22);
            this.txtHyojun.TabIndex = 8;
            this.txtHyojun.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHyojun.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commonTxtKeyPress);
            this.txtHyojun.Leave += new System.EventHandler(this.commonTxtLeave);
            // 
            // lblSiire
            // 
            this.lblSiire.AutoSize = true;
            this.lblSiire.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSiire.Location = new System.Drawing.Point(854, 82);
            this.lblSiire.Name = "lblSiire";
            this.lblSiire.Size = new System.Drawing.Size(87, 15);
            this.lblSiire.strToolTip = null;
            this.lblSiire.TabIndex = 90;
            this.lblSiire.Text = "仕入単価％";
            this.lblSiire.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSiire
            // 
            this.txtSiire.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtSiire.Location = new System.Drawing.Point(948, 79);
            this.txtSiire.MaxLength = 5;
            this.txtSiire.Name = "txtSiire";
            this.txtSiire.Size = new System.Drawing.Size(50, 22);
            this.txtSiire.TabIndex = 9;
            this.txtSiire.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSiire.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commonTxtKeyPress);
            this.txtSiire.Leave += new System.EventHandler(this.commonTxtLeave);
            // 
            // lblHyoka
            // 
            this.lblHyoka.AutoSize = true;
            this.lblHyoka.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHyoka.Location = new System.Drawing.Point(854, 122);
            this.lblHyoka.Name = "lblHyoka";
            this.lblHyoka.Size = new System.Drawing.Size(87, 15);
            this.lblHyoka.strToolTip = null;
            this.lblHyoka.TabIndex = 90;
            this.lblHyoka.Text = "評価単価％";
            this.lblHyoka.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHyoka
            // 
            this.txtHyoka.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHyoka.Location = new System.Drawing.Point(948, 119);
            this.txtHyoka.MaxLength = 5;
            this.txtHyoka.Name = "txtHyoka";
            this.txtHyoka.Size = new System.Drawing.Size(50, 22);
            this.txtHyoka.TabIndex = 10;
            this.txtHyoka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHyoka.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commonTxtKeyPress);
            this.txtHyoka.Leave += new System.EventHandler(this.commonTxtLeave);
            // 
            // lblTatene
            // 
            this.lblTatene.AutoSize = true;
            this.lblTatene.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTatene.Location = new System.Drawing.Point(854, 161);
            this.lblTatene.Name = "lblTatene";
            this.lblTatene.Size = new System.Drawing.Size(87, 15);
            this.lblTatene.strToolTip = null;
            this.lblTatene.TabIndex = 90;
            this.lblTatene.Text = "建値単価％";
            this.lblTatene.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTatene
            // 
            this.txtTatene.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTatene.Location = new System.Drawing.Point(948, 158);
            this.txtTatene.MaxLength = 5;
            this.txtTatene.Name = "txtTatene";
            this.txtTatene.Size = new System.Drawing.Size(50, 22);
            this.txtTatene.TabIndex = 11;
            this.txtTatene.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTatene.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commonTxtKeyPress);
            this.txtTatene.Leave += new System.EventHandler(this.commonTxtLeave);
            // 
            // bgSort
            // 
            this.bgSort.Controls.Add(this.radSet_2btn);
            this.bgSort.Controls.Add(this.lblSort);
            this.bgSort.Location = new System.Drawing.Point(659, 41);
            this.bgSort.Name = "bgSort";
            this.bgSort.Size = new System.Drawing.Size(147, 100);
            this.bgSort.TabIndex = 92;
            this.bgSort.TabStop = false;
            // 
            // radSet_2btn
            // 
            this.radSet_2btn.intJudBtn = 30;
            this.radSet_2btn.LabelTitle = "";
            this.radSet_2btn.Location = new System.Drawing.Point(9, 27);
            this.radSet_2btn.Name = "radSet_2btn";
            this.radSet_2btn.PositionLabelTitle_X = 0;
            this.radSet_2btn.PositionLabelTitle_Y = 0;
            this.radSet_2btn.PositionRadbtn1_X = 0;
            this.radSet_2btn.PositionRadbtn1_Y = 0;
            this.radSet_2btn.PositionRadbtn2_X = 0;
            this.radSet_2btn.PositionRadbtn2_Y = 30;
            this.radSet_2btn.Radbtn1Text = "品名順";
            this.radSet_2btn.Radbtn2Text = "棚番・品名順";
            this.radSet_2btn.Size = new System.Drawing.Size(121, 53);
            this.radSet_2btn.TabIndex = 0;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSort.Location = new System.Drawing.Point(6, 0);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(71, 15);
            this.lblSort.strToolTip = null;
            this.lblSort.TabIndex = 90;
            this.lblSort.Text = "並び替え";
            this.lblSort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKanri
            // 
            this.lblKanri.AutoSize = true;
            this.lblKanri.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKanri.Location = new System.Drawing.Point(1200, 169);
            this.lblKanri.Name = "lblKanri";
            this.lblKanri.Size = new System.Drawing.Size(207, 15);
            this.lblKanri.strToolTip = null;
            this.lblKanri.TabIndex = 90;
            this.lblKanri.Text = "在庫管理　0:する 1:しない";
            this.lblKanri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnHyoji
            // 
            this.btnHyoji.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnHyoji.Location = new System.Drawing.Point(517, 161);
            this.btnHyoji.Name = "btnHyoji";
            this.btnHyoji.Size = new System.Drawing.Size(100, 23);
            this.btnHyoji.TabIndex = 7;
            this.btnHyoji.Text = "一覧表示";
            this.btnHyoji.UseVisualStyleBackColor = true;
            this.btnHyoji.Click += new System.EventHandler(this.btnHyoji_Click);
            // 
            // btnKeisan
            // 
            this.btnKeisan.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnKeisan.Location = new System.Drawing.Point(1071, 157);
            this.btnKeisan.Name = "btnKeisan";
            this.btnKeisan.Size = new System.Drawing.Size(100, 23);
            this.btnKeisan.TabIndex = 12;
            this.btnKeisan.Text = "単価計算";
            this.btnKeisan.UseVisualStyleBackColor = true;
            this.btnKeisan.Click += new System.EventHandler(this.btnKeisan_Click);
            // 
            // lblHyokaKingaku
            // 
            this.lblHyokaKingaku.AutoSize = true;
            this.lblHyokaKingaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHyokaKingaku.Location = new System.Drawing.Point(994, 748);
            this.lblHyokaKingaku.Name = "lblHyokaKingaku";
            this.lblHyokaKingaku.Size = new System.Drawing.Size(71, 15);
            this.lblHyokaKingaku.strToolTip = null;
            this.lblHyokaKingaku.TabIndex = 90;
            this.lblHyokaKingaku.Text = "評価金額";
            this.lblHyokaKingaku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSiireKingaku
            // 
            this.lblSiireKingaku.AutoSize = true;
            this.lblSiireKingaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSiireKingaku.Location = new System.Drawing.Point(789, 748);
            this.lblSiireKingaku.Name = "lblSiireKingaku";
            this.lblSiireKingaku.Size = new System.Drawing.Size(71, 15);
            this.lblSiireKingaku.strToolTip = null;
            this.lblSiireKingaku.TabIndex = 90;
            this.lblSiireKingaku.Text = "仕入金額";
            this.lblSiireKingaku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTateneKingaku
            // 
            this.lblTateneKingaku.AutoSize = true;
            this.lblTateneKingaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTateneKingaku.Location = new System.Drawing.Point(1212, 748);
            this.lblTateneKingaku.Name = "lblTateneKingaku";
            this.lblTateneKingaku.Size = new System.Drawing.Size(71, 15);
            this.lblTateneKingaku.strToolTip = null;
            this.lblTateneKingaku.TabIndex = 90;
            this.lblTateneKingaku.Text = "建値金額";
            this.lblTateneKingaku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridShohin
            // 
            this.gridShohin.AllowUserToAddRows = false;
            this.gridShohin.AllowUserToResizeColumns = false;
            this.gridShohin.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShohin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridShohin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridShohin.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridShohin.EnableHeadersVisualStyles = false;
            this.gridShohin.Location = new System.Drawing.Point(12, 201);
            this.gridShohin.Name = "gridShohin";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShohin.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridShohin.RowHeadersVisible = false;
            this.gridShohin.RowTemplate.Height = 21;
            this.gridShohin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridShohin.Size = new System.Drawing.Size(1395, 528);
            this.gridShohin.TabIndex = 21;
            this.gridShohin.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridShohin_EditingConShow);
            // 
            // txtSiireKingaku
            // 
            this.txtSiireKingaku.blnCommaOK = true;
            this.txtSiireKingaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtSiireKingaku.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSiireKingaku.intDeciSet = 0;
            this.txtSiireKingaku.intIntederSet = 0;
            this.txtSiireKingaku.intShishagonyu = 0;
            this.txtSiireKingaku.Location = new System.Drawing.Point(866, 745);
            this.txtSiireKingaku.MaxLength = 9;
            this.txtSiireKingaku.Name = "txtSiireKingaku";
            this.txtSiireKingaku.Size = new System.Drawing.Size(100, 22);
            this.txtSiireKingaku.TabIndex = 103;
            this.txtSiireKingaku.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHyokaKingaku
            // 
            this.txtHyokaKingaku.blnCommaOK = true;
            this.txtHyokaKingaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHyokaKingaku.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtHyokaKingaku.intDeciSet = 0;
            this.txtHyokaKingaku.intIntederSet = 0;
            this.txtHyokaKingaku.intShishagonyu = 0;
            this.txtHyokaKingaku.Location = new System.Drawing.Point(1071, 744);
            this.txtHyokaKingaku.MaxLength = 9;
            this.txtHyokaKingaku.Name = "txtHyokaKingaku";
            this.txtHyokaKingaku.Size = new System.Drawing.Size(100, 22);
            this.txtHyokaKingaku.TabIndex = 102;
            this.txtHyokaKingaku.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTateneKingaku
            // 
            this.txtTateneKingaku.blnCommaOK = true;
            this.txtTateneKingaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTateneKingaku.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTateneKingaku.intDeciSet = 0;
            this.txtTateneKingaku.intIntederSet = 0;
            this.txtTateneKingaku.intShishagonyu = 0;
            this.txtTateneKingaku.Location = new System.Drawing.Point(1289, 745);
            this.txtTateneKingaku.MaxLength = 9;
            this.txtTateneKingaku.Name = "txtTateneKingaku";
            this.txtTateneKingaku.Size = new System.Drawing.Size(100, 22);
            this.txtTateneKingaku.TabIndex = 101;
            this.txtTateneKingaku.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // M1150_ShohinTankaIkkatsuUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.txtTateneKingaku);
            this.Controls.Add(this.txtHyokaKingaku);
            this.Controls.Add(this.txtSiireKingaku);
            this.Controls.Add(this.gridShohin);
            this.Controls.Add(this.btnKeisan);
            this.Controls.Add(this.btnHyoji);
            this.Controls.Add(this.bgSort);
            this.Controls.Add(this.txtHyoka);
            this.Controls.Add(this.txtKataban);
            this.Controls.Add(this.lblSiireKingaku);
            this.Controls.Add(this.lblTateneKingaku);
            this.Controls.Add(this.lblHyokaKingaku);
            this.Controls.Add(this.lblHyoka);
            this.Controls.Add(this.lblKataban);
            this.Controls.Add(this.txtTatene);
            this.Controls.Add(this.txtSiire);
            this.Controls.Add(this.txtTanabanGifu);
            this.Controls.Add(this.lblKanri);
            this.Controls.Add(this.lblTatene);
            this.Controls.Add(this.lblSiire);
            this.Controls.Add(this.lblTanabanGifu);
            this.Controls.Add(this.txtHyojun);
            this.Controls.Add(this.txtTanabanHonsha);
            this.Controls.Add(this.lblHyojun);
            this.Controls.Add(this.lblTanabanHonsha);
            this.Controls.Add(this.labelSet_Maker);
            this.Controls.Add(this.labelSet_Chubunrui);
            this.Controls.Add(this.labelSet_Daibunrui);
            this.Name = "M1150_ShohinTankaIkkatsuUpdate";
            this.Text = "M1150_ShohinTankaIkkatsuUpdate";
            this.Load += new System.EventHandler(this.M1150_ShohinTankaIkkatsuUpdate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1150_ShohinTankaIkkatsuUpdate_KeyDown);
            this.Controls.SetChildIndex(this.cmbSubWinShow, 0);
            this.Controls.SetChildIndex(this.btnF01, 0);
            this.Controls.SetChildIndex(this.btnF02, 0);
            this.Controls.SetChildIndex(this.btnF03, 0);
            this.Controls.SetChildIndex(this.btnF04, 0);
            this.Controls.SetChildIndex(this.btnF05, 0);
            this.Controls.SetChildIndex(this.btnF06, 0);
            this.Controls.SetChildIndex(this.btnF07, 0);
            this.Controls.SetChildIndex(this.btnF08, 0);
            this.Controls.SetChildIndex(this.btnF09, 0);
            this.Controls.SetChildIndex(this.btnF10, 0);
            this.Controls.SetChildIndex(this.btnF11, 0);
            this.Controls.SetChildIndex(this.btnF12, 0);
            this.Controls.SetChildIndex(this.labelSet_Daibunrui, 0);
            this.Controls.SetChildIndex(this.labelSet_Chubunrui, 0);
            this.Controls.SetChildIndex(this.labelSet_Maker, 0);
            this.Controls.SetChildIndex(this.lblTanabanHonsha, 0);
            this.Controls.SetChildIndex(this.lblHyojun, 0);
            this.Controls.SetChildIndex(this.txtTanabanHonsha, 0);
            this.Controls.SetChildIndex(this.txtHyojun, 0);
            this.Controls.SetChildIndex(this.lblTanabanGifu, 0);
            this.Controls.SetChildIndex(this.lblSiire, 0);
            this.Controls.SetChildIndex(this.lblTatene, 0);
            this.Controls.SetChildIndex(this.lblKanri, 0);
            this.Controls.SetChildIndex(this.txtTanabanGifu, 0);
            this.Controls.SetChildIndex(this.txtSiire, 0);
            this.Controls.SetChildIndex(this.txtTatene, 0);
            this.Controls.SetChildIndex(this.lblKataban, 0);
            this.Controls.SetChildIndex(this.lblHyoka, 0);
            this.Controls.SetChildIndex(this.lblHyokaKingaku, 0);
            this.Controls.SetChildIndex(this.lblTateneKingaku, 0);
            this.Controls.SetChildIndex(this.lblSiireKingaku, 0);
            this.Controls.SetChildIndex(this.txtKataban, 0);
            this.Controls.SetChildIndex(this.txtHyoka, 0);
            this.Controls.SetChildIndex(this.bgSort, 0);
            this.Controls.SetChildIndex(this.btnHyoji, 0);
            this.Controls.SetChildIndex(this.btnKeisan, 0);
            this.Controls.SetChildIndex(this.gridShohin, 0);
            this.Controls.SetChildIndex(this.txtSiireKingaku, 0);
            this.Controls.SetChildIndex(this.txtHyokaKingaku, 0);
            this.Controls.SetChildIndex(this.txtTateneKingaku, 0);
            this.bgSort.ResumeLayout(false);
            this.bgSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShohin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.LabelSet_Daibunrui labelSet_Daibunrui;
        private Common.Ctl.LabelSet_Chubunrui labelSet_Chubunrui;
        private Common.Ctl.LabelSet_Maker labelSet_Maker;
        private Common.Ctl.BaseLabel lblTanabanHonsha;
        private Common.Ctl.BaseText txtTanabanHonsha;
        private Common.Ctl.BaseLabel lblTanabanGifu;
        private Common.Ctl.BaseText txtTanabanGifu;
        private Common.Ctl.BaseLabel lblKataban;
        private Common.Ctl.BaseText txtKataban;
        private Common.Ctl.BaseLabel lblHyojun;
        private Common.Ctl.BaseText txtHyojun;
        private Common.Ctl.BaseLabel lblSiire;
        private Common.Ctl.BaseText txtSiire;
        private Common.Ctl.BaseLabel lblHyoka;
        private Common.Ctl.BaseText txtHyoka;
        private Common.Ctl.BaseLabel lblTatene;
        private Common.Ctl.BaseText txtTatene;
        private System.Windows.Forms.GroupBox bgSort;
        private Common.Ctl.RadSet_2btn radSet_2btn;
        private Common.Ctl.BaseLabel lblSort;
        private Common.Ctl.BaseLabel lblKanri;
        private Common.Ctl.BaseButton btnHyoji;
        private Common.Ctl.BaseButton btnKeisan;
        private Common.Ctl.BaseLabel lblHyokaKingaku;
        private Common.Ctl.BaseLabel lblSiireKingaku;
        private Common.Ctl.BaseLabel lblTateneKingaku;
        private Common.Ctl.BaseDataGridViewEdit gridShohin;
        private Common.Ctl.BaseTextMoney txtSiireKingaku;
        private Common.Ctl.BaseTextMoney txtHyokaKingaku;
        private Common.Ctl.BaseTextMoney txtTateneKingaku;
    }
}