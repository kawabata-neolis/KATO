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
using KATO.Business.M1130_Shohizeiritsu;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1130_Shohizeiritsu
{
    ///<summary>
    ///M1130_Shohizeiritsu
    ///消費税率フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class M1130_Shohizeiritsu : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///M1130_Shohizeiritu
        ///フォームの初期設定
        ///</summary>
        public M1130_Shohizeiritsu(Control c)
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
        ///M1130_Shohizeiritsu_Load
        ///画面レイアウト設定
        ///</summary>
        private void M1130_Shohizeiritsu_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "消費税率マスタ";
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
        ///M1130_Shohizeiritsu_KeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void M1130_Shohizeiritsu_KeyDown(object sender, KeyEventArgs e)
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
                    this.addShohizeiritsu();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delShohizeiritsu();
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
        ///txtShohizeiritsu_KeyDown
        ///キー入力判定（無機能テキストボックス）
        ///</summary>
        private void txtShohizeiritsu_KeyDown(object sender, KeyEventArgs e)
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
        ///txtTekiyoYMD_KeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void txtTekiyoYMD_KeyDown(object sender, KeyEventArgs e)
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
                    showShohizeiList();
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
                    this.addShohizeiritsu();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delShohizeiritsu();
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
        ///showShohizeiList
        /// コード入力項目でのキー入力判定
        ///</summary>
        private void showShohizeiList()
        {
            //担当者リストのインスタンス生成
            ShohizeiritsuList shohizeiritsulist = new ShohizeiritsuList(this);
            try
            {
                //担当者区分リストの表示、画面IDを渡す
                shohizeiritsulist.StartPosition = FormStartPosition.Manual;
                shohizeiritsulist.intFrmKind = CommonTeisu.FRM_SHOHIZEIRITSU;
                shohizeiritsulist.ShowDialog();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///addShohizeiritu
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addShohizeiritsu()
        {
            //記入情報登録用
            List<string> lstShohizei = new List<string>();

            //空文字判定（年月日）
            if (txtTekiyoYMD.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTekiyoYMD.Focus();
                return;
            }
            //空文字判定（消費税率）
            if (txtShohizeiritu.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtShohizeiritu.Focus();
                return;
            }

            //入力項目が規定通りになるように一度フォーカスを外す
            Control cActiveBefore = this.ActiveControl;
            //内部的に別フォーカスにしたい
            this.SelectNextControl(this.ActiveControl, true, true, true, true);

            //登録情報を入れる（年月日、消費税率、ユーザー名）
            lstShohizei.Add(txtTekiyoYMD.Text);
            lstShohizei.Add(txtShohizeiritu.Text);
            lstShohizei.Add(SystemInformation.UserName);

            //ビジネス層のインスタンス生成
            M1130_Shohizeiritsu_B shohizeiritsuB = new M1130_Shohizeiritsu_B();
            try
            {
                //登録
                shohizeiritsuB.addShohizeiritsu(lstShohizei);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtShohizeiritu.Text = "";
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
            delFormClear(this);
            txtShohizeiritu.Text = "";

            txtTekiyoYMD.Focus();
        }

        ///<summary>
        ///delShohizeiritu
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delShohizeiritsu()
        {
            //記入情報削除用
            List<string> lstShohizei = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //文字判定
            if (txtTekiyoYMD.blIsEmpty() == false)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1130_Shohizeiritsu_B shohizeiritsuB = new M1130_Shohizeiritsu_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = shohizeiritsuB.getTxtShohizeiLeave(txtTekiyoYMD.Text);

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

                //削除情報を入れる（年月日、消費税率、ユーザー名）
                lstShohizei.Add(txtTekiyoYMD.Text);
                lstShohizei.Add(txtShohizeiritu.Text);
                lstShohizei.Add(SystemInformation.UserName);

                //ビジネス層、削除ロジックに移動
                shohizeiritsuB.delShohizeiritsu(lstShohizei);

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtShohizeiritu.Text = "";
                txtTekiyoYMD.Focus();
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
        ///setShohizeiritu
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setShohizeiritsu(DataTable dtSelectData)
        {
            txtTekiyoYMD.Text = dtSelectData.Rows[0]["適用開始年月日"].ToString();
            txtShohizeiritu.Text = dtSelectData.Rows[0]["消費税率"].ToString();
        }

        ///<summary>
        ///txtTekiyoYMD_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void txtTekiyoYMD_Leave(object sender, EventArgs e)
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //文字チェック用
            Boolean blnGood;

            //前後の空白を取り除く
            txtTekiyoYMD.Text = txtTekiyoYMD.Text.Trim();

            //空文字判定
            if (txtTekiyoYMD.blIsEmpty() == false)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1130_Shohizeiritsu_B shohizeirituB = new M1130_Shohizeiritsu_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = shohizeirituB.getTxtShohizeiLeave(txtTekiyoYMD.Text);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    setShohizeiritsu(dtSetCd);
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
        ///setShohizeiListClose
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setShohizeiListClose()
        {
            txtTekiyoYMD.Focus();
        }

        /// <summary>
        /// judtxtShohizeiKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtShohizeiKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
