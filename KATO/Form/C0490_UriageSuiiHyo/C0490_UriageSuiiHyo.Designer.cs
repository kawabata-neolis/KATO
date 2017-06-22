namespace KATO.Form.C0490_UriageSuiiHyo
{
    partial class C0490_UriageSuiiHyo
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
            this.lblKikan = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblSpan = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Eigyosho1 = new KATO.Common.Ctl.LabelSet_Eigyosho();
            this.labelSet_GroupCd1 = new KATO.Common.Ctl.LabelSet_GroupCd();
            this.labelSet_Tantousha1 = new KATO.Common.Ctl.LabelSet_Tantousha();
            this.lsJuchusha = new KATO.Common.Ctl.LabelSet_Tantousha();
            this.nameLabel = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Daibunrui1 = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.labelSet_Chubunrui1 = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.labelSet_Maker1 = new KATO.Common.Ctl.LabelSet_Maker();
            this.gridUriageSuii = new KATO.Common.Ctl.BaseDataGridView();
            this.txtCalendarYMopen = new KATO.Common.Ctl.BaseCalendarYM();
            this.txtCalendarYMclose = new KATO.Common.Ctl.BaseCalendarYM();
            this.labelSet_TokuisakiStart = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.labelSet_TokuisakiEnd = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.object_dd63fa84_f17e_4d86_9efe_89770990b04e = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lsJuchusha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUriageSuii)).BeginInit();
            this.labelSet_TokuisakiEnd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnF12
            // 
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // lblKikan
            // 
            this.lblKikan.AutoSize = true;
            this.lblKikan.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKikan.Location = new System.Drawing.Point(24, 20);
            this.lblKikan.Name = "lblKikan";
            this.lblKikan.Size = new System.Drawing.Size(39, 15);
            this.lblKikan.strToolTip = null;
            this.lblKikan.TabIndex = 0;
            this.lblKikan.Text = "期間";
            this.lblKikan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpan
            // 
            this.lblSpan.AutoSize = true;
            this.lblSpan.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSpan.Location = new System.Drawing.Point(225, 20);
            this.lblSpan.Name = "lblSpan";
            this.lblSpan.Size = new System.Drawing.Size(23, 15);
            this.lblSpan.strToolTip = null;
            this.lblSpan.TabIndex = 89;
            this.lblSpan.Text = "～";
            this.lblSpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Eigyosho1
            // 
            this.labelSet_Eigyosho1.AppendLabelSize = 0;
            this.labelSet_Eigyosho1.AppendLabelText = "";
            this.labelSet_Eigyosho1.CodeTxtSize = 40;
            this.labelSet_Eigyosho1.CodeTxtText = "";
            this.labelSet_Eigyosho1.LabelName = "営業所コード";
            this.labelSet_Eigyosho1.Location = new System.Drawing.Point(359, 17);
            this.labelSet_Eigyosho1.Name = "labelSet_Eigyosho1";
            this.labelSet_Eigyosho1.ShowAppendFlg = false;
            this.labelSet_Eigyosho1.Size = new System.Drawing.Size(286, 22);
            this.labelSet_Eigyosho1.SpaceCodeValue = 4;
            this.labelSet_Eigyosho1.SpaceNameCode = 4;
            this.labelSet_Eigyosho1.SpaceValueAppend = 4;
            this.labelSet_Eigyosho1.TabIndex = 5;
            this.labelSet_Eigyosho1.ValueLabelSize = 250;
            this.labelSet_Eigyosho1.ValueLabelText = "";
            // 
            // labelSet_GroupCd1
            // 
            this.labelSet_GroupCd1.AppendLabelSize = 0;
            this.labelSet_GroupCd1.AppendLabelText = "";
            this.labelSet_GroupCd1.CodeTxtSize = 40;
            this.labelSet_GroupCd1.CodeTxtText = "";
            this.labelSet_GroupCd1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.labelSet_GroupCd1.LabelName = "グループコード";
            this.labelSet_GroupCd1.Location = new System.Drawing.Point(679, 18);
            this.labelSet_GroupCd1.LsGroupCddata = null;
            this.labelSet_GroupCd1.Name = "labelSet_GroupCd1";
            this.labelSet_GroupCd1.ShowAppendFlg = false;
            this.labelSet_GroupCd1.Size = new System.Drawing.Size(291, 22);
            this.labelSet_GroupCd1.SpaceCodeValue = 4;
            this.labelSet_GroupCd1.SpaceNameCode = 4;
            this.labelSet_GroupCd1.SpaceValueAppend = 4;
            this.labelSet_GroupCd1.TabIndex = 8;
            this.labelSet_GroupCd1.ValueLabelSize = 120;
            this.labelSet_GroupCd1.ValueLabelText = "";
            // 
            // labelSet_Tantousha1
            // 
            this.labelSet_Tantousha1.AppendLabelSize = 0;
            this.labelSet_Tantousha1.AppendLabelText = "";
            this.labelSet_Tantousha1.CodeTxtSize = 40;
            this.labelSet_Tantousha1.CodeTxtText = "";
            this.labelSet_Tantousha1.LabelName = "担当者コード";
            this.labelSet_Tantousha1.Location = new System.Drawing.Point(359, 54);
            this.labelSet_Tantousha1.Name = "labelSet_Tantousha1";
            this.labelSet_Tantousha1.ShowAppendFlg = false;
            this.labelSet_Tantousha1.Size = new System.Drawing.Size(273, 22);
            this.labelSet_Tantousha1.SpaceCodeValue = 4;
            this.labelSet_Tantousha1.SpaceNameCode = 4;
            this.labelSet_Tantousha1.SpaceValueAppend = 4;
            this.labelSet_Tantousha1.TabIndex = 6;
            this.labelSet_Tantousha1.ValueLabelSize = 120;
            this.labelSet_Tantousha1.ValueLabelText = "";
            // 
            // lsJuchusha
            // 
            this.lsJuchusha.AppendLabelSize = 0;
            this.lsJuchusha.AppendLabelText = "";
            this.lsJuchusha.CodeTxtSize = 39;
            this.lsJuchusha.CodeTxtText = "";
            this.lsJuchusha.Controls.Add(this.nameLabel);
            this.lsJuchusha.Controls.Add(this.baseLabel1);
            this.lsJuchusha.LabelName = "受注者";
            this.lsJuchusha.Location = new System.Drawing.Point(679, 54);
            this.lsJuchusha.Name = "lsJuchusha";
            this.lsJuchusha.ShowAppendFlg = false;
            this.lsJuchusha.Size = new System.Drawing.Size(255, 22);
            this.lsJuchusha.SpaceCodeValue = 4;
            this.lsJuchusha.SpaceNameCode = 4;
            this.lsJuchusha.SpaceValueAppend = 4;
            this.lsJuchusha.TabIndex = 9;
            this.lsJuchusha.ValueLabelSize = 150;
            this.lsJuchusha.ValueLabelText = "";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.nameLabel.Location = new System.Drawing.Point(2, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(55, 15);
            this.nameLabel.strToolTip = null;
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "受注者";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(2, 3);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(55, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 0;
            this.baseLabel1.Text = "発注者";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Daibunrui1
            // 
            this.labelSet_Daibunrui1.AppendLabelSize = 0;
            this.labelSet_Daibunrui1.AppendLabelText = "";
            this.labelSet_Daibunrui1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.labelSet_Daibunrui1.CodeTxtSize = 24;
            this.labelSet_Daibunrui1.CodeTxtText = "";
            this.labelSet_Daibunrui1.LabelName = "大分類コード";
            this.labelSet_Daibunrui1.Location = new System.Drawing.Point(13, 82);
            this.labelSet_Daibunrui1.Lschubundata = null;
            this.labelSet_Daibunrui1.LsSubchubundata = null;
            this.labelSet_Daibunrui1.Name = "labelSet_Daibunrui1";
            this.labelSet_Daibunrui1.ShowAppendFlg = false;
            this.labelSet_Daibunrui1.Size = new System.Drawing.Size(277, 22);
            this.labelSet_Daibunrui1.SpaceCodeValue = 4;
            this.labelSet_Daibunrui1.SpaceNameCode = 4;
            this.labelSet_Daibunrui1.SpaceValueAppend = 4;
            this.labelSet_Daibunrui1.TabIndex = 4;
            this.labelSet_Daibunrui1.ValueLabelSize = 200;
            this.labelSet_Daibunrui1.ValueLabelText = "";
            // 
            // labelSet_Chubunrui1
            // 
            this.labelSet_Chubunrui1.AppendLabelSize = 0;
            this.labelSet_Chubunrui1.AppendLabelText = "";
            this.labelSet_Chubunrui1.CodeTxtSize = 24;
            this.labelSet_Chubunrui1.CodeTxtText = "";
            this.labelSet_Chubunrui1.LabelName = "中分類コード";
            this.labelSet_Chubunrui1.Location = new System.Drawing.Point(359, 82);
            this.labelSet_Chubunrui1.Name = "labelSet_Chubunrui1";
            this.labelSet_Chubunrui1.ShowAppendFlg = false;
            this.labelSet_Chubunrui1.Size = new System.Drawing.Size(273, 22);
            this.labelSet_Chubunrui1.SpaceCodeValue = 4;
            this.labelSet_Chubunrui1.SpaceNameCode = 4;
            this.labelSet_Chubunrui1.SpaceValueAppend = 4;
            this.labelSet_Chubunrui1.strDaibunCd = null;
            this.labelSet_Chubunrui1.TabIndex = 7;
            this.labelSet_Chubunrui1.ValueLabelSize = 200;
            this.labelSet_Chubunrui1.ValueLabelText = "";
            // 
            // labelSet_Maker1
            // 
            this.labelSet_Maker1.AppendLabelSize = 0;
            this.labelSet_Maker1.AppendLabelText = "";
            this.labelSet_Maker1.CodeTxtSize = 30;
            this.labelSet_Maker1.CodeTxtText = "";
            this.labelSet_Maker1.LabelName = "メーカー";
            this.labelSet_Maker1.Location = new System.Drawing.Point(679, 82);
            this.labelSet_Maker1.Name = "labelSet_Maker1";
            this.labelSet_Maker1.ShowAppendFlg = false;
            this.labelSet_Maker1.Size = new System.Drawing.Size(250, 22);
            this.labelSet_Maker1.SpaceCodeValue = 4;
            this.labelSet_Maker1.SpaceNameCode = 4;
            this.labelSet_Maker1.SpaceValueAppend = 4;
            this.labelSet_Maker1.TabIndex = 10;
            this.labelSet_Maker1.ValueLabelSize = 200;
            this.labelSet_Maker1.ValueLabelText = "";
            // 
            // gridUriageSuii
            // 
            this.gridUriageSuii.AllowUserToAddRows = false;
            this.gridUriageSuii.AllowUserToDeleteRows = false;
            this.gridUriageSuii.AllowUserToResizeColumns = false;
            this.gridUriageSuii.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUriageSuii.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridUriageSuii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridUriageSuii.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridUriageSuii.EnableHeadersVisualStyles = false;
            this.gridUriageSuii.Location = new System.Drawing.Point(16, 124);
            this.gridUriageSuii.MultiSelect = false;
            this.gridUriageSuii.Name = "gridUriageSuii";
            this.gridUriageSuii.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUriageSuii.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridUriageSuii.RowHeadersVisible = false;
            this.gridUriageSuii.RowTemplate.Height = 21;
            this.gridUriageSuii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUriageSuii.Size = new System.Drawing.Size(1408, 539);
            this.gridUriageSuii.StandardTab = true;
            this.gridUriageSuii.TabIndex = 129;
            this.gridUriageSuii.TabStop = false;
            this.gridUriageSuii.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridUriageSuii_CellMouseDoubleClick);
            // 
            // txtCalendarYMopen
            // 
            this.txtCalendarYMopen.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtCalendarYMopen.Location = new System.Drawing.Point(119, 17);
            this.txtCalendarYMopen.MaxLength = 7;
            this.txtCalendarYMopen.Name = "txtCalendarYMopen";
            this.txtCalendarYMopen.Size = new System.Drawing.Size(100, 22);
            this.txtCalendarYMopen.TabIndex = 0;
            this.txtCalendarYMopen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCalendarYMopen.Leave += new System.EventHandler(this.txtCalendarYMopen_Leave);
            // 
            // txtCalendarYMclose
            // 
            this.txtCalendarYMclose.BackColor = System.Drawing.SystemColors.Window;
            this.txtCalendarYMclose.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtCalendarYMclose.Location = new System.Drawing.Point(254, 17);
            this.txtCalendarYMclose.Name = "txtCalendarYMclose";
            this.txtCalendarYMclose.ReadOnly = true;
            this.txtCalendarYMclose.Size = new System.Drawing.Size(96, 22);
            this.txtCalendarYMclose.TabIndex = 1;
            this.txtCalendarYMclose.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelSet_TokuisakiStart
            // 
            this.labelSet_TokuisakiStart.AppendLabelSize = 40;
            this.labelSet_TokuisakiStart.AppendLabelText = "";
            this.labelSet_TokuisakiStart.CodeTxtSize = 40;
            this.labelSet_TokuisakiStart.CodeTxtText = "";
            this.labelSet_TokuisakiStart.LabelName = "得意先コード";
            this.labelSet_TokuisakiStart.Location = new System.Drawing.Point(16, 54);
            this.labelSet_TokuisakiStart.Name = "labelSet_TokuisakiStart";
            this.labelSet_TokuisakiStart.ShowAppendFlg = true;
            this.labelSet_TokuisakiStart.Size = new System.Drawing.Size(148, 22);
            this.labelSet_TokuisakiStart.SpaceCodeValue = 4;
            this.labelSet_TokuisakiStart.SpaceNameCode = 4;
            this.labelSet_TokuisakiStart.SpaceValueAppend = 0;
            this.labelSet_TokuisakiStart.TabIndex = 2;
            this.labelSet_TokuisakiStart.ValueLabelSize = 0;
            this.labelSet_TokuisakiStart.ValueLabelText = "";
            // 
            // labelSet_TokuisakiEnd
            // 
            this.labelSet_TokuisakiEnd.AppendLabelSize = 40;
            this.labelSet_TokuisakiEnd.AppendLabelText = "";
            this.labelSet_TokuisakiEnd.CodeTxtSize = 40;
            this.labelSet_TokuisakiEnd.CodeTxtText = "";
            this.labelSet_TokuisakiEnd.Controls.Add(this.baseLabel2);
            this.labelSet_TokuisakiEnd.Controls.Add(this.object_dd63fa84_f17e_4d86_9efe_89770990b04e);
            this.labelSet_TokuisakiEnd.LabelName = "～";
            this.labelSet_TokuisakiEnd.Location = new System.Drawing.Point(175, 54);
            this.labelSet_TokuisakiEnd.Name = "labelSet_TokuisakiEnd";
            this.labelSet_TokuisakiEnd.ShowAppendFlg = true;
            this.labelSet_TokuisakiEnd.Size = new System.Drawing.Size(73, 22);
            this.labelSet_TokuisakiEnd.SpaceCodeValue = 4;
            this.labelSet_TokuisakiEnd.SpaceNameCode = 8;
            this.labelSet_TokuisakiEnd.SpaceValueAppend = 0;
            this.labelSet_TokuisakiEnd.TabIndex = 3;
            this.labelSet_TokuisakiEnd.ValueLabelSize = 0;
            this.labelSet_TokuisakiEnd.ValueLabelText = "";
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(2, 3);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(23, 15);
            this.baseLabel2.strToolTip = null;
            this.baseLabel2.TabIndex = 0;
            this.baseLabel2.Text = "～";
            this.baseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // object_dd63fa84_f17e_4d86_9efe_89770990b04e
            // 
            this.object_dd63fa84_f17e_4d86_9efe_89770990b04e.AutoSize = true;
            this.object_dd63fa84_f17e_4d86_9efe_89770990b04e.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_dd63fa84_f17e_4d86_9efe_89770990b04e.Location = new System.Drawing.Point(2, 3);
            this.object_dd63fa84_f17e_4d86_9efe_89770990b04e.Name = "object_dd63fa84_f17e_4d86_9efe_89770990b04e";
            this.object_dd63fa84_f17e_4d86_9efe_89770990b04e.Size = new System.Drawing.Size(0, 15);
            this.object_dd63fa84_f17e_4d86_9efe_89770990b04e.strToolTip = null;
            this.object_dd63fa84_f17e_4d86_9efe_89770990b04e.TabIndex = 0;
            this.object_dd63fa84_f17e_4d86_9efe_89770990b04e.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // C0490_UriageSuiiHyo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 758);
            this.Controls.Add(this.labelSet_TokuisakiEnd);
            this.Controls.Add(this.labelSet_TokuisakiStart);
            this.Controls.Add(this.txtCalendarYMclose);
            this.Controls.Add(this.txtCalendarYMopen);
            this.Controls.Add(this.gridUriageSuii);
            this.Controls.Add(this.labelSet_Maker1);
            this.Controls.Add(this.labelSet_Chubunrui1);
            this.Controls.Add(this.labelSet_Daibunrui1);
            this.Controls.Add(this.lsJuchusha);
            this.Controls.Add(this.labelSet_Tantousha1);
            this.Controls.Add(this.labelSet_GroupCd1);
            this.Controls.Add(this.labelSet_Eigyosho1);
            this.Controls.Add(this.lblSpan);
            this.Controls.Add(this.lblKikan);
            this.Name = "C0490_UriageSuiiHyo";
            this.Text = "C0490_UriageSuiiHyo";
            this.Load += new System.EventHandler(this.C0490_UriageSuiiHyo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.C0490_UriageSuiiHyo_KeyDown);
            this.Controls.SetChildIndex(this.lblKikan, 0);
            this.Controls.SetChildIndex(this.lblSpan, 0);
            this.Controls.SetChildIndex(this.labelSet_Eigyosho1, 0);
            this.Controls.SetChildIndex(this.labelSet_GroupCd1, 0);
            this.Controls.SetChildIndex(this.labelSet_Tantousha1, 0);
            this.Controls.SetChildIndex(this.lsJuchusha, 0);
            this.Controls.SetChildIndex(this.labelSet_Daibunrui1, 0);
            this.Controls.SetChildIndex(this.labelSet_Chubunrui1, 0);
            this.Controls.SetChildIndex(this.labelSet_Maker1, 0);
            this.Controls.SetChildIndex(this.gridUriageSuii, 0);
            this.Controls.SetChildIndex(this.txtCalendarYMopen, 0);
            this.Controls.SetChildIndex(this.txtCalendarYMclose, 0);
            this.Controls.SetChildIndex(this.labelSet_TokuisakiStart, 0);
            this.Controls.SetChildIndex(this.labelSet_TokuisakiEnd, 0);
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
            this.lsJuchusha.ResumeLayout(false);
            this.lsJuchusha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUriageSuii)).EndInit();
            this.labelSet_TokuisakiEnd.ResumeLayout(false);
            this.labelSet_TokuisakiEnd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseLabel lblKikan;
        private Common.Ctl.BaseLabel lblSpan;
        private Common.Ctl.LabelSet_Eigyosho labelSet_Eigyosho1;
        private Common.Ctl.LabelSet_GroupCd labelSet_GroupCd1;
        private Common.Ctl.LabelSet_Tantousha labelSet_Tantousha1;
        private Common.Ctl.LabelSet_Tantousha lsJuchusha;
        private Common.Ctl.BaseLabel nameLabel;
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.LabelSet_Daibunrui labelSet_Daibunrui1;
        private Common.Ctl.LabelSet_Chubunrui labelSet_Chubunrui1;
        private Common.Ctl.LabelSet_Maker labelSet_Maker1;
        private Common.Ctl.BaseDataGridView gridUriageSuii;
        private Common.Ctl.BaseCalendarYM txtCalendarYMopen;
        private Common.Ctl.BaseCalendarYM txtCalendarYMclose;
        private Common.Ctl.LabelSet_Tokuisaki labelSet_TokuisakiStart;
        private Common.Ctl.LabelSet_Tokuisaki labelSet_TokuisakiEnd;
        private Common.Ctl.BaseLabel baseLabel2;
        private Common.Ctl.BaseLabel object_dd63fa84_f17e_4d86_9efe_89770990b04e;
    }
}