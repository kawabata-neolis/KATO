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
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.D0380_ShohinMotochoKakunin;

namespace KATO.Form.D0380_ShohinMotochoKakunin
{
    ///<summary>
    ///D0380_ShohinMotochoKakunin
    ///商品元帳確認フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class D0380_ShohinMotochoKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// D0380_ShohinMotochoKakunin
        /// フォーム関係の設定
        /// </summary>
        public D0380_ShohinMotochoKakunin(Control c)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
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
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            //メーカーsetデータを読めるようにする
            labelSet_Daibunrui.Lsmakerdata = labelSet_Maker;

        }

        /// <summary>
        /// D0380_ShohinMotochoKakunin_Load
        /// 読み込み時
        /// </summary>
        private void D0380_ShohinMotochoKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品元帳確認";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            //初期表示(営業所コード取り出し)
            DataTable dtTantoshaCd = new DataTable();

            D0380_ShohinMotochoKakunin_B shohinmotochokakuninB = new D0380_ShohinMotochoKakunin_B();
            try
            {
                //ログインＩＤから担当者コードを取り出す
                dtTantoshaCd = shohinmotochokakuninB.getTantoshaCd(SystemInformation.UserName);

                //担当者データがある場合
                if (dtTantoshaCd.Rows.Count > 0)
                {
                    //一行目にデータがない場合
                    if (dtTantoshaCd.Rows[0][0].ToString() == "")
                    {
                        return;
                    }
                }

                labelSet_Eigyosho.CodeTxtText = dtTantoshaCd.Rows[0]["営業所コード"].ToString();
                labelSet_Eigyosho.chkTxtEigyousho();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
            
            labelSet_Daibunrui.Focus();

            //カレンダー関係の初期設定（当日）
            txtCalendarYMopen.setUp(0);
            txtCalendarYMclose.setUp(0);
            
            //DataGridViewの初期設定
            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridSeihin.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn hizuke = new DataGridViewTextBoxColumn();
            hizuke.DataPropertyName = "伝票年月日";
            hizuke.Name = "伝票年月日";
            hizuke.HeaderText = "日付";

            DataGridViewTextBoxColumn denpyo = new DataGridViewTextBoxColumn();
            denpyo.DataPropertyName = "伝票番号";
            denpyo.Name = "伝票番号";
            denpyo.HeaderText = "伝票No";

            DataGridViewTextBoxColumn kbn = new DataGridViewTextBoxColumn();
            kbn.DataPropertyName = "取引区分名";
            kbn.Name = "取引区分名";
            kbn.HeaderText = "区分";

            DataGridViewTextBoxColumn tekiyo = new DataGridViewTextBoxColumn();
            tekiyo.DataPropertyName = "名前";
            tekiyo.Name = "名前";
            tekiyo.HeaderText = "摘　　　要";

            DataGridViewTextBoxColumn nyuko = new DataGridViewTextBoxColumn();
            nyuko.DataPropertyName = "入庫数";
            nyuko.Name = "入庫数";
            nyuko.HeaderText = "入庫数";

            DataGridViewTextBoxColumn shuko = new DataGridViewTextBoxColumn();
            shuko.DataPropertyName = "出庫数";
            shuko.Name = "出庫数";
            shuko.HeaderText = "出庫数";

            DataGridViewTextBoxColumn zaiko = new DataGridViewTextBoxColumn();
            zaiko.DataPropertyName = "在庫数";
            zaiko.Name = "在庫数";
            zaiko.HeaderText = "在庫数";

            DataGridViewTextBoxColumn tanka = new DataGridViewTextBoxColumn();
            tanka.DataPropertyName = "単価";
            tanka.Name = "単価";
            tanka.HeaderText = "単価";

            //個々の幅、文章の寄せ
            setColumn(hizuke, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(denpyo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumn(kbn, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 110);
            setColumn(tekiyo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 580);
            setColumn(nyuko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 120);
            setColumn(shuko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 120);
            setColumn(zaiko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 120);
            setColumn(tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#.00", 120);

        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridSeihin.Columns.Add(col);
            if (gridSeihin.Columns[col.Name] != null)
            {
                gridSeihin.Columns[col.Name].Width = intLen;
                gridSeihin.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridSeihin.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridSeihin.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// D0380_ShohinMotochoKakunin_KeyDown
        /// キー入力判定
        /// </summary>
        private void D0380_ShohinMotochoKakunin_KeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setShohinMotoCho();
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
        /// judShohinTxtKeyDown
        /// キー入力判定
        /// </summary>
        private void judShohinTxtKeyDown(object sender, KeyEventArgs e)
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

                default:
                    break;
            }
        }

        /// <summary>
        /// judTxtShohinTxtDown
        /// キー入力判定
        /// </summary>
        private void judTxtShohinTxtDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    this.setShohinList();
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
                    //検索項目が一つも記入がない場合
                    if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Chubunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Maker.codeTxt.blIsEmpty() == false &&
                        txtKensaku.blIsEmpty() == false)
                    {
                        //TABボタンと同じ効果
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                        this.setShohinList();
                    }
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
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    this.setShohinList();
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
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
                    this.setShohinMotoCho();
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

        ///<summary>
        ///setShohinList
        ///商品リストに移動
        ///</summary>
        private void setShohinList()
        {
            //商品リストのインスタンス生成
            ShouhinList shouhinlist = new ShouhinList(this);
            try
            {
                //検索項目に一つでも記入がある場合
                if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false &&
                    labelSet_Chubunrui.codeTxt.blIsEmpty() == false &&
                    labelSet_Maker.codeTxt.blIsEmpty() == false &&
                    txtKensaku.blIsEmpty() == false)
                {
                    shouhinlist.blKensaku = false;
                }
                else
                {
                    shouhinlist.blKensaku = true;
                }

                //商品リストの表示、画面IDを渡す
                shouhinlist.intFrmKind = CommonTeisu.FRM_SHOHINMOTOCHOKAKUNIN;
                shouhinlist.strYMD = "";
                shouhinlist.strEigyoushoCode = "";
                shouhinlist.lsDaibunrui = labelSet_Daibunrui;
                shouhinlist.lsChubunrui = labelSet_Chubunrui;
                shouhinlist.lsMaker = labelSet_Maker;
                shouhinlist.btxtKensaku = txtKensaku;
                shouhinlist.btxtShohinCd = txtShohinCd;
                shouhinlist.lblGrayHinMakerChuHinban = lblGrayShohin;
                shouhinlist.lblGrayTanabanH = lblGrayTanaHon;
                shouhinlist.lblGrayTanabanG = lblGrayTanaGihu;

                shouhinlist.ShowDialog();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        /// <summary>
        /// setShouhin
        /// 取り出したデータをテキストボックスに配置（商品リスト）
        /// </summary>
        public void setShouhin(DataTable dtShohin)
        {
            labelSet_Daibunrui.CodeTxtText = dtShohin.Rows[0]["大分類コード"].ToString();
            labelSet_Chubunrui.CodeTxtText = dtShohin.Rows[0]["中分類コード"].ToString();
            labelSet_Maker.CodeTxtText = dtShohin.Rows[0]["メーカーコード"].ToString();
            txtShohinCd.Text = dtShohin.Rows[0]["商品コード"].ToString();
            lblGrayTanaHon.Text = dtShohin.Rows[0]["棚番本社"].ToString();
            lblGrayTanaGihu.Text = dtShohin.Rows[0]["棚番岐阜"].ToString();
            lblGrayShohin.Text = labelSet_Maker.ValueLabelText +
                                 labelSet_Chubunrui.ValueLabelText + " " +
                                 dtShohin.Rows[0]["Ｃ１"].ToString() + " " +
                                 dtShohin.Rows[0]["Ｃ２"].ToString() + " " +
                                 dtShohin.Rows[0]["Ｃ３"].ToString() + " " +
                                 dtShohin.Rows[0]["Ｃ４"].ToString() + " " +
                                 dtShohin.Rows[0]["Ｃ５"].ToString() + " " +
                                 dtShohin.Rows[0]["Ｃ６"].ToString();
        }

        /// <summary>
        /// setZaiko
        /// 取り出したデータをテキストボックスに配置（在庫関係リスト）
        /// </summary>
        public void setZaiko(List<string> lstString)
        {
            //フォーカス位置の確保
            Control cActiveBefore = this.ActiveControl;

            //本社前月在庫が0の場合
            if (lstString[0] == "0")
            {
                txtHonZenZaiko.Text = "";
            }
            else
            {
                txtHonZenZaiko.Text = string.Format("{0:#,#}", lstString[0]);
            }

            //岐阜前月在庫が0の場合
            if (lstString[1] == "0")
            {
                txtGihuZenZaiko.Text = "";
            }
            else
            {
                txtGihuZenZaiko.Text = string.Format("{0:#,#}", lstString[1]);
            }

            //本社入庫が0の場合
            if (lstString[2] == "0")
            {
                txtHonNyuko.Text = "";
            }
            else
            {
                txtHonNyuko.Text = string.Format("{0:#,#}", lstString[2]);
            }

            //岐阜入庫が0の場合
            if (lstString[3] == "0")
            {
                txtGihuNyuko.Text = "";
            }
            else
            {
                txtGihuNyuko.Text = string.Format("{0:#,#}", lstString[3]);
            }

            //本社出庫が0の場合
            if (lstString[4] == "0")
            {
                txtHonShuko.Text = "";
            }
            else
            {
                txtHonShuko.Text = string.Format("{0:#,#}", lstString[4]);
            }

            //岐阜出庫が0の場合
            if (lstString[5] == "0")
            {
                txtGihuShuko.Text = "";
            }
            else
            {
                txtGihuShuko.Text = string.Format("{0:#,#}", lstString[5]);
            }

            //本社現在庫が0の場合
            if (lstString[6] == "0")
            {
                txtHonGenzaiko.Text = "";
            }
            else
            {
                txtHonGenzaiko.Text = string.Format("{0:#,#}", lstString[6]);
            }

            //岐阜現在庫が0の場合
            if (lstString[7] == "0")
            {
                txtGihuGenzaiko.Text = "";
            }
            else
            {
                txtGihuGenzaiko.Text = string.Format("{0:#,#}", lstString[7]);
            }
        }

        /// <summary>
        /// setShohinClose
        /// setShohinListが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setShohinClose()
        {
            txtKensaku.Focus();
        }

        /// <summary>
        /// setShohinMotoCho
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setShohinMotoCho()
        {
            //データ検索用
            List<string> lstShohinLoad = new List<string>();
            //グリッドビュー表示用
            List<string> lstShohinGrid = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //空文字判定（商品名）
            if (lblGrayShohin.Text == "")
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtKensaku.Focus();
                return;
            }

            //空文字判定（検索開始年月）
            if (txtCalendarYMopen.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n条件を指定してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMopen.Focus();

                return;
            }

            //空文字判定（検索終了年月）
            if (txtCalendarYMclose.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n条件を指定してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMclose.Focus();

                return;
            }

            //大分類チェック
            if (labelSet_Daibunrui.chkTxtDaibunrui())
            {
                labelSet_Daibunrui.Focus();

                return;
            }

            //中分類チェック
            if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
            {
                labelSet_Chubunrui.Focus();

                return;
            }

            //メーカーチェック
            if (labelSet_Maker.chkTxtMaker())
            {
                labelSet_Maker.Focus();

                return;
            }

            //営業所チェック
            if (labelSet_Eigyosho.chkTxtEigyousho())
            {
                labelSet_Eigyosho.Focus();

                return;
            }

            //待機カーソル
            this.Cursor = Cursors.WaitCursor;

            //日付フォーマット生成、およびチェック
            strYMDformat = txtCalendarYMopen.chkDateYMDataFormat(txtCalendarYMopen.Text);

            //開始年月日の日付チェック
            if (strYMDformat == "")
            {
                //デフォルトカーソル
                this.Cursor = Cursors.Default;

                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMopen.Focus();

                return;
            }
            else
            {
                txtCalendarYMopen.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtCalendarYMclose.chkDateYMDataFormat(txtCalendarYMclose.Text);

            //終了年月日の日付チェック
            if (strYMDformat == "")
            {
                //デフォルトカーソル
                this.Cursor = Cursors.Default;

                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMclose.Focus();

                return;
            }
            else
            {
                txtCalendarYMclose.Text = strYMDformat;
            }

            //ビジネス層のインスタンス生成
            D0380_ShohinMotochoKakunin_B shohinmotochokakuninB = new D0380_ShohinMotochoKakunin_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                lstShohinLoad.Add(txtShohinCd.Text);
                lstShohinLoad.Add(labelSet_Eigyosho.CodeTxtText);
                lstShohinLoad.Add(txtCalendarYMopen.Text);
                lstShohinLoad.Add(txtCalendarYMclose.Text);

                //ビジネス層、テキストボックス表示用ロジックに移動
                lstShohinGrid = shohinmotochokakuninB.setTextBox(lstShohinLoad);

                //データ配置（textbox系）
                setZaiko(lstShohinGrid);

                //データグリッドビュー表示用の情報を入れる
                lstShohinLoad.Add(txtHonZenZaiko.Text);
                lstShohinLoad.Add(txtGihuZenZaiko.Text);

                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = shohinmotochokakuninB.setViewGrid(lstShohinLoad);

                //データ配置（datagridview)
                gridSeihin.DataSource = dtSetView;

                //デフォルトカーソル
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                //デフォルトカーソル
                this.Cursor = Cursors.Default;

                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            return;
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            //削除するデータ以外を確保
            string strkensakuopen = txtCalendarYMopen.Text;
            string strkensakuclose = txtCalendarYMclose.Text;

            //画面の項目内を白紙にする
            delFormClear(this, gridSeihin);
            txtHonZenZaiko.Clear();
            txtGihuZenZaiko.Clear();
            txtHonNyuko.Clear();
            txtGihuNyuko.Clear();
            txtHonShuko.Clear();
            txtGihuShuko.Clear();
            txtHonGenzaiko.Clear();
            txtGihuGenzaiko.Clear();

            txtCalendarYMopen.Text = strkensakuopen;
            txtCalendarYMclose.Text = strkensakuclose;
        }

        ///<summary>
        ///updDaibun
        ///リスト内の大分類が変更されたのを反映
        ///</summary>
        public void setDaibun(string strDaibun)
        {
            labelSet_Daibunrui.CodeTxtText = strDaibun;
        }
    }
}
