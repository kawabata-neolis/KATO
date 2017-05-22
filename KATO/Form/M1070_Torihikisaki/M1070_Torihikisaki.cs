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

            ////中分類setデータを読めるようにする
            //labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;
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
            this.btnF08.Text = STR_FUNC_F8_Torihikisaki;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

        }

        /// <summary>
        /// judToririkiKeyDown
        /// キー入力判定
        /// </summary>
        private void judToririkiKeyDown(object sender, KeyEventArgs e)
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
        /// txtCdT_KeyDown
        /// コード入力項目でのキー入力判定
        /// </summary>
        private void txtCdT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                TokuisakiList tokuisakilist = new TokuisakiList(this);
                try
                {
                    tokuisakilist.StartPosition = FormStartPosition.Manual;
                    tokuisakilist.intFrmKind = CommonTeisu.FRM_TORIHIKISAKI;
                    tokuisakilist.ShowDialog();

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
                case STR_BTN_F08: // 取り消し
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
            TorihikiCdList torihikicdlist = new TorihikiCdList(this);
            torihikicdlist.ShowDialog();
        }

        /// <summary>
        /// addGyoushu
        /// テキストボックス内のデータをDBに登録
        /// </summary>
        private void addTorihiki()
        {

        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            delFormClear(this);
            txtCdT.Focus();
        }

        /// <summary>
        /// delGyoushu
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void delTorihiki()
        {

        }

        /// <summary>
        /// setTorihikisaki
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setTorihikisaki(DataTable dtSelectData)
        {
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

    }
}
