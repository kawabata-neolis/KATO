using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Ctl;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.Z1500_MyMenuSet;
using KATO.Common.Util;
using KATO.Form;

namespace KATO.Form.Z1500_MyMenuSet
{
    ///<summary>
    ///Z1500_MyMenuSet
    ///マイメニュー
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class Z1500_MyMenuSet : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        Control cActiveBefore = null;

        //エラーメッセージを表示したかどうか
        bool blMessageOn = false;

        ///<summary>
        ///Z1500_MyMenuSet
        ///フォームの初期設定
        ///</summary>
        public Z1500_MyMenuSet(Control c)
        {
            //画面データが解放されていた時の対策
            if (c == null)
            {
                return;
            }

            //画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //最大化最小化不可
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //画面サイズを固定
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;

            //初期化
            delFormClear(this);
        }

        ///<summary>
        ///Z1500_MyMenuSet_Load
        ///画面レイアウト設定
        ///</summary>
        private void Z1500_MyMenuSet_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "マイメニューセット";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF12.Text = STR_FUNC_F12;

            //ユーザーIDの取得
            string strUserID = SystemInformation.UserName;

            DataTable dtGetData;

            //指定したＩＤ
            strUserID = "master";

            //TabControlをオーナードローする
            lblP2Text.DrawMode = TabDrawMode.OwnerDrawFixed;
            //DrawItemイベントハンドラを追加
            lblP2Text.DrawItem += new DrawItemEventHandler(TabControl1_DrawItem);

            Z1500_MyMenuSet_B mymenusetB = new Z1500_MyMenuSet_B();
            try
            {
                dtGetData = mymenusetB.getMenuSet(strUserID);

                int intLabelSetCnt = 1;

                //データが一つ以上ある場合
                if (dtGetData.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtGetData.Rows)
                    {
                        if (int.Parse(dr.ItemArray[0].ToString()) < 1000)
                        {
                            //どこのラベルセットに入れるか取得
                            Control[] cs = this.Controls.Find("labelSet_Menu" + intLabelSetCnt, true);

                            //ラベルセットに配置
                            ((LabelSet_Menu)cs[0]).CodeTxtText = dr.ItemArray[1].ToString();
                            ((LabelSet_Menu)cs[0]).ValueLabelText = dr.ItemArray[2].ToString();
                        }
                        intLabelSetCnt++;
                    }
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        ///<summary>
        ///TabControl1_DrawItem
        ///TabControl1のDrawItemイベントハンドラ
        ///</summary>
        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //対象のTabControlを取得
            TabControl tab = (TabControl)sender;
            //タブページのテキストを取得
            string txt = tab.TabPages[e.Index].Text;

            //タブのテキストと背景を描画するためのブラシを決定する
            Brush foreBrush, backBrush;
            //FontStyle fontText;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //選択されているタブのテキストを赤、背景を青とする
                foreBrush = Brushes.Black;
                backBrush = Brushes.WhiteSmoke;
            }
            else
            {
                //選択されていないタブのテキストは灰色、背景を白とする
                foreBrush = Brushes.Black;
                backBrush = Brushes.WhiteSmoke;
            }

            //StringFormatを作成
            StringFormat sf = new StringFormat();
            //中央に表示する
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //背景の描画
            e.Graphics.FillRectangle(backBrush, e.Bounds);
            //Textの描画
            e.Graphics.DrawString(txt, e.Font, foreBrush, e.Bounds, sf);
        }

        ///<summary>
        ///judMyMenuKeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void judMyMenuKeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    break;
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                case Keys.Enter:
                    break;
                case Keys.F1:
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addMyMenu();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judBtnClick
        ///ファンクションボタンの反応
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    this.addMyMenu();
                    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///addMyMenu
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addMyMenu()
        {
            //フォーカス位置の確保
            cActiveBefore = this.ActiveControl;

            //一度登録ボタンに移動して各データをチェック
            btnF01.Focus();

            //エラーメッセージを表示したかどうか
            if (blMessageOn == true)
            {
                //元のフォーカスに移動
                cActiveBefore.Focus();
                return;
            }

            //ビジネス層のインスタンス生成
            Z1500_MyMenuSet_B mymenuB = new Z1500_MyMenuSet_B();
            try
            {
                //全データ分ループ
                for (int intCnt = 1; intCnt <= 200; intCnt++)
                {
                    //記入情報登録用
                    List<string> lstMakerData = new List<string>();

                    LabelSet_Menu lblsetmenu = (LabelSet_Menu)FindControlByFieldName(this,"labelSet_Menu" + intCnt);
                    lstMakerData.Add(intCnt.ToString());
                    lstMakerData.Add(lblsetmenu.CodeTxtText);
                    lstMakerData.Add(lblsetmenu.ValueLabelText);

                    //登録
                    mymenuB.addMyMenu(lstMakerData);
                }

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

            //閉じる
            this.Close();

            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //業種のフォームを探す
                if (frm.Name.Equals("Z0000"))
                {
                    //データを連れてくるため、newをしないこと
                    Z0000.Z0000 z0000 = (Z0000.Z0000)frm;
                    z0000.Menu_ReSet();
                    z0000.Menu_Set();
                    break;
                }
            }
        }

        public static object FindControlByFieldName(Control cfrm, string name)
        {
            System.Type t = cfrm.GetType();

            System.Reflection.FieldInfo fi = t.GetField(
                name,
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.DeclaredOnly);

            if (fi == null)
                return null;

            return fi.GetValue(cfrm);
        }

        ///<summary>
        ///labelSet_Menu1_Enter
        ///フォーカスが来た場合
        ///</summary>
        private void labelSet_Menu1_Enter(object sender, EventArgs e)
        {
            //エラーメッセージ表示がされたかどうか
            if (blMessageOn == true)
            {
                //フォーカス位置確保
                Control cActive = this.ActiveControl;

                switch (cActive.Name)
                {
                    //1
                    case "labelSet_Menu1":

                        labelSet_Menu1.codeTxt.BackColor = Color.White;
                        break;
                    //2
                    case "labelSet_Menu2":

                        labelSet_Menu2.codeTxt.BackColor = Color.White;
                        break;
                    //3
                    case "labelSet_Menu3":

                        labelSet_Menu3.codeTxt.BackColor = Color.White;
                        break;
                    //4
                    case "labelSet_Menu4":

                        labelSet_Menu4.codeTxt.BackColor = Color.White;
                        break;
                }

                //初期化
                blMessageOn = false;

                switch (cActiveBefore.Name)
                {
                    //1
                    case "labelSet_Menu1":
                        labelSet_Menu1.Focus();
                        labelSet_Menu1.codeTxt.BackColor = Color.Cyan;
                        //this.ActiveControl = labelSet_Menu1;
                        break;
                    //2
                    case "labelSet_Menu2":

                        labelSet_Menu2.Focus();
                        break;
                    //3
                    case "labelSet_Menu3":

                        labelSet_Menu3.codeTxt.Focus();
                        break;
                    //4
                    case "labelSet_Menu4":

                        labelSet_Menu4.codeTxt.Focus();
                        break;
                }
            }
            else
            {
                //フォーカス位置の確保
                cActiveBefore = this.ActiveControl;
            }
        }

        ///<summary>
        ///labelSet_Menu1_Leave
        ///フォーカスが外れた場合
        ///</summary>
        private void labelSet_Menu1_Leave(object sender, EventArgs e)
        {
            switch (cActiveBefore.Name)
            {
                //1
                case "labelSet_Menu1":

                    //メッセージ表示がされていた場合
                    if (labelSet_Menu1.blMessageOn == true)
                    {
                        blMessageOn = true;
                        //初期化
                        labelSet_Menu1.blMessageOn = false;
                    }

                    break;
                //2
                case "labelSet_Menu2":

                    //メッセージ表示がされていた場合
                    if (labelSet_Menu2.blMessageOn == true)
                    {
                        blMessageOn = true;
                        //初期化
                        labelSet_Menu2.blMessageOn = false;
                    }

                    break;
                //3
                case "labelSet_Menu3":

                    //メッセージ表示がされていた場合
                    if (labelSet_Menu3.blMessageOn == true)
                    {
                        blMessageOn = true;
                        //初期化
                        labelSet_Menu3.blMessageOn = false;
                    }

                    break;
            }
        }
    }
}
