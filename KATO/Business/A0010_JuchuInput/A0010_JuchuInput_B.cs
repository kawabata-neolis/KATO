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
