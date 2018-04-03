using KATO.Business.C0650_SyohingunUriageSiirePrint;
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

namespace KATO.Form.C0650_SyohingunUriageSiirePrint
{
    ///<summary>
    ///C0650_SyohingunUriageSiirePrint
    ///請求一覧表
    ///作成者：太田
    ///作成日：2017/07/20
    ///更新者：
    ///更新日：
    ///</summary>
    public partial class C0650_SyohingunUriageSiirePrint : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// C0650_SyohingunUriageSiirePrint
        /// フォーム関係の設定
        /// </summary>
        public C0650_SyohingunUriageSiirePrint(Control c)
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

        private void C0650_SyohingunUriageSiirePrint_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品群別売上仕入管理表";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            //初期表示
            DateTime dtToday = DateTime.Now;

            //本日の年を取得する。
            int yy = dtToday.Year;

            //本日の月を取得する。
            int mm = dtToday.Month;

            if (mm >= 5 && mm <= 12)
            {
                txtKamikiYMDopen.Text = yy.ToString()+"/05"+"/01";

                txtKamikiYMDclose.Text = (DateTime.Parse(txtKamikiYMDopen.Text).AddMonths(6)).ToString();
                txtKamikiYMDclose.Text = (DateTime.Parse(txtKamikiYMDclose.Text).AddDays(-1)).ToString();

                txtSimokiYMDopen.Text = (DateTime.Parse(txtKamikiYMDopen.Text).AddMonths(6)).ToString();

                txtSimokiYMDclose.Text = (DateTime.Parse(txtKamikiYMDopen.Text).AddMonths(12)).ToString();
                txtSimokiYMDclose.Text = (DateTime.Parse(txtSimokiYMDclose.Text).AddDays(-1)).ToString();
            }
            else
            {
                txtKamikiYMDopen.Text = (yy-1).ToString() + "/05" + "/01";

                txtKamikiYMDclose.Text = (DateTime.Parse(txtKamikiYMDopen.Text).AddMonths(6)).ToString();
                txtKamikiYMDclose.Text = (DateTime.Parse(txtKamikiYMDclose.Text).AddDays(-1)).ToString();

                txtSimokiYMDopen.Text = (DateTime.Parse(txtKamikiYMDopen.Text).AddMonths(6)).ToString();

                txtSimokiYMDclose.Text = (DateTime.Parse(txtKamikiYMDopen.Text).AddMonths(12)).ToString();
                txtSimokiYMDclose.Text = (DateTime.Parse(txtSimokiYMDclose.Text).AddDays(-1)).ToString();
            }
        }

        /// <summary>
        /// C0650_SyohingunUriageSiirePrint_KeyDown
        /// キー入力判定
        /// </summary>
        private void C0650_SyohingunUriageSiirePrint_KeyDown(object sender, KeyEventArgs e)
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
            //画面の項目内を白紙にする
            delFormClear(this, null);
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

            this.Cursor = Cursors.WaitCursor;

            // ビジネス層のインスタンス生成
            C0650_SyohingunUriageSiirePrint_B syohingunuriagesiireprintB = new C0650_SyohingunUriageSiirePrint_B();
            try
            {


                // 検索するデータをリストに格納
                lstSearchItem.Add(txtKamikiYMDopen.Text);               //[0]
                lstSearchItem.Add(txtKamikiYMDclose.Text);              //[1]
                lstSearchItem.Add(txtSimokiYMDopen.Text);               //[2]
                lstSearchItem.Add(txtSimokiYMDclose.Text);              //[3]
                //lstSearchItem.Add(labelSet_Torihikisaki.CodeTxtText);   //[4]
                //lstSearchItem.Add(labelSet_Tantousha.CodeTxtText);      //[5]
                //lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);      //[6]
                //lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);      //[7]
                //lstSearchItem.Add(labelSet_Maker.CodeTxtText);          //[8]

                // 検索実行（印刷用）
                DataTable dtSyohingunUriageSiire = syohingunuriagesiireprintB.getSyohingunUriageSiireItiran(lstSearchItem);

                this.Cursor = Cursors.Default;

                // レコードが0件だった場合は終了）
                if (dtSyohingunUriageSiire.Rows.Count <= 0)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
                
                //プリントダイアログ！
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_B4, CommonTeisu.YOKO);

                pf.ShowDialog(this);
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    this.Cursor = Cursors.WaitCursor;

                    //PDF作成
                    string strFile = syohingunuriagesiireprintB.dbToPdf(dtSyohingunUriageSiire);

                    this.Cursor = Cursors.Default;

                    pf.execPreview(@strFile);
                }
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    this.Cursor = Cursors.WaitCursor;

                    //PDF作成
                    string strFile = syohingunuriagesiireprintB.dbToPdf(dtSyohingunUriageSiire);

                    this.Cursor = Cursors.Default;

                    // 用紙サイズ、印刷方向はインスタンス生成と同じ値を入れる
                    // ダイアログ表示時は最後の引数はtrue
                    // （ダイアログ非経由の直接印刷時は先頭引数にプリンタ名を入れ、最後の引数をfalseに）
                    pf.execPrint(null, @strFile, CommonTeisu.SIZE_B4, CommonTeisu.YOKO, true);
                }

                pf.Dispose();

            }
            catch (Exception ex)
            {
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
        /// dataCheack
        /// データチェック処理(グリッドビュー表示)
        /// </summary>
        private Boolean dataCheack()
        {
            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            // 空文字判定（上期開始年月日）
            if (txtKamikiYMDopen.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtKamikiYMDopen.Focus();
                return false;
            }

            // 空文字判定（上期終了年月日）
            if (txtKamikiYMDclose.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtKamikiYMDclose.Focus();
                return false;
            }


            // 空文字判定（下期開始年月日）
            if (txtSimokiYMDopen.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSimokiYMDopen.Focus();
                return false;
            }

            // 空文字判定（下期終了年月日）
            if (txtSimokiYMDclose.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSimokiYMDclose.Focus();
                return false;
            }

            //日付フォーマット生成、およびチェック
            strYMDformat = txtKamikiYMDopen.chkDateDataFormat(txtKamikiYMDopen.Text);

            //開始上期年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtKamikiYMDopen.Focus();

                return false;
            }
            else
            {
                txtKamikiYMDopen.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtKamikiYMDclose.chkDateDataFormat(txtKamikiYMDclose.Text);

            //終了上期年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtKamikiYMDclose.Focus();

                return false;
            }
            else
            {
                txtKamikiYMDclose.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtSimokiYMDopen.chkDateDataFormat(txtSimokiYMDopen.Text);

            //開始下期年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtSimokiYMDopen.Focus();

                return false;
            }
            else
            {
                txtSimokiYMDopen.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtSimokiYMDclose.chkDateDataFormat(txtSimokiYMDclose.Text);

            //終了下期年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtSimokiYMDclose.Focus();

                return false;
            }
            else
            {
                txtSimokiYMDclose.Text = strYMDformat;
            }

            ////得意先チェック
            //if (labelSet_Torihikisaki.chkTxtTorihikisaki())
            //{
            //    return false;
            //}

            ////担当者チェック
            //if (labelSet_Tantousha.chkTxtTantosha())
            //{
            //    return false;
            //}

            ////大分類チェック
            //if (labelSet_Daibunrui.chkTxtDaibunrui())
            //{
            //    return false;
            //}

            ////中分類チェック
            //if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
            //{
            //    return false;
            //}

            ////メーカーチェック
            //if (labelSet_Maker.chkTxtMaker())
            //{
            //    return false;
            //}

            return true;
        }
    }
}
