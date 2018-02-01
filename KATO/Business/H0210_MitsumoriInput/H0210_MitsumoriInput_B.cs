using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.H0210_MitsumoriInput
{
    class H0210_MitsumoriInput_B
    {
        DBConnective con;
        public void beginTrance()
        {
            con = new DBConnective();
            con.BeginTrans();
        }

        public void commit()
        {
            con.Commit();
            con.DB_Disconnect();
        }

        public void rollback()
        {
            con.Rollback();
            con.DB_Disconnect();
        }

        public DataTable getUserInfo(string strCd)
        {
            DataTable dtRet = null;
            string strQuery = "";

            strQuery += "SELECT *";
            strQuery += "  FROM 担当者";
            strQuery += " WHERE ログインＩＤ = '" + strCd + "'";
            strQuery += "   AND 削除 = 'N'";


            DBConnective dbCon = new DBConnective();
            try
            {
                dtRet = dbCon.ReadSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }

        public DataTable getMitsumoriInfo(string strNum)
        {
            DataTable dt = null;

            string strSQL = "";
            strSQL += "SELECT ";
            strSQL += " CONVERT(VARCHAR, 見積年月日, 111) as 見積年月日,標題,担当者名,納期,支払条件,有効期限,備考,";
            strSQL += " 得意先コード,得意先名称,担当者コード,営業所コード,";
            strSQL += " 売上金額,納入先コード,納入先名称, 社内メモ";
            strSQL += " FROM 見積ヘッド ";
            strSQL += " WHERE 削除 = 'N' ";
            strSQL += " AND 見積書番号=" + strNum;

            DBConnective dbCon = new DBConnective();
            try
            {
                dt = dbCon.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable getMitsumoriDetail(string strNum)
        {
            DataTable dt = null;

            string strSQL = "";

            //strSQL += "SELECT ";
            //strSQL += " 行番号,商品コード,メーカーコード,大分類コード,中分類コード,";
            //strSQL += " Ｃ１, Ｃ２, Ｃ３,Ｃ４, Ｃ５,Ｃ６, ";
            //strSQL += " 品名型式,数量,単位, 売上単価, 売上金額,仕入単価, 粗利金額,率,備考,仕入先コード,仕入先名,印刷フラグ, ";
            //strSQL += " 仕入先コード１,仕入先名１,仕入単価１,仕入金額１,粗利１,粗利率１,仕入先コード２,仕入先名２, 仕入単価２,仕入金額２,粗利２,粗利率２,仕入先コード３,仕入先名３,仕入単価３,仕入金額３,粗利３,粗利率３";
            //strSQL += " FROM 見積明細 ";
            //strSQL += " WHERE 削除 = 'N' ";
            //strSQL += " AND 伝票番号=" + strNum;
            //strSQL += " ORDER BY 行番号";

            strSQL += "select a.行番号,";
            strSQL += "       null as 印,";
            strSQL += "       a.品名型式,";
            strSQL += "       a.数量,";
            strSQL += "       b.定価,";
            strSQL += "       a.売上単価 as 見積単価,";
            strSQL += "       0.0 as 掛率,";
            strSQL += "       ROUND(a.売上単価 * a.数量 , 0) as 金額,";
            strSQL += "       a.仕入単価,";
            strSQL += "       ROUND(a.粗利金額, 0) as 粗利金額,";
            strSQL += "       ROUND(a.率, 1) as 率,";
            strSQL += "       a.備考,";
            strSQL += "       a.仕入先名,";
            strSQL += "       a.印刷フラグ,";
            strSQL += "       a.仕入先コード１,";
            strSQL += "       a.仕入先名１,";
            strSQL += "       ROUND(a.仕入単価１, 0) as 仕入単価１,";
            strSQL += "       ROUND(a.仕入金額１, 0) as 仕入金額１,";
            strSQL += "       ROUND(a.粗利１, 0) as 粗利１,";
            strSQL += "       ROUND(a.粗利率１, 0) as 粗利率１,";
            strSQL += "       a.仕入先コード２,";
            strSQL += "       a.仕入先名２,";
            strSQL += "       ROUND(a.仕入単価２, 0) as 仕入単価２,";
            strSQL += "       ROUND(a.仕入金額２, 0) as 仕入金額２,";
            strSQL += "       ROUND(a.粗利２, 0) as 粗利２,";
            strSQL += "       ROUND(a.粗利率２, 0) as 粗利率２,";
            strSQL += "       a.仕入先コード３,";
            strSQL += "       a.仕入先名３,";
            strSQL += "       ROUND(a.仕入単価３, 0) as 仕入単価３,";
            strSQL += "       ROUND(a.仕入金額３, 0) as 仕入金額３,";
            strSQL += "       ROUND(a.粗利３, 0) as 粗利３,";
            strSQL += "       ROUND(a.粗利率３, 1) as 粗利率３,";
            strSQL += "       a.仕入先コード４,";
            strSQL += "       a.仕入先名４,";
            strSQL += "       ROUND(a.仕入単価４, 0) as 仕入単価４,";
            strSQL += "       ROUND(a.仕入金額４, 0) as 仕入金額４,";
            strSQL += "       ROUND(a.粗利４, 0) as 粗利４,";
            strSQL += "       ROUND(a.粗利率４, 1) as 粗利率４,";
            strSQL += "       a.仕入先コード５,";
            strSQL += "       a.仕入先名５,";
            strSQL += "       ROUND(a.仕入単価５, 0) as 仕入単価５,";
            strSQL += "       ROUND(a.仕入金額５, 0) as 仕入金額５,";
            strSQL += "       ROUND(a.粗利５, 0) as 粗利５,";
            strSQL += "       ROUND(a.粗利率５, 1) as 粗利率５,";
            strSQL += "       a.仕入先コード６,";
            strSQL += "       a.仕入先名６,";
            strSQL += "       ROUND(a.仕入単価６, 0) as 仕入単価６,";
            strSQL += "       ROUND(a.仕入金額６, 0) as 仕入金額６,";
            strSQL += "       ROUND(a.粗利６, 0) as 粗利６,";
            strSQL += "       ROUND(a.粗利率６, 1) as 粗利率６,";
            strSQL += "       a.加工仕入先コード１,";
            strSQL += "       a.加工仕入先名１,";
            strSQL += "       ROUND(a.加工仕入単価１, 0) as 加工仕入単価１,";
            strSQL += "       ROUND(a.加工仕入金額１, 0) as 加工仕入金額１,";
            strSQL += "       ROUND(a.加工粗利１, 0) as 加工粗利１,";
            strSQL += "       ROUND(a.加工粗利率１, 1) as 加工粗利率１,";
            strSQL += "       a.加工仕入先コード２,";
            strSQL += "       a.加工仕入先名２,";
            strSQL += "       ROUND(a.加工仕入単価２, 0) as 加工仕入単価２,";
            strSQL += "       ROUND(a.加工仕入金額２, 0) as 加工仕入金額２,";
            strSQL += "       ROUND(a.加工粗利２, 0) as 加工粗利２,";
            strSQL += "       ROUND(a.加工粗利率２, 1) as 加工粗利率２,";
            strSQL += "       a.加工仕入先コード３,";
            strSQL += "       a.加工仕入先名３,";
            strSQL += "       ROUND(a.加工仕入単価３, 0) as 加工仕入単価３,";
            strSQL += "       ROUND(a.加工仕入金額３, 0) as 加工仕入金額３,";
            strSQL += "       ROUND(a.加工粗利３, 0) as 加工粗利３,";
            strSQL += "       ROUND(a.加工粗利率３, 1) as 加工粗利率３,";
            strSQL += "       a.加工仕入先コード４,";
            strSQL += "       a.加工仕入先名４,";
            strSQL += "       ROUND(a.加工仕入単価４, 0) as 加工仕入単価４,";
            strSQL += "       ROUND(a.加工仕入金額４, 0) as 加工仕入金額４,";
            strSQL += "       ROUND(a.加工粗利４, 0) as 加工粗利４,";
            strSQL += "       ROUND(a.加工粗利率４, 1) as 加工粗利率４,";
            strSQL += "       a.加工仕入先コード５,";
            strSQL += "       a.加工仕入先名５,";
            strSQL += "       ROUND(a.加工仕入単価５, 0) as 加工仕入単価５,";
            strSQL += "       ROUND(a.加工仕入金額５, 0) as 加工仕入金額５,";
            strSQL += "       ROUND(a.加工粗利５, 0) as 加工粗利５,";
            strSQL += "       ROUND(a.加工粗利率５, 1) as 加工粗利率５,";
            strSQL += "       a.加工仕入先コード６,";
            strSQL += "       a.加工仕入先名６,";
            strSQL += "       ROUND(a.加工仕入単価６, 0) as 加工仕入単価６,";
            strSQL += "       ROUND(a.加工仕入金額６, 0) as 加工仕入金額６,";
            strSQL += "       ROUND(a.加工粗利６, 0) as 加工粗利６,";
            strSQL += "       ROUND(a.加工粗利率６, 1) as 加工粗利率６,";
            strSQL += "       a.商品コード,";
            strSQL += "       a.大分類コード,";
            strSQL += "       a.中分類コード,";
            strSQL += "       a.メーカーコード,";
            strSQL += "       ROUND(b.定価, 0) as 定価1,";
            strSQL += "       ROUND(b.定価, 0) as 定価2,";
            strSQL += "       ROUND(b.定価, 0) as 定価3,";
            strSQL += "       a.Ｃ１,";
            strSQL += "       a.Ｃ２,";
            strSQL += "       a.Ｃ３,";
            strSQL += "       a.Ｃ４,";
            strSQL += "       a.Ｃ５,";
            strSQL += "       a.Ｃ６,";
            strSQL += "       a.仕入先名材料２";
            strSQL += "  from 見積明細 as a left join 商品 as b on a.商品コード = b.商品コード and b.削除 = 'N'";
            strSQL += " where a.削除 = 'N'";
            strSQL += "   and a.伝票番号 = " + strNum;
            strSQL += " order by 行番号";

            DBConnective dbCon = new DBConnective();
            try
            {
                dt = dbCon.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public string getDenpyoNo(string tableName)
        {
            List<string> lstTableName = new List<string>();
            lstTableName.Add("@テーブル名");

            List<string> lstDataName = new List<string>();
            lstDataName.Add(tableName);

            string strRet;

            try
            {
                // get伝票番号_PROC"を実行
                strRet = con.RunSqlRe("get伝票番号_PROC", CommandType.StoredProcedure, lstDataName, lstTableName, "@番号");
            }
            catch
            {
                throw;
            }

            return strRet;
        }

        public void updMitsumoriH(List<String> aryPrm)
        {
            List<String> aryCol = new List<string>();

            aryCol.Add("@見積書番号");
            aryCol.Add("@見積年月日");
            aryCol.Add("@標題");
            aryCol.Add("@担当者名");
            aryCol.Add("@納期");
            aryCol.Add("@支払条件");
            aryCol.Add("@有効期限");
            aryCol.Add("@備考");
            aryCol.Add("@得意先コード");
            aryCol.Add("@得意先名称");
            aryCol.Add("@担当者コード");
            aryCol.Add("@営業所コード");
            aryCol.Add("@売上金額");
            aryCol.Add("@粗利額");
            aryCol.Add("@納入先コード");
            aryCol.Add("@納入先名称");
            aryCol.Add("@社内メモ");
            aryCol.Add("@ユーザー名");

            try
            {
                con.RunSql("見積ヘッド更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updMitsumoriM(List<String> aryPrm)
        {
            List<String> aryCol = new List<string>();

            aryCol.Add("@伝票番号");
            aryCol.Add("@行番号");
            aryCol.Add("@商品コード");
            aryCol.Add("@メーカーコード");
            aryCol.Add("@大分類コード");
            aryCol.Add("@中分類コード");
            aryCol.Add("@Ｃ１");
            aryCol.Add("@Ｃ２");
            aryCol.Add("@Ｃ３");
            aryCol.Add("@Ｃ４");
            aryCol.Add("@Ｃ５");
            aryCol.Add("@Ｃ６");
            aryCol.Add("@品名型式");
            aryCol.Add("@数量");
            aryCol.Add("@単位");
            aryCol.Add("@売上単価");
            aryCol.Add("@売上金額");
            aryCol.Add("@仕入単価");
            aryCol.Add("@粗利金額");
            aryCol.Add("@率");
            aryCol.Add("@備考");
            aryCol.Add("@仕入先コード");
            aryCol.Add("@仕入先名");
            aryCol.Add("@印刷フラグ");
            aryCol.Add("@仕入先コード１");
            aryCol.Add("@仕入先名１");
            aryCol.Add("@仕入単価１");
            aryCol.Add("@仕入金額１");
            aryCol.Add("@粗利１");
            aryCol.Add("@粗利率１");
            aryCol.Add("@仕入先コード２");
            aryCol.Add("@仕入先名２");
            aryCol.Add("@仕入単価２");
            aryCol.Add("@仕入金額２");
            aryCol.Add("@粗利２");
            aryCol.Add("@粗利率２");
            aryCol.Add("@仕入先コード３");
            aryCol.Add("@仕入先名３");
            aryCol.Add("@仕入単価３");
            aryCol.Add("@仕入金額３");
            aryCol.Add("@粗利３");
            aryCol.Add("@粗利率３");
            aryCol.Add("@仕入先コード４");
            aryCol.Add("@仕入先名４");
            aryCol.Add("@仕入単価４");
            aryCol.Add("@仕入金額４");
            aryCol.Add("@粗利４");
            aryCol.Add("@粗利率４");
            aryCol.Add("@仕入先コード５");
            aryCol.Add("@仕入先名５");
            aryCol.Add("@仕入単価５");
            aryCol.Add("@仕入金額５");
            aryCol.Add("@粗利５");
            aryCol.Add("@粗利率５");
            aryCol.Add("@仕入先コード６");
            aryCol.Add("@仕入先名６");
            aryCol.Add("@仕入単価６");
            aryCol.Add("@仕入金額６");
            aryCol.Add("@粗利６");
            aryCol.Add("@粗利率６");
            aryCol.Add("@加工仕入先コード１");
            aryCol.Add("@加工仕入先名１");
            aryCol.Add("@加工仕入単価１");
            aryCol.Add("@加工仕入金額１");
            aryCol.Add("@加工粗利１");
            aryCol.Add("@加工粗利率１");
            aryCol.Add("@加工仕入先コード２");
            aryCol.Add("@加工仕入先名２");
            aryCol.Add("@加工仕入単価２");
            aryCol.Add("@加工仕入金額２");
            aryCol.Add("@加工粗利２");
            aryCol.Add("@加工粗利率２");
            aryCol.Add("@加工仕入先コード３");
            aryCol.Add("@加工仕入先名３");
            aryCol.Add("@加工仕入単価３");
            aryCol.Add("@加工仕入金額３");
            aryCol.Add("@加工粗利３");
            aryCol.Add("@加工粗利率３");
            aryCol.Add("@加工仕入先コード４");
            aryCol.Add("@加工仕入先名４");
            aryCol.Add("@加工仕入単価４");
            aryCol.Add("@加工仕入金額４");
            aryCol.Add("@加工粗利４");
            aryCol.Add("@加工粗利率４");
            aryCol.Add("@加工仕入先コード５");
            aryCol.Add("@加工仕入先名５");
            aryCol.Add("@加工仕入単価５");
            aryCol.Add("@加工仕入金額５");
            aryCol.Add("@加工粗利５");
            aryCol.Add("@加工粗利率５");
            aryCol.Add("@加工仕入先コード６");
            aryCol.Add("@加工仕入先名６");
            aryCol.Add("@加工仕入単価６");
            aryCol.Add("@加工仕入金額６");
            aryCol.Add("@加工粗利６");
            aryCol.Add("@加工粗利率６");
            aryCol.Add("@仕入先名材料２");
            aryCol.Add("@ユーザー名");

            try
            {
                con.RunSql("見積明細更新_PROC", CommandType.StoredProcedure, aryPrm, aryCol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delMitsumoriH(string strNum, string strUserName)
        {
            string strSQL = null;

            try
            {
                strSQL = "見積ヘッド削除_PROC '" + strNum + "','" + strUserName + "'";
                con.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void delMitsumoriM(string strNum, string strUserName)
        {
            string strSQL = null;

            try
            {
                strSQL = "見積明細全削除_PROC '" + strNum + "','" + strUserName + "'";
                con.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DataTable getMitsumoriH(List<String> aryPrm)
        {
            DataTable dt = null;

            DBConnective dbCon = new DBConnective();

            try
            {
                List<String> aryCol = new List<string>();

                aryCol.Add("@見積書番号");
                aryCol.Add("@表示フラグ");
                aryCol.Add("@宛先フラグ");
                aryCol.Add("@メーカー印刷フラグ");
                aryCol.Add("@中分類名印刷フラグ");

                dt = dbCon.RunSqlReDT("見積書印刷_PROC", CommandType.StoredProcedure, aryPrm, aryCol, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable getMitsumoriList(string strF, string strT, string strTan, string strTok,
            string strTan2, string strKen, string strBik, string strKat, int s, int iShonin)
        {
            DataTable dt = null;

            string strSQL = "";

            strSQL += "SELECT distinct";
            strSQL += " (CASE a.承認フラグ WHEN '1' THEN '済'  WHEN '9' THEN '否' ELSE '未' END) AS 承認フラグ,";
            strSQL += " a.見積書番号, CONVERT(VARCHAR, a.見積年月日, 111) as 見積年月日,a.得意先コード,a.得意先名称,a.標題,a.売上金額,a.社内メモ,t.担当者名";
            strSQL += " FROM 見積ヘッド a left join 担当者 t on a.担当者コード = t.担当者コード, 見積明細 b";
            strSQL += " WHERE a.削除 = 'N' ";
            strSQL += "   AND a.見積書番号 = b.伝票番号 ";

            if (!string.IsNullOrWhiteSpace(strF))
            {
                strSQL += "   AND CONVERT(VARCHAR, a.見積年月日, 111) >= '" + strF + "/01" + "'";
            }
            if (!string.IsNullOrWhiteSpace(strT))
            {
                strSQL += "   AND CONVERT(VARCHAR, a.見積年月日, 111) <= '" + strT + "/31" + "'";
            }
            if (!string.IsNullOrWhiteSpace(strTan))
            {
                strSQL += "   AND a.担当者コード = '" + strTan + "'";
            }
            if (!string.IsNullOrWhiteSpace(strTok))
            {
                strSQL += "   AND a.得意先コード = '" + strTok + "'";
            }
            if (!string.IsNullOrWhiteSpace(strTan2))
            {
                strSQL += "   AND a.担当者名 like '%" + strTan2 + "%'";
            }
            if (!string.IsNullOrWhiteSpace(strKen))
            {
                strSQL += "   AND a.標題 like '%" + strKen + "%'";
            }
            if (!string.IsNullOrWhiteSpace(strBik))
            {
                strSQL += "   AND (a.備考 like '%" + strBik + "%' OR b.備考 like '%" + strBik + "%')";
            }
            if (!string.IsNullOrWhiteSpace(strKat))
            {
                strSQL += "   AND b.品名型式 like '%" + strKat + "%'";
            }
            if (iShonin == 1)
            {
                strSQL += "   AND a.承認フラグ = '1'";
            }
            else if (iShonin == 2)
            {
                strSQL += "   AND a.承認フラグ = '0'";
            }
            if (s == 1)
            {
                strSQL += " ORDER BY 見積書番号 DESC";
            }
            else
            {
                strSQL += " ORDER BY 得意先コード ASC, 見積書番号 DESC";
            }

            DBConnective dbCon = new DBConnective();
            try
            {
                dt = dbCon.ReadSql(strSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public string updShohinNew(List<string> lstString, Boolean blnKanri)
        {
            //データ渡し用
            List<string> stringSQLAry = new List<string>();

            string strSQLName = null;

            int intNewCd;
            string strNewCd = "99999";

            if (blnKanri == true)
            {
                strSQLName = "C_LIST_Shohin_SELECT_MAXCd";
            }
            else
            {
                strSQLName = "C_LIST_Shohin_SELECT_kari_MAXCd";
            }

            //データ渡し用
            stringSQLAry.Add("Common");
            stringSQLAry.Add(strSQLName);

            DataTable dtSetCd_B = new DataTable();
            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = opensql.setOpenSQL(stringSQLAry);

                if (strSQLInput == "")
                {
                    return null;
                }

                strSQLInput = string.Format(strSQLInput);

                dtSetCd_B = con.ReadSql(strSQLInput);

                char chrNewCdHead = ' ';
                string strNewCdOther = "";

                //中身が空
                if (dtSetCd_B.Rows[0]["最新コード"].ToString() == "")
                {
                    strNewCd = "00001";
                    lstString[0] = strNewCd.ToString();
                }
                //中身がある
                else
                {
                    chrNewCdHead = dtSetCd_B.Rows[0]["最新コード"].ToString().Substring(0, 1)[0];

                    strNewCdOther = dtSetCd_B.Rows[0]["最新コード"].ToString().Substring(1);

                    //先頭以外が9999の場合
                    if (strNewCdOther == "9999")
                    {
                        strNewCdOther = "0001";

                        //先頭が9の場合
                        if (chrNewCdHead == '9')
                        {

                            chrNewCdHead = 'A';
                        }
                        else
                        {
                            //アスキーコード取得、加算
                            int intASCII = chrNewCdHead;
                            intASCII = intASCII + 1;
                            chrNewCdHead = (char)intASCII;
                        }
                        lstString[0] = chrNewCdHead + strNewCdOther;
                    }
                    else
                    {
                        intNewCd = int.Parse(strNewCdOther.ToString());

                        intNewCd = intNewCd + 1;

                        lstString[0] = chrNewCdHead + intNewCd.ToString().PadLeft(4, '0').ToString();
                    }
                }
                addShohin(lstString, blnKanri);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            return lstString[0];
        }

        ///<summary>
        ///addShohin
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addShohin(List<string> lstString, Boolean blnKanri)
        {
            try
            {
                string[] aryStr = new string[] {
                    lstString[0],
                    lstString[1],
                    lstString[2],
                    lstString[3],
                    lstString[4],
                    lstString[5],
                    lstString[6],
                    lstString[7],
                    lstString[8],
                    lstString[9],
                    lstString[10],
                    lstString[11],
                    lstString[12],
                    lstString[13],
                    lstString[14],
                    lstString[15],
                    lstString[16],
                    lstString[17],
                    lstString[18],
                    lstString[19],
                    lstString[20],
                    lstString[21],
                    "N",
                    DateTime.Now.ToString(),
                    lstString[22],
                    DateTime.Now.ToString(),
                    lstString[22]
                };

                if (blnKanri == true)
                {
                    con.RunSqlCommon(CommonTeisu.C_SQL_SHOHIN_UPD, aryStr);
                }
                else
                {
                    con.RunSqlCommon(CommonTeisu.C_SQL_SHOHIN_KARI_UPD, aryStr);
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
        }

        public void updShoninFlg(string stMitsumoriNo, string strFlg, string strMemo)
        {
            string strQuery = "";
            strQuery += "UPDATE 見積ヘッド";
            strQuery += "   SET 承認フラグ = '" + strFlg + "'";
            strQuery += "     , 社内メモ = '" + strMemo + "'";
            strQuery += " WHERE 見積書番号 = " + stMitsumoriNo;
            try
            {
                con.RunSql(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
