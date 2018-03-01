using KATO.Business.E0330_TokuisakiMotocyoKakunin;
using KATO.Common.Ctl;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.E0330_TokuisakiMotocyoKakunin
{

    ///<summary>
    ///E0330_TokuisakiMotocyoKakunin
    ///得意先元帳確認
    ///作成者：太田
    ///作成日：2017/07/12
    ///更新者：大河内
    ///更新日：2018/02/02
    ///</summary>
    public partial class E0330_TokuisakiMotocyoKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // 画面ID
        private int intFrm;

        // 得意先コード
        private string strTokuisakiCd;

        /// <summary>
        /// E0330_TokuisakiMotocyoKakunin
        /// フォーム関係の設定
        /// </summary>
        public E0330_TokuisakiMotocyoKakunin(Control c, int intFrm, string strTokuisakiCd)
        {
            if (c == null)
            {
                return;
            }

            // 画面IDをセット
            this.intFrm = intFrm;
            // 得意先コードをセット
            this.strTokuisakiCd = strTokuisakiCd;

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;

            //印刷対象の初期値
            radSet_Insatsu.radbtn1.Checked = true;
        }

        //フォームが最初に開いた場合の処理
        private void E0330_TokuisakiMotocyoKakunin_Shown(object sender, EventArgs e)
        {
            //得意先コードが他画面から連れてきた場合(入金入力と支払入力から専用)
            if (strTokuisakiCd != "")
            {
                labelSet_TokuisakiStart.CodeTxtText = strTokuisakiCd;
                this.setTokuisakimotocho();
                gridTorihiki.Focus();
            }
        }

        private void E0330_TokuisakiMotocyoKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "得意先元帳確認";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1_HYOJII;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            //初期表示

            txtStartYM.Text = DateTime.Now.ToString();
            txtEndYM.Text = DateTime.Now.ToString();
            

            //DataGridViewの初期設定
            SetUpGrid();

            // ステータスバーにメッセージ表示
            this.lblStatusMessage.Text = "F9を押すと、一覧表示または検索ができます";
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {

            //列自動生成禁止
            gridTorihiki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn hiduke = new DataGridViewTextBoxColumn();
            hiduke.DataPropertyName = "伝票年月日";
            hiduke.Name = "伝票年月日";
            hiduke.HeaderText = "日付";

            DataGridViewTextBoxColumn denpyoNo = new DataGridViewTextBoxColumn();
            denpyoNo.DataPropertyName = "伝票番号";
            denpyoNo.Name = "伝票番号";
            denpyoNo.HeaderText = "伝№";

            DataGridViewTextBoxColumn gyoubangou = new DataGridViewTextBoxColumn();
            gyoubangou.DataPropertyName = "行番号";
            gyoubangou.Name = "行番号";
            gyoubangou.HeaderText = "行№";

            DataGridViewTextBoxColumn kubun1 = new DataGridViewTextBoxColumn();
            kubun1.DataPropertyName = "取引区分名";
            kubun1.Name = "取引区分名";
            kubun1.HeaderText = "区分";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー名";
            maker.Name = "メーカー名";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn sinamei_kataban = new DataGridViewTextBoxColumn();
            sinamei_kataban.DataPropertyName = "商品名";
            sinamei_kataban.Name = "商品名";
            sinamei_kataban.HeaderText = "品名・型式";

            DataGridViewTextBoxColumn suuryou = new DataGridViewTextBoxColumn();
            suuryou.DataPropertyName = "数量";
            suuryou.Name = "数量";
            suuryou.HeaderText = "数量";
            
            DataGridViewTextBoxColumn uriagetanka = new DataGridViewTextBoxColumn();
            uriagetanka.DataPropertyName = "売上単価";
            uriagetanka.Name = "売上単価";
            uriagetanka.HeaderText = "売上単価";

            DataGridViewTextBoxColumn uriagekingaku = new DataGridViewTextBoxColumn();
            uriagekingaku.DataPropertyName = "売上金額";
            uriagekingaku.Name = "売上金額";
            uriagekingaku.HeaderText = "売上金額";

            DataGridViewTextBoxColumn nyukinkingaku = new DataGridViewTextBoxColumn();
            nyukinkingaku.DataPropertyName = "入金額";
            nyukinkingaku.Name = "入金額";
            nyukinkingaku.HeaderText = "入金金額";

            DataGridViewTextBoxColumn sasihikizandaka = new DataGridViewTextBoxColumn();
            sasihikizandaka.DataPropertyName = "差引残高";
            sasihikizandaka.Name = "差引残高";
            sasihikizandaka.HeaderText = "差引残高";

            DataGridViewTextBoxColumn kubun2 = new DataGridViewTextBoxColumn();
            kubun2.DataPropertyName = "取引区分";
            kubun2.Name = "取引区分";
            kubun2.HeaderText = "区分";


            //個々の幅、文章の寄せ
            setColumn(hiduke, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 90);
            setColumn(denpyoNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 64);
            setColumn(gyoubangou, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#0",64);
            setColumn(kubun1, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,64);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,149);
            setColumn(sinamei_kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null,400);
            setColumn(suuryou, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",64);
            setColumn(uriagetanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 108);
            setColumn(uriagekingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",108);
            setColumn(nyukinkingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 108);
            setColumn(sasihikizandaka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 108);
            setColumn(kubun2, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null, 65);

            //表示はしない項目
            gridTorihiki.Columns[11].Visible = false;
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridTorihiki.Columns.Add(col);
            if (gridTorihiki.Columns[col.Name] != null)
            {
                gridTorihiki.Columns[col.Name].Width = intLen;
                gridTorihiki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridTorihiki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridTorihiki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// E0330_TokuisakiMotocyoKakunin_KeyDown
        /// キー入力判定
        /// </summary>
        private void E0330_TokuisakiMotocyoKakunin_KeyDown(object sender, KeyEventArgs e)
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
                    this.setTokuisakimotocho();
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
                    this.printTokuisakiMotocyoKakunin();
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
                    this.setTokuisakimotocho();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printTokuisakiMotocyoKakunin();
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

            //画面の項目内を白紙にする
            delFormClear(this, gridTorihiki);

            //初期表示

            txtStartYM.Text = DateTime.Now.ToString();
            txtEndYM.Text = DateTime.Now.ToString();

        }


        /// <summary>
        /// setUriageSuiiHyo
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setTokuisakimotocho()
        {
            //記入項目の空白削除
            labelSet_TokuisakiStart.CodeTxtText.Trim();
            labelSet_TokuisakiEnd.CodeTxtText.Trim();
            txtStartYM.Text.Trim();
            txtEndYM.Text.Trim();
            txtZenZan.Text.Trim();
            txtNyukin.Text.Trim();
            txtUriage.Text.Trim();
            txtZei.Text.Trim();
            txtZandaka.Text.Trim();
            
            //得意先コードの検索開始項目
            if (labelSet_TokuisakiStart.codeTxt.blIsEmpty() == false ||
                StringUtl.blIsEmpty(labelSet_TokuisakiStart.ValueLabelText) == false ||
                labelSet_TokuisakiStart.chkTxtTorihikisaki() == true)
            {
                labelSet_TokuisakiStart.Focus();
                return;
            }

            //得意先コードの終了開始項目
            if (labelSet_TokuisakiEnd.codeTxt.blIsEmpty() == true)
            {
                //得意先コードの範囲指定は出来ないメッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "複数の得意先コードは指定できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_TokuisakiEnd.Focus();
                return;
            }

            //年月日の検索開始項目
            if (txtStartYM.blIsEmpty() == false)
            {
                txtStartYM.Focus();
                return;
            }

            //年月日の検索終了項目
            if (txtEndYM.blIsEmpty() == false)
            {
                txtEndYM.Focus();
                return;
            }

            ////得意先開始チェック
            //if ()
            //{

            //}
            
            //得意先終了チェック


            //検索開始年月

            //検索終了年月


            //データ検索用
            List<string> lstUriageSuiiLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;
            // 得意先情報取得用
            DataTable dtTokuisakiInfo;
            // 消費税区分 
            string kbnZei = "";
            // 消費税計算区分
            string kbnZeiKeisan = "";

            string StartYMD;
            string EndYMD;
            decimal wkin1;
            decimal wkin2;
            decimal wkin3;
            decimal wkin4;
            decimal wkin5;
            decimal wkin6;
            decimal wkin7;
            decimal decZengetsuZandaka;
            decimal decSiireKingaku;
            decimal decShiharaiKingaku;



            StartYMD = txtStartYM.Text + "/01";
            EndYMD = txtEndYM.Text + "/01";
            //入力値の月末を取得
            EndYMD = DateTime.Parse(EndYMD).AddMonths(1).ToString();
            EndYMD = DateTime.Parse(EndYMD).AddDays(-1).ToString("yyyy/MM/dd");

            //データの存在確認を検索する情報を入れる
            /*[0]得意先コード*/
            lstUriageSuiiLoad.Add(labelSet_TokuisakiStart.CodeTxtText);
            /*[1]スタート日付（yyyy/MM/dd）*/
            lstUriageSuiiLoad.Add(StartYMD);
            /*[2]スタート日付（yyyy/MM/dd）*/
            lstUriageSuiiLoad.Add(EndYMD);

            //ビジネス層のインスタンス生成
            E0330_TokuisakiMotocyoKakunin_B tokuisakimotocyokakuninB = new E0330_TokuisakiMotocyoKakunin_B();
            try
            {
                // 得意先情報取得
                dtTokuisakiInfo = tokuisakimotocyokakuninB.getTokuisakiInfo(this.labelSet_TokuisakiStart.CodeTxtText);
                if (dtTokuisakiInfo.Rows.Count > 0)
                {
                    kbnZei = dtTokuisakiInfo.Rows[0]["消費税区分"].ToString();
                    kbnZeiKeisan = dtTokuisakiInfo.Rows[0]["消費税計算区分"].ToString();
                }

                //ビジネス層、前月残高取得ロジックに移動
                dtSetView = tokuisakimotocyokakuninB.getZenzan(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    txtZenZan.Text = decimal.Parse(dtSetView.Rows[0]["前月残高"].ToString()).ToString("");
                }
                else
                {
                    txtZenZan.Text = "0";
                }

                //ビジネス層、売上金額取得ロジックに移動
                dtSetView = tokuisakimotocyokakuninB.getUriage(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    wkin1 = decimal.Parse(dtSetView.Rows[0]["売上金額"].ToString());
                }
                else
                {
                    wkin1 = 0;
                }

                // テキストボックス売上金額に値を入れる
                txtUriage.Text = wkin1.ToString();

                /*[3]売上金額 */
                lstUriageSuiiLoad.Add(txtUriage.Text);

                //ビジネス層、消費税額取得ロジックに移動
                dtSetView = tokuisakimotocyokakuninB.getZei(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    wkin1 = decimal.Parse(dtSetView.Rows[0]["消費税額"].ToString());
                }
                else
                {
                    wkin1 = 0;
                }

                txtZei.Text = wkin1.ToString();


                //ビジネス層、請求消費税取得ロジックに移動
                dtSetView = tokuisakimotocyokakuninB.getSotozei(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    if (kbnZei.Equals("0") && kbnZeiKeisan.Equals("2"))
                    {
                        wkin1 = decimal.Parse(dtSetView.Rows[0]["請求消費税"].ToString());
                    }
                    //内税の場合売上金額から内税を減算
                    if (kbnZei.Equals("1"))
                    {
                        txtUriage.Text = (decimal.Parse(txtUriage.Text) - wkin1).ToString();
                    }
                    
                }
                else
                {
                    wkin1 = 0;
                }

                txtZei.Text = wkin1.ToString();

                //ビジネス層、入金現金取得ロジックに移動
                dtSetView = tokuisakimotocyokakuninB.getNyukinGenkin(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    wkin1 = decimal.Parse(dtSetView.Rows[0]["入金現金"].ToString());
                }
                else
                {
                    wkin1 = 0;
                }

                //ビジネス層、入金小切手取得ロジックに移動
                dtSetView = tokuisakimotocyokakuninB.getNyukinKogitte(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    wkin2 = decimal.Parse(dtSetView.Rows[0]["入金小切手"].ToString());
                }
                else
                {
                    wkin2 = 0;
                }


                //ビジネス層、入金振込取得ロジックに移動
                dtSetView = tokuisakimotocyokakuninB.getNyukinHurikomi(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    wkin3 = decimal.Parse(dtSetView.Rows[0]["入金振込"].ToString());
                }
                else
                {
                    wkin3 = 0;
                }

                //ビジネス層、入金手形取得ロジックに移動
                dtSetView = tokuisakimotocyokakuninB.getNyukinTegata(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    wkin4 = decimal.Parse(dtSetView.Rows[0]["入金手形"].ToString());
                }
                else
                {
                    wkin4 = 0;
                }


                //ビジネス層、入金相殺取得ロジックに移動
                dtSetView = tokuisakimotocyokakuninB.getNyukinSousatu(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    wkin5 = decimal.Parse(dtSetView.Rows[0]["入金相殺"].ToString());
                }
                else
                {
                    wkin5 = 0;
                }

                //ビジネス層、入金手数料取得ロジックに移動
                dtSetView = tokuisakimotocyokakuninB.getNyukinTesuryou(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    wkin6 = decimal.Parse(dtSetView.Rows[0]["入金手数料"].ToString());
                }
                else
                {
                    wkin6 = 0;
                }


                //ビジネス層、入金_その他取得ロジックに移動
                dtSetView = tokuisakimotocyokakuninB.getNyukinSonota(lstUriageSuiiLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    wkin7 = decimal.Parse(dtSetView.Rows[0]["入金その他"].ToString());
                }
                else
                {
                    wkin7 = 0;
                }

                //Wkin1～7の合計を入金金額に設定
                txtNyukin.Text = (wkin1 + wkin2 + wkin3 + wkin4 + wkin5 + wkin6 + wkin7).ToString();
                //当月残高を求める
                txtZandaka.Text = (decimal.Parse(txtZenZan.Text) - decimal.Parse(txtNyukin.Text) + decimal.Parse(txtUriage.Text) + decimal.Parse(txtZei.Text)).ToString();

                //ビジネス層、グリッドビュー表示情報取得に移動
                dtSetView = tokuisakimotocyokakuninB.getTokuisakiMotocyo(lstUriageSuiiLoad);

                gridTorihiki.DataSource = dtSetView;

                if (dtSetView != null && dtSetView.Rows.Count > 0)
                {
                    string strDate = "";
                    string strDenpyoNo = "";
                    for (int cnt = 0; cnt < gridTorihiki.RowCount; cnt++)
                    {
                        // 伝票年月日と伝票番号が同じ場合、伝票年月日と伝票番号を表示しない
                        if (gridTorihiki.Rows[cnt].Cells["伝票年月日"].Value.ToString().Equals(strDate) &&
                            gridTorihiki.Rows[cnt].Cells["伝票番号"].Value.ToString().Equals(strDenpyoNo))
                        {
                            // 仕入の場合、区分を表示しない
                            if (gridTorihiki.Rows[cnt].Cells["取引区分"].Value.ToString().Equals("11"))
                            {
                                gridTorihiki.Rows[cnt].Cells["取引区分名"].Value = DBNull.Value;
                            }

                            gridTorihiki.Rows[cnt].Cells["伝票年月日"].Value = DBNull.Value;
                            gridTorihiki.Rows[cnt].Cells["伝票番号"].Value = DBNull.Value;
                        }
                        else
                        {
                            strDate = gridTorihiki.Rows[cnt].Cells["伝票年月日"].Value.ToString();
                            strDenpyoNo = gridTorihiki.Rows[cnt].Cells["伝票番号"].Value.ToString();
                        }

                        // 入金の場合はフォントカラーを変更
                        int intKubun = int.Parse(gridTorihiki.Rows[cnt].Cells["取引区分"].Value.ToString());
                        if (intKubun >= 31 && intKubun <= 37)
                        {
                            gridTorihiki.Rows[cnt].DefaultCellStyle.ForeColor = Color.Blue;
                        }

                        // 数量又は金額の空白チェック用フラグ
                        bool blnBlankFlg = false;

                        // 数量
                        decimal decSuuryo = 0;
                        if (!decimal.TryParse(gridTorihiki.Rows[cnt].Cells["数量"].Value.ToString(), out decSuuryo))
                        {
                            blnBlankFlg = true;
                        }

                        // 金額
                        decimal decKingaku = 0;
                        if (!decimal.TryParse(gridTorihiki.Rows[cnt].Cells["売上金額"].Value.ToString(), out decKingaku))
                        {
                            blnBlankFlg = true;
                        }

                        // 数量又は金額が空白ではなく、かつ、マイナスの場合はフォントカラーを変更
                        if (!blnBlankFlg && (decSuuryo < 0 || decKingaku < 0))
                        {
                            gridTorihiki.Rows[cnt].DefaultCellStyle.ForeColor = Color.Red;
                        }

                        // 1行目の場合
                        if (cnt == 0)
                        {
                            decZengetsuZandaka = decimal.Parse(txtZenZan.Text);
                        }
                        else
                        {
                            decZengetsuZandaka = decimal.Parse(gridTorihiki.Rows[cnt - 1].Cells["差引残高"].Value.ToString());
                        }

                        // 売上金額がなかった場合
                        if (!decimal.TryParse(gridTorihiki.Rows[cnt].Cells["売上金額"].Value.ToString(), out decSiireKingaku))
                        {
                            decSiireKingaku = 0;
                        }

                        // 入金金額がなかった場合
                        if (!decimal.TryParse(gridTorihiki.Rows[cnt].Cells["入金額"].Value.ToString(), out decShiharaiKingaku))
                        {
                            decShiharaiKingaku = 0;
                        }

                        // 差引残高
                        decimal decSashihikiZandaka = decZengetsuZandaka + decSiireKingaku - decShiharaiKingaku;
                        gridTorihiki.Rows[cnt].Cells["差引残高"].Value = decSashihikiZandaka.ToString("#,0");
                    }

                    Control cNow = this.ActiveControl;
                    cNow.Focus();

                    //整数になるようにフォーマット
                    txtZenZan.Text = decimal.Parse(txtZenZan.Text.ToString()).ToString("#,0");
                    txtNyukin.Text = decimal.Parse(txtNyukin.Text.ToString()).ToString("#,0");
                    txtUriage.Text = decimal.Parse(txtUriage.Text.ToString()).ToString("#,0");
                    txtZei.Text = decimal.Parse(txtZei.Text.ToString()).ToString("#,0");
                    txtZandaka.Text = decimal.Parse(txtZandaka.Text.ToString()).ToString("#,0");
                }

                // DataTableのレコード数取得
                int dtCnt = dtSetView.Rows.Count;
                if (dtCnt > 0)
                {
                    // ステータスバーに検索結果表示
                    this.lblStatusMessage.Text = "検索終了(該当件数" + dtCnt + "件)";
                }
                else
                {
                    // ステータスバーに検索結果表示
                    this.lblStatusMessage.Text = "検索終了(該当なし)";
                }
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            return;
        }

        ///<summary>
        ///printTokuisakiMotocyoKakunin
        ///印刷ダイアログ
        ///</summary>
        private void printTokuisakiMotocyoKakunin()
        {        
            //SQL実行時に取り出したデータを入れる用
            DataTable dtPrintData = new DataTable();

            //PDF作成後の入れ物
            string strFile = "";

            //印刷対象の選択用
            string strInsatsuSelect = "";

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //得意先コードの検索開始項目のチェック
            if (labelSet_TokuisakiStart.codeTxt.blIsEmpty() == false ||
                StringUtl.blIsEmpty(labelSet_TokuisakiStart.ValueLabelText) == false ||
                labelSet_TokuisakiStart.chkTxtTorihikisaki() == true)
            {
                labelSet_TokuisakiStart.Focus();
                return;
            }

            //得意先コードの終了開始項目のチェック
            if (labelSet_TokuisakiEnd.codeTxt.blIsEmpty() == false ||
                StringUtl.blIsEmpty(labelSet_TokuisakiEnd.ValueLabelText) == false ||
                labelSet_TokuisakiEnd.chkTxtTorihikisaki() == true)
            {
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "得意先コードを範囲で指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                labelSet_TokuisakiEnd.Focus();
                return;
            }

            //空文字判定（検索開始年月）
            if (txtStartYM.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n条件を指定してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtStartYM.Focus();

                return;
            }

            //空文字判定（検索終了年月）
            if (txtEndYM.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n条件を指定してください。 ", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtEndYM.Focus();

                return;
            }

            //得意先開始チェック
            if (labelSet_TokuisakiStart.chkTxtTorihikisaki())
            {
                labelSet_TokuisakiStart.Focus();

                return;
            }

            //得意先終了チェック
            if (labelSet_TokuisakiEnd.chkTxtTorihikisaki())
            {
                labelSet_TokuisakiEnd.Focus();

                return;
            }

            //日付フォーマット生成、およびチェック
            strYMDformat = txtStartYM.chkDateYMDataFormat(txtStartYM.Text);

            //開始年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtStartYM.Focus();

                return;
            }
            else
            {
                txtStartYM.Text = strYMDformat;
            }

            //初期化
            strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtEndYM.chkDateYMDataFormat(txtEndYM.Text);

            //終了年月日の日付チェック
            if (strYMDformat == "")
            {
                // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtEndYM.Focus();

                return;
            }
            else
            {
                txtEndYM.Text = strYMDformat;
            }

            //印刷対象の範囲指定をする場合
            if (radSet_Insatsu.radbtn1.Checked == true)
            {
                strInsatsuSelect = "0";
            }
            else
            {
               strInsatsuSelect = "1";
            }

            //その月の最終日を求める（年月日検索終了項目用）
            int intDay = DateTime.DaysInMonth(DateTime.Parse(txtEndYM.Text).Year, DateTime.Parse(txtEndYM.Text).Month);

            //印刷用データを入れる用
            List<string> lstPrintData = new List<string>();

            //印刷用データを入れる
            lstPrintData.Add(labelSet_TokuisakiStart.CodeTxtText);
            lstPrintData.Add(labelSet_TokuisakiEnd.CodeTxtText);
            lstPrintData.Add(DateTime.Parse(txtStartYM.Text).ToString("yyyy/MM/dd"));
            lstPrintData.Add(DateTime.Parse(txtEndYM.Text).ToString("yyyy/MM/") + intDay.ToString());
            lstPrintData.Add(strInsatsuSelect);

            //得意先コード範囲内の取引先を取得
            E0330_TokuisakiMotocyoKakunin_B tokuisakimotocyokakuninB = new E0330_TokuisakiMotocyoKakunin_B();
            try
            {
                //待機状態
                Cursor.Current = Cursors.WaitCursor;

                dtPrintData = tokuisakimotocyokakuninB.getPrintData(lstPrintData);

                //元に戻す
                Cursor.Current = Cursors.Default;
                
                //データが無ければ
                if (dtPrintData.Rows.Count < 1)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, "印刷", "対象のデータがありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

                //初期値
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, YOKO);

                pf.ShowDialog(this);

                //プレビューの場合
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    //待機状態
                    Cursor.Current = Cursors.WaitCursor;

                    //結果セットをレコードセットに
                    strFile = tokuisakimotocyokakuninB.dbToPdf(dtPrintData, lstPrintData);

                    //元に戻す
                    Cursor.Current = Cursors.Default;

                    //印刷できなかった場合
                    if (strFile == "")
                    {
                        //印刷時エラーメッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, "印刷", "印刷時エラーです。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        return;
                    }

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    strFile = tokuisakimotocyokakuninB.dbToPdf(dtPrintData, lstPrintData);

                    //印刷できなかった場合
                    if (strFile == "")
                    {
                        //印刷時エラーメッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, "印刷", "印刷時エラーです。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        return;
                    }

                    // 一括印刷
                    pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
                }
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }


        }
    }
}
