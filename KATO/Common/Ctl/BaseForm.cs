using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Common.Ctl
{
    public partial class BaseForm : System.Windows.Forms.Form
    {
        protected bool adminUserFlg = false;
        protected bool powerUserFlg = false;

        private int intMsgCnt = -1;

        private const string defaultMessage = "　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　";
        // ステータスバー用メッセージ
        private string StatusMessage = "";
        public string _StatusMessage
        {
            set
            {
                StatusMessage = value;
            }
            get
            {
                return StatusMessage;
            }
        }

        // 画面タイトル
        private string Title = "";
        public string _Title
        {
            set
            {
                String[] aryTitle = new string[]{value};
                this.Text = string.Format(STR_TITLE, aryTitle);
                Title = this.Text;
            }
            get
            {
                return Title;
            }
        }

        // 大分類（退避用）
        private String strKeepDaibunrui;
        public String StrKeepDaibunrui
        {
            set
            {
                strKeepDaibunrui = value;
            }
            get
            {
                return strKeepDaibunrui;
            }
        }

        // 中分類（退避用）
        private String strKeepChubunrui;
        public String StrKeepChubunrui
        {
            set
            {
                strKeepChubunrui = value;
            }
            get
            {
                return strKeepChubunrui;
            }
        }

        // サブ画面表示用コンボボックス表示フラグ
        private Boolean showSubWinCmbFlg = false;
        public Boolean ShowSubWinCmbFlg
        {
            get {
                return showSubWinCmbFlg;
            }
            set
            {
                showSubWinCmbFlg = value;
                lblSubWinSHow.Visible = showSubWinCmbFlg;
                cmbSubWinShow.Visible = showSubWinCmbFlg;
            }
        }

        // テスト用文字列
        private List<String> strMgsList = new List<String>();

        public BaseForm()
        {
            InitializeComponent();
            // ユーザ名表示
            lblStatusMessage.Text = "";
            lblStatusUser.Text = Environment.UserName;

            // テスト用（後日削除）
            strMgsList.Add("拙者親方と申すは、御立会の内に御存知の御方も御座りましょうが、御江戸を発って二十里上方、相州小田原一色町を御過ぎなされて、青物町を上りへ御出でなさるれば、欄干橋虎屋藤右衛門、只今では剃髪致して圓斎と名乗りまする。");
            strMgsList.Add("元朝より大晦日まで御手に入れまする此の薬は、昔、珍の国の唐人外郎と云う人、我が朝へ来たり。");
            strMgsList.Add("帝へ参内の折から此の薬を深く込め置き、用うる時は一粒ずつ冠の隙間より取り出だす。");
            strMgsList.Add("依ってその名を帝より「透頂香」と賜る。");
            strMgsList.Add("即ち文字には頂き・透く・香と書いて透頂香と申す。");
            strMgsList.Add("只今では此の薬、殊の外、世上に広まり、方々に偽看板を出だし、イヤ小田原の、灰俵の、さん俵の、炭俵のと色々に申せども、平仮名を以って「ういろう」と記せしは親方圓斎ばかり。もしや御立会の内に、熱海か塔ノ沢へ湯治に御出でなさるるか、又は伊勢御参宮の折からは、必ず門違いなされまするな。");
            strMgsList.Add("御上りなれば右の方、御下りなれば左側、八方が八つ棟、面が三つ棟、玉堂造、破風には菊に桐の薹の御紋を御赦免あって、系図正しき薬で御座る。");
            strMgsList.Add("イヤ最前より家名の自慢ばかり申しても、御存知無い方には正真の胡椒の丸呑み、白河夜船、されば一粒食べ掛けて、その気味合いを御目に掛けましょう。先ず此の薬を斯様に一粒舌の上に乗せまして、腹内へ納めますると、イヤどうも言えぬわ、胃・心・肺・肝が健やかに成りて、薫風喉より来たり、口中微涼を生ずるが如し。魚・鳥・茸・麺類の食い合わせ、その他万病即効在る事神の如し。");
        }

        /// <summary>
        /// timer1_Tick
        /// タイマーイベント
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (strMgsList.Count == 0)
            {
                return;
            }

            if (lblStatusMessage.Text.Length == 0)
            {
                if (intMsgCnt < (strMgsList.Count - 1))
                {
                    intMsgCnt++;
                }
                else
                {
                    intMsgCnt = 0;
                }
                lblStatusMessage.Text = defaultMessage + strMgsList[intMsgCnt];
            }

            lblStatusMessage.Text = (lblStatusMessage.Text).Remove(0, 1);
        }

        /// <summary>
        /// timer1_Tick
        /// クローズメソッド
        /// </summary>
        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Dispose();
        }

        // 
        /// <summary>
        /// CreateParams
        /// タイトルバーの閉じるボタン、コントロールボックスの「閉じる」、Alt + F4 を無効
        /// </summary>
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.Demand,
                Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                const int FRM_NOCLOSE = 0x200;
                CreateParams cpForm = base.CreateParams;
                cpForm.ClassStyle = cpForm.ClassStyle | FRM_NOCLOSE;

                return cpForm;
            }
        }

        ///<summary>
        ///delFormClear
        ///フォーム上の項目を初期化(DataGridViewがある場合)
        ///</summary>
        public void delFormClear(Control hParent, DataGridView gridData)
        {
            // hParent 内のすべてのコントロールを列挙する
            foreach (Control cControl in hParent.Controls)
            {
                // 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                if (cControl.HasChildren == true)
                {
                    delFormClear(cControl, gridData);
                }
                // コントロールの型が BaseText からの派生型の場合は BaseText をクリアする
                if (cControl is BaseText)
                {
                    cControl.Text = string.Empty;
                }
                // コントロールの型が BaseTextMoney からの派生型の場合は BaseTextMoney をクリアする
                if (cControl is BaseTextMoney)
                {
                    cControl.Text = string.Empty;
                }

                // コントロールの型が BaseLabelGray からの派生型の場合は BaseLabelGray をクリアする
                if (cControl is BaseLabelGray)
                {
                    cControl.Text = string.Empty;
                }
                // コントロールの型が BaseDataGridView からの派生型の場合は BaseDataGridView をクリアする
                if (cControl is BaseDataGridView)
                {
                    gridData.DataSource = "";
                }
                // コントロールの型が CheckBox からの派生型の場合は CheckBox をクリアする
                if (cControl is CheckBox)
                {
                    CheckBox checkbox = (CheckBox)cControl;
                    checkbox.Checked = false;
                }
                // コントロールの型が ComboBox からの派生型の場合は ComboBox をクリアする
                if (cControl is ComboBox)
                {
                    ComboBox combobox = (ComboBox)cControl;
                    combobox.DataSource = null;
                    combobox.Text = "";
                }
            }
        }

        ///<summary>
        ///delFormClear
        ///フォーム上の項目を初期化(DataGridViewがない場合)
        ///</summary>
        public void delFormClear(Control hParent)
        {
            // hParent 内のすべてのコントロールを列挙する
            foreach (Control cControl in hParent.Controls)
            {
                // 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                if (cControl.HasChildren == true)
                {
                    delFormClear(cControl);
                }

                // コントロールの型が BaseText からの派生型の場合は BaseText をクリアする
                if (cControl is BaseText)
                {
                    cControl.Text = string.Empty;
                }
                // コントロールの型が BaseTextMoney からの派生型の場合は BaseTextMoney をクリアする
                if (cControl is BaseTextMoney)
                {
                    cControl.Text = string.Empty;
                }

                // コントロールの型が BaseLabelGray からの派生型の場合は BaseLabelGray をクリアする
                if (cControl is BaseLabelGray)
                {
                    cControl.Text = string.Empty;
                }
                // コントロールの型が CheckBox からの派生型の場合は CheckBox をクリアする
                if (cControl is CheckBox)
                {
                    CheckBox checkbox = (CheckBox)cControl;
                    checkbox.Checked = false;
                }
                // コントロールの型が ComboBox からの派生型の場合は ComboBox をクリアする
                if (cControl is ComboBox)
                {
                    //コンボボックスの初期化                    
                    ComboBox combobox = (ComboBox)cControl;
                    combobox.DataSource = null;
                    combobox.Text = "";
                }
            }
        }

        ///<summary>
        ///BaseForm_Load
        ///フォームロード
        ///</summary>
        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Enter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Cyan;
        }

        private void btn_Leave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = SystemColors.Control;
        }
    }
}
