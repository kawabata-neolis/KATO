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
using KATO.Business.M1100_Chokusosaki;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1100_Chokusosaki
{
    ///<summary>
    ///M1100_Chokusosaki
    ///直送先フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class M1100_Chokusosaki : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// M1100_Chokusosaki
        /// フォーム関係の設定
        /// </summary>
        public M1100_Chokusosaki(Control c)
        {
            //画面データが解放されていた時の対策
            if (c == null)
            {
                return;
            }

            //画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //最大化最小化不可
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //画面サイズを固定
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;
        }

        /// <summary>
        /// M1100_Chokusosaki_Load
        /// 画面レイアウト設定
        /// </summary>
        private void M1100_Chokusosaki_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "直送先マスタ";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;
        }

        ///<summary>
        ///M1090_Eigyosho_KeyDown
        /// キー入力判定（画面全般）
        ///</summary>
        private void M1100_Chokusosaki_KeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addChokusosaki();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delChokusosaki();
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
                    break;
                case Keys.F12:
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judChokuTxtKeyDown
        /// キー入力判定（無機能テキストボックス）
        ///</summary>
        private void judChokuTxtKeyDown(object sender, KeyEventArgs e)
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

        ///<summary>
        ///judTxtChoTxtKeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void judTxtChoTxtKeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    judtxtChokuKeyDown(sender, e);
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

        ///<summary>
        ///judBtnClick
        ///ファンクションボタンの反応
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            //ボタン入力情報によって動作を変える
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addChokusosaki();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delChokusosaki();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///judtxtChokuKeyDown
        ///キー入力判定
        ///</summary>
        private void judtxtChokuKeyDown(object sender, KeyEventArgs e)
        {
            //F9キーが押されて且つ得意先コードが入力されている場合
            if (e.KeyCode == Keys.F9 && labelSet_Tokuisaki.CodeTxtText != "")
            {
                //直送先リストのインスタンス生成
                ChokusosakiList chokusosakilist = new ChokusosakiList(this, labelSet_Tokuisaki.CodeTxtText);
                try
                {
                    //直送先リストの表示、画面IDを渡す
                    chokusosakilist.StartPosition = FormStartPosition.Manual;
                    chokusosakilist.intFrmKind = KATO.Common.Util.CommonTeisu.FRM_CHOKUSOSAKI;
                    chokusosakilist.ShowDialog();
                }
                catch (Exception ex)
                {
                    //エラーロギング
                    new CommonException(ex);
                    return;
                }
            }
        }

        ///<summary>
        ///addChokusosaki
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addChokusosaki()
        {
            //記入情報登録用
            List<string> lstChokusosaki = new List<string>();

            //取消メソッド起動前に、残す項目を確保用
            string strTokuiSub = "";

            //空文字判定（得意先コード）
            if (StringUtl.blIsEmpty(labelSet_Tokuisaki.CodeTxtText) == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tokuisaki.Focus();
                return;
            }
            //空文字判定（得意先コード）
            if (txtChokusoCd.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtChokusoCd.Focus();
                return;
            }
            //空文字判定（直送先名）
            if (txtChokusoName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtChokusoName.Focus();
                return;
            }

            //登録情報を入れる（得意先コード、直送先コード、直送先名、郵便番号、住所１、住所２、電話番号、部署名、ユーザー名）
            lstChokusosaki.Add(labelSet_Tokuisaki.codeTxt.Text);
            lstChokusosaki.Add(txtChokusoCd.Text);
            lstChokusosaki.Add(txtChokusoName.Text);
            lstChokusosaki.Add(txtYubin.Text);
            lstChokusosaki.Add(txtJusho1.Text);
            lstChokusosaki.Add(txtJusho2.Text);
            lstChokusosaki.Add(txtDenwa.Text);
            lstChokusosaki.Add(txtBushoName.Text);
            lstChokusosaki.Add(SystemInformation.UserName);

            M1100_Chokusosaki_B chokusosakiB = new M1100_Chokusosaki_B();
            try
            {
                //登録
                chokusosakiB.addChokusosaki(lstChokusosaki);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //取消メソッド起動前に、残す項目を確保
                strTokuiSub = labelSet_Tokuisaki.CodeTxtText;

                //テキストボックスを白紙にする
                delText();
                labelSet_Tokuisaki.CodeTxtText = strTokuiSub;
                labelSet_Tokuisaki.Focus();
                txtChokusoCd.Focus();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除、ボタンの機能を消す
        ///</summary>
        private void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);
            labelSet_Tokuisaki.Focus();
        }

        ///<summary>
        ///delChokusosaki
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delChokusosaki()
        {
            //記入情報のデータの存在確認用
            List<string> lstChokusosakiLoad = new List<string>();
            //記入情報削除用
            List<string> lstChokusosaki = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //取消メソッド起動前に、残す項目を確保用
            string strTokuiSub = "";

            //空文字判定（得意先コード、直送先コード）
            if (StringUtl.blIsEmpty(labelSet_Tokuisaki.CodeTxtText) == false || txtChokusoCd.blIsEmpty() == false)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1100_Chokusosaki_B chokusosakiB = new M1100_Chokusosaki_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                lstChokusosakiLoad.Add(labelSet_Tokuisaki.CodeTxtText);
                lstChokusosakiLoad.Add(txtChokusoCd.Text);

                //戻り値のDatatableを取り込む
                dtSetCd = chokusosakiB.updTxtChokusoLeave(lstChokusosakiLoad);

                //検索結果にデータが存在しなければ終了
                if (dtSetCd.Rows.Count == 0)
                {
                    return;
                }

                //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                //削除情報を入れる（得意先コード、直送先コード、直送先名、郵便番号、住所１、住所２、電話番号、部署名、ユーザー名）
                lstChokusosaki.Add(labelSet_Tokuisaki.codeTxt.Text);
                lstChokusosaki.Add(txtChokusoCd.Text);
                lstChokusosaki.Add(txtChokusoName.Text);
                lstChokusosaki.Add(txtYubin.Text);
                lstChokusosaki.Add(txtJusho1.Text);
                lstChokusosaki.Add(txtJusho2.Text);
                lstChokusosaki.Add(txtDenwa.Text);
                lstChokusosaki.Add(txtBushoName.Text);
                lstChokusosaki.Add(SystemInformation.UserName);

                //ビジネス層、削除ロジックに移動
                chokusosakiB.delChokusosaki(lstChokusosaki);

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //取消メソッド起動前に、残す項目を確保
                strTokuiSub = labelSet_Tokuisaki.CodeTxtText;

                //テキストボックスを白紙にする
                delText();
                labelSet_Tokuisaki.CodeTxtText = strTokuiSub;
                labelSet_Tokuisaki.Focus();
                txtChokusoCd.Focus();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///setChokusoCode
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setChokusoCode(DataTable dtSelectData)
        {
            txtChokusoCd.Text = dtSelectData.Rows[0]["直送先コード"].ToString();
            txtChokusoName.Text = dtSelectData.Rows[0]["直送先名"].ToString();
            txtYubin.Text = dtSelectData.Rows[0]["郵便番号"].ToString();
            txtJusho1.Text = dtSelectData.Rows[0]["住所１"].ToString();
            txtJusho2.Text = dtSelectData.Rows[0]["住所２"].ToString();
            txtDenwa.Text = dtSelectData.Rows[0]["電話番号"].ToString();
        }

        ///<summary>
        ///updTxtChokuTxtLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public void updTxtChokuTxtLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstChokusosaki = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //文字チェック用
            Boolean blnGood;

            //前後の空白を取り除く
            txtChokusoCd.Text = txtChokusoCd.Text.Trim();

            //空文字判定（得意先コード、直送先コード）
            if (StringUtl.blIsEmpty(labelSet_Tokuisaki.CodeTxtText) == false || txtChokusoCd.blIsEmpty() == false)
            {
                return;
            }

            //文字数が足りなかった場合0パティング
            if (txtChokusoCd.TextLength < 4)
            {
                txtChokusoCd.Text = txtChokusoCd.Text.ToString().PadLeft(4, '0');
            }

            //禁止文字チェック
            blnGood = StringUtl.JudBanChr(labelSet_Tokuisaki.CodeTxtText);
            blnGood = StringUtl.JudBanChr(txtChokusoCd.Text);
            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(labelSet_Tokuisaki.CodeTxtText, CommonTeisu.NUMBER_ONLY);
            blnGood = StringUtl.JudBanSelect(txtChokusoCd.Text, CommonTeisu.NUMBER_ONLY);

            //文字チェックが通らなかった場合
            if (blnGood == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_Tokuisaki.Focus();
                return;
            }

            //データの存在確認を検索する情報を入れる
            lstChokusosaki.Add(labelSet_Tokuisaki.CodeTxtText);
            lstChokusosaki.Add(txtChokusoCd.Text);

            //ビジネス層のインスタンス生成
            M1100_Chokusosaki_B chokusosakiB = new M1100_Chokusosaki_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = chokusosakiB.updTxtChokusoLeave(lstChokusosaki);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtChokusoCd.Text = dtSetCd.Rows[0]["直送先コード"].ToString();
                    txtChokusoName.Text = dtSetCd.Rows[0]["直送先名"].ToString();
                    txtYubin.Text = dtSetCd.Rows[0]["郵便番号"].ToString();
                    txtJusho1.Text = dtSetCd.Rows[0]["住所１"].ToString();
                    txtJusho2.Text = dtSetCd.Rows[0]["住所２"].ToString();
                    txtDenwa.Text = dtSetCd.Rows[0]["電話番号"].ToString();
                    txtBushoName.Text = dtSetCd.Rows[0]["部署名"].ToString();
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///setTokuiListClose
        ///TokuisakiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setTokuiListClose()
        {
            labelSet_Tokuisaki.Focus();
        }

        ///<summary>
        ///setChokuListClose
        ///ChokusosakiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setChokuListClose()
        {
            txtChokusoCd.Focus();
        }
        
        /// <summary>
        /// judtxtChokuKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtChokuKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
