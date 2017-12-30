using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.A0010_JuchuInput;
using KATO.Common.Ctl;
using KATO.Business.Z0000_B;

namespace KATO.Form.A0010_JuchuInput
{
    public partial class A0010_JuchuInput : KATO.Common.Ctl.BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        bool lockFlg = false;
        bool nokiFlg = false;

        public A0010_JuchuInput(Control c)
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

            //メーカーsetデータを読めるようにする
            lsDaibunrui.Lsmakerdata = lsMaker;
        }

        private void A0010JuchuInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "受注入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF08.Text = STR_FUNC_F8_RIREKI;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            SetUpGrid();
            A0010_JuchuInput_B juchuInput = new A0010_JuchuInput_B();
            try
            {
                DataTable dt = juchuInput.getUserInfo(SystemInformation.UserName);

                if (dt != null && dt.Rows.Count > 0)
                {
                    lsJuchusha.CodeTxtText = dt.Rows[0]["担当者コード"].ToString();
                    txtEigyoshoCd.Text = dt.Rows[0]["営業所コード"].ToString();
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

            txtJuchuYMD.Text = DateTime.Now.ToString("yyyy/MM/dd");

        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            //gridZanList.AutoGenerateColumns = false;

            //データをバインド
            #region
            DataGridViewTextBoxColumn eigyosho = new DataGridViewTextBoxColumn();
            eigyosho.DataPropertyName = "営業所";
            eigyosho.Name = "営業所";
            eigyosho.HeaderText = "営業所";

            DataGridViewTextBoxColumn zaikosu = new DataGridViewTextBoxColumn();
            zaikosu.DataPropertyName = "在庫数";
            zaikosu.Name = "在庫数";
            zaikosu.HeaderText = "在庫数";

            DataGridViewTextBoxColumn juchzan = new DataGridViewTextBoxColumn();
            juchzan.DataPropertyName = "受注残";
            juchzan.Name = "受注残";
            juchzan.HeaderText = "受注残";

            DataGridViewTextBoxColumn hatchuzan = new DataGridViewTextBoxColumn();
            hatchuzan.DataPropertyName = "発注残";
            hatchuzan.Name = "発注残";
            hatchuzan.HeaderText = "発注残";

            DataGridViewTextBoxColumn juchzanUke = new DataGridViewTextBoxColumn();
            juchzanUke.DataPropertyName = "発注残受";
            juchzanUke.Name = "発注残受";
            juchzanUke.HeaderText = "発注残(受)";

            DataGridViewTextBoxColumn freeZaiko = new DataGridViewTextBoxColumn();
            freeZaiko.DataPropertyName = "ﾌﾘｰ在庫";
            freeZaiko.Name = "ﾌﾘｰ在庫";
            freeZaiko.HeaderText = "ﾌﾘｰ在庫";
            #endregion

            #region
            DataGridViewTextBoxColumn juchuNo = new DataGridViewTextBoxColumn();
            juchuNo.DataPropertyName = "受注番号";
            juchuNo.Name = "受注番号";
            juchuNo.HeaderText = "受注番号";

            DataGridViewTextBoxColumn chuban = new DataGridViewTextBoxColumn();
            chuban.DataPropertyName = "注番";
            chuban.Name = "注番";
            chuban.HeaderText = "注番";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー";
            maker.Name = "メーカー";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn chubunruiName = new DataGridViewTextBoxColumn();
            chubunruiName.DataPropertyName = "中分類名";
            chubunruiName.Name = "中分類名";
            chubunruiName.HeaderText = "中分類名";

            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "型番";
            kataban.Name = "型番";
            kataban.HeaderText = "型　　番";

            DataGridViewTextBoxColumn juchuSuryo = new DataGridViewTextBoxColumn();
            juchuSuryo.DataPropertyName = "受注数量";
            juchuSuryo.Name = "受注数量";
            juchuSuryo.HeaderText = "受注数量";

            DataGridViewTextBoxColumn noki = new DataGridViewTextBoxColumn();
            noki.DataPropertyName = "納期";
            noki.Name = "納期";
            noki.HeaderText = "納期";

            DataGridViewTextBoxColumn honshaShukko = new DataGridViewTextBoxColumn();
            honshaShukko.DataPropertyName = "本社出庫";
            honshaShukko.Name = "本社出庫";
            honshaShukko.HeaderText = "本社出庫";

            DataGridViewTextBoxColumn gihuShukko = new DataGridViewTextBoxColumn();
            gihuShukko.DataPropertyName = "岐阜出庫";
            gihuShukko.Name = "岐阜出庫";
            gihuShukko.HeaderText = "岐阜出庫";

            DataGridViewTextBoxColumn hatchuShiji = new DataGridViewTextBoxColumn();
            hatchuShiji.DataPropertyName = "発注指示";
            hatchuShiji.Name = "発注指示";
            hatchuShiji.HeaderText = "発注指示";

            #endregion

            //バインド、個々の幅、文章の寄せの設定
            #region
            setColumn(gridZaiko, eigyosho, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 61);
            setColumn(gridZaiko, zaikosu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 66);
            setColumn(gridZaiko, juchzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 66);
            setColumn(gridZaiko, hatchuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 66);
            setColumn(gridZaiko, juchzanUke, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 96);
            setColumn(gridZaiko, freeZaiko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 74);

            setColumn(gridJuchuZanMeisai, juchuNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(gridJuchuZanMeisai, chuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(gridJuchuZanMeisai, maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(gridJuchuZanMeisai, chubunruiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumn(gridJuchuZanMeisai, kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumn(gridJuchuZanMeisai, juchuSuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 76);
            setColumn(gridJuchuZanMeisai, noki, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(gridJuchuZanMeisai, honshaShukko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 76);
            setColumn(gridJuchuZanMeisai, gihuShukko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 76);
            setColumn(gridJuchuZanMeisai, hatchuShiji, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, 76);

            #endregion
        }

        ///<summary>
        ///setColumn
        ///Grid列設定
        ///</summary>
        private void setColumn(Common.Ctl.BaseDataGridView gr, DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gr.Columns.Add(col);
            if (gr.Columns[col.Name] != null)
            {
                gr.Columns[col.Name].Width = intLen;
                gr.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gr.Columns[col.Name].HeaderCell.Style.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                gr.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gr.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// A0100_HachuInput_KeyDown
        /// キー入力判定
        /// </summary>
        private void A0010_JuchuInput_KeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addJuchu();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delJuchu();
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delFormClear(this);
                    lsDaibunrui.Enabled = true;
                    lsChubunrui.Enabled = true;
                    lsMaker.Enabled = true;
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));
                    //this.setRireki();
                    break;
                case Keys.F9:
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
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
        /// delJuchu
        /// 受注削除
        /// </summary>
        private void delJuchu()
        {
            String strJuchuNo = txtJuchuNo.Text;
            decimal uriageSu = 0;

            // デッドストック管理Noが未入力の場合は処理しない
            if (string.IsNullOrWhiteSpace(strJuchuNo))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "削除する伝票を呼び出してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return;
            }

            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();

            try
            {
                // 売上済がある場合、削除不可
                DataTable dt = juchuB.getUriagezumisuryo(strJuchuNo);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (chkDigit(dt.Rows[0]["仕入済数量"].ToString())) {
                        uriageSu = decimal.Parse(dt.Rows[0]["仕入済数量"].ToString());
                    }
                    if (uriageSu > 0)
                    {
                        BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに売上済みです。削除できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessageboxEr.ShowDialog();
                        return;
                    }
                }
                // 仕入済がある場合、削除不可
                if (juchuB.getShiirezumisuryo(strJuchuNo) > 0)
                {
                    BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに仕入済みです。削除できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessageboxEr.ShowDialog();
                    return;
                }
                // 在庫移動処理済の場合、削除不可
                if (uriageSu != 0)
                {
                    if ((juchuB.getZaikoHikiateFlg(strJuchuNo)).Equals("1"))
                    {
                        BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "在庫が既に移動処理されています。変更・削除は禁止です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessageboxEr.ShowDialog();
                        return;
                    }
                }

                BaseMessageBox basemessageboxSa = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessageboxSa.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                //削除
                juchuB.delJuchu(strJuchuNo, lblStatusUser.Text);

                //// デッドストック在庫を使用していた場合は、再度デッドストックとして戻す
                //if (!String.IsNullOrWhiteSpace(txtDeadStockNo.Text))
                //{
                //    juchuB.restoreDeadStock(txtDeadStockNo.Text);
                //}

                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                this.delFormClear(this);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

            return;
        }

        private void gridJuchuZanMeisai_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtJuchuYMD.ReadOnly = true;
            lsJuchusha.codeTxt.ReadOnly = false;
            txtJuchuNo.ReadOnly = false;
            tsTokuisaki.ReadOnlyANDTabStopFlg = false;
            txtSearchStr.ReadOnly = false;
            txtJuchuSuryo.ReadOnly = false;

            cbJuchuTanka.Enabled = true;
            cbSiireTanka.Enabled = true;

            txtHatchushiji.ReadOnly = false;
            txtHonshaShukko.ReadOnly = false;
            txtGihuShukko.ReadOnly = false;
            txtHatchusu.ReadOnly = false;
            txtChuban.ReadOnly = false;
            tsShiiresaki.ReadOnlyANDTabStopFlg = false;
            txtShiireTanto.ReadOnly = false;
            txtShiireChuban.ReadOnly = false;

            lsDaibunrui.codeTxt.ReadOnly = true;
            lsChubunrui.codeTxt.ReadOnly = true;
            lsMaker.codeTxt.ReadOnly = true;

            txtJuchuNo.Text = "";
            txtHatchuNo.Text = "";

            if (gridJuchuZanMeisai.CurrentRow.Cells[0] != null)
            {
                txtJuchuNo.Text = (gridJuchuZanMeisai.CurrentRow.Cells[0]).ToString();
                getJuchuInfo();
            }
        }

        private void showShohinList()
        {
            KATO.Common.Form.ShouhinList shohinList = new KATO.Common.Form.ShouhinList(this);

            if (!String.IsNullOrWhiteSpace(lsDaibunrui.CodeTxtText))
            {
                shohinList.lsDaibunrui = lsDaibunrui;
            }

            if (!String.IsNullOrWhiteSpace(lsChubunrui.CodeTxtText))
            {
                shohinList.lsChubunrui = lsChubunrui;
            }

            if (!String.IsNullOrWhiteSpace(lsMaker.CodeTxtText))
            {
                shohinList.lsMaker = lsMaker;
            }

            if (!String.IsNullOrWhiteSpace(txtSearchStr.Text))
            {
                shohinList.btxtKensaku = txtSearchStr;
            }
            shohinList.intFrmKind = CommonTeisu.FRM_JUCHUINPUT;
            shohinList.Show();
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
                    //this.addHachu();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    //this.delHachu();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delFormClear(this);
                    break;
                case STR_BTN_F08: // 履歴
                    logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));
                    //this.setRireki();
                    break;
                case STR_BTN_F09: // 履歴
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    //this.setRireki();
                    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// setShohinClose
        /// setShohinListが閉じたらコード記入欄にフォーカス
        /// </summary>
        public void setShohinClose()
        {
            txtSearchStr.Focus();
        }

        /// <summary>
        /// setShouhin
        /// 取り出したデータをテキストボックスに配置（商品リスト）
        /// </summary>
        public void setShouhin(DataTable dtShohin)
        {
            string strCd = dtShohin.Rows[0]["商品コード"].ToString();

            if (!string.IsNullOrWhiteSpace(strCd))
            {
                txtShohinCd.Text = dtShohin.Rows[0]["商品コード"].ToString();
                txtHinmei.Enabled = true;
                txtJuchuSuryo.Enabled = true;
                txtJuchuSuryo.Focus();

            }
            else
            {
                txtSearchStr.Focus();
            }
            //lblGrayTanaHon.Text = dtShohin.Rows[0]["棚番本社"].ToString();
            //lblGrayTanaGihu.Text = dtShohin.Rows[0]["棚番岐阜"].ToString();
            //lblGrayShohin.Text = labelSet_Maker.ValueLabelText +
            //                     labelSet_Chubunrui.ValueLabelText + " " +
            //                     dtShohin.Rows[0]["Ｃ１"].ToString() + " " +
            //                     dtShohin.Rows[0]["Ｃ２"].ToString() + " " +
            //                     dtShohin.Rows[0]["Ｃ３"].ToString() + " " +
            //                     dtShohin.Rows[0]["Ｃ４"].ToString() + " " +
            //                     dtShohin.Rows[0]["Ｃ５"].ToString() + " " +
            //                     dtShohin.Rows[0]["Ｃ６"].ToString();
        }

        private void txtC1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    showShohinList();
                    break;

                default:
                    break;
            }
        }

        private void tsShiiresaki_Leave(object sender, EventArgs e)
        {
            string strCd = tsShiiresaki.CodeTxtText;

            if (!string.IsNullOrWhiteSpace(strCd) && (strCd.Equals("8888") || strCd.Equals("5555")))
            {
                tsShiiresaki.ReadOnlyANDTabStopFlg = false;
            }
            else
            {
                tsShiiresaki.ReadOnlyANDTabStopFlg = true;
            }
        }

        private void txtJuchuNo_Leave(object sender, EventArgs e)
        {
            getJuchuInfo();
        }

        private void getJuchuInfo() {
            string strCd = txtJuchuNo.Text;

            lockFlg = true;

            try
            {
                if (string.IsNullOrWhiteSpace(strCd))
                {
                    return;
                }

                A0010_JuchuInput_B juchuInput = new A0010_JuchuInput_B();

                if (juchuInput.judKakohinJuchu(strCd))
                {
                    BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "加工品の受注です。加工品受注画面で修正してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessageboxEr.ShowDialog();
                    return;
                }

                DataTable dtJuchuNoInfo = juchuInput.getJuchuNoInfo(strCd);

                if (dtJuchuNoInfo != null && dtJuchuNoInfo.Rows.Count > 0)
                {
                    txtJuchuYMD.Text = dtJuchuNoInfo.Rows[0]["受注年月日"].ToString();
                    lsJuchusha.CodeTxtText = dtJuchuNoInfo.Rows[0]["受注者コード"].ToString();
                    tsTokuisaki.CodeTxtText = dtJuchuNoInfo.Rows[0]["得意先コード"].ToString();
                    lsDaibunrui.CodeTxtText = dtJuchuNoInfo.Rows[0]["大分類コード"].ToString();
                    lsChubunrui.CodeTxtText = dtJuchuNoInfo.Rows[0]["中分類コード"].ToString();
                    lsMaker.CodeTxtText = dtJuchuNoInfo.Rows[0]["メーカーコード"].ToString();
                    txtC1.Text = dtJuchuNoInfo.Rows[0]["Ｃ１"].ToString();
                    txtC2.Text = dtJuchuNoInfo.Rows[0]["Ｃ２"].ToString();
                    txtC3.Text = dtJuchuNoInfo.Rows[0]["Ｃ３"].ToString();
                    txtC4.Text = dtJuchuNoInfo.Rows[0]["Ｃ４"].ToString();
                    txtC5.Text = dtJuchuNoInfo.Rows[0]["Ｃ５"].ToString();
                    txtC6.Text = dtJuchuNoInfo.Rows[0]["Ｃ６"].ToString();
                    txtJuchuSuryo.Text = dtJuchuNoInfo.Rows[0]["受注数量"].ToString();
                    cbJuchuTanka.Text = dtJuchuNoInfo.Rows[0]["受注単価"].ToString();
                    cbSiireTanka.Text = dtJuchuNoInfo.Rows[0]["仕入単価"].ToString();
                    txtNoki.Text = dtJuchuNoInfo.Rows[0]["納期"].ToString();
                    txtChuban.Text = (dtJuchuNoInfo.Rows[0]["注番"].ToString()).Trim();
                    txtEigyoshoCd.Text = dtJuchuNoInfo.Rows[0]["営業所コード"].ToString();
                    txtTantosha.Text = dtJuchuNoInfo.Rows[0]["担当者コード"].ToString();
                    txtHatchushiji.Text = dtJuchuNoInfo.Rows[0]["発注指示区分"].ToString();
                    txtShohinCd.Text = dtJuchuNoInfo.Rows[0]["商品コード"].ToString();
                    txtHonshaShukko.Text = dtJuchuNoInfo.Rows[0]["本社出庫数"].ToString();
                    txtGihuShukko.Text = dtJuchuNoInfo.Rows[0]["岐阜出庫数"].ToString();
                    txtShukkaShiji.Text = dtJuchuNoInfo.Rows[0]["出荷指示区分"].ToString();
                    txtZaikoHikiate.Text = dtJuchuNoInfo.Rows[0]["在庫引当フラグ"].ToString();
                    txtUriage.Text = dtJuchuNoInfo.Rows[0]["売上フラグ"].ToString();

                    string strHinmei = txtC1.Text.Trim() + " "
                        + txtC2.Text.Trim() + " "
                        + txtC3.Text.Trim() + " "
                        + txtC4.Text.Trim() + " "
                        + txtC5.Text.Trim() + " "
                        + txtC6.Text.Trim();
                    txtHinmei.Text = strHinmei.Trim();

                    txtJuchuSuryo.ReadOnly = false;
                    cbJuchuTanka.Enabled = true;
                    cbSiireTanka.Enabled = true;
                    txtNoki.ReadOnly = false;

                    if (txtShohinCd.Text.Equals("88888"))
                    {
                        lsDaibunrui.codeTxt.ReadOnly = false;
                        lsChubunrui.codeTxt.ReadOnly = false;
                        lsMaker.codeTxt.ReadOnly = false;
                    }
                    else
                    {
                        lsDaibunrui.Enabled = false;
                        lsChubunrui.Enabled = false;
                        lsMaker.Enabled = false;
                        txtHinmei.Enabled = false;
                    }

                    DataTable dtHatchuNo = juchuInput.getHatchuNoInfo(strCd);
                    if (dtHatchuNo != null && dtHatchuNo.Rows.Count > 0) {
                        if (!string.IsNullOrWhiteSpace(dtHatchuNo.Rows[0]["発注番号"].ToString()))
                        {
                            txtHatchuNo.Text = dtHatchuNo.Rows[0]["発注番号"].ToString();
                        }
                        else
                        {
                            txtHatchusu.Text = "0";
                        }
                    }

                    decimal decUriSuryo = 0;
                    if (chkDigit(dtJuchuNoInfo.Rows[0]["売上済数量"].ToString())) {
                        decUriSuryo = decimal.Parse(dtJuchuNoInfo.Rows[0]["売上済数量"].ToString());
                    }

                    decimal decJuchuSuryo = 0;
                    if (chkDigit(dtJuchuNoInfo.Rows[0]["受注数量"].ToString()))
                    {
                        decJuchuSuryo = decimal.Parse(dtJuchuNoInfo.Rows[0]["受注数量"].ToString());
                    }
                    if (decUriSuryo == 0)
                    {
                        lockFlg = false;
                    }
                    else if (decUriSuryo == decJuchuSuryo)
                    {
                        btnF01.Enabled = false;
                        btnF03.Enabled = false;
                        btnF08.Enabled = false;
                        btnF09.Enabled = false;
                        BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "売上済の受注です。変更は不可です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessageboxEr.ShowDialog();
                        return;
                    }
                    else if (decUriSuryo > 0)
                    {
                        txtUriSuryo.Text = decUriSuryo.ToString();
                        txtJuchuNo.ReadOnly = true;
                        txtJuchuYMD.ReadOnly = true;

                        if (powerUserFlg)
                        {
                            lsJuchusha.codeTxt.ReadOnly = false;
                            cbJuchuTanka.Enabled = true;
                        }
                        else
                        {
                            lsJuchusha.codeTxt.ReadOnly = true;
                            cbJuchuTanka.Enabled = false;
                        }
                        tsTokuisaki.ReadOnlyANDTabStopFlg = true;
                        lsDaibunrui.codeTxt.ReadOnly = true;
                        lsChubunrui.codeTxt.ReadOnly = true;
                        lsMaker.codeTxt.ReadOnly = true;
                        txtSearchStr.ReadOnly = true;
                        txtHinmei.ReadOnly = true;
                        txtJuchuSuryo.ReadOnly = true;

                        cbSiireTanka.Enabled = false;
                        txtHatchushiji.ReadOnly = true;
                        txtHonshaShukko.ReadOnly = true;
                        txtGihuShukko.ReadOnly = true;
                        txtHatchusu.ReadOnly = true;
                        tsShiiresaki.ReadOnlyANDTabStopFlg = true;
                        txtShiireChuban.ReadOnly = true;

                        if (dtHatchuNo != null && dtHatchuNo.Rows.Count > 0)
                        {
                            decimal decShiireSuryo = 0;
                            if (chkDigit(dtHatchuNo.Rows[0]["仕入済数量"].ToString()))
                            {
                                decShiireSuryo = decimal.Parse(dtHatchuNo.Rows[0]["仕入済数量"].ToString());
                            }

                            if (decUriSuryo == decShiireSuryo)
                            {
                                nokiFlg = true;
                                txtJuchuSuryo.Enabled = true;
                                BaseMessageBox basemessageboxEr1 = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "分納で売上済みです。受注数・納期・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                                basemessageboxEr1.ShowDialog();
                                return;
                            }
                        }

                        nokiFlg = true;
                        txtJuchuSuryo.Enabled = true;
                        BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "分納で売上済みです。納期・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessageboxEr.ShowDialog();
                        txtNoki.Focus();
                        return;
                    }

                    if (dtHatchuNo != null && dtHatchuNo.Rows.Count > 0)
                    {
                        decimal decShiireSuryo = 0;
                        if (chkDigit(dtHatchuNo.Rows[0]["仕入済数量"].ToString())) {
                            decShiireSuryo = decimal.Parse(dtHatchuNo.Rows[0]["仕入済数量"].ToString());
                        }

                        if (decShiireSuryo > 0)
                        {
                            BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "分納で売上済みです。納期・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                            basemessageboxEr.ShowDialog();

                            txtJuchuNo.ReadOnly = true;
                            txtJuchuYMD.ReadOnly = true;

                            if (powerUserFlg)
                            {
                                lsJuchusha.codeTxt.ReadOnly = false;
                                cbJuchuTanka.Enabled = true;
                            }
                            else
                            {
                                lsJuchusha.codeTxt.ReadOnly = true;
                                cbJuchuTanka.Enabled = false;
                            }
                            tsTokuisaki.ReadOnlyANDTabStopFlg = true;
                            txtSearchStr.ReadOnly = true;
                            txtHinmei.ReadOnly = true;
                            txtJuchuSuryo.ReadOnly = true;

                            cbSiireTanka.Enabled = false;
                            txtHatchushiji.ReadOnly = true;
                            txtHonshaShukko.ReadOnly = true;
                            txtGihuShukko.ReadOnly = true;
                            txtHatchusu.ReadOnly = true;
                            tsShiiresaki.ReadOnlyANDTabStopFlg = true;
                            txtShiireChuban.ReadOnly = true;

                        }
                        else
                        {
                            txtJuchuNo.ReadOnly = false;
                            txtJuchuYMD.ReadOnly = false;

                            lsJuchusha.codeTxt.ReadOnly = false;
                            cbJuchuTanka.Enabled = true;
                            tsTokuisaki.ReadOnlyANDTabStopFlg = false;
                            txtSearchStr.ReadOnly = false;
                            txtJuchuSuryo.ReadOnly = false;

                            cbSiireTanka.Enabled = true;
                            txtHatchushiji.ReadOnly = false;
                            txtHonshaShukko.ReadOnly = false;
                            txtGihuShukko.ReadOnly = false;
                            txtChuban.ReadOnly = false;

                            txtHatchusu.ReadOnly = false;
                            tsShiiresaki.ReadOnlyANDTabStopFlg = false;
                            txtShiireChuban.ReadOnly = false;

                        }
                    }
                    else
                    {
                        txtJuchuNo.ReadOnly = false;
                        txtJuchuYMD.ReadOnly = false;
                        lsJuchusha.codeTxt.ReadOnly = false;

                        cbJuchuTanka.Enabled = true;

                        tsTokuisaki.ReadOnlyANDTabStopFlg = false;
                        txtSearchStr.ReadOnly = false;
                        txtJuchuSuryo.ReadOnly = false;

                        cbSiireTanka.Enabled = false;

                        txtHatchushiji.ReadOnly = false;
                        txtHonshaShukko.ReadOnly = false;
                        txtGihuShukko.ReadOnly = false;
                        txtChuban.ReadOnly = false;

                        txtHatchusu.ReadOnly = false;
                        tsShiiresaki.ReadOnlyANDTabStopFlg = false;
                        txtShiireChuban.ReadOnly = false;
                    }

                    if (!lsDaibunrui.CodeTxtText.Equals("28"))
                    {
                        if (string.IsNullOrWhiteSpace(txtJuchuSuryo.Text) && int.Parse(txtJuchuSuryo.Text) == 0)
                        {
                            cbSiireTanka.Enabled = false;
                        }
                    }
                }

                lockFlg = false;

                execZaikoDisp();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void txtJuchuNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9 || e.KeyCode == Keys.Enter)
            {
                //
                if (tsTokuisaki.CodeTxtText == null || string.IsNullOrWhiteSpace(tsTokuisaki.CodeTxtText))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "取引先コードを指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                D0360_JuchuzanKakunin.D0360_JuchuzanKakunin juchuZan = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this, tsTokuisaki.CodeTxtText, txtJuchuNo);
                juchuZan.ShowDialog();
                if (!string.IsNullOrWhiteSpace(txtJuchuNo.Text))
                {
                    getJuchuInfo();
                }
            }
        }

        private void txtHatchuNo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbJuchuTanka_SelectedIndexChanged(object sender, EventArgs e)
        {
            updKakeritsu();
        }

        private void cbJuchuTanka_Leave(object sender, EventArgs e)
        {
            updKakeritsu();
        }

        private void cbKinShiireTanka_Leave(object sender, EventArgs e)
        {
            updKakeritsu();
        }

        private void updKakeritsu()
        {
            if (lsDaibunrui.CodeTxtText.Equals("28") && lsChubunrui.CodeTxtText.Equals("04"))
            {
                cbSiireTanka.Text = cbJuchuTanka.Text;
            }
            // 定価が未設定の場合、掛率を計算しない
            if (string.IsNullOrEmpty(txtTeika.Text) || double.Parse(txtTeika.Text) == 0)
            {
                return;
            }

            string strNumerator = "0";

            if (string.IsNullOrEmpty(cbJuchuTanka.Text))
            {
                strNumerator = "0";
            }
            else
            {
                strNumerator = cbJuchuTanka.Text;
            }
            txtJuchuTankaSub.Text = (double.Parse(strNumerator) / double.Parse(txtTeika.Text) * 100).ToString();

            if (string.IsNullOrEmpty(cbSiireTanka.Text))
            {
                strNumerator = "0";
            }
            else
            {
                strNumerator = cbSiireTanka.Text;
            }
            txtSiireTankaSub.Text = (double.Parse(strNumerator) / double.Parse(txtTeika.Text) * 100).ToString();

            if (string.IsNullOrEmpty(cbKinShiireTanka.Text))
            {
                strNumerator = "0";
            }
            else
            {
                strNumerator = cbKinShiireTanka.Text;
            }
            txtKinSiireTankaSub.Text = (double.Parse(strNumerator) / double.Parse(txtTeika.Text) * 100).ToString();

        }

        // 在庫一覧表示
        private void execZaikoDisp()
        {
            getZaikoInfo();
        }

        private void cbJuchuTanka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(cbJuchuTanka.Text))
                {
                    cbJuchuTanka.Focus();
                }
            }
        }

        private void txtSearchStr_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchStr.Text))
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F9)
                {
                    // TODO: 商品リスト呼び出し
                }
            }
        }

        private void txtNoki_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoki.Text))
            {
                return;
            }

            //if ()
            //{

            if (txtNoki.Text.CompareTo(DateTime.Now.ToString("yyyy/MM/dd")) < 0)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は本日以降に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                txtNoki.Text = "";
                txtNoki.Focus();
                return;
            }

            DateTime endDateTime = DateTime.Parse(txtJuchuYMD.Text);
            string strEndDay = endDateTime.AddYears(1).ToString("yyyy/MM/dd");

            if (!string.IsNullOrWhiteSpace(txtJuchuNo.Text))
            {
                A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                try
                {
                    DataTable dtHatchu = juchuB.getShiireSuryouNoki(txtJuchuNo.Text);

                    if (dtHatchu != null && dtHatchu.Rows.Count > 0)
                    {
                        String strSuryo = dtHatchu.Rows[0]["仕入済数量"].ToString();
                        if (int.Parse(strSuryo) > 0)
                        {
                            strEndDay = endDateTime.AddMonths(6).ToString("yyyy/MM/dd");
                        }
                    }
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtHatchusu.Text) && Decimal.Parse(txtHatchusu.Text) != 0)
            {
                if (txtNoki.Text.CompareTo(strEndDay) > 0)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は仕入済みの場合は６ケ月、未仕入の場合は１年間に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    txtNoki.Text = "";
                    txtNoki.Focus();
                    return;
                }
            }

            //}
        }

        private void txtShiireNoki_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtShiireNoki.Text))
            {
                return;
            }

            //if ()
            //{

            if (txtShiireNoki.Text.CompareTo(DateTime.Now.ToString("yyyy/MM/dd")) < 0)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は本日以降に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                txtShiireNoki.Text = "";
                txtShiireNoki.Focus();
                return;
            }

            DateTime endDateTime = DateTime.Parse(txtJuchuYMD.Text);
            string strEndDay = endDateTime.AddYears(1).ToString("yyyy/MM/dd");

            if (string.IsNullOrWhiteSpace(txtJuchuNo.Text))
            {
                A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                try
                {
                    DataTable dtHatchu = juchuB.getShiireSuryouNoki(txtJuchuNo.Text);

                    if (dtHatchu != null && dtHatchu.Rows.Count > 0)
                    {
                        String strSuryo = dtHatchu.Rows[0]["仕入済数量"].ToString();
                        if (int.Parse(strSuryo) > 0)
                        {
                            strEndDay = endDateTime.AddMonths(6).ToString("yyyy/MM/dd");
                        }
                    }
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(txtHatchusu.Text) && decimal.Parse(txtHatchusu.Text) > 0)
            {
                if (txtShiireNoki.Text.CompareTo(strEndDay) > 0)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は仕入済みの場合は６ケ月、未仕入の場合は１年間に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    txtShiireNoki.Text = "";
                    txtShiireNoki.Focus();
                    return;
                }
            }

            //}

        }

        private void txtJuchuSuryo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJuchuSuryo.Text))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(txtJuchuNo.Text))
            {
                txtHonshaShukko.Text = "0";
                txtGihuShukko.Text = "0";
                txtHatchusu.Text = "0";

                if (txtEigyoshoCd.Equals("0001"))
                {
                    txtHonshaShukko.Text = txtJuchuSuryo.Text;
                }
                else if (txtEigyoshoCd.Equals("0002"))
                {
                    txtGihuShukko.Text = txtJuchuSuryo.Text;
                }
            }
        }

        // TODO
        private void txtJuchuSuryo_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShohinCd.Text))
            {
                return;
            }
            getZaikoInfo();
        }

        private void txtHatchusu_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHatchusu.Text))
            {
                panel1.Visible = false;
                txtHatchushiji.Text = "0";
            }
            else if (txtHatchusu.Text.Equals("0"))
            {
                panel1.Visible = false;
                txtHatchushiji.Text = "0";
                txtHatchuNo.Text = "";
                txtShiireTanto.Text = "";
                tsShiiresaki.CodeTxtText = "";
                tsShiiresaki.valueTextText = "";
                txtShiireNoki.Text = "";
                txtShiireChuban.Text = "";
            }
            else
            {
                panel1.Visible = true;
                panel1.Enabled = true;
                txtHatchushiji.Text = "1";
                txtHatchuNo.ReadOnly = false;
                txtShiireTanto.ReadOnly = false;
                txtShiireChuban.ReadOnly = false;
            }

            if (panel1.Enabled == true && tsShiiresaki.ReadOnlyANDTabStopFlg == false)
            {
                tsShiiresaki.codeTxt.Focus();
            }
        }

        private void txtShohinCd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShohinCd.Text))
            {
                return;
            }

            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dtShohin = juchuB.getShohin(txtShohinCd.Text);

                if (dtShohin != null && dtShohin.Rows.Count > 0)
                {
                    lsDaibunrui.codeTxt.Focus();
                    lsDaibunrui.CodeTxtText = dtShohin.Rows[0]["大分類コード"].ToString();
                    lsChubunrui.codeTxt.Focus();
                    lsChubunrui.CodeTxtText = dtShohin.Rows[0]["中分類コード"].ToString();
                    lsMaker.codeTxt.Focus();
                    lsMaker.CodeTxtText = dtShohin.Rows[0]["メーカーコード"].ToString();

                    txtJuchuSuryo.Focus();

                    txtC1.Text = dtShohin.Rows[0]["Ｃ１"].ToString();
                    txtC2.Text = dtShohin.Rows[0]["Ｃ２"].ToString();
                    txtC3.Text = dtShohin.Rows[0]["Ｃ３"].ToString();
                    txtC4.Text = dtShohin.Rows[0]["Ｃ４"].ToString();
                    txtC5.Text = dtShohin.Rows[0]["Ｃ５"].ToString();
                    txtC6.Text = dtShohin.Rows[0]["Ｃ６"].ToString();

                    txtHinmei.Text = txtC1.Text + " " + txtC2.Text + " " + txtC3.Text + " " + txtC4.Text + " " + txtC5.Text + " " + txtC6.Text + " ";

                    lsDaibunrui.codeTxt.ReadOnly = true;
                    lsChubunrui.codeTxt.ReadOnly = true;
                    lsChubunrui.codeTxt.ReadOnly = true;

                    txtTeika.Text = dtShohin.Rows[0]["定価"].ToString();
                    cbJuchuTanka.Text = dtShohin.Rows[0]["標準売価"].ToString();
                    txtHinmei.ReadOnly = true;

                    lblGrayTanaHon.Text = dtShohin.Rows[0]["棚番本社"].ToString();
                    lblGrayTanaSub.Text = dtShohin.Rows[0]["棚番岐阜"].ToString();

                    getKinShiireTanka();
                    getJuchuTanka();
                    getKinShiireTanka();
                    updKakeritsu();
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void getKinShiireTanka()
        {
            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dtTanka = juchuB.getKinShiireTanka(txtShohinCd.Text);

                cbKinShiireTanka.Items.Clear();
                cbKinShiireTanka.Items.Add("");

                for (int i = 0; i < dtTanka.Rows.Count; i++)
                {
                    cbKinShiireTanka.Items.Add(dtTanka.Rows[0]["仕入単価"].ToString() + ":" + dtTanka.Rows[0]["仕入先名称"].ToString() + ":" + dtTanka.Rows[0]["伝票年月日"].ToString());
                }
                cbKinShiireTanka.Refresh();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void getJuchuTanka()
        {
            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dtTanka = juchuB.getJuchuTanka(txtShohinCd.Text, tsTokuisaki.CodeTxtText);

                cbJuchuTanka.Items.Clear();
                cbJuchuTanka.Items.Add("");

                for (int i = 0; i < dtTanka.Rows.Count; i++)
                {
                    cbJuchuTanka.Items.Add(dtTanka.Rows[0]["受注単価"].ToString() + ":" + dtTanka.Rows[0]["受注日"].ToString());
                }
                cbJuchuTanka.Refresh();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void getShiireTanka()
        {
            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dtTanka = juchuB.getShiireTanka(txtShohinCd.Text);

                cbSiireTanka.Items.Clear();
                cbSiireTanka.Items.Add("");

                for (int i = 0; i < dtTanka.Rows.Count; i++)
                {
                    cbSiireTanka.Items.Add(dtTanka.Rows[0]["仕入単価"].ToString() + ":" + dtTanka.Rows[0]["仕入日"].ToString());
                }
                cbSiireTanka.Refresh();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void addJuchu()
        {
            if (!chkData())
            {
                return;
            }

            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            if (cbChuban.Checked)
            {
                try
                {
                    juchuB.updChubanOnly(txtJuchuNo.Text, txtChuban.Text);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "注番を更新しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                    clearInput2();
                    return;
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }

            if (tsTokuisaki.codeTxt.ReadOnly == true)
            {
                try
                {

                    juchuB.updNokiOnly(txtChuban.Text
                        ,txtNoki.Text
                        ,txtJuchuSuryo.Text
                        ,cbJuchuTanka.Text
                        ,(decimal.Parse(cbJuchuTanka.Text) * decimal.Parse(txtJuchuSuryo.Text)).ToString()
                        ,txtHonshaShukko.Text
                        ,txtGihuShukko.Text
                        ,lsJuchusha.CodeTxtText
                        ,txtJuchuNo.Text
                        ,txtHatchuNo.Text
                        ,txtShiireNoki.Text);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "数量・納期・注番を更新しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                    clearInput2();
                    return;
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }

            try
            {
                juchuB.beginTrance();

                string strJuchuNo = null;
                if (string.IsNullOrWhiteSpace(txtJuchuNo.Text))
                {
                    strJuchuNo = juchuB.getDenpyoNo("受注伝票");
                }
                else
                {
                    strJuchuNo = txtJuchuNo.Text;
                }

                string strC1 = null;
                string strC2 = null;
                string strC3 = null;
                string strC4 = null;
                string strC5 = null;
                string strC6 = null;

                if (txtHinmei.Enabled)
                {
                    strC1 = txtHinmei.Text;
                }
                else
                {
                    strC1 = txtC1.Text;
                    strC2 = txtC2.Text;
                    strC3 = txtC3.Text;
                    strC4 = txtC4.Text;
                    strC5 = txtC5.Text;
                    strC6 = txtC6.Text;
                }

                string strShohinCd = "";
                string strHinMei = "";
                if (!string.IsNullOrWhiteSpace(txtHinmei.Text))
                {
                    strHinMei = txtHinmei.Text;
                }

                if (string.IsNullOrWhiteSpace(txtShohinCd.Text)) {
                    DataTable dtShohin = juchuB.getShohinForUpd(lsDaibunrui.CodeTxtText, lsChubunrui.CodeTxtText, lsMaker.CodeTxtText, strHinMei);

                    if (dtShohin != null && dtShohin.Rows.Count > 0)
                    {
                        strShohinCd = dtShohin.Rows[0]["商品コード"].ToString();
                    }
                    else
                    {
                        strShohinCd = "88888";
                    }
                }
                else
                {
                    strShohinCd = txtShohinCd.Text;
                }

                decimal decKin = 0;
                decimal decArari = 0;
                if (chkDigit(cbJuchuTanka.Text) && chkDigit(txtJuchuSuryo.Text)) {
                    decKin = decimal.Parse(cbJuchuTanka.Text) * decimal.Parse(txtJuchuSuryo.Text);
                    decArari = decimal.Parse(cbJuchuTanka.Text) * decimal.Parse(txtJuchuSuryo.Text);
                    if (chkDigit(cbKinShiireTanka.Text)) {
                        decArari = decArari - decimal.Parse(cbKinShiireTanka.Text) * decimal.Parse(txtJuchuSuryo.Text);
                    }
                }

                if (string.IsNullOrWhiteSpace(txtShukkaShiji.Text))
                {
                    txtShukkaShiji.Text = "0";
                }
                if (string.IsNullOrWhiteSpace(txtZaikoHikiate.Text))
                {
                    txtZaikoHikiate.Text = "0";
                }
                if (string.IsNullOrWhiteSpace(txtUriage.Text))
                {
                    txtUriage.Text = "0";
                }

                List<String> aryPrm = new List<string>();

                aryPrm.Add(tsTokuisaki.CodeTxtText);
                aryPrm.Add(tsTokuisaki.valueTextText);
                aryPrm.Add(txtJuchuYMD.Text);
                aryPrm.Add(strJuchuNo);
                aryPrm.Add(lsJuchusha.CodeTxtText);
                aryPrm.Add(txtEigyoshoCd.Text);
                aryPrm.Add(txtTantosha.Text);
                aryPrm.Add(strShohinCd);
                aryPrm.Add(lsMaker.CodeTxtText);
                aryPrm.Add(lsDaibunrui.CodeTxtText);
                aryPrm.Add(lsChubunrui.CodeTxtText);
                aryPrm.Add(strC1);
                aryPrm.Add(strC2);
                aryPrm.Add(strC3);
                aryPrm.Add(strC4);
                aryPrm.Add(strC5);
                aryPrm.Add(strC6);
                aryPrm.Add(txtJuchuSuryo.Text);
                aryPrm.Add(cbJuchuTanka.Text);
                aryPrm.Add(decKin.ToString());
                aryPrm.Add(cbSiireTanka.Text);
                aryPrm.Add(decArari.ToString());
                aryPrm.Add(txtNoki.Text);
                aryPrm.Add(txtShukkaShiji.Text);
                aryPrm.Add(txtZaikoHikiate.Text);
                aryPrm.Add(txtUriage.Text);
                aryPrm.Add(txtChuban.Text);
                aryPrm.Add(txtHatchushiji.Text);
                aryPrm.Add(txtHonshaShukko.Text);
                aryPrm.Add(txtGihuShukko.Text);
                aryPrm.Add("0");
                aryPrm.Add(Environment.UserName);

                juchuB.beginTrance();
                juchuB.updJuchu(aryPrm);

                if (string.IsNullOrWhiteSpace(txtHatchusu.Text) || txtHatchusu.Text.Equals("0"))
                {
                    DataTable dtHachu = juchuB.getHatchuNoInfo(strJuchuNo);

                    if (dtHachu != null && dtHachu.Rows.Count > 0)
                    {
                        juchuB.delHachu(dtHachu.Rows[0]["発注番号"].ToString(), Environment.UserName);
                    }
                    juchuB.commit();
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "正常に登録されました", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                }
                else
                {
                    string strHachuNo = addJuchuH(strJuchuNo);
                    string strMsg = juchuB.getChubanName(lsJuchusha.CodeTxtText);
                    juchuB.commit();
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "正常に登録されました\r\n注番:" + strMsg.TrimEnd() + strHachuNo, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                    
                }

                clearInput2();
                tsTokuisaki.codeTxt.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                juchuB.rollback();
                return;
            }
        }
        private string addJuchuH(string strJuchuNo)
        {
            string ret = "";

            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                if (string.IsNullOrWhiteSpace(txtHatchuNo.Text))
                {
                    ret = juchuB.getDenpyoNo("発注番号");
                }
                else
                {
                    ret = txtHatchuNo.Text;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string strShohin = "";

            if (string.IsNullOrWhiteSpace(txtShohinCd.Text))
            {
                strShohin = "88888";
            }
            else
            {
                strShohin = txtShohinCd.Text;
            }

            string strC1 = txtC1.Text;
            string strC2 = txtC2.Text;
            string strC3 = txtC3.Text;
            string strC4 = txtC4.Text;
            string strC5 = txtC5.Text;
            string strC6 = txtC6.Text;

            if (string.IsNullOrWhiteSpace(txtShohinCd.Text) || txtShohinCd.Text.Equals("88888"))
            {
                strC1 = txtHinmei.Text;
            }

            decimal deckin = 0;
            if (chkDigit(cbSiireTanka.Text) && chkDigit(txtHatchusu.Text)) {
                deckin = int.Parse(cbSiireTanka.Text) * int.Parse(txtHatchusu.Text);
            }

            List<String> aryPrm = new List<string>();

            aryPrm.Add(tsShiiresaki.CodeTxtText);
            aryPrm.Add(txtJuchuYMD.Text);
            aryPrm.Add(ret);
            aryPrm.Add(lsJuchusha.CodeTxtText);
            aryPrm.Add(txtEigyoshoCd.Text);
            aryPrm.Add(lsJuchusha.CodeTxtText);
            aryPrm.Add(strJuchuNo);
            aryPrm.Add("0");
            aryPrm.Add("0");
            aryPrm.Add(strShohin);
            aryPrm.Add(lsMaker.CodeTxtText);
            aryPrm.Add(lsDaibunrui.CodeTxtText);
            aryPrm.Add(lsChubunrui.CodeTxtText);
            aryPrm.Add(strC1);
            aryPrm.Add(strC2);
            aryPrm.Add(strC3);
            aryPrm.Add(strC4);
            aryPrm.Add(strC5);
            aryPrm.Add(strC6);
            aryPrm.Add(txtHatchusu.Text);
            aryPrm.Add(cbSiireTanka.Text);
            aryPrm.Add(deckin.ToString());
            aryPrm.Add(txtShiireNoki.Text);
            aryPrm.Add("0");
            aryPrm.Add(txtShiireChuban.Text);
            aryPrm.Add("0");
            aryPrm.Add(tsShiiresaki.valueTextText);
            aryPrm.Add(Environment.UserName);

            try
            {
                juchuB.updJuchuH(aryPrm);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        private bool chkData()
        {
            if (!string.IsNullOrWhiteSpace(txtJuchuNo.Text) && txtJuchuNo.Text.Equals("0"))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "伝票番号＝０は無効です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtJuchuYMD.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                txtJuchuYMD.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(lsJuchusha.CodeTxtText))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                lsJuchusha.codeTxt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(tsTokuisaki.CodeTxtText))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                tsTokuisaki.codeTxt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(lsDaibunrui.CodeTxtText))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                lsDaibunrui.codeTxt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(lsChubunrui.CodeTxtText))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                lsChubunrui.codeTxt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(lsMaker.CodeTxtText))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                lsMaker.codeTxt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHinmei.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                txtHinmei.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtJuchuSuryo.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                txtJuchuSuryo.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbJuchuTanka.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                cbJuchuTanka.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbSiireTanka.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                cbSiireTanka.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNoki.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                txtNoki.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHonshaShukko.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                txtHonshaShukko.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGihuShukko.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                txtGihuShukko.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHatchushiji.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                txtHatchusu.Focus();
                return false;
            }

            DateTime endDateTime = DateTime.Parse(txtJuchuYMD.Text);
            string strEndDay = endDateTime.AddYears(1).ToString("yyyy/MM/dd");

            if (!string.IsNullOrWhiteSpace(txtJuchuNo.Text))
            {
                A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                try
                {
                    DataTable dtHatchu = juchuB.getShiireSuryouNoki(txtJuchuNo.Text);

                    if (dtHatchu != null && dtHatchu.Rows.Count > 0)
                    {
                        String strSuryo = dtHatchu.Rows[0]["仕入済数量"].ToString();
                        if (chkDigit(strSuryo) && decimal.Parse(strSuryo) > 0)
                        {
                            strEndDay = endDateTime.AddMonths(6).ToString("yyyy/MM/dd");
                        }
                    }
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
            }

            //if ()
            //{

            if (!cbChuban.Checked)
            {
                if (txtNoki.Text.CompareTo(DateTime.Now.ToString("yyyy/MM/dd")) < 0)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は本日以降に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    txtNoki.Text = "";
                    txtNoki.Focus();
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(txtHatchusu.Text) && int.Parse(txtHatchusu.Text) > 0)
                {
                    if (txtNoki.Text.CompareTo(strEndDay) > 0)
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は仕入済みの場合は６ケ月、未仕入の場合は１年間に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        txtNoki.Text = "";
                        txtNoki.Focus();
                        return false;
                    }
                }

                if (txtShiireNoki.Text.CompareTo(DateTime.Now.ToString("yyyy/MM/dd")) < 0)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は本日以降に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    txtShiireNoki.Text = "";
                    txtShiireNoki.Focus();
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(txtHatchusu.Text) && int.Parse(txtHatchusu.Text) > 0)
                {
                    if (txtShiireNoki.Text.CompareTo(strEndDay) > 0)
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は仕入済みの場合は６ケ月、未仕入の場合は１年間に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        txtShiireNoki.Text = "";
                        txtShiireNoki.Focus();
                        return false;
                    }
                }
            }

            //}

            if (chkDigit(txtJuchuSuryo.Text) && decimal.Parse(txtJuchuSuryo.Text) > 0)
            {
                if (decimal.Parse(txtHonshaShukko.Text) + decimal.Parse(txtGihuShukko.Text) > decimal.Parse(txtJuchuSuryo.Text))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫数は受注数量以下で入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return false;
                }
            }

            if (chkDigit(txtJuchuSuryo.Text) && decimal.Parse(txtJuchuSuryo.Text) < 0)
            {
                if (decimal.Parse(cbSiireTanka.Text).Equals(0))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "数量がマイナスの場合は仕入単価＝０は不可です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return false;
                }

                if (txtHatchushiji.Text.Equals("0"))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "数量がマイナスの場合は発注指示をしてください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return false;
                }
            }

            if (int.Parse(txtJuchuSuryo.Text) < 0)
            {
            }

            if (!string.IsNullOrWhiteSpace(txtJuchuNo.Text))
            {
                A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                try
                {
                    DataTable dtHikiate = juchuB.getHikiate(txtJuchuNo.Text);

                    if (dtHikiate != null && dtHikiate.Rows.Count > 0)
                    {
                        String strHikiate = dtHikiate.Rows[0]["在庫引当フラグ"].ToString();
                        if (strHikiate.Equals("1"))
                        {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "在庫が既に移動処理されています。納期以外の変更は禁止です\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_EXCLAMATION);
                            //NOが押された場合
                            if (basemessagebox.ShowDialog() == DialogResult.No)
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
            }

            if (nokiFlg)
            {
                if (txtHatchushiji.Equals("0"))
                {
                    if (int.Parse(txtHonshaShukko.Text) + int.Parse(txtGihuShukko.Text) != int.Parse(txtJuchuSuryo.Text))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫数の入力に誤りがあります", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        txtJuchuSuryo.Focus();
                        return false;
                    }
                }
                else
                {
                    if (int.Parse(txtHonshaShukko.Text) + int.Parse(txtGihuShukko.Text) + int.Parse(txtHatchusu.Text) != int.Parse(txtJuchuSuryo.Text))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫数・発注数の入力に誤りがあります", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        txtJuchuSuryo.Focus();
                        return false;
                    }
                }

                if (string.IsNullOrWhiteSpace(tsShiiresaki.CodeTxtText))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    tsShiiresaki.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtShiireTanto.Text))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    txtShiireTanto.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtShiireNoki.Text))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    txtShiireNoki.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtUriSuryo.Text))
            {
                if (!lsDaibunrui.CodeTxtText.Equals("28"))
                {
                    if (int.Parse(txtJuchuSuryo.Text) < int.Parse(txtUriSuryo.Text))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "受注数量は売上済数量以上を入力してください。\r\n売上済：" + txtUriSuryo.Text, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        txtJuchuSuryo.Focus();
                        return false;
                    }
                }
            }

            //if ()
            //{
            if (!txtShohinCd.Text.Equals("88888"))
            {
                if (!lsDaibunrui.CodeTxtText.Equals("28"))
                {
                    if (int.Parse(txtHonshaShukko.Text) > 0) {
                        A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                        try
                        {
                            DataTable dtZaiko = juchuB.getZaiko("0001", txtShohinCd.Text);

                            if (dtZaiko != null && dtZaiko.Rows.Count > 0 && int.Parse(dtZaiko.Rows[0]["在庫数"].ToString()) > 0)
                            {
                                if (int.Parse(dtZaiko.Rows[0]["在庫数"].ToString()) >= int.Parse(txtHonshaShukko.Text))
                                {
                                    dtZaiko = juchuB.getZaiko(null, txtShohinCd.Text);

                                    int zaikoF = 0;
                                    for (int i = 0; i < dtZaiko.Rows.Count; i++)
                                    {
                                        zaikoF += int.Parse(dtZaiko.Rows[i]["フリー在庫数"].ToString());
                                    }

                                    if (string.IsNullOrWhiteSpace(txtJuchuNo.Text) || txtEigyoshoCd.Equals("0002"))
                                    {
                                        if (int.Parse(txtHonshaShukko.Text) > zaikoF)
                                        {
                                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "本社出庫数がフリー在庫数（本社）を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                            basemessagebox.ShowDialog();
                                            txtHonshaShukko.Focus();
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        if (int.Parse(txtHonshaShukko.Text) > zaikoF + int.Parse(txtJuchuSuryo.Text) - int.Parse(txtHatchusu.Text))
                                        {
                                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "本社出庫数がフリー在庫数（本社）を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                            basemessagebox.ShowDialog();
                                            txtHonshaShukko.Focus();
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "本社出庫数が在庫数（本社）を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                    basemessagebox.ShowDialog();
                                    txtHonshaShukko.Focus();
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            new CommonException(ex);
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            return false;
                        }
                    }

                    if (int.Parse(txtGihuShukko.Text) > 0)
                    {
                        A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                        try
                        {
                            DataTable dtZaiko = juchuB.getZaiko("0002", txtShohinCd.Text);

                            if (dtZaiko != null && dtZaiko.Rows.Count > 0 && int.Parse(dtZaiko.Rows[0]["在庫数"].ToString()) > 0)
                            {
                                if (int.Parse(dtZaiko.Rows[0]["在庫数"].ToString()) >= int.Parse(txtHonshaShukko.Text))
                                {
                                    dtZaiko = juchuB.getZaiko(null, txtShohinCd.Text);

                                    int zaikoF = 0;
                                    for (int i = 0; i < dtZaiko.Rows.Count; i++)
                                    {
                                        zaikoF += int.Parse(dtZaiko.Rows[i]["フリー在庫数"].ToString());
                                    }

                                    if (string.IsNullOrWhiteSpace(txtJuchuNo.Text) || txtEigyoshoCd.Equals("0001"))
                                    {
                                        if (int.Parse(txtGihuShukko.Text) > zaikoF)
                                        {
                                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "本社出庫数がフリー在庫数（岐阜）を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                            basemessagebox.ShowDialog();
                                            txtGihuShukko.Focus();
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        if (int.Parse(txtGihuShukko.Text) > zaikoF + int.Parse(txtJuchuSuryo.Text) - int.Parse(txtHatchusu.Text))
                                        {
                                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "本社出庫数がフリー在庫数（岐阜）を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                            basemessagebox.ShowDialog();
                                            txtGihuShukko.Focus();
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "本社出庫数が在庫数（岐阜）を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                    basemessagebox.ShowDialog();
                                    txtGihuShukko.Focus();
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            new CommonException(ex);
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            return false;
                        }
                    }

                    if (int.Parse(txtHonshaShukko.Text) > 0 && int.Parse(txtGihuShukko.Text) > 0)
                    {
                        A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                        try
                        {
                            DataTable dtZaiko = juchuB.getZaiko(null, txtShohinCd.Text);

                            if (dtZaiko != null && dtZaiko.Rows.Count > 1 && int.Parse(dtZaiko.Rows[0]["在庫数"].ToString()) > 0 && int.Parse(dtZaiko.Rows[1]["在庫数"].ToString()) > 0)
                            {
                                int zaikoF = 0;
                                for (int i = 0; i < dtZaiko.Rows.Count; i++)
                                {
                                    zaikoF += int.Parse(dtZaiko.Rows[i]["フリー在庫数"].ToString());
                                }

                                if (string.IsNullOrWhiteSpace(txtJuchuNo.Text))
                                {
                                    if ((int.Parse(txtHonshaShukko.Text) + int.Parse(txtGihuShukko.Text)) > zaikoF)
                                    {
                                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "本社・岐阜出庫数がフリー在庫合計数を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                        basemessagebox.ShowDialog();
                                        txtHonshaShukko.Focus();
                                        return false;
                                    }
                                }
                                else
                                {
                                    if ((int.Parse(txtHonshaShukko.Text) + int.Parse(txtGihuShukko.Text)) > zaikoF + int.Parse(txtJuchuSuryo.Text) - int.Parse(txtHatchusu.Text))
                                    {
                                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "本社・岐阜出庫数がフリー在庫合計数を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                        basemessagebox.ShowDialog();
                                        txtHonshaShukko.Focus();
                                        return false;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            new CommonException(ex);
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            return false;
                        }
                    }
                }
            }
            //}

            int intRiekiFlg = 0;

            intRiekiFlg = judRiekiritsu();

            if (intRiekiFlg == 0)
            {
                bool blKokohin = false;
                double dblRitsu = 0;
                string strRitsuMsg = "";
                decimal decTotal = Decimal.Parse(cbJuchuTanka.Text) * Decimal.Parse(txtJuchuSuryo.Text);

                if (blKokohin)
                {
                    if (decTotal <= 2000)
                    {
                        dblRitsu = 0.5;
                        strRitsuMsg = "利益率が５０％を割っています。（販売価格\\2000以下）\r\n続行しますか？";
                    }
                    else
                    {
                        dblRitsu = 0.75;
                        strRitsuMsg = "利益率が２５％を割っています。\r\n続行しますか？";
                    }
                }
                else
                {
                    dblRitsu = 0.85;
                    strRitsuMsg = "利益率が１５％を割っています。\r\n続行しますか？";
                }

                //if ()
                //{
                bool blRieki10 = true;

                if (blRieki10)
                {
                    if (Math.Abs(Double.Parse(cbJuchuTanka.Text)) < Math.Abs(Double.Parse(cbSiireTanka.Text)) / dblRitsu)
                    {
                        BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "利益率", strRitsuMsg, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                        //NOが押された場合
                        if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                        {
                            return false;
                        }
                    }
                }

                //}
            }
            else if (intRiekiFlg == 1)
            {

            }
            else if (intRiekiFlg == 2)
            {
                return false;
            }

            return true;

        }

        private int judRiekiritsu ()
        {
            int ret = 0;

            int intShiire = 0;
            if (cbSiireTanka.Text != null)
            {
                intShiire = int.Parse(cbSiireTanka.Text);
            }
            int intRitsu = (Math.Abs(int.Parse(cbJuchuTanka.Text)) - intShiire) / Math.Abs(int.Parse(cbJuchuTanka.Text)) * 100;

            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dtRieki = juchuB.getRiekiritsu(tsTokuisaki.CodeTxtText, txtShohinCd.Text, null, null, null);

                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (intRitsu < int.Parse(dtRieki.Rows[0]["利益率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "利益率", "利益率を割っています。\r\n(設定利益率=" + dtRieki.Rows[0]["利益率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }

                    if (dtRieki.Rows[0]["単価"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["単価"].ToString()))
                    {
                        if (int.Parse(cbJuchuTanka.Text) < int.Parse(dtRieki.Rows[0]["単価"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "単価", "設定単価を下回っています。\r\n(設定単価=" + dtRieki.Rows[0]["単価"].ToString() + "円)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }
                    return ret;
                }

                DataTable dtCodes = juchuB.getCodesFromShohin(txtShohinCd.Text);

                if (dtCodes != null && dtCodes.Rows.Count > 0)
                {
                    return ret;
                }

                string strDaibunrui = dtCodes.Rows[0]["大分類コード"].ToString();
                string strChubunrui = dtCodes.Rows[0]["中分類コード"].ToString();
                string strMaker = dtCodes.Rows[0]["メーカーコード"].ToString();

                dtRieki = juchuB.getRiekiritsu(tsTokuisaki.CodeTxtText, txtShohinCd.Text, strDaibunrui, strChubunrui, strMaker);

                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (intRitsu < int.Parse(dtRieki.Rows[0]["利益率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "利益率", "利益率を割っています。\r\n(設定利益率=" + dtRieki.Rows[0]["利益率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }

                    if (dtRieki.Rows[0]["掛率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["掛率"].ToString()))
                    {
                        if (int.Parse(txtJuchuTankaSub.Text) < int.Parse(dtRieki.Rows[0]["掛率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "掛率", "設定掛率を下回っています。\r\n(設定掛率=" + dtRieki.Rows[0]["掛率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }
                    return ret;
                }

                dtRieki = juchuB.getRiekiritsu(tsTokuisaki.CodeTxtText, txtShohinCd.Text, strDaibunrui, strChubunrui, null);

                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (intRitsu < int.Parse(dtRieki.Rows[0]["利益率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "利益率", "利益率を割っています。\r\n(設定利益率=" + dtRieki.Rows[0]["利益率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }

                    if (dtRieki.Rows[0]["掛率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["掛率"].ToString()))
                    {
                        if (int.Parse(txtJuchuTankaSub.Text) < int.Parse(dtRieki.Rows[0]["掛率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "掛率", "設定掛率を下回っています。\r\n(設定掛率=" + dtRieki.Rows[0]["掛率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }
                    return ret;
                }

                dtRieki = juchuB.getRiekiritsu(tsTokuisaki.CodeTxtText, txtShohinCd.Text, strDaibunrui, null, strMaker);

                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (intRitsu < int.Parse(dtRieki.Rows[0]["利益率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "利益率", "利益率を割っています。\r\n(設定利益率=" + dtRieki.Rows[0]["利益率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }

                    if (dtRieki.Rows[0]["掛率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["掛率"].ToString()))
                    {
                        if (int.Parse(txtJuchuTankaSub.Text) < int.Parse(dtRieki.Rows[0]["掛率"].ToString()))
                        {
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "掛率", "設定掛率を下回っています。\r\n(設定掛率=" + dtRieki.Rows[0]["掛率"].ToString() + "％)\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return 2;
                            }
                        }
                    }
                    return ret;
                }

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                throw ex;
            }

            return ret;
        }

        private void clearInput()
        {
            btnF01.Enabled = true;
            btnF03.Enabled = true;
            btnF08.Enabled = true;
            btnF09.Enabled = true;

            txtJuchuYMD.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtJuchuNo.Text = "";
            tsTokuisaki.CodeTxtText = "";
            tsTokuisaki.valueTextText = "";
            lsDaibunrui.CodeTxtText = "";
            lsChubunrui.CodeTxtText = "";
            lsMaker.CodeTxtText = "";
            txtShohinCd.Text = "";
            txtHinmei.Text = "";
            txtC1.Text = "";
            txtC2.Text = "";
            txtC3.Text = "";
            txtC4.Text = "";
            txtC5.Text = "";
            txtC6.Text = "";
            cbJuchuTanka.Text = "";
            cbSiireTanka.Text = "";
            txtNoki.Text = "";
            txtChuban.Text = "";
            gridJuchuZanMeisai.Rows.Clear();
            txtSearchStr.Text = "";
            txtTantosha.Text = "";
            txtHatchushiji.Text = "";
            txtHonshaShukko.Text = "";
            txtGihuShukko.Text = "";
            txtHatchuNo.Text = "";
            tsShiiresaki.CodeTxtText = "";
            tsShiiresaki.valueTextText = "";
            cbChuban.Checked = false;
            lblGrayTanaHon.Text = "";
            lblGrayTanaSub.Text = "";
            txtTeika.Text = "";
            txtJuchuTankaSub.Text = "";
            txtSiireTankaSub.Text = "";
            txtUriSuryo.Text = "";

            txtJuchuNo.Enabled = true;
            txtJuchuYMD.Enabled = true;
            lsJuchusha.Enabled = true;
            tsTokuisaki.Enabled = true;
            lsDaibunrui.Enabled = true;
            lsChubunrui.Enabled = true;
            lsMaker.Enabled = true;
            txtSearchStr.Enabled = true;
            txtJuchuSuryo.Enabled = true;
            cbJuchuTanka.Enabled = true;
            cbSiireTanka.Enabled = true;
            txtHatchushiji.Enabled = true;
            txtHonshaShukko.Enabled = true;
            txtGihuShukko.Enabled = true;
            txtHatchusu.Enabled = true;
            txtChuban.Enabled = true;
            tsShiiresaki.Enabled = true;
            txtShiireChuban.Enabled = true;

            lsJuchusha.Focus();
        }

        private void clearInput2()
        {
            btnF01.Enabled = true;
            btnF03.Enabled = true;
            btnF08.Enabled = true;
            btnF09.Enabled = true;

            txtJuchuYMD.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtJuchuNo.Text = "";
            tsTokuisaki.CodeTxtText = "";
            tsTokuisaki.valueTextText = "";
            lsDaibunrui.CodeTxtText = "";
            lsChubunrui.CodeTxtText = "";
            lsMaker.CodeTxtText = "";
            txtShohinCd.Text = "";
            txtHinmei.Text = "";
            txtC1.Text = "";
            txtC2.Text = "";
            txtC3.Text = "";
            txtC4.Text = "";
            txtC5.Text = "";
            txtC6.Text = "";
            cbJuchuTanka.Text = "";
            cbSiireTanka.Text = "";
            txtNoki.Text = "";
            txtChuban.Text = "";
            gridJuchuZanMeisai.Rows.Clear();
            txtSearchStr.Text = "";
            txtHatchushiji.Text = "";
            txtHonshaShukko.Text = "";
            txtGihuShukko.Text = "";
            txtHatchuNo.Text = "";
            tsShiiresaki.CodeTxtText = "";
            tsShiiresaki.valueTextText = "";
            txtShiireChuban.Text = "";
            txtHatchusu.Text = "";
            txtFreeZaiko.Text = "";
            txtShukkaShiji.Text = "";
            txtZaikoHikiate.Text = "";
            txtUriage.Text = "";
            lblGrayTanaHon.Text = "";
            lblGrayTanaSub.Text = "";
            txtTeika.Text = "";
            txtJuchuTankaSub.Text = "";
            cbKinShiireTanka.Text = "";
            txtKinSiireTankaSub.Text = "";

            txtJuchuYMD.Enabled = true;
            lsJuchusha.Enabled = true;
            tsTokuisaki.Enabled = true;
            lsDaibunrui.Enabled = true;
            lsChubunrui.Enabled = true;
            lsMaker.Enabled = true;
            txtSearchStr.Enabled = true;
            txtJuchuSuryo.Enabled = true;
            cbJuchuTanka.Enabled = true;
            cbSiireTanka.Enabled = true;
            txtHatchushiji.Enabled = true;
            txtHonshaShukko.Enabled = true;
            txtGihuShukko.Enabled = true;
            txtHatchusu.Enabled = true;
            txtChuban.Enabled = true;
            tsShiiresaki.Enabled = true;
            txtShiireChuban.Enabled = true;
        }

        private void getZaikoInfo ()
        {
            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dtZan = juchuB.getZaikoInfo(txtShohinCd.Text);
                gridZaiko.DataSource = dtZan;
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void tsTokuisaki_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tsTokuisaki.CodeTxtText))
            {
                return;
            }

            getJuchuZanInfo();
            if (tsTokuisaki.CodeTxtText.Equals("6666") || tsTokuisaki.CodeTxtText.Equals("7777") || tsTokuisaki.CodeTxtText.Equals("8888"))
            {
                tsTokuisaki.ReadOnlyANDTabStopFlg = false;
            }
            else
            {
                tsTokuisaki.ReadOnlyANDTabStopFlg = true;
            }
        }

        private void getJuchuZanInfo()
        {
            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dtJuchuZan = juchuB.getJuchuZanInfo(txtShohinCd.Text);
                gridJuchuZanMeisai.DataSource = dtJuchuZan;
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void txtSearchStr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F9)
            {
                if (string.IsNullOrWhiteSpace(txtSearchStr.Text))
                {
                    return;
                }
                showShohinList();
            }
        }

        private bool chkDigit(string s)
        {
            Decimal d = 0;
            bool b = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    if (Decimal.TryParse(s, out d))
                    {
                        b = true;
                    }
                }
            }
            catch (Exception ex) { }

            return b;
        }

        private void txtHatchuNo_Leave(object sender, EventArgs e)
        {
            getHatchuInfo();
        }
        private void getHatchuInfo() {
            if (txtHatchuNo.Text == null || string.IsNullOrWhiteSpace(txtHatchuNo.Text))
            {
                return;
            }

            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dtHatchu = juchuB.getHatchuData(txtHatchuNo.Text);

                if (dtHatchu != null && dtHatchu.Rows.Count > 0)
                {
                    txtHatchusu.Text = dtHatchu.Rows[0]["発注数量"].ToString();
                    tsShiiresaki.CodeTxtText = dtHatchu.Rows[0]["仕入先コード"].ToString();
                    txtShiireNoki.Text = dtHatchu.Rows[0]["納期"].ToString();
                    txtShiireChuban.Text = dtHatchu.Rows[0]["注番"].ToString();
                    txtShiireTanto.Text = dtHatchu.Rows[0]["担当者コード"].ToString();
                    tsShiiresaki.valueTextText = dtHatchu.Rows[0]["仕入先名称"].ToString();
                }

            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

    }
}
