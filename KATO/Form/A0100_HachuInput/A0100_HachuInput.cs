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
using KATO.Business.A0100_HachuInput_B;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.A0100_HachuInput
{
    ///<summary>
    ///A0100_HachuInput
    ///商品フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class A0100_HachuInput : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// A0100_HachuInput
        /// フォームの初期設定
        /// </summary>
        public A0100_HachuInput(Control c)
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

            //中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            //メーカーsetデータを読めるようにする
            labelSet_Daibunrui.Lsmakerdata = labelSet_Maker;
        }

        /// <summary>
        /// A0100_HachuInput_Load
        /// 画面レイアウト設定
        /// </summary>
        private void A0100_HachuInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "発注入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF08.Text = STR_FUNC_F8_RIREKI;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            txtHachuYMD.Text = DateTime.Today.ToString();
            labelSet_Hachusha.CodeTxtText = "0022";

            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridHachu.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn hachuban = new DataGridViewTextBoxColumn();
            hachuban.DataPropertyName = "発注番号";
            hachuban.Name = "発注番号";
            hachuban.HeaderText = "発注番号";

            DataGridViewTextBoxColumn chuban = new DataGridViewTextBoxColumn();
            chuban.DataPropertyName = "注番";
            chuban.Name = "注番";
            chuban.HeaderText = "注番";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー名";
            maker.Name = "メーカー名";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn chubun = new DataGridViewTextBoxColumn();
            chubun.DataPropertyName = "中分類名";
            chubun.Name = "中分類名";
            chubun.HeaderText = "中分類";

            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "型番";
            kataban.Name = "型番";
            kataban.HeaderText = "型　　番";

            DataGridViewTextBoxColumn hachusu = new DataGridViewTextBoxColumn();
            hachusu.DataPropertyName = "発注数量";
            hachusu.Name = "発注数量";
            hachusu.HeaderText = "発注数量";

            DataGridViewTextBoxColumn noki = new DataGridViewTextBoxColumn();
            noki.DataPropertyName = "納期";
            noki.Name = "納期";
            noki.HeaderText = "納期";

            //個々の幅、文章の寄せ
            setColumn(hachuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(chuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 170);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 170);
            setColumn(chubun, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 600);
            setColumn(hachusu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0.#", 130);
            setColumn(noki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 130);

            gridHachu.Columns[0].Visible = false;
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            //column設定
            gridHachu.Columns.Add(col);
            if (gridHachu.Columns[col.Name] != null)
            {
                gridHachu.Columns[col.Name].Width = intLen;
                gridHachu.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridHachu.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridHachu.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// A0100_HachuInput_KeyDown
        /// キー入力判定
        /// </summary>
        private void A0100_HachuInput_KeyDown(object sender, KeyEventArgs e)
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
                    this.addHachu();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delHachu();
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
                    logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));
                    this.setRireki();
                    break;
                case Keys.F9:
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

        ///<summary>
        ///judGridSeihinKeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///</summary>        
        private void gridHachu_KeyDown(object sender, KeyEventArgs e)
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
                    //ダブルクリックと同じ効果
                    setSelectItem();
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
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    //戻るボタン
                    logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));
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
                    this.addHachu();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delHachu();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F08: // 履歴
                    logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));
                    this.setRireki();
                    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// addHachu
        /// テキストボックス内のデータをDBに登録
        /// </summary>
        private void addHachu()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定(発注年月日)
            if (txtHachuYMD.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHachuYMD.Focus();
                return;
            }
            //文字判定(担当者)
            if (labelSet_Hachusha.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Hachusha.Focus();
                return;
            }
            //文字判定(仕入先コード)
            if (textSet_Tokuisaki.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                textSet_Tokuisaki.Focus();
                return;
            }
            //文字判定(大分類)
            if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Daibunrui.Focus();
                return;
            }
            //文字判定(中分類)
            if (labelSet_Chubunrui.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Chubunrui.Focus();
                return;
            }
            //文字判定(メーカー)
            if (labelSet_Maker.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Maker.Focus();
                return;
            }
            //文字判定(発注数量)
            if (txtHachusu.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHachusu.Focus();
                return;
            }
            //文字判定(発注単価)
            if (cmbHachutan.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                cmbHachutan.Focus();
                return;
            }
            //文字判定(納期)
            if (txtNoki.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtNoki.Focus();
                return;
            }
            ////文字判定(注番)
            //if (txtChuban.blIsEmpty() == false)
            //{
            //    //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
            //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
            //    basemessagebox.ShowDialog();
            //    txtChuban.Focus();
            //    return;
            //}
            ////文字判定(型番)
            //if (txtData1.blIsEmpty() == false)
            //{
            //    //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
            //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
            //    basemessagebox.ShowDialog();
            //    txtData1.Focus();
            //    return;
            //}

            lstString.Add(txtHachuYMD.Text);
            lstString.Add(labelSet_Hachusha.CodeTxtText);
            lstString.Add(labelSet_Hachusha.CodeTxtText);
            lstString.Add(labelSet_Daibunrui.CodeTxtText);
            lstString.Add(labelSet_Chubunrui.CodeTxtText);
            lstString.Add(labelSet_Maker.CodeTxtText);
            lstString.Add(txtHinmei.Text);
            lstString.Add(txtHachusu.Text);
            lstString.Add(cmbHachutan.Text);
            lstString.Add(txtNoki.Text);
            lstString.Add(txtChuban.Text);
            lstString.Add(txtData1.Text);

            //受注番号が入っている場合
            if (txtJuchuban.Text != "")
            {
                decimal decJusu = 0;
                decimal decHonsu = 0;
                decimal decGifusu = 0;

                //検索時のデータ取り出し先(受注検出時)
                DataTable dtSetJuchurenkei;

                //ビジネス層のインスタンス生成
                A0100_HachuInput_B hachuB = new A0100_HachuInput_B();
                try
                {
                    //戻り値のDatatableを取り込む（該当DBで受注番号を検索）
                    dtSetJuchurenkei = hachuB.setJuchuRenkei(txtJuchuban.Text);

                    //１件以上データがある場合
                    if (dtSetJuchurenkei.Rows.Count > 0)
                    {
                        decJusu = decimal.Parse(dtSetJuchurenkei.Rows[0]["受注数量"].ToString());
                        decHonsu = decimal.Parse(dtSetJuchurenkei.Rows[0]["本社出庫数"].ToString());
                        decGifusu = decimal.Parse(dtSetJuchurenkei.Rows[0]["岐阜出庫数"].ToString());
                    }

                    //受注数量が使用在庫数を超えた場合
                    if ((decimal.Parse(txtHachusu.Text) + decHonsu + decGifusu) > decJusu)
                    {
                        //受注数量が使用在庫を超えているというメッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_HACHU_JUCHURENKEI, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return;
                    }                    
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

            //仕入先コードが本社の場合
            if (textSet_Tokuisaki.CodeTxtText == "1111")
            {
                //0より小さい数値の場合
                if (int.Parse(txtHachusu.Text) < 0)
                {
                    //仕入先コード1111は返品不可というメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_HACHU_JUCHURENKEI, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;

                }
            }

            //仕入先コードが岐阜の場合
            if (textSet_Tokuisaki.CodeTxtText == "2222")
            {
                //0より小さい数値の場合
                if (int.Parse(txtHachusu.Text) < 0)
                {
                    //仕入先コード2222は返品不可というメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_HACHU_JUCHURENKEI, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }

            //発注番号がない場合、伝票番号テーブルから新規伝票番号を得る
            if (txtHachuban.blIsEmpty() == false)
            {
                //ビジネス層のインスタンス生成
                A0100_HachuInput_B hachuB = new A0100_HachuInput_B();
                try
                {
                    //新規番号を記入
                    txtHachuban.Text =  hachuB.setNewDenpyo("発注番号");
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

            //商品コードが空だった場合
            if (txtShohinCd.blIsEmpty() == false)
            {
                txtShohinCd.Text = "88888";
            }

            //ここから
            //if (strC1 == "" | IsDbNull(strC1) | txtSyohinCD.data == "88888")
            //{
            //    //UPGRADE_WARNING: オブジェクト txtKataban.data の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            //    //UPGRADE_WARNING: オブジェクト strC1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            //    strC1 = txtKataban.data;
            //}

            //型番１に記入がないまたは、商品コードが88888の場合
            if (txtData1.blIsEmpty() == true || txtShohinCd.Text == "88888")
            {
                //商品コードを型番１に記入
                txtData1.Text = txtShohinCd.Text;
            }
            //受注番号に記入がない場合
            if (txtJuchuban.blIsEmpty() == true)
            {
                //0を入れる
                txtJuchuban.Text = "0";
            }

            
            //JucyuKin = Fix(txtSiireTanka.data * txtSu.data);

            //theErr = execSProc("発注更新_PROC", txtCD.data, txtYMD.data, Denno, txtJyucyuTantou.data, txtEigyosho.data, txtJyucyuTantou.data, JyucyuNo, 0, 0,
            //SyohinCD, txtMaker.data, txtDaiBunrui.data, txtCyuBunrui.data, strC1, strC2, strC3, strC4, strC5, strC6,
            //txtSu.data, txtSiireTanka.data, JucyuKin, txtNouki.data, 0, txtCyuuban.data, "0", txtTname.data, gSysInfo.UserID);

            //if (theErr != noErr)
            //    goto Err_Proc;

        //    gCon.CommitTrans();
        //    //2005.05.25    msgAlert "正常に登録されました" & vbCrLf & "注番：" & Left(gSysInfo.UserID, 3) & CStr(DenNo), "登録"
        //    //2005.06.03    msgAlert "正常に登録されました" & vbCrLf & "注番：" & Left(gSysInfo.UserID, 4) & CStr(DenNo), "登録"
        //    string msgStr;
        //    msgStr = GetCyubanName((txtJyucyuTantou.data));
        //    msgAlert("正常に登録されました" + vbCrLf + "注番：" + RTrim(msgStr) + (string)Denno, "登録");

        //    //2005.07.18    Call Torikesi
        //    Torikesi2();

        //    txtCD.setFocus();

        //    Tsuika = true;

        //    return;

        //Err_Proc:
        //    msgError("追加処理でエラーが発生しました。");
        //    // ERROR: Not supported in C#: OnErrorStatement

        //    if (gCon.Errors.Count > 0)
        //        gCon.RollbackTrans();
        //    Tsuika = false;

        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            delFormClear(this,gridHachu);

            //記入可能にする
            labelSet_Daibunrui.Enabled = true;
            labelSet_Chubunrui.Enabled = true;
            labelSet_Maker.Enabled = true;
            txtHinmei.Enabled = true;

        }

        /// <summary>
        /// delHachu
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void delHachu()
        {
            //受注番号が記入されている場合
            if (txtJuchuban.Text != "")
            {
                //検索時のデータ取り出し先(受注検出時)
                DataTable dtSetCdJuchuNo;

                //検索時のデータ取り出し先(発注検出時)
                DataTable dtSetCdHachuNo;

                //ビジネス層のインスタンス生成
                A0100_HachuInput_B hachuB = new A0100_HachuInput_B();
                try
                {
                    //戻り値のDatatableを取り込む（該当DBで受注番号を検索）
                    dtSetCdJuchuNo = hachuB.setJuchuNoCheck(txtJuchuban.Text);

                    //１件以上データがある場合
                    if (dtSetCdJuchuNo.Rows.Count > 0)
                    {
                        //受注番号があるので、受注伝票に誘導のコメント（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_HACHU_JUCHUNO_JUCHUDEL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return;
                    }

                    //戻り値のDatatableを取り込む（該当DBで発注番号を検索）
                    dtSetCdHachuNo = hachuB.setHachuNoCheck(txtHachuban.Text);

                    //仕入済数量が0以上の場合
                    if (int.Parse(dtSetCdHachuNo.Rows[0]["仕入済数量"].ToString()) > 0)
                    {
                        //既に仕入済みのため、削除できないとメッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_HACHU_JUCHUNO_NOTDEL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        return;
                    }

                    //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
                    BaseMessageBox basemessageboxSa = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                    //NOが押された場合
                    if (basemessageboxSa.ShowDialog() == DialogResult.No)
                    {
                        return;
                    }

                    //削除工程
                    hachuB.delHachu(txtHachuban.Text, SystemInformation.UserName);
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
        }

        /// <summary>
        /// setRireki
        /// 仕入実績確認を表示
        /// </summary>
        public void setRireki()
        {

        }

        /// <summary>
        /// textSet_Tokuisaki_Leave
        /// 仕入先コードから離れた場合
        /// </summary>
        private void textSet_Tokuisaki_Leave(object sender, EventArgs e)
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd;

            //前後の空白を取り除く
            textSet_Tokuisaki.CodeTxtText = textSet_Tokuisaki.CodeTxtText.Trim();

            //取引先コードが記入されていない場合
            if (textSet_Tokuisaki.CodeTxtText == "")
            {
                return;
            }

            //ビジネス層のインスタンス生成
            A0100_HachuInput_B hachuB = new A0100_HachuInput_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = hachuB.setHachuGrid(textSet_Tokuisaki.CodeTxtText);

                //１件以上データがある場合
                if (dtSetCd.Rows.Count > 0)
                {
                    gridHachu.DataSource = dtSetCd;
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

        /// <summary>
        /// judtxtDaibunruiKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void gridHachu_DoubleClick(object sender, EventArgs e)
        {
            setSelectItem();
        }

        /// <summary>
        /// setSelectItem
        /// データグリッドビュー内のデータが選択された時
        /// </summary>
        private void setSelectItem()
        {
            //選択されたデータの"発注番号"を取得
            txtHachuban.Text = (string)gridHachu.CurrentRow.Cells["発注番号"].Value.ToString();

            //検索時のデータ取り出し先(グリッド全体)
            DataTable dtSetCd;
            //検索時のデータ取り出し先(受注検出時)
            DataTable dtSetCdJuchuNo;

            //ビジネス層のインスタンス生成
            A0100_HachuInput_B hachuB = new A0100_HachuInput_B();
            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = hachuB.setHachuLeave(txtHachuban.Text);

                //１件以上データがある場合
                if (dtSetCd.Rows.Count != 0)
                {
                    //受注番号が1以上の場合
                    if (int.Parse(dtSetCd.Rows[0]["受注番号"].ToString()) > 0)
                    {
                        //戻り値のDatatableを取り込む
                        dtSetCdJuchuNo = hachuB.setJuchuNoCheck(dtSetCd.Rows[0]["受注番号"].ToString());

                        //１件以上データがある場合
                        if (dtSetCdJuchuNo.Rows.Count > 0)
                        {
                            //受注番号があるので、受注入力に誘導のコメント（OK）
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_HACHU_JUCHUNO_SHUSEI, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            txtHachuban.Clear();
                            txtHachuban.Focus();
                            return;
                        }
                    }

                    txtHachuYMD.Text = dtSetCd.Rows[0]["発注年月日"].ToString();
                    labelSet_Hachusha.CodeTxtText = dtSetCd.Rows[0]["発注者コード"].ToString();
                    textSet_Tokuisaki.CodeTxtText = dtSetCd.Rows[0]["仕入先コード"].ToString();
                    txtShohinCd.Text = dtSetCd.Rows[0]["商品コード"].ToString();
                    txtHachusu.Text = dtSetCd.Rows[0]["発注数量"].ToString();
                    cmbHachutan.Text = dtSetCd.Rows[0]["発注単価"].ToString();
                    txtNoki.Text = dtSetCd.Rows[0]["納期"].ToString();
                    txtChuban.Text = dtSetCd.Rows[0]["注番"].ToString();

                    labelSet_Daibunrui.CodeTxtText = dtSetCd.Rows[0]["大分類コード"].ToString();
                    labelSet_Chubunrui.CodeTxtText = dtSetCd.Rows[0]["中分類コード"].ToString();
                    labelSet_Maker.CodeTxtText = dtSetCd.Rows[0]["メーカーコード"].ToString();
                    txtData1.Text = dtSetCd.Rows[0]["Ｃ１"].ToString();
                    txtData2.Text = dtSetCd.Rows[0]["Ｃ２"].ToString();
                    txtData3.Text = dtSetCd.Rows[0]["Ｃ３"].ToString();
                    txtData4.Text = dtSetCd.Rows[0]["Ｃ４"].ToString();
                    txtData5.Text = dtSetCd.Rows[0]["Ｃ５"].ToString();
                    txtData6.Text = dtSetCd.Rows[0]["Ｃ６"].ToString();

                    labelSet_Eigyosho1.CodeTxtText = dtSetCd.Rows[0]["営業所コード"].ToString();
                    labelSet_Tantosha.CodeTxtText = dtSetCd.Rows[0]["担当者コード"].ToString();

                    //受注番号が1以上で存在していた場合
                    if (int.Parse(dtSetCd.Rows[0]["受注番号"].ToString()) > 0)
                    {
                        txtJuchuban.Text = dtSetCd.Rows[0]["受注番号"].ToString();
                    }

                    txtHinmei.Text = ((TextBox)txtData1).Text.Trim() + " " 
                                   + ((TextBox)txtData2).Text.Trim() + " "
                                   + ((TextBox)txtData3).Text.Trim() + " "
                                   + ((TextBox)txtData4).Text.Trim() + " "
                                   + ((TextBox)txtData5).Text.Trim() + " "
                                   + ((TextBox)txtData6).Text.Trim() + " ";
                    

                    //フォーカス位置の確保
                    Control cActive = this.ActiveControl;

                    //フォーカスを当てて中身を適切なものに置き換える必要がある
                    txtHachusu.Focus();

                    txtHachusu.Enabled = true;
                    cmbHachutan.Enabled = true;
                    txtNoki.Enabled = true;

                    if (txtShohinCd.Text == "88888")
                    {
                        //受注番号がない場合
                        if (txtJuchuban.blIsEmpty() == false)
                        {
                            labelSet_Daibunrui.Enabled = true;
                            labelSet_Chubunrui.Enabled = true;
                            labelSet_Maker.Enabled = true;
                            txtHinmei.Enabled = true;
                        }
                        else
                        {
                            labelSet_Daibunrui.Enabled = false;
                            labelSet_Chubunrui.Enabled = false;
                            labelSet_Maker.Enabled = false;
                            txtHinmei.Enabled = false;
                        }
                    }
                    else
                    {
                        labelSet_Daibunrui.Enabled = false;
                        labelSet_Chubunrui.Enabled = false;
                        labelSet_Maker.Enabled = false;
                        txtHinmei.Enabled = false;
                    }

                    cActive.Focus();
                }
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

        /// <summary>
        /// judtxtDaibunruiKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtHachuKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///updDaibun
        ///リスト内の大分類が変更されたのを反映
        ///</summary>
        public void updDaibun(string strDaibun)
        {
            labelSet_Daibunrui.CodeTxtText = strDaibun;
        }
    }
}
