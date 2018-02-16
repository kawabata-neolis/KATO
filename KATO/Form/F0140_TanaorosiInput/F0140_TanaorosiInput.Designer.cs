using KATO.Common;
using KATO.Common.Ctl;

namespace KATO.Form.F0140_TanaorosiInput
{
    partial class F0140_TanaorosiInput
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
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gridRireki = new KATO.Common.Ctl.BaseDataGridView();
            this.radBase3 = new KATO.Common.Ctl.BaseRadioButton();
            this.radBase2 = new KATO.Common.Ctl.BaseRadioButton();
            this.radBase1 = new KATO.Common.Ctl.BaseRadioButton();
            this.radBase4 = new KATO.Common.Ctl.BaseRadioButton();
            this.btnViewGrid = new KATO.Common.Ctl.BaseButton();
            this.lblRecords = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Chubunrui_Edit = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.labelSet_Tanaban_Edit = new KATO.Common.Ctl.LabelSet_Tanaban();
            this.labelSet_Maker_Edit = new KATO.Common.Ctl.LabelSet_Maker();
            this.lblDspShouhin = new KATO.Common.Ctl.BaseLabelGray();
            this.txtTyoubosuu = new KATO.Common.Ctl.BaseText();
            this.txtTanasuu = new KATO.Common.Ctl.BaseText();
            this.txtKensaku = new KATO.Common.Ctl.BaseText();
            this.lblHinmei = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblTyoubosuu = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblTanasuu = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblKensaku = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtShouhinCD = new KATO.Common.Ctl.BaseText();
            this.txtbaseLabel7 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtYMD = new KATO.Common.Ctl.BaseCalendar();
            this.labelSet_Daibunrui = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.labelSet_Chubunrui = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.labelSet_Eigyousho = new KATO.Common.Ctl.LabelSet_Eigyosho();
            this.labelSet_Maker = new KATO.Common.Ctl.LabelSet_Maker();
            this.labelSet_Tanaban = new KATO.Common.Ctl.LabelSet_Tanaban();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.lblBox1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblNewInput = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblSelectOutPut = new KATO.Common.Ctl.BaseLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridRireki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.TabIndex = 11;
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
            // 
            // btnF10
            // 
            this.btnF10.TabStop = false;
            // 
            // btnF09
            // 
            this.btnF09.TabStop = false;
            // 
            // btnF08
            // 
            this.btnF08.TabStop = false;
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
            this.btnF05.TabIndex = 13;
            this.btnF05.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.TabIndex = 12;
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
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(15, 40);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(87, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 90;
            this.baseLabel1.Text = "棚卸年月日";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridRireki
            // 
            this.gridRireki.AllowUserToAddRows = false;
            this.gridRireki.AllowUserToResizeColumns = false;
            this.gridRireki.AllowUserToResizeRows = false;
            this.gridRireki.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRireki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridRireki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRireki.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridRireki.EnableHeadersVisualStyles = false;
            this.gridRireki.Location = new System.Drawing.Point(332, 35);
            this.gridRireki.Name = "gridRireki";
            this.gridRireki.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRireki.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridRireki.RowHeadersVisible = false;
            this.gridRireki.RowTemplate.Height = 21;
            this.gridRireki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRireki.Size = new System.Drawing.Size(1080, 631);
            this.gridRireki.StandardTab = true;
            this.gridRireki.TabIndex = 7;
            this.gridRireki.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.setGridSeihinDbl);
            this.gridRireki.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.judGridCellChanged);
            this.gridRireki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judRirekiKeyDown);
            // 
            // radBase3
            // 
            this.radBase3.AutoSize = true;
            this.radBase3.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.radBase3.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.radBase3.FocusedBackColor = System.Drawing.SystemColors.Control;
            this.radBase3.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.radBase3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.radBase3.Location = new System.Drawing.Point(24, 318);
            this.radBase3.Name = "radBase3";
            this.radBase3.Size = new System.Drawing.Size(233, 19);
            this.radBase3.TabIndex = 16;
            this.radBase3.TabStop = true;
            this.radBase3.Text = "棚番・メーカー・品名の昇順";
            this.radBase3.UseVisualStyleBackColor = true;
            // 
            // radBase2
            // 
            this.radBase2.AutoSize = true;
            this.radBase2.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.radBase2.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.radBase2.FocusedBackColor = System.Drawing.SystemColors.Control;
            this.radBase2.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.radBase2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.radBase2.Location = new System.Drawing.Point(24, 291);
            this.radBase2.Name = "radBase2";
            this.radBase2.Size = new System.Drawing.Size(185, 19);
            this.radBase2.TabIndex = 15;
            this.radBase2.TabStop = true;
            this.radBase2.Text = "メーカー・品名の昇順";
            this.radBase2.UseVisualStyleBackColor = true;
            // 
            // radBase1
            // 
            this.radBase1.AutoSize = true;
            this.radBase1.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.radBase1.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.radBase1.FocusedBackColor = System.Drawing.SystemColors.Control;
            this.radBase1.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.radBase1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.radBase1.Location = new System.Drawing.Point(24, 264);
            this.radBase1.Name = "radBase1";
            this.radBase1.Size = new System.Drawing.Size(105, 19);
            this.radBase1.TabIndex = 14;
            this.radBase1.TabStop = true;
            this.radBase1.Text = "品名の昇順";
            this.radBase1.UseVisualStyleBackColor = true;
            // 
            // radBase4
            // 
            this.radBase4.AutoSize = true;
            this.radBase4.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.radBase4.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.radBase4.FocusedBackColor = System.Drawing.SystemColors.Control;
            this.radBase4.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.radBase4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.radBase4.Location = new System.Drawing.Point(24, 345);
            this.radBase4.Name = "radBase4";
            this.radBase4.Size = new System.Drawing.Size(153, 19);
            this.radBase4.TabIndex = 17;
            this.radBase4.TabStop = true;
            this.radBase4.Text = "棚番・品名の昇順";
            this.radBase4.UseVisualStyleBackColor = true;
            // 
            // btnViewGrid
            // 
            this.btnViewGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnViewGrid.Location = new System.Drawing.Point(32, 405);
            this.btnViewGrid.Name = "btnViewGrid";
            this.btnViewGrid.Size = new System.Drawing.Size(100, 23);
            this.btnViewGrid.TabIndex = 6;
            this.btnViewGrid.Text = "検索表示";
            this.btnViewGrid.UseVisualStyleBackColor = true;
            this.btnViewGrid.Click += new System.EventHandler(this.btnView);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblRecords.Location = new System.Drawing.Point(138, 409);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(87, 15);
            this.lblRecords.strToolTip = null;
            this.lblRecords.TabIndex = 94;
            this.lblRecords.Text = "該当件数：";
            this.lblRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Chubunrui_Edit
            // 
            this.labelSet_Chubunrui_Edit.AppendLabelSize = 0;
            this.labelSet_Chubunrui_Edit.AppendLabelText = "";
            this.labelSet_Chubunrui_Edit.CodeTxtSize = 33;
            this.labelSet_Chubunrui_Edit.CodeTxtText = "";
            this.labelSet_Chubunrui_Edit.LabelName = "中分類コード";
            this.labelSet_Chubunrui_Edit.Location = new System.Drawing.Point(594, 692);
            this.labelSet_Chubunrui_Edit.Name = "labelSet_Chubunrui_Edit";
            this.labelSet_Chubunrui_Edit.ShowAppendFlg = false;
            this.labelSet_Chubunrui_Edit.Size = new System.Drawing.Size(340, 23);
            this.labelSet_Chubunrui_Edit.SpaceCodeValue = 4;
            this.labelSet_Chubunrui_Edit.SpaceNameCode = 4;
            this.labelSet_Chubunrui_Edit.SpaceValueAppend = 4;
            this.labelSet_Chubunrui_Edit.strDaibunCd = null;
            this.labelSet_Chubunrui_Edit.TabIndex = 18;
            this.labelSet_Chubunrui_Edit.ValueLabelSize = 150;
            this.labelSet_Chubunrui_Edit.ValueLabelText = "";
            // 
            // labelSet_Tanaban_Edit
            // 
            this.labelSet_Tanaban_Edit.AppendLabelSize = 0;
            this.labelSet_Tanaban_Edit.AppendLabelText = "";
            this.labelSet_Tanaban_Edit.CodeTxtSize = 70;
            this.labelSet_Tanaban_Edit.CodeTxtText = "";
            this.labelSet_Tanaban_Edit.LabelName = "棚番";
            this.labelSet_Tanaban_Edit.Location = new System.Drawing.Point(1070, 720);
            this.labelSet_Tanaban_Edit.Name = "labelSet_Tanaban_Edit";
            this.labelSet_Tanaban_Edit.ShowAppendFlg = false;
            this.labelSet_Tanaban_Edit.Size = new System.Drawing.Size(251, 23);
            this.labelSet_Tanaban_Edit.SpaceCodeValue = 4;
            this.labelSet_Tanaban_Edit.SpaceNameCode = 36;
            this.labelSet_Tanaban_Edit.SpaceValueAppend = 4;
            this.labelSet_Tanaban_Edit.TabIndex = 10;
            this.labelSet_Tanaban_Edit.ValueLabelSize = 151;
            this.labelSet_Tanaban_Edit.ValueLabelText = "";
            // 
            // labelSet_Maker_Edit
            // 
            this.labelSet_Maker_Edit.AppendLabelSize = 0;
            this.labelSet_Maker_Edit.AppendLabelText = "";
            this.labelSet_Maker_Edit.CodeTxtSize = 40;
            this.labelSet_Maker_Edit.CodeTxtText = "";
            this.labelSet_Maker_Edit.LabelName = "メーカー";
            this.labelSet_Maker_Edit.Location = new System.Drawing.Point(1070, 692);
            this.labelSet_Maker_Edit.Name = "labelSet_Maker_Edit";
            this.labelSet_Maker_Edit.ShowAppendFlg = false;
            this.labelSet_Maker_Edit.Size = new System.Drawing.Size(251, 23);
            this.labelSet_Maker_Edit.SpaceCodeValue = 4;
            this.labelSet_Maker_Edit.SpaceNameCode = 4;
            this.labelSet_Maker_Edit.SpaceValueAppend = 4;
            this.labelSet_Maker_Edit.strDaibunCd = null;
            this.labelSet_Maker_Edit.TabIndex = 19;
            this.labelSet_Maker_Edit.ValueLabelSize = 150;
            this.labelSet_Maker_Edit.ValueLabelText = "";
            // 
            // lblDspShouhin
            // 
            this.lblDspShouhin.AutoEllipsis = true;
            this.lblDspShouhin.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDspShouhin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDspShouhin.ForeColor = System.Drawing.Color.Blue;
            this.lblDspShouhin.Location = new System.Drawing.Point(131, 720);
            this.lblDspShouhin.Name = "lblDspShouhin";
            this.lblDspShouhin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDspShouhin.Size = new System.Drawing.Size(341, 23);
            this.lblDspShouhin.TabIndex = 96;
            this.lblDspShouhin.Text = " ";
            this.lblDspShouhin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTyoubosuu
            // 
            this.txtTyoubosuu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTyoubosuu.Location = new System.Drawing.Point(701, 749);
            this.txtTyoubosuu.Name = "txtTyoubosuu";
            this.txtTyoubosuu.Size = new System.Drawing.Size(163, 22);
            this.txtTyoubosuu.TabIndex = 1;
            this.txtTyoubosuu.TabStop = false;
            // 
            // txtTanasuu
            // 
            this.txtTanasuu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanasuu.Location = new System.Drawing.Point(701, 721);
            this.txtTanasuu.Name = "txtTanasuu";
            this.txtTanasuu.Size = new System.Drawing.Size(163, 22);
            this.txtTanasuu.TabIndex = 9;
            this.txtTanasuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTanaTxtKeyDown);
            // 
            // txtKensaku
            // 
            this.txtKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensaku.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtKensaku.Location = new System.Drawing.Point(130, 692);
            this.txtKensaku.Name = "txtKensaku";
            this.txtKensaku.Size = new System.Drawing.Size(186, 22);
            this.txtKensaku.TabIndex = 8;
            this.txtKensaku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTanaTxtKeyDown);
            this.txtKensaku.Leave += new System.EventHandler(this.updTxtKensakuLeave);
            // 
            // lblHinmei
            // 
            this.lblHinmei.AutoSize = true;
            this.lblHinmei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHinmei.Location = new System.Drawing.Point(29, 724);
            this.lblHinmei.Name = "lblHinmei";
            this.lblHinmei.Size = new System.Drawing.Size(87, 15);
            this.lblHinmei.strToolTip = null;
            this.lblHinmei.TabIndex = 0;
            this.lblHinmei.Text = "品名・型番";
            this.lblHinmei.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTyoubosuu
            // 
            this.lblTyoubosuu.AutoSize = true;
            this.lblTyoubosuu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTyoubosuu.Location = new System.Drawing.Point(597, 752);
            this.lblTyoubosuu.Name = "lblTyoubosuu";
            this.lblTyoubosuu.Size = new System.Drawing.Size(87, 15);
            this.lblTyoubosuu.strToolTip = null;
            this.lblTyoubosuu.TabIndex = 0;
            this.lblTyoubosuu.Text = "帳簿在庫数";
            this.lblTyoubosuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTanasuu
            // 
            this.lblTanasuu.AutoSize = true;
            this.lblTanasuu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTanasuu.Location = new System.Drawing.Point(597, 724);
            this.lblTanasuu.Name = "lblTanasuu";
            this.lblTanasuu.Size = new System.Drawing.Size(55, 15);
            this.lblTanasuu.strToolTip = null;
            this.lblTanasuu.TabIndex = 0;
            this.lblTanasuu.Text = "棚卸数";
            this.lblTanasuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKensaku
            // 
            this.lblKensaku.AutoSize = true;
            this.lblKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKensaku.Location = new System.Drawing.Point(29, 695);
            this.lblKensaku.Name = "lblKensaku";
            this.lblKensaku.Size = new System.Drawing.Size(87, 15);
            this.lblKensaku.strToolTip = null;
            this.lblKensaku.TabIndex = 0;
            this.lblKensaku.Text = "検索文字列";
            this.lblKensaku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtShouhinCD
            // 
            this.txtShouhinCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShouhinCD.Location = new System.Drawing.Point(123, 510);
            this.txtShouhinCD.Name = "txtShouhinCD";
            this.txtShouhinCD.Size = new System.Drawing.Size(81, 22);
            this.txtShouhinCD.TabIndex = 1;
            this.txtShouhinCD.Visible = false;
            this.txtShouhinCD.Leave += new System.EventHandler(this.updTxtKensakuLeave);
            // 
            // txtbaseLabel7
            // 
            this.txtbaseLabel7.AutoSize = true;
            this.txtbaseLabel7.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtbaseLabel7.Location = new System.Drawing.Point(34, 513);
            this.txtbaseLabel7.Name = "txtbaseLabel7";
            this.txtbaseLabel7.Size = new System.Drawing.Size(87, 15);
            this.txtbaseLabel7.strToolTip = null;
            this.txtbaseLabel7.TabIndex = 94;
            this.txtbaseLabel7.Text = "商品コード";
            this.txtbaseLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtbaseLabel7.Visible = false;
            // 
            // txtYMD
            // 
            this.txtYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYMD.Location = new System.Drawing.Point(120, 37);
            this.txtYMD.Name = "txtYMD";
            this.txtYMD.Size = new System.Drawing.Size(96, 22);
            this.txtYMD.TabIndex = 97;
            this.txtYMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelSet_Daibunrui
            // 
            this.labelSet_Daibunrui.AppendLabelSize = 0;
            this.labelSet_Daibunrui.AppendLabelText = "";
            this.labelSet_Daibunrui.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.labelSet_Daibunrui.CodeTxtSize = 33;
            this.labelSet_Daibunrui.CodeTxtText = "";
            this.labelSet_Daibunrui.LabelName = "大分類コード";
            this.labelSet_Daibunrui.Location = new System.Drawing.Point(12, 95);
            this.labelSet_Daibunrui.Lschubundata = null;
            this.labelSet_Daibunrui.Lsmakerdata = null;
            this.labelSet_Daibunrui.LsSubchubundata = null;
            this.labelSet_Daibunrui.LsSubmakerdata = null;
            this.labelSet_Daibunrui.Name = "labelSet_Daibunrui";
            this.labelSet_Daibunrui.ShowAppendFlg = false;
            this.labelSet_Daibunrui.Size = new System.Drawing.Size(314, 22);
            this.labelSet_Daibunrui.SpaceCodeValue = 10;
            this.labelSet_Daibunrui.SpaceNameCode = 4;
            this.labelSet_Daibunrui.SpaceValueAppend = 4;
            this.labelSet_Daibunrui.TabIndex = 1;
            this.labelSet_Daibunrui.ValueLabelSize = 150;
            this.labelSet_Daibunrui.ValueLabelText = "";
            // 
            // labelSet_Chubunrui
            // 
            this.labelSet_Chubunrui.AppendLabelSize = 0;
            this.labelSet_Chubunrui.AppendLabelText = "";
            this.labelSet_Chubunrui.CodeTxtSize = 33;
            this.labelSet_Chubunrui.CodeTxtText = "";
            this.labelSet_Chubunrui.LabelName = "中分類コード";
            this.labelSet_Chubunrui.Location = new System.Drawing.Point(12, 123);
            this.labelSet_Chubunrui.Name = "labelSet_Chubunrui";
            this.labelSet_Chubunrui.ShowAppendFlg = false;
            this.labelSet_Chubunrui.Size = new System.Drawing.Size(316, 22);
            this.labelSet_Chubunrui.SpaceCodeValue = 10;
            this.labelSet_Chubunrui.SpaceNameCode = 4;
            this.labelSet_Chubunrui.SpaceValueAppend = 4;
            this.labelSet_Chubunrui.strDaibunCd = null;
            this.labelSet_Chubunrui.TabIndex = 2;
            this.labelSet_Chubunrui.ValueLabelSize = 150;
            this.labelSet_Chubunrui.ValueLabelText = "";
            // 
            // labelSet_Eigyousho
            // 
            this.labelSet_Eigyousho.AppendLabelSize = 0;
            this.labelSet_Eigyousho.AppendLabelText = "";
            this.labelSet_Eigyousho.CodeTxtSize = 53;
            this.labelSet_Eigyousho.CodeTxtText = "";
            this.labelSet_Eigyousho.LabelName = "営業所コード";
            this.labelSet_Eigyousho.Location = new System.Drawing.Point(12, 67);
            this.labelSet_Eigyousho.Name = "labelSet_Eigyousho";
            this.labelSet_Eigyousho.ShowAppendFlg = false;
            this.labelSet_Eigyousho.Size = new System.Drawing.Size(316, 22);
            this.labelSet_Eigyousho.SpaceCodeValue = 10;
            this.labelSet_Eigyousho.SpaceNameCode = 4;
            this.labelSet_Eigyousho.SpaceValueAppend = 4;
            this.labelSet_Eigyousho.TabIndex = 0;
            this.labelSet_Eigyousho.ValueLabelSize = 130;
            this.labelSet_Eigyousho.ValueLabelText = "";
            // 
            // labelSet_Maker
            // 
            this.labelSet_Maker.AppendLabelSize = 0;
            this.labelSet_Maker.AppendLabelText = "";
            this.labelSet_Maker.CodeTxtSize = 43;
            this.labelSet_Maker.CodeTxtText = "";
            this.labelSet_Maker.LabelName = "メーカー";
            this.labelSet_Maker.Location = new System.Drawing.Point(12, 151);
            this.labelSet_Maker.Name = "labelSet_Maker";
            this.labelSet_Maker.ShowAppendFlg = false;
            this.labelSet_Maker.Size = new System.Drawing.Size(316, 22);
            this.labelSet_Maker.SpaceCodeValue = 10;
            this.labelSet_Maker.SpaceNameCode = 36;
            this.labelSet_Maker.SpaceValueAppend = 4;
            this.labelSet_Maker.strDaibunCd = null;
            this.labelSet_Maker.TabIndex = 3;
            this.labelSet_Maker.ValueLabelSize = 140;
            this.labelSet_Maker.ValueLabelText = "";
            // 
            // labelSet_Tanaban
            // 
            this.labelSet_Tanaban.AppendLabelSize = 0;
            this.labelSet_Tanaban.AppendLabelText = "";
            this.labelSet_Tanaban.CodeTxtSize = 63;
            this.labelSet_Tanaban.CodeTxtText = "";
            this.labelSet_Tanaban.LabelName = "棚番";
            this.labelSet_Tanaban.Location = new System.Drawing.Point(12, 179);
            this.labelSet_Tanaban.Name = "labelSet_Tanaban";
            this.labelSet_Tanaban.ShowAppendFlg = false;
            this.labelSet_Tanaban.Size = new System.Drawing.Size(316, 22);
            this.labelSet_Tanaban.SpaceCodeValue = 10;
            this.labelSet_Tanaban.SpaceNameCode = 68;
            this.labelSet_Tanaban.SpaceValueAppend = 4;
            this.labelSet_Tanaban.TabIndex = 4;
            this.labelSet_Tanaban.ValueLabelSize = 120;
            this.labelSet_Tanaban.ValueLabelText = "";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // lblBox1
            // 
            this.lblBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBox1.Location = new System.Drawing.Point(12, 677);
            this.lblBox1.Name = "lblBox1";
            this.lblBox1.Size = new System.Drawing.Size(1400, 100);
            this.lblBox1.strToolTip = null;
            this.lblBox1.TabIndex = 100;
            this.lblBox1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNewInput
            // 
            this.lblNewInput.AutoSize = true;
            this.lblNewInput.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNewInput.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblNewInput.Location = new System.Drawing.Point(21, 671);
            this.lblNewInput.Name = "lblNewInput";
            this.lblNewInput.Size = new System.Drawing.Size(87, 15);
            this.lblNewInput.strToolTip = null;
            this.lblNewInput.TabIndex = 101;
            this.lblNewInput.Text = "新規に入力";
            this.lblNewInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baseLabel2
            // 
            this.baseLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.baseLabel2.Location = new System.Drawing.Point(12, 237);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(278, 152);
            this.baseLabel2.strToolTip = null;
            this.baseLabel2.TabIndex = 100;
            this.baseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectOutPut
            // 
            this.lblSelectOutPut.AutoSize = true;
            this.lblSelectOutPut.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSelectOutPut.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSelectOutPut.Location = new System.Drawing.Point(21, 232);
            this.lblSelectOutPut.Name = "lblSelectOutPut";
            this.lblSelectOutPut.Size = new System.Drawing.Size(103, 15);
            this.lblSelectOutPut.strToolTip = null;
            this.lblSelectOutPut.TabIndex = 101;
            this.lblSelectOutPut.Text = "出力順の選択";
            this.lblSelectOutPut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // F0140_TanaorosiInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 828);
            this.Controls.Add(this.radBase3);
            this.Controls.Add(this.lblSelectOutPut);
            this.Controls.Add(this.lblNewInput);
            this.Controls.Add(this.radBase2);
            this.Controls.Add(this.labelSet_Chubunrui_Edit);
            this.Controls.Add(this.radBase1);
            this.Controls.Add(this.radBase4);
            this.Controls.Add(this.labelSet_Tanaban);
            this.Controls.Add(this.labelSet_Tanaban_Edit);
            this.Controls.Add(this.labelSet_Maker);
            this.Controls.Add(this.labelSet_Maker_Edit);
            this.Controls.Add(this.lblDspShouhin);
            this.Controls.Add(this.labelSet_Eigyousho);
            this.Controls.Add(this.txtTyoubosuu);
            this.Controls.Add(this.labelSet_Chubunrui);
            this.Controls.Add(this.txtTanasuu);
            this.Controls.Add(this.labelSet_Daibunrui);
            this.Controls.Add(this.txtKensaku);
            this.Controls.Add(this.txtYMD);
            this.Controls.Add(this.lblHinmei);
            this.Controls.Add(this.lblTyoubosuu);
            this.Controls.Add(this.txtbaseLabel7);
            this.Controls.Add(this.lblTanasuu);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.lblKensaku);
            this.Controls.Add(this.btnViewGrid);
            this.Controls.Add(this.gridRireki);
            this.Controls.Add(this.txtShouhinCD);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.lblBox1);
            this.Name = "F0140_TanaorosiInput";
            this.Text = "F0140_TanaorosiInput";
            this.Load += new System.EventHandler(this.TanaorosiInput_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTanaorosiKeyDown);
            this.Controls.SetChildIndex(this.lblBox1, 0);
            this.Controls.SetChildIndex(this.baseLabel2, 0);
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
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.txtShouhinCD, 0);
            this.Controls.SetChildIndex(this.gridRireki, 0);
            this.Controls.SetChildIndex(this.btnViewGrid, 0);
            this.Controls.SetChildIndex(this.lblKensaku, 0);
            this.Controls.SetChildIndex(this.lblRecords, 0);
            this.Controls.SetChildIndex(this.lblTanasuu, 0);
            this.Controls.SetChildIndex(this.txtbaseLabel7, 0);
            this.Controls.SetChildIndex(this.lblTyoubosuu, 0);
            this.Controls.SetChildIndex(this.lblHinmei, 0);
            this.Controls.SetChildIndex(this.txtYMD, 0);
            this.Controls.SetChildIndex(this.txtKensaku, 0);
            this.Controls.SetChildIndex(this.labelSet_Daibunrui, 0);
            this.Controls.SetChildIndex(this.txtTanasuu, 0);
            this.Controls.SetChildIndex(this.labelSet_Chubunrui, 0);
            this.Controls.SetChildIndex(this.txtTyoubosuu, 0);
            this.Controls.SetChildIndex(this.labelSet_Eigyousho, 0);
            this.Controls.SetChildIndex(this.lblDspShouhin, 0);
            this.Controls.SetChildIndex(this.labelSet_Maker_Edit, 0);
            this.Controls.SetChildIndex(this.labelSet_Maker, 0);
            this.Controls.SetChildIndex(this.labelSet_Tanaban_Edit, 0);
            this.Controls.SetChildIndex(this.labelSet_Tanaban, 0);
            this.Controls.SetChildIndex(this.radBase4, 0);
            this.Controls.SetChildIndex(this.radBase1, 0);
            this.Controls.SetChildIndex(this.labelSet_Chubunrui_Edit, 0);
            this.Controls.SetChildIndex(this.radBase2, 0);
            this.Controls.SetChildIndex(this.lblNewInput, 0);
            this.Controls.SetChildIndex(this.lblSelectOutPut, 0);
            this.Controls.SetChildIndex(this.radBase3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridRireki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BaseLabel baseLabel1;
        private BaseDataGridView gridRireki;
        private BaseButton btnViewGrid;
        private BaseLabel lblRecords;
        private BaseText txtKensaku;
        private BaseLabel lblHinmei;
        private BaseLabel lblKensaku;
        private BaseLabelGray lblDspShouhin;
        private BaseLabel lblTyoubosuu;
        private BaseLabel lblTanasuu;
        private BaseText txtTyoubosuu;
        private BaseText txtTanasuu;
        private BaseText txtShouhinCD;
        private BaseLabel txtbaseLabel7;
        private BaseCalendar txtYMD;
        private BaseRadioButton radBase3;
        private BaseRadioButton radBase2;
        private BaseRadioButton radBase1;
        private BaseRadioButton radBase4;
        private LabelSet_Daibunrui labelSet_Daibunrui;
        private LabelSet_Chubunrui labelSet_Chubunrui;
        private LabelSet_Eigyosho labelSet_Eigyousho;
        private LabelSet_Maker labelSet_Maker;
        private LabelSet_Tanaban labelSet_Tanaban;
        private LabelSet_Chubunrui labelSet_Chubunrui_Edit;
        private LabelSet_Tanaban labelSet_Tanaban_Edit;
        private LabelSet_Maker labelSet_Maker_Edit;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private BaseLabel lblBox1;
        private BaseLabel lblSelectOutPut;
        private BaseLabel lblNewInput;
        private BaseLabel baseLabel2;
    }
}