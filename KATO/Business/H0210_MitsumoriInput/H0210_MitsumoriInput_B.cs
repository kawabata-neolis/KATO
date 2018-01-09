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
        public DataTable getMitsumoriInfo(string strNum)
        {
            DataTable dt = null;

            string strSQL = "";
            strSQL += "SELECT ";
            strSQL += " 見積年月日,標題,担当者名,納期,支払条件,有効期限,備考,";
            strSQL += " 得意先コード,得意先名称,担当者コード,営業所コード,";
            strSQL += " 売上金額,納入先コード,納入先名称  ";
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

            strSQL += "SELECT ";
            strSQL += " 行番号,商品コード,メーカーコード,大分類コード,中分類コード,";
            strSQL += " Ｃ１, Ｃ２, Ｃ３,Ｃ４, Ｃ５,Ｃ６, ";
            strSQL += " 品名型式,数量,単位, 売上単価, 売上金額,仕入単価, 粗利金額,率,備考,仕入先コード,仕入先名,印刷フラグ, ";
            strSQL += " 仕入先コード１,仕入先名１,仕入単価１,仕入金額１,粗利１,粗利率１,仕入先コード２,仕入先名２, 仕入単価２,仕入金額２,粗利２,粗利率２,仕入先コード３,仕入先名３,仕入単価３,仕入金額３,粗利３,粗利率３";
            strSQL += " FROM 見積明細 ";
            strSQL += " WHERE 削除 = 'N' ";
            strSQL += " AND 伝票番号=" + strNum;
            strSQL += " ORDER BY 行番号";

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
    }
}
