﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Common.Util;

namespace KATO.Common.Ctl
{
    ///<summary>
    ///LabelSet_Tokuisaki
    ///ラベルセット得意先（取引先）
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class LabelSet_Tokuisaki : BaseTextLabelSet
    {
        /// <summary>
        /// LabelSet_Daibunrui
        /// 読み込み時
        /// </summary>
        public LabelSet_Tokuisaki()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OnPaint
        /// control.paintのイベント発生
        /// </summary>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        ///<summary>
        ///judTokuisakiKeyDown
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void judTokuisakiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                TokuisakiList tokuisakiList = new TokuisakiList(this.Parent, this);
                tokuisakiList.StartPosition = FormStartPosition.Manual;
                tokuisakiList.intFrmKind = CommonTeisu.FRM_TOKUISAKI;
                tokuisakiList.ShowDialog();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.F12)
            {
                //閉じる
                this.Parent.Dispose();
            }
        }

        ///<summary>
        ///updTxtTokuisakiLeave
        ///code入力箇所からフォーカスが外れた時(テキスト処理)
        ///</summary>
        public void updTxtTokuisakiLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            string strSQLName = null;

            Boolean blnGood;

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
                this.AppendLabelText = "";
                return;
            }

            //禁止文字チェック
            blnGood = StringUtl.JudBanChr(this.CodeTxtText);
            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(this.CodeTxtText, CommonTeisu.NUMBER_ONLY);

            if (blnGood == false)
            {
                this.ValueLabelText = "";
                //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                this.Focus();
                return;
            }

            //前後の空白を取り除く
            this.CodeTxtText = this.CodeTxtText.Trim();

            strSQLName = "C_LIST_Torihikisaki_SELECT_LEAVE";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                if (strSQLInput == "")
                {
                    return;
                }

                //配列設定
                string[] aryStr = { this.CodeTxtText };

                strSQLInput = string.Format(strSQLInput, aryStr);

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count != 0)
                {
                    string strZeikubun = "";

                    if (dtSetCd.Rows[0]["消費税計算区分"].ToString() == "0" || dtSetCd.Rows[0]["消費税計算区分"].ToString() == "2")
                    {
                        strZeikubun = "外税";
                    }
                    else if (dtSetCd.Rows[0]["消費税計算区分"].ToString() == "1")
                    {
                        strZeikubun = "内税";
                    }

                    this.CodeTxtText = dtSetCd.Rows[0]["取引先コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["取引先名称"].ToString();
                    this.AppendLabelText = strZeikubun;
                }
                else
                {
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    this.codeTxt.Focus();
                }
                return;
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///judTokuisakiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judTokuisakiKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ とタブ、エンター
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                return;
            }

            //数字入力以外は返す
            if ((Keys.D0 <= e.KeyCode && e.KeyCode <= Keys.D9) || (Keys.NumPad0 <= e.KeyCode && e.KeyCode <= Keys.NumPad9))
            {
            }
            else
            {
                return;
            }

            if (this.codeTxt.TextLength == 4)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }
    }
}