using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    }
}
