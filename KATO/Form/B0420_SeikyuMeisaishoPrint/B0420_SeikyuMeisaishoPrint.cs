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
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.B0420_SeikyuMeisaishoPrint;

namespace KATO.Form.B0420_SeikyuMeisaishoPrint
{
    /// <summary>
    /// B0420_SeikyuMeisaishoPrint
    /// 請求明細書フォーム
    /// 作成者：多田
    /// 作成日：2017/7/25
    /// 更新者：多田
    /// 更新日：2017/7/25
    /// カラム論理名
    /// </summary>
    public partial class B0420_SeikyuMeisaishoPrint : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// B0420_SeikyuMeisaishoPrint
        /// フォーム関係の設定
        /// </summary>
        public B0420_SeikyuMeisaishoPrint(Control c)
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
        /// B0420_SeikyuMeisaishoPrint_Load
        /// 読み込み時
        /// </summary>
        private void B0420_SeikyuMeisaishoPrint_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "請求明細書";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // 発行年月日の設定
            txtHakkoYmd.setUp(0);

            labelSet_TokuisakiCdFrom.SearchOn = false;
            labelSet_TokuisakiCdTo.SearchOn = false;

            //左寄せ
            txtSimekiribi.TextAlign = HorizontalAlignment.Left;

        }

        /// <summary>
        /// B0420_SeikyuMeisaishoPrint_KeyDown
        /// キー入力判定
        /// </summary>
        private void B0420_SeikyuMeisaishoPrint_KeyDown(object sender, KeyEventArgs e)
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
        /// txtSimekiribi_KeyDown
        /// キー入力判定（締切日コード用）
        /// </summary>
        private void txtSimekiribi_KeyDown(object sender, KeyEventArgs e)
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
        /// txtSimekiriYmd_Leave
        /// 締切年月日の入力箇所からフォーカスが外れた時
        /// </summary>
        private void txtSimekiriYmd_Leave(object sender, EventArgs e)
        {
            // 締切年月日が空の場合
            if (txtSimekiriYmd.blIsEmpty() == false)
            {
                return;
            }

            //TryParse用
            DateTime dateTry = new DateTime();

            //年月日に変換できない場合
            if (!DateTime.TryParse(txtSimekiriYmd.Text, out dateTry))
            {
                txtSimekiriYmd.Focus();
                return;
            }

            // ビジネス層のインスタンス生成
            B0420_SeikyuMeisaishoPrint_B meisaiPrintB = new B0420_SeikyuMeisaishoPrint_B();
            try
            {
                // 請求履歴を取得
                DataTable dtGetsumatsu = meisaiPrintB.getGetsumatsu(txtSimekiriYmd.Text);

                if (dtGetsumatsu != null && dtGetsumatsu.Rows.Count > 0)
                {
                    txtStartYmd.Text = dtGetsumatsu.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // 例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            txtSimekiriYmd.Text = "";
            txtSimekiribi.Text = "";

            txtSimekiriYmd.Focus();
        }

        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();
            string stSimebi = "";

            if (string.IsNullOrWhiteSpace(txtEndDay.Text)) {
                // データチェック
                if (!blnDataCheck())
                {
                    return;
                }
                stSimebi = txtSimekiriYmd.Text;
            } else
            {
                if (!blnDataCheck2())
                {
                    return;
                }
                stSimebi = txtEndDay.Text;
            }

            // ビジネス層のインスタンス生成
            B0420_SeikyuMeisaishoPrint_B meisaiPrintB = new B0420_SeikyuMeisaishoPrint_B();
            try
            {
                // 検索するデータをリストに格納
                //lstSearchItem.Add(txtSimekiriYmd.Text);
                lstSearchItem.Add(stSimebi);
                lstSearchItem.Add(txtStartYmd.Text);
                lstSearchItem.Add(txtSimekiribi.Text);
                lstSearchItem.Add(labelSet_TokuisakiCdFrom.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiCdTo.CodeTxtText);
                lstSearchItem.Add(Environment.UserName);

                // 検索実行
                DataTable dtSeikyuMeisai = meisaiPrintB.addSeikyuMeisaisho(lstSearchItem);

                if (dtSeikyuMeisai != null && dtSeikyuMeisai.Rows.Count > 0)
                {
                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // PDF作成
                        String strFile = meisaiPrintB.dbToPdf(dtSeikyuMeisai);

                        // プレビュー
                        pf.execPreview(strFile);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // PDF作成
                        String strFile = meisaiPrintB.dbToPdf(dtSeikyuMeisai);

                        // 一括印刷
                        pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
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
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        /// <summary>
        /// blnDataCheck
        /// データチェック
        /// </summary>
        private Boolean blnDataCheck()
        {
           // 空文字判定（締切年月日）
            if (txtSimekiriYmd.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtSimekiriYmd.Focus();

                return false;
            }

            // 空文字判定（開始年月日）
            if (txtStartYmd.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtStartYmd.Focus();

                return false;
            }

            // 空文字判定（締切日コード）
            if (txtSimekiribi.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtSimekiribi.Focus();

                return false;
            }

            // 空文字判定（得意先コード（開始））
            if (labelSet_TokuisakiCdFrom.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_TokuisakiCdFrom.Focus();

                return false;
            }

            // フォーマットチェック（得意先コード（開始））
            if (labelSet_TokuisakiCdFrom.chkTxtTorihikisaki())
            {
                return false;
            }

            // 空文字判定（得意先コード（終了））
            if (labelSet_TokuisakiCdTo.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_TokuisakiCdTo.Focus();

                return false;
            }

            // フォーマットチェック（得意先コード（終了））
            if (labelSet_TokuisakiCdTo.chkTxtTorihikisaki())
            {
                return false;
            }

            // 日付フォーマットチェック（締切年月日）
            string datedata = txtSimekiriYmd.chkDateDataFormat(txtSimekiriYmd.Text);
            if ("".Equals(datedata))
            {
                // メッセージボックスの処理
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }
            else
            {
                txtSimekiriYmd.Text = datedata;
            }

            // 日付フォーマットチェック（開始年月日）
            datedata = txtStartYmd.chkDateDataFormat(txtStartYmd.Text);
            if ("".Equals(datedata))
            {
                // メッセージボックスの処理
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }
            else
            {
                txtStartYmd.Text = datedata;
            }

            // 日付フォーマットチェック（発行年月日）
            if (!"".Equals(txtHakkoYmd.Text))
            {
                // 日付フォーマットチェック（開始年月日）
                datedata = txtHakkoYmd.chkDateDataFormat(txtHakkoYmd.Text);
                if ("".Equals(datedata))
                {
                    // メッセージボックスの処理
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
                else
                {
                    txtHakkoYmd.Text = datedata;
                }

            }

            // 締切年月日の日付と締切日コードが違う場合
            if (!DateTime.Parse(txtSimekiriYmd.Text).Day.Equals(int.Parse(txtSimekiribi.Text)))
            {
                // メッセージボックスの処理（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, "締日付の確認", "締切年月日の日付と締切日コードが違います。" + "\r\n" + "続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                // Noが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return false;
                }
            }

            // 再発行の場合
            if (radSet_2btnSyurui.radbtn1.Checked)
            {
                // メッセージボックスの処理（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, "再発行の確認", "再発行をすると前回の請求履歴が破棄されます。" + "\r\n" + "よろしいですか？。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                // Noが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return false;
                }
            }

            // 通常発行の場合
            if (radSet_2btnSyurui.radbtn0.Checked)
            {
                // データ検索用
                List<string> lstSearchItem = new List<string>();

                // 検索するデータをリストに格納
                lstSearchItem.Add(labelSet_TokuisakiCdFrom.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiCdTo.CodeTxtText);
                lstSearchItem.Add(txtSimekiriYmd.Text);

                // ビジネス層のインスタンス生成
                B0420_SeikyuMeisaishoPrint_B meisaiPrintB = new B0420_SeikyuMeisaishoPrint_B();
                try
                {
                    // 請求履歴を取得
                    DataTable dtSeikyuRireki = meisaiPrintB.getSeikyuRireki(lstSearchItem);

                    if (dtSeikyuRireki != null && dtSeikyuRireki.Rows.Count > 0)
                    {
                        // 請求履歴に登録されている場合
                        if (!dtSeikyuRireki.Rows[0][0].Equals(0))
                        {
                            // メッセージボックスの処理、請求履歴に登録されている場合のウィンドウ（OK）
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, "通常発行の確認", "請求明細書はすでに発行済みです。" + "\r\n" + "取引先の範囲を限定するか、再発行をしてください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                            basemessagebox.ShowDialog();

                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // エラーロギング
                    new CommonException(ex);

                    // 例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
            }

            return true;
        }

        private Boolean blnDataCheck2()
        {
            // 空文字判定（締切年月日）
            if (txtEndDay.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtEndDay.Focus();

                return false;
            }

            // 空文字判定（開始年月日）
            if (txtStartYmd.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtStartYmd.Focus();

                return false;
            }

            // 空文字判定（締切日コード）
            if (txtSimekiribi.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtSimekiribi.Focus();

                return false;
            }

            // 空文字判定（得意先コード（開始））
            if (labelSet_TokuisakiCdFrom.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_TokuisakiCdFrom.Focus();

                return false;
            }

            // フォーマットチェック（得意先コード（開始））
            if (labelSet_TokuisakiCdFrom.chkTxtTorihikisaki())
            {
                return false;
            }

            // 空文字判定（得意先コード（終了））
            if (labelSet_TokuisakiCdTo.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_TokuisakiCdTo.Focus();

                return false;
            }

            // フォーマットチェック（得意先コード（終了））
            if (labelSet_TokuisakiCdTo.chkTxtTorihikisaki())
            {
                return false;
            }

            // 日付フォーマットチェック（締切年月日）
            string datedata = txtEndDay.chkDateDataFormat(txtEndDay.Text);
            if ("".Equals(datedata))
            {
                // メッセージボックスの処理
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }
            else
            {
                txtEndDay.Text = datedata;
            }

            // 日付フォーマットチェック（開始年月日）
            datedata = txtStartYmd.chkDateDataFormat(txtStartYmd.Text);
            if ("".Equals(datedata))
            {
                // メッセージボックスの処理
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }
            else
            {
                txtStartYmd.Text = datedata;
            }

            // 日付フォーマットチェック（発行年月日）
            if (!"".Equals(txtHakkoYmd.Text))
            {
                // 日付フォーマットチェック（開始年月日）
                datedata = txtHakkoYmd.chkDateDataFormat(txtHakkoYmd.Text);
                if ("".Equals(datedata))
                {
                    // メッセージボックスの処理
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
                else
                {
                    txtHakkoYmd.Text = datedata;
                }

            }

            // 締切年月日の日付と締切日コードが違う場合
            //if (!DateTime.Parse(txtEndDay.Text).Day.Equals(int.Parse(txtSimekiribi.Text)))
            //{
            //    // メッセージボックスの処理（YES,NO）
            //    BaseMessageBox basemessagebox = new BaseMessageBox(this, "締日付の確認", "締切年月日の日付と締切日コードが違います。" + "\r\n" + "続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

            //    // Noが押された場合
            //    if (basemessagebox.ShowDialog() == DialogResult.No)
            //    {
            //        return false;
            //    }
            //}
            // メッセージボックスの処理（YES,NO）
            BaseMessageBox mb = new BaseMessageBox(this, "締日付の確認", "月末日の日付で明細を作成します。" + "\r\n" + "続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

            // Noが押された場合
            if (mb.ShowDialog() == DialogResult.No)
            {
                return false;
            }

            // 再発行の場合
            if (radSet_2btnSyurui.radbtn1.Checked)
            {
                // メッセージボックスの処理（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, "再発行の確認", "再発行をすると前回の請求履歴が破棄されます。" + "\r\n" + "よろしいですか？。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                // Noが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return false;
                }
            }

            // 通常発行の場合
            if (radSet_2btnSyurui.radbtn0.Checked)
            {
                // データ検索用
                List<string> lstSearchItem = new List<string>();

                // 検索するデータをリストに格納
                lstSearchItem.Add(labelSet_TokuisakiCdFrom.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiCdTo.CodeTxtText);
                lstSearchItem.Add(txtEndDay.Text);

                // ビジネス層のインスタンス生成
                B0420_SeikyuMeisaishoPrint_B meisaiPrintB = new B0420_SeikyuMeisaishoPrint_B();
                try
                {
                    // 請求履歴を取得
                    DataTable dtSeikyuRireki = meisaiPrintB.getSeikyuRireki(lstSearchItem);

                    if (dtSeikyuRireki != null && dtSeikyuRireki.Rows.Count > 0)
                    {
                        // 請求履歴に登録されている場合
                        if (!dtSeikyuRireki.Rows[0][0].Equals(0))
                        {
                            // メッセージボックスの処理、請求履歴に登録されている場合のウィンドウ（OK）
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, "通常発行の確認", "請求明細書はすでに発行済みです。" + "\r\n" + "取引先の範囲を限定するか、再発行をしてください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                            basemessagebox.ShowDialog();

                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // エラーロギング
                    new CommonException(ex);

                    // 例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    return false;
                }
            }

            return true;
        }

        ///<summary>
        ///judtxtSeikyuMesaishoKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtSeikyuMesaishoKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
