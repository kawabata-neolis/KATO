using KATO.Business.D0680_UriageJissekiKakuninAS400;
using KATO.Common.Ctl;
using KATO.Common.Util;
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

namespace KATO.Form.D0680_UriageJissekiKakuninAS400
{

    ///<summary>
    ///D0680_UriageJissekiKakuninAS400
    ///売上実績確認（AS400）
    ///作成者：TMSOL太田
    ///作成日：2017/07/03
    ///更新者：
    ///更新日：
    ///</summary>
    public partial class D0680_UriageJissekiKakuninAS400 : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private int intFrm;

        /// <summary>
        /// D0680_UriageJissekiKakuninAS400
        /// フォーム関係の設定
        /// </summary>
        /// <param name="c"></param>
        /// <param name="intFrm">画面ID</param>
        public D0680_UriageJissekiKakuninAS400(Control c, int intFrm = 0)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

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
            this.Left = c.Left;
            this.Top = c.Top;

            // 画面IDをセット
            this.intFrm = intFrm;
        }

        private void D0680_UriageJissekiKakuninAS400_Load(object sender, EventArgs e)
        {

            this.Show();
            this._Title = "売上実績確認（AS400）";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;
            // F9:検索ボタン無効
            this.btnF09.Enabled = false;

            // 初期表示
            labelSet_Tokuisaki.Focus();

            // 伝票年月日の設定
            txtCalendarYMDEnd.Text = "2005/04/30";
            DateTime dateYMDEnd = DateTime.Parse(txtCalendarYMDEnd.Text);
            txtCalendarYMDStart.Text = dateYMDEnd.AddMonths(-1).ToString().Substring(0, 8) + "01";

            // DataGridViewの初期設定
            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {

            //列自動生成禁止
            gridTorihiki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn day = new DataGridViewTextBoxColumn();
            day.DataPropertyName = "処理日付";
            day.Name = "処理日付";
            day.HeaderText = "日付";

            DataGridViewTextBoxColumn DenpyoNo = new DataGridViewTextBoxColumn();
            DenpyoNo.DataPropertyName = "伝票番号";
            DenpyoNo.Name = "伝票番号";
            DenpyoNo.HeaderText = "伝№";

            DataGridViewTextBoxColumn Shinamei_katasiki = new DataGridViewTextBoxColumn();
            Shinamei_katasiki.DataPropertyName = "型番";
            Shinamei_katasiki.Name = "型番";
            Shinamei_katasiki.HeaderText = "品名・型式";

            DataGridViewTextBoxColumn Suuryou = new DataGridViewTextBoxColumn();
            Suuryou.DataPropertyName = "数量";
            Suuryou.Name = "数量";
            Suuryou.HeaderText = "数量";

            DataGridViewTextBoxColumn UriageTanka = new DataGridViewTextBoxColumn();
            UriageTanka.DataPropertyName = "売上単価";
            UriageTanka.Name = "売上単価";
            UriageTanka.HeaderText = "売上単価";

            DataGridViewTextBoxColumn UriageKingaku = new DataGridViewTextBoxColumn();
            UriageKingaku.DataPropertyName = "売上金額";
            UriageKingaku.Name = "売上金額";
            UriageKingaku.HeaderText = "売上金額";

            DataGridViewTextBoxColumn Bikou = new DataGridViewTextBoxColumn();
            Bikou.DataPropertyName = "備考";
            Bikou.Name = "備考";
            Bikou.HeaderText = "備  考";

            DataGridViewTextBoxColumn Tekiyou = new DataGridViewTextBoxColumn();
            Tekiyou.DataPropertyName = "摘要";
            Tekiyou.Name = "摘要";
            Tekiyou.HeaderText = "摘  要";

            DataGridViewTextBoxColumn TokuisakiName = new DataGridViewTextBoxColumn();
            TokuisakiName.DataPropertyName = "得意先名";
            TokuisakiName.Name = "得意先名";
            TokuisakiName.HeaderText = "得意先名";



            //個々の幅、文章の寄せ
            setColumn(day, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(DenpyoNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 80);
            setColumn(Shinamei_katasiki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 350);
            setColumn(Suuryou, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#0.00", 80);
            setColumn(UriageTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 120);
            setColumn(UriageKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumn(Bikou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(Tekiyou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(TokuisakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,300);
           
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
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
        /// <summary>
        /// judTextboxKeyDown
        /// キー入力判定(テキストボックス【labelset及びカレンダ以外全て】)
        /// </summary>
        private void judTextboxKeyDown(object sender, KeyEventArgs e)
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
                    // タブ機能
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
        /// D0680_UriageJissekiKakuninAS400
        /// キー入力判定
        /// </summary>
        private void D0680_UriageJissekiKakuninAS400_KeyDown(object sender, KeyEventArgs e)
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
                    this.showUriageJisseki();
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
                case STR_BTN_F01: // 追加
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.showUriageJisseki();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// showUriageJisseki
        /// データグリッドビューにデータを表示
        /// </summary>
        private void showUriageJisseki()
        {
            //データ検索用
            List<string> lstUriageSuiiLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //空文字判定（得意先コード、品番・型番、備考、開始伝票年月日、終了伝票年月日）
            if (labelSet_Tokuisaki.CodeTxtText == "" && txtSinamei_KatabanS.Text == "" && txtBikouS.Text == "" && txtCalendarYMDStart.blIsEmpty() == false && txtCalendarYMDEnd.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT,"条件を指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tokuisaki.codeTxt.Focus();
                return;
            }

            //得意先チェック
            if (labelSet_Tokuisaki.chkTxtTokuisaki())
            {
                labelSet_Tokuisaki.Focus();

                return;
            }

            //開始年月日がある場合
            if (txtCalendarYMDStart.blIsEmpty() == true)
            {
                //日付フォーマット生成、およびチェック
                strYMDformat = txtCalendarYMDStart.chkDateDataFormat(txtCalendarYMDStart.Text);

                //開始年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtCalendarYMDStart.Focus();

                    return;
                }
                else
                {
                    txtCalendarYMDStart.Text = strYMDformat;
                }
            }
            
            //初期化
            strYMDformat = "";

            //終了年月日がある場合
            if (txtCalendarYMDEnd.blIsEmpty() == true)
            {
                //日付フォーマット生成、およびチェック
                strYMDformat = txtCalendarYMDEnd.chkDateDataFormat(txtCalendarYMDEnd.Text);

                //終了年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtCalendarYMDEnd.Focus();

                    return;
                }
                else
                {
                    txtCalendarYMDEnd.Text = strYMDformat;
                }
            }

            //ビジネス層のインスタンス生成
            D0680_UriageJissekiKakuninAS400_B uriagejissekiB = new D0680_UriageJissekiKakuninAS400_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                /*[0]開始伝票年月日*/
                lstUriageSuiiLoad.Add(txtCalendarYMDStart.Text);
                /*[1]終了伝票年月日*/
                lstUriageSuiiLoad.Add(txtCalendarYMDEnd.Text);
                /*[2]得意先コード*/
                lstUriageSuiiLoad.Add(labelSet_Tokuisaki.CodeTxtText);
                /*[3]品番・型番*/

                //数値チェック
                double dblKensaku = 0;
                string strUkata;
                if (!double.TryParse(txtSinamei_KatabanS.Text, out dblKensaku))
                {
                    //そのまま確保
                    strUkata = txtSinamei_KatabanS.Text;
                }
                else
                {
                    //空白削除
                    strUkata = txtSinamei_KatabanS.Text.Trim();
                }

                //英字を大文字に
                strUkata = strUkata.ToUpper();

                strUkata = strUkata.Replace(" ", "");

                //lstUriageSuiiLoad.Add(txtSinamei_KatabanS.Text);
                lstUriageSuiiLoad.Add(strUkata);
                /*[4]備考*/
                lstUriageSuiiLoad.Add(txtBikouS.Text);

                gridTorihiki.Visible = false;

                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = uriagejissekiB.getUriageJissekiList(lstUriageSuiiLoad);

                //データを配置（datagridview)
                gridTorihiki.DataSource = dtSetView;

                if (dtSetView.Rows.Count > 0)
                {
                    for (int cnt = 0; cnt < gridTorihiki.RowCount; cnt++)
                    {
                        // 数量
                        decimal decSuuryo = decimal.Parse(gridTorihiki.Rows[cnt].Cells["数量"].Value.ToString());

                        // 金額・粗利
                        decimal decKingaku = decimal.Parse(gridTorihiki.Rows[cnt].Cells["売上金額"].Value.ToString());

                        // 数量又は金額・粗利がマイナスの場合はフォントカラーを変更
                        if (decSuuryo < 0 || decKingaku < 0)
                        {
                            gridTorihiki.Rows[cnt].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }

                    Control cNow = this.ActiveControl;
                    cNow.Focus();
                }

                gridTorihiki.Visible = true;

            }
            catch (Exception ex)
            {
                //エラーロギング
                gridTorihiki.Visible = true;
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
            string strKikanStart = txtCalendarYMDStart.Text;
            string strKikanEnd = txtCalendarYMDEnd.Text;

            // 画面の項目内を白紙にする
            delFormClear(this, gridTorihiki);

            txtCalendarYMDStart.Text = strKikanStart;
            txtCalendarYMDEnd.Text = strKikanEnd;
            
            labelSet_Tokuisaki.Focus();
        }

       
    }
}
