using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Business.M1010_Daibunrui;
using KATO.Common.Form;
using KATO.Common.Util;

namespace KATO.Common.Ctl
{
    public partial class LabelSet_Daibunrui : BaseTextLabelSet
    {

        //他のformでも中分類setデータを見れるようにするためのもの
        LabelSet_Chubunrui lschubundata;
        public LabelSet_Chubunrui Lschubundata
        {
            get
            {
                return this.lschubundata;
            }
            set
            {
                this.lschubundata = value;
            }
        }

        LabelSet_Chubunrui lsSubchubundata;
        public LabelSet_Chubunrui LsSubchubundata
        {
            get
            {
                return this.lsSubchubundata;
            }
            set
            {
                this.lsSubchubundata = value;
            }
        }


        public LabelSet_Daibunrui()
        {

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }


        ///<summary>
        ///judDaibunruiKeyDown
        ///コード入力項目でのキー入力判定（大分類）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judDaibunruiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                DaibunruiList daibunruiList = new DaibunruiList(this.Parent, this);
                daibunruiList.Show();
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
        ///txtDaibunruiLeave
        ///code入力箇所からフォーカスが外れた時(テキスト処理)
        ///作成者：大河内
        ///作成日：2017/4/25
        ///更新者：大河内
        ///更新日：2017/4/25
        ///カラム論理名
        ///</summary>
        public void txtDaibunruiLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetcode;

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
                return;
            }

            if (this.CodeTxtText.Length == 1)
            {
                CodeTxtText = CodeTxtText.ToString().PadLeft(2, '0');
            }

            //前後の空白を取り除く
            this.CodeTxtText = this.CodeTxtText.Trim();

            //データ渡し用
            lstString.Add(this.CodeTxtText);

            //処理部に移動
            //戻り値のDatatableを取り込む
            dtSetcode = judTxtDaibunruiLeave(lstString);

            if (dtSetcode.Rows.Count != 0)
            {
                this.CodeTxtText = dtSetcode.Rows[0]["大分類コード"].ToString();
                this.ValueLabelText = dtSetcode.Rows[0]["大分類名"].ToString();
            }
        }

        ///<summary>
        ///judTxtDaibunruiLeave
        ///code入力箇所からフォーカスが外れた時(SQL処理)
        ///作成者：大河内
        ///作成日：2017/3/21
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public DataTable judTxtDaibunruiLeave(List<string> lstString)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLName = null;

            DataTable dtSetcode_B = new DataTable();

            strSQLName = "C_LIST_Daibun_SELECT_LEAVE";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            if (strSQLInput == "")
            {
                return (dtSetcode_B);
            }

            //配列設定
            string[] strArray = { lstString[0] };

            strSQLInput = string.Format(strSQLInput, strArray);

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //SQL文を直書き（＋戻り値を受け取る)
            dtSetcode_B = dbconnective.ReadSql(strSQLInput);

            //中分類のプロパティが空でない場合
            if (lschubundata != null )
            {
                lschubundata.strDaibunCD = dtSetcode_B.Rows[0]["大分類コード"].ToString();
            }
            if (lsSubchubundata != null)
            {
                lsSubchubundata.strDaibunCD = dtSetcode_B.Rows[0]["大分類コード"].ToString();
            }

            return (dtSetcode_B);
        }


        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/4/25
        ///更新者：大河内
        ///更新日：2017/4/25
        ///カラム論理名
        ///</summary>
        private void judtxtDaibunruiKeyUp(object sender, KeyEventArgs e)
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
