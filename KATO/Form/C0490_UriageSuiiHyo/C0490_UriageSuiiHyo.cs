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
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.C0490_UriageSuiiHyo;

namespace KATO.Form.C0490_UriageSuiiHyo
{
    ///<summary>
    ///C0490_UriageSuiiHyo
    ///分類別売上推移表
    ///作成者：TMSOL太田
    ///作成日：2017/06/14
    ///更新者：
    ///更新日：
    ///</summary>
    public partial class C0490_UriageSuiiHyo : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// D0380_ShohinMotochoKakunin
        /// フォーム関係の設定
        /// </summary>
        public C0490_UriageSuiiHyo(Control c)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

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
            labelSet_Daibunrui1.Lschubundata = labelSet_Chubunrui1;

            //メーカーsetデータを読めるようにする
            labelSet_Daibunrui1.Lsmakerdata = labelSet_Maker1;
        }

        private void C0490_UriageSuiiHyo_Load(object sender, EventArgs e)
        {
            System.DateTime dateYMclose;

            this.Show();
            this._Title = "分類別売上推移表";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // 開始終了年月の設定
            txtCalendarYMclose.setUp(0);
            dateYMclose = DateTime.Parse(txtCalendarYMclose.Text + "/01");
            txtCalendarYMopen.Text = dateYMclose.AddMonths(-11).ToString().Substring(0, 10);

            labelSet_TokuisakiStart.SearchOn = false;
            labelSet_TokuisakiEnd.SearchOn = false;

            //初期表示
            txtCalendarYMopen.Focus();

            //DataGridViewの初期設定
            SetUpGrid();
        }
        

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            System.DateTime dateStartYMD;

            dateStartYMD = DateTime.Parse(txtCalendarYMopen.Text);

            //列自動生成禁止
            gridUriageSuii.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn TokuisakiCd = new DataGridViewTextBoxColumn();
            TokuisakiCd.DataPropertyName = "得意先コード";
            TokuisakiCd.Name = "得意先コード";
            TokuisakiCd.HeaderText = "得意先コード";

            DataGridViewTextBoxColumn TokuisakiName = new DataGridViewTextBoxColumn();
            TokuisakiName.DataPropertyName = "得意先名";
            TokuisakiName.Name = "得意先名";
            TokuisakiName.HeaderText = "得意先名";

            DataGridViewTextBoxColumn BunruiKbn = new DataGridViewTextBoxColumn();
            BunruiKbn.DataPropertyName = "区分";
            BunruiKbn.Name = "区分";
            BunruiKbn.HeaderText = "分類区分";

            DataGridViewTextBoxColumn DaibunruiCd = new DataGridViewTextBoxColumn();
            DaibunruiCd.DataPropertyName = "大分類コード";
            DaibunruiCd.Name = "大分類コード";
            DaibunruiCd.HeaderText = "大分類コード";

            DataGridViewTextBoxColumn ChubunruiCd = new DataGridViewTextBoxColumn();
            ChubunruiCd.DataPropertyName = "中分類コード";
            ChubunruiCd.Name = "中分類コード";
            ChubunruiCd.HeaderText = "中分類コード";

            DataGridViewTextBoxColumn MakerCd = new DataGridViewTextBoxColumn();
            MakerCd.DataPropertyName = "メーカーコード";
            MakerCd.Name = "メーカーコード";
            MakerCd.HeaderText = "メーカーコード";

            DataGridViewTextBoxColumn BunruiName = new DataGridViewTextBoxColumn();
            BunruiName.DataPropertyName = "分類名";
            BunruiName.Name = "分類名";
            BunruiName.HeaderText = "分類名";

            DataGridViewTextBoxColumn month1 = new DataGridViewTextBoxColumn();
            month1.DataPropertyName = "金額１";
            month1.Name = "金額１";
            month1.HeaderText = dateStartYMD.AddMonths(0).ToString("M月");

            DataGridViewTextBoxColumn month2 = new DataGridViewTextBoxColumn();
            month2.DataPropertyName = "金額２";
            month2.Name = "金額２";
            month2.HeaderText = dateStartYMD.AddMonths(1).ToString("M月");

            DataGridViewTextBoxColumn month3 = new DataGridViewTextBoxColumn();
            month3.DataPropertyName = "金額３";
            month3.Name = "金額３";
            month3.HeaderText = dateStartYMD.AddMonths(2).ToString("M月");

            DataGridViewTextBoxColumn month4 = new DataGridViewTextBoxColumn();
            month4.DataPropertyName = "金額４";
            month4.Name = "金額４";
            month4.HeaderText = dateStartYMD.AddMonths(3).ToString("M月");

            DataGridViewTextBoxColumn month5 = new DataGridViewTextBoxColumn();
            month5.DataPropertyName = "金額５";
            month5.Name = "金額５";
            month5.HeaderText = dateStartYMD.AddMonths(4).ToString("M月");

            DataGridViewTextBoxColumn month6 = new DataGridViewTextBoxColumn();
            month6.DataPropertyName = "金額６";
            month6.Name = "金額６";
            month6.HeaderText = dateStartYMD.AddMonths(5).ToString("M月");

            DataGridViewTextBoxColumn month7 = new DataGridViewTextBoxColumn();
            month7.DataPropertyName = "金額７";
            month7.Name = "金額７";
            month7.HeaderText = dateStartYMD.AddMonths(6).ToString("M月");

            DataGridViewTextBoxColumn month8 = new DataGridViewTextBoxColumn();
            month8.DataPropertyName = "金額８";
            month8.Name = "金額８";
            month8.HeaderText = dateStartYMD.AddMonths(7).ToString("M月");

            DataGridViewTextBoxColumn month9 = new DataGridViewTextBoxColumn();
            month9.DataPropertyName = "金額９";
            month9.Name = "金額９";
            month9.HeaderText = dateStartYMD.AddMonths(8).ToString("M月");

            DataGridViewTextBoxColumn month10 = new DataGridViewTextBoxColumn();
            month10.DataPropertyName = "金額１０";
            month10.Name = "金額１０";
            month10.HeaderText = dateStartYMD.AddMonths(9).ToString("M月");

            DataGridViewTextBoxColumn month11 = new DataGridViewTextBoxColumn();
            month11.DataPropertyName = "金額１１";
            month11.Name = "金額１１";
            month11.HeaderText = dateStartYMD.AddMonths(10).ToString("M月");

            DataGridViewTextBoxColumn month12 = new DataGridViewTextBoxColumn();
            month12.DataPropertyName = "金額１２";
            month12.Name = "金額１２";
            month12.HeaderText = dateStartYMD.AddMonths(11).ToString("M月");

            DataGridViewTextBoxColumn UriageSuiiGokei = new DataGridViewTextBoxColumn();
            UriageSuiiGokei.DataPropertyName = "金額合計";
            UriageSuiiGokei.Name = "合計";
            UriageSuiiGokei.HeaderText = "合計";


            //個々の幅、文章の寄せ
            setColumn(TokuisakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, null,150);
            setColumn(BunruiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, null,150);
            setColumn(month1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0",70);
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
            setColumn(UriageSuiiGokei, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            //表示はしない項目
            setColumn(TokuisakiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null,0);
            setColumn(BunruiKbn, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,0);
            setColumn(DaibunruiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,0);
            setColumn(ChubunruiCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null,0);
            setColumn(MakerCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null,0);

            gridUriageSuii.Columns[15].Visible = false;
            gridUriageSuii.Columns[16].Visible = false;
            gridUriageSuii.Columns[17].Visible = false;
            gridUriageSuii.Columns[18].Visible = false;
            gridUriageSuii.Columns[19].Visible = false;

        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridUriageSuii.Columns.Add(col);
            if (gridUriageSuii.Columns[col.Name] != null)
            {
                gridUriageSuii.Columns[col.Name].Width = intLen;
                gridUriageSuii.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridUriageSuii.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridUriageSuii.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// C0490_UriageSuiiHyo_KeyDown
        /// キー入力判定
        /// </summary>
        private void C0490_UriageSuiiHyo_KeyDown(object sender, KeyEventArgs e)
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
                    this.setUriageSuiiHyo();
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
                    this.setUriageSuiiHyo();
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
            System.DateTime dateYMclose;

            //削除するデータ以外を確保
            string strkensakuopen = txtCalendarYMopen.Text;
            string strkensakuclose = txtCalendarYMclose.Text;

            //画面の項目内を白紙にする
            delFormClear(this,gridUriageSuii);

            txtCalendarYMopen.Text = strkensakuopen;
            txtCalendarYMclose.Text = strkensakuclose;

            // 開始終了年月の設定
            txtCalendarYMclose.setUp(0);
            dateYMclose = DateTime.Parse(txtCalendarYMclose.Text + "/01");
            txtCalendarYMopen.Text = dateYMclose.AddMonths(-11).ToString().Substring(0, 10);

            txtCalendarYMopen.Focus();
        }

        /// <summary>
        /// setUriageSuiiHyo
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setUriageSuiiHyo()
        {
            //データ検索用
            List<string> lstUriageSuiiLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //空文字判定（機関開始、期間終了）
            if (txtCalendarYMopen.blIsEmpty() == false || txtCalendarYMclose.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMopen.Focus();

                return;
            }

            //空文字判定（得意先コード開始）
            if (labelSet_TokuisakiStart.CodeTxtText == "")
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_TokuisakiStart.Focus();

                return;
            }

            // 空文字判定（仕入先コード終了）
            if (labelSet_TokuisakiEnd.CodeTxtText == "")
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
            if (labelSet_Eigyosho1.chkTxtEigyousho() == true)
            {
                labelSet_Eigyosho1.Focus();

                return;
            }

            //グループコードのチェック
            if (labelSet_GroupCd1.chkTxtGroupCd() == true)
            {
                labelSet_GroupCd1.Focus();

                return;
            }

            //担当者コードのチェック
            if (labelSet_Tantousha1.chkTxtTantosha() == true)
            {
                labelSet_Tantousha1.Focus();

                return;
            }

            //受注者コードのチェック
            if (lsJuchusha.chkTxtTantosha() == true)
            {
                lsJuchusha.Focus();

                return;
            }

            //大分類コードのチェック
            if (labelSet_Daibunrui1.chkTxtDaibunrui() == true)
            {
                labelSet_Daibunrui1.Focus();

                return;
            }

            //中分類コードのチェック
            if (labelSet_Chubunrui1.chkTxtChubunrui(labelSet_Daibunrui1.CodeTxtText) == true)
            {
                labelSet_Chubunrui1.Focus();

                return;
            }

            //メーカーコードのチェック
            if (labelSet_Maker1.chkTxtMaker() == true)
            {
                labelSet_Maker1.Focus();

                return;
            }


            //ビジネス層のインスタンス生成
            C0490_UriageSuiiHyo_B uriagesuiihyoB = new C0490_UriageSuiiHyo_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                /*[0]開始期間*/lstUriageSuiiLoad.Add(txtCalendarYMopen.Text);
                /*[1]終了期間*/lstUriageSuiiLoad.Add(txtCalendarYMclose.Text);
                /*[2]開始得意先コード*/lstUriageSuiiLoad.Add(labelSet_TokuisakiStart.CodeTxtText);
                /*[3]終了得意先コード*/lstUriageSuiiLoad.Add(labelSet_TokuisakiEnd.CodeTxtText);
                /*[4]大分類コード*/lstUriageSuiiLoad.Add(labelSet_Daibunrui1.CodeTxtText);
                /*[5]営業所コード*/lstUriageSuiiLoad.Add(labelSet_Eigyosho1.CodeTxtText);
                /*[6]担当者コード*/lstUriageSuiiLoad.Add(labelSet_Tantousha1.CodeTxtText);
                /*[7]中分類コード*/lstUriageSuiiLoad.Add(labelSet_Chubunrui1.CodeTxtText);
                /*[8]グループコード*/lstUriageSuiiLoad.Add(labelSet_GroupCd1.CodeTxtText);
                /*[9]受注者コード*/lstUriageSuiiLoad.Add(lsJuchusha.CodeTxtText);
                /*[10]メーカーコード*/lstUriageSuiiLoad.Add(labelSet_Maker1.CodeTxtText);
                
                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = uriagesuiihyoB.getUriageSuiiList(lstUriageSuiiLoad,"disp");
                
                //データを配置（datagridview)
                gridUriageSuii.DataSource = dtSetView;

                //合計額計算処理
                    int i;
                    int j;
                    String pre;
                    pre = "";
                    decimal[] suM = new decimal[14];

                    for (i = 0; i < 13; i++)
                    {
                        suM[i] = 0;
                    }

                    //配列の前後で名前が重複している場合は名前を削除
                    for (i = 0; i < gridUriageSuii.RowCount; i++)
                    {
                        //配列の前後を比較、同じ名前だった場合
                        if (gridUriageSuii[0, i].Value.ToString() == pre)
                        {
                            //名前を削除する。
                            gridUriageSuii[0, i].Value = null;
                        }
                        else
                        {
                            pre = gridUriageSuii[0, i].Value.ToString();
                        }
                    
                        for (j = 0; j < 13; j++)
                        {
                            suM[j] = suM[j] + decimal.Parse(gridUriageSuii[j+2,i].Value.ToString());
                        }
                    }
                    
                DataRow datarow = dtSetView.NewRow();

                datarow["得意先名"] = "【合計】";
                datarow["金額１"] = suM[0];
                datarow["金額２"] = suM[1];
                datarow["金額３"] = suM[2];
                datarow["金額４"] = suM[3];
                datarow["金額５"] = suM[4];
                datarow["金額６"] = suM[5];
                datarow["金額７"] = suM[6];
                datarow["金額８"] = suM[7];
                datarow["金額９"] = suM[8];
                datarow["金額１０"] = suM[9];
                datarow["金額１１"] = suM[10];
                datarow["金額１２"] = suM[11];
                datarow["金額合計"] = suM[12];

                dtSetView.Rows.Add(datarow);

                //データに合計を追加したものを配置（datagridview)
                gridUriageSuii.DataSource = dtSetView;

                gridUriageSuii.Visible = true;

            }
            catch (Exception ex)
            {
                //エラーロギング
                gridUriageSuii.Visible = true;
                new CommonException(ex);
                return;
            }
        }

        /// <summary>
        /// 期間開始日の１１ヶ月後を算出する。
        /// またグリッドビューの位置を変更する。
        /// </summary>
        private void txtCalendarYMopen_Leave(object sender, EventArgs e)
        {
            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;

            if (txtCalendarYMopen.Text == "") {
                txtCalendarYMopen.setUp(0);
            }
            try
            {
                dateStartYMD = DateTime.Parse(txtCalendarYMopen.Text);

                dateEndYMD = dateStartYMD.AddMonths(11);
                txtCalendarYMclose.Text = dateEndYMD.ToString("yyyy/MM");

                gridUriageSuii.Columns[2].HeaderText = dateStartYMD.AddMonths(0).ToString("M月");
                gridUriageSuii.Columns[3].HeaderText = dateStartYMD.AddMonths(1).ToString("M月");
                gridUriageSuii.Columns[4].HeaderText = dateStartYMD.AddMonths(2).ToString("M月");
                gridUriageSuii.Columns[5].HeaderText = dateStartYMD.AddMonths(3).ToString("M月");
                gridUriageSuii.Columns[6].HeaderText = dateStartYMD.AddMonths(4).ToString("M月");
                gridUriageSuii.Columns[7].HeaderText = dateStartYMD.AddMonths(5).ToString("M月");
                gridUriageSuii.Columns[8].HeaderText = dateStartYMD.AddMonths(6).ToString("M月");
                gridUriageSuii.Columns[9].HeaderText = dateStartYMD.AddMonths(7).ToString("M月");
                gridUriageSuii.Columns[10].HeaderText = dateStartYMD.AddMonths(8).ToString("M月");
                gridUriageSuii.Columns[11].HeaderText = dateStartYMD.AddMonths(9).ToString("M月");
                gridUriageSuii.Columns[12].HeaderText = dateStartYMD.AddMonths(10).ToString("M月");
                gridUriageSuii.Columns[13].HeaderText = dateStartYMD.AddMonths(11).ToString("M月");
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                return;
            }
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

            //空文字判定（機関開始、期間終了）
            if (txtCalendarYMopen.blIsEmpty() == false || txtCalendarYMclose.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtCalendarYMopen.Focus();

                return;
            }

            //空文字判定（得意先コード開始）
            if (labelSet_TokuisakiStart.CodeTxtText == "")
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_TokuisakiStart.Focus();

                return;
            }

            // 空文字判定（仕入先コード終了）
            if (labelSet_TokuisakiEnd.CodeTxtText == "")
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
            if (labelSet_Eigyosho1.chkTxtEigyousho() == true)
            {
                labelSet_Eigyosho1.Focus();

                return;
            }

            //グループコードのチェック
            if (labelSet_GroupCd1.chkTxtGroupCd() == true)
            {
                labelSet_GroupCd1.Focus();

                return;
            }

            //担当者コードのチェック
            if (labelSet_Tantousha1.chkTxtTantosha() == true)
            {
                labelSet_Tantousha1.Focus();

                return;
            }

            //受注者コードのチェック
            if (lsJuchusha.chkTxtTantosha() == true)
            {
                lsJuchusha.Focus();

                return;
            }

            //大分類コードのチェック
            if (labelSet_Daibunrui1.chkTxtDaibunrui() == true)
            {
                labelSet_Daibunrui1.Focus();

                return;
            }

            //中分類コードのチェック
            if (labelSet_Chubunrui1.chkTxtChubunrui(labelSet_Daibunrui1.CodeTxtText) == true)
            {
                labelSet_Chubunrui1.Focus();

                return;
            }

            //メーカーコードのチェック
            if (labelSet_Maker1.chkTxtMaker() == true)
            {
                labelSet_Maker1.Focus();

                return;
            }

            this.Cursor = Cursors.WaitCursor;

            // ビジネス層のインスタンス生成
            C0490_UriageSuiiHyo_B uriagesuiihyoB = new C0490_UriageSuiiHyo_B();
            try
            {
                // 検索するデータをリストに格納
                lstSearchItem.Add(txtCalendarYMopen.Text);
                lstSearchItem.Add(txtCalendarYMclose.Text);
                lstSearchItem.Add(labelSet_TokuisakiStart.CodeTxtText);
                lstSearchItem.Add(labelSet_TokuisakiEnd.CodeTxtText);
                lstSearchItem.Add(labelSet_Daibunrui1.CodeTxtText);
                lstSearchItem.Add(labelSet_Eigyosho1.CodeTxtText);
                lstSearchItem.Add(labelSet_Tantousha1.CodeTxtText);
                lstSearchItem.Add(labelSet_Chubunrui1.CodeTxtText);
                lstSearchItem.Add(labelSet_GroupCd1.CodeTxtText);
                lstSearchItem.Add(lsJuchusha.CodeTxtText);
                lstSearchItem.Add(labelSet_Maker1.CodeTxtText);
                
                // 検索実行（印刷用）
                DataTable dtSiireSuiiList = uriagesuiihyoB.getUriageSuiiList(lstSearchItem, "print");

                this.Cursor = Cursors.Default;

                if (dtSiireSuiiList.Rows.Count > 0)
                {
                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        // PDF作成
                        string strFile = uriagesuiihyoB.dbToPdf(dtSiireSuiiList, lstSearchItem[0]);

                        this.Cursor = Cursors.Default;

                        pf.execPreview(@strFile);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        // PDF作成
                        string strFile = uriagesuiihyoB.dbToPdf(dtSiireSuiiList, lstSearchItem[0]);

                        this.Cursor = Cursors.Default;

                        // 用紙サイズ、印刷方向はインスタンス生成と同じ値を入れる
                        // ダイアログ表示時は最後の引数はtrue
                        // （ダイアログ非経由の直接印刷時は先頭引数にプリンタ名を入れ、最後の引数をfalseに）
                        pf.execPrint(null, @strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
                    }

                    pf.Dispose();
                }
                else
                {
                    this.Cursor = Cursors.Default;

                    // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                return;
            }

        }

        /// <summary>
        /// gridUriageSuii_CellMouseDoubleClick
        /// グリッドビューのセルがダブルクリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridUriageSuii_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //データ検索用
            List<string> lstUriageSuiiDoubleClick = new List<string>();

            //選択行の値を取得(得意先コード、分類区分、大分類コード、中分類コード、メーカーコード、開始の期間、終わりの期間)
            //レベル２に渡す用
            lstUriageSuiiDoubleClick.Add(gridUriageSuii.CurrentRow.Cells[15].Value.ToString());
            lstUriageSuiiDoubleClick.Add(gridUriageSuii.CurrentRow.Cells[16].Value.ToString());
            lstUriageSuiiDoubleClick.Add(gridUriageSuii.CurrentRow.Cells[17].Value.ToString());
            lstUriageSuiiDoubleClick.Add(gridUriageSuii.CurrentRow.Cells[18].Value.ToString());
            lstUriageSuiiDoubleClick.Add(gridUriageSuii.CurrentRow.Cells[19].Value.ToString());
            lstUriageSuiiDoubleClick.Add(txtCalendarYMopen.Text);
            lstUriageSuiiDoubleClick.Add(txtCalendarYMclose.Text);

            //分類区分がNULLの場合は処理を終了する。
            if (lstUriageSuiiDoubleClick[1] == "")
            {
                return;
            }

            //分類区分が2未満の場合は分類別売上推移表レベル２フォームを開く。
            if (int.Parse(lstUriageSuiiDoubleClick[1]) < 2)
            {
                
                C0491_UriageSuiiHyo.C0491_UriageSuiiHyoLevel2 uriagesuiihyolevel2 = new C0491_UriageSuiiHyo.C0491_UriageSuiiHyoLevel2(this,lstUriageSuiiDoubleClick);
                uriagesuiihyolevel2.ShowDialog();
            }
        }
    }
    //baseformの終わり
}
//namespaceの終わり
