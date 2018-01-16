﻿using System;
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
using KATO.Business.A1520_Uriageshonin_B;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.A1520_Uriageshonin
{
    ///<summary>
    ///A1520_Uriageshonin
    ///売上承認フォーム
    ///作成者：大河内
    ///作成日：2017/2/2
    ///更新者：大河内
    ///更新日：2017/2/2
    ///カラム論理名
    ///</summary>
    public partial class A1520_Uriageshonin : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///A1520_Uriageshonin
        ///フォームの初期設定
        ///</summary>
        public A1520_Uriageshonin(Control c)
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
        ///A1520_Uriageshonin_Load
        ///画面レイアウト設定
        ///</summary>
        private void A1520_Uriageshonin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "ＭＯ入力";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF04.Text = STR_FUNC_F4;

            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            this.radHenpin.radbtn1.Checked = true;
            this.radRiekiritsu.radbtn1.Checked = true;
            this.radUriagesakujo.radbtn1.Checked = true;

            SetUpGrid();

            //返品値引分売上承認入力の表示
            showGirdHenpin();
        }

        ///<summary>
        ///SetUpGrid
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //データをバインド
            DataGridViewTextBoxColumn HJuchuNo = new DataGridViewTextBoxColumn();
            HJuchuNo.DataPropertyName = "受注番号";
            HJuchuNo.Name = "受注番号";
            HJuchuNo.HeaderText = "受注番号";

            DataGridViewTextBoxColumn HShonin = new DataGridViewTextBoxColumn();
            HShonin.DataPropertyName = "承認";
            HShonin.Name = "承認";
            HShonin.HeaderText = "承認";

            DataGridViewTextBoxColumn HNoki = new DataGridViewTextBoxColumn();
            HNoki.DataPropertyName = "納期";
            HNoki.Name = "納期";
            HNoki.HeaderText = "納期";

            DataGridViewTextBoxColumn HTokuisaki = new DataGridViewTextBoxColumn();
            HTokuisaki.DataPropertyName = "得意先";
            HTokuisaki.Name = "得意先";
            HTokuisaki.HeaderText = "得意先";

            DataGridViewTextBoxColumn HMaker = new DataGridViewTextBoxColumn();
            HMaker.DataPropertyName = "ﾒｰｶｰ";
            HMaker.Name = "ﾒｰｶｰ";
            HMaker.HeaderText = "ﾒｰｶｰ";

            DataGridViewTextBoxColumn HKataban = new DataGridViewTextBoxColumn();
            HKataban.DataPropertyName = "型番";
            HKataban.Name = "型番";
            HKataban.HeaderText = "型番";

            DataGridViewTextBoxColumn HSu = new DataGridViewTextBoxColumn();
            HSu.DataPropertyName = "数量";
            HSu.Name = "数量";
            HSu.HeaderText = "数量";

            DataGridViewTextBoxColumn HJuchuTanka = new DataGridViewTextBoxColumn();
            HJuchuTanka.DataPropertyName = "受注単価";
            HJuchuTanka.Name = "受注単価";
            HJuchuTanka.HeaderText = "受注単価";

            DataGridViewTextBoxColumn HShireTanka = new DataGridViewTextBoxColumn();
            HShireTanka.DataPropertyName = "仕入単価";
            HShireTanka.Name = "仕入単価";
            HShireTanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn HRiekiritsu = new DataGridViewTextBoxColumn();
            HRiekiritsu.DataPropertyName = "利益率";
            HRiekiritsu.Name = "利益率";
            HRiekiritsu.HeaderText = "利益率";

            DataGridViewTextBoxColumn HChuban = new DataGridViewTextBoxColumn();
            HChuban.DataPropertyName = "注番";
            HChuban.Name = "注番";
            HChuban.HeaderText = "注番";

            DataGridViewTextBoxColumn HShanaiMemo = new DataGridViewTextBoxColumn();
            HShanaiMemo.DataPropertyName = "社内メモ";
            HShanaiMemo.Name = "社内メモ";
            HShanaiMemo.HeaderText = "社内メモ";

            DataGridViewTextBoxColumn HTanto = new DataGridViewTextBoxColumn();
            HTanto.DataPropertyName = "担当者";
            HTanto.Name = "担当者";
            HTanto.HeaderText = "担当者";

            //個々の幅、文章の寄せ
            setColumnHenpin(HJuchuNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnHenpin(HShonin, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnHenpin(HNoki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumnHenpin(HTokuisaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnHenpin(HMaker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumnHenpin(HKataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnHenpin(HSu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumnHenpin(HJuchuTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 200);
            setColumnHenpin(HShireTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 200);
            setColumnHenpin(HRiekiritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 200);
            setColumnHenpin(HChuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnHenpin(HShanaiMemo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnHenpin(HTanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);

            //受注番号非表示
            HJuchuNo.Visible = false;
        }

        ///<summary>
        ///setColumnHenpin
        ///DataGridViewの内部設定（返品値引分売上承認入力）
        ///</summary>
        private void setColumnHenpin(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridHenpinNebiki.Columns.Add(col);
            if (gridHenpinNebiki.Columns[col.Name] != null)
            {
                gridHenpinNebiki.Columns[col.Name].Width = intLen;
                gridHenpinNebiki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridHenpinNebiki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridHenpinNebiki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///A1520_Uriageshonin_KeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void A1520_Uriageshonin_KeyDown(object sender, KeyEventArgs e)
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
                    //logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    //this.addMO();
                    break;
                case Keys.F2:
                    //logger.Info(LogUtil.getMessage(this._Title, "確定実行"));
                    //this.addMOKakutei();
                    break;
                case Keys.F3:
                    //logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    //this.delMO();
                    break;
                case Keys.F4:
                    //logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    //this.delText();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    //logger.Info(LogUtil.getMessage(this._Title, "再計算実行"));
                    //updSaikesan();
                    break;
                case Keys.F7:
                    //logger.Info(LogUtil.getMessage(this._Title, "ＣＳＶ発行"));
                    //saveCSV();
                    break;
                case Keys.F8:
                    //logger.Info(LogUtil.getMessage(this._Title, "特値実行"));
                    //showTokune();
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    //logger.Info(LogUtil.getMessage(this._Title, "ｴｸｾﾙ取込実行"));
                    //setExcelData();
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

        ///<summary>
        ///judFuncBtnClick
        ///ファンクションボタンの反応
        ///</summary>
        private void judFuncBtnClick(object sender, EventArgs e)
        {
            //ボタン入力情報によって動作を変える
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    //this.addMO();
                    break;
                case STR_BTN_F03: // 削除
                    //logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    //this.delMO();
                    break;
                case STR_BTN_F04: // 取消
                    //logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    //this.delText();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///btnSaihyojiHenpin_Click
        ///返品値引き分売上承認の再表示ボタンを押す
        ///</summary>
        private void btnSaihyojiHenpin_Click(object sender, EventArgs e)
        {
            //返品値引き分売上承認のグリッド表示
            showGirdHenpin();
        }

        ///<summary>
        ///showGirdHenpin
        ///返品値引き分売上承認のグリッド表示
        ///</summary>
        private void showGirdHenpin()
        {
            DataTable dtGrid = new DataTable();

            int intShonin = 0;

            //ラジオボタンのチェックによって表示を変える
            if (radHenpin.radbtn0.Checked == true)
            {
                intShonin = 0;
            }
            else if (radHenpin.radbtn1.Checked == true)
            {
                intShonin = 1;
            }
            else
            {
                intShonin = 2;
            }

            A1520_Uriageshonin_B uriageshoninB = new A1520_Uriageshonin_B();
            try
            {
                dtGrid = uriageshoninB.getViewGridHenpin(intShonin);

                //テーブルがある場合
                if (dtGrid.Rows.Count > 0)
                {
                    //グリッドビューの表示
                    gridHenpinNebiki.DataSource = dtGrid;
                }
                else
                {
                    //データ存在なしメッセージ（OK）
                    BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this, "売上承認", CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox_Nodata.ShowDialog();
                    gridHenpinNebiki.DataSource = "";
                    return;
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
