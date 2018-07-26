namespace KATO.Form.A0110_KakohinTehaiInput
{
    partial class KakoTehaiList
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
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.lblKensu = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gridShukko = new KATO.Common.Ctl.BaseDataGridView();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtHinmei = new KATO.Common.Ctl.BaseText();
            this.lsShiire = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.lsTanto = new KATO.Common.Ctl.LabelSet_Tantousha();
            ((System.ComponentModel.ISupportInitialize)(this.gridShukko)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(759, 36);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 3;
            this.btnF11.Text = "検索(F11)";
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnF11_Click);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(759, 7);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 4;
            this.btnF12.Text = "戻る(F12)";
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnF12_Click);
            // 
            // lblKensu
            // 
            this.lblKensu.AutoSize = true;
            this.lblKensu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKensu.Location = new System.Drawing.Point(22, 577);
            this.lblKensu.Name = "lblKensu";
            this.lblKensu.Size = new System.Drawing.Size(111, 15);
            this.lblKensu.strToolTip = null;
            this.lblKensu.TabIndex = 5;
            this.lblKensu.Text = "該当件数(0件)";
            this.lblKensu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridShukko
            // 
            this.gridShukko.AllowUserToAddRows = false;
            this.gridShukko.AllowUserToResizeColumns = false;
            this.gridShukko.AllowUserToResizeRows = false;
            this.gridShukko.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShukko.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridShukko.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridShukko.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridShukko.EnableHeadersVisualStyles = false;
            this.gridShukko.Location = new System.Drawing.Point(9, 92);
            this.gridShukko.Name = "gridShukko";
            this.gridShukko.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridShukko.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridShukko.RowHeadersVisible = false;
            this.gridShukko.RowTemplate.Height = 21;
            this.gridShukko.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShukko.Size = new System.Drawing.Size(850, 479);
            this.gridShukko.StandardTab = true;
            this.gridShukko.TabIndex = 5;
            this.gridShukko.DoubleClick += new System.EventHandler(this.gridShukko_DoubleClick);
            this.gridShukko.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.gridShukko_PreviewKeyDown);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(26, 67);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(87, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 3;
            this.baseLabel1.Text = "品名・型番";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHinmei
            // 
            this.txtHinmei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHinmei.Location = new System.Drawing.Point(119, 64);
            this.txtHinmei.Name = "txtHinmei";
            this.txtHinmei.Size = new System.Drawing.Size(345, 22);
            this.txtHinmei.TabIndex = 2;
            this.txtHinmei.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHinmei_KeyDown);
            // 
            // lsShiire
            // 
            this.lsShiire.AppendLabelSize = 0;
            this.lsShiire.AppendLabelText = "";
            this.lsShiire.CodeTxtSize = 40;
            this.lsShiire.CodeTxtText = "";
            this.lsShiire.LabelName = "仕入先";
            this.lsShiire.Location = new System.Drawing.Point(23, 36);
            this.lsShiire.Name = "lsShiire";
            this.lsShiire.ShowAppendFlg = false;
            this.lsShiire.Size = new System.Drawing.Size(441, 22);
            this.lsShiire.SpaceCodeValue = 4;
            this.lsShiire.SpaceNameCode = 41;
            this.lsShiire.SpaceValueAppend = 4;
            this.lsShiire.TabIndex = 1;
            this.lsShiire.ValueLabelSize = 300;
            this.lsShiire.ValueLabelText = "";
            // 
            // lsTanto
            // 
            this.lsTanto.AppendLabelSize = 0;
            this.lsTanto.AppendLabelText = "";
            this.lsTanto.CodeTxtSize = 40;
            this.lsTanto.CodeTxtText = "";
            this.lsTanto.LabelName = "担当者";
            this.lsTanto.Location = new System.Drawing.Point(23, 8);
            this.lsTanto.Name = "lsTanto";
            this.lsTanto.ShowAppendFlg = false;
            this.lsTanto.Size = new System.Drawing.Size(461, 22);
            this.lsTanto.SpaceCodeValue = 4;
            this.lsTanto.SpaceNameCode = 41;
            this.lsTanto.SpaceValueAppend = 4;
            this.lsTanto.TabIndex = 0;
            this.lsTanto.ValueLabelSize = 120;
            this.lsTanto.ValueLabelText = "";
            // 
            // KakoTehaiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 601);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.lblKensu);
            this.Controls.Add(this.gridShukko);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.txtHinmei);
            this.Controls.Add(this.lsShiire);
            this.Controls.Add(this.lsTanto);
            this.Name = "KakoTehaiList";
            this.Text = "加工品手配リスト";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KakoTehaiList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridShukko)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.LabelSet_Tantousha lsTanto;
        private Common.Ctl.LabelSet_Torihikisaki lsShiire;
        private Common.Ctl.BaseText txtHinmei;
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.BaseDataGridView gridShukko;
        private Common.Ctl.BaseLabel lblKensu;
        private Common.Ctl.BaseButton btnF12;
        private Common.Ctl.BaseButton btnF11;
    }
}