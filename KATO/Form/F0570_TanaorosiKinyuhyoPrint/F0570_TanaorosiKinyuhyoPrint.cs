﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.F0570_TanaorosiKinyuhyoPrint;

namespace KATO.Form.F0570_TanaorosiKinyuhyoPrint
{
    /// <summary>
    /// F0570_TanaorosiKinyuhyoPrint
    /// 棚卸プレシートフォーム
    /// 作成者：多田
    /// 作成日：2017/7/31
    /// 更新者：多田
    /// 更新日：2017/7/31
    /// カラム論理名
    /// </summary>
    public partial class F0570_TanaorosiKinyuhyoPrint : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// F0570_TanaorosiKinyuhyoPrint
        /// フォーム関係の設定
        /// </summary>
        public F0570_TanaorosiKinyuhyoPrint(Control c)
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

            // 中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            // メーカーsetデータを読めるようにする
            labelSet_Daibunrui.Lsmakerdata = labelSet_Maker;
        }

        /// <summary>
        /// F0570_TanaorosiKinyuhyoPrint_Load
        /// 読み込み時
        /// </summary>
        private void F0570_TanaorosiKinyuhyoPrint_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "棚卸プレシート";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // 初期表示
            radSort.radbtn3.Checked = true;
            txtYmd.Focus();
        }

        /// <summary>
        /// F0570_TanaorosiKinyuhyoPrint_KeyDown
        /// キー入力判定
        /// </summary>
        private void F0570_TanaorosiKinyuhyoPrint_KeyDown(object sender, KeyEventArgs e)
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
            // 削除するデータ以外を確保
            Boolean blnPrintOnly = chkPrintOnly.Checked;

            // 画面の項目内を白紙にする
            delFormClear(this);

            chkPrintOnly.Checked = blnPrintOnly;
        }

        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // データ検索用（プロシージャ用）
            List<string> lstSearchItemProc = new List<string>();

            // データチェック
            if (!blnDataCheack())
            {
                return;
            }

            // 検索するデータをリストに格納
            lstSearchItem.Add(txtYmd.Text);
            lstSearchItem.Add(labelSet_Eigyosho.CodeTxtText);
            lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);
            lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);
            lstSearchItem.Add(labelSet_Maker.CodeTxtText);
            lstSearchItem.Add(txtTanabanFrom.Text);
            lstSearchItem.Add(txtTanabanTo.Text);

            // 検索するデータをリストに格納（プロシージャ用）
            lstSearchItemProc.Add(txtYmd.Text);
            lstSearchItemProc.Add(labelSet_Eigyosho.CodeTxtText);
            lstSearchItemProc.Add(labelSet_Daibunrui.CodeTxtText);
            lstSearchItemProc.Add((radSort.judCheckBtn() + 1).ToString());

            // ビジネス層のインスタンス生成
            F0570_TanaorosiKinyuhyoPrint_B tanaorosiPrint_B = new F0570_TanaorosiKinyuhyoPrint_B();
            try
            {
                // 印刷するにチェックが入っていない場合
                if (chkPrintOnly.Checked == false)
                {
                    // 棚卸記入表の件数を取得
                    DataTable dtTanaorosiCount = tanaorosiPrint_B.getTanaorosiCount(lstSearchItem);

                    // 対象データがある場合
                    if (dtTanaorosiCount != null && dtTanaorosiCount.Rows.Count > 0)
                    {
                        // 件数が1件以上の場合
                        if (int.Parse(dtTanaorosiCount.Rows[0][0].ToString()) > 0)
                        {
                            // メッセージボックスの処理（YES,NO）
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, "棚卸記入表", "既にデータが作成されています。書き換えますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                            // Noが押された場合
                            if (basemessagebox.ShowDialog() == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }

                    try
                    {
                        // 棚卸記入表テーブルに追加
                        tanaorosiPrint_B.addTanaorosi(lstSearchItem);
                    }
                    catch (Exception ex)
                    {
                        // エラーロギング
                        new CommonException(ex);

                        // メッセージボックスの処理、追加失敗の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        return;
                    }
                }

                // 検索実行
                DataTable dtTanaorosi = tanaorosiPrint_B.getTanaorosi(lstSearchItemProc);

                // 対象データがある場合
                if (dtTanaorosi != null && dtTanaorosi.Rows.Count > 0)
                {
                    string strFilter = "";

                    // 中分類コードがある場合
                    if (!lstSearchItem[3].Equals(""))
                    {
                        strFilter += "中分類コード = '" + lstSearchItem[3] + "'";
                    }

                    // メーカーコードがある場合
                    if (!lstSearchItem[4].Equals(""))
                    {
                        if (!strFilter.Equals(""))
                        {
                            strFilter += " AND ";
                        }
                        strFilter += "メーカーコード = '" + lstSearchItem[4] + "'";
                    }

                    // 棚番がある場合
                    if (!lstSearchItem[5].Equals("") && !lstSearchItem[6].Equals(""))
                    {
                        if (!strFilter.Equals(""))
                        {
                            strFilter += " AND ";
                        }
                        strFilter += "棚番 >= '" + lstSearchItem[5] + "' AND 棚番 <= '" + lstSearchItem[6] + "'";
                    }

                    // 対象データから更に絞り込み（中分類コード、メーカーコード、棚番）
                    if (!strFilter.Equals(""))
                    {
                        DataView dvTanaorosi = new DataView(dtTanaorosi);
                        dvTanaorosi.RowFilter = strFilter;
                        dtTanaorosi = dvTanaorosi.ToTable();

                        // 対象データがない場合
                        if (dtTanaorosi == null || dtTanaorosi.Rows.Count == 0)
                        {
                            // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                            basemessagebox.ShowDialog();

                            return;
                        }
                    }

                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, CommonTeisu.TATE);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // PDF作成
                        String strFile = tanaorosiPrint_B.dbToPdf(dtTanaorosi, lstSearchItem);

                        // プレビュー
                        pf.execPreview(strFile);
                        pf.ShowDialog(this);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // PDF作成
                        String strFile = tanaorosiPrint_B.dbToPdf(dtTanaorosi, lstSearchItem);

                        // 一括印刷
                        pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.TATE, true);
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

        /// <summary>
        /// blnDataCheack
        /// データチェック処理
        /// </summary>
        private Boolean blnDataCheack()
        {
            // 空文字判定（棚卸年月日）
            if (txtYmd.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmd.Focus();

                return false;
            }

            // 空文字判定（営業所コード）
            if (labelSet_Eigyosho.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_Eigyosho.Focus();

                return false;
            }

            return true;
        }

    }
}