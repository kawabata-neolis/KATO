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
using KATO.Common.Util;
using KATO.Common.Form;
using KATO.Business.A0030_ShireInput;
using static KATO.Common.Util.CommonTeisu;

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
                dtSetshire = shireinputB.getShiremesai(txtDenpyoNo.Text);

                //取得したデータが1行以上あった場合
                if (dtSetshire.Rows.Count > 0)
                {
                    //vb1284行目から
                }

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
