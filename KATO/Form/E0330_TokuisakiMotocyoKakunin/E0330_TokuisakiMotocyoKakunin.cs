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
    ///更新者：
    ///更新日：
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

            this.WindowState = FormWindowState.Maximized;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;

        }

        //フォームが最初に開いた場合の処理
        private void E0330_TokuisakiMotocyoKakunin_Shown(object sender, EventArgs e)
        {
            //【暫定】

            //画面名不明（gMode=1）
            if (intFrm == 1)
            {
                labelSet_Tokuisaki.CodeTxtText = strTokuisakiCd;

                //this.setUriageJissekikakunin();

                gridTorihiki.Focus();

            }
            //入金入力からの要求
            else if (intFrm == 2)
            {

                labelSet_Tokuisaki.CodeTxtText = strTokuisakiCd;

                //this.setUriageJissekikakunin();

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
            this.btnF12.Text = STR_FUNC_F12;

            //初期表示

            txtStartYM.Text = DateTime.Now.ToString();
            txtEndYM.Text = DateTime.Now.ToString();
            

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
            gridTorihiki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn hiduke = new DataGridViewTextBoxColumn();
            hiduke.DataPropertyName = "伝票年月日";
            hiduke.Name = "伝票年月日";
            hiduke.HeaderText = "日付";

            DataGridViewTextBoxColumn denpyoNo = new DataGridViewTextBoxColumn();
            denpyoNo.DataPropertyName = "伝票番号";
            denpyoNo.Name = "伝票番号";
            denpyoNo.HeaderText = "伝票No";

            DataGridViewTextBoxColumn gyoubangou = new DataGridViewTextBoxColumn();
            gyoubangou.DataPropertyName = "行番号";
            gyoubangou.Name = "行番号";
            gyoubangou.HeaderText = "行番号";

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
            setColumn(hiduke, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(denpyoNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumn(gyoubangou, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#0",80);
            setColumn(kubun1, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,80);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,150);
            setColumn(sinamei_kataban, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter,null,400);
            setColumn(suuryou, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",80);
            setColumn(uriagetanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0.00", 120);
            setColumn(uriagekingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0",120);
            setColumn(nyukinkingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(sasihikizandaka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(kubun2, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,null, 80);

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
                    //logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    //this.printReport();
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
            
        }
        

        /// <summary>
        /// setUriageSuiiHyo
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setTokuisakimotocho()
        {
            //データ検索用
            List<string> lstUriageSuiiLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

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
            EndYMD = DateTime.Parse(EndYMD).AddDays(-1).ToString();

            //データの存在確認を検索する情報を入れる
            /*[0]得意先コード*/
            lstUriageSuiiLoad.Add(labelSet_Tokuisaki.CodeTxtText);
            /*[1]スタート日付（yyyy/MM/dd）*/
            lstUriageSuiiLoad.Add(StartYMD);
            /*[2]スタート日付（yyyy/MM/dd）*/
            lstUriageSuiiLoad.Add(EndYMD);

            //ビジネス層のインスタンス生成
            E0330_TokuisakiMotocyoKakunin_B tokuisakimotocyokakuninB = new E0330_TokuisakiMotocyoKakunin_B();
            try
            {
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

                txtUriage.Text = wkin1.ToString("");

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
                    wkin1 = decimal.Parse(dtSetView.Rows[0]["請求消費税"].ToString());
                }
                else
                {
                    wkin1 = 0;
                }

                txtZei.Text = wkin1.ToString();

                //内税か外税で処理を変更
                if (labelSet_Tokuisaki.AppendLabelText == "外税")
                {
                    //何もしない
                }
                else if (labelSet_Tokuisaki.AppendLabelText == "内税")
                {
                    //内税の場合売上金額から内税を減算
                    txtUriage.Text = (decimal.Parse(txtUriage.Text) - wkin1).ToString();
                }


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
            }
            catch (Exception ex)
            {
                //エラーロギング
                gridTorihiki.Visible = true;
                new CommonException(ex);
                return;
            }
            return;
        }
    }
}
