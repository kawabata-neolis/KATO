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

namespace KATO.Form.B1570_NyukinInput
{
    public partial class B1570_NyukinInput : BaseForm
    {
        DataGridViewContentAlignment posLeft   = DataGridViewContentAlignment.MiddleLeft;
        DataGridViewContentAlignment posCenter = DataGridViewContentAlignment.MiddleCenter;
        DataGridViewContentAlignment posRight  = DataGridViewContentAlignment.MiddleRight;

        string fmtNumNormal = "#";
        string fmtNumComma = "#,0";
        string fmtNumPeriod = "#,0.00";
        string fmtYMD = "yyyy/MM/dd";
        string fmtString = null;

        public B1570_NyukinInput(Control c)
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
            gridNyukin.AutoGenerateColumns = false;

            #region 列項目定義
            DataGridViewTextBoxColumn colRowNum = new DataGridViewTextBoxColumn();
            colRowNum.DataPropertyName = "行番号";
            colRowNum.Name = "行番号";
            colRowNum.HeaderText = "No.";
            colRowNum.ReadOnly = true;
            colRowNum.Visible = false;
            setColumn(gridNyukin, colRowNum, posRight, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colDenpyoYmd = new DataGridViewTextBoxColumn();
            colDenpyoYmd.DataPropertyName = "伝票年月日";
            colDenpyoYmd.Name = "伝票年月日";
            colDenpyoYmd.HeaderText = "伝票年月日";
            setColumn(gridNyukin, colDenpyoYmd, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colShimekiriDay = new DataGridViewTextBoxColumn();
            colShimekiriDay.DataPropertyName = "締切日";
            colShimekiriDay.Name = "締切日";
            colShimekiriDay.HeaderText = "締切日";
            setColumn(gridNyukin, colShimekiriDay, posRight, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colShiiresakiCd = new DataGridViewTextBoxColumn();
            colShiiresakiCd.DataPropertyName = "得意先コード";
            colShiiresakiCd.Name = "得意先コード";
            colShiiresakiCd.HeaderText = "得意先コード";
            setColumn(gridNyukin, colShiiresakiCd, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiiresakiNm = new DataGridViewTextBoxColumn();
            colShiiresakiNm.DataPropertyName = "得意先名";
            colShiiresakiNm.Name = "得意先名";
            colShiiresakiNm.HeaderText = "得意先名";
            setColumn(gridNyukin, colShiiresakiNm, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiharaiYoteiYMD = new DataGridViewTextBoxColumn();
            colShiharaiYoteiYMD.DataPropertyName = "入金予定日";
            colShiharaiYoteiYMD.Name = "入金予定日";
            colShiharaiYoteiYMD.HeaderText = "入金予定日";
            setColumn(gridNyukin, colShiharaiYoteiYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colShiharaiYMD = new DataGridViewTextBoxColumn();
            colShiharaiYMD.DataPropertyName = "入金日";
            colShiharaiYMD.Name = "入金日";
            colShiharaiYMD.HeaderText = "入金日";
            setColumn(gridNyukin, colShiharaiYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colDenpyoNo = new DataGridViewTextBoxColumn();
            colDenpyoNo.DataPropertyName = "伝票番号";
            colDenpyoNo.Name = "伝票番号";
            colDenpyoNo.HeaderText = "伝票番号";
            setColumn(gridNyukin, colDenpyoNo, posRight, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colToriKbnCd = new DataGridViewTextBoxColumn();
            colToriKbnCd.DataPropertyName = "取引区分コード";
            colToriKbnCd.Name = "取引区分コード";
            colToriKbnCd.HeaderText = "コード";
            setColumn(gridNyukin, colToriKbnCd, posCenter, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colToriKbnNm = new DataGridViewTextBoxColumn();
            colToriKbnNm.DataPropertyName = "取引区分名";
            colToriKbnNm.Name = "取引区分名";
            colToriKbnNm.HeaderText = "区分名";
            setColumn(gridNyukin, colToriKbnNm, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colKouza = new DataGridViewTextBoxColumn();
            colKouza.DataPropertyName = "口座";
            colKouza.Name = "口座";
            colKouza.HeaderText = "口座";
            setColumn(gridNyukin, colKouza, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colKinyuKikan = new DataGridViewTextBoxColumn();
            colKinyuKikan.DataPropertyName = "金融機関名";
            colKinyuKikan.Name = "金融機関名";
            colKinyuKikan.HeaderText = "金融機関名";
            setColumn(gridNyukin, colKinyuKikan, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiten = new DataGridViewTextBoxColumn();
            colShiten.DataPropertyName = "支店名";
            colShiten.Name = "支店名";
            colShiten.HeaderText = "支店名";
            setColumn(gridNyukin, colShiten, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShiharaiYoteiGaku = new DataGridViewTextBoxColumn();
            colShiharaiYoteiGaku.DataPropertyName = "入金予定額";
            colShiharaiYoteiGaku.Name = "入金予定額";
            colShiharaiYoteiGaku.HeaderText = "入金予定額";
            setColumn(gridNyukin, colShiharaiYoteiGaku, posRight, posCenter, fmtNumComma, 122);

            DataGridViewTextBoxColumn colShiharaiGaku = new DataGridViewTextBoxColumn();
            colShiharaiGaku.DataPropertyName = "入金額";
            colShiharaiGaku.Name = "入金額";
            colShiharaiGaku.HeaderText = "入金額";
            setColumn(gridNyukin, colShiharaiGaku, posRight, posCenter, fmtNumComma, 122);

            DataGridViewTextBoxColumn colTegataYMD = new DataGridViewTextBoxColumn();
            colTegataYMD.DataPropertyName = "手形期日";
            colTegataYMD.Name = "手形期日";
            colTegataYMD.HeaderText = "手形期日";
            setColumn(gridNyukin, colTegataYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colShiharaiMonths = new DataGridViewTextBoxColumn();
            colShiharaiMonths.DataPropertyName = "入金月数";
            colShiharaiMonths.Name = "入金月数";
            colShiharaiMonths.HeaderText = "入金月数";
            setColumn(gridNyukin, colShiharaiMonths, posCenter, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colShiharaiJoken = new DataGridViewTextBoxColumn();
            colShiharaiJoken.DataPropertyName = "支払条件";
            colShiharaiJoken.Name = "支払条件";
            colShiharaiJoken.HeaderText = "支払条件";
            setColumn(gridNyukin, colShiharaiJoken, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colShukinKbn = new DataGridViewTextBoxColumn();
            colShukinKbn.DataPropertyName = "集金区分";
            colShukinKbn.Name = "集金区分";
            colShukinKbn.HeaderText = "集金区分";
            setColumn(gridNyukin, colShukinKbn, posCenter, posCenter, fmtNumNormal, 122);

            DataGridViewTextBoxColumn colMawashisakiNm = new DataGridViewTextBoxColumn();
            colMawashisakiNm.DataPropertyName = "廻し先";
            colMawashisakiNm.Name = "廻し先";
            colMawashisakiNm.HeaderText = "廻し先";
            setColumn(gridNyukin, colMawashisakiNm, posLeft, posCenter, fmtString, 122);

            DataGridViewTextBoxColumn colMawashisakiYMD = new DataGridViewTextBoxColumn();
            colMawashisakiYMD.DataPropertyName = "廻し先日付";
            colMawashisakiYMD.Name = "廻し先日付";
            colMawashisakiYMD.HeaderText = "廻し先日付";
            setColumn(gridNyukin, colMawashisakiYMD, posRight, posCenter, fmtYMD, 122);

            DataGridViewTextBoxColumn colBikou = new DataGridViewTextBoxColumn();
            colBikou.DataPropertyName = "備考";
            colBikou.Name = "備考";
            colBikou.HeaderText = "備考";
            setColumn(gridNyukin, colBikou, posLeft, posCenter, fmtString, 122);

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
