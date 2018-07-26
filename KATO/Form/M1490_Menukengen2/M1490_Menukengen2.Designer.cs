namespace KATO.Form.M1490_Menukengen2
{
    partial class M1490_Menukengen2
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
            this.gridKengen = new KATO.Common.Ctl.BaseDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSet_Menu = new KATO.Common.Ctl.LabelSet_Menu();
            ((System.ComponentModel.ISupportInitialize)(this.gridKengen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnF01
            // 
            this.btnF01.TabIndex = 2;
            this.btnF01.Click += new System.EventHandler(this.judBtnClick);
            // 
            // btnF12
            // 
            this.btnF12.TabIndex = 5;
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
            this.btnF09.TabIndex = 4;
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
            this.btnF04.TabIndex = 3;
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
            // gridKengen
            // 
            this.gridKengen.AllowUserToAddRows = false;
            this.gridKengen.AllowUserToResizeColumns = false;
            this.gridKengen.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridKengen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridKengen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridKengen.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridKengen.EnableHeadersVisualStyles = false;
            this.gridKengen.Location = new System.Drawing.Point(168, 120);
            this.gridKengen.Name = "gridKengen";
            this.gridKengen.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridKengen.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridKengen.RowHeadersVisible = false;
            this.gridKengen.RowTemplate.Height = 21;
            this.gridKengen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridKengen.Size = new System.Drawing.Size(498, 630);
            this.gridKengen.StandardTab = true;
            this.gridKengen.TabIndex = 1;
            this.gridKengen.DoubleClick += new System.EventHandler(this.gridKengen_DblClick);
            this.gridKengen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridKengen_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 12);
            this.label1.TabIndex = 102;
            this.label1.Text = "※権限　Ｙ：使用可　Ｎ：使用不可";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 12);
            this.label2.TabIndex = 103;
            this.label2.Text = "※権限の切り替えは、";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 12);
            this.label3.TabIndex = 104;
            this.label3.Text = "　 変更したい行でダブルクリックします。";
            // 
            // labelSet_Menu
            // 
            this.labelSet_Menu.AppendLabelSize = 0;
            this.labelSet_Menu.AppendLabelText = "";
            this.labelSet_Menu.CodeTxtSize = 40;
            this.labelSet_Menu.CodeTxtText = "";
            this.labelSet_Menu.LabelName = "PGNo.";
            this.labelSet_Menu.Location = new System.Drawing.Point(85, 70);
            this.labelSet_Menu.Name = "labelSet_Menu";
            this.labelSet_Menu.ShowAppendFlg = false;
            this.labelSet_Menu.Size = new System.Drawing.Size(637, 22);
            this.labelSet_Menu.SpaceCodeValue = 4;
            this.labelSet_Menu.SpaceNameCode = 4;
            this.labelSet_Menu.SpaceValueAppend = 4;
            this.labelSet_Menu.TabIndex = 0;
            this.labelSet_Menu.ValueLabelSize = 300;
            this.labelSet_Menu.ValueLabelText = "";
            this.labelSet_Menu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.labelSet_Menu_KeyDown);
            this.labelSet_Menu.Leave += new System.EventHandler(this.labelSet_Menu_Leave);
            // 
            // M1490_Menukengen2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 826);
            this.Controls.Add(this.labelSet_Menu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridKengen);
            this.Name = "M1490_Menukengen2";
            this.Text = "M1490_Menukengen2";
            this.Load += new System.EventHandler(this.M1490_Menukengen2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1490_Menukengen2_KeyDown);
            this.Controls.SetChildIndex(this.cmbSubWinShow, 0);
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
            this.Controls.SetChildIndex(this.gridKengen, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.labelSet_Menu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridKengen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.Ctl.BaseDataGridView gridKengen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Common.Ctl.LabelSet_Menu labelSet_Menu;
    }
}