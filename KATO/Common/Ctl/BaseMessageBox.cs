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

namespace KATO.Common.Ctl
{
    public partial class BaseMessageBox : System.Windows.Forms.Form
    {
        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //何のメッセージを表示するかの判定
        public int intMessageJud = 0;

        public int intFrmWidth = 0;
        public int intFrmHeight = 0;


        public BaseMessageBox()
        {
            InitializeComponent();

        }


        public BaseMessageBox(Control c, String strText, String strLabel , int intBtnCnt , int intIcon)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;

            //最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ボタンの指定
            switch (intBtnCnt)
            {
                //ボタン0
                case 0:
                    break;
                //OKボタン
                case 1:
                    baseButtonG1_OK.Visible = true;
                    break;
                //YES,NOボタン
                case 2:
                    baseButtonG2_YES.Visible = true;
                    baseButtonG2_NO.Visible = true;
                    break;
                //YES,NO,CANCELボタン
                case 3:
                    baseButtonG3_YES.Visible = true;
                    baseButtonG3_NO.Visible = true;
                    baseButtonG3_CANCEL.Visible = true;
                    break;
                default:
                    break;
            }

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;

            // 描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width * 2, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //アイコンの指定
            switch(intIcon)
            {
                case 0:
                    //システムの情報アイコン(WIN32: IDI_INFORMATION)
                    g.DrawIcon(SystemIcons.Information, 0, 0);
                    break;
                case 1:
                    //システムのエラーアイコン(WIN32: IDI_ERROR)
                    g.DrawIcon(SystemIcons.Error, 0, 0);
                    break;
                case 2:
                    //システムの感嘆符アイコン(WIN32: IDI_EXCLAMATION)
                    g.DrawIcon(SystemIcons.Exclamation, 0, 0);
                    break;
                case 3:
                    //システムの疑問符アイコン(WIN32: IDI_QUESTION)
                    g.DrawIcon(SystemIcons.Question, 0, 0);
                    break;
                default:
                    return;
            }
            //PictureBox1に表示する
            pictureBox1.Image = canvas;

            g.Dispose();

            this.Text = strText;
            baseLabel1.Text = strLabel;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
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



        private void baseButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
