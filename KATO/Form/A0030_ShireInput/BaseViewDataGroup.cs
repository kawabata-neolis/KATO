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

namespace KATO.Form.A0030_ShireInput
{
    public partial class BaseViewDataGroup : UserControl
    {
        public BaseViewDataGroup()
        {
            InitializeComponent();
        }

        ///<summary>
        ///delData
        ///入力項目削除
        ///</summary>
        public void delData()
        {
            txtNo.Clear();
            txtChumonNo.Clear();
            txtHin.Clear();
            txtSu.Clear();
            txtTanka.Clear();
            txtKin.Clear();
            txtBiko.Clear();
            labelSet_Eigyosho.codeTxt.Clear();
            txtTeka.Clear();
            txtShireritsu.Clear();
            txtChokinTanka.Clear();
            txtMasterTanka.Clear();
            txtTokuisaki.Clear();
        }

        ///<summary>
        ///setData
        ///項目にデータを入れる
        ///</summary>
        public void setData(List<string> lstData)
        {
            //行番号
            txtNo.Text = lstData[0];
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
            txtTanka.Text = string.Format("{0:#,#.00}", lstData[14]);
            //単価確保（発注原価チェック用）
            txtTankaSub.Text = string.Format("{0:#,#.00}", lstData[14]);

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
            txtSu.Focus();
            txtTanka.Focus();
            txtKin.Focus();
            txtTankaSub.Focus();
            txtBiko.Focus();

            //仕入率の取得
            txtShireritsu.Text = ((decimal.Parse(txtTankaSub.Text) / int.Parse(txtTekaSub.Text)) * 100).ToString();

            //0パディング等の表示情報の修正
            txtShireritsu.Focus();
            txtBiko.Focus();


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

                //直近単価に入れる
                txtChokinTanka.Text = string.Format("{0:#,#.00}", dtSetCd_B.Rows[0][1]);

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

                //マスター単価に入れる
                txtMasterTanka.Text = string.Format("{0:#,0.00}", dtSetCd_B.Rows[0]["仕入単価"]);

                //単価確保（発注原価チェック用）
                txtTankaSub.Text = string.Format("{0:#,0.00}", dtSetCd_B.Rows[0]["仕入単価"]);

                //定価を入れる
                txtTeka.Text = string.Format("{0:#,#}", dtSetCd_B.Rows[0]["定価"]);

                //定価のサブの入れものに追加(仕入率計算時に[.]があるとエラーを起こすため)
                txtTekaSub.Visible = true;
                txtTekaSub.Text = string.Format("{0:#}", dtSetCd_B.Rows[0]["定価"]);
                txtTekaSub.Visible = false;

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

                //得意先に入れる
                txtTokuisaki.Text = dtSetCd_B.Rows[0]["得意先名称"].ToString().Trim(' ');

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
            //品名確保
            string strHinmei;

            //現行数確保用
            short shortCntG = 0;

            //親画面の情報取得
            A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

            //注文Noの記入がない場合
            if (!StringUtl.blIsEmpty(txtChumonNo.Text))
            {
                //一行文すべて白紙
                delText();
                setGokeiKesan();
                return;
            }

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQLHeader = new List<string>();
            List<string> lstSQLCount = new List<string>();
            List<string> lstSQLHachu = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQLHeader.Add("Common");
            lstSQLHeader.Add("C_LIST_ShireHeader_SELECT");

            lstSQLCount.Add("A0030_ShireInput");
            lstSQLCount.Add("ShireInput_ShireMesai_Count_SELECT");

            lstSQLHachu.Add("A0030_ShireInput");
            lstSQLHachu.Add("ShireInput_gb_HachuData_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B_Header = new DataTable();
            DataTable dtSetCd_B_Count = new DataTable();
            DataTable dtSetCd_B_Hachu = new DataTable();

            //SQL実行時に取り出したデータを入れる用(受注得意先用)
            DataTable dtSetCdTokuisaki_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //ヘッダー
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQLHeader);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, shireinput.txtDenpyoNo.Text);

                //SQL接続後、該当データを取得
                dtSetCd_B_Header = dbconnective.ReadSql(strSQLInput);

                //データがある場合
                if (dtSetCd_B_Header.Rows[0][0].ToString() != "")
                {
                    shireinput.txtYMD.Text = dtSetCd_B_Header.Rows[0]["伝票年月日"].ToString();
                    shireinput.txtCD.Text = dtSetCd_B_Header.Rows[0]["仕入先コード"].ToString();
                    shireinput.txtYubinView.Text = dtSetCd_B_Header.Rows[0]["郵便番号"].ToString();
                    shireinput.txtJusho1View.Text = dtSetCd_B_Header.Rows[0]["住所１"].ToString();
                    shireinput.txtJusho2View.Text = dtSetCd_B_Header.Rows[0]["住所２"].ToString();
                    shireinput.labelSet_Torihikikbn.CodeTxtText = dtSetCd_B_Header.Rows[0]["取引区分"].ToString();
                    shireinput.labelSet_Tantousha.CodeTxtText = dtSetCd_B_Header.Rows[0]["担当者コード"].ToString();
                    shireinput.txtEigyouCd.Text = dtSetCd_B_Header.Rows[0]["営業所コード"].ToString();
                    shireinput.txtTekiyo.Text = dtSetCd_B_Header.Rows[0]["摘要欄"].ToString();
                    shireinput.txtGokei.Text = dtSetCd_B_Header.Rows[0]["税抜合計金額"].ToString();
                    shireinput.txtShohizei.Text = dtSetCd_B_Header.Rows[0]["消費税"].ToString();
                    shireinput.txtSogokei.Text = dtSetCd_B_Header.Rows[0]["税込合計金額"].ToString();
                    shireinput.txtUnchin.Text = dtSetCd_B_Header.Rows[0]["運賃"].ToString();

                    //初期化
                    strSQLInput = "";

                    //カウント
                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQLCount);

                    //パスがなければ返す
                    if (strSQLInput == "")
                    {
                        return;
                    }

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput, txtChumonNo.Text);

                    //SQL接続後、該当データを取得
                    dtSetCd_B_Count = dbconnective.ReadSql(strSQLInput);

                    //データがある場合
                    if (int.Parse(dtSetCd_B_Count.Rows[0][0].ToString()) > 0)
                    {
                        //メッセージ
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "検収済みの収入です。変更は不可能です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        shireinput.btnF01.Enabled = false;
                        shireinput.btnF03.Enabled = false;
                        shireinput.btnF07.Enabled = false;
                    }
                }
                else
                {
                    //メッセージ
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    shireinput.blRock = false;

                    shireinput.txtDenpyoNo.Focus();
                    return;
                }

                //初期化 
                strSQLInput = "";


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
                if (dtSetCd_B_Hachu.Rows[0][0].ToString() != "")
                {
                    //行数分ループ
                    for (int intCnt = 0; intCnt < dtSetCd_B_Hachu.Rows.Count; intCnt++)
                    {
                        //行番号が99の場合
                        if(dtSetCd_B_Hachu.Rows[intCnt]["行番号"].ToString() == "99")
                        {
                                //運賃の処理があったが
                        }

                        //行番号を確保
                        shireinput.shotCnt = short.Parse(dtSetCd_B_Hachu.Rows[intCnt]["行番号"].ToString());

                        //グループ内でも確保
                        shortCntG = shireinput.shotCnt;

                        //行数１の場合
                        if (shireinput.shotCnt == 1)
                        {
                            shireinput.gbData1.txtNo.Text = shortCntG.ToString();
                            shireinput.gbData1.txtChumonNo.Text = dtSetCd_B_Hachu.Rows[intCnt]["発注番号"].ToString();
                        }
                        //行数２の場合
                        else if (shireinput.shotCnt == 2)
                        {
                            shireinput.gbData2.txtNo.Text = shortCntG.ToString();
                            shireinput.gbData2.txtChumonNo.Text = dtSetCd_B_Hachu.Rows[intCnt]["発注番号"].ToString();
                        }
                        //行数３の場合
                        else if (shireinput.shotCnt == 3)
                        {
                            shireinput.gbData3.txtNo.Text = shortCntG.ToString();
                            shireinput.gbData3.txtChumonNo.Text = dtSetCd_B_Hachu.Rows[intCnt]["発注番号"].ToString();
                        }
                        //行数４の場合
                        else if (shireinput.shotCnt == 4)
                        {
                            shireinput.gbData4.txtNo.Text = shortCntG.ToString();
                            shireinput.gbData4.txtChumonNo.Text = dtSetCd_B_Hachu.Rows[intCnt]["発注番号"].ToString();
                        }
                        //行数５の場合
                        else if (shireinput.shotCnt == 5)
                        {
                            shireinput.gbData5.txtNo.Text = shortCntG.ToString();
                            shireinput.gbData5.txtChumonNo.Text = dtSetCd_B_Hachu.Rows[intCnt]["発注番号"].ToString();
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

                    strHinmei = strHinmei + " " + dtChubun.Rows[0]["中分類名"];

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

                    //発注数量から仕入済数量を引く
                    txtSu.Text = ((int.Parse(string.Format("{0:0.#}", double.Parse(dtSetCd_B_Hachu.Rows[0]["発注数量"].ToString())))) - (int.Parse(string.Format("{0:0.#}", double.Parse(dtSetCd_B_Hachu.Rows[0]["仕入済数量"].ToString()))))).ToString();
                    //数量が変更になったことによる処理
                    setTxtSuChange();

                    txtTanka.Text = string.Format("{0:0.00}", double.Parse(dtSetCd_B_Hachu.Rows[0]["発注単価"].ToString()));
                    //単価が変更になったことによる処理
                    setTxtTankaChange();

                    txtBiko.Text = dtSetCd_B_Hachu.Rows[0]["注番"].ToString();

                    labelSet_Eigyosho.CodeTxtText = dtSetCd_B_Hachu.Rows[0]["営業所コード"].ToString();
                                        
                    txtJuchuNo.Text = dtSetCd_B_Hachu.Rows[0]["受注番号"].ToString();

                    //仕入入力画面のコードが8888か5555の場合
                    if(shireinput.txtCD.ToString() == "8888" || shireinput.txtCD.ToString() == "8888")
                    {
                        shireinput.txtShireNameView.Text = dtSetCd_B_Hachu.Rows[0]["仕入先名称"].ToString();
                    }

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

                    txtTokuisaki.Text = dtSetCdTokuisaki_B.Rows[0]["得意先名称"].ToString();



                }
                else
                {
                    //発注データが存在しないということを伝えるメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_ERROR, "発注データが存在しません！！", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    txtChumonNo.Focus();
                    return;
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
        ///setTxtShohinCd
        ///商品コード項目が変更になった場合
        ///</summary>
        private void setTxtShohinCd()
        {
            //親画面の情報取得
            A0030_ShireInput shireinput = (A0030_ShireInput)this.Parent;

            //直近仕入単価の取得
            txtChokinTanka.Text = getChokinShireTanka(txtShohinCd.Text);
            //マスター単価の取得
            txtMasterTanka.Text = getGyomuShireTanka(txtShohinCd.Text);
            //定価の取得
            txtTeka.Text = getMasterTeka(txtShohinCd.Text);
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

            //DBの取引先から該当データの取得
            intHasu = getMesaiKesankbn(shireinput.txtCD.Text);

            //数量と単価、四捨五入による計算、金額に記入
            txtKin.Text = (setRound((int.Parse(string.Format("{0:0.#}", double.Parse(txtSu.Text))) * (int.Parse(string.Format("{0:0.#}", double.Parse(txtTanka.Text))))), 0, intHasu)).ToString();

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

            //DBの取引先から該当データの取得
            intHasu = getMesaiKesankbn(shireinput.txtCD.Text);

            txtKin.Text = (setRound((int.Parse(string.Format("{0:0.#}", double.Parse(txtSu.Text))) * (int.Parse(string.Format("{0:0.#}", double.Parse(txtTanka.Text))))), 0, intHasu)).ToString();

            //金額が-1になった場合
            if (txtKin.Text == "-1")
            {
                txtKin.Text = "0";
            }

            setGokeiKesan();

            //定価の項目に記入がある場合
            if (StringUtl.blIsEmpty(txtTeka.Text))
            {
                //定価の数値が0以外の場合
                if (txtTeka.Text != "0")
                {
                    txtShireritsu.Text = (int.Parse(string.Format("{0:0.#}", double.Parse(txtTanka.Text))) * (int.Parse(string.Format("{0:0.#}", double.Parse(txtTanka.Text)))) * 100).ToString();
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

                strChokinShireTanka = string.Format("{0:0.00}", double.Parse(dtSetCd_B.Rows[0]["仕入単価"].ToString()));

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

                strChokinShireTanka = string.Format("{0:0.00}", double.Parse(dtSetCd_B.Rows[0]["仕入単価"].ToString()));

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

                strMasterTeka = string.Format("{0:0.#}", double.Parse(dtSetCd_B.Rows[0]["定価"].ToString()));

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
        ///txtChumonNo_KeyDown
        ///注文Noでのキー判定
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
                    if (!StringUtl.blIsEmpty(txtChumonNo.Text))
                    {
                        txtChumonNo.Focus();
                        return;
                    }
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
                txtKin.Text = (setRound((int.Parse(string.Format("{0:0.#}", double.Parse(txtSu.Text))) * (int.Parse(string.Format("{0:0.#}", double.Parse(txtTanka.Text))))), 0, intHasu)).ToString();

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

            //
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
                txtKin.Text = (setRound((int.Parse(string.Format("{0:0.#}", double.Parse(txtSu.Text))) * (int.Parse(string.Format("{0:0.#}", double.Parse(txtTanka.Text))))), 0, intHasu)).ToString();

                //金額が-1になった場合
                if (txtKin.Text == "-1")
                {
                    txtKin.Text = "0";
                }

                //定価の中身がない場合
                if (!StringUtl.blIsEmpty(txtTeka.Text))
                {
                    //定価の中身が0以外の場合
                    if (txtTeka.Text != "0" && txtTeka.Text != "")
                    {
                        //単価と定価で計算、仕入率に記入
                        txtShireritsu.Text = (int.Parse(txtTanka.Text) / int.Parse(txtTeka.Text) * 100).ToString();
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
        private void delText()
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
        private void setGokeiKesan()
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
            if (!StringUtl.blIsEmpty(shireinput.txtCD.Text) || !StringUtl.blIsEmpty(txtKin.Text))
            {
                return;
            }

            //合計、総合計、消費税
            shireinput.txtGokei.Clear();
            shireinput.txtSogokei.Clear();
            shireinput.txtShohizei.Clear();

            //forループカウント用
            int intCnt;

            //行数分ループ
            for (intCnt = 0; intCnt <= shireinput.intMaxRow; intCnt++)
            {
                //各行の入力金額を追加
                decGokei = decGokei + int.Parse(txtKin.Text.Trim(' '));
            }

            //運賃が記入されていない場合
            if (!StringUtl.blIsEmpty(shireinput.txtUnchin.Text)) {
                shireinput.txtUnchin.Text = "0";
            }

            //運賃を追加
            decGokei = decGokei + Decimal.Parse(shireinput.txtUnchin.Text);
                
            //合計に入れる
            shireinput.txtGokei.Text = decGokei.ToString();

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
                        return;
                    }

                    //消費税区分が1の場合
                    if (intZeikbn == 1)
                    {
                        //消費税を0
                        shireinput.txtShohizei.Text = "0";
                        //総合計を合計と同じ数値
                        shireinput.txtSogokei.Text = decGokei.ToString();
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
                            decZei = int.Parse(dtZei.Rows[0]["消費税率"].ToString());
                        }
                    }

                    //税計算区分が0の場合
                    if (decZeikesankbn == 0)
                    {
                        //行数分ループ
                        for (intCnt = 0; intCnt <= shireinput.intMaxRow; intCnt++)
                        {
                            //税端数区分で判断、金額から税合計を取得
                            switch (intZeihasukbn)
                            {
                                case 0:
                                    //金額と税率、四捨五入による計算（モード0）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((int.Parse(txtKin.Text) * decZei / 100).ToString()), 0, 0)).ToString());
                                    break;
                                case 1:
                                    //金額と税率、四捨五入による計算（モード1）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((int.Parse(txtKin.Text) * decZei / 100).ToString()), 0, 1)).ToString());
                                    break;
                                case 2:
                                    //金額と税率、四捨五入による計算（モード2）
                                    decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((int.Parse(txtKin.Text) * decZei / 100).ToString()), 0, 2)).ToString());
                                    break;
                            }
                        }

                        //税端数区分で判断、運賃から税合計を取得
                        switch (intZeihasukbn)
                        {
                            case 0:
                                //運賃と税率、四捨五入による計算（モード0）
                                decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((int.Parse(shireinput.txtUnchin.Text) * decZei / 100).ToString()), 0, 0)).ToString());
                                break;
                            case 1:
                                //運賃と税率、四捨五入による計算（モード1）
                                decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((int.Parse(shireinput.txtUnchin.Text) * decZei / 100).ToString()), 0, 1)).ToString());
                                break;
                            case 2:
                                //運賃と税率、四捨五入による計算（モード2）
                                decZeigokei = decZeigokei + decimal.Parse((setRound(double.Parse((int.Parse(shireinput.txtUnchin.Text) * decZei / 100).ToString()), 0, 2)).ToString());
                                break;
                        }

                        //仕入入力画面の消費税に記入
                        shireinput.txtShohizei.Text = decZeigokei.ToString();
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

                    //仕入入力画面の総合計に記入
                    shireinput.txtSogokei.Text = (int.Parse(shireinput.txtGokei.Text) + int.Parse(shireinput.txtShohizei.Text)).ToString();
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
            lstSQL.Add("Common");
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
    }
}
