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
using KATO.Business.C0480_SiireSuiiHyo;

namespace KATO.Form.C0480_SiireSuiiHyo
{
    /// <summary>
    /// C0480_SiireSuiiHyo
    /// 分類別仕入推移表フォーム
    /// 作成者：多田
    /// 作成日：2017/6/14
    /// 更新者：多田
    /// 更新日：2017/6/14
    /// カラム論理名
    /// </summary>
    public partial class C0480_SiireSuiiHyo : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// C0480_SiireSuiiHyo
        /// フォーム関係の設定
        /// </summary>
        public C0480_SiireSuiiHyo(Control c)
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
        /// C0480_SiireSuiiHyo_Load
        /// 読み込み時
        /// </summary>
        private void C0480_SiireSuiiHyo_Load(object sender, EventArgs e)
        {
            System.DateTime dateYMclose;
            
            this.Show();
            this._Title = "分類別仕入推移表";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // 開始終了年月の設定
            txtCalendarYMclose.setUp(0);
            dateYMclose = DateTime.Parse(txtCalendarYMclose.Text + "/01");
            txtCalendarYMopen.Text = dateYMclose.AddMonths(-11).ToString().Substring(0, 10);

            labelSet_TokuisakiStart.SearchOn = false;
            labelSet_TokuisakiEnd.SearchOn = false;

            // 初期表示
            txtCalendarYMopen.Focus();

            // DataGridViewの初期設定
            SetUpGrid();
        }

        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            System.DateTime dateYMopen;

            // 列自動生成禁止
            gridSiireSuii.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn siiresakiCd = new DataGridViewTextBoxColumn();
            siiresakiCd.DataPropertyName = "仕入先コード";
            siiresakiCd.Name = "仕入先コード";
            siiresakiCd.HeaderText = "仕入先コード";

            DataGridViewTextBoxColumn siiresakiName = new DataGridViewTextBoxColumn();
            siiresakiName.DataPropertyName = "仕入先名";
            siiresakiName.Name = "仕入先名";
            siiresakiName.HeaderText = "仕入先名";

            DataGridViewTextBoxColumn bunruiKbn = new DataGridViewTextBoxColumn();
            bunruiKbn.DataPropertyName = "区分";
            bunruiKbn.Name = "区分";
            bunruiKbn.HeaderText = "分類区分";

            DataGridViewTextBoxColumn daibunruiCd = new DataGridViewTextBoxColumn();
            daibunruiCd.DataPropertyName = "大分類コード";
            daibunruiCd.Name = "大分類コード";
            daibunruiCd.HeaderText = "大分類コード";

            DataGridViewTextBoxColumn chubunruiCd = new DataGridViewTextBoxColumn();
            chubunruiCd.DataPropertyName = "中分類コード";
            chubunruiCd.Name = "中分類コード";
            chubunruiCd.HeaderText = "中分類コード";

            DataGridViewTextBoxColumn makerCd = new DataGridViewTextBoxColumn();
            makerCd.DataPropertyName = "メーカーコード";
            makerCd.Name = "メーカーコード";
            makerCd.HeaderText = "メーカーコード";

            DataGridViewTextBoxColumn bunruiName = new DataGridViewTextBoxColumn();
            bunruiName.DataPropertyName = "分類名";
            bunruiName.Name = "分類名";
            bunruiName.HeaderText = "分類名";
            
            dateYMopen = DateTime.Parse(txtCalendarYMopen.Text + "/01");

            DataGridViewTextBoxColumn month1 = new DataGridViewTextBoxColumn();
            month1.DataPropertyName = "金額１";
            month1.Name = "金額１";
            month1.HeaderText = dateYMopen.AddMonths(0).ToString("M月");

            DataGridViewTextBoxColumn month2 = new DataGridViewTextBoxColumn();
            month2.DataPropertyName = "金額２";
            month2.Name = "金額２";
            month2.HeaderText = dateYMopen.AddMonths(1).ToString("M月");

            DataGridViewTextBoxColumn month3 = new DataGridViewTextBoxColumn();
            month3.DataPropertyName = "金額３";
            month3.Name = "金額３";
            month3.HeaderText = dateYMopen.AddMonths(2).ToString("M月");

            DataGridViewTextBoxColumn month4 = new DataGridViewTextBoxColumn();
            month4.DataPropertyName = "金額４";
            month4.Name = "金額４";
            month4.HeaderText = dateYMopen.AddMonths(3).ToString("M月");

            DataGridViewTextBoxColumn month5 = new DataGridViewTextBoxColumn();
            month5.DataPropertyName = "金額５";
            month5.Name = "金額５";
            month5.HeaderText = dateYMopen.AddMonths(4).ToString("M月");

            DataGridViewTextBoxColumn month6 = new DataGridViewTextBoxColumn();
            month6.DataPropertyName = "金額６";
            month6.Name = "金額６";
            month6.HeaderText = dateYMopen.AddMonths(5).ToString("M月");

            DataGridViewTextBoxColumn month7 = new DataGridViewTextBoxColumn();
            month7.DataPropertyName = "金額７";
            month7.Name = "金額７";
            month7.HeaderText = dateYMopen.AddMonths(6).ToString("M月");

            DataGridViewTextBoxColumn month8 = new DataGridViewTextBoxColumn();
            month8.DataPropertyName = "金額８";
            month8.Name = "金額８";
            month8.HeaderText = dateYMopen.AddMonths(7).ToString("M月");

            DataGridViewTextBoxColumn month9 = new DataGridViewTextBoxColumn();
            month9.DataPropertyName = "金額９";
            month9.Name = "金額９";
            month9.HeaderText = dateYMopen.AddMonths(8).ToString("M月");

            DataGridViewTextBoxColumn month10 = new DataGridViewTextBoxColumn();
            month10.DataPropertyName = "金額１０";
            month10.Name = "金額１０";
            month10.HeaderText = dateYMopen.AddMonths(9).ToString("M月");

            DataGridViewTextBoxColumn month11 = new DataGridViewTextBoxColumn();
            month11.DataPropertyName = "金額１１";
            month11.Name = "金額１１";
            month11.HeaderText = dateYMopen.AddMonths(10).ToString("M月");

            DataGridViewTextBoxColumn month12 = new DataGridViewTextBoxColumn();
            month12.DataPropertyName = "金額１２";
            month12.Name = "金額１２";
            month12.HeaderText = dateYMopen.AddMonths(11).ToString("M月");

            DataGridViewTextBoxColumn goukei = new DataGridViewTextBoxColumn();
            goukei.DataPropertyName = "金額合計";
            goukei.Name = "金額合計";
            goukei.HeaderText = "合計";

            // 個々の幅、文字の寄せ
            setColumn(siiresakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(bunruiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 140);
            setColumn(month1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month7, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month8, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month9, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month10, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month11, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month12, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(goukei, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 90);

            // 非表示項目（レベル２で使用）
            setColumn(siiresakiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(bunruiKbn, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(daibunruiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(chubunruiCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(makerCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);

            gridSiireSuii.Columns[15].Visible = false;
            gridSiireSuii.Columns[16].Visible = false;
            gridSiireSuii.Columns[17].Visible = false;
            gridSiireSuii.Columns[18].Visible = false;
            gridSiireSuii.Columns[19].Visible = false;

        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridSiireSuii.Columns.Add(col);
            if (gridSiireSuii.Columns[col.Name] != null)
            {
                gridSiireSuii.Columns[col.Name].Width = intLen;
                gridSiireSuii.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridSiireSuii.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridSiireSuii.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// C0480_SiireSuiiHyo_KeyDown
        /// キー入力判定
        /// </summary>
        private void C0480_SiireSuiiHyo_KeyDown(object sender, KeyEventArgs e)
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
                    this.setSiireSuiiHyo();
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
                    this.setSiireSuiiHyo();
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
        /// updTxtCalendarLeave
        /// 期間開始の入力箇所からフォーカスが外れた時
        /// </summary>
        private void updTxtCalendarLeave(object sender, EventArgs e)
        {
            System.DateTime dateYMopen;

            // 期間終了の日付設定
            if (DateTime.TryParse(txtCalendarYMopen.Text + "/01", out dateYMopen))
            {
                txtCalendarYMclose.Text = dateYMopen.AddMonths(11).ToString().Substring(0, 10);

                // ヘッダー部分（月）の変更
                gridSiireSuii.Columns[2].HeaderText = dateYMopen.AddMonths(0).ToString("M月");
                gridSiireSuii.Columns[3].HeaderText = dateYMopen.AddMonths(1).ToString("M月");
                gridSiireSuii.Columns[4].HeaderText = dateYMopen.AddMonths(2).ToString("M月");
                gridSiireSuii.Columns[5].HeaderText = dateYMopen.AddMonths(3).ToString("M月");
                gridSiireSuii.Columns[6].HeaderText = dateYMopen.AddMonths(4).ToString("M月");
                gridSiireSuii.Columns[7].HeaderText = dateYMopen.AddMonths(5).ToString("M月");
                gridSiireSuii.Columns[8].HeaderText = dateYMopen.AddMonths(6).ToString("M月");
                gridSiireSuii.Columns[9].HeaderText = dateYMopen.AddMonths(7).ToString("M月");
                gridSiireSuii.Columns[10].HeaderText = dateYMopen.AddMonths(8).ToString("M月");
                gridSiireSuii.Columns[11].HeaderText = dateYMopen.AddMonths(9).ToString("M月");
                gridSiireSuii.Columns[12].HeaderText = dateYMopen.AddMonths(10).ToString("M月");
                gridSiireSuii.Columns[13].HeaderText = dateYMopen.AddMonths(11).ToString("M月");
            }

            return;
        }

        /// <summary>
        /// txtCalendar_KeyPress
        /// 期間終了のKeyPressイベント
        /// </summary>
        private void txtCalendarYMcloseKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        /// <summary>
        /// txtCalendar_KeyDown
        /// 期間終了のKeyDownイベント
        /// </summary>
        private void txtCalendarYMcloseKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            return;
        }

        /// <summary>
        /// setSiireSuiiHyo
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setSiireSuiiHyo()
        {
            // 金額１～金額１２、金額合計の合計用
            decimal[] decGoukei = new decimal[13];

            // データ検索用
            List<string> lstSearchItem = new List<string>();

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            // 空文字判定（期間開始、期間終了）
            if (txtCalendarYMopen.blIsEmpty() == false || txtCalendarYMclose.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMopen.Focus();

                return;
            }

            // 空文字判定（仕入先コード開始）
            if (labelSet_TokuisakiStart.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_TokuisakiStart.Focus();

                return;
            }

            // 空文字判定（仕入先コード終了）
            if (labelSet_TokuisakiEnd.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_TokuisakiEnd.Focus();

                return;
            }

            //日付フォーマット生成、およびチェック
            strYMDformat = txtCalendarYMopen.chkDateYMDataFormat(txtCalendarYMopen.Text);

            //開始年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMopen.Focus();

                return;
            }
            else
            {
                txtCalendarYMopen.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtCalendarYMclose.chkDateYMDataFormat(txtCalendarYMclose.Text);

            //終了年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMclose.Focus();

                return;
            }
            else
            {
                txtCalendarYMclose.Text = strYMDformat;
            }

            //営業所コードのチェック
            if (labelSet_Eigyosho.chkTxtEigyousho() == true)
            {
                labelSet_Eigyosho.Focus();

                return;
            }

            //グループコードのチェック
            if (labelSet_GroupCd.chkTxtGroupCd() == true)
            {
                labelSet_GroupCd.Focus();

                return;
            }

            //受注者コードのチェック
            if (labelSet_Juchusha.chkTxtTantosha() == true)
            {
                labelSet_Juchusha.Focus();

                return;
            }

            //大分類コードのチェック
            if (labelSet_Daibunrui.chkTxtDaibunrui() == true)
            {
                labelSet_Daibunrui.Focus();

                return;
            }

            //中分類コードのチェック
            if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText) == true)
            {
                labelSet_Chubunrui.Focus();

                return;
            }

            //メーカーコードのチェック
            if (labelSet_Maker.chkTxtMaker() == true)
            {
                labelSet_Maker.Focus();

                return;
            }

            // ビジネス層のインスタンス生成
            C0480_SiireSuiiHyo_B siiresuiihyoB = new C0480_SiireSuiiHyo_B();
            try
            {
                // 検索するデータをリストに格納
                lstSearchItem.Add(txtCalendarYMopen.Text);
                lstSearchItem.Add(txtCalendarYMclose.Text);
                lstSearchItem.Add(labelSet_Eigyosho.CodeTxtText);
                lstSearchItem.Add(labelSet_GroupCd.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiStart.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiEnd.CodeTxtText);
                lstSearchItem.Add(labelSet_Juchusha.CodeTxtText);
                lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);
                lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);
                lstSearchItem.Add(labelSet_Maker.CodeTxtText);

                // 検索実行（表示用）
                DataTable dtSiireSuiiList = siiresuiihyoB.getSiireSuiiList(lstSearchItem, "disp");

                DataRow drGoukei = dtSiireSuiiList.NewRow();
                int rowsCnt = dtSiireSuiiList.Rows.Count;

                // 検索データがある場合
                if (dtSiireSuiiList != null && rowsCnt > 0)
                {
                    // 金額１～金額１２、金額合計の計算
                    for (int cnt = 0; cnt < rowsCnt; cnt++)
                    {
                        decGoukei[0] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額１"].ToString()));
                        decGoukei[1] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額２"].ToString()));
                        decGoukei[2] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額３"].ToString()));
                        decGoukei[3] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額４"].ToString()));
                        decGoukei[4] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額５"].ToString()));
                        decGoukei[5] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額６"].ToString()));
                        decGoukei[6] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額７"].ToString()));
                        decGoukei[7] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額８"].ToString()));
                        decGoukei[8] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額９"].ToString()));
                        decGoukei[9] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額１０"].ToString()));
                        decGoukei[10] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額１１"].ToString()));
                        decGoukei[11] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額１２"].ToString()));
                        decGoukei[12] += decimal.ToInt32(Decimal.Parse(dtSiireSuiiList.Rows[cnt]["金額合計"].ToString()));
                    }
                }

                // 合計行へ値をセット
                drGoukei["仕入先名"] = "【合計】";
                drGoukei["金額１"] = decGoukei[0];
                drGoukei["金額２"] = decGoukei[1];
                drGoukei["金額３"] = decGoukei[2];
                drGoukei["金額４"] = decGoukei[3];
                drGoukei["金額５"] = decGoukei[4];
                drGoukei["金額６"] = decGoukei[5];
                drGoukei["金額７"] = decGoukei[6];
                drGoukei["金額８"] = decGoukei[7];
                drGoukei["金額９"] = decGoukei[8];
                drGoukei["金額１０"] = decGoukei[9];
                drGoukei["金額１１"] = decGoukei[10];
                drGoukei["金額１２"] = decGoukei[11];
                drGoukei["金額合計"] = decGoukei[12];

                // 合計行を追加
                dtSiireSuiiList.Rows.Add(drGoukei);

                // データテーブルからデータグリッドへセット
                gridSiireSuii.DataSource = dtSiireSuiiList;

                String strName = "";

                // 配列の前後で名前が重複している場合は名前を削除
                for (int cnt = 0; cnt < gridSiireSuii.RowCount; cnt++)
                {
                    // 配列の前後を比較、同じ名前だった場合
                    if (gridSiireSuii[0, cnt].Value.ToString().Equals(strName))
                    {
                        // 名前を削除
                        gridSiireSuii[0, cnt].Value = null;
                    }
                    else
                    {
                        strName = gridSiireSuii[0, cnt].Value.ToString();
                    }
                }

                gridSiireSuii.Visible = true;

                Control cNow = this.ActiveControl;
                cNow.Focus();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                return;
            }
            return;
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // 削除するデータ以外を確保
            string strkikanopen = txtCalendarYMopen.Text;
            string strkikanclose = txtCalendarYMclose.Text;

            // 画面の項目内を白紙にする
            delFormClear(this, gridSiireSuii);

            txtCalendarYMopen.Text = strkikanopen;
            txtCalendarYMclose.Text = strkikanclose;
        }

        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            // 空文字判定（期間開始、期間終了）
            if (txtCalendarYMopen.blIsEmpty() == false || txtCalendarYMclose.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMopen.Focus();

                return;
            }

            // 空文字判定（仕入先コード開始）
            if (labelSet_TokuisakiStart.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_TokuisakiStart.Focus();

                return;
            }

            // 空文字判定（仕入先コード終了）
            if (labelSet_TokuisakiEnd.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_TokuisakiEnd.Focus();

                return;
            }

            //日付フォーマット生成、およびチェック
            strYMDformat = txtCalendarYMopen.chkDateYMDataFormat(txtCalendarYMopen.Text);

            //開始年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMopen.Focus();

                return;
            }
            else
            {
                txtCalendarYMopen.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtCalendarYMclose.chkDateYMDataFormat(txtCalendarYMclose.Text);

            //終了年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMclose.Focus();

                return;
            }
            else
            {
                txtCalendarYMclose.Text = strYMDformat;
            }

            //営業所コードのチェック
            if (labelSet_Eigyosho.chkTxtEigyousho() == true)
            {
                labelSet_Eigyosho.Focus();

                return;
            }

            //グループコードのチェック
            if (labelSet_GroupCd.chkTxtGroupCd() == true)
            {
                labelSet_GroupCd.Focus();

                return;
            }

            //受注者コードのチェック
            if (labelSet_Juchusha.chkTxtTantosha() == true)
            {
                labelSet_Juchusha.Focus();

                return;
            }

            //大分類コードのチェック
            if (labelSet_Daibunrui.chkTxtDaibunrui() == true)
            {
                labelSet_Daibunrui.Focus();

                return;
            }

            //中分類コードのチェック
            if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText) == true)
            {
                labelSet_Chubunrui.Focus();

                return;
            }

            //メーカーコードのチェック
            if (labelSet_Maker.chkTxtMaker() == true)
            {
                labelSet_Maker.Focus();

                return;
            }

            // ビジネス層のインスタンス生成
            C0480_SiireSuiiHyo_B siiresuiihyoB = new C0480_SiireSuiiHyo_B();
            try
            {
                // 検索するデータをリストに格納
                lstSearchItem.Add(txtCalendarYMopen.Text);
                lstSearchItem.Add(txtCalendarYMclose.Text);
                lstSearchItem.Add(labelSet_Eigyosho.CodeTxtText);
                lstSearchItem.Add(labelSet_GroupCd.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiStart.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiEnd.CodeTxtText);
                lstSearchItem.Add(labelSet_Juchusha.CodeTxtText);
                lstSearchItem.Add(labelSet_Daibunrui.CodeTxtText);
                lstSearchItem.Add(labelSet_Chubunrui.CodeTxtText);
                lstSearchItem.Add(labelSet_Maker.CodeTxtText);

                // 検索実行（印刷用）
                DataTable dtSiireSuiiList = siiresuiihyoB.getSiireSuiiList(lstSearchItem, "print");

                if (dtSiireSuiiList.Rows.Count > 0)
                {
                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_B4, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // PDF作成
                        String strFile = siiresuiihyoB.dbToPdf(dtSiireSuiiList, lstSearchItem[0]);

                        // プレビュー
                        pf.execPreview(strFile);
                        pf.ShowDialog(this);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // PDF作成
                        String strFile = siiresuiihyoB.dbToPdf(dtSiireSuiiList, lstSearchItem[0]);

                        // 一括印刷
                        pf.execPrint(null, strFile, CommonTeisu.SIZE_B4, CommonTeisu.YOKO, true);
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
        /// gridUriageSuii_CellMouseDoubleClick
        /// グリッドビューのセルがダブルクリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridSiireSuii_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // データ検索用
            List<string> lstSiireSuiiDoubleClick = new List<string>();

            // 選択行の値を取得(仕入先コード、分類区分、大分類コード、中分類コード、メーカーコード、開始の期間、終わりの期間)
            // レベル２に渡す用
            lstSiireSuiiDoubleClick.Add(gridSiireSuii.CurrentRow.Cells[15].Value.ToString());
            lstSiireSuiiDoubleClick.Add(gridSiireSuii.CurrentRow.Cells[16].Value.ToString());
            lstSiireSuiiDoubleClick.Add(gridSiireSuii.CurrentRow.Cells[17].Value.ToString());
            lstSiireSuiiDoubleClick.Add(gridSiireSuii.CurrentRow.Cells[18].Value.ToString());
            lstSiireSuiiDoubleClick.Add(gridSiireSuii.CurrentRow.Cells[19].Value.ToString());
            lstSiireSuiiDoubleClick.Add(txtCalendarYMopen.Text);
            lstSiireSuiiDoubleClick.Add(txtCalendarYMclose.Text);

            // 分類区分がNULLの場合は処理を終了
            if (lstSiireSuiiDoubleClick[1] == "")
            {
                return;
            }

            // 分類区分が2未満の場合は分類別仕入推移表レベル２フォームを開く
            if (int.Parse(lstSiireSuiiDoubleClick[1]) < 2)
            {
                C0481_SiireSuiiHyo.C0481_SiireSuiiHyoLevel2 siiresuiihyolevel2 = new C0481_SiireSuiiHyo.C0481_SiireSuiiHyoLevel2(this, lstSiireSuiiDoubleClick);
                siiresuiihyolevel2.ShowDialog();
            }
        }

    }
}
