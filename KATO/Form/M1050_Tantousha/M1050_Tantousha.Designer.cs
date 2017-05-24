﻿namespace KATO.Form.M1050_Tantousha
{
    partial class M1050_Tantousha
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
            this.labelSet_Eigyousho = new KATO.Common.Ctl.LabelSet_Eigyosho();
            this.labelSet_GroupCd = new KATO.Common.Ctl.LabelSet_GroupCd();
            this.lblTantouCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTantoushaCd = new KATO.Common.Ctl.BaseText();
            this.lblTantoushaName = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtTantoushaName = new KATO.Common.Ctl.BaseText();
            this.lblLoginID = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtLoginID = new KATO.Common.Ctl.BaseText();
            this.lblChuban = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtChuban = new KATO.Common.Ctl.BaseText();
            this.lblMokuhyou = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtMokuhyou = new KATO.Common.Ctl.BaseTextMoney();
            this.SuspendLayout();
            // 
            // labelSet_Eigyousho
            // 
            this.labelSet_Eigyousho.AppendLabelSize = 0;
            this.labelSet_Eigyousho.AppendLabelText = "";
            this.labelSet_Eigyousho.CodeTxtSize = 40;
            this.labelSet_Eigyousho.CodeTxtText = "";
            this.labelSet_Eigyousho.LabelName = "営業所コード";
            this.labelSet_Eigyousho.Location = new System.Drawing.Point(738, 195);
            this.labelSet_Eigyousho.Name = "labelSet_Eigyousho";
            this.labelSet_Eigyousho.ShowAppendFlg = false;
            this.labelSet_Eigyousho.Size = new System.Drawing.Size(453, 22);
            this.labelSet_Eigyousho.SpaceCodeValue = 8;
            this.labelSet_Eigyousho.SpaceNameCode = 20;
            this.labelSet_Eigyousho.SpaceValueAppend = 4;
            this.labelSet_Eigyousho.TabIndex = 3;
            this.labelSet_Eigyousho.ValueLabelSize = 140;
            this.labelSet_Eigyousho.ValueLabelText = "";
            // 
            // labelSet_GroupCd
            // 
            this.labelSet_GroupCd.AppendLabelSize = 0;
            this.labelSet_GroupCd.AppendLabelText = "";
            this.labelSet_GroupCd.CodeTxtSize = 40;
            this.labelSet_GroupCd.CodeTxtText = "";
            this.labelSet_GroupCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.labelSet_GroupCd.LabelName = "グループコード";
            this.labelSet_GroupCd.Location = new System.Drawing.Point(738, 272);
            this.labelSet_GroupCd.LsGroupCddata = null;
            this.labelSet_GroupCd.Name = "labelSet_GroupCd";
            this.labelSet_GroupCd.ShowAppendFlg = false;
            this.labelSet_GroupCd.Size = new System.Drawing.Size(453, 22);
            this.labelSet_GroupCd.SpaceCodeValue = 8;
            this.labelSet_GroupCd.SpaceNameCode = 4;
            this.labelSet_GroupCd.SpaceValueAppend = 4;
            this.labelSet_GroupCd.TabIndex = 6;
            this.labelSet_GroupCd.ValueLabelSize = 140;
            this.labelSet_GroupCd.ValueLabelText = "";
            this.labelSet_GroupCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtTantouKeyDown);
            // 
            // lblTantouCd
            // 
            this.lblTantouCd.AutoSize = true;
            this.lblTantouCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTantouCd.Location = new System.Drawing.Point(423, 120);
            this.lblTantouCd.Name = "lblTantouCd";
            this.lblTantouCd.Size = new System.Drawing.Size(103, 15);
            this.lblTantouCd.TabIndex = 89;
            this.lblTantouCd.Text = "担当者コード";
            this.lblTantouCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTantoushaCd
            // 
            this.txtTantoushaCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTantoushaCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTantoushaCd.Location = new System.Drawing.Point(532, 117);
            this.txtTantoushaCd.MaxLength = 4;
            this.txtTantoushaCd.Name = "txtTantoushaCd";
            this.txtTantoushaCd.Size = new System.Drawing.Size(40, 22);
            this.txtTantoushaCd.TabIndex = 0;
            this.txtTantoushaCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtTantouTxtKeyDown);
            this.txtTantoushaCd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtTantoushaKeyUp);
            this.txtTantoushaCd.Leave += new System.EventHandler(this.updTxtTantoushaLeave);
            // 
            // lblTantoushaName
            // 
            this.lblTantoushaName.AutoSize = true;
            this.lblTantoushaName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTantoushaName.Location = new System.Drawing.Point(740, 122);
            this.lblTantoushaName.Name = "lblTantoushaName";
            this.lblTantoushaName.Size = new System.Drawing.Size(71, 15);
            this.lblTantoushaName.TabIndex = 89;
            this.lblTantoushaName.Text = "担当者名";
            this.lblTantoushaName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTantoushaName
            // 
            this.txtTantoushaName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTantoushaName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTantoushaName.Location = new System.Drawing.Point(861, 117);
            this.txtTantoushaName.MaxLength = 12;
            this.txtTantoushaName.Name = "txtTantoushaName";
            this.txtTantoushaName.Size = new System.Drawing.Size(102, 22);
            this.txtTantoushaName.TabIndex = 1;
            this.txtTantoushaName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTantouTxtKeyDown);
            this.txtTantoushaName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtTantouNameKeyUp);
            // 
            // lblLoginID
            // 
            this.lblLoginID.AutoSize = true;
            this.lblLoginID.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblLoginID.Location = new System.Drawing.Point(740, 159);
            this.lblLoginID.Name = "lblLoginID";
            this.lblLoginID.Size = new System.Drawing.Size(103, 15);
            this.lblLoginID.TabIndex = 89;
            this.lblLoginID.Text = "ログインＩＤ";
            this.lblLoginID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoginID
            // 
            this.txtLoginID.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtLoginID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLoginID.Location = new System.Drawing.Point(861, 156);
            this.txtLoginID.MaxLength = 20;
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(166, 22);
            this.txtLoginID.TabIndex = 2;
            this.txtLoginID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTantouTxtKeyDown);
            this.txtLoginID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtLogInKeyUp);
            // 
            // lblChuban
            // 
            this.lblChuban.AutoSize = true;
            this.lblChuban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblChuban.Location = new System.Drawing.Point(740, 236);
            this.lblChuban.Name = "lblChuban";
            this.lblChuban.Size = new System.Drawing.Size(71, 15);
            this.lblChuban.TabIndex = 89;
            this.lblChuban.Text = "注番文字";
            this.lblChuban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChuban
            // 
            this.txtChuban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtChuban.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtChuban.Location = new System.Drawing.Point(861, 233);
            this.txtChuban.MaxLength = 3;
            this.txtChuban.Name = "txtChuban";
            this.txtChuban.Size = new System.Drawing.Size(39, 22);
            this.txtChuban.TabIndex = 5;
            this.txtChuban.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judtxtTantouKeyDown);
            this.txtChuban.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtChubanKeyUp);
            // 
            // lblMokuhyou
            // 
            this.lblMokuhyou.AutoSize = true;
            this.lblMokuhyou.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblMokuhyou.Location = new System.Drawing.Point(740, 315);
            this.lblMokuhyou.Name = "lblMokuhyou";
            this.lblMokuhyou.Size = new System.Drawing.Size(103, 15);
            this.lblMokuhyou.TabIndex = 89;
            this.lblMokuhyou.Text = "売上目標金額";
            this.lblMokuhyou.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMokuhyou
            // 
            this.txtMokuhyou.blnCommaOK = true;
            this.txtMokuhyou.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtMokuhyou.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMokuhyou.intDeciSet = 0;
            this.txtMokuhyou.intIntederSet = 0;
            this.txtMokuhyou.Location = new System.Drawing.Point(861, 312);
            this.txtMokuhyou.MaxLength = 0;
            this.txtMokuhyou.Name = "txtMokuhyou";
            this.txtMokuhyou.Size = new System.Drawing.Size(117, 22);
            this.txtMokuhyou.TabIndex = 7;
            this.txtMokuhyou.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMokuhyou.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTantouTxtKeyDown);
            // 
            // M1050_Tantousha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.txtMokuhyou);
            this.Controls.Add(this.lblMokuhyou);
            this.Controls.Add(this.txtChuban);
            this.Controls.Add(this.lblChuban);
            this.Controls.Add(this.txtLoginID);
            this.Controls.Add(this.lblLoginID);
            this.Controls.Add(this.txtTantoushaName);
            this.Controls.Add(this.lblTantoushaName);
            this.Controls.Add(this.txtTantoushaCd);
            this.Controls.Add(this.lblTantouCd);
            this.Controls.Add(this.labelSet_GroupCd);
            this.Controls.Add(this.labelSet_Eigyousho);
            this.Name = "M1050_Tantousha";
            this.Text = "M1050_Tantousha";
            this.Load += new System.EventHandler(this.M1050_Tantousha_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTantoushaKeyDown);
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
            this.Controls.SetChildIndex(this.labelSet_Eigyousho, 0);
            this.Controls.SetChildIndex(this.labelSet_GroupCd, 0);
            this.Controls.SetChildIndex(this.lblTantouCd, 0);
            this.Controls.SetChildIndex(this.txtTantoushaCd, 0);
            this.Controls.SetChildIndex(this.lblTantoushaName, 0);
            this.Controls.SetChildIndex(this.txtTantoushaName, 0);
            this.Controls.SetChildIndex(this.lblLoginID, 0);
            this.Controls.SetChildIndex(this.txtLoginID, 0);
            this.Controls.SetChildIndex(this.lblChuban, 0);
            this.Controls.SetChildIndex(this.txtChuban, 0);
            this.Controls.SetChildIndex(this.lblMokuhyou, 0);
            this.Controls.SetChildIndex(this.txtMokuhyou, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.LabelSet_Eigyosho labelSet_Eigyousho;
        private Common.Ctl.LabelSet_GroupCd labelSet_GroupCd;
        private Common.Ctl.BaseLabel lblTantouCd;
        private Common.Ctl.BaseText txtTantoushaCd;
        private Common.Ctl.BaseLabel lblTantoushaName;
        private Common.Ctl.BaseText txtTantoushaName;
        private Common.Ctl.BaseLabel lblLoginID;
        private Common.Ctl.BaseText txtLoginID;
        private Common.Ctl.BaseLabel lblChuban;
        private Common.Ctl.BaseText txtChuban;
        private Common.Ctl.BaseLabel lblMokuhyou;
        private Common.Ctl.BaseTextMoney txtMokuhyou;
    }
}