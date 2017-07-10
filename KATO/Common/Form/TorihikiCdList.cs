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
using KATO.Common.Ctl;
using KATO.Common.Business;
using KATO.Common.Util;
using System.Security.Permissions;

namespace KATO.Common.Form
{
    ///<summary>
    ///TorihikiCdList
    ///取引コードリスト
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class TorihikiCdList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
        ///TorihikiCdList
        ///フォームの初期設定(通常テキストボックス)
        ///</summary>
        public TorihikiCdList(Control c)
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

            radAgyo.Checked = true;
        }

        ///<summary>
        ///TorihikiCdList_Load
        ///画面レイアウト設定
        ///</summary>
        private void TorihikiCdList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "取引コードリスト";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF12.Text = "F12:戻る";
            this.btnF11.Text = "F11:検索";

            setupGrid();
        }

        ///<summary>
        ///SetUpGrid
        ///データグリッドビューの準備
        ///</summary>
        private void setupGrid()
        {
            //列自動生成禁止
            gridTorihiki.AutoGenerateColumns = false;

            //カラム情報の設定
            DataGridViewTextBoxColumn Cd = new DataGridViewTextBoxColumn();
            Cd.DataPropertyName = "コード";
            Cd.Name = "コード";
            Cd.HeaderText = "コード";

            //カラム情報を追加
            gridTorihiki.Columns.Add(Cd);

            //個々の幅、文章の寄せ
            gridTorihiki.Columns["コード"].Width = 100;
            gridTorihiki.Columns["コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridTorihiki.Columns["コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        ///<summary>
        ///judToriListKeyDown
        ///キー入力判定
        ///</summary>
        private void judToriListKeyDown(object sender, KeyEventArgs e)
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
        ///judGridToriKeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///</summary>
        private void judGridToriKeyDown(object sender, KeyEventArgs e)
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
            if (gridTorihiki.Rows.Count == 0)
            {
                return;
            }

            //データ渡し用
            List<string> lstSelectID = new List<string>();

            //選択行の担当者情報取得
            string strSelectId = (string)gridTorihiki.CurrentRow.Cells["コード"].Value;

            //担当者情報を入れる
            lstSelectID.Add(strSelectId);

            //ビジネス層のインスタンス生成
            TorihikiCdList_B torihikilistB = new TorihikiCdList_B();
            try
            {
                //ビジネス層、検索ロジックに移動
                torihikilistB.getSelectItem(intFrmKind, strSelectId);
                EndAction(lstSelectID);
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
            EndAction(lstString);
        }

        ///<summary>
        ///EndAction
        ///戻るボタンの処理
        ///</summary>
        private void EndAction(List<string> lstSelectCd)
        {
            this.Close();

            //ビジネス層のインスタンス生成
            TorihikiCdList_B torihikilistB = new TorihikiCdList_B();
            try
            {
                //画面終了処理
                torihikilistB.FormMove(intFrmKind);
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

            //記入情報検索用
            List<Boolean> lstBoolean = new List<Boolean>();

            //画面の取引コード検索情報取得
            lstBoolean.Add(radAgyo.Checked);
            lstBoolean.Add(radKagyo.Checked);
            lstBoolean.Add(radSagyo.Checked);
            lstBoolean.Add(radTagyo.Checked);
            lstBoolean.Add(radNagyo.Checked);
            lstBoolean.Add(radHagyo.Checked);
            lstBoolean.Add(radMagyo.Checked);
            lstBoolean.Add(radYagyo.Checked);
            lstBoolean.Add(radRagyo.Checked);
            lstBoolean.Add(radWagyo.Checked);

            //ビジネス層のインスタンス生成
            TorihikiCdList_B torihikilistB = new TorihikiCdList_B();
            try
            {
                //データグリッドビュー部分
                gridTorihiki.DataSource = torihikilistB.getKensaku(lstBoolean);

                //表示数を記載
                lblRecords.Text = "該当件数( " + gridTorihiki.RowCount.ToString() + "件)";

                gridTorihiki.Focus();

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
        ///gridTorihiki_DoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void gridTorihiki_DoubleClick(object sender, EventArgs e)
        {
            setSelectItem();
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
