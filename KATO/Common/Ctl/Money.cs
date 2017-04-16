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
    public partial class Money : BaseText
    {
        //カンマ入力の可不可(他で決定させる）
        Boolean blnCommaOK = true;

        //小数点以下入力の可不可と小数点以下桁数(他で決定）
        int intPeriodcnt = 0;

        //小数点以下表示の可、入力不可の場合(他で決定）
        Boolean blnEnablePeriodEnter = false;

        //記入の可不可
        Boolean blnEntry = true;

        //整数部
        string strIntArea;

        //小数点以下部
        string strDeciArea;

        //テキストボックス内データの「.」の位置
        int intPeriodposi;

        public Money()
        {
            InitializeComponent();

            //textbox内容の入力数制限
            this.MaxLength = 9;

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
        public void updMoneyEnter(object sender, EventArgs e)
        {
            //カンマ付け、小数点以下付けに移動
            updPriceMethod();

        }

        //
        //別の場所にフォーカスされた時
        //
        public void updMoneyLeave(object sender, EventArgs e)
        {
            //カンマ付け、小数点以下付けに移動
            updPriceMethod();
        }

        //
        //textboxに入力された場合
        //
        public void updMoneyKeyPress(object sender, KeyPressEventArgs e)
        {
            blnEntry = true;

            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ',')
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                blnEntry = false;
            }
            //小数点以下の記載を認めない
            else if (blnEnablePeriodEnter == true && e.KeyChar != '.')
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

            //整数部と小数点以下部を分ける

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
            intPeriodposi = this.Text.IndexOf('.');

            //ピリオドがない場合
            if (intPeriodposi == -1)
            {
                strIntArea = this.Text;
            }
            else
            {
                //整数部のみを取り出す
                strIntArea = this.Text.Substring(0, intPeriodposi);

                //小数点以下部のみを取り出す
                strDeciArea = this.Text.Substring(intPeriodposi + 1);
            }

            //カンマを許可する場合
            if (blnCommaOK == true)
            {
                //カンマ書き込み用をint型を作成
                int intIntArea = int.Parse(strIntArea);

                //カンマ付けで書き込み
                strIntArea = string.Format("{0:#,0}", intIntArea);
            }

            //数点以下入力の可不可と小数点以下桁数
            if (intPeriodcnt > 0)
            {
                //小数点以下桁数分にデータが入らない場合は「0」で右埋め
                if (strDeciArea.Length < intPeriodcnt)
                {
                    strDeciArea = strDeciArea.PadRight(intPeriodcnt, '0');
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
