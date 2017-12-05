using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Form.F0140_TanaorosiInput;
using KATO.Common.Util;
using KATO.Common.Business;
using static KATO.Common.Util.CommonTeisu;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    ///<summary>
    ///ShouhinList
    ///商品リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class ShouhinList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //前画面から年月日を取り出す枠（年月日初期値）
        public string strYMD = "";

        //前画面から営業所コードを取り出す枠（営業所コード初期値）
        public string strEigyoushoCode = "";

        //前画面から大分類コードを取り出す枠（大分類コード初期値）
        public string strDaibunruiCode = "";

        //前画面から中分類コードを取り出す枠（中分類コード初期値）
        public string strChubunruiCode = "";

        //前画面からメーカーコードを取り出す枠（メーカーコード初期値）
        public string strMakerCode = "";

        //前画面から検索コードを取り出す枠（検索コード初期値）
        public string strKensaku = "";
        
        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //DB参照の場所を判断（テキストボックスから）
        int intDBjud = 0;

        //棚無し画面かどうか
        public bool blNoTana = false;

        Boolean blnZaikoKensaku = true;

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
        /// ShouhinList
        /// フォーム関係の設定（通常のテキストボックスから）
        /// </summary>
        public ShouhinList(Control c)
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

            //中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            //
            if (blNoTana == true)
            {
                //未登録棚番を使用する場合
                chkNotToroku.Checked = false;
            }
            else
            {
                chkNotToroku.Checked = true;
            }

        }

        /// <summary>
        /// MakerList_Load
        /// 読み込み時
        /// </summary>
        private void ShouhinList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品リスト";

            List<int> lstInt = new List<int>();

            //メーカーsetデータを読めるようにする
            labelSet_Daibunrui.Lsmakerdata = labelSet_Maker;

            setTextData();

            //DataGridViewの初期設定
            setupGrid();

            //画面で判定して項目を追加
            setupStart();

            //データ渡し用
            lstInt.Add(0);

            //検索単語があれば表示
            if (StringUtl.blIsEmpty(strKensaku) == true)
            {
                setShohinView(lstInt);
            }
        }

        ///<summary>
        ///setupGrid
        ///DataGridView初期設定
        ///</summary>
        private void setupGrid()
        {
            //列自動生成禁止
            gridTorihiki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn code = new DataGridViewTextBoxColumn();
            code.DataPropertyName = "コード";
            code.Name = "コード";
            code.HeaderText = "コード";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー";
            maker.Name = "メーカー";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn daibunrui = new DataGridViewTextBoxColumn();
            daibunrui.DataPropertyName = "大分類名";
            daibunrui.Name = "大分類名";
            daibunrui.HeaderText = "大分類名";

            DataGridViewTextBoxColumn chubunrui = new DataGridViewTextBoxColumn();
            chubunrui.DataPropertyName = "中分類名";
            chubunrui.Name = "中分類名";
            chubunrui.HeaderText = "中分類名";

            DataGridViewTextBoxColumn hinmei = new DataGridViewTextBoxColumn();
            hinmei.DataPropertyName = "品名";
            hinmei.Name = "品名";
            hinmei.HeaderText = "品名";

            DataGridViewTextBoxColumn honshazaiko = new DataGridViewTextBoxColumn();
            honshazaiko.DataPropertyName = "本社在庫";
            honshazaiko.Name = "本社在庫";
            honshazaiko.HeaderText = "本社在庫";

            DataGridViewTextBoxColumn honshafree = new DataGridViewTextBoxColumn();
            honshafree.DataPropertyName = "本社ﾌﾘｰ";
            honshafree.Name = "本社ﾌﾘｰ";
            honshafree.HeaderText = "本社ﾌﾘｰ";

            DataGridViewTextBoxColumn gihuzaiko = new DataGridViewTextBoxColumn();
            gihuzaiko.DataPropertyName = "岐阜在庫";
            gihuzaiko.Name = "岐阜在庫";
            gihuzaiko.HeaderText = "岐阜在庫";

            DataGridViewTextBoxColumn gihufree = new DataGridViewTextBoxColumn();
            gihufree.DataPropertyName = "岐阜ﾌﾘｰ";
            gihufree.Name = "岐阜ﾌﾘｰ";
            gihufree.HeaderText = "岐阜ﾌﾘｰ";

            DataGridViewTextBoxColumn teika = new DataGridViewTextBoxColumn();
            teika.DataPropertyName = "定価";
            teika.Name = "定価";
            teika.HeaderText = "定価";

            DataGridViewTextBoxColumn kakeritu = new DataGridViewTextBoxColumn();
            kakeritu.DataPropertyName = "掛率";
            kakeritu.Name = "掛率";
            kakeritu.HeaderText = "掛率";

            DataGridViewTextBoxColumn shiretanka = new DataGridViewTextBoxColumn();
            shiretanka.DataPropertyName = "仕入単価";
            shiretanka.Name = "仕入単価";
            shiretanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn memo = new DataGridViewTextBoxColumn();
            memo.DataPropertyName = "メモ";
            memo.Name = "メモ";
            memo.HeaderText = "メモ";

            //個々の幅、文章の寄せ
            setColumnShohin(code, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnShohin(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnShohin(daibunrui, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnShohin(chubunrui, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnShohin(hinmei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 250);
            setColumnShohin(honshazaiko, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnShohin(honshafree, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumnShohin(gihuzaiko, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnShohin(gihufree, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumnShohin(teika, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumnShohin(kakeritu, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumnShohin(shiretanka, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnShohin(memo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
        }

        ///<summary>
        ///setColumnShohin
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumnShohin(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridTorihiki.Columns.Add(col);
            if (gridTorihiki.Columns[col.Name] != null)
            {
                gridTorihiki.Columns[col.Name].Width = intLen;
                gridTorihiki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridTorihiki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridTorihiki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///setupStart
        ///DataGridView初期設定続き
        ///</summary>
        private void setupStart()
        {
            //if (intFrmKind == CommonTeisu.FRM_SHOHIN_TANA)
            //{
            //    DataGridViewTextBoxColumn tanaHonsha = new DataGridViewTextBoxColumn();
            //    tanaHonsha.DataPropertyName = "棚番本社";
            //    tanaHonsha.Name = "棚番本社";
            //    tanaHonsha.HeaderText = "棚番本社";

            //    DataGridViewTextBoxColumn tanaGifu = new DataGridViewTextBoxColumn();
            //    tanaGifu.DataPropertyName = "棚番岐阜";
            //    tanaGifu.Name = "棚番岐阜";
            //    tanaGifu.HeaderText = "棚番岐阜";

            //    gridTorihiki.Columns.Add(tanaHonsha);
            //    gridTorihiki.Columns.Add(tanaGifu);

            //    gridTorihiki.Columns["棚番本社"].Width = 110;
            //    gridTorihiki.Columns["棚番本社"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    gridTorihiki.Columns["棚番本社"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //    gridTorihiki.Columns["棚番岐阜"].Width = 110;
            //    gridTorihiki.Columns["棚番岐阜"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    gridTorihiki.Columns["棚番岐阜"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //    chkNotToroku.Visible = true;
            //    chkNotToroku.Checked = true;
            //    lblDataFree.Visible = false;
            //    btnHonshaZaiko.Visible = false;
            //    btnGifuZaiko.Visible = false;

            //    blnZaikoKensaku = false;
            //}
            //else if (intFrmKind == CommonTeisu.FRM_SHOHIN ||
            //         intFrmKind == CommonTeisu.FRM_TANAOROSHI ||
            //         intFrmKind == CommonTeisu.FRM_SHOHINMOTOCHOKAKUNIN ||
            //         intFrmKind == CommonTeisu.FRM_HACHUINPUT)
            //{
            //    DataGridViewTextBoxColumn zaikoHonsha = new DataGridViewTextBoxColumn();
            //    zaikoHonsha.DataPropertyName = "本社在庫";
            //    zaikoHonsha.Name = "本社在庫";
            //    zaikoHonsha.HeaderText = "本社在庫";

            //    DataGridViewTextBoxColumn zaikoGifu = new DataGridViewTextBoxColumn();
            //    zaikoGifu.DataPropertyName = "岐阜在庫";
            //    zaikoGifu.Name = "岐阜在庫";
            //    zaikoGifu.HeaderText = "岐阜在庫";

            //    gridTorihiki.Columns.Add(zaikoHonsha);
            //    gridTorihiki.Columns.Add(zaikoGifu);

            //    gridTorihiki.Columns["本社在庫"].Width = 110;
            //    gridTorihiki.Columns["本社在庫"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    gridTorihiki.Columns["本社在庫"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //    gridTorihiki.Columns["岐阜在庫"].Width = 110;
            //    gridTorihiki.Columns["岐阜在庫"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    gridTorihiki.Columns["岐阜在庫"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
        }


        ///<summary>
        ///judShouhinListKeyDown
        ///キー入力判定
        ///</summary>
        private void judShouhinListKeyDown(object sender, KeyEventArgs e)
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

        ///<summary>
        ///judTokuiListTxtKeyDown
        ///キー入力判定(テキストボックス)
        ///</summary>
        private void judTokuiListTxtKeyDown(object sender, KeyEventArgs e)
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
                    //ダブルクリックと同じ動作
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

        ///<summary>
        ///setGridTorihiki_DoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void setGridTorihiki_DoubleClick(object sender, EventArgs e)
        {
            setSelectItem();
        }
        
        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>
        private void setSelectItem()
        {
            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();

            if (intFrmKind == 0)
            {
                return;
            }

            //選択行のcode取得
            string strSelectid = (string)gridTorihiki.CurrentRow.Cells[4].Value;
            //選択行の商品コード取得
            string strSelectShohinCD = (string)gridTorihiki.CurrentRow.Cells["コード"].Value;
            //選択行のメーカーコード取得
            string strSelectMakerCD = (string)gridTorihiki.CurrentRow.Cells["メーカー"].Value;
            //選択行の大分類名取得
            string strSelectDaibunName = (string)gridTorihiki.CurrentRow.Cells["大分類名"].Value;
            //選択行の中分類名取得
            string strSelectChubunName = (string)gridTorihiki.CurrentRow.Cells["中分類名"].Value;

            //データ渡し用
            lstInt.Add(intFrmKind);

            lstString.Add(strYMD);
            lstString.Add(strEigyoushoCode);
            lstString.Add(strSelectShohinCD);
            lstString.Add(strSelectMakerCD);
            lstString.Add(strSelectDaibunName);
            lstString.Add(strSelectChubunName);
            lstString.Add(strSelectid);

            ShouhinList_B shohinlistB = new ShouhinList_B();
            try
            {
                shohinlistB.getSelectItem(lstInt, lstString);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            setEndAction();
        }
        
        ///<summary>
        ///setTextData
        ///前画面のデータを記入
        ///</summary>
        private void setTextData()
        {
            if (strDaibunruiCode.Length >= 1)
            {
                labelSet_Daibunrui.CodeTxtText = strDaibunruiCode;

                //leaveの処理をする
                labelSet_Daibunrui.setTxtDaibunruiLeave();
                intDBjud = 1;
                setLabel(intDBjud);
            }
            if (strChubunruiCode.Length >= 1)
            {
                labelSet_Chubunrui.CodeTxtText = strChubunruiCode;

                //leaveの処理をする
                labelSet_Chubunrui.setTxtChubunruiLeave();
                intDBjud = 2;
                setLabel(intDBjud);
            }
            if (strMakerCode.Length >= 1)
            {
                labelSet_Maker.CodeTxtText = strMakerCode;
                intDBjud = 3;
                setLabel(intDBjud);
            }
            txtKensaku.Text = strKensaku;
        }
        
        ///<summary>
        ///btnEndClick
        ///戻るボタンを押したとき
        ///</summary>
        private void btnEndClick(object sender, EventArgs e)
        {
            setEndAction();
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction()
        {
            logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));

            this.Close();

            ShouhinList_B shohinlistB = new ShouhinList_B();
            try
            {
                shohinlistB.FormMove(intFrmKind);
            }
            catch (Exception ex)
            {
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

            List<int> lstInt = new List<int>();

            txtHon.Text = "";
            txtGihu.Text = "";

            gridTorihiki.Columns.Clear();

            //DataGridViewの初期設定
            setupGrid();

            //modeで判定して項目を追加
            setupStart();

            //データ渡し用
            lstInt.Add(0);

            setShohinView(lstInt);
        }


        ///<summary>
        ///setShohinView
        ///検索データを記入
        ///</summary>
        private void setShohinView(List<int> lstIntMode)
        {
            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();
            List<Boolean> lstBoolean = new List<Boolean>();

            gridTorihiki.Enabled = true;
            gridTorihiki.DataSource = null;
            DataTable dtView = new DataTable();

            decimal decHonsha = 0;

            //データ渡し用
            lstInt.Add(intFrmKind);
            lstInt.Add(lstIntMode[0]);

            lstString.Add(labelSet_Daibunrui.CodeTxtText);
            lstString.Add(labelSet_Chubunrui.CodeTxtText);
            lstString.Add(labelSet_Maker.CodeTxtText);
            lstString.Add(txtKensaku.Text);
            lstString.Add(txtHon.Text);
            lstString.Add(txtGihu.Text);

            lstBoolean.Add(chkNotToroku.Checked);

            ShouhinList_B shohinlistB = new ShouhinList_B();
            try
            {
                dtView = shohinlistB.getShohinView(lstInt, lstString, lstBoolean, blnZaikoKensaku);
                
                //在庫数の小数点以下を削除
                DataColumnCollection columns = dtView.Columns;
                                
                if (columns.Contains("本社在庫"))
                {
                    //指定日在庫、棚卸数量の小数点切り下げ
                    for (int cnt = 0; cnt < dtView.Rows.Count; cnt++)
                    {
                        //空だった場合
                        if (dtView.Rows[cnt]["本社在庫"].ToString() != "")
                        {
                            decHonsha = Math.Floor(decimal.Parse(dtView.Rows[cnt]["本社在庫"].ToString()));
                        }
                        else
                        {
                            decHonsha = 0;
                        }

                        dtView.Rows[cnt]["本社在庫"] = decHonsha.ToString();    
                        //ヘッダーを含まない特定のセルの背景色を赤色にする
                        this.gridTorihiki.Columns["本社在庫"].DefaultCellStyle.BackColor = Color.Red;
                    }
                }

                //if (columns.Contains("岐阜在庫"))
                //{
                //    //指定日在庫、棚卸数量の小数点切り下げ
                //    for (int cnt = 0; cnt < dtView.Rows.Count; cnt++)
                //    {
                //        decimal decHonsha = Math.Floor(decimal.Parse(dtView.Rows[cnt]["岐阜在庫"].ToString()));
                //        dtView.Rows[cnt]["岐阜在庫"] = decHonsha.ToString();
                //    }
                //}

                gridTorihiki.DataSource = dtView;
                this.gridTorihiki.Columns["コード"].Visible = false;
                this.gridTorihiki.Columns["大分類名"].Visible = false;

                lblRecords.Text = "該当件数(" + gridTorihiki.RowCount.ToString() + "件)";
                gridTorihiki.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///setLabel
        ///textboxのデータをlabelに記入
        ///</summary>
        private void setLabel(int intDBjud)
        {
            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();

            DataTable dtSetData = new DataTable();

            //データ渡し用
            lstString.Add(labelSet_Daibunrui.CodeTxtText);
            lstString.Add(labelSet_Chubunrui.CodeTxtText);
            lstString.Add(labelSet_Maker.CodeTxtText);

            lstInt.Add(intDBjud);

            ShouhinList_B shohinlistB = new ShouhinList_B();
            try
            {
                dtSetData = shohinlistB.getLabel(lstString, lstInt);

                //テキストボックスが空白のままの場合
                if (dtSetData == null)
                {
                    return;
                }

                if (dtSetData.Rows.Count != 0)
                {
                    switch (intDBjud)
                    {
                        case 1://大分類
                            labelSet_Daibunrui.CodeTxtText = dtSetData.Rows[0]["大分類コード"].ToString();
                            labelSet_Daibunrui.ValueLabelText = dtSetData.Rows[0]["大分類名"].ToString();
                            break;
                        case 2://中分類
                            labelSet_Chubunrui.CodeTxtText = dtSetData.Rows[0]["中分類コード"].ToString();
                            labelSet_Chubunrui.ValueLabelText = dtSetData.Rows[0]["中分類名"].ToString();
                            break;
                        case 3://メーカー
                            labelSet_Maker.CodeTxtText = dtSetData.Rows[0]["メーカーコード"].ToString();
                            labelSet_Maker.ValueLabelText = dtSetData.Rows[0]["メーカー名"].ToString();
                            break;
                        default:
                            return;
                    }
                    //初期化
                    intDBjud = 0;
                }
                else
                {
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    switch (intDBjud)
                    {
                        case 1://大分類
                            labelSet_Daibunrui.CodeTxtText = "";
                            labelSet_Daibunrui.Focus();
                            break;
                        case 2://中分類
                            labelSet_Chubunrui.CodeTxtText = "";
                            labelSet_Chubunrui.Focus();
                            break;
                        case 3://メーカー
                            labelSet_Maker.CodeTxtText = "";
                            labelSet_Maker.Focus();
                            break;
                        default:
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///btnHonshaZaikoClick
        ///本社在庫ボタン
        ///</summary>
        private void btnHonshaZaikoClick(object sender, EventArgs e)
        {
            //データ渡し用
            List<int> lstInt = new List<int>();

            txtHon.Text = "1";

            //データ渡し用
            lstInt.Add(1);

            setShohinView(lstInt);

            ////処理部に移動
            //ShouhinList_B shohinlistB = new ShouhinList_B();
            ////戻り値のDatatableを取り込む
            //shohinlistB.ZaikoClick(lstString);

            //gridTorihiki.Columns.Clear();

            ////DataGridViewの初期設定
            //setupGrid();

            ////modeで判定して項目を追加
            //setStart();

            //setShohinView(0);

            //txtHon.Text = "";
        }

        ///<summary>
        ///btnGifuZaikoClick
        ///岐阜在庫ボタン
        ///</summary>
        private void btnGifuZaikoClick(object sender, EventArgs e)
        {
            //データ渡し用
            List<int> lstInt = new List<int>();

            txtGihu.Text = "1";

            //データ渡し用
            lstInt.Add(2);

            setShohinView(lstInt);

            ////処理部に移動
            //ShouhinList_B shohinlistB = new ShouhinList_B();
            ////戻り値のDatatableを取り込む
            //shohinlistB.ZaikoClick(lstString);
        }

        ///<summary>
        ///ZaikoClick
        ///岐阜在庫ボタン
        ///</summary>
        private void ZaikoClick(string mode)
        {
            string strWhere;

        }

        ///<summary>
        ///setDaibunrui
        ///取り出したデータをテキストボックスに配置（大分類）
        ///</summary>
        public void setDaibunrui(DataTable dtSelectData)
        {
            labelSet_Daibunrui.CodeTxtText = dtSelectData.Rows[0]["大分類コード"].ToString();
            labelSet_Daibunrui.ValueLabelText = dtSelectData.Rows[0]["大分類名"].ToString();
        }

        ///<summary>
        ///setCyubunrui
        ///取り出したデータをテキストボックスに配置（中分類）
        ///</summary>
        public void setChubunrui(DataTable dtSelectData)
        {
            labelSet_Chubunrui.CodeTxtText = dtSelectData.Rows[0]["中分類コード"].ToString();
            labelSet_Chubunrui.ValueLabelText = dtSelectData.Rows[0]["中分類名"].ToString();
        }

        ///<summary>
        ///setMakerCode
        ///取り出したデータをテキストボックスに配置（メーカー）
        ///</summary>
        public void setMakerCode(DataTable dtSelectData)
        {
            labelSet_Maker.CodeTxtText = dtSelectData.Rows[0]["メーカーコード"].ToString();
            labelSet_Maker.ValueLabelText = dtSelectData.Rows[0]["メーカー名"].ToString();
        }

        ///<summary>
        ///setDaibunruiListClose
        ///DaibunruiiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setDaibunruiListClose()
        {
            labelSet_Daibunrui.Focus();
        }

        ///<summary>
        ///setChubunruiListClose
        ///ChubunruiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setChubunruiListClose()
        {
            labelSet_Chubunrui.Focus();
        }

        ///<summary>
        ///setMakerListClose
        ///MakerListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setMakerListClose()
        {
            labelSet_Maker.Focus();
        }


        ///<summary>
        ///txtDaibunruiLieave
        ///code入力箇所からフォーカスが外れた時(大分類)
        ///</summary>
        private void judDaibunruiLieave(object sender, EventArgs e)
        {
            intDBjud = 1;
            labelSet_Daibunrui.ValueLabelText = "";
            setLabel(intDBjud);
        }

        ///<summary>
        ///txtCyubunruiLieave
        ///code入力箇所からフォーカスが外れた時(中分類)
        ///</summary>
        private void judCyubunruiLieave(object sender, EventArgs e)
        {
            intDBjud = 2;
            labelSet_Chubunrui.ValueLabelText = "";
            setLabel(intDBjud);
        }

        ///<summary>
        ///txtMakerLieave
        ///code入力箇所からフォーカスが外れた時(メーカー)
        ///</summary>
        private void judMakerLieave(object sender, EventArgs e)
        {
            intDBjud = 3;
            labelSet_Maker.ValueLabelText = "";
            setLabel(intDBjud);
        }

        ///<summary>
        ///setChubun
        ///中分類のチェック
        ///</summary>
        public void setChubun()
        {
            labelSet_Chubunrui.setTxtChubunruiLeave();
        }
    }
}
