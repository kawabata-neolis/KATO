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
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.D0360_JuchuzanKakunin;

namespace KATO.Form.D0360_JuchuzanKakunin
{
    public partial class D0360_JuchuzanKakunin : BaseForm
    {
        public D0360_JuchuzanKakunin(Control c)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;

            //最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;

            //中分類setデータを読めるようにする
            lsDaibunrui.Lschubundata = lsChubunrui;
        }

        private void JuchuzanKakunin_Load(object sender, EventArgs e)
        {
            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridZanList.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn juchubi = new DataGridViewTextBoxColumn();
            juchubi.DataPropertyName = "受注日";
            juchubi.Name = "受注日";
            juchubi.HeaderText = "受注日";

            DataGridViewTextBoxColumn noki = new DataGridViewTextBoxColumn();
            noki.DataPropertyName = "納期";
            noki.Name = "納期";
            noki.HeaderText = "納期";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー";
            maker.Name = "メーカー";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn hinmei = new DataGridViewTextBoxColumn();
            hinmei.DataPropertyName = "品名";
            hinmei.Name = "品名";
            hinmei.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn juchusu = new DataGridViewTextBoxColumn();
            juchusu.DataPropertyName = "受注数";
            juchusu.Name = "受注数";
            juchusu.HeaderText = "受注数";

            DataGridViewTextBoxColumn juchuzan = new DataGridViewTextBoxColumn();
            juchuzan.DataPropertyName = "受注残";
            juchuzan.Name = "受注残";
            juchuzan.HeaderText = "受注残";

            DataGridViewTextBoxColumn hatchuzan = new DataGridViewTextBoxColumn();
            hatchuzan.DataPropertyName = "発注残";
            hatchuzan.Name = "発注残";
            hatchuzan.HeaderText = "発注残";

            DataGridViewTextBoxColumn uriTanka = new DataGridViewTextBoxColumn();
            uriTanka.DataPropertyName = "売上単価";
            uriTanka.Name = "売上単価";
            uriTanka.HeaderText = "売上単価";

            DataGridViewTextBoxColumn uriKingaku = new DataGridViewTextBoxColumn();
            uriKingaku.DataPropertyName = "売上金額";
            uriKingaku.Name = "売上金額";
            uriKingaku.HeaderText = "売上金額";

            DataGridViewTextBoxColumn siireTanka = new DataGridViewTextBoxColumn();
            siireTanka.DataPropertyName = "仕入単価";
            siireTanka.Name = "仕入単価";
            siireTanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn siireKingaku = new DataGridViewTextBoxColumn();
            siireKingaku.DataPropertyName = "仕入金額";
            siireKingaku.Name = "仕入金額";
            siireKingaku.HeaderText = "仕入金額";

            DataGridViewTextBoxColumn chuban = new DataGridViewTextBoxColumn();
            chuban.DataPropertyName = "注番";
            chuban.Name = "注番";
            chuban.HeaderText = "注番";

            DataGridViewTextBoxColumn siireGokeiKingaku = new DataGridViewTextBoxColumn();
            siireGokeiKingaku.DataPropertyName = "仕入合計金額";
            siireGokeiKingaku.Name = "仕入合計金額";
            siireGokeiKingaku.HeaderText = "仕入合計金額";

            DataGridViewTextBoxColumn kyakusakiChuban = new DataGridViewTextBoxColumn();
            kyakusakiChuban.DataPropertyName = "客先注番";
            kyakusakiChuban.Name = "客先注番";
            kyakusakiChuban.HeaderText = "客先注番";

            DataGridViewTextBoxColumn tokuiName = new DataGridViewTextBoxColumn();
            tokuiName.DataPropertyName = "得意先名";
            tokuiName.Name = "得意先名";
            tokuiName.HeaderText = "得意先名";

            DataGridViewTextBoxColumn siirebi = new DataGridViewTextBoxColumn();
            siirebi.DataPropertyName = "仕入日";
            siirebi.Name = "仕入日";
            siirebi.HeaderText = "仕入日";

            DataGridViewTextBoxColumn siireName = new DataGridViewTextBoxColumn();
            siireName.DataPropertyName = "仕入先名";
            siireName.Name = "仕入先名";
            siireName.HeaderText = "仕入先名";

            DataGridViewTextBoxColumn uriagezumi = new DataGridViewTextBoxColumn();
            uriagezumi.DataPropertyName = "売上済";
            uriagezumi.Name = "売上済";
            uriagezumi.HeaderText = "売上済";

            DataGridViewTextBoxColumn siirezumi = new DataGridViewTextBoxColumn();
            siirezumi.DataPropertyName = "仕入済";
            siirezumi.Name = "仕入済";
            siirezumi.HeaderText = "仕入済";

            DataGridViewTextBoxColumn hatchubi = new DataGridViewTextBoxColumn();
            hatchubi.DataPropertyName = "発注日";
            hatchubi.Name = "発注日";
            hatchubi.HeaderText = "発注日";

            DataGridViewTextBoxColumn jotai = new DataGridViewTextBoxColumn();
            jotai.DataPropertyName = "状態";
            jotai.Name = "状態";
            jotai.HeaderText = "状態";

            DataGridViewTextBoxColumn juchuNo = new DataGridViewTextBoxColumn();
            juchuNo.DataPropertyName = "受注番号";
            juchuNo.Name = "受注番号";
            juchuNo.HeaderText = "受注番号";

            DataGridViewTextBoxColumn juchusha = new DataGridViewTextBoxColumn();
            juchusha.DataPropertyName = "受注者";
            juchusha.Name = "受注者";
            juchusha.HeaderText = "受注者";

            DataGridViewTextBoxColumn tantosha = new DataGridViewTextBoxColumn();
            tantosha.DataPropertyName = "担当者";
            tantosha.Name = "担当者";
            tantosha.HeaderText = "担当者";

            DataGridViewTextBoxColumn hatchusha = new DataGridViewTextBoxColumn();
            tantosha.DataPropertyName = "発注者";
            tantosha.Name = "発注者";
            tantosha.HeaderText = "発注者";

            //バインドしたデータを追加
            gridZanList.Columns.Add(juchubi);
            gridZanList.Columns.Add(noki);
            gridZanList.Columns.Add(maker);
            gridZanList.Columns.Add(hinmei);
            gridZanList.Columns.Add(juchusu);
            gridZanList.Columns.Add(juchuzan);
            gridZanList.Columns.Add(hatchuzan);
            gridZanList.Columns.Add(uriTanka);
            gridZanList.Columns.Add(uriKingaku);
            gridZanList.Columns.Add(siireTanka);
            gridZanList.Columns.Add(siireKingaku);
            gridZanList.Columns.Add(chuban);
            gridZanList.Columns.Add(siireGokeiKingaku);
            gridZanList.Columns.Add(kyakusakiChuban);
            gridZanList.Columns.Add(tokuiName);
            gridZanList.Columns.Add(siirebi);
            gridZanList.Columns.Add(siireName);
            gridZanList.Columns.Add(uriagezumi);
            gridZanList.Columns.Add(siirezumi);
            gridZanList.Columns.Add(hatchubi);
            gridZanList.Columns.Add(jotai);
            gridZanList.Columns.Add(juchuNo);
            gridZanList.Columns.Add(juchusha);
            gridZanList.Columns.Add(tantosha);
            gridZanList.Columns.Add(tantosha);

            //バインド、個々の幅、文章の寄せの設定
            setColumn(juchubi,           100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(noki,              100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(maker,             100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(hinmei,            100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(juchusu,           100, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(juchuzan,          100, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(hatchuzan,         100, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(uriTanka,          100, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(uriKingaku,        100, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siireTanka,        100, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siireKingaku,      100, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(chuban,            100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siireGokeiKingaku, 100, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(kyakusakiChuban,   100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(tokuiName,         100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siirebi,           100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siireName,         100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(uriagezumi,        100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siirezumi,         100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(hatchubi,          100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(jotai,             100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(juchuNo,           100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(juchusha,          100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(tantosha,          100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(tantosha,          100, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
        }

        private void setColumn (DataGridViewTextBoxColumn col, int intLen, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader)
        {
            gridZanList.Columns.Add(col);
            gridZanList.Columns[col.Name].Width = 100;
            gridZanList.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
            gridZanList.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;
        }
    }
}
