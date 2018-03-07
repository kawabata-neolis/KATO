using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.C0480_SiireSuiiHyo;
using KATO.Common.Ctl;
using KATO.Form.C0480_SiireSuiiHyo;

namespace KATO.Form.C0481_SiireSuiiHyo
{
    public partial class C0481_SiireSuiiHyoLevel2 : System.Windows.Forms.Form
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<string> lstString; // 仕入推移表から値を受け取るリスト

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

        /// <summary>
        /// C0481_SiireSuiiHyoLevel2
        /// 仕入推移表レベル２
        /// </summary>
        /// <param name="c"></param>
        /// <param name="argumentValues">仕入推移表から送られたリスト</param>
        public C0481_SiireSuiiHyoLevel2(Control c,List<string> argumentValues)
        {
            // SiireSuiiHyoから引数を取得
            lstString = argumentValues;

            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;
            
            InitializeComponent();

            // フォームが最大化されないようにする
            this.MaximizeBox = false;
            // フォームが最小化されないようにする
            this.MinimizeBox = false;

            // 最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            // ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            // 親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;
            
        }

        private void C0480_SiireSuiiHyoLevel2_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "分類別仕入推移表レベル２";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF12.Text = "F12:戻る";

            // DataGridViewの初期設定
            SetUpGrid();
        }

        /// <summary>
        /// GridSetUp
        /// DataGridView初期設定
        /// </summary>
        private void SetUpGrid()
        {
            System.DateTime dateStartYMD;

            dateStartYMD = DateTime.Parse(lstString[5]);

            // 列自動生成禁止
            gridSiireSuii.AutoGenerateColumns = false;

            // データをバインド
            DataGridViewTextBoxColumn siiresakiCd = new DataGridViewTextBoxColumn();
            siiresakiCd.DataPropertyName = "仕入先コード";
            siiresakiCd.Name = "仕入先コード";
            siiresakiCd.HeaderText = "仕入先コード";

            DataGridViewTextBoxColumn siiresakiName = new DataGridViewTextBoxColumn();
            siiresakiName.DataPropertyName = "仕入先名";
            siiresakiName.Name = "仕入先名";
            siiresakiName.HeaderText = "仕入先名";

            DataGridViewTextBoxColumn bunruiKbn = new DataGridViewTextBoxColumn();
            bunruiKbn.DataPropertyName = "区分";
            bunruiKbn.Name = "区分";
            bunruiKbn.HeaderText = "分類区分";

            DataGridViewTextBoxColumn daibunruiCd = new DataGridViewTextBoxColumn();
            daibunruiCd.DataPropertyName = "大分類コード";
            daibunruiCd.Name = "大分類コード";
            daibunruiCd.HeaderText = "大分類コード";

            DataGridViewTextBoxColumn chubunruiCd = new DataGridViewTextBoxColumn();
            chubunruiCd.DataPropertyName = "中分類コード";
            chubunruiCd.Name = "中分類コード";
            chubunruiCd.HeaderText = "中分類コード";

            DataGridViewTextBoxColumn makerCd = new DataGridViewTextBoxColumn();
            makerCd.DataPropertyName = "メーカーコード";
            makerCd.Name = "メーカーコード";
            makerCd.HeaderText = "メーカーコード";

            DataGridViewTextBoxColumn bunruiName = new DataGridViewTextBoxColumn();
            bunruiName.DataPropertyName = "分類名";
            bunruiName.Name = "分類名";
            bunruiName.HeaderText = "分類名";

            DataGridViewTextBoxColumn month1 = new DataGridViewTextBoxColumn();
            month1.DataPropertyName = "金額１";
            month1.Name = "金額１";
            month1.HeaderText = dateStartYMD.AddMonths(0).ToString("M月");

            DataGridViewTextBoxColumn month2 = new DataGridViewTextBoxColumn();
            month2.DataPropertyName = "金額２";
            month2.Name = "金額２";
            month2.HeaderText = dateStartYMD.AddMonths(1).ToString("M月");

            DataGridViewTextBoxColumn month3 = new DataGridViewTextBoxColumn();
            month3.DataPropertyName = "金額３";
            month3.Name = "金額３";
            month3.HeaderText = dateStartYMD.AddMonths(2).ToString("M月");

            DataGridViewTextBoxColumn month4 = new DataGridViewTextBoxColumn();
            month4.DataPropertyName = "金額４";
            month4.Name = "金額４";
            month4.HeaderText = dateStartYMD.AddMonths(3).ToString("M月");

            DataGridViewTextBoxColumn month5 = new DataGridViewTextBoxColumn();
            month5.DataPropertyName = "金額５";
            month5.Name = "金額５";
            month5.HeaderText = dateStartYMD.AddMonths(4).ToString("M月");

            DataGridViewTextBoxColumn month6 = new DataGridViewTextBoxColumn();
            month6.DataPropertyName = "金額６";
            month6.Name = "金額６";
            month6.HeaderText = dateStartYMD.AddMonths(5).ToString("M月");

            DataGridViewTextBoxColumn month7 = new DataGridViewTextBoxColumn();
            month7.DataPropertyName = "金額７";
            month7.Name = "金額７";
            month7.HeaderText = dateStartYMD.AddMonths(6).ToString("M月");

            DataGridViewTextBoxColumn month8 = new DataGridViewTextBoxColumn();
            month8.DataPropertyName = "金額８";
            month8.Name = "金額８";
            month8.HeaderText = dateStartYMD.AddMonths(7).ToString("M月");

            DataGridViewTextBoxColumn month9 = new DataGridViewTextBoxColumn();
            month9.DataPropertyName = "金額９";
            month9.Name = "金額９";
            month9.HeaderText = dateStartYMD.AddMonths(8).ToString("M月");

            DataGridViewTextBoxColumn month10 = new DataGridViewTextBoxColumn();
            month10.DataPropertyName = "金額１０";
            month10.Name = "金額１０";
            month10.HeaderText = dateStartYMD.AddMonths(9).ToString("M月");

            DataGridViewTextBoxColumn month11 = new DataGridViewTextBoxColumn();
            month11.DataPropertyName = "金額１１";
            month11.Name = "金額１１";
            month11.HeaderText = dateStartYMD.AddMonths(10).ToString("M月");

            DataGridViewTextBoxColumn month12 = new DataGridViewTextBoxColumn();
            month12.DataPropertyName = "金額１２";
            month12.Name = "金額１２";
            month12.HeaderText = dateStartYMD.AddMonths(11).ToString("M月");

            DataGridViewTextBoxColumn goukei = new DataGridViewTextBoxColumn();
            goukei.DataPropertyName = "金額合計";
            goukei.Name = "金額合計";
            goukei.HeaderText = "合計";

            // 個々の幅、文章の寄せ
            setColumn(siiresakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, null, 150);
            setColumn(bunruiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, null, 150);
            setColumn(month1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 70);
            setColumn(month2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month7, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month8, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month9, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month10, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month11, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);
            setColumn(month12, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 70);

            // レベル2は金額合計も表示しない
            setColumn(goukei, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            
            // 非表示項目（レベル２で使用）
            setColumn(siiresakiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(bunruiKbn, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(daibunruiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(chubunruiCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(makerCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);

            gridSiireSuii.Columns[14].Visible = false;
            gridSiireSuii.Columns[15].Visible = false;
            gridSiireSuii.Columns[16].Visible = false;
            gridSiireSuii.Columns[17].Visible = false;
            gridSiireSuii.Columns[18].Visible = false;
            gridSiireSuii.Columns[19].Visible = false;

            // グリッドビューにデータをバインドする。
            setSiireSuiiHyo();

        }

        /// <summary>
        /// setColumn
        /// DataGridViewの内部設定
        /// </summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridSiireSuii.Columns.Add(col);
            if (gridSiireSuii.Columns[col.Name] != null)
            {
                gridSiireSuii.Columns[col.Name].Width = intLen;
                gridSiireSuii.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridSiireSuii.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridSiireSuii.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// C0481_SiireSuiiHyo_KeyDown
        /// キー入力判定
        /// </summary>
        private void C0481_SiireSuiiHyo_KeyDown(object sender, KeyEventArgs e)
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

        /// <summary>
        /// judBtnClick
        /// ボタンの反応
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// setSiireSuiiHyo
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setSiireSuiiHyo()
        {
            // データ検索用
            List<string> lstSiireSuiiLoad = new List<string>();

            // 検索時のデータ取り出し先
            DataTable dtSetView;
            
            // ビジネス層のインスタンス生成
            C0481_SiireSuiiHyoLevel2_B siiresuiihyolevel2B = new C0481_SiireSuiiHyoLevel2_B();
            try
            {
                // データの存在確認を検索する情報を入れる
                /*[0]開始期間*/
                lstSiireSuiiLoad.Add(lstString[5]);
                /*[1]終了期間*/
                lstSiireSuiiLoad.Add(lstString[6]);
                /*[2]開始得意先コード*/
                lstSiireSuiiLoad.Add(lstString[0]);
                /*[3]終了得意先コード*/
                lstSiireSuiiLoad.Add(lstString[0]);
                

                // 区分の値によって処理変更する。レベル２はcase0とcase1のみ通過する。（レベル１からの遷移条件が区分2未満の為。）
                switch (lstString[1])
                {
                    case "0":
                        /*[4]大分類コード*/
                        lstSiireSuiiLoad.Add(lstString[2]);
                        /*[5]中分類コード*/
                        lstSiireSuiiLoad.Add("");
                        /*[6]メーカーコード*/
                        lstSiireSuiiLoad.Add("");
                        break;
                    case "1":
                        /*[4]大分類コード*/
                        lstSiireSuiiLoad.Add(lstString[2]);
                        /*[5]中分類コード*/
                        lstSiireSuiiLoad.Add(lstString[3]);
                        /*[6]メーカーコード*/
                        lstSiireSuiiLoad.Add("");
                        break;
                    case "2":
                        /*[4]大分類コード*/
                        lstSiireSuiiLoad.Add(lstString[2]);
                        /*[5]中分類コード*/
                        lstSiireSuiiLoad.Add(lstString[3]);
                        /*[6]メーカーコード*/
                        lstSiireSuiiLoad.Add(lstString[4]);
                        break;
                }
                
                gridSiireSuii.Visible = false;

                // ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = siiresuiihyolevel2B.setViewGrid(lstSiireSuiiLoad);

                // データを配置（datagridview)
                gridSiireSuii.DataSource = dtSetView;

                int i;
                String pre;
                pre = "";

                // 配列の前後で名前が重複している場合は名前を削除
                for (i = 0; i < gridSiireSuii.RowCount; i++)
                {
                    // 配列の前後を比較、同じ名前だった場合
                    if (gridSiireSuii[0, i].Value.ToString() == pre)
                    {
                        // 名前を削除する。
                        gridSiireSuii[0, i].Value = null;
                    }
                    else
                    {
                        pre = gridSiireSuii[0, i].Value.ToString();
                    }
                }

                gridSiireSuii.Visible = true;

            }
            catch (Exception ex)
            {
                // エラーロギング
                gridSiireSuii.Visible = true;
                new CommonException(ex);
                return;
            }
            return;
        }


        
        private void backFormButton_Click(object sender, EventArgs e)
        {
            // 閉じる
            this.Close();
        }

        /// <summary>
        /// lstSiireSuiiLevel2DoubleClick
        /// セルをダブルクリックしたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridSiireSuii_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // データ検索用
            List<string> lstSiireSuiiLevel2DoubleClick = new List<string>();

            // 選択行の値を取得(得意先コード、分類区分、大分類コード、中分類コード、メーカーコード、開始の期間、終わりの期間)
            // レベル３に渡す用
            lstSiireSuiiLevel2DoubleClick.Add(gridSiireSuii.CurrentRow.Cells[15].Value.ToString());
            lstSiireSuiiLevel2DoubleClick.Add(gridSiireSuii.CurrentRow.Cells[16].Value.ToString());
            lstSiireSuiiLevel2DoubleClick.Add(gridSiireSuii.CurrentRow.Cells[17].Value.ToString());
            lstSiireSuiiLevel2DoubleClick.Add(gridSiireSuii.CurrentRow.Cells[18].Value.ToString());
            lstSiireSuiiLevel2DoubleClick.Add(gridSiireSuii.CurrentRow.Cells[19].Value.ToString());
            lstSiireSuiiLevel2DoubleClick.Add(lstString[5]);
            lstSiireSuiiLevel2DoubleClick.Add(lstString[6]);

            // 分類区分がNULLの場合は処理を終了する。
            if (lstSiireSuiiLevel2DoubleClick[1] == "")
            {
                return;
            }

            // 分類区分が2未満の場合は分類別仕入推移表レベル３フォームを開く。
            if (int.Parse(lstSiireSuiiLevel2DoubleClick[1]) < 2)
            {
                C0482_SiireSuiiHyo.C0482_SiireSuiiHyoLevel3 siiresuiihyolevel3 = new C0482_SiireSuiiHyo.C0482_SiireSuiiHyoLevel3(this, lstSiireSuiiLevel2DoubleClick);
                siiresuiihyolevel3.ShowDialog();
            }
        }
    }
}
