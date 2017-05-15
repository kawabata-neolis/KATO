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
            #region
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
            hatchusha.DataPropertyName = "発注者";
            hatchusha.Name = "発注者";
            hatchusha.HeaderText = "発注者";
            #endregion

            //バインド、個々の幅、文章の寄せの設定
            #region
            setColumn(juchubi,           130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(noki,              130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(maker,             130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(hinmei,            130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(juchusu,           130, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(juchuzan,          130, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(hatchuzan,         130, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(uriTanka,          130, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(uriKingaku,        130, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siireTanka,        130, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siireKingaku,      130, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(chuban,            130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siireGokeiKingaku, 130, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter);
            setColumn(kyakusakiChuban,   130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(tokuiName,         130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siirebi,           130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siireName,         130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(uriagezumi,        130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(siirezumi,         130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(hatchubi,          130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(jotai,             130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(juchuNo,           130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(juchusha,          130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(tantosha,          130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            setColumn(hatchusha,         130, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter);
            #endregion
        }

        private void setColumn (DataGridViewTextBoxColumn col, int intLen, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader)
        {
            gridZanList.Columns.Add(col);
            if (gridZanList.Columns[col.Name] != null) {
                gridZanList.Columns[col.Name].Width = intLen;
                gridZanList.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridZanList.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;
            }
        }

        private void D0360_JuchuzanKakunin_KeyDown(object sender, KeyEventArgs e)
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
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    this.selZanList();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    this.delText();
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
                    //印刷
                    //PrintReport();
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

        private void delText()
        {
            //フォーム上のデータを白紙
            this.delFormClear(this, gridZanList);
            txtJuchuNo.Focus();
        }

        private void btnFKeys_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 一覧表示
                    this.selZanList();
                    break;
                case STR_BTN_F04: // 取り消し
                    this.delText();
                    break;
                case STR_BTN_F09: // 印刷
                    //this.PrintReport();
                    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        private void selZanList()
        {

            string[] listParam = new string[29];

            setParam(listParam, txtJuchuNo.Text, 0);
            setParam(listParam, txtHachuNo.Text, 1);
            setParam(listParam, txtHinmei.Text, 2);
            setParam(listParam, txtChuban.Text, 3);
            setParam(listParam, txtKyakuChuban.Text, 4);
            setParam(listParam, txtJuchuNokiFrom.Text, 5);
            setParam(listParam, txtJuchuNokiTo.Text, 6);
            setParam(listParam, txtHatchuNokiFrom.Text, 7);
            setParam(listParam, txtHatchuNokiTo.Text, 8);
            setParam(listParam, txtChienFrom.Text, 9);
            setParam(listParam, txtChienTo.Text, 10);
            setParam(listParam, txtJuchubiFrom.Text, 11);
            setParam(listParam, txtJuchubiTo.Text, 12);
            setParam(listParam, txtHatchubiFrom.Text, 13);
            setParam(listParam, txtHatchubiTo.Text, 14);
            setParam(listParam, lsJuchusha.CodeTxtText, 15);
            setParam(listParam, lsHatchusha.CodeTxtText, 16);
            setParam(listParam, lsTantousha.CodeTxtText, 17);
            setParam(listParam, lsTokuisaki.CodeTxtText, 18);
            setParam(listParam, lsShiiresaki.CodeTxtText, 19);
            setParam(listParam, lsDaibunrui.CodeTxtText, 20);
            setParam(listParam, lsChubunrui.CodeTxtText, 21);
            setParam(listParam, lsMaker.CodeTxtText, 22);
            setParam(listParam, (rsNyukazumi.judCheckBtn()).ToString(), 23);
            setParam(listParam, (rsJuchuShubetsu.judCheckBtn()).ToString(), 24);
            setParam(listParam, (rsKyoten.judCheckBtn()).ToString(), 25);
            setParam(listParam, (rsGroup.judCheckBtn()).ToString(), 26);
            setParam(listParam, (rsSortItem.judCheckBtn()).ToString(), 27);
            setParam(listParam, (rsSortOrder.judCheckBtn()).ToString(), 28);

            D0360_JuchuzanKakunin_B bis = new D0360_JuchuzanKakunin_B();
            DataTable dtZanList =  bis.getZanList(listParam);

        }

        private void setParam(string[] lst, string prm, int idx)
        {
            if (prm != null && !StringUtl.blIsEmpty(prm))
            {
                lst[idx] = prm;
            } else
            {
                lst[idx] = null;
            }
        }
    }
}
