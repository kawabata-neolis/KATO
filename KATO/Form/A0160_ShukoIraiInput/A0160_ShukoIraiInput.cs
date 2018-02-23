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
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.A0160_ShukoIraiInput;
using KATO.Common.Form;

namespace KATO.Form.A0160_ShukoIraiInput
{
    ///<summary>
    ///A0160_ShukoIraiInput
    ///出庫依頼入力
    ///作成者：大河内
    ///作成日：2017/02/21
    ///更新者：
    ///更新日：
    ///</summary>
    public partial class A0160_ShukoIraiInput : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///A0160_ShukoIraiInput
        ///フォームの初期設定
        ///</summary>
        public A0160_ShukoIraiInput(Control c)
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
            lblsetDaibunrui.Lschubundata = lblsetChubunrui;

            //メーカーsetデータを読めるようにする
            lblsetDaibunrui.Lsmakerdata = lblsetMaker;

            //伝票番号テキストボックスの左寄せ
            txtDenpyoNo.TextAlign = HorizontalAlignment.Left;
        }

        ///<summary>
        ///A0160_ShukoIraiInput_Load
        ///画面レイアウト設定
        ///</summary>
        private void A0160_ShukoIraiInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "出庫依頼入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1; //登録
            this.btnF03.Text = STR_FUNC_F3; //削除
            this.btnF04.Text = STR_FUNC_F4; //取消
            this.btnF09.Text = STR_FUNC_F9; //検索
            this.btnF12.Text = STR_FUNC_F12;//終了

            //当日の年月日を記入
            txtYMD.Text = DateTime.Today.ToString("yyyy/MM/dd");

            //担当者コードと営業所コードを取得、記入
            setTantoCdEigyoCd();

            //グリッドの設定
            setupGrid();
        }

        ///<summary>
        ///setupGrid
        ///DataGridView初期設定
        ///</summary>
        private void setupGrid()
        {
            //列自動生成禁止
            gridShuko.AutoGenerateColumns = false;

            //カラム名の指定
            DataGridViewTextBoxColumn denpyoNo = new DataGridViewTextBoxColumn();
            denpyoNo.DataPropertyName = "伝票番号";
            denpyoNo.Name = "伝票番号";
            denpyoNo.HeaderText = "伝票番号";

            //カラム名の指定
            DataGridViewTextBoxColumn iraibi = new DataGridViewTextBoxColumn();
            iraibi.DataPropertyName = "依頼日";
            iraibi.Name = "依頼日";
            iraibi.HeaderText = "依頼日";

            //カラム名の指定
            DataGridViewTextBoxColumn tantoName = new DataGridViewTextBoxColumn();
            tantoName.DataPropertyName = "担当者名";
            tantoName.Name = "担当者名";
            tantoName.HeaderText = "担当者名";

            //カラム名の指定
            DataGridViewTextBoxColumn shukoeigyo = new DataGridViewTextBoxColumn();
            shukoeigyo.DataPropertyName = "出庫営業所";
            shukoeigyo.Name = "出庫営業所";
            shukoeigyo.HeaderText = "出庫営業所";

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
            DataGridViewTextBoxColumn su = new DataGridViewTextBoxColumn();
            su.DataPropertyName = "数量";
            su.Name = "数量";
            su.HeaderText = "数量";

            //各カラムのバインド（文章の寄せ、カラム名の位置、フォーマット指定、横幅サイズ）
            setColumn(denpyoNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(iraibi, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumn(tantoName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 110);
            setColumn(shukoeigyo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(chubun, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 530);
            setColumn(su, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 90);

            //グリッドに非表示する項目
            gridShuko.Columns["伝票番号"].Visible = false;

        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            //column設定
            gridShuko.Columns.Add(col);

            //カラム名が空でない場合
            if (gridShuko.Columns[col.Name] != null)
            {
                //横幅サイズの決定
                gridShuko.Columns[col.Name].Width = intLen;
                //文章の寄せ方向の決定
                gridShuko.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                //カラム名の位置の決定
                gridShuko.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                //フォーマットが指定されていた場合
                if (fmt != null)
                {
                    //フォーマットを指定
                    gridShuko.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///A0160_ShukoIraiInput_KeyDown
        ///キー入力判定(画面全体)
        ///</summary>
        private void A0160_ShukoIraiInput_KeyDown(object sender, KeyEventArgs e)
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
                    this.addShuko();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delShuko();
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
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judTxtShukoKeyDown
        ///キー入力判定(テキストボックス)
        ///</summary>
        private void judTxtShukoKeyDown(object sender, KeyEventArgs e)
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
        private void txtKensaku_KeyDown(object sender, KeyEventArgs e)
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
                    //検索テキストボックスが空の場合
                    if (txtKensaku.blIsEmpty() == false)
                    {
                        //TABボタンと同じ効果
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                        //商品検索画面の表示処理
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
        ///gridShuko_KeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///</summary>        
        private void gridShuko_KeyDown(object sender, KeyEventArgs e)
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
        ///judFuncBtnClick
        ///ファンクションボタンの反応
        ///</summary>
        private void judFuncBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addShuko();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delShuko();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F12: // 終了
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
            //商品検索画面のインスタンス生成
            ShouhinList shouhinlist = new ShouhinList(this);
            try
            {
                //検索項目に一つでも記入がある場合
                if (lblsetDaibunrui.codeTxt.blIsEmpty() == false &&
                    lblsetChubunrui.codeTxt.blIsEmpty() == false &&
                    lblsetMaker.codeTxt.blIsEmpty() == false &&
                    txtKensaku.blIsEmpty() == false)
                {
                    //商品検索画面へ移動時に検索をしない
                    shouhinlist.blKensaku = false;
                }
                else
                {
                    //商品検索画面へ移動時に検索をする
                    shouhinlist.blKensaku = true;
                }

                //表示していた品名を確保
                string strHinmeiBef = txtHinmei.Text;

                //検索項目が編集できる状態かどうか判断
                Boolean blEnabledTrue = false;

                //検索項目が編集できる状態だった場合(Enable処理は複数一挙に行うため、大分類コードのみの確認でＯＫ)
                if (lblsetDaibunrui.Enabled == true)
                {
                    //検索項目が編集できる状態だった判定
                    blEnabledTrue = true;
                }

                //編集可能にする
                lblsetDaibunrui.Enabled = true;
                lblsetChubunrui.Enabled = true;
                lblsetMaker.Enabled = true;
                txtHinmei.Enabled = true;
                lblHinmei.Enabled = true;

                //商品検索画面と繋げるデータ
                shouhinlist.intFrmKind = CommonTeisu.FRM_HACHUINPUT;    //画面No
                shouhinlist.lsDaibunrui = lblsetDaibunrui;              //大分類ラベルセット
                shouhinlist.lsChubunrui = lblsetChubunrui;              //中分類ラベルセット
                shouhinlist.lsMaker = lblsetMaker;                      //メーカーラベルセット
                shouhinlist.btxtHinC1Hinban = txtHinmei;                //品名テキストボックス
                shouhinlist.btxtHinC1 = txtC1;                          //Ｃ１テキストボックス
                shouhinlist.btxtHinC2 = txtC2;                          //Ｃ２テキストボックス
                shouhinlist.btxtHinC3 = txtC3;                          //Ｃ３テキストボックス
                shouhinlist.btxtHinC4 = txtC4;                          //Ｃ４テキストボックス
                shouhinlist.btxtHinC5 = txtC5;                          //Ｃ５テキストボックス
                shouhinlist.btxtHinC6 = txtC6;                          //Ｃ６テキストボックス
                shouhinlist.btxtShohinCd = txtShohinCd;                 //商品コードテキストボックス
                shouhinlist.btxtKensaku = txtKensaku;                   //検索テキストボックス
                shouhinlist.bmtxtShireTanka = txtTanka;                 //単価テキストボックス

                //商品検索画面の表示
                shouhinlist.ShowDialog();

                //商品リストから新しく選ばれた場合
                if (strHinmeiBef != txtHinmei.Text)
                {
                    txtHinmei.Enabled = false;
                    lblHinmei.Enabled = false;

                    //カンマ処理
                    txtTanka.updPriceMethod();
                    //数量テキストボックスにフォーカス
                    txtSu.Focus();
                }
                else
                {
                    //商品リストに行く前に検索項目が編集できない状態だった場合
                    if (blEnabledTrue == false)
                    {
                        //編集不可能にする(検索前の状態にする)
                        lblsetDaibunrui.Enabled = false;
                        lblsetChubunrui.Enabled = false;
                        lblsetMaker.Enabled = false;
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
        ///addHachu
        ///テキストボックス内のデータをDBに登録または更新
        ///</summary>
        private void addShuko()
        {
            //データ追加用（テーブル名）
            List<string> lstTableName = new List<string>();
            //データ追加用（データ内容）
            List<string> lstData = new List<string>();

            //文字判定(出庫年月日)
            if (txtYMD.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                //出庫年月日にフォーカス
                txtYMD.Focus();
                return;
            }

            //文字判定(担当者)
            if (lblsetTantosha.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                //担当者にフォーカス
                lblsetTantosha.Focus();
                return;
            }
            //担当者コードが正しくない場合
            else if (lblsetTantosha.chkTxtTantosha() == true)
            {
                //担当者にフォーカス
                lblsetTantosha.Focus();
                return;
            }

            //文字判定(出庫営業所)
            if (lblsetShukoEigyosho.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                //出庫営業所にフォーカス
                lblsetShukoEigyosho.Focus();
                return;
            }
            //出庫営業所コードが正しくない場合
            else if (lblsetShukoEigyosho.chkTxtEigyousho() == true)
            {
                //出庫営業所にフォーカス
                lblsetShukoEigyosho.Focus();
                return;
            }

            //文字判定(大分類)
            if (lblsetDaibunrui.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                //大分類にフォーカス
                lblsetDaibunrui.Focus();
                return;
            }
            //大分類コードが正しくない場合
            else if (lblsetDaibunrui.chkTxtDaibunrui() == true)
            {
                //大分類にフォーカス
                lblsetDaibunrui.Focus();
                return;
            }

            //文字判定(中分類)
            if (lblsetChubunrui.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                //中分類にフォーカス
                lblsetChubunrui.Focus();
                return;
            }
            //中分類コードが正しくない場合
            else if (lblsetChubunrui.chkTxtChubunrui(lblsetDaibunrui.CodeTxtText) == true)
            {
                //中分類にフォーカス
                lblsetChubunrui.Focus();
                return;
            }

            //文字判定(メーカー)
            if (lblsetMaker.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                //メーカーにフォーカス
                lblsetMaker.Focus();
                return;
            }
            //メーカーコードが正しくない場合
            else if (lblsetMaker.chkTxtMaker() == true)
            {
                //メーカーにフォーカス
                lblsetMaker.Focus();
                return;
            }

            //文字判定(数量)
            if (txtSu.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                //数量にフォーカス
                txtSu.Focus();
                return;
            }

            //文字判定(単価)
            if (txtTanka.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                //単価にフォーカス
                txtTanka.Focus();
                return;
            }

            //文字判定(品名)
            if (txtHinmei.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                //品名にフォーカス
                txtHinmei.Focus();
                return;
            }

            //伝票番号がない場合、伝票番号テーブルから新規伝票番号を得る
            if (txtDenpyoNo.blIsEmpty() == false)
            {
                //ビジネス層のインスタンス生成
                A0160_ShukoIraiInput_B shukoiraiB = new A0160_ShukoIraiInput_B();
                try
                {
                    //新規番号を取得                    
                    txtDenpyoNo.Text = (shukoiraiB.getNewDenpyo("出庫依頼")).Rows[0]["最終番号"].ToString();
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

            //DB登録用
            string strC1 = "";
            string strC2 = "";
            string strC3 = "";
            string strC4 = "";
            string strC5 = "";
            string strC6 = "";

            //品名を自分で記入した場合
            if (txtHinmei.Enabled == true)
            {
                //品名をＣ１に入れる
                strC1 = txtHinmei.Text;
            }
            //品名が編集できない場合(商品検索画面から取り込んだ場合)
            else
            {
                //自分で記入した場合空になるのでテキストボックスをそのまま入れる(現行通り)
                strC1 = txtC1.Text;
                strC2 = txtC2.Text;
                strC3 = txtC3.Text;
                strC4 = txtC4.Text;
                strC5 = txtC5.Text;
                strC6 = txtC6.Text;
            }

            //商品コードを入れる用
            string strShohinCd;

            //商品コードが空でない場合
            if (txtShohinCd.blIsEmpty() == false)
            {
                //強制的に88888を記入
                strShohinCd = "88888";
            }
            else
            {
                //商品コードテキストボックスを記入
                strShohinCd = txtShohinCd.Text;
            }

            try
            {
                //ビジネス層のインスタンス生成
                A0160_ShukoIraiInput_B shukoiraiB = new A0160_ShukoIraiInput_B();

                //PROCに必要なテーブル名の追加
                lstData.Add(txtYMD.Text);                       //依頼年月日
                lstData.Add(txtDenpyoNo.Text);                  //伝票番号
                lstData.Add(lblsetTantosha.CodeTxtText);        //担当者コード
                lstData.Add(lblsetEigyosho.CodeTxtText);        //営業所コード
                lstData.Add(lblsetShukoEigyosho.CodeTxtText);   //出庫営業所コード
                lstData.Add(txtShohinCd.Text);                  //商品コード
                lstData.Add(lblsetMaker.CodeTxtText);           //メーカーコード
                lstData.Add(lblsetDaibunrui.CodeTxtText);       //大分類コード
                lstData.Add(lblsetChubunrui.CodeTxtText);       //中分類コード
                lstData.Add(strC1);                             //C1
                lstData.Add(strC2);                             //C2
                lstData.Add(strC3);                             //C3
                lstData.Add(strC4);                             //C4
                lstData.Add(strC5);                             //C5
                lstData.Add(strC6);                             //C6
                lstData.Add(txtSu.Text);                        //数量
                lstData.Add(txtTanka.Text);                     //単価
                lstData.Add(DBNull.Value.ToString());           //承認年月日
                lstData.Add("N");                               //承認
                lstData.Add("0");                               //処理済
                lstData.Add(SystemInformation.UserName);        //ユーザー名

                //PROCに必要なカラム名の追加
                lstTableName.Add("@依頼年月日");                //依頼年月日
                lstTableName.Add("@伝票番号");                  //伝票番号
                lstTableName.Add("@担当者コード");              //担当者
                lstTableName.Add("@営業所コード");              //営業所
                lstTableName.Add("@出庫倉庫");	                //出庫営業所
                lstTableName.Add("@商品コード");	   	        //商品コード
                lstTableName.Add("@メーカーコード");			//メーカーコード
                lstTableName.Add("@大分類コード");				//大分類コード
                lstTableName.Add("@中分類コード");				//中分類コード
                lstTableName.Add("@Ｃ１");				        //C1
                lstTableName.Add("@Ｃ２");		                //C2
                lstTableName.Add("@Ｃ３");	                    //C3
                lstTableName.Add("@Ｃ４");                      //C4
                lstTableName.Add("@Ｃ５");					    //C5
                lstTableName.Add("@Ｃ６");					    //C6
                lstTableName.Add("@数量");					    //数量
                lstTableName.Add("@単価");					    //単価
                lstTableName.Add("@承認年月日");				//承認年月日
                lstTableName.Add("@承認");					    //承認
                lstTableName.Add("@処理済");					//処理済
                lstTableName.Add("@ユーザー名");                //ユーザー名

                //データの追加または更新
                shukoiraiB.addShukoInput(lstData, lstTableName);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //指定テキストボックスを白紙にする
                delText();

                //出庫依頼明細グリッドの表示
                setGridData();

                //出庫営業所にフォーカス
                lblsetShukoEigyosho.Focus();
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
        ///delShuko
        ///データ削除
        ///</summary>
        private void delShuko()
        {
            //データ追加用（テーブル名）
            List<string> lstTableName = new List<string>();
            //データ追加用（データ内容）
            List<string> lstData = new List<string>();

            //伝票番号がない場合
            if (txtDenpyoNo.blIsEmpty() == false)
            {
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "削除する伝票を呼び出してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                //グリッドにフォーカス
                gridShuko.Focus();
                return;
            }

            //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
            BaseMessageBox basemessageboxDel = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
            //NOが押された場合
            if (basemessageboxDel.ShowDialog() == DialogResult.No)
            {
                return;
            }

            try
            {
                //ビジネス層のインスタンス生成
                A0160_ShukoIraiInput_B shukoiraiB = new A0160_ShukoIraiInput_B();

                //PROCに必要なデータの追加
                lstData.Add(txtDenpyoNo.Text);                  //伝票番号
                lstData.Add(SystemInformation.UserName);        //ユーザー名

                //PROCに必要なカラム名の追加
                lstTableName.Add("@伝票番号");                  //伝票番号
                lstTableName.Add("@ユーザー名");                //ユーザー名

                //データの削除
                shukoiraiB.updShukoInputDel(lstData, lstTableName);

                //メッセージボックスの処理、削除完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //指定テキストボックスを白紙にする
                delText();

                //出庫営業所にフォーカス
                lblsetShukoEigyosho.Focus();
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
        ///delText
        ///テキストボックス内の文字を削除
        ///</summary>
        private void delText()
        {
            txtYMD.Text = DateTime.Today.ToString("yyyy/MM/dd");
            txtDenpyoNo.Text = "";
            lblsetDaibunrui.CodeTxtText = "";
            lblsetDaibunrui.chkTxtDaibunrui();
            lblsetChubunrui.CodeTxtText = "";
            lblsetChubunrui.chkTxtChubunrui(lblsetDaibunrui.CodeTxtText);
            lblsetMaker.CodeTxtText = "";
            lblsetMaker.chkTxtMaker();
            lblsetShukoEigyosho.CodeTxtText = "";
            lblsetShukoEigyosho.chkTxtEigyousho();
            txtShohinCd.Text = "";
            txtKensaku.Text = "";
            txtHinmei.Text = "";
            txtSu.Text = "";
            txtTanka.Text = "";
            txtC1.Text = "";
            txtC2.Text = "";
            txtC3.Text = "";
            txtC4.Text = "";
            txtC5.Text = "";
            txtC6.Text = "";
            gridShuko.DataSource = "";

            //担当者コードと営業所コードの取得、配置
            setTantoCdEigyoCd();

            //編集可能にする
            lblsetDaibunrui.Enabled = true;
            lblsetChubunrui.Enabled = true;
            lblsetMaker.Enabled = true;
            txtHinmei.Enabled = true;
            lblHinmei.Enabled = true;

            //初期化
            lblsetChubunrui.strDaibunCd = null;

            //出庫年月日にフォーカス
            txtYMD.Focus();
        }

        ///<summary>
        ///setGridData
        //出庫依頼明細グリッドの表示
        ///</summary>
        private void setGridData()
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //前後の空白を取り除く
            txtDenpyoNo.Text = txtDenpyoNo.Text.Trim();

            //ビジネス層のインスタンス生成
            A0160_ShukoIraiInput_B shukoiraiB = new A0160_ShukoIraiInput_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = shukoiraiB.getShukoGrid(lblsetTantosha.CodeTxtText, lblsetShukoEigyosho.CodeTxtText);

                //１件以上データがある場合
                if (dtSetCd.Rows.Count > 0)
                {
                    //データグリッドビューに表示
                    gridShuko.DataSource = dtSetCd;
                }
                else
                {
                    //グリッドを空にする
                    gridShuko.DataSource = "";
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
        ///lblsetShukoEigyosho_Leave
        ///出庫営業所コードから離れた時
        ///</summary>
        private void lblsetShukoEigyosho_Leave(object sender, EventArgs e)
        {
            //出庫営業所コードがない場合
            if (lblsetShukoEigyosho.codeTxt.blIsEmpty() == false)
            {
                return;
            }

            //グリッドの表示
            setGridData();
        }

        ///<summary>
        ///gridShuko_DoubleClick
        ///グリッドでダブルクリックした場合
        ///</summary>
        private void gridShuko_DoubleClick(object sender, EventArgs e)
        {
            getSelectItem();
        }

        ///<summary>
        ///setSelectItem
        ///データグリッドビュー上での共通処理
        ///</summary>
        private void getSelectItem()
        {
            //選択したものが空の場合
            if (gridShuko.Rows.Count == 0)
            {
                return;
            }

            //選択されたデータの"伝票番号"を取得
            txtDenpyoNo.Text = (string)gridShuko.CurrentRow.Cells["伝票番号"].Value.ToString();

            //出庫依頼データの表示
            setShukoData();
        }

        ///<summary>
        ///setShukoData
        ///出庫依頼データの表示
        ///</summary>
        private void setShukoData()
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //前後の空白を取り除く
            txtDenpyoNo.Text = txtDenpyoNo.Text.Trim();

            //伝票番号がない場合
            if (txtDenpyoNo.blIsEmpty() == false)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            A0160_ShukoIraiInput_B shukoiraiB = new A0160_ShukoIraiInput_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = shukoiraiB.getShukoData(txtDenpyoNo.Text);

                //１件以上データがある場合
                if (dtSetCd.Rows.Count > 0)
                {
                    txtYMD.Text = DateTime.Parse(dtSetCd.Rows[0]["依頼年月日"].ToString()).ToString("yyyy/MM/dd");
                    lblsetTantosha.CodeTxtText = dtSetCd.Rows[0]["担当者コード"].ToString();
                    lblsetShukoEigyosho.CodeTxtText = dtSetCd.Rows[0]["出庫倉庫"].ToString();
                    lblsetShukoEigyosho.chkTxtEigyousho();
                    lblsetDaibunrui.CodeTxtText = dtSetCd.Rows[0]["大分類コード"].ToString();
                    lblsetDaibunrui.chkTxtDaibunrui();
                    lblsetChubunrui.CodeTxtText = dtSetCd.Rows[0]["中分類コード"].ToString();
                    lblsetChubunrui.chkTxtChubunrui(lblsetDaibunrui.CodeTxtText);
                    lblsetMaker.CodeTxtText = dtSetCd.Rows[0]["メーカーコード"].ToString();
                    lblsetMaker.chkTxtMaker();
                    txtC1.Text = dtSetCd.Rows[0]["Ｃ１"].ToString();
                    txtC2.Text = dtSetCd.Rows[0]["Ｃ２"].ToString();
                    txtC3.Text = dtSetCd.Rows[0]["Ｃ３"].ToString();
                    txtC4.Text = dtSetCd.Rows[0]["Ｃ４"].ToString();
                    txtC5.Text = dtSetCd.Rows[0]["Ｃ５"].ToString();
                    txtC6.Text = dtSetCd.Rows[0]["Ｃ６"].ToString();
                    txtSu.Text = dtSetCd.Rows[0]["数量"].ToString();
                    txtSu.Text = decimal.Parse(txtSu.Text).ToString("#,0.00");
                    txtSu.updPriceMethod();
                    txtTanka.Text = dtSetCd.Rows[0]["単価"].ToString();
                    txtTanka.Text = decimal.Parse(txtTanka.Text).ToString("#,0.00");
                    txtTanka.updPriceMethod();
                    lblsetEigyosho.CodeTxtText = dtSetCd.Rows[0]["営業所コード"].ToString();
                    txtShohinCd.Text = dtSetCd.Rows[0]["商品コード"].ToString();

                    //商品コードが88888の場合
                    if (txtShohinCd.Text == "88888")
                    {
                        //品名にＣ１の情報を入れる
                        txtHinmei.Text = txtC1.Text;
                    }
                    else
                    {
                        //各データを入れる
                        txtC1.Text = dtSetCd.Rows[0]["Ｃ１"].ToString().Trim();
                        txtC2.Text = dtSetCd.Rows[0]["Ｃ２"].ToString().Trim();
                        txtC3.Text = dtSetCd.Rows[0]["Ｃ３"].ToString().Trim();
                        txtC4.Text = dtSetCd.Rows[0]["Ｃ４"].ToString().Trim();
                        txtC5.Text = dtSetCd.Rows[0]["Ｃ５"].ToString().Trim();
                        txtC6.Text = dtSetCd.Rows[0]["Ｃ６"].ToString().Trim();

                        txtHinmei.Text = txtC1.Text + txtC2.Text + txtC3.Text + txtC4.Text + txtC5.Text + txtC6.Text;
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
            }
        }

        ///<summary>
        ///setTantoCdEigyoCd
        ///担当者コードと営業所コードを取得、記入
        ///</summary>
        private void setTantoCdEigyoCd()
        {
            //担当者データを入れる用
            DataTable dtTantoshaCd = new DataTable();

            //ビジネス層のインスタンス生成
            A0160_ShukoIraiInput_B shukoiraiB = new A0160_ShukoIraiInput_B();
            try
            {
                //ログインＩＤから担当者データを取り出す
                dtTantoshaCd = shukoiraiB.getTantoshaCdSetUserID(SystemInformation.UserName);

                //担当者データがある場合
                if (dtTantoshaCd.Rows.Count > 0)
                {
                    //一行目にデータがない場合
                    if (dtTantoshaCd.Rows[0][0].ToString() == "")
                    {
                        return;
                    }
                }

                //担当者コードを記入
                lblsetTantosha.CodeTxtText = dtTantoshaCd.Rows[0]["担当者コード"].ToString();
                //担当者コードをチェック
                lblsetTantosha.chkTxtTantosha();

                //営業所コードを記入
                lblsetEigyosho.CodeTxtText = dtTantoshaCd.Rows[0]["営業所コード"].ToString();
                //営業所コードをチェック
                lblsetEigyosho.chkTxtEigyousho();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        ///<summary>
        ///txtDenpyoNo_Leave
        ///伝票番号から離れた時
        ///</summary>
        private void txtDenpyoNo_Leave(object sender, EventArgs e)
        {
            //伝票番号がない場合
            if(txtDenpyoNo.blIsEmpty() == false)
            {
                return;
            }

            //出庫依頼データの表示
            setShukoData();

            //グリッドの表示
            setGridData();
        }

        ///<summary>
        ///judtxtShukoKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtShukoKeyUp(object sender, KeyEventArgs e)
        {
            //フォーカスの確保
            Control cActiveBefore = this.ActiveControl;

            //ベーステキストのインスタンス生成
            BaseText basetext = new BaseText();
            //キーアップされた時の判断処理
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
