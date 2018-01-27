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
using KATO.Business.C0500_UrikakekinZandakaIchiranKakunin_B;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.C0520_KaikakekinZandakaIchiranKakunin
{
    ///<summary>
    ///C0520_KaikakekinZandakaIchiranKakunin
    ///買掛金残高一覧確認
    ///作成者：大河内
    ///作成日：2018/01/27
    ///更新者：大河内
    ///更新日：2018/01/27
    ///</summary>
    public partial class C0520_KaikakekinZandakaIchiranKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///C0520_KaikakekinZandakaIchiranKakunin
        ///フォームの初期設定
        ///</summary>
        public C0520_KaikakekinZandakaIchiranKakunin(Control c)
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


    }
}
