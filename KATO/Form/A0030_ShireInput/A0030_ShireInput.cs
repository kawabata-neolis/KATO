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
        bool blRock = false;

        //行数(gbでも使用する)
        public int intMaxRow = 4;

        //伝票番号のLeaveの処理をしたかどうか
        bool blDenpyoLeave = false;

        //データ追加時の商品コード確保
        string strShohinCd;

        //各行の情報を入れる配列
        BaseViewDataGroup[] bvg;

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
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            //初期値の設定
            txtYMD.Text = DateTime.Today.ToString();
            labelSet_Tantousha.CodeTxtText = "0022";
            labelSet_Torihikikbn.CodeTxtText = "21";
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
                    logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));
                    this.setUriageJisseki();
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
        ///txtCD_KeyDown
        ///ボタンの反応(コード入力)
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
                    //this.setHachusuhenko();
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
                    logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));
                    setUriageJisseki();
                    break;
                case STR_BTN_F12: // 終了
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
            object o;
            int theErr;

            //伝票番号の確保
            int intDenpyoNo;

            //発注番号（注文番号）の確保
            string strHachuNo;

            decimal UnchinKin;

            //記入情報登録用
            List<string> lstSaveData = new List<string>();

            //各行の注文Noの有無
            int intChumonCnt = 0;

            //各行の情報を入れる
            bvg = new BaseViewDataGroup[] { gbData1, gbData2, gbData3, gbData4, gbData5 };

            //各行のチェック
            for (int intCnt= 0; intCnt < bvg.Length; intCnt++)
            {
                if (StringUtl.blIsEmpty(bvg[intCnt].txtChumonNo.Text))
                {
                    intChumonCnt = intChumonCnt + 1;
                }
            }

            //どの行も注文番号が書かれていない場合
            if (intChumonCnt == 0)
            {
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "有効な明細行がありません。\r\n伝票が不要な場合は伝票削除（F3)を行ってください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

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

            //運賃の確保
            UnchinKin = int.Parse(string.Format("{0:0}", txtUnchin.Text));
            
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
            //直送先コード（なし）
            //直送先名（なし）
            //郵便番号（直送先）（なし）
            //住所１（直送先）（なし）
            //住所２（直送先）（なし）
            //ユーザーID（判定無し）

            //伝票番号[0]
            lstSaveData.Add(txtDenpyoNo.Text);
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


            //発注番号の確保用
            int intHachuNo;

            //型番確保用
            string strKataban = "";

            //加工受注かどうかの判断
            bool blKakojuchu = false;

            //加工品仕入単価
            int intKakoShireTanka = 0;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
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
                                    //新規の伝票番号を作成、取得
                                    strShohinCd = shireinputBadd.getNewShohinNo();

                                    //商品番号がない場合
                                    if (strShohinCd == "0")
                                    {
                                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "システムエラー", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                        basemessagebox.ShowDialog();
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
                        else
                        {
                            //商品コードの確保
                            strShohinCd = bvg[intCnt].txtShohinCd.Text;
                        }

                        //仕入明細更新用のデータ追加
                        lstMesaiKoshin.Add(intDenpyoNo.ToString());
                        lstMesaiKoshin.Add((intCnt + 1).ToString() );
                        lstMesaiKoshin.Add(bvg[intCnt].txtChumonNo.Text);
                        lstMesaiKoshin.Add(strShohinCd);
                        lstMesaiKoshin.Add(bvg[intCnt].txtMakerCd.Text);
                        lstMesaiKoshin.Add(bvg[intCnt].txtDaibunCd.Text);
                        lstMesaiKoshin.Add(bvg[intCnt].txtChubunCd.Text);
                        lstMesaiKoshin.Add(bvg[intCnt].txtC1.Text);
                        lstMesaiKoshin.Add(bvg[intCnt].txtC2.Text);
                        lstMesaiKoshin.Add(bvg[intCnt].txtC3.Text);
                        lstMesaiKoshin.Add(bvg[intCnt].txtC4.Text);
                        lstMesaiKoshin.Add(bvg[intCnt].txtC5.Text);
                        lstMesaiKoshin.Add(bvg[intCnt].txtC6.Text);
                        lstMesaiKoshin.Add(bvg[intCnt].txtSu.Text);
                        lstMesaiKoshin.Add(string.Format("{0:0.#}", double.Parse(bvg[intCnt].txtTanka.Text)));
                        lstMesaiKoshin.Add(bvg[intCnt].txtKin.Text);
                        lstMesaiKoshin.Add(bvg[intCnt].txtBiko.Text);
                        lstMesaiKoshin.Add(bvg[intCnt].labelSet_Eigyosho.CodeTxtText);
                        lstMesaiKoshin.Add(SystemInformation.UserName);

                        //テスト用にコメントアウトしていた
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
                                dtJuchuDataCnt = shireinputB.getJuchuDataCnt(bvg[intCnt].txtChumonNo.Text);

//テスト中はわざと通す必要あり

                                //カウント1以上の場合
                                //if (int.Parse(dtJuchuDataCnt.Rows[0][0].ToString()) > 0)
                                if (int.Parse(dtJuchuDataCnt.Rows[0][0].ToString()) >= 0)
                                {
                                    //加工をする判定
                                    blKakojuchu = true;
                                }

                                //加工をする判定の場合
                                if (blKakojuchu)
                                {
                                    //加工品仕入単価の取得
                                    intKakoShireTanka = int.Parse((shireinputB.getKakoShireTanka(bvg[intCnt].txtChumonNo.Text)).ToString());

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

                    }//注文番号の有り無し

                }//ループ終了

                //直送先の登録
                //直送先項目の削除のためなし

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
                    if (StringUtl.blIsEmpty(txtJuchu1.Text) == true && int.Parse(txtJuchu1.Text) > 0)
                    {
                        arrJuchuNo[intGyoCnt] = int.Parse(txtJuchu1.Text);
                        intGyoCnt = intGyoCnt + 1;
                    }
                    //受注番号のデータが空でない、且つ1以上の場合(2行目)
                    if (StringUtl.blIsEmpty(txtJuchu2.Text) == true && int.Parse(txtJuchu2.Text) > 0)
                    {
                        arrJuchuNo[intGyoCnt] = int.Parse(txtJuchu2.Text);
                        intGyoCnt = intGyoCnt + 1;
                    }
                    //受注番号のデータが空でない、且つ1以上の場合(3行目)
                    if (StringUtl.blIsEmpty(txtJuchu3.Text) == true && int.Parse(txtJuchu3.Text) > 0)
                    {
                        arrJuchuNo[intGyoCnt] = int.Parse(txtJuchu3.Text);
                        intGyoCnt = intGyoCnt + 1;
                    }
                    //受注番号のデータが空でない、且つ1以上の場合(4行目)
                    if (StringUtl.blIsEmpty(txtJuchu4.Text) == true && int.Parse(txtJuchu4.Text) > 0)
                    {
                        arrJuchuNo[intGyoCnt] = int.Parse(txtJuchu4.Text);
                        intGyoCnt = intGyoCnt + 1;
                    }
                    //受注番号のデータが空でない、且つ1以上の場合(5行目)
                    if (StringUtl.blIsEmpty(txtJuchu5.Text) == true && int.Parse(txtJuchu5.Text) > 0)
                    {
                        arrJuchuNo[intGyoCnt] = int.Parse(txtJuchu5.Text);
                        intGyoCnt = intGyoCnt + 1;
                    }

                    //行数カウントが1以上の場合
                    if (intGyoCnt > 0)
                    {
                        decKin = int.Parse(string.Format("{0:0.#}", int.Parse(txtUnchin.Text) / intGyoCnt));

                        decKinSub = int.Parse(string.Format("{0:0.#}", int.Parse(txtUnchin.Text) / decKin * intGyoCnt));
                                                
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

                    //登録完了メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();

                    //テキストボックスを白紙にする
                    delText();
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
            if (txtEigyouCd.blIsEmpty() == false && txtDenpyoNo.blIsEmpty() == false)
            {
                return;
            }

            //検索時のデータ取り出し先
            DataTable dtSetCd = null;

            //ビジネス層のインスタンス生成
            A0030_ShireInput_B shireinputB = new A0030_ShireInput_B();
            try
            {
                //戻り値のDatatableを取り込む(日付制限の検索)
                dtSetCd = shireinputB.getHidukeseigen("3",txtEigyouCd.Text);

                //検索結果にデータが存在しなければ終了
                if (dtSetCd.Rows.Count == 0)
                {
                    return;
                }

                //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                //仕入入力情報の削除
                shireinputB.delShireInput(txtDenpyoNo.Text ,SystemInformation.UserName);

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //テキストボックスを白紙にする
                delText();

                txtYMD.Focus();

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
        ///selData
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public bool selData()
        {
            bool blGood = false;

            return (blGood);
        }

        ///<summary>
        ///delGyou
        ///行削除
        ///</summary>
        public void delGyou()
        {
            //例外発生メッセージ（OK）
            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "選択中の行を削除します。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_QUESTION);
            basemessagebox.ShowDialog();

            //フォーカス位置を確保
            Control cActiveBefore = this.ActiveControl;

            if (cActiveBefore.Name.ToString() == "gbData1")
            {
                gbData1.delData();
            }
            if (cActiveBefore.Name.ToString() == "gbData2")
            {
                gbData2.delData();
            }
            if (cActiveBefore.Name.ToString() == "gbData3")
            {
                gbData3.delData();
            }
            if (cActiveBefore.Name.ToString() == "gbData4")
            {
                gbData4.delData();
            }
            if (cActiveBefore.Name.ToString() == "gbData5")
            {
                gbData5.delData();
            }

        }

        ///<summary>
        ///delText
        ///テキストボックス等の入力情報を白紙にする
        ///</summary>
        public void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);
            btnF01.Enabled = true;
            btnF03.Enabled = true;
            btnF07.Enabled = true;
            txtYMD.Focus();
        }

        ///<summary>
        ///setUriageJisseki
        ///売り上げ実績画面へ
        ///</summary>
        public void setUriageJisseki()
        {
            object txtSyohinCD;
            object SyohinCD;

            string strSyohinCD;

            //コード未記入の場合
            if (!StringUtl.blIsEmpty(txtCD.Text))
            {
                return;
            }

            //売上実績確認画面へ移動
            D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin uriage = new Form.D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, 0, "", "");
            uriage.ShowDialog();

        }

        ///<summary>
        ///setDenpyo
        ///伝票番号から各種データを取得
        ///</summary>
        public void setDenpyo(object sender, EventArgs e)
        {
            //次のフォーカス位置を確保
            Control cActiveBefore = this.ActiveControl;

            //伝票番号の処理が1度でもあった場合
            if (blDenpyoLeave == true)
            {
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
            string strHinmei;

            string strNM;

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
                    txtGokei.Text = string.Format("{0:0,0}", dtSetShireHeader.Rows[0]["税抜合計金額"]);
                    txtShohizei.Text = string.Format("{0:0,0}", dtSetShireHeader.Rows[0]["消費税"]);
                    txtSogokei.Text = string.Format("{0:0,0}", dtSetShireHeader.Rows[0]["税込合計金額"]);
                    txtUnchin.Text = string.Format("{0:0,0}", dtSetShireHeader.Rows[0]["運賃"]);

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
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
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
                        //[4]
                        lstData.Add(dtSetshire.Rows[intCnt]["大分類コード"].ToString());

                        strHinmei = dtSetshire.Rows[intCnt]["メーカー名"].ToString();

                        //[5]
                        lstData.Add(dtSetshire.Rows[intCnt]["中分類コード"].ToString());

                        //中分類のビジネス層インスタンス生成
                        M1110_Chubunrui_B chubunruiB = new M1110_Chubunrui_B();
                        //中分類のコードと名前を確保
                        dtChubun = chubunruiB.getTxtChubunruiLeave(dtSetshire.Rows[intCnt]["大分類コード"].ToString(), dtSetshire.Rows[intCnt]["中分類コード"].ToString());

                        strHinmei = strHinmei + " " + dtChubun.Rows[0]["中分類名"];

                        //Ｃ１にデータがある場合
                        if (dtSetshire.Rows[intCnt]["Ｃ１"].ToString() != "")
                        {
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ１"].ToString();
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
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ２"].ToString();
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
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ３"].ToString();
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
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ４"].ToString();
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
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ５"].ToString();
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
                            strHinmei = strHinmei + " " + dtSetshire.Rows[intCnt]["Ｃ６"].ToString();
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
                        lstData.Add(dtSetshire.Rows[intCnt]["数量"].ToString());
                        //[14]
                        lstData.Add(dtSetshire.Rows[intCnt]["仕入単価"].ToString());
                        //[15]
                        lstData.Add(dtSetshire.Rows[intCnt]["仕入金額"].ToString());
                        //[16]
                        lstData.Add(dtSetshire.Rows[intCnt]["備考"].ToString());
                        //[17]
                        lstData.Add(dtSetshire.Rows[intCnt]["入庫倉庫"].ToString());

                        //発注番号の取得
                        int intHNo = int.Parse(dtSetshire.Rows[intCnt]["発注番号"].ToString());

                        //発注受注番号の取得
                        DataTable dtHachuJuchu = shireinputB.getHachuJuchu(intHNo.ToString());

                        //行番号-1が0の場合(1行目)
                        if (intRowCntMinus1 == 0)
                        {
                            gbData1.txtChumonNo.Text = dtHachuJuchu.Rows[0][0].ToString();
                            gbData1.setData(lstData);

                            //一行以上ある場合
                            if (dtHachuJuchu.Rows.Count > 0 && dtSetshire.Rows.Count > 0)
                            {
                                txtJuchu1.Text = dtHachuJuchu.Rows[0][0].ToString();

                                //受注単価の取得
                                DataTable dtJuchuTanka = shireinputB.getJuchuTanka(txtJuchu1.Text);

                                txtTanka1.Text = string.Format("{0:#,#}", dtJuchuTanka.Rows[0][0]);
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
                                txtJuchu2.Text = dtHachuJuchu.Rows[0][0].ToString();

                                //受注単価の取得
                                DataTable dtJuchuTanka = shireinputB.getJuchuTanka(txtJuchu2.Text);

                                txtTanka2.Text = string.Format("{0:#,#}", dtJuchuTanka.Rows[0][0]);
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
                                txtJuchu3.Text = dtHachuJuchu.Rows[0][0].ToString();

                                //受注単価の取得
                                DataTable dtJuchuTanka = shireinputB.getJuchuTanka(txtJuchu3.Text);

                                txtTanka3.Text = string.Format("{0:#,#}", dtJuchuTanka.Rows[0][0]);
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
                                txtJuchu4.Text = dtHachuJuchu.Rows[0][0].ToString();

                                //受注単価の取得
                                DataTable dtJuchuTanka = shireinputB.getJuchuTanka(txtJuchu4.Text);

                                txtTanka4.Text = string.Format("{0:#,#}", dtJuchuTanka.Rows[0][0]);
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
                                txtJuchu5.Text = dtHachuJuchu.Rows[0][0].ToString();

                                //受注単価の取得
                                DataTable dtJuchuTanka = shireinputB.getJuchuTanka(txtJuchu5.Text);

                                txtTanka5.Text = string.Format("{0:#,#}", dtJuchuTanka.Rows[0][0]);
                            }
                        }
                    }

                    //フォーカス移動
                    cActiveBefore.Focus();
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
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
                gbData1.delData();
            }
            //二行目
            else if (intRow == 2)
            {
                gbData2.delData();
            }
            //三行目
            else if (intRow == 3)
            {
                gbData3.delData();
            }
            //四行目
            else
            {
                gbData4.delData();
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
            catch(Exception ex)
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
        ///ボタンの反応(伝票入力項目)
        ///</summary>
        private void txtDenpyoNo_KeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.F9:
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    showShireList();
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
            if (!StringUtl.blIsEmpty(txtJuchu1.Text))
            {
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
            if (!StringUtl.blIsEmpty(txtJuchu1.Text))
            {
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
                    txtTanka2.Text = string.Format("{0:0.#}", double.Parse(dtSetCd.Rows[0][0].ToString()));
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
            if (!StringUtl.blIsEmpty(txtJuchu1.Text))
            {
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
                    txtTanka3.Text = string.Format("{0:0.#}", double.Parse(dtSetCd.Rows[0][0].ToString()));
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
            if (!StringUtl.blIsEmpty(txtJuchu1.Text))
            {
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
                    txtTanka4.Text = string.Format("{0:0.#}", double.Parse(dtSetCd.Rows[0][0].ToString()));
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
        ///txtJuchu5_TextChanged
        ///受注番号5が変更になった場合
        ///</summary>
        private void txtJuchu5_TextChanged(object sender, EventArgs e)
        {
            txtTanka5.Clear();

            //受注番号が白紙の場合
            if (!StringUtl.blIsEmpty(txtJuchu1.Text))
            {
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
                    txtTanka5.Text = string.Format("{0:0.#}", double.Parse(dtSetCd.Rows[0][0].ToString()));
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
        ///txtShireInput_KeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void txtShireInput_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
