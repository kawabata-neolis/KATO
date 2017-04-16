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
using KATO.Business.M1020_Maker_B;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M_Maker
{
    public partial class M_Maker : BaseForm
    {
        public M_Maker()
        {
            InitializeComponent();
        }

        private void M_Maker_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "メーカーマスタ";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;
        }

        ///<summary>
        ///judMakerKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/3/6
        ///更新者：大河内
        ///更新日：2017/3/6
        ///カラム論理名
        ///</summary>
        private void judMakerKeyDown(object sender, KeyEventArgs e)
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
                    this.addMaker();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delMaker();
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
        ///judBtnClick
        ///ボタンの反応
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/3
        ///カラム論理名
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    this.addMaker();
                    break;
                case STR_BTN_F03: // 削除
                    this.delMaker();
                    break;
                case STR_BTN_F04: // 取り消し
                    this.delText();
                    break;
                //case STR_BTN_F11: //印刷
                //    this.XX();
                //    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }


        ///<summary>
        ///addMaker
        ///テキストボックス内のデータをDBに登録
        ///作成者：大河内
        ///作成日：2017/3/9
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        private void addMaker()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtMaker.blIsEmpty() == false)
            {
                MessageBox.Show("項目が空です。文字を入力してください。", "入力項目", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //データ渡し用
            lstString.Add(txtMaker.Text);
            lstString.Add(txtName.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動
            M1020_Maker_B makerB = new M1020_Maker_B();
            //戻り値のDatatableを取り込む
            makerB.addMaker(lstString);

            delText();
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除、ボタンの機能を消す
        ///作成者：大河内
        ///作成日：2017/3/9
        ///更新者：大河内
        ///更新日：2017/3/8
        ///カラム論理名
        ///</summary>
        private void delText()
        {
            BaseForm formreset = new BaseForm();
            formreset.delFormClear(this);
            txtMaker.Focus();
        }

        ///<summary>
        ///delMaker
        ///テキストボックス内のデータをDBから削除
        ///作成者：大河内
        ///作成日：2017/3/9
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public void delMaker()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            bool blDelFinish = false;

            //文字判定
            if (txtMaker.blIsEmpty() == false)
            {
                return;
            }

            //データ渡し用
            lstString.Add(txtMaker.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動
            M1020_Maker_B makerb = new M1020_Maker_B();
            //戻り値のDatatableを取り込む
            blDelFinish = makerb.delMaker(lstString);

            if (blDelFinish == true)
            {
                //テキストボックスを白紙にする
                delText();
                txtMaker.Focus();
            }
        }

        ///<summary>
        ///setMakerCode
        ///取り出したデータをテキストボックスに配置
        ///作成者：大河内
        ///作成日：2017/3/6
        ///更新者：大河内
        ///更新日：2017/3/6
        ///カラム論理名
        ///</summary>
        public void setMakerCode(DataTable dtSelectData)
        {
            txtMaker.Text = dtSelectData.Rows[0]["メーカーコード"].ToString();
            txtName.Text = dtSelectData.Rows[0]["メーカー名"].ToString();
        }

        ///<summary>
        ///txtMakerKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/3/6
        ///更新者：大河内
        ///更新日：2017/3/7
        ///カラム論理名
        ///</summary>
        private void txtMakerKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                MakerList makerlist = new MakerList();
                makerlist.Left = 100;
                makerlist.StartPosition = FormStartPosition.Manual;
                makerlist.intFrmKind = CommonTeisu.FRM_MAKER;
                makerlist.Show();
            }
        }

        ///<summary>
        ///judtxtMakerTextLeave
        ///code入力箇所からフォーカスが外れた時
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        public void judtxtMakerTextLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetcode;

            if (txtMaker.Text.Equals(null) || String.IsNullOrWhiteSpace(txtMaker.Text).Equals(true))
            {
                txtMaker.Text.Equals("");
                txtName.Focus();
                return;
            }

            if (txtMaker.TextLength <= 3)
            {
                txtMaker.Text = txtMaker.Text.ToString().PadLeft(3, '0');
            }

            //データ渡し用
            lstString.Add(txtMaker.Text);

            //処理部に移動
            M1020_Maker_B makerB = new M1020_Maker_B();
            //戻り値のDatatableを取り込む
            dtSetcode = makerB.judtxtMakerTextLeave(lstString);

            //前後の空白を取り除く
            txtMaker.Text = txtMaker.Text.Trim();

            if (dtSetcode.Rows.Count == 0)
            {
            }
            else
            {
                txtMaker.Text = dtSetcode.Rows[0]["メーカーコード"].ToString();
                txtName.Text = dtSetcode.Rows[0]["メーカー名"].ToString();
            }
            txtName.Focus();
        }


        ///<summary>
        ///setmakerListClose
        ///MakerListCloseが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/3
        ///更新者：大河内
        ///更新日：2017/3/3
        ///カラム論理名
        ///</summary>
        public void setmakerListClose()
        {
            txtMaker.Focus();
        }

        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judtxtMakerKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtMaker.TextLength == 3)
            {
                judtxtMakerTextLeave(sender, e);
            }
        }
    }
}
