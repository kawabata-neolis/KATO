using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Common.Util
{
    class LogUtil
    {
        public static string getMessage(String title, String value)
        {
            string strRet  = "";
            string strUser = "";

            if (Environment.UserName != null)
            {
                strUser = Environment.UserName;
            }

            strRet = strUser + "\t" + title + "\t"+ value;

            return strRet;
        }
    }
}
