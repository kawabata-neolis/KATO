using System;
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
    public partial class BaseTextMoney : BaseText
    {
        //記入の可不可
        Boolean blnEntry = true;

        //整数部
        string strIntArea = "";

        //小数点以下部
        string strDeciArea = "";

        //テキストボックス内データの「.」の位置
        int intPeriodPosi =0;

        //小数点以下の桁数
        int _intDeciSet = 0;

        //整数の桁数
        int _intIntegerSet = 0;

        //カンマ入力の可不可(他で決定）
        Boolean _blnCommaOK = true;


        //（アクセス識別子) (型) (プロパティ名)
        public int intDeciSet
        {
            get
            {
                //プロパティデータにデータを入れる場合
                return this._intDeciSet;
            }
            set
            {
                //プロパティデータからデータを取り出す場合
                this._intDeciSet = value;
                setTextLength();
            }
        }

        //（アクセス識別子) (型) (プロパティ名)
        public int intIntederSet
        {
            get
            {
                //プロパティデータにデータを入れる場合
                return this._intIntegerSet;
            }
            set
            {
                //プロパティデータからデータを取り出す場合
                this._intIntegerSet = value;
                setTextLength();
            }
        }

        //（アクセス識別子) (型) (プロパティ名)
        public Boolean blnCommaOK
        {
            get
            {
                //プロパティデータにデータを入れる場合
                return this._blnCommaOK;
            }
            set
            {
                //プロパティデータからデータを取り出す場合
                this._blnCommaOK = value;
            }
        }

        private void setTextLength()
        {
            //小数点以下を扱う場合
            if (_intDeciSet > 0)
            {
                //ピリオド分が＋１になる
                this.MaxLength = this._intDeciSet + this._intIntegerSet + 1;
            }
            //整数のみを扱う場合
            else
            {
                this.MaxLength = this._intIntegerSet;
            }
        }


        public BaseTextMoney()
        {
            InitializeComponent();

            //右寄せ
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        //
        //この場所にフォーカスされた時
        //
        private void updMoneyEnter(object sender, EventArgs e)
        {
            //カンマ付け、小数点以下付けに移動
            updPriceMethod();

        }

        //
        //別の場所にフォーカスされた時
        //
        private void updMoneyLeave(object sender, EventArgs e)
        {
            //カンマ付け、小数点以下付けに移動
            updPriceMethod();
        }

        //
        //textboxに入力された場合
        //
        private void updMoneyKeyPress(object sender, KeyPressEventArgs e)
        {
            //小数点以下を許可
            if (_intDeciSet > 0)
            {
                blnEntry = true;

                if (e.KeyChar == '.')
                {
                    //文字チェック,チェック用のLISTを作成
                    List<string> checklist = new List<string>();

                    checklist.Add(this.Text);

                    //テキストボックス内のチェック
                    foreach (string Listvalue in checklist)
                    {
                        //「.]があった場合入力させない
                        if (this.Text.Contains('.'))
                        {
                            blnEntry = false;
                        }
                    }
                }
                if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                {
                    //押されたキーが 0～9でない場合は、イベントをキャンセルする
                    blnEntry = false;
                }

            }
            //小数点以下を拒否
            else if (_intDeciSet == 0)
            {
                blnEntry = true;

                if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
                {
                    //押されたキーが 0～9でない場合は、イベントをキャンセルする
                    blnEntry = false;
                }

            }

            //小数点以下の記載を認める
            else if (_intDeciSet > 0)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                blnEntry = false;
            }

            //最終的な入力判定
            if (blnEntry == false)
            {
                e.Handled = true;
            }
        }

        //
        //カンマ付け、小数点以下付けに移動
        //
        public void updPriceMethod()
        {
            //テキストボックス内が空の場合スルー
            if (this.Text == "")
            {
                return;
            }

            //[,]を取り除く
            //文字チェック,チェック用のLISTを作成
            List<string> checklist = new List<string>();

            //テキストボックス内のデータを確保
            string strtextBox = this.Text;

            //リストに追加
            checklist.Add(strtextBox);

            //テキストボックス内のチェック
            foreach (string Listvalue in checklist)
            {
                //「,]があった場合一度取り除く
                if (strtextBox.Contains(','))
                {
                    strtextBox = strtextBox.Replace(",", "");
                }
            }
            this.Text = strtextBox;

            //ピリオドの位置の確保
            intPeriodPosi = this.Text.IndexOf('.');

            //ピリオドがない場合
            if (intPeriodPosi == -1)
            {
                strIntArea = this.Text;
            }
            else
            {
                //整数部のみを取り出す
                strIntArea = this.Text.Substring(0, intPeriodPosi);

                //小数点以下部のみを取り出す
                strDeciArea = this.Text.Substring(intPeriodPosi + 1);
            }

            //カンマを許可する場合
            if (_blnCommaOK == true)
            {
                int intdata = 0;
                if (int.TryParse(strIntArea, out intdata))
                {
                    intdata = int.Parse(strIntArea);
                    strIntArea = string.Format("{0:#,##0}", intdata);
                }
            }

            //将来的にフォーマットで作成
            //数点以下入力の可不可と小数点以下桁数
            if (_intDeciSet > 0)
            {
                //小数点以下桁数分にデータが入らない場合は「0」で右埋め
                if (strDeciArea.Length < _intDeciSet)
                {
                    strDeciArea = strDeciArea.PadRight(_intDeciSet, '0');
                }

                //整数部と小数点以下部を書き込み
                this.Text = strIntArea + '.' + strDeciArea;
            }
            //小数点以下を許可しない場合
            else
            {
                //整数部のみを書き込み
                this.Text = strIntArea;
            }
        }
    }
}
