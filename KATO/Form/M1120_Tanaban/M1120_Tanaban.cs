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
using KATO.Business.M1120_Tanaban;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1120_Tanaban
{
    ///<summary>
    ///M1120_Tanaban
    ///棚番フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class M1120_Tanaban : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// M1120_Tanaban
        /// フォーム関係の設定
        /// </summary>
        public M1120_Tanaban(Control c)
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
        /// M1090_Eigyosho_Load
        /// 読み込み時
        /// </summary>
        private void M1120_Tanaban_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "営業所マスタ";
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
        ///M1120_Tanaban_KeyDown
        ///キー入力判定
        ///</summary>
        private void M1120_Tanaban_KeyDown(object sender, KeyEventArgs e)
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
                    this.addTanaban();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delTanaban();
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
        ///txtTanabanName_KeyDown
        ///キー入力判定
        ///</summary>
        private void txtTanabanName_KeyDown(object sender, KeyEventArgs e)
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
        ///txtTanabanCd_KeyDown
        ///キー入力判定
        ///</summary>
        private void txtTanabanCd_KeyDown(object sender, KeyEventArgs e)
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
                    txtTanabanKeyDown(sender, e);
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
        ///ボタンの反応
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addTanaban();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delTanaban();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                //case STR_BTN_F11: //印刷
                //    this.XX();
                //    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///txtTanabanKeyDown
        ///キー入力判定
        ///</summary>
        private void txtTanabanKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                TanabanList tanabanlist = new TanabanList(this);
                try
                {
                    tanabanlist.intFrmKind = CommonTeisu.FRM_TANABAN;
                    tanabanlist.ShowDialog();
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    return;
                }
            }
        }

        ///<summary>
        ///addTanaban
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addTanaban()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtTanabanCd.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTanabanCd.Focus();
                return;
            }
            if (txtTanabanName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTanabanName.Focus();
                return;
            }
            //営業所
            lstString.Add(txtTanabanCd.Text);
            lstString.Add(txtTanabanName.Text);

            //ユーザー名
            lstString.Add(SystemInformation.UserName);

            M1120_Tanaban_B tanabanB = new M1120_Tanaban_B();
            try
            {
                tanabanB.addTanaban(lstString);

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

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除、ボタンの機能を消す
        ///</summary>
        private void delText()
        {
            delFormClear(this);
            txtTanabanCd.Focus();
        }

        ///<summary>
        ///delTanaban
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delTanaban()
        {
            //データ渡し用
            List<string> lstStringLoad = new List<string>();
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            //文字判定
            if (txtTanabanCd.blIsEmpty() == false)
            {
                return;
            }

            //処理部に移動(削除)
            M1120_Tanaban_B tanabanB = new M1120_Tanaban_B();

            try
            {
                lstStringLoad.Add(txtTanabanCd.Text);

                //戻り値のDatatableを取り込む
                dtSetCd = tanabanB.updTxtTanabanCdLeave(lstStringLoad);

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
                lstString.Add(txtTanabanCd.Text);
                lstString.Add(SystemInformation.UserName);

                tanabanB.delTanaban(lstString);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtTanabanCd.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///setTanaban
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setTanabanCd(DataTable dtSelectData)
        {
            txtTanabanCd.Text = dtSelectData.Rows[0]["棚番"].ToString();
            txtTanabanName.Text = dtSelectData.Rows[0]["棚番名"].ToString();

        }

        ///<summary>
        ///txtTanabanCd_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void txtTanabanCd_Leave(object sender, EventArgs e)
        {
            Control cActive = this.ActiveControl;

            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            //文字判定
            if (txtTanabanCd.blIsEmpty() == false)
            {
                return;
            }

            //前後の空白を取り除く
            txtTanabanCd.Text = txtTanabanCd.Text.Trim();

            //データ渡し用
            lstString.Add(txtTanabanCd.Text);

            //処理部に移動
            M1120_Tanaban_B tanabanB = new M1120_Tanaban_B();

            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = tanabanB.updTxtTanabanCdLeave(lstString);

                if (dtSetCd.Rows.Count != 0)
                {
                    setTanabanCd(dtSetCd);
                }
                //データの新規登録時に邪魔になるため、現段階削除予定
                //else
                //{
                //    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                //    basemessagebox.ShowDialog();
                //}

                cActive.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///setTanabanListClose
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setTanabanListClose()
        {
            txtTanabanCd.Focus();
        }

        /// <summary>
        /// judtxtTanabanKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtTanabanKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
