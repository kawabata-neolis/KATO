using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace KATO.Common.Util
{
    class OpenSQL
    {
        ///<summary>
        ///setOpenSQL
        ///SQL文ファイルの取り出し
        ///</summary>
        public string setOpenSQL(List<string> lstStringSQL)
        {
            StreamReader ReadFile = null;

            string BaseFilePath = "";

            Encoding UTF8_Enc = null;

            try
            {
                //フォルダ直下の場合とフォルダ分けした先にある場合
                if (lstStringSQL.Count == 1)
                {
                    BaseFilePath = "../../SQL/" + lstStringSQL[0] + ".sql";
                }
                else if (lstStringSQL.Count == 2)
                {
                    BaseFilePath = "../../SQL/" + lstStringSQL[0] + "/" + lstStringSQL[1] + ".sql";
                }
                else if (lstStringSQL.Count == 3)
                {
                    BaseFilePath = "../../SQL/" + lstStringSQL[0] + "/" + lstStringSQL[1] + "/" + lstStringSQL[2] + ".sql";
                }

                //UTF - 8
                UTF8_Enc = new UTF8Encoding(true);

                ReadFile = new StreamReader(BaseFilePath, UTF8_Enc);

                string SqlText = ReadFile.ReadToEnd();

                return(SqlText);
            }
            catch
            {
                return("");
            }
            finally
            {
                ReadFile.Close();
                ReadFile.Dispose();
            }
        }
    }
}
