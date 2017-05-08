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

namespace KATO.Common.Ctl
{
    public partial class LabelSet_Tantousha : BaseTextLabelSet
    {

        public LabelSet_Tantousha()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        ///<summary>
        ///judTokuisakiKeyDown
        ///コード入力項目でのキー入力判定（大分類）
        ///</summary>
        private void judTantoushaKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                TantoushaList tantoushaList = new TantoushaList(this.Parent, this);
                tantoushaList.StartPosition = FormStartPosition.Manual;
                tantoushaList.intFrmKind = CommonTeisu.FRM_TANTOUSYA;
                tantoushaList.ShowDialog();

            }
            else if(e.KeyCode == Keys.Enter)
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
        ///txtTokuisakiLeave
        ///code入力箇所からフォーカスが外れた時(テキスト処理)
        ///</summary>
        public void txtTokuisakiLeave(object sender, EventArgs e)
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

            if (this.CodeTxtText.Length <= 3)
            {
                this.CodeTxtText = this.CodeTxtText.ToString().PadLeft(4, '0');
            }

            //データ渡し用
            lstString.Add(this.CodeTxtText);

            //処理部に移動
            //戻り値のDatatableを取り込む
            dtSetcode = judTxtTantoushaLeave(lstString);

            if (dtSetcode.Rows.Count != 0)
            {
                this.CodeTxtText = dtSetcode.Rows[0]["担当者コード"].ToString();
                this.ValueLabelText = dtSetcode.Rows[0]["担当者名"].ToString();
            }
            else
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                this.codeTxt.Focus();
            }
        }

        ///<summary>
        ///judTxtDaibunruiLeave
        ///code入力箇所からフォーカスが外れた時(SQL処理)
        ///</summary>
        public DataTable judTxtTantoushaLeave(List<string> lstString)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLName = null;

            DataTable dtSetcode_B = new DataTable();

            strSQLName = "C_LIST_Tantousha_SELECT_LEAVE";

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

        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        private void judtxtTantoushaKeyUp(object sender, KeyEventArgs e)
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

            if (this.codeTxt.TextLength == 4)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
        }
    }
}
