using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.D0360_JuchuzanKakunin;

namespace KATO.Form.D0360_JuchuzanKakunin
{
    public partial class D0360_JuchuzanKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private BaseText bBox = null;
        private bool searchedFlg = false;

        ///<summary>
        ///D0360_JuchuzanKakunin
        ///フォーム初期設定
        ///</summary>
        public D0360_JuchuzanKakunin(Control c)
        {
            // 引数のコントロールが無い場合は画面を開かない
            if (c == null)
            {
                return;
            }

            this._Title = "残確認";
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //フォームの最大化・最小化を禁止
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left;
            this.Top = c.Top;

            //中分類setデータを読めるようにする
            lsDaibunrui.Lschubundata = lsChubunrui;
        }

        public D0360_JuchuzanKakunin(Control c, string stTokuisaki, BaseText baseTxtBox)
        {
            // 引数のコントロールが無い場合は画面を開かない
            if (c == null)
            {
                return;
            }

            this._Title = "残確認";
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //フォームの最大化・最小化を禁止
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;

            //中分類setデータを読めるようにする
            lsDaibunrui.Lschubundata = lsChubunrui;

            this.bBox = baseTxtBox;
            this.lsTokuisaki.CodeTxtText = stTokuisaki;
            this.rsSearchKind.radbtn1.Checked = false;
            this.rsSearchKind.radbtn0.Checked = true;
            //txtJuchuNo.Focus();
            gridZanList.Focus();
            this.selZanList();
            searchedFlg = true;
            
            
        }

        ///<summary>
        ///JuchuzanKakunin_Load
        ///フォームロード
        ///</summary>
        private void JuchuzanKakunin_Load(object sender, EventArgs e)
        {
            btnF01.Text = CommonTeisu.STR_FUNC_F1_HYOJII;
            btnF04.Text = CommonTeisu.STR_FUNC_F4;
            btnF12.Text = CommonTeisu.STR_FUNC_F12;
            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridZanList.AutoGenerateColumns = false;

            //データをバインド
            #region
            DataGridViewTextBoxColumn juchubi = new DataGridViewTextBoxColumn();
            juchubi.DataPropertyName = "受注日";
            juchubi.Name = "受注日";
            juchubi.HeaderText = "受注日";

            DataGridViewTextBoxColumn noki = new DataGridViewTextBoxColumn();
            noki.DataPropertyName = "納期";
            noki.Name = "納期";
            noki.HeaderText = "納期";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー";
            maker.Name = "メーカー";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn hinmei = new DataGridViewTextBoxColumn();
            hinmei.DataPropertyName = "品名";
            hinmei.Name = "品名";
            hinmei.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn juchusu = new DataGridViewTextBoxColumn();
            juchusu.DataPropertyName = "受注数";
            juchusu.Name = "受注数";
            juchusu.HeaderText = "受注数";

            DataGridViewTextBoxColumn juchuzan = new DataGridViewTextBoxColumn();
            juchuzan.DataPropertyName = "受注残";
            juchuzan.Name = "受注残";
            juchuzan.HeaderText = "受注残";

            DataGridViewTextBoxColumn hatchuzan = new DataGridViewTextBoxColumn();
            hatchuzan.DataPropertyName = "発注残";
            hatchuzan.Name = "発注残";
            hatchuzan.HeaderText = "発注残";

            DataGridViewTextBoxColumn uriTanka = new DataGridViewTextBoxColumn();
            uriTanka.DataPropertyName = "売上単価";
            uriTanka.Name = "売上単価";
            uriTanka.HeaderText = "売上単価";

            DataGridViewTextBoxColumn uriKingaku = new DataGridViewTextBoxColumn();
            uriKingaku.DataPropertyName = "売上金額";
            uriKingaku.Name = "売上金額";
            uriKingaku.HeaderText = "売上金額";

            DataGridViewTextBoxColumn siireTanka = new DataGridViewTextBoxColumn();
            siireTanka.DataPropertyName = "仕入単価";
            siireTanka.Name = "仕入単価";
            siireTanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn siireKingaku = new DataGridViewTextBoxColumn();
            siireKingaku.DataPropertyName = "仕入金額";
            siireKingaku.Name = "仕入金額";
            siireKingaku.HeaderText = "仕入金額";

            DataGridViewTextBoxColumn chuban = new DataGridViewTextBoxColumn();
            chuban.DataPropertyName = "注番";
            chuban.Name = "注番";
            chuban.HeaderText = "注番";

            DataGridViewTextBoxColumn siireGokeiKingaku = new DataGridViewTextBoxColumn();
            siireGokeiKingaku.DataPropertyName = "仕入合計金額";
            siireGokeiKingaku.Name = "仕入合計金額";
            siireGokeiKingaku.HeaderText = "仕入合計金額";

            DataGridViewTextBoxColumn kyakusakiChuban = new DataGridViewTextBoxColumn();
            kyakusakiChuban.DataPropertyName = "客先注番";
            kyakusakiChuban.Name = "客先注番";
            kyakusakiChuban.HeaderText = "客先注番";

            DataGridViewTextBoxColumn tokuiName = new DataGridViewTextBoxColumn();
            tokuiName.DataPropertyName = "得意先名";
            tokuiName.Name = "得意先名";
            tokuiName.HeaderText = "得意先名";

            DataGridViewTextBoxColumn siirebi = new DataGridViewTextBoxColumn();
            siirebi.DataPropertyName = "仕入日";
            siirebi.Name = "仕入日";
            siirebi.HeaderText = "仕入日";

            DataGridViewTextBoxColumn siireName = new DataGridViewTextBoxColumn();
            siireName.DataPropertyName = "仕入先名";
            siireName.Name = "仕入先名";
            siireName.HeaderText = "仕入先名";

            DataGridViewTextBoxColumn uriagezumi = new DataGridViewTextBoxColumn();
            uriagezumi.DataPropertyName = "売上済";
            uriagezumi.Name = "売上済";
            uriagezumi.HeaderText = "売上済";

            DataGridViewTextBoxColumn siirezumi = new DataGridViewTextBoxColumn();
            siirezumi.DataPropertyName = "仕入済";
            siirezumi.Name = "仕入済";
            siirezumi.HeaderText = "仕入済";

            DataGridViewTextBoxColumn hatchubi = new DataGridViewTextBoxColumn();
            hatchubi.DataPropertyName = "発注日";
            hatchubi.Name = "発注日";
            hatchubi.HeaderText = "発注日";

            DataGridViewTextBoxColumn jotai = new DataGridViewTextBoxColumn();
            jotai.DataPropertyName = "状態";
            jotai.Name = "状態";
            jotai.HeaderText = "状態";

            DataGridViewTextBoxColumn juchuNo = new DataGridViewTextBoxColumn();
            juchuNo.DataPropertyName = "受注番号";
            juchuNo.Name = "受注番号";
            juchuNo.HeaderText = "受注番号";

            DataGridViewTextBoxColumn juchusha = new DataGridViewTextBoxColumn();
            juchusha.DataPropertyName = "受注者";
            juchusha.Name = "受注者";
            juchusha.HeaderText = "受注者";

            DataGridViewTextBoxColumn tantosha = new DataGridViewTextBoxColumn();
            tantosha.DataPropertyName = "担当者";
            tantosha.Name = "担当者";
            tantosha.HeaderText = "担当者";

            DataGridViewTextBoxColumn hatchusha = new DataGridViewTextBoxColumn();
            hatchusha.DataPropertyName = "発注者";
            hatchusha.Name = "発注者";
            hatchusha.HeaderText = "発注者";
            #endregion

            //バインド、個々の幅、文章の寄せの設定
            #region
            setColumn(juchubi,           DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null,   90);
            setColumn(noki,              DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   90);
            setColumn(maker,             DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   150);
            setColumn(hinmei,            DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   400);
            setColumn(juchusu,           DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",  80);
            setColumn(juchuzan,          DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",  80);
            setColumn(hatchuzan,         DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",  80);
            setColumn(uriTanka,          DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 100);
            setColumn(uriKingaku,        DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",  100);
            setColumn(siireTanka,        DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 100);
            setColumn(siireKingaku,      DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",  100);
            setColumn(chuban,            DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   300);
            setColumn(siireGokeiKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",  140);
            setColumn(kyakusakiChuban,   DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   300);
            setColumn(tokuiName,         DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   150);
            setColumn(siirebi,           DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null,   90);
            setColumn(siireName,         DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   150);
            setColumn(uriagezumi,        DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",  100);
            setColumn(siirezumi,         DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",  100);
            setColumn(hatchubi,          DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null,   90);
            setColumn(jotai,             DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   90);
            setColumn(juchuNo,           DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   100);
            setColumn(juchusha,          DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   100);
            setColumn(tantosha,          DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   100);
            setColumn(hatchusha,         DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   100);
            #endregion
        }

        ///<summary>
        ///setColumn
        ///Grid列設定
        ///</summary>
        private void setColumn (DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridZanList.Columns.Add(col);
            if (gridZanList.Columns[col.Name] != null) {
                gridZanList.Columns[col.Name].Width = intLen;
                gridZanList.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridZanList.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridZanList.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///D0360_JuchuzanKakunin_KeyDown
        ///キー押下処理
        ///</summary>
        private void D0360_JuchuzanKakunin_KeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    break;
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    this.selZanList();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    //印刷
                    //PrintReport();
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        ///<summary>
        ///delText
        ///入力内容クリア
        ///</summary>
        private void delText()
        {
            //フォーム上のデータを白紙
            this.delFormClear(this, gridZanList);

            rsSearchKind.radbtn1.Checked = false;
            rsSearchKind.radbtn0.Checked = true;

            rsGroup.radbtn4.Checked = false;
            rsGroup.radbtn3.Checked = false;
            rsGroup.radbtn2.Checked = false;
            rsGroup.radbtn1.Checked = false;
            rsGroup.radbtn0.Checked = true;

            rsNyukazumi.radbtn2.Checked = false;
            rsNyukazumi.radbtn1.Checked = false;
            rsNyukazumi.radbtn0.Checked = true;

            rsJuchuShubetsu.radbtn2.Checked = false;
            rsJuchuShubetsu.radbtn1.Checked = false;
            rsJuchuShubetsu.radbtn0.Checked = true;

            rsKyoten.radbtn2.Checked = false;
            rsKyoten.radbtn1.Checked = false;
            rsKyoten.radbtn0.Checked = true;

            txtJuchuNo.Focus();
        }

        ///<summary>
        ///D0360_JuchuzanKakunin_KeyDown
        ///ボタン押下処理
        ///</summary>
        private void btnFKeys_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 一覧表示
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    this.selZanList();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F09: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    //this.PrintReport();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        //<summary>
        ///selZanList
        ///残一覧検索実行
        ///</summary>
        private void selZanList()
        {

            string[] listParam = new string[30];

            // パラメータ設定
            setParam(listParam, txtJuchuNo.Text, 0);
            setParam(listParam, txtHachuNo.Text, 1);
            setParam(listParam, txtHinmei.Text, 2);
            setParam(listParam, txtChuban.Text, 3);
            setParam(listParam, txtKyakuChuban.Text, 4);
            setParam(listParam, txtJuchuNokiFrom.Text, 5);
            setParam(listParam, txtJuchuNokiTo.Text, 6);
            setParam(listParam, txtHatchuNokiFrom.Text, 7);
            setParam(listParam, txtHatchuNokiTo.Text, 8);
            setParam(listParam, txtChienFrom.Text, 9);
            setParam(listParam, txtChienTo.Text, 10);
            setParam(listParam, txtJuchubiFrom.Text, 11);
            setParam(listParam, txtJuchubiTo.Text, 12);
            setParam(listParam, txtHatchubiFrom.Text, 13);
            setParam(listParam, txtHatchubiTo.Text, 14);
            setParam(listParam, lsJuchusha.CodeTxtText, 15);
            setParam(listParam, lsHatchusha.CodeTxtText, 16);
            setParam(listParam, lsTantousha.CodeTxtText, 17);
            setParam(listParam, lsTokuisaki.CodeTxtText, 18);
            setParam(listParam, lsShiiresaki.CodeTxtText, 19);
            setParam(listParam, lsDaibunrui.CodeTxtText, 20);
            setParam(listParam, lsChubunrui.CodeTxtText, 21);
            setParam(listParam, lsMaker.CodeTxtText, 22);
            setParam(listParam, (rsNyukazumi.judCheckBtn()).ToString(), 23);
            setParam(listParam, (rsJuchuShubetsu.judCheckBtn()).ToString(), 24);
            setParam(listParam, (rsKyoten.judCheckBtn()).ToString(), 25);
            setParam(listParam, (rsGroup.judCheckBtn()).ToString(), 26);
            setParam(listParam, (rsSortItem.judCheckBtn()).ToString(), 27);
            setParam(listParam, (rsSortOrder.judCheckBtn()).ToString(), 28);
            setParam(listParam, (rsSearchKind.judCheckBtn()).ToString(), 29);

            D0360_JuchuzanKakunin_B bis = new D0360_JuchuzanKakunin_B();
            try
            {
                // 検索実行
                DataTable dtZanList = bis.getZanList(listParam);
                gridZanList.DataSource = dtZanList;

                if (dtZanList != null && dtZanList.Rows.Count > 0)
                {
                    Control cNow = this.ActiveControl;

                    int rowsCnt = gridZanList.RowCount;

                    // 入荷済の行はフォントカラーを変更
                    for (int i = 0; i < rowsCnt; i++)
                    {
                        if (gridZanList.Rows[i].Cells["状態"].Value != null && (String)gridZanList.Rows[i].Cells["状態"].Value == "入荷済")
                        {
                            gridZanList.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                        }
                    }

                    // 受注残が検索された場合は単価合計を算出
                    if (rsSearchKind.judCheckBtn() != 1)
                    {
                        txtGokeiUriage.Text = (dtZanList.Compute("Sum(売上単価)", null)).ToString();
                        txtGokeiUriage.Focus();
                        txtGokeiGenka.Text = (dtZanList.Compute("Sum(仕入単価)", null)).ToString();
                        txtGokeiGenka.Focus();
                    }
                    if (this.bBox == null)
                    {
                        cNow.Focus();
                    }
                }

            } catch (Exception ex)
            {
                CommonException cex = new CommonException(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void setParam(string[] lst, string prm, int idx)
        {
            if (prm != null && StringUtl.blIsEmpty(prm))
            {
                lst[idx] = prm;
            } else
            {
                lst[idx] = null;
            }
        }

        private void gridZanList_DoubleClick(object sender, EventArgs e)
        {
            int intIdx = gridZanList.CurrentCell.RowIndex;
            if (this.bBox != null) {
                bBox.Text = (gridZanList[21, intIdx].Value).ToString();
                this.Close();
            }
        }

        private void gridZanList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int intIdx = gridZanList.CurrentCell.RowIndex;
                if (this.bBox != null)
                {
                    bBox.Text = (gridZanList[21, intIdx].Value).ToString();
                    this.Close();
                }
            }
        }

        private void D0360_JuchuzanKakunin_Shown(object sender, EventArgs e)
        {
            if (gridZanList.RowCount > 0 && searchedFlg)
            {
                gridZanList.Focus();
                gridZanList.CurrentCell = gridZanList[0, 0];
            }
        }


    }
}
