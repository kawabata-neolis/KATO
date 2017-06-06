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
using KATO.Business.D0380_ShohinMotochoKakunin;

namespace KATO.Form.D0380_ShohinMotochoKakunin
{
    ///<summary>
    ///D0380_ShohinMotochoKakunin
    ///商品元帳確認フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class D0380_ShohinMotochoKakunin : BaseForm
    {
        /// <summary>
        /// D0380_ShohinMotochoKakunin
        /// フォーム関係の設定
        /// </summary>
        public D0380_ShohinMotochoKakunin(Control c)
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
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;
        }

        /// <summary>
        /// D0380_ShohinMotochoKakunin_Load
        /// 読み込み時
        /// </summary>
        private void D0380_ShohinMotochoKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品元帳確認";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            //初期表示
            labelSet_Eigyosho.CodeTxtText = "0002";
            labelSet_Eigyosho.Focus();
            labelSet_Daibunrui.Focus();

            txtCalendarYMopen.setUp(0);
            txtCalendarYMclose.setUp(0);
            
            //DataGridViewの初期設定
            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridSeihin.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn hizuke = new DataGridViewTextBoxColumn();
            hizuke.DataPropertyName = "日付";
            hizuke.Name = "日付";
            hizuke.HeaderText = "日付";

            DataGridViewTextBoxColumn denpyo = new DataGridViewTextBoxColumn();
            denpyo.DataPropertyName = "伝票No";
            denpyo.Name = "伝票No";
            denpyo.HeaderText = "伝票No";

            DataGridViewTextBoxColumn kbn = new DataGridViewTextBoxColumn();
            kbn.DataPropertyName = "区分";
            kbn.Name = "区分";
            kbn.HeaderText = "区分";

            DataGridViewTextBoxColumn tekiyo = new DataGridViewTextBoxColumn();
            tekiyo.DataPropertyName = "摘要";
            tekiyo.Name = "摘要";
            tekiyo.HeaderText = "摘　　　要";

            DataGridViewTextBoxColumn nyuko = new DataGridViewTextBoxColumn();
            nyuko.DataPropertyName = "入庫数";
            nyuko.Name = "入庫数";
            nyuko.HeaderText = "入庫数";

            DataGridViewTextBoxColumn shuko = new DataGridViewTextBoxColumn();
            shuko.DataPropertyName = "出庫数";
            shuko.Name = "出庫数";
            shuko.HeaderText = "出庫数";

            DataGridViewTextBoxColumn zaiko = new DataGridViewTextBoxColumn();
            zaiko.DataPropertyName = "在庫数";
            zaiko.Name = "在庫数";
            zaiko.HeaderText = "在庫数";

            DataGridViewTextBoxColumn tanka = new DataGridViewTextBoxColumn();
            tanka.DataPropertyName = "単価";
            tanka.Name = "単価";
            tanka.HeaderText = "単価";

            //バインドしたデータを追加
            gridSeihin.Columns.Add(hizuke);
            gridSeihin.Columns.Add(denpyo);
            gridSeihin.Columns.Add(kbn);
            gridSeihin.Columns.Add(tekiyo);
            gridSeihin.Columns.Add(nyuko);
            gridSeihin.Columns.Add(shuko);
            gridSeihin.Columns.Add(zaiko);
            gridSeihin.Columns.Add(tanka);

            //個々の幅、文章の寄せ
            gridSeihin.Columns["日付"].Width = 100;
            gridSeihin.Columns["日付"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridSeihin.Columns["日付"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridSeihin.Columns["伝票No"].Width = 120;
            gridSeihin.Columns["伝票No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSeihin.Columns["伝票No"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridSeihin.Columns["区分"].Width = 120;
            gridSeihin.Columns["区分"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridSeihin.Columns["区分"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridSeihin.Columns["摘要"].Width = 550;
            gridSeihin.Columns["摘要"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridSeihin.Columns["摘要"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridSeihin.Columns["入庫数"].Width = 120;
            gridSeihin.Columns["入庫数"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSeihin.Columns["入庫数"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridSeihin.Columns["出庫数"].Width = 120;
            gridSeihin.Columns["出庫数"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSeihin.Columns["出庫数"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridSeihin.Columns["在庫数"].Width = 120;
            gridSeihin.Columns["在庫数"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSeihin.Columns["在庫数"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridSeihin.Columns["単価"].Width = 120;
            gridSeihin.Columns["単価"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSeihin.Columns["単価"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// D0380_ShohinMotochoKakunin_KeyDown
        /// キー入力判定
        /// </summary>
        private void D0380_ShohinMotochoKakunin_KeyDown(object sender, KeyEventArgs e)
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
                    this.updShohinMotoCho();
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

        /// <summary>
        /// judShohinTxtKeyDown
        /// キー入力判定
        /// </summary>
        private void judShohinTxtKeyDown(object sender, KeyEventArgs e)
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
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
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

        /// <summary>
        /// judTxtShohinTxtDown
        /// キー入力判定
        /// </summary>
        private void judTxtShohinTxtDown(object sender, KeyEventArgs e)
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
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
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
                    this.setShohinList();
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

        /// <summary>
        /// judBtnClick
        /// ボタンの反応
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    this.updShohinMotoCho();
                    break;
                case STR_BTN_F04: // 取り消し
                    this.delText();
                    break;
                //case STR_BTN_F11: //印刷
                //    this.XX();
                //    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///txtKensaku_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void txtKensaku_Leave(object sender, EventArgs e)
        {
            if (txtKensaku.Text == "")
            {
                return;
            }
            setShohinList();
        }

        ///<summary>
        ///setShohinList
        ///商品リストに移動
        ///</summary>
        private void setShohinList()
        {
            ShouhinList shouhinlist = new ShouhinList(this);
            try
            {
                shouhinlist.intFrmKind = CommonTeisu.FRM_SHOHINMOTOCHOKAKUNIN;
                shouhinlist.strYMD = "";
                shouhinlist.strEigyoushoCode = "";
                shouhinlist.strDaibunruiCode = labelSet_Daibunrui.CodeTxtText;
                shouhinlist.strChubunruiCode = labelSet_Chubunrui.CodeTxtText;
                shouhinlist.strMakerCode = labelSet_Maker.CodeTxtText;
                shouhinlist.strKensaku = txtKensaku.Text;
                shouhinlist.ShowDialog();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// setShouhin
        ///取り出したデータをテキストボックスに配置（商品リスト）
        /// </summary>
        public void setShouhin(DataTable dtShohin)
        {
            labelSet_Daibunrui.CodeTxtText = dtShohin.Rows[0]["大分類コード"].ToString();
            labelSet_Chubunrui.CodeTxtText = dtShohin.Rows[0]["中分類コード"].ToString();
            labelSet_Maker.CodeTxtText = dtShohin.Rows[0]["メーカーコード"].ToString();
            txtShohinCd.Text = dtShohin.Rows[0]["商品コード"].ToString();
            lblGrayTanaHon.Text = dtShohin.Rows[0]["棚番本社"].ToString();
            lblGrayTanaGihu.Text = dtShohin.Rows[0]["棚番岐阜"].ToString();
            lblGrayShohin.Text = labelSet_Maker.ValueLabelText + " " +
                                 labelSet_Chubunrui.ValueLabelText + " " +
                                 dtShohin.Rows[0]["Ｃ１"].ToString() + " " +
                                 dtShohin.Rows[0]["Ｃ２"].ToString() + " " +
                                 dtShohin.Rows[0]["Ｃ３"].ToString() + " " +
                                 dtShohin.Rows[0]["Ｃ４"].ToString() + " " +
                                 dtShohin.Rows[0]["Ｃ５"].ToString() + " " +
                                 dtShohin.Rows[0]["Ｃ６"].ToString();
        }

        /// <summary>
        /// setZaiko
        ///取り出したデータをテキストボックスに配置（在庫関係リスト）
        /// </summary>
        public void setZaiko(List<string> lstString)
        {
            Control cActiveBefore = this.ActiveControl;

            txtHonZenZaiko.Text = lstString[0];
            txtGihuZenZaiko.Text = lstString[1];
            txtHonNyuko.Text = lstString[2];
            txtGihuNyuko.Text = lstString[3];
            txtHonShuko.Text = lstString[4];
            txtGihuShuko.Text = lstString[5];
            txtHonGenzaiko.Text = lstString[6];
            txtGihuGenzaiko.Text = lstString[7];

            txtHonZenZaiko.Focus();
            txtGihuZenZaiko.Focus();
            txtHonNyuko.Focus();
            txtGihuNyuko.Focus();
            txtHonShuko.Focus();
            txtGihuShuko.Focus();
            txtHonGenzaiko.Focus();
            txtGihuGenzaiko.Focus();
            cActiveBefore.Focus();
        }

        ///<summary>
        ///setShohinClose
        ///setShohinListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setShohinClose()
        {
            txtKensaku.Focus();
        }

        /// <summary>
        /// updShohinMotoCho
        /// データグリッドビューにデータを表示
        /// </summary>
        private void updShohinMotoCho()
        {
            //データ渡し用
            List<string> lstString = new List<string>();
            List<string> lstStringSet = new List<string>();

            DataTable dtSetText;

            if (lblGrayShohin.Text == "" || txtCalendarYMopen.blIsEmpty() == false || txtCalendarYMclose.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

            D0380_ShohinMotochoKakunin_B shohinmotochokakuninB = new D0380_ShohinMotochoKakunin_B();
            try
            {
                lstString.Add(txtShohinCd.Text);
                lstString.Add(labelSet_Eigyosho.CodeTxtText);
                lstString.Add(txtCalendarYMopen.Text);
                lstString.Add(txtCalendarYMclose.Text);

                lstStringSet = shohinmotochokakuninB.setTextBox(lstString);
                //データ配置
                setZaiko(lstStringSet);

//SQL関係のメソッドをビジネスに作成

                //string strSelect;
                //string strFrom;
                //string strWhere;
                //string strOder;

                //string strDateStart;

                //strSelect = "";
                //strSelect = strSelect + "伝票年月日,伝票番号,行番号,取引区分名,";
                //strSelect = strSelect + "名前,入庫数,出庫数,0,";
                //strSelect = strSelect + "取引区分,単価";

                //strFrom = " 商品在庫元帳_VIEW";

                //strWhere = " 商品コード = '" + txtSyohinCD.data + "'";

                ////2005.09.19
                //if (!txtEigyousyo.isEmpty)
                //{
                //    strWhere = strWhere + " AND 倉庫 = '" + txtEigyousyo.data + "'";
                //}

                //strWhere = strWhere + " AND 伝票年月日 >='" + dateStratYMD + "'";
                //strWhere = strWhere + " AND 伝票年月日 <='" + dateEndYMD + "'";


                //strOder = " ORDER BY 伝票年月日,表示順,伝票番号,行番号 ";

                //grdTorihiki.Visible = false;

                //grdTorihiki.showSQLSelect(strSelect, strFrom, strWhere, strOder);

                //int i;
                //int j;
                //int pre;
                //object preYMD;
                //pre = 0;
                ////UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                ////UPGRADE_WARNING: オブジェクト preYMD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //preYMD = System.DBNull.Value;

                //for (i = 1; i <= grdTorihiki.rowCount; i++)
                //{
                //    if (i == 1)
                //    {
                //        if (txtEigyousyo.data == "0001")
                //        {
                //            //UPGRADE_WARNING: UserControl メソッド grdTorihiki.cellData には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
                //            //UPGRADE_WARNING: オブジェクト PutIsNull() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //            //UPGRADE_WARNING: オブジェクト PutIsNull(txtZenZan.data, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //            //UPGRADE_WARNING: オブジェクト grdTorihiki.cellData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //            grdTorihiki.cellData(8, i) = PutIsNull((txtZenZan.data), 0) + (double)PutIsNull(grdTorihiki.cellData(6, i), 0) - (double)PutIsNull(grdTorihiki.cellData(7, i), 0);
                //        }
                //        else
                //        {
                //            //UPGRADE_WARNING: UserControl メソッド grdTorihiki.cellData には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
                //            //UPGRADE_WARNING: オブジェクト PutIsNull() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //            //UPGRADE_WARNING: オブジェクト PutIsNull(txtZenZan2.data, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //            //UPGRADE_WARNING: オブジェクト grdTorihiki.cellData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //            grdTorihiki.cellData(8, i) = PutIsNull((txtZenZan2.data), 0) + (double)PutIsNull(grdTorihiki.cellData(6, i), 0) - (double)PutIsNull(grdTorihiki.cellData(7, i), 0);
                //        }
                //    }
                //    else
                //    {
                //        //UPGRADE_WARNING: UserControl メソッド grdTorihiki.cellData には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
                //        //UPGRADE_WARNING: オブジェクト PutIsNull() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //        //UPGRADE_WARNING: オブジェクト grdTorihiki.cellData(8, i - 1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //        //UPGRADE_WARNING: オブジェクト grdTorihiki.cellData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                //        grdTorihiki.cellData(8, i) = grdTorihiki.cellData(8, i - 1) + (double)PutIsNull(grdTorihiki.cellData(6, i), 0) - (double)PutIsNull(grdTorihiki.cellData(7, i), 0);
                //    }
                //}

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return;


            gridSeihin.Visible = true;
            gridSeihin.Focus();

        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            string strkensakuopen = txtCalendarYMopen.Text;
            string strkensakuclose = txtCalendarYMclose.Text;

            delFormClear(this, gridSeihin);
            txtHonZenZaiko.Clear();
            txtGihuZenZaiko.Clear();
            txtHonNyuko.Clear();
            txtGihuNyuko.Clear();
            txtHonShuko.Clear();
            txtGihuShuko.Clear();
            txtHonGenzaiko.Clear();
            txtGihuGenzaiko.Clear();

            txtCalendarYMopen.Text = strkensakuopen;
            txtCalendarYMclose.Text = strkensakuclose;
        }
    }
}
