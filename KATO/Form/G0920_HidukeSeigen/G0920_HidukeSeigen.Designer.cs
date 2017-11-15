namespace KATO.Form.G0920_HidukeSeigen
{
    partial class G0920_HidukeSeigen
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
            this.txtCalendarMinYMD = new KATO.Common.Ctl.BaseCalendar();
            this.txtCalendarMaxYMD = new KATO.Common.Ctl.BaseCalendar();
            this.lblMinYMD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblMaxYMD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.labelSet_Eigyosho = new KATO.Common.Ctl.LabelSet_Eigyosho();
            this.gridHidukeSeigen = new KATO.Common.Ctl.BaseDataGridView();
            this.lblGamenNo = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtGamenNo = new KATO.Common.Ctl.BaseText();
            this.lblGamenName = new KATO.Common.Ctl.BaseLabelGray();
            ((System.ComponentModel.ISupportInitialize)(this.gridHidukeSeigen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF01
            // 
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
            this.btnF02.TabStop = false;
            this.btnF02.Click += new System.EventHandler(this.judBtnClick);
            // 
            // txtCalendarMinYMD
            // 
            this.txtCalendarMinYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtCalendarMinYMD.Location = new System.Drawing.Point(696, 74);
            this.txtCalendarMinYMD.MaxLength = 10;
            this.txtCalendarMinYMD.Name = "txtCalendarMinYMD";
            this.txtCalendarMinYMD.Size = new System.Drawing.Size(90, 22);
            this.txtCalendarMinYMD.TabIndex = 3;
            this.txtCalendarMinYMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCalendarMinYMD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judText_KeyUp);
            // 
            // txtCalendarMaxYMD
            // 
            this.txtCalendarMaxYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtCalendarMaxYMD.Location = new System.Drawing.Point(921, 74);
            this.txtCalendarMaxYMD.MaxLength = 10;
            this.txtCalendarMaxYMD.Name = "txtCalendarMaxYMD";
            this.txtCalendarMaxYMD.Size = new System.Drawing.Size(90, 22);
            this.txtCalendarMaxYMD.TabIndex = 4;
            this.txtCalendarMaxYMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCalendarMaxYMD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judText_KeyUp);
            // 
            // lblMinYMD
            // 
            this.lblMinYMD.AutoSize = true;
            this.lblMinYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblMinYMD.Location = new System.Drawing.Point(603, 77);
            this.lblMinYMD.Name = "lblMinYMD";
            this.lblMinYMD.Size = new System.Drawing.Size(87, 15);
            this.lblMinYMD.strToolTip = null;
            this.lblMinYMD.TabIndex = 91;
            this.lblMinYMD.Text = "最小年月日";
            this.lblMinYMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaxYMD
            // 
            this.lblMaxYMD.AutoSize = true;
            this.lblMaxYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblMaxYMD.Location = new System.Drawing.Point(828, 77);
            this.lblMaxYMD.Name = "lblMaxYMD";
            this.lblMaxYMD.Size = new System.Drawing.Size(87, 15);
            this.lblMaxYMD.strToolTip = null;
            this.lblMaxYMD.TabIndex = 91;
            this.lblMaxYMD.Text = "最大年月日";
            this.lblMaxYMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSet_Eigyosho
            // 
            this.labelSet_Eigyosho.AppendLabelSize = 0;
            this.labelSet_Eigyosho.AppendLabelText = "";
            this.labelSet_Eigyosho.CodeTxtSize = 40;
            this.labelSet_Eigyosho.CodeTxtText = "";
            this.labelSet_Eigyosho.LabelName = "営業所";
            this.labelSet_Eigyosho.Location = new System.Drawing.Point(200, 120);
            this.labelSet_Eigyosho.Name = "labelSet_Eigyosho";
            this.labelSet_Eigyosho.ShowAppendFlg = false;
            this.labelSet_Eigyosho.Size = new System.Drawing.Size(361, 22);
            this.labelSet_Eigyosho.SpaceCodeValue = 4;
            this.labelSet_Eigyosho.SpaceNameCode = 4;
            this.labelSet_Eigyosho.SpaceValueAppend = 4;
            this.labelSet_Eigyosho.TabIndex = 2;
            this.labelSet_Eigyosho.ValueLabelSize = 250;
            this.labelSet_Eigyosho.ValueLabelText = "";
            this.labelSet_Eigyosho.Leave += new System.EventHandler(this.labelSet_Eigyosho_Leave);
            // 
            // gridHidukeSeigen
            // 
            this.gridHidukeSeigen.AllowUserToAddRows = false;
            this.gridHidukeSeigen.AllowUserToResizeColumns = false;
            this.gridHidukeSeigen.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHidukeSeigen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridHidukeSeigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridHidukeSeigen.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridHidukeSeigen.EnableHeadersVisualStyles = false;
            this.gridHidukeSeigen.Location = new System.Drawing.Point(145, 183);
            this.gridHidukeSeigen.Name = "gridHidukeSeigen";
            this.gridHidukeSeigen.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHidukeSeigen.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridHidukeSeigen.RowHeadersVisible = false;
            this.gridHidukeSeigen.RowTemplate.Height = 21;
            this.gridHidukeSeigen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHidukeSeigen.Size = new System.Drawing.Size(968, 447);
            this.gridHidukeSeigen.StandardTab = true;
            this.gridHidukeSeigen.TabIndex = 5;
            this.gridHidukeSeigen.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridHidukeSeigen_CellMouseClick);
            this.gridHidukeSeigen.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridHidukeSeigen_CellMouseDoubleClick);
            // 
            // lblGamenNo
            // 
            this.lblGamenNo.AutoSize = true;
            this.lblGamenNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblGamenNo.Location = new System.Drawing.Point(202, 76);
            this.lblGamenNo.Name = "lblGamenNo";
            this.lblGamenNo.Size = new System.Drawing.Size(55, 15);
            this.lblGamenNo.strToolTip = null;
            this.lblGamenNo.TabIndex = 105;
            this.lblGamenNo.Text = "画面№";
            this.lblGamenNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGamenNo
            // 
            this.txtGamenNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtGamenNo.Location = new System.Drawing.Point(258, 74);
            this.txtGamenNo.MaxLength = 3;
            this.txtGamenNo.Name = "txtGamenNo";
            this.txtGamenNo.Size = new System.Drawing.Size(35, 22);
            this.txtGamenNo.TabIndex = 1;
            this.txtGamenNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGamenNo.TextChanged += new System.EventHandler(this.txtGamenNoTextChanged);
            this.txtGamenNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judTxtGamenNoKeyDown);
            this.txtGamenNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.judtxtGamenNoKeyUp);
            this.txtGamenNo.Leave += new System.EventHandler(this.updTxtGamenNoLeave);
            // 
            // lblGamenName
            // 
            this.lblGamenName.AutoEllipsis = true;
            this.lblGamenName.AutoSize = true;
            this.lblGamenName.BackColor = System.Drawing.Color.Gainsboro;
            this.lblGamenName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblGamenName.ForeColor = System.Drawing.Color.Blue;
            this.lblGamenName.Location = new System.Drawing.Point(299, 74);
            this.lblGamenName.MinimumSize = new System.Drawing.Size(250, 22);
            this.lblGamenName.Name = "lblGamenName";
            this.lblGamenName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblGamenName.Size = new System.Drawing.Size(250, 22);
            this.lblGamenName.TabIndex = 99;
            this.lblGamenName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // G0920_HidukeSeigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.lblGamenName);
            this.Controls.Add(this.txtGamenNo);
            this.Controls.Add(this.lblGamenNo);
            this.Controls.Add(this.gridHidukeSeigen);
            this.Controls.Add(this.labelSet_Eigyosho);
            this.Controls.Add(this.lblMaxYMD);
            this.Controls.Add(this.lblMinYMD);
            this.Controls.Add(this.txtCalendarMaxYMD);
            this.Controls.Add(this.txtCalendarMinYMD);
            this.Name = "G0920_HidukeSeigen";
            this.Text = "G0920_HidukeSeigen";
            this.Load += new System.EventHandler(this.G0920_HidukeSeigen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.G0920_HidukeSeigen_KeyDown);
            this.Controls.SetChildIndex(this.txtCalendarMinYMD, 0);
            this.Controls.SetChildIndex(this.txtCalendarMaxYMD, 0);
            this.Controls.SetChildIndex(this.lblMinYMD, 0);
            this.Controls.SetChildIndex(this.lblMaxYMD, 0);
            this.Controls.SetChildIndex(this.labelSet_Eigyosho, 0);
            this.Controls.SetChildIndex(this.gridHidukeSeigen, 0);
            this.Controls.SetChildIndex(this.lblGamenNo, 0);
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
            this.Controls.SetChildIndex(this.txtGamenNo, 0);
            this.Controls.SetChildIndex(this.lblGamenName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridHidukeSeigen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.Ctl.BaseCalendar txtCalendarMinYMD;
        private Common.Ctl.BaseCalendar txtCalendarMaxYMD;
        private Common.Ctl.BaseLabel lblMinYMD;
        private Common.Ctl.BaseLabel lblMaxYMD;
        private Common.Ctl.LabelSet_Eigyosho labelSet_Eigyosho;
        private Common.Ctl.BaseDataGridView gridHidukeSeigen;
        private Common.Ctl.BaseLabel lblGamenNo;
        private Common.Ctl.BaseText txtGamenNo;
        private Common.Ctl.BaseLabelGray lblGamenName;
    }
}