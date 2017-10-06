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
using System.Security.Permissions;
using KATO.Common.Ctl;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Common.Form
{
    ///<summary>
    ///MenuList
    ///メニューリストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class MenuList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //メニューコードの確保
        LabelSet_Menu lblSetMenu = null;

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
        ///MenuList
        ///フォームの初期設定（通常のテキストボックスから）
        ///</summary>
        public MenuList(Control c)
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

        /// <summary>
        /// MakerList
        /// フォームの初期設定（ラベルセットから）
        /// </summary>
        public MenuList(Control c, LabelSet_Menu lblSetMenuSelect)
        {
            //画面データが解放されていた時の対策
            if (c == null)
            {
                return;
            }

            //画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            //ラベルセットデータの確保
            lblSetMenu = lblSetMenuSelect;

            InitializeComponent();

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;
        }


        ///<summary>
        ///MenuList_Load
        ///画面レイアウト設定
        ///</summary>
        private void MenuList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "frmMenuList";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = "F12:戻る";

            setupGrid();

            setDatagridView();
        }

        ///<summary>
        ///setupGrid
        ///DataGridView初期設定
        ///</summary>
        private void setupGrid()
        {
            //列自動生成禁止
            gridMenu.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn PgNo = new DataGridViewTextBoxColumn();
            PgNo.DataPropertyName = "ＰＧ番号";
            PgNo.Name = "ＰＧ番号";
            PgNo.HeaderText = "PgNo";

            DataGridViewTextBoxColumn PgName = new DataGridViewTextBoxColumn();
            PgName.DataPropertyName = "ＰＧ名";
            PgName.Name = "ＰＧ名";
            PgName.HeaderText = "プログラム名";

            DataGridViewTextBoxColumn comment = new DataGridViewTextBoxColumn();
            comment.DataPropertyName = "コメント";
            comment.Name = "コメント";
            comment.HeaderText = "コメント";

            //個々の幅、文章の寄せ
            setColumn(PgNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(PgName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumn(comment, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null , 400);
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            //column設定
            gridMenu.Columns.Add(col);
            //カラム名が空でない場合
            if (gridMenu.Columns[col.Name] != null)
            {
                //横幅サイズの決定
                gridMenu.Columns[col.Name].Width = intLen;
                //文章の寄せ方向の決定
                gridMenu.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                //カラム名の位置の決定
                gridMenu.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                //フォーマットが指定されていた場合
                if (fmt != null)
                {
                    //フォーマットを指定
                    gridMenu.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        private void setDatagridView()
        {
            //取得したデータの編集を行う用
            DataTable dtView = new DataTable();

            //ビジネス層のインスタンス生成
            MenuList_B menulistB = new MenuList_B();
            try
            {
                //検索データを取得
                dtView = menulistB.getViewGrid();


                //データグリッドビューに表示
                gridMenu.DataSource = dtView;

                //検索件数を表示
                lblRecords.Text = "該当件数( " + gridMenu.RowCount.ToString() + "件)";

                //件数が0の場合
                if (gridMenu.RowCount == 0)
                {
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
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
        ///MenuList_KeyDown
        ///キー入力判定
        ///</summary>
        private void MenuList_KeyDown(object sender, KeyEventArgs e)
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
                    //戻るボタン
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

            //戻るボタンの処理に行くために必要（直接も戻る動作のため中身無し）
            List<string> lstString = new List<string>();

            //戻るボタンの処理
            setEndAction(lstString);
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction(List<string> lstSelectId)
        {
            ////データグリッドビューからデータを選択且つセット系から来た場合
            //if (lblSetMenu != null && lstSelectId.Count != 0)
            //{
            //    //ＰＧ番号が0の場合
            //    if (lstSelectId[0] == "0")
            //    {
            //        lblSetMenu.CodeTxtText = "0";
            //        lblSetMenu.ValueLabelText = "";
            //    }
            //    else
            //    {
            //        //セットの中に検索結果データを入れる
            //        lblSetMenu.CodeTxtText = lstSelectId[0];
            //        lblSetMenu.ValueLabelText = lstSelectId[1];
            //    }
            //}

            this.Close();

            //ビジネス層のインスタンス生成
            MenuList_B menulistB = new MenuList_B();
            try
            {
                //画面終了処理
                menulistB.FormMove(intFrmKind);
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
        ///gridMenu_CellDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void gridMenu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///gridMenu_KeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///</summary>        
        private void gridMenu_KeyDown(object sender, KeyEventArgs e)
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

        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void setSelectItem()
        {
            //検索結果にデータが存在しなければ終了
            if (gridMenu.RowCount == 0)
            {
                return;
            }

            //選択行の担当者情報
            List<string> lstSelectId = new List<string>();

            //選択行の担当者情報取得
            string strSelectNo = (string)gridMenu.CurrentRow.Cells["ＰＧ番号"].Value.ToString();
            string strSelectName = (string)gridMenu.CurrentRow.Cells["ＰＧ名"].Value;

            //検索情報を入れる
            lstSelectId.Add(strSelectNo);
            lstSelectId.Add(strSelectName);

            //ビジネス層のインスタンス生成
            MenuList_B menuListB = new MenuList_B();
            try
            {
                //ビジネス層、検索ロジックに移動
                menuListB.getSelectItem(intFrmKind, strSelectNo);

                setEndAction(lstSelectId);
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
