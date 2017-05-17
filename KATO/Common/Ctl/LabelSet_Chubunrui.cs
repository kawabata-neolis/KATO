using System;
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
using KATO.Form.F0140_TanaorosiInput;

namespace KATO.Common.Ctl
{
    ///<summary>
    ///LabelSet_Chubunrui
    ///ラベルセット中分類
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class LabelSet_Chubunrui : BaseTextLabelSet
    {
        //大分類コード確保用
        string strdaibunCd;

        /// <summary>
        /// strDaibunCd
        /// プロパティの設定（大分類コード）
        /// </summary>
        public string strDaibunCd
        {
            get
            {
                return this.strdaibunCd;
            }
            set
            {
                this.strdaibunCd = value;
            }
        }

        /// <summary>
        /// LabelSet_Chubunrui
        /// 読み込み時
        /// </summary>
        public LabelSet_Chubunrui()
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
        ///judChubunruiKeyDown
        ///コード入力項目でのキー入力判定（中分類）
        ///</summary>
        private void judChubunruiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (this.strdaibunCd == null)
                {
                    return;
                }
                ChubunruiList chubunruiList = new ChubunruiList(this.Parent, this, strdaibunCd);
                chubunruiList.Show();
            }
        }
        
        ///<summary>
        ///updTxtChubunruiLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void updTxtChubunruiLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            string strSQLName = null;

            Boolean blnGood;

            if (this.strdaibunCd == null)
            {
                return;
            }

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
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
            
            if (this.CodeTxtText.Length == 1)
            {
                CodeTxtText = CodeTxtText.ToString().PadLeft(2, '0');
            }

            //前後の空白を取り除く
            this.CodeTxtText = this.CodeTxtText.Trim();

            strSQLName = "C_LIST_Chubun_SELECT_LEAVE";

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
                string[] aryStr = { this.strdaibunCd, this.CodeTxtText };

                strSQLInput = string.Format(strSQLInput, aryStr);

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count != 0)
                {
                    this.CodeTxtText = dtSetCd.Rows[0]["中分類コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["中分類名"].ToString();
                }
                else
                {
                    this.ValueLabelText = "";
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    this.Focus();
                }
                return;
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///judtxtChubunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtChubunruiKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                return;
            }
            //キーボードの方向キー4つ
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            {
                return;
            }


            //数字入力以外は返す
            if ((Keys.D0 <= e.KeyCode && e.KeyCode <= Keys.D9) || (Keys.NumPad0 <= e.KeyCode && e.KeyCode <= Keys.NumPad9))
            {
            }
            else
            {
                e.Handled = true;
                return;
            }

            if (this.codeTxt.TextLength == 2)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }

        ///<summary>
        ///codeTxt_TextChanged
        ///入力項目に変更があった場合
        ///</summary>
        private void codeTxt_TextChanged(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            string strSQLName = null;

            if (this.strdaibunCd == null)
            {
                return;
            }

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
                return;
            }

            strSQLName = "C_LIST_Chubun_SELECT_LEAVE";

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
                string[] aryStr = { this.strdaibunCd, this.CodeTxtText };

                strSQLInput = string.Format(strSQLInput, aryStr);

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                //データの有無チェック
                if (dtSetCd.Rows.Count != 0)
                {
                    this.CodeTxtText = dtSetCd.Rows[0]["中分類コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["中分類名"].ToString();
                }
                return;
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }
    }
}
