using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Ctl
{
    public partial class BaseDataGridView : DataGridView
    {
        Boolean judLineSelect = true;

        public BaseDataGridView()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            //dataGridViewを編集させない
            this.ReadOnly = true;

            //最下行を選択できないようにする
            this.AllowUserToAddRows = false;

            //TAB使用時に別のセルに移動させない
            this.StandardTab = true;

            //選択モードを行単位での選択のみにする
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //DataGridView1の列の幅をユーザーが変更できないようにする
            this.AllowUserToResizeColumns = false;

            //DataGridView1の行の高さをユーザーが変更できないようにする
            this.AllowUserToResizeRows = false;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            //列ヘッダーを表示する
            this.ColumnHeadersVisible = true;

            //ヘッダーの色を変えるための準備
            this.EnableHeadersVisualStyles = false;

            //ヘッダーの色指定
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;

            //行ヘッダを非表示にする
            this.RowHeadersVisible = false;

            //ヘッダのフォント、フォントサイズはプロパティで変更
            if (judLineSelect == true)
            {
                //選択モードを行単位での選択のみにする
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            //列自動生成禁止
            this.AutoGenerateColumns = false;
        }

        /// <summary>
        /// BaseDataGridView_KeyDown
        /// キー入力判定
        /// </summary>
        private void BaseDataGridView_KeyDown(object sender, KeyEventArgs e)
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
                    //動作取り消し
                    e.Handled = true;
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
                    break;

                default:
                    break;
            }

        }
    }
}
