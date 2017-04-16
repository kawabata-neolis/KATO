using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Form.M_Daibunrui;
using KATO.Form.M_Chubunrui;
using KATO.Form.M_Maker;
using KATO.Form.TanaorosiInput;
using KATO.Common.Util;
using KATO.Common.Business;
using System.Security.Permissions;

namespace KATO.Common.Form
{
    public partial class MakerList : System.Windows.Forms.Form
    {
        //前画面からメーカーコードを取り出す枠（初期値）
        public string strDaibunruiCode = "";

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        public MakerList()
        {
            InitializeComponent();
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

        }

        private void MakerList_Load(object sender, EventArgs e)
        {
            //テキストボックスに入れる
            txtDaibunrui.Text = strDaibunruiCode;

            lblDsp.TextAlign = ContentAlignment.MiddleLeft;

            if(txtDaibunrui.TextLength > 0)
            {
                btnKensakuClick(sender, e);
                judtxtDaibunTextLeave(sender, e);
            }
            else
            {
                setDatagridView();
            }

            radioButton1.Checked = true;

        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///作成者：大河内
        ///作成日：2017/3/6
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        public void setDatagridView()
        {
            //処理部に移動
            MakerList_B makerlistB = new MakerList_B();
            //データグリッドビュー部分
            dgvSeihin.DataSource = makerlistB.setDatagridView();

            //幅の値を設定
            dgvSeihin.Columns["メーカーコード"].Width = 150;
            dgvSeihin.Columns["メーカー名"].Width = 200;

            //中央揃え
            dgvSeihin.Columns["メーカー名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
        ///judMakerListKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/3/7
        ///更新者：大河内
        ///更新日：2017/3/7
        ///カラム論理名
        ///</summary>
        private void judMakerListKeyDown(object sender, KeyEventArgs e)
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
        ///setMoveOrder
        ///form内のエンターによるタブオーダー機能
        ///作成者：大河内
        ///作成日：2017/3/15
        ///更新者：大河内
        ///更新日：2017/3/15
        ///カラム論理名
        ///</summary>
        private void setMoveOrder(object sender, KeyEventArgs e)
        {
            //F1キーが押されたか調べる
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        ///<summary>
        ///btnKensakuClick
        ///検索ボタンを押したとき
        ///作成者：大河内
        ///作成日：2017/3/7
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            int RadioBtnJud = 0;

            //並び替え判定
            if (radioButton1.Checked == true)
            {
                RadioBtnJud = 1;
            }
            else
            {
                RadioBtnJud = 0;
            }

            //処理部に移動
            MakerList_B makerlistB = new MakerList_B();
            //データグリッドビュー部分
            dgvSeihin.DataSource = makerlistB.setKensaku(txtDaibunrui.Text,txtKensaku.Text,RadioBtnJud);

            lblRecords.Text = "該当件数( " + dgvSeihin.RowCount.ToString() + "件)";

            //幅の値を設定
            dgvSeihin.Columns["メーカーコード"].Width = 150;
            dgvSeihin.Columns["メーカー名"].Width = 200;

            dgvSeihin.Focus();
        }


        ///<summary>
        ///btnEndClick
        ///戻るボタンを押したとき
        ///作成者：大河内
        ///作成日：2017/3/7
        ///更新者：大河内
        ///更新日：2017/3/8
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
        ///作成日：2017/3/8
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        private void setEndAction()
        {
            this.Close();

            MakerList_B makerlistB = new MakerList_B();
            makerlistB.setEndAction(intFrmKind);
        }


        ///<summary>
        ///setDaibunruiTextChanged
        ///code入力項目の文字数が2文字以上になった場合
        ///作成者：大河内
        ///作成日：2017/3/7
        ///更新者：大河内
        ///更新日：2017/3/7
        ///カラム論理名
        ///</summary>
        private void setDaibunruiTextChanged(object sender, EventArgs e)
        {
            if (txtDaibunrui.TextLength == 2)
            {
                //txtKensaku.Focus();
            }
        }

        ///<summary>
        ///judtxtDaibunTextLeave
        ///code入力箇所からフォーカスが外れた時
        ///作成者：大河内
        ///作成日：2017/3/7
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judtxtDaibunTextLeave(object sender, EventArgs e)
        {
            DataTable dtGetTable = new DataTable();

            if (txtDaibunrui.Text == "")
            {
                lblDsp.Text = "";
                return;
            }
            else if (txtDaibunrui.TextLength == 1)
            {
                MessageBox.Show("入力された文字列が正しくありません。", "入力項目", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                ////0パティングする場合（予備）
                //txtDaibunrui.Text = txtDaibunrui.Text.ToString().PadLeft(2, '0');
            }
            else
            {
                MakerList_B makerlistB = new MakerList_B();
                dtGetTable = makerlistB.judtxtDaibunTextLeave(txtDaibunrui.Text);

                if (dtGetTable.Rows.Count == 0)
                {
                    MessageBox.Show("入力された文字列が正しくありません。", "入力項目", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //名前を表示
                    lblDsp.Text = dtGetTable.Rows[0]["大分類名"].ToString();
                    dgvSeihin.Focus();
                }
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
        ///作成日：2017/3/7
        ///更新者：大河内
        ///更新日：2017/3/7
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
        ///作成日：2017/3/7
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>        
        private void setSelectItem()
        {
            if (intFrmKind == 0)
            {
                return;
            }

            //選択行のcode取得
            string strSelectid = (string)dgvSeihin.CurrentRow.Cells["メーカーコード"].Value;

            MakerList_B makerlistB = new MakerList_B();
            makerlistB.setSelectItem(intFrmKind, strSelectid);

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
