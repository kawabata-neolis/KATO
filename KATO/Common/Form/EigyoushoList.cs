using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Form.TanaorosiInput;
using KATO.Common.Util;
using KATO.Common.Business;
using System.Security.Permissions;

namespace KATO.Common.Form
{
    public partial class EigyoushoList : System.Windows.Forms.Form
    {
        //並び替えボタンの連続押しを防ぐ判定
        int intOrderCode = 1;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        public EigyoushoList()
        {
            InitializeComponent();
        }

        private void EigyoushoList_Load(object sender, EventArgs e)
        {
            //列自動生成禁止
            dgvSeihin.AutoGenerateColumns = false;

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            //データをバインド
            DataGridViewTextBoxColumn gyoshuCD = new DataGridViewTextBoxColumn();
            gyoshuCD.DataPropertyName = "業種コード";
            gyoshuCD.Name = "業種コード";
            gyoshuCD.HeaderText = "業種コード";

            DataGridViewTextBoxColumn gyoshuName = new DataGridViewTextBoxColumn();
            gyoshuName.DataPropertyName = "業種名";
            gyoshuName.Name = "業種名";
            gyoshuName.HeaderText = "業種名";

            dgvSeihin.Columns.Add(gyoshuCD);
            dgvSeihin.Columns.Add(gyoshuName);

            setDatagridView();

            radioButton1.Checked = true;

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
            EigyoushoList_B eigyoulistB = new EigyoushoList_B();

            //データグリッドビュー部分
            dgvSeihin.DataSource = eigyoulistB.setDatagridView();

            //幅の値を設定
            dgvSeihin.Columns["業種コード"].Width = 150;
            dgvSeihin.Columns["業種名"].Width = 150;

            //中央揃え
            dgvSeihin.Columns["業種名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //検索件数を表示
            lblRecords.Text = "該当件数( " + dgvSeihin.RowCount.ToString() + "件)";

            //件数が0の場合
            if (lblRecords.Text.Equals("0"))
            {
                //表示を変える
                MessageBox.Show("データが見つかりませんでした。");
                return;
            }
        }


        ///<summary>
        ///judEigyoushoListKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judEigyoushoListKeyDown(object sender, KeyEventArgs e)
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
        ///setKensakuClick
        ///検索ボタンを押したとき
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void btnKensakuClick(object sender, EventArgs e)
        {
            //並び替えの準備
            ListSortDirection sortDirection = dgvSeihin.SortOrder == SortOrder.Ascending ?
            ListSortDirection.Ascending : ListSortDirection.Ascending;

            //コード昇順
            if (radioButton1.Checked == true)
            {
                if (intOrderCode != 1)
                {
                    setDatagridView();
                    dgvSeihin.Sort(dgvSeihin.Columns[0], sortDirection);
                }
                intOrderCode = 1;
            }
            //名前昇順
            else if (radioButton2.Checked == true)
            {
                if (intOrderCode != 2)
                {
                    setDatagridView();
                    dgvSeihin.Sort(dgvSeihin.Columns[1], sortDirection);
                }
                intOrderCode = 2;
            }
            else
            {
                MessageBox.Show("出力順が選択されていません");
                return;
            }
            dgvSeihin.Focus();
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
            setEndAction();
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        private void setEndAction()
        {
            this.Close();

            //処理部に移動
            EigyoushoList_B eigyoulistB = new EigyoushoList_B();
            //データグリッドビュー部分
            eigyoulistB.setEndAction(intFrmKind);
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
        public void setdgvEigyousyoDoubleClick(object sender, EventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///judDgvEigyoushoKeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>        
        private void judDgvEigyoushoKeyDown(object sender, KeyEventArgs e)
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
            if (intFrmKind == 0)
            {
                return;
            }

            //選択行の大分類コード取得
            string strSelectid = (string)dgvSeihin.CurrentRow.Cells[0].Value;

            //処理部に移動
            EigyoushoList_B eigyoulistB = new EigyoushoList_B();
            eigyoulistB.setSelectItem(intFrmKind, strSelectid);

            //選択行の営業所コード取得
            string selectid = (string)dgvSeihin.CurrentRow.Cells[0].Value;

            setEndAction();
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
