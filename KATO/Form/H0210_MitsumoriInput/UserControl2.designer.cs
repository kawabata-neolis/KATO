namespace KATO.Form.H0210_MitsumoriInput
{
    partial class UserControl2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtHin = new System.Windows.Forms.TextBox();
            this.lsDaibun = new KATO.Common.Ctl.LabelSet_Daibunrui();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsChubun = new KATO.Common.Ctl.LabelSet_Chubunrui();
            this.lsMaker = new KATO.Common.Ctl.LabelSet_Maker();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(855, 31);
            this.tableLayoutPanel1.TabIndex = 300;
            // 
            // txtHin
            // 
            this.txtHin.BackColor = System.Drawing.SystemColors.Window;
            this.txtHin.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtHin.Location = new System.Drawing.Point(11, 4);
            this.txtHin.Name = "txtHin";
            this.txtHin.ReadOnly = true;
            this.txtHin.Size = new System.Drawing.Size(310, 22);
            this.txtHin.TabIndex = 235;
            this.txtHin.TabStop = false;
            // 
            // lsDaibun
            // 
            this.lsDaibun.AppendLabelSize = 0;
            this.lsDaibun.AppendLabelText = "";
            this.lsDaibun.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lsDaibun.CodeTxtSize = 30;
            this.lsDaibun.CodeTxtText = "";
            this.lsDaibun.LabelName = "";
            this.lsDaibun.Location = new System.Drawing.Point(327, 4);
            this.lsDaibun.Lschubundata = null;
            this.lsDaibun.Lsmakerdata = null;
            this.lsDaibun.LsSubchubundata = null;
            this.lsDaibun.LsSubmakerdata = null;
            this.lsDaibun.Name = "lsDaibun";
            this.lsDaibun.ShowAppendFlg = false;
            this.lsDaibun.Size = new System.Drawing.Size(166, 22);
            this.lsDaibun.SpaceCodeValue = 4;
            this.lsDaibun.SpaceNameCode = 4;
            this.lsDaibun.SpaceValueAppend = 4;
            this.lsDaibun.TabIndex = 242;
            this.lsDaibun.ValueLabelSize = 130;
            this.lsDaibun.ValueLabelText = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lsMaker);
            this.panel1.Controls.Add(this.lsChubun);
            this.panel1.Controls.Add(this.lsDaibun);
            this.panel1.Controls.Add(this.txtHin);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(855, 31);
            this.panel1.TabIndex = 0;
            // 
            // lsChubun
            // 
            this.lsChubun.AppendLabelSize = 0;
            this.lsChubun.AppendLabelText = "";
            this.lsChubun.CodeTxtSize = 30;
            this.lsChubun.CodeTxtText = "";
            this.lsChubun.LabelName = "";
            this.lsChubun.Location = new System.Drawing.Point(499, 4);
            this.lsChubun.Name = "lsChubun";
            this.lsChubun.ShowAppendFlg = false;
            this.lsChubun.Size = new System.Drawing.Size(160, 22);
            this.lsChubun.SpaceCodeValue = 4;
            this.lsChubun.SpaceNameCode = 4;
            this.lsChubun.SpaceValueAppend = 4;
            this.lsChubun.strDaibunCd = null;
            this.lsChubun.TabIndex = 243;
            this.lsChubun.ValueLabelSize = 120;
            this.lsChubun.ValueLabelText = "";
            // 
            // lsMaker
            // 
            this.lsMaker.AppendLabelSize = 0;
            this.lsMaker.AppendLabelText = "";
            this.lsMaker.CodeTxtSize = 40;
            this.lsMaker.CodeTxtText = "";
            this.lsMaker.LabelName = "";
            this.lsMaker.Location = new System.Drawing.Point(665, 4);
            this.lsMaker.Name = "lsMaker";
            this.lsMaker.ShowAppendFlg = false;
            this.lsMaker.Size = new System.Drawing.Size(180, 22);
            this.lsMaker.SpaceCodeValue = 4;
            this.lsMaker.SpaceNameCode = 4;
            this.lsMaker.SpaceValueAppend = 4;
            this.lsMaker.strDaibunCd = null;
            this.lsMaker.TabIndex = 244;
            this.lsMaker.ValueLabelSize = 130;
            this.lsMaker.ValueLabelText = "";
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(855, 31);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtHin;
        public Common.Ctl.LabelSet_Daibunrui lsDaibun;
        public Common.Ctl.LabelSet_Chubunrui lsChubun;
        public Common.Ctl.LabelSet_Maker lsMaker;
    }
}
