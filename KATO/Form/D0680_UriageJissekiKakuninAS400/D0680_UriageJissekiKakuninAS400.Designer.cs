﻿namespace KATO.Form.D0680_UriageJissekiKakuninAS400
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
            this.lblSpan = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblKikan = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtSinamei_KatabanS = new KATO.Common.Ctl.BaseText();
            this.lblKataban = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtBikouS = new KATO.Common.Ctl.BaseText();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gridTorihiki = new KATO.Common.Ctl.BaseDataGridView();
            this.txtCalendarYMDStart = new KATO.Common.Ctl.BaseCalendar();
            this.txtCalendarYMDEnd = new KATO.Common.Ctl.BaseCalendar();
            this.labelSet_Tokuisaki = new KATO.Common.Ctl.LabelSet_Tokuisaki();
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.TabIndex = 5;
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF12
            // 
            this.btnF12.TabIndex = 16;
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.TabIndex = 15;
            // 
            // btnF10
            // 
            this.btnF10.TabIndex = 14;
            // 
            // btnF09
            // 
            this.btnF09.TabIndex = 13;
            // 
            // btnF08
            // 
            this.btnF08.TabIndex = 12;
            // 
            // btnF07
            // 
            this.btnF07.TabIndex = 11;
            // 
            // btnF06
            // 
            this.btnF06.TabIndex = 10;
            // 
            // btnF05
            // 
            this.btnF05.TabIndex = 9;
            // 
            // btnF04
            // 
            this.btnF04.TabIndex = 8;
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.TabIndex = 7;
            // 
            // btnF02
            // 
            this.btnF02.TabIndex = 6;
            // 
            // lblSpan
            // 
            this.lblSpan.AutoSize = true;
            this.lblSpan.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblSpan.Location = new System.Drawing.Point(216, 81);
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
            this.lblKikan.Location = new System.Drawing.Point(13, 81);
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
            this.txtSinamei_KatabanS.Location = new System.Drawing.Point(772, 40);
            this.txtSinamei_KatabanS.MaxLength = 100;
            this.txtSinamei_KatabanS.Name = "txtSinamei_KatabanS";
            this.txtSinamei_KatabanS.Size = new System.Drawing.Size(353, 22);
            this.txtSinamei_KatabanS.TabIndex = 3;
            this.txtSinamei_KatabanS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTextboxKeyDown);
            // 
            // lblKataban
            // 
            this.lblKataban.AutoSize = true;
            this.lblKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKataban.Location = new System.Drawing.Point(679, 43);
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
            this.txtBikouS.Location = new System.Drawing.Point(772, 77);
            this.txtBikouS.MaxLength = 100;
            this.txtBikouS.Name = "txtBikouS";
            this.txtBikouS.Size = new System.Drawing.Size(353, 22);
            this.txtBikouS.TabIndex = 4;
            this.txtBikouS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTextboxKeyDown);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(679, 81);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(87, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 107;
            this.baseLabel1.Text = "備      考";
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridTorihiki
            // 
            this.gridTorihiki.AllowUserToAddRows = false;
            this.gridTorihiki.AllowUserToDeleteRows = false;
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
            this.gridTorihiki.Location = new System.Drawing.Point(12, 121);
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
            this.gridTorihiki.Size = new System.Drawing.Size(1560, 587);
            this.gridTorihiki.StandardTab = true;
            this.gridTorihiki.TabIndex = 109;
            // 
            // txtCalendarYMDStart
            // 
            this.txtCalendarYMDStart.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtCalendarYMDStart.Location = new System.Drawing.Point(119, 77);
            this.txtCalendarYMDStart.MaxLength = 10;
            this.txtCalendarYMDStart.Name = "txtCalendarYMDStart";
            this.txtCalendarYMDStart.Size = new System.Drawing.Size(90, 22);
            this.txtCalendarYMDStart.TabIndex = 1;
            // 
            // txtCalendarYMDEnd
            // 
            this.txtCalendarYMDEnd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtCalendarYMDEnd.Location = new System.Drawing.Point(245, 77);
            this.txtCalendarYMDEnd.MaxLength = 10;
            this.txtCalendarYMDEnd.Name = "txtCalendarYMDEnd";
            this.txtCalendarYMDEnd.Size = new System.Drawing.Size(90, 22);
            this.txtCalendarYMDEnd.TabIndex = 2;
            // 
            // labelSet_Tokuisaki
            // 
            this.labelSet_Tokuisaki.AppendLabelSize = 40;
            this.labelSet_Tokuisaki.AppendLabelText = "";
            this.labelSet_Tokuisaki.CodeTxtSize = 40;
            this.labelSet_Tokuisaki.CodeTxtText = "";
            this.labelSet_Tokuisaki.LabelName = "得意先コード";
            this.labelSet_Tokuisaki.Location = new System.Drawing.Point(12, 40);
            this.labelSet_Tokuisaki.Name = "labelSet_Tokuisaki";
            this.labelSet_Tokuisaki.ShowAppendFlg = false;
            this.labelSet_Tokuisaki.Size = new System.Drawing.Size(510, 22);
            this.labelSet_Tokuisaki.SpaceCodeValue = 4;
            this.labelSet_Tokuisaki.SpaceNameCode = 4;
            this.labelSet_Tokuisaki.SpaceValueAppend = 4;
            this.labelSet_Tokuisaki.TabIndex = 0;
            this.labelSet_Tokuisaki.ValueLabelSize = 350;
            this.labelSet_Tokuisaki.ValueLabelText = "";
            // 
            // D0680_UriageJissekiKakuninAS400
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 826);
            this.Controls.Add(this.labelSet_Tokuisaki);
            this.Controls.Add(this.txtCalendarYMDEnd);
            this.Controls.Add(this.txtCalendarYMDStart);
            this.Controls.Add(this.gridTorihiki);
            this.Controls.Add(this.txtBikouS);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.txtSinamei_KatabanS);
            this.Controls.Add(this.lblKataban);
            this.Controls.Add(this.lblSpan);
            this.Controls.Add(this.lblKikan);
            this.Name = "D0680_UriageJissekiKakuninAS400";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.D0680_UriageJissekiKakuninAS400_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.D0680_UriageJissekiKakuninAS400_KeyDown);
            this.Controls.SetChildIndex(this.cmbSubWinShow, 0);
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
            this.Controls.SetChildIndex(this.txtCalendarYMDStart, 0);
            this.Controls.SetChildIndex(this.txtCalendarYMDEnd, 0);
            this.Controls.SetChildIndex(this.labelSet_Tokuisaki, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.Ctl.BaseLabel lblSpan;
        private Common.Ctl.BaseLabel lblKikan;
        private Common.Ctl.BaseText txtSinamei_KatabanS;
        private Common.Ctl.BaseLabel lblKataban;
        private Common.Ctl.BaseText txtBikouS;
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.BaseDataGridView gridTorihiki;
        private Common.Ctl.BaseCalendar txtCalendarYMDStart;
        private Common.Ctl.BaseCalendar txtCalendarYMDEnd;
        private Common.Ctl.LabelSet_Tokuisaki labelSet_Tokuisaki;
    }
}