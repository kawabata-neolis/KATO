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
        ///作成者：大河内
        ///作成日：2017/3/22
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
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
                else
                {
                    BaseFilePath = "../../SQL/" + lstStringSQL[0] + "/" + lstStringSQL[1] + ".sql";
                }

                //UTF - 8
                UTF8_Enc = new UTF8Encoding(true);

                ReadFile = new StreamReader(BaseFilePath, UTF8_Enc);

                string SqlText = ReadFile.ReadToEnd();

                return(SqlText);
            }
            catch
            {
                MessageBox.Show("エラー発生", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
