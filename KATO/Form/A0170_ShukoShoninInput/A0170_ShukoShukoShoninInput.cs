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
using KATO.Business.A0170_ShukoShoninInput;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.A0170_ShukoShoninInput
{
    ///<summary>
    ///A0170_ShukoShoninInput
    ///商品フォーム
    ///作成者：大河内
    ///作成日：2018/02/22
    ///更新者：
    ///更新日：
    ///カラム論理名
    ///</summary>
    public partial class A0170_ShukoShoninInput : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///A0170_ShukoShoninInput
        ///フォームの初期設定
        ///</summary>
        public A0170_ShukoShoninInput(Control c)
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
        ///A0170_ShukoShoninInput_Load
        ///画面レイアウト設定
        ///</summary>
        private void A0170_ShukoShoninInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "出庫承認入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;    //まだ不明
            this.btnF12.Text = STR_FUNC_F12;

            //当日の年月日を記入
            txtYMD.Text = DateTime.Today.ToString("yyyy/MM/dd");

            //グリッドの設定
            setupGrid();
        }

        ///<summary>
        ///setupGrid
        ///DataGridView初期設定
        ///</summary>
        private void setupGrid()
        {
            //列自動生成禁止
            gridShukoiraimesai.AutoGenerateColumns = false;

            //カラム名の指定
            DataGridViewTextBoxColumn denpyoNo = new DataGridViewTextBoxColumn();
            denpyoNo.DataPropertyName = "伝票番号";
            denpyoNo.Name = "伝票番号";
            denpyoNo.HeaderText = "伝票番号";

            //カラム名の指定
            DataGridViewTextBoxColumn iraibi = new DataGridViewTextBoxColumn();
            iraibi.DataPropertyName = "依頼日";
            iraibi.Name = "依頼日";
            iraibi.HeaderText = "依頼日";

            //カラム名の指定
            DataGridViewTextBoxColumn tantoName = new DataGridViewTextBoxColumn();
            tantoName.DataPropertyName = "担当者名";
            tantoName.Name = "担当者名";
            tantoName.HeaderText = "担当者名";

            //カラム名の指定
            DataGridViewTextBoxColumn shukoeigyosho = new DataGridViewTextBoxColumn();
            shukoeigyosho.DataPropertyName = "出庫営業所";
            shukoeigyosho.Name = "出庫営業所";
            shukoeigyosho.HeaderText = "出庫営業所";

            //カラム名の指定
            DataGridViewTextBoxColumn chubunName = new DataGridViewTextBoxColumn();
            chubunName.DataPropertyName = "中分類名";
            chubunName.Name = "中分類名";
            chubunName.HeaderText = "中分類名";

            //カラム名の指定
            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー";
            maker.Name = "メーカー";
            maker.HeaderText = "メーカー";

            //カラム名の指定
            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "型番";
            kataban.Name = "型番";
            kataban.HeaderText = "型    番";

            //カラム名の指定
            DataGridViewTextBoxColumn su = new DataGridViewTextBoxColumn();
            su.DataPropertyName = "数量";
            su.Name = "数量";
            su.HeaderText = "数量";

            //カラム名の指定
            DataGridViewTextBoxColumn shonin = new DataGridViewTextBoxColumn();
            shonin.DataPropertyName = "承認";
            shonin.Name = "承認";
            shonin.HeaderText = "承認";

            //カラム名の指定
            DataGridViewTextBoxColumn shoninhenko = new DataGridViewTextBoxColumn();
            shoninhenko.DataPropertyName = "承認変更";
            shoninhenko.Name = "承認変更";
            shoninhenko.HeaderText = "承認変更";

            //各カラムのバインド（文章の寄せ、カラム名の位置、フォーマット指定、横幅サイズ）
            setColumn(denpyoNo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(iraibi, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(tantoName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(shukoeigyosho, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(chubunName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 390);
            setColumn(su, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 96);
            setColumn(shonin, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 65);
            setColumn(shoninhenko, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "0", 0);

            //グリッドに非表示する項目
            gridShukoiraimesai.Columns["伝票番号"].Visible = false;
            gridShukoiraimesai.Columns["承認変更"].Visible = false;
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            //column設定
            gridShukoiraimesai.Columns.Add(col);

            //カラム名が空でない場合
            if (gridShukoiraimesai.Columns[col.Name] != null)
            {
                //横幅サイズの決定
                gridShukoiraimesai.Columns[col.Name].Width = intLen;
                //文章の寄せ方向の決定
                gridShukoiraimesai.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                //カラム名の位置の決定
                gridShukoiraimesai.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                //フォーマットが指定されていた場合
                if (fmt != null)
                {
                    //フォーマットを指定
                    gridShukoiraimesai.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///A0170_ShukoShoninInput_KeyDown
        ///キー入力判定(画面全体)
        ///</summary>
        private void A0170_ShukoShoninInput_KeyDown(object sender, KeyEventArgs e)
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
                    //this.addShukoShonin();
                    break;
                case Keys.F2:
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
                    //this.delText();
                    break;
                case Keys.F12:
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///gridShukoiraimesai_KeyDown
        ///キー入力判定(グリッド)
        ///</summary>
        private void gridShukoiraimesai_KeyDown(object sender, KeyEventArgs e)
        {
            //承認フラグを変える
            setShoninFlg();
        }

        ///<summary>
        ///gridShukoiraimesai_DoubleClick
        ///グリッド内でダブルクリックしたとき
        ///</summary>
        private void gridShukoiraimesai_DoubleClick(object sender, EventArgs e)
        {
            //承認フラグを変える
            setShoninFlg();
        }

        ///<summary>
        ///judFuncBtnClick
        ///ファンクションボタンの反応
        ///</summary>
        private void judFuncBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    //this.addShukoShonin();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    //this.delText();
                    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///addHachu
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addShukoShonin()
        {
            //データ追加用（テーブル名）
            List<string> lstTableName = new List<string>();
            //データ追加用（伝票番号）
            List<Array> lstDenpyoNo = new List<Array>();
            //データ追加用（伝票番号）
            List<string> lstShoninFlg = new List<string>();

            //データ取り出し用配列
            string[] strGetData = null;

            //文字判定(出庫年月日)
            if (txtYMD.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                //出庫年月日にフォーカス
                txtYMD.Focus();
                return;
            }

            //グリッド内の検索
            for (int intCnt = 1; intCnt < gridShukoiraimesai.Rows.Count; intCnt++)
            {
                //承認変更されている場合
                if (gridShukoiraimesai.Rows[intCnt].Cells["承認変更"].Value.ToString() == "1")
                {
                    //新しく配列を作成
                    strGetData = new string[2];
                    //一つ目に入れる
                    strGetData[0] = gridShukoiraimesai.Rows[intCnt].Cells["伝票番号"].Value.ToString();
                    //二つ目に入れる
                    strGetData[1] = gridShukoiraimesai.Rows[intCnt].Cells["承認"].Value.ToString();

                    //入れた配列をリストに入れる
                    lstDenpyoNo.Add(strGetData);

                    strGetData = (String[]) lstDenpyoNo[intCnt];

                    //lstDenpyoNo.Add(gridShukoiraimesai.Rows[intCnt].Cells["伝票番号"].Value.ToString());
                    //lstShoninFlg.Add(gridShukoiraimesai.Rows[intCnt].Cells["承認"].Value.ToString());
            }
            }

            //ビジネス層のインスタンス生成
            A0170_ShukoShoninInput_B shukoshoninB = new A0170_ShukoShoninInput_B();
            try
            {
                //PROCに必要なカラム名の追加
                lstTableName.Add("@伝票番号");          //伝票番号
                lstTableName.Add("@承認年月日");        //承認年月日
                lstTableName.Add("@承認");              //承認
                lstTableName.Add("@ユーザー名");        //ユーザー名

                shukoshoninB.updShukoShonin(lstDenpyoNo, lstTableName, txtYMD.Text, SystemInformation.UserName);
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
        ///delShukoShonin
        ///データ削除
        ///</summary>
        private void delShukoShonin()
        {

        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除
        ///</summary>
        private void delText()
        {
            //画面内全削除
            this.delFormClear(this, gridShukoiraimesai);

            //当日の年月日を記入
            txtYMD.Text = DateTime.Today.ToString("yyyy/MM/dd");

            //年月度にフォーカス
            txtYMD.Focus();
        }

        ///<summary>
        ///setGridData
        //出庫依頼明細グリッドの表示
        ///</summary>
        private void setGridData()
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //前後の空白を取り除く
            lblset_Eigyosho.CodeTxtText = lblset_Eigyosho.CodeTxtText.Trim();

            //ビジネス層のインスタンス生成
            A0170_ShukoShoninInput_B shukoshoninB = new A0170_ShukoShoninInput_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = shukoshoninB.getShukoGrid(lblset_Eigyosho.CodeTxtText);

                //１件以上データがある場合
                if (dtSetCd.Rows.Count > 0)
                {
                    //データグリッドビューに表示
                    gridShukoiraimesai.DataSource = dtSetCd;
                }
                else
                {
                    //グリッドを空にする
                    gridShukoiraimesai.DataSource = "";
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        ///<summary>
        ///lblset_Eigyosho_Leave
        ///営業所コードから離れた時
        ///</summary>
        private void lblset_Eigyosho_Leave(object sender, EventArgs e)
        {
            //正しく表示されていない場合
            if (lblset_Eigyosho.ValueLabelText == "")
            {
                return;
            }

            //出庫依頼明細グリッドの表示
            setGridData();
        }

        ///<summary>
        ///setShoninFlg
        ///承認フラグを変える
        ///</summary>
        private void setShoninFlg()
        {
            //グリッド内が空の場合
            if (gridShukoiraimesai.Rows.Count == 0)
            {
                return;
            }

            //承認フラグがNの時
            if (gridShukoiraimesai.CurrentRow.Cells["承認"].Value.ToString() == "N")
            {
                gridShukoiraimesai.CurrentRow.Cells["承認"].Value = "Y";
            }
            else
            {
                gridShukoiraimesai.CurrentRow.Cells["承認"].Value = "N";
            }

            //承認変更をしたフラグを立てる
            gridShukoiraimesai.CurrentRow.Cells["承認変更"].Value = "1";

        }

        ///<summary>
        ///judtxtShukoKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtShukoKeyUp(object sender, KeyEventArgs e)
        {
            //フォーカスの確保
            Control cActiveBefore = this.ActiveControl;

            //ベーステキストのインスタンス生成
            BaseText basetext = new BaseText();
            //キーアップされた時の判断処理
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
