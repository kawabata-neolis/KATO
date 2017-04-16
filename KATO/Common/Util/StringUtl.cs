using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Common.Util
{
    class StringUtl
    {
        //
        //文字判定
        //
        public bool blIsEmpty(string strText)
        {
            Boolean good = true;

            if (strText == "" || String.IsNullOrWhiteSpace(strText).Equals(true))
            {
                good = false;
            }
            return (good);
        }
    }
}
