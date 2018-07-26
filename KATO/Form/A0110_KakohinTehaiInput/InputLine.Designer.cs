namespace KATO.Form.A0110_KakohinTehaiInput
{
    partial class InputLine
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtNoki = new KATO.Common.Ctl.BaseCalendar();
            this.lsSouko = new KATO.Common.Ctl.LabelSet_Eigyosho();
            this.nameLabel = new KATO.Common.Ctl.BaseLabel(this.components);
            this.baseLabel1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtBiko = new KATO.Common.Ctl.BaseText();
            this.txtTanka = new KATO.Common.Ctl.BaseTextMoney();
            this.txtSuryo = new KATO.Common.Ctl.BaseTextMoney();
            this.txtHinban = new KATO.Common.Ctl.BaseText();
            this.txtKensaku = new KATO.Common.Ctl.BaseText();
            this.lsMaker = new KATO.Common.Ctl.LabelSet_Maker();
            this.object_72ace247_2dcb_4894_9365_255297a2ba20 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.object_16250cff_7230_44f3_842f_fd819887511a = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lsChubun = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.object_f6f9769c_6a4e_4231_9798_010cb76ef761 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.object_5357f72f_309f_499c_9924_e562eb697910 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lsDaibun = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.object_7a1282db_a948_4a8e_99e2_c85108048256 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtNo = new KATO.Common.Ctl.BaseTextMoney();
            this.lsSouko.SuspendLayout();
            this.lsMaker.SuspendLayout();
            this.lsChubun.SuspendLayout();
            this.lsDaibun.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNoki
            // 
            this.txtNoki.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtNoki.Location = new System.Drawing.Point(1430, 1);
            this.txtNoki.Name = "txtNoki";
            this.txtNoki.Size = new System.Drawing.Size(100, 22);
            this.txtNoki.TabIndex = 10;
            // 
            // lsSouko
            // 
            this.lsSouko.AppendLabelSize = 0;
            this.lsSouko.AppendLabelText = "";
            this.lsSouko.CodeTxtSize = 40;
            this.lsSouko.CodeTxtText = "";
            this.lsSouko.Controls.Add(this.nameLabel);
            this.lsSouko.Controls.Add(this.baseLabel1);
            this.lsSouko.LabelName = "";
            this.lsSouko.Location = new System.Drawing.Point(1430, 1);
            this.lsSouko.Name = "lsSouko";
            this.lsSouko.ShowAppendFlg = false;
            this.lsSouko.Size = new System.Drawing.Size(121, 22);
            this.lsSouko.SpaceCodeValue = 4;
            this.lsSouko.SpaceNameCode = 0;
            this.lsSouko.SpaceValueAppend = 4;
            this.lsSouko.TabIndex = 9;
            this.lsSouko.ValueLabelSize = 250;
            this.lsSouko.ValueLabelText = "";
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
            // txtBiko
            // 
            this.txtBiko.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtBiko.Location = new System.Drawing.Point(1255, 1);
            this.txtBiko.Name = "txtBiko";
            this.txtBiko.Size = new System.Drawing.Size(169, 22);
            this.txtBiko.TabIndex = 8;
            this.txtBiko.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyDown);
            // 
            // txtTanka
            // 
            this.txtTanka.blnCommaOK = true;
            this.txtTanka.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTanka.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTanka.intDeciSet = 2;
            this.txtTanka.intIntederSet = 12;
            this.txtTanka.intShishagonyu = 0;
            this.txtTanka.Location = new System.Drawing.Point(1143, 1);
            this.txtTanka.MaxLength = 15;
            this.txtTanka.MinusFlg = true;
            this.txtTanka.Name = "txtTanka";
            this.txtTanka.Size = new System.Drawing.Size(106, 22);
            this.txtTanka.TabIndex = 7;
            this.txtTanka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTanka.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyDown);
            // 
            // txtSuryo
            // 
            this.txtSuryo.blnCommaOK = true;
            this.txtSuryo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtSuryo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSuryo.intDeciSet = 0;
            this.txtSuryo.intIntederSet = 8;
            this.txtSuryo.intShishagonyu = 0;
            this.txtSuryo.Location = new System.Drawing.Point(1072, 1);
            this.txtSuryo.MaxLength = 8;
            this.txtSuryo.MinusFlg = true;
            this.txtSuryo.Name = "txtSuryo";
            this.txtSuryo.Size = new System.Drawing.Size(65, 22);
            this.txtSuryo.TabIndex = 6;
            this.txtSuryo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSuryo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyDown);
            // 
            // txtHinban
            // 
            this.txtHinban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtHinban.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtHinban.Location = new System.Drawing.Point(628, 1);
            this.txtHinban.Name = "txtHinban";
            this.txtHinban.Size = new System.Drawing.Size(438, 22);
            this.txtHinban.TabIndex = 5;
            this.txtHinban.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyDown);
            // 
            // txtKensaku
            // 
            this.txtKensaku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKensaku.Location = new System.Drawing.Point(513, 1);
            this.txtKensaku.Name = "txtKensaku";
            this.txtKensaku.Size = new System.Drawing.Size(109, 22);
            this.txtKensaku.TabIndex = 4;
            this.txtKensaku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyDown);
            this.txtKensaku.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.serchKeyDown);
            // 
            // lsMaker
            // 
            this.lsMaker.AppendLabelSize = 0;
            this.lsMaker.AppendLabelText = "";
            this.lsMaker.CodeTxtSize = 40;
            this.lsMaker.CodeTxtText = "";
            this.lsMaker.Controls.Add(this.object_72ace247_2dcb_4894_9365_255297a2ba20);
            this.lsMaker.Controls.Add(this.object_16250cff_7230_44f3_842f_fd819887511a);
            this.lsMaker.LabelName = "";
            this.lsMaker.Location = new System.Drawing.Point(341, 1);
            this.lsMaker.Name = "lsMaker";
            this.lsMaker.ShowAppendFlg = false;
            this.lsMaker.Size = new System.Drawing.Size(166, 22);
            this.lsMaker.SpaceCodeValue = 4;
            this.lsMaker.SpaceNameCode = 0;
            this.lsMaker.SpaceValueAppend = 4;
            this.lsMaker.strDaibunCd = null;
            this.lsMaker.TabIndex = 3;
            this.lsMaker.ValueLabelSize = 200;
            this.lsMaker.ValueLabelText = "";
            // 
            // object_72ace247_2dcb_4894_9365_255297a2ba20
            // 
            this.object_72ace247_2dcb_4894_9365_255297a2ba20.AutoSize = true;
            this.object_72ace247_2dcb_4894_9365_255297a2ba20.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_72ace247_2dcb_4894_9365_255297a2ba20.Location = new System.Drawing.Point(2, 3);
            this.object_72ace247_2dcb_4894_9365_255297a2ba20.Name = "object_72ace247_2dcb_4894_9365_255297a2ba20";
            this.object_72ace247_2dcb_4894_9365_255297a2ba20.Size = new System.Drawing.Size(0, 15);
            this.object_72ace247_2dcb_4894_9365_255297a2ba20.strToolTip = null;
            this.object_72ace247_2dcb_4894_9365_255297a2ba20.TabIndex = 0;
            this.object_72ace247_2dcb_4894_9365_255297a2ba20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // object_16250cff_7230_44f3_842f_fd819887511a
            // 
            this.object_16250cff_7230_44f3_842f_fd819887511a.AutoSize = true;
            this.object_16250cff_7230_44f3_842f_fd819887511a.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_16250cff_7230_44f3_842f_fd819887511a.Location = new System.Drawing.Point(2, 3);
            this.object_16250cff_7230_44f3_842f_fd819887511a.Name = "object_16250cff_7230_44f3_842f_fd819887511a";
            this.object_16250cff_7230_44f3_842f_fd819887511a.Size = new System.Drawing.Size(0, 15);
            this.object_16250cff_7230_44f3_842f_fd819887511a.strToolTip = null;
            this.object_16250cff_7230_44f3_842f_fd819887511a.TabIndex = 0;
            this.object_16250cff_7230_44f3_842f_fd819887511a.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lsChubun
            // 
            this.lsChubun.AppendLabelSize = 0;
            this.lsChubun.AppendLabelText = "";
            this.lsChubun.CodeTxtSize = 24;
            this.lsChubun.CodeTxtText = "";
            this.lsChubun.Controls.Add(this.object_f6f9769c_6a4e_4231_9798_010cb76ef761);
            this.lsChubun.Controls.Add(this.object_5357f72f_309f_499c_9924_e562eb697910);
            this.lsChubun.LabelName = "";
            this.lsChubun.Location = new System.Drawing.Point(189, 1);
            this.lsChubun.Name = "lsChubun";
            this.lsChubun.ShowAppendFlg = false;
            this.lsChubun.Size = new System.Drawing.Size(146, 22);
            this.lsChubun.SpaceCodeValue = 4;
            this.lsChubun.SpaceNameCode = 0;
            this.lsChubun.SpaceValueAppend = 4;
            this.lsChubun.strDaibunCd = null;
            this.lsChubun.TabIndex = 2;
            this.lsChubun.ValueLabelSize = 200;
            this.lsChubun.ValueLabelText = "";
            // 
            // object_f6f9769c_6a4e_4231_9798_010cb76ef761
            // 
            this.object_f6f9769c_6a4e_4231_9798_010cb76ef761.AutoSize = true;
            this.object_f6f9769c_6a4e_4231_9798_010cb76ef761.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_f6f9769c_6a4e_4231_9798_010cb76ef761.Location = new System.Drawing.Point(2, 3);
            this.object_f6f9769c_6a4e_4231_9798_010cb76ef761.Name = "object_f6f9769c_6a4e_4231_9798_010cb76ef761";
            this.object_f6f9769c_6a4e_4231_9798_010cb76ef761.Size = new System.Drawing.Size(0, 15);
            this.object_f6f9769c_6a4e_4231_9798_010cb76ef761.strToolTip = null;
            this.object_f6f9769c_6a4e_4231_9798_010cb76ef761.TabIndex = 0;
            this.object_f6f9769c_6a4e_4231_9798_010cb76ef761.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // object_5357f72f_309f_499c_9924_e562eb697910
            // 
            this.object_5357f72f_309f_499c_9924_e562eb697910.AutoSize = true;
            this.object_5357f72f_309f_499c_9924_e562eb697910.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_5357f72f_309f_499c_9924_e562eb697910.Location = new System.Drawing.Point(2, 3);
            this.object_5357f72f_309f_499c_9924_e562eb697910.Name = "object_5357f72f_309f_499c_9924_e562eb697910";
            this.object_5357f72f_309f_499c_9924_e562eb697910.Size = new System.Drawing.Size(0, 15);
            this.object_5357f72f_309f_499c_9924_e562eb697910.strToolTip = null;
            this.object_5357f72f_309f_499c_9924_e562eb697910.TabIndex = 0;
            this.object_5357f72f_309f_499c_9924_e562eb697910.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lsDaibun
            // 
            this.lsDaibun.AppendLabelSize = 0;
            this.lsDaibun.AppendLabelText = "";
            this.lsDaibun.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lsDaibun.CodeTxtSize = 24;
            this.lsDaibun.CodeTxtText = "";
            this.lsDaibun.Controls.Add(this.object_7a1282db_a948_4a8e_99e2_c85108048256);
            this.lsDaibun.Controls.Add(this.object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e);
            this.lsDaibun.LabelName = "";
            this.lsDaibun.Location = new System.Drawing.Point(37, 1);
            this.lsDaibun.Lschubundata = null;
            this.lsDaibun.Lsmakerdata = null;
            this.lsDaibun.LsSubchubundata = null;
            this.lsDaibun.LsSubmakerdata = null;
            this.lsDaibun.Name = "lsDaibun";
            this.lsDaibun.ShowAppendFlg = false;
            this.lsDaibun.Size = new System.Drawing.Size(146, 22);
            this.lsDaibun.SpaceCodeValue = 4;
            this.lsDaibun.SpaceNameCode = 0;
            this.lsDaibun.SpaceValueAppend = 4;
            this.lsDaibun.TabIndex = 1;
            this.lsDaibun.ValueLabelSize = 200;
            this.lsDaibun.ValueLabelText = "";
            // 
            // object_7a1282db_a948_4a8e_99e2_c85108048256
            // 
            this.object_7a1282db_a948_4a8e_99e2_c85108048256.AutoSize = true;
            this.object_7a1282db_a948_4a8e_99e2_c85108048256.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_7a1282db_a948_4a8e_99e2_c85108048256.Location = new System.Drawing.Point(2, 3);
            this.object_7a1282db_a948_4a8e_99e2_c85108048256.Name = "object_7a1282db_a948_4a8e_99e2_c85108048256";
            this.object_7a1282db_a948_4a8e_99e2_c85108048256.Size = new System.Drawing.Size(0, 15);
            this.object_7a1282db_a948_4a8e_99e2_c85108048256.strToolTip = null;
            this.object_7a1282db_a948_4a8e_99e2_c85108048256.TabIndex = 0;
            this.object_7a1282db_a948_4a8e_99e2_c85108048256.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e
            // 
            this.object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e.AutoSize = true;
            this.object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e.Location = new System.Drawing.Point(2, 3);
            this.object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e.Name = "object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e";
            this.object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e.Size = new System.Drawing.Size(0, 15);
            this.object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e.strToolTip = null;
            this.object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e.TabIndex = 0;
            this.object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNo
            // 
            this.txtNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtNo.blnCommaOK = true;
            this.txtNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtNo.intDeciSet = 0;
            this.txtNo.intIntederSet = 0;
            this.txtNo.intShishagonyu = 0;
            this.txtNo.Location = new System.Drawing.Point(7, 1);
            this.txtNo.MaxLength = 0;
            this.txtNo.MinusFlg = true;
            this.txtNo.Name = "txtNo";
            this.txtNo.ReadOnly = true;
            this.txtNo.Size = new System.Drawing.Size(24, 22);
            this.txtNo.TabIndex = 0;
            this.txtNo.TabStop = false;
            this.txtNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // InputLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNoki);
            this.Controls.Add(this.lsSouko);
            this.Controls.Add(this.txtBiko);
            this.Controls.Add(this.txtTanka);
            this.Controls.Add(this.txtSuryo);
            this.Controls.Add(this.txtHinban);
            this.Controls.Add(this.txtKensaku);
            this.Controls.Add(this.lsMaker);
            this.Controls.Add(this.lsChubun);
            this.Controls.Add(this.lsDaibun);
            this.Controls.Add(this.txtNo);
            this.Name = "InputLine";
            this.Size = new System.Drawing.Size(1558, 24);
            this.lsSouko.ResumeLayout(false);
            this.lsSouko.PerformLayout();
            this.lsMaker.ResumeLayout(false);
            this.lsMaker.PerformLayout();
            this.lsChubun.ResumeLayout(false);
            this.lsChubun.PerformLayout();
            this.lsDaibun.ResumeLayout(false);
            this.lsDaibun.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.Ctl.BaseLabel nameLabel;
        private Common.Ctl.BaseLabel baseLabel1;
        private Common.Ctl.BaseLabel object_72ace247_2dcb_4894_9365_255297a2ba20;
        private Common.Ctl.BaseLabel object_16250cff_7230_44f3_842f_fd819887511a;
        private Common.Ctl.BaseLabel object_f6f9769c_6a4e_4231_9798_010cb76ef761;
        private Common.Ctl.BaseLabel object_5357f72f_309f_499c_9924_e562eb697910;
        private Common.Ctl.BaseLabel object_7a1282db_a948_4a8e_99e2_c85108048256;
        private Common.Ctl.BaseLabel object_ba2e7b7d_47be_4484_87ab_4e0eb0513e7e;
        public Common.Ctl.LabelSet_Eigyosho lsSouko;
        public Common.Ctl.BaseText txtBiko;
        public Common.Ctl.BaseTextMoney txtTanka;
        public Common.Ctl.BaseTextMoney txtSuryo;
        public Common.Ctl.BaseText txtHinban;
        public Common.Ctl.BaseText txtKensaku;
        public Common.Ctl.LabelSet_Maker lsMaker;
        public Common.Ctl.LabelSet_Chubunrui lsChubun;
        public Common.Ctl.LabelSet_Daibunrui lsDaibun;
        public Common.Ctl.BaseTextMoney txtNo;
        public Common.Ctl.BaseCalendar txtNoki;
    }
}
