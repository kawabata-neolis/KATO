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

        //行数
        int intMaxRow = 4;

        //伝票番号のLeaveの処理をしたかどうか
        bool blDenpyoLeave = false;

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
//                    this.addHachu();
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
//
                    break;
                case Keys.F8:
                    logger.Info(LogUtil.getMessage(this._Title, "履歴実行"));
//                    this.setRireki();
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
        ///addShireInput
        ///テキストボックス内のデータをDBに追加
        ///</summary>
        public void addShireInput()
        {
            object o;
            object SyohinCD;
            int theErr;
            int Denno;

            decimal UnchinKin;

            //伝票番号
            if (txtDenpyoNo.blIsEmpty() == false)
            {
                return;
            }
            //年月日
            if (txtYMD.blIsEmpty() == false)
            {
                return;
            }
            //コード
            if (txtCD.blIsEmpty() == false)
            {
                return;
            }
            //仕入先名
            if (txtShireNameView.blIsEmpty() == false)
            {
                return;
            }
            //郵便番号
            if (txtYubinView.blIsEmpty() == false)
            {
                return;
            }
            //住所１
            if (txtJusho1View.blIsEmpty() == false)
            {
                return;
            }
            //住所２
            if (txtJusho2View.blIsEmpty() == false)
            {
                return;
            }
            //取引区分
            if (StringUtl.blIsEmpty(labelSet_Torihikikbn.ValueLabelText) == false)
            {
                return;
            }
            //担当者名
            if (StringUtl.blIsEmpty(labelSet_Tantousha.ValueLabelText) == false)
            {
                return;
            }
            //営業所コード
            if (txtEigyouCd.blIsEmpty() == false)
            {
                return;
            }
            //DBNull(なし)
            //摘要
            if (txtTekiyo.blIsEmpty() == false)
            {
                return;
            }
            //運賃
            if (txtUnchin.blIsEmpty() == false)
            {
                return;
            }
            //合計
            if (txtGokei.blIsEmpty() == false)
            {
                return;
            }
            //消費税
            if (txtShohizei.blIsEmpty() == false)
            {
                return;
            }
            //総合計
            if (txtSogokei.blIsEmpty() == false)
            {
                return;
            }
            //直送先コード（なし）
            //直送先名（なし）
            //郵便番号（直送先）（なし）
            //住所１（直送先）（なし）
            //住所２（直送先）（なし）
            //ユーザーID（判定無し）


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
                //delText();

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

        }

        ///<summary>
        ///setGokeiKeisan
        ///合計計算
        ///</summary>
        public void setGokeiKeisan()
        {

        }

        ///<summary>
        ///delText
        ///テキストボックス等の入力情報を白紙にする
        ///</summary>
        public void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);
            txtYMD.Focus();
        }

        ///<summary>
        ///setUriageJisseki
        ///売り上げ実績から商品コードの取得
        ///</summary>
        public void setUriageJisseki()
        {

        }

        ///<summary>
        ///setDenpyo
        ///伝票番号から各種データを取得
        ///</summary>
        public void setDenpyo(object sender, EventArgs e)
        {
            //伝票番号の処理が1度でもあった場合
            if (blDenpyoLeave == true)
            {
                //初期化
                blDenpyoLeave = false;
                return;
            }

            //品名データを作成する用
            string strHinmei;

            string strNM;

            //検収済仕入明細のカウント
            int intKenshuShireCnt;

            //ロックをかける
            blRock = true;

            txtYMD.Clear();
            txtCD.Clear();

            //各行の削除
            for (int intCnt = 0; intCnt <= intMaxRow; intCnt++)
            {
                delLine(intCnt);
            }

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

                //検索結果にデータが存在しなければ終了
                if (dtSetShireHeader.Rows.Count == 0)
                {
                    return;
                }

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
                txtGokei.Text = string.Format("{0:#,#}", dtSetShireHeader.Rows[0]["税抜合計金額"]);
                txtShohizei.Text = string.Format("{0:#,#}", dtSetShireHeader.Rows[0]["消費税"]);
                txtSogokei.Text = string.Format("{0:#,#}", dtSetShireHeader.Rows[0]["税込合計金額"]);
                txtUnchin.Text = string.Format("{0:#,#}", dtSetShireHeader.Rows[0]["運賃"]);

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
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    blRock = false;
                    txtDenpyoNo.Focus();
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
                            goto Unchin_JP;
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
                            gbData1.strJuchuNo = dtHachuJuchu.Rows[0][0].ToString();
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
                            gbData2.strJuchuNo = dtHachuJuchu.Rows[0][0].ToString();
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
                            gbData3.strJuchuNo = dtHachuJuchu.Rows[0][0].ToString();
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
                            gbData4.strJuchuNo = dtHachuJuchu.Rows[0][0].ToString();
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
                            gbData5.strJuchuNo = dtHachuJuchu.Rows[0][0].ToString();
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
                }                
            txtYMD.Focus();

            //次のフォーカスに移動
            Unchin_JP:
                SendKeys.Send("{TAB}");

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
    }
}
