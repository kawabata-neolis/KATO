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

        private string beforeCode = "";

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
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            // ファンクションボタン制御
            this.btnF01.Enabled = false;
            this.btnF04.Enabled = false;
            this.btnF09.Enabled = false;

            // DataGridViewの初期設定
            SetGrid();

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
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addKengen();
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    if (this.btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.clearForm();
                    }
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
                    if (this.ActiveControl == labelSet_Menu)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                        showMenuList();
                    }
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

        private void labelSet_Menu_KeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    showMenuList();
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
                    // フォーカスが下に移動しないようにする
                    e.Handled = true;
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
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                        this.addKengen();
                    }
                    break;
                case STR_BTN_F04: // 取消
                    if (this.btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        this.clearForm();
                    }
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///メニューリストの表示
        ///</summary>
        private void showMenuList()
        {
            MenuList menulist = new MenuList(this, labelSet_Menu);
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

        /// <summary>
        ///     DataGridView初期設定
        /// </summary>
        private void SetGrid()
        {
            // 列自動生成禁止
            gridKengen.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn code = new DataGridViewTextBoxColumn();
            code.DataPropertyName = "担当者コード";
            code.Name = "担当者コード";
            code.HeaderText = "コード";

            DataGridViewTextBoxColumn tanto = new DataGridViewTextBoxColumn();
            tanto.DataPropertyName = "担当者名";
            tanto.Name = "担当者名";
            tanto.HeaderText = "担当者名";

            DataGridViewTextBoxColumn kengen = new DataGridViewTextBoxColumn();
            kengen.DataPropertyName = "権限";
            kengen.Name = "権限";
            kengen.HeaderText = "権限";

            // 個々の幅、文字の寄せ
            setColumn(code, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#", 100);
            setColumn(tanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(kengen, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
        }

        /// <summary>
        ///     DataGridViewのカラム設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridKengen.Columns.Add(col);
            if (gridKengen.Columns[col.Name] != null)
            {
                gridKengen.Columns[col.Name].Width = intLen;
                gridKengen.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridKengen.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridKengen.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///     権限データ取得しgridに表示
        ///</summary>
        private void setGridKengen()
        {
            //前後の空白を取り除く
            labelSet_Menu.CodeTxtText = labelSet_Menu.CodeTxtText.Trim();

            //空文字判定
            if (labelSet_Menu.codeTxt.blIsEmpty() == false)
            {
                return;
            }

            // PGNo.エラーチェック
            if (chkPGNo() == true)
            {
                return;
            }

            M1490_Menukengen2_B kengen2B = new M1490_Menukengen2_B();
            // 入力PGNo.を取得
            string pgno = labelSet_Menu.CodeTxtText;

            try
            {
                var kengen = kengen2B.getKengen(pgno);
                string menuName = kengen.Item1;
                DataTable dtkengen = kengen.Item2;

                if (dtkengen.Rows.Count != 0)
                {
                    labelSet_Menu.ValueLabelText = menuName;
                    gridKengen.DataSource = dtkengen;

                    //labelSet_Menu.codeTxt.Focus();

                    this.btnF01.Enabled = true;
                    this.btnF04.Enabled = true;
                }
                else
                {
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    labelSet_Menu.CodeTxtText = "";
                    labelSet_Menu.codeTxt.Focus();

                    this.btnF01.Enabled = true;
                    this.btnF04.Enabled = true;

                    return;
                }
            }
            catch (Exception ex)
            {
                throw;
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
            if (gridKengen.RowCount != 0)
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
            else
            {
                labelSet_Menu.codeTxt.Focus();
                return;
            }


        }

        // 権限登録
        private void addKengen()
        {
            M1490_Menukengen2_B kengen2B = new M1490_Menukengen2_B();
            // datagridviewのデータ取得
            DataTable dt = (DataTable)this.gridKengen.DataSource;

            string pgno = labelSet_Menu.CodeTxtText;
            try
            {
                kengen2B.updateKengen(dt, pgno);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
            catch(Exception ex)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

        }

        /// <summary>
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setMenuDat(DataTable dtSelectData)
        {
            labelSet_Menu.CodeTxtText = dtSelectData.Rows[0]["ＰＧ番号"].ToString();
            labelSet_Menu.ValueLabelText = dtSelectData.Rows[0]["ＰＧ名"].ToString();
        }

        /// <summary>
        ///     フォーム内の情報をクリア
        /// </summary>
        private void clearForm()
        {
            delFormClear(this, gridKengen);
            labelSet_Menu.codeTxt.Focus();
        }

        /// <summary>
        /// MenuListを閉じたらテキストボックスにフォーカス
        /// </summary>
        public void CloseMenuList()
        {
            setGridKengen();
            labelSet_Menu.codeTxt.Focus();
        }

        ///<summary>
        /// PGNo.チェック
        ///</summary>
        private bool chkPGNo()
        {
            // 禁止文字チェック
            if (StringUtl.JudBanSQL(labelSet_Menu.CodeTxtText) == false)
            {
                // メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_Menu.CodeTxtText = "";

                labelSet_Menu.codeTxt.Focus();
                return true;
            }

            // 数値チェック
            if (StringUtl.JudBanSelect(labelSet_Menu.CodeTxtText, CommonTeisu.NUMBER_ONLY) == false)
            {
                // メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_Menu.CodeTxtText = "";

                labelSet_Menu.codeTxt.Focus();
                return true;
            }
            return false;
        }

        private void labelSet_Menu_Leave(object sender, EventArgs e)
        {
            try
            {
                setGridKengen();
            }
            catch(Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }
    }
}
