﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Common.Ctl;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.F0140_TanaorosiInput_B;

namespace KATO.Form.F0140_TanaorosiInput
{
    ///<summary>
    ///F0140_TanaorosiInput
    ///棚卸入力
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class F0140_TanaorosiInput : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //大分類コードの確保(text上のを使うと書き換えていた場合に異なるデータを参照するから)
        string strDaibunruiCD;

        //編集中かどうかのフラグ
        Boolean blnEditting = false;

        int gRowIndex = 0;

        ///<summary>
        ///F0140_TanaorosiInput
        ///棚卸入力（画面設定）
        ///</summary>
        public F0140_TanaorosiInput(Control c)
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
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;
            labelSet_Daibunrui_Edit.LsSubchubundata = labelSet_Chubunrui_Edit;

            //メーカーsetデータを読めるようにする
            labelSet_Daibunrui.Lsmakerdata = labelSet_Maker;
            labelSet_Daibunrui_Edit.LsSubmakerdata = labelSet_Maker_Edit;

        }

        ///<summary>
        ///TanaorosiInput_Load
        ///棚卸入力（初回読み込み）
        ///</summary>
        private void TanaorosiInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "棚卸入力";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            radBase4.Checked = true;

            //DataGridViewの初期設定
            SetUpGrid();

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            DataTable dtYMD = new DataTable();

            try
            {
                //処理部に移動
                F0140_TanaorosiInput_B tanaorosiinputB = new F0140_TanaorosiInput_B();
                dtYMD = tanaorosiinputB.setYMD();

                if (dtYMD.Rows.Count != 0)
                {
                    string strYMD = dtYMD.Rows[0]["最新棚卸年月日"].ToString();

                    txtYMD.Text = strYMD.Substring(0, 10);

                    this.txtYMD.ReadOnly = true;
                    this.txtYMD.Enabled = false;

                    this.txtTyoubosuu.Enabled = false;

                    this.btnF01.Text = STR_FUNC_F1;
                    this.btnF04.Text = STR_FUNC_F4;

                    //閲覧権限がある場合
                    if (("1").Equals(etsuranFlg))
                    {
                        this.btnF05.Text = "F5:更新";
                        this.btnF05.Enabled = true;
                    }
                    else
                    {
                        this.btnF05.Enabled = false;
                    }

                    this.btnF12.Text = STR_FUNC_F12;

                }
                else
                {
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridRireki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn tanaban = new DataGridViewTextBoxColumn();
            tanaban.DataPropertyName = "棚番";
            tanaban.Name = "棚番";
            tanaban.HeaderText = "棚番";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー名";
            maker.Name = "メーカー名";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn hinmei = new DataGridViewTextBoxColumn();
            hinmei.DataPropertyName = "品名型番";
            hinmei.Name = "品名型番";
            hinmei.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn tyoubo = new DataGridViewTextBoxColumn();
            tyoubo.DataPropertyName = "指定日在庫";
            tyoubo.Name = "指定日在庫";
            tyoubo.HeaderText = "帳簿在庫数";

            DataGridViewTextBoxColumn tana = new DataGridViewTextBoxColumn();
            tana.DataPropertyName = "棚卸数量";
            tana.Name = "棚卸数量";
            tana.HeaderText = "棚卸数";

            DataGridViewTextBoxColumn koushin = new DataGridViewTextBoxColumn();
            koushin.DataPropertyName = "更新区分";
            koushin.Name = "更新区分";
            koushin.HeaderText = "更新";

            DataGridViewTextBoxColumn gyousyoCD = new DataGridViewTextBoxColumn();
            gyousyoCD.DataPropertyName = "営業所コード";
            gyousyoCD.Name = "営業所コード";
            gyousyoCD.HeaderText = "営業所コード";

            DataGridViewTextBoxColumn koshinUserName = new DataGridViewTextBoxColumn();
            koshinUserName.DataPropertyName = "入力者名";
            koshinUserName.Name = "入力者名";
            koshinUserName.HeaderText = "入力者名";

            DataGridViewTextBoxColumn syouhinCD = new DataGridViewTextBoxColumn();
            syouhinCD.DataPropertyName = "商品コード";
            syouhinCD.Name = "商品コード";
            syouhinCD.HeaderText = "商品コード";

            //バインドしたデータを追加
            gridRireki.Columns.Add(tanaban);
            gridRireki.Columns.Add(maker);
            gridRireki.Columns.Add(hinmei);
            gridRireki.Columns.Add(tyoubo);
            gridRireki.Columns.Add(tana);
            gridRireki.Columns.Add(koushin);
            gridRireki.Columns.Add(gyousyoCD);
            gridRireki.Columns.Add(koshinUserName);
            gridRireki.Columns.Add(syouhinCD);

            //個々の幅、文章の寄せ
            gridRireki.Columns["棚番"].Width = 70;
            gridRireki.Columns["棚番"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRireki.Columns["棚番"].HeaderCell.Style.Alignment =DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["メーカー名"].Width = 160;
            gridRireki.Columns["メーカー名"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRireki.Columns["メーカー名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["品名型番"].Width = 300;
            gridRireki.Columns["品名型番"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRireki.Columns["品名型番"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["指定日在庫"].Width = 120;
            gridRireki.Columns["指定日在庫"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridRireki.Columns["指定日在庫"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["棚卸数量"].Width = 100;
            gridRireki.Columns["棚卸数量"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridRireki.Columns["棚卸数量"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["更新区分"].Width = 70;
            gridRireki.Columns["更新区分"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridRireki.Columns["更新区分"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["営業所コード"].Width = 130;
            gridRireki.Columns["営業所コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRireki.Columns["営業所コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["入力者名"].Width = 110;
            gridRireki.Columns["入力者名"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRireki.Columns["入力者名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["商品コード"].Width = 120;
            gridRireki.Columns["商品コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRireki.Columns["商品コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        ///<summary>
        ///judTanaorosiKeyDown
        ///キー入力判定
        ///</summary>
        private void judTanaorosiKeyDown(object sender, KeyEventArgs e)
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
                    this.addTanaorosi();
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
                    // ファンクションボタン制御
                    if (this.btnF05.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "更新実行"));
                        this.updKoshin();
                    }
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    //印刷
                    //PrintReport();
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    //クローズの前にデータ変更の破棄確認メッセージ
                    if(blnEditting == true)
                    {
                        // どのボタンを選択したかを判断する
                        if (MessageBox.Show("データが変更されています。破棄してもよろしいですか？", "終了確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judTanaTxtKeyDown
        ///キー入力判定
        ///</summary>
        private void judTanaTxtKeyDown(object sender, KeyEventArgs e)
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
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
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
                    //印刷
                    //PrintReport();
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    break;

                default:
                    break;
            }
        }


        ///<summary>
        ///judBtnClick
        ///ボタンの判定
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addTanaorosi();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F05: // 更新
                    // ファンクションボタン制御
                    if (this.btnF05.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "更新実行"));
                        this.updKoshin();
                    }
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///judRirekiKeyDown
        ///キー入力判定
        ///</summary>
        private void judRirekiKeyDown(object sender, KeyEventArgs e)
        {
            //エンターキーが押されたか調べる
            if (e.KeyData == Keys.Enter)
            {
                setSelectItem();
                e.Handled = true;
                return;
            }
        }

        ///<summary>
        ///addTanaorosi
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addTanaorosi()
        {
            if(blnAddDataCheck() != true)
            {
                return;
            }

            //データ渡し用
            List<string> lstString = new List<string>();
            
            //データ渡し用
            lstString.Add(txtYMD.Text);
            lstString.Add(labelSet_Eigyousho.CodeTxtText);
            lstString.Add(txtShouhinCD.Text);
            lstString.Add(txtTanasuu.Text);
            lstString.Add(labelSet_Tanaban_Edit.CodeTxtText);
            lstString.Add(txtBiko.Text);

            DBConnective con = null;
            KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B juchuB = new KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B();

            con = new DBConnective();

            try
            {
                F0140_TanaorosiInput_B tanaorosiinputB = new F0140_TanaorosiInput_B();
                tanaorosiinputB.addTanaoroshi(lstString);

                con.BeginTrans();
                juchuB.updZaiko(txtShouhinCD.Text, labelSet_Eigyousho.CodeTxtText, txtYMD.Text, Environment.UserName, con);
                con.Commit();

                //特定の値確保
                string strYMD = txtYMD.Text;
                string strDibunCd = labelSet_Daibunrui.CodeTxtText;
                string strChubunCd = labelSet_Chubunrui.CodeTxtText;
                string strEigyoCd = labelSet_Eigyousho.CodeTxtText;
                string strMakerCd = labelSet_Maker.CodeTxtText;
                string strTanaban = labelSet_Tanaban.CodeTxtText;

                //画面内削除
                delFormClear(this, gridRireki);

                //確保した値を元に戻す
                txtYMD.Text = strYMD;
                labelSet_Daibunrui.CodeTxtText = strDibunCd;
                labelSet_Chubunrui.CodeTxtText = strChubunCd;
                labelSet_Eigyousho.CodeTxtText = strEigyoCd;
                labelSet_Maker.CodeTxtText = strMakerCd;
                labelSet_Tanaban.CodeTxtText = strTanaban;

                setViewGrid();

                //各ラベルセットのLeave処理
                if (labelSet_Daibunrui.chkTxtDaibunrui())
                {
                    return;
                }

                if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
                {
                    return;
                }

                if (labelSet_Eigyousho.chkTxtEigyousho())
                {
                    return;
                }

                if (labelSet_Maker.chkTxtMaker())
                {
                    return;
                }

                if (labelSet_Tanaban.chkTxtTanaban())
                {
                    return;
                }

                txtTyoubosuu.Text = "0";

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                txtKensaku.Focus();

            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Rollback();
                }
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///blnDataCheckAdd
        ///DB追加前のチェック工程
        ///</summary>
        private bool blnAddDataCheck()
        {
            bool good = true;
            if(good)
            {
                good = txtYMD.blIsEmpty();

                if (good == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    txtYMD.Focus();
                }
            }
            if (good)
            {
                good = StringUtl.blIsEmpty(labelSet_Eigyousho.CodeTxtText);

                if (good == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    labelSet_Eigyousho.Focus();
                }
            }
            if (good)
            {                
                good = StringUtl.blIsEmpty(labelSet_Daibunrui_Edit.CodeTxtText);

                if (good == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    labelSet_Daibunrui_Edit.Focus();
                }
            }
            if (good)
            {
                good = StringUtl.blIsEmpty(labelSet_Chubunrui_Edit.CodeTxtText);

                if (good == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    labelSet_Chubunrui_Edit.Focus();
                }
            }
            if (good)
            {
                good = StringUtl.blIsEmpty(labelSet_Maker_Edit.CodeTxtText);

                if (good == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    labelSet_Maker_Edit.Focus();
                }
            }
            if (good)
            {
                good = txtTanasuu.blIsEmpty();

                if (good == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    txtTanasuu.Focus();
                }
            }
            if (good)
            {
                good = StringUtl.blIsEmpty(labelSet_Tanaban_Edit.CodeTxtText);

                if (good == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    labelSet_Tanaban_Edit.Focus();
                }
            }
            if (good)
            {
                good = txtShouhinCD.blIsEmpty();

                if (good == false)
                {
                    // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    txtKensaku.Focus();
                }
            }
            if (good)
            {
                if (btnF01.Enabled == false)
                {
                    good = false;
                }
            }

            //エラーになってない場合
            if (good == true)
            {
                //営業所チェック
                if (labelSet_Eigyousho.chkTxtEigyousho())
                {
                    good = false;
                }
            }

            //エラーになってない場合
            if (good == true)
            {
                //大分類チェック
                if (labelSet_Daibunrui.chkTxtDaibunrui())
                {
                    good = false;
                }
            }

            //エラーになってない場合
            if (good == true)
            {
                //中分類チェック
                if (labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText))
                {
                    good = false;
                }
            }

            //エラーになってない場合
            if (good == true)
            {
                //メーカーチェック
                if (labelSet_Maker.chkTxtMaker())
                {
                    good = false;
                }
            }

            //エラーになってない場合
            if (good == true)
            {
                //棚番チェック
                if (labelSet_Tanaban.chkTxtTanaban())
                {
                    good = false;
                }
            }

            //エラーになってない場合
            if (good == true)
            {
                //データがある場合
                if (labelSet_Chubunrui_Edit.codeTxt.blIsEmpty())
                {
                    //下段中分類チェック
                    if (labelSet_Chubunrui_Edit.chkTxtChubunrui(labelSet_Daibunrui_Edit.CodeTxtText))
                    {
                        good = false;
                    }
                }
            }

            //エラーになってない場合
            if (good == true)
            {
                //データがある場合
                if (labelSet_Maker_Edit.codeTxt.blIsEmpty())
                {
                    //下段メーカーチェック
                    if (labelSet_Maker_Edit.chkTxtMaker())
                    {
                        good = false;
                    }
                }
            }

            //エラーになってない場合
            if (good == true)
            {
                //データがある場合
                if (txtTanasuu.blIsEmpty())
                {
                    //数値チェック
                    if (txtTanasuu.chkMoneyText())
                    {
                        good = false;
                    }
                }
            }

            //エラーになってない場合
            if (good == true)
            {
                //データがある場合
                if (labelSet_Tanaban_Edit.codeTxt.blIsEmpty())
                {
                    //棚卸数
                    if (labelSet_Tanaban_Edit.chkTxtTanaban())
                    {
                        good = false;
                    }
                }
            }

            return good;            
        }


        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除
        ///</summary>
        private void delText()
        {
            //残したいデータの確保
            string strTxtYMD = "";

            string strEigyouID = "";

            string strEigyouName = "";

            strTxtYMD = txtYMD.Text;

            strEigyouID = labelSet_Eigyousho.CodeTxtText;

            strEigyouName = labelSet_Eigyousho.ValueLabelText;

            //フォーム上のデータを白紙
            this.delFormClear(this, gridRireki);

            //データ復旧
            txtYMD.Text = strTxtYMD;

            labelSet_Eigyousho.CodeTxtText = strEigyouID;

            labelSet_Eigyousho.ValueLabelText = strEigyouName;

            //ﾗｼﾞｵﾎﾞﾀﾝのチェックを初期値
            radBase4.Checked = true;

            labelSet_Eigyousho.Focus();
        }

        ///<summary>
        ///btnView
        ///Gridを表示させる（ボタン使用）
        ///</summary>
        private void btnView(object sender, EventArgs e)
        {
            gRowIndex = 0;
            setViewGrid();
        }

        ///<summary>
        ///setViewGrid
        ///Gridを表示させる
        ///</summary>
        private void setViewGrid()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            strDaibunruiCD = null;

            strDaibunruiCD = labelSet_Daibunrui.CodeTxtText;

            DataTable dtView = new DataTable();

            gridRireki.Enabled = true;

            string strBtnJud = "0";

            if (radBase1.Checked == true)
            {
                strBtnJud = "1";
            }
            else if (radBase2.Checked == true)
            {
                strBtnJud = "2";
            }
            else if (radBase3.Checked == true)
            {
                strBtnJud = "3";
            }
            else if (radBase4.Checked == true)
            {
                strBtnJud = "4";
            }

            //データ渡し用
            lstString.Add(txtYMD.Text);
            lstString.Add(labelSet_Eigyousho.CodeTxtText);
            lstString.Add(labelSet_Daibunrui.CodeTxtText);
            lstString.Add(labelSet_Chubunrui.CodeTxtText);
            lstString.Add(labelSet_Maker.CodeTxtText);
            lstString.Add(labelSet_Tanaban.CodeTxtText);
            lstString.Add(strBtnJud);

            try
            {
                //処理部に移動
                F0140_TanaorosiInput_B tanaorosiinputB = new F0140_TanaorosiInput_B();
                //戻り値のDatatableを取り込む
                dtView = tanaorosiinputB.setViewGrid(lstString);

                //指定日在庫、棚卸数量の小数点切り下げ
                for (int cnt = 0; cnt < dtView.Rows.Count; cnt++)
                {
                    decimal decTyoubosuu = Math.Floor(decimal.Parse(dtView.Rows[cnt]["棚卸数量"].ToString()));
                    dtView.Rows[cnt]["棚卸数量"] = decTyoubosuu.ToString();
                    decimal decTanasuu = Math.Floor(decimal.Parse(dtView.Rows[cnt]["指定日在庫"].ToString()));
                    dtView.Rows[cnt]["指定日在庫"] = decTanasuu.ToString();
                }

                gridRireki.DataSource = dtView;

                if (gridRireki.RowCount > 0)
                {
                    gridRireki.Focus();
                    gridRireki.CurrentCell = gridRireki[0, gRowIndex];
                }
                else
                {
                    btnViewGrid.Focus();
                }
                lblRecords.Text = "該当件数：" + gridRireki.RowCount.ToString();

                txtShouhinCD.Text = "";

                txtTanasuu.Text = "";
                labelSet_Tanaban_Edit.CodeTxtText = "";
                labelSet_Tanaban_Edit.ValueLabelText = "";
                blnEditting = false;

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
        ///setSelectItem
        ///データグリッドビューの処理
        ///</summary>
        private void setSelectItem()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSelect = null;

            //グリッドにデータがない場合
            if (gridRireki.Rows.Count < 1)
            {
                return;
            }

            //選択行の商品コード取得
            string strSelectSyouhinCD = (string)gridRireki.CurrentRow.Cells["商品コード"].Value;

            //データ渡し用
            lstString.Add(txtYMD.Text);
            lstString.Add(strSelectSyouhinCD);
            lstString.Add((string)gridRireki.CurrentRow.Cells["営業所コード"].Value);

            try
            {
                //処理部に移動
                F0140_TanaorosiInput_B tanaorosiinputB = new F0140_TanaorosiInput_B();
                //戻り値のDatatableを取り込む
                dtSelect = tanaorosiinputB.setSelectItem(lstString);

                //存在チェック
                if (dtSelect.Rows.Count > 0)
                {
                    //各ラベル,テキストボックスに記入
                    txtShouhinCD.Text = strSelectSyouhinCD;
                    labelSet_Daibunrui_Edit.CodeTxtText = dtSelect.Rows[0]["大分類コード"].ToString();
                    labelSet_Daibunrui_Edit.chkTxtDaibunrui();
                    labelSet_Chubunrui_Edit.CodeTxtText = dtSelect.Rows[0]["中分類コード"].ToString();
                    labelSet_Chubunrui_Edit.chkTxtChubunrui(labelSet_Daibunrui_Edit.CodeTxtText);
                    labelSet_Tanaban_Edit.CodeTxtText = dtSelect.Rows[0]["棚番"].ToString();
                    labelSet_Maker_Edit.CodeTxtText = dtSelect.Rows[0]["メーカーコード"].ToString();
                    lblDspShouhin.Text = dtSelect.Rows[0]["品名型番"].ToString();
                    txtBiko.Text = dtSelect.Rows[0]["備考"].ToString();


                    //文字列をDecimal型に変換、小数点以下を削除
                    decimal decElemTanasu = Math.Floor(decimal.Parse(dtSelect.Rows[0]["棚卸数量"].ToString()));
                    decimal decElemShitei = Math.Floor(decimal.Parse(dtSelect.Rows[0]["指定日在庫"].ToString()));
                    //各テキストボックスに記入
                    txtTanasuu.Text = decElemTanasu.ToString();
                    txtTyoubosuu.Text = decElemShitei.ToString();


                    gRowIndex = gridRireki.CurrentCell.RowIndex;



                    txtTanasuu.Focus();
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
        ///setGridSeihinDbl
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void setGridSeihinDbl(object sender, DataGridViewCellEventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///setEigyoushoListClose
        ///EigyoushoListCloseが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setEigyoushoListClose()
        {
            labelSet_Eigyousho.Focus();
        }

        ///<summary>
        ///setDaibunruiListClose
        ///DaibunruiiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setDaibunruiListClose()
        {
            labelSet_Daibunrui.Focus();
        }

        ///<summary>
        ///setChubunruiListClose
        ///ChubunruiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setChubunruiListClose()
        {
            labelSet_Chubunrui.Focus();
        }

        ///<summary>
        ///setMakerListClose
        ///MakerListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setMakerListClose()
        {
            labelSet_Maker.Focus();
        }

        ///<summary>
        ///setTanabanListClose
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setTanabanListClose()
        {
            labelSet_Tanaban.Focus();
        }

        ///<summary>
        ///setChubunListCloseEdit
        ///ChubunruiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setChubunListCloseEdit()
        {
            labelSet_Chubunrui_Edit.Focus();
        }

        ///<summary>
        ///setMakerListCloseEdit
        ///MakerListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setMakerListCloseEdit()
        {
            labelSet_Maker_Edit.Focus();
        }

        ///<summary>
        ///setTanaListCloseEdit
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setTanaListCloseEdit()
        {
            labelSet_Tanaban_Edit.Focus();
        }

        ///<summary>
        ///setShohinClose
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setShohinClose()
        {
            txtTanasuu.Focus();
        }

        ///<summary>
        ///updTxtKensakuLeave
        //検索ウィンドウか別テキストボックスに移動
        ///</summary>
        public void updTxtKensakuLeave(object sender, EventArgs e)
        {
            if(txtKensaku.TextLength > 0)
            {
                ShouhinList shouhinlist = new ShouhinList(this);
                try
                {
                    //検索項目に一つでも記入がある場合
                    if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Chubunrui.codeTxt.blIsEmpty() == false &&
                        labelSet_Maker.codeTxt.blIsEmpty() == false &&
                        txtKensaku.blIsEmpty() == false)
                    {
                        shouhinlist.blKensaku = false;
                    }
                    else
                    {
                        shouhinlist.blKensaku = true;
                    }

                    shouhinlist.intFrmKind = CommonTeisu.FRM_TANAOROSHI;
                    shouhinlist.strYMD = txtYMD.Text;
                    shouhinlist.strEigyoushoCode = labelSet_Eigyousho.CodeTxtText;
                    shouhinlist.lsDaibunrui = labelSet_Daibunrui_Edit;
                    shouhinlist.lsChubunrui = labelSet_Chubunrui_Edit;
                    shouhinlist.lsMaker = labelSet_Maker_Edit;


                    //shouhinlist.lsDaibunrui.CodeTxtText = "";
                    //shouhinlist.lsChubunrui.CodeTxtText = "";
                    //shouhinlist.lsMaker.CodeTxtText = "";



                    shouhinlist.btxtKensaku = txtKensaku;
                    shouhinlist.blKensaku = true;
                    shouhinlist.lblGrayHinChuHinban = lblDspShouhin;
                    shouhinlist.btxtShohinCd = txtShouhinCD;

                    //営業所が本社の場合
                    if (labelSet_Eigyousho.CodeTxtText == "0001")
                    {
                        shouhinlist.lsTanabanH = labelSet_Tanaban_Edit;
                    }
                    //営業所が岐阜の場合
                    else if (labelSet_Eigyousho.CodeTxtText == "0002")
                    {
                        shouhinlist.lsTanabanG = labelSet_Tanaban_Edit;
                    }

                    shouhinlist.ShowDialog();

                    //商品コードがある場合
                    if (txtShouhinCD.blIsEmpty())
                    {
                        //データ渡し用
                        List<string> lstString = new List<string>();

                        DataTable dtSelect = null;

                        //データ渡し用
                        lstString.Add(txtYMD.Text);
                        lstString.Add(txtShouhinCD.Text);
                        lstString.Add(labelSet_Eigyousho.CodeTxtText);

                        //処理部に移動
                        F0140_TanaorosiInput_B tanaorosiinputB = new F0140_TanaorosiInput_B();
                        //戻り値のDatatableを取り込む
                        dtSelect = tanaorosiinputB.setSelectItem(lstString);

                        //存在チェック
                        if (dtSelect.Rows.Count > 0)
                        {
                            //各ラベル,テキストボックスに記入
                            labelSet_Daibunrui_Edit.CodeTxtText = dtSelect.Rows[0]["大分類コード"].ToString();
                            labelSet_Daibunrui_Edit.chkTxtDaibunrui();
                            labelSet_Chubunrui_Edit.CodeTxtText = dtSelect.Rows[0]["中分類コード"].ToString();
                            labelSet_Chubunrui_Edit.chkTxtChubunrui(labelSet_Daibunrui_Edit.CodeTxtText);
                            labelSet_Tanaban_Edit.CodeTxtText = dtSelect.Rows[0]["棚番"].ToString();
                            labelSet_Maker_Edit.CodeTxtText = dtSelect.Rows[0]["メーカーコード"].ToString();
                            lblDspShouhin.Text = dtSelect.Rows[0]["品名型番"].ToString();
                            txtBiko.Text = dtSelect.Rows[0]["備考"].ToString();


                            //文字列をDecimal型に変換、小数点以下を削除
                            decimal decElemTanasu = Math.Floor(decimal.Parse(dtSelect.Rows[0]["棚卸数量"].ToString()));
                            decimal decElemShitei = Math.Floor(decimal.Parse(dtSelect.Rows[0]["指定日在庫"].ToString()));
                            //各テキストボックスに記入
                            txtTanasuu.Text = decElemTanasu.ToString();
                            txtTyoubosuu.Text = decElemShitei.ToString();

                            txtTanasuu.Focus();
                        }
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

        /// <summary>
        /// updKoshin
        /// 更新実行
        /// </summary>
        private void updKoshin()
        {
            // 空文字判定（伝票年月日）
            if (txtYMD.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtYMD.Focus();
                return;
            }

            // 日付フォーマットチェック
            string datedata = txtYMD.chkDateDataFormat(txtYMD.Text);
            if ("".Equals(datedata))
            {
                // メッセージボックスの処理
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            else
            {
                txtYMD.Text = datedata;
            }

            // ビジネス層のインスタンス生成
            F0140_TanaorosiInput_B tanaorosiinputB = new F0140_TanaorosiInput_B();
            try
            {

                //待機状態
                Cursor.Current = Cursors.WaitCursor;

                // 表示中の棚卸年月日の棚卸データの取得、判定
                int intJud = tanaorosiinputB.judTanaData(txtYMD.Text);

                //元に戻す
                Cursor.Current = Cursors.Default;

                //本社棚卸データがない場合
                if (intJud == 1)
                {
                    // メッセージボックスの処理、追加成功の場合のウィンドウ（OK）
                    BaseMessageBox basemessageboxHon = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "本社の棚卸データがありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessageboxHon.ShowDialog();
                }
                //岐阜棚卸データがない場合
                else if (intJud == 2)
                {
                    // メッセージボックスの処理、追加成功の場合のウィンドウ（OK）
                    BaseMessageBox basemessageboxHon = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "岐阜の棚卸データがありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessageboxHon.ShowDialog();
                }
                else
                {
                    // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "指定した年月日の棚卸データを更新します。" + "\r\n" + "よろしいですか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                    // NOが押された場合
                    if (basemessagebox.ShowDialog() == DialogResult.No)
                    {
                        return;
                    }

                    //待機状態
                    Cursor.Current = Cursors.WaitCursor;

                    // 表示中の棚卸年月日を追加処理
                    tanaorosiinputB.updTanaData(txtYMD.Text, SystemInformation.UserName);

                    // メッセージボックスの処理、追加成功の場合のウィンドウ（OK）
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();

                    //元に戻す
                    Cursor.Current = Cursors.Default;

                    //初期化
                    delText();
                }
            }
            catch (Exception ex)
            {
                //元に戻す
                Cursor.Current = Cursors.Default;

                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

            }
            return;
        }

        ///<summary>
        ///judGridCellChanged
        ///データグリッドビューに直接変更があった場合
        ///</summary>
        private void judGridCellChanged(object sender, DataGridViewCellEventArgs e)
        {
            blnEditting = true;
        }

        ///<summary>
        ///updDaibun
        ///リスト内の大分類が変更されたのを反映
        ///</summary>
        public void setDaibun(string strDaibun)
        {
            labelSet_Daibunrui.CodeTxtText = strDaibun;
        }
    }
}
