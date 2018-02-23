namespace KATO.Common.Form
{
    partial class TorihikiCdList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbShuturyoku = new System.Windows.Forms.GroupBox();
            this.radNagyo = new System.Windows.Forms.RadioButton();
            this.radTagyo = new System.Windows.Forms.RadioButton();
            this.radSagyo = new System.Windows.Forms.RadioButton();
            this.radKagyo = new System.Windows.Forms.RadioButton();
            this.radWagyo = new System.Windows.Forms.RadioButton();
            this.radRagyo = new System.Windows.Forms.RadioButton();
            this.radYagyo = new System.Windows.Forms.RadioButton();
            this.radMagyo = new System.Windows.Forms.RadioButton();
            this.radHagyo = new System.Windows.Forms.RadioButton();
            this.radAgyo = new System.Windows.Forms.RadioButton();
            this.lblRecords = new System.Windows.Forms.Label();
            this.btnF11 = new KATO.Common.Ctl.BaseButton();
            this.gridTorihiki = new KATO.Common.Ctl.BaseDataGridView();
            this.btnF12 = new KATO.Common.Ctl.BaseButton();
            this.gbShuturyoku.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).BeginInit();
            this.SuspendLayout();
            // 
            // gbShuturyoku
            // 
            this.gbShuturyoku.Controls.Add(this.radNagyo);
            this.gbShuturyoku.Controls.Add(this.radTagyo);
            this.gbShuturyoku.Controls.Add(this.radSagyo);
            this.gbShuturyoku.Controls.Add(this.radKagyo);
            this.gbShuturyoku.Controls.Add(this.radWagyo);
            this.gbShuturyoku.Controls.Add(this.radRagyo);
            this.gbShuturyoku.Controls.Add(this.radYagyo);
            this.gbShuturyoku.Controls.Add(this.radMagyo);
            this.gbShuturyoku.Controls.Add(this.radHagyo);
            this.gbShuturyoku.Controls.Add(this.radAgyo);
            this.gbShuturyoku.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.gbShuturyoku.Location = new System.Drawing.Point(31, 4);
            this.gbShuturyoku.Name = "gbShuturyoku";
            this.gbShuturyoku.Size = new System.Drawing.Size(354, 70);
            this.gbShuturyoku.TabIndex = 2;
            this.gbShuturyoku.TabStop = false;
            this.gbShuturyoku.Text = "出力順";
            // 
            // radNagyo
            // 
            this.radNagyo.AutoSize = true;
            this.radNagyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radNagyo.Location = new System.Drawing.Point(280, 19);
            this.radNagyo.Name = "radNagyo";
            this.radNagyo.Size = new System.Drawing.Size(57, 19);
            this.radNagyo.TabIndex = 4;
            this.radNagyo.TabStop = true;
            this.radNagyo.Text = "ナ行";
            this.radNagyo.UseVisualStyleBackColor = true;
            this.radNagyo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judToriListKeyDown);
            // 
            // radTagyo
            // 
            this.radTagyo.AutoSize = true;
            this.radTagyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radTagyo.Location = new System.Drawing.Point(217, 19);
            this.radTagyo.Name = "radTagyo";
            this.radTagyo.Size = new System.Drawing.Size(57, 19);
            this.radTagyo.TabIndex = 3;
            this.radTagyo.TabStop = true;
            this.radTagyo.Text = "タ行";
            this.radTagyo.UseVisualStyleBackColor = true;
            this.radTagyo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judToriListKeyDown);
            // 
            // radSagyo
            // 
            this.radSagyo.AutoSize = true;
            this.radSagyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radSagyo.Location = new System.Drawing.Point(154, 19);
            this.radSagyo.Name = "radSagyo";
            this.radSagyo.Size = new System.Drawing.Size(57, 19);
            this.radSagyo.TabIndex = 2;
            this.radSagyo.TabStop = true;
            this.radSagyo.Text = "サ行";
            this.radSagyo.UseVisualStyleBackColor = true;
            this.radSagyo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judToriListKeyDown);
            // 
            // radKagyo
            // 
            this.radKagyo.AutoSize = true;
            this.radKagyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radKagyo.Location = new System.Drawing.Point(91, 19);
            this.radKagyo.Name = "radKagyo";
            this.radKagyo.Size = new System.Drawing.Size(57, 19);
            this.radKagyo.TabIndex = 1;
            this.radKagyo.TabStop = true;
            this.radKagyo.Text = "カ行";
            this.radKagyo.UseVisualStyleBackColor = true;
            this.radKagyo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judToriListKeyDown);
            // 
            // radWagyo
            // 
            this.radWagyo.AutoSize = true;
            this.radWagyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radWagyo.Location = new System.Drawing.Point(280, 42);
            this.radWagyo.Name = "radWagyo";
            this.radWagyo.Size = new System.Drawing.Size(57, 19);
            this.radWagyo.TabIndex = 9;
            this.radWagyo.TabStop = true;
            this.radWagyo.Text = "ワ行";
            this.radWagyo.UseVisualStyleBackColor = true;
            this.radWagyo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judToriListKeyDown);
            // 
            // radRagyo
            // 
            this.radRagyo.AutoSize = true;
            this.radRagyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radRagyo.Location = new System.Drawing.Point(217, 42);
            this.radRagyo.Name = "radRagyo";
            this.radRagyo.Size = new System.Drawing.Size(57, 19);
            this.radRagyo.TabIndex = 8;
            this.radRagyo.TabStop = true;
            this.radRagyo.Text = "ラ行";
            this.radRagyo.UseVisualStyleBackColor = true;
            this.radRagyo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judToriListKeyDown);
            // 
            // radYagyo
            // 
            this.radYagyo.AutoSize = true;
            this.radYagyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radYagyo.Location = new System.Drawing.Point(154, 42);
            this.radYagyo.Name = "radYagyo";
            this.radYagyo.Size = new System.Drawing.Size(57, 19);
            this.radYagyo.TabIndex = 7;
            this.radYagyo.TabStop = true;
            this.radYagyo.Text = "ヤ行";
            this.radYagyo.UseVisualStyleBackColor = true;
            this.radYagyo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judToriListKeyDown);
            // 
            // radMagyo
            // 
            this.radMagyo.AutoSize = true;
            this.radMagyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radMagyo.Location = new System.Drawing.Point(91, 42);
            this.radMagyo.Name = "radMagyo";
            this.radMagyo.Size = new System.Drawing.Size(57, 19);
            this.radMagyo.TabIndex = 6;
            this.radMagyo.TabStop = true;
            this.radMagyo.Text = "マ行";
            this.radMagyo.UseVisualStyleBackColor = true;
            this.radMagyo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judToriListKeyDown);
            // 
            // radHagyo
            // 
            this.radHagyo.AutoSize = true;
            this.radHagyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radHagyo.Location = new System.Drawing.Point(28, 42);
            this.radHagyo.Name = "radHagyo";
            this.radHagyo.Size = new System.Drawing.Size(57, 19);
            this.radHagyo.TabIndex = 5;
            this.radHagyo.TabStop = true;
            this.radHagyo.Text = "ハ行";
            this.radHagyo.UseVisualStyleBackColor = true;
            this.radHagyo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judToriListKeyDown);
            // 
            // radAgyo
            // 
            this.radAgyo.AutoSize = true;
            this.radAgyo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radAgyo.Location = new System.Drawing.Point(28, 19);
            this.radAgyo.Name = "radAgyo";
            this.radAgyo.Size = new System.Drawing.Size(57, 19);
            this.radAgyo.TabIndex = 0;
            this.radAgyo.TabStop = true;
            this.radAgyo.Text = "ア行";
            this.radAgyo.UseVisualStyleBackColor = true;
            this.radAgyo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judToriListKeyDown);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblRecords.Location = new System.Drawing.Point(29, 477);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecords.Size = new System.Drawing.Size(125, 12);
            this.lblRecords.TabIndex = 20;
            this.lblRecords.Text = "該当件数(ありません)";
            // 
            // btnF11
            // 
            this.btnF11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF11.Location = new System.Drawing.Point(405, 41);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(100, 23);
            this.btnF11.TabIndex = 0;
            this.btnF11.UseVisualStyleBackColor = true;
            this.btnF11.Click += new System.EventHandler(this.btnKensakuClick);
            // 
            // gridTorihiki
            // 
            this.gridTorihiki.AllowUserToAddRows = false;
            this.gridTorihiki.AllowUserToResizeColumns = false;
            this.gridTorihiki.AllowUserToResizeRows = false;
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
            this.gridTorihiki.Location = new System.Drawing.Point(31, 87);
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
            this.gridTorihiki.Size = new System.Drawing.Size(474, 374);
            this.gridTorihiki.StandardTab = true;
            this.gridTorihiki.TabIndex = 3;
            this.gridTorihiki.DoubleClick += new System.EventHandler(this.gridTorihiki_DoubleClick);
            this.gridTorihiki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judGridToriKeyDown);
            // 
            // btnF12
            // 
            this.btnF12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.btnF12.Location = new System.Drawing.Point(405, 12);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(100, 23);
            this.btnF12.TabIndex = 1;
            this.btnF12.UseVisualStyleBackColor = true;
            this.btnF12.Click += new System.EventHandler(this.btnEndClick);
            // 
            // TorihikiCdList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 524);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.gbShuturyoku);
            this.Controls.Add(this.btnF11);
            this.Controls.Add(this.gridTorihiki);
            this.Controls.Add(this.btnF12);
            this.Name = "TorihikiCdList";
            this.Text = "TorihikiCdList";
            this.Load += new System.EventHandler(this.TorihikiCdList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.judToriListKeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_KeyPress);
            this.gbShuturyoku.ResumeLayout(false);
            this.gbShuturyoku.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTorihiki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctl.BaseButton btnF12;
        private Ctl.BaseDataGridView gridTorihiki;
        private Ctl.BaseButton btnF11;
        private System.Windows.Forms.GroupBox gbShuturyoku;
        private System.Windows.Forms.RadioButton radNagyo;
        private System.Windows.Forms.RadioButton radTagyo;
        private System.Windows.Forms.RadioButton radSagyo;
        private System.Windows.Forms.RadioButton radKagyo;
        private System.Windows.Forms.RadioButton radWagyo;
        private System.Windows.Forms.RadioButton radRagyo;
        private System.Windows.Forms.RadioButton radYagyo;
        private System.Windows.Forms.RadioButton radMagyo;
        private System.Windows.Forms.RadioButton radHagyo;
        private System.Windows.Forms.RadioButton radAgyo;
        private System.Windows.Forms.Label lblRecords;
    }
}