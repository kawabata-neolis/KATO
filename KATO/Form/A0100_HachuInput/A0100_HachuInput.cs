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
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Business.A0100_HachuInput_B;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.M1050_Tantousha;

namespace KATO.Form.A0100_HachuInput
{
    ///<summary>
    ///A0100_HachuInput
    ///商品フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2018/02/17
    ///カラム論理名
    ///</summary>
    public partial class A0100_HachuInput : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        bool addLock = false;
        ///<summary>
        ///A0100_HachuInput
        ///フォームの初期設定
        ///</summary>
        public A0100_HachuInput(Control c)
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

            //中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            //メーカーsetデータを読めるようにする
            labelSet_Daibunrui.Lsmakerdata = labelSet_Maker;
        }

        ///<summary>
        ///A0100_HachuInput_Load
        ///画面レイアウト設定
        ///</summary>
        private void A0100_HachuInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "発注入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF08.Text = STR_FUNC_F8_RIREKI;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            txtHachuYMD.Text = DateTime.Today.ToString();

            DataTable dtTantoshaCd = new DataTable();

            A0100_HachuInput_B hachuinputB = new A0100_HachuInput_B();
            try
            {
                //ログインＩＤから担当者コードを取り出す
                dtTantoshaCd = hachuinputB.getTantoshaCdSetUserID(SystemInformation.UserName);

                //担当者データがある場合
                if (dtTantoshaCd.Rows.Count > 0)
                {
                    //一行目にデータがない場合
                    if (dtTantoshaCd.Rows[0][0].ToString() == "")
                    {
                        return;
                    }
                }

                labelSet_Hachusha.CodeTxtText = dtTantoshaCd.Rows[0]["担当者コード"].ToString();
                labelSet_Hachusha.chkTxtTantosha();

                labelSet_Eigyosho.CodeTxtText = dtTantoshaCd.Rows[0]["営業所コード"].ToString();
                labelSet_Eigyosho.chkTxtEigyousho();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

            setupGrid();
        }

        ///<summary>
        ///setupGrid
        ///DataGridView初期設定
        ///</summary>
        private void setupGrid()
        {
            //列自動生成禁止
            gridHachu.AutoGenerateColumns = false;

            //カラム名の指定
            DataGridViewTextBoxColumn hachuban = new DataGridViewTextBoxColumn();
            hachuban.DataPropertyName = "発注番号";
            hachuban.Name = "発注番号";
            hachuban.HeaderText = "発注番号";

            //カラム名の指定
            DataGridViewTextBoxColumn shisakiname = new DataGridViewTextBoxColumn();
            shisakiname.DataPropertyName = "仕入先名";
            shisakiname.Name = "仕入先名";
            shisakiname.HeaderText = "仕入先名";
            
            //カラム名の指定
            DataGridViewTextBoxColumn chuban = new DataGridViewTextBoxColumn();
            chuban.DataPropertyName = "注番";
            chuban.Name = "注番";
            chuban.HeaderText = "注番";

            //カラム名の指定
            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー名";
            maker.Name = "メーカー名";
            maker.HeaderText = "メーカー";

            //カラム名の指定
            DataGridViewTextBoxColumn chubun = new DataGridViewTextBoxColumn();
            chubun.DataPropertyName = "中分類名";
            chubun.Name = "中分類名";
            chubun.HeaderText = "中分類";

            //カラム名の指定
            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "型番";
            kataban.Name = "型番";
            kataban.HeaderText = "型　　番";

            //カラム名の指定
            DataGridViewTextBoxColumn hachusu = new DataGridViewTextBoxColumn();
            hachusu.DataPropertyName = "発注数量";
            hachusu.Name = "発注数量";
            hachusu.HeaderText = "発注数量";

            //カラム名の指定
            DataGridViewTextBoxColumn noki = new DataGridViewTextBoxColumn();
            noki.DataPropertyName = "納期";
            noki.Name = "納期";
            noki.HeaderText = "納期";

            //各カラムのバインド（文章の寄せ、カラム名の位置、フォーマット指定、横幅サイズ）
            setColumn(hachuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(shisakiname, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 252);
            setColumn(chuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 172);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 160);
            setColumn(chubun, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 160);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 330);
            setColumn(hachusu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 96);
            setColumn(noki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);

            gridHachu.Columns["発注番号"].Visible = false;
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            //column設定
            gridHachu.Columns.Add(col);

            //カラム名が空でない場合
            if (gridHachu.Columns[col.Name] != null)
            {
                //横幅サイズの決定
                gridHachu.Columns[col.Name].Width = intLen;
                //文章の寄せ方向の決定
                gridHachu.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                //カラム名の位置の決定
                gridHachu.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                //フォーマットが指定されていた場合
                if (fmt != null)
                {
                    //フォーマットを指定
                    gridHachu.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///A0100_HachuInput_KeyDown
        ///キー入力判定(画面全般）
        ///</summary>
        private void A0100_HachuInput_KeyDown(object sender, KeyEventArgs e)
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
                    if (!addLock) {
                        addLock = true;
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addHachu(true);
                        addLock = false;
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delHachu();
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
                    logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));
                    this.showRireki();
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    printHachuInput();
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
        ///judTxtHachuKeyDown
        ///キー入力判定(テキストボックス)
        ///</summary>
        private void judTxtHachuKeyDown(object sender, KeyEventArgs e)
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
        ///judTxtKensakuKeyDown
        ///キー入力判定(検索テキストボックス)
        ///</summary>
        private void judTxtKensakuKeyDown(object sender, KeyEventArgs e)
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
                    if (txtKensaku.blIsEmpty() == false)
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
                    //商品リスト移動メソッド
                    showShohinList();
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
        ///gridHachu_KeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///</summary>        
        private void gridHachu_KeyDown(object sender, KeyEventArgs e)
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
                    //DataGridViewの次の列に移動しないようにする
                    e.Handled = true;
                    //ダブルクリックと同じ効果
                    getSelectItem();
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
        ///txtHachuban_KeyDown
        ///発注番号でキーが押されたとき
        ///</summary>        
        private void txtHachuban_KeyDown(object sender, KeyEventArgs e)
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

                    //取引先コードにデータがない場合
                    if (textSet_Torihikisaki.valueTextText == "")
                    {
                        //例外発生メッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, "", "取引先コードを指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        textSet_Torihikisaki.Focus();
                        return;
                    }

                    //発注残確認に移動
                    Form.D0360_JuchuzanKakunin.D0360_JuchuzanKakunin juchuzankakunin = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this, textSet_Torihikisaki.CodeTxtText, txtHachuban, true);
                    try
                    {
                        juchuzankakunin.ShowDialog();
                        juchuzankakunin.Dispose();

                        //注文Noにデータがある場合
                        if (txtHachuban.blIsEmpty() == true)
                        {
                            getView();
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
        ///judFuncBtnClick
        ///ファンクションボタンの反応
        ///</summary>
        private void judFuncBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    if (!addLock)
                    {
                        addLock = true;
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addHachu(true);
                        addLock = false;
                    }
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delHachu();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F08: // 履歴
                    logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));
                    this.showRireki();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printHachuInput();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///showShohinList
        ///商品リストの実行
        ///</summary>
        private void showShohinList()
        {
            ShouhinList shouhinlist = new ShouhinList(this);
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
                
                //表示していた品名を確保
                string strHinmeiBef = txtHinmei.Text;

                //検索項目が編集できる状態かどうか判断
                Boolean blEnabledTrue = false;

                //検索項目が編集できる状態だった場合
                if (labelSet_Daibunrui.Enabled == true)
                {
                    blEnabledTrue = true;
                }

                //編集可能にする
                labelSet_Daibunrui.Enabled = true;
                labelSet_Chubunrui.Enabled = true;
                labelSet_Maker.Enabled = true;
                txtHinmei.Enabled = true;
                lblHinmei.Enabled = true;

                shouhinlist.intFrmKind = CommonTeisu.FRM_HACHUINPUT;
                shouhinlist.lsDaibunrui = labelSet_Daibunrui;
                shouhinlist.lsChubunrui = labelSet_Chubunrui;
                shouhinlist.lsMaker = labelSet_Maker;
                shouhinlist.btxtHinC1 = txtHinmei;
                shouhinlist.btxtHinC2 = txtData2;
                shouhinlist.btxtHinC3 = txtData3;
                shouhinlist.btxtHinC4 = txtData4;
                shouhinlist.btxtHinC5 = txtData5;
                shouhinlist.btxtHinC6 = txtData6;
                shouhinlist.btxtShohinCd = txtShohinCd;
                shouhinlist.lblGrayTanabanH = lblGrayTanaHon;
                shouhinlist.lblGrayTanabanG = lblGrayTanaGihu;
                shouhinlist.cbShireTanka = cmbHachutan;
                shouhinlist.btxtKensaku = txtKensaku;
                shouhinlist.bmtxtTeika = txtTeka;

                shouhinlist.ShowDialog();

                setcmbHachutanSetUp();

                //商品リストから新しく選ばれた場合
                if (strHinmeiBef != txtHinmei.Text)
                {
                    //編集不可能にする
                    labelSet_Daibunrui.Enabled = false;
                    labelSet_Chubunrui.Enabled = false;
                    labelSet_Maker.Enabled = false;
                    txtHinmei.Enabled = false;
                    lblHinmei.Enabled = false;

                    //データを確保
                    txtData1.Text = txtHinmei.Text;

                    //掛率の再計算
                    setKakeritsu();
                    txtHachusu.Focus();
                }
                else
                {
                    //商品リストに行く前に検索項目が編集できる状態ではない場合
                    if (blEnabledTrue == false)
                    {
                        //編集不可能にする
                        labelSet_Daibunrui.Enabled = false;
                        labelSet_Chubunrui.Enabled = false;
                        labelSet_Maker.Enabled = false;
                        txtHinmei.Enabled = false;
                        lblHinmei.Enabled = false;
                    }
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
        ///showRireki
        ///仕入実績確認の実行
        ///</summary>
        private void showRireki()
        {
            //入力チェック
            if (StringUtl.blIsEmpty(textSet_Torihikisaki.CodeTxtText) == false)
            {
                return;
            }

            D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin shire = new D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin(this, 10, textSet_Torihikisaki.CodeTxtText);
            shire.ShowDialog();
        }

        ///<summary>
        ///addHachu
        ///テキストボックス内のデータをDBに登録または更新
        ///</summary>
        private Boolean addHachu(Boolean blAddOnly)
        {
            //登録が出来たかどうかの判定
            Boolean blAddEnd = false;

            //データ追加用（テーブル名）
            List<string> lstTableName = new List<string>();
            //データ追加用（データ内容）
            List<string> lstData = new List<string>();

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //受注伝票があるものは弾く
            if (btnF01.Enabled == false)
            {
                return (blAddEnd);
            }

            //文字判定(発注年月日)
            if (txtHachuYMD.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHachuYMD.Focus();
                return(blAddEnd);
            }

            //担当者を確保する
            labelSet_Hachusha.chkTxtTantosha();
            txtTanto.Text = labelSet_Hachusha.CodeTxtText;

            //文字判定(担当者)
            if (labelSet_Hachusha.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Hachusha.Focus();
                return (blAddEnd);
            }
            //文字判定(仕入先コード)
            if (textSet_Torihikisaki.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                textSet_Torihikisaki.Focus();
                return (blAddEnd);
            }

            //文字判定(大分類がなく、中分類がある場合)
            if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false && labelSet_Chubunrui.codeTxt.blIsEmpty() == true)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                // 中分類コードを空にする。
                labelSet_Chubunrui.CodeTxtText = "";
                labelSet_Chubunrui.ValueLabelText = "";

                labelSet_Daibunrui.Focus();
                return (blAddEnd);
            }
            //大分類があり、中分類もある場合
            else if(labelSet_Daibunrui.codeTxt.blIsEmpty() == true && labelSet_Chubunrui.codeTxt.blIsEmpty() == true)
            {
                //文字判定(中分類)
                if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
                {
                    labelSet_Chubunrui.Focus();
                    return (blAddEnd);
                }
            }

            //文字判定(メーカー)
            if (labelSet_Maker.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Maker.Focus();
                return (blAddEnd);
            }
            //文字判定(発注数量)
            if (txtHachusu.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHachusu.Focus();
                return (blAddEnd);
            }
            //文字判定(発注単価)
            if (cmbHachutan.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                cmbHachutan.Focus();
                return (blAddEnd);
            }
            //文字判定(納期)
            if (txtNoki.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtNoki.Focus();
                return (blAddEnd);
            }

            //日付フォーマット生成、およびチェック
            strYMDformat = txtHachuYMD.chkDateDataFormat(txtHachuYMD.Text);

            //開始年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtHachuYMD.Focus();

                return (blAddEnd);
            }
            else
            {
                txtHachuYMD.Text = strYMDformat;
            }

            //担当者チェック
            if (labelSet_Hachusha.chkTxtTantosha())
            {
                labelSet_Hachusha.Focus();

                return (blAddEnd);
            }

            //仕入先名称の確保用
            string strTorihikisakiSub = "";

            //仕入先名称の確保
            strTorihikisakiSub = textSet_Torihikisaki.valueTextText;

            strTorihikisakiSub.Trim();

            //仕入先チェック
            if (textSet_Torihikisaki.chkTxtTorihikisaki())
            {
                textSet_Torihikisaki.Focus();

                return (blAddEnd);
            }

            //大分類チェック
            if (labelSet_Daibunrui.chkTxtDaibunrui())
            {
                labelSet_Daibunrui.Focus();

                return (blAddEnd);
            }

            //メーカーチェック
            if (labelSet_Maker.chkTxtMaker())
            {
                labelSet_Maker.Focus();

                return (blAddEnd);
            }

            //発注数量、数値チェック
            if (txtHachusu.chkMoneyText())
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された数値が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtHachusu.Focus();

                return (blAddEnd);
            }

            //発注単価、数値チェック
            if (chkMoneyText() == true)
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された文字列が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                cmbHachutan.Focus();

                return (blAddEnd);
            }

            //初期化
            strYMDformat = "";

            strYMDformat = txtNoki.chkDateDataFormat(txtNoki.Text);

            txtNoki.Text = strYMDformat;

            //納期、カレンダ―チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtNoki.Focus();

                return (blAddEnd);
            }

            //受注番号が入っている場合
            if (txtJuchuban.Text != "" && txtJuchuban.Text != "0")
            {
                decimal decJusu = 0;
                decimal decHonsu = 0;
                decimal decGifusu = 0;

                //検索時のデータ取り出し先(受注検出時)
                DataTable dtSetJuchurenkei;

                //ビジネス層のインスタンス生成
                A0100_HachuInput_B hachuB = new A0100_HachuInput_B();
                try
                {
                    //戻り値のDatatableを取り込む（該当DBで受注番号を検索）
                    dtSetJuchurenkei = hachuB.getJuchuRenkei(txtJuchuban.Text);

                    //１件以上データがある場合
                    if (dtSetJuchurenkei.Rows.Count > 0)
                    {
                        decJusu = decimal.Parse(dtSetJuchurenkei.Rows[0]["受注数量"].ToString());
                        decHonsu = decimal.Parse(dtSetJuchurenkei.Rows[0]["本社出庫数"].ToString());
                        decGifusu = decimal.Parse(dtSetJuchurenkei.Rows[0]["岐阜出庫数"].ToString());
                    }

                    //受注数量が使用在庫数を超えた場合
                    if ((decimal.Parse(txtHachusu.Text) + decHonsu + decGifusu) > decJusu)
                    {
                        //受注数量が使用在庫を超えているというメッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_HACHU_JUCHURENKEI, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return (blAddEnd);
                    }
                }
                catch (Exception ex)
                {
                    //エラーロギング
                    new CommonException(ex);
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return (blAddEnd);
                }
            }

            //取引先コードが本社か岐阜の場合
            if (textSet_Torihikisaki.CodeTxtText == "1111" || textSet_Torihikisaki.CodeTxtText == "2222")
            {
                //発注数が0より小さい数値の場合
                if (int.Parse(txtHachusu.Text) < 0)
                {
                    //仕入先コード1111か2222は返品不可というメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_HACHU_JUCHURENKEI, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return (blAddEnd);
                }
            }

            //発注番号がない場合、伝票番号テーブルから新規伝票番号を得る
            if (txtHachuban.blIsEmpty() == false)
            {
                //ビジネス層のインスタンス生成
                A0100_HachuInput_B hachuB = new A0100_HachuInput_B();
                try
                {
                    //新規番号を取得                    
                    txtHachuban.Text = (hachuB.getNewDenpyo("発注番号")).Rows[0]["最終番号"].ToString();
                }
                catch (Exception ex)
                {
                    //エラーロギング
                    new CommonException(ex);
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return (blAddEnd);
                }
            }

            //受注金額の確保
            decimal decJucyuKin;

            //発注単価の確保
            string strTanka;

            //営業所コードがなかった場合に使用する
            DataTable dtTantoshaCd = new DataTable();

            //商品コードが空だった場合
            if (txtShohinCd.blIsEmpty() == false)
            {
                txtShohinCd.Text = "88888";
            }

            //型番１に記入がないまたは、商品コードが88888の場合
            if (txtData1.blIsEmpty() == false || txtShohinCd.Text == "88888")
            {
                //商品コードを型番１に記入
                txtData1.Text = txtHinmei.Text;
            }

            //受注番号に記入がない場合
            if (txtJuchuban.blIsEmpty() == false)
            {
                //0を入れる
                txtJuchuban.Text = "0";
            }

            //カンマ除去
            strTanka = cmbHachutan.Text.Replace(",", "");

            //整数のみ取得
            decimal decData = decimal.Parse(strTanka.Split('.')[0]);

            //受注金の計算
            decJucyuKin = (decData * (decimal.Parse(txtHachusu.Text)));

            DBConnective con = null;
            KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B juchuB = new KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B();

            con = new DBConnective();

            try
            {
                A0100_HachuInput_B hachuinputB = new A0100_HachuInput_B();

                //ログインＩＤから担当者コードを取り出す
                dtTantoshaCd = hachuinputB.getTantoshaCdSetTantoCd(txtTanto.Text);

                //担当者データがある場合
                if (dtTantoshaCd.Rows.Count > 0)
                {
                    //一行目にデータがない場合
                    if (dtTantoshaCd.Rows[0][0].ToString() == "")
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }

                //営業所を設定
                labelSet_Eigyosho.CodeTxtText = dtTantoshaCd.Rows[0]["営業所コード"].ToString();
                labelSet_Eigyosho.chkTxtEigyousho();

                //PROCに必要なテーブル名の追加
                lstData.Add(textSet_Torihikisaki.CodeTxtText);  //仕入先コード
                lstData.Add(txtHachuYMD.Text);                  //発注年月日
                lstData.Add(txtHachuban.Text);                  //発注番号
                lstData.Add(txtTanto.Text);                     //発注者コード
                lstData.Add(labelSet_Eigyosho.CodeTxtText);	    //営業所コード
                lstData.Add(txtTanto.Text);					    //担当者コード
                lstData.Add(txtJuchuban.Text);					//受注番号
                lstData.Add("0");								//出庫番号
                lstData.Add("0");								//行番号
                lstData.Add(txtShohinCd.Text);					//商品コード
                lstData.Add(labelSet_Maker.CodeTxtText);		//メーカーコード
                lstData.Add(labelSet_Daibunrui.CodeTxtText);	//大分類コード
                lstData.Add(labelSet_Chubunrui.CodeTxtText);	//中分類コード
                lstData.Add(txtData1.Text);					    //Ｃ１
                lstData.Add(txtData2.Text);					    //Ｃ２
                lstData.Add(txtData3.Text);					    //Ｃ３
                lstData.Add(txtData4.Text);					    //Ｃ４
                lstData.Add(txtData5.Text);					    //Ｃ５
                lstData.Add(txtData6.Text);					    //Ｃ６
                lstData.Add(txtHachusu.Text);					//発注数量
                lstData.Add(cmbHachutan.Text);					//発注単価
                lstData.Add(decJucyuKin.ToString());		    //発注金額
                lstData.Add(txtNoki.Text);						//納期
                lstData.Add("0");								//発注フラグ
                lstData.Add(txtChuban.Text);					//注番
                lstData.Add("0");								//加工区分
                lstData.Add(strTorihikisakiSub);	//仕入先名称
                lstData.Add(SystemInformation.UserName);        //ユーザー名

                //PROCに必要なカラム名の追加
                lstTableName.Add("@仕入先コード");              //仕入先コード
                lstTableName.Add("@発注年月日");                //発注年月日
                lstTableName.Add("@発注番号");                  //発注番号
                lstTableName.Add("@発注者コード");              //発注者コード
                lstTableName.Add("@営業所コード");	            //営業所コード
                lstTableName.Add("@担当者コード");	   	        //担当者コード
                lstTableName.Add("@受注番号");				    //受注番号
                lstTableName.Add("@出庫番号");					//出庫番号
                lstTableName.Add("@行番号");					//行番号
                lstTableName.Add("@商品コード");				//商品コード
                lstTableName.Add("@メーカーコード");		    //メーカーコード
                lstTableName.Add("@大分類コード");	            //大分類コード
                lstTableName.Add("@中分類コード");              //中分類コード
                lstTableName.Add("@Ｃ１");					    //Ｃ１
                lstTableName.Add("@Ｃ２");					    //Ｃ２
                lstTableName.Add("@Ｃ３");					    //Ｃ３
                lstTableName.Add("@Ｃ４");					    //Ｃ４
                lstTableName.Add("@Ｃ５");					    //Ｃ５
                lstTableName.Add("@Ｃ６");					    //Ｃ６
                lstTableName.Add("@発注数量");					//発注数量
                lstTableName.Add("@発注単価");					//発注単価
                lstTableName.Add("@発注金額");				    //発注金額
                lstTableName.Add("@納期");	    		        //納期
                lstTableName.Add("@発注フラグ");	    		//発注フラグ
                lstTableName.Add("@注番");			    		//注番
                lstTableName.Add("@加工区分");					//加工区分
                lstTableName.Add("@仕入先名称");	            //仕入先名称
                lstTableName.Add("@ユーザー名");            	//ユーザー名

                //データの追加または更新
                hachuinputB.addHachuInput(lstData, lstTableName);
                
                //ビジネス層のインスタンス生成(担当者マスター)
                M1050_Tantousha_B tantoshaB = new M1050_Tantousha_B();

                //担当者のデータを取り出す
                DataTable dtTantosha = tantoshaB.getTxtTantoshaLeave(txtTanto.Text);

                //取得した注番文字を入れる用
                string strChubanMoji = null;

                //注番文字を取得
                strChubanMoji = dtTantosha.Rows[0]["注番文字"].ToString();

                strChubanMoji = strChubanMoji.Trim();

                //注番文字がなかった場合
                if (strChubanMoji == "")
                {
                    strChubanMoji = ".";
                }

                con.BeginTrans();
                juchuB.updZaiko(txtShohinCd.Text, labelSet_Eigyosho.CodeTxtText, txtHachuYMD.Text, Environment.UserName, con);
                con.Commit();

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU + "\r\n注番:" + strChubanMoji + txtHachuban.Text , CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //登録のみの場合
                if (blAddOnly == true)
                {
                    //取引先コードと発注者コードを確保
                    string strTorihikisakiCd = textSet_Torihikisaki.CodeTxtText;
                    string strTorihikisakiName = textSet_Torihikisaki.valueText.Text;
                    string strHachushaCd = labelSet_Hachusha.CodeTxtText;

                    delText();

                    //一部の項目を戻す
                    textSet_Torihikisaki.CodeTxtText = strTorihikisakiCd;
                    textSet_Torihikisaki.valueText.Text = strTorihikisakiName;
                    labelSet_Hachusha.CodeTxtText = strHachushaCd;
                    labelSet_Hachusha.chkTxtTantosha();

                    textSet_Torihikisaki.Focus();
                }

                //グリッドの表示
                setGridData();

                //登録完了判定
                blAddEnd = true;

                return(blAddEnd);
            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Rollback();
                }
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return (blAddEnd);
            }
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除
        ///</summary>
        private void delText()
        {
            //画面上のクリア
            delFormClear(this,gridHachu);

            //コンボボックスの中身初期化
            cmbHachutan.Items.Clear();

            //記入可能にする
            labelSet_Daibunrui.Enabled = true;
            labelSet_Chubunrui.Enabled = true;
            labelSet_Maker.Enabled = true;
            txtHinmei.Enabled = true;
            lblHinmei.Enabled = true;

            //初期化
            btnF01.Enabled = true;
            btnF03.Enabled = true;

            DataTable dtTantoshaCd = new DataTable();

            A0100_HachuInput_B hachuinputB = new A0100_HachuInput_B();
            try
            {
                //ログインＩＤから担当者コードを取り出す
                dtTantoshaCd = hachuinputB.getTantoshaCdSetUserID(SystemInformation.UserName);

                //担当者データがある場合
                if (dtTantoshaCd.Rows.Count > 0)
                {
                    //一行目にデータがない場合
                    if (dtTantoshaCd.Rows[0][0].ToString() == "")
                    {
                        return;
                    }
                }

                labelSet_Hachusha.CodeTxtText = dtTantoshaCd.Rows[0]["担当者コード"].ToString();
                labelSet_Hachusha.chkTxtTantosha();

                labelSet_Eigyosho.CodeTxtText = dtTantoshaCd.Rows[0]["営業所コード"].ToString();
                labelSet_Eigyosho.chkTxtEigyousho();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

            //今日の日付を記入
            txtHachuYMD.Text = DateTime.Today.ToString();

            txtHachuYMD.Focus();
        }

        ///<summary>
        ///delHachu
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delHachu()
        {
            //受注番号が記入されている場合
            if (txtJuchuban.Text != "")
            {
                //検索時のデータ取り出し先(受注検出時)
                DataTable dtSetCdJuchuNo;

                //検索時のデータ取り出し先(発注検出時)
                DataTable dtSetCdHachuNo;

                //ビジネス層のインスタンス生成
                A0100_HachuInput_B hachuB = new A0100_HachuInput_B();

                DBConnective con = null;
                KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B juchuB = new KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B();

                con = new DBConnective();

                try
                {
                    //戻り値のDatatableを取り込む（該当DBで受注番号を検索）
                    dtSetCdJuchuNo = hachuB.getJuchuNoCheck(txtJuchuban.Text);

                    //１件以上データがある場合
                    if (dtSetCdJuchuNo.Rows.Count > 0)
                    {
                        //受注番号があるので、受注伝票に誘導のコメント（OK）
                        BaseMessageBox basemessageboxJuchu = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_HACHU_JUCHUNO_JUCHUDEL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessageboxJuchu.ShowDialog();
                        return;
                    }

                    //戻り値のDatatableを取り込む（該当DBで発注番号を検索）
                    dtSetCdHachuNo = hachuB.getHachuNoCheck(txtHachuban.Text);

                    //仕入済数量が0以上の場合
                    if (decimal.Parse(dtSetCdHachuNo.Rows[0]["仕入済数量"].ToString()) > 0)
                    {
                        //既に仕入済みのため、削除できないとメッセージ（OK）
                        BaseMessageBox basemessageboxErr = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_HACHU_JUCHUNO_NOTDEL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessageboxErr.ShowDialog();
                        return;
                    }

                    //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
                    BaseMessageBox basemessageboxSa = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                    //NOが押された場合
                    if (basemessageboxSa.ShowDialog() == DialogResult.No)
                    {
                        return;
                    }

                    //削除工程
                    hachuB.delHachu(txtHachuban.Text, SystemInformation.UserName);

                    con.BeginTrans();
                    juchuB.updZaiko(txtShohinCd.Text, labelSet_Eigyosho.CodeTxtText, txtHachuYMD.Text, Environment.UserName, con);
                    con.Commit();

                    //削除されましたメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();

                    //取引先コードと発注者コードを確保
                    string strTorihikisakiCd = textSet_Torihikisaki.CodeTxtText;
                    string strTorihikisakiName = textSet_Torihikisaki.valueText.Text;
                    string strHachushaCd = labelSet_Hachusha.CodeTxtText;

                    delText();

                    //一部の項目を戻す
                    textSet_Torihikisaki.CodeTxtText = strTorihikisakiCd;
                    textSet_Torihikisaki.valueText.Text = strTorihikisakiName;
                    labelSet_Hachusha.CodeTxtText = strHachushaCd;
                    labelSet_Hachusha.chkTxtTantosha();

                    textSet_Torihikisaki.Focus();
                }
                catch (Exception ex)
                {
                    if (con != null)
                    {
                        con.Rollback();
                    }
                    //エラーロギング
                    new CommonException(ex);
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }
        }

        ///<summary>
        ///closeShohinList
        ///ShohinListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void closeShohinList()
        {
            txtHachusu.Focus();
        }

        ///<summary>
        ///textSet_Torihikisaki_Leave
        ///仕入先コードから離れた場合
        ///</summary>
        private void textSet_Torihikisaki_Leave(object sender, EventArgs e)
        {
            setGridData();
        }

        ///<summary>
        ///setGridData
        //仕入先コードありでの検索
        ///</summary>
        private void setGridData()
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //前後の空白を取り除く
            textSet_Torihikisaki.CodeTxtText = textSet_Torihikisaki.CodeTxtText.Trim();

            //取引先コードが記入されていない場合
            if (textSet_Torihikisaki.CodeTxtText == "")
            {
                return;
            }

            //ビジネス層のインスタンス生成
            A0100_HachuInput_B hachuB = new A0100_HachuInput_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = hachuB.getHachuGrid(textSet_Torihikisaki.CodeTxtText);

                //１件以上データがある場合
                if (dtSetCd.Rows.Count > 0)
                {
                    //データグリッドビューに表示
                    gridHachu.DataSource = dtSetCd;
                }
                else
                {
                    gridHachu.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        ///<summary>
        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void gridHachu_DoubleClick(object sender, EventArgs e)
        {
            //データグリッドビュー上での共通処理
            getSelectItem();
        }

        ///<summary>
        ///setSelectItem
        ///データグリッドビュー上での共通処理
        ///</summary>
        private void getSelectItem()
        {
            //コンボボックスの中身初期化
            cmbHachutan.Items.Clear();

            //選択したものが空の場合
            if (gridHachu.Rows.Count == 0)
            {
                return;
            }

            //選択されたデータの"発注番号"を取得
            txtHachuban.Text = (string)gridHachu.CurrentRow.Cells["発注番号"].Value.ToString();

            //データの表示
            getView();
        }

        ///<summary>
        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtHachuKeyUp(object sender, KeyEventArgs e)
        {
            //フォーカスの確保
            Control cActiveBefore = this.ActiveControl;

            //ベーステキストのインスタンス生成
            BaseText basetext = new BaseText();
            //キーアップされた時の判断処理
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///setDaibun
        ///リスト内の大分類が変更されたのを反映
        ///</summary>
        public void setDaibun(string strDaibun)
        {
            //テキストボックスに記入
            labelSet_Daibunrui.CodeTxtText = strDaibun;
        }

        ///<summary>
        ///labelSet_Hachusha_Leave
        ///発注者コード入力後に担当者コードテキストに確保
        ///</summary>
        private void labelSet_Hachusha_Leave(object sender, EventArgs e)
        {
            //担当者コードテキストに確保
            txtTanto.Text = labelSet_Hachusha.CodeTxtText;
        }

        ///<summary>
        ///txtHachuban_Leave
        ///発注番号のチェック
        ///</summary>
        private void txtHachuban_Leave(object sender, EventArgs e)
        {
            //発注番号に記入がない場合
            if (txtHachuban.blIsEmpty() == false)
            {
                return;
            }

            //受注番号の記入を取り消す
            txtJuchuban.Clear();

            //データの表示
            getView();
        }

        ///<summary>
        ///getView
        ///データの表示
        ///</summary>
        private void getView()
        {
            //検索時のデータ取り出し先(グリッド全体)
            DataTable dtSetCd;
            //検索時のデータ取り出し先(受注検出時)
            DataTable dtSetCdJuchuNo;
            //検索時のデータ取り出し先(単価検出時)
            DataTable dtSetTanka;
            //検索時のデータ取り出し先(商品)
            DataTable dtSetShohin;

            //ビジネス層のインスタンス生成
            A0100_HachuInput_B hachuB = new A0100_HachuInput_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = hachuB.getHachuLeave(txtHachuban.Text);

                //１件以上データがある場合
                if (dtSetCd.Rows.Count > 0)
                {
                    //受注番号が1以上の場合
                    if (int.Parse(dtSetCd.Rows[0]["受注番号"].ToString()) > 0)
                    {
                        //戻り値のDatatableを取り込む
                        dtSetCdJuchuNo = hachuB.getHachuNoCheck(dtSetCd.Rows[0]["受注番号"].ToString());

                        //１件以上データがある場合
                        if (dtSetCdJuchuNo.Rows.Count > 0)
                        {
                            //受注番号があるので、受注入力に誘導のコメント（OK）
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_HACHU_JUCHUNO_SHUSEI, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();

                            //登録削除をさせない
                            btnF01.Enabled = false;
                            btnF03.Enabled = false;
                        }
                    }

                    //戻り値のDatatableを取り込む
                    dtSetTanka = hachuB.getTanka(dtSetCd.Rows[0]["商品コード"].ToString());

                    //条件付き単価が１件以上ある場合
                    if (dtSetTanka.Rows.Count > 0)
                    {
                        //条件付き単価の行数分
                        for (int cnt = 0; cnt < dtSetTanka.Rows.Count; cnt++)
                        {
                            //テキストボックス表示用の0行目
                            if (cnt == 0)
                            {
                                cmbHachutan.Items.Add("");
                            }

                            //各月と日を確保
                            string strMonth = ((DateTime)dtSetTanka.Rows[cnt]["日時"]).Month.ToString();
                            string strDay = ((DateTime)dtSetTanka.Rows[cnt]["日時"]).Day.ToString();

                            //月の桁数が1桁以下の場合
                            if (strMonth.Length <= 1)
                            {
                                strMonth = strMonth.PadLeft(2, '0');
                            }

                            //日の桁数が1桁以下の場合
                            if (strDay.Length <= 1)
                            {
                                strDay = strDay.PadLeft(2, '0');
                            }

                            cmbHachutan.Items.Add(((decimal)dtSetCd.Rows[0]["発注単価"]).ToString("#,#.00") + ":" + (((DateTime)dtSetTanka.Rows[cnt]["日時"]).Year.ToString()).Substring(2) + "/" + strMonth + "/" + strDay);
                        }
                    }
                    else
                    {
                        cmbHachutan.Items.Add("0.00");
                    }

                    txtHachuYMD.Text = dtSetCd.Rows[0]["発注年月日"].ToString();
                    labelSet_Hachusha.CodeTxtText = dtSetCd.Rows[0]["発注者コード"].ToString();
                    textSet_Torihikisaki.CodeTxtText = dtSetCd.Rows[0]["仕入先コード"].ToString();

                    //仕入先データのチェック
                    textSet_Torihikisaki.chkTxtTorihikisaki();

                    //仕入先コードでの仕入先名称と発注テーブルの仕入先名称が違う場合
                    if (textSet_Torihikisaki.valueTextText.Trim() != dtSetCd.Rows[0]["仕入先名称"].ToString().Trim())
                    {
                        //発注テーブルの仕入先名称に差し替える
                        textSet_Torihikisaki.valueTextText = dtSetCd.Rows[0]["仕入先名称"].ToString().Trim();
                    }

                    txtShohinCd.Text = dtSetCd.Rows[0]["商品コード"].ToString();
                    txtHachusu.Text = ((decimal)dtSetCd.Rows[0]["発注数量"]).ToString("#,#");
                    cmbHachutan.Text = ((decimal)dtSetCd.Rows[0]["発注単価"]).ToString("#,0.00");
                    txtNoki.Text = dtSetCd.Rows[0]["納期"].ToString();
                    txtChuban.Text = dtSetCd.Rows[0]["注番"].ToString();
                    txtJuchuban.Text = dtSetCd.Rows[0]["受注番号"].ToString();

                    labelSet_Daibunrui.CodeTxtText = dtSetCd.Rows[0]["大分類コード"].ToString();
                    labelSet_Daibunrui.chkTxtDaibunrui();
                    labelSet_Chubunrui.CodeTxtText = dtSetCd.Rows[0]["中分類コード"].ToString();
                    labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText);
                    labelSet_Maker.CodeTxtText = dtSetCd.Rows[0]["メーカーコード"].ToString();
                    labelSet_Maker.chkTxtMaker();

                    txtData1.Text = dtSetCd.Rows[0]["Ｃ１"].ToString();
                    txtData2.Text = dtSetCd.Rows[0]["Ｃ２"].ToString();
                    txtData3.Text = dtSetCd.Rows[0]["Ｃ３"].ToString();
                    txtData4.Text = dtSetCd.Rows[0]["Ｃ４"].ToString();
                    txtData5.Text = dtSetCd.Rows[0]["Ｃ５"].ToString();
                    txtData6.Text = dtSetCd.Rows[0]["Ｃ６"].ToString();

                    labelSet_Eigyosho.CodeTxtText = dtSetCd.Rows[0]["営業所コード"].ToString();
                    labelSet_Eigyosho.chkTxtEigyousho();
                    txtTanto.Text = dtSetCd.Rows[0]["担当者コード"].ToString();

                    //受注番号が1以上で存在していた場合
                    if (int.Parse(dtSetCd.Rows[0]["受注番号"].ToString()) > 0)
                    {
                        txtJuchuban.Text = dtSetCd.Rows[0]["受注番号"].ToString();
                    }

                    txtHinmei.Text = ((TextBox)txtData1).Text.Trim() + " "
                                   + ((TextBox)txtData2).Text.Trim() + " "
                                   + ((TextBox)txtData3).Text.Trim() + " "
                                   + ((TextBox)txtData4).Text.Trim() + " "
                                   + ((TextBox)txtData5).Text.Trim() + " "
                                   + ((TextBox)txtData6).Text.Trim() + " ";

                    //商品コードがある場合
                    if (txtShohinCd.Text != "")
                    {
                        //商品
                        dtSetShohin = hachuB.getShohin(txtShohinCd.Text);

                        //商品データがある場合
                        if (dtSetShohin.Rows.Count > 0)
                        {
                            //発注単価のピリオド取り
                            decimal decHachu = decimal.Parse(dtSetCd.Rows[0]["発注単価"].ToString().Split('.')[0]);

                            //定価のピリオド取り
                            decimal decTeika = decimal.Parse(dtSetShohin.Rows[0]["定価"].ToString().Split('.')[0]);

                            //定価の確保
                            txtTeka.Text = decTeika.ToString();
                            txtTeka.updPriceMethod();

                            //定価が0以下の場合
                            if (decTeika < 1)
                            {
                                //掛け率0.0
                                txtKakeritsu.Text = "0.0";
                            }
                            else
                            {
                                //規定の計算で掛け率を記入
                                txtKakeritsu.Text = ((decHachu / decTeika) * 100).ToString("0.0");
                            }
                            lblGrayTanaHon.Text = dtSetShohin.Rows[0]["棚番本社"].ToString();
                            lblGrayTanaGihu.Text = dtSetShohin.Rows[0]["棚番岐阜"].ToString();
                        }
                        else
                        {
                            //商品データがない処理
                            txtTeka.Text = "";
                            txtKakeritsu.Text = "";
                            lblGrayTanaHon.Text = "";
                            lblGrayTanaGihu.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///cmbHachutan_Leave
        ///発注単価から離れた時の処理
        ///</summary>
        private void cmbHachutan_Leave(object sender, EventArgs e)
        {
            //小数点処理が出来た場合
            if (setcmbHachutanSetUp())
            {
                //掛率の再計算
                setKakeritsu();
            }
        }

        ///<summary>
        ///setcmbHachutanSetUp
        ///発注単価の表示時の小数点関係の処理
        ///</summary>
        private Boolean setcmbHachutanSetUp()
        {
            bool blCheckTrue = false;

            //前後の空白を取り除く
            cmbHachutan.Text = cmbHachutan.Text.Trim();

            //発注単価の記入がない場合
            if (cmbHachutan.Text == "")
            {
                return(blCheckTrue);
            }

            //ダブル型に変換できるか試す用
            double dblData;

            //double型に変換できれば
            if (double.TryParse(cmbHachutan.Text.ToString(), out dblData))
            {
                //スルー
            }
            else
            {
                //時間の部分を除去
                cmbHachutan.Text = cmbHachutan.Text.Split(':')[0];
            }

            cmbHachutan.Text = decimal.Parse(cmbHachutan.Text).ToString("#,#.00");

            return blCheckTrue = true;
        }

        ///<summary>
        ///setKakeritsu
        ///掛率の再計算
        ///</summary>
        private void setKakeritsu()
        {
            //定価が存在する場合
            if (txtTeka.blIsEmpty() == false)
            {
                return;
            }

            decimal decTeka = decimal.Parse(txtTeka.Text);
            decimal decTanka = decimal.Parse(cmbHachutan.Text);

            //定価か単価が0の場合
            if (decTeka == 0 || decTanka == 0)
            {
                txtKakeritsu.Text = "0";
            }
            else
            {
                //規定の計算で掛け率を記入
                txtKakeritsu.Text = ((decTanka / decTeka) * 100).ToString("0.0");
            }
        }

        ///<summary>
        ///printHachuInput
        ///印刷ダイアログ
        ///</summary>
        private void printHachuInput()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtPrintData = new DataTable();

            //PDF作成後の入れ物
            string strFile = "";

            //発注番号コードがない場合
            if (txtHachuban.blIsEmpty() == false)
            {
                //新規登録（印刷処理用フラグを渡す）
                if (addHachu(false) == false)
                {
                    return;
                }
            }

            //ビジネス層のインスタンス生成
            A0100_HachuInput_B hachuB = new A0100_HachuInput_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtPrintData = hachuB.getHachu(txtHachuban.Text);

                //１件以上データがない場合
                if (dtPrintData.Rows.Count < 1)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
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
                    strFile = hachuB.dbToPdf(dtPrintData);

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    strFile = hachuB.dbToPdf(dtPrintData);

                    // 一括印刷
                    pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
                }
                
                //発注テーブルの該当発注番号の印刷フラグを立てる
                hachuB.updHachu(txtHachuban.Text);

            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        ///<summary>
        ///txtKeyPress
        ///発注単価での入力キー処理
        ///</summary>
        private void txtKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b'
            && e.KeyChar != '\u0001' && e.KeyChar != '\u0003' && e.KeyChar != '\u0016' && e.KeyChar != '\u0018')
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        /// <summary>
        ///     途中入力の場合のチェックロジック
        /// </summary>
        /// <returns>
        ///    エラーの場合：true 正常な場合：false
        /// </returns>
        public bool chkMoneyText()
        {
            // テキストボックスの値を取得
            string strTextBoxValue = cmbHachutan.Text;

            if (strTextBoxValue == "")
            {
                return false;
            }

            if (strTextBoxValue.Equals(""))
            {
                if (this.Parent is BaseForm)
                {
                    //データ存在なしメッセージ（OK）
                    BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this.Parent, "", "数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox_Nodata.ShowDialog();

                    this.Text = "";
                }
                else if (this.Parent.Parent is BaseForm)
                {
                    //データ存在なしメッセージ（OK）
                    BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this.Parent.Parent, "", "数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox_Nodata.ShowDialog();

                    this.Text = "";
                }

                return true;
            }

            cmbHachutan.Text = strTextBoxValue;

            return false;
        }
    }
}
