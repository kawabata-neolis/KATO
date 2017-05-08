using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;


namespace KATO.Business.JuchuInput
{
    class JuchuInput_B
    {
        public DataTable baseText1_Leave(string strBaseText1)
        {
            string strSQLName = null;

            //�f�[�^�n���p
            List<string> lstStringSQL = new List<string>();

            strSQLName = "JuchuInput_Chubun_SELECT_LEAVE";

            //�f�[�^�n���p
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //�z��ݒ�
            string[] strArray = { strBaseText1 };

            strSQLInput = string.Format(strSQLInput, strArray);

            //SQL�̃C���X�^���X�쐬
            DBConnective dbconnective = new DBConnective();

            DataTable dtSetcode_B = new DataTable();

            //SQL���𒼏����i�{�߂�l���󂯎��)
            dtSetcode_B = dbconnective.ReadSql(strSQLInput);

            return (dtSetcode_B);
        }
    }
}
