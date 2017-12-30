using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.E0330_TokuisakiMotocyoKakunin
{
    /// E0330_TokuisakiMotocyoKakunin_B
    /// 得意先元帳確認
    /// 作成者：
    /// 作成日：2017/6/30
    /// 更新者：
    /// 更新日：2017/6/30
    /// カラム論理名
    /// </summary>
    class E0330_TokuisakiMotocyoKakunin_B
    {
        ///<summary>
        ///getZenzan
        ///前月残高を取得
        ///</summary>
        public DataTable getZenzan(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 請求履歴

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_繰越残高FROM取引先経理情報( '"+ lstString[0] +"'" + ",dbo.f_月初日('" +lstString[1]+ "')) AS 前月残高 ";
            
            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }


        ///<summary>
        ///getUriage
        ///売上金額を取得
        ///</summary>
        public DataTable getUriage(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 売上金額

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_売上ヘッダ_売上高( '" + lstString[0] + "','" + lstString[1] +  "','" + lstString[2] + "') AS 売上金額 ";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }

        ///<summary>
        ///getZei
        ///消費税額を取得
        ///</summary>
        public DataTable getZei(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 消費税額

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_売上ヘッダ_消費税( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 消費税額 ";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }

        ///<summary>
        ///getSotozei
        ///外税を取得
        ///</summary>
        public DataTable getSotozei(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 外税

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_月間消費税( '" + lstString[0] + "','" + lstString[2] + "'," + lstString[3] + ") AS 請求消費税 ";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }


        ///<summary>
        ///getNyukinGenkin
        ///入金現金を取得
        ///</summary>
        public DataTable getNyukinGenkin(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 外税

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_現金( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 入金現金 ";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }

        ///<summary>
        ///getNyukinKogitte
        ///入金小切手を取得
        ///</summary>
        public DataTable getNyukinKogitte(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金小切手

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_小切手( '" + lstString[0] + "','" + lstString[1] +  "','" + lstString[2] + "') AS 入金小切手 ";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }


        ///<summary>
        ///getNyukinHurikomi
        ///入金振込を取得
        ///</summary>
        public DataTable getNyukinHurikomi(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金振込

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_振込( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 入金振込 ";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }



        ///<summary>
        ///getNyukinTegata
        ///入金手形を取得
        ///</summary>
        public DataTable getNyukinTegata(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金手形

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_手形( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 入金手形 ";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }


        ///<summary>
        ///getNyukinSousatu
        ///入金相殺を取得
        ///</summary>
        public DataTable getNyukinSousatu(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金相殺

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_相殺( '" + lstString[0] +  "','" + lstString[1] + "','" + lstString[2] + "') AS 入金相殺 ";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }


        ///<summary>
        ///getNyukinTesuryou
        ///入金手数料を取得
        ///</summary>
        public DataTable getNyukinTesuryou(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金手数料

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_手数料( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 入金手数料 ";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }


        ///<summary>
        ///getNyukinSonota
        ///入金その他を取得
        ///</summary>
        public DataTable getNyukinSonota(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 入金その他

            strSQLInput = strSQLInput + " SELECT dbo.f_get売掛残高一覧表_入金_その他( '" + lstString[0] + "','" + lstString[1] + "','" + lstString[2] + "') AS 入金その他 ";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }

        ///<summary>
        ///getTokuisakiMotocyo
        ///得意先元帳を取得
        ///</summary>
        public DataTable getTokuisakiMotocyo(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();


            //SQL文 得意先元帳

            strSQLInput = strSQLInput + " SELECT ";
            strSQLInput = strSQLInput + " 伝票年月日 ";
            strSQLInput = strSQLInput + " , 伝票番号 ";
            strSQLInput = strSQLInput + " , 行番号 ";
            strSQLInput = strSQLInput + " , 取引区分名 ";
            strSQLInput = strSQLInput + " , メーカー名 ";
            strSQLInput = strSQLInput + " , 商品名 ";
            strSQLInput = strSQLInput + " , 数量 ";
            strSQLInput = strSQLInput + " , 売上単価 ";
            strSQLInput = strSQLInput + " , 売上金額 ";
            strSQLInput = strSQLInput + " , 入金額 ";
            strSQLInput = strSQLInput + " , 0 ";
            strSQLInput = strSQLInput + " , 取引区分 ";

            strSQLInput = strSQLInput + " FROM ";
            strSQLInput = strSQLInput + " 得意先元帳明細_VIEW ";

            strSQLInput = strSQLInput + " WHERE ";
            strSQLInput = strSQLInput + " 得意先コード = '" + lstString[0] + "' ";
            strSQLInput = strSQLInput + " AND 伝票年月日 >= '" + lstString[1] + "' ";
            strSQLInput = strSQLInput + " AND 伝票年月日 <= '" + lstString[2] + "' ";

            strSQLInput = strSQLInput + " ORDER BY ";
            strSQLInput = strSQLInput + " 伝票年月日, 表示順, 伝票番号, 行番号 ";


            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            try
            {
                dtGetTableGrid = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }

            return dtGetTableGrid;
        }
    }
}
