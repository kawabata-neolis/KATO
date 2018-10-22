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
        readonly String[] labelsNohki = new String[] { "納期", "出庫日", "納期", "出庫日", "出庫日", "出庫日" };

        // 変数
        int[] panelCnt = { 0, 0, 0, 0, 0, 0 };
        String zeroPad = null;
        int minimumIdx = 0;
        Control ctl = null;

        A0010_JuchuInput a0010JInput;
        public String strJuchuNo = "";
        public String strEigyoCd = ""; 
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

            this.checkBox1.Checked = false;

            //A0010_JuchuInput frm1;

            //frm1 = (A0010_JuchuInput)this.Parent;
            txtHinmei.Text = a0010JInput.txtHinmei.Text;
            strJuchuNo = a0010JInput.txtJuchuNo.Text;
            strJuchuSu = a0010JInput.txtJuchuSuryo.Text;

            txtJuchuYMD.Text = (DateTime.Now).ToString("yyyy/MM/dd");

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
        private void setColumn(BaseDataGridView gr, DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
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

            ((BaseCalendar)inputPanel.Controls["txtHYMD"]).Text = ((BaseCalendar)c.Controls["txtHYMD"]).Text;
            ((LabelSet_Tantousha)inputPanel.Controls["lsHSha"]).CodeTxtText = ((LabelSet_Tantousha)c.Controls["lsHSha"]).CodeTxtText;
            ((TextSet_Torihikisaki)inputPanel.Controls["lsShiire"]).CodeTxtText = "";
            ((BaseTextMoney)inputPanel.Controls["txtHNo"]).Text = "";
            ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).CodeTxtText = ((LabelSet_Daibunrui)c.Controls["lsDaibun"]).CodeTxtText;
            ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).chkTxtDaibunrui();
            ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).CodeTxtText = ((LabelSet_Chubunrui)c.Controls["lsChubun"]).CodeTxtText;
            ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).chkTxtChubunrui(((LabelSet_Daibunrui)c.Controls["lsDaibun"]).CodeTxtText);
            ((LabelSet_Maker)inputPanel.Controls["lsMaker"]).CodeTxtText = ((LabelSet_Maker)c.Controls["lsMaker"]).CodeTxtText;
            ((BaseText)inputPanel.Controls["txtHinmei"]).Text = ((BaseText)c.Controls["txtHinmei"]).Text;
            ((BaseLabelGray)inputPanel.Controls["txtTanabanL"]).Text = ((BaseLabelGray)c.Controls["txtTanabanL"]).Text;
            ((BaseLabelGray)inputPanel.Controls["txtTanabanR"]).Text = ((BaseLabelGray)c.Controls["txtTanabanR"]).Text;
            ((BaseTextMoney)inputPanel.Controls["txtSuryo"]).Text = ((BaseTextMoney)c.Controls["txtSuryo"]).Text;
            ((BaseTextMoney)inputPanel.Controls["txtTanka"]).Text = ((BaseTextMoney)c.Controls["txtTanka"]).Text;
            ((BaseCalendar)inputPanel.Controls["txtNohki"]).Text = "";
            ((BaseText)inputPanel.Controls["txtChuban"]).Text = ((BaseText)c.Controls["txtChuban"]).Text;
            ((BaseText)inputPanel.Controls["txtEigyo"]).Text = ((BaseText)c.Controls["txtEigyo"]).Text;

            ((BaseCalendar)inputPanel.Controls["tmpHYMD"]).Text = ((BaseCalendar)c.Controls["txtHYMD"]).Text;
            ((BaseText)inputPanel.Controls["tmpHSha"]).Text = ((LabelSet_Tantousha)c.Controls["lsHSha"]).CodeTxtText;
            ((BaseText)inputPanel.Controls["tmpShiire"]).Text = "";
            ((BaseText)inputPanel.Controls["tmpSName"]).Text = "";
            ((BaseTextMoney)inputPanel.Controls["tmpHNo"]).Text = "";
            ((BaseText)inputPanel.Controls["tmpDaibun"]).Text = ((LabelSet_Daibunrui)c.Controls["lsDaibun"]).CodeTxtText;
            ((BaseText)inputPanel.Controls["tmpChubun"]).Text = ((LabelSet_Chubunrui)c.Controls["lsChubun"]).CodeTxtText;
            ((BaseText)inputPanel.Controls["tmpMaker"]).Text = ((LabelSet_Maker)c.Controls["lsMaker"]).CodeTxtText;
            ((BaseText)inputPanel.Controls["tmpHinmei"]).Text = ((BaseText)c.Controls["txtHinmei"]).Text;
            ((BaseTextMoney)inputPanel.Controls["tmpSuryo"]).Text = ((BaseTextMoney)c.Controls["txtSuryo"]).Text;
            ((BaseTextMoney)inputPanel.Controls["tmpTanka"]).Text = ((BaseTextMoney)c.Controls["txtTanka"]).Text;
            ((BaseCalendar)inputPanel.Controls["tmpNohki"]).Text = "";
            ((BaseText)inputPanel.Controls["tmpChuban"]).Text = ((BaseText)c.Controls["txtChuban"]).Text;

            ((BaseText)inputPanel.Controls["txtC1"]).Text = ((BaseText)c.Controls["txtC1"]).Text;
            ((BaseText)inputPanel.Controls["txtC2"]).Text = ((BaseText)c.Controls["txtC2"]).Text;
            ((BaseText)inputPanel.Controls["txtC3"]).Text = ((BaseText)c.Controls["txtC3"]).Text;
            ((BaseText)inputPanel.Controls["txtC4"]).Text = ((BaseText)c.Controls["txtC4"]).Text;
            ((BaseText)inputPanel.Controls["txtC5"]).Text = ((BaseText)c.Controls["txtC5"]).Text;
            ((BaseText)inputPanel.Controls["txtC6"]).Text = ((BaseText)c.Controls["txtC6"]).Text;
            ((BaseText)inputPanel.Controls["txtShohin"]).Text = ((BaseText)c.Controls["txtShohin"]).Text;
            ((BaseText)inputPanel.Controls["txtShiireSu"]).Text = ((BaseText)c.Controls["txtShiireSu"]).Text;
            ((BaseText)inputPanel.Controls["txtShiireBi"]).Text = ((BaseText)c.Controls["txtShiireBi"]).Text;
            ((BaseText)inputPanel.Controls["txtKataban"]).Text = ((BaseText)c.Controls["txtKataban"]).Text;
            ((BaseText)inputPanel.Controls["notNewPanel"]).Text = "0";

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

            A0024_KakohinJuchuInput_B kakoB = new A0024_KakohinJuchuInput_B();

            DBConnective con = new DBConnective();
            try
            {
                if (string.IsNullOrWhiteSpace(((BaseTextMoney)c.Controls["txtHNo"]).Text))
                {
                    return;
                }
                DataTable dtS = kakoB.getShiire(((BaseTextMoney)c.Controls["txtHNo"]).Text);
                if (dtS != null && dtS.Rows.Count > 0)
                {
                    ((BaseTextMoney)inputPanel.Controls["txtHNo"]).Text = kakoB.getDenpyoNo("出庫伝票", con);
                    ((BaseTextMoney)inputPanel.Controls["tmpHNo"]).Text = ((BaseTextMoney)inputPanel.Controls["txtHNo"]).Text;

                    Button btnExecShukko = new Button();
                    btnExecShukko.Text = "出庫実行";
                    btnExecShukko.Tag = cats[4];
                    inputPanel.Controls.Add(btnExecShukko);
                    btnExecShukko.Click += new EventHandler(btnExecShukko_Click);
                    btnExecShukko.Location = new Point(1000, 105);
                    btnExecShukko.BringToFront();
                    btnExecShukko.Name = "btnAddShukko";
                    btnExecShukko.TabIndex = (int)Math.Pow(10, keta + 2) + (idx * 100) + 1;
                    btnExecShukko.Enabled = button14.Enabled;
                }
            }
            catch (Exception ex)
            {
                con.Rollback();
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
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

            ((BaseCalendar)inputPanel.Controls["txtHYMD"]).Text = ((BaseCalendar)c.Controls["txtHYMD"]).Text;
            ((LabelSet_Tantousha)inputPanel.Controls["lsHSha"]).CodeTxtText = ((LabelSet_Tantousha)c.Controls["lsHSha"]).CodeTxtText;
            ((TextSet_Torihikisaki)inputPanel.Controls["lsShiire"]).CodeTxtText = "";
            ((BaseTextMoney)inputPanel.Controls["txtHNo"]).Text = "";
            ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).CodeTxtText = ((LabelSet_Daibunrui)c.Controls["lsDaibun"]).CodeTxtText;
            ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).chkTxtDaibunrui();
            ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).CodeTxtText = ((LabelSet_Chubunrui)c.Controls["lsChubun"]).CodeTxtText;
            ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).chkTxtChubunrui(((LabelSet_Daibunrui)c.Controls["lsDaibun"]).CodeTxtText);
            ((LabelSet_Maker)inputPanel.Controls["lsMaker"]).CodeTxtText = ((LabelSet_Maker)c.Controls["lsMaker"]).CodeTxtText;
            ((BaseText)inputPanel.Controls["txtHinmei"]).Text = ((BaseText)c.Controls["txtHinmei"]).Text;
            ((BaseLabelGray)inputPanel.Controls["txtTanabanL"]).Text = ((BaseLabelGray)c.Controls["txtTanabanL"]).Text;
            ((BaseLabelGray)inputPanel.Controls["txtTanabanR"]).Text = ((BaseLabelGray)c.Controls["txtTanabanR"]).Text;
            ((BaseTextMoney)inputPanel.Controls["txtSuryo"]).Text = ((BaseTextMoney)c.Controls["txtSuryo"]).Text;
            ((BaseTextMoney)inputPanel.Controls["txtTanka"]).Text = ((BaseTextMoney)c.Controls["txtTanka"]).Text;
            ((BaseCalendar)inputPanel.Controls["txtNohki"]).Text = "";
            ((BaseText)inputPanel.Controls["txtChuban"]).Text = ((BaseText)c.Controls["txtChuban"]).Text;

            ((BaseCalendar)inputPanel.Controls["tmpHYMD"]).Text = ((BaseCalendar)c.Controls["txtHYMD"]).Text;
            ((BaseText)inputPanel.Controls["tmpHSha"]).Text = ((LabelSet_Tantousha)c.Controls["lsHSha"]).CodeTxtText;
            ((BaseText)inputPanel.Controls["tmpShiire"]).Text = "";
            ((BaseText)inputPanel.Controls["tmpSName"]).Text = "";
            ((BaseTextMoney)inputPanel.Controls["tmpHNo"]).Text = "";
            ((BaseText)inputPanel.Controls["tmpDaibun"]).Text = ((LabelSet_Daibunrui)c.Controls["lsDaibun"]).CodeTxtText;
            ((BaseText)inputPanel.Controls["tmpChubun"]).Text = ((LabelSet_Chubunrui)c.Controls["lsChubun"]).CodeTxtText;
            ((BaseText)inputPanel.Controls["tmpMaker"]).Text = ((LabelSet_Maker)c.Controls["lsMaker"]).CodeTxtText;
            ((BaseText)inputPanel.Controls["tmpHinmei"]).Text = ((BaseText)c.Controls["txtHinmei"]).Text;
            ((BaseTextMoney)inputPanel.Controls["tmpSuryo"]).Text = ((BaseTextMoney)c.Controls["txtSuryo"]).Text;
            ((BaseTextMoney)inputPanel.Controls["tmpTanka"]).Text = ((BaseTextMoney)c.Controls["txtTanka"]).Text;
            ((BaseCalendar)inputPanel.Controls["tmpNohki"]).Text = "";
            ((BaseText)inputPanel.Controls["tmpChuban"]).Text = ((BaseText)c.Controls["txtChuban"]).Text;

            ((BaseText)inputPanel.Controls["txtC1"]).Text = ((BaseText)c.Controls["txtC1"]).Text;
            ((BaseText)inputPanel.Controls["txtC2"]).Text = ((BaseText)c.Controls["txtC2"]).Text;
            ((BaseText)inputPanel.Controls["txtC3"]).Text = ((BaseText)c.Controls["txtC3"]).Text;
            ((BaseText)inputPanel.Controls["txtC4"]).Text = ((BaseText)c.Controls["txtC4"]).Text;
            ((BaseText)inputPanel.Controls["txtC5"]).Text = ((BaseText)c.Controls["txtC5"]).Text;
            ((BaseText)inputPanel.Controls["txtC6"]).Text = ((BaseText)c.Controls["txtC6"]).Text;
            ((BaseText)inputPanel.Controls["txtShohin"]).Text = ((BaseText)c.Controls["txtShohin"]).Text;
            ((BaseText)inputPanel.Controls["txtShiireSu"]).Text = ((BaseText)c.Controls["txtShiireSu"]).Text;
            ((BaseText)inputPanel.Controls["txtShiireBi"]).Text = ((BaseText)c.Controls["txtShiireBi"]).Text;
            ((BaseText)inputPanel.Controls["txtKataban"]).Text = ((BaseText)c.Controls["txtKataban"]).Text;
            ((BaseText)inputPanel.Controls["notNewPanel"]).Text = "0";

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

            A0024_KakohinJuchuInput_B kakoB = new A0024_KakohinJuchuInput_B();

            DBConnective con = new DBConnective();
            try
            {
                if (string.IsNullOrWhiteSpace(((BaseTextMoney)c.Controls["txtHNo"]).Text))
                {
                    return;
                }
                DataTable dtS = kakoB.getShiire(((BaseTextMoney)c.Controls["txtHNo"]).Text);
                if (dtS != null && dtS.Rows.Count > 0)
                {
                    ((BaseTextMoney)inputPanel.Controls["txtHNo"]).Text = kakoB.getDenpyoNo("出庫伝票", con);
                    ((BaseTextMoney)inputPanel.Controls["tmpHNo"]).Text = ((BaseTextMoney)inputPanel.Controls["txtHNo"]).Text;

                    Button btnExecKako = new Button();
                    btnExecKako.Text = "加工品発注実行";
                    btnExecKako.Width = 100;
                    btnExecKako.Tag = cats[5];
                    inputPanel.Controls.Add(btnExecKako);
                    btnExecKako.Click += new EventHandler(btnExecKako_Click);
                    btnExecKako.Location = new Point(1000, 105);
                    btnExecKako.BringToFront();
                    btnExecKako.Name = "btnAddShukko";
                    btnExecKako.TabIndex = (int)Math.Pow(10, keta + 2) + (idx * 100) + 1;
                    btnExecKako.Enabled = button14.Enabled;
                }
            }
            catch (Exception ex)
            {
                con.Rollback();
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
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


            DBConnective con = new DBConnective();
            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
            try
            {
                bool flg = true;
                Button b = (Button)sender;

                Panel p = (Panel)b.Parent;
                string sLbl = ((Label)p.Controls["cate"]).Text;

                BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "取消", "この" + sLbl + "を取り消しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessageboxSa.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                //tableLayoutPanel1.Controls.Remove(b.Parent);
                TableLayoutControlCollection c = tableLayoutPanel1.Controls;

                con.BeginTrans();
                if ((int)b.Tag == cats[0] || (int)b.Tag == cats[2])
                {
                    Control[] cs = c.Find("basePanel" + (int.Parse((String)b.Parent.Tag) + 1).ToString(zeroPad), false);
                    if (cs != null && cs.Length > 0 && cs[0] != null)
                    {
                        if (delKakoJuchuS((Panel)cs[0], juchuB, con, true))
                        {
                            flg = false;
                            c.Remove(cs[0]);
                        }
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
                if (delKakoJuchuS((Panel)b.Parent, juchuB, con, flg))
                {
                    c.Remove(b.Parent);
                    con.Commit();
                    BaseMessageBox basemessage = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessage.ShowDialog();
                }

                a0010JInput.cbSiireTanka.Text = updTanka(a0010JInput.txtJuchuSuryo.Text);

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
            catch (Exception ex)
            {
                con.Rollback();
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
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
                ((TextSet_Torihikisaki)inputPanel.Controls["lsShiire"]).CodeTxtText = r["仕入先コード"].ToString();
                ((TextSet_Torihikisaki)inputPanel.Controls["lsShiire"]).chkTxtTorihikisaki();
                //((TextSet_Torihikisaki)inputPanel.Controls["lsShiire"]).valueTextText = r["仕入先名"].ToString();
                ((BaseTextMoney)inputPanel.Controls["txtHNo"]).Text = r["発注番号"].ToString();
                ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).CodeTxtText = r["大分類コード"].ToString();
                ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).chkTxtDaibunrui();
                ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).CodeTxtText = r["中分類コード"].ToString();
                ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).chkTxtChubunrui(((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).CodeTxtText);
                ((LabelSet_Maker)inputPanel.Controls["lsMaker"]).CodeTxtText = r["メーカーコード"].ToString();
                ((BaseText)inputPanel.Controls["txtHinmei"]).Text = r["品名"].ToString();
                ((BaseLabelGray)inputPanel.Controls["txtTanabanL"]).Text = r["棚番本社"].ToString();
                ((BaseLabelGray)inputPanel.Controls["txtTanabanR"]).Text = r["棚番岐阜"].ToString();
                ((BaseText)inputPanel.Controls["txtHXXX"]).Text = r["表注番"].ToString();

                if (!((TextSet_Torihikisaki)inputPanel.Controls["lsShiire"]).valueTextText.Equals(r["仕入先名"].ToString()))
                {
                    ((TextSet_Torihikisaki)inputPanel.Controls["lsShiire"]).valueTextText = r["仕入先名"].ToString();
                }

                decimal dSu = 0;
                string stSu = "";
                if (r["発注数量"] != null && r["発注数量"] != DBNull.Value && !string.IsNullOrWhiteSpace(r["発注数量"].ToString()))
                {
                    dSu = getDecValue(r["発注数量"].ToString());
                    stSu = (decimal.Round(dSu, 0)).ToString("#,0");
                }

                decimal dTanka = 0;
                string stTanka = "";
                if (r["発注単価"] != null && r["発注単価"] != DBNull.Value && !string.IsNullOrWhiteSpace(r["発注単価"].ToString()))
                {
                    dTanka = getDecValue(r["発注単価"].ToString());
                    stTanka = (decimal.Round(dTanka, 2)).ToString("#,0.00");
                }

                ((BaseTextMoney)inputPanel.Controls["txtSuryo"]).Text = stSu;
                ((BaseTextMoney)inputPanel.Controls["txtTanka"]).Text = stTanka;

                ((BaseCalendar)inputPanel.Controls["txtNohki"]).Text = r["納期"].ToString();
                ((BaseText)inputPanel.Controls["txtChuban"]).Text = r["注番"].ToString();
                ((BaseText)inputPanel.Controls["txtEigyo"]).Text = r["営業所コード"].ToString();
                ((BaseText)inputPanel.Controls["txtSouko"]).Text = r["出庫倉庫"].ToString();

                ((RadSet_2btn)inputPanel.Controls["rdSouko"]).radbtn1.Checked = false;
                ((RadSet_2btn)inputPanel.Controls["rdSouko"]).radbtn0.Checked = true;
                if ("0002".Equals(((BaseText)inputPanel.Controls["txtSouko"]).Text))
                {
                    ((RadSet_2btn)inputPanel.Controls["rdSouko"]).radbtn0.Checked = false;
                    ((RadSet_2btn)inputPanel.Controls["rdSouko"]).radbtn1.Checked = true;
                }

                ((BaseCalendar)inputPanel.Controls["tmpHYMD"]).Text = r["発注年月日"].ToString();
                ((BaseText)inputPanel.Controls["tmpHSha"]).Text = r["発注者コード"].ToString();
                ((BaseText)inputPanel.Controls["tmpShiire"]).Text = r["仕入先コード"].ToString();
                ((BaseText)inputPanel.Controls["tmpSName"]).Text = r["仕入先名"].ToString();
                ((BaseTextMoney)inputPanel.Controls["tmpHNo"]).Text = r["発注番号"].ToString();
                ((BaseText)inputPanel.Controls["tmpDaibun"]).Text = r["大分類コード"].ToString();
                ((BaseText)inputPanel.Controls["tmpChubun"]).Text = r["中分類コード"].ToString();
                ((BaseText)inputPanel.Controls["tmpMaker"]).Text = r["メーカーコード"].ToString();
                ((BaseText)inputPanel.Controls["tmpHinmei"]).Text = r["品名"].ToString();
                ((BaseTextMoney)inputPanel.Controls["tmpSuryo"]).Text = ((BaseTextMoney)inputPanel.Controls["txtSuryo"]).Text;
                ((BaseTextMoney)inputPanel.Controls["tmpTanka"]).Text = ((BaseTextMoney)inputPanel.Controls["txtTanka"]).Text;
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
                ((BaseText)inputPanel.Controls["notNewPanel"]).Text = "1";

                if (num == 1)
                {
                    ((BaseCalendar)inputPanel.Controls["txtHYMD"]).ReadOnly = true;
                    ((LabelSet_Tantousha)inputPanel.Controls["lsHSha"]).codeTxt.ReadOnly = true;
                    ((TextSet_Torihikisaki)inputPanel.Controls["lsShiire"]).codeTxt.ReadOnly = true;
                    ((BaseTextMoney)inputPanel.Controls["txtHNo"]).ReadOnly = true;
                    ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).codeTxt.ReadOnly = true;
                    ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).codeTxt.ReadOnly = true;
                    ((LabelSet_Maker)inputPanel.Controls["lsMaker"]).codeTxt.ReadOnly = true;
                    ((BaseText)inputPanel.Controls["txtHinmei"]).ReadOnly = true;
                    ((BaseTextMoney)inputPanel.Controls["txtSuryo"]).ReadOnly = true;
                    ((BaseTextMoney)inputPanel.Controls["txtTanka"]).ReadOnly = true;
                    ((BaseCalendar)inputPanel.Controls["txtNohki"]).ReadOnly = true;
                    ((BaseText)inputPanel.Controls["txtChuban"]).ReadOnly = true;
                    ((BaseText)inputPanel.Controls["txtSearchStr"]).ReadOnly = true;
                }
                else if (num == 2)
                {
                    ((BaseCalendar)inputPanel.Controls["txtHYMD"]).ReadOnly = true;
                    ((LabelSet_Tantousha)inputPanel.Controls["lsHSha"]).codeTxt.ReadOnly = true;
                    ((TextSet_Torihikisaki)inputPanel.Controls["lsShiire"]).codeTxt.ReadOnly = true;
                    ((BaseTextMoney)inputPanel.Controls["txtHNo"]).ReadOnly = true;
                    ((LabelSet_Daibunrui)inputPanel.Controls["lsDaibun"]).codeTxt.ReadOnly = true;
                    ((LabelSet_Chubunrui)inputPanel.Controls["lsChubun"]).codeTxt.ReadOnly = true;
                    ((LabelSet_Maker)inputPanel.Controls["lsMaker"]).codeTxt.ReadOnly = true;
                    ((BaseText)inputPanel.Controls["txtHinmei"]).ReadOnly = true;
                    ((BaseTextMoney)inputPanel.Controls["txtTanka"]).ReadOnly = true;
                    ((BaseText)inputPanel.Controls["txtSearchStr"]).ReadOnly = true;
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
            txtHYMD.Text = DateTime.Now.ToString("yyyy/MM/dd");
            tabIdx++;

            ctl = txtHYMD;

            LabelSet_Tantousha lsHSha = new LabelSet_Tantousha();
            lsHSha.Name = "lsHSha";
            lsHSha.AutoSize = true;
            lsHSha.LabelName = "発注者";
            lsHSha.ShowAppendFlg = false;
            basePanel.Controls.Add(lsHSha);
            lsHSha.Location = new Point(266, 22);
            lsHSha.ValueLabelSize = 126;
            lsHSha.BringToFront();
            lsHSha.TabIndex = tabIdx;
            lsHSha.CodeTxtText = a0010JInput.lsJuchusha.CodeTxtText;
            tabIdx++;

            TextSet_Torihikisaki lsShiire = new TextSet_Torihikisaki();
            lsShiire.Name = "lsShiire";
            lsShiire.AutoSize = true;
            lsShiire.LabelName = "仕入先";
            lsShiire.ShowAppendFlg = false;
            basePanel.Controls.Add(lsShiire);
            lsShiire.Location = new Point(496, 22);
            lsShiire.ValueTextSize = 240;
            lsShiire.SpaceNameCode = 20;
            lsShiire.BringToFront();
            lsShiire.TabIndex = tabIdx;
            tabIdx++;

            BaseLabel lblHNo = new BaseLabel();
            lblHNo.AutoSize = true;
            //lblHNo.BackColor = Color.Transparent;
            lblHNo.Text = "発注番号";
            basePanel.Controls.Add(lblHNo);
            lblHNo.Location = new Point(869, 22);
            lblHNo.BringToFront();
            lblHNo.TabIndex = tabIdx;
            lblHNo.Visible = false;
            tabIdx++;

            BaseTextMoney txtHNo = new BaseTextMoney();
            txtHNo.Name = "txtHNo";
            txtHNo.Size = new System.Drawing.Size(70, 22);
            basePanel.Controls.Add(txtHNo);
            txtHNo.Location = new Point(962, 19);
            txtHNo.BringToFront();
            txtHNo.Name = "txtHNo";
            txtHNo.Leave += new EventHandler(txtHNo_Leave);
            txtHNo.KeyDown += new KeyEventHandler(baseTexts_KeyDown);
            txtHNo.TabStop = false;
            txtHNo.TabIndex = tabIdx;
            txtHNo.Visible = false;
            tabIdx++;



            BaseLabel lblHXXX = new BaseLabel();
            lblHXXX.AutoSize = true;
            //lblHNo.BackColor = Color.Transparent;
            lblHXXX.Text = "注番";
            basePanel.Controls.Add(lblHXXX);
            lblHXXX.Location = new Point(869, 22);
            lblHXXX.BringToFront();
            lblHXXX.TabIndex = tabIdx;
            lblHXXX.Visible = false;
            tabIdx++;

            BaseText txtHXXX = new BaseText();
            txtHXXX.Name = "txtHXXX";
            txtHXXX.Size = new System.Drawing.Size(86, 22);
            basePanel.Controls.Add(txtHXXX);
            txtHXXX.Location = new Point(962, 19);
            txtHXXX.BringToFront();
            txtHXXX.Name = "txtHXXX";
            txtHXXX.TabStop = false;
            txtHXXX.TabIndex = tabIdx;
            txtHXXX.ReadOnly = true;
            txtHXXX.Visible = false;
            tabIdx++;
            if (cat == cats[0] || cat == cats[2])
            {
                lblHXXX.Visible = true;
                txtHXXX.Visible = true;
            }




            #endregion

            // 2行目
            #region
            LabelSet_Daibunrui lsDaibun = new LabelSet_Daibunrui();
            lsDaibun.Name = "lsDaibun";
            lsDaibun.AutoSize = true;
            //lsDaibun.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lsDaibun.LabelName = "大分類";
            lsDaibun.ShowAppendFlg = false;
            basePanel.Controls.Add(lsDaibun);
            lsDaibun.Location = new Point(36, 49);
            lsDaibun.SpaceNameCode = 6;
            lsDaibun.BringToFront();
            lsDaibun.TabIndex = tabIdx;
            tabIdx++;

            LabelSet_Chubunrui lsChubun = new LabelSet_Chubunrui();
            lsChubun.Name = "lsChubun";
            lsChubun.AutoSize = true;
            //lsChubun.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lsChubun.LabelName = "中分類";
            lsChubun.ShowAppendFlg = false;
            basePanel.Controls.Add(lsChubun);
            lsChubun.Location = new Point(266, 49);
            lsChubun.BringToFront();
            lsChubun.TabIndex = tabIdx;
            tabIdx++;

            LabelSet_Maker lsMaker = new LabelSet_Maker();
            lsMaker.Name = "lsMaker";
            lsMaker.AutoSize = true;
            //lsMaker.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lsMaker.LabelName = "メーカー";
            lsMaker.ShowAppendFlg = false;
            basePanel.Controls.Add(lsMaker);
            lsMaker.Location = new Point(496, 49);
            lsMaker.BringToFront();
            lsMaker.TabIndex = tabIdx;
            tabIdx++;

            lsDaibun.Lschubundata = lsChubun;
            lsDaibun.Lsmakerdata = lsMaker;

            BaseLabel lblSearchStr = new BaseLabel();
            lblSearchStr.AutoSize = true;
            //lblSearchStr.BackColor = Color.Transparent;
            lblSearchStr.Text = "検索文字列";
            basePanel.Controls.Add(lblSearchStr);
            lblSearchStr.Location = new Point(869, 52);
            lblSearchStr.BringToFront();

            BaseText txtSearchStr = new BaseText();
            txtSearchStr.Name = "txtSearchStr";
            txtSearchStr.Size = new System.Drawing.Size(271, 22);
            basePanel.Controls.Add(txtSearchStr);
            txtSearchStr.Location = new Point(962, 49);
            txtSearchStr.BringToFront();
            txtSearchStr.Name = "txtSearchStr";
            txtSearchStr.TabIndex = tabIdx;
            tabIdx++;
            txtSearchStr.Leave += new EventHandler(txtSearchStr_Leave);
            txtSearchStr.KeyDown += new KeyEventHandler(txtSearchStr_KeyDown);
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

            BaseText txtHinmei = new BaseText();
            txtHinmei.Name = "txtHinmei";
            txtHinmei.Size = new System.Drawing.Size(331, 22);
            basePanel.Controls.Add(txtHinmei);
            //txtHinmei.Location = new Point(327, 77);
            txtHinmei.Location = new Point(97, 77);
            txtHinmei.BringToFront();
            txtHinmei.Name = "txtHinmei";
            txtHinmei.KeyDown += new KeyEventHandler(baseTexts_KeyDown);
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
            txtHinmeiY.KeyDown += new KeyEventHandler(baseTexts_KeyDown);
            txtHinmeiY.TabIndex = tabIdx;
            tabIdx++;
            txtHinmeiY.Visible = false;

            BaseLabel lblTanaban = new BaseLabel();
            lblTanaban.AutoSize = true;
            //lblTanaban.BackColor = Color.Transparent;
            lblTanaban.Text = "棚番";
            basePanel.Controls.Add(lblTanaban);
            //lblTanaban.Location = new Point(841, 80);
            //lblTanaban.Location = new Point(617, 80);
            lblTanaban.Location = new Point(571, 80);
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
            //txtTanabanL.Location = new Point(661, 77);
            txtTanabanL.Location = new Point(615, 77);
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
            //txtTanabanR.Location = new Point(723, 77);
            txtTanabanR.Location = new Point(677, 77);
            txtTanabanR.BringToFront();
            txtTanabanR.Name = "txtTanabanR";
            txtTanabanR.TabStop = false;

            BaseLabel lblSouko = new BaseLabel();
            lblSouko.AutoSize = true;
            //lblTanaban.BackColor = Color.Transparent;
            lblSouko.Text = "出庫倉庫";
            basePanel.Controls.Add(lblSouko);
            //lblTanaban.Location = new Point(841, 80);
            //lblTanaban.Location = new Point(617, 80);
            lblSouko.Location = new Point(869, 80);
            lblSouko.BringToFront();
            lblSouko.Visible = false;

            RadSet_2btn rdSouko = new RadSet_2btn();
            rdSouko.Width = 125;
            rdSouko.Height = 15;
            rdSouko.PositionRadbtn1_X = 0;
            rdSouko.PositionRadbtn2_X = 70;
            rdSouko.LabelTitle = "";
            rdSouko.Radbtn1Text = "本社";
            rdSouko.Radbtn2Text = "岐阜";
            basePanel.Controls.Add(rdSouko);
            rdSouko.Location = new Point(962, 80);
            rdSouko.Name = "rdSouko";
            rdSouko.BringToFront();
            rdSouko.Visible = false;

            rdSouko.radbtn1.Checked = false;
            rdSouko.radbtn0.Checked = false;

            if (cat == cats[1] || cat == cats[3] || cat == cats[4] || cat == cats[5])
            {
                lblSouko.Visible = true;
                rdSouko.Visible = true;
            }

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
            txtSuryo.intIntederSet = 12;
            txtSuryo.KeyDown += new KeyEventHandler(baseTexts_KeyDown);
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
            txtTanka.intDeciSet = 2;
            txtTanka.intIntederSet = 12;
            txtTanka.KeyDown += new KeyEventHandler(baseTexts_KeyDown);
            txtTanka.TabIndex = tabIdx;
            tabIdx++;

            BaseLabel lblNohki = new BaseLabel();
            lblNohki.AutoSize = true;
            //lblNohki.BackColor = Color.Transparent;
            lblNohki.Text = labelsNohki[cat];
            basePanel.Controls.Add(lblNohki);
            if (cat == cats[1] || cat == cats[3] || cat == cats[4] || cat == cats[5])
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
            lblChuban.Text = "備考";
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
            txtChuban.KeyDown += new KeyEventHandler(baseTexts_KeyDown);

            txtChuban.TabIndex = tabIdx;
            tabIdx++;

            if (cat == cats[1])
            {
                Button btnExecShukko = new Button();
                btnExecShukko.Text = "出庫実行";
                btnExecShukko.Tag = cat;
                basePanel.Controls.Add(btnExecShukko);
                btnExecShukko.Click += new EventHandler(btnExecShukko_Click);
                btnExecShukko.Location = new Point(1000, 105);
                btnExecShukko.BringToFront();
                btnExecShukko.Name = "btnAddShukko";
                btnExecShukko.TabIndex = tabIdx;
                tabIdx++;
                btnExecShukko.Enabled = button14.Enabled;
            }
            else if (cat == cats[2])
            {
                Button btnExecKako = new Button();
                btnExecKako.Text = "加工品発注実行";
                btnExecKako.Width = 100;
                btnExecKako.Tag = cat;
                basePanel.Controls.Add(btnExecKako);
                btnExecKako.Click += new EventHandler(btnExecKako_Click);
                btnExecKako.Location = new Point(1000, 105);
                btnExecKako.BringToFront();
                btnExecKako.Name = "btnAddShukko";
                btnExecKako.TabIndex = tabIdx;
                tabIdx++;
                btnExecKako.Enabled = button14.Enabled;
            }
            else if (cat == cats[3])
            {
                Button btnExecKakoShukko = new Button();
                btnExecKakoShukko.Text = "加工品出庫実行";
                btnExecKakoShukko.Width = 100;
                btnExecKakoShukko.Tag = cat;
                basePanel.Controls.Add(btnExecKakoShukko);
                btnExecKakoShukko.Click += new EventHandler(btnExecKakoShukko_Click);
                btnExecKakoShukko.Location = new Point(1000, 105);
                btnExecKakoShukko.BringToFront();
                btnExecKakoShukko.Name = "btnAddShukko";
                btnExecKakoShukko.TabIndex = tabIdx;
                tabIdx++;
                btnExecKakoShukko.Enabled = button14.Enabled;
            }

            if (cat == cats[0])
            {
                Button btnAddShukko = new Button();
                btnAddShukko.Text = "出庫入力";
                btnAddShukko.Tag = cat;
                basePanel.Controls.Add(btnAddShukko);
                btnAddShukko.Click += new EventHandler(btnAddShukko_Click);
                btnAddShukko.Location = new Point(1176, 105);
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
                    btnAddShukko.Text = "加工品出庫入力";
                    btnAddShukko.Width = 100;
                    btnAddShukko.Tag = cat;
                    basePanel.Controls.Add(btnAddShukko);
                    btnAddShukko.Click += new EventHandler(btnAddKakoShukko_Click);
                    btnAddShukko.Location = new Point(1176, 105);
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
                        btnAddShukko.Text = "加工品出庫入力";
                        btnAddShukko.Width = 100;
                        btnAddShukko.Tag = cat;
                        basePanel.Controls.Add(btnAddShukko);
                        btnAddShukko.Click += new EventHandler(btnAddKakoShukko_Click);
                        btnAddShukko.Location = new Point(1176, 105);
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
                lsShiire.valueTextText = a0010JInput.tsShiiresaki.valueTextText;
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
            BaseText tmpSName = new BaseText();
            tmpSName.Name = "tmpSName";
            basePanel.Controls.Add(tmpSName);
            tmpSName.SendToBack();
            tmpSName.Visible = false;
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
            txtEigyo.Text = strEigyoCd;
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
            //txtShohin.TextChanged += new EventHandler(shohinChangeSub);

            BaseText txtSouko = new BaseText();
            txtSouko.Name = "txtSouko";
            basePanel.Controls.Add(txtSouko);
            txtSouko.Text = strEigyoCd;
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

            BaseText notNewPanel = new BaseText();
            notNewPanel.Name = "notNewPanel";
            basePanel.Controls.Add(notNewPanel);
            notNewPanel.SendToBack();
            notNewPanel.Visible = false;

            #endregion

            return basePanel;
        }

        private void btnExecShukko_Click(object sender, EventArgs e)
        {
            bool judge = false;

            A0024_KakohinJuchuInput_B kakoB = new A0024_KakohinJuchuInput_B();
            BaseMessageBox basemessagebox;

            DBConnective con = new DBConnective();
            try
            {
                Button t = (Button)sender;
                Panel c = (Panel)t.Parent;

                string stNo = ((BaseTextMoney)c.Controls["txtHNo"]).Text;

                if (string.IsNullOrWhiteSpace(stNo))
                {
                    return;
                }

                DataTable dLap = kakoB.getOverlapShukko(stNo, "41");

                if (dLap != null && dLap.Rows.Count > 0)
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "既に出庫済です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                string stShi = ((BaseTextMoney)c.Controls["txtHNo"]).Text;

                string sSouko = ((BaseText)c.Controls["txtSouko"]).Text;

                int jud = ((RadSet_2btn)c.Controls["rdSouko"]).judCheckBtn();
                if (jud == 1 || ((RadSet_2btn)c.Controls["rdSouko"]).radbtn1.Checked)
                {
                    sSouko = "0002";
                }
                else
                {
                    sSouko = "0001";
                }

                DataTable dtZaiko = kakoB.getZaiko(sSouko, ((BaseText)c.Controls["txtShohin"]).Text);

                decimal decZaikoSu = 0;
                decimal decSu = decimal.Parse(((BaseTextMoney)c.Controls["txtSuryo"]).Text);

                if (dtZaiko != null && dtZaiko.Rows.Count > 0)
                {
                    decZaikoSu = getDecValue(dtZaiko.Rows[0]["在庫数"].ToString());

                    if (decZaikoSu < decSu)
                    {
                        basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫数が在庫数を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        return;
                    }
                }

                BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "出庫", "出庫を行いますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessageboxSa.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                string stH = kakoB.getExecHatchu(stNo, "41");

                // 出庫スタート（発注が無い）場合は実行可能
                if (string.IsNullOrWhiteSpace(stH))
                {
                    judge = true;
                }
                // 発注がある場合、仕入があれば可能
                else
                {
                    DataTable dtS = kakoB.getShiire(stH);
                    if (dtS != null && dtS.Rows.Count > 0)
                    {
                        judge = true;
                    }
                }

                if (judge)
                {
                    DataTable dt = kakoB.getHonShukko(stNo, "41");
                    con.BeginTrans();
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        updKakoInputS(c, kakoB, con, true);
                    }
                    kakoB.execShukko(stNo, con);
                    con.Commit();
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "正常に登録されました", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                    return;
                }
                else
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "仕入処理を先に行ってください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }
            }
            catch (Exception ex)
            {
                con.Rollback();
                new CommonException(ex);
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void btnExecKako_Click(object sender, EventArgs e)
        {
            bool judge = false;

            A0024_KakohinJuchuInput_B kakoB = new A0024_KakohinJuchuInput_B();
            BaseMessageBox basemessagebox;

            DBConnective con = new DBConnective();
            try
            {
                if (string.IsNullOrWhiteSpace(strJuchuNo))
                {
                    return;
                }

                Button t = (Button)sender;
                Panel c = (Panel)t.Parent;

                string stC1 = ((BaseText)c.Controls["txtC1"]).Text;
                string stC2 = ((BaseText)c.Controls["txtC2"]).Text;
                string stC3 = ((BaseText)c.Controls["txtC3"]).Text;
                string stC4 = ((BaseText)c.Controls["txtC4"]).Text;
                string stC5 = ((BaseText)c.Controls["txtC5"]).Text;
                string stC6 = ((BaseText)c.Controls["txtC6"]).Text;
                string stC = (stC1 + " " + stC2 + " " + stC3 + " " + stC4 + " " + stC5 + " " + stC6 + " ").Trim();
                string stNo = ((BaseTextMoney)c.Controls["txtHNo"]).Text;

                if (string.IsNullOrWhiteSpace(stNo))
                {
                    stNo = kakoB.getDenpyoNo("発注番号", con);
                    ((BaseTextMoney)c.Controls["txtHNo"]).Text = stNo;
                }

                DataTable dLap = kakoB.getHachu(stNo);

                if (dLap != null && dLap.Rows.Count > 0)
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "既に発注済です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "本加工発注", "発注を行いますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessageboxSa.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                DataTable dt = kakoB.getExecKako(strJuchuNo, stC);
                if (dt != null && dt.Rows.Count > 0)
                {
                    judge = true;
                }

                if (judge)
                {
                    DataTable dtK = kakoB.getHonKako(stNo);
                    con.BeginTrans();
                    if (dtK == null || dtK.Rows.Count == 0)
                    {
                        updKakoInputS(c, kakoB, con, true);
                    }
                    kakoB.execKako(stNo, con);
                    con.Commit();

                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "正常に登録されました", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                    return;
                }
                else
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "出庫処理を先に行ってください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }
            }
            catch (Exception ex)
            {
                con.Rollback();
                new CommonException(ex);
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void btnExecKakoShukko_Click(object sender, EventArgs e)
        {
            bool judge = false;

            A0024_KakohinJuchuInput_B kakoB = new A0024_KakohinJuchuInput_B();
            BaseMessageBox basemessagebox;

            DBConnective con = new DBConnective();
            try
            {
                Button t = (Button)sender;
                Panel c = (Panel)t.Parent;

                string stNo = ((BaseTextMoney)c.Controls["txtHNo"]).Text;
                string stC1 = ((BaseText)c.Controls["txtC1"]).Text;
                string stC2 = ((BaseText)c.Controls["txtC2"]).Text;
                string stC3 = ((BaseText)c.Controls["txtC3"]).Text;
                string stC4 = ((BaseText)c.Controls["txtC4"]).Text;
                string stC5 = ((BaseText)c.Controls["txtC5"]).Text;
                string stC6 = ((BaseText)c.Controls["txtC6"]).Text;
                string stC = (stC1 + " " + stC2 + " " + stC3 + " " + stC4 + " " + stC5 + " " + stC6 + " ").Trim();

                if (string.IsNullOrWhiteSpace(stNo))
                {
                    return;
                }

                DataTable dLap = kakoB.getOverlapShukko(stNo, "43");

                if (dLap != null && dLap.Rows.Count > 0)
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "既に出庫済です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                string sSouko = ((BaseText)c.Controls["txtSouko"]).Text;

                int jud = ((RadSet_2btn)c.Controls["rdSouko"]).judCheckBtn();
                if (jud == 1 || ((RadSet_2btn)c.Controls["rdSouko"]).radbtn1.Checked)
                {
                    sSouko = "0002";
                }
                else
                {
                    sSouko = "0001";
                }

                DataTable dtZaiko = kakoB.getZaiko(sSouko, ((BaseText)c.Controls["txtShohin"]).Text);

                decimal decZaikoSu = 0;
                decimal decSu = decimal.Parse(((BaseTextMoney)c.Controls["txtSuryo"]).Text);

                if (dtZaiko != null && dtZaiko.Rows.Count > 0)
                {
                    decZaikoSu = getDecValue(dtZaiko.Rows[0]["在庫数"].ToString());

                    if (decZaikoSu < decSu)
                    {
                        basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫数が在庫数を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        return;
                    }
                }

                BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "加工品出庫", "出庫を行いますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessageboxSa.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                string stH = kakoB.getExecShukko(stNo, "43", stC);

                if (!string.IsNullOrWhiteSpace(stH))
                {
                    judge = true;
                }

                if (judge)
                {
                    DataTable dt = kakoB.getHonShukko(stNo, "43");
                    con.BeginTrans();
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        updKakoInputS(c, kakoB, con, true);
                    }
                    kakoB.execShukko(stNo, con);
                    con.Commit();
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "正常に登録されました", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                    return;
                }
                else
                {
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "仕入処理を先に行ってください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }
            }
            catch (Exception ex)
            {
                con.Rollback();
                new CommonException(ex);
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
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

        private void shohinChangeSub(string stShoCd, Panel cc)
        {
            //string stShoCd = ((BaseText)sender).Text;
            if (string.IsNullOrWhiteSpace(strJuchuNo) || string.IsNullOrWhiteSpace(stShoCd))
            {
                return;
            }

            //Panel cc = (Panel)((BaseText)sender).Parent;

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
                            decimal dTanka = 0;
                            string stTanka = "";
                            if (dtS.Rows[0]["発注単価"] != null && dtS.Rows[0]["発注単価"] != DBNull.Value && !string.IsNullOrWhiteSpace(dtS.Rows[0]["発注単価"].ToString()))
                            {
                                dTanka = getDecValue(dtS.Rows[0]["発注単価"].ToString());
                                stTanka = (decimal.Round(dTanka, 0)).ToString("#,0.00");
                            }
                            ((BaseTextMoney)cc.Controls["txtTanka"]).Text = stTanka;
                        }
                        else
                        {
                            DataTable dtT = juchuB.getKinShiireTanka(stShoCd);
                            if (dtT != null && dtT.Rows.Count > 0)
                            {
                                decimal dTanka = 0;
                                string stTanka = "";
                                if (dtT.Rows[0]["仕入単価"] != null && dtT.Rows[0]["仕入単価"] != DBNull.Value && !string.IsNullOrWhiteSpace(dtT.Rows[0]["仕入単価"].ToString()))
                                {
                                    dTanka = getDecValue(dtT.Rows[0]["仕入単価"].ToString());
                                    stTanka = (decimal.Round(dTanka, 0)).ToString("#,0.00");
                                }
                                ((BaseTextMoney)cc.Controls["txtTanka"]).Text = stTanka;
                            }
                        }
                    }
                    else
                    {
                        decimal dTanka = 0;
                        string stTanka = "";
                        if (dt.Rows[0]["仕入単価"] != null && dt.Rows[0]["仕入単価"] != DBNull.Value && !string.IsNullOrWhiteSpace(dt.Rows[0]["仕入単価"].ToString()))
                        {
                            dTanka = getDecValue(dt.Rows[0]["仕入単価"].ToString());
                            stTanka = (decimal.Round(dTanka, 0)).ToString("#,0.00");
                        }
                        ((BaseTextMoney)cc.Controls["txtTanka"]).Text = stTanka;
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
        private bool delKakoJuchuS(Panel c, A0024_KakohinJuchuInput_B juchuB, DBConnective con, bool f)
        {
            //if (c.Controls["notNewPanel"] == null || ((BaseText)c.Controls["notNewPanel"]) == null)
            //{
            //    return true;
            //}
            //// 新規生成したパネルはDBに値が無いため削除処理をスキップ
            //if (string.IsNullOrWhiteSpace(((BaseText)c.Controls["notNewPanel"]).Text) || !((BaseText)c.Controls["notNewPanel"]).Text.Equals("1"))
            //{
            //    return true;
            //}

            strHachuNo = ((BaseTextMoney)c.Controls["txtHNo"]).Text;

            if (string.IsNullOrWhiteSpace(strHachuNo))
            {
                return true;
            }

            string cate = ((Label)c.Controls["cate"]).Text;
            bool hatchuFlg = false;

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
                        return false;
                    }
                }

                string strFlg = juchuB.getZaikoHikiateFlg(strJuchuNo);
                if (strFlg.Equals("1"))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "在庫が既に移動処理されています。変更・削除は禁止です", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return false;
                }

                strFlg = juchuB.getShukkoFlg(strJuchuNo);
                if (strFlg.Equals("1"))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "在庫が既に移動処理されています。変更・削除は禁止です", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return false;
                }
                if (f == true)
                {
                    BaseMessageBox basemessageboxSa = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                    //NOが押された場合
                    if (basemessageboxSa.ShowDialog() == DialogResult.No)
                    {
                        return false;
                    }
                }
                juchuB.delHachuS(strHachuNo, Environment.UserName, con, hatchuFlg);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 加工品登録
        public void updKakoInput(DBConnective con)
        {
            //if (!chkData())
            //{
            //    return;
            //}
            string strShoCd = "88888";
            decimal JucyuKin = 0;

            if (!string.IsNullOrWhiteSpace(strShohin))
            {
                strShoCd = strShohin;
            }

            BaseMessageBox basemessagebox;
            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();

            try
            {
                //con.DB_Connect();
                //con.BeginTrans();

                TableLayoutControlCollection c = tableLayoutPanel1.Controls;
                foreach (Control cc in c)
                {
                    updKakoInputS((Panel)cc, juchuB, con, true);
                }
                //con.Commit();
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
                //con.DB_Disconnect();
            }

//            basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
//            basemessagebox.ShowDialog();
        }

        private void updKakoInputS(Panel cc, A0024_KakohinJuchuInput_B juchuB, DBConnective con, bool kariFlg)
        {
            //if (!chkData())
            //{
            //    return;
            //}

            string strShoCd = "88888";
            decimal JucyuKin = 0;

            try {
                if (!changeVal((Panel)cc))
                {
                    return;
                }
                // 更新パラメータ取得
                #region
                string sLbl = ((Label)cc.Controls["cate"]).Text;
                string sHSha = ((LabelSet_Tantousha)cc.Controls["lsHSha"]).CodeTxtText;
                string sHYMD = ((BaseCalendar)cc.Controls["txtHYMD"]).Text;
                string sHShiire = ((TextSet_Torihikisaki)cc.Controls["lsShiire"]).CodeTxtText;
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

                int jud = ((RadSet_2btn)cc.Controls["rdSouko"]).judCheckBtn();
                if (jud == 1 || ((RadSet_2btn)cc.Controls["rdSouko"]).radbtn1.Checked)
                {
                    sSouko = "0002";
                }
                else
                {
                    sSouko = "0001";
                }

                string sTmpSu = ((BaseTextMoney)cc.Controls["tmpSuryo"]).Text;
                string sShiireMei = ((TextSet_Torihikisaki)cc.Controls["lsShiire"]).valueTextText;
                string sEigyo = ((BaseText)cc.Controls["txtEigyo"]).Text;
                string sC1 = ((BaseText)cc.Controls["txtC1"]).Text;
                string sC2 = ((BaseText)cc.Controls["txtC2"]).Text;
                string sC3 = ((BaseText)cc.Controls["txtC3"]).Text;
                string sC4 = ((BaseText)cc.Controls["txtC4"]).Text;
                string sC5 = ((BaseText)cc.Controls["txtC5"]).Text;
                string sC6 = ((BaseText)cc.Controls["txtC6"]).Text;
                string sKataban = ((BaseText)cc.Controls["txtKataban"]).Text;
                #endregion
                string shoCd = "88888";
                string shohinCd;

                string strDenpyoNo = null;

                // 発注/本加工
                #region
                if (sLbl.Equals(labels[0]) || sLbl.Equals(labels[2]))
                {
                    if (!string.IsNullOrWhiteSpace(sShohin))
                    {
                        shoCd = sShohin;
                    }
                    string juchuNo = "";
                    if (!string.IsNullOrWhiteSpace(strJuchuNo))
                    {
                        juchuNo = strJuchuNo;
                    }
                    JucyuKin = 0;
                    if (!string.IsNullOrWhiteSpace(sHTanka) && !string.IsNullOrWhiteSpace(sHSu))
                    {
                        JucyuKin = getDecValue(sHTanka) * getDecValue(sHSu);
                    }
                    string kakoKbn = "1";
                    if (sLbl.Equals(labels[0]))
                    {
                        kakoKbn = "0";
                        //kakoKbn = "1";
                    }

                    //if (!string.IsNullOrWhiteSpace(strJuchuNo) && juchuB.judKakohinJuchu(juchuNo))
                    //{
                    //    kakoKbn = "1";
                    //}

                    if (string.IsNullOrWhiteSpace(sHNo))
                    {
                        strDenpyoNo = juchuB.getDenpyoNo("発注番号", con);
                    }
                    else
                    {
                        strDenpyoNo = sHNo;
                    }

                    List<String> aryPrmH = new List<string>();

                    aryPrmH.Add(sHShiire);
                    aryPrmH.Add(sHYMD);
                    aryPrmH.Add(strDenpyoNo);
                    aryPrmH.Add(sHSha);
                    aryPrmH.Add(sEigyo);
                    aryPrmH.Add(sHSha);
                    aryPrmH.Add(juchuNo);
                    aryPrmH.Add("0");
                    aryPrmH.Add("0");
                    aryPrmH.Add(sShohin);
                    aryPrmH.Add(sHMak);
                    aryPrmH.Add(sHDai);
                    aryPrmH.Add(sHChubun);
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

                    // 発注時は無条件で仮・本登録両方を実行
                    if (sLbl.Equals(labels[0]))
                    {
                        juchuB.updJuchuH(aryPrmH, con, false);
                    } else
                    {
                        juchuB.updJuchuH(aryPrmH, con, kariFlg);
                    }

                    // 発注なら在庫数を変更
                    if (sLbl.Equals(labels[0])) {
                        decimal d = getDecValue(sHSu);
                        decimal dTmp = getDecValue(sTmpSu);
                        //juchuB.updZaiko(true, sEigyo, sShohin, (d - dTmp).ToString(), con);
                    }
                    shohinCd = sShohin;
                    ((BaseTextMoney)cc.Controls["txtHNo"]).Text = strDenpyoNo;
                }
                #endregion
                // 出庫/加工品出庫
                #region
                else
                {
                    string kbn = "41";
                    if (sLbl.Equals(labels[3]))
                    {
                        kbn = "43";
                    }

                    if (string.IsNullOrWhiteSpace(sHNo))
                    {
                        strDenpyoNo = juchuB.getDenpyoNo("出庫伝票", con);
                    }
                    else
                    {
                        strDenpyoNo = sHNo;
                    }

                    List<String> aryPrmSH = new List<string>();

                    aryPrmSH.Add(strDenpyoNo);
                    aryPrmSH.Add(sHYMD);
                    aryPrmSH.Add(sHShiire);
                    aryPrmSH.Add(kbn);
                    aryPrmSH.Add(sHSha);
                    aryPrmSH.Add(sEigyo);
                    aryPrmSH.Add(Environment.UserName);
                    aryPrmSH.Add(sShiireMei);

                    juchuB.updShukkoHead(aryPrmSH, con, kariFlg);
                    

                    // 既存商品にない場合は商品を新規登録
                    #region
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
                            aryPrmShohin.Add(sC1);
                            aryPrmShohin.Add(sC2);
                            aryPrmShohin.Add(sC3);
                            aryPrmShohin.Add(sC4);
                            aryPrmShohin.Add(sC5);
                            aryPrmShohin.Add(sC6);
                            aryPrmShohin.Add("Y");
                            aryPrmShohin.Add("0");
                            aryPrmShohin.Add(sHTanka);
                            aryPrmShohin.Add("0");
                            aryPrmShohin.Add("000000");
                            aryPrmShohin.Add("000000");
                            aryPrmShohin.Add("");
                            aryPrmShohin.Add(sHTanka);
                            aryPrmShohin.Add("0");
                            aryPrmShohin.Add("1");
                            aryPrmShohin.Add("0");
                            aryPrmShohin.Add("");
                            aryPrmShohin.Add(Environment.UserName);

                            juchuB.updNewShohin(aryPrmShohin, con);
                        }
                    }
                    else
                    {
                        shohinCd = sShohin;
                    }
                    #endregion

                    string updC1 = "";
                    string updC2 = "";
                    string updC3 = "";
                    string updC4 = "";
                    string updC5 = "";
                    string updC6 = "";

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
                    aryPrmShukko.Add(strDenpyoNo);
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

                    juchuB.updShukkoMeisai(aryPrmShukko, con, kariFlg);
                }
                #endregion
                ((BaseTextMoney)cc.Controls["txtHNo"]).Text = strDenpyoNo;
                ((BaseText)cc.Controls["txtShohin"]).Text = shohinCd;
                ((BaseText)cc.Controls["notNewPanel"]).Text = "1";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 加工品受注検索
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

                    //txtHinmei.Text = strC1 + " " + strC2 + " " + strC3 + " " + strC4 + " " + strC5 + " " + strC6;
                    txtHinmei.Text = strC1; ;

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

                    if (getDecValue(dt.Rows[0]["受注数量"].ToString()).CompareTo(0) != 0 &&  getDecValue(dt.Rows[0]["売上済数量"].ToString()).Equals(getDecValue(dt.Rows[0]["受注数量"].ToString())))
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
                        getZaikoInfo(strShohin);
                        return;
                    }
                    else if (getDecValue(dt.Rows[0]["売上済数量"].ToString()).CompareTo(0) > 0)
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
                        getZaikoInfo(strShohin);
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

                getZaikoInfo(strShohin);

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

        private void getZaikoInfo(string sShohin)
        {
            A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
            try
            {
                DataTable dtZan = juchuB.getZaikoInfo(sShohin);
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
                        ((TextSet_Torihikisaki)c.Controls["lsShiire"]).CodeTxtText = dt.Rows[0]["仕入先コード"].ToString();
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
                        ((TextSet_Torihikisaki)c.Controls["lsShiire"]).CodeTxtText = dt.Rows[0]["仕入先コード"].ToString();
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
                            ((TextSet_Torihikisaki)c.Controls["lsShiire"]).codeTxt.ReadOnly = true;
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
                            ((TextSet_Torihikisaki)c.Controls["lsShiire"]).codeTxt.ReadOnly = false;
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
                        ((TextSet_Torihikisaki)c.Controls["lsShiire"]).codeTxt.ReadOnly = false;
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

            if (sNoki.CompareTo(DateTime.Now.ToString("yyyy/MM/dd")) < 0)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は本日以降に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                ((BaseCalendar)sender).Text = "";
                ((BaseCalendar)sender).Focus();
                return;
            }

            DateTime endDateTime = DateTime.Parse(txtJuchuYMD.Text);
            string strEndDay = endDateTime.AddYears(1).ToString("yyyy/MM/dd");

            if (!string.IsNullOrWhiteSpace(strJuchuNo))
            {
                A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
                try
                {
                    DataTable dtHatchu = juchuB.getShiireSuryouNoki(strJuchuNo);

                    if (dtHatchu != null && dtHatchu.Rows.Count > 0)
                    {
                        String strSuryo = dtHatchu.Rows[0]["仕入済数量"].ToString();
                        if (decimal.Parse(strSuryo).CompareTo(0) > 0)
                        {
                            strEndDay = endDateTime.AddMonths(6).ToString("yyyy/MM/dd");
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

            if (!string.IsNullOrWhiteSpace(sHachu) && !decimal.Parse(sHachu).Equals(0))
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

        public int chkShiire()
        {
            int ret = 0;

            TableLayoutControlCollection c = tableLayoutPanel1.Controls;

            foreach (Control cc in c)
            {
                string sName = ((TextSet_Torihikisaki)cc.Controls["lsShiire"]).valueTextText;

                string sHYMD = ((BaseCalendar)cc.Controls["txtHYMD"]).Text;
                string sHShiire = ((TextSet_Torihikisaki)cc.Controls["lsShiire"]).CodeTxtText;
                string sHSha = ((LabelSet_Tantousha)cc.Controls["lsHSha"]).CodeTxtText;
                string sHDai = ((LabelSet_Daibunrui)cc.Controls["lsDaibun"]).CodeTxtText;
                string sHChubun = ((LabelSet_Chubunrui)cc.Controls["lsChubun"]).CodeTxtText;
                string sHMak = ((LabelSet_Maker)cc.Controls["lsMaker"]).CodeTxtText;
                string sHHin = ((BaseText)cc.Controls["txtHinmei"]).Text;
                string sHSu = ((BaseTextMoney)cc.Controls["txtSuryo"]).Text;
                string sHTanka = ((BaseTextMoney)cc.Controls["txtTanka"]).Text;

                #region
                if (string.IsNullOrWhiteSpace(sHYMD))
                {
                    ((BaseCalendar)cc.Controls["txtHYMD"]).Focus();
                    ret = 1;
                    break;
                }

                if (string.IsNullOrWhiteSpace(sHShiire))
                {
                    ((TextSet_Torihikisaki)cc.Controls["lsShiire"]).Focus();
                    ret = 1;
                    break;
                }

                ((TextSet_Torihikisaki)cc.Controls["lsShiire"]).valueTextText = sName;

                if (string.IsNullOrWhiteSpace(sHSha))
                {
                    ((LabelSet_Tantousha)cc.Controls["lsHSha"]).Focus();
                    ret = 1;
                    break;
                }
                if (string.IsNullOrWhiteSpace(sHMak))
                {
                    ((LabelSet_Maker)cc.Controls["lsMaker"]).Focus();
                    ret = 1;
                    break;
                }
                if (string.IsNullOrWhiteSpace(sHDai))
                {
                    ((LabelSet_Daibunrui)cc.Controls["lsDaibun"]).Focus();
                    ret = 1;
                    break;
                }
                if (string.IsNullOrWhiteSpace(sHChubun))
                {
                    ((LabelSet_Chubunrui)cc.Controls["lsChubun"]).Focus();
                    ret = 1;
                    break;
                }
                if (string.IsNullOrWhiteSpace(sHHin))
                {
                    ((BaseText)cc.Controls["txtHinmei"]).Focus();
                    ret = 1;
                    break;
                }
                #endregion

                DateTime endDateTime = DateTime.Parse(txtJuchuYMD.Text);
                //string strEndDay = endDateTime.AddYears(1).ToString("yyyy/MM/dd");
                string strEndDay = (DateTime.Now.AddMonths(6)).ToString("yyyy/MM/dd");

                if (!string.IsNullOrWhiteSpace(strJuchuNo))
                {
                    A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
                    try
                    {
                        DataTable dtHatchu = juchuB.getShiireSuryouNoki(strJuchuNo);

                        if (dtHatchu != null && dtHatchu.Rows.Count > 0)
                        {
                            String strSuryo = dtHatchu.Rows[0]["仕入済数量"].ToString();
                            if (decimal.Parse(strSuryo).CompareTo(0) > 0)
                            {
                                strEndDay = endDateTime.AddMonths(6).ToString("yyyy/MM/dd");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        new CommonException(ex);
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        throw ex;
                    }
                }

                #region
                if (!changeVal((Panel)cc))
                {
                    continue;
                }
                string sYMD = ((BaseCalendar)cc.Controls["txtNohki"]).Text;

                if (string.IsNullOrWhiteSpace(sYMD))
                {
                    ((BaseCalendar)cc.Controls["txtNohki"]).Focus();
                    ret = 1;
                    break;
                }
                if (sYMD.CompareTo(DateTime.Now.ToString("yyyy/MM/dd")) < 0)
                {
                    ((BaseCalendar)cc.Controls["txtNohki"]).Text = "";
                    ((BaseCalendar)cc.Controls["txtNohki"]).Focus();
                    ret = 2;
                    break;
                }

                string sSuryo = ((BaseTextMoney)cc.Controls["txtSuryo"]).Text;

                if (!string.IsNullOrWhiteSpace(sSuryo) && decimal.Parse(sSuryo) > 0)
                {
                    if (sYMD.CompareTo(strEndDay) > 0)
                    {
                        ((BaseCalendar)cc.Controls["txtNohki"]).Text = "";
                        ((BaseCalendar)cc.Controls["txtNohki"]).Focus();
                        ret = 3;
                        break;
                    }
                }
                if ((((Label)cc.Controls["cate"]).Text).Equals(labels[1]))
                {
                    string sLimit = ((DateTime.Now).AddDays(7)).ToString();

                    //
                    // 暫定
                    // 出庫の7日制限を無視
                    //
                    //if (sYMD.CompareTo(sLimit) > 0)
                    //{
                    //    ((BaseCalendar)cc.Controls["txtNohki"]).Text = "";
                    //    ((BaseCalendar)cc.Controls["txtNohki"]).Focus();
                    //    ret = 4;
                    //    break;
                    //}
                }
                if (string.IsNullOrWhiteSpace(sHSu))
                {
                    ret = 1;
                    ((BaseTextMoney)cc.Controls["txtSuryo"]).Focus();
                    break;
                }
                if (string.IsNullOrWhiteSpace(sHTanka))
                {
                    ret = 1;
                    ((BaseTextMoney)cc.Controls["txtTanka"]).Focus();
                    break;
                }
                #endregion

                if (!((RadSet_2btn)cc.Controls["rdSouko"]).radbtn0.Checked && !((RadSet_2btn)cc.Controls["rdSouko"]).radbtn1.Checked)
                {
                    string cat = ((Label)cc.Controls["cate"]).Text;
                    if (cat.Equals(labels[1]) || cat.Equals(labels[3]) || cat.Equals(labels[4]) || cat.Equals(labels[5]))
                    {
                        ret = 5;
                        break;
                    }
                }
            }

            return ret;
        }

        public bool chkData()
        {
            TableLayoutControlCollection c = tableLayoutPanel1.Controls;
            bool flg = false;
            if (flg == false)
            {
            }

            DateTime endDateTime = DateTime.Parse(txtJuchuYMD.Text);
            string strEndDay = endDateTime.AddYears(1).ToString("yyyy/MM/dd");

            if (!string.IsNullOrWhiteSpace(strJuchuNo))
            {
                A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();
                try
                {
                    DataTable dtHatchu = juchuB.getShiireSuryouNoki(strJuchuNo);

                    if (dtHatchu != null && dtHatchu.Rows.Count > 0)
                    {
                        String strSuryo = dtHatchu.Rows[0]["仕入済数量"].ToString();
                        if (decimal.Parse(strSuryo).CompareTo(0) > 0)
                        {
                            strEndDay = endDateTime.AddMonths(6).ToString("yyyy/MM/dd");
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

            foreach (Control cc in c)
            {
                if (!changeVal((Panel)cc)) {
                    continue;
                }
                string sYMD = ((BaseCalendar)cc.Controls["txtNohki"]).Text;
                if (sYMD.CompareTo(DateTime.Now.ToString("yyyy/MM/dd")) < 0)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は本日以降に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((BaseCalendar)cc.Controls["txtNohki"]).Text = "";
                    ((BaseCalendar)cc.Controls["txtNohki"]).Focus();
                    return false;
                }

                string sSuryo = ((BaseTextMoney)cc.Controls["txtSuryo"]).Text;
                if (!string.IsNullOrWhiteSpace(sSuryo) && !decimal.Parse(sSuryo).Equals(0))
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
                    string sLimit = ((DateTime.Now).AddDays(7)).ToString();

                    //
                    // 暫定
                    // 出庫の7日制限を無視
                    //
                    //if (sYMD.CompareTo(sLimit) < 0)
                    //{

                    //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫予定日は７日以内に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    //    basemessagebox.ShowDialog();
                    //    ((BaseCalendar)cc.Controls["txtNohki"]).Text = "";
                    //    ((BaseCalendar)cc.Controls["txtNohki"]).Focus();
                    //    return false;
                    //}
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
                string sHShiire = ((TextSet_Torihikisaki)cc.Controls["lsShiire"]).CodeTxtText;
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
                string sTmpSu = ((BaseTextMoney)cc.Controls["tmpSuryo"]).Text; 

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
                //if (string.IsNullOrWhiteSpace(sHNo))
                //{
                //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                //    basemessagebox.ShowDialog();
                //    ((BaseTextMoney)cc.Controls["txtHNo"]).Focus();
                //    return false;
                //}
                if (string.IsNullOrWhiteSpace(sHShiire))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    ((TextSet_Torihikisaki)cc.Controls["lsShiire"]).Focus();
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
                if (string.IsNullOrWhiteSpace(sHChubun))
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
                    if (getDecValue(sHTanka).Equals(0))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "単価が￥０です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        ((BaseTextMoney)cc.Controls["txtTanka"]).Focus();
                        return false;
                    }
                }

                if (sLbl.Equals(labels[3]))
                {
                    if (!getDecValue(sHTanka).Equals(0))
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

                // 出庫の場合は、汎用商品コードは禁止
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
                    if (getDecValue(sShiireSu).Equals(0))
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
                if (!"1".Equals(etsuranFlg)) {
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
                }
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
            if (!((BaseCalendar)cc.Controls["txtHYMD"]).Text.Equals(((BaseCalendar)cc.Controls["tmpHYMD"]).Text)) {
                return true;
            }
            if (!((LabelSet_Tantousha)cc.Controls["lsHSha"]).CodeTxtText.Equals(((BaseText)cc.Controls["tmpHSha"]).Text))
            {
                return true;
            }
            if (!((TextSet_Torihikisaki)cc.Controls["lsShiire"]).CodeTxtText.Equals(((BaseText)cc.Controls["tmpShiire"]).Text))
            {
                return true;
            }
            if (!((TextSet_Torihikisaki)cc.Controls["lsShiire"]).valueTextText.Equals(((BaseText)cc.Controls["tmpSName"]).Text))
            {
                return true;
            }
            if (!((BaseTextMoney)cc.Controls["txtHNo"]).Text.Equals(((BaseTextMoney)cc.Controls["tmpHNo"]).Text))
            {
                return true;
            }
            if (!((LabelSet_Daibunrui)cc.Controls["lsDaibun"]).CodeTxtText.Equals(((BaseText)cc.Controls["tmpDaibun"]).Text))
            {
                return true;
            }
            if (!((LabelSet_Chubunrui)cc.Controls["lsChubun"]).CodeTxtText.Equals(((BaseText)cc.Controls["tmpChubun"]).Text))
            {
                return true;
            }
            if (!((LabelSet_Maker)cc.Controls["lsMaker"]).CodeTxtText.Equals(((BaseText)cc.Controls["tmpMaker"]).Text))
            {
                return true;
            }
            if (!((BaseText)cc.Controls["txtHinmei"]).Text.Equals(((BaseText)cc.Controls["tmpHinmei"]).Text))
            {
                return true;
            }
            if (!((BaseTextMoney)cc.Controls["txtSuryo"]).Text.Equals(((BaseTextMoney)cc.Controls["tmpSuryo"]).Text))
            {
                return true;
            }
            if (!((BaseTextMoney)cc.Controls["txtTanka"]).Text.Equals(((BaseTextMoney)cc.Controls["tmpTanka"]).Text))
            {
                return true;
            }
            if (!((BaseCalendar)cc.Controls["txtNohki"]).Text.Equals(((BaseCalendar)cc.Controls["tmpNohki"]).Text))
            {
                return true;
            }
            if (!((BaseText)cc.Controls["txtChuban"]).Text.Equals(((BaseText)cc.Controls["tmpChuban"]).Text))
            {
                return true;
            }
            if (((BaseText)cc.Controls["txtSouko"]).Text.Equals("0001") && (((RadSet_2btn)cc.Controls["rdSouko"]).judCheckBtn() != 0 || ((RadSet_2btn)cc.Controls["rdSouko"]).radbtn1.Checked))
            {
                return true;
            }
            if (((BaseText)cc.Controls["txtSouko"]).Text.Equals("0002") && (((RadSet_2btn)cc.Controls["rdSouko"]).judCheckBtn() != 1 || ((RadSet_2btn)cc.Controls["rdSouko"]).radbtn0.Checked))
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

            if (!string.IsNullOrWhiteSpace(((BaseText)c.Controls["txtSearchStr"]).Text)) {
                getShohinCd(c);
            }
        }

        private void baseTexts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtSearchStr_KeyDown(object sender, KeyEventArgs e)
        {
            BaseText t = (BaseText)sender;
            Panel c = (Panel)t.Parent;

            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(((BaseText)c.Controls["txtSearchStr"]).Text))
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                else
                {
                    getShohinCd(c);
                }
            }
            else if (e.KeyCode == Keys.F9)
            {
                getShohinCd(c);
            }
        }

        //private void txtSearchStr_Leave_1(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtSearchStr.Text) || txtSearchStr.Text.Equals(txtOldStr.Text))
        //    {
        //        return;
        //    }

            //    txtOldStr.Text = txtSearchStr.Text;

            //    getShohinCd(lsDaibunruiM, lsChubunruiM, lsMakerM, txtSearchStr, txtShohinCd, txtHinmei);
            //}

        private void getShohinCd(Panel c)
        {
            KATO.Common.Form.ShouhinList shohinList = new KATO.Common.Form.ShouhinList(this);
            shohinList.intFrmKind = CommonTeisu.FRM_KAKOHINJUCHUINPUT;
            shohinList.blKensaku = false;
            shohinList.lsDaibunrui = (LabelSet_Daibunrui)c.Controls["lsDaibun"];
            shohinList.lsChubunrui = (LabelSet_Chubunrui)c.Controls["lsChubun"];
            shohinList.lsMaker = (LabelSet_Maker)c.Controls["lsMaker"];
            shohinList.btxtKensaku = (BaseText)c.Controls["txtSearchStr"];
            shohinList.btxtShohinCd = (BaseText)c.Controls["txtShohin"];
            //shohinList.btxtHinC1Hinban = (BaseText)c.Controls["txtKataban"];
            shohinList.btxtHinC1Hinban = (BaseText)c.Controls["txtHinmei"];
            shohinList.btxtHinC1 = (BaseText)c.Controls["txtC1"];
            shohinList.btxtHinC2 = (BaseText)c.Controls["txtC2"];
            shohinList.btxtHinC3 = (BaseText)c.Controls["txtC3"];
            shohinList.btxtHinC4 = (BaseText)c.Controls["txtC4"];
            shohinList.btxtHinC5 = (BaseText)c.Controls["txtC5"];
            shohinList.btxtHinC6 = (BaseText)c.Controls["txtC6"];

            if (!String.IsNullOrWhiteSpace(((LabelSet_Daibunrui)c.Controls["lsDaibun"]).CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(((LabelSet_Chubunrui)c.Controls["lsChubun"]).CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(((LabelSet_Maker)c.Controls["lsMaker"]).CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(((BaseText)c.Controls["txtSearchStr"]).Text))
            {
                shohinList.blKensaku = true;
            }

            shohinList.ShowDialog();
            shohinList.Dispose();

            if (!string.IsNullOrWhiteSpace(((BaseText)c.Controls["txtShohin"]).Text))
            {
                ((BaseText)c.Controls["txtSearchStr"]).Text = "";
                getZaikoInfo(((BaseText)c.Controls["txtShohin"]).Text);
                ((BaseTextMoney)c.Controls["txtSuryo"]).Focus();

                shohinChangeSub(((BaseText)c.Controls["txtShohin"]).Text, c);
            }
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
            string ALbl = labels[1];

            TableLayoutControlCollection c = tableLayoutPanel1.Controls;

            // 発注から始まるかチェック
            foreach (Control cc in c)
            {
                string sLbl = ((Label)cc.Controls["cate"]).Text;
                if (sLbl.Equals(labels[0]))
                {
                    ALbl = labels[0];
                    break;
                }
            }

            // 材料発注から始まる場合：　発注＋本加工
            // 材料出庫から始まる場合：　出庫＋本加工
            foreach (Control cc in c)
            {
                string sLbl = ((Label)cc.Controls["cate"]).Text;
                string sHSu = ((BaseTextMoney)cc.Controls["txtSuryo"]).Text;
                string sHTanka = ((BaseTextMoney)cc.Controls["txtTanka"]).Text;

                if (sLbl.Equals(ALbl) || sLbl.Equals(labels[2]))
                {
                    dTotal += getDecValue(sHTanka) * getDecValue(sHSu);
                }
                //if (!sLbl.Equals(labels[0]))
                //{
                //    dTotal += getDecValue(sHTanka) * getDecValue(sHSu);
                //}
            }

            if (!getDecValue(stJSu).Equals(0))
            {
                dTotal = decimal.Round(dTotal / getDecValue(stJSu), 2);
            }

            ret = dTotal.ToString();
            return ret;
        }

        private void btnF12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
