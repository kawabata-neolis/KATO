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
        ///</summary>
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

            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;
            this.btnF09.Enabled = false;
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
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addTantousha();
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.deTantousha();
                    }
                    break;
                case Keys.F4:
                    if (this.btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.delText();
                    }
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
                    printTantousha();
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

        ///<summary>
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
                    showTantoushaList();
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
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addTantousha();
                    }
                    break;
                case STR_BTN_F03: // 削除
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.deTantousha();
                    }
                    break;
                case STR_BTN_F04: // 取消
                    if (this.btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.delText();
                    }
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printTantousha();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///showTantoushaList
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void showTantoushaList()
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

        ///<summary>
        ///addTantousha
        ///テキストボックス内のデータをDBに登録
        ///</summary>
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
            if (StringUtl.blIsEmpty(lblSetEigyousho.CodeTxtText) == false )
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                lblSetEigyousho.Focus();
                return;
            }
            // 存在チェック（グループチェック）
            if (lblSetEigyousho.chkTxtEigyousho())
            {
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
            if (StringUtl.blIsEmpty(lblSetGroupCd.CodeTxtText) == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                lblSetGroupCd.Focus();
                return;
            }
            // 存在チェック（グループチェック）
            if (lblSetGroupCd.chkTxtGroupCd())
            {
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
            //空文字判定（役職コード）
            if (txtYakushokuCd.blIsEmpty() == false || StringUtl.blIsEmpty(lblGrayYakushokuCdName.Text) == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtYakushokuCd.Focus();
                return;
            }
            // 存在チェック（役職コード）
            if (txtYakushokuCd_Leave_Set())
            {
                return;
            }
            //空文字判定（表示設定）
            if (txtHyoji.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHyoji.Focus();
                return;
            }
            //入力文字判定（表示設定）
            if (txtHyoji.Text != "0" && txtHyoji.Text != "1")
            {
                //メッセージボックスの処理、項目が該当数値以外の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "表示設定は、0か1を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHyoji.Focus();
                return;
            }
            //空文字判定（マスタ権限）
            if (txtMasterKengen.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtMasterKengen.Focus();
                return;
            }
            //入力文字判定（マスタ権限）
            if (txtMasterKengen.Text != "0" && txtMasterKengen.Text != "1")
            {
                //メッセージボックスの処理、項目が該当数値以外の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "表示設定は、0か1を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtMasterKengen.Focus();
                return;
            }
            //空文字判定（閲覧権限）
            if (txtEtsuranKengen.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtEtsuranKengen.Focus();
                return;
            }
            //入力文字判定（閲覧権限）
            if (txtEtsuranKengen.Text != "0" && txtEtsuranKengen.Text != "1")
            {
                //メッセージボックスの処理、項目が該当数値以外の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "表示設定は、0か1を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtEtsuranKengen.Focus();
                return;
            }
            //空文字判定（利益率権限）
            if (txtRiekiritsuKengen.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtRiekiritsuKengen.Focus();
                return;
            }
            //入力文字判定（利益率権限）
            if (txtRiekiritsuKengen.Text != "0" && txtRiekiritsuKengen.Text != "1")
            {
                //メッセージボックスの処理、項目が該当数値以外の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "表示設定は、0か1を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtRiekiritsuKengen.Focus();
                return;
            }
            // 担当者コードチェック
            if (chkTantoushaCd())
            {
                return;
            }

            //登録情報を入れる（担当者コード、担当者名、ログインID、営業所コード、注番、グループコード、目標金額、マスター権限、閲覧権限、利益率権限、ユーザー名）
            //[0]
            lstTantousha.Add(txtTantoushaCd.Text);
            //[1]
            lstTantousha.Add(txtTantoushaName.Text);
            //[2]
            lstTantousha.Add(txtLoginID.Text);
            //[3]
            lstTantousha.Add(lblSetEigyousho.CodeTxtText);
            //[4]
            lstTantousha.Add(txtChuban.Text);
            //[5]
            lstTantousha.Add(lblSetGroupCd.CodeTxtText);
            //[6]
            lstTantousha.Add(txtMokuhyou.Text);
            //[7]
            lstTantousha.Add(txtMasterKengen.Text);
            //[8]
            lstTantousha.Add(txtEtsuranKengen.Text);
            //[9]
            lstTantousha.Add(txtRiekiritsuKengen.Text);
            //[10]
            lstTantousha.Add(txtYakushokuCd.Text);
            //[11]
            lstTantousha.Add(txtHyoji.Text);
            //[12]
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

            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;

            txtTantoushaCd.Focus();
            txtMokuhyou.Text = "";
        }

        ///<summary>
        ///deTantousha
        ///テキストボックス内のデータをDBから削除
        ///</summary>
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

            // 担当者コードチェック
            if (chkTantoushaCd())
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1050_Tantousha_B tantouB = new M1050_Tantousha_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = tantouB.getTxtTantoshaLeave(txtTantoushaCd.Text);

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
                lstTantousha.Add(dtSetCd.Rows[0]["担当者コード"].ToString());
                lstTantousha.Add(dtSetCd.Rows[0]["担当者名"].ToString());
                lstTantousha.Add(dtSetCd.Rows[0]["ログインID"].ToString());
                lstTantousha.Add(dtSetCd.Rows[0]["営業所コード"].ToString());
                lstTantousha.Add(dtSetCd.Rows[0]["注番文字"].ToString());
                lstTantousha.Add(dtSetCd.Rows[0]["グループコード"].ToString());
                lstTantousha.Add(((decimal)dtSetCd.Rows[0]["年間売上目標"]).ToString("#,0"));
                lstTantousha.Add(dtSetCd.Rows[0]["マスタ権限"].ToString());
                lstTantousha.Add(dtSetCd.Rows[0]["閲覧権限"].ToString());
                lstTantousha.Add(dtSetCd.Rows[0]["利益率権限"].ToString());
                lstTantousha.Add(dtSetCd.Rows[0]["役職コード"].ToString());
                lstTantousha.Add(dtSetCd.Rows[0]["表示"].ToString());
                lstTantousha.Add(SystemInformation.UserName);
                
                //ビジネス層、削除ロジックに移動
                tantouB.delTantosha(lstTantousha);

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
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
        ///setTantousha
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setTantousha(DataTable dtSelectData)
        {
            txtTantoushaCd.Text = dtSelectData.Rows[0]["担当者コード"].ToString();
            txtTantoushaName.Text = dtSelectData.Rows[0]["担当者名"].ToString();
            txtLoginID.Text = dtSelectData.Rows[0]["ログインID"].ToString();
            lblSetEigyousho.CodeTxtText = dtSelectData.Rows[0]["営業所コード"].ToString();
            txtChuban.Text = dtSelectData.Rows[0]["注番文字"].ToString();
            lblSetGroupCd.CodeTxtText = dtSelectData.Rows[0]["グループコード"].ToString();
            txtMokuhyou.Text = ((decimal)dtSelectData.Rows[0]["年間売上目標"]).ToString("#,0");
            txtYakushokuCd.Text = dtSelectData.Rows[0]["役職コード"].ToString();
            txtHyoji.Text = dtSelectData.Rows[0]["表示"].ToString();
            txtMasterKengen.Text = dtSelectData.Rows[0]["マスタ権限"].ToString();
            txtEtsuranKengen.Text = dtSelectData.Rows[0]["閲覧権限"].ToString();
            txtRiekiritsuKengen.Text = dtSelectData.Rows[0]["利益率権限"].ToString();

            //役職コードの表示
            if (txtYakushokuCd_Leave_Set())
            {
                return;
            }
        }

        ///<summary>
        ///setTxtTantoushaLeave
        ///担当者code入力箇所からフォーカスが外れた時
        ///</summary>
        public void setTxtTantoushaLeave(object sender, EventArgs e)
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //前後の空白を取り除く
            txtTantoushaCd.Text = txtTantoushaCd.Text.Trim();

            //空文字判定
            if (txtTantoushaCd.blIsEmpty() == false)
            {
                return;
            }

            // 担当者コードチェック
            if (chkTantoushaCd())
            {
                return;
            }
            //ビジネス層のインスタンス生成
            M1050_Tantousha_B tantouB = new M1050_Tantousha_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = tantouB.getTxtTantoshaLeave(txtTantoushaCd.Text);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    setTantousha(dtSetCd);

                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = true;
                    this.btnF04.Enabled = true;
                }
                else
                {
                    txtTantoushaName.Text = "";

                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = false;
                    this.btnF04.Enabled = true;
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
        ///CloseTantoshaList
        ///担当者リストが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void CloseTantoshaList()
        {
            txtTantoushaCd.Focus();
        }

        ///<summary>
        ///judtxtTantoushaKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtTantoushaKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///printTantousha
        ///印刷ダイアログ
        ///</summary>
        private void printTantousha()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //PDF作成後の入れ物
            string strFile = "";

            //ビジネス層のインスタンス生成
            M1050_Tantousha_B tantouB = new M1050_Tantousha_B();
            try
            {
                dtSetCd_B = tantouB.getPrintData();

                //取得したデータがない場合
                if (dtSetCd_B.Rows.Count == 0 || dtSetCd_B == null)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

                //初期値
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, TATE);

                pf.ShowDialog(this);

                //プレビューの場合
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    //結果セットをレコードセットに
                    strFile = tantouB.dbToPdf(dtSetCd_B);

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    strFile = tantouB.dbToPdf(dtSetCd_B);

                    // 一括印刷
                    pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.TATE, true);
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
        ///labelSet_Eigyousho_Leave
        ///営業所のラベルセットから離れた場合
        ///</summary>
        private void labelSet_Eigyousho_Leave(object sender, EventArgs e)
        {
            //営業所コードがない場合
            if (lblSetEigyousho.CodeTxtText == "" ||
                StringUtl.blIsEmpty(lblSetEigyousho.CodeTxtText) == false)
            {
                return;
            }

            //営業所コードの名前が白紙の場合
            if (lblSetEigyousho.ValueLabelText == "" ||
                StringUtl.blIsEmpty(lblSetEigyousho.ValueLabelText) == false)
            {
                lblSetEigyousho.Focus();
            }
        }

        ///<summary>
        ///labelSet_GroupCd_Leave
        ///グループコードのラベルセットから離れた場合
        ///</summary>
        private void labelSet_GroupCd_Leave(object sender, EventArgs e)
        {
            //グループコードがない場合
            if (lblSetGroupCd.CodeTxtText == "" ||
                StringUtl.blIsEmpty(lblSetGroupCd.CodeTxtText) == false)
            {
                return;
            }

            //コードの名前が白紙の場合
            if (lblSetGroupCd.ValueLabelText == "" ||
                StringUtl.blIsEmpty(lblSetGroupCd.ValueLabelText) == false)
            {
                lblSetGroupCd.Focus();
            }
        }

        ///<summary>
        ///txtYakushokuCd_Leave
        ///役職コードから離れた場合
        ///</summary>
        private void txtYakushokuCd_Leave(object sender, EventArgs e)
        {
            if (txtYakushokuCd_Leave_Set())
            {
                return;
            }
        }

        ///<summary>
        ///txtYakushokuCd_Leave_Set
        ///役職コード入力処理
        ///</summary>
        private bool txtYakushokuCd_Leave_Set()
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;
            

            //前後の空白を取り除く
            txtYakushokuCd.Text = txtYakushokuCd.Text.Trim();

            //空文字判定
            if (txtYakushokuCd.blIsEmpty() == false)
            {
                lblGrayYakushokuCdName.Text = "";
                return true;
            }

            // 役職コードチェック
            if (chkYakushokuCd())
            {
                return true;
            }

            //ビジネス層のインスタンス生成
            M1050_Tantousha_B tantouB = new M1050_Tantousha_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = tantouB.getTxtYakushokuLeave(txtYakushokuCd.Text);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtYakushokuCd.Text = dtSetCd.Rows[0]["役職コード"].ToString();
                    lblGrayYakushokuCdName.Text = dtSetCd.Rows[0]["役職名"].ToString();
                }
                else
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtYakushokuCd.Text = "";
                    lblGrayYakushokuCdName.Text = "";

                    txtYakushokuCd.Focus();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return true;
            }
        }
        ///<summary>
        /// chkTantoushaCd
        /// 担当者コードチェック
        ///</summary>
        private bool chkTantoushaCd()
        {

            // 禁止文字チェック
            if (StringUtl.JudBanSQL(txtTantoushaCd.Text) == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtTantoushaCd.Text = "";

                txtTantoushaCd.Focus();
                return true;
            }

            // 数値チェック
            if (StringUtl.JudBanSelect(txtTantoushaCd.Text, CommonTeisu.NUMBER_ONLY) == true)
            {
                //文字数が足りなかった場合0パティング
                if (txtTantoushaCd.TextLength < 4)
                {
                    txtTantoushaCd.Text = txtTantoushaCd.Text.ToString().PadLeft(4, '0');
                }
            }

            return false;
        }

        ///<summary>
        /// chkYakushokuCd
        /// 役職コードチェック
        ///</summary>
        private bool chkYakushokuCd()
        {

            // 禁止文字チェック
            if (StringUtl.JudBanSQL(txtYakushokuCd.Text) == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYakushokuCd.Text = "";
                lblGrayYakushokuCdName.Text = "";

                txtYakushokuCd.Focus();
                return true;
            }

            // 数値チェック
            if (StringUtl.JudBanSelect(txtYakushokuCd.Text, CommonTeisu.NUMBER_ONLY) == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYakushokuCd.Text = "";
                lblGrayYakushokuCdName.Text = "";

                txtYakushokuCd.Focus();
                return true;
            }

            //文字数が足りなかった場合0パティング
            if (txtYakushokuCd.TextLength < 2)
            {
                txtYakushokuCd.Text = txtYakushokuCd.Text.ToString().PadLeft(2, '0');
            }
            return false;
        }

    }
}
