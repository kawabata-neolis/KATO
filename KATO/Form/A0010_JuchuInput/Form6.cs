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
using KATO.Business.A0030_ShireInput;

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

        A0010_JuchuInput a0010JInput;
        public String strJuchuNo = "";
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
        string strTokuiName;
        string strShohin;
        string strTeika;

        public Form6(A0010_JuchuInput c)
        {
            a0010JInput = c;
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

            //A0010_JuchuInput frm1;

            //frm1 = (A0010_JuchuInput)this.Parent;
            txtHinmei.Text = a0010JInput.txtHinmei.Text;
            strJuchuNo = a0010JInput.txtJuchuNo.Text;
            strJuchuSu = a0010JInput.txtJuchuSuryo.Text;

            SetUpGrid();
            getInfo();
        }

        private void SetUpGrid()
        {
            //列自動生成禁止
            //gridZanList.AutoGenerateColumns = false;

            //データをバインド
            #region
            DataGridViewTextBoxColumn eigyosho = new DataGridViewTextBoxColumn();
            eigyosho.DataPropertyName = "営業所";
            eigyosho.Name = "営業所";
            eigyosho.HeaderText = "営業所";

            DataGridViewTextBoxColumn zaikosu = new DataGridViewTextBoxColumn();
            zaikosu.DataPropertyName = "在庫数";
            zaikosu.Name = "在庫数";
            zaikosu.HeaderText = "在庫数";

            DataGridViewTextBoxColumn juchzan = new DataGridViewTextBoxColumn();
            juchzan.DataPropertyName = "受注残";
            juchzan.Name = "受注残";
            juchzan.HeaderText = "受注残";

            DataGridViewTextBoxColumn hatchuzan = new DataGridViewTextBoxColumn();
            hatchuzan.DataPropertyName = "発注残";
            hatchuzan.Name = "発注残";
            hatchuzan.HeaderText = "発注残";

            DataGridViewTextBoxColumn juchzanUke = new DataGridViewTextBoxColumn();
            juchzanUke.DataPropertyName = "発注残受";
            juchzanUke.Name = "発注残受";
            juchzanUke.HeaderText = "発注残(受)";

            DataGridViewTextBoxColumn freeZaiko = new DataGridViewTextBoxColumn();
            freeZaiko.DataPropertyName = "ﾌﾘｰ在庫";
            freeZaiko.Name = "ﾌﾘｰ在庫";
            freeZaiko.HeaderText = "ﾌﾘｰ在庫";
            #endregion

            //バインド、個々の幅、文章の寄せの設定
            #region
            setColumn(gridZaiko, eigyosho, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 61);
            setColumn(gridZaiko, zaikosu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 66);
            setColumn(gridZaiko, juchzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 66);
            setColumn(gridZaiko, hatchuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 66);
            setColumn(gridZaiko, juchzanUke, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 96);
            setColumn(gridZaiko, freeZaiko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 74);

            #endregion
        }

        ///<summary>
        ///setColumn
        ///Grid列設定
        ///</summary>
        private void setColumn(Common.Ctl.BaseDataGridView gr, DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gr.Columns.Add(col);
            if (gr.Columns[col.Name] != null)
            {
                gr.Columns[col.Name].Width = intLen;
                gr.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gr.Columns[col.Name].HeaderCell.Style.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                gr.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gr.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
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
                //if (cc.Name != null && cc.Name == "txtHYMD" + idx.ToString(zeroPad))
                if (cc.Name != null && cc.Name == "txtHYMD")
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
            //    if (cc.Name != null && cc.Name == "linePanel" + (decimal.Parse((String)b.Parent.Tag)).ToString(zeroPad))
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
            //        s = ((BaseText)cc).Text;
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
                //if (cc.Name != null && cc.Name == "txtHYMD" + idx.ToString(zeroPad))
                if (cc.Name != null && cc.Name == "txtHYMD")
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
            //    if (cc.Name != null && cc.Name == "linePanel" + (decimal.Parse((String)b.Parent.Tag)).ToString(zeroPad))
            //    {
            //        //cc.BackColor = Color.FromArgb(0x66, 0xFF, 0x66);
            //        break;
            //    }
            //}
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
                        //if (cc.Name != null && cc.Name == "btnAddShukko" + (int.Parse((String)b.Parent.Tag) - 1).ToString(zeroPad))
                        if (cc.Name != null && cc.Name == "btnAddShukko")
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
                        //if (cc.Name != null && cc.Name == "btnAddKakoShukko" + (int.Parse((String)b.Parent.Tag) - 1).ToString(zeroPad))
                        if (cc.Name != null && cc.Name == "btnAddKakoShukko")
                        {
                            cc.Visible = true;
                            break;
                        }
                    }
                }
            }
            delKakoJuchuS((Panel)b.Parent, flg);
            c.Remove(b.Parent);

            decimal decTotal = 0;

            foreach (Control cc in c)
            {
                if (!string.IsNullOrWhiteSpace(((BaseTextMoney)cc.Controls["txtHNo"]).Text))
                {
                    if (!((Label)cc.Controls["cate"]).Text.Equals(labels[0]))
                    {
                        decTotal += decimal.Parse(((BaseTextMoney)cc.Controls["txtSuryo"]).Text) * decimal.Parse(((BaseText)cc.Controls["txtTanka"]).Text);
                    }
                }
            }

            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
            try
            {
                juchuB.updateShiireTanka(strJuchuNo, (decTotal / decimal.Parse(strJuchuSu)).ToString());
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
                    //if (cc.Name != null && cc.Name == "txtHYMD" + panelCnt[cat].ToString(zeroPad))
                    if (cc.Name != null && cc.Name == "txtHYMD")
                    {
                        cc.Focus();
                        break;
                    }
                }

                panelCnt[cat] += 100;
            }
        }

        private void addInputPanelVal(int cat, DataRow r, int num)
        {
            if (panelCnt[cat] < cats[cat] * limit * 100 + limit * 100)
            {
                Panel inputPanel = createPanel(cats[cat], panelCnt[cat], "", null);

                tableLayoutPanel1.Controls.Add(inputPanel, 0, panelCnt[cat]);

                ((BaseCalendar)inputPanel.Controls["txtHYMD"]).Text = r["発注年月日"].ToString();
                ((LabelSet_Tantousha)inputPanel.Controls["lsHSha"]).CodeTxtText = r["発注者コード"].ToString();
                ((LabelSet_Shiresaki)inputPanel.Controls["lsShiire"]).CodeTxtText = r["仕入先コード"].ToString();
                ((BaseTextMoney)inputPanel.Controls["txtHNo"]).Text = r["発注番号"].ToString();
                ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).CodeTxtText = r["大分類コード"].ToString();
                ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).chkTxtDaibunrui();
                ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).CodeTxtText = r["中分類コード"].ToString();
                ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).chkTxtChubunrui(((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).CodeTxtText);
                ((LabelSet_Maker)inputPanel.Controls["lsMaker"]).CodeTxtText = r["メーカーコード"].ToString();
                ((BaseText)inputPanel.Controls["txtHinmei"]).Text = r["品名"].ToString();
                ((BaseLabelGray)inputPanel.Controls["txtTanabanL"]).Text = r["棚番本社"].ToString();
                ((BaseLabelGray)inputPanel.Controls["txtTanabanR"]).Text = r["棚番岐阜"].ToString();
                ((BaseTextMoney)inputPanel.Controls["txtSuryo"]).Text = r["発注数量"].ToString();
                ((BaseTextMoney)inputPanel.Controls["txtTanka"]).Text = r["発注単価"].ToString();
                ((BaseCalendar)inputPanel.Controls["txtNohki"]).Text = r["納期"].ToString();
                ((BaseText)inputPanel.Controls["txtChuban"]).Text = r["注番"].ToString();

                ((BaseCalendar)inputPanel.Controls["tmpHYMD"]).Text = r["発注年月日"].ToString();
                ((BaseText)inputPanel.Controls["tmpHSha"]).Text = r["発注者コード"].ToString();
                ((BaseText)inputPanel.Controls["tmpShiire"]).Text = r["仕入先コード"].ToString();
                ((BaseTextMoney)inputPanel.Controls["tmpHNo"]).Text = r["発注番号"].ToString();
                ((BaseText)inputPanel.Controls["tmpDaibun"]).Text = r["大分類コード"].ToString();
                ((BaseText)inputPanel.Controls["tmpChubun"]).Text = r["中分類コード"].ToString();
                ((BaseText)inputPanel.Controls["tmpMaker"]).Text = r["メーカーコード"].ToString();
                ((BaseText)inputPanel.Controls["tmpHinmei"]).Text = r["品名"].ToString();
                ((BaseTextMoney)inputPanel.Controls["tmpSuryo"]).Text = r["発注数量"].ToString();
                ((BaseTextMoney)inputPanel.Controls["tmpTanka"]).Text = r["発注単価"].ToString();
                ((BaseCalendar)inputPanel.Controls["tmpNohki"]).Text = r["納期"].ToString();
                ((BaseText)inputPanel.Controls["tmpChuban"]).Text = r["注番"].ToString();

                ((BaseText)inputPanel.Controls["txtC1"]).Text = r["Ｃ１"].ToString();
                ((BaseText)inputPanel.Controls["txtC2"]).Text = r["Ｃ２"].ToString();
                ((BaseText)inputPanel.Controls["txtC3"]).Text = r["Ｃ３"].ToString();
                ((BaseText)inputPanel.Controls["txtC4"]).Text = r["Ｃ４"].ToString();
                ((BaseText)inputPanel.Controls["txtC5"]).Text = r["Ｃ５"].ToString();
                ((BaseText)inputPanel.Controls["txtC6"]).Text = r["Ｃ６"].ToString();
                ((BaseText)inputPanel.Controls["txtShohin"]).Text = r["商品コード"].ToString();
                ((BaseText)inputPanel.Controls["txtShiireSu"]).Text = r["仕入済数量"].ToString();
                ((BaseText)inputPanel.Controls["txtShiireBi"]).Text = r["仕入日"].ToString();
                ((BaseText)inputPanel.Controls["txtKataban"]).Text = r["型番"].ToString();

                if (num == 1)
                {
                    ((BaseCalendar)inputPanel.Controls["txtHYMD"]).ReadOnly = true;
                    ((LabelSet_Tantousha)inputPanel.Controls["lsHSha"]).codeTxt.ReadOnly = true;
                    ((LabelSet_Shiresaki)inputPanel.Controls["lsShiire"]).codeTxt.ReadOnly = true;
                    ((BaseTextMoney)inputPanel.Controls["txtHNo"]).ReadOnly = true;
                    ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).codeTxt.ReadOnly = true;
                    ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).codeTxt.ReadOnly = true;
                    ((LabelSet_Maker)inputPanel.Controls["lsMaker"]).codeTxt.ReadOnly = true;
                    ((BaseText)inputPanel.Controls["txtHinmei"]).ReadOnly = true;
                    ((BaseTextMoney)inputPanel.Controls["txtSuryo"]).ReadOnly = true;
                    ((BaseTextMoney)inputPanel.Controls["txtTanka"]).ReadOnly = true;
                    ((BaseCalendar)inputPanel.Controls["txtNohki"]).ReadOnly = true;
                    ((BaseText)inputPanel.Controls["txtChuban"]).ReadOnly = true;

                }
                else if (num == 2)
                {
                    ((BaseCalendar)inputPanel.Controls["txtHYMD"]).ReadOnly = true;
                    ((LabelSet_Tantousha)inputPanel.Controls["lsHSha"]).codeTxt.ReadOnly = true;
                    ((LabelSet_Shiresaki)inputPanel.Controls["lsShiire"]).codeTxt.ReadOnly = true;
                    ((BaseTextMoney)inputPanel.Controls["txtHNo"]).ReadOnly = true;
                    ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).codeTxt.ReadOnly = true;
                    ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).codeTxt.ReadOnly = true;
                    ((LabelSet_Maker)inputPanel.Controls["lsMaker"]).codeTxt.ReadOnly = true;
                    ((BaseText)inputPanel.Controls["txtHinmei"]).ReadOnly = true;
                    ((BaseTextMoney)inputPanel.Controls["txtTanka"]).ReadOnly = true;
                                    }

//                tableLayoutPanel1.Controls.Add(inputPanel, 0, panelCnt[cat]);

                foreach (Control cc in inputPanel.Controls)
                {
                    //if (cc.Name != null && cc.Name == "txtHYMD" + panelCnt[cat].ToString(zeroPad))
                    if (cc.Name != null && cc.Name == "txtHYMD")
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
            #region
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
            #endregion

            // 1行目
            #region
            BaseLabel lblHYMD = new BaseLabel();
            lblHYMD.AutoSize = true;
            lblHYMD.BackColor = Color.Transparent;
            lblHYMD.Text = "発注年月日";
            basePanel.Controls.Add(lblHYMD);
            lblHYMD.Location = new Point(4, 25);
            lblHYMD.BringToFront();

            BaseCalendar txtHYMD = new BaseCalendar();
            txtHYMD.Size = new System.Drawing.Size(85, 22);
            txtHYMD.TextAlign = HorizontalAlignment.Right;
            basePanel.Controls.Add(txtHYMD);
            txtHYMD.Location = new Point(97, 22);
            txtHYMD.BringToFront();
            //txtHYMD.Name = "txtHYMD" + idx.ToString(zeroPad);
            txtHYMD.Name = "txtHYMD";
            txtHYMD.TabIndex = tabIdx;
            tabIdx++;

            ctl = txtHYMD;

            LabelSet_Tantousha lsHSha = new LabelSet_Tantousha();
            lsHSha.Name = "lsHSha";
            lsHSha.AutoSize = true;
            lsHSha.LabelName = "発注者";
            basePanel.Controls.Add(lsHSha);
            lsHSha.Location = new Point(266, 22);
            lsHSha.BringToFront();
            lsHSha.TabIndex = tabIdx;
            tabIdx++;

            #region
            //Label lblHSha = new Label();
            //lblHSha.AutoSize = true;
            //lblHSha.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ////lblHSha.BackColor = Color.Transparent;
            //lblHSha.Text = "発注者";
            //basePanel.Controls.Add(lblHSha);
            //lblHSha.Location = new Point(266, 22);
            //lblHSha.BringToFront();

            //BaseText txtHSha = new BaseText();
            //txtHSha.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtHSha.Size = new System.Drawing.Size(38, 22);
            //basePanel.Controls.Add(txtHSha);
            //txtHSha.Location = new Point(327, 19);
            //txtHSha.BringToFront();
            //txtHSha.Name = "txtHSha" + idx.ToString(zeroPad);
            //txtHSha.TabIndex = tabIdx;
            //tabIdx++;

            //BaseText txtLHSha = new BaseText();
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
            lsShiire.LabelName = "仕入先";
            basePanel.Controls.Add(lsShiire);
            lsShiire.Location = new Point(496, 22);
            lsShiire.BringToFront();
            lsShiire.TabIndex = tabIdx;
            tabIdx++;

            #region
            //Label lblShiire = new Label();
            //lblShiire.AutoSize = true;
            //lblShiire.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ////lblShiire.BackColor = Color.Transparent;
            //lblShiire.Text = "仕入先";
            //basePanel.Controls.Add(lblShiire);
            //lblShiire.Location = new Point(496, 22);
            //lblShiire.BringToFront();

            //BaseText txtShiireCd = new BaseText();
            //txtShiireCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtShiireCd.Size = new System.Drawing.Size(38, 22);
            //basePanel.Controls.Add(txtShiireCd);
            //txtShiireCd.Location = new Point(573, 19);
            //txtShiireCd.BringToFront();
            //txtShiireCd.Name = "txtShiireCd" + idx.ToString(zeroPad);
            //txtShiireCd.TabIndex = tabIdx;
            //tabIdx++;

            //BaseText txtShiireMei = new BaseText();
            //txtShiireMei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtShiireMei.Size = new System.Drawing.Size(218, 22);
            //basePanel.Controls.Add(txtShiireMei);
            //txtShiireMei.Location = new Point(617, 19);
            //txtShiireMei.BringToFront();
            //txtShiireMei.Name = "txtShiireMei" + idx.ToString(zeroPad);
            //txtShiireMei.TabIndex = tabIdx;
            //tabIdx++;
            #endregion

            BaseLabel lblHNo = new BaseLabel();
            lblHNo.AutoSize = true;
            //lblHNo.BackColor = Color.Transparent;
            lblHNo.Text = "発注番号";
            basePanel.Controls.Add(lblHNo);
            lblHNo.Location = new Point(841, 22);
            lblHNo.BringToFront();
            lblHNo.TabIndex = tabIdx;
            tabIdx++;

            BaseTextMoney txtHNo = new BaseTextMoney();
            txtHNo.Name = "txtHNo";
            txtHNo.Size = new System.Drawing.Size(70, 22);
            basePanel.Controls.Add(txtHNo);
            txtHNo.Location = new Point(934, 19);
            txtHNo.BringToFront();
            txtHNo.Name = "txtHNo";
            txtHNo.Leave += new EventHandler(txtHNo_Leave);
            txtHNo.TabIndex = tabIdx;
            tabIdx++;
            #endregion

            // 2行目
            #region
            LabelSet_Daibunrui lsDaibun = new LabelSet_Daibunrui();
            lsDaibun.Name = "lsDaibun";
            lsDaibun.AutoSize = true;
            //lsDaibun.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lsDaibun.LabelName = "大分類";
            basePanel.Controls.Add(lsDaibun);
            lsDaibun.Location = new Point(36, 49);
            lsDaibun.BringToFront();
            lsDaibun.TabIndex = tabIdx;
            tabIdx++;

            #region
            //Label lblDaibunruiCd = new Label();
            //lblDaibunruiCd.AutoSize = true;
            //lblDaibunruiCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ////lblDaibunruiCd.BackColor = Color.Transparent;
            //lblDaibunruiCd.Text = "大分類";
            //basePanel.Controls.Add(lblDaibunruiCd);
            //lblDaibunruiCd.Location = new Point(36, 52);
            //lblDaibunruiCd.BringToFront();

            //BaseText txtDaibunruiCd = new BaseText();
            //txtDaibunruiCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtDaibunruiCd.Size = new System.Drawing.Size(30, 22);
            //basePanel.Controls.Add(txtDaibunruiCd);
            //txtDaibunruiCd.Location = new Point(97, 49);
            //txtDaibunruiCd.TextAlign = HorizontalAlignment.Right;
            //txtDaibunruiCd.BringToFront();
            //txtDaibunruiCd.Name = "txtDaibunruiCd" + idx.ToString(zeroPad);
            //txtDaibunruiCd.TabIndex = tabIdx;
            //tabIdx++;

            //BaseText txtDaibunruiName = new BaseText();
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
            //lsChubun.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lsChubun.LabelName = "中分類";
            basePanel.Controls.Add(lsChubun);
            lsChubun.Location = new Point(266, 49);
            lsChubun.BringToFront();
            lsChubun.TabIndex = tabIdx;
            tabIdx++;

            #region
            //Label lblChubunruiCd = new Label();
            //lblChubunruiCd.AutoSize = true;
            //lblChubunruiCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ////lblChubunruiCd.BackColor = Color.Transparent;
            //lblChubunruiCd.Text = "中分類";
            //basePanel.Controls.Add(lblChubunruiCd);
            //lblChubunruiCd.Location = new Point(266, 52);
            //lblChubunruiCd.BringToFront();

            //BaseText txtChubunruiCd = new BaseText();
            //txtChubunruiCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtChubunruiCd.Size = new System.Drawing.Size(30, 22);
            //txtChubunruiCd.TextAlign = HorizontalAlignment.Right;
            //basePanel.Controls.Add(txtChubunruiCd);
            //txtChubunruiCd.Location = new Point(327, 49);
            //txtChubunruiCd.BringToFront();
            //txtChubunruiCd.Name = "txtChubunruiCd" + idx.ToString(zeroPad);
            //txtChubunruiCd.TabIndex = tabIdx;
            //tabIdx++;

            //BaseText txtChubunruiName = new BaseText();
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
            //lsMaker.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lsMaker.LabelName = "メーカー";
            basePanel.Controls.Add(lsMaker);
            lsMaker.Location = new Point(496, 49);
            lsMaker.BringToFront();
            lsMaker.TabIndex = tabIdx;
            tabIdx++;

            #region
            //Label lblMakerCd = new Label();
            //lblMakerCd.AutoSize = true;
            //lblMakerCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ////lblMakerCd.BackColor = Color.Transparent;
            //lblMakerCd.Text = "メーカー";
            //basePanel.Controls.Add(lblMakerCd);
            //lblMakerCd.Location = new Point(496, 52);
            //lblMakerCd.BringToFront();

            //BaseText txtMakerCd = new BaseText();
            //txtMakerCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtMakerCd.Size = new System.Drawing.Size(30, 22);
            //basePanel.Controls.Add(txtMakerCd);
            //txtMakerCd.Location = new Point(573, 49);
            //txtMakerCd.TextAlign = HorizontalAlignment.Right;
            //txtMakerCd.BringToFront();
            //txtMakerCd.Name = "txtMakerCd" + idx.ToString(zeroPad);
            //txtMakerCd.TabIndex = tabIdx;
            //tabIdx++;

            //BaseText txtMakerName = new BaseText();
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

            BaseLabel lblSearchStr = new BaseLabel();
            lblSearchStr.AutoSize = true;
            //lblSearchStr.BackColor = Color.Transparent;
            lblSearchStr.Text = "検索文字列";
            basePanel.Controls.Add(lblSearchStr);
            lblSearchStr.Location = new Point(841, 52);
            lblSearchStr.BringToFront();

            BaseText txtSearchStr = new BaseText();
            txtSearchStr.Name = "txtSearchStr";
            txtSearchStr.Size = new System.Drawing.Size(271, 22);
            basePanel.Controls.Add(txtSearchStr);
            txtSearchStr.Location = new Point(934, 49);
            txtSearchStr.BringToFront();
            txtSearchStr.Name = "txtSearchStr";
            txtSearchStr.TabIndex = tabIdx;
            tabIdx++;
            txtSearchStr.Leave += new EventHandler(txtSearchStr_Leave);
            #endregion

            // 3行目
            #region
            BaseLabel lblHinmei = new BaseLabel();
            lblHinmei.AutoSize = true;
            //lblHinmei.BackColor = Color.Transparent;
            lblHinmei.Text = "品名";
            basePanel.Controls.Add(lblHinmei);
            lblHinmei.Location = new Point(52, 80);
            lblHinmei.BringToFront();

            #region
            //BaseText txtHinmeiM = new BaseText();
            //txtHinmeiM.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtHinmeiM.Size = new System.Drawing.Size(109, 22);
            //basePanel.Controls.Add(txtHinmeiM);
            //txtHinmeiM.Location = new Point(97, 77);
            //txtHinmeiM.BringToFront();
            //txtHinmeiM.Name = "txtHinmeiM" + idx.ToString(zeroPad);
            //txtHinmeiM.TabIndex = tabIdx;
            //tabIdx++;

            //BaseText txtHinmeiC = new BaseText();
            //txtHinmeiC.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //txtHinmeiC.Size = new System.Drawing.Size(109, 22);
            //basePanel.Controls.Add(txtHinmeiC);
            //txtHinmeiC.Location = new Point(212, 77);
            //txtHinmeiC.BringToFront();
            //txtHinmeiC.Name = "txtHinmeiC" + idx.ToString(zeroPad);
            //txtHinmeiC.TabIndex = tabIdx;
            //tabIdx++;
            #endregion

            BaseText txtHinmei = new BaseText();
            txtHinmei.Name = "txtHinmei";
            txtHinmei.Size = new System.Drawing.Size(331, 22);
            basePanel.Controls.Add(txtHinmei);
            //txtHinmei.Location = new Point(327, 77);
            txtHinmei.Location = new Point(97, 77);
            txtHinmei.BringToFront();
            txtHinmei.Name = "txtHinmei";
            txtHinmei.TabIndex = tabIdx;
            tabIdx++;

            BaseText txtHinmeiY = new BaseText();
            txtHinmeiY.Name = "txtHinmeiY";
            txtHinmeiY.Size = new System.Drawing.Size(169, 22);
            basePanel.Controls.Add(txtHinmeiY);
            //txtHinmeiY.Location = new Point(664, 77);
            txtHinmeiY.Location = new Point(434, 77);
            txtHinmeiY.BringToFront();
            txtHinmeiY.Name = "txtHinmeiY";
            txtHinmeiY.TabIndex = tabIdx;
            tabIdx++;

            BaseLabel lblTanaban = new BaseLabel();
            lblTanaban.AutoSize = true;
            //lblTanaban.BackColor = Color.Transparent;
            lblTanaban.Text = "棚番";
            basePanel.Controls.Add(lblTanaban);
            //lblTanaban.Location = new Point(841, 80);
            lblTanaban.Location = new Point(617, 80);
            lblTanaban.BringToFront();

            BaseLabelGray txtTanabanL = new BaseLabelGray();
            txtTanabanL.Name = "txtTanabanL";
            //txtTanabanL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //txtTanabanL.BackColor = System.Drawing.SystemColors.ScrollBar;
            //txtTanabanL.ForeColor = System.Drawing.Color.Navy;
            //txtTanabanL.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            txtTanabanL.Size = new System.Drawing.Size(59, 21);
            //txtTanabanL.ReadOnly = true;
            basePanel.Controls.Add(txtTanabanL);
            //txtTanabanL.Location = new Point(934, 80);
            txtTanabanL.Location = new Point(661, 77);
            txtTanabanL.BringToFront();
            txtTanabanL.Name = "txtTanabanL";
            txtTanabanL.TabStop = false;

            BaseLabelGray txtTanabanR = new BaseLabelGray();
            txtTanabanR.Name = "txtTanabanR";
            //txtTanabanR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //txtTanabanR.BackColor = System.Drawing.SystemColors.ScrollBar;
            //txtTanabanR.ForeColor = System.Drawing.Color.Navy;
            //txtTanabanR.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            txtTanabanR.Size = new System.Drawing.Size(59, 21);
            //txtTanabanR.ReadOnly = true;
            basePanel.Controls.Add(txtTanabanR);
            //txtTanabanR.Location = new Point(982, 80);
            txtTanabanR.Location = new Point(723, 77);
            txtTanabanR.BringToFront();
            txtTanabanR.Name = "txtTanabanR";
            txtTanabanR.TabStop = false;
            #endregion

            // 4行目
            #region
            BaseLabel lblSuryo = new BaseLabel();
            lblSuryo.AutoSize = true;
            //lblSuryo.BackColor = Color.Transparent;
            lblSuryo.Text = "数量";
            basePanel.Controls.Add(lblSuryo);
            lblSuryo.Location = new Point(52, 108);
            lblSuryo.BringToFront();

            BaseTextMoney txtSuryo = new BaseTextMoney();
            txtSuryo.Name = "txtSuryo";
            txtSuryo.Size = new System.Drawing.Size(77, 22);
            txtSuryo.TextAlign = HorizontalAlignment.Right;
            basePanel.Controls.Add(txtSuryo);
            txtSuryo.Location = new Point(97, 105);
            txtSuryo.BringToFront();
            txtSuryo.Name = "txtSuryo";
            txtSuryo.TabIndex = tabIdx;
            tabIdx++;

            BaseLabel lblTanka = new BaseLabel();
            lblTanka.AutoSize = true;
            //lblTanka.BackColor = Color.Transparent;
            lblTanka.Text = "単価";
            basePanel.Controls.Add(lblTanka);
            lblTanka.Location = new Point(199, 108);
            lblTanka.BringToFront();

            BaseTextMoney txtTanka = new BaseTextMoney();
            txtTanka.Name = "txtTanka";
            txtTanka.Size = new System.Drawing.Size(77, 22);
            txtTanka.TextAlign = HorizontalAlignment.Right;
            basePanel.Controls.Add(txtTanka);
            txtTanka.Location = new Point(244, 105);
            txtTanka.BringToFront();
            txtTanka.Name = "txtTanka";
            txtTanka.TabIndex = tabIdx;
            tabIdx++;

            BaseLabel lblNohki = new BaseLabel();
            lblNohki.AutoSize = true;
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

            BaseCalendar txtNohki = new BaseCalendar();
            txtNohki.Name = "txtNohki";
            txtNohki.Size = new System.Drawing.Size(85, 22);
            txtNohki.TextAlign = HorizontalAlignment.Right;
            basePanel.Controls.Add(txtNohki);
            txtNohki.Location = new Point(393, 105);
            txtNohki.BringToFront();
            txtNohki.Name = "txtNohki";
            txtNohki.Leave += new EventHandler(txtNohki_Leave);
            txtNohki.TabIndex = tabIdx;
            tabIdx++;

            BaseLabel lblChuban = new BaseLabel();
            lblChuban.AutoSize = true;
            //lblChuban.BackColor = Color.Transparent;
            lblChuban.Text = "注番";
            basePanel.Controls.Add(lblChuban);
            lblChuban.Location = new Point(505, 108);
            lblChuban.BringToFront();

            BaseText txtChuban = new BaseText();
            txtChuban.Name = "txtChuban";
            txtChuban.Size = new System.Drawing.Size(197, 22);
            basePanel.Controls.Add(txtChuban);
            txtChuban.Location = new Point(550, 105);
            txtChuban.BringToFront();
            txtChuban.Name = "txtChuban";
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
                btnAddShukko.Name = "btnAddShukko";
                btnAddShukko.TabIndex = tabIdx;
                tabIdx++;
                btnAddShukko.Enabled = button14.Enabled;
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
                    btnAddShukko.Name = "btnAddKakoShukko";
                    btnAddShukko.TabIndex = tabIdx;
                    tabIdx++;
                    btnAddShukko.Enabled = button15.Enabled;
                }
                else
                {
                    if (!a0010JInput.txtHinmei.Text.Equals(this.txtHinmei.Text))
                    {
                        Button btnAddShukko = new Button();
                        btnAddShukko.Text = "加工品出庫";
                        btnAddShukko.Tag = cat;
                        basePanel.Controls.Add(btnAddShukko);
                        btnAddShukko.Click += new EventHandler(btnAddKakoShukko_Click);
                        btnAddShukko.Location = new Point(1206, 105);
                        btnAddShukko.BringToFront();
                        btnAddShukko.Name = "btnAddKakoShukko";
                        btnAddShukko.TabIndex = tabIdx;
                        tabIdx++;
                        btnAddShukko.Enabled = button15.Enabled;
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
            btnDelRow.Name = "btnDel";
            btnDelRow.TabIndex = tabIdx;
            tabIdx++;
            btnDelRow.Enabled = button13.Enabled;

            if (this.checkBox1.Checked == true)
            {
                txtHYMD.Text = txtJuchuYMD.Text;
                lsHSha.CodeTxtText = a0010JInput.lsJuchusha.CodeTxtText;
                lsHSha.ValueLabelText = a0010JInput.lsJuchusha.ValueLabelText;
                lsShiire.CodeTxtText = a0010JInput.tsShiiresaki.CodeTxtText;
                lsShiire.ValueLabelText = a0010JInput.tsShiiresaki.valueTextText;
                lsDaibun.CodeTxtText = lsDaibunruiM.CodeTxtText;
                lsDaibun.ValueLabelText = lsDaibunruiM.ValueLabelText;
                lsChubun.CodeTxtText = lsChubunruiM.CodeTxtText;
                lsChubun.ValueLabelText = lsChubunruiM.ValueLabelText;
                lsMaker.CodeTxtText = lsMakerM.CodeTxtText;
                lsMaker.ValueLabelText = lsMakerM.ValueLabelText;
                txtHinmei.Text = this.txtHinmei.Text;
            }
            #endregion

            // 隠し
            #region
 
            #region
            BaseCalendar tmpHYMD = new BaseCalendar();
            tmpHYMD.Name = "tmpHYMD";
            basePanel.Controls.Add(tmpHYMD);
            tmpHYMD.SendToBack();
            tmpHYMD.Visible = false;
            BaseText tmpHSha = new BaseText();
            tmpHSha.Name = "tmpHSha";
            basePanel.Controls.Add(tmpHSha);
            tmpHSha.SendToBack();
            tmpHSha.Visible = false;
            BaseText tmpShiire = new BaseText();
            tmpShiire.Name = "tmpShiire";
            basePanel.Controls.Add(tmpShiire);
            tmpShiire.SendToBack();
            tmpShiire.Visible = false;
            BaseTextMoney tmpHNo = new BaseTextMoney();
            tmpHNo.Name = "tmpHNo";
            basePanel.Controls.Add(tmpHNo);
            tmpHNo.SendToBack();
            tmpHNo.Visible = false;
            BaseText tmpDaibun = new BaseText();
            tmpDaibun.Name = "tmpDaibun";
            basePanel.Controls.Add(tmpDaibun);
            tmpDaibun.SendToBack();
            tmpDaibun.Visible = false;
            BaseText tmpChubun = new BaseText();
            tmpChubun.Name = "tmpChubun";
            basePanel.Controls.Add(tmpChubun);
            tmpChubun.SendToBack();
            tmpChubun.Visible = false;
            BaseText tmpMaker = new BaseText();
            tmpMaker.Name = "tmpMaker";
            basePanel.Controls.Add(tmpMaker);
            tmpMaker.SendToBack();
            tmpMaker.Visible = false;
            BaseText tmpHinmei = new BaseText();
            tmpHinmei.Name = "tmpHinmei";
            basePanel.Controls.Add(tmpHinmei);
            tmpHinmei.SendToBack();
            tmpHinmei.Visible = false;
            BaseTextMoney tmpSuryo = new BaseTextMoney();
            tmpSuryo.Name = "tmpSuryo";
            basePanel.Controls.Add(tmpSuryo);
            tmpSuryo.SendToBack();
            tmpSuryo.Visible = false;
            BaseTextMoney tmpTanka = new BaseTextMoney();
            tmpTanka.Name = "tmpTanka";
            basePanel.Controls.Add(tmpTanka);
            tmpTanka.SendToBack();
            tmpTanka.Visible = false;
            BaseCalendar tmpNohki = new BaseCalendar();
            tmpNohki.Name = "tmpNohki";
            basePanel.Controls.Add(tmpNohki);
            tmpNohki.SendToBack();
            tmpNohki.Visible = false;
            BaseText tmpChuban = new BaseText();
            tmpChuban.Name = "tmpChuban";
            basePanel.Controls.Add(tmpChuban);
            tmpChuban.SendToBack();
            tmpChuban.Visible = false;
            #endregion

            BaseText txtC1 = new BaseText();
            txtC1.Name = "txtC1";
            basePanel.Controls.Add(txtC1);
            txtC1.SendToBack();
            txtC1.Visible = false;

            BaseText txtC2 = new BaseText();
            txtC2.Name = "txtC2";
            basePanel.Controls.Add(txtC2);
            txtC2.SendToBack();
            txtC2.Visible = false;

            BaseText txtC3 = new BaseText();
            txtC3.Name = "txtC3";
            basePanel.Controls.Add(txtC3);
            txtC3.SendToBack();
            txtC3.Visible = false;

            BaseText txtC4 = new BaseText();
            txtC4.Name = "txtC4";
            basePanel.Controls.Add(txtC4);
            txtC4.SendToBack();
            txtC4.Visible = false;

            BaseText txtC5 = new BaseText();
            txtC5.Name = "txtC5";
            basePanel.Controls.Add(txtC5);
            txtC5.SendToBack();
            txtC5.Visible = false;

            BaseText txtC6 = new BaseText();
            txtC6.Name = "txtC6";
            basePanel.Controls.Add(txtC6);
            txtC6.SendToBack();
            txtC6.Visible = false;

            BaseText txtEigyo = new BaseText();
            txtEigyo.Name = "txtEigyo";
            basePanel.Controls.Add(txtEigyo);
            txtEigyo.TextChanged += new EventHandler(txtEigyo_TextChanged);
            txtEigyo.SendToBack();
            txtEigyo.Visible = false;

            BaseText txtTanto = new BaseText();
            txtTanto.Name = "txtTanto";
            basePanel.Controls.Add(txtTanto);
            txtTanto.SendToBack();
            txtTanto.Visible = false;

            BaseText txtShohin = new BaseText();
            txtShohin.Name = "txtShohin";
            basePanel.Controls.Add(txtShohin);
            txtShohin.SendToBack();
            txtShohin.Visible = false;
            txtShohin.TextChanged += new EventHandler(shohinChangeSub);

            BaseText txtSouko = new BaseText();
            txtSouko.Name = "txtSouko";
            basePanel.Controls.Add(txtSouko);
            txtSouko.SendToBack();
            txtSouko.Visible = false;

            BaseText txtShiireSu = new BaseText();
            txtShiireSu.Name = "txtShiireSu";
            basePanel.Controls.Add(txtShiireSu);
            txtShiireSu.SendToBack();
            txtShiireSu.Visible = false;

            BaseText txtShiireBi = new BaseText();
            txtShiireBi.Name = "txtShiireBi";
            basePanel.Controls.Add(txtShiireBi);
            txtShiireBi.SendToBack();
            txtShiireBi.Visible = false;

            BaseText txtRitsu = new BaseText();
            txtRitsu.Name = "txtRitsu";
            basePanel.Controls.Add(txtRitsu);
            txtRitsu.SendToBack();
            txtRitsu.Visible = false;

            BaseText txtKataban = new BaseText();
            txtKataban.Name = "txtKataban";
            basePanel.Controls.Add(txtKataban);
            txtKataban.SendToBack();
            txtKataban.Visible = false;

            BaseText oldStr = new BaseText();
            oldStr.Name = "oldStr";
            basePanel.Controls.Add(oldStr);
            oldStr.SendToBack();
            oldStr.Visible = false;

            #endregion

            return basePanel;
        }

        private void shohinChange(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShohinCd.Text))
            {
                return;
            }

            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
            try
            {
                DataTable dt = juchuB.getShohin(txtShohinCd.Text);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    lsDaibunruiM.CodeTxtText = dt.Rows[0]["大分類コード"].ToString();
                    lsChubunruiM.CodeTxtText = dt.Rows[0]["中分類コード"].ToString();
                    lsMakerM.CodeTxtText = dt.Rows[0]["メーカーコード"].ToString();
                    strC1 = dt.Rows[0]["Ｃ１"].ToString();
                    strC2 = dt.Rows[0]["Ｃ２"].ToString();
                    strC3 = dt.Rows[0]["Ｃ３"].ToString();
                    strC4 = dt.Rows[0]["Ｃ４"].ToString();
                    strC5 = dt.Rows[0]["Ｃ５"].ToString();
                    strC6 = dt.Rows[0]["Ｃ６"].ToString();

                    txtHinmei.Text = strC1 + " " + strC2 + " " + strC3 + " " + strC4 + " " + strC5 + " " + strC6;

                    if (!string.IsNullOrWhiteSpace(strTokuiCd))
                    {
                        strJuchuTanka = juchuB.getUriageTanka(strTokuiCd, txtShohinCd.Text);
                        strShiireTanka = dt.Rows[0]["仕入単価"].ToString();
                    }

                    strTeika = dt.Rows[0]["定価"].ToString();
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

        private void shohinChangeSub(object sender, EventArgs e)
        {
            string stShoCd = ((BaseText)sender).Text;
            if (string.IsNullOrWhiteSpace(strJuchuNo) || string.IsNullOrWhiteSpace(stShoCd))
            {
                return;
            }

            Panel cc = (Panel)((BaseText)sender).Parent;

            string sLbl = ((Label)cc.Controls["cate"]).Text;

            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
            try
            {

                DataTable dt = juchuB.getShohin(stShoCd);

                if (dt != null && dt.Rows.Count > 0)
                {
                    ((LabelSet_Daibunrui)cc.Controls["lsDaibun"]).CodeTxtText = dt.Rows[0]["大分類コード"].ToString();
                    ((LabelSet_Chubunrui)cc.Controls["lsChubun"]).CodeTxtText = dt.Rows[0]["中分類コード"].ToString();
                    ((LabelSet_Maker)cc.Controls["lsMaker"]).CodeTxtText = dt.Rows[0]["メーカーコード"].ToString();
                    ((BaseText)cc.Controls["txtC1"]).Text = dt.Rows[0]["Ｃ１"].ToString();
                    ((BaseText)cc.Controls["txtC2"]).Text = dt.Rows[0]["Ｃ２"].ToString();
                    ((BaseText)cc.Controls["txtC3"]).Text = dt.Rows[0]["Ｃ３"].ToString();
                    ((BaseText)cc.Controls["txtC4"]).Text = dt.Rows[0]["Ｃ４"].ToString();
                    ((BaseText)cc.Controls["txtC5"]).Text = dt.Rows[0]["Ｃ５"].ToString();
                    ((BaseText)cc.Controls["txtC6"]).Text = dt.Rows[0]["Ｃ６"].ToString();

                    ((BaseText)cc.Controls["txtKataban"]).Text =
                        ((BaseText)cc.Controls["txtC1"]).Text + " " +
                        ((BaseText)cc.Controls["txtC2"]).Text + " " +
                        ((BaseText)cc.Controls["txtC3"]).Text + " " +
                        ((BaseText)cc.Controls["txtC4"]).Text + " " +
                        ((BaseText)cc.Controls["txtC5"]).Text + " " +
                        ((BaseText)cc.Controls["txtC6"]).Text;

                    ((BaseText)cc.Controls["txtHinmei"]).Text =
                        ((LabelSet_Maker)cc.Controls["lsMaker"]).ValueLabelText + " " +
                        ((LabelSet_Chubunrui)cc.Controls["lsChubun"]).ValueLabelText + " " +
                        ((BaseText)cc.Controls["txtC1"]).Text + " " +
                        ((BaseText)cc.Controls["txtC2"]).Text + " " +
                        ((BaseText)cc.Controls["txtC3"]).Text + " " +
                        ((BaseText)cc.Controls["txtC4"]).Text + " " +
                        ((BaseText)cc.Controls["txtC5"]).Text + " " +
                        ((BaseText)cc.Controls["txtC6"]).Text;

                    if (sLbl.Equals(labels[1]))
                    {
                        DataTable dtS = juchuB.getShukkoTanka(strJuchuNo, stShoCd);

                        if (dtS != null && dtS.Rows.Count > 0)
                        {
                            ((BaseTextMoney)cc.Controls["txtTanka"]).Text = dt.Rows[0]["仕入単価"].ToString();
                        }
                        else
                        {
                            DataTable dtT = juchuB.getKinShiireTanka(stShoCd);
                            if (dtT != null && dtT.Rows.Count > 0)
                            {
                                ((BaseTextMoney)cc.Controls["txtTanka"]).Text = dtT.Rows[0]["仕入単価"].ToString();
                            }
                        }
                    }
                    else
                    {
                        ((BaseTextMoney)cc.Controls["txtTanka"]).Text = dt.Rows[0]["仕入単価"].ToString();
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

        private void Form6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //addKakoJuchu();
            }
            else if (e.KeyCode == Keys.F3)
            {
                //delKakoJuchu();
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
                a0010JInput.f6 = null;
                this.Close();
                // this.Dispose();
            }
        }

        // 加工品受注個別削除
        private void delKakoJuchuS(Panel c, bool f)
        {
            strHachuNo = ((BaseTextMoney)c.Controls["txtHNo"]).Text;

            if (string.IsNullOrWhiteSpace(strHachuNo))
            {
                return;
            }

            string cate = ((Label)c.Controls["cate"]).Text;
            bool hatchuFlg = false;
            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();

            try
            {
                if (cate.Equals(labels[0]) || cate.Equals(labels[2]))
                {
                    hatchuFlg = true;
                    decimal decSuryo = juchuB.getShiirezumisuryoH(strHachuNo);
                    if (decSuryo > 0)
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに仕入済みです。削除できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        return;
                    }
                }

                string strFlg = juchuB.getZaikoHikiateFlg(strJuchuNo);
                if (strFlg.Equals("1"))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "在庫が既に移動処理されています。変更・削除は禁止です", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                strFlg = juchuB.getShukkoFlg(strJuchuNo);
                if (strFlg.Equals("1"))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "在庫が既に移動処理されています。変更・削除は禁止です", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }
                if (f == true)
                {
                    BaseMessageBox basemessageboxSa = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                    //NOが押された場合
                    if (basemessageboxSa.ShowDialog() == DialogResult.No)
                    {
                        return;
                    }
                }
                juchuB.delHachuS(strHachuNo, Environment.UserName, hatchuFlg);

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        // 加工品登録
        private void updKakoInput()
        {
            if (!chkData())
            {
                return;
            }
            string strShoCd = "88888";
            decimal JucyuKin = 0;

            if (!string.IsNullOrWhiteSpace(strShohin))
            {
                strShoCd = strShohin;
            }

            DBConnective con = new DBConnective();
            BaseMessageBox basemessagebox;
            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();

            try
            {
                con.DB_Connect();
                con.BeginTrans();

                TableLayoutControlCollection c = tableLayoutPanel1.Controls;
                foreach (Control cc in c)
                {
                    if (changeVal((Panel)cc))
                    {
                        continue;
                    }
                    string sLbl = ((Label)cc.Controls["cate"]).Text;
                    string sHSha = ((LabelSet_Tantousha)cc.Controls["lsHSha"]).CodeTxtText;
                    string sHYMD = ((BaseCalendar)cc.Controls["txtHYMD"]).Text;
                    string sHShiire = ((LabelSet_Shiresaki)cc.Controls["lsShiire"]).CodeTxtText;
                    string sHNo = ((BaseTextMoney)cc.Controls["txtHNo"]).Text;
                    string sHDai = ((LabelSet_Daibunrui)cc.Controls["lsDaibun"]).CodeTxtText;
                    string sHChubun = ((LabelSet_Chubunrui)cc.Controls["lsChubun"]).CodeTxtText;
                    string sHMak = ((LabelSet_Maker)cc.Controls["lsMaker"]).CodeTxtText;
                    string sHHin = ((BaseText)cc.Controls["txtHinmei"]).Text;
                    string sHTanaL = ((BaseLabelGray)cc.Controls["txtTanabanL"]).Text;
                    string sHTanaR = ((BaseLabelGray)cc.Controls["txtTanabanR"]).Text;
                    string sHSu = ((BaseTextMoney)cc.Controls["txtSuryo"]).Text;
                    string sHTanka = ((BaseTextMoney)cc.Controls["txtTanka"]).Text;
                    string sHNoki = ((BaseCalendar)cc.Controls["txtNohki"]).Text;
                    string sHChuban = ((BaseText)cc.Controls["txtChuban"]).Text;
                    string sShohin = ((BaseText)cc.Controls["txtShohin"]).Text;
                    string sShiireSu = ((BaseText)cc.Controls["txtShiireSu"]).Text;
                    string sShiireBi = ((BaseText)cc.Controls["txtShiireBi"]).Text;
                    string sSouko = ((BaseText)cc.Controls["txtSouko"]).Text;
                    string sTmpSu = ((BaseText)cc.Controls["tmpSuryo"]).Text;
                    string sShiireMei = ((LabelSet_Shiresaki)cc.Controls["lsShiire"]).ValueLabelText;
                    string sEigyo = ((BaseText)cc.Controls["txtEigyo"]).Text;
                    string sC1 = ((BaseText)cc.Controls["txtC1"]).Text;
                    string sC2 = ((BaseText)cc.Controls["txtC2"]).Text;
                    string sC3 = ((BaseText)cc.Controls["txtC3"]).Text;
                    string sC4 = ((BaseText)cc.Controls["txtC4"]).Text;
                    string sC5 = ((BaseText)cc.Controls["txtC5"]).Text;
                    string sC6 = ((BaseText)cc.Controls["txtC6"]).Text;
                    string sKataban = ((BaseText)cc.Controls["txtKataban"]).Text;

                    string shoCd = "88888";

                    if (sLbl.Equals(labels[0]) || sLbl.Equals(labels[2]))
                    {
                        if (!string.IsNullOrWhiteSpace(sShohin))
                        {
                            shoCd = sShohin;
                        }
                        string juchuNo = "0";
                        if (!string.IsNullOrWhiteSpace(strJuchuNo))
                        {
                            juchuNo = strJuchuNo;
                        }
                        JucyuKin = 0;
                        if (!string.IsNullOrWhiteSpace(sHTanka) && !string.IsNullOrWhiteSpace(sHSu))
                        {
                            JucyuKin = decimal.Parse(sHTanka) * decimal.Parse(sHSu);
                        }
                        string kakoKbn = "1";
                        if (sLbl.Equals(labels[0]))
                        {
                            kakoKbn = "0";
                        }

                        List<String> aryPrmH = new List<string>();

                        aryPrmH.Add(sHShiire);
                        aryPrmH.Add(sHYMD);
                        aryPrmH.Add(sHNo);
                        aryPrmH.Add(sHSha);
                        aryPrmH.Add(sEigyo);
                        aryPrmH.Add(sHSha);
                        aryPrmH.Add(strJuchuNo);
                        aryPrmH.Add("0");
                        aryPrmH.Add("0");
                        aryPrmH.Add(strShohin);
                        aryPrmH.Add(sHMak);
                        aryPrmH.Add(sHChubun);
                        aryPrmH.Add(sHDai);
                        aryPrmH.Add(sC1);
                        aryPrmH.Add(sC2);
                        aryPrmH.Add(sC3);
                        aryPrmH.Add(sC4);
                        aryPrmH.Add(sC5);
                        aryPrmH.Add(sC6);
                        aryPrmH.Add(sHSu);
                        aryPrmH.Add(sHTanka);
                        aryPrmH.Add(JucyuKin.ToString());
                        aryPrmH.Add(sHNoki);
                        aryPrmH.Add("0");
                        aryPrmH.Add(sHChuban);
                        aryPrmH.Add(kakoKbn);
                        aryPrmH.Add(sShiireMei);
                        aryPrmH.Add(Environment.UserName);

                        juchuB.updJuchuH(aryPrmH, con);

                    }
                    else
                    {
                        string kbn = "41";
                        if (sLbl.Equals(labels[3]))
                        {
                            kbn = "43";
                        }

                        string strHachuNo = null;
                        if (string.IsNullOrWhiteSpace(sHNo))
                        {
                            strHachuNo = juchuB.getDenpyoNo("出庫伝票", con);
                        }
                        else
                        {
                            strHachuNo = sHNo;
                        }

                        List<String> aryPrmSH = new List<string>();

                        aryPrmSH.Add(strHachuNo);
                        aryPrmSH.Add(sHYMD);
                        aryPrmSH.Add(sHShiire);
                        aryPrmSH.Add(kbn);
                        aryPrmSH.Add(sHSha);
                        aryPrmSH.Add(sEigyo);
                        aryPrmSH.Add(Environment.UserName);
                        aryPrmSH.Add(sShiireMei);

                        juchuB.updShukkoHead(aryPrmSH, con);
                        string shohinCd;

                        if (string.IsNullOrWhiteSpace(sShohin) || sShohin.Equals("88888"))
                        {
                            DataTable dt = juchuB.getShohinForUpd(sHDai, sHChubun, sHMak, sKataban);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                shohinCd = dt.Rows[0]["商品コード"].ToString();
                            }
                            else
                            {
                                A0030_ShireInput_B si = new A0030_ShireInput_B();
                                shohinCd = si.getNewShohinNo();

                                List<String> aryPrmShohin = new List<string>();
                                aryPrmShohin.Add(shohinCd);
                                aryPrmShohin.Add(sHMak);
                                aryPrmShohin.Add(sHDai);
                                aryPrmShohin.Add(sHChubun);
                                aryPrmShohin.Add(sKataban);
                                aryPrmShohin.Add(null);
                                aryPrmShohin.Add(null);
                                aryPrmShohin.Add(null);
                                aryPrmShohin.Add(null);
                                aryPrmShohin.Add(null);
                                aryPrmShohin.Add("Y");
                                aryPrmShohin.Add("0");
                                aryPrmShohin.Add(sHTanka);
                                aryPrmShohin.Add("0");
                                aryPrmShohin.Add("000000");
                                aryPrmShohin.Add("000000");
                                aryPrmShohin.Add(null);
                                aryPrmShohin.Add(sHTanka);
                                aryPrmShohin.Add("0");
                                aryPrmShohin.Add("1");
                                aryPrmShohin.Add(Environment.UserName);

                                juchuB.updNewShohin(aryPrmShohin, con);
                            }
                        }
                        else
                        {
                            shohinCd = sShohin;
                        }

                        string updC1 = null;
                        string updC2 = null;
                        string updC3 = null;
                        string updC4 = null;
                        string updC5 = null;
                        string updC6 = null;

                        if (!string.IsNullOrWhiteSpace(sKataban))
                        {
                            updC1 = sKataban;
                        }
                        else
                        {
                            updC1 = sC1;
                            updC2 = sC2;
                            updC3 = sC3;
                            updC4 = sC4;
                            updC5 = sC5;
                            updC6 = sC6;
                        }

                        List<String> aryPrmShukko = new List<string>();
                        aryPrmShukko.Add(sHNo);
                        aryPrmShukko.Add("1");
                        aryPrmShukko.Add(shohinCd);
                        aryPrmShukko.Add(sHMak);
                        aryPrmShukko.Add(sHDai);
                        aryPrmShukko.Add(sHChubun);
                        aryPrmShukko.Add(updC1);
                        aryPrmShukko.Add(updC2);
                        aryPrmShukko.Add(updC3);
                        aryPrmShukko.Add(updC4);
                        aryPrmShukko.Add(updC5);
                        aryPrmShukko.Add(updC6);
                        aryPrmShukko.Add(sHSu);
                        aryPrmShukko.Add(sHTanka);
                        aryPrmShukko.Add(sHChuban);
                        aryPrmShukko.Add(sSouko);
                        aryPrmShukko.Add(strJuchuNo);
                        aryPrmShukko.Add(sHNoki);
                        aryPrmShukko.Add(Environment.UserName);

                        juchuB.updNewShohin(aryPrmShukko, con);
                    }
                }
                con.Commit();
            }
            catch (Exception ex)
            {
                con.Rollback();
                new CommonException(ex);
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            finally
            {
                con.DB_Disconnect();
            }

            basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
            basemessagebox.ShowDialog();
        }

        private void getInfo()
        {
            if (string.IsNullOrWhiteSpace(strJuchuNo))
            {
                return;
            }
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
                    strTokuiName = dt.Rows[0]["得意先名称"].ToString();
                    strShohin = dt.Rows[0]["商品コード"].ToString();
                    strTeika = dt.Rows[0]["定価"].ToString();

                    txtHinmei.Text = strC1 + " " + strC2 + " " + strC3 + " " + strC4 + " " + strC5 + " " + strC6;

                    //getRireki();

                    if (!string.IsNullOrWhiteSpace(strShohin) && strShohin.Equals("88888"))
                    {
                        lsDaibunruiM.codeTxt.ReadOnly = false;
                        lsChubunruiM.codeTxt.ReadOnly = false;
                        lsMakerM.codeTxt.ReadOnly = false;
                    }
                    else
                    {
                        lsDaibunruiM.codeTxt.ReadOnly = true;
                        lsChubunruiM.codeTxt.ReadOnly = true;
                        lsMakerM.codeTxt.ReadOnly = true;
                        txtHinmei.ReadOnly = true;
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
                        getRireki(1);
                        return;
                    }
                    else if (dt.Rows[0]["売上済数量"].ToString().CompareTo("0") > 0)
                    {
                        basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに売上済みです。納期・数量・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        txtJuchuYMD.ReadOnly = true;
                        lsDaibunruiM.codeTxt.ReadOnly = true;
                        lsChubunruiM.codeTxt.ReadOnly = true;
                        lsMakerM.codeTxt.ReadOnly = true;
                        txtSearchStr.ReadOnly = true;
                        txtHinmei.ReadOnly = true;
                        getRireki(2);
                        return;
                    }

                    decimal dSu = juchuB.getShiirezumisuryo(strJuchuNo);

                    if (dSu > -1)
                    {
                        if (dSu > 0)
                        {
                            basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに仕入済みです。納期・数量・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();
                            txtJuchuYMD.ReadOnly = true;
                            lsDaibunruiM.codeTxt.ReadOnly = true;
                            lsChubunruiM.codeTxt.ReadOnly = true;
                            lsMakerM.codeTxt.ReadOnly = true;
                            txtSearchStr.ReadOnly = true;
                            txtHinmei.ReadOnly = true;
                            getRireki(2);
                        }
                        else
                        {
                            txtJuchuYMD.ReadOnly = false;
                            lsDaibunruiM.codeTxt.ReadOnly = false;
                            lsChubunruiM.codeTxt.ReadOnly = false;
                            lsMakerM.codeTxt.ReadOnly = false;
                            txtSearchStr.ReadOnly = false;
                            txtHinmei.ReadOnly = false;
                            getRireki(0);
                        }
                    }
                    else
                    {
                        txtJuchuYMD.ReadOnly = false;
                        lsDaibunruiM.codeTxt.ReadOnly = false;
                        lsChubunruiM.codeTxt.ReadOnly = false;
                        lsMakerM.codeTxt.ReadOnly = false;
                        txtSearchStr.ReadOnly = false;
                        txtHinmei.ReadOnly = false;
                        getRireki(0);
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

        private void getRireki(int num)
        {
            if (string.IsNullOrWhiteSpace(strJuchuNo))
            {
                return;
            }

            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();

            try
            {
                DataTable dt = juchuB.getRireki(strJuchuNo);

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

                    if (iCate != -1)
                    {
                        addInputPanelVal(cats[iCate], dt.Rows[i], num);
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

        private void txtHNo_Leave(object sender, EventArgs e)
        {
            string stNo = ((BaseTextMoney)sender).Text;
            if (string.IsNullOrWhiteSpace(stNo))
            {
                return;
            }

            Panel c = (Panel)((BaseTextMoney)sender).Parent;
            string sCate = ((Label)c.Controls["cate"]).Text;

            BaseMessageBox basemessagebox;
            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
            try
            {
                DataTable dt;
                string sC1;
                string sC2;
                string sC3;
                string sC4;
                string sC5;
                string sC6;

                if (sCate.Equals(labels[0]) || sCate.Equals(labels[2]))
                {
                    dt = juchuB.getHachu(stNo);

                    #region
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ((BaseCalendar)c.Controls["txtHYMD"]).Text = dt.Rows[0]["発注年月日"].ToString();
                        ((LabelSet_Tantousha)c.Controls["lsHSha"]).CodeTxtText = dt.Rows[0]["発注者コード"].ToString();
                        ((LabelSet_Shiresaki)c.Controls["lsShiire"]).CodeTxtText = dt.Rows[0]["仕入先コード"].ToString();
                        ((LabelSet_Daibunrui)c.Controls["lsDaibun"]).CodeTxtText = dt.Rows[0]["大分類コード"].ToString();
                        ((LabelSet_Chubunrui)c.Controls["lsChubun"]).CodeTxtText = dt.Rows[0]["中分類コード"].ToString();
                        ((LabelSet_Maker)c.Controls["lsMaker"]).CodeTxtText = dt.Rows[0]["メーカーコード"].ToString();
                        ((BaseTextMoney)c.Controls["txtSuryo"]).Text = dt.Rows[0]["発注数量"].ToString();
                        ((BaseTextMoney)c.Controls["txtTanka"]).Text = dt.Rows[0]["発注単価"].ToString();
                        ((BaseCalendar)c.Controls["txtNohki"]).Text = dt.Rows[0]["納期"].ToString();
                        ((BaseText)c.Controls["txtChuban"]).Text = dt.Rows[0]["注番"].ToString();

                        sC1 = dt.Rows[0]["Ｃ１"].ToString();
                        sC2 = dt.Rows[0]["Ｃ２"].ToString();
                        sC3 = dt.Rows[0]["Ｃ３"].ToString();
                        sC4 = dt.Rows[0]["Ｃ４"].ToString();
                        sC5 = dt.Rows[0]["Ｃ５"].ToString();
                        sC6 = dt.Rows[0]["Ｃ６"].ToString();
                        ((BaseText)c.Controls["txtC1"]).Text = sC1;
                        ((BaseText)c.Controls["txtC2"]).Text = sC2;
                        ((BaseText)c.Controls["txtC3"]).Text = sC3;
                        ((BaseText)c.Controls["txtC4"]).Text = sC4;
                        ((BaseText)c.Controls["txtC5"]).Text = sC5;
                        ((BaseText)c.Controls["txtC6"]).Text = sC6;

                        ((BaseText)c.Controls["txtHinmei"]).Text = (sC1 + " " + sC2 + " " + sC3 + " " + sC4 + " " + sC5 + " " + sC6).Trim();
                        ((BaseText)c.Controls["txtEigyo"]).Text = dt.Rows[0]["営業所コード"].ToString();
                        ((BaseText)c.Controls["txtTanto"]).Text = dt.Rows[0]["担当者コード"].ToString();
                        ((BaseText)c.Controls["txtShohin"]).Text = dt.Rows[0]["商品コード"].ToString();
                    }
                    #endregion
                }
                else
                {
                    dt = juchuB.getShukko(stNo, strJuchuNo);

                    #region
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ((BaseCalendar)c.Controls["txtHYMD"]).Text = dt.Rows[0]["伝票年月日"].ToString();
                        ((LabelSet_Tantousha)c.Controls["lsHSha"]).CodeTxtText = dt.Rows[0]["担当者コード"].ToString();
                        ((LabelSet_Shiresaki)c.Controls["lsShiire"]).CodeTxtText = dt.Rows[0]["仕入先コード"].ToString();
                        ((LabelSet_Daibunrui)c.Controls["lsDaibun"]).CodeTxtText = dt.Rows[0]["大分類コード"].ToString();
                        ((LabelSet_Chubunrui)c.Controls["lsChubun"]).CodeTxtText = dt.Rows[0]["中分類コード"].ToString();
                        ((LabelSet_Maker)c.Controls["lsMaker"]).CodeTxtText = dt.Rows[0]["メーカーコード"].ToString();
                        ((BaseTextMoney)c.Controls["txtSuryo"]).Text = dt.Rows[0]["数量"].ToString();
                        ((BaseTextMoney)c.Controls["txtTanka"]).Text = dt.Rows[0]["単価"].ToString();
                        ((BaseCalendar)c.Controls["txtNohki"]).Text = dt.Rows[0]["出庫予定日"].ToString();
                        ((BaseText)c.Controls["txtChuban"]).Text = dt.Rows[0]["備考"].ToString();

                        sC1 = dt.Rows[0]["Ｃ１"].ToString();
                        sC2 = dt.Rows[0]["Ｃ２"].ToString();
                        sC3 = dt.Rows[0]["Ｃ３"].ToString();
                        sC4 = dt.Rows[0]["Ｃ４"].ToString();
                        sC5 = dt.Rows[0]["Ｃ５"].ToString();
                        sC6 = dt.Rows[0]["Ｃ６"].ToString();
                        ((BaseText)c.Controls["txtC1"]).Text = sC1;
                        ((BaseText)c.Controls["txtC2"]).Text = sC2;
                        ((BaseText)c.Controls["txtC3"]).Text = sC3;
                        ((BaseText)c.Controls["txtC4"]).Text = sC4;
                        ((BaseText)c.Controls["txtC5"]).Text = sC5;
                        ((BaseText)c.Controls["txtC6"]).Text = sC6;

                        ((BaseText)c.Controls["txtHinmei"]).Text = (sC1 + " " + sC2 + " " + sC3 + " " + sC4 + " " + sC5 + " " + sC6).Trim();
                        ((BaseText)c.Controls["txtEigyo"]).Text = dt.Rows[0]["営業所コード"].ToString();
                        ((BaseText)c.Controls["txtTanto"]).Text = dt.Rows[0]["担当者コード"].ToString();
                        ((BaseText)c.Controls["txtShohin"]).Text = dt.Rows[0]["商品コード"].ToString();
                        ((BaseText)c.Controls["txtSouko"]).Text = dt.Rows[0]["出庫倉庫"].ToString();
                    }
                    #endregion
                }

                if (sCate.Equals(labels[0]) || sCate.Equals(labels[2]))
                {
                    decimal dSu = juchuB.getShiirezumisuryoH(stNo);
                    if (dSu != -1)
                    {
                        if (dSu > 0)
                        {
                            basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに仕入済みです。納期・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();

                            ((LabelSet_Tantousha)c.Controls["lsHSha"]).codeTxt.ReadOnly = true;

                            ((BaseCalendar)c.Controls["txtHYMD"]).ReadOnly = true;
                            ((LabelSet_Shiresaki)c.Controls["lsShiire"]).codeTxt.ReadOnly = true;
                            ((BaseTextMoney)c.Controls["txtHNo"]).ReadOnly = true;
                            ((LabelSet_Daibunrui)c.Controls["lsDaibun"]).codeTxt.ReadOnly = true;
                            ((LabelSet_Chubunrui)c.Controls["lsChubun"]).codeTxt.ReadOnly = true;
                            ((LabelSet_Maker)c.Controls["lsMaker"]).codeTxt.ReadOnly = true;
                            ((BaseText)c.Controls["txtHinmei"]).ReadOnly = true;
                            ((BaseTextMoney)c.Controls["txtSuryo"]).ReadOnly = true;
                            ((BaseTextMoney)c.Controls["txtTanka"]).ReadOnly = true;
                            ((BaseCalendar)c.Controls["txtNohki"]).ReadOnly = false;
                            ((BaseText)c.Controls["txtChuban"]).ReadOnly = false;
                        }
                        else
                        {
                            ((LabelSet_Tantousha)c.Controls["lsHSha"]).codeTxt.ReadOnly = false;

                            ((BaseCalendar)c.Controls["txtHYMD"]).ReadOnly = false;
                            ((LabelSet_Shiresaki)c.Controls["lsShiire"]).codeTxt.ReadOnly = false;
                            ((BaseTextMoney)c.Controls["txtHNo"]).ReadOnly = false;
                            ((LabelSet_Daibunrui)c.Controls["lsDaibun"]).codeTxt.ReadOnly = false;
                            ((LabelSet_Chubunrui)c.Controls["lsChubun"]).codeTxt.ReadOnly = false;
                            ((LabelSet_Maker)c.Controls["lsMaker"]).codeTxt.ReadOnly = false;
                            ((BaseText)c.Controls["txtHinmei"]).ReadOnly = false;
                            ((BaseTextMoney)c.Controls["txtSuryo"]).ReadOnly = false;
                            ((BaseTextMoney)c.Controls["txtTanka"]).ReadOnly = false;
                            ((BaseCalendar)c.Controls["txtNohki"]).ReadOnly = false;
                            ((BaseText)c.Controls["txtChuban"]).ReadOnly = false;
                        }
                    }
                    else
                    {
                        ((LabelSet_Tantousha)c.Controls["lsHSha"]).codeTxt.ReadOnly = false;

                        ((BaseCalendar)c.Controls["txtHYMD"]).ReadOnly = false;
                        ((LabelSet_Shiresaki)c.Controls["lsShiire"]).codeTxt.ReadOnly = false;
                        ((BaseTextMoney)c.Controls["txtHNo"]).ReadOnly = false;
                        ((LabelSet_Daibunrui)c.Controls["lsDaibun"]).codeTxt.ReadOnly = false;
                        ((LabelSet_Chubunrui)c.Controls["lsChubun"]).codeTxt.ReadOnly = false;
                        ((LabelSet_Maker)c.Controls["lsMaker"]).codeTxt.ReadOnly = false;
                        ((BaseText)c.Controls["txtHinmei"]).ReadOnly = false;
                        ((BaseTextMoney)c.Controls["txtSuryo"]).ReadOnly = false;
                        ((BaseTextMoney)c.Controls["txtTanka"]).ReadOnly = false;
                        ((BaseCalendar)c.Controls["txtNohki"]).ReadOnly = false;
                        ((BaseText)c.Controls["txtChuban"]).ReadOnly = false;
                    }
                }

                //getZaikoInfo();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void txtNohki_Leave(object sender, EventArgs e)
        {
            String sNoki = ((BaseCalendar)sender).Text;
            if (string.IsNullOrEmpty(sNoki))
            {
                return;
            }

            if (sNoki.CompareTo(string.Format("yyyy/MM/dd", DateTime.Now)) < 0)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は本日以降に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                ((BaseCalendar)sender).Text = "";
                ((BaseCalendar)sender).Focus();
                return;
            }

            DateTime endDateTime = DateTime.Parse(txtJuchuYMD.Text);
            string strEndDay = string.Format("yyyy/MM/dd", endDateTime.AddYears(1));

            if (!string.IsNullOrWhiteSpace(strJuchuNo))
            {
                A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
                try
                {
                    DataTable dtHatchu = juchuB.getShiireSuryouNoki(strJuchuNo);

                    if (dtHatchu != null && dtHatchu.Rows.Count > 0)
                    {
                        String strSuryo = dtHatchu.Rows[0]["仕入済数量"].ToString();
                        if (decimal.Parse(strSuryo) > 0)
                        {
                            strEndDay = string.Format("yyyy/MM/dd", endDateTime.AddMonths(6));
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

            Panel c = (Panel)((BaseCalendar)sender).Parent;

            String sHachu = ((BaseTextMoney)c.Controls["txtHNo"]).Text;

            if (!string.IsNullOrWhiteSpace(sHachu) && decimal.Parse(sHachu) > 0)
            {
                if (sNoki.CompareTo(strEndDay) > 0)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は仕入済みの場合は６ケ月、未仕入の場合は１年間に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((BaseCalendar)sender).Text = "";
                    ((BaseCalendar)sender).Focus();
                    return;
                }
            }

            //}
        }

        private void txtEigyo_TextChanged(object sender, EventArgs e)
        {
            Panel c = (Panel)((BaseText)sender).Parent;
            ((BaseText)c.Controls["txtSouko"]).Text = ((BaseText)c.Controls["txtEigyo"]).Text;
        }

        private bool chkData()
        {
            TableLayoutControlCollection c = tableLayoutPanel1.Controls;
            bool flg = false;
            if (flg == false)
            {
                if (string.IsNullOrWhiteSpace(strJuchuNo))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "受注のみの登録は出来ません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return false;
                }
                A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
                try
                {
                    DataTable dt = juchuB.getHatchuNoInfo(strJuchuNo);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "受注のみの登録は出来ません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        return false;
                    }
                    decimal dSu = juchuB.getShukkoToroku(strJuchuNo);
                    if (dSu == 0)
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "受注のみの登録は出来ません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
            }

            DateTime endDateTime = DateTime.Parse(txtJuchuYMD.Text);
            string strEndDay = string.Format("yyyy/MM/dd", endDateTime.AddYears(1));

            if (!string.IsNullOrWhiteSpace(strJuchuNo))
            {
                A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
                try
                {
                    DataTable dtHatchu = juchuB.getShiireSuryouNoki(strJuchuNo);

                    if (dtHatchu != null && dtHatchu.Rows.Count > 0)
                    {
                        String strSuryo = dtHatchu.Rows[0]["仕入済数量"].ToString();
                        if (decimal.Parse(strSuryo) > 0)
                        {
                            strEndDay = string.Format("yyyy/MM/dd", endDateTime.AddMonths(6));
                        }
                    }
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
            }

            //if ()
            //{


            if (strNoki.CompareTo(string.Format("yyyy/MM/dd", DateTime.Now)) < 0)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は本日以降に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                strNoki = "";
                return false;
            }

            if (strNoki.CompareTo(strEndDay) > 0)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は仕入済みの場合は６ケ月、未仕入の場合は１年間に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                strNoki = "";
                return false;
            }
            //}

            foreach (Control cc in c)
            {
                if (changeVal((Panel)cc)) {
                    continue;
                }
                string sYMD = ((BaseCalendar)cc.Controls["txtNohki"]).Text;
                if (sYMD.CompareTo(string.Format("yyyy/MM/dd", DateTime.Now)) < 0)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は本日以降に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((BaseCalendar)cc.Controls["txtNohki"]).Text = "";
                    ((BaseCalendar)cc.Controls["txtNohki"]).Focus();
                    return false;
                }

                string sSuryo = ((BaseTextMoney)cc.Controls["txtSuryo"]).Text;
                if (!string.IsNullOrWhiteSpace(sSuryo) && decimal.Parse(sSuryo) > 0)
                {
                    if (sYMD.CompareTo(strEndDay) > 0)
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は仕入済みの場合は６ケ月、未仕入の場合は１年間に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        ((BaseCalendar)cc.Controls["txtNohki"]).Text = "";
                        ((BaseCalendar)cc.Controls["txtNohki"]).Focus();
                        return false;
                    }
                }
                if ((((Label)cc.Controls["cate"]).Text).Equals(labels[1]))
                {
                    string sLimit = string.Format("yyyy/MM/dd", (DateTime.Now).AddDays(7));

                    if (sYMD.CompareTo(sLimit) < 0)
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫予定日は７日以内に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        ((BaseCalendar)cc.Controls["txtNohki"]).Text = "";
                        ((BaseCalendar)cc.Controls["txtNohki"]).Focus();
                        return false;
                    }
                }
            }

            decimal SK = 0;
            decimal KK = 0;
            decimal HC = 0;
            decimal SKs = 0;
            decimal KKs = 0;
            decimal HCs = 0;

            decimal dTotal = 0;


            foreach (Control cc in c)
            {
                string sLbl = ((Label)cc.Controls["cate"]).Text;
                string sHSha = ((LabelSet_Tantousha)cc.Controls["lsHSha"]).CodeTxtText;
                string sHYMD = ((BaseCalendar)cc.Controls["txtHYMD"]).Text;
                string sHShiire = ((LabelSet_Shiresaki)cc.Controls["lsShiire"]).CodeTxtText;
                string sHNo = ((BaseTextMoney)cc.Controls["txtHNo"]).Text;
                string sHDai = ((LabelSet_Daibunrui)cc.Controls["lsDaibun"]).CodeTxtText;
                string sHChubun = ((LabelSet_Chubunrui)cc.Controls["lsChubun"]).CodeTxtText;
                string sHMak = ((LabelSet_Maker)cc.Controls["lsMaker"]).CodeTxtText;
                string sHHin = ((BaseText)cc.Controls["txtHinmei"]).Text;
                string sHTanaL = ((BaseLabelGray)cc.Controls["txtTanabanL"]).Text;
                string sHTanaR = ((BaseLabelGray)cc.Controls["txtTanabanR"]).Text;
                string sHSu = ((BaseTextMoney)cc.Controls["txtSuryo"]).Text;
                string sHTanka = ((BaseTextMoney)cc.Controls["txtTanka"]).Text;
                string sHNoki = ((BaseCalendar)cc.Controls["txtNohki"]).Text;
                string sHChuban = ((BaseText)cc.Controls["txtChuban"]).Text;
                string sShohin = ((BaseText)cc.Controls["txtShohin"]).Text;
                string sShiireSu = ((BaseText)cc.Controls["txtShiireSu"]).Text;
                string sShiireBi = ((BaseText)cc.Controls["txtShiireBi"]).Text;
                string sSouko = ((BaseText)cc.Controls["txtSouko"]).Text;
                string sTmpSu = ((BaseText)cc.Controls["tmpSuryo"]).Text; 

                if (string.IsNullOrWhiteSpace(sHYMD))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((BaseCalendar)cc.Controls["txtHYMD"]).Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(sHSha))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((LabelSet_Tantousha)cc.Controls["lsHSha"]).Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(sHNo))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((BaseTextMoney)cc.Controls["txtHNo"]).Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(sHShiire))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((LabelSet_Shiresaki)cc.Controls["lsShiire"]).Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(sHMak))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((LabelSet_Maker)cc.Controls["lsMaker"]).Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(sHDai))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((LabelSet_Daibunrui)cc.Controls["lsDaibun"]).Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(sHChuban))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((LabelSet_Chubunrui)cc.Controls["lsChubun"]).Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(sHHin))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((BaseText)cc.Controls["txtHinmei"]).Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(sHSu))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((BaseTextMoney)cc.Controls["txtSuryo"]).Focus();
                    return false;
                }
                if (sLbl.Equals(labels[0]) || sLbl.Equals(labels[2]))
                {
                    if (string.IsNullOrWhiteSpace(sHNoki))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        ((BaseCalendar)cc.Controls["txtNohki"]).Focus();
                        return false;
                    }
                }

                if (sLbl.Equals(labels[1]))
                {
                    if (string.IsNullOrWhiteSpace(sHTanka) || sHTanka.Equals("0"))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "単価が￥０です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        ((BaseTextMoney)cc.Controls["txtTanka"]).Focus();
                        return false;
                    }
                }

                if (sLbl.Equals(labels[3]))
                {
                    if (!string.IsNullOrWhiteSpace(sHTanka) && !sHTanka.Equals("0"))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "単価は￥０にしてください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        ((BaseTextMoney)cc.Controls["txtTanka"]).Focus();
                        return false;
                    }
                }

                if (string.IsNullOrWhiteSpace(sHNo))
                {
                    if (sLbl.Equals(labels[1]))
                    {
                        SK = SK + 1;
                        SKs = SKs + decimal.Parse(sHSu);
                    }
                    if (sLbl.Equals(labels[3]))
                    {
                        SK = SK + 1;
                        SKs = SKs + decimal.Parse(sHSu);
                    }
                    if (sLbl.Equals(labels[2]))
                    {
                        KK = KK + 1;
                        KKs = KKs + decimal.Parse(sHSu);
                    }
                    if (sLbl.Equals(labels[0]))
                    {
                        HC = HC + 1;
                        HCs = HCs + decimal.Parse(sHSu);
                    }
                }

                if (sLbl.Equals(labels[1]))
                {
                    if (string.IsNullOrWhiteSpace(sShohin) && sShohin.Equals("88888"))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "商品マスタに登録されていない型番です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        return false;
                    }
                }

                bool bShiirezumi = false;
                decimal dShiireSu = 0;
                decimal dGenzaikoSu = 0;
                bool bHaccyuAri = false;
                
                if (sLbl.Equals(labels[1]))
                {
                    bHaccyuAri = true;
                    if (!string.IsNullOrWhiteSpace(sShiireSu)) {
                        dShiireSu = decimal.Parse(sShiireSu);
                    }
                    if (string.IsNullOrWhiteSpace(sShiireSu) || sShiireSu.Equals("0"))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "仕入処理を先に行ってください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        return false;
                    }
                    else
                    {
                        bShiirezumi = true;
                    }

                    if (!string.IsNullOrWhiteSpace(sShiireBi) && sHYMD.CompareTo(sShiireBi) < 0)
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "仕入日以降で登録してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        return false;
                    }
                }

                decimal tmpZaiko = 0;
                //if () {
                if (sLbl.Equals(labels[1]) && !sShohin.Equals("88888"))
                {
                    if (!string.IsNullOrWhiteSpace(sSouko) && sSouko.Equals("0001"))
                    {
                        if (gridZaiko[2, 0] != null && !string.IsNullOrWhiteSpace(gridZaiko[2, 0].ToString())) {

                            tmpZaiko = decimal.Parse((gridZaiko[2, 0].Value).ToString());
                        }
                        if (gridZaiko[1, 0] != null && !string.IsNullOrWhiteSpace(gridZaiko[1, 0].ToString())) {
                            dGenzaikoSu = decimal.Parse((gridZaiko[1, 0].Value).ToString());
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(sSouko) && sSouko.Equals("0002"))
                    {
                        if (gridZaiko[2, 1] != null && !string.IsNullOrWhiteSpace(gridZaiko[2, 1].ToString()))
                        {

                            tmpZaiko = decimal.Parse((gridZaiko[2, 1].Value).ToString());
                        }
                        if (gridZaiko[1, 1] != null && !string.IsNullOrWhiteSpace(gridZaiko[1, 1].ToString()))
                        {
                            dGenzaikoSu = decimal.Parse((gridZaiko[1, 1].Value).ToString());
                        }
                    }

                    if (bHaccyuAri == false)
                    {
                        decimal d = 0;
                        if (string.IsNullOrWhiteSpace(sHNo))
                        {
                            if (decimal.Parse(sHSu) > tmpZaiko)
                            {
                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "フリー在庫が不足しています。\r\nフリー在庫数：" + tmpZaiko.ToString(), CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                basemessagebox.ShowDialog();
                                return false;
                            }
                        }
                        else
                        {
                            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
                            try
                            {
                                DataTable dt = juchuB.getShukkoSu(sHNo);
                                 
                                if (dt != null && dt.Rows.Count > 0 && string.IsNullOrWhiteSpace(dt.Rows[0]["数量"].ToString()))
                                {
                                    d = decimal.Parse(dt.Rows[0]["数量"].ToString());
                                }
                                decimal d2 = 0;
                                if (string.IsNullOrWhiteSpace(sTmpSu))
                                {
                                    d2 = decimal.Parse(sTmpSu);
                                }
                                
                                if (decimal.Parse(sHSu) > tmpZaiko + d + d2)
                                {
                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "フリー在庫が不足しています。\r\nフリー在庫数：" + (tmpZaiko + d + d2).ToString(), CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                    basemessagebox.ShowDialog();
                                    return false;
                                }
                            }
                            catch (Exception ex)
                            {
                                new CommonException(ex);
                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                basemessagebox.ShowDialog();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (decimal.Parse(sHSu) > dShiireSu)
                        {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "仕入数が不足しています。\r\n仕入済数：" + (dShiireSu).ToString(), CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();
                            return false;
                        }
                        if (decimal.Parse(sHSu) > dGenzaikoSu)
                        {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "在庫数が不足しています。\r\n仕入済数：" + (dGenzaikoSu).ToString(), CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();
                            return false;
                        }
                    }
                }
                if (!sLbl.Equals(labels[0]) && !string.IsNullOrWhiteSpace(sHTanka) && !string.IsNullOrWhiteSpace(sHSu))
                {
                    dTotal += decimal.Parse(sHTanka) * decimal.Parse(sHSu);
                }
                
                //}
            }

            if (HC > 0 && SK < HC)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫処理を先に行ってください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }
            if (HC > 0 && SKs < HCs)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫数と発注数が違います。正しく出庫処理を行ってください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }

            if (dTotal.Equals(0))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "仕入単価が￥０のため登録できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }

            return true;
        }

        private int judRiekiritsu()
        {
            int ret = 0;

            decimal decShiire = 0;
            if (strShiireTanka != null)
            {
                decShiire = int.Parse(strShiireTanka);
            }
            decimal decRitsu = (Math.Abs(decimal.Parse(strJuchuTanka)) - decShiire) / Math.Abs(decimal.Parse(strJuchuTanka)) * 100;

            decimal JyucyuRitu = 0;
            if (!string.IsNullOrWhiteSpace(strTeika))
            {
                JyucyuRitu = (decimal.Parse(strJuchuTanka) / decimal.Parse(strTeika)) * 100;
            }

            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
            try
            {
                DataTable dtRieki = juchuB.getRiekiritsu(strTokuiCd, strShohin, null, null, null);

                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (decRitsu < decimal.Parse(dtRieki.Rows[0]["利益率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "利益率", "利益率を割っています。\r\n(設定利益率=" + dtRieki.Rows[0]["利益率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }

                    if (dtRieki.Rows[0]["単価"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["単価"].ToString()))
                    {
                        if (decimal.Parse(strJuchuTanka) < decimal.Parse(dtRieki.Rows[0]["単価"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "単価", "設定単価を下回っています。\r\n(設定単価=" + dtRieki.Rows[0]["単価"].ToString() + "円)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }
                    return ret;
                }

                DataTable dtCodes = juchuB.getCodesFromShohin(strShohin);

                if (dtCodes != null && dtCodes.Rows.Count > 0)
                {
                    return ret;
                }

                string strDaibunrui = dtCodes.Rows[0]["大分類コード"].ToString();
                string strChubunrui = dtCodes.Rows[0]["中分類コード"].ToString();
                string strMaker = dtCodes.Rows[0]["メーカーコード"].ToString();

                dtRieki = juchuB.getRiekiritsu(strTokuiCd, strShohin, strDaibunrui, strChubunrui, strMaker);

                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (decRitsu < decimal.Parse(dtRieki.Rows[0]["利益率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "利益率", "利益率を割っています。\r\n(設定利益率=" + dtRieki.Rows[0]["利益率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }

                    if (dtRieki.Rows[0]["掛率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["掛率"].ToString()))
                    {
                        if (JyucyuRitu < decimal.Parse(dtRieki.Rows[0]["掛率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "掛率", "設定掛率を下回っています。\r\n(設定掛率=" + dtRieki.Rows[0]["掛率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }
                    return ret;
                }

                dtRieki = juchuB.getRiekiritsu(strTokuiCd, strShohin, strDaibunrui, strChubunrui, null);

                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (decRitsu < decimal.Parse(dtRieki.Rows[0]["利益率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "利益率", "利益率を割っています。\r\n(設定利益率=" + dtRieki.Rows[0]["利益率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }

                    if (dtRieki.Rows[0]["掛率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["掛率"].ToString()))
                    {
                        if (JyucyuRitu < decimal.Parse(dtRieki.Rows[0]["掛率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "掛率", "設定掛率を下回っています。\r\n(設定掛率=" + dtRieki.Rows[0]["掛率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }
                    return ret;
                }

                dtRieki = juchuB.getRiekiritsu(strTokuiCd, strShohin, strDaibunrui, null, strMaker);

                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (decRitsu < decimal.Parse(dtRieki.Rows[0]["利益率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "利益率", "利益率を割っています。\r\n(設定利益率=" + dtRieki.Rows[0]["利益率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }

                    if (dtRieki.Rows[0]["掛率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["掛率"].ToString()))
                    {
                        if (JyucyuRitu < decimal.Parse(dtRieki.Rows[0]["掛率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "掛率", "設定掛率を下回っています。\r\n(設定掛率=" + dtRieki.Rows[0]["掛率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }
                    return ret;
                }

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                throw ex;
            }

            return ret;
        }

        private bool changeVal(Panel cc)
        {
            if (!((BaseCalendar)cc.Controls["txtHYMD"]).Text.Equals(((BaseCalendar)cc.Controls["tmpHYMD"]))) {
                return true;
            }
            if (!((LabelSet_Tantousha)cc.Controls["lsHSha"]).CodeTxtText.Equals(((BaseText)cc.Controls["tmpHSha"])))
            {
                return true;
            }
            if (!((LabelSet_Shiresaki)cc.Controls["lsShiire"]).CodeTxtText.Equals(((BaseText)cc.Controls["tmpShiire"])))
            {
                return true;
            }
            if (!((BaseTextMoney)cc.Controls["txtHNo"]).Text.Equals(((BaseTextMoney)cc.Controls["tmpHNo"])))
            {
                return true;
            }
            if (!((LabelSet_Daibunrui)cc.Controls["lsDaibun"]).CodeTxtText.Equals(((BaseText)cc.Controls["tmpDaibun"])))
            {
                return true;
            }
            if (!((LabelSet_Chubunrui)cc.Controls["lsChubun"]).CodeTxtText.Equals(((BaseText)cc.Controls["tmpChubun"])))
            {
                return true;
            }
            if (!((LabelSet_Maker)cc.Controls["lsMaker"]).CodeTxtText.Equals(((BaseText)cc.Controls["tmpMaker"])))
            {
                return true;
            }
            if (!((BaseText)cc.Controls["txtHinmei"]).Text.Equals(((BaseText)cc.Controls["tmpHinmei"])))
            {
                return true;
            }
            if (!((BaseTextMoney)cc.Controls["txtSuryo"]).Text.Equals(((BaseTextMoney)cc.Controls["tmpSuryo"])))
            {
                return true;
            }
            if (!((BaseTextMoney)cc.Controls["txtTanka"]).Text.Equals(((BaseTextMoney)cc.Controls["tmpTanka"])))
            {
                return true;
            }
            if (!((BaseCalendar)cc.Controls["txtNohki"]).Text.Equals(((BaseCalendar)cc.Controls["tmpNohki"])))
            {
                return true;
            }
            if (!((BaseText)cc.Controls["txtChuban"]).Text.Equals(((BaseText)cc.Controls["tmpChuban"])))
            {
                return true;
            }
            return false;
        }

        // 検索
        private void txtSearchStr_Leave(object sender, EventArgs e)
        {

            BaseText t = (BaseText)sender;
            Panel c = (Panel)t.Parent;

            string s1 = ((BaseText)c.Controls["txtSearchStr"]).Text;
            string s2 = ((BaseText)c.Controls["oldStr"]).Text;
            if (string.IsNullOrWhiteSpace(s1) || s1.Equals(s2))
            {
                return;
            }

            ((BaseText)c.Controls["oldStr"]).Text = s1;

            getShohinCd((LabelSet_Daibunrui)c.Controls["lsDaibun"],
                (LabelSet_Chubunrui)c.Controls["lsChubun"],
                (LabelSet_Maker)c.Controls["lsMaker"],
                (BaseText)c.Controls["txtSearchStr"],
                (BaseText)c.Controls["txtShohin"],
                (BaseText)c.Controls["txtKataban"]);
        }

        private void txtSearchStr_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchStr.Text) || txtSearchStr.Text.Equals(txtOldStr.Text))
            {
                return;
            }

            txtOldStr.Text = txtSearchStr.Text;

            getShohinCd(lsDaibunruiM, lsChubunruiM, lsMakerM, txtSearchStr, txtShohinCd, txtHinmei);
        }

        private void getShohinCd(LabelSet_Daibunrui d, LabelSet_Chubunrui c, LabelSet_Maker m, BaseText b, BaseText sh, BaseText hin)
        {
            KATO.Common.Form.ShouhinList shohinList = new KATO.Common.Form.ShouhinList(this);
            shohinList.intFrmKind = CommonTeisu.FRM_KAKOHINJUCHUINPUT;
            shohinList.blKensaku = false;
            shohinList.lsDaibunrui = d;
            shohinList.lsChubunrui = c;
            shohinList.lsMaker = m;
            shohinList.btxtKensaku = b;
            shohinList.btxtShohinCd = sh;
            shohinList.btxtHinC1Hinban = hin;

            if (!String.IsNullOrWhiteSpace(d.CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(c.CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(m.CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(b.Text))
            {
                shohinList.blKensaku = true;
            }

            shohinList.Show();
        }

        private void clearInput()
        {
            TableLayoutControlCollection c = tableLayoutPanel1.Controls;

            c.Clear();

            txtJuchuYMD.ReadOnly = false;
            lsDaibunruiM.codeTxt.ReadOnly = false;
            lsChubunruiM.codeTxt.ReadOnly = false;
            lsMakerM.codeTxt.ReadOnly = false;
            txtSearchStr.ReadOnly = false;
            txtHinmei.ReadOnly = false;

            btnF01.Enabled = true;
            btnF03.Enabled = true;
            btnF08.Enabled = true;
            btnF09.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;

            getInfo();
        }

        // util 系
        private decimal getDecValue(string s)
        {
            decimal ret = 0;

            if (string.IsNullOrWhiteSpace(s))
            {
                return ret;
            }

            try
            {
                ret = decimal.Parse(s);
            }
            catch (Exception e)
            {

            }
            return ret;
        }

        // 加工入力の入力件数存在チェック
        public bool isExistInput ()
        {
            bool ret = false;
            TableLayoutControlCollection c = tableLayoutPanel1.Controls;

            foreach (Control cc in c)
            {
                ret = true;
                break;
            }
            return ret;
        }

        public string updTanka (string stJSu)
        {
            string ret = "";
            decimal dTotal = 0;

            TableLayoutControlCollection c = tableLayoutPanel1.Controls;

            foreach (Control cc in c)
            {
                string sLbl = ((Label)cc.Controls["cate"]).Text;
                string sHSu = ((BaseTextMoney)cc.Controls["txtSuryo"]).Text;
                string sHTanka = ((BaseTextMoney)cc.Controls["txtTanka"]).Text;

                if (!sLbl.Equals(labels[0]))
                {
                    dTotal += getDecValue(sHTanka) * getDecValue(sHSu);
                }
            }

            if (!getDecValue(stJSu).Equals(0))
            {
                dTotal = decimal.Round(dTotal / getDecValue(stJSu), 2);
            }

            ret = dTotal.ToString();
            return ret;
        }
    }
}
