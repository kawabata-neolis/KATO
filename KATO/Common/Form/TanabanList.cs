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
using KATO.Common.Ctl;
using KATO.Common.Business;
using System.Security.Permissions;
using static KATO.Common.Util.CommonTeisu;


namespace KATO.Common.Form
{
    public partial class TanabanList : System.Windows.Forms.Form
    {
        LabelSet_Tanaban lblSetTanaban = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        public TanabanList(Control c)
        {
            if (c == null)
            {
                return;
            }
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
            this.Top = c.Top;
        }

        public TanabanList(Control c, LabelSet_Tanaban lblSetTanabanSelect)
        {
            if (c == null)
            {
                return;
            }
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            lblSetTanaban = lblSetTanabanSelect;
            InitializeComponent();

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
            this.Top = c.Top;
        }

        public string _Title
        {
            set
            {
                String[] aryTitle = new string[] { value };
                this.Text = string.Format(STR_TITLE, aryTitle);
            }
        }

        private void TanabanList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "棚番リスト";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = "F12:戻る";

            setDatagridView();
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        private void setDatagridView()
        {
            //処理部に移動
            TanabanList_B tanabanlistB = new TanabanList_B();
            //データグリッドビュー部分
            dgvSeihin.DataSource = tanabanlistB.setDatagridView();

            //幅の値を設定
            dgvSeihin.Columns["棚番"].Width = 150;
            dgvSeihin.Columns["棚番名"].Width = 150;

            //中央揃え
            dgvSeihin.Columns["棚番名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblRecords.Text = "該当件数( " + dgvSeihin.RowCount.ToString() + "件)";

            //件数が0の場合
            if (lblRecords.Text == "0")
            {
                //表示を変える
                MessageBox.Show("データが見つかりませんでした。");
                return;
            }
        }


        ///<summary>
        ///judTanabanListKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judTanabanListKeyDown(object sender, KeyEventArgs e)
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
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void btnEndClick(object sender, EventArgs e)
        {
            List<string> lstString = new List<string>();
            setEndAction(lstString);
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void setEndAction(List<string> lstString)
        {
            if (lblSetTanaban != null && lstString.Count != 0)
            {
                lblSetTanaban.CodeTxtText = lstString[0];
                lblSetTanaban.ValueLabelText = lstString[1];
            }

            //データ渡し用
            List<int> lstInt = new List<int>();

            //データ渡し用
            lstInt.Add(intFrmKind);

            this.Close();

            //処理部に移動
            TanabanList_B tanabanlistB = new TanabanList_B();
            tanabanlistB.setEndAction(intFrmKind);
        }

        ///<summary>
        ///setdgvEigyousyoDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void setdgvEigyousyoDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///judDgvTanabanKeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>        
        private void judDgvTanabanKeyDown(object sender, KeyEventArgs e)
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
        ///setdgvSeihinDoubleClick
        ///データグリッドビュー内のデータ選択後の処理
        ///作成者：大河内
        ///作成日：2017/3/6
        ///更新者：大河内
        ///更新日：2017/3/6
        ///カラム論理名
        ///</summary>        
        private void setSelectItem()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //選択行の営業所コード取得
            string strSelectid = (string)dgvSeihin.CurrentRow.Cells[0].Value;
            string strSelectName = (string)dgvSeihin.CurrentRow.Cells[1].Value;

            //データ渡し用
            lstString.Add(strSelectid);
            lstString.Add(strSelectName);

            //処理部に移動
            TanabanList_B tanabanlistB = new TanabanList_B();
            tanabanlistB.setSelectItem(intFrmKind, strSelectid);

            setEndAction(lstString);
        }

        // タイトルバーの閉じるボタン、コントロールボックスの「閉じる」、Alt + F4 を無効
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
