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

namespace KATO.Common.Form
{
    public partial class PrintForm : System.Windows.Forms.Form
    {
        System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

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

        public PrintForm(Control c)
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
                }
                intIdx++;
            }
            rdPage0.Checked = true;
        }

        private void prtList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrt.Text = prtList.Items[prtList.SelectedIndex].ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            _action = CommonTeisu.ACTION_PRINT;
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            _action = CommonTeisu.ACTION_PREVIEW;
            this.Close();
        }

        private void baseButton3_Click(object sender, EventArgs e)
        {
            _action = CommonTeisu.ACTION_CANCEL;
            this.Close();
        }

        public void execPrint()
        {
            // ブラウザコントロールの作成
            AxAcroPDFLib.AxAcroPDF pdfOcx = new AxAcroPDFLib.AxAcroPDF();
            // フォームにコントロールを追加
            this.Controls.Add(pdfOcx);

            // 注意！！
            // フォームへコントロール追加後に非表示にしないと例外発生
            pdfOcx.Visible = false;       // 非表示にする



            // 印刷設定
            pd.DefaultPageSettings.Landscape = true; // 用紙横向



            // PDF ファイルの読み込み
            pdfOcx.LoadFile(@"E:\test1.pdf");

            // 以下のコードでもOK（URL指定でも多分OK）
            //pdfOcx.src = @"E:\test1.pdf";

            pdfOcx.printAll();        // 問答無用で全ページ印刷(デフォルトプリンタ)

            //pdfOcx.printPages(1, 2);  // 印刷範囲を指定して印刷(デフォルトプリンタ)

            //pdfOcx.printWithDialog(); // 印刷ダイアログを出力
        }


    }
}
