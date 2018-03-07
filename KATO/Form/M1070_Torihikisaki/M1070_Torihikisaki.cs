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
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Business.M1070_Torihikisaki;

namespace KATO.Form.M1070_Torihikisaki
{

    ///<summary>
    ///M1070_Torihikisaki
    ///取引先フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class M1070_Torihikisaki : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        Control cActiveBefore = null;

        //エラーメッセージを表示したかどうか
        bool blMessageOn = false;

        ///<summary>
        ///M1070_Torihikisaki
        ///フォームの初期設定
        ///</summary>
        public M1070_Torihikisaki(Control c)
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
        ///M1070_Torihikisaki_Load
        ///画面レイアウト設定
        ///</summary>
        private void M1070_Torihikisaki_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "取引先マスタ";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF08.Text = STR_FUNC_F8_KARABAN;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // 画面初回起動時は、下記ボタンは無効化
            this.btnF01.Enabled = false;    // 登録
            this.btnF03.Enabled = false;    // 削除
            this.btnF04.Enabled = false;    // 取消
            this.btnF09.Enabled = false;    // 検索

            //コンボボックス内データの追加
            cmbNonyu.Items.Add("配達");
            cmbNonyu.Items.Add("発送");
            cmbNonyu.Items.Add("直送");
            cmbNonyu.Items.Add("代納");
            cmbNonyu.Items.Add("来店");
        }


        ///<summary>
        ///judTorihikiKeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void judTorihikiKeyDown(object sender, KeyEventArgs e)
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
                        this.addTorihiki();
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delTorihiki();
                    }
                    break;
                case Keys.F4:
                    if (this.btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.delText();
                        this.txtCdT.Focus();
                    }
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    logger.Info(LogUtil.getMessage(this._Title, "空番実行"));
                    this.showTorihikicdList();
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    printTorihiki();
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
        ///judTorihikiTxtKeyDown
        ///キー入力判定（無機能テキストボックス）
        ///</summary>
        private void judTorihikiTxtKeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;

                default:
                    break;
            }

        }

        ///<summary>
        ///judTxtToriTxtKeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void judTxtToriTxtKeyDown(object sender, KeyEventArgs e)
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
                    txtCdT_KeyDown(sender, e);
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
                        this.addTorihiki();
                    }
                    break;
                case STR_BTN_F03: // 削除
                    if (this.btnF03.Enabled)
                    {
                        this.delTorihiki();
                    }
                    break;
                case STR_BTN_F04: // 取り消し
                    if (this.btnF04.Enabled)
                    {
                        this.delText();
                    }
                    break;
                case STR_BTN_F08: // 未割当の番号検索
                    logger.Info(LogUtil.getMessage(this._Title, "空番実行"));
                    this.showTorihikicdList();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printTorihiki();
                    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///txtCdT_KeyDown
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void txtCdT_KeyDown(object sender, KeyEventArgs e)
        {
            //取引先リストのインスタンス生成
            TorihikisakiList torihikisakilist = new TorihikisakiList(this);
            try
            {
                //取引先リストの表示、画面IDを渡す
                torihikisakilist.StartPosition = FormStartPosition.Manual;
                torihikisakilist.intFrmKind = CommonTeisu.FRM_TORIHIKISAKI;
                torihikisakilist.ShowDialog();

                labelSet_Tantousha.Focus();
                labelSet_GyoshuCd.Focus();
                txtSihon.Focus();
                txtCdT.Focus();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///showTorihikicdList
        ///空番ボタン、キーの反応
        ///</summary>
        private void showTorihikicdList()
        {
            //取引先リストのインスタンス生成
            TorihikiCdList torihikicdlist = new TorihikiCdList(this);
            try
            {
                //取引先リストの表示、画面IDを渡す
                torihikicdlist.intFrmKind = CommonTeisu.FRM_TORIHIKISAKI;
                torihikicdlist.ShowDialog();

                txtCdT.Focus();

            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }

        }

        ///<summary>
        ///addGyoushu
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addTorihiki()
        {
            //記入情報登録用
            List<string> lstTorihikisaki = new List<string>();

            //文字判定（取引先コード）
            if (txtCdT.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtCdT.Focus();
                return;
            }
            // 文字列チェック
            if (chkToriikisaki())
            {
                return;
            }

            //文字判定（取引先名）
            if (txtNameT.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtNameT.Focus();
                return;
            }
            //文字判定（フリガナ）
            if (txtHuriT.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHuriT.Focus();
                return;
            }
            //文字判定（担当者コード）
            if (labelSet_Tantousha.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tantousha.Focus();
                return;
            }

            // 文字列チェック
            if(labelSet_Tantousha.chkTxtTantosha())
            {
                return;
            }

            //文字判定（業種コード）
            if (labelSet_GyoshuCd.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_GyoshuCd.Focus();
                return;
            }
            //文字判定（締切日）
            if (txtSime.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSime.Focus();
                return;
            }
            //文字判定（支払月数）
            if (txtSihatuki.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSihatuki.Focus();
                return;
            }
            //文字判定（支払日）
            if (txtSihabi.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSihabi.Focus();
                return;
            }
            //文字判定（集金区分）
            if (txtShukinkbn.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtShukinkbn.Focus();
                return;
            }
            //文字判定（請求書有無）
            if (txtSeikyuumu.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSeikyuumu.Focus();
                return;
            }
            //文字判定（納品書有無）
            if (txtNohinshoumu.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtNohinshoumu.Focus();
                return;
            }
            //文字判定（税区分）
            if (txtZeikbn.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtZeikbn.Focus();
                return;
            }
            //文字判定（税計算区分）
            if (txtKeisankbn.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtKeisankbn.Focus();
                return;
            }
            //文字判定（税は数計算区分）
            if (txtZeihasu.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtZeihasu.Focus();
                return;
            }
            //文字判定（明細端数区分）
            if (txtMesai.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtMesai.Focus();
                return;
            }
            //文字判定（資本金）
            if (txtSihon.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSihon.Focus();
                return;
            }
            //文字判定（従業員数）
            if (txtJugyo.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtJugyo.Focus();
                return;
            }

            //文字判定（業務担当者コード）
            if(labelSet_GyomuTantousha.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_GyomuTantousha.Focus();
                return;
            }

            // 文字列チェック
            if (labelSet_GyomuTantousha.chkTxtTantosha())
            {
                return;
            }

            //文字判定（納入方法）
            if (StringUtl.blIsEmpty(cmbNonyu.Text) == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                cmbNonyu.Focus();
                return;
            }

            //登録情報を入れる（多いため割愛部分あり）
            //取引先
            lstTorihikisaki.Add(txtCdT.Text);
            lstTorihikisaki.Add(txtNameT.Text);
            lstTorihikisaki.Add(txtHuriT.Text);
            lstTorihikisaki.Add(txtYubinT.Text);
            lstTorihikisaki.Add(txtJusho1T.Text);
            lstTorihikisaki.Add(txtJusho2T.Text);
            lstTorihikisaki.Add(txtDenwaT.Text);
            lstTorihikisaki.Add(txtFAXT.Text);
            lstTorihikisaki.Add(txtYubinAT.Text);
            lstTorihikisaki.Add(txtJusho1AT.Text);
            lstTorihikisaki.Add(txtJusho2AT.Text);
            lstTorihikisaki.Add(txtDenwaAT.Text);
            lstTorihikisaki.Add(txtFAXAT.Text);
            lstTorihikisaki.Add(txtEmail.Text);
            lstTorihikisaki.Add(txtTantoNameA.Text);
            lstTorihikisaki.Add(txtBushoNameA.Text);
            lstTorihikisaki.Add(txtTantoEmailA.Text);

            //領収書送付先
            lstTorihikisaki.Add(txtNameR.Text);
            lstTorihikisaki.Add(txtYubinR.Text);
            lstTorihikisaki.Add(txtJusho1R.Text);
            lstTorihikisaki.Add(txtJusho2R.Text);
            lstTorihikisaki.Add(txtDenwaR.Text);
            lstTorihikisaki.Add(txtFAXR.Text);

            //業種コード
            lstTorihikisaki.Add(labelSet_GyoshuCd.codeTxt.Text);

            //担当者コード
            lstTorihikisaki.Add(labelSet_Tantousha.codeTxt.Text);

            //請求書送付先
            lstTorihikisaki.Add(txtNameS.Text);
            lstTorihikisaki.Add(txtYubinS.Text);
            lstTorihikisaki.Add(txtJusho1S.Text);
            lstTorihikisaki.Add(txtJusho2S.Text);
            lstTorihikisaki.Add(txtDenwaS.Text);
            lstTorihikisaki.Add(txtFAXS.Text);

            //〆関係
            lstTorihikisaki.Add(txtSime.Text);
            lstTorihikisaki.Add(txtSihatuki.Text);
            lstTorihikisaki.Add(txtSihabi.Text);
            lstTorihikisaki.Add(txtJoken.Text);
            lstTorihikisaki.Add(txtShukinkbn.Text);
            lstTorihikisaki.Add(txtSeikyuumu.Text);

            //税金関係
            lstTorihikisaki.Add(txtZeikbn.Text);
            lstTorihikisaki.Add(txtKeisankbn.Text);
            lstTorihikisaki.Add(txtZeihasu.Text);
            lstTorihikisaki.Add(txtMesai.Text);

            //会社内容関係
            lstTorihikisaki.Add(txtSiha.Text);
            lstTorihikisaki.Add(txtDaihyo.Text);
            lstTorihikisaki.Add(txtSihon.Text);
            lstTorihikisaki.Add(txtSeturitu.Text);
            lstTorihikisaki.Add(txtJugyo.Text);
            lstTorihikisaki.Add(txtKesan.Text);
            lstTorihikisaki.Add(txtGinko.Text);
            lstTorihikisaki.Add(txtSiten.Text);
            lstTorihikisaki.Add(txtShubetu.Text);
            lstTorihikisaki.Add(txtBango.Text);
            lstTorihikisaki.Add(txtKoza.Text);
            lstTorihikisaki.Add(txtToriatu.Text);

            //主な取引先
            lstTorihikisaki.Add(txtTorihiki1.Text);
            lstTorihikisaki.Add(txtTorihiki2.Text);
            lstTorihikisaki.Add(txtTorihiki3.Text);
            lstTorihikisaki.Add(txtTorihiki4.Text);
            lstTorihikisaki.Add(txtTorihiki5.Text);
            lstTorihikisaki.Add(txtTorihiki6.Text);
            lstTorihikisaki.Add(txtTorihiki7.Text);
            lstTorihikisaki.Add(txtTorihiki8.Text);
            lstTorihikisaki.Add(txtTorihiki9.Text);
            lstTorihikisaki.Add(txtTorihiki10.Text);
            lstTorihikisaki.Add(txtTorihiki11.Text);
            lstTorihikisaki.Add(txtTorihiki12.Text);
            lstTorihikisaki.Add(txtTorihiki13.Text);
            lstTorihikisaki.Add(txtTorihiki14.Text);
            lstTorihikisaki.Add(txtTorihiki15.Text);
            lstTorihikisaki.Add(txtTorihiki16.Text);
            lstTorihikisaki.Add(txtTorihiki17.Text);
            lstTorihikisaki.Add(txtTorihiki18.Text);
            lstTorihikisaki.Add(txtTorihiki19.Text);
            lstTorihikisaki.Add(txtTorihiki20.Text);

            //納入方法
            lstTorihikisaki.Add(cmbNonyu.Text);
            //業務担当者
            lstTorihikisaki.Add(labelSet_GyomuTantousha.CodeTxtText);

            // 納品書有無
            lstTorihikisaki.Add(txtNohinshoumu.Text);

            //ユーザー名
            lstTorihikisaki.Add(SystemInformation.UserName);

            //ビジネス層のインスタンス生成
            M1070_Torihikisaki_B torihikisakiB = new M1070_Torihikisaki_B();
            try
            {
                //登録
                torihikisakiB.addTorihiki(lstTorihikisaki);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();

            }
            catch (Exception ex)
            {
                //エラーロギング
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
            txtSihon.Text = "";

            // クリア後は登録、削除、取消は無効化
            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;
        }
        
        ///<summary>
        ///delTorihiki
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delTorihiki()
        {
            //記入情報削除用
            List<string> lstTorihikisaki = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //文字判定（取引先コード）
            if (txtCdT.blIsEmpty() == false)
            {
                return;
            }

            //空文字判定
            if (chkToriikisaki())
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1070_Torihikisaki_B torihikisakiB = new M1070_Torihikisaki_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = torihikisakiB.getTxtTorihikiCdLeave(txtCdT.Text);

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

                //削除情報を入れる（多いため割愛部分あり）
                //取引先
                lstTorihikisaki.Add(dtSetCd.Rows[0]["取引先コード"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["取引先名称"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["カナ"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["郵便番号"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["住所１"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["住所２"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["電話番号"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["ＦＡＸ番号"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["Ａ郵便番号"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["Ａ住所１"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["Ａ住所２"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["Ａ電話番号"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["ＡＦＡＸ番号"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["ＭＡＩＬ"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["担当者名"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["部署名"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["担当ＭＡＩＬ"].ToString());

                //領収書送付先
                lstTorihikisaki.Add(dtSetCd.Rows[0]["領収書送付先名"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["領収書送付郵便番号"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["領収書送付住所１"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["領収書送付住所２"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["領収書送付電話番号"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["領収書送付ＦＡＸ番号"].ToString());

                //業種コード
                lstTorihikisaki.Add(dtSetCd.Rows[0]["業種コード"].ToString());

                //担当者コード
                lstTorihikisaki.Add(dtSetCd.Rows[0]["担当者コード"].ToString());

                //請求書送付先
                lstTorihikisaki.Add(dtSetCd.Rows[0]["請求書送付先名"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["請求書送付郵便番号"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["請求書送付住所１"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["請求書送付住所２"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["請求書送付電話番号"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["請求書送付ＦＡＸ番号"].ToString());

                //〆関係
                lstTorihikisaki.Add(dtSetCd.Rows[0]["締切日"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["支払月数"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["支払日"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["支払条件"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["集金区分"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["請求書有無"].ToString());

                //税金関係
                lstTorihikisaki.Add(dtSetCd.Rows[0]["消費税区分"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["消費税計算区分"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["消費税端数計算区分"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["明細行円以下計算区分"].ToString());

                //会社内容関係
                lstTorihikisaki.Add(dtSetCd.Rows[0]["変則支払条件"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["取引先代表者名"].ToString());
                lstTorihikisaki.Add(((decimal)dtSetCd.Rows[0]["取引先資本金"]).ToString("#,#"));
                lstTorihikisaki.Add(dtSetCd.Rows[0]["設立年月日"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["従業員数"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["決算日"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["銀行名"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["支店名"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["口座種別"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["口座番号"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["口座名義"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["取扱品目"].ToString());

                //主な取引先
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先１"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先２"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先３"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先４"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先５"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先６"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先７"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先８"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先９"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先１０"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先１１"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先１２"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先１３"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先１４"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先１５"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先１６"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先１７"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先１８"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先１９"].ToString());
                lstTorihikisaki.Add(dtSetCd.Rows[0]["主な取引先２０"].ToString());

                //納入方法
                lstTorihikisaki.Add(dtSetCd.Rows[0]["納入方法"].ToString());
                //業務担当者
                lstTorihikisaki.Add(dtSetCd.Rows[0]["業務担当者コード"].ToString());
                // 納品書有無
                lstTorihikisaki.Add(dtSetCd.Rows[0]["納品書印刷"].ToString());
                //ユーザー名
                lstTorihikisaki.Add(SystemInformation.UserName);

                torihikisakiB.delTorihiki(lstTorihikisaki);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();

                txtCdT.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///setTorihikisaki
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setTorihikisaki(DataTable dtSelectData)
        {
            //表示項目をリセット
            delFormClear(this);
            txtSihon.Text = "";

            //取引先
            txtCdT.Text = dtSelectData.Rows[0]["取引先コード"].ToString();
            txtNameT.Text = dtSelectData.Rows[0]["取引先名称"].ToString();
            txtHuriT.Text = dtSelectData.Rows[0]["カナ"].ToString();
            txtYubinT.Text = dtSelectData.Rows[0]["郵便番号"].ToString();
            txtJusho1T.Text = dtSelectData.Rows[0]["住所１"].ToString();
            txtJusho2T.Text = dtSelectData.Rows[0]["住所２"].ToString();
            txtDenwaT.Text = dtSelectData.Rows[0]["電話番号"].ToString();
            txtFAXT.Text = dtSelectData.Rows[0]["ＦＡＸ番号"].ToString();
            txtYubinAT.Text = dtSelectData.Rows[0]["Ａ郵便番号"].ToString();
            txtJusho1AT.Text = dtSelectData.Rows[0]["Ａ住所１"].ToString();
            txtJusho2AT.Text = dtSelectData.Rows[0]["Ａ住所２"].ToString();
            txtDenwaAT.Text = dtSelectData.Rows[0]["Ａ電話番号"].ToString();
            txtFAXAT.Text = dtSelectData.Rows[0]["ＡＦＡＸ番号"].ToString();
            txtEmail.Text = dtSelectData.Rows[0]["ＭＡＩＬ"].ToString();
            txtTantoNameA.Text = dtSelectData.Rows[0]["担当者名"].ToString();
            txtBushoNameA.Text = dtSelectData.Rows[0]["部署名"].ToString();
            txtTantoEmailA.Text = dtSelectData.Rows[0]["担当ＭＡＩＬ"].ToString();

            //領収書送付先
            txtNameR.Text = dtSelectData.Rows[0]["領収書送付先名"].ToString();
            txtYubinR.Text = dtSelectData.Rows[0]["領収書送付郵便番号"].ToString();
            txtJusho1R.Text = dtSelectData.Rows[0]["領収書送付住所１"].ToString();
            txtJusho2R.Text = dtSelectData.Rows[0]["領収書送付住所２"].ToString();
            txtDenwaR.Text = dtSelectData.Rows[0]["領収書送付電話番号"].ToString();
            txtFAXR.Text = dtSelectData.Rows[0]["領収書送付ＦＡＸ番号"].ToString();

            //業種コード
            labelSet_GyoshuCd.codeTxt.Text = dtSelectData.Rows[0]["業種コード"].ToString();

            //担当者コード
            labelSet_Tantousha.codeTxt.Text = dtSelectData.Rows[0]["担当者コード"].ToString();

            //請求書送付先
            txtNameS.Text = dtSelectData.Rows[0]["請求書送付先名"].ToString();
            txtYubinS.Text = dtSelectData.Rows[0]["請求書送付郵便番号"].ToString();
            txtJusho1S.Text = dtSelectData.Rows[0]["請求書送付住所１"].ToString();
            txtJusho2S.Text = dtSelectData.Rows[0]["請求書送付住所２"].ToString();
            txtDenwaS.Text = dtSelectData.Rows[0]["請求書送付電話番号"].ToString();
            txtFAXS.Text = dtSelectData.Rows[0]["請求書送付ＦＡＸ番号"].ToString();

            //〆関係
            txtSime.Text = dtSelectData.Rows[0]["締切日"].ToString();
            txtSihatuki.Text = dtSelectData.Rows[0]["支払月数"].ToString();
            txtSihabi.Text = dtSelectData.Rows[0]["支払日"].ToString();
            txtJoken.Text = dtSelectData.Rows[0]["支払条件"].ToString();
            txtShukinkbn.Text = dtSelectData.Rows[0]["集金区分"].ToString();
            txtSeikyuumu.Text = dtSelectData.Rows[0]["請求書有無"].ToString();

            //税金関係
            txtZeikbn.Text = dtSelectData.Rows[0]["消費税区分"].ToString();
            txtKeisankbn.Text = dtSelectData.Rows[0]["消費税計算区分"].ToString();
            txtZeihasu.Text = dtSelectData.Rows[0]["消費税端数計算区分"].ToString();
            txtMesai.Text = dtSelectData.Rows[0]["明細行円以下計算区分"].ToString();

            //会社内容関係
            txtSiha.Text = dtSelectData.Rows[0]["変則支払条件"].ToString();
            txtDaihyo.Text = dtSelectData.Rows[0]["取引先代表者名"].ToString();
            txtSihon.Text = ((decimal)dtSelectData.Rows[0]["取引先資本金"]).ToString("#,#");
            txtSeturitu.Text = dtSelectData.Rows[0]["設立年月日"].ToString();
            txtJugyo.Text = dtSelectData.Rows[0]["従業員数"].ToString();
            txtKesan.Text = dtSelectData.Rows[0]["決算日"].ToString();
            txtGinko.Text = dtSelectData.Rows[0]["銀行名"].ToString();
            txtSiten.Text = dtSelectData.Rows[0]["支店名"].ToString();
            txtShubetu.Text = dtSelectData.Rows[0]["口座種別"].ToString();
            txtBango.Text = dtSelectData.Rows[0]["口座番号"].ToString();
            txtKoza.Text = dtSelectData.Rows[0]["口座名義"].ToString();
            txtToriatu.Text = dtSelectData.Rows[0]["取扱品目"].ToString();

            //主な取引先
            txtTorihiki1.Text = dtSelectData.Rows[0]["主な取引先１"].ToString();
            txtTorihiki2.Text = dtSelectData.Rows[0]["主な取引先２"].ToString();
            txtTorihiki3.Text = dtSelectData.Rows[0]["主な取引先３"].ToString();
            txtTorihiki4.Text = dtSelectData.Rows[0]["主な取引先４"].ToString();
            txtTorihiki5.Text = dtSelectData.Rows[0]["主な取引先５"].ToString();
            txtTorihiki6.Text = dtSelectData.Rows[0]["主な取引先６"].ToString();
            txtTorihiki7.Text = dtSelectData.Rows[0]["主な取引先７"].ToString();
            txtTorihiki8.Text = dtSelectData.Rows[0]["主な取引先８"].ToString();
            txtTorihiki9.Text = dtSelectData.Rows[0]["主な取引先９"].ToString();
            txtTorihiki10.Text = dtSelectData.Rows[0]["主な取引先１０"].ToString();
            txtTorihiki11.Text = dtSelectData.Rows[0]["主な取引先１１"].ToString();
            txtTorihiki12.Text = dtSelectData.Rows[0]["主な取引先１２"].ToString();
            txtTorihiki13.Text = dtSelectData.Rows[0]["主な取引先１３"].ToString();
            txtTorihiki14.Text = dtSelectData.Rows[0]["主な取引先１４"].ToString();
            txtTorihiki15.Text = dtSelectData.Rows[0]["主な取引先１５"].ToString();
            txtTorihiki16.Text = dtSelectData.Rows[0]["主な取引先１６"].ToString();
            txtTorihiki17.Text = dtSelectData.Rows[0]["主な取引先１７"].ToString();
            txtTorihiki18.Text = dtSelectData.Rows[0]["主な取引先１８"].ToString();
            txtTorihiki19.Text = dtSelectData.Rows[0]["主な取引先１９"].ToString();
            txtTorihiki20.Text = dtSelectData.Rows[0]["主な取引先２０"].ToString();

            //納入方法
            cmbNonyu.Text = dtSelectData.Rows[0]["納入方法"].ToString();
            //業務担当者
            labelSet_GyomuTantousha.CodeTxtText = dtSelectData.Rows[0]["業務担当者コード"].ToString();
            // 納品書有無
            txtNohinshoumu.Text = dtSelectData.Rows[0]["納品書印刷"].ToString();

        }

        ///<summary>
        ///setTorihikisakiCd
        ///取り出したデータをテキストボックスに配置（空番）
        ///</summary>
        public void setTorihikisakiCd(DataTable dtSelectData)
        {
            //表示項目をリセット
            delFormClear(this);
            txtSihon.Text = "";

            //取引先
            txtCdT.Text = dtSelectData.Rows[0]["取引先コード"].ToString();
        }

        ///<summary>
        ///     取引先リストが閉じたらコード入力欄にフォーカス
        ///</summary>
        public void CloseTorihikisakiList()
        {
            txtCdT.Focus();
        }

        ///<summary>
        ///     取引コードリストが閉じたらコード入力欄にフォーカス
        ///</summary>
        public void CloseTorihikiCdList()
        {
            txtCdT.Focus();
        }

        ///<summary>
        ///     担当者リストが閉じたらコード入力欄にフォーカス
        ///</summary>
        public void CloseTantoshaList()
        {
            labelSet_Tantousha.Focus();
        }

        ///<summary>
        ///txtCdT_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void txtCdT_Leave(object sender, EventArgs e)
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //空文字判定
            if (chkToriikisaki())
            {
                return;
            }

            // 取引先コード格納
            string torihikiCode = txtCdT.Text;

            //ビジネス層のインスタンス生成
            M1070_Torihikisaki_B torihikisakiB = new M1070_Torihikisaki_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = torihikisakiB.getTxtTorihikiCdLeave(torihikiCode);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    setTorihikisaki(dtSetCd);

                    // データ表示後、下記ボタン有効化
                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = true;
                    this.btnF04.Enabled = true;
                }
                else
                {
                    delText();
                    // 画面クリアしても取引先コードは残す
                    txtCdT.Text = torihikiCode;

                    // データ表示後、下記ボタン有効化
                    this.btnF01.Enabled = true;
                    this.btnF04.Enabled = true;
                            
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
        ///judtxtTorihikiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtTorihikiKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            //ベーステキストのインスタンス生成
            BaseText basetext = new BaseText();

            //キー判定、文字数判定
            basetext.judKeyUp(cActiveBefore, e);

        }

        ///<summary>
        ///cmbNonyu_KeyUp
        ///入力項目上でのキー判定と文字数判定(コンボボックス用)
        ///</summary>
        private void cmbNonyu_KeyUp(object sender, KeyEventArgs e)
        {
            cActiveBefore = this.ActiveControl;

            //ベーステキストのインスタンス生成
            BaseText basetext = new BaseText();

            //キー判定、文字数判定
            basetext.judKeyUp(cActiveBefore, e);

        }

        ///<summary>
        ///txt_KeyPress
        ///入力項目上でのキー判定
        ///</summary>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b'
                        && e.KeyChar != '\u0001' && e.KeyChar != '\u0003' && e.KeyChar != '\u0016' && e.KeyChar != '\u0018')
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        ///<summary>
        ///printTorihiki
        ///印刷ダイアログ
        ///</summary>
        private void printTorihiki()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //PDF作成後の入れ物
            string strFile = "";

            //ビジネス層のインスタンス生成
            M1070_Torihikisaki_B torihikiB = new M1070_Torihikisaki_B();
            try
            {
                dtSetCd_B = torihikiB.getPrintData();

                //取得したデータがない場合
                if (dtSetCd_B.Rows.Count == 0 || dtSetCd_B == null)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

                //初期値
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, YOKO);

                pf.ShowDialog(this);

                //プレビューの場合
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    this.Cursor = Cursors.WaitCursor;

                    //結果セットをレコードセットに
                    strFile = torihikiB.dbToPdf(dtSetCd_B);

                    this.Cursor = Cursors.Default;

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    this.Cursor = Cursors.WaitCursor;

                    // PDF作成
                    strFile = torihikiB.dbToPdf(dtSetCd_B);

                    this.Cursor = Cursors.Default;

                    // 一括印刷
                    pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
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
        ///labelset_Enter
        ///フォーカスが来た場合
        ///</summary>
        private void labelset_Enter(object sender, EventArgs e)
        {
            //エラーメッセージ表示がされたかどうか
            if (blMessageOn == true)
            {
                //フォーカス位置確保
                Control cActive = this.ActiveControl;

                switch (cActive.Name)
                {
                    //1
                    case "labelSet_Tantousha":

                        labelSet_Tantousha.codeTxt.BackColor = Color.White;
                        break;

                    //2
                    case "labelSet_GyoshuCd":

                        labelSet_GyoshuCd.codeTxt.BackColor = Color.White;
                        break;

                    //3
                    case "labelSet_GyomuTantousha":

                        labelSet_GyomuTantousha.codeTxt.BackColor = Color.White;
                        break;

                }

                //初期化
                blMessageOn = false;

                switch (cActiveBefore.Name)
                {
                    //1
                    case "labelSet_Tantousha":
                        labelSet_Tantousha.Focus();
                        labelSet_Tantousha.codeTxt.BackColor = Color.Cyan;
                        break;

                    //2
                    case "labelSet_GyoshuCd":
                        labelSet_GyoshuCd.Focus();
                        labelSet_GyoshuCd.codeTxt.BackColor = Color.Cyan;
                        break;

                    //3
                    case "labelSet_GyomuTantousha":
                        labelSet_GyomuTantousha.Focus();
                        labelSet_GyomuTantousha.codeTxt.BackColor = Color.Cyan;
                        break;
                }
            }
            else
            {
                //フォーカス位置の確保
                cActiveBefore = this.ActiveControl;
            }
        }

        ///<summary>
        ///labelset_Leave
        ///フォーカスが外れた場合
        ///</summary>
        private void labelset_Leave(object sender, EventArgs e)
        {
            switch (cActiveBefore.Name)
            {
                //1
                case "labelSet_Tantousha":

                    //メッセージ表示がされていた場合
                    if (labelSet_Tantousha.blMessageOn == true)
                    {
                        blMessageOn = true;
                        //初期化
                        labelSet_Tantousha.blMessageOn = false;
                    }

                    break;

                //2
                case "labelSet_GyoshuCd":

                    //メッセージ表示がされていた場合
                    if (labelSet_GyoshuCd.blMessageOn == true)
                    {
                        blMessageOn = true;
                        //初期化
                        labelSet_GyoshuCd.blMessageOn = false;
                    }

                    break;

                //3
                case "labelSet_GyomuTantousha":

                    //メッセージ表示がされていた場合
                    if (labelSet_GyomuTantousha.blMessageOn == true)
                    {
                        blMessageOn = true;
                        //初期化
                        labelSet_GyomuTantousha.blMessageOn = false;
                    }

                    break;
            }
        }
        
        ///<summary>
        ///torihikisaki_Enter
        ///code入力箇所からフォーカスがついた時
        ///</summary>
        private void torihikisaki_Enter(object sender, EventArgs e)
        {
            if (blMessageOn == true)
            {
                cActiveBefore.Focus();
            }
        }

        ///<summary>
        ///NomberTxt_KeyPress
        ///数値のみ通す処理
        ///</summary>
        private void NomberTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b'
                        && e.KeyChar != '\u0001' && e.KeyChar != '\u0003' && e.KeyChar != '\u0016' && e.KeyChar != '\u0018')
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        private void txtHuriT_Leave(object sender, EventArgs e)
        {
            //ビジネス層のインスタンス生成
            M1070_Torihikisaki_B torihikiB = new M1070_Torihikisaki_B();

            // フリガナ入力されている場合
            if (txtHuriT.blIsEmpty())
            {
                // フリガナ文字チェック
                string kana = torihikiB.chkFurigana(txtHuriT.Text.Trim());

                // 半角カナ変換ではなく"FALSE"が返ってきた場合エラーメッセージ
                if (kana.Equals("FALSE"))
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "ひらがなとカタカナ以外の文字列が含まれています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtHuriT.Focus();
                    return;
                }
                else
                {
                    txtHuriT.Text = kana;
                }
            }
        }

        ///<summary>
        ///chkToriikisaki
        ///code入力箇所からフォーカスがついた時
        ///</summary>
        private bool chkToriikisaki()
        {

            if (txtCdT.Text == "" || String.IsNullOrWhiteSpace(txtCdT.Text).Equals(true))
            {
                return false;
            }

            // 前後の空白を取り除く
            txtCdT.Text = txtCdT.Text.Trim();

            // 禁止文字チェック
            if (StringUtl.JudBanSQL(txtCdT.Text) == false)
            {
                // メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return true;
            }


            // 全角数字を半角数字に変換
            txtCdT.Text = StringUtl.JudZenToHanNum(txtCdT.Text);

            // 数値チェック
            if (StringUtl.JudBanSelect(txtCdT.Text, CommonTeisu.NUMBER_ONLY) == true)
            {
                // 4文字以下の場合0パティング
                if (txtCdT.Text.Length < 4)
                {
                    txtCdT.Text = txtCdT.Text.ToString().PadLeft(4, '0');
                }
            }
            return false;
        }

    }
}
