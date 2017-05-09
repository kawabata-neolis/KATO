using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Boolean good = true;

            if (strText == "" || String.IsNullOrWhiteSpace(strText).Equals(true))
            {
                good = false;
            }
            return (good);
        }

        //
        //カレンダーのチェック
        //
        public static bool JudCalenderCheck(string strData)
        {
            Boolean good = true;
            DateTime datiSub;

            if (DateTime.TryParse(strData, out datiSub) == false)
            {
                good = false;
            }
            return (good);
        }

        //
        //禁止文字チェック（個々を呼び出す形になるのでまとめて処理できるように）(戻り値はboolean）
        //
        public static bool JudBanChar(string strData)
        {
            Boolean good = true;

            //ファイル名に使用できない文字を取得
            char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();

            if (strData.IndexOfAny(invalidChars) > 0)
            {
                good = false;
            }
            return (good);
        }
    }
}
