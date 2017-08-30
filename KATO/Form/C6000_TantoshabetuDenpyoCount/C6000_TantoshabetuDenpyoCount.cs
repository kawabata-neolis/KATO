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
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.C6000_TantoshabetuDenpyoCount;

namespace KATO.Form.C6000_TantoshabetuDenpyoCount
{
    ///<summary>
    ///C6000_TantoshabetuDenpyoCount
    ///担当者別伝票処理件数フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class C6000_TantoshabetuDenpyoCount : BaseForm
    {
        //担当者別伝票処理件数画面内にある複数のテキストボックスの判断
        int intSelectTextBox = 0;

        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///C6000_TantoshabetuDenpyoCount
        ///フォームの初期設定
        ///</summary>
        public C6000_TantoshabetuDenpyoCount(Control c)
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
        ///C6000_TantoshabetuDenpyoCount_Load
        ///画面レイアウト設定
        ///</summary>
        private void C6000_TantoshabetuDenpyoCount_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "担当者別伝票処理件数";
            //フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            //初期値の設定
            txtDenpyoOpen.setUp(0);
            txtDenpyoClose.setUp(0);
            txtTantoshaCdOpen.Text = "0000";
            txtTantoshaCdClose.Text = "9999";
            txtPrintCount.Text = "1";

            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridViewData.AutoGenerateColumns = false;

            //カラム名の指定
            DataGridViewTextBoxColumn TantoshaName = new DataGridViewTextBoxColumn();
            TantoshaName.DataPropertyName = "担当者名";
            TantoshaName.Name = "担当者名";
            TantoshaName.HeaderText = "担当者名";

            //カラム名の指定
            DataGridViewTextBoxColumn Juchu = new DataGridViewTextBoxColumn();
            Juchu.DataPropertyName = "受注計";
            Juchu.Name = "受注計";
            Juchu.HeaderText = "受注";

            //カラム名の指定
            DataGridViewTextBoxColumn Hachu = new DataGridViewTextBoxColumn();
            Hachu.DataPropertyName = "発注計";
            Hachu.Name = "発注計";
            Hachu.HeaderText = "発注";

            //カラム名の指定
            DataGridViewTextBoxColumn Shire = new DataGridViewTextBoxColumn();
            Shire.DataPropertyName = "仕入計";
            Shire.Name = "仕入計";
            Shire.HeaderText = "仕入";

            //カラム名の指定
            DataGridViewTextBoxColumn Uriage = new DataGridViewTextBoxColumn();
            Uriage.DataPropertyName = "売上計";
            Uriage.Name = "売上計";
            Uriage.HeaderText = "売上";

            //カラム名の指定
            DataGridViewTextBoxColumn Nyuko = new DataGridViewTextBoxColumn();
            Nyuko.DataPropertyName = "入庫計";
            Nyuko.Name = "入庫計";
            Nyuko.HeaderText = "入庫";

            //カラム名の指定
            DataGridViewTextBoxColumn Shuko = new DataGridViewTextBoxColumn();
            Shuko.DataPropertyName = "出庫計";
            Shuko.Name = "出庫計";
            Shuko.HeaderText = "出庫";

            //カラム名の指定
            DataGridViewTextBoxColumn Tantoshakei = new DataGridViewTextBoxColumn();
            Tantoshakei.DataPropertyName = "担当計";
            Tantoshakei.Name = "担当者計";
            Tantoshakei.HeaderText = "担当者計";

            //各カラムのバインド（文章の寄せ、カラム名の位置、フォーマット指定、横幅サイズ）
            setColumn(TantoshaName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 136);
            setColumn(Juchu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 136);
            setColumn(Hachu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 136);
            setColumn(Shire, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 136);
            setColumn(Uriage, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 136);
            setColumn(Nyuko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 136);
            setColumn(Shuko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 136);
            setColumn(Tantoshakei, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 136);

        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            //column設定
            gridViewData.Columns.Add(col);

            //カラム名が空でない場合
            if (gridViewData.Columns[col.Name] != null)
            {
                //横幅サイズの決定
                gridViewData.Columns[col.Name].Width = intLen;
                //文章の寄せ方向の決定
                gridViewData.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                //カラム名の位置の決定
                gridViewData.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                //フォーマットが指定されていた場合
                if (fmt != null)
                {
                    //フォーマットを指定
                    gridViewData.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }



        ///<summary>
        ///C6000_TantoshabetuDenpyoCount_KeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void C6000_TantoshabetuDenpyoCount_KeyDown(object sender, KeyEventArgs e)
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
                    this.setDataView();
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
                    printDenpyoCount();
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
        ///judTxtTantouTxtKeyDown
        ///キー入力判定（検索ありテキストボックス）
        ///</summary>
        private void judTxtTantouTxtKeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    showTantoushaList();
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
        /// judBtnClick
        /// ボタンの反応
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 表示
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setDataView();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printDenpyoCount();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///showTantoushaList
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void showTantoushaList()
        {
            //openの方のテキストボックスの場合
            if(this.ActiveControl.Name == "txtTantoshaCdOpen")
            {
                intSelectTextBox = 1;
            }
            //closeの方のテキストボックスの場合
            else
            {
                intSelectTextBox = 2;
            }

            //担当者リストのインスタンス生成
            TantoushaList tantoushalist = new TantoushaList(this, intSelectTextBox);
            try
            {
                //担当者区分リストの表示、画面IDを渡す
                tantoushalist.StartPosition = FormStartPosition.Manual;
                tantoushalist.intFrmKind = CommonTeisu.FRM_TANTOSHABETUDENPYOCOUNT;
                tantoushalist.ShowDialog();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///setTantoushaOpen
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setTantoushaOpen(DataTable dtSelectData)
        {
            txtTantoshaCdOpen.Text = dtSelectData.Rows[0]["担当者コード"].ToString();
        }

        ///<summary>
        ///setTantoushaClose
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setTantoushaClose(DataTable dtSelectData)
        {
            txtTantoshaCdClose.Text = dtSelectData.Rows[0]["担当者コード"].ToString();
        }

        ///<summary>
        ///CloseTantoshaList
        ///担当者リストが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void CloseTantoshaList(int intSelectTextBox)
        {
            //openのテキストボックスの場合
            if (intSelectTextBox == 1)
            {
                txtTantoshaCdOpen.Focus();
            }
            //closeのテキストボックスの場合
            else
            {
                txtTantoshaCdClose.Focus();
            }
        }

        ///<summary>
        ///txtTantoshaCdOpen_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void txtTantoshaCdOpen_Leave(object sender, EventArgs e)
        {
            this.txtTantoshaCdOpen.Text = this.txtTantoshaCdOpen.Text.ToString().PadLeft(4, '0');
        }

        ///<summary>
        ///txtTantoshaCdClose_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void txtTantoshaCdClose_Leave(object sender, EventArgs e)
        {
            this.txtTantoshaCdClose.Text = this.txtTantoshaCdClose.Text.ToString().PadLeft(4, '0');
        }

        /// <summary>
        /// setDataView
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setDataView()
        {
            //データ検索用
            List<string> lstUriageSuiiLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //各取り出しデータ
            int intJuchu = 0;
            int intHachu = 0;
            int intShire = 0;
            int intUriage = 0;
            int intNyuko = 0;
            int intShuko = 0;
            int intTanto = 0;


            C6000_TantoshabetuDenpyoCount_B denpyocountB = new C6000_TantoshabetuDenpyoCount_B();
            try
            {
                dtSetView = denpyocountB.getData(txtDenpyoOpen.Text, txtDenpyoClose.Text, txtTantoshaCdOpen.Text, txtTantoshaCdClose.Text);

                gridViewData.DataSource = dtSetView;

                //datagridviewの行数分ループ
                for (int intRcnt = 1; intRcnt < gridViewData.RowCount; intRcnt++)
                {
                    intJuchu = intJuchu + (int)Math.Floor(double.Parse(gridViewData[1, intRcnt].Value.ToString()));
                    txtJuchuKei.Text = string.Format("{0:#,0}", intJuchu);

                    intHachu = intHachu + (int)Math.Floor(double.Parse(gridViewData[2, intRcnt].Value.ToString()));
                    txtHachu.Text = string.Format("{0:#,0}", intHachu);

                    intShire = intShire + (int)Math.Floor(double.Parse(gridViewData[3, intRcnt].Value.ToString()));
                    txtShire.Text = string.Format("{0:#,0}", intShire);

                    intUriage = intUriage + (int)Math.Floor(double.Parse(gridViewData[4, intRcnt].Value.ToString()));
                    txtUriage.Text = string.Format("{0:#,0}", intUriage);

                    intNyuko = intNyuko + (int)Math.Floor(double.Parse(gridViewData[5, intRcnt].Value.ToString()));
                    txtNyuko.Text = string.Format("{0:#,0}", intNyuko);

                    intShuko = intShuko + (int)Math.Floor(double.Parse(gridViewData[6, intRcnt].Value.ToString()));
                    txtShuko.Text = string.Format("{0:#,0}", intShuko);

                    intTanto = intTanto + (int)Math.Floor(double.Parse(gridViewData[7, intRcnt].Value.ToString()));
                    txtTanto.Text = string.Format("{0:#,0}", intTanto);

                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            gridViewData.DataSource = "";

            txtDenpyoOpen.Focus();
        }

        ///<summary>
        ///printDenpyoCount
        ///印刷ダイアログ
        ///</summary>
        private void printDenpyoCount()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //PDF作成後の入れ物
            string strFile = "";

            //検索開始日確保
            DateTime dateOpen;
            //検索終了日確保
            DateTime dateClose;
            
            //各取り出しデータ
            int intJuchu = 0;
            int intHachu = 0;
            int intShire = 0;
            int intUriage = 0;
            int intNyuko = 0;
            int intShuko = 0;
            int intTanto = 0;

            //合計データ用
            List<string> lstKei = new List<string>();

            //ビジネス層のインスタンス生成
            C6000_TantoshabetuDenpyoCount_B denpyocountB = new C6000_TantoshabetuDenpyoCount_B();
            try
            {
                //初期値
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, YOKO);

                pf.ShowDialog(this);
                pf.intPrintCnt = int.Parse(txtPrintCount.Text);

                //入力項目の記入に漏れがある場合
                if (txtDenpyoOpen.blIsEmpty() == false || 
                    txtDenpyoClose.blIsEmpty() == false ||
                    txtTantoshaCdOpen.blIsEmpty() == false ||
                    txtTantoshaCdClose.blIsEmpty() == false)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

                //データの取得
                dtSetCd_B = denpyocountB.getData(txtDenpyoOpen.Text, txtDenpyoClose.Text, txtTantoshaCdOpen.Text, txtTantoshaCdClose.Text);

                //取得したデータがない場合
                if (dtSetCd_B.Rows.Count == 0 || dtSetCd_B == null)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "対象のデータはありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

                //datagridviewの行数分ループ
                for (int intRcnt = 0; intRcnt < dtSetCd_B.Rows.Count; intRcnt++)
                {
                    intJuchu = intJuchu + (int)Math.Floor(double.Parse(dtSetCd_B.Rows[intRcnt]["受注計"].ToString()));

                    intHachu = intHachu + (int)Math.Floor(double.Parse(dtSetCd_B.Rows[intRcnt]["発注計"].ToString()));

                    intShire = intShire + (int)Math.Floor(double.Parse(dtSetCd_B.Rows[intRcnt]["仕入計"].ToString()));

                    intUriage = intUriage + (int)Math.Floor(double.Parse(dtSetCd_B.Rows[intRcnt]["売上計"].ToString()));

                    intNyuko = intNyuko + (int)Math.Floor(double.Parse(dtSetCd_B.Rows[intRcnt]["入庫計"].ToString()));

                    intShuko = intShuko + (int)Math.Floor(double.Parse(dtSetCd_B.Rows[intRcnt]["出庫計"].ToString()));

                    intTanto = intTanto + (int)Math.Floor(double.Parse(dtSetCd_B.Rows[intRcnt]["担当計"].ToString()));
                }

                //合計データをまとめる
                lstKei.Add(intJuchu.ToString());
                lstKei.Add(intHachu.ToString());
                lstKei.Add(intShire.ToString());
                lstKei.Add(intUriage.ToString());
                lstKei.Add(intNyuko.ToString());
                lstKei.Add(intShuko.ToString());
                lstKei.Add(intTanto.ToString());
                
                //表示する年月日の取得、編集
                dateOpen = DateTime.Parse(txtDenpyoOpen.Text);
                dateClose = DateTime.Parse(txtDenpyoClose.Text);

                //プレビューの場合
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    //結果セットをレコードセットに
                    strFile = denpyocountB.dbToPdf(dtSetCd_B, dateOpen, dateClose, txtTantoshaCdOpen.Text, txtTantoshaCdClose.Text, lstKei);
                    
                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    strFile = denpyocountB.dbToPdf(dtSetCd_B, dateOpen, dateClose, txtTantoshaCdOpen.Text, txtTantoshaCdClose.Text, lstKei);

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

        ///<summary>
        ///txtTantoshabetuDenpyoCount_KeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void txtTantoshabetuDenpyoCount_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
