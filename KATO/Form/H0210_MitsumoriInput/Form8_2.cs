using ClosedXML.Excel;
using KATO.Business.H0210_MitsumoriInput;
using KATO.Common.Ctl;
using KATO.Common.Form;
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
    public partial class Form8_2 : BaseForm
    {
        string strPdfPath = System.Configuration.ConfigurationManager.AppSettings["pdfpath"];
        BaseTextMoney nm;
        public int printFlg = 0;

        //Form8_3 f83;

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
            kingaku.DataPropertyName = "売上金額";
            kingaku.Name = "売上金額";
            kingaku.HeaderText = "見積金額";
            kingaku.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn memo = new DataGridViewTextBoxColumn();
            memo.DataPropertyName = "社内メモ";
            memo.Name = "社内メモ";
            memo.HeaderText = "社内メモ";
            memo.Visible = false;

            DataGridViewTextBoxColumn tanto = new DataGridViewTextBoxColumn();
            tanto.DataPropertyName = "担当者名";
            tanto.Name = "担当者名";
            tanto.HeaderText = "担当者名";
            tanto.Visible = false;

            #endregion

            //バインド、個々の幅、文章の寄せの設定
            #region
            setColumn(gridMitsu, shoFlg, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, 26);
            setColumn(gridMitsu, mNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 85);
            setColumn(gridMitsu, mYmd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumn(gridMitsu, torihiki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 183);
            setColumn(gridMitsu, kenmei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 268);
            setColumn(gridMitsu, kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 108);
            setColumn(gridMitsu, memo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumn(gridMitsu, tanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);

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
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int intRowIdx = e.RowIndex;

                if (gridMitsu[6, intRowIdx].Value != null)
                {
                    txtMemo.Text = (gridMitsu[6, intRowIdx].Value).ToString();
                }

                axAcroPDF1.LoadFile("NUL");
                axAcroPDF1.setLayoutMode("SinglePage");
                axAcroPDF1.Refresh();
                string path = (strPdfPath + "_" + gridMitsu[1, intRowIdx].Value).ToString() + "_H.pdf";
                //string path = (strPdfPath + "_" + gridMitsu[1, intRowIdx].Value).ToString() + "_M.pdf";
                if (System.IO.File.Exists(path))
                {
                    //f83.loadFile(path);
                    axAcroPDF1.LoadFile(path);
                    sleepAsync();
                }
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                gridMitsu.Focus();
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
            //if (e.KeyData == Keys.F10)
            //{
            //    changePreview();
            //    e.Handled = true;
            //}
            //else if (e.KeyData == Keys.F11)
            //{
            //    selectMitsumoriList();
            //}
            //else if (e.KeyData == Keys.F12)
            //{
            //    this.Close();
            //}
            //else
            //{

            //}
        }

        private void selectMitsumoriList()
        {
            H0210_MitsumoriInput_B inputB = new H0210_MitsumoriInput_B();

            textBox10.Text = "";

            try
            {
                this.Cursor = Cursors.WaitCursor;
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

                int intCnt = 0;
                if (dt != null && dt.Rows.Count > 0)
                {
                    intCnt = dt.Rows.Count;
                }

                textBox10.Text = intCnt.ToString();

                gridMitsu.DataSource = dt;
                gridMitsu.Focus();
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
            finally
            {
                this.Cursor = Cursors.Default;
            }
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
            if (e.KeyCode == Keys.F1)
            {
                updShonin("1");
            }
            else if (e.KeyCode == Keys.F3)
            {
                updShonin("0");
            }
            else if (e.KeyCode == Keys.F10)
            {
                changePreview();
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
            if (gridMitsu[1, gridMitsu.CurrentCell.RowIndex].Value != null)
            {
                nm.Text = gridMitsu[1, gridMitsu.CurrentCell.RowIndex].Value.ToString();
            }
            this.Close();
        }

        private void Form8_2_Load(object sender, EventArgs e)
        {
            // TODO debug
            //powerUserFlg = true;
            if (!"1".Equals(etsuranFlg))
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
            }
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.txtFrom.Text = (DateTime.Now.AddMonths(-3)).ToString("yyyy/MM");
            this.txtTo.Text = (DateTime.Now).ToString("yyyy/MM");
            this.Activate();
            this.ActiveControl = txtFrom;

            //f83 = new Form8_3(this);
            //f83.Show();
        }

        private void txtTanto_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.F10)
            //{
            //    changePreview();
            //}
            //else if (e.KeyData == Keys.F11)
            //{
            //    selectMitsumoriList();
            //}
            //else if (e.KeyData == Keys.F12)
            //{
            //    this.Close();
            //}
            //else if (e.KeyCode == Keys.Enter)
            //{
            //    this.SelectNextControl(this.ActiveControl, true, true, true, true);
            //}
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void Form8_2_Shown(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            this.Activate();
            this.ActiveControl = txtFrom;
        }

        private void axAcroPDF1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyData == Keys.F10)
            //{
            //    changePreview();
            //}
            //else if (e.KeyData == Keys.F11)
            //{
            //    selectMitsumoriList();
            //}
            //else if (e.KeyData == Keys.F12)
            //{
            //    this.Close();
            //}
            //else
            //{

            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            updShonin("1");
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            updShonin("9");
        }

        private void updShonin(string strFlg)
        {
            int intRowNum = gridMitsu.CurrentCell.RowIndex;
            DataGridViewSelectedRowCollection rc = gridMitsu.SelectedRows;

            H0210_MitsumoriInput_B inputB = new H0210_MitsumoriInput_B();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                inputB.beginTrance();

                int intRowIdx = 0;

                for (int i = 0; i < rc.Count; i++)
                {
                    intRowIdx = rc[i].Index;

                    if (gridMitsu[1, intRowIdx].Value != null)
                    {
                        inputB.updShoninFlg((gridMitsu[1, intRowIdx].Value).ToString(), strFlg, txtMemo.Text);
                    }
                }

                if (rc.Count > 0)
                {
                    inputB.commit();
                }
                selectMitsumoriList();
            }
            catch (Exception ex)
            {
                inputB.rollback();
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string st = printSakuseiList();

                PrintForm pf = new PrintForm(this, st, Common.Util.CommonTeisu.SIZE_A4, true);
                pf.ShowDialog(this);
                //if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                //{
                //    pf.execPreview(st);
                //    pf.ShowDialog(this);
                //}
                //else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                //{
                //    pf.execPrint(null, st, CommonTeisu.SIZE_A4, CommonTeisu.TATE, false);
                //    pf.Close();
                //    pf.Dispose();
                //}
                pf.Dispose();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private string printSakuseiList()
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/H0210_MitsumoriSakuseiList.xlsx";
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);

                IXLWorksheet templatesheet1 = workbook.Worksheet(1);   // テンプレートシート
                //IXLWorksheet templatesheet2 = workbook.Worksheet(2);   // テンプレートシート（明細行のみ）
                IXLWorksheet currentsheet = null;  // 処理中シート

                int pageCnt = 0;    // ページ(シート枚数)カウント
                int xlsRowCnt = 11;  // Excel出力行カウント（開始は出力行）

                templatesheet1.CopyTo("Page" + pageCnt.ToString());
                currentsheet = workbook.Worksheet(workbook.Worksheets.Count);

                string strKikan = "";
                if (!string.IsNullOrWhiteSpace(txtFrom.Text))
                {
                    strKikan += txtFrom.Text;
                    if (!string.IsNullOrWhiteSpace(txtTo.Text))
                    {
                        strKikan += "～";
                    }
                }
                if (!string.IsNullOrWhiteSpace(txtTo.Text))
                {
                    strKikan += txtTo.Text;
                }
                currentsheet.Cell(8, "B").Value = strKikan;

                for (int i = 0; i < gridMitsu.RowCount; i++)
                {
                    if (xlsRowCnt == 55)
                    {
                        pageCnt++;
                        xlsRowCnt = 11;

                        // テンプレートシート（明細行のみ）からコピー
                        templatesheet1.CopyTo("Page" + pageCnt.ToString());
                        currentsheet = workbook.Worksheet(workbook.Worksheets.Count);
                    }
                    currentsheet.Cell(xlsRowCnt, "A").Value = getCellValue(gridMitsu[7, i], false);
                    currentsheet.Cell(xlsRowCnt, "C").Value = getCellValue(gridMitsu[3, i], false);
                    currentsheet.Cell(xlsRowCnt, "D").Value = getCellValue(gridMitsu[2, i], false);
                    currentsheet.Cell(xlsRowCnt, "E").Value = getCellValue(gridMitsu[4, i], false);
                    currentsheet.Cell(xlsRowCnt, "F").Value = getCellValue(gridMitsu[5, i], false);

                    xlsRowCnt++;
                }

                // テンプレートシート削除
                templatesheet1.Delete();
                //templatesheet2.Delete();

                // ページ数設定
                for (pageCnt = 1; pageCnt <= workbook.Worksheets.Count; pageCnt++)
                {
                    workbook.Worksheet(pageCnt).Cell("F3").Value = "'" + pageCnt.ToString() + "/" + (workbook.Worksheets.Count).ToString("0");      // No.
                }

                // workbookを保存
                string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                //string strOutXlsFile = strWorkPath + "_" + txtMNum.Text + ".xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // PDF化の処理
                CreatePdf pdf = new CreatePdf();
                return pdf.createPdf(strOutXlsFile, strDateTime, 0);
                //return pdf.createPdf(strOutXlsFile, "_" + txtMNum.Text, 0);

            }
            catch
            {
                throw;
            }
            finally
            {
                //// Workフォルダの全ファイルを取得
                //string[] files = System.IO.Directory.GetFiles(strWorkPath, "*", System.IO.SearchOption.AllDirectories);
                //// Workフォルダ内のファイル削除
                //foreach (string filepath in files)
                //{
                //    System.IO.File.Delete(filepath);
                //}
                this.Cursor = Cursors.Default;
            }
        }

        private string getCellValue(DataGridViewCell c, bool zero)
        {
            string ret = "";
            if (zero)
            {
                ret = "0";
            }

            if (c != null && c.Value != null && !string.IsNullOrWhiteSpace(c.Value.ToString()))
            {
                ret = c.Value.ToString();
            }
            return ret;
        }

        private void btnF012_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void sleepAsync()
        {
            await Task.Delay(500);
            gridMitsu.Focus();
        }

        private void gridMitsu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (gridMitsu[1, gridMitsu.CurrentCell.RowIndex].Value != null)
                {
                    nm.Text = gridMitsu[1, gridMitsu.CurrentCell.RowIndex].Value.ToString();
                }
                this.Close();
            }
        }
    }
}
