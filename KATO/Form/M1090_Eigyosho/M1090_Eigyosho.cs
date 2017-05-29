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
using KATO.Business.M1090_Eigyosho;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1090_Eigyosho
{
    ///<summary>
    ///M1090_Eigyosho
    ///営業所フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class M1090_Eigyosho : BaseForm
    {
        /// <summary>
        /// M1090_Eigyosho
        /// フォーム関係の設定
        /// </summary>
        public M1090_Eigyosho(Control c)
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
        private void M1090_Eigyosho_Load(object sender, EventArgs e)
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
        ///M1090_Eigyosho_KeyDown
        ///キー入力判定
        ///</summary>
        private void M1090_Eigyosho_KeyDown(object sender, KeyEventArgs e)
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
                    this.addEigyosho();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delMaker();
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

        ///<summary>
        ///judEigyoTxtKeyDown
        ///キー入力判定
        ///</summary>
        private void judEigyoTxtKeyDown(object sender, KeyEventArgs e)
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

        ///<summary>
        ///judTxtEigyTxtKeyDown
        ///キー入力判定
        ///</summary>
        private void txtEigyoshoCd_KeyDown(object sender, KeyEventArgs e)
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
                    txtEigyoKeyDown(sender, e);
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

        ///<summary>
        ///judBtnClick
        ///ボタンの反応
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    this.addEigyosho();
                    break;
                case STR_BTN_F03: // 削除
                    this.delMaker();
                    break;
                case STR_BTN_F04: // 取り消し
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

        ///<summary>
        ///txtEigyoKeyDown
        ///キー入力判定
        ///</summary>
        private void txtEigyoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                EigyoshoList eigyoshoList = new EigyoshoList(this);
                try
                {
                    eigyoshoList.intFrmKind = CommonTeisu.FRM_EIGYOSHO;
                    eigyoshoList.Show();
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    return;
                }
            }
        }

        ///<summary>
        ///addEigyosho
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addEigyosho()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtEigyoshoCd.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtEigyoshoCd.Focus();
                return;
            }
            if (txtEigyoshoName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtEigyoshoName.Focus();
                return;
            }
            //営業所
            lstString.Add(txtEigyoshoCd.Text);
            lstString.Add(txtEigyoshoName.Text);

            //ユーザー名
            lstString.Add(SystemInformation.UserName);

            M1090_Eigyosho_B eigyoshoB = new M1090_Eigyosho_B();
            try
            {
                eigyoshoB.addEigyosho(lstString);

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
            txtEigyoshoCd.Focus();
        }

        ///<summary>
        ///delMaker
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delMaker()
        {
            //データ渡し用
            List<string> lstStringLoad = new List<string>();
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            //文字判定
            if (txtEigyoshoCd.blIsEmpty() == false)
            {
                return;
            }

            //処理部に移動(削除)
            M1090_Eigyosho_B eigyoshoB = new M1090_Eigyosho_B();

            try
            {
                lstStringLoad.Add(txtEigyoshoCd.Text);

                //戻り値のDatatableを取り込む
                dtSetCd = eigyoshoB.updTxtEigyoCdLeave(lstStringLoad);

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
                lstString.Add(txtEigyoshoCd.Text);
                lstString.Add(SystemInformation.UserName);

                eigyoshoB.delEighosho(lstString);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtEigyoshoCd.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///setEigyoshoCode
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setEigyoshoCode(DataTable dtSelectData)
        {
            txtEigyoshoCd.Text = dtSelectData.Rows[0]["営業所コード"].ToString();
            txtEigyoshoName.Text = dtSelectData.Rows[0]["営業所名"].ToString();

        }

        ///<summary>
        ///updTxtEigyoTxtLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public void updTxtEigyoTxtLeave(object sender, EventArgs e)
        {
            Control cActive = this.ActiveControl;

            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            //文字判定
            if (txtEigyoshoCd.blIsEmpty() == false)
            {
                return;
            }

            //前後の空白を取り除く
            txtEigyoshoCd.Text = txtEigyoshoCd.Text.Trim();

            if (txtEigyoshoCd.TextLength < 4)
            {
                txtEigyoshoCd.Text = txtEigyoshoCd.Text.ToString().PadLeft(4, '0');
            }

            //データ渡し用
            lstString.Add(txtEigyoshoCd.Text);

            //処理部に移動
            M1090_Eigyosho_B eigyoshoB = new M1090_Eigyosho_B();

            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = eigyoshoB.updTxtEigyoCdLeave(lstString);

                if (dtSetCd.Rows.Count != 0)
                {
                    setEigyoshoCode(dtSetCd);
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
        ///setEigyoListClose
        ///MakerListCloseが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setEigyoListClose()
        {
            txtEigyoshoCd.Focus();
        }

        /// <summary>
        /// judtxtEigyoKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtEigyoKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
