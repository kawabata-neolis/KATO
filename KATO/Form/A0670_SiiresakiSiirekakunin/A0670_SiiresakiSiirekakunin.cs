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
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.A0670_SiiresakiSiirekakunin;

namespace KATO.Form.A0670_SiiresakiSiirekakunin
{
    ///<summary>
    /// A0670_SiiresakiSiirekakunin
    /// 仕入検収入力＆確認
    ///     作成者：山本
    ///     作成日：2017/12/21
    ///     更新者：大河内
    ///     更新日：2018/02/01
    ///     更新者：山本
    ///     更新日：2019/02/02
    ///</summary>
    public partial class A0670_SiiresakiSiirekakunin : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public A0670_SiiresakiSiirekakunin(Control c)
        {
            InitializeComponent();

            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

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
        ///     フォームロード
        /// </summary>
        private void A0670_SiiresakiSiirekakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "仕入検収入力＆確認";

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF02.Text = "F2:更新";
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF06.Text = "すべて済み";
            this.btnF07.Text = "すべて解除";
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF10.Text = "Excel出力";
            this.btnF12.Text = STR_FUNC_F12;

            // 検索ボタン無効化
            this.btnF09.Enabled = false;

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            // 初期表示
            radOutOrder.radbtn0.Checked = true;
            radDisplay.radbtn0.Checked = true;
            labelSet_Shiresaki.Focus();

            // 伝票年月日の設定
            txtDenpyoYMDEnd.setUp(2);
            DateTime dateYMDStart = DateTime.Parse(txtDenpyoYMDEnd.Text);
            txtDenpyoYMDStart.Text = dateYMDStart.AddMonths(-1).ToString().Substring(0, 8) + "01";

            // 中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            // DataGridViewの初期設定
            SetGrid();
            // 行番号列は非表示
            gridSiireKensyu.Columns[2].Visible = false;

            txtInputTotal.TextAlign = HorizontalAlignment.Right;
            txtKensyuTotal.TextAlign = HorizontalAlignment.Right;
            txtMikensyuTotal.TextAlign = HorizontalAlignment.Right;
        }

        /// <summary>
        ///     フォーム上でのキー押下
        /// </summary>
        private void A0670_SiiresakiSiirekakunin_KeyDown(object sender, KeyEventArgs e)
        {
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
                    this.getSiireKensyu();
                    break;
                case Keys.F2:
                    logger.Info(LogUtil.getMessage(this._Title, "更新実行"));
                    this.UpdateKensyuStatus();
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.clearForm();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    logger.Info(LogUtil.getMessage(this._Title, "すべて済み実行"));
                    chengeKensyuAll("F6");
                    break;
                case Keys.F7:
                    logger.Info(LogUtil.getMessage(this._Title, "すべて解除実行"));
                    chengeKensyuAll("F7");
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
        ///     画面下のファンクションボタン押下時
        /// </summary>
        private void judFuncBtnClick(object sender, EventArgs e)
        {
            // ファンクション機能のボタンの名前を取得・判別
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01:
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.getSiireKensyu();
                    break;
                case STR_BTN_F02:
                    logger.Info(LogUtil.getMessage(this._Title, "更新実行"));
                    this.UpdateKensyuStatus();
                    break;
                case STR_BTN_F04:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.clearForm();
                    break;
                case STR_BTN_F06:
                    logger.Info(LogUtil.getMessage(this._Title, "すべて済み実行"));
                    this.chengeKensyuAll("F6");
                    break;
                case STR_BTN_F07:
                    logger.Info(LogUtil.getMessage(this._Title, "すべて解除実行"));
                    this.chengeKensyuAll("F7");
                    break;
                case STR_BTN_F10:
                    logger.Info(LogUtil.getMessage(this._Title, "Excel出力"));
                    exportXls();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    
                    break;
            }
        }

        /// <summary>
        ///     DataGridView初期設定
        /// </summary>
        private void SetGrid()
        {
            // 列自動生成禁止
            gridSiireKensyu.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn ymd = new DataGridViewTextBoxColumn();
            ymd.DataPropertyName = "伝票年月日";
            ymd.Name = "伝票年月日";
            ymd.HeaderText = "日付";

            DataGridViewTextBoxColumn denNo = new DataGridViewTextBoxColumn();
            denNo.DataPropertyName = "伝票番号";
            denNo.Name = "伝票番号";
            denNo.HeaderText = "伝No.";

            DataGridViewTextBoxColumn rowNo = new DataGridViewTextBoxColumn();
            rowNo.DataPropertyName = "行番号";
            rowNo.Name = "行番号";
            rowNo.HeaderText = "行No.";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー";
            maker.Name = "メーカー";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn kata = new DataGridViewTextBoxColumn();
            kata.DataPropertyName = "品名型式";
            kata.Name = "品名型式";
            kata.HeaderText = "品名・型式";

            DataGridViewTextBoxColumn suryo = new DataGridViewTextBoxColumn();
            suryo.DataPropertyName = "数量";
            suryo.Name = "数量";
            suryo.HeaderText = "数量";

            DataGridViewTextBoxColumn siiretanka = new DataGridViewTextBoxColumn();
            siiretanka.DataPropertyName = "仕入単価";
            siiretanka.Name = "仕入単価";
            siiretanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn siirekingaku = new DataGridViewTextBoxColumn();
            siirekingaku.DataPropertyName = "仕入金額";
            siirekingaku.Name = "仕入金額";
            siirekingaku.HeaderText = "仕入金額";

            DataGridViewTextBoxColumn biko = new DataGridViewTextBoxColumn();
            biko.DataPropertyName = "備考";
            biko.Name = "備考";
            biko.HeaderText = "備  考";

            DataGridViewTextBoxColumn status = new DataGridViewTextBoxColumn();
            status.DataPropertyName = "検収状態";
            status.Name = "検収状態";
            status.HeaderText = "検収";

            // 個々の幅、文字の寄せ
            setColumn(ymd, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(denNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 75);
            setColumn(rowNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 0);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(kata, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 400);
            setColumn(suryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 80);
            setColumn(siiretanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 120);
            setColumn(siirekingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumn(biko, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 250);
            setColumn(status, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 70);
        }

        /// <summary>
        ///     DataGridViewのカラム設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridSiireKensyu.Columns.Add(col);
            if (gridSiireKensyu.Columns[col.Name] != null)
            {
                gridSiireKensyu.Columns[col.Name].Width = intLen;
                gridSiireKensyu.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridSiireKensyu.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridSiireKensyu.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///     仕入検収データ取得
        ///</summary>
        private void getSiireKensyu()
        {
            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //仕入先が空の場合
            if (labelSet_Shiresaki.codeTxt.blIsEmpty() == false)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "仕入先を指定してください ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_Shiresaki.Focus();
                return;
            }

            //仕入先チェック
            if (labelSet_Shiresaki.chkTxtTorihikisaki())
            {
                labelSet_Shiresaki.Focus();
                return;
            }

            //検索開始年月日に記入がある場合
            if (txtDenpyoYMDStart.blIsEmpty())
            {
                //日付フォーマット生成、およびチェック
                strYMDformat = txtDenpyoYMDStart.chkDateDataFormat(txtDenpyoYMDStart.Text);

                //検索開始年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtDenpyoYMDStart.Focus();
                    return;
                }
                else
                {
                    txtDenpyoYMDStart.Text = strYMDformat;
                }
            }

            //検索終了年月日に記入がある場合
            if (txtDenpyoYMDEnd.blIsEmpty())
            {
                //初期化
                strYMDformat = "";

                //日付フォーマット生成、およびチェック
                strYMDformat = txtDenpyoYMDEnd.chkDateDataFormat(txtDenpyoYMDEnd.Text);

                //検索終了年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtDenpyoYMDEnd.Focus();

                    return;
                }
                else
                {
                    txtDenpyoYMDEnd.Text = strYMDformat;
                }
            }

            //大分類チェック
            if (labelSet_Daibunrui.chkTxtDaibunrui())
            {
                labelSet_Daibunrui.Focus();
                return;
            }

            //中分類チェック
            if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
            {
                labelSet_Chubunrui.Focus();
                return;
            }

            //メーカーチェック
            if (labelSet_Maker.chkTxtMaker())
            {
                labelSet_Maker.Focus();
                return;
            }
            
            try
            {
                A0670_SiiresakiSiirekakunin_B siirekakuninB = new A0670_SiiresakiSiirekakunin_B();

                // 検索文字列格納用
                string[] arrSerach = new string[8];
                // 出力順条件取得用
                string[] arrOrder = new string[2];
                // 表示条件取得用
                string[] arrDisplay = new string[3];

                arrSerach[0] = labelSet_Shiresaki.CodeTxtText;  // 仕入先コード
                arrSerach[1] = txtDenpyoYMDStart.Text;          // 伝票年月日start
                arrSerach[2] = txtDenpyoYMDEnd.Text;            // 伝票年月日end
                arrSerach[3] = labelSet_Daibunrui.CodeTxtText;  // 大分類コード
                arrSerach[4] = labelSet_Chubunrui.CodeTxtText;  // 中分類コード
                arrSerach[5] = txtKataban.Text;                 // 品名・型番
                arrSerach[6] = txtBiko.Text;                    // 備考

                arrSerach[7] = labelSet_Maker.CodeTxtText;      // メーカーコード

                arrOrder[0] = radOutOrder.radbtn0.Checked.ToString().ToUpper();   // 出力順　日付・伝票番号順
                arrOrder[1] = radOutOrder.radbtn1.Checked.ToString().ToUpper();   // 出力順　型番・日付順

                arrDisplay[0] = radDisplay.radbtn0.Checked.ToString().ToUpper();  // 表示　すべて
                arrDisplay[1] = radDisplay.radbtn1.Checked.ToString().ToUpper();  // 表示　未検収
                arrDisplay[2] = radDisplay.radbtn2.Checked.ToString().ToUpper();  // 表示　検収済

                DataTable dtSiirekensyu = siirekakuninB.getSiireData(arrSerach, arrOrder, arrDisplay);

                // 入力合計
                var total = (int)dtSiirekensyu.AsEnumerable().Sum(s => s.Field<decimal>("仕入金額"));
                // 検収済合計
                var kensyuSum = (int)dtSiirekensyu.AsEnumerable().Where(s => s.Field<string>("検収状態") == "済")
                    .Sum(s => s.Field<decimal>("仕入金額"));
                // 未検収合計
                var mikenSum = (int)dtSiirekensyu.AsEnumerable().Where(s => s.Field<string>("検収状態") != "済")
                    .Sum(s => s.Field<decimal>("仕入金額"));

                // gridにバインド
                gridSiireKensyu.DataSource = dtSiirekensyu;

                // カンマを付けてテキストボックスに入れる
                txtInputTotal.Text = String.Format("{0:#,0}", total);
                txtKensyuTotal.Text = String.Format("{0:#,0}", kensyuSum);
                txtMikensyuTotal.Text = String.Format("{0:#,0}", mikenSum);

                int rowCnt = 0;
                foreach (var row in gridSiireKensyu.Rows)
                {
                    // 済の行は赤くする
                    if (gridSiireKensyu.Rows[rowCnt].Cells[9].Value.ToString().Trim().Equals("済"))
                    {
                        gridSiireKensyu.Rows[rowCnt].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        gridSiireKensyu.Rows[rowCnt].DefaultCellStyle.ForeColor = Color.Empty;
                    }
                    rowCnt++;
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                // エラーメッセージ表示
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "データ取得に失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
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
            sfd.FileName = "仕入検収入力_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xlsx";
            // デフォルトパス取得（デスクトップ）
            string Init_dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = Init_dir;
            // ファイルフィルタの設定
            sfd.Filter = "すべてのファイル(*.*)|*.*";

            try
            {
                //年月日の日付フォーマット後を入れる用
                string strYMDformat = "";

                //待機状態
                Cursor.Current = Cursors.WaitCursor;

                //仕入先が空の場合
                if (labelSet_Shiresaki.codeTxt.blIsEmpty() == false)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "仕入先を指定してください ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    labelSet_Shiresaki.Focus();
                    return;
                }

                //仕入先チェック
                if (labelSet_Shiresaki.chkTxtTorihikisaki())
                {
                    labelSet_Shiresaki.Focus();
                    return;
                }

                //検索開始年月日に記入がある場合
                if (txtDenpyoYMDStart.blIsEmpty())
                {
                    //日付フォーマット生成、およびチェック
                    strYMDformat = txtDenpyoYMDStart.chkDateDataFormat(txtDenpyoYMDStart.Text);

                    //検索開始年月日の日付チェック
                    if (strYMDformat == "")
                    {
                        // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        txtDenpyoYMDStart.Focus();
                        return;
                    }
                    else
                    {
                        txtDenpyoYMDStart.Text = strYMDformat;
                    }
                }

                //検索終了年月日に記入がある場合
                if (txtDenpyoYMDEnd.blIsEmpty())
                {
                    //初期化
                    strYMDformat = "";

                    //日付フォーマット生成、およびチェック
                    strYMDformat = txtDenpyoYMDEnd.chkDateDataFormat(txtDenpyoYMDEnd.Text);

                    //検索終了年月日の日付チェック
                    if (strYMDformat == "")
                    {
                        // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        txtDenpyoYMDEnd.Focus();

                        return;
                    }
                    else
                    {
                        txtDenpyoYMDEnd.Text = strYMDformat;
                    }
                }

                //大分類チェック
                if (labelSet_Daibunrui.chkTxtDaibunrui())
                {
                    labelSet_Daibunrui.Focus();
                    return;
                }

                //中分類チェック
                if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
                {
                    labelSet_Chubunrui.Focus();
                    return;
                }

                //メーカーチェック
                if (labelSet_Maker.chkTxtMaker())
                {
                    labelSet_Maker.Focus();
                    return;
                }

                A0670_SiiresakiSiirekakunin_B siirekakuninB = new A0670_SiiresakiSiirekakunin_B();

                // 検索文字列格納用
                string[] arrSerach = new string[8];
                // 出力順条件取得用
                string[] arrOrder = new string[2];
                // 表示条件取得用
                string[] arrDisplay = new string[3];

                arrSerach[0] = labelSet_Shiresaki.CodeTxtText;  // 仕入先コード
                arrSerach[1] = txtDenpyoYMDStart.Text;          // 伝票年月日start
                arrSerach[2] = txtDenpyoYMDEnd.Text;            // 伝票年月日end
                arrSerach[3] = labelSet_Daibunrui.CodeTxtText;  // 大分類コード
                arrSerach[4] = labelSet_Chubunrui.CodeTxtText;  // 中分類コード
                arrSerach[5] = txtKataban.Text;                 // 品名・型番
                arrSerach[6] = txtBiko.Text;                    // 備考

                arrSerach[7] = labelSet_Maker.CodeTxtText;      // メーカーコード

                arrOrder[0] = radOutOrder.radbtn0.Checked.ToString().ToUpper();   // 出力順　日付・伝票番号順
                arrOrder[1] = radOutOrder.radbtn1.Checked.ToString().ToUpper();   // 出力順　型番・日付順

                arrDisplay[0] = radDisplay.radbtn0.Checked.ToString().ToUpper();  // 表示　すべて
                arrDisplay[1] = radDisplay.radbtn1.Checked.ToString().ToUpper();  // 表示　未検収
                arrDisplay[2] = radDisplay.radbtn2.Checked.ToString().ToUpper();  // 表示　検収済

                DataTable dtSiirekensyu = siirekakuninB.getSiireData(arrSerach, arrOrder, arrDisplay);

                // カーソルをデフォルトに戻す
                this.Cursor = Cursors.Default;

                if (dtSiirekensyu.Rows.Count > 0)
                {
                    //ダイアログを表示する
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //待機状態
                        Cursor.Current = Cursors.WaitCursor;

                        CreatePdf cpdf = new CreatePdf();

                        // 出力するヘッダを設定
                        string[] header =
                        {
                            "日付",
                            "伝No.",
                            "メーカー",
                            "品名・型式",
                            "数量",
                            "仕入単価",
                            "仕入金額",
                            "備考",
                            "検収",
                        };

                        // Linqで出力対象の項目をSelect
                        // カラム名は以下のようにつける(カラム名でフォーマットを判断するため)
                        // 金額関係：＊＊＊kingaku
                        // 単価関係：＊＊＊tanka
                        // 原価：＊＊＊genka
                        // 数量：＊＊＊suryo
                        var outDat = dtSiirekensyu.AsEnumerable()
                            .Select(dat => new
                            {
                                denYmd = dat["伝票年月日"],
                                denNo = dat["伝票番号"],
                                maker = dat["メーカー"],
                                hinmei = dat["品名型式"],
                                suryo = dat["数量"],
                                siiretanka = dat["仕入単価"],
                                siirekingaku = dat["仕入金額"],
                                biko = dat["備考"],
                                kensyu = dat["検収状態"]
                            }).ToList();

                        // listをDataTableに変換
                        DataTable dtUriKensyuList = cpdf.ConvertToDataTable(outDat);

                        string outFile = sfd.FileName;

                        cpdf.DtToXls(dtUriKensyuList, "仕入検収入力", outFile, 3, 1, header);

                        this.Cursor = Cursors.Default;

                        // メッセージボックスの処理、Excel作成完了の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "Excelファイルを作成しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessagebox.ShowDialog();

                    }
                }
                else
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }


            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                // エラーロギング
                new CommonException(ex);

                // Excel出力失敗メッセージ
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "Excel出力に失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

        /// <summary>
        ///     検収状態更新（DB UPDATE）
        /// </summary>
        private void UpdateKensyuStatus()
        {
            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";
            
            //仕入先チェック
            if (labelSet_Shiresaki.chkTxtTorihikisaki())
            {
                labelSet_Shiresaki.Focus();
                return;
            }

            //検索開始年月日に記入がある場合
            if (txtDenpyoYMDStart.blIsEmpty())
            {
                //日付フォーマット生成、およびチェック
                strYMDformat = txtDenpyoYMDStart.chkDateDataFormat(txtDenpyoYMDStart.Text);

                //検索開始年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtDenpyoYMDStart.Focus();
                    return;
                }
                else
                {
                    txtDenpyoYMDStart.Text = strYMDformat;
                }
            }

            //検索終了年月日に記入がある場合
            if (txtDenpyoYMDEnd.blIsEmpty())
            {
                //初期化
                strYMDformat = "";

                //日付フォーマット生成、およびチェック
                strYMDformat = txtDenpyoYMDEnd.chkDateDataFormat(txtDenpyoYMDEnd.Text);

                //検索終了年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtDenpyoYMDEnd.Focus();

                    return;
                }
                else
                {
                    txtDenpyoYMDEnd.Text = strYMDformat;
                }
            }

            //大分類チェック
            if (labelSet_Daibunrui.chkTxtDaibunrui())
            {
                labelSet_Daibunrui.Focus();
                return;
            }

            //中分類チェック
            if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
            {
                labelSet_Chubunrui.Focus();
                return;
            }

            A0670_SiiresakiSiirekakunin_B siirekakuninB = new A0670_SiiresakiSiirekakunin_B();
            // ユーザ名取得
            string userName = SystemInformation.UserName;
            // datagridViewの情報をDataTableで取得
            DataTable dt = (DataTable)gridSiireKensyu.DataSource;

            try
            {
                // 更新処理
                siirekakuninB.UpdateKnesyuSiire(dt, userName);
                // 再度データ取得
                getSiireKensyu();
                // 成功メッセージ表示
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // エラーメッセージ表示
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_TOUROKU_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

        }

        /// <summary>
        ///     検収状態変更（１行ずつ）
        /// </summary>
        private void changeKensyu()
        {
            A0670_SiiresakiSiirekakunin_B siirekakuninB = new A0670_SiiresakiSiirekakunin_B();
            List<Kingaku> lstKingaku = new List<Kingaku>();

            // 検収状態取得
            string status = gridSiireKensyu.CurrentRow.Cells[9].Value.ToString().Trim(); ;
            // 選択行の仕入金額取得
            string strSiire = string.Format("{0:#0}", gridSiireKensyu.CurrentRow.Cells[7].Value);
            // 検収合計取得
            string strKensyu = txtKensyuTotal.Text;
            // 未検収合計取得
            string strMikensyu = txtMikensyuTotal.Text;

            if (status.Equals(""))
            {
                gridSiireKensyu.CurrentRow.Cells[9].Value = "済";
                // 検収金額、未検収金額計算
                lstKingaku = siirekakuninB.kingakuCalculation(strSiire, strKensyu, strMikensyu, 0);
            }
            else if (status.Equals("済"))
            {
                gridSiireKensyu.CurrentRow.Cells[9].Value = "";
                // 検収金額、未検収金額計算
                lstKingaku = siirekakuninB.kingakuCalculation(strSiire, strKensyu, strMikensyu, 1);
            }

            // カンマを付けてテキストボックスに入れる
            txtKensyuTotal.Text = String.Format("{0:#,0}", lstKingaku[0].kensyu);
            txtMikensyuTotal.Text = String.Format("{0:#,0}", lstKingaku[0].mikensyu);
        }

        /// <summary>
        ///     検収状態変更（すべて）
        /// <param name="fkey">
        ///     ファンクションキーの種類</param>
        /// </summary>
        private void chengeKensyuAll(string fkey)
        {
            A0670_SiiresakiSiirekakunin_B siirekakuninB = new A0670_SiiresakiSiirekakunin_B();
            List<Kingaku> lstKingaku = new List<Kingaku>();

            // 検収合計取得
            string strKensyu = txtKensyuTotal.Text;
            // 未検収合計取得
            string strMikensyu = txtMikensyuTotal.Text;
            // 行カウント用
            int rowCnt = 0;

            if (fkey.Equals("F6"))
            {
                // すべて済み
                foreach (var row in gridSiireKensyu.Rows)
                {
                    // 空のセルに"済"を入れる
                    if (gridSiireKensyu.Rows[rowCnt].Cells[9].Value.ToString().Trim().Equals(""))
                    {
                        gridSiireKensyu.Rows[rowCnt].Cells[9].Value = "済";
                    }
                    rowCnt++;
                }
                // 検収金額、未検収金額計算
                lstKingaku = siirekakuninB.kingakuCalculation(strKensyu, strMikensyu, 0);
            }
            else if (fkey.Equals("F7"))
            {
                // すべて解除
                foreach (var row in gridSiireKensyu.Rows)
                {
                    // "済"のセルを空にする
                    if (gridSiireKensyu.Rows[rowCnt].Cells[9].Value.ToString().Trim().Equals("済"))
                    {
                        gridSiireKensyu.Rows[rowCnt].Cells[9].Value = "";
                    }
                    rowCnt++;
                }
                // 検収金額、未検収金額計算
                lstKingaku = siirekakuninB.kingakuCalculation(strKensyu, strMikensyu, 1);
            }

            // カンマを付けてテキストボックスに入れる
            txtKensyuTotal.Text = String.Format("{0:#,0}", lstKingaku[0].kensyu);
            txtMikensyuTotal.Text = String.Format("{0:#,0}", lstKingaku[0].mikensyu);

        }

        /// <summary>
        ///     フォーム内の情報をクリア
        /// </summary>
        private void clearForm()
        {
            delFormClear(this, gridSiireKensyu);
            labelSet_Shiresaki.CodeTxtText = "";
            labelSet_Shiresaki.codeTxt.Focus();

            // 伝票年月日の設定
            txtDenpyoYMDStart.setUp(0);

            txtDenpyoYMDEnd.setUp(2);
            DateTime dateYMDStart = DateTime.Parse(txtDenpyoYMDEnd.Text);
            txtDenpyoYMDStart.Text = dateYMDStart.AddMonths(-1).ToString().Substring(0, 8) + "01";
        }

        /// <summary>
        ///     grid内でダブルクリック
        /// </summary>
        private void gridSiireKensyu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            changeKensyu();
        }

        ///<summary>
        ///     品名・型番内でキー押下
        ///</summary>
        private void txtKataban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }

        ///<summary>
        ///     備考内でキー押下
        ///</summary>
        private void txtBiko_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }

        ///<summary>
        ///     Grid内でキー押下
        ///</summary>
        private void gridSiireKensyu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                changeKensyu();
                // フォーカスが下に移動しないようにする
                e.Handled = true;
            }
        }

    }
}
