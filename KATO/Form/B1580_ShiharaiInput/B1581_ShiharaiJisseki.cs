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
using KATO.Business.B1580_ShiharaiInput;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.B0060_ShiharaiInput_B;

namespace KATO.Form.B1580_ShiharaiInput
{
    public partial class B1581_ShiharaiJisseki : BaseForm
    {
        DataTable dt = null;
        public B1581_ShiharaiJisseki(B1580_ShiharaiInput c, DataTable d)
        {
            InitializeComponent();
            dt = d;
        }

        private void B1581_ShiharaiJisseki_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "支払実績";

            SetUpGrid();
            if (dt != null)
            {
                gridShireJisseki.DataSource = dt;
            }
        }

        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            // 列自動生成禁止
            gridShireJisseki.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn hiduke = new DataGridViewTextBoxColumn();
            hiduke.DataPropertyName = "年月";
            hiduke.Name = "年月";
            hiduke.HeaderText = "年月";

            DataGridViewTextBoxColumn kingaku = new DataGridViewTextBoxColumn();
            kingaku.DataPropertyName = "税抜合計金額";
            kingaku.Name = "税抜合計金額";
            kingaku.HeaderText = "仕入金額";

            DataGridViewTextBoxColumn zei = new DataGridViewTextBoxColumn();
            zei.DataPropertyName = "消費税";
            zei.Name = "消費税";
            zei.HeaderText = "消費税";

            DataGridViewTextBoxColumn goukei = new DataGridViewTextBoxColumn();
            goukei.DataPropertyName = "税込合計金額";
            goukei.Name = "税込合計金額";
            goukei.HeaderText = "合計";

            // 個々の幅、文字の寄せ
            setColumn(hiduke, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM", 90);
            setColumn(kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 160);
            setColumn(zei, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 140);
            setColumn(goukei, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 160);
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridShireJisseki.Columns.Add(col);
            if (gridShireJisseki.Columns[col.Name] != null)
            {
                gridShireJisseki.Columns[col.Name].Width = intLen;
                gridShireJisseki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridShireJisseki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridShireJisseki.Columns[col.Name].DefaultCellStyle.Format = fmt;
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
