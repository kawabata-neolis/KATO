using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Common.Util;

namespace KATO.Common.Ctl
{
    ///<summary>
    ///LabelSet_Menu
    ///ラベルセット取引先
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class LabelSet_Menu : BaseTextLabelSet
    {
        //エラーメッセージを表示したかどうか
        public bool blMessageOn = false;

        ///<summary>
        ///LabelSet_Menu
        ///読み込み時
        ///</summary>
        public LabelSet_Menu()
        {
            InitializeComponent();
        }

        ///<summary>
        ///OnPaint
        ///control.paintのイベント発生
        ///</summary>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        ///<summary>
        ///codeTxt_KeyDown
        ///コード入力項目でのキー入力判定
        ///</summary>
        private void codeTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel)
                {
                    MenuList menulist = new MenuList(this.Parent.Parent.Parent, this);
                    menulist.StartPosition = FormStartPosition.Manual;
                    menulist.intFrmKind = CommonTeisu.FRM_MENU;
                    menulist.ShowDialog();
                }
                //親画面がBaseFormの場合
                else if (this.Parent is BaseForm)
                {
                    //MenuList menulist = new MenuList(this.Parent, this);
                    //menulist.StartPosition = FormStartPosition.Manual;
                    //menulist.intFrmKind = CommonTeisu.FRM_MENU;
                    //menulist.ShowDialog();
                }
                //親画面がLIST画面の場合
                else
                {
                    ////他と判別させるために空のオブジェクトを作成する
                    //object obj = new object();

                    //TorihikisakiList torihikisakiList = new TorihikisakiList(this.Parent, this, obj);
                    //torihikisakiList.StartPosition = FormStartPosition.Manual;
                    //torihikisakiList.intFrmKind = CommonTeisu.FRM_TOKUISAKI;
                    //torihikisakiList.ShowDialog();
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
        ///codeTxt_KeyPress
        ///コード入力項目でのキー入力判定（数値判定）
        ///</summary>
        private void codeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                return;
            }

            //0から9以外の場合
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }
        
        ///<summary>
        ///codeTxt_Leave
        ///code入力箇所からフォーカスが外れた時
        ///</summary>
        private void codeTxt_Leave(object sender, EventArgs e)
        {
            setData();
        }

        ///<summary>
        ///setData
        ///code入力箇所からフォーカスが外れた時の処理
        ///</summary>
        private void setData()
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            DataTable dtSetCd;

            Boolean blnGood;

            //空白、文字数4以上の場合
            if (this.CodeTxtText == "" || String.IsNullOrWhiteSpace(this.CodeTxtText).Equals(true) || this.CodeTxtText.Length > 3)
            {
                this.ValueLabelText = "";
                this.AppendLabelText = "";
                return;
            }

            //前後の空白を取り除く
            this.CodeTxtText = this.CodeTxtText.Trim();

            //禁止文字チェック
            if (StringUtl.JudBanSQL(this.CodeTxtText) == false ||
                StringUtl.JudBanSelect(this.CodeTxtText, CommonTeisu.NUMBER_ONLY) == false)
            {
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

                CodeTxtText = "0";
                return;
            }

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_Menu_SELECT_LEAVE");

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

                //データがある場合
                if (dtSetCd.Rows.Count != 0)
                {
                    //ＰＧ番号が0の場合
                    if (dtSetCd.Rows[0]["ＰＧ番号"].ToString() == "0")
                    {
                        this.CodeTxtText = "0";
                        this.ValueLabelText = "";
                    }
                    else
                    {
                        this.CodeTxtText = dtSetCd.Rows[0]["ＰＧ番号"].ToString();
                        this.ValueLabelText = dtSetCd.Rows[0]["ＰＧ名"].ToString();
                    }
                    blMessageOn = false;
                }
                else
                {
                    //初期化
                    this.CodeTxtText = "0";
                    this.ValueLabelText = "0";

                    //グループボックスかパネル内にいる場合
                    if (this.Parent is TabPage)
                    {
                        //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent.Parent.Parent, "入力", "指定されたPgNo.は登録されていません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                    }
                    else if (this.Parent is GroupBox || this.Parent is Panel)
                    {
                        //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent.Parent, "入力", "指定されたPgNo.は登録されていません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                    }
                    else
                    {
                        //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, "入力", "指定されたPgNo.は登録されていません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                    }

                    //エラーメッセージを表示された
                    blMessageOn = true;
                }
                return;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックスかパネル内にいる場合
                if (this.Parent is GroupBox || this.Parent is Panel || this.Parent is TabPage)
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
                    return;
                }
            }
        }

        ///codeTxt_KeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void codeTxt_KeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///LabelSet_Torihikisaki_EnabledChanged
        ///Enabledが変更になった場合と解除
        ///</summary>
        private void LabelSet_Torihikisaki_EnabledChanged(object sender, EventArgs e)
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

        ///<summary>
        ///codeTxt_TextChanged
        ///入力項目に変更があった場合
        ///</summary>
        private void codeTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
