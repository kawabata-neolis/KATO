using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static KATO.Common.Util.CommonTeisu;

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
