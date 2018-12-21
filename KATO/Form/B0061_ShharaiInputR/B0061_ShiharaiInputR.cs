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
using KATO.Common.Util;
using KATO.Common.Form;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.B0060_ShiharaiInput_B;

namespace KATO.Form.B0061_ShharaiInputR
{
    public partial class B0061_ShiharaiInputR : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public B0061_ShiharaiInputR(Control c)
        {
            this._Title = "支払入力";
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();
        }

        // ロード処理
        private void B0061_ShharaiInputR_Load(object sender, EventArgs e)
        {

        }

        // grid セットアップ
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridShiharaiInput.AutoGenerateColumns = false;

            //データをバインド
            #region
            DataGridViewTextBoxColumn gyoNo = new DataGridViewTextBoxColumn();
            gyoNo.DataPropertyName = "行番号";
            gyoNo.Name = "行番号";
            gyoNo.HeaderText = "行番号";
            gyoNo.Visible = false;

            DataGridViewTextBoxColumn shiireCd = new DataGridViewTextBoxColumn();
            shiireCd.DataPropertyName = "仕入先コード";
            shiireCd.Name = "仕入先コード";
            shiireCd.HeaderText = "コード";

            DataGridViewTextBoxColumn torihikisakiName = new DataGridViewTextBoxColumn();
            torihikisakiName.DataPropertyName = "取引先名";
            torihikisakiName.Name = "取引先名";
            torihikisakiName.HeaderText = "仕入先名";
            torihikisakiName.ReadOnly = true;

            DataGridViewTextBoxColumn shiharaiYmd = new DataGridViewTextBoxColumn();
            shiharaiYmd.DataPropertyName = "支払年月日";
            shiharaiYmd.Name = "支払年月日";
            shiharaiYmd.HeaderText = "支払日";

            DataGridViewTextBoxColumn denpyoNo = new DataGridViewTextBoxColumn();
            denpyoNo.DataPropertyName = "伝票番号";
            denpyoNo.Name = "伝票番号";
            denpyoNo.HeaderText = "伝票番号";

            DataGridViewTextBoxColumn toriKbnCd = new DataGridViewTextBoxColumn();
            toriKbnCd.DataPropertyName = "取引区分コード";
            toriKbnCd.Name = "取引区分コード";
            toriKbnCd.HeaderText = "取引区分コード";
            toriKbnCd.Visible = false;

            DataGridViewTextBoxColumn toriKbnName = new DataGridViewTextBoxColumn();
            toriKbnName.DataPropertyName = "取引区分名";
            toriKbnName.Name = "取引区分名";
            toriKbnName.HeaderText = "取引区分";


            //
            DataGridViewTextBoxColumn koza = new DataGridViewTextBoxColumn();
            koza.DataPropertyName = "口座";
            koza.Name = "口座";
            koza.HeaderText = "口座";

            DataGridViewTextBoxColumn kinyuKikan = new DataGridViewTextBoxColumn();
            kinyuKikan.DataPropertyName = "金融機関名";
            kinyuKikan.Name = "金融機関名";
            kinyuKikan.HeaderText = "金融機関名";
            //


            DataGridViewTextBoxColumn shiharaiGaku = new DataGridViewTextBoxColumn();
            shiharaiGaku.DataPropertyName = "支払額";
            shiharaiGaku.Name = "支払額";
            shiharaiGaku.HeaderText = "支払額";

            DataGridViewTextBoxColumn tegataKijitsu = new DataGridViewTextBoxColumn();
            tegataKijitsu.DataPropertyName = "手形期日";
            tegataKijitsu.Name = "手形期日";
            tegataKijitsu.HeaderText = "手形期日";

            DataGridViewTextBoxColumn biko = new DataGridViewTextBoxColumn();
            biko.DataPropertyName = "備考";
            biko.Name = "備考";
            biko.HeaderText = "備考";
            #endregion

            #region
            setColumn(gyoNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0", 80);
            setColumn(shiireCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumn(torihikisakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 280);
            setColumn(shiharaiYmd, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, 45);
            setColumn(denpyoNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0", 80);
            setColumn(toriKbnCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 160);
            setColumn(toriKbnName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 405);
            setColumn(koza, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 405);
            setColumn(kinyuKikan, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 405);
            setColumn(shiharaiGaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(tegataKijitsu, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 405);
            setColumn(biko, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 405);
            #endregion
        }

        // 列設定
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridShiharaiInput.Columns.Add(col);
            if (gridShiharaiInput.Columns[col.Name] != null)
            {
                gridShiharaiInput.Columns[col.Name].Width = intLen;
                gridShiharaiInput.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridShiharaiInput.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;
                gridShiharaiInput.Columns[col.Name].SortMode = DataGridViewColumnSortMode.Automatic;

                if (fmt != null)
                {
                    gridShiharaiInput.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }
    }

}
