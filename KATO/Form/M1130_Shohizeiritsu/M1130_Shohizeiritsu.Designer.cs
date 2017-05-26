namespace KATO.Form.M1130_Shohizeiritsu
{
    partial class M1130_Shohizeiritsu
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
            this.txtShohizeiritu = new KATO.Common.Ctl.BaseTextMoney();
            this.txtTekiyoYMD = new KATO.Common.Ctl.BaseCalendar();
            this.lblTekiyoYMD = new KATO.Common.Ctl.BaseLabel(this.components);
            this.lblShohizeiritu = new KATO.Common.Ctl.BaseLabel(this.components);
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
            // txtShohizeiritu
            // 
            this.txtShohizeiritu.blnCommaOK = false;
            this.txtShohizeiritu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtShohizeiritu.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtShohizeiritu.intDeciSet = 1;
            this.txtShohizeiritu.intIntederSet = 0;
            this.txtShohizeiritu.intShishagonyu = 1;
            this.txtShohizeiritu.Location = new System.Drawing.Point(241, 162);
            this.txtShohizeiritu.MaxLength = 17;
            this.txtShohizeiritu.Name = "txtShohizeiritu";
            this.txtShohizeiritu.Size = new System.Drawing.Size(100, 22);
            this.txtShohizeiritu.TabIndex = 1;
            this.txtShohizeiritu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtShohizeiritu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShohizeiritsu_KeyDown);
            // 
            // txtTekiyoYMD
            // 
            this.txtTekiyoYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.txtTekiyoYMD.Location = new System.Drawing.Point(241, 112);
            this.txtTekiyoYMD.MaxLength = 10;
            this.txtTekiyoYMD.Name = "txtTekiyoYMD";
            this.txtTekiyoYMD.Size = new System.Drawing.Size(100, 22);
            this.txtTekiyoYMD.TabIndex = 0;
            this.txtTekiyoYMD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTekiyoYMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTekiyoYMD_KeyDown);
            this.txtTekiyoYMD.Leave += new System.EventHandler(this.txtTekiyoYMD_Leave);
            // 
            // lblTekiyoYMD
            // 
            this.lblTekiyoYMD.AutoSize = true;
            this.lblTekiyoYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblTekiyoYMD.Location = new System.Drawing.Point(116, 115);
            this.lblTekiyoYMD.Name = "lblTekiyoYMD";
            this.lblTekiyoYMD.Size = new System.Drawing.Size(119, 15);
            this.lblTekiyoYMD.strToolTip = null;
            this.lblTekiyoYMD.TabIndex = 89;
            this.lblTekiyoYMD.Text = "適用開始年月日";
            this.lblTekiyoYMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShohizeiritu
            // 
            this.lblShohizeiritu.AutoSize = true;
            this.lblShohizeiritu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lblShohizeiritu.Location = new System.Drawing.Point(116, 165);
            this.lblShohizeiritu.Name = "lblShohizeiritu";
            this.lblShohizeiritu.Size = new System.Drawing.Size(71, 15);
            this.lblShohizeiritu.strToolTip = null;
            this.lblShohizeiritu.TabIndex = 89;
            this.lblShohizeiritu.Text = "消費税率";
            this.lblShohizeiritu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // M1130_Shohizeiritu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 826);
            this.Controls.Add(this.lblShohizeiritu);
            this.Controls.Add(this.lblTekiyoYMD);
            this.Controls.Add(this.txtTekiyoYMD);
            this.Controls.Add(this.txtShohizeiritu);
            this.Name = "M1130_Shohizeiritu";
            this.Text = "M1130_Shohizeiritu";
            this.Load += new System.EventHandler(this.M1130_Shohizeiritsu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.M1130_Shohizeiritsu_KeyDown);
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
            this.Controls.SetChildIndex(this.txtShohizeiritu, 0);
            this.Controls.SetChildIndex(this.txtTekiyoYMD, 0);
            this.Controls.SetChildIndex(this.lblTekiyoYMD, 0);
            this.Controls.SetChildIndex(this.lblShohizeiritu, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Ctl.BaseTextMoney txtShohizeiritu;
        private Common.Ctl.BaseCalendar txtTekiyoYMD;
        private Common.Ctl.BaseLabel lblTekiyoYMD;
        private Common.Ctl.BaseLabel lblShohizeiritu;
    }
}