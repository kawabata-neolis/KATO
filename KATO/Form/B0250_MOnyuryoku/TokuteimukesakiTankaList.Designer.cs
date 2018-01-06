using KATO.Common;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    partial class TokuteimukesakiTankaList
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
            this.lblsetTorihikisakiCd = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.lblShohinCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtShohinCd = new KATO.Common.Ctl.BaseText();
            this.lblKataban = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtKataban = new KATO.Common.Ctl.BaseText();
            this.gridSeihin = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeihin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(29, 635);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 19;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // lblsetTorihikisakiCd
            // 
            this.lblsetTorihikisakiCd.AppendLabelSize = 0;
            this.lblsetTorihikisakiCd.AppendLabelText = "";
            this.lblsetTorihikisakiCd.CodeTxtSize = 40;
            this.lblsetTorihikisakiCd.CodeTxtText = "";
            this.lblsetTorihikisakiCd.LabelName = "取引先コード";
            this.lblsetTorihikisakiCd.Location = new System.Drawing.Point(593, 40);
            this.lblsetTorihikisakiCd.Name = "lblsetTorihikisakiCd";
            this.lblsetTorihikisakiCd.ShowAppendFlg = false;
            this.lblsetTorihikisakiCd.Size = new System.Drawing.Size(471, 22);
            this.lblsetTorihikisakiCd.SpaceCodeValue = 4;
            this.lblsetTorihikisakiCd.SpaceNameCode = 4;
            this.lblsetTorihikisakiCd.SpaceValueAppend = 4;
            this.lblsetTorihikisakiCd.TabIndex = 25;
            this.lblsetTorihikisakiCd.TabStop = false;
            this.lblsetTorihikisakiCd.ValueLabelSize = 300;
            this.lblsetTorihikisakiCd.ValueLabelText = "";
            this.lblsetTorihikisakiCd.Visible = false;
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(1163, 48);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 24;
            this.btnF11.TabStop = false;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Visible = false;
            // 
            // lblShohinCd
            // 
            this.lblShohinCd.AutoSize = true;
            this.lblShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblShohinCd.Location = new System.Drawing.Point(595, 15);
            this.lblShohinCd.Name = "lblShohinCd";
            this.lblShohinCd.Size = new System.Drawing.Size(87, 15);
            this.lblShohinCd.strToolTip = null;
            this.lblShohinCd.TabIndex = 23;
            this.lblShohinCd.Text = "商品コード";
            this.lblShohinCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShohinCd.Visible = false;
            // 
            // txtShohinCd
            // 
            this.txtShohinCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShohinCd.Location = new System.Drawing.Point(711, 12);
            this.txtShohinCd.MaxLength = 6;
            this.txtShohinCd.Name = "txtShohinCd";
            this.txtShohinCd.Size = new System.Drawing.Size(137, 22);
            this.txtShohinCd.TabIndex = 22;
            this.txtShohinCd.TabStop = false;
            this.txtShohinCd.Visible = false;
            // 
            // lblKataban
            // 
            this.lblKataban.AutoSize = true;
            this.lblKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKataban.Location = new System.Drawing.Point(39, 43);
            this.lblKataban.Name = "lblKataban";
            this.lblKataban.Size = new System.Drawing.Size(39, 15);
            this.lblKataban.strToolTip = null;
            this.lblKataban.TabIndex = 21;
            this.lblKataban.Text = "型番";
            this.lblKataban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKataban
            // 
            this.txtKataban.BackColor = System.Drawing.SystemColors.Window;
            this.txtKataban.Enabled = false;
            this.txtKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKataban.Location = new System.Drawing.Point(150, 40);
            this.txtKataban.MaxLength = 40;
            this.txtKataban.Name = "txtKataban";
            this.txtKataban.ReadOnly = true;
            this.txtKataban.Size = new System.Drawing.Size(405, 22);
            this.txtKataban.TabIndex = 2;
            this.txtKataban.TabStop = false;
            // 
            // gridSeihin
            // 
            this.gridSeihin.AllowUserToAddRows = false;
            this.gridSeihin.AllowUserToResizeColumns = false;
            this.gridSeihin.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSeihin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSeihin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSeihin.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridSeihin.EnableHeadersVisualStyles = false;
            this.gridSeihin.Location = new System.Drawing.Point(31, 83);
            this.gridSeihin.Name = "gridSeihin";
            this.gridSeihin.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSeihin.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSeihin.RowHeadersVisible = false;
            this.gridSeihin.RowTemplate.Height = 21;
            this.gridSeihin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSeihin.Size = new System.Drawing.Size(1232, 534);
            this.gridSeihin.StandardTab = true;
            this.gridSeihin.TabIndex = 0;
            this.gridSeihin.DoubleClick += new System.EventHandler(this.gridChoku_DoubleClick);
            this.gridSeihin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridSeihinKeyDown);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(1163, 19);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 1;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // TokuteimukesakiTankaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 675);
            this.Controls.Add(this.lblsetTorihikisakiCd);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.lblShohinCd);
            this.Controls.Add(this.txtShohinCd);
            this.Controls.Add(this.lblKataban);
            this.Controls.Add(this.txtKataban);
            this.Controls.Add(this.gridSeihin);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnF12);
            this.Name = "TokuteimukesakiTankaList";
            this.Text = "TokuteimukesakiTankaList";
            this.Load += new System.EventHandler(this.ChokusosakiList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judDaiBunruiListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridSeihin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BaseButton btnF12;
        private System.Windows.Forms.Label lblRecords;
        private BaseDataGridView gridSeihin;
        private BaseText txtKataban;
        private BaseLabel lblKataban;
        private BaseLabel lblShohinCd;
        private BaseText txtShohinCd;
        private BaseButton btnF11;
        private LabelSet_Torihikisaki lblsetTorihikisakiCd;
    }
}