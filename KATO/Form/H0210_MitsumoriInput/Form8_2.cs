using KATO.Business.H0210_MitsumoriInput;
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

namespace KATO.Form.H0210_MitsumoriInput
{
    public partial class Form8_2 : System.Windows.Forms.Form
    {
        string strPdfPath = System.Configuration.ConfigurationManager.AppSettings["pdfpath"];
        BaseTextMoney nm;

        public Form8_2(BaseTextMoney txtNum)
        {
            InitializeComponent();
            axAcroPDF1.setShowToolbar(true);
            axAcroPDF1.setLayoutMode("SinglePage");
            nm = txtNum;

            SetUpGrid();
        }

        private void SetUpGrid()
        {
            //列自動生成禁止
            //gridZanList.AutoGenerateColumns = false;

            //データをバインド
            #region
            DataGridViewTextBoxColumn shoFlg = new DataGridViewTextBoxColumn();
            shoFlg.DataPropertyName = "承認フラグ";
            shoFlg.Name = "承認フラグ";
            shoFlg.HeaderText = "認";
            shoFlg.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn mNo = new DataGridViewTextBoxColumn();
            mNo.DataPropertyName = "見積書番号";
            mNo.Name = "見積書番号";
            mNo.HeaderText = "見積書番号";
            mNo.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn mYmd = new DataGridViewTextBoxColumn();
            mYmd.DataPropertyName = "見積年月日";
            mYmd.Name = "見積年月日";
            mYmd.HeaderText = "見積年月日";
            mYmd.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn torihiki = new DataGridViewTextBoxColumn();
            torihiki.DataPropertyName = "得意先名称";
            torihiki.Name = "得意先名称";
            torihiki.HeaderText = "取引先名";
            torihiki.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn kenmei = new DataGridViewTextBoxColumn();
            kenmei.DataPropertyName = "標題";
            kenmei.Name = "標題";
            kenmei.HeaderText = "件名";
            kenmei.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn kingaku = new DataGridViewTextBoxColumn();
            kingaku.DataPropertyName = "見積金額";
            kingaku.Name = "見積金額";
            kingaku.HeaderText = "見積金額";
            kingaku.SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion

            //バインド、個々の幅、文章の寄せの設定
            #region
            setColumn(gridMitsu, shoFlg, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, 26);
            setColumn(gridMitsu, mNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 85);
            setColumn(gridMitsu, mYmd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumn(gridMitsu, torihiki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 183);
            setColumn(gridMitsu, kenmei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 268);
            setColumn(gridMitsu, kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 108);

            #endregion
        }

        ///<summary>
        ///setColumn
        ///Grid列設定
        ///</summary>
        private void setColumn(Common.Ctl.BaseDataGridView gr, DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gr.Columns.Add(col);
            if (gr.Columns[col.Name] != null)
            {
                gr.Columns[col.Name].Width = intLen;
                gr.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gr.Columns[col.Name].HeaderCell.Style.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                gr.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gr.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int intRowIdx = e.RowIndex;
            axAcroPDF1.LoadFile("NUL");
            axAcroPDF1.setLayoutMode("SinglePage");
            axAcroPDF1.Refresh();
            string path = (strPdfPath + "_" + gridMitsu[1, intRowIdx].Value).ToString() + ".pdf";
            //string path = (strPdfPath + "_" + gridMitsu[1, intRowIdx].Value).ToString() + "_M.pdf";
            if (System.IO.File.Exists(path)) {
                axAcroPDF1.LoadFile(path);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectMitsumoriList();
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            selectMitsumoriList();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F10)
            {
                changePreview();
                e.Handled = true;
            }
            else if (e.KeyData == Keys.F11)
            {
                selectMitsumoriList();
            }
            else if (e.KeyData == Keys.F12)
            {
                this.Close();
            }
            else
            {

            }
        }

        private void selectMitsumoriList()
        {
            H0210_MitsumoriInput_B inputB = new H0210_MitsumoriInput_B();

            try
            {
                int iRd1 = 1;
                if (rdSort2.Checked)
                {
                    iRd1 = 2;
                }
                int iRd2 = 0;
                if (rdShoninYes.Checked)
                {
                    iRd2 = 1;
                }
                else if (rdShoninNo.Checked)
                {
                    iRd2 = 2;
                }

                DataTable dt = inputB.getMitsumoriList(txtFrom.Text, txtTo.Text, lsTanto.CodeTxtText, lsTokui.CodeTxtText,
                    txtTanto.Text, txtKenmei.Text, txtBiko.Text, txtKata.Text, iRd1, iRd2);

                gridMitsu.DataSource = dt;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                inputB.rollback();
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

            gridMitsu.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changePreview();
        }

        private void changePreview()
        {
            PDFPreviewM frm9 = null;

            if (frm9 == null || frm9.IsDisposed)
            {
                //string path = (strPdfPath + "_" + gridMitsu[1, gridMitsu.CurrentRow.Index].Value).ToString() + ".pdf";
                string path = (strPdfPath + "_" + gridMitsu[1, gridMitsu.CurrentRow.Index].Value).ToString() + "_M.pdf";
                if (System.IO.File.Exists(path))
                {
                    if (gridMitsu.Rows.Count > 0)
                    {
                        int intRowIdx = gridMitsu.CurrentRow.Index;
                        frm9 = null;
                        frm9 = new PDFPreviewM(this, path);

                        openChildForm(frm9);
                    }
                }
            }
        }

        private void openChildForm(PDFPreviewM f)
        {
            Screen s = null;
            Screen[] argScreen = Screen.AllScreens;
            if (argScreen.Length > 1)
            {
                s = argScreen[1];
            }
            else
            {
                s = argScreen[0];
            }

            f.StartPosition = FormStartPosition.Manual;
            f.Location = s.Bounds.Location;

            f.ShowDialog();
            f.Dispose();
        }

        private void Form8_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                e.Handled = true;
            }
            else if (e.KeyData == Keys.F11)
            {
                selectMitsumoriList();
            }
            else if (e.KeyData == Keys.F12)
            {
                this.Close();
            }
        }

        private void gridMitsu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridMitsu[1, gridMitsu.CurrentCell.RowIndex].Value != null) {
                nm.Text = gridMitsu[1, gridMitsu.CurrentCell.RowIndex].Value.ToString();
            }
            this.Close();
        }

        private void Form8_2_Load(object sender, EventArgs e)
        {
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.txtFrom.Text = (DateTime.Now.AddMonths(-3)).ToString("yyyy/MM");
            this.txtTo.Text = (DateTime.Now).ToString("yyyy/MM");
            this.Activate();
            this.ActiveControl = txtFrom;
        }

        private void txtTanto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F10)
            {
                changePreview();
                e.Handled = true;
            }
            else if (e.KeyData == Keys.F11)
            {
                selectMitsumoriList();
            }
            else if (e.KeyData == Keys.F12)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void Form8_2_Shown(object sender, EventArgs e)
        {
            this.Activate();
            this.ActiveControl = txtFrom;
        }
    }
}
