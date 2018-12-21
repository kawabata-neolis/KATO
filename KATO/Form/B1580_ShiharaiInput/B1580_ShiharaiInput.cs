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
using KATO.Business.B0250_MOnyuryoku;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.B1580_ShiharaiInput
{
    public partial class B1580_ShiharaiInput : BaseForm
    {
        DataGridViewContentAlignment posLeft   = DataGridViewContentAlignment.MiddleLeft;
        DataGridViewContentAlignment posCenter = DataGridViewContentAlignment.MiddleCenter;
        DataGridViewContentAlignment posRight  = DataGridViewContentAlignment.MiddleRight;

        string fmtNumNormal = "#";
        string fmtNumComma  = "#,0";
        string fmtNumPeriod = "#,0.00";
        string fmtYMD       = "yyyy/MM/dd";
        string fmtString    = null;

        public B1580_ShiharaiInput(Control c)
        {
            InitializeComponent();
            setupGrid();
        }

        //
        // grid 初期設定
        //
        private void setupGrid()
        {
            //列自動生成禁止
            gridShiharai.AutoGenerateColumns = false;

            #region 列項目定義
            DataGridViewTextBoxColumn colRowNum = new DataGridViewTextBoxColumn();
            colRowNum.DataPropertyName = "行番号";
            colRowNum.Name = "行番号";
            colRowNum.HeaderText = "No.";
            colRowNum.ReadOnly = true;
            colRowNum.Visible = false;
            setColumn(gridShiharai, colRowNum, posRight, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colDenpyoYmd = new DataGridViewTextBoxColumn();
            colDenpyoYmd.DataPropertyName = "伝票年月日";
            colDenpyoYmd.Name = "伝票年月日";
            colDenpyoYmd.HeaderText = "伝票年月日";
            setColumn(gridShiharai, colDenpyoYmd, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colShimekiriDay = new DataGridViewTextBoxColumn();
            colShimekiriDay.DataPropertyName = "締切日";
            colShimekiriDay.Name = "締切日";
            colShimekiriDay.HeaderText = "締切日";
            setColumn(gridShiharai, colShimekiriDay, posRight, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colShiiresakiCd = new DataGridViewTextBoxColumn();
            colShiiresakiCd.DataPropertyName = "仕入先コード";
            colShiiresakiCd.Name = "仕入先コード";
            colShiiresakiCd.HeaderText = "仕入先コード";
            setColumn(gridShiharai, colShiiresakiCd, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiiresakiNm = new DataGridViewTextBoxColumn();
            colShiiresakiNm.DataPropertyName = "仕入先名";
            colShiiresakiNm.Name = "仕入先名";
            colShiiresakiNm.HeaderText = "仕入先名";
            setColumn(gridShiharai, colShiiresakiNm, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiharaiYoteiYMD = new DataGridViewTextBoxColumn();
            colShiharaiYoteiYMD.DataPropertyName = "支払予定日";
            colShiharaiYoteiYMD.Name = "支払予定日";
            colShiharaiYoteiYMD.HeaderText = "支払予定日";
            setColumn(gridShiharai, colShiharaiYoteiYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colShiharaiYMD = new DataGridViewTextBoxColumn();
            colShiharaiYMD.DataPropertyName = "支払日";
            colShiharaiYMD.Name = "支払日";
            colShiharaiYMD.HeaderText = "支払日";
            setColumn(gridShiharai, colShiharaiYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colDenpyoNo = new DataGridViewTextBoxColumn();
            colDenpyoNo.DataPropertyName = "伝票番号";
            colDenpyoNo.Name = "伝票番号";
            colDenpyoNo.HeaderText = "伝票番号";
            setColumn(gridShiharai, colDenpyoNo, posRight, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colToriKbnCd = new DataGridViewTextBoxColumn();
            colToriKbnCd.DataPropertyName = "取引区分コード";
            colToriKbnCd.Name = "取引区分コード";
            colToriKbnCd.HeaderText = "コード";
            setColumn(gridShiharai, colToriKbnCd, posCenter, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colToriKbnNm = new DataGridViewTextBoxColumn();
            colToriKbnNm.DataPropertyName = "取引区分名";
            colToriKbnNm.Name = "取引区分名";
            colToriKbnNm.HeaderText = "区分名";
            setColumn(gridShiharai, colToriKbnNm, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colKouza = new DataGridViewTextBoxColumn();
            colKouza.DataPropertyName = "口座";
            colKouza.Name = "口座";
            colKouza.HeaderText = "口座";
            setColumn(gridShiharai, colKouza, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colKinyuKikan = new DataGridViewTextBoxColumn();
            colKinyuKikan.DataPropertyName = "金融機関名";
            colKinyuKikan.Name = "金融機関名";
            colKinyuKikan.HeaderText = "金融機関名";
            setColumn(gridShiharai, colKinyuKikan, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiten = new DataGridViewTextBoxColumn();
            colShiten.DataPropertyName = "支店名";
            colShiten.Name = "支店名";
            colShiten.HeaderText = "支店名";
            setColumn(gridShiharai, colShiten, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiharaiYoteiGaku = new DataGridViewTextBoxColumn();
            colShiharaiYoteiGaku.DataPropertyName = "支払予定額";
            colShiharaiYoteiGaku.Name = "支払予定額";
            colShiharaiYoteiGaku.HeaderText = "支払予定額";
            setColumn(gridShiharai, colShiharaiYoteiGaku, posRight, posCenter, fmtNumComma, 122);

            DataGridViewTextBoxColumn colShiharaiGaku = new DataGridViewTextBoxColumn();
            colShiharaiGaku.DataPropertyName = "支払額";
            colShiharaiGaku.Name = "支払額";
            colShiharaiGaku.HeaderText = "支払額";
            setColumn(gridShiharai, colShiharaiGaku, posRight, posCenter, fmtNumComma, 122);

            DataGridViewTextBoxColumn colTegataYMD = new DataGridViewTextBoxColumn();
            colTegataYMD.DataPropertyName = "手形期日";
            colTegataYMD.Name = "手形期日";
            colTegataYMD.HeaderText = "手形期日";
            setColumn(gridShiharai, colTegataYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colShiharaiMonths = new DataGridViewTextBoxColumn();
            colShiharaiMonths.DataPropertyName = "支払月数";
            colShiharaiMonths.Name = "支払月数";
            colShiharaiMonths.HeaderText = "支払月数";
            setColumn(gridShiharai, colShiharaiMonths, posCenter, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colShiharaiJoken = new DataGridViewTextBoxColumn();
            colShiharaiJoken.DataPropertyName = "支払条件";
            colShiharaiJoken.Name = "支払条件";
            colShiharaiJoken.HeaderText = "支払条件";
            setColumn(gridShiharai, colShiharaiJoken, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShukinKbn = new DataGridViewTextBoxColumn();
            colShukinKbn.DataPropertyName = "集金区分";
            colShukinKbn.Name = "集金区分";
            colShukinKbn.HeaderText = "集金区分";
            setColumn(gridShiharai, colShukinKbn, posCenter, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colMawashisakiNm = new DataGridViewTextBoxColumn();
            colMawashisakiNm.DataPropertyName = "廻し先";
            colMawashisakiNm.Name = "廻し先";
            colMawashisakiNm.HeaderText = "廻し先";
            setColumn(gridShiharai, colMawashisakiNm, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colMawashisakiYMD = new DataGridViewTextBoxColumn();
            colMawashisakiYMD.DataPropertyName = "廻し先日付";
            colMawashisakiYMD.Name = "廻し先日付";
            colMawashisakiYMD.HeaderText = "廻し先日付";
            setColumn(gridShiharai, colMawashisakiYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colBikou = new DataGridViewTextBoxColumn();
            colBikou.DataPropertyName = "備考";
            colBikou.Name = "備考";
            colBikou.HeaderText = "備考";
            setColumn(gridShiharai, colBikou, posLeft, posCenter, fmtString, 122);

            #endregion
        }

        //
        // grid列セット
        //
        private void setColumn(Common.Ctl.BaseDataGridViewEdit gr, DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gr.Columns.Add(col);
            if (gr.Columns[col.Name] != null)
            {
                gr.Columns[col.Name].Width = intLen;
                gr.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gr.Columns[col.Name].HeaderCell.Style.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                gr.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;
                gr.Columns[col.Name].SortMode = DataGridViewColumnSortMode.NotSortable;


                if (fmt != null)
                {
                    gr.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }
    }
}
