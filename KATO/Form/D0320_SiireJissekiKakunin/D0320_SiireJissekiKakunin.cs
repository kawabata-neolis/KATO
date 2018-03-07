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
using KATO.Business.D0320_SiireJissekiKakunin;
using KATO.Form.A0030_ShireInput;

namespace KATO.Form.D0320_SiireJissekiKakunin
{
    /// <summary>
    /// D0320_SiireJissekiKakunin
    /// 仕入実績確認フォーム
    /// 作成者：多田
    /// 作成日：2017/7/5
    /// 更新者：多田
    /// 更新日：2017/7/5
    /// カラム論理名
    /// </summary>
    public partial class D0320_SiireJissekiKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // 画面ID
        private int intFrm;

        // 仕入先コード
        private string strSiiresakiCd;

        // ユーザーID
        private string strUserId = Environment.UserName;

        /// <summary>
        /// D0320_SiireJissekiKakunin
        /// フォーム関係の設定
        /// <param name="intFrm">画面ID</param>
        /// <param name="strSiiresakiCd">仕入先コード</param>
        /// </summary>
        public D0320_SiireJissekiKakunin(Control c, int intFrm = 0, string strSiiresakiCd = "")
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

            // 画面IDをセット
            this.intFrm = intFrm;
            // 仕入先コードをセット
            this.strSiiresakiCd = strSiiresakiCd;
            // 営業所ラジオボタンはすべてを選択
            radEigyosho.radbtn0.Checked = true;
        }

        /// <summary>
        /// D0320_SiireJissekiKakunin_Load
        /// 読み込み時
        /// </summary>
        private void D0320_SiireJissekiKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "仕入実績確認";

            // ステータスバーにメッセージ
            this.lblStatusMessage.Text = "F9を押すと、一覧選択または検索ができます";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF12.Text = STR_FUNC_F12;

            // F9:検索は常にdisable
            this.btnF09.Enabled = false;

            // 閲覧権限がある場合のみF7とF11に文字を表示
            if (etsuranFlg.Equals("1"))
            {
                this.btnF07.Text = "F7:CSV";
                this.btnF11.Text = STR_FUNC_F11;
            }
            else
            {
                // 営業コードからラジオボタンの初期チェックを設定
                if (eigyoCode.Equals("0001"))
                {
                    radEigyosho.radbtn1.Checked = true;
                }
                else
                {
                    radEigyosho.radbtn2.Checked = true;
                }
            }

            // 初期表示
            radSortOrder.radbtn1.Checked = true;    // 並び順：Z-Aにチェック
            labelSet_Htanto.Focus();

            // 伝票年月日の設定
            txtDenpyoYMDEnd.setUp(2);
            DateTime dateYMDStart = DateTime.Parse(txtDenpyoYMDEnd.Text);
            txtDenpyoYMDStart.Text = dateYMDStart.AddMonths(-1).ToString().Substring(0, 8) + "01";

            // 中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            // DataGridViewの初期設定
            SetUpGrid();
        }

        /// <summary>
        /// D0320_SiireJissekiKakunin_Shown
        /// フォームが最初に表示された時
        /// </summary>
        private void D0320_SiireJissekiKakunin_Shown(object sender, EventArgs e)
        {
            //仕入入力フォームから呼ばれた場合
            if (this.intFrm == 3)
            {
                labelSet_Siiresaki.CodeTxtText = this.strSiiresakiCd;

                if (labelSet_Siiresaki.codeTxt.blIsEmpty())
                {
                    this.setSiireJisseki();
                }
            }

            // 発注入力フォームから呼ばれた場合
            if (this.intFrm == 10)
            {
                // ラジオボタン初期表示
                radEigyosho.radbtn0.Checked = true;     // 営業所：すべてにチェック 
                radSortOrder.radbtn1.Checked = true;    // 並び順：Z-Aにチェック
                labelSet_Htanto.Focus();

                // 伝票年月日の設定
                txtDenpyoYMDEnd.setUp(2);
                DateTime dateYMDStart = DateTime.Parse(txtDenpyoYMDEnd.Text);
                txtDenpyoYMDStart.Text = dateYMDStart.AddMonths(-1).ToString().Substring(0, 8) + "01";

                labelSet_Siiresaki.CodeTxtText = this.strSiiresakiCd;
                this.setSiireJisseki();
            }

            // ステータスバーに検索結果表示
            this.lblStatusMessage.Text = "F9を押すと、一覧表示または検索ができます";
        }

        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            // 列自動生成禁止
            gridSiireJisseki.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn hiduke = new DataGridViewTextBoxColumn();
            hiduke.DataPropertyName = "伝票年月日";
            hiduke.Name = "伝票年月日";
            hiduke.HeaderText = "日付";

            DataGridViewTextBoxColumn denpyoNo = new DataGridViewTextBoxColumn();
            denpyoNo.DataPropertyName = "伝票番号";
            denpyoNo.Name = "伝票番号";
            denpyoNo.HeaderText = "伝№";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー";
            maker.Name = "メーカー";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "品名型式";
            kataban.Name = "品名型式";
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

            DataGridViewTextBoxColumn bikou = new DataGridViewTextBoxColumn();
            bikou.DataPropertyName = "備考";
            bikou.Name = "備考";
            bikou.HeaderText = "備  考";

            DataGridViewTextBoxColumn syukaName = new DataGridViewTextBoxColumn();
            syukaName.DataPropertyName = "出荷先名";
            syukaName.Name = "出荷先名";
            syukaName.HeaderText = "出荷先名";

            DataGridViewTextBoxColumn siireName = new DataGridViewTextBoxColumn();
            siireName.DataPropertyName = "仕入先名";
            siireName.Name = "仕入先名";
            siireName.HeaderText = "仕入先名";

            DataGridViewTextBoxColumn hachuNo = new DataGridViewTextBoxColumn();
            hachuNo.DataPropertyName = "発注番号";
            hachuNo.Name = "発注番号";
            hachuNo.HeaderText = "発注番号";

            DataGridViewTextBoxColumn hachuTanto = new DataGridViewTextBoxColumn();
            hachuTanto.DataPropertyName = "発注担当";
            hachuTanto.Name = "発注担当";
            hachuTanto.HeaderText = "発注担当者";

            DataGridViewTextBoxColumn siireTanto = new DataGridViewTextBoxColumn();
            siireTanto.DataPropertyName = "仕入担当";
            siireTanto.Name = "仕入担当";
            siireTanto.HeaderText = "仕入担当者";

            DataGridViewTextBoxColumn juchuNo = new DataGridViewTextBoxColumn();
            juchuNo.DataPropertyName = "受注番号";
            juchuNo.Name = "受注番号";
            juchuNo.HeaderText = "受注番号";

            DataGridViewTextBoxColumn juchuTanka = new DataGridViewTextBoxColumn();
            juchuTanka.DataPropertyName = "受注単価";
            juchuTanka.Name = "受注単価";
            juchuTanka.HeaderText = "受注単価";

            DataGridViewTextBoxColumn juchuKingaku = new DataGridViewTextBoxColumn();
            juchuKingaku.DataPropertyName = "受注金額";
            juchuKingaku.Name = "受注金額";
            juchuKingaku.HeaderText = "受注金額";

            DataGridViewTextBoxColumn juchuYmd = new DataGridViewTextBoxColumn();
            juchuYmd.DataPropertyName = "受注日";
            juchuYmd.Name = "受注日";
            juchuYmd.HeaderText = "受注日";

            DataGridViewTextBoxColumn juchuTanto = new DataGridViewTextBoxColumn();
            juchuTanto.DataPropertyName = "受注担当";
            juchuTanto.Name = "受注担当";
            juchuTanto.HeaderText = "受注担当";

            DataGridViewTextBoxColumn eigyoTanto = new DataGridViewTextBoxColumn();
            eigyoTanto.DataPropertyName = "営業担当";
            eigyoTanto.Name = "営業担当";
            eigyoTanto.HeaderText = "営業担当";

            // 個々の幅、文字の寄せ
            setColumn(hiduke, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(denpyoNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 80);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 530);
            setColumn(suuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 120);
            setColumn(kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumn(bikou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumn(syukaName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 320);
            setColumn(siireName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 320);
            setColumn(hachuNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 100);
            setColumn(hachuTanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(siireTanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(juchuNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 100);
            setColumn(juchuTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 120);
            setColumn(juchuKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumn(juchuYmd, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(juchuTanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(eigyoTanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridSiireJisseki.Columns.Add(col);
            if (gridSiireJisseki.Columns[col.Name] != null)
            {
                gridSiireJisseki.Columns[col.Name].Width = intLen;
                gridSiireJisseki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridSiireJisseki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridSiireJisseki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// D0320_SiireJissekiKakunin_KeyDown
        /// キー入力判定
        /// </summary>
        private void D0320_SiireJissekiKakunin_KeyDown(object sender, KeyEventArgs e)
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
                    this.setSiireJisseki();
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
                    // 閲覧権限がある場合のみ有効
                    if (etsuranFlg.Equals("1"))
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "CSV実行"));
                        this.exportCsv();
                    }
                    break;
                case Keys.F8:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    // 閲覧権限がある場合のみ有効
                    if (etsuranFlg.Equals("1"))
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
                case STR_BTN_F01: // 表示
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setSiireJisseki();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F07: // CSV
                    // 閲覧権限がある場合のみ有効
                    if (etsuranFlg.Equals("1"))
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "CSV実行"));
                        this.exportCsv();
                    }
                    break;
                case STR_BTN_F11: // 印刷
                    // 閲覧権限がある場合のみ有効
                    if (etsuranFlg.Equals("1"))
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
        /// gridSiireJisseki_CellMouseDoubleClick
        /// グリッドビューのセルがダブルクリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridSiireJisseki_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gridSiireJisseki.RowCount > 0)
            {
                // 加工原価確認フォームを開く
                string strJuchuNo = gridSiireJisseki.CurrentRow.Cells[13].Value.ToString();
                KATO.Common.Form.KakouGenkaList kakou = new Common.Form.KakouGenkaList(this, strJuchuNo);
                kakou.ShowDialog();
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // 削除するデータ以外を確保
            string strYmdStart = txtDenpyoYMDStart.Text;
            string strYmdEnd = txtDenpyoYMDEnd.Text;

            // 画面の項目内を白紙にする
            delFormClear(this, gridSiireJisseki);

            txtDenpyoYMDStart.Text = strYmdStart;
            txtDenpyoYMDEnd.Text = strYmdEnd;

            labelSet_Siiresaki.Focus();
        }

        /// <summary>
        /// setSiireJisseki
        /// データをグリッドビューに追加
        /// </summary>
        private void setSiireJisseki()
        {
            // カーソルを待機状態にする
            this.Cursor = Cursors.WaitCursor;

            // 検索条件格納用
            List<string> lstSearchItem = new List<string>();
            List<Array> lstSearchItem2 = new List<Array>();

            // データチェック
            if (!blnDataCheck())
            {
                // カーソルの状態を元に戻す
                this.Cursor = Cursors.Default;

                return;
            }

            // ビジネス層のインスタンス生成
            D0320_SiireJissekiKakunin_B siireB = new D0320_SiireJissekiKakunin_B();
            try
            {
                // 検索条件をリストに格納
                lstSearchItem = setSearchList();    // テキストボックスの値
                lstSearchItem2 = getRadioBtn();     // ラジオボタン・チェックボックスの値

                // 検索実行
                DataTable dtSiireJissekiList = siireB.getSiireJissekiList(lstSearchItem, lstSearchItem2);

                // データテーブルからデータグリッドへセット
                gridSiireJisseki.DataSource = dtSiireJissekiList;

                if (dtSiireJissekiList != null && dtSiireJissekiList.Rows.Count > 0)
                {
                    // 合計金額
                    decimal decGoukei = 0;

                    for (int cnt = 0; cnt < gridSiireJisseki.RowCount; cnt++)
                    {
                        // 数量
                        decimal decSuuryo = decimal.Parse(gridSiireJisseki.Rows[cnt].Cells["数量"].Value.ToString());

                        // 金額
                        decimal decKingaku = decimal.Parse(gridSiireJisseki.Rows[cnt].Cells["仕入金額"].Value.ToString());
                        decGoukei += decKingaku;

                        // 数量又は金額がマイナスの場合はフォントカラーを変更
                        if (decSuuryo < 0 || decKingaku < 0)
                        {
                            gridSiireJisseki.Rows[cnt].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }

                    // 閲覧権限がある場合のみ有効
                    if (etsuranFlg.Equals("1"))
                    {
                        txtKingaku.Text = decGoukei.ToString("#,#");
                    }
                    else
                    {
                        // 対象期間チェック
                        if (blnKikanCheck())
                        {
                            txtKingaku.Text = decGoukei.ToString("#,#");
                        }
                        else
                        {
                            txtKingaku.Text = "";
                        }

                        // 仕入先コードがない場合
                        if (labelSet_Siiresaki.CodeTxtText.Equals(""))
                        {
                            txtKingaku.Text = "";
                        }
                    }

                    Control cNow = this.ActiveControl;
                    cNow.Focus();
                }
                // DataTableのレコード数取得
                int dtCnt = dtSiireJissekiList.Rows.Count;
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
                // gridにフォーカス
                gridSiireJisseki.Focus();

                // カーソルの状態を元に戻す
                this.Cursor = Cursors.Default;

            }
            catch(Exception ex)
            {
                // カーソルの状態を元に戻す
                this.Cursor = Cursors.Default;

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
            return;
        }


        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            // 検索条件格納用
            List<string> lstSearchItem = new List<string>();
            List<Array> lstSearchItem2 = new List<Array>();

            DataTable dtSiireJisseki = new DataTable();

            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // ヘッダーに条件を出力する値
            lstSearchItem.Add(labelSet_Siiresaki.ValueLabelText);   //仕入先名
            lstSearchItem.Add(labelSet_Daibunrui.ValueLabelText);   //大分類名
            lstSearchItem.Add(labelSet_Chubunrui.ValueLabelText);   //中分類名

            // ビジネス層のインスタンス生成
            D0320_SiireJissekiKakunin_B siireB = new D0320_SiireJissekiKakunin_B();
            try
            {
                // 検索データをリストに格納
                lstSearchItem = setSearchList();
                lstSearchItem2 = getRadioBtn();

                // 検索実行
                dtSiireJisseki = siireB.getSiireJissekiList(lstSearchItem, lstSearchItem2);

                if (dtSiireJisseki != null && dtSiireJisseki.Rows.Count > 0)
                {
                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A3, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // PDF出力用List(各テキストボックスの値をコードではなく名称で取得)
                    List<string> lstoutItem = new List<string>();
                    lstoutItem.Add(txtDenpyoYMDStart.Text);              // 伝票年月日Start
                    lstoutItem.Add(txtDenpyoYMDEnd.Text);                // 伝票年月日End
                    lstoutItem.Add(labelSet_Etanto.ValueLabelText);      // 営業担当者名
                    lstoutItem.Add(labelSet_Htanto.ValueLabelText);      // 発注者名
                    lstoutItem.Add(labelSet_Jtanto.ValueLabelText);      // 受注者名
                    lstoutItem.Add(labelSet_Siiresaki.ValueLabelText);   // 仕入先名称
                    lstoutItem.Add(labelSet_Daibunrui.ValueLabelText);   // 大分類名称
                    lstoutItem.Add(labelSet_Chubunrui.ValueLabelText);   // 中分類名称
                    lstoutItem.Add(txtKataban.Text);                     // 型番1
                    lstoutItem.Add(txtKataban2.Text);                    // 型番2
                    lstoutItem.Add(txtKataban3.Text);                    // 型番3
                    lstoutItem.Add(txtBikou.Text);                       // 備考
                    lstoutItem.Add(labelSet_Tokuisaki.ValueLabelText);   // 得意先名称


                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // カーソルを待機状態にする
                        this.Cursor = Cursors.WaitCursor;

                        // PDF作成
                        String strFile = siireB.dbToPdf(dtSiireJisseki, lstoutItem);

                        // プレビュー
                        pf.execPreview(strFile);
                        pf.ShowDialog(this);

                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // カーソルを待機状態にする
                        this.Cursor = Cursors.WaitCursor;

                        // PDF作成
                        String strFile = siireB.dbToPdf(dtSiireJisseki, lstoutItem);

                        // 一括印刷
                        pf.execPrint(null, strFile, CommonTeisu.SIZE_A3, CommonTeisu.YOKO, true);

                    }

                    pf.Dispose();

                    // カーソルの状態を元に戻す
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    // カーソルの状態を元に戻す
                    this.Cursor = Cursors.Default;

                    // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                // カーソルの状態を元に戻す
                this.Cursor = Cursors.Default;

                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、PDF作成失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "印刷が失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }

        }

        /// <summary>
        /// exportCsv
        /// CSVを出力する
        /// </summary>
        private void exportCsv()
        {
            // 検索条件格納用
            List<string> lstSearchItem = new List<string>();
            List<Array> lstSearchItem2 = new List<Array>();

            DataTable dtSiireJisseki = new DataTable();

            // ファイル保存用
            SaveFileDialog sfd = new SaveFileDialog();

            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // ファイル名の指定
            sfd.FileName = "仕入" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";

            // デフォルトのフォルダ位置
            sfd.InitialDirectory = "MyDocuments";

            // ファイルフィルタの設定
            sfd.Filter = "CSVファイル(*.csv)|*.csv";

            // タイトルの設定
            sfd.Title = "保存先のファイルを選択してください";

            // ダイアログを表示
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // ビジネス層のインスタンス生成
                D0320_SiireJissekiKakunin_B siireB = new D0320_SiireJissekiKakunin_B();
                try
                {
                    // 検索データをリストに格納
                    lstSearchItem = setSearchList();
                    lstSearchItem2 = getRadioBtn();

                    // 検索実行
                    dtSiireJisseki = siireB.getSiireJissekiList(lstSearchItem, lstSearchItem2);

                    if (dtSiireJisseki != null && dtSiireJisseki.Rows.Count > 0)
                    {
                        // CSV出力
                        siireB.dbToCsv(dtSiireJisseki, sfd.FileName);

                        // メッセージボックスの処理、CSV作成完了の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "CSVファイルを作成しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessagebox.ShowDialog();
                    }
                    else
                    {
                        // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "該当データはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessagebox.ShowDialog();
                    }

                }
                catch (Exception ex)
                {
                    // エラーロギング
                    new CommonException(ex);

                    // メッセージボックスの処理、CSV作成失敗の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "処理中にエラーが発生しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return;
                }
            }

            return;
        }

        /// <summary>
        /// blnDataCheck
        /// データチェック
        /// </summary>
        private Boolean blnDataCheck()
        {
            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            // 空文字判定（仕入先コード、発注担当者、型番、大分類、伝票年月日）
            if (labelSet_Etanto.CodeTxtText.Equals("") && labelSet_Htanto.CodeTxtText.Equals("") && labelSet_Jtanto.CodeTxtText.Equals("") &&
                labelSet_Siiresaki.CodeTxtText.Equals("") && txtKataban.Text.Equals("") && labelSet_Daibunrui.CodeTxtText.Equals("") &&
                txtDenpyoYMDStart.Text.Equals("") && txtDenpyoYMDEnd.Text.Equals("") )
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n条件を指定してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return false;
            }

            // 伝票年月日のStart・Endは必須項目
            if (txtDenpyoYMDStart.Text.Equals(""))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDStart.Focus();

                return false;
            }
            if (txtDenpyoYMDEnd.Text.Equals(""))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDEnd.Focus();

                return false;
            }

            //発注担当者チェック
            if (labelSet_Htanto.chkTxtTantosha())
            {
                labelSet_Htanto.Focus();

                return false;
            }

            //受注担当者チェック
            if (labelSet_Jtanto.chkTxtTantosha())
            {
                labelSet_Jtanto.Focus();

                return false;
            }

            //営業担当者チェック
            if (labelSet_Etanto.chkTxtTantosha())
            {
                labelSet_Etanto.Focus();

                return false;
            }

            //仕入先チェック
            if (labelSet_Siiresaki.chkTxtTorihikisaki())
            {
                labelSet_Siiresaki.Focus();

                return false;
            }

            //得意先チェック
            if (labelSet_Tokuisaki.chkTxtTorihikisaki())
            {
                labelSet_Tokuisaki.Focus();

                return false;
            }

            //日付フォーマット生成、およびチェック
            strYMDformat = txtDenpyoYMDStart.chkDateDataFormat(txtDenpyoYMDStart.Text);

            //開始伝票年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDStart.Focus();

                return false;
            }
            else
            {
                txtDenpyoYMDStart.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtDenpyoYMDEnd.chkDateDataFormat(txtDenpyoYMDEnd.Text);

            //終了伝票年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDEnd.Focus();

                return false;
            }
            else
            {
                txtDenpyoYMDEnd.Text = strYMDformat;
            }

            //大分類チェック
            if (labelSet_Daibunrui.chkTxtDaibunrui())
            {
                labelSet_Daibunrui.Focus();

                return false;
            }

            //中分類チェック
            if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
            {
                labelSet_Chubunrui.Focus();

                return false;
            }

            //メーカーチェック
            if (labelSet_Maker.chkTxtMaker())
            {
                labelSet_Maker.Focus();

                return false;
            }
            
            return true;
        }

        /// <summary>
        /// setSearchList
        /// 検索データをリストに格納
        /// </summary>
        private List<string> setSearchList()
        {
            List<string> lstSearchItem = new List<string>();

            // 検索するデータをリストに格納
            lstSearchItem.Add(txtDenpyoYMDStart.Text);          // 伝票年月日Start
            lstSearchItem.Add(txtDenpyoYMDEnd.Text);            // 伝票年月日End
            lstSearchItem.Add(labelSet_Etanto.CodeTxtText);  // 営業担当者コード
            lstSearchItem.Add(labelSet_Htanto.CodeTxtText);  // 発注者コード
            lstSearchItem.Add(labelSet_Jtanto.CodeTxtText);  // 受注者コード
            lstSearchItem.Add(labelSet_Siiresaki.CodeTxtText);  // 仕入先コード
            lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);  // 大分類コード
            lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);  // 中分類コード
            lstSearchItem.Add(labelSet_Maker.CodeTxtText);  // メーカーコード
            lstSearchItem.Add(txtKataban.Text);                 // 型番1
            lstSearchItem.Add(txtKataban2.Text);                // 型番2
            lstSearchItem.Add(txtKataban3.Text);                // 型番3
            lstSearchItem.Add(txtBikou.Text);                   // 備考
            lstSearchItem.Add(labelSet_Tokuisaki.CodeTxtText);  // 得意先コード

            return lstSearchItem;
        }

        /// <summary>
        /// ラジオボタンの検索条件を取得
        /// </summary>
        private List<Array> getRadioBtn()
        {
            List<Array> arrList = new List<Array>();

            // 表示条件取得用(営業所)
            string[] arrDispEigyo = new string[3];
            // 表示条件取得用(グループコード)
            string[] arrDispGroup = new string[5];
            // 出力順条件取得用
            string[] arrOrder = new string[4];
            // 出力順条件取得用(A-Z,Z-A)
            string[] arrOrderAtoZ = new string[2];

            // 営業所
            arrDispEigyo[0] = radEigyosho.radbtn0.Checked.ToString().ToUpper(); // すべて
            arrDispEigyo[1] = radEigyosho.radbtn1.Checked.ToString().ToUpper(); // 本社
            arrDispEigyo[2] = radEigyosho.radbtn2.Checked.ToString().ToUpper(); // 岐阜

            // グループコード
            arrDispGroup[0] = radGroupCd0.Checked.ToString().ToUpper();         // すべて
            arrDispGroup[1] = radGroupCd1.Checked.ToString().ToUpper();         // 共通
            arrDispGroup[2] = radGroupCd2.Checked.ToString().ToUpper();         // １
            arrDispGroup[3] = radGroupCd3.Checked.ToString().ToUpper();         // ２
            arrDispGroup[4] = radGroupCd4.Checked.ToString().ToUpper();         // ３

            // 並び順
            arrOrder[0] = radSortItem0.Checked.ToString().ToUpper();            // 仕入日
            arrOrder[1] = radSortItem1.Checked.ToString().ToUpper();            // 注番
            arrOrder[2] = radSortItem2.Checked.ToString().ToUpper();            // 金額
            arrOrder[3] = radSortItem3.Checked.ToString().ToUpper();            // 受注日

            // 並び順
            arrOrderAtoZ[0] = radSortOrder.radbtn0.Checked.ToString().ToUpper();// A-Z
            arrOrderAtoZ[1] = radSortOrder.radbtn1.Checked.ToString().ToUpper();// Z-A

            arrList.Add(arrDispEigyo);
            arrList.Add(arrDispGroup);
            arrList.Add(arrOrder);
            arrList.Add(arrOrderAtoZ);

            return arrList;

        }

        /// <summary>
        /// blnKikanCheck
        /// 対象期間チェック
        /// </summary>
        private Boolean blnKikanCheck()
        {
            // 閲覧権限ありの場合
            if (etsuranFlg.Equals("1"))
            {
                return true;
            }

            // 伝票年月日が空の場合
            if (txtDenpyoYMDStart.Text.Equals("") || txtDenpyoYMDEnd.Text.Equals(""))
            {
                return false;
            }

            // 伝票年月日の間隔が2を超える場合
            if (!blnDateDiff(txtDenpyoYMDStart.Text, txtDenpyoYMDEnd.Text))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// blnDateDiff
        /// 入力した年月日の月間隔が2を超えるかを判断
        /// </summary>
        private Boolean blnDateDiff(string strStartYMD, string strEndYMD)
        {
            int diff;

            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MaxValue;
            DateTime dtStartYMD = DateTime.MinValue;
            DateTime dtEndYMD = DateTime.MaxValue;

            dtStartYMD = DateTime.Parse(strStartYMD);
            dtEndYMD = DateTime.Parse(strEndYMD);

            if (dtStartYMD < dtEndYMD)
            {
                dtFrom = dtStartYMD;
                dtTo = dtEndYMD;
            }
            else
            {
                dtFrom = dtEndYMD;
                dtTo = dtStartYMD;
            }

            // 月差計算（年差考慮(差分1年 → 12(ヶ月)加算)）
            diff = (dtTo.Month + (dtTo.Year - dtFrom.Year) * 12) - dtFrom.Month;

            // 差分が2を超える場合
            if (diff > 2)
            {
                return false;
            }

            return true;
        }

        #region テキストボックスのKeyDownイベント（EnterキーでTAB）
        // 品名・型番テキストボックス（１番目）
        private void txtKataban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        // 品名・型番テキストボックス（２番目）
        private void txtKataban2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        // 品名・型番テキストボックス（３番目）
        private void txtKataban3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        // 備考テキストボックス
        private void txtBikou_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion
    }

}
