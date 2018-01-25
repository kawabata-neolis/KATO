using KATO.Common.Form;
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
    public partial class PDFPreviewM : KATO.Common.Ctl.BaseForm
    {
        private int oldWidth;
        private int oldHeight;
        string strPath = null;

        public PDFPreviewM(Control c, string path)
        {
            InitializeComponent();

            axAcroPDF1.setShowToolbar(true);
            //axAcroPDF1.setLayoutMode("SinglePage");
            if (System.IO.File.Exists(path))
            {
                axAcroPDF1.LoadFile(path);
                strPath = path;
            }

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            //画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = 0;

            oldWidth = this.Width;
            oldHeight = this.Height;
            this.HScroll = false;
            this.VScroll = false;

        }

        private void PDFPreview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                PrintForm pf = new PrintForm(this, strPath, Common.Util.CommonTeisu.SIZE_A4, false);
                pf.ShowDialog(this);
                if (this.printFlg == Common.Util.CommonTeisu.ACTION_PREVIEW)
                {
                    pf.execPreview(strPath);
                    pf.ShowDialog(this);
                }
                else if (this.printFlg == Common.Util.CommonTeisu.ACTION_PRINT)
                {
                    pf.execPrint(null, strPath, Common.Util.CommonTeisu.SIZE_B4, Common.Util.CommonTeisu.YOKO, false);
                    pf.Close();
                    pf.Dispose();
                }
            }
            else if (e.KeyCode == Keys.F12)
            {
                this.Close();
            }
        }

        private void axAcroPDF1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                PrintForm pf = new PrintForm(this, strPath, Common.Util.CommonTeisu.SIZE_A4, false);
                pf.ShowDialog(this);
                if (this.printFlg == Common.Util.CommonTeisu.ACTION_PREVIEW)
                {
                    pf.execPreview(strPath);
                    pf.ShowDialog(this);
                }
                else if (this.printFlg == Common.Util.CommonTeisu.ACTION_PRINT)
                {
                    pf.execPrint(null, strPath, Common.Util.CommonTeisu.SIZE_B4, Common.Util.CommonTeisu.YOKO, false);

                }
            }
            else if (e.KeyCode == Keys.F12)
            {
                this.Close();
            }
        }

        private void PDFPreview_Resize(object sender, EventArgs e)
        {
            axAcroPDF1.Width += this.Width - oldWidth;
            axAcroPDF1.Height += this.Height - oldHeight;

            oldWidth = this.Width;
            oldHeight = this.Height;
        }

        private void baseButton1_Click(object sender, EventArgs e)
        {
            PrintForm pf = new PrintForm(this, strPath, Common.Util.CommonTeisu.SIZE_A4, false);
            pf.ShowDialog(this);
            if (this.printFlg == Common.Util.CommonTeisu.ACTION_PREVIEW)
            {
                pf.execPreview(strPath);
                pf.ShowDialog(this);
            }
            else if (this.printFlg == Common.Util.CommonTeisu.ACTION_PRINT)
            {
                pf.execPrint(null, strPath, Common.Util.CommonTeisu.SIZE_B4, Common.Util.CommonTeisu.YOKO, false);

            }
        }

        private void baseButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PDFPreviewM_Load(object sender, EventArgs e)
        {
            baseButton2.Focus();
        }
    }
}
