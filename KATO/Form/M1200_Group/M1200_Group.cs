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
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.M1200_Group;

namespace KATO.Form.M1200_Group
{
    ///<summary>
    ///M1200_Group
    ///グループマスタフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class M1200_Group : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// M1200_Group
        /// フォームの初期設定
        /// </summary>
        public M1200_Group(Control c)
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
        /// M1200_Group_Load
        /// 読み込み時
        /// </summary>
        private void M1200_Group_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "グループマスタ";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // ファンクションボタン制御
            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;
            this.btnF09.Enabled = false;

        }

        ///<summary>
        ///M1200_Group_KeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void M1200_Group_KeyDown(object sender, KeyEventArgs e)
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
                    // ファンクションボタン制御
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addGroup();
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    // ファンクションボタン制御
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delGroup();
                    }
                    break;
                case Keys.F4:
                    // ファンクションボタン制御
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
                    break;
                case Keys.F12:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///txtName_KeyDown
        ///キー入力判定（無機能テキストボックス）
        ///</summary>
        private void txtName_KeyDown(object sender, KeyEventArgs e)
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
        ///txtTorihikikubun_KeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void txtTorihikikubun_KeyDown(object sender, KeyEventArgs e)
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
                    showGroupList();
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
                    // ファンクションボタン制御
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addGroup();
                    }
                    break;
                case STR_BTN_F03: // 削除
                    // ファンクションボタン制御
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delGroup();
                    }
                    break;
                case STR_BTN_F04: // 取消
                    // ファンクションボタン制御
                    if (this.btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.delText();
                    }
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///showGroupList
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void showGroupList()
        {
            //担当者リストのインスタンス生成
            GroupCdList groupcdlist = new GroupCdList(this);
            try
            {
                //担当者区分リストの表示、画面IDを渡す
                groupcdlist.StartPosition = FormStartPosition.Manual;
                groupcdlist.intFrmKind = CommonTeisu.FRM_GROUP;
                groupcdlist.ShowDialog();
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
        ///addGroup
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addGroup()
        {
            //記入情報登録用
            List<string> lstGroup = new List<string>();

            //空文字判定（グループID）
            if (txtGroupId.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtGroupId.Focus();
                return;
            }
            //空文字判定（グループ名）
            if (txtGroupName.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtGroupName.Focus();
                return;
            }

            // グループIDの文字チェック
            if (chkGroupId() == true)
            {
                return;
            }

            //登録情報を入れる（グループID、グループ名、ユーザー名）
            lstGroup.Add(txtGroupId.Text);
            lstGroup.Add(txtGroupName.Text);
            lstGroup.Add(SystemInformation.UserName);

            //ビジネス層のインスタンス生成
            M1200_Group_B groupB = new M1200_Group_B();
            try
            {
                //登録
                groupB.addGroup(lstGroup);

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
        ///テキストボックス内の文字を削除、ボタンの機能を消す
        ///</summary>
        private void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);

            // ファンクション機能リセット
            btnF01.Enabled = false;
            btnF03.Enabled = false;
            btnF04.Enabled = false;

            txtGroupId.Focus();
        }

        ///<summary>
        ///delShohizeiritu
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delGroup()
        {
            //記入情報削除用
            List<string> lstGroup = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //空文字判定（グループコード）
            if (txtGroupId.blIsEmpty() == false)
            {
                return;
            }

            // グループIDの文字チェック
            if (chkGroupId() == true)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1200_Group_B groupB = new M1200_Group_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = groupB.updTxtGroupLeave(txtGroupId.Text);

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

                //削除情報を入れる（グループコード、グループ名、ユーザー名）
                lstGroup.Add(dtSetCd.Rows[0]["グループコード"].ToString());
                lstGroup.Add(dtSetCd.Rows[0]["グループ名"].ToString());
                lstGroup.Add(SystemInformation.UserName);

                //ビジネス層、削除ロジックに移動
                groupB.delGroup(lstGroup);
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                txtGroupId.Focus();
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
        ///setGroup
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setGroup(DataTable dtSelectData)
        {
            txtGroupId.Text = dtSelectData.Rows[0]["グループコード"].ToString();
            txtGroupName.Text = dtSelectData.Rows[0]["グループ名"].ToString();
        }

        ///<summary>
        ///txtGroupId_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void txtGroupId_Leave(object sender, EventArgs e)
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //前後の空白を取り除く
            txtGroupId.Text = txtGroupId.Text.Trim();

            // グループIDの空チェック
            if (txtGroupId.blIsEmpty() == false)
            {
                return;
            }

            // グループIDの文字チェック
            if (chkGroupId() == true)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1200_Group_B groupB = new M1200_Group_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = groupB.updTxtGroupLeave(txtGroupId.Text);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    setGroup(dtSetCd);

                    // ファンクションボタン制御
                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = true;
                    this.btnF04.Enabled = true;

                }
                else
                {
                    txtGroupName.Text = "";

                    // ファンクションボタン制御
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
        ///setGroupListClose
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setGroupListClose()
        {
            txtGroupId.Focus();
        }

        /// <summary>
        /// judtxtShohizeiKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtShohizeiKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        /// chkGroupId
        /// グループIDチェック
        ///</summary>
        private bool chkGroupId()
        {
            if (StringUtl.JudBanSQL(txtGroupId.Text) == false)
            {
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                this.txtGroupId.Text = "";
                txtGroupId.Focus();
                return true;
            }

            //数値数が足りなかった場合0パティング
            if (StringUtl.JudBanSelect(txtGroupId.Text, CommonTeisu.NUMBER_ONLY) == true)
            {
                if (txtGroupId.TextLength < 4)
                {
                    txtGroupId.Text = txtGroupId.Text.ToString().PadLeft(4, '0');
                }
            }
            return false;
        }
    }
}
