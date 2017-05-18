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
using KATO.Business.F0140_TanaorosiInput_B;
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
        /// <summary>
        /// M1030_Shohin
        /// フォーム関係の設定
        /// </summary>
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
            this._Title = "業種マスタ";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF10.Text = STR_FUNC_F10_Shohin;
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
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
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
                    this.setKensaku();
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
                    this.setKensaku();
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
        /// labelSet_Daibunrui_Leave
        /// C1からC2のラベルを表示
        /// </summary>
        private void labelSet_Daibunrui_Leave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtCset = new DataTable();

            if (labelSet_Daibunrui.CodeTxtText == "")
            {
                return;
            }

            //データ渡し用
            lstString.Add(labelSet_Daibunrui.CodeTxtText);

            M1030_Shohin_B shohinB = new M1030_Shohin_B();
            try
            {
                dtCset = shohinB.labelSet_Daibunrui_Leave(lstString);

                if (dtCset.Rows[0]["ラベル名１"].ToString() != "")
                {
                    lblBaseLabelC1.Text = dtCset.Rows[0]["ラベル名１"].ToString();
                    lblBaseLabelC1.Visible = true;
                }
                if (dtCset.Rows[0]["ラベル名２"].ToString() != "")
                {
                    lblBaseLabelC2.Text = dtCset.Rows[0]["ラベル名２"].ToString();
                    lblBaseLabelC2.Visible = true;
                }
                if (dtCset.Rows[0]["ラベル名３"].ToString() != "")
                {
                    lblBaseLabelC3.Text = dtCset.Rows[0]["ラベル名３"].ToString();
                    lblBaseLabelC3.Visible = true;
                }
                if (dtCset.Rows[0]["ラベル名４"].ToString() != "")
                {
                    lblBaseLabelC4.Text = dtCset.Rows[0]["ラベル名４"].ToString();
                    lblBaseLabelC4.Visible = true;
                }
                if (dtCset.Rows[0]["ラベル名５"].ToString() != "")
                {
                    lblBaseLabelC5.Text = dtCset.Rows[0]["ラベル名５"].ToString();
                    lblBaseLabelC5.Visible = true;
                }
                if (dtCset.Rows[0]["ラベル名６"].ToString() != "")
                {
                    lblBaseLabelC6.Text = dtCset.Rows[0]["ラベル名６"].ToString();
                    lblBaseLabelC6.Visible = true;
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// setKensaku
        /// 商品リストに移動
        /// </summary>
        private void setKensaku()
        {
            string strKensaku = "";

            string strYMD = "";

            DataTable dtYMD = new DataTable();

            if (txtKensaku.TextLength > 0)
            {
                strKensaku = txtKensaku.Text;
            }

            try
            {
                F0140_TanaorosiInput_B tanaorosiinputB = new F0140_TanaorosiInput_B();
                dtYMD = tanaorosiinputB.setYMD();

                if (dtYMD.Rows.Count != 0)
                {
                    strYMD = dtYMD.Rows[0]["最新棚卸年月日"].ToString();
                }
                else
                {
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
                ShouhinList shouhinlist = new ShouhinList(this);
                shouhinlist.intFrmKind = CommonTeisu.FRM_SHOHIN;
                shouhinlist.strYMD = strYMD;
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

        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            delFormClear(this);
            labelSet_Daibunrui.Focus();
        }

        /// <summary>
        /// delShohin
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void delShohin()
        {

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
    }
}
