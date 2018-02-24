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
using KATO.Business.D0280_SoukoIdouKakunin;

namespace KATO.Form.D0280_SoukoIdouKakunin
{

    /// <summary>
    /// D0280_SoukoIdouKakunin
    /// 倉庫移動確認フォーム
    /// 作成者：宇津野
    /// 作成日：2018/02/21
    /// 更新者：宇津野
    /// 更新日：2018/02/21
    /// カラム論理名
    /// </summary>
    public partial class D0280_SoukoIdouKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// D0280_SoukoIdouKakunin
        /// フォーム関係の設定
        /// <param name="strSiiresakiCd">仕入先コード</param>
        /// </summary>
        public D0280_SoukoIdouKakunin(Control c)
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
            
        }

        /// <summary>
        /// D0280_SoukoIdouKakunin_Load
        /// 読み込み時
        /// </summary>
        private void D0280_SoukoIdouKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "倉庫移動確認";

            // ステータスバーにメッセージ
            this.lblStatusMessage.Text = "F9を押すと、一覧選択または検索ができます";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            // F9:検索は常にdisable
            this.btnF09.Enabled = false;

            // SPPowerUserの場合のみF11に文字を表示
            if ("1".Equals(this.etsuranFlg))
            {
                this.btnF11.Text = STR_FUNC_F11;
                this.btnF11.Enabled = true;
            }
            else
            {
                this.btnF11.Text = "";
                this.btnF11.Enabled = false;
            }

            // 初期表示
            labelSet_Eigyosho.Focus();

            // 伝票年月日の設定
            txtIdouYMDEnd.setUp(2);
            DateTime dateYMDStart = DateTime.Parse(txtIdouYMDEnd.Text);
            txtIdouYMDStart.Text = dateYMDStart.AddMonths(-1).ToString().Substring(0, 8) + "01";

            // 中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            // DataGridViewの初期設定
            SetUpGrid();
        }


        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            // 列自動生成禁止
            gridSoukoIdou.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn hiduke = new DataGridViewTextBoxColumn();
            hiduke.DataPropertyName = "年月日";
            hiduke.Name = "年月日";
            hiduke.HeaderText = "日付";

            DataGridViewTextBoxColumn denpyoNo = new DataGridViewTextBoxColumn();
            denpyoNo.DataPropertyName = "伝票番号";
            denpyoNo.Name = "伝票番号";
            denpyoNo.HeaderText = "伝№";

            DataGridViewTextBoxColumn syoriName = new DataGridViewTextBoxColumn();
            syoriName.DataPropertyName = "処理名";
            syoriName.Name = "処理名";
            syoriName.HeaderText = "処理名";

            DataGridViewTextBoxColumn kubunName = new DataGridViewTextBoxColumn();
            kubunName.DataPropertyName = "区分名";
            kubunName.Name = "区分名";
            kubunName.HeaderText = "区分名";

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
            tanka.DataPropertyName = "単価";
            tanka.Name = "単価";
            tanka.HeaderText = "受注単価";

            DataGridViewTextBoxColumn kingaku = new DataGridViewTextBoxColumn();
            kingaku.DataPropertyName = "金額";
            kingaku.Name = "金額";
            kingaku.HeaderText = "受注金額";

            DataGridViewTextBoxColumn syukkosaki = new DataGridViewTextBoxColumn();
            syukkosaki.DataPropertyName = "出庫先";
            syukkosaki.Name = "出庫先";
            syukkosaki.HeaderText = "出庫先";

            DataGridViewTextBoxColumn iraiName = new DataGridViewTextBoxColumn();
            iraiName.DataPropertyName = "依頼者名";
            iraiName.Name = "依頼者名";
            iraiName.HeaderText = "依頼者名";

            DataGridViewTextBoxColumn shouhinCode = new DataGridViewTextBoxColumn();
            shouhinCode.DataPropertyName = "商品コード";
            shouhinCode.Name = "商品コード";
            shouhinCode.HeaderText = "商品コード";

            DataGridViewTextBoxColumn juchuNo = new DataGridViewTextBoxColumn();
            juchuNo.DataPropertyName = "受注番号";
            juchuNo.Name = "受注番号";
            juchuNo.HeaderText = "受注番号";
            

            // 個々の幅、文字の寄せ
            setColumn(hiduke, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(denpyoNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 80);
            setColumn(syoriName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(kubunName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 530);
            setColumn(suuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 80);
            setColumn(tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 120);
            setColumn(kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumn(syukkosaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(iraiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(shouhinCode, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 120);
            setColumn(juchuNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 100);

            shouhinCode.Visible = false;

        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridSoukoIdou.Columns.Add(col);
            if (gridSoukoIdou.Columns[col.Name] != null)
            {
                gridSoukoIdou.Columns[col.Name].Width = intLen;
                gridSoukoIdou.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridSoukoIdou.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridSoukoIdou.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// D0280_SoukoIdouKakunin_KeyDown
        /// キー入力判定
        /// </summary>
        private void D0280_SoukoIdouKakunin_KeyDown(object sender, KeyEventArgs e)
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
                    this.setSoukoIdou();
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
                    // 閲覧権限がある場合のみ有効
                    if ("1".Equals(etsuranFlg))
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
                    this.setSoukoIdou();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F11: // 印刷
                    // 閲覧権限がある場合のみ有効
                    if ("1".Equals(etsuranFlg))
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
        /// judNyukinCheckKeyDown
        /// キー入力判定(テキストボックス【Labelset以外全て】)
        /// </summary>
        private void judSoukoIdouKeyDown(object sender, KeyEventArgs e)
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
                    // タブ機能
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
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // 削除するデータ以外を確保
            string strYmdStart = txtIdouYMDStart.Text;
            string strYmdEnd = txtIdouYMDEnd.Text;

            // 画面の項目内を白紙にする
            delFormClear(this, gridSoukoIdou);

            txtIdouYMDStart.Text = strYmdStart;
            txtIdouYMDEnd.Text = strYmdEnd;
        }

        /// <summary>
        /// setSoukoIdou
        /// データをグリッドビューに追加
        /// </summary>
        private void setSoukoIdou()
        {

            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // 検索条件格納用
            List<string> lstSearchItem = new List<string>();
            List<Array> lstSearchItem2 = new List<Array>();

            // ビジネス層のインスタンス生成
            D0280_SoukoIdouKakunin_B soukoIdouB = new D0280_SoukoIdouKakunin_B();
            try
            {
                // 検索条件をリストに格納
                lstSearchItem = setSearchList();    // テキストボックスの値
                lstSearchItem2 = getRadioBtn();     // ラジオボタン・チェックボックスの値

                // 検索実行
                DataTable dtSoukoIdouList = soukoIdouB.getSoukoIdouList(lstSearchItem, lstSearchItem2 ,1);

                // データテーブルからデータグリッドへセット
                gridSoukoIdou.DataSource = dtSoukoIdouList;

                // DataTableのレコード数取得
                int dtCnt = dtSoukoIdouList.Rows.Count;
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
                gridSoukoIdou.Focus();

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

            DataTable dtSoukoIdou = new DataTable();

            // ビジネス層のインスタンス生成
            D0280_SoukoIdouKakunin_B soukoIdouB = new D0280_SoukoIdouKakunin_B();
            try
            {
                // 検索データをリストに格納
                lstSearchItem = setSearchList();
                lstSearchItem2 = getRadioBtn();

                // 検索実行
                dtSoukoIdou = soukoIdouB.getSoukoIdouList(lstSearchItem, lstSearchItem2 , 2);

                if (dtSoukoIdou != null && dtSoukoIdou.Rows.Count > 0)
                {
                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A3, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // PDF出力用List(各テキストボックスの値をコードではなく名称で取得)
                    List<string> lstoutItem = new List<string>();
                    lstoutItem.Add(labelSet_Eigyosho.ValueLabelText);   // 営業所
                    lstoutItem.Add(txtIdouYMDStart.Text);               // 移動年月日Start
                    lstoutItem.Add(txtIdouYMDEnd.Text);                 // 移動年月日End
                    lstoutItem.Add(labelSet_Daibunrui.ValueLabelText);  // 大分類名称
                    lstoutItem.Add(txtKataban.Text);                    // 型番
                    lstoutItem.Add(txtBikou.Text);                      // 備考


                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // カーソルを待機状態にする
                        this.Cursor = Cursors.WaitCursor;

                        // PDF作成
                        String strFile = soukoIdouB.dbToPdf(dtSoukoIdou, lstoutItem);

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
                        String strFile = soukoIdouB.dbToPdf(dtSoukoIdou, lstoutItem);

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
        /// blnDataCheck
        /// データチェック
        /// </summary>
        private Boolean blnDataCheck()
        {
            // 移動年月日のStart・Endは必須項目
            if (txtIdouYMDStart.Text.Equals(""))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtIdouYMDStart.Focus();

                return false;
            }
            if (txtIdouYMDEnd.Text.Equals(""))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtIdouYMDEnd.Focus();

                return false;
            }

            // 移動年月日のStart・Endの日付フォーマットチェック
            string datedata = txtIdouYMDStart.chkDateDataFormat(txtIdouYMDStart.Text);
            if("".Equals(datedata))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return false;
            }
            else
            {
                txtIdouYMDStart.Text = datedata;
            }

            datedata = txtIdouYMDEnd.chkDateDataFormat(txtIdouYMDEnd.Text);
            if ("".Equals(datedata))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return false;
            }
            else
            {
                txtIdouYMDEnd.Text = datedata;
            }

            // 空文字チェック（営業所コード）
            if (labelSet_Eigyosho.codeTxt.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Eigyosho.Focus();
                return false;
            }
            // 文字列チェック（営業所コード）
            if (labelSet_Eigyosho.chkTxtEigyousho())
            {
                return false;
            }

            // 文字列チェック（大分類コード）
            if (labelSet_Daibunrui.chkTxtDaibunrui())
            {
                return false;
            }


            // 大分類が存在していないが中分類が存在している場合
            if ("".Equals(labelSet_Daibunrui.CodeTxtText) && !"".Equals(labelSet_Chubunrui.CodeTxtText))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                // 中分類コードを空にする。
                labelSet_Chubunrui.CodeTxtText = "";
                labelSet_Chubunrui.ValueLabelText = "";

                labelSet_Daibunrui.Focus();
                return false;
            }
            // 大分類が存在していて中分類も存在している場合
            else if (!"".Equals(labelSet_Daibunrui.CodeTxtText) && !"".Equals(labelSet_Chubunrui.CodeTxtText))
            {
                // 文字列チェック（中分類コード）
                if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
                {
                    return false;
                }
            }

            // 文字列チェック（メーカー）
            if (labelSet_Maker.chkTxtMaker())
            {
                return false;
            }

            // 文字列チェック（担当者）
            if (labelSet_Tantousha.chkTxtTantosha())
            {
                return false;
            }

            // 文字列チェック（担当者）
            if (labelSet_Nyuuryokusha.chkTxtTantosha())
            {
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
            lstSearchItem.Add(labelSet_Eigyosho.CodeTxtText);       // 営業所コード
            lstSearchItem.Add(txtIdouYMDStart.Text);                // 移動年月日Start
            lstSearchItem.Add(txtIdouYMDEnd.Text);                  // 移動年月日End
            lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);      // 大分類コード
            lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);      // 中分類コード
            lstSearchItem.Add(labelSet_Maker.CodeTxtText);          // メーカーコード
            lstSearchItem.Add(txtKataban.Text);                     // 型番
            lstSearchItem.Add(txtBikou.Text);                       // 備考
            lstSearchItem.Add(txtDenpyoNo.Text);                    // 伝票番号
            lstSearchItem.Add(labelSet_Tantousha.CodeTxtText);      // 担当者コード
            lstSearchItem.Add(labelSet_Nyuuryokusha.CodeTxtText);   // 入力者コード

            return lstSearchItem;
        }

        /// <summary>
        /// ラジオボタンの検索条件を取得
        /// </summary>
        private List<Array> getRadioBtn()
        {
            List<Array> arrList = new List<Array>();

            // 出力条件取得用(受注残)
            string[] arrDispJuchuzan = new string[2];
            // 出力条件取得用(処理名)
            string[] arrDispSyoriName = new string[3];
            // 出力条件取得用(区分名)
            string[] arrDispKubunName = new string[5];

            // 出力条件取得用(受注残)格納
            arrDispJuchuzan[0] = radJuchuuzan.radbtn0.Checked.ToString().ToUpper(); // すべて
            arrDispJuchuzan[1] = radJuchuuzan.radbtn1.Checked.ToString().ToUpper(); // 受注残のみ

            // 出力条件取得用(処理名)格納
            arrDispSyoriName[0] = radSyoriName.radbtn0.Checked.ToString().ToUpper(); // すべて
            arrDispSyoriName[1] = radSyoriName.radbtn1.Checked.ToString().ToUpper(); // 受注
            arrDispSyoriName[2] = radSyoriName.radbtn2.Checked.ToString().ToUpper(); // 依頼

            // 出力条件取得用(区分名)格納
            arrDispKubunName[0] = radKubunName.radbtn0.Checked.ToString().ToUpper(); // すべて
            arrDispKubunName[1] = radKubunName.radbtn1.Checked.ToString().ToUpper(); // 移動出
            arrDispKubunName[2] = radKubunName.radbtn2.Checked.ToString().ToUpper(); // 入庫分
            arrDispKubunName[3] = radKubunName.radbtn3.Checked.ToString().ToUpper(); // 移動入
            arrDispKubunName[4] = radKubunName.radbtn4.Checked.ToString().ToUpper(); // 出庫分

            // ラジオボタン格納
            arrList.Add(arrDispJuchuzan);
            arrList.Add(arrDispSyoriName);
            arrList.Add(arrDispKubunName);

            return arrList;

        }

    }

}
