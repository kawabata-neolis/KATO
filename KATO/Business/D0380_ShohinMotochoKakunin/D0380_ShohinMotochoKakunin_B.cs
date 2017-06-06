using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.D0380_ShohinMotochoKakunin;

namespace KATO.Business.D0380_ShohinMotochoKakunin
{
    ///<summary>
    ///D0380_ShohinMotochoKakunin_B
    ///商品元帳確認フォーム
    ///作成者：大河内
    ///作成日：2017/3/23
    ///更新者：大河内
    ///更新日：2017/4/7
    ///カラム論理名
    ///</summary>
    class D0380_ShohinMotochoKakunin_B
    {
        ///<summary>
        ///setTxtBox
        ///検索データを記入
        ///</summary>
        public List<string> setTextBox(List<string> lstString)
        {
            List<string> lstStringSet = new List<string>();

            System.DateTime dateStartYMD;
            System.DateTime dateEndYMD;
            System.DateTime dateZenYMD;

            string strSQL;

            decimal decWSu1;
            decimal decWSu2;
            decimal decWSu3;
            decimal decWSu1_2;
            decimal decWSu2_2;
            decimal decWSu3_2;

            decimal decNyukoSu1;
            decimal decNyukoSu2;
            decimal decNyukoSu1_2;
            decimal decNyukoSu2_2;
            decimal decNyukoSu3;
            decimal decNyukoSu3_2;

            decimal decNyukoSu4;
            decimal decNyukoSu4_2;

            DataTable dtView;

            string strEigyosyo1;
            string strEigyosyo2;

            int intData = 0;

            strEigyosyo1 = "0001";
            strEigyosyo2 = "0002";

            dateStartYMD = DateTime.Parse(lstString[2] + "/01");

            dateEndYMD = DateTime.Parse(lstString[3] + "/01");

            dateEndYMD = dateEndYMD.AddMonths(1);
            dateEndYMD = dateEndYMD.AddDays(-1);

            dateZenYMD = dateStartYMD.AddDays(-1);


            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {

                //本社　前月在庫
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定日の在庫数( '" + strEigyosyo1 + "','" + lstString[0] + "','" + dateZenYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }

                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));
                if (intData != 0)
                {
                    lstStringSet.Add(intData.ToString() + ".00");
                }
                else
                {
                    lstStringSet.Add("0.00");
                }

                //岐阜　前月在庫
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定日の在庫数( '" + strEigyosyo2 + "','" + lstString[0] + "','" + dateZenYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }

                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));
                if (intData != 0)
                {
                    lstStringSet.Add(intData.ToString() + ".00");
                }
                else
                {
                    lstStringSet.Add("0.00");
                }

                //本社　入庫 1
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_仕入数量_仕入明細( '" + strEigyosyo1 + "','" + lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }

                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));
                if (intData != 0)
                {
                    decNyukoSu1 = intData;
                }
                else
                {
                    decNyukoSu1 = 0;
                }

                //岐阜　入庫 1
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_仕入数量_仕入明細( '" + strEigyosyo2 + "','" + lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }

                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));
                if (intData != 0)
                {
                    decNyukoSu1_2 = intData;
                }
                else
                {
                    decNyukoSu1_2 = 0;
                }

                //本社　入庫 2
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_移動入数_倉庫間移動( '" + strEigyosyo1 + "','" + lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }

                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));
                if (intData != 0)
                {
                    decNyukoSu2 = intData;
                }
                else
                {
                    decNyukoSu2 = 0;
                }

                //岐阜　入庫 2
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_移動入数_倉庫間移動( '" + strEigyosyo2 + "','" + lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decNyukoSu2_2 = intData;
                }
                else
                {
                    decNyukoSu2_2 = 0;
                }

                //本社　入庫 3
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_棚卸調整数_棚卸調整( '" + strEigyosyo1 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");

                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decNyukoSu3 = intData;
                }
                else
                {
                    decNyukoSu3 = 0;
                }

                //岐阜　入庫 3
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_棚卸調整数_棚卸調整( '" + strEigyosyo2 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decNyukoSu3_2 = intData;
                }
                else
                {
                    decNyukoSu3_2 = 0;
                }

                //本社　入庫 4
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_入庫数量_出庫明細( '" + strEigyosyo1 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decNyukoSu4 = intData;
                }
                else
                {
                    decNyukoSu4 = 0;
                }

                //岐阜　入庫 4
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_入庫数量_出庫明細( '" + strEigyosyo2 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decNyukoSu4_2 = intData;
                }
                else
                {
                    decNyukoSu4_2 = 0;
                }

                //本社　出庫 1
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_売上数量_売上明細( '" + strEigyosyo1 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu1 = intData;
                }
                else
                {
                    decWSu1 = 0;
                }

                //岐阜　出庫 2
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_売上数量_売上明細( '" + strEigyosyo2 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu1_2 = intData;
                }
                else
                {
                    decWSu1_2 = 0;
                }

                //本社　出庫 2
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_出庫数量_出庫明細( '" + strEigyosyo1 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu2 = intData;
                }
                else
                {
                    decWSu2 = 0;
                }

                //岐阜　出庫 2
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_出庫数量_出庫明細( '" + strEigyosyo2 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu2_2 = intData;
                }
                else
                {
                    decWSu2_2 = 0;
                }

                //本社　出庫 3
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_移動出数_倉庫間移動( '" + strEigyosyo1 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu3 = intData;
                }
                else
                {
                    decWSu3 = 0;
                }

                //岐阜　出庫 3
                strSQL = "";
                dtView = dbconnective.ReadSql("SELECT dbo.f_get指定期間_移動出数_倉庫間移動( '" + strEigyosyo2 + "','" +  lstString[0] + "','" + dateStartYMD + "','" + dateEndYMD + "')");
                if (dtView.Rows.Count < 0)
                {
                    return(lstStringSet);
                }
                intData = decimal.ToInt32(Decimal.Parse(dtView.Rows[0]["Column1"].ToString()));

                if (intData != 0)
                {
                    decWSu3_2 = intData;
                }
                else
                {
                    decWSu3_2 = 0;
                }

                //計算枠
                lstStringSet.Add((decNyukoSu1 + decNyukoSu2 + decNyukoSu3 + decNyukoSu4).ToString());
                lstStringSet.Add((decNyukoSu1_2 + decNyukoSu2_2 + decNyukoSu3_2 + decNyukoSu4_2).ToString());
                lstStringSet.Add((decWSu1 + decWSu2 + decWSu3).ToString());
                lstStringSet.Add((decWSu1_2 + decWSu2_2 + decWSu3_2).ToString());
                lstStringSet.Add((Decimal.Parse(lstStringSet[0]) + Decimal.Parse(lstStringSet[2]) - Decimal.Parse(lstStringSet[4])).ToString());
                lstStringSet.Add((Decimal.Parse(lstStringSet[1]) + Decimal.Parse(lstStringSet[3]) - Decimal.Parse(lstStringSet[5])).ToString());

                return(lstStringSet);
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
        }
    }
}
