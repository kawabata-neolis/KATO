using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.A0020_UriageInput;
using KATO.Form.D0360_JuchuzanKakunin;

namespace KATO.Common.Ctl
{
    public partial class TextSet_Jucyu : UserControl
    {
        public BaseText btbTokuiCd;

        public String strNo
        {
            get
            {
                return txtNoElem1.Text;
            }
            set
            {
                txtNoElem1.Text = value;
            }
        }

        public String strChumonNo
        {
            get
            {
                return txtJucyuNoElem2.Text;
            }
            set
            {
                txtJucyuNoElem2.Text = value;
            }
        }

        public String strSinaBan
        {
            get
            {
                return txtSinaBanElem3.Text;
            }
            set
            {
                txtSinaBanElem3.Text = value;
            }
        }

        public String strSuuryo
        {
            get
            {
                return txtSuuryoElem4.Text;
            }
            set
            {
                txtSuuryoElem4.Text = value;
            }
        }

        public String strTanka
        {
            get
            {
                return txtTankaElem5.Text;
            }
            set
            {
                txtTankaElem5.Text = value;
            }
        }

        public String strTankaKakeritu
        {
            get
            {
                return txtJucyuRitu.Text;
            }
            set
            {
                txtJucyuRitu.Text = value;
            }
        }

        public String strKingaku
        {
            get
            {
                return txtKingakuElem6.Text;
            }
            set
            {
                txtKingakuElem6.Text = value;
            }
        }

        public String strCyokkinSiireTanka
        {
            get
            {
                return txtCyokkinSiire.Text;
            }
            set
            {
                txtCyokkinSiire.Text = value;
            }
        }

        public String strCyokkinSiireRitu
        {
            get
            {
                return txtCyokkinSiireRitu.Text;
            }
            set
            {
                txtCyokkinSiireRitu.Text = value;
            }
        }

        public String strCyokkinSiireRituA
        {
            get
            {
                return txtCyokkinSiireRituA.Text;
            }
            set
            {
                txtCyokkinSiireRituA.Text = value;
            }
        }

        public String strSoukoNo
        {
            get
            {
                return labelSet_SoukoNoElem10.CodeTxtText;
            }
            set
            {
                labelSet_SoukoNoElem10.CodeTxtText = value;
            }
        }

        public String strSoukomei
        {
            get
            {
                return labelSet_SoukoNoElem10.AppendLabelText;
            }
            set
            {
                labelSet_SoukoNoElem10.AppendLabelText = value;
            }
        }

        public String strTeika
        {
            get
            {
                return txtTeika.Text;
            }
            set
            {
                txtTeika.Text = value;
            }
        }

        public String strGenka
        {
            get
            {
                return txtGenkaElem7.Text;
            }
            set
            {
                txtGenkaElem7.Text = value;
            }
        }

        public String strGenkaKakeritu
        {
            get
            {
                return txtSiireRitu.Text;
            }
            set
            {
                txtSiireRitu.Text = value;
            }
        }

        public String strArari
        {
            get
            {
                return txtArariElem8.Text;
            }
            set
            {
                txtArariElem8.Text = value;
            }
        }

        public String strArariRitu
        {
            get
            {
                return txtRitsuElem21.Text;
            }
            set
            {
                txtRitsuElem21.Text = value;
            }
        }

        public String strMasterSiire
        {
            get
            {
                return txtMasterSiire.Text;
            }
            set
            {
                txtMasterSiire.Text = value;
            }
        }

        public String strMasterSiireRitu
        {
            get
            {
                return txtMasterSiireRitu.Text;
            }
            set
            {
                txtMasterSiireRitu.Text = value;
            }
        }

        public String strMasterSiireRituA
        {
            get
            {
                return txtMasterSiireRituA.Text;
            }
            set
            {
                txtMasterSiireRituA.Text = value;
            }
        }

        public String strBikouElem9
        {
            get
            {
                return txtBikouElem9.Text;
            }
            set
            {
                txtBikouElem9.Text = value;
            }
        }

        public TextSet_Jucyu()
        {
            InitializeComponent();
            this.TabStop = true;
        }

        //テキストボックスをクリックした場合
        private void txtBox_Click(object sender, EventArgs e)
        {
            //親フォームのコントロールを取得する。
            A0020_UriageInput C_uriageInput = (A0020_UriageInput)this.Parent;
            //選択行取得メソッドへ。
            C_uriageInput.getCurrentRow(sender,e);
        }

        //注文Noのフォーカスが外れた場合
        private void txtJucyuNoElem2_Leave(object sender, EventArgs e)
        {
            txtJucyuNoElem2_func();
        }

        //注文Noのフォーカスが外れた場合の処理
        public void txtJucyuNoElem2_func()
        {
            //メインフォームのコントロールを取得。
            A0020_UriageInput C_uriageInput = (A0020_UriageInput)this.Parent;

            //テキストボックスの項目を全削除
            OneLineClear2();

            //注文Noが未入力の場合は合計計算処理を行う。
            if (string.IsNullOrWhiteSpace(txtJucyuNoElem2.Text))
            {
                //合計計算処理へ。
                GokeiKeisan();
                txtJucyuNoElem2.Focus();
                return;
            }
            
            try
            {
                //データ取得用テーブルを初期化
                DataTable rs;
                DataTable rs3;

                string strSQLInput = " SELECT 得意先コード, 商品コード, メーカーコード, 大分類コード, 中分類コード, Ｃ１, Ｃ２, Ｃ３, Ｃ４, Ｃ５, Ｃ６, 受注数量, 受注単価, 仕入単価, 納期, 注番, 売上フラグ, 売上済数量, 得意先名称, 本社出庫数, 岐阜出庫数, 営業所コード, dbo.f_getメーカー名(受注.メーカーコード) AS メーカー名, 受注者コード ";
                strSQLInput += " FROM 受注 WHERE 受注番号 = "+ txtJucyuNoElem2.Text +" AND 削除 = 'N' ";


                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                rs = dbconnective.ReadSql(strSQLInput);

                if (rs.Rows.Count > 0)
                {
                    //取得得意先コードが入力した得意先コードと異なる場合はメッセージを表示し、終了。
                    if (!(rs.Rows[0]["得意先コード"].ToString()).Equals(C_uriageInput.labelSet_txtCD.CodeTxtText))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "指定した取引先の受注データではありません！！", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                        txtJucyuNoElem2.Text = "";
                        txtJucyuNoElem2.Focus();
                        return;
                    }

                    //年月日が2005年8月1日以降の場合
                    if (DateTime.Parse(C_uriageInput.txtYMD.Text) >= DateTime.Parse("2005/08/01"))
                    {

                        strSQLInput = "SELECT dbo.f_get受注番号から発注番号FROM発注(" + txtJucyuNoElem2.Text + ") AS 発注番号";

                        //SQL文を直書き（＋戻り値を受け取る)
                        rs3 = dbconnective.ReadSql(strSQLInput);

                        //発注番号が空白でない場合
                        if (rs3.Rows[0]["発注番号"].ToString() != "")
                        {
                            string HachuuNo = rs3.Rows[0]["発注番号"].ToString();

                            strSQLInput = "SELECT 仕入先コード FROM 発注 WHERE 発注番号 = " + HachuuNo;

                            //SQL文を直書き（＋戻り値を受け取る)
                            rs3 = dbconnective.ReadSql(strSQLInput);

                            //仕入先コード9999、7777は返品口座の為、仕入入力はチェックしない。
                            if (rs3.Rows[0]["仕入先コード"].ToString() != "9999" && rs3.Rows[0]["仕入先コード"].ToString() != "7777")
                            {
                                strSQLInput = "SELECT dbo.f_get仕入済数量_発注(" + txtJucyuNoElem2.Text + ") 仕入済数量";

                                //SQL文を直書き（＋戻り値を受け取る)
                                rs3 = dbconnective.ReadSql(strSQLInput);

                                if (rs3.Rows[0]["仕入済数量"].ToString() == "0")
                                {
                                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "仕入入力がされていません！！", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                    basemessagebox.ShowDialog();
                                    txtJucyuNoElem2.Text = "";
                                    txtJucyuNoElem2.Focus();
                                }

                            }
                        }
                    }

                    if (C_uriageInput.MODY_FLAG == false)
                    {
                        if (rs.Rows[0]["売上フラグ"].ToString() == "1")
                        {
                            if (decimal.Parse(rs.Rows[0]["売上済数量"].ToString()) >= decimal.Parse(rs.Rows[0]["受注数量"].ToString()))
                            {
                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "売上済の受注データです！！", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                basemessagebox.ShowDialog();
                                txtJucyuNoElem2.Text = "";
                                txtJucyuNoElem2.Focus();
                                return;
                            }
                            else
                            {
                                string MSG = decimal.Parse(rs.Rows[0]["売上済数量"].ToString()).ToString("###,###") + "個が売上済です！！";
                                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT,MSG, CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                                basemessagebox.ShowDialog();
                            }
                        }
                    }

                    string Hinmei = "";
                    string NM = "";

                    if (rs.Rows[0]["商品コード"] != null && !string.IsNullOrWhiteSpace(rs.Rows[0]["商品コード"].ToString()))
                    {
                        txtSyohinCdElem11.Text = rs.Rows[0]["商品コード"].ToString();
                        //商品コードからフォーカスを外れた場合の処理へ
                        txtSyohinCdElem11_func();
                    }

                    if (rs.Rows[0]["メーカーコード"] != null && !string.IsNullOrWhiteSpace(rs.Rows[0]["メーカーコード"].ToString()))
                    {
                        txtElem12.Text = rs.Rows[0]["メーカーコード"].ToString();
                    }

                    if (rs.Rows[0]["大分類コード"] != null && !string.IsNullOrWhiteSpace(rs.Rows[0]["大分類コード"].ToString()))
                    {
                        txtElem13.Text = rs.Rows[0]["大分類コード"].ToString();
                    }

                    Hinmei = rs.Rows[0]["メーカー名"].ToString().TrimEnd();

                    if (rs.Rows[0]["中分類コード"].ToString() != null)
                    {
                        txtElem14.Text = rs.Rows[0]["中分類コード"].ToString();

                        //中分類名取得メソッドへ
                        if (GetCyubunruiName(txtElem13.Text, txtElem14.Text, ref NM))
                        {
                            Hinmei += " " + NM.TrimEnd();
                        }
                    }

                    if (rs.Rows[0]["Ｃ１"].ToString() != null)
                    {
                        Hinmei += " " + rs.Rows[0]["Ｃ１"].ToString().TrimEnd();
                        txtElem15.Text = rs.Rows[0]["Ｃ１"].ToString();
                    }

                    if (rs.Rows[0]["Ｃ２"].ToString() != null)
                    {
                        Hinmei += " " + rs.Rows[0]["Ｃ２"].ToString().TrimEnd();
                        txtElem16.Text = rs.Rows[0]["Ｃ２"].ToString();
                    }

                    if (rs.Rows[0]["Ｃ３"].ToString() != null)
                    {
                        Hinmei += " " + rs.Rows[0]["Ｃ３"].ToString().TrimEnd();
                        txtElem17.Text = rs.Rows[0]["Ｃ３"].ToString();
                    }

                    if (rs.Rows[0]["Ｃ４"].ToString() != null)
                    {
                        Hinmei += " " + rs.Rows[0]["Ｃ４"].ToString().TrimEnd();
                        txtElem18.Text = rs.Rows[0]["Ｃ４"].ToString();
                    }

                    if (rs.Rows[0]["Ｃ５"].ToString() != null)
                    {
                        Hinmei += " " + rs.Rows[0]["Ｃ５"].ToString().TrimEnd();
                        txtElem19.Text = rs.Rows[0]["Ｃ５"].ToString();
                    }

                    if (rs.Rows[0]["Ｃ６"].ToString() != null)
                    {
                        Hinmei += " " + rs.Rows[0]["Ｃ６"].ToString().TrimEnd();
                        txtElem20.Text = rs.Rows[0]["Ｃ６"].ToString();
                    }

                    //品名を設定
                    txtSinaBanElem3.Text = Hinmei;

                    //数量を設定
                    txtSuuryoElem4.Text = (decimal.Parse(rs.Rows[0]["受注数量"].ToString()) - decimal.Parse(rs.Rows[0]["売上済数量"].ToString())).ToString();
                    //数量が変更した場合の処理へ。
                    txtSuuryoElem4_func();

                    txtElem22.Text = txtSuuryoElem4.Text;

                    string st = "";
                    if (rs.Rows[0]["受注単価"] != null && !string.IsNullOrWhiteSpace(rs.Rows[0]["受注単価"].ToString()))
                    {
                        st = (decimal.Parse(rs.Rows[0]["受注単価"].ToString())).ToString("#,0");
                    }
                    txtTankaElem5.Text = st;
                    //単価が変更した場合の処理へ。
                    txtTankaElem5_func();

                    //加工品受注チェックへ。
                    if (ChkKakouhinJucyu(txtJucyuNoElem2.Text))
                    {
                        //加工品の場合は受注時の仕入れ単価のまま
                        txtGenkaElem7.Text = rs.Rows[0]["仕入単価"].ToString();
                    }
                    else
                    {
                        //仕入れ単価は商品マスタの仕入単価を表示する。
                        txtGenkaElem7.Text = (GetSyohinSiireTanka(rs.Rows[0]["商品コード"].ToString())).ToString();
                    }

                    //原価が変更になった場合の処理へ。
                    txtGenkaElem7_func();

                    txtBikouElem9.Text = rs.Rows[0]["注番"].ToString();

                    labelSet_SoukoNoElem10.CodeTxtText = rs.Rows[0]["営業所コード"].ToString();

                    C_uriageInput.txtTname.ReadOnly = true;

                    if (C_uriageInput.labelSet_txtCD.CodeTxtText.Equals("8888") || C_uriageInput.labelSet_txtCD.CodeTxtText.Equals("6666") || C_uriageInput.labelSet_txtCD.CodeTxtText.Equals("7777"))
                    {
                        C_uriageInput.txtTname.Text = rs.Rows[0]["得意先名称"].ToString();
                        C_uriageInput.txtTname.ReadOnly = false;
                    }

                    C_uriageInput.labelSet_Tantousha.CodeTxtText = rs.Rows[0]["受注者コード"].ToString();

                    txtSinaBanElem3.ReadOnly = true;
                    txtSinaBanElem3.BackColor = SystemColors.Window;
                    txtGenkaElem7.ReadOnly = true;
                    txtGenkaElem7.BackColor = SystemColors.Window;
                    C_uriageInput.labelSet_txtCD.Enabled = false;

                    //返品承認済みは編集不可
                    strSQLInput = "SELECT COUNT(*) AS 返品値引売上承認カウント FROM 返品値引売上承認 WHERE 受注番号=" + txtJucyuNoElem2.Text + " AND 承認フラグ='1'";

                    //SQL文を直書き（＋戻り値を受け取る)
                    rs3 = dbconnective.ReadSql(strSQLInput);

                    if (int.Parse(rs3.Rows[0]["返品値引売上承認カウント"].ToString()) > 0)
                    {
                        txtNoElem1.Enabled = false;
                        txtJucyuNoElem2.Enabled = false;
                        txtSuuryoElem4.Enabled = false;
                        txtTankaElem5.Enabled = false;
                        txtKingakuElem6.Enabled = false;
                        txtArariElem8.Enabled = false;
                        txtBikouElem9.Enabled = false;
                        labelSet_SoukoNoElem10.Enabled = false;
                        txtSyohinCdElem11.Enabled = false;
                        txtElem12.Enabled = false;
                        txtElem13.Enabled = false;
                        txtElem14.Enabled = false;
                        txtElem15.Enabled = false;
                        txtElem16.Enabled = false;
                        txtElem17.Enabled = false;
                        txtElem18.Enabled = false;
                        txtElem19.Enabled = false;
                        txtElem20.Enabled = false;
                        txtRitsuElem21.Enabled = false;
                        txtElem22.Enabled = false;

                    }
                    else
                    {
                        txtNoElem1.Enabled = true;
                        txtJucyuNoElem2.Enabled = true;
                        txtSuuryoElem4.Enabled = true;
                        txtTankaElem5.Enabled = true;
                        txtKingakuElem6.Enabled = true;
                        txtArariElem8.Enabled = true;
                        txtBikouElem9.Enabled = true;
                        labelSet_SoukoNoElem10.Enabled = true;
                        txtSyohinCdElem11.Enabled = true;
                        txtElem12.Enabled = true;
                        txtElem13.Enabled = true;
                        txtElem14.Enabled = true;
                        txtElem15.Enabled = true;
                        txtElem16.Enabled = true;
                        txtElem17.Enabled = true;
                        txtElem18.Enabled = true;
                        txtElem19.Enabled = true;
                        txtElem20.Enabled = true;
                        txtRitsuElem21.Enabled = true;
                        txtElem22.Enabled = true;
                    }

                    //カンマのある形へ整形
                    txtSuuryoElem4.Text = decimal.Parse(txtSuuryoElem4.Text).ToString("#,0");
                    //txtTankaElem5.Text = decimal.Parse(txtTankaElem5.Text).ToString("#,0.00");
                    txtTankaElem5.Text = decimal.Parse(txtTankaElem5.Text).ToString("#,0");
                    txtGenkaElem7.Text = decimal.Parse(txtGenkaElem7.Text).ToString("#,0.00");
                    txtKingakuElem6.Text = decimal.Parse(txtKingakuElem6.Text).ToString("#,0");
                    txtArariElem8.Text = decimal.Parse(txtArariElem8.Text).ToString("#,0");
                    txtCyokkinSiire.Text = decimal.Parse(PutIsNull(txtCyokkinSiire.Text,"0")).ToString("#,0");
                    txtMasterSiire.Text = decimal.Parse(PutIsNull(txtMasterSiire.Text,"0")).ToString("#,0");
                    txtTeika.Text = decimal.Parse(PutIsNull(txtTeika.Text,"0")).ToString("#,0");

                    txtRitsuElem21.Text = decimal.Parse(txtRitsuElem21.Text).ToString("0.0");
                    txtCyokkinSiireRituA.Text = decimal.Parse(PutIsNull(txtCyokkinSiireRituA.Text,"0")).ToString("0.0");
                    txtMasterSiireRituA.Text = decimal.Parse(PutIsNull(txtMasterSiireRituA.Text,"0")).ToString("0.0");

                    txtTankaElem5.ReadOnly = true;
                    txtGenkaElem7.ReadOnly = true;
                    txtKingakuElem6.ReadOnly = true;
                    txtArariElem8.ReadOnly = true;
                    txtTankaElem5.BackColor = SystemColors.Window;
                    txtGenkaElem7.BackColor = SystemColors.Window;
                    txtKingakuElem6.BackColor = SystemColors.Window;
                    txtArariElem8.BackColor = SystemColors.Window;

                }
                else
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "受注データが存在しません！！", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    txtJucyuNoElem2.Text = "";
                    txtJucyuNoElem2.Focus();
                }

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
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

        //商品マスタより仕入れ単価を得る
        private decimal GetSyohinSiireTanka(string SyouhinCD)
        {
            if (string.IsNullOrWhiteSpace(SyouhinCD))
            {
                return 0;
            }

            //データ取得用テーブルを初期化
            DataTable dtSetCd;

            try
            {
                string strSQLInput = "SELECT 仕入単価 FROM 商品 WHERE 商品コード='" + SyouhinCD + "'  and 削除='N'";

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count > 0)
                {
                    //仕入単価を返す。
                     return decimal.Parse(dtSetCd.Rows[0]["仕入単価"].ToString());
                }

                return 0;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return 0;
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return 0;
                }
            }
        }

        //加工品受注かチェックを行うメソッド
        private Boolean ChkKakouhinJucyu(string JNo)
        {
            //データ取得用テーブルを初期化
            DataTable dtSetCd;

            try
            {
                string strSQLInput = "SELECT COUNT(*) AS カウント FROM 発注 WHERE 受注番号=" + JNo + " AND 削除='N' AND 加工区分='1'";

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows[0]["カウント"].ToString() == "0" )
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
            }
        }

        //中分類名を得るメソッド
        public Boolean GetCyubunruiName(string Dai, string Cyu, ref string Name)
        {
            string strSQL;
            bool re = true;

            if (string.IsNullOrWhiteSpace(Dai) || string.IsNullOrWhiteSpace(Cyu))
            {
                Name = "";
                return re;
            }

            //データ取得用テーブルを初期化
            DataTable dtSetCd;

            try
            {
                string strSQLInput = "SELECT 中分類名 FROM 中分類 WHERE 大分類コード='" + Dai + "'" + " and 中分類コード='" + Cyu + "'  and 削除='N'";

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count > 0)
                {
                    Name = PutIsNull(dtSetCd.Rows[0]["中分類名"].ToString(),"");
                }
                else
                {
                    re = false;
                }

                return re;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return false;
                }
            }
        }

        public void GokeiKeisan()
        {
            //メインフォームのコントロールを取得。
            A0020_UriageInput C_uriageInput = (A0020_UriageInput)this.Parent;

            //コードが未入力の場合は処理を終了する。
            if (string.IsNullOrWhiteSpace(C_uriageInput.labelSet_txtCD.CodeTxtText))
            {
                return;
            }

            //合計、消費税、総合計、粗利合計を初期化。
            C_uriageInput.txtGoukei1.Text = "";
            C_uriageInput.txtZei.Text = "";
            C_uriageInput.txtGoukei2.Text = "";
            C_uriageInput.txtGoukei3.Text = "";
            C_uriageInput.txtArariKei.Text = "";

            decimal Kingaku;
            decimal Genka;
            decimal Arari;
            Kingaku = 0;
            Genka = 0;
            Arari = 0;

            //金額、原価、粗利を合計する。
            Kingaku += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu1.strKingaku, "0"));
            Kingaku += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu2.strKingaku, "0"));
            Kingaku += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu3.strKingaku, "0"));
            Kingaku += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu4.strKingaku, "0"));
            Kingaku += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu5.strKingaku, "0"));

            Genka += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu1.strSuuryo, "0")) * decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu1.strGenka, "0"));
            Genka += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu2.strSuuryo, "0")) * decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu2.strGenka, "0"));
            Genka += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu3.strSuuryo, "0")) * decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu3.strGenka, "0"));
            Genka += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu4.strSuuryo, "0")) * decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu4.strGenka, "0"));
            Genka += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu5.strSuuryo, "0")) * decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu5.strGenka, "0"));

            Arari += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu1.strArari, "0"));
            Arari += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu2.strArari, "0"));
            Arari += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu3.strArari, "0"));
            Arari += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu4.strArari, "0"));
            Arari += decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu5.strArari, "0"));

            //合計、原価合計、粗利合計に設定。
            C_uriageInput.txtGoukei1.Text = Kingaku.ToString("#,0");
            C_uriageInput.txtGoukei3.Text = Genka.ToString("#,0");
            C_uriageInput.txtArariKei.Text = Arari.ToString("#,0");

            int SyohizeiKubun; //所費税計算区分    0:外税    1:内税
            int Hasu;          //消費税端数計算区分　0:切り捨て   1:四捨五入 2:切り上げ
            int Zeikeisan;      //消費税計算区分     0：行　１：伝票　２：請求

            //消費税区分と端数計算区分と消費税計算区分を取得する。
            SyohizeiKubun = getSyihizeikubun(C_uriageInput.labelSet_txtCD.CodeTxtText);
            Hasu = getHasukeisankubun(C_uriageInput.labelSet_txtCD.CodeTxtText);
            Zeikeisan = getTokuisakikeisankubun(C_uriageInput.labelSet_txtCD.CodeTxtText);

            //請求の場合
            if (Zeikeisan == 2)
            {
                C_uriageInput.txtZei.Text = "0";
                C_uriageInput.txtGoukei2.Text = Kingaku.ToString("#,0");
                return;
            }

            //内税の場合
            if (SyohizeiKubun == 1)
            {
                C_uriageInput.txtZei.Text = "0";
                C_uriageInput.txtGoukei2.Text = Kingaku.ToString("#,0");
            }

            decimal Syohizei;

            if (C_uriageInput.txtYMD.Text.Equals(""))
            {
                Syohizei = 0;
            }
            else
            {
                //消費税率を得る
                Syohizei = getSyohizeiritu(C_uriageInput.txtYMD.Text);
            }

            decimal ZeiGokei = 0;
            decimal work1 = 0;
            decimal work2 = 0;
            decimal work3 = 0;
            decimal work4 = 0;
            decimal work5 = 0;

            //行の場合
            if (Zeikeisan == 0)
            {
                //消費税を算出する。
                work1 = decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu1.txtKingakuElem6.Text, "0")) * Syohizei / 100;
                work2 = decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu2.txtKingakuElem6.Text, "0")) * Syohizei / 100;
                work3 = decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu3.txtKingakuElem6.Text, "0")) * Syohizei / 100;
                work4 = decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu4.txtKingakuElem6.Text, "0")) * Syohizei / 100;
                work5 = decimal.Parse(PutIsNull(C_uriageInput.textSet_Jucyu5.txtKingakuElem6.Text, "0")) * Syohizei / 100;

                switch (Hasu)
                {
                    //切り捨て
                    case 0:
                        Zeikeisan += (int)Math.Floor(work1);
                        Zeikeisan += (int)Math.Floor(work2);
                        Zeikeisan += (int)Math.Floor(work3);
                        Zeikeisan += (int)Math.Floor(work4);
                        Zeikeisan += (int)Math.Floor(work5);
                        break;
                    //四捨五入
                    case 1:
                        Zeikeisan += (int)Math.Round(work1);
                        Zeikeisan += (int)Math.Round(work2);
                        Zeikeisan += (int)Math.Round(work3);
                        Zeikeisan += (int)Math.Round(work4);
                        Zeikeisan += (int)Math.Round(work5);
                        break;
                    //切り上げ
                    case 2:
                        Zeikeisan += (int)Math.Ceiling(work1);
                        Zeikeisan += (int)Math.Ceiling(work2);
                        Zeikeisan += (int)Math.Ceiling(work3);
                        Zeikeisan += (int)Math.Ceiling(work4);
                        Zeikeisan += (int)Math.Ceiling(work5);
                        break;
                }

                C_uriageInput.txtZei.Text = Zeikeisan.ToString();
            }
            //行以外の場合
            else
            {
                work1 = Kingaku * Syohizei / 100;

                switch (Hasu)
                {
                    //切り捨て
                    case 0:
                        C_uriageInput.txtZei.Text = ((int)Math.Floor(work1)).ToString();
                        break;
                    //四捨五入
                    case 1:
                        C_uriageInput.txtZei.Text = ((int)Math.Floor(work2)).ToString();
                        break;
                    //切り上げ
                    case 2:
                        C_uriageInput.txtZei.Text = ((int)Math.Floor(work3)).ToString();
                        break;
                }
            }

            //総合計　=　合計　＊　消費税
            C_uriageInput.txtGoukei2.Text = (decimal.Parse(C_uriageInput.txtGoukei1.Text) + decimal.Parse(C_uriageInput.txtZei.Text)).ToString("#,0"); 
        }
        
        //消費税区分を取得する関数
        private int getSyihizeikubun(string txtCD)
        {
            //データ取得用テーブルを初期化
            DataTable dtSetCd;
            int Syohizeikubun =0;

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = " SELECT 消費税区分 FROM 取引先 WHERE 取引先コード= '" +txtCD+ "'";

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count > 0)
                {
                    Syohizeikubun = int.Parse(dtSetCd.Rows[0]["消費税区分"].ToString()); 
                }

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
            }

            return Syohizeikubun;
        }

        //端数計算区分を取得する関数
        private int getHasukeisankubun(string txtCD)
        {
            //データ取得用テーブルを初期化
            DataTable dtSetCd;
            int Hasukeisankubun = 0;

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = " SELECT 消費税端数計算区分 FROM 取引先 WHERE 取引先コード= '" + txtCD + "'";

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count > 0)
                {
                    Hasukeisankubun = int.Parse(dtSetCd.Rows[0]["消費税端数計算区分"].ToString());
                }

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
            }

            return Hasukeisankubun;
        }

        //消費税計算区分を取得する関数
        private int getTokuisakikeisankubun(string txtCD)
        {
            //データ取得用テーブルを初期化
            DataTable dtSetCd;
            int Tokuisakikeisankubun = 0;

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = " SELECT 消費税計算区分 FROM 取引先 WHERE 取引先コード= '" + txtCD + "'";

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count > 0)
                {
                    Tokuisakikeisankubun = int.Parse(dtSetCd.Rows[0]["消費税計算区分"].ToString());
                }

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
            }

            return Tokuisakikeisankubun;
        }

        //消費税率を得る
        private decimal getSyohizeiritu(string txtYMD)
        {
            //データ取得用テーブルを初期化
            DataTable dtSetCd;
            decimal Syohizeiritu = 0;
            string strYMD = DateTime.Now.ToString("yyyy/MM/dd");

            if (!string.IsNullOrWhiteSpace(txtYMD))
            {
                strYMD = txtYMD;
            }

            try
            {
                string strSQLInput = " SELECT 消費税率 FROM 消費税率 WHERE 適用開始年月日= (SELECT MAX(適用開始年月日) FROM 消費税率 WHERE 適用開始年月日 <= '" + strYMD + "')";

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count > 0)
                {
                    Syohizeiritu = decimal.Parse(dtSetCd.Rows[0]["消費税率"].ToString());
                }

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
            }

            return Syohizeiritu;
        }

        ///<summary>
        ///PutIsNull
        ///値がNULLの場合、差し替え文字を挿入する。
        ///</summary>
        private String PutIsNull(string CheckColumn, String ChangeValue)
        {
            if (string.IsNullOrWhiteSpace(CheckColumn))
            {
                //値の差し替え
                CheckColumn = ChangeValue;
                return CheckColumn;
            }
            return CheckColumn;
        }

        //注文No以外のテキストボックスを削除する。
        private void OneLineClear2()
        {
            txtNoElem1.Text = "";
            txtSinaBanElem3.Text = "";
            txtSuuryoElem4.Text = "";
            txtTankaElem5.Text = "";
            txtKingakuElem6.Text = "";
            txtGenkaElem7.Text = "";
            txtArariElem8.Text = "";
            txtBikouElem9.Text = "";
            labelSet_SoukoNoElem10.CodeTxtText = "";
            labelSet_SoukoNoElem10.ValueLabelText = "";
            txtSyohinCdElem11.Text = "";
            txtElem12.Text = "";
            txtElem13.Text = "";
            txtElem14.Text = "";
            txtElem15.Text = "";
            txtElem16.Text = "";
            txtElem17.Text = "";
            txtElem18.Text = "";
            txtElem19.Text = "";
            txtElem20.Text = "";
            txtRitsuElem21.Text = "";
            txtElem22.Text = "";

            txtTeika.Text = "";
            txtJucyuRitu.Text = "";
            txtSiireRitu.Text = "";
            txtCyokkinSiire.Text = "";
            txtCyokkinSiireRitu.Text = "";
            txtMasterSiire.Text = "";
            txtMasterSiireRitu.Text = "";

            txtTankaElem5.ReadOnly = false;
            txtGenkaElem7.ReadOnly = false;
            txtKingakuElem6.ReadOnly = false;
            txtArariElem8.ReadOnly = false;
        }

        //数量テキストボックスからフォーカスが外れた場合
        private void txtSuuryoElem4_Leave(object sender, EventArgs e)
        {
            txtSuuryoElem4_func();
        }

        //数量テキストボックスからフォーカスが外れた場合の処理。
        public void txtSuuryoElem4_func()
        {
            //メインフォームのコントロールを取得。
            A0020_UriageInput C_uriageInput = (A0020_UriageInput)this.Parent;

            //コードが未入力の場合は処理を終了。
            if (string.IsNullOrWhiteSpace(C_uriageInput.labelSet_txtCD.CodeTxtText))
            {
                return;
            }

            //数量が未入力の場合は処理を終了
            if (string.IsNullOrWhiteSpace(txtSuuryoElem4.Text))
            {
                return;
            }

            //単価が未入力の場合は処理を終了
            if (string.IsNullOrWhiteSpace(txtTankaElem5.Text))
            {
                return;
            }

            //金額・粗利・率算出メソッドへ。
            culKingaku_Ararigaku_ritu();

            //合計計算メソッドへ
            GokeiKeisan();
        }

        //単価テキストボックスからフォーカスが外れた場合
        private void txtTankaElem5_Leave(object sender, EventArgs e)
        {
            txtTankaElem5_func();
        }

        //単価テキストボックスからフォーカスが外れた場合の処理。
        public void txtTankaElem5_func()
        {
            //メインフォームのコントロールを取得。
            A0020_UriageInput C_uriageInput = (A0020_UriageInput)this.Parent;

            //コードが未入力の場合は処理を終了。
            if (string.IsNullOrWhiteSpace(C_uriageInput.labelSet_txtCD.CodeTxtText))
            {
                return;
            }

            //数量が未入力の場合は処理を終了
            if (string.IsNullOrWhiteSpace(txtSuuryoElem4.Text))
            {
                return;
            }

            //単価が未入力の場合は処理を終了
            if (string.IsNullOrWhiteSpace(txtTankaElem5.Text))
            {
                return;
            }

            //金額・粗利・率算出メソッドへ。
            culKingaku_Ararigaku_ritu();

            //合計計算メソッドへ
            GokeiKeisan();

            //掛率更新メソッドへ
            KakerituKosin();
        }

        //原価テキストボックスのフォーカスが外れた場合。
        private void txtGenkaElem7_Leave(object sender, EventArgs e)
        {
            txtGenkaElem7_func();
        }

        //原価テキストボックスのフォーカスが外れた場合の処理
        public void txtGenkaElem7_func()
        {
            //メインフォームのコントロールを取得。
            A0020_UriageInput C_uriageInput = (A0020_UriageInput)this.Parent;


            //数量が未入力の場合は処理を終了
            if (string.IsNullOrWhiteSpace(txtSuuryoElem4.Text))
            {
                return;
            }

            //単価が未入力の場合は処理を終了
            if (string.IsNullOrWhiteSpace(txtTankaElem5.Text))
            {
                return;
            }

            //原価が未入力の場合は処理を終了
            if (string.IsNullOrWhiteSpace(txtGenkaElem7.Text))
            {
                return;
            }

            //コードが未入力の場合は処理を終了。
            if (string.IsNullOrWhiteSpace(C_uriageInput.labelSet_txtCD.CodeTxtText))
            {
                return;
            }

            //金額・粗利・率算出メソッドへ。
            culKingaku_Ararigaku_ritu();

            //合計計算メソッドへ
            GokeiKeisan();

            //掛率更新メソッドへ
            KakerituKosin();
        }

        //商品コードテキストボックス（非表示項目）のテキストボックスが外れた場合
        private void txtSyohinCdElem11_Leave(object sender, EventArgs e)
        {
            txtSyohinCdElem11_func();
        }

        //商品コードテキストボックス（非表示項目）のテキストボックスが外れた場合の処理。
        public void txtSyohinCdElem11_func()
        {
            if (string.IsNullOrWhiteSpace(txtSyohinCdElem11.Text))
            {
                return;
            }
            //データ取得用テーブルを初期化
            DataTable rs9;

            try
            {
                string strSQLInput = "SELECT * FROM 商品 WHERE 商品コード='" + txtSyohinCdElem11.Text + "' AND 削除='N'";

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                rs9 = dbconnective.ReadSql(strSQLInput);

                if (rs9.Rows.Count > 0)
                {
                    txtTeika.Text = decimal.Parse(rs9.Rows[0]["定価"].ToString()).ToString();
                    txtMasterSiire.Text = decimal.Parse(rs9.Rows[0]["仕入単価"].ToString()).ToString();

                    //直近仕入単価を取得するメソッドへ。
                    txtCyokkinSiire.Text = CyokkinSiireTanka().ToString();

                    //掛率更新メソッドへ。
                    KakerituKosin();
                }

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
            }
        }

        //直近仕入単価を取得する処理。
        private decimal CyokkinSiireTanka()
        {
            //データ取得用テーブルを初期化
            DataTable rs8;

            try
            {
                if (!string.IsNullOrWhiteSpace(txtJucyuNoElem2.Text)) {
                    string strSQLInput = "";

                    strSQLInput += " SELECT";
                    strSQLInput += "         受注.仕入単価 AS 仕入単価";
                    strSQLInput += " FROM";
                    strSQLInput += "         受注 INNER JOIN 発注 ";
                    strSQLInput += "     ON (発注.商品コード = 受注.商品コード) ";
                    strSQLInput += "     AND (受注.受注番号 = 発注.受注番号)";
                    strSQLInput += " WHERE";
                    strSQLInput += "     発注.削除 ='N' AND";
                    strSQLInput += "     受注.削除 ='N' AND";
                    strSQLInput += "     発注.加工区分 ='1' AND";
                    strSQLInput += "     受注.受注番号 =" + txtJucyuNoElem2.Text;

                    //SQLのインスタンス作成
                    DBConnective dbconnective = new DBConnective();

                    //SQL文を直書き（＋戻り値を受け取る)
                    rs8 = dbconnective.ReadSql(strSQLInput);

                    if (rs8.Rows.Count > 0)
                    {
                        return decimal.Parse(rs8.Rows[0]["仕入単価"].ToString());
                    }
                    else
                    {
                        //商品コードから直近仕入単価を得るメソッドへ
                        return GetCyokkinSiireTanka(txtSyohinCdElem11.Text);
                    }
                }
                else
                {
                    //商品コードから直近仕入単価を得るメソッドへ
                    return GetCyokkinSiireTanka(txtSyohinCdElem11.Text);
                }

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return 0;
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return 0;
                }
            }
        }

        //商品コードより直近仕入単価を得る。
        private decimal GetCyokkinSiireTanka(string SyouhinCD)
        {
            if (string.IsNullOrWhiteSpace(SyouhinCD))
            {
                return 0;
            }

            //データ取得用テーブルを初期化
            DataTable dtSetCd;

            try
            {
                string strSQLInput = "";

                strSQLInput += "SELECT H.伝票年月日,M.仕入単価 AS 仕入単価  FROM 仕入ヘッダ H,仕入明細 M WHERE H.削除='N' and M.削除='N' AND H.伝票番号=M.伝票番号 AND  M.商品コード='" + SyouhinCD + "' ORDER BY H.伝票年月日 DESC ";

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count > 0)
                {
                    return decimal.Parse(dtSetCd.Rows[0]["仕入単価"].ToString());
                }

                return 0;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return 0;
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return 0;
                }
            }
        }

        //金額・粗利額・率を計算するメソッド
        private void culKingaku_Ararigaku_ritu()
        {
            //メインフォームのコントロールを取得。
            A0020_UriageInput C_uriageInput = (A0020_UriageInput)this.Parent;

            int hasuu = 0;

            //端数区分を取得するメソッドへ。
            hasuu = GetTokuisakiHasuSyori(C_uriageInput.labelSet_txtCD.CodeTxtText);

            //金額算出
            decimal work1 = decimal.Parse(PutIsNull(txtSuuryoElem4.Text, "0")) * decimal.Parse(PutIsNull(txtTankaElem5.Text, "0"));

            switch (hasuu)
            {
                //切り捨て
                case 0:
                    txtKingakuElem6.Text = ((int)Math.Floor(work1)).ToString();
                    break;
                //四捨五入
                case 1:
                    txtKingakuElem6.Text = ((int)Math.Round(work1)).ToString();
                    break;
                //切り上げ
                case 2:
                    txtKingakuElem6.Text = ((int)Math.Ceiling(work1)).ToString();
                    break;
            }

            //金額がマイナスの場合は文字色を赤に変更。
            if (decimal.Parse(txtKingakuElem6.Text) < 0)
            {
                txtKingakuElem6.ForeColor = Color.Red;
            }
            else
            {
                txtKingakuElem6.ForeColor = Color.Black;
            }

            //カンマで区切るよう整形する。
            txtKingakuElem6.Text = decimal.Parse(txtKingakuElem6.Text).ToString("#,0");

            //粗利額算出。
            work1 = (decimal.Parse(PutIsNull(txtSuuryoElem4.Text, "0")) * decimal.Parse(PutIsNull(txtTankaElem5.Text, "0")))
                       - (decimal.Parse(PutIsNull(txtSuuryoElem4.Text, "0")) * decimal.Parse(PutIsNull(txtGenkaElem7.Text, "0")));
            switch (hasuu)
            {
                //切り捨て
                case 0:
                    txtArariElem8.Text = ((int)Math.Floor(work1)).ToString();
                    break;
                //四捨五入
                case 1:
                    txtArariElem8.Text = ((int)Math.Round(work1)).ToString();
                    break;
                //切り上げ
                case 2:
                    txtArariElem8.Text = ((int)Math.Ceiling(work1)).ToString();
                    break;
            }

            //カンマで区切るよう整形する。
            txtArariElem8.Text = decimal.Parse(txtArariElem8.Text).ToString("#,0");

            //粗利額がマイナスの場合は文字色を赤に変更。
            if (decimal.Parse(txtArariElem8.Text) < 0)
            {
                txtArariElem8.ForeColor = Color.Red;
            }
            else
            {
                txtArariElem8.ForeColor = Color.Black;
            }

            //率算出
            if (string.IsNullOrWhiteSpace(txtKingakuElem6.Text) || decimal.Parse(txtKingakuElem6.Text).Equals(0))
            {
                txtRitsuElem21.Text = "0";
            }
            else
            {
                txtRitsuElem21.Text = (decimal.Parse(txtArariElem8.Text) / decimal.Parse(txtKingakuElem6.Text) * 100).ToString();
                //少数第2位で四捨五入する。
                txtRitsuElem21.Text = decimal.Parse(txtRitsuElem21.Text).ToString("0.0");
            }
        }

        //掛率の更新
        private void KakerituKosin()
        {
            if (txtTeika.Text == "")
            {
                
            }
            else
            {


                //定価または単価が空白だった場合は、計算をSKIPする。
                if (txtTankaElem5.Text != "" && txtTeika.Text != "")
                {
                    //定価が0の場合は処理をSKIPする。
                    if (decimal.Parse(txtTeika.Text) != 0)
                    {
                        txtJucyuRitu.Text = (decimal.Parse(txtTankaElem5.Text) / decimal.Parse(txtTeika.Text) * 100).ToString();
                        //少数第2位で四捨五入する。
                        txtJucyuRitu.Text = decimal.Parse(txtJucyuRitu.Text).ToString("0.0");
                    }

                }

                //定価またはマスタ仕入単価が空白だった場合は、計算をSKIPする。
                if (txtMasterSiire.Text != "" && txtTeika.Text != "")
                {
                    //定価が0の場合は処理をSKIPする。
                    if (decimal.Parse(txtTeika.Text) != 0)
                    {
                        txtMasterSiireRitu.Text = (decimal.Parse(txtMasterSiire.Text) / decimal.Parse(txtTeika.Text) * 100).ToString();
                        //少数第2位で四捨五入する。
                        txtMasterSiireRitu.Text = decimal.Parse(txtMasterSiireRitu.Text).ToString("0.0");
                    }
                    
                }

                //定価または直近仕入単価が空白だった場合は、計算をSKIPする。
                if (txtCyokkinSiire.Text != "" && txtTeika.Text != "")
                {
                    //定価が0の場合は処理をSKIPする。
                    if (decimal.Parse(txtTeika.Text) != 0)
                    {
                        txtCyokkinSiireRitu.Text = (decimal.Parse(txtCyokkinSiire.Text) / decimal.Parse(txtTeika.Text) * 100).ToString();
                        //少数第2位で四捨五入する。
                        txtCyokkinSiireRitu.Text = decimal.Parse(txtCyokkinSiireRitu.Text).ToString("0.0");
                    }
                }

                //定価または原価が空白だった場合は計算をSKIPする。
                if (txtGenkaElem7.Text != "" && txtTeika.Text != "")
                {
                    //定価が0の場合は処理をSKIPする。
                    if (decimal.Parse(txtTeika.Text) != 0)
                    {
                        txtSiireRitu.Text = (decimal.Parse(txtGenkaElem7.Text) / decimal.Parse(txtTeika.Text) * 100).ToString();
                        //少数第2位で四捨五入する。
                        txtSiireRitu.Text = decimal.Parse(txtSiireRitu.Text).ToString("0.0");
                    }
                }

            }

            //単価が空白の場合スキップ
            if (txtTankaElem5.Text != "")
            {
                //単価が0ではない場合
                if (decimal.Parse(txtTankaElem5.Text) != 0)
                {
                    //直近仕入単価が空白だった場合は、計算をSKIPする。
                    if (txtCyokkinSiire.Text != "")
                    {
                        txtCyokkinSiireRituA.Text = ((decimal.Parse(txtTankaElem5.Text) - decimal.Parse(txtCyokkinSiire.Text)) / decimal.Parse(txtTankaElem5.Text) * 100).ToString();

                        //少数第2位で四捨五入する。
                        txtCyokkinSiireRituA.Text = decimal.Parse(txtCyokkinSiireRituA.Text).ToString("0.0");
                    }

                    //マスタ仕入単価が空白だった場合は計算をSKIPする。
                    if (txtMasterSiire.Text != "")
                    {
                        txtMasterSiireRituA.Text = ((decimal.Parse(txtTankaElem5.Text) - decimal.Parse(txtMasterSiire.Text)) / decimal.Parse(txtTankaElem5.Text) * 100).ToString();

                        //少数第2位で四捨五入する。
                        txtMasterSiireRituA.Text = decimal.Parse(txtMasterSiireRituA.Text).ToString("0.0");
                    }
                    
                }
            }
        }

        //取引先の端数区分を得る     0：切捨て　1：四捨五入　2：切上
        private int GetTokuisakiHasuSyori(string TokuisakiCd)
        {
            if (string.IsNullOrWhiteSpace(TokuisakiCd))
            {
                return 0;
            }
            
            //データ取得用テーブルを初期化
            DataTable dtSetCd;

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = " SELECT 明細行円以下計算区分 FROM 取引先 WHERE 取引先コード= '" + TokuisakiCd + "'";

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count > 0)
                {
                    return int.Parse(dtSetCd.Rows[0]["明細行円以下計算区分"].ToString());
                }

                return 0;

            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //グループボックス内にいる場合
                if (this.Parent is GroupBox)
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return 0;
                }
                else
                {
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return 0;
                }
            }
        }

        /// <summary>
        /// txtJucyuNoElem2_KeyDown
        /// 注文番号用キー入力判定
        /// </summary>
        private void txtJucyuNoElem2_KeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.F9:
                    //受注残確認を開く
                    this.setJyucyuZanKakunin();
                    break;
                case Keys.Enter:
                    if (!string.IsNullOrWhiteSpace(txtJucyuNoElem2.Text))
                    {
                        SendKeys.Send("{TAB}");
                    }
                    break;
                default:
                    break;
            }
        }

        //受注残確認フォームを開く。
        private void setJyucyuZanKakunin()
        {
            //親フォームのコントロールを取得する。
            A0020_UriageInput C_uriageInput = (A0020_UriageInput)this.Parent;

            //コードが空欄の場合は処理終了。
            if (string.IsNullOrWhiteSpace(C_uriageInput.labelSet_txtCD.CodeTxtText))
            {
                return;
            }

            //受注残確認フォームを開く処理
            int intFrmKind = 0020;

            //D0360_JuchuzanKakunin jucyuzankakunin = new D0360_JuchuzanKakunin(this);
            D0360_JuchuzanKakunin jucyuzankakunin = new D0360_JuchuzanKakunin(C_uriageInput, btbTokuiCd.Text, txtJucyuNoElem2);

            jucyuzankakunin.ShowDialog();
            if (!string.IsNullOrWhiteSpace(txtJucyuNoElem2.Text))
            {
                //SendKeys.Send("{TAB}");
                //txtSuuryoElem4.Focus();
            }
        }

        private void txtSuuryoElem4_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                default:
                    break;
            }
        }
    }
}
