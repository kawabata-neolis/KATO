using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;

using Ghostscript.NET.Processor;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    public partial class PrintForm : System.Windows.Forms.Form
    {
        System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

        private int _intPrintCnt = 1;
        public int intPrintCnt
        {
            set
            {
                _intPrintCnt = value;
            }
            get
            {
                return _intPrintCnt;
            }
        }
        private bool diagFlg = true;
        private int _action = 2;
        public int action
        {
            set
            {
                _action = value;
            }
            get
            {
                return _action;
            }
        }

        private string _printer = "";
        public string printer
        {
            set
            {
                _printer = value;
            }
            get
            {
                return _printer;
            }
        }

        private string stPath;
        private string stSize;
        private bool tateFlg;
        private string[] lstSize;

        public PrintForm(Control c, String path, string size, bool tate)
        {
            InitializeComponent();

            PrinterSettings.StringCollection oPrinter;
            oPrinter = PrinterSettings.InstalledPrinters;

            int intIdx = 0;
            foreach (string item in oPrinter)
            {
                prtList.Items.Add(item);
                if (item.Equals(pd.PrinterSettings.PrinterName))
                {
                    prtList.SelectedIndex = intIdx;
                    txtPrt.Text = item;
                    _printer = item;
                }
                intIdx++;
            }
            rdPage0.Checked = true;
            stPath = path;
            stSize = size;
            tateFlg = tate;
            lstSize = CommonTeisu.paramSize[stSize];
            lblPage.Text = stSize.ToUpper() + CommonTeisu.muki[tateFlg];
            
            //画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 150;

            groupBox2.Visible = false;
        }

        private void prtList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrt.Text = prtList.Items[prtList.SelectedIndex].ToString();
            _printer = prtList.Items[prtList.SelectedIndex].ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            _action = CommonTeisu.ACTION_PRINT;
            if (stPath == null || string.IsNullOrEmpty(stPath))
            {
                ((BaseForm)this.Owner).printFlg = CommonTeisu.ACTION_PRINT;
                this.Close();
            }
            else
            {
                for (int i = 0; i < intPrintCnt; i++)
                {
                    execPrint();
                }
                this.Close();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            _action = CommonTeisu.ACTION_PREVIEW;
            if (stPath == null || string.IsNullOrEmpty(stPath)) {
                ((BaseForm)this.Owner).printFlg = CommonTeisu.ACTION_PREVIEW;
                this.Close();
            }
            else
            {
                execPreview(stPath);
            }
        }

        private void baseButton3_Click(object sender, EventArgs e)
        {
            _action = CommonTeisu.ACTION_CANCEL;
            ((BaseForm)this.Owner).printFlg = CommonTeisu.ACTION_CANCEL;
            this.Close();
        }

        public void execPrint(string p, string path, string size, bool tFlg, bool dFlg)
        {
            _action = CommonTeisu.ACTION_PRINT;
            if (p != null && !string.IsNullOrEmpty(p)) {
                _printer = p;
            }
            stPath = path;
            stSize = size;
            tateFlg = tFlg;
            diagFlg = dFlg;
            //execPrint();
            for (int i = 0; i < intPrintCnt; i++)
            {
                execPrint();
            }
            this.Close();
        }

        public void execPrint(string p, string path, string size, bool tFlg, bool dFlg, int pNum)
        {
            _action = CommonTeisu.ACTION_PRINT;
            if (p != null && !string.IsNullOrEmpty(p))
            {
                _printer = p;
            }
            stPath = path;
            stSize = size;
            tateFlg = tFlg;
            diagFlg = dFlg;
            //_intPrintCnt = pNum;
            //execPrint();
            for (int i = 0; i < intPrintCnt; i++)
            {
                execPrint();
            }
            this.Close();
        }

        public void execPreview(string path)
        {
            _action = CommonTeisu.ACTION_PREVIEW;
            stPath = path;
            PDFPreview pv = new PDFPreview(this, stPath);
            pv.ShowDialog();
            pv.Dispose();
            this.Close();
        }

        public void execPrint()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (GhostscriptProcessor processor = new GhostscriptProcessor())
                {
                    if (diagFlg)
                    {
                        if (rdPage1.Checked)
                        {
                            stSize = CommonTeisu.SIZE_B5;
                        }
                        else if (rdPage2.Checked)
                        {
                            stSize = CommonTeisu.SIZE_A4;
                        }
                        if (rdPage3.Checked)
                        {
                            stSize = CommonTeisu.SIZE_B4;
                        }
                        lstSize = CommonTeisu.paramSize[stSize];
                    }


                    List<string> switches = new List<string>();
                    switches.Add("-empty");
                    switches.Add("-dPrinted");
                    switches.Add("-dBATCH");
                    switches.Add("-dNOPAUSE");
                    switches.Add("-dNOSAFER");
                    //switches.Add("-dNumCopies=" + _intPrintCnt.ToString()); //部数
                    switches.Add("-dNumCopies=1"); //部数
                    switches.Add("-sDEVICE=mswinpr2");
                    switches.Add("-sOutputFile=%printer%" + _printer);

                    if (stSize == CommonTeisu.SIZE_NAGA3 || stSize == CommonTeisu.SIZE_NAGA4)
                    {
                        switches.Add("-dManualFeed");
                        switches.Add("-dCasset=1");

                        if (tateFlg)
                        {
                            switches.Add("-dDEVICEWIDTHPOINTS=" + lstSize[1]);
                            switches.Add("-dDEVICEHEIGHTPOINTS=" + lstSize[0]);
                            //switches.Add("-sPAPERSIZE=" + stSize);
                            //switches.Add("-g" + lstSize[1] + "x" + lstSize[0]);
                        }
                        else
                        {
                            //横指定A4
                            switches.Add("-dDEVICEWIDTHPOINTS=" + lstSize[0]);
                            switches.Add("-dDEVICEHEIGHTPOINTS=" + lstSize[1]);
                            //switches.Add("-g" + lstSize[0] + "x" + lstSize[1]);
                        }
                        //switches.Add("-dFitPage");
                    }
                    else
                    {

                        if (tateFlg)
                        {
                            switches.Add("-dDEVICEWIDTHPOINTS=" + lstSize[1]);
                            switches.Add("-dDEVICEHEIGHTPOINTS=" + lstSize[0]);
                            //switches.Add("-sPAPERSIZE=" + stSize);
                            //switches.Add("-g" + lstSize[1] + "x" + lstSize[0]);
                        }
                        else
                        {
                            //横指定A4
                            switches.Add("-dDEVICEWIDTHPOINTS=" + lstSize[0]);
                            switches.Add("-dDEVICEHEIGHTPOINTS=" + lstSize[1]);
                            //switches.Add("-g" + lstSize[0] + "x" + lstSize[1]);
                        }
                        //両面印刷
                        //switches.Add("-dDuplex");//TrueON,false=off
                        //switches.Add("-dTumble=true");//True=短辺綴じ false=長辺綴じ
                        switches.Add("-dFitPage");
                    }

                    switches.Add("-f");
                    switches.Add(stPath);
                    processor.StartProcessing(switches.ToArray(), null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnPrt_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;

            PrinterSettings.StringCollection oPrinter;
            oPrinter = PrinterSettings.InstalledPrinters;

            int intIdx = 0;
            foreach (string item in oPrinter)
            {
                //prtList.Items.Add(item);
                if (item.Equals(pd.PrinterSettings.PrinterName))
                {
                    prtList.SelectedIndex = intIdx;
                }
                intIdx++;
            }

        }

        private void PrintForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                this.Close();
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
