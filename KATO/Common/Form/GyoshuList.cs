using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Util;
using KATO.Common.Business;
using static KATO.Common.Util.CommonTeisu;
using System.Security.Permissions;

namespace KATO.Common.Form
{
    ///<summary>
    ///DaibunruiList
    ///大分類リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class GyoshuList : System.Windows.Forms.Form
    {
        //作成する場合、変更
        //LabelSet_Daibunrui lblSetDaibun = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        /// <summary>
        /// GyoshuList
        /// フォーム関係の設定（通常のテキストボックスから）
        /// </summary>
        public GyoshuList(Control c)
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

        //作成する場合、変更
        ///// <summary>
        ///// GyoshuList
        ///// フォーム関係の設定（ラベルセットから）
        ///// </summary>
        //public GyoshuList(Control c, LabelSet_Daibunrui lblSetDaibunSelect)
        //{
        //    if (c == null)
        //    {
        //        return;
        //    }

        //    int intWindowWidth = c.Width;
        //    int intWindowHeight = c.Height;

        //    lblSetDaibun = lblSetDaibunSelect;
        //    InitializeComponent();

        //    //ウィンドウ位置をマニュアル
        //    this.StartPosition = FormStartPosition.Manual;
        //    //親画面の中央を指定
        //    this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
        //    this.Top = c.Top;
        //}

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

        /// <summary>
        /// GyoshuList_Load
        /// 読み込み時
        /// </summary>
        private void GyoshuList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "業種リスト";
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
            //処理部に移動
            GyoshuList_B gyoshulistB = new GyoshuList_B();
            try
            {
                //データグリッドビュー部分
                gridSeihin.DataSource = gyoshulistB.setDatagridView();

                //幅の値を設定
                gridSeihin.Columns["業種コード"].Width = 100;
                gridSeihin.Columns["業種名"].Width = 150;

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
        ///judGyoshuListKeyDown
        ///キー入力判定
        ///</summary>
        private void judGyoshuListKeyDown(object sender, KeyEventArgs e)
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
            List<string> lstString = new List<string>();
            setEndAction(lstString);
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction(List<string> lstString)
        {
            //作成する場合変更
            //if (lblSetDaibun != null && lstString.Count != 0)
            //{
            //    lblSetDaibun.CodeTxtText = lstString[0];
            //    lblSetDaibun.ValueLabelText = lstString[1];
            //}

            this.Close();

            //データ渡し用
            List<int> lstInt = new List<int>();

            //データ渡し用
            lstInt.Add(intFrmKind);

            //処理部に移動
            DaibunruiList_B daibunlistB = new DaibunruiList_B();
            try
            {
                daibunlistB.setEndAction(lstInt);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///setGridSeihinDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        public void setGridSeiDblClick(object sender, EventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///judGridSeihinKeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///</summary>        
        private void judGridSeihinKeyDown(object sender, KeyEventArgs e)
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

//リストからメインの動き
//登録削除関係

        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void setSelectItem()
        {
            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();

            //選択行の大分類コード取得
            string strSelectId = (string)gridSeihin.CurrentRow.Cells["業種コード"].Value;
            string strSelectName = (string)gridSeihin.CurrentRow.Cells["業種名"].Value;

            lstInt.Add(intFrmKind);
            lstString.Add(strSelectId);
            lstString.Add(strSelectName);

            //処理部に移動
            GyoshuList_B gyoshulistB = new GyoshuList_B();
            try
            {
                gyoshulistB.setSelectItem(lstInt, lstString);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
            setEndAction(lstString);
        }

        ///<summary>
        ///CreateParams
        ///タイトルバーの閉じるボタン、コントロールボックスの「閉じる」、Alt + F4 を無効
        ///</summary>
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
