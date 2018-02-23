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
            //背景色をシアンにする
            this.BackColor = Color.Cyan;

            //this.SelectAll();
            if (blnFirstClick == true && this.Text != "")
            {
                //全選択
                this.SelectAll();

                //クリックによる全選択を有効にする
                this.BeginInvoke(new MethodInvoker(() => this.SelectAll()));

                //二回目以降のクリックに切り替える
                blnFirstClick = false;
            }

            if (this.Text == "")
            {
                return;
            }
          
            //四捨五入
            this.Text = updShishagonyu(this.Text, intshishagonyu);

            //カンマ付け、小数点以下付けに移動
            updPriceMethod();

        }

        //
        //別の場所にフォーカスされた時
        //
        private void updMoneyLeave(object sender, EventArgs e)
        {
            //数値チェック用
            decimal decCheck = 0;

            //背景色を白にする
            this.BackColor = Color.White;

            //フォーカスが外れたのでリセット
            blnFirstClick = true;

            if (this.Text == "")
            {
                return;
            }

            //コピーペーストされた時のための数値チェック
            if (!decimal.TryParse(this.Text, out decCheck))
            {
                if (this.Parent is BaseForm)
                {
                    //データ存在なしメッセージ（OK）
                    BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this.Parent, "", "数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox_Nodata.ShowDialog();
                }
                else if (this.Parent.Parent is BaseForm)
                {
                    //データ存在なしメッセージ（OK）
                    BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this.Parent.Parent, "", "数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox_Nodata.ShowDialog();
                }

//ラベルセットのカーソル色が残るのを防ぐ
//しかしShift + Tabで移動した場合は二重になるため対応策が必要（加藤Prj_問題点課題管理表 No29）
                SendKeys.Send("+{TAB}");

                return;
            }

            //四捨五入
            this.Text = updShishagonyu(this.Text, intshishagonyu);

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

                if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '\u0001' 
                                                                                                  && e.KeyChar != '\u0003' 
                                                                                                  && e.KeyChar != '\u0016' 
                                                                                                  && e.KeyChar != '\u0018')
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
            //整数部
            string strIntArea = "";

            //小数点以下部
            string strDeciArea = "";

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
                Int64 intdata = 0;
                if (Int64.TryParse(strIntArea, out intdata))
                {
                    intdata = Int64.Parse(strIntArea);
                    strIntArea = string.Format("{0:#,0}", intdata);
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

            //四捨五入
            this.Text = updShishagonyu(strMoneyInput, intshishagonyu);

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
    }
}
