namespace KATO.Form.D0680_UriageJissekiKakuninAS400
{
    partial class D0680_UriageJissekiKakuninAS400
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
            this.labelSet_Tokuisaki = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            this.lblSpan = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblKikan = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtSinamei_KatabanS = new KATO.Common.Ctl.BaseText();
            this.lblKataban = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtBikouS = new KATO.Common.Ctl.BaseText();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gridTorihiki = new KATO.Common.Ctl.BaseDataGridView();
            this.txtYMDopen = new KATO.Common.Ctl.BaseCalendar();
            this.txtYMDclose = new KATO.Common.Ctl.BaseCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF12
            // 
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
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
            this.labelSet_Tokuisaki.Location = new System.Drawing.Point(24, 15);
            this.labelSet_Tokuisaki.Name = "labelSet_Tokuisaki";
            this.labelSet_Tokuisaki.ShowAppendFlg = true;
            this.labelSet_Tokuisaki.Size = new System.Drawing.Size(500, 22);
            this.labelSet_Tokuisaki.SpaceCodeValue = 4;
            this.labelSet_Tokuisaki.SpaceNameCode = 4;
            this.labelSet_Tokuisaki.SpaceValueAppend = 4;
            this.labelSet_Tokuisaki.TabIndex = 87;
            this.labelSet_Tokuisaki.ValueLabelSize = 350;
            this.labelSet_Tokuisaki.ValueLabelText = "";
            // 
            // lblSpan
            // 
            this.lblSpan.AutoSize = true;
            this.lblSpan.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSpan.Location = new System.Drawing.Point(262, 57);
            this.lblSpan.Name = "lblSpan";
            this.lblSpan.Size = new System.Drawing.Size(23, 15);
            this.lblSpan.strToolTip = null;
            this.lblSpan.TabIndex = 93;
            this.lblSpan.Text = "～";
            this.lblSpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKikan
            // 
            this.lblKikan.AutoSize = true;
            this.lblKikan.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKikan.Location = new System.Drawing.Point(21, 58);
            this.lblKikan.Name = "lblKikan";
            this.lblKikan.Size = new System.Drawing.Size(87, 15);
            this.lblKikan.strToolTip = null;
            this.lblKikan.TabIndex = 91;
            this.lblKikan.Text = "伝票年月日";
            this.lblKikan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSinamei_KatabanS
            // 
            this.txtSinamei_KatabanS.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtSinamei_KatabanS.Location = new System.Drawing.Point(745, 15);
            this.txtSinamei_KatabanS.MaxLength = 100;
            this.txtSinamei_KatabanS.Name = "txtSinamei_KatabanS";
            this.txtSinamei_KatabanS.Size = new System.Drawing.Size(353, 22);
            this.txtSinamei_KatabanS.TabIndex = 106;
            // 
            // lblKataban
            // 
            this.lblKataban.AutoSize = true;
            this.lblKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKataban.Location = new System.Drawing.Point(652, 18);
            this.lblKataban.Name = "lblKataban";
            this.lblKataban.Size = new System.Drawing.Size(87, 15);
            this.lblKataban.strToolTip = null;
            this.lblKataban.TabIndex = 105;
            this.lblKataban.Text = "品名・型番";
            this.lblKataban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBikouS
            // 
            this.txtBikouS.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtBikouS.Location = new System.Drawing.Point(745, 58);
            this.txtBikouS.MaxLength = 100;
            this.txtBikouS.Name = "txtBikouS";
            this.txtBikouS.Size = new System.Drawing.Size(353, 22);
            this.txtBikouS.TabIndex = 108;
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(652, 61);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(39, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 107;
            this.baseLabel1.Text = "備考";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridTorihiki
            // 
            this.gridTorihiki.AllowUserToAddRows = false;
            this.gridTorihiki.AllowUserToDeleteRows = false;
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
            this.gridTorihiki.Location = new System.Drawing.Point(24, 91);
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
            this.gridTorihiki.Size = new System.Drawing.Size(1315, 620);
            this.gridTorihiki.StandardTab = true;
            this.gridTorihiki.TabIndex = 109;
            // 
            // txtYMDopen
            // 
            this.txtYMDopen.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYMDopen.Location = new System.Drawing.Point(129, 54);
            this.txtYMDopen.Name = "txtYMDopen";
            this.txtYMDopen.Size = new System.Drawing.Size(127, 22);
            this.txtYMDopen.TabIndex = 110;
            this.txtYMDopen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtYMDclose
            // 
            this.txtYMDclose.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYMDclose.Location = new System.Drawing.Point(291, 54);
            this.txtYMDclose.Name = "txtYMDclose";
            this.txtYMDclose.Size = new System.Drawing.Size(147, 22);
            this.txtYMDclose.TabIndex = 111;
            this.txtYMDclose.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // D0680_UriageJissekiKakuninAS400
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.txtYMDclose);
            this.Controls.Add(this.txtYMDopen);
            this.Controls.Add(this.gridTorihiki);
            this.Controls.Add(this.txtBikouS);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.txtSinamei_KatabanS);
            this.Controls.Add(this.lblKataban);
            this.Controls.Add(this.lblSpan);
            this.Controls.Add(this.lblKikan);
            this.Controls.Add(this.labelSet_Tokuisaki);
            this.Name = "D0680_UriageJissekiKakuninAS400";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.D0680_UriageJissekiKakuninAS400_FormClosed);
            this.Load += new System.EventHandler(this.D0680_UriageJissekiKakuninAS400_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.D0680_UriageJissekiKakuninAS400_KeyDown);
            this.Controls.SetChildIndex(this.labelSet_Tokuisaki, 0);
            this.Controls.SetChildIndex(this.lblKikan, 0);
            this.Controls.SetChildIndex(this.lblSpan, 0);
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
            this.Controls.SetChildIndex(this.lblKataban, 0);
            this.Controls.SetChildIndex(this.txtSinamei_KatabanS, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.txtBikouS, 0);
            this.Controls.SetChildIndex(this.gridTorihiki, 0);
            this.Controls.SetChildIndex(this.txtYMDopen, 0);
            this.Controls.SetChildIndex(this.txtYMDclose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.LabelSet_Tokuisaki labelSet_Tokuisaki;
        private Common.Ctl.BaseLabel lblSpan;
        private Common.Ctl.BaseLabel lblKikan;
        private Common.Ctl.BaseText txtSinamei_KatabanS;
        private Common.Ctl.BaseLabel lblKataban;
        private Common.Ctl.BaseText txtBikouS;
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.BaseDataGridView gridTorihiki;
        private Common.Ctl.BaseCalendar txtYMDopen;
        private Common.Ctl.BaseCalendar txtYMDclose;
    }
}