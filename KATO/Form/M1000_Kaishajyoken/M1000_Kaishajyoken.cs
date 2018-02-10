using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Business.M1000_Kaishajyoken;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1000_Kaishajyoken
{
    ///<summary>
    /// M1000_Kaishajyoken
    /// 会社条件マスタ画面
    /// 作成者：utsuno
    /// 作成日：2017/6/10
    /// 更新者：utsuno
    /// 更新日：2017/6/10
    ///</summary>
    public partial class M1000_Kaishajyoken : BaseForm
    {
        // ログ初期設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// M1000_Kaishajyoken
        /// コンストラクタ(画面初期設定)
        /// </summary>
        public M1000_Kaishajyoken(Control c)
        {
            if (c == null)
            {
                return;
            }

            // 現画面サイズ取得
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
        /// M1000_Kaishajyoken_Load
        /// 画面出力処理
        /// </summary>
        private void M1000_Kaishajyoken_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "会社条件マスタ";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF12.Text = STR_FUNC_F12;

            // ボタン機能無効(検索機能後、使用できる)
            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;
        }

        /// <summary>
        /// judKaisyaCodeKeyDown
        /// キー入力判定(会社コード)
        /// </summary>
        private void judKaisyaCodeKeyDown(object sender, KeyEventArgs e)
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
                // 登録処理へ
                case Keys.F1:
                    // ボタン制御
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addKaishajyoken();
                    }
                    break;
                case Keys.F2:
                    break;
                // 削除処理へ
                case Keys.F3:
                    // ボタン制御
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delKaishajyoken();
                    }
                    break;
                // 取消処理へ
                case Keys.F4:
                    // ボタン制御
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.delText();
                    }
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
                // 終了処理へ
                case Keys.F12:
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// judKaishaNameKeyDown
        /// キー入力判定(テキストボックス【詳細項目全て】)
        /// </summary>
        private void judKaishajyoDetailsKeyDown(object sender, KeyEventArgs e)
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
        /// judtxtGetumatsusimebiKeyDown
        /// 月末締日キー入力判定(テキストボックス【詳細項目全て】)
        /// </summary>
        private void judtxtGetumatsusimebiKeyDown(object sender, KeyEventArgs e)
        {
            // 文字判定（期首月）
            if (txtGetumatsusimebi.blIsEmpty() == true)
            {
                // 期首月31日チェック
                if (!(int.Parse(txtGetumatsusimebi.Text) >= 0 && int.Parse(txtGetumatsusimebi.Text) < 31))
                {
                    //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISSNUM, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    txtGetumatsusimebi.Focus();
                    return;

                }
            }

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
        /// txtGetumatsusimebi_KeyPress
        /// 締日の数字入力規制
        /// </summary>
        private void txtGetumatsusimebi_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// judtxtShohizeiKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        /// <summary>
        /// judBtnClick
        /// ファンクション機能のボタンチェック
        /// </summary>
        private void judFuncBtnClick(object sender, EventArgs e)
        {
            // ファンクション機能のボタンの名前を取得・判別
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addKaishajyoken();
                    }
                    break;
                case STR_BTN_F03: // 削除
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delKaishajyoken();
                    }
                    break;
                case STR_BTN_F04: // 取り消し
                    if (this.btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.delText();
                    }
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }


        /// <summary>
        /// addKaishajyoken
        /// 会社条件画面の入力情報（会社条件情報）をDBに登録及び更新
        /// </summary>
        private void addKaishajyoken()
        {

            // データ渡し用
            List<string> lstString = new List<string>();

            // 文字判定（会社名）
            if (txtKaisyaCode.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtKaisyaCode.Focus();
                return;
            }
            // 文字判定（会社名）
            if (txtKaishaName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtKaishaName.Focus();
                return;
            }
            // 文字判定（郵便番号）
            if (txtYubinNum.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtYubinNum.Focus();
                return;
            }
            // 文字判定（住所１）
            if (txtJyusyo1.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtJyusyo1.Focus();
                return;
            }
            // 文字判定（電話番号）
            if (txtDennwaNum.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtDennwaNum.Focus();
                return;
            }
            // 文字判定（ＦＡＸ番号）
            if (txtFaxNum.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtFaxNum.Focus();
                return;
            }
            // 文字判定（期首月）
            if (txtGetumatsusimebi.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtGetumatsusimebi.Focus();
                return; 
            }
            // 文字判定（会計期間-開始年月日）
            if (txtKaishiYMD.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtKaishiYMD.Focus();
                return;
            }
            // 文字判定（会計期間-終了年月日）
            if (txtShuryouYMD.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtShuryouYMD.Focus();
                return;
            }

            // 禁止文字チェック
            if (StringUtl.JudBanSQL(txtKaisyaCode.Text) == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                this.txtKaisyaCode.Text = "";
                txtKaisyaCode.Focus();
                return;

            }

            // 会社コードの一桁で数値の場合パティング
            if (StringUtl.JudBanSelect(txtKaisyaCode.Text, CommonTeisu.NUMBER_ONLY) == true)
            {
                if (txtKaisyaCode.TextLength == 1)
                {
                    txtKaisyaCode.Text = txtKaisyaCode.Text.ToString().PadLeft(2, '0');
                }
            }

            // 画面情報【会社条件情報】を会社条件情報登録Ｂ層へのリスト格納
            lstString.Add(txtKaisyaCode.Text);         // 会社コード
            lstString.Add(txtKaishaName.Text);         // 会社名
            lstString.Add(txtYubinNum.Text);           // 郵便番号
            lstString.Add(txtJyusyo1.Text);            // 住所１
            lstString.Add(txtJyusyo2.Text);            // 住所２
            lstString.Add(txtDaihyosyaName.Text);      // 代表者名
            lstString.Add(txtDennwaNum.Text);          // 電話番号
            lstString.Add(txtFaxNum.Text);             // ＦＡＸ
            lstString.Add(txtGetumatsusimebi.Text);    // 期首月
            lstString.Add(txtKaishiYMD.Text);          // 開始年月日
            lstString.Add(txtShuryouYMD.Text);         // 終了年月日
            lstString.Add(SystemInformation.UserName); // ユーザ名

            // Ｂ層クラス宣言【会社条件】
            M1000_Kaishajyoken_B kaishajyokenB = new M1000_Kaishajyoken_B();

            try
            {

                // Ｂ層登録及び更新メソッド
                kaishajyokenB.addKaishajyoken(lstString);

                // メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
            }
            // 例外処理（Ｂ層での例外をキャッチする）
            catch (Exception ex)
            {
                // ログ出力処理
                new CommonException(ex);
            }
        }

        /// <summary>
        /// delKaishajyoken
        /// 会社条件画面の入力情報（会社条件情報）をDBに削除
        /// ※削除キー【会社コード】
        /// </summary>
        public void delKaishajyoken()
        {

            // 会社条件情報格納用DataTable
            DataTable dtKaishajyokenInfo;

            // データ渡し用
            List<string> lstString = new List<string>();

            // メッセージボックス宣言
            BaseMessageBox basemessagebox = null;

            // 存在チェック（会社コード）
            if (txtKaisyaCode.blIsEmpty() == false)
            {
                return;
            }

            // 禁止文字チェック
            if (StringUtl.JudBanSQL(txtKaisyaCode.Text) == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                this.txtKaisyaCode.Text = "";
                txtKaisyaCode.Focus();
                return;

            }

            // 会社コードの一桁で数値の場合パティング
            if (StringUtl.JudBanSelect(txtKaisyaCode.Text, CommonTeisu.NUMBER_ONLY) == true)
            {
                if (txtKaisyaCode.TextLength == 1)
                {
                    txtKaisyaCode.Text = txtKaisyaCode.Text.ToString().PadLeft(2, '0');
                }
            }

            // Ｂ層クラス宣言【会社条件】
            M1000_Kaishajyoken_B kaishajyokenB = new M1000_Kaishajyoken_B();

            try
            {
                // Ｂ層の会社条件情報取得処理
                dtKaishajyokenInfo = kaishajyokenB.getKaishajyoken(txtKaisyaCode.Text);

                //検索結果にデータが存在しなければ終了
                if (dtKaishajyokenInfo.Rows.Count == 0)
                {
                    return;
                }

                //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                // 画面情報【会社条件情報】を会社条件情報削除Ｂ層へのリスト格納
                lstString.Add(dtKaishajyokenInfo.Rows[0]["会社コード"].ToString());                     // 会社コード
                lstString.Add(dtKaishajyokenInfo.Rows[0]["会社名"].ToString());                         // 会社名
                lstString.Add(dtKaishajyokenInfo.Rows[0]["郵便番号"].ToString());                       // 郵便番号
                lstString.Add(dtKaishajyokenInfo.Rows[0]["住所１"].ToString());                         // 住所１
                lstString.Add(dtKaishajyokenInfo.Rows[0]["住所２"].ToString());                         // 住所２
                lstString.Add(dtKaishajyokenInfo.Rows[0]["代表者名"].ToString());                       // 代表者名
                lstString.Add(dtKaishajyokenInfo.Rows[0]["電話番号"].ToString());                       // 電話番号
                lstString.Add(dtKaishajyokenInfo.Rows[0]["ＦＡＸ"].ToString());                         // ＦＡＸ
                lstString.Add(dtKaishajyokenInfo.Rows[0]["期首月"].ToString());                         // 期首月
                lstString.Add(dtKaishajyokenInfo.Rows[0]["開始年月日"].ToString().Substring(0, 10));     // 開始年月日
                lstString.Add(dtKaishajyokenInfo.Rows[0]["終了年月日"].ToString().Substring(0, 10));    // 終了年月日
                lstString.Add(SystemInformation.UserName);                                              // ユーザ名

                // Ｂ層削除メソッド
                kaishajyokenB.delKaishajyoken(lstString);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();

                this.btnF01.Enabled = false;
                this.btnF03.Enabled = false;
                this.btnF04.Enabled = false;

                txtKaisyaCode.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// getKaishajyokenLeave
        /// 会社コード入力箇所からフォーカスが外れた時。会社条件情報取得
        /// </summary>
        public void getKaishajyokenLeave(object sender, EventArgs e)
        {

            // 会社条件情報格納用DataTable
            DataTable dtKaishajyokenInfo;

            // 存在チェック【会社コード】
            if (txtKaisyaCode.blIsEmpty() == false)
            {
                // ファンクション機能を無効化
                this.btnF01.Enabled = false;       // 登録機能
                this.btnF03.Enabled = false;       // 削除機能
                this.btnF04.Enabled = false;       // 取消機能

                return;
            }

            // 会社コードをトリム
            txtKaisyaCode.Text = txtKaisyaCode.Text.Trim();

            // 禁止文字チェック
            if (StringUtl.JudBanSQL(txtKaisyaCode.Text) == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                this.txtKaisyaCode.Text = "";
                txtKaisyaCode.Focus();
                return;

            }

            // 会社コードの一桁で数値の場合パティング
            if (StringUtl.JudBanSelect(txtKaisyaCode.Text, CommonTeisu.NUMBER_ONLY) == true)
            {
                if (txtKaisyaCode.TextLength == 1)
                {
                    txtKaisyaCode.Text = txtKaisyaCode.Text.ToString().PadLeft(2, '0');
                }
            }


            // Ｂ層クラス宣言【会社条件】
            M1000_Kaishajyoken_B kaishajyokenB = new M1000_Kaishajyoken_B();

            try
            {
                // Ｂ層の会社条件情報取得処理
                dtKaishajyokenInfo = kaishajyokenB.getKaishajyoken(txtKaisyaCode.Text);

                // 会社条件情報の件数チェック
                if (dtKaishajyokenInfo.Rows.Count != 0)
                {
                    // 会社条件情報を画面出力
                    setKaishajyoken(dtKaishajyokenInfo);

                    // ファンクション機能を有効化
                    this.btnF01.Enabled = true;       // 登録機能
                    this.btnF03.Enabled = true;       // 削除機能
                    this.btnF04.Enabled = true;       // 取消機能
                }
                else
                {
                    // 会社コード以外表示クリア
                    txtKaishaName.Text = "";
                    txtYubinNum.Text = "";
                    txtJyusyo1.Text = "";
                    txtJyusyo2.Text = "";
                    txtDaihyosyaName.Text = "";
                    txtDennwaNum.Text = "";
                    txtFaxNum.Text = "";
                    txtGetumatsusimebi.Text = "";
                    txtKaishiYMD.Text = "";
                    txtShuryouYMD.Text = "";

                    // ファンクション機能を有効化(削除以外)
                    this.btnF01.Enabled = true;      // 登録機能
                    this.btnF03.Enabled = false;      // 削除機能
                    this.btnF04.Enabled = false;       // 取消機能
                }

                // 会社名にフォーカスを移動
                txtKaishaName.Focus();

            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }


        /// <summary>
        /// setKaishajyoken
        /// 会社条件情報を画面に出力する。
        /// </summary>
        public void setKaishajyoken(DataTable dtKaishajyokenInfo)
        {
            txtKaisyaCode.Text = dtKaishajyokenInfo.Rows[0]["会社コード"].ToString();
            txtKaishaName.Text = dtKaishajyokenInfo.Rows[0]["会社名"].ToString();
            txtYubinNum.Text = dtKaishajyokenInfo.Rows[0]["郵便番号"].ToString();
            txtJyusyo1.Text = dtKaishajyokenInfo.Rows[0]["住所１"].ToString();
            txtJyusyo2.Text = dtKaishajyokenInfo.Rows[0]["住所２"].ToString();
            txtDaihyosyaName.Text = dtKaishajyokenInfo.Rows[0]["代表者名"].ToString();
            txtDennwaNum.Text = dtKaishajyokenInfo.Rows[0]["電話番号"].ToString();
            txtFaxNum.Text = dtKaishajyokenInfo.Rows[0]["ＦＡＸ"].ToString();
            txtGetumatsusimebi.Text = dtKaishajyokenInfo.Rows[0]["期首月"].ToString();
            txtKaishiYMD.Text = dtKaishajyokenInfo.Rows[0]["開始年月日"].ToString().Substring(0,10);
            txtShuryouYMD.Text = dtKaishajyokenInfo.Rows[0]["終了年月日"].ToString().Substring(0, 10);
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            delFormClear(this);

            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;

            txtKaisyaCode.Focus();
        }


    }
}
