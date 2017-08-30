using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Ctl;
using static KATO.Common.Util.CommonTeisu;
using KATO.Common.Business;
using KATO.Common.Util;

namespace KATO.Common.Form
{
    ///<summary>
    ///TantoushaList
    ///担当者リスト
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class TantoushaList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //メーカーコードの確保（セット系用）
        LabelSet_Tantousha lblSetTantousha = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //担当者別伝票処理件数画面内にある複数のテキストボックスの判断
        int intSelectTextBox = 0;

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
        ///TantoushaList
        ///フォームの初期設定(通常テキストボックス)
        ///</summary>
        public TantoushaList(Control c)
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
            this.Top = c.Top + 130;
        }

        ///<summary>
        ///TantoushaList
        ///フォームの初期設定(セットテキストボックス)
        ///</summary>
        public TantoushaList(Control c, LabelSet_Tantousha lblSetTantouSelect)
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
            lblSetTantousha = lblSetTantouSelect;

            InitializeComponent();
            
            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 130;
        }

        ///<summary>
        ///TantoushaList
        ///フォームの初期設定(セットテキストボックス)
        ///</summary>
        public TantoushaList(Control c, LabelSet_Tantousha lblSetTantouSelect, object obj)
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
            lblSetTantousha = lblSetTantouSelect;

            InitializeComponent();

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 30;
        }

        ///<summary>
        ///TantoushaList
        ///フォームの初期設定(担当者別伝票処理件数の通常テキストボックス)
        ///</summary>
        public TantoushaList(Control c, int intSelect)
        {
            //画面データが解放されていた時の対策
            if (c == null)
            {
                return;
            }

            //open、closeのどっちのテキストボックスかの判断
            intSelectTextBox = intSelect;

            //画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 130;
        }

        ///<summary>
        ///TantousyaList_Load
        ///画面レイアウト設定
        ///</summary>
        private void TantousyaList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "担当者リスト";

            //データグリッドビューの準備
            SetUpGrid();

            //データグリッドビュー表示
            setDatagridView();

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF12.Text = "F12:戻る";
        }

        ///<summary>
        ///SetUpGrid
        ///データグリッドビューの準備
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridTantousha.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn tantoushaCD = new DataGridViewTextBoxColumn();
            tantoushaCD.DataPropertyName = "担当者コード";
            tantoushaCD.Name = "担当者コード";
            tantoushaCD.HeaderText = "コード";

            DataGridViewTextBoxColumn tantoushaName = new DataGridViewTextBoxColumn();
            tantoushaName.DataPropertyName = "担当者名";
            tantoushaName.Name = "担当者名";
            tantoushaName.HeaderText = "担当者名";

            DataGridViewTextBoxColumn eigyoushoCD = new DataGridViewTextBoxColumn();
            eigyoushoCD.DataPropertyName = "営業所コード";
            eigyoushoCD.Name = "営業所コード";
            eigyoushoCD.HeaderText = "営業所";

            DataGridViewTextBoxColumn chubanmoji = new DataGridViewTextBoxColumn();
            chubanmoji.DataPropertyName = "注番文字";
            chubanmoji.Name = "注番文字";
            chubanmoji.HeaderText = "注番文字";

            DataGridViewTextBoxColumn groupCD = new DataGridViewTextBoxColumn();
            groupCD.DataPropertyName = "グループコード";
            groupCD.Name = "グループコード";
            groupCD.HeaderText = "グループ";

            DataGridViewTextBoxColumn uriageMokuhyo = new DataGridViewTextBoxColumn();
            uriageMokuhyo.DataPropertyName = "年間売上目標";
            uriageMokuhyo.Name = "年間売上目標";
            uriageMokuhyo.HeaderText = "売上目標金額";

            //バインドしたデータを追加
            gridTantousha.Columns.Add(tantoushaCD);
            gridTantousha.Columns.Add(tantoushaName);
            gridTantousha.Columns.Add(eigyoushoCD);
            gridTantousha.Columns.Add(chubanmoji);
            gridTantousha.Columns.Add(groupCD);
            gridTantousha.Columns.Add(uriageMokuhyo);

            //個々の幅、文章の寄せ
            gridTantousha.Columns["担当者コード"].Width = 80;
            gridTantousha.Columns["担当者コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridTantousha.Columns["担当者コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridTantousha.Columns["担当者名"].Width = 200;
            gridTantousha.Columns["担当者名"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridTantousha.Columns["担当者名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridTantousha.Columns["営業所コード"].Width = 100;
            gridTantousha.Columns["営業所コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridTantousha.Columns["営業所コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridTantousha.Columns["注番文字"].Width = 100;
            gridTantousha.Columns["注番文字"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridTantousha.Columns["注番文字"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridTantousha.Columns["グループコード"].Width = 100;
            gridTantousha.Columns["グループコード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridTantousha.Columns["グループコード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridTantousha.Columns["年間売上目標"].Width = 150;
            gridTantousha.Columns["年間売上目標"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridTantousha.Columns["年間売上目標"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            TantoushaList_B daibunlistB = new TantoushaList_B();
            try
            {
                //検索データを取得
                dtView = daibunlistB.getViewGrid();

                //目標売上を整数型に
                for (int cnt = 0; cnt < dtView.Rows.Count; cnt++)
                {
                    
                    decimal decTyoubosuu = Math.Floor(decimal.Parse(dtView.Rows[cnt]["年間売上目標"].ToString()));
                    dtView.Rows[cnt]["年間売上目標"] = decTyoubosuu.ToString();

                    //営業所コードが0001の場合
                    if (dtView.Rows[cnt]["営業所コード"].ToString() == "0001")
                    {
                        dtView.Rows[cnt]["営業所コード"] = "本社";
                    }
                    //営業所コードが0002の場合
                    else if (dtView.Rows[cnt]["営業所コード"].ToString() == "0002")
                    {
                        dtView.Rows[cnt]["営業所コード"] = "岐阜";
                    }
                }

                //データグリッドビューに表示
                gridTantousha.DataSource = dtView;

                //検索件数を表示
                lblRecords.Text = "該当件数( " + gridTantousha.RowCount.ToString() + "件)";

                //件数が0の場合
                if (gridTantousha.RowCount == 0)
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
        ///judTantouListKeyDown
        ///キー入力判定
        ///</summary>
        private void judTantouListKeyDown(object sender, KeyEventArgs e)
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
        ///judGridTantouKeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///</summary>        
        private void judGridTantouKeyDown(object sender, KeyEventArgs e)
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
            if (gridTantousha.RowCount == 0)
            {
                return;
            }

            //選択行の担当者情報
            List<string> lstSelectId = new List<string>();

            //選択行の担当者情報取得
            string strSelectId = (string)gridTantousha.CurrentRow.Cells["担当者コード"].Value;
            string strSelectName = (string)gridTantousha.CurrentRow.Cells["担当者名"].Value;

            //検索情報を入れる
            lstSelectId.Add(strSelectId);
            lstSelectId.Add(strSelectName);

            //ビジネス層のインスタンス生成
            TantoushaList_B tantoushaListB = new TantoushaList_B();
            try
            {
                //ビジネス層、検索ロジックに移動
                tantoushaListB.getSelectItem(intFrmKind, strSelectId, intSelectTextBox);

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
            //データグリッドビューからデータを選択且つセット系から来た場合
            if (lblSetTantousha != null && lstSelectCd.Count != 0)
            {
                //セットの中に検索結果データを入れる
                lblSetTantousha.CodeTxtText = lstSelectCd[0];
                lblSetTantousha.ValueLabelText = lstSelectCd[1];
            }

            this.Close();

            //ビジネス層のインスタンス生成
            TantoushaList_B tantoushalistB = new TantoushaList_B();
            try
            {
                //画面終了処理
                tantoushalistB.FormMove(intFrmKind, intSelectTextBox);
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
        ///gridTantousha_CellDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void gridTantousha_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///CreateParams
        ///タイトルバーの閉じるボタン、コントロールボックスの「閉じる」、Alt + F4 を無効
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
    }
}
