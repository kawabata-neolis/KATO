using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.M1070_Torihikisaki;

namespace KATO.Common.Business
{
    ///<summary>
    ///TorihikiCdList
    ///取引コードリスト
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class TorihikiCdList_B
    {
        /// <summary>
        /// setEndAction
        /// 終了時の処理
        /// </summary>
        public void setEndAction(List<int> lstInt)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //目的のフォームを探す
                if (lstInt[0] == 12 && frm.Name.Equals("M1070_Torihikisaki"))
                {
                    //データを連れてくるため、newをしないこと
                    M1070_Torihikisaki torihikisaki = (M1070_Torihikisaki)frm;
                    torihikisaki.setTorihikiCdListClose();
                    break;
                }
            }
        }

        ///<summary>
        ///setKensaku
        ///検索時の処理
        ///</summary>
        public DataTable setKensaku(List<Boolean> lstBoolean)
        {
            DataTable dtGetTableGrid = new DataTable();

            DataTable dtSelectMin = new DataTable();
            DataTable dtSelectMax = new DataTable();


            string strSQL;
            string kana = "ｱ";
            string MinCode;
            string MaxCode;

            if (lstBoolean[0] == true)
              kana = "ｱ";
            if (lstBoolean[1] == true)
              kana = "ｶ";
            if (lstBoolean[2] == true)
              kana = "ｻ";
            if (lstBoolean[3] == true)
              kana = "ﾀ";
            if (lstBoolean[4] == true)
              kana = "ﾅ";
            if (lstBoolean[5] == true)
              kana = "ﾊ";
            if (lstBoolean[6] == true)
              kana = "ﾏ";
            if (lstBoolean[7] == true)
              kana = "ﾔ";
            if (lstBoolean[8] == true)
              kana = "ﾗ";
            if (lstBoolean[9] == true)
              kana = "ﾜ";

            MinCode = "1101";
            MaxCode = "9999";

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                strSQL = "";
                //strSQL = strSQL + " 取引先コード検索_PROC ";
                strSQL = strSQL + " SELECT MIN(取引先コード) ";
                strSQL = strSQL + " FROM 取引先コード検索";
                strSQL = strSQL + " WHERE カナ LIKE '" + kana + "%'";

                dtSelectMin = dbconnective.ReadSql(strSQL);

                if (dtSelectMin.Rows.Count > 0)
                {
                    MinCode = dtSelectMin.Rows[0][0].ToString();
                }

                strSQL = "";
                //strSQL = strSQL + " 取引先コード検索_PROC ";
                strSQL = strSQL + " SELECT MAX(取引先コード) ";
                strSQL = strSQL + " FROM 取引先コード検索";
                strSQL = strSQL + " WHERE カナ LIKE '" + kana + "%'";

                dtSelectMax = dbconnective.ReadSql(strSQL);

                if (dtSelectMax.Rows.Count > 0)
                {
                    MinCode = dtSelectMax.Rows[0][0].ToString();
                }

                string StrWhere;
                StrWhere = "";
                StrWhere = StrWhere + " 取引先コード >= '" + MinCode + "'";
                StrWhere = StrWhere + " AND 取引先コード <= '" + MaxCode + "'";
                StrWhere = StrWhere + " AND 取引先名称 is NULL  ";
                StrWhere = " SELECT 取引先コード FROM 取引先コード検索 WHERE " + StrWhere + "ORDER BY 取引先コード ASC";

                dtGetTableGrid = dbconnective.ReadSql(StrWhere);
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
