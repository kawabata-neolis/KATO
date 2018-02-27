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
using KATO.Business.A0470_Hachusuhenko;

namespace KATO.Form.A0470_Hachusuhenko
{
    ///<summary>
    ///A0470_Hachusuhenko
    ///発注数変更フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class A0470_Hachusuhenko : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //更新用発注番号の確保
        string strHachuID;

        ///<summary>
        ///A0100_HachuInput
        ///フォームの初期設定
        ///</summary>
        public A0470_Hachusuhenko(Control c)
        {
            //画面データが解放されていた時の対策
            if (c == null)
            {
                return;
            }

            //画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //最大化最小化不可
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //画面サイズを固定
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;
        }

        ///<summary>
        ///A0470_Hachusuhenko_Load
        ///画面レイアウト設定
        ///</summary>
        private void A0470_Hachusuhenko_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "発注数変更";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF05.Text = "F5:選択";
            this.btnF08.Text = "F8:更新";
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            radSet_3btn_Basho.radbtn2.Checked = true;
            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridHachusuhenko.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn hachubi = new DataGridViewTextBoxColumn();
            hachubi.DataPropertyName = "発注日";
            hachubi.Name = "発注日";
            hachubi.HeaderText = "発注日";

            DataGridViewTextBoxColumn hatsu = new DataGridViewTextBoxColumn();
            hatsu.DataPropertyName = "発";
            hatsu.Name = "発";
            hatsu.HeaderText = "発";

            DataGridViewTextBoxColumn noki = new DataGridViewTextBoxColumn();
            noki.DataPropertyName = "納期";
            noki.Name = "納期";
            noki.HeaderText = "納期";

            DataGridViewTextBoxColumn chuban = new DataGridViewTextBoxColumn();
            chuban.DataPropertyName = "注番";
            chuban.Name = "注番";
            chuban.HeaderText = "注番";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー";
            maker.Name = "メーカー";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn himeikatashiki = new DataGridViewTextBoxColumn();
            himeikatashiki.DataPropertyName = "品名型式";
            himeikatashiki.Name = "品名型式";
            himeikatashiki.HeaderText = "品名・型式";

            DataGridViewTextBoxColumn suryo = new DataGridViewTextBoxColumn();
            suryo.DataPropertyName = "数量";
            suryo.Name = "数量";
            suryo.HeaderText = "数量";

            DataGridViewTextBoxColumn tanka = new DataGridViewTextBoxColumn();
            tanka.DataPropertyName = "単価";
            tanka.Name = "単価";
            tanka.HeaderText = "単価";

            DataGridViewTextBoxColumn kingaku = new DataGridViewTextBoxColumn();
            kingaku.DataPropertyName = "金額";
            kingaku.Name = "金額";
            kingaku.HeaderText = "金額";

            DataGridViewTextBoxColumn shohinCd = new DataGridViewTextBoxColumn();
            shohinCd.DataPropertyName = "商品コード";
            shohinCd.Name = "商品コード";
            shohinCd.HeaderText = "商品コード";

            DataGridViewTextBoxColumn shirezumi = new DataGridViewTextBoxColumn();
            shirezumi.DataPropertyName = "仕入済";
            shirezumi.Name = "仕入済";
            shirezumi.HeaderText = "仕入済";

            DataGridViewTextBoxColumn hachusha = new DataGridViewTextBoxColumn();
            hachusha.DataPropertyName = "発注者";
            hachusha.Name = "発注者";
            hachusha.HeaderText = "発注者";
            
            DataGridViewTextBoxColumn hikiatesaki = new DataGridViewTextBoxColumn();
            hikiatesaki.DataPropertyName = "引当先名";
            hikiatesaki.Name = "引当先名";
            hikiatesaki.HeaderText = "引当先名";

            DataGridViewTextBoxColumn shiresaki = new DataGridViewTextBoxColumn();
            shiresaki.DataPropertyName = "仕入先";
            shiresaki.Name = "仕入先";
            shiresaki.HeaderText = "仕入先";

            DataGridViewTextBoxColumn chubangamen = new DataGridViewTextBoxColumn();
            chubangamen.DataPropertyName = "注番（画面）";
            chubangamen.Name = "注番（画面）";
            chubangamen.HeaderText = "注番（画面）";

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Ｃ１";
            c1.Name = "Ｃ１";
            c1.HeaderText = "Ｃ１";

            DataGridViewTextBoxColumn juchuban = new DataGridViewTextBoxColumn();
            juchuban.DataPropertyName = "受注番号";
            juchuban.Name = "受注番号";
            juchuban.HeaderText = "受注番号";

            //個々の幅、文章の寄せ
            setColumn(hachubi, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumn(hatsu, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(noki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumn(chuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(himeikatashiki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumn(suryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 70);
            setColumn(tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 100);
            setColumn(kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 100);
            setColumn(shohinCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(shirezumi, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0", 80);
            setColumn(hachusha, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(hikiatesaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(shiresaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(chubangamen, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 130);
            setColumn(c1, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(juchuban, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 100);

            //「発」「商品コード」「Ｃ１」のカラムを非表示
            gridHachusuhenko.Columns[1].Visible = false;
            gridHachusuhenko.Columns[9].Visible = false;
            gridHachusuhenko.Columns[15].Visible = false;
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            //column設定
            gridHachusuhenko.Columns.Add(col);
            if (gridHachusuhenko.Columns[col.Name] != null)
            {
                gridHachusuhenko.Columns[col.Name].Width = intLen;
                gridHachusuhenko.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridHachusuhenko.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridHachusuhenko.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///A0470_Hachusuhenko_KeyDown
        ///キー入力判定(画面全般）
        ///</summary>
        private void A0470_Hachusuhenko_KeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setHachusuhenko();
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
                    logger.Info(LogUtil.getMessage(this._Title, "選択実行"));
                    //this.delText();
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    logger.Info(LogUtil.getMessage(this._Title, "更新実行"));
                    this.updKoshin();
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

        ///<summary>
        ///judTxtHachuKeyDown
        ///キー入力判定(テキストボックス)
        ///</summary>
        private void judTxtHachuKeyDown(object sender, KeyEventArgs e)
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

        ///<summary>
        ///setHachusuhenko
        ///該当データの表示
        ///</summary>
        private void setHachusuhenko()
        {
            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //受注者コードと仕入先コードがない場合
            if (StringUtl.blIsEmpty(labelSet_Tantousha.CodeTxtText) == false && 
                StringUtl.blIsEmpty(labelSet_Torihikisaki.CodeTxtText) == false)
            {
                //メッセージボックスの処理、受注者コードと仕入先コードが空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "発注者か仕入先を指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tantousha.Focus();
                return;
            }

            //発注者チェック
            if (labelSet_Tantousha.chkTxtTantosha())
            {
                labelSet_Tantousha.Focus();

                return;
            }

            //仕入先チェック
            if (labelSet_Torihikisaki.chkTxtTorihikisaki())
            {
                labelSet_Torihikisaki.Focus();

                return;
            }

            //検索開始年月日に記入がある場合
            if (baseCalendarOpen.blIsEmpty())
            {
                //日付フォーマット生成、およびチェック
                strYMDformat = baseCalendarOpen.chkDateDataFormat(baseCalendarOpen.Text);

                //検索開始年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    baseCalendarOpen.Focus();

                    return;
                }
                else
                {
                    baseCalendarOpen.Text = strYMDformat;
                }
            }

            //検索終了年月日に記入がある場合
            if (baseCalendarClose.blIsEmpty())
            {
                //初期化
                strYMDformat = "";

                //日付フォーマット生成、およびチェック
                strYMDformat = baseCalendarClose.chkDateDataFormat(baseCalendarClose.Text);

                //検索終了年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    baseCalendarClose.Focus();

                    return;
                }
                else
                {
                    baseCalendarClose.Text = strYMDformat;
                }
            }
            
            //発注数の数値チェック
            if (txtHachusu.chkMoneyText())
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された数値が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtHachusu.Focus();

                return;
            }
            
            //グリッド表示のデータ渡し用
            List<string> lstStrSQL = new List<string>();

            //ビジネス層のインスタンス生成
            A0470_Hachusuhenko_B hachusuhenkoB = new A0470_Hachusuhenko_B();
            try
            {
                //発注者コード
                lstStrSQL.Add(labelSet_Tantousha.CodeTxtText);
                //仕入先コード
                lstStrSQL.Add(labelSet_Torihikisaki.CodeTxtText);
                //検索納期範囲（開始）
                lstStrSQL.Add(baseCalendarOpen.Text);
                //検索納期範囲（終了）
                lstStrSQL.Add(baseCalendarClose.Text);

                //場所ボタンセットの「すべて」にチェックがある場合
                if (radSet_3btn_Basho.radbtn0.Checked)
                {
                    lstStrSQL.Add("0");
                }
                //本社
                else if (radSet_3btn_Basho.radbtn1.Checked)
                {
                    lstStrSQL.Add("1");
                }
                //岐阜
                else
                {
                    lstStrSQL.Add("2");
                }

                //発注残ボタンセットの「発注残をすべて」にチェックがある場合
                if (radHachuZan0.Checked == true)
                {
                    lstStrSQL.Add("0");

                }
                //発注残で仕入済数あり
                else
                {
                    lstStrSQL.Add("1");
                }

                //品名・型番
                lstStrSQL.Add(txtHinmei_Kataban.Text);
                //注番
                lstStrSQL.Add(txtChuban.Text);

                gridHachusuhenko.DataSource = hachusuhenkoB.setHachusuhenkoGrid(lstStrSQL);


                int intCnt;
                int intCntB;

                int intKin = 0;

                for (intCnt= 0; intCnt < gridHachusuhenko.RowCount; intCnt++)
                {
                    intKin = intKin + Convert.ToInt32(gridHachusuhenko.Rows[intCnt].Cells[8].Value);

                    if (Convert.ToInt32(gridHachusuhenko.Rows[intCnt].Cells[6].Value) < 0)
                    {
                        for (intCntB = 0; intCntB < gridHachusuhenko.RowCount; intCntB++)
                        {
                            gridHachusuhenko.Columns[intCntB].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
                txtHachukin.Text = string.Format("{0:#,#}", intKin);

                //グリッドビューに一行以上ある場合
                if (gridHachusuhenko.RowCount >  0)
                {
                    gridHachusuhenko.Focus();
                }
                else
                {
                    labelSet_Torihikisaki.Focus();
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///radioButton_CheckedChanged
        ///受注残選択肢をチェックした場合
        ///</summary>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            setHachusuhenko();
        }

        ///<summary>
        ///gridHachusuhenko_CellDoubleClick
        ///データグリッドビュー上でダブルクリックした場合
        ///</summary>
        private void gridHachusuhenko_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setDataSelect();
        }

        ///<summary>
        ///gridHachusuhenko_KeyDown
        ///データグリッドビュー上でキーを押した場合
        ///</summary>
        private void gridHachusuhenko_KeyDown(object sender, KeyEventArgs e)
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
                    setDataSelect();
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
                    setDataSelect();
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

        ///<summary>
        ///setDataSelect
        ///データグリッドビューで選んだデータを表示
        ///</summary>
        private void setDataSelect()
        {
            //グリッドビューに一行以上ない場合
            if (gridHachusuhenko.RowCount < 1)
            {
                return;
            }

            //選択行の品名・型番取得
            txtHinmei_Katashiki.Text = (string)gridHachusuhenko.CurrentRow.Cells["品名型式"].Value;
            txtHachusu.Text = string.Format("{0:#,#}", gridHachusuhenko.CurrentRow.Cells["数量"].Value);
            txtShiresu.Text = string.Format("{0:#,#}", gridHachusuhenko.CurrentRow.Cells["仕入済"].Value);
            txtTanka.Text = string.Format("{0:#,#}", gridHachusuhenko.CurrentRow.Cells["単価"].Value);

            strHachuID = (string)gridHachusuhenko.CurrentRow.Cells["発"].Value.ToString();

            //空だった場合0に置き換える
            if (txtShiresu.Text == "")
            {
                txtShiresu.Text = "0";
            }

            txtHachusu.Focus();
        }

        ///<summary>
        ///delText
        ///テキストボックスとグリッドビューの内容を削除
        ///</summary>
        private void delText()
        {
            delFormClear(this, gridHachusuhenko);

            labelSet_Tantousha.Focus();
        }

        ///<summary>
        ///judBtnClick
        ///ボタンの反応
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 表示
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.setHachusuhenko();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F05: // 選択
                    logger.Info(LogUtil.getMessage(this._Title, "選択実行"));
                    setDataSelect();
                    break;
                case STR_BTN_F08: // 更新
                    logger.Info(LogUtil.getMessage(this._Title, "更新実行"));
                    updKoshin();
                    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///updKoshin
        ///データの更新
        ///</summary>
        private void updKoshin()
        {
            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //発注者チェック
            if (labelSet_Tantousha.chkTxtTantosha())
            {
                labelSet_Tantousha.Focus();

                return;
            }

            //仕入先チェック
            if (labelSet_Torihikisaki.chkTxtTorihikisaki())
            {
                labelSet_Torihikisaki.Focus();

                return;
            }

            //検索開始年月日に記入がある場合
            if (baseCalendarOpen.blIsEmpty())
            {
                //日付フォーマット生成、およびチェック
                strYMDformat = baseCalendarOpen.chkDateDataFormat(baseCalendarOpen.Text);

                //検索開始年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    baseCalendarOpen.Focus();

                    return;
                }
                else
                {
                    baseCalendarOpen.Text = strYMDformat;
                }
            }

            //検索終了年月日に記入がある場合
            if (baseCalendarClose.blIsEmpty())
            {
                //初期化
                strYMDformat = "";

                //日付フォーマット生成、およびチェック
                strYMDformat = baseCalendarClose.chkDateDataFormat(baseCalendarClose.Text);

                //検索終了年月日の日付チェック
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    baseCalendarClose.Focus();

                    return;
                }
                else
                {
                    baseCalendarClose.Text = strYMDformat;
                }
            }

            //発注数の数値チェック
            if (txtHachusu.chkMoneyText())
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された数値が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtHachusu.Focus();

                return;
            }

            //発注数が仕入数以下の場合
            if (int.Parse(txtHachusu.Text) < int.Parse(txtShiresu.Text))
            {
                //発注数が仕入数以下の場合のメッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "発注数は仕入数以上を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

            //ビジネス層のインスタンス生成
            A0470_Hachusuhenko_B hachusuhenkoB = new A0470_Hachusuhenko_B();
            try
            {
                hachusuhenkoB.updKoushin(txtHachusu.Text, strHachuID);

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //下部のみ取消動作
                txtHinmei_Katashiki.Clear();
                txtHachusu.Clear();
                txtShiresu.Clear();
                txtTanka.Clear();

                //グリッド表示
                setHachusuhenko();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }
    }
}