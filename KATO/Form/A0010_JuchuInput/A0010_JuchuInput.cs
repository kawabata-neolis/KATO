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
using KATO.Form.D0310_UriageJissekiKakunin;

namespace KATO.Form.A0010_JuchuInput
{
    public partial class A0010_JuchuInput : KATO.Common.Ctl.BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        bool lockFlg = false;
        bool nokiFlg = false;
        bool kyouseiFlg = false;

        bool acceptFlg = false;

        decimal dSearchSu = 0;
        decimal dSearchSuH = 0;
        string defaultUser = "";
        string defaultEigyo = "";

        bool editLock = false;

        public Form6 f6 = null;
        D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin uriKakunin = null;

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

            panel1.Visible = false;
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
                    defaultUser = lsJuchusha.CodeTxtText;
                    defaultEigyo = txtEigyoshoCd.Text;
                }
                lsJuchusha.codeTxt.Focus();
                lsJuchusha.Leave += new EventHandler(lsJuchusha_Leave);
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

            tsTokuisaki.codeTxt.Leave += new EventHandler(tsTokuisaki_Leave);
            txtJuchuYMD.Text = DateTime.Now.ToString("yyyy/MM/dd");

            cmbSubWinShow.Items.Add("売上実績確認");
            cmbSubWinShow.Items.Add("加工品受注入力");
            cmbSubWinShow.Items.Add("見積書入力");
        }

        private void lsJuchusha_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lsJuchusha.CodeTxtText))
            {
                return;
            }
            A0010_JuchuInput_B juchuInput = new A0010_JuchuInput_B();
            try
            {
                DataTable dt = juchuInput.getUserInfoFromCd(lsJuchusha.CodeTxtText);

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtEigyoshoCd.Text = dt.Rows[0]["営業所コード"].ToString();
                }
                if (!"0001".Equals(txtEigyoshoCd.Text) && !"0002".Equals(txtEigyoshoCd.Text))
                {
                    txtEigyoshoCd.Text = "0001";
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
            juchuNo.Visible = false;

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
                    if (btnF01.Enabled)
                    {
                        if (!editLock) {
                            logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                            editLock = true;
                            this.addJuchu();
                            editLock = false;
                        }
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    if (btnF03.Enabled)
                    {
                        if (!editLock)
                        {
                            logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                            editLock = true;
                            this.delJuchu();
                            editLock = false;
                        }
                    }
                    break;
                case Keys.F4:
                    if (btnF04.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                        clearInput2();
                    }
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    //if (btnF08.Enabled) {
                    //    logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));

                    //    uriKakunin = new D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, 1, tsTokuisaki.CodeTxtText, txtShohinCd.Text);

                    //    Screen s = null;
                    //    Screen[] argScreen = Screen.AllScreens;
                    //    if (argScreen.Length > 1)
                    //    {
                    //        s = argScreen[1];
                    //    }
                    //    else
                    //    {
                    //        s = argScreen[0];
                    //    }

                    //    uriKakunin.StartPosition = FormStartPosition.Manual;
                    //    uriKakunin.Location = s.Bounds.Location;

                    //    uriKakunin.Show();
                    //    //uriKakunin.Dispose();
                    //}
                    break;
                case Keys.F9:
                    if (btnF09.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    }
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    if (uriKakunin != null)
                    {
                        uriKakunin.Close();
                        uriKakunin.Dispose();
                    }
                    if (f6 != null)
                    {
                        f6.Close();
                        f6.Dispose();
                    }
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
                    if (btnF01.Enabled)
                    {
                        if (!editLock)
                        {
                            logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                            editLock = true;
                            this.addJuchu();
                            editLock = false;
                        }
                    }
                    break;
                case STR_BTN_F03: // 削除
                    if (btnF03.Enabled)
                    {
                        if (!editLock)
                        {
                            logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                            editLock = true;
                            this.delJuchu();
                            editLock = false;
                        }
                    }
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    clearInput2();
                    break;
                case STR_BTN_F08: // 履歴
                    //logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));

                    //uriKakunin = new D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, 1, tsTokuisaki.CodeTxtText, txtShohinCd.Text);

                    //Screen s = null;
                    //Screen[] argScreen = Screen.AllScreens;
                    //if (argScreen.Length > 1)
                    //{
                    //    s = argScreen[1];
                    //}
                    //else
                    //{
                    //    s = argScreen[0];
                    //}

                    //uriKakunin.StartPosition = FormStartPosition.Manual;
                    //uriKakunin.Location = s.Bounds.Location;

                    //uriKakunin.Show();
                    ////uriKakunin.Dispose();

                    break;
                case STR_BTN_F09: // 履歴
                    if (btnF09.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    }
                    break;
                case STR_BTN_F12: // 終了
                    if (uriKakunin != null)
                    {
                        uriKakunin.Close();
                        uriKakunin.Dispose();
                    }
                    if (f6 != null)
                    {
                        f6.Close();
                        f6.Dispose();
                    }
                    this.Close();
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

            DBConnective con = new DBConnective();
            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();

            try
            {
                // 売上済がある場合、削除不可
                DataTable dt = juchuB.getUriagezumisuryo(strJuchuNo);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (chkDigit(dt.Rows[0]["売上済数量"].ToString())) {
                        uriageSu = decimal.Parse(dt.Rows[0]["売上済数量"].ToString());
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
                DataTable dtHachu = juchuB.getHatchuNoInfo(strJuchuNo);
                con.BeginTrans();
                juchuB.delJuchu(strJuchuNo, lblStatusUser.Text,con);
                // 受発注の在庫数を変更
                //juchuB.updZaiko(true, txtEigyoshoCd.Text, txtShohinCd.Text, (dSearchSu).ToString(), con);
                //juchuB.updZaiko(false, txtEigyoshoCd.Text, txtShohinCd.Text, (dSearchSuH).ToString(),con);
                juchuB.updZaiko(txtShohinCd.Text, txtEigyoshoCd.Text, txtNoki.Text, Environment.UserName, con);

                if (dtHachu != null && dtHachu.Rows.Count > 0)
                {
                    juchuB.updZaiko(txtShohinCd.Text, txtEigyoshoCd.Text, dtHachu.Rows[0]["発注年月日"].ToString(), Environment.UserName, con);
                }

                //juchuB.updZaiko(true, txtEigyoshoCd.Text, txtShohinCd.Text, dSearchSu.ToString());

                //// デッドストック在庫を使用していた場合は、再度デッドストックとして戻す
                //if (!String.IsNullOrWhiteSpace(txtDeadStockNo.Text))
                //{
                //    juchuB.restoreDeadStock(txtDeadStockNo.Text);
                //}

                con.Commit();
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                clearInput();
            }
            catch (Exception ex)
            {
                con.Rollback();
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
            //txtJuchuNo.ReadOnly = false;
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
                txtJuchuNo.Text = (gridJuchuZanMeisai.CurrentRow.Cells[0].Value).ToString();
                getJuchuInfo();
            }
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

        private void showShohinList()
        {
            KATO.Common.Form.ShouhinList shohinList = new KATO.Common.Form.ShouhinList(this);
            shohinList.intFrmKind = CommonTeisu.FRM_JUCHUINPUT;
            shohinList.blKensaku = false;
            shohinList.lsDaibunrui = lsDaibunrui;
            shohinList.lsChubunrui = lsChubunrui;
            shohinList.lsMaker = lsMaker;
            shohinList.btxtKensaku = txtSearchStr;
            shohinList.btxtShohinCd = txtShohinCd;
            shohinList.btxtHinC1Hinban = txtHinmei;

            if (!String.IsNullOrWhiteSpace(lsDaibunrui.CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(lsChubunrui.CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(lsMaker.CodeTxtText))
            {
                shohinList.blKensaku = true;
            }

            if (!String.IsNullOrWhiteSpace(txtSearchStr.Text))
            {
                shohinList.blKensaku = true;
            }
            
            shohinList.ShowDialog();
            txtSearchStr.Text = "";
            txtHatchuNo.ReadOnly = true;
            shohinList.Dispose();
            getShohinInfo();

            //if (!string.IsNullOrWhiteSpace(txtShohinCd.Text))
            //{
            //    txtJuchuNo.Focus();
            //}
            //else
            //{
            //    txtSearchStr.Focus();
            //}
            txtJuchuSuryo.Focus();
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
            if (f6 == null || !f6.Visible) {
                getJuchuInfo();
            }
        }

        // 受注情報検索
        private void getJuchuInfo() {
            string strCd = txtJuchuNo.Text;
            bool selKakoFlg = false;

            lockFlg = true;

            try
            {
                if (string.IsNullOrWhiteSpace(strCd))
                {
                    return;
                }

                A0010_JuchuInput_B juchuInput = new A0010_JuchuInput_B();

                selKakoFlg = juchuInput.judKakohinJuchu(strCd);

                if (selKakoFlg)
                {
                    panel1.Visible = false;
                    //BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "加工品の受注です。加工品受注画面で修正してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    //basemessageboxEr.ShowDialog();

                    lblHonshaShukko.Visible = false;
                    lblGihuShukko.Visible = false;
                    lblHatchusu.Visible = false;
                    txtHonshaShukko.Visible = false;
                    txtGihuShukko.Visible = false;
                    txtHatchusu.Visible = false;
                    //return;
                }
                else
                {
                    lblHonshaShukko.Visible = true;
                    lblGihuShukko.Visible = true;
                    lblHatchusu.Visible = true;
                    txtHonshaShukko.Visible = true;
                    txtGihuShukko.Visible = true;
                    txtHatchusu.Visible = true;
                }

                DataTable dtJuchuNoInfo = juchuInput.getJuchuNoInfo(strCd);

                if (dtJuchuNoInfo != null && dtJuchuNoInfo.Rows.Count > 0)
                {
                    txtJuchuYMD.Text = dtJuchuNoInfo.Rows[0]["受注年月日"].ToString();
                    lsJuchusha.CodeTxtText = dtJuchuNoInfo.Rows[0]["受注者コード"].ToString();
                    lsJuchusha.chkTxtTantosha();
                    tsTokuisaki.CodeTxtText = dtJuchuNoInfo.Rows[0]["得意先コード"].ToString();
                    lsDaibunrui.CodeTxtText = dtJuchuNoInfo.Rows[0]["大分類コード"].ToString();
                    lsDaibunrui.chkTxtDaibunrui();
                    lsChubunrui.CodeTxtText = dtJuchuNoInfo.Rows[0]["中分類コード"].ToString();
                    lsChubunrui.chkTxtChubunrui(lsDaibunrui.CodeTxtText);
                    lsMaker.CodeTxtText = dtJuchuNoInfo.Rows[0]["メーカーコード"].ToString();
                    lsMaker.chkTxtMaker();
                    txtC1.Text = dtJuchuNoInfo.Rows[0]["Ｃ１"].ToString();
                    txtC2.Text = dtJuchuNoInfo.Rows[0]["Ｃ２"].ToString();
                    txtC3.Text = dtJuchuNoInfo.Rows[0]["Ｃ３"].ToString();
                    txtC4.Text = dtJuchuNoInfo.Rows[0]["Ｃ４"].ToString();
                    txtC5.Text = dtJuchuNoInfo.Rows[0]["Ｃ５"].ToString();
                    txtC6.Text = dtJuchuNoInfo.Rows[0]["Ｃ６"].ToString();

                    decimal dJSu = 0;
                    if (dtJuchuNoInfo.Rows[0]["受注数量"] != null)
                    {
                        dJSu = getDecValue(dtJuchuNoInfo.Rows[0]["受注数量"].ToString());
                    }
                    txtJuchuSuryo.Text = (decimal.Round(dJSu, 0)).ToString();

                    dSearchSu = (decimal.Round(dJSu, 0));

                    decimal dJTanka = 0;
                    if (dtJuchuNoInfo.Rows[0]["受注単価"] != null)
                    {
                        dJTanka = getDecValue(dtJuchuNoInfo.Rows[0]["受注単価"].ToString());
                    }
                    cbJuchuTanka.Text = (decimal.Round(dJTanka, 0)).ToString();

                    decimal dSTanka = 0;
                    if (dtJuchuNoInfo.Rows[0]["仕入単価"] != null)
                    {
                        dSTanka = getDecValue(dtJuchuNoInfo.Rows[0]["仕入単価"].ToString());
                    }
                    cbSiireTanka.Text = (decimal.Round(dSTanka, 2, MidpointRounding.AwayFromZero)).ToString();

                    txtNoki.Text = dtJuchuNoInfo.Rows[0]["納期"].ToString();
                    txtChuban.Text = (dtJuchuNoInfo.Rows[0]["注番"].ToString()).Trim();
                    txtEigyoshoCd.Text = dtJuchuNoInfo.Rows[0]["営業所コード"].ToString();
                    txtTantosha.Text = dtJuchuNoInfo.Rows[0]["担当者コード"].ToString();
                    txtHatchushiji.Text = dtJuchuNoInfo.Rows[0]["発注指示区分"].ToString();
                    txtShohinCd.Text = dtJuchuNoInfo.Rows[0]["商品コード"].ToString();

                    decimal dHonSu = 0;
                    if (dtJuchuNoInfo.Rows[0]["本社出庫数"] != null)
                    {
                        dHonSu = getDecValue(dtJuchuNoInfo.Rows[0]["本社出庫数"].ToString());
                    }
                    txtHonshaShukko.Text = (decimal.Round(dHonSu, 0)).ToString();

                    decimal dGihSu = 0;
                    if (dtJuchuNoInfo.Rows[0]["岐阜出庫数"] != null)
                    {
                        dGihSu = getDecValue(dtJuchuNoInfo.Rows[0]["岐阜出庫数"].ToString());
                    }
                    txtGihuShukko.Text = (decimal.Round(dGihSu, 0)).ToString();

                    txtShukkaShiji.Text = dtJuchuNoInfo.Rows[0]["出荷指示区分"].ToString();
                    txtZaikoHikiate.Text = dtJuchuNoInfo.Rows[0]["在庫引当フラグ"].ToString();
                    txtUriage.Text = dtJuchuNoInfo.Rows[0]["売上フラグ"].ToString();

                    //string strHinmei = txtC1.Text.Trim() + " "
                    //    + txtC2.Text.Trim() + " "
                    //    + txtC3.Text.Trim() + " "
                    //    + txtC4.Text.Trim() + " "
                    //    + txtC5.Text.Trim() + " "
                    //    + txtC6.Text.Trim();
                    //txtHinmei.Text = strHinmei.Trim();
                    string strHinmei = txtC1.Text.Trim();
                    txtHinmei.Text = strHinmei;

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
                        lsDaibunrui.codeTxt.ReadOnly = true;
                        lsChubunrui.codeTxt.ReadOnly = true;
                        lsMaker.codeTxt.ReadOnly = true;
                        txtHinmei.ReadOnly = true;
                    }
                    getShohinInfo();

                    cbJuchuTanka.Text = (decimal.Round(dJTanka, 0)).ToString();
                    cbSiireTanka.Text = (decimal.Round(dSTanka, 2, MidpointRounding.AwayFromZero)).ToString();

                    DataTable dtHatchuNo = juchuInput.getHatchuNoInfo(strCd);
                    if (dtHatchuNo != null && dtHatchuNo.Rows.Count > 0) {
                        if (!string.IsNullOrWhiteSpace(dtHatchuNo.Rows[0]["発注番号"].ToString()) && !selKakoFlg)
                        {
                            txtHatchuNo.Text = dtHatchuNo.Rows[0]["発注番号"].ToString();
                            getHatchuInfo();
                        }
                        else
                        {
                            txtHatchusu.Text = "0";

                            panel1.Visible = false;
                            txtHatchushiji.Text = "0";
                            tsShiiresaki.CodeTxtText = "";
                            tsShiiresaki.valueTextText = "";
                            txtShiireNoki.Text = "";
                            txtShiireChuban.Text = "";
                            txtHatchuNo.Text = "";
                        }
                    }

                    decimal decUriSuryo = 0;
                    if (chkDigit(dtJuchuNoInfo.Rows[0]["売上済数量"].ToString()))
                    {
                        decUriSuryo = decimal.Parse(dtJuchuNoInfo.Rows[0]["売上済数量"].ToString());
                    }

                    decimal decJuchuSuryo = 0;
                    if (chkDigit(dtJuchuNoInfo.Rows[0]["受注数量"].ToString()))
                    {
                        decJuchuSuryo = decimal.Parse(dtJuchuNoInfo.Rows[0]["受注数量"].ToString());
                    }

                    if (decUriSuryo.Equals(0))
                    {
                        lockFlg = false;
                    }
                    else if (decUriSuryo.Equals(decJuchuSuryo))
                    {
                        btnF01.Enabled = false;
                        btnF03.Enabled = false;
                        btnF08.Enabled = false;
                        btnF09.Enabled = false;
                        BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "売上済の受注です。変更は不可です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessageboxEr.ShowDialog();
                        return;
                    }
                    else if (decUriSuryo.CompareTo(0) > 0)
                    {
                        txtUriSuryo.Text = decUriSuryo.ToString();
                        txtJuchuNo.ReadOnly = true;
                        txtJuchuYMD.ReadOnly = true;

                        if ("1".Equals(riekiritsuFlg))
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

                            if (decUriSuryo.Equals(decShiireSuryo))
                            {
                                nokiFlg = true;
                                txtJuchuSuryo.Enabled = true;
                                BaseMessageBox basemessageboxEr1 = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "分納で売上済みです。受注数・納期・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                                basemessageboxEr1.ShowDialog();
                                return;
                            }
                        }

                        nokiFlg = true;
                        BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "分納で売上済みです。納期・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        basemessageboxEr.ShowDialog();
                        //txtNoki.Focus();
                        return;
                    }

                    if (dtHatchuNo != null && dtHatchuNo.Rows.Count > 0)
                    {
                        decimal decShiireSuryo = 0;
                        if (chkDigit(dtHatchuNo.Rows[0]["仕入済数量"].ToString()))
                        {
                            decShiireSuryo = decimal.Parse(dtHatchuNo.Rows[0]["仕入済数量"].ToString());
                        }

                        if (decShiireSuryo > 0)
                        {
                            nokiFlg = true;
                            BaseMessageBox basemessageboxEr = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "すでに仕入済みです。納期・数量・注番のみ変更可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                            basemessageboxEr.ShowDialog();

                            txtJuchuNo.ReadOnly = true;
                            txtJuchuYMD.ReadOnly = true;

                            if ("1".Equals(riekiritsuFlg))
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
                        if (!string.IsNullOrWhiteSpace(txtHatchusu.Text) && decimal.Parse(txtHatchusu.Text).Equals(0))
                        {
                            cbSiireTanka.Enabled = false;
                        }
                    }
                }

                lockFlg = false;

                // 在庫呼び出し
                getZaikoInfo();

                if (f6 != null)
                {
                    f6.Close();
                    f6.Dispose();
                }

               // A0024_KakohinJuchuInput_B juchuB = new A0024_KakohinJuchuInput_B();

                //DataTable dtH = juchuB.getRireki(strCd);

                //if (dtH != null && dtH.Rows.Count > 0) {
                if (selKakoFlg) {
                    panel1.Visible = false;
                    lblHonshaShukko.Visible = false;
                    lblGihuShukko.Visible = false;
                    lblHatchusu.Visible = false;
                    txtHonshaShukko.Visible = false;
                    txtGihuShukko.Visible = false;
                    txtHatchusu.Visible = false;

                    f6 = new Form6(this);
                    f6.strJuchuNo = txtJuchuNo.Text;

                    Screen s = null;
                    Screen[] argScreen = Screen.AllScreens;
                    if (argScreen.Length > 1)
                    {
                        s = argScreen[1];
                    }
                    else
                    {
                        s = argScreen[0];
                    }

                    f6.StartPosition = FormStartPosition.Manual;
                    f6.Location = s.Bounds.Location;

                    f6.strEigyoCd = txtEigyoshoCd.Text;
                    f6.Show();
                }
                else
                {
                    lblHonshaShukko.Visible = true;
                    lblGihuShukko.Visible = true;
                    lblHatchusu.Visible = true;
                    txtHonshaShukko.Visible = true;
                    txtGihuShukko.Visible = true;
                    txtHatchusu.Visible = true;
                }
                updKakeritsu();
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
                if (tsTokuisaki.CodeTxtText == null || string.IsNullOrWhiteSpace(tsTokuisaki.CodeTxtText))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "取引先コードを指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                D0360_JuchuzanKakunin.D0360_JuchuzanKakunin juchuZan = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this, tsTokuisaki.CodeTxtText, txtJuchuNo);
                juchuZan.ShowDialog();
                juchuZan.Dispose();
                if (!string.IsNullOrWhiteSpace(txtJuchuNo.Text))
                {
                    getJuchuInfo();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtHatchuNo_Leave(object sender, EventArgs e)
        {
            getHatchuInfo();
        }

        // 発注情報取得
        private void getHatchuInfo()
        {
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
                    panel1.Visible = true;

                    decimal dHatSu = 0;
                    if (dtHatchu.Rows[0]["発注数量"] != null)
                    {
                        dHatSu = getDecValue(dtHatchu.Rows[0]["発注数量"].ToString());
                    }
                    txtHatchusu.Text = (decimal.Round(dHatSu, 0)).ToString();
                    dSearchSuH = getDecValue(txtHatchusu.Text);
                    tsShiiresaki.CodeTxtText = dtHatchu.Rows[0]["仕入先コード"].ToString();
                    txtShiireNoki.Text = dtHatchu.Rows[0]["納期"].ToString();
                    txtShiireChuban.Text = dtHatchu.Rows[0]["注番"].ToString();
                    txtShiireTanto.Text = dtHatchu.Rows[0]["担当者コード"].ToString();
                    tsShiiresaki.valueTextText = dtHatchu.Rows[0]["仕入先名称"].ToString();
                }
                else
                {
                    panel1.Visible = false;
                    txtHatchusu.Text = "0";
                    dSearchSuH = 0;
                    tsShiiresaki.CodeTxtText = "";
                    txtShiireNoki.Text = "";
                    txtShiireChuban.Text = "";
                    txtShiireTanto.Text = "";
                    tsShiiresaki.valueTextText = "";

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

            decimal decTeika = getDecValue(txtTeika.Text);
            // 定価が未設定の場合、掛率を計算しない
            if (decTeika.Equals(0))
            {
                return;
            }

            decimal decNum = 0;
            decimal decRitsu = 0;

            // 受注単価
            decNum = getDecValue(cbJuchuTanka.Text);
            decRitsu = decimal.Round((decNum / decTeika) * 100, 1, MidpointRounding.AwayFromZero);

            txtJuchuTankaSub.Text = decRitsu.ToString();

            // 仕入単価
            decNum = getDecValue(cbSiireTanka.Text);
            decRitsu = decimal.Round((decNum / decTeika) * 100, 1, MidpointRounding.AwayFromZero);

            txtSiireTankaSub.Text = decRitsu.ToString();

            // 直近仕入単価
            decNum = getDecValue(cbKinShiireTanka.Text);
            decRitsu = decimal.Round((decNum / decTeika) * 100, 1, MidpointRounding.AwayFromZero);

            txtKinSiireTankaSub.Text = decRitsu.ToString();
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

        private void txtSearchStr_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchStr.Text))
            {
                return;
            }
            showShohinList();
        }

        private void txtSearchStr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txtSearchStr.Text))
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                else
                {
                    showShohinList();
                }
            }
            else if (e.KeyCode == Keys.F9)
            {
                showShohinList();
            }
            lsDaibunrui.codeTxt.BackColor = SystemColors.Window;
        }

        private void txtNoki_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoki.Text))
            {
                return;
            }

            if (!"1".Equals(riekiritsuFlg))
            {
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
                            if (getDecValue(strSuryo) > 0)
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

                if (getDecValue(txtHatchusu.Text)> 0)
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
            }
        }

        private void txtShiireNoki_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtShiireNoki.Text))
            {
                return;
            }

            if (!"1".Equals(riekiritsuFlg))
            {
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

                if (!string.IsNullOrWhiteSpace(txtJuchuNo.Text))
                {
                    A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                    try
                    {
                        DataTable dtHatchu = juchuB.getShiireSuryouNoki(txtJuchuNo.Text);

                        if (dtHatchu != null && dtHatchu.Rows.Count > 0)
                        {
                            String strSuryo = dtHatchu.Rows[0]["仕入済数量"].ToString();
                            if (getDecValue(strSuryo) > 0)
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

                if (!getDecValue(txtHatchusu.Text).Equals(0))
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
            }
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

                if (txtEigyoshoCd.Text.Equals("0001"))
                {
                    txtHonshaShukko.Text = txtJuchuSuryo.Text;
                }
                else if (txtEigyoshoCd.Text.Equals("0002"))
                {
                    txtGihuShukko.Text = txtJuchuSuryo.Text;
                }
            }
        }

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
                tsShiiresaki.CodeTxtText = "";
                tsShiiresaki.valueTextText = "";
                txtShiireNoki.Text = "";
                txtShiireChuban.Text = "";
                txtHatchuNo.Text = "";
            }
            else if (getDecValue(txtHatchusu.Text).Equals(0))
            {
                panel1.Visible = false;
                txtHatchushiji.Text = "0";
                tsShiiresaki.CodeTxtText = "";
                tsShiiresaki.valueTextText = "";
                txtShiireNoki.Text = "";
                txtShiireChuban.Text = "";
                txtHatchuNo.Text = "";
            }
            else
            {
                panel1.Visible = true;
                panel1.Enabled = true;
                txtHatchushiji.Text = "1";
                tsShiiresaki.codeTxt.ReadOnly = false;
                tsShiiresaki.ReadOnlyANDTabStopFlg = false;
                txtShiireChuban.ReadOnly = false;
                //tsShiiresaki.CodeTxtText = "";
                //tsShiiresaki.valueTextText = "";
                //txtShiireNoki.Text = "";
                //txtShiireChuban.Text = "";
                //txtHatchuNo.Text = "";

                //A0010_JuchuInput_B juchuInput = new A0010_JuchuInput_B();
                //try
                //{
                //    if (!string.IsNullOrWhiteSpace(txtJuchuNo.Text)) {
                //        DataTable dtHatchuNo = juchuInput.getHatchuNoInfo(txtJuchuNo.Text);
                //        if (dtHatchuNo != null && dtHatchuNo.Rows.Count > 0)
                //        {
                //            if (!string.IsNullOrWhiteSpace(dtHatchuNo.Rows[0]["発注番号"].ToString()))
                //            {
                //                txtHatchuNo.Text = dtHatchuNo.Rows[0]["発注番号"].ToString();
                //                getHatchuInfo();
                //            }
                //            else
                //            {
                //                txtHatchusu.Text = "0";
                //            }
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    new CommonException(ex);
                //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                //    basemessagebox.ShowDialog();
                //    return;
                //}
            }

            if (panel1.Enabled == true && tsShiiresaki.ReadOnlyANDTabStopFlg == false)
            {
                tsShiiresaki.codeTxt.Focus();
            }
        }

        private void txtShohinCd_Leave(object sender, EventArgs e)
        {
            try
            {
                getShohinInfo();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        // 商品情報取得
        private void getShohinInfo() {
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
                    lsDaibunrui.CodeTxtText = dtShohin.Rows[0]["大分類コード"].ToString();
                    lsDaibunrui.chkTxtDaibunrui();
                    lsChubunrui.CodeTxtText = dtShohin.Rows[0]["中分類コード"].ToString();
                    lsChubunrui.chkTxtChubunrui(lsDaibunrui.CodeTxtText);
                    lsMaker.CodeTxtText = dtShohin.Rows[0]["メーカーコード"].ToString();
                    lsMaker.chkTxtMaker();

                    lsDaibunrui.codeTxt.ReadOnly = true;
                    lsChubunrui.codeTxt.ReadOnly = true;
                    lsMaker.codeTxt.ReadOnly = true;

                    txtC1.Text = dtShohin.Rows[0]["Ｃ１"].ToString();
                    txtC2.Text = dtShohin.Rows[0]["Ｃ２"].ToString();
                    txtC3.Text = dtShohin.Rows[0]["Ｃ３"].ToString();
                    txtC4.Text = dtShohin.Rows[0]["Ｃ４"].ToString();
                    txtC5.Text = dtShohin.Rows[0]["Ｃ５"].ToString();
                    txtC6.Text = dtShohin.Rows[0]["Ｃ６"].ToString();

                    //txtHinmei.Text = txtC1.Text + " " + txtC2.Text + " " + txtC3.Text + " " + txtC4.Text + " " + txtC5.Text + " " + txtC6.Text + " ";
                    txtHinmei.Text = txtC1.Text;

                    decimal dTeika = 0;
                    if (dtShohin.Rows[0]["定価"] != null)
                    {
                        dTeika = getDecValue(dtShohin.Rows[0]["定価"].ToString());
                    }

                    txtTeika.Text = (decimal.Round(dTeika, 0)).ToString();
                    
                    txtHinmei.ReadOnly = true;

                    lblGrayTanaHon.Text = dtShohin.Rows[0]["棚番本社"].ToString();
                    lblGrayTanaSub.Text = dtShohin.Rows[0]["棚番岐阜"].ToString();

                    // 各単価のリストを取得
                    getJuchuTanka();
                    getShiireTanka();
                    getKinShiireTanka();

                    decimal d = 0;
                    if (dtShohin.Rows[0]["標準売価"] != null)
                    {
                        d = decimal.Round(getDecValue(dtShohin.Rows[0]["標準売価"].ToString()), 0);
                        //cbJuchuTanka.Text = d.ToString();
                        cbJuchuTanka.Text = "";
                    }
                    else
                    {
                        cbJuchuTanka.Text = "";
                    }
                    
                    if (dtShohin.Rows[0]["仕入単価"] != null)
                    {
                        d = decimal.Round(getDecValue(dtShohin.Rows[0]["仕入単価"].ToString()), 2, MidpointRounding.AwayFromZero);
                        cbSiireTanka.Text = d.ToString("0.00");
                    }
                    else
                    {
                        cbSiireTanka.Text = "";
                    }

                    updKakeritsu();
                    execZaikoDisp();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

                decimal d = 0;

                if (dtTanka != null)
                {
                    for (int i = 0; i < dtTanka.Rows.Count; i++)
                    {
                        d = decimal.Round(getDecValue(dtTanka.Rows[0]["仕入単価"].ToString()), 2, MidpointRounding.AwayFromZero);

                        if (i == 0)
                        {
                            cbKinShiireTanka.Text = d.ToString("0.00");
                        }
                        cbKinShiireTanka.Items.Add(d.ToString("0.00") + ":" + dtTanka.Rows[0]["仕入先名称"].ToString() + ":" + dtTanka.Rows[0]["伝票年月日"].ToString());
                    }
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
            //A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            //try
            //{
            //    DataTable dtTanka = juchuB.getJuchuTanka(txtShohinCd.Text, tsTokuisaki.CodeTxtText);

            //    cbJuchuTanka.Items.Clear();
            //    cbJuchuTanka.Items.Add("");

            //    decimal d = 0;

            //    if (dtTanka != null)
            //    {
            //        for (int i = 0; i < dtTanka.Rows.Count; i++)
            //        {
            //            d = decimal.Round(getDecValue(dtTanka.Rows[0]["受注単価"].ToString()), 2);
            //            cbJuchuTanka.Items.Add(d.ToString("0") + ":" + dtTanka.Rows[0]["受注日"].ToString());
            //        }
            //    }
            //    cbJuchuTanka.Refresh();
            //}
            //catch (Exception ex)
            //{
            //    new CommonException(ex);
            //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
            //    basemessagebox.ShowDialog();
            //    return;
            //}
        }

        private void getShiireTanka()
        {
            //A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            //try
            //{
            //    DataTable dtTanka = juchuB.getShiireTanka(txtShohinCd.Text);

            //    cbSiireTanka.Items.Clear();
            //    cbSiireTanka.Items.Add("");

            //    decimal d = 0;

            //    if (dtTanka != null)
            //    {
            //        for (int i = 0; i < dtTanka.Rows.Count; i++)
            //        {
            //            d = decimal.Round(getDecValue(dtTanka.Rows[0]["仕入単価"].ToString()), 2);
            //            cbSiireTanka.Items.Add(d.ToString("0.00").ToString() + ":" + dtTanka.Rows[0]["仕入日"].ToString());
            //        }
            //    }
            //    cbSiireTanka.Refresh();
            //}
            //catch (Exception ex)
            //{
            //    new CommonException(ex);
            //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
            //    basemessagebox.ShowDialog();
            //    return;
            //}
        }

        // 受注追加
        private void addJuchu()
        {
            if (string.IsNullOrWhiteSpace(txtHatchusu.Text) || (getDecValue(txtHatchusu.Text)).Equals(0))
            {
                txtHatchushiji.Text = "0";
            }
            else
            {
                txtHatchushiji.Text = "1";
            }
            // 加工品受注入力の画面が開いている場合、入力存在チェックと仕入単価更新を行う。
            #region
            if (f6 != null && f6.Visible)
            {
                if (!f6.isExistInput())
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "受注のみの登録は出来ません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }

                cbSiireTanka.Text = f6.updTanka(txtJuchuSuryo.Text);
                txtHatchusu.Text = "0";
                txtHatchushiji.Text = "1";
            }
            #endregion

            if (!chkData())
            {
                return;
            }
            if (f6 != null)
            {
                //if (!f6.chkData())
                //{
                //    return;
                //}
            }

            string strMsg = "正常に登録されました";

            DBConnective con = new DBConnective();
            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();

            //// 加工品受注の入力が存在する状態で仕入先、型番ともに空欄なら受注のみの登録とみなす
            //#region
            //if (f6 != null && string.IsNullOrEmpty(txtHatchuNo.Text) && string.IsNullOrEmpty(tsShiiresaki.CodeTxtText))
            //{
            //    try
            //    {
            //        DataTable dt = juchuB.getHatchuNoInfo(txtJuchuNo.Text);
            //        if (dt == null || dt.Rows.Count == 0)
            //        {
            //            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "受注のみの登録は出来ません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
            //            basemessagebox.ShowDialog();
            //            return;
            //        }
            //        decimal dSu = juchuB.getShukkoToroku(txtJuchuNo.Text);
            //        if (dSu == 0)
            //        {
            //            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "受注のみの登録は出来ません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
            //            basemessagebox.ShowDialog();
            //            return;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        new CommonException(ex);
            //        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
            //        basemessagebox.ShowDialog();
            //        return;
            //    }
            //}
            //#endregion

            // 注番のみチェックが入っている場合、注番のみ更新
            #region
            if (cbChuban.Checked)
            {
                try
                {
                    juchuB.updChubanOnly(txtJuchuNo.Text, txtChuban.Text);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "注番を更新しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                    clearInput2();
                    tsTokuisaki.codeTxt.Focus();
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
            #endregion

            // 仕入済の場合、納期のみ更新
            #region
            if (tsTokuisaki.codeTxt.ReadOnly == true)
            {
                try
                {
                    juchuB.updNokiOnly(txtChuban.Text
                        ,txtNoki.Text
                        ,txtJuchuSuryo.Text
                        ,cbJuchuTanka.Text
                        ,decimal.Round((getDecValue(cbJuchuTanka.Text) * getDecValue(txtJuchuSuryo.Text)), 2, MidpointRounding.AwayFromZero).ToString()
                        ,txtHonshaShukko.Text
                        ,txtGihuShukko.Text
                        ,lsJuchusha.CodeTxtText
                        ,txtJuchuNo.Text
                        ,txtHatchuNo.Text
                        ,txtShiireNoki.Text,
                        con);
                    decimal d = getDecValue(txtJuchuSuryo.Text);

                    //juchuB.updZaiko(false, txtEigyoshoCd.Text, txtShohinCd.Text, (d - dSearchSu).ToString(), con);
                    juchuB.updZaiko(txtShohinCd.Text, txtEigyoshoCd.Text, txtNoki.Text, Environment.UserName, con);

                    con.Commit();
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "数量・納期・注番を更新しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                    clearInput2();
                    tsTokuisaki.codeTxt.Focus();
                    return;
                }
                catch (Exception ex)
                {
                    con.Rollback();
                    new CommonException(ex);
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
                finally
                {
                    con.DB_Disconnect();
                }
            }
            #endregion

            try
            {
                con.BeginTrans();

                // 受注更新
                #region
                string strJuchuNo = null;
                if (string.IsNullOrWhiteSpace(txtJuchuNo.Text))
                {
                    strJuchuNo = juchuB.getDenpyoNo("受注伝票");
                }
                else
                {
                    strJuchuNo = txtJuchuNo.Text;
                }
                if (f6 != null)
                {
                    f6.strJuchuNo = strJuchuNo;
                }

                string strC1 = "";
                string strC2 = "";
                string strC3 = "";
                string strC4 = "";
                string strC5 = "";
                string strC6 = "";

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

                strHinMei = txtC1.Text + txtC2.Text + txtC3.Text + txtC4.Text + txtC5.Text + txtC6.Text;

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

                decKin = getDecValue(cbJuchuTanka.Text) * getDecValue(txtJuchuSuryo.Text);
                decArari = decKin - (getDecValue(cbSiireTanka.Text) * getDecValue(txtJuchuSuryo.Text));

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

                string kbn = "0";
                string honSu = txtHonshaShukko.Text;
                string gihSu = txtGihuShukko.Text;

                if (f6 != null && f6.Visible)
                {
                    kbn = "1";
                    honSu = "0";
                    gihSu = "0";
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
                aryPrm.Add((decimal.Round(decKin, 2, MidpointRounding.AwayFromZero)).ToString());
                aryPrm.Add(cbSiireTanka.Text);
                aryPrm.Add((decimal.Round(decArari, 2, MidpointRounding.AwayFromZero)).ToString());
                aryPrm.Add(txtNoki.Text);
                aryPrm.Add(txtShukkaShiji.Text);
                aryPrm.Add(txtZaikoHikiate.Text);
                aryPrm.Add(txtUriage.Text);
                aryPrm.Add(txtChuban.Text);
                aryPrm.Add(txtHatchushiji.Text);
                aryPrm.Add(honSu);
                aryPrm.Add(gihSu);
                aryPrm.Add(kbn);
                aryPrm.Add("");
                aryPrm.Add(Environment.UserName);

                juchuB.updJuchu(aryPrm, con);
                #endregion

                decimal d = getDecValue(txtJuchuSuryo.Text);

                //juchuB.updZaiko(false, txtEigyoshoCd.Text, txtShohinCd.Text, (d - dSearchSu).ToString(), con);
                juchuB.updZaiko(txtShohinCd.Text, txtEigyoshoCd.Text, txtNoki.Text, Environment.UserName, con);

                // 発注数0の場合、既に発注があれば削除、発注があれば更新
                #region
                if (f6 == null) {
                    if (getDecValue(txtHatchusu.Text).Equals(0))
                    {
                        DataTable dtHachu = juchuB.getHatchuNoInfo(strJuchuNo);

                        if (dtHachu != null && dtHachu.Rows.Count > 0)
                        {
                            juchuB.delHachu(dtHachu.Rows[0]["発注番号"].ToString(), Environment.UserName, con);

                            string hNum = "0";
                            if (dtHachu.Rows[0]["発注数量"] != null && !string.IsNullOrWhiteSpace(dtHachu.Rows[0]["発注数量"].ToString()))
                            {
                                hNum = dtHachu.Rows[0]["発注数量"].ToString();
                            }
                            //juchuB.updZaiko(false, txtEigyoshoCd.Text, txtShohinCd.Text, hNum, con);
                            juchuB.updZaiko(txtShohinCd.Text, txtEigyoshoCd.Text, dtHachu.Rows[0]["発注年月日"].ToString(), Environment.UserName, con);
                        }
                        strMsg = "正常に登録されました";
                        //BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "正常に登録されました", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        //basemessagebox.ShowDialog();
                    }
                    else
                    {
                        string strHachuNo = addJuchuH(strJuchuNo, juchuB, con);
                        d = getDecValue(txtHatchusu.Text);
                        //juchuB.updZaiko(true, txtEigyoshoCd.Text, txtShohinCd.Text, (d - dSearchSuH).ToString(), con);
                        juchuB.updZaiko(txtShohinCd.Text, txtEigyoshoCd.Text, txtShiireNoki.Text, Environment.UserName, con);
                        string st = juchuB.getChubanName(lsJuchusha.CodeTxtText);
                        strMsg = "正常に登録されました\r\n注番:" + st.TrimEnd() + strHachuNo;

                        //BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "正常に登録されました\r\n注番:" + st.TrimEnd() + strHachuNo, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                        //basemessagebox.ShowDialog();
                    }
                }
                #endregion

                // 利益率チェックに引っかかった場合は利益率承認へ登録する
                if (acceptFlg)
                {
                    juchuB.insAccept(strJuchuNo, Environment.UserName, con);
                    acceptFlg = false;
                }

                // 加工品画面が開いている場合、加工品の登録を実行
                if (f6 != null && f6.Visible)
                {
                    f6.strJuchuNo = strJuchuNo;
                    f6.updKakoInput(con);
                    strMsg = "正常に登録されました";
                    //BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "正常に登録されました", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    //basemessagebox.ShowDialog();

                }
                con.Commit();
                txtJuchuNo.Text = strJuchuNo;
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, strMsg, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //if (basemessagebox.ShowDialog() != DialogResult.Yes)
                //{
                //    KATO.Form.H0210_MitsumoriInput.H0210_MitsumoriInput mitsumoriInput = new KATO.Form.H0210_MitsumoriInput.H0210_MitsumoriInput(this);

                //}

                // 加工品の登録を行った場合は入力をクリアしない
                if (f6 == null || !f6.Visible)
                {
                    clearInput2();
                }

                tsTokuisaki.codeTxt.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                con.Rollback();
                return;
            }
            finally
            {
                con.DB_Disconnect();
            }
        }
        private string addJuchuH(string strJuchuNo, A0010_JuchuInput_B juchuB, DBConnective con)
        {
            string ret = "";

//            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
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

            decimal decSTanka = getDecValue(cbSiireTanka.Text);
            decimal deckin = decSTanka * getDecValue(txtHatchusu.Text);
            decSTanka = decimal.Round(decSTanka, 2, MidpointRounding.AwayFromZero);
            deckin = decimal.Round(deckin, 2, MidpointRounding.AwayFromZero);

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
            aryPrm.Add(decSTanka.ToString());
            aryPrm.Add(deckin.ToString());
            aryPrm.Add(txtShiireNoki.Text);
            aryPrm.Add("0");
            aryPrm.Add(txtShiireChuban.Text);
            aryPrm.Add("0");
            aryPrm.Add(tsShiiresaki.valueTextText);
            aryPrm.Add(Environment.UserName);

            try
            {
                juchuB.updJuchuH(aryPrm, con);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        // データチェック
        private bool chkData()
        {
            acceptFlg = false;

            // 空文字チェック
            #region
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
            if (tsTokuisaki.chkTxtTorihikisaki())
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が正しくありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
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

            // 加工品画面が開いていない場合
            if (f6 == null || !f6.Visible)
            {
                if (string.IsNullOrWhiteSpace(txtJuchuSuryo.Text))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    txtJuchuSuryo.Focus();
                    return false;
                }
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
            // 加工品画面が開いていない場合
            if (f6 == null || !f6.Visible)
            {
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
            }
            if (string.IsNullOrWhiteSpace(txtHatchushiji.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                txtHatchusu.Focus();
                return false;
            }
            #endregion

            // 納期チェック
            #region
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
                        if (dtHatchu.Rows[0]["仕入済数量"] != null) {
                            if (getDecValue(dtHatchu.Rows[0]["仕入済数量"].ToString()) > 0)
                            {
                                strEndDay = endDateTime.AddMonths(6).ToString("yyyy/MM/dd");
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

            if (!"1".Equals(riekiritsuFlg))
            {
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

                    if (!string.IsNullOrWhiteSpace(txtHatchusu.Text) && getDecValue(txtHatchusu.Text) > 0)
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

                    if (!string.IsNullOrWhiteSpace(txtHatchusu.Text) && decimal.Parse(txtHatchusu.Text) > 0)
                    {
                        if (txtShiireNoki.Text.CompareTo(DateTime.Now.ToString("yyyy/MM/dd")) < 0)
                        {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "納期は本日以降に設定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();
                            txtShiireNoki.Text = "";
                            txtShiireNoki.Focus();
                            return false;
                        }

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
            }
            #endregion

            // 加工品画面が開いていない場合
            if (f6 == null || !f6.Visible)
            {
                // 数量チェック
                #region
                decimal decSu = getDecValue(txtJuchuSuryo.Text);

                if (decSu > 0)
                {
                    if (getDecValue(txtHonshaShukko.Text) + getDecValue(txtGihuShukko.Text) > decSu)
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫数は受注数量以下で入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        return false;
                    }
                }

                if (decSu < 0)
                {
                    if (getDecValue(cbSiireTanka.Text).Equals(0))
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
                #endregion

                // 在庫引当チェック
                #region
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
                #endregion

                // 納期のみチェックが無い場合
                #region
                if (!nokiFlg)
                {
                    // 発注指示が無いか、加工品受注の場合
                    if (string.IsNullOrWhiteSpace(txtHatchushiji.Text) || txtHatchushiji.Text.Equals("0") || f6 != null)
                    {
                        // 出庫数チェック
                        if (!(getDecValue(txtHonshaShukko.Text) + getDecValue(txtGihuShukko.Text)).Equals(getDecValue(txtJuchuSuryo.Text)))
                        {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫数の入力に誤りがあります", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();
                            txtJuchuSuryo.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        // 出庫数・発注数チェック
                        if (!(getDecValue(txtHonshaShukko.Text) + getDecValue(txtGihuShukko.Text) + getDecValue(txtHatchusu.Text)).Equals(getDecValue(txtJuchuSuryo.Text)))
                        {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "出庫数・発注数の入力に誤りがあります", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();
                            txtJuchuSuryo.Focus();
                            return false;
                        }

                        // 発注情報入力チェック
                        if (string.IsNullOrWhiteSpace(tsShiiresaki.CodeTxtText))
                        {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();
                            tsShiiresaki.codeTxt.Focus();
                            return false;
                        }

                        if (string.IsNullOrWhiteSpace(tsShiiresaki.valueTextText))
                        {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。\r\n文字を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();
                            tsShiiresaki.valueText.Focus();
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
                }
                #endregion

                // 売上数量チェック
                #region
                if (!string.IsNullOrWhiteSpace(txtUriSuryo.Text))
                {
                    if (!lsDaibunrui.CodeTxtText.Equals("28"))
                    {
                        if (getDecValue(txtJuchuSuryo.Text) < getDecValue(txtUriSuryo.Text))
                        {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "受注数量は売上済数量以上を入力してください。\r\n売上済：" + txtUriSuryo.Text, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                            basemessagebox.ShowDialog();
                            txtJuchuSuryo.Focus();
                            return false;
                        }
                    }
                }
                #endregion

                // 在庫数チェック
                #region

                bool zaikoKanri = false;

                try
                {
                    if (!string.IsNullOrWhiteSpace(txtShohinCd.Text)) {
                        A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                        DataTable dtS = juchuB.getShohin(txtShohinCd.Text);
                        if (dtS != null && dtS.Rows.Count > 0)
                        {
                            string s = dtS.Rows[0]["在庫管理区分"].ToString();
                            if ("0".Equals(s))
                            {
                                zaikoKanri = true;
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

                if (!"1".Equals(riekiritsuFlg) && zaikoKanri)
                {
                    if (!txtShohinCd.Text.Equals("88888"))
                    {
                        if (!lsDaibunrui.CodeTxtText.Equals("28"))
                        {
                            // 本社在庫数チェック
                            #region
                            if (getDecValue(txtHonshaShukko.Text) > 0)
                            {
                                A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                                try
                                {
                                    decimal decZaikoSu = 0;
                                    decimal decZaikoSuF = 0;
                                    decimal decHonshaSu = getDecValue(txtHonshaShukko.Text);

                                    DataTable dtZaiko = juchuB.getZaiko("0001", txtShohinCd.Text);

                                    if (dtZaiko != null && dtZaiko.Rows.Count > 0)
                                    {
                                        decZaikoSu = getDecValue(dtZaiko.Rows[0]["在庫数"].ToString());

                                        if (decZaikoSu >= decHonshaSu)
                                        {
                                            if (string.IsNullOrWhiteSpace(txtJuchuNo.Text) || (txtEigyoshoCd.Text).Equals("0002"))
                                            {
                                                //decZaikoSuF = getDecValue(dtZaiko.Rows[0]["フリー在庫数"].ToString()) + getDecValue(dtZaiko.Rows[0]["フリー在庫数未来"].ToString());
                                                decZaikoSuF = getDecValue(dtZaiko.Rows[0]["フリー在庫数"].ToString());

                                                if (decHonshaSu > decZaikoSuF)
                                                {
                                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "本社出庫数がフリー在庫数（本社）を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                                    basemessagebox.ShowDialog();
                                                    txtHonshaShukko.Focus();
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                if (decHonshaSu > decZaikoSuF + getDecValue(txtJuchuSuryo.Text) - getDecValue(txtHatchusu.Text))
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
                            #endregion

                            // 岐阜在庫数チェック
                            #region
                            if (decimal.Parse(txtGihuShukko.Text) > 0)
                            {
                                A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                                try
                                {
                                    decimal decZaikoSu = 0;
                                    decimal decZaikoSuF = 0;
                                    decimal decGihuSu = getDecValue(txtGihuShukko.Text);

                                    DataTable dtZaiko = juchuB.getZaiko("0002", txtShohinCd.Text);

                                    if (dtZaiko != null && dtZaiko.Rows.Count > 0)
                                    {
                                        decZaikoSu = getDecValue(dtZaiko.Rows[0]["在庫数"].ToString());

                                        if (decZaikoSu >= decGihuSu)
                                        {
                                            if (string.IsNullOrWhiteSpace(txtJuchuNo.Text) || (txtEigyoshoCd.Text).Equals("0001"))
                                            {
                                                //decZaikoSuF = getDecValue(dtZaiko.Rows[0]["フリー在庫数"].ToString()) + getDecValue(dtZaiko.Rows[0]["フリー在庫数未来"].ToString());
                                                decZaikoSuF = getDecValue(dtZaiko.Rows[0]["フリー在庫数"].ToString());

                                                if (decGihuSu > decZaikoSuF)
                                                {
                                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "本社出庫数がフリー在庫数（岐阜）を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                                    basemessagebox.ShowDialog();
                                                    txtGihuShukko.Focus();
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                if (decGihuSu > decZaikoSuF + getDecValue(txtJuchuSuryo.Text) - getDecValue(txtHatchusu.Text))
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
                            #endregion

                            //本社＋岐阜出庫数＞フリー在庫合計数は不可
                            #region
                            if (getDecValue(txtHonshaShukko.Text) > 0 && getDecValue(txtGihuShukko.Text) > 0)
                            {
                                A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
                                try
                                {
                                    DataTable dtZaikoH = juchuB.getZaiko("0001", txtShohinCd.Text);
                                    DataTable dtZaikoG = juchuB.getZaiko("0002", txtShohinCd.Text);

                                    if (dtZaikoH != null && dtZaikoH.Rows.Count > 1 && dtZaikoG != null && dtZaikoG.Rows.Count > 1
                                        && getDecValue(dtZaikoH.Rows[0]["在庫数"].ToString()) > 0 && getDecValue(dtZaikoG.Rows[1]["在庫数"].ToString()) > 0)
                                    {
                                        decimal zaikoF = 0;
                                        
                                        zaikoF += getDecValue(dtZaikoH.Rows[0]["フリー在庫数"].ToString()) + getDecValue(dtZaikoG.Rows[0]["フリー在庫数"].ToString());
 
                                        if (string.IsNullOrWhiteSpace(txtJuchuNo.Text))
                                        {
                                            if ((getDecValue(txtHonshaShukko.Text) + getDecValue(txtGihuShukko.Text)) > zaikoF)
                                            {
                                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "本社・岐阜出庫数がフリー在庫合計数を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                                basemessagebox.ShowDialog();
                                                txtHonshaShukko.Focus();
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            if ((getDecValue(txtHonshaShukko.Text) + getDecValue(txtGihuShukko.Text)) > zaikoF + getDecValue(txtJuchuSuryo.Text) - getDecValue(txtHatchusu.Text))
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
                            #endregion
                        }
                    }
                }
                #endregion
            }
            // 利益率チェック
            #region
            int intRiekiFlg = 0;

            intRiekiFlg = judRiekiritsu();

            if (intRiekiFlg == 0)
            {
                bool blKakohin = false;
                decimal decRitsu = 0;
                string strRitsuMsg = "";
                decimal decTotal = getDecValue(cbJuchuTanka.Text) * getDecValue(txtJuchuSuryo.Text);

                if (blKakohin)
                {
                    if (decTotal <= 2000)
                    {
                        decRitsu = decimal.Parse("0.5");
                        strRitsuMsg = "利益率が５０％を割っています。（販売価格\\2000以下）\r\n続行しますか？";
                    }
                    else
                    {
                        decRitsu = decimal.Parse("0.75");
                        strRitsuMsg = "利益率が２５％を割っています。\r\n続行しますか？";
                    }
                }
                else
                {
                    decRitsu = decimal.Parse("0.85"); ;
                    strRitsuMsg = "利益率が１５％を割っています。\r\n続行しますか？";
                }

                if (!"1".Equals(riekiritsuFlg))
                {
                    bool blRieki10 = true;

                    if (blRieki10)
                    {
                        if (Math.Abs(getDecValue(cbJuchuTanka.Text)) < Math.Abs(getDecValue(cbSiireTanka.Text)) / decRitsu)
                        {
                            kyouseiFlg = true;
                            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "利益率", strRitsuMsg, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                            //NOが押された場合
                            if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                            {
                                return false;
                            }

                            acceptFlg = true;
                        }
                    }
                }
            }
            else if (intRiekiFlg == 1)
            {
                acceptFlg = true;
            }
            else if (intRiekiFlg == 2)
            {
                return false;
            }
            #endregion

            return true;
        }

        private int judRiekiritsu ()
        {
            int ret = 0;

            decimal decShiire = 0;
            if (cbSiireTanka.Text != null)
            {
                decShiire = getDecValue(cbSiireTanka.Text);
            }

            // 利益率でチェックする仕入単価は最初に表示される商品マスタ単価で実施
            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dtShohin = juchuB.getShohin(txtShohinCd.Text);

                if (dtShohin != null && dtShohin.Rows.Count > 0)
                {
                    if (dtShohin.Rows[0]["仕入単価"] != null)
                    {
                        decShiire = decimal.Round(getDecValue(dtShohin.Rows[0]["仕入単価"].ToString()), 2, MidpointRounding.AwayFromZero);
                    }
                }

                decimal decRitsu = 0;
                if (!(getDecValue(cbJuchuTanka.Text)).Equals(0)) {
                    decRitsu = Math.Abs((getDecValue(cbJuchuTanka.Text) - decShiire) / Math.Abs(getDecValue(cbJuchuTanka.Text))) * 100;
                }

                DataTable dtRieki = juchuB.getRiekiritsu(tsTokuisaki.CodeTxtText, txtShohinCd.Text, null, null, null);

                if (getDecValue(cbJuchuTanka.Text) < decShiire)
                {
                    BaseMessageBox basemessageboxSa = new BaseMessageBox(this, "受注単価", "受注単価が仕入単価を下回っています。\r\n続行しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                    //NOが押された場合
                    if (basemessageboxSa.ShowDialog() != DialogResult.Yes)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
                // 商品別
                #region
                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (decRitsu < getDecValue(dtRieki.Rows[0]["利益率"].ToString()))
                        {
                            kyouseiFlg = true;
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
                        if (getDecValue(cbJuchuTanka.Text) < getDecValue(dtRieki.Rows[0]["単価"].ToString()))
                        {
                            kyouseiFlg = true;
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
                #endregion

                // 商品分類別
                #region
                DataTable dtCodes = juchuB.getCodesFromShohin(txtShohinCd.Text);

                if (dtCodes == null || dtCodes.Rows.Count == 0)
                {
                    return ret;
                }

                string strDaibunrui = dtCodes.Rows[0]["大分類コード"].ToString();
                string strChubunrui = dtCodes.Rows[0]["中分類コード"].ToString();
                string strMaker = dtCodes.Rows[0]["メーカーコード"].ToString();
                #endregion

                // 大中メーカー
                #region
                dtRieki = juchuB.getRiekiritsu(tsTokuisaki.CodeTxtText, txtShohinCd.Text, strDaibunrui, strChubunrui, strMaker);

                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (decRitsu < getDecValue(dtRieki.Rows[0]["利益率"].ToString()))
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
                        if (getDecValue(txtJuchuTankaSub.Text) < getDecValue(dtRieki.Rows[0]["掛率"].ToString()))
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
                #endregion

                // 大中
                #region
                dtRieki = juchuB.getRiekiritsu(tsTokuisaki.CodeTxtText, txtShohinCd.Text, strDaibunrui, strChubunrui, null);

                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (decRitsu < getDecValue(dtRieki.Rows[0]["利益率"].ToString()))
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
                        if (getDecValue(txtJuchuTankaSub.Text) < getDecValue(dtRieki.Rows[0]["掛率"].ToString()))
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
                #endregion

                //大メーカー
                #region
                dtRieki = juchuB.getRiekiritsu(tsTokuisaki.CodeTxtText, txtShohinCd.Text, strDaibunrui, null, strMaker);

                if (dtRieki != null && dtRieki.Rows.Count > 0)
                {
                    ret = 1;
                    if (dtRieki.Rows[0]["利益率"] != null && !string.IsNullOrWhiteSpace(dtRieki.Rows[0]["利益率"].ToString()))
                    {
                        if (decRitsu < getDecValue(dtRieki.Rows[0]["利益率"].ToString()))
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
                        if (getDecValue(txtJuchuTankaSub.Text) < getDecValue(dtRieki.Rows[0]["掛率"].ToString()))
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
                #endregion
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
            lsDaibunrui.ValueLabelText = "";
            lsChubunrui.CodeTxtText = "";
            lsChubunrui.ValueLabelText = "";
            lsMaker.CodeTxtText = "";
            lsMaker.ValueLabelText = "";
            txtShohinCd.Text = "";
            txtHinmei.Text = "";
            txtC1.Text = "";
            txtC2.Text = "";
            txtC3.Text = "";
            txtC4.Text = "";
            txtC5.Text = "";
            txtC6.Text = "";
            txtJuchuSuryo.Text = "";
            cbJuchuTanka.Text = "";
            cbSiireTanka.Text = "";
            txtNoki.Text = "";
            txtChuban.Text = "";
            //gridJuchuZanMeisai.Rows.Clear();
            gridJuchuZanMeisai.DataSource = null;
            gridJuchuZanMeisai.Refresh();
            //gridJuchuZanMeisai.DataSource = new DataTable();
            gridZaiko.DataSource = null;
            gridZaiko.Refresh();
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

            txtJuchuNo.ReadOnly = false;
            txtJuchuYMD.ReadOnly = false;
            lsJuchusha.codeTxt.ReadOnly = false;
            tsTokuisaki.ReadOnlyANDTabStopFlg = false;
            lsDaibunrui.codeTxt.ReadOnly = false;
            lsChubunrui.codeTxt.ReadOnly = false;
            lsMaker.codeTxt.ReadOnly = false;
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
            txtShiireChuban.ReadOnly = false;

            lblHonshaShukko.Visible = true;
            lblGihuShukko.Visible = true;
            lblHatchusu.Visible = true;
            txtHonshaShukko.Visible = true;
            txtGihuShukko.Visible = true;
            txtHatchusu.Visible = true;

            lsJuchusha.CodeTxtText = defaultUser;
            lsJuchusha.chkTxtTantosha();
            txtEigyoshoCd.Text = defaultEigyo;

            if (f6 != null)
            {
                f6.Close();
                f6.Dispose();
            }

            lsJuchusha.Focus();
        }

        private void clearInput2()
        {
            btnF01.Enabled = true;
            btnF03.Enabled = true;
            btnF08.Enabled = true;
            btnF09.Enabled = true;

            txtJuchuNo.Text = "";
            tsTokuisaki.CodeTxtText = "";
            tsTokuisaki.valueTextText = "";
            lsDaibunrui.CodeTxtText = "";
            lsDaibunrui.ValueLabelText = "";
            lsChubunrui.CodeTxtText = "";
            lsChubunrui.ValueLabelText = "";
            lsMaker.CodeTxtText = "";
            lsMaker.ValueLabelText = "";
            txtShohinCd.Text = "";
            txtHinmei.Text = "";
            txtC1.Text = "";
            txtC2.Text = "";
            txtC3.Text = "";
            txtC4.Text = "";
            txtC5.Text = "";
            txtC6.Text = "";
            txtJuchuSuryo.Text = "";
            cbJuchuTanka.Text = "";
            cbJuchuTanka.Items.Clear();
            cbJuchuTanka.Items.Add("");
            cbSiireTanka.Text = "";
            cbSiireTanka.Items.Clear();
            cbSiireTanka.Items.Add("");
            txtNoki.Text = "";
            txtChuban.Text = "";
            //gridJuchuZanMeisai.Rows.Clear();
            gridJuchuZanMeisai.DataSource = null;
            gridJuchuZanMeisai.Refresh();
            gridZaiko.DataSource = null;
            gridZaiko.Refresh();
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
            txtSiireTankaSub.Text = "";
            cbKinShiireTanka.Text = "";
            txtKinSiireTankaSub.Text = "";
            txtUriSuryo.Text = "";

            txtJuchuNo.ReadOnly = false;
            txtJuchuYMD.ReadOnly = false;
            lsJuchusha.codeTxt.ReadOnly = false;
            tsTokuisaki.codeTxt.ReadOnly = false;
            tsTokuisaki.ReadOnlyANDTabStopFlg = false;
            lsDaibunrui.codeTxt.ReadOnly = false;
            lsChubunrui.codeTxt.ReadOnly = false;
            lsMaker.codeTxt.ReadOnly = false;
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
            txtShiireChuban.ReadOnly = false;

            lblHonshaShukko.Visible = true;
            lblGihuShukko.Visible = true;
            lblHatchusu.Visible = true;
            txtHonshaShukko.Visible = true;
            txtGihuShukko.Visible = true;
            txtHatchusu.Visible = true;

            txtJuchuYMD.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lsJuchusha.CodeTxtText = defaultUser;
            lsJuchusha.chkTxtTantosha();
            txtEigyoshoCd.Text = defaultEigyo;
            panel1.Visible = false;

            if (f6 != null)
            {
                f6.Close();
                f6.Dispose();
            }

            lsJuchusha.Focus();
        }

        private void getZaikoInfo ()
        {
            if (string.IsNullOrWhiteSpace(txtShohinCd.Text))
            {
                return;
            }
            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dtZan = juchuB.getZaikoInfo(txtShohinCd.Text);
                gridZaiko.DataSource = dtZan;

                decimal d = 0;
                for (int i = 0; i < gridZaiko.Rows.Count; i++)
                {
                    if (gridZaiko[5, i].Value != null)
                    {
                        d += getDecValue(gridZaiko[5, i].Value.ToString());
                    }
                }
                txtFreeZaiko.Text = (decimal.Round(d, 0)).ToString();
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

            if (string.IsNullOrWhiteSpace(tsTokuisaki.valueTextText))
            {
                tsTokuisaki.CodeTxtText = "";
                tsTokuisaki.codeTxt.Focus();
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

            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dt = juchuB.getTanto(tsTokuisaki.CodeTxtText);

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtTantosha.Text = dt.Rows[0]["担当者コード"].ToString();
                }
                lsDaibunrui.codeTxt.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void getJuchuZanInfo()
        {
            A0010_JuchuInput_B juchuB = new A0010_JuchuInput_B();
            try
            {
                DataTable dtJuchuZan = juchuB.getJuchuZanInfo(tsTokuisaki.CodeTxtText);
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

        // サブ画面表示
        private void cmbSubWinShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;

            if (cmbSubWinShow.SelectedIndex == 0)
            {
                if (uriKakunin != null && uriKakunin.Visible)
                {
                    uriKakunin.Activate();
                    return;
                }
                uriKakunin = new D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, 1, tsTokuisaki.CodeTxtText, txtShohinCd.Text);

                Screen s = null;
                Screen[] argScreen = Screen.AllScreens;
                if (argScreen.Length > 1)
                {
                    s = argScreen[1];
                }
                else
                {
                    s = argScreen[0];
                }

                uriKakunin.StartPosition = FormStartPosition.Manual;
                uriKakunin.Location = s.Bounds.Location;

                uriKakunin.Show();
                //uriKakunin.Dispose();
            }
            else if (c.SelectedIndex == 1)
            {
                if (f6 != null && f6.Visible)
                {
                    f6.Activate();
                    return;
                }

                panel1.Visible = false;
                lblHonshaShukko.Visible = false;
                lblGihuShukko.Visible = false;
                lblHatchusu.Visible = false;
                txtHonshaShukko.Visible = false;
                txtGihuShukko.Visible = false;
                txtHatchusu.Visible = false;

                f6 = new Form6(this);
                f6.strJuchuNo = txtJuchuNo.Text;

                Screen s = null;
                Screen[] argScreen = Screen.AllScreens;
                if (argScreen.Length > 1)
                {
                    s = argScreen[1];
                }
                else
                {
                    s = argScreen[0];
                }

                f6.StartPosition = FormStartPosition.Manual;
                f6.Location = s.Bounds.Location;

                f6.strEigyoCd = txtEigyoshoCd.Text;
                f6.Show();
            }
        }

        // util 系
        private decimal getDecValue(string s)
        {
            decimal ret = 0;

            if (string.IsNullOrWhiteSpace(s))
            {
                return ret;
            }

            try
            {
                ret = decimal.Parse(s);
            }
            catch (Exception e)
            {

            }
            return ret;
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

        public void setShohinClose()
        {
            txtSearchStr.Focus();
        }

        private void txtJuchuSuryo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(((BaseTextMoney)sender).Text))
                {
                    return;
                }
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtHatchushiji_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(((BaseText)sender).Text))
                {
                    return;
                }
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void cbJuchuTanka_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(((BaseComboBox)sender).Text))
                {
                    return;
                }
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtHonshaShukko_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtChuban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void cbSiireTanka_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void setShouhin(string shoCd, string Tanka)
        {
            if (btnF01.Enabled) {
                txtShohinCd.Text = shoCd;
                getShohinInfo();
                decimal d = getDecValue(Tanka);
                cbJuchuTanka.Text = (decimal.Round(d, 0)).ToString();
            }
        }

        private void gridJuchuZanMeisai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtJuchuYMD.ReadOnly = true;
                lsJuchusha.codeTxt.ReadOnly = false;
                //txtJuchuNo.ReadOnly = false;
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
                    txtJuchuNo.Text = (gridJuchuZanMeisai.CurrentRow.Cells[0].Value).ToString();
                    getJuchuInfo();
                }
            }
        }

        private void txtShiireChuban_Leave(object sender, EventArgs e)
        {
            btnF01.Focus();
        }

        private void txtChuban_KeyDown_1(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers & Keys.Alt) == Keys.Alt && e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
    }
}
