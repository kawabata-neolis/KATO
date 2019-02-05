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
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Business.M1040_Torihikikbn;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1040_Torihikikbn
{
    ///<summary>
    ///M1040_Torihikikubun
    ///取引区分フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：宇津野
    ///更新日：2019/01/26
    ///カラム論理名
    ///</summary>
    public partial class M1040_Torihikikbn : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///M1040_Torihikikubun
        ///フォームの初期設定
        ///</summary>
        public M1040_Torihikikbn(Control c)
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
        private void M1040_Torihikikubun_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "取引区分マスタ";
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
        ///judTorikbnKeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void judTorikbnKeyDown(object sender, KeyEventArgs e)
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
                    // ボタン制御
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addTorikbn();
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delTorikbn();
                    }
                    break;
                case Keys.F4:
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
                    excelTorihikikbn();
                    break;
                case Keys.F11:
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    printTorihikikbn();
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
        ///judTorikbnTxtKeyDown
        ///キー入力判定（無機能テキストボックス）
        ///</summary>
        private void judTorikbnTxtKeyDown(object sender, KeyEventArgs e)
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
        ///judTxtTorikbnTxtKeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void judTxtTorikbnTxtKeyDown(object sender, KeyEventArgs e)
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
                    shoTorihikikbn();
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
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addTorikbn();
                    }
                    break;
                case STR_BTN_F03: // 削除
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delTorikbn();
                    }
                    break;
                case STR_BTN_F04: // 取消
                    if (this.btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.delText();
                    }
                    break;
                case STR_BTN_F10: // Excel出力
                    logger.Info(LogUtil.getMessage(this._Title, "Excel出力実行"));
                    this.excelTorihikikbn();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printTorihikikbn();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///shoTorihikikbn
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void shoTorihikikbn()
        {
            //取引区分リストのインスタンス生成
            TorihikikbnList torihikikbnList = new TorihikikbnList(this);
            try
            {
                //取引区分リストの表示、画面IDを渡す
                torihikikbnList.StartPosition = FormStartPosition.Manual;
                torihikikbnList.intFrmKind = CommonTeisu.FRM_TORIHIKIKBN;
                torihikikbnList.ShowDialog();
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
        ///addTorikubun
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addTorikbn()
        {
            //記入情報登録用
            List<string> lstTorihikikbnData = new List<string>();

            //文字判定（取引区分コード）
            if (txtTorihikikubunCd.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTorihikikubunCd.Focus();
                return;
            }
            //文字判定（取引区分名）
            if (txtTorihikikubunName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTorihikikubunName.Focus();
                return;
            }

            // 取引区分チェック
            if (chkTorihikikubunCd() == true)
            {
                return;
            }

            //登録情報を入れる（取引区分コード、取引区分名、ユーザー名）
            lstTorihikikbnData.Add(txtTorihikikubunCd.Text);
            lstTorihikikbnData.Add(txtTorihikikubunName.Text);
            lstTorihikikbnData.Add(SystemInformation.UserName);

            //ビジネス層のインスタンス生成
            M1040_Torihikikbn_B torikbnB = new M1040_Torihikikbn_B();
            try
            {
                //登録
                torikbnB.addTorihikikbn(lstTorihikikbnData);

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
        ///テキストボックス内の文字を削除
        ///</summary>
        private void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);
            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;
            txtTorihikikubunCd.Focus();
        }

        ///<summary>
        ///delTorikbn
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delTorikbn()
        {
            //記入情報削除用
            List<string> lstTorihikikbn = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //文字判定（取引区分コード、取引区分名）
            if (txtTorihikikubunCd.blIsEmpty() == false && txtTorihikikubunName.blIsEmpty() == false)
            {
                return;
            }

            // 取引区分チェック
            if (chkTorihikikubunCd() == true)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1040_Torihikikbn_B torikbnB = new M1040_Torihikikbn_B();
            try
            {
                //ビジネス層、検索ロジックに移動
                dtSetCd = torikbnB.getTxtTorikbnLeave(txtTorihikikubunCd.Text);

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

                //削除情報を入れる（取引区分CD、取引区分名、ユーザー名）
                lstTorihikikbn.Add(dtSetCd.Rows[0]["取引区分コード"].ToString());
                lstTorihikikbn.Add(dtSetCd.Rows[0]["取引区分名"].ToString());
                lstTorihikikbn.Add(SystemInformation.UserName);

                //ビジネス層、削除ロジックに移動
                torikbnB.delTorihikikbn(lstTorihikikbn);
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
        ///setTorikubun
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setTorikubun(DataTable dtSelectData)
        {
            txtTorihikikubunCd.Text = dtSelectData.Rows[0]["取引区分コード"].ToString();
            txtTorihikikubunName.Text = dtSelectData.Rows[0]["取引区分名"].ToString();
        }

        ///<summary>
        ///setTxtToriLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public void setTxtToriLeave(object sender, EventArgs e)
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //前後の空白を取り除く
            txtTorihikikubunCd.Text = txtTorihikikubunCd.Text.Trim();

            //空文字判定
            if (txtTorihikikubunCd.blIsEmpty() == false)
            {
                return;
            }

            // 取引区分チェック
            if (chkTorihikikubunCd() == true)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1040_Torihikikbn_B torikbnB = new M1040_Torihikikbn_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = torikbnB.getTxtTorikbnLeave(txtTorihikikubunCd.Text);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtTorihikikubunCd.Text = dtSetCd.Rows[0]["取引区分コード"].ToString();
                    txtTorihikikubunName.Text = dtSetCd.Rows[0]["取引区分名"].ToString();

                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = true;
                    this.btnF04.Enabled = true;
                }
                else
                {
                    txtTorihikikubunName.Text = "";

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
        ///closeTorikbnList
        ///TorihikikbnListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void closeTorikbnList()
        {
            txtTorihikikubunCd.Focus();
        }

        ///<summary>
        ///judtxtToriKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtToriKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///printTorihikikbn
        ///印刷ダイアログ
        ///</summary>
        private void printTorihikikbn()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //PDF作成後の入れ物
            string strFile = "";

            //ビジネス層のインスタンス生成
            M1040_Torihikikbn_B torikbnB = new M1040_Torihikikbn_B();
            try
            {
                dtSetCd_B = torikbnB.getPrintData();

                //取得したデータがない場合
                if (dtSetCd_B == null || dtSetCd_B.Rows.Count == 0)
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
                    strFile = torikbnB.dbToPdf(dtSetCd_B);

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    strFile = torikbnB.dbToPdf(dtSetCd_B);

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
        private void excelTorihikikbn()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //ビジネス層のインスタンス生成
            M1040_Torihikikbn_B daibunB = new M1040_Torihikikbn_B();
            try
            {
                dtSetCd_B = daibunB.getPrintData();

                BaseMessageBox basemessagebox;
                //取得したデータがない場合
                if (dtSetCd_B.Rows.Count == 0 || dtSetCd_B == null)
                {
                    //例外発生メッセージ（OK）
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

                // SaveFileDialogクラスのインスタンスを作成
                SaveFileDialog sfd = new SaveFileDialog();
                // ファイル名の指定
                sfd.FileName = "取引区分マスタ_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xlsx";
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

                    //Linqで必要なデータをselect
                    var outDataAll = dtSetCd_B.AsEnumerable()
                        .Select(dat => new
                        {
                            torihikikbnCd = (String)dat["取引区分コード"],
                            torihikikbnName = dat["取引区分名"],
                        }).ToList();

                    //リストをデータテーブルに変換
                    DataTable dtChkList = cpdf.ConvertToDataTable(outDataAll);

                    // 出力するヘッダを設定
                    string[] header =
                    {
                            "コード",
                            "取引区分名",
                        };

                    string outFile = sfd.FileName;

                    // Excel作成処理
                    cpdf.DtToXls(dtChkList, "取引区分マスタリスト", outFile, 3, 1, header);

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
        /// chkTorihikikubunCd
        /// 取引区分チェック
        ///</summary>
        private bool chkTorihikikubunCd()
        {
            // 禁止文字チェック
            if (StringUtl.JudBanSQL(txtTorihikikubunCd.Text) == false)
            {
                // メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtTorihikikubunCd.Text = "";

                txtTorihikikubunCd.Focus();
                return true;
            }

            this.txtTorihikikubunCd.Text = StringUtl.JudZenToHanNum(txtTorihikikubunCd.Text);

            // 数値チェック
            if (StringUtl.JudBanSelect(txtTorihikikubunCd.Text, CommonTeisu.NUMBER_ONLY) == true)
            {
                // 文字数が足りなかった場合0パティング
                if (txtTorihikikubunCd.TextLength == 1)
                {
                    txtTorihikikubunCd.Text = txtTorihikikubunCd.Text.ToString().PadLeft(2, '0');
                }
            }

            return false;
        }
    }
}
