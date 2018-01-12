using KATO.Business.B0410_SeikyuItiranPrint;
using KATO.Business.B1510_SeikyuRireki_B;
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

namespace KATO.Form.B1510_SeikyuRireki
{
    ///<summary>
    ///B1510_SeikyuRireki
    ///請求履歴
    ///作成者：大河内
    ///作成日：2018/01/12
    ///更新者：
    ///更新日：
    ///</summary>
    public partial class B1510_SeikyuRireki : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///B1510_SeikyuRireki
        ///フォーム関係の設定
        ///引数　：前画面情報
        ///戻り値：なし
        ///</summary>
        public B1510_SeikyuRireki(Control c)
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
        }

        ///<summary>
        ///B1510_SeikyuRireki_Load
        ///画面レイアウト設定
        ///引数　：画面情報
        ///戻り値：なし
        ///</summary>
        private void B1510_SeikyuRireki_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "請求履歴";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            //初期値
            this.txtDenpyoYMDopen.setUp(0);
            this.txtDenpyoYMDclose.setUp(2);

            //DataGridView初期設定
            SetUpGrid();
        }

        ///<summary>
        ///SetUpGrid
        ///DataGridView初期設定
        ///引数　：なし
        ///戻り値：なし
        ///</summary>
        private void SetUpGrid()
        {
            //データをバインド
            DataGridViewTextBoxColumn TokuisakiCd = new DataGridViewTextBoxColumn();
            TokuisakiCd.DataPropertyName = "得意先コード";
            TokuisakiCd.Name = "得意先コード";
            TokuisakiCd.HeaderText = "得意先コード";

            DataGridViewTextBoxColumn TorihikisakiName = new DataGridViewTextBoxColumn();
            TorihikisakiName.DataPropertyName = "取引先名称";
            TorihikisakiName.Name = "取引先名称";
            TorihikisakiName.HeaderText = "取引先名称";

            DataGridViewTextBoxColumn SeikyuYMD = new DataGridViewTextBoxColumn();
            SeikyuYMD.DataPropertyName = "請求年月日";
            SeikyuYMD.Name = "請求年月日";
            SeikyuYMD.HeaderText = "請求年月日";

            DataGridViewTextBoxColumn Zenkaiseikyu = new DataGridViewTextBoxColumn();
            Zenkaiseikyu.DataPropertyName = "前回請求額";
            Zenkaiseikyu.Name = "前回請求額";
            Zenkaiseikyu.HeaderText = "前回請求額";

            DataGridViewTextBoxColumn Nyukin = new DataGridViewTextBoxColumn();
            Nyukin.DataPropertyName = "入金額";
            Nyukin.Name = "入金額";
            Nyukin.HeaderText = "入金額";

            DataGridViewTextBoxColumn Kurikoshi = new DataGridViewTextBoxColumn();
            Kurikoshi.DataPropertyName = "繰越額";
            Kurikoshi.Name = "繰越額";
            Kurikoshi.HeaderText = "繰越額";

            DataGridViewTextBoxColumn Uriage = new DataGridViewTextBoxColumn();
            Uriage.DataPropertyName = "売上額";
            Uriage.Name = "売上額";
            Uriage.HeaderText = "売上額";

            DataGridViewTextBoxColumn Shohizei = new DataGridViewTextBoxColumn();
            Shohizei.DataPropertyName = "消費税";
            Shohizei.Name = "消費税";
            Shohizei.HeaderText = "消費税";

            DataGridViewTextBoxColumn KonkaiSeikyu = new DataGridViewTextBoxColumn();
            KonkaiSeikyu.DataPropertyName = "今回請求額";
            KonkaiSeikyu.Name = "今回請求額";
            KonkaiSeikyu.HeaderText = "今回請求額";

            //個々の幅、文章の寄せ
            setColumnRireki(TokuisakiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 128);
            setColumnRireki(TorihikisakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 410);
            setColumnRireki(SeikyuYMD, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, 112);
            setColumnRireki(Zenkaiseikyu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 113);
            setColumnRireki(Nyukin, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 113);
            setColumnRireki(Kurikoshi, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 113);
            setColumnRireki(Uriage, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 113);
            setColumnRireki(Shohizei, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 113);
            setColumnRireki(KonkaiSeikyu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 113);

        }
        
        ///<summary>
        ///setColumnRireki
        ///DataGridViewの内部設定（履歴）
        ///引数　：カラム指定、幅寄せ(セル)、幅寄せ(ヘッダー)、フォーマット、カラム幅
        ///戻り値：なし
        ///</summary>
        private void setColumnRireki(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridRireki.Columns.Add(col);
            if (gridRireki.Columns[col.Name] != null)
            {
                gridRireki.Columns[col.Name].Width = intLen;
                gridRireki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridRireki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridRireki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///B1510_SeikyuRireki_KeyDown
        ///キー入力判定（画面全般）
        ///引数　：オブジェクト、イベント情報
        ///戻り値：なし
        ///</summary>
        private void B1510_SeikyuRireki_KeyDown(object sender, KeyEventArgs e)
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
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
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
        ///txtDenpyoYMDclose_KeyDown
        ///キー入力判定（通常テキスト）
        ///引数　：オブジェクト、イベント情報
        ///戻り値：なし
        ///</summary>
        private void txtDenpyoYMDclose_KeyDown(object sender, KeyEventArgs e)
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

        ///<summary>
        ///judFuncBtnClick
        ///ファンクションボタンの反応
        ///</summary>
        private void judFuncBtnClick(object sender, EventArgs e)
        {
            //ボタン入力情報によって動作を変える
            switch (((Button)sender).Name)
            {
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///delText
        ///テキストボックス等の入力情報を白紙にする
        ///引数　：なし
        ///戻り値：なし
        ///</summary>
        private void delText()
        {
            //画面内のデータを空にする
            this.delFormClear(this, gridRireki);

            //伝票年月日を初期値に
            this.txtDenpyoYMDopen.setUp(0);
            this.txtDenpyoYMDclose.setUp(2);

            //初期位置に移動
            this.txtDenpyoYMDopen.Focus();
        }

        ///<summary>
        ///setGridRirekiTokui
        ///請求履歴グリッドの表示（得意先コードから）
        ///引数　：なし
        ///戻り値：なし
        ///</summary>
        private void setGridRirekiTokui()
        {
            //どれか一か所でも記入されているなら
            Boolean blCheckOne = false;

            //空チェック
            if (txtDenpyoYMDopen.blIsEmpty()|| 
                txtDenpyoYMDclose.blIsEmpty()||
                lblsetTokuisaki.codeTxt.blIsEmpty())
            {
                blCheckOne = true;
            }

            //どれか一か所も記入されていない場合
            if (blCheckOne == false)
            {
                gridRireki.DataSource = "";
                return;
            }

            //データ検索用
            List<string> lstSeikyuRireki = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //ビジネス層のインスタンス生成
            B1510_SeikyuRireki_B seikyurirekiB = new B1510_SeikyuRireki_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                lstSeikyuRireki.Add(txtDenpyoYMDopen.Text);         //伝票年月日（開始）
                lstSeikyuRireki.Add(txtDenpyoYMDclose.Text);        //伝票年月日（終了）
                lstSeikyuRireki.Add(lblsetTokuisaki.CodeTxtText);   //得意先コード

                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = seikyurirekiB.getGridRirekiTokui(lstSeikyuRireki);

                //データがなかった場合
                if (dtSetView.Rows.Count == 0)
                {
                    return;
                }

                //データを配置
                gridRireki.DataSource = dtSetView;

                //グリッドの色変え
                setGridColor();
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
            return;
        }

        ///<summary>
        ///setGridColor
        ///グリッドの文字色指定
        ///</summary>
        private void setGridColor()
        {
            //グリッド内にデータがある場合
            if (gridRireki.Rows.Count > 0)
            {
                //グリッドの行数分ループ
                for (int intRowCnt = 0; intRowCnt < gridRireki.Rows.Count; intRowCnt++)
                {
                    //前回請求額が0以外の場合
                    if (Math.Floor(double.Parse(gridRireki.Rows[intRowCnt].Cells["前回請求額"].Value.ToString())) < 0)
                    {
                        //前回請求額を赤色
                        gridRireki.Rows[intRowCnt].Cells["前回請求額"].Style.ForeColor = Color.Red;
                    }
                    //入金額が0以外の場合
                    if (Math.Floor(double.Parse(gridRireki.Rows[intRowCnt].Cells["入金額"].Value.ToString())) < 0)
                    {
                        //入金額を赤色
                        gridRireki.Rows[intRowCnt].Cells["入金額"].Style.ForeColor = Color.Red;
                    }
                    //繰越額が0以外の場合
                    if (Math.Floor(double.Parse(gridRireki.Rows[intRowCnt].Cells["繰越額"].Value.ToString())) < 0)
                    {
                        //繰越額を赤色
                        gridRireki.Rows[intRowCnt].Cells["繰越額"].Style.ForeColor = Color.Red;
                    }
                    //売上額が0以外の場合
                    if (Math.Floor(double.Parse(gridRireki.Rows[intRowCnt].Cells["売上額"].Value.ToString())) < 0)
                    {
                        //売上額を赤色
                        gridRireki.Rows[intRowCnt].Cells["売上額"].Style.ForeColor = Color.Red;
                    }
                    //消費税が0以外の場合
                    if (Math.Floor(double.Parse(gridRireki.Rows[intRowCnt].Cells["消費税"].Value.ToString())) < 0)
                    {
                        //消費税を赤色
                        gridRireki.Rows[intRowCnt].Cells["消費税"].Style.ForeColor = Color.Red;
                    }
                    //今回請求額が0以外の場合
                    if (Math.Floor(double.Parse(gridRireki.Rows[intRowCnt].Cells["今回請求額"].Value.ToString())) < 0)
                    {
                        //今回請求額を赤色
                        gridRireki.Rows[intRowCnt].Cells["今回請求額"].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        ///<summary>
        ///lblsetTokuisaki_Leave
        ///得意先コードから離れた時
        ///引数　：オブジェクト、イベント情報
        ///戻り値：なし
        ///</summary>
        private void lblsetTokuisaki_Leave(object sender, EventArgs e)
        {
            //請求履歴グリッドの表示（得意先から）
            setGridRirekiTokui();
        }
    }
}
