using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Common.Util
{
    class CommonException
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CommonException(Exception e)
        {
            logger.Info(LogUtil.getMessage(e.Source, "例外処理が発生"));
            logger.Error(LogUtil.getMessage(e.Source, e.Message));
            logger.Debug(LogUtil.getMessage(e.Source, e.StackTrace));
        }
    }
}
