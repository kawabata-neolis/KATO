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
using KATO.Business.D0300_ZaikoIchiranKakunin;

namespace KATO.Form.D0300_ZaikoIchiranKakunin
{
    /// <summary>
    /// B0060_ShiharaiInput
    /// 在庫一覧確認フォーム
    /// 作成者：多田
    /// 作成日：2017/7/20
    /// 更新者：多田
    /// 更新日：2017/7/20
    /// カラム論理名
    /// </summary>
    public partial class D0300_ZaikoIchiranKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// D0300_ZaikoIchiranKakunin
        /// フォーム関係の設定
        /// </summary>
        public D0300_ZaikoIchiranKakunin(Control c)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            // フォームが最大化されないようにする
            this.MaximizeBox = false;
            // フォームが最小化されないようにする
            this.MinimizeBox = false;

            // 最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            // ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            // 親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;

            // 中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            // メーカーsetデータを読めるようにする
            labelSet_Daibunrui.Lsmakerdata = labelSet_Maker;
        }

        /// <summary>
        /// D0300_ZaikoIchiranKakunin_Load
        /// 読み込み時
        /// </summary>
        private void D0300_ZaikoIchiranKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "在庫一覧確認";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // ラジオボタンの初期表示
            radSiire.radbtn2.Checked = true;
            radUriage.radbtn2.Checked = true;
            radSort.radbtn3.Checked = true;

            // DataGridViewの初期設定
            SetUpGrid();
        }

        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            // 列自動生成禁止
            gridZaiko.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn tanaban = new DataGridViewTextBoxColumn();
            tanaban.DataPropertyName = "棚番";
            tanaban.Name = "棚番";
            tanaban.HeaderText = "棚番";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー名";
            maker.Name = "メーカー名";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "品名";
            kataban.Name = "品名";
            kataban.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn siireTanka = new DataGridViewTextBoxColumn();
            siireTanka.DataPropertyName = "仕入単価";
            siireTanka.Name = "仕入単価";
            siireTanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn hyokaTanka = new DataGridViewTextBoxColumn();
            hyokaTanka.DataPropertyName = "評価単価";
            hyokaTanka.Name = "評価単価";
            hyokaTanka.HeaderText = "評価単価";

            DataGridViewTextBoxColumn tateneTanka = new DataGridViewTextBoxColumn();
            tateneTanka.DataPropertyName = "建値仕入単価";
            tateneTanka.Name = "建値仕入単価";
            tateneTanka.HeaderText = "建値仕入単価";

            DataGridViewTextBoxColumn zengetsu = new DataGridViewTextBoxColumn();
            zengetsu.DataPropertyName = "前月在庫";
            zengetsu.Name = "前月在庫";
            zengetsu.HeaderText = "前月在庫";

            DataGridViewTextBoxColumn nyuko = new DataGridViewTextBoxColumn();
            nyuko.DataPropertyName = "入庫数";
            nyuko.Name = "入庫数";
            nyuko.HeaderText = "入庫数";

            DataGridViewTextBoxColumn shuko = new DataGridViewTextBoxColumn();
            shuko.DataPropertyName = "出庫数";
            shuko.Name = "出庫数";
            shuko.HeaderText = "出庫数";

            DataGridViewTextBoxColumn zaiko = new DataGridViewTextBoxColumn();
            zaiko.DataPropertyName = "現在庫数";
            zaiko.Name = "現在庫数";
            zaiko.HeaderText = "現在庫数";

            DataGridViewTextBoxColumn siireKingaku = new DataGridViewTextBoxColumn();
            siireKingaku.DataPropertyName = "在庫仕入金額";
            siireKingaku.Name = "在庫仕入金額";
            siireKingaku.HeaderText = "在庫仕入金額";

            DataGridViewTextBoxColumn hyokaKingaku = new DataGridViewTextBoxColumn();
            hyokaKingaku.DataPropertyName = "在庫評価金額";
            hyokaKingaku.Name = "在庫評価金額";
            hyokaKingaku.HeaderText = "在庫評価金額";

            DataGridViewTextBoxColumn tateneKingaku = new DataGridViewTextBoxColumn();
            tateneKingaku.DataPropertyName = "在庫建値金額";
            tateneKingaku.Name = "在庫建値金額";
            tateneKingaku.HeaderText = "在庫建値金額";

            // 個々の幅、文字の寄せ
            setColumn(tanaban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 160);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 440);
            setColumn(siireTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 120);
            setColumn(hyokaTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 120);
            setColumn(tateneTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 130);
            setColumn(zengetsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0", 100);
            setColumn(nyuko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0", 100);
            setColumn(shuko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0", 100);
            setColumn(zaiko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0", 100);
            setColumn(siireKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 150);
            setColumn(hyokaKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 150);
            setColumn(tateneKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 150);
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridZaiko.Columns.Add(col);
            if (gridZaiko.Columns[col.Name] != null)
            {
                gridZaiko.Columns[col.Name].Width = intLen;
                gridZaiko.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridZaiko.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridZaiko.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// D0300_ZaikoIchiranKakunin_KeyDown
        /// キー入力判定
        /// </summary>
        private void D0300_ZaikoIchiranKakunin_KeyDown(object sender, KeyEventArgs e)
        {
            // キー入力情報によって動作を変える
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
                    this.setZaikoIchiran();
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
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printReport();
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
        /// judBtnClick
        /// ボタンの反応
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 表示
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setZaikoIchiran();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printReport();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // 削除するデータ以外を確保
            string strTanaban = txtTanaban.Text;

            // 画面の項目内を白紙にする
            delFormClear(this, gridZaiko);

            txtTanaban.Text = strTanaban;

            // ラジオボタンの初期表示
            radSiire.radbtn2.Checked = true;
            radUriage.radbtn2.Checked = true;
            radSort.radbtn3.Checked = true;
        }

        /// <summary>
        /// setZaikoIchiran
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setZaikoIchiran()
        {
            DataTable dtZaikoIchiran;

            // 仕入単価、評価単価、建値仕入単価の合計用
            decimal[] decGoukei = new decimal[3];

            // データ作成用
            List<string> lstCreateItem = new List<string>();

            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // 空文字判定
            if (!blnDataCheck())
            {
                return;
            }

            // 作成するデータをリストに格納
            lstCreateItem = setCreateList();

            // 検索するデータをリストに格納
            lstSearchItem = setSearchList();

            // ビジネス層のインスタンス生成
            D0300_ZaikoIchiranKakunin_B zaikoIchiran_B = new D0300_ZaikoIchiranKakunin_B();
            try
            {
                // データ作成実行
                zaikoIchiran_B.addZaikoIchiranCreate(lstCreateItem);

                // 営業所コードが空の場合、本社と岐阜を表示
                if (lstSearchItem[2].Equals(""))
                {
                    // 検索実行（本社）
                    lstSearchItem[2] = "0001";
                    DataTable dtZaikoIchiranHonsha = zaikoIchiran_B.getZaikoIchiran(lstSearchItem);

                    // 検索実行（岐阜）
                    lstSearchItem[2] = "0002";
                    DataTable dtZaikoIchiranGifu = zaikoIchiran_B.getZaikoIchiran(lstSearchItem);

                    // 本社データに岐阜データを追加
                    foreach (DataRow drGifu in dtZaikoIchiranGifu.Rows)
                    {
                        DataRow drNewRow = dtZaikoIchiranHonsha.NewRow();
                        drNewRow = drGifu;
                        dtZaikoIchiranHonsha.ImportRow(drNewRow);
                    }

                    // スキーマのみコピー
                    dtZaikoIchiran = dtZaikoIchiranHonsha.Clone();

                    DataRow[] drZaikoIchiranSort = null;

                    // 並び順の指定（品名）
                    if (lstSearchItem[9].Equals("0"))
                    {
                        drZaikoIchiranSort = dtZaikoIchiranHonsha.Select("", "大分類コード, 品名");
                    }
                    // 並び順の指定（メーカー・品名）
                    else if (lstSearchItem[9].Equals("1"))
                    {
                        drZaikoIchiranSort = dtZaikoIchiranHonsha.Select("", "大分類コード, メーカー名, 品名");
                    }
                    // 並び順の指定（棚番・メーカー・品名）
                    else if (lstSearchItem[9].Equals("2"))
                    {
                        drZaikoIchiranSort = dtZaikoIchiranHonsha.Select("", "大分類コード, 棚番, メーカー名, 品名");
                    }
                    // 並び順の指定（棚番・品名）
                    else if (lstSearchItem[9].Equals("3"))
                    {
                        drZaikoIchiranSort = dtZaikoIchiranHonsha.Select("", "大分類コード, 棚番, 品名");
                    }

                    // データテーブルにソートしたデータを追加
                    foreach (DataRow drZaikoIchiran in drZaikoIchiranSort)
                    {
                        DataRow drNewRow = dtZaikoIchiran.NewRow();
                        drNewRow = drZaikoIchiran;
                        dtZaikoIchiran.ImportRow(drNewRow);
                    }
                }
                else
                {
                    // 検索実行
                    dtZaikoIchiran = zaikoIchiran_B.getZaikoIchiran(lstSearchItem);
                }

                int rowsCnt = dtZaikoIchiran.Rows.Count;

                // 検索データがある場合
                if (dtZaikoIchiran != null && rowsCnt > 0)
                {
                    // 仕入単価、評価単価、建値仕入単価の計算
                    for (int cnt = 0; cnt < rowsCnt; cnt++)
                    {
                        decGoukei[0] += Decimal.Parse(dtZaikoIchiran.Rows[cnt]["在庫仕入金額"].ToString());
                        decGoukei[1] += Decimal.Parse(dtZaikoIchiran.Rows[cnt]["在庫評価金額"].ToString());
                        decGoukei[2] += Decimal.Parse(dtZaikoIchiran.Rows[cnt]["在庫建値金額"].ToString());
                    }

                    // 計算結果をテキストボックスへ配置
                    lblSiireKingaku.Text = string.Format("{0:#,0}", decGoukei[0]);
                    lblHyoka.Text = string.Format("{0:#,0}", decGoukei[1]);
                    lblTatene.Text = string.Format("{0:#,0}", decGoukei[2]);

                    // データテーブルからデータグリッドへセット
                    gridZaiko.DataSource = dtZaikoIchiran;

                    Control cNow = this.ActiveControl;
                    cNow.Focus();
                }
                else
                {
                    gridZaiko.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            DataTable dtZaikoIchiran;

            // データ作成用
            List<string> lstCreateItem = new List<string>();

            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // 空文字判定
            if (!blnDataCheck())
            {
                return;
            }

            // 作成するデータをリストに格納
            lstCreateItem = setCreateList();

            // 検索するデータをリストに格納
            lstSearchItem = setSearchList();

            // ビジネス層のインスタンス生成
            D0300_ZaikoIchiranKakunin_B zaikoIchiran_B = new D0300_ZaikoIchiranKakunin_B();
            try
            {
                // データ作成実行
                zaikoIchiran_B.addZaikoIchiranCreate(lstCreateItem);

                // 営業所コードが空の場合、本社と岐阜を表示
                if (lstSearchItem[2].Equals(""))
                {
                    // 検索実行（本社）
                    lstSearchItem[2] = "0001";
                    DataTable dtZaikoIchiranHonsha = zaikoIchiran_B.getZaikoIchiran(lstSearchItem);

                    // 検索実行（岐阜）
                    lstSearchItem[2] = "0002";
                    DataTable dtZaikoIchiranGifu = zaikoIchiran_B.getZaikoIchiran(lstSearchItem);

                    // 本社データに岐阜データを追加
                    foreach (DataRow drGifu in dtZaikoIchiranGifu.Rows)
                    {
                        DataRow drNewRow = dtZaikoIchiranHonsha.NewRow();
                        drNewRow = drGifu;
                        dtZaikoIchiranHonsha.ImportRow(drNewRow);
                    }

                    // スキーマのみコピー
                    dtZaikoIchiran = dtZaikoIchiranHonsha.Clone();

                    DataRow[] drZaikoIchiranSort = null;

                    // 並び順の指定（品名）
                    if (lstSearchItem[9].Equals("0"))
                    {
                        drZaikoIchiranSort = dtZaikoIchiranHonsha.Select("", "大分類コード, 品名");
                    }
                    // 並び順の指定（メーカー・品名）
                    else if (lstSearchItem[9].Equals("1"))
                    {
                        drZaikoIchiranSort = dtZaikoIchiranHonsha.Select("", "大分類コード, メーカー名, 品名");
                    }
                    // 並び順の指定（棚番・メーカー・品名）
                    else if (lstSearchItem[9].Equals("2"))
                    {
                        drZaikoIchiranSort = dtZaikoIchiranHonsha.Select("", "大分類コード, 棚番, メーカー名, 品名");
                    }
                    // 並び順の指定（棚番・品名）
                    else if (lstSearchItem[9].Equals("3"))
                    {
                        drZaikoIchiranSort = dtZaikoIchiranHonsha.Select("", "大分類コード, 棚番, 品名");
                    }

                    // データテーブルにソートしたデータを追加
                    foreach (DataRow drZaikoIchiran in drZaikoIchiranSort)
                    {
                        DataRow drNewRow = dtZaikoIchiran.NewRow();
                        drNewRow = drZaikoIchiran;
                        dtZaikoIchiran.ImportRow(drNewRow);
                    }
                }
                else
                {
                    // 検索実行
                    dtZaikoIchiran = zaikoIchiran_B.getZaikoIchiran(lstSearchItem);
                }

                // 検索データがある場合
                if (dtZaikoIchiran != null && dtZaikoIchiran.Rows.Count > 0)
                {
                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // PDF作成
                        String strFile = zaikoIchiran_B.dbToPdf(dtZaikoIchiran, lstSearchItem);

                        // プレビュー
                        pf.execPreview(strFile);
                        pf.ShowDialog(this);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // PDF作成
                        String strFile = zaikoIchiran_B.dbToPdf(dtZaikoIchiran, lstSearchItem);

                        // 一括印刷
                        pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
                    }

                    pf.Dispose();
                }
                else
                {
                    // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、PDF作成失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "印刷が失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }

        }

        /// <summary>
        /// setCreateList
        /// 作成データをリストに格納
        /// </summary>
        private List<string> setCreateList()
        {
            List<string> lstCreateItem = new List<string>();

            lstCreateItem.Add(txtYmdFrom.Text);
            lstCreateItem.Add(txtYmdTo.Text);
            lstCreateItem.Add(labelSet_Eigyosho.CodeTxtText);
            lstCreateItem.Add(labelSet_Daibunrui.CodeTxtText);
            lstCreateItem.Add(Environment.UserName);

            return lstCreateItem;
        }

        /// <summary>
        /// setSearchList
        /// 検索データをリストに格納
        /// </summary>
        private List<string> setSearchList()
        {
            List<string> lstSearchItem = new List<string>();

            lstSearchItem.Add(txtYmdFrom.Text);
            lstSearchItem.Add(txtYmdTo.Text);
            lstSearchItem.Add(labelSet_Eigyosho.CodeTxtText);
            lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);
            lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);
            lstSearchItem.Add(labelSet_Maker.CodeTxtText);
            lstSearchItem.Add(txtTanaban.Text);

            // 期間中に仕入が（ある）
            if (radSiire.radbtn0.Checked)
            {
                lstSearchItem.Add("0");
            }
            // 期間中に仕入が（ない）
            else if (radSiire.radbtn1.Checked)
            {
                lstSearchItem.Add("1");
            }
            // 期間中に仕入が（指定なし）
            else if (radSiire.radbtn2.Checked)
            {
                lstSearchItem.Add("2");
            }

            // 期間中に売上が（ある）
            if (radUriage.radbtn0.Checked)
            {
                lstSearchItem.Add("0");
            }
            // 期間中に売上が（ない）
            else if (radUriage.radbtn1.Checked)
            {
                lstSearchItem.Add("1");
            }
            // 期間中に売上が（指定なし）
            else if (radUriage.radbtn2.Checked)
            {
                lstSearchItem.Add("2");
            }

            // 並び順の指定（品名）
            if (radSort.radbtn0.Checked)
            {
                lstSearchItem.Add("0");
            }
            // 並び順の指定（メーカー・品名）
            else if (radSort.radbtn1.Checked)
            {
                lstSearchItem.Add("1");
            }
            // 並び順の指定（棚番・メーカー・品名）
            else if (radSort.radbtn2.Checked)
            {
                lstSearchItem.Add("2");
            }
            // 並び順の指定（棚番・品名）
            else if (radSort.radbtn3.Checked)
            {
                lstSearchItem.Add("3");
            }

            // 営業所コードが空の場合
            if (labelSet_Eigyosho.CodeTxtText.Equals(""))
            {
                lstSearchItem.Add("0");
            }
            else
            {
                lstSearchItem.Add("1");
            }

            return lstSearchItem;
        }

        /// <summary>
        /// blnDataCheck
        /// 空文字判定
        /// </summary>
        private Boolean blnDataCheck()
        {
            // 開始期間
            if (txtYmdFrom.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmdFrom.Focus();

                return false;
            }

            // 終了期間
            if (txtYmdTo.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYmdTo.Focus();

                return false;
            }

            return true;
        }

    }
}
