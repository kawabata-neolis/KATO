﻿using System;
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
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///M1090_Eigyosho
        ///フォームの初期設定
        ///</summary>
        public M1090_Eigyosho(Control c)
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
        ///M1090_Eigyosho_Load
        ///画面レイアウト設定
        ///</summary>
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

            // ファンクションボタン制御
            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;
            this.btnF09.Enabled = false;

        }

        ///<summary>
        ///M1090_Eigyosho_KeyDown
        ///キー入力判定（画面全般）
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
                    // ファンクションボタン制御
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addEigyosho();
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    // ファンクションボタン制御
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delEigyosho();
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
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    printEigyosho();
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
        ///judEigyoTxtKeyDown
        ///キー入力判定（無機能テキストボックス）
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
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judTxtEigyTxtKeyDown
        ///キー入力判定（検索ありテキストボックス）
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
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    txtEigyoKeyDown(sender, e);
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
                        this.addEigyosho();
                    }
                    break;
                case STR_BTN_F03: // 削除
                    // ファンクションボタン制御
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delEigyosho();
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
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printEigyosho();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///txtEigyoKeyDown
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void txtEigyoKeyDown(object sender, KeyEventArgs e)
        {
            //営業所リストのインスタンス生成
            EigyoshoList eigyoshoList = new EigyoshoList(this);
            try
            {
                //担当者区分リストの表示、画面IDを渡す
                eigyoshoList.StartPosition = FormStartPosition.Manual;
                eigyoshoList.intFrmKind = CommonTeisu.FRM_EIGYOSHO;
                eigyoshoList.Show();
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
        ///addEigyosho
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addEigyosho()
        {
            //データ渡し用
            List<string> lstEigyosho = new List<string>();

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

            //営業所コードチェック
            if (chkEigyoshoCd() == true)
            {
                return;
            }

            //登録情報を入れる（営業所コード、営業所名、ユーザー名）
            lstEigyosho.Add(txtEigyoshoCd.Text);
            lstEigyosho.Add(txtEigyoshoName.Text);
            lstEigyosho.Add(SystemInformation.UserName);

            //ビジネス層のインスタンス生成
            M1090_Eigyosho_B eigyoshoB = new M1090_Eigyosho_B();
            try
            {
                //登録
                eigyoshoB.addEigyosho(lstEigyosho);

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

            // ファンクション機能リセット
            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            this.btnF04.Enabled = false;

            txtEigyoshoCd.Focus();
        }

        ///<summary>
        ///delMaker
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delEigyosho()
        {
            //記入情報削除用
            List<string> lstEigyosho = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //文字判定（営業所コード）
            if (txtEigyoshoCd.blIsEmpty() == false)
            {
                return;
            }

            //営業所コードチェック
            if (chkEigyoshoCd() == true)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            M1090_Eigyosho_B eigyoshoB = new M1090_Eigyosho_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = eigyoshoB.getTxtEigyoCdLeave(txtEigyoshoCd.Text);

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

                //削除情報を入れる（営業所コード、営業所名、ユーザー名）
                lstEigyosho.Add(dtSetCd.Rows[0]["営業所コード"].ToString());
                lstEigyosho.Add(dtSetCd.Rows[0]["営業所名"].ToString());
                lstEigyosho.Add(SystemInformation.UserName);

                //ビジネス層、削除ロジックに移動
                eigyoshoB.delEighosho(lstEigyosho);

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
        ///setEigyoshoCode
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setEigyoshoCode(DataTable dtSelectData)
        {
            txtEigyoshoCd.Text = dtSelectData.Rows[0]["営業所コード"].ToString();
            txtEigyoshoName.Text = dtSelectData.Rows[0]["営業所名"].ToString();

        }

        ///<summary>
        ///setTxtEigyoTxtLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public void setTxtEigyoTxtLeave(object sender, EventArgs e)
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //前後の空白を取り除く
            txtEigyoshoCd.Text = txtEigyoshoCd.Text.Trim();

            //文字判定
            if (txtEigyoshoCd.blIsEmpty() == false)
            {
                return;
            }

            //営業所コードチェック
            if (chkEigyoshoCd() == true)
            {
                return;
            }
            
            //ビジネス層のインスタンス生成
            M1090_Eigyosho_B eigyoshoB = new M1090_Eigyosho_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = eigyoshoB.getTxtEigyoCdLeave(txtEigyoshoCd.Text);

                //Datatable内のデータが存在する場合
                if (dtSetCd.Rows.Count != 0)
                {
                    setEigyoshoCode(dtSetCd);

                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = true;
                    this.btnF04.Enabled = true;

                    txtEigyoshoName.Focus();

                }
                else
                {
                    txtEigyoshoName.Text = "";

                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = false;
                    this.btnF04.Enabled = true;

                    txtEigyoshoName.Focus();
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
        ///CloseEigyoList
        ///MakerListCloseが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void CloseEigyoList()
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

        ///<summary>
        ///printEigyosho
        ///印刷ダイアログ
        ///</summary>
        private void printEigyosho()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //PDF作成後の入れ物
            string strFile = "";

            //ビジネス層のインスタンス生成
            M1090_Eigyosho_B eigyoB = new M1090_Eigyosho_B();
            try
            {
                dtSetCd_B = eigyoB.getPrintData();

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
                    strFile = eigyoB.dbToPdf(dtSetCd_B);

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    strFile = eigyoB.dbToPdf(dtSetCd_B);

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
        /// chkEigyoshoCd
        /// 営業所コードチェック
        ///</summary>
        private bool chkEigyoshoCd()
        {
            // 禁止文字チェック
            if (StringUtl.JudBanSQL(txtEigyoshoCd.Text) == false)
            {
                // メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtEigyoshoCd.Text = "";

                txtEigyoshoCd.Focus();
                return true;
            }

            this.txtEigyoshoCd.Text = StringUtl.JudZenToHanNum(txtEigyoshoCd.Text);

            // 数値チェック
            if (StringUtl.JudBanSelect(txtEigyoshoCd.Text, CommonTeisu.NUMBER_ONLY) == true)
            {
                // 文字数が足りなかった場合0パティング
                if (txtEigyoshoCd.TextLength < 4)
                {
                    txtEigyoshoCd.Text = txtEigyoshoCd.Text.ToString().PadLeft(4, '0');
                }
            }

            return false;
        }
    }
}
