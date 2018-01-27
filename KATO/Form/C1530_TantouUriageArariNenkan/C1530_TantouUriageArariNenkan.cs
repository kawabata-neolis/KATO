using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.C1530_TantouUriageArariNenkan_B;

namespace KATO.Form.C1530_TantouUriageArariNenkan
{
    /// <summary>
    /// C1530_TantouUriageArariNenkan
    /// 担当者別売上管理表（年間）フォーム
    /// 作成者：多田
    /// 作成日：2017/8/3
    /// 更新者：多田
    /// 更新日：2017/8/3
    /// カラム論理名
    /// </summary>
    public partial class C1530_TantouUriageArariNenkan : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.  GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// C0140_TantouUriageArariNenkan
        /// フォーム関係の設定
        /// </summary>
        public C1530_TantouUriageArariNenkan(Control c)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            // フォームが最大化されないようにする
            this.MaximizeBox = false;
            // フォームが最小化されないようにする
            this.MinimizeBox = false;

            // 最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            // ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            // 親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;
        }


        /// <summary>
        /// C0140_TantouUriageArariNenkan_Load
        /// 読み込み時
        /// </summary>
        private void C0140_TantouUriageArariNenkan_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "担当者別売上管理表（年間）";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // 初期表示
            txtYear.Focus();

            // DataGridViewの初期設定
            SetUpGrid();
        }

        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            // 列自動生成禁止
            gridUriage.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn tanto1 = new DataGridViewTextBoxColumn();
            tanto1.DataPropertyName = "担当者名";
            tanto1.Name = "担当者名1";
            tanto1.HeaderText = "担当者";

            DataGridViewTextBoxColumn uriage1 = new DataGridViewTextBoxColumn();
            uriage1.DataPropertyName = "売上額1";
            uriage1.Name = "売上額1";
            uriage1.HeaderText = "5月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari1 = new DataGridViewTextBoxColumn();
            arari1.DataPropertyName = "粗利額1";
            arari1.Name = "粗利額1";
            arari1.HeaderText = "5月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu1 = new DataGridViewTextBoxColumn();
            hiritsu1.DataPropertyName = "前年比率1";
            hiritsu1.Name = "前年比率1";
            hiritsu1.HeaderText = "5月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriage2 = new DataGridViewTextBoxColumn();
            uriage2.DataPropertyName = "売上額2";
            uriage2.Name = "売上額2";
            uriage2.HeaderText = "6月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari2 = new DataGridViewTextBoxColumn();
            arari2.DataPropertyName = "粗利額2";
            arari2.Name = "粗利額2";
            arari2.HeaderText = "6月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu2 = new DataGridViewTextBoxColumn();
            hiritsu2.DataPropertyName = "前年比率2";
            hiritsu2.Name = "前年比率2";
            hiritsu2.HeaderText = "6月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriage3 = new DataGridViewTextBoxColumn();
            uriage3.DataPropertyName = "売上額3";
            uriage3.Name = "売上額3";
            uriage3.HeaderText = "7月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari3 = new DataGridViewTextBoxColumn();
            arari3.DataPropertyName = "粗利額3";
            arari3.Name = "粗利額3";
            arari3.HeaderText = "7月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu3 = new DataGridViewTextBoxColumn();
            hiritsu3.DataPropertyName = "前年比率3";
            hiritsu3.Name = "前年比率3";
            hiritsu3.HeaderText = "7月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriage4 = new DataGridViewTextBoxColumn();
            uriage4.DataPropertyName = "売上額4";
            uriage4.Name = "売上額4";
            uriage4.HeaderText = "8月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari4 = new DataGridViewTextBoxColumn();
            arari4.DataPropertyName = "粗利額4";
            arari4.Name = "粗利額4";
            arari4.HeaderText = "8月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu4 = new DataGridViewTextBoxColumn();
            hiritsu4.DataPropertyName = "前年比率4";
            hiritsu4.Name = "前年比率4";
            hiritsu4.HeaderText = "8月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriage5 = new DataGridViewTextBoxColumn();
            uriage5.DataPropertyName = "売上額5";
            uriage5.Name = "売上額5";
            uriage5.HeaderText = "9月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari5 = new DataGridViewTextBoxColumn();
            arari5.DataPropertyName = "粗利額5";
            arari5.Name = "粗利額5";
            arari5.HeaderText = "9月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu5 = new DataGridViewTextBoxColumn();
            hiritsu5.DataPropertyName = "前年比率5";
            hiritsu5.Name = "前年比率5";
            hiritsu5.HeaderText = "9月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriage6 = new DataGridViewTextBoxColumn();
            uriage6.DataPropertyName = "売上額6";
            uriage6.Name = "売上額6";
            uriage6.HeaderText = "10月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari6 = new DataGridViewTextBoxColumn();
            arari6.DataPropertyName = "粗利額6";
            arari6.Name = "粗利額6";
            arari6.HeaderText = "10月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu6 = new DataGridViewTextBoxColumn();
            hiritsu6.DataPropertyName = "前年比率6";
            hiritsu6.Name = "前年比率6";
            hiritsu6.HeaderText = "10月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriageKamiki = new DataGridViewTextBoxColumn();
            uriageKamiki.DataPropertyName = "上期売上額";
            uriageKamiki.Name = "上期売上額";
            uriageKamiki.HeaderText = "上期" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arariKamiki = new DataGridViewTextBoxColumn();
            arariKamiki.DataPropertyName = "上期粗利額";
            arariKamiki.Name = "上期粗利額";
            arariKamiki.HeaderText = "上期" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsuKamiki = new DataGridViewTextBoxColumn();
            hiritsuKamiki.DataPropertyName = "上期前年比率";
            hiritsuKamiki.Name = "上期前年比率";
            hiritsuKamiki.HeaderText = "上期" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn tanto2 = new DataGridViewTextBoxColumn();
            tanto2.DataPropertyName = "担当者名";
            tanto2.Name = "担当者名2";
            tanto2.HeaderText = "担当者";

            DataGridViewTextBoxColumn uriage7 = new DataGridViewTextBoxColumn();
            uriage7.DataPropertyName = "売上額7";
            uriage7.Name = "売上額7";
            uriage7.HeaderText = "11月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari7 = new DataGridViewTextBoxColumn();
            arari7.DataPropertyName = "粗利額7";
            arari7.Name = "粗利額7";
            arari7.HeaderText = "11月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu7 = new DataGridViewTextBoxColumn();
            hiritsu7.DataPropertyName = "前年比率7";
            hiritsu7.Name = "前年比率7";
            hiritsu7.HeaderText = "11月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriage8 = new DataGridViewTextBoxColumn();
            uriage8.DataPropertyName = "売上額8";
            uriage8.Name = "売上額8";
            uriage8.HeaderText = "12月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari8 = new DataGridViewTextBoxColumn();
            arari8.DataPropertyName = "粗利額8";
            arari8.Name = "粗利額8";
            arari8.HeaderText = "12月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu8 = new DataGridViewTextBoxColumn();
            hiritsu8.DataPropertyName = "前年比率8";
            hiritsu8.Name = "前年比率8";
            hiritsu8.HeaderText = "12月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriage9 = new DataGridViewTextBoxColumn();
            uriage9.DataPropertyName = "売上額9";
            uriage9.Name = "売上額9";
            uriage9.HeaderText = "1月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari9 = new DataGridViewTextBoxColumn();
            arari9.DataPropertyName = "粗利額9";
            arari9.Name = "粗利額9";
            arari9.HeaderText = "1月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu9 = new DataGridViewTextBoxColumn();
            hiritsu9.DataPropertyName = "前年比率9";
            hiritsu9.Name = "前年比率9";
            hiritsu9.HeaderText = "1月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriage10 = new DataGridViewTextBoxColumn();
            uriage10.DataPropertyName = "売上額10";
            uriage10.Name = "売上額10";
            uriage10.HeaderText = "2月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari10 = new DataGridViewTextBoxColumn();
            arari10.DataPropertyName = "粗利額10";
            arari10.Name = "粗利額10";
            arari10.HeaderText = "2月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu10 = new DataGridViewTextBoxColumn();
            hiritsu10.DataPropertyName = "前年比率10";
            hiritsu10.Name = "前年比率10";
            hiritsu10.HeaderText = "2月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriage11 = new DataGridViewTextBoxColumn();
            uriage11.DataPropertyName = "売上額11";
            uriage11.Name = "売上額11";
            uriage11.HeaderText = "3月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari11 = new DataGridViewTextBoxColumn();
            arari11.DataPropertyName = "粗利額11";
            arari11.Name = "粗利額11";
            arari11.HeaderText = "3月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu11 = new DataGridViewTextBoxColumn();
            hiritsu11.DataPropertyName = "前年比率11";
            hiritsu11.Name = "前年比率11";
            hiritsu11.HeaderText = "3月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriage12 = new DataGridViewTextBoxColumn();
            uriage12.DataPropertyName = "売上額12";
            uriage12.Name = "売上額12";
            uriage12.HeaderText = "4月" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arari12 = new DataGridViewTextBoxColumn();
            arari12.DataPropertyName = "粗利額12";
            arari12.Name = "粗利額12";
            arari12.HeaderText = "4月" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsu12 = new DataGridViewTextBoxColumn();
            hiritsu12.DataPropertyName = "前年比率12";
            hiritsu12.Name = "前年比率12";
            hiritsu12.HeaderText = "4月" + Environment.NewLine + "昨年比";

            DataGridViewTextBoxColumn uriageSimoki = new DataGridViewTextBoxColumn();
            uriageSimoki.DataPropertyName = "下期売上額";
            uriageSimoki.Name = "下期売上額";
            uriageSimoki.HeaderText = "下期" + Environment.NewLine + "売上";

            DataGridViewTextBoxColumn arariSimoki = new DataGridViewTextBoxColumn();
            arariSimoki.DataPropertyName = "下期粗利額";
            arariSimoki.Name = "下期粗利額";
            arariSimoki.HeaderText = "下期" + Environment.NewLine + "粗利";

            DataGridViewTextBoxColumn hiritsuSimoki = new DataGridViewTextBoxColumn();
            hiritsuSimoki.DataPropertyName = "下期前年比率";
            hiritsuSimoki.Name = "下期前年比率";
            hiritsuSimoki.HeaderText = "下期" + Environment.NewLine + "昨年比";

            // 個々の幅、文字の寄せ
            setColumn(tanto1, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(uriage1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriage2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriage3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriage4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriage5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriage6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriageKamiki, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arariKamiki, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsuKamiki, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(tanto2, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(uriage7, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari7, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu7, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriage8, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari8, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu8, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriage9, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari9, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu9, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriage10, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari10, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu10, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriage11, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari11, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu11, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriage12, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arari12, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsu12, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
            setColumn(uriageSimoki, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(arariSimoki, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(hiritsuSimoki, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0%", 80);
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridUriage.Columns.Add(col);
            if (gridUriage.Columns[col.Name] != null)
            {
                gridUriage.Columns[col.Name].Width = intLen;
                gridUriage.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridUriage.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridUriage.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// C0140_TantouUriageArariNenkan_KeyDown
        /// キー入力判定
        /// </summary>
        private void C0140_TantouUriageArariNenkan_KeyDown(object sender, KeyEventArgs e)
        {
            // キー入力情報によって動作を変える
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
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setUriage();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
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
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printReport();
                    break;
                case Keys.F12:
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
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
                case STR_BTN_F01: // 表示
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setUriage();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printReport();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // 画面の項目内を白紙にする
            delFormClear(this, gridUriage);
        }

        /// <summary>
        /// setUriage
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setUriage()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // 検索するデータをリストに格納
            lstSearchItem.Add(txtYear.Text);

            // ビジネス層のインスタンス生成
            C1530_TantouUriageArariNenkan_B uriagePrint_B = new C1530_TantouUriageArariNenkan_B();
            try
            {
                // 検索実行
                DataTable dtUriage = uriagePrint_B.getUriage(lstSearchItem);
                int rowsCnt = dtUriage.Rows.Count;

                // 対象データがある場合
                if (dtUriage != null && rowsCnt > 0)
                {
                    // 総合計
                    DataRow drGoukei = dtUriage.NewRow();
                    DataTable dt = null;
                    decimal[] decKingaku = uriagePrint_B.getGoukeiKingaku(dtUriage, ref dt);

                    // 総合計行へ値をセット
                    drGoukei["担当者名"] = "総合計";

                    for (int month = 1; month <= 6; month++)
                    {
                        drGoukei["売上額" + month.ToString()] = decKingaku[month * 3 - 3];
                        drGoukei["粗利額" + month.ToString()] = decKingaku[month * 3 - 2];
                        if (decKingaku[month * 3 - 1] == 0)
                        {
                            drGoukei["前年比率" + month.ToString()] = 0;
                        }
                        else
                        {
                            drGoukei["前年比率" + month.ToString()] = decKingaku[month * 3 - 2] / decKingaku[month * 3 - 1];
                        }
                    }
                    drGoukei["上期売上額"] = decKingaku[18];
                    drGoukei["上期粗利額"] = decKingaku[19];
                    if (decKingaku[20] == 0)
                    {
                        drGoukei["上期前年比率"] = 0;
                    }
                    else
                    {
                        drGoukei["上期前年比率"] = decKingaku[19] / decKingaku[20];
                    }

                    for (int month = 7; month <= 12; month++)
                    {
                        drGoukei["売上額" + month.ToString()] = decKingaku[month * 3];
                        drGoukei["粗利額" + month.ToString()] = decKingaku[month * 3 + 1];
                        if (decKingaku[month * 3 + 2] == 0)
                        {
                            drGoukei["前年比率" + month.ToString()] = 0;
                        }
                        else
                        {
                            drGoukei["前年比率" + month.ToString()] = decKingaku[month * 3 + 1] / decKingaku[month * 3 + 2];
                        }
                    }
                    drGoukei["下期売上額"] = decKingaku[39];
                    drGoukei["下期粗利額"] = decKingaku[40];
                    if (decKingaku[41] == 0)
                    {
                        drGoukei["上期前年比率"] = 0;
                    }
                    else
                    {
                        drGoukei["下期前年比率"] = decKingaku[40] / decKingaku[41];
                    }

                    // グループ合計
                    int[] groupRowsCnt = null;
                    int groupsCnt = 0;
                    int groupRowCnt = 0;
                    decimal[,] decKingakuGroup = uriagePrint_B.getGroupKingaku(dtUriage, ref groupRowsCnt, ref groupsCnt);

                    // グループ名を取得
                    DataView dv = new DataView(dtUriage);
                    DataTable dtGroup = dv.ToTable(true, "グループ名");

                    for (int cnt = 0; cnt < groupsCnt; cnt++)
                    {
                        DataRow drGroupGoukei = dtUriage.NewRow();

                        // 合計行へ値をセット
                        drGroupGoukei["担当者名"] = dtGroup.Rows[cnt][0].ToString();

                        for (int month = 1; month <= 6; month++)
                        {
                            drGroupGoukei["売上額" + month.ToString()] = decKingakuGroup[cnt, month * 3 - 3];
                            drGroupGoukei["粗利額" + month.ToString()] = decKingakuGroup[cnt, month * 3 - 2];
                            if (decKingakuGroup[cnt, month * 3 - 1] == 0)
                            {
                                drGroupGoukei["前年比率" + month.ToString()] = 0;
                            }
                            else
                            {
                                drGroupGoukei["前年比率" + month.ToString()] = decKingakuGroup[cnt, month * 3 - 2] / decKingakuGroup[cnt, month * 3 - 1];
                            }
                        }
                        drGroupGoukei["上期売上額"] = decKingakuGroup[cnt, 18];
                        drGroupGoukei["上期粗利額"] = decKingakuGroup[cnt, 19];
                        if (decKingakuGroup[cnt, 20] == 0)
                        {
                            drGroupGoukei["上期前年比率"] = 0;
                        }
                        else
                        {
                            drGroupGoukei["上期前年比率"] = decKingakuGroup[cnt, 19] / decKingakuGroup[cnt, 20];
                        }

                        for (int month = 7; month <= 12; month++)
                        {
                            drGroupGoukei["売上額" + month.ToString()] = decKingakuGroup[cnt, month * 3];
                            drGroupGoukei["粗利額" + month.ToString()] = decKingakuGroup[cnt, month * 3 + 1];
                            if (decKingakuGroup[cnt, month * 3 + 2] == 0)
                            {
                                drGroupGoukei["前年比率" + month.ToString()] = 0;
                            }
                            else
                            {
                                drGroupGoukei["前年比率" + month.ToString()] = decKingakuGroup[cnt, month * 3 + 1] / decKingakuGroup[cnt, month * 3 + 2];
                            }
                        }
                        drGroupGoukei["下期売上額"] = decKingakuGroup[cnt, 39];
                        drGroupGoukei["下期粗利額"] = decKingakuGroup[cnt, 40];
                        if (decKingakuGroup[cnt, 41] == 0)
                        {
                            drGroupGoukei["上期前年比率"] = 0;
                        }
                        else
                        {
                            drGroupGoukei["下期前年比率"] = decKingakuGroup[cnt, 40] / decKingakuGroup[cnt, 41];
                        }

                        // グループ合計行を追加
                        groupRowCnt += groupRowsCnt[cnt];
                        dtUriage.Rows.InsertAt(drGroupGoukei, groupRowCnt + cnt);
                    }

                    // 合計行を追加
                    dtUriage.Rows.Add(drGoukei);

                    // データテーブルからデータグリッドへセット
                    gridUriage.DataSource = dtUriage;
                }

                Control cNow = this.ActiveControl;
                cNow.Focus();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // データチェック
            if (!blnDataCheck())
            {
                return;
            }

            // 検索するデータをリストに格納
            lstSearchItem.Add(txtYear.Text);

            // ビジネス層のインスタンス生成
            C1530_TantouUriageArariNenkan_B uriagePrint_B = new C1530_TantouUriageArariNenkan_B();
            try
            {
                // 検索実行
                DataTable dtUriage = uriagePrint_B.getUriage(lstSearchItem);

                // 対象データがある場合
                if (dtUriage != null && dtUriage.Rows.Count > 0)
                {
                    // 印刷ダイアログ
                    Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A3, CommonTeisu.YOKO);
                    pf.ShowDialog(this);

                    // プレビューの場合
                    if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                    {
                        // PDF作成
                        String strFile = uriagePrint_B.dbToPdf(dtUriage, lstSearchItem);

                        // プレビュー
                        pf.execPreview(strFile);
                        pf.ShowDialog(this);
                    }
                    // 一括印刷の場合
                    else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                    {
                        // PDF作成
                        String strFile = uriagePrint_B.dbToPdf(dtUriage, lstSearchItem);

                        // 一括印刷
                        pf.execPrint(null, strFile, CommonTeisu.SIZE_A3, CommonTeisu.YOKO, true);
                    }

                    pf.Dispose();
                }
                else
                {
                    // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、PDF作成失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "印刷が失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

        /// <summary>
        /// blnDataCheck
        /// データチェック処理
        /// </summary>
        private Boolean blnDataCheck()
        {
            // 空文字判定（年）
            if (txtYear.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。年を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYear.Focus();

                return false;
            }

            return true;
        }

    }
}
