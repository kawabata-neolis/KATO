using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Business.M1490_Menukengen2;
using KATO.Common.Ctl;
using KATO.Common.Util;
using KATO.Common.Form;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1490_Menukengen2
{
    public partial class M1490_Menukengen2 : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public M1490_Menukengen2(Control c)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;

            //最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;
        }

        /// <summary>
        /// M1490_Menukengen2_Load
        /// 読み込み時
        /// </summary>
        private void M1490_Menukengen2_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "メニュー権限２";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;
        }

        private void M1490_Menukengen2_KeyDown(object sender, KeyEventArgs e)
        {
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
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addKengen();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.clearForm();
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
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///     テキストボックスでキー押下
        ///</summary>
        private void txtMenukengen2_KeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    getKengenData();
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
                    getKengenData();
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
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    Function9KeyDown(sender, e);
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
        ///     Grid内でキー押下
        ///</summary>
        private void gridKengen_KeyDown(object sender, KeyEventArgs e)
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
                    // 権限変更
                    chengeKengen();
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
        ///judBtnClick
        ///ボタンの反応
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addKengen();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.clearForm();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        /// F9押下でメニュー検索（メニュー一覧表示）
        ///キー入力判定
        ///</summary>
        private void Function9KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                MenuList menulist = new MenuList(this);
                try
                {
                    // 一覧画面表示
                    menulist.StartPosition = FormStartPosition.Manual;
                    menulist.intFrmKind = CommonTeisu.FRM_MENUKENGEN2;
                    menulist.ShowDialog();
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    return;
                }
            }
        }

        ///<summary>
        ///     権限データ取得
        ///</summary>
        private void getKengenData()
        {
            M1490_Menukengen2_B kengen2B = new M1490_Menukengen2_B();
            // 入力PGNo.を取得
            string pgno = txtMenukengen2.Text;

            var kengen = kengen2B.getKengen(pgno);
            string menuName = kengen.Item1;
            DataTable dtkengen = kengen.Item2;

            lblMenuName.Text = menuName;
            gridKengen.DataSource = dtkengen;

            // カラムの幅を指定
            gridKengen.Columns["担当者コード"].Width = 150;
            gridKengen.Columns["担当者名"].Width = 200;
            gridKengen.Columns["権限"].Width = 130;

            //件数が0の場合
            if (dtkengen.Rows.Count == 0)
            {
                //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        // gridダブルクリックで権限変更
        private void gridKengen_DblClick(object sender, EventArgs e)
        {
            chengeKengen();
        }

        /// <summary>
        ///     権限変更
        /// </summary>
        private void chengeKengen()
        {
            string kengen = "";
            kengen = gridKengen.CurrentRow.Cells[2].Value.ToString().Trim();

            if (kengen.Equals("Y"))
            {
                gridKengen.CurrentRow.Cells[2].Value = "N";
            }
            else if (kengen.Equals("N"))
            {
                gridKengen.CurrentRow.Cells[2].Value = "Y";
            }
        }

        // 権限登録
        private void addKengen()
        {
            M1490_Menukengen2_B kengen2B = new M1490_Menukengen2_B();
            // datagridviewのデータ取得
            DataTable dt = (DataTable)this.gridKengen.DataSource;

            string pgno = txtMenukengen2.Text;

            kengen2B.updateKengen(dt, pgno);
        }

        /// <summary>
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setMenuDat(DataTable dtSelectData)
        {
            txtMenukengen2.Text = dtSelectData.Rows[0]["ＰＧ番号"].ToString();
            lblMenuName.Text = dtSelectData.Rows[0]["ＰＧ名"].ToString();
        }

        /// <summary>
        ///     フォーム内の情報をクリア
        /// </summary>
        private void clearForm()
        {
            delFormClear(this, gridKengen);
            txtMenukengen2.Focus();
        }

        /// <summary>
        /// MenuListを閉じたらテキストボックスにフォーカス
        /// </summary>
        public void menuListClose()
        {
            txtMenukengen2.Focus();
        }

    }
}
