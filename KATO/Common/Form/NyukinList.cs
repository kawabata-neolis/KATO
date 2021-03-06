﻿using System;
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
using static KATO.Common.Util.CommonTeisu;
using System.Security.Permissions;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    ///<summary>
    ///NyukinList
    ///入金リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class NyukinList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //得意先コードの確保
        string strTokuiCdsub = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //前画面から伝票番号を取り出す枠（伝票番号初期値）（ベーステキストマネー）
        public BaseTextMoney bmDenpyo = null;

        //前画面からリストからデータを取り出した判定を取り出す枠（ラジオボタン）
        public RadSet_2btn radListInput = null;

        //画面タイトル設定
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
        /// NyukinList
        /// フォームの初期設定（通常のテキストボックスから）
        /// </summary>
        public NyukinList(Control c)
        {
            //画面データが解放されていた時の対策
            if (c == null)
            {
                return;
            }

            //画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;

            // 伝票番号の引き渡しチェック
            if (bmDenpyo == null)
            {
                bmDenpyo = new BaseTextMoney();
            }

            //リストからデータを取り出したかどうかの判定の引き渡しチェック
            if (radListInput == null)
            {
                radListInput = new RadSet_2btn();
            }
        }

        ///<summary>
        ///NyukinList_Load
        ///画面レイアウト設定
        ///</summary>
        private void NyukinList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "入金リスト";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            setupGrid();
        }

        ///<summary>
        ///setupGrid
        ///DataGridView初期設定
        ///</summary>
        private void setupGrid()
        {
            //列自動生成禁止
            gridTokui.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn YMD = new DataGridViewTextBoxColumn();
            YMD.DataPropertyName = "入金年月日";
            YMD.Name = "入金年月日";
            YMD.HeaderText = "年月日";

            DataGridViewTextBoxColumn tokuisaki = new DataGridViewTextBoxColumn();
            tokuisaki.DataPropertyName = "得意先名";
            tokuisaki.Name = "得意先名";
            tokuisaki.HeaderText = "得意先";

            DataGridViewTextBoxColumn nyukin = new DataGridViewTextBoxColumn();
            nyukin.DataPropertyName = "入金額";
            nyukin.Name = "入金額";
            nyukin.HeaderText = "入金額";

            DataGridViewTextBoxColumn denpyo = new DataGridViewTextBoxColumn();
            denpyo.DataPropertyName = "伝票番号";
            denpyo.Name = "伝票番号";
            denpyo.HeaderText = "伝票番号";

            //個々の幅、文章の寄せ
            setColumn(YMD, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(tokuisaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumn(nyukin, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumn(denpyo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 100);
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            //column設定
            gridTokui.Columns.Add(col);
            //カラム名が空でない場合
            if (gridTokui.Columns[col.Name] != null)
            {
                //横幅サイズの決定
                gridTokui.Columns[col.Name].Width = intLen;
                //文章の寄せ方向の決定
                gridTokui.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                //カラム名の位置の決定
                gridTokui.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                //フォーマットが指定されていた場合
                if (fmt != null)
                {
                    //フォーマットを指定
                    gridTokui.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        private void setDatagridView()
        {
            //ビジネス層のインスタンス生成
            NyukinList_B nyukinlistB = new NyukinList_B();
            try
            {
                //データグリッドビュー部分
                gridTokui.DataSource = nyukinlistB.getDatagridView(lblsetTokui.CodeTxtText);

                //表示数を記載
                lblRecords.Text = "該当件数( " + gridTokui.RowCount.ToString() + "件)";

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
        ///NyukinList_KeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void NyukinList_KeyDown(object sender, KeyEventArgs e)
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
        ///btnEndClick
        ///戻るボタンを押したとき
        ///</summary>
        public void btnEndClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));
            this.Close();
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction(DataTable dtNyukin)
        {
            this.Close();

            bmDenpyo.Text = dtNyukin.Rows[0]["伝票番号"].ToString();

            //リストからデータを取り出した判定
            radListInput.radbtn1.Checked = true;
        }

        ///<summary>
        ///setKensakuClick
        ///検索ボタンを押したとき
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "検索実行"));

            setDatagridView();

            strTokuiCdsub = lblsetTokui.CodeTxtText;

            gridTokui.Focus();
        }

        ///<summary>
        ///setGridSeihinDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>        
        private void gridChoku_DoubleClick(object sender, EventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void setSelectItem()
        {
            //伝票番号を入れる用
            DataTable dtNyukin = new DataTable();

            //検索結果にデータが存在しなければ終了
            if (gridTokui.RowCount == 0)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            NyukinList_B nyukinkistB = new NyukinList_B();
            try
            {
                //ビジネス層、検索ロジックに移動
                dtNyukin = nyukinkistB.getSelectItem(intFrmKind, (gridTokui.CurrentRow.Cells["伝票番号"].Value).ToString());

                //検索結果がない場合
                if (dtNyukin.Rows.Count <= 0)
                {
                    return;
                }
                
                setEndAction(dtNyukin);
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

        ///<summary>
        ///setGridSeihinDoubleClick
        ///キー入力判定（グリッドビュー内）
        ///</summary>        
        private void gridTokui_KeyDown(object sender, KeyEventArgs e)
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

        /// <summary>
        /// form_KeyPress
        /// KeyPressイベントハンドラ
        /// </summary>
        private void form_KeyPress(object sender, KeyPressEventArgs e)
        {
            //EnterやEscapeキーでビープ音が鳴らないようにする
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }
        }
    }
}
