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
using KATO.Business.C0500_UrikakekinZandakaIchiranKakunin_B;
using static KATO.Common.Util.CommonTeisu;


namespace KATO.Form.C0500_UrikakekinZandakaIchiranKakunin
{
    ///<summary>
    ///C0500_UrikakekinZandakaIchiranKakunin
    ///売掛金残高一覧確認
    ///作成者：大河内
    ///作成日：2018/01/30
    ///更新者：大河内
    ///更新日：2018/01/30
    ///</summary>
    public partial class C0500_UrikakekinZandakaIchiranKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        ///<summary>
        ///C1500_UrikakekinanKakunin
        ///フォームの初期設定
        ///</summary>
        public C0500_UrikakekinZandakaIchiranKakunin(Control c)
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
        ///C1500_UrikakekinanKakunin_Load
        ///画面レイアウト設定
        ///</summary>
        private void C1500_UrikakekinanKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "売掛金残高一覧確認";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            ////本番用
            //パワーユーザーの場合
            if ("1".Equals(this.etsuranFlg))
            {
                //読み取り専用
                lblsetTantoshaCdclose.codeTxt.ReadOnly = false;
                //タブ移動しない
                lblsetTantoshaCdclose.TabStop = true;
            }
            else
            {
                //読み取り専用
                lblsetTantoshaCdclose.codeTxt.ReadOnly = true;
                //タブ移動しない
                lblsetTantoshaCdclose.TabStop = false;
            }
            

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

            DataGridViewTextBoxColumn ZengetuUrikakeZan = new DataGridViewTextBoxColumn();
            ZengetuUrikakeZan.DataPropertyName = "前月売掛残";
            ZengetuUrikakeZan.Name = "前月売掛残";
            ZengetuUrikakeZan.HeaderText = "前月売掛残";

            DataGridViewTextBoxColumn NyukinGenkin = new DataGridViewTextBoxColumn();
            NyukinGenkin.DataPropertyName = "入金現金";
            NyukinGenkin.Name = "入金現金";
            NyukinGenkin.HeaderText = "入金現金";

            DataGridViewTextBoxColumn NyukinKogitte = new DataGridViewTextBoxColumn();
            NyukinKogitte.DataPropertyName = "入金小切手";
            NyukinKogitte.Name = "入金小切手";
            NyukinKogitte.HeaderText = "入金小切手";

            DataGridViewTextBoxColumn NyukinHurikomi = new DataGridViewTextBoxColumn();
            NyukinHurikomi.DataPropertyName = "入金振込";
            NyukinHurikomi.Name = "入金振込";
            NyukinHurikomi.HeaderText = "入金振込";

            DataGridViewTextBoxColumn NyukinTegata = new DataGridViewTextBoxColumn();
            NyukinTegata.DataPropertyName = "入金手形";
            NyukinTegata.Name = "入金手形";
            NyukinTegata.HeaderText = "入金手形";

            DataGridViewTextBoxColumn NyukinSosai = new DataGridViewTextBoxColumn();
            NyukinSosai.DataPropertyName = "入金相殺";
            NyukinSosai.Name = "入金相殺";
            NyukinSosai.HeaderText = "入金相殺";

            DataGridViewTextBoxColumn NyukinTesuryo = new DataGridViewTextBoxColumn();
            NyukinTesuryo.DataPropertyName = "入金手数料";
            NyukinTesuryo.Name = "入金手数料";
            NyukinTesuryo.HeaderText = "入金手数料";

            DataGridViewTextBoxColumn NyukinSonota = new DataGridViewTextBoxColumn();
            NyukinSonota.DataPropertyName = "入金その他";
            NyukinSonota.Name = "入金その他";
            NyukinSonota.HeaderText = "入金その他";

            DataGridViewTextBoxColumn Kurikosizan = new DataGridViewTextBoxColumn();
            Kurikosizan.DataPropertyName = "繰越残高";
            Kurikosizan.Name = "繰越残高";
            Kurikosizan.HeaderText = "繰越残高";

            DataGridViewTextBoxColumn TougetsuUriage = new DataGridViewTextBoxColumn();
            TougetsuUriage.DataPropertyName = "当月売上高";
            TougetsuUriage.Name = "当月売上高";
            TougetsuUriage.HeaderText = "当月売上高";

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
            setColumngridTokuisaki(ZengetuUrikakeZan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(NyukinGenkin, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(NyukinKogitte, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(NyukinHurikomi, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(NyukinTegata, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(NyukinSosai, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(NyukinTesuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(NyukinSonota, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(Kurikosizan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
            setColumngridTokuisaki(TougetsuUriage, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 112);
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
        ///C0500_UrikakekinanKakunin_KeyDown
        ///キー入力判定
        ///</summary>
        private void C0500_UrikakekinanKakunin_KeyDown(object sender, KeyEventArgs e)
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
            lblsetTantoshaCdopen.Focus();
        }

        ///<summary>
        ///judtxtUrikakeZanKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtUrikakeZanKeyUp(object sender, KeyEventArgs e)
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
            //パワーユーザーの場合
            if ("1".Equals(this.etsuranFlg))
            {
                //空チェック（開始得意先コード）
                if (StringUtl.blIsEmpty(lblsetTantoshaCdopen.CodeTxtText) == false)
                {
                    lblsetTantoshaCdopen.Focus();
                    return;
                }
                // データフォーマットチェック（開始得意先コード）
                if (lblsetTantoshaCdopen.chkTxtTorihikisaki())
                {
                    return;
                }
                //空チェック（終了得意先コード）
                if (StringUtl.blIsEmpty(lblsetTantoshaCdclose.CodeTxtText) == false)
                {
                    lblsetTantoshaCdopen.Focus();
                    return;
                }
                // データフォーマットチェック（終了得意先コード）
                if (lblsetTantoshaCdclose.chkTxtTorihikisaki())
                {
                    return;
                }
                //データチェック（開始年月日）
                if (StringUtl.JudCalenderCheck(txtYMopen.Text) == false)
                {
                    txtYMopen.Focus();
                    return;
                }

                //データチェック（終了年月日）
                if (StringUtl.JudCalenderCheck(txtYMclose.Text) == false)
                {
                    txtYMclose.Focus();
                    return;
                }
            }
            else
            {
                //空チェック（開始得意先コード）
                if (StringUtl.blIsEmpty(lblsetTantoshaCdopen.CodeTxtText) == false)
                {
                    lblsetTantoshaCdopen.Focus();
                    return;
                }
                // データフォーマットチェック（開始得意先コード）
                if (lblsetTantoshaCdopen.chkTxtTorihikisaki())
                {
                    return;
                }

                //データチェック（開始年月日）
                if (StringUtl.JudCalenderCheck(txtYMopen.Text) == false)
                {
                    txtYMopen.Focus();
                    return;
                }
                //データチェック（終了年月日）
                if (StringUtl.JudCalenderCheck(txtYMclose.Text) == false)
                {
                    txtYMclose.Focus();
                    return;
                }

                //データチェック（年月度が同じの場合）
                if (txtYMopen.Text == txtYMclose.Text)
                {
                    //一か月単位は出来ないメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "１ケ月単位は指定できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    txtYMopen.Focus();
                    return;
                }
            }

            DataTable dtGridViewTokusaki = new DataTable();

            List<string> lstStringViewData = new List<string>();

            lstStringViewData.Add(lblsetTantoshaCdopen.CodeTxtText);
            //パワーユーザーの場合
            if ("1".Equals(this.etsuranFlg))
            {
                lstStringViewData.Add(lblsetTantoshaCdclose.CodeTxtText);
            }
            else
            {
                lstStringViewData.Add(lblsetTantoshaCdopen.CodeTxtText);
            }
            lstStringViewData.Add(DateTime.Parse(txtYMopen.Text).ToString("yyyy/MM/dd"));
            lstStringViewData.Add(DateTime.Parse(txtYMclose.Text).ToString("yyyy/MM/dd"));

            C0500_UrikakekinZandakaIchiranKakunin_B urikakekakuninB = new C0500_UrikakekinZandakaIchiranKakunin_B();
            try
            {
                //待機状態
                Cursor.Current = Cursors.WaitCursor;

                dtGridViewTokusaki = urikakekakuninB.setGridTokusaiki(lstStringViewData);

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

            //データの並び替えと印刷データ用
            DataTable dtPrintDataClone = new DataTable();

            //列情報を取得
            DataGridViewColumnCollection cols = gridTokuisaki.Columns;

            //行情報を取得
            DataGridViewRowCollection rows = gridTokuisaki.Rows;

            //取引先経理情報登録時の情報
            List<string> lstTorihiki = new List<string>();

            foreach (DataGridViewColumn c in cols)
            {
                if (c.ValueType != null)
                {
                    dtPrintData.Columns.Add(c.Name, c.ValueType);
                }
                else
                {
                    dtPrintData.Columns.Add(c.Name);
                }
            }

            //列情報のみをコピーしたデータを作る
            dtPrintDataClone = dtPrintData.Clone();

            foreach (DataGridViewRow r in rows)
            {
                List<object> array = new List<object>();

                foreach (DataGridViewCell cell in r.Cells)
                {
                    array.Add(cell.Value);
                }

                dtPrintData.Rows.Add(array.ToArray());
            }

            //並び替え用
            DataView dvGridViewTokuisaki = new DataView(dtPrintData);

            //出力順が得意先コードの昇順の場合
            if (radShuturyoku.radbtn0.Checked == true)
            {
                dvGridViewTokuisaki.Sort = "コード";
            }
            else
            //出力順がフリガナの昇順の場合
            {
                dvGridViewTokuisaki.Sort = "フリガナ";
            }

            //空にする
            dtPrintData = null;

            //戻す
            foreach (DataRowView drv in dvGridViewTokuisaki)
            {
                //データテーブルに戻す
                dtPrintDataClone.ImportRow(drv.Row);
            }

            C0500_UrikakekinZandakaIchiranKakunin_B urikakekakuninB = new C0500_UrikakekinZandakaIchiranKakunin_B();
            try
            {
                //初期値
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, YOKO);

                pf.ShowDialog(this);

                //プレビューの場合
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    //現在時間と使用者ＰＣユーザー名を確保
                    lstTorihiki.Add(DateTime.Now.ToString());
                    lstTorihiki.Add(SystemInformation.UserName);

                    //結果セットをレコードセットに
                    strFile = urikakekakuninB.dbToPdf(dtPrintDataClone, lstTorihiki);

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

                    //結果セットをレコードセットに
                    strFile = urikakekakuninB.dbToPdf(dtPrintDataClone, lstTorihiki);

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