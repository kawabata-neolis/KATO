﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.C0130_TantouUriageArariPrint;
using System.Linq;

namespace KATO.Form.C0130_TantouUriageArariPrint
{
    /// <summary>
    /// C0130_TantouUriageArariPrint
    /// 担当者別売上管理表フォーム
    /// 作成者：多田
    /// 作成日：2017/7/31
    /// 更新者：多田
    /// 更新日：2017/7/31
    /// カラム論理名
    /// </summary>
    public partial class C0130_TantouUriageArariPrint : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// C0130_TantouUriageArariPrint
        /// フォーム関係の設定
        /// </summary>
        public C0130_TantouUriageArariPrint(Control c)
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
        /// C0130_TantouUriageArariPrint_Load
        /// 読み込み時
        /// </summary>
        private void C0130_TantouUriageArariPrint_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "担当者別売上管理表";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF10.Text = "Excel出力";
            this.btnF12.Text = STR_FUNC_F12;

            // 閲覧権限がある場合
            if ("1".Equals(etsuranFlg))
            {
                txtYmdFrom.Enabled = true;
                txtYmdFrom.TabStop = true;
                txtYmdTo.Enabled = true;
                txtYmdTo.TabStop = true;
                // F11;印刷表示
                this.btnF11.Text = STR_FUNC_F11;
            }
            else
            {
                txtYmdFrom.ReadOnly = true;
                txtYmdTo.ReadOnly = true;
                // F11;印刷非表示
                this.btnF11.Text = "";
            }

            // 開始年月日、終了年月日の設定
            txtYmdFrom.setUp(1);
            txtYmdTo.setUp(2);

            labelSet_EigyoshoCdFrom.SearchOn = false;
            labelSet_EigyoshoCdTo.SearchOn = false;

            labelSet_GroupCdFrom.SearchOn = false;
            labelSet_GroupCdTo.SearchOn = false;

            labelSet_TantoushaCdFrom.SearchOn = false;
            labelSet_TantoushaCdTo.SearchOn = false;

            // ステータスバーにメッセージ
            this.lblStatusMessage.Text = "F9を押すと、一覧選択または検索ができます";
        }

        /// <summary>
        /// C0130_TantouUriageArariPrint_KeyDown
        /// キー入力判定
        /// </summary>
        private void C0130_TantouUriageArariPrint_KeyDown(object sender, KeyEventArgs e)
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
                    if ("1".Equals(etsuranFlg))
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "Excel出力"));
                        this.exportXls();
                    }
                    break;
                case Keys.F11:
                    if ("1".Equals(etsuranFlg))
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
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F10: // 印刷
                    if ("1".Equals(etsuranFlg))
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "Excel出力"));
                        this.exportXls();
                    }
                    break;
                case STR_BTN_F11: // 印刷
                    if ("1".Equals(etsuranFlg))
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
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // 削除するデータ以外を確保
            string strGroupCdFrom = labelSet_GroupCdFrom.CodeTxtText;
            string strGroupCdTo = labelSet_GroupCdTo.CodeTxtText;

            // 画面の項目内を白紙にする
            delFormClear(this);

            labelSet_GroupCdFrom.CodeTxtText = strGroupCdFrom;
            labelSet_GroupCdTo.CodeTxtText = strGroupCdTo;
        }

        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // データチェック
            if (!blnDataCheack())
            {
                return;
            }

            //待機状態
            Cursor.Current = Cursors.WaitCursor;

            // 検索するデータをリストに格納
            lstSearchItem.Add(txtYmdFrom.Text);
            lstSearchItem.Add(txtYmdTo.Text);

            // 営業所コード（開始）が空の場合
            if (labelSet_EigyoshoCdFrom.CodeTxtText.Equals(""))
            {
                lstSearchItem.Add("0000");
            }
            else
            {
                lstSearchItem.Add(labelSet_EigyoshoCdFrom.CodeTxtText);
            }
            // 営業所コード（終了）が空の場合
            if (labelSet_EigyoshoCdTo.CodeTxtText.Equals(""))
            {
                lstSearchItem.Add("9999");
            }
            else
            {
                lstSearchItem.Add(labelSet_EigyoshoCdTo.CodeTxtText);
            }

            // グループコード（開始）が空の場合
            if (labelSet_GroupCdFrom.CodeTxtText.Equals(""))
            {
                lstSearchItem.Add("0000");
            }
            else
            {
                lstSearchItem.Add(labelSet_GroupCdFrom.CodeTxtText);
            }
            // グループコード（終了）が空の場合
            if (labelSet_GroupCdTo.CodeTxtText.Equals(""))
            {
                lstSearchItem.Add("9999");
            }
            else
            {
                lstSearchItem.Add(labelSet_GroupCdTo.CodeTxtText);
            }

            // 担当者コード（開始）が空の場合
            if (labelSet_TantoushaCdFrom.CodeTxtText.Equals(""))
            {
                lstSearchItem.Add("0000");
            }
            else
            {
                lstSearchItem.Add(labelSet_TantoushaCdFrom.CodeTxtText);
            }
            // 担当者コード（終了）が空の場合
            if (labelSet_TantoushaCdTo.CodeTxtText.Equals(""))
            {
                lstSearchItem.Add("9999");
            }
            else
            {
                lstSearchItem.Add(labelSet_TantoushaCdTo.CodeTxtText);
            }

            // 経過月数
            lstSearchItem.Add(intDateDiff(txtYmdFrom.Text, txtYmdTo.Text).ToString());

            // ビジネス層のインスタンス生成
            C0130_TantouUriageArariPrint_B uriagePrint_B = new C0130_TantouUriageArariPrint_B();
            try
            {
                // 検索実行
                DataTable dtUriage = uriagePrint_B.getUriage(lstSearchItem);

                // 対象データがある場合
                if (dtUriage != null && dtUriage.Rows.Count > 0)
                {
                    //元に戻す
                    Cursor.Current = Cursors.Default;

                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, CommonTeisu.YOKO);
                    pf.lblBusu.Visible = true;
                    pf.txtBusu.Visible = true;
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // カーソルを待機状態にする
                        this.Cursor = Cursors.WaitCursor;

                        // PDF作成
                        String strFile = uriagePrint_B.dbToPdf(dtUriage, lstSearchItem, null, 0);

                        // プレビュー
                        //pf.execPreview(strFile);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // カーソルを待機状態にする
                        this.Cursor = Cursors.WaitCursor;

                        string s = pf.txtBusu.Text;

                        int num = 0;

                        if (!string.IsNullOrWhiteSpace(s))
                        {
                            num = int.Parse(s);
                        }

                        // PDF作成
                        String strFile = uriagePrint_B.dbToPdf(dtUriage, lstSearchItem, pf.printer, num);

                        // 一括印刷
                        //pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
                    }
                    // カーソルの状態を元に戻す
                    this.Cursor = Cursors.Default;

                    pf.Dispose();
                }
                else
                {
                    // カーソルの状態を元に戻す
                    this.Cursor = Cursors.Default;

                    // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                // カーソルの状態を元に戻す
                this.Cursor = Cursors.Default;

                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、PDF作成失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "印刷が失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

        /// <summary>
        /// F10：Excel出力
        /// </summary>
        private void exportXls()
        {
            // SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();
            // ファイル名の指定
            sfd.FileName = "担当者別売上管理表_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xlsx";
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

                // データチェック
                if (!blnDataCheack())
                {
                    return;
                }

                //待機状態
                Cursor.Current = Cursors.WaitCursor;

                // 検索するデータをリストに格納
                lstSearchItem.Add(txtYmdFrom.Text);
                lstSearchItem.Add(txtYmdTo.Text);

                // 営業所コード（開始）が空の場合
                if (labelSet_EigyoshoCdFrom.CodeTxtText.Equals(""))
                {
                    lstSearchItem.Add("0000");
                }
                else
                {
                    lstSearchItem.Add(labelSet_EigyoshoCdFrom.CodeTxtText);
                }
                // 営業所コード（終了）が空の場合
                if (labelSet_EigyoshoCdTo.CodeTxtText.Equals(""))
                {
                    lstSearchItem.Add("9999");
                }
                else
                {
                    lstSearchItem.Add(labelSet_EigyoshoCdTo.CodeTxtText);
                }

                // グループコード（開始）が空の場合
                if (labelSet_GroupCdFrom.CodeTxtText.Equals(""))
                {
                    lstSearchItem.Add("0000");
                }
                else
                {
                    lstSearchItem.Add(labelSet_GroupCdFrom.CodeTxtText);
                }
                // グループコード（終了）が空の場合
                if (labelSet_GroupCdTo.CodeTxtText.Equals(""))
                {
                    lstSearchItem.Add("9999");
                }
                else
                {
                    lstSearchItem.Add(labelSet_GroupCdTo.CodeTxtText);
                }

                // 担当者コード（開始）が空の場合
                if (labelSet_TantoushaCdFrom.CodeTxtText.Equals(""))
                {
                    lstSearchItem.Add("0000");
                }
                else
                {
                    lstSearchItem.Add(labelSet_TantoushaCdFrom.CodeTxtText);
                }
                // 担当者コード（終了）が空の場合
                if (labelSet_TantoushaCdTo.CodeTxtText.Equals(""))
                {
                    lstSearchItem.Add("9999");
                }
                else
                {
                    lstSearchItem.Add(labelSet_TantoushaCdTo.CodeTxtText);
                }

                // 経過月数
                lstSearchItem.Add(intDateDiff(txtYmdFrom.Text, txtYmdTo.Text).ToString());

                // ビジネス層のインスタンス生成
                C0130_TantouUriageArariPrint_B uriagePrint_B = new C0130_TantouUriageArariPrint_B();

                // 検索実行
                DataTable dtUriage = uriagePrint_B.getUriage(lstSearchItem);

                // カーソルを戻す
                this.Cursor = Cursors.Default;

                // 対象データがある場合
                if (dtUriage != null && dtUriage.Rows.Count > 0)
                {
                    // ダイアログ表示
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //待機状態
                        Cursor.Current = Cursors.WaitCursor;

                        CreatePdf cpdf = new CreatePdf();

                        // 出力するヘッダを設定
                        string[] header =
                        {
                            "営業所名",
                            "グループ名",
                            "担当者名",
                            "売上額",
                            "粗利額",
                            "粗利率",
                            "指定期間内受注残金額",
                            "指定期間内受注残粗利",
                            "指定期間以降受注残金額",
                            "指定期間以降受注残粗利",
                            "月末売掛金残",
                            "当月入金額",
                            "月目標",
                            "期間達成率",
                    };

                        // Linqで出力対象の項目をSelect
                        // カラム名は以下のようにつける(カラム名でフォーマットを判断するため)
                        // 金額関係：＊＊＊kingaku
                        // 単価関係：＊＊＊tanka
                        // 原価：＊＊＊genka
                        // 数量：＊＊＊suryo
                        var outDat = dtUriage.AsEnumerable()
                            .Select(dat => new
                            {
                                eigyosyoName = dat["営業所名"],
                                groupName = dat["グループ名"],
                                tantoName = dat["担当者名"],
                                uriageKingaku = dat["売上額"],
                                arariKingaku = dat["粗利額"],
                                arariritu = dat["粗利率"],
                                getumatuJuchuzanKingaku = dat["月末迄受注残売上"],
                                getumatuJuchuarariKingaku = dat["月末迄受注残粗利"],
                                yokugetuJuchuzankingaku = dat["翌月以降受注残売上"],
                                yokugetuJuchuarariKingaku = dat["翌月以降受注残粗利"],
                                urikakezanKingaku = dat["月末売掛金残"],
                                nyuKingaku = dat["当月入金額"],
                                tougetuzanKingaku = dat["年間売上目標"],
                                taseiritu = dat["達成率"],
                            }).ToList();

                        // listをDataTableに変換
                        DataTable dtTantoArari = cpdf.ConvertToDataTable(outDat);

                        string outFile = sfd.FileName;

                        cpdf.DtToXls(dtTantoArari, "担当者別売上管理表", outFile, 3, 1, header);

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

                    //元に戻す
                    Cursor.Current = Cursors.Default;
                    return;
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // Excel出力失敗メッセージ
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "Excel出力に失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

        /// <summary>
        /// blnDataCheack
        /// データチェック処理
        /// </summary>
        private Boolean blnDataCheack()
        {
            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            // 空文字判定（開始年月日）
            if (txtYmdFrom.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmdFrom.Focus();

                return false;
            }

            // 空文字判定（終了年月日）
            if (txtYmdTo.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmdTo.Focus();

                return false;
            }

            // 閲覧権限がない場合
            if (!"1".Equals(etsuranFlg))
            {
                // 空文字判定（営業所コード（開始））
                if (labelSet_EigyoshoCdFrom.CodeTxtText.Equals(""))
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    labelSet_EigyoshoCdFrom.Focus();

                    return false;
                }

                // 空文字判定（営業所コード（終了））
                if (labelSet_EigyoshoCdTo.CodeTxtText.Equals(""))
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    labelSet_EigyoshoCdTo.Focus();

                    return false;
                }

                // 空文字判定（グループコード（開始））
                if (labelSet_GroupCdFrom.CodeTxtText.Equals(""))
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    labelSet_GroupCdFrom.Focus();

                    return false;
                }

                // 空文字判定（グループコード（終了））
                if (labelSet_GroupCdTo.CodeTxtText.Equals(""))
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    labelSet_GroupCdTo.Focus();

                    return false;
                }
            }

            //日付フォーマット生成、およびチェック
            strYMDformat = txtYmdFrom.chkDateDataFormat(txtYmdFrom.Text);

            //開始年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmdFrom.Focus();

                return false;
            }
            else
            {
                txtYmdFrom.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtYmdTo.chkDateDataFormat(txtYmdTo.Text);

            //終了年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmdTo.Focus();

                return false;
            }
            else
            {
                txtYmdTo.Text = strYMDformat;
            }

            //営業所コードの検索開始のチェック
            if (labelSet_EigyoshoCdFrom.chkTxtEigyousho() == true)
            {
                labelSet_EigyoshoCdFrom.Focus();

                return false;
            }

            //営業所コードの検索終了のチェック
            if (labelSet_EigyoshoCdTo.chkTxtEigyousho() == true)
            {
                labelSet_EigyoshoCdTo.Focus();

                return false;
            }

            //グループコードの検索開始のチェック
            if (labelSet_GroupCdFrom.chkTxtGroupCd() == true)
            {
                labelSet_GroupCdFrom.Focus();

                return false;
            }

            //グループコードの検索終了のチェック
            if (labelSet_GroupCdTo.chkTxtGroupCd() == true)
            {
                labelSet_GroupCdTo.Focus();

                return false;
            }

            //担当者コードの検索開始のチェック
            if (labelSet_TantoushaCdFrom.chkTxtTantosha() == true)
            {
                labelSet_TantoushaCdFrom.Focus();

                return false;
            }

            //担当者コードの検索終了のチェック
            if (labelSet_TantoushaCdTo.chkTxtTantosha() == true)
            {
                labelSet_TantoushaCdTo.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// intDateDiff
        /// 入力した年月日の月間隔の計算
        /// </summary>
        private int intDateDiff(string strStartYMD, string strEndYMD)
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
            diff += 1;

            return diff;
        }

    }
}
