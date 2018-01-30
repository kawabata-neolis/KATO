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

namespace KATO.Form.B0060_ShiharaiInput
{
    /// <summary>
    /// B0060_ShiharaiInput
    /// 支払入力フォーム
    /// 作成者：多田
    /// 作成日：2017/6/23
    /// 更新者：大河内
    /// 更新日：2018/01/30
    /// カラム論理名
    /// </summary>
    public partial class B0060_ShiharaiInput : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// B0060_ShiharaiInput
        /// フォーム関係の設定
        /// </summary>
        public B0060_ShiharaiInput(Control c)
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
        /// B0060_ShiharaiInput_Load
        /// 読み込み時
        /// </summary>
        private void B0060_ShiharaiInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "支払入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF06.Text = "F6:終り";
            this.btnF07.Text = "F7:行削除";
            this.btnF08.Text = "F8:元帳";
            this.btnF12.Text = STR_FUNC_F12;

            // 初期表示
            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
            labelSet_Siiresaki.Focus();

            // 伝票年月日の設定
            txtYMD.setUp(0);

            // テスト用に【営業所コード】へ'0001'をセット
            labelSet_Eigyosho.CodeTxtText = "0001";

            //DataGridViewの初期設定
            SetUpGrid();
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

        /// <summary>
        /// B0060_ShiharaiInput_KeyDown
        /// キー入力判定
        /// </summary>
        private void B0060_ShiharaiInput_KeyDown(object sender, KeyEventArgs e)
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
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "追加実行"));
                        this.addShiharai();
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delAllSakujo();
                    }
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    logger.Info(LogUtil.getMessage(this._Title, "F1へフォーカス実行"));
                    this.btnF01.Focus();
                    break;
                case Keys.F7:
                    logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                    this.delGyoSakujo();
                    break;
                case Keys.F8:
                    logger.Info(LogUtil.getMessage(this._Title, "得意先元帳確認実行"));
                    this.showMotocyou();
                    break;
                case Keys.F9:
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
                case STR_BTN_F01: // 追加
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "追加実行"));
                        this.addShiharai();
                    }
                    break;
                case STR_BTN_F03: // 削除
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delAllSakujo();
                    }
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F06: // F1へフォーカス
                    logger.Info(LogUtil.getMessage(this._Title, "F1へフォーカス実行"));
                    this.btnF01.Focus();
                    break;
                case STR_BTN_F07: // 行削除
                    logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                    this.delGyoSakujo();
                    break;
                case STR_BTN_F08: // 得意先元帳確認
                    logger.Info(LogUtil.getMessage(this._Title, "得意先元帳確認実行"));
                    this.showMotocyou();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// updDenpyoYMDLeave
        /// 伝票年月日のテキストボックスからフォーカスが外れた時
        /// </summary>
        private void updDenpyoYMDLeave(object sender, EventArgs e)
        {
            // 日付制限チェック
            dateCheck();
        }

        /// <summary>
        /// updDenpyoNoLeave
        /// 伝票番号のテキストボックスからフォーカスが外れた時
        /// </summary>
        private void updDenpyoNoLeave(object sender, EventArgs e)
        {
            // 伝票番号がない場合
            if (txtDenpyoNo.Text.Equals(""))
            {
                labelSet_Siiresaki.CodeTxtText = "";
                txtShimekiribi.Text = "";
                txtShiharaiGessu.Text = "";
                txtShiharaibi.Text = "";
                txtShiharaiJojen.Text = "";
                txtShukunkbn.Text = "";
                txtZeiHasuuKubun.Text = "";
                gridShireJisseki.DataSource = "";

                // グループボックス内のテキストボックス内の文字を削除
                delMeisai();

                txtYMD.Focus();
            }
            else
            {
                // 伝票番号から支払データを取得し、テキストボックスへ配置
                setShiharai();
            }

            // 機能追加_締切日、支払月数、支払日、支払条件、集金区分表示
            getSiiresakiData();

            // 仕入実績表示
            setSiireJisseki();
        }

        /// <summary>
        /// updTorihikiKbnLeave
        /// 取引区分コードのテキストボックスからフォーカスが外れた時
        /// </summary>
        private void updTorihikiKbnLeave(object sender, EventArgs e)
        {
            this.btnF01.Enabled = true;
        }

        /// <summary>
        /// updKingakuLeave
        /// 支払額のテキストボックスからフォーカスが外れた時
        /// </summary>
        private void updKingakuLeave(object sender, EventArgs e)
        {
            // 合計を出力
            setGoukei();
        }

        /// <summary>
        /// txtDenpyoYMDKeyDown
        /// 伝票年月日のKeyDownイベント
        /// </summary>
        private void txtDenpyoYMDKeyDown(object sender, KeyEventArgs e)
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
                case Keys.PageUp:
                    // 伝票番号の最小値を取得し、伝票番号へセット
                    this.getNextDenpyoNo();
                    txtDenpyoNo.Focus();
                    txtYMD.Focus();
                    break;
                case Keys.PageDown:
                    // 伝票番号の最大値を取得し、伝票番号へセット
                    this.getPrevDenpyoNo();
                    txtDenpyoNo.Focus();
                    txtYMD.Focus();
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
                    break;
            }

            return;
        }

        /// <summary>
        /// txtDenpyoNoKeyDown
        /// 伝票番号のKeyDownイベント
        /// </summary>
        private void txtDenpyoNoKeyDown(object sender, KeyEventArgs e)
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
                case Keys.PageUp:
                    // 伝票番号の最小値を取得し、伝票番号へセット
                    this.getNextDenpyoNo();
                    txtYMD.Focus();
                    break;
                case Keys.PageDown:
                    // 伝票番号の最大値を取得し、伝票番号へセット
                    this.getPrevDenpyoNo();
                    txtYMD.Focus();
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
                    this.setShiharaiList();  // 支払リスト表示
                    this.dateCheck();  // 日付制限チェック
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    break;
            }

            return;
        }

        /// <summary>
        /// txtKingakuKeyDown
        /// 支払額のKeyDownイベント
        /// </summary>
        private void txtKingakuKeyDown(object sender, KeyEventArgs e)
        {
            // キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
            }
        }

        /// <summary>
        /// txtBikouKeyDown
        /// 備考のKeyDownイベント
        /// </summary>
        private void txtBikouKeyDown(object sender, KeyEventArgs e)
        {
            // キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
            }
        }

        /// <summary>
        /// txtDenpyoNoKeyPress
        /// 伝票番号のKeyPressイベント
        /// </summary>
        private void txtDenpyoNoKeyPress(object sender, KeyPressEventArgs e)
        {
            // 0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// labelSet_Siiresaki_Leave
        /// 仕入先コードのLeaveイベント
        /// </summary>
        private void labelSet_Siiresaki_Leave(object sender, EventArgs e)
        {
            // 機能追加_締切日、支払月数、支払日、支払条件、集金区分表示
            getSiiresakiData();

            // 仕入実績表示
            setSiireJisseki();
        }

        /// <summary>
        /// setShiharaiList
        /// 支払リストに移動
        /// </summary>
        private void setShiharaiList()
        {
            ShiharaiList shiharailist = new ShiharaiList(this);
            try
            {
                // 【支払リスト用の画面ID】
                // 支払リストの表示、画面IDを渡す
                shiharailist.intFrmKind = CommonTeisu.FRM_TEST;
                shiharailist.ShowDialog();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // 例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }
        }

        /// <summary>
        /// setShiharai
        /// 伝票番号からデータを取得し、テキストボックスに配置
        /// </summary>
        public void setShiharai()
        {
            txtYMD.Text = "";
            labelSet_Siiresaki.CodeTxtText = "";
            txtShimekiribi.Text = "";
            txtShiharaiGessu.Text = "";
            txtShiharaibi.Text = "";
            txtShiharaiJojen.Text = "";
            txtShukunkbn.Text = "";
            txtZeiHasuuKubun.Text = "";
            gridShireJisseki.DataSource = "";

            // グループボックス内のテキストボックス内の文字を削除
            delMeisai();

            B0060_ShiharaiInput_B shiharaiinputB = new B0060_ShiharaiInput_B();
            try
            {
                // 伝票番号から支払を取得
                DataTable dtGetShiharai = shiharaiinputB.getShiharai(txtDenpyoNo.Text);

                if (dtGetShiharai.Rows.Count > 0)
                {
                    txtYMD.Text = string.Format(dtGetShiharai.Rows[0]["支払年月日"].ToString(), "yyyy/MM/dd");
                    labelSet_Siiresaki.CodeTxtText = dtGetShiharai.Rows[0]["仕入先コード"].ToString();

                    Control ctlGb = this.Controls["gbSiharaiInput"];
                    foreach (DataRow drData in dtGetShiharai.Rows)
                    {
                        int cnt = int.Parse(drData["行番号"].ToString()) - 1;
                        ctlGb.Controls["labelSet_TorihikiKbn" + cnt.ToString()].Controls["codeTxt"].Text = drData["取引区分コード"].ToString(); ;
                        ctlGb.Controls["txtKingaku" + cnt.ToString()].Text = decimal.Parse(drData["支払額"].ToString()).ToString("#,#");
                        ctlGb.Controls["txtKijitsuYMD" + cnt.ToString()].Text = string.Format(drData["手形期日"].ToString(), "yyyy/MM/dd");
                        ctlGb.Controls["txtBikou" + cnt.ToString()].Text = drData["備考"].ToString();
                    }

                    // 合計を計算
                    setGoukei();

                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = true;
                }
                else
                {
                    // メッセージボックスの処理、失敗の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtDenpyoNo.Focus();
                }

            }
            catch(Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                // メッセージボックスの処理、失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtDenpyoNo.Focus();
            }
        }

        /// <summary>
        /// setShiharaiDenpyo
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setShiharaiDenpyo(DataTable dtSelectData)
        {
            txtDenpyoNo.Text = dtSelectData.Rows[0]["伝票番号"].ToString();

            // 伝票番号がある場合
            if (!txtDenpyoNo.Text.Equals(""))
            {
                // 伝票番号から支払データを取得し、テキストボックスへ配置
                setShiharai();

                object sender = new object();
                EventArgs e = new EventArgs();
                updDenpyoNoLeave(sender, e);
           }
        }

        /// <summary>
        /// setShiharaiListClose    
        /// setShiharaiListCloseが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setShiharaiListClose()
        {
            txtDenpyoNo.Focus();
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // 削除するデータ以外を確保
            string strDenpyoYMD = txtYMD.Text;
            string strDenpyoNo = txtDenpyoNo.Text;
            string strTantousha = labelSet_Tantousha.CodeTxtText;
            string strEigyosho = labelSet_Eigyosho.CodeTxtText;

            // 画面の項目内を白紙にする
            delFormClear(this, gridShireJisseki);

            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;

            txtYMD.Text = strDenpyoYMD;
            txtDenpyoNo.Text = strDenpyoNo;
            labelSet_Tantousha.CodeTxtText = strTantousha;
            labelSet_Eigyosho.CodeTxtText = strEigyosho;

            labelSet_Siiresaki.Focus();
        }

        /// <summary>
        /// delMeisai
        /// グループボックス内のテキストボックス内の文字を削除
        /// </summary>
        private void delMeisai()
        {
            Control ctlGb = this.Controls["gbSiharaiInput"];
            for (int cnt = 0; cnt <= 9; cnt++)
            {
                ctlGb.Controls["labelSet_TorihikiKbn" + cnt.ToString()].Controls["codeTxt"].Text = "";
                ctlGb.Controls["txtKingaku" + cnt.ToString()].Text = "";
                ctlGb.Controls["txtKijitsuYMD" + cnt.ToString()].Text = "";
                ctlGb.Controls["txtBikou" + cnt.ToString()].Text = "";
            }
            lblGoukeiDisp.Text = "";
        }

        /// <summary>
        /// addShiharai
        /// 支払追加処理
        /// </summary>
        private void addShiharai()
        {
            string strDenpyoNo = "";
            Control ctlGb = this.Controls["gbSiharaiInput"];

            // 空文字判定（伝票年月日、仕入先コード）
            if (txtYMD.blIsEmpty() == false || labelSet_Siiresaki.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

            // 空文字判定（取引区分コードがある場合の金額）
            for (int cnt = 0; cnt <= 9; cnt++)
            {
                if (!ctlGb.Controls["labelSet_TorihikiKbn" + cnt.ToString()].Controls["codeTxt"].Text.Equals(""))
                {
                    if (ctlGb.Controls["txtKingaku" + cnt.ToString()].Text.Equals(""))
                    {
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return;
                    }
                }
            }

            // 日付制限チェック
            if (!dateCheck())
            {
                txtYMD.Focus();
                return;
            }

            B0060_ShiharaiInput_B shiharaiinputB = new B0060_ShiharaiInput_B();
            try
            {
                // 伝票番号がない場合
                if (txtDenpyoNo.Text.Equals(""))
                {
                    strDenpyoNo = shiharaiinputB.getDenpyoNo();
                }
                else
                {
                    strDenpyoNo = txtDenpyoNo.Text;
                }

                string[] strCommontItem = new string[4];
                string[,] strInsertItem = new string[10, 4];

                strCommontItem[0] = strDenpyoNo;
                strCommontItem[1] = Environment.UserName;
                strCommontItem[2] = txtYMD.Text;
                strCommontItem[3] = labelSet_Siiresaki.CodeTxtText;

                for (int cnt = 0; cnt <= 9; cnt++)
                {
                    strInsertItem[cnt, 0] = ctlGb.Controls["labelSet_TorihikiKbn" + cnt.ToString()].Controls["codeTxt"].Text;
                    strInsertItem[cnt, 1] = ctlGb.Controls["txtKingaku" + cnt.ToString()].Text;
                    strInsertItem[cnt, 2] = ctlGb.Controls["txtKijitsuYMD" + cnt.ToString()].Text;
                    strInsertItem[cnt, 3] = ctlGb.Controls["txtBikou" + cnt.ToString()].Text;
                }

                // 表示中の支払を追加する処理
                shiharaiinputB.addShiharai(strCommontItem, strInsertItem);

                // メッセージボックスの処理、追加成功の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、追加失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

            }
            return;
        }

        /// <summary>
        /// delAllSakujo
        /// 支払全削除処理
        /// </summary>
        private void delAllSakujo()
        {
            // 日付制限チェック
            if (!dateCheck())
            {
                return;
            }

            B0060_ShiharaiInput_B shiharaiinputB = new B0060_ShiharaiInput_B();
            try
            {
                string[] strDeleteItem = new String[2];

                // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "表示中のデータを削除します。よろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                // NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                strDeleteItem[0] = txtDenpyoNo.Text;
                strDeleteItem[1] = Environment.UserName;

                // 表示中の支払全削除処理
                shiharaiinputB.delShiharai(strDeleteItem);

                // メッセージボックスの処理、削除成功の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                delText();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "削除が失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

            }
            return;
        }

        /// <summary>
        /// delGyoSakujo
        /// 選択行削除
        /// </summary>
        private void delGyoSakujo()
        {
            int currentRow = 99;
            String strControlName = "";

            // このフォームで現在アクティブなコントロールを取得
            Control cControl = this.ActiveControl;

            // 取得できた場合、名前の右から一文字をCurrentRowに設定する（選択行）
            if (cControl != null)
            {
                strControlName = cControl.Name;
                // 末尾から1文字切り取り
                strControlName = strControlName.Substring(strControlName.Length - 1, 1);
                // 切り取った文字列が数字でなければ処理終了
                if (!int.TryParse(strControlName, out currentRow))
                {
                    return;
                }
                // 数字が0～9の間でない場合、処理終了
                if (currentRow < 0 && currentRow > 9)
                {
                    return;
                }

                // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "選択中の行を削除します。よろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
            
                // NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                Control ctlGb = this.Controls["gbSiharaiInput"];
                for (int cnt = currentRow ; cnt < 9; cnt++)
                {
                    ctlGb.Controls["labelSet_TorihikiKbn" + cnt.ToString()].Controls["codeTxt"].Text = 
                        ((LabelSet_Torihikikbn)ctlGb.Controls["labelSet_TorihikiKbn" + (cnt + 1).ToString()]).Controls["codeTxt"].Text;
                    ctlGb.Controls["txtKingaku" + cnt.ToString()].Text = ((BaseTextMoney)ctlGb.Controls["txtKingaku" + (cnt + 1).ToString()]).Text;
                    ctlGb.Controls["txtKijitsuYMD" + cnt.ToString()].Text = ((TextBox)ctlGb.Controls["txtKijitsuYMD" + (cnt + 1).ToString()]).Text;
                    ctlGb.Controls["txtBikou" + cnt.ToString()].Text = ((TextBox)ctlGb.Controls["txtBikou" + (cnt + 1).ToString()]).Text;
                }

                this.labelSet_Torihikikbn9.CodeTxtText = "";
                this.txtShiharai9.Text = "";
                this.txtTegataYMD9.Text = "";
                this.txtBikou9.Text = "";

                // 合計を再計算
                setGoukei();
            }
        }

        /// <summary>
        /// showMotocyou
        /// 得意先元帳確認フォームを開く
        /// </summary>
        private void showMotocyou()
        {
            // 仕入先コードがある場合
            if (!labelSet_Siiresaki.CodeTxtText.Equals(""))
            {
                // 得意先元帳確認フォームを開く
                E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin tokuisaki = 
                    new E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin(this, 6, labelSet_Siiresaki.CodeTxtText);
                tokuisaki.ShowDialog();
            }
        }

        /// <summary>
        /// getGoukei
        /// 金額の合計処理
        /// </summary>
        private void setGoukei()
        {
            // 仕入先コードがない場合
            if (labelSet_Siiresaki.CodeTxtText.Equals(""))
            {
                return;
            }

            Control ctlGb = this.Controls["gbSiharaiInput"];
            decimal decGoukei = 0;
            for (int cnt = 0; cnt <= 9; cnt++)
            {
                string strKingaku = ((BaseTextMoney)ctlGb.Controls["txtKingaku" + cnt.ToString()]).Text;
                decimal decKingaku;
                if (decimal.TryParse(strKingaku, out decKingaku))
                {
                    decGoukei += decKingaku;
                }
            }
            lblGoukeiDisp.Text = decGoukei.ToString("#,#");
        }

        /// <summary>
        /// getNextDenpyoNo
        /// 伝票番号の最小値を取得し、伝票番号へセット
        /// </summary>
        private void getNextDenpyoNo()
        {
            B0060_ShiharaiInput_B shiharaiinputB = new B0060_ShiharaiInput_B();
            try
            {
                string strDenpyoNo = "";

                // 伝票番号の最小値を取得
                DataTable dtMinDenpyoNo = shiharaiinputB.getMinDenpyoNo(txtDenpyoNo.Text);

                if (dtMinDenpyoNo.Rows.Count > 0)
                {
                    strDenpyoNo = dtMinDenpyoNo.Rows[0]["最小値"].ToString();

                    int intDenpyoNo;
                    int.TryParse(strDenpyoNo, out intDenpyoNo);
                    if (!strDenpyoNo.Equals("") && intDenpyoNo <= 0)
                    {
                        strDenpyoNo = "1";
                    }
                }
                
                txtDenpyoNo.Text = strDenpyoNo;

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        /// <summary>
        /// getPrevDenpyoNo
        /// 伝票番号の最大値を取得し、伝票番号へセット
        /// </summary>
        private void getPrevDenpyoNo()
        {
            B0060_ShiharaiInput_B shiharaiinputB = new B0060_ShiharaiInput_B();
            try
            {
                string strDenpyoNo = "";

                // 伝票番号の最大値を取得
                DataTable dtMinDenpyoNo = shiharaiinputB.getMaxDenpyoNo(txtDenpyoNo.Text);

                if (dtMinDenpyoNo.Rows.Count > 0)
                {
                    strDenpyoNo = dtMinDenpyoNo.Rows[0]["最大値"].ToString();

                    int intDenpyoNo;
                    int.TryParse(strDenpyoNo, out intDenpyoNo);
                    if (!strDenpyoNo.Equals("") && intDenpyoNo <= 0)
                    {
                        strDenpyoNo = "1";
                    }
                }

                txtDenpyoNo.Text = strDenpyoNo;

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }


        /// <summary>
        /// dateCheck
        /// 日付制限チェック
        /// </summary>
        private Boolean dateCheck()
        {
            if (txtYMD.Text.Equals(""))
            {
                return false;
            }

            B0060_ShiharaiInput_B shiharaiinputB = new B0060_ShiharaiInput_B();
            try
            {
                // 日付制限テーブルから最小年月日、最大年月日を取得
                DataTable dtDate = shiharaiinputB.getDate(labelSet_Eigyosho.CodeTxtText);

                if (dtDate.Rows.Count > 0)
                {
                    DateTime dtMinDate = DateTime.Parse(dtDate.Rows[0]["最小年月日"].ToString());
                    DateTime dtMaxDate = DateTime.Parse(dtDate.Rows[0]["最大年月日"].ToString());
                    DateTime dtDenpyoYMD = DateTime.Parse(txtYMD.Text);

                    // 伝票年月日が最小年月日から最大年月日の間の場合
                    if (dtMinDate <= dtDenpyoYMD && dtDenpyoYMD <= dtMaxDate)
                    {
                        return true;
                    }
                    else
                    {
                        // メッセージボックスの処理、日付が範囲外の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "日付が範囲外です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

            }
            return false;
        }

        /// <summary>
        /// getSiiresakiData
        /// 機能追加_取引先の情報を表示（締切日、支払月数、支払日、支払条件、集金区分）
        /// </summary>
        private void getSiiresakiData()
        {
            // データ検索用
            List<string> lstSiiresakiDataLoad = new List<string>();

            // 検索時のデータ取り出し先
            DataTable dtSetView;

            // 空文字判定（仕入先コード）
            if (labelSet_Siiresaki.CodeTxtText.Equals(""))
            {
                return;
            }

            // ビジネス層のインスタンス生成
            B0060_ShiharaiInput_B shiharaiInputB = new B0060_ShiharaiInput_B();
            try
            {
                // データの存在確認を検索する情報を入れる
                /* [0]仕入先コード */
                lstSiiresakiDataLoad.Add(labelSet_Siiresaki.CodeTxtText);

                // ビジネス層、取引先情報表示用ロジックに移動
                dtSetView = shiharaiInputB.getSiiresakiData(lstSiiresakiDataLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    txtShimekiribi.Text = dtSetView.Rows[0]["締切日"].ToString();
                    txtShiharaiGessu.Text = dtSetView.Rows[0]["支払月数"].ToString();
                    txtShiharaibi.Text = dtSetView.Rows[0]["支払日"].ToString();
                    txtShiharaiJojen.Text = dtSetView.Rows[0]["支払条件"].ToString().Trim();
                    txtShukunkbn.Text = dtSetView.Rows[0]["集金区分"].ToString();
                    txtZeiHasuuKubun.Text = dtSetView.Rows[0]["消費税端数計算区分"].ToString();
                }
                else
                {
                    txtShimekiribi.Text = "";
                    txtShiharaiGessu.Text = "";
                    txtShiharaibi.Text = "";
                    txtShiharaiJojen.Text = "";
                    txtShukunkbn.Text = "";
                    txtZeiHasuuKubun.Text = "";
                    gridShireJisseki.DataSource = "";
                }

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
            return;
        }

        /// <summary>
        /// setSiireJisseki
        /// データをグリッドビューに追加
        /// </summary>
        private void setSiireJisseki()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();

            lstSearchItem.Add(labelSet_Siiresaki.CodeTxtText);      // 仕入先コード
            lstSearchItem.Add(txtShimekiribi.Text);                 // 締切日
            lstSearchItem.Add(txtZeiHasuuKubun.Text);               // 消費税端数計算区分

            // 仕入先コードが空の場合
            if (labelSet_Siiresaki.CodeTxtText.Equals(""))
            {
                txtShimekiribi.Text = "";
                txtShiharaiGessu.Text = "";
                txtShiharaibi.Text = "";
                txtShiharaiJojen.Text = "";
                txtShukunkbn.Text = "";
                txtZeiHasuuKubun.Text = "";
                gridShireJisseki.DataSource = "";

                return;
            }

            // 締切日、消費税端数計算区分が空の場合
            if (txtShimekiribi.Text.Equals("") || txtZeiHasuuKubun.Text.Equals(""))
            {
                return;
            }

            // ビジネス層のインスタンス生成
            B0060_ShiharaiInput_B siireB = new B0060_ShiharaiInput_B();
            try
            {
                // 検索実行
                DataTable dtSiireJissekiList = siireB.getSiireJissekiList(lstSearchItem);

                // データテーブルからデータグリッドへセット
                gridShireJisseki.DataSource = dtSiireJissekiList;

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
            return;
        }
    }
}
