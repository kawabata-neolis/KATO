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
    ///ShiresakiList
    ///仕入先リスト
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class ShiresakiList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //得意先のラベルセットとテキストセットを確保する用
        LabelSet_Shiresaki lblSetShiresaki = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //フォームタイトル設定
        private string Title = "";
        public string _Title
        {
            set
            {
                String[] aryTitle = new string[] { value };
                this.Text = string.Format(STR_TITLE, aryTitle);
                Title = this.Text;
            }
            get
            {
                return Title;
            }
        }

        /// <summary>
        /// ShiresakiList
        /// 前画面からデータ受け取り(通常テキストボックス)
        /// </summary>
        public ShiresakiList(Control c)
        {
            //フォームタイトル設定
            if (c == null)
            {
                return;
            }

            //画面位置の指定
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
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;
        }

        /// <summary>
        /// ShiresakiList
        /// 前画面からデータ受け取り(セットテキストボックス)（ラベル型）
        /// </summary>
        public ShiresakiList(Control c, LabelSet_Shiresaki lblSetSireSelect)
        {
            //画面データが解放されていた時の対策
            if (c == null)
            {
                return;
            }

            //画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            //ラベルセットデータの確保
            lblSetShiresaki = lblSetSireSelect;

            InitializeComponent();

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = "F12:戻る";
            this.btnF11.Text = "F11:検索";

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;
        }

        /// <summary>
        /// ShiresakiList_Load
        /// 画面レイアウト設定
        /// </summary>
        private void ShiresakiList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "仕入先名";

            //データグリッドビューの準備
            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridShiresaki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn shireCd = new DataGridViewTextBoxColumn();
            shireCd.DataPropertyName = "仕入先コード";
            shireCd.Name = "仕入先コード";
            shireCd.HeaderText = "コード";

            DataGridViewTextBoxColumn shireName = new DataGridViewTextBoxColumn();
            shireName.DataPropertyName = "仕入先名";
            shireName.Name = "仕入先名";
            shireName.HeaderText = "仕入先名";

            //個々の幅、文章の寄せ
            setColumn(shireCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(shireName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 400);
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            //column設定
            gridShiresaki.Columns.Add(col);
            if (gridShiresaki.Columns[col.Name] != null)
            {
                gridShiresaki.Columns[col.Name].Width = intLen;
                gridShiresaki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridShiresaki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridShiresaki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///judTantouListKeyDown
        ///キー入力判定
        ///</summary>
        private void judSireListKeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    this.btnKensakuClick(sender, e);
                    break;
                case Keys.F12:
                    //戻るボタン
                    logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));
                    this.btnEndClick(sender, e);
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judTokuiListTxtKeyDown
        ///キー入力判定(テキストボックス)
        ///</summary>
        private void judSireListTxtKeyDown(object sender, KeyEventArgs e)
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
                    break;
                case Keys.F12:
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// judGridSireKeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        /// </summary>
        private void judGridSireKeyDown(object sender, KeyEventArgs e)
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
            //検索結果にデータが存在しなければ終了
            if (gridShiresaki.RowCount == 0)
            {
                return;
            }

            //データ渡し用
            List<string> lstSelectData = new List<string>();

            string strSelectId = null;

            string strSelectName = null;

            int intSelectRow = 0;
            int intSelectColumn = 0;

            //何行目かを確保
            intSelectRow = gridShiresaki.CurrentCell.RowIndex;
            intSelectColumn = gridShiresaki.CurrentCell.ColumnIndex;

            //datagridviewをdatatable化
            DataTable dtSelect = (DataTable)gridShiresaki.DataSource;

            //選択した仕入先コードの確保
            strSelectId = dtSelect.Rows[intSelectRow]["仕入先コード"].ToString();

            //選択した仕入先コードが存在しない場合
            if (strSelectId == "")
            {
                return;
            }

            //選択した仕入先名の確保
            strSelectName = dtSelect.Rows[intSelectRow]["仕入先名"].ToString();

            //検索情報を入れる
            lstSelectData.Add(strSelectId);
            lstSelectData.Add(strSelectName);

            //ビジネス層のインスタンス生成
            ShiresakiList_B shiresakilistB = new ShiresakiList_B();
            try
            {
                //ビジネス層、検索ロジックに移動
                shiresakilistB.setSelectItem(intFrmKind, strSelectId);

                setEndAction(lstSelectData);
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///btnEndClick
        ///戻るボタンを押したとき
        ///</summary>
        private void btnEndClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));

            //戻るボタンの処理に行くために必要（直接も戻る動作のため中身無し）
            List<string> lstString = new List<string>();

            //戻るボタンの処理
            setEndAction(lstString);
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction(List<string> lstSelectData)
        {
            //データグリッドビューからデータを選択且つセット系から来た場合(ラベルセットの場合)
            if (lblSetShiresaki != null && lstSelectData.Count != 0)
            {
                //セットの中に検索結果データを入れる
                lblSetShiresaki.CodeTxtText = lstSelectData[0];
                lblSetShiresaki.ValueLabelText = lstSelectData[1];
            }

            this.Close();

            //ビジネス層のインスタンス生成
            ShiresakiList_B shiresakilistB = new ShiresakiList_B();
            try
            {
                //画面終了処理
                shiresakilistB.setEndAction(intFrmKind);
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///btnKensakuClick
        ///検索ボタンを押したとき
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "検索実行"));

            //記入情報検索用
            List<string> lstSelectData = new List<string>();

            //画面の取引先検索情報取得
            lstSelectData.Add(txtTorihikisaki.Text);
            lstSelectData.Add(txtHurigana.Text);

            //ビジネス層のインスタンス生成
            ShiresakiList_B shiresakilistB = new ShiresakiList_B();
            try
            {
                //データグリッドビュー部分
                gridShiresaki.DataSource = shiresakilistB.setKensaku(lstSelectData);

                //表示数を記載
                lblRecords.Text = "該当件数( " + gridShiresaki.RowCount.ToString() + "件)";

                gridShiresaki.Focus();

            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        /// <summary>
        /// setShireGridDblClick
        /// データグリッドビュー内のデータをダブルクリックしたとき
        /// </summary>
        private void setShireGridDblClick(object sender, EventArgs e)
        {
            setSelectItem();
        }

        /// <summary>
        /// CreateParams
        /// タイトルバーの閉じるボタン、コントロールボックスの「閉じる」、Alt + F4 を無効
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

        /// <summary>
        /// txtShiresaki_KeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void txtShiresaki_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
