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
        LabelSet_Tantousha lblSetTantousha = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        /// <summary>
        /// TantoushaList
        /// 前画面からデータ受け取り(通常テキストボックス)
        /// </summary>
        public TantoushaList(Control c)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = "F12:戻る";

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
            this.Top = c.Top;
        }

        /// <summary>
        /// TantoushaList
        /// 前画面からデータ受け取り(セットテキストボックス)
        /// </summary>
        public TantoushaList(Control c, LabelSet_Tantousha lblSetTantouSelect)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            lblSetTantousha = lblSetTantouSelect;
            InitializeComponent();

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = "F12:戻る";

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
            this.Top = c.Top;
        }

        /// <summary>
        /// _Title
        /// タイトルプロパティを決める
        /// </summary>
        public string _Title
        {
            set
            {
                String[] aryTitle = new string[] { value };
                this.Text = string.Format(STR_TITLE, aryTitle);
            }
        }

        /// <summary>
        /// TantousyaList_Load
        /// 初回読み込み
        /// </summary>
        private void TantousyaList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "担当者リスト";

            SetUpGrid();

            setDatagridView();
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
            DataTable dtView = new DataTable();

            //処理部に移動
            TantoushaList_B daibunlistB = new TantoushaList_B();
            try
            {
                dtView = daibunlistB.setViewGrid();

                //目標売上を整数型に
                for (int cnt = 0; cnt < dtView.Rows.Count; cnt++)
                {
                    decimal decTyoubosuu = Math.Floor(decimal.Parse(dtView.Rows[cnt]["年間売上目標"].ToString()));
                    dtView.Rows[cnt]["年間売上目標"] = decTyoubosuu.ToString();

                    if (dtView.Rows[cnt]["営業所コード"].ToString() == "0001")
                    {
                        dtView.Rows[cnt]["営業所コード"] = "本社";
                    }
                    else if (dtView.Rows[cnt]["営業所コード"].ToString() == "0002")
                    {
                        dtView.Rows[cnt]["営業所コード"] = "岐阜";
                    }
                }

                //データグリッドビュー部分
                gridTantousha.DataSource = dtView;

                lblRecords.Text = "該当件数( " + gridTantousha.RowCount.ToString() + "件)";

            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }

            //件数が0の場合
            if (lblRecords.Text == "0")
            {
                //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
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
            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();

            //選択行の担当者情報取得
            string strSelectId = (string)gridTantousha.CurrentRow.Cells["担当者コード"].Value;
            string strSelectName = (string)gridTantousha.CurrentRow.Cells["担当者名"].Value;

            lstInt.Add(intFrmKind);
            lstString.Add(strSelectId);
            lstString.Add(strSelectName);

            setEndAction(lstString);
        }
        
        ///<summary>
        ///btnEndClick
        ///戻るボタンを押したとき
        ///</summary>
        private void btnEndClick(object sender, EventArgs e)
        {
            List<string> lstString = new List<string>();
            setEndAction(lstString);
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction(List<string> lstString)
        {
            if (lblSetTantousha != null && lstString.Count != 0)
            {
                lblSetTantousha.CodeTxtText = lstString[0];
                lblSetTantousha.ValueLabelText = lstString[1];
            }

            this.Close();

            //データ渡し用
            List<int> lstInt = new List<int>();

            //データ渡し用
            lstInt.Add(intFrmKind);
        }

        /// <summary>
        /// CreateParams
        ///データグリッドビュー内のデータをダブルクリックしたとき
        /// </summary>
        private void setGridTanDblClick(object sender, EventArgs e)
        {
            setSelectItem();
        }

        /// <summary>
        /// CreateParams
        // タイトルバーの閉じるボタン、コントロールボックスの「閉じる」、Alt + F4 を無効
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
