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
    public partial class BaseDataGridViewEdit : DataGridView
    {
        public BaseDataGridViewEdit()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            //dataGridView 編集可能
            this.ReadOnly = false;

            //最下行を選択できないようにする
            this.AllowUserToAddRows = false;

            //TAB使用許可
            this.StandardTab = false;

            //選択モードをセル単位での選択のみにする
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;

            //DataGridView1の列の幅をユーザーが変更できるようにする
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

        }

        // tabキー押下時にセルの移動を下から右に変更する
        [System.Security.Permissions.UIPermission(
        System.Security.Permissions.SecurityAction.Demand,
        Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //Enterキーが押された時は、Tabキーが押されたようにする
            if ((keyData & Keys.KeyCode) == Keys.Enter)
            {
                return this.ProcessTabKey(keyData);
            }
            return base.ProcessDialogKey(keyData);
        }

        [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.Demand,
        Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            //Enterキーが押された時は、Tabキーが押されたようにする
            if (e.KeyCode == Keys.Enter)
            {
                return this.ProcessTabKey(e.KeyCode);
            }
            return base.ProcessDataGridViewKey(e);
        }

    }
}
