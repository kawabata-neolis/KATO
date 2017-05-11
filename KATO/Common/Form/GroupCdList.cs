using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using KATO.Common.Ctl;
using static KATO.Common.Util.CommonTeisu;
using KATO.Common.Business;
using KATO.Common.Util;

namespace KATO.Common.Form
{
    //修正中

    ///<summary>
    ///GroupCdList
    ///グループコードフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class groupCdList : System.Windows.Forms.Form
    {
        LabelSet_GroupCd lblSetGroupCd = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        ///<summary>
        ///GroupCdList
        /// フォーム関係の設定（通常のテキストボックスから）
        ///</summary>
        public groupCdList(Control c)
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

        /// <summary>
        /// DaibunruiList
        /// フォーム関係の設定（ラベルセットから）
        /// </summary>
        public groupCdList(Control c, LabelSet_GroupCd lblSetGroupCdSelect)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            lblSetGroupCd = lblSetGroupCdSelect;
            InitializeComponent();

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
            this.Top = c.Top;
        }

        /// <summary>
        /// _Title
        /// タイトルの設定
        /// </summary>
        public string _Title
        {
            set
            {
                String[] aryTitle = new string[] { value };
                this.Text = string.Format(STR_TITLE, aryTitle);
            }
        }

        private void GroupCdList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "グループコードリスト";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = "F12:戻る";

            setDatagridView();
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        private void setDatagridView()
        {
            GroupCdList_B groupcdlistB = new GroupCdList_B();
            try
            {
                //データグリッドビュー部分
                gridSeihin.DataSource = groupcdlistB.setDatagridView();

                //幅の値を設定
                gridSeihin.Columns["大分類コード"].Width = 150;
                gridSeihin.Columns["大分類名"].Width = 150;

                //中央揃え
                gridSeihin.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                lblRecords.Text = "該当件数( " + gridSeihin.RowCount.ToString() + "件)";

                //件数が0の場合
                if (lblRecords.Text == "0")
                {
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }                
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///judDaiBunruiListKeyDown
        ///キー入力判定
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
        ///</summary>
        private void btnEndClick(object sender, EventArgs e)
        {
//ここから
            List<string> lstString = new List<string>();
            //setEndAction(lstString);
        }

    }
}
