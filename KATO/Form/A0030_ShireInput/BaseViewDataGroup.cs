using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Form.A0030_ShireInput
{
    public partial class BaseViewDataGroup : UserControl
    {
        public BaseViewDataGroup()
        {
            InitializeComponent();
        }

        ///<summary>
        ///delData
        ///入力項目削除
        ///</summary>
        public void delData()
        {
            txtNo.Clear();
            txtChumonNo.Clear();
            txtHin.Clear();
            txtSu.Clear();
            txtTanka.Clear();
            txtKin.Clear();
            txtBiko.Clear();
            labelSet_Eigyosho.codeTxt.Clear();
            txtTeka.Clear();
            txtShireritsu.Clear();
            txtChokinTanka.Clear();
            txtMasterTanka.Clear();
            txtTokuisaki.Clear();
        }
    }
}
