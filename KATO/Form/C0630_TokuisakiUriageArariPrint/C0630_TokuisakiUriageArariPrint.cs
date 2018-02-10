using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.C0630_TokuisakiUriageArariPrint;

namespace KATO.Form.C0630_TokuisakiUriageArariPrint
{
    /// <summary>
    /// C0630_TokuisakiUriageArariPrint
    /// 得意先別売上管理表フォーム
    /// 作成者：多田
    /// 作成日：2017/7/28
    /// 更新者：多田
    /// 更新日：2017/7/28
    /// カラム論理名
    /// </summary>
    public partial class C0630_TokuisakiUriageArariPrint : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// C0630_TokuisakiUriageArariPrint
        /// フォーム関係の設定
        /// </summary>
        public C0630_TokuisakiUriageArariPrint(Control c)
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
        /// C0630_TokuisakiUriageArariPrint_Load
        /// 読み込み時
        /// </summary>
        private void C0630_TokuisakiUriageArariPrint_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "得意先別売上管理表";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // 閲覧権限がある場合
            if (("1").Equals(this.etsuranFlg))
            {
                txtYmdFrom.ReadOnly = false;
                txtYmdTo.ReadOnly = false;
            }
            else
            {
                txtYmdFrom.ReadOnly = true;
                txtYmdTo.ReadOnly = true;
            }

            // 開始年月日、終了年月日の設定
            txtYmdFrom.setUp(1);
            txtYmdTo.setUp(2);
        }

        /// <summary>
        /// C0630_TokuisakiUriageArariPrint_KeyDown
        /// キー入力判定
        /// </summary>
        private void C0630_TokuisakiUriageArariPrint_KeyDown(object sender, KeyEventArgs e)
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

            // 検索するデータをリストに格納
            lstSearchItem.Add(txtYmdFrom.Text);
            lstSearchItem.Add(txtYmdTo.Text);

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

            // ビジネス層のインスタンス生成
            C0630_TokuisakiUriageArariPrint_B uriagePrint_B = new C0630_TokuisakiUriageArariPrint_B();
            try
            {
                // 検索実行
                DataTable dtUriage = uriagePrint_B.getUriage(lstSearchItem);

                // 対象データがある場合
                if (dtUriage != null && dtUriage.Rows.Count > 0)
                {
                    // 並べ替え（グループコード、担当者コード、得意先コード）
                    DataView dvUriage = new DataView(dtUriage);
                    dvUriage.Sort = "グループコード, 担当者コード, 得意先コード";
                    dtUriage = dvUriage.ToTable();

                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_B4, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // PDF作成
                        String strFile = uriagePrint_B.dbToPdf(dtUriage, lstSearchItem);

                        // プレビュー
                        pf.execPreview(strFile);
                        pf.ShowDialog(this);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // PDF作成
                        String strFile = uriagePrint_B.dbToPdf(dtUriage, lstSearchItem);

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

        /// <summary>
        /// blnDataCheack
        /// データチェック処理
        /// </summary>
        private Boolean blnDataCheack()
        {
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
            if (!("1").Equals(etsuranFlg))
            {
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

            return true;
        }

    }
}
