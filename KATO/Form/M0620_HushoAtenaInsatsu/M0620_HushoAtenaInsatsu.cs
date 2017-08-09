using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Business.M1000_Kaishajyoken;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.M0620_HushoAtenaInsatsu;

namespace KATO.Form.M0620_HushoAtenaInsatsu
{
    public partial class M0620_HushoAtenaInsatsu : BaseForm
    {
        // ログ初期設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// M0620_HushoAtenaInsatsu
        /// コンストラクタ(画面初期設定)
        /// </summary>
        public M0620_HushoAtenaInsatsu(Control c)
        {
            if (c == null)
            {
                return;
            }

            // 現画面サイズ取得
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            // フォームが最大化されないようにする
            this.MaximizeBox = false;
            // フォームが最小化されないようにする
            this.MinimizeBox = false;

            // 最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            // ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            // 親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;
        }

        /// <summary>
        /// M0620_HushoAtenaInsatsu_Load
        /// 画面出力処理
        /// </summary>
        private void M0620_HushoAtenaInsatsu_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "メーカーマスタ";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            //用紙長３にチェック
            radSet_2btn_Yoshi.radbtn1.Checked = true;
            //敬称御中にチェック
            radSet_2btn_Kesho.radbtn1.Checked = true;
        }

        /// <summary>
        /// judKaisyaCodeKeyDown
        /// キー入力判定(会社コード)
        /// </summary>
        private void M0620_HushoAtenaInsatsu_KeyDown(object sender, KeyEventArgs e)
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
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                // 取消処理へ
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
                // 印刷処理へ
                case Keys.F11:
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));

                    break;
                // 終了処理へ
                case Keys.F12:
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
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

        }

        ///<summary>
        ///delText
        ///テキストボックス等の入力情報を白紙にする
        ///</summary>
        private void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);
            labelSet_Torihikisaki.Focus();

        }

        ///<summary>
        ///AtenaView
        ///取引先コード入力項目から離れた時
        ///</summary>
        public void AtenaView(object sender, EventArgs e)
        {
            //検索時のデータ取り出し先
            DataTable dtSetData;

            //取引先入力項目が空の場合
            if (!StringUtl.blIsEmpty(labelSet_Torihikisaki.CodeTxtText))
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M0620_HushoAtenaInsatsu_B hushoatenainsatsu = new M0620_HushoAtenaInsatsu_B();
            try
            {
                dtSetData = hushoatenainsatsu.getEigyoshoTextLeave(labelSet_Torihikisaki.CodeTxtText);

                //住所１を使用する場合
                if (radAtena1.Checked == true)
                {
                    lblGrayMeisho.Text = dtSetData.Rows[0]["取引先名称"].ToString();
                    lblGrayYubin.Text = dtSetData.Rows[0]["郵便番号"].ToString();
                    lblGrayJusho1.Text = dtSetData.Rows[0]["住所１"].ToString();
                    lblGrayJusho2.Text = dtSetData.Rows[0]["住所２"].ToString();
                }
                else if (radAtena2.Checked == true)
                {
                    lblGrayMeisho.Text = dtSetData.Rows[0]["取引先名称"].ToString();
                    lblGrayYubin.Text = dtSetData.Rows[0]["Ａ郵便番号"].ToString();
                    lblGrayJusho1.Text = dtSetData.Rows[0]["Ａ住所１"].ToString();
                    lblGrayJusho2.Text = dtSetData.Rows[0]["Ａ住所２"].ToString();
                }
                else if (radAtena3.Checked == true)
                {
                    lblGrayMeisho.Text = dtSetData.Rows[0]["領収書送付先名"].ToString();
                    lblGrayYubin.Text = dtSetData.Rows[0]["領収書送付郵便番号"].ToString();
                    lblGrayJusho1.Text = dtSetData.Rows[0]["領収書送付住所１"].ToString();
                    lblGrayJusho2.Text = dtSetData.Rows[0]["領収書送付住所２"].ToString();
                }
                else if (radAtena4.Checked == true)
                {
                    lblGrayMeisho.Text = dtSetData.Rows[0]["請求書送付先名"].ToString();
                    lblGrayYubin.Text = dtSetData.Rows[0]["請求書送付郵便番号"].ToString();
                    lblGrayJusho1.Text = dtSetData.Rows[0]["請求書送付住所１"].ToString();
                    lblGrayJusho2.Text = dtSetData.Rows[0]["請求書送付住所２"].ToString();
                }


//印刷ロジック

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

        private void printHushoNaga4()
        {

        }

        private void printHushoNaga3()
        {

        }

    }
}
