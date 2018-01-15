using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Common.Business;
using KATO.Form.F0140_TanaorosiInput;
using static KATO.Common.Util.CommonTeisu;
using System.Security.Permissions;
using KATO.Common.Ctl;
using KATO.Business.TokuteimukesakiTankaList_B;

namespace KATO.Common.Form
{
    ///<summary>
    ///TokuteimukesakiTankaList
    ///特定向先単価リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class TokuteimukesakiTankaList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //前画面から商品コードを取り出す枠（商品コード初期値）（ベーステキスト）
        public BaseText btxtShohinCd = null;

        //前画面から仕向け先を取り出す枠（仕向け先初期値）（ラベルセット）
        public LabelSet_Torihikisaki lsShimuke = null;

        //前画面から単価を取り出す枠（単価初期値）（ベーステキストマネー）
        public BaseTextMoney btmTanka = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //画面タイトル設定
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
        /// TokuteimukesakiTankaList
        /// フォームの初期設定
        /// </summary>
        public TokuteimukesakiTankaList(Control c, string strKataban, string strShohinCd)
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

            //型番の挿入
            txtKataban.Text = strKataban;

            //強制値
            lblsetTorihikisakiCd.CodeTxtText = "1800";

            //商品コードの挿入
            txtShohinCd.Text = strShohinCd;
        }

        /// <summary>
        /// ChokusosakiList_Load
        ///画面レイアウト設定
        /// </summary>
        private void ChokusosakiList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "特定向け先単価リスト";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            //DataGridViewの初期設定
            SetUpGrid();
            
            //型番がある場合は検索
            if (txtKataban.blIsEmpty() == true)
            {
                //データグリッドビューに表示
                getDatagridView();

            }

            //グリッドの中身がない場合の初期フォーカス位置の変更
            if (gridSeihin.RowCount == 0)
            {
                //データがないの発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                btnF12.Focus();
                return;

            }
        }

        ///<summary>
        ///SetUpGrid
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridSeihin.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn TokuisakiCd = new DataGridViewTextBoxColumn();
            TokuisakiCd.DataPropertyName = "得意先コード";
            TokuisakiCd.Name = "得意先コード";
            TokuisakiCd.HeaderText = "得意先コード";

            DataGridViewTextBoxColumn ShimukesakiName = new DataGridViewTextBoxColumn();
            ShimukesakiName.DataPropertyName = "仕向先";
            ShimukesakiName.Name = "仕向先";
            ShimukesakiName.HeaderText = "仕向先";

            DataGridViewTextBoxColumn Maker = new DataGridViewTextBoxColumn();
            Maker.DataPropertyName = "ﾒｰｶｰ";
            Maker.Name = "ﾒｰｶｰ";
            Maker.HeaderText = "ﾒｰｶｰ";

            DataGridViewTextBoxColumn Kataban = new DataGridViewTextBoxColumn();
            Kataban.DataPropertyName = "型番";
            Kataban.Name = "型番";
            Kataban.HeaderText = "型番";

            DataGridViewTextBoxColumn Tanka = new DataGridViewTextBoxColumn();
            Tanka.DataPropertyName = "単価";
            Tanka.Name = "単価";
            Tanka.HeaderText = "単価";

            DataGridViewTextBoxColumn Saishushirebi = new DataGridViewTextBoxColumn();
            Saishushirebi.DataPropertyName = "最終仕入日";
            Saishushirebi.Name = "最終仕入日";
            Saishushirebi.HeaderText = "最終仕入日";

            DataGridViewTextBoxColumn ShiresakiCd = new DataGridViewTextBoxColumn();
            ShiresakiCd.DataPropertyName = "仕入先コード";
            ShiresakiCd.Name = "仕入先コード";
            ShiresakiCd.HeaderText = "仕入先コード";

            DataGridViewTextBoxColumn ShohinCd = new DataGridViewTextBoxColumn();
            ShohinCd.DataPropertyName = "商品コード";
            ShohinCd.Name = "商品コード";
            ShohinCd.HeaderText = "商品コード";
            
            //個々の幅、文章の寄せ（売上数非表示）
            setColumnSeihin(TokuisakiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnSeihin(ShimukesakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 320);
            setColumnSeihin(Maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnSeihin(Kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 570);
            setColumnSeihin(Tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 115);
            setColumnSeihin(Saishushirebi, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumnSeihin(ShiresakiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnSeihin(ShohinCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);

            //非表示項目
            TokuisakiCd.Visible = false;
            ShiresakiCd.Visible = false;
            ShohinCd.Visible = false;
        }

        ///<summary>
        ///gridSeihin
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumnSeihin(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridSeihin.Columns.Add(col);
            if (gridSeihin.Columns[col.Name] != null)
            {
                gridSeihin.Columns[col.Name].Width = intLen;
                gridSeihin.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridSeihin.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridSeihin.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///getDatagridView
        ///データグリッドビュー表示
        ///</summary>
        private void getDatagridView()
        {
            //表示するデータ
            DataTable dtTokune = new DataTable();

            //ビジネス層のインスタンス生成
            TokuteimukesakiTankaList_B tokumukesakitanlist = new TokuteimukesakiTankaList_B();
            try
            {
                //特値データの取り出し
                dtTokune = tokumukesakitanlist.getDatagridView(txtKataban.Text, lblsetTorihikisakiCd.CodeTxtText, txtShohinCd.Text);

                //データグリッドビュー部分
                gridSeihin.DataSource = tokumukesakitanlist.getDatagridView(txtKataban.Text, lblsetTorihikisakiCd.CodeTxtText, txtShohinCd.Text);

                //表示数を記載
                lblRecords.Text = "該当件数( " + gridSeihin.RowCount.ToString() + "件)";
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
        ///judDaiBunruiListKeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void judDaiBunruiListKeyDown(object sender, KeyEventArgs e)
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
        ///btnEndClick
        ///戻るボタンを押したとき
        ///</summary>
        private void btnEndClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));
            EndAction();
        }

        ///<summary>
        ///EndAction
        ///戻るボタンの処理
        ///</summary>
        private void EndAction()
        {
            this.Close();
        }

        ///<summary>
        ///setKensakuClick
        ///検索ボタンを押したとき
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "検索実行"));

            //データグリッドビューに表示
            getDatagridView();

            gridSeihin.Focus();
        }

        ///<summary>
        ///setGridSeihinDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>        
        private void gridChoku_DoubleClick(object sender, EventArgs e)
        {
            getSelectItem();
        }

        ///<summary>
        ///judGridSeihinKeyDown
        ///キー入力判定（グリッドビュー内）
        ///</summary>        
        private void judGridSeihinKeyDown(object sender, KeyEventArgs e)
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
                    getSelectItem();
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
                    this.btnKensakuClick(sender, e);
                    break;
                case Keys.F12:
                    //戻るボタン
                    this.btnEndClick(sender, e);
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///getSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void getSelectItem()
        {
            //検索結果にデータが存在しなければ終了
            if (gridSeihin.RowCount == 0)
            {
                return;
            }

            //仕向先名を取得
            lsShimuke.CodeTxtText = (string)gridSeihin.CurrentRow.Cells["得意先コード"].Value.ToString();

            //仕向先チェック及びラベルにデータ追加
            lsShimuke.chkTxtTorihikisaki();

            //単価の取得
            btmTanka.Text = (string)gridSeihin.CurrentRow.Cells["単価"].Value.ToString();
            btmTanka.setMoneyData(btmTanka.Text, 0);

            this.Close();
        }

        ///<summary>
        ///CreateParams
        ///タイトルバーの閉じるボタン、コントロールボックスの「閉じる」、Alt + F4 を無効
        ///</summary>        
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
    }
}
