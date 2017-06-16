﻿using System;
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
using KATO.Form.M1030_Shohin;
using KATO.Form.D0380_ShohinMotochoKakunin;
using KATO.Form.A0100_HachuInput;

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
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //メーカーコードの確保（セット系用）
        LabelSet_Maker lblSetMaker = null;

        ////大分類コードの確保（セット系用）
        //LabelSet_Daibunrui lblSetDaibun = new LabelSet_Daibunrui();

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //大分類コードの予備データ
        string strSubDaibunCd;

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
        /// MakerList
        /// フォームの初期設定（通常のテキストボックスから）
        /// </summary>
        public MakerList(Control c)
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

        /// <summary>
        /// MakerList
        /// フォームの初期設定（ラベルセットから）
        /// </summary>
        public MakerList(Control c, LabelSet_Maker lblSetMakerSelect)
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
            lblSetMaker = lblSetMakerSelect;

            InitializeComponent();

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;
        }

        /// <summary>
        /// MakerList
        /// フォームの初期設定（ラベルセットから）（大分類コードを付ける場合）
        /// </summary>
        public MakerList(Control c, LabelSet_Maker lblSetMakerSelect, string strdaibunCD)
        {
            //画面データが解放されていた時の対策
            if (c == null)
            {
                return;
            }

            //画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            //ラベルセットデータの確保（メーカー）
            lblSetMaker = lblSetMakerSelect;

            ////ラベルセットデータの確保（大分類）
            //lblSetDaibun.CodeTxtText = strdaibunCD;

            InitializeComponent();

            //テキストボックスに入れる
            labelSet_Daibunrui.CodeTxtText = strdaibunCD;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;
        }

        /// <summary>
        /// MakerList_Load
        /// 画面レイアウト設定
        /// </summary>
        private void MakerList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "メーカーリスト";

            //大分類がすでに入力されていた場合検索
            if(labelSet_Daibunrui.CodeTxtText.Length > 0)
            {
                btnKensakuClick(sender, e);
            }
            else
            {
                setDatagridView();
            }

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            //大分類コードが記入されている場合
            if (labelSet_Daibunrui.CodeTxtText != "")
            {
                setDatagridView();
                setKensaku();
            }
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        public void setDatagridView()
        {
            //ビジネス層のインスタンス生成
            MakerList_B makerlistB = new MakerList_B();
            try
            {
                //データグリッドビュー部分
                gridMaker.DataSource = makerlistB.setDatagridView();

                //幅の値を設定
                gridMaker.Columns["メーカーコード"].Width = 150;
                gridMaker.Columns["メーカー名"].Width = 200;

                //中央揃え
                gridMaker.Columns["メーカー名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //検索件数を表示
                lblRecords.Text = "該当件数( " + gridMaker.RowCount.ToString() + "件)";

                //件数が0の場合
                if (gridMaker.RowCount == 0)
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

            //戻るボタンの処理に行くために必要（直接も戻る動作のため中身無し）
            List<string> lstString = new List<string>();

            //戻るボタンの処理
            setEndAction(lstString);
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction(List<string> lstSelectId)
        {
            //データグリッドビューからデータを選択且つセット系から来た場合
            if (lblSetMaker != null && lstSelectId.Count != 0)
            {
                //セットの中に検索結果データを入れる
                lblSetMaker.CodeTxtText = lstSelectId[0];
                lblSetMaker.ValueLabelText = lstSelectId[1];

                //全てのフォームの中から
                foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                {
                    //商品のフォームを探す
                    if (frm.Name == "M1030_Shohin")
                    {
                        //データを連れてくるため、newをしないこと
                        M1030_Shohin shohinHome = (M1030_Shohin)frm;
                        shohinHome.updDaibun(strSubDaibunCd);
                        break;
                    }
                    //棚卸入力のフォームを探す
                    if (frm.Name == "F0140_TanaorosiInput")
                    {
                        //データを連れてくるため、newをしないこと
                        F0140_TanaorosiInput tanaHome = (F0140_TanaorosiInput)frm;
                        tanaHome.updDaibun(strSubDaibunCd);
                        break;
                    }
                    //商品元帳確認のフォームを探す
                    if (frm.Name == "D0380_ShohinMotochoKakunin")
                    {
                        //データを連れてくるため、newをしないこと
                        D0380_ShohinMotochoKakunin shohinmotoHome = (D0380_ShohinMotochoKakunin)frm;
                        shohinmotoHome.updDaibun(strSubDaibunCd);
                        break;
                    }
                    //発注入力のフォームを探す
                    if (frm.Name == "A0100_HachuInput")
                    {
                        //データを連れてくるため、newをしないこと
                        A0100_HachuInput hachuHome = (A0100_HachuInput)frm;
                        hachuHome.updDaibun(strSubDaibunCd);
                        break;
                    }

                }
            }

            this.Close();

            //ビジネス層のインスタンス生成
            MakerList_B makerlistB = new MakerList_B();
            try
            {
                //画面終了処理
                makerlistB.setEndAction(intFrmKind);
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
            setKensaku();
        }

        ///<summary>
        ///setKensaku
        ///検索の処理
        ///</summary>
        private void setKensaku()
        {
            logger.Info(LogUtil.getMessage(this._Title, "検索実行"));

            //記入情報検索用
            List<string> lstSearch = new List<string>();

            //画面の業種検索情報取得
            lstSearch.Add(labelSet_Daibunrui.CodeTxtText);
            lstSearch.Add(txtKensaku.Text);

            //ビジネス層のインスタンス生成
            MakerList_B makerlistB = new MakerList_B();
            try
            {
                //データグリッドビュー部分
                gridMaker.DataSource = makerlistB.setKensaku(lstSearch);

                //表示数を記載
                lblRecords.Text = "該当件数( " + gridMaker.RowCount.ToString() + "件)";

                //予備の大分類コードに保持
                strSubDaibunCd = labelSet_Daibunrui.CodeTxtText;

                gridMaker.Focus();
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
        ///setGridSeihinDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>        
        private void setGridSeihinDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///judTokuiListTxtKeyDown
        ///キー入力判定(テキストボックス)
        ///</summary>
        private void judTokuiListTxtKeyDown(object sender, KeyEventArgs e)
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
            //検索結果にデータが存在しなければ終了
            if (gridMaker.RowCount == 0)
            {
                return;
            }

            //選択行のメーカー情報
            List<string> lstSelectId = new List<string>();

            //選択行のメーカー情報取得
            string strSelectid = (string)gridMaker.CurrentRow.Cells["メーカーコード"].Value;
            string strSelectName = (string)gridMaker.CurrentRow.Cells["メーカー名"].Value;

            //検索情報を入れる
            lstSelectId.Add(strSelectid);
            lstSelectId.Add(strSelectName);

            //ビジネス層のインスタンス生成
            MakerList_B makerlistB = new MakerList_B();
            try
            {
                //ビジネス層、検索ロジックに移動
                makerlistB.setSelectItem(intFrmKind, strSelectid);

                setEndAction(lstSelectId);
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

        /// <summary>
        /// txtKensaku_KeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void txtKensaku_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
