using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.E0340_SiiresakiMotochouKakunin;

namespace KATO.Form.E0340_SiiresakiMotochouKakunin
{
    /// <summary>
    /// E0340_SiiresakiMotochouKakunin
    /// 仕入先元帳確認フォーム
    /// 作成者：多田
    /// 作成日：2017/7/12
    /// 更新者：多田
    /// 更新日：2017/7/12
    /// カラム論理名
    /// </summary>
    public partial class E0340_SiiresakiMotochouKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // 画面ID
        private int intFrm;

        // 得意先コード
        private string strSiiresakiCd;

        /// <summary>
        /// E0340_SiiresakiMotochouKakunin
        /// フォーム関係の設定
        /// </summary>
        public E0340_SiiresakiMotochouKakunin(Control c, int intFrm, string strSiiresakiCd)
        {
            if (c == null)
            {
                return;
            }

            // 画面IDをセット
            this.intFrm = intFrm;
            // 得意先コードをセット
            this.strSiiresakiCd = strSiiresakiCd;

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            // フォームが最大化されないようにする
            this.MaximizeBox = false;
            // フォームが最小化されないようにする
            this.MinimizeBox = false;

            // 最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            // ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            // 親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;
        }

        private void E0340_SiiresakiMotochouKakunin_Shown(object sender, EventArgs e)
        {
            if (strSiiresakiCd != "")
            {
                labelSet_SiiresakiStart.CodeTxtText = strSiiresakiCd;
                this.setSiire();
                gridSiire.Focus();
            }
        }

        /// <summary>
        /// E0340_SiiresakiMotochouKakunin_Load
        /// 読み込み時
        /// </summary>
        private void E0340_SiiresakiMotochouKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "仕入先元帳確認";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // 初期表示
            labelSet_SiiresakiStart.Focus();

            // 検索開始年月の設定
            txtYmStart.setUp(0);
            txtYmEnd.setUp(0);

            radSet_Insatsu.radbtn1.Checked = true;

            // DataGridViewの初期設定
            SetUpGrid();

            // ステータスバーにメッセージ表示
            this.lblStatusMessage.Text = "F9を押すと、一覧表示または検索ができます";
        }

        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            // 列自動生成禁止
            gridSiire.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn hiduke = new DataGridViewTextBoxColumn();
            hiduke.DataPropertyName = "伝票年月日";
            hiduke.Name = "伝票年月日";
            hiduke.HeaderText = "日付";

            DataGridViewTextBoxColumn denpyoNo = new DataGridViewTextBoxColumn();
            denpyoNo.DataPropertyName = "伝票番号";
            denpyoNo.Name = "伝票番号";
            denpyoNo.HeaderText = "伝№";

            DataGridViewTextBoxColumn kubunName = new DataGridViewTextBoxColumn();
            kubunName.DataPropertyName = "取引区分名";
            kubunName.Name = "取引区分名";
            kubunName.HeaderText = "区分";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー名";
            maker.Name = "メーカー名";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "商品名";
            kataban.Name = "商品名";
            kataban.HeaderText = "品名・型式";

            DataGridViewTextBoxColumn suuryo = new DataGridViewTextBoxColumn();
            suuryo.DataPropertyName = "数量";
            suuryo.Name = "数量";
            suuryo.HeaderText = "数量";

            DataGridViewTextBoxColumn tanka = new DataGridViewTextBoxColumn();
            tanka.DataPropertyName = "仕入単価";
            tanka.Name = "仕入単価";
            tanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn kingaku = new DataGridViewTextBoxColumn();
            kingaku.DataPropertyName = "仕入金額";
            kingaku.Name = "仕入金額";
            kingaku.HeaderText = "仕入金額";

            DataGridViewTextBoxColumn shiharai = new DataGridViewTextBoxColumn();
            shiharai.DataPropertyName = "支払額";
            shiharai.Name = "支払額";
            shiharai.HeaderText = "支払金額";

            DataGridViewTextBoxColumn zandaka = new DataGridViewTextBoxColumn();
            zandaka.DataPropertyName = "差引残高";
            zandaka.Name = "差引残高";
            zandaka.HeaderText = "差引残高";

            DataGridViewTextBoxColumn kubun = new DataGridViewTextBoxColumn();
            kubun.DataPropertyName = "取引区分";
            kubun.Name = "取引区分";
            kubun.HeaderText = "取引区分";

            // 個々の幅、文字の寄せ
            setColumn(hiduke, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(denpyoNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 64);
            setColumn(kubunName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 64);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 145);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 465);
            setColumn(suuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 64);
            setColumn(tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 108);
            setColumn(kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 108);
            setColumn(shiharai, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 108);
            setColumn(zandaka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 108);

            // 非表示項目（取引区分）
            setColumn(kubun, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#", 0);
            gridSiire.Columns[10].Visible = false;
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridSiire.Columns.Add(col);
            if (gridSiire.Columns[col.Name] != null)
            {
                gridSiire.Columns[col.Name].Width = intLen;
                gridSiire.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridSiire.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridSiire.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// E0340_SiiresakiMotochouKakunin_KeyDown
        /// キー入力判定
        /// </summary>
        private void E0340_SiiresakiMotochouKakunin_KeyDown(object sender, KeyEventArgs e)
        {
            // キー入力情報によって動作を変える
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
                    break;
                case Keys.F1:
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setSiire();
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
                case Keys.F10:
                    break;
                case Keys.F11:
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printShireMotocyoKakunin();
                    break;
                case Keys.F12:
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// judBtnClick
        /// ボタンの反応
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 表示
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setSiire();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printShireMotocyoKakunin();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // 削除するデータ以外を確保
            string strYmStart = txtYmStart.Text;
            string strYmEnd = txtYmEnd.Text;

            // 画面の項目内を白紙にする
            delFormClear(this, gridSiire);

            txtYmStart.Text = strYmStart;
            txtYmEnd.Text = strYmEnd;

            labelSet_SiiresakiStart.Focus();
        }

        /// <summary>
        /// setSiire
        /// データをグリッドビューに追加
        /// </summary>
        private void setSiire()
        {
            //記入項目の空白削除
            labelSet_SiiresakiStart.CodeTxtText.Trim();
            labelSet_SiiresakiEnd.CodeTxtText.Trim();
            txtYmStart.Text.Trim();
            txtYmStart.Text.Trim();
            txtZeigaku.Text.Trim();
            txtShiharaiKingaku.Text.Trim();
            txtSiireKingaku.Text.Trim();
            txtZeigaku.Text.Trim();
            txtTougetsuZandaka.Text.Trim();

            //検索時に必須条件を満たさない場合
            if (labelSet_SiiresakiStart.codeTxt.blIsEmpty() == false ||
                txtYmStart.blIsEmpty() == false ||
                txtYmEnd.blIsEmpty() == false)
            {
                labelSet_SiiresakiStart.Focus();
                return;
            }

            // 入力チェック（仕入先コード（取引先））
            if (labelSet_SiiresakiStart.chkTxtTorihikisaki())
            {
                return;
            }

            // 日付フォーマットチェック（検索年月Start）
            string sDatedata = txtYmStart.chkDateYMDataFormat(txtYmStart.Text);
            if ("".Equals(sDatedata))
            {
                // メッセージボックスの処理
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            else
            {
                txtYmStart.Text = sDatedata;
            }

            // 日付フォーマットチェック（検索年月End）
            string eDatedata = txtYmEnd.chkDateYMDataFormat(txtYmEnd.Text);
            if ("".Equals(eDatedata))
            {
                // メッセージボックスの処理
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            else
            {
                txtYmEnd.Text = eDatedata;
            }

            //仕入先コードの終了開始項目
            if (labelSet_SiiresakiEnd.codeTxt.blIsEmpty() == true)
            {
                //得意先コードの範囲指定は出来ないメッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "複数の仕入先コードは指定できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_SiiresakiEnd.Focus();
                return;
            }

            // データ検索用
            List<string> lstSearchItem = new List<string>();
            // 得意先情報取得用
            DataTable dtSiiresakiInfo;
            // 消費税区分 
            string kbnZei = "";
            // 消費税計算区分
            string kbnZeiKeisan = "";

            string strYmStart = txtYmStart.Text + "/01";
            DateTime dateYmEnd = DateTime.Parse(txtYmEnd.Text + "/01");
            string strYmEnd = dateYmEnd.AddMonths(1).AddDays(-1).ToString().Substring(0, 10);

            // 検索データをリストに格納
            lstSearchItem.Add(labelSet_SiiresakiStart.CodeTxtText);      // 仕入先コード
            lstSearchItem.Add(strYmStart);                          // 検索開始年月日
            lstSearchItem.Add(strYmEnd);                            // 検索終了年月日
            lstSearchItem.Add("");                                  // 仕入金額

            // 金額
            decimal[] decKingku = new decimal[7];

            // ビジネス層のインスタンス生成
            E0340_SiiresakiMotochouKakunin_B siireB = new E0340_SiiresakiMotochouKakunin_B();
            try
            {
                // 仕入先情報取得
                dtSiiresakiInfo = siireB.getSiiresakiInfo(this.labelSet_SiiresakiStart.CodeTxtText);
                if (dtSiiresakiInfo.Rows.Count > 0)
                {
                    kbnZei = dtSiiresakiInfo.Rows[0]["消費税区分"].ToString();
                    kbnZeiKeisan = dtSiiresakiInfo.Rows[0]["消費税計算区分"].ToString();
                }

                decimal decGoukei = 0;
                decimal decZengetsuZandaka = 0;
                decimal decSiireKingaku = 0;
                decimal decShiharaiKingaku = 0;
                DataTable dtSiireList;

                // 買掛残高一覧表_繰越残高FROM取引先経理情報
                dtSiireList = siireB.getSiireList(lstSearchItem, 1);

                if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                {
                    txtZengetsuZandaka.Text = string.Format("{0:#,0}", decimal.Parse(dtSiireList.Rows[0][0].ToString()));
                }
                else
                {
                    txtZengetsuZandaka.Text = "0";
                }

                // 買掛残高一覧表_仕入ヘッダ_仕入高
                dtSiireList = siireB.getSiireList(lstSearchItem, 2);

                if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                {
                    txtSiireKingaku.Text = string.Format("{0:#,0}", decimal.Parse(dtSiireList.Rows[0][0].ToString()));
                }
                else
                {
                    txtSiireKingaku.Text = "0";
                }

                lstSearchItem[3] = decimal.Parse(txtSiireKingaku.Text).ToString();

                // 買掛残高一覧表_仕入ヘッダ_消費税
                dtSiireList = siireB.getSiireList(lstSearchItem, 3);

                if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                {
                    txtZeigaku.Text = string.Format("{0:#,0}", decimal.Parse(dtSiireList.Rows[0][0].ToString()));
                }
                else
                {
                    txtZeigaku.Text = "0";
                }

                // 外税の場合
                if (kbnZei.Equals("0") && kbnZeiKeisan.Equals("2"))
                {
                    // 売掛残高一覧表_月間消費税
                    dtSiireList = siireB.getSiireList(lstSearchItem, 4);

                    if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                    {
                        txtZeigaku.Text = string.Format("{0:#,0}", decimal.Parse(dtSiireList.Rows[0][0].ToString()));
                    }
                    else
                    {
                        txtZeigaku.Text = "0";
                    }
                }

                // 内税の場合
                if (kbnZei.Equals("1"))
                {
                    // 売掛残高一覧表_月間消費税
                    dtSiireList = siireB.getSiireList(lstSearchItem, 4);

                    if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                    {
                        txtZeigaku.Text = string.Format("{0:#,0}", decimal.Parse(dtSiireList.Rows[0][0].ToString()));
                    }
                    else
                    {
                        txtZeigaku.Text = "0";
                    }

                    // 仕入金額に値をセット
                    decimal decSiire = decimal.Parse(txtSiireKingaku.Text) - decimal.Parse(txtZeigaku.Text);
                    txtSiireKingaku.Text = decSiire.ToString("#,0");
                }

                // 買掛残高一覧表_支払_現金
                dtSiireList = siireB.getSiireList(lstSearchItem, 5);

                if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                {
                    decKingku[0] = decimal.Parse(dtSiireList.Rows[0][0].ToString());
                }
                else
                {
                    decKingku[0] = 0;
                }


                // 買掛残高一覧表_支払_小切手
                dtSiireList = siireB.getSiireList(lstSearchItem, 6);

                if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                {
                    decKingku[1] = decimal.Parse(dtSiireList.Rows[0][0].ToString());
                }
                else
                {
                    decKingku[1] = 0;
                }

                // 買掛残高一覧表_支払_振込
                dtSiireList = siireB.getSiireList(lstSearchItem, 7);

                if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                {
                    decKingku[2] = decimal.Parse(dtSiireList.Rows[0][0].ToString());
                }
                else
                {
                    decKingku[2] = 0;
                }

                // 買掛残高一覧表_支払_手形
                dtSiireList = siireB.getSiireList(lstSearchItem, 8);

                if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                {
                    decKingku[3] = decimal.Parse(dtSiireList.Rows[0][0].ToString());
                }
                else
                {
                    decKingku[3] = 0;
                }

                // 買掛残高一覧表_支払_相殺
                dtSiireList = siireB.getSiireList(lstSearchItem, 9);

                if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                {
                    decKingku[4] = decimal.Parse(dtSiireList.Rows[0][0].ToString());
                }
                else
                {
                    decKingku[4] = 0;
                }

                // 買掛残高一覧表_支払_手数料
                dtSiireList = siireB.getSiireList(lstSearchItem, 10);

                if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                {
                    decKingku[5] = decimal.Parse(dtSiireList.Rows[0][0].ToString());
                }
                else
                {
                    decKingku[5] = 0;
                }

                // 買掛残高一覧表_支払_その他
                dtSiireList = siireB.getSiireList(lstSearchItem, 11);

                if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                {
                    decKingku[6] = decimal.Parse(dtSiireList.Rows[0][0].ToString());
                }
                else
                {
                    decKingku[6] = 0;
                }

                // 支払金額
                for (int cnt = 0; cnt < decKingku.Length; cnt++)
                {
                    decGoukei += decKingku[cnt];
                }
                txtShiharaiKingaku.Text = decGoukei.ToString("#,0");

                // 当月残高
                decimal decTougetsuZandaka = decimal.Parse(txtZengetsuZandaka.Text) - decimal.Parse(txtShiharaiKingaku.Text) +
                    decimal.Parse(txtSiireKingaku.Text) + decimal.Parse(txtZeigaku.Text);
                txtTougetsuZandaka.Text = decTougetsuZandaka.ToString("#,0");

                // 検索実行
                dtSiireList = siireB.getSiireList(lstSearchItem, 12);

                // データテーブルからデータグリッドへセット
                gridSiire.DataSource = dtSiireList;

                if (dtSiireList != null && dtSiireList.Rows.Count > 0)
                {
                    string strDate = "";
                    string strDenpyoNo = "";
                    for (int cnt = 0; cnt < gridSiire.RowCount; cnt++)
                    {
                        // 伝票年月日と伝票番号が同じ場合、伝票年月日と伝票番号を表示しない
                        if (gridSiire.Rows[cnt].Cells["伝票年月日"].Value.ToString().Equals(strDate) &&
                            gridSiire.Rows[cnt].Cells["伝票番号"].Value.ToString().Equals(strDenpyoNo))
                        {
                            // 仕入の場合、区分を表示しない
                            if (gridSiire.Rows[cnt].Cells["取引区分"].Value.ToString().Equals("21"))
                            {
                                gridSiire.Rows[cnt].Cells["取引区分名"].Value = DBNull.Value;
                            }

                            gridSiire.Rows[cnt].Cells["伝票年月日"].Value = DBNull.Value;
                            gridSiire.Rows[cnt].Cells["伝票番号"].Value = DBNull.Value;
                        }
                        else
                        {
                            strDate = gridSiire.Rows[cnt].Cells["伝票年月日"].Value.ToString();
                            strDenpyoNo = gridSiire.Rows[cnt].Cells["伝票番号"].Value.ToString();
                        }

                        // 入金の場合はフォントカラーを変更
                        int intKubun = int.Parse(gridSiire.Rows[cnt].Cells["取引区分"].Value.ToString());
                        if (intKubun >= 31 && intKubun <= 37)
                        {
                            gridSiire.Rows[cnt].DefaultCellStyle.ForeColor = Color.Blue;
                        }

                        // 数量又は金額の空白チェック用フラグ
                        bool blnBlankFlg = false;

                        // 数量
                        decimal decSuuryo = 0;
                        if (!decimal.TryParse(gridSiire.Rows[cnt].Cells["数量"].Value.ToString(), out decSuuryo))
                        {
                            blnBlankFlg = true;
                        }

                        // 金額
                        decimal decKingaku = 0;
                        if (!decimal.TryParse(gridSiire.Rows[cnt].Cells["仕入金額"].Value.ToString(), out decKingaku))
                        {
                            blnBlankFlg = true;
                        }

                        // 数量又は金額が空白ではなく、かつ、マイナスの場合はフォントカラーを変更
                        if (!blnBlankFlg && (decSuuryo < 0 || decKingaku < 0))
                        {
                            gridSiire.Rows[cnt].DefaultCellStyle.ForeColor = Color.Red;
                        }

                        // 1行目の場合
                        if (cnt == 0)
                        {
                            decZengetsuZandaka = decimal.Parse(txtZengetsuZandaka.Text);
                        }
                        else
                        {
                            decZengetsuZandaka = decimal.Parse(gridSiire.Rows[cnt - 1].Cells["差引残高"].Value.ToString());
                        }

                        // 仕入金額がなかった場合
                        if (!decimal.TryParse(gridSiire.Rows[cnt].Cells["仕入金額"].Value.ToString(), out decSiireKingaku))
                        {
                            decSiireKingaku = 0;
                        }

                        // 支払金額がなかった場合
                        if (!decimal.TryParse(gridSiire.Rows[cnt].Cells["支払額"].Value.ToString(), out decShiharaiKingaku))
                        {
                            decShiharaiKingaku = 0;
                        }

                        // 差引残高
                        decimal decSashihikiZandaka = decZengetsuZandaka + decSiireKingaku - decShiharaiKingaku;
                        gridSiire.Rows[cnt].Cells["差引残高"].Value = decSashihikiZandaka.ToString("#,0");
                    }

                    Control cNow = this.ActiveControl;
                    cNow.Focus();
                }
                // DataTableのレコード数取得
                int dtCnt = dtSiireList.Rows.Count;
                if (dtCnt > 0)
                {
                    // ステータスバーに検索結果表示
                    this.lblStatusMessage.Text = "検索終了(該当件数" + dtCnt + "件)";
                }
                else
                {
                    // ステータスバーに検索結果表示
                    this.lblStatusMessage.Text = "検索終了(該当なし)";
                }

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
            return;
        }

        ///<summary>
        ///printShireMotocyoKakunin
        ///印刷ダイアログ
        ///</summary>
        private void printShireMotocyoKakunin()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtPrintData = new DataTable();

            //PDF作成後の入れ物
            string strFile = "";

            //印刷対象の選択用
            string strInsatsuSelect = "";

            //営業所の選択用
            string strEigyosho = "";

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //得意先コードの検索開始項目のチェック
            if (labelSet_SiiresakiStart.codeTxt.blIsEmpty() == false ||
                StringUtl.blIsEmpty(labelSet_SiiresakiStart.ValueLabelText) == false ||
                labelSet_SiiresakiStart.chkTxtTorihikisaki() == true)
            {
                labelSet_SiiresakiStart.Focus();
                return;
            }

            //得意先コードの終了開始項目のチェック
            if (labelSet_SiiresakiEnd.codeTxt.blIsEmpty() == false ||
                StringUtl.blIsEmpty(labelSet_SiiresakiEnd.ValueLabelText) == false ||
                labelSet_SiiresakiEnd.chkTxtTorihikisaki() == true)
            {
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "仕入先コードを範囲で指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_SiiresakiEnd.Focus();
                return;
            }

            //空文字判定（検索開始年月）
            if (txtYmStart.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n条件を指定してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmStart.Focus();

                return;
            }

            //空文字判定（検索終了年月）
            if (txtYmEnd.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n条件を指定してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmEnd.Focus();

                return;
            }

            //得意先開始チェック
            if (labelSet_SiiresakiStart.chkTxtTorihikisaki())
            {
                labelSet_SiiresakiStart.Focus();

                return;
            }

            //得意先終了チェック
            if (labelSet_SiiresakiEnd.chkTxtTorihikisaki())
            {
                labelSet_SiiresakiEnd.Focus();

                return;
            }

            //日付フォーマット生成、およびチェック
            strYMDformat = txtYmStart.chkDateYMDataFormat(txtYmStart.Text);

            //開始年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmStart.Focus();

                return;
            }
            else
            {
                txtYmStart.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtYmEnd.chkDateYMDataFormat(txtYmEnd.Text);

            //終了年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmEnd.Focus();

                return;
            }
            else
            {
                txtYmEnd.Text = strYMDformat;
            }

            //印刷対象の範囲指定をする場合
            if (radSet_Insatsu.radbtn1.Checked == true)
            {
                strInsatsuSelect = "0";
            }
            else
            {
                strInsatsuSelect = "1";
            }

            //営業所の指定をする場合
            if (radSet_Eigyo.radbtn0.Checked == true)
            {
                strEigyosho = "0";
            }
            else if (radSet_Eigyo.radbtn1.Checked == true)
            {
                strEigyosho = "1";
            }
            else if (radSet_Eigyo.radbtn2.Checked == true)
            {
                strEigyosho = "2";
            }

            //その月の最終日を求める（年月日検索終了項目用）
            int intDay = DateTime.DaysInMonth(DateTime.Parse(txtYmEnd.Text).Year, DateTime.Parse(txtYmEnd.Text).Month);

            //印刷用データを入れる用
            List<string> lstPrintData = new List<string>();

            //印刷用データを入れる
            lstPrintData.Add(labelSet_SiiresakiStart.CodeTxtText);
            lstPrintData.Add(labelSet_SiiresakiEnd.CodeTxtText);
            lstPrintData.Add(DateTime.Parse(txtYmStart.Text).ToString("yyyy/MM/dd"));
            lstPrintData.Add(DateTime.Parse(txtYmEnd.Text).ToString("yyyy/MM/") + intDay.ToString());
            lstPrintData.Add(strInsatsuSelect);
            lstPrintData.Add(strEigyosho);

            //仕入先コード範囲内の取引先を取得
            E0340_SiiresakiMotochouKakunin_B siireB = new E0340_SiiresakiMotochouKakunin_B();
            try
            {
                //待機状態
                Cursor.Current = Cursors.WaitCursor;

                dtPrintData = siireB.getPrintData(lstPrintData);

                //元に戻す
                Cursor.Current = Cursors.Default;

                //データが無ければ
                if (dtPrintData.Rows.Count < 1)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, "印刷", "対象のデータがありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

                //初期値
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, YOKO);

                pf.ShowDialog(this);

                //プレビューの場合
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    //待機状態
                    Cursor.Current = Cursors.WaitCursor;

                    //結果セットをレコードセットに
                    strFile = siireB.dbToPdf(dtPrintData, lstPrintData);

                    //元に戻す
                    Cursor.Current = Cursors.Default;

                    //印刷できなかった場合
                    if (strFile == "")
                    {
                        //印刷時エラーメッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, "印刷", "印刷時エラーです。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        return;
                    }

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    strFile = siireB.dbToPdf(dtPrintData, lstPrintData);

                    //印刷できなかった場合
                    if (strFile == "")
                    {
                        //印刷時エラーメッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, "印刷", "印刷時エラーです。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        return;
                    }

                    // 一括印刷
                    pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
                }
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }
    }
}
