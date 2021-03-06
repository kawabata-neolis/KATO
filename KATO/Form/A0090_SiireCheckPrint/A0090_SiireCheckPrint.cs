﻿using System;
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
using KATO.Business.A0090_SiireCheckPrint;

namespace KATO.Form.A0090_SiireCheckPrint
{
    /// <summary>
    /// A0090_SiireCheckPrint
    /// 仕入チェックリストフォーム
    /// 作成者：多田
    /// 作成日：2017/7/1
    /// 更新者：山本
    /// 更新日：2019/2/2
    /// F10：Excel出力 機能追加
    /// </summary>
    public partial class A0090_SiireCheckPrint : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// A0090_SiireCheckPrint
        /// フォーム関係の設定
        /// </summary>
        public A0090_SiireCheckPrint(Control c)
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
        }

        /// <summary>
        /// A0090_SiireCheckPrint_Load
        /// 読み込み時
        /// </summary>
        private void A0090_SiireCheckPrint_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "仕入チェックリスト";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF10.Text = "Excel出力";
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // 初期表示
            txtUserId.Focus();

            // ユーザーIDの設定
            txtUserId.Text = Environment.UserName;

            // 入力年月日の設定
            txtInputYMDStart.setUp(0);
            txtInputYMDEnd.setUp(0);

            // 伝票年月日の設定
            txtDenpyoYMDStart.setUp(1);
            txtDenpyoYMDEnd.setUp(2);

            // 初期設定
            labelSet_SiiresakiCdFrom.SearchOn = false;
            labelSet_SiiresakiCdTo.SearchOn = false;
        }

        /// <summary>
        /// A0090_SiireCheckPrint_KeyDown
        /// キー入力判定
        /// </summary>
        private void A0090_SiireCheckPrint_KeyDown(object sender, KeyEventArgs e)
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
            // 入力年月日の設定
            txtInputYMDStart.setUp(0);
            txtInputYMDEnd.setUp(0);

            // 伝票年月日の設定
            txtDenpyoYMDStart.setUp(0);
            txtDenpyoYMDEnd.setUp(0);

            labelSet_SiiresakiCdFrom.CodeTxtText = "";
            labelSet_SiiresakiCdTo.CodeTxtText = "";

            txtInputYMDStart.Focus();
        }


        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            // 空文字判定（入力年月日（開始））
            if (txtInputYMDStart.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtInputYMDStart.Focus();

                return;
            }

            // 空文字判定（入力年月日（終了））
            if (txtInputYMDEnd.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtInputYMDEnd.Focus();

                return;
            }

            // 空文字判定（伝票年月日（開始））
            if (txtDenpyoYMDStart.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDStart.Focus();

                return;
            }

            // 空文字判定（伝票年月日（終了））
            if (txtDenpyoYMDEnd.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDEnd.Focus();

                return;
            }

            //日付フォーマット生成、およびチェック
            strYMDformat = txtInputYMDStart.chkDateDataFormat(txtInputYMDStart.Text);

            //開始入力年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtInputYMDStart.Focus();

                return;
            }
            else
            {
                txtInputYMDStart.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtInputYMDEnd.chkDateDataFormat(txtInputYMDEnd.Text);

            //終了入力年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtInputYMDEnd.Focus();

                return;
            }
            else
            {
                txtInputYMDEnd.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtDenpyoYMDStart.chkDateDataFormat(txtDenpyoYMDStart.Text);

            //開始伝票年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDStart.Focus();

                return;
            }
            else
            {
                txtDenpyoYMDStart.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtDenpyoYMDEnd.chkDateDataFormat(txtDenpyoYMDEnd.Text);

            //終了伝票年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoYMDEnd.Focus();

                return;
            }
            else
            {
                txtDenpyoYMDEnd.Text = strYMDformat;
            }

            // ビジネス層のインスタンス生成
            A0090_SiireCheckPrint_B checkPrintB = new A0090_SiireCheckPrint_B();
            try
            {
                // 検索するデータをリストに格納
                lstSearchItem.Add(txtInputYMDStart.Text);
                lstSearchItem.Add(txtInputYMDEnd.Text);
                lstSearchItem.Add(txtDenpyoYMDStart.Text);
                lstSearchItem.Add(txtDenpyoYMDEnd.Text);
                lstSearchItem.Add(txtUserId.Text);
                lstSearchItem.Add(labelSet_SiiresakiCdFrom.CodeTxtText);
                lstSearchItem.Add(labelSet_SiiresakiCdTo.CodeTxtText);

                // 検索実行
                DataTable dtSiireCheckList = checkPrintB.getSiireCheckList(lstSearchItem);
                
                if (dtSiireCheckList.Rows.Count > 0)
                {
                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_B4, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // PDF作成
                        String strFile = checkPrintB.dbToPdf(dtSiireCheckList, lstSearchItem);

                        // プレビュー
                        pf.execPreview(strFile);
                        pf.ShowDialog(this);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // PDF作成
                        String strFile = checkPrintB.dbToPdf(dtSiireCheckList, lstSearchItem);

                        // 一括印刷
                        pf.execPrint(null, strFile, CommonTeisu.SIZE_B4, CommonTeisu.YOKO, true);
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

        ///<summary>
        ///     F10：Excel出力
        ///</summary>
        private void exportXls()
        {
            // SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();
            // ファイル名の指定
            sfd.FileName = "仕入チェックリスト_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xlsx";
            // デフォルトパス取得（デスクトップ）
            string Init_dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = Init_dir;
            // ファイルフィルタの設定
            sfd.Filter = "すべてのファイル(*.*)|*.*";

            try
            {
                // データ検索用
                List<string> lstSearchItem = new List<string>();

                //年月日の日付フォーマット後を入れる用
                string strYMDformat = "";

                //待機状態
                Cursor.Current = Cursors.WaitCursor;

                // 空文字判定（入力年月日（開始））
                if (txtInputYMDStart.blIsEmpty() == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtInputYMDStart.Focus();

                    return;
                }

                // 空文字判定（入力年月日（終了））
                if (txtInputYMDEnd.blIsEmpty() == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtInputYMDEnd.Focus();

                    return;
                }

                // 空文字判定（伝票年月日（開始））
                if (txtDenpyoYMDStart.blIsEmpty() == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtDenpyoYMDStart.Focus();

                    return;
                }

                // 空文字判定（伝票年月日（終了））
                if (txtDenpyoYMDEnd.blIsEmpty() == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtDenpyoYMDEnd.Focus();

                    return;
                }

                //日付フォーマット生成、およびチェック
                strYMDformat = txtInputYMDStart.chkDateDataFormat(txtInputYMDStart.Text);

                //開始入力年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtInputYMDStart.Focus();

                    return;
                }
                else
                {
                    txtInputYMDStart.Text = strYMDformat;
                }

                //初期化
                strYMDformat = "";

                //日付フォーマット生成、およびチェック
                strYMDformat = txtInputYMDEnd.chkDateDataFormat(txtInputYMDEnd.Text);

                //終了入力年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtInputYMDEnd.Focus();

                    return;
                }
                else
                {
                    txtInputYMDEnd.Text = strYMDformat;
                }

                //初期化
                strYMDformat = "";

                //日付フォーマット生成、およびチェック
                strYMDformat = txtDenpyoYMDStart.chkDateDataFormat(txtDenpyoYMDStart.Text);

                //開始伝票年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtDenpyoYMDStart.Focus();

                    return;
                }
                else
                {
                    txtDenpyoYMDStart.Text = strYMDformat;
                }

                //初期化
                strYMDformat = "";

                //日付フォーマット生成、およびチェック
                strYMDformat = txtDenpyoYMDEnd.chkDateDataFormat(txtDenpyoYMDEnd.Text);

                //終了伝票年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtDenpyoYMDEnd.Focus();

                    return;
                }
                else
                {
                    txtDenpyoYMDEnd.Text = strYMDformat;
                }

                // ビジネス層のインスタンス生成
                A0090_SiireCheckPrint_B checkPrintB = new A0090_SiireCheckPrint_B();

                // 検索するデータをリストに格納
                lstSearchItem.Add(txtInputYMDStart.Text);
                lstSearchItem.Add(txtInputYMDEnd.Text);
                lstSearchItem.Add(txtDenpyoYMDStart.Text);
                lstSearchItem.Add(txtDenpyoYMDEnd.Text);
                lstSearchItem.Add(txtUserId.Text);
                lstSearchItem.Add(labelSet_SiiresakiCdFrom.CodeTxtText);
                lstSearchItem.Add(labelSet_SiiresakiCdTo.CodeTxtText);

                // 検索実行
                DataTable dtSiireCheckList = checkPrintB.getSiireCheckList(lstSearchItem);
                // カーソルをデフォルトに戻す
                this.Cursor = Cursors.Default;

                if (dtSiireCheckList.Rows.Count > 0)
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
                            "仕入先名",
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
                        var outDat = dtSiireCheckList.AsEnumerable()
                            .Select(dat => new
                            {
                                code = dat["仕入先コード"],
                                siiresakiName = dat["仕入先名"],
                                denYmd = dat["伝票年月日"],
                                denNo = dat["伝票番号"],
                                torihikiKbn = dat["取引区分名"],
                                hinmei = dat["品名"],
                                suryo = dat["数量"],
                                siireTanka = dat["仕入単価"],
                                siireKingaku = dat["仕入金額"],
                                biko = dat["備考"],
                                zeinukiGokeiKingaku = dat["税抜合計金額"],
                                zeiKingaku = dat["消費税"],
                                zeikomiGokeiKingaku = dat["税込合計金額"],
                            }).ToList();

                        // listをDataTableに変換
                        DataTable dtSiireChk = cpdf.ConvertToDataTable(outDat);

                        string outFile = sfd.FileName;

                        cpdf.DtToXls(dtSiireChk, "仕入チェックリスト", outFile, 3, 1, header);

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

        ///<summary>
        ///txtSiireCheckPrint_KeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void txtSiireCheckPrint_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

    }
}
