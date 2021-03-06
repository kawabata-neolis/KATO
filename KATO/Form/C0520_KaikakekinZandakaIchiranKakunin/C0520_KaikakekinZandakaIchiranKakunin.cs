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
using KATO.Business.C0520_KaikakekinZandakaIchiranKakunin_B;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.C0520_KaikakekinZandakaIchiranKakunin
{
    ///<summary>
    ///C0520_KaikakekinZandakaIchiranKakunin
    ///買掛金残高一覧確認
    ///作成者：大河内
    ///作成日：2018/01/30
    ///更新者：大河内
    ///更新日：2018/01/30
    ///</summary>
    public partial class C0520_KaikakekinZandakaIchiranKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///C0520_KaikakekinZandakaIchiranKakunin
        ///フォームの初期設定
        ///</summary>
        public C0520_KaikakekinZandakaIchiranKakunin(Control c)
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
            this.Left = c.Left;
            this.Top = c.Top;
        }

        ///<summary>
        ///C0520_KaikakekinZandakaIchiranKakunin_Load
        ///画面レイアウト設定
        ///</summary>
        private void C0520_KaikakekinZandakaIchiranKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "買掛金残高一覧確認";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF10.Text = "Excel出力";
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            //書き込み可能
            lblsetTokuisakiCdclose.codeTxt.ReadOnly = false;
            //タブ移動する
            lblsetTokuisakiCdclose.TabStop = true;

            ////パワーユーザーの場合
            //if ("1".Equals(this.etsuranFlg))
            //{
            //    //書き込み可能
            //    lblsetTokuisakiCdclose.codeTxt.ReadOnly = false;
            //    //タブ移動する
            //    lblsetTokuisakiCdclose.TabStop = true;
            //}
            //else
            //{
            //    //読み取り専用
            //    lblsetTokuisakiCdclose.codeTxt.ReadOnly = true;
            //    //タブ移動しない
            //    lblsetTokuisakiCdclose.TabStop = false;
            //}

            lblsetTokuisakiCdopen.SearchOn = false;
            lblsetTokuisakiCdclose.SearchOn = false;

            //ﾗｼﾞｵﾎﾞﾀﾝの初期値
            radShuturyoku.radbtn1.Checked = true;

            //DataGridViewの初期設定
            SetUpGrid();
        }

        ///<summary>
        ///SetUpGrid
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //データをバインド
            DataGridViewTextBoxColumn Code = new DataGridViewTextBoxColumn();
            Code.DataPropertyName = "コード";
            Code.Name = "コード";
            Code.HeaderText = "コード";

            DataGridViewTextBoxColumn TokuiName = new DataGridViewTextBoxColumn();
            TokuiName.DataPropertyName = "得意先名";
            TokuiName.Name = "得意先名";
            TokuiName.HeaderText = "得意先名";

            DataGridViewTextBoxColumn YM = new DataGridViewTextBoxColumn();
            YM.DataPropertyName = "年月";
            YM.Name = "年月";
            YM.HeaderText = "年月";

            DataGridViewTextBoxColumn ZengetuKaikakeZan = new DataGridViewTextBoxColumn();
            ZengetuKaikakeZan.DataPropertyName = "前月買掛残";
            ZengetuKaikakeZan.Name = "前月買掛残";
            ZengetuKaikakeZan.HeaderText = "前月買掛残";

            DataGridViewTextBoxColumn ShiharaiGenkin = new DataGridViewTextBoxColumn();
            ShiharaiGenkin.DataPropertyName = "支払現金";
            ShiharaiGenkin.Name = "支払現金";
            ShiharaiGenkin.HeaderText = "支払現金";

            DataGridViewTextBoxColumn ShiharaiKogitte = new DataGridViewTextBoxColumn();
            ShiharaiKogitte.DataPropertyName = "支払小切手";
            ShiharaiKogitte.Name = "支払小切手";
            ShiharaiKogitte.HeaderText = "支払小切手";

            DataGridViewTextBoxColumn ShiharaiHurikomi = new DataGridViewTextBoxColumn();
            ShiharaiHurikomi.DataPropertyName = "支払振込";
            ShiharaiHurikomi.Name = "支払振込";
            ShiharaiHurikomi.HeaderText = "支払振込";

            DataGridViewTextBoxColumn ShiharaiTegata = new DataGridViewTextBoxColumn();
            ShiharaiTegata.DataPropertyName = "支払手形";
            ShiharaiTegata.Name = "支払手形";
            ShiharaiTegata.HeaderText = "支払手形";

            DataGridViewTextBoxColumn ShiharaiSosai = new DataGridViewTextBoxColumn();
            ShiharaiSosai.DataPropertyName = "支払相殺";
            ShiharaiSosai.Name = "支払相殺";
            ShiharaiSosai.HeaderText = "支払相殺";

            DataGridViewTextBoxColumn ShiharaiTesuryo = new DataGridViewTextBoxColumn();
            ShiharaiTesuryo.DataPropertyName = "支払手数料";
            ShiharaiTesuryo.Name = "支払手数料";
            ShiharaiTesuryo.HeaderText = "支払手数料";

            DataGridViewTextBoxColumn ShiharaiSonota = new DataGridViewTextBoxColumn();
            ShiharaiSonota.DataPropertyName = "支払その他";
            ShiharaiSonota.Name = "支払その他";
            ShiharaiSonota.HeaderText = "支払その他";

            DataGridViewTextBoxColumn Kurikosizan = new DataGridViewTextBoxColumn();
            Kurikosizan.DataPropertyName = "繰越残高";
            Kurikosizan.Name = "繰越残高";
            Kurikosizan.HeaderText = "繰越残高";

            DataGridViewTextBoxColumn TougetsuShire = new DataGridViewTextBoxColumn();
            TougetsuShire.DataPropertyName = "当月仕入高";
            TougetsuShire.Name = "当月仕入高";
            TougetsuShire.HeaderText = "当月仕入高";

            DataGridViewTextBoxColumn TougetsuShohizei = new DataGridViewTextBoxColumn();
            TougetsuShohizei.DataPropertyName = "当月消費税";
            TougetsuShohizei.Name = "当月消費税";
            TougetsuShohizei.HeaderText = "当月消費税";

            DataGridViewTextBoxColumn TougetsuZan = new DataGridViewTextBoxColumn();
            TougetsuZan.DataPropertyName = "当月残高";
            TougetsuZan.Name = "当月残高";
            TougetsuZan.HeaderText = "当月残高";

            DataGridViewTextBoxColumn Zeiku = new DataGridViewTextBoxColumn();
            Zeiku.DataPropertyName = "税区";
            Zeiku.Name = "税区";
            Zeiku.HeaderText = "税区";

            DataGridViewTextBoxColumn Hurigana = new DataGridViewTextBoxColumn();
            Hurigana.DataPropertyName = "フリガナ";
            Hurigana.Name = "フリガナ";
            Hurigana.HeaderText = "フリガナ";

            //個々の幅、文章の寄せ
            setColumngridTokuisaki(Code, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumngridTokuisaki(TokuiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 400);
            setColumngridTokuisaki(YM, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 70);
            setColumngridTokuisaki(ZengetuKaikakeZan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(ShiharaiGenkin, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(ShiharaiKogitte, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(ShiharaiHurikomi, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(ShiharaiTegata, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(ShiharaiSosai, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(ShiharaiTesuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(ShiharaiSonota, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(Kurikosizan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(TougetsuShire, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(TougetsuShohizei, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(TougetsuZan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(Zeiku, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumngridTokuisaki(Hurigana, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);

            //非表示項目
            gridTokuisaki.Columns["税区"].Visible = false;
            gridTokuisaki.Columns["フリガナ"].Visible = false;
        }

        ///<summary>
        ///setColumngridTokuisaki
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumngridTokuisaki(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridTokuisaki.Columns.Add(col);
            if (gridTokuisaki.Columns[col.Name] != null)
            {
                gridTokuisaki.Columns[col.Name].Width = intLen;
                gridTokuisaki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridTokuisaki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridTokuisaki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///C0520_KaikakekinZandakaIchiranKakunin_KeyDown
        ///キー入力判定
        ///</summary>
        private void C0520_KaikakekinZandakaIchiranKakunin_KeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setTokuisakiView();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
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
                    logger.Info(LogUtil.getMessage(this._Title, "Excel出力"));
                    exportXls();
                    break;
                case Keys.F11:
                    //印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printUrikakeZan();
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
        ///judBtnClick
        ///ボタンの反応
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 表示
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setTokuisakiView();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F10: // Excel出力
                    logger.Info(LogUtil.getMessage(this._Title, "Excel出力"));
                    exportXls();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printUrikakeZan();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///delText
        ///テキストボックス等の入力情報を白紙にする
        ///</summary>
        private void delText()
        {
            this.delFormClear(this, gridTokuisaki);
            //初期値にフォーカス
            lblsetTokuisakiCdopen.Focus();
        }

        ///<summary>
        ///judtxtKaikakeZanKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtKaikakeZanKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///setTokuisakiView
        ///得意先データの表示
        ///</summary>
        private void setTokuisakiView()
        {
            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //空チェック（開始得意先コード）
            if (StringUtl.blIsEmpty(lblsetTokuisakiCdopen.CodeTxtText) == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                lblsetTokuisakiCdopen.Focus();
                return;
            }

            //空チェック（終了得意先コード）
            if (StringUtl.blIsEmpty(lblsetTokuisakiCdclose.CodeTxtText) == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                lblsetTokuisakiCdclose.Focus();
                return;
            }

            ////パワーユーザーの場合
            //if ("1".Equals(this.etsuranFlg))
            //{
            //    //空チェック（終了得意先コード）
            //    if (StringUtl.blIsEmpty(lblsetTokuisakiCdclose.CodeTxtText) == false)
            //    {
            //        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
            //        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
            //        basemessagebox.ShowDialog();

            //        lblsetTokuisakiCdclose.Focus();
            //        return;
            //    }
            //}

            //日付フォーマット生成、およびチェック
            strYMDformat = txtYMopen.chkDateYMDataFormat(txtYMopen.Text);

            //開始年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYMopen.Focus();

                return;
            }
            else
            {
                txtYMopen.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtYMopen.chkDateYMDataFormat(txtYMclose.Text);

            //開始年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYMclose.Focus();

                return;
            }
            else
            {
                txtYMclose.Text = strYMDformat;
            }

            //年月日が空の場合
            if (txtYMopen.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtYMopen.Focus();
                return;

            }

            //年月日が空の場合
            if (txtYMclose.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtYMclose.Focus();
                return;

            }

            //検索開始得意先コードのチェック
            if (lblsetTokuisakiCdopen.chkTxtTorihikisaki() == true)
            {
                lblsetTokuisakiCdopen.Focus();

                return;
            }

            //検索終了得意先コードのチェック
            if (lblsetTokuisakiCdclose.chkTxtTorihikisaki() == true)
            {
                lblsetTokuisakiCdclose.Focus();

                return;
            }

            DataTable dtGridViewTokusaki = new DataTable();

            List<string> lstStringViewData = new List<string>();

            lstStringViewData.Add(lblsetTokuisakiCdopen.CodeTxtText);

            lstStringViewData.Add(lblsetTokuisakiCdclose.CodeTxtText);

            ////パワーユーザーの場合
            //if ("1".Equals(this.etsuranFlg))
            //{
            //    lstStringViewData.Add(lblsetTokuisakiCdclose.CodeTxtText);
            //}
            //else
            //{
            //    lstStringViewData.Add(lblsetTokuisakiCdopen.CodeTxtText);
            //}

            string strShuturyoku = "";

            //出力順のラジオボタン判定
            if (radShuturyoku.radbtn0.Checked == true)
            {
                strShuturyoku = "Tokuisaki";
            }
            else
            {
                strShuturyoku = "Hurigana";
            }

            lstStringViewData.Add(DateTime.Parse(txtYMopen.Text).ToString("yyyy/MM/dd"));
            lstStringViewData.Add(DateTime.Parse(txtYMclose.Text).ToString("yyyy/MM/dd"));
            lstStringViewData.Add(strShuturyoku);

            C0520_KaikakekinZandakaIchiranKakunin_B kaikakekakuninB = new C0520_KaikakekinZandakaIchiranKakunin_B();
            try
            {
                //待機状態
                Cursor.Current = Cursors.WaitCursor;

                dtGridViewTokusaki = kaikakekakuninB.setGridTokusaiki(lstStringViewData);

                //テーブルがある場合
                if (dtGridViewTokusaki.Rows.Count > 0)
                {
                    //グリッドビューの表示
                    gridTokuisaki.DataSource = dtGridViewTokusaki;

                    //元に戻す
                    Cursor.Current = Cursors.Default;

                    gridTokuisaki.Focus();
                }
                else
                {
                    //元に戻す
                    Cursor.Current = Cursors.Default;

                    //データがないメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    //グリッドを空にする
                    gridTokuisaki.DataSource = "";
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
        ///printUrikakeZan
        ///印刷ダイアログ
        ///</summary>
        private void printUrikakeZan()
        {
            //グリッドに表示されていない場合
            if (gridTokuisaki.Rows.Count == 0)
            {
                return;
            }

            //PDF作成後の入れ物
            string strFile = "";

            //データの取り出し用
            DataTable dtPrintData = new DataTable();

            //列情報を取得
            DataGridViewColumnCollection cols = gridTokuisaki.Columns;

            //行情報を取得
            DataGridViewRowCollection rows = gridTokuisaki.Rows;

            //取引先経理情報登録時の情報
            List<string> lstTorihiki = new List<string>();

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            this.Cursor = Cursors.WaitCursor;

            //空チェック（開始得意先コード）
            if (StringUtl.blIsEmpty(lblsetTokuisakiCdopen.CodeTxtText) == false)
            {
                this.Cursor = Cursors.Default;

                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                lblsetTokuisakiCdopen.Focus();
                return;
            }

            //空チェック（終了得意先コード）
            if (StringUtl.blIsEmpty(lblsetTokuisakiCdclose.CodeTxtText) == false)
            {
                this.Cursor = Cursors.Default;

                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                lblsetTokuisakiCdclose.Focus();
                return;
            }

            ////パワーユーザーの場合
            //if ("1".Equals(this.etsuranFlg))
            //{
            //    //空チェック（終了得意先コード）
            //    if (StringUtl.blIsEmpty(lblsetTokuisakiCdclose.CodeTxtText) == false)
            //    {
            //        this.Cursor = Cursors.Default;

            //        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
            //        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
            //        basemessagebox.ShowDialog();

            //        lblsetTokuisakiCdclose.Focus();
            //        return;
            //    }
            //}

            //日付フォーマット生成、およびチェック
            strYMDformat = txtYMopen.chkDateYMDataFormat(txtYMopen.Text);

            //開始年月日の日付チェック
            if (strYMDformat == "")
            {
                this.Cursor = Cursors.Default;

                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYMopen.Focus();

                return;
            }
            else
            {
                txtYMopen.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtYMclose.chkDateYMDataFormat(txtYMclose.Text);

            //終了年月日の日付チェック
            if (strYMDformat == "")
            {
                this.Cursor = Cursors.Default;

                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYMclose.Focus();

                return;
            }
            else
            {
                txtYMclose.Text = strYMDformat;
            }

            this.Cursor = Cursors.Default;

            //年月日が空の場合
            if (txtYMopen.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtYMopen.Focus();
                return;

            }

            //年月日が空の場合
            if (txtYMclose.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtYMclose.Focus();
                return;

            }

            //検索開始得意先コードのチェック
            if (lblsetTokuisakiCdopen.chkTxtTorihikisaki() == true)
            {
                lblsetTokuisakiCdopen.Focus();

                return;
            }

            //検索終了得意先コードのチェック
            if (lblsetTokuisakiCdclose.chkTxtTorihikisaki() == true)
            {
                lblsetTokuisakiCdclose.Focus();

                return;
            }

            ////パワーユーザーの場合
            //if ("1".Equals(this.etsuranFlg))
            //{
            //    //スルー
            //}
            //else
            //{
            //    //データチェック（年月度が同じの場合）
            //    if (txtYMopen.Text == txtYMclose.Text)
            //    {
            //        //一か月単位は出来ないメッセージ（OK）
            //        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "１ケ月単位は指定できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
            //        basemessagebox.ShowDialog();
            //        txtYMopen.Focus();
            //        return;
            //    }
            //}

            this.Cursor = Cursors.WaitCursor;

            DataTable dtGridViewTokusaki = new DataTable();

            List<string> lstStringViewData = new List<string>();

            lstStringViewData.Add(lblsetTokuisakiCdopen.CodeTxtText);

            lstStringViewData.Add(lblsetTokuisakiCdclose.CodeTxtText);

            ////パワーユーザーの場合
            //if ("1".Equals(this.etsuranFlg))
            //{
            //    lstStringViewData.Add(lblsetTokuisakiCdclose.CodeTxtText);
            //}
            //else
            //{
            //    lstStringViewData.Add(lblsetTokuisakiCdopen.CodeTxtText);
            //}

            string strShuturyoku = "";

            //出力順のラジオボタン判定
            if (radShuturyoku.radbtn0.Checked == true)
            {
                strShuturyoku = "Tokuisaki";
            }
            else
            {
                strShuturyoku = "Hurigana";
            }

            lstStringViewData.Add(DateTime.Parse(txtYMopen.Text).ToString("yyyy/MM/dd"));
            lstStringViewData.Add(DateTime.Parse(txtYMclose.Text).ToString("yyyy/MM/dd"));
            lstStringViewData.Add(strShuturyoku);

            C0520_KaikakekinZandakaIchiranKakunin_B kaikakekakuninB = new C0520_KaikakekinZandakaIchiranKakunin_B();
            try
            {
                dtPrintData = kaikakekakuninB.getPrintData(lstStringViewData);

                this.Cursor = Cursors.Default;

                //初期値
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, YOKO);

                pf.ShowDialog(this);

                //プレビューの場合
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    //現在時間と使用者ＰＣユーザー名を確保
                    lstTorihiki.Add(DateTime.Now.ToString());
                    lstTorihiki.Add(SystemInformation.UserName);

                    this.Cursor = Cursors.WaitCursor;

                    //結果セットをレコードセットに
                    strFile = kaikakekakuninB.dbToPdf(dtPrintData,lstTorihiki);

                    this.Cursor = Cursors.Default;

                    //印刷できなかった場合
                    if (strFile == "")
                    {
                        //印刷時エラーメッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, "印刷", "印刷時エラーです。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        return;
                    }

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    //現在時間と使用者ＰＣユーザー名を確保
                    lstTorihiki.Add(DateTime.Now.ToString());
                    lstTorihiki.Add(SystemInformation.UserName);

                    this.Cursor = Cursors.WaitCursor;

                    //結果セットをレコードセットに
                    strFile = kaikakekakuninB.dbToPdf(dtPrintData, lstTorihiki);

                    this.Cursor = Cursors.Default;

                    //印刷できなかった場合
                    if (strFile == "")
                    {
                        //印刷時エラーメッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, "印刷", "印刷時エラーです。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        return;
                    }

                    // 一括印刷
                    pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///     F10：Excel出力
        ///</summary>
        private void exportXls()
        {
            // SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();
            // ファイル名の指定
            sfd.FileName = "買掛金残高一覧確認_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xlsx";
            // デフォルトパス取得（デスクトップ）
            string Init_dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = Init_dir;
            // ファイルフィルタの設定
            sfd.Filter = "すべてのファイル(*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // グリッドに表示されていない場合
                if (gridTokuisaki.Rows.Count == 0)
                {
                    return;
                }

                //データの取り出し用
                DataTable dtPrintData = new DataTable();

                //列情報を取得
                DataGridViewColumnCollection cols = gridTokuisaki.Columns;

                //行情報を取得
                DataGridViewRowCollection rows = gridTokuisaki.Rows;

                //取引先経理情報登録時の情報
                List<string> lstTorihiki = new List<string>();

                //年月日の日付フォーマット後を入れる用
                string strYMDformat = "";

                this.Cursor = Cursors.WaitCursor;

                //空チェック（開始得意先コード）
                if (StringUtl.blIsEmpty(lblsetTokuisakiCdopen.CodeTxtText) == false)
                {
                    this.Cursor = Cursors.Default;

                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    lblsetTokuisakiCdopen.Focus();
                    return;
                }

                //空チェック（終了得意先コード）
                if (StringUtl.blIsEmpty(lblsetTokuisakiCdclose.CodeTxtText) == false)
                {
                    this.Cursor = Cursors.Default;

                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    lblsetTokuisakiCdclose.Focus();
                    return;
                }

                //日付フォーマット生成、およびチェック
                strYMDformat = txtYMopen.chkDateYMDataFormat(txtYMopen.Text);

                //開始年月日の日付チェック
                if (strYMDformat == "")
                {
                    this.Cursor = Cursors.Default;

                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtYMopen.Focus();

                    return;
                }
                else
                {
                    txtYMopen.Text = strYMDformat;
                }

                //初期化
                strYMDformat = "";

                //日付フォーマット生成、およびチェック
                strYMDformat = txtYMclose.chkDateYMDataFormat(txtYMclose.Text);

                //終了年月日の日付チェック
                if (strYMDformat == "")
                {
                    this.Cursor = Cursors.Default;

                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtYMclose.Focus();

                    return;
                }
                else
                {
                    txtYMclose.Text = strYMDformat;
                }

                this.Cursor = Cursors.Default;

                //年月日が空の場合
                if (txtYMopen.blIsEmpty() == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    txtYMopen.Focus();
                    return;

                }

                //年月日が空の場合
                if (txtYMclose.blIsEmpty() == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    txtYMclose.Focus();
                    return;

                }

                //検索開始得意先コードのチェック
                if (lblsetTokuisakiCdopen.chkTxtTorihikisaki() == true)
                {
                    lblsetTokuisakiCdopen.Focus();

                    return;
                }

                //検索終了得意先コードのチェック
                if (lblsetTokuisakiCdclose.chkTxtTorihikisaki() == true)
                {
                    lblsetTokuisakiCdclose.Focus();

                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                DataTable dtGridViewTokusaki = new DataTable();

                List<string> lstStringViewData = new List<string>();

                lstStringViewData.Add(lblsetTokuisakiCdopen.CodeTxtText);

                lstStringViewData.Add(lblsetTokuisakiCdclose.CodeTxtText);

                string strShuturyoku = "";

                //出力順のラジオボタン判定
                if (radShuturyoku.radbtn0.Checked == true)
                {
                    strShuturyoku = "Tokuisaki";
                }
                else
                {
                    strShuturyoku = "Hurigana";
                }

                lstStringViewData.Add(DateTime.Parse(txtYMopen.Text).ToString("yyyy/MM/dd"));
                lstStringViewData.Add(DateTime.Parse(txtYMclose.Text).ToString("yyyy/MM/dd"));
                lstStringViewData.Add(strShuturyoku);

                C0520_KaikakekinZandakaIchiranKakunin_B kaikakekakuninB = new C0520_KaikakekinZandakaIchiranKakunin_B();

                try
                {
                    DataTable dtXlsData = kaikakekakuninB.getPrintData(lstStringViewData);

                    if (dtXlsData.Rows.Count > 0)
                    {
                        CreatePdf cpdf = new CreatePdf();

                        // 出力するヘッダを設定
                        string[] header =
                        {
                            "コード",
                            "得意先名",
                            "年月",
                            "前月買掛残",
                            "支払現金",
                            "支払小切手",
                            "支払振込",
                            "支払手形",
                            "支払相殺",
                            "支払手数料",
                            "支払その他",
                            "繰越残高",
                            "当月仕入高",
                            "当月消費税",
                            "当月残高",
                            "税区",
                        };

                        // Linqで出力対象の項目をSelect
                        // カラム名は以下のようにつける(カラム名でフォーマットを判断するため)
                        // 金額関係：＊＊＊kingaku
                        // 単価関係：＊＊＊tanka
                        // 原価：＊＊＊genka
                        // 数量：＊＊＊suryo
                        var outDat = dtXlsData.AsEnumerable()
                            .Select(dat => new
                            {
                                code = dat["コード"],
                                tokuisakiName = dat["得意先名"],
                                YM = dat["年月"],
                                zenkaikakezanKingaku = dat["前月買掛残"],
                                siharaiGenkinKingaku = dat["支払現金"],
                                siharaiKogiteKingaku = dat["支払小切手"],
                                siharaiFurikomiKingaku = dat["支払振込"],
                                siharaiTegataKingaku = dat["支払手形"],
                                siharaiSosaiKingaku = dat["支払相殺"],
                                siharaiTesuryoKingaku = dat["支払手数料"],
                                siharaiSonotaKingaku = dat["支払その他"],
                                kurikosizanKingaku = dat["繰越残高"],
                                togetuUriageKingaku = dat["当月仕入高"],
                                togetuZeiKingaku = dat["当月消費税"],
                                togetuZanKingaku = dat["当月残高"],
                                zeiku = dat["税区"]
                            }).ToList();

                        // listをDataTableに変換
                        DataTable dtKaikakeZan = cpdf.ConvertToDataTable(outDat);

                        string outFile = sfd.FileName;

                        cpdf.DtToXls(dtKaikakeZan, "買掛金残高一覧確認", outFile, 3, 1, header);

                        this.Cursor = Cursors.Default;

                        // メッセージボックスの処理、Excel作成完了の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "Excelファイルを作成しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessagebox.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;

                    //データロギング
                    new CommonException(ex);
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }
        }
    }
}
