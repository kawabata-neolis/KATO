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
            juchzanUke.DataPropertyName = "発注残(受)";
            juchzanUke.Name = "発注残(受)";
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
                    //this.addHachu();
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
            int uriageSu = 0;

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
                uriageSu = juchuB.getUriagezumisuryo(strJuchuNo);
                if (uriageSu > 0)
                {
                    BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "すでに売上済みです。削除できません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessageboxEr.ShowDialog();
                    return;
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
            txtJuchuYMD.Enabled = true;
            lsJuchusha.Enabled = true;
            txtJuchuNo.Enabled = true;
            tsTokuisaki.Enabled = true;
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
            txtShiireTanto.Enabled = true;
            txtShiireChuban.Enabled = true;

            lsDaibunrui.Enabled = false;
            lsChubunrui.Enabled = false;
            lsMaker.Enabled = false;

            txtJuchuNo.Text = "";
            txtHatchuNo.Text = "";

            if (gridJuchuZanMeisai.CurrentRow.Cells[0] != null)
            {
                txtJuchuNo.Text = (gridJuchuZanMeisai.CurrentRow.Cells[0]).ToString();
            }
        }

        private void showShohinList()
        {
            KATO.Common.Form.ShouhinList shohinList = new KATO.Common.Form.ShouhinList(this);
            
            if (!String.IsNullOrWhiteSpace(lsDaibunrui.CodeTxtText))
            {
                shohinList.strDaibunruiCode = lsDaibunrui.CodeTxtText;
            }

            if (!String.IsNullOrWhiteSpace(lsChubunrui.CodeTxtText))
            {
                shohinList.strChubunruiCode = lsChubunrui.CodeTxtText;
            }

            if (!String.IsNullOrWhiteSpace(lsMaker.CodeTxtText))
            {
                shohinList.strMakerCode = lsMaker.CodeTxtText;
            }

            if (!String.IsNullOrWhiteSpace(txtSearchStr.Text))
            {
                shohinList.strKensaku = txtSearchStr.Text;
            }

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


        //
        // 検索文字列フォーカスアウト時
        //
        private void txtSearchStr_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchStr.Text))
            {
                return;
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

            }else
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
            } else
            {
                tsShiiresaki.ReadOnlyANDTabStopFlg = true;
            }
        }

        private void txtJuchuNo_Leave(object sender, EventArgs e)
        {
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
                    txtChuban.Text = (dtJuchuNoInfo.Rows[0]["納期"].ToString()).Trim();
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
                        + txtC1.Text.Trim() + " "
                        + txtC1.Text.Trim() + " "
                        + txtC1.Text.Trim() + " "
                        + txtC1.Text.Trim() + " "
                        + txtC1.Text.Trim();
                    txtHinmei.Text = strHinmei.Trim();

                    txtJuchuSuryo.Enabled = true;
                    cbJuchuTanka.Enabled = true;
                    cbSiireTanka.Enabled = true;
                    txtNoki.Enabled = true;

                    if (txtShohinCd.Text.Equals("88888"))
                    {
                        lsDaibunrui.Enabled = true;
                        lsChubunrui.Enabled = true;
                        lsMaker.Enabled = true;
                    }
                    else
                    {
                        lsDaibunrui.Enabled = false;
                        lsChubunrui.Enabled = false;
                        lsMaker.Enabled = false;
                        txtHinmei.Enabled = false;
                    }

                    DataTable dtHatchuNo = juchuInput.getHatchuNoInfo(strCd);
                    if (!string.IsNullOrWhiteSpace(dtHatchuNo.Rows[0]["発注番号"].ToString()))
                    {
                        txtHatchuNo.Text = dtHatchuNo.Rows[0]["発注番号"].ToString();
                    }
                    else
                    {
                        txtHatchusu.Text = "0";
                    }

                    int intUriSuryo   = (int)dtJuchuNoInfo.Rows[0]["売上済数量"];
                    int intjuchuSuryo = (int)dtJuchuNoInfo.Rows[0]["受注数量"];
                    if (intUriSuryo == 0)
                    {
                        lockFlg = false;
                    }
                    else if (intUriSuryo == intjuchuSuryo)
                    {
                        btnF01.Enabled = false;
                        btnF03.Enabled = false;
                        btnF08.Enabled = false;
                        btnF09.Enabled = false;
                        BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "売上済の受注です。変更は不可です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessageboxEr.ShowDialog();
                        return;
                    }
                    else if (intUriSuryo > 0)
                    {
                        txtUriSuryo.Text = intUriSuryo.ToString();
                        txtJuchuNo.Enabled = false;
                        txtJuchuYMD.Enabled = false;

                        if (powerUserFlg)
                        {
                            lsJuchusha.Enabled = true;
                            cbJuchuTanka.Enabled = true;
                        }
                        else
                        {
                            lsJuchusha.Enabled = false;
                            cbJuchuTanka.Enabled = false;
                        }
                        tsTokuisaki.Enabled = false;
                        lsDaibunrui.Enabled = false;
                        lsChubunrui.Enabled = false;
                        lsMaker.Enabled = false;
                        txtSearchStr.Enabled = false;
                        txtHinmei.Enabled = false;
                        txtJuchuSuryo.Enabled = false;

                        cbSiireTanka.Enabled = false;
                        txtHatchushiji.Enabled = false;
                        txtHonshaShukko.Enabled = false;
                        txtGihuShukko.Enabled = false;
                        txtHatchusu.Enabled = false;
                        tsShiiresaki.Enabled = false;
                        txtShiireChuban.Enabled = false;

                        if (dtHatchuNo != null && dtHatchuNo.Rows.Count > 0) {
                            int intShiireSuryo = (int)dtHatchuNo.Rows[0]["仕入済数量"];

                            if (intUriSuryo == intShiireSuryo)
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
                        int intShiireSuryo = (int)dtHatchuNo.Rows[0]["仕入済数量"];

                        if (intShiireSuryo > 0)
                        {
                            BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "分納で売上済みです。納期・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                            basemessageboxEr.ShowDialog();

                            txtJuchuNo.Enabled = false;
                            txtJuchuYMD.Enabled = false;

                            if (powerUserFlg)
                            {
                                lsJuchusha.Enabled = true;
                                cbJuchuTanka.Enabled = true;
                            }
                            else
                            {
                                lsJuchusha.Enabled = false;
                                cbJuchuTanka.Enabled = false;
                            }
                            tsTokuisaki.Enabled = false;
                            txtSearchStr.Enabled = false;
                            txtHinmei.Enabled = false;
                            txtJuchuSuryo.Enabled = false;

                            cbSiireTanka.Enabled = false;
                            txtHatchushiji.Enabled = false;
                            txtHonshaShukko.Enabled = false;
                            txtGihuShukko.Enabled = false;
                            txtHatchusu.Enabled = false;
                            tsShiiresaki.Enabled = false;
                            txtShiireChuban.Enabled = false;

                        }
                        else
                        {
                            txtJuchuNo.Enabled = true;
                            txtJuchuYMD.Enabled = true;

                            lsJuchusha.Enabled = true;
                            cbJuchuTanka.Enabled = true;
                            tsTokuisaki.Enabled = true;
                            txtSearchStr.Enabled = true;
                            txtJuchuSuryo.Enabled = true;

                            cbSiireTanka.Enabled = true;
                            txtHatchushiji.Enabled = true;
                            txtHonshaShukko.Enabled = true;
                            txtGihuShukko.Enabled = true;
                            txtChuban.Enabled = true;

                            txtHatchusu.Enabled = true;
                            tsShiiresaki.Enabled = true;
                            txtShiireChuban.Enabled = true;

                        }
                    }
                    else
                    {
                        txtJuchuNo.Enabled = true;
                        txtJuchuYMD.Enabled = true;

                        lsJuchusha.Enabled = true;
                        cbJuchuTanka.Enabled = true;
                        tsTokuisaki.Enabled = true;
                        txtSearchStr.Enabled = true;
                        txtJuchuSuryo.Enabled = true;

                        cbSiireTanka.Enabled = true;
                        txtHatchushiji.Enabled = true;
                        txtHonshaShukko.Enabled = true;
                        txtGihuShukko.Enabled = true;
                        txtChuban.Enabled = true;

                        txtHatchusu.Enabled = true;
                        tsShiiresaki.Enabled = true;
                        txtShiireChuban.Enabled = true;
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
            if (e.KeyCode == Keys.F9)
            {
                //
                if (tsTokuisaki.CodeTxtText == null || string.IsNullOrWhiteSpace(tsTokuisaki.CodeTxtText))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "取引先コードを指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                D0360_JuchuzanKakunin.D0360_JuchuzanKakunin juchuZan = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this, tsTokuisaki.CodeTxtText);
                juchuZan.ShowDialog();
            }
        }

        private void txtHatchuNo_TextChanged(object sender, EventArgs e)
        {
            if (txtHatchuNo.Text == null || string.IsNullOrWhiteSpace(txtHatchuNo.Text))
            {
                return;
            }

            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try {
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

            } catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void cbJuchuTanka_SelectedIndexChanged(object sender, EventArgs e)
        {
            updKakeritsu();
        }

        private void cbJuchuTanka_Leave(object sender, EventArgs e)
        {

        }

        private void updKakeritsu()
        {
            if (lsDaibunrui.CodeTxtText.Equals("28") && lsChubunrui.CodeTxtText.Equals("04"))
            {
                cbSiireTanka.Text = cbJuchuTanka.Text;
            }
            // 定価が未設定の場合、掛率を計算しない
            if (string.IsNullOrEmpty(txtTeika.Text) || int.Parse(txtTeika.Text) == 0)
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
            txtJuchuTankaSub.Text = (int.Parse(strNumerator) / int.Parse(txtTeika.Text)).ToString();

            if (string.IsNullOrEmpty(cbSiireTanka.Text))
            {
                strNumerator = "0";
            }
            else
            {
                strNumerator = cbSiireTanka.Text;
            }
            txtSiireTankaSub.Text = (int.Parse(strNumerator) / int.Parse(txtTeika.Text)).ToString();

            if (string.IsNullOrEmpty(txtKinSiireTanka.Text))
            {
                strNumerator = "0";
            }
            else
            {
                strNumerator = txtKinSiireTanka.Text;
            }
            txtKinSiireTankaSub.Text = (int.Parse(strNumerator) / int.Parse(txtTeika.Text)).ToString();

        }

        // 在庫一覧表示
        private void execZaikoDisp()
        {

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

        }
    }
}
