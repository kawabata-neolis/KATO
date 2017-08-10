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

        // SPPowerUser
        private string strSPPowerUser = Environment.UserName;
        //private string strSPPowerUser = "ooba";

        // ユーザーID
        private string strUserId = Environment.UserName;
        //private string strUserId = "ooba";

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
        }

        /// <summary>
        /// D0320_SiireJissekiKakunin_Load
        /// 読み込み時
        /// </summary>
        private void D0320_SiireJissekiKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "仕入実績確認";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF12.Text = STR_FUNC_F12;

            // SPPowerUserの場合のみF7とF11に文字を表示
            if (strSPPowerUser.Equals("ゲストユーザー"))
            {
                this.btnF07.Text = "F7:CSV";
                this.btnF11.Text = STR_FUNC_F11;
            }
            // 特定のユーザーの場合
            else if (strUserId.Equals("k.kato") || strUserId.Equals("s.kato") || strUserId.Equals("ohara") ||
                strUserId.Equals("kawaharazaki") || strUserId.Equals("komori"))
            {
            }
            else
            {
                // ログインIDから営業所コードを取得
                string strEigyoCd = getEigyoCd(Environment.UserName);

                // 営業コードからラジオボタンの初期チェックを設定
                if (strEigyoCd.Equals("0001"))
                {
                    radEigyosho.radbtn1.Checked = true;
                }
                else
                {
                    radEigyosho.radbtn2.Checked = true;
                }
            }

            // 初期表示
            radSortOrder.radbtn1.Checked = true;
            labelSet_Tantousha.Focus();

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
            // 受注入力フォームから呼ばれた場合
            if (this.intFrm == 0010)
            {
                // 【テスト用に日付を変更】
                txtDenpyoYMDStart.Text = "2017/05/01";
                labelSet_Siiresaki.CodeTxtText = this.strSiiresakiCd;
                this.setSiireJisseki();
            }
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

            // 個々の幅、文字の寄せ
            setColumn(hiduke, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(denpyoNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 80);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 520);
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
                    // SPPowerUserの場合のみ有効
                    if (strSPPowerUser.Equals("ゲストユーザー"))
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
                case STR_BTN_F01: // 表示
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setSiireJisseki();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F07: // CSV
                    // SPPowerUserの場合のみ有効
                    if (strSPPowerUser.Equals("ゲストユーザー"))
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "CSV実行"));
                        this.exportCsv();
                    }
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
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // 検索データをリストに格納
            lstSearchItem = setSearchList();

            // ビジネス層のインスタンス生成
            D0320_SiireJissekiKakunin_B siireB = new D0320_SiireJissekiKakunin_B();
            try
            {
                // 検索実行
                DataTable dtSiireJissekiList = siireB.getSiireJissekiList(lstSearchItem);

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

                    // SPPowerUserの場合
                    if (strSPPowerUser.Equals("ゲストユーザー") || strUserId.Equals("k.kato"))
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

            }
            catch
            {
                throw;
            }
            return;
        }


        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // 検索データをリストに格納
            lstSearchItem = setSearchList();

            // ヘッダーに条件を出力する値
            lstSearchItem.Add(labelSet_Siiresaki.ValueLabelText);   //仕入先名
            lstSearchItem.Add(labelSet_Daibunrui.ValueLabelText);   //大分類名
            lstSearchItem.Add(labelSet_Chubunrui.ValueLabelText);   //中分類名

            // ビジネス層のインスタンス生成
            D0320_SiireJissekiKakunin_B siireB = new D0320_SiireJissekiKakunin_B();
            try
            {
                // 検索実行
                DataTable dtSiireJissekiList = siireB.getSiireJissekiList(lstSearchItem);

                if (dtSiireJissekiList != null && dtSiireJissekiList.Rows.Count > 0)
                {
                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A3, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // PDF作成
                        String strFile = siireB.dbToPdf(dtSiireJissekiList, lstSearchItem);

                        // プレビュー
                        pf.execPreview(strFile);
                        pf.ShowDialog(this);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // PDF作成
                        String strFile = siireB.dbToPdf(dtSiireJissekiList, lstSearchItem);

                        // 一括印刷
                        pf.execPrint(null, strFile, CommonTeisu.SIZE_A3, CommonTeisu.YOKO, true);
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

        /// <summary>
        /// exportCsv
        /// CSVを出力する
        /// </summary>
        private void exportCsv()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

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
                // 検索データをリストに格納
                lstSearchItem = setSearchList();

                // ビジネス層のインスタンス生成
                D0320_SiireJissekiKakunin_B siireB = new D0320_SiireJissekiKakunin_B();
                try
                {
                    // 検索実行
                    DataTable dtSiireJissekiList = siireB.getSiireJissekiList(lstSearchItem);

                    if (dtSiireJissekiList != null && dtSiireJissekiList.Rows.Count > 0)
                    {
                        // CSV出力
                        siireB.dbToCsv(dtSiireJissekiList, sfd.FileName);

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
            // 空文字判定（仕入先コード、発注担当者、型番、大分類、伝票年月日）
            if (labelSet_Siiresaki.CodeTxtText.Equals("") && labelSet_Tantousha.CodeTxtText.Equals("") &&
                txtKataban.Text.Equals("") && labelSet_Daibunrui.CodeTxtText.Equals("") &&
                txtDenpyoYMDStart.Text.Equals("") && txtDenpyoYMDEnd.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "条件を指定してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

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
            lstSearchItem.Add(txtDenpyoYMDStart.Text);
            lstSearchItem.Add(txtDenpyoYMDEnd.Text);
            lstSearchItem.Add(labelSet_Tantousha.ValueLabelText);
            lstSearchItem.Add(labelSet_Siiresaki.CodeTxtText);
            lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);
            lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);
            lstSearchItem.Add(txtKataban.Text);
            lstSearchItem.Add(txtBikou.Text);
            lstSearchItem.Add(labelSet_Tokuisaki.CodeTxtText);

            // 営業所（すべて）
            if (radEigyosho.radbtn0.Checked)
            {
                lstSearchItem.Add("0");
            }
            // 営業所（本社）
            else if (radEigyosho.radbtn1.Checked)
            {
                lstSearchItem.Add("1");
            }
            // 営業所（岐阜）
            else if (radEigyosho.radbtn2.Checked)
            {
                lstSearchItem.Add("2");
            }

            // 並び順（仕入日）
            if (radSortItem0.Checked)
            {
                lstSearchItem.Add("0");
            }
            // 並び順（注番）
            else if (radSortItem1.Checked)
            {
                lstSearchItem.Add("1");
            }
            // 並び順（金額）
            else if (radSortItem2.Checked)
            {
                lstSearchItem.Add("2");
            }

            // 並び順（A-Z）
            if (radSortOrder.radbtn0.Checked)
            {
                lstSearchItem.Add("0");
            }
            // 並び順（Z-A）
            else if (radSortOrder.radbtn1.Checked)
            {
                lstSearchItem.Add("1");
            }

            return lstSearchItem;
        }

        /// <summary>
        /// blnKikanCheck
        /// 対象期間チェック
        /// </summary>
        private Boolean blnKikanCheck()
        {
            // SPPowerUserの場合
            if (strSPPowerUser.Equals("ゲストユーザー"))
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

        /// <summary>
        /// getEigyoCd
        /// ログインユーザーの営業コードを取得
        /// </summary>
        private string getEigyoCd(string strUserId)
        {
            string strEigyoCd = "";

            //ビジネス層のインスタンス生成
            D0320_SiireJissekiKakunin_B siireB = new D0320_SiireJissekiKakunin_B();
            try
            {
                // ビジネス層、データグリッドビュー表示用ロジックに移動
                DataTable dtSetView = siireB.getEigyoCd(strUserId);

                // 検索結果が1件以上の場合
                if (dtSetView.Rows.Count > 0)
                {
                    strEigyoCd = dtSetView.Rows[0]["営業所コード"].ToString();
                }
                else
                {
                    strEigyoCd = "0002";
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                return strEigyoCd;
            }

            return strEigyoCd;
        }

    }

 }
