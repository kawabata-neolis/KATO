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
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //ラベルセット作成後修正
        //LabelSet_Chubunrui lblSetChubun = null;

        //得意先コードの確保
        string strTokuiCdsub = null;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

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
        /// フォーム関係の設定（通常のテキストボックスから）
        /// </summary>
        public ChokusosakiList(Control c, string strTokuisakiCd)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //テキストボックスに入れる
            labelSet_Tokuisaki.CodeTxtText = strTokuisakiCd;

            //大分類コードの確保
            strTokuiCdsub = strTokuisakiCd;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
            this.Top = c.Top;
        }

        //ラベルセット作成後修正
        ///// <summary>
        ///// ChokusosakiList
        ///// フォーム関係の設定（ラベルセットから）
        ///// </summary>
        //public ChokusosakiList(Control c, LabelSet_Chubunrui lblSetChubunSelect, string strdaibunCD)
        //{
        //    if (c == null)
        //    {
        //        return;
        //    }

        //    int intWindowWidth = c.Width;
        //    int intWindowHeight = c.Height;

        //    lblSetChubun = lblSetChubunSelect;

        //    InitializeComponent();

        //    //テキストボックスに入れる
        //    labelSet_Tokuisaki.CodeTxtText = strdaibunCD;

        //    //大分類コードの確保
        //    strdaibunCDsub = strdaibunCD;

        //    //ウィンドウ位置をマニュアル
        //    this.StartPosition = FormStartPosition.Manual;
        //    //親画面の中央を指定
        //    this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
        //    this.Top = c.Top;
        //}

        /// <summary>
        /// ChokusosakiList_Load
        /// 読み込み時
        /// </summary>
        private void CyokusousakiList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "直送先リスト";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            setDatagridView();

            if (gridChoku.RowCount == 0)
            {
                labelSet_Tokuisaki.Focus();
            }
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
            lstString.Add(labelSet_Tokuisaki.CodeTxtText);

            ChokusosakiList_B chokusosakilistB = new ChokusosakiList_B();
            try
            {
                //データグリッドビュー部分
                gridChoku.DataSource = chokusosakilistB.setDatagridView(lstString);
                //テキストボックス部分
                dtGetTable = chokusosakilistB.setText(lstString);

                if (dtGetTable.Rows.Count == 0)
                {
                    return;
                }

                //幅の値を設定
                gridChoku.Columns["直送先コード"].Width = 130;
                gridChoku.Columns["直送先名"].Width = 250;

                //中央揃え
                gridChoku.Columns["直送先名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //大分類コードと名前を表示
                labelSet_Tokuisaki.CodeTxtText = dtGetTable.Rows[0]["得意先コード"].ToString();

                lblRecords.Text = "該当件数( " + gridChoku.RowCount.ToString() + "件)";

            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }


            ////処理部に移動
            //ChubunruiList_B chubunlistB = new ChubunruiList_B();
            //try
            //{
            //    //データグリッドビュー部分
            //    gridChoku.DataSource = chubunlistB.setDatagridView(lstString);
            //    //テキストボックス部分
            //    dtGetTable = chubunlistB.setText(lstString);

            //    if (dtGetTable.Rows.Count == 0)
            //    {
            //        return;
            //    }

            //    //幅の値を設定
            //    gridChoku.Columns["直送先コード"].Width = 130;
            //    gridChoku.Columns["直送先名"].Width = 200;

            //    //中央揃え
            //    gridChoku.Columns["直送先名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //    //大分類コードと名前を表示
            //    labelSet_Tokuisaki.CodeTxtText = dtGetTable.Rows[0]["得意先コード"].ToString();

            //    lblRecords.Text = "該当件数( " + gridChoku.RowCount.ToString() + "件)";
            //}
            //catch (Exception ex)
            //{
            //    new CommonException(ex);
            //}
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

            List<string> lstString = new List<string>();
            setEndAction(lstString);
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction(List<string> lstString)
        {
            //ラベルセット作成後修正
            //if (lblSetChubun != null && lstString.Count != 0)
            //{
            //    lblSetChubun.CodeTxtText = lstString[0];
            //    lblSetChubun.ValueLabelText = lstString[1];
            //}

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
            logger.Info(LogUtil.getMessage(this._Title, "検索実行"));

            setDatagridView();
            gridChoku.Focus();
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

            if(gridChoku.RowCount == 0)
            {
                return;
            }

            //選択行のcode取得
            string strSelectId = (string)gridChoku.CurrentRow.Cells["直送先コード"].Value;
            string strSelectName = (string)gridChoku.CurrentRow.Cells["直送先名"].Value;

            //データ渡し用
            lstInt.Add(intFrmKind);
            lstString.Add(strSelectId);
            lstString.Add(strSelectName);

            //処理部に移動
            ChokusosakiList_B chokusosakilistB = new ChokusosakiList_B();
            try
            {
                chokusosakilistB.setSelectItem(lstInt, lstString, strTokuiCdsub);
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
