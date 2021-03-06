﻿using KATO.Business.A0150_UriageCheckPrint;
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


namespace KATO.Form.A0150_UriageCheckPrint
{
    ///<summary>
    ///A0150_UriageCheckPrint
    ///売上チェックリスト
    ///作成者：太田
    ///作成日：2017/07/03
    ///更新者：山本
    ///更新日：2019/2/2
    ///F10：Excel出力 機能追加
    ///</summary>
    public partial class A0150_UriageCheckPrint : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// A0150_UriageCheckPrint
        /// フォーム関係の設定
        /// </summary>
        public A0150_UriageCheckPrint(Control c)
        {
            if (c == null)
            {
                return;
            }

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
        }

        private void A0150_UriageCheckPrint_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "売上チェックリスト";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF10.Text = "Excel出力";
            this.btnF12.Text = STR_FUNC_F12;

            //初期表示
            txtUserID.Text = Environment.UserName;
            txtNyuryokuYMDstart.Text = DateTime.Now.ToString();
            txtNyuryokuYMDend.Text = DateTime.Now.ToString();
            txtDenpyoYMDstart.Text = DateTime.Now.ToString("yyyy/MM")+"/01";

            //月末のデータ取得
            System.DateTime dateEndYMD;

            dateEndYMD = DateTime.Parse(txtDenpyoYMDstart.Text);

            dateEndYMD = dateEndYMD.AddMonths(1);
            txtDenpyoYMDend.Text = dateEndYMD.AddDays(-1).ToString("yyyy/MM/dd");

            labelSet_TokuisakiCdFrom.SearchOn = false;
            labelSet_TokuisakiCdTo.SearchOn = false;
        }

        /// <summary>
        /// C0490_UriageSuiiHyo_KeyDown
        /// キー入力判定
        /// </summary>
        private void C0490_UriageSuiiHyo_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.F9:
                    break;
                case Keys.F10:
                    logger.Info(LogUtil.getMessage(this._Title, "Excel出力"));
                    this.exportXls();
                    break;
                case Keys.F11:
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printReport();
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
                
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F10: // Excel出力
                    logger.Info(LogUtil.getMessage(this._Title, "Excel出力"));
                    this.exportXls();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printReport();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            
            //画面の項目内を白紙にする
            delFormClear(this,null);

            //本日日付を設定する。
            txtNyuryokuYMDstart.Text = DateTime.Now.ToString();
            txtNyuryokuYMDend.Text = DateTime.Now.ToString();
            txtDenpyoYMDstart.Text = DateTime.Now.ToString();
            txtDenpyoYMDend.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {

            // データチェック処理
            if (!dataCheack())
            {
                return;
            }

            // データ検索用
            List<string> lstSearchItem = new List<string>();


            // ビジネス層のインスタンス生成
            A0150_UriageCheckPrint_B uriagecheckprintB = new A0150_UriageCheckPrint_B();
            try
            {
                // 検索するデータをリストに格納
                lstSearchItem.Add(txtNyuryokuYMDstart.Text);
                lstSearchItem.Add(txtNyuryokuYMDend.Text);
                lstSearchItem.Add(txtDenpyoYMDstart.Text);
                lstSearchItem.Add(txtDenpyoYMDend.Text);
                lstSearchItem.Add(txtUserID.Text);
                lstSearchItem.Add(labelSet_TokuisakiCdFrom.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiCdTo.CodeTxtText);

                // 検索実行（印刷用）
                DataTable dtSiireSuiiList = uriagecheckprintB.getUriageCheckList(lstSearchItem);

                // レコードが0件だった場合は終了）
                if (dtSiireSuiiList.Rows.Count <= 0 )
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT,"対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
                
                // 印刷ダイアログ
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_B4, CommonTeisu.YOKO);

                pf.ShowDialog(this);
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    // PDF作成
                    string strFile;
                    strFile = uriagecheckprintB.dbToPdf(dtSiireSuiiList, lstSearchItem);
                    pf.execPreview(@strFile);
                }
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    string strFile;
                    strFile = uriagecheckprintB.dbToPdf(dtSiireSuiiList, lstSearchItem);

                    // 用紙サイズ、印刷方向はインスタンス生成と同じ値を入れる
                    // ダイアログ表示時は最後の引数はtrue
                    // （ダイアログ非経由の直接印刷時は先頭引数にプリンタ名を入れ、最後の引数をfalseに）
                    pf.execPrint(null, @strFile, CommonTeisu.SIZE_B4, CommonTeisu.YOKO, true);
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
        ///     F10：Excel出力
        ///</summary>
        private void exportXls()
        {
            // SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();
            // ファイル名の指定
            sfd.FileName = "売上チェックリスト_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xlsx";
            // デフォルトパス取得（デスクトップ）
            string Init_dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = Init_dir;
            // ファイルフィルタの設定
            sfd.Filter = "すべてのファイル(*.*)|*.*";

            try
            {
                // データチェック処理
                if (!dataCheack())
                {
                    return;
                }

                // データ検索用
                List<string> lstSearchItem = new List<string>();

                //待機状態
                Cursor.Current = Cursors.WaitCursor;

                // ビジネス層のインスタンス生成
                A0150_UriageCheckPrint_B uriagecheckprintB = new A0150_UriageCheckPrint_B();

                // 検索するデータをリストに格納
                lstSearchItem.Add(txtNyuryokuYMDstart.Text);
                lstSearchItem.Add(txtNyuryokuYMDend.Text);
                lstSearchItem.Add(txtDenpyoYMDstart.Text);
                lstSearchItem.Add(txtDenpyoYMDend.Text);
                lstSearchItem.Add(txtUserID.Text);
                lstSearchItem.Add(labelSet_TokuisakiCdFrom.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiCdTo.CodeTxtText);

                // 検索実行（印刷用）
                DataTable dtUriageChk = uriagecheckprintB.getUriageCheckList(lstSearchItem);

                // カーソルをデフォルトに戻す
                this.Cursor = Cursors.Default;

                if (dtUriageChk.Rows.Count > 0)
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //待機状態
                        Cursor.Current = Cursors.WaitCursor;

                        CreatePdf cpdf = new CreatePdf();

                        // 出力するヘッダを設定
                        string[] header =
                        {
                            "コード",
                            "得意先名",
                            "年月日",
                            "伝票番号",
                            "取引区分",
                            "品名・型番",
                            "数量",
                            "単価",
                            "金額",
                            "備考",
                            "伝票合計",
                            "消費税",
                            "税込み計",
                        };

                        // Linqで出力対象の項目をSelect
                        // カラム名は以下のようにつける(カラム名でフォーマットを判断するため)
                        // 金額関係：＊＊＊kingaku
                        // 単価関係：＊＊＊tanka
                        // 原価：＊＊＊genka
                        // 数量：＊＊＊suryo
                        var outDat = dtUriageChk.AsEnumerable()
                            .Select(dat => new
                            {
                                code = dat["得意先コード"],
                                siiresakiName = dat["得意先名"],
                                denYmd = dat["伝票年月日"],
                                denNo = dat["伝票番号"],
                                torihikiKbn = dat["取引区分名"],
                                hinmei = dat["品名"],
                                suryo = dat["数量"],
                                siireTanka = dat["単価"],
                                siireKingaku = dat["金額"],
                                biko = dat["備考"],
                                zeinukiGokeiKingaku = dat["税抜合計金額"],
                                zeiKingaku = dat["消費税"],
                                zeikomiGokeiKingaku = dat["税込合計金額"],
                            }).ToList();

                        // listをDataTableに変換
                        DataTable dtSiireChk = cpdf.ConvertToDataTable(outDat);

                        string outFile = sfd.FileName;

                        cpdf.DtToXls(dtSiireChk, "売上チェックリスト", outFile, 3, 1, header);

                        this.Cursor = Cursors.Default;

                        // メッセージボックスの処理、Excel作成完了の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "Excelファイルを作成しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessagebox.ShowDialog();
                    }
                }
                else
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                // エラーロギング
                new CommonException(ex);

                // Excel出力失敗メッセージ
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "Excel出力に失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

        /// <summary>
        /// dataCheack
        /// データチェック処理(グリッドビュー表示)
        /// </summary>
        private Boolean dataCheack()
        {
            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            // 空文字判定（入力開始期間）
            if (txtNyuryokuYMDstart.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtNyuryokuYMDstart.Focus();
                return false;
            }

            // 空文字判定（入力終了期間）
            if (txtNyuryokuYMDend.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtNyuryokuYMDend.Focus();
                return false;
            }

            // 空文字判定（開始伝票年月日）
            if (txtDenpyoYMDstart.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtDenpyoYMDstart.Focus();
                return false;
            }

            // 空文字判定（終了伝票年月日）
            if (txtDenpyoYMDend.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtDenpyoYMDend.Focus();
                return false;
            }

            //日付フォーマット生成、およびチェック
            strYMDformat = txtNyuryokuYMDstart.chkDateDataFormat(txtNyuryokuYMDstart.Text);

            //開始入力年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtNyuryokuYMDstart.Focus();

                return false;
            }
            else
            {
                txtNyuryokuYMDstart.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtNyuryokuYMDend.chkDateDataFormat(txtNyuryokuYMDend.Text);

            //終了入力年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtNyuryokuYMDend.Focus();

                return false;
            }
            else
            {
                txtNyuryokuYMDend.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtDenpyoYMDstart.chkDateDataFormat(txtDenpyoYMDstart.Text);

            //開始伝票年月日の日付チェック
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

            //終了伝票年月日の日付チェック
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

        ///<summary>
        ///txtUriageCheckPrint_KeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void txtUriageCheckPrint_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
