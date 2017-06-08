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
        /// <summary>
        /// M1070_Torihikisaki
        /// フォーム関係の設定
        /// </summary>
        public M1070_Torihikisaki(Control c)
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

        /// <summary>
        /// M1070_Torihikisaki_Load
        /// 読み込み時
        /// </summary>
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

            //コンボボックス内データの追加
            cmbNonyu.Items.Add("配達");
            cmbNonyu.Items.Add("発送");
            cmbNonyu.Items.Add("直送");
            cmbNonyu.Items.Add("代引き");
            cmbNonyu.Items.Add("来店");
        }

        /// <summary>
        /// judTorihikiKeyDown
        /// キー入力判定
        /// </summary>
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
                    this.addTorihiki();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delTorihiki();
                    break;
                case Keys.F4:
                    this.delText();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    this.setAkiban();
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// judTorihikiTxtKeyDown
        /// キー入力判定
        /// </summary>
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
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// judTxtToriTxtKeyDown
        /// キー入力判定
        /// </summary>
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
                    txtCdT_KeyDown(sender, e);
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    this.Close();
                    break;

                default:
                    break;
            }
        }


        /// <summary>
        /// txtCdT_KeyDown
        /// コード入力項目でのキー入力判定
        /// </summary>
        private void txtCdT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                TorihikisakiList torihikisakilist = new TorihikisakiList(this);
                try
                {
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
                    new CommonException(ex);
                    return;
                }
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
                case STR_BTN_F01: // 登録
                    this.addTorihiki();
                    break;
                case STR_BTN_F03: // 削除
                    this.delTorihiki();
                    break;
                case STR_BTN_F04: // 取り消し
                    this.delText();
                    break;
                case STR_BTN_F08: // 未割当の番号検索
                    this.delText();
                    break;
                //case STR_BTN_F11: //印刷
                //    this.XX();
                //    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// setAkiban
        /// ボタンの反応
        /// </summary>
        private void setAkiban()
        {
            try
            {
                TorihikiCdList torihikicdlist = new TorihikiCdList(this);
                torihikicdlist.intFrmKind = CommonTeisu.FRM_TORIHIKISAKI;
                torihikicdlist.ShowDialog();

                txtCdT.Focus();

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                return;
            }

        }

        /// <summary>
        /// addGyoushu
        /// テキストボックス内のデータをDBに登録
        /// </summary>
        private void addTorihiki()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtCdT.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtCdT.Focus();
                return;
            }
            if (txtNameT.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtNameT.Focus();
                return;
            }
            if (txtHuriT.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHuriT.Focus();
                return;
            }
            if (labelSet_Tantousha.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tantousha.Focus();
                return;
            }
            if (labelSet_GyoshuCd.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_GyoshuCd.Focus();
                return;
            }
            if (txtSime.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSime.Focus();
                return;
            }
            if (txtSihatuki.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSihatuki.Focus();
                return;
            }
            if (txtSihabi.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSihabi.Focus();
                return;
            }
            if (txtShukinkbn.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtShukinkbn.Focus();
                return;
            }
            if (txtSeikyuumu.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSeikyuumu.Focus();
                return;
            }
            if (txtZeikbn.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtZeikbn.Focus();
                return;
            }
            if (txtKeisankbn.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtKeisankbn.Focus();
                return;
            }
            if (txtZeihasu.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtZeihasu.Focus();
                return;
            }
            if (txtMesai.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtMesai.Focus();
                return;
            }
            if (txtSihon.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtSihon.Focus();
                return;
            }
            if (txtJugyo.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtJugyo.Focus();
                return;
            }
            //取引先
            lstString.Add(txtCdT.Text);
            lstString.Add(txtNameT.Text);
            lstString.Add(txtHuriT.Text);
            lstString.Add(txtYubinT.Text);
            lstString.Add(txtJusho1T.Text);
            lstString.Add(txtJusho2T.Text);
            lstString.Add(txtDenwaT.Text);
            lstString.Add(txtFAXT.Text);
            lstString.Add(txtYubinAT.Text);
            lstString.Add(txtJusho1AT.Text);
            lstString.Add(txtJusho2AT.Text);
            lstString.Add(txtDenwaAT.Text);
            lstString.Add(txtFAXAT.Text);
            lstString.Add(txtEmail.Text);
            lstString.Add(txtTantoNameA.Text);
            lstString.Add(txtBushoNameA.Text);
            lstString.Add(txtTantoEmailA.Text);

            //領収書送付先
            lstString.Add(txtNameR.Text);
            lstString.Add(txtYubinR.Text);
            lstString.Add(txtJusho1R.Text);
            lstString.Add(txtJusho2R.Text);
            lstString.Add(txtDenwaR.Text);
            lstString.Add(txtFAXR.Text);

            //業種コード
            lstString.Add(labelSet_GyoshuCd.codeTxt.Text);

            //担当者コード
            lstString.Add(labelSet_Tantousha.codeTxt.Text);

            //請求書送付先
            lstString.Add(txtNameS.Text);
            lstString.Add(txtYubinS.Text);
            lstString.Add(txtJusho1S.Text);
            lstString.Add(txtJusho2S.Text);
            lstString.Add(txtDenwaS.Text);
            lstString.Add(txtFAXS.Text);

            //〆関係
            lstString.Add(txtSime.Text);
            lstString.Add(txtSihatuki.Text);
            lstString.Add(txtSihabi.Text);
            lstString.Add(txtJoken.Text);
            lstString.Add(txtShukinkbn.Text);
            lstString.Add(txtSeikyuumu.Text);

            //税金関係
            lstString.Add(txtZeikbn.Text);
            lstString.Add(txtKeisankbn.Text);
            lstString.Add(txtZeihasu.Text);
            lstString.Add(txtMesai.Text);

            //会社内容関係
            lstString.Add(txtSiha.Text);
            lstString.Add(txtDaihyo.Text);
            lstString.Add(txtSihon.Text);
            lstString.Add(txtSeturitu.Text);
            lstString.Add(txtJugyo.Text);
            lstString.Add(txtKesan.Text);
            lstString.Add(txtGinko.Text);
            lstString.Add(txtSiten.Text);
            lstString.Add(txtShubetu.Text);
            lstString.Add(txtBango.Text);
            lstString.Add(txtKoza.Text);
            lstString.Add(txtToriatu.Text);

            //主な取引先
            lstString.Add(txtTorihiki1.Text);
            lstString.Add(txtTorihiki2.Text);
            lstString.Add(txtTorihiki3.Text);
            lstString.Add(txtTorihiki4.Text);
            lstString.Add(txtTorihiki5.Text);
            lstString.Add(txtTorihiki6.Text);
            lstString.Add(txtTorihiki7.Text);
            lstString.Add(txtTorihiki8.Text);
            lstString.Add(txtTorihiki9.Text);
            lstString.Add(txtTorihiki10.Text);
            lstString.Add(txtTorihiki11.Text);
            lstString.Add(txtTorihiki12.Text);
            lstString.Add(txtTorihiki13.Text);
            lstString.Add(txtTorihiki14.Text);
            lstString.Add(txtTorihiki15.Text);
            lstString.Add(txtTorihiki16.Text);
            lstString.Add(txtTorihiki17.Text);
            lstString.Add(txtTorihiki18.Text);
            lstString.Add(txtTorihiki19.Text);
            lstString.Add(txtTorihiki20.Text);

            //納入方法
            lstString.Add(cmbNonyu.Text);
            //業務担当者
            lstString.Add(txtGyotan.Text);

            //ユーザー名
            lstString.Add(SystemInformation.UserName);

            M1070_Torihikisaki_B torihikisakiB = new M1070_Torihikisaki_B();
            try
            {
                torihikisakiB.addTorihiki(lstString);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();

            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            delFormClear(this);
            txtSihon.Text = "";
            txtCdT.Focus();
        }

        /// <summary>
        /// delTextSearch
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delTextSearch()
        {
            delFormClear(this);
            txtSihon.Text = "";
        }
        
        /// <summary>
        /// delTorihiki
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void delTorihiki()
        {
            //データ渡し用
            List<string> lstStringLoad = new List<string>();
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            //文字判定
            if (txtCdT.blIsEmpty() == false)
            {
                return;
            }

            //処理部に移動(削除)
            M1070_Torihikisaki_B torihikisakiB = new M1070_Torihikisaki_B();

            try
            {
                lstStringLoad.Add(txtCdT.Text);

                //戻り値のDatatableを取り込む
                dtSetCd = torihikisakiB.updTxtTorihikiCdLeave(lstStringLoad);

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

                //データ渡し用
                lstString.Add(txtCdT.Text);
                lstString.Add(txtNameT.Text);
                lstString.Add(txtHuriT.Text);
                lstString.Add(txtYubinT.Text);
                lstString.Add(txtJusho1T.Text);
                lstString.Add(txtJusho2T.Text);
                lstString.Add(txtDenwaT.Text);
                lstString.Add(txtFAXT.Text);
                lstString.Add(txtYubinAT.Text);
                lstString.Add(txtJusho1AT.Text);
                lstString.Add(txtJusho2AT.Text);
                lstString.Add(txtDenwaAT.Text);
                lstString.Add(txtFAXAT.Text);
                lstString.Add(txtEmail.Text);
                lstString.Add(txtTantoNameA.Text);
                lstString.Add(txtBushoNameA.Text);
                lstString.Add(txtTantoEmailA.Text);

                //領収書送付先
                lstString.Add(txtNameR.Text);
                lstString.Add(txtYubinR.Text);
                lstString.Add(txtJusho1R.Text);
                lstString.Add(txtJusho2R.Text);
                lstString.Add(txtDenwaR.Text);
                lstString.Add(txtFAXR.Text);

                //業種コード
                lstString.Add(labelSet_GyoshuCd.codeTxt.Text);

                //担当者コード
                lstString.Add(labelSet_Tantousha.codeTxt.Text);

                //請求書送付先
                lstString.Add(txtNameS.Text);
                lstString.Add(txtYubinS.Text);
                lstString.Add(txtJusho1S.Text);
                lstString.Add(txtJusho2S.Text);
                lstString.Add(txtDenwaS.Text);
                lstString.Add(txtFAXS.Text);

                //〆関係
                lstString.Add(txtSime.Text);
                lstString.Add(txtSihatuki.Text);
                lstString.Add(txtSihabi.Text);
                lstString.Add(txtJoken.Text);
                lstString.Add(txtShukinkbn.Text);
                lstString.Add(txtSeikyuumu.Text);

                //税金関係
                lstString.Add(txtZeikbn.Text);
                lstString.Add(txtKeisankbn.Text);
                lstString.Add(txtZeihasu.Text);
                lstString.Add(txtMesai.Text);

                //会社内容関係
                lstString.Add(txtSiha.Text);
                lstString.Add(txtDaihyo.Text);
                lstString.Add(txtSihon.Text);
                lstString.Add(txtSeturitu.Text);
                lstString.Add(txtJugyo.Text);
                lstString.Add(txtKesan.Text);
                lstString.Add(txtGinko.Text);
                lstString.Add(txtSiten.Text);
                lstString.Add(txtShubetu.Text);
                lstString.Add(txtBango.Text);
                lstString.Add(txtKoza.Text);
                lstString.Add(txtToriatu.Text);

                //主な取引先
                lstString.Add(txtTorihiki1.Text);
                lstString.Add(txtTorihiki2.Text);
                lstString.Add(txtTorihiki3.Text);
                lstString.Add(txtTorihiki4.Text);
                lstString.Add(txtTorihiki5.Text);
                lstString.Add(txtTorihiki6.Text);
                lstString.Add(txtTorihiki7.Text);
                lstString.Add(txtTorihiki8.Text);
                lstString.Add(txtTorihiki9.Text);
                lstString.Add(txtTorihiki10.Text);
                lstString.Add(txtTorihiki11.Text);
                lstString.Add(txtTorihiki12.Text);
                lstString.Add(txtTorihiki13.Text);
                lstString.Add(txtTorihiki14.Text);
                lstString.Add(txtTorihiki15.Text);
                lstString.Add(txtTorihiki16.Text);
                lstString.Add(txtTorihiki17.Text);
                lstString.Add(txtTorihiki18.Text);
                lstString.Add(txtTorihiki19.Text);
                lstString.Add(txtTorihiki20.Text);

                //納入方法
                lstString.Add(cmbNonyu.Text);
                //業務担当者
                lstString.Add(txtGyotan.Text);

                //ユーザー名
                lstString.Add(SystemInformation.UserName);

                torihikisakiB.delTorihiki(lstString);
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

        /// <summary>
        /// setTorihikisaki
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setTorihikisaki(DataTable dtSelectData)
        {
            delTextSearch();

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
            txtSihon.Text = dtSelectData.Rows[0]["取引先資本金"].ToString();
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

            cmbNonyu.Text = dtSelectData.Rows[0]["納入方法"].ToString();
            txtGyotan.Text = dtSelectData.Rows[0]["業務担当者コード"].ToString();

        }

        /// <summary>
        /// setTokuisakiListClose
        /// GyoushuListが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setTokuisakiListClose()
        {
            txtCdT.Focus();
        }

        /// <summary>
        /// setTorihikiCdListClose
        /// 担当者リストが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setTorihikiCdListClose()
        {
            txtCdT.Focus();
        }

        ///<summary>
        ///txtCdT_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void txtCdT_Leave(object sender, EventArgs e)
        {
            Control cActive = this.ActiveControl;

            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            //文字判定
            if (txtCdT.blIsEmpty() == false)
            {
                return;
            }

            //前後の空白を取り除く
            txtCdT.Text = txtCdT.Text.Trim();

            if (txtCdT.TextLength < 4)
            {
                txtCdT.Text = txtCdT.Text.ToString().PadLeft(4, '0');
            }

            //データ渡し用
            lstString.Add(txtCdT.Text);

            //処理部に移動
            M1070_Torihikisaki_B torihikisakiB = new M1070_Torihikisaki_B();

            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = torihikisakiB.updTxtTorihikiCdLeave(lstString);

                if (dtSetCd.Rows.Count != 0)
                {
                    setTorihikisaki(dtSetCd);
                }
                //データの新規登録時に邪魔になるため、現段階削除予定
                //else
                //{
                //    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                //    basemessagebox.ShowDialog();
                //}

                txtSihon.Focus();
                cActive.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// judtxtTorihikiKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtTorihikiKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        /// <summary>
        /// judtxtTorihikiKeyUp
        /// 入力項目上でのキー判定と文字数判定(コンボボックス用)
        /// </summary>
        private void cmbNonyu_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ とタブ、エンター
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter || e.KeyCode == Keys.F12)
            {
                return;
            }
            //キーボードの方向キー4つ
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            {
                return;
            }

            //ファンクションキーにも対応すること

            //変換して扱う（これは該当がテキストボックスのみ場合は可能、他のツールには不可能）
            if (cActiveBefore.Text.Length == ((ComboBox)cActiveBefore).MaxLength)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// txt_KeyPress
        /// 入力項目上でのキー判定
        /// </summary>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }
    }
}
