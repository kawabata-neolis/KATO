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
                labelSet_Siiresaki.CodeTxtText = strSiiresakiCd;
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
            this.btnF12.Text = STR_FUNC_F12;

            // 初期表示
            labelSet_Siiresaki.Focus();

            // 検索開始年月の設定
            txtYmStart.setUp(0);
            txtYmEnd.setUp(0);

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
            setColumn(kubunName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 70);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 480);
            setColumn(suuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 80);
            setColumn(tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#.00", 100);
            setColumn(kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 100);
            setColumn(shiharai, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 100);
            setColumn(zandaka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 120);

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

            labelSet_Siiresaki.Focus();
        }

        /// <summary>
        /// setSiire
        /// データをグリッドビューに追加
        /// </summary>
        private void setSiire()
        {
            //記入項目の空白削除
            labelSet_Siiresaki.CodeTxtText.Trim();
            txtYmStart.Text.Trim();
            txtYmStart.Text.Trim();
            txtZeigaku.Text.Trim();
            txtShiharaiKingaku.Text.Trim();
            txtSiireKingaku.Text.Trim();
            txtZeigaku.Text.Trim();
            txtTougetsuZandaka.Text.Trim();

            //検索時に必須条件を満たさない場合
            if (labelSet_Siiresaki.codeTxt.blIsEmpty() == false ||
                txtYmStart.blIsEmpty() == false ||
                txtYmEnd.blIsEmpty() == false)
            {
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
            lstSearchItem.Add(labelSet_Siiresaki.CodeTxtText);      // 仕入先コード
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
                dtSiiresakiInfo = siireB.getSiiresakiInfo(this.labelSet_Siiresaki.CodeTxtText);
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


    }
}
