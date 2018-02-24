using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KATO.Common.Util.StringUtl;

namespace KATO.Common.Ctl
{
    public partial class BaseTextMoney : TextBox
    {
        //最初のクリックかの判断
        Boolean blnFirstClick = true;

        //記入の可不可
        Boolean blnEntry = true;

        //テキストボックス内データの「.」の位置
        int intPeriodPosi = 0;

        //小数点以下の桁数
        int _intDeciSet = 0;

        //整数の桁数
        int _intIntegerSet = 0;

        //変動があった時のデータの確保
        public string strDataSub = null;

        //カンマ入力の可不可(他で決定）
        Boolean _blnCommaOK = true;

        // マイナス入力の可不可
        Boolean _blnMinusFlg = true;

        // 入力した値にマイナスが存在するかのフラグ（存在した場合：true 存在しない場合：false）
        bool blInputMinus = false;

        //小数点以下の０パディング
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

        //整数の０パディング
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

        //カンマを許可するか否か
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

        /// <summary>
        ///     マイナス入力を許可するか（許可：true　禁止：false）
        /// </summary>
        public Boolean MinusFlg
        {
            get
            {
                return this._blnMinusFlg;
            }
            set
            {
                this._blnMinusFlg = value;
            }
        }

        int intshishagonyu;
        //四捨五入をするか否か（0が否、１以上が小数点第何位か）
        //（アクセス識別子) (型) (プロパティ名)
        public int intShishagonyu
        {
            get
            {
                //プロパティデータにデータを入れる場合
                return this.intshishagonyu;
            }
            set
            {
                //プロパティデータからデータを取り出す場合
                this.intshishagonyu = value;
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
            // 削除する文字
            char[] removeChars = new char[] { '-' };

            //背景色をシアンにする
            this.BackColor = Color.Cyan;

            // テキストボックスの値を取得
            string strTextBoxValue = this.Text;

            // "-"があった場合
            if (strTextBoxValue.IndexOf('-') > -1)
            {
                // blInputMinusをtrueにする
                blInputMinus = true;
            }
            else
            {
                blInputMinus = false;
            }
            // "-" を取り除く
            foreach (char c in removeChars)
            {
                strTextBoxValue = strTextBoxValue.Replace(c.ToString(), "");
            }

            //this.SelectAll();
            if (blnFirstClick == true && strTextBoxValue != "")
            {
                //全選択
                this.SelectAll();

                //クリックによる全選択を有効にする
                this.BeginInvoke(new MethodInvoker(() => this.SelectAll()));

                //二回目以降のクリックに切り替える
                blnFirstClick = false;
            }

            if (strTextBoxValue == "")
            {
                // "-" を取り除いた値が空の場合、テキストボックスに"0"を入れる
                if (blInputMinus == true)
                {
                    this.Text = "0";
                }
                return;
            }

            // 数字チェック
            strTextBoxValue = chkNumber(strTextBoxValue);

            // 入力された値にマイナスが付いていた場合
            if (blInputMinus == true)
            {
                // 値が"0"の場合、マイナスは付けない
                if (strTextBoxValue.Equals("0"))
                {
                    //四捨五入
                    strTextBoxValue = updShishagonyu(strTextBoxValue, intDeciSet);
                }
                else
                {
                    //四捨五入
                    strTextBoxValue = "-" + updShishagonyu(strTextBoxValue, intDeciSet);
                }
            }
            else
            {
                //四捨五入
                strTextBoxValue = updShishagonyu(strTextBoxValue, intDeciSet);
            }

            //カンマ付け、小数点以下付けに移動
            updPriceMethod();

        }

        //
        //別の場所にフォーカスされた時
        //
        private void updMoneyLeave(object sender, EventArgs e)
        {
            // 削除する文字
            char[] removeChars = new char[] { '-' };

            //背景色を白にする
            this.BackColor = Color.White;

            //フォーカスが外れたのでリセット
            blnFirstClick = true;

            // テキストボックスの値を取得
            string strTextBoxValue = this.Text;

            // "-"があった場合
            if (strTextBoxValue.IndexOf('-') > -1)
            {
                // blInputMinusをtrueにする
                blInputMinus = true;
            }
            else
            {
                blInputMinus = false;
            }
            // "-" を取り除く
            foreach (char c in removeChars)
            {
                strTextBoxValue = strTextBoxValue.Replace(c.ToString(), "");
            }

            if (strTextBoxValue == "")
            {
                // "-" を取り除いた値が空の場合、テキストボックスに"0"を入れる
                if (blInputMinus == true)
                {
                    this.Text = "0";
                }
                return;
            }

            // 数字チェック（数字ではない場合、空が返ってくる）
            strTextBoxValue = chkNumber(strTextBoxValue);

            if (strTextBoxValue.Equals(""))
            {
                if (this.Parent is BaseForm)
                {
                    //データ存在なしメッセージ（OK）
                    BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this.Parent, "", "数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox_Nodata.ShowDialog();

                    this.Text = "";
                }
                else if (this.Parent.Parent is BaseForm)
                {
                    //データ存在なしメッセージ（OK）
                    BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this.Parent.Parent, "", "数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox_Nodata.ShowDialog();

                    this.Text = "";
                }

                // ラベルセットのカーソル色が残るのを防ぐ
                // todo:しかしShift + Tabで移動した場合は二重になるため対応策が必要（加藤Prj_問題点課題管理表 No29）
                SendKeys.Send("+{TAB}");

                return;
            }

            // 入力された値にマイナスが付いていた場合
            if (blInputMinus == true)
            {
                // 値が"0"の場合、マイナスは付けない
                if (strTextBoxValue.Equals("0"))
                {
                    //四捨五入
                    strTextBoxValue = updShishagonyu(strTextBoxValue, intDeciSet);
                }
                else
                {
                    //四捨五入
                    strTextBoxValue = "-" + updShishagonyu(strTextBoxValue, intDeciSet);
                }
            }
            else
            {
                //四捨五入
                strTextBoxValue = updShishagonyu(strTextBoxValue, intDeciSet);
            }

            this.Text = strTextBoxValue;

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

                // マイナス入力を許可している場合
                if (_blnMinusFlg == true)
                {
                    if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '-' 
                        && e.KeyChar != '\u0001' && e.KeyChar != '\u0003' && e.KeyChar != '\u0016' && e.KeyChar != '\u0018')
                    {
                        //押されたキーが 0～9でない場合は、イベントをキャンセルする
                        blnEntry = false;
                    }
                }
                else
                {
                    if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' 
                        && e.KeyChar != '\u0001' && e.KeyChar != '\u0003' && e.KeyChar != '\u0016' && e.KeyChar != '\u0018')
                    {
                        //押されたキーが 0～9でない場合は、イベントをキャンセルする
                        blnEntry = false;
                    }
                }            
            }
            //小数点以下を拒否
            else if (_intDeciSet == 0)
            {
                blnEntry = true;

                // マイナス入力を許可している場合
                if (_blnMinusFlg == true)
                {
                    if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '-')
                    {
                        //押されたキーが 0～9でない場合は、イベントをキャンセルする
                        blnEntry = false;
                    }
                }
                else
                {
                    if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
                    {
                        //押されたキーが 0～9でない場合は、イベントをキャンセルする
                        blnEntry = false;
                    }
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
            // 削除する文字
            char[] removeChars = new char[] { ',', '-' };

            //整数部
            string strIntArea = "";

            //小数点以下部
            string strDeciArea = "";

            //テキストボックス内が空の場合スルー
            if (this.Text == "")
            {
                return;
            }

            //テキストボックス内のデータを確保
            string strtextBox = this.Text;

            // "-"があった場合
            if (strtextBox.IndexOf('-') > -1)
            {
                // blInputMinusをtrueにする
                blInputMinus = true;
            }
            else
            {
                blInputMinus = false;
            }
            // "," と "-" を取り除く
            foreach (char c in removeChars)
            {
                strtextBox = strtextBox.Replace(c.ToString(), "");
            }
            // strtextBox.Replaceで文字列が空になってしまった場合
            if (strtextBox.Equals(""))
            {
                return;
            }

            // ピリオドの位置を取得
            intPeriodPosi = strtextBox.IndexOf('.');

            //ピリオドがない場合
            if (intPeriodPosi == -1)
            {
                strIntArea = strtextBox;
            }
            else
            {
                //整数部のみを取り出す
                strIntArea = strtextBox.Substring(0, intPeriodPosi);

                //小数点以下部のみを取り出す
                strDeciArea = strtextBox.Substring(intPeriodPosi + 1);
            }

            //カンマを許可する場合
            if (_blnCommaOK == true)
            {
                Int64 intdata = 0;
                if (Int64.TryParse(strIntArea, out intdata))
                {
                    intdata = Int64.Parse(strIntArea);
                    strIntArea = string.Format("{0:#,0}", intdata);
                }
            }

            //数点以下入力の可不可と小数点以下桁数
            if (_intDeciSet > 0)
            {
                //小数点以下桁数分にデータが入らない場合は「0」で右埋め
                if (strDeciArea.Length < _intDeciSet)
                {
                    strDeciArea = strDeciArea.PadRight(_intDeciSet, '0');
                }

                //整数部と小数点以下部を変数に入れる
                strtextBox = strIntArea + '.' + strDeciArea;
            }
            //小数点以下を許可しない場合
            else
            {
                //整数部のみを変数に入れる
                strtextBox = strIntArea;
            }

            // 入力値にマイナスが存在した場合、先頭に"-"を付ける
            if (blInputMinus == true)
            {
                strtextBox = "-" + strtextBox;
            }

            this.Text = strtextBox;
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
        //テキストの変更があったときに確保する
        //
        private void BaseTextMoney_TextChanged(object sender, EventArgs e)
        {
            strDataSub = this.Text;
        }

        //
        //四捨五入のみを行う処理
        //
        public void setMoneyData(string strMoneyInput, int intshishagonyu)
        {
            //string strMoneyOutPut = "";

            if (this.Text == "")
            {
                return;
            }

            // 数字チェック
            strMoneyInput = chkNumber(strMoneyInput);
            //四捨五入
            this.Text = updShishagonyu(strMoneyInput, intDeciSet);

            //カンマ付け、小数点以下付けに移動
            updPriceMethod();

            return;
        }

        /// <summary>
        /// textbox_KeyPress
        /// KeyPressイベントハンドラ
        /// </summary>
        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //EnterやEscapeキーでビープ音が鳴らないようにする
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }
        }

        // 数字チェック
        private string chkNumber(string target)
        {
            string strReturn = "";
            
            long outlong = 0;
            int outint = 0;
            decimal outdecimal = 0;

            bool canConvertLong = long.TryParse(target, out outlong);
            bool canConvertInt = int.TryParse(target, out outint);
            bool canConvertDecimal = decimal.TryParse(target, out outdecimal);

            if (canConvertLong == true)
            {
                strReturn = outlong.ToString();
            }
            else if (canConvertInt == true)
            {
                strReturn = outint.ToString();
            }
            else if (canConvertDecimal == true)
            {
                strReturn = outdecimal.ToString();
            }
            else
            {
                // すべてfalseなら"0"を返す
                strReturn = "";
            }
            return strReturn;
        }

        /// <summary>
        ///     途中入力の場合のチェックロジック
        /// </summary>
        /// <returns>
        ///    エラーの場合：true 正常な場合：false
        /// </returns>
        public bool chkMoneyText()
        {             
            // 削除する文字
            char[] removeChars = new char[] { '-' };

            // テキストボックスの値を取得
            string strTextBoxValue = this.Text;

            // "-"があった場合
            if (strTextBoxValue.IndexOf('-') > -1)
            {
                // blInputMinusをtrueにする
                blInputMinus = true;
            }
            else
            {
                blInputMinus = false;
            }
            // "-" を取り除く
            foreach (char c in removeChars)
            {
                strTextBoxValue = strTextBoxValue.Replace(c.ToString(), "");
            }

            if (strTextBoxValue == "")
            {
                // "-" を取り除いた値が空の場合、テキストボックスに"0"を入れる
                if (blInputMinus == true)
                {
                    this.Text = "0";
                    return false;
                }
                else
                {
                    return false;
                }
            }

            // 数字チェック（数字ではない場合、空が返ってくる）
            strTextBoxValue = chkNumber(strTextBoxValue);

            if (strTextBoxValue.Equals(""))
            {
                if (this.Parent is BaseForm)
                {
                    //データ存在なしメッセージ（OK）
                    BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this.Parent, "", "数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox_Nodata.ShowDialog();

                    this.Text = "";
                }
                else if (this.Parent.Parent is BaseForm)
                {
                    //データ存在なしメッセージ（OK）
                    BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this.Parent.Parent, "", "数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox_Nodata.ShowDialog();

                    this.Text = "";
                }

                return true;
            }

            // 入力された値にマイナスが付いていた場合
            if (blInputMinus == true)
            {
                // 値が"0"の場合、マイナスは付けない
                if (strTextBoxValue.Equals("0"))
                {
                    //四捨五入
                    strTextBoxValue = updShishagonyu(strTextBoxValue, intDeciSet);
                }
                else
                {
                    //四捨五入
                    strTextBoxValue = "-" + updShishagonyu(strTextBoxValue, intDeciSet);
                }
            }
            else
            {
                //四捨五入
                strTextBoxValue = updShishagonyu(strTextBoxValue, intDeciSet);
            }

            this.Text = strTextBoxValue;

            //カンマ付け、小数点以下付けに移動
            updPriceMethod();

            return false;
        }
    }
}
