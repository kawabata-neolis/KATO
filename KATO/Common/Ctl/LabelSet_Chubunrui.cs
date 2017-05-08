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
    public partial class LabelSet_Chubunrui : BaseTextLabelSet
    {

        //大分類コード確保用
        string strdaibunCD;
        public string strDaibunCD
        {
            get
            {
                return this.strdaibunCD;
            }
            set
            {
                this.strdaibunCD = value;
            }
        }

        public LabelSet_Chubunrui()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        ///<summary>
        ///judChubunruiKeyDown
        ///コード入力項目でのキー入力判定（中分類）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judChubunruiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (this.strdaibunCD == null)
                {
                    return;
                }
                ChubunruiList chubunruiList = new ChubunruiList(this.Parent, this, strdaibunCD);
                chubunruiList.Show();
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
        ///judTxtChubunruiLeave
        ///code入力箇所からフォーカスが外れた時
        ///作成者：大河内
        ///作成日：2017/3/21
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        private void txtChubunruiLeave(object sender, EventArgs e)
        {
            if (this.strdaibunCD == null)
            {
                return;
            }

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
                return;
            }

            if (this.CodeTxtText.Length == 1)
            {
                CodeTxtText = CodeTxtText.ToString().PadLeft(2, '0');
            }

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLName = null;

            DataTable dtSetcode_B = new DataTable();

            strSQLName = "C_LIST_Chubun_SELECT_LEAVE";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            if (strSQLInput == "")
            {
                return;
            }

            //配列設定
            string[] strArray = { this.strdaibunCD, this.CodeTxtText};

            strSQLInput = string.Format(strSQLInput, strArray);

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //SQL文を直書き（＋戻り値を受け取る)
            dtSetcode_B = dbconnective.ReadSql(strSQLInput);

            if(dtSetcode_B.Rows.Count == 0)
            {
                return;
            }

            this.CodeTxtText = dtSetcode_B.Rows[0]["中分類コード"].ToString();
            this.ValueLabelText = dtSetcode_B.Rows[0]["中分類名"].ToString();
            return;
        }

        ///judtxtChubunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/4/25
        ///更新者：大河内
        ///更新日：2017/4/25
        ///カラム論理名
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

            //数字入力以外は返す
            if ((Keys.D0 <= e.KeyCode && e.KeyCode <= Keys.D9) || (Keys.NumPad0 <= e.KeyCode && e.KeyCode <= Keys.NumPad9))
            {
            }
            else
            {
                return;
            }

            if (this.codeTxt.TextLength == 2)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }
    }
}
