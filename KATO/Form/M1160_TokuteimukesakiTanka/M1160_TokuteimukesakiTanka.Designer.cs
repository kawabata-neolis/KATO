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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelSet_Tokuisaki = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtKensakuS = new KATO.Common.Ctl.BaseText();
            this.txtKataban = new KATO.Common.Ctl.BaseText();
            this.baseLabel2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTanka = new KATO.Common.Ctl.BaseTextMoney();
            this.baseLabel4 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Siiresaki = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.nameLabel = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblShohinCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtShohinCd = new KATO.Common.Ctl.BaseText();
            this.gridTokuteimukesakiTanka = new KATO.Common.Ctl.BaseDataGridView();
            this.labelSet_Siiresaki.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTokuteimukesakiTanka)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF12
            // 
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF06
            // 
            this.btnF06.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // labelSet_Tokuisaki
            // 
            this.labelSet_Tokuisaki.AppendLabelSize = 40;
            this.labelSet_Tokuisaki.AppendLabelText = "";
            this.labelSet_Tokuisaki.CodeTxtSize = 40;
            this.labelSet_Tokuisaki.CodeTxtText = "";
            this.labelSet_Tokuisaki.LabelName = "得意先コード";
            this.labelSet_Tokuisaki.Location = new System.Drawing.Point(57, 15);
            this.labelSet_Tokuisaki.Name = "labelSet_Tokuisaki";
            this.labelSet_Tokuisaki.ShowAppendFlg = true;
            this.labelSet_Tokuisaki.Size = new System.Drawing.Size(498, 22);
            this.labelSet_Tokuisaki.SpaceCodeValue = 4;
            this.labelSet_Tokuisaki.SpaceNameCode = 4;
            this.labelSet_Tokuisaki.SpaceValueAppend = 4;
            this.labelSet_Tokuisaki.TabIndex = 87;
            this.labelSet_Tokuisaki.ValueLabelSize = 350;
            this.labelSet_Tokuisaki.ValueLabelText = "";
            this.labelSet_Tokuisaki.Leave += new System.EventHandler(this.labelSet_Tokuisaki_Leave);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(59, 53);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(71, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 99;
            this.baseLabel1.Text = "検索文字";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKensakuS
            // 
            this.txtKensakuS.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensakuS.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKensakuS.Location = new System.Drawing.Point(152, 50);
            this.txtKensakuS.MaxLength = 40;
            this.txtKensakuS.Name = "txtKensakuS";
            this.txtKensakuS.Size = new System.Drawing.Size(297, 22);
            this.txtKensakuS.TabIndex = 98;
            this.txtKensakuS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKensakuS_KeyDown);
            // 
            // txtKataban
            // 
            this.txtKataban.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKataban.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtKataban.Location = new System.Drawing.Point(152, 78);
            this.txtKataban.MaxLength = 100;
            this.txtKataban.Name = "txtKataban";
            this.txtKataban.ReadOnly = true;
            this.txtKataban.Size = new System.Drawing.Size(415, 22);
            this.txtKataban.TabIndex = 101;
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel2.Location = new System.Drawing.Point(59, 81);
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
            this.txtTanka.intDeciSet = 0;
            this.txtTanka.intIntederSet = 0;
            this.txtTanka.intShishagonyu = 0;
            this.txtTanka.Location = new System.Drawing.Point(152, 106);
            this.txtTanka.MaxLength = 18;
            this.txtTanka.Name = "txtTanka";
            this.txtTanka.Size = new System.Drawing.Size(100, 22);
            this.txtTanka.TabIndex = 108;
            this.txtTanka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // baseLabel4
            // 
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel4.Location = new System.Drawing.Point(59, 109);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(39, 15);
            this.baseLabel4.strToolTip = null;
            this.baseLabel4.TabIndex = 107;
            this.baseLabel4.Text = "単価";
            this.baseLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Siiresaki
            // 
            this.labelSet_Siiresaki.AppendLabelSize = 40;
            this.labelSet_Siiresaki.AppendLabelText = "";
            this.labelSet_Siiresaki.CodeTxtSize = 40;
            this.labelSet_Siiresaki.CodeTxtText = "";
            this.labelSet_Siiresaki.Controls.Add(this.nameLabel);
            this.labelSet_Siiresaki.LabelName = "仕入先コード";
            this.labelSet_Siiresaki.Location = new System.Drawing.Point(582, 15);
            this.labelSet_Siiresaki.Name = "labelSet_Siiresaki";
            this.labelSet_Siiresaki.ShowAppendFlg = true;
            this.labelSet_Siiresaki.Size = new System.Drawing.Size(505, 22);
            this.labelSet_Siiresaki.SpaceCodeValue = 4;
            this.labelSet_Siiresaki.SpaceNameCode = 4;
            this.labelSet_Siiresaki.SpaceValueAppend = 4;
            this.labelSet_Siiresaki.TabIndex = 109;
            this.labelSet_Siiresaki.ValueLabelSize = 350;
            this.labelSet_Siiresaki.ValueLabelText = "";
            this.labelSet_Siiresaki.Visible = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.nameLabel.Location = new System.Drawing.Point(2, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(103, 15);
            this.nameLabel.strToolTip = null;
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "得意先コード";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShohinCd
            // 
            this.lblShohinCd.AutoSize = true;
            this.lblShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblShohinCd.Location = new System.Drawing.Point(584, 81);
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
            this.txtShohinCd.Location = new System.Drawing.Point(677, 78);
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokuteimukesakiTanka.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridTokuteimukesakiTanka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTokuteimukesakiTanka.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridTokuteimukesakiTanka.EnableHeadersVisualStyles = false;
            this.gridTokuteimukesakiTanka.Location = new System.Drawing.Point(12, 148);
            this.gridTokuteimukesakiTanka.Name = "gridTokuteimukesakiTanka";
            this.gridTokuteimukesakiTanka.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokuteimukesakiTanka.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridTokuteimukesakiTanka.RowHeadersVisible = false;
            this.gridTokuteimukesakiTanka.RowTemplate.Height = 21;
            this.gridTokuteimukesakiTanka.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTokuteimukesakiTanka.Size = new System.Drawing.Size(1131, 541);
            this.gridTokuteimukesakiTanka.StandardTab = true;
            this.gridTokuteimukesakiTanka.TabIndex = 112;
            this.gridTokuteimukesakiTanka.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTokuteimukesakiTanka_CellDoubleClick);
            // 
            // M1160_TokuteimukesakiTanka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.gridTokuteimukesakiTanka);
            this.Controls.Add(this.lblShohinCd);
            this.Controls.Add(this.txtShohinCd);
            this.Controls.Add(this.labelSet_Siiresaki);
            this.Controls.Add(this.txtTanka);
            this.Controls.Add(this.baseLabel4);
            this.Controls.Add(this.txtKataban);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.txtKensakuS);
            this.Controls.Add(this.labelSet_Tokuisaki);
            this.Name = "M1160_TokuteimukesakiTanka";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.M1160_TokuteimukesakiTanka_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1160_TokuteimukesakiTanka_KeyDown);
            this.Controls.SetChildIndex(this.labelSet_Tokuisaki, 0);
            this.Controls.SetChildIndex(this.txtKensakuS, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.baseLabel2, 0);
            this.Controls.SetChildIndex(this.txtKataban, 0);
            this.Controls.SetChildIndex(this.baseLabel4, 0);
            this.Controls.SetChildIndex(this.txtTanka, 0);
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
            this.Controls.SetChildIndex(this.txtShohinCd, 0);
            this.Controls.SetChildIndex(this.lblShohinCd, 0);
            this.Controls.SetChildIndex(this.gridTokuteimukesakiTanka, 0);
            this.labelSet_Siiresaki.ResumeLayout(false);
            this.labelSet_Siiresaki.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTokuteimukesakiTanka)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.LabelSet_Tokuisaki labelSet_Tokuisaki;
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.BaseText txtKensakuS;
        private Common.Ctl.BaseText txtKataban;
        private Common.Ctl.BaseLabel baseLabel2;
        private Common.Ctl.BaseTextMoney txtTanka;
        private Common.Ctl.BaseLabel baseLabel4;
        private Common.Ctl.LabelSet_Tokuisaki labelSet_Siiresaki;
        private Common.Ctl.BaseLabel nameLabel;
        private Common.Ctl.BaseLabel lblShohinCd;
        private Common.Ctl.BaseText txtShohinCd;
        private Common.Ctl.BaseDataGridView gridTokuteimukesakiTanka;
    }
}