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
using KATO.Form.M1030_Shohin;
using KATO.Form.D0380_ShohinMotochoKakunin;
using KATO.Form.A0100_HachuInput;

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
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //中分類コードの確保（セット系用）
        LabelSet_Chubunrui lblSetChubun = null;

        //大分類コードの確保
        string strSubDaibunCd = null;

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
        /// ChubunruiList
        /// フォームの初期設定（通常のテキストボックスから）
        /// </summary>
        public ChubunruiList(Control c, string strdaibunCd)
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
            labelSet_Daibunrui.CodeTxtText = strdaibunCd;

            //大分類コードの確保
            strSubDaibunCd = strdaibunCd;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;
        }

        /// <summary>
        /// ChubunruiList
        /// フォームの初期設定（ラベルセットから）
        /// </summary>
        public ChubunruiList(Control c, LabelSet_Chubunrui lblSetChubunSelect, string strdaibunCD)
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
            lblSetChubun = lblSetChubunSelect;

            InitializeComponent();

            //テキストボックスに入れる
            labelSet_Daibunrui.CodeTxtText = strdaibunCD;

            //大分類コードの確保
            strSubDaibunCd = strdaibunCD;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;
        }

        /// <summary>
        /// CyokusousakiList_Load
        /// 画面レイアウト設定
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

            //データない場合、フォーカス位置を変える
            if (gridSeihin.RowCount == 0)
            {
                labelSet_Daibunrui.Focus();
            }

        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///</summary>
        private void setDatagridView()
        {
            //大分類テキストボックスに入れる用
            DataTable dtGetTable;

            //データグリッドビュー部分
            ChubunruiList_B chubunlistB = new ChubunruiList_B();
            try
            {
                //データグリッドビュー部分
                gridSeihin.DataSource = chubunlistB.setDatagridView(labelSet_Daibunrui.CodeTxtText);
                //テキストボックス部分
                dtGetTable = chubunlistB.setText(labelSet_Daibunrui.CodeTxtText);

                //幅の値を設定
                gridSeihin.Columns["中分類コード"].Width = 130;
                gridSeihin.Columns["中分類名"].Width = 200;

                //中央揃え
                gridSeihin.Columns["中分類名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //大分類コードと名前を表示
                labelSet_Daibunrui.CodeTxtText = dtGetTable.Rows[0]["大分類コード"].ToString();
                labelSet_Daibunrui.ValueLabelText = dtGetTable.Rows[0]["大分類名"].ToString();

                lblRecords.Text = "該当件数( " + gridSeihin.RowCount.ToString() + "件)";

                //予備の大分類コードに保持
                strSubDaibunCd = labelSet_Daibunrui.CodeTxtText;
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
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
            List<string> lstSelectData = new List<string>();

            //戻るボタンの処理
            setEndAction(lstSelectData);
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction(List<string> lstSelectData)
        {
            //データグリッドビューからデータを選択且つセット系から来た場合
            if (lblSetChubun != null && lstSelectData.Count != 0)
            {
                //セットの中に検索結果データを入れる
                lblSetChubun.CodeTxtText = lstSelectData[0];
                lblSetChubun.ValueLabelText = lstSelectData[1];

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
            ChubunruiList_B chubunListB = new ChubunruiList_B();
            try
            {
                //画面終了処理
                chubunListB.setEndAction(intFrmKind);
            }
            catch (Exception ex)
            {
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
            //データグリッドビューにデータが存在しなければ終了
            if (gridSeihin.RowCount == 0)
            {
                return;
            }

            //データ渡し用
            List<string> lstSelectData = new List<string>();

            //選択行のcode取得
            string strSelectId = (string)gridSeihin.CurrentRow.Cells["中分類コード"].Value;
            string strSelectName = (string)gridSeihin.CurrentRow.Cells["中分類名"].Value;

            //検索情報を入れる
            lstSelectData.Add(strSelectId);
            lstSelectData.Add(strSelectName);

            //ビジネス層のインスタンス生成
            ChubunruiList_B chubunListB = new ChubunruiList_B();
            try
            {
                //データグリッドビュー内のデータ選択後の処理
                chubunListB.setSelectItem(intFrmKind, strSelectId, strSubDaibunCd);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            setEndAction(lstSelectData);
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
