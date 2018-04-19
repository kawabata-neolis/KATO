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
        private bool hatchuzanFlg = false;

        private bool blShireInput = false;

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

            this._Title = "受注残・発注残確認";
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

            rsSortOrder.radbtn0.Checked = false;
            rsSortOrder.radbtn1.Checked = true;

            //中分類setデータを読めるようにする
            lsDaibunrui.Lschubundata = lsChubunrui;

            SetUpGrid();
        }

        public D0360_JuchuzanKakunin(Control c, string stTokuisaki, BaseText baseTxtBox)
        {
            // 引数のコントロールが無い場合は画面を開かない
            if (c == null)
            {
                return;
            }

            this._Title = "受注残・発注残確認";
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

            this.bBox = baseTxtBox;
            this.lsTokuisaki.CodeTxtText = stTokuisaki;
            this.rsSearchKind.radbtn1.Checked = false;
            this.rsSearchKind.radbtn0.Checked = true;

            this.rsSortItem.radbtn3.Checked = false;
            this.rsSortItem.radbtn2.Checked = false;
            this.rsSortItem.radbtn1.Checked = false;
            this.rsSortItem.radbtn0.Checked = true;

            this.rsSortOrder.radbtn0.Checked = false;
            this.rsSortOrder.radbtn1.Checked = true;

            SetUpGrid();

            ////txtJuchuNo.Focus();
            //gridZanList.Focus();
            //this.selZanList();
            //searchedFlg = true;
            //hatchuzanFlg = true;

            //txtJuchuNo.Focus();
            this.selZanList();
            searchedFlg = true;

            hatchuzanFlg = true;

            gridZanList.Focus();
        }

        public D0360_JuchuzanKakunin(Control c, string stTokuisaki, BaseText baseTxtBox, bool blShire)
        {
            // 引数のコントロールが無い場合は画面を開かない
            if (c == null)
            {
                return;
            }

            this._Title = "受注残・発注残確認";
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

            this.bBox = baseTxtBox;
            this.lsShiiresaki.CodeTxtText = stTokuisaki;
            this.rsSearchKind.radbtn1.Checked = true;
            this.rsSearchKind.radbtn0.Checked = false;

            this.rsSortItem.radbtn3.Checked = false;
            this.rsSortItem.radbtn2.Checked = false;
            this.rsSortItem.radbtn0.Checked = false;
            this.rsSortItem.radbtn1.Checked = true;

            this.rsSortOrder.radbtn1.Checked = false;
            this.rsSortOrder.radbtn0.Checked = true;

            SetUpGrid();

            //txtJuchuNo.Focus();
            this.selZanList();
            searchedFlg = true;

            //仕入入力から来た証明
            blShireInput = blShire;
            hatchuzanFlg = true;

            gridZanList.Focus();
        }

        ///<summary>
        ///JuchuzanKakunin_Load
        ///フォームロード
        ///</summary>
        private void JuchuzanKakunin_Load(object sender, EventArgs e)
        {
            btnF01.Text = CommonTeisu.STR_FUNC_F1_HYOJII;
            btnF04.Text = CommonTeisu.STR_FUNC_F4;
            if ("1".Equals(etsuranFlg))
            {
                btnF11.Text = CommonTeisu.STR_FUNC_F11;
            }
            btnF12.Text = CommonTeisu.STR_FUNC_F12;
            if (!"1".Equals(etsuranFlg))
            {
                btnF09.Enabled = false;
            }
            
            //rsSortOrder.radbtn0.Checked = false;
            //rsSortOrder.radbtn1.Checked = true;
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

            // 注番位置入れ替え
            DataGridViewTextBoxColumn chuban = new DataGridViewTextBoxColumn();
            chuban.DataPropertyName = "注番";
            chuban.Name = "注番";
            chuban.HeaderText = "注番";

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

            // 注番位置入れ替え
            //DataGridViewTextBoxColumn chuban = new DataGridViewTextBoxColumn();
            //chuban.DataPropertyName = "注番";
            //chuban.Name = "注番";
            //chuban.HeaderText = "注番";

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

            DataGridViewTextBoxColumn hachuNo = new DataGridViewTextBoxColumn();
            hachuNo.DataPropertyName = "発注番号";
            hachuNo.Name = "発注番号";
            hachuNo.HeaderText = "発注番号";
            #endregion



            #region
            DataGridViewTextBoxColumn kakoKbn = new DataGridViewTextBoxColumn();
            kakoKbn.DataPropertyName = "区分";
            kakoKbn.Name = "区分";
            kakoKbn.HeaderText = "区分";

            DataGridViewTextBoxColumn kakoDay = new DataGridViewTextBoxColumn();
            kakoDay.DataPropertyName = "日付";
            kakoDay.Name = "日付";
            kakoDay.HeaderText = "日付";

            DataGridViewTextBoxColumn kakoChuban = new DataGridViewTextBoxColumn();
            kakoChuban.DataPropertyName = "注番";
            kakoChuban.Name = "注番";
            kakoChuban.HeaderText = "注番";

            DataGridViewTextBoxColumn kakoHinmei = new DataGridViewTextBoxColumn();
            kakoHinmei.DataPropertyName = "型番";
            kakoHinmei.Name = "型番";
            kakoHinmei.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn kakoSuryo = new DataGridViewTextBoxColumn();
            kakoSuryo.DataPropertyName = "数量";
            kakoSuryo.Name = "数量";
            kakoSuryo.HeaderText = "数量";

            DataGridViewTextBoxColumn kakoTanka = new DataGridViewTextBoxColumn();
            kakoTanka.DataPropertyName = "単価";
            kakoTanka.Name = "単価";
            kakoTanka.HeaderText = "単価";

            DataGridViewTextBoxColumn kakoNoki = new DataGridViewTextBoxColumn();
            kakoNoki.DataPropertyName = "納期";
            kakoNoki.Name = "納期";
            kakoNoki.HeaderText = "納期／出庫";

            DataGridViewTextBoxColumn kakoShiiremei = new DataGridViewTextBoxColumn();
            kakoShiiremei.DataPropertyName = "仕入先名";
            kakoShiiremei.Name = "仕入先名";
            kakoShiiremei.HeaderText = "仕入先名";

            DataGridViewTextBoxColumn kakoShiireDay = new DataGridViewTextBoxColumn();
            kakoShiireDay.DataPropertyName = "仕入日";
            kakoShiireDay.Name = "仕入日";
            kakoShiireDay.HeaderText = "仕入日";

            DataGridViewTextBoxColumn kakoShiireSu = new DataGridViewTextBoxColumn();
            kakoShiireSu.DataPropertyName = "仕入数量";
            kakoShiireSu.Name = "仕入数量";
            kakoShiireSu.HeaderText = "仕入数量";

            #endregion

            //バインド、個々の幅、文章の寄せの設定
            #region
            setColumn(juchubi,           DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null,      90);
            setColumn(noki,              DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,      90);
            setColumn(chuban,            DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,     280);
            setColumn(maker,             DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,     160);
            setColumn(hinmei,            DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,     405);
            setColumn(juchusu,           DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",     80);
            setColumn(juchuzan,          DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",     80);
            setColumn(hatchuzan,         DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",     80);
            setColumn(uriTanka,          DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",    100);
            setColumn(uriKingaku,        DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",    100);
            setColumn(siireTanka,        DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 100);
            setColumn(siireKingaku,      DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",    100);
            //setColumn(chuban,            DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,   300);
            setColumn(siireGokeiKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",    140);
            setColumn(kyakusakiChuban,   DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,     280);
            setColumn(tokuiName,         DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,     340);
            setColumn(siirebi,           DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null,      90);
            setColumn(siireName,         DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,     340);
            setColumn(uriagezumi,        DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",    100);
            setColumn(siirezumi,         DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",    100);
            setColumn(hatchubi,          DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null,      90);
            setColumn(jotai,             DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,      80);
            setColumn(juchuNo,           DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,     100);
            setColumn(juchusha,          DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,     108);
            setColumn(tantosha,          DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,     108);
            setColumn(hatchusha,         DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,     108);
            setColumn(hachuNo,           DataGridViewContentAlignment.MiddleLeft,  DataGridViewContentAlignment.MiddleCenter, null,       0);
            #endregion

            #region
            setColumnKako(kakoKbn, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 64);
            setColumnKako(kakoDay, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumnKako(kakoChuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 95);
            setColumnKako(kakoHinmei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 460);
            setColumnKako(kakoSuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 96);
            setColumnKako(kakoTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumnKako(kakoNoki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 112);
            setColumnKako(kakoShiiremei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 340);
            setColumnKako(kakoShiireDay, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumnKako(kakoShiireSu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 96);
            #endregion

            //発注番号カラムの非表示
            gridZanList.Columns["発注番号"].Visible = false;
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
                gridZanList.Columns[col.Name].SortMode = DataGridViewColumnSortMode.Automatic;

                if (fmt != null)
                {
                    gridZanList.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        private void setColumnKako(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridKakoList.Columns.Add(col);
            if (gridKakoList.Columns[col.Name] != null)
            {
                gridKakoList.Columns[col.Name].Width = intLen;
                gridKakoList.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridKakoList.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;
                gridKakoList.Columns[col.Name].SortMode = DataGridViewColumnSortMode.Automatic;

                if (fmt != null)
                {
                    gridKakoList.Columns[col.Name].DefaultCellStyle.Format = fmt;
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
                    //SendKeys.Send("{TAB}");
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
                    
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    //印刷
                    if ("1".Equals(etsuranFlg))
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                        PrintReportJuchu();
                    }
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

            this.gridKakoList.DataSource = "";

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
                case STR_BTN_F11: // 印刷
                    if ("1".Equals(etsuranFlg))
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                        this.PrintReportJuchu();
                    }
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
            //データチェック
            if (!blnDataCheck())
            {
                return;
            }

            //加工グリッドの初期化
            this.gridKakoList.DataSource = "";

            string[] listParam = new string[30];

            // パラメータ設定
            setParam(listParam, txtJuchuNo.Text, 0);
            setParam(listParam, txtHachuNo.Text, 1);

            //setParam(listParam, txtHinmei.Text, 2);
            double dblKensaku = 0;
            string strUkata;
            if (!double.TryParse(txtHinmei.Text, out dblKensaku))
            {
                //そのまま確保
                strUkata = txtHinmei.Text;
            }
            else
            {
                //空白削除
                strUkata = txtHinmei.Text.Trim();
            }

            //英字を大文字に
            strUkata = strUkata.ToUpper();

            strUkata = strUkata.Replace(" ", "");

            setParam(listParam, strUkata, 2);

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
                txtGokeiUriage.Text = "";
                txtGokeiGenka.Text = "";
                // 検索実行
                DataTable dtZanList = bis.getZanList(listParam, hatchuzanFlg);
                gridZanList.DataSource = dtZanList;

                if (dtZanList != null && dtZanList.Rows.Count > 0)
                {
                    Control cNow = this.ActiveControl;

                    lineMark();
                    //int rowsCnt = gridZanList.RowCount;

                    //decimal d = 0;
                    //// 入荷済の行はフォントカラーを変更
                    //for (int i = 0; i < rowsCnt; i++)
                    //{
                    //    d = 0;
                    //    if (gridZanList.Rows[i].Cells["受注残"].Value != null && gridZanList.Rows[i].Cells["受注残"].Value != DBNull.Value)
                    //    {
                    //        d = (decimal)gridZanList.Rows[i].Cells["受注残"].Value;
                    //        if (d.CompareTo(0) < 0)
                    //        {
                    //            gridZanList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    //        }
                    //    }
                    //    else if (gridZanList.Rows[i].Cells["発注残"].Value != null && gridZanList.Rows[i].Cells["発注残"].Value != DBNull.Value)
                    //    {
                    //        d = (decimal)gridZanList.Rows[i].Cells["発注残"].Value;
                    //        if (d.CompareTo(0) < 0)
                    //        {
                    //            gridZanList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    //        }
                    //    }
                    //    if (gridZanList.Rows[i].Cells["状態"].Value != null)
                    //    {
                    //        string s = (String)gridZanList.Rows[i].Cells["状態"].Value;

                    //        if (s.Equals("入荷済") || s.Equals("入庫済") || s.Equals("一部入荷"))
                    //        {
                    //            gridZanList.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                    //        }
                    //    }
                    //}

                    // 受注残が検索された場合は単価合計を算出
                    //if (rsSearchKind.judCheckBtn() != 1)
                    //{
                    txtGokeiUriage.Text = (dtZanList.Compute("Sum(売上金額)", null)).ToString();
                    if (!string.IsNullOrWhiteSpace(txtGokeiUriage.Text))
                    {
                        decimal dTotalU = decimal.Parse(txtGokeiUriage.Text);
                        txtGokeiUriage.Text = decimal.Round(dTotalU, 0).ToString("#,0");
                    }
                    txtGokeiUriage.Focus();

                    txtGokeiGenka.Text = (dtZanList.Compute("Sum(仕入金額)", null)).ToString();
                    if (!string.IsNullOrWhiteSpace(txtGokeiGenka.Text))
                    {
                        decimal dTotalG = decimal.Parse(txtGokeiGenka.Text);
                        txtGokeiGenka.Text = decimal.Round(dTotalG, 0).ToString("#,0");
                    }
                    txtGokeiGenka.Focus();
                    //}

                    gridZanList.Focus();

                    //if (this.bBox == null)
                    //{
                    //    cNow.Focus();
                    //}
                    //else
                    //{
                    //    gridZanList.Focus();
                    //}

                }

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        private void lineMark()
        {
            try
            {
                int rowsCnt = gridZanList.RowCount;
                decimal d = 0;
                // 入荷済の行はフォントカラーを変更
                for (int i = 0; i < rowsCnt; i++)
                {
                    d = 0;
                    if (gridZanList.Rows[i].Cells["受注残"].Value != null && gridZanList.Rows[i].Cells["受注残"].Value != DBNull.Value)
                    {
                        d = (decimal)gridZanList.Rows[i].Cells["受注残"].Value;
                        if (d.CompareTo(0) < 0)
                        {
                            gridZanList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                    else if (gridZanList.Rows[i].Cells["発注残"].Value != null && gridZanList.Rows[i].Cells["発注残"].Value != DBNull.Value)
                    {
                        d = (decimal)gridZanList.Rows[i].Cells["発注残"].Value;
                        if (d.CompareTo(0) < 0)
                        {
                            gridZanList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                    if (gridZanList.Rows[i].Cells["状態"].Value != null)
                    {
                        string s = (String)gridZanList.Rows[i].Cells["状態"].Value;

                        if (s.Equals("入荷済") || s.Equals("入庫済") || s.Equals("一部入荷"))
                        {
                            gridZanList.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// blnDataCheck
        /// データチェック
        /// </summary>
        private Boolean blnDataCheck()
        {
            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //受注者チェック
            if (lsJuchusha.chkTxtTantosha())
            {
                lsJuchusha.Focus();

                return false;
            }

            //得意先チェック
            if (lsTokuisaki.chkTxtTorihikisaki())
            {
                lsTokuisaki.Focus();

                return false;
            }

            //受注納期検索開始がある場合
            if (txtJuchuNokiFrom.blIsEmpty() == true)
            {
                strYMDformat = txtJuchuNokiFrom.chkDateDataFormat(txtJuchuNokiFrom.Text);

                if ("".Equals(strYMDformat))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
                else
                {
                    txtJuchuNokiFrom.Text = strYMDformat;
                }
            }

            //初期化
            strYMDformat = "";

            //受注納期検索終了がある場合
            if (txtJuchuNokiTo.blIsEmpty() == true)
            {
                strYMDformat = txtJuchuNokiTo.chkDateDataFormat(txtJuchuNokiTo.Text);

                if ("".Equals(strYMDformat))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
                else
                {
                    txtJuchuNokiTo.Text = strYMDformat;
                }
            }

            //初期化
            strYMDformat = "";

            //受注日検索開始がある場合
            if (txtJuchubiFrom.blIsEmpty() == true)
            {
                strYMDformat = txtJuchubiFrom.chkDateDataFormat(txtJuchubiFrom.Text);

                if ("".Equals(strYMDformat))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
                else
                {
                    txtJuchubiFrom.Text = strYMDformat;
                }
            }

            //初期化
            strYMDformat = "";

            //受注日検索終了がある場合
            if (txtJuchubiTo.blIsEmpty() == true)
            {
                strYMDformat = txtJuchubiTo.chkDateDataFormat(txtJuchubiTo.Text);

                if ("".Equals(strYMDformat))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
                else
                {
                    txtJuchubiTo.Text = strYMDformat;
                }
            }

            //発注者チェック
            if (lsHatchusha.chkTxtTantosha())
            {
                lsHatchusha.Focus();

                return false;
            }

            //仕入先チェック
            if (lsShiiresaki.chkTxtTorihikisaki())
            {
                lsShiiresaki.Focus();

                return false;
            }

            //初期化
            strYMDformat = "";

            //発注納期検索開始がある場合
            if (txtHatchuNokiFrom.blIsEmpty() == true)
            {
                strYMDformat = txtHatchuNokiFrom.chkDateDataFormat(txtHatchuNokiFrom.Text);

                if ("".Equals(strYMDformat))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
                else
                {
                    txtHatchuNokiFrom.Text = strYMDformat;
                }
            }

            //初期化
            strYMDformat = "";

            //発注納期検索終了がある場合
            if (txtHatchuNokiTo.blIsEmpty() == true)
            {
                strYMDformat = txtHatchuNokiTo.chkDateDataFormat(txtHatchuNokiTo.Text);

                if ("".Equals(strYMDformat))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
                else
                {
                    txtHatchuNokiTo.Text = strYMDformat;
                }
            }

            //初期化
            strYMDformat = "";

            //発注日検索開始がある場合
            if (txtHatchubiFrom.blIsEmpty() == true)
            {
                strYMDformat = txtHatchubiFrom.chkDateDataFormat(txtHatchubiFrom.Text);

                if ("".Equals(strYMDformat))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
                else
                {
                    txtHatchubiFrom.Text = strYMDformat;
                }

            }

            //初期化
            strYMDformat = "";

            //発注日検索終了がある場合
            if (txtHatchubiTo.blIsEmpty() == true)
            {
                strYMDformat = txtHatchubiTo.chkDateDataFormat(txtHatchubiTo.Text);

                if ("".Equals(strYMDformat))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
                else
                {
                    txtHatchubiTo.Text = strYMDformat;
                }
            }

            //初期化
            strYMDformat = "";

            //遅延判断日検索開始がある場合
            if (txtChienFrom.blIsEmpty() == true)
            {
                strYMDformat = txtChienFrom.chkDateDataFormat(txtChienFrom.Text);

                if ("".Equals(strYMDformat))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
                else
                {
                    txtChienFrom.Text = strYMDformat;
                }
            }

            //初期化
            strYMDformat = "";

            //遅延判断日検索終了がある場合
            if (txtChienTo.blIsEmpty() == true)
            {
                strYMDformat = txtChienTo.chkDateDataFormat(txtChienTo.Text);

                if ("".Equals(strYMDformat))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
                else
                {
                    txtChienTo.Text = strYMDformat;
                }
            }

            //担当者チェック
            if (lsTantousha.chkTxtTantosha())
            {
                lsTantousha.Focus();

                return false;
            }

            //大分類チェック
            if (lsDaibunrui.chkTxtDaibunrui())
            {
                lsDaibunrui.Focus();

                return false;
            }
            //中分類チェック
            if (lsChubunrui.chkTxtChubunrui(lsDaibunrui.CodeTxtText))
            {
                lsChubunrui.Focus();

                return false;
            }

            //メーカーチェック
            if (lsMaker.chkTxtMaker())
            {
                lsMaker.Focus();

                return false;
            }

            return true;
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
            //残リストがない場合
            if (gridZanList.Rows.Count < 1)
            {
                return;
            }

            int intIdx = gridZanList.CurrentCell.RowIndex;
            if (this.bBox != null) {

                //仕入入力から来た場合
                if (blShireInput == true)
                {
                    bBox.Text = (gridZanList[25, intIdx].Value).ToString();
                }
                else
                {
                    bBox.Text = (gridZanList[21, intIdx].Value).ToString();
                }
                this.Close();
            }
        }

        private void gridZanList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //残リストがない場合
                if (gridZanList.Rows.Count < 1)
                {
                    return;
                }

                int intIdx = gridZanList.CurrentCell.RowIndex;
                if (this.bBox != null)
                {
                    //仕入入力から来た場合
                    if (blShireInput == true)
                    {
                        bBox.Text = (gridZanList[25, intIdx].Value).ToString();
                    }
                    else
                    {
                        bBox.Text = (gridZanList[21, intIdx].Value).ToString();
                    }
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
                lineMark();
            }
        }

        private void txtJuchuNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void gridZanList_Sorted(object sender, EventArgs e)
        {
            lineMark();
        }

        /// <summary>
        /// gridZanList_RowEnter
        /// 加工原価確認グリッドの表示
        /// </summary>
        private void gridZanList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //残リストがない場合
            if (gridZanList.Rows.Count < 1)
            {
                return;
            }

            D0360_JuchuzanKakunin_B bis = new D0360_JuchuzanKakunin_B();
            try
            {
                int intRowIdx = e.RowIndex;

                //受注番号がない場合
                if (StringUtl.blIsEmpty(gridZanList.Rows[intRowIdx].Cells["受注番号"].Value.ToString()) == false)
                {
                    gridKakoList.DataSource = "";
                    return;
                }

                DataTable dtKakoList = bis.getKakoList(gridZanList.Rows[intRowIdx].Cells["受注番号"].Value.ToString());

                gridKakoList.DataSource = dtKakoList;
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        /// <summary>
        /// PrintReportJuchu
        /// PDF印刷を行う。()
        /// </summary>
        private void PrintReportJuchu()
        {
            // 閲覧権限のないユーザーは使用不可
            if (!"1".Equals(etsuranFlg))
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            //データチェック
            if (!blnDataCheck())
            {
                return;
            }

            //加工グリッドの初期化
            this.gridKakoList.DataSource = "";

            string[] listParam = new string[30];

            // パラメータ設定
            setParam(listParam, txtJuchuNo.Text, 0);
            setParam(listParam, txtHachuNo.Text, 1);

            //setParam(listParam, txtHinmei.Text, 2);
            double dblKensaku = 0;
            string strUkata;
            if (!double.TryParse(txtHinmei.Text, out dblKensaku))
            {
                //そのまま確保
                strUkata = txtHinmei.Text;
            }
            else
            {
                //空白削除
                strUkata = txtHinmei.Text.Trim();
            }

            //英字を大文字に
            strUkata = strUkata.ToUpper();

            strUkata = strUkata.Replace(" ", "");

            setParam(listParam, strUkata, 2);

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
                txtGokeiUriage.Text = "";
                txtGokeiGenka.Text = "";
                // 検索実行
                DataTable dtZanList = bis.getZanListP(listParam, hatchuzanFlg);

                if (dtZanList == null || dtZanList.Rows.Count == 0)
                {
                    return;
                }

                // PDF作成
                string  stPass = bis.printReport(dtZanList, lsJuchusha.ValueLabelText,
                    lsTokuisaki.ValueLabelText, txtJuchuNokiFrom.Text, txtJuchuNokiTo.Text,
                    strUkata, txtChuban.Text);

                // 印刷ダイアログ表示
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, CommonTeisu.YOKO);
                pf.ShowDialog(this);
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    pf.execPreview(stPass);
                }
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    pf.execPrint(null, stPass, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, false);
                }
                pf.Dispose();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
