﻿namespace KATO.Form.M1220_SyohinBunruiRiekiritsu
{
    partial class M1220_SyohinBunruiRiekiritsu
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
            this.gridRiekiritsu = new KATO.Common.Ctl.BaseDataGridView();
            this.bgSerach = new System.Windows.Forms.GroupBox();
            this.btnSerach = new KATO.Common.Ctl.BaseButton();
            this.labelSet_MakerS = new KATO.Common.Ctl.LabelSet_Maker();
            this.labelSet_ChubunruiS = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.labelSet_DaibunruiS = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.labelSet_TantoushaS = new KATO.Common.Ctl.LabelSet_Tantousha();
            this.labelSet_TokuisakiS = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.bgSort = new System.Windows.Forms.GroupBox();
            this.radSortItem = new KATO.Common.Ctl.RadSet_6btn();
            this.radSortOrder = new KATO.Common.Ctl.RadSet_2btn();
            this.labelSet_Maker = new KATO.Common.Ctl.LabelSet_Maker();
            this.nameLabel = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Chubunrui = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Daibunrui = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Tokuisaki = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.object_a104912b_94e8_4c43_8287_fc0ac5bd51ec = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblRitsu = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtRitsu = new KATO.Common.Ctl.BaseText();
            this.lblKakeritsu = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtKakeritsu = new KATO.Common.Ctl.BaseText();
            this.radSetting = new KATO.Common.Ctl.RadSet_2btn();
            this.lblTitle = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblId = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtId = new KATO.Common.Ctl.BaseText();
            this.lblSerach = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblSort = new KATO.Common.Ctl.BaseLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridRiekiritsu)).BeginInit();
            this.bgSerach.SuspendLayout();
            this.bgSort.SuspendLayout();
            this.labelSet_Maker.SuspendLayout();
            this.labelSet_Chubunrui.SuspendLayout();
            this.labelSet_Daibunrui.SuspendLayout();
            this.labelSet_Tokuisaki.SuspendLayout();
            this.radSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridRiekiritsu
            // 
            this.gridRiekiritsu.AllowUserToAddRows = false;
            this.gridRiekiritsu.AllowUserToResizeColumns = false;
            this.gridRiekiritsu.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRiekiritsu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridRiekiritsu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRiekiritsu.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridRiekiritsu.EnableHeadersVisualStyles = false;
            this.gridRiekiritsu.Location = new System.Drawing.Point(12, 216);
            this.gridRiekiritsu.Name = "gridRiekiritsu";
            this.gridRiekiritsu.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRiekiritsu.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridRiekiritsu.RowHeadersVisible = false;
            this.gridRiekiritsu.RowTemplate.Height = 21;
            this.gridRiekiritsu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRiekiritsu.Size = new System.Drawing.Size(1330, 252);
            this.gridRiekiritsu.StandardTab = true;
            this.gridRiekiritsu.TabIndex = 87;
            this.gridRiekiritsu.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridRiekiritsu_CellMouseClick);
            this.gridRiekiritsu.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridRiekiritsu_CellMouseDoubleClick);
            // 
            // bgSerach
            // 
            this.bgSerach.Controls.Add(this.lblSerach);
            this.bgSerach.Controls.Add(this.btnSerach);
            this.bgSerach.Controls.Add(this.labelSet_MakerS);
            this.bgSerach.Controls.Add(this.labelSet_ChubunruiS);
            this.bgSerach.Controls.Add(this.labelSet_DaibunruiS);
            this.bgSerach.Controls.Add(this.labelSet_TantoushaS);
            this.bgSerach.Controls.Add(this.labelSet_TokuisakiS);
            this.bgSerach.Location = new System.Drawing.Point(30, 22);
            this.bgSerach.Name = "bgSerach";
            this.bgSerach.Size = new System.Drawing.Size(529, 171);
            this.bgSerach.TabIndex = 89;
            this.bgSerach.TabStop = false;
            // 
            // btnSerach
            // 
            this.btnSerach.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnSerach.Location = new System.Drawing.Point(412, 134);
            this.btnSerach.Name = "btnSerach";
            this.btnSerach.Size = new System.Drawing.Size(100, 23);
            this.btnSerach.TabIndex = 105;
            this.btnSerach.Text = "検索";
            this.btnSerach.UseVisualStyleBackColor = true;
            this.btnSerach.Click += new System.EventHandler(this.btnSerach_Click);
            // 
            // labelSet_MakerS
            // 
            this.labelSet_MakerS.AppendLabelSize = 0;
            this.labelSet_MakerS.AppendLabelText = "";
            this.labelSet_MakerS.CodeTxtSize = 40;
            this.labelSet_MakerS.CodeTxtText = "";
            this.labelSet_MakerS.LabelName = "メーカー";
            this.labelSet_MakerS.Location = new System.Drawing.Point(7, 136);
            this.labelSet_MakerS.Name = "labelSet_MakerS";
            this.labelSet_MakerS.ShowAppendFlg = false;
            this.labelSet_MakerS.Size = new System.Drawing.Size(327, 22);
            this.labelSet_MakerS.SpaceCodeValue = 4;
            this.labelSet_MakerS.SpaceNameCode = 4;
            this.labelSet_MakerS.SpaceValueAppend = 4;
            this.labelSet_MakerS.strDaibunCd = null;
            this.labelSet_MakerS.TabIndex = 104;
            this.labelSet_MakerS.ValueLabelSize = 200;
            this.labelSet_MakerS.ValueLabelText = "";
            // 
            // labelSet_ChubunruiS
            // 
            this.labelSet_ChubunruiS.AppendLabelSize = 0;
            this.labelSet_ChubunruiS.AppendLabelText = "";
            this.labelSet_ChubunruiS.CodeTxtSize = 24;
            this.labelSet_ChubunruiS.CodeTxtText = "";
            this.labelSet_ChubunruiS.LabelName = "中分類コード";
            this.labelSet_ChubunruiS.Location = new System.Drawing.Point(7, 108);
            this.labelSet_ChubunruiS.Name = "labelSet_ChubunruiS";
            this.labelSet_ChubunruiS.ShowAppendFlg = false;
            this.labelSet_ChubunruiS.Size = new System.Drawing.Size(348, 22);
            this.labelSet_ChubunruiS.SpaceCodeValue = 4;
            this.labelSet_ChubunruiS.SpaceNameCode = 4;
            this.labelSet_ChubunruiS.SpaceValueAppend = 4;
            this.labelSet_ChubunruiS.strDaibunCd = null;
            this.labelSet_ChubunruiS.TabIndex = 103;
            this.labelSet_ChubunruiS.ValueLabelSize = 200;
            this.labelSet_ChubunruiS.ValueLabelText = "";
            // 
            // labelSet_DaibunruiS
            // 
            this.labelSet_DaibunruiS.AppendLabelSize = 0;
            this.labelSet_DaibunruiS.AppendLabelText = "";
            this.labelSet_DaibunruiS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.labelSet_DaibunruiS.CodeTxtSize = 24;
            this.labelSet_DaibunruiS.CodeTxtText = "";
            this.labelSet_DaibunruiS.LabelName = "大分類コード";
            this.labelSet_DaibunruiS.Location = new System.Drawing.Point(7, 80);
            this.labelSet_DaibunruiS.Lschubundata = null;
            this.labelSet_DaibunruiS.Lsmakerdata = null;
            this.labelSet_DaibunruiS.LsSubchubundata = null;
            this.labelSet_DaibunruiS.LsSubmakerdata = null;
            this.labelSet_DaibunruiS.Name = "labelSet_DaibunruiS";
            this.labelSet_DaibunruiS.ShowAppendFlg = false;
            this.labelSet_DaibunruiS.Size = new System.Drawing.Size(364, 22);
            this.labelSet_DaibunruiS.SpaceCodeValue = 4;
            this.labelSet_DaibunruiS.SpaceNameCode = 4;
            this.labelSet_DaibunruiS.SpaceValueAppend = 4;
            this.labelSet_DaibunruiS.TabIndex = 102;
            this.labelSet_DaibunruiS.ValueLabelSize = 200;
            this.labelSet_DaibunruiS.ValueLabelText = "";
            // 
            // labelSet_TantoushaS
            // 
            this.labelSet_TantoushaS.AppendLabelSize = 0;
            this.labelSet_TantoushaS.AppendLabelText = "";
            this.labelSet_TantoushaS.CodeTxtSize = 40;
            this.labelSet_TantoushaS.CodeTxtText = "";
            this.labelSet_TantoushaS.LabelName = "担当者コード";
            this.labelSet_TantoushaS.Location = new System.Drawing.Point(7, 52);
            this.labelSet_TantoushaS.Name = "labelSet_TantoushaS";
            this.labelSet_TantoushaS.ShowAppendFlg = false;
            this.labelSet_TantoushaS.Size = new System.Drawing.Size(327, 22);
            this.labelSet_TantoushaS.SpaceCodeValue = 4;
            this.labelSet_TantoushaS.SpaceNameCode = 4;
            this.labelSet_TantoushaS.SpaceValueAppend = 4;
            this.labelSet_TantoushaS.TabIndex = 101;
            this.labelSet_TantoushaS.ValueLabelSize = 120;
            this.labelSet_TantoushaS.ValueLabelText = "";
            // 
            // labelSet_TokuisakiS
            // 
            this.labelSet_TokuisakiS.AppendLabelSize = 40;
            this.labelSet_TokuisakiS.AppendLabelText = "";
            this.labelSet_TokuisakiS.CodeTxtSize = 40;
            this.labelSet_TokuisakiS.CodeTxtText = "";
            this.labelSet_TokuisakiS.LabelName = "得意先コード";
            this.labelSet_TokuisakiS.Location = new System.Drawing.Point(7, 23);
            this.labelSet_TokuisakiS.Name = "labelSet_TokuisakiS";
            this.labelSet_TokuisakiS.ShowAppendFlg = false;
            this.labelSet_TokuisakiS.Size = new System.Drawing.Size(504, 22);
            this.labelSet_TokuisakiS.SpaceCodeValue = 4;
            this.labelSet_TokuisakiS.SpaceNameCode = 4;
            this.labelSet_TokuisakiS.SpaceValueAppend = 4;
            this.labelSet_TokuisakiS.TabIndex = 100;
            this.labelSet_TokuisakiS.ValueLabelSize = 350;
            this.labelSet_TokuisakiS.ValueLabelText = "";
            // 
            // bgSort
            // 
            this.bgSort.Controls.Add(this.lblSort);
            this.bgSort.Controls.Add(this.radSortItem);
            this.bgSort.Controls.Add(this.radSortOrder);
            this.bgSort.Location = new System.Drawing.Point(586, 24);
            this.bgSort.Name = "bgSort";
            this.bgSort.Size = new System.Drawing.Size(439, 128);
            this.bgSort.TabIndex = 90;
            this.bgSort.TabStop = false;
            // 
            // radSortItem
            // 
            this.radSortItem.LabelTitle = "";
            this.radSortItem.Location = new System.Drawing.Point(20, 21);
            this.radSortItem.Name = "radSortItem";
            this.radSortItem.PositionLabelTitle_X = 0;
            this.radSortItem.PositionLabelTitle_Y = 0;
            this.radSortItem.PositionRadbtn1_X = 0;
            this.radSortItem.PositionRadbtn1_Y = 0;
            this.radSortItem.PositionRadbtn2_X = 100;
            this.radSortItem.PositionRadbtn2_Y = 0;
            this.radSortItem.PositionRadbtn3_X = 200;
            this.radSortItem.PositionRadbtn3_Y = 0;
            this.radSortItem.PositionRadbtn4_X = 300;
            this.radSortItem.PositionRadbtn4_Y = 0;
            this.radSortItem.PositionRadbtn5_X = 0;
            this.radSortItem.PositionRadbtn5_Y = 20;
            this.radSortItem.PositionRadbtn6_X = 100;
            this.radSortItem.PositionRadbtn6_Y = 20;
            this.radSortItem.Radbtn1Text = "得意先";
            this.radSortItem.Radbtn2Text = "大分類";
            this.radSortItem.Radbtn3Text = "中分類";
            this.radSortItem.Radbtn4Text = "メーカー";
            this.radSortItem.Radbtn5Text = "利益率";
            this.radSortItem.Radbtn6Text = "掛率";
            this.radSortItem.Size = new System.Drawing.Size(398, 55);
            this.radSortItem.TabIndex = 1;
            this.radSortItem.TabStop = false;
            // 
            // radSortOrder
            // 
            this.radSortOrder.LabelTitle = "";
            this.radSortOrder.Location = new System.Drawing.Point(20, 82);
            this.radSortOrder.Name = "radSortOrder";
            this.radSortOrder.PositionLabelTitle_X = 0;
            this.radSortOrder.PositionLabelTitle_Y = 0;
            this.radSortOrder.PositionRadbtn1_X = 0;
            this.radSortOrder.PositionRadbtn1_Y = 0;
            this.radSortOrder.PositionRadbtn2_X = 100;
            this.radSortOrder.PositionRadbtn2_Y = 0;
            this.radSortOrder.Radbtn1Text = "Ａ－Ｚ";
            this.radSortOrder.Radbtn2Text = "Ｚ－Ａ";
            this.radSortOrder.Size = new System.Drawing.Size(201, 28);
            this.radSortOrder.TabIndex = 0;
            this.radSortOrder.TabStop = false;
            // 
            // labelSet_Maker
            // 
            this.labelSet_Maker.AppendLabelSize = 0;
            this.labelSet_Maker.AppendLabelText = "";
            this.labelSet_Maker.CodeTxtSize = 40;
            this.labelSet_Maker.CodeTxtText = "";
            this.labelSet_Maker.Controls.Add(this.nameLabel);
            this.labelSet_Maker.LabelName = "メーカー";
            this.labelSet_Maker.Location = new System.Drawing.Point(40, 566);
            this.labelSet_Maker.Name = "labelSet_Maker";
            this.labelSet_Maker.ShowAppendFlg = false;
            this.labelSet_Maker.Size = new System.Drawing.Size(327, 22);
            this.labelSet_Maker.SpaceCodeValue = 4;
            this.labelSet_Maker.SpaceNameCode = 4;
            this.labelSet_Maker.SpaceValueAppend = 4;
            this.labelSet_Maker.strDaibunCd = null;
            this.labelSet_Maker.TabIndex = 113;
            this.labelSet_Maker.ValueLabelSize = 200;
            this.labelSet_Maker.ValueLabelText = "";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.nameLabel.Location = new System.Drawing.Point(2, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(71, 15);
            this.nameLabel.strToolTip = null;
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "メーカー";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Chubunrui
            // 
            this.labelSet_Chubunrui.AppendLabelSize = 0;
            this.labelSet_Chubunrui.AppendLabelText = "";
            this.labelSet_Chubunrui.CodeTxtSize = 24;
            this.labelSet_Chubunrui.CodeTxtText = "";
            this.labelSet_Chubunrui.Controls.Add(this.object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92);
            this.labelSet_Chubunrui.LabelName = "中分類コード";
            this.labelSet_Chubunrui.Location = new System.Drawing.Point(40, 538);
            this.labelSet_Chubunrui.Name = "labelSet_Chubunrui";
            this.labelSet_Chubunrui.ShowAppendFlg = false;
            this.labelSet_Chubunrui.Size = new System.Drawing.Size(348, 22);
            this.labelSet_Chubunrui.SpaceCodeValue = 4;
            this.labelSet_Chubunrui.SpaceNameCode = 4;
            this.labelSet_Chubunrui.SpaceValueAppend = 4;
            this.labelSet_Chubunrui.strDaibunCd = null;
            this.labelSet_Chubunrui.TabIndex = 112;
            this.labelSet_Chubunrui.ValueLabelSize = 200;
            this.labelSet_Chubunrui.ValueLabelText = "";
            // 
            // object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92
            // 
            this.object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92.AutoSize = true;
            this.object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92.Location = new System.Drawing.Point(2, 3);
            this.object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92.Name = "object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92";
            this.object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92.Size = new System.Drawing.Size(103, 15);
            this.object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92.strToolTip = null;
            this.object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92.TabIndex = 0;
            this.object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92.Text = "中分類コード";
            this.object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Daibunrui
            // 
            this.labelSet_Daibunrui.AppendLabelSize = 0;
            this.labelSet_Daibunrui.AppendLabelText = "";
            this.labelSet_Daibunrui.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.labelSet_Daibunrui.CodeTxtSize = 24;
            this.labelSet_Daibunrui.CodeTxtText = "";
            this.labelSet_Daibunrui.Controls.Add(this.object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601);
            this.labelSet_Daibunrui.LabelName = "大分類コード";
            this.labelSet_Daibunrui.Location = new System.Drawing.Point(40, 510);
            this.labelSet_Daibunrui.Lschubundata = null;
            this.labelSet_Daibunrui.Lsmakerdata = null;
            this.labelSet_Daibunrui.LsSubchubundata = null;
            this.labelSet_Daibunrui.LsSubmakerdata = null;
            this.labelSet_Daibunrui.Name = "labelSet_Daibunrui";
            this.labelSet_Daibunrui.ShowAppendFlg = false;
            this.labelSet_Daibunrui.Size = new System.Drawing.Size(364, 22);
            this.labelSet_Daibunrui.SpaceCodeValue = 4;
            this.labelSet_Daibunrui.SpaceNameCode = 4;
            this.labelSet_Daibunrui.SpaceValueAppend = 4;
            this.labelSet_Daibunrui.TabIndex = 111;
            this.labelSet_Daibunrui.ValueLabelSize = 200;
            this.labelSet_Daibunrui.ValueLabelText = "";
            // 
            // object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601
            // 
            this.object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601.AutoSize = true;
            this.object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601.Location = new System.Drawing.Point(2, 3);
            this.object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601.Name = "object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601";
            this.object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601.Size = new System.Drawing.Size(103, 15);
            this.object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601.strToolTip = null;
            this.object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601.TabIndex = 0;
            this.object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601.Text = "大分類コード";
            this.object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Tokuisaki
            // 
            this.labelSet_Tokuisaki.AppendLabelSize = 40;
            this.labelSet_Tokuisaki.AppendLabelText = "";
            this.labelSet_Tokuisaki.CodeTxtSize = 40;
            this.labelSet_Tokuisaki.CodeTxtText = "";
            this.labelSet_Tokuisaki.Controls.Add(this.object_a104912b_94e8_4c43_8287_fc0ac5bd51ec);
            this.labelSet_Tokuisaki.LabelName = "得意先コード";
            this.labelSet_Tokuisaki.Location = new System.Drawing.Point(40, 482);
            this.labelSet_Tokuisaki.Name = "labelSet_Tokuisaki";
            this.labelSet_Tokuisaki.ShowAppendFlg = false;
            this.labelSet_Tokuisaki.Size = new System.Drawing.Size(504, 22);
            this.labelSet_Tokuisaki.SpaceCodeValue = 4;
            this.labelSet_Tokuisaki.SpaceNameCode = 4;
            this.labelSet_Tokuisaki.SpaceValueAppend = 4;
            this.labelSet_Tokuisaki.TabIndex = 110;
            this.labelSet_Tokuisaki.ValueLabelSize = 350;
            this.labelSet_Tokuisaki.ValueLabelText = "";
            // 
            // object_a104912b_94e8_4c43_8287_fc0ac5bd51ec
            // 
            this.object_a104912b_94e8_4c43_8287_fc0ac5bd51ec.AutoSize = true;
            this.object_a104912b_94e8_4c43_8287_fc0ac5bd51ec.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_a104912b_94e8_4c43_8287_fc0ac5bd51ec.Location = new System.Drawing.Point(2, 3);
            this.object_a104912b_94e8_4c43_8287_fc0ac5bd51ec.Name = "object_a104912b_94e8_4c43_8287_fc0ac5bd51ec";
            this.object_a104912b_94e8_4c43_8287_fc0ac5bd51ec.Size = new System.Drawing.Size(103, 15);
            this.object_a104912b_94e8_4c43_8287_fc0ac5bd51ec.strToolTip = null;
            this.object_a104912b_94e8_4c43_8287_fc0ac5bd51ec.TabIndex = 0;
            this.object_a104912b_94e8_4c43_8287_fc0ac5bd51ec.Text = "得意先コード";
            this.object_a104912b_94e8_4c43_8287_fc0ac5bd51ec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRitsu
            // 
            this.lblRitsu.AutoSize = true;
            this.lblRitsu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblRitsu.Location = new System.Drawing.Point(45, 599);
            this.lblRitsu.Name = "lblRitsu";
            this.lblRitsu.Size = new System.Drawing.Size(79, 15);
            this.lblRitsu.strToolTip = null;
            this.lblRitsu.TabIndex = 96;
            this.lblRitsu.Text = "利益率(%)";
            this.lblRitsu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRitsu
            // 
            this.txtRitsu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtRitsu.Location = new System.Drawing.Point(130, 596);
            this.txtRitsu.MaxLength = 3;
            this.txtRitsu.Name = "txtRitsu";
            this.txtRitsu.Size = new System.Drawing.Size(30, 22);
            this.txtRitsu.TabIndex = 114;
            this.txtRitsu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblKakeritsu
            // 
            this.lblKakeritsu.AutoSize = true;
            this.lblKakeritsu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKakeritsu.Location = new System.Drawing.Point(45, 628);
            this.lblKakeritsu.Name = "lblKakeritsu";
            this.lblKakeritsu.Size = new System.Drawing.Size(63, 15);
            this.lblKakeritsu.strToolTip = null;
            this.lblKakeritsu.TabIndex = 96;
            this.lblKakeritsu.Text = "掛率(%)";
            this.lblKakeritsu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKakeritsu
            // 
            this.txtKakeritsu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKakeritsu.Location = new System.Drawing.Point(130, 625);
            this.txtKakeritsu.MaxLength = 3;
            this.txtKakeritsu.Name = "txtKakeritsu";
            this.txtKakeritsu.Size = new System.Drawing.Size(30, 22);
            this.txtKakeritsu.TabIndex = 115;
            this.txtKakeritsu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radSetting
            // 
            this.radSetting.Controls.Add(this.lblTitle);
            this.radSetting.LabelTitle = "";
            this.radSetting.Location = new System.Drawing.Point(130, 658);
            this.radSetting.Name = "radSetting";
            this.radSetting.PositionLabelTitle_X = 0;
            this.radSetting.PositionLabelTitle_Y = 0;
            this.radSetting.PositionRadbtn1_X = 0;
            this.radSetting.PositionRadbtn1_Y = 0;
            this.radSetting.PositionRadbtn2_X = 100;
            this.radSetting.PositionRadbtn2_Y = 0;
            this.radSetting.Radbtn1Text = "設定";
            this.radSetting.Radbtn2Text = "解除";
            this.radSetting.Size = new System.Drawing.Size(201, 19);
            this.radSetting.TabIndex = 116;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 15);
            this.lblTitle.strToolTip = null;
            this.lblTitle.TabIndex = 6;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblId.Location = new System.Drawing.Point(603, 484);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(23, 15);
            this.lblId.strToolTip = null;
            this.lblId.TabIndex = 96;
            this.lblId.Text = "ID";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtId.Location = new System.Drawing.Point(640, 481);
            this.txtId.MaxLength = 9;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(80, 22);
            this.txtId.TabIndex = 97;
            this.txtId.TabStop = false;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSerach
            // 
            this.lblSerach.AutoSize = true;
            this.lblSerach.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSerach.Location = new System.Drawing.Point(6, 0);
            this.lblSerach.Name = "lblSerach";
            this.lblSerach.Size = new System.Drawing.Size(71, 15);
            this.lblSerach.strToolTip = null;
            this.lblSerach.TabIndex = 106;
            this.lblSerach.Text = "検索条件";
            this.lblSerach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSort.Location = new System.Drawing.Point(6, 0);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(103, 15);
            this.lblSort.strToolTip = null;
            this.lblSort.TabIndex = 106;
            this.lblSort.Text = "並び順の指定";
            this.lblSort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // M1220_SyohinBunruiRiekiritsu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.radSetting);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtKakeritsu);
            this.Controls.Add(this.txtRitsu);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblKakeritsu);
            this.Controls.Add(this.lblRitsu);
            this.Controls.Add(this.labelSet_Maker);
            this.Controls.Add(this.labelSet_Chubunrui);
            this.Controls.Add(this.labelSet_Daibunrui);
            this.Controls.Add(this.labelSet_Tokuisaki);
            this.Controls.Add(this.bgSort);
            this.Controls.Add(this.bgSerach);
            this.Controls.Add(this.gridRiekiritsu);
            this.Name = "M1220_SyohinBunruiRiekiritsu";
            this.Text = "M1220_SyohinBunruiRiekiritsu";
            this.Load += new System.EventHandler(this.M1220_SyohinBunruiRiekiritsu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1220_SyohinBunruiRiekiritsu_KeyDown);
            this.Controls.SetChildIndex(this.gridRiekiritsu, 0);
            this.Controls.SetChildIndex(this.bgSerach, 0);
            this.Controls.SetChildIndex(this.bgSort, 0);
            this.Controls.SetChildIndex(this.labelSet_Tokuisaki, 0);
            this.Controls.SetChildIndex(this.labelSet_Daibunrui, 0);
            this.Controls.SetChildIndex(this.labelSet_Chubunrui, 0);
            this.Controls.SetChildIndex(this.labelSet_Maker, 0);
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
            this.Controls.SetChildIndex(this.lblRitsu, 0);
            this.Controls.SetChildIndex(this.lblKakeritsu, 0);
            this.Controls.SetChildIndex(this.lblId, 0);
            this.Controls.SetChildIndex(this.txtRitsu, 0);
            this.Controls.SetChildIndex(this.txtKakeritsu, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.Controls.SetChildIndex(this.radSetting, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridRiekiritsu)).EndInit();
            this.bgSerach.ResumeLayout(false);
            this.bgSerach.PerformLayout();
            this.bgSort.ResumeLayout(false);
            this.bgSort.PerformLayout();
            this.labelSet_Maker.ResumeLayout(false);
            this.labelSet_Maker.PerformLayout();
            this.labelSet_Chubunrui.ResumeLayout(false);
            this.labelSet_Chubunrui.PerformLayout();
            this.labelSet_Daibunrui.ResumeLayout(false);
            this.labelSet_Daibunrui.PerformLayout();
            this.labelSet_Tokuisaki.ResumeLayout(false);
            this.labelSet_Tokuisaki.PerformLayout();
            this.radSetting.ResumeLayout(false);
            this.radSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseDataGridView gridRiekiritsu;
        private System.Windows.Forms.GroupBox bgSerach;
        private Common.Ctl.LabelSet_Maker labelSet_MakerS;
        private Common.Ctl.LabelSet_Chubunrui labelSet_ChubunruiS;
        private Common.Ctl.LabelSet_Daibunrui labelSet_DaibunruiS;
        private Common.Ctl.LabelSet_Tantousha labelSet_TantoushaS;
        private Common.Ctl.LabelSet_Tokuisaki labelSet_TokuisakiS;
        private System.Windows.Forms.GroupBox bgSort;
        private Common.Ctl.RadSet_2btn radSortOrder;
        private Common.Ctl.BaseButton btnSerach;
        private Common.Ctl.LabelSet_Maker labelSet_Maker;
        private Common.Ctl.BaseLabel nameLabel;
        private Common.Ctl.LabelSet_Chubunrui labelSet_Chubunrui;
        private Common.Ctl.BaseLabel object_2680d006_852d_4dd9_bdcc_dfd1dc8aaa92;
        private Common.Ctl.LabelSet_Daibunrui labelSet_Daibunrui;
        private Common.Ctl.BaseLabel object_78231d7f_9a3f_4c98_a5cb_e04fb41f5601;
        private Common.Ctl.LabelSet_Tokuisaki labelSet_Tokuisaki;
        private Common.Ctl.BaseLabel object_a104912b_94e8_4c43_8287_fc0ac5bd51ec;
        private Common.Ctl.BaseLabel lblRitsu;
        private Common.Ctl.BaseText txtRitsu;
        private Common.Ctl.BaseLabel lblKakeritsu;
        private Common.Ctl.BaseText txtKakeritsu;
        private Common.Ctl.RadSet_2btn radSetting;
        private Common.Ctl.BaseLabel lblTitle;
        private Common.Ctl.BaseLabel lblId;
        private Common.Ctl.BaseText txtId;
        private Common.Ctl.RadSet_6btn radSortItem;
        private Common.Ctl.BaseLabel lblSerach;
        private Common.Ctl.BaseLabel lblSort;
    }
}