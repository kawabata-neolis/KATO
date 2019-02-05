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
using KATO.Business.M1100_Chokusosaki;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1100_Chokusosaki
{
    ///<summary>
    ///M1100_Chokusosaki
    ///直送先フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：宇津野
    ///更新日：2019/02/02
    ///カラム論理名
    ///</summary>
    public partial class M1100_Chokusosaki : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        ///<summary>
        ///M1100_Chokusosaki
        ///フォームの初期設定
        ///</summary>
        public M1100_Chokusosaki(Control c)
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
        }

        ///<summary>
        ///M1100_Chokusosaki_Load
        ///画面レイアウト設定
        ///</summary>
        private void M1100_Chokusosaki_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "直送先マスタ";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF10.Text = "Excel出力";
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // ファンクションボタン制御
            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;
            this.btnF09.Enabled = false;
        }

        ///<summary>
        ///M1090_Eigyosho_KeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void M1100_Chokusosaki_KeyDown(object sender, KeyEventArgs e)
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
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addChokusosaki();
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    // ファンクションボタン制御
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delChokusosaki();
                    }
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
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    logger.Info(LogUtil.getMessage(this._Title, "Excel出力実行"));
                    excelChokuso();
                    break;
                case Keys.F11:
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    printChokuso();
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
        ///judChokuTxtKeyDown
        ///キー入力判定（無機能テキストボックス）
        ///</summary>
        private void judChokuTxtKeyDown(object sender, KeyEventArgs e)
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

        ///<summary>
        ///judTxtChoTxtKeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void judTxtChoTxtKeyDown(object sender, KeyEventArgs e)
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
                    if (labelSet_Torihikisaki.CodeTxtText != "")
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                        showChokusosakiList();
                    }
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

        ///<summary>
        ///judBtnClick
        ///ファンクションボタンの反応
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            //ボタン入力情報によって動作を変える
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    // ファンクションボタン制御
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addChokusosaki();
                    }
                    break;
                case STR_BTN_F03: // 削除
                    // ファンクションボタン制御
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delChokusosaki();
                    }
                    break;
                case STR_BTN_F04: // 取り消し
                    // ファンクションボタン制御
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.delText();
                    }
                    break;
                case STR_BTN_F10: // Excel出力
                    logger.Info(LogUtil.getMessage(this._Title, "Excel出力実行"));
                    excelChokuso();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printChokuso();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///showChokusosakiList
        ///キー入力判定
        ///</summary>
        private void showChokusosakiList()
        {
            string strTorihikiCd = labelSet_Torihikisaki.CodeTxtText;

            //直送先リストのインスタンス生成
            ChokusosakiList chokusosakilist = new ChokusosakiList(this, strTorihikiCd);
            try
            {
                //直送先リストの表示、画面IDを渡す
                chokusosakilist.StartPosition = FormStartPosition.Manual;
                chokusosakilist.intFrmKind = KATO.Common.Util.CommonTeisu.FRM_CHOKUSOSAKI;
                chokusosakilist.ShowDialog();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///addChokusosaki
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addChokusosaki()
        {

            //記入情報登録用
            List<string> lstChokusosaki = new List<string>();

            //空文字判定（得意先コード）
            if (StringUtl.blIsEmpty(labelSet_Torihikisaki.CodeTxtText) == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Torihikisaki.Focus();
                return;
            }
            // 値チェック（得意先コード：仕様上、取引先コード）
            if (labelSet_Torihikisaki.chkTxtTorihikisaki())
            {
                return;
            }
            //空文字判定（直送先コード）
            if (txtChokusoCd.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtChokusoCd.Focus();
                return;
            }

            // 値チェック（直送先コード）
            if (chkChokusoCd() == true)
            {
                return;
            }

            //空文字判定（直送先名）
            if (txtChokusoName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtChokusoName.Focus();
                return;
            }

            //登録情報を入れる（得意先コード、直送先コード、直送先名、郵便番号、住所１、住所２、電話番号、部署名、ユーザー名）
            lstChokusosaki.Add(labelSet_Torihikisaki.codeTxt.Text);
            lstChokusosaki.Add(txtChokusoCd.Text);
            lstChokusosaki.Add(txtChokusoName.Text);
            lstChokusosaki.Add(txtYubin.Text);
            lstChokusosaki.Add(txtJusho1.Text);
            lstChokusosaki.Add(txtJusho2.Text);
            lstChokusosaki.Add(txtDenwa.Text);
            lstChokusosaki.Add(txtBushoName.Text);
            lstChokusosaki.Add(SystemInformation.UserName);

            M1100_Chokusosaki_B chokusosakiB = new M1100_Chokusosaki_B();
            try
            {
                //登録
                chokusosakiB.addChokusosaki(lstChokusosaki);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                
                //テキストボックスを白紙にする
                DipDelChokusoInfo();

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除、ボタンの機能を消す
        ///</summary>
        private void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);

            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;

            labelSet_Torihikisaki.Focus();
        }

        ///<summary>
        ///delChokusosaki
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delChokusosaki()
        {
            //記入情報のデータの存在確認用
            List<string> lstChokusosakiLoad = new List<string>();
            //記入情報削除用
            List<string> lstChokusosaki = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;
            
            //空文字判定（得意先コード、直送先コード）
            if (StringUtl.blIsEmpty(labelSet_Torihikisaki.CodeTxtText) == false || txtChokusoCd.blIsEmpty() == false)
            {
                return;
            }

            // 値チェック（得意先コード：仕様上、取引先コード）
            if (labelSet_Torihikisaki.chkTxtTorihikisaki())
            {
                return;
            }

            // 値チェック（直送先コード）
            if (chkChokusoCd() == true)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1100_Chokusosaki_B chokusosakiB = new M1100_Chokusosaki_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                lstChokusosakiLoad.Add(labelSet_Torihikisaki.CodeTxtText);
                lstChokusosakiLoad.Add(txtChokusoCd.Text);

                //戻り値のDatatableを取り込む
                dtSetCd = chokusosakiB.setTxtChokusoLeave(lstChokusosakiLoad);

                //検索結果にデータが存在しなければ終了
                if (dtSetCd.Rows.Count == 0)
                {
                    return;
                }

                //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                //削除情報を入れる（得意先コード、直送先コード、直送先名、郵便番号、住所１、住所２、電話番号、部署名、ユーザー名）
                lstChokusosaki.Add(dtSetCd.Rows[0]["得意先コード"].ToString());
                lstChokusosaki.Add(dtSetCd.Rows[0]["直送先コード"].ToString());
                lstChokusosaki.Add(dtSetCd.Rows[0]["直送先名"].ToString());
                lstChokusosaki.Add(dtSetCd.Rows[0]["郵便番号"].ToString());
                lstChokusosaki.Add(dtSetCd.Rows[0]["住所１"].ToString());
                lstChokusosaki.Add(dtSetCd.Rows[0]["住所２"].ToString());
                lstChokusosaki.Add(dtSetCd.Rows[0]["電話番号"].ToString());
                lstChokusosaki.Add(dtSetCd.Rows[0]["部署名"].ToString());
                lstChokusosaki.Add(SystemInformation.UserName);

                //ビジネス層、削除ロジックに移動
                chokusosakiB.delChokusosaki(lstChokusosaki);

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();


                //テキストボックスを白紙にする
                DipDelChokusoInfo();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///setChokusoCode
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setChokusoCode(DataTable dtSelectData)
        {
            //得意先コードが一致する場合
            if (labelSet_Torihikisaki.CodeTxtText == dtSelectData.Rows[0]["得意先コード"].ToString())
            {
                txtChokusoCd.Text = dtSelectData.Rows[0]["直送先コード"].ToString();
                txtChokusoName.Text = dtSelectData.Rows[0]["直送先名"].ToString();
                txtYubin.Text = dtSelectData.Rows[0]["郵便番号"].ToString();
                txtJusho1.Text = dtSelectData.Rows[0]["住所１"].ToString();
                txtJusho2.Text = dtSelectData.Rows[0]["住所２"].ToString();
                txtDenwa.Text = dtSelectData.Rows[0]["電話番号"].ToString();
                txtBushoName.Text = dtSelectData.Rows[0]["部署名"].ToString();
            }
            else
            {
                txtChokusoCd.Text = dtSelectData.Rows[0]["直送先コード"].ToString();
                txtChokusoName.Clear();
                txtYubin.Clear();
                txtJusho1.Clear();
                txtJusho2.Clear();
                txtDenwa.Clear();
                txtBushoName.Clear();
            }
        }

        ///<summary>
        ///updTxtChokuTxtLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public void updTxtChokuTxtLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstChokusosaki = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //前後の空白を取り除く
            txtChokusoCd.Text = txtChokusoCd.Text.Trim();

            //空文字判定（得意先コード、直送先コード）
            if (StringUtl.blIsEmpty(labelSet_Torihikisaki.CodeTxtText) == false || txtChokusoCd.blIsEmpty() == false)
            {
                return;
            }

            // 値チェック（直送先コード）
            if (chkChokusoCd() == true)
            {
                return;
            }

            //データの存在確認を検索する情報を入れる
            lstChokusosaki.Add(labelSet_Torihikisaki.CodeTxtText);
            lstChokusosaki.Add(txtChokusoCd.Text);

            //ビジネス層のインスタンス生成
            M1100_Chokusosaki_B chokusosakiB = new M1100_Chokusosaki_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = chokusosakiB.setTxtChokusoLeave(lstChokusosaki);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtChokusoCd.Text = dtSetCd.Rows[0]["直送先コード"].ToString();
                    txtChokusoName.Text = dtSetCd.Rows[0]["直送先名"].ToString();
                    txtYubin.Text = dtSetCd.Rows[0]["郵便番号"].ToString();
                    txtJusho1.Text = dtSetCd.Rows[0]["住所１"].ToString();
                    txtJusho2.Text = dtSetCd.Rows[0]["住所２"].ToString();
                    txtDenwa.Text = dtSetCd.Rows[0]["電話番号"].ToString();
                    txtBushoName.Text = dtSetCd.Rows[0]["部署名"].ToString();

                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = true;
                    this.btnF04.Enabled = true;

                }
                else
                {
                    //各項目のクリア
                    txtChokusoName.Text = "";
                    txtYubin.Text = "";
                    txtJusho1.Text = "";
                    txtJusho2.Text = "";
                    txtDenwa.Text = "";
                    txtBushoName.Text = "";

                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = false;
                    this.btnF04.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///setTokuiListClose
        ///TokuisakiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setTokuiListClose()
        {
            labelSet_Torihikisaki.Focus();
        }

        ///<summary>
        ///setChokuListClose
        ///ChokusosakiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setChokuListClose()
        {
            txtChokusoCd.Focus();
        }
        
        ///<summary>
        ///judtxtChokuKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtChokuKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///     F10：Excel出力
        ///</summary>
        private void excelChokuso()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //ビジネス層のインスタンス生成
            M1100_Chokusosaki_B daibunB = new M1100_Chokusosaki_B();
            try
            {
                dtSetCd_B = daibunB.getPrintData();

                BaseMessageBox basemessagebox;
                //取得したデータがない場合
                if (dtSetCd_B == null || dtSetCd_B.Rows.Count == 0)
                {
                    //例外発生メッセージ（OK）
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

                // SaveFileDialogクラスのインスタンスを作成
                SaveFileDialog sfd = new SaveFileDialog();
                // ファイル名の指定
                sfd.FileName = "直送先マスタ_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xlsx";
                // デフォルトパス取得（デスクトップ）
                string Init_dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //はじめに表示されるフォルダを指定する
                sfd.InitialDirectory = Init_dir;
                // ファイルフィルタの設定
                sfd.Filter = "すべてのファイル(*.*)|*.*";

                //ダイアログを表示する
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    CreatePdf cpdf = new CreatePdf();
                    string[] header =
                    {
                        "得意先コード",
                        "得意先名称",
                        "直送先コード",
                        "直送先名",
                        "郵便番号",
                        "住所１",
                        "住所２",
                        "電話番号",
                        };

                    string outFile = sfd.FileName;

                    // Excel作成処理
                    cpdf.DtToXls(dtSetCd_B, "直送先マスタリスト", outFile, 3, 1, header);

                    // メッセージボックスの処理、Excel作成完了の場合のウィンドウ（OK）
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "Excelファイルを作成しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///printChokuso
        ///印刷ダイアログ
        ///</summary>
        private void printChokuso()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //PDF作成後の入れ物
            string strFile = "";

            //ビジネス層のインスタンス生成
            M1100_Chokusosaki_B chokusoB = new M1100_Chokusosaki_B();
            try
            {
                dtSetCd_B = chokusoB.getPrintData();

                //取得したデータがない場合
                if (dtSetCd_B.Rows.Count == 0 || dtSetCd_B == null)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();    
                    return;
                }

                //初期値
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, YOKO);

                pf.ShowDialog(this);

                //プレビューの場合
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    //結果セットをレコードセットに
                    strFile = chokusoB.dbToPdf(dtSetCd_B);

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    strFile = chokusoB.dbToPdf(dtSetCd_B);

                    // 一括印刷
                    pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.TATE, true);
                }

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        /// DipDelChokusoInfo
        /// 直送先に掛かるデータリセット
        ///</summary>
        private void DipDelChokusoInfo()
        {
            //各項目のクリア
            txtChokusoCd.Text = "";
            txtChokusoName.Text = "";
            txtYubin.Text = "";
            txtJusho1.Text = "";
            txtJusho2.Text = "";
            txtDenwa.Text = "";
            txtBushoName.Text = "";
            txtChokusoCd.Focus();

            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;
        }

        ///<summary>
        /// chkChokusoCd
        /// 直送先コードチェック
        ///</summary>
        private bool chkChokusoCd()
        {
            // 禁止文字チェック
            if (StringUtl.JudBanSQL(txtChokusoCd.Text) == false)
            {
                // メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                DipDelChokusoInfo();

                return true;
            }

            this.txtChokusoCd.Text = StringUtl.JudZenToHanNum(txtChokusoCd.Text);

            // 数値チェック
            if (StringUtl.JudBanSelect(txtChokusoCd.Text, CommonTeisu.NUMBER_ONLY) == true)
            {
                // 文字数が足りなかった場合0パティング
                if (txtChokusoCd.TextLength < 4)
                {
                    txtChokusoCd.Text = txtChokusoCd.Text.ToString().PadLeft(4, '0');
                }
            }

            return false;
        }
    }
}
