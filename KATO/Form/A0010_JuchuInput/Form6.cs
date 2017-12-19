using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.A0010_JuchuInput;
using KATO.Common.Ctl;

namespace KATO.Form.A0010_JuchuInput
{
    public partial class Form6 : BaseForm
    {
        // 定数
        const int limit = 100; // 各ボタン毎に作成できる入力パネルの個数上限
        readonly int keta = ((limit * 10).ToString()).Length;
        readonly int[] cats = { 0, 1, 2, 3, 4, 5 };
        readonly String[] labels = new String[] { "発注", "出庫", "本加工", "加工品出庫", "出庫", "加工品出庫" };
        readonly String[] labelsNohki = new String[] { "納期", "出庫日", "納期", "納期", "出庫日", "納期" };

        // 変数
        int[] panelCnt = { 0, 0, 0, 0, 0, 0 };
        String zeroPad = null;
        int minimumIdx = 0;
        Control ctl = null;

        String strJuchuNo = "";
        String strHachuNo = "";
        String strJuchuSu = "";

        string strC1;
        string strC2;
        string strC3;
        string strC4;
        string strC5;
        string strC6;
        string strNoki;
        string strJuchuTanka;
        string strShiireTanka;
        string strChuban;
        string strJuchusha;
        string strTantosha;
        string strEigyosho;
        string strTokuiCd;
        string strShohin;

        public Form6()
        {
            InitializeComponent();

            // 横スクロールバーを表示させないようにする
            Padding p = tableLayoutPanel1.Padding;
            p.Right = SystemInformation.VerticalScrollBarWidth;
            tableLayoutPanel1.Padding = p;

            for (int i = 0; i < cats.Length; i++)
            {
                panelCnt[i] = cats[i] * limit * 100;
            }
            zeroPad = "D" + keta.ToString();

            this.checkBox1.Checked = true;

            A0010_JuchuInput frm1;

            frm1 = (A0010_JuchuInput)this.Parent;
            txtHinmei.Text = frm1.txtHinmei.Text;
            strJuchuNo = frm1.txtJuchuNo.Text;
            strJuchuSu = frm1.txtJuchuSuryo.Text;

            getInfo();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            addInputPanel(cats[0]);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            addInputPanel(cats[1]);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            addInputPanel(cats[2]);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            addInputPanel(cats[3]);
        }

        // 
        private void btnAddShukko_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Panel c = (Panel)b.Parent;

            int idx = int.Parse((String)c.Tag);
            idx++;
            b.Tag = idx;
            //panelCnt[0] = idx;
            b.Visible = false;

            Panel inputPanel = createPanel(cats[4], idx, "", c);
            tableLayoutPanel1.Controls.Add(inputPanel, 0, idx);

            foreach (Control cc in inputPanel.Controls)
            {
                if (cc.Name != null && cc.Name == "txtHYMD" + idx.ToString(zeroPad))
                {
                    cc.Focus();
                }
                else if (cc.Name != null && cc.Name == "linePanel" + idx.ToString(zeroPad))
                {
                    //cc.BackColor = Color.FromArgb(0x66, 0xFF, 0x66);
                }
            }

            //foreach (Control cc in c.Controls)
            //{
            //    if (cc.Name != null && cc.Name == "linePanel" + (int.Parse((String)b.Parent.Tag)).ToString(zeroPad))
            //    {
            //        //cc.BackColor = Color.FromArgb(0x66, 0xFF, 0x66);
            //        break;
            //    }
            //}
        }

        private void btnAddKakoShukko_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Panel c = (Panel)b.Parent;


            int idx = int.Parse((String)c.Tag);
            String s = "";

            //foreach (Control cc in c.Controls)
            //{
            //    if (cc.Name != null && cc.Name == "txtHinmei" + idx.ToString(zeroPad))
            //    {
            //        s = ((TextBox)cc).Text;
            //    }
            //}

            idx++;
            b.Tag = idx;
            //panelCnt[0] = idx;
            b.Visible = false;

            Panel inputPanel = createPanel(cats[5], idx, s, c);
            tableLayoutPanel1.Controls.Add(inputPanel, 0, idx);


            foreach (Control cc in inputPanel.Controls)
            {
                if (cc.Name != null && cc.Name == "txtHYMD" + idx.ToString(zeroPad))
                {
                    cc.Focus();
                }
                else if (cc.Name != null && cc.Name == "linePanel" + idx.ToString(zeroPad))
                {
                    //cc.BackColor = Color.FromArgb(0x66, 0xFF, 0x66);
                }
            }

            //foreach (Control cc in c.Controls)
            //{
            //    if (cc.Name != null && cc.Name == "linePanel" + (int.Parse((String)b.Parent.Tag)).ToString(zeroPad))
            //    {
            //        //cc.BackColor = Color.FromArgb(0x66, 0xFF, 0x66);
            //        break;
            //    }
            //}
        }

        // 検索
        private void txtSearchStr_Leave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            Panel c = (Panel)t.Parent;
            //Control cc = c.Controls["txtHinmei"];

            ((TextBox)c.Controls["txtHinmei"]).Text = "";



            //TextBox1が見つかれば、Textを変更する
            //if (c != null)
            //((TextBox)c).Text += "*";
        }

        // 入力欄削除
        private void btnDelRow_Click(object sender, EventArgs e)
        {
            bool flg = true;
            Button b = (Button)sender;
            //tableLayoutPanel1.Controls.Remove(b.Parent);
            TableLayoutControlCollection c = tableLayoutPanel1.Controls;

            if ((int)b.Tag == cats[0] || (int)b.Tag == cats[2])
            {
                Control[] cs = c.Find("basePanel" + (int.Parse((String)b.Parent.Tag) + 1).ToString(zeroPad), false);
                if (cs != null && cs.Length > 0 && cs[0] != null)
                {
                    delKakoJuchuS((Panel)cs[0], true);
                    flg = false;
                    c.Remove(cs[0]);
                }
            }
            else if ((int)b.Tag == cats[4])
            {
                Control[] cs = c.Find("basePanel" + (int.Parse((String)b.Parent.Tag) - 1).ToString(zeroPad), false);
                if (cs != null && cs.Length > 0 && cs[0] != null)
                {
                    foreach (Control cc in cs[0].Controls)
                    {
                        if (cc.Name != null && cc.Name == "btnAddShukko" + (int.Parse((String)b.Parent.Tag) - 1).ToString(zeroPad))
                        {
                            cc.Visible = true;
                            break;
                        }
                    }
                }
            }
            else if ((int)b.Tag == cats[5])
            {
                Control[] cs = c.Find("basePanel" + (int.Parse((String)b.Parent.Tag) - 1).ToString(zeroPad), false);
                if (cs != null && cs.Length > 0 && cs[0] != null)
                {
                    foreach (Control cc in cs[0].Controls)
                    {
                        if (cc.Name != null && cc.Name == "btnAddKakoShukko" + (int.Parse((String)b.Parent.Tag) - 1).ToString(zeroPad))
                        {
                            cc.Visible = true;
                            break;
                        }
                    }
                }
            }
            delKakoJuchuS((Panel)b.Parent, flg);
            c.Remove(b.Parent);

            int iTotal = 0;

            foreach (Control cc in c)
            {
                if (!string.IsNullOrWhiteSpace(((TextBox)cc.Controls["txtHNo"]).Text)) {
                    if (!((TextBox)cc.Controls["cate"]).Text.Equals(labels[0]))
                    {
                        iTotal += int.Parse(((TextBox)cc.Controls["txtSuryo"]).Text) * int.Parse(((TextBox)cc.Controls["txtTanka"]).Text);
                    }
                }
            }

            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
            try
            {
                juchuB.updateShiireTanka(strHachuNo, (iTotal / int.Parse(strJuchuSu)).ToString());
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

            BaseMessageBox basemessage = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
            basemessage.ShowDialog();

            ctl = null;

            switch ((int)b.Tag)
            {
                case 0:
                    button13.Focus();
                    break;
                case 1:
                    button14.Focus();
                    break;
                case 2:
                    button16.Focus();
                    break;
                case 3:
                    button15.Focus();
                    break;
                case 4:
                    button13.Focus();
                    break;
                default:
                    txtJuchuYMD.Focus();
                    break;
            }
        }

        //
        // 入力欄追加
        //
        private void addInputPanel(int cat)
        {
            if (panelCnt[cat] < cats[cat] * limit * 100 + limit * 100)
            {
                Panel inputPanel = createPanel(cats[cat], panelCnt[cat], "", null);
                tableLayoutPanel1.Controls.Add(inputPanel, 0, panelCnt[cat]);

                foreach (Control cc in inputPanel.Controls)
                {
                    if (cc.Name != null && cc.Name == "txtHYMD" + panelCnt[cat].ToString(zeroPad))
                    {
                        cc.Focus();
                        break;
                    }
                }

                panelCnt[cat] += 100;
            }
        }

        private void addInputPanelVal(int cat, DataRow r)
        {
            if (panelCnt[cat] < cats[cat] * limit * 100 + limit * 100)
            {
                Panel inputPanel = createPanel(cats[cat], panelCnt[cat], "", null);
                tableLayoutPanel1.Controls.Add(inputPanel, 0, panelCnt[cat]);


                ((TextBox)inputPanel.Controls["txtHNo"]).Text = r["発注番号"].ToString();
                ((TextBox)inputPanel.Controls["txtHYMD"]).Text = r["発注年月日"].ToString();
                ((LabelSet_Tantousha)inputPanel.Controls["lsHSha"]).CodeTxtText = r["発注者コード"].ToString();
                ((TextBox)inputPanel.Controls["txtHNo"]).Text = r["発注番号"].ToString();




                foreach (Control cc in inputPanel.Controls)
                {
                    if (cc.Name != null && cc.Name == "txtHYMD" + panelCnt[cat].ToString(zeroPad))
                    {
                        cc.Focus();
                        break;
                    }
                }

                panelCnt[cat] += 100;
            }
        }

        //
        // パネル生成
        //
        private Panel createPanel(int cat, int idx, String hin, Panel c)
        {
            int tabIdx = (int)Math.Pow(10, keta + 2) + (idx * 100);

            if (minimumIdx == 0 || minimumIdx < tabIdx)
            {
                minimumIdx = tabIdx;
            }

            Panel basePanel = new Panel();
            basePanel.Size = new Size(1368, 134);
            basePanel.Name = "basePanel" + idx.ToString(zeroPad);
            basePanel.Tag = idx.ToString(zeroPad);
            basePanel.TabIndex = tabIdx;
            tabIdx++;

            // ガワ
            //Rectangle l = new Rectangle();

            Panel linePanel = new Panel();
            linePanel.Size = new Size(1368, 125);
            basePanel.Controls.Add(linePanel);
            linePanel.Location = new Point(0, 9);
            linePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            linePanel.Name = "linePanel" + idx.ToString(zeroPad);

            Label lblHatTitle = new Label();
            lblHatTitle.Name = "cate";
            lblHatTitle.AutoSize = true;
            lblHatTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lblHatTitle.Text = labels[cat];
            basePanel.Controls.Add(lblHatTitle);
            lblHatTitle.Location = new Point(3, 2);
            lblHatTitle.BringToFront();
            lblHatTitle.BackColor = Color.Transparent;

            // 1行目
            Label lblHYMD = new Label();
            lblHYMD.AutoSize = true;
            lblHYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lblHYMD.BackColor = Color.Transparent;
            lblHYMD.Text = "発注年月日";
            basePanel.Controls.Add(lblHYMD);
            lblHYMD.Location = new Point(4, 22);
            lblHYMD.BringToFront();

            TextBox txtHYMD = new TextBox();
            txtHYMD.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            txtHYMD.Size = new System.Drawing.Size(85, 22);
            txtHYMD.TextAlign = HorizontalAlignment.Right;
            basePanel.Controls.Add(txtHYMD);
            txtHYMD.Location = new Point(97, 19);
            txtHYMD.BringToFront();
            txtHYMD.Name = "txtHYMD" + idx.ToString(zeroPad);
            txtHYMD.TabIndex = tabIdx;
            tabIdx++;

            ctl = txtHYMD;

            LabelSet_Tantousha lsHSha = new LabelSet_Tantousha();
            lsHSha.Name = "lsHSha";
            lsHSha.AutoSize = true;
            lsHSha.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lsHSha.LabelName = "発注者";
            basePanel.Controls.Add(lsHSha);
            lsHSha.Location = new Point(266, 22);
            lsHSha.BringToFront();

            #region
            //Label lblHSha = new Label();
            //lblHSha.AutoSize = true;
            //lblHSha.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ////lblHSha.BackColor = Color.Transparent;
            //lblHSha.Text = "発注者";
            //basePanel.Controls.Add(lblHSha);
            //lblHSha.Location = new Point(266, 22);
            //lblHSha.BringToFront();

            //TextBox txtHSha = new TextBox();
            //txtHSha.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtHSha.Size = new System.Drawing.Size(38, 22);
            //basePanel.Controls.Add(txtHSha);
            //txtHSha.Location = new Point(327, 19);
            //txtHSha.BringToFront();
            //txtHSha.Name = "txtHSha" + idx.ToString(zeroPad);
            //txtHSha.TabIndex = tabIdx;
            //tabIdx++;

            //TextBox txtLHSha = new TextBox();
            //txtLHSha.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtLHSha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //txtLHSha.BackColor = System.Drawing.SystemColors.ScrollBar;
            //txtLHSha.ForeColor = System.Drawing.Color.Navy;
            //txtLHSha.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            //txtLHSha.Size = new System.Drawing.Size(111, 15);
            //txtLHSha.ReadOnly = true;
            //basePanel.Controls.Add(txtLHSha);
            //txtLHSha.Location = new Point(374, 22);
            //txtLHSha.BringToFront();
            //txtLHSha.Name = "txtLHSha" + idx.ToString(zeroPad);
            //txtLHSha.TabStop = false;
            #endregion

            LabelSet_Shiresaki lsShiire = new LabelSet_Shiresaki();
            lsShiire.Name = "lsShiire";
            lsShiire.AutoSize = true;
            lsShiire.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lsShiire.LabelName = "仕入先";
            basePanel.Controls.Add(lsShiire);
            lsShiire.Location = new Point(496, 22);
            lsShiire.BringToFront();

            #region
            //Label lblShiire = new Label();
            //lblShiire.AutoSize = true;
            //lblShiire.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ////lblShiire.BackColor = Color.Transparent;
            //lblShiire.Text = "仕入先";
            //basePanel.Controls.Add(lblShiire);
            //lblShiire.Location = new Point(496, 22);
            //lblShiire.BringToFront();

            //TextBox txtShiireCd = new TextBox();
            //txtShiireCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtShiireCd.Size = new System.Drawing.Size(38, 22);
            //basePanel.Controls.Add(txtShiireCd);
            //txtShiireCd.Location = new Point(573, 19);
            //txtShiireCd.BringToFront();
            //txtShiireCd.Name = "txtShiireCd" + idx.ToString(zeroPad);
            //txtShiireCd.TabIndex = tabIdx;
            //tabIdx++;

            //TextBox txtShiireMei = new TextBox();
            //txtShiireMei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtShiireMei.Size = new System.Drawing.Size(218, 22);
            //basePanel.Controls.Add(txtShiireMei);
            //txtShiireMei.Location = new Point(617, 19);
            //txtShiireMei.BringToFront();
            //txtShiireMei.Name = "txtShiireMei" + idx.ToString(zeroPad);
            //txtShiireMei.TabIndex = tabIdx;
            //tabIdx++;
            #endregion

            Label lblHNo = new Label();
            lblHNo.AutoSize = true;
            lblHNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //lblHNo.BackColor = Color.Transparent;
            lblHNo.Text = "発注番号";
            basePanel.Controls.Add(lblHNo);
            lblHNo.Location = new Point(841, 22);
            lblHNo.BringToFront();

            TextBox txtHNo = new TextBox();
            txtHNo.Name = "txtHNo";
            txtHNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            txtHNo.Size = new System.Drawing.Size(70, 22);
            basePanel.Controls.Add(txtHNo);
            txtHNo.Location = new Point(934, 19);
            txtHNo.BringToFront();
            txtHNo.Name = "txtHNo" + idx.ToString(zeroPad);
            txtHNo.TabIndex = tabIdx;
            tabIdx++;

            // 2行目
            LabelSet_Daibunrui lsDaibun = new LabelSet_Daibunrui();
            lsDaibun.Name = "lsDaibun";
            lsDaibun.AutoSize = true;
            lsDaibun.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lsDaibun.LabelName = "大分類";
            basePanel.Controls.Add(lsDaibun);
            lsDaibun.Location = new Point(36, 52);
            lsDaibun.BringToFront();

            #region
            //Label lblDaibunruiCd = new Label();
            //lblDaibunruiCd.AutoSize = true;
            //lblDaibunruiCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ////lblDaibunruiCd.BackColor = Color.Transparent;
            //lblDaibunruiCd.Text = "大分類";
            //basePanel.Controls.Add(lblDaibunruiCd);
            //lblDaibunruiCd.Location = new Point(36, 52);
            //lblDaibunruiCd.BringToFront();

            //TextBox txtDaibunruiCd = new TextBox();
            //txtDaibunruiCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtDaibunruiCd.Size = new System.Drawing.Size(30, 22);
            //basePanel.Controls.Add(txtDaibunruiCd);
            //txtDaibunruiCd.Location = new Point(97, 49);
            //txtDaibunruiCd.TextAlign = HorizontalAlignment.Right;
            //txtDaibunruiCd.BringToFront();
            //txtDaibunruiCd.Name = "txtDaibunruiCd" + idx.ToString(zeroPad);
            //txtDaibunruiCd.TabIndex = tabIdx;
            //tabIdx++;

            //TextBox txtDaibunruiName = new TextBox();
            //txtDaibunruiName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtDaibunruiName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //txtDaibunruiName.BackColor = System.Drawing.SystemColors.ScrollBar;
            //txtDaibunruiName.ForeColor = System.Drawing.Color.Navy;
            //txtDaibunruiName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            //txtDaibunruiName.Size = new System.Drawing.Size(111, 15);
            //txtDaibunruiName.ReadOnly = true;
            //basePanel.Controls.Add(txtDaibunruiName);
            //txtDaibunruiName.Location = new Point(144, 52);
            //txtDaibunruiName.BringToFront();
            //txtDaibunruiName.Name = "txtDaibunruiName" + idx.ToString(zeroPad);
            //txtDaibunruiName.TabStop = false;
            #endregion

            LabelSet_Chubunrui lsChubun = new LabelSet_Chubunrui();
            lsChubun.Name = "lsChubun";
            lsChubun.AutoSize = true;
            lsChubun.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lsChubun.LabelName = "中分類";
            basePanel.Controls.Add(lsChubun);
            lsChubun.Location = new Point(266, 52);
            lsChubun.BringToFront();

            #region
            //Label lblChubunruiCd = new Label();
            //lblChubunruiCd.AutoSize = true;
            //lblChubunruiCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ////lblChubunruiCd.BackColor = Color.Transparent;
            //lblChubunruiCd.Text = "中分類";
            //basePanel.Controls.Add(lblChubunruiCd);
            //lblChubunruiCd.Location = new Point(266, 52);
            //lblChubunruiCd.BringToFront();

            //TextBox txtChubunruiCd = new TextBox();
            //txtChubunruiCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtChubunruiCd.Size = new System.Drawing.Size(30, 22);
            //txtChubunruiCd.TextAlign = HorizontalAlignment.Right;
            //basePanel.Controls.Add(txtChubunruiCd);
            //txtChubunruiCd.Location = new Point(327, 49);
            //txtChubunruiCd.BringToFront();
            //txtChubunruiCd.Name = "txtChubunruiCd" + idx.ToString(zeroPad);
            //txtChubunruiCd.TabIndex = tabIdx;
            //tabIdx++;

            //TextBox txtChubunruiName = new TextBox();
            //txtChubunruiName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtChubunruiName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //txtChubunruiName.BackColor = System.Drawing.SystemColors.ScrollBar;
            //txtChubunruiName.ForeColor = System.Drawing.Color.Navy;
            //txtChubunruiName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            //txtChubunruiName.Size = new System.Drawing.Size(111, 15);
            //txtChubunruiName.ReadOnly = true;
            //basePanel.Controls.Add(txtChubunruiName);
            //txtChubunruiName.Location = new Point(374, 52);
            //txtChubunruiName.BringToFront();
            //txtChubunruiName.Name = "txtChubunruiName" + idx.ToString(zeroPad);
            //txtChubunruiName.TabStop = false;
            #endregion

            LabelSet_Maker lsMaker = new LabelSet_Maker();
            lsMaker.Name = "lsMaker";
            lsMaker.AutoSize = true;
            lsMaker.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lsMaker.LabelName = "メーカー";
            basePanel.Controls.Add(lsMaker);
            lsMaker.Location = new Point(496, 52);
            lsMaker.BringToFront();

            #region
            //Label lblMakerCd = new Label();
            //lblMakerCd.AutoSize = true;
            //lblMakerCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ////lblMakerCd.BackColor = Color.Transparent;
            //lblMakerCd.Text = "メーカー";
            //basePanel.Controls.Add(lblMakerCd);
            //lblMakerCd.Location = new Point(496, 52);
            //lblMakerCd.BringToFront();

            //TextBox txtMakerCd = new TextBox();
            //txtMakerCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtMakerCd.Size = new System.Drawing.Size(30, 22);
            //basePanel.Controls.Add(txtMakerCd);
            //txtMakerCd.Location = new Point(573, 49);
            //txtMakerCd.TextAlign = HorizontalAlignment.Right;
            //txtMakerCd.BringToFront();
            //txtMakerCd.Name = "txtMakerCd" + idx.ToString(zeroPad);
            //txtMakerCd.TabIndex = tabIdx;
            //tabIdx++;

            //TextBox txtMakerName = new TextBox();
            //txtMakerName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtMakerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //txtMakerName.BackColor = System.Drawing.SystemColors.ScrollBar;
            //txtMakerName.ForeColor = System.Drawing.Color.Navy;
            //txtMakerName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            //txtMakerName.Size = new System.Drawing.Size(111, 15);
            //txtMakerName.ReadOnly = true;
            //basePanel.Controls.Add(txtMakerName);
            //txtMakerName.Location = new Point(620, 52);
            //txtMakerName.BringToFront();
            //txtMakerName.Name = "txtMakerName" + idx.ToString(zeroPad);
            //txtMakerName.TabStop = false;
            #endregion

            Label lblSearchStr = new Label();
            lblSearchStr.AutoSize = true;
            lblSearchStr.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //lblSearchStr.BackColor = Color.Transparent;
            lblSearchStr.Text = "検索文字列";
            basePanel.Controls.Add(lblSearchStr);
            lblSearchStr.Location = new Point(841, 52);
            lblSearchStr.BringToFront();

            TextBox txtSearchStr = new TextBox();
            txtSearchStr.Name = "txtSearchStr";
            txtSearchStr.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            txtSearchStr.Size = new System.Drawing.Size(271, 22);
            basePanel.Controls.Add(txtSearchStr);
            txtSearchStr.Location = new Point(934, 49);
            txtSearchStr.BringToFront();
            txtSearchStr.Name = "txtSearchStr" + idx.ToString(zeroPad);
            txtSearchStr.TabIndex = tabIdx;
            tabIdx++;
            txtSearchStr.Leave += new EventHandler(txtSearchStr_Leave);

            // 3行目
            Label lblHinmei = new Label();
            lblHinmei.AutoSize = true;
            lblHinmei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //lblHinmei.BackColor = Color.Transparent;
            lblHinmei.Text = "品名";
            basePanel.Controls.Add(lblHinmei);
            lblHinmei.Location = new Point(52, 80);
            lblHinmei.BringToFront();

            #region
            //TextBox txtHinmeiM = new TextBox();
            //txtHinmeiM.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtHinmeiM.Size = new System.Drawing.Size(109, 22);
            //basePanel.Controls.Add(txtHinmeiM);
            //txtHinmeiM.Location = new Point(97, 77);
            //txtHinmeiM.BringToFront();
            //txtHinmeiM.Name = "txtHinmeiM" + idx.ToString(zeroPad);
            //txtHinmeiM.TabIndex = tabIdx;
            //tabIdx++;

            //TextBox txtHinmeiC = new TextBox();
            //txtHinmeiC.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtHinmeiC.Size = new System.Drawing.Size(109, 22);
            //basePanel.Controls.Add(txtHinmeiC);
            //txtHinmeiC.Location = new Point(212, 77);
            //txtHinmeiC.BringToFront();
            //txtHinmeiC.Name = "txtHinmeiC" + idx.ToString(zeroPad);
            //txtHinmeiC.TabIndex = tabIdx;
            //tabIdx++;
            #endregion

            TextBox txtHinmei = new TextBox();
            txtHinmei.Name = "txtHinmei";
            txtHinmei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            txtHinmei.Size = new System.Drawing.Size(331, 22);
            basePanel.Controls.Add(txtHinmei);
            //txtHinmei.Location = new Point(327, 77);
            txtHinmei.Location = new Point(97, 77);
            txtHinmei.BringToFront();
            txtHinmei.Name = "txtHinmei" + idx.ToString(zeroPad);
            txtHinmei.TabIndex = tabIdx;
            tabIdx++;

            TextBox txtHinmeiY = new TextBox();
            txtHinmeiY.Name = "txtHinmeiY";
            txtHinmeiY.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            txtHinmeiY.Size = new System.Drawing.Size(169, 22);
            basePanel.Controls.Add(txtHinmeiY);
            //txtHinmeiY.Location = new Point(664, 77);
            txtHinmeiY.Location = new Point(434, 77);
            txtHinmeiY.BringToFront();
            txtHinmeiY.Name = "txtHinmeiY" + idx.ToString(zeroPad);
            txtHinmeiY.TabIndex = tabIdx;
            tabIdx++;

            Label lblTanaban = new Label();
            lblTanaban.AutoSize = true;
            lblTanaban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //lblTanaban.BackColor = Color.Transparent;
            lblTanaban.Text = "棚番";
            basePanel.Controls.Add(lblTanaban);
            //lblTanaban.Location = new Point(841, 80);
            lblTanaban.Location = new Point(617, 80);
            lblTanaban.BringToFront();

            TextBox txtTanabanL = new TextBox();
            txtTanabanL.Name = "txtTanabanL";
            txtTanabanL.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            txtTanabanL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtTanabanL.BackColor = System.Drawing.SystemColors.ScrollBar;
            txtTanabanL.ForeColor = System.Drawing.Color.Navy;
            txtTanabanL.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            txtTanabanL.Size = new System.Drawing.Size(45, 15);
            txtTanabanL.ReadOnly = true;
            basePanel.Controls.Add(txtTanabanL);
            //txtTanabanL.Location = new Point(934, 80);
            txtTanabanL.Location = new Point(661, 80);
            txtTanabanL.BringToFront();
            txtTanabanL.Name = "txtTanabanL" + idx.ToString(zeroPad);
            txtTanabanL.TabStop = false;

            TextBox txtTanabanR = new TextBox();
            txtTanabanR.Name = "txtTanabanR";
            txtTanabanR.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            txtTanabanR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtTanabanR.BackColor = System.Drawing.SystemColors.ScrollBar;
            txtTanabanR.ForeColor = System.Drawing.Color.Navy;
            txtTanabanR.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            txtTanabanR.Size = new System.Drawing.Size(45, 15);
            txtTanabanR.ReadOnly = true;
            basePanel.Controls.Add(txtTanabanR);
            //txtTanabanR.Location = new Point(982, 80);
            txtTanabanR.Location = new Point(709, 80);
            txtTanabanR.BringToFront();
            txtTanabanR.Name = "txtTanabanR" + idx.ToString(zeroPad);
            txtTanabanR.TabStop = false;

            // 4行目
            Label lblSuryo = new Label();
            lblSuryo.AutoSize = true;
            lblSuryo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //lblSuryo.BackColor = Color.Transparent;
            lblSuryo.Text = "数量";
            basePanel.Controls.Add(lblSuryo);
            lblSuryo.Location = new Point(52, 108);
            lblSuryo.BringToFront();

            TextBox txtSuryo = new BaseTextMoney();
            txtSuryo.Name = "txtSuryo";
            txtSuryo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            txtSuryo.Size = new System.Drawing.Size(77, 22);
            txtSuryo.TextAlign = HorizontalAlignment.Right;
            basePanel.Controls.Add(txtSuryo);
            txtSuryo.Location = new Point(97, 105);
            txtSuryo.BringToFront();
            txtSuryo.Name = "txtSuryo" + idx.ToString(zeroPad);
            txtSuryo.TabIndex = tabIdx;
            tabIdx++;

            Label lblTanka = new Label();
            lblTanka.AutoSize = true;
            lblTanka.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //lblTanka.BackColor = Color.Transparent;
            lblTanka.Text = "単価";
            basePanel.Controls.Add(lblTanka);
            lblTanka.Location = new Point(199, 108);
            lblTanka.BringToFront();

            TextBox txtTanka = new BaseTextMoney();
            txtTanka.Name = "txtTanka";
            txtTanka.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            txtTanka.Size = new System.Drawing.Size(77, 22);
            txtTanka.TextAlign = HorizontalAlignment.Right;
            basePanel.Controls.Add(txtTanka);
            txtTanka.Location = new Point(244, 105);
            txtTanka.BringToFront();
            txtTanka.Name = "txtTanka" + idx.ToString(zeroPad);
            txtTanka.TabIndex = tabIdx;
            tabIdx++;

            Label lblNohki = new Label();
            lblNohki.AutoSize = true;
            lblNohki.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //lblNohki.BackColor = Color.Transparent;
            lblNohki.Text = labelsNohki[cat];
            basePanel.Controls.Add(lblNohki);
            if (cat == cats[1] || cat == cats[4])
            {
                lblNohki.Location = new Point(337, 108);
            }
            else
            {
                lblNohki.Location = new Point(348, 108);
            }
            lblNohki.BringToFront();

            TextBox txtNohki = new BaseCalendar();
            txtNohki.Name = "txtNohki";
            txtNohki.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            txtNohki.Size = new System.Drawing.Size(85, 22);
            txtNohki.TextAlign = HorizontalAlignment.Right;
            basePanel.Controls.Add(txtNohki);
            txtNohki.Location = new Point(393, 105);
            txtNohki.BringToFront();
            txtNohki.Name = "txtNohki" + idx.ToString(zeroPad);
            txtNohki.TabIndex = tabIdx;
            tabIdx++;

            Label lblChuban = new Label();
            lblChuban.AutoSize = true;
            lblChuban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //lblChuban.BackColor = Color.Transparent;
            lblChuban.Text = "注番";
            basePanel.Controls.Add(lblChuban);
            lblChuban.Location = new Point(505, 108);
            lblChuban.BringToFront();

            TextBox txtChuban = new TextBox();
            txtChuban.Name = "txtChuban";
            txtChuban.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            txtChuban.Size = new System.Drawing.Size(197, 22);
            basePanel.Controls.Add(txtChuban);
            txtChuban.Location = new Point(550, 105);
            txtChuban.BringToFront();
            txtChuban.Name = "txtChuban" + idx.ToString(zeroPad);
            txtChuban.TabIndex = tabIdx;
            tabIdx++;

            if (cat == cats[0])
            {
                Button btnAddShukko = new Button();
                btnAddShukko.Text = "出庫";
                btnAddShukko.Tag = cat;
                basePanel.Controls.Add(btnAddShukko);
                btnAddShukko.Click += new EventHandler(btnAddShukko_Click);
                btnAddShukko.Location = new Point(1206, 105);
                btnAddShukko.BringToFront();
                btnAddShukko.Name = "btnAddShukko" + idx.ToString(zeroPad);
                btnAddShukko.TabIndex = tabIdx;
                tabIdx++;
            }
            else if (cat == cats[2])
            {
                if (checkBox1.Checked == false)
                {
                    Button btnAddShukko = new Button();
                    btnAddShukko.Text = "加工品出庫";
                    btnAddShukko.Tag = cat;
                    basePanel.Controls.Add(btnAddShukko);
                    btnAddShukko.Click += new EventHandler(btnAddKakoShukko_Click);
                    btnAddShukko.Location = new Point(1206, 105);
                    btnAddShukko.BringToFront();
                    btnAddShukko.Name = "btnAddKakoShukko" + idx.ToString(zeroPad);
                    btnAddShukko.TabIndex = tabIdx;
                    tabIdx++;
                }
                else
                {
                    A0010_JuchuInput frm1;

                    frm1 = (A0010_JuchuInput)this.Parent;

                    if (!frm1.txtHinmei.Text.Equals(this.txtHinmei.Text))
                    {
                        Button btnAddShukko = new Button();
                        btnAddShukko.Text = "加工品出庫";
                        btnAddShukko.Tag = cat;
                        basePanel.Controls.Add(btnAddShukko);
                        btnAddShukko.Click += new EventHandler(btnAddKakoShukko_Click);
                        btnAddShukko.Location = new Point(1206, 105);
                        btnAddShukko.BringToFront();
                        btnAddShukko.Name = "btnAddKakoShukko" + idx.ToString(zeroPad);
                        btnAddShukko.TabIndex = tabIdx;
                        tabIdx++;
                    }
                }
            }

            Button btnDelRow = new Button();
            btnDelRow.Text = "取消";
            btnDelRow.Tag = cat;
            basePanel.Controls.Add(btnDelRow);
            btnDelRow.Click += new EventHandler(btnDelRow_Click);
            btnDelRow.Location = new Point(1286, 105);
            btnDelRow.BringToFront();
            btnDelRow.TabIndex = tabIdx;
            tabIdx++;

            if (this.checkBox1.Checked == true)
            {
                txtHYMD.Text = txtJuchuYMD.Text;
                lsHSha.CodeTxtText = ((A0010_JuchuInput)this.Parent).lsJuchusha.CodeTxtText;
                lsHSha.ValueLabelText = ((A0010_JuchuInput)this.Parent).lsJuchusha.ValueLabelText;
                lsShiire.CodeTxtText = ((A0010_JuchuInput)this.Parent).tsShiiresaki.CodeTxtText;
                lsShiire.ValueLabelText = ((A0010_JuchuInput)this.Parent).tsShiiresaki.valueTextText;
                lsDaibun.CodeTxtText = lsDaibunruiM.CodeTxtText;
                lsDaibun.ValueLabelText = lsDaibunruiM.ValueLabelText;
                lsChubun.CodeTxtText = lsChubunruiM.CodeTxtText;
                lsChubun.ValueLabelText = lsChubunruiM.ValueLabelText;
                lsMaker.CodeTxtText = lsMakerM.CodeTxtText;
                lsMaker.ValueLabelText = lsMakerM.ValueLabelText;
                txtHinmei.Text = this.txtHinmei.Text;
            }

            return basePanel;
        }

        private void Form6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //addKakoJuchu();
            }
            else if (e.KeyCode == Keys.F3)
            {
                delKakoJuchu();
            }
            else if (e.KeyCode == Keys.F4)
            {
                //clearInput();
            }
            else if (e.KeyCode == Keys.F6)
            {
                //delKakoJuchuS();
            }
            else if (e.KeyCode == Keys.F8)
            {

            }
            else if (e.KeyCode == Keys.F12)
            {
                this.Close();
                this.Dispose();
            }
        }


        private void delKakoJuchu()
        {
            BaseMessageBox basemessage;
            
            if (string.IsNullOrWhiteSpace(strJuchuNo))
            {
                basemessage = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "削除する伝票を呼び出してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessage.ShowDialog();
                return;
            }

            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
            try
            {
                BaseMessageBox basemessagebox; 

                int intSuryo = juchuB.getUriagezumisuryo(strJuchuNo);
                if (intSuryo > 0)
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに売上済みです。削除できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                intSuryo = juchuB.getShiirezumisuryo(strJuchuNo);
                if (intSuryo > 0)
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに仕入済みです。削除できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                string strFlg = juchuB.getZaikoHikiateFlg(strJuchuNo);
                if (strFlg.Equals("1"))
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "在庫が既に移動処理されています。変更・削除は禁止です", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                strFlg = juchuB.getShukkoFlg(strJuchuNo);
                if (strFlg.Equals("1"))
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "在庫が既に移動処理されています。変更・削除は禁止です", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                intSuryo = juchuB.getShukkoToroku(strJuchuNo);
                if (intSuryo > 0)
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫登録が残っています。先に出庫データを削除してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                BaseMessageBox basemessageboxSa = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessageboxSa.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                juchuB.delJuchu(strJuchuNo, lblStatusUser.Text);

                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //clearInput();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void delKakoJuchuS(Panel c, bool f)
        {
            strHachuNo = ((TextBox)c.Controls["txtHNo"]).Text;

            if (string.IsNullOrWhiteSpace(strHachuNo))
            {
                return;
            }

            string cate = ((TextBox)c.Controls["cate"]).Text;
            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();

            try
            {
                BaseMessageBox basemessagebox;
                if (cate.Equals(labels[0]) || cate.Equals(labels[2]))
                {
                    int intSuryo = juchuB.getShiirezumisuryo(strHachuNo);
                    if (intSuryo > 0)
                    {
                        basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに仕入済みです。削除できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        return;
                    }
                }

                string strFlg = juchuB.getZaikoHikiateFlg(strJuchuNo);
                if (strFlg.Equals("1"))
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "在庫が既に移動処理されています。変更・削除は禁止です", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                strFlg = juchuB.getShukkoFlg(strJuchuNo);
                if (strFlg.Equals("1"))
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "在庫が既に移動処理されています。変更・削除は禁止です", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }
                if (f == true) {
                    BaseMessageBox basemessageboxSa = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                    //NOが押された場合
                    if (basemessageboxSa.ShowDialog() == DialogResult.No)
                    {
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void getInfo()
        {
            BaseMessageBox basemessagebox;
            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();

            try
            {
                DataTable dt = juchuB.getJuchuNoInfo(strJuchuNo);

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtJuchuYMD.Text = dt.Rows[0]["受注年月日"].ToString();
                    lsDaibunruiM.CodeTxtText = dt.Rows[0]["大分類コード"].ToString();
                    lsChubunruiM.CodeTxtText = dt.Rows[0]["中分類コード"].ToString();
                    lsMakerM.CodeTxtText = dt.Rows[0]["メーカーコード"].ToString();

                    strC1 = dt.Rows[0]["Ｃ１"].ToString();
                    strC2 = dt.Rows[0]["Ｃ２"].ToString();
                    strC3 = dt.Rows[0]["Ｃ３"].ToString();
                    strC4 = dt.Rows[0]["Ｃ４"].ToString();
                    strC5 = dt.Rows[0]["Ｃ５"].ToString();
                    strC6 = dt.Rows[0]["Ｃ６"].ToString();
                    strJuchuSu = dt.Rows[0]["受注数量"].ToString();
                    strJuchuTanka = dt.Rows[0]["受注単価"].ToString();
                    strShiireTanka = dt.Rows[0]["仕入単価"].ToString();
                    strNoki = dt.Rows[0]["納期"].ToString();
                    strChuban = dt.Rows[0]["注番"].ToString();
                    strEigyosho = dt.Rows[0]["営業所コード"].ToString();
                    strTantosha = dt.Rows[0]["担当者コード"].ToString();
                    strTokuiCd = dt.Rows[0]["得意先コード"].ToString();
                    strShohin = dt.Rows[0]["商品コード"].ToString();

                    txtHinmei.Text = strC1 + " " + strC2 + " " + strC3 + " " + strC4 + " " + strC5 + " " + strC6;

                    getRireki();

                    if (!string.IsNullOrWhiteSpace(strShohin) && strShohin.Equals("88888"))
                    {
                        lsDaibunruiM.Enabled = true;
                        lsChubunruiM.Enabled = true;
                        lsMakerM.Enabled = true;
                    }
                    else
                    {
                        lsDaibunruiM.Enabled = false;
                        lsChubunruiM.Enabled = false;
                        lsMakerM.Enabled = false;
                        txtHinmei.Enabled = false;
                    }

                    if (dt.Rows[0]["売上済数量"].ToString().Equals(dt.Rows[0]["受注数量"].ToString()))
                    {
                        basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "売上済の受注です。変更は不可です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        btnF01.Enabled = false;
                        btnF03.Enabled = false;
                        btnF08.Enabled = false;
                        btnF09.Enabled = false;
                        button13.Enabled = false;
                        button14.Enabled = false;
                        button15.Enabled = false;
                        button16.Enabled = false;
                        return;
                    }
                    else if (dt.Rows[0]["売上済数量"].ToString().CompareTo("0") > 0)
                    {
                        basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに売上済みです。納期・数量・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        txtJuchuYMD.Enabled = false;
                        lsDaibunruiM.Enabled = false;
                        lsChubunruiM.Enabled = false;
                        lsMakerM.Enabled = false;
                        txtSearchStr.Enabled = false;
                        txtHinmei.Enabled = false;
                        return;
                    }

                    int iSu = juchuB.getShiirezumisuryo(strJuchuNo);

                    if (iSu > -1)
                    {
                        if (iSu > 0)
                        {
                            basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに仕入済みです。納期・数量・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();
                            txtJuchuYMD.Enabled = false;
                            lsDaibunruiM.Enabled = false;
                            lsChubunruiM.Enabled = false;
                            lsMakerM.Enabled = false;
                            txtSearchStr.Enabled = false;
                            txtHinmei.Enabled = false;
                        }
                        else
                        {
                            txtJuchuYMD.Enabled = true;
                            lsDaibunruiM.Enabled = true;
                            lsChubunruiM.Enabled = true;
                            lsMakerM.Enabled = true;
                            txtSearchStr.Enabled = true;
                            txtHinmei.Enabled = true;
                        }
                    }
                    else
                    {
                        txtJuchuYMD.Enabled = true;
                        lsDaibunruiM.Enabled = true;
                        lsChubunruiM.Enabled = true;
                        lsMakerM.Enabled = true;
                        txtSearchStr.Enabled = true;
                        txtHinmei.Enabled = true;
                    }
                }

                getZaikoInfo();

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void getRireki()
        {
            if (string.IsNullOrWhiteSpace(strJuchuNo))
            {
                return;
            }

            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();

            try
            {
                DataTable dt =  juchuB.getRireki(strJuchuNo);

                if (dt == null)
                {
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int iCate = 0;

                    switch (dt.Rows[i]["区分"].ToString())
                    {
                        case "発注":
                            iCate = 0;
                            break;
                        case "出庫":
                            iCate = 1;
                            break;
                        case "本加工":
                            iCate = 2;
                            break;
                        case "加工品出庫":
                            iCate = 3;
                            break;

                        default:
                            iCate = -1;
                            break;
                    }

                    if (iCate != -1) {
                        addInputPanelVal(cats[iCate], dt.Rows[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void getZaikoInfo()
        {
            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
            try
            {
                DataTable dtZan = juchuB.getZaikoInfo(strShohin);
                gridZaiko.DataSource = dtZan;
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }



        //Control c = this.Controls["TextBox1"];
        //TextBox1が見つかれば、Textを変更する
        //if (c != null)
        //((TextBox)c).Text += "*";

    }
}
