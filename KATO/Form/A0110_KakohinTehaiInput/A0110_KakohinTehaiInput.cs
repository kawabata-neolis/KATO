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
using KATO.Business.A0110_KakohinTehaiInput;

namespace KATO.Form.A0110_KakohinTehaiInput
{
    public partial class A0110_KakohinTehaiInput : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        bool addLock = false;
        static int MAX_ROW_S = 10;
        static int MAX_ROW_K = 6;
        List<string> arr;

        int lineNo = -1;

        InputLine[] InputLineSs = new InputLine[MAX_ROW_S + 1];
        InputLine[] InputLineKs = new InputLine[MAX_ROW_K + 1];

        BaseText txtEigyo;

        public A0110_KakohinTehaiInput()
        {
            InitializeComponent();
        }

        public A0110_KakohinTehaiInput(Control c)
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

            txtEigyo = new BaseText();
            InputLineSs[0] = inputLineS0;
            InputLineSs[1] = inputLineS1;
            InputLineSs[2] = inputLineS2;
            InputLineSs[3] = inputLineS3;
            InputLineSs[4] = inputLineS4;
            InputLineSs[5] = inputLineS5;
            InputLineSs[6] = inputLineS6;
            InputLineSs[7] = inputLineS7;
            InputLineSs[8] = inputLineS8;
            InputLineSs[9] = inputLineS9;
            InputLineSs[10] = null;

            for (int i = 0; i < MAX_ROW_S; i++)
            {
                InputLineSs[i].txtNoki.Visible = false;
            }

            InputLineKs[0] = inputLineK0;
            InputLineKs[1] = inputLineK1;
            InputLineKs[2] = inputLineK2;
            InputLineKs[3] = inputLineK3;
            InputLineKs[4] = inputLineK4;
            InputLineKs[5] = inputLineK5;
            InputLineKs[6] = null;

            for (int i = 0; i < MAX_ROW_K; i++)
            {
                InputLineKs[i].lsSouko.Visible = false;
            }

            // 行番号付与
            for (int i = 0; i < MAX_ROW_S; i++)
            {
                InputLineSs[i].txtNo.Text = (i + 1).ToString();
            }

            for (int i = 0; i < MAX_ROW_K; i++)
            {
                InputLineKs[i].txtNo.Text = (i + 1).ToString();
            }

            arr = new List<string>();

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
        }

        ///<summary>
        ///画面ロード
        ///</summary>
        private void A0110_KakohinTehaiInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "加工品手配入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF07.Text = "F7:行削";
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            //初期値の設定
            setDefalut();
        }

        ///<summary>
        ///初期値の設定
        ///</summary>
        private void setDefalut()
        {
            txtYMD.Text = DateTime.Today.ToString("yyyy/MM/dd");

            txtDenNo.Text = "";
            lsTorihikisaki.CodeTxtText = "";
            lsTorihikisaki.ValueLabelText = "";
            txtEigyo.Text = "";

            DataTable dtTantoshaCd = new DataTable();

            A0110_KakohinTehaiInput_B bis = new A0110_KakohinTehaiInput_B();
            try
            {
                //ログインＩＤから担当者コードを取り出す
                dtTantoshaCd = bis.getTantoshaCd(SystemInformation.UserName);

                //担当者データがある場合
                if (dtTantoshaCd.Rows.Count > 0)
                {
                    //一行目にデータがない場合
                    if (dtTantoshaCd.Rows[0][0].ToString() == "")
                    {
                        return;
                    }
                }

                lsTantosha.CodeTxtText = dtTantoshaCd.Rows[0]["担当者コード"].ToString();
                lsTantosha.chkTxtTantosha();

                txtEigyo.Text = dtTantoshaCd.Rows[0]["営業所コード"].ToString();
                lsTorihikikbn.CodeTxtText = "41";
                lsTorihikikbn.chkTxtTorihikikbn();

                arr.Clear();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

            txtYMD.Focus();
        }

        private void A0110_KakohinTehaiInput_KeyDown(object sender, KeyEventArgs e)
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
                    if (!addLock) {
                        addLock = true;
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addInput();
                        addLock = false;
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delInput();
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.clearInput();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                    this.delLine();
                    break;
                case Keys.F8:
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

        ///<summary>
        ///judBtnClick
        ///ボタンの反応
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    if (!addLock)
                    {
                        addLock = true;
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addInput();
                        addLock = false;
                    }
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delInput();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.clearInput();
                    break;
                case STR_BTN_F07: // 行削除
                    logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                    this.delLine();
                    break;
                case STR_BTN_F09:
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///登録
        ///</summary>
        private void addInput()
        {
            // 入力チェック
            if (!this.chkInput())
            {
                return;
            }

            DBConnective con = new DBConnective();
            A0110_KakohinTehaiInput_B bis = new A0110_KakohinTehaiInput_B();

            try
            {
                bool bShukko = false;
                int lineCnt = 1;

                for (int i = 0; i < MAX_ROW_S; i++)
                {
                    if (!string.IsNullOrWhiteSpace(InputLineSs[i].txtHinban.Text))
                    {
                        bShukko = true;
                        break;
                    }
                }

                string stDenNo = txtDenNo.Text;
                if (bShukko && string.IsNullOrWhiteSpace(stDenNo))
                {
                    stDenNo = bis.getDenpyoNo("出庫伝票");
                }

                con.BeginTrans();

                // 出庫登録
                #region
                if (bShukko)
                {
                    string[] stHead = new string[]
                        { stDenNo,
                          txtYMD.Text,
                          lsTorihikisaki.CodeTxtText,
                          lsTorihikikbn.CodeTxtText,
                          lsTantosha.CodeTxtText,
                          txtEigyo.Text,
                          Environment.UserName,
                          lsTorihikisaki.ValueLabelText
                        };

                    bis.addShukkoHead(con, stHead);

                    bis.delShukkoMeisai(con, stDenNo);

                    for (int i = 0; i < MAX_ROW_S; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(InputLineSs[i].txtHinban.Text))
                        {
                            string stDai = InputLineSs[i].lsDaibun.CodeTxtText;
                            string stChu = InputLineSs[i].lsChubun.CodeTxtText;
                            string stMak = InputLineSs[i].lsMaker.CodeTxtText;
                            string stSho = InputLineSs[i].txtShohin.Text;
                            string stC1 = InputLineSs[i].txtC1.Text;

                            // 商品コードが無い場合、雑費扱い
                            if (string.IsNullOrWhiteSpace(stSho))
                            {
                                stDai = "00";
                                stChu = "00";
                                stMak = "0000";
                                stSho = "88888";
                                stC1 = InputLineSs[i].txtHinban.Text;
                            }

                            string[] stMeisai = new string[]
                                { stDenNo,                            //0 num
                                  lineCnt.ToString(),                 //1 num
                                  stSho,                              //2
                                  stMak,                              //3
                                  stDai,                              //4
                                  stChu,                              //5
                                  stC1,                               //6
                                  InputLineSs[i].txtC2.Text,          //7
                                  InputLineSs[i].txtC3.Text,          //8
                                  InputLineSs[i].txtC4.Text,          //9
                                  InputLineSs[i].txtC5.Text,          //10
                                  InputLineSs[i].txtC6.Text,          //11
                                  decimal.Parse(InputLineSs[i].txtSuryo.Text).ToString(),       //12 num
                                  decimal.Parse(InputLineSs[i].txtTanka.Text).ToString(),       //13 num
                                  InputLineSs[i].txtBiko.Text,        //14
                                  InputLineSs[i].lsSouko.CodeTxtText, //15
                                  "0",                                //16 num
                                  txtYMD.Text,                        //17
                                  Environment.UserName                //18
                                };

                            bis.addShukkoMeisai(con, stMeisai);
                            lineCnt++;
                        }
                    }
                }
                #endregion

                // 発注登録
                #region

                string stHatchuNo = "" ;

                if (string.IsNullOrWhiteSpace(stDenNo))
                {
                    stDenNo = "0";
                }

                for (int i = 0; i < arr.Count; i++)
                {
                    bis.delHaychu(con, arr[i], Environment.UserName);
                }

                lineCnt = 1;

                for (int i = 0; i < MAX_ROW_K; i++)
                {
                    stHatchuNo = InputLineKs[i].txtHNo.Text;
                    if (string.IsNullOrWhiteSpace(stHatchuNo))
                    {
                        stHatchuNo = bis.getDenpyoNo("発注番号");
                    }
                    
                    if (!string.IsNullOrWhiteSpace(InputLineKs[i].txtHinban.Text))
                    {
                        string stDai = InputLineKs[i].lsDaibun.CodeTxtText;
                        string stChu = InputLineKs[i].lsChubun.CodeTxtText;
                        string stMak = InputLineKs[i].lsMaker.CodeTxtText;
                        string stSho = InputLineKs[i].txtShohin.Text;
                        string stC1 = InputLineKs[i].txtC1.Text;

                        // 商品コードが無い場合、雑費扱い
                        if (string.IsNullOrWhiteSpace(stSho))
                        {
                            stDai = "00";
                            stChu = "00";
                            stMak = "0000";
                            stSho = "88888";
                            stC1 = InputLineKs[i].txtHinban.Text;
                        }

                        string[] stHatchu = new string[]
                            {
                              lsTorihikisaki.CodeTxtText,         //0
                              txtYMD.Text,                        //1
                              stHatchuNo,                         //2 num
                              lsTantosha.CodeTxtText,             //3
                              txtEigyo.Text,                      //4
                              lsTantosha.CodeTxtText,             //5
                              "0",                                //6 num
                              stDenNo,                            //7 num
                              lineCnt.ToString(),                 //8 num
                              stSho,                              //9
                              stMak,                              //10
                              stDai,                              //11
                              stChu,                              //12
                              stC1,                               //13
                              InputLineKs[i].txtC2.Text,          //14
                              InputLineKs[i].txtC3.Text,          //15
                              InputLineKs[i].txtC4.Text,          //16
                              InputLineKs[i].txtC5.Text,          //17
                              InputLineKs[i].txtC6.Text,          //18
                              decimal.Parse(InputLineKs[i].txtSuryo.Text).ToString(), //19 num
                              decimal.Parse(InputLineKs[i].txtTanka.Text).ToString(), //20 num
                              "0",                                //21 num
                              InputLineKs[i].txtNoki.Text,        //22
                              "0",                                //23 num
                              InputLineKs[i].txtBiko.Text,        //24
                              "1",                                //25 num
                              lsTorihikisaki.ValueLabelText,      //26
                              Environment.UserName                //27
                            };

                        bis.addHatchu(con, stHatchu);
                        lineCnt++;
                    }
                }
                #endregion

                con.Commit();

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                clearInput();
            }
            catch (Exception ex)
            {
                con.Rollback();
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
            finally
            {
                con.DB_Disconnect();
            }
        }

        ///<summary>
        ///入力チェック
        ///</summary>
        private bool chkInput()
        {
            // 年月日
            if (string.IsNullOrWhiteSpace(txtYMD.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                txtYMD.Focus();
                return false;
            }

            // 仕入先
            if (string.IsNullOrWhiteSpace(lsTorihikisaki.CodeTxtText))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                this.lsTorihikisaki.codeTxt.Focus();
                return false;
            }

            // 担当者
            if (string.IsNullOrWhiteSpace(lsTantosha.CodeTxtText))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                this.lsTantosha.codeTxt.Focus();
                return false;
            }

            // 取引区分
            if (string.IsNullOrWhiteSpace(lsTorihikikbn.CodeTxtText))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                this.lsTorihikikbn.codeTxt.Focus();
                return false;
            }

            // 入力行チェック(支給品)
            for (int i = 0; i < MAX_ROW_S; i++)
            {
                if (!InputLineSs[i].chkInput(txtDenNo.Text, false))
                {
                    return false;
                }
            }

            // 入力行チェック(完成品)
            for (int i = 0; i < MAX_ROW_K; i++)
            {
                if (!InputLineKs[i].chkInput(txtDenNo.Text, true))
                {
                    return false;
                }
            }

            return true;
        }

        ///<summary>
        ///削除
        ///</summary>
        private void delInput()
        {
            if (string.IsNullOrWhiteSpace(txtDenNo.Text))
            {
                return;
            }

            BaseMessageBox bb = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "表示中の伝票を削除します。\r\nよろしいですか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
            if (bb.ShowDialog() != DialogResult.Yes)
            {
                return;
            }

            try
            {
                A0110_KakohinTehaiInput_B bis = new A0110_KakohinTehaiInput_B();
                bis.delData(txtDenNo.Text, Environment.UserName);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                clearInput();
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

        ///<summary>
        ///入力クリア
        ///</summary>
        private void clearInput()
        {
            setDefalut();

            for (int i = 0; i < MAX_ROW_S; i++)
            {
                InputLineSs[i].clearInput();
            }
            for (int i = 0; i < MAX_ROW_K; i++)
            {
                InputLineKs[i].clearInput();
            }
            lineNo = -1;
        }

        ///<summary>
        ///行削除
        ///</summary>
        private void delLine()
        {
            Control c = this.ActiveControl;
            int num = -1;
            InputLine[] lines;
            int max = 0;

            num = lineNo;

           
            if (num >= 0 && num < 10)
            {
                lines = InputLineSs;
                max = MAX_ROW_S;
            }
            else if (num >= 10 && num < 16)
            {
                lines = InputLineKs;
                max = MAX_ROW_K;
                num = num - 10;
                if (!string.IsNullOrWhiteSpace(InputLineKs[num].txtHNo.Text)) {
                    arr.Add(InputLineKs[num].txtHNo.Text);
                }
            }
            else
            {
                return;
            }

            lines[num].clearInput();

            for (int i = num; i < max; i++)
            {
                lines[i].copyInput(lines[i + 1]);
            }

            lineNo = -1;
        }

        ///<summary>
        ///検索
        ///</summary>
        private void search()
        {
            lineNo = -1;

            if (string.IsNullOrWhiteSpace(txtDenNo.Text))
            {
                return;
            }

            A0110_KakohinTehaiInput_B bis = new A0110_KakohinTehaiInput_B();
            try
            {
                string dn = txtDenNo.Text;

                // 出庫情報取得
                DataTable dtH = bis.getDenpyoData(dn);
                if (dtH == null || dtH.Rows.Count == 0)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    txtDenNo.Focus();
                    return;
                }

                DataTable dtM = bis.getDenpyoMeisai(dn);
                if (dtM == null || dtM.Rows.Count == 0)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    txtDenNo.Focus();
                    return;
                }

                clearInput();

                txtDenNo.Text = dn;

                txtYMD.Text = getValue(dtH.Rows[0]["伝票年月日"]);
                lsTorihikisaki.CodeTxtText = getValue(dtH.Rows[0]["仕入先コード"]);
                lsTorihikisaki.chkTxtTorihikisaki();
                lsTorihikikbn.CodeTxtText = getValue(dtH.Rows[0]["取引区分"]);
                lsTorihikikbn.chkTxtTorihikikbn();
                lsTantosha.CodeTxtText = getValue(dtH.Rows[0]["担当者コード"]);
                lsTantosha.chkTxtTantosha();
                txtEigyo.Text = getValue(dtH.Rows[0]["営業所コード"]);

                int max = MAX_ROW_S;
                if (dtM.Rows.Count < MAX_ROW_S)
                {
                    max = dtM.Rows.Count;
                }

                for (int i = 0; i < max; i++)
                {
                    int ln = int.Parse(getValue(dtM.Rows[i]["行番号"]));
                    if (ln > 0)
                    {
                        ln = ln - 1;
                    }

                    InputLineSs[ln].lsDaibun.CodeTxtText = getValue(dtM.Rows[i]["大分類コード"]);
                    InputLineSs[ln].lsDaibun.chkTxtDaibunrui();
                    InputLineSs[ln].lsChubun.CodeTxtText = getValue(dtM.Rows[i]["中分類コード"]);
                    InputLineSs[ln].lsChubun.chkTxtChubunrui(InputLineSs[i].lsDaibun.CodeTxtText);
                    InputLineSs[ln].lsMaker.CodeTxtText = getValue(dtM.Rows[i]["メーカーコード"]);
                    InputLineSs[ln].lsMaker.chkTxtMaker();

                    InputLineSs[ln].txtShohin.Text = getValue(dtM.Rows[i]["商品コード"]);
                    InputLineSs[ln].txtC1.Text = getValue(dtM.Rows[i]["Ｃ１"]);
                    InputLineSs[ln].txtC2.Text = getValue(dtM.Rows[i]["Ｃ２"]);
                    InputLineSs[ln].txtC3.Text = getValue(dtM.Rows[i]["Ｃ３"]);
                    InputLineSs[ln].txtC4.Text = getValue(dtM.Rows[i]["Ｃ４"]);
                    InputLineSs[ln].txtC5.Text = getValue(dtM.Rows[i]["Ｃ５"]);
                    InputLineSs[ln].txtC6.Text = getValue(dtM.Rows[i]["Ｃ６"]);

                    string h = InputLineSs[ln].lsChubun.ValueLabelText + " "
                        + InputLineSs[ln].txtC1.Text + " "
                        + InputLineSs[ln].txtC2.Text + " "
                        + InputLineSs[ln].txtC3.Text + " "
                        + InputLineSs[ln].txtC4.Text + " "
                        + InputLineSs[ln].txtC5.Text + " "
                        + InputLineSs[ln].txtC6.Text;

                    InputLineSs[ln].txtHinban.Text = h;

                    InputLineSs[ln].txtSuryo.Text = decimal.Parse(getValue(dtM.Rows[i]["数量"])).ToString("#,0");
                    InputLineSs[ln].txtTanka.Text = decimal.Parse(getValue(dtM.Rows[i]["単価"])).ToString("#,0.00");
                    InputLineSs[ln].txtBiko.Text = getValue(dtM.Rows[i]["備考"]);
                    InputLineSs[ln].lsSouko.CodeTxtText = getValue(dtM.Rows[i]["出庫倉庫"]);
                    InputLineSs[ln].lsSouko.chkTxtEigyousho();
                }

                // 発注情報取得
                DataTable dtHt = bis.getHatchuData(dn);

                if (dtHt == null || dtHt.Rows.Count == 0)
                {
                    InputLineSs[0].lsDaibun.codeTxt.Focus();
                    return;
                }

                max = MAX_ROW_K;
                if (dtHt.Rows.Count < MAX_ROW_K)
                {
                    max = dtHt.Rows.Count;
                }

                for (int i = 0; i < max; i++)
                {
                    //int ln = int.Parse(getValue(dtM.Rows[i]["行番号"])) - 1;
                    //if (ln > 0)
                    //{
                    //    ln = ln - 1;
                    //}

                    InputLineKs[i].lsDaibun.CodeTxtText = getValue(dtHt.Rows[i]["大分類コード"]);
                    InputLineKs[i].lsDaibun.chkTxtDaibunrui();
                    InputLineKs[i].lsChubun.CodeTxtText = getValue(dtHt.Rows[i]["中分類コード"]);
                    InputLineKs[i].lsChubun.chkTxtChubunrui(InputLineKs[i].lsDaibun.CodeTxtText);
                    InputLineKs[i].lsMaker.CodeTxtText = getValue(dtHt.Rows[i]["メーカーコード"]);
                    InputLineKs[i].lsMaker.chkTxtMaker();

                    InputLineKs[i].txtShohin.Text = getValue(dtHt.Rows[i]["商品コード"]);
                    InputLineKs[i].txtC1.Text = getValue(dtHt.Rows[i]["Ｃ１"]);
                    InputLineKs[i].txtC2.Text = getValue(dtHt.Rows[i]["Ｃ２"]);
                    InputLineKs[i].txtC3.Text = getValue(dtHt.Rows[i]["Ｃ３"]);
                    InputLineKs[i].txtC4.Text = getValue(dtHt.Rows[i]["Ｃ４"]);
                    InputLineKs[i].txtC5.Text = getValue(dtHt.Rows[i]["Ｃ５"]);
                    InputLineKs[i].txtC6.Text = getValue(dtHt.Rows[i]["Ｃ６"]);

                    string h = InputLineKs[i].lsChubun.ValueLabelText + " "
                        + InputLineKs[i].txtC1.Text + " "
                        + InputLineKs[i].txtC2.Text + " "
                        + InputLineKs[i].txtC3.Text + " "
                        + InputLineKs[i].txtC4.Text + " "
                        + InputLineKs[i].txtC5.Text + " "
                        + InputLineKs[i].txtC6.Text;

                    InputLineKs[i].txtHinban.Text = h;

                    InputLineKs[i].txtSuryo.Text = decimal.Parse(getValue(dtHt.Rows[i]["発注数量"])).ToString("#,0");
                    InputLineKs[i].txtTanka.Text = decimal.Parse(getValue(dtHt.Rows[i]["発注単価"])).ToString("#,0.00");
                    InputLineKs[i].txtBiko.Text = getValue(dtHt.Rows[i]["注番"]);
                    InputLineKs[i].lsSouko.chkTxtEigyousho();
                    InputLineKs[i].txtHNo.Text = getValue(dtHt.Rows[i]["発注番号"]);
                    InputLineKs[i].txtNoki.Text = getValue(dtHt.Rows[i]["納期"]);
                    InputLineKs[i].txtShiireMei.Text = getValue(dtHt.Rows[i]["仕入先名称"]);
                }
                InputLineSs[0].lsDaibun.codeTxt.Focus();
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

        private void inputLineS_Enter(object sender, EventArgs e)
        {
            lineNo = int.Parse(((InputLine)sender).txtNo.Text) - 1;
        }

        private void inputLineK_Enter(object sender, EventArgs e)
        {
            lineNo = 10 + int.Parse(((InputLine)sender).txtNo.Text) - 1;
        }

        ///<summary>
        ///伝票No 入力時
        ///</summary>
        private void txtDenNo_Leave(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
            search();
        }

        private string getValue(object o)
        {
            if (o == null || o == DBNull.Value || string.IsNullOrWhiteSpace(o.ToString()))
            {
                return "";
            }
            else
            {
                return o.ToString().Trim();
            }
        }

        private void txtDenNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lsTorihikisaki.codeTxt.Focus();
            }
            else if (e.KeyCode == Keys.F9) {
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

                KakoTehaiList l = new KakoTehaiList();

                l.StartPosition = FormStartPosition.Manual;
                l.Location = s.Bounds.Location;

                l.pDenNo = txtDenNo;
                l.ShowDialog();
                l.Dispose();
                lsTorihikisaki.codeTxt.Focus();
            }
        }
    }
}
