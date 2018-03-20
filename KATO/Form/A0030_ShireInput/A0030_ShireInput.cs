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
using KATO.Common.Util;
using KATO.Common.Form;
using KATO.Business.A0030_ShireInput;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.M1110_Chubunrui;
using KATO.Common.Business;
using KATO.Form.D0320_SiireJissekiKakunin;

namespace KATO.Form.A0030_ShireInput
{
    ///<summary>
    ///A0030_ShireInput
    ///仕入入力フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class A0030_ShireInput : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //ロックをかけるか否か
        public bool blRock = false;

        //行数(gbでも使用する)
        public int intMaxRow = 4;

        //伝票番号のLeaveの処理をしたかどうか
        bool blDenpyoLeave = false;

        //データ追加時の商品コード確保
        string strShohinCd;

        //各行の情報を入れる配列
        BaseViewDataGroup[] bvg;

        //どこのGroupDataにフォーカスされているか
        public short shotCnt = 0;

        //伝票番号のあるデータが表示されているかどうか
        public Boolean blMODYflg = false;

        D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin shireKakunin = null;
        D0360_JuchuzanKakunin.D0360_JuchuzanKakunin juchuzan = null;
        D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin shohinmoto = null;

        //受注残確認に飛ぶ用
        BaseText txtNull = new BaseText();

        ///<summary>
        ///A0030_ShireInput
        ///フォームの初期設定
        ///</summary>
        public A0030_ShireInput(Control c)
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
        ///A0030_ShireInput_Load
        ///画面レイアウト設定
        ///</summary>
        private void A0030_ShireInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "仕入入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF07.Text = "F7:行削";
            //this.btnF08.Text = "F8:実績";
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            //初期値の設定
            txtYMD.Text = DateTime.Today.ToString();

            DataTable dtTantoshaCd = new DataTable();

            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                //ログインＩＤから担当者コードを取り出す
                dtTantoshaCd = shireinputB.getTantoshaCd(SystemInformation.UserName);

                //担当者データがある場合
                if (dtTantoshaCd.Rows.Count > 0)
                {
                    //一行目にデータがない場合
                    if (dtTantoshaCd.Rows[0][0].ToString() == "")
                    {
                        return;
                    }
                }

                labelSet_Tantousha.CodeTxtText = dtTantoshaCd.Rows[0]["担当者コード"].ToString();
                labelSet_Tantousha.chkTxtTantosha();

                txtEigyouCd.Text = dtTantoshaCd.Rows[0]["営業所コード"].ToString();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

            labelSet_Torihikikbn.CodeTxtText = "21";
            labelSet_Torihikikbn.chkTxtTorihikikbn();

            //伝票Noを触れるようにする
            txtDenpyoNo.Enabled = true;

            cmbSubWinShow.Items.Add("仕入実績確認");
            cmbSubWinShow.Items.Add("受注残・発注残確認");
            cmbSubWinShow.Items.Add("商品元帳確認");

        }

        ///<summary>
        ///A0030_ShireInput_KeyDown
        ///キー入力判定(画面全般）
        ///</summary>
        private void A0030_ShireInput_KeyDown(object sender, KeyEventArgs e)
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
                    this.addShireInput();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delShireInput();
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
                    logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                    this.delGyou();
                    break;
                case Keys.F8:
                    //logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));
                    //this.setShireJisseki();
                    //break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:

                    //仕入実績確認が既に開いている場合        
                    if (shireKakunin != null)
                    {
                        shireKakunin.Close();
                    }

                    //受注残・発注残確認が既に開いている場合        
                    if (juchuzan != null)
                    {
                        juchuzan.Close();
                    }

                    //商品元帳確認が既に開いている場合        
                    if (shohinmoto != null)
                    {
                        shohinmoto.Close();
                    }

                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///txtCD_KeyDown
        ///キー入力判定(コード入力)
        ///</summary>
        private void txtCD_KeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    showTorihikiList();
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
        ///ボタンの反応
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addShireInput();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delShireInput();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F07: // 行削除
                    logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                    this.delGyou();
                    break;
                case STR_BTN_F08: // 履歴
                    //logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));
                    //setShireJisseki();
                    //break;
                case STR_BTN_F12: // 終了
                    
                    //仕入実績確認が既に開いている場合        
                    if (shireKakunin != null)
                    {
                        shireKakunin.Close();
                    }

                    //受注残・発注残確認が既に開いている場合        
                    if (juchuzan != null)
                    {
                        juchuzan.Close();
                    }

                    //商品元帳確認が既に開いている場合        
                    if (shohinmoto != null)
                    {
                        shohinmoto.Close();
                    }

                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///showTorihikiList
        ///空番ボタン、キーの反応
        ///</summary>
        private void showTorihikiList()
        {
            //取引先リストのインスタンス生成
            TorihikisakiList torihikisakilist = new TorihikisakiList(this);
            try
            {
                //取引先リストの表示、画面IDを渡す
                torihikisakilist.intFrmKind = CommonTeisu.FRM_SHIREINPUT;
                torihikisakilist.ShowDialog();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///addShireInput
        ///テキストボックス内のデータをDBに追加
        ///</summary>
        public void addShireInput()
        {
            //伝票番号の確保
            int intDenpyoNo;

            decimal UnchinKin;

            //記入情報登録用
            List<string> lstSaveData = new List<string>();

            //伝票番号がない場合
            if (!StringUtl.blIsEmpty(txtDenpyoNo.Text))
            {
                //ビジネス層のインスタンス生成
                A0030_ShireInput_B shireinputBadd = new A0030_ShireInput_B();
                try
                {
                    //伝票番号を取得
                    intDenpyoNo = shireinputBadd.getDenpyoNo("仕入伝票");

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
            else
            {
                intDenpyoNo = int.Parse(txtDenpyoNo.Text);
            }

            //データのチェック
            if (ChkData() == false)
            {
                return;
            }

            decimal decTry = 0;

            if (decimal.TryParse(txtUnchin.Text, out decTry))
            {
                //運賃をDecimal型に変換
                txtUnchin.Text = decimal.Parse(txtUnchin.Text).ToString();
            }
            else
            {
                txtUnchin.Text = "0";
            }


            //運賃の確保
            UnchinKin = decimal.Parse(string.Format("{0:0}", txtUnchin.Text));
            
            //仕入ヘッダ更新_PROC用
            //年月日
            if (txtYMD.blIsEmpty() == false)
            {
                txtYMD.Text = "";
            }
            //コード
            if (txtCD.blIsEmpty() == false)
            {
                txtCD.Text = "";
            }
            //仕入先名
            if (txtShireNameView.blIsEmpty() == false)
            {
                txtShireNameView.Text = "";
            }
            //郵便番号
            if (txtYubinView.blIsEmpty() == false)
            {
                txtYubinView.Text = "";
            }
            //住所１
            if (txtJusho1View.blIsEmpty() == false)
            {
                txtJusho1View.Text = "";
            }
            //住所２
            if (txtJusho2View.blIsEmpty() == false)
            {
                txtJusho2View.Text = "";
            }
            //取引区分
            if (StringUtl.blIsEmpty(labelSet_Torihikikbn.CodeTxtText) == false)
            {
                labelSet_Torihikikbn.CodeTxtText = "";
            }
            //担当者名
            if (StringUtl.blIsEmpty(labelSet_Tantousha.CodeTxtText) == false)
            {
                labelSet_Tantousha.CodeTxtText = "";
            }
            //営業所コード
            if (txtEigyouCd.blIsEmpty() == false)
            {
                txtEigyouCd.Text = "";
            }
            //DBNull(なし)
            //摘要
            if (txtTekiyo.blIsEmpty() == false)
            {
                txtTekiyo.Text = "";
            }
            //運賃
            if (txtUnchin.blIsEmpty() == false)
            {
                txtUnchin.Text = "";
            }
            //合計
            if (txtGokei.blIsEmpty() == false)
            {
                txtGokei.Text = "";
            }
            //消費税
            if (txtShohizei.blIsEmpty() == false)
            {
                txtShohizei.Text = "";
            }
            //総合計
            if (txtSogokei.blIsEmpty() == false)
            {
                txtSogokei.Text = "";
            }

            //伝票番号[0]
            lstSaveData.Add(intDenpyoNo.ToString());
            //年月日[1]
            lstSaveData.Add(txtYMD.Text);
            //コード[2]
            lstSaveData.Add(txtCD.Text);
            //仕入先名[3]
            lstSaveData.Add(txtShireNameView.Text);
            //郵便番号[4]
            lstSaveData.Add(txtYubinView.Text);
            //住所1[5]
            lstSaveData.Add(txtJusho1View.Text);
            //住所2[6]
            lstSaveData.Add(txtJusho2View.Text);
            //区分[7]
            lstSaveData.Add(labelSet_Torihikikbn.CodeTxtText);
            //担当者[8]
            lstSaveData.Add(labelSet_Tantousha.CodeTxtText);
            //営業所コード[9]
            lstSaveData.Add(txtEigyouCd.Text);
            //摘要コード（無し）[10]
            lstSaveData.Add("");
            //摘要欄[11]
            lstSaveData.Add(txtTekiyo.Text);
            //運賃[12]
            lstSaveData.Add(txtUnchin.Text);
            //合計[13]
            lstSaveData.Add(txtGokei.Text);
            //消費税[14]
            lstSaveData.Add(txtShohizei.Text);
            //総合計[15]
            lstSaveData.Add(txtSogokei.Text);
            //直送先コード（無し）[16]
            lstSaveData.Add("");
            //直送先名（無し）[17]
            lstSaveData.Add("");
            //直送先郵便番号（無し）[18]
            lstSaveData.Add("");
            //直送先住所1（無し）[19]
            lstSaveData.Add("");
            //直送先住所2（無し）[20]
            lstSaveData.Add("");
            //ユーザー名[21]
            lstSaveData.Add(SystemInformation.UserName);

            //商品マスタ更新用
            List<string> lstMasterKoshin = new List<string>();
            //商品コード取得用
            List<string> lstSetShohinData = new List<string>();
            //仕入明細更新用
            List<string> lstMesaiKoshin = new List<string>();
            //発注単価更新用
            List<string> lstHachutanKoshin = new List<string>();
            //仕入単価更新用
            List<string> lstShireTanka = new List<string>();
            //受注商品コード更新用
            List<string> lstJuchuShohinCd = new List<string>();
            //受注番号の数量取得用
            List<string> lstJuchuNoCnt = new List<string>();
            //受注仕入単価商品コードの更新用
            List<string> lstShireShohin = new List<string>();
            //運賃を仕入明細に追加する用
            List<string> lstShireUnchin = new List<string>();

            //受注データの確保用
            DataTable dtJuchuData = new DataTable();
            //発注データの確保用
            DataTable dtHachuData = new DataTable();
            //商品コードの確保用
            DataTable dtShohinCd = new DataTable();
            //受注データカウントの確保用
            DataTable dtJuchuDataCnt = new DataTable();
            //受注データカウント(受注番号が1以上の場合の処理)の確保用
            DataTable dtJuchuDataCntNO = new DataTable();
            
            //型番確保用
            string strKataban = "";

            //加工受注かどうかの判断
            bool blKakojuchu = false;

            //加工品仕入単価
            int intKakoShireTanka = 0;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();

            DBConnective con = new DBConnective();
            KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B juchuB = new KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B();

            con = new DBConnective();
            con.BeginTrans();










            try
            {
                //登録(仕入ヘッダ更新_PROC,発注_仕入数_戻し更新_PROC,仕入明細消去_PROC)
                shireinputB.addShire(lstSaveData);

                //各行のチェック
                for (int intCnt = 0; intCnt < bvg.Length; intCnt++)
                {
                    //注文番号に記入がある場合
                    if (StringUtl.blIsEmpty(bvg[intCnt].txtChumonNo.Text))
                    {
                        //商品コードがない場合は、新規商品として扱う
                        if (!StringUtl.blIsEmpty(bvg[intCnt].txtShohinCd.Text))
                        {
                            bvg[intCnt].txtShohinCd.Text = "88888";
                        }

                        ///新規商品の場合
                        if (bvg[intCnt].txtShohinCd.Text == "88888")
                        {
                            strKataban = bvg[intCnt].txtC1.Text + bvg[intCnt].txtC2.Text + bvg[intCnt].txtC3.Text + bvg[intCnt].txtC4.Text + bvg[intCnt].txtC5.Text + bvg[intCnt].txtC6.Text;

                            lstSetShohinData.Add(bvg[intCnt].txtMakerCd.Text);
                            lstSetShohinData.Add(bvg[intCnt].txtDaibunCd.Text);
                            lstSetShohinData.Add(bvg[intCnt].txtChubunCd.Text);
                            lstSetShohinData.Add(strKataban);

                            //商品コードの確保
                            dtShohinCd = getShohinCd(lstSetShohinData);

                            //データが一つ以上ある場合
                            if (dtShohinCd.Rows.Count > 0)
                            {
                                strShohinCd = dtShohinCd.Rows[0]["商品コード"].ToString();
                            }
                            else
                            {
                                //ビジネス層のインスタンス生成
                                A0030_ShireInput_B shireinputBadd = new A0030_ShireInput_B();
                                try
                                {
                                    //商品コード取得
                                    strShohinCd = shireinputBadd.getNewShohinNo();

                                    //商品マスタ更新のための情報
                                    List<string> lstShireMesaiKoshin = new List<string>();
                                    lstShireMesaiKoshin.Add(bvg[intCnt].txtShohinCd.Text);  //商品コード
                                    lstShireMesaiKoshin.Add(bvg[intCnt].txtMakerCd.Text);   //メーカーコード
                                    lstShireMesaiKoshin.Add(bvg[intCnt].txtDaibunCd.Text);  //大分類コード
                                    lstShireMesaiKoshin.Add(bvg[intCnt].txtChubunCd.Text);  //中分類コード
                                    lstShireMesaiKoshin.Add(bvg[intCnt].txtC1.Text);        //C1
                                    lstShireMesaiKoshin.Add("");                            //C2
                                    lstShireMesaiKoshin.Add("");                            //C3
                                    lstShireMesaiKoshin.Add("");                            //C4
                                    lstShireMesaiKoshin.Add("");                            //C5
                                    lstShireMesaiKoshin.Add("");                            //C6
                                    lstShireMesaiKoshin.Add("Y");                           //発注区分
                                    lstShireMesaiKoshin.Add("0");                           //標準売価
                                    lstShireMesaiKoshin.Add(bvg[intCnt].txtTanka.Text);     //仕入単価
                                    lstShireMesaiKoshin.Add("0");                           //在庫管理区分
                                    lstShireMesaiKoshin.Add("000000");                      //棚番本社
                                    lstShireMesaiKoshin.Add("000000");                      //棚番岐阜
                                    lstShireMesaiKoshin.Add("");                            //メモ
                                    lstShireMesaiKoshin.Add(bvg[intCnt].txtTanka.Text);     //評価単価
                                    lstShireMesaiKoshin.Add("0");                           //定価
                                    lstShireMesaiKoshin.Add("1");                           //箱入数
                                    lstShireMesaiKoshin.Add("0");                           //建値仕入単価
                                    lstShireMesaiKoshin.Add("");                            //コメント
                                    lstShireMesaiKoshin.Add(SystemInformation.UserName);    //ユーザー名

                                    //商品マスタ更新
                                    shireinputBadd.addMasterKoshin(lstShireMesaiKoshin);
                                }
                                catch (Exception ex)
                                {
                                    //データロギング
                                    new CommonException(ex);
                                    //例外発生メッセージ（OK）
                                    BaseMessageBox basemessageboxToroku = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                    basemessageboxToroku.ShowDialog();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            //商品コードの確保
                            strShohinCd = bvg[intCnt].txtShohinCd.Text;
                        }

                        lstMesaiKoshin = new List<string>();

                        //仕入明細更新用のデータ追加
                        lstMesaiKoshin.Add(intDenpyoNo.ToString());                                             //伝票番号
                        lstMesaiKoshin.Add((intCnt + 1).ToString() );                                           //行番号
                        lstMesaiKoshin.Add(bvg[intCnt].txtChumonNo.Text);                                       //発注番号
                        lstMesaiKoshin.Add(strShohinCd);                                                        //商品コード
                        lstMesaiKoshin.Add(bvg[intCnt].txtMakerCd.Text);                                        //メーカーコード
                        lstMesaiKoshin.Add(bvg[intCnt].txtDaibunCd.Text);                                       //大分類コード
                        lstMesaiKoshin.Add(bvg[intCnt].txtChubunCd.Text);                                       //中分類コード
                        lstMesaiKoshin.Add(bvg[intCnt].txtC1.Text);                                             //C1
                        lstMesaiKoshin.Add(bvg[intCnt].txtC2.Text);                                             //C2
                        lstMesaiKoshin.Add(bvg[intCnt].txtC3.Text);                                             //C3
                        lstMesaiKoshin.Add(bvg[intCnt].txtC4.Text);                                             //C4
                        lstMesaiKoshin.Add(bvg[intCnt].txtC5.Text);                                             //C5
                        lstMesaiKoshin.Add(bvg[intCnt].txtC6.Text);                                             //C6
                        lstMesaiKoshin.Add(bvg[intCnt].txtSu.Text);                                             //数量
                        lstMesaiKoshin.Add(string.Format("{0:0.0#}", double.Parse(bvg[intCnt].txtTanka.Text)));  //仕入単価
                        lstMesaiKoshin.Add(bvg[intCnt].txtKin.Text);                                            //仕入金額
                        lstMesaiKoshin.Add(bvg[intCnt].txtBiko.Text);                                           //備考
                        lstMesaiKoshin.Add(bvg[intCnt].labelSet_Eigyosho.CodeTxtText);                          //入庫倉庫
                        lstMesaiKoshin.Add(SystemInformation.UserName);                                         //ユーザー名

                        //仕入明細更新
                        shireinputB.addShireMesaiKoshin(lstMesaiKoshin);

                        //発注データの発注単価更新用のデータ追加
                        lstHachutanKoshin.Add(string.Format("{0:0.#}", double.Parse(bvg[intCnt].txtTanka.Text)));
                        lstHachutanKoshin.Add(strShohinCd);
                        lstHachutanKoshin.Add(bvg[intCnt].txtChumonNo.Text);

                        //発注データの発注単価更新  
                        shireinputB.addHachuTankaKoshin(lstHachutanKoshin);

                        //発注データの発注金額更新
                        shireinputB.addHachuKinKoshin(bvg[intCnt].txtChumonNo.Text);

                        //発注データの有無
                        dtHachuData = shireinputB.getHachuData(bvg[intCnt].txtChumonNo.Text);

                        //発注データが一件以上ある場合
                        if (dtHachuData.Rows.Count > 0)
                        {
                            //受注番号が1以上の場合
                            if (int.Parse(dtHachuData.Rows[0]["受注番号"].ToString()) > 0)
                            {
                                //加工をしない判定
                                blKakojuchu = false;

                                //受注データのカウント取得
                                dtJuchuDataCnt = shireinputB.getJuchuDataCnt(dtHachuData.Rows[0]["受注番号"].ToString());

                                //カウント1以上の場合
                                if (int.Parse(dtJuchuDataCnt.Rows[0][0].ToString()) > 0)
                                {
                                    //加工をする判定
                                    blKakojuchu = true;
                                }

                                //加工をする判定の場合
                                if (blKakojuchu)
                                {
                                    //加工品仕入単価の取得
                                    intKakoShireTanka = int.Parse((shireinputB.getKakoShireTanka(dtHachuData.Rows[0]["受注番号"].ToString())).ToString());

                                    //受注データの仕入単価更新用
                                    lstShireTanka.Add(intKakoShireTanka.ToString());
                                    lstShireTanka.Add(bvg[intCnt].txtChumonNo.Text);

                                    //受注データの仕入単価更新
                                    shireinputB.addShiretanka(lstShireTanka);

                                    strKataban = bvg[intCnt].txtC1.Text + bvg[intCnt].txtC2.Text + bvg[intCnt].txtC3.Text + bvg[intCnt].txtC4.Text + bvg[intCnt].txtC5.Text + bvg[intCnt].txtC6.Text;

                                    //受注商品コード更新用
                                    lstJuchuShohinCd.Add(strShohinCd);
                                    lstJuchuShohinCd.Add(dtHachuData.Rows[0]["受注番号"].ToString());
                                    lstJuchuShohinCd.Add(strKataban);

                                    //受注データの商品コード更新
                                    shireinputB.addJuchuShohinCd(lstJuchuShohinCd);
                                }
                                else
                                {
                                    strKataban = bvg[intCnt].txtC1.Text + bvg[intCnt].txtC2.Text + bvg[intCnt].txtC3.Text + bvg[intCnt].txtC4.Text + bvg[intCnt].txtC5.Text + bvg[intCnt].txtC6.Text;

                                    //受注番号がある場合用の受注データのカウントを取得用
                                    lstJuchuNoCnt.Add(dtHachuData.Rows[0]["受注番号"].ToString());
                                    lstJuchuNoCnt.Add(strKataban);

                                    //受注番号がある場合用の受注データのカウントを取得
                                    dtJuchuDataCntNO = shireinputB.getJuchuDataCntNO(lstJuchuNoCnt);

                                    //カウント1以上の場合
                                    if (int.Parse(dtJuchuDataCntNO.Rows[0][0].ToString()) > 0)
                                    {
                                        //受注データの単価と商品コードの更新用
                                        lstShireShohin.Add(bvg[intCnt].txtTanka.Text);
                                        lstShireShohin.Add(strShohinCd);
                                        lstShireShohin.Add(dtJuchuDataCntNO.Rows[0][0].ToString());

                                        //受注データの単価と商品コードの更新
                                        shireinputB.addJuchuShireShohin(lstShireShohin);
                                    }
                                }
                            }
                        }

                        juchuB.updZaiko(bvg[intCnt].txtShohinCd.Text, txtEigyouCd.Text, txtYMD.Text, Environment.UserName, con);

                    }//注文番号の有り無し
                }//ループ終了

                //運賃の更新

                int intGyoCnt = 0;
                decimal[] arrUnchin = new decimal[7];
                int[] arrJuchuNo = new int[7];
                decimal decKin;
                decimal decKinSub;

                //運賃が0以外のものだった場合
                if (txtUnchin.Text != "0")
                {
                    //行数分
                    for (int intCnt = 0; intCnt < intMaxRow; intCnt++)
                    {
                        arrUnchin[intCnt] = 0;
                        arrJuchuNo[intCnt] = 0;
                    }

                    //受注番号のデータが空でない、且つ1以上の場合(1行目)
                    if (StringUtl.blIsEmpty(txtJuchu1.Text) == true && Int64.Parse(txtJuchu1.Text) > 0)
                    {
                        arrJuchuNo[intGyoCnt] = int.Parse(txtJuchu1.Text);
                        intGyoCnt = intGyoCnt + 1;
                    }
                    //受注番号のデータが空でない、且つ1以上の場合(2行目)
                    if (StringUtl.blIsEmpty(txtJuchu2.Text) == true && Int64.Parse(txtJuchu2.Text) > 0)
                    {
                        arrJuchuNo[intGyoCnt] = int.Parse(txtJuchu2.Text);
                        intGyoCnt = intGyoCnt + 1;
                    }
                    //受注番号のデータが空でない、且つ1以上の場合(3行目)
                    if (StringUtl.blIsEmpty(txtJuchu3.Text) == true && Int64.Parse(txtJuchu3.Text) > 0)
                    {
                        arrJuchuNo[intGyoCnt] = int.Parse(txtJuchu3.Text);
                        intGyoCnt = intGyoCnt + 1;
                    }
                    //受注番号のデータが空でない、且つ1以上の場合(4行目)
                    if (StringUtl.blIsEmpty(txtJuchu4.Text) == true && Int64.Parse(txtJuchu4.Text) > 0)
                    {
                        arrJuchuNo[intGyoCnt] = int.Parse(txtJuchu4.Text);
                        intGyoCnt = intGyoCnt + 1;
                    }
                    //受注番号のデータが空でない、且つ1以上の場合(5行目)
                    if (StringUtl.blIsEmpty(txtJuchu5.Text) == true && Int64.Parse(txtJuchu5.Text) > 0)
                    {
                        arrJuchuNo[intGyoCnt] = int.Parse(txtJuchu5.Text);
                        intGyoCnt = intGyoCnt + 1;
                    }

                    //行数カウントが1以上の場合
                    if (intGyoCnt > 0)
                    {
                        decKin = Int64.Parse(string.Format("{0:0.#}", Int64.Parse(txtUnchin.Text) / intGyoCnt));

                        //decKinとtxtUnchinが0の場合
                        if (decKin.ToString() != "0" || int.Parse(txtUnchin.Text).ToString() != "0")
                        {
                            decKinSub = Int64.Parse(string.Format("{0:0.#}", Int64.Parse(txtUnchin.Text))) - (decKin * intGyoCnt);
                        }
                        else
                        {
                            decKinSub = 0;
                        }

                        //
                        for (int intCnt = 0; intCnt <= intGyoCnt - 2; intCnt++)
                        {
                            arrUnchin[intCnt] = decKin;
                        }

                        arrUnchin[intGyoCnt - 1] = decKin + decKinSub;

                        //運賃消去PROC
                        shireinputB.addUnchinShokyo(txtDenpyoNo.Text);

                        //行数分ループ
                        for (int intCnt = 0; intCnt < intGyoCnt; intCnt++)
                        {
                            //運賃更新PROC用
                            List<string> lstUnchinKoshin = new List<string>();
                            lstUnchinKoshin.Add(txtDenpyoNo.Text);
                            lstUnchinKoshin.Add(arrJuchuNo[intCnt].ToString());
                            lstUnchinKoshin.Add(arrUnchin[intCnt].ToString());
                            lstUnchinKoshin.Add(SystemInformation.UserName);

                            //運賃更新PROC
                            shireinputB.addUnchinKoshin(lstUnchinKoshin);
                        }

                        //運賃を仕入明細に追加用
                        //伝票番号
                        lstShireUnchin.Add(txtDenpyoNo.Text);
                        //行番号
                        lstShireUnchin.Add("99");
                        //発注番号
                        lstShireUnchin.Add("0");
                        //商品コード
                        lstShireUnchin.Add("00000");
                        //メーカーコード
                        lstShireUnchin.Add("000");
                        //大分類コード
                        lstShireUnchin.Add("28");
                        //中分類コード
                        lstShireUnchin.Add("01");
                        //Ｃ１
                        lstShireUnchin.Add("運賃");
                        //Ｃ２
                        lstShireUnchin.Add(" ");
                        //Ｃ３
                        lstShireUnchin.Add(" ");
                        //Ｃ４
                        lstShireUnchin.Add(" ");
                        //Ｃ５
                        lstShireUnchin.Add(" ");
                        //Ｃ６
                        lstShireUnchin.Add(" ");
                        //数量
                        lstShireUnchin.Add("1");
                        //仕入単価
                        lstShireUnchin.Add(txtUnchin.Text);
                        //仕入金額
                        lstShireUnchin.Add(txtUnchin.Text);
                        //備考
                        lstShireUnchin.Add(" ");
                        //入庫倉庫
                        lstShireUnchin.Add(txtEigyouCd.Text);
                        //ユーザー名
                        lstShireUnchin.Add(SystemInformation.UserName);
                        //運賃を仕入明細に追加
                        shireinputB.addShireUnchinKoshin(lstShireUnchin);
                    }
                }

                con.Commit();

                //登録完了メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //テキストボックスを白紙にする
                delText();
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
        ///setMasterKoshinValue
        ///マスター更新用のリスト作成
        ///</summary>
        private List<string> setMasterKoshinValue(BaseViewDataGroup gbData)
        {
            //各行の保存するデータを入れる用
            List<string> lstSaveData = new List<string>();

            //型番確保
            string strKataban;

            //注文Noが入力されていない場合
            if (StringUtl.blIsEmpty(gbData1.txtChubunCd.Text) == false)
            {
                return(lstSaveData);
            }

            //手入力の場合は新規商品として追加登録 加工発注を含む
            if (StringUtl.blIsEmpty(gbData.txtShohinCd.Text) == false)
            {
                gbData1.txtShohinCd.Text = "88888";
            }

            ///新規商品の場合
            if (gbData1.txtShohinCd.Text == "88888")
            {
                strKataban = gbData1.txtC1.Text.ToString() + gbData1.txtC2 + gbData1.txtC3 + gbData1.txtC4 + gbData1.txtC5 + gbData1.txtC6;

                //商品コード
                lstSaveData.Add(gbData.txtChubunCd.Text);
                //メーカーコード
                lstSaveData.Add(gbData.txtMakerCd.Text);
                //大分類コード
                lstSaveData.Add(gbData.txtDaibunCd.Text);
                //中分類コード
                lstSaveData.Add(gbData.txtChubunCd.Text);
                //Ｃ１
                lstSaveData.Add(gbData.txtC1.Text);
                //Ｃ２
                lstSaveData.Add(gbData.txtC2.Text);
                //Ｃ３
                lstSaveData.Add(gbData.txtC3.Text);
                //Ｃ４
                lstSaveData.Add(gbData.txtC4.Text);
                //Ｃ５
                lstSaveData.Add(gbData.txtC5.Text);
                //Ｃ６
                lstSaveData.Add(gbData.txtC6.Text);
                //発注区分
                lstSaveData.Add("Y");
                //標準売価
                lstSaveData.Add("0");
                //仕入単価
                lstSaveData.Add(gbData.txtTanka.Text);
                //在庫管理区分
                lstSaveData.Add("0");
                //棚番本社
                lstSaveData.Add("000000");
                //棚番岐阜
                lstSaveData.Add("000000");
                //メモ
                lstSaveData.Add("");
                //評価単価
                lstSaveData.Add(gbData.txtTanka.Text);
                //定価
                lstSaveData.Add("0");
                //箱入数
                lstSaveData.Add("1");
                //ユーザー名
                lstSaveData.Add(SystemInformation.UserName);
            }
            else
            {
                //商品コードの確保
                strShohinCd = gbData.txtShohinCd.Text;
            }

            return lstSaveData;
        }

        ///<summary>
        ///setShireKoshinValue
        ///仕入明細更新用のリスト作成
        ///</summary>
        private List<string> setShireKoshinValue(BaseViewDataGroup gbData, int intCnt)
        {
            //各行の保存するデータを入れる用
            List<string> lstSaveData = new List<string>();

            //伝票番号
            lstSaveData.Add(txtDenpyoNo.Text);
            //行番号
            lstSaveData.Add((intCnt + 1).ToString());
            //発注番号
            lstSaveData.Add(gbData.txtChumonNo.Text);
            //大分類コード
            lstSaveData.Add(gbData.txtDaibunCd.Text);
            //中分類コード
            lstSaveData.Add(gbData.txtChubunCd.Text);
            //Ｃ１
            lstSaveData.Add(gbData.txtC1.Text);
            //Ｃ２
            lstSaveData.Add(gbData.txtC2.Text);
            //Ｃ３
            lstSaveData.Add(gbData.txtC3.Text);
            //Ｃ４
            lstSaveData.Add(gbData.txtC4.Text);
            //Ｃ５
            lstSaveData.Add(gbData.txtC5.Text);
            //Ｃ６
            lstSaveData.Add(gbData.txtC6.Text);
            //数量
            lstSaveData.Add(gbData.txtSu.Text);
            //仕入単価
            lstSaveData.Add(gbData.txtTanka.Text);
            //仕入金額
            lstSaveData.Add(gbData.txtKin.Text);
            //備考
            lstSaveData.Add(gbData.txtBiko.Text);
            //入庫倉庫
            lstSaveData.Add(gbData.labelSet_Eigyosho.CodeTxtText);
            //ユーザー名
            lstSaveData.Add(SystemInformation.UserName);

            return lstSaveData;
        }


        ///<summary>
        ///delShireInput
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delShireInput()
        {
            //営業所コードと伝票番号の空文字判定
            if (txtEigyouCd.blIsEmpty() == false || txtDenpyoNo.blIsEmpty() == false)
            {
                delText();
                txtYMD.Focus();
                return;
            }

            //年月日テキスト内が年月日として成り立たない場合
            if(txtYMD.updCalendarLeave(txtYMD.Text) == false)
            {
                delText();
                txtYMD.Focus();
                return;
            }

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();

            DBConnective con = null;
            KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B juchuB = new KATO.Business.A0010_JuchuInput.A0010_JuchuInput_B();

            con = new DBConnective();

            try
            {
                //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }
                DataTable dt = shireinputB.getShohins(txtDenpyoNo.Text);
                //仕入入力情報の削除
                shireinputB.delShireInput(txtDenpyoNo.Text ,SystemInformation.UserName);

                if (dt != null)
                {
                    con.BeginTrans();
                    foreach (DataRow dr in dt.Rows)
                    {
                        juchuB.updZaiko(dr["商品コード"].ToString(), txtEigyouCd.Text, txtYMD.Text, Environment.UserName, con);
                    }
                    con.Commit();
                }

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //テキストボックスを白紙にする
                delText();

                txtYMD.Focus();

            }
            catch (Exception ex)
            {
                con.Rollback();
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///delGyou
        ///行削除
        ///</summary>
        public void delGyou()
        {
            //行削除前メッセージ（YES NO）
            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "選択中の行を削除します。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

            //YESが押された場合
            if (basemessagebox.ShowDialog() == DialogResult.Yes)
            {
                //フォーカス位置を確保
                Control cActiveBefore = this.ActiveControl;

                if (cActiveBefore.Name.ToString() == "gbData1")
                {
                    gbData1.delText();

                    //伝票番号がある場合
                    if (txtDenpyoNo.blIsEmpty())
                    {
                        //2行目以降を上にずらす
                        setGbData1();

                        shotCnt = 1;
                        gbData1.setRiekiritu(false);

                        if (gbData1.txtChubunCd.Text == "")
                        {
                            txtJuchu1.Clear();
                            txtTanka1.Clear();
                        }

                        setGbData2();

                        shotCnt = 2;
                        gbData2.setRiekiritu(false);

                        if (gbData2.txtChubunCd.Text == "")
                        {
                            txtJuchu2.Clear();
                            txtTanka2.Clear();
                        }

                        setGbData3();

                        shotCnt = 3;
                        gbData3.setRiekiritu(false);

                        if (gbData3.txtChubunCd.Text == "")
                        {
                            txtJuchu3.Clear();
                            txtTanka3.Clear();
                        }

                        setGbData4();

                        shotCnt = 4;
                        gbData4.setRiekiritu(false);

                        if (gbData4.txtChubunCd.Text == "")
                        {
                            txtJuchu4.Clear();
                            txtTanka4.Clear();
                        }

                        setNullGbData5();

                        gbData1.setGokeiKesan();
                    }
                    else
                    {
                        //2行目以降を上にずらす
                        setGbData1();

                        shotCnt = 1;
                        gbData1.setRiekiritu(true);

                        if (gbData1.txtChubunCd.Text == "")
                        {
                            txtJuchu1.Clear();
                            txtTanka1.Clear();
                        }

                        setGbData2();

                        shotCnt = 2;
                        gbData2.setRiekiritu(true);

                        if (gbData2.txtChubunCd.Text == "")
                        {
                            txtJuchu2.Clear();
                            txtTanka2.Clear();
                        }

                        setGbData3();

                        shotCnt = 3;
                        gbData3.setRiekiritu(true);

                        if (gbData3.txtChubunCd.Text == "")
                        {
                            txtJuchu3.Clear();
                            txtTanka3.Clear();
                        }

                        setGbData4();

                        shotCnt = 4;
                        gbData4.setRiekiritu(true);

                        if (gbData4.txtChubunCd.Text == "")
                        {
                            txtJuchu4.Clear();
                            txtTanka4.Clear();
                        }

                        setNullGbData5();
                    }

                    gbData5.delText();

                    gbData1.setGokeiKesan();

                    shotCnt = 1;
                }
                if (cActiveBefore.Name.ToString() == "gbData2")
                {
                    gbData2.delText();

                    //3行目以降を上にずらす
                    //伝票番号がある場合
                    if (txtDenpyoNo.blIsEmpty())
                    {
                        setGbData2();

                        shotCnt = 2;
                        gbData2.setRiekiritu(false);

                        if (gbData2.txtChubunCd.Text == "")
                        {
                            txtJuchu2.Clear();
                            txtTanka2.Clear();
                        }

                        setGbData3();

                        shotCnt = 3;
                        gbData3.setRiekiritu(false);

                        if (gbData3.txtChubunCd.Text == "")
                        {
                            txtJuchu3.Clear();
                            txtTanka3.Clear();
                        }

                        setGbData4();

                        shotCnt = 4;
                        gbData4.setRiekiritu(false);

                        if (gbData4.txtChubunCd.Text == "")
                        {
                            txtJuchu4.Clear();
                            txtTanka4.Clear();
                        }

                        setNullGbData5();
                    }
                    else
                    {
                        setGbData2();

                        shotCnt = 2;
                        gbData2.setRiekiritu(true);

                        if (gbData2.txtChubunCd.Text == "")
                        {
                            txtJuchu2.Clear();
                            txtTanka2.Clear();
                        }

                        setGbData3();

                        shotCnt = 3;
                        gbData3.setRiekiritu(true);

                        if (gbData3.txtChubunCd.Text == "")
                        {
                            txtJuchu3.Clear();
                            txtTanka3.Clear();
                        }

                        setGbData4();

                        shotCnt = 4;
                        gbData4.setRiekiritu(true);

                        if (gbData4.txtChubunCd.Text == "")
                        {
                            txtJuchu4.Clear();
                            txtTanka4.Clear();
                        }

                        setNullGbData5();

                    }

                    gbData5.delText();

                    gbData1.setGokeiKesan();

                    shotCnt = 2;
                }
                if (cActiveBefore.Name.ToString() == "gbData3")
                {
                    gbData3.delText();

                    //4行目以降を上にずらす
                    //伝票番号がある場合
                    if (txtDenpyoNo.blIsEmpty())
                    {
                        setGbData3();

                        shotCnt = 3;
                        gbData3.setRiekiritu(false);

                        if (gbData3.txtChubunCd.Text == "")
                        {
                            txtJuchu3.Clear();
                            txtTanka3.Clear();
                        }

                        setGbData4();

                        shotCnt = 4;
                        gbData4.setRiekiritu(false);

                        if (gbData4.txtChubunCd.Text == "")
                        {
                            txtJuchu4.Clear();
                            txtTanka4.Clear();
                        }

                        setNullGbData5();
                    }
                    else
                    {
                        setGbData3();

                        shotCnt = 3;
                        gbData3.setRiekiritu(true);

                        if (gbData3.txtChubunCd.Text == "")
                        {
                            txtJuchu3.Clear();
                            txtTanka3.Clear();
                        }

                        setGbData4();

                        shotCnt = 4;
                        gbData4.setRiekiritu(true);

                        if (gbData4.txtChubunCd.Text == "")
                        {
                            txtJuchu4.Clear();
                            txtTanka4.Clear();
                        }

                        setNullGbData5();

                    }

                    gbData5.delText();

                    gbData1.setGokeiKesan();

                    shotCnt = 3;
                }
                if (cActiveBefore.Name.ToString() == "gbData4")
                {
                    gbData4.delText();

                    //5行目を上にずらす
                    //伝票番号がある場合
                    if (txtDenpyoNo.blIsEmpty())
                    {
                        setGbData4();

                        shotCnt = 4;
                        gbData4.setRiekiritu(false);

                        if (gbData4.txtChubunCd.Text == "")
                        {
                            txtJuchu4.Clear();
                            txtTanka4.Clear();
                        }

                        setNullGbData5();
                    }
                    else
                    {
                        setGbData4();

                        shotCnt = 4;
                        gbData4.setRiekiritu(true);

                        if (gbData4.txtChubunCd.Text == "")
                        {
                            txtJuchu4.Clear();
                            txtTanka4.Clear();
                        }

                        setNullGbData5();

                    }

                    gbData5.delText();

                    gbData1.setGokeiKesan();

                    shotCnt = 4;
                }
                if (cActiveBefore.Name.ToString() == "gbData5")
                {
                    gbData5.delText();

                    setNullGbData5();

                    gbData1.setGokeiKesan();

                    shotCnt = 5;
                }
            }
        }

        ///<summary>
        ///delText
        ///テキストボックス等の入力情報を白紙にする
        ///</summary>
        public void delText()
        {
            //テキスト確保
            string strYMD = txtYMD.Text;
            string strTantoCd = labelSet_Tantousha.CodeTxtText;
            string strKbnCd = labelSet_Torihikikbn.CodeTxtText;
            string strEigyoshoCd = txtEigyouCd.Text;

            //画面の項目内を白紙にする
            delFormClear(this);
            btnF01.Enabled = true;
            btnF03.Enabled = true;
            btnF07.Enabled = true;

            txtYMD.Text = strYMD;
            labelSet_Tantousha.CodeTxtText = strTantoCd;
            labelSet_Tantousha.chkTxtTantosha();
            labelSet_Torihikikbn.CodeTxtText = strKbnCd;
            labelSet_Torihikikbn.chkTxtTorihikikbn();
            txtEigyouCd.Text = strEigyoshoCd;

            //伝票Noを触れるようにする
            txtDenpyoNo.Enabled = true;

            //各行の削除
            gbData1.delText();
            gbData2.delText();
            gbData3.delText();
            gbData4.delText();
            gbData5.delText();

            txtYMD.Focus();
        }

        ///<summary>
        ///setShireJisseki
        ///仕入実績画面へ
        ///</summary>
        public void setShireJisseki()
        {
            //コード未記入の場合
            if (!StringUtl.blIsEmpty(txtCD.Text))
            {
                return;
            }

            //仕入実績確認が既に開いている場合        
            if (shireKakunin != null && shireKakunin.Visible)
            {
                shireKakunin.Activate();
                return;
            }

            shireKakunin = new Form.D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin(this, 3, txtCD.Text);

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

            shireKakunin.StartPosition = FormStartPosition.Manual;
            shireKakunin.Location = s.Bounds.Location;

            //仕入実績確認画面へ移動
            shireKakunin.Show();
        }

        ///<summary>
        ///setDenpyo
        ///伝票番号から各種データを取得
        ///</summary>
        public void setDenpyo(object sender, EventArgs e)
        {
            //次のフォーカス位置を確保
            Control cActiveBefore = this.ActiveControl;

            //初期値に戻す
            blMODYflg = true;

            //伝票番号の処理が1度でもあった場合
            if (blDenpyoLeave == true)
            {
                //伝票番号を入力させないようにする


                //初期化
                blDenpyoLeave = false;
                return;
            }

            //伝票番号の記入がない場合
            if (!StringUtl.blIsEmpty(txtDenpyoNo.Text))
            {
                cActiveBefore.Focus();
                return;
            }

            //品名データを作成する用
            string strHinmei = "";

            //検収済仕入明細のカウント
            int intKenshuShireCnt;

            //ロックをかける
            blRock = true;

            //検索時のデータ取り出し先（仕入ヘッダー）
            DataTable dtSetShireHeader = null;
            //検索時のデータ取り出し先（検収済仕入明細）
            DataTable dtSetKenshuzumishire = null;
            //検索時のデータ取り出し先（仕入明細）
            DataTable dtSetshire = null;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                //戻り値のDatatableを取り込む(仕入ヘッダー内の検索)
                dtSetShireHeader = shireinputB.getShireHeader(txtDenpyoNo.Text);

                //検索結果にデータが存在するなら
                if (dtSetShireHeader.Rows.Count > 0)
                {
                    txtYMD.Text = dtSetShireHeader.Rows[0]["伝票年月日"].ToString();
                    txtCD.Text = dtSetShireHeader.Rows[0]["仕入先コード"].ToString();
                    txtShireNameView.Text = dtSetShireHeader.Rows[0]["仕入先名"].ToString();
                    txtYubinView.Text = dtSetShireHeader.Rows[0]["郵便番号"].ToString();
                    txtJusho1View.Text = dtSetShireHeader.Rows[0]["住所１"].ToString();
                    txtJusho2View.Text = dtSetShireHeader.Rows[0]["住所２"].ToString();
                    labelSet_Torihikikbn.CodeTxtText = dtSetShireHeader.Rows[0]["取引区分"].ToString();
                    labelSet_Tantousha.CodeTxtText = dtSetShireHeader.Rows[0]["担当者コード"].ToString();
                    txtEigyouCd.Text = dtSetShireHeader.Rows[0]["営業所コード"].ToString();
                    txtTekiyo.Text = dtSetShireHeader.Rows[0]["摘要欄"].ToString();
                    txtUnchin.Text = (decimal.Parse(dtSetShireHeader.Rows[0]["運賃"].ToString())).ToString("#,0");

                    //数値の入る各項目がnullの場合0を入れる
                    if (txtGokei.Text == "")
                    {
                        txtGokei.Text = "0";
                    }
                    if (txtShohizei.Text == "")
                    {
                        txtShohizei.Text = "0";
                    }
                    if (txtSogokei.Text == "0")
                    {
                        txtSogokei.Text = "0";
                    }
                    if (txtUnchin.Text == "")
                    {
                        txtUnchin.Text = "0";
                    }

                    //検収済仕入明細のカウント取得
                    dtSetKenshuzumishire = shireinputB.getKenshuShire(txtDenpyoNo.Text);

                    intKenshuShireCnt = int.Parse(dtSetKenshuzumishire.Rows[0]["カウント"].ToString());

                    //年月日チェックをしたときにfalseの場合
                    if (StringUtl.judHidukeCheck("3", txtEigyouCd.Text, DateTime.Parse(txtYMD.Text)) == false)
                    {
                        //例外発生メッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "日付が範囲外です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                    }

                    //1以上の場合
                    if (intKenshuShireCnt > 0)
                    {
                        //例外発生メッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "検収済みの仕入です。変更は不可です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        btnF01.Enabled = false;
                        btnF03.Enabled = false;
                        btnF07.Enabled = false;
                    }
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();

                    blRock = false;
                    txtDenpyoNo.Focus();

                    //txtYMD.Clear();
                    txtCD.Clear();

                    //各行の削除
                    for (int intCnt = 0; intCnt <= intMaxRow; intCnt++)
                    {
                        delLine(intCnt);
                    }
                    return;
                }

                //Leave処理を行った証明
                blDenpyoLeave = true;

                //仕入明細の取得
                dtSetshire = shireinputB.getShireMesai(txtDenpyoNo.Text);

                //取得したデータが1行以上あった場合
                if (dtSetshire.Rows.Count > 0)
                {
                    //テーブルの行数分ループ
                    for(int intCnt = 0; intCnt < dtSetshire.Rows.Count; intCnt++)
                    {
                        //行番号が99になった場合
                        if (dtSetshire.Rows[intCnt]["行番号"].ToString() == "99")
                        {
                            //フォーカス移動
                            cActiveBefore.Focus();
                        }

                        //行番号の数値から-1した数値を確保
                        int intRowCntMinus1 = int.Parse(dtSetshire.Rows[intCnt]["行番号"].ToString()) - 1;

                        //表示するデータを確保
                        List<string> lstData = new List<string>();

                        //中分類のデータ確保
                        DataTable dtChubun = null;

                        //[0]
                        lstData.Add(dtSetshire.Rows[intCnt]["行番号"].ToString());
                        //[1]
                        lstData.Add(dtSetshire.Rows[intCnt]["発注番号"].ToString());
                        //[2]
                        lstData.Add(dtSetshire.Rows[intCnt]["商品コード"].ToString());
                        //[3]
                        lstData.Add(dtSetshire.Rows[intCnt]["メーカーコード"].ToString());

                        //品名の確保（メーカー名部分）
                        strHinmei = dtSetshire.Rows[intCnt]["メーカー名"].ToString().Trim();

                        //[4]
                        lstData.Add(dtSetshire.Rows[intCnt]["大分類コード"].ToString());
                        
                        //[5]
                        lstData.Add(dtSetshire.Rows[intCnt]["中分類コード"].ToString());

                        //中分類のビジネス層インスタンス生成
                        M1110_Chubunrui_B chubunruiB = new M1110_Chubunrui_B();
                        //中分類のコードと名前を確保
                        dtChubun = chubunruiB.getTxtChubunruiLeave(dtSetshire.Rows[intCnt]["大分類コード"].ToString(), dtSetshire.Rows[intCnt]["中分類コード"].ToString());

                        strHinmei = strHinmei + " " + dtChubun.Rows[0]["中分類名"].ToString().Trim();

                        //Ｃ１にデータがある場合
                        if (dtSetshire.Rows[intCnt]["Ｃ１"].ToString() != "")
                        {
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ１"].ToString().Trim();
                            //[6]
                            lstData.Add(dtSetshire.Rows[intCnt]["Ｃ１"].ToString());
                        }
                        else
                        {
                            //[6]
                            lstData.Add("");
                        }
                        //Ｃ２にデータがある場合
                        if (dtSetshire.Rows[intCnt]["Ｃ２"].ToString() != "")
                        {
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ２"].ToString().Trim();
                            //[7]
                            lstData.Add(dtSetshire.Rows[intCnt]["Ｃ２"].ToString());
                        }
                        else
                        {
                            //[7]
                            lstData.Add("");
                        }
                        //Ｃ３にデータがある場合
                        if (dtSetshire.Rows[intCnt]["Ｃ３"].ToString() != "")
                        {
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ３"].ToString().Trim();
                            //[8]
                            lstData.Add(dtSetshire.Rows[intCnt]["Ｃ３"].ToString());
                        }
                        else
                        {
                            //[8]
                            lstData.Add("");
                        }
                        //Ｃ４にデータがある場合
                        if (dtSetshire.Rows[intCnt]["Ｃ４"].ToString() != "")
                        {
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ４"].ToString().Trim();
                            //[9]
                            lstData.Add(dtSetshire.Rows[intCnt]["Ｃ４"].ToString());
                        }
                        else
                        {
                            //[9]
                            lstData.Add("");
                        }
                        //Ｃ５にデータがある場合
                        if (dtSetshire.Rows[intCnt]["Ｃ５"].ToString() != "")
                        {
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ５"].ToString().Trim();
                            //[10]
                            lstData.Add(dtSetshire.Rows[intCnt]["Ｃ５"].ToString());
                        }
                        else
                        {
                            //[10]
                            lstData.Add("");
                        }
                        //Ｃ６にデータがある場合
                        if (dtSetshire.Rows[intCnt]["Ｃ６"].ToString() != "")
                        {
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ６"].ToString().Trim();
                            //[11]
                            lstData.Add(dtSetshire.Rows[intCnt]["Ｃ６"].ToString());
                        }
                        else
                        {
                            //[11]
                            lstData.Add("");
                        }

                        //[12]
                        lstData.Add(strHinmei);
                        //[13]
                        lstData.Add(dtSetshire.Rows[intCnt]["数量"].ToString().Trim());
                        //[14]
                        lstData.Add(dtSetshire.Rows[intCnt]["仕入単価"].ToString().Trim());
                        //[15]
                        lstData.Add(dtSetshire.Rows[intCnt]["仕入金額"].ToString().Trim());
                        //[16]
                        lstData.Add(dtSetshire.Rows[intCnt]["備考"].ToString().Trim());
                        //[17]
                        lstData.Add(dtSetshire.Rows[intCnt]["入庫倉庫"].ToString().Trim());

                        //発注番号の取得
                        int intHNo = int.Parse(dtSetshire.Rows[intCnt]["発注番号"].ToString().Trim());

                        //発注受注番号の取得
                        DataTable dtHachuJuchu = shireinputB.getHachuJuchu(intHNo.ToString().Trim());

                        //行番号-1が0の場合(1行目)
                        if (intRowCntMinus1 == 0)
                        {
                            gbData1.txtChumonNo.Text = dtHachuJuchu.Rows[0][0].ToString();
                            gbData1.setData(lstData);

                            //一行以上ある場合
                            if (dtHachuJuchu.Rows.Count > 0 && dtSetshire.Rows.Count > 0)
                            {
                                txtJuchu1.Text = "";

                                txtJuchu1.Text = dtHachuJuchu.Rows[0][0].ToString();

                                //受注単価の取得
                                DataTable dtJuchuTanka = shireinputB.getJuchuTanka(txtJuchu1.Text);

                                txtTanka1.Text = string.Format("{0:#,#}", dtJuchuTanka.Rows[0][0]);
                                txtTanka1.updPriceMethod();

                                gbData1.setRiekiritu(true);
                            }
                        }
                        //行番号-1が1の場合(2行目)
                        else if (intRowCntMinus1 == 1)
                        {
                            gbData2.txtChumonNo.Text = dtHachuJuchu.Rows[0][0].ToString();
                            gbData2.setData(lstData);

                            //一行以上ある場合
                            if (dtHachuJuchu.Rows.Count > 0 && dtSetshire.Rows.Count > 0)
                            {
                                txtJuchu2.Text = "";

                                txtJuchu2.Text = dtHachuJuchu.Rows[0][0].ToString();

                                //受注単価の取得
                                DataTable dtJuchuTanka = shireinputB.getJuchuTanka(txtJuchu2.Text);

                                txtTanka2.Text = string.Format("{0:#,#}", dtJuchuTanka.Rows[0][0]);
                                txtTanka2.updPriceMethod();

                                gbData2.setRiekiritu(true);
                            }
                        }
                        //行番号-1が2の場合(3行目)
                        else if (intRowCntMinus1 == 2)
                        {
                            gbData3.txtChumonNo.Text = dtHachuJuchu.Rows[0][0].ToString();
                            gbData3.setData(lstData);

                            //一行以上ある場合
                            if (dtHachuJuchu.Rows.Count > 0 && dtSetshire.Rows.Count > 0)
                            {
                                txtJuchu3.Text = "";

                                txtJuchu3.Text = dtHachuJuchu.Rows[0][0].ToString();

                                //受注単価の取得
                                DataTable dtJuchuTanka = shireinputB.getJuchuTanka(txtJuchu3.Text);

                                txtTanka3.Text = string.Format("{0:#,#}", dtJuchuTanka.Rows[0][0]);
                                txtTanka3.updPriceMethod();

                                gbData3.setRiekiritu(true);
                            }
                        }
                        //行番号-1が3の場合(4行目)
                        else if (intRowCntMinus1 == 3)
                        {
                            gbData4.txtChumonNo.Text = dtHachuJuchu.Rows[0][0].ToString();
                            gbData4.setData(lstData);

                            //一行以上ある場合
                            if (dtHachuJuchu.Rows.Count > 0 && dtSetshire.Rows.Count > 0)
                            {
                                txtJuchu4.Text = "";

                                txtJuchu4.Text = dtHachuJuchu.Rows[0][0].ToString();

                                //受注単価の取得
                                DataTable dtJuchuTanka = shireinputB.getJuchuTanka(txtJuchu4.Text);

                                txtTanka4.Text = string.Format("{0:#,#}", dtJuchuTanka.Rows[0][0]);
                                txtTanka4.updPriceMethod();

                                gbData4.setRiekiritu(true);
                            }
                        }
                        //行番号-1が4の場合(5行目)
                        else if (intRowCntMinus1 == 4)
                        {
                            gbData5.txtChumonNo.Text = dtHachuJuchu.Rows[0][0].ToString();
                            gbData5.setData(lstData);

                            //一行以上ある場合
                            if (dtHachuJuchu.Rows.Count > 0 && dtSetshire.Rows.Count > 0)
                            {
                                txtJuchu5.Text = "";

                                txtJuchu5.Text = dtHachuJuchu.Rows[0][0].ToString();

                                //受注単価の取得
                                DataTable dtJuchuTanka = shireinputB.getJuchuTanka(txtJuchu5.Text);

                                txtTanka5.Text = string.Format("{0:#,#}", dtJuchuTanka.Rows[0][0]);
                                txtTanka5.updPriceMethod();

                                gbData5.setRiekiritu(true);
                            }
                        }
                    }

                    //フォーカス移動
                    cActiveBefore.Focus();
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();

                    blRock = false;
                    txtDenpyoNo.Focus();

                    //txtYMD.Clear();
                    txtCD.Clear();

                    //各行の削除
                    for (int intCnt = 0; intCnt <= intMaxRow; intCnt++)
                    {
                        delLine(intCnt);
                    }
                    return;
                }

                //合計値を入力
                txtGokei.Text = string.Format("{0:0,0}", dtSetShireHeader.Rows[0]["税抜合計金額"].ToString());
                txtGokei.Text = StringUtl.updShishagonyu(txtGokei.Text, 0);
                txtGokei.updPriceMethod();
                txtShohizei.Text = string.Format("{0:0,0}", dtSetShireHeader.Rows[0]["消費税"].ToString());
                txtShohizei.Text = StringUtl.updShishagonyu(txtShohizei.Text, 0);
                txtShohizei.updPriceMethod();
                txtSogokei.Text = string.Format("{0:0,0}", dtSetShireHeader.Rows[0]["税込合計金額"].ToString());
                txtSogokei.Text = StringUtl.updShishagonyu(txtSogokei.Text, 0);
                txtSogokei.updPriceMethod();

                //伝票番号ありのデータの証明
                blMODYflg = false;

                //伝票Noを触らせない
                txtDenpyoNo.Enabled = false;
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
        ///delLine
        ///各行の入力項目削除
        ///</summary>
        public void delLine(int intRow)
        {
            //一行目
            if (intRow == 1)
            {
                gbData1.delText();
            }
            //二行目
            else if (intRow == 2)
            {
                gbData2.delText();
            }
            //三行目
            else if (intRow == 3)
            {
                gbData3.delText();
            }
            //四行目
            else if (intRow == 4)
            {
                gbData4.delText();
            }
            //五行目
            else
            {
                gbData5.delText();
            }
        }

        ///<summary>
        ///setTokuisakiListClose
        ///担当者リストが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setTokuisakiListClose()
        {
            txtCD.Focus();
        }

        ///<summary>
        ///setTorihikisaki
        ///取り出したデータをテキストボックスに配置
        ///</summary>
        public void setTorihikisaki(DataTable dtSelectData)
        {
            txtCD.Text = dtSelectData.Rows[0]["取引先コード"].ToString();
            txtYubinView.Text = dtSelectData.Rows[0]["郵便番号"].ToString();
            txtJusho1View.Text = dtSelectData.Rows[0]["住所１"].ToString();
            txtJusho2View.Text = dtSelectData.Rows[0]["住所２"].ToString();
            txtShireNameView.Text = dtSelectData.Rows[0]["取引先名称"].ToString();
        }

        ///<summary>
        ///txtCD_Leave
        ///コード入力項目から離れた時
        ///</summary>
        private void txtCD_Leave(object sender, EventArgs e)
        {
            setShireData();
        }

        ///<summary>
        ///setShireData
        ///仕入先データを表示(BaseViewDataGroup)
        ///</summary>
        public void setShireData()
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                dtSetCd = shireinputB.getTorihikisaki(txtCD.Text);

                //取引先情報が１件以上ある場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtYubinView.Text = dtSetCd.Rows[0]["郵便番号"].ToString();
                    txtJusho1View.Text = dtSetCd.Rows[0]["住所１"].ToString();
                    txtJusho2View.Text = dtSetCd.Rows[0]["住所２"].ToString();
                    txtShireNameView.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
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
        ///txtDenpyoNo_KeyDown
        ///キー入力判定(伝票番号)
        ///</summary>
        private void txtDenpyoNo_KeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F9:
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    showShireList();
                    break;
                default:
                    break;
            }
        }

        ///<summary>
        ///txtDenpyoNo_KeyDown
        ///キー入力判定（各テキストボックス）
        ///</summary>
        private void txtKeyDown(object sender, KeyEventArgs e)
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
        ///showShireList
        //仕入リスト表示
        ///</summary>
        private void showShireList()
        {
            //仕入先リストのインスタンス生成
            ShireList shirelist = new ShireList(this);
            try
            {
                //取引先リストの表示、画面IDを渡す
                shirelist.intFrmKind = CommonTeisu.FRM_SHIREINPUT;
                shirelist.strTorihiki = txtCD.Text;
                shirelist.ShowDialog();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///setDenpyoShire
        ///仕入リストからのデータ記入
        ///</summary>
        public void setDenpyoShire(string strDenpyo)
        {
            txtDenpyoNo.Text = strDenpyo;
        }

        ///<summary>
        ///setShireListClose
        ///仕入リストからの戻り
        ///</summary>
        public void setShireListClose()
        {
            txtDenpyoNo.Focus();
        }

        ///<summary>
        ///txtJuchu1_TextChanged
        ///受注番号1が変更になった場合
        ///</summary>
        private void txtJuchu1_TextChanged(object sender, EventArgs e)
        {
            txtTanka1.Clear();

            //受注番号が白紙の場合
            if (!StringUtl.blIsEmpty(txtJuchu1.Text) || txtJuchu1.Text.Trim() == "0")
            {
                txtTanka1.Text = "0";
                return;
            }

            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                dtSetCd = shireinputB.getJuchuTanka(txtJuchu1.Text);

                //取引先情報が１件以上ある場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtTanka1.Text = string.Format("{0:0.#}", double.Parse(dtSetCd.Rows[0][0].ToString()));
                    txtTanka1.updPriceMethod();

                    dtSetCd.Clear();
                    dtSetCd = shireinputB.getJuchuTokusaikimei(txtJuchu1.Text);

                    if (dtSetCd != null && dtSetCd.Rows.Count > 0)
                    {
                        gbData1.txtTokuisaki.Text = dtSetCd.Rows[0]["得意先名称"].ToString();
                    }
                    else
                    {
                        gbData1.txtTokuisaki.Text = "";
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

        ///<summary>
        ///txtJuchu2_TextChanged
        ///受注番号2が変更になった場合
        ///</summary>
        private void txtJuchu2_TextChanged(object sender, EventArgs e)
        {
            txtTanka2.Clear();

            //受注番号が白紙の場合
            if (!StringUtl.blIsEmpty(txtJuchu2.Text) || txtJuchu2.Text.Trim() == "0")
            {
                txtTanka2.Text = "0";
                return;
            }

            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                dtSetCd = shireinputB.getJuchuTanka(txtJuchu2.Text);

                //取引先情報が１件以上ある場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtTanka2.Text = string.Format("{0:0.#}", double.Parse(dtSetCd.Rows[0][0].ToString()));
                    txtTanka2.updPriceMethod();

                    dtSetCd.Clear();
                    dtSetCd = shireinputB.getJuchuTokusaikimei(txtJuchu2.Text);

                    if (dtSetCd != null && dtSetCd.Rows.Count > 0)
                    {
                        gbData2.txtTokuisaki.Text = dtSetCd.Rows[0]["得意先名称"].ToString();
                    }
                    else
                    {
                        gbData2.txtTokuisaki.Text = "";
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

        ///<summary>
        ///txtJuchu3_TextChanged
        ///受注番号3が変更になった場合
        ///</summary>
        private void txtJuchu3_TextChanged(object sender, EventArgs e)
        {
            txtTanka3.Clear();

            //受注番号が白紙の場合
            if (!StringUtl.blIsEmpty(txtJuchu3.Text) || txtJuchu3.Text.Trim() == "0")
            {
                txtTanka3.Text = "0";
                return;
            }

            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                dtSetCd = shireinputB.getJuchuTanka(txtJuchu3.Text);

                //取引先情報が１件以上ある場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtTanka3.Text = string.Format("{0:0.#}", double.Parse(dtSetCd.Rows[0][0].ToString()));
                    txtTanka3.updPriceMethod();

                    dtSetCd.Clear();
                    dtSetCd = shireinputB.getJuchuTokusaikimei(txtJuchu3.Text);

                    if (dtSetCd != null && dtSetCd.Rows.Count > 0)
                    {
                        gbData3.txtTokuisaki.Text = dtSetCd.Rows[0]["得意先名称"].ToString();
                    }
                    else
                    {
                        gbData3.txtTokuisaki.Text = "";
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

        ///<summary>
        ///txtJuchu4_TextChanged
        ///受注番号4が変更になった場合
        ///</summary>
        private void txtJuchu4_TextChanged(object sender, EventArgs e)
        {
            txtTanka4.Clear();

            //受注番号が白紙の場合
            if (!StringUtl.blIsEmpty(txtJuchu4.Text) || txtJuchu4.Text.Trim() == "0")
            {
                txtTanka4.Text = "0";
                return;
            }

            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                dtSetCd = shireinputB.getJuchuTanka(txtJuchu4.Text);

                //取引先情報が１件以上ある場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtTanka4.Text = string.Format("{0:0.#}", double.Parse(dtSetCd.Rows[0][0].ToString()));
                    txtTanka4.updPriceMethod();

                    dtSetCd.Clear();
                    dtSetCd = shireinputB.getJuchuTokusaikimei(txtJuchu4.Text);

                    if (dtSetCd != null && dtSetCd.Rows.Count > 0)
                    {
                        gbData4.txtTokuisaki.Text = dtSetCd.Rows[0]["得意先名称"].ToString();
                    }
                    else
                    {
                        gbData4.txtTokuisaki.Text = "";
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

        ///<summary>
        ///txtJuchu5_TextChangedgetJuchuTokusaikimei
        ///受注番号5が変更になった場合
        ///</summary>
        private void txtJuchu5_TextChanged(object sender, EventArgs e)
        {
            txtTanka5.Clear();

            //受注番号が白紙の場合
            if (!StringUtl.blIsEmpty(txtJuchu5.Text) || txtJuchu5.Text.Trim() == "0")
            {
                txtTanka5.Text = "0";
                return;
            }

            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                dtSetCd = shireinputB.getJuchuTanka(txtJuchu5.Text);

                //取引先情報が１件以上ある場合
                if (dtSetCd.Rows.Count != 0)
                {
                    txtTanka5.Text = string.Format("{0:0.#}", double.Parse(dtSetCd.Rows[0][0].ToString()));
                    txtTanka5.updPriceMethod();

                    dtSetCd.Clear();
                    dtSetCd = shireinputB.getJuchuTokusaikimei(txtJuchu5.Text);

                    if (dtSetCd != null && dtSetCd.Rows.Count > 0)
                    {
                        gbData5.txtTokuisaki.Text = dtSetCd.Rows[0]["得意先名称"].ToString();
                    }
                    else
                    {
                        gbData5.txtTokuisaki.Text = "";
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

        ///<summary>
        ///getShohinCd
        ///商品コードの確保
        ///</summary>
        private DataTable getShohinCd(List<string> lstSetShohinData)
        {
            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                dtSetCd = shireinputB.getShohinCdB(lstSetShohinData);

                return dtSetCd;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return dtSetCd;
            }
        }


        ///<summary>
        ///ChkData
        ///データチェック
        ///</summary>
        private bool ChkData()
        {
            object objSu = null;

            //チェック後の判定
            bool blgood = true;

            //各行の注文Noの有無
            int intChumonCnt = 0;

            //仕入単価入れる用
            DataTable dtShireTanka = new DataTable();

            //発注数量入れる用
            DataTable dtHachusu = new DataTable();

            //tryParse用
            decimal decTry = 0;

            //エラー位置にフォーカスする用
            Control cErrorData = null;

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //各行の情報を入れる
            bvg = new BaseViewDataGroup[] { gbData1, gbData2, gbData3, gbData4, gbData5 };

            //各行のチェック
            for (int intCnt = 0; intCnt < bvg.Length; intCnt++)
            {
                if (StringUtl.blIsEmpty(bvg[intCnt].txtChumonNo.Text))
                {
                    intChumonCnt = intChumonCnt + 1;
                }
            }

            //仕入先コードが存在しない場合
            if (txtCD.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtCD.Focus();
                return false;
            }

            //仕入先コードが存在しない場合
            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                dtSetCd = shireinputB.getShiresaki(txtCD.Text);

                //データがない場合
                if (dtSetCd.Rows.Count == 0)
                {
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    txtCD.Clear();
                    txtCD.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }

            //どの行も注文番号が書かれていない場合
            if (intChumonCnt == 0)
            {
                //有効な明細行がないというメッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, 
                                                                   CommonTeisu.TEXT_VIEW, 
                                                                   "有効な明細行がありません。\r\n伝票が不要な場合は伝票削除（F3)を行ってください。", 
                                                                   CommonTeisu.BTN_OK, 
                                                                   CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();

                blgood = false;
            }

            int intUnchinCnt = 0;

            //運賃データが空の場合は0、それ以外はそのまま
            if (txtUnchin.Text.Trim() == "")
            {
                txtUnchin.Text = "0";
            }

            //数字チェック
            if (txtUnchin.chkMoneyText())
            {
                txtUnchin.Focus();

                blgood = false;
            }

            //false判定でない場合
            if (blgood == true)
            {
                txtUnchin.Text = (decimal.Parse(txtUnchin.Text)).ToString();

                //運賃データが0以外の場合
                if (txtUnchin.Text != "0")
                {
                    if (txtJuchu1.blIsEmpty() == true)
                    {
                        intUnchinCnt = intUnchinCnt + 1;
                    }
                    if (txtJuchu2.blIsEmpty() == true)
                    {
                        intUnchinCnt = intUnchinCnt + 1;
                    }
                    if (txtJuchu3.blIsEmpty() == true)
                    {
                        intUnchinCnt = intUnchinCnt + 1;
                    }
                    if (txtJuchu4.blIsEmpty() == true)
                    {
                        intUnchinCnt = intUnchinCnt + 1;
                    }
                    if (txtJuchu5.blIsEmpty() == true)
                    {
                        intUnchinCnt = intUnchinCnt + 1;
                    }

                    //運賃カウントが0の場合
                    if (intUnchinCnt == 0)
                    {
                        //"関連する受注データがないとメッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "関連する受注データがありません。明細行で運賃を入力して下さい。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();

                        blgood = false;
                    }
                }
                else
                {
                    txtUnchin.Text = "0";
                }
            }

            if (blgood)
            {
                strYMDformat = txtYMD.chkDateDataFormat(txtYMD.Text);

                //年月として扱えない場合
                if (strYMDformat == "")
                {
                    // メッセージボックスの処理、項目が日付でない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力された日付が正しくありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();

                    blgood = false;
                }
                else
                {
                    //生成した年月日を反映させる
                    txtYMD.Text = strYMDformat;
                }
            }

            if (blgood)
            {
                //コードが空の場合
                if (txtCD.blIsEmpty() == false)
                {
                    blgood = false;
                }
            }

            if (blgood)
            {
                //担当者名が空の場合
                if (labelSet_Tantousha.ValueLabelText == "")
                {
                    blgood = false;
                }

                //担当者コードのチェック
                if (labelSet_Tantousha.chkTxtTantosha() == true)
                {
                    labelSet_Tantousha.Focus();

                    blgood = false;
                }
            }

            if (blgood)
            {
                //取引区分が空の場合
                if (labelSet_Torihikikbn.ValueLabelText == "")
                {
                    blgood = false;
                }

                //取引区分のチェック
                if (labelSet_Torihikikbn.chkTxtTorihikikbn())
                {
                    labelSet_Torihikikbn.Focus();

                    blgood = false;
                }
            }

            //各gbDataのチェック
            //false判定でない場合
            if (blgood == true)
            {
                //各行のチェック
                for (int intgbCnt = 0; intgbCnt < bvg.Length; intgbCnt++)
                {
                    //注文番号がある場合
                    if (StringUtl.blIsEmpty(bvg[intgbCnt].txtChumonNo.Text))
                    {
                        //数量がない場合
                        if (!StringUtl.blIsEmpty(bvg[intgbCnt].txtSu.Text))
                        {
                            blgood = false;
                        }
                        //単価がない場合
                        if (!StringUtl.blIsEmpty(bvg[intgbCnt].txtTanka.Text))
                        {
                            blgood = false;
                        }
                        //倉庫番号がない場合
                        if (!StringUtl.blIsEmpty(bvg[intgbCnt].labelSet_Eigyosho.ValueLabelText))
                        {
                            blgood = false;
                        }

                        //数量の数字チェック
                        if (bvg[intgbCnt].txtSu.chkMoneyText())
                        {
                            blgood = false;
                        }

                        //単価の数字チェック
                        if (bvg[intgbCnt].txtTanka.chkMoneyText())
                        {
                            blgood = false;
                        }

                        //倉庫番号チェック
                        if (bvg[intgbCnt].labelSet_Eigyosho.chkTxtEigyousho())
                        {
                            blgood = false;
                        }
                    }

                    //各行のチェック
                    for (int intCntJuhuku = 0; intCntJuhuku < bvg.Length; intCntJuhuku++)
                    {
                        //注文番号がある場合
                        if (StringUtl.blIsEmpty(bvg[intgbCnt].txtChumonNo.Text))
                        {
                            //同じ列同士の検索被りをしないようにする
                            if (intgbCnt != intCntJuhuku)
                            {
                                //注文番号重複チェック
                                if (bvg[intgbCnt].txtChumonNo.Text == bvg[intCntJuhuku].txtChumonNo.Text)
                                {
                                    //"関連する受注データがないとメッセージ（OK）
                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "注文No.が重複してます。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                    basemessagebox.ShowDialog();

                                    blgood = false;
                                    return (blgood);
                                }
                            }
                        }
                    }

                    //発注原価のチェック
                    if (bvg[intgbCnt].txtTankaSub.Text != "0" && bvg[intgbCnt].txtTankaSub.Text != "")
                    {
                        //数量の数字チェック
                        if (bvg[intgbCnt].txtTanka.chkMoneyText())
                        {
                            blgood = false;
                        }

                        if (blgood)
                        {
                            //商品マスタから仕入単価を得る
                            ShouhinList_B shohinlistB = new ShouhinList_B();
                            dtShireTanka = shohinlistB.getShireTanka(bvg[intgbCnt].txtShohinCd.Text);

                            //仕入単価がある場合
                            if (dtShireTanka.Rows.Count > 0)
                            {
                                //発注単価より値段が高い場合
                                if (int.Parse(bvg[intgbCnt].txtTanka.Text) < int.Parse(dtShireTanka.Rows[0][0].ToString()))
                                {
                                    //"関連する受注データがないとメッセージ（OK）
                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "発注単価より高い価格です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                    basemessagebox.ShowDialog();

                                    blgood = false;

                                    bvg[intgbCnt].txtTanka.Focus();
                                }
                            }
                        }
                    }

                    //発注数>=仕入数量のチェック
                    if (bvg[intgbCnt].txtChumonNo.blIsEmpty() == true)
                    {
                        if (blgood)
                        {
                            try
                            {
                                //商品マスタから仕入単価を得る
                                A0030_ShireInput_B shireB = new A0030_ShireInput_B();
                                dtHachusu = shireB.getHachusu(bvg[intgbCnt].txtChumonNo.Text);

                                //発注数がある場合
                                if (dtHachusu.Rows.Count > 0)
                                {
                                    objSu = dtHachusu.Rows[0][0].ToString();
                                }

                                //発注数と仕入数量の比較
                                if (decimal.Parse(bvg[intgbCnt].txtSu.Text) > decimal.Parse(objSu.ToString()))
                                {
                                    //"関連する受注データがないとメッセージ（OK）
                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "発注数量を超えています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                    basemessagebox.ShowDialog();

                                    blgood = false;
                                    bvg[intgbCnt].txtSu.Focus();
                                }
                            }
                            catch(Exception ex)
                            {
                                //データロギング
                                new CommonException(ex);
                                //例外発生メッセージ（OK）
                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                basemessagebox.ShowDialog();
                            }
                        }
                    }
                }
            }

            //売上単価チェック
            if (blgood)
            {
                //受注単価内に０がある場合
                if (gbData1.txtJuchuTanka.Text == "0" || 
                    gbData2.txtJuchuTanka.Text == "0" || 
                    gbData3.txtJuchuTanka.Text == "0" || 
                    gbData4.txtJuchuTanka.Text == "0" || 
                    gbData5.txtJuchuTanka.Text == "0")
                {
                    //"関連する受注データがないとメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "売上単価が￥０の受注が含まれています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();

                    blgood = false;
                }
            }

            //good判定の判定
            if (blgood == false)
            {
                return (blgood);
            }

            //日付制限チェックをしたときにfalseの場合
            if (StringUtl.judHidukeCheck("3", txtEigyouCd.Text, DateTime.Parse(txtYMD.Text)) == false)
            {

                //日付が範囲外とメッセージ
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "日付が範囲外です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();

                txtYMD.Focus();
                blgood = false;
            }

            //good判定の判定
            if (blgood == false)
            {
                return (blgood);
            }

            //合計計算式を入れる(一つで全行計算する)
            gbData1.setGokeiKesan();

            //閲覧権限がない場合
            if (!("1").Equals(etsuranFlg))
            {
                //各行のデータ
                for (int intCnt = 0; intCnt < 5; intCnt++)
                {
                    if(bvg[intCnt].txtChumonNo.blIsEmpty() == true)
                    {
                        //単価の文字色
                        bvg[intCnt].txtTanka.ForeColor = Color.Black;

                        //単価と直近単価が数値変換できる場合
                        if (decimal.TryParse(bvg[intCnt].txtTanka.Text.Trim(), out decTry) &&
                            decimal.TryParse(bvg[intCnt].txtChokinTanka.Text.Trim(), out decTry))
                        {
                            //単価と直近仕入単価の比較、単価とマスタ単価の比較
                            if (decimal.Parse(bvg[intCnt].txtTanka.Text) < decimal.Parse(bvg[intCnt].txtChokinTanka.Text) ||
                                decimal.Parse(bvg[intCnt].txtTanka.Text) < decimal.Parse(bvg[intCnt].txtMasterTanka.Text))
                            {
                                bvg[intCnt].txtTanka.ForeColor = Color.Red;
                                blgood = false;
                            }

                            //初めてエラーになったの場合
                            if (blgood == false && cErrorData == null)
                            {
                                //エラー位置確保
                                cErrorData = bvg[intCnt].txtTanka;
                            }
                        }
                    }
                }

                if (blgood == false)
                {
                    //"関連する受注データがないとメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, "仕入単価チェック", "仕入単価が直近・マスタ仕入単価を上回っています。続行してもいいですか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                    //YESが押された場合
                    if (basemessagebox.ShowDialog() == DialogResult.Yes)
                    {
                        blgood = true;
                    }
                    else
                    {
                        //エラー位置にフォーカス
                        cErrorData.Focus();
                    }
                }
            }
            return (blgood);
        }


        ///<summary>
        ///txtShireInput_KeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void txtShireInput_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///gbData1_Enter
        ///DataGroupの1にフォーカスが来た場合
        ///</summary>
        private void gbData1_Enter(object sender, EventArgs e)
        {
            //GroupData1にフォーカスが行ってる情報を残す
            shotCnt = 1;
        }

        ///<summary>
        ///gbData2_Enter
        ///DataGroupの2にフォーカスが来た場合
        ///</summary>
        private void gbData2_Enter(object sender, EventArgs e)
        {
            //GroupData2にフォーカスが行ってる情報を残す
            shotCnt = 2;
        }

        ///<summary>
        ///gbData3_Enter
        ///DataGroupの3にフォーカスが来た場合
        ///</summary>
        private void gbData3_Enter(object sender, EventArgs e)
        {
            //GroupData3にフォーカスが行ってる情報を残す
            shotCnt = 3;
        }

        ///<summary>
        ///gbData4_Enter
        ///DataGroupの4にフォーカスが来た場合
        ///</summary>
        private void gbData4_Enter(object sender, EventArgs e)
        {
            //GroupData4にフォーカスが行ってる情報を残す
            shotCnt = 4;
        }

        ///<summary>
        ///gbData5_Enter
        ///DataGroupの5にフォーカスが来た場合
        ///</summary>
        private void gbData5_Enter(object sender, EventArgs e)
        {
            //GroupData5にフォーカスが行ってる情報を残す
            shotCnt = 5;
        }


        ///<summary>
        ///txtYMD_Leave
        ///年月日
        ///</summary>
        private void txtYMD_Leave(object sender, EventArgs e)
        {
            //年月日が空の場合
            if (txtYMD.blIsEmpty() == false)
            {
                return;
            }

            //年月日の日付フォーマット後を入れる用
            string strYMDformat = "";

            //日付フォーマット生成、およびチェック
            strYMDformat = txtYMD.chkDateDataFormat(txtYMD.Text);

            //年月日の日付チェック
            if (strYMDformat == "")
            {
                txtYMD.Focus();
            }
            else
            {
                txtYMD.Text = strYMDformat;

                //日付制限チェックをしたときにfalseの場合
                if (StringUtl.judHidukeCheck("3", txtEigyouCd.Text, DateTime.Parse(txtYMD.Text)) == false)
                {
                    //日付が範囲外とメッセージ
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "日付が範囲外です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                }
            }
        }

        ///<summary>
        ///txtDenpyoNo_KeyPress
        ///キープレスの処理
        ///</summary>
        private void txtDenpyoNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b'
            && e.KeyChar != '\u0001' && e.KeyChar != '\u0003' && e.KeyChar != '\u0016' && e.KeyChar != '\u0018')
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        ///<summary>
        ///cmbSubWinShow_SelectedIndexChanged
        /// サブ画面表示
        ///</summary>
        private void cmbSubWinShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;

            //仕入実績確認
            if (cmbSubWinShow.SelectedIndex == 0)
            {
                logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));

                //仕入実績確認が既に開いている場合        
                if (shireKakunin != null && shireKakunin.Visible)
                {
                    shireKakunin.Activate();
                    return;
                }

                shireKakunin = new Form.D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin(this, 3, txtCD.Text);

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

                shireKakunin.StartPosition = FormStartPosition.Manual;
                shireKakunin.Location = s.Bounds.Location;

                //仕入実績確認画面へ移動
                shireKakunin.Show();
            }
            //受注残・発注残確認
            else if (c.SelectedIndex == 1)
            {
                logger.Info(LogUtil.getMessage(this._Title, "受注残・発注残確認実行"));

                //受注残・発注残確認が既に開いている場合        
                if (juchuzan != null && juchuzan.Visible)
                {
                    juchuzan.Activate();
                    return;
                }

                //取引先コードがある場合
                if (txtCD.blIsEmpty())
                {
                    juchuzan = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this, txtCD.Text, txtNull, true);
                }
                else
                {
                    juchuzan = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this);
                }
                
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

                juchuzan.StartPosition = FormStartPosition.Manual;
                juchuzan.Location = s.Bounds.Location;

                juchuzan.Show();
            }
            //商品元帳確認
            else if (c.SelectedIndex == 2)
            {
                logger.Info(LogUtil.getMessage(this._Title, "商品元帳確認実行"));

                //商品元帳確認が既に開いている場合        
                if (shohinmoto != null && shohinmoto.Visible)
                {
                    shohinmoto.Activate();
                    return;
                }

                shohinmoto = new D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin(this);
                
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

                shohinmoto.StartPosition = FormStartPosition.Manual;
                shohinmoto.Location = s.Bounds.Location;

                shohinmoto.Show();
            }
        }

        ///<summary>
        ///setGbData1
        ///行削除時に移動する
        ///</summary>
        private void setGbData1()
        {
            if (gbData2.txtChumonNo.blIsEmpty() == true)
            {
                gbData1.txtNo.Text = "0";
            }
            else
            {
                gbData1.txtNo.Text = "";
            }

            gbData1.txtChumonNo.Text = gbData2.txtChumonNo.Text;
            gbData1.txtHin.Text = gbData2.txtHin.Text;
            gbData1.txtSu.Text = gbData2.txtSu.Text;
            gbData1.txtTanka.Text = gbData2.txtTanka.Text;
            gbData1.txtBiko.Text = gbData2.txtBiko.Text;
            gbData1.txtKin.Text = gbData2.txtKin.Text;
            gbData1.txtShohinCd.Text = gbData2.txtShohinCd.Text;
            gbData1.txtMakerCd.Text = gbData2.txtMakerCd.Text;
            gbData1.txtDaibunCd.Text = gbData2.txtDaibunCd.Text;
            gbData1.txtChubunCd.Text = gbData2.txtChubunCd.Text;
            gbData1.txtC1.Text = gbData2.txtC1.Text;
            gbData1.txtC2.Text = gbData2.txtC2.Text;
            gbData1.txtC3.Text = gbData2.txtC3.Text;
            gbData1.txtC4.Text = gbData2.txtC4.Text;
            gbData1.txtC5.Text = gbData2.txtC5.Text;
            gbData1.txtC6.Text = gbData2.txtC6.Text;
            gbData1.labelSet_Eigyosho.CodeTxtText = gbData2.labelSet_Eigyosho.CodeTxtText;
            gbData1.labelSet_Eigyosho.chkTxtEigyousho();
            gbData1.txtTeka.Text = gbData2.txtTeka.Text;
            gbData1.txtShireritsu.Text = gbData2.txtShireritsu.Text;
            gbData1.txtChokinTanka.Text = gbData2.txtChokinTanka.Text;
            gbData1.txtMasterTanka.Text = gbData2.txtMasterTanka.Text;
            gbData1.txtTokuisaki.Text = gbData2.txtTokuisaki.Text;

            gbData1.txtHin.TabStop = true;
            gbData1.txtHin.Enabled = true;

            txtJuchu1.Text = txtJuchu2.Text;
            txtTanka1.Text = txtTanka2.Text;
        }

        ///<summary>
        ///setGbData2
        ///行削除時に移動する
        ///</summary>
        private void setGbData2()
        {
            if (gbData3.txtChumonNo.blIsEmpty() == true)
            {
                gbData2.txtNo.Text = "1";
            }
            else
            {
                gbData2.txtNo.Text = "";
            }

            gbData2.txtChumonNo.Text = gbData3.txtChumonNo.Text;
            gbData2.txtHin.Text = gbData3.txtHin.Text;
            gbData2.txtSu.Text = gbData3.txtSu.Text;
            gbData2.txtTanka.Text = gbData3.txtTanka.Text;
            gbData2.txtKin.Text = gbData3.txtKin.Text;
            gbData2.txtBiko.Text = gbData3.txtBiko.Text;
            gbData2.txtShohinCd.Text = gbData3.txtShohinCd.Text;
            gbData2.txtMakerCd.Text = gbData3.txtMakerCd.Text;
            gbData2.txtDaibunCd.Text = gbData3.txtDaibunCd.Text;
            gbData2.txtChubunCd.Text = gbData3.txtChubunCd.Text;
            gbData2.txtC1.Text = gbData3.txtC1.Text;
            gbData2.txtC2.Text = gbData3.txtC2.Text;
            gbData2.txtC3.Text = gbData3.txtC3.Text;
            gbData2.txtC4.Text = gbData3.txtC4.Text;
            gbData2.txtC5.Text = gbData3.txtC5.Text;
            gbData2.txtC6.Text = gbData3.txtC6.Text;
            gbData2.labelSet_Eigyosho.CodeTxtText = gbData3.labelSet_Eigyosho.CodeTxtText;
            gbData2.labelSet_Eigyosho.chkTxtEigyousho();
            gbData2.txtTeka.Text = gbData3.txtTeka.Text;
            gbData2.txtShireritsu.Text = gbData3.txtShireritsu.Text;
            gbData2.txtChokinTanka.Text = gbData3.txtChokinTanka.Text;
            gbData2.txtMasterTanka.Text = gbData3.txtMasterTanka.Text;
            gbData2.txtTokuisaki.Text = gbData3.txtTokuisaki.Text;

            gbData2.txtHin.TabStop = true;
            gbData2.txtHin.Enabled = true;
            
            txtJuchu2.Text = txtJuchu3.Text;
            txtTanka2.Text = txtTanka3.Text;
        }

        ///<summary>
        ///setGbData3
        ///行削除時に移動する
        ///</summary>
        private void setGbData3()
        {
            if (gbData4.txtChumonNo.blIsEmpty() == true)
            {
                gbData3.txtNo.Text = "2";
            }
            else
            {
                gbData3.txtNo.Text = "";
            }

            gbData3.txtChumonNo.Text = gbData4.txtChumonNo.Text;
            gbData3.txtHin.Text = gbData4.txtHin.Text;
            gbData3.txtSu.Text = gbData4.txtSu.Text;
            gbData3.txtTanka.Text = gbData4.txtTanka.Text;
            gbData3.txtBiko.Text = gbData4.txtBiko.Text;
            gbData3.txtKin.Text = gbData4.txtKin.Text;
            gbData3.txtShohinCd.Text = gbData4.txtShohinCd.Text;
            gbData3.txtMakerCd.Text = gbData4.txtMakerCd.Text;
            gbData3.txtDaibunCd.Text = gbData4.txtDaibunCd.Text;
            gbData3.txtChubunCd.Text = gbData4.txtChubunCd.Text;
            gbData3.txtC1.Text = gbData4.txtC1.Text;
            gbData3.txtC2.Text = gbData4.txtC2.Text;
            gbData3.txtC3.Text = gbData4.txtC3.Text;
            gbData3.txtC4.Text = gbData4.txtC4.Text;
            gbData3.txtC5.Text = gbData4.txtC5.Text;
            gbData3.txtC6.Text = gbData4.txtC6.Text;
            gbData3.labelSet_Eigyosho.CodeTxtText = gbData4.labelSet_Eigyosho.CodeTxtText;
            gbData3.labelSet_Eigyosho.chkTxtEigyousho();
            gbData3.txtTeka.Text = gbData4.txtTeka.Text;
            gbData3.txtShireritsu.Text = gbData4.txtShireritsu.Text;
            gbData3.txtChokinTanka.Text = gbData4.txtChokinTanka.Text;
            gbData3.txtMasterTanka.Text = gbData4.txtMasterTanka.Text;
            gbData3.txtTokuisaki.Text = gbData4.txtTokuisaki.Text;

            gbData3.txtHin.TabStop = true;
            gbData3.txtHin.Enabled = true;

            txtJuchu3.Text = txtJuchu4.Text;
            txtTanka3.Text = txtTanka4.Text;
        }

        ///<summary>
        ///setGbData4
        ///行削除時に移動する
        ///</summary>
        private void setGbData4()
        {
            if (gbData5.txtChumonNo.blIsEmpty() == true)
            {
                gbData4.txtNo.Text = "3";
            }
            else
            {
                gbData4.txtNo.Text = "";
            }

            gbData4.txtChumonNo.Text = gbData5.txtChumonNo.Text;
            gbData4.txtHin.Text = gbData5.txtHin.Text;
            gbData4.txtSu.Text = gbData5.txtSu.Text;
            gbData4.txtTanka.Text = gbData5.txtTanka.Text;
            gbData4.txtBiko.Text = gbData5.txtBiko.Text;
            gbData4.txtKin.Text = gbData5.txtKin.Text;
            gbData4.txtShohinCd.Text = gbData5.txtShohinCd.Text;
            gbData4.txtMakerCd.Text = gbData5.txtMakerCd.Text;
            gbData4.txtDaibunCd.Text = gbData5.txtDaibunCd.Text;
            gbData4.txtChubunCd.Text = gbData5.txtChubunCd.Text;
            gbData4.txtC1.Text = gbData5.txtC1.Text;
            gbData4.txtC2.Text = gbData5.txtC2.Text;
            gbData4.txtC3.Text = gbData5.txtC3.Text;
            gbData4.txtC4.Text = gbData5.txtC4.Text;
            gbData4.txtC5.Text = gbData5.txtC5.Text;
            gbData4.txtC6.Text = gbData5.txtC6.Text;
            gbData4.labelSet_Eigyosho.CodeTxtText = gbData5.labelSet_Eigyosho.CodeTxtText;
            gbData4.labelSet_Eigyosho.chkTxtEigyousho();
            gbData4.txtTeka.Text = gbData5.txtTeka.Text;
            gbData4.txtShireritsu.Text = gbData5.txtShireritsu.Text;
            gbData4.txtChokinTanka.Text = gbData5.txtChokinTanka.Text;
            gbData4.txtMasterTanka.Text = gbData5.txtMasterTanka.Text;
            gbData4.txtTokuisaki.Text = gbData5.txtTokuisaki.Text;

            gbData4.txtHin.TabStop = true;
            gbData4.txtHin.Enabled = true;

            txtJuchu4.Text = txtJuchu5.Text;
            txtTanka4.Text = txtTanka5.Text;
        }

        ///<summary>
        ///setGbData5
        ///行削除時に消す
        ///</summary>
        private void setNullGbData5()
        {
            txtJuchu5.Text = "";
            txtTanka5.Text = "";
            txtRiekiritsu5.Text = "";
        }

        ///<summary>
        ///judHachuNoOverlap
        ///発注番号が既にあるかどうか確認
        ///</summary>
        public bool judHachuNoOverlap(string strHachuNo)
        {
            Boolean blHachuNoOverlap = false;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                //発注データの有無
                DataTable dtHachuData = shireinputB.getHachuData(strHachuNo);

                //取引先情報が１件以上ある場合
                if (dtHachuData.Rows.Count != 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blHachuNoOverlap;
        }
    }
}
