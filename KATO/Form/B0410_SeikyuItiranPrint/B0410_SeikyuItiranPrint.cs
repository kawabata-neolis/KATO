using KATO.Business.B0410_SeikyuItiranPrint;
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

namespace KATO.Form.B0410_SeikyuItiranPrint
{
    ///<summary>
    ///B0410_SeikyuItiranPrint
    ///請求一覧表
    ///作成者：太田
    ///作成日：2017/07/10
    ///更新者：
    ///更新日：
    ///</summary>
    public partial class B0410_SeikyuItiranPrint : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// D0410_SeikyuItiranPrint
        /// フォーム関係の設定
        /// </summary>
        public B0410_SeikyuItiranPrint(Control c)
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

        private void B0410_SeikyuItiranPrint_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "請求一覧表";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            //初期表示
            labelSet_TokuisakiStart.SearchOn = false;
            labelSet_TokuisakiEnd.SearchOn = false;
            labelSet_TokuisakiStart.CodeTxtText = "0000";
            labelSet_TokuisakiEnd.CodeTxtText = "9999";

            //左寄せ
            txtSimekiribiCd.TextAlign = HorizontalAlignment.Left;

            radSetSort.radbtn1.Checked = true;

            txtSimekiriYMD.Focus();
        }

        /// <summary>
        /// B0410_SeikyuItiranPrint_KeyDown
        /// キー入力判定
        /// </summary>
        private void B0410_SeikyuItiranPrint_KeyDown(object sender, KeyEventArgs e)
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
        /// judNyukinCheckKeyDown
        /// キー入力判定(テキストボックス【締切日コードのみ】)
        /// </summary>
        private void judSeikyuItiranKeyDown(object sender, KeyEventArgs e)
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
                    // タブ機能
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
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            string tmp1;
            string tmp2;

            tmp1 = labelSet_TokuisakiStart.CodeTxtText;
            tmp2 = labelSet_TokuisakiEnd.CodeTxtText;

            //画面の項目内を白紙にする
            delFormClear(this, null);

            labelSet_TokuisakiStart.CodeTxtText = tmp1;
            labelSet_TokuisakiEnd.CodeTxtText = tmp2;
        }

        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            //待機状態
            Cursor.Current = Cursors.WaitCursor;

            // データチェック処理
            if (!dataCheack())
            {
                //元に戻す
                Cursor.Current = Cursors.Default;
                return;
            }

            // データ検索用
            List<string> lstSearchItem = new List<string>();


            // ビジネス層のインスタンス生成
            B0410_SeikyuItiranPrint_B seikyuitiranprintB = new B0410_SeikyuItiranPrint_B();
            try
            {
                 

                // 検索するデータをリストに格納
                lstSearchItem.Add(txtSimekiriYMD.Text);
                lstSearchItem.Add(txtKaisiYMD.Text);
                lstSearchItem.Add(labelSet_TokuisakiStart.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiEnd.CodeTxtText);
                lstSearchItem.Add(txtSimekiribiCd.Text);
                if (radSetSort.judCheckBtn() == 0)
                {
                    lstSearchItem.Add("1");
                }
                else if (radSetSort.judCheckBtn() == 1)
                {
                    lstSearchItem.Add("2");
                }
                else
                {
                    lstSearchItem.Add("3");
                }
                lstSearchItem.Add(Environment.UserName);


                // 検索実行（印刷用）
                DataTable dtSeikyuItiran = seikyuitiranprintB.getSeikyuItiran(lstSearchItem);

                // レコードが0件だった場合は終了）
                if (dtSeikyuItiran.Rows.Count <= 0)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    //元に戻す
                    Cursor.Current = Cursors.Default;
                    return;
                }

                //元に戻す
                Cursor.Current = Cursors.Default;

                //プリントダイアログ！
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_B4, CommonTeisu.YOKO);

                pf.ShowDialog(this);
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    //待機状態
                    Cursor.Current = Cursors.WaitCursor;

                    // PDF作成
                    string strFile = seikyuitiranprintB.dbToPdf(dtSeikyuItiran, lstSearchItem);
                    pf.execPreview(@strFile);
                }
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    //待機状態
                    Cursor.Current = Cursors.WaitCursor;

                    // PDF作成
                    string strFile = seikyuitiranprintB.dbToPdf(dtSeikyuItiran, lstSearchItem);

                    // 用紙サイズ、印刷方向はインスタンス生成と同じ値を入れる
                    // ダイアログ表示時は最後の引数はtrue
                    // （ダイアログ非経由の直接印刷時は先頭引数にプリンタ名を入れ、最後の引数をfalseに）
                    pf.execPrint(null, @strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
                }

                //元に戻す
                Cursor.Current = Cursors.Default;
                pf.Dispose();

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //元に戻す
                Cursor.Current = Cursors.Default;
                return;
            }

        }

        /// <summary>
        /// dataCheack
        /// データチェック処理
        /// </summary>
        private Boolean dataCheack()
        {
            // 空文字判定（締切年月日）
            if (txtSimekiriYMD.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSimekiriYMD.Focus();
                return false;
            }
            else
            {
                // 日付フォーマットチェック
                string datedata = txtSimekiriYMD.chkDateDataFormat(txtSimekiriYMD.Text);
                if ("".Equals(datedata))
                {
                    // メッセージボックスの処理
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
                else
                {
                    txtSimekiriYMD.Text = datedata;
                }
            }

            // 空文字判定（開始年月日）
            if (txtKaisiYMD.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtKaisiYMD.Focus();
                return false;
            }
            else
            {
                // 日付フォーマットチェック
                string datedata = txtKaisiYMD.chkDateDataFormat(txtKaisiYMD.Text);
                if ("".Equals(datedata))
                {
                    // メッセージボックスの処理
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
                else
                {
                    txtKaisiYMD.Text = datedata;
                }
            }


            // 空文字判定（締切日コード）
            if (txtSimekiribiCd.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSimekiribiCd.Focus();
                return false;
            }

            // 空文字判定（開始得意先コード）
            if (labelSet_TokuisakiStart.codeTxt.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_TokuisakiStart.Focus();
                return false;
            }
            else
            {
                // 入力チェック（得意先コード（取引先））
                if (labelSet_TokuisakiStart.chkTxtTorihikisaki())
                {
                    return false;
                }
            }

            // 空文字判定（終了得意先コード）
            if (labelSet_TokuisakiEnd.codeTxt.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_TokuisakiEnd.Focus();
                return false;
            }
            else
            {
                // 入力チェック（得意先コード（取引先））
                if (labelSet_TokuisakiEnd.chkTxtTorihikisaki())
                {
                    return false;
                }
            }

            //string tmp1 = DateTime.Parse(txtSimekiriYMD.Text).DayOfWeek.ToString("d");
            string tmp1 = DateTime.Parse(txtSimekiriYMD.Text).ToString("dd");

            if (tmp1 != txtSimekiribiCd.Text)
            {
                // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this,"締日付の確認", "締切年月日の日付と締切日コードが違います。\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                // NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

        //締切年月日の前月翌日を取得する。
        private void ZengetuYokugetuSyutoku()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();


            // ビジネス層のインスタンス生成
            B0410_SeikyuItiranPrint_B seikyuitiranprintB = new B0410_SeikyuItiranPrint_B();
            try
            {
                // 検索するデータをリストに格納
                lstSearchItem.Add(txtSimekiriYMD.Text);
               
                // 検索実行（印刷用）
                DataTable dtZengetuYokugetu = seikyuitiranprintB.getZengetuYokugetuSyutoku(lstSearchItem);

                // レコードが0件だった場合は終了）
                if (dtZengetuYokugetu.Rows.Count <= 0)
                {
                    return;
                }

                txtKaisiYMD.Text = dtZengetuYokugetu.Rows[0]["前月翌月"].ToString();


            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                return;
            }
        }

        //締切年月日のフォーカスが外れた場合の処理
        private void txtSimekiriYMD_Leave(object sender, EventArgs e)
        {
            // 空の場合処理を行わない
            if(txtSimekiriYMD.Text != "")
            {
                //前月翌月請求へ
                ZengetuYokugetuSyutoku();
            }
        }

        ///<summary>
        ///judtxtSeikyuItiranKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtSeikyuItiranKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
