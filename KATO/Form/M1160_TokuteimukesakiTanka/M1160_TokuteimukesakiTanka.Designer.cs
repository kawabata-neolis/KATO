namespace KATO.Form.M1160_TokuteimukesakiTanka
{
    partial class M1160_TokuteimukesakiTanka
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
            this.txtKensakuS = new KATO.Common.Ctl.BaseText();
            this.txtKataban = new KATO.Common.Ctl.BaseText();
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTanka = new KATO.Common.Ctl.BaseTextMoney();
            this.baseLabel4 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblShohinCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtShohinCd = new KATO.Common.Ctl.BaseText();
            this.gridTokuteimukesakiTanka = new KATO.Common.Ctl.BaseDataGridView();
            this.labelSet_Tokuisaki = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.labelSet_Siiresaki = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.labelSet_Daibunrui1 = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.labelSet_Chubunrui1 = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.labelSet_Maker1 = new KATO.Common.Ctl.LabelSet_Maker();
            ((System.ComponentModel.ISupportInitialize)(this.gridTokuteimukesakiTanka)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.TabIndex = 4;
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF12
            // 
            this.btnF12.TabIndex = 10;
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.TabIndex = 9;
            this.btnF11.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF10
            // 
            this.btnF10.TabStop = false;
            this.btnF10.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.TabIndex = 8;
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
            this.btnF06.TabIndex = 7;
            this.btnF06.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF05
            // 
            this.btnF05.TabStop = false;
            this.btnF05.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.TabIndex = 6;
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.TabIndex = 5;
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
            this.baseLabel1.Location = new System.Drawing.Point(151, 134);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(71, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 39;
            this.baseLabel1.Text = "検索文字";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKensakuS
            // 
            this.txtKensakuS.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensakuS.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKensakuS.Location = new System.Drawing.Point(256, 127);
            this.txtKensakuS.MaxLength = 40;
            this.txtKensakuS.Name = "txtKensakuS";
            this.txtKensakuS.Size = new System.Drawing.Size(297, 22);
            this.txtKensakuS.TabIndex = 1;
            this.txtKensakuS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKensakuS_KeyDown);
            // 
            // txtKataban
            // 
            this.txtKataban.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKataban.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtKataban.Location = new System.Drawing.Point(256, 155);
            this.txtKataban.MaxLength = 100;
            this.txtKataban.Name = "txtKataban";
            this.txtKataban.ReadOnly = true;
            this.txtKataban.Size = new System.Drawing.Size(415, 22);
            this.txtKataban.TabIndex = 101;
            this.txtKataban.TabStop = false;
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(151, 158);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(39, 15);
            this.baseLabel2.strToolTip = null;
            this.baseLabel2.TabIndex = 100;
            this.baseLabel2.Text = "型番";
            this.baseLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTanka
            // 
            this.txtTanka.blnCommaOK = true;
            this.txtTanka.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanka.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTanka.intDeciSet = 2;
            this.txtTanka.intIntederSet = 0;
            this.txtTanka.intShishagonyu = 0;
            this.txtTanka.Location = new System.Drawing.Point(256, 183);
            this.txtTanka.MaxLength = 10;
            this.txtTanka.MinusFlg = true;
            this.txtTanka.Name = "txtTanka";
            this.txtTanka.Size = new System.Drawing.Size(100, 22);
            this.txtTanka.TabIndex = 2;
            this.txtTanka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTanka.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTanka_KeyDown);
            // 
            // baseLabel4
            // 
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel4.Location = new System.Drawing.Point(151, 186);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(39, 15);
            this.baseLabel4.strToolTip = null;
            this.baseLabel4.TabIndex = 107;
            this.baseLabel4.Text = "単価";
            this.baseLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShohinCd
            // 
            this.lblShohinCd.AutoSize = true;
            this.lblShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblShohinCd.Location = new System.Drawing.Point(684, 158);
            this.lblShohinCd.Name = "lblShohinCd";
            this.lblShohinCd.Size = new System.Drawing.Size(87, 15);
            this.lblShohinCd.strToolTip = null;
            this.lblShohinCd.TabIndex = 111;
            this.lblShohinCd.Text = "商品コード";
            this.lblShohinCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShohinCd.Visible = false;
            // 
            // txtShohinCd
            // 
            this.txtShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShohinCd.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtShohinCd.Location = new System.Drawing.Point(777, 155);
            this.txtShohinCd.MaxLength = 5;
            this.txtShohinCd.Name = "txtShohinCd";
            this.txtShohinCd.Size = new System.Drawing.Size(119, 22);
            this.txtShohinCd.TabIndex = 110;
            this.txtShohinCd.Visible = false;
            this.txtShohinCd.Leave += new System.EventHandler(this.txtShohinCd_Leave);
            // 
            // gridTokuteimukesakiTanka
            // 
            this.gridTokuteimukesakiTanka.AllowUserToAddRows = false;
            this.gridTokuteimukesakiTanka.AllowUserToResizeColumns = false;
            this.gridTokuteimukesakiTanka.AllowUserToResizeRows = false;
            this.gridTokuteimukesakiTanka.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokuteimukesakiTanka.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTokuteimukesakiTanka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTokuteimukesakiTanka.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridTokuteimukesakiTanka.EnableHeadersVisualStyles = false;
            this.gridTokuteimukesakiTanka.Location = new System.Drawing.Point(104, 209);
            this.gridTokuteimukesakiTanka.Name = "gridTokuteimukesakiTanka";
            this.gridTokuteimukesakiTanka.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokuteimukesakiTanka.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTokuteimukesakiTanka.RowHeadersVisible = false;
            this.gridTokuteimukesakiTanka.RowTemplate.Height = 21;
            this.gridTokuteimukesakiTanka.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTokuteimukesakiTanka.Size = new System.Drawing.Size(1131, 541);
            this.gridTokuteimukesakiTanka.StandardTab = true;
            this.gridTokuteimukesakiTanka.TabIndex = 3;
            this.gridTokuteimukesakiTanka.TabStop = false;
            this.gridTokuteimukesakiTanka.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTokuteimukesakiTanka_CellDoubleClick);
            this.gridTokuteimukesakiTanka.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridTokuteimukesakiTanka_KeyDown);
            // 
            // labelSet_Tokuisaki
            // 
            this.labelSet_Tokuisaki.AppendLabelSize = 0;
            this.labelSet_Tokuisaki.AppendLabelText = "";
            this.labelSet_Tokuisaki.CodeTxtSize = 40;
            this.labelSet_Tokuisaki.CodeTxtText = "";
            this.labelSet_Tokuisaki.LabelName = "得意先コード";
            this.labelSet_Tokuisaki.Location = new System.Drawing.Point(149, 15);
            this.labelSet_Tokuisaki.Name = "labelSet_Tokuisaki";
            this.labelSet_Tokuisaki.ShowAppendFlg = false;
            this.labelSet_Tokuisaki.Size = new System.Drawing.Size(452, 22);
            this.labelSet_Tokuisaki.SpaceCodeValue = 4;
            this.labelSet_Tokuisaki.SpaceNameCode = 4;
            this.labelSet_Tokuisaki.SpaceValueAppend = 4;
            this.labelSet_Tokuisaki.TabIndex = 0;
            this.labelSet_Tokuisaki.ValueLabelSize = 300;
            this.labelSet_Tokuisaki.ValueLabelText = "";
            this.labelSet_Tokuisaki.Leave += new System.EventHandler(this.labelSet_Tokuisaki_Leave);
            // 
            // labelSet_Siiresaki
            // 
            this.labelSet_Siiresaki.AppendLabelSize = 0;
            this.labelSet_Siiresaki.AppendLabelText = "";
            this.labelSet_Siiresaki.CodeTxtSize = 40;
            this.labelSet_Siiresaki.CodeTxtText = "";
            this.labelSet_Siiresaki.LabelName = "仕入先コード";
            this.labelSet_Siiresaki.Location = new System.Drawing.Point(679, 15);
            this.labelSet_Siiresaki.Name = "labelSet_Siiresaki";
            this.labelSet_Siiresaki.ShowAppendFlg = false;
            this.labelSet_Siiresaki.Size = new System.Drawing.Size(453, 22);
            this.labelSet_Siiresaki.SpaceCodeValue = 4;
            this.labelSet_Siiresaki.SpaceNameCode = 4;
            this.labelSet_Siiresaki.SpaceValueAppend = 4;
            this.labelSet_Siiresaki.TabIndex = 114;
            this.labelSet_Siiresaki.ValueLabelSize = 300;
            this.labelSet_Siiresaki.ValueLabelText = "";
            this.labelSet_Siiresaki.Visible = false;
            // 
            // labelSet_Daibunrui1
            // 
            this.labelSet_Daibunrui1.AppendLabelSize = 0;
            this.labelSet_Daibunrui1.AppendLabelText = "";
            this.labelSet_Daibunrui1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.labelSet_Daibunrui1.CodeTxtSize = 24;
            this.labelSet_Daibunrui1.CodeTxtText = "";
            this.labelSet_Daibunrui1.LabelName = "大分類コード";
            this.labelSet_Daibunrui1.Location = new System.Drawing.Point(149, 43);
            this.labelSet_Daibunrui1.Lschubundata = null;
            this.labelSet_Daibunrui1.Lsmakerdata = null;
            this.labelSet_Daibunrui1.LsSubchubundata = null;
            this.labelSet_Daibunrui1.LsSubmakerdata = null;
            this.labelSet_Daibunrui1.Name = "labelSet_Daibunrui1";
            this.labelSet_Daibunrui1.ShowAppendFlg = false;
            this.labelSet_Daibunrui1.Size = new System.Drawing.Size(543, 22);
            this.labelSet_Daibunrui1.SpaceCodeValue = 20;
            this.labelSet_Daibunrui1.SpaceNameCode = 4;
            this.labelSet_Daibunrui1.SpaceValueAppend = 4;
            this.labelSet_Daibunrui1.TabIndex = 115;
            this.labelSet_Daibunrui1.ValueLabelSize = 300;
            this.labelSet_Daibunrui1.ValueLabelText = "";
            this.labelSet_Daibunrui1.Visible = false;
            // 
            // labelSet_Chubunrui1
            // 
            this.labelSet_Chubunrui1.AppendLabelSize = 0;
            this.labelSet_Chubunrui1.AppendLabelText = "";
            this.labelSet_Chubunrui1.CodeTxtSize = 24;
            this.labelSet_Chubunrui1.CodeTxtText = "";
            this.labelSet_Chubunrui1.LabelName = "中分類コード";
            this.labelSet_Chubunrui1.Location = new System.Drawing.Point(149, 71);
            this.labelSet_Chubunrui1.Name = "labelSet_Chubunrui1";
            this.labelSet_Chubunrui1.ShowAppendFlg = false;
            this.labelSet_Chubunrui1.Size = new System.Drawing.Size(474, 22);
            this.labelSet_Chubunrui1.SpaceCodeValue = 20;
            this.labelSet_Chubunrui1.SpaceNameCode = 4;
            this.labelSet_Chubunrui1.SpaceValueAppend = 4;
            this.labelSet_Chubunrui1.strDaibunCd = null;
            this.labelSet_Chubunrui1.TabIndex = 116;
            this.labelSet_Chubunrui1.ValueLabelSize = 300;
            this.labelSet_Chubunrui1.ValueLabelText = "";
            this.labelSet_Chubunrui1.Visible = false;
            // 
            // labelSet_Maker1
            // 
            this.labelSet_Maker1.AppendLabelSize = 0;
            this.labelSet_Maker1.AppendLabelText = "";
            this.labelSet_Maker1.CodeTxtSize = 40;
            this.labelSet_Maker1.CodeTxtText = "";
            this.labelSet_Maker1.LabelName = "メーカー";
            this.labelSet_Maker1.Location = new System.Drawing.Point(149, 99);
            this.labelSet_Maker1.Name = "labelSet_Maker1";
            this.labelSet_Maker1.ShowAppendFlg = false;
            this.labelSet_Maker1.Size = new System.Drawing.Size(453, 22);
            this.labelSet_Maker1.SpaceCodeValue = 4;
            this.labelSet_Maker1.SpaceNameCode = 36;
            this.labelSet_Maker1.SpaceValueAppend = 4;
            this.labelSet_Maker1.strDaibunCd = null;
            this.labelSet_Maker1.TabIndex = 117;
            this.labelSet_Maker1.ValueLabelSize = 300;
            this.labelSet_Maker1.ValueLabelText = "";
            this.labelSet_Maker1.Visible = false;
            // 
            // M1160_TokuteimukesakiTanka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 826);
            this.Controls.Add(this.labelSet_Maker1);
            this.Controls.Add(this.labelSet_Chubunrui1);
            this.Controls.Add(this.labelSet_Daibunrui1);
            this.Controls.Add(this.labelSet_Siiresaki);
            this.Controls.Add(this.labelSet_Tokuisaki);
            this.Controls.Add(this.gridTokuteimukesakiTanka);
            this.Controls.Add(this.lblShohinCd);
            this.Controls.Add(this.txtShohinCd);
            this.Controls.Add(this.txtTanka);
            this.Controls.Add(this.baseLabel4);
            this.Controls.Add(this.txtKataban);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.txtKensakuS);
            this.Name = "M1160_TokuteimukesakiTanka";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.M1160_TokuteimukesakiTanka_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1160_TokuteimukesakiTanka_KeyDown);
            this.Controls.SetChildIndex(this.cmbSubWinShow, 0);
            this.Controls.SetChildIndex(this.txtKensakuS, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.baseLabel2, 0);
            this.Controls.SetChildIndex(this.txtKataban, 0);
            this.Controls.SetChildIndex(this.baseLabel4, 0);
            this.Controls.SetChildIndex(this.txtTanka, 0);
            this.Controls.SetChildIndex(this.txtShohinCd, 0);
            this.Controls.SetChildIndex(this.lblShohinCd, 0);
            this.Controls.SetChildIndex(this.gridTokuteimukesakiTanka, 0);
            this.Controls.SetChildIndex(this.labelSet_Tokuisaki, 0);
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
            this.Controls.SetChildIndex(this.labelSet_Siiresaki, 0);
            this.Controls.SetChildIndex(this.labelSet_Daibunrui1, 0);
            this.Controls.SetChildIndex(this.labelSet_Chubunrui1, 0);
            this.Controls.SetChildIndex(this.labelSet_Maker1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridTokuteimukesakiTanka)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.BaseText txtKensakuS;
        private Common.Ctl.BaseText txtKataban;
        private Common.Ctl.BaseLabel baseLabel2;
        private Common.Ctl.BaseTextMoney txtTanka;
        private Common.Ctl.BaseLabel baseLabel4;
        private Common.Ctl.BaseLabel lblShohinCd;
        private Common.Ctl.BaseText txtShohinCd;
        private Common.Ctl.BaseDataGridView gridTokuteimukesakiTanka;
        private Common.Ctl.LabelSet_Torihikisaki labelSet_Tokuisaki;
        private Common.Ctl.LabelSet_Torihikisaki labelSet_Siiresaki;
        private Common.Ctl.LabelSet_Daibunrui labelSet_Daibunrui1;
        private Common.Ctl.LabelSet_Chubunrui labelSet_Chubunrui1;
        private Common.Ctl.LabelSet_Maker labelSet_Maker1;
    }
}