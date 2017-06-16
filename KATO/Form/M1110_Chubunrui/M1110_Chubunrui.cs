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
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Business.M1010_Daibunrui;
using KATO.Business.M1110_Chubunrui;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1110_Chubunrui
{
    ///<summary>
    ///M1110_Chubunrui
    ///中分類フォーム
    ///作成者：大河内
    ///作成日：2017/2/2
    ///更新者：大河内
    ///更新日：2017/2/2
    ///カラム論理名
    ///</summary>
    public partial class M1110_Chubunrui : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// M1110_Chubunrui
        /// フォームの初期設定
        /// </summary>
        public M1110_Chubunrui(Control c)
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
        /// M_Chubunrui_Load
        /// 画面レイアウト設定
        /// </summary>
        private void M_Chubunrui_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "中分類マスタ";
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
        ///judChubunruiKeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void judChubunruiKeyDown(object sender, KeyEventArgs e)
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
                    this.addChubunrui();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delChubunrui();
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    delText();
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
        ///judChubunTxtKeyDown
        ///キー入力判定（無機能テキストボックス）
        ///</summary>
        private void judChubunTxtKeyDown(object sender, KeyEventArgs e)
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
        ///judTxtChuTxtKeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void judTxtChuTxtKeyDown(object sender, KeyEventArgs e)
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
                    delText();
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
                    judtxtChubunKeyDown(sender, e);
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
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addChubunrui();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delChubunrui();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    delText();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///judtxtCyokuCDKeyDown
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void judtxtChubunKeyDown(object sender, KeyEventArgs e)
        {
            //F9を押して且つ大分類コードが記載されている場合
            if (e.KeyCode == Keys.F9 && LabelSet_Daibun.CodeTxtText != "")
            {
                //ラベルセットである情報を渡すためにインスタンス生成
                LabelSet_Chubunrui lblSetChubunSelect = new LabelSet_Chubunrui();
                //中分類リストのインスタンス生成
                ChubunruiList chubunruilist = new ChubunruiList(this, lblSetChubunSelect, LabelSet_Daibun.CodeTxtText);
                try
                {
                    //中分類リストの表示、画面IDを渡す
                    chubunruilist.StartPosition = FormStartPosition.Manual;
                    chubunruilist.intFrmKind = KATO.Common.Util.CommonTeisu.FRM_CHUBUNRUI;
                    chubunruilist.ShowDialog();
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
        ///addChubunrui
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addChubunrui()
        {
            //記入情報登録用
            List<string> lstChubunrui = new List<string>();

            //取消メソッド起動前に、残す項目を確保用
            string strTokuiSub = "";

            //文字判定（大分類コード）
            if (StringUtl.blIsEmpty(LabelSet_Daibun.CodeTxtText) == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                LabelSet_Daibun.Focus();
                return;
            }
            //文字判定（中分類コード）
            if (txtChubunrui.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtChubunrui.Focus();
                return;
            }
            //文字判定（中分類名）
            if (txtElem.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtElem.Focus();
                return;
            }

            //登録情報を入れる（大分類コード、中分類コード、中分類名、ユーザー名）
            lstChubunrui.Add(LabelSet_Daibun.CodeTxtText);
            lstChubunrui.Add(txtChubunrui.Text);
            lstChubunrui.Add(txtElem.Text);
            lstChubunrui.Add(SystemInformation.UserName);

            //ビジネス層のインスタンス生成
            M1110_Chubunrui_B chubunB = new M1110_Chubunrui_B();
            try
            {
                //登録
                chubunB.addChubunrui(lstChubunrui);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //取消メソッド起動前に、残す項目を確保
                strTokuiSub = LabelSet_Daibun.CodeTxtText;

                //テキストボックスを白紙にする
                delText();
                LabelSet_Daibun.CodeTxtText = strTokuiSub;
                LabelSet_Daibun.Focus();
                txtChubunrui.Focus();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除
        ///</summary>
        private void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);
            LabelSet_Daibun.Focus();
        }

        ///<summary>
        ///delCtyubunrui
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delChubunrui()
        {
            //記入情報のデータの存在確認用
            List<string> lstChubunruiLoad = new List<string>();
            //記入情報削除用
            List<string> lstChubunrui = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //空文字判定（大部類コード、中分類コード）
            if (StringUtl.blIsEmpty(LabelSet_Daibun.CodeTxtText) == false || txtChubunrui.blIsEmpty() == false)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1110_Chubunrui_B chubunB = new M1110_Chubunrui_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                lstChubunruiLoad.Add(LabelSet_Daibun.CodeTxtText);
                lstChubunruiLoad.Add(txtChubunrui.Text);

                //戻り値のDatatableを取り込む
                dtSetCd = chubunB.updTxtChubunruiLeave(lstChubunruiLoad);

                //取消メソッド起動前に、残す項目を確保用
                string strTokuiSub = "";

                //検索結果にデータが存在しなければ終了
                if (dtSetCd.Rows.Count == 0)
                {
                    return;
                }

                //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //YESが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }
                
                //削除情報を入れる（大分類コード、中分類コード、中分類名、ユーザー名）
                lstChubunrui.Add(LabelSet_Daibun.CodeTxtText);
                lstChubunrui.Add(txtChubunrui.Text);
                lstChubunrui.Add(txtElem.Text);
                lstChubunrui.Add(SystemInformation.UserName);

                //ビジネス層、削除ロジックに移動
                chubunB.delChubunrui(lstChubunrui);

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //取消メソッド起動前に、残す項目を確保
                strTokuiSub = LabelSet_Daibun.CodeTxtText;

                //テキストボックスを白紙にする
                delText();
                LabelSet_Daibun.CodeTxtText = strTokuiSub;
                LabelSet_Daibun.Focus();
                txtChubunrui.Focus();

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///setDaibunrui
        ///取り出したデータをテキストボックスに配置（大分類）
        ///</summary>
        public void setDaibunrui(DataTable dtSelectData)
        {
            
            LabelSet_Daibun.CodeTxtText = dtSelectData.Rows[0]["大分類コード"].ToString();
            LabelSet_Daibun.ValueLabelText = dtSelectData.Rows[0]["大分類名"].ToString();
        }

        ///<summary>
        ///setChubunrui
        ///取り出したデータをテキストボックスに配置（中分類）
        ///</summary>
        public void setChubunrui(DataTable dtSelectData)
        {
            txtChubunrui.Text = dtSelectData.Rows[0]["中分類コード"].ToString();
            txtElem.Text = dtSelectData.Rows[0]["中分類名"].ToString();
        }

        ///<summary>
        ///updTxtChubunruiLeave
        ///code入力箇所からフォーカスが外れた時（中分類）
        ///</summary>
        public void updTxtChubunruiLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //文字チェック用
            Boolean blnGood;

            //前後の空白を取り除く
            txtChubunrui.Text = txtChubunrui.Text.Trim();

            //空文字判定（中分類コード）
            if (StringUtl.blIsEmpty(txtChubunrui.Text) == false)
            {
                return;
            }

            //文字数が足りなかった場合0パティング
            if (txtChubunrui.TextLength == 1)
            {
                txtChubunrui.Text = txtChubunrui.Text.ToString().PadLeft(2, '0');
            }

            //禁止文字チェック
            blnGood = StringUtl.JudBanChr(txtChubunrui.Text);
            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(txtChubunrui.Text, CommonTeisu.NUMBER_ONLY);

            //文字チェックが通らなかった場合
            if (blnGood == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtChubunrui.Focus();
                return;
            }

            //データの存在確認を検索する情報を入れる
            lstString.Add(LabelSet_Daibun.CodeTxtText);
            lstString.Add(txtChubunrui.Text);

            //ビジネス層のインスタンス生成
            M1110_Chubunrui_B chubunB = new M1110_Chubunrui_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = chubunB.updTxtChubunruiLeave(lstString);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    LabelSet_Daibun.CodeTxtText = dtSetCd.Rows[0]["大分類コード"].ToString();
                    txtChubunrui.Text = dtSetCd.Rows[0]["中分類コード"].ToString();
                    txtElem.Text = dtSetCd.Rows[0]["中分類名"].ToString();
                }
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///setDaibunruiListClose
        ///DaibunruiListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///</summary>
        public void setDaibunruiListClose()
        {
            LabelSet_Daibun.Focus();
        }

        ///<summary>
        ///setChubunruiListClose
        ///ChubunruiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setChubunruiListClose()
        {
            txtChubunrui.Focus();
        }

        ///judtxtChubunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtChubunruiKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
