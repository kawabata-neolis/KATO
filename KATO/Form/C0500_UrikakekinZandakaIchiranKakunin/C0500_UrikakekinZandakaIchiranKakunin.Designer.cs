﻿namespace KATO.Form.C0500_UrikakekinZandakaIchiranKakunin
{
    partial class C0500_UrikakekinZandakaIchiranKakunin
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
            this.txtYMopen = new KATO.Common.Ctl.BaseCalendarYM();
            this.txtYMclose = new KATO.Common.Ctl.BaseCalendarYM();
            this.lblHani1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lbl2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblTokuisakiCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblYM = new KATO.Common.Ctl.BaseLabel(this.components);
            this.gridTokuisaki = new KATO.Common.Ctl.BaseDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radShuturyoku = new KATO.Common.Ctl.RadSet_2btn();
            this.lblsetTantoshaCdopen = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.lblsetTantoshaCdclose = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.nameLabel = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblMessage = new KATO.Common.Ctl.BaseLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridTokuisaki)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.lblsetTantoshaCdclose.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.TabIndex = 4;
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
            this.btnF04.TabIndex = 6;
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
            // txtYMopen
            // 
            this.txtYMopen.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYMopen.Location = new System.Drawing.Point(124, 51);
            this.txtYMopen.MaxLength = 7;
            this.txtYMopen.Name = "txtYMopen";
            this.txtYMopen.Size = new System.Drawing.Size(65, 22);
            this.txtYMopen.TabIndex = 2;
            this.txtYMopen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtUrikakeZanKeyUp);
            // 
            // txtYMclose
            // 
            this.txtYMclose.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYMclose.Location = new System.Drawing.Point(222, 51);
            this.txtYMclose.MaxLength = 7;
            this.txtYMclose.Name = "txtYMclose";
            this.txtYMclose.Size = new System.Drawing.Size(65, 22);
            this.txtYMclose.TabIndex = 3;
            this.txtYMclose.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtUrikakeZanKeyUp);
            // 
            // lblHani1
            // 
            this.lblHani1.AutoSize = true;
            this.lblHani1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHani1.Location = new System.Drawing.Point(167, 18);
            this.lblHani1.Name = "lblHani1";
            this.lblHani1.Size = new System.Drawing.Size(23, 15);
            this.lblHani1.strToolTip = null;
            this.lblHani1.TabIndex = 91;
            this.lblHani1.Text = "～";
            this.lblHani1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl2.Location = new System.Drawing.Point(194, 54);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(23, 15);
            this.lbl2.strToolTip = null;
            this.lbl2.TabIndex = 91;
            this.lbl2.Text = "～";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTokuisakiCd
            // 
            this.lblTokuisakiCd.AutoSize = true;
            this.lblTokuisakiCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTokuisakiCd.Location = new System.Drawing.Point(12, 18);
            this.lblTokuisakiCd.Name = "lblTokuisakiCd";
            this.lblTokuisakiCd.Size = new System.Drawing.Size(103, 15);
            this.lblTokuisakiCd.strToolTip = null;
            this.lblTokuisakiCd.TabIndex = 91;
            this.lblTokuisakiCd.Text = "得意先コード";
            this.lblTokuisakiCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblYM
            // 
            this.lblYM.AutoSize = true;
            this.lblYM.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblYM.Location = new System.Drawing.Point(12, 54);
            this.lblYM.Name = "lblYM";
            this.lblYM.Size = new System.Drawing.Size(55, 15);
            this.lblYM.strToolTip = null;
            this.lblYM.TabIndex = 91;
            this.lblYM.Text = "年月度";
            this.lblYM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridTokuisaki
            // 
            this.gridTokuisaki.AllowUserToAddRows = false;
            this.gridTokuisaki.AllowUserToResizeColumns = false;
            this.gridTokuisaki.AllowUserToResizeRows = false;
            this.gridTokuisaki.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokuisaki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridTokuisaki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTokuisaki.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridTokuisaki.EnableHeadersVisualStyles = false;
            this.gridTokuisaki.Location = new System.Drawing.Point(14, 96);
            this.gridTokuisaki.Name = "gridTokuisaki";
            this.gridTokuisaki.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTokuisaki.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridTokuisaki.RowHeadersVisible = false;
            this.gridTokuisaki.RowTemplate.Height = 21;
            this.gridTokuisaki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTokuisaki.Size = new System.Drawing.Size(1397, 668);
            this.gridTokuisaki.StandardTab = true;
            this.gridTokuisaki.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radShuturyoku);
            this.groupBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(382, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 80);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出力順";
            // 
            // radShuturyoku
            // 
            this.radShuturyoku.intJudBtn = 25;
            this.radShuturyoku.LabelTitle = null;
            this.radShuturyoku.Location = new System.Drawing.Point(11, 20);
            this.radShuturyoku.Name = "radShuturyoku";
            this.radShuturyoku.PositionLabelTitle_X = 0;
            this.radShuturyoku.PositionLabelTitle_Y = 0;
            this.radShuturyoku.PositionRadbtn1_X = 0;
            this.radShuturyoku.PositionRadbtn1_Y = 0;
            this.radShuturyoku.PositionRadbtn2_X = 0;
            this.radShuturyoku.PositionRadbtn2_Y = 25;
            this.radShuturyoku.Radbtn1Text = "得意先コードの昇順";
            this.radShuturyoku.Radbtn2Text = "フリガナの昇順";
            this.radShuturyoku.Size = new System.Drawing.Size(178, 53);
            this.radShuturyoku.TabIndex = 7;
            // 
            // lblsetTantoshaCdopen
            // 
            this.lblsetTantoshaCdopen.AppendLabelSize = 0;
            this.lblsetTantoshaCdopen.AppendLabelText = "";
            this.lblsetTantoshaCdopen.CodeTxtSize = 40;
            this.lblsetTantoshaCdopen.CodeTxtText = "";
            this.lblsetTantoshaCdopen.LabelName = "";
            this.lblsetTantoshaCdopen.Location = new System.Drawing.Point(120, 15);
            this.lblsetTantoshaCdopen.Name = "lblsetTantoshaCdopen";
            this.lblsetTantoshaCdopen.ShowAppendFlg = false;
            this.lblsetTantoshaCdopen.Size = new System.Drawing.Size(46, 22);
            this.lblsetTantoshaCdopen.SpaceCodeValue = 4;
            this.lblsetTantoshaCdopen.SpaceNameCode = 4;
            this.lblsetTantoshaCdopen.SpaceValueAppend = 0;
            this.lblsetTantoshaCdopen.TabIndex = 0;
            this.lblsetTantoshaCdopen.ValueLabelSize = 0;
            this.lblsetTantoshaCdopen.ValueLabelText = "";
            // 
            // lblsetTantoshaCdclose
            // 
            this.lblsetTantoshaCdclose.AppendLabelSize = 0;
            this.lblsetTantoshaCdclose.AppendLabelText = "";
            this.lblsetTantoshaCdclose.CodeTxtSize = 40;
            this.lblsetTantoshaCdclose.CodeTxtText = "";
            this.lblsetTantoshaCdclose.Controls.Add(this.baseLabel1);
            this.lblsetTantoshaCdclose.Controls.Add(this.nameLabel);
            this.lblsetTantoshaCdclose.LabelName = "";
            this.lblsetTantoshaCdclose.Location = new System.Drawing.Point(189, 15);
            this.lblsetTantoshaCdclose.Name = "lblsetTantoshaCdclose";
            this.lblsetTantoshaCdclose.ShowAppendFlg = false;
            this.lblsetTantoshaCdclose.Size = new System.Drawing.Size(46, 22);
            this.lblsetTantoshaCdclose.SpaceCodeValue = 4;
            this.lblsetTantoshaCdclose.SpaceNameCode = 4;
            this.lblsetTantoshaCdclose.SpaceValueAppend = 0;
            this.lblsetTantoshaCdclose.TabIndex = 1;
            this.lblsetTantoshaCdclose.ValueLabelSize = 0;
            this.lblsetTantoshaCdclose.ValueLabelText = "";
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.baseLabel1.Location = new System.Drawing.Point(2, 3);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(0, 15);
            this.baseLabel1.strToolTip = null;
            this.baseLabel1.TabIndex = 0;
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.nameLabel.Location = new System.Drawing.Point(2, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 15);
            this.nameLabel.strToolTip = null;
            this.nameLabel.TabIndex = 0;
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblMessage.Location = new System.Drawing.Point(615, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(295, 15);
            this.lblMessage.strToolTip = null;
            this.lblMessage.TabIndex = 105;
            this.lblMessage.Text = "※締め後の金額は印刷時に更新されます";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // C0500_UrikakekinZandakaIchiranKakunin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblsetTantoshaCdclose);
            this.Controls.Add(this.lblsetTantoshaCdopen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridTokuisaki);
            this.Controls.Add(this.lblYM);
            this.Controls.Add(this.lblTokuisakiCd);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lblHani1);
            this.Controls.Add(this.txtYMclose);
            this.Controls.Add(this.txtYMopen);
            this.Name = "C0500_UrikakekinZandakaIchiranKakunin";
            this.Text = "";
            this.Load += new System.EventHandler(this.C1500_UrikakekinanKakunin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.C0500_UrikakekinanKakunin_KeyDown);
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
            this.Controls.SetChildIndex(this.cmbSubWinShow, 0);
            this.Controls.SetChildIndex(this.txtYMopen, 0);
            this.Controls.SetChildIndex(this.txtYMclose, 0);
            this.Controls.SetChildIndex(this.lblHani1, 0);
            this.Controls.SetChildIndex(this.lbl2, 0);
            this.Controls.SetChildIndex(this.lblTokuisakiCd, 0);
            this.Controls.SetChildIndex(this.lblYM, 0);
            this.Controls.SetChildIndex(this.gridTokuisaki, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblsetTantoshaCdopen, 0);
            this.Controls.SetChildIndex(this.lblsetTantoshaCdclose, 0);
            this.Controls.SetChildIndex(this.lblMessage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridTokuisaki)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.lblsetTantoshaCdclose.ResumeLayout(false);
            this.lblsetTantoshaCdclose.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.Ctl.BaseCalendarYM txtYMopen;
        private Common.Ctl.BaseCalendarYM txtYMclose;
        private Common.Ctl.BaseLabel lblHani1;
        private Common.Ctl.BaseLabel lbl2;
        private Common.Ctl.BaseLabel lblTokuisakiCd;
        private Common.Ctl.BaseLabel lblYM;
        private Common.Ctl.BaseDataGridView gridTokuisaki;
        private System.Windows.Forms.GroupBox groupBox1;
        private Common.Ctl.RadSet_2btn radShuturyoku;
        private Common.Ctl.LabelSet_Torihikisaki lblsetTantoshaCdopen;
        private Common.Ctl.LabelSet_Torihikisaki lblsetTantoshaCdclose;
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.BaseLabel nameLabel;
        private Common.Ctl.BaseLabel lblMessage;
    }
}