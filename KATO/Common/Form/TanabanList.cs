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
    public partial class TanabanList : System.Windows.Forms.Form
    {
        //並び替えボタンの連続押しを防ぐ判定
        int intOrderCode = 1;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        public TanabanList()
        {
            InitializeComponent();
        }

        private void TanabanList_Load(object sender, EventArgs e)
        {
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

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
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void setEndAction()
        {
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


            //選択行の営業所コード取得
            string strSelectid = (string)dgvSeihin.CurrentRow.Cells[0].Value;

            //処理部に移動
            TanabanList_B tanabanlistB = new TanabanList_B();
            tanabanlistB.setSelectItem(intFrmKind, strSelectid);

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
