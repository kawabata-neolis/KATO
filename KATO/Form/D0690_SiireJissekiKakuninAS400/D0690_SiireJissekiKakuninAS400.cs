using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.D0690_SiireJissekiKakuninAS400;

namespace KATO.Form.D0690_SiireJissekiKakuninAS400
{

    /// <summary>
    /// D0690_SiireJissekiKakuninAS400
    /// 仕入実績確認（AS400）フォーム
    /// 作成者：多田
    /// 作成日：2017/6/30
    /// 更新者：多田
    /// 更新日：2017/6/30
    /// カラム論理名
    /// </summary>
    public partial class D0690_SiireJissekiKakuninAS400 : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private int intFrm;

        /// <summary>
        /// D0690_SiireJissekiKakuninAS400
        /// フォーム関係の設定
        /// <param name="intFrm">画面ID</param>
        /// </summary>
        public D0690_SiireJissekiKakuninAS400(Control c, int intFrm = 0)
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

            // 画面IDをセット
            this.intFrm = intFrm;
        }

        /// <summary>
        /// D0690_SiireJissekiKakuninAS400_Load
        /// 読み込み時
        /// </summary>
        private void D0690_SiireJissekiKakuninAS400_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "仕入実績確認（AS400）";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;
            // F9:検索ボタン無効
            this.btnF09.Enabled = false;

            // 初期表示
            labelSet_Shiiresaki.Focus();

            // 伝票年月日の設定
            txtCalendarYMDEnd.Text = "2005/04/30";
            DateTime dateYMDStart = DateTime.Parse(txtCalendarYMDEnd.Text);
            txtCalendarYMDStart.Text = dateYMDStart.AddMonths(-1).ToString().Substring(0, 8) + "01";

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
            gridSiireJisseki.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn hiduke = new DataGridViewTextBoxColumn();
            hiduke.DataPropertyName = "処理日付";
            hiduke.Name = "処理日付";
            hiduke.HeaderText = "日付";

            DataGridViewTextBoxColumn denpyoNo = new DataGridViewTextBoxColumn();
            denpyoNo.DataPropertyName = "伝票番号";
            denpyoNo.Name = "伝票番号";
            denpyoNo.HeaderText = "伝№";

            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "型番";
            kataban.Name = "型番";
            kataban.HeaderText = "品名・型式";

            DataGridViewTextBoxColumn suuryo = new DataGridViewTextBoxColumn();
            suuryo.DataPropertyName = "数量";
            suuryo.Name = "数量";
            suuryo.HeaderText = "数量";

            DataGridViewTextBoxColumn tanka = new DataGridViewTextBoxColumn();
            tanka.DataPropertyName = "仕入単価";
            tanka.Name = "仕入単価";
            tanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn kingaku = new DataGridViewTextBoxColumn();
            kingaku.DataPropertyName = "仕入金額";
            kingaku.Name = "仕入金額";
            kingaku.HeaderText = "仕入金額";

            DataGridViewTextBoxColumn bikou = new DataGridViewTextBoxColumn();
            bikou.DataPropertyName = "備考";
            bikou.Name = "備考";
            bikou.HeaderText = "備  考";

            DataGridViewTextBoxColumn tekiyou = new DataGridViewTextBoxColumn();
            tekiyou.DataPropertyName = "摘要";
            tekiyou.Name = "摘要";
            tekiyou.HeaderText = "摘  要";

            DataGridViewTextBoxColumn siireName = new DataGridViewTextBoxColumn();
            siireName.DataPropertyName = "仕入先名";
            siireName.Name = "仕入先名";
            siireName.HeaderText = "仕入先名";

            // 個々の幅、文字の寄せ
            setColumn(hiduke, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(denpyoNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 80);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 350);
            setColumn(suuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 80);
            setColumn(tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 120);
            setColumn(kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumn(bikou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(tekiyou, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(siireName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridSiireJisseki.Columns.Add(col);
            if (gridSiireJisseki.Columns[col.Name] != null)
            {
                gridSiireJisseki.Columns[col.Name].Width = intLen;
                gridSiireJisseki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridSiireJisseki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridSiireJisseki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// judTextboxKeyDown
        /// キー入力判定(テキストボックス【labelset及びカレンダ以外全て】)
        /// </summary>
        private void judTextboxKeyDown(object sender, KeyEventArgs e)
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
                    // タブ機能
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
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// D0690_SiireJissekiKakuninAS400_KeyDown
        /// キー入力判定
        /// </summary>
        private void D0690_SiireJissekiKakuninAS400_KeyDown(object sender, KeyEventArgs e)
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
                    this.setSiireJisseki();
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
                case Keys.F10:
                    break;
                case Keys.F11:
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
                    this.setSiireJisseki();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
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
            // 削除するデータ以外を確保
            string strKikanStart = txtCalendarYMDStart.Text;
            string strKikanEnd = txtCalendarYMDEnd.Text;

            // 画面の項目内を白紙にする
            delFormClear(this, gridSiireJisseki);

            txtCalendarYMDStart.Text = strKikanStart;
            txtCalendarYMDEnd.Text = strKikanEnd;

            labelSet_Shiiresaki.Focus();
        }


        /// <summary>
        /// setSiireJisseki
        /// データをグリッドビューに追加
        /// </summary>
        private void setSiireJisseki()
        {
            // データ検索用
            List<string> lstItem = new List<string>();

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            // 空文字判定（仕入先コード、型番、備考、伝票年月日）
            if (labelSet_Shiiresaki.CodeTxtText.Equals("")  && txtKataban.Text.Equals("") && txtBikou.Text.Equals("") && 
                txtCalendarYMDStart.Text.Equals("") && txtCalendarYMDEnd.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "条件を指定してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Shiiresaki.codeTxt.Focus();
                return;
            }

            //仕入先チェック
            if (labelSet_Shiiresaki.chkTxtShiresaki())
            {
                labelSet_Shiiresaki.Focus();

                return;
            }
            
            //開始年月日がある場合
            if (txtCalendarYMDStart.blIsEmpty() == true)
            {
                //日付フォーマット生成、およびチェック
                strYMDformat = txtCalendarYMDStart.chkDateDataFormat(txtCalendarYMDStart.Text);

                //開始年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtCalendarYMDStart.Focus();

                    return;
                }
                else
                {
                    txtCalendarYMDStart.Text = strYMDformat;
                }
            }

            //初期化
            strYMDformat = "";

            //終了年月日がある場合
            if (txtCalendarYMDEnd.blIsEmpty() == true)
            {
                //日付フォーマット生成、およびチェック
                strYMDformat = txtCalendarYMDEnd.chkDateDataFormat(txtCalendarYMDEnd.Text);

                //終了年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtCalendarYMDEnd.Focus();

                    return;
                }
                else
                {
                    txtCalendarYMDEnd.Text = strYMDformat;
                }
            }

            // ビジネス層のインスタンス生成
            D0690_SiireJissekiKakuninAS400_B siireB = new D0690_SiireJissekiKakuninAS400_B();
            try
            {
                // 検索するデータをリストに格納
                lstItem.Add(labelSet_Shiiresaki.CodeTxtText);
                lstItem.Add(txtCalendarYMDStart.Text);
                lstItem.Add(txtCalendarYMDEnd.Text);

                //lstItem.Add(txtKataban.Text);
                double dblKensaku = 0;
                string strUkata;
                if (!double.TryParse(txtKataban.Text, out dblKensaku))
                {
                    //そのまま確保
                    strUkata = txtKataban.Text;
                }
                else
                {
                    //空白削除
                    strUkata = txtKataban.Text.Trim();
                }

                //英字を大文字に
                strUkata = strUkata.ToUpper();

                strUkata = strUkata.Replace(" ", "");

                lstItem.Add(strUkata);

                lstItem.Add(txtBikou.Text);

                // 検索実行
                DataTable dtSiireJissekiList = siireB.getSiireJissekiList(lstItem);

                // データテーブルからデータグリッドへセット
                gridSiireJisseki.DataSource = dtSiireJissekiList;

                if (dtSiireJissekiList.Rows.Count > 0)
                {
                    for (int cnt = 0; cnt < gridSiireJisseki.RowCount; cnt++)
                    {
                        // 数量
                        decimal decSuuryo = decimal.Parse(gridSiireJisseki.Rows[cnt].Cells["数量"].Value.ToString());

                        // 金額・粗利
                        decimal decKingaku = decimal.Parse(gridSiireJisseki.Rows[cnt].Cells["仕入金額"].Value.ToString());

                        // 数量又は金額・粗利がマイナスの場合はフォントカラーを変更
                        if (decSuuryo < 0 || decKingaku < 0)
                        {
                            gridSiireJisseki.Rows[cnt].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }

                    Control cNow = this.ActiveControl;
                    cNow.Focus();
                }

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                return;
            }
            return;
        }

    }
}
