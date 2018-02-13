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
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Business.M1030_Shohin;
using static KATO.Common.Util.CommonTeisu;
using KATO.Common.Business;

namespace KATO.Form.M1030_Shohin
{
    ///<summary>
    ///M1030_Shohin
    ///商品フォーム
    ///作成者：大河内
    ///作成日：2017/05/01
    ///更新者：大河内
    ///更新日：2017/01/24
    ///カラム論理名
    ///</summary>
    public partial class M1030_Shohin : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //管理者かどうかの判定
        Boolean blnKanri;

        Control cActiveBefore = null;
        ShouhinList shouhinlist = null;

        ///<summary>
        ///M1030_Shohin
        ///フォームの初期設定（通常のテキストボックスから）
        ///</summary>
        public M1030_Shohin(Control c)
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

            //中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            //メーカーsetデータを読めるようにする
            labelSet_Daibunrui.Lsmakerdata = labelSet_Maker;

            //初期表示
            txtZaiko.Text = "0";
        }

        ///<summary>
        ///M1030_Shohin_Load
        ///画面レイアウト設定
        ///</summary>
        private void M1030_Shohin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品マスター";

            //masterUserの場合
            if (("1").Equals(masterFlg))
            {
                blnKanri = true;
            }

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF03.Text = STR_FUNC_F3;

            if (blnKanri == false)
            {
                this.btnF01.Text = "F1:仮登録";
                this.btnF03.Enabled = false;
            }
            else
            {
                this.btnF01.Text = STR_FUNC_F1;
            }

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF10.Text = STR_FUNC_F10_SHOHIN;
            this.btnF12.Text = STR_FUNC_F12;
        }

        ///<summary>
        ///judShohinKeyDown
        ///キー入力判定
        ///</summary>
        private void judShohinKeyDown(object sender, KeyEventArgs e)
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
                    this.addShohin();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delShohin();
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
                    logger.Info(LogUtil.getMessage(this._Title, "本棚無実行"));
                    this.showShohinListTana();
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));

                    //商品リストが一回以上開いたことがある場合
                    if (shouhinlist != null)
                    {
                        shouhinlist.Close();
                    }
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judShohinTxtKeyDown
        ///キー入力判定
        ///</summary>
        private void judShohinTxtKeyDown(object sender, KeyEventArgs e)
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
        ///judKenKataTxtKeyDown
        ///キー入力判定
        ///</summary>
        private void judKenKataTxtKeyDown(object sender, KeyEventArgs e)
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
                    if(txtKensaku.blIsEmpty() == false)
                    {
                        //TABボタンと同じ効果
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                        this.showShohinList();
                    }
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
                    this.showShohinList();
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
                    this.addShohin();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delShohin();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F10: // 棚番無
                    logger.Info(LogUtil.getMessage(this._Title, "本棚無実行"));
                    this.showShohinListTana();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///showtShohinList
        ///商品リストに移動
        ///</summary>
        private void showShohinList()
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //目的のフォームを探す
                if (frm.Name == "ShohinList")
                {
                    //検索項目に一つでも記入がある場合
                    if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Chubunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Maker.codeTxt.blIsEmpty() == false &&
                        txtKensaku.blIsEmpty() == false)
                    {
                        shouhinlist.blKensaku = false;
                    }
                    else
                    {
                        shouhinlist.blKensaku = true;
                    }

                    shouhinlist.intFrmKind = CommonTeisu.FRM_SHOHIN;
                    shouhinlist.strYMD = "";
                    shouhinlist.strEigyoushoCode = "";
                    shouhinlist.lsDaibunrui = labelSet_Daibunrui;
                    shouhinlist.lsChubunrui = labelSet_Chubunrui;
                    shouhinlist.lsMaker = labelSet_Maker;
                    shouhinlist.btxtKensaku = txtKensaku;
                    shouhinlist.btxtHinC1 = txtData1;
                    shouhinlist.btxtHinC2 = txtData2;
                    shouhinlist.btxtHinC3 = txtData3;
                    shouhinlist.btxtHinC4 = txtData4;
                    shouhinlist.btxtHinC5 = txtData5;
                    shouhinlist.btxtHinC6 = txtData6;
                    shouhinlist.bmtxtHyojunBaika = txtHyojun;
                    shouhinlist.bmtxtShireTanka = txtShire;
                    shouhinlist.bmtxtHyokaTanka = txtHyoka;
                    shouhinlist.bmtxtTateneShire = txtTatene;
                    shouhinlist.btxtZaikokbn = txtZaiko;
                    shouhinlist.lsTanabanH = labelSet_TanabanHonsha;
                    shouhinlist.lsTanabanG = labelSet_TanabanGihu;
                    shouhinlist.btxtMemo = txtMemo;
                    shouhinlist.bmtxtTeika = txtTeika;
                    shouhinlist.bmtxtHakosu = txtHako;
                    shouhinlist.btxtComment = txtComment;
                    shouhinlist.lblGrayYM = lblGrayToroku;
                    shouhinlist.btxtShohinCd = txtShohinCd;
                    shouhinlist.lblGrayHinMakerDaiCdChuCdHinban = lblGrayShohin;
                    shouhinlist.blNoTana = false;
                    shouhinlist.blShohinMaster = true;

                    frm.Show();
                    break;
                }
            }

            //商品リストが一回以上開いたことがない場合
            if (shouhinlist == null)
            {
                shouhinlist = new ShouhinList(this);
                try
                {
                    //検索項目に一つでも記入がある場合
                    if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Chubunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Maker.codeTxt.blIsEmpty() == false &&
                        txtKensaku.blIsEmpty() == false)
                    {
                        shouhinlist.blKensaku = false;
                    }
                    else
                    {
                        shouhinlist.blKensaku = true;
                    }

                    shouhinlist.intFrmKind = CommonTeisu.FRM_SHOHIN;
                    shouhinlist.strYMD = "";
                    shouhinlist.strEigyoushoCode = "";
                    shouhinlist.lsDaibunrui = labelSet_Daibunrui;
                    shouhinlist.lsChubunrui = labelSet_Chubunrui;
                    shouhinlist.lsMaker = labelSet_Maker;
                    shouhinlist.btxtKensaku = txtKensaku;
                    shouhinlist.btxtHinC1 = txtData1;
                    shouhinlist.btxtHinC2 = txtData2;
                    shouhinlist.btxtHinC3 = txtData3;
                    shouhinlist.btxtHinC4 = txtData4;
                    shouhinlist.btxtHinC5 = txtData5;
                    shouhinlist.btxtHinC6 = txtData6;
                    shouhinlist.bmtxtHyojunBaika = txtHyojun;
                    shouhinlist.bmtxtShireTanka = txtShire;
                    shouhinlist.bmtxtHyokaTanka = txtHyoka;
                    shouhinlist.bmtxtTateneShire = txtTatene;
                    shouhinlist.btxtZaikokbn = txtZaiko;
                    shouhinlist.lsTanabanH = labelSet_TanabanHonsha;
                    shouhinlist.lsTanabanG = labelSet_TanabanGihu;
                    shouhinlist.btxtMemo = txtMemo;
                    shouhinlist.bmtxtTeika = txtTeika;
                    shouhinlist.bmtxtHakosu = txtHako;
                    shouhinlist.btxtComment = txtComment;
                    shouhinlist.lblGrayYM = lblGrayToroku;
                    shouhinlist.btxtShohinCd = txtShohinCd;
                    shouhinlist.lblGrayHinMakerDaiCdChuCdHinban = lblGrayShohin;
                    shouhinlist.blNoTana = false;
                    shouhinlist.blShohinMaster = true;


                    shouhinlist.ShowDialog();

                    //初回時用、二回目以降は無くても動作する
                    if (txtShohinCd.Text != "")
                    {
                        txtData1.Focus();
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
            else
            {
                // 既に１回以上商品リストを表示しているので、hideを元に戻す
                shouhinlist.Show();
            }
        }

        ///<summary>
        ///showShohinListTana
        ///商品リストに移動(棚番）
        ///</summary>
        private void showShohinListTana()
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //目的のフォームを探す
                if (frm.Name == "ShohinList")
                {
                    //検索項目に一つでも記入がある場合
                    if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Chubunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Maker.codeTxt.blIsEmpty() == false &&
                        txtKensaku.blIsEmpty() == false)
                    {
                        shouhinlist.blKensaku = false;
                    }
                    else
                    {
                        shouhinlist.blKensaku = true;
                    }

                    shouhinlist.intFrmKind = CommonTeisu.FRM_SHOHIN;
                    shouhinlist.strYMD = "";
                    shouhinlist.strEigyoushoCode = "";
                    shouhinlist.lsDaibunrui = labelSet_Daibunrui;
                    shouhinlist.lsChubunrui = labelSet_Chubunrui;
                    shouhinlist.lsMaker = labelSet_Maker;
                    shouhinlist.btxtKensaku = txtKensaku;
                    shouhinlist.btxtHinC1 = txtData1;
                    shouhinlist.btxtHinC2 = txtData2;
                    shouhinlist.btxtHinC3 = txtData3;
                    shouhinlist.btxtHinC4 = txtData4;
                    shouhinlist.btxtHinC5 = txtData5;
                    shouhinlist.btxtHinC6 = txtData6;
                    shouhinlist.bmtxtHyojunBaika = txtHyojun;
                    shouhinlist.bmtxtShireTanka = txtShire;
                    shouhinlist.bmtxtHyokaTanka = txtHyoka;
                    shouhinlist.bmtxtTateneShire = txtTatene;
                    shouhinlist.btxtZaikokbn = txtZaiko;
                    shouhinlist.lsTanabanH = labelSet_TanabanHonsha;
                    shouhinlist.lsTanabanG = labelSet_TanabanGihu;
                    shouhinlist.btxtMemo = txtMemo;
                    shouhinlist.bmtxtTeika = txtTeika;
                    shouhinlist.bmtxtHakosu = txtHako;
                    shouhinlist.btxtComment = txtComment;
                    shouhinlist.lblGrayYM = lblGrayToroku;
                    shouhinlist.btxtShohinCd = txtShohinCd;
                    shouhinlist.lblGrayHinMakerDaiCdChuCdHinban = lblGrayShohin;
                    shouhinlist.blNoTana = true;
                    shouhinlist.blShohinMaster = true;

                    frm.Show();
                    break;
                }
            }

            //商品リストが一回以上開いたことがない場合
            if (shouhinlist == null)
            {
                shouhinlist = new ShouhinList(this);
                try
                {
                    //検索項目に一つでも記入がある場合
                    if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Chubunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Maker.codeTxt.blIsEmpty() == false &&
                        txtKensaku.blIsEmpty() == false)
                    {
                        shouhinlist.blKensaku = false;
                    }
                    else
                    {
                        shouhinlist.blKensaku = true;
                    }

                    shouhinlist.intFrmKind = CommonTeisu.FRM_SHOHIN;
                    shouhinlist.strYMD = "";
                    shouhinlist.strEigyoushoCode = "";
                    shouhinlist.lsDaibunrui = labelSet_Daibunrui;
                    shouhinlist.lsChubunrui = labelSet_Chubunrui;
                    shouhinlist.lsMaker = labelSet_Maker;
                    shouhinlist.btxtKensaku = txtKensaku;
                    shouhinlist.btxtHinC1 = txtData1;
                    shouhinlist.btxtHinC2 = txtData2;
                    shouhinlist.btxtHinC3 = txtData3;
                    shouhinlist.btxtHinC4 = txtData4;
                    shouhinlist.btxtHinC5 = txtData5;
                    shouhinlist.btxtHinC6 = txtData6;
                    shouhinlist.bmtxtHyojunBaika = txtHyojun;
                    shouhinlist.bmtxtShireTanka = txtShire;
                    shouhinlist.bmtxtHyokaTanka = txtHyoka;
                    shouhinlist.bmtxtTateneShire = txtTatene;
                    shouhinlist.btxtZaikokbn = txtZaiko;
                    shouhinlist.lsTanabanH = labelSet_TanabanHonsha;
                    shouhinlist.lsTanabanG = labelSet_TanabanGihu;
                    shouhinlist.btxtMemo = txtMemo;
                    shouhinlist.bmtxtTeika = txtTeika;
                    shouhinlist.bmtxtHakosu = txtHako;
                    shouhinlist.btxtComment = txtComment;
                    shouhinlist.lblGrayYM = lblGrayToroku;
                    shouhinlist.btxtShohinCd = txtShohinCd;
                    shouhinlist.lblGrayHinMakerDaiCdChuCdHinban = lblGrayShohin;
                    shouhinlist.blNoTana = true;
                    shouhinlist.blShohinMaster = true;


                    shouhinlist.ShowDialog();

                    //初回時用、二回目以降は無くても動作する
                    if (txtShohinCd.Text != "")
                    {
                        txtData1.Focus();
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
            else
            {
                // 既に１回以上商品リストを表示しているので、hideを元に戻す
                shouhinlist.Show();
            }
        }

        ///<summary>
        ///addShohin
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addShohin()
        {
            //フォーカス位置の確保
            cActiveBefore = this.ActiveControl;

            //商品コードからデータ取り出し（確認メッセージ用）
            DataTable dtShohin = new DataTable();

            //商品コードの最大値用
            string strShohinCdMax = "";

            //空文字削除
            labelSet_Daibunrui.CodeTxtText.Trim();
            labelSet_Chubunrui.CodeTxtText.Trim();
            labelSet_Maker.CodeTxtText.Trim();
            txtData1.Text.Trim();
            txtHyojun.Text.Trim();
            txtShire.Text.Trim();
            txtHyoka.Text.Trim();
            txtTatene.Text.Trim();
            txtZaiko.Text.Trim();
            labelSet_TanabanHonsha.Text.Trim();
            labelSet_TanabanGihu.Text.Trim();
            txtTeika.Text.Trim();
            txtHako.Text.Trim();
            txtMemo.Text.Trim();
            txtComment.Text.Trim();

            //データ渡し用
            List<string> lstString = new List<string>();

            //空文字判定
            if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Daibunrui.Focus();
                return;
            }
            //入力文字チェック
            if (labelSet_Daibunrui.chkTxtDaibunrui())
            {
                return;
            }

            //空文字判定
            if (labelSet_Chubunrui.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Chubunrui.Focus();
                return;
            }
            //入力文字チェック
            if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
            {
                return;
            }

            //空文字判定
            if (labelSet_Maker.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Maker.Focus();
                return;
            }
            //入力文字チェック
            if (labelSet_Maker.chkTxtMaker())
            {
                return;
            }

            //空文字判定
            if (txtHyojun.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHyojun.Focus();
                return;
            }

            //空文字判定
            if (txtShire.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtShire.Focus();
                return;
            }

            //空文字判定
            if (txtHyoka.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHyoka.Focus();
                return;
            }

            //空文字判定
            if (txtTatene.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTatene.Focus();
                return;
            }

            //空文字判定
            if (txtZaiko.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtZaiko.Focus();
                return;
            }

            //空文字判定
            if (labelSet_TanabanHonsha.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_TanabanHonsha.Focus();
                return;
            }

            //空文字判定
            if (labelSet_TanabanGihu.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_TanabanGihu.Focus();
                return;
            }

            //空文字判定
            if (txtTeika.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTeika.Focus();
                return;
            }

            //空文字判定
            if (txtHako.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHako.Focus();
                return;
            }

            M1030_Shohin_B shohinB = new M1030_Shohin_B();

            lstString.Add(txtShohinCd.Text);
            lstString.Add(labelSet_Maker.CodeTxtText);
            lstString.Add(labelSet_Daibunrui.CodeTxtText);
            lstString.Add(labelSet_Chubunrui.CodeTxtText);
            lstString.Add(txtData1.Text);
            lstString.Add(txtData2.Text);
            lstString.Add(txtData3.Text);
            lstString.Add(txtData4.Text);
            lstString.Add(txtData5.Text);
            lstString.Add(txtData6.Text);
            lstString.Add(txtHyojun.Text);
            lstString.Add(txtShire.Text);
            lstString.Add(txtZaiko.Text);
            lstString.Add(labelSet_TanabanHonsha.CodeTxtText);
            lstString.Add(labelSet_TanabanGihu.CodeTxtText);
            lstString.Add(txtMemo.Text);
            lstString.Add(txtHyoka.Text);
            lstString.Add(txtTeika.Text);
            lstString.Add(txtHako.Text);
            lstString.Add(txtTatene.Text);
            lstString.Add(txtComment.Text);

            //ユーザー名
            lstString.Add(SystemInformation.UserName);

            try
            {
                //新規登録
                if (radSet_2btn_Toroku.radbtn0.Checked == true)
                {
                    //商品コードの最大値を確保
                    strShohinCdMax = shohinB.getNewShohinNo();

                    //商品コードのみを上書き
                    lstString[0] = strShohinCdMax;

                    shohinB.addShohin(lstString, blnKanri);


                }
                //修正登録
                else
                {
                    //商品コードからデータの読み込み
                    dtShohin = shohinB.getShohin(txtShohinCd.Text);

                    //商品データがある場合
                    if (dtShohin.Rows.Count > 0)
                    {
                        //一行目にデータがない場合
                        if (dtShohin.Rows[0][0].ToString() == "")
                        {
                            return;
                        }
                    }



                    //メッセージボックスの処理、登録完了のウィンドウ（OK）
                    BaseMessageBox basemessageboxUwagaki = new BaseMessageBox(this, 
                                                                              CommonTeisu.TEXT_TOUROKU,
                                                                              dtShohin.Rows[0]["品名"].ToString().Trim() + 
                                                                              "\r\n" + 
                                                                              CommonTeisu.LABEL_TOUROKU_UWAGAKi, 
                                                                              CommonTeisu.BTN_YESNO, 
                                                                              CommonTeisu.DIAG_EXCLAMATION);
                    //NOが押された場合
                    if (basemessageboxUwagaki.ShowDialog() == DialogResult.No)
                    {
                        return;
                    }

                    shohinB.addShohin(lstString, blnKanri);
                }

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                labelSet_Daibunrui.Focus();
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
            string strToroku = lblGrayToroku.Text;

            delFormClear(this);
            txtHyojun.Text = "";
            txtShire.Text = "";
            txtHyoka.Text = "";
            txtTatene.Text = "";
            txtTeika.Text = "";
            txtHako.Text = "";
            labelSet_Daibunrui.Focus();
            radSet_2btn_Toroku.radbtn0.Checked = true;

            lblGrayToroku.Text = strToroku;

            txtZaiko.Text = "0";
        }

        ///<summary>
        ///delShohin
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delShohin()
        {
            if (blnKanri == false)
            {
                return;
            }

            //データ渡し用
            List<string> lstString = new List<string>();

            //データの取得用
            DataTable dtShohin = new DataTable();
            
            //文字判定
            if (txtShohinCd.blIsEmpty() == false)
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

            ShouhinList_B shohinlistB = new ShouhinList_B();

            dtShohin = shohinlistB.getSelectItem(txtShohinCd.Text);

            //データがない場合
            if (dtShohin.Rows.Count == 0)
            {
                //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

            M1030_Shohin_B shohinB = new M1030_Shohin_B();

            lstString.Add(dtShohin.Rows[0]["商品コード"].ToString());
            lstString.Add(dtShohin.Rows[0]["メーカーコード"].ToString());
            lstString.Add(dtShohin.Rows[0]["大分類コード"].ToString());
            lstString.Add(dtShohin.Rows[0]["中分類コード"].ToString());
            lstString.Add(dtShohin.Rows[0]["Ｃ１"].ToString());
            lstString.Add(dtShohin.Rows[0]["Ｃ２"].ToString());
            lstString.Add(dtShohin.Rows[0]["Ｃ３"].ToString());
            lstString.Add(dtShohin.Rows[0]["Ｃ４"].ToString());
            lstString.Add(dtShohin.Rows[0]["Ｃ５"].ToString());
            lstString.Add(dtShohin.Rows[0]["Ｃ６"].ToString());
            lstString.Add(dtShohin.Rows[0]["標準売価"].ToString());
            lstString.Add(dtShohin.Rows[0]["仕入単価"].ToString());
            lstString.Add(dtShohin.Rows[0]["在庫管理区分"].ToString());
            lstString.Add(dtShohin.Rows[0]["棚番本社"].ToString());
            lstString.Add(dtShohin.Rows[0]["棚番岐阜"].ToString());
            lstString.Add(dtShohin.Rows[0]["メモ"].ToString());
            lstString.Add(dtShohin.Rows[0]["評価単価"].ToString());
            lstString.Add(dtShohin.Rows[0]["定価"].ToString());
            lstString.Add(dtShohin.Rows[0]["箱入数"].ToString());
            lstString.Add(dtShohin.Rows[0]["建値仕入単価"].ToString());
            lstString.Add(dtShohin.Rows[0]["コメント"].ToString());

            //ユーザー名
            lstString.Add(SystemInformation.UserName);

            try
            {
                shohinB.delShohin(lstString, blnKanri);

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                labelSet_Daibunrui.Focus();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///judtxtShohinKeyUp
        ///入力項目上でのキー判定と文字数判定（）
        ///</summary>
        private void judtxtShohinKeyUp(object sender, KeyEventArgs e)
        {
            cActiveBefore = this.ActiveControl;

            //入力項目上でのキー判定と文字数判定
            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///txtMemo_KeyDown
        ///エンターでの改行で5行以上いった場合動作を止める
        ///</summary>
        private void txtComment_KeyDown(object sender, KeyEventArgs e)
        {
            //エンターキーを押した場合
            if (e.KeyCode == Keys.Enter)
            {
                //5行以上の改行の場合
                if (txtComment.Lines.Length > 4)
                {
                    //改行させない
                    e.SuppressKeyPress = true;
                }
            }
        }

        ///<summary>
        ///setMaker
        ///メーカーのLeave処理
        ///</summary>
        public void setMaker()
        {
            labelSet_Maker.chkTxtMaker();
        }

        ///<summary>
        ///txtZaiko_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void txtZaiko_Leave(object sender, EventArgs e)
        {
            //前後の空白を取り除く
            ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

            if (((TextBox)sender).Text == "")
            {
                return;
            }

                if (((TextBox)sender).Text != "1" && ((TextBox)sender).Text != "0")
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, "", CommonTeisu.LABEL_ZEROORONE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    cActiveBefore.Focus();
                }
        }

        ///<summary>
        ///setChubun
        ///中分類リストから帰ってきたとき
        ///</summary>
        public void setChubun()
        {
            labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText);
        }

        ///<summary>
        ///txtData_Leave
        ///型式関係から離れた時
        ///</summary>
        private void txtData_Leave(object sender, EventArgs e)
        {
            setShohinName();
        }

        ///<summary>
        ///setShohinName
        ///商品名の修正
        ///</summary>
        private void setShohinName()
        {
            //大分類、中分類、メーカーにデータがない場合
            if (labelSet_Daibunrui.ValueLabelText != "" && 
                labelSet_Chubunrui.ValueLabelText != "" &&
                labelSet_Maker.ValueLabelText != "")
            {
                //商品名に書き込み
                lblGrayShohin.Text = labelSet_Maker.ValueLabelText.Trim() +
                                   " " +
                                   labelSet_Daibunrui.codeTxt.Text +
                                   " " +
                                   labelSet_Chubunrui.codeTxt.Text +
                                   " " +
                                   txtData1.Text +
                                   " " +
                                   txtData2.Text +
                                   " " +
                                   txtData3.Text +
                                   " " +
                                   txtData4.Text +
                                   " " +
                                   txtData5.Text +
                                   " " +
                                   txtData6.Text;
            }

        }

        ///<summary>
        ///txtComment_TextChanged
        ///コメントに変化があった場合
        ///</summary>
        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            //改行コード含めて500文字に達した場合
            if (txtComment.Text.Length == 500)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }

        ///<summary>
        ///txtShohinCd_TextChanged
        ///商品コードに変化があった場合
        ///</summary>
        private void txtShohinCd_TextChanged(object sender, EventArgs e)
        {
            //商品コードにデータがある場合
            if (txtShohinCd.Text != "")
            {
                txtData1.Focus();
                //編集登録にチェック
                radSet_2btn_Toroku.radbtn1.Checked = true;
            }
        }

        ///<summary>
        ///chkMoneyText
        ///値段、数量の文字数チェック
        ///</summary>
        private void chkMoneyText(string strText, string strTextName)
        {
            //箱入数の場合
            if (strTextName == "txtHako")
            {
                //文字数が7を超える場合
                if (strText.Length > 7)
                {
                    //メッセージボックスの処理、項目の数値が正しくない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISSNUM, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    SendKeys.Send("+{TAB}");
                    return;
                }
            }
            else
            {
                //文字数が13を超える場合
                if (strText.Length > 13)
                {
                    //メッセージボックスの処理、項目の数値が正しくない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISSNUM, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    SendKeys.Send("+{TAB}");
                    return;
                }
            }
        }

        ///<summary>
        ///txtHyojun_Leave
        ///標準売価から離れた時
        ///</summary>
        private void txtHyojun_Leave(object sender, EventArgs e)
        {
            //データの文字数チェック
            chkMoneyText(txtHyojun.Text, txtHyojun.Name);
        }

        ///<summary>
        ///txtShire_Leave
        ///仕入単価から離れた時
        ///</summary>
        private void txtShire_Leave(object sender, EventArgs e)
        {
            //データの文字数チェック
            chkMoneyText(txtShire.Text, txtShire.Name);

        }

        ///<summary>
        ///txtHyoka_Leave
        ///評価単価から離れた時
        ///</summary>
        private void txtHyoka_Leave(object sender, EventArgs e)
        {
            //データの文字数チェック
            chkMoneyText(txtHyoka.Text, txtHyoka.Name);
        }

        ///<summary>
        ///txtTatene_Leave
        ///建値仕入単価から離れた時
        ///</summary>
        private void txtTatene_Leave(object sender, EventArgs e)
        {
            //データの文字数チェック
            chkMoneyText(txtTatene.Text, txtTatene.Name);
        }

        ///<summary>
        ///txtTeika_Leave
        ///定価から離れた時
        ///</summary>
        private void txtTeika_Leave(object sender, EventArgs e)
        {
            //データの文字数チェック
            chkMoneyText(txtTeika.Text, txtTeika.Name);
        }

        ///<summary>
        ///txtHako_Leave
        ///箱入数から離れた時
        ///</summary>
        private void txtHako_Leave(object sender, EventArgs e)
        {
            //データの文字数チェック
            chkMoneyText(txtHako.Text, txtHako.Name);
        }
    }
}
