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
using KATO.Business.A0100_HachuInput_B;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.M1050_Tantousha;

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

        //ロック
        bool blNLOCK;

        ///<summary>
        ///A0100_HachuInput
        ///フォームの初期設定
        ///</summary>
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

        ///<summary>
        ///A0100_HachuInput_Load
        ///画面レイアウト設定
        ///</summary>
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
            txtTanto.Text = "0022";
            labelSet_Eigyosho.CodeTxtText = "0001";
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

        ///<summary>
        ///A0100_HachuInput_KeyDown
        ///キー入力判定(画面全般）
        ///</summary>
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
        ///judTxtHachuKeyDown
        ///キー入力判定(テキストボックス)
        ///</summary>
        private void judTxtHachuKeyDown(object sender, KeyEventArgs e)
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
                    //TABボタンと同じ効果
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
        ///judTxtKensakuKeyDown
        ///キー入力判定(テキストボックス)
        ///</summary>
        private void judTxtKensakuKeyDown(object sender, KeyEventArgs e)
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
                    //TABボタンと同じ効果
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
                    //商品リスト移動メソッド
                    updKensaku();
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
                    //DataGridViewの次の列に移動しないようにする
                    e.Handled = true;
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

        ///<summary>
        ///judBtnClick
        ///ボタンの反応
        ///</summary>
        private void updKensaku()
        {
            //検索文字列に何か記入されている場合
            if (txtKensaku.TextLength > 0)
            {
                try
                {
                    ShouhinList shouhinlist = new ShouhinList(this);
                    shouhinlist.intFrmKind = CommonTeisu.FRM_HACHUINPUT;
                    shouhinlist.strYMD = txtHachuYMD.Text;
                    shouhinlist.strEigyoushoCode = "";
                    shouhinlist.strDaibunruiCode = labelSet_Daibunrui.CodeTxtText;
                    shouhinlist.strChubunruiCode = labelSet_Chubunrui.CodeTxtText;
                    shouhinlist.strMakerCode = labelSet_Maker.CodeTxtText;
                    shouhinlist.strKensaku = txtKensaku.Text;
                    shouhinlist.ShowDialog();

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

        ///<summary>
        ///judBtnClick
        ///ボタンの反応
        ///</summary>
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

        ///<summary>
        ///addHachu
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addHachu()
        {
            //データ追加用（テーブル名）
            List<string> lstTableName = new List<string>();
            //データ追加用（データ内容）
            List<string> lstData = new List<string>();

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
                    //新規番号を取得                    
                    txtHachuban.Text = (hachuB.setNewDenpyo("発注番号")).Rows[0]["最終番号"].ToString();
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

            decimal JucyuKin;

            //商品コードが空だった場合
            if (txtShohinCd.blIsEmpty() == false)
            {
                txtShohinCd.Text = "88888";
            }

            //型番１に記入がないまたは、商品コードが88888の場合
            if (txtData1.blIsEmpty() == true || txtShohinCd.Text == "88888")
            {
                //商品コードを型番１に記入
                txtData1.Text = txtHinmei.Text;
            }

            //受注番号に記入がない場合
            if (txtJuchuban.blIsEmpty() == false)
            {
                //0を入れる
                txtJuchuban.Text = "0";
            }

            //受注金の計算
            JucyuKin = (int.Parse(cmbHachutan.Text.Split('.')[0]) * (int.Parse(txtHachusu.Text)));

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                //PROCに必要なテーブル名の追加
                lstData.Add(textSet_Tokuisaki.CodeTxtText);     //仕入先コード
                lstData.Add(txtHachuYMD.Text);                  //発注年月日
                lstData.Add(txtHachuban.Text);                  //発注番号
                lstData.Add(txtTanto.Text);                     //発注者コード
                lstData.Add(labelSet_Eigyosho.CodeTxtText);	    //営業所コード
                lstData.Add(txtTanto.Text);					    //担当者コード
                lstData.Add(txtJuchuban.Text);					//受注番号
                lstData.Add("0");								//出庫番号
                lstData.Add("0");								//行番号
                lstData.Add(txtShohinCd.Text);					//商品コード
                lstData.Add(labelSet_Maker.CodeTxtText);		//メーカーコード
                lstData.Add(labelSet_Daibunrui.CodeTxtText);	//大分類コード
                lstData.Add(labelSet_Chubunrui.CodeTxtText);	//中分類コード
                lstData.Add(txtData1.Text);					    //Ｃ１
                lstData.Add(txtData2.Text);					    //Ｃ２
                lstData.Add(txtData3.Text);					    //Ｃ３
                lstData.Add(txtData4.Text);					    //Ｃ４
                lstData.Add(txtData5.Text);					    //Ｃ５
                lstData.Add(txtData6.Text);					    //Ｃ６
                lstData.Add(txtHachusu.Text);					//発注数量
                lstData.Add(cmbHachutan.Text);					//発注単価
                lstData.Add(JucyuKin.ToString());				//発注金額
                lstData.Add(txtNoki.Text);						//納期
                lstData.Add("0");								//発注フラグ
                lstData.Add(txtChuban.Text);					//注番
                lstData.Add("0");								//加工区分
                lstData.Add(textSet_Tokuisaki.valueTextText);	//仕入先名称
                lstData.Add(SystemInformation.UserName);        //ユーザー名

                //PROCに必要なカラム名の追加
                lstTableName.Add("@仕入先コード");              //仕入先コード
                lstTableName.Add("@発注年月日");                //発注年月日
                lstTableName.Add("@発注番号");                  //発注番号
                lstTableName.Add("@発注者コード");              //発注者コード
                lstTableName.Add("@営業所コード");	            //営業所コード
                lstTableName.Add("@担当者コード");	   	        //担当者コード
                lstTableName.Add("@受注番号");				    //受注番号
                lstTableName.Add("@出庫番号");					//出庫番号
                lstTableName.Add("@行番号");					//行番号
                lstTableName.Add("@商品コード");				//商品コード
                lstTableName.Add("@メーカーコード");		    //メーカーコード
                lstTableName.Add("@大分類コード");	            //大分類コード
                lstTableName.Add("@中分類コード");              //中分類コード
                lstTableName.Add("@Ｃ１");					    //Ｃ１
                lstTableName.Add("@Ｃ２");					    //Ｃ２
                lstTableName.Add("@Ｃ３");					    //Ｃ３
                lstTableName.Add("@Ｃ４");					    //Ｃ４
                lstTableName.Add("@Ｃ５");					    //Ｃ５
                lstTableName.Add("@Ｃ６");					    //Ｃ６
                lstTableName.Add("@発注数量");					//発注数量
                lstTableName.Add("@発注単価");					//発注単価
                lstTableName.Add("@発注金額");				    //発注金額
                lstTableName.Add("@納期");	    		        //納期
                lstTableName.Add("@発注フラグ");	    		//発注フラグ
                lstTableName.Add("@注番");			    		//注番
                lstTableName.Add("@加工区分");					//加工区分
                lstTableName.Add("@仕入先名称");	            //仕入先名称
                lstTableName.Add("@ユーザー名");            	//ユーザー名

                //プロシージャ（戻り値なし）用のメソッドに投げる
                dbconnective.RunSql("発注更新_PROC", CommandType.StoredProcedure, lstData, lstTableName);

                //コミット
                dbconnective.Commit();

                //ビジネス層のインスタンス生成(担当者マスター)
                M1050_Tantousha_B tantoshaB = new M1050_Tantousha_B();

                //担当者のデータを取り出す
                DataTable dtTantosha = tantoshaB.updTxtTantoshaLeave(txtTanto.Text);

                string strChubanMoji = null;

                //注番文字を取得
                strChubanMoji = dtTantosha.Rows[0]["注番文字"].ToString();

                //注番文字がなかった場合
                if (strChubanMoji == "")
                {
                    strChubanMoji = ".";
                }

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU + "\r\n注番:" + strChubanMoji + txtHachuban.Text , CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                delText();

                textSet_Tokuisaki.Focus();
                return;
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
        ///delText
        ///テキストボックス内の文字を削除
        ///</summary>
        private void delText()
        {
            delFormClear(this,gridHachu);

            txtHachusu.Clear();

            //コンボボックスの中身初期化
            cmbHachutan.Items.Clear();

            //記入可能にする
            labelSet_Daibunrui.Enabled = true;
            labelSet_Chubunrui.Enabled = true;
            labelSet_Maker.Enabled = true;
            txtHinmei.Enabled = true;
            lblHinmei.Enabled = true;

            txtHachuYMD.Text = DateTime.Today.ToString();

            txtHachuYMD.Focus();
        }

        ///<summary>
        ///delHachu
        ///テキストボックス内のデータをDBから削除
        ///</summary>
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

        ///<summary>
        ///setShouhin
        ///取り出したデータをテキストボックスに配置（商品リスト）
        ///</summary>
        public void setShouhin(DataTable dtShohin)
        {
            labelSet_Daibunrui.CodeTxtText = dtShohin.Rows[0]["大分類コード"].ToString();
            labelSet_Chubunrui.CodeTxtText = dtShohin.Rows[0]["中分類コード"].ToString();
            labelSet_Maker.CodeTxtText = dtShohin.Rows[0]["メーカーコード"].ToString();
            txtHinmei.Text = dtShohin.Rows[0]["Ｃ１"].ToString();
            cmbHachutan.Text = ((decimal)dtShohin.Rows[0]["仕入単価"]).ToString("#,#.0000");
            lblGrayTanaHon.Text = dtShohin.Rows[0]["棚番本社"].ToString();
            lblGrayTanaGihu.Text = dtShohin.Rows[0]["棚番岐阜"].ToString();
        }

        ///<summary>
        ///setShohinClose
        ///ShohinListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setShohinClose()
        {
            txtHachusu.Focus();
        }

        ///<summary>
        ///setRireki
        ///仕入実績確認を表示
        ///</summary>
        public void setRireki()
        {

        }

        ///<summary>
        ///textSet_Tokuisaki_Leave
        ///仕入先コードから離れた場合
        ///</summary>
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

        ///<summary>
        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void gridHachu_DoubleClick(object sender, EventArgs e)
        {            
            //データグリッドビュー上での共通処理
            setSelectItem();
        }

        ///<summary>
        ///setSelectItem
        ///データグリッドビュー上での共通処理
        ///</summary>
        private void setSelectItem()
        {
            //コンボボックスの中身初期化
            cmbHachutan.Items.Clear();

            //選択したものが空の場合ｓ
            if (gridHachu.Rows.Count == 0)
            {
                return;
            }

            //選択されたデータの"発注番号"を取得
            txtHachuban.Text = (string)gridHachu.CurrentRow.Cells["発注番号"].Value.ToString();

            //データの表示
            setView();
        }

        ///<summary>
        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
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

        ///<summary>
        ///labelSet_Hachusha_Leave
        ///発注者コード入力後に担当者コードテキストに確保
        ///</summary>
        private void labelSet_Hachusha_Leave(object sender, EventArgs e)
        {
            txtTanto.Text = labelSet_Hachusha.CodeTxtText;
        }

        ///<summary>
        ///txtHachuban_Leave
        ///発注番号のチェック
        ///</summary>
        private void txtHachuban_Leave(object sender, EventArgs e)
        {
            //発注番号に記入がない場合
            if (txtHachuban.blIsEmpty() == false)
            {
                return;
            }

            //受注番号の記入を取り消す
            txtJuchuban.Clear();

            //データの表示
            setView();

            Control c = this.ActiveControl;

            textSet_Tokuisaki.Focus();

            c.Focus();

        }

        ///<summary>
        ///setView
        ///データの表示
        ///</summary>
        private void setView()
        {
            //検索時のデータ取り出し先(グリッド全体)
            DataTable dtSetCd;
            //検索時のデータ取り出し先(受注検出時)
            DataTable dtSetCdJuchuNo;
            //検索時のデータ取り出し先(単価検出時)
            DataTable dtSetTanka;
            //検索時のデータ取り出し先(商品)
            DataTable dtSetShohin;

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

                    //戻り値のDatatableを取り込む
                    dtSetTanka = hachuB.setTanka(dtSetCd.Rows[0]["商品コード"].ToString());

                    //条件付き単価が１件以上ある場合
                    if (dtSetTanka.Rows.Count != 0)
                    {
                        //条件付き単価の行数分
                        for (int cnt = 0; cnt < dtSetTanka.Rows.Count; cnt++)
                        {
                            //テキストボックス表示用の0行目
                            if (cnt == 0)
                            {
                                cmbHachutan.Items.Add("");
                            }

                            //各月と日を確保
                            string strMonth = ((DateTime)dtSetTanka.Rows[cnt]["日時"]).Month.ToString();
                            string strDay = ((DateTime)dtSetTanka.Rows[cnt]["日時"]).Day.ToString();

                            //月の桁数が1桁以下の場合
                            if (strMonth.Length <= 1)
                            {
                                strMonth = strMonth.PadLeft(2, '0');
                            }

                            //日の桁数が1桁以下の場合
                            if (strDay.Length <= 1)
                            {
                                strDay = strDay.PadLeft(2, '0');
                            }

                            cmbHachutan.Items.Add(((decimal)dtSetCd.Rows[0]["発注単価"]).ToString("#,#.0000") + ":" + (((DateTime)dtSetTanka.Rows[cnt]["日時"]).Year.ToString()).Substring(2) + "/" + strMonth + "/" + strDay);
                        }
                    }

                    txtHachuYMD.Text = dtSetCd.Rows[0]["発注年月日"].ToString();
                    txtTanto.Text = dtSetCd.Rows[0]["発注者コード"].ToString();
                    labelSet_Hachusha.CodeTxtText = dtSetCd.Rows[0]["発注者コード"].ToString();
                    textSet_Tokuisaki.CodeTxtText = dtSetCd.Rows[0]["仕入先コード"].ToString();
                    txtShohinCd.Text = dtSetCd.Rows[0]["商品コード"].ToString();
                    txtHachusu.Text = ((decimal)dtSetCd.Rows[0]["発注数量"]).ToString("#,#");
                    cmbHachutan.Text = ((decimal)dtSetCd.Rows[0]["発注単価"]).ToString("#,#.0000");
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

                    labelSet_Eigyosho.CodeTxtText = dtSetCd.Rows[0]["営業所コード"].ToString();
                    txtTanto.Text = dtSetCd.Rows[0]["担当者コード"].ToString();

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
                            lblHinmei.Enabled = true;
                        }
                        else
                        {
                            labelSet_Daibunrui.Enabled = false;
                            labelSet_Chubunrui.Enabled = false;
                            labelSet_Maker.Enabled = false;
                            txtHinmei.Enabled = false;
                            lblHinmei.Enabled = false;
                        }
                    }
                    else
                    {
                        labelSet_Daibunrui.Enabled = false;
                        labelSet_Chubunrui.Enabled = false;
                        labelSet_Maker.Enabled = false;
                        txtHinmei.Enabled = false;
                        lblHinmei.Enabled = false;
                    }

                    //商品コードがある場合
                    if (txtShohinCd.Text != "")
                    {
                        //商品
                        dtSetShohin = hachuB.setShohin(txtShohinCd.Text);

                        //発注単価のピリオド取り
                        decimal decHachu = decimal.Parse(dtSetCd.Rows[0]["発注単価"].ToString().Split('.')[0]);

                        //定価のピリオド取り
                        decimal decTeika = decimal.Parse(dtSetShohin.Rows[0]["定価"].ToString().Split('.')[0]);

                        //規定の計算で掛け率を記入
                        txtKakeritsu.Text = ((decimal)(decHachu / decTeika) * 100).ToString("#.0");

                        lblGrayTanaHon.Text = dtSetShohin.Rows[0]["棚番本社"].ToString();
                        lblGrayTanaGihu.Text = dtSetShohin.Rows[0]["棚番岐阜"].ToString();
                    }
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

        ///<summary>
        ///cmbHachutan_Leave
        ///発注単価から離れた時の処理
        ///</summary>
        private void cmbHachutan_Leave(object sender, EventArgs e)
        {
            if (cmbHachutan.Text == "")
            {
                return;
            }

            double dblData;

            //double型に変換できれば
            if (double.TryParse(cmbHachutan.Text.ToString(), out dblData))
            {
                //スルー
            }
            else
            {
                //時間の部分を除去
                cmbHachutan.Text = cmbHachutan.Text.Split(':')[0];
            }

            cmbHachutan.Text = decimal.Parse(cmbHachutan.Text).ToString("#,#.0000");
        }
    }
}
