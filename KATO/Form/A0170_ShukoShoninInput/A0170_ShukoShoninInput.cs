using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Business.A0170_ShukoShoninInput;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.A0170_ShukoShoninInput
{
    ///<summary>
    ///A0170_ShukoShoninInput
    ///商品フォーム
    ///作成者：大河内
    ///作成日：2018/02/22
    ///更新者：
    ///更新日：
    ///カラム論理名
    ///</summary>
    public partial class A0170_ShukoShoninInput : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///A0170_ShukoShoninInput
        ///フォームの初期設定
        ///</summary>
        public A0170_ShukoShoninInput(Control c)
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

            //最大化最小化不可
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //画面サイズを固定
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;
        }

        ///<summary>
        ///A0170_ShukoShoninInput_Load
        ///画面レイアウト設定
        ///</summary>
        private void A0170_ShukoShoninInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "出庫承認入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;    //まだ不明
            this.btnF12.Text = STR_FUNC_F12;

            setupGrid();
        }

        ///<summary>
        ///setupGrid
        ///DataGridView初期設定
        ///</summary>
        private void setupGrid()
        {

        }
    }
}
