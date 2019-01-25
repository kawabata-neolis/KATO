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
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Business.B0250_MOnyuryoku;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.B1570_NyukinInput;
using KATO.Business.B0060_ShiharaiInput_B;

namespace KATO.Form.B1570_NyukinInput
{
    public partial class B1570_NyukinInput : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        DataGridViewContentAlignment posLeft = DataGridViewContentAlignment.MiddleLeft;
        DataGridViewContentAlignment posCenter = DataGridViewContentAlignment.MiddleCenter;
        DataGridViewContentAlignment posRight = DataGridViewContentAlignment.MiddleRight;

        DataTable dt = null;

        string fmtNumNormal = "#";
        string fmtNumComma = "#,0";
        string fmtNumPeriod = "#,0.00";
        string fmtYMD = "yyyy/MM/dd";
        string fmtString = null;
        int rowIdx = 0;

        string eigyosho = "";

        string defInputYmdFr = "";
        string defInputYmdTo = "";
        string defDenpyoYmdFr = "";
        string defDenpyoYmdTo = "";
        string defShiireCdFr = "0000";
        string defShiireCdTo = "9999";

        public B1570_NyukinInput(Control c)
        {
            if (c == null)
            {
                return;
            }

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

            setupGrid();
        }


        private void B1570_NyukinInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "入金入力";

            cmbSubWinShow.Items.Add("請求履歴");

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            setTanto(true);
            setupGrid();

            txtInputYMDFr.setUp(0);
            txtInputYMDTo.setUp(0);
            txtDenpyoYMDFr.setUp(1);
            txtDenpyoYMDTo.setUp(2);

            defInputYmdFr = txtInputYMDFr.Text;
            defInputYmdTo = txtInputYMDTo.Text;
            defDenpyoYmdFr = txtDenpyoYMDFr.Text;
            defDenpyoYmdTo = txtDenpyoYMDTo.Text;

            showGrid(1);
        }

        //
        // grid 初期設定
        //
        private void setupGrid()
        {
            //列自動生成禁止
            gridNyukin.AutoGenerateColumns = false;

            #region 列項目定義
            DataGridViewTextBoxColumn colRowNum = new DataGridViewTextBoxColumn();
            colRowNum.DataPropertyName = "行番号";
            colRowNum.Name = "行番号";
            colRowNum.HeaderText = "No.";
            colRowNum.ReadOnly = true;
            colRowNum.Visible = false;
            setColumn(gridNyukin, colRowNum, posRight, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colDenpyoYmd = new DataGridViewTextBoxColumn();
            colDenpyoYmd.DataPropertyName = "伝票年月日";
            colDenpyoYmd.Name = "伝票年月日";
            colDenpyoYmd.HeaderText = "伝票年月日";
            setColumn(gridNyukin, colDenpyoYmd, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colShimekiriDay = new DataGridViewTextBoxColumn();
            colShimekiriDay.DataPropertyName = "締切日";
            colShimekiriDay.Name = "締切日";
            colShimekiriDay.HeaderText = "締切日";
            setColumn(gridNyukin, colShimekiriDay, posRight, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colShiiresakiCd = new DataGridViewTextBoxColumn();
            colShiiresakiCd.DataPropertyName = "得意先コード";
            colShiiresakiCd.Name = "得意先コード";
            colShiiresakiCd.HeaderText = "得意先コード";
            setColumn(gridNyukin, colShiiresakiCd, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiiresakiNm = new DataGridViewTextBoxColumn();
            colShiiresakiNm.DataPropertyName = "得意先名";
            colShiiresakiNm.Name = "得意先名";
            colShiiresakiNm.HeaderText = "得意先名";
            setColumn(gridNyukin, colShiiresakiNm, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiharaiYoteiYMD = new DataGridViewTextBoxColumn();
            colShiharaiYoteiYMD.DataPropertyName = "入金予定日";
            colShiharaiYoteiYMD.Name = "入金予定日";
            colShiharaiYoteiYMD.HeaderText = "入金予定日";
            setColumn(gridNyukin, colShiharaiYoteiYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colShiharaiYMD = new DataGridViewTextBoxColumn();
            colShiharaiYMD.DataPropertyName = "入金日";
            colShiharaiYMD.Name = "入金日";
            colShiharaiYMD.HeaderText = "入金日";
            setColumn(gridNyukin, colShiharaiYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colDenpyoNo = new DataGridViewTextBoxColumn();
            colDenpyoNo.DataPropertyName = "伝票番号";
            colDenpyoNo.Name = "伝票番号";
            colDenpyoNo.HeaderText = "伝票番号";
            setColumn(gridNyukin, colDenpyoNo, posRight, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colToriKbnCd = new DataGridViewTextBoxColumn();
            colToriKbnCd.DataPropertyName = "取引区分コード";
            colToriKbnCd.Name = "取引区分コード";
            colToriKbnCd.HeaderText = "コード";
            setColumn(gridNyukin, colToriKbnCd, posCenter, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colToriKbnNm = new DataGridViewTextBoxColumn();
            colToriKbnNm.DataPropertyName = "取引区分名";
            colToriKbnNm.Name = "取引区分名";
            colToriKbnNm.HeaderText = "区分名";
            setColumn(gridNyukin, colToriKbnNm, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colKouza = new DataGridViewTextBoxColumn();
            colKouza.DataPropertyName = "口座";
            colKouza.Name = "口座";
            colKouza.HeaderText = "口座";
            setColumn(gridNyukin, colKouza, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colKinyuKikan = new DataGridViewTextBoxColumn();
            colKinyuKikan.DataPropertyName = "金融機関名";
            colKinyuKikan.Name = "金融機関名";
            colKinyuKikan.HeaderText = "金融機関名";
            setColumn(gridNyukin, colKinyuKikan, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiten = new DataGridViewTextBoxColumn();
            colShiten.DataPropertyName = "支店名";
            colShiten.Name = "支店名";
            colShiten.HeaderText = "支店名";
            setColumn(gridNyukin, colShiten, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiharaiYoteiGaku = new DataGridViewTextBoxColumn();
            colShiharaiYoteiGaku.DataPropertyName = "入金予定額";
            colShiharaiYoteiGaku.Name = "入金予定額";
            colShiharaiYoteiGaku.HeaderText = "入金予定額";
            setColumn(gridNyukin, colShiharaiYoteiGaku, posRight, posCenter, fmtNumComma, 122);

            DataGridViewTextBoxColumn colShiharaiGaku = new DataGridViewTextBoxColumn();
            colShiharaiGaku.DataPropertyName = "入金額";
            colShiharaiGaku.Name = "入金額";
            colShiharaiGaku.HeaderText = "入金額";
            setColumn(gridNyukin, colShiharaiGaku, posRight, posCenter, fmtNumComma, 122);

            DataGridViewTextBoxColumn colTegataYMD = new DataGridViewTextBoxColumn();
            colTegataYMD.DataPropertyName = "手形期日";
            colTegataYMD.Name = "手形期日";
            colTegataYMD.HeaderText = "手形期日";
            setColumn(gridNyukin, colTegataYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colShiharaiMonths = new DataGridViewTextBoxColumn();
            colShiharaiMonths.DataPropertyName = "入金月数";
            colShiharaiMonths.Name = "入金月数";
            colShiharaiMonths.HeaderText = "入金月数";
            setColumn(gridNyukin, colShiharaiMonths, posCenter, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colShiharaiJoken = new DataGridViewTextBoxColumn();
            colShiharaiJoken.DataPropertyName = "支払条件";
            colShiharaiJoken.Name = "支払条件";
            colShiharaiJoken.HeaderText = "支払条件";
            setColumn(gridNyukin, colShiharaiJoken, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShukinKbn = new DataGridViewTextBoxColumn();
            colShukinKbn.DataPropertyName = "集金区分";
            colShukinKbn.Name = "集金区分";
            colShukinKbn.HeaderText = "集金区分";
            setColumn(gridNyukin, colShukinKbn, posCenter, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colMawashisakiNm = new DataGridViewTextBoxColumn();
            colMawashisakiNm.DataPropertyName = "廻し先";
            colMawashisakiNm.Name = "廻し先";
            colMawashisakiNm.HeaderText = "廻し先";
            setColumn(gridNyukin, colMawashisakiNm, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colMawashisakiYMD = new DataGridViewTextBoxColumn();
            colMawashisakiYMD.DataPropertyName = "廻し先日付";
            colMawashisakiYMD.Name = "廻し先日付";
            colMawashisakiYMD.HeaderText = "廻し先日付";
            setColumn(gridNyukin, colMawashisakiYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colBikou = new DataGridViewTextBoxColumn();
            colBikou.DataPropertyName = "備考";
            colBikou.Name = "備考";
            colBikou.HeaderText = "備考";
            setColumn(gridNyukin, colBikou, posLeft, posCenter, fmtString, 122);

            #endregion
        }

        //
        // grid列セット
        //
        private void setColumn(Common.Ctl.BaseDataGridViewEdit gr, DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gr.Columns.Add(col);
            if (gr.Columns[col.Name] != null)
            {
                gr.Columns[col.Name].Width = intLen;
                gr.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gr.Columns[col.Name].HeaderCell.Style.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                gr.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;
                gr.Columns[col.Name].SortMode = DataGridViewColumnSortMode.NotSortable;


                if (fmt != null)
                {
                    gr.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        // キー入力
        private void B1570_NyukinInput_KeyDown(object sender, KeyEventArgs e)
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
                    break;
                case Keys.F1:
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    addShiire();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    delShiire();
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    clearAll();
                    break;
                case Keys.F5:
                    logger.Info(LogUtil.getMessage(this._Title, "行追加"));
                    addRow();
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    logger.Info(LogUtil.getMessage(this._Title, "元帳確認"));
                    showMotocyou();
                    break;
                case Keys.F9:
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    showGrid(0);
                    break;
                case Keys.F10:
                    logger.Info(LogUtil.getMessage(this._Title, "Excel出力実行"));
                    printOut(false);
                    break;
                case Keys.F11:
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    printOut(true);
                    break;
                case Keys.F12:
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        // ボタン押下
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    addShiire();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    delShiire();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    clearAll();
                    break;
                case STR_BTN_F05: // 行追加
                    logger.Info(LogUtil.getMessage(this._Title, "行追加"));
                    addRow();
                    break;
                case STR_BTN_F08: // 元帳確認
                    logger.Info(LogUtil.getMessage(this._Title, "元帳確認"));
                    showMotocyou();
                    break;
                case STR_BTN_F09: // 検索
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    showGrid(0);
                    break;
                case STR_BTN_F10: // Excel出力
                    logger.Info(LogUtil.getMessage(this._Title, "Excel出力実行"));
                    printOut(false);
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    printOut(true);
                    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        // クリック行のデータを入力欄に反映
        private void gridNyukin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            formToGrid();
            rowIdx = e.RowIndex;
            gridToForm();
        }

        private void formToGrid()
        {
            if (!string.IsNullOrWhiteSpace(lsTokuisakiInput.CodeTxtText))
            {
                gridNyukin.Rows[rowIdx].Cells["仕入先コード"].Value = lsTokuisakiInput.CodeTxtText;
                gridNyukin.Rows[rowIdx].Cells["仕入先名"].Value = lsTokuisakiInput.ValueLabelText;
                if (string.IsNullOrWhiteSpace(txtKijitsuInput.Text))
                {
                    gridNyukin.Rows[rowIdx].Cells["手形期日"].Value = DBNull.Value;
                }
                else
                {
                    gridNyukin.Rows[rowIdx].Cells["手形期日"].Value = txtKijitsuInput.chkDateDataFormat(txtKijitsuInput.Text);
                }
                gridNyukin.Rows[rowIdx].Cells["手形期日"].Value = txtKijitsuInput.Text;
                gridNyukin.Rows[rowIdx].Cells["締切日"].Value = txtShimekiribi.Text;
                gridNyukin.Rows[rowIdx].Cells["支払月数"].Value = txtShiharaiMonthInput.Text;
                gridNyukin.Rows[rowIdx].Cells["支払日"].Value = txtShiharaibi.Text;
                gridNyukin.Rows[rowIdx].Cells["集金区分"].Value = txtSyukinKbn.Text;
                gridNyukin.Rows[rowIdx].Cells["取引区分コード"].Value = lsTorihikiCdInput.CodeTxtText;
                gridNyukin.Rows[rowIdx].Cells["取引区分名"].Value = lsTorihikiCdInput.ValueLabelText;
                gridNyukin.Rows[rowIdx].Cells["支払額"].Value = getDecValue(txtNyukinGakuInput.Text);
                gridNyukin.Rows[rowIdx].Cells["支払額"].Value = setNumString(rowIdx, "支払額", fmtNumComma);
                gridNyukin.Rows[rowIdx].Cells["支払条件"].Value = txtShiharaiJoken.Text;
                gridNyukin.Rows[rowIdx].Cells["備考"].Value = txtBikoInput.Text;
                gridNyukin.Rows[rowIdx].Cells["廻し先"].Value = txtMawashisakiInput.Text;
                gridNyukin.Rows[rowIdx].Cells["廻し先日付"].Value = txtMawashisakiYMDInput.Text;
                if (string.IsNullOrWhiteSpace(txtDenpyoYMD.Text))
                {
                    gridNyukin.Rows[rowIdx].Cells["伝票年月日"].Value = DBNull.Value;
                }
                else
                {
                    gridNyukin.Rows[rowIdx].Cells["伝票年月日"].Value = txtDenpyoYMD.chkDateDataFormat(txtDenpyoYMD.Text);
                }
                gridNyukin.Rows[rowIdx].Cells["金融機関名"].Value = txtKinyuInput.Text;
                gridNyukin.Rows[rowIdx].Cells["支店名"].Value = txtShitenInput.Text;
                gridNyukin.Rows[rowIdx].Cells["口座"].Value = txtKozaInput.Text;

            }
        }

        private void gridToForm()
        {
            lsTokuisakiInput.CodeTxtText = getCellValue(rowIdx, "仕入先コード", false);
            lsTokuisakiInput.ValueLabelText = getCellValue(rowIdx, "仕入先名", false);
            txtKijitsuInput.Text = getCellValueYMD(rowIdx, "手形期日", false);

            txtShimekiribi.Text = getCellValue(rowIdx, "締切日", false);
            txtShiharaiMonthInput.Text = getCellValue(rowIdx, "支払月数", false);
            txtShiharaibi.Text = getCellValue(rowIdx, "支払日", false);
            txtSyukinKbn.Text = getCellValue(rowIdx, "集金区分", false);
            lsTorihikiCdInput.CodeTxtText = getCellValue(rowIdx, "取引区分コード", false);
            lsTorihikiCdInput.ValueLabelText = getCellValue(rowIdx, "取引区分名", false);
            txtNyukinGakuInput.Text = getCellValue(rowIdx, "支払額", false);
            if (!string.IsNullOrWhiteSpace(txtNyukinGakuInput.Text))
            {
                txtNyukinGakuInput.Text = getDecValue(getCellValue(rowIdx, "支払額", true)).ToString(fmtNumComma);
            }
            txtShiharaiJoken.Text = getCellValue(rowIdx, "支払条件", false);
            txtBikoInput.Text = getCellValue(rowIdx, "備考", false);
            txtMawashisakiInput.Text = getCellValue(rowIdx, "廻し先", false);
            txtMawashisakiYMDInput.Text = getCellValue(rowIdx, "廻し先日付", false);
            txtDenpyoYMD.Text = getCellValueYMD(rowIdx, "伝票年月日", false);
            txtKinyuInput.Text = getCellValue(rowIdx, "金融機関名", false);
            txtShitenInput.Text = getCellValue(rowIdx, "支店名", false);
            txtKozaInput.Text = getCellValue(rowIdx, "口座", false);

        }

        // 入力欄のデータをグリッド行に反映
        private void gridNyukin_SelectionChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(lsTokuisakiInput.CodeTxtText))
            //{
            //    return;
            //}

            //int rowIdx = gridNyukin.CurrentCell.RowIndex;

            //gridNyukin.Rows[rowIdx].Cells["仕入先コード"].Value   = lsTokuisakiInput.CodeTxtText;
            //gridNyukin.Rows[rowIdx].Cells["仕入先名"].Value       = lsTokuisakiInput.ValueLabelText;
            //gridNyukin.Rows[rowIdx].Cells["手形期日"].Value       = txtKijitsuInput.Text;
            //gridNyukin.Rows[rowIdx].Cells["締切日"].Value         = txtShimekiribi.Text;
            //gridNyukin.Rows[rowIdx].Cells["支払月数"].Value       = txtShiharaiMonthInput.Text;
            //gridNyukin.Rows[rowIdx].Cells["支払日"].Value         = txtShiharaibi.Text;
            //gridNyukin.Rows[rowIdx].Cells["集金区分"].Value       = txtSyukinKbn.Text;
            //gridNyukin.Rows[rowIdx].Cells["取引区分コード"].Value = lsTorihikiCdInput.CodeTxtText;
            //gridNyukin.Rows[rowIdx].Cells["取引区分名"].Value     = lsTorihikiCdInput.ValueLabelText;
            //gridNyukin.Rows[rowIdx].Cells["支払額"].Value         = getDecValue(txtNyukinGakuInput.Text);
            //gridNyukin.Rows[rowIdx].Cells["支払条件"].Value       = txtShiharaiJoken.Text;
            //gridNyukin.Rows[rowIdx].Cells["備考"].Value           = txtBikoInput.Text;
            //gridNyukin.Rows[rowIdx].Cells["廻し先"].Value         = txtMawashisakiInput.Text;
            //gridNyukin.Rows[rowIdx].Cells["廻し先日付"].Value     = txtMawashisakiYMDInput.Text;
        }

        // 検索
        private void showGrid(int noForce)
        {
            B1570_NyukinInput_B bis = new B1570_NyukinInput_B();
            try
            {
                if (noForce == 0 && !chkSearchInput())
                {
                    return;
                }

                // データ検索用
                List<string> lstSearchItem = new List<string>();

                // 検索するデータをリストに格納
                if (noForce == 0)
                {
                    #region 通常検索
                    lstSearchItem.Add(txtInputYMDFr.Text);
                    lstSearchItem.Add(txtInputYMDTo.Text);
                    lstSearchItem.Add(txtDenpyoYMDFr.Text);
                    lstSearchItem.Add(txtDenpyoYMDTo.Text);
                    lstSearchItem.Add(lsTantousha.ValueLabelText);
                    lstSearchItem.Add(txtShiireCdFr.Text);
                    lstSearchItem.Add(txtShiireCdTo.Text);

                    lstSearchItem.Add(createCb());
                    lstSearchItem.Add(txtTegataYMDFr.Text);
                    lstSearchItem.Add(txtTegataYMDTo.Text);
                    lstSearchItem.Add(txtShiharaiYoteiYMDFr.Text);
                    lstSearchItem.Add(txtShiharaiYoteiYMDTo.Text);
                    lstSearchItem.Add(txtKinyu.Text);
                    lstSearchItem.Add(txtShiten.Text);
                    lstSearchItem.Add(txtKouza.Text);
                    lstSearchItem.Add(txtTegataKinyu.Text);
                    lstSearchItem.Add(txtTegataShiten.Text);
                    lstSearchItem.Add(txtTegataKouza.Text);
                    #endregion
                }
                else if (noForce == 1)
                {
                    #region 初期表示用(強制的に0件検索)
                    lstSearchItem.Add("1900/01/01");
                    lstSearchItem.Add("1900/01/01");
                    lstSearchItem.Add("1900/01/01");
                    lstSearchItem.Add("1900/01/01");
                    lstSearchItem.Add("");
                    lstSearchItem.Add("0000");
                    lstSearchItem.Add("0000");
                    lstSearchItem.Add("");
                    lstSearchItem.Add("");
                    lstSearchItem.Add("");
                    lstSearchItem.Add("");
                    lstSearchItem.Add("");
                    lstSearchItem.Add("");
                    lstSearchItem.Add("");
                    lstSearchItem.Add("");
                    lstSearchItem.Add("");
                    lstSearchItem.Add("");
                    lstSearchItem.Add("");
                    #endregion
                }
                else
                {
                    #region 登録完了後
                    if (!string.IsNullOrWhiteSpace(txtInputYMDFr.Text))
                    {
                        lstSearchItem.Add(txtInputYMDFr.Text);
                    }
                    else
                    {
                        lstSearchItem.Add(defInputYmdFr);
                    }

                    if (!string.IsNullOrWhiteSpace(txtInputYMDTo.Text))
                    {
                        lstSearchItem.Add(txtInputYMDTo.Text);
                    }
                    else
                    {
                        lstSearchItem.Add(defInputYmdTo);
                    }

                    if (!string.IsNullOrWhiteSpace(txtDenpyoYMDFr.Text))
                    {
                        lstSearchItem.Add(txtDenpyoYMDFr.Text);
                    }
                    else
                    {
                        lstSearchItem.Add(defDenpyoYmdFr);
                    }

                    if (!string.IsNullOrWhiteSpace(txtDenpyoYMDTo.Text))
                    {
                        lstSearchItem.Add(txtDenpyoYMDTo.Text);
                    }
                    else
                    {
                        lstSearchItem.Add(defDenpyoYmdTo);
                    }

                    lstSearchItem.Add(Environment.UserName);

                    if (!string.IsNullOrWhiteSpace(txtShiireCdFr.Text))
                    {
                        lstSearchItem.Add(txtShiireCdFr.Text);
                    }
                    else
                    {
                        lstSearchItem.Add(defShiireCdFr);
                    }
                    if (!string.IsNullOrWhiteSpace(txtShiireCdTo.Text))
                    {
                        lstSearchItem.Add(txtShiireCdTo.Text);
                    }
                    else
                    {
                        lstSearchItem.Add(defShiireCdTo);
                    }
                    lstSearchItem.Add(createCb());
                    lstSearchItem.Add(txtTegataYMDFr.Text);
                    lstSearchItem.Add(txtTegataYMDTo.Text);
                    lstSearchItem.Add(txtShiharaiYoteiYMDFr.Text);
                    lstSearchItem.Add(txtShiharaiYoteiYMDTo.Text);
                    lstSearchItem.Add(txtKinyu.Text);
                    lstSearchItem.Add(txtShiten.Text);
                    lstSearchItem.Add(txtKouza.Text);
                    lstSearchItem.Add(txtTegataKinyu.Text);
                    lstSearchItem.Add(txtTegataShiten.Text);
                    lstSearchItem.Add(txtTegataKouza.Text);
                    #endregion
                }

                // 検索実行
                inputClear();
                dt = null;
                dt = bis.getShiharaiList(lstSearchItem);

                if (dt != null && dt.Rows.Count > 0)
                {
                    gridNyukin.DataSource = dt;
                }
                else
                {
                    if (noForce == 0)
                    {
                        // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessagebox.ShowDialog();
                    }
                    if (dt != null)
                    {
                        dt.Rows.Add(dt.NewRow());
                        gridNyukin.DataSource = dt;
                    }
                }
                gridNyukin.CurrentCell = gridNyukin.Rows[0].Cells[1];
                rowIdx = gridNyukin.CurrentCell.RowIndex;

                decimal d = 0;
                for (int i = 0; i < gridNyukin.Rows.Count; i++)
                {
                    gridNyukin.Rows[i].Cells["支払額"].Value = setNumString(i, "支払額", fmtNumComma);
                    d += getDecValue(getCellValue(i, "支払額", true));
                }

                txtShiharaiTotal.Text = d.ToString(fmtNumComma);
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

        private string createCb()
        {
            string ret = "";
            if (cbTegataGenkin.Checked)
            {
                ret += "'31', ";
            }
            if (cbTegataHurikomi.Checked)
            {
                ret += "'33', ";
            }
            if (cbTegataKogitte.Checked)
            {
                ret += "'32', ";
            }
            if (cbTegataSonota.Checked)
            {
                ret += "'37', ";
            }
            if (cbTegataSousai.Checked)
            {
                ret += "'35', ";
            }
            if (cbTegataTegata.Checked)
            {
                ret += "'34', ";
            }
            if (cbTegataTesuuryo.Checked)
            {
                ret += "'36', ";
            }
            if (cbTegataUragaki.Checked)
            {
                ret += "'38', ";
            }
            if (!string.IsNullOrWhiteSpace(ret))
            {
                ret = ret.Substring(0, ret.Length - 2);
            }
            return ret;
        }

        // 登録
        private void addShiire()
        {
            if (gridNyukin.Rows == null || gridNyukin.Rows.Count == 0)
            {
                return;
            }
            formToGrid();
            rowIdx = gridNyukin.CurrentCell.RowIndex;
            gridToForm();

            B1570_NyukinInput_B bis = new B1570_NyukinInput_B();
            try
            {
                if (!chkGridInput())
                {
                    return;
                }

                List<string[]> lsInput = new List<string[]>();

                for (int i = 0; i < gridNyukin.Rows.Count; i++)
                {
                    string[] strs = new string[14];

                    if (string.IsNullOrWhiteSpace(getCellValue(i, "伝票年月日", false)))
                    {
                        continue;
                    }

                    if (!string.IsNullOrWhiteSpace(getCellValue(i, "伝票番号", false)))
                    {
                        strs[0] = getCellValue(i, "伝票番号", false);
                    }
                    else
                    {
                        strs[0] = bis.getDenpyoNo();
                    }

                    if (!string.IsNullOrWhiteSpace(getCellValue(i, "行番号", false)))
                    {
                        strs[1] = getCellValue(i, "行番号", false);
                    }
                    else
                    {
                        strs[1] = "1";
                    }

                    strs[2] = getCellValueYMD(i, "伝票年月日", false);
                    strs[3] = getCellValue(i, "仕入先コード", false);
                    strs[4] = getCellValue(i, "取引区分コード", false);
                    strs[5] = getCellValue(i, "支払額", false);
                    strs[6] = getCellValueYMD(i, "手形期日", false);
                    strs[7] = getCellValue(i, "備考", false);
                    strs[8] = getCellValue(i, "廻し先", false);
                    strs[9] = getCellValue(i, "廻し先日付", false);
                    strs[10] = getCellValue(i, "金融機関名", false);
                    strs[11] = getCellValue(i, "支店名", false);
                    strs[12] = getCellValue(i, "口座", false);
                    strs[13] = Environment.UserName;

                    lsInput.Add(strs);
                }

                if (lsInput.Count > 0)
                {
                    // 登録実行
                    bis.addShiire(lsInput);

                    // メッセージボックスの処理、追加成功の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                }

                inputClear();
                showGrid(2);

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、追加失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

            }
        }

        // 削除
        private void delShiire()
        {
            B1570_NyukinInput_B bis = new B1570_NyukinInput_B();
            try
            {
                // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "選択中のデータを削除します。よろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                // NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                string[] strDeleteItem = new String[3];

                if (!string.IsNullOrWhiteSpace(getCellValue(gridNyukin.CurrentCell.RowIndex, "伝票番号", false)))
                {
                    strDeleteItem[0] = getCellValue(gridNyukin.CurrentCell.RowIndex, "伝票番号", false);
                    strDeleteItem[1] = getCellValue(gridNyukin.CurrentCell.RowIndex, "行番号", false);
                    strDeleteItem[2] = Environment.UserName;

                    // 削除実行
                    bis.delShiire(strDeleteItem);
                }

                dt.Rows.RemoveAt(gridNyukin.CurrentCell.RowIndex);
                inputClear();

                if (gridNyukin.Rows.Count == 0)
                {
                    dt.Rows.InsertAt(dt.NewRow(), 0);
                    rowIdx = 0;
                }
                else if (rowIdx >= gridNyukin.Rows.Count)
                {
                    rowIdx = gridNyukin.Rows.Count - 1;
                }

                // メッセージボックスの処理、削除成功の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                inputClear();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "削除が失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

            }
        }

        // 行追加
        private void addRow()
        {
            if (gridNyukin.CurrentCell == null)
            {
                return;
            }
            int rNum = gridNyukin.CurrentCell.RowIndex;
            dt.Rows.InsertAt(dt.NewRow(), rNum);
            gridNyukin.CurrentCell = gridNyukin.Rows[rNum].Cells[1];
            inputClear();
            rowIdx = rNum;
        }

        /// 得意先元帳確認フォームを開く
        private void showMotocyou()
        {
            // 仕入先コードがある場合
            if (gridNyukin.CurrentCell != null && !string.IsNullOrWhiteSpace(getCellValue(gridNyukin.CurrentCell.RowIndex, "仕入先コード", false)))
            {
                // 仕入先元帳確認フォームを開く
                E0340_SiiresakiMotochouKakunin.E0340_SiiresakiMotochouKakunin tokuisaki =
                    new E0340_SiiresakiMotochouKakunin.E0340_SiiresakiMotochouKakunin(this, 6, getCellValue(gridNyukin.CurrentCell.RowIndex, "仕入先コード", false));
                tokuisaki.ShowDialog();
            }
        }

        // 印刷
        private void printOut(bool paper)
        {
            B1570_NyukinInput_B bis = new B1570_NyukinInput_B();

            try
            {
                // 入力チェック
                if (!chkSearchInput())
                {
                    return;
                }

                // データ検索用
                List<string> lstSearchItem = new List<string>();

                lstSearchItem.Add(txtInputYMDFr.Text);
                lstSearchItem.Add(txtInputYMDTo.Text);
                lstSearchItem.Add(txtDenpyoYMDFr.Text);
                lstSearchItem.Add(txtDenpyoYMDTo.Text);
                lstSearchItem.Add(lsTantousha.ValueLabelText);
                lstSearchItem.Add(txtShiireCdFr.Text);
                lstSearchItem.Add(txtShiireCdTo.Text);

                lstSearchItem.Add(createCb());
                lstSearchItem.Add(txtTegataYMDFr.Text);
                lstSearchItem.Add(txtTegataYMDTo.Text);
                lstSearchItem.Add(txtShiharaiYoteiYMDFr.Text);
                lstSearchItem.Add(txtShiharaiYoteiYMDTo.Text);
                lstSearchItem.Add(txtKinyu.Text);
                lstSearchItem.Add(txtShiten.Text);
                lstSearchItem.Add(txtKouza.Text);
                lstSearchItem.Add(txtTegataKinyu.Text);
                lstSearchItem.Add(txtTegataShiten.Text);
                lstSearchItem.Add(txtTegataKouza.Text);

                DataTable dtp = bis.getShiharaiList(lstSearchItem);

                if (dtp == null || dtp.Rows.Count == 0)
                {
                    // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                // 印刷
                //if (paper)
                //{
                //    // 印刷ダイアログ
                //    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, CommonTeisu.YOKO);
                //    pf.ShowDialog(this);

                //    // プレビューの場合
                //    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                //    {
                //        // PDF作成
                //        String strFile = bis.dbToPdf(dtp, lstSearchItem);

                //        // プレビュー
                //        pf.execPreview(strFile);

                //    }
                //    // 一括印刷の場合
                //    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                //    {
                //        // PDF作成
                //        String strFile = bis.dbToPdf(dtp, lstSearchItem);

                //        // 一括印刷
                //        pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
                //    }
                //    pf.Dispose();
                //}
                //// Excel出力
                //else
                //{
                //    string std = DateTime.Now.ToString("_yyyy_MM_dd_HH_mm");
                //    SaveFileDialog sfd = new SaveFileDialog();
                //    sfd.FileName = "支払チェックリスト" + std + ".xlsx";

                //    if (sfd.ShowDialog() == DialogResult.OK)
                //    {
                //        bis.dbToXls(dtp, lstSearchItem, sfd.FileName);
                //    }

                //}

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

        // 締切日、支払月数、支払日、支払条件、集金区分表示
        private void lsTokuisakiInput_Leave(object sender, EventArgs e)
        {
            getSiiresakiData();
        }

        private void getSiiresakiData()
        {
            // データ検索用
            List<string> lstSiiresakiDataLoad = new List<string>();

            // 検索時のデータ取り出し先
            DataTable dtSetView;

            // 空文字判定（仕入先コード）
            if (lsTokuisakiInput.CodeTxtText.Equals(""))
            {
                return;
            }

            // ビジネス層のインスタンス生成
            B0060_ShiharaiInput_B shiharaiInputB = new B0060_ShiharaiInput_B();
            try
            {
                // データの存在確認を検索する情報を入れる
                /* [0]仕入先コード */
                lstSiiresakiDataLoad.Add(lsTokuisakiInput.CodeTxtText);

                // ビジネス層、取引先情報表示用ロジックに移動
                dtSetView = shiharaiInputB.getSiiresakiData(lstSiiresakiDataLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    txtShimekiribi.Text = dtSetView.Rows[0]["締切日"].ToString();
                    txtShiharaiMonthInput.Text = dtSetView.Rows[0]["支払月数"].ToString();
                    txtShiharaibi.Text = dtSetView.Rows[0]["支払日"].ToString();
                    txtShiharaiJoken.Text = dtSetView.Rows[0]["支払条件"].ToString().Trim();
                    txtSyukinKbn.Text = dtSetView.Rows[0]["集金区分"].ToString();
                    //ginko = dtSetView.Rows[0]["銀行名"].ToString();
                    //shiten = dtSetView.Rows[0]["支店名"].ToString();
                    //koza = dtSetView.Rows[0]["口座種別"].ToString();
                    //txtZeiHasuuKubun.Text = dtSetView.Rows[0]["消費税端数計算区分"].ToString();
                }
                else
                {
                    txtShimekiribi.Text = "";
                    txtShiharaiMonthInput.Text = "";
                    txtShiharaibi.Text = "";
                    txtShiharaiJoken.Text = "";
                    txtSyukinKbn.Text = "";
                    //ginko = "";
                    //shiten = "";
                    //koza = "";
                    //txtZeiHasuuKubun.Text = "";
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

        private void txtBikoInput_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.PageUp:
                    break;
                case Keys.PageDown:
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
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
                    break;
                case Keys.F12:
                    break;
            }

            return;
        }

        private void txtMawashisakiYMDInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDenpyoYMD.Text)
                || string.IsNullOrWhiteSpace(lsTokuisakiInput.CodeTxtText)
                || string.IsNullOrWhiteSpace(lsTorihikiCdInput.CodeTxtText)
                || string.IsNullOrWhiteSpace(txtNyukinGakuInput.Text))
            {
                return;
            }
            formToGrid();
            rowIdx = gridNyukin.CurrentCell.RowIndex;
            gridToForm();
        }

        private void lsTantousha_Leave(object sender, EventArgs e)
        {
            setTanto(false);
        }

        // サブ画面表示
        private void cmbSubWinShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubWinShow.SelectedIndex == 0)
            {
                subShow();
            }
        }

        private void subShow()
        {
            B0060_ShiharaiInput_B siireB = new B0060_ShiharaiInput_B();
            try
            {
                // データ検索用
                List<string> lstSearchItem = new List<string>();

                if (gridNyukin.CurrentCell == null || string.IsNullOrWhiteSpace(getCellValue(gridNyukin.CurrentCell.RowIndex, "仕入先コード", false)))
                {
                    return;
                }

                lstSearchItem.Add(getCellValue(gridNyukin.CurrentCell.RowIndex, "仕入先コード", false));       // 仕入先コード
                lstSearchItem.Add(getCellValue(gridNyukin.CurrentCell.RowIndex, "締切日", false));             // 締切日
                lstSearchItem.Add(getCellValue(gridNyukin.CurrentCell.RowIndex, "消費税端数計算区分", false)); // 消費税端数計算区分

                DataTable dt = siireB.getSiireJissekiList(lstSearchItem);

                B1571_SeikyuRireki f = new B1571_SeikyuRireki(this, dt);

                Screen s = null;
                Screen[] argScreen = Screen.AllScreens;
                if (argScreen.Length > 1)
                {
                    s = argScreen[1];
                }
                else
                {
                    s = argScreen[0];
                }

                f.StartPosition = FormStartPosition.Manual;
                f.Location = s.Bounds.Location;

                f.Show();
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

        // util
        // cellの値を文字列で取得
        private string getCellValue(int rowIdx, string col, bool zero)
        {
            string ret = "";

            DataGridViewCell c = gridNyukin.Rows[rowIdx].Cells[col];

            if (zero)
            {
                ret = "0";
            }

            if (c != null && c.Value != null && c.Value != DBNull.Value && !string.IsNullOrWhiteSpace(c.Value.ToString()))
            {
                ret = c.Value.ToString();
            }
            return ret;
        }

        private string getCellValueYMD(int rowIdx, string col, bool zero)
        {
            string ret = "";

            DataGridViewCell c = gridNyukin.Rows[rowIdx].Cells[col];

            if (zero)
            {
                ret = "0";
            }

            if (c != null && c.Value != null && c.Value != DBNull.Value && !string.IsNullOrWhiteSpace(c.Value.ToString()))
            {
                ret = c.Value.ToString();

                if (DateTime.Parse(ret).ToString("yyyy/MM/dd").CompareTo("0001/01/01") <= 0)
                {
                    ret = "";
                }
                else
                {
                    ret = DateTime.Parse(ret).ToString("yyyy/MM/dd");
                }

            }

            return ret;
        }

        // 文字列を decimalで取得
        public decimal getDecValue(string s)
        {
            decimal d = 0;

            if (!string.IsNullOrWhiteSpace(s))
            {
                try
                {
                    d = decimal.Parse(s);
                }
                catch (Exception e)
                {
                }
            }

            return d;
        }

        // "0"をブランクに変換
        private string zeroToBlank(String s)
        {
            string ret = "";
            decimal d = 0;

            if (!string.IsNullOrEmpty(s))
            {
                try
                {
                    d = decimal.Parse(s);
                }
                catch (Exception e)
                {
                    // 数値以外の値なのでそのまま返す
                    return s;
                }
            }
            if (!d.Equals(0))
            {
                ret = s;
            }
            return ret;

        }

        private string setNumString(int rowIdx, string col, string s)
        {
            decimal d = 0;

            if (string.IsNullOrWhiteSpace((getCellValue(rowIdx, col, false))))
            {
                return "";
            }

            d = Decimal.Parse(getCellValue(rowIdx, col, false));
            return (decimal.Round(d, 0)).ToString(s);
        }

        // 入力チェック
        private bool chkSearchInput()
        {
            // 空文字判定（入力年月日（開始））
            if (txtInputYMDFr.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtInputYMDFr.Focus();

                return false;
            }

            // 空文字判定（入力年月日（終了））
            if (txtInputYMDTo.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtInputYMDTo.Focus();

                return false;
            }

            // 空文字判定（伝票年月日（開始））
            if (txtDenpyoYMDFr.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDFr.Focus();

                return false;
            }

            // 空文字判定（伝票年月日（終了））
            if (txtDenpyoYMDTo.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDTo.Focus();

                return false;
            }

            // 空文字判定（仕入先コード）from なし　to　あり　エラー
            if (string.IsNullOrWhiteSpace(txtShiireCdFr.Text) && string.IsNullOrWhiteSpace(txtShiireCdTo.Text))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。仕入先を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtShiireCdFr.Focus();
                return false;
            }
            // 日付フォーマットチェック（入力年月日（開始））
            string datedata = txtInputYMDFr.chkDateDataFormat(txtInputYMDFr.Text);
            if ("".Equals(datedata))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return false;
            }
            else
            {
                txtInputYMDFr.Text = datedata;
            }

            // 日付フォーマットチェック（入力年月日（終了））
            datedata = txtInputYMDTo.chkDateDataFormat(txtInputYMDTo.Text);
            if ("".Equals(datedata))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return false;
            }
            else
            {
                txtInputYMDTo.Text = datedata;
            }

            // 日付フォーマットチェック（伝票年月日（開始））
            datedata = txtDenpyoYMDFr.chkDateDataFormat(txtDenpyoYMDFr.Text);
            if ("".Equals(datedata))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return false;
            }
            else
            {
                txtDenpyoYMDFr.Text = datedata;
            }

            // 日付フォーマットチェック（伝票年月日（終了））
            datedata = txtDenpyoYMDTo.chkDateDataFormat(txtDenpyoYMDTo.Text);
            if ("".Equals(datedata))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return false;
            }
            else
            {
                txtDenpyoYMDTo.Text = datedata;
            }
            return true;
        }

        private bool chkGridInput()
        {
            string strChkYMD = "";
            string strChkShiire = "";
            string strChkKbn = "";
            string strChkGaku = "";

            for (int i = 0; i < gridNyukin.Rows.Count; i++)
            {
                strChkYMD = getCellValueYMD(rowIdx, "伝票年月日", false);
                strChkShiire = getCellValue(rowIdx, "仕入先コード", false);
                strChkKbn = getCellValue(rowIdx, "取引区分コード", false);
                strChkGaku = getCellValue(rowIdx, "支払額", false);

                // 入力必須項目全てに入力のない行は空行扱いとする
                if (string.IsNullOrWhiteSpace(strChkYMD)
                    && string.IsNullOrWhiteSpace(strChkShiire)
                    && string.IsNullOrWhiteSpace(strChkKbn)
                    && string.IsNullOrWhiteSpace(strChkGaku))
                {
                    continue;
                }

                #region 必須入力チェック
                // 伝票年月日
                if (string.IsNullOrWhiteSpace(strChkYMD))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    gridNyukin.CurrentCell = gridNyukin.Rows[i].Cells[1];
                    rowIdx = gridNyukin.CurrentCell.RowIndex;
                    gridToForm();
                    txtDenpyoYMD.Focus();
                    return false;
                }
                // 仕入先
                if (string.IsNullOrWhiteSpace(strChkShiire))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    gridNyukin.CurrentCell = gridNyukin.Rows[i].Cells[1];
                    rowIdx = gridNyukin.CurrentCell.RowIndex;
                    gridToForm();
                    lsTokuisakiInput.codeTxt.Focus();
                    return false;
                }
                // 取引区分
                if (string.IsNullOrWhiteSpace(strChkKbn))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    gridNyukin.CurrentCell = gridNyukin.Rows[i].Cells[1];
                    rowIdx = gridNyukin.CurrentCell.RowIndex;
                    gridToForm();
                    lsTorihikiCdInput.codeTxt.Focus();
                    return false;
                }
                // 支払額
                if (string.IsNullOrWhiteSpace(strChkShiire))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。金額を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    gridNyukin.CurrentCell = gridNyukin.Rows[i].Cells[1];
                    rowIdx = gridNyukin.CurrentCell.RowIndex;
                    gridToForm();
                    lsTokuisakiInput.codeTxt.Focus();
                    return false;
                }
                #endregion

                // 日付制限
                if (!chkDate(strChkYMD))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "日付が範囲外です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    gridNyukin.CurrentCell = gridNyukin.Rows[i].Cells[1];
                    rowIdx = gridNyukin.CurrentCell.RowIndex;
                    gridToForm();
                    txtDenpyoYMD.Focus();
                    return false;
                }
            }

            return true;
        }
        // クリア
        private void clearAll()
        {
            searchClear();
            inputClear();
            showGrid(1);
        }

        private void searchClear()
        {
            txtInputYMDFr.Text = "";
            txtInputYMDTo.Text = "";
            txtDenpyoYMDFr.Text = "";
            txtDenpyoYMDTo.Text = "";
            txtShiireCdFr.Text = "";
            txtShiireCdTo.Text = "";
            lsTantousha.CodeTxtText = "";
            lsTantousha.ValueLabelText = "";

            cbTegataGenkin.Checked = false;
            cbTegataHurikomi.Checked = false;
            cbTegataKogitte.Checked = false;
            cbTegataSonota.Checked = false;
            cbTegataSousai.Checked = false;
            cbTegataTegata.Checked = false;
            cbTegataTesuuryo.Checked = false;
            cbTegataUragaki.Checked = false;

            txtTegataYMDFr.Text = "";
            txtTegataYMDTo.Text = "";
            txtShiharaiYoteiYMDFr.Text = "";
            txtShiharaiYoteiYMDTo.Text = "";

            txtKinyu.Text = "";
            txtShiten.Text = "";
            txtKouza.Text = "";

            txtTegataKinyu.Text = "";
            txtTegataShiten.Text = "";
            txtTegataKouza.Text = "";
        }

        private void inputClear()
        {
            txtDenpyoYMD.Text = "";
            lsTokuisakiInput.CodeTxtText = "";
            lsTokuisakiInput.ValueLabelText = "";
            txtKijitsuInput.Text = "";
            txtShimekiribi.Text = "";
            txtShiharaiMonthInput.Text = "";
            txtShiharaibi.Text = "";
            txtSyukinKbn.Text = "";
            lsTorihikiCdInput.CodeTxtText = "";
            lsTorihikiCdInput.ValueLabelText = "";
            txtNyukinGakuInput.Text = "";
            txtShiharaiJoken.Text = "";
            txtBikoInput.Text = "";
            txtMawashisakiInput.Text = "";
            txtMawashisakiYMDInput.Text = "";
            txtKinyuInput.Text = "";
            txtShitenInput.Text = "";
            txtKozaInput.Text = "";

        }

        // 担当者取得
        private void setTanto(bool force)
        {
            DataTable dtTantoshaCd = new DataTable();

            B0060_ShiharaiInput_B shiharaiinputB = new B0060_ShiharaiInput_B();
            try
            {
                string s = "";
                if (force)
                {
                    s = SystemInformation.UserName;
                }
                else
                {
                    s = lsTantousha.CodeTxtText;
                }

                if (string.IsNullOrWhiteSpace(s))
                {
                    return;
                }
                //ログインＩＤから担当者コードを取り出す
                dtTantoshaCd = shiharaiinputB.getTantoshaCd(SystemInformation.UserName);

                //担当者データがある場合
                if (dtTantoshaCd.Rows.Count > 0)
                {
                    //一行目にデータがない場合
                    if (dtTantoshaCd.Rows[0]["担当者コード"].ToString() == "")
                    {
                        return;
                    }
                }

                lsTantousha.CodeTxtText = dtTantoshaCd.Rows[0]["担当者コード"].ToString();
                lsTantousha.chkTxtTantosha();
                eigyosho = dtTantoshaCd.Rows[0]["営業所コード"].ToString();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        // 日付制限チェック
        private bool chkDate(string st)
        {
            B0060_ShiharaiInput_B shiharaiinputB = new B0060_ShiharaiInput_B();
            try
            {
                // 日付制限テーブルから最小年月日、最大年月日を取得
                DataTable dtDate = shiharaiinputB.getDate(eigyosho);

                if (dtDate.Rows.Count > 0)
                {
                    DateTime dtMinDate = DateTime.Parse(dtDate.Rows[0]["最小年月日"].ToString());
                    DateTime dtMaxDate = DateTime.Parse(dtDate.Rows[0]["最大年月日"].ToString());
                    DateTime dtDenpyoYMD = DateTime.Parse(st);

                    // 伝票年月日が最小年月日から最大年月日の間の場合
                    if (dtMinDate <= dtDenpyoYMD && dtDenpyoYMD <= dtMaxDate)
                    {
                        return true;
                    }
                    else
                    {
                        // メッセージボックスの処理、日付が範囲外の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "日付が範囲外です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;

            }
        }

    }

}
