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
using KATO.Form.F0140_TanaorosiInput;
using static KATO.Common.Util.CommonTeisu;
using System.Security.Permissions;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    ///<summary>
    ///ChokusosakiList
    ///直送先リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class ChokusosakiList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //得意先コードの確保
        string strTokuiCdsub = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

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
        /// ChubunruiList
        /// フォームの初期設定（通常のテキストボックスから）
        /// </summary>
        public ChokusosakiList(Control c, string strTokuisakiCd)
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

            //テキストボックスに入れる
            txtTokuisakiCd.Text = strTokuisakiCd;

            //得意先コードの確保
            strTokuiCdsub = strTokuisakiCd;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;
        }

        /// <summary>
        /// ChokusosakiList_Load
        ///画面レイアウト設定
        /// </summary>
        private void ChokusosakiList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "直送先リスト";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            SetUpGrid();

            //データグリッドビューに表示
            getDatagridView();

            //グリッドの中身がない場合の初期フォーカス位置の変更
            if (gridChoku.RowCount == 0)
            {
                txtTokuisakiCd.Focus();
            }
        }

        ///<summary>
        ///SetUpGrid
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridChoku.AutoGenerateColumns = false;

            //データをバインド
            //1
            DataGridViewTextBoxColumn chokuCd = new DataGridViewTextBoxColumn();
            chokuCd.DataPropertyName = "直送先コード";
            chokuCd.Name = "直送先コード";
            chokuCd.HeaderText = "直送先コード";

            //2
            DataGridViewTextBoxColumn chokuName = new DataGridViewTextBoxColumn();
            chokuName.DataPropertyName = "直送先名";
            chokuName.Name = "直送先名";
            chokuName.HeaderText = "直送先名";

            //個々の幅、文章の寄せ
            setColumnChoku(chokuCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 130);
            setColumnChoku(chokuName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 250);

        }

        ///<summary>
        ///setColumnChoku
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumnChoku(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridChoku.Columns.Add(col);
            if (gridChoku.Columns[col.Name] != null)
            {
                gridChoku.Columns[col.Name].Width = intLen;
                gridChoku.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridChoku.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridChoku.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///getDatagridView
        ///データグリッドビュー表示
        ///</summary>
        private void getDatagridView()
        {
            DataTable dtChokuso = new DataTable();

            //ビジネス層のインスタンス生成
            ChokusosakiList_B chokusosakilistB = new ChokusosakiList_B();
            try
            {
                dtChokuso = chokusosakilistB.getDatagridView(txtTokuisakiCd.Text);

                if(dtChokuso.Rows.Count > 0)
                {
                    //データグリッドビュー部分
                    gridChoku.DataSource = dtChokuso;
                }
                else
                {
                    gridChoku.DataSource = "";
                }

                //表示数を記載
                lblRecords.Text = "該当件数( " + gridChoku.RowCount.ToString() + "件)";

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
        ///judDaiBunruiListKeyDown
        ///キー入力判定（画面全般）
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
        private void btnEndClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));
            EndAction();
        }

        ///<summary>
        ///EndAction
        ///戻るボタンの処理
        ///</summary>
        private void EndAction()
        {
            this.Close();

            //ビジネス層のインスタンス生成
            ChokusosakiList_B chokusosakilistB = new ChokusosakiList_B();
            try
            {
                //ビジネス層、移動元フォームに移動するロジックに移動
                chokusosakilistB.FormMove(intFrmKind);
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
        ///setKensakuClick
        ///検索ボタンを押したとき
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "検索実行"));

            //データグリッドビューに表示
            getDatagridView();

            //得意先コードを確保
            strTokuiCdsub = txtTokuisakiCd.Text;

            gridChoku.Focus();
        }

        ///<summary>
        ///setGridSeihinDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>        
        private void gridChoku_DoubleClick(object sender, EventArgs e)
        {
            getSelectItem();
        }

        ///<summary>
        ///judGridSeihinKeyDown
        ///キー入力判定（グリッドビュー内）
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
                    getSelectItem();
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
        ///getSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>        
        private void getSelectItem()
        {
            //検索結果にデータが存在しなければ終了
            if (gridChoku.RowCount == 0)
            {
                return;
            }

            //ビジネス層のインスタンス生成
            ChokusosakiList_B chokusosakilistB = new ChokusosakiList_B();
            try
            {
                //ビジネス層、検索ロジックに移動
                chokusosakilistB.getSelectItem(intFrmKind, (string)gridChoku.CurrentRow.Cells["直送先コード"].Value, strTokuiCdsub);

                EndAction();
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
        ///ChokusosakiList_KeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>        
        private void ChokusosakiList_KeyUp(object sender, KeyEventArgs e)
        {
            //フォーカスの確保
            Control cActiveBefore = this.ActiveControl;

            //ベーステキストのインスタンス生成
            BaseText basetext = new BaseText();

            //キーアップされた時の判断処理
            basetext.judKeyUp(cActiveBefore, e);
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
