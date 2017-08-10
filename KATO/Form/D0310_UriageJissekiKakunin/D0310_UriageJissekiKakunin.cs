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
        public D0310_UriageJissekiKakunin(Control c, int intFrm, string strTokuisakiCd,string strSyohinCd)
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
            else if (intFrm == 0020)
            {
                
                labelSet_Tokuisaki.CodeTxtText = strTokuisakiCd;

                this.setUriageJissekikakunin();

                gridUriageJisseki.Focus();
            }
            //売上別利益率設定
            else if (intFrm == 1210)
            {

                labelSet_Tokuisaki.CodeTxtText = strTokuisakiCd;
                txtKataban.Text = strSyohinCd;

                this.setUriageJissekikakunin();

                gridUriageJisseki.Focus();
            }
            
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

            //現在の月の1日を表示（例；2017年4月13日→2017/04/01）
            txtDenpyoYMDstart.Text = DateTime.Now.ToString("yyyy/MM")+"/01";
            //月末を表示
            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;

            dateStartYMD = DateTime.Parse(txtDenpyoYMDstart.Text);

            dateEndYMD = dateStartYMD.AddMonths(2);
            txtDenpyoYMDend.Text = dateEndYMD.AddDays(-1).ToString();

            //ユーザ権限チェック【暫定】
            String EigyoCd = "";

            //SPPowerUserの場合
            if (Environment.UserName == "SPPowerUser")
            {
                this.btnF07.Enabled = true;
                this.btnF07.Text = "F7:CSV";
                radSet_group.Visible = true;

            }
            //環境ユーザで表示変更
            else if (Environment.UserName == "k.kato" || Environment.UserName == "s.kato" || Environment.UserName == "s.kato" || Environment.UserName == "kawaharazaki" || Environment.UserName == "komori")
            {
                this.btnF07.Enabled = false;
                this.btnF07.Text = "";
                radSet_group.Visible = true;
            }
            else
            {
                this.btnF07.Enabled = false;
                this.btnF07.Text = "";
                radSet_group.Visible = true;

                //営業所コードを取得
                EigyoCd = getEigyoCd(Environment.UserName);

                //営業コードからラジオボタンの初期チェックを設定
                if (EigyoCd == "0001")
                {
                    radSet_group.radbtn1.Checked = true;
                }
                else
                {
                    radSet_group.radbtn2.Checked = true;
                }
                
            }

            if (Environment.UserName == "SPPowerUser")
            {
                this.btnF11.Enabled = true;
                this.btnF11.Text = STR_FUNC_F11;
            }
            else
            {
                this.btnF11.Enabled = false;
                this.btnF11.Text = "";
            }

            //CSV・印刷テスト用コード
            this.btnF11.Enabled = true;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF07.Enabled = true;
            this.btnF07.Text = "F7:CSV";

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

            DataGridViewTextBoxColumn nyuryokusya = new DataGridViewTextBoxColumn();
            nyuryokusya.DataPropertyName = "入力者名";
            nyuryokusya.Name = "入力者名";
            nyuryokusya.HeaderText = "担当者";

            DataGridViewTextBoxColumn gyoubangou = new DataGridViewTextBoxColumn();
            gyoubangou.DataPropertyName = "行番号";
            gyoubangou.Name = "行番号";
            gyoubangou.HeaderText = "行番号";

            DataGridViewTextBoxColumn shohincd = new DataGridViewTextBoxColumn();
            shohincd.DataPropertyName = "商品コード";
            shohincd.Name = "商品コード";
            shohincd.HeaderText = "商品コード";
            

            //個々の幅、文章の寄せ
            setColumn(Sirusi, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,30);
            setColumn(Day, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(DenpyoNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null, 150);
            setColumn(Maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(Sinamei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 500);
            setColumn(Suuryou, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#0", 100);
            setColumn(Uriagetanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(UriageKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(Siiretanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(SiireKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(Ararigaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(Untin, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",100);
            setColumn(Bikou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null,300);
            setColumn(HachusakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null,150);
            setColumn(TokuisakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null,300);
            setColumn(Juchubangou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,150);
            setColumn(nyuryokusya, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,150);
            //表示はしない項目
            setColumn(gyoubangou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(shohincd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);

            gridUriageJisseki.Columns[17].Visible = false;
            gridUriageJisseki.Columns[18].Visible = false;

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

        ///<summary>
        ///getEigyoCd
        ///ログインユーザの営業コードを取得する。
        ///</summary>
        private string getEigyoCd(String UserName)
        {
            string EigyoCd = "";

            //データ検索用
            List<string> lstUriageSuiiLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //ビジネス層のインスタンス生成
            D0310_UriageJissekiKakunin_B uriagejissekikakunin = new D0310_UriageJissekiKakunin_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                /*[0]開始伝票年月日*/
                lstUriageSuiiLoad.Add(UserName);
                
                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = uriagejissekikakunin.getEigyoCd(lstUriageSuiiLoad);

                //検索結果が1件以上の場合
                if (dtSetView.Rows.Count > 0)
                {
                    EigyoCd = dtSetView.Rows[0]["営業所コード"].ToString();
                }
                else
                {
                    EigyoCd = "0002";
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return EigyoCd;
            }

            return EigyoCd;
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
            // データ検索用
            List<string> lstUriageSuiiLoad = new List<string>();

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
                // 検索データをリストに格納
                //データの存在確認を検索する情報を入れる
                /*[0]開始伝票年月日*/
                lstUriageSuiiLoad.Add(txtDenpyoYMDstart.Text);
                /*[1]終了伝票年月日*/
                lstUriageSuiiLoad.Add(txtDenpyoYMDend.Text);
                /*[2]得意先コード*/
                lstUriageSuiiLoad.Add(labelSet_Tokuisaki.CodeTxtText);
                /*[3]入力者コード*/
                lstUriageSuiiLoad.Add(labelSet_Nyuryokusya.CodeTxtText);
                /*[4]担当者コード*/
                lstUriageSuiiLoad.Add(labelSet_Tantousha.CodeTxtText);
                /*[5]大分類コード*/
                lstUriageSuiiLoad.Add(labelSet_Daibunrui.CodeTxtText);
                /*[6]中分類コード*/
                lstUriageSuiiLoad.Add(labelSet_Chubunrui.CodeTxtText);
                /*[7]品名・型番*/
                lstUriageSuiiLoad.Add(txtKataban.Text);
                /*[8]備考*/
                lstUriageSuiiLoad.Add(txtBikou.Text);

                //[9]逆鞘分のみチェックボックス
                if (chkGyakusayabun.Checked == true)
                {
                    lstUriageSuiiLoad.Add("1");
                }
                else
                {
                    lstUriageSuiiLoad.Add("0");
                }

                //[10]仕入未入力分のみチェックボックス
                if (chkSiireMinyuryoku.Checked == true)
                {
                    lstUriageSuiiLoad.Add("1");
                }
                else
                {
                    lstUriageSuiiLoad.Add("0");
                }

                /*[11]メーカーコード*/
                lstUriageSuiiLoad.Add(labelSet_Maker.CodeTxtText);
                /*[12]受注番号*/
                lstUriageSuiiLoad.Add(txtJuchuNo.Text);
                /*[13]仕入先コード*/
                lstUriageSuiiLoad.Add(labelSet_SiiresakiCd.CodeTxtText);

                //[14]両方、通常受注、加工受注
                lstUriageSuiiLoad.Add(radSet_JuchuHouhou.judCheckBtn().ToString());

                //[15]営業所名（すべて、本社、岐阜）
                lstUriageSuiiLoad.Add(radSet_group.judCheckBtn().ToString());

                //[16]並び順の指定（上段）から選択値を取得
                foreach (RadioButton rb3 in radSet_Sort1.Controls)
                {
                    if (rb3.Checked)
                    {
                        lstUriageSuiiLoad.Add(rb3.Text);
                    }
                }

                //[17]並び順の指定（下段）
                lstUriageSuiiLoad.Add(radSet_Sort2.judCheckBtn().ToString());

                //[18]プリント用　担当者名
                lstUriageSuiiLoad.Add(labelSet_Tantousha.ValueLabelText);

                //[19]プリント用　得意先名
                lstUriageSuiiLoad.Add(labelSet_Tokuisaki.ValueLabelText);

                //[20]プリント用　大分類名
                lstUriageSuiiLoad.Add(labelSet_Daibunrui.ValueLabelText);

                //[21]プリント用　中分類名
                lstUriageSuiiLoad.Add(labelSet_Chubunrui.ValueLabelText);

                // ビジネス層のインスタンス生成
                D0310_UriageJissekiKakunin_B uriagejissekikakunin = new D0310_UriageJissekiKakunin_B();
                try
                {
                    

                    // 検索実行
                    DataTable dtSetView = uriagejissekikakunin.getUriageJisseki(lstUriageSuiiLoad);

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

            labelSet_Nyuryokusya.Focus();
        }

        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {

            //データ検索用
            List<string> lstUriageSuiiLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;


            //ビジネス層のインスタンス生成
            D0310_UriageJissekiKakunin_B uriagejissekikakunin = new D0310_UriageJissekiKakunin_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                /*[0]開始伝票年月日*/
                lstUriageSuiiLoad.Add(txtDenpyoYMDstart.Text);
                /*[1]終了伝票年月日*/
                lstUriageSuiiLoad.Add(txtDenpyoYMDend.Text);
                /*[2]得意先コード*/
                lstUriageSuiiLoad.Add(labelSet_Tokuisaki.CodeTxtText);
                /*[3]入力者コード*/
                lstUriageSuiiLoad.Add(labelSet_Nyuryokusya.CodeTxtText);
                /*[4]担当者コード*/
                lstUriageSuiiLoad.Add(labelSet_Tantousha.CodeTxtText);
                /*[5]大分類コード*/
                lstUriageSuiiLoad.Add(labelSet_Daibunrui.CodeTxtText);
                /*[6]中分類コード*/
                lstUriageSuiiLoad.Add(labelSet_Chubunrui.CodeTxtText);
                /*[7]品名・型番*/
                lstUriageSuiiLoad.Add(txtKataban.Text);
                /*[8]備考*/
                lstUriageSuiiLoad.Add(txtBikou.Text);

                //[9]逆鞘分のみチェックボックス
                if (chkGyakusayabun.Checked == true)
                {
                    lstUriageSuiiLoad.Add("1");
                }
                else
                {
                    lstUriageSuiiLoad.Add("0");
                }

                //[10]仕入未入力分のみチェックボックス
                if (chkSiireMinyuryoku.Checked == true)
                {
                    lstUriageSuiiLoad.Add("1");
                }
                else
                {
                    lstUriageSuiiLoad.Add("0");
                }

                /*[11]メーカーコード*/
                lstUriageSuiiLoad.Add(labelSet_Maker.CodeTxtText);
                /*[12]受注番号*/
                lstUriageSuiiLoad.Add(txtJuchuNo.Text);
                /*[13]仕入先コード*/
                lstUriageSuiiLoad.Add(labelSet_SiiresakiCd.CodeTxtText);

                //[14]両方、通常受注、加工受注
                lstUriageSuiiLoad.Add(radSet_JuchuHouhou.judCheckBtn().ToString());

                //[15]営業所名（すべて、本社、岐阜）
                lstUriageSuiiLoad.Add(radSet_group.judCheckBtn().ToString());

                //[16]並び順の指定（上段）から選択値を取得
                foreach (RadioButton rb3 in radSet_Sort1.Controls)
                {
                    if (rb3.Checked)
                    {
                        lstUriageSuiiLoad.Add(rb3.Text);
                    }
                }

                //[17]並び順の指定（下段）
                lstUriageSuiiLoad.Add(radSet_Sort2.judCheckBtn().ToString());

                //[18]プリント用　担当者名
                lstUriageSuiiLoad.Add(labelSet_Tantousha.ValueLabelText);

                //[19]プリント用　得意先名
                lstUriageSuiiLoad.Add(labelSet_Tokuisaki.ValueLabelText);

                //[20]プリント用　大分類名
                lstUriageSuiiLoad.Add(labelSet_Daibunrui.ValueLabelText);

                //[21]プリント用　中分類名
                lstUriageSuiiLoad.Add(labelSet_Chubunrui.ValueLabelText);

                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = uriagejissekikakunin.getUriageJisseki(lstUriageSuiiLoad);

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

                pf.ShowDialog(this);
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    // PDF作成
                    string strFile = uriagejissekikakunin.dbToPdf(dtSetView, lstUriageSuiiLoad);
                    pf.execPreview(@strFile);
                }
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    string strFile = uriagejissekikakunin.dbToPdf(dtSetView, lstUriageSuiiLoad);

                    // 用紙サイズ、印刷方向はインスタンス生成と同じ値を入れる
                    // ダイアログ表示時は最後の引数はtrue
                    // （ダイアログ非経由の直接印刷時は先頭引数にプリンタ名を入れ、最後の引数をfalseに）
                    pf.execPrint(null, @strFile, CommonTeisu.SIZE_A3, CommonTeisu.YOKO, true);
                }

                pf.Dispose();

            }
            catch (Exception ex)
            {
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

            //データ検索用
            List<string> lstUriageSuiiLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //ビジネス層のインスタンス生成
            D0310_UriageJissekiKakunin_B uriagejissekikakunin = new D0310_UriageJissekiKakunin_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                /*[0]開始伝票年月日*/
                lstUriageSuiiLoad.Add(txtDenpyoYMDstart.Text);
                /*[1]終了伝票年月日*/
                lstUriageSuiiLoad.Add(txtDenpyoYMDend.Text);
                /*[2]得意先コード*/
                lstUriageSuiiLoad.Add(labelSet_Tokuisaki.CodeTxtText);
                /*[3]入力者コード*/
                lstUriageSuiiLoad.Add(labelSet_Nyuryokusya.CodeTxtText);
                /*[4]担当者コード*/
                lstUriageSuiiLoad.Add(labelSet_Tantousha.CodeTxtText);
                /*[5]大分類コード*/
                lstUriageSuiiLoad.Add(labelSet_Daibunrui.CodeTxtText);
                /*[6]中分類コード*/
                lstUriageSuiiLoad.Add(labelSet_Chubunrui.CodeTxtText);
                /*[7]品名・型番*/
                lstUriageSuiiLoad.Add(txtKataban.Text);
                /*[8]備考*/
                lstUriageSuiiLoad.Add(txtBikou.Text);

                //[9]逆鞘分のみチェックボックス
                if (chkGyakusayabun.Checked == true)
                {
                    lstUriageSuiiLoad.Add("1");
                }
                else
                {
                    lstUriageSuiiLoad.Add("0");
                }

                //[10]仕入未入力分のみチェックボックス
                if (chkSiireMinyuryoku.Checked == true)
                {
                    lstUriageSuiiLoad.Add("1");
                }
                else
                {
                    lstUriageSuiiLoad.Add("0");
                }

                /*[11]メーカーコード*/
                lstUriageSuiiLoad.Add(labelSet_Maker.CodeTxtText);
                /*[12]受注番号*/
                lstUriageSuiiLoad.Add(txtJuchuNo.Text);
                /*[13]仕入先コード*/
                lstUriageSuiiLoad.Add(labelSet_SiiresakiCd.CodeTxtText);

                //[14]両方、通常受注、加工受注
                lstUriageSuiiLoad.Add(radSet_JuchuHouhou.judCheckBtn().ToString());

                //[15]営業所名（すべて、本社、岐阜）
                lstUriageSuiiLoad.Add(radSet_group.judCheckBtn().ToString());
                
                //[16]並び順の指定（上段）から選択値を取得
                foreach (RadioButton rb3 in radSet_Sort1.Controls)
                {
                    if (rb3.Checked)
                    {
                        lstUriageSuiiLoad.Add(rb3.Text);
                    }
                }
                
                //[17]並び順の指定（下段）
                lstUriageSuiiLoad.Add(radSet_Sort2.judCheckBtn().ToString());
                
                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = uriagejissekikakunin.getUriageJisseki(lstUriageSuiiLoad);

                //取得データテーブルをグリッドビューにセットする。
                gridUriageJisseki.DataSource = dtSetView;

                //ユーザによって処理変更、金額がマイナスの場合文字を赤くする。

                decimal UriageGoukei = 0;
                decimal SiireGoukei = 0;
                decimal ArariGoukei = 0;
                decimal UntinGoukei = 0;

                if (dtSetView.Rows.Count > 0)
                {
                    for (int cnt = 0; cnt < gridUriageJisseki.RowCount; cnt++)
                    {
                        //各項目の合計額を算出
                        UriageGoukei += decimal.Parse(PutIsNull(gridUriageJisseki.Rows[cnt].Cells["売上金額"].Value.ToString(), "0"));
                        SiireGoukei += decimal.Parse(PutIsNull(gridUriageJisseki.Rows[cnt].Cells["原価金額"].Value.ToString(), "0"));
                        ArariGoukei += decimal.Parse(PutIsNull(gridUriageJisseki.Rows[cnt].Cells["粗利額"].Value.ToString(), "0"));
                        UntinGoukei += decimal.Parse(PutIsNull(gridUriageJisseki.Rows[cnt].Cells["運賃"].Value.ToString(), "0"));

                        // 数量
                        decimal decSuuryo = decimal.Parse(gridUriageJisseki.Rows[cnt].Cells["数量"].Value.ToString());

                        // 金額
                        decimal decKingaku = decimal.Parse(gridUriageJisseki.Rows[cnt].Cells["売上金額"].Value.ToString());

                        // 粗利
                        decimal decArari = decimal.Parse(gridUriageJisseki.Rows[cnt].Cells["粗利額"].Value.ToString());

                        // 数量又は金額又は粗利がマイナスの場合はフォントカラーを変更
                        if (decSuuryo < 0 || decKingaku < 0 || decArari < 0)
                        {
                            gridUriageJisseki.Rows[cnt].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }

                    //粗利率計算
                    decimal Arariritsu = 0;
                    Arariritsu = ArariGoukei / UriageGoukei * 100;
                    
                    //管理者以外の場合で、得意先が空欄なら合計は表示しない
                    //入力者コード、担当者コード、 得意先コードいずれかを入力した時のみ表示
                    //３ケ月以上なら合計は表示しない
                    if (Environment.UserName == "SPPowerUser" || Environment.UserName == "k.kato")
                    {
                        txtUriageKingaku.Text = UriageGoukei.ToString("#,0");
                        txtSiireKingaku.Text = SiireGoukei.ToString("#,0");
                        txtArarigaku.Text = ArariGoukei.ToString("#,0");
                        txtUntin.Text = UntinGoukei.ToString("#,0");
                        txtArariritsu.Text = Arariritsu.ToString("0.0");
                    }
                    else
                    {
                        
                        if (txtDenpyoYMDstart.Text != "" && txtDenpyoYMDend.Text != "")
                        {
                            //対象期間内を判断する関数へ
                            if (DateDiff(txtDenpyoYMDstart.Text, txtDenpyoYMDend.Text))
                            {
                                txtUriageKingaku.Text = UriageGoukei.ToString("#,0");
                                txtSiireKingaku.Text = SiireGoukei.ToString("#,0");
                                txtArarigaku.Text = ArariGoukei.ToString("#,0");
                                txtUntin.Text = UntinGoukei.ToString("#,0");
                                txtArariritsu.Text = Arariritsu.ToString("0.0");
                            }
                            else
                            {
                                if (labelSet_Nyuryokusya.CodeTxtText != "" || labelSet_Tantousha.CodeTxtText != "")
                                {
                                    txtUriageKingaku.Text = UriageGoukei.ToString("#,0");
                                    txtSiireKingaku.Text = SiireGoukei.ToString("#,0");
                                    txtArarigaku.Text = ArariGoukei.ToString("#,0");
                                    txtUntin.Text = UntinGoukei.ToString("#,0");
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
                        
                        //2015.1.29 入力者コード、担当者コードのいずれかを入力した場合の合計金額の表示                       
                        if (labelSet_Nyuryokusya.CodeTxtText != "" || labelSet_Tantousha.CodeTxtText != "")      
                        {
                            txtUriageKingaku.Text = UriageGoukei.ToString("#,0");
                            txtSiireKingaku.Text = SiireGoukei.ToString("#,0");
                            txtArarigaku.Text = ArariGoukei.ToString("#,0");
                            txtUntin.Text = UntinGoukei.ToString("#,0");
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

                    Control cNow = this.ActiveControl;
                    cNow.Focus();
                }


            }
            catch (Exception ex)
            {
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

        ///<summary>
        ///DateDiff
        ///入力した年月日の月間隔が2を超えるかを判断する。
        ///</summary>
        private Boolean DateDiff(string StartYMD, String EndYMD)
        {
            int iRet = 0;

            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MaxValue;
            DateTime dTime1 = DateTime.MinValue;
            DateTime dTime2 = DateTime.MaxValue;

            dTime1 = DateTime.Parse(StartYMD);
            dTime2 = DateTime.Parse(EndYMD);

            if (StartYMD == "")
            {
                return false;
            }

            if (EndYMD == "")
            {
                return false;
            }

            if (dTime1 < dTime2)
            {
                dtFrom = dTime1;
                dtTo = dTime2;
            }
            else
            {
                dtFrom = dTime2;
                dtTo = dTime1;
            }

            // 月差計算（年差考慮(差分1年 → 12(ヶ月)加算)）
            iRet = (dtTo.Month + (dtTo.Year - dtFrom.Year) * 12) - dtFrom.Month;

            //差分が3以上（4か月間隔）の場合
            if (iRet > 2)
            {
                //MessageBox.Show("対象期間は３ケ月間に限ります。");
                return false;
            }

            return true;
        }

        
    }
}
