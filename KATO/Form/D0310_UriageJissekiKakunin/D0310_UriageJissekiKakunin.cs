using KATO.Business.D0310_UriageJissekiKakunin;
using KATO.Common.Ctl;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KATO.Common.Util.CommonTeisu;


namespace KATO.Form.D0310_UriageJissekiKakunin
{
    ///<summary>
    ///D0310_UriageJissekiKakunin
    ///売上実績確認
    ///作成者：太田
    ///作成日：2017/07/05
    ///更新者：
    ///更新日：
    ///</summary>
    public partial class D0310_UriageJissekiKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        // 画面ID
        private int intFrm;

        // 得意先コード
        private string strTokuisakiCd;

        // 商品コード
        private string strSyohinCd;

        /// <summary>
        /// D0310_UriageJissekiKakunin
        /// フォーム関係の設定
        /// </summary>
        public D0310_UriageJissekiKakunin(Control c, int intFrm, string strTokuisakiCd, string strSyohinCd)
        {
            if (c == null)
            {
                return;
            }

            // 画面IDをセット
            this.intFrm = intFrm;
            // 得意先コードをセット
            this.strTokuisakiCd = strTokuisakiCd;
            // 商品コードをセット
            this.strSyohinCd = strSyohinCd;
            
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

        }

        public D0310_UriageJissekiKakunin(H0210_MitsumoriInput.H0210_MitsumoriInput c)
        {
            if (c == null)
            {
                return;
            }

            // 画面IDをセット
            this.intFrm = -1;
            // 得意先コードをセット
            this.labelSet_Tokuisaki.CodeTxtText = c.tsTokuisaki.CodeTxtText;
            // 受注者コードをセット
            this.labelSet_Jtanto.CodeTxtText = c.lsTantousha.CodeTxtText;
            // 営業所コード
            //if ()
            //{
            //    // 本社
            //    this.radEigyosho.radbtn1.Checked = true;
            //}
            //else if ()
            //{
            //    // 岐阜
            //    this.radEigyosho.radbtn2.Checked = true;
            //}
            //else
            //{
            //    // すべて
            //    this.radEigyosho.radbtn0.Checked = true;
            //}
            

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

        }

        //フォームが最初に開いた場合の処理
        private void D0310_UriageJissekiKakunin_Shown(object sender, EventArgs e)
        {

            //受注入力処理
            if (intFrm == 1)
            {
                labelSet_Tokuisaki.CodeTxtText = strTokuisakiCd;

                this.setUriageJissekikakunin();

                gridUriageJisseki.Focus();

            }
            //売上入力
            else if (intFrm == 2)
            {
                
                labelSet_Tokuisaki.CodeTxtText = strTokuisakiCd;

                this.setUriageJissekikakunin();

                gridUriageJisseki.Focus();
            }
            //売上別利益率設定
            else if (intFrm == 121)
            {

                labelSet_Tokuisaki.CodeTxtText = strTokuisakiCd;
                txtKataban.Text = strSyohinCd;

                this.setUriageJissekikakunin();

                gridUriageJisseki.Focus();
            }

            // ステータスバーに検索結果表示
            this.lblStatusMessage.Text = "F9を押すと、一覧表示または検索ができます";
        }

        private void D0310_UriageJissekiKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "売上実績確認";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF07.Text = "F7:CSV";
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            //初期表示
            txtDenpyoYMDstart.Focus();

            txtDenpyoYMDstart.Text = DateTime.Parse(DateTime.Now.ToString("yyyy/MM") + "/01").AddMonths(-1).ToString();
            txtDenpyoYMDend.Text = DateTime.Parse(DateTime.Now.ToString("yyyy/MM") + "/01").AddMonths(1).AddDays(-1).ToString();

            // 閲覧権限ありの場合
            if (etsuranFlg.Equals("1"))
            {
                this.btnF07.Enabled = true;
                this.btnF07.Text = "F7:CSV";
                radEigyosho.Visible = true;

            }
            else
            {
                this.btnF07.Enabled = false;
                this.btnF07.Text = "";
                radEigyosho.Visible = true;

                //営業コードからラジオボタンの初期チェックを設定
                if (eigyoCode == "0001")
                {
                    radEigyosho.radbtn1.Checked = true;
                }
                else
                {
                    radEigyosho.radbtn2.Checked = true;
                }
                
            }

            if (etsuranFlg.Equals("1"))
            {
                this.btnF11.Enabled = true;
                this.btnF11.Text = STR_FUNC_F11;
            }
            else
            {
                this.btnF11.Enabled = false;
                this.btnF11.Text = "";
            }

            //DataGridViewの初期設定
            SetUpGrid();

            labelSet_Jtanto.Focus();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {

            //列自動生成禁止
            gridUriageJisseki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn Sirusi = new DataGridViewTextBoxColumn();
            Sirusi.DataPropertyName = "印";
            Sirusi.Name = "印";
            Sirusi.HeaderText = "印";

            DataGridViewTextBoxColumn Day = new DataGridViewTextBoxColumn();
            Day.DataPropertyName = "伝票年月日";
            Day.Name = "伝票年月日";
            Day.HeaderText = "日付";

            DataGridViewTextBoxColumn DenpyoNo = new DataGridViewTextBoxColumn();
            DenpyoNo.DataPropertyName = "伝票番号";
            DenpyoNo.Name = "伝票番号";
            DenpyoNo.HeaderText = "伝№";
            
            DataGridViewTextBoxColumn Maker = new DataGridViewTextBoxColumn();
            Maker.DataPropertyName = "メーカー";
            Maker.Name = "メーカー";
            Maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn Sinamei = new DataGridViewTextBoxColumn();
            Sinamei.DataPropertyName = "品名型式";
            Sinamei.Name = "品名型式";
            Sinamei.HeaderText = "品名・型式";

            DataGridViewTextBoxColumn Suuryou = new DataGridViewTextBoxColumn();
            Suuryou.DataPropertyName = "数量";
            Suuryou.Name = "数量";
            Suuryou.HeaderText = "数量";

            DataGridViewTextBoxColumn Uriagetanka = new DataGridViewTextBoxColumn();
            Uriagetanka.DataPropertyName = "単価";
            Uriagetanka.Name = "単価";
            Uriagetanka.HeaderText = "売上単価";


            DataGridViewTextBoxColumn UriageKingaku = new DataGridViewTextBoxColumn();
            UriageKingaku.DataPropertyName = "売上金額";
            UriageKingaku.Name = "売上金額";
            UriageKingaku.HeaderText = "売上金額";

            DataGridViewTextBoxColumn Siiretanka = new DataGridViewTextBoxColumn();
            Siiretanka.DataPropertyName = "原価";
            Siiretanka.Name = "原価";
            Siiretanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn SiireKingaku = new DataGridViewTextBoxColumn();
            SiireKingaku.DataPropertyName = "原価金額";
            SiireKingaku.Name = "原価金額";
            SiireKingaku.HeaderText = "仕入金額";

            DataGridViewTextBoxColumn Ararigaku = new DataGridViewTextBoxColumn();
            Ararigaku.DataPropertyName = "粗利額";
            Ararigaku.Name = "粗利額";
            Ararigaku.HeaderText = "粗利額";

            DataGridViewTextBoxColumn Untin = new DataGridViewTextBoxColumn();
            Untin.DataPropertyName = "運賃";
            Untin.Name = "運賃";
            Untin.HeaderText = "運賃";
            
            DataGridViewTextBoxColumn Bikou = new DataGridViewTextBoxColumn();
            Bikou.DataPropertyName = "備考";
            Bikou.Name = "備考";
            Bikou.HeaderText = "備考";

            DataGridViewTextBoxColumn HachusakiName = new DataGridViewTextBoxColumn();
            HachusakiName.DataPropertyName = "仕入先名";
            HachusakiName.Name = "仕入先名";
            HachusakiName.HeaderText = "発注先名";

            DataGridViewTextBoxColumn TokuisakiName = new DataGridViewTextBoxColumn();
            TokuisakiName.DataPropertyName = "得意先名";
            TokuisakiName.Name = "得意先名";
            TokuisakiName.HeaderText = "得意先名";

            DataGridViewTextBoxColumn Juchubangou = new DataGridViewTextBoxColumn();
            Juchubangou.DataPropertyName = "受注番号";
            Juchubangou.Name = "受注番号";
            Juchubangou.HeaderText = "受注番号";

            DataGridViewTextBoxColumn juchuTanto = new DataGridViewTextBoxColumn();
            juchuTanto.DataPropertyName = "受注担当";
            juchuTanto.Name = "受注担当";
            juchuTanto.HeaderText = "受注者";

            DataGridViewTextBoxColumn hachubangou = new DataGridViewTextBoxColumn();
            hachubangou.DataPropertyName = "発注番号";
            hachubangou.Name = "発注番号";
            hachubangou.HeaderText = "発注番号";

            DataGridViewTextBoxColumn siireYmd = new DataGridViewTextBoxColumn();
            siireYmd.DataPropertyName = "仕入日";
            siireYmd.Name = "仕入日";
            siireYmd.HeaderText = "仕入日";

            DataGridViewTextBoxColumn eigyoTanto = new DataGridViewTextBoxColumn();
            eigyoTanto.DataPropertyName = "営業担当";
            eigyoTanto.Name = "営業担当";
            eigyoTanto.HeaderText = "営業担当者";

            DataGridViewTextBoxColumn setteiTanka = new DataGridViewTextBoxColumn();
            setteiTanka.DataPropertyName = "設定単価";
            setteiTanka.Name = "設定単価";
            setteiTanka.HeaderText = "設定単価";

            DataGridViewTextBoxColumn nyuryokuTanto = new DataGridViewTextBoxColumn();
            nyuryokuTanto.DataPropertyName = "入力者名";
            nyuryokuTanto.Name = "入力者名";
            nyuryokuTanto.HeaderText = "入力者";

            DataGridViewTextBoxColumn gyoubangou = new DataGridViewTextBoxColumn();
            gyoubangou.DataPropertyName = "行番号";
            gyoubangou.Name = "行番号";
            gyoubangou.HeaderText = "行番号";

            DataGridViewTextBoxColumn shohincd = new DataGridViewTextBoxColumn();
            shohincd.DataPropertyName = "商品コード";
            shohincd.Name = "商品コード";
            shohincd.HeaderText = "商品コード";

            //個々の幅、文章の寄せ
            setColumn(Sirusi, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,25);
            setColumn(Day, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(DenpyoNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null, 70);
            setColumn(Maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(Sinamei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 500);
            setColumn(Suuryou, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(Uriagetanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(UriageKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(Siiretanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(SiireKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(Ararigaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(Untin, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(Bikou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null,300);
            setColumn(HachusakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null,300);
            setColumn(TokuisakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null,300);
            setColumn(Juchubangou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,100);
            setColumn(juchuTanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(hachubangou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(siireYmd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(eigyoTanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(setteiTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            //表示はしない項目
            setColumn(nyuryokuTanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(gyoubangou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(shohincd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);

            gridUriageJisseki.Columns[21].Visible = false;
            gridUriageJisseki.Columns[22].Visible = false;
            gridUriageJisseki.Columns[23].Visible = false;

        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridUriageJisseki.Columns.Add(col);
            if (gridUriageJisseki.Columns[col.Name] != null)
            {
                gridUriageJisseki.Columns[col.Name].Width = intLen;
                gridUriageJisseki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridUriageJisseki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridUriageJisseki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// D0310_UriageJissekiKakunin_KeyDown
        /// キー入力判定
        /// </summary>
        private void D0310_UriageJissekiKakunin_KeyDown(object sender, KeyEventArgs e)
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
                    this.setUriageJissekikakunin();
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
                    if (this.btnF07.Enabled == true)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "CSV実行"));
                        this.exportCsv();
                    }
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    if (this.btnF11.Enabled == true)
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
                    this.setUriageJissekikakunin();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F07: // CSV
                    if(this.btnF07.Enabled == true)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "CSV実行"));
                        this.exportCsv();
                    }
                    break;
                case STR_BTN_F11: // 印刷
                    if (this.btnF11.Enabled == true)
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
        /// exportCsv
        /// CSVを出力する
        /// </summary>
        private void exportCsv()
        {
            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // カーソルを待機状態にする
            this.Cursor = Cursors.WaitCursor;

            // データ検索条件用List
            List<string> lstSearchItem = new List<string>();
            List<Array> lstSearchItem2 = new List<Array>();

            DataTable dtSetView = new DataTable();

            // ファイル保存用
            SaveFileDialog sfd = new SaveFileDialog();

            // ファイル名の指定
            sfd.FileName = "売上" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";

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
                D0310_UriageJissekiKakunin_B uriagejissekikakunin = new D0310_UriageJissekiKakunin_B();
                try
                {
                    // 検索条件をリストに格納
                    lstSearchItem = setSearchList();        // テキストボックスの値
                    lstSearchItem2 = getRadio_CheckBox();   // ラジオボタン・チェックボックスの値

                    // 検索実行
                    dtSetView = uriagejissekikakunin.getUriageJisseki(lstSearchItem, lstSearchItem2);


                    if (dtSetView != null && dtSetView.Rows.Count > 0)
                    {
                        // CSV出力
                        uriagejissekikakunin.dbToCsv(dtSetView, sfd.FileName);

                        // メッセージボックスの処理、CSV作成完了の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "CSVファイルを作成しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessagebox.ShowDialog();
                    }
                    else
                    {
                        // カーソルの状態を元に戻す
                        this.Cursor = Cursors.Default;

                        // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "該当データはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessagebox.ShowDialog();
                    }
                    // カーソルの状態を元に戻す
                    this.Cursor = Cursors.Default;

                }
                catch (Exception ex)
                {
                    // カーソルの状態を元に戻す
                    this.Cursor = Cursors.Default;

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
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            String tmp1 = "";
            String tmp2 = "";


            tmp1 = txtDenpyoYMDstart.Text;
            tmp2 = txtDenpyoYMDend.Text;

            //画面の項目内を白紙にする
            delFormClear(this, gridUriageJisseki);

            txtDenpyoYMDstart.Text = tmp1;
            txtDenpyoYMDend.Text = tmp2;

            labelSet_Jtanto.Focus();
        }

        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // データ検索条件用List
            List<string> lstSearchItem = new List<string>();
            List<Array> lstSearchItem2 = new List<Array>();

            //検索時のデータ取り出し先
            DataTable dtSetView = new DataTable();

            //ビジネス層のインスタンス生成
            D0310_UriageJissekiKakunin_B uriagejissekikakunin = new D0310_UriageJissekiKakunin_B();
            try
            {
                // 検索条件をリストに格納
                lstSearchItem = setSearchList();        // テキストボックスの値
                lstSearchItem2 = getRadio_CheckBox();   // ラジオボタン・チェックボックスの値

                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = uriagejissekikakunin.getUriageJisseki(lstSearchItem, lstSearchItem2);

                // レコードが0件だった場合は終了）
                if (dtSetView.Rows.Count <= 0)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
                
                // 印刷ダイアログ
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A3, CommonTeisu.YOKO);

                // PDF出力用List(各テキストボックスの値をコードではなく名称で取得)
                List<string> lstoutItem = new List<string>();
                lstoutItem.Add(txtDenpyoYMDstart.Text);             // 伝票年月日Start
                lstoutItem.Add(txtDenpyoYMDend.Text);               // 伝票年月日End
                lstoutItem.Add(labelSet_Jtanto.ValueLabelText);     // 受注者名
                lstoutItem.Add(labelSet_Etanto.ValueLabelText);     // 営業担当者名
                lstoutItem.Add(labelSet_Ntanto.ValueLabelText);     // 入力者名
                lstoutItem.Add(labelSet_SiiresakiCd.ValueLabelText);// 仕入先名
                lstoutItem.Add(labelSet_Daibunrui.ValueLabelText);  // 大分類名称
                lstoutItem.Add(labelSet_Chubunrui.ValueLabelText);  // 中分類名称
                lstoutItem.Add(txtKataban.Text);                    // 品名・型番
                lstoutItem.Add(txtBikou.Text);                      // 備考
                lstoutItem.Add(labelSet_Tokuisaki.ValueLabelText);  // 得意先名
                lstoutItem.Add(labelSet_Maker.ValueLabelText);      // メーカー
                lstoutItem.Add(txtJuchuNo.Text);                    // 受注番号
                lstoutItem.Add(txtHachuNo.Text);                    // 発注番号

                pf.ShowDialog(this);
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    // カーソルを待機状態にする
                    this.Cursor = Cursors.WaitCursor;

                    // PDF作成
                    string strFile = uriagejissekikakunin.dbToPdf(dtSetView, lstoutItem);
                    pf.execPreview(@strFile);
                }
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // カーソルを待機状態にする
                    this.Cursor = Cursors.WaitCursor;

                    // PDF作成
                    string strFile = uriagejissekikakunin.dbToPdf(dtSetView, lstoutItem);

                    // 用紙サイズ、印刷方向はインスタンス生成と同じ値を入れる
                    // ダイアログ表示時は最後の引数はtrue
                    // （ダイアログ非経由の直接印刷時は先頭引数にプリンタ名を入れ、最後の引数をfalseに）
                    pf.execPrint(null, @strFile, CommonTeisu.SIZE_A3, CommonTeisu.YOKO, true);
                }

                pf.Dispose();

                // カーソルの状態を元に戻す
                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                // カーソルの状態を元に戻す
                this.Cursor = Cursors.Default;

                // エラーロギング
                new CommonException(ex);
                return;
            }

        }

        ///<summary>
        ///setUriageJissekikakunin
        ///グリッドビューにデータを設定する。
        ///</summary>
        private void setUriageJissekikakunin()
        {
            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // カーソルを待機状態にする
            this.Cursor = Cursors.WaitCursor;

            // データ検索条件用List
            List<string> lstSearchItem = new List<string>();
            List<Array> lstSearchItem2 = new List<Array>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //ビジネス層のインスタンス生成
            D0310_UriageJissekiKakunin_B uriagejissekikakunin = new D0310_UriageJissekiKakunin_B();
            try
            {
                // 検索条件をリストに格納
                lstSearchItem = setSearchList();        // テキストボックスの値
                lstSearchItem2 = getRadio_CheckBox();   // ラジオボタン・チェックボックスの値
                
                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = uriagejissekikakunin.getUriageJisseki(lstSearchItem, lstSearchItem2);

                //取得データテーブルをグリッドビューにセットする。
                gridUriageJisseki.DataSource = dtSetView;

                //ユーザによって処理変更、金額がマイナスの場合文字を赤くする。

                decimal UriageGoukei = 0;
                decimal SiireGoukei = 0;
                decimal ArariGoukei = 0;
                decimal UnchinGoukei = 0;

                if (dtSetView.Rows.Count > 0)
                {
                    for (int cnt = 0; cnt < gridUriageJisseki.RowCount; cnt++)
                    {
                        decimal decSuuryo = 0;
                        decimal decKingaku = 0;
                        decimal decSiire = 0;
                        decimal decArari = 0;
                        decimal decUnchin = 0;

                        string strSuuryo = gridUriageJisseki.Rows[cnt].Cells["数量"].Value.ToString().Trim();
                        string strKingaku = gridUriageJisseki.Rows[cnt].Cells["売上金額"].Value.ToString().Trim();
                        string strSiire = gridUriageJisseki.Rows[cnt].Cells["原価金額"].Value.ToString().Trim();
                        string strArari = gridUriageJisseki.Rows[cnt].Cells["粗利額"].Value.ToString().Trim();
                        string strUnchin = gridUriageJisseki.Rows[cnt].Cells["運賃"].Value.ToString().Trim();

                        //各項目の合計額を算出
                        //UriageGoukei += decimal.Parse(PutIsNull(gridUriageJisseki.Rows[cnt].Cells["売上金額"].Value.ToString(), "0"));
                        //SiireGoukei += decimal.Parse(PutIsNull(gridUriageJisseki.Rows[cnt].Cells["原価金額"].Value.ToString(), "0"));
                        //ArariGoukei += decimal.Parse(PutIsNull(gridUriageJisseki.Rows[cnt].Cells["粗利額"].Value.ToString(), "0"));
                        //UnchinGoukei += decimal.Parse(PutIsNull(gridUriageJisseki.Rows[cnt].Cells["運賃"].Value.ToString(), "0"));

                        if (!strSuuryo.Equals(""))
                        {
                            // 数量
                            decSuuryo = decimal.Parse(strSuuryo);
                        }

                        if (!strKingaku.Equals(""))
                        {
                            // 金額
                            decKingaku = decimal.Parse(strKingaku);
                        }

                        if (!strSiire.Equals(""))
                        {
                            // 仕入
                            decSiire = decimal.Parse(strSiire);
                        }

                        if (!strArari.Equals(""))
                        {
                            // 粗利
                            decArari = decimal.Parse(strArari);
                        }

                        if (!strUnchin.Equals(""))
                        {
                            // 運賃
                            decUnchin = decimal.Parse(strUnchin);
                        }

                        // 設定単価
                        string strSetteiTanka = gridUriageJisseki.Rows[cnt].Cells["設定単価"].Value.ToString();

                        UriageGoukei += decKingaku;
                        SiireGoukei += decSiire;
                        ArariGoukei += decArari;
                        UnchinGoukei += decUnchin;

                        // 数量又は金額又は粗利がマイナスの場合はフォントカラーを変更
                        if (decSuuryo < 0 || decKingaku < 0 || decArari < 0)
                        {
                            if (strSetteiTanka.Equals(""))
                            {
                                gridUriageJisseki.Rows[cnt].DefaultCellStyle.ForeColor = Color.Red;
                            }
                            else
                            {
                                gridUriageJisseki.Rows[cnt].DefaultCellStyle.ForeColor = Color.Blue;
                            }
                            
                        }
                    }

                    //粗利率計算
                    decimal Arariritsu = 0;
                    Arariritsu = ArariGoukei / UriageGoukei * 100;

                    // 閲覧権限があれば、無条件で金額を表示
                    if (etsuranFlg.Equals("1"))
                    {
                        txtUriageKingaku.Text = UriageGoukei.ToString("#,0");
                        txtSiireKingaku.Text = SiireGoukei.ToString("#,0");
                        txtArarigaku.Text = ArariGoukei.ToString("#,0");
                        txtUntin.Text = UnchinGoukei.ToString("#,0");
                        txtArariritsu.Text = Arariritsu.ToString("0.0");
                    }
                    else
                    {
                        // 得意先コードの入力がない場合、金額を表示しない
                        if (labelSet_Tokuisaki.CodeTxtText.Equals(""))
                        {
                            txtUriageKingaku.Text = "";
                            txtSiireKingaku.Text = "";
                            txtArarigaku.Text = "";
                            txtUntin.Text = "";
                            txtArariritsu.Text = "";
                            // ただし、受注者コードまたは営業担当者コードを入力した場合、金額表示
                            if (labelSet_Jtanto.CodeTxtText != "" || labelSet_Etanto.CodeTxtText != "")
                            {
                                txtUriageKingaku.Text = UriageGoukei.ToString("#,0");
                                txtSiireKingaku.Text = SiireGoukei.ToString("#,0");
                                txtArarigaku.Text = ArariGoukei.ToString("#,0");
                                txtUntin.Text = UnchinGoukei.ToString("#,0");
                                txtArariritsu.Text = Arariritsu.ToString("0.0");
                            }
                        }
                        else
                        {
                            // 2ケ月以内の場合のみ金額表示
                            if (blnKikanCheck())
                            {
                                txtUriageKingaku.Text = UriageGoukei.ToString("#,0");
                                txtSiireKingaku.Text = SiireGoukei.ToString("#,0");
                                txtArarigaku.Text = ArariGoukei.ToString("#,0");
                                txtUntin.Text = UnchinGoukei.ToString("#,0");
                                txtArariritsu.Text = Arariritsu.ToString("0.0");
                            }
                            // 2か月を超えた場合でも、受注者コードまたは営業担当者コードを入力した場合、金額表示
                            else if (labelSet_Jtanto.CodeTxtText != "" || labelSet_Etanto.CodeTxtText != "")
                            {
                                txtUriageKingaku.Text = UriageGoukei.ToString("#,0");
                                txtSiireKingaku.Text = SiireGoukei.ToString("#,0");
                                txtArarigaku.Text = ArariGoukei.ToString("#,0");
                                txtUntin.Text = UnchinGoukei.ToString("#,0");
                                txtArariritsu.Text = Arariritsu.ToString("0.0");
                            }
                            else
                            {
                                txtUriageKingaku.Text = "";
                                txtSiireKingaku.Text = "";
                                txtArarigaku.Text = "";
                                txtUntin.Text = "";
                                txtArariritsu.Text = "";
                            }
                        }
                    }

                    Control cNow = this.ActiveControl;
                    cNow.Focus();

                }

                // DataTableのレコード数取得
                int dtCnt = dtSetView.Rows.Count;
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
                gridUriageJisseki.Focus();

                // カーソルの状態を元に戻す
                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                // カーソルの状態を元に戻す
                this.Cursor = Cursors.Default;

                //エラーロギング
                new CommonException(ex);
                return;
            }

            return;
        }

        //グリッドビューをダブルクリックした場合
        private void gridUriageJisseki_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridUriageJisseki.Rows.Count == 0)
            {
                return;
            }

            //intFrmの値によって処理を変更

            //受注入力画面を表示する。
            if (intFrm == 1)
            {
                string ShohinCd = "";
                string JuchuTanka = "";

                //商品コードを取得する。
                ShohinCd = gridUriageJisseki.CurrentRow.Cells[18].Value.ToString();

                if (ShohinCd == "")
                {
                    return;
                }

                //売上単価を取得する（受注単価）
                JuchuTanka = gridUriageJisseki.CurrentRow.Cells[6].Value.ToString();

                //受注入力画面へ遷移「引数:商品コード、売上単価」
                foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                {

                    //目的のフォームを探す
                    if (frm.Name == "A0010_JuchuInput")
                    {
                        ////データを連れてくるため、newをしないこと
                        //A0010_JuchuInput.A0010JuchuInput JuchuInputReturn = (A0010_JuchuInput.A0010JuchuInput)frm;
                        //JuchuInputReturn.setShouhin(ShohinCd, JuchuTanka);
                        //break;
                    }
                }

                //閉じる
                this.Close();

            }

            //加工原価リストを表示する。
            if (intFrm == 0)
            {
                string JuchuNo = "";

                //受注番号を取得する。
                JuchuNo = gridUriageJisseki.CurrentRow.Cells[15].Value.ToString();

                //加工原価リストをスタートする。
                //引数1 受注番号

                if (gridUriageJisseki.RowCount > 0)
                {
                    // 加工原価確認フォームを開く
                    KATO.Common.Form.KakouGenkaList kakou = new Common.Form.KakouGenkaList(this, JuchuNo);
                    kakou.ShowDialog();
                }

            }

        }

        ///<summary>
        ///PutIsNull
        ///値がNULLの場合、差し替え文字を挿入する。
        ///</summary>
        private String PutIsNull(string CheckColumn, String ChangeValue)
        {
            if (CheckColumn == null || CheckColumn == "")
            {
                //値の差し替え
                CheckColumn = ChangeValue;
                return CheckColumn;
            }
            return CheckColumn;
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
            if (txtDenpyoYMDstart.Text.Equals("") || txtDenpyoYMDend.Text.Equals(""))
            {
                return false;
            }

            // 伝票年月日の間隔が2を超える場合
            if (!blnDateDiff(txtDenpyoYMDstart.Text, txtDenpyoYMDend.Text))
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
        /// テキストボックスの検索条件をリストに格納
        /// </summary>
        private List<string> setSearchList()
        {
            List<string> lstSearchItem = new List<string>();

            // 検索するデータをリストに格納
            lstSearchItem.Add(txtDenpyoYMDstart.Text);          // 伝票年月日Start
            lstSearchItem.Add(txtDenpyoYMDend.Text);            // 伝票年月日End
            lstSearchItem.Add(labelSet_Jtanto.CodeTxtText);     // 受注者コード
            lstSearchItem.Add(labelSet_Etanto.CodeTxtText);     // 営業担当者コード
            lstSearchItem.Add(labelSet_Ntanto.CodeTxtText);     // 入力者コード
            lstSearchItem.Add(labelSet_SiiresakiCd.CodeTxtText);// 仕入先コード
            lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);  // 大分類
            lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);  // 中分類
            lstSearchItem.Add(txtKataban.Text);                 // 品名・型番
            lstSearchItem.Add(txtBikou.Text);                   // 備考
            lstSearchItem.Add(labelSet_Tokuisaki.CodeTxtText);  // 得意先
            lstSearchItem.Add(labelSet_Maker.CodeTxtText);      // メーカー
            lstSearchItem.Add(txtJuchuNo.Text);                 // 受注番号
            lstSearchItem.Add(txtHachuNo.Text);                 // 発注番号

            return lstSearchItem;
        }

        /// <summary>
        /// ラジオボタンとチェックボックスの検索条件を取得
        /// </summary>
        private List<Array> getRadio_CheckBox()
        {
            List<Array> arrList = new List<Array>();

            // 表示条件取得用(営業所)
            string[] arrDispEigyo = new string[3];
            // 表示条件取得用(グループコード)
            string[] arrDispGroup = new string[5];
            // 出力順条件取得用
            string[] arrOrder = new string[2];
            // 出力順条件取得用(A-Z,Z-A)
            string[] arrOrderAtoZ = new string[2];
            // チェックボックス用
            string[] arrCheckBox = new string[1];
            // 
            string[] arrJuchuType = new string[3];

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
            arrOrder[0] = radSortUriage.Checked.ToString().ToUpper();           // 売上日
            arrOrder[1] = radSortSiire.Checked.ToString().ToUpper();            // 仕入日

            // 並び順（A-Z、Z-A）
            arrOrderAtoZ[0] = radSortOrder.radbtn0.Checked.ToString().ToUpper();// A-Z
            arrOrderAtoZ[1] = radSortOrder.radbtn1.Checked.ToString().ToUpper();// Z-A

            // チェックボックス
            arrCheckBox[0] = chkGyakusayabun.Checked.ToString().ToUpper();      // 逆鞘分のみ

            // 加工区分
            arrJuchuType[0] = radJuchuType.radbtn0.Checked.ToString().ToUpper();// 両方    
            arrJuchuType[1] = radJuchuType.radbtn1.Checked.ToString().ToUpper();// 通常受注
            arrJuchuType[2] = radJuchuType.radbtn2.Checked.ToString().ToUpper();// 加工品受注

            arrList.Add(arrDispEigyo);
            arrList.Add(arrDispGroup);
            arrList.Add(arrOrder);
            arrList.Add(arrOrderAtoZ);
            arrList.Add(arrCheckBox);
            arrList.Add(arrJuchuType);

            return arrList;

        }

        /// <summary>
        /// blnDataCheck
        /// データチェック
        /// </summary>
        private Boolean blnDataCheck()
        {
            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            // 空文字判定
            if (labelSet_Etanto.CodeTxtText.Equals("") && labelSet_Ntanto.CodeTxtText.Equals("") && labelSet_Jtanto.CodeTxtText.Equals("") &&
                labelSet_SiiresakiCd.CodeTxtText.Equals("") && txtKataban.Text.Equals("") && labelSet_Daibunrui.CodeTxtText.Equals("") &&
                labelSet_Tokuisaki.CodeTxtText.Equals("") && labelSet_Maker.CodeTxtText.Equals("") && txtBikou.Text.Equals("") &&
                txtJuchuNo.Text.Equals("") && txtHachuNo.Text.Equals("") &&
                txtDenpyoYMDstart.Text.Equals("") && txtDenpyoYMDend.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n条件を指定してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return false;
            }

            // 伝票年月日のStart・Endは必須項目
            if (txtDenpyoYMDstart.Text.Equals(""))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDstart.Focus();

                return false;
            }
            if (txtDenpyoYMDend.Text.Equals(""))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDend.Focus();

                return false;
            }

            //営業担当者チェック
            if (labelSet_Etanto.chkTxtTantosha())
            {
                labelSet_Etanto.Focus();

                return false;
            }

            //入力担当者チェック
            if (labelSet_Ntanto.chkTxtTantosha())
            {
                labelSet_Ntanto.Focus();

                return false;
            }

            //受注担当者チェック
            if (labelSet_Jtanto.chkTxtTantosha())
            {
                labelSet_Jtanto.Focus();

                return false;
            }

            //得意先チェック
            if (labelSet_Tokuisaki.chkTxtTorihikisaki())
            {
                labelSet_Tokuisaki.Focus();

                return false;
            }

            //仕入先チェック
            if (labelSet_SiiresakiCd.chkTxtTorihikisaki())
            {
                labelSet_SiiresakiCd.Focus();

                return false;
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
            
            //日付フォーマット生成、およびチェック
            strYMDformat = txtDenpyoYMDstart.chkDateDataFormat(txtDenpyoYMDstart.Text);

            //開始年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDstart.Focus();

                return false;
            }
            else
            {
                txtDenpyoYMDstart.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtDenpyoYMDend.chkDateDataFormat(txtDenpyoYMDend.Text);

            //終了年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDend.Focus();

                return false;
            }
            else
            {
                txtDenpyoYMDend.Text = strYMDformat;
            }
            
            return true;
        }

        #region テキストボックスのKeyDownイベント（EnterキーでTAB）
        // 品名・型番テキストボックス
        private void txtKataban_KeyDown(object sender, KeyEventArgs e)
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
        // 受注番号テキストボックス
        private void txtJuchuNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        // 発注番号テキストボックス
        private void txtHachuNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        #endregion
    }
}
