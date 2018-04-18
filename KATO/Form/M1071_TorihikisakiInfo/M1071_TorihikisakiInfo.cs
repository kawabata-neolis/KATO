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
using KATO.Business.M1070_Torihikisaki;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1071_TorihikisakiInfo
{

    public partial class M1071_TorihikisakiInfo : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public M1071_TorihikisakiInfo(Control c)
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
        ///     Formロード
        ///</summary>
        private void M1071_TorihikisakiInfo_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "取引先情報";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // 検索ボタン無効化
            this.btnF09.Enabled = false;

            txtCdT.Focus();
        }
        
        ///<summary>
        ///     Form上のFunctionボタンクリック時
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printTorihiki();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///     txtCdTフォーカス時、F9：検索押下で取引先リスト表示
        ///</summary>
        private void displayTorihikisakiList(object sender, KeyEventArgs e)
        {
            //取引先リストのインスタンス生成
            TorihikisakiList torihikisakilist = new TorihikisakiList(this);
            try
            {
                logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                //取引先リストの表示、画面IDを渡す
                torihikisakilist.StartPosition = FormStartPosition.Manual;
                //torihikisakilist.intFrmKind = CommonTeisu.FRM_TORIHIKISAKI;
                torihikisakilist.intFrmKind = 1071;
                torihikisakilist.ShowDialog();

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
            txtNohinnshoumu.Text = dtSelectData.Rows[0]["納品書印刷"].ToString();
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

            //ビジネス層のインスタンス生成(M1071取引先情報画面でも、M1070取引先マスタのビジネスを利用する)
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
                    //結果セットをレコードセットに
                    strFile = torihikiB.dbToPdf(dtSetCd_B);

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    strFile = torihikiB.dbToPdf(dtSetCd_B);

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
        ///     テキストの文字チェック
        ///</summary>
        private Boolean chkText(string target)
        {
            //文字チェック用
            Boolean bln = false;

            //禁止文字チェック
            bln = StringUtl.JudBanChr(target);

            if (bln == true)
            {
                //数字のみを許可する
                bln = StringUtl.JudBanSelect(target, CommonTeisu.NUMBER_ONLY);
            }

            return bln;
        }

        ///<summary>
        ///     取引先リストが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void CloseTorihikisakiList()
        {
            txtCdT.Focus();
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除
        ///</summary>
        private void delText()
        {
            delFormClear(this);
            txtSihon.Text = "";
        }


        ///<summary>
        ///     Form上でのKeyDownイベント
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
        ///     コードTextBox でのKeyDownイベント
        ///</summary>
        private void txtCdT_KeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    break;
                case Keys.F9:
                    displayTorihikisakiList(sender, e);
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
        ///     コードTextBox でのKeyUpイベント
        ///</summary>
        private void txtCdT_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            //ベーステキストのインスタンス生成
            BaseText basetext = new BaseText();

            //キー判定、文字数判定
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///     コードTextBox からフォーカスが外れた場合
        ///</summary>
        private void txtCdT_Leave(object sender, EventArgs e)
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //前後の空白を取り除く
            txtCdT.Text = txtCdT.Text.Trim();

            //空文字判定
            if (txtCdT.blIsEmpty() == false)
            {
                return;
            }

            // 文字列チェック
            if (chkToriikisaki())
            {
                return;
            }

            // 取引先コード取得
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

                }
                else
                {
                    delText();
                    // 画面クリアしても取引先コードは残す
                    txtCdT.Text = torihikiCode;
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
            txtCdT.Focus();

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
