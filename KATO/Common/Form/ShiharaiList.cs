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
using static KATO.Common.Util.CommonTeisu;
using System.Security.Permissions;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    ///<summary>
    ///ShiharaiList
    ///支払リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class ShiharaiList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //得意先コードの確保
        string strTokuiCdsub = null;

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

        ///<summary>
        ///ShiharaiList
        ///フォームの初期設定（通常のテキストボックスから）
        ///</summary>
        public ShiharaiList(Control c)
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

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;
        }

        ///<summary>
        ///ShiharaiList_Load
        ///画面レイアウト設定
        ///</summary>
        private void ShiharaiList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "支払リスト";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridTokui.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn YMD = new DataGridViewTextBoxColumn();
            YMD.DataPropertyName = "支払年月日";
            YMD.Name = "支払年月日";
            YMD.HeaderText = "年月日";

            DataGridViewTextBoxColumn shiresaki = new DataGridViewTextBoxColumn();
            shiresaki.DataPropertyName = "仕入先名";
            shiresaki.Name = "仕入先名";
            shiresaki.HeaderText = "仕入先名";

            DataGridViewTextBoxColumn shiharai = new DataGridViewTextBoxColumn();
            shiharai.DataPropertyName = "支払額";
            shiharai.Name = "支払額";
            shiharai.HeaderText = "支払額";

            DataGridViewTextBoxColumn denpyo = new DataGridViewTextBoxColumn();
            denpyo.DataPropertyName = "伝票番号";
            denpyo.Name = "伝票番号";
            denpyo.HeaderText = "伝票番号";

            //個々の幅、文章の寄せ
            setColumn(YMD, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(shiresaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumn(shiharai, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumn(denpyo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);

            //伝票番号の列を非表示にする
            gridTokui.Columns["伝票番号"].Visible = false;
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            //column設定
            gridTokui.Columns.Add(col);
            if (gridTokui.Columns[col.Name] != null)
            {
                gridTokui.Columns[col.Name].Width = intLen;
                gridTokui.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridTokui.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridTokui.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        private void setDatagridView()
        {
            //ビジネス層のインスタンス生成
            ShiharaiList_B shiharailistB = new ShiharaiList_B();
            try
            {
                //データグリッドビュー部分
                gridTokui.DataSource = shiharailistB.setDatagridView(labelSet_Tokuisaki.CodeTxtText);

                //表示数を記載
                lblRecords.Text = "該当件数( " + gridTokui.RowCount.ToString() + "件)";

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
        ///ShiharaiList_KeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void ShiharaiList_KeyDown(object sender, KeyEventArgs e)
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
            setEndAction();
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction()
        {
            this.Close();

            //ビジネス層のインスタンス生成
            ChokusosakiList_B chokusosakilistB = new ChokusosakiList_B();
            try
            {
                //ビジネス層、移動元フォームに移動するロジックに移動
                chokusosakilistB.FormMove(intFrmKind);
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
        ///setKensakuClick
        ///検索ボタンを押したとき
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "検索実行"));

            setDatagridView();

            strTokuiCdsub = labelSet_Tokuisaki.CodeTxtText;

            gridTokui.Focus();
        }

        ///<summary>
        ///gridTokui_DoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>        
        private void gridTokui_DoubleClick(object sender, EventArgs e)
        {
            setSelectItem();
        }

        private void gridTokui_KeyDown(object sender, KeyEventArgs e)
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
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void setSelectItem()
        {
            //取引コードを入れる用
            DataTable dtTorihikiCd = new DataTable();

            //検索結果にデータが存在しなければ終了
            if (gridTokui.RowCount == 0)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            ShiharaiList_B shiharailistB = new ShiharaiList_B();
            try
            {
                //ビジネス層、検索ロジックに移動
                shiharailistB.setSelectItem(intFrmKind, (gridTokui.CurrentRow.Cells["伝票番号"].Value).ToString());

                setEndAction();
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
