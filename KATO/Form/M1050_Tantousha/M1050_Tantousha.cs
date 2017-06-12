using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Business.M1050_Tantousha;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1050_Tantousha
{
    ///<summary>
    ///M1050_Tantousha
    ///担当者フォーム
    ///作成者：大河内
    ///作成日：2017/2/2
    ///更新者：大河内
    ///更新日：2017/2/2
    ///カラム論理名
    ///</summary>
    public partial class M1050_Tantousha : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //コード内の無限ループを抜けるためのもの
        public Boolean blnLoopOne = true;

        ///<summary>
        ///M1050_Tantousha
        ///フォームの初期設定
        ///</summary>
        public M1050_Tantousha(Control c)
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
        ///M1050_Tantousha_Load
        ///画面レイアウト設定
        /// </summary>
        private void M1050_Tantousha_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "担当者マスタ";
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
        ///judTantoushaKeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void judTantoushaKeyDown(object sender, KeyEventArgs e)
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
                    this.addTantousha();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.deTantousha();
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
        ///judTantouTxtKeyDown
        ///キー入力判定（無機能テキストボックス）
        ///</summary>
        private void judTantouTxtKeyDown(object sender, KeyEventArgs e)
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

        /// <summary>
        ///judTxtTantouTxtKeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void judTxtTantouTxtKeyDown(object sender, KeyEventArgs e)
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
                    judtxtTantouKeyDown(sender, e);
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
                    this.addTantousha();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.deTantousha();
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

        /// <summary>
        /// judtxtTantouKeyDown
        /// コード入力項目でのキー入力判定
        /// </summary>
        private void judtxtTantouKeyDown(object sender, KeyEventArgs e)
        {
            //F9キーが押された場合
            if (e.KeyCode == Keys.F9)
            {
                //担当者リストのインスタンス生成
                TantoushaList tantoushalist = new TantoushaList(this);
                try
                {
                    //担当者区分リストの表示、画面IDを渡す
                    tantoushalist.StartPosition = FormStartPosition.Manual;
                    tantoushalist.intFrmKind = CommonTeisu.FRM_TANTOUSHA;
                    tantoushalist.ShowDialog();

                    txtMokuhyou.Focus();
                    txtTantoushaCd.Focus();
                }
                catch (Exception ex)
                {
                    //エラーロギング
                    new CommonException(ex);
                    return;
                }
            }
        }

        /// <summary>
        /// addTantousha
        /// テキストボックス内のデータをDBに登録
        /// </summary>
        private void addTantousha()
        {
            //記入情報登録用
            List<string> lstTantousha = new List<string>();

            //空文字判定（担当者コード）
            if (txtTantoushaCd.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTantoushaCd.Focus();
                return;
            }
            //空文字判定（担当者名）
            if (txtTantoushaName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTantoushaName.Focus();
                return;
            }
            //空文字判定（ログインID）
            if (txtLoginID.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtLoginID.Focus();
                return;
            }
            //空文字判定（営業所コード）
            if (StringUtl.blIsEmpty(labelSet_Eigyousho.CodeTxtText) == false )
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Eigyousho.Focus();
                return;
            }
            //空文字判定（注番）
            if (txtChuban.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtChuban.Focus();
                return;
            }
            //空文字判定（グループコード）
            if (StringUtl.blIsEmpty(labelSet_GroupCd.CodeTxtText) == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_GroupCd.Focus();
                return;
            }
            //空文字判定（目標金額）
            if (txtMokuhyou.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtMokuhyou.Focus();
                return;
            }

            //登録情報を入れる（担当者コード、担当者名、ログインID、営業所コード、注番、グループコード、目標金額、ユーザー名）
            lstTantousha.Add(txtTantoushaCd.Text);
            lstTantousha.Add(txtTantoushaName.Text);
            lstTantousha.Add(txtLoginID.Text);
            lstTantousha.Add(labelSet_Eigyousho.CodeTxtText);
            lstTantousha.Add(txtChuban.Text);
            lstTantousha.Add(labelSet_GroupCd.CodeTxtText);
            lstTantousha.Add(txtMokuhyou.Text);
            lstTantousha.Add(SystemInformation.UserName);

            //ビジネス層のインスタンス生成
            M1050_Tantousha_B tantouB = new M1050_Tantousha_B();
            try
            {
                //登録
                tantouB.addTantousha(lstTantousha);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtTantoushaCd.Focus();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);
            txtTantoushaCd.Focus();
            txtMokuhyou.Text = "";
        }

        /// <summary>
        /// deTantousha
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void deTantousha()
        {
            //記入情報削除用
            List<string> lstTantousha = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //空文字判定（担当者コード）
            if (txtTantoushaCd.blIsEmpty() == false)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1050_Tantousha_B tantouB = new M1050_Tantousha_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = tantouB.updTxtTantoshaLeave(txtTantoushaCd.Text);

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

                //削除情報を入れる（担当者コード、担当者名、ログインID、営業所コード、注番、グループコード、目標金額、ユーザー名）
                lstTantousha.Add(txtTantoushaCd.Text);
                lstTantousha.Add(txtTantoushaName.Text);
                lstTantousha.Add(txtLoginID.Text);
                lstTantousha.Add(labelSet_Eigyousho.CodeTxtText);
                lstTantousha.Add(txtChuban.Text);
                lstTantousha.Add(labelSet_GroupCd.CodeTxtText);
                lstTantousha.Add(txtMokuhyou.Text);
                lstTantousha.Add(SystemInformation.UserName);

                //ビジネス層、削除ロジックに移動
                tantouB.delTantosha(lstTantousha);

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtTantoushaCd.Focus();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        /// <summary>
        /// setTantousha
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setTantousha(DataTable dtSelectData)
        {
            txtTantoushaCd.Text = dtSelectData.Rows[0]["担当者コード"].ToString();
            txtTantoushaName.Text = dtSelectData.Rows[0]["担当者名"].ToString();
            txtLoginID.Text = dtSelectData.Rows[0]["ログインID"].ToString();
            labelSet_Eigyousho.CodeTxtText = dtSelectData.Rows[0]["営業所コード"].ToString();
            txtChuban.Text = dtSelectData.Rows[0]["注番文字"].ToString();
            labelSet_GroupCd.CodeTxtText = dtSelectData.Rows[0]["グループコード"].ToString();
            txtMokuhyou.Text = dtSelectData.Rows[0]["年間売上目標"].ToString();
        }

        /// <summary>
        /// updTxtTantoushaLeave
        /// code入力箇所からフォーカスが外れた時
        /// </summary>
        public void updTxtTantoushaLeave(object sender, EventArgs e)
        {
            //無限ループさせないようにする
            if (blnLoopOne == false)
            {
                blnLoopOne = true;
                return;
            }

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //文字チェック用
            Boolean blnGood;

            //前後の空白を取り除く
            txtTantoushaCd.Text = txtTantoushaCd.Text.Trim();

            //空文字判定
            if (txtTantoushaCd.blIsEmpty() == false)
            {
                return;
            }

            //文字数が足りなかった場合0パティング
            if (txtTantoushaCd.TextLength < 4)
            {
                txtTantoushaCd.Text = txtTantoushaCd.Text.ToString().PadLeft(4, '0');
            }
            
            //禁止文字チェック
            blnGood = StringUtl.JudBanChr(txtTantoushaCd.Text);
            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(txtTantoushaCd.Text, CommonTeisu.NUMBER_ONLY);

            //文字チェックが通らなかった場合
            if (blnGood == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtTantoushaCd.Focus();
                return;
            }

            //ビジネス層のインスタンス生成
            M1050_Tantousha_B tantouB = new M1050_Tantousha_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = tantouB.updTxtTantoshaLeave(txtTantoushaCd.Text);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    setTantousha(dtSetCd);
                }

                //フォーカス位置の確保
                Control c = this.ActiveControl;

                //金額の表示をさせるため、一度対象にフォーカスさせる
                txtMokuhyou.Focus();
                txtTantoushaCd.Focus();

                //１回分のループ完了
                blnLoopOne = false;

                //元のフォーカス位置に移動
                c.Focus();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        /// <summary>
        /// setTantouListClose
        /// 担当者リストが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setTantouListClose()
        {
            txtTantoushaCd.Focus();
        }

        /// <summary>
        /// judtxtTantoushaKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtTantoushaKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
