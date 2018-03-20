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
using KATO.Common.Ctl;
using KATO.Business.M1110_Chubunrui;
using KATO.Form.D0360_JuchuzanKakunin;

namespace KATO.Form.A0030_ShireInput
{
    public partial class BaseViewDataGroup : UserControl
    {
        //仕入入力の伝票番号から表示した注文Noを確保
        public string strShireChuNo = "";

        //受注単価用
        string strJuchuTanka = "";

        public BaseViewDataGroup()
        {
            InitializeComponent();
        }

        ///<summary>
        ///setData
        ///項目にデータを入れる
        ///</summary>
        public void setData(List<string> lstData)
        {
            //行番号
            txtNo.Text = (int.Parse(lstData[0].ToString()) - 1).ToString();
            //発注番号
            txtChumonNo.Text = lstData[1];
            //商品コード
            txtShohinCd.Text = lstData[2];
            //メーカーコード
            txtMakerCd.Text = lstData[3];
            //大分類コード
            txtDaibunCd.Text = lstData[4];
            //中分類コード
            txtChubunCd.Text = lstData[5];
            //C1
            txtC1.Text = lstData[6];
            //C2
            txtC2.Text = lstData[7];
            //C3
            txtC3.Text = lstData[8];
            //C4
            txtC4.Text = lstData[9];
            //C5
            txtC5.Text = lstData[10];
            //C6
            txtC6.Text = lstData[11];
            //品名
            txtHin.Text = lstData[12];

            //数量
            txtSu.Text = string.Format("{0:#}", lstData[13]);
            //単価(仕入単価)
            txtTanka.Text = string.Format("{0:#,#.00}", double.Parse(lstData[14]));
            //単価確保（発注原価チェック用）
            txtTankaSub.Text = string.Format("{0:#,#.00}", double.Parse(lstData[14]));

            //単価のサブの入れものに追加(仕入率計算時に[.]があるとエラーを起こすため)
            txtTankaSub.Visible = true;
            txtTankaSub.Text = string.Format("{0:#}", lstData[14]);
            txtTankaSub.Visible = false;

            //金額(仕入金額)
            txtKin.Text = string.Format("{0:#,#}", lstData[15]);
            //備考
            txtBiko.Text = lstData[16];
            //入庫倉庫
            labelSet_Eigyosho.CodeTxtText = lstData[17];

            //直近単価、マスタ単価、定価、得意先
            setAnotherData();
            
            //0パディング等の表示情報の修正
            txtSu.updPriceMethod();
            txtTanka.updPriceMethod();
            txtKin.updPriceMethod();
            txtTankaSub.updPriceMethod();
            txtChokinTanka.updPriceMethod();

            //単価か定価の値が0の場合
            if (txtTanka.Text == "0" || txtTeka.Text == "0")
            {
                txtShireritsu.Text = "";
            }
            else
            {
                //仕入率の取得
                txtShireritsu.Text = ((decimal.Parse(txtTanka.Text) / decimal.Parse(txtTeka.Text)) * 100).ToString();
                //小数点第一位まで表示
                txtShireritsu.Text = StringUtl.updShishagonyu(txtShireritsu.Text, 1);
            }

            //仕入入力で表示した証明を残す
            strShireChuNo = txtChumonNo.Text;

            //0パディング等の表示情報の修正
            txtShireritsu.updPriceMethod();
            txtBiko.Focus();

            setGokeiKesan();
        }

        ///<summary>
        ///setAnotherData
        ///そのほかのデータを入れる
        ///</summary>
        private void setAnotherData()
        {
            //商品コードの中身がない場合
            if (!txtShohinCd.blIsEmpty())
            {
                return;
            }

            //直近単価の取得
            getChokinTanka();
            //マスタ単価と定価の取得
            getMasterTankaTeka();
            //得意先の取得
            getTokuisaki();
        }

        ///<summary>
        ///getChokinTanka
        ///直近単価の取得
        ///</summary>
        private void getChokinTanka()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_ShireHeader_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, txtShohinCd.Text);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //空チェック
                if (dtSetCd_B.Rows.Count > 0)
                {
                    //直近単価に入れる
                    txtChokinTanka.Text = string.Format("{0:#,#.00}", dtSetCd_B.Rows[0][1]);
                }
                else
                {
                    txtChokinTanka.Text = "";
                }

                return;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getMasterTankaTeka
        ///マスタ単価と定価の取得
        ///</summary>
        private void getMasterTankaTeka()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Shohin_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, txtShohinCd.Text);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //データがある場合
                if (dtSetCd_B.Rows.Count > 0)
                {
                    //仕入単価の値がなかった場合
                    if (dtSetCd_B.Rows[0]["仕入単価"].ToString() == "0.0000")
                    {
                        //マスター単価に入れる
                        txtMasterTanka.Text = "0";
                        txtTankaSub.Text = "0";
                    }
                    else
                    {
                        //マスター単価に入れる
                        txtMasterTanka.Text = string.Format("{0:#,0.00}", dtSetCd_B.Rows[0]["仕入単価"]);
                        txtTankaSub.Text = txtMasterTanka.Text;
                    }

                    //定価の値がなかった場合
                    if (dtSetCd_B.Rows[0]["定価"].ToString() == "0.0000")
                    {
                        txtTeka.Text = "0";
                        txtTekaSub.Text = "0";
                    }
                    else
                    {
                        //定価を入れる
                        txtTeka.Text = string.Format("{0:#,#}", dtSetCd_B.Rows[0]["定価"]);

                        //定価のサブの入れものに追加(仕入率計算時に[.]があるとエラーを起こすため)
                        txtTekaSub.Visible = true;
                        txtTekaSub.Text = string.Format("{0:#}", dtSetCd_B.Rows[0]["定価"]);
                        txtTekaSub.Visible = false;
                    }
                }
                else
                {
                    txtMasterTanka.Text = "0";
                    txtTankaSub.Text = "0";
                    txtTeka.Text = "0";
                    txtTekaSub.Text = "0";
                }

                return;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getTokuisaki
        ///得意先の取得
        ///</summary>
        private void getTokuisaki()
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Juchu_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, txtChumonNo.Text);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //得意先が存在する場合
                if (dtSetCd_B.Rows.Count > 0)
                {
                    //得意先に入れる
                    txtTokuisaki.Text = dtSetCd_B.Rows[0]["得意先名称"].ToString().Trim(' ');
                }
                else
                {
                    //得意先に入れる
                    txtTokuisaki.Text = "";
                }

                return;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///txtChumonNo_Leave
        ///注文Noから離れた時
        ///</summary>
        private void txtChumonNo_Leave(object sender, EventArgs e)
        {
            //仕入入力で表示した注文Noと同じではない場合
            if (strShireChuNo != txtChumonNo.Text)
            {
                //親画面の情報取得
                A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

                try
                {
                    //発注番号が既にある場合
                    if (shireinput.judHachuNoOverlap(txtChumonNo.Text))
                    {
                        //発注データが既に仕入済みであるということを伝えるメッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, "仕入済の発注データです！！", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        txtNo.Clear();
                        txtChumonNo.Clear();
                        txtHin.Clear();
                        txtSu.Clear();
                        txtTanka.Clear();
                        txtKin.Clear();
                        txtBiko.Clear();
                        labelSet_Eigyosho.codeTxt.Clear();
                        labelSet_Eigyosho.chkTxtEigyousho();
                        txtTeka.Clear();
                        //txtTeka.Text = "0";
                        txtChokinTanka.Clear();
                        //txtChokinTanka.Text = "0";
                        //txtChokinTanka.updPriceMethod();
                        txtMasterTanka.Clear();
                        //txtMasterTanka.Text = "0";
                        //txtMasterTanka.updPriceMethod();
                        txtJuchuNo.Clear();
                        txtJuchuTanka.Clear();
                        txtTankaSub.Clear();

                        txtChumonNo.Focus();

                        strShireChuNo = "";
                        txtHin.TabStop = true;
                        txtHin.Enabled = true;
                        setGokeiKesan();
                        return;
                    }
                    else
                    {
                        getData();
                    }
                }
                catch (Exception ex)
                {
                    //データロギング
                    new CommonException(ex);
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }
            else if(txtChumonNo.blIsEmpty() == false)
            {
                txtNo.Clear();
                txtChumonNo.Clear();
                txtHin.Clear();
                txtSu.Clear();
                txtTanka.Clear();
                txtKin.Clear();
                txtBiko.Clear();
                labelSet_Eigyosho.codeTxt.Clear();
                labelSet_Eigyosho.chkTxtEigyousho();
                txtTeka.Clear();
                txtChokinTanka.Clear();
                //txtChokinTanka.Text = "0";
                //txtChokinTanka.updPriceMethod();
                txtMasterTanka.Clear();
                //txtMasterTanka.Text = "0";
                //txtMasterTanka.updPriceMethod();
                txtJuchuNo.Clear();
                txtJuchuTanka.Clear();
                txtTankaSub.Clear();

                strShireChuNo = "";
                txtHin.TabStop = true;
                txtHin.Enabled = true;

                setGokeiKesan();
                return;
            }
        }

        ///<summary>
        ///getData
        ///注文Noからデータを取得
        ///</summary>
        private void getData()
        {
            //品名確保
            string strHinmei;

            //親画面の情報取得
            A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

            //注文Noの記入がない場合
            if (!StringUtl.blIsEmpty(txtChumonNo.Text))
            {
                txtNo.Clear();
                txtChumonNo.Clear();
                txtHin.Clear();
                txtSu.Clear();
                txtTanka.Clear();
                txtKin.Clear();
                txtBiko.Clear();
                labelSet_Eigyosho.codeTxt.Clear();
                labelSet_Eigyosho.chkTxtEigyousho();
                txtTeka.Clear();
                txtChokinTanka.Clear();
                txtMasterTanka.Clear();
                txtJuchuNo.Clear();
                txtJuchuTanka.Clear();
                txtTankaSub.Clear();
                txtShireritsu.Clear();
                txtTokuisaki.Clear();

                //フォーカスしている列の判定
                if (shireinput.shotCnt == 1)
                {
                    shireinput.txtJuchu1.Clear();
                    shireinput.txtTanka1.Clear();
                }
                else if (shireinput.shotCnt == 2)
                {
                    shireinput.txtJuchu2.Clear();
                    shireinput.txtTanka2.Clear();
                }
                else if (shireinput.shotCnt == 3)
                {
                    shireinput.txtJuchu3.Clear();
                    shireinput.txtTanka3.Clear();
                }
                else if (shireinput.shotCnt == 4)
                {
                    shireinput.txtJuchu4.Clear();
                    shireinput.txtTanka4.Clear();
                }
                else if (shireinput.shotCnt == 5)
                {
                    shireinput.txtJuchu5.Clear();
                    shireinput.txtTanka5.Clear();
                }

                strShireChuNo = "";
                txtHin.TabStop = true;
                txtHin.Enabled = true;

                setGokeiKesan();
                return;
            }

            //SQLファイルのパスとファイル名を入れる用
            //List<string> lstSQLHeader = new List<string>();
            //List<string> lstSQLCount = new List<string>();
            List<string> lstSQLHachu = new List<string>();
            List<string> lstSQLJuchuNo = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            //lstSQLHeader.Add("Common");
            //lstSQLHeader.Add("C_LIST_ShireHeader_SELECT");

            //lstSQLCount.Add("A0030_ShireInput");
            //lstSQLCount.Add("ShireInput_ShireMesai_Count_SELECT");

            lstSQLHachu.Add("A0030_ShireInput");
            lstSQLHachu.Add("ShireInput_gb_HachuData_SELECT");

            lstSQLJuchuNo.Add("A0030_ShireInput");
            lstSQLJuchuNo.Add("ShireInput_JuchuNo_SELECT");

            //SQL実行時に取り出したデータを入れる用
            //DataTable dtSetCd_B_Header = new DataTable();
            //DataTable dtSetCd_B_Count = new DataTable();
            DataTable dtSetCd_B_Hachu = new DataTable();
            DataTable dtSetCd_B_JuchuNo = new DataTable();

            //SQL実行時に取り出したデータを入れる用(受注得意先用)
            DataTable dtSetCdTokuisaki_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //詳細データ
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQLHachu);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, txtChumonNo.Text);

                //SQL接続後、該当データを取得
                dtSetCd_B_Hachu = dbconnective.ReadSql(strSQLInput);

                //データが1件以上ある場合
                if (dtSetCd_B_Hachu.Rows.Count > 0)
                {
                    //行数分ループ
                    for (int intCnt = 0; intCnt < dtSetCd_B_Hachu.Rows.Count; intCnt++)
                    {
                        //取り出したデータの仕入先コードと仕入入力の仕入先コードが違う場合
                        if (dtSetCd_B_Hachu.Rows[intCnt]["仕入先コード"].ToString() != shireinput.txtCD.Text &&
                            shireinput.txtCD.Text != "")
                        {
                            //発注データが存在しないということを伝えるメッセージ（OK）
                            BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, "指定した取引先の発注データではありません！！", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();

                            txtNo.Clear();
                            txtChumonNo.Clear();
                            txtHin.Clear();
                            txtSu.Clear();
                            txtTanka.Clear();
                            txtKin.Clear();
                            txtBiko.Clear();
                            labelSet_Eigyosho.codeTxt.Clear();
                            labelSet_Eigyosho.chkTxtEigyousho();
                            txtTeka.Clear();
                            //txtTeka.Text = "0";
                            txtChokinTanka.Clear();
                            //txtChokinTanka.Text = "0";
                            //txtChokinTanka.updPriceMethod();
                            txtMasterTanka.Clear();
                            //txtMasterTanka.Text = "0";
                            //txtMasterTanka.updPriceMethod();
                            txtJuchuNo.Clear();
                            txtJuchuTanka.Clear();
                            txtTankaSub.Clear();

                            txtChumonNo.Focus();

                            strShireChuNo = "";
                            txtHin.TabStop = true;
                            txtHin.Enabled = true;
                            setGokeiKesan();
                            return;
                        }

                        //発注フラグがある場合
                        if (dtSetCd_B_Hachu.Rows[intCnt]["発注フラグ"].ToString() == "1")
                        {
                            //仕入済み発注数が発注数量以上の場合
                            if (decimal.Parse(dtSetCd_B_Hachu.Rows[intCnt]["仕入済数量"].ToString()) >= decimal.Parse(dtSetCd_B_Hachu.Rows[intCnt]["発注数量"].ToString()))
                            {
                                //発注データが既に仕入済みであるということを伝えるメッセージ（OK）
                                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, "仕入済の発注データです！！", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                                basemessagebox.ShowDialog();

                                txtNo.Clear();
                                txtChumonNo.Clear();
                                txtHin.Clear();
                                txtSu.Clear();
                                txtTanka.Clear();
                                txtKin.Clear();
                                txtBiko.Clear();
                                labelSet_Eigyosho.codeTxt.Clear();
                                labelSet_Eigyosho.chkTxtEigyousho();
                                txtTeka.Clear();
                                //txtTeka.Text = "0";
                                txtChokinTanka.Clear();
                                //txtChokinTanka.Text = "0";
                                //txtChokinTanka.updPriceMethod();
                                txtMasterTanka.Clear();
                                //txtMasterTanka.Text = "0";
                                //txtMasterTanka.updPriceMethod();
                                txtJuchuNo.Clear();
                                txtJuchuTanka.Clear();
                                txtTankaSub.Clear();
                                txtTokuisaki.Clear();
                                txtChumonNo.Focus();

                                strShireChuNo = null;
                                txtHin.TabStop = true;
                                txtHin.Enabled = true;
                                return;
                            }
                            else
                            {
                                string strData = Math.Floor(decimal.Parse(dtSetCd_B_Hachu.Rows[intCnt]["仕入済数量"].ToString())).ToString("#,0");

                                //発注データが存在しないということを伝えるメッセージ（OK）
                                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent,
                                                                                   CommonTeisu.TEXT_ERROR,
                                                                                   Math.Floor(decimal.Parse(dtSetCd_B_Hachu.Rows[intCnt]["仕入済数量"].ToString())).ToString("#,0") + "個が仕入済みです！！",
                                                                                   CommonTeisu.BTN_OK,
                                                                                   CommonTeisu.DIAG_ERROR
                                                                                   );
                                basemessagebox.ShowDialog();
                            }
                        }

                        //仕入先コードがある場合
                        if (dtSetCd_B_Hachu.Rows[intCnt]["仕入先コード"].ToString() != "")
                        {
                            shireinput.txtCD.Text = dtSetCd_B_Hachu.Rows[intCnt]["仕入先コード"].ToString();
                            shireinput.setShireData();
                        }

                        //行番号が99の場合
                        if (dtSetCd_B_Hachu.Rows[intCnt]["行番号"].ToString() == "99")
                        {
                            //運賃の処理があったがなし
                        }

                        //受注番号がある場合
                        if (dtSetCd_B_Hachu.Rows[intCnt]["受注番号"].ToString() != "0" && dtSetCd_B_Hachu.Rows[intCnt]["受注番号"].ToString() != "")
                        {
                            //詳細データ
                            //SQLファイルのパス取得
                            strSQLInput = opensql.setOpenSQL(lstSQLJuchuNo);

                            //パスがなければ返す
                            if (strSQLInput == "")
                            {
                                return;
                            }

                            //SQLファイルと該当コードでフォーマット
                            strSQLInput = string.Format(strSQLInput, dtSetCd_B_Hachu.Rows[intCnt]["受注番号"].ToString());

                            //SQL接続後、該当データを取得
                            dtSetCd_B_JuchuNo = dbconnective.ReadSql(strSQLInput);

                            //データが1件以上ある場合
                            if (dtSetCd_B_JuchuNo.Rows.Count > 0)
                            {
                                strJuchuTanka = decimal.Parse(dtSetCd_B_JuchuNo.Rows[0]["受注単価"].ToString()).ToString("0");

                                //受注単価が空の場合
                                if (strJuchuTanka == "")
                                {
                                    strJuchuTanka = "0";
                                }
                            }
                            else
                            {
                                strJuchuTanka = "0";
                            }
                        }
                        else
                        {
                            strJuchuTanka = "0";
                        }

                        //行数１の場合
                        if (shireinput.shotCnt == 1)
                        {
                            shireinput.gbData1.txtNo.Text = "0";
                            shireinput.gbData1.txtChumonNo.Text = dtSetCd_B_Hachu.Rows[intCnt]["発注番号"].ToString();
                            shireinput.txtJuchu1.Text = dtSetCd_B_Hachu.Rows[intCnt]["受注番号"].ToString();
                        }
                        //行数２の場合
                        else if (shireinput.shotCnt == 2)
                        {
                            shireinput.gbData2.txtNo.Text = "1";
                            shireinput.gbData2.txtChumonNo.Text = dtSetCd_B_Hachu.Rows[intCnt]["発注番号"].ToString();
                            shireinput.txtJuchu2.Text = dtSetCd_B_Hachu.Rows[intCnt]["受注番号"].ToString();
                        }
                        //行数３の場合
                        else if (shireinput.shotCnt == 3)
                        {
                            shireinput.gbData3.txtNo.Text = "2";
                            shireinput.gbData3.txtChumonNo.Text = dtSetCd_B_Hachu.Rows[intCnt]["発注番号"].ToString();
                            shireinput.txtJuchu3.Text = dtSetCd_B_Hachu.Rows[intCnt]["受注番号"].ToString();
                        }
                        //行数４の場合
                        else if (shireinput.shotCnt == 4)
                        {
                            shireinput.gbData4.txtNo.Text = "3";
                            shireinput.gbData4.txtChumonNo.Text = dtSetCd_B_Hachu.Rows[intCnt]["発注番号"].ToString();
                            shireinput.txtJuchu4.Text = dtSetCd_B_Hachu.Rows[intCnt]["受注番号"].ToString();
                        }
                        //行数５の場合
                        else if (shireinput.shotCnt == 5)
                        {
                            shireinput.gbData5.txtNo.Text = "4";
                            shireinput.gbData5.txtChumonNo.Text = dtSetCd_B_Hachu.Rows[intCnt]["発注番号"].ToString();
                            shireinput.txtJuchu5.Text = dtSetCd_B_Hachu.Rows[intCnt]["受注番号"].ToString();
                        }
                    }

                    //初期化
                    strHinmei = "";

                    //中分類のデータ確保
                    DataTable dtChubun = null;

                    //商品コードが存在する場合
                    if (StringUtl.blIsEmpty(dtSetCd_B_Hachu.Rows[0]["商品コード"].ToString()))
                    {
                        txtShohinCd.Text = dtSetCd_B_Hachu.Rows[0]["商品コード"].ToString();
                        setTxtShohinCd();
                    }

                    //メーカーコードが存在する場合
                    if (StringUtl.blIsEmpty(dtSetCd_B_Hachu.Rows[0]["メーカーコード"].ToString()))
                    {
                        txtMakerCd.Text = dtSetCd_B_Hachu.Rows[0]["メーカーコード"].ToString();
                    }

                    //大分類コードが存在する場合
                    if (StringUtl.blIsEmpty(dtSetCd_B_Hachu.Rows[0]["大分類コード"].ToString()))
                    {
                        txtDaibunCd.Text = dtSetCd_B_Hachu.Rows[0]["大分類コード"].ToString();
                    }

                    //中分類コードが存在する場合
                    if (StringUtl.blIsEmpty(dtSetCd_B_Hachu.Rows[0]["中分類コード"].ToString()))
                    {
                        txtChubunCd.Text = dtSetCd_B_Hachu.Rows[0]["中分類コード"].ToString();
                    }

                    //品名の確保（メーカー名部分）
                    strHinmei = dtSetCd_B_Hachu.Rows[0]["メーカー名"].ToString().Trim(' ');

                    //中分類のビジネス層インスタンス生成
                    M1110_Chubunrui_B chubunruiB = new M1110_Chubunrui_B();
                    //中分類のコードと名前を確保
                    dtChubun = chubunruiB.getTxtChubunruiLeave(dtSetCd_B_Hachu.Rows[0]["大分類コード"].ToString(), dtSetCd_B_Hachu.Rows[0]["中分類コード"].ToString());

                    if (dtChubun != null && dtChubun.Rows.Count > 0) {
                        strHinmei = strHinmei + " " + dtChubun.Rows[0]["中分類名"];
                    }

                    //Ｃ１が存在する場合
                    if (StringUtl.blIsEmpty(dtSetCd_B_Hachu.Rows[0]["Ｃ１"].ToString()))
                    {
                        strHinmei = strHinmei + dtSetCd_B_Hachu.Rows[0]["Ｃ１"].ToString().Trim(' ');
                        txtC1.Text = dtSetCd_B_Hachu.Rows[0]["Ｃ１"].ToString();
                    }
                    //Ｃ２が存在する場合
                    if (StringUtl.blIsEmpty(dtSetCd_B_Hachu.Rows[0]["Ｃ２"].ToString()))
                    {
                        strHinmei = strHinmei + dtSetCd_B_Hachu.Rows[0]["Ｃ２"].ToString().Trim(' ');
                        txtC2.Text = dtSetCd_B_Hachu.Rows[0]["Ｃ２"].ToString();
                    }
                    //Ｃ３が存在する場合
                    if (StringUtl.blIsEmpty(dtSetCd_B_Hachu.Rows[0]["Ｃ３"].ToString()))
                    {
                        strHinmei = strHinmei + dtSetCd_B_Hachu.Rows[0]["Ｃ３"].ToString().Trim(' ');
                        txtC3.Text = dtSetCd_B_Hachu.Rows[0]["Ｃ３"].ToString();
                    }
                    //Ｃ４が存在する場合
                    if (StringUtl.blIsEmpty(dtSetCd_B_Hachu.Rows[0]["Ｃ４"].ToString()))
                    {
                        strHinmei = strHinmei + dtSetCd_B_Hachu.Rows[0]["Ｃ４"].ToString().Trim(' ');
                        txtC4.Text = dtSetCd_B_Hachu.Rows[0]["Ｃ４"].ToString();
                    }
                    //Ｃ５が存在する場合
                    if (StringUtl.blIsEmpty(dtSetCd_B_Hachu.Rows[0]["Ｃ５"].ToString()))
                    {
                        strHinmei = strHinmei + dtSetCd_B_Hachu.Rows[0]["Ｃ５"].ToString().Trim(' ');
                        txtC5.Text = dtSetCd_B_Hachu.Rows[0]["Ｃ５"].ToString();
                    }
                    //Ｃ６が存在する場合
                    if (StringUtl.blIsEmpty(dtSetCd_B_Hachu.Rows[0]["Ｃ６"].ToString()))
                    {
                        strHinmei = strHinmei + dtSetCd_B_Hachu.Rows[0]["Ｃ６"].ToString().Trim(' ');
                        txtC6.Text = dtSetCd_B_Hachu.Rows[0]["Ｃ６"].ToString();
                    }

                    txtHin.Text = strHinmei;
                    txtHin.TabStop = false;
                    txtHin.Enabled = false;

                    //ActiveControlがある場合
                    if (ActiveControl != null)
                    {
                        //フォーカスがtxtHinの場合
                        if (ActiveControl.Name == "txtHin")
                        {
                            SendKeys.Send("{TAB}");
                        }
                    }

                    //発注数量から仕入済数量を引く
                    txtSu.Text = ((int.Parse(string.Format("{0:0.#}", double.Parse(dtSetCd_B_Hachu.Rows[0]["発注数量"].ToString())))) - (double.Parse(string.Format("{0:0.#}", double.Parse(dtSetCd_B_Hachu.Rows[0]["仕入済数量"].ToString()))))).ToString();
                    txtSu.updPriceMethod();

                    //文字色を黒にする
                    txtSu.ForeColor = Color.Black;

                    //マイナスがついていた場合
                    if (txtSu.Text.StartsWith("-"))
                    {
                        txtSu.ForeColor = Color.Red;
                    }

                    //数量が変更になったことによる処理
                    setTxtSuChange();

                    txtTanka.Text = string.Format("{0:0.00}", double.Parse(dtSetCd_B_Hachu.Rows[0]["発注単価"].ToString()));
                    txtTanka.updPriceMethod();
                    //単価が変更になったことによる処理
                    setTxtTankaChange();

                    txtBiko.Text = dtSetCd_B_Hachu.Rows[0]["注番"].ToString();

                    labelSet_Eigyosho.CodeTxtText = dtSetCd_B_Hachu.Rows[0]["営業所コード"].ToString();

                    txtJuchuNo.Text = dtSetCd_B_Hachu.Rows[0]["受注番号"].ToString();

                    //仕入入力画面のコードが8888か5555の場合
                    if (shireinput.txtCD.ToString() == "8888" || shireinput.txtCD.ToString() == "8888")
                    {
                        shireinput.txtShireNameView.Text = dtSetCd_B_Hachu.Rows[0]["仕入先名称"].ToString();
                    }

                    //受注番号が0ではない場合
                    if (dtSetCd_B_Hachu.Rows[0]["受注番号"].ToString() != "0")
                    {
                        //No.によって何番の仕入入力画面の受注番号項目に記入するか
                        if (int.Parse(this.Tag.ToString()) == 1)
                        {
                            shireinput.txtJuchu1.Text = dtSetCd_B_Hachu.Rows[0]["受注番号"].ToString();

                            dtSetCdTokuisaki_B = getJuchuTokuisaki(shireinput.txtJuchu1.Text);
                        }
                        if (int.Parse(this.Tag.ToString()) == 2)
                        {
                            shireinput.txtJuchu2.Text = dtSetCd_B_Hachu.Rows[0]["受注番号"].ToString();

                            dtSetCdTokuisaki_B = getJuchuTokuisaki(shireinput.txtJuchu2.Text);
                        }
                        if (int.Parse(this.Tag.ToString()) == 3)
                        {
                            shireinput.txtJuchu3.Text = dtSetCd_B_Hachu.Rows[0]["受注番号"].ToString();

                            dtSetCdTokuisaki_B = getJuchuTokuisaki(shireinput.txtJuchu3.Text);
                        }
                        if (int.Parse(this.Tag.ToString()) == 4)
                        {
                            shireinput.txtJuchu4.Text = dtSetCd_B_Hachu.Rows[0]["受注番号"].ToString();

                            dtSetCdTokuisaki_B = getJuchuTokuisaki(shireinput.txtJuchu4.Text);
                        }
                        if (int.Parse(this.Tag.ToString()) == 5)
                        {
                            shireinput.txtJuchu5.Text = dtSetCd_B_Hachu.Rows[0]["受注番号"].ToString();

                            dtSetCdTokuisaki_B = getJuchuTokuisaki(shireinput.txtJuchu5.Text);
                        }

                        //dtSetCdTokuisaki_Bにデータがある場合
                        if (dtSetCdTokuisaki_B.Rows.Count > 0)
                        {
                            txtTokuisaki.Text = dtSetCdTokuisaki_B.Rows[0]["得意先名称"].ToString();
                        }
                    }

                    setGokeiKesan();
                }
                else
                {
                    //発注データが存在しないということを伝えるメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, "発注データが存在しません！！", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    //項目削除
                    delText();

                    txtChumonNo.Focus();
                    return;
                }

                //初期化 
                strSQLInput = "";

                return;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///setTxtShohinCd
        ///商品コード項目が変更になった場合
        ///</summary>
        private void setTxtShohinCd()
        {
            //親画面の情報取得
            A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

            //直近仕入単価の取得
            txtChokinTanka.Text = getChokinShireTanka(txtShohinCd.Text);
            
            //0.00の場合
            if (txtChokinTanka.Text == "0.00")
            {
                txtChokinTanka.Text = "0";
            }

            txtChokinTanka.updPriceMethod();
            //マスター単価の取得
            txtMasterTanka.Text = getGyomuShireTanka(txtShohinCd.Text);

            //0.00の場合
            if (txtMasterTanka.Text == "0.00")
            {
                txtMasterTanka.Text = "0";
            }

            txtMasterTanka.updPriceMethod();
            //定価の取得
            txtTeka.Text = getMasterTeka(txtShohinCd.Text);
            txtTeka.updPriceMethod();
        }

        ///<summary>
        ///setTxtSuChange
        ///数量項目が変更になった場合
        ///</summary>
        private void setTxtSuChange()
        {
            //親画面の情報取得
            A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

            int intHasu = 0;

            //数量項目に記入がない場合
            if (!StringUtl.blIsEmpty(txtSu.Text))
            {
                return;
            }
            //単価項目に記入がない場合
            if (!StringUtl.blIsEmpty(txtTanka.Text))
            {
                return;
            }

            //コードがない場合
            if (shireinput.txtCD.blIsEmpty() == false)
            {
                txtKin.Text = "";
                return;
            }

            //DBの取引先から該当データの取得
            intHasu = getMesaiKesankbn(shireinput.txtCD.Text);

            txtKin.Text = (double.Parse(string.Format("{0:0.#}", double.Parse(txtSu.Text))) * (double.Parse(string.Format("{0:0.#}", double.Parse(txtTanka.Text))))).ToString();
            txtKin.updPriceMethod();

            //金額が-1になった場合
            if (txtKin.Text == "-1")
            {
                txtKin.Text = "0";
            }

            setGokeiKesan();
        }

        ///<summary>
        ///setTxtTankaChange
        ///単価項目が変更になった場合
        ///</summary>
        private void setTxtTankaChange()
        {
            //親画面の情報取得
            A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

            int intHasu = 0;

            //数量項目に記入がない場合
            if (!StringUtl.blIsEmpty(txtSu.Text))
            {
                return;
            }
            //単価項目に記入がない場合
            if (!StringUtl.blIsEmpty(txtTanka.Text))
            {
                return;
            }

            //コードがない場合
            if (shireinput.txtCD.blIsEmpty() == false)
            {
                txtKin.Text = "";
                return;
            }

            //DBの取引先から該当データの取得
            intHasu = getMesaiKesankbn(shireinput.txtCD.Text);

            txtKin.Text = (setRound((double.Parse(string.Format("{0:0.#}", double.Parse(txtSu.Text))) * (double.Parse(string.Format("{0:0.#}", double.Parse(txtTanka.Text))))), 0, intHasu)).ToString();
            txtKin.updPriceMethod();

            //金額が-1になった場合
            if (txtKin.Text == "-1")
            {
                txtKin.Text = "0";
            }

            setGokeiKesan();

            //定価の項目に記入がある場合
            if (StringUtl.blIsEmpty(txtTeka.Text))
            {
                decimal decTeka = decimal.Parse(txtTeka.Text);

                //定価の数値が0以外の場合
                if (txtTeka.Text != "0")
                {
                    txtShireritsu.Text = ((decimal.Parse(txtTanka.Text) / decimal.Parse(txtTeka.Text)) * 100).ToString();
                    txtShireritsu.Text = StringUtl.updShishagonyu(txtShireritsu.Text, 1);
                }
            }
        }

        ///<summary>
        ///getChokinShireTanka
        ///直近仕入単価の取得
        ///</summary>
        private string getChokinShireTanka(string strCd)
        {
            string strChokinShireTanka = "0";

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_gb_ChokinShireTanka_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return strChokinShireTanka;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strCd);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd_B != null && dtSetCd_B.Rows.Count > 0) {
                    strChokinShireTanka = string.Format("{0:0.00}", double.Parse(dtSetCd_B.Rows[0]["仕入単価"].ToString()));
                }
                return strChokinShireTanka;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return strChokinShireTanka;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getGyomuShireTanka
        ///マスター単価の取得
        ///</summary>
        private string getGyomuShireTanka(string strCd)
        {
            string strChokinShireTanka = "0";

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Shohin_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return strChokinShireTanka;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strCd);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //データがある場合
                if (dtSetCd_B.Rows.Count > 0)
                {
                    strChokinShireTanka = string.Format("{0:0.00}", double.Parse(dtSetCd_B.Rows[0]["仕入単価"].ToString()));
                }
                else
                {
                    strChokinShireTanka = "";
                }

                return strChokinShireTanka;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return strChokinShireTanka;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getMasterTeka
        ///定価の取得
        ///</summary>
        private string getMasterTeka(string strCd)
        {
            string strMasterTeka = "";

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Shohin_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return strMasterTeka;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strCd);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //データがある場合
                if (dtSetCd_B.Rows.Count > 0)
                {
                    strMasterTeka = string.Format("{0:0.#}", double.Parse(dtSetCd_B.Rows[0]["定価"].ToString()));
                }
                else
                {
                    strMasterTeka = "";
                }

                return strMasterTeka;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return strMasterTeka;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getMesaiKesankbn
        ///明細行円以下計算区分をDBの取引先から取得
        ///</summary>
        private int getMesaiKesankbn(string strCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //取得データの確保
            int intHasu = 0;

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Torihikisaki_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return intHasu;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strCd);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                intHasu = int.Parse(dtSetCd_B.Rows[0]["明細行円以下計算区分"].ToString());

                return intHasu;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return intHasu;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///txtSu_Leave
        ///数量項目から離れた時
        ///</summary>
        private void txtSu_Leave(object sender, EventArgs e)
        {
            //親画面の情報取得
            A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

            //端数区分用
            int intHasu;

            //取引先データの確保用
            DataTable dtSetCd_B = new DataTable();

            //仕入入力画面のコード、数量、単価に記入がない場合
            if (!StringUtl.blIsEmpty(shireinput.txtCD.ToString()) || !StringUtl.blIsEmpty(txtSu.Text) || !StringUtl.blIsEmpty(txtTanka.Text))
            {
                return;
            }

            //取引先のデータの取得
            dtSetCd_B = getTorihikisaki(shireinput.txtCD.Text);

            //データが1つ以上ある場合
            if (dtSetCd_B.Rows.Count > 0)
            {   
                //端数区分確保
                intHasu = int.Parse(dtSetCd_B.Rows[0]["明細行円以下計算区分"].ToString());

                //数量と単価、四捨五入による計算、金額に記入
                txtKin.Text = (setRound((double.Parse(string.Format("{0:0.#}", double.Parse(txtSu.Text))) * (double.Parse(string.Format("{0:0.#}", double.Parse(txtTanka.Text))))), 0, intHasu)).ToString();
                txtKin.updPriceMethod();

                //金額が-1になった場合
                if (txtKin.Text == "-1")
                {
                    txtKin.Text = "0";
                }

                //合計計算
                setGokeiKesan();
            }
        }

        ///<summary>
        ///txtTanka_Leave
        ///単価項目から離れた時
        ///</summary>
        private void txtTanka_Leave(object sender, EventArgs e)
        {
            //親画面の情報取得
            A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

            int intHasu = 0;

            //取引先データの確保用
            DataTable dtSetCd_B = new DataTable();

            //仕入入力画面のコード、数量、単価に記入がない場合
            if (!StringUtl.blIsEmpty(shireinput.txtCD.ToString()) || !StringUtl.blIsEmpty(txtSu.Text) || !StringUtl.blIsEmpty(txtTanka.Text))
            {
                return;
            }

            //取引先のデータの取得
            dtSetCd_B = getTorihikisaki(shireinput.txtCD.Text);

            //データが1つ以上ある場合
            if (dtSetCd_B.Rows.Count > 0)
            {
                //端数区分確保
                intHasu = int.Parse(dtSetCd_B.Rows[0]["明細行円以下計算区分"].ToString());

                //数量と単価、四捨五入による計算、金額に記入
                txtKin.Text = (setRound((double.Parse(string.Format("{0:0.#}", double.Parse(txtSu.Text))) * (double.Parse(string.Format("{0:0.#}", double.Parse(txtTanka.Text))))), 0, intHasu)).ToString();
                txtKin.updPriceMethod();

                //金額が-1になった場合
                if (txtKin.Text == "-1")
                {
                    txtKin.Text = "0";
                }

                //定価の中身がある場合
                if (StringUtl.blIsEmpty(txtTeka.Text))
                {
                    //定価の中身が0以外の場合
                    if (txtTeka.Text != "0" && txtTeka.Text != "")
                    {
                        //単価と定価で計算、仕入率に記入
                        txtShireritsu.Text = (decimal.Parse(txtTanka.Text) / decimal.Parse(txtTeka.Text) * 100).ToString();
                        txtShireritsu.Text = StringUtl.updShishagonyu(txtShireritsu.Text, 1);
                    }
                }

                //合計計算
                setGokeiKesan();
            }

        }

        ///<summary>
        ///delText
        ///全てのテキストを白紙にする
        ///</summary>
        public void delText()
        {
            txtNo.Clear();
            txtChumonNo.Clear();
            txtHin.Clear();
            txtSu.Clear();
            txtTanka.Clear();
            txtKin.Clear();
            txtBiko.Clear();
            txtShohinCd.Clear();
            txtMakerCd.Clear();
            txtDaibunCd.Clear();
            txtChubunCd.Clear();
            txtC1.Clear();
            txtC2.Clear();
            txtC3.Clear();
            txtC4.Clear();
            txtC5.Clear();
            txtC6.Clear();
            txtTankaSub.Clear();
            txtTekaSub.Clear();
            txtJuchuNo.Clear();
            labelSet_Eigyosho.codeTxt.Clear();
            labelSet_Eigyosho.ValueLabelText = "";
            txtTeka.Clear();
            txtShireritsu.Clear();
            txtChokinTanka.Clear();
            txtMasterTanka.Clear();
            txtTokuisaki.Clear();
            txtHin.TabStop = true;
            txtHin.Enabled = true;
        }

        ///<summary>
        ///setRound
        ///四捨五入
        ///</summary>
        public double setRound(double dblData, int intKetaInput, int intMode)
        {
            //最後に足す数値を入れる用
            double dblAdd;

            //最後に足す桁数を入れる用
            int intKeta = 1;

            //forループカウント用
            int intCnt;

            //モードによって最後に足す数値を決める
            switch (intMode)
            {
                case 2:
                    dblAdd = 0.9;
                    break;
                case 0:
                    dblAdd = 0;
                    break;
                default:
                    dblAdd = 0.5;
                    break;
            }

            //桁数によって最後に追加する桁を決める
            if (intKetaInput > -1)
            {
                //入力された桁数分ループ
                for (intCnt = 1; intCnt <= intKetaInput; intCnt++)
                {
                    intKeta = intKeta * 10;
                }
            }
            else
            {
                //入力された桁数分ループ
                for (intCnt = 1; intCnt <= -intKetaInput; intCnt++)
                {
                    intKeta = intKeta / 10;
                }
            }

            //入力された数値が0以上の場合
            if (dblData > 0)
            {
                dblData = dblData * intKeta + dblAdd;
            }
            else
            {
                dblData = dblData * intKeta - dblAdd;
            }

            dblData = Math.Floor(dblData) / intKeta;

            return dblData;
        }

        ///<summary>
        ///setGokeiKesan
        ///合計計算
        ///</summary>
        public void setGokeiKesan()
        {
            //親画面の情報取得
            A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

            //消費税区分用
            int intZeikbn = 0;

            //消費税端数計算区分
            int intZeihasukbn = 0;

            //消費税計算区分
            decimal decZeikesankbn = 0;

            //消費税確保
            decimal decZei = 0;

            //消費税受け取り用のデータテーブル
            DataTable dtZei = new DataTable();

            //合計に入れる用
            decimal decGokei = 0;

            //税合計に入れる用
            decimal decZeigokei = 0;

            //仕入入力画面のコードに記入がない場合
            if (!StringUtl.blIsEmpty(shireinput.txtCD.Text))
            {
                return;
            }

            //合計、総合計、消費税
            shireinput.txtGokei.Clear();
            shireinput.txtSogokei.Clear();
            shireinput.txtShohizei.Clear();

            //forループカウント用
            int intCnt;

            //全グループ内の金額のdecimal変換できるか

            //tryParse用
            decimal decTry = 0;

            //1行目
            if (decimal.TryParse(shireinput.gbData1.txtKin.Text.Trim(), out decTry))
            {
                decGokei = decGokei + decimal.Parse(shireinput.gbData1.txtKin.Text.Trim());
            }

            //2行目
            if (decimal.TryParse(shireinput.gbData2.txtKin.Text.Trim(), out decTry))
            {
                decGokei = decGokei + decimal.Parse(shireinput.gbData2.txtKin.Text.Trim());
            }

            //3行目
            if (decimal.TryParse(shireinput.gbData3.txtKin.Text.Trim(), out decTry))
            {
                decGokei = decGokei + decimal.Parse(shireinput.gbData3.txtKin.Text.Trim());
            }

            //4行目
            if (decimal.TryParse(shireinput.gbData4.txtKin.Text.Trim(), out decTry))
            {
                decGokei = decGokei + decimal.Parse(shireinput.gbData4.txtKin.Text.Trim());
            }

            //5行目
            if (decimal.TryParse(shireinput.gbData5.txtKin.Text.Trim(), out decTry))
            {
                decGokei = decGokei + decimal.Parse(shireinput.gbData5.txtKin.Text.Trim());
            }

            //利益率の表示
            setRiekiritu(false);

            //運賃が記入されていない場合
            if (!StringUtl.blIsEmpty(shireinput.txtUnchin.Text)) {
                shireinput.txtUnchin.Text = "0";
            }

            decGokei = decimal.Round(decGokei, 2, MidpointRounding.AwayFromZero);

            //運賃を追加
            decGokei = decGokei + Decimal.Parse(shireinput.txtUnchin.Text);
                
            //合計に入れる
            shireinput.txtGokei.Text = decGokei.ToString();
            shireinput.txtGokei.updPriceMethod();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Torihikisaki_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, shireinput.txtCD.Text);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //データが1つ以上ある場合
                if (dtSetCd_B.Rows[0][0].ToString() != "")
                {
                    //消費税区分確保
                    intZeikbn = int.Parse(dtSetCd_B.Rows[0]["消費税区分"].ToString());

                    //消費税端数計算区分確保
                    intZeihasukbn = int.Parse(dtSetCd_B.Rows[0]["消費税端数計算区分"].ToString());

                    //消費税計算区分確保
                    decZeikesankbn = decimal.Parse(dtSetCd_B.Rows[0]["消費税計算区分"].ToString());

                    //消費税計算区分が2の場合
                    if (decZeikesankbn == 2)
                    {
                        //消費税を0
                        shireinput.txtShohizei.Text = "0";
                        //総合計を合計と同じ数値
                        shireinput.txtSogokei.Text = decGokei.ToString();
                        shireinput.txtSogokei.updPriceMethod();
                        //運賃が0円の場合
                        if (shireinput.txtUnchin.Text == "0")
                        {
                            shireinput.txtUnchin.Text = "";
                        }
                        return;
                    }

                    //消費税区分が1の場合
                    if (intZeikbn == 1)
                    {
                        //消費税を0
                        shireinput.txtShohizei.Text = "0";
                        //総合計を合計と同じ数値
                        shireinput.txtSogokei.Text = decGokei.ToString();
                        shireinput.txtSogokei.updPriceMethod();
                        //運賃が0円の場合
                        if (shireinput.txtUnchin.Text == "0")
                        {
                            shireinput.txtUnchin.Text = "";
                        }
                        return;
                    }

                    //仕入入力画面の年月日に記入がない場合
                    if (!StringUtl.blIsEmpty(shireinput.txtYMD.Text))
                    {
                        decZei = 0;
                    }
                    else
                    {
                        //消費税の確保
                        dtZei = getShohizei(shireinput.txtYMD.Text);

                        //データが一つ以上ある場合
                        if (dtZei.Rows.Count > 0)
                        {
                            decZei = decimal.Parse(dtZei.Rows[0]["消費税率"].ToString());
                        }
                    }

                    //税計算区分が0の場合
                    if (decZeikesankbn == 0)
                    {
                        //１行目
                        //金額無記入の場合
                        if (shireinput.gbData1.txtKin.Text == "")
                        {
                            shireinput.gbData1.txtKin.Text = "0";
                        }

                        if (shireinput.gbData1.txtKin.Text != "0")
                        {
                            //税端数区分で判断、金額から税合計を取得
                            switch (intZeihasukbn)
                            {
                                case 0:
                                    //金額と税率、四捨五入による計算（モード0）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData1.txtKin.Text) * decZei / 100).ToString()), 0, 0)).ToString());
                                    break;
                                case 1:
                                    //金額と税率、四捨五入による計算（モード1）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData1.txtKin.Text) * decZei / 100).ToString()), 0, 1)).ToString());
                                    break;
                                case 2:
                                    //金額と税率、四捨五入による計算（モード2）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData1.txtKin.Text) * decZei / 100).ToString()), 0, 2)).ToString());
                                    break;
                            }
                        }

                        //金額0の場合
                        if (shireinput.gbData2.txtKin.Text == "0")
                        {
                            shireinput.gbData2.txtKin.Text = "";
                        }

                        //２行目
                        //金額無記入の場合
                        if (shireinput.gbData2.txtKin.Text == "")
                        {
                            shireinput.gbData2.txtKin.Text = "0";
                        }

                        if (shireinput.gbData2.txtKin.Text != "0")
                        {
                            //税端数区分で判断、金額から税合計を取得
                            switch (intZeihasukbn)
                            {
                                case 0:
                                    //金額と税率、四捨五入による計算（モード0）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData2.txtKin.Text) * decZei / 100).ToString()), 0, 0)).ToString());
                                    break;
                                case 1:
                                    //金額と税率、四捨五入による計算（モード1）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData2.txtKin.Text) * decZei / 100).ToString()), 0, 1)).ToString());
                                    break;
                                case 2:
                                    //金額と税率、四捨五入による計算（モード2）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData2.txtKin.Text) * decZei / 100).ToString()), 0, 2)).ToString());
                                    break;
                            }
                        }

                        //金額0の場合
                        if (shireinput.gbData2.txtKin.Text == "0")
                        {
                            shireinput.gbData2.txtKin.Text = "";
                        }

                        //３行目
                        //金額無記入の場合
                        if (shireinput.gbData3.txtKin.Text == "")
                        {
                            shireinput.gbData3.txtKin.Text = "0";
                        }

                        if (shireinput.gbData3.txtKin.Text != "0")
                        {
                            //税端数区分で判断、金額から税合計を取得
                            switch (intZeihasukbn)
                            {
                                case 0:
                                    //金額と税率、四捨五入による計算（モード0）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData3.txtKin.Text) * decZei / 100).ToString()), 0, 0)).ToString());
                                    break;
                                case 1:
                                    //金額と税率、四捨五入による計算（モード1）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData3.txtKin.Text) * decZei / 100).ToString()), 0, 1)).ToString());
                                    break;
                                case 2:
                                    //金額と税率、四捨五入による計算（モード2）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData3.txtKin.Text) * decZei / 100).ToString()), 0, 2)).ToString());
                                    break;
                            }
                        }

                        //金額0の場合
                        if (shireinput.gbData3.txtKin.Text == "0")
                        {
                            shireinput.gbData3.txtKin.Text = "";
                        }

                        //４行目
                        //金額無記入の場合
                        if (shireinput.gbData4.txtKin.Text == "")
                        {
                            shireinput.gbData4.txtKin.Text = "0";
                        }

                        if (shireinput.gbData4.txtKin.Text != "0")
                        {
                            //税端数区分で判断、金額から税合計を取得
                            switch (intZeihasukbn)
                            {
                                case 0:
                                    //金額と税率、四捨五入による計算（モード0）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData4.txtKin.Text) * decZei / 100).ToString()), 0, 0)).ToString());
                                    break;
                                case 1:
                                    //金額と税率、四捨五入による計算（モード1）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData4.txtKin.Text) * decZei / 100).ToString()), 0, 1)).ToString());
                                    break;
                                case 2:
                                    //金額と税率、四捨五入による計算（モード2）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData4.txtKin.Text) * decZei / 100).ToString()), 0, 2)).ToString());
                                    break;
                            }
                        }

                        //金額0の場合
                        if (shireinput.gbData4.txtKin.Text == "0")
                        {
                            shireinput.gbData4.txtKin.Text = "";
                        }


                        //５行目
                        //金額無記入の場合
                        if (shireinput.gbData5.txtKin.Text == "")
                        {
                            shireinput.gbData5.txtKin.Text = "0";
                        }

                        if (shireinput.gbData5.txtKin.Text != "0")
                        {
                            //税端数区分で判断、金額から税合計を取得
                            switch (intZeihasukbn)
                            {
                                case 0:
                                    //金額と税率、四捨五入による計算（モード0）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData5.txtKin.Text) * decZei / 100).ToString()), 0, 0)).ToString());
                                    break;
                                case 1:
                                    //金額と税率、四捨五入による計算（モード1）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData5.txtKin.Text) * decZei / 100).ToString()), 0, 1)).ToString());
                                    break;
                                case 2:
                                    //金額と税率、四捨五入による計算（モード2）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.gbData5.txtKin.Text) * decZei / 100).ToString()), 0, 2)).ToString());
                                    break;
                            }
                        }

                        //金額0の場合
                        if (shireinput.gbData5.txtKin.Text == "0")
                        {
                            shireinput.gbData5.txtKin.Text = "";
                        }

                        //0の場合
                        if (txtKin.Text == "0")
                        {
                            txtKin.Text = "";
                        }

                        if (shireinput.txtUnchin.Text != "0")
                        {
                            //税端数区分で判断、運賃から税合計を取得
                            switch (intZeihasukbn)
                            {
                                case 0:
                                    //運賃と税率、四捨五入による計算（モード0）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.txtUnchin.Text) * decZei / 100).ToString()), 0, 0)).ToString());
                                    break;
                                case 1:
                                    //運賃と税率、四捨五入による計算（モード1）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.txtUnchin.Text) * decZei / 100).ToString()), 0, 1)).ToString());
                                    break;
                                case 2:
                                    //運賃と税率、四捨五入による計算（モード2）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((decimal.Parse(shireinput.txtUnchin.Text) * decZei / 100).ToString()), 0, 2)).ToString());
                                    break;
                            }
                        }

                        decZeigokei = decimal.Round(decZeigokei, 2, MidpointRounding.AwayFromZero);

                        //仕入入力画面の消費税に記入
                        shireinput.txtShohizei.Text = decZeigokei.ToString();

                        //運賃が0円の場合
                        if (shireinput.txtUnchin.Text == "0")
                        {
                            shireinput.txtUnchin.Text = "";
                        }
                    }
                    else
                    {
                        //税端数区分で判断、合計金額から税合計を取得
                        switch (intZeihasukbn)
                        {
                            case 0:
                                //合計金額と税率、四捨五入による計算（モード0）、仕入入力画面の消費税に記入
                                shireinput.txtShohizei.Text = (setRound(double.Parse((decGokei * decZei / 100).ToString()), 0, 0)).ToString();
                                break;
                            case 1:
                                //合計金額と税率、四捨五入による計算（モード1）、仕入入力画面の消費税に記入
                                shireinput.txtShohizei.Text = (setRound(double.Parse((decGokei * decZei / 100).ToString()), 0, 1)).ToString();
                                break;
                            case 2:
                                //合計金額と税率、四捨五入による計算（モード2）、仕入入力画面の消費税に記入
                                shireinput.txtShohizei.Text = (setRound(double.Parse((decGokei * decZei / 100).ToString()), 0, 2)).ToString();
                                break;
                        }
                    }

                    string strGokei = shireinput.txtGokei.Text;

                    if (strGokei == "0" || strGokei == "-1")
                    {
                        strGokei = "0";
                    }

                    string strShohizei = shireinput.txtShohizei.Text;

                    if (strShohizei == "0" || strShohizei == "-1")
                    {
                        strShohizei = "0";
                    }

                    //仕入入力画面の総合計に記入
                    shireinput.txtSogokei.Text = (decimal.Parse(strGokei) + decimal.Parse(strShohizei)).ToString("#");
                    shireinput.txtSogokei.updPriceMethod();

                    shireinput.txtGokei.updPriceMethod();
                    shireinput.txtShohizei.updPriceMethod();
                    shireinput.txtSogokei.updPriceMethod();

                    //マイナス１か０の場合
                    if (shireinput.txtGokei.Text == "-1" || shireinput.txtGokei.Text == "0")
                    {
                        shireinput.txtGokei.Clear();
                    }

                    //マイナス１か０の場合
                    if (shireinput.txtShohizei.Text == "-1" || shireinput.txtShohizei.Text == "0")
                    {
                        shireinput.txtShohizei.Clear();
                    }

                    //マイナス１か０の場合
                    if (shireinput.txtSogokei.Text == "-1" || shireinput.txtSogokei.Text == "0")
                    {
                        shireinput.txtSogokei.Clear();
                    }

                    //マイナス１か０の場合
                    if (shireinput.txtUnchin.Text == "-1" || shireinput.txtUnchin.Text == "0")
                    {
                        shireinput.txtUnchin.Clear();
                    }

                }
                return;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getShohizei
        ///消費税の取得
        ///</summary>
        private DataTable getShohizei(string strYMD)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_gb_Shohizei_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return dtSetCd_B;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strYMD);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return dtSetCd_B;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return dtSetCd_B;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getTorihikisaki
        ///取引先の取得
        ///</summary>
        private DataTable getTorihikisaki(string strCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Torihikisaki_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return dtSetCd_B;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strCd);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return dtSetCd_B;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return dtSetCd_B;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getJuchuTokuisaki
        ///得意先名の取得
        ///</summary>
        private DataTable getJuchuTokuisaki(string strJuchuNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Juchu_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return dtSetCd_B;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strJuchuNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return dtSetCd_B;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return dtSetCd_B;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///txtKeyDown
        ///キー入力判定（各テキストボックス）
        ///</summary>
        private void txtKeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    break;
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///txtChumonNo_KeyDown
        ///キー入力判定（注文番号）
        ///</summary>
        private void txtChumonNo_KeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    break;
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:

                    //親画面の情報取得
                    A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

                    //仕入入力のコードテキストに記入がある場合
                    if (shireinput.txtCD.blIsEmpty() == true)
                    {
                        bool blShire = true;

                        //発注残確認に移動
                        Form.D0360_JuchuzanKakunin.D0360_JuchuzanKakunin juchuzankakunin = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this.Parent, shireinput.txtCD.Text, txtChumonNo, blShire);
                        try
                        {
                            juchuzankakunin.ShowDialog();
                            juchuzankakunin.Dispose();

                            //注文Noにデータがある場合
                            if (txtChumonNo.blIsEmpty() == true)
                            {
                                getData();
                            }
                        }
                        catch (Exception ex)
                        {
                            //エラーロギング
                            new CommonException(ex);
                            return;
                        }
                    }
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///txtJuchuNo_TextChanged
        ///受注番号が変わった場合
        ///</summary>
        private void txtJuchuNo_TextChanged(object sender, EventArgs e)
        {
            //受注単価の初期化
            txtJuchuTanka.Clear();

            //受注番号が空白の場合
            if (txtJuchuNo.blIsEmpty() == false)
            {
                return;
            }

            DataTable dtJuchuTanka = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            DBConnective dbconnective = new DBConnective();
            try
            {
                // トランザクション開始
                dbconnective.BeginTrans();

                // dbo.f_get受注番号から受注単価を実行
                dtJuchuTanka = dbconnective.ReadSql("dbo.f_get受注番号から受注単価 '" + txtJuchuNo.Text + "'");

                //データがあるなら
                if (dtJuchuTanka.Rows.Count > 0)
                {
                    txtJuchuTanka.Text = dtJuchuTanka.Rows[0][0].ToString();
                }
                
                return;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///setRiekiritu
        ///利益率計算
        ///</summary>
        public void setRiekiritu(Boolean blDenpyoNoSelect)
        {
            //親画面の情報取得
            A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

            if (blDenpyoNoSelect)
            {
                //フォーカスしている列の判定
                if (shireinput.shotCnt == 1)
                {
                    //受注単価が空の場合
                    if (shireinput.txtTanka1.Text == "0" ||
                        shireinput.txtTanka1.Text == "" ||
                        shireinput.gbData1.txtTanka.Text == "0" ||
                        shireinput.gbData1.txtTanka.Text == "")
                    {
                        shireinput.txtRiekiritsu1.Clear();
                    }
                    else
                    {
                        decimal dectxtShiTanka = decimal.Round(decimal.Parse(shireinput.txtTanka1.Text), 2, MidpointRounding.AwayFromZero);
                        decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData1.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                        shireinput.txtRiekiritsu1.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                    }
                }
                else if (shireinput.shotCnt == 2)
                {
                    //受注単価が空の場合
                    if (shireinput.txtTanka2.Text == "0" ||
                        shireinput.txtTanka2.Text == "" ||
                        shireinput.gbData2.txtTanka.Text == "0" ||
                        shireinput.gbData2.txtTanka.Text == "")
                    {
                        shireinput.txtRiekiritsu2.Clear();
                    }
                    else
                    {
                        decimal dectxtShiTanka = decimal.Round(decimal.Parse(shireinput.txtTanka2.Text), 2, MidpointRounding.AwayFromZero);
                        decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData2.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                        shireinput.txtRiekiritsu2.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                    }
                }
                else if (shireinput.shotCnt == 3)
                {

                    //受注単価が空の場合
                    if (shireinput.txtTanka3.Text == "0" ||
                        shireinput.txtTanka3.Text == "" ||
                        shireinput.gbData3.txtTanka.Text == "0" ||
                        shireinput.gbData3.txtTanka.Text == "")
                    {
                        shireinput.txtRiekiritsu3.Clear();
                    }
                    else
                    {
                        decimal dectxtShiTanka = decimal.Round(decimal.Parse(shireinput.txtTanka3.Text), 2, MidpointRounding.AwayFromZero);
                        decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData3.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                        shireinput.txtRiekiritsu3.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                    }
                }
                else if (shireinput.shotCnt == 4)
                {
                    //受注単価が空の場合
                    if (shireinput.txtTanka4.Text == "0" ||
                        shireinput.txtTanka4.Text == "" ||
                        shireinput.gbData4.txtTanka.Text == "0" ||
                        shireinput.gbData4.txtTanka.Text == "")
                    {
                        shireinput.txtRiekiritsu4.Clear();
                    }
                    else
                    {
                        decimal dectxtShiTanka = decimal.Round(decimal.Parse(shireinput.txtTanka4.Text), 2, MidpointRounding.AwayFromZero);
                        decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData4.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                        shireinput.txtRiekiritsu4.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                    }
                }
                else if (shireinput.shotCnt == 5)
                {
                    //受注単価が空の場合
                    if (shireinput.txtTanka5.Text == "0" ||
                        shireinput.txtTanka5.Text == "" ||
                        shireinput.gbData5.txtTanka.Text == "0" ||
                        shireinput.gbData5.txtTanka.Text == "")
                    {
                        shireinput.txtRiekiritsu5.Clear();
                    }
                    else
                    {
                        decimal dectxtShiTanka = decimal.Round(decimal.Parse(shireinput.txtTanka5.Text), 2, MidpointRounding.AwayFromZero);
                        decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData5.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                        shireinput.txtRiekiritsu5.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                    }
                }
            }
            else
            {
                //フォーカスしている列の判定
                if (shireinput.shotCnt == 1)
                {
                    //仕入先画面に受注単価がある場合
                    //受注番号から呼び出して、注文Noで未入力のまま金額と単価を移動した時
                    if (shireinput.txtTanka1.Text != "0" &&
                        shireinput.txtTanka1.Text != ""
                        )
                    {
                        //入力項目に単価がない場合
                        if (shireinput.gbData1.txtTanka.Text == "0" ||
                        shireinput.gbData1.txtTanka.Text == "")
                        {
                            shireinput.txtRiekiritsu1.Clear();
                        }
                        else
                        {
                        decimal dectxtShiTanka = decimal.Round(decimal.Parse(shireinput.txtTanka1.Text), 2, MidpointRounding.AwayFromZero);
                        decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData1.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                        shireinput.txtRiekiritsu1.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                        }
                    }
                    //受注番号がなく注文Noでデータを呼び出して、金額と単価を移動した時
                    else
                    {
                        //受注単価が空の場合
                        if (strJuchuTanka == "0" ||
                            strJuchuTanka == "" ||
                            shireinput.gbData1.txtTanka.Text == "0" ||
                            shireinput.gbData1.txtTanka.Text == "")
                        {
                            shireinput.txtRiekiritsu1.Clear();
                        }
                        else
                        {
                            decimal dectxtShiTanka = decimal.Round(decimal.Parse(strJuchuTanka), 2, MidpointRounding.AwayFromZero);
                            decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData1.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                            shireinput.txtRiekiritsu1.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");

                            //shireinput.txtRiekiritsu1.Text = ((decimal.Parse(strJuchuTanka) - decimal.Parse(shireinput.gbData1.txtTanka.Text)) / decimal.Parse(strJuchuTanka) * 100).ToString("0.0");
                        }
                    }
                }
                else if (shireinput.shotCnt == 2)
                {
                    //仕入先画面に受注単価がある場合
                    //受注番号から呼び出して、注文Noで未入力のまま金額と単価を移動した時
                    if (shireinput.txtTanka2.Text != "0" &&
                        shireinput.txtTanka2.Text != ""
                        )
                    {
                        //入力項目に単価がない場合
                        if (shireinput.gbData2.txtTanka.Text == "0" ||
                        shireinput.gbData2.txtTanka.Text == "")
                        {
                            shireinput.txtRiekiritsu2.Clear();
                        }
                        else
                        {
                            decimal dectxtShiTanka = decimal.Round(decimal.Parse(shireinput.txtTanka2.Text), 2, MidpointRounding.AwayFromZero);
                            decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData2.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                            shireinput.txtRiekiritsu2.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                        }
                    }
                    //受注番号がなく注文Noでデータを呼び出して、金額と単価を移動した時
                    else
                    {
                        //受注単価が空の場合
                        if (strJuchuTanka == "0" ||
                            strJuchuTanka == "" ||
                            shireinput.gbData2.txtTanka.Text == "0" ||
                            shireinput.gbData2.txtTanka.Text == "")
                        {
                            shireinput.txtRiekiritsu2.Clear();
                        }
                        else
                        {
                            decimal dectxtShiTanka = decimal.Round(decimal.Parse(strJuchuTanka), 2, MidpointRounding.AwayFromZero);
                            decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData2.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                            shireinput.txtRiekiritsu2.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                        }
                    }
                }
                else if (shireinput.shotCnt == 3)
                {
                    //仕入先画面に受注単価がある場合
                    //受注番号から呼び出して、注文Noで未入力のまま金額と単価を移動した時
                    if (shireinput.txtTanka3.Text != "0" &&
                        shireinput.txtTanka3.Text != ""
                        )
                    {
                        //入力項目に単価がない場合
                        if (shireinput.gbData3.txtTanka.Text == "0" ||
                        shireinput.gbData3.txtTanka.Text == "")
                        {
                            shireinput.txtRiekiritsu3.Clear();
                        }
                        else
                        {
                            decimal dectxtShiTanka = decimal.Round(decimal.Parse(shireinput.txtTanka3.Text), 2, MidpointRounding.AwayFromZero);
                            decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData3.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                            shireinput.txtRiekiritsu3.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                        }
                    }
                    //受注番号がなく注文Noでデータを呼び出して、金額と単価を移動した時
                    else
                    {
                        //受注単価が空の場合
                        if (strJuchuTanka == "0" ||
                            strJuchuTanka == "" ||
                            shireinput.gbData3.txtTanka.Text == "0" ||
                            shireinput.gbData3.txtTanka.Text == "")
                        {
                            shireinput.txtRiekiritsu3.Clear();
                        }
                        else
                        {
                            decimal dectxtShiTanka = decimal.Round(decimal.Parse(strJuchuTanka), 2, MidpointRounding.AwayFromZero);
                            decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData3.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                            shireinput.txtRiekiritsu3.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                        }
                    }
                }
                else if (shireinput.shotCnt == 4)
                {
                    //仕入先画面に受注単価がある場合
                    //受注番号から呼び出して、注文Noで未入力のまま金額と単価を移動した時
                    if (shireinput.txtTanka4.Text != "0" &&
                        shireinput.txtTanka4.Text != ""
                        )
                    {
                        //入力項目に単価がない場合
                        if (shireinput.gbData4.txtTanka.Text == "0" ||
                        shireinput.gbData4.txtTanka.Text == "")
                        {
                            shireinput.txtRiekiritsu4.Clear();
                        }
                        else
                        {
                            decimal dectxtShiTanka = decimal.Round(decimal.Parse(shireinput.txtTanka4.Text), 2, MidpointRounding.AwayFromZero);
                            decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData4.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                            shireinput.txtRiekiritsu4.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                        }
                    }
                    //受注番号がなく注文Noでデータを呼び出して、金額と単価を移動した時
                    else
                    {
                        //受注単価が空の場合
                        if (strJuchuTanka == "0" ||
                            strJuchuTanka == "" ||
                            shireinput.gbData4.txtTanka.Text == "0" ||
                            shireinput.gbData4.txtTanka.Text == "")
                        {
                            shireinput.txtRiekiritsu4.Clear();
                        }
                        else
                        {
                            decimal dectxtShiTanka = decimal.Round(decimal.Parse(strJuchuTanka), 2, MidpointRounding.AwayFromZero);
                            decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData4.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                            shireinput.txtRiekiritsu4.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                        }
                    }
                }
                else if (shireinput.shotCnt == 5)
                {
                    //仕入先画面に受注単価がある場合
                    //受注番号から呼び出して、注文Noで未入力のまま金額と単価を移動した時
                    if (shireinput.txtTanka5.Text != "0" &&
                        shireinput.txtTanka5.Text != ""
                        )
                    {
                        //入力項目に単価がない場合
                        if (shireinput.gbData5.txtTanka.Text == "0" ||
                        shireinput.gbData5.txtTanka.Text == "")
                        {
                            shireinput.txtRiekiritsu5.Clear();
                        }
                        else
                        {
                            decimal dectxtShiTanka = decimal.Round(decimal.Parse(shireinput.txtTanka5.Text), 2, MidpointRounding.AwayFromZero);
                            decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData5.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                            shireinput.txtRiekiritsu5.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                        }
                    }
                    //受注番号がなく注文Noでデータを呼び出して、金額と単価を移動した時
                    else
                    {
                        //受注単価が空の場合
                        if (strJuchuTanka == "0" ||
                            strJuchuTanka == "" ||
                            shireinput.gbData5.txtTanka.Text == "0" ||
                            shireinput.gbData5.txtTanka.Text == "")
                        {
                            shireinput.txtRiekiritsu5.Clear();
                        }
                        else
                        {
                            decimal dectxtShiTanka = decimal.Round(decimal.Parse(strJuchuTanka), 2, MidpointRounding.AwayFromZero);
                            decimal dectxtGbTanka = decimal.Round(decimal.Parse(shireinput.gbData5.txtTanka.Text), 2, MidpointRounding.AwayFromZero);

                            shireinput.txtRiekiritsu5.Text = ((dectxtShiTanka - dectxtGbTanka) / dectxtShiTanka * 100).ToString("0.0");
                        }
                    }
                }
            }
        }

        ///<summary>
        ///txtKeyPress
        ///No.と注文Noでの入力キー処理
        ///</summary>
        private void txtKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b'
            && e.KeyChar != '\u0001' && e.KeyChar != '\u0003' && e.KeyChar != '\u0016' && e.KeyChar != '\u0018')
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }
    }
}
