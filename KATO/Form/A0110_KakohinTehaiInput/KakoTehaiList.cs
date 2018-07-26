using KATO.Business.A0110_KakohinTehaiInput;
using KATO.Common.Ctl;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Form.A0110_KakohinTehaiInput
{
    public partial class KakoTehaiList : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseTextMoney pDenNo;

        public KakoTehaiList()
        {
            InitializeComponent();
            setupGrid();
        }

        ///<summary>
        ///setupGrid
        ///DataGridView初期設定
        ///</summary>
        private void setupGrid()
        {
            //列自動生成禁止
            gridShukko.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn colYmd = new DataGridViewTextBoxColumn();
            colYmd.DataPropertyName = "年月日";
            colYmd.Name = "年月日";
            colYmd.HeaderText = "年月日";

            DataGridViewTextBoxColumn colShiire = new DataGridViewTextBoxColumn();
            colShiire.DataPropertyName = "仕入先名";
            colShiire.Name = "仕入先名";
            colShiire.HeaderText = "仕入先名";

            DataGridViewTextBoxColumn colHinmei = new DataGridViewTextBoxColumn();
            colHinmei.DataPropertyName = "品名";
            colHinmei.Name = "品名";
            colHinmei.HeaderText = "品名";

            DataGridViewTextBoxColumn colSuryo = new DataGridViewTextBoxColumn();
            colSuryo.DataPropertyName = "数量";
            colSuryo.Name = "数量";
            colSuryo.HeaderText = "数量";

            DataGridViewTextBoxColumn colDenNo = new DataGridViewTextBoxColumn();
            colDenNo.DataPropertyName = "伝票番号";
            colDenNo.Name = "伝票番号";
            colDenNo.HeaderText = "伝票番号";
            colDenNo.Visible = false;

            //個々の幅、文章の寄せ
            setColumn(colYmd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(colShiire, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 265);
            setColumn(colHinmei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 328);
            setColumn(colSuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(colDenNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 265);
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridShukko.Columns.Add(col);
            if (gridShukko.Columns[col.Name] != null)
            {
                gridShukko.Columns[col.Name].Width = intLen;
                gridShukko.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridShukko.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridShukko.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        private void searchList ()
        {
            if (string.IsNullOrWhiteSpace(lsShiire.CodeTxtText)
                && string.IsNullOrWhiteSpace(lsTanto.CodeTxtText)
                && string.IsNullOrWhiteSpace(txtHinmei.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "担当者か仕入先か型番を指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return;
            }

            A0110_KakohinTehaiInput_B bis = new A0110_KakohinTehaiInput_B();
            try
            {
                DataTable dt = bis.searchList(lsShiire.CodeTxtText, lsTanto.CodeTxtText, txtHinmei.Text);

                if (dt != null && dt.Rows.Count > 0)
                {
                    gridShukko.DataSource = dt;
                    lblKensu.Text = "該当件数(" + (dt.Rows.Count).ToString() + "件)";
                    gridShukko.Focus();
                }
                else
                {
                    gridShukko.DataSource = "";
                    lblKensu.Text = "該当件数(0件)";
                }
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        private void setRetVal()
        {
            if (gridShukko[4, gridShukko.CurrentCell.RowIndex].Value != null)
            {
                pDenNo.Text = gridShukko[4, gridShukko.CurrentCell.RowIndex].Value.ToString();
            }
            this.Close();
        }

        private void KakoTehaiList_KeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this.Name, "検索実行"));
                    this.searchList();
                    break;
                case Keys.F12:
                    logger.Info(LogUtil.getMessage(this.Name, "終了実行"));
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void btnF11_Click(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this.Name, "検索実行"));
            this.searchList();
        }

        private void btnF12_Click(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this.Name, "終了実行"));
            this.Close();
        }

        private void gridShukko_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.setRetVal();
            }
        }

        private void gridShukko_DoubleClick(object sender, EventArgs e)
        {
            this.setRetVal();
        }

        private void txtHinmei_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnF11.Focus();
            }
            else if (e.KeyCode == Keys.F11)
            {
                logger.Info(LogUtil.getMessage(this.Name, "検索実行"));
                this.searchList();
            }
            else if (e.KeyCode == Keys.F12)
            {
                logger.Info(LogUtil.getMessage(this.Name, "終了実行"));
                this.Close();
            }
        }
    }
}
