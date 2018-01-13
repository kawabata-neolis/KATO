namespace KATO.Form.B1510_SeikyuRireki
{
    partial class B1510_SeikyuRireki
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
            this.gridRireki = new KATO.Common.Ctl.BaseDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDenpyoYMDopen = new KATO.Common.Ctl.BaseCalendar();
            this.txtDenpyoYMDclose = new KATO.Common.Ctl.BaseCalendar();
            this.lblsetTokuisaki = new KATO.Common.Ctl.LabelSet_Torihikisaki();
            this.lblDenpyoYMD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblKikan = new KATO.Common.Ctl.BaseLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridRireki)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.TabStop = false;
            this.btnF01.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF12
            // 
            this.btnF12.TabStop = false;
            this.btnF12.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF11
            // 
            this.btnF11.TabStop = false;
            this.btnF11.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF10
            // 
            this.btnF10.TabStop = false;
            this.btnF10.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF09
            // 
            this.btnF09.TabStop = false;
            this.btnF09.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF08
            // 
            this.btnF08.TabStop = false;
            this.btnF08.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF07
            // 
            this.btnF07.TabStop = false;
            this.btnF07.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF06
            // 
            this.btnF06.TabStop = false;
            this.btnF06.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF05
            // 
            this.btnF05.TabStop = false;
            this.btnF05.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF04
            // 
            this.btnF04.TabIndex = 3;
            this.btnF04.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF03
            // 
            this.btnF03.TabStop = false;
            this.btnF03.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // btnF02
            // 
            this.btnF02.TabStop = false;
            this.btnF02.Click += new System.EventHandler(this.judFuncBtnClick);
            // 
            // gridRireki
            // 
            this.gridRireki.AllowUserToAddRows = false;
            this.gridRireki.AllowUserToResizeColumns = false;
            this.gridRireki.AllowUserToResizeRows = false;
            this.gridRireki.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRireki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridRireki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRireki.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridRireki.EnableHeadersVisualStyles = false;
            this.gridRireki.Location = new System.Drawing.Point(17, 28);
            this.gridRireki.Name = "gridRireki";
            this.gridRireki.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRireki.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridRireki.RowHeadersVisible = false;
            this.gridRireki.RowTemplate.Height = 21;
            this.gridRireki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRireki.Size = new System.Drawing.Size(1348, 619);
            this.gridRireki.StandardTab = true;
            this.gridRireki.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridRireki);
            this.groupBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(19, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1384, 667);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "請求履歴";
            // 
            // txtDenpyoYMDopen
            // 
            this.txtDenpyoYMDopen.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDenpyoYMDopen.Location = new System.Drawing.Point(210, 47);
            this.txtDenpyoYMDopen.Name = "txtDenpyoYMDopen";
            this.txtDenpyoYMDopen.Size = new System.Drawing.Size(87, 22);
            this.txtDenpyoYMDopen.TabIndex = 0;
            this.txtDenpyoYMDopen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDenpyoYMDclose_KeyDown);
            // 
            // txtDenpyoYMDclose
            // 
            this.txtDenpyoYMDclose.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtDenpyoYMDclose.Location = new System.Drawing.Point(345, 47);
            this.txtDenpyoYMDclose.Name = "txtDenpyoYMDclose";
            this.txtDenpyoYMDclose.Size = new System.Drawing.Size(86, 22);
            this.txtDenpyoYMDclose.TabIndex = 1;
            this.txtDenpyoYMDclose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDenpyoYMDclose_KeyDown);
            // 
            // lblsetTokuisaki
            // 
            this.lblsetTokuisaki.AppendLabelSize = 0;
            this.lblsetTokuisaki.AppendLabelText = "";
            this.lblsetTokuisaki.CodeTxtSize = 40;
            this.lblsetTokuisaki.CodeTxtText = "";
            this.lblsetTokuisaki.LabelName = "取引先コード";
            this.lblsetTokuisaki.Location = new System.Drawing.Point(541, 47);
            this.lblsetTokuisaki.Name = "lblsetTokuisaki";
            this.lblsetTokuisaki.ShowAppendFlg = false;
            this.lblsetTokuisaki.Size = new System.Drawing.Size(465, 22);
            this.lblsetTokuisaki.SpaceCodeValue = 4;
            this.lblsetTokuisaki.SpaceNameCode = 4;
            this.lblsetTokuisaki.SpaceValueAppend = 4;
            this.lblsetTokuisaki.TabIndex = 2;
            this.lblsetTokuisaki.ValueLabelSize = 300;
            this.lblsetTokuisaki.ValueLabelText = "";
            this.lblsetTokuisaki.Leave += new System.EventHandler(this.lblsetTokuisaki_Leave);
            // 
            // lblDenpyoYMD
            // 
            this.lblDenpyoYMD.AutoSize = true;
            this.lblDenpyoYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblDenpyoYMD.Location = new System.Drawing.Point(106, 50);
            this.lblDenpyoYMD.Name = "lblDenpyoYMD";
            this.lblDenpyoYMD.Size = new System.Drawing.Size(87, 15);
            this.lblDenpyoYMD.strToolTip = null;
            this.lblDenpyoYMD.TabIndex = 93;
            this.lblDenpyoYMD.Text = "伝票年月日";
            this.lblDenpyoYMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKikan
            // 
            this.lblKikan.AutoSize = true;
            this.lblKikan.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKikan.Location = new System.Drawing.Point(310, 51);
            this.lblKikan.Name = "lblKikan";
            this.lblKikan.Size = new System.Drawing.Size(23, 15);
            this.lblKikan.strToolTip = null;
            this.lblKikan.TabIndex = 93;
            this.lblKikan.Text = "～";
            this.lblKikan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // B1510_SeikyuRireki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.lblKikan);
            this.Controls.Add(this.lblDenpyoYMD);
            this.Controls.Add(this.lblsetTokuisaki);
            this.Controls.Add(this.txtDenpyoYMDclose);
            this.Controls.Add(this.txtDenpyoYMDopen);
            this.Controls.Add(this.groupBox1);
            this.Name = "B1510_SeikyuRireki";
            this.Text = "B1510_SeikyuRireki";
            this.Load += new System.EventHandler(this.B1510_SeikyuRireki_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.B1510_SeikyuRireki_KeyDown);
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
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtDenpyoYMDopen, 0);
            this.Controls.SetChildIndex(this.txtDenpyoYMDclose, 0);
            this.Controls.SetChildIndex(this.lblsetTokuisaki, 0);
            this.Controls.SetChildIndex(this.lblDenpyoYMD, 0);
            this.Controls.SetChildIndex(this.lblKikan, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridRireki)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseDataGridView gridRireki;
        private System.Windows.Forms.GroupBox groupBox1;
        private Common.Ctl.BaseCalendar txtDenpyoYMDopen;
        private Common.Ctl.BaseCalendar txtDenpyoYMDclose;
        private Common.Ctl.LabelSet_Torihikisaki lblsetTokuisaki;
        private Common.Ctl.BaseLabel lblDenpyoYMD;
        private Common.Ctl.BaseLabel lblKikan;
    }
}