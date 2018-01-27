using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.M1240_ShohinSiireKakakuSuii2;
using System.Reflection;

namespace KATO.Form.M1240_ShohinSiireKakakuSuii2
{
    /// <summary>
    /// M1240_ShohinSiireKakakuSuii2
    /// 商品仕入単価推移２フォーム
    /// 作成者：多田
    /// 作成日：2017/8/4
    /// 更新者：多田
    /// 更新日：2017/8/4
    /// カラム論理名
    /// </summary>
    public partial class M1240_ShohinSiireKakakuSuii2 : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // グリッドビューの選択行
        private int rowIndex = 0;

        // SPAdminUser
        private string strSPAdminUser = Environment.UserName;

        /// <summary>
        ///     M1240_ShohinSiireKakakuSuii2
        ///     フォーム関係の設定
        /// </summary>
        public M1240_ShohinSiireKakakuSuii2(Control c)
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

            // 中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            // メーカーsetデータを読めるようにする
            labelSet_Daibunrui.Lsmakerdata = labelSet_Maker;

        }

        /// <summary>
        ///     M1240_ShohinSiireKakakuSuii2_Load
        ///     読み込み時
        /// </summary>
        private void M1240_ShohinSiireKakakuSuii2_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品仕入単価推移２";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF07.Text = "評価単価登録";
            this.btnF10.Text = "F10:EXCEL";
            this.btnF12.Text = STR_FUNC_F12;

            this.btnF10.Enabled = false;

            // 基準年月日を設定
            txtKijunYmd.Text = this.getMaxZaikoDate();

            // SPAdminUserの場合
            if (strSPAdminUser.Equals("ゲストユーザー"))
            {
                lblShohinCd.Visible = true;
                txtShohinCd.Visible = true;
            }

            // 初期表示
            txtKijunYmd.Focus();
            labelSet_Daibunrui.Focus();

            // DataGridViewの初期設定
            SetUpGridShohin();
            SetUpGridSiire();
            SetUpGridUriage();

            //gridShohin.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        #region 各グリッドのカラム設定（3grid分）
        /// <summary>
        ///     SetUpGridShohin
        ///     DataGridView初期設定
        /// </summary>
        private void SetUpGridShohin()
        {
            // 列自動生成禁止
            gridShohin.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn shohinCd = new DataGridViewTextBoxColumn();
            shohinCd.DataPropertyName = "商品コード";
            shohinCd.Name = "商品コード";
            shohinCd.HeaderText = "商品コード";

            DataGridViewTextBoxColumn uriage = new DataGridViewTextBoxColumn();
            uriage.DataPropertyName = "売上";
            uriage.Name = "売上";
            uriage.HeaderText = "売";

            DataGridViewTextBoxColumn siire = new DataGridViewTextBoxColumn();
            siire.DataPropertyName = "仕入";
            siire.Name = "仕入";
            siire.HeaderText = "仕";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー名";
            maker.Name = "メーカー名";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "型番";
            kataban.Name = "型番";
            kataban.HeaderText = "型番";

            DataGridViewTextBoxColumn zaiko = new DataGridViewTextBoxColumn();
            zaiko.DataPropertyName = "在庫数量";
            zaiko.Name = "在庫数量";
            zaiko.HeaderText = "在庫数";

            DataGridViewTextBoxColumn teika = new DataGridViewTextBoxColumn();
            teika.DataPropertyName = "定価";
            teika.Name = "定価";
            teika.HeaderText = "定価";

            DataGridViewTextBoxColumn hyokaTanka = new DataGridViewTextBoxColumn();
            hyokaTanka.DataPropertyName = "評価単価";
            hyokaTanka.Name = "評価単価";
            hyokaTanka.HeaderText = "評価単価";

            DataGridViewTextBoxColumn ritsu = new DataGridViewTextBoxColumn();
            ritsu.DataPropertyName = "掛率";
            ritsu.Name = "掛率";
            ritsu.HeaderText = "掛率";

            DataGridViewTextBoxColumn kariTanka = new DataGridViewTextBoxColumn();
            kariTanka.DataPropertyName = "仮単価";
            kariTanka.Name = "仮単価";
            kariTanka.HeaderText = "設定単価";

            DataGridViewTextBoxColumn kariRitsu = new DataGridViewTextBoxColumn();
            kariRitsu.DataPropertyName = "仮掛率";
            kariRitsu.Name = "仮掛率";
            kariRitsu.HeaderText = "掛率";

            DataGridViewTextBoxColumn uriageTanka = new DataGridViewTextBoxColumn();
            uriageTanka.DataPropertyName = "最終売上単価";
            uriageTanka.Name = "最終売上単価";
            uriageTanka.HeaderText = "終売単価";

            DataGridViewTextBoxColumn uriageRitsu = new DataGridViewTextBoxColumn();
            uriageRitsu.DataPropertyName = "売掛率";
            uriageRitsu.Name = "売掛率";
            uriageRitsu.HeaderText = "掛率";

            DataGridViewTextBoxColumn uriageDate = new DataGridViewTextBoxColumn();
            uriageDate.DataPropertyName = "最終売上日";
            uriageDate.Name = "最終売上日";
            uriageDate.HeaderText = "最終売上日";

            DataGridViewTextBoxColumn siireTanka = new DataGridViewTextBoxColumn();
            siireTanka.DataPropertyName = "最終仕入単価";
            siireTanka.Name = "最終仕入単価";
            siireTanka.HeaderText = "終入単価";

            DataGridViewTextBoxColumn siireRitsu = new DataGridViewTextBoxColumn();
            siireRitsu.DataPropertyName = "入掛率";
            siireRitsu.Name = "入掛率";
            siireRitsu.HeaderText = "掛率";

            DataGridViewTextBoxColumn siireDate = new DataGridViewTextBoxColumn();
            siireDate.DataPropertyName = "最終仕入日";
            siireDate.Name = "最終仕入日";
            siireDate.HeaderText = "最終仕入日";

            // 個々の幅、文字の寄せ
            setColumnShohin(shohinCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnShohin(uriage, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, 30);
            setColumnShohin(siire, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, 30);
            setColumnShohin(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumnShohin(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 530);
            setColumnShohin(zaiko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,##0", 80);
            setColumnShohin(teika, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,##0", 100);
            setColumnShohin(hyokaTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,##0", 100);
            setColumnShohin(ritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0.0", 70);
            setColumnShohin(kariTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,##0", 100);
            setColumnShohin(kariRitsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0.0", 80);
            setColumnShohin(uriageTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,##0", 100);
            setColumnShohin(uriageRitsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0.0", 80);
            setColumnShohin(uriageDate, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 120);
            setColumnShohin(siireTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,##0", 100);
            setColumnShohin(siireRitsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0.0", 80);
            setColumnShohin(siireDate, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 120);

            // 商品コードのカラム非表示
            gridShohin.Columns[0].Visible = false;
        }

        /// <summary>
        ///     SetUpGridSiire
        ///     DataGridView初期設定
        /// </summary>
        private void SetUpGridSiire()
        {
            // 列自動生成禁止
            gridSiire.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn shohinCd = new DataGridViewTextBoxColumn();
            shohinCd.DataPropertyName = "商品コード";
            shohinCd.Name = "商品コード";
            shohinCd.HeaderText = "商品コード";

            DataGridViewTextBoxColumn siireDate = new DataGridViewTextBoxColumn();
            siireDate.DataPropertyName = "仕入日";
            siireDate.Name = "仕入日";
            siireDate.HeaderText = "仕入日";

            DataGridViewTextBoxColumn siireTanka = new DataGridViewTextBoxColumn();
            siireTanka.DataPropertyName = "仕入単価";
            siireTanka.Name = "仕入単価";
            siireTanka.HeaderText = "仕入単価";

            // 個々の幅、文字の寄せ
            setColumnSiire(shohinCd, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnSiire(siireDate, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 100);
            setColumnSiire(siireTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,##0", 120);
            
            // 商品コードのカラム非表示
            gridSiire.Columns[0].Visible = false;
        }

        /// <summary>
        ///     SetUpGridUriage
        ///     DataGridView初期設定
        /// </summary>
        private void SetUpGridUriage()
        {
            // 列自動生成禁止
            gridUriage.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn shohinCd = new DataGridViewTextBoxColumn();
            shohinCd.DataPropertyName = "商品コード";
            shohinCd.Name = "商品コード";
            shohinCd.HeaderText = "商品コード";

            DataGridViewTextBoxColumn uriageDate = new DataGridViewTextBoxColumn();
            uriageDate.DataPropertyName = "売上日";
            uriageDate.Name = "売上日";
            uriageDate.HeaderText = "売上日";

            DataGridViewTextBoxColumn uriageTanka = new DataGridViewTextBoxColumn();
            uriageTanka.DataPropertyName = "売上単価";
            uriageTanka.Name = "売上単価";
            uriageTanka.HeaderText = "売上単価";

            // 個々の幅、文字の寄せ
            setColumnUriage(shohinCd, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnUriage(uriageDate, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 100);
            setColumnUriage(uriageTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,##0", 120);

            // 商品コードのカラム非表示
            gridUriage.Columns[0].Visible = false;
        }
        #endregion

        #region 各グリッドのスタイル設定メソッド（3grid分）
        /// <summary>
        ///     setColumn
        ///     DataGridViewの内部設定
        /// </summary>
        private void setColumnShohin(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridShohin.Columns.Add(col);
            if (gridShohin.Columns[col.Name] != null)
            {
                gridShohin.Columns[col.Name].Width = intLen;
                gridShohin.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridShohin.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridShohin.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        ///     setColumnSiire
        ///     DataGridViewの内部設定
        /// </summary>
        private void setColumnSiire(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
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
        ///     setColumn
        ///     DataGridViewの内部設定
        /// </summary>
        private void setColumnUriage(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridUriage.Columns.Add(col);
            if (gridUriage.Columns[col.Name] != null)
            {
                gridUriage.Columns[col.Name].Width = intLen;
                gridUriage.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridUriage.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridUriage.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }
        #endregion

        /// <summary>
        ///     M1240_ShohinSiireKakakuSuii2_KeyDown
        ///     キー入力判定
        /// </summary>
        private void M1240_ShohinSiireKakakuSuii2_KeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "評価単価登録実行"));
                    this.updHyokaTanka();
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    if (this.btnF10.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "Excel実行"));
                        this.outputExcel();
                    }
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
        ///     judBtnClick
        ///     Form上のFunctionボタンクリック
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F07: // 評価単価登録
                    logger.Info(LogUtil.getMessage(this._Title, "評価単価登録実行"));
                    this.updHyokaTanka();
                    break;
                case STR_BTN_F10: // Excel
                    if (this.btnF10.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "Excel実行"));
                        this.outputExcel();
                    }
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        ///     btnCyokkinUpdate_Click
        ///     検索ボタンを押した時の処理
        /// </summary>
        private void btnSerach_Click(object sender, EventArgs e)
        {
            // カーソルを待機状態にする
            this.Cursor = Cursors.WaitCursor;

            // 検索
            this.search();

            // grid上に1件でもデータが存在すればF10を許可
            if (this.gridShohin.Rows.Count > 0)
            {
                this.btnF10.Enabled = true;
            }
            else
            {
                this.btnF10.Enabled = false;
            }
            // カーソルを元に戻す
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        ///     btnCyokkinUpdate_Click
        ///     データ作成ボタンを押した時の処理
        /// </summary>
        private void btnDataCreate_Click(object sender, EventArgs e)
        {
            // データ作成
            this.dataCreate();
        }

        /// <summary>
        ///     btnCyokkinUpdate_Click
        ///     更新ボタンを押した時の処理
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 設定単価更新
            this.updSetteiTanka();
        }

        /// <summary>
        ///     btnCyokkinUpdate_Click
        ///     一覧の型番の設定単価に直近仕入単価をセットボタンを押した時の処理
        /// </summary>
        private void btnCyokkinUpdate_Click(object sender, EventArgs e)
        {
            // 直近単価更新
            this.updCyokkinTanka();
        }

        /// <summary>
        ///     gridShohin_RowEnter
        ///     グリッドビューの行が選択されたときの処理
        /// </summary>
        private void gridShohin_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // グリッドビューにデータがない場合
            if (gridShohin.RowCount == 0)
            {
                return;
            }

            rowIndex = e.RowIndex;

            string strShohinCd = gridShohin.Rows[rowIndex].Cells[0].Value.ToString();

            // ビジネス層のインスタンス生成
            M1240_ShohinSiireKakakuSuii2_B suii_B = new M1240_ShohinSiireKakakuSuii2_B();
            try
            {
                // 仕入日、仕入単価を取得
                DataTable dtSiire = suii_B.getSiire(strShohinCd);
                gridSiire.DataSource = dtSiire;

                // 売上日、売上単価を取得
                DataTable dtUriage = suii_B.getUriage(strShohinCd);
                gridUriage.DataSource = dtUriage;
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
            txtHyokaTanka.Text = string.Format("{0:#,##0}", decimal.Parse(gridShohin.Rows[rowIndex].Cells[7].Value.ToString()));
            txtSetteiTanka.Text = string.Format("{0:#,##0}", decimal.Parse(gridShohin.Rows[rowIndex].Cells[9].Value.ToString()));
            txtShohinCd.Text = strShohinCd;
        }

        /// <summary>
        ///     txtKijunYmd_Leave
        ///     基準年月日からフォーカスが外れた時
        /// </summary>
        private void txtKijunYmd_Leave(object sender, EventArgs e)
        {
            txtKingakuHyoka.Text = "";
            txtKingakuSettei.Text = "";

            try
            {
                // 在庫金額合計にセット
                this.setZaikoKingaku();
            }
            catch(Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        /// <summary>
        ///     chkAll_CheckedChanged
        ///     全項目のCheckプロパティが変更された時の処理
        /// </summary>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            // チェック済みの場合
            if (chkAll.Checked)
            {
                // 期間内売上、期間内仕入のラジオボタンのチェックを外す
                radUriageAri.Checked = false;
                radUriageNasi.Checked = false;
                radSiireAri.Checked = false;
                radSiireNasi.Checked = false;
            }
        }

        /// <summary>
        ///     radUriageAri_CheckedChanged
        ///     期間内売上ありのCheckプロパティが変更された時の処理
        /// </summary>
        private void radUriageAri_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked && chkAll.Checked)
            {
                // 全項目のチェックボックスのチェックを外す
                chkAll.Checked = false;
            }
        }

        /// <summary>
        ///     radUriageNasi_CheckedChanged
        ///     期間内売上なしのCheckプロパティが変更された時の処理
        /// </summary>
        private void radUriageNasi_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked && chkAll.Checked)
            {
                // 全項目のチェックボックスのチェックを外す
                chkAll.Checked = false;
            }
        }

        /// <summary>
        ///     radSiireAri_CheckedChanged
        ///     期間内仕入ありのCheckプロパティが変更された時の処理
        /// </summary>
        private void radSiireAri_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked && chkAll.Checked)
            {
                // 全項目のチェックボックスのチェックを外す
                chkAll.Checked = false;
            }
        }

        /// <summary>
        ///     radSiireNasi_CheckedChanged
        ///     期間内仕入なしのCheckプロパティが変更された時の処理
        /// </summary>
        private void radSiireNasi_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked && chkAll.Checked)
            {
                // 全項目のチェックボックスのチェックを外す
                chkAll.Checked = false;
            }
        }

        /// <summary>
        ///     getMaxZaikoDate
        ///     最大の在庫年月日を取得
        /// </summary>
        private string getMaxZaikoDate()
        {
            string strMaxZaikoDate = "";

            // ビジネス層のインスタンス生成
            M1240_ShohinSiireKakakuSuii2_B suii_B = new M1240_ShohinSiireKakakuSuii2_B();
            try
            {
                // 在庫年月日の最大値を取得
                DataTable dtMaxZaikoDate = suii_B.getMaxZaikoDate();

                if (dtMaxZaikoDate != null && dtMaxZaikoDate.Rows.Count > 0)
                {
                    strMaxZaikoDate = dtMaxZaikoDate.Rows[0][0].ToString();
                }

                return strMaxZaikoDate;
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return strMaxZaikoDate;
            }

        }

        /// <summary>
        ///     delText
        ///     テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // F4：取消をしても全項目クリアはしないので
            // 個別に空にする
            gridShohin.DataSource = "";
            gridSiire.DataSource = "";
            gridUriage.DataSource = "";
            labelSet_Daibunrui.CodeTxtText = "";
            labelSet_Daibunrui.ValueLabelText = "";
            labelSet_Chubunrui.CodeTxtText = "";
            labelSet_Chubunrui.ValueLabelText = "";
            labelSet_Maker.CodeTxtText = "";
            labelSet_Maker.ValueLabelText = "";
            txtHyokaTanka.Text = "";
            txtSetteiTanka.Text = "";
            // grid情報もクリアするため、EXCEL出力ボタンを無効化
            this.btnF10.Enabled = false;
            // 大分類のラベルセットにフォーカス
            labelSet_Daibunrui.Focus();
        }

        /// <summary>
        ///     updHyokaTanaka
        ///     評価単価を更新
        /// </summary>
        private void updHyokaTanka()
        {
            // 空文字判定（基準在庫日）
            if (txtKijunYmd.Text.Equals(""))
            {
                return;
            }

            // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
            BaseMessageBox basemessagebox = new BaseMessageBox(this, "確認", "すべての設定単価を商品マスタの評価単価に更新します。\r\nよろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

            // NOが押された場合
            if (basemessagebox.ShowDialog() == DialogResult.No)
            {
                return;
            }

            // ビジネス層のインスタンス生成
            M1240_ShohinSiireKakakuSuii2_B suii_B = new M1240_ShohinSiireKakakuSuii2_B();
            try
            {
                // 評価単価を更新
                suii_B.updHyokaTanaka(txtKijunYmd.Text);

                // メッセージボックスの処理、更新完了の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "正常に更新しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

            return;
        }

        /// <summary>
        ///     outputExcel
        ///     エクセルへ出力し、作成したファイルを開く
        /// </summary>
        private void outputExcel()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // Excel出力用
            List<string> lstExcelItem = new List<string>();

            // ファイル保存用
            SaveFileDialog sfd = new SaveFileDialog();

            // ファイル名の指定
            sfd.FileName = "商品単価一覧" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            // デフォルトのフォルダ位置
            sfd.InitialDirectory = "MyDocuments";

            // ファイルフィルタの設定
            sfd.Filter = "EXCELファイル(*.xlsx)|*.xlsx";

            // タイトルの設定
            sfd.Title = "保存先のファイルを選択してください";

            // ダイアログを表示
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // データ検索用にデータをセット
                lstSearchItem.Add(txtKijunYmd.Text);                // 基準年月日
                lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);  // 大分類コード
                lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);  // 中分類コード
                lstSearchItem.Add(labelSet_Maker.CodeTxtText);      // メーカーコード
                lstSearchItem.Add(chkAll.Checked.ToString());       // チェックボックス
                // 期間内売上（ラジオボタン）
                if (radUriageAri.Checked)
                {
                    lstSearchItem.Add("0");
                }
                else if(radUriageNasi.Checked)
                {
                    lstSearchItem.Add("1");
                }
                else
                {
                    lstSearchItem.Add("");
                }
                // 期間内仕入（ラジオボタン）
                if (radSiireAri.Checked)
                {
                    lstSearchItem.Add("0");
                }
                else if (radSiireNasi.Checked)
                {
                    lstSearchItem.Add("1");
                }
                else
                {
                    lstSearchItem.Add("");
                }
                lstSearchItem.Add(radZaiko.judCheckBtn().ToString());

                // Excel出力用にデータをセット
                lstExcelItem.Add(labelSet_Daibunrui.ValueLabelText);    // 大分類名称
                lstExcelItem.Add(labelSet_Chubunrui.ValueLabelText);    // 中分類名称
                lstExcelItem.Add(labelSet_Maker.ValueLabelText);        // メーカー名称
                lstExcelItem.Add(txtYmdFrom.Text);                      // 期間From
                lstExcelItem.Add(txtYmdTo.Text);                        // 期間To
                lstExcelItem.Add(txtKijunYmd.Text);                     // 基準年月日
                lstExcelItem.Add(chkAll.Checked.ToString());            // チェックボックス
                // 期間内売上（ラジオボタン）
                if (radUriageAri.Checked)
                {
                    lstExcelItem.Add("0");
                }
                else if (radUriageNasi.Checked)
                {
                    lstExcelItem.Add("1");
                }
                else
                {
                    lstExcelItem.Add("");
                }
                // 期間内仕入（ラジオボタン）
                if (radSiireAri.Checked)
                {
                    lstExcelItem.Add("0");
                }
                else if (radSiireNasi.Checked)
                {
                    lstExcelItem.Add("1");
                }
                else
                {
                    lstExcelItem.Add("");
                }
                lstExcelItem.Add(txtKingakuHyoka.Text);
                lstExcelItem.Add(txtKingakuSettei.Text);
                lstExcelItem.Add(txtKingakuCyokkin.Text);

                // ビジネス層のインスタンス生成
                M1240_ShohinSiireKakakuSuii2_B suii_B = new M1240_ShohinSiireKakakuSuii2_B();
                try
                {
                    // カーソルを待機状態にする
                    this.Cursor = Cursors.WaitCursor;

                    // 検索実行
                    DataTable dtShohin = suii_B.getShohin(lstSearchItem);

                    if (dtShohin != null && dtShohin.Rows.Count > 0)
                    {
                        // Excel出力ファイルパス
                        string strFilePath = sfd.FileName;

                        // Excel出力
                        bool xlsResult = suii_B.dbToExcel(dtShohin, lstExcelItem, strFilePath);

                        // Excel出力が正常にできれば処理
                        if (xlsResult == true)
                        {
                            // Excelのクラスのタイプとインスタンスを取得
                            object xlsApp = CreateObject("Excel.Application");

                            // ワークブックコレクションオブジェクト
                            object xlsBooks = xlsApp.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, xlsApp, null);

                            // Excelファイルのオープン
                            object xlsBook = xlsBooks.GetType().InvokeMember(
                                                  "Open", BindingFlags.InvokeMethod, null,
                                                  xlsBooks, new object[] {
                                                               strFilePath
                                                             , Type.Missing
                                                             , Type.Missing
                                                             , Type.Missing
                                                             , Type.Missing
                                                             , Type.Missing
                                                             , Type.Missing
                                                             , Type.Missing
                                                             , Type.Missing
                                                             , Type.Missing
                                                             , Type.Missing
                                                             , Type.Missing
                                                             , Type.Missing
                                                                            });

                            // Excelファイルの表示
                            xlsApp.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, xlsApp, new object[] { true });

                            // カーソルの状態を元に戻す
                            this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            // カーソルの状態を元に戻す
                            this.Cursor = Cursors.Default;

                            // メッセージボックスの処理、Excel作成失敗の場合のウィンドウ（OK）
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "テンプレート：商品単価一覧.xlsxが存在しません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                        }


                    }
                }
                catch (Exception ex)
                {
                    // カーソルの状態を元に戻す
                    this.Cursor = Cursors.Default;

                    // エラーロギング
                    new CommonException(ex);

                    // メッセージボックスの処理、Excel作成失敗の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "処理中にエラーが発生しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return;
                }
            }

            return;
        }

        /// <summary>
        ///     search
        ///     検索
        /// </summary>
        private void search()
        {
            // データ更新用
            List<string> lstUpdateItem = new List<string>();

            // 大分類の指定がなく、かつ、中分類の指定がある場合
            if (labelSet_Daibunrui.CodeTxtText.Equals("") && !labelSet_Chubunrui.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "中分類を指定する場合は大分類を指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_Daibunrui.Focus();

                return;
            }

            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            gridShohin.DataSource = "";
            gridSiire.DataSource = "";
            gridUriage.DataSource = "";
            txtHyokaTanka.Text = "";
            txtSetteiTanka.Text = "";

            // データ更新用にデータをセット
            lstUpdateItem.Add(txtKijunYmd.Text);            // 基準在庫日
            lstUpdateItem.Add(txtYmdFrom.Text);             // 期間From
            lstUpdateItem.Add(txtYmdTo.Text);               // 期間To
            lstUpdateItem.Add(Environment.UserName);        // ユーザ名

            // ビジネス層のインスタンス生成
            M1240_ShohinSiireKakakuSuii2_B suii_B = new M1240_ShohinSiireKakakuSuii2_B();
            try
            {
                // 商品仕入価格推移2_直近仕入単価更新を実行
                suii_B.updCyokkinTanka_Proc(lstUpdateItem);

                // 履歴から商品単価を取得し、在庫金額合計にセット
                this.getShohinTanka();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

            return;
        }

        /// <summary>
        ///     getShohinTanka
        ///     履歴から商品単価を取得し、在庫金額合計にセット
        /// </summary>
        private void getShohinTanka()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // データ検索用にデータをセット
            lstSearchItem.Add(txtKijunYmd.Text);                // 基準年月日
            lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);  // 大分類コード
            lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);  // 中分類コード
            lstSearchItem.Add(labelSet_Maker.CodeTxtText);      // メーカーコード
            lstSearchItem.Add(chkAll.Checked.ToString());       // チェックボックス
            // 期間内売上（ラジオボタン）
            if (radUriageAri.Checked)
            {
                lstSearchItem.Add("0");
            }
            else if (radUriageNasi.Checked)
            {
                lstSearchItem.Add("1");
            }
            else
            {
                lstSearchItem.Add("");
            }
            // 期間内仕入（ラジオボタン）
            if (radSiireAri.Checked)
            {
                lstSearchItem.Add("0");
            }
            else if (radSiireNasi.Checked)
            {
                lstSearchItem.Add("1");
            }
            else
            {
                lstSearchItem.Add("");
            }
            lstSearchItem.Add(radZaiko.judCheckBtn().ToString());

            // ビジネス層のインスタンス生成
            M1240_ShohinSiireKakakuSuii2_B suii_B = new M1240_ShohinSiireKakakuSuii2_B();
            try
            {
                // 履歴から商品単価を取得
                DataTable dtShohin = suii_B.getShohin(lstSearchItem);

                if (dtShohin != null && dtShohin.Rows.Count > 0)
                {
                    // データテーブルをグリッドへセット
                    gridShohin.DataSource = dtShohin;

                    // 在庫金額合計にセット
                    this.setZaikoKingaku();
                }

                Control cNow = this.ActiveControl;
                cNow.Focus();
            }
            catch
            {
                throw;
            }

            return;
        }

        /// <summary>
        ///     setZaikoKingaku
        ///     在庫金額合計にセット
        /// </summary>
        private void setZaikoKingaku()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // 空文字判定（基準在庫日）
            if (txtKijunYmd.blIsEmpty() == false)
            {
                return;
            }

            txtKingakuHyoka.Text = "";
            txtKingakuSettei.Text = "";
            txtKingakuCyokkin.Text = "";
            txtKingakuCyokkin2.Text = "";

            // ビジネス層のインスタンス生成
            M1240_ShohinSiireKakakuSuii2_B suii_B = new M1240_ShohinSiireKakakuSuii2_B();
            try
            {
                decimal decCyokkin = 0;
                decimal decKari = 0;

                // 在庫金額を取得
                DataTable dtKingaku = suii_B.getZaikoKingaku(txtKijunYmd.Text);

                if (dtKingaku != null && dtKingaku.Rows.Count > 0)
                {
                    string hyoka = dtKingaku.Rows[0]["評価金額"].ToString();
                    string kari = dtKingaku.Rows[0]["仮金額"].ToString();
                    // 評価金額が空でなかった場合、カンマ付きのフォーマットにしてテキストボックスへ
                    if (hyoka != "")
                    {
                        txtKingakuHyoka.Text = string.Format("{0:#,##0}", decimal.Parse(hyoka));
                    }
                    // 仮金額が空でなかった場合、カンマ付きのフォーマットにしてテキストボックスへ
                    if (kari != "")
                    {
                        txtKingakuSettei.Text = string.Format("{0:#,##0}", decimal.Parse(kari));
                    }                    
                }

                // グリッドビューに何も表示されていない場合
                if (gridShohin.RowCount == 0)
                {
                    return;
                }

                // データ検索用にデータをセット
                lstSearchItem.Add(txtKijunYmd.Text);                // 基準在庫日
                lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);  // 大分類コード
                lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);  // 中分類コード
                lstSearchItem.Add(labelSet_Maker.CodeTxtText);      // メーカーコード

                // 直近金額を取得
                dtKingaku = suii_B.getCyokkinKingaku(lstSearchItem);
                if (dtKingaku != null && dtKingaku.Rows.Count > 0)
                {
                    string strCyokkin = dtKingaku.Rows[0][0].ToString();
                    // 直近金額が空でない場合、decimalにキャスト
                    if (strCyokkin != "")
                    {
                        decCyokkin = decimal.Parse(strCyokkin);
                    }
                }

                // 仮金額を取得
                dtKingaku = suii_B.getKariKingaku(lstSearchItem);
                if (dtKingaku != null && dtKingaku.Rows.Count > 0)
                {
                    string strKari = dtKingaku.Rows[0][0].ToString();
                    // 仮金額が空でない場合、decimalにキャスト
                    if (strKari != "")
                    {
                        decKari = decimal.Parse(strKari);
                    }
                }

                txtKingakuCyokkin.Text = string.Format("{0:#,##0}", decCyokkin + decKari);
                txtKingakuCyokkin2.Text = string.Format("{0:#,##0}", decCyokkin);
            }
            catch
            {
                throw;
            }

            return;
        }

        /// <summary>
        ///     dataCreate
        ///     データ作成
        /// </summary>
        private void dataCreate()
        {
            // 商品仕入価格推移2_PROC用
            List<string> lstProcItem = new List<string>();

            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // ビジネス層のインスタンス生成
            M1240_ShohinSiireKakakuSuii2_B suii_B = new M1240_ShohinSiireKakakuSuii2_B();
            try
            {
                BaseMessageBox basemessagebox;

                // データ件数を取得
                //DataTable dtShohin = suii_B.getCount(txtKijunYmd.Text);
                int cnt = suii_B.getRecordCount(txtKijunYmd.Text);

                //if (dtShohin != null && dtShohin.Rows.Count > 0)
                if (cnt > 0)
                {

                    // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
                    basemessagebox = new BaseMessageBox(this, "確認", "すでにデータが存在します。再計算すると入力した単価が初期化されます。\r\nよろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                    // NOが押された場合
                    if (basemessagebox.ShowDialog() == DialogResult.No)
                    {
                        return;
                    }

                }
                // カーソルを待機状態にする
                this.Cursor = Cursors.WaitCursor;

                // 在庫一覧データ作成_PROCを実行
                suii_B.addZaikoData_Proc(txtKijunYmd.Text);

                // 商品仕入価格推移2_PROC用にデータをセット
                lstProcItem.Add(txtKijunYmd.Text);      // 基準在庫日
                lstProcItem.Add(txtYmdFrom.Text);       // 期間From
                lstProcItem.Add(txtYmdTo.Text);         // 期間To
                lstProcItem.Add(Environment.UserName);  // ユーザ名

                // 商品仕入価格推移2_PROCを実行
                suii_B.suii2_Proc(lstProcItem);

                // 履歴から商品単価を取得し、在庫金額合計にセット
                this.getShohinTanka();
                // カーソルを元に戻す
                this.Cursor = Cursors.Default;

                // メッセージボックスの処理、作成完了の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "データ作成が完了しました。条件を入力して検索してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                labelSet_Daibunrui.Focus();
            }
            catch (Exception ex)
            {
                // カーソルを元に戻す
                this.Cursor = Cursors.Default;
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

            return;
        }

        /// <summary>
        ///     updSetteiTanka
        ///     設定単価更新
        /// </summary>
        private void updSetteiTanka()
        {
            // データ更新用
            List<string> lstUpdateItem = new List<string>();

            // グリッドビューにデータがない場合
            if (gridShohin.RowCount == 0)
            {
                return;
            }

            // 空文字判定（設定単価）
            if (txtSetteiTanka.Text.Equals(""))
            {
                return;
            }

            // 設定単価（仮単価）を選択行へセット
            gridShohin.Rows[rowIndex].Cells[9].Value = decimal.Parse(txtSetteiTanka.Text);

            decimal decTeika = decimal.Parse(gridShohin.Rows[rowIndex].Cells[6].Value.ToString());
            if (decTeika != 0)
            {
                // 仮掛率の計算
                decimal decSetteiTanka = decimal.Parse(gridShohin.Rows[rowIndex].Cells[9].Value.ToString());
                decimal decRitsu = decSetteiTanka / decTeika * 100;

                // 仮掛率を選択行へセット
                gridShohin.Rows[rowIndex].Cells[10].Value = string.Format("{0:0.0}", decRitsu);
            }

            // データ更新用にデータをセット
            lstUpdateItem.Add(txtKijunYmd.Text);                                            // 基準在庫日
            lstUpdateItem.Add(txtSetteiTanka.Text);                                         // 設定単価
            lstUpdateItem.Add(gridShohin.Rows[rowIndex].Cells[10].Value.ToString());        // 仮掛率
            lstUpdateItem.Add(gridShohin.Rows[rowIndex].Cells[0].Value.ToString().Trim());  // 商品コード

            // ビジネス層のインスタンス生成
            M1240_ShohinSiireKakakuSuii2_B suii_B = new M1240_ShohinSiireKakakuSuii2_B();
            try
            {
                // 設定単価を更新
                suii_B.updSetteiTanka(lstUpdateItem);

                // 在庫金額を取得
                DataTable dtKingaku = suii_B.getZaikoKingakuSettei(txtKijunYmd.Text);

                if (dtKingaku != null && dtKingaku.Rows.Count > 0)
                {
                    string kari = dtKingaku.Rows[0]["仮金額"].ToString();
                    // 仮金額が空でなかった場合、カンマ付きのフォーマットにしてテキストボックスへ
                    if (kari != "")
                    {
                        txtKingakuSettei.Text = string.Format("{0:#,##0}", decimal.Parse(kari));
                    }
                    
                }

                gridShohin.Focus();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

            return;
        }

        /// <summary>
        ///     updCyokkinTanka
        ///     直近単価更新
        /// </summary>
        private void updCyokkinTanka()
        {
            // データ更新用
            List<string> lstUpdateItem = new List<string>();

            // グリッドビューにデータがない場合
            if (gridShohin.RowCount == 0)
            {
                return;
            }

            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
            BaseMessageBox basemessagebox = new BaseMessageBox(this, "確認", "一覧の型番に対して、設定単価に直近仕入単価をセットします。\r\nよろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

            // NOが押された場合
            if (basemessagebox.ShowDialog() == DialogResult.No)
            {
                return;
            }

            // データ更新用にデータをセット
            lstUpdateItem.Add(txtKijunYmd.Text);                // 基準在庫日
            lstUpdateItem.Add(labelSet_Daibunrui.CodeTxtText);  // 大分類コード
            lstUpdateItem.Add(labelSet_Chubunrui.CodeTxtText);  // 中分類コード
            lstUpdateItem.Add(labelSet_Maker.CodeTxtText);      // メーカーコード

            // ビジネス層のインスタンス生成
            M1240_ShohinSiireKakakuSuii2_B suii_B = new M1240_ShohinSiireKakakuSuii2_B();
            try
            {
                // 直近単価を更新
                suii_B.updCyokkinTanka(lstUpdateItem);

                // 履歴から商品単価を取得し、在庫金額合計にセット
                this.getShohinTanka();

                // メッセージボックスの処理、作成完了の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "設定単価を更新しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

            return;
        }

        /// <summary>
        ///     blnDataCheck
        ///     データチェック
        /// </summary>
        private Boolean blnDataCheck()
        {
            // 空文字判定（基準在庫日）
            if (txtKijunYmd.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "基準在庫日を指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtKijunYmd.Focus();

                return false;
            }

            // 空文字判定（開始期間）
            if (txtYmdFrom.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "期間を指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmdFrom.Focus();

                return false;
            }

            // 空文字判定（終了期間）
            if (txtYmdTo.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "期間を指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmdTo.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        ///     COMオブジェクトへの参照を作成および取得する
        /// </summary>
        /// <param name="progId">
        ///     作成するオブジェクトのプログラムID
        /// </param>
        /// <param name="serverName">
        ///     オブジェクトが作成されるネットワーク サーバーの名前
        /// </param>
        /// <returns>
        ///     作成されたCOMオブジェクト
        /// </returns>
        private static object CreateObject(string progId, string serverName)
        {
            Type t;
            if (serverName == null || serverName.Length == 0)
                t = Type.GetTypeFromProgID(progId);
            else
                t = Type.GetTypeFromProgID(progId, serverName, true);
            return Activator.CreateInstance(t);
        }

        /// <summary>
        ///     COMオブジェクトへの参照を作成および取得する
        /// </summary>
        /// <param name="progId">
        ///     作成するオブジェクトのプログラムID
        /// </param>
        /// <returns>
        ///     作成されたCOMオブジェクト
        /// </returns>
        private static object CreateObject(string progId)
        {
            return CreateObject(progId, null);
        }


    }
}
