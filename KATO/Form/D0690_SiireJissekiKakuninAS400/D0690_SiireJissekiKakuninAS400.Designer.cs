namespace KATO.Form.D0690_SiireJissekiKakuninAS400
{
    partial class D0690_SiireJissekiKakuninAS400
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
            this.lblaida1 = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblKikan = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtCalendarYMDStart = new KATO.Common.Ctl.BaseCalendar();
            this.txtCalendarYMDEnd = new KATO.Common.Ctl.BaseCalendar();
            this.lblKataban = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtKataban = new KATO.Common.Ctl.BaseText();
            this.lblBikou = new KATO.Common.Ctl.BaseLabel(this.components);
            this.txtBikou = new KATO.Common.Ctl.BaseText();
            this.gridSiireJisseki = new KATO.Common.Ctl.BaseDataGridView();
            this.labelSet_Shiiresaki = new KATO.Common.Ctl.LabelSet_Shiresaki();
            ((System.ComponentModel.ISupportInitialize)(this.gridSiireJisseki)).BeginInit();
            this.SuspendLayout();
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
            // btnF01
            // 
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // lblaida1
            // 
            this.lblaida1.AutoSize = true;
            this.lblaida1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblaida1.Location = new System.Drawing.Point(293, 80);
            this.lblaida1.Name = "lblaida1";
            this.lblaida1.Size = new System.Drawing.Size(23, 15);
            this.lblaida1.strToolTip = null;
            this.lblaida1.TabIndex = 106;
            this.lblaida1.Text = "～";
            this.lblaida1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKikan
            // 
            this.lblKikan.AutoSize = true;
            this.lblKikan.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKikan.Location = new System.Drawing.Point(100, 80);
            this.lblKikan.Name = "lblKikan";
            this.lblKikan.Size = new System.Drawing.Size(87, 15);
            this.lblKikan.strToolTip = null;
            this.lblKikan.TabIndex = 107;
            this.lblKikan.Text = "伝票年月日";
            this.lblKikan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCalendarYMDStart
            // 
            this.txtCalendarYMDStart.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtCalendarYMDStart.Location = new System.Drawing.Point(193, 77);
            this.txtCalendarYMDStart.MaxLength = 10;
            this.txtCalendarYMDStart.Name = "txtCalendarYMDStart";
            this.txtCalendarYMDStart.Size = new System.Drawing.Size(90, 22);
            this.txtCalendarYMDStart.TabIndex = 2;
            this.txtCalendarYMDStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCalendarYMDEnd
            // 
            this.txtCalendarYMDEnd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtCalendarYMDEnd.Location = new System.Drawing.Point(323, 78);
            this.txtCalendarYMDEnd.MaxLength = 10;
            this.txtCalendarYMDEnd.Name = "txtCalendarYMDEnd";
            this.txtCalendarYMDEnd.Size = new System.Drawing.Size(90, 22);
            this.txtCalendarYMDEnd.TabIndex = 3;
            this.txtCalendarYMDEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblKataban
            // 
            this.lblKataban.AutoSize = true;
            this.lblKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblKataban.Location = new System.Drawing.Point(679, 43);
            this.lblKataban.Name = "lblKataban";
            this.lblKataban.Size = new System.Drawing.Size(87, 15);
            this.lblKataban.strToolTip = null;
            this.lblKataban.TabIndex = 109;
            this.lblKataban.Text = "品名・型番";
            this.lblKataban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKataban
            // 
            this.txtKataban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtKataban.Location = new System.Drawing.Point(772, 40);
            this.txtKataban.MaxLength = 100;
            this.txtKataban.Name = "txtKataban";
            this.txtKataban.Size = new System.Drawing.Size(324, 22);
            this.txtKataban.TabIndex = 4;
            // 
            // lblBikou
            // 
            this.lblBikou.AutoSize = true;
            this.lblBikou.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblBikou.Location = new System.Drawing.Point(679, 81);
            this.lblBikou.Name = "lblBikou";
            this.lblBikou.Size = new System.Drawing.Size(87, 15);
            this.lblBikou.strToolTip = null;
            this.lblBikou.TabIndex = 109;
            this.lblBikou.Text = "備　　　考";
            this.lblBikou.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBikou
            // 
            this.txtBikou.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtBikou.Location = new System.Drawing.Point(772, 77);
            this.txtBikou.MaxLength = 100;
            this.txtBikou.Name = "txtBikou";
            this.txtBikou.Size = new System.Drawing.Size(324, 22);
            this.txtBikou.TabIndex = 5;
            // 
            // gridSiireJisseki
            // 
            this.gridSiireJisseki.AllowUserToAddRows = false;
            this.gridSiireJisseki.AllowUserToResizeColumns = false;
            this.gridSiireJisseki.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSiireJisseki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSiireJisseki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSiireJisseki.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridSiireJisseki.EnableHeadersVisualStyles = false;
            this.gridSiireJisseki.Location = new System.Drawing.Point(12, 121);
            this.gridSiireJisseki.Name = "gridSiireJisseki";
            this.gridSiireJisseki.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSiireJisseki.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSiireJisseki.RowHeadersVisible = false;
            this.gridSiireJisseki.RowTemplate.Height = 21;
            this.gridSiireJisseki.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSiireJisseki.Size = new System.Drawing.Size(1400, 587);
            this.gridSiireJisseki.StandardTab = true;
            this.gridSiireJisseki.TabIndex = 110;
            // 
            // labelSet_Shiiresaki
            // 
            this.labelSet_Shiiresaki.AppendLabelSize = 0;
            this.labelSet_Shiiresaki.AppendLabelText = "";
            this.labelSet_Shiiresaki.CodeTxtSize = 40;
            this.labelSet_Shiiresaki.CodeTxtText = "";
            this.labelSet_Shiiresaki.LabelName = "仕入先コード";
            this.labelSet_Shiiresaki.Location = new System.Drawing.Point(98, 43);
            this.labelSet_Shiiresaki.Name = "labelSet_Shiiresaki";
            this.labelSet_Shiiresaki.ShowAppendFlg = false;
            this.labelSet_Shiiresaki.Size = new System.Drawing.Size(471, 22);
            this.labelSet_Shiiresaki.SpaceCodeValue = 4;
            this.labelSet_Shiiresaki.SpaceNameCode = 4;
            this.labelSet_Shiiresaki.SpaceValueAppend = 4;
            this.labelSet_Shiiresaki.TabIndex = 1;
            this.labelSet_Shiiresaki.ValueLabelSize = 300;
            this.labelSet_Shiiresaki.ValueLabelText = "";
            // 
            // D0690_SiireJissekiKakuninAS400
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.labelSet_Shiiresaki);
            this.Controls.Add(this.gridSiireJisseki);
            this.Controls.Add(this.txtBikou);
            this.Controls.Add(this.lblBikou);
            this.Controls.Add(this.txtKataban);
            this.Controls.Add(this.lblKataban);
            this.Controls.Add(this.txtCalendarYMDEnd);
            this.Controls.Add(this.txtCalendarYMDStart);
            this.Controls.Add(this.lblaida1);
            this.Controls.Add(this.lblKikan);
            this.Name = "D0690_SiireJissekiKakuninAS400";
            this.Text = "D0690_SiireJissekiKakuninAS400";
            this.Load += new System.EventHandler(this.D0690_SiireJissekiKakuninAS400_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.D0690_SiireJissekiKakuninAS400_KeyDown);
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
            this.Controls.SetChildIndex(this.lblKikan, 0);
            this.Controls.SetChildIndex(this.lblaida1, 0);
            this.Controls.SetChildIndex(this.txtCalendarYMDStart, 0);
            this.Controls.SetChildIndex(this.txtCalendarYMDEnd, 0);
            this.Controls.SetChildIndex(this.lblKataban, 0);
            this.Controls.SetChildIndex(this.txtKataban, 0);
            this.Controls.SetChildIndex(this.lblBikou, 0);
            this.Controls.SetChildIndex(this.txtBikou, 0);
            this.Controls.SetChildIndex(this.gridSiireJisseki, 0);
            this.Controls.SetChildIndex(this.labelSet_Shiiresaki, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridSiireJisseki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.Ctl.BaseLabel lblaida1;
        private Common.Ctl.BaseLabel lblKikan;
        private Common.Ctl.BaseCalendar txtCalendarYMDStart;
        private Common.Ctl.BaseCalendar txtCalendarYMDEnd;
        private Common.Ctl.BaseLabel lblKataban;
        private Common.Ctl.BaseText txtKataban;
        private Common.Ctl.BaseLabel lblBikou;
        private Common.Ctl.BaseText txtBikou;
        private Common.Ctl.BaseDataGridView gridSiireJisseki;
        private Common.Ctl.LabelSet_Shiresaki labelSet_Shiiresaki;
    }
}