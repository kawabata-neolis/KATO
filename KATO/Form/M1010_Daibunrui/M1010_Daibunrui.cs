using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Business.M1010_Daibunrui;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1010_Daibunrui
{
    ///<summary>
    ///M1010_Daibunrui
    ///大分類フォーム
    ///作成者：大河内
    ///作成日：2017/2/2
    ///更新者：宇津野
    ///更新日：2019/01/26
    ///カラム論理名
    ///</summary>
    public partial class M1010_Daibunrui : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///M1010_Daibunrui
        ///フォームの初期設定
        ///</summary>
        public M1010_Daibunrui(Control c)
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
        ///M1010_Daibunrui_Load
        ///画面レイアウト設定
        ///</summary>
        private void M1010_Daibunrui_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "大分類マスタ";
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
        ///judDaiBunruiKeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void judDaiBunruiKeyDown(object sender, KeyEventArgs e)
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
                        this.addDaibunrui();
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    // ファンクションボタン制御
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delDaibunrui();
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
                    excelDaibun();
                    break;
                case Keys.F11:
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    printDaibun();
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
        ///judDaiBunTxtKeyDown
        ///キー入力判定（無機能テキストボックス）
        ///</summary>
        private void judDaiBunTxtKeyDown(object sender, KeyEventArgs e)
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
        ///judTxtDaiTxtKeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void judTxtDaiTxtKeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    showDaibunList();
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
        ///judFuncBtnClick
        ///ファンクションボタンの反応
        ///</summary>
        private void judFuncBtnClick(object sender, EventArgs e)
        {
            //ボタン入力情報によって動作を変える
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    // ファンクションボタン制御
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addDaibunrui();
                    }
                    break;
                case STR_BTN_F03: // 削除
                    // ファンクションボタン制御
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delDaibunrui();
                    }
                    break;
                case STR_BTN_F04: // 取消
                    // ファンクションボタン制御
                    if (this.btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.delText();
                    }
                    break;
                case STR_BTN_F10: // Excel出力
                    logger.Info(LogUtil.getMessage(this._Title, "Excel出力実行"));
                    this.excelDaibun();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printDaibun();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///showDaibunList
        ///大分類リストの表示
        ///</summary>
        private void showDaibunList()
        {
            //大分類リストのインスタンス生成
            DaibunruiList daibunruiList = new DaibunruiList(this);
            try
            {
                //大分類リストの表示、画面IDを渡す
                daibunruiList.StartPosition = FormStartPosition.Manual;
                daibunruiList.intFrmKind = CommonTeisu.FRM_DAIBUNRUI;
                daibunruiList.ShowDialog();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///addDaibunrui
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addDaibunrui()
        {
            //記入情報登録用
            List<string> lstString = new List<string>();

            //文字判定（大分類コード）
            if (txtDaibunrui.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtDaibunrui.Focus();
                return;
            }
            //文字判定（大分類名）
            if (txtName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtName.Focus();
                return;
            }

            // 大分類コードエラーチェック
            if (chkDaibunCd() == true)
            {
                return;
            }

            //登録情報を入れる（大分類コード、大分類名、ラべル１～６、ユーザー名）
            lstString.Add(txtDaibunrui.Text);
            lstString.Add(txtName.Text);
            lstString.Add(txtLabel1.Text);
            lstString.Add(txtLabel2.Text);
            lstString.Add(txtLabel3.Text);
            lstString.Add(txtLabel4.Text);
            lstString.Add(txtLabel5.Text);
            lstString.Add(txtLabel6.Text);
            lstString.Add(SystemInformation.UserName);

            //ビジネス層のインスタンス生成
            M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();
            try
            {
                //登録
                daibunB.addDaibunrui(lstString);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
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
        ///テキストボックス等の入力情報を白紙にする
        ///</summary>
        private void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);
            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;
            txtDaibunrui.Focus();
        }

        ///<summary>
        ///delDaibunrui
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delDaibunrui()
        {
            //記入情報削除用
            List<string> lstDaibunData = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //空文字判定（大分類コード）
            if (txtDaibunrui.blIsEmpty() == false)
            {
                return;
            }

            // 大分類コードエラーチェック
            if (chkDaibunCd() == true)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();
            try
            {
                //検索
                dtSetCd = daibunB.getTxtDaibunruiLeave(txtDaibunrui.Text);

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

                //削除情報を入れる（大分類CD、大分類名、ラベル１～６、ユーザー名）
                lstDaibunData.Add(dtSetCd.Rows[0]["大分類コード"].ToString());
                lstDaibunData.Add(dtSetCd.Rows[0]["大分類名"].ToString());
                lstDaibunData.Add(dtSetCd.Rows[0]["ラベル名１"].ToString());
                lstDaibunData.Add(dtSetCd.Rows[0]["ラベル名２"].ToString());
                lstDaibunData.Add(dtSetCd.Rows[0]["ラベル名３"].ToString());
                lstDaibunData.Add(dtSetCd.Rows[0]["ラベル名４"].ToString());
                lstDaibunData.Add(dtSetCd.Rows[0]["ラベル名５"].ToString());
                lstDaibunData.Add(dtSetCd.Rows[0]["ラベル名６"].ToString());
                lstDaibunData.Add(SystemInformation.UserName);

                //ビジネス層、削除ロジックに移動
                daibunB.delDaibunrui(lstDaibunData);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
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
        ///setDaibunrui
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setDaibunrui(DataTable dtSelectData)
        {
            txtDaibunrui.Text = dtSelectData.Rows[0]["大分類コード"].ToString();
            txtName.Text = dtSelectData.Rows[0]["大分類名"].ToString();
            txtLabel1.Text = dtSelectData.Rows[0]["ラベル名１"].ToString();
            txtLabel2.Text = dtSelectData.Rows[0]["ラベル名２"].ToString();
            txtLabel3.Text = dtSelectData.Rows[0]["ラベル名３"].ToString();
            txtLabel4.Text = dtSelectData.Rows[0]["ラベル名４"].ToString();
            txtLabel5.Text = dtSelectData.Rows[0]["ラベル名５"].ToString();
            txtLabel6.Text = dtSelectData.Rows[0]["ラベル名６"].ToString();
        }


        ///<summary>
        ///setTxtDaibunruiLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public void setTxtDaibunruiLeave(object sender, EventArgs e)
        {
            //フォーカス位置の確保
            Control cActive = this.ActiveControl;

            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //前後の空白を取り除く
            txtDaibunrui.Text = txtDaibunrui.Text.Trim();

            //空文字判定
            if (txtDaibunrui.blIsEmpty() == false)
            {
                return;
            }

            // 大分類コードエラーチェック
            if (chkDaibunCd() == true)
            {
                return;
            }

            //ビジネス層、検索ロジックに移動
            M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = daibunB.getTxtDaibunruiLeave(txtDaibunrui.Text);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtDaibunrui.Text = dtSetCd.Rows[0]["大分類コード"].ToString();
                    txtName.Text = dtSetCd.Rows[0]["大分類名"].ToString();
                    txtLabel1.Text = dtSetCd.Rows[0]["ラベル名１"].ToString();
                    txtLabel2.Text = dtSetCd.Rows[0]["ラベル名２"].ToString();
                    txtLabel3.Text = dtSetCd.Rows[0]["ラベル名３"].ToString();
                    txtLabel4.Text = dtSetCd.Rows[0]["ラベル名４"].ToString();
                    txtLabel5.Text = dtSetCd.Rows[0]["ラベル名５"].ToString();
                    txtLabel6.Text = dtSetCd.Rows[0]["ラベル名６"].ToString();
                    txtName.Focus();
                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = true;
                    this.btnF04.Enabled = true;
                }
                else
                {
                    txtName.Text = "";
                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = false;
                    this.btnF04.Enabled = true;
                }
                cActive.Focus();
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
        ///closeDaibunruiList
        ///DaibunruiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void closeDaibunruiList()
        {
            txtDaibunrui.Focus();
        }

        ///<summary>
        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtDaibunruiKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///printDaibun
        ///印刷ダイアログ
        ///</summary>
        private void printDaibun()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //PDF作成後の入れ物
            string strFile = "";
            
            //ビジネス層のインスタンス生成
            M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();
            try
            {
                dtSetCd_B = daibunB.getPrintData();

                //取得したデータがない場合
                if (dtSetCd_B.Rows.Count == 0 || dtSetCd_B == null)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

                //初期値
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, TATE);

                pf.ShowDialog(this);

                //プレビューの場合
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    //結果セットをレコードセットに
                    strFile = daibunB.dbToPdf(dtSetCd_B);

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    strFile = daibunB.dbToPdf(dtSetCd_B);

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
        ///     F10：Excel出力
        ///</summary>
        private void excelDaibun()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //ビジネス層のインスタンス生成
            M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();
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
                sfd.FileName = "大分類マスタ_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xlsx";
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

                    // 出力するヘッダを設定
                    string[] header =
                    {
                            "コード",
                            "大分類名",
                        };

                    string outFile = sfd.FileName;

                    // Excel作成処理
                    cpdf.DtToXls(dtSetCd_B, "大分類マスタリスト", outFile, 3, 1, header);

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
        /// chkDaibunCd
        /// 大分類コードチェック
        ///</summary>
        private bool chkDaibunCd()
        {
            // 禁止文字チェック
            if (StringUtl.JudBanSQL(txtDaibunrui.Text) == false)
            {
                // メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDaibunrui.Text = "";

                txtDaibunrui.Focus();
                return true;
            }

            // 数値チェック
            if (StringUtl.JudBanSelect(txtDaibunrui.Text, CommonTeisu.NUMBER_ONLY) == false)
            {
                // メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDaibunrui.Text = "";

                txtDaibunrui.Focus();
                return true;
            }

            // 文字数が足りなかった場合0パティング
            if (txtDaibunrui.TextLength == 1)
            {
                txtDaibunrui.Text = txtDaibunrui.Text.ToString().PadLeft(2, '0');
            }
            return false;
        }
    }
}
