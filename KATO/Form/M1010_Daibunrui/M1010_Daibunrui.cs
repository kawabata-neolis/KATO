using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Business.M_Daibunrui;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.M_Daibunrui
{
    public partial class M_Daibunrui : BaseForm
    {
        string strCoverDaibun = "";

        public M_Daibunrui()
        {
            InitializeComponent();
        }

        private void M_Daibunrui_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "大分類マスタ";
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
        ///judDaiBunruiKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/2/28
        ///更新者：大河内
        ///更新日：2017/3/2
        ///カラム論理名
        ///</summary>
        private void judDaiBunruiKeyDown(object sender, KeyEventArgs e)
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
                    this.addDaibunrui();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delDaibunrui();
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
//印刷
//PrintReport();
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
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/3/28
        ///カラム論理名
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    this.addDaibunrui();
                    break;
                case STR_BTN_F03: // 削除
                    this.delDaibunrui();
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
        ///addDaibunrui
        ///テキストボックス内のデータをDBに登録
        ///作成者：大河内
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/4/6
        ///カラム論理名
        ///</summary>
        private void addDaibunrui()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (txtDaibunrui.blIsEmpty() == false || txtName.blIsEmpty() == false)
            {
                MessageBox.Show("項目が空です。文字を入力してください。", "入力項目", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //データ渡し用
            lstString.Add(txtDaibunrui.Text);
            lstString.Add(txtName.Text);
            lstString.Add(txtLabel1.Text);
            lstString.Add(txtLabel2.Text);
            lstString.Add(txtLabel3.Text);
            lstString.Add(txtLabel4.Text);
            lstString.Add(txtLabel5.Text);
            lstString.Add(txtLabel6.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動
            Daibunrui_B daibunB = new Daibunrui_B();
            daibunB.addDaibunrui(lstString);

            delText();
            txtDaibunrui.Focus();
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除
        ///作成者：大河内
        ///作成日：2017/3/1
        ///更新者：大河内
        ///更新日：2017/3/2
        ///カラム論理名
        ///</summary>
        private void delText()
        {
            //delFormClear(this);
            BaseForm formreset = new BaseForm();
            formreset.delFormClear(this);

            txtDaibunrui.Focus();
        }

        ///<summary>
        ///delDaibunrui
        ///テキストボックス内のデータをDBから削除
        ///作成者：大河内
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public void delDaibunrui()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            bool blDelFinish = false;

            //文字判定
            if (txtDaibunrui.blIsEmpty() == false && txtName.blIsEmpty() == false)
            {
                return;
            }

            //データ渡し用
            lstString.Add(txtDaibunrui.Text);
            lstString.Add(SystemInformation.UserName);

            //処理部に移動
            Daibunrui_B daibunB = new Daibunrui_B();
            blDelFinish = daibunB.delDaibunrui(lstString);

            if (blDelFinish == true)
            {
                //テキストボックスを白紙にする
                delText();
                txtDaibunrui.Focus();
            }
        }

        ///<summary>
        ///delFormClear
        ///フォーム上の項目を初期化
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        public void delFormClear(Control hParent)
        {
            // hParent 内のすべてのコントロールを列挙する
            foreach (Control cControl in hParent.Controls)
            {
                // 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                if (cControl.HasChildren == true)
                {
                    delFormClear(cControl);
                }

                // コントロールの型が TextBoxBase からの派生型の場合は Text をクリアする
                if (cControl is TextBoxBase)
                {
                    cControl.Text = string.Empty;
                }
            }
        }

        ///<summary>
        ///setDaibunrui
        ///取り出したデータをテキストボックスに配置
        ///作成者：大河内
        ///作成日：2017/3/1
        ///更新者：大河内
        ///更新日：2017/3/2
        ///カラム論理名
        ///</summary>
        public void setDaibunrui(DataTable dtSelectData)
        {
            txtDaibunrui.Text = dtSelectData.Rows[0]["大分類コード"].ToString();
            txtName.Text = dtSelectData.Rows[0]["大分類名"].ToString();
            txtLabel1.Text = dtSelectData.Rows[0]["ラベル名１"].ToString();
            txtLabel2.Text = dtSelectData.Rows[0]["ラベル名２"].ToString();
            txtLabel3.Text = dtSelectData.Rows[0]["ラベル名３"].ToString();
            txtLabel4.Text = dtSelectData.Rows[0]["ラベル名４"].ToString();
            txtLabel5.Text = dtSelectData.Rows[0]["ラベル名５"].ToString();
            txtLabel6.Text = dtSelectData.Rows[0]["ラベル名６"].ToString();
        }

        ///<summary>
        ///judtxtDaiBunruiKeyDown
        ///コード入力項目でのキー入力判定
        ///作成者：大河内
        ///作成日：2017/2/27
        ///更新者：大河内
        ///更新日：2017/3/2
        ///カラム論理名
        ///</summary>
        private void judtxtDaibunruiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                DaibunruiList daibunruiList = new DaibunruiList();
                daibunruiList.Left = 100;
                daibunruiList.StartPosition = FormStartPosition.Manual;
                daibunruiList.intFrmKind = CommonTeisu.FRM_DAIBUNRUI;
                daibunruiList.Show();
            }
        }

        ///<summary>
        ///judtxtDaibunruLeave
        ///code入力箇所からフォーカスが外れた時
        ///作成者：大河内
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public void judtxtDaibunruiLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetcode;

            //文字判定
            if (txtDaibunrui.blIsEmpty() == false)
            {
                return;
            }

            //前後の空白を取り除く
            txtDaibunrui.Text = txtDaibunrui.Text.Trim();

            if (txtDaibunrui.TextLength == 1)
            {
                txtDaibunrui.Text = txtDaibunrui.Text.ToString().PadLeft(2, '0');
            }

            //データ渡し用
            lstString.Add(txtDaibunrui.Text);

            //処理部に移動
            Daibunrui_B daibunB = new Daibunrui_B();
            //戻り値のDatatableを取り込む
            dtSetcode = daibunB.judTxtDaibunruiLeave(lstString);

            if (dtSetcode.Rows.Count == 0)
            {
                txtDaibunrui.Focus();
                return;
            }
            else
            {
                txtDaibunrui.Text = dtSetcode.Rows[0]["大分類コード"].ToString();
                txtName.Text = dtSetcode.Rows[0]["大分類名"].ToString();
                txtLabel1.Text = dtSetcode.Rows[0]["ラベル名１"].ToString();
                txtLabel2.Text = dtSetcode.Rows[0]["ラベル名２"].ToString();
                txtLabel3.Text = dtSetcode.Rows[0]["ラベル名３"].ToString();
                txtLabel4.Text = dtSetcode.Rows[0]["ラベル名４"].ToString();
                txtLabel5.Text = dtSetcode.Rows[0]["ラベル名５"].ToString();
                txtLabel6.Text = dtSetcode.Rows[0]["ラベル名６"].ToString();
                txtName.Focus();

                strCoverDaibun = dtSetcode.Rows[0]["大分類コード"].ToString(); ;
            }
        }

        ///<summary>
        ///setDaibunruiListClose
        ///DaibunruiListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/3/2
        ///カラム論理名
        ///</summary>
        public void setDaibunruiListClose()
        {
            txtDaibunrui.Focus();
        }

        ///<summary>
        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/28
        ///更新者：大河内
        ///更新日：2017/3/28
        ///カラム論理名
        ///</summary>
        private void judtxtDaibunruiKeyUp(object sender, KeyEventArgs e)
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

            if (txtDaibunrui.TextLength == 2)
            {
                judtxtDaibunruiLeave(sender, e);
            }
        }

    }
}
