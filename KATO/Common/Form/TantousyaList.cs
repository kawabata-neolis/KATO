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
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Common.Form
{
    public partial class TantousyaList : System.Windows.Forms.Form
    {
        ////並び替えボタンの連続押しを防ぐ判定
        //int intOrderCode = 1;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        public TantousyaList()
        {
            InitializeComponent();
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

        }

        public string _Title
        {
            set
            {
                String[] aryTitle = new string[] { value };
                this.Text = string.Format(STR_TITLE, aryTitle);
            }
        }


        private void TantousyaList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "担当者リスト";

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
