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
using KATO.Form.B1580_ShiharaiInput;
using KATO.Business.B1570_NyukinInput;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.B0060_ShiharaiInput_B;

namespace KATO.Form.B1570_NyukinInput
{
    public partial class B1571_SeikyuRireki : BaseForm
    {
        DataTable dt = null;

        public B1571_SeikyuRireki(B1570_NyukinInput c, DataTable d)
        {
            InitializeComponent();
            dt = d;
        }

        private void B1581_ShiharaiJisseki_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "請求履歴";

            SetUpGrid();
            if (dt != null)
            {
                gridSeikyuRireki.DataSource = dt;
            }
        }

        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            // 列自動生成禁止
            gridSeikyuRireki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn Seikyuubi = new DataGridViewTextBoxColumn();
            Seikyuubi.DataPropertyName = "請求年月日";
            Seikyuubi.Name = "請求年月日";
            Seikyuubi.HeaderText = "請求日";

            DataGridViewTextBoxColumn NyuukinYoteibi = new DataGridViewTextBoxColumn();
            NyuukinYoteibi.DataPropertyName = "入金予定年月日";
            NyuukinYoteibi.Name = "入金予定年月日";
            NyuukinYoteibi.HeaderText = "入金予定日";

            DataGridViewTextBoxColumn ZenkaiSeikyuugaku = new DataGridViewTextBoxColumn();
            ZenkaiSeikyuugaku.DataPropertyName = "前回請求額";
            ZenkaiSeikyuugaku.Name = "前回請求額";
            ZenkaiSeikyuugaku.HeaderText = "前回請求額";

            DataGridViewTextBoxColumn Nyuukingaku = new DataGridViewTextBoxColumn();
            Nyuukingaku.DataPropertyName = "入金額";
            Nyuukingaku.Name = "入金額";
            Nyuukingaku.HeaderText = "入金額";

            DataGridViewTextBoxColumn Kurikosigaku = new DataGridViewTextBoxColumn();
            Kurikosigaku.DataPropertyName = "繰越額";
            Kurikosigaku.Name = "繰越額";
            Kurikosigaku.HeaderText = "繰越額";

            DataGridViewTextBoxColumn Uriagegaku = new DataGridViewTextBoxColumn();
            Uriagegaku.DataPropertyName = "売上額";
            Uriagegaku.Name = "売上額";
            Uriagegaku.HeaderText = "売上額";

            DataGridViewTextBoxColumn Syouhizei = new DataGridViewTextBoxColumn();
            Syouhizei.DataPropertyName = "消費税";
            Syouhizei.Name = "消費税";
            Syouhizei.HeaderText = "消費税";

            DataGridViewTextBoxColumn KonkaiSeikyugaku = new DataGridViewTextBoxColumn();
            KonkaiSeikyugaku.DataPropertyName = "今回請求額";
            KonkaiSeikyugaku.Name = "今回請求額";
            KonkaiSeikyugaku.HeaderText = "今回請求額";


            //個々の幅、文章の寄せ
            setColumn(Seikyuubi, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(NyuukinYoteibi, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(ZenkaiSeikyuugaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            setColumn(Nyuukingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumn(Kurikosigaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumn(Uriagegaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumn(Syouhizei, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumn(KonkaiSeikyugaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridSeikyuRireki.Columns.Add(col);
            if (gridSeikyuRireki.Columns[col.Name] != null)
            {
                gridSeikyuRireki.Columns[col.Name].Width = intLen;
                gridSeikyuRireki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridSeikyuRireki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridSeikyuRireki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        private void btnF12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B1581_ShiharaiJisseki_KeyDown(object sender, KeyEventArgs e)
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
                    break;
                case Keys.F12:
                    this.Close();
                    break;

                default:
                    break;
            }
        }
    }
}
