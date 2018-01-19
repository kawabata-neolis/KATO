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
            this._Title = "売上承認";
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
            //履歴率承認の表示
            showGirdRiekiritsu();
            //売上削除承認入力の表示
            showGirdUriage();

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
            HShonin.HeaderText = "認";

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
            setColumnHenpin(HShonin, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 21);
            setColumnHenpin(HNoki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 88);
            setColumnHenpin(HTokuisaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);//元330
            setColumnHenpin(HMaker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100); //元200

            setColumnHenpin(HKataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 328);
            setColumnHenpin(HSu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 64);
            setColumnHenpin(HJuchuTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 96);
            setColumnHenpin(HShireTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 96);
            setColumnHenpin(HRiekiritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 80);
            setColumnHenpin(HChuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 248);
            setColumnHenpin(HShanaiMemo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnHenpin(HTanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 109);

            //受注番号非表示
            HJuchuNo.Visible = false;

            //データをバインド
            DataGridViewTextBoxColumn RJuchuNo = new DataGridViewTextBoxColumn();
            RJuchuNo.DataPropertyName = "受注番号";
            RJuchuNo.Name = "受注番号";
            RJuchuNo.HeaderText = "受注番号";

            DataGridViewTextBoxColumn RShonin = new DataGridViewTextBoxColumn();
            RShonin.DataPropertyName = "承認";
            RShonin.Name = "承認";
            RShonin.HeaderText = "承認";

            DataGridViewTextBoxColumn RNoki = new DataGridViewTextBoxColumn();
            RNoki.DataPropertyName = "納期";
            RNoki.Name = "納期";
            RNoki.HeaderText = "納期";

            DataGridViewTextBoxColumn RTokuisaki = new DataGridViewTextBoxColumn();
            RTokuisaki.DataPropertyName = "得意先";
            RTokuisaki.Name = "得意先";
            RTokuisaki.HeaderText = "得意先";

            DataGridViewTextBoxColumn RMaker = new DataGridViewTextBoxColumn();
            RMaker.DataPropertyName = "ﾒｰｶｰ";
            RMaker.Name = "ﾒｰｶｰ";
            RMaker.HeaderText = "ﾒｰｶｰ";

            DataGridViewTextBoxColumn RKataban = new DataGridViewTextBoxColumn();
            RKataban.DataPropertyName = "型番";
            RKataban.Name = "型番";
            RKataban.HeaderText = "型番";

            DataGridViewTextBoxColumn RSu = new DataGridViewTextBoxColumn();
            RSu.DataPropertyName = "数量";
            RSu.Name = "数量";
            RSu.HeaderText = "数量";

            DataGridViewTextBoxColumn RJuchuTanka = new DataGridViewTextBoxColumn();
            RJuchuTanka.DataPropertyName = "受注単価";
            RJuchuTanka.Name = "受注単価";
            RJuchuTanka.HeaderText = "受注単価";

            DataGridViewTextBoxColumn RShireTanka = new DataGridViewTextBoxColumn();
            RShireTanka.DataPropertyName = "仕入単価";
            RShireTanka.Name = "仕入単価";
            RShireTanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn RRiekiritsu = new DataGridViewTextBoxColumn();
            RRiekiritsu.DataPropertyName = "利益率";
            RRiekiritsu.Name = "利益率";
            RRiekiritsu.HeaderText = "利益率";

            DataGridViewTextBoxColumn RChuban = new DataGridViewTextBoxColumn();
            RChuban.DataPropertyName = "注番";
            RChuban.Name = "注番";
            RChuban.HeaderText = "注番";

            DataGridViewTextBoxColumn RShanaiMemo = new DataGridViewTextBoxColumn();
            RShanaiMemo.DataPropertyName = "社内メモ";
            RShanaiMemo.Name = "社内メモ";
            RShanaiMemo.HeaderText = "社内メモ";

            DataGridViewTextBoxColumn RTanto = new DataGridViewTextBoxColumn();
            RTanto.DataPropertyName = "担当者";
            RTanto.Name = "担当者";
            RTanto.HeaderText = "担当者";

            //個々の幅、文章の寄せ
            setColumnRiekiritsu(RJuchuNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnRiekiritsu(RShonin, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnRiekiritsu(RNoki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumnRiekiritsu(RTokuisaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnRiekiritsu(RMaker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumnRiekiritsu(RKataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnRiekiritsu(RSu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumnRiekiritsu(RJuchuTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 200);
            setColumnRiekiritsu(RShireTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 200);
            setColumnRiekiritsu(RRiekiritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 200);
            setColumnRiekiritsu(RChuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnRiekiritsu(RShanaiMemo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnRiekiritsu(RTanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);

            //受注番号非表示
            RJuchuNo.Visible = false;
            
            //データをバインド
            DataGridViewTextBoxColumn UJuchuNo = new DataGridViewTextBoxColumn();
            UJuchuNo.DataPropertyName = "受注番号";
            UJuchuNo.Name = "受注番号";
            UJuchuNo.HeaderText = "受注番号";

            DataGridViewTextBoxColumn UDenpyoYMD = new DataGridViewTextBoxColumn();
            UDenpyoYMD.DataPropertyName = "伝票年月日";
            UDenpyoYMD.Name = "伝票年月日";
            UDenpyoYMD.HeaderText = "伝票年月日";

            DataGridViewTextBoxColumn UShonin = new DataGridViewTextBoxColumn();
            UShonin.DataPropertyName = "承認";
            UShonin.Name = "承認";
            UShonin.HeaderText = "承認";

            DataGridViewTextBoxColumn UNoki = new DataGridViewTextBoxColumn();
            UNoki.DataPropertyName = "納期";
            UNoki.Name = "納期";
            UNoki.HeaderText = "納期";

            DataGridViewTextBoxColumn UTokuisaki = new DataGridViewTextBoxColumn();
            UTokuisaki.DataPropertyName = "得意先";
            UTokuisaki.Name = "得意先";
            UTokuisaki.HeaderText = "得意先";

            DataGridViewTextBoxColumn UMaker = new DataGridViewTextBoxColumn();
            UMaker.DataPropertyName = "ﾒｰｶｰ";
            UMaker.Name = "ﾒｰｶｰ";
            UMaker.HeaderText = "ﾒｰｶｰ";

            DataGridViewTextBoxColumn UKataban = new DataGridViewTextBoxColumn();
            UKataban.DataPropertyName = "型番";
            UKataban.Name = "型番";
            UKataban.HeaderText = "型番";

            DataGridViewTextBoxColumn USu = new DataGridViewTextBoxColumn();
            USu.DataPropertyName = "数量";
            USu.Name = "数量";
            USu.HeaderText = "数量";

            DataGridViewTextBoxColumn UJuchuTanka = new DataGridViewTextBoxColumn();
            UJuchuTanka.DataPropertyName = "受注単価";
            UJuchuTanka.Name = "受注単価";
            UJuchuTanka.HeaderText = "受注単価";

            DataGridViewTextBoxColumn UShireTanka = new DataGridViewTextBoxColumn();
            UShireTanka.DataPropertyName = "仕入単価";
            UShireTanka.Name = "仕入単価";
            UShireTanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn URiekiritsu = new DataGridViewTextBoxColumn();
            URiekiritsu.DataPropertyName = "利益率";
            URiekiritsu.Name = "利益率";
            URiekiritsu.HeaderText = "利益率";

            DataGridViewTextBoxColumn UChuban = new DataGridViewTextBoxColumn();
            UChuban.DataPropertyName = "注番";
            UChuban.Name = "注番";
            UChuban.HeaderText = "注番";

            DataGridViewTextBoxColumn UShanaiMemo = new DataGridViewTextBoxColumn();
            UShanaiMemo.DataPropertyName = "社内メモ";
            UShanaiMemo.Name = "社内メモ";
            UShanaiMemo.HeaderText = "社内メモ";

            DataGridViewTextBoxColumn UTanto = new DataGridViewTextBoxColumn();
            UTanto.DataPropertyName = "担当者";
            UTanto.Name = "担当者";
            UTanto.HeaderText = "担当者";

            //個々の幅、文章の寄せ
            setColumnUriage(UJuchuNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnUriage(UDenpyoYMD, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnUriage(UShonin, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnUriage(UNoki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumnUriage(UTokuisaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnUriage(UMaker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumnUriage(UKataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnUriage(USu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumnUriage(UJuchuTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 200);
            setColumnUriage(UShireTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 200);
            setColumnUriage(URiekiritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 200);
            setColumnUriage(UChuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnUriage(UShanaiMemo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumnUriage(UTanto, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);

            //受注番号、伝票年月日非表示
            UJuchuNo.Visible = false;
            UDenpyoYMD.Visible = false;
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
        ///setColumnRiekiritsu
        ///DataGridViewの内部設定（利益率承認）
        ///</summary>
        private void setColumnRiekiritsu(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
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

        ///<summary>
        ///setColumnRiekiritsu
        ///DataGridViewの内部設定（売上削除承認入力）
        ///</summary>
        private void setColumnUriage(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridUriagesakujo.Columns.Add(col);
            if (gridUriagesakujo.Columns[col.Name] != null)
            {
                gridUriagesakujo.Columns[col.Name].Width = intLen;
                gridUriagesakujo.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridUriagesakujo.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridUriagesakujo.Columns[col.Name].DefaultCellStyle.Format = fmt;
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
        ///返品値引分売上承認の再表示ボタンを押す
        ///</summary>
        private void btnSaihyojiHenpin_Click(object sender, EventArgs e)
        {
            //返品値引き分売上承認のグリッド表示
            showGirdHenpin();
        }

        ///<summary>
        ///showGirdHenpin
        ///返品値引分売上承認のグリッド表示
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

        ///<summary>
        ///btnSaihyojiHenpin_Click
        ///利益率承認の再表示ボタンを押す
        ///</summary>
        private void btnSaihyojiRiekiritsu_Click(object sender, EventArgs e)
        {
            //利益率承認のグリッド表示
            showGirdRiekiritsu();
        }

        ///<summary>
        ///showGirdRiekiritsu
        ///利益率承認のグリッド表示
        ///</summary>
        private void showGirdRiekiritsu()
        {
            DataTable dtGrid = new DataTable();

            int intShonin = 0;

            //ラジオボタンのチェックによって表示を変える
            if (radRiekiritsu.radbtn0.Checked == true)
            {
                intShonin = 0;
            }
            else if (radRiekiritsu.radbtn1.Checked == true)
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
                dtGrid = uriageshoninB.getViewGridRireki(intShonin);

                //テーブルがある場合
                if (dtGrid.Rows.Count > 0)
                {
                    //グリッドビューの表示
                    gridRiekiritsu.DataSource = dtGrid;
                }
                else
                {
                    gridRiekiritsu.DataSource = "";
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

        ///<summary>
        ///btnSaihyojiUriagesakujo_Click
        ///売上削除承認入力の再表示ボタンを押す
        ///</summary>
        private void btnSaihyojiUriagesakujo_Click(object sender, EventArgs e)
        {
            showGirdUriage();
        }

        ///<summary>
        ///showGirdUriage
        ///売上削除承認入力のグリッド表示
        ///</summary>
        private void showGirdUriage()
        {
            DataTable dtGrid = new DataTable();

            List<string> lstViewGrid = new List<string>();

            //ラジオボタンのチェックによって表示を変える
            if (radUriagesakujo.radbtn0.Checked == true)
            {
                lstViewGrid.Add("0");
            }
            else if (radUriagesakujo.radbtn1.Checked == true)
            {
                lstViewGrid.Add("1");
            }
            else
            {
                lstViewGrid.Add("2");
            }

            //本日から三か月前
            lstViewGrid.Add(DateTime.Now.ToString("yyyy/MM/dd"));
            lstViewGrid.Add(DateTime.Now.AddMonths(-3).ToString("yyyy/MM/dd"));

            ////仮(テスト用)
            //lstViewGrid.Add("2016/06/01");
            //lstViewGrid.Add("2015/12/01");

            A1520_Uriageshonin_B uriageshoninB = new A1520_Uriageshonin_B();
            try
            {
                dtGrid = uriageshoninB.getViewGridUriage(lstViewGrid);

                //テーブルがある場合
                if (dtGrid.Rows.Count > 0)
                {
                    //グリッドビューの表示
                    gridUriagesakujo.DataSource = dtGrid;
                }
                else
                {
                    gridUriagesakujo.DataSource = "";
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

        ///<summary>
        ///gridHenpinNebiki_DoubleClick
        ///返品値引分売上承認入力グリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void gridHenpinNebiki_DoubleClick(object sender, EventArgs e)
        {
            updHenpinNebiki();
        }

        ///<summary>
        ///updHenpinNebiki
        ///返品値引分売上承認入力の登録
        ///</summary>
        private void updHenpinNebiki()
        {
            //グリッドが空の場合
            if (gridHenpinNebiki.Rows.Count < 0)
            {
                return;
            }

            //データ登録用
            List<string> lstGrid = new List<string>();

            //承認フラグ登録用
            int intShoninFlg = 0;

            //承認がNの場合
            if(gridHenpinNebiki.CurrentRow.Cells["承認"].Value.ToString() == "N")
            {
                //Yに変更
                gridHenpinNebiki.CurrentRow.Cells["承認"].Value = "Y";
                intShoninFlg = 1;
            }
            else
            {
                //Nに変更
                gridHenpinNebiki.CurrentRow.Cells["承認"].Value = "N";
                intShoninFlg = 0;
            }

            //承認情報
            lstGrid.Add(gridHenpinNebiki.CurrentRow.Cells["受注番号"].Value.ToString());
            lstGrid.Add(intShoninFlg.ToString());
            lstGrid.Add(DateTime.Now.ToString());
            lstGrid.Add(SystemInformation.UserName);

            A1520_Uriageshonin_B uriageshoninB = new A1520_Uriageshonin_B();
            try
            {
                uriageshoninB.updHenpinNebiki(lstGrid);
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
        ///gridRiekiritsu_DoubleClick
        ///利益率承認グリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void gridRiekiritsu_DoubleClick(object sender, EventArgs e)
        {
            updRiekiritsu();
        }

        ///<summary>
        ///updHenpinNebiki
        ///利益率承認の登録
        ///</summary>
        private void updRiekiritsu()
        {
            //グリッドが空の場合
            if (gridRiekiritsu.Rows.Count < 0)
            {
                return;
            }

            //データ登録用
            List<string> lstGrid = new List<string>();

            //承認フラグ登録用
            int intShoninFlg = 0;

            //承認がNの場合
            if (gridRiekiritsu.CurrentRow.Cells["承認"].Value.ToString() == "N")
            {
                //Yに変更
                gridRiekiritsu.CurrentRow.Cells["承認"].Value = "Y";
                intShoninFlg = 1;
            }
            else
            {
                //Nに変更
                gridRiekiritsu.CurrentRow.Cells["承認"].Value = "N";
                intShoninFlg = 0;
            }

            //承認情報
            lstGrid.Add(gridRiekiritsu.CurrentRow.Cells["受注番号"].Value.ToString());
            lstGrid.Add(intShoninFlg.ToString());
            lstGrid.Add(DateTime.Now.ToString());
            lstGrid.Add(SystemInformation.UserName);

            A1520_Uriageshonin_B uriageshoninB = new A1520_Uriageshonin_B();
            try
            {
                uriageshoninB.updRiekiritsu(lstGrid);
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
        ///gridUriagesakujo_DoubleClick
        ///売上削除承認入力グリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void gridUriagesakujo_DoubleClick(object sender, EventArgs e)
        {
            updUriagesakujo();
        }

        ///<summary>
        ///updHenpinNebiki
        ///売上削除承認入力の登録
        ///</summary>
        private void updUriagesakujo()
        {
            //グリッドが空の場合
            if (gridUriagesakujo.Rows.Count < 0)
            {
                return;
            }

            //データ登録用
            List<string> lstGrid = new List<string>();

            //承認がNの場合
            if (gridUriagesakujo.CurrentRow.Cells["承認"].Value.ToString() == "N")
            {
                //Yに変更
                gridUriagesakujo.CurrentRow.Cells["承認"].Value = "Y";
            }
            else
            {
                //Nに変更
                gridUriagesakujo.CurrentRow.Cells["承認"].Value = "N";
            }

            //承認情報
            lstGrid.Add(gridUriagesakujo.CurrentRow.Cells["受注番号"].Value.ToString());
            lstGrid.Add(gridUriagesakujo.CurrentRow.Cells["承認"].Value.ToString());
            lstGrid.Add(DateTime.Now.ToString());
            lstGrid.Add(SystemInformation.UserName);

            A1520_Uriageshonin_B uriageshoninB = new A1520_Uriageshonin_B();
            try
            {
                uriageshoninB.updUriagesakujo(lstGrid);
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
