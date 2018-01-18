using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Form.H0210_MitsumoriInput
{
    public partial class UserControl2 : UserControl
    {
        public string strRow = null;
        public string strShohinCd = null;

        public string strC1 = null;
        public string strC2 = null;
        public string strC3 = null;
        public string strC4 = null;
        public string strC5 = null;
        public string strC6 = null;

        public string strSuryo = null;
        public string strTanni = null;
        public string strMitsuTanka = null;
        public string strKin = null;
        public string strShiireKin = null;
        public string strArariKin = null;
        public string strArariritsuKin = null;
        public string strBiko = null;
        public string strShiireCd = null;
        public string strShiiName = null;
        public string strPrint = null;

        public string strShiireCd1 = null;
        public string strShiireName1 = null;
        public string strShiireTanka1 = null;
        public string strShiireKin1 = null;
        public string strShiireArari1 = null;
        public string strShiireRitsu1 = null;

        public string strShiireCd2 = null;
        public string strShiireName2 = null;
        public string strShiireTanka2 = null;
        public string strShiireKin2 = null;
        public string strShiireArari2 = null;
        public string strShiireRitsu2 = null;

        public string strShiireCd3 = null;
        public string strShiireName3 = null;
        public string strShiireTanka3 = null;
        public string strShiireKin3 = null;
        public string strShiireArari3 = null;
        public string strShiireRitsu3 = null;

        public DataGridViewCell cD = null;
        public DataGridViewCell cC = null;
        public DataGridViewCell cM = null;

        //public string strShiireCd4 = null;
        //public string strShiireName4 = null;
        //public string strShiireTanka4 = null;
        //public string strShiireKin4 = null;
        //public string strShiireArari4 = null;
        //public string strShiireRitsu4 = null;

        //public string strShiireCd5 = null;
        //public string strShiireName5 = null;
        //public string strShiireTanka5 = null;
        //public string strShiireKin5 = null;
        //public string strShiireArari5 = null;
        //public string strShiireRitsu5 = null;

        //public string strShiireCd6 = null;
        //public string strShiireName6 = null;
        //public string strShiireTanka6 = null;
        //public string strShiireKin6 = null;
        //public string strShiireArari6 = null;
        //public string strShiireRitsu6 = null;


        public UserControl2(DataGridViewCell d, DataGridViewCell c, DataGridViewCell m)
        {
            cD = d;
            cC = c;
            cM = m;
            InitializeComponent();

            lsDaibun.Lschubundata = lsChubun;
            lsDaibun.Lsmakerdata = lsMaker;
        }
        
    }
}
