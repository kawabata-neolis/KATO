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
using KATO.Common.Form;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.M1150_ShohinTankaIkkatsuUpdate;

namespace KATO.Form.M1150_ShohinTankaIkkatsuUpdate
{
    /// <summary>
    /// M1150_ShohinTankaIkkatuUpdate
    /// 商品マスタ単価一括更新フォーム
    /// 作成者：多田
    /// 作成日：2017/7/7
    /// 更新者：多田
    /// 更新日：2017/7/7
    /// カラム論理名
    /// </summary>
    public partial class M1150_ShohinTankaIkkatsuUpdate : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // SPPowerUser
        private string strSPPowerUser = Environment.UserName;
        //private string strSPPowerUser = "aaa";

        /// <summary>
        /// M1150_ShohinTankaIkkatuUpdate
        /// フォーム関係の設定
        /// </summary>
        public M1150_ShohinTankaIkkatsuUpdate(Control c)
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
        /// M1150_ShohinTankaIkkatsuUpdate_Load
        /// 読み込み時
        /// </summary>
        private void M1150_ShohinTankaIkkatsuUpdate_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品単価一括更新";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF06.Text = "棚番コピー";
            this.btnF12.Text = STR_FUNC_F12;

            // ファンクションボタン制御
            this.btnF01.Enabled = false;
            this.btnF04.Enabled = false;

            // SPPowerUserの場合のみF11に文字を表示
            if (strSPPowerUser.Equals("ゲストユーザー"))
            {
                this.btnF11.Text = STR_FUNC_F11;
            }

            // 初期表示
            labelSet_Daibunrui.Focus();

            // DataGridViewの初期設定
            SetUpGrid();

            // グリッドビューの定価、棚番本社、棚番岐阜、在庫管理の列のみ編集可能にする
            gridShohin.Columns[0].ReadOnly = true;
            gridShohin.Columns[1].ReadOnly = true;
            gridShohin.Columns[2].ReadOnly = true;
            gridShohin.Columns[3].ReadOnly = true;
            gridShohin.Columns[5].ReadOnly = true;
            gridShohin.Columns[6].ReadOnly = true;
            gridShohin.Columns[7].ReadOnly = true;
            gridShohin.Columns[8].ReadOnly = true;
        }

        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            // 列自動生成禁止
            gridShohin.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn shohinCd = new DataGridViewTextBoxColumn();
            shohinCd.DataPropertyName = "商品コード";
            shohinCd.Name = "商品コード";
            shohinCd.HeaderText = "商品コード";

            DataGridViewTextBoxColumn daibunruiName = new DataGridViewTextBoxColumn();
            daibunruiName.DataPropertyName = "大分類名";
            daibunruiName.Name = "大分類名";
            daibunruiName.HeaderText = "大分類";

            DataGridViewTextBoxColumn chubunruiName = new DataGridViewTextBoxColumn();
            chubunruiName.DataPropertyName = "中分類名";
            chubunruiName.Name = "中分類名";
            chubunruiName.HeaderText = "中分類";

            DataGridViewTextBoxColumn makerName = new DataGridViewTextBoxColumn();
            makerName.DataPropertyName = "メーカー名";
            makerName.Name = "メーカー名";
            makerName.HeaderText = "メーカー";

            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "品名型式";
            kataban.Name = "品名型式";
            kataban.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn teika = new DataGridViewTextBoxColumn();
            teika.DataPropertyName = "定価";
            teika.Name = "定価";
            teika.HeaderText = "定価";

            DataGridViewTextBoxColumn baika = new DataGridViewTextBoxColumn();
            baika.DataPropertyName = "標準売価";
            baika.Name = "標準売価";
            baika.HeaderText = "標準売価";

            DataGridViewTextBoxColumn siireTanka = new DataGridViewTextBoxColumn();
            siireTanka.DataPropertyName = "仕入単価";
            siireTanka.Name = "仕入単価";
            siireTanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn hyokaTanka = new DataGridViewTextBoxColumn();
            hyokaTanka.DataPropertyName = "評価単価";
            hyokaTanka.Name = "評価単価";
            hyokaTanka.HeaderText = "評価単価";
            
            DataGridViewTextBoxColumn tateneTanka = new DataGridViewTextBoxColumn();
            tateneTanka.DataPropertyName = "建値仕入単価";
            tateneTanka.Name = "建値仕入単価";
            tateneTanka.HeaderText = "建値仕入単価";

            DataGridViewTextBoxColumn tanabanHonsha = new DataGridViewTextBoxColumn();
            tanabanHonsha.DataPropertyName = "棚番本社";
            tanabanHonsha.Name = "棚番本社";
            tanabanHonsha.HeaderText = "棚番本社";

            DataGridViewTextBoxColumn tanabanGifu = new DataGridViewTextBoxColumn();
            tanabanGifu.DataPropertyName = "棚番岐阜";
            tanabanGifu.Name = "棚番岐阜";
            tanabanGifu.HeaderText = "棚番岐阜";

            DataGridViewTextBoxColumn zaiko = new DataGridViewTextBoxColumn();
            zaiko.DataPropertyName = "在庫管理区分";
            zaiko.Name = "在庫管理区分";
            zaiko.HeaderText = "在庫管理";

            // 個々の幅、文字の寄せ
            setColumn(daibunruiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 140);
            setColumn(chubunruiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 140);
            setColumn(makerName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 140);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 360);
            setColumn(teika, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 140);
            setColumn(baika, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 140);
            setColumn(siireTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 140);
            setColumn(hyokaTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 140);
            setColumn(tateneTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 140);
            setColumn(tanabanHonsha, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(tanabanGifu, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(zaiko, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#", 100);

            // 非表示項目（商品コード）
            setColumn(shohinCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#", 0);
            gridShohin.Columns[12].Visible = false;
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
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
        /// M1150_ShohinTankaIkkatsuUpdate_KeyDown
        /// キー入力判定
        /// </summary>
        private void M1150_ShohinTankaIkkatsuUpdate_KeyDown(object sender, KeyEventArgs e)
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
                    // ファンクションボタン制御
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.updShohinMaster();
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    // ファンクションボタン制御
                    if (this.btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.delText();
                    }
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    logger.Info(LogUtil.getMessage(this._Title, "棚番コピー実行"));
                    this.copyTanaban();
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    // SPPowerUserの場合のみ有効
                    if (strSPPowerUser.Equals("ゲストユーザー"))
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                        this.printReport();
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

        /// <summary>
        /// judBtnClick
        /// ボタンの反応
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    // ファンクションボタン制御
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.updShohinMaster();
                    }
                    break;
                case STR_BTN_F04: // 取消
                    // ファンクションボタン制御
                    if (this.btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.delText();
                    }
                    break;
                case STR_BTN_F06: // 棚番コピー
                    logger.Info(LogUtil.getMessage(this._Title, "棚番コピー実行"));
                    this.copyTanaban();
                    break;
                case STR_BTN_F11: // 印刷
                    // SPPowerUserの場合のみ有効
                    if (strSPPowerUser.Equals("ゲストユーザー"))
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                        this.printReport();
                    }
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// btnHyoji_Click
        /// 一覧表示ボタン
        /// </summary>
        private void btnHyoji_Click(object sender, EventArgs e)
        {


            this.setShohin();

        }

        /// <summary>
        /// btnKeisan_Click
        /// 単価計算ボタン
        /// </summary>
        private void btnKeisan_Click(object sender, EventArgs e)
        {
            this.tankaKeisan();
        }

        /// <summary>
        /// commonTxtKeyPress
        /// 標準売価％、仕入単価％、評価単価％、建値単価％のテキストボックスのKeyPressイベント
        /// </summary>
        private void commonTxtKeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressイベントが発生したテキストボックス
            Control ctlTb = this.Controls[((TextBox)sender).Name];

            // コンマが含まれている場合
            if (ctlTb.Text.Contains("."))
            {
                // 0～9、バックスペース以外の時は、イベントをキャンセルする
                if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
            else
            {
                // 0～9、コンマ、バックスペース以外の時は、イベントをキャンセルする
                if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// commonTxtLeave
        /// 標準売価％、仕入単価％、評価単価％、建値単価％のテキストボックスからフォーカスが外れた時
        /// </summary>
        private void commonTxtLeave(object sender, EventArgs e)
        {
            // フォーカスが外れたテキストボックス
            Control ctlTb = this.Controls[((TextBox)sender).Name];

            double dblPercent;

            // double型へ変換できなかった場合
            if (!double.TryParse(ctlTb.Text, out dblPercent))
            {
                // コロンの場合のみ
                if (ctlTb.Text.Equals("."))
                {
                    ctlTb.Text = "0.0";
                }

                return;
            }

            // 小数点以下第2位を四捨五入して、小数点第1位まで表示
            ctlTb.Text = Math.Round(dblPercent, 1, MidpointRounding.AwayFromZero).ToString("0.0");

            // 1000以上の場合、入力不可
            if (dblPercent >= 1000)
            {
                // メッセージボックスの処理、数値が1000以上の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された数値が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        /// <summary>
        /// setShohin
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setShohin()
        {
            // 仕入単価、評価単価、建値仕入単価の合計用
            decimal[] decGoukei = new decimal[3];

            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // 検索するデータをリストに格納
            lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);
            lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);
            lstSearchItem.Add(labelSet_Maker.CodeTxtText);
            lstSearchItem.Add(txtTanabanHonsha.Text);
            lstSearchItem.Add(txtTanabanGifu.Text);
            lstSearchItem.Add(txtKataban.Text);

            // 並び替え
            if (radSet_2btn.radbtn0.Checked)
            {
                lstSearchItem.Add("0");
            }
            else
            {
                lstSearchItem.Add("1");
            }

            // ビジネス層のインスタンス生成
            M1150_ShohinTankaIkkatsuUpdate_B shohinB = new M1150_ShohinTankaIkkatsuUpdate_B();
            try
            {
                // 検索実行
                DataTable dtShohinList = shohinB.getShohinList(lstSearchItem);

                int rowsCnt = dtShohinList.Rows.Count;

                // 検索データがある場合
                if (dtShohinList != null && rowsCnt > 0)
                {
                    // 仕入単価、評価単価、建値仕入単価の計算
                    for (int cnt = 0; cnt < rowsCnt; cnt++)
                    {
                        decGoukei[0] += Decimal.Parse(dtShohinList.Rows[cnt]["仕入単価"].ToString());
                        decGoukei[1] += Decimal.Parse(dtShohinList.Rows[cnt]["評価単価"].ToString());
                        decGoukei[2] += Decimal.Parse(dtShohinList.Rows[cnt]["建値仕入単価"].ToString());
                    }

                    // 計算結果をテキストボックスへ配置
                    txtSiireKingaku.Text = string.Format("{0:#,0}", decGoukei[0]);
                    txtHyokaKingaku.Text = string.Format("{0:#,0}", decGoukei[1]);
                    txtTateneKingaku.Text = string.Format("{0:#,0}", decGoukei[2]);

                    // データテーブルからデータグリッドへセット
                    gridShohin.DataSource = dtShohinList;

                    Control cNow = this.ActiveControl;
                    cNow.Focus();
                    // ファンクションボタン制御
                    this.btnF01.Enabled = true;
                    this.btnF04.Enabled = true;

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

        /// <summary>
        /// tankaKeisan
        /// 単価計算
        /// </summary>
        private void tankaKeisan()
        {
            decimal decTeika;
            double dblTeika;
            int rowsCnt = gridShohin.RowCount;

            if (rowsCnt > 0)
            {
                // データチェック
                if (!blnDataCheak())
                {
                    return;
                }

                for (int cnt = 0; cnt < rowsCnt; cnt++)
                {
                    // 定価
                    decTeika = decimal.Parse(gridShohin[4, cnt].Value.ToString());
                    dblTeika = double.Parse(gridShohin[4, cnt].Value.ToString());

                    // 定価が0でない場合、計算を行う
                    if (decTeika != 0)
                    {
                        // 標準売価がある場合
                        if (!txtHyojun.Text.Equals(""))
                        {
                            gridShohin[5, cnt].Value = Math.Round(dblTeika * double.Parse(txtHyojun.Text) / 100, 0, MidpointRounding.AwayFromZero);
                        }

                        // 仕入単価がある場合
                        if (!txtSiire.Text.Equals(""))
                        {
                            gridShohin[6, cnt].Value = Math.Round(dblTeika * double.Parse(txtSiire.Text) / 100, 0, MidpointRounding.AwayFromZero);
                        }

                        // 評価単価がある場合
                        if (!txtHyoka.Text.Equals(""))
                        {
                            gridShohin[7, cnt].Value = Math.Round(dblTeika * double.Parse(txtHyoka.Text) / 100, 0, MidpointRounding.AwayFromZero);
                        }

                        // 建値単価がある場合
                        if (!txtTatene.Text.Equals(""))
                        {
                            gridShohin[8, cnt].Value = Math.Round(dblTeika * double.Parse(txtTatene.Text) / 100, 0, MidpointRounding.AwayFromZero);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            //// 削除するデータ以外を確保
            //string strKataban = txtKataban.Text;

            // 画面の項目内を白紙にする
            delFormClear(this, gridShohin);

            // ファンクションボタン制御
            this.btnF01.Enabled = false;
            this.btnF04.Enabled = false;

            labelSet_Daibunrui.Focus();
        }

        /// <summary>
        /// updShohinMaster
        /// 商品マスタ更新
        /// </summary>
        private void updShohinMaster()
        {
            // データチェック
            if (!blnDataCheak())
            {
                return;
            }

            // メッセージボックスの処理、商品マスタ更新の場合のウィンドウ（YES,NO）
            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "一覧表に表示中の単価で商品マスタを更新します。よろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

            // NOが押された場合
            if (basemessagebox.ShowDialog() == DialogResult.No)
            {
                return;
            }

            // データグリッドのデータをデータテーブルへ
            DataTable dtShohinList = (DataTable)gridShohin.DataSource;

            if (dtShohinList == null)
            {
                return;
            }

            // ビジネス層のインスタンス生成
            M1150_ShohinTankaIkkatsuUpdate_B shohinB = new M1150_ShohinTankaIkkatsuUpdate_B();
            try
            {
                // 更新実行
                shohinB.updShohinMaster(dtShohinList, Environment.UserName);

                // メッセージボックスの処理、更新成功の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、失敗の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

        /// <summary>
        /// blnDataCheak
        /// データチェック
        /// </summary>
        private Boolean blnDataCheak()
        {
            for (int cnt = 0; cnt < gridShohin.RowCount; cnt++)
            {
                // 空文字判定（定価）
                if (string.IsNullOrEmpty(gridShohin.Rows[cnt].Cells["定価"].Value.ToString()))
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    // 空文字のセルへ移動（編集状態）
                    gridShohin.CurrentCell = gridShohin.Rows[cnt].Cells["定価"];
                    gridShohin.BeginEdit(false);

                    return false;
                }

                // 空文字判定（標準売価）
                if (string.IsNullOrEmpty(gridShohin.Rows[cnt].Cells["標準売価"].Value.ToString()))
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    // 空文字のセルへ移動（編集状態）
                    gridShohin.CurrentCell = gridShohin.Rows[cnt].Cells["標準売価"];
                    gridShohin.BeginEdit(false);

                    return false;
                }

                // 空文字判定（仕入単価）
                if (string.IsNullOrEmpty(gridShohin.Rows[cnt].Cells["仕入単価"].Value.ToString()))
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    // 空文字のセルへ移動（編集状態）
                    gridShohin.CurrentCell = gridShohin.Rows[cnt].Cells["仕入単価"];
                    gridShohin.BeginEdit(false);

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// copyTanaban
        /// 棚番コピー
        /// </summary>
        private void copyTanaban()
        {
            // 行数
            int rowsCnt = gridShohin.RowCount;

            // 現在の行番号と列番号
            int rowIndex = gridShohin.CurrentCell.RowIndex;
            int columnIndex = gridShohin.CurrentCell.ColumnIndex;

            // 行数が1行を超える場合
            if (rowsCnt > 1)
            {
                // 現在の行が2行目以降、かつ、最下行までの場合
                if (rowIndex >= 1 && rowIndex < rowsCnt)
                {
                    // 現在の列が棚番本社と棚番岐阜の場合
                    if (columnIndex == 9 || columnIndex == 10)
                    {
                        // 前行のセルの値を現在のセルへ値をセット
                        gridShohin.Rows[rowIndex].Cells[columnIndex].Value = gridShohin.Rows[rowIndex - 1].Cells[columnIndex].Value;

                        // 最下行以外の場合、次行へ移動
                        if (rowIndex < rowsCnt - 1)
                        {
                            gridShohin.CurrentCell = gridShohin.Rows[rowIndex + 1].Cells[columnIndex];
                            gridShohin.BeginEdit(false);
                        }
                        // 最下行の場合、前行へ移動
                        else if (rowIndex == rowsCnt - 1)
                        {
                            gridShohin.CurrentCell = gridShohin.Rows[rowIndex - 1].Cells[columnIndex];
                            gridShohin.BeginEdit(false);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // 検索するデータをリストに格納
            lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);
            lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);
            lstSearchItem.Add(labelSet_Maker.CodeTxtText);
            lstSearchItem.Add(txtTanabanHonsha.Text);
            lstSearchItem.Add(txtTanabanGifu.Text);
            lstSearchItem.Add(txtKataban.Text);

            // 並び替え
            if (radSet_2btn.radbtn0.Checked)
            {
                lstSearchItem.Add("0");
            }
            else
            {
                lstSearchItem.Add("1");
            }

            // ビジネス層のインスタンス生成
            M1150_ShohinTankaIkkatsuUpdate_B shohinB = new M1150_ShohinTankaIkkatsuUpdate_B();
            try
            {

                // 検索実行
                DataTable dtShohinList = shohinB.getShohinList(lstSearchItem);

                if (dtShohinList.Rows.Count > 0)
                {
                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_B4, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // PDF作成
                        String strFile = shohinB.dbToPdf(dtShohinList, lstSearchItem);

                        // プレビュー
                        pf.execPreview(strFile);
                        pf.ShowDialog(this);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // PDF作成
                        String strFile = shohinB.dbToPdf(dtShohinList, lstSearchItem);

                        // 一括印刷
                        pf.execPrint(null, strFile, CommonTeisu.SIZE_B4, CommonTeisu.YOKO, true);
                    }

                    pf.Dispose();
                }
                else
                {
                    // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、PDF作成失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "印刷が失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

    }
}
