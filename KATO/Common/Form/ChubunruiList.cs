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
using KATO.Form.F0140_TanaorosiInput;
using KATO.Form.M1110_Chubunrui;
using static KATO.Common.Util.CommonTeisu;
using System.Security.Permissions;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    ///<summary>
    ///ChubunruiList
    ///中分類リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class ChubunruiList : System.Windows.Forms.Form
    {
        LabelSet_Chubunrui lblSetChubun = null;

        //大分類コードの確保
        string strdaibunCDsub = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        /// <summary>
        /// ChubunruiList
        /// フォーム関係の設定（通常のテキストボックスから）
        /// </summary>
        public ChubunruiList(Control c, string strdaibunCD)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //テキストボックスに入れる
            labelSet_Daibunrui.CodeTxtText = strdaibunCD;

            //大分類コードの確保
            strdaibunCDsub = strdaibunCD;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
            this.Top = c.Top;
        }

        /// <summary>
        /// ChubunruiList
        /// フォーム関係の設定（ラベルセットから）
        /// </summary>
        public ChubunruiList(Control c, LabelSet_Chubunrui lblSetChubunSelect, string strdaibunCD)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            lblSetChubun = lblSetChubunSelect;

            InitializeComponent();

            //テキストボックスに入れる
            labelSet_Daibunrui.CodeTxtText = strdaibunCD;

            //大分類コードの確保
            strdaibunCDsub = strdaibunCD;

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
        /// CyokusousakiList_Load
        /// 読み込み時
        /// </summary>
        private void CyokusousakiList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "中分類リスト";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            setDatagridView();

        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        private void setDatagridView()
        {
            DataTable dtGetTable;

            //データ渡し用
            List<string> lstString = new List<string>();

            //データ渡し用
            lstString.Add(labelSet_Daibunrui.CodeTxtText);

            //処理部に移動
            ChubunruiList_B chubunlistB = new ChubunruiList_B();
            try
            {
                //データグリッドビュー部分
                gridSeihin.DataSource = chubunlistB.setDatagridView(lstString);
                //テキストボックス部分
                dtGetTable = chubunlistB.setText(lstString);

                if (dtGetTable.Rows.Count == 0)
                {
                    return;
                }

                //幅の値を設定
                gridSeihin.Columns["中分類コード"].Width = 130;
                gridSeihin.Columns["中分類名"].Width = 150;

                //中央揃え
                gridSeihin.Columns["中分類名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //大分類コードと名前を表示
                labelSet_Daibunrui.CodeTxtText = dtGetTable.Rows[0]["大分類コード"].ToString();
                labelSet_Daibunrui.ValueLabelText = dtGetTable.Rows[0]["大分類名"].ToString();

                lblRecords.Text = "該当件数( " + gridSeihin.RowCount.ToString() + "件)";

                //件数が0の場合
                if (gridSeihin.RowCount.ToString() == "0")
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
            if (lblSetChubun != null && lstString.Count != 0)
            {
                lblSetChubun.CodeTxtText = lstString[0];
                lblSetChubun.ValueLabelText = lstString[1];
            }

            this.Close();

            //データ渡し用
            List<int> lstInt = new List<int>();

            //データ渡し用
            lstInt.Add(intFrmKind);

            //処理部に移動
            ChubunruiList_B chubunListB = new ChubunruiList_B();
            try
            {
                chubunListB.setEndAction(lstInt);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }

        }

        ///<summary>
        ///setKensakuClick
        ///検索ボタンを押したとき
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            setDatagridView();
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
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void setSelectItem()
        {
            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();

            //選択行のcode取得
            string strSelectId = (string)gridSeihin.CurrentRow.Cells["中分類コード"].Value;
            string strSelectName = (string)gridSeihin.CurrentRow.Cells["中分類名"].Value;

            //データ渡し用
            lstInt.Add(intFrmKind);
            lstString.Add(strSelectId);
            lstString.Add(strSelectName);

            //処理部に移動
            ChubunruiList_B chubunListB = new ChubunruiList_B();
            try
            {
                chubunListB.setSelectItem(lstInt, lstString, strdaibunCDsub);
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
