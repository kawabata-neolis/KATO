using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Common.Business;
using System.Security.Permissions;
using KATO.Common.Ctl;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Common.Form
{
    /// <summary>
    /// KakouGenkaList
    /// 加工原価確認フォーム
    /// 作成者：多田
    /// 作成日：2017/7/7
    /// 更新者：多田
    /// 更新日：2017/7/7
    /// カラム論理名
    /// </summary>
    public partial class KakouGenkaList : System.Windows.Forms.Form
    {
        // ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        // フォームタイトル設定
        private string Title = "";
        public string _Title
        {
            set
            {
                String[] aryTitle = new string[] { value };
                this.Text = string.Format(STR_TITLE, aryTitle);
                Title = this.Text;
            }
            get
            {
                return Title;
            }
        }

        // 受注番号
        private string strJuchuNo;

        /// <summary>
        /// KakouGenkaList
        /// フォーム関係の設定
        /// <param name="strJuchuNo">受注番号</param>
        /// </summary>
        public KakouGenkaList(Control c, string strJuchuNo)
        {
            // 画面データが解放されていた時の対策
            if (c == null)
            {
                return;
            }

            // 画面位置の指定
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            // ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            // 親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;

            // 受注番号をセット
            this.strJuchuNo = strJuchuNo;
        }

        /// <summary>
        /// KakouGenkaList_Load
        /// 読み込み時
        /// </summary>
        private void KakouGenkaList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "加工原価確認";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF12.Text = "F12:戻る";

            // DataGridViewの初期設定
            SetUpGrid();
        }

        /// <summary>
        /// KakouGenkaList_Shown
        /// フォームが最初に表示された時
        /// </summary>
        private void KakouGenkaList_Shown(object sender, EventArgs e)
        {
            // データをグリッドビューに追加
            this.setKakouGenka();
        }

        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            // 列自動生成禁止
            gridJuchu.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn kubun = new DataGridViewTextBoxColumn();
            kubun.DataPropertyName = "区分";
            kubun.Name = "区分";
            kubun.HeaderText = "区分";

            DataGridViewTextBoxColumn hiduke = new DataGridViewTextBoxColumn();
            hiduke.DataPropertyName = "発注年月日";
            hiduke.Name = "発注年月日";
            hiduke.HeaderText = "日付";

            DataGridViewTextBoxColumn chuban = new DataGridViewTextBoxColumn();
            chuban.DataPropertyName = "注番";
            chuban.Name = "注番";
            chuban.HeaderText = "注番";

            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "品名";
            kataban.Name = "品名";
            kataban.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn suuryo = new DataGridViewTextBoxColumn();
            suuryo.DataPropertyName = "発注数量";
            suuryo.Name = "発注数量";
            suuryo.HeaderText = "数量";

            DataGridViewTextBoxColumn tanka = new DataGridViewTextBoxColumn();
            tanka.DataPropertyName = "発注単価";
            tanka.Name = "発注単価";
            tanka.HeaderText = "単価";

            DataGridViewTextBoxColumn nouki = new DataGridViewTextBoxColumn();
            nouki.DataPropertyName = "納期";
            nouki.Name = "納期";
            nouki.HeaderText = "納期／出庫";

            DataGridViewTextBoxColumn siireName = new DataGridViewTextBoxColumn();
            siireName.DataPropertyName = "仕入先名";
            siireName.Name = "仕入先名";
            siireName.HeaderText = "仕入先名";

            DataGridViewTextBoxColumn siireDate = new DataGridViewTextBoxColumn();
            siireDate.DataPropertyName = "仕入日";
            siireDate.Name = "仕入日";
            siireDate.HeaderText = "仕入日";

            DataGridViewTextBoxColumn siireSuuryo = new DataGridViewTextBoxColumn();
            siireSuuryo.DataPropertyName = "仕入済数量";
            siireSuuryo.Name = "仕入済数量";
            siireSuuryo.HeaderText = "仕入数量";

            // 個々の幅、文字の寄せ
            setColumn(kubun, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumn(hiduke, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(chuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#", 100);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 520);
            setColumn(suuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 80);
            setColumn(tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 100);
            setColumn(nouki, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 120);
            setColumn(siireName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 320);
            setColumn(siireDate, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, "yyyy/MM/dd", 90);
            setColumn(siireSuuryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,#", 100);
        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridJuchu.Columns.Add(col);
            if (gridJuchu.Columns[col.Name] != null)
            {
                gridJuchu.Columns[col.Name].Width = intLen;
                gridJuchu.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridJuchu.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridJuchu.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// KakouGenkaList_KeyDown
        /// キー入力判定
        /// </summary>
        private void KakouGenkaList_KeyDown(object sender, KeyEventArgs e)
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
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// btnEndClick
        /// 戻るボタンを押したとき
        /// </summary>
        private void btnEndClick(object sender, EventArgs e)
        {
            logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));
            this.Close();
        }

        /// <summary>
        /// setKakouGenka
        /// データをグリッドビューに追加
        /// </summary>
        private void setKakouGenka()
        {
            // ビジネス層のインスタンス生成
            KakouGenkaList_B kakouB = new KakouGenkaList_B();
            try
            {
                // 検索実行
                DataTable dtKakouGenkaList = kakouB.setDatagridView(this.strJuchuNo);

                // データテーブルからデータグリッドへセット
                gridJuchu.DataSource = dtKakouGenkaList;

                if (dtKakouGenkaList != null && dtKakouGenkaList.Rows.Count > 0)
                {
                    for (int cnt = 0; cnt < gridJuchu.RowCount; cnt++)
                    {
                        string strKubun = gridJuchu.Rows[cnt].Cells["区分"].Value.ToString();

                        // 区分が出庫、加工出庫、入庫(原在)、入庫(原)の場合はフォントカラーを変更
                        if (strKubun.Equals("出庫") || strKubun.Equals("加工出庫") || strKubun.Equals("入庫(原在)") || strKubun.Equals("入庫(原)"))
                        {
                            gridJuchu.Rows[cnt].DefaultCellStyle.ForeColor = Color.Green;
                        }

                        // 区分が発注の場合はフォントカラーを変更
                        if (strKubun.Equals("発注"))
                        {
                            gridJuchu.Rows[cnt].DefaultCellStyle.ForeColor = Color.Blue;
                        }
                    }

                    Control cNow = this.ActiveControl;
                    cNow.Focus();
                }

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);
                return;
            }
            return;
        }

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

    }
}
