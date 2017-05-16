using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Form.M1010_Daibunrui;
using KATO.Form.M1110_Chubunrui;
using KATO.Form.M1020_Maker;
using KATO.Form.F0140_TanaorosiInput;
using KATO.Common.Util;
using KATO.Common.Ctl;
using KATO.Common.Business;
using System.Security.Permissions;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Common.Form
{
    ///<summary>
    ///MakerList
    ///メーカーリストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class MakerList : System.Windows.Forms.Form
    {
        LabelSet_Maker lblSetMaker = null;

        //前画面からメーカーコードを取り出す枠（初期値）
        public string strDaibunruiCode = "";

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        /// <summary>
        /// MakerList
        /// フォーム関係の設定（通常のテキストボックスから）
        /// </summary>
        public MakerList(Control c)
        {
            if (c == null)
            {
                return;
            }
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();
            // フォームでもキーイベントを受け取る

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
            this.Top = c.Top;
        }

        /// <summary>
        /// MakerList
        /// フォーム関係の設定（ラベルセットから）
        /// </summary>
        public MakerList(Control c, LabelSet_Maker lblSetMakerSelect)
        {
            if (c == null)
            {
                return;
            }
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            lblSetMaker = lblSetMakerSelect;

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

        /// <summary>
        /// MakerList_Load
        /// 読み込み時
        /// </summary>
        private void MakerList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "メーカーリスト";

            //テキストボックスに入れる
            labelSet_Daibunrui1.CodeTxtText = strDaibunruiCode;

            if(labelSet_Daibunrui1.CodeTxtText.Length > 0)
            {
                btnKensakuClick(sender, e);
            }
            else
            {
                setDatagridView();
            }
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public void setDatagridView()
        {
            //処理部に移動
            MakerList_B makerlistB = new MakerList_B();
            try
            {
                //データグリッドビュー部分
                gridSeihin.DataSource = makerlistB.setDatagridView();

                //幅の値を設定
                gridSeihin.Columns["メーカーコード"].Width = 150;
                gridSeihin.Columns["メーカー名"].Width = 150;

                //中央揃え
                gridSeihin.Columns["メーカー名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //検索件数を表示
                lblRecords.Text = "該当件数( " + gridSeihin.RowCount.ToString() + "件)";

                //件数が0の場合
                if (lblRecords.Text.Equals("0"))
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
        ///judMakerListKeyDown
        ///キー入力判定
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
        ///</summary>
        private void setMoveOrder(object sender, KeyEventArgs e)
        {
            //エンターキーが押されたか調べる
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
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
            if (lblSetMaker != null && lstString.Count != 0)
            {
                lblSetMaker.CodeTxtText = lstString[0];
                lblSetMaker.ValueLabelText = lstString[1];
            }

            this.Close();

            //データ渡し用
            List<int> lstInt = new List<int>();

            //データ渡し用
            lstInt.Add(intFrmKind);

            MakerList_B makerlistB = new MakerList_B();
            try
            {
                makerlistB.setEndAction(lstInt);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///btnKensakuClick
        ///検索ボタンを押したとき
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();

            //データ渡し用
            lstString.Add(labelSet_Daibunrui1.CodeTxtText);
            lstString.Add(txtKensaku.Text);

            //処理部に移動
            MakerList_B makerlistB = new MakerList_B();
            try
            {
                //データグリッドビュー部分
                gridSeihin.DataSource = makerlistB.setKensaku(lstInt, lstString);

                lblRecords.Text = "該当件数( " + gridSeihin.RowCount.ToString() + "件)";

                gridSeihin.Focus();
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
        private void setGridSeihinDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///setGridSeihinDoubleClick
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
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void setSelectItem()
        {
            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();

            //選択行のcode取得
            string strSelectid = (string)gridSeihin.CurrentRow.Cells["メーカーコード"].Value;
            string strSelectName = (string)gridSeihin.CurrentRow.Cells["メーカー名"].Value;

            //データ渡し用
            lstInt.Add(intFrmKind);
            lstString.Add(strSelectid);
            lstString.Add(strSelectName);

            MakerList_B makerlistB = new MakerList_B();
            try
            {
                makerlistB.setSelectItem(lstInt, lstString);

                setEndAction(lstString);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
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
