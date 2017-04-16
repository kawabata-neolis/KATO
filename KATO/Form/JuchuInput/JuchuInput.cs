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
using KATO.Business.JuchuInput;
using static KATO.Common.Util.CommonTeisu;
using System.Collections;

namespace KATO.Form.JuchuInput
{
    public partial class JuchuInput : BaseForm
    {
        public JuchuInput()
        {
            InitializeComponent();
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除
        ///作成者：大河内
        ///作成日：2017/4/5
        ///更新者：大河内
        ///更新日：2017/4/5
        ///カラム論理名
        ///</summary>
        private void delText()
        {
            //delFormClear(this);
            BaseForm formreset = new BaseForm();
            formreset.delFormClear(this);

            baseText1.Focus();
        }



        private void baseText1_Leave(object sender, EventArgs e)
        {
            DataTable dtSetcode;

            //表示時に空にするかどうか
            baseComboBox1.BlankFlg = false;

            //配列
            string[] strListJuchu;
            string[] strListShiire;

            //ArrayList作成
            ArrayList lstBaseComboBox1 = new ArrayList();
            ArrayList lstBaseComboBox2 = new ArrayList();

            //コンボボックスのリストを削除
            baseComboBox1.Items.Clear();
            baseComboBox2.Items.Clear();

            //文字判定
            if (baseText1.blIsEmpty() == false)
            {
                return;
            }

            //前後の空白を取り除く
            baseText1.Text = baseText1.Text.Trim();

            //処理部に移動
            JuchuInput_B juchuinputB = new JuchuInput_B();
            //戻り値のDatatableを取り込む
            dtSetcode = juchuinputB.baseText1_Leave(baseText1.Text);

            if (dtSetcode.Rows.Count == 0)
            {
                baseText1.Focus();
                return;
            }
            else
            {
                decimal decTyoubosuu = Math.Floor(decimal.Parse(dtSetcode.Rows[0]["受注単価"].ToString()));
                dtSetcode.Rows[0]["受注単価"] = decTyoubosuu.ToString();
                decimal decTanasuu = Math.Floor(decimal.Parse(dtSetcode.Rows[0]["仕入単価"].ToString()));
                dtSetcode.Rows[0]["仕入単価"] = decTanasuu.ToString();

                lstBaseComboBox1.Add(dtSetcode.Rows[0]["受注単価"].ToString());
                lstBaseComboBox2.Add(dtSetcode.Rows[0]["仕入単価"].ToString());

                //処理部
                strListJuchu = baseComboBox1.setComboBox(lstBaseComboBox1);
                strListShiire = baseComboBox2.setComboBox(lstBaseComboBox2);

                baseComboBox1.Text = strListJuchu[0];
                baseComboBox2.Text = strListShiire[0];

                baseComboBox1.Focus();
            }
        }

        private void baseComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baseLabelGray1.Text = baseComboBox1.Text;
        }

        ///<summary>
        ///judDaiBunruiKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/4/6
        ///更新者：大河内
        ///更新日：2017/4/6
        ///カラム論理名
        ///</summary>
        private void judJuchuInputKeyDown(object sender, KeyEventArgs e)
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
                    //this.addDaibunrui();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    //this.delDaibunrui();
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
        ///作成日：2017/4/6
        ///更新者：大河内
        ///更新日：2017/4/6
        ///カラム論理名
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    //this.addDaibunrui();
                    break;
                case STR_BTN_F03: // 削除
                    //this.delDaibunrui();
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

        private void money1_Leave(object sender, EventArgs e)
        {
            money1.updMoneyEnter(sender, e);
        }
    }
}
