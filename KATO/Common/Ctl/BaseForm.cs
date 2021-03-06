﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using static KATO.Common.Util.CommonTeisu;
using KATO.Common.Business;
using System.Data;
using KATO.Common.Util;

namespace KATO.Common.Ctl
{
    /// <summary>
    /// BaseForm
    /// ベースフォーム
    /// 作成者：大河内
    /// 作成日：2017/02/21
    /// 更新者：
    /// 更新日：
    /// </summary>
    public partial class BaseForm : System.Windows.Forms.Form
    {
        //ToDo:権限使用画面の修正後に削除(大河内)
        //マスタ権限
        protected bool masterUserflg = false;
        //閲覧権限
        protected bool powerUserFlg = false;
        //利益率権限
        protected bool riekiUserFlg = false;

        protected string masterFlg = "";     // マスタ権限
        protected string etsuranFlg = "";    // 閲覧権限
        protected string riekiritsuFlg = ""; // 利益率権限
        protected string adminFlg = "";      // 開発者権限
        protected string eigyoCode = "";     // 営業所コード
        protected string groupCode = "";     // グループコード

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

        private int _printFlg = -1;
        public int printFlg
        {
            get
            {
                return _printFlg;
            }
            set
            {
                _printFlg = value;
            }
        }

        // テスト用文字列
        private List<String> strMgsList = new List<String>();

        /// <summary>
        /// BaseForm
        /// フォームの初期設定
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
            // ユーザ名表示
            lblStatusMessage.Text = "";
            lblStatusUser.Text = Environment.UserName;            
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

        /// <summary>
        /// delFormClear
        /// フォーム上の項目を初期化(DataGridViewがある場合)
        /// </summary>
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

        /// <summary>
        /// delFormClear
        /// フォーム上の項目を初期化(DataGridViewがない場合)
        /// </summary>
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

        /// <summary>
        /// BaseForm_Load
        /// フォームロード
        /// </summary>
        private void BaseForm_Load(object sender, EventArgs e)
        {
            // ユーザ名取得
            string strUserId = Environment.UserName;
            try
            {
                // 権限取得
                Tantosya_Kengen tk = new Tantosya_Kengen(strUserId);
                masterFlg = tk.master;
                etsuranFlg = tk.etsuran;
                riekiritsuFlg = tk.riekiritsu;
                adminFlg = tk.admin;
                eigyoCode = tk.eigyocd;
                groupCode = tk.groupcd;
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

        }

        /// <summary>
        /// btn_Enter
        /// エンターキーイベントハンドラ
        /// </summary>
        private void btn_Enter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Cyan;
        }

        /// <summary>
        /// btn_Leave
        /// Leaveイベントハンドラ
        /// </summary>
        private void btn_Leave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = SystemColors.Control;
        }

        /// <summary>
        /// form_KeyPress
        /// KeyPressイベントハンドラ
        /// </summary>
        private void form_KeyPress(object sender, KeyPressEventArgs e)
        {
            //EnterやEscapeキーでビープ音が鳴らないようにする
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }
        }
    }
}
