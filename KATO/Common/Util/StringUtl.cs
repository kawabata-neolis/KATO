using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace KATO.Common.Util
{
    static class StringUtl
    {
        //
        //文字判定
        //
        //名前修正
        public static bool blIsEmpty(string strText)
        {
            Boolean blnGood = false;

            if (String.IsNullOrWhiteSpace(strText).Equals(false))
            {
                blnGood = true;
            }
            return (blnGood);
        }

        //
        //カレンダーのチェック
        //
        public static bool JudCalenderCheck(string strData)
        {
            Boolean blnGood = true;
            DateTime datiSub;

            if (DateTime.TryParse(strData, out datiSub) == false)
            {
                blnGood = false;
            }
            return (blnGood);
        }

        //
        //禁止文字チェック（ファイル名に使用できない文字）
        //
        public static bool JudBanChr(string strData)
        {
            Boolean blnGood = true;

            //ファイル名に使用できない文字を取得
            char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();

            //ファイル名に使用できない文字でチェック
            if (strData.IndexOfAny(invalidChars) > 0)
            {
                blnGood = false;
            }
            return (blnGood);
        }

        //
        //禁止文字チェック（選択された禁止文字）
        //
        public static bool JudBanSelect(string strData, string strBanSelect)
        {
            Boolean blnGood = true;

            //選択した禁止文字でチェック
            Regex regex = new Regex(strBanSelect);
            if (!regex.IsMatch(strData))
            {
                blnGood = false;
            }
            return (blnGood);
        }

        //
        //四捨五入させる
        //
        public static string updShishagonyu(string strData, int intShisyagonyu)
        { 
            Decimal d = Convert.ToDecimal(strData);
            strData = Convert.ToString(Decimal.Round(d, intShisyagonyu, MidpointRounding.AwayFromZero));

            return (strData);
        }

        //
        //切り上げさせる
        //
        public static string updKiriage(string strData)
        {
            Decimal d = Convert.ToDecimal(strData);
            strData = Convert.ToString(Decimal.Ceiling(d));

            return (strData);
        }

        //
        //切り捨て
        //
        public static string updKirisute(string strData)
        {
            Decimal d = Convert.ToDecimal(strData);
            strData = Convert.ToString(Decimal.Floor(d));

            return (strData);
        }

        /// <summary>
        ///     SQL禁則文字チェック</summary>
        /// <param name="strData">
        ///     チェック対象文字列</param>
        /// <returns>
        ///     禁止文字が含まれていた場合"false"を返す</returns>
        public static bool JudBanSQL(string strData)
        {
            bool result = true;

            string[] arrBanChar = { "`", ".", "!", "[", "]", "\"", @"*", @"?" }; 

            for (int arrCnt = 0; arrCnt < arrBanChar.Length; arrCnt++)
            {
                if (0 <= strData.IndexOf(arrBanChar[arrCnt]))
                {
                    result = false;
                    break;
                }
                
            }

            return result;
        }

        /// <summary>
        ///     全角数字から半角数字変換</summary>
        /// <param name="strData">
        ///     チェック対象文字列</param>
        /// <returns>
        ///     全角数字を半角数字に変換する</returns>
        public static string JudZenToHanNum(string strData)
        {
            return Regex.Replace(strData, "[０-９]", p => ((char)(p.Value[0] - '０' + '0')).ToString());
        }

        ///
        ///画面Noから日付範囲チェックをする
        ///
        public static bool judHidukeCheck(string strGamenID, string strEigyoshoCd, DateTime dateYMD)
        {
            bool blCheck = false;

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_GDateCheckEG");

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
                    return (blCheck);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strGamenID, strEigyoshoCd);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //行がある場合
                if (dtSetCd_B.Rows.Count > 0)
                {
                    //チェックデータが取り出しデータの範囲内の場合
                    if (DateTime.Parse(dtSetCd_B.Rows[0][0].ToString()) < dateYMD && dateYMD < DateTime.Parse(dtSetCd_B.Rows[0][1].ToString()))
                    {
                        blCheck = true;
                    }
                    else
                    {
                        blCheck = false;
                    }
                }
                return (blCheck);
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
