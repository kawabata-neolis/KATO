﻿using System;
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
    public partial class BaseCalendarYM : BaseText
    {
        //最初のクリックかの判断
        Boolean blnFirstClick = true;

        //記入の可不可
        Boolean blnEntry = true;

        string strY = DateTime.Today.Year.ToString();
        string strM = "01";

        public BaseCalendarYM()
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
        public void setUp(int intSelectMonth)
        {
            if (intSelectMonth == 0)
            {
                //初期値は本日の月
                this.Text = (DateTime.Today).ToString().Substring(0, 10);
            }
            else if (intSelectMonth == 1)
            {
                //その年の1月を取り出す
                DateTime datiFirstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

                //初期値はその年の1月
                this.Text = datiFirstDayOfMonth.ToString("yyyy/MM");
            }
            else if(intSelectMonth == 2)
            {
                //その年の末月を取り出す
                DateTime datiEndDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

                //初期値はその月の末日
                this.Text = datiEndDayOfMonth.ToString("yyyy/MM");
            }
            else if (intSelectMonth == 3)
            {
                //次の月にする
                //表示年の確保
                string strYear = DateTime.Today.Year.ToString();

                //表示月の確保
                string strMonth = DateTime.Today.Month.ToString();

                //本月が1月の場合
                if (DateTime.Today.Month == 12)
                {
                    //前の年に変更
                    strYear = (DateTime.Today.Year + 1).ToString();
                    //前の月に変更
                    strMonth = "0";
                }

                //その月の来月の1日を取り出す
                DateTime dateFirstDayOFNextMonth = new DateTime(int.Parse(strYear), int.Parse(strMonth) + 1, 01);

                //初期値は来月の1日
                this.Text = dateFirstDayOFNextMonth.ToString("yyyy/MM");
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
            if (blnFirstClick == true && this.Text != "")
            {
                //全選択
                this.SelectAll();

                //クリックによる全選択を有効にする
                this.BeginInvoke(new MethodInvoker(() => this.SelectAll()));

                //二回目以降のクリックに切り替える
                blnFirstClick = false;
            }
        }

        //
        //別の場所にフォーカス移動された時
        //
        public Boolean updCalendarLeave(string updCalendarLeave)
        {
            //日付チェック用
            DateTime dateCheck = new DateTime();

            bool modDay = true;

            strY = DateTime.Today.Year.ToString();
            strM = "01";

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
            blnFirstClick = true;

            //何も書かれていない場合戻る
            if (updCalendarLeave == "")
            {
                blnDateCheck = true;
                return(blnDateCheck);
            }

//            //コピーペーストされた時のための数値チェック
//            if (!DateTime.TryParse(this.Text, out dateCheck))
//            {
//                if (this.Parent is BaseForm)
//                {
//                    //データ存在なしメッセージ（OK）
//                    BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this.Parent, "", "数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
//                    basemessagebox_Nodata.ShowDialog();
//                }
//                else if (this.Parent.Parent is BaseForm)
//                {
//                    //データ存在なしメッセージ（OK）
//                    BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this.Parent.Parent, "", "数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
//                    basemessagebox_Nodata.ShowDialog();
//                }

//                blnDateCheck = true;

////ラベルセットのカーソル色が残るのを防ぐ
////しかしShift + Tabで移動した場合は二重になるため対応策が必要（加藤Prj_問題点課題管理表 No29）
//                SendKeys.Send("+{TAB}");

//                return (blnDateCheck);
//            }

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

            if (strInData.Count() == 2)
            {
                strY = strInData[0];
                modDay = false;

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
            }
            else if (strInData.Count() == 1)
            {
                if (strInData[0].Length > 4)
                {
                    // 年部分取得
                    strY = strInData[0].Substring(0, strInData[0].Length - 2);
                    modDay = false;

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
                    strM = strInData[0].Substring(strInData[0].Length - 2, 2);
                }
                else if (strInData[0].Length > 2)
                {
                    //月部のみを取り出す
                    strM = strInData[0].Substring(0, strInData[0].Length - 2);
                }
                else
                {
                    //月部のみを取り出す
                    strM = strInData[0].ToString();

                    if (strM.Length == 1)
                    {
                        strM = strM.PadLeft(2, '0');
                    }
                }
            }

            strDate = strY + "/" + strM;

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

            if (modDay && !string.IsNullOrWhiteSpace(this.Text))
            {
                this.Text = chkModDay(this.Text);
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

            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '/' && e.KeyChar != '.' && e.KeyChar != '\u0001'
                                                                                                                  && e.KeyChar != '\u0003'
                                                                                                                  && e.KeyChar != '\u0016'
                                                                                                                  && e.KeyChar != '\u0018')
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
        //別の場所にフォーカス移動された時(始まり)
        //
        private void BaseCalendar_Leave(object sender, EventArgs e)
        {
            Boolean blnDateJud;

            blnDateJud = this.updCalendarLeave(this.Text);

            if (blnDateJud == false)
            {
                Control c = this;

                c = Parent;

                while (true)
                {
                    //継承元がBaseFormかFormなら
                    if (c is BaseForm || c is System.Windows.Forms.Form)
                    {
                        break;
                    }
                    else if (this.Parent == null)
                    {
                        return;
                    }

                    c = c.Parent;
                }

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                BaseMessageBox basemessagebox = new BaseMessageBox(c, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                this.Focus();
                return;
            }
            else
            {
                return;
            }
        }
        ///<summary>
        /// chkDateYMDataFormat
        /// テキストボックス内の日付フォーマットをチェック及び再生成
        /// 引数：日付フォーマット再生成済み日付文字列　エラーの場合、空を返す。
        ///</summary>
        public string chkDateYMDataFormat(string strDateData)
        {
            bool modDay = true;

            strY = DateTime.Today.Year.ToString();
            strM = "01";

            Boolean blnDateCheck = false;

            //テキストデータの格納
            string strDate = "";

            //格納（エラー時に元に戻す用）
            string strDataPi = "";

            //文字チェック,チェック用のLISTを作成
            List<string> checklist = new List<string>();

            //データを入れる配列
            string[] strInData;

            //リストに追加
            checklist.Add(strDateData);

            //テキストボックス内のチェック
            foreach (string Listvalue in checklist)
            {
                //「,]があった場合一度取り除く
                if (strDateData.Contains('.'))
                {
                    strDataPi = strDateData;
                    strDateData = strDateData.Replace(".", "/");
                }
            }

            strInData = strDateData.Split('/');

            if (strInData.Count() == 2)
            {
                strY = strInData[0];
                modDay = false;

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
            }
            else if (strInData.Count() == 1)
            {
                if (strInData[0].Length > 4)
                {
                    //月部のみを取り出す
                    strY = strInData[0].Substring(0, strInData[0].Length - 2);
                    modDay = false;

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
                    strM = strInData[0].Substring(strInData[0].Length - 2, 2);
                }
                else if (strInData[0].Length > 2)
                {
                    //月部のみを取り出す
                    strM = strInData[0].Substring(0, strInData[0].Length - 2);
                }
                else
                {
                    //月部のみを取り出す
                    strM = strInData[0].ToString();

                    if (strM.Length == 1)
                    {
                        strM = strM.PadLeft(2, '0');
                    }
                }
            }

            strDate = strY + "/" + strM;

            blnDateCheck = StringUtl.JudCalenderCheck(strDate);

            if (blnDateCheck == true)
            {
                strDateData = strDate;
            }
            else
            {
                if (strDataPi != "")
                {
                    strDateData = strDataPi;
                }
                else
                {
                    strDateData = "";
                }
            }

            if (modDay && !string.IsNullOrWhiteSpace(strDateData))
            {
                strDateData = chkModDay(strDateData);
            }

            return (strDateData);
        }

        private string chkModDay(string s)
        {
            string ret = s;

            if (s.CompareTo(DateTime.Now.ToString("yyyy/MM")) < 0)
            {
                DateTime d = DateTime.ParseExact(s + "/01", "yyyy/MM/dd", null).AddYears(1);
                if (d.ToString("yyyy/MM/01").CompareTo(DateTime.Now.AddMonths(6).ToString("yyyy/MM/01")) > 0)
                {
                    d = d.AddYears(-1);
                }
                ret = d.ToString("yyyy/MM");
            }

            return ret;
        }
    }
}
