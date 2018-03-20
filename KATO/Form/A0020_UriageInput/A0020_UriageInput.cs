using KATO.Business.A0020_UriageInput;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.A0020_UriageInput
{
    
    ///<summary>
    ///A0020_ShireInput
    ///売上入力フォーム
    ///作成者：太田
    ///作成日：2017/7/24
    ///更新者：太田
    ///更新日：2017/7/24
    ///カラム論理名
    ///</summary>
    public partial class A0020_UriageInput : BaseForm
    {
        System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Boolean MODY_FLAG = false;

        public bool editFlg = false;

        bool noEditable = false;
        bool f1Flg = false;

        D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin uriagejissekikakunin = null;
        D0360_JuchuzanKakunin.D0360_JuchuzanKakunin juchuzan = null;
        D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin shohinmoto = null;

        //現在の選択行を初期化
        private int CurrentRow = 99;

        //受注残確認に飛ぶ用
        BaseText txtNull = new BaseText();

        ///<summary>
        ///A0020_UriageInput
        ///フォームの初期設定
        ///</summary>
        public A0020_UriageInput(Control c)
        {
            //画面データが解放されていた時の対策
            if (c == null)
            {
                return;
            }

            //画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //最大化最小化不可
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //画面サイズを固定
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;

            //プリンタの選択リストの設定
            PrinterSettings.StringCollection oPrinter;
            oPrinter = PrinterSettings.InstalledPrinters;

            textSet_Jucyu1.btbTokuiCd = labelSet_txtCD.codeTxt;
            textSet_Jucyu2.btbTokuiCd = labelSet_txtCD.codeTxt;
            textSet_Jucyu3.btbTokuiCd = labelSet_txtCD.codeTxt;
            textSet_Jucyu4.btbTokuiCd = labelSet_txtCD.codeTxt;
            textSet_Jucyu5.btbTokuiCd = labelSet_txtCD.codeTxt;

            labelSet_txtCD.codeTxt.ModifiedChanged += new EventHandler(txtModified);
            labelSet_txtCD.codeTxt.ModifiedChanged += new EventHandler(txtModified);
            labelSet_Tantousha.codeTxt.ModifiedChanged += new EventHandler(txtModified);
            labelSet_Torihikikbn.codeTxt.Leave += new EventHandler(labelSet_Torihikikbn_Leave);
            labelSet_Tantousha.Leave += new EventHandler(labelSet_Tantousha_Leave);

            int intIdx = 0;
            foreach (string item in oPrinter)
            {
                prtList.Items.Add(item);
                if (item.Equals(pd.PrinterSettings.PrinterName))
                {
                    prtList.SelectedIndex = intIdx;
                }
                intIdx++;
            }
        }

        private void labelSet_Tantousha_Leave(object sender, EventArgs e)
        {
            GetTantouCode(labelSet_Tantousha.CodeTxtText);
        }

        private void labelSet_Torihikikbn_Leave(object sender, EventArgs e)
        {
            //textSet_Jucyu1.txtJucyuNoElem2.SelectAll();
            //this.ActiveControl = textSet_Jucyu1.txtJucyuNoElem2;
            //this.SelectNextControl(this.ActiveControl,true, true, true, true);
            editFlg = true;
        }

        ///<summary>
        ///A0020_UriageInput_Load
        ///画面レイアウト設定
        ///</summary>
        private void A0020_UriageInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "売上入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;

            //閲覧権限がある場合
            if (("1").Equals(etsuranFlg))
            {
                this.btnF03.Text = STR_FUNC_F3;

            }
            else
            {
                this.btnF03.Text = "F3:削除申請";
            }
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF07.Text = "F7:行削除";
            //this.btnF08.Text = "F8:売上実績確認";
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            //本日日付を設定
            txtYMD.Text = DateTime.Now.ToString("yyyy/MM/dd");

            //営業所コードに初期値を設定
            labelSet_Eigyosho.CodeTxtText = "0001";

            //担当者コード取得メソッドへ。
            GetTantouCode();

            //取引区分のデフォルトをセットする。
            labelSet_Torihikikbn.CodeTxtText = "11";

            //コンボボックスに値をセットする。
            cboNounyu.Items.Add("配達");
            cboNounyu.Items.Add("発送");
            cboNounyu.Items.Add("直送");
            cboNounyu.Items.Add("代納");
            cboNounyu.Items.Add("来店");

            //本日日付が2016年1月18日～21日の場合は直近仕入単価を非表示にする。
            if (DateTime.Now >= DateTime.Parse("2016/01/18") && DateTime.Now <= DateTime.Parse("2016/01/21"))
            {
                labelCyokkinSiireTanka.Visible = false;
                textSet_Jucyu1.txtCyokkinSiire.Visible = false;
                textSet_Jucyu2.txtCyokkinSiire.Visible = false;
                textSet_Jucyu3.txtCyokkinSiire.Visible = false;
                textSet_Jucyu4.txtCyokkinSiire.Visible = false;
                textSet_Jucyu5.txtCyokkinSiire.Visible = false;
            }
            else
            {
                labelCyokkinSiireTanka.Visible = true;
                textSet_Jucyu1.txtCyokkinSiire.Visible = true;
                textSet_Jucyu2.txtCyokkinSiire.Visible = true;
                textSet_Jucyu3.txtCyokkinSiire.Visible = true;
                textSet_Jucyu4.txtCyokkinSiire.Visible = true;
                textSet_Jucyu5.txtCyokkinSiire.Visible = true;
            }

            cmbSubWinShow.Items.Add("売上実績確認");
            cmbSubWinShow.Items.Add("受注残・発注残確認");
            cmbSubWinShow.Items.Add("商品元帳確認");
        }


        //ログインIDから担当者コードを得る。
        private void GetTantouCode()
        {
            //検索時のデータ取り出し先
            DataTable dtSetView;

            List<string> lstUriageSuiiLoad = new List<string>();
            //データの存在確認を検索する情報を入れる
            /*[0]環境ユーザー*/
            lstUriageSuiiLoad.Add(Environment.UserName);

            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriagesuiihyoB = new A0020_UriageInput_B();
            try
            {
                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = uriagesuiihyoB.GetTantouCode(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    labelSet_Tantousha.CodeTxtText = dtSetView.Rows[0]["担当者コード"].ToString();
                    labelSet_Eigyosho.CodeTxtText = dtSetView.Rows[0]["営業所コード"].ToString();
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        private void GetTantouCode(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                labelSet_Tantousha.CodeTxtText = "";
                labelSet_Eigyosho.CodeTxtText = "0001";
                return;
            }
            //検索時のデータ取り出し先
            DataTable dtSetView;

            List<string> lstUriageSuiiLoad = new List<string>();
            //データの存在確認を検索する情報を入れる
            /*[0]環境ユーザー*/
            lstUriageSuiiLoad.Add(user);

            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriagesuiihyoB = new A0020_UriageInput_B();
            try
            {
                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = uriagesuiihyoB.GetTantouCode2(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    labelSet_Tantousha.CodeTxtText = dtSetView.Rows[0]["担当者コード"].ToString();
                    labelSet_Eigyosho.CodeTxtText = dtSetView.Rows[0]["営業所コード"].ToString();
                }
                else
                {
                    labelSet_Eigyosho.CodeTxtText = "0001";
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///A0020_UriageInput_KeyDown
        ///キー入力判定(画面全般）
        ///</summary>
        private void A0020_UriageInput_KeyDown(object sender, KeyEventArgs e)
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
                    // ファンクションボタン制御
                    if (btnF01.Enabled == true)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        f1Flg = true;
                        btnF01.Focus();
                        this.addJucyu();
                        f1Flg = true;
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delJucyu();
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    logger.Info(LogUtil.getMessage(this._Title, "終り実行"));
                    btnF01.Focus();
                    break;
                case Keys.F7:
                    if (btnF07.Enabled == true)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                        this.delCurrentRow();
                    }
                    break;
                case Keys.F8:
                    //logger.Info(LogUtil.getMessage(this._Title, "売上実績確認実行"));
                    ////売上実績確認表示
                    //showUriageJissekiKakunin();
                    //break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    this.PrintReport(txtDenNo.Text,1);
                    break;
                case Keys.F12:

                    //売上実績確認が既に開いている場合        
                    if (uriagejissekikakunin != null)
                    {
                        uriagejissekikakunin.Close();
                    }

                    //受注残・発注残確認が既に開いている場合        
                    if (juchuzan != null)
                    {
                        juchuzan.Close();
                    }

                    //商品元帳確認が既に開いている場合        
                    if (shohinmoto != null)
                    {
                        shohinmoto.Close();
                    }

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
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    f1Flg = true;
                    this.addJucyu();
                    f1Flg = false;
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delJucyu();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F06: // 終り
                    logger.Info(LogUtil.getMessage(this._Title, "終り実行"));
                    btnF01.Focus();
                    break;
                case STR_BTN_F07: // 行削除
                    logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                    this.delCurrentRow();
                    break;
                case STR_BTN_F08: // 売上実績確認
                    //logger.Info(LogUtil.getMessage(this._Title, "売上実績確認実行"));
                    ////売上実績確認表示
                    //showUriageJissekiKakunin();
                    //break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.PrintReport(txtDenNo.Text, 1);
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));

                    //売上実績確認が既に開いている場合        
                    if (uriagejissekikakunin != null)
                    {
                        uriagejissekikakunin.Close();
                    }

                    //受注残・発注残確認が既に開いている場合        
                    if (juchuzan != null)
                    {
                        juchuzan.Close();
                    }

                    //商品元帳確認が既に開いている場合        
                    if (shohinmoto != null)
                    {
                        shohinmoto.Close();
                    }

                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// addJucyu
        /// 売上データを追加する。
        /// </summary>
        private void addJucyu()
        {
            //変数を初期化する。
            string Denno;
            int i;

            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            DBConnective con = null;

            try
            {
                labelSet_Tantousha.chkTxtTantosha();
                GetTantouCode(labelSet_Tantousha.CodeTxtText);

                this.Cursor = Cursors.WaitCursor;
                con = new DBConnective();
                con.BeginTrans();

                //倉庫間移動処理
                #region
                if (txtDenNo.Text == "")
                {
                    if (textSet_Jucyu1.txtJucyuNoElem2.Text != "")
                    {
                        //処理済の更新＆倉庫間移動データの追加処理へ。
                        Data_Create(textSet_Jucyu1.txtJucyuNoElem2.Text, con);
                    }

                    if (textSet_Jucyu2.txtJucyuNoElem2.Text != "")
                    {
                        //処理済の更新＆倉庫間移動データの追加処理へ。
                        Data_Create(textSet_Jucyu2.txtJucyuNoElem2.Text, con);
                    }

                    if (textSet_Jucyu3.txtJucyuNoElem2.Text != "")
                    {
                        //処理済の更新＆倉庫間移動データの追加処理へ。
                        Data_Create(textSet_Jucyu3.txtJucyuNoElem2.Text, con);
                    }


                    if (textSet_Jucyu4.txtJucyuNoElem2.Text != "")
                    {
                        //処理済の更新＆倉庫間移動データの追加処理へ。
                        Data_Create(textSet_Jucyu4.txtJucyuNoElem2.Text, con);
                    }

                    if (textSet_Jucyu5.txtJucyuNoElem2.Text != "")
                    {
                        //処理済の更新＆倉庫間移動データの追加処理へ。
                        Data_Create(textSet_Jucyu5.txtJucyuNoElem2.Text, con);
                    }
                }
                #endregion

                //データチェック処理を行うメソッドへ。
                if (!DataCheack(con))
                {
                    //データチェックがfalseの場合はデータベースをロールバックして終了。
                    con.Rollback();
                    return;

                }

                //伝票の記述がない場合は、伝票取得メソッドへ
                if (txtDenNo.Text == "")
                {
                    //伝票取得メソッドへ
                    Denno = GetDenpyoNo("売上伝票");
                }
                else
                {
                    Denno = txtDenNo.Text;
                }

            
                //データ追加プロシージャー始動
                //ビジネス層のインスタンス生成

                //検索時のデータ取り出し先
                DataTable dtSetView;

                //売上入力用データリスト
                #region
                List<string> UriageInputItem = new List<string>();
                /*[0]伝票NO*/
                UriageInputItem.Add(Denno);
                /*[１]伝票年月日*/
                UriageInputItem.Add(txtYMD.Text);
                /*[２]コード*/
                UriageInputItem.Add(labelSet_txtCD.CodeTxtText);
                /*[３]得意先名*/
                UriageInputItem.Add(txtTname.Text);
                /*[４]郵便番号*/
                UriageInputItem.Add(txtYubin.Text);
                /*[５]住所１*/
                UriageInputItem.Add(txtAdr1.Text);
                /*[６]住所２*/
                UriageInputItem.Add(txtAdr2.Text);
                /*[７]取引先区分コード*/
                UriageInputItem.Add(labelSet_Torihikikbn.CodeTxtText);
                /*[８]担当者コード*/
                UriageInputItem.Add(labelSet_Tantousha.CodeTxtText);
                /*[９]営業所コード*/
                UriageInputItem.Add(labelSet_Eigyosho.CodeTxtText);
                //null
                /*[１０]摘要*/
                UriageInputItem.Add(txtTekiyo.Text);
                /*[１１]納入方法*/
                UriageInputItem.Add(cboNounyu.Text);
                /*[１２]売上合計*/
                UriageInputItem.Add(txtGoukei1.Text);
                /*[１３]消費税*/
                UriageInputItem.Add(txtZei.Text);
                /*[１４]総合計*/
                UriageInputItem.Add(txtGoukei2.Text);
                /*[１５]粗利合計*/
                UriageInputItem.Add(txtArariKei.Text);
                /*[１６]直送先コード*/
                UriageInputItem.Add(txtCyoku.Text);
                /*[１７]直送先名*/
                UriageInputItem.Add(txtName_C.Text);
                /*[１８]郵便番号*/
                UriageInputItem.Add(txtYubin_C.Text);
                /*[１９]直送先住所１*/
                UriageInputItem.Add(txtAdr1_C.Text);
                /*[２０]直送先住所２*/
                UriageInputItem.Add(txtAdr2_C.Text);
                /*[２１]環境ユーザ*/
                UriageInputItem.Add(Environment.UserName);
                #endregion

                //ビジネス層、売上ヘッダ更新（プロシージャー）
                uriageinputB.updUriageHeader(UriageInputItem, con);
                //ビジネス層、受注＿売上数＿戻し更新（プロシージャー）
                uriageinputB.updUriagesuuModosi(UriageInputItem, con);
                //ビジネス層、売上明細削除（プロシージャー）
                uriageinputB.delUriageMeisai(UriageInputItem, con);

                //変数を初期化する。
                string Kataban = "";
                string SyohinCD = "";

                KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B juchuB = new KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B();

                for (i = 1; i <= 5; i++)
                {
                    //明細コントロールを取得。
                    Control[] cs1 = this.Controls.Find("textSet_Jucyu" + i.ToString(), true);

                    //商品検索用データリスト
                    #region
                    List<string> MeisaiItem = new List<string>();
                    /*[0]環境ユーザー*/
                    MeisaiItem.Add(Environment.UserName);
                    /*[１]elem1(No)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtNoElem1.Text);
                    /*[２]elem2(受注番号)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);
                    /*[３]elem3(品名・型番)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtSinaBanElem3.Text);
                    /*[４]elem4(数量)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text);
                    /*[５]elem5(単価)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text);
                    /*[６]elem6(金額)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtKingakuElem6.Text);
                    /*[７]elem7(原価)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text);
                    /*[８]elem8(粗利額)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtArariElem8.Text);
                    /*[９]elem9(備考)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtBikouElem9.Text);
                    /*[１０]elem10(倉庫番号)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).labelSet_SoukoNoElem10.CodeTxtText);
                    /*[１１]elem11(商品コード)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text);
                    /*[１２]elem12(メーカコード)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtElem12.Text);
                    /*[１３]elem13(大分類コード)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtElem13.Text);
                    /*[１４]elem14(中分類コード)*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtElem14.Text);
                    /*[１５]elem15*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtElem15.Text);
                    /*[１６]elem16*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtElem16.Text);
                    /*[１７]elem17*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtElem17.Text);
                    /*[１８]elem18*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtElem18.Text);
                    /*[１９]elem19*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtElem19.Text);
                    /*[２０]elem20*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtElem20.Text);
                    /*[２１]elem21*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtRitsuElem21.Text);
                    /*[２２]elem22*/
                    MeisaiItem.Add(((TextSet_Jucyu)cs1[0]).txtElem22.Text);
                    #endregion

                    if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                    {
                        //手入力の品名の場合は新規商品として追加登録 加工発注を含む 2006.5.11
                        if (((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text == "88888")
                        {
                            Kataban = ((TextSet_Jucyu)cs1[0]).txtElem15.Text +
                                      ((TextSet_Jucyu)cs1[0]).txtElem16.Text +
                                      ((TextSet_Jucyu)cs1[0]).txtElem17.Text +
                                      ((TextSet_Jucyu)cs1[0]).txtElem18.Text +
                                      ((TextSet_Jucyu)cs1[0]).txtElem19.Text +
                                      ((TextSet_Jucyu)cs1[0]).txtElem20.Text;

                            Kataban = Kataban.Replace(" ", "");

                            //ビジネス層、型番に一致する商品コードを取得する。
                            dtSetView = uriageinputB.getSyohinCd(MeisaiItem, Kataban, con);

                            if (dtSetView.Rows.Count > 0)
                            {
                                SyohinCD = dtSetView.Rows[0]["商品コード"].ToString();
                            }
                            else
                            {
                                //新しい商品コードを取得するメソッドへ。
                                SyohinCD = GetNewSyohinNo();

                                //ビジネス層、商品マスタ更新（プロシージャー）
                                uriageinputB.updSyohinMastr(MeisaiItem, SyohinCD, con);
                            }

                        }
                        else
                        {
                            SyohinCD = ((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text;
                        }

                        //ビジネス層、売上明細更新（プロシージャー）
                        uriageinputB.updUriageMeisai(MeisaiItem, SyohinCD,Denno,i.ToString(), con);

                        //受注の商品コードが88888の場合は採用した商品コードを更新 2006.5.11
                        if (((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text == "88888")
                        {
                            //ビジネス層、受注テーブルの商品コードを更新
                            uriageinputB.updJTableSyohinCD(MeisaiItem, SyohinCD, con);
                        }

                        //'受注の商品コードが88888の場合は採用した商品コードを発注データにも更新 2007.4.25
                        //'仕入先が返品口座（９９９９）の場合は仕入が発生しないため、売上時に商品コードを更新するしかない
                        if (((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text == "88888")
                        {
                            //ビジネス層、発注テーブルの商品コードを更新
                            uriageinputB.updHTableSyohinCD(MeisaiItem, SyohinCD,Kataban, con);
                        }

                        //８８８８、６６６６の場合は得意先名を更新   2012.2.14
                        if (labelSet_txtCD.CodeTxtText == "8888" || labelSet_txtCD.CodeTxtText == "6666")
                        {
                            //ビジネス層、受注テーブルの得意先名称を更新。
                            uriageinputB.updJTableTokuisakiName(MeisaiItem,UriageInputItem, con);
                        }

                        juchuB.updZaiko(SyohinCD, labelSet_Eigyosho.CodeTxtText, txtYMD.Text, Environment.UserName, con);
                    }
                }

                //商品検索用データリスト
                List<string> CyokuItem = new List<string>();
                /*[0]得意先コード*/
                CyokuItem.Add(labelSet_txtCD.CodeTxtText);
                /*[１]直送先コード*/
                CyokuItem.Add(txtCyoku.Text);
                /*[２]直送先名称*/
                CyokuItem.Add(txtName_C.Text);
                /*[３]郵便番号*/
                CyokuItem.Add(txtYubin_C.Text);
                /*[４]住所１*/
                CyokuItem.Add(txtAdr1_C.Text);
                /*[５]住所２*/
                CyokuItem.Add(txtAdr2_C.Text);
                /*[6]電話番号*/
                CyokuItem.Add(txtTelNo_C.Text);
                /*[7]部署名*/
                CyokuItem.Add(txtBusyo_C.Text);
                /*[8]環境ユーザ*/
                CyokuItem.Add(Environment.UserName);

                if (txtCyoku.Text != "")
                {

                    //直送先コードに該当するレコードの有無をチェック
                    dtSetView = uriageinputB.GetCyokuCode(CyokuItem, con);

                    if (decimal.Parse(dtSetView.Rows[0]["直送先コードカウント"].ToString()) > 0)
                    {
                        //レコードがあった場合は更新する。
                        uriageinputB.updCyokusousaki(CyokuItem, con);
                    }
                    else
                    {
                        //レコードがなかった場合は登録する。
                        uriageinputB.insCyokusousaki(CyokuItem, con);
                    }
                }

                con.Commit();

                txtDenNo.Text = Denno;
                editFlg = false;

                //印刷しないにチェックがない場合は印刷メソッドへ
                if (chkInsatu.Checked == false)
                {
                    //印刷画面へ遷移。
                    //PrintReport(Denno, 0);
                }

                // メッセージボックスの処理、追加成功の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //取消メソッドへ。
                delText();
                
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                if (con != null)
                {
                    con.Rollback();
                }
                //エラーロギング
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// delJucyu
        /// 売上データを削除する。
        /// </summary>
        private void delJucyu()
        {

            //変数の初期化
            string Denno;

            //伝票Noの取得。
            Denno = txtDenNo.Text;

            //伝票Noが空欄だった場合は処理終了。
            if(Denno == "")
            {
                return;
            }

            //日付制限2006.01.31
            if (!GDateCheckEG(2, labelSet_Eigyosho.CodeTxtText, DateTime.Parse(txtYMD.Text)))
            {
                txtYMD.Focus();
                return ;
            }

            //閲覧権限がある場合
            if (("1").Equals(etsuranFlg))
            {
                // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "表示中の伝票を削除します。\r\nよろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                // NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "表示中の伝票を削除申請します。\r\nよろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                // NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }
            }

            DBConnective con = null;
            KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B juchuB = new KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B();

            con = new DBConnective();

            try
            {
                //ビジネス層のインスタンス生成
                A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
                
                //売上入力用データリスト
                List<string> UriageInputItem = new List<string>();
                /*[0]伝票NO*/
                UriageInputItem.Add(Denno);
                /*[１]環境ユーザ*/
                UriageInputItem.Add(Environment.UserName);

                con.BeginTrans();

                //閲覧権限がある場合
                if (("1").Equals(etsuranFlg))
                {
                    //ビジネス層、プロシージャー実行（売上ヘッダ削除_PROC、受注_売上数_戻し更新_PROC、売上明細削除_PROC）
                    DataTable dt = uriageinputB.getShohins(Denno, con);
                    uriageinputB.delUriageData(UriageInputItem, con);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            juchuB.updZaiko(dr["商品コード"].ToString(), labelSet_Eigyosho.CodeTxtText, txtYMD.Text, Environment.UserName, con);
                        }
                        con.Commit();
                    }

                    // メッセージボックスの処理、削除成功の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();

                }
                else
                {
                    //売上削除承認に追加
                    uriageinputB.updUriageSakujoShonin(UriageInputItem, con);

                    // メッセージボックスの処理、申請成功の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "削除申請をしました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                }

                con.Commit();

                //取消メソッドへ。
                delText();

            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Rollback();
                }
                //エラーロギング
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

        }

        /// <summary>
        /// showUriageJissekiKakunin
        /// 売上実績確認フォームを開く処理
        /// </summary>
        private void showUriageJissekiKakunin()
        {
            //コードが空欄の場合は処理終了。
            if (labelSet_txtCD.CodeTxtText == "")
            {
                return;
            }
            
            //売上実績フォームを開く処理
            int intFrmKind = 0020;

            D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin uriagejissekikakunin =
                new D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, intFrmKind,labelSet_txtCD.CodeTxtText,"");
            uriagejissekikakunin.Show();
        }

        /// <summary>
        /// GetDenpyoNo
        // 伝票番号テーブルから新規伝票番号を得る。
        /// </summary>
        public string GetDenpyoNo(string DenName)
        {
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                return uriageinputB.getDenpyoNo(DenName);
               
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                return null;
            }
        }

        /// <summary>
        /// PDF印刷を行う。
        /// </summary>
        /// <param name="Denno">伝票NO</param>
        /// <param name="Flag">再印刷フラグ 0:通常　1:再印刷</param>
        private void PrintReport(string Denno,int Flag)
        {
            this.Cursor = Cursors.WaitCursor;
            if (string.IsNullOrWhiteSpace(txtDenNo.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "登録してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                return;
            }
            if (editFlg)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "登録してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                return;
            }

            // ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinput_B = new A0020_UriageInput_B();
            try
            {
                //ラジオボタンの結果をChokusoFLGに保持。
                int ChokusoFLG = radSyubetu.judCheckBtn();

                //プロシージャーからデータテーブルを取得。
                // 検索実行（印刷用）
                DataTable dtSetView1 = uriageinput_B.getUriageDenpyoPrint(Denno,Environment.UserName,Flag);

                DataTable dtSetView2 = uriageinput_B.getUriageDenpyoPrint(Denno, Environment.UserName, Flag, ChokusoFLG);

                DataTable dtSetView3 = uriageinput_B.getUriageDenpyoPrint(Denno, Environment.UserName, Flag, ChokusoFLG);


                // 対象データがある場合
                if (dtSetView1 != null && dtSetView1.Rows.Count > 0)
                {
                    //検索で使用したデータをリストに保持
                    List<string> lstSearchItem = new List<string>();
                    //[0]伝票番号
                    lstSearchItem.Add(Denno);
                    //[1]ユーザ名
                    lstSearchItem.Add(Environment.UserName);
                    //[2]再印刷フラグ
                    lstSearchItem.Add(Flag.ToString());
                    //[3]直送先フラグ
                    lstSearchItem.Add(ChokusoFLG.ToString());
                    //[4]得意先コード
                    lstSearchItem.Add(labelSet_txtCD.CodeTxtText);
                    //[5]直送先名称
                    lstSearchItem.Add(txtName_C.Text);

                    
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, CommonTeisu.TATE);
             

                    //SPAdminUserの場合は印刷ﾀﾞｲｱﾛｸﾞを表示、それ以外は直印刷
                    if (Environment.UserName != "SPAdminUser")
                    {
                        //pf.ShowDialog(this);
                        //if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                        //{
                        //    //PDF作成
                        //    String strFile = uriageinput_B.dbToPdf(dtSetView1, dtSetView2, dtSetView3, lstSearchItem);
                        //    pf.execPreview(@strFile);
                        //    pf.ShowDialog(this);
                        //}
                        //else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                        //{
                        //    //PDF作成
                        //    String strFile = uriageinput_B.dbToPdf(dtSetView1, dtSetView2, dtSetView3, lstSearchItem);
                        //    pf.execPrint(null, @strFile, CommonTeisu.SIZE_A4, CommonTeisu.TATE, true);

                        //    //印刷済みにする。（プロシージャー）
                        //    Flag = 0;
                        //    uriageinput_B.updInsatuzumi(Denno, Environment.UserName, Flag);

                        //    //ラベルプリンターで印刷
                        //    uriageinput_B.dbToExcel();
                        //}
                        String strFile = uriageinput_B.dbToPdf(dtSetView1, dtSetView2, dtSetView3, lstSearchItem);
                        pf.execPrint(prtList.SelectedItem.ToString(), @strFile, CommonTeisu.SIZE_A4, CommonTeisu.TATE, true);

                        //ラベルプリンターで印刷
                        uriageinput_B.printGenpinhyo(Denno, false);

                        //印刷済みにする。（プロシージャー）
                        Flag = 1;
                        uriageinput_B.updInsatuzumi(Denno, Environment.UserName, Flag);
                    }
                    else
                    {
                        //PDF作成
                        String strFile = uriageinput_B.dbToPdf(dtSetView1, dtSetView2, dtSetView3, lstSearchItem);
                        pf.execPrint(prtList.SelectedItem.ToString(), @strFile, CommonTeisu.SIZE_A4, CommonTeisu.TATE,false);

                        //ラベルプリンターで印刷
                        uriageinput_B.printGenpinhyo(Denno, false);

                        //印刷済みにする。（プロシージャー）
                        Flag = 1;
                        uriageinput_B.updInsatuzumi(Denno, Environment.UserName, Flag);
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
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// GetDenpyoNo
        /// 商品テーブルから新規商品コードを得る。
        /// </summary>
        public string GetNewSyohinNo()
        {
            string reGetNewSyohinNo = "";

            //変数を初期化。
            string dummy = "";
            string returnval = "";
            string cdHEAD ="";
            string cdHEAD2 = "";
            string DenNoStr = "";
            string DenNoStr2 = "";

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                //ビジネス層、商品コードの最大値を取得する。
                dtSetView = uriageinputB.getMaxSyohinCd();

                if (dtSetView.Rows.Count > 0)
                {
                    //商品コードの左から1文字を取得する。
                    cdHEAD = vbLeft(dtSetView.Rows[0]["MAX商品コード"].ToString(), 1);
                }

                switch (cdHEAD)
                {
                    case "A":
                        cdHEAD2 = "B";
                        DenNoStr = "商品コード２";
                        DenNoStr2 = "商品コード３";
                        break;
                    case "B":
                        cdHEAD2 = "C";
                        DenNoStr = "商品コード３";
                        DenNoStr2 = "商品コード４";
                        break;
                    case "C":
                        cdHEAD2 = "D";
                        DenNoStr = "商品コード４";
                        DenNoStr2 = "商品コード５";
                        break;
                    case "D":
                        cdHEAD2 = "E";
                        DenNoStr = "商品コード５";
                        DenNoStr2 = "商品コード６";
                        break;
                    case "E":
                        cdHEAD2 = "F";
                        DenNoStr = "商品コード６";
                        DenNoStr2 = "商品コード７";
                        break;
                    case "F":
                        cdHEAD2 = "G";
                        DenNoStr = "商品コード７";
                        DenNoStr2 = "商品コード８";
                        break;
                    case "G":
                        cdHEAD2 = "H";
                        DenNoStr = "商品コード８";
                        DenNoStr2 = "商品コード９";
                        break;
                    case "H":
                        cdHEAD2 = "I";
                        DenNoStr = "商品コード９";
                        DenNoStr2 = "商品コード１０";
                        break;
                    case "I":
                        cdHEAD2 = "J";
                        DenNoStr = "商品コード１０";
                        DenNoStr2 = "商品コード１１";
                        break;
                    case "J":
                        cdHEAD2 = "K";
                        DenNoStr = "商品コード１１";
                        DenNoStr2 = "商品コード１２";
                        break;
                    case "K":
                        cdHEAD2 = "L";
                        DenNoStr = "商品コード１２";
                        DenNoStr2 = "商品コード１３";
                        break;
                    case "L":
                        cdHEAD2 = "M";
                        DenNoStr = "商品コード１３";
                        DenNoStr2 = "商品コード１４";
                        break;
                    case "M":
                        cdHEAD2 = "N";
                        DenNoStr = "商品コード１４";
                        DenNoStr2 = "商品コード１５";
                        break;
                    case "N":
                        cdHEAD2 = "O";
                        DenNoStr = "商品コード１５";
                        DenNoStr2 = "商品コード１６";
                        break;
                    case "O":
                        cdHEAD2 = "P";
                        DenNoStr = "商品コード１６";
                        DenNoStr2 = "商品コード１７";
                        break;
                    case "P":
                        cdHEAD2 = "Q";
                        DenNoStr = "商品コード１７";
                        DenNoStr2 = "商品コード１８";
                        break;
                    case "Q":
                        cdHEAD2 = "R";
                        DenNoStr = "商品コード１８";
                        DenNoStr2 = "商品コード１９";
                        break;
                    case "R":
                        cdHEAD2 = "S";
                        DenNoStr = "商品コード１９";
                        DenNoStr2 = "商品コード２０";
                        break;
                    case "S":
                        cdHEAD2 = "T";
                        DenNoStr = "商品コード２０";
                        DenNoStr2 = "商品コード２１";
                        break;
                    case "T":
                        cdHEAD2 = "U";
                        DenNoStr = "商品コード２１";
                        DenNoStr2 = "商品コード２２";
                        break;
                    case "U":
                        cdHEAD2 = "V";
                        DenNoStr = "商品コード２２";
                        DenNoStr2 = "商品コード２３";
                        break;
                    case "V":
                        cdHEAD2 = "W";
                        DenNoStr = "商品コード２３";
                        DenNoStr2 = "商品コード２４";
                        break;
                    case "W":
                        cdHEAD2 = "X";
                        DenNoStr = "商品コード２４";
                        DenNoStr2 = "商品コード２５";
                        break;
                    case "X":
                        cdHEAD2 = "Y";
                        DenNoStr = "商品コード２５";
                        DenNoStr2 = "商品コード２６";
                        break;
                    case "Y":
                        cdHEAD2 = "Z";
                        DenNoStr = "商品コード２６";
                        DenNoStr2 = "商品コード２７";
                        break;
                    case "Z":
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT,"システムエラー（商品追加）", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return null;
                }

                //商品番号が９９９９に達した場合は次のアルファベットに変更する。
                if (decimal.Parse(vbMid(dtSetView.Rows[0]["MAX商品コード"].ToString(), 2, 4)) >= 9999)
                {
                    cdHEAD = cdHEAD2;
                    DenNoStr = DenNoStr2;
                }

                dummy = "0";

                //検索アイテムをリストデータで保持
                List<string> lstString = new List<string>();
                lstString.Add("1");
                lstString.Add(returnval);
                lstString.Add(DenNoStr);
                lstString.Add(dummy);


                //ビジネス層、商品番号を取得する。（プロシージャー）
                reGetNewSyohinNo = cdHEAD +　string.Format(GetDenpyoNo(DenNoStr),"0000");

                return reGetNewSyohinNo;
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return null;
            }
        }

        /// <summary>
        /// vbLeft
        /// VBのleft関数にあたる。
        /// </summary>
        public static string vbLeft(string stTarget, int iLength)
        {
            if (iLength <= stTarget.Length)
            {
                return stTarget.Substring(0, iLength);
            }

            return stTarget;
        }

        /// <summary>
        /// vbMid
        /// VBのmidにあたる。
        /// </summary>
        public static string vbMid(string stTarget, int iStart)
        {
            if (iStart <= stTarget.Length)
            {
                return stTarget.Substring(iStart - 1);
            }

            return string.Empty;
        }

        /// <summary>
        /// vbMid
        /// VBのmidにあたる。
        /// </summary>
        public static string vbMid(string stTarget, int iStart, int iLength)
        {
            if (iStart <= stTarget.Length)
            {
                if (iStart + iLength - 1 <= stTarget.Length)
                {
                    return stTarget.Substring(iStart - 1, iLength);
                }

                return stTarget.Substring(iStart - 1);
            }

            return string.Empty;
        }

        /// <summary>
        /// vbRight
        /// VBのRightにあたる。
        /// </summary>
        public static string vbRight(string stTarget, int iLength)
        {
            if (iLength <= stTarget.Length)
            {
                return stTarget.Substring(stTarget.Length - iLength);
            }

            return stTarget;
        }

        /// <summary>
        /// DataCheack
        /// データのチェックを行う。
        /// </summary>
        private Boolean DataCheack(DBConnective con)
        {
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();

            #region
            if (txtYMD.Text == "")
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtYMD.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtYMD.chkDateDataFormat(txtYMD.Text)))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                txtYMD.Focus();
                return false;
            }

            if (labelSet_txtCD.CodeTxtText == "")
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_txtCD.Focus();
                return false;
            }
            if (labelSet_txtCD.chkTxtTorihikisaki())
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力項目が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_txtCD.Focus();
                return false;
            }

            if (labelSet_Tantousha.CodeTxtText == "")
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tantousha.Focus();
                return false;
            }
            if (labelSet_Tantousha.chkTxtTantosha())
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力項目が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tantousha.Focus();
                return false;
            }

            if (labelSet_Torihikikbn.CodeTxtText == "")
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Torihikikbn.Focus();
                return false;
            }
            if (labelSet_Torihikikbn.chkTxtTorihikikbn())
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力項目が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Torihikikbn.Focus();
                return false;
            }

            //変数を初期化する。
            bool reGood = true;
            String RituMSG ="";
            int i;
            int j;
            int H_Flag;
            decimal JuSU;
            decimal UriSU;
            decimal UriSU2;
            string Kataban;
            bool ari;
            ari = false;
            bool Kakohin;
            Kakohin = false;
            int SyohinbetuCheckFLG;
            int SyohinbetuCheckFLGAll;
            SyohinbetuCheckFLGAll = 0;
            int[] DoituTanka = new int[6];

            //明細1の入力チェック
            if (textSet_Jucyu1.txtJucyuNoElem2.Text != "")
            {
                ari = true;
            }

            //明細2の入力チェック
            if (textSet_Jucyu2.txtJucyuNoElem2.Text != "")
            {
                ari = true;
            }

            //明細3の入力チェック
            if (textSet_Jucyu3.txtJucyuNoElem2.Text != "")
            {
                ari = true;
            }

            //明細4の入力チェック
            if (textSet_Jucyu4.txtJucyuNoElem2.Text != "")
            {
                ari = true;
            }

            //明細5の入力チェック
            if (textSet_Jucyu5.txtJucyuNoElem2.Text != "")
            {
                ari = true;
            }

            //明細の入力が1行もなかった場合はメッセージを表示して、終了。
            if (ari == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this,CommonTeisu.TEXT_INPUT , "明細が１行もありません。伝票を削除する場合は、削除（F3)を押してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }

            //明細と明細の間に空行があるかチェック
            for (i = 1; i <= 5; i++)
            {
                Control[] cs1 = this.Controls.Find("textSet_Jucyu" + i.ToString(), true);

                //受注明細が空欄だった場合はariフラグをtrueにし、ループを抜ける。
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text == "")
                {
                    ari = true;
                    break;
                }
            }

            //ariフラグがtrueの場合
            if (ari == true)
            {
                int iST;
                iST = i + 1;

                //明細のない欄の次からスタートし、入力行があるかチェック。
                for (i = iST; i <= 5; i++)
                {
                    Control[] cs1 = this.Controls.Find("textSet_Jucyu" + i.ToString(), true);

                    //空欄行の後に入力行があった場合は、メッセージを表示し、処理終了。
                    if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                    {
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this,CommonTeisu.TEXT_INPUT , "空行が挿入されています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return false;
                    }
                }
            }
            #endregion

            //データ項目のチェック。
            for (i = 1; i <= 5; i++)
            {
                Control[] cs1 = this.Controls.Find("textSet_Jucyu" + i.ToString(), true);
                #region
                //受注NOが空欄の場合は処理をSKIP。
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    //品名・型番が空白だった場合は処理を終了。
                    if (((TextSet_Jucyu)cs1[0]).txtSinaBanElem3.Text == "")
                    {
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return false;
                    }

                    //数量が空欄だった場合は処理を終了。
                    if (((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text == "")
                    {
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return false;
                    }

                    //単価が空欄だった場合は処理を終了。
                    if (((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text == "")
                    {
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return false;
                    }

                    //金額が空欄だった場合は処理を終了。
                    if (((TextSet_Jucyu)cs1[0]).txtKingakuElem6.Text == "")
                    {
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return false;
                    }

                    //原価が空欄だった場合は処理を終了。
                    if (((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text == "")
                    {
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return false;
                    }

                    //粗利が空欄だった場合は処理を終了。
                    if (((TextSet_Jucyu)cs1[0]).txtArariElem8.Text == "")
                    {
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return false;
                    }

                    //倉庫が空欄だった場合は処理を終了。
                    if (((TextSet_Jucyu)cs1[0]).labelSet_SoukoNoElem10.CodeTxtText == "")
                    {
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return false;
                    }
                }

                
                //注番の重複チェック
                for (j = 1; j <= 5; j++)
                {
                    //iとjが同じ数字の場合は比較しない。
                    if (i != j)
                    {
                        Control[] cs2 = this.Controls.Find("textSet_Jucyu" + j.ToString(), true);

                        //注文番号がどちらか空欄の場合は処理をSKIP
                        if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "" && ((TextSet_Jucyu)cs2[0]).txtJucyuNoElem2.Text != "")
                        {
                            //注文番号が重複する場合は処理を終了する。
                            if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text == ((TextSet_Jucyu)cs2[0]).txtJucyuNoElem2.Text)
                            {
                                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "注文No.が重複してます", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                basemessagebox.ShowDialog();
                                return false;
                            }
                        }
                        
                    }
                }
                #endregion


                //'受注数量＞＝売上数量のチェック
                //'2015.5.7 分納の場合も考慮
                #region
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    JuSU = 0;
                    UriSU = 0;
                    UriSU2 = 0;

                    //検索アイテムをリストデータで保持
                    List<string> lstString = new List<string>();

                    //[0]受注No
                    lstString.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);

                    //検索時のデータ取り出し先
                    DataTable dtSetView;

                    //ビジネス層のインスタンス生成
                    try
                    {
                        //ビジネス層、受注数量を取得する。
                        dtSetView = uriageinputB.getJucyuSuuryo(lstString, con);

                        if(dtSetView.Rows.Count > 0)
                        {
                            JuSU = decimal.Parse(dtSetView.Rows[0]["受注数量"].ToString());
                        }

                        //ビジネス層、売上明細から売上数量の合計を取得する。
                        dtSetView = uriageinputB.getSumUriageSuuryo(lstString, con);

                        if (dtSetView.Rows.Count > 0)
                        {
                            UriSU = decimal.Parse(PutIsNull(dtSetView.Rows[0]["合計売上数量"].ToString(), "0"));
                        }

                        //伝票番号が入力されていない場合は処理をSKIP
                        if (txtDenNo.Text != "")
                        {
                            string gyoNo = i.ToString();

                            List<string> lstCurrentRowSuuryo = new List<string>();
                            lstCurrentRowSuuryo.Add(txtDenNo.Text);
                            lstCurrentRowSuuryo.Add(gyoNo);

                            //ビジネス層、売上明細から現在行の数量を取得する。
                            dtSetView = uriageinputB.getCurrentRowUriageSuuryo(lstCurrentRowSuuryo, con);

                            if (dtSetView.Rows.Count > 0)
                            {
                                UriSU2 = decimal.Parse(PutIsNull(dtSetView.Rows[0]["数量"].ToString(), "0"));
                            }
                        }

                        if (decimal.Parse(((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text) +UriSU - UriSU2 > JuSU)
                        {
                            // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "受注数量を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            ((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Focus();
                            return false;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        
                        //エラーロギング
                        new CommonException(ex);
                    }
                }
                #endregion

                //売上単価＝０のチェック
                if (((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text != "")
                {
                    if (decimal.Parse(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text) == 0)
                    {
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "売上単価＝０は不可です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        ((TextSet_Jucyu)cs1[0]).txtTankaElem5.Focus();
                        return false;
                    }
                }

                //同時売上ガード
                #region
                if (string.IsNullOrWhiteSpace(txtDenNo.Text) && ((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    //検索アイテムをリストデータで保持
                    List<string> lstString = new List<string>();

                    //[0]受注No
                    lstString.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);

                    //検索時のデータ取り出し先
                    DataTable dtSetView;

                    //ビジネス層のインスタンス生成
                    try
                    {
                        //ビジネス層、受注データを取得する。
                        dtSetView = uriageinputB.getJucyu(lstString, con);

                        if (dtSetView.Rows.Count > 0)
                        {
                            if (dtSetView.Rows[0]["売上フラグ"].ToString() == "1")
                            {
                                if (decimal.Parse(dtSetView.Rows[0]["売上済数量"].ToString()) >= decimal.Parse(dtSetView.Rows[0]["受注数量"].ToString()))
                                {
                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "売上済の受注データです！！", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                    basemessagebox.ShowDialog();
                                    return false;
                                }
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        
                        //エラーロギング
                        new CommonException(ex);
                    }
                }
                #endregion

                //在庫出庫は原価＝０のチェック
                #region
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    H_Flag = 0;

                    //検索アイテムをリストデータで保持
                    List<string> lstString = new List<string>();

                    //[0]受注No
                    lstString.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);

                    //検索時のデータ取り出し先
                    DataTable dtSetView;

                    //ビジネス層のインスタンス生成
                    try
                    {
                        //ビジネス層、発注指示区分を取得する。
                        dtSetView = uriageinputB.getHacyusijiKbn(lstString, con);

                        if (dtSetView.Rows.Count > 0)
                        {
                            H_Flag = int.Parse(dtSetView.Rows[0]["発注指示区分"].ToString());
                        }

                        if (H_Flag == 0 && ((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text == "0")
                        {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "在庫出庫は原価＝０は不可です。受注入力で仕入単価を入力して下さい。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        
                        //エラーロギング
                        new CommonException(ex);
                    }
                }
                #endregion

                //受注品番が加工発注品番に１個も存在しない場合はエラー　2006.6.9
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                #region
                {
                    //検索アイテムをリストデータで保持
                    List<string> lstString = new List<string>();

                    //[0]受注No
                    lstString.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);

                    //検索時のデータ取り出し先
                    DataTable dtSetView;

                    //ビジネス層のインスタンス生成
                    try
                    {
                        //ビジネス層、発注データをカウントする。
                        dtSetView = uriageinputB.getHacyuCount(lstString, con);

                        if (decimal.Parse(dtSetView.Rows[0]["発注カウント"].ToString()) > 0)
                        {
                            Kataban = ((TextSet_Jucyu)cs1[0]).txtElem15.Text +
                                      ((TextSet_Jucyu)cs1[0]).txtElem16.Text +
                                      ((TextSet_Jucyu)cs1[0]).txtElem17.Text +
                                      ((TextSet_Jucyu)cs1[0]).txtElem18.Text +
                                      ((TextSet_Jucyu)cs1[0]).txtElem19.Text +
                                      ((TextSet_Jucyu)cs1[0]).txtElem20.Text;

                            Kataban = Kataban.Replace(" ", "");
                            Kataban = Kataban.Replace("　", "");     //2006.6.15  全角スペースも無し変換

                            //[1]型番
                            lstString.Add(Kataban);

                            //ビジネス層、型番が一致する発注データをカウントする。
                            dtSetView = uriageinputB.getKatbanHacyuCount(lstString, con);

                            //型番が一致しない場合はメッセージを表示し、処理を終了。
                            if (decimal.Parse(dtSetView.Rows[0]["型番発注カウント"].ToString()) == 0)
                            {
                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "受注品番が発注品番に１個も存在しません。\r\n受注伝票・発注伝票を確認してください。\r\n加工品の場合は、加工品受注入力画面で加工状況を確認してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                basemessagebox.ShowDialog();
                                return false;
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        
                        //エラーロギング
                        new CommonException(ex);
                    }
                }
                #endregion

                //'材料発注・加工発注の仕入入力をチェックして未入力がある場合はエラー　2006.6.9
                #region
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    //検索アイテムをリストデータで保持
                    List<string> lstString = new List<string>();

                    //[0]受注No
                    lstString.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);

                    //検索時のデータ取り出し先
                    DataTable dtSetView;

                    //ビジネス層のインスタンス生成
                    try
                    {
                        //ビジネス層、受注番号と仕入先コードから発注データをカウントする。
                        dtSetView = uriageinputB.getSiiresakiSiteiHacyuCount(lstString, con);

                        if (decimal.Parse(dtSetView.Rows[0]["仕入先指定発注カウント"].ToString()).CompareTo(0) > 0)
                        {
                            //ビジネス層、仕入済数量が0の発注データをカウントする。
                            dtSetView = uriageinputB.SiirezumiSuuryoHacyuCount(lstString, con);

                            if (decimal.Parse(dtSetView.Rows[0]["仕入済数量発注カウント"].ToString()).CompareTo(0) > 0)
                            {
                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "未仕入の発注伝票があります。\r\n発注伝票・仕入伝票を確認してください。\r\n加工品の場合は、加工品受注入力画面で仕入状況を確認してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                basemessagebox.ShowDialog();
                                return false;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        
                        //エラーロギング
                        new CommonException(ex);
                    }
                }
                #endregion

                //2006.9.5  仕入先が返品値引口座(9999)の場合は、" & vbCrLf & "数量＜０及び売上単価＜仕入単価の売上でかつ、
                //              NO.23.返品値引分売上承認入力で承認未のものは売上できません
                #region
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    //検索アイテムをリストデータで保持
                    List<string> lstString = new List<string>();

                    //[0]受注No
                    lstString.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);
                    //[1]数量
                    lstString.Add(((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text);

                    //検索時のデータ取り出し先
                    DataTable dtSetView;

                    //ビジネス層のインスタンス生成
                    try
                    {
                        //ビジネス層、数量が0未満の受発注データをカウント
                        dtSetView = uriageinputB.getSuryoSiteiJuhacyu(lstString, con);

                        if (decimal.Parse(dtSetView.Rows[0]["数量0未満受発注カウント"].ToString()) > 0)
                        {
                            //ビジネス層、返品値引売上承認フラグを取得する。
                            dtSetView = uriageinputB.getHenpinNebikiUriageSyoninFlg(lstString, con);

                            if (decimal.Parse(dtSetView.Rows[0]["返品値引売上承認フラグ"].ToString()) == 0)
                            {
                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "数量＜０の売上はできません。返品値引分売上承認入力で承認してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                basemessagebox.ShowDialog();
                                return false;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        
                        //エラーロギング
                        new CommonException(ex);
                    }
                }
                #endregion

                //2007.6.27  売上単価＜仕入単価の売上は禁止   '仕入品のみ対象
                #region
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    //部長は処理をSKIP
                    if (!"1".Equals(riekiritsuFlg))
                    {
                        //検索アイテムをリストデータで保持
                        List<string> lstString = new List<string>();

                        //[0]受注No
                        lstString.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);
                        //[1]数量
                        lstString.Add(((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text);

                        //検索時のデータ取り出し先
                        DataTable dtSetView;

                        //ビジネス層のインスタンス生成
                        try
                        {
                            //ビジネス層、発注指示区分を取得する。
                            dtSetView = uriageinputB.getHacyusijiKbn(lstString, con);

                            if (dtSetView.Rows.Count > 0)
                            {
                                //仕入品のみ対象
                                if (dtSetView.Rows[0]["発注指示区分"].ToString() == "1")
                                {
                                    //赤伝は対象外
                                    if (decimal.Parse(((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text) > 0)
                                    {
                                        if (Math.Abs(decimal.Parse(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text)) <Math.Abs(decimal.Parse(((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text)))
                                        {
                                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "売上単価＜仕入単価の売上はできません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                            basemessagebox.ShowDialog();
                                            return false;
                                        }
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            
                            //エラーロギング
                            new CommonException(ex);
                        }
                    }
                }
                #endregion

                //売上日は最終仕入日以降 2008.4.1
                #region
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    //検索アイテムをリストデータで保持
                    List<string> lstString = new List<string>();

                    //[0]受注No
                    lstString.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);

                    //検索時のデータ取り出し先
                    DataTable dtSetView;

                    //ビジネス層のインスタンス生成
                    try
                    {
                        //ビジネス層、最終仕入先日を取得する。
                        dtSetView = uriageinputB.getSaisyuSiirebi(lstString, con);

                        if (dtSetView.Rows.Count > 0)
                        {
                            if (dtSetView.Rows[0]["最終仕入先日"].ToString() != "")
                            {
                                if (DateTime.Parse(txtYMD.Text) < DateTime.Parse(dtSetView.Rows[0]["最終仕入先日"].ToString()))
                                {
                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "売上日は仕入日以降で入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                    basemessagebox.ShowDialog();
                                    return false;
                                }
                            }

                        }
                            
                    }
                    catch (Exception ex)
                    {
                        
                        //エラーロギング
                        new CommonException(ex);
                    }
                }
                #endregion

                //2008.4.10 2008.4.11  仕入先が(7777)の場合は、得意先が(4125)(4116)(4129)に限る
                #region
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    //検索アイテムをリストデータで保持
                    List<string> lstString = new List<string>();

                    //[0]受注No
                    lstString.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);

                    //検索時のデータ取り出し先
                    DataTable dtSetView;

                    //ビジネス層のインスタンス生成
                    try
                    {
                        //ビジネス層、得意先コードを取得する。
                        dtSetView = uriageinputB.getTokuisakiCd(lstString, con);

                        if (dtSetView.Rows.Count > 0)
                        {
                            if (dtSetView.Rows[0]["得意先コード"].ToString() == "4125" ||
                               dtSetView.Rows[0]["得意先コード"].ToString() == "4116" ||
                               dtSetView.Rows[0]["得意先コード"].ToString() == "4129")
                            {
                                //何も処理を行わない。
                            }
                            else
                            {
                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "仕入先が(7777)の場合は、得意先は大同資材サービス(4125)(4116)(4129)に限ります。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                basemessagebox.ShowDialog();
                                return false;
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        
                        //エラーロギング
                        new CommonException(ex);
                    }
                }
                #endregion

                //加工品受注のチェック
                #region
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    //検索アイテムをリストデータで保持
                    List<string> lstString = new List<string>();

                    //[0]受注No
                    lstString.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);

                    //検索時のデータ取り出し先
                    DataTable dtSetView;

                    //ビジネス層のインスタンス生成
                    try
                    {
                        //ビジネス層、加工品区分が1の発注データをカウントする。
                        dtSetView = uriageinputB.getKakouHacyuCount(lstString, con);

                        if (dtSetView.Rows[0]["加工品発注カウント"].ToString() == "0")
                        {
                            Kakohin = false;
                        }
                        else
                        {
                            Kakohin = true;
                        } 

                    }
                    catch (Exception ex)
                    {
                        
                        //エラーロギング
                        new CommonException(ex);
                    }
                }
                #endregion

                //2014.4.25 商品別利益率チェック機能　追加
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    //商品別利益率チェックメソッドへ
                    SyohinbetuCheckFLG = SyohinbetuCheck(i);
                    if (SyohinbetuCheckFLG == 2 || SyohinbetuCheckFLG == 3)
                    {
                        SyohinbetuCheckFLGAll = SyohinbetuCheckFLG;
                        return false;
                    }

                    if (SyohinbetuCheckFLG != 0)
                    {
                        SyohinbetuCheckFLGAll = SyohinbetuCheckFLG;
                    }

                    DoituTanka[i] = SyohinbetuCheckFLG;
                }
            }

            //日付制限2006.01.31
            if (!GDateCheckEG(2, labelSet_Eigyosho.CodeTxtText, DateTime.Parse(txtYMD.Text)))
            {
                txtYMD.Focus();
                return false;
            }

            //在庫チェックは部長は除外。
            #region
            if (!"1".Equals(riekiritsuFlg))
            {
                //変数を初期化
                decimal sU = 0;
                string Basho;

                for (i = 1; i <= 5; i++)
                {
                    Control[] cs1 = this.Controls.Find("textSet_Jucyu" + i.ToString(), true);

                    bool zaikoKanri = false;

                    try
                    {
                        if (!string.IsNullOrWhiteSpace(((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text))
                        {
                            DataTable dtS = uriageinputB.getShohin(((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text, con);
                            if (dtS != null && dtS.Rows.Count > 0)
                            {
                                string s = dtS.Rows[0]["在庫管理区分"].ToString();
                                if ("0".Equals(s))
                                {
                                    zaikoKanri = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        new CommonException(ex);
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return false;
                    }


                    //商品コードが入力されているか
                    //if (((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text != "")
                    if (zaikoKanri)
                    {
                        //倉庫番後をBashoに格納
                        Basho = ((TextSet_Jucyu)cs1[0]).labelSet_SoukoNoElem10.CodeTxtText;

                        //商品コードが88888かどうか
                        if (((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text != "88888")
                        {
                            //大分類コードが雑費かどうか
                            if (((TextSet_Jucyu)cs1[0]).txtElem13.Text != "28")
                            {
                                //数量が0以上かどうか
                                if (decimal.Parse(((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text) > 0)
                                {
                                    //指定日の在庫数を得るメソッドへ
                                    if (Get_ZaikoSu2(((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text, Basho, ref sU, DateTime.Parse(txtYMD.Text), con))
                                    {
                                        if (sU < decimal.Parse(((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text))
                                        {
                                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "出庫数が在庫数を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                            basemessagebox.ShowDialog();
                                            return false;
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            //代納にチェックされている場合は直送先コードが入力されているか判断。
            if (radSyubetu.judCheckBtn() == 1)
            {
                if (txtCyoku.Text == "")
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "代納先（直送先）を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
            }

            //行単位の利益率チェック
            #region
            for (i = 1; i <= 5; i++)
            {
                Control[] cs1 = this.Controls.Find("textSet_Jucyu" + i.ToString(), true);

                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    if (DoituTanka[i] != 9)
                    {
                        ((TextSet_Jucyu)cs1[0]).txtTankaElem5.ForeColor = Color.Black;

                        //変数を初期化
                        bool akakuroCheck;
                        akakuroCheck = true;
                        double Ritu;

                        decimal GokeiKingaku;
                        GokeiKingaku = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text);

                        Kakohin = false;

                        if (Kakohin)
                        {
                            if (GokeiKingaku <= 2000)
                            {
                                Ritu = 0.5;
                                RituMSG = "利益率が５０％を割っています。（販売価格2000以下）";
                                //BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                //basemessagebox.ShowDialog();
                            }
                            else
                            {
                                Ritu = 7.5;
                                RituMSG = "利益率が２５％を割っています。";
                                //BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                //basemessagebox.ShowDialog();
                            }
                        }
                        else
                        {
                            Ritu = 0.85;
                            RituMSG = "利益率が１５％を割っています。";
                            //BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            //basemessagebox.ShowDialog();
                        }

                        //利益率のガード　売値＞＝仕入値÷０．９
                        //赤伝は除外
                        //部長の場合は処理をSKIP
                        if (!"1".Equals(riekiritsuFlg))
                        {
                            //メソッドRieki10へ
                            if (Rieki10(con))
                            {


                                decimal decShiire = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text);

                                try
                                {
                                    DataTable dtShohin = uriageinputB.getShohin(((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text, con);
                                    //decimal decBaika = 0;

                                    if (dtShohin != null && dtShohin.Rows.Count > 0)
                                    {
                                        //if (dtShohin.Rows[0]["標準売価"] != null)
                                        //{
                                        //    decBaika = decimal.Round(getDecValue(dtShohin.Rows[0]["標準売価"].ToString()), 2, MidpointRounding.AwayFromZero);
                                        //}

                                        if (dtShohin.Rows[0]["仕入単価"] != null)
                                        {
                                            decShiire = decimal.Round(decimal.Parse(dtShohin.Rows[0]["仕入単価"].ToString()), 2, MidpointRounding.AwayFromZero);
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    new CommonException(ex);
                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                    basemessagebox.ShowDialog();
                                    return false;
                                }




                                //単価が(原価÷率)より小さい場合
                                if (Math.Abs(decimal.Parse(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text)) < Math.Abs(decShiire / decimal.Parse(Ritu.ToString())))
                                {
                                    ((TextSet_Jucyu)cs1[0]).txtTankaElem5.ForeColor = Color.Red;
                                    reGood = false;
                                }
                                else
                                {
                                    akakuroCheck = false; //１０％以上ある
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            //利益率チェック結果
            if (!reGood)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Rieki10
        /// 利益のチェックを行う。
        /// </summary>
        private Boolean Rieki10(DBConnective con)
        {
            int i;
            int icnt;

            bool reRieki10;
            reRieki10 = true;

            icnt = 0;

            for (i = 1; i < 5; i++)
            {
                Control[] cs1 = this.Controls.Find("textSet_Jucyu" + i.ToString(), true);
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    icnt += 1;
                }
            }

            //複数行は対象外
            if (icnt > 1)
            {
                return reRieki10;
            }

            for (i = 1; i < 5; i++)
            {
                Control[] cs1 = this.Controls.Find("textSet_Jucyu" + i.ToString(), true);
                //2008.4.24  仕入先が返品値引口座(9999)の場合は、返品値引分売上承認入力で承認済みに限り売上可。利益率ガードなし。
                if (((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text != "")
                {
                    //検索アイテムをリストデータで保持
                    List<string> lstString = new List<string>();

                    //[0]受注No
                    lstString.Add(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text);

                    //検索時のデータ取り出し先
                    DataTable dtSetView;

                    //ビジネス層のインスタンス生成
                    A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
                    try
                    {
                        //ビジネス層、受注数量が0未満の受発注データをカウントする。
                        dtSetView = uriageinputB.getJucyuSuryositeiJuhacyuCount(lstString, con);

                        if (decimal.Parse(dtSetView.Rows[0]["受注数量0未満受発注カウント"].ToString()) > 0)
                        {
                            //ビジネス層、返品値引売上承認フラグ
                            dtSetView = uriageinputB.getHenpinNebikiUriageSyoninFlg(lstString, con);

                            if (dtSetView.Rows[0]["返品値引売上承認フラグ"].ToString() =="1")
                            {
                                reRieki10 = false;
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        
                        //エラーロギング
                        new CommonException(ex);
                    }

                    break;
                }
            }

            return reRieki10;
        }

        /// <summary>
        /// Get_ZaikoSu2
        /// 指定日の在庫数を得る。
        /// </summary>
        private Boolean Get_ZaikoSu2(string SyouhinCD, string Eigyousyo,ref decimal sU, DateTime yymd, DBConnective con)
        {
            string strSQL;
            bool reGet_ZaikoSu2 = true;

            if (SyouhinCD == "" || Eigyousyo == "" )
            {
                sU = 0;
            }

            //検索アイテムをリストデータで保持
            List<string> lstString = new List<string>();

            //[0]営業所コード
            lstString.Add(Eigyousyo);
            //[1]商品コード
            lstString.Add(SyouhinCD);
            //[2]日付
            lstString.Add(yymd.ToString());

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                //ビジネス層、指定日の在庫数を取得する。
                dtSetView = uriageinputB.getzaikosuu(lstString, con);

                if (dtSetView.Rows.Count == 0)
                {
                    reGet_ZaikoSu2 = false;
                }
                else
                {
                    sU = decimal.Parse(dtSetView.Rows[0]["指定日の在庫数"].ToString());
                }

                return reGet_ZaikoSu2;
            }
            catch (Exception ex)
            {
                
                //エラーロギング
                new CommonException(ex);
                return reGet_ZaikoSu2;
            }

        }

        /// <summary>
        /// Get_ZaikoSu2
        /// 商品別利益率チェック機能。
        /// </summary>
        private int SyohinbetuCheck(int i)
        {
            Control[] cs1 = this.Controls.Find("textSet_Jucyu" + i.ToString(), true);

            //変数を初期化
            decimal Ritu;
            string RituMSG;
            Boolean SetteiAri;
            SetteiAri = false;
            int getSyohinbetuCheck = 0 ;    //戻り値 

            //部長の場合はPASS
            if ("1".Equals(riekiritsuFlg))
            {
                getSyohinbetuCheck = 1;
                return getSyohinbetuCheck;
            }

            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                // 利益率承認が下りている場合、利益率チェックは無視
                if (uriageinputB.getRiekiAccept(((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text) != 0)
                {
                    getSyohinbetuCheck = 9;
                    return getSyohinbetuCheck;
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                throw;
            }
            getSyohinbetuCheck = 0;

            //商品コードが空欄の場合は０を返す。
            if (((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text == "")
            {
                return getSyohinbetuCheck;
            }

            //率　=　(単価 - 原価) / 単価 * 100
            Ritu = Math.Abs(decimal.Parse(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text))
                - decimal.Parse(PutIsNull(((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text, "0"))
                / Math.Abs(decimal.Parse(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text))
                * 100;


            //商品別

            //検索アイテムをリストデータで保持
            List<string> lstString = new List<string>();

            //[0]得意先コード
            lstString.Add(labelSet_txtCD.CodeTxtText);
            //[1]商品コード
            lstString.Add(((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text);

            //検索時のデータ取り出し先
            DataTable dtSetView;

            try
            {
                //ビジネス層、商品別利益率を設定する。
                dtSetView = uriageinputB.getSyohinbeturiekiritu(lstString);

                if (dtSetView.Rows.Count > 0)
                {
                    SetteiAri = true;
                    getSyohinbetuCheck = 1;

                    if (dtSetView.Rows[0]["単価"].ToString() != "")
                    {
                        //if (((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text == dtSetView.Rows[0]["単価"].ToString())
                        //{
                        //    getSyohinbetuCheck = 9; //単価同一でパス     2016.3.11
                        //}
                        decimal d1 = 0;
                        decimal d2 = decimal.Parse(dtSetView.Rows[0]["単価"].ToString());
                        if (!string.IsNullOrWhiteSpace(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text))
                        {
                            d1 = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text);
                        }
                        if (d1.Equals(d2))
                        {
                            getSyohinbetuCheck = 9; //単価同一でパス
                        }
                    }

                    //単価同一だった場合は処理をパスする。
                    if (getSyohinbetuCheck != 9)
                    {
                        if (dtSetView.Rows[0]["単価"].ToString() != "")
                        {
                            if (decimal.Parse(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text) < decimal.Parse(dtSetView.Rows[0]["単価"].ToString()))
                            {
                                RituMSG = "設定単価を下回っています。 \r\n (設定単価=" + dtSetView.Rows[0]["単価"].ToString() + "円)";

                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                basemessagebox.ShowDialog();
                                getSyohinbetuCheck = 2;
                            }
                        }

                        if (dtSetView.Rows[0]["利益率"].ToString() != "")
                        {
                            if (Ritu < decimal.Parse(dtSetView.Rows[0]["利益率"].ToString()))
                            {
                                RituMSG = "利益率を割っています。 \r\n (設定利益率=" + dtSetView.Rows[0]["利益率"].ToString() + "％)";

                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                basemessagebox.ShowDialog();
                                getSyohinbetuCheck = 2;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return 0;
            }

            if (SetteiAri == true)
            {
                return getSyohinbetuCheck;
            }

            //商品分類別

            //変数を初期化
            string sDaiBunrui;
            string sCyuBunrui;
            string sMaker;
            
            try
            {
                //ビジネス層、大・中分類・メーカコードを取得する。
                dtSetView = uriageinputB.getBunruiMaker(lstString);

                if (dtSetView.Rows.Count == 0)
                {
                    return getSyohinbetuCheck;
                }
                else
                {
                    sDaiBunrui = dtSetView.Rows[0]["大分類コード"].ToString();
                    sCyuBunrui = dtSetView.Rows[0]["中分類コード"].ToString();
                    sMaker = dtSetView.Rows[0]["メーカーコード"].ToString();
                }

                //[2]大分類コード
                lstString.Add(sDaiBunrui);
                //[3]中分類コード
                lstString.Add(sCyuBunrui);
                //[4]メーカーコード
                lstString.Add(sMaker);

                //大中メーカー

                //ビジネス層、商品分類別利益率を取得する。（大分類・中分類・メーカーを使用）
                dtSetView = uriageinputB.getSyohinbunruiriekiritu3items(lstString);

                if (dtSetView.Rows.Count > 0)
                {
                    SetteiAri = true;
                    getSyohinbetuCheck = 1;
                    
                    if (dtSetView.Rows[0]["利益率"].ToString() != "")
                    {
                        if (Ritu < decimal.Parse(dtSetView.Rows[0]["利益率"].ToString()))
                        {
                            RituMSG = "利益率を割っています。 \r\n (設定利益率=" + dtSetView.Rows[0]["利益率"].ToString() + "％)";

                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            getSyohinbetuCheck = 2;
                        }
                    }

                    if (dtSetView.Rows[0]["掛率"].ToString() != "")
                    {
                        if (decimal.Parse(((TextSet_Jucyu)cs1[0]).txtJucyuRitu.Text) < decimal.Parse(dtSetView.Rows[0]["掛率"].ToString()))
                        {
                            RituMSG = "設定掛率を下回っています。 \r\n (設定掛率=" + dtSetView.Rows[0]["掛率"].ToString() + "％)";

                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            getSyohinbetuCheck = 2;
                        }
                    }
                }

                if (SetteiAri == true)
                {
                    return getSyohinbetuCheck;
                }

                //大中

                //ビジネス層、商品分類別利益率を取得する。（大分類・中分類を使用）
                dtSetView = uriageinputB.getSyohinbunruiriekirituDaiCyu(lstString);

                if (dtSetView.Rows.Count > 0)
                {
                    SetteiAri = true;
                    getSyohinbetuCheck = 1;

                    if (dtSetView.Rows[0]["利益率"].ToString() != "")
                    {
                        if (Ritu < decimal.Parse(dtSetView.Rows[0]["利益率"].ToString()))
                        {
                            RituMSG = "利益率を割っています。 \r\n (設定利益率=" + dtSetView.Rows[0]["利益率"].ToString() + "％)";

                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            getSyohinbetuCheck = 2;
                        }
                    }

                    if (dtSetView.Rows[0]["掛率"].ToString() != "")
                    {
                        if (decimal.Parse(((TextSet_Jucyu)cs1[0]).txtJucyuRitu.Text) < decimal.Parse(dtSetView.Rows[0]["掛率"].ToString()))
                        {
                            RituMSG = "設定掛率を下回っています。 \r\n (設定掛率=" + dtSetView.Rows[0]["掛率"].ToString() + "％)";

                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            getSyohinbetuCheck = 2;
                        }
                    }
                }

                if (SetteiAri == true)
                {
                    return getSyohinbetuCheck;
                }

                //大メーカー

                //ビジネス層、商品分類別利益率を取得する。（大分類・メーカコードを使用）
                dtSetView = uriageinputB.getSyohinbunruiriekirituDaiMaker(lstString);

                if (dtSetView.Rows.Count > 0)
                {
                    SetteiAri = true;
                    getSyohinbetuCheck = 1;

                    if (dtSetView.Rows[0]["利益率"].ToString() != "")
                    {
                        if (Ritu < decimal.Parse(dtSetView.Rows[0]["利益率"].ToString()))
                        {
                            RituMSG = "利益率を割っています。 \r\n (設定利益率=" + dtSetView.Rows[0]["利益率"].ToString() + "％)";

                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            getSyohinbetuCheck = 2;
                        }
                    }

                    if (dtSetView.Rows[0]["掛率"].ToString() != "")
                    {
                        if (decimal.Parse(((TextSet_Jucyu)cs1[0]).txtJucyuRitu.Text) < decimal.Parse(dtSetView.Rows[0]["掛率"].ToString()))
                        {
                            RituMSG = "設定掛率を下回っています。 \r\n (設定掛率=" + dtSetView.Rows[0]["掛率"].ToString() + "％)";

                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, RituMSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            getSyohinbetuCheck = 2;
                        }
                    }
                }

                return getSyohinbetuCheck;
            }
            catch (Exception ex)
            {
                
                //エラーロギング
                new CommonException(ex);
                return 0;
            }

        }

        /// <summary>
        /// Data_Create
        /// 処理済の更新＆倉庫間移動データの追加。
        /// </summary>
        private void Data_Create(string JucyuNo, DBConnective con)
        {
            //変数を初期化する。
            string IdouMoto;
            string IdouSaki;
            decimal sU;
            decimal Tanka;
            string Eigyousyo;
            bool IdoAri;

            //検索アイテムをリストデータで保持
            List<string> lstString = new List<string>();

            //[0]受注No
            lstString.Add(JucyuNo);

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                //ビジネス層、営業所コードを取得する。(DC = Data_Create )
                dtSetView = uriageinputB.DC_getEigyosyoCd(lstString);

                //営業所コードが存在しない場合は処理を終了。
                if (dtSetView.Rows.Count == 0)
                {
                    return;
                }
                else
                {
                    Eigyousyo = dtSetView.Rows[0]["営業所コード"].ToString();
                }

                IdoAri = false;

                //[1]営業所
                lstString.Add(Eigyousyo);

                //ビジネス層、受注番号、営業所コードから受注データを取得(DC = Data_Create )
                dtSetView = uriageinputB.DC_getJucyu(lstString);

                //該当する受注データがある場合はIdoAriフラグをtrueにする。
                if (dtSetView.Rows.Count > 0)
                {
                    IdoAri = true;
                }

                //取得した受注データを全行処理
                foreach (DataRow datarow in dtSetView.Rows)
                {
                    if (decimal.Parse(datarow["本社出庫数"].ToString()) > 0)     //本社⇒岐阜
                    {
                        IdouMoto = "0001";
                        IdouSaki = "0002";

                        sU = decimal.Parse(datarow["本社出庫数"].ToString());
                    }
                    else　                                                       //岐阜⇒本社
                    {
                        IdouMoto = "0002";
                        IdouSaki = "0001";

                        sU = decimal.Parse(datarow["岐阜出庫数"].ToString());
                    }

                    Tanka = decimal.Parse(datarow["仕入単価"].ToString());

                    //出庫データ作成用にアイテムリストを作成
                    List<string> SyukkoyouItem = new List<string>();
                    SyukkoyouItem.Add(txtYMD.Text);
                    SyukkoyouItem.Add(datarow["受注番号"].ToString());
                    SyukkoyouItem.Add("1");
                    SyukkoyouItem.Add(IdouMoto);
                    SyukkoyouItem.Add("51");
                    SyukkoyouItem.Add(datarow["受注者コード"].ToString());
                    SyukkoyouItem.Add(datarow["営業所コード"].ToString());
                    SyukkoyouItem.Add(datarow["商品コード"].ToString());
                    SyukkoyouItem.Add(datarow["メーカーコード"].ToString());
                    SyukkoyouItem.Add(datarow["大分類コード"].ToString());
                    SyukkoyouItem.Add(datarow["中分類コード"].ToString());
                    SyukkoyouItem.Add(datarow["Ｃ１"].ToString());
                    SyukkoyouItem.Add(datarow["Ｃ２"].ToString());
                    SyukkoyouItem.Add(datarow["Ｃ３"].ToString());
                    SyukkoyouItem.Add(datarow["Ｃ４"].ToString());
                    SyukkoyouItem.Add(datarow["Ｃ５"].ToString());
                    SyukkoyouItem.Add(datarow["Ｃ６"].ToString());
                    SyukkoyouItem.Add(sU.ToString());
                    SyukkoyouItem.Add(Tanka.ToString());
                    SyukkoyouItem.Add(IdouSaki);
                    SyukkoyouItem.Add(Environment.UserName);

                    //入庫データ作成用にアイテムリストを作成
                    List<string> NyuukoyouItem = new List<string>();
                    NyuukoyouItem.Add(txtYMD.Text);
                    NyuukoyouItem.Add(datarow["受注番号"].ToString());
                    NyuukoyouItem.Add("1");
                    NyuukoyouItem.Add(IdouSaki);
                    NyuukoyouItem.Add("52");
                    NyuukoyouItem.Add(datarow["受注者コード"].ToString());
                    NyuukoyouItem.Add(datarow["営業所コード"].ToString());
                    NyuukoyouItem.Add(datarow["商品コード"].ToString());
                    NyuukoyouItem.Add(datarow["メーカーコード"].ToString());
                    NyuukoyouItem.Add(datarow["大分類コード"].ToString());
                    NyuukoyouItem.Add(datarow["中分類コード"].ToString());
                    NyuukoyouItem.Add(datarow["Ｃ１"].ToString());
                    NyuukoyouItem.Add(datarow["Ｃ２"].ToString());
                    NyuukoyouItem.Add(datarow["Ｃ３"].ToString());
                    NyuukoyouItem.Add(datarow["Ｃ４"].ToString());
                    NyuukoyouItem.Add(datarow["Ｃ５"].ToString());
                    NyuukoyouItem.Add(datarow["Ｃ６"].ToString());
                    NyuukoyouItem.Add(sU.ToString());
                    NyuukoyouItem.Add(Tanka.ToString());
                    NyuukoyouItem.Add(IdouMoto);
                    NyuukoyouItem.Add(Environment.UserName);

                    //ビジネス層、出庫データと入庫データを作成する。(DC = Data_Create )
                    uriageinputB.DC_Syukko_Nyuuko(SyukkoyouItem, NyuukoyouItem, con);

                }

                if (IdoAri == true)
                {
                    //ビジネス層、倉庫間移動データ作成済セット(DC = Data_Create )
                    uriageinputB.DC_updHikiateflg(lstString, con);
                }

                return;
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                throw ex;
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            //削除するデータ以外を確保
            string tmpYMD = txtYMD.Text;
            string tmpTantosyaCd = labelSet_Tantousha.CodeTxtText;
            string tmpTrihikiKbn = labelSet_Torihikikbn.CodeTxtText;
            string tmpEigyosyoCd = labelSet_Eigyosho.CodeTxtText;
                
            //画面の項目内を白紙にする
            delFormClear(this,null);

            txtYMD.Text = tmpYMD;
            labelSet_Tantousha.CodeTxtText = tmpTantosyaCd;
            labelSet_Torihikikbn.CodeTxtText = tmpTrihikiKbn;
            labelSet_Eigyosho.CodeTxtText = tmpEigyosyoCd;

            //コントロール制限を解除
            labelSet_txtCD.Enabled = true;
            textSet_Jucyu1.txtSinaBanElem3.ReadOnly = false;
            textSet_Jucyu1.txtGenkaElem7.ReadOnly = false;
            textSet_Jucyu2.txtSinaBanElem3.ReadOnly = false;
            textSet_Jucyu2.txtGenkaElem7.ReadOnly = false;
            textSet_Jucyu3.txtSinaBanElem3.ReadOnly = false;
            textSet_Jucyu3.txtGenkaElem7.ReadOnly = false;
            textSet_Jucyu4.txtSinaBanElem3.ReadOnly = false;
            textSet_Jucyu4.txtGenkaElem7.ReadOnly = false;
            textSet_Jucyu5.txtSinaBanElem3.ReadOnly = false;
            textSet_Jucyu5.txtGenkaElem7.ReadOnly = false;

            btnF01.Enabled = true;
            btnF03.Enabled = true;
            btnF07.Enabled = true;

            textSet_Jucyu1.readOnly = false;
            textSet_Jucyu2.readOnly = false;
            textSet_Jucyu3.readOnly = false;
            textSet_Jucyu4.readOnly = false;
            textSet_Jucyu5.readOnly = false;
            noEditable = false;

            OneLineClear();
            editFlg = false;

            txtYMD.Focus();

            txtDenNo.Enabled = true;
        }

        /// <summary>
        /// getCurrentRow
        /// 選択行（1～5)番号を取得する。
        /// </summary>
        public void getCurrentRow(object sender, EventArgs e)
        {
            String str = "";

            // このフォームで現在アクティブなコントロールを取得する
            Control cControl = this.ActiveControl;

            // 取得できた場合、名前の右から一文字をCurrentRowに設定する（選択行）
            if (cControl != null)
            {
                str = cControl.Name;
                //末尾から1文字切り取り
                str = str.Substring(str.Length - 1, 1);
                //切り取った文字列が数字でなければ99を設定
                if (!int.TryParse(str, out CurrentRow))
                {
                    CurrentRow = 99;
                }
                //数字が1～5の間でない場合、99を設定
                if (CurrentRow < 1 && CurrentRow > 5)
                {
                    CurrentRow = 99;
                }
            }
        }

        /// <summary>
        /// delCurrentRow
        /// 選択行（1～5）を削除し、値を再設定する。
        /// また合計も再計算する。
        /// </summary>
        private void delCurrentRow()
        {

            //数字が1～5の間でない場合、処理終了
            if (CurrentRow < 1 || CurrentRow > 5)
            {
                return;
            }

            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show("選択行（" + (CurrentRow).ToString() + "行目）を削除します。\r\nよろしいですか。",
                "質問",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.No)
            {
                //「いいえ」が選択された場合は処理終了
                return;
            }

            //選択行から最終行-1（4行）まで1つずつ値を上に並び変える。
            for (int i = CurrentRow; i <= 4; i++)
            {
                Control[] cs1 = this.Controls.Find("textSet_Jucyu" + i.ToString(), true);
                Control[] cs2 = this.Controls.Find("textSet_Jucyu" + (i + 1).ToString(), true);
                
                ((TextSet_Jucyu)cs1[0]).txtNoElem1.Text = ((TextSet_Jucyu)cs2[0]).txtNoElem1.Text;
                ((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text = ((TextSet_Jucyu)cs2[0]).txtJucyuNoElem2.Text;
                ((TextSet_Jucyu)cs1[0]).txtSinaBanElem3.Text = ((TextSet_Jucyu)cs2[0]).txtSinaBanElem3.Text;
                ((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text = ((TextSet_Jucyu)cs2[0]).txtSuuryoElem4.Text;
                ((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text = ((TextSet_Jucyu)cs2[0]).txtTankaElem5.Text;
                ((TextSet_Jucyu)cs1[0]).txtKingakuElem6.Text = ((TextSet_Jucyu)cs2[0]).txtKingakuElem6.Text;
                ((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text = ((TextSet_Jucyu)cs2[0]).txtGenkaElem7.Text;
                ((TextSet_Jucyu)cs1[0]).txtArariElem8.Text = ((TextSet_Jucyu)cs2[0]).txtArariElem8.Text;
                ((TextSet_Jucyu)cs1[0]).txtBikouElem9.Text = ((TextSet_Jucyu)cs2[0]).txtBikouElem9.Text;
                ((TextSet_Jucyu)cs1[0]).labelSet_SoukoNoElem10.CodeTxtText = ((TextSet_Jucyu)cs2[0]).labelSet_SoukoNoElem10.CodeTxtText;
                ((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text = ((TextSet_Jucyu)cs2[0]).txtSyohinCdElem11.Text;
                ((TextSet_Jucyu)cs1[0]).txtElem12.Text = ((TextSet_Jucyu)cs2[0]).txtElem12.Text;
                ((TextSet_Jucyu)cs1[0]).txtElem13.Text = ((TextSet_Jucyu)cs2[0]).txtElem13.Text;
                ((TextSet_Jucyu)cs1[0]).txtElem14.Text = ((TextSet_Jucyu)cs2[0]).txtElem14.Text;
                ((TextSet_Jucyu)cs1[0]).txtElem15.Text = ((TextSet_Jucyu)cs2[0]).txtElem15.Text;
                ((TextSet_Jucyu)cs1[0]).txtElem16.Text = ((TextSet_Jucyu)cs2[0]).txtElem16.Text;
                ((TextSet_Jucyu)cs1[0]).txtElem17.Text = ((TextSet_Jucyu)cs2[0]).txtElem17.Text;
                ((TextSet_Jucyu)cs1[0]).txtElem18.Text = ((TextSet_Jucyu)cs2[0]).txtElem18.Text;
                ((TextSet_Jucyu)cs1[0]).txtElem19.Text = ((TextSet_Jucyu)cs2[0]).txtElem19.Text;
                ((TextSet_Jucyu)cs1[0]).txtElem20.Text = ((TextSet_Jucyu)cs2[0]).txtElem20.Text;
                ((TextSet_Jucyu)cs1[0]).txtTeika.Text = ((TextSet_Jucyu)cs2[0]).txtTeika.Text;
                ((TextSet_Jucyu)cs1[0]).txtJucyuRitu.Text = ((TextSet_Jucyu)cs2[0]).txtJucyuRitu.Text;
                ((TextSet_Jucyu)cs1[0]).txtSiireRitu.Text = ((TextSet_Jucyu)cs2[0]).txtSiireRitu.Text;
                ((TextSet_Jucyu)cs1[0]).txtCyokkinSiire.Text = ((TextSet_Jucyu)cs2[0]).txtCyokkinSiire.Text;
                ((TextSet_Jucyu)cs1[0]).txtCyokkinSiireRitu.Text = ((TextSet_Jucyu)cs2[0]).txtCyokkinSiireRitu.Text;
                ((TextSet_Jucyu)cs1[0]).txtCyokkinSiireRituA.Text = ((TextSet_Jucyu)cs2[0]).txtCyokkinSiireRituA.Text;
                ((TextSet_Jucyu)cs1[0]).txtMasterSiire.Text = ((TextSet_Jucyu)cs2[0]).txtMasterSiire.Text;
                ((TextSet_Jucyu)cs1[0]).txtMasterSiireRitu.Text = ((TextSet_Jucyu)cs2[0]).txtMasterSiireRitu.Text;
                ((TextSet_Jucyu)cs1[0]).txtMasterSiireRituA.Text = ((TextSet_Jucyu)cs2[0]).txtMasterSiireRituA.Text;
                ((TextSet_Jucyu)cs1[0]).txtRitsuElem21.Text = ((TextSet_Jucyu)cs2[0]).txtRitsuElem21.Text;
                ((TextSet_Jucyu)cs1[0]).txtElem22.Text = ((TextSet_Jucyu)cs2[0]).txtElem22.Text;


            }
            
            //一番下の行の内容をクリア
            textSet_Jucyu5.txtNoElem1.Text = "";
            textSet_Jucyu5.txtJucyuNoElem2.Text = "";
            textSet_Jucyu5.txtSinaBanElem3.Text = "";
            textSet_Jucyu5.txtSuuryoElem4.Text = "";
            textSet_Jucyu5.txtTankaElem5.Text = "";
            textSet_Jucyu5.txtKingakuElem6.Text = "";
            textSet_Jucyu5.txtGenkaElem7.Text = "";
            textSet_Jucyu5.txtArariElem8.Text = "";
            textSet_Jucyu5.txtBikouElem9.Text = "";
            textSet_Jucyu5.labelSet_SoukoNoElem10.CodeTxtText = "";
            textSet_Jucyu5.labelSet_SoukoNoElem10.ValueLabelText = "";
            textSet_Jucyu5.txtSyohinCdElem11.Text = "";
            textSet_Jucyu5.txtElem12.Text = "";
            textSet_Jucyu5.txtElem13.Text = "";
            textSet_Jucyu5.txtElem14.Text = "";
            textSet_Jucyu5.txtElem15.Text = "";
            textSet_Jucyu5.txtElem16.Text = "";
            textSet_Jucyu5.txtElem17.Text = "";
            textSet_Jucyu5.txtElem18.Text = "";
            textSet_Jucyu5.txtElem19.Text = "";
            textSet_Jucyu5.txtElem20.Text = "";
            textSet_Jucyu5.txtRitsuElem21.Text = "";
            textSet_Jucyu5.txtElem22.Text = "";

            textSet_Jucyu5.txtTeika.Text = "";
            textSet_Jucyu5.txtJucyuRitu.Text = "";
            textSet_Jucyu5.txtSiireRitu.Text = "";
            textSet_Jucyu5.txtCyokkinSiire.Text = "";
            textSet_Jucyu5.txtCyokkinSiireRitu.Text = "";
            textSet_Jucyu5.txtCyokkinSiireRituA.Text = "";
            textSet_Jucyu5.txtMasterSiire.Text = "";
            textSet_Jucyu5.txtMasterSiireRitu.Text = "";
            textSet_Jucyu5.txtMasterSiireRituA.Text = "";

            textSet_Jucyu5.oldNo = "";
            textSet_Jucyu5.oldSuryo = "";
            textSet_Jucyu5.oldTanka = "";
            textSet_Jucyu5.oldKin = "";
            textSet_Jucyu5.oldGenka = "";
            textSet_Jucyu5.oldTeika = "";
            textSet_Jucyu5.oldArari = "";
            textSet_Jucyu5.oldSouko = "";
            textSet_Jucyu5.oldBiko = "";

            //合計計算メソッドへ
            textSet_Jucyu1.GokeiKeisan();

        }


        /// <summary>
        /// txtDenNo_KeyDown
        /// 伝票No用キー入力判定
        /// </summary>
        private void txtDenNo_KeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    //次伝票番号取得メソッドへ
                    txtDenNo.Text = GetNextDenpyoNumber(txtDenNo.Text);
                    if (txtDenNo.Text != "")
                    {
                        SendKeys.Send("{TAB}");
                        txtYMD.Focus();
                    }
                    break;
                case Keys.PageDown:
                    //前伝票番号取得メソッドへ
                    txtDenNo.Text = GetPrevDenpyoNumber(txtDenNo.Text);
                    if (txtDenNo.Text != "")
                    {
                        SendKeys.Send("{TAB}");
                        txtYMD.Focus();
                    }
                    break;
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    txtYMD.Focus();
                    break;
                case Keys.F9:
                    //売上リストを開く
                    this.setUriageList();

                    if (!string.IsNullOrWhiteSpace(txtDenNo.Text))
                    {
                        //DispDenpyo();
                        //SendKeys.Send("{TAB}");
                        if (string.IsNullOrWhiteSpace(txtYubin_C.Text)) {
                            txtYMD.Focus();
                        }
                        else {
                            txtYubin_C.Focus();
                        }
                    }

                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// GetNextDenpyoNumber
        /// 売上伝票において、指定した次の伝票番号を得る。
        /// </summary>
        private string GetNextDenpyoNumber(string DenpyoNo)
        {
            //伝票番号が空白の場合はNULLを返す。
            if (DenpyoNo == "")
            {
                return null;
            }

            //検索時のデータ取り出し先
            DataTable dtSetView;

            List<string> lstNextDenpyoLoad = new List<string>();
            //データの存在確認を検索する情報を入れる
            /*[0]伝票番号*/
            lstNextDenpyoLoad.Add(DenpyoNo);
            
            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                //ビジネス層、次伝票を取得する。
                dtSetView = uriageinputB.GetNextDenpyo(lstNextDenpyoLoad);
                
                //次伝票番号が存在した場合、その値を返す。
                if (dtSetView.Rows.Count > 0)
                {
                    if (dtSetView.Rows[0]["次伝票番号"].ToString() != "")
                    {
                        return dtSetView.Rows[0]["次伝票番号"].ToString();
                    }
                }

                //次伝票番号が0以下の場合は1を返す。
                if (decimal.Parse(dtSetView.Rows[0]["次伝票番号"].ToString()) <= 0)
                {
                    return "1";
                }

                return null;
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return null;
            }
        }

        /// <summary>
        /// GetPrevDenpyoNumber
        /// 売上伝票において、指定した前の伝票番号を得る。
        /// </summary>
        private string GetPrevDenpyoNumber(string DenpyoNo)
        {
            //検索時のデータ取り出し先
            DataTable dtSetView;
            
            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                //伝票番号が空白かどうか
                if (DenpyoNo == "")
                {
                    //ビジネス層、前伝票を取得する。(引数はデフォルト値を使用)
                    dtSetView = uriageinputB.GetPrevDenpyo();
                }
                else
                {
                    //ビジネス層、前伝票を取得する。(引数はDenpyoNoを使用)
                    dtSetView = uriageinputB.GetPrevDenpyo(DenpyoNo);
                }

                //前伝票番号が存在した場合、その値を返す。
                if (dtSetView.Rows.Count > 0)
                {
                    if (dtSetView.Rows[0]["前伝票番号"].ToString() != "")
                    {
                        return dtSetView.Rows[0]["前伝票番号"].ToString();
                    }
                }

                //前伝票番号が0以下の場合は1を返す。
                if (decimal.Parse(dtSetView.Rows[0]["前伝票番号"].ToString()) <= 0)
                {
                    return "1";
                }

                return null;
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return null;
            }
        }

        ///<summary>
        ///setUriageList
        ///売上リストに移動
        ///</summary>
        private void setUriageList()
        {
            UriageList uriagelist = new UriageList(this);
            try
            {
                //売上リストの表示、画面IDを渡す
                uriagelist.intFrmKind = CommonTeisu.FRM_URIAGEINPUT;
                uriagelist.ShowDialog();
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
        /// setDenpyo_Uriage
        /// 伝票番号を取得
        /// </summary>
        public void setDenpyo_Uriage(string DenpyoNo)
        {
            txtDenNo.Text = DenpyoNo;
        }

        ///<summary>
        ///setUriageListClose
        ///setUriageListCloseが閉じたら伝票Noにフォーカス
        ///</summary>
        public void setUriageListClose()
        {
            txtDenNo.Focus();
        }



        /// <summary>
        /// txtCyoku_KeyDown
        /// 直送先CD用キー入力判定
        /// </summary>
        private void txtCyoku_KeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.F9:
                    //得意先コードがある場合は、直送先リストを表示する。
                    if (labelSet_txtCD.CodeTxtText != "")
                    {
                        this.setCyokuList();
                    }
                    break;
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
                default:
                    break;
            }
        }


        ///<summary>
        ///setCyokuList
        ///直送先リストに移動
        ///</summary>
        private void setCyokuList()
        {
            ChokusosakiList chokusousakilist = new ChokusosakiList(this,labelSet_txtCD.CodeTxtText);
            try
            {
                //直送先リストの表示、画面IDを渡す
                chokusousakilist.intFrmKind = CommonTeisu.FRM_URIAGEINPUT;
                chokusousakilist.ShowDialog();
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
        /// setDenpyo_Uriage
        /// 直送先リストをテキストボックスに設定
        /// </summary>
        public void setChokusoCode(DataTable Cyokusousakilist)
        {
            txtCyoku.Text = Cyokusousakilist.Rows[0]["直送先コード"].ToString();
            txtYubin_C.Text = Cyokusousakilist.Rows[0]["郵便番号"].ToString();
            txtAdr1_C.Text = Cyokusousakilist.Rows[0]["住所１"].ToString();
            txtAdr2_C.Text = Cyokusousakilist.Rows[0]["住所２"].ToString();
            txtName_C.Text = Cyokusousakilist.Rows[0]["直送先名"].ToString();
            txtBusyo_C.Text = Cyokusousakilist.Rows[0]["部署名"].ToString();
            txtTelNo_C.Text = Cyokusousakilist.Rows[0]["電話番号"].ToString();
        }

        /// <summary>
        /// setUriageListClose
        /// setUriageListCloseが閉じたら伝票Noにフォーカス
        /// </summary>
        public void setChokuListClose()
        {
            txtCyoku.Focus();
        }

        /// <summary>
        /// txtCyoku_Leave
        /// 直送先リストのフォーカスが外れた場合
        /// </summary>
        private void txtCyoku_Leave(object sender, EventArgs e)
        {
            //直送先リストのフォーカスが外れた場合のメソッドへ。
            txtCyoku_func();
        }

        /// <summary>
        /// txtCyoku_func
        /// 直送先リストのフォーカスが外れた場合
        /// </summary>
        private void txtCyoku_func()
        {
            if (txtCyoku.Text == "")
            {
                return;
            }

            //0パディング
            txtCyoku.Text = txtCyoku.Text.PadLeft(4, '0');

            //直先リストチェックへ
            Cyoku_Check();

            txtYubin_C.Focus();
        }

        /// <summary>
        /// Cyoku_Check
        /// 直送先CDに該当するデータの存在をチェックする
        /// </summary>
        private void Cyoku_Check()
        {
            DataTable dtSetView = new DataTable();

            List<string> lstDateCheckLoad = new List<string>();

            /*[0]得意先コード*/
            lstDateCheckLoad.Add(labelSet_txtCD.CodeTxtText);
            /*[1]直送先コード*/
            lstDateCheckLoad.Add(txtCyoku.Text);
            
            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                //ビジネス層、日付範囲を取得。
                dtSetView = uriageinputB.GetCyokusousakiDateCheck(lstDateCheckLoad);

                if (dtSetView.Rows.Count == 0)
                {
                    txtYubin_C.Text = "";
                    txtAdr1_C.Text = "";
                    txtAdr2_C.Text = "";
                    txtName_C.Text = "";
                    txtBusyo_C.Text = "";
                    txtTelNo_C.Text = "";
                }
                else
                {
                    txtCyoku.Text = dtSetView.Rows[0]["直送先コード"].ToString();
                    txtYubin_C.Text = dtSetView.Rows[0]["郵便番号"].ToString();
                    txtAdr1_C.Text = dtSetView.Rows[0]["住所１"].ToString();
                    txtAdr2_C.Text = dtSetView.Rows[0]["住所２"].ToString();
                    txtName_C.Text = dtSetView.Rows[0]["直送先名"].ToString();
                    txtBusyo_C.Text = dtSetView.Rows[0]["部署名"].ToString();
                    txtTelNo_C.Text = dtSetView.Rows[0]["電話番号"].ToString();
                }
                
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
            }
        }

        /// <summary>
        /// txtDenNo_Leave
        /// 伝票NOのフォーカスが外れた場合
        /// </summary>
        private void txtDenNo_Leave(object sender, EventArgs e)
        {
            //伝票NOが空白の場合は処理終了。
            if (txtDenNo.Text == "")
            {
                return;
            }

            MODY_FLAG = true;

            //伝票の内容を表示するメソッドへ移動する。
            DispDenpyo();

            txtDenNo.Enabled = false;

            MODY_FLAG = false;
            editFlg = false;
        }

        /// <summary>
        /// DispDenpyo
        /// 伝票番号に該当する明細を表示する
        /// </summary>
        private void DispDenpyo()
        {
            string Hinmei = "";
            string NM = "";


            // 売上ヘッダの担当者コードを強制的に設定する用
            string TCD = "";

            txtYMD.Text = "";
            labelSet_txtCD.CodeTxtText = "";

            //受注明細のクリアを行う。
            OneLineClear();

            //本日日付を設定する。
            txtYMD.Text = DateTime.Now.ToString("yyyy/MM/dd");

            //検索時のデータ取り出し先
            DataTable rs1;

            List<string> lstUriageInputLoad = new List<string>();
            //データの存在確認を検索する情報を入れる
            /*[0]伝票NO*/
            lstUriageInputLoad.Add(txtDenNo.Text);

            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //売上ヘッダの情報取得
                rs1 = uriageinputB.GetUriageInput(lstUriageInputLoad);

                if (rs1.Rows.Count > 0)
                {
                    txtYMD.Text = DateTime.Parse(rs1.Rows[0]["伝票年月日"].ToString()).ToString("yyyy/MM/dd");
                    //年月日が変更された場合の処理へ。
                    txtYMD_func();

                    labelSet_txtCD.CodeTxtText = rs1.Rows[0]["得意先コード"].ToString();
                    txtTname.Text = rs1.Rows[0]["得意先名"].ToString();
                    txtYubin.Text = rs1.Rows[0]["郵便番号"].ToString();
                    txtAdr1.Text = rs1.Rows[0]["住所１"].ToString();
                    txtAdr2.Text = rs1.Rows[0]["住所２"].ToString();
                    labelSet_Torihikikbn.CodeTxtText = rs1.Rows[0]["取引区分"].ToString();
                    labelSet_Tantousha.CodeTxtText = rs1.Rows[0]["担当者コード"].ToString();
                    TCD = rs1.Rows[0]["担当者コード"].ToString();
                    labelSet_Eigyosho.CodeTxtText = rs1.Rows[0]["営業所コード"].ToString();
                    txtTekiyo.Text = rs1.Rows[0]["摘要欄"].ToString();
                    cboNounyu.Text = rs1.Rows[0]["納入方法"].ToString();
                    txtGoukei1.Text = rs1.Rows[0]["税抜合計金額"].ToString();
                    txtZei.Text = rs1.Rows[0]["消費税"].ToString();
                    txtGoukei2.Text = rs1.Rows[0]["税込合計金額"].ToString();
                    txtArariKei.Text = rs1.Rows[0]["粗利額"].ToString();
                    txtCyoku.Text = rs1.Rows[0]["直送先コード"].ToString();
                    txtName_C.Text = rs1.Rows[0]["直送先名"].ToString();
                    txtYubin_C.Text = rs1.Rows[0]["直送先郵便番号"].ToString();
                    txtAdr1_C.Text = rs1.Rows[0]["直送先住所１"].ToString();
                    txtAdr2_C.Text = rs1.Rows[0]["直送先住所２"].ToString();
                    
                    //検索時のデータ取り出し先
                    DataTable rs3;

                    //検収済のデータを取得する。
                    rs3 = uriageinputB.GetKensyuzumiUriagemeisai(lstUriageInputLoad);

                    if (decimal.Parse(rs3.Rows[0]["検収済カウント"].ToString()) > 0)
                    {
                        textSet_Jucyu1.readOnly = true;
                        textSet_Jucyu2.readOnly = true;
                        textSet_Jucyu3.readOnly = true;
                        textSet_Jucyu4.readOnly = true;
                        textSet_Jucyu5.readOnly = true;
                        noEditable = true;

                        //メッセージ
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "検収済みの売上です。変更は不可です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessagebox.ShowDialog();

                        btnF01.Enabled = false;
                        btnF03.Enabled = false;
                        btnF07.Enabled = false;
                    }

                }
                else
                {
                    //メッセージ
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力した伝票番号は見つかりませんでした。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();

                    txtDenNo.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                //エラーロギング
                new CommonException(ex);
                return;
            }

            textSet_Jucyu1.readOnly = true;
            textSet_Jucyu2.readOnly = true;
            textSet_Jucyu3.readOnly = true;
            textSet_Jucyu4.readOnly = true;
            textSet_Jucyu5.readOnly = true;

            try
            {
                //受注明細の情報取得

                rs1 = uriageinputB.GetJucyuMeisai(lstUriageInputLoad);

                if (rs1.Rows.Count > 0)
                {
                    //行番号を基にデータを受注明細を設定する。
                    foreach (DataRow datarow in rs1.Rows)
                    {
                        //行番号－1した変数を保持
                        int gyoNo = int.Parse(datarow["行番号"].ToString());

                        Control[] cs1 = this.Controls.Find("textSet_Jucyu" + gyoNo.ToString(), true);
                        ((TextSet_Jucyu)cs1[0]).txtNoElem1.Text = datarow["行番号"].ToString();

                        //受注番号が変更された場合の処理
                        ((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text = datarow["受注番号"].ToString();
                        
                        ((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2_func();

                        Hinmei = "";
                         NM = "";

                        if (datarow["商品コード"].ToString() != null)
                        {
                            ((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text = datarow["商品コード"].ToString();
                            
                            //商品コードが変更された場合の処理を実行。
                            ((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11_func();
                        }

                        if (datarow["メーカーコード"].ToString() != null)
                        {
                            ((TextSet_Jucyu)cs1[0]).txtElem12.Text = datarow["メーカーコード"].ToString();
                        }

                        if (datarow["大分類コード"].ToString() != null)
                        {
                            ((TextSet_Jucyu)cs1[0]).txtElem13.Text = datarow["大分類コード"].ToString();
                        }

                        Hinmei = datarow["メーカー名"].ToString().TrimEnd();

                        if (datarow["中分類コード"].ToString() != null)
                        {
                            ((TextSet_Jucyu)cs1[0]).txtElem14.Text = datarow["中分類コード"].ToString();

                            //中分類名取得メソッドへ
                            if (((TextSet_Jucyu)cs1[0]).GetCyubunruiName(((TextSet_Jucyu)cs1[0]).txtElem13.Text, ((TextSet_Jucyu)cs1[0]).txtElem14.Text, ref NM))
                            {
                                Hinmei += " " + NM.TrimEnd();
                            }
                        }

                        if (datarow["Ｃ１"].ToString() != null)
                        {
                            Hinmei += " " + datarow["Ｃ１"].ToString().TrimEnd();
                            ((TextSet_Jucyu)cs1[0]).txtElem15.Text = datarow["Ｃ１"].ToString();
                        }

                        if (datarow["Ｃ２"].ToString() != null)
                        {
                            Hinmei += " " + datarow["Ｃ２"].ToString().TrimEnd();
                            ((TextSet_Jucyu)cs1[0]).txtElem16.Text = datarow["Ｃ２"].ToString();
                        }

                        if (datarow["Ｃ３"].ToString() != null)
                        {
                            Hinmei += " " + datarow["Ｃ３"].ToString().TrimEnd();
                            ((TextSet_Jucyu)cs1[0]).txtElem17.Text = datarow["Ｃ３"].ToString();
                        }

                        if (datarow["Ｃ４"].ToString() != null)
                        {
                            Hinmei += " " + datarow["Ｃ４"].ToString().TrimEnd();
                            ((TextSet_Jucyu)cs1[0]).txtElem18.Text = datarow["Ｃ４"].ToString();
                        }

                        if (datarow["Ｃ５"].ToString() != null)
                        {
                            Hinmei += " " + datarow["Ｃ５"].ToString().TrimEnd();
                            ((TextSet_Jucyu)cs1[0]).txtElem19.Text = datarow["Ｃ５"].ToString();
                        }

                        if (datarow["Ｃ６"].ToString() != null)
                        {
                            Hinmei += " " + datarow["Ｃ６"].ToString().TrimEnd();
                            ((TextSet_Jucyu)cs1[0]).txtElem20.Text = datarow["Ｃ６"].ToString();
                        }

                        //品名を設定
                        ((TextSet_Jucyu)cs1[0]).txtSinaBanElem3.Text = Hinmei;

                        ((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text = datarow["数量"].ToString();
                        //数量が変更した場合の処理へ。
                        ((TextSet_Jucyu)cs1[0]).txtSuuryoElem4_func();

                        //修正時の数量比較のため、使用する。
                        ((TextSet_Jucyu)cs1[0]).txtElem22.Text = datarow["数量"].ToString();

                        ((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text = datarow["売上単価"].ToString();
                        //単価が変更した場合の処理へ。
                        ((TextSet_Jucyu)cs1[0]).txtTankaElem5_func();

                        ((TextSet_Jucyu)cs1[0]).txtKingakuElem6.Text = datarow["売上金額"].ToString();

                        ((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text = datarow["仕入単価"].ToString();
                        //原価が変更になった場合の処理へ。
                        ((TextSet_Jucyu)cs1[0]).txtGenkaElem7_func();

                        ((TextSet_Jucyu)cs1[0]).txtArariElem8.Text = datarow["粗利金額"].ToString();

                        ((TextSet_Jucyu)cs1[0]).txtBikouElem9.Text = datarow["備考"].ToString();

                        ((TextSet_Jucyu)cs1[0]).labelSet_SoukoNoElem10.CodeTxtText = datarow["出庫倉庫"].ToString();


                        ((TextSet_Jucyu)cs1[0]).txtSinaBanElem3.ReadOnly = true;
                        ((TextSet_Jucyu)cs1[0]).txtGenkaElem7.ReadOnly = true;


                        //カンマのある形へ整形
                        ((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text).ToString("#,0");
                        //((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text).ToString("#,0.00");
                        //((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text).ToString("#,0.00");
                        ((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text).ToString("#,0");
                        ((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text).ToString("#,0");
                        ((TextSet_Jucyu)cs1[0]).txtKingakuElem6.Text = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtKingakuElem6.Text).ToString("#,0");
                        ((TextSet_Jucyu)cs1[0]).txtArariElem8.Text = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtArariElem8.Text).ToString("#,0");
                        ((TextSet_Jucyu)cs1[0]).txtCyokkinSiire.Text = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtCyokkinSiire.Text).ToString("#,0");
                        ((TextSet_Jucyu)cs1[0]).txtMasterSiire.Text = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtMasterSiire.Text).ToString("#,0");
                        ((TextSet_Jucyu)cs1[0]).txtTeika.Text = decimal.Parse(((TextSet_Jucyu)cs1[0]).txtTeika.Text).ToString("#,0");

                        ((TextSet_Jucyu)cs1[0]).txtJucyuRitu.Text = decimal.Parse(PutIsNull(((TextSet_Jucyu)cs1[0]).txtJucyuRitu.Text,"0")).ToString("0.0");
                        ((TextSet_Jucyu)cs1[0]).txtSiireRitu.Text = decimal.Parse(PutIsNull(((TextSet_Jucyu)cs1[0]).txtSiireRitu.Text,"0")).ToString("0.0");
                        ((TextSet_Jucyu)cs1[0]).txtRitsuElem21.Text = decimal.Parse(PutIsNull(((TextSet_Jucyu)cs1[0]).txtRitsuElem21.Text,"0")).ToString("0.0");
                        ((TextSet_Jucyu)cs1[0]).txtCyokkinSiireRitu.Text = decimal.Parse(PutIsNull(((TextSet_Jucyu)cs1[0]).txtCyokkinSiireRitu.Text,"0")).ToString("0.0");
                        ((TextSet_Jucyu)cs1[0]).txtMasterSiireRitu.Text = decimal.Parse(PutIsNull(((TextSet_Jucyu)cs1[0]).txtMasterSiireRitu.Text,"0")).ToString("0.0");
                        ((TextSet_Jucyu)cs1[0]).txtCyokkinSiireRituA.Text = decimal.Parse(PutIsNull(((TextSet_Jucyu)cs1[0]).txtCyokkinSiireRituA.Text,"0")).ToString("0.0");
                        ((TextSet_Jucyu)cs1[0]).txtMasterSiireRituA.Text = decimal.Parse(PutIsNull(((TextSet_Jucyu)cs1[0]).txtMasterSiireRituA.Text,"0")).ToString("0.0");
                    }

                }
                else
                {
                    //メッセージ
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();

                    txtDenNo.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            
            btnF01.Enabled = true;
            btnF03.Enabled = true;
            btnF07.Enabled = true;

            //売上削除承認確認、閲覧権限ユーザー【暫定】の場合は行わない。
            if (!"1".Equals(etsuranFlg))
            {
                //売上削除承認確認へ。
                if (!UriageSakujoCheck(txtDenNo.Text))
                {
                    btnF01.Enabled = false;
                    btnF07.Enabled = false;

                    noEditable = true;

                    //メッセージ
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "承認されていない為、編集登録・削除はできません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                }
                else
                {
                    if (!noEditable) {
                        textSet_Jucyu1.readOnly = false;
                        textSet_Jucyu2.readOnly = false;
                        textSet_Jucyu3.readOnly = false;
                        textSet_Jucyu4.readOnly = false;
                        textSet_Jucyu5.readOnly = false;
                    }
                }
            }
            else
            {
                if (!noEditable)
                {
                    textSet_Jucyu1.readOnly = false;
                    textSet_Jucyu2.readOnly = false;
                    textSet_Jucyu3.readOnly = false;
                    textSet_Jucyu4.readOnly = false;
                    textSet_Jucyu5.readOnly = false;
                }
            }

            //labelSet_Tantousha.CodeTxtText = TCD;
            //labelSet_Tantousha.chkTxtTantosha();
            //GetTantouCode(labelSet_Tantousha.CodeTxtText);

        }

        /// <summary>
        /// UriageSakujoCheck
        /// 売上削除が承認されているかチェックする
        /// </summary>
        private Boolean UriageSakujoCheck(string DenNo)
        {
            //検索時のデータ取り出し先
            DataTable rs;

            List<string> lstUriageSakujoCheckLoad = new List<string>();
            //データの存在確認を検索する情報を入れる
            /*[0]伝票NO*/
            lstUriageSakujoCheckLoad.Add(DenNo);

            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                //売上ヘッダの情報取得
                rs = uriageinputB.GeUriageSakujoCheckt(lstUriageSakujoCheckLoad);

                if (rs.Rows.Count > 0)
                {
                    if (rs.Rows[0]["承認"].ToString() == "Y")
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return false;
            }
        }

        /// <summary>
        /// OneLineClear
        /// 受注明細１～５のテキストボックスの中身をクリアする。
        /// </summary>
        private void OneLineClear()
        {
            for (int i = 1; i <= 5; i++)
            {
                Control[] cs1 = this.Controls.Find("textSet_Jucyu" + i.ToString(), true);
                ((TextSet_Jucyu)cs1[0]).txtNoElem1.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtJucyuNoElem2.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtSinaBanElem3.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtSuuryoElem4.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtTankaElem5.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtKingakuElem6.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtGenkaElem7.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtArariElem8.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtBikouElem9.Text = "";
                ((TextSet_Jucyu)cs1[0]).labelSet_SoukoNoElem10.CodeTxtText = "";
                ((TextSet_Jucyu)cs1[0]).labelSet_SoukoNoElem10.ValueLabelText = "";
                ((TextSet_Jucyu)cs1[0]).txtSyohinCdElem11.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtElem12.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtElem13.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtElem14.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtElem15.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtElem16.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtElem17.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtElem18.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtElem19.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtElem20.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtRitsuElem21.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtElem22.Text = "";

                ((TextSet_Jucyu)cs1[0]).txtTeika.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtJucyuRitu.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtSiireRitu.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtCyokkinSiire.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtCyokkinSiireRitu.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtMasterSiire.Text = "";
                ((TextSet_Jucyu)cs1[0]).txtMasterSiireRitu.Text = "";

                ((TextSet_Jucyu)cs1[0]).oldNo = "";
                ((TextSet_Jucyu)cs1[0]).oldSuryo = "";
                ((TextSet_Jucyu)cs1[0]).oldTanka = "";
                ((TextSet_Jucyu)cs1[0]).oldKin = "";
                ((TextSet_Jucyu)cs1[0]).oldGenka = "";
                ((TextSet_Jucyu)cs1[0]).oldTeika = "";
                ((TextSet_Jucyu)cs1[0]).oldArari = "";
                ((TextSet_Jucyu)cs1[0]).oldSouko = "";
                ((TextSet_Jucyu)cs1[0]).oldBiko = "";

            }
        }

        /// <summary>
        /// PutIsNull
        /// 値がNULLの場合、差し替え文字を挿入する。
        /// </summary>
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
        /// txtYMD_Leave
        /// 年月日のフォーカスが外れた場合
        /// </summary>
        private void txtYMD_Leave(object sender, EventArgs e)
        {
            //年月日のフォーカスが外れた場合のメソッドへ
            txtYMD_func();
        }

        /// <summary>
        /// txtYMD_func
        /// 年月日のフォーカスが外れた場合の処理
        /// </summary>
        private void txtYMD_func()
        {
            if (txtYMD.Text == "")
            {
                txtYMD.Focus();
                return;
            }

            if (labelSet_Eigyosho.CodeTxtText == "")
            {
                return;
            }

            if (f1Flg)
            {
                return;
            }

            //日付範囲チェックのメソッドへ(入力日付が日付範囲外だった場合は処理終了。)
            if (!GDateCheckEG(2, labelSet_Eigyosho.CodeTxtText, DateTime.Parse(txtYMD.Text)))
            {
                return;
            }
        }

        /// <summary>
        /// GDateCheckEG
        /// 日付範囲チェックのメソッド
        /// </summary>
        private Boolean GDateCheckEG(int gNo, string EigyosyoCd, DateTime Ymd, bool alert = true)
        {
            //検索時のデータ取り出し先
            DataTable dtSetView;

            List<string> lstDateCheckLoad = new List<string>();
            //データの存在確認を検索する情報を入れる
            /*[0]画面No*/
            lstDateCheckLoad.Add(gNo.ToString());
            /*[1]営業所コード*/
            lstDateCheckLoad.Add(EigyosyoCd);


            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                //ビジネス層、日付範囲を取得。
                dtSetView = uriageinputB.GetDateCheck(lstDateCheckLoad);

                string stF = "";
                string stT = "";
                string stYmd = "";

                if (dtSetView != null && dtSetView.Rows.Count > 0)
                {
                    stF = dtSetView.Rows[0]["最小年月日"].ToString();
                    stT = dtSetView.Rows[0]["最大年月日"].ToString();

                    stF = (DateTime.Parse(stF)).ToString("yyyy/MM/dd");
                    stT = (DateTime.Parse(stT)).ToString("yyyy/MM/dd");
                    stYmd = Ymd.ToString("yyyy/MM/dd");
                }

                //入力日付が日付範囲内外だった場合はアラートを表示する。
                //if (DateTime.Parse(dtSetView.Rows[0]["最小年月日"].ToString()) <= Ymd && Ymd <= DateTime.Parse(dtSetView.Rows[0]["最大年月日"].ToString()))
                //{
                //    return true;
                //}
                if (stYmd.CompareTo(stF) >= 0 && stYmd.CompareTo(stT) <= 0)
                {
                    return true;
                }
                else
                {
                    if (alert)
                    {
                        //例外発生メッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT,"日付が範囲外です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();  
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return false;
            }
        }

        /// <summary>
        /// labelSet_txtCD_Leave
        /// コードテキストボックスのフォーカスが外れた場合
        /// </summary>
        private void labelSet_txtCD_Leave(object sender, EventArgs e)
        {
            //コードテキストボックスのフォーカスが外れた場合のメソッドへ。
            labelSet_txtCD_func();
        }

        /// <summary>
        /// labelSet_txtCD_func
        /// コードテキストボックスのフォーカスが外れた場合の処理
        /// </summary>
        private void labelSet_txtCD_func()
        {
            //コードに該当する取引先名が空欄の場合は処理終了。
            if (labelSet_txtCD.ValueLabelText == "")
            {
                return;
            }

            //検索時のデータ取り出し先
            DataTable dtSetView;
            
            List<string> lstString = new List<string>();
            //データの存在確認を検索する情報を入れる
            /*[0]取引先コードNo*/
            lstString.Add(labelSet_txtCD.CodeTxtText);


            //ビジネス層のインスタンス生成
            A0020_UriageInput_B uriageinputB = new A0020_UriageInput_B();
            try
            {
                //ビジネス層、取引先情報を取得する。
                dtSetView = uriageinputB.getTorihikisakiData(lstString);

                if (dtSetView != null && dtSetView.Rows.Count > 0)
                {
                    txtYubin.Text = dtSetView.Rows[0]["郵便番号"].ToString();
                    txtAdr1.Text = dtSetView.Rows[0]["住所１"].ToString();
                    txtAdr2.Text = dtSetView.Rows[0]["住所２"].ToString();
                    txtTname.Text = dtSetView.Rows[0]["取引先名称"].ToString();
                    cboNounyu.Text = dtSetView.Rows[0]["納入方法"].ToString();
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
            }
        }

        private void txtModified(object sender, EventArgs e)
        {
            editFlg = true;
        }

        private void txtTekiyo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                SendKeys.Send("{TAB}");
            }
        }

        private void labelSet_Torihikikbn_Leave_1(object sender, EventArgs e)
        {
            textSet_Jucyu1.Focus();
        }

        // サブ画面表示
        private void cmbSubWinShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;

            //売上実績確認
            if (cmbSubWinShow.SelectedIndex == 0)
            {
                logger.Info(LogUtil.getMessage(this._Title, "売上実績確認実行"));

                //仕入実績確認が既に開いている場合        
                if (uriagejissekikakunin != null && uriagejissekikakunin.Visible)
                {
                    uriagejissekikakunin.Activate();
                    return;
                }

                uriagejissekikakunin = new Form.D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, 2, labelSet_txtCD.CodeTxtText, "");

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

                uriagejissekikakunin.StartPosition = FormStartPosition.Manual;
                uriagejissekikakunin.Location = s.Bounds.Location;

                //売上実績確認画面へ移動
                uriagejissekikakunin.Show();
            }
            //受注残・発注残確認
            else if (c.SelectedIndex == 1)
            {
                logger.Info(LogUtil.getMessage(this._Title, "受注残・発注残確認実行"));

                //受注残・発注残確認が既に開いている場合        
                if (juchuzan != null && juchuzan.Visible)
                {
                    juchuzan.Activate();
                    return;
                }

                //取引先コードがある場合
                if (labelSet_txtCD.codeTxt.blIsEmpty())
                {
                    juchuzan = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this, labelSet_txtCD.CodeTxtText, txtNull, true);
                }
                else
                {
                    juchuzan = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this);
                }

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

                juchuzan.StartPosition = FormStartPosition.Manual;
                juchuzan.Location = s.Bounds.Location;

                juchuzan.Show();
            }
            //商品元帳確認
            else if (c.SelectedIndex == 2)
            {
                logger.Info(LogUtil.getMessage(this._Title, "商品元帳確認実行"));

                //商品元帳確認が既に開いている場合        
                if (shohinmoto != null && shohinmoto.Visible)
                {
                    shohinmoto.Activate();
                    return;
                }

                shohinmoto = new D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin(this);

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

                shohinmoto.StartPosition = FormStartPosition.Manual;
                shohinmoto.Location = s.Bounds.Location;

                shohinmoto.Show();
            }
        }
    }
}
