using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.D0680_UriageJissekiKakuninAS400
{
    ///<summary>
    ///D0680_UriageJissekiKakuninAS400_B
    ///売上実績確認(AS400)
    ///作成者：
    ///作成日：2017/3/23
    ///更新者：
    ///更新日：2017/4/7
    ///カラム論理名
    ///</summary>
    class D0680_UriageJissekiKakuninAS400_B
    {
        /// <summary>
        /// getUriageJissekiList
        /// 売上実績を取得
        /// </summary>
        public DataTable getUriageJissekiList(List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();
            string strSQLInput = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            //SQL文 商品別利益率

            strSQLInput = strSQLInput + " SELECT ";
            strSQLInput = strSQLInput + " 処理日付 ";
            strSQLInput = strSQLInput + " , 伝票番号 ";
            strSQLInput = strSQLInput + " , RTRIM(ISNULL(手打品名, '')) + ' ' + Rtrim(ISNULL(型番, '')) + ' ' + Rtrim(ISNULL(枝, '')) AS 型番 ";
            strSQLInput = strSQLInput + " , 数量 ";
            strSQLInput = strSQLInput + " , 売上単価 ";
            strSQLInput = strSQLInput + " , 売上金額 ";
            strSQLInput = strSQLInput + " , 備考 ";
            strSQLInput = strSQLInput + " , 摘要 ";
            strSQLInput = strSQLInput + " , 得意先名 ";

            strSQLInput = strSQLInput + " FROM ";
            strSQLInput = strSQLInput + " AS400売上明細  ";

            strSQLInput = strSQLInput + " WHERE ";
            strSQLInput = strSQLInput + " 処理日付 >= '"+lstString[0]+"' ";
            strSQLInput = strSQLInput + " AND 処理日付 <= '" + lstString[1] + "' ";

            //得意先コードを記述した場合
            if (lstString[2] != "")
            {
                strSQLInput = strSQLInput + " AND 得意先コード = '" + lstString[2] + "' ";
            }

            //型番を記述した場合
            if (lstString[3] != "")
            {
                strSQLInput = strSQLInput + " AND (RTRIM(ISNULL(手打品名,'')) + Rtrim(ISNULL(型番,'')) + Rtrim(ISNULL(枝,'')) ) LIKE '%"+lstString[3]+"%' ";
            }

            //備考を記述した場合
            if (lstString[4] != "")
            {
                strSQLInput = strSQLInput + " AND ( 備考 LIKE '%"+lstString[4]+"%' OR 摘要 LIKE '%"+lstString[4]+"%') ";
            }

            strSQLInput = strSQLInput + " ORDER BY 処理日付 DESC, 伝票番号 ";


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
            return (dtGetTableGrid);
        }
    }
}
