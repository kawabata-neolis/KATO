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
using KATO.Business.M1220_SyohinBunruiRiekiritsu;

namespace KATO.Form.M1220_SyohinBunruiRiekiritsu
{
    /// <summary>
    /// M1220_SyohinBunruiRiekiritsu
    /// 商品分類別利益率設定フォーム
    /// 作成者：多田
    /// 作成日：2017/6/27
    /// 更新者：多田
    /// 更新日：2017/6/27
    /// カラム論理名
    /// </summary>
    public partial class M1220_SyohinBunruiRiekiritsu : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // グリッドビューで選択した行
        private int currentRow;

        /// <summary>
        /// M1220_SyohinBunruiRiekiritsu
        /// フォーム関係の設定
        /// </summary>
        public M1220_SyohinBunruiRiekiritsu(Control c)
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

            // 中分類setデータを読めるようにする
            labelSet_DaibunruiS.Lschubundata = labelSet_ChubunruiS;
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            // メーカーsetデータを読めるようにする
            labelSet_DaibunruiS.Lsmakerdata = labelSet_MakerS;
            labelSet_Daibunrui.Lsmakerdata = labelSet_Maker;
        }

        /// <summary>
        /// M1220_SyohinBunruiRiekiritsu_Load
        /// 読み込み時
        /// </summary>
        private void M1220_SyohinBunruiRiekiritsu_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品分類別利益率設定";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF06.Text = "F6:売上実績";
            this.btnF12.Text = STR_FUNC_F12;

            // 初期表示
            labelSet_TokuisakiS.Focus();

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
            gridRiekiritsu.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn tokuisakiCd = new DataGridViewTextBoxColumn();
            tokuisakiCd.DataPropertyName = "得意先コード";
            tokuisakiCd.Name = "得意先コード";
            tokuisakiCd.HeaderText = "コード";

            DataGridViewTextBoxColumn tokuisakiName = new DataGridViewTextBoxColumn();
            tokuisakiName.DataPropertyName = "得意先名";
            tokuisakiName.Name = "得意先名";
            tokuisakiName.HeaderText = "得意先名";

            DataGridViewTextBoxColumn daibunruiName = new DataGridViewTextBoxColumn();
            daibunruiName.DataPropertyName = "大分類";
            daibunruiName.Name = "大分類";
            daibunruiName.HeaderText = "大分類";

            DataGridViewTextBoxColumn chubunruiName = new DataGridViewTextBoxColumn();
            chubunruiName.DataPropertyName = "中分類";
            chubunruiName.Name = "中分類";
            chubunruiName.HeaderText = "中分類";

            DataGridViewTextBoxColumn makerName = new DataGridViewTextBoxColumn();
            makerName.DataPropertyName = "メーカー";
            makerName.Name = "メーカー";
            makerName.HeaderText = "メーカー";

            DataGridViewTextBoxColumn riekiritsu = new DataGridViewTextBoxColumn();
            riekiritsu.DataPropertyName = "利益率";
            riekiritsu.Name = "利益率";
            riekiritsu.HeaderText = "利益率";

            DataGridViewTextBoxColumn kakeritsu = new DataGridViewTextBoxColumn();
            kakeritsu.DataPropertyName = "掛率";
            kakeritsu.Name = "掛率";
            kakeritsu.HeaderText = "掛率";

            DataGridViewTextBoxColumn setting = new DataGridViewTextBoxColumn();
            setting.DataPropertyName = "設定";
            setting.Name = "設定";
            setting.HeaderText = "設定:1/解除:0";

            DataGridViewTextBoxColumn daibunruiCd = new DataGridViewTextBoxColumn();
            daibunruiCd.DataPropertyName = "大分類コード";
            daibunruiCd.Name = "大分類コード";
            daibunruiCd.HeaderText = "大分類コード";

            DataGridViewTextBoxColumn chubunruiCd = new DataGridViewTextBoxColumn();
            chubunruiCd.DataPropertyName = "中分類コード";
            chubunruiCd.Name = "中分類コード";
            chubunruiCd.HeaderText = "中分類コード";

            DataGridViewTextBoxColumn makerCd = new DataGridViewTextBoxColumn();
            makerCd.DataPropertyName = "メーカーコード";
            makerCd.Name = "メーカーコード";
            makerCd.HeaderText = "メーカーコード";

            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.DataPropertyName = "ID";
            id.Name = "ID";
            id.HeaderText = "ID";

            // 個々の幅、文字の寄せ
            setColumn(tokuisakiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumn(tokuisakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 330);
            setColumn(daibunruiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(chubunruiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(makerName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(riekiritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 80);
            setColumn(kakeritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 80);
            setColumn(setting, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#", 140);
            setColumn(daibunruiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#", 130);
            setColumn(chubunruiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#", 130);
            setColumn(makerCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#", 145);
            setColumn(id, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#", 100);
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridRiekiritsu.Columns.Add(col);
            if (gridRiekiritsu.Columns[col.Name] != null)
            {
                gridRiekiritsu.Columns[col.Name].Width = intLen;
                gridRiekiritsu.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridRiekiritsu.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridRiekiritsu.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// M1220_SyohinBunruiRiekiritsu_KeyDown
        /// キー入力判定
        /// </summary>
        private void M1220_SyohinBunruiRiekiritsu_KeyDown(object sender, KeyEventArgs e)
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
                    this.addRiekiritsu();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delRiekiritsu();
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delAllText();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    logger.Info(LogUtil.getMessage(this._Title, "売上実績確認実行"));
                    this.showUriageJisseki();
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
                    this.addRiekiritsu();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delRiekiritsu();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delAllText();
                    break;
                case STR_BTN_F06: // 売上実績確認
                    logger.Info(LogUtil.getMessage(this._Title, "売上実績確認実行"));
                    this.showUriageJisseki();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///txtBox_KeyDown
        ///キー入力判定（無機能テキストボックス_BaseText）
        ///</summary>
        private void txtBox_KeyDown(object sender, KeyEventArgs e)
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
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// delText
        /// すべてのテキストボックス内の文字を削除
        /// </summary>
        private void delAllText()
        {
            // 画面の項目内を白紙にする
            delFormClear(this, gridRiekiritsu);

            labelSet_TokuisakiS.Focus();
        }

        /// <summary>
        /// delText
        /// 検索用テキストボックス以外のテキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // 削除するデータ以外を確保
            string strTokuisaki = labelSet_TokuisakiS.CodeTxtText;
            string strTantousha = labelSet_TantoushaS.CodeTxtText;
            string strDaibunrui = labelSet_DaibunruiS.CodeTxtText;
            string strChubunrui = labelSet_ChubunruiS.CodeTxtText;
            string strMaker = labelSet_MakerS.CodeTxtText;

            // 画面の項目内を白紙にする
            delFormClear(this, gridRiekiritsu);

            labelSet_TokuisakiS.CodeTxtText = strTokuisaki;
            labelSet_TantoushaS.CodeTxtText = strTantousha;
            labelSet_DaibunruiS.CodeTxtText = strDaibunrui;
            labelSet_ChubunruiS.CodeTxtText = strChubunrui;
            labelSet_MakerS.CodeTxtText = strMaker;
        }


        /// <summary>
        /// addRiekiritsu
        /// マスタデータを追加
        /// </summary>
        private void addRiekiritsu()
        {
            // データ更新用
            List<string> lstItem = new List<string>();

            // 入力チェック
            if(dataCheack() == false)
            {
                return;
            }

            // ビジネス層のインスタンス生成
            M1220_SyohinBunruiRiekiritsu_B riekiritsuB = new M1220_SyohinBunruiRiekiritsu_B();
            try
            {
                // 追加するデータをリストに格納
                lstItem.Add(txtId.Text);
                lstItem.Add(labelSet_Tokuisaki.CodeTxtText);
                lstItem.Add(labelSet_Daibunrui.CodeTxtText);
                lstItem.Add(labelSet_Chubunrui.CodeTxtText);
                lstItem.Add(labelSet_Maker.CodeTxtText);
                lstItem.Add(txtRitsu.Text);
                lstItem.Add(txtKakeritsu.Text);
                if (radSetting.judCheckBtn().Equals(0))
                {
                    lstItem.Add("1");
                }
                else
                {
                    lstItem.Add("0");
                }
                lstItem.Add(Environment.UserName);

                // 更新実行
                riekiritsuB.addRiekiritsu(lstItem);

                // メッセージボックスの処理、追加成功の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                // テキストボックス内の文字を削除
                delText();

                // データグリッドビューにデータを表示
                setRiekiritsu();

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
            // 空文字判定（得意先）
            if (labelSet_Tokuisaki.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tokuisaki.Focus();
                return false;
            }
            // 文字チェック（得意先）
            if (labelSet_Tokuisaki.chkTxtTorihikisaki())
            {
                return false;
            }

            // 空文字判定（大分類）
            if (labelSet_Daibunrui.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "大分類を指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }
            // 文字チェック（大分類）
            if (labelSet_Daibunrui.chkTxtDaibunrui())
            {
                return false;
            }

            // 空文字判定（中分類、メーカー）
            if (labelSet_Chubunrui.CodeTxtText.Equals("") && labelSet_Maker.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "中分類またはメーカーを指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }

            // 文字チェック（中分類）
            if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
            {
                return false;
            }

            // 文字チェック（メーカー）
            if (labelSet_Maker.chkTxtMaker())
            {
                return false;
            }

            // 空文字判定（利益率、掛率）
            if (txtRitsu.Text.Equals("") && txtKakeritsu.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "利益率、掛率はいずれかを指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }

            // 両方入力されていた場合の判定（利益率、掛率）
            if (!txtRitsu.Text.Equals("") && !txtKakeritsu.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "利益率、掛率の両方は指定できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }

            // IDがない場合
            if (txtId.Text.Equals(""))
            {
                List<string> lstItem = new List<string>();
                lstItem.Add(labelSet_Tokuisaki.CodeTxtText);
                lstItem.Add(labelSet_Daibunrui.CodeTxtText);
                lstItem.Add(labelSet_Chubunrui.CodeTxtText);
                lstItem.Add(labelSet_Maker.CodeTxtText);

                // ビジネス層のインスタンス生成
                M1220_SyohinBunruiRiekiritsu_B riekiritsuB = new M1220_SyohinBunruiRiekiritsu_B();
                try
                {
                    // 登録するデータがすでにデータベースに登録されているか確認する処理
                    DataTable dtRiekiritsu = riekiritsuB.getDataCount(lstItem);

                    if (dtRiekiritsu.Rows.Count > 0 && int.Parse(dtRiekiritsu.Rows[0]["件数"].ToString()) > 0)
                    {
                        // メッセージボックスの処理、すでに登録されている場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "すでに登録されています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return false;
                    }
                }
                catch
                {
                    throw;
                }

            }
            return true;
        }

        /// <summary>
        /// delRiekiritsu
        /// マスタデータ削除処理
        /// </summary>
        private void delRiekiritsu()
        {
            // 文字チェック（得意先）
            if (labelSet_Tokuisaki.chkTxtTorihikisaki())
            {
                return;
            }

            // 文字チェック（大分類）
            if (labelSet_Daibunrui.chkTxtDaibunrui())
            {
                return;
            }

            // 文字チェック（中分類）
            if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
            {
                return;
            }

            // 文字チェック（メーカー）
            if (labelSet_Maker.chkTxtMaker())
            {
                return;
            }

            M1220_SyohinBunruiRiekiritsu_B riekiritsuB = new M1220_SyohinBunruiRiekiritsu_B();
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

                lstDeleteItem.Add(txtId.Text);
                lstDeleteItem.Add(Environment.UserName);

                // 表示中のマスタデータの削除処理
                riekiritsuB.delRiekiritsu(lstDeleteItem);

                // メッセージボックスの処理、削除成功の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                // テキストボックス内の文字を削除
                delText();

                // データグリッドビューにデータを表示
                setRiekiritsu();

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
        /// showUriageJisseki
        /// 売上実績確認フォームを開く
        /// </summary>
        private void showUriageJisseki()
        {
            // グリッドビューに表示されていない場合
            if (gridRiekiritsu.RowCount <= 0)
            {
                return;
            }

            // 画面ID（1つ目の引数）
            int intFrm = 3;
            // 得意先コード（2つ目の引数）
            string strTokuisaki = gridRiekiritsu.Rows[currentRow].Cells[0].Value.ToString();
            // 大分類名（3つ目の引数）
            string strDaibunrui = gridRiekiritsu.Rows[currentRow].Cells[2].Value.ToString().Trim();

            // 売上実績確認フォームを開く
            D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin uriage =
                new D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, intFrm, strTokuisaki, strDaibunrui);
            uriage.ShowDialog();
        }

        /// <summary>
        /// setRiekiritsu
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setRiekiritsu()
        {
            // データ検索用
            List<string> lstSearchItem = new List<string>();
            List<string> lstSerachOrder = new List<string>();

            // ビジネス層のインスタンス生成
            M1220_SyohinBunruiRiekiritsu_B riekiritsuB = new M1220_SyohinBunruiRiekiritsu_B();
            try
            {
                // 検索するデータをリストに格納
                lstSearchItem.Add(labelSet_TokuisakiS.CodeTxtText);
                lstSearchItem.Add(labelSet_TantoushaS.CodeTxtText);
                lstSearchItem.Add(labelSet_DaibunruiS.CodeTxtText);
                lstSearchItem.Add(labelSet_ChubunruiS.CodeTxtText);
                lstSearchItem.Add(labelSet_MakerS.CodeTxtText);

                // 検索実行
                DataTable dtRiekiritsuBList = riekiritsuB.getRiekiritsuList(lstSearchItem, lstSerachOrder);

                // データテーブルからデータグリッドへセット
                gridRiekiritsu.DataSource = dtRiekiritsuBList;

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
        /// btnSerach_Click
        /// 検索ボタンのクリック
        /// </summary>
        private void btnSerach_Click(object sender, EventArgs e)
        {
            // 検索を実行
            setRiekiritsu();
        }

        /// <summary>
        /// gridRiekiritsu_CellMouseDoubleClick
        /// グリッドビューのセルがクリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridRiekiritsu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // 選択している行を取得
            currentRow = e.RowIndex;
        }

        /// <summary>
        /// gridRiekiritsu_CellMouseDoubleClick
        /// グリッドビューのセルがダブルクリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridRiekiritsu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gridRiekiritsu.RowCount == 0)
            {
                return;
            }

            // グリッドビューのデータをテキストボックスに配置
            // 得意先
            labelSet_Tokuisaki.CodeTxtText = gridRiekiritsu.CurrentRow.Cells[0].Value.ToString();
            // 大分類
            labelSet_Daibunrui.CodeTxtText = gridRiekiritsu.CurrentRow.Cells[8].Value.ToString();
            // 中分類
            labelSet_Chubunrui.CodeTxtText = gridRiekiritsu.CurrentRow.Cells[9].Value.ToString();
            // メーカー
            labelSet_Maker.CodeTxtText = gridRiekiritsu.CurrentRow.Cells[10].Value.ToString();

            // 利益率
            if (!gridRiekiritsu.CurrentRow.Cells[5].Value.ToString().Equals(""))
            {
                txtRitsu.Text = decimal.Parse(gridRiekiritsu.CurrentRow.Cells[5].Value.ToString()).ToString("#");
            }
            else
            {
                txtRitsu.Text = "";
            }

            // 掛率
            if (!gridRiekiritsu.CurrentRow.Cells[6].Value.ToString().Equals(""))
            {
                txtKakeritsu.Text = decimal.Parse(gridRiekiritsu.CurrentRow.Cells[6].Value.ToString()).ToString("#");
            }
            else
            {
                txtKakeritsu.Text = "";
            }

            // ID
            txtId.Text = gridRiekiritsu.CurrentRow.Cells[11].Value.ToString();

            // 設定
            if (gridRiekiritsu.CurrentRow.Cells[7].Value.ToString().Trim().Equals("0"))
            {
                radSetting.radbtn1.Checked = true;
            }
            else
            {
                radSetting.radbtn0.Checked = true;
            }

            // 文字チェック（得意先）
            if(labelSet_Tokuisaki.chkTxtTorihikisaki())
            {
                return;
            }
            // 文字チェック（大分類）
            if (labelSet_Daibunrui.chkTxtDaibunrui())
            {
                return;
            }
            // 文字チェック（中分類）
            if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
            {
                return;
            }
            // 文字チェック（メーカー）
            if (labelSet_Maker.chkTxtMaker())
            {
                return;
            }

            return;
        }

    }

}
