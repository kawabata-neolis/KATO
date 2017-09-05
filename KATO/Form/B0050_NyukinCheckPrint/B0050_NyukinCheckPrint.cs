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
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.B0050_NyukinCheckPrint;

namespace KATO.Form.B0050_NyukinCheckPrint
{
    /// <summary>
    /// B0050_NyukinCheckPrint
    /// 入金チェックリストフォーム
    /// 作成者：多田
    /// 作成日：2017/7/25
    /// 更新者：多田
    /// 更新日：2017/7/25
    /// カラム論理名
    /// </summary>
    public partial class B0050_NyukinCheckPrint : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// B0050_NyukinCheakPrint
        /// フォーム関係の設定
        /// </summary>
        public B0050_NyukinCheckPrint(Control c)
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
        /// B0050_NyukinCheckPrint_Load
        /// 読み込み時
        /// </summary>
        private void B0050_NyukinCheckPrint_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "入金チェックリスト";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
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
        }

        /// <summary>
        /// B0050_NyukinCheckPrint_KeyDown
        /// キー入力判定
        /// </summary>
        private void B0050_NyukinCheckPrint_KeyDown(object sender, KeyEventArgs e)
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
            // 入力年月日の設定
            txtInputYMDStart.setUp(0);
            txtInputYMDEnd.setUp(0);

            // 伝票年月日の設定
            txtDenpyoYMDStart.setUp(0);
            txtDenpyoYMDEnd.setUp(0);

            labelSet_TokuisakiCdFrom.CodeTxtText = "";
            labelSet_TokuisakiCdTo.CodeTxtText = "";

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

            // ビジネス層のインスタンス生成
            B0050_NyukinCheckPrint_B checkPrintB = new B0050_NyukinCheckPrint_B();
            try
            {
                // 検索するデータをリストに格納
                lstSearchItem.Add(txtInputYMDStart.Text);
                lstSearchItem.Add(txtInputYMDEnd.Text);
                lstSearchItem.Add(txtDenpyoYMDStart.Text);
                lstSearchItem.Add(txtDenpyoYMDEnd.Text);
                lstSearchItem.Add(txtUserId.Text);
                lstSearchItem.Add(labelSet_TokuisakiCdFrom.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiCdTo.CodeTxtText);

                // 検索実行
                DataTable dtNyukinCheckList = checkPrintB.getNyukinCheckList(lstSearchItem);

                if (dtNyukinCheckList != null && dtNyukinCheckList.Rows.Count > 0)
                {
                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // PDF作成
                        String strFile = checkPrintB.dbToPdf(dtNyukinCheckList, lstSearchItem);

                        // プレビュー
                        pf.execPreview(strFile);
                        pf.ShowDialog(this);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // PDF作成
                        String strFile = checkPrintB.dbToPdf(dtNyukinCheckList, lstSearchItem);

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

                // メッセージボックスの処理、PDF作成失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "印刷が失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }

        }

    }
}
