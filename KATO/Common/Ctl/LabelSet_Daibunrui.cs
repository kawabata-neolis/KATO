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

        //エラーメッセージを表示したかどうか
        public bool blMessageOn = false;

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
                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    DaibunruiList daibunruiList = new DaibunruiList(this.Parent.Parent, this);
                    daibunruiList.ShowDialog();
                }
                //親画面がBaseFormの場合
                else if (this.Parent is BaseForm)
                {
                    DaibunruiList daibunruiList = new DaibunruiList(this.Parent, this);
                    daibunruiList.ShowDialog();
                }
                //親画面がLIST画面の場合
                else
                {
                    //他と判別させるために空のオブジェクトを作成する
                    object obj = new object();

                    DaibunruiList daibunruiList = new DaibunruiList(this.Parent, this, obj);
                    daibunruiList.ShowDialog();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                //TABボタンと同じ効果
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;
            }
        }

        ///<summary>
        ///updTxtDaibunruiLeave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void updTxtDaibunruiLeave(object sender, EventArgs e)
        {
            setTxtDaibunruiLeave();
        }

        ///<summary>
        ///updTxtDaibunruiLeave
        ///code入力箇所からフォーカスが外れた時の処理
        ///</summary>
        public void setTxtDaibunruiLeave()
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            Boolean blnGood;

            //情報を投げる必須項目になるため空の情報を作成
            object sender = null;
            EventArgs e = null;

            //空白、文字数3以上の場合
            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true) || this.CodeTxtText.Length > 2)
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
                //Parent 内のすべてのコントロールを列挙する
                foreach (Control cControl in Parent.Controls)
                {
                    //列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                    if (cControl is BaseButton)
                    {
                        if (cControl.Text == "F12:戻る")
                        {
                            //フォーカスがボタンを指している場合
                            Control ctrlParent = ParentForm.ActiveControl;

                            if (ctrlParent.Name == "btnF12")
                            {
                                //全てのフォームの中から
                                foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                                {
                                    //商品のフォームを探す
                                    if (frm.Name == Parent.Name)
                                    {
                                        //中分類リストの場合
                                        if (frm.Name == "ChubunruiList")
                                        {
                                            //データを連れてくるため、newをしないこと
                                            ChubunruiList chubunlist = (ChubunruiList)frm;
                                            chubunlist.btnEndClick(sender, e);
                                            return;
                                        }
                                        //メーカーリストの場合
                                        else if (frm.Name == "MakerList")
                                        {
                                            //データを連れてくるため、newをしないこと
                                            MakerList makerlist = (MakerList)frm;
                                            makerlist.btnEndClick(sender, e);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                this.ValueLabelText = "";

                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(Parent.Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
                else
                {
                    //メッセージボックスの処理、項目が該当する禁止文字を含む場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(Parent, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }

                //エラーメッセージを表示された
                blMessageOn = true;
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

                    blMessageOn = false;
                }
                else
                {
                    this.ValueLabelText = "";

                    //グループボックスかパネル内にいる場合
                    if (this.Parent is GroupBox || this.Parent is Panel)
                    {
                        //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                    }
                    else
                    {
                        //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                    }
                    blMessageOn = true;
                    return;
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
                //データロギング
                new CommonException(ex);

                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    this.Focus();
                    return;
                }
            }
        }

        ///<summary>
        ///setData
        ///code入力箇所からフォーカスが外れた時の処理
        ///</summary>
        private void setData(object sender, EventArgs e)
        {

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
        ///codeTxt_ReadOnlyChanged
        ///ReadOnlyになった場合と解除
        ///</summary>
        private void codeTxt_ReadOnlyChanged(object sender, EventArgs e)
        {
            //ReadOnlyになった場合
            if (this.codeTxt.ReadOnly == true)
            {
                this.codeTxt.BackColor = Color.Gray;
            }
        }

        ///<summary>
        ///LabelSet_Daibunrui_EnabledChanged
        ///Enabledが変更になった場合と解除
        ///</summary>
        private void LabelSet_Daibunrui_EnabledChanged(object sender, EventArgs e)
        {
            //EnabledがFalseになった場合
            if (this.Enabled == false)
            {
                this.codeTxt.BackColor = SystemColors.Control;
            }
            else
            {
                this.codeTxt.BackColor = Color.White;
            }
        }
    }
}
