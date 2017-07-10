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
using KATO.Business.M1020_Maker_B;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1020_Maker
{
    ///<summary>
    ///M1020_Maker
    ///メーカーフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class M1020_Maker : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///M1020_Maker
        ///フォームの初期設定
        ///</summary>
        public M1020_Maker(Control c)
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

        ///<summary>
        ///M_Maker_Load
        ///画面レイアウト設定
        ///</summary>
        private void M_Maker_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "メーカーマスタ";
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
        ///judMakerKeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void judMakerKeyDown(object sender, KeyEventArgs e)
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
                    this.addMaker();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delMaker();
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
        ///judMakerTxtKeyDown
        ///キー入力判定（無機能テキストボックス）
        ///</summary>
        private void judMakerTxtKeyDown(object sender, KeyEventArgs e)
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
        ///judTxtMakerTxtKeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void judTxtMakerTxtKeyDown(object sender, KeyEventArgs e)
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
                    showMakerList();
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
                    this.addMaker();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delMaker();
                    break;
                case STR_BTN_F04: // 取消
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
        ///showMakerList
        ///メーカーリストの表示
        ///</summary>
        private void showMakerList()
        {
            //メーカーリストのインスタンス生成
            MakerList makerlist = new MakerList(this);
            try
            {
                //メーカーリストの表示、画面IDを渡す
                makerlist.StartPosition = FormStartPosition.Manual;
                makerlist.intFrmKind = CommonTeisu.FRM_MAKER;
                makerlist.Show();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///addMaker
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addMaker()
        {
            //記入情報登録用
            List<string> lstMakerData = new List<string>();

            //空文字判定（メーカーコード）
            if (txtMaker.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtMaker.Focus();
                return;
            }
            //空文字判定（メーカー名）
            if (txtName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtName.Focus();
                return;
            }

            //登録情報を入れる（メーカーID、メーカー名、ユーザー名）
            lstMakerData.Add(txtMaker.Text);
            lstMakerData.Add(txtName.Text);
            lstMakerData.Add(SystemInformation.UserName);

            //ビジネス層のインスタンス生成
            M1020_Maker_B makerB = new M1020_Maker_B();
            try
            {
                //登録
                makerB.addMaker(lstMakerData);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtMaker.Focus();
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
        ///テキストボックス等の入力情報を白紙にする
        ///</summary>
        private void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);
            txtMaker.Focus();
        }

        ///<summary>
        ///delMaker
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delMaker()
        {
            //記入情報削除用
            List<string> lstMakerData = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //空文字判定（メーカーコード）
            if (txtMaker.blIsEmpty() == false)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1020_Maker_B makerB = new M1020_Maker_B();
            try
            {
                //検索
                dtSetCd = makerB.getTxtMakerTextLeave(txtMaker.Text);

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

                //削除情報を入れる（メーカーCD、メーカー名、ユーザー名）
                lstMakerData.Add(txtMaker.Text);
                lstMakerData.Add(txtName.Text);
                lstMakerData.Add(SystemInformation.UserName);

                //ビジネス層、削除ロジックに移動
                makerB.delMaker(lstMakerData);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtMaker.Focus();
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
        ///setMakerCode
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setMakerCode(DataTable dtSelectData)
        {
            txtMaker.Text = dtSelectData.Rows[0]["メーカーコード"].ToString();
            txtName.Text = dtSelectData.Rows[0]["メーカー名"].ToString();
        }

        ///<summary>
        ///setTxtMakerTextLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public void setTxtMakerTextLeave(object sender, EventArgs e)
        {
            //フォーカス位置の確保
            Control cActive = this.ActiveControl;

            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //文字チェック用
            bool blGood;

            //前後の空白を取り除く
            txtMaker.Text = txtMaker.Text.Trim();

            //空文字判定
            if (txtMaker.blIsEmpty() == false)
            {
                return;
            }
            //文字数が足りなかった場合0パティング
            if (txtMaker.TextLength < 4)
            {
                txtMaker.Text = txtMaker.Text.ToString().PadLeft(4, '0');
            }

            //禁止文字チェック
            blGood = StringUtl.JudBanChr(txtMaker.Text);
            //数字のみを許可する
            blGood = StringUtl.JudBanSelect(txtMaker.Text, CommonTeisu.NUMBER_ONLY);

            //文字チェックが通らなかった場合
            if (blGood == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtMaker.Focus();
                return;
            }

            //ビジネス層、検索ロジックに移動
            M1020_Maker_B makerB = new M1020_Maker_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = makerB.getTxtMakerTextLeave(txtMaker.Text);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtMaker.Text = dtSetCd.Rows[0]["メーカーコード"].ToString();
                    txtName.Text = dtSetCd.Rows[0]["メーカー名"].ToString();
                    txtName.Focus();
                }
                cActive.Focus();
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
        ///closeMakerList
        ///MakerListCloseが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void closeMakerList()
        {
            txtMaker.Focus();
        }

        ///judtxtMakerKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtMakerKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
