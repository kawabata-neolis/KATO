using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.A1520_Uriageshonin_B
{
    ///<summary>
    ///A1520_Uriageshonin_B
    ///売上承認のビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class A1520_Uriageshonin_B
    {
        ///<summary>
        ///getViewGridHenpin
        ///返品値引分売上承認入力データの取得
        ///</summary>
        public DataTable getViewGridHenpin(int intShonin)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //分岐WHERE分用
            string strShonin = "";

            //表示範囲によって分岐
            if (intShonin == 0)
            {
                strShonin = "";
            }
            else if (intShonin == 1)
            {
                strShonin = "AND dbo.f_get返品値引売上承認フラグ(受注番号)=0";
            }
            else
            {
                strShonin = "AND dbo.f_get返品値引売上承認フラグ(受注番号)=1";
            }

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A1520_Uriageshonin");
            lstSQL.Add("Uriageshonin_SELECT_Henpin");

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
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strShonin);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
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
