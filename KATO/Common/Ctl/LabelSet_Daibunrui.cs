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
    ///<summary>
    ///LabelSet_Chubunrui
    ///ラベルセット大分類
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class LabelSet_Daibunrui : BaseTextLabelSet
    {
        //他のformでも中分類setデータを見れるようにするためのもの
        LabelSet_Chubunrui lschubundata;

        /// <summary>
        /// Lschubundata
        /// プロパティの設定（データ確保）
        /// </summary>
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

        /// <summary>
        /// LsSubchubundata
        /// プロパティの設定（データ確保、補助）
        /// </summary>
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

        //他のformでもメーカーsetデータを見れるようにするためのもの
        LabelSet_Maker lsmakerdata;

        /// <summary>
        /// Lsmakerdata
        /// プロパティの設定（データ確保）
        /// </summary>
        public LabelSet_Maker Lsmakerdata
        {
            get
            {
                return this.lsmakerdata;
            }
            set
            {
                this.lsmakerdata = value;
            }
        }

        LabelSet_Maker lsSubmakerdata;

        /// <summary>
        /// LsSubmakerdata
        /// プロパティの設定（データ確保、補助）
        /// </summary>
        public LabelSet_Maker LsSubmakerdata
        {
            get
            {
                return this.lsSubmakerdata;
            }
            set
            {
                this.lsSubmakerdata = value;
            }
        }

        /// <summary>
        /// LabelSet_Daibunrui
        /// 読み込み時
        /// </summary>
        public LabelSet_Daibunrui()
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
        ///judDaibunruiKeyDown
        ///コード入力項目でのキー入力判定（大分類）
        ///</summary>
        private void judDaibunruiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (this.Parent is GroupBox)
                {
                    DaibunruiList daibunruiList = new DaibunruiList(this.Parent.Parent, this);
                    daibunruiList.Show();
                }
                else
                {
                    DaibunruiList daibunruiList = new DaibunruiList(this.Parent, this);
                    daibunruiList.Show();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }

        }

        ///<summary>
        ///updTxtDaibunruiLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        public void updTxtDaibunruiLeave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            Boolean blnGood;

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
            
            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_Daibun_SELECT_LEAVE");

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                if (strSQLInput == "")
                {
                    return;
                }

                strSQLInput = string.Format(strSQLInput, this.CodeTxtText);

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count != 0)
                {
                    this.CodeTxtText = dtSetCd.Rows[0]["大分類コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["大分類名"].ToString();
                }
                else
                {
                    this.ValueLabelText = "";
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    this.Focus();
                }

                //中分類のプロパティが空でない場合
                if (lschubundata != null)
                {
                    lschubundata.strDaibunCd = dtSetCd.Rows[0]["大分類コード"].ToString();
                }
                if (lsSubchubundata != null)
                {
                    lsSubchubundata.strDaibunCd = dtSetCd.Rows[0]["大分類コード"].ToString();
                }

                //メーカーのプロパティが空でない場合
                if (lsmakerdata != null)
                {
                    lsmakerdata.strDaibunCd = dtSetCd.Rows[0]["大分類コード"].ToString();
                }
                if (lsSubmakerdata != null)
                {
                    lsSubmakerdata.strDaibunCd = dtSetCd.Rows[0]["大分類コード"].ToString();
                }

                return;
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtDaibunruiKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
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

            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true))
            {
                this.ValueLabelText = "";
                return;
            }
            
            strSQLName = "C_LIST_Daibun_SELECT_LEAVE";

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
                    this.CodeTxtText = dtSetCd.Rows[0]["大分類コード"].ToString();
                    this.ValueLabelText = dtSetCd.Rows[0]["大分類名"].ToString();
                }

                //中分類のプロパティが空でない場合
                if (lschubundata != null)
                {
                    lschubundata.strDaibunCd = dtSetCd.Rows[0]["大分類コード"].ToString();
                }
                if (lsSubchubundata != null)
                {
                    lsSubchubundata.strDaibunCd = dtSetCd.Rows[0]["大分類コード"].ToString();
                }

                //メーカーのプロパティが空でない場合
                if (lsmakerdata != null)
                {
                    lsmakerdata.strDaibunCd = dtSetCd.Rows[0]["大分類コード"].ToString();
                }
                if (lsSubmakerdata != null)
                {
                    lsSubmakerdata.strDaibunCd = dtSetCd.Rows[0]["大分類コード"].ToString();
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
