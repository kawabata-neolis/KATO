namespace KATO.Form.M1050_Tantousha
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
            this.lblSetEigyousho = new KATO.Common.Ctl.LabelSet_Eigyosho();
            this.lblSetGroupCd = new KATO.Common.Ctl.LabelSet_GroupCd();
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
            this.lblYakushokuCd = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblHyoji = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtYakushokuCd = new KATO.Common.Ctl.BaseText();
            this.txtHyoji = new KATO.Common.Ctl.BaseText();
            this.lblGrayYakushokuCdName = new KATO.Common.Ctl.BaseLabelGray();
            this.lblYakushokuMemo1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblYakushokuMemo2 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblHyojiMemo = new KATO.Common.Ctl.BaseLabel(this.components);
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF12
            // 
            this.btnF12.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF10
            // 
            this.btnF10.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF08
            // 
            this.btnF08.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF07
            // 
            this.btnF07.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF06
            // 
            this.btnF06.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF05
            // 
            this.btnF05.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF02
            // 
            this.btnF02.Click += new System.EventHandler(this.judBtnClick);
            // 
            // lblSetEigyousho
            // 
            this.lblSetEigyousho.AppendLabelSize = 0;
            this.lblSetEigyousho.AppendLabelText = "";
            this.lblSetEigyousho.CodeTxtSize = 40;
            this.lblSetEigyousho.CodeTxtText = "";
            this.lblSetEigyousho.LabelName = "営業所コード";
            this.lblSetEigyousho.Location = new System.Drawing.Point(738, 195);
            this.lblSetEigyousho.Name = "lblSetEigyousho";
            this.lblSetEigyousho.ShowAppendFlg = false;
            this.lblSetEigyousho.Size = new System.Drawing.Size(453, 22);
            this.lblSetEigyousho.SpaceCodeValue = 8;
            this.lblSetEigyousho.SpaceNameCode = 20;
            this.lblSetEigyousho.SpaceValueAppend = 4;
            this.lblSetEigyousho.TabIndex = 3;
            this.lblSetEigyousho.ValueLabelSize = 140;
            this.lblSetEigyousho.ValueLabelText = "";
            this.lblSetEigyousho.Leave += new System.EventHandler(this.labelSet_Eigyousho_Leave);
            // 
            // lblSetGroupCd
            // 
            this.lblSetGroupCd.AppendLabelSize = 0;
            this.lblSetGroupCd.AppendLabelText = "";
            this.lblSetGroupCd.CodeTxtSize = 40;
            this.lblSetGroupCd.CodeTxtText = "";
            this.lblSetGroupCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lblSetGroupCd.LabelName = "グループコード";
            this.lblSetGroupCd.Location = new System.Drawing.Point(738, 272);
            this.lblSetGroupCd.LsGroupCddata = null;
            this.lblSetGroupCd.Name = "lblSetGroupCd";
            this.lblSetGroupCd.ShowAppendFlg = false;
            this.lblSetGroupCd.Size = new System.Drawing.Size(453, 22);
            this.lblSetGroupCd.SpaceCodeValue = 8;
            this.lblSetGroupCd.SpaceNameCode = 4;
            this.lblSetGroupCd.SpaceValueAppend = 4;
            this.lblSetGroupCd.TabIndex = 6;
            this.lblSetGroupCd.ValueLabelSize = 140;
            this.lblSetGroupCd.ValueLabelText = "";
            this.lblSetGroupCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.setTxtTantoushaLeave);
            this.lblSetGroupCd.Leave += new System.EventHandler(this.labelSet_GroupCd_Leave);
            // 
            // lblTantouCd
            // 
            this.lblTantouCd.AutoSize = true;
            this.lblTantouCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTantouCd.Location = new System.Drawing.Point(423, 120);
            this.lblTantouCd.Name = "lblTantouCd";
            this.lblTantouCd.Size = new System.Drawing.Size(103, 15);
            this.lblTantouCd.strToolTip = null;
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
            this.txtTantoushaCd.Leave += new System.EventHandler(this.setTxtTantoushaLeave);
            // 
            // lblTantoushaName
            // 
            this.lblTantoushaName.AutoSize = true;
            this.lblTantoushaName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTantoushaName.Location = new System.Drawing.Point(740, 122);
            this.lblTantoushaName.Name = "lblTantoushaName";
            this.lblTantoushaName.Size = new System.Drawing.Size(71, 15);
            this.lblTantoushaName.strToolTip = null;
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
            this.txtTantoushaName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtTantoushaKeyUp);
            // 
            // lblLoginID
            // 
            this.lblLoginID.AutoSize = true;
            this.lblLoginID.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblLoginID.Location = new System.Drawing.Point(740, 159);
            this.lblLoginID.Name = "lblLoginID";
            this.lblLoginID.Size = new System.Drawing.Size(103, 15);
            this.lblLoginID.strToolTip = null;
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
            this.txtLoginID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtTantoushaKeyUp);
            // 
            // lblChuban
            // 
            this.lblChuban.AutoSize = true;
            this.lblChuban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblChuban.Location = new System.Drawing.Point(740, 236);
            this.lblChuban.Name = "lblChuban";
            this.lblChuban.Size = new System.Drawing.Size(71, 15);
            this.lblChuban.strToolTip = null;
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
            this.txtChuban.Size = new System.Drawing.Size(30, 22);
            this.txtChuban.TabIndex = 5;
            this.txtChuban.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTantouTxtKeyDown);
            this.txtChuban.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtTantoushaKeyUp);
            // 
            // lblMokuhyou
            // 
            this.lblMokuhyou.AutoSize = true;
            this.lblMokuhyou.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblMokuhyou.Location = new System.Drawing.Point(740, 315);
            this.lblMokuhyou.Name = "lblMokuhyou";
            this.lblMokuhyou.Size = new System.Drawing.Size(103, 15);
            this.lblMokuhyou.strToolTip = null;
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
            this.txtMokuhyou.intShishagonyu = 0;
            this.txtMokuhyou.Location = new System.Drawing.Point(861, 312);
            this.txtMokuhyou.MaxLength = 0;
            this.txtMokuhyou.Name = "txtMokuhyou";
            this.txtMokuhyou.Size = new System.Drawing.Size(117, 22);
            this.txtMokuhyou.TabIndex = 7;
            this.txtMokuhyou.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMokuhyou.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTantouTxtKeyDown);
            // 
            // lblYakushokuCd
            // 
            this.lblYakushokuCd.AutoSize = true;
            this.lblYakushokuCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblYakushokuCd.Location = new System.Drawing.Point(740, 355);
            this.lblYakushokuCd.Name = "lblYakushokuCd";
            this.lblYakushokuCd.Size = new System.Drawing.Size(87, 15);
            this.lblYakushokuCd.strToolTip = null;
            this.lblYakushokuCd.TabIndex = 89;
            this.lblYakushokuCd.Text = "役職コード";
            this.lblYakushokuCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHyoji
            // 
            this.lblHyoji.AutoSize = true;
            this.lblHyoji.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHyoji.Location = new System.Drawing.Point(740, 394);
            this.lblHyoji.Name = "lblHyoji";
            this.lblHyoji.Size = new System.Drawing.Size(71, 15);
            this.lblHyoji.strToolTip = null;
            this.lblHyoji.TabIndex = 89;
            this.lblHyoji.Text = "表示設定";
            this.lblHyoji.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtYakushokuCd
            // 
            this.txtYakushokuCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtYakushokuCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtYakushokuCd.Location = new System.Drawing.Point(861, 352);
            this.txtYakushokuCd.MaxLength = 2;
            this.txtYakushokuCd.Name = "txtYakushokuCd";
            this.txtYakushokuCd.Size = new System.Drawing.Size(30, 22);
            this.txtYakushokuCd.TabIndex = 8;
            this.txtYakushokuCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTantouTxtKeyDown);
            this.txtYakushokuCd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtTantoushaKeyUp);
            this.txtYakushokuCd.Leave += new System.EventHandler(this.txtYakushokuCd_Leave);
            // 
            // txtHyoji
            // 
            this.txtHyoji.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHyoji.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtHyoji.Location = new System.Drawing.Point(861, 391);
            this.txtHyoji.MaxLength = 1;
            this.txtHyoji.Name = "txtHyoji";
            this.txtHyoji.Size = new System.Drawing.Size(30, 22);
            this.txtHyoji.TabIndex = 9;
            this.txtHyoji.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTantouTxtKeyDown);
            this.txtHyoji.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtTantoushaKeyUp);
            // 
            // lblGrayYakushokuCdName
            // 
            this.lblGrayYakushokuCdName.AutoEllipsis = true;
            this.lblGrayYakushokuCdName.BackColor = System.Drawing.Color.Gainsboro;
            this.lblGrayYakushokuCdName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblGrayYakushokuCdName.ForeColor = System.Drawing.Color.Blue;
            this.lblGrayYakushokuCdName.Location = new System.Drawing.Point(908, 352);
            this.lblGrayYakushokuCdName.Name = "lblGrayYakushokuCdName";
            this.lblGrayYakushokuCdName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblGrayYakushokuCdName.Size = new System.Drawing.Size(119, 22);
            this.lblGrayYakushokuCdName.TabIndex = 99;
            this.lblGrayYakushokuCdName.Text = "           ";
            this.lblGrayYakushokuCdName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblYakushokuMemo1
            // 
            this.lblYakushokuMemo1.AutoSize = true;
            this.lblYakushokuMemo1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblYakushokuMemo1.Location = new System.Drawing.Point(1053, 355);
            this.lblYakushokuMemo1.Name = "lblYakushokuMemo1";
            this.lblYakushokuMemo1.Size = new System.Drawing.Size(271, 15);
            this.lblYakushokuMemo1.strToolTip = null;
            this.lblYakushokuMemo1.TabIndex = 100;
            this.lblYakushokuMemo1.Text = "00：取締役  10：部長  20：ﾏﾈｰｼﾞｬｰ";
            this.lblYakushokuMemo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblYakushokuMemo2
            // 
            this.lblYakushokuMemo2.AutoSize = true;
            this.lblYakushokuMemo2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblYakushokuMemo2.Location = new System.Drawing.Point(1053, 373);
            this.lblYakushokuMemo2.Name = "lblYakushokuMemo2";
            this.lblYakushokuMemo2.Size = new System.Drawing.Size(335, 15);
            this.lblYakushokuMemo2.strToolTip = null;
            this.lblYakushokuMemo2.TabIndex = 100;
            this.lblYakushokuMemo2.Text = "30：営業担当  40：ﾘｰﾀﾞｰ  50：営業事務担当";
            this.lblYakushokuMemo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHyojiMemo
            // 
            this.lblHyojiMemo.AutoSize = true;
            this.lblHyojiMemo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblHyojiMemo.Location = new System.Drawing.Point(911, 395);
            this.lblHyojiMemo.Name = "lblHyojiMemo";
            this.lblHyojiMemo.Size = new System.Drawing.Size(151, 15);
            this.lblHyojiMemo.strToolTip = null;
            this.lblHyojiMemo.TabIndex = 100;
            this.lblHyojiMemo.Text = "0：非表示  1：表示";
            this.lblHyojiMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // M1050_Tantousha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.lblHyojiMemo);
            this.Controls.Add(this.lblYakushokuMemo2);
            this.Controls.Add(this.lblYakushokuMemo1);
            this.Controls.Add(this.lblGrayYakushokuCdName);
            this.Controls.Add(this.txtMokuhyou);
            this.Controls.Add(this.lblHyoji);
            this.Controls.Add(this.lblYakushokuCd);
            this.Controls.Add(this.lblMokuhyou);
            this.Controls.Add(this.txtHyoji);
            this.Controls.Add(this.txtYakushokuCd);
            this.Controls.Add(this.txtChuban);
            this.Controls.Add(this.lblChuban);
            this.Controls.Add(this.txtLoginID);
            this.Controls.Add(this.lblLoginID);
            this.Controls.Add(this.txtTantoushaName);
            this.Controls.Add(this.lblTantoushaName);
            this.Controls.Add(this.txtTantoushaCd);
            this.Controls.Add(this.lblTantouCd);
            this.Controls.Add(this.lblSetGroupCd);
            this.Controls.Add(this.lblSetEigyousho);
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
            this.Controls.SetChildIndex(this.lblSetEigyousho, 0);
            this.Controls.SetChildIndex(this.lblSetGroupCd, 0);
            this.Controls.SetChildIndex(this.lblTantouCd, 0);
            this.Controls.SetChildIndex(this.txtTantoushaCd, 0);
            this.Controls.SetChildIndex(this.lblTantoushaName, 0);
            this.Controls.SetChildIndex(this.txtTantoushaName, 0);
            this.Controls.SetChildIndex(this.lblLoginID, 0);
            this.Controls.SetChildIndex(this.txtLoginID, 0);
            this.Controls.SetChildIndex(this.lblChuban, 0);
            this.Controls.SetChildIndex(this.txtChuban, 0);
            this.Controls.SetChildIndex(this.txtYakushokuCd, 0);
            this.Controls.SetChildIndex(this.txtHyoji, 0);
            this.Controls.SetChildIndex(this.lblMokuhyou, 0);
            this.Controls.SetChildIndex(this.lblYakushokuCd, 0);
            this.Controls.SetChildIndex(this.lblHyoji, 0);
            this.Controls.SetChildIndex(this.txtMokuhyou, 0);
            this.Controls.SetChildIndex(this.lblGrayYakushokuCdName, 0);
            this.Controls.SetChildIndex(this.lblYakushokuMemo1, 0);
            this.Controls.SetChildIndex(this.lblYakushokuMemo2, 0);
            this.Controls.SetChildIndex(this.lblHyojiMemo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.LabelSet_Eigyosho lblSetEigyousho;
        private Common.Ctl.LabelSet_GroupCd lblSetGroupCd;
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
        private Common.Ctl.BaseLabel lblYakushokuCd;
        private Common.Ctl.BaseLabel lblHyoji;
        private Common.Ctl.BaseText txtYakushokuCd;
        private Common.Ctl.BaseText txtHyoji;
        private Common.Ctl.BaseLabelGray lblGrayYakushokuCdName;
        private Common.Ctl.BaseLabel lblYakushokuMemo1;
        private Common.Ctl.BaseLabel lblYakushokuMemo2;
        private Common.Ctl.BaseLabel lblHyojiMemo;
    }
}