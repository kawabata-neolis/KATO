using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Common.Ctl;
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
    public partial class LabelSet_Maker : BaseTextLabelSet
    {
        public LabelSet_Maker()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        ///<summary>
        ///judMakerKeyDown
        ///コード入力項目でのキー入力判定（メーカー）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judMakerKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                MakerList makerList = new MakerList(this.Parent, this);
                makerList.Show();
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
        ///txtMakerLeave
        ///code入力箇所からフォーカスが外れた時(テキスト処理)
        ///作成者：大河内
        ///作成日：2017/4/25
        ///更新者：大河内
        ///更新日：2017/4/25
        ///カラム論理名
        ///</summary>
        public void txtMakerLeave(object sender, EventArgs e)
        {
            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
                return;
            }

            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetcode;


            //前後の空白を取り除く
            this.CodeTxtText = this.CodeTxtText.Trim();

            if (this.CodeTxtText.Length <= 2)
            {
                this.CodeTxtText = this.CodeTxtText.ToString().PadLeft(3, '0');
            }

            //データ渡し用
            lstString.Add(this.CodeTxtText);

            ////処理部に移動
            ////戻り値のDatatableを取り込む
            dtSetcode = judTxtMakerLeave(lstString);

            if (dtSetcode.Rows.Count != 0)
            {
                this.CodeTxtText = dtSetcode.Rows[0]["メーカーコード"].ToString();
                this.ValueLabelText = dtSetcode.Rows[0]["メーカー名"].ToString();
            }

        }


        ///<summary>
        ///judTxtMakerLeave
        ///code入力箇所からフォーカスが外れた時(SQL処理)
        ///作成者：大河内
        ///作成日：2017/3/21
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public DataTable judTxtMakerLeave(List<string> lstString)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLName = null;

            DataTable dtSetcode_B = new DataTable();

            strSQLName = "C_LIST_Maker_SELECT_LEAVE";

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

            return (dtSetcode_B);
        }


        ///judtxtMakerKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/4/25
        ///更新者：大河内
        ///更新日：2017/4/25
        ///カラム論理名
        ///</summary>
        private void judtxtMakerKeyUp(object sender, KeyEventArgs e)
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

            if (this.codeTxt.TextLength == 3)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }
    }
}
