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
    public partial class A0010JuchuInput : KATO.Common.Ctl.BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public A0010JuchuInput(Control c)
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
            if (gridZaiko.Columns[col.Name] != null)
            {
                gr.Columns[col.Name].Width = intLen;
                gr.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
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

                // デッドストック在庫を使用していた場合は、再度デッドストックとして戻す
                if (!String.IsNullOrWhiteSpace(txtDeadStockNo.Text))
                {
                    juchuB.restoreDeadStock(txtDeadStockNo.Text);
                }

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

            var a = gridJuchuZanMeisai.CurrentRow.Cells[1];


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

    }
}
