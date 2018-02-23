namespace KATO.Common.Ctl
{
    partial class BaseForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusHeader = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnF12 = new System.Windows.Forms.Button();
            this.btnF11 = new System.Windows.Forms.Button();
            this.btnF10 = new System.Windows.Forms.Button();
            this.btnF09 = new System.Windows.Forms.Button();
            this.btnF08 = new System.Windows.Forms.Button();
            this.btnF07 = new System.Windows.Forms.Button();
            this.btnF06 = new System.Windows.Forms.Button();
            this.btnF05 = new System.Windows.Forms.Button();
            this.btnF04 = new System.Windows.Forms.Button();
            this.btnF03 = new System.Windows.Forms.Button();
            this.btnF02 = new System.Windows.Forms.Button();
            this.btnF01 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbSubWinShow = new System.Windows.Forms.ComboBox();
            this.lblSubWinSHow = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusHeader,
            this.lblStatusMessage,
            this.lblStatusUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 804);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1424, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusHeader
            // 
            this.lblStatusHeader.AutoSize = false;
            this.lblStatusHeader.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatusHeader.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblStatusHeader.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatusHeader.Name = "lblStatusHeader";
            this.lblStatusHeader.Size = new System.Drawing.Size(60, 17);
            this.lblStatusHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.AutoSize = false;
            this.lblStatusMessage.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatusMessage.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(1349, 17);
            this.lblStatusMessage.Spring = true;
            this.lblStatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusUser
            // 
            this.lblStatusUser.AutoSize = false;
            this.lblStatusUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatusUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblStatusUser.Name = "lblStatusUser";
            this.lblStatusUser.Size = new System.Drawing.Size(160, 17);
            this.lblStatusUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF12.Location = new System.Drawing.Point(1302, 783);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(117, 23);
            this.btnF12.TabIndex = 84;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF12.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF11.Location = new System.Drawing.Point(1184, 783);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(117, 23);
            this.btnF11.TabIndex = 83;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF11.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // btnF10
            // 
            this.btnF10.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF10.Location = new System.Drawing.Point(1066, 783);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(117, 23);
            this.btnF10.TabIndex = 82;
            this.btnF10.UseVisualStyleBackColor = true;
            this.btnF10.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF10.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // btnF09
            // 
            this.btnF09.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF09.Location = new System.Drawing.Point(948, 783);
            this.btnF09.Name = "btnF09";
            this.btnF09.Size = new System.Drawing.Size(117, 23);
            this.btnF09.TabIndex = 81;
            this.btnF09.UseVisualStyleBackColor = true;
            this.btnF09.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF09.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // btnF08
            // 
            this.btnF08.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF08.Location = new System.Drawing.Point(830, 783);
            this.btnF08.Name = "btnF08";
            this.btnF08.Size = new System.Drawing.Size(117, 23);
            this.btnF08.TabIndex = 80;
            this.btnF08.UseVisualStyleBackColor = true;
            this.btnF08.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF08.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // btnF07
            // 
            this.btnF07.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF07.Location = new System.Drawing.Point(712, 783);
            this.btnF07.Name = "btnF07";
            this.btnF07.Size = new System.Drawing.Size(117, 23);
            this.btnF07.TabIndex = 79;
            this.btnF07.UseVisualStyleBackColor = true;
            this.btnF07.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF07.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // btnF06
            // 
            this.btnF06.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF06.Location = new System.Drawing.Point(594, 783);
            this.btnF06.Name = "btnF06";
            this.btnF06.Size = new System.Drawing.Size(117, 23);
            this.btnF06.TabIndex = 78;
            this.btnF06.UseVisualStyleBackColor = true;
            this.btnF06.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF06.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // btnF05
            // 
            this.btnF05.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF05.Location = new System.Drawing.Point(476, 783);
            this.btnF05.Name = "btnF05";
            this.btnF05.Size = new System.Drawing.Size(117, 23);
            this.btnF05.TabIndex = 77;
            this.btnF05.UseVisualStyleBackColor = true;
            this.btnF05.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF05.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // btnF04
            // 
            this.btnF04.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF04.Location = new System.Drawing.Point(358, 783);
            this.btnF04.Name = "btnF04";
            this.btnF04.Size = new System.Drawing.Size(117, 23);
            this.btnF04.TabIndex = 76;
            this.btnF04.UseVisualStyleBackColor = true;
            this.btnF04.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF04.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // btnF03
            // 
            this.btnF03.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF03.Location = new System.Drawing.Point(240, 783);
            this.btnF03.Name = "btnF03";
            this.btnF03.Size = new System.Drawing.Size(117, 23);
            this.btnF03.TabIndex = 75;
            this.btnF03.UseVisualStyleBackColor = true;
            this.btnF03.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF03.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // btnF02
            // 
            this.btnF02.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF02.Location = new System.Drawing.Point(122, 783);
            this.btnF02.Name = "btnF02";
            this.btnF02.Size = new System.Drawing.Size(117, 23);
            this.btnF02.TabIndex = 74;
            this.btnF02.UseVisualStyleBackColor = true;
            this.btnF02.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF02.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // btnF01
            // 
            this.btnF01.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnF01.Location = new System.Drawing.Point(4, 783);
            this.btnF01.Name = "btnF01";
            this.btnF01.Size = new System.Drawing.Size(117, 23);
            this.btnF01.TabIndex = 73;
            this.btnF01.UseVisualStyleBackColor = true;
            this.btnF01.Enter += new System.EventHandler(this.btn_Enter);
            this.btnF01.Leave += new System.EventHandler(this.btn_Leave);
            // 
            // timer1
            // 
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbSubWinShow
            // 
            this.cmbSubWinShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubWinShow.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbSubWinShow.FormattingEnabled = true;
            this.cmbSubWinShow.Location = new System.Drawing.Point(1230, 12);
            this.cmbSubWinShow.Name = "cmbSubWinShow";
            this.cmbSubWinShow.Size = new System.Drawing.Size(182, 24);
            this.cmbSubWinShow.TabIndex = 85;
            this.cmbSubWinShow.Visible = false;
            // 
            // lblSubWinSHow
            // 
            this.lblSubWinSHow.AutoSize = true;
            this.lblSubWinSHow.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSubWinSHow.Location = new System.Drawing.Point(1104, 15);
            this.lblSubWinSHow.Name = "lblSubWinSHow";
            this.lblSubWinSHow.Size = new System.Drawing.Size(120, 16);
            this.lblSubWinSHow.TabIndex = 86;
            this.lblSubWinSHow.Text = "サブ画面を選択";
            this.lblSubWinSHow.Visible = false;
            // 
            // BaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.lblSubWinSHow);
            this.Controls.Add(this.cmbSubWinShow);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.btnF10);
            this.Controls.Add(this.btnF09);
            this.Controls.Add(this.btnF08);
            this.Controls.Add(this.btnF07);
            this.Controls.Add(this.btnF06);
            this.Controls.Add(this.btnF05);
            this.Controls.Add(this.btnF04);
            this.Controls.Add(this.btnF03);
            this.Controls.Add(this.btnF02);
            this.Controls.Add(this.btnF01);
            this.Controls.Add(this.statusStrip1);
            this.Name = "BaseForm";
            this.Text = "[{0}]";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseForm_FormClosed);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.StatusStrip statusStrip1;
        protected System.Windows.Forms.ToolStripStatusLabel lblStatusHeader;
        protected System.Windows.Forms.ToolStripStatusLabel lblStatusMessage;
        protected System.Windows.Forms.ToolStripStatusLabel lblStatusUser;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSubWinSHow;
        public System.Windows.Forms.Button btnF01;
        public System.Windows.Forms.Button btnF12;
        public System.Windows.Forms.Button btnF11;
        public System.Windows.Forms.Button btnF10;
        public System.Windows.Forms.Button btnF09;
        public System.Windows.Forms.Button btnF08;
        public System.Windows.Forms.Button btnF07;
        public System.Windows.Forms.Button btnF06;
        public System.Windows.Forms.Button btnF05;
        public System.Windows.Forms.Button btnF04;
        public System.Windows.Forms.Button btnF03;
        public System.Windows.Forms.Button btnF02;
        public System.Windows.Forms.ComboBox cmbSubWinShow;
    }
}