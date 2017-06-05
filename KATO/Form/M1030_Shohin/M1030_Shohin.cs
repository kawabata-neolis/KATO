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
using KATO.Business.M1030_Shohin;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M1030_Shohin
{
    ///<summary>
    ///M1030_Shohin
    ///商品フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class M1030_Shohin : BaseForm
    {
        //管理者かどうかの判定
        Boolean blnKanri;

        public M1030_Shohin(Control c)
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
        }

        /// <summary>
        /// M1030_Shohin_Load
        /// 読み込み時
        /// </summary>
        private void M1030_Shohin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品マスター";

//登録か仮登録かの判定（仮）
            if (SystemInformation.UserName == "admin")
            {
                this.btnF01.Text = STR_FUNC_F1_KARITOROKU;
                blnKanri = false;
            }
            else
            {
                this.btnF01.Text = STR_FUNC_F1;
                blnKanri = true;
            }

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF03.Text = STR_FUNC_F3;

            if (blnKanri == false)
            {
                this.btnF03.Enabled = false;
            }

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF10.Text = STR_FUNC_F10_SHOHIN;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;
        }

        /// <summary>
        /// judShohinKeyDown
        /// キー入力判定
        /// </summary>
        private void judShohinKeyDown(object sender, KeyEventArgs e)
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
                    this.addShohin();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delShohin();
                    break;
                case Keys.F4:
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
                    this.setShohinListTana();
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

        /// <summary>
        /// judShohinTxtKeyDown
        /// キー入力判定
        /// </summary>
        private void judShohinTxtKeyDown(object sender, KeyEventArgs e)
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
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// judShohinTxtKeyDown
        /// キー入力判定
        /// </summary>
        private void judKenKataTxtKeyDown(object sender, KeyEventArgs e)
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
                    this.setShohinList();
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

        /// <summary>
        /// judBtnClick
        /// ボタンの反応
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    this.addShohin();
                    break;
                case STR_BTN_F03: // 削除
                    this.delShohin();
                    break;
                case STR_BTN_F04: // 取り消し
                    this.delText();
                    break;
                case STR_BTN_F10: // 棚番無
                    this.setShohinListTana();
                    break;
                //case STR_BTN_F11: //印刷
                //    this.XX();
                //    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// setShohinList
        /// 商品リストに移動
        /// </summary>
        private void setShohinList()
        {
            ShouhinList shouhinlist = new ShouhinList(this);
            try
            {
                shouhinlist.intFrmKind = CommonTeisu.FRM_SHOHIN;
                shouhinlist.strYMD = "";
                shouhinlist.strEigyoushoCode = "";
                shouhinlist.strDaibunruiCode = labelSet_Daibunrui.CodeTxtText;
                shouhinlist.strChubunruiCode = labelSet_Chubunrui.CodeTxtText;
                shouhinlist.strMakerCode = labelSet_Maker.CodeTxtText;
                shouhinlist.strKensaku = txtKensaku.Text;
                shouhinlist.ShowDialog();

                txtHyojun.Focus();
                txtShire.Focus();
                txtHyoka.Focus();
                txtTatene.Focus();
                txtTeika.Focus();
                txtData1.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// setShohinListTana
        /// 商品リストに移動(棚番）
        /// </summary>
        private void setShohinListTana()
        {
            ShouhinList shouhinlist = new ShouhinList(this);
            try
            {
                shouhinlist.intFrmKind = CommonTeisu.FRM_SHOHIN_TANA;
                shouhinlist.strYMD = "";
                shouhinlist.strEigyoushoCode = "";
                shouhinlist.strDaibunruiCode = labelSet_Daibunrui.CodeTxtText;
                shouhinlist.strChubunruiCode = labelSet_Chubunrui.CodeTxtText;
                shouhinlist.strMakerCode = labelSet_Maker.CodeTxtText;
                shouhinlist.strKensaku = txtKensaku.Text;
                shouhinlist.ShowDialog();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// addShohin
        /// テキストボックス内のデータをDBに登録
        /// </summary>
        private void addShohin()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Daibunrui.Focus();
                return;
            }
            if (labelSet_Chubunrui.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Chubunrui.Focus();
                return;
            }
            if (labelSet_Maker.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Maker.Focus();
                return;
            }
            if (txtData1.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtData1.Focus();
                return;
            }
            if (txtHachukbn.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHachukbn.Focus();
                return;
            }
            if (txtHyojun.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHyojun.Focus();
                return;
            }
            if (txtShire.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtShire.Focus();
                return;
            }
            if (txtHyoka.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHyoka.Focus();
                return;
            }
            if (txtTatene.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTatene.Focus();
                return;
            }
            if (txtZaiko.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtZaiko.Focus();
                return;
            }
            if (labelSet_TanabanHonsha.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_TanabanHonsha.Focus();
                return;
            }
            if (labelSet_TanabanGihu.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_TanabanGihu.Focus();
                return;
            }
            if (txtTeika.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtTeika.Focus();
                return;
            }
            if (txtHako.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtHako.Focus();
                return;
            }

            M1030_Shohin_B shohinB = new M1030_Shohin_B();

            lstString.Add(txtShohinCd.Text);
            lstString.Add(labelSet_Maker.CodeTxtText);
            lstString.Add(labelSet_Daibunrui.CodeTxtText);
            lstString.Add(labelSet_Chubunrui.CodeTxtText);
            lstString.Add(txtData1.Text);
            lstString.Add(txtData2.Text);
            lstString.Add(txtData3.Text);
            lstString.Add(txtData4.Text);
            lstString.Add(txtData5.Text);
            lstString.Add(txtData6.Text);
            lstString.Add(txtHachukbn.Text);
            lstString.Add(txtHyojun.Text);
            lstString.Add(txtShire.Text);
            lstString.Add(txtZaiko.Text);
            lstString.Add(labelSet_TanabanHonsha.CodeTxtText);
            lstString.Add(labelSet_TanabanGihu.CodeTxtText);
            lstString.Add(txtMemo.Text);
            lstString.Add(txtHyoka.Text);
            lstString.Add(txtTeika.Text);
            lstString.Add(txtHako.Text);
            lstString.Add(txtTatene.Text);
            lstString.Add(txtComment.Text);

            //ユーザー名
            lstString.Add(SystemInformation.UserName);

            try
            {
                //新規登録
                if (radSet_2btn_Toroku.radbtn0.Checked == true)
                {
                    shohinB.updShohinNew(lstString, blnKanri);
                }
                //修正登録
                else
                {
                    //メッセージボックスの処理、登録完了のウィンドウ（OK）
                    BaseMessageBox basemessageboxUwagaki = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, lblGrayShohin.Text + "\r\n" + CommonTeisu.LABEL_TOUROKU_UWAGAKi, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_EXCLAMATION);
                    //NOが押された場合
                    if (basemessageboxUwagaki.ShowDialog() == DialogResult.No)
                    {
                        return;
                    }

                    shohinB.addShohin(lstString, blnKanri);
                }

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                labelSet_Daibunrui.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            delFormClear(this);
            txtHyojun.Text = "";
            txtShire.Text = "";
            txtHyoka.Text = "";
            txtTatene.Text = "";
            txtTeika.Text = "";
            txtHako.Text = "";
            labelSet_Daibunrui.Focus();
            radSet_2btn_Toroku.radbtn0.Checked = true;
        }

        /// <summary>
        /// delShohin
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void delShohin()
        {
            if (blnKanri == false)
            {
                return;
            }

            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtShohinCd.blIsEmpty() == false)
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

            M1030_Shohin_B shohinB = new M1030_Shohin_B();

            lstString.Add(txtShohinCd.Text);
            lstString.Add(labelSet_Maker.CodeTxtText);
            lstString.Add(labelSet_Daibunrui.CodeTxtText);
            lstString.Add(labelSet_Chubunrui.CodeTxtText);
            lstString.Add(txtData1.Text);
            lstString.Add(txtData2.Text);
            lstString.Add(txtData3.Text);
            lstString.Add(txtData4.Text);
            lstString.Add(txtData5.Text);
            lstString.Add(txtData6.Text);
            lstString.Add(txtHachukbn.Text);
            lstString.Add(txtHyojun.Text);
            lstString.Add(txtShire.Text);
            lstString.Add(txtZaiko.Text);
            lstString.Add(labelSet_TanabanHonsha.CodeTxtText);
            lstString.Add(labelSet_TanabanGihu.CodeTxtText);
            lstString.Add(txtMemo.Text);
            lstString.Add(txtHyoka.Text);
            lstString.Add(txtTeika.Text);
            lstString.Add(txtHako.Text);
            lstString.Add(txtTatene.Text);
            lstString.Add(txtComment.Text);

            //ユーザー名
            lstString.Add(SystemInformation.UserName);

            try
            {
                shohinB.delShohin(lstString, blnKanri);

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                //テキストボックスを白紙にする
                delText();
                labelSet_Daibunrui.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// setShouhin
        ///取り出したデータをテキストボックスに配置（商品リスト）
        /// </summary>
        public void setShouhin(DataTable dtShohin)
        {
            delFormClear(this);

            labelSet_Daibunrui.CodeTxtText = dtShohin.Rows[0]["大分類コード"].ToString();
            labelSet_Chubunrui.CodeTxtText = dtShohin.Rows[0]["中分類コード"].ToString();
            labelSet_Maker.CodeTxtText = dtShohin.Rows[0]["メーカーコード"].ToString();
            txtShohinCd.Text = dtShohin.Rows[0]["商品コード"].ToString();

            txtData1.Text = dtShohin.Rows[0]["Ｃ１"].ToString();
            txtData2.Text = dtShohin.Rows[0]["Ｃ２"].ToString();
            txtData3.Text = dtShohin.Rows[0]["Ｃ３"].ToString();
            txtData4.Text = dtShohin.Rows[0]["Ｃ４"].ToString();
            txtData5.Text = dtShohin.Rows[0]["Ｃ５"].ToString();
            txtData6.Text = dtShohin.Rows[0]["Ｃ６"].ToString();
            txtHachukbn.Text = dtShohin.Rows[0]["発注区分"].ToString();
            txtHyojun.Text = dtShohin.Rows[0]["標準売価"].ToString();
            txtShire.Text = dtShohin.Rows[0]["仕入単価"].ToString();
            txtHyoka.Text = dtShohin.Rows[0]["評価単価"].ToString();
            txtTatene.Text = dtShohin.Rows[0]["建値仕入単価"].ToString();
            txtZaiko.Text = dtShohin.Rows[0]["在庫管理区分"].ToString();
            labelSet_TanabanHonsha.CodeTxtText = dtShohin.Rows[0]["棚番本社"].ToString();
            labelSet_TanabanGihu.CodeTxtText = dtShohin.Rows[0]["棚番岐阜"].ToString();
            txtMemo.Text = dtShohin.Rows[0]["メモ"].ToString();
            txtTeika.Text = dtShohin.Rows[0]["定価"].ToString();
            txtHako.Text = dtShohin.Rows[0]["箱入数"].ToString();
            txtComment.Text = dtShohin.Rows[0]["コメント"].ToString();

            lblGrayShohin.Text =
                labelSet_Maker.CodeTxtText + " " +
                labelSet_Daibunrui.CodeTxtText + " " +
                labelSet_Chubunrui.CodeTxtText + " " +
                txtData1.Text + " " +
                txtData2.Text + " " +
                txtData3.Text + " " +
                txtData4.Text + " " +
                txtData5.Text + " " +
                txtData6.Text + " ";

            lblGrayToroku.Text = ((DateTime)dtShohin.Rows[0]["登録日時"]).ToString("yyyy/MM/dd");

            radSet_2btn_Toroku.radbtn1.Checked = true;
        }

        ///<summary>
        ///setShohinClose
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setShohinClose()
        {
            txtData1.Focus();
        }

        /// <summary>
        /// judtxtShohinKeyUp
        /// 入力項目上でのキー判定と文字数判定（）
        /// </summary>
        private void judtxtShohinKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ とタブ、エンター
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                return;
            }
            //キーボードの方向キー4つ
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            {
                return;
            }

            //前後の空白を取り除く
            ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

            if (((TextBox)sender).Text == "")
            {
                return;
            }

            if (this.ActiveControl.Name == "txtHachukbn")
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
            else if (this.ActiveControl.Name == "txtZaiko")
            {
                if (((TextBox)sender).Text != "1" && ((TextBox)sender).Text != "0")
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, "", CommonTeisu.LABEL_ZEROORONE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
                else
                {
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                }
            }
        }

        /// <summary>
        /// txtMemo_KeyDown
        /// エンターでの改行で5行以上いった場合動作を止める
        /// </summary>
        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtMemo.Lines.Length > 5)
            {
                e.Handled = true;
            }
        }

        ///<summary>
        ///updCtxtLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void updCtxtLeave(object sender, EventArgs e)
        {
            lblGrayShohin.Text =
                labelSet_Maker.CodeTxtText + " " +
                labelSet_Daibunrui.CodeTxtText + " " +
                labelSet_Chubunrui.CodeTxtText + " " +
                txtData1.Text + " " +
                txtData2.Text + " " +
                txtData3.Text + " " +
                txtData4.Text + " " +
                txtData5.Text + " " +
                txtData6.Text + " ";
        }
    }
}
