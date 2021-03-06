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
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

        ///<summary>
        ///ShohizeiritsuList
        ///フォームの初期設定（通常テキストボックスから）
        ///</summary>
        public ShohizeiritsuList(Control c)
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
        }

        ///<summary>
        ///ShohizeiritsuList_Load
        ///レイアウト設定
        ///</summary>
        private void ShohizeiritsuList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "消費税率リスト";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = "F12:戻る";

            Boolean blnAll = false;

            setDatagridView(blnAll);
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        private void setDatagridView(Boolean blnAll)
        {
            //ビジネス層のインスタンス生成
            ShohizeiritsuList_B shohizeiritsulistB = new ShohizeiritsuList_B();
            try
            {
                //データの変換を行うためのデータテーブル
                DataTable dtView;

                //検索結果を取り込む
                dtView = shohizeiritsulistB.getDatagridView(blnAll);

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

                //検索件数を表示
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
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
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

            //戻るボタンの処理に行くために必要（直接も戻る動作のため中身無し）
            List<string> lstString = new List<string>();

            //戻るボタンの処理
            setEndAction(lstString);
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction(List<string> lstString)
        {
            this.Close();

            //ビジネス層のインスタンス生成
            ShohizeiritsuList_B shohizeilistB = new ShohizeiritsuList_B();
            try
            {
                shohizeilistB.FormMove(intFrmKind);
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
            //データグリッドビューにデータが存在しなければ終了
            if (gridSeihin.RowCount == 0)
            {
                return;
            }

            //選択された月用
            string strSelectMonth = "";

            //選択された日付用
            string strSelectDay = "";

            //選択行の検索情報取得用
            List<string> lstSelectData = new List<string>();

            //検索データ用
            DateTime dateSelect;

            //検索データを取り込む
            dateSelect =  (DateTime)gridSeihin.CurrentRow.Cells[0].Value;

            //月データを入れる
            strSelectMonth = dateSelect.Month.ToString();

            //文字数が1だった場合、0パディング
            if (strSelectMonth.Length == 1)
            {
                strSelectMonth = dateSelect.Month.ToString().PadLeft(2, '0');
            }

            //日付データを入れる
            strSelectDay = dateSelect.Day.ToString();

            //文字数が1だった場合、0パディング
            if (strSelectDay.Length == 1)
            {
                strSelectDay = dateSelect.Day.ToString().PadLeft(2, '0');
            }

            //日付データを取得
            string strSelectDate = (dateSelect.Year +"/"+ strSelectMonth + "/"+ strSelectDay).ToString();

            //名前データを取得
            string strSelectName = (string)gridSeihin.CurrentRow.Cells[1].Value.ToString();

            //検索するデータの取得
            lstSelectData.Add(strSelectDate);
            lstSelectData.Add(strSelectName);

            //ビジネス層のインスタンス生成
            ShohizeiritsuList_B shohizeilistB = new ShohizeiritsuList_B();
            try
            {
                //データグリッドビュー内のデータ選択後の処理
                shohizeilistB.getSelectItem(intFrmKind, strSelectDate);

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
        ///chkSakujoData_CheckedChanged
        ///チェックボックスに変更があった場合
        ///</summary>        
        private void chkSakujoData_CheckedChanged(object sender, EventArgs e)
        {
            //削除込みも含む場合
            if (chkSakujoData.Checked == true)
            {
                Boolean blnAll = true;

                setDatagridView(blnAll);
            }
            else
            {
                Boolean blnAll = false;

                setDatagridView(blnAll);
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
        ///form_KeyPress
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
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
