using KATO.Common.Ctl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.B1590_TegataCalendar;
using KATO.Common.Util;
using KATO.Form.B1580_ShiharaiInput;
using KATO.Form.B1570_NyukinInput;

namespace KATO.Form.B1590_TegataCalendar
{
    public partial class B1590_TegataCalendar : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        DataGridViewContentAlignment posLeft = DataGridViewContentAlignment.MiddleLeft;
        DataGridViewContentAlignment posCenter = DataGridViewContentAlignment.MiddleCenter;
        DataGridViewContentAlignment posRight = DataGridViewContentAlignment.MiddleRight;

        string fmtNumNormal = "#";
        string fmtNumComma = "#,0";
        string fmtNumPeriod = "#,0.00";
        string fmtYMD = "yyyy/MM/dd";
        string fmtString = null;
        int rowIdx = 0;

        BaseLabel[] lblCalendars = new BaseLabel[42];

        string stSearchDay = "";

        Color cShiharai = Color.Lime;
        Color cNyukin   = Color.Orange;

        bool shiharaiFlg = true;
        bool rangeFlg    = false;


        public B1590_TegataCalendar(Control c)
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
        }

        private void B1590_TegataCalendar_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "支払・入金期日一覧";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            btnShiharai.BackColor = cShiharai;
            btnNyukin.BackColor = cNyukin;

            gridShirarai.Visible = true;
            gridNyukin.Visible = false;

            DateTime dtN = DateTime.Today;

            #region lblDay を配列にセット
            lblCalendars[0] = lblDay0;
            lblCalendars[1] = lblDay1;
            lblCalendars[2] = lblDay2;
            lblCalendars[3] = lblDay3;
            lblCalendars[4] = lblDay4;
            lblCalendars[5] = lblDay5;
            lblCalendars[6] = lblDay6;
            lblCalendars[7] = lblDay7;
            lblCalendars[8] = lblDay8;
            lblCalendars[9] = lblDay9;
            lblCalendars[10] = lblDay10;
            lblCalendars[11] = lblDay11;
            lblCalendars[12] = lblDay12;
            lblCalendars[13] = lblDay13;
            lblCalendars[14] = lblDay14;
            lblCalendars[15] = lblDay15;
            lblCalendars[16] = lblDay16;
            lblCalendars[17] = lblDay17;
            lblCalendars[18] = lblDay18;
            lblCalendars[19] = lblDay19;
            lblCalendars[20] = lblDay20;
            lblCalendars[21] = lblDay21;
            lblCalendars[22] = lblDay22;
            lblCalendars[23] = lblDay23;
            lblCalendars[24] = lblDay24;
            lblCalendars[25] = lblDay25;
            lblCalendars[26] = lblDay26;
            lblCalendars[27] = lblDay27;
            lblCalendars[28] = lblDay28;
            lblCalendars[29] = lblDay29;
            lblCalendars[30] = lblDay30;
            lblCalendars[31] = lblDay31;
            lblCalendars[32] = lblDay32;
            lblCalendars[33] = lblDay33;
            lblCalendars[34] = lblDay34;
            lblCalendars[35] = lblDay35;
            lblCalendars[36] = lblDay36;
            lblCalendars[37] = lblDay37;
            lblCalendars[38] = lblDay38;
            lblCalendars[39] = lblDay39;
            lblCalendars[40] = lblDay40;
            lblCalendars[41] = lblDay41;
            #endregion

            setupGrid();

            // 実行時当日の日付を選択日としてカレンダー作成
            stSearchDay = dtN.ToString("yyyy/MM/dd");
            setCalendar(stSearchDay);

            setBtnColor();

            // 初期表示時は検索振分を支払側でカレンダー検索
            getCalendarData(getMonthFirst(stSearchDay), getMonthEnd(stSearchDay));

            // 選択日を検索期間範囲として詳細検索
            getListData(stSearchDay);
        }

        //
        // grid 初期設定
        //
        private void setupGrid()
        {
            #region 列項目定義 支払
            DataGridViewTextBoxColumn colRowNum = new DataGridViewTextBoxColumn();
            colRowNum.DataPropertyName = "チェック";
            colRowNum.Name = "チェック";
            colRowNum.HeaderText = "支払";
            setColumn(gridShirarai, colRowNum, posRight, posCenter, fmtString, 54);

            DataGridViewTextBoxColumn colShiireCd = new DataGridViewTextBoxColumn();
            colShiireCd.DataPropertyName = "仕入先コード";
            colShiireCd.Name = "仕入先コード";
            colShiireCd.HeaderText = "仕入先コード";
            colShiireCd.Visible = false;
            setColumn(gridShirarai, colShiireCd, posRight, posCenter, fmtString, 48);

            DataGridViewTextBoxColumn colShiireNm = new DataGridViewTextBoxColumn();
            colShiireNm.DataPropertyName = "仕入先名";
            colShiireNm.Name = "仕入先名";
            colShiireNm.HeaderText = "仕入先名";
            setColumn(gridShirarai, colShiireNm, posLeft, posCenter, fmtString, 240);

            DataGridViewTextBoxColumn colYoteiYMD = new DataGridViewTextBoxColumn();
            colYoteiYMD.DataPropertyName = "支払予定日";
            colYoteiYMD.Name = "支払予定日";
            colYoteiYMD.HeaderText = "支払予定日";
            setColumn(gridShirarai, colYoteiYMD, posRight, posCenter, fmtString, 130);

            DataGridViewTextBoxColumn colYoteiMoney = new DataGridViewTextBoxColumn();
            colYoteiMoney.DataPropertyName = "支払予定額";
            colYoteiMoney.Name = "支払予定額";
            colYoteiMoney.HeaderText = "支払予定額";
            setColumn(gridShirarai, colYoteiMoney, posRight, posCenter, "#,0", 140);

            DataGridViewTextBoxColumn colShiharaiMoney = new DataGridViewTextBoxColumn();
            colShiharaiMoney.DataPropertyName = "支払額";
            colShiharaiMoney.Name = "支払額";
            colShiharaiMoney.HeaderText = "支払額";
            //colShiharaiMoney.Visible = false;
            setColumn(gridShirarai, colShiharaiMoney, posRight, posCenter, "#,0", 140);

            DataGridViewTextBoxColumn colTegataYMD = new DataGridViewTextBoxColumn();
            colTegataYMD.DataPropertyName = "手形期日";
            colTegataYMD.Name = "手形期日";
            colTegataYMD.HeaderText = "手形期日";
            setColumn(gridShirarai, colTegataYMD, posRight, posCenter, fmtString, 130);

            DataGridViewTextBoxColumn colShiharaiYMD = new DataGridViewTextBoxColumn();
            colShiharaiYMD.DataPropertyName = "支払年月日";
            colShiharaiYMD.Name = "支払年月日";
            colShiharaiYMD.HeaderText = "支払年月日";
            colShiharaiYMD.Visible = false;
            setColumn(gridShirarai, colShiharaiYMD, posRight, posCenter, fmtString, 130);

            DataGridViewTextBoxColumn colUpdYMD = new DataGridViewTextBoxColumn();
            colUpdYMD.DataPropertyName = "更新日時";
            colUpdYMD.Name = "更新日時";
            colUpdYMD.HeaderText = "更新日時";
            colUpdYMD.Visible = false;
            setColumn(gridShirarai, colUpdYMD, posRight, posCenter, fmtString, 130);
            #endregion


            #region 列項目定義 入金
            DataGridViewTextBoxColumn colNRowNum = new DataGridViewTextBoxColumn();
            colNRowNum.DataPropertyName = "チェック";
            colNRowNum.Name = "チェック";
            colNRowNum.HeaderText = "入金";
            setColumn(gridNyukin, colNRowNum, posRight, posCenter, fmtString, 54);

            DataGridViewTextBoxColumn colNShiireCd = new DataGridViewTextBoxColumn();
            colNShiireCd.DataPropertyName = "得意先コード";
            colNShiireCd.Name = "得意先コード";
            colNShiireCd.HeaderText = "得意先コード";
            colNShiireCd.Visible = false;
            setColumn(gridNyukin, colNShiireCd, posRight, posCenter, fmtString, 48);

            DataGridViewTextBoxColumn colTokuiNm = new DataGridViewTextBoxColumn();
            colTokuiNm.DataPropertyName = "得意先名";
            colTokuiNm.Name = "得意先名";
            colTokuiNm.HeaderText = "得意先名";
            setColumn(gridNyukin, colTokuiNm, posLeft, posCenter, fmtString, 240);

            DataGridViewTextBoxColumn colNYoteiYMD = new DataGridViewTextBoxColumn();
            colNYoteiYMD.DataPropertyName = "入金予定日";
            colNYoteiYMD.Name = "入金予定日";
            colNYoteiYMD.HeaderText = "入金予定日";
            setColumn(gridNyukin, colNYoteiYMD, posRight, posCenter, fmtString, 130);

            DataGridViewTextBoxColumn colNYoteiMoney = new DataGridViewTextBoxColumn();
            colNYoteiMoney.DataPropertyName = "入金予定額";
            colNYoteiMoney.Name = "入金予定額";
            colNYoteiMoney.HeaderText = "入金予定額";
            setColumn(gridNyukin, colNYoteiMoney, posRight, posCenter, "#,0", 140);

            DataGridViewTextBoxColumn colNyukinMoney = new DataGridViewTextBoxColumn();
            colNyukinMoney.DataPropertyName = "入金額";
            colNyukinMoney.Name = "入金額";
            colNyukinMoney.HeaderText = "入金額";
            //colShiharaiMoney.Visible = false;
            setColumn(gridNyukin, colNyukinMoney, posRight, posCenter, "#,0", 140);

            DataGridViewTextBoxColumn colNTegataYMD = new DataGridViewTextBoxColumn();
            colNTegataYMD.DataPropertyName = "手形期日";
            colNTegataYMD.Name = "手形期日";
            colNTegataYMD.HeaderText = "手形期日";
            setColumn(gridNyukin, colNTegataYMD, posRight, posCenter, fmtString, 130);

            DataGridViewTextBoxColumn colNShiharaiYMD = new DataGridViewTextBoxColumn();
            colNShiharaiYMD.DataPropertyName = "入金年月日";
            colNShiharaiYMD.Name = "入金年月日";
            colNShiharaiYMD.HeaderText = "入金年月日";
            colNShiharaiYMD.Visible = false;
            setColumn(gridShirarai, colNShiharaiYMD, posRight, posCenter, fmtString, 130);

            DataGridViewTextBoxColumn colNUpdYMD = new DataGridViewTextBoxColumn();
            colNUpdYMD.DataPropertyName = "更新日時";
            colNUpdYMD.Name = "更新日時";
            colNUpdYMD.HeaderText = "更新日時";
            colNUpdYMD.Visible = false;
            setColumn(gridShirarai, colNUpdYMD, posRight, posCenter, fmtString, 130);
            #endregion
        }

        //
        // grid列セット
        //
        private void setColumn(Common.Ctl.BaseDataGridView gr, DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gr.Columns.Add(col);
            if (gr.Columns[col.Name] != null)
            {
                gr.Columns[col.Name].Width = intLen;
                gr.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gr.Columns[col.Name].HeaderCell.Style.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                gr.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;
                gr.Columns[col.Name].SortMode = DataGridViewColumnSortMode.Automatic;

                if (fmt != null)
                {
                    gr.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        // カレンダー作成
        private void setCalendar(string st)
        {
            clearCalendar(true);
            int pos = getDayOfWeek(st);
            int end = DateTime.Parse(getMonthEnd(st)).Day;

            for (int i = 0; i < end; i++)
            {
                lblCalendars[i + pos].Text = (i + 1).ToString();
            }

            #region 日付表記のない週は非表示
            if (string.IsNullOrWhiteSpace(lblDay28.Text))
            {
                lblDay28.Visible = false;
                lblDay29.Visible = false;
                lblDay30.Visible = false;
                lblDay31.Visible = false;
                lblDay32.Visible = false;
                lblDay33.Visible = false;
                lblDay34.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(lblDay35.Text))
            {
                lblDay35.Visible = false;
                lblDay36.Visible = false;
                lblDay37.Visible = false;
                lblDay38.Visible = false;
                lblDay39.Visible = false;
                lblDay40.Visible = false;
                lblDay41.Visible = false;
            }
            #endregion
        }



        // キー入力
        private void B1590_TegataCalendar_KeyDown(object sender, KeyEventArgs e)
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
                    this.Close();
                    break;

                default:
                    break;
            }
        }


        // ボタン押下
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    break;
                case STR_BTN_F03: // 削除
                    break;
                case STR_BTN_F04: // 取り消し
                    break;
                case STR_BTN_F05: // 行追加
                    break;
                case STR_BTN_F08: // 元帳確認
                    break;
                case STR_BTN_F09: // 検索
                    break;
                case STR_BTN_F10: // Excel出力
                    break;
                case STR_BTN_F11: // 印刷
                    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }
        
        // 日付ラベルクリック
        private void lblDay0_Click(object sender, EventArgs e)
        {
            setBtnColor();

            string stDay = ((BaseLabel)sender).Text;
            stDay = stDay.Split('\n')[0];

            // 日付ラベルに日付が無い場合は無視
            if (string.IsNullOrWhiteSpace(stDay))
            {
                return;
            }

            // 選択日を変更
            setSearchDay(stDay);

            rangeFlg = false;
            // 選択日を検索期間範囲として詳細検索
            getListData(stSearchDay);
        }

        // 前月ボタンクリック
        private void btnPrev_Click(object sender, EventArgs e)
        {
            setBtnColor();

            // 現在選択日の1か月前の日付を選択日としてカレンダー再作成
            stSearchDay = DateTime.Parse(stSearchDay).AddMonths(-1).ToString("yyyy/MM/dd");
            clearCalendar(true);
            setCalendar(stSearchDay);
            getCalendarData(getMonthFirst(stSearchDay), getMonthEnd(stSearchDay));
            
            // 詳細検索
            getListData(stSearchDay);
        }

        // 次月ボタンクリック
        private void btnNext_Click(object sender, EventArgs e)
        {
            setBtnColor();

            // 現在選択日の1か月後の日付を選択日としてカレンダー再作成
            stSearchDay = DateTime.Parse(stSearchDay).AddMonths(1).ToString("yyyy/MM/dd");
            clearCalendar(true);
            setCalendar(stSearchDay);
            getCalendarData(getMonthFirst(stSearchDay), getMonthEnd(stSearchDay));
            
            // 詳細検索
            getListData(stSearchDay);
        }

        // 当月全表示ボタンクリック
        private void btnAll_Click(object sender, EventArgs e)
        {
            setBtnColor();

            rangeFlg = true;
            // 選択日の月初～月末を検索期間範囲として詳細検索
            getListData(stSearchDay);
        }

        // 支払ボタンクリック
        private void btnShiharai_Click(object sender, EventArgs e)
        {
            // 日付ラベルの背景色のみクリア
            clearCalendar(false);

            // 検索振分を支払側に設定してカレンダー検索
            shiharaiFlg = true;
            gridShirarai.Visible = true;
            gridNyukin.Visible = false;
            setBtnColor();
            getCalendarData(getMonthFirst(stSearchDay), getMonthEnd(stSearchDay));

            // 詳細検索
            getListData(stSearchDay);
        }

        // 入金ボタンクリック
        private void btnNyukin_Click(object sender, EventArgs e)
        {
            // 日付ラベルの背景色のみクリア
            clearCalendar(false);

            // 検索振分を入金側に設定してカレンダー検索
            shiharaiFlg = false;
            gridShirarai.Visible = false;
            gridNyukin.Visible = true;
            setBtnColor();
            getCalendarData(getMonthFirst(stSearchDay), getMonthEnd(stSearchDay));
            
            // 詳細検索
            getListData(stSearchDay);
        }

        // カレンダー情報
        // カレンダー情報検索振分
        private void getCalendarData (string from, string to)
        {

            lblSelectYM.Text = DateTime.Parse(from).ToString("yyyy年MM月");

            if (shiharaiFlg)
            {
                getCalendarShiharai(from, to);
            }
            else
            {
                getCalendarNyukin(from, to);
            }
        }

        // 支払カレンダー情報検索
        private void getCalendarShiharai(string from, string to)
        {
            B1590_TegataCalendar_B bis = new B1590_TegataCalendar_B();
            try
            {
                DataTable dt = bis.getCalendarShiharai(from, to);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string st = dt.Rows[i]["支払予定日"].ToString().Substring(8, 2);

                        for (int j = 0; j < 42; j++)
                        {
                            if (string.IsNullOrWhiteSpace(lblCalendars[j].Text))
                            {
                                continue;
                            }
                            if (int.Parse(st) == int.Parse(lblCalendars[j].Text))
                            {
                                lblCalendars[j].BackColor = cShiharai;
                                break;
                            }
                        }
                    }
                }

                DataTable dt2 = bis.getCalendarShiharai2(from, to);
                DateTime d = new DateTime();
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(dt2.Rows[i]["支払予定日"].ToString())
                        || !DateTime.TryParse(dt2.Rows[i]["支払予定日"].ToString(), out d))
                    {
                        continue;
                    }
                    string st = dt2.Rows[i]["支払予定日"].ToString().Substring(8, 2);

                    for (int j = 0; j < 42; j++)
                    {
                        if (string.IsNullOrWhiteSpace(lblCalendars[j].Text))
                        {
                            continue;
                        }
                        if (int.Parse(st) == int.Parse(lblCalendars[j].Text.Split('\n')[0]))
                        {
                            lblCalendars[j].Text = lblCalendars[j].Text.Split('\n')[0] + "\n手形";
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        // 入金カレンダー情報検索
        private void getCalendarNyukin(string from, string to)
        {
            B1590_TegataCalendar_B bis = new B1590_TegataCalendar_B();
            try
            {
                DataTable dt = bis.getCalendarNyukin(from, to);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string st = dt.Rows[i]["入金予定日"].ToString().Substring(8, 2);

                        for (int j = 0; j < 42; j++)
                        {
                            if (string.IsNullOrWhiteSpace(lblCalendars[j].Text))
                            {
                                continue;
                            }
                            if (int.Parse(st) == int.Parse(lblCalendars[j].Text))
                            {
                                lblCalendars[j].BackColor = cNyukin;
                                break;
                            }
                        }
                    }
                }

                DataTable dt2 = bis.getCalendarNyukin2(from, to);
                DateTime d = new DateTime();
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(dt2.Rows[i]["入金予定日"].ToString())
                        || !DateTime.TryParse(dt2.Rows[i]["入金予定日"].ToString(), out d))
                    {
                        continue;
                    }
                    string st = dt2.Rows[i]["入金予定日"].ToString().Substring(8, 2);

                    for (int j = 0; j < 42; j++)
                    {
                        if (string.IsNullOrWhiteSpace(lblCalendars[j].Text))
                        {
                            continue;
                        }
                        if (int.Parse(st) == int.Parse(lblCalendars[j].Text.Split('\n')[0]))
                        {
                            lblCalendars[j].Text = lblCalendars[j].Text.Split('\n')[0] + "\n手形";
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        // 詳細情報
        // 詳細情報検索振分
        private void getListData(string YMD)
        {
            string stFrom;
            string stTo;
            if (rangeFlg)
            {
                lblSelectDay.Text = DateTime.Parse(YMD).ToString("yyyy年MM月");
                stFrom = getMonthFirst(YMD);
                stTo   = getMonthEnd(YMD);
            }
            else
            {
                lblSelectDay.Text = DateTime.Parse(YMD).ToString("yyyy年MM月dd日");
                stFrom = YMD;
                stTo   = YMD;
            }

            if (shiharaiFlg)
            {
                getListShiharai(stFrom, stTo);
            }
            else
            {
                getListNyukin(stFrom, stTo);
            }
        }

        // 支払詳細情報検索
        private void getListShiharai(string from, string to)
        {
            B1590_TegataCalendar_B bis = new B1590_TegataCalendar_B();
            try
            {
                DataTable dt = bis.getListShiharai(from, to, getMonthFirst(from), getMonthEnd(to));

                if (dt != null && dt.Rows.Count > 0)
                {
                    gridShirarai.DataSource = dt;
                }
                else
                {
                    gridShirarai.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        // 入金詳細情報検索
        private void getListNyukin(string from, string to)
        {
            B1590_TegataCalendar_B bis = new B1590_TegataCalendar_B();
            try
            {
                DataTable dt = bis.getListNyukin(from, to, getMonthFirst(from), getMonthEnd(to));

                if (dt != null && dt.Rows.Count > 0)
                {
                    gridNyukin.DataSource = dt;
                }
                else
                {
                    gridNyukin.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        // util
        // 月初日取得
        private string getMonthFirst(string st)
        {
            DateTime d = new DateTime();
            if (!DateTime.TryParse(st, out d))
            {
                return st;
            }

            return DateTime.Parse(st).ToString("yyyy/MM/01");
        }

        //月末日取得
        private string getMonthEnd(string st)
        {
            DateTime d = new DateTime();
            if (!DateTime.TryParse(st, out d))
            {
                return st;
            }

            string firstDay = getMonthFirst(st);

            return DateTime.Parse(firstDay).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
        }

        // 月初日の曜日取得
        private int getDayOfWeek(string st)
        {
            DateTime d = new DateTime();
            if (!DateTime.TryParse(st, out d))
            {
                return 0;
            }

            string firstDay = getMonthFirst(st);

            return (int)(DateTime.Parse(firstDay).DayOfWeek);

        }

        // 検索対象日付設定
        private void setSearchDay (string st)
        {
            string stDay = "";
            int end = DateTime.Parse(getMonthEnd(stSearchDay)).Day;

            if (int.Parse(st) > end)
            {
                stDay = end.ToString();
            }
            else
            {
                stDay = st;
            }

            stSearchDay = stSearchDay.Substring(0, 8) + getDayString(st);

        }

        // 日付の桁揃え
        private string getDayString(string st)
        {
            if (string.IsNullOrWhiteSpace(st))
            {
                return "01";
            }

            if (st.Length == 1)
            {
                return "0" + st;
            }

            return st;
        }

        // カレンダー初期化
        private void clearCalendar(bool bTxt)
        {
            for (int i = 0; i < 42; i++)
            {
                // 背景色を初期化し、日付ラベルを表示状態に戻す
                lblCalendars[i].BackColor = Color.White;
                lblCalendars[i].Visible = true;
                lblCalendars[i].Text = lblCalendars[i].Text.Split('\n')[0];

                // テキスト指定有の場合、日付のテキストもクリア
                if (bTxt)
                {
                    lblCalendars[i].Text = "";
                }
            }
        }

        // ボタン色設定
        private void setBtnColor()
        {
            btnShiharai.BackColor = cShiharai;
            btnNyukin.BackColor = cNyukin;

            if (shiharaiFlg)
            {
                btnShiharai.BackColor = Color.Cyan;
            }
            else
            {
                btnNyukin.BackColor = Color.Cyan;
            }
        }

        private void gridShirarai_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                B1580_ShiharaiInput.B1580_ShiharaiInput si = new B1580_ShiharaiInput.B1580_ShiharaiInput(this);

                si.txtInputYMDFr.Text  = getCellValueYMD(gridShirarai, e.RowIndex, "支払予定日", false);
                si.txtInputYMDTo.Text  = getCellValueYMD(gridShirarai, e.RowIndex, "支払予定日", false);
                si.txtDenpyoYMDFr.Text = getMonthFirst(si.txtInputYMDFr.Text);
                si.txtDenpyoYMDTo.Text = getMonthEnd(si.txtInputYMDFr.Text);
                si.txtShiireCdFr.Text  = getCellValue(gridShirarai, e.RowIndex, "仕入先コード", false);
                si.txtShiireCdTo.Text  = getCellValue(gridShirarai, e.RowIndex, "仕入先コード", false);

                si.Location = this.Location;
                si.ShowDialog();
            }
        }

        private void gridNyukin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

            }
        }

        // cellの値を文字列で取得
        private string getCellValue(BaseDataGridView g, int rowIdx, string col, bool zero)
        {
            string ret = "";

            DataGridViewCell c = g.Rows[rowIdx].Cells[col];

            if (zero)
            {
                ret = "0";
            }

            if (c != null && c.Value != null && c.Value != DBNull.Value && !string.IsNullOrWhiteSpace(c.Value.ToString()))
            {
                ret = c.Value.ToString();
            }
            return ret;
        }

        private string getCellValueYMD(BaseDataGridView g, int rowIdx, string col, bool zero)
        {
            string ret = "";

            DataGridViewCell c = g.Rows[rowIdx].Cells[col];

            if (zero)
            {
                ret = "0";
            }

            if (c != null && c.Value != null && c.Value != DBNull.Value && !string.IsNullOrWhiteSpace(c.Value.ToString()))
            {
                ret = c.Value.ToString();

                if (DateTime.Parse(ret).ToString("yyyy/MM/dd").CompareTo("0001/01/01") <= 0)
                {
                    ret = "";
                }
                else
                {
                    ret = DateTime.Parse(ret).ToString("yyyy/MM/dd");
                }

            }

            return ret;
        }

    }
}
