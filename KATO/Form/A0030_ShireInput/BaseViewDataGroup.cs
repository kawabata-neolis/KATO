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

namespace KATO.Form.A0030_ShireInput
{
    public partial class BaseViewDataGroup : UserControl
    {
        //受注番号確保用
        private string strjuchuno = "";
        public string strJuchuNo
        {
            get
            {
                return strjuchuno;
            }
            set
            {
                strjuchuno = value;
            }
        }

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
            if (txtShohinCd.blIsEmpty() == false)
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
                txtMasterTanka.Text = string.Format("{0:#,#.00}", dtSetCd_B.Rows[0]["仕入単価"]);
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
                strSQLInput = string.Format(strSQLInput, this.strjuchuno);

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
    }
}
