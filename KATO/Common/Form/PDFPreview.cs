using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Form
{
    public partial class PDFPreview : System.Windows.Forms.Form
    {
        private int oldWidth;
        private int oldHeight;

        public PDFPreview(Control c, string path)
        {
            InitializeComponent();

            axAcroPDF1.setShowToolbar(true);
            axAcroPDF1.LoadFile(path);

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

        }

        private void PDFPreview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                this.Close();
            }
        }

        private void axAcroPDF1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
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
    }
}
