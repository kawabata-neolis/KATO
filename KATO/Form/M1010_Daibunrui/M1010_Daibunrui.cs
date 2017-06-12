using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Business.M1010_Daibunrui;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1010_Daibunrui
{
    ///<summary>
    ///M1010_Daibunrui
    ///大分類フォーム
    ///作成者：大河内
    ///作成日：2017/2/2
    ///更新者：大河内
    ///更新日：2017/2/2
    ///カラム論理名
    ///</summary>
    public partial class M1010_Daibunrui : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// M1010_Daibunrui
        /// フォームの初期設定
        /// </summary>
        public M1010_Daibunrui(Control c)
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
        /// M1010_Daibunrui_Load
        /// 画面レイアウト設定
        /// </summary>
        private void M1010_Daibunrui_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "大分類マスタ";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;
        }

        /// <summary>
        /// judDaiBunruiKeyDown
        /// キー入力判定（画面全般）
        /// </summary>
        private void judDaiBunruiKeyDown(object sender, KeyEventArgs e)
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
                    this.addDaibunrui();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delDaibunrui();
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

        /// <summary>
        /// judDaiBunTxtKeyDown
        /// キー入力判定（無機能テキストボックス）
        /// </summary>
        private void judDaiBunTxtKeyDown(object sender, KeyEventArgs e)
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
        ///judTxtDaiTxtKeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void judTxtDaiTxtKeyDown(object sender, KeyEventArgs e)
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
                    judtxtDaibunKeyDown(sender, e);
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
                    this.addDaibunrui();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delDaibunrui();
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
        ///judtxtDaibunruiKeyDown
        ///ファンクションキー入力判定
        ///</summary>
        private void judtxtDaibunKeyDown(object sender, KeyEventArgs e)
        {
            //F9キーが押された場合
            if (e.KeyCode == Keys.F9)
            {
                //大分類リストのインスタンス生成
                DaibunruiList daibunruiList = new DaibunruiList(this);
                try
                {
                    //大分類リストの表示、画面IDを渡す
                    daibunruiList.StartPosition = FormStartPosition.Manual;
                    daibunruiList.intFrmKind = CommonTeisu.FRM_DAIBUNRUI;
                    daibunruiList.ShowDialog();
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
        ///addDaibunrui
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addDaibunrui()
        {
            //記入情報登録用
            List<string> lstString = new List<string>();

            //文字判定（大分類コード）
            if (txtDaibunrui.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtDaibunrui.Focus();
                return;
            }
            //文字判定（大分類名）
            if (txtName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtName.Focus();
                return;
            }

            //登録情報を入れる（大分類コード、大分類名、ラべル１～６、ユーザー名）
            lstString.Add(txtDaibunrui.Text);
            lstString.Add(txtName.Text);
            lstString.Add(txtLabel1.Text);
            lstString.Add(txtLabel2.Text);
            lstString.Add(txtLabel3.Text);
            lstString.Add(txtLabel4.Text);
            lstString.Add(txtLabel5.Text);
            lstString.Add(txtLabel6.Text);
            lstString.Add(SystemInformation.UserName);

            //ビジネス層のインスタンス生成
            M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();
            try
            {
                //登録
                daibunB.addDaibunrui(lstString);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtDaibunrui.Focus();
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
        ///テキストボックス等の入力情報を白紙にする
        /// </summary>
        private void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);
            txtDaibunrui.Focus();
        }

        /// <summary>
        /// delDaibunrui
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void delDaibunrui()
        {
            //記入情報削除用
            List<string> lstDaibunData = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //空文字判定（大分類コード）
            if (txtDaibunrui.blIsEmpty() == false)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();
            try
            {
                //検索
                dtSetCd = daibunB.updTxtDaibunruiLeave(txtDaibunrui.Text);

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

                //削除情報を入れる（大分類CD、大分類名、ラベル１～６、ユーザー名）
                lstDaibunData.Add(txtDaibunrui.Text);
                lstDaibunData.Add(txtName.Text);
                lstDaibunData.Add(txtLabel1.Text);
                lstDaibunData.Add(txtLabel2.Text);
                lstDaibunData.Add(txtLabel3.Text);
                lstDaibunData.Add(txtLabel4.Text);
                lstDaibunData.Add(txtLabel5.Text);
                lstDaibunData.Add(txtLabel6.Text);
                lstDaibunData.Add(SystemInformation.UserName);

                //ビジネス層、削除ロジックに移動
                daibunB.delDaibunrui(lstDaibunData);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtDaibunrui.Focus();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        /// <summary>
        /// setDaibunrui
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setDaibunrui(DataTable dtSelectData)
        {
            txtDaibunrui.Text = dtSelectData.Rows[0]["大分類コード"].ToString();
            txtName.Text = dtSelectData.Rows[0]["大分類名"].ToString();
            txtLabel1.Text = dtSelectData.Rows[0]["ラベル名１"].ToString();
            txtLabel2.Text = dtSelectData.Rows[0]["ラベル名２"].ToString();
            txtLabel3.Text = dtSelectData.Rows[0]["ラベル名３"].ToString();
            txtLabel4.Text = dtSelectData.Rows[0]["ラベル名４"].ToString();
            txtLabel5.Text = dtSelectData.Rows[0]["ラベル名５"].ToString();
            txtLabel6.Text = dtSelectData.Rows[0]["ラベル名６"].ToString();
        }


        /// <summary>
        /// updTxtDaibunruiLeave
        /// code入力箇所からフォーカスが外れた時
        /// </summary>
        public void updTxtDaibunruiLeave(object sender, EventArgs e)
        {
            //フォーカス位置の確保
            Control cActive = this.ActiveControl;

            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //文字チェック用
            bool blGood;

            //前後の空白を取り除く
            txtDaibunrui.Text = txtDaibunrui.Text.Trim();

            //空文字判定
            if (txtDaibunrui.blIsEmpty() == false)
            {
                return;
            }

            //文字数が足りなかった場合0パティング
            if (txtDaibunrui.TextLength == 1)
            {
                txtDaibunrui.Text = txtDaibunrui.Text.ToString().PadLeft(2, '0');
            }

            //禁止文字チェック
            blGood = StringUtl.JudBanChr(txtDaibunrui.Text);
            //数字のみを許可する
            blGood = StringUtl.JudBanSelect(txtDaibunrui.Text, CommonTeisu.NUMBER_ONLY);

            //文字チェックが通らなかった場合
            if (blGood == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDaibunrui.Focus();
                return;
            }

            //ビジネス層、検索ロジックに移動
            M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = daibunB.updTxtDaibunruiLeave(txtDaibunrui.Text);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtDaibunrui.Text = dtSetCd.Rows[0]["大分類コード"].ToString();
                    txtName.Text = dtSetCd.Rows[0]["大分類名"].ToString();
                    txtLabel1.Text = dtSetCd.Rows[0]["ラベル名１"].ToString();
                    txtLabel2.Text = dtSetCd.Rows[0]["ラベル名２"].ToString();
                    txtLabel3.Text = dtSetCd.Rows[0]["ラベル名３"].ToString();
                    txtLabel4.Text = dtSetCd.Rows[0]["ラベル名４"].ToString();
                    txtLabel5.Text = dtSetCd.Rows[0]["ラベル名５"].ToString();
                    txtLabel6.Text = dtSetCd.Rows[0]["ラベル名６"].ToString();
                    txtName.Focus();
                }
                cActive.Focus();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        /// <summary>
        /// setDaibunruiListClose
        /// DaibunruiListが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setDaibunruiListClose()
        {
            txtDaibunrui.Focus();
        }

        /// <summary>
        /// judtxtDaibunruiKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtDaibunruiKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
