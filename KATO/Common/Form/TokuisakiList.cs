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
using static KATO.Common.Util.CommonTeisu;
using KATO.Common.Business;
using KATO.Common.Util;
using System.Security.Permissions;

namespace KATO.Common.Form
{
    ///<summary>
    ///TokuisakiList
    ///得意先リスト
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class TokuisakiList : System.Windows.Forms.Form
    {
        LabelSet_Tokuisaki lblSetTokuisaki = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        /// <summary>
        /// TantoushaList
        /// 前画面からデータ受け取り(通常テキストボックス)
        /// </summary>
        public TokuisakiList(Control c)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = "F12:戻る";
            this.btnF11.Text = "F11:検索";

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
            this.Top = c.Top;
        }

        /// <summary>
        /// TokuisakiList
        /// 前画面からデータ受け取り(セットテキストボックス)
        /// </summary>
        public TokuisakiList(Control c, LabelSet_Tokuisaki lblSetTokuiSelect)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            lblSetTokuisaki = lblSetTokuiSelect;
            InitializeComponent();

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = "F12:戻る";
            this.btnF11.Text = "F11:検索";

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
            this.Top = c.Top;
        }

        /// <summary>
        /// _Title
        /// タイトルプロパティを決める
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
        /// TantousyaList_Load
        /// 初回読み込み
        /// </summary>
        private void TantousyaList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "取引先名";

            SetUpGrid();
        }

        ///<summary>
        ///SetUpGrid
        ///データグリッドビューの準備
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            TokuisakiGrid.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn torihikisakiCD = new DataGridViewTextBoxColumn();
            torihikisakiCD.DataPropertyName = "取引先コード";
            torihikisakiCD.Name = "取引先コード";
            torihikisakiCD.HeaderText = "コード";

            DataGridViewTextBoxColumn torihikisakiName = new DataGridViewTextBoxColumn();
            torihikisakiName.DataPropertyName = "取引先名称";
            torihikisakiName.Name = "取引先名称";
            torihikisakiName.HeaderText = "取引先名";

            //バインドしたデータを追加
            TokuisakiGrid.Columns.Add(torihikisakiCD);
            TokuisakiGrid.Columns.Add(torihikisakiName);

            //個々の幅、文章の寄せ
            TokuisakiGrid.Columns["取引先コード"].Width = 100;
            TokuisakiGrid.Columns["取引先コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            TokuisakiGrid.Columns["取引先コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            TokuisakiGrid.Columns["取引先名称"].Width = 400;
            TokuisakiGrid.Columns["取引先名称"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            TokuisakiGrid.Columns["取引先名称"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        ///<summary>
        ///judTantouListKeyDown
        ///キー入力判定
        ///</summary>
        private void judTokuiListKeyDown(object sender, KeyEventArgs e)
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
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
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

        /// <summary>
        /// CreateParams
        ///データグリッドビュー内のデータをダブルクリックしたとき
        /// </summary>
        private void setTanGridDblClick(object sender, KeyEventArgs e)
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
        ///setdgvSeihinDoubleClick
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void setSelectItem()
        {
            if (TokuisakiGrid.Rows.Count < 1)
            {
                return;
            }

            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();

            //選択行の担当者情報取得
            string strSelectId = (string)TokuisakiGrid.CurrentRow.Cells["取引先コード"].Value;
            string strSelectName = (string)TokuisakiGrid.CurrentRow.Cells["取引先名称"].Value;

            lstInt.Add(intFrmKind);
            lstString.Add(strSelectId);
            lstString.Add(strSelectName);

            setEndAction(lstString);
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
            if (lblSetTokuisaki != null && lstString.Count != 0)
            {
                lblSetTokuisaki.CodeTxtText = lstString[0];
                lblSetTokuisaki.ValueLabelText = lstString[1];
            }

            this.Close();

            //データ渡し用
            List<int> lstInt = new List<int>();

            //処理部へ
            lstInt.Add(intFrmKind);
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
            lstString.Add("");
            lstString.Add("");
            lstString.Add(txtTorihikisaki.Text);
            lstString.Add(txtHurigana.Text);
            lstString.Add("");

            //処理部に移動
            TokuisakiList_B tokuisakiB = new TokuisakiList_B();
            try
            {
                //データグリッドビュー部分
                TokuisakiGrid.DataSource = tokuisakiB.setKensaku(lstInt, lstString);

                lblRecords.Text = "該当件数( " + TokuisakiGrid.RowCount.ToString() + "件)";

                TokuisakiGrid.Focus();

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
        }


        /// <summary>
        /// CreateParams
        // タイトルバーの閉じるボタン、コントロールボックスの「閉じる」、Alt + F4 を無効
        /// </summary>
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
