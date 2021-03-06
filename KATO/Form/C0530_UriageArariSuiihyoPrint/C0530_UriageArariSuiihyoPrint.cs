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
using KATO.Business.C0530_UriageArariSuiihyoPrint;

namespace KATO.Form.C0530_UriageArariSuiihyoPrint
{
    /// <summary>
    /// C0530_UriageArariSuiihyoPrint
    /// 得意先別売上粗利推移表フォーム
    /// 作成者：多田
    /// 作成日：2017/7/20
    /// 更新者：多田
    /// 更新日：2017/7/20
    /// カラム論理名
    /// </summary>
    public partial class C0530_UriageArariSuiihyoPrint : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// C0530_UriageArariSuiihyoPrint
        /// フォーム関係の設定
        /// </summary>
        public C0530_UriageArariSuiihyoPrint(Control c)
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
        /// C0530_UriageArariSuiihyoPrint_Load
        /// 読み込み時
        /// </summary>
        private void C0530_UriageArariSuiihyoPrint_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "得意先別売上粗利推移表";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            labelSet_TantoushaCdTo.SearchOn = false;
            labelSet_TantoushaCdFrom.SearchOn = false;
            labelSet_TokuisakiCdTo.SearchOn = false;
            labelSet_TokuisakiCdFrom.SearchOn = false;

            // ビジネス層のインスタンス生成
            C0530_UriageArariSuiihyoPrint_B suiihyoPrint_B = new C0530_UriageArariSuiihyoPrint_B();
            try
            {
                // 検索実行
                DataTable dtKikanDate = suiihyoPrint_B.getKikanDate();

                if (dtKikanDate.Rows.Count > 0)
                {
                    txtYmdFrom.Text = dtKikanDate.Rows[0]["開始年月日"].ToString();
                    txtYmdTo.Text = dtKikanDate.Rows[0]["終了年月日"].ToString();
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

        /// <summary>
        /// C0530_UriageArariSuiihyoPrint_KeyDown
        /// キー入力判定
        /// </summary>
        private void C0530_UriageArariSuiihyoPrint_KeyDown(object sender, KeyEventArgs e)
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
            // 画面の項目内を白紙にする
            delFormClear(this);

            txtYmdFrom.Focus();
        }


        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // データテーブル格納用
            List<DataTable> lstDtSuiihyo = new List<DataTable>();
            DataTable dtSuiihyo = null;

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            // 空文字判定（期間年月日（開始））
            if (txtYmdFrom.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmdFrom.Focus();

                return;
            }

            // 空文字判定（期間年月日（終了））
            if (txtYmdTo.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmdTo.Focus();

                return;
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

                return;
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

                return;
            }
            else
            {
                txtYmdTo.Text = strYMDformat;
            }

            //開始担当者コードのチェック
            if (labelSet_TantoushaCdFrom.chkTxtTantosha() == true)
            {
                labelSet_TantoushaCdFrom.Focus();

                return;
            }

            //終了担当者コードのチェック
            if (labelSet_TantoushaCdTo.chkTxtTantosha() == true)
            {
                labelSet_TantoushaCdTo.Focus();

                return;
            }

            //開始得意先コードのチェック
            if (labelSet_TokuisakiCdFrom.chkTxtTorihikisaki() == true)
            {
                labelSet_TokuisakiCdFrom.Focus();

                return;
            }

            //終了得意先コードのチェック
            if (labelSet_TokuisakiCdTo.chkTxtTorihikisaki() == true)
            {
                labelSet_TokuisakiCdTo.Focus();

                return;
            }

            // 検索するデータをリストに格納
            lstSearchItem.Add(txtYmdFrom.Text);
            lstSearchItem.Add(txtYmdTo.Text);

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
            // 得意先コード（開始）が空の場合
            if (labelSet_TokuisakiCdFrom.CodeTxtText.Equals(""))
            {
                lstSearchItem.Add("0000");
            }
            else
            {
                lstSearchItem.Add(labelSet_TokuisakiCdFrom.CodeTxtText);
            }
            // 得意先コード（終了）が空の場合
            if (labelSet_TokuisakiCdTo.CodeTxtText.Equals(""))
            {
                lstSearchItem.Add("9999");
            }
            else
            {
                lstSearchItem.Add(labelSet_TokuisakiCdTo.CodeTxtText);
            }

            // グループ
            lstSearchItem.Add(rsGroup.judCheckBtn().ToString());

            // 出力先の選択が得意先別売上推移表の場合
            if (radSet_2btn.radbtn0.Checked)
            {
                lstSearchItem.Add("0");
            }
            else
            {
                lstSearchItem.Add("1");
            }

            // ビジネス層のインスタンス生成
            C0530_UriageArariSuiihyoPrint_B suiihyoPrint_B = new C0530_UriageArariSuiihyoPrint_B();
            try
            {
                int cntYear = 0;
                Boolean blnData = false;
                DateTime dtYmdFrom = DateTime.Parse(lstSearchItem[0]);
                DateTime dtYmdTo = DateTime.Parse(lstSearchItem[1]);

                // 期間の年数計算
                while (true)
                {
                    dtYmdFrom = dtYmdFrom.AddYears(1);
                    cntYear += 1;
                    if (dtYmdFrom.CompareTo(dtYmdTo) > 0)
                    {
                        break;
                    }
                }

                this.Cursor = Cursors.WaitCursor;

                for (int cnt = 0; cnt < cntYear; cnt++)
                {
                    // 検索実行
                    dtSuiihyo = suiihyoPrint_B.getSuiihyo(lstSearchItem);
                    lstDtSuiihyo.Add(dtSuiihyo);

                    // 対象データがある場合、フラグ(blnData)にtrueをセット
                    if (dtSuiihyo != null && dtSuiihyo.Rows.Count > 0)
                    {
                        blnData = true;
                    }

                    // 開始年月日を1年後にする
                    dtYmdFrom = DateTime.Parse(lstSearchItem[0]);
                    dtYmdFrom = dtYmdFrom.AddYears(1);
                    lstSearchItem[0] = dtYmdFrom.ToString();
                }

                this.Cursor = Cursors.Default;

                // 対象データがある場合
                if (blnData)
                {
                    lstSearchItem[0] = txtYmdFrom.Text;

                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_B4, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        // PDF作成
                        String strFile = suiihyoPrint_B.dbToPdf(lstDtSuiihyo, lstSearchItem);

                        this.Cursor = Cursors.Default;

                        // プレビュー
                        pf.execPreview(strFile);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        // PDF作成
                        String strFile = suiihyoPrint_B.dbToPdf(lstDtSuiihyo, lstSearchItem);

                        this.Cursor = Cursors.Default;

                        // 一括印刷
                        pf.execPrint(null, strFile, CommonTeisu.SIZE_B4, CommonTeisu.YOKO, true);
                    }

                    pf.Dispose();
                }
                else
                {
                    this.Cursor = Cursors.Default;

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

    }
}
