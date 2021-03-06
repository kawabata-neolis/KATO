﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using KATO.Common.Util;
using KATO.Common.Business;
using static KATO.Common.Util.CommonTeisu;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    ///<summary>
    ///UriageList
    ///売上リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class UriageList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //前画面から取引先コードを取り出す枠（取引先コード初期値）
        public string strTorihiki = "";

        private string Title = "";
        public string _Title
        {
            set
            {
                String[] aryTitle = new string[] { value };
                this.Text = string.Format(STR_TITLE, aryTitle);
                Title = this.Text;
            }
            get
            {
                return Title;
            }
        }

        /// <summary>
        /// UriageList
        /// フォーム関係の設定（通常のテキストボックスから）
        /// </summary>
        public UriageList(Control c)
        {
            //画面データが解放されていた時の対策
            if (c == null)
            {
                return;
            }
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 100;
        }

        /// <summary>
        /// UriageList_Load
        /// 読み込み時
        /// </summary>
        private void UriageList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "売上リスト";

            List<int> lstInt = new List<int>();

            setTextData();

            //先月の1日
            txtCalendarOpen.setUp(3);

            //本月の末日
            txtCalendarClose.setUp(2);

            //DataGridViewの初期設定
            setupGrid();
        }

        /// <summary>
        /// UriageList_KeyDown
        /// キー入力判定
        /// </summary>
        private void UriageList_KeyDown(object sender, KeyEventArgs e)
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
                    //検索ボタン
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    this.btnKensakuClick(sender, e);
                    break;
                case Keys.F12:
                    //戻るボタン
                    logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));
                    this.btnEndClick(sender, e);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// judUriListTxtKeyDown
        /// キー入力判定(テキストボックス)
        /// </summary>
        private void judUriListTxtKeyDown(object sender, KeyEventArgs e)
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

        /// <summary>
        /// judGridUriageKeyDown
        /// データグリッドビュー内のデータ選択中にキーが押されたとき
        /// </summary>
        private void judGridUriageKeyDown(object sender, KeyEventArgs e)
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
                    //ダブルクリックと同じ効果
                    setSelectItem();
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

        /// <summary>
        /// setTextData
        /// 前画面のデータを記入
        /// </summary>
        private void setTextData()
        {
            //取引先コード
            if (strTorihiki.Length >= 1)
            {
                labelSet_Torihikisaki.CodeTxtText = strTorihiki;
            }
        }

        /// <summary>
        /// setupGrid
        /// DataGridView初期設定
        /// </summary>
        private void setupGrid()
        {
            //列自動生成禁止
            gridUriage.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn denpyo = new DataGridViewTextBoxColumn();
            denpyo.DataPropertyName = "伝票番号";
            denpyo.Name = "伝票番号";
            denpyo.HeaderText = "伝票番号";

            DataGridViewTextBoxColumn ymd = new DataGridViewTextBoxColumn();
            ymd.DataPropertyName = "伝票年月日";
            ymd.Name = "伝票年月日";
            ymd.HeaderText = "年月日";

            DataGridViewTextBoxColumn tokuisaki = new DataGridViewTextBoxColumn();
            tokuisaki.DataPropertyName = "得意先名";
            tokuisaki.Name = "得意先名";
            tokuisaki.HeaderText = "得意先名";

            DataGridViewTextBoxColumn hinmei = new DataGridViewTextBoxColumn();
            hinmei.DataPropertyName = "品名型番";
            hinmei.Name = "品名型番";
            hinmei.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn suu = new DataGridViewTextBoxColumn();
            suu.DataPropertyName = "数量";
            suu.Name = "数量";
            suu.HeaderText = "数量";

            DataGridViewTextBoxColumn tanka = new DataGridViewTextBoxColumn();
            tanka.DataPropertyName = "売上単価";
            tanka.Name = "売上単価";
            tanka.HeaderText = "単価";

            DataGridViewTextBoxColumn biko = new DataGridViewTextBoxColumn();
            biko.DataPropertyName = "備考";
            biko.Name = "備考";
            biko.HeaderText = "備   考";

            DataGridViewTextBoxColumn tanto = new DataGridViewTextBoxColumn();
            tanto.DataPropertyName = "担当者";
            tanto.Name = "担当者";
            tanto.HeaderText = "担当者";

            //個々の幅、文章の寄せ
            setColumn(denpyo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(ymd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 95);
            setColumn(tokuisaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 265);
            setColumn(hinmei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 330);
            setColumn(suu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 90);
            setColumn(tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 90);
            setColumn(biko, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 230);
            setColumn(tanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            //column設定
            gridUriage.Columns.Add(col);
            //カラム名が空でない場合
            if (gridUriage.Columns[col.Name] != null)
            {
                //横幅サイズの決定
                gridUriage.Columns[col.Name].Width = intLen;
                //文章の寄せ方向の決定
                gridUriage.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                //カラム名の位置の決定
                gridUriage.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                //フォーマットが指定されていた場合
                if (fmt != null)
                {
                    //フォーマットを指定
                    gridUriage.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void setSelectItem()
        {
            //datagridviewにデータが存在しなければ終了
            if (gridUriage.RowCount == 0)
            {
                return;
            }

            //選択したのは何行目か
            int intSelectRow = 0;

            //伝票番号の確保
            string strDenpyo = "";

            //detagridviewを一時的にdatatable化する用
            DataTable dtSelect = new DataTable();

            //選んだデータを渡す用
            List<string> lstSelectData = new List<string>();

            //何行目かを確保
            intSelectRow = gridUriage.CurrentCell.RowIndex;

            //datagridviewをdatatable化
            dtSelect = (DataTable)gridUriage.DataSource;

            //選択した伝票番号の確保
            strDenpyo = dtSelect.Rows[intSelectRow]["伝票番号"].ToString();

            //選択した伝票番号が存在しない場合
            if (strDenpyo == "")
            {
                return;
            }

            //ビジネス層のインスタンス生成
            UriageList_B uriagelistB = new UriageList_B();
            try
            {
                //元の画面に伝票番号を渡す
                uriagelistB.setSelectItem(intFrmKind, strDenpyo);

                //選んだ行の伝票番号を追加（終了工程用）
                lstSelectData.Add(strDenpyo);

                setEndAction(lstSelectData);
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
        ///btnEndClick
        ///戻るボタンを押したとき
        ///</summary>
        private void btnEndClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));

            //戻るボタンの処理に行くために必要（直接も戻る動作のため中身無し）
            List<string> lstString = new List<string>();

            //戻るボタンの処理
            setEndAction(lstString);
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction(List<string> lstSelectData)
        {
            this.Close();

            //ビジネス層のインスタンス生成
            UriageList_B uriagelistB = new UriageList_B();
            try
            {
                //画面終了処理
                uriagelistB.FormMove(intFrmKind);
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
        ///btnKensakuClick
        ///検索ボタンを押したとき
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "検索実行"));

            //検索結果データの確保
            DataTable dtGetData = new DataTable();

            //検索項目を入れる用
            List<string> lstUriageView = new List<string>();

            if (string.IsNullOrWhiteSpace(txtCalendarOpen.chkDateDataFormat(txtCalendarOpen.Text)))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                txtCalendarOpen.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCalendarClose.chkDateDataFormat(txtCalendarClose.Text)))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                txtCalendarClose.Focus();
                return;
            }

            //担当者[0]
            lstUriageView.Add(labelSet_Tantousha.CodeTxtText);
            //取引先コード[1](表示は得意先)
            lstUriageView.Add(labelSet_Torihikisaki.CodeTxtText);
            //開始年月日[2]
            lstUriageView.Add(txtCalendarOpen.Text);
            //終了年月日[3]
            lstUriageView.Add(txtCalendarClose.Text);
            //品名・型番[4]
            lstUriageView.Add(txtHin.Text);

            //ビジネス層のインスタンス生成
            UriageList_B uriagelstB = new UriageList_B();
            try
            {
                //データグリッドビュー部分
                dtGetData = uriagelstB.getDatagridView(lstUriageView);

                //検索結果が１つ以上ある場合
                if (dtGetData.Rows.Count > 0)
                {
                    gridUriage.DataSource = dtGetData;

                    //検索件数を表示
                    lblRecords.Text = "該当件数( " + gridUriage.RowCount.ToString() + "件)";

                    gridUriage.Focus();
                }
            }
            catch(Exception ex)
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
        ///gridUriage_DoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void gridUriage_DoubleClick(object sender, EventArgs e)
        {
            setSelectItem();
        }

        /// <summary>
        /// CreateParams
        /// タイトルバーの閉じるボタン、コントロールボックスの「閉じる」、Alt + F4 を無効
        /// </summary>
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.Demand,
                Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                const int FRM_NOCLOSE = 0x200;
                CreateParams cpForm = base.CreateParams;
                cpForm.ClassStyle = cpForm.ClassStyle | FRM_NOCLOSE;

                return cpForm;
            }
        }

        ///<summary>
        ///txtUriage_KeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void txtUriage_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///form_KeyPress
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void form_KeyPress(object sender, KeyPressEventArgs e)
        {
            //EnterやEscapeキーでビープ音が鳴らないようにする
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }
        }
    }
}
