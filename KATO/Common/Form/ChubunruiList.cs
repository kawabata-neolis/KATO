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
using KATO.Form.TanaorosiInput;
using KATO.Form.M_Chubunrui;
using static KATO.Common.Util.CommonTeisu;
using System.Security.Permissions;

namespace KATO.Common.Form
{
    public partial class ChubunruiList : System.Windows.Forms.Form
    {
        //前画面から大分類コードを取り出す枠（初期値）
        public string strDaibunruiCode = "";

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        public ChubunruiList()
        {
            InitializeComponent();

        }

        private void CyokusousakiList_Load(object sender, EventArgs e)
        {
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            //テキストボックスに入れる
            txtDaibunrui.Text = strDaibunruiCode;

            setDatagridView();

        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void setDatagridView()
        {
            DataTable dtGetTable;

            //処理部に移動
            ChubunruiList_B chubunlistB = new ChubunruiList_B();
            //データグリッドビュー部分
            dgvSeihin.DataSource = chubunlistB.setDatagridView(txtDaibunrui.Text);
            //テキストボックス部分
            dtGetTable = chubunlistB.setText(txtDaibunrui.Text);

            //幅の値を設定
            //例
            dgvSeihin.Columns["中分類コード"].Width = 150;
            dgvSeihin.Columns["中分類名"].Width = 200;
            
            //中央揃え
            dgvSeihin.Columns["中分類名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //大分類コードと名前を表示
            txtDaibunrui.Text = dtGetTable.Rows[0]["大分類コード"].ToString();
            lblText.Text = dtGetTable.Rows[0]["大分類名"].ToString();

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
        ///judDaiBunruiListKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/3
        ///カラム論理名
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
        ///btnEndClick
        ///戻るボタンを押したとき
        ///作成者：大河内
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/3/2
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
        ///作成日：2017/3/6
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        private void setEndAction()
        {
            this.Close();

            //処理部に移動
            ChubunruiList_B chubunListB = new ChubunruiList_B();
            chubunListB.setEndAction(intFrmKind);
        }

        ///judTxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judDaibunruiKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtDaibunrui.TextLength == 2)
            {
                judDaibunruiLeave(sender, e);
            }
        }


        ///<summary>
        ///setKensakuClick
        ///検索ボタンを押したとき
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            setDatagridView();

        }

        ///<summary>
        ///judtxtCDTextLeave
        ///code入力箇所からフォーカスが外れた時
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        public void judDaibunruiLeave(object sender, EventArgs e)
        {
            if (txtDaibunrui.TextLength == 1)
            {
                txtDaibunrui.Text = txtDaibunrui.Text.ToString().PadLeft(2, '0');
            }
            else if (txtDaibunrui.Text == "")
            {
                return;
            }

            DataTable dtSetcode;

            //処理部に移動
            ChubunruiList_B chubunListB = new ChubunruiList_B();
            //テキストボックス部分
            dtSetcode = chubunListB.setName(txtDaibunrui.Text);

            if (dtSetcode.Rows.Count != 0)
            {
                lblText.Text = dtSetcode.Rows[0]["大分類名"].ToString();

                dgvSeihin.Focus();
            }
            else
            {
                MessageBox.Show("入力された文字列が正しくありません。", "入力項目", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }


        ///<summary>
        ///setdgvSeihinDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///作成者：大河内
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/3/6
        ///カラム論理名
        ///</summary>        
        private void setdgvSeihinDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///setdgvSeihinDoubleClick
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///作成者：大河内
        ///作成日：2017/3/6
        ///更新者：大河内
        ///更新日：2017/3/6
        ///カラム論理名
        ///</summary>        
        private void judDgvSeihinKeyDown(object sender, KeyEventArgs e)
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
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>        
        private void setSelectItem()
        {
            if (intFrmKind == 0)
            {
                return;
            }

            //選択行のcode取得
            string strSelectid = (string)dgvSeihin.CurrentRow.Cells["中分類コード"].Value;

            //処理部に移動
            ChubunruiList_B chubunListB = new ChubunruiList_B();
            chubunListB.setSelectItem(intFrmKind, txtDaibunrui.Text, strSelectid);
            
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
