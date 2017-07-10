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
using static KATO.Common.Util.CommonTeisu;
using KATO.Common.Business;
using KATO.Common.Util;
using System.Security.Permissions;

namespace KATO.Common.Form
{
    ///<summary>
    ///TorihikikbnList
    ///取引区分リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class TorihikikbnList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //取引区分のラベルセットとテキストセットを確保する用
        LabelSet_Torihikikbn lblSetTorikbn = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //フォームタイトル設定
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
        ///TorihikikbnList
        ///フォームの初期設定（通常のテキストボックスから）
        ///</summary>
        public TorihikikbnList(Control c)
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
        ///TorihikikbnList
        ///フォームの初期設定（通常のテキストボックスから）
        ///</summary>
        public TorihikikbnList(Control c, LabelSet_Torihikikbn lblSetTorikbnSelect)
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
            lblSetTorikbn = lblSetTorikbnSelect;

            InitializeComponent();

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;
        }

        ///<summary>
        ///DaiBunruiList_Load
        ///読み込み時
        ///</summary>
        private void TorihikikbnList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "取引区分リスト";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = "F12:戻る";

            //データグリッドビューの準備
            setupGrid();

            //データグリッドビュー表示
            setDatagridView();
        }

        ///<summary>
        ///setupGrid
        ///データグリッドビューの準備
        ///</summary>
        private void setupGrid()
        {
            //列自動生成禁止
            gridSeihin.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn tantoushaCD = new DataGridViewTextBoxColumn();
            tantoushaCD.DataPropertyName = "取引区分コード";
            tantoushaCD.Name = "取引区分コード";
            tantoushaCD.HeaderText = "コード";

            DataGridViewTextBoxColumn tantoushaName = new DataGridViewTextBoxColumn();
            tantoushaName.DataPropertyName = "取引区分名";
            tantoushaName.Name = "取引区分名";
            tantoushaName.HeaderText = "取引区分名";

            //バインドしたデータを追加
            gridSeihin.Columns.Add(tantoushaCD);
            gridSeihin.Columns.Add(tantoushaName);

            //個々の幅、文章の寄せ
            gridSeihin.Columns["取引区分コード"].Width = 80;
            gridSeihin.Columns["取引区分コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridSeihin.Columns["取引区分コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridSeihin.Columns["取引区分名"].Width = 180;
            gridSeihin.Columns["取引区分名"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridSeihin.Columns["取引区分名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        private void setDatagridView()
        {
            //ビジネス層のインスタンス生成
            TorihikikbnList_B torikbnListB = new TorihikikbnList_B();
            try
            {
                //データグリッドビューに表示
                gridSeihin.DataSource = torikbnListB.getDatagridView();

                //中央揃え
                gridSeihin.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //検索件数を表示
                lblRecords.Text = "該当件数( " + gridSeihin.RowCount.ToString() + "件)";

                //件数が0の場合
                if (lblRecords.Text == "0")
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
        ///judDaiBunruiListKeyDown
        ///キー入力判定
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
        ///setGridSeihinDoubleClick
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
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
        private void setEndAction(List<string> lstSelectCd)
        {
            //データグリッドビューからデータを選択且つセット系から来た場合(ラベルセットの場合)
            if (lblSetTorikbn != null && lstSelectCd.Count != 0)
            {
                //セットの中に検索結果データを入れる
                lblSetTorikbn.CodeTxtText = lstSelectCd[0];
                lblSetTorikbn.ValueLabelText = lstSelectCd[1];
            }

            this.Close();

            //処理部に移動
            TorihikikbnList_B torikbnListB = new TorihikikbnList_B();
            try
            {
                torikbnListB.FormMove(intFrmKind);
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
        ///gridSeihin_CellDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void gridSeihin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void setSelectItem()
        {
            //検索結果にデータが存在しなければ終了
            if (gridSeihin.RowCount == 0)
            {
                return;
            }

            //データ渡し用
            List<string> lstSelectId = new List<string>();

            //選択行の取引区分取得
            string strSelectId = (string)gridSeihin.CurrentRow.Cells["取引区分コード"].Value;
            string strSelectName = (string)gridSeihin.CurrentRow.Cells["取引区分名"].Value;

            //検索情報を入れる
            lstSelectId.Add(strSelectId);
            lstSelectId.Add(strSelectName);

            //処理部に移動
            TorihikikbnList_B torikbnListB = new TorihikikbnList_B();
            try
            {
                torikbnListB.getSelectItem(intFrmKind, strSelectId);

                setEndAction(lstSelectId);
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
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
