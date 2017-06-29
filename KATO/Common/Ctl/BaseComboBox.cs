using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Ctl
{
    public partial class BaseComboBox : ComboBox
    {
        //最初のクリックかの判断
        Boolean firstclickjud = true;

        Boolean blnNull;

        //コンボボックスのリスト一部表示用
        string strMoney = null;

        //KeyDown時に方向キーの場合true
        bool blHoukouKey = false;

        //方向キーのどこを押したか用
        int intHoukou = 0;

        //リストのフォーカス位置の確保
        int intSelectBefore = 0;

        Boolean blankFlg;
        public Boolean blnBlankFlg
        {
            get
            {
                return this.blankFlg;
            }
            set
            {
                this.blankFlg = value;
            }
        }

        public BaseComboBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        //
        //この場所にフォーカスされた時
        //
        private void BaseText_Enter(object sender, EventArgs e)
        {
            //背景色をシアンにする
            this.BackColor = Color.Cyan;

            //this.SelectAll();
            if (firstclickjud == true && this.Text != "")
            {
                //全選択
                this.SelectAll();

                //クリックによる全選択を有効にする
                this.BeginInvoke(new MethodInvoker(() => this.SelectAll()));

                //二回目以降のクリックに切り替える
                firstclickjud = false;
            }
        }

        //
        //別の場所にフォーカスされた時
        //
        private void BaseText_Leave(object sender, EventArgs e)
        {
            //背景色を白にする
            this.BackColor = Color.White;

            //フォーカスが外れたのでリセット
            firstclickjud = true;
        }

        //
        //文字判定
        //
        public bool blIsEmpty()
        {
            Boolean good = true;

            if (this.Text == "" || String.IsNullOrWhiteSpace(this.Text).Equals(true))
            {
                good = false;
            }
            return (good);
        }

        //
        //コンボボックスのリストに入れる
        //
        public Boolean setComboBox(KeyValuePair<int, string>[] kvpComboBox)
        {
            //コンボボックス内にデータを入れる
            this.DataSource = kvpComboBox;
            this.DisplayMember = "Value";
            this.ValueMember = "Key";

            if (this.DataSource == null)
            {
                blnNull = true;
            }

            if (blankFlg == true)
            {
                blnNull = true;
            }

            return (blnNull);
        }


        //
        //コンボボックスのリストを選択後
        //
        private void BaseComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ////方向キーが入力されていた場合
            //if (blHoukouKey == true)
            //{
            //    return;
            //}

            //parentが発注入力の場合
            if (this.Parent.Parent.Name == "A0100_HachuInput")
            {
                //↑キー
                if (intHoukou == 1)
                {
                    //リストの下限を下回る場合
                    if (intSelectBefore -1 < 0)
                    {
                        return;
                    }
                    this.SelectedIndex = intSelectBefore - 1;
                }
                //↓キー
                else if(intHoukou == 2)
                {
                    //リストの上限を超える場合
                    if (intSelectBefore + 1 >= this.Items.Count -1)
                    {
                        return;
                    }
                    this.SelectedIndex = intSelectBefore + 1;
                }

                //選んだアイテムがある場合
                if (this.SelectedItem != null)
                {
                    //コロンより手前（金額）のみを読み取る
                    strMoney = this.SelectedItem.ToString().Split(':')[0];

                    //インデックスを変更して、選択元データを読み取らないようにする
                    this.Items[0] = strMoney;

                    //元のフォーカス位置の確保
                    intSelectBefore = this.SelectedIndex;

                    //インデックスを変更して、選択元データを読み取らないようにする
                    this.SelectedIndex = 0;

                    this.DisplayMember = strMoney;
                    this.Text = strMoney;
                }
                else
                {
                    //this.Text = strMoney;
                }
                intHoukou = 0;
                blHoukouKey = false;
            }
        }

        //
        //キー入力判定
        //
        private void BaseComboBox_KeyDown(object sender, KeyEventArgs e)
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
                    intHoukou = 1;
                    blHoukouKey = true;
                    BaseComboBox_SelectionChangeCommitted(sender, e);
                    break;
                case Keys.Down:
                    intHoukou = 2;
                    blHoukouKey = true;
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

        //
        //クリック判定
        //
        private void BaseComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            blHoukouKey = false;
        }
    }
}
