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

namespace KATO.Common.Ctl
{
    public partial class BaseCalendar : BaseText
    {
        //最初のクリックかの判断
        Boolean blnFirstclick = true;

        //記入の可不可
        Boolean blnEntry = true;

        string strY = DateTime.Today.Year.ToString();
        string strM = DateTime.Today.Month.ToString();
        string strD = DateTime.Today.Day.ToString();

        public BaseCalendar()
        {
            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        //
        //各フォームに合った初期値にする
        //
        public void setUp(int intSelectDay)
        {
            if (intSelectDay == 0)
            {
                //初期値は本日の日付
                this.Text = (DateTime.Today).ToString().Substring(0, 10);
            }
            else if (intSelectDay == 1)
            {
                //その月の1日を取り出す
                DateTime datiFirstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

                //初期値はその月の1日
                this.Text = datiFirstDayOfMonth.ToString("yyyy/MM/dd");
            }
            else if(intSelectDay == 2)
            {
                //その月の末日を取り出す
                DateTime datiEndDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));

                //初期値はその月の末日
                this.Text = datiEndDayOfMonth.ToString("yyyy/MM/dd");
            }
        }

        //
        //この場所にフォーカスされた時
        //
        private void updCalendarEnter(object sender, EventArgs e)
        {
            //背景色をシアンにする
            this.BackColor = Color.Cyan;

            //this.SelectAll();
            if (blnFirstclick == true && this.Text != "")
            {
                //全選択
                this.SelectAll();

                //クリックによる全選択を有効にする
                this.BeginInvoke(new MethodInvoker(() => this.SelectAll()));

                //二回目以降のクリックに切り替える
                blnFirstclick = false;
            }
        }

        //
        //別の場所にフォーカス移動された時
        //
        public Boolean updCalendarLeave(string updCalendarLeave)
        {
            strY = DateTime.Today.Year.ToString();
            strM = DateTime.Today.Month.ToString();
            strD = DateTime.Today.Day.ToString();

            Boolean blnDateCheck = false;

            //テキストデータの格納
            string strDate = "";

            //格納（エラー時に元に戻す用）
            string strDataPi = "";

            //文字チェック,チェック用のLISTを作成
            List<string> checklist = new List<string>();

            //データを入れる配列
            string[] strInData;

            //背景色を白にする
            this.BackColor = Color.White;

            //フォーカスが外れたのでリセット
            blnFirstclick = true;

            //何も書かれていない場合戻る
            if (updCalendarLeave == "")
            {
                blnDateCheck = true;
                return(blnDateCheck);
            }

            //リストに追加
            checklist.Add(this.Text);

            //テキストボックス内のチェック
            foreach (string Listvalue in checklist)
            {
                //「,]があった場合一度取り除く
                if (this.Text.Contains('.'))
                {
                    strDataPi = this.Text;
                    this.Text = this.Text.Replace(".", "/");
                }
            }

            strInData = this.Text.Split('/');

            if (strInData.Count() == 3)
            {
                strY = strInData[0];

                //20~と付けるか否か
                if (strY.Length == 3)
                {
                    strY = 2 + strY;
                }
                else if (strY.Length == 2)
                {
                    int intY = int.Parse(strY);

                    if (intY < 50)
                    {
                        strY = 20 + strY;
                    }
                    else
                    {
                        strY = 19 + strY;
                    }
                }
                else if (strY.Length == 1)
                {
                    strY = 200 + strY;
                }

                strM = strInData[1];

                if (strM.Length == 1)
                {
                    strM = strM.PadLeft(2, '0');
                }

                strD = strInData[2];

                if (strD.Length == 1)
                {
                    strD = strD.PadLeft(2, '0');
                }

            }
            else if (strInData.Count() == 2)
            {
                strM = strInData[0];

                if (strM.Length == 1)
                {
                    strM = strM.PadLeft(2, '0');
                }

                strD = strInData[1];

                if (strD.Length == 1)
                {
                    strD = strD.PadLeft(2, '0');
                }
            }
            else if (strInData.Count() == 1)
            {
                if (strInData[0].Length > 4)
                {
                    //月部のみを取り出す
                    strY = strInData[0].Substring(0, strInData[0].Length - 4);

                    //20~と付けるか否か
                    if (strY.Length == 3)
                    {
                        strY = 2 + strY;
                    }
                    else if (strY.Length == 2)
                    {
                        int intY = int.Parse(strY);

                        if (intY < 50)
                        {
                            strY = 20 + strY;
                        }
                        else
                        {
                            strY = 19 + strY;
                        }
                    }
                    else if (strY.Length == 1)
                    {
                        strY = 200 + strY;
                    }

                    //月部のみを取り出す
                    strM = strInData[0].Substring(strInData[0].Length - 4, 2);

                    //日部のみを取り出す
                    strD = strInData[0].Substring(strInData[0].Length - 2, 2);

                }
                else if (strInData[0].Length > 2)
                {
                    //月部のみを取り出す
                    strM = strInData[0].Substring(0, strInData[0].Length -2);

                    //日部のみを取り出す
                    strD = strInData[0].Substring(strInData[0].Length -2, 2);
                }
                else
                {
                    //日部のみを取り出す
                    strD = strInData[0].PadLeft(2, '0');
                }
            }

            strDate = strY + "/" + strM + "/" + strD;

            blnDateCheck = StringUtl.JudCalenderCheck(strDate);

            if (blnDateCheck == true)
            {
                this.Text = strDate;
            }
            else
            {
                if (strDataPi != "")
                {
                    this.Text = strDataPi;
                }
            }
            return (blnDateCheck);
        }

        //
        //キー入力された場合
        //
        private void setCalendarKeyDown(object sender, KeyEventArgs e)
        {
            //flg情報初期化
            blnEntry = true;

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
                    break;

                default:
                    break;
            }
        }

        //
        //textboxに入力された場合
        //
        private void setCalendarKeyPress(object sender, KeyPressEventArgs e)
        {
            blnEntry = true;

            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '/' && e.KeyChar != '.')
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
        //文字判定
        //
        public bool blIsEmpty()
        {
            Boolean good = true;

            if (String.IsNullOrWhiteSpace(this.Text).Equals(true))
            {
                MessageBox.Show("項目が空です。項目を入力してください", "入力項目");
                good = false;
            }
            return (good);
        }
    }
}
