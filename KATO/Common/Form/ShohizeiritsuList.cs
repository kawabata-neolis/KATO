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
using KATO.Common.Ctl;
using KATO.Common.Business;
using System.Security.Permissions;
using static KATO.Common.Util.CommonTeisu;
using static KATO.Common.Util.StringUtl;

namespace KATO.Common.Form
{
    ///<summary>
    ///ShohizeiritsuList
    ///消費税率リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class ShohizeiritsuList : System.Windows.Forms.Form
    {
        //ラベルセットが出た場合
        //LabelSet_Tanaban lblSetTanaban = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        /// <summary>
        /// ShohizeiritsuList
        /// フォーム関係の設定（ラベルセットから）
        /// </summary>
        public ShohizeiritsuList(Control c)
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
        /// ShohizeiritsuList_Load
        /// 読み込み時
        /// </summary>
        private void ShohizeiritsuList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "消費税率リスト";

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
            ShohizeiritsuList_B shohizeiritsulistB = new ShohizeiritsuList_B();
            try
            {
                DataTable dtView;

                dtView = shohizeiritsulistB.setDatagridView();

                //目標売上を整数型に
                for (int cnt = 0; cnt < dtView.Rows.Count; cnt++)
                {
                    int intShisyagonyu = 1;
                    dtView.Rows[cnt]["消費税率"] = updShishagonyu(dtView.Rows[cnt]["消費税率"].ToString(), intShisyagonyu);
                }

                //データグリッドビュー部分
                gridSeihin.DataSource = dtView;

                //幅の値を設定
                gridSeihin.Columns["適用開始年月日"].Width = 150;
                gridSeihin.Columns["消費税率"].Width = 120;

                //中央揃え
                gridSeihin.Columns["適用開始年月日"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridSeihin.Columns["消費税率"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
        ///judShohiListKeyDown
        ///キー入力判定
        ///</summary>
        private void judShohiListKeyDown(object sender, KeyEventArgs e)
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
            //if (lblSetTanaban != null && lstString.Count != 0)
            //{
            //    lblSetTanaban.CodeTxtText = lstString[0];
            //    lblSetTanaban.ValueLabelText = lstString[1];
            //}

            //データ渡し用
            List<int> lstInt = new List<int>();

            //データ渡し用
            lstInt.Add(intFrmKind);

            this.Close();

            //処理部に移動
            TanabanList_B tanabanlistB = new TanabanList_B();
            try
            {
                tanabanlistB.setEndAction(intFrmKind);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///gridSeihin_DoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>

        private void gridSeihin_DoubleClick(object sender, EventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///judGridShohiKeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///</summary>        
        private void judGridShohiKeyDown(object sender, KeyEventArgs e)
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

        ///<summary>
        ///setGridSeihinDoubleClick
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void setSelectItem()
        {
            //データ渡し用
            List<string> lstString = new List<string>();
                        
            //選択行の営業所コード取得
//datetimeのままの長さの場合、エクセプションが飛ぶ
            string strSelectid = gridSeihin.CurrentRow.Cells[0].Value.ToString();
            //string strSelectid = (string)gridSeihin.CurrentRow.Cells[0].Value;
            string strSelectName = (string)gridSeihin.CurrentRow.Cells[1].Value.ToString();
            //string strSelectName = (string)gridSeihin.CurrentRow.Cells[1].Value;

            //データ渡し用
            lstString.Add(strSelectid);
            lstString.Add(strSelectName);

            //処理部に移動
            ShohizeiritsuList_B shohizeilistB = new ShohizeiritsuList_B();
            try
            {
                shohizeilistB.setSelectItem(intFrmKind, lstString);

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
