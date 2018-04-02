using KATO.Business.B0040_NyukinInput;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.B0040_NyukinInput
{

    ///<summary>
    ///B0040_NyukinInput_Load
    ///入金入力フォーム
    ///作成者：太田
    ///作成日：2017/06/23
    ///更新者：大河内
    ///更新日：2018/01/26
    ///</summary>
    public partial class B0040_NyukinInput : BaseForm
    {
        //現在の選択行を初期化
        private int CurrentRow = 99;

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// B0040_NyukinInput
        /// フォーム関係の設定
        /// </summary>
        public B0040_NyukinInput(Control c)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;

            //最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;

            //左寄せ
            txtDenpyoNo.TextAlign = HorizontalAlignment.Left;
        }

        /// <summary>
        /// B0040_NyukinInput_Load
        /// 読み込み時
        /// </summary>
        private void B0040_NyukinInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "入金入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF06.Text = "F6:終り";
            this.btnF07.Text = "F7:行削除";
            this.btnF08.Text = "F8:元帳";
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            //リストからデータを取り出したかどうかのチェックの初期値(リストから取り出していない状態)
            radSet_chkListDataInput.radbtn0.Checked = true;
            
            DataTable dtTantoshaCd = new DataTable();

            B0040_NyukinInput_B nyukininputB = new B0040_NyukinInput_B();
            try
            {
                //ログインＩＤから担当者コードを取り出す
                dtTantoshaCd = nyukininputB.getTantoshaCd(SystemInformation.UserName);
                
                //担当者データがある場合
                if (dtTantoshaCd.Rows.Count > 0)
                {
                    //一行目にデータがない場合
                    if (dtTantoshaCd.Rows[0]["担当者コード"].ToString() == "")
                    {
                        return;
                    }
                }

                labelSet_Tantousha.CodeTxtText = dtTantoshaCd.Rows[0]["担当者コード"].ToString();
                labelSet_Tantousha.chkTxtTantosha();
                labelSet_Eigyosho.CodeTxtText = dtTantoshaCd.Rows[0]["営業所コード"].ToString();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }

            //伝票年月日の設定
            txtYMD.setUp(0);			
            
            //DataGridViewの初期設定
            SetUpGrid();
        }

        ///<summary>
        ///SetUpGrid
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            System.DateTime dateStartYMD;

            dateStartYMD = DateTime.Parse(txtYMD.Text);

            //列自動生成禁止
            gridSeikyuRireki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn Seikyuubi = new DataGridViewTextBoxColumn();
            Seikyuubi.DataPropertyName = "請求年月日";
            Seikyuubi.Name = "請求年月日";
            Seikyuubi.HeaderText = "請求日";

            DataGridViewTextBoxColumn NyuukinYoteibi = new DataGridViewTextBoxColumn();
            NyuukinYoteibi.DataPropertyName = "入金予定年月日";
            NyuukinYoteibi.Name = "入金予定年月日";
            NyuukinYoteibi.HeaderText = "入金予定日";

            DataGridViewTextBoxColumn ZenkaiSeikyuugaku = new DataGridViewTextBoxColumn();
            ZenkaiSeikyuugaku.DataPropertyName = "前回請求額";
            ZenkaiSeikyuugaku.Name = "前回請求額";
            ZenkaiSeikyuugaku.HeaderText = "前回請求額";

            DataGridViewTextBoxColumn Nyuukingaku = new DataGridViewTextBoxColumn();
            Nyuukingaku.DataPropertyName = "入金額";
            Nyuukingaku.Name = "入金額";
            Nyuukingaku.HeaderText = "入金額";

            DataGridViewTextBoxColumn Kurikosigaku = new DataGridViewTextBoxColumn();
            Kurikosigaku.DataPropertyName = "繰越額";
            Kurikosigaku.Name = "繰越額";
            Kurikosigaku.HeaderText = "繰越額";

            DataGridViewTextBoxColumn Uriagegaku = new DataGridViewTextBoxColumn();
            Uriagegaku.DataPropertyName = "売上額";
            Uriagegaku.Name = "売上額";
            Uriagegaku.HeaderText = "売上額";

            DataGridViewTextBoxColumn Syouhizei = new DataGridViewTextBoxColumn();
            Syouhizei.DataPropertyName = "消費税";
            Syouhizei.Name = "消費税";
            Syouhizei.HeaderText = "消費税";

            DataGridViewTextBoxColumn KonkaiSeikyugaku = new DataGridViewTextBoxColumn();
            KonkaiSeikyugaku.DataPropertyName = "今回請求額";
            KonkaiSeikyugaku.Name = "今回請求額";
            KonkaiSeikyugaku.HeaderText = "今回請求額";


            //個々の幅、文章の寄せ
            setColumn(Seikyuubi, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumn(NyuukinYoteibi, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null,120);
            setColumn(ZenkaiSeikyuugaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0",120);
            setColumn(Nyuukingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumn(Kurikosigaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumn(Uriagegaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumn(Syouhizei, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumn(KonkaiSeikyugaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            
        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridSeikyuRireki.Columns.Add(col);
            if (gridSeikyuRireki.Columns[col.Name] != null)
            {
                gridSeikyuRireki.Columns[col.Name].Width = intLen;
                gridSeikyuRireki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridSeikyuRireki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridSeikyuRireki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// B0040_NyukinInput_KeyDown
        /// キー入力判定
        /// </summary>
        private void B0040_NyukinInput_KeyDown(object sender, KeyEventArgs e)
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
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "追加実行"));
                        this.addNyuukin();
                    }
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delAllSakujo();
                    }
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    logger.Info(LogUtil.getMessage(this._Title, "終り実行"));
                    this.btnF01.Focus();
                    break;
                case Keys.F7:
                    logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                    this.delCurrentRow();
                    break;
                case Keys.F8:
                    logger.Info(LogUtil.getMessage(this._Title, "元帳実行"));
                    this.frmOpenTokuisakiMotocho();
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

        /// <summary>
        /// judBtnClick
        /// ボタンの反応
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 追加
                    if (this.btnF01.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "追加実行"));
                        this.addNyuukin();
                    }
                    break;
                case STR_BTN_F03: // 削除
                    if (this.btnF03.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                        this.delAllSakujo();
                    }
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F06: // 終り実行
                    logger.Info(LogUtil.getMessage(this._Title, "終り実行"));
                    this.btnF01.Focus();
                    break;
                case STR_BTN_F07: // 行削除
                    logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                    this.delCurrentRow();
                    break;
                case STR_BTN_F08: // 元帳
                    logger.Info(LogUtil.getMessage(this._Title, "元帳実行"));
                    this.frmOpenTokuisakiMotocho();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// updTorihikiKbnLeave
        /// 区分コードのテキストボックスからフォーカスが外れた時
        /// </summary>
        private void updTorihikiKbnLeave(object sender, EventArgs e)
        {
            this.btnF01.Enabled = true;
        }

        //入金額テキストボックスを入力した場合の処理
        private void txtNyukinX_Leave(object sender, EventArgs e)
        {
            //金額計算メソッドへ移動
            sumKingakuGoukei();
        }
        
        //得意先コードを入力した場合の処理。
        private void labelSet_Tokuisaki_Leave(object sender, EventArgs e)
        {
            //グリッド初期化
            gridSeikyuRireki.DataSource = "";

            //請求履歴表示メソッドへ
            getSeikyuRireki();

            //機能追加_締切日、支払月数、支払日、支払条件、集金区分表示
            getTorihikisakiData();
        }
        
        /// <summary>
        /// frmOpenTokuisakiMotocho
        /// 得意先元帳を開く
        /// </summary>
        private void frmOpenTokuisakiMotocho()
        {
            //ここで得意先コードを引数に指定し、得意先元帳を開きます。
            // 得意先コードがある場合
            if (labelSet_Tokuisaki.CodeTxtText != "")
            {
                // 得意先元帳確認フォームを開く
                E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin tokuisaki =
                    new E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin(this, 4, labelSet_Tokuisaki.CodeTxtText);
                tokuisaki.ShowDialog();
            }
        }

        /// <summary>
        /// updtxtYMD_Leave
        /// 伝票年月日のテキストボックスからフォーカスが外れた時
        /// </summary>
        private void updtxtYMD_Leave(object sender, EventArgs e)
        {
            // 日付制限チェック
            dateCheck();
        }
        
        /// <summary>
        /// txtYMDKeyDown
        /// 伝票年月日のKeyDownイベント
        /// </summary>
        private void txtYMDKeyDown(object sender, KeyEventArgs e)
        {

            // キー入力情報によって動作を変える
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
                case Keys.PageUp:
                    this.getNextDenpyoNo();
                    txtDenpyoNo.Focus();
                    txtYMD.Focus();
                    break;
                case Keys.PageDown:
                    this.getPrevDenpyoNo();
                    txtDenpyoNo.Focus();
                    txtYMD.Focus();
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                case Keys.Enter:
                    //最大桁数ではない場合
                    if (txtYMD.Text.Length < 10 )
                    {

                        //日付制限チェック
                        dateCheck();
                    }
                    break;
                case Keys.F1:
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
                    break;
            }

            return;
        }


        /// <summary>
        /// txtDenpyoNo_KeyDown
        /// 伝票番号のKeyDownイベント
        /// </summary>
        private void txtDenpyoNo_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.PageUp:
                    this.getNextDenpyoNo();
                    txtYMD.Focus();
                    break;
                case Keys.PageDown:
                    this.getPrevDenpyoNo();
                    txtYMD.Focus();
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
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
                    this.setNyukinList();
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// lblsetTorihikikbn_KeyDown
        /// 取引区分コードのKeyDownイベント
        /// </summary>
        private void lblsetTorihikikbn_KeyDown(object sender, KeyEventArgs e)
        {
            string strSenderName = ((TextBox)(sender)).Name;

            // 入金額のベース名、長さの取得に使用
            string strBaseName = "lblsetTorihikikbn";

            // txtKingakuXXのXXを取得して数字に直す
            int index = int.Parse(strSenderName.Substring(strBaseName.Length, strSenderName.Length - strBaseName.Length));

            // キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.F6:
                    this.btnF01.Focus();  // F1へフォーカス
                    break;
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.Down:
                    if (index <= 8)
                    {
                        this.Controls["gbNyukinInput"].Controls["lblsetTorihikikbn" + (index + 1).ToString()].Controls["codeTxt"].Focus();
                    }
                    else
                    {
                        this.txtNyukin0.Focus();
                    }
                    break;
                case Keys.Up:
                    if (index > 1)
                    {
                        this.Controls["gbNyukinInput"].Controls["lblsetTorihikikbn" + (index - 1).ToString()].Controls["codeTxt"].Focus();
                    }
                    else
                    {
                        this.txtNyukin9.Focus();
                    }
                    break;
            }
        }

        /// <summary>
        /// txtNyukin_KeyDown
        /// 入金額のKeyDownイベント
        /// </summary>
        private void txtNyukin_KeyDown(object sender, KeyEventArgs e)
        {
            //string strSenderName = ((TextBox)(sender)).Name;

            //// 入金額のベース名、長さの取得に使用
            //string strBaseName = "txtNyukin";

            //// txtKingakuXXのXXを取得して数字に直す
            //int index = int.Parse(strSenderName.Substring(strBaseName.Length, strSenderName.Length - strBaseName.Length));

            // キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.F6:
                    this.btnF01.Focus();  // F1へフォーカス
                    break;
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.Down:
                    break;
                case Keys.Up:
                    break;
            }
        }

        /// <summary>
        /// txtBikou0_KeyDown
        /// 備考のKeyDownイベント
        /// </summary>
        private void txtBikou_KeyDown(object sender, KeyEventArgs e)
        {
            // キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.F6:
                    this.btnF01.Focus();  // F1へフォーカス
                    break;
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
            }
        }

        ///<summary>
        ///setNyukinList
        ///入金リストに移動
        ///</summary>
        private void setNyukinList()
        {
            //初期化
            radSet_chkListDataInput.radbtn0.Checked = true;

            NyukinList nyukinlist = new NyukinList(this);
            try
            {
                //入金リストの表示
                nyukinlist.bmDenpyo = txtDenpyoNo;
                nyukinlist.radListInput = radSet_chkListDataInput;
                nyukinlist.ShowDialog();

                //リストからデータを取り出した場合
                if (radSet_chkListDataInput.radbtn1.Checked == true)
                {
                    //伝票データを入れる 
                    setDenpyoData();
                    dateCheck();
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///setDenpyoData
        ///伝票番号からデータを表示
        ///</summary>
        private void setDenpyoData()
        {
            //伝票番号は空白だった場合は、処理終了
            if (txtDenpyoNo.Text == "")
            {
                return;
            }

            txtYMD.Text = "";
            labelSet_Tokuisaki.CodeTxtText = "";
            LabelGray_Goukei.Text = "";

            //全行をクリアする。
            for (int i = 0; i <= 9; i++)
            {

                Control[] cs1 = this.Controls.Find("lblsetTorihikikbn" + i.ToString(), true);

                ((BaseTextLabelSet)cs1[0]).CodeTxtText = "";

                Control[] cs3 = this.Controls.Find("txtNyukin" + i.ToString(), true);

                ((TextBox)cs3[0]).Text = "";

                Control[] cs5 = this.Controls.Find("txtTegataYMD" + i.ToString(), true);

                ((TextBox)cs5[0]).Text = "";

                Control[] cs7 = this.Controls.Find("txtBikou" + i.ToString(), true);

                ((TextBox)cs7[0]).Text = "";

            }

            //伝票番号をキーに得意先コードを取得する。

            //ビジネス層のインスタンス生成
            B0040_NyukinInput_B nyukinInputB = new B0040_NyukinInput_B();
            try
            {
                //データ検索用
                List<string> lstSeikyuRirekiLoad = new List<string>();

                //検索時のデータ取り出し先
                DataTable dtSetView;

                //データの存在確認を検索する情報を入れる
                /*[0]伝票番号*/
                lstSeikyuRirekiLoad.Add(txtDenpyoNo.Text);

                //ビジネス層、伝票番号をキーに入金テーブルから得意先コードを取得
                dtSetView = nyukinInputB.getTokuisakiCd(lstSeikyuRirekiLoad);

                //取得した得意先コードが2件以上あった場合、メッセージを表示し、処理を終了する。
                if (dtSetView.Rows.Count > 1)
                {
                    //複数取引先ありのメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "１枚の伝票に複数の取引先が登録されているので表示できません。\r\nNO.71 入金入力（部門別）を使用してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

                //ビジネス層、伝票番号をキーに入金テーブルから全データを取得
                dtSetView = nyukinInputB.getNyukinData(lstSeikyuRirekiLoad);

                //取得した入金データが0件の場合はメッセージを表示し、処理を終了。
                if (dtSetView.Rows.Count > 0)
                {
                    txtYMD.Text = dtSetView.Rows[0]["入金年月日"].ToString();
                    labelSet_Tokuisaki.CodeTxtText = dtSetView.Rows[0]["得意先コード"].ToString();
                    labelSet_Tokuisaki.chkTxtTorihikisaki();

                    //行番号を基にデータをテキストボックスに設定する。
                    foreach (DataRow datarow in dtSetView.Rows)
                    {
                        //行番号－1した変数を保持
                        int gyoNo = int.Parse(datarow["行番号"].ToString()) - 1;

                        Control[] cs1 = this.Controls.Find("lblsetTorihikikbn" + gyoNo.ToString(), true);

                        ((BaseTextLabelSet)cs1[0]).CodeTxtText = datarow["取引区分コード"].ToString();

                        Control[] cs3 = this.Controls.Find("txtNyukin" + gyoNo.ToString(), true);

                        ((TextBox)cs3[0]).Text = decimal.Parse(datarow["入金額"].ToString()).ToString("#,0");

                        Control[] cs5 = this.Controls.Find("txtTegataYMD" + gyoNo.ToString(), true);

                        ((TextBox)cs5[0]).Text = datarow["手形期日"].ToString();

                        Control[] cs7 = this.Controls.Find("txtBikou" + gyoNo.ToString(), true);

                        ((TextBox)cs7[0]).Text = datarow["備考"].ToString();
                    }

                    //合計計算のメソッドへ
                    sumKingakuGoukei();

                    //請求履歴を表示する。
                    getSeikyuRireki();

                    //取引先データを表示
                    getTorihikisakiData();

                    this.btnF01.Enabled = true;
                    this.btnF03.Enabled = true;

                }
                else
                {
                    //伝票が見つからないメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "入力した伝票番号は見つかりません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    //伝票番号とグリッドと担当者以外初期化

                    //得意先コードの初期化
                    labelSet_Tokuisaki.CodeTxtText = "";
                    labelSet_Tokuisaki.ValueLabelText = "";

                    //区分データの初期化
                    delKbnData();

                    //表示のみの項目の初期化
                    txtSimekiribi.Text = "";
                    txtShiharaiGessu.Text = "";
                    txtShiharaibi.Text = "";
                    txtShiharaiJojen.Text = "";
                    txtShukunkbn.Text = "";
                    
                    txtDenpyoNo.Focus();
                    return;
                }
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

        ///<summary>
        ///delKbnData
        ///区分のデータを初期化
        ///</summary>
        private void delKbnData()
        {
            //１行目
            lblsetTorihikikbn0.CodeTxtText = "";
            lblsetTorihikikbn0.ValueLabelText = "";
            txtNyukin0.Text = "";
            txtTegataYMD0.Text = "";
            txtBikou0.Text = "";

            //２行目
            lblsetTorihikikbn1.CodeTxtText = "";
            lblsetTorihikikbn1.ValueLabelText = "";
            txtNyukin1.Text = "";
            txtTegataYMD1.Text = "";
            txtBikou1.Text = "";

            //３行目
            lblsetTorihikikbn2.CodeTxtText = "";
            lblsetTorihikikbn2.ValueLabelText = "";
            txtNyukin2.Text = "";
            txtTegataYMD2.Text = "";
            txtBikou2.Text = "";

            //４行目
            lblsetTorihikikbn3.CodeTxtText = "";
            lblsetTorihikikbn3.ValueLabelText = "";
            txtNyukin3.Text = "";
            txtTegataYMD3.Text = "";
            txtBikou3.Text = "";

            //５行目
            lblsetTorihikikbn4.CodeTxtText = "";
            lblsetTorihikikbn4.ValueLabelText = "";
            txtNyukin4.Text = "";
            txtTegataYMD4.Text = "";
            txtBikou4.Text = "";

            //６行目
            lblsetTorihikikbn5.CodeTxtText = "";
            lblsetTorihikikbn5.ValueLabelText = "";
            txtNyukin5.Text = "";
            txtTegataYMD5.Text = "";
            txtBikou5.Text = "";

            //７行目
            lblsetTorihikikbn6.CodeTxtText = "";
            lblsetTorihikikbn6.ValueLabelText = "";
            txtNyukin6.Text = "";
            txtTegataYMD6.Text = "";
            txtBikou6.Text = "";

            //８行目
            lblsetTorihikikbn7.CodeTxtText = "";
            lblsetTorihikikbn7.ValueLabelText = "";
            txtNyukin7.Text = "";
            txtTegataYMD7.Text = "";
            txtBikou7.Text = "";

            //９行目
            lblsetTorihikikbn8.CodeTxtText = "";
            lblsetTorihikikbn8.ValueLabelText = "";
            txtNyukin8.Text = "";
            txtTegataYMD0.Text = "";
            txtBikou8.Text = "";

            //１０行目
            lblsetTorihikikbn9.CodeTxtText = "";
            lblsetTorihikikbn9.ValueLabelText = "";
            txtNyukin9.Text = "";
            txtTegataYMD9.Text = "";
            txtBikou9.Text = "";

            //合計の初期化
            LabelGray_Goukei.Text = "";
        }

        ///<summary>
        ///txtDenpyoNo_Leave
        ///伝票番号を入力した場合の処理
        ///</summary>
        private void txtDenpyoNo_Leave(object sender, EventArgs e)
        {
            setDenpyoData();
        }

        /// <summary>
        /// setNyukinDenpyo
        /// 取り出したデータをテキストボックスに配置
        /// </summary>
        public void setNyukinDenpyo(DataTable dtSelectData)
        {
            txtDenpyoNo.Text = dtSelectData.Rows[0]["伝票番号"].ToString();

            //飛ばす用の変数
            object sender = new object();
            EventArgs e = new EventArgs();

            txtDenpyoNo_Leave(sender, e);
        }

        ///<summary>
        ///setNyukinListClose
        ///setNyukinListCloseが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setNyukinListClose()
        {
            txtDenpyoNo.Focus();
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            //削除するデータ以外を確保
            string strkensakuopen = txtYMD.Text;
            string streigyosyocd = labelSet_Eigyosho.CodeTxtText;

            //画面の項目内を白紙にする
            delFormClear(this, gridSeikyuRireki);

            txtYMD.Text = strkensakuopen;
            labelSet_Eigyosho.CodeTxtText = streigyosyocd;
            labelSet_Tantousha.chkTxtTantosha();

            DataTable dtTantoshaCd = new DataTable();

            B0040_NyukinInput_B nyukininputB = new B0040_NyukinInput_B();
            try
            {
                //ログインＩＤから担当者コードを取り出す
                dtTantoshaCd = nyukininputB.getTantoshaCd(SystemInformation.UserName);

                //担当者データがある場合
                if (dtTantoshaCd.Rows.Count > 0)
                {
                    //一行目にデータがない場合
                    if (dtTantoshaCd.Rows[0]["担当者コード"].ToString() == "")
                    {
                        return;
                    }
                }

                labelSet_Tantousha.CodeTxtText = dtTantoshaCd.Rows[0]["担当者コード"].ToString();
                labelSet_Tantousha.chkTxtTantosha();
                labelSet_Eigyosho.CodeTxtText = dtTantoshaCd.Rows[0]["営業所コード"].ToString();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }


            txtYMD.Focus();

            this.btnF01.Enabled = false;
            this.btnF03.Enabled = false;
        }

        /// <summary>
        /// addNyuukin
        /// 入金追加処理
        /// </summary>
        private void addNyuukin()
        {
            string strDenpyoNo = "";
            Control ctlGb = this.Controls["gbNyukinInput"];

            // 空文字判定（伝票年月日）
            if (txtYMD.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                txtYMD.Focus();
                return;
            }


            // 日付フォーマットチェック
            string datedata = txtYMD.chkDateDataFormat(txtYMD.Text);
            if ("".Equals(datedata))
            {
                // メッセージボックスの処理
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            else
            {
                txtYMD.Text = datedata;
            }

            // 空文字判定（得意先コード）
            if (labelSet_Tokuisaki.codeTxt.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tokuisaki.Focus();
                return;
            }

            // 入力チェック（得意先コード（取引先））
            if (labelSet_Tokuisaki.chkTxtTorihikisaki())
            {
                return;
            }

            // 空文字判定（取引区分コードがある場合の金額）
            for (int cnt = 0; cnt <= 9; cnt++)
            {
                if (!ctlGb.Controls["lblsetTorihikikbn" + cnt.ToString()].Controls["codeTxt"].Text.Equals(""))
                {
                    // 入力チェック（取引区分）
                    if (((LabelSet_Torihikikbn)ctlGb.Controls["lblsetTorihikikbn" + cnt.ToString()]).chkTxtTorihikikbn())
                    {
                        return;
                    }
                    
                    // 必須チェック（金額）
                    if (ctlGb.Controls["txtNyukin" + cnt.ToString()].Text.Equals(""))
                    {
                        // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "項目が空です。\r\n数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        //対象の列の金額にフォーカス
                        ctlGb.Controls["txtNyukin" + cnt.ToString()].Focus();
                        return;
                    }

                    // 金額フォーマットチェック（金額）
                    if (((BaseTextMoney)ctlGb.Controls["txtNyukin" + cnt.ToString()]).chkMoneyText())
                    {
                        return;
                    }

                    // 日付フォーマットチェック（手形期日）
                    if (!"".Equals(((BaseCalendar)ctlGb.Controls["txtTegataYMD" + cnt.ToString()]).Text))
                    {
                        datedata = ((BaseCalendar)ctlGb.Controls["txtTegataYMD" + cnt.ToString()]).chkDateDataFormat(((BaseCalendar)ctlGb.Controls["txtTegataYMD" + cnt.ToString()]).Text);
                        if ("".Equals(datedata))
                        {
                            // メッセージボックスの処理
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            return;
                        }
                        else
                        {
                            ((BaseCalendar)ctlGb.Controls["txtTegataYMD" + cnt.ToString()]).Text = datedata;
                        }
                    }
                }
            }

            // 日付制限チェック
            if (!dateCheck())
            {
                txtYMD.Focus();
                return;
            }

            B0040_NyukinInput_B nyukininputB = new B0040_NyukinInput_B();
            try
            {
                // 伝票番号がない場合
                if (txtDenpyoNo.Text.Equals(""))
                {
                    strDenpyoNo = nyukininputB.getDenpyoNo();
                }
                else
                {
                    strDenpyoNo = txtDenpyoNo.Text;
                }                
            
                string[] strCommontItem = new string[4];
                string[,] strInsertItem = new string[10, 4];

                strCommontItem[0] = strDenpyoNo;
                strCommontItem[1] = Environment.UserName;
                strCommontItem[2] = txtYMD.Text;
                strCommontItem[3] = labelSet_Tokuisaki.CodeTxtText;

                for (int cnt = 0; cnt <= 9; cnt++)
                {
                    strInsertItem[cnt, 0] = ctlGb.Controls["lblsetTorihikikbn" + cnt.ToString()].Controls["codeTxt"].Text;
                    strInsertItem[cnt, 1] = ctlGb.Controls["txtNyukin" + cnt.ToString()].Text;
                    strInsertItem[cnt, 2] = ctlGb.Controls["txtTegataYMD" + cnt.ToString()].Text;
                    strInsertItem[cnt, 3] = ctlGb.Controls["txtBikou" + cnt.ToString()].Text;
                }

                Boolean blDataAri = false;

                for (int intRow = 0; intRow <= 9; intRow++)
                {
                    for (int intCol = 0; intCol <= 3; intCol++)
                    {
                        //データがある場合
                        if (StringUtl.blIsEmpty(strInsertItem[intRow, intCol].ToString()))
                        {
                            blDataAri = true;
                        }
                    }
                }

                //データがない場合
                if (blDataAri == false)
                {
                    return;
                }

                // 表示中の入金を追加する処理
                nyukininputB.addNyukin(strCommontItem, strInsertItem);

                // メッセージボックスの処理、追加成功の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //初期化
                delText();

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

            }
            return;
        }

        /// <summary>
        /// allSakujo
        /// 入金全削除処理
        /// </summary>
        private void delAllSakujo()
        {

            // 日付フォーマットチェック
            string datedata = txtYMD.chkDateDataFormat(txtYMD.Text);
            if ("".Equals(datedata))
            {
                // メッセージボックスの処理
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            else
            {
                txtYMD.Text = datedata; 
            }

            // 日付制限チェック
            if (!dateCheck())
            {
                return;
            }

            // 空文字判定（伝票番号）
            if (txtDenpyoNo.blIsEmpty() == false)
            {
                return;
            }
                        
            B0040_NyukinInput_B nyukininputB = new B0040_NyukinInput_B();
            try
            {
                string[] strDeleteItem = new String[2];

                // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "表示中のデータを削除します。よろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                // NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                strDeleteItem[0] = txtDenpyoNo.Text;
                strDeleteItem[1] = Environment.UserName;

                // 表示中の入金全削除処理
                nyukininputB.delNyukin(strDeleteItem);

                // メッセージボックスの処理、削除成功の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                delText();
            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
            return;
        }

        /// <summary>
        /// getCurrentRow
        /// 選択行（０～９)番号を取得する。
        /// </summary>
        private void getCurrentRow(object sender, EventArgs e)
        {

            String str = "";

            // このフォームで現在アクティブなコントロールを取得する
            Control cControl = this.ActiveControl;

            // 取得できた場合、名前の右から一文字をCurrentRowに設定する（選択行）
            if (cControl != null)
            {
                str = cControl.Name;
                //末尾から1文字切り取り
                str = str.Substring(str.Length - 1, 1);
                //切り取った文字列が数字でなければ99を設定
                if (!int.TryParse(str, out CurrentRow))
                {
                    CurrentRow = 99;
                }
                //数字が０～９の間でない場合、処理終了
                if (CurrentRow < 0 && CurrentRow > 9)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// delCurrentRow
        /// 選択行（０～９）を削除し、値を再設定する。
        /// また合計も再計算する。
        /// </summary>
        private void delCurrentRow()
        {
            
                //数字が０～９の間でない場合、処理終了
                if (CurrentRow < 0 || CurrentRow > 9)
                {
                    return;
                }

                //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "選択行を削除します。\r\nよろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //何が選択されたか調べる
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    //「いいえ」が選択された場合は処理終了
                    return;
                }

                //選択行から最終行-1（8行）まで1つずつ値を上に並び変える。
                for (int i = CurrentRow; i <= 8; i++)
                {

                    Control[] cs1 = this.Controls.Find("lblsetTorihikikbn" + i.ToString(), true);
                    Control[] cs2 = this.Controls.Find("lblsetTorihikikbn" + (i + 1).ToString(), true);

                    ((BaseTextLabelSet)cs1[0]).CodeTxtText = ((BaseTextLabelSet)cs2[0]).CodeTxtText;

                    Control[] cs3 = this.Controls.Find("txtNyukin" + i.ToString(), true);
                    Control[] cs4 = this.Controls.Find("txtNyukin" + (i + 1).ToString(), true);

                    ((TextBox)cs3[0]).Text = ((TextBox)cs4[0]).Text;

                    Control[] cs5 = this.Controls.Find("txtTegataYMD" + i.ToString(), true);
                    Control[] cs6 = this.Controls.Find("txtTegataYMD" + (i + 1).ToString(), true);

                    ((TextBox)cs5[0]).Text = ((TextBox)cs6[0]).Text;

                    Control[] cs7 = this.Controls.Find("txtBikou" + i.ToString(), true);
                    Control[] cs8 = this.Controls.Find("txtBikou" + (i + 1).ToString(), true);

                    ((TextBox)cs7[0]).Text = ((TextBox)cs8[0]).Text;

                }

                //一番下の行の内容をクリア
                lblsetTorihikikbn9.CodeTxtText = "";
                txtNyukin9.Text = "";
                txtTegataYMD9.Text = "";
                txtBikou9.Text = "";

                //合計計算メソッドへ
                sumKingakuGoukei();
            
        }

        /// <summary>
        /// sumKingakuGoukei
        /// 入金額の合計を計算し、表示
        /// </summary>
        private void sumKingakuGoukei()
        {
            decimal sumGoukei = 0;
            String work = "";

            //合計金額を1度リセットする。
            LabelGray_Goukei.Text = "";

            for (int i = 0; i <= 9; i++)
            {
                Control[] cs3 = this.Controls.Find("txtNyukin" + i.ToString(), true);
                //金額がNULLの場合は計算しない。
                if (((TextBox)cs3[0]).Text != "")
                {
                    work = ((TextBox)cs3[0]).Text;
                    //カンマを消す
                    work = work.Replace(",", "");

                    sumGoukei = sumGoukei + decimal.Parse(work);

                    //3桁毎にカンマで区切る
                    work = String.Format("{0:#,0}", sumGoukei);

                }
            }

            LabelGray_Goukei.Text = work;
        }


        /// <summary>
        /// getSeikyuRireki
        /// データグリッドビューにデータを表示
        /// （請求履歴）
        /// </summary>
        private void getSeikyuRireki()
        {
            //データ検索用
            List<string> lstSeikyuRirekiLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //空文字判定（得意先コード）
            if (labelSet_Tokuisaki.CodeTxtText == "")
            {
                //表示のみの項目を削除
                txtSimekiribi.Text = "";
                txtShiharaiGessu.Text = "";
                txtShiharaibi.Text = "";
                txtShiharaiJojen.Text = "";
                txtShukunkbn.Text = "";

                //グリッド内容を削除
                gridSeikyuRireki.DataSource = "";
                return;
            }

            //ビジネス層のインスタンス生成
            B0040_NyukinInput_B nyukinInputB = new B0040_NyukinInput_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                /*[0]得意先コード*/
                lstSeikyuRirekiLoad.Add(labelSet_Tokuisaki.CodeTxtText);


                gridSeikyuRireki.Visible = false;

                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = nyukinInputB.getSeikyuRireki(lstSeikyuRirekiLoad);

                //データを配置（datagridview)
                gridSeikyuRireki.DataSource = dtSetView;

                gridSeikyuRireki.Visible = true;

            }
            catch (Exception ex)
            {
                //エラーロギング
                gridSeikyuRireki.Visible = true;
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            return;
        }

        /// <summary>
        /// getTorihikisakiData
        /// 機能追加＿取引先の情報を表示（締切日、支払月数、支払日、支払条件、集金区分）
        /// （請求履歴）
        /// </summary>
        private void getTorihikisakiData()
        {
            //データ検索用
            List<string> lstTorikhikisakiDataLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //空文字判定（得意先コード）
            if (labelSet_Tokuisaki.CodeTxtText == "")
            {
                return;
            }

            //ビジネス層のインスタンス生成
            B0040_NyukinInput_B nyukinInputB = new B0040_NyukinInput_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                /*[0]得意先コード*/
                lstTorikhikisakiDataLoad.Add(labelSet_Tokuisaki.CodeTxtText);
                
                //ビジネス層、取引先情報表示用ロジックに移動
                dtSetView = nyukinInputB.getTorihikisakiData(lstTorikhikisakiDataLoad);

                if (dtSetView.Rows.Count > 0)
                {
                    txtSimekiribi.Text = dtSetView.Rows[0]["締切日"].ToString();
                    txtShiharaiGessu.Text = dtSetView.Rows[0]["支払月数"].ToString();
                    txtShiharaibi.Text = dtSetView.Rows[0]["支払日"].ToString();
                    txtShiharaiJojen.Text = dtSetView.Rows[0]["支払条件"].ToString();
                    txtShukunkbn.Text = dtSetView.Rows[0]["集金区分"].ToString();
                }
                else
                {
                    txtSimekiribi.Text = "";
                    txtShiharaiGessu.Text = "";
                    txtShiharaibi.Text = "";
                    txtShiharaiJojen.Text = "";
                    txtShukunkbn.Text = "";
                }



            }
            catch (Exception ex)
            {
                //エラーロギング
                gridSeikyuRireki.Visible = true;
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            return;
        }

        /// <summary>
        /// getNextDenpyoNo
        /// 伝票番号の最小値を取得し、伝票番号へセット
        /// </summary>
        private string getNextDenpyoNo()
        {
            B0040_NyukinInput_B nyukininputB = new B0040_NyukinInput_B();
            try
            {
                string strDenpyoNo = "";

                // 伝票番号の最小値を取得
                DataTable dtMinDenpyoNo = nyukininputB.getMinDenpyoNo(txtDenpyoNo.Text);

                if (dtMinDenpyoNo.Rows.Count > 0)
                {
                    strDenpyoNo = dtMinDenpyoNo.Rows[0]["最小値"].ToString();

                    int intDenpyoNo;
                    int.TryParse(strDenpyoNo, out intDenpyoNo);
                    if (!strDenpyoNo.Equals("") && intDenpyoNo <= 0)
                    {
                        strDenpyoNo = "1";
                    }
                }
                
                txtDenpyoNo.Text = strDenpyoNo;

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

        }
            return "";
        }


        /// <summary>
        /// getPrevDenpyoNo
        /// 伝票番号の最大値を取得し、伝票番号へセット
        /// </summary>
        private string getPrevDenpyoNo()
        {
            B0040_NyukinInput_B nyukininputB = new B0040_NyukinInput_B();
            try
            {
                string strDenpyoNo = "";

                // 伝票番号の最大値を取得
                DataTable dtMinDenpyoNo = nyukininputB.getMaxDenpyoNo(txtDenpyoNo.Text);

                if (dtMinDenpyoNo.Rows.Count > 0)
                {
                    strDenpyoNo = dtMinDenpyoNo.Rows[0]["最大値"].ToString();

                    int intDenpyoNo;
                    int.TryParse(strDenpyoNo, out intDenpyoNo);
                    if (!strDenpyoNo.Equals("") && intDenpyoNo <= 0)
                    {
                        strDenpyoNo = "1";
                    }
                }

                txtDenpyoNo.Text = strDenpyoNo;

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

            }
            return "";
        }


        /// <summary>
        /// dateCheck
        /// 日付制限チェック
        /// </summary>
        private Boolean dateCheck()
        {
            // 日付空チェック
            if (txtYMD.Text.Equals(""))
            {
                return false;
            }
            
            // 日付フォーマットチェック
            string datedata = txtYMD.chkDateDataFormat(txtYMD.Text);

            if ("".Equals(datedata))
            {
                return false;
            }
            else
            {
                txtYMD.Text = datedata;
            }

            B0040_NyukinInput_B nyukininputB = new B0040_NyukinInput_B();
            try
            {
                // 日付制限テーブルから最小年月日、最大年月日を取得
                DataTable dtDate = nyukininputB.getDate(labelSet_Eigyosho.CodeTxtText);

                if (dtDate.Rows.Count > 0)
                {
                    DateTime dtMinDate = DateTime.Parse(dtDate.Rows[0]["最小年月日"].ToString());
                    DateTime dtMaxDate = DateTime.Parse(dtDate.Rows[0]["最大年月日"].ToString());
                    DateTime dtDenpyoYMD = DateTime.Parse(txtYMD.Text);

                    // 伝票年月日が最小年月日から最大年月日の間の場合
                    if (dtMinDate <= dtDenpyoYMD && dtDenpyoYMD <= dtMaxDate)
                    {
                        return true;
                    }
                    else
                    {
                        // メッセージボックスの処理、日付が範囲外の場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "日付が範囲外です。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

            }
            return false;
        }

        ///<summary>
        ///judtxtNyukinKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtNyukinKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}
