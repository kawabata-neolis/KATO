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
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.G0920_HidukeSeigen;

namespace KATO.Form.G0920_HidukeSeigen
{
    /// <summary>
    /// G0920_HidukeSeigen
    /// 日付制限フォーム
    /// 作成者：多田
    /// 作成日：2017/6/29
    /// 更新者：大河内
    /// 更新日：2017/11/15
    /// カラム論理名
    /// </summary>
    public partial class G0920_HidukeSeigen : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // グリッドビューで選択した行
        private int currentRow;

        //エラーメッセージを表示したかどうか
        bool blMessageOn = false;
        
        /// <summary>
        /// G0920_HidukeSeigen
        /// フォーム関係の設定
        /// </summary>
        public G0920_HidukeSeigen(Control c)
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
        /// G0920_HidukeSeigen_Load
        /// 読み込み時
        /// </summary>
        private void G0920_HidukeSeigen_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "日付制限";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF05.Text = "F5:選択";
            this.btnF12.Text = STR_FUNC_F12;

            // 初期表示
            txtGamenNo.Focus();

            // DataGridViewの初期設定
            SetUpGrid();

            // 日付制限データをグリッドビューに表示
            setHidukeSeigen();
        }

        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            // 列自動生成禁止
            gridHidukeSeigen.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn gamenNo = new DataGridViewTextBoxColumn();
            gamenNo.DataPropertyName = "画面ＮＯ";
            gamenNo.Name = "画面ＮＯ";
            gamenNo.HeaderText = "画面№";

            DataGridViewTextBoxColumn gamenName = new DataGridViewTextBoxColumn();
            gamenName.DataPropertyName = "ＰＧ名";
            gamenName.Name = "ＰＧ名";
            gamenName.HeaderText = "画面名";

            DataGridViewTextBoxColumn eigyoshoCd = new DataGridViewTextBoxColumn();
            eigyoshoCd.DataPropertyName = "営業所コード";
            eigyoshoCd.Name = "営業所コード";
            eigyoshoCd.HeaderText = "営業所コード";

            DataGridViewTextBoxColumn eigyoshoName = new DataGridViewTextBoxColumn();
            eigyoshoName.DataPropertyName = "営業所名";
            eigyoshoName.Name = "営業所名";
            eigyoshoName.HeaderText = "営業所名";

            DataGridViewTextBoxColumn minYmd = new DataGridViewTextBoxColumn();
            minYmd.DataPropertyName = "最小年月日";
            minYmd.Name = "最小年月日";
            minYmd.HeaderText = "最小年月日";

            DataGridViewTextBoxColumn maxYmd = new DataGridViewTextBoxColumn();
            maxYmd.DataPropertyName = "最大年月日";
            maxYmd.Name = "最大年月日";
            maxYmd.HeaderText = "最大年月日";

            // 個々の幅、文字の寄せ
            setColumn(gamenNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(gamenName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumn(eigyoshoCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#", 140);
            setColumn(eigyoshoName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 140);
            setColumn(minYmd, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 140);
            setColumn(maxYmd, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 140);
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridHidukeSeigen.Columns.Add(col);
            if (gridHidukeSeigen.Columns[col.Name] != null)
            {
                gridHidukeSeigen.Columns[col.Name].Width = intLen;
                gridHidukeSeigen.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridHidukeSeigen.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridHidukeSeigen.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// G0920_HidukeSeigen_KeyDown
        /// キー入力判定
        /// </summary>
        private void G0920_HidukeSeigen_KeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addHidukeSeigen();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delHidukeSeigen();
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case Keys.F5:
                    logger.Info(LogUtil.getMessage(this._Title, "選択実行"));
                    this.setText();
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
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addHidukeSeigen();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delHidukeSeigen();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F05: // 選択
                    logger.Info(LogUtil.getMessage(this._Title, "選択実行"));
                    this.setText();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// setText
        /// 選択した行のデータをテキストボックスへ配置
        /// </summary>
        private void setText()
        {
            // グリッドビューに表示されていない場合
            if (gridHidukeSeigen.RowCount == 0)
            {
                return;
            }

            // グリッドビューのデータをテキストボックスに配置
            txtGamenNo.Text = gridHidukeSeigen.Rows[currentRow].Cells[0].Value.ToString();
            labelSet_Eigyosho.CodeTxtText = gridHidukeSeigen.Rows[currentRow].Cells[2].Value.ToString();
            txtCalendarMinYMD.Text = gridHidukeSeigen.Rows[currentRow].Cells[4].Value.ToString();
            txtCalendarMaxYMD.Text = gridHidukeSeigen.Rows[currentRow].Cells[5].Value.ToString();

            // 最小年月日にフォーカス
            txtCalendarMinYMD.Focus();

            return;
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // テキストボックス内の文字を削除
            txtGamenNo.Text = "";
            lblGamenName.Text = "";
            labelSet_Eigyosho.CodeTxtText = "";
            labelSet_Eigyosho.ValueLabelText = "";
            txtCalendarMinYMD.Text = "";
            txtCalendarMaxYMD.Text = "";

            // 画面Noへフォーカス
            txtGamenNo.Focus();
        }

        /// <summary>
        /// delAllText
        /// 画面の項目内の文字を削除
        /// </summary>
        private void delAllText()
        {
            // 画面の項目内を白紙にする
            delFormClear(this, gridHidukeSeigen);

            // データグリッドビューにデータを表示
            setHidukeSeigen();

            // 画面Noへフォーカス
            txtGamenNo.Focus();
        }

        /// <summary>
        /// addHidukeSeigen
        /// 日付制限データを追加
        /// </summary>
        private void addHidukeSeigen()
        {
            // データ追加用
            List<string> lstItem = new List<string>();

            // データチェック処理
            if (!dataCheack())
            {
                return;
            }

            // ビジネス層のインスタンス生成
            G0920_HidukeSeigen_B hidukeB = new G0920_HidukeSeigen_B();
            try
            {
                // 追加するデータをリストに格納
                lstItem.Add(txtGamenNo.Text);
                lstItem.Add(labelSet_Eigyosho.CodeTxtText);
                lstItem.Add(txtCalendarMinYMD.Text);
                lstItem.Add(txtCalendarMaxYMD.Text);
                lstItem.Add(Environment.UserName);

                // 追加実行
                hidukeB.addHidukeSeigen(lstItem);

                // メッセージボックスの処理、追加成功の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                // 画面の項目内の文字を削除
                delAllText();

                // データグリッドビューにデータを表示
                setHidukeSeigen();
            }
            catch (Exception ex)
            {
                // メッセージボックスの処理、追加失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                // エラーロギング
                new CommonException(ex);
                return;
            }
            return;
        }

        /// <summary>
        /// dataCheack
        /// データチェック処理
        /// </summary>
        private Boolean dataCheack()
        {
            // 空文字判定（画面№）
            if (txtGamenNo.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtGamenNo.Focus();
                return false;
            }

            // 空文字判定（営業所）
            if (labelSet_Eigyosho.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Eigyosho.Focus();
                return false;
            }

            // 空文字判定（最小年月日）
            if (txtCalendarMinYMD.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtCalendarMinYMD.Focus();
                return false;
            }

            // 空文字判定（最大年月日）
            if (txtCalendarMaxYMD.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtCalendarMaxYMD.Focus();
                return false;
            }

            DateTime dtMinDate = DateTime.Parse(txtCalendarMinYMD.Text);
            DateTime dtMaxDate = DateTime.Parse(txtCalendarMaxYMD.Text);

            // 最小年月日が最大年月日より大きい場合
            if (dtMinDate > dtMaxDate)
            {
                // メッセージボックスの処理、日付が範囲外の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "開始日と終了日の指定が不正です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }

            return true;
        }

        /// <summary>
        /// delHidukeSeigen
        /// 日付制限データを削除
        /// </summary>
        private void delHidukeSeigen()
        {
            G0920_HidukeSeigen_B hidukeB = new G0920_HidukeSeigen_B();
            try
            {
                List<string> lstDeleteItem = new List<string>();

                // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "表示中のレコードを削除します。よろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                // NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                // 削除対象となる値が入力されていない場合は処理をしない
                if (txtGamenNo.Text.Equals("") || labelSet_Eigyosho.CodeTxtText.Equals(""))
                {
                    return;
                }

                lstDeleteItem.Add(txtGamenNo.Text);
                lstDeleteItem.Add(labelSet_Eigyosho.CodeTxtText);
                lstDeleteItem.Add(Environment.UserName);

                // 表示中の日付制限データの削除処理
                hidukeB.delHidukeSeigen(lstDeleteItem);

                // メッセージボックスの処理、削除成功の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                // 画面の項目内の文字を削除
                delAllText();

                // データグリッドビューにデータを表示
                setHidukeSeigen();

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
        /// setRiekiritsu
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setHidukeSeigen()
        {
            // テキストボックスをクリア
            delText();

            // ビジネス層のインスタンス生成
            G0920_HidukeSeigen_B hidukeB = new G0920_HidukeSeigen_B();
            try
            {
                // 検索実行
                DataTable dtRiekiritsuBList = hidukeB.getHidukeSeigenList();

                // データテーブルからデータグリッドへセット
                gridHidukeSeigen.DataSource = dtRiekiritsuBList;

                Control cNow = this.ActiveControl;
                cNow.Focus();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                return;
            }
            return;
        }

        /// <summary>
        /// gridHidukeSeigen_CellMouseDoubleClick
        /// グリッドビューのセルがクリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridHidukeSeigen_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // 選択している行を取得
            currentRow = e.RowIndex;
        }

        /// <summary>
        /// gridHidukeSeigen_CellMouseDoubleClick
        /// グリッドビューのセルがダブルクリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridHidukeSeigen_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // グリッドビューにデータがない場合
            if (gridHidukeSeigen.RowCount == 0)
            {
                return;
            }

            // グリッドビューのデータをテキストボックスに配置
            txtGamenNo.Text = gridHidukeSeigen.CurrentRow.Cells[0].Value.ToString();
            labelSet_Eigyosho.CodeTxtText = gridHidukeSeigen.CurrentRow.Cells[2].Value.ToString();
            txtCalendarMinYMD.Text = gridHidukeSeigen.CurrentRow.Cells[4].Value.ToString();
            txtCalendarMaxYMD.Text = gridHidukeSeigen.CurrentRow.Cells[5].Value.ToString();

            // 最小年月日にフォーカス
            txtCalendarMinYMD.Focus();

            return;
        }

        /// <summary>
        /// judTxtGamenNoKeyDown
        /// コード入力項目でのキー入力判定（画面No）
        /// </summary>
        private void judTxtGamenNoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// updTxtGamenNoLeave
        /// 画面No入力箇所からフォーカスが外れた時
        /// </summary>
        public void updTxtGamenNoLeave(object sender, EventArgs e)
        {
            Boolean blnGood;

            if (txtGamenNo.Text == "" || String.IsNullOrWhiteSpace(txtGamenNo.Text).Equals(true))
            {
                lblGamenName.Text = "";
                return;
            }

            // 禁止文字チェック
            blnGood = StringUtl.JudBanChr(txtGamenNo.Text);
            // 数字のみを許可する
            blnGood = StringUtl.JudBanSelect(txtGamenNo.Text, CommonTeisu.NUMBER_ONLY);

            if (blnGood == false)
            {
                lblGamenName.Text = "";

                // メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

            // 前後の空白を取り除く
            txtGamenNo.Text = txtGamenNo.Text.Trim();

            // ビジネス層のインスタンス生成
            G0920_HidukeSeigen_B hidukeB = new G0920_HidukeSeigen_B();
            try
            {
                // 検索実行
                DataTable dtGamenList = hidukeB.getGamenList(txtGamenNo.Text);

                // データの有無チェック
                if (dtGamenList.Rows.Count != 0)
                {
                    txtGamenNo.Text = dtGamenList.Rows[0]["ＰＧ番号"].ToString();
                    lblGamenName.Text = dtGamenList.Rows[0]["ＰＧ名"].ToString();
                }
                else
                {
                    lblGamenName.Text = "";

                    // メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
                return;
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
        /// txtGamenNoTextChanged
        /// 画面No入力項目に変更があった場合
        /// </summary>
        private void txtGamenNoTextChanged(object sender, EventArgs e)
        {
            //文字数が少ない場合
            if (txtGamenNo.TextLength < 3)
            {
                return;
            }

            if (txtGamenNo.Text == "" || String.IsNullOrWhiteSpace(txtGamenNo.Text).Equals(true))
            {
                lblGamenName.Text = "";
                return;
            }
            
            // ビジネス層のインスタンス生成
            G0920_HidukeSeigen_B hidukeB = new G0920_HidukeSeigen_B();
            try
            {
                // 検索実行
                DataTable dtGamenList = hidukeB.getGamenList(txtGamenNo.Text);

                // データの有無チェック
                if (dtGamenList.Rows.Count != 0)
                {
                    txtGamenNo.Text = dtGamenList.Rows[0]["ＰＧ番号"].ToString();
                    lblGamenName.Text = dtGamenList.Rows[0]["ＰＧ名"].ToString();
                }
                else
                {
                    lblGamenName.Text = "";

                    // メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
                return;
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

        ///<summary>
        ///judtxtGamenNoKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtGamenNoKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///labelSet_Eigyosho_Leave
        ///フォーカスが外れた場合
        ///</summary>
        private void labelSet_Eigyosho_Leave(object sender, EventArgs e)
        {
            //メッセージ表示がされていた場合
            if (labelSet_Eigyosho.blMessageOn == true)
            {
                blMessageOn = true;

                //初期化
                labelSet_Eigyosho.blMessageOn = false;

                labelSet_Eigyosho.Focus();
            }
        }

        ///judText_KeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judText_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

    }
}
