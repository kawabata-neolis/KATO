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
using static KATO.Common.Util.CommonTeisu;
using KATO.Common.Ctl;
using KATO.Business.D0910_ShohinKensaku;

namespace KATO.Form.D0910_ShohinKensaku
{
    ///<summary>
    ///D0910_ShohinKensaku
    ///商品リストフォーム
    ///作成者：大河内
    ///作成日：2017/05/01
    ///更新者：大河内
    ///更新日：2017/01/24
    ///カラム論理名
    ///</summary>
    public partial class D0910_ShohinKensaku : System.Windows.Forms.Form
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ////前画面から年月日を取り出す枠（年月初期値）
        //public string strYMD = "";

        ////前画面から営業所コードを取り出す枠（営業所コード初期値）
        //public string strEigyoushoCode = "";

        ////前画面から大分類コードを取り出す枠（大分類コード初期値）（ラベルセット）
        //public LabelSet_Daibunrui lsDaibunrui = null;

        ////前画面から中分類コードを取り出す枠（中分類コード初期値）（ラベルセット）
        //public LabelSet_Chubunrui lsChubunrui = null;

        ////前画面からメーカーコードを取り出す枠（メーカーコード初期値）（ラベルセット）
        //public LabelSet_Maker lsMaker = null;

        ////前画面から検索コードを取り出す枠（検索コード初期値）（ベーステキスト）
        //public BaseText btxtKensaku = null;

        ////前画面から商品コードを取り出す枠（商品コード初期値）（ベーステキスト）
        //public BaseText btxtShohinCd = null;

        ////前画面から品名を取り出す枠（品名初期値）（Ｃ１のみ）（ベーステキスト）
        //public BaseText btxtHinC1 = null;

        ////前画面から品名を取り出す枠（品名初期値）（Ｃ２のみ）（ベーステキスト）
        //public BaseText btxtHinC2 = null;

        ////前画面から品名を取り出す枠（品名初期値）（Ｃ３のみ）（ベーステキスト）
        //public BaseText btxtHinC3 = null;

        ////前画面から品名を取り出す枠（品名初期値）（Ｃ４のみ）（ベーステキスト）
        //public BaseText btxtHinC4 = null;

        ////前画面から品名を取り出す枠（品名初期値）（Ｃ５のみ）（ベーステキスト）
        //public BaseText btxtHinC5 = null;

        ////前画面から品名を取り出す枠（品名初期値）（Ｃ６のみ）（ベーステキスト）
        //public BaseText btxtHinC6 = null;

        ////前画面から品名を取り出す枠（品名初期値）（Ｃ１~Ｃ６）（ベーステキスト）
        //public BaseText btxtHinC1Hinban = null;

        ////前画面から品名を取り出す枠（品名初期値）（中分類名 + Ｃ１~Ｃ６）（グレイラベル）
        //public BaseLabelGray lblGrayHinChuHinban = null;

        ////前画面から品名を取り出す枠（品名初期値）（メーカー名 + Ｃ１~Ｃ６）（グレイラベル）
        //public BaseLabelGray lblGrayHinMakerHinban = null;

        ////前画面から品名を取り出す枠（品名初期値）（メーカー名 + 中分類名 + Ｃ１~Ｃ６）（グレイラベル）
        //public BaseLabelGray lblGrayHinMakerChuHinban = null;

        ////前画面から品名を取り出す枠（品名初期値）（メーカー名 + 中分類名 + 大分類名 + Ｃ１~Ｃ６）（グレイラベル）
        //public BaseLabelGray lblGrayHinMakerChuDaiHinban = null;

        ////前画面から品名を取り出す枠（品名初期値）（メーカー名 + 中分類コード + 大分類コード + Ｃ１~Ｃ６）（グレイラベル）
        //public BaseLabelGray lblGrayHinMakerDaiCdChuCdHinban = null;

        ////前画面から棚番（本社）を取り出す枠（棚番本社初期値）（ラベルセット）
        //public LabelSet_Tanaban lsTanabanH = null;

        ////前画面から棚番（岐阜）を取り出す枠（棚番岐阜初期値）（ラベルセット）
        //public LabelSet_Tanaban lsTanabanG = null;

        ////前画面から棚番（本社）を取り出す枠（棚番本社初期値）（ベーステキスト）
        //public BaseText btxtTanabanH = null;

        ////前画面から棚番（岐阜）を取り出す枠（棚番岐阜初期値）（ベーステキスト）
        //public BaseText btxtTanabanG = null;

        ////前画面から棚番（本社）を取り出す枠（棚番本社初期値）（グレイラベル）
        //public BaseLabelGray lblGrayTanabanH = null;

        ////前画面から棚番（岐阜）を取り出す枠（棚番岐阜初期値）（グレイラベル）
        //public BaseLabelGray lblGrayTanabanG = null;

        ////前画面から年月日を取り出す枠（グレイラベル）
        //public BaseLabelGray lblGrayYM = null;

        ////前画面から標準売価を取り出す枠（標準売価初期値）（ベーステキストマネー）
        //public BaseTextMoney bmtxtHyojunBaika = null;

        ////前画面から仕入単価を取り出す枠（仕入単価初期値）（ベーステキストマネー）
        //public BaseTextMoney bmtxtShireTanka = null;

        ////前画面から評価単価を取り出す枠（評価単価初期値）（ベーステキストマネー）
        //public BaseTextMoney bmtxtHyokaTanka = null;

        ////前画面から建値仕入単価を取り出す枠（建値仕入単価初期値）（ベーステキストマネー）
        //public BaseTextMoney bmtxtTateneShire = null;

        ////前画面から定価を取り出す枠（定価初期値）（ベーステキストマネー）
        //public BaseTextMoney bmtxtTeika = null;

        ////前画面から箱入数を取り出す枠（箱入数初期値）（ベーステキストマネー）
        //public BaseTextMoney bmtxtHakosu = null;

        ////前画面から在庫管理区分を取り出す枠（品名初期値）（ベーステキスト）
        //public BaseText btxtZaikokbn = null;

        ////前画面からメモを取り出す枠（メモ初期値）（ベーステキスト）
        //public BaseText btxtMemo = null;

        ////前画面からコメントを取り出す枠（コメント初期値）（ベーステキスト）
        //public BaseText btxtComment = null;

        ////前画面から仕入単価を取り出す枠（仕入単価初期値）（コンボボックス）
        //public ComboBox cbShireTanka = null;

        ////商品マスタからかどうかの判定
        //public bool blShohinMaster = false;

        ////検索項目が記入されているかどうか
        //public bool blKensaku = false;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //DB参照の場所を判断（テキストボックスから）
        int intDBjud = 0;

        ////本登録されたデータを呼び出した判定
        //public CheckBox chbxHontoroku;

        Boolean blnZaikoKensaku = true;

        ////表示時専用の本登録データ判定
        //bool blHontorokuDataSub = false;

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
        /// ShouhinList
        /// フォーム関係の設定（通常のテキストボックスから）
        /// </summary>
        public D0910_ShohinKensaku(Control c)
        {
            //画面データが解放されていた時の対策
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

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + 50;

            //中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;

            //// 大分類の引き渡しチェック
            //if (lsDaibunrui == null)
            //{
            //    lsDaibunrui = new LabelSet_Daibunrui();
            //}

            //// 中分類の引き渡しチェック
            //if (lsChubunrui == null)
            //{
            //    lsChubunrui = new LabelSet_Chubunrui();
            //}

            //// メーカーの引き渡しチェック
            //if (lsMaker == null)
            //{
            //    lsMaker = new LabelSet_Maker();
            //}

            //// 検索テキストの引き渡しチェック
            //if (btxtKensaku == null)
            //{
            //    btxtKensaku = new BaseText();
            //}

            //// 商品コードの引き渡しチェック
            //if (btxtShohinCd == null)
            //{
            //    btxtShohinCd = new BaseText();
            //}

            //// 品名の引き渡しチェック（Ｃ１のみ）（ベーステキスト）
            //if (btxtHinC1 == null)
            //{
            //    btxtHinC1 = new BaseText();
            //}

            //// 品名の引き渡しチェック（Ｃ２のみ）（ベーステキスト）
            //if (btxtHinC2 == null)
            //{
            //    btxtHinC2 = new BaseText();
            //}

            //// 品名の引き渡しチェック（Ｃ３のみ）（ベーステキスト）
            //if (btxtHinC3 == null)
            //{
            //    btxtHinC3 = new BaseText();
            //}

            //// 品名の引き渡しチェック（Ｃ４のみ）（ベーステキスト）
            //if (btxtHinC4 == null)
            //{
            //    btxtHinC4 = new BaseText();
            //}

            //// 品名の引き渡しチェック（Ｃ５のみ）（ベーステキスト）
            //if (btxtHinC5 == null)
            //{
            //    btxtHinC5 = new BaseText();
            //}

            //// 品名の引き渡しチェック（Ｃ６のみ）（ベーステキスト）
            //if (btxtHinC6 == null)
            //{
            //    btxtHinC6 = new BaseText();
            //}

            //// 品名の引き渡しチェック（Ｃ１~Ｃ６）（ベーステキスト）
            //if (btxtHinC1Hinban == null)
            //{
            //    btxtHinC1Hinban = new BaseText();
            //}

            //// 品名の引き渡しチェック（中分類名 + Ｃ１~Ｃ６）（グレイラベル）
            //if (lblGrayHinChuHinban == null)
            //{
            //    lblGrayHinChuHinban = new BaseLabelGray();
            //}

            //// 品名の引き渡しチェック（メーカー名 + Ｃ１~Ｃ６）（グレイラベル）
            //if (lblGrayHinMakerHinban == null)
            //{
            //    lblGrayHinMakerHinban = new BaseLabelGray();
            //}

            //// 品名の引き渡しチェック（メーカー名 + 中分類名 + Ｃ１~Ｃ６）（グレイラベル）
            //if (lblGrayHinMakerChuHinban == null)
            //{
            //    lblGrayHinMakerChuHinban = new BaseLabelGray();
            //}

            //// 品名の引き渡しチェック（メーカー名 + 中分類名 + 大分類名 + Ｃ１~Ｃ６）（グレイラベル）
            //if (lblGrayHinMakerChuDaiHinban == null)
            //{
            //    lblGrayHinMakerChuDaiHinban = new BaseLabelGray();
            //}

            //// 品名の引き渡しチェック（メーカー名 + 中分類コード + 大分類コード + Ｃ１~Ｃ６）（グレイラベル）
            //if (lblGrayHinMakerDaiCdChuCdHinban == null)
            //{
            //    lblGrayHinMakerDaiCdChuCdHinban = new BaseLabelGray();
            //}

            //// 棚番本社（本社）の引き渡しチェック（ラベルセット）
            //if (lsTanabanH == null)
            //{
            //    lsTanabanH = new LabelSet_Tanaban();
            //}

            //// 棚番本社（岐阜）の引き渡しチェック（ラベルセット）
            //if (lsTanabanG == null)
            //{
            //    lsTanabanG = new LabelSet_Tanaban();
            //}

            //// 棚番本社（本社）の引き渡しチェック（ベーステキスト）
            //if (btxtTanabanH == null)
            //{
            //    btxtTanabanH = new BaseText();
            //}

            //// 棚番本社（岐阜）の引き渡しチェック（ベーステキスト）
            //if (btxtTanabanG == null)
            //{
            //    btxtTanabanG = new BaseText();
            //}

            //// 棚番本社（本社）の引き渡しチェック（グレイラベル）
            //if (lblGrayTanabanH == null)
            //{
            //    lblGrayTanabanH = new BaseLabelGray();
            //}

            //// 棚番本社（岐阜）の引き渡しチェック（グレイラベル）
            //if (lblGrayTanabanG == null)
            //{
            //    lblGrayTanabanG = new BaseLabelGray();
            //}

            //// 年月の引き渡しチェック（グレイラベル）
            //if (lblGrayYM == null)
            //{
            //    lblGrayYM = new BaseLabelGray();
            //}

            //// 標準売価の引き渡しチェック（ベーステキストマネー）
            //if (bmtxtHyojunBaika == null)
            //{
            //    bmtxtHyojunBaika = new BaseTextMoney();
            //}

            //// 仕入単価の引き渡しチェック（ベーステキストマネー）
            //if (bmtxtShireTanka == null)
            //{
            //    bmtxtShireTanka = new BaseTextMoney();
            //}

            //// 評価単価の引き渡しチェック（ベーステキストマネー）
            //if (bmtxtHyokaTanka == null)
            //{
            //    bmtxtHyokaTanka = new BaseTextMoney();
            //}

            //// 建値仕入単価の引き渡しチェック（ベーステキストマネー）
            //if (bmtxtTateneShire == null)
            //{
            //    bmtxtTateneShire = new BaseTextMoney();
            //}

            //// 箱入数初期値の引き渡しチェック（ベーステキストマネー）
            //if (bmtxtHakosu == null)
            //{
            //    bmtxtHakosu = new BaseTextMoney();
            //}

            //// 在庫管理区分の引き渡しチェック（ベーステキストマネー）
            //if (btxtZaikokbn == null)
            //{
            //    btxtZaikokbn = new BaseText();
            //}

            //// 定価の引き渡しチェック（ベーステキストマネー）
            //if (bmtxtTeika == null)
            //{
            //    bmtxtTeika = new BaseTextMoney();
            //}
            
            //// メモの引き渡しチェック（ベーステキストマネー）
            //if (btxtMemo == null)
            //{
            //    btxtMemo = new BaseText();
            //}

            //// コメントの引き渡しチェック（ベーステキストマネー）
            //if (btxtComment == null)
            //{
            //    btxtComment = new BaseText();
            //}

            //// 仕入単価の引き渡しチェック（コンボボックス）
            //if (cbShireTanka == null)
            //{
            //    cbShireTanka = new ComboBox();
            //}

            //// 本登録されたデータを呼び出した判定
            //if (chbxHontoroku == null)
            //{
            //    chbxHontoroku = new CheckBox();
            //}
        }

        /// <summary>
        /// MakerList_Load
        /// 読み込み時
        /// </summary>
        private void ShouhinList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品リスト";

            //メーカーsetデータを読めるようにする
            labelSet_Daibunrui.Lsmakerdata = labelSet_Maker;

            //setTextData();

            //DataGridViewの初期設定
            setupGrid();

            ////検索単語があれば表示
            //if (blKensaku == true)
            //{
            //    setShohinView();
            //}

            //// 商品マスタからの場合
            //if (blShohinMaster == true)
            //{
            //    radSet_2btn_Toroku.Visible = true;
            //}
            //else
            //{
            //    radSet_2btn_Toroku.Visible = false;
            //}

        }

        ///<summary>
        ///setupGrid
        ///DataGridView初期設定
        ///</summary>
        private void setupGrid()
        {
            //列自動生成禁止
            gridTorihiki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn code = new DataGridViewTextBoxColumn();
            code.DataPropertyName = "商品コード";
            code.Name = "商品コード";
            code.HeaderText = "商品コード";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー";
            maker.Name = "メーカー";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn daibunrui = new DataGridViewTextBoxColumn();
            daibunrui.DataPropertyName = "大分類名";
            daibunrui.Name = "大分類名";
            daibunrui.HeaderText = "大分類名";

            DataGridViewTextBoxColumn chubunrui = new DataGridViewTextBoxColumn();
            chubunrui.DataPropertyName = "中分類名";
            chubunrui.Name = "中分類名";
            chubunrui.HeaderText = "中分類名";

            DataGridViewTextBoxColumn hinmei = new DataGridViewTextBoxColumn();
            hinmei.DataPropertyName = "品名";
            hinmei.Name = "品名";
            hinmei.HeaderText = "品名";

            DataGridViewTextBoxColumn honshazaiko = new DataGridViewTextBoxColumn();
            honshazaiko.DataPropertyName = "本社在庫";
            honshazaiko.Name = "本社在庫";
            honshazaiko.HeaderText = "本社在庫";

            DataGridViewTextBoxColumn honshafree = new DataGridViewTextBoxColumn();
            honshafree.DataPropertyName = "本社ﾌﾘｰ";
            honshafree.Name = "本社ﾌﾘｰ";
            honshafree.HeaderText = "本社ﾌﾘｰ";

            DataGridViewTextBoxColumn gihuzaiko = new DataGridViewTextBoxColumn();
            gihuzaiko.DataPropertyName = "岐阜在庫";
            gihuzaiko.Name = "岐阜在庫";
            gihuzaiko.HeaderText = "岐阜在庫";

            DataGridViewTextBoxColumn gihufree = new DataGridViewTextBoxColumn();
            gihufree.DataPropertyName = "岐阜ﾌﾘｰ";
            gihufree.Name = "岐阜ﾌﾘｰ";
            gihufree.HeaderText = "岐阜ﾌﾘｰ";

            DataGridViewTextBoxColumn teika = new DataGridViewTextBoxColumn();
            teika.DataPropertyName = "定価";
            teika.Name = "定価";
            teika.HeaderText = "定価";

            DataGridViewTextBoxColumn kakeritu = new DataGridViewTextBoxColumn();
            kakeritu.DataPropertyName = "掛率";
            kakeritu.Name = "掛率";
            kakeritu.HeaderText = "掛率";

            DataGridViewTextBoxColumn shiretanka = new DataGridViewTextBoxColumn();
            shiretanka.DataPropertyName = "仕入単価";
            shiretanka.Name = "仕入単価";
            shiretanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn memo = new DataGridViewTextBoxColumn();
            memo.DataPropertyName = "メモ";
            memo.Name = "メモ";
            memo.HeaderText = "メモ";

            //個々の幅、文章の寄せ
            setColumnShohin(code, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnShohin(daibunrui, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnShohin(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnShohin(chubunrui, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnShohin(hinmei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 328);
            setColumnShohin(honshazaiko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumnShohin(honshafree, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumnShohin(gihuzaiko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumnShohin(gihufree, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumnShohin(teika, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumnShohin(kakeritu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 75);
            setColumnShohin(shiretanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 120);
            setColumnShohin(memo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 190);

            //メーカーコードと大分類コードの列を非表示
            gridTorihiki.Columns[0].Visible = false;
            gridTorihiki.Columns[1].Visible = false;

        }

        ///<summary>
        ///setColumnShohin
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumnShohin(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridTorihiki.Columns.Add(col);
            if (gridTorihiki.Columns[col.Name] != null)
            {
                gridTorihiki.Columns[col.Name].Width = intLen;
                gridTorihiki.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridTorihiki.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridTorihiki.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///judShouhinListKeyDown
        ///キー入力判定
        ///</summary>
        private void judShouhinListKeyDown(object sender, KeyEventArgs e)
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
                    //検索ボタン
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    this.btnKensakuClick(sender, e);
                    break;
                case Keys.F12:
                    //戻るボタン
                    logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));
                    this.btnEndClick(sender, e);
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judTokuiListTxtKeyDown
        ///キー入力判定(テキストボックス)
        ///</summary>
        private void judTokuiListTxtKeyDown(object sender, KeyEventArgs e)
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

        /////<summary>
        /////judTokuiListGridKeyDown
        /////キー入力判定(グリッド)
        /////</summary>
        //private void judTokuiListGridKeyDown(object sender, KeyEventArgs e)
        //{
        //    //キー入力情報によって動作を変える
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Tab:
        //            break;
        //        case Keys.Left:
        //            break;
        //        case Keys.Right:
        //            break;
        //        case Keys.Up:
        //            break;
        //        case Keys.Down:
        //            break;
        //        case Keys.Delete:
        //            break;
        //        case Keys.Back:
        //            break;
        //        case Keys.Enter:
        //            //グリッド選択
        //            setSelectItem();
        //            break;
        //        case Keys.F1:
        //            break;
        //        case Keys.F2:
        //            break;
        //        case Keys.F3:
        //            break;
        //        case Keys.F4:
        //            break;
        //        case Keys.F5:
        //            break;
        //        case Keys.F6:
        //            break;
        //        case Keys.F7:
        //            break;
        //        case Keys.F8:
        //            break;
        //        case Keys.F9:
        //            break;
        //        case Keys.F10:
        //            break;
        //        case Keys.F11:
        //            break;
        //        case Keys.F12:
        //            break;

        //        default:
        //            break;
        //    }
        //}

        /////<summary>
        /////setGridTorihiki_DoubleClick
        /////データグリッドビュー内のデータをダブルクリックしたとき
        /////</summary>
        //private void setGridTorihiki_DoubleClick(object sender, EventArgs e)
        //{
        //    setSelectItem();
        //}
        
        /////<summary>
        /////setSelectItem
        /////データグリッドビュー内のデータ選択後の処理
        /////</summary>
        //private void setSelectItem()
        //{
        //    //グリッド内が空の場合
        //    if (gridTorihiki.Rows.Count < 1)
        //    {
        //        return;
        //    }

        //    //データ渡し用
        //    List<int> lstInt = new List<int>();

        //    //商品検索結果を格納用
        //    DataTable dtShohin = new DataTable();

        //    if (intFrmKind == 0)
        //    {
        //        return;
        //    }

        //    //選択行のcode取得
        //    string strSelectid = (string)gridTorihiki.CurrentRow.Cells[4].Value;
        //    //選択行の商品コード取得
        //    string strSelectShohinCD = (string)gridTorihiki.CurrentRow.Cells["商品コード"].Value;
        //    //選択行のメーカーコード取得
        //    string strSelectMakerCD = (string)gridTorihiki.CurrentRow.Cells["メーカー"].Value;
        //    //選択行の大分類名取得
        //    string strSelectDaibunName = (string)gridTorihiki.CurrentRow.Cells["大分類名"].Value;
        //    //選択行の中分類名取得
        //    string strSelectChubunName = (string)gridTorihiki.CurrentRow.Cells["中分類名"].Value;

        //    D0910_ShohinKensaku_B shohinlistB = new D0910_ShohinKensaku_B();
        //    try
        //    {
        //        dtShohin = shohinlistB.getSelectItem(strSelectShohinCD, blHontorokuDataSub);

        //        //検索結果がない場合
        //        if (dtShohin.Rows.Count <= 0)
        //        {
        //            return;
        //        }

        //        //各データを各項目に入れる
        //        setItemData(dtShohin);
        //    }
        //    catch (Exception ex)
        //    {
        //        new CommonException(ex);
        //        //例外発生メッセージ（OK）
        //        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
        //        basemessagebox.ShowDialog();
        //        return;
        //    }
        //    setEndAction();
        //}

        /////<summary>
        /////setItemData
        /////各データを各項目に入れる
        /////</summary>
        //private void setItemData(DataTable dtShohin)
        //{
        //    //本登録かどうかの判定(商品マスターの影響で先にやる必要あり)
        //    if (this.blHontorokuDataSub)
        //    {
        //        this.chbxHontoroku.Checked = true;
        //    }
        //    else
        //    {
        //        this.chbxHontoroku.Checked = false;
        //    }

        //    //大分類
        //    this.lsDaibunrui.CodeTxtText = dtShohin.Rows[0]["大分類コード"].ToString();
        //    this.lsDaibunrui.chkTxtDaibunrui();

        //    //中分類
        //    this.lsChubunrui.CodeTxtText = dtShohin.Rows[0]["中分類コード"].ToString();
        //    this.lsChubunrui.chkTxtChubunrui(dtShohin.Rows[0]["大分類コード"].ToString());

        //    //メーカーコード
        //    this.lsMaker.CodeTxtText = dtShohin.Rows[0]["メーカーコード"].ToString();
        //    this.lsMaker.chkTxtMaker();

        //    //検索データ
        //    this.btxtKensaku.Text = txtKensaku.Text.Trim();

        //    //商品コード
        //    this.btxtShohinCd.Text = dtShohin.Rows[0]["商品コード"].ToString().Trim();

        //    //品名（Ｃ１のみ）（ベーステキスト）
        //    this.btxtHinC1.Text = dtShohin.Rows[0]["Ｃ１"].ToString().Trim();

        //    //品名（Ｃ２のみ）（ベーステキスト）
        //    this.btxtHinC2.Text = dtShohin.Rows[0]["Ｃ２"].ToString().Trim();

        //    //品名（Ｃ３のみ）（ベーステキスト）
        //    this.btxtHinC3.Text = dtShohin.Rows[0]["Ｃ３"].ToString().Trim();

        //    //品名（Ｃ４のみ）（ベーステキスト）
        //    this.btxtHinC4.Text = dtShohin.Rows[0]["Ｃ４"].ToString().Trim();

        //    //品名（Ｃ５のみ）（ベーステキスト）
        //    this.btxtHinC5.Text = dtShohin.Rows[0]["Ｃ５"].ToString().Trim();

        //    //品名（Ｃ６のみ）（ベーステキスト）
        //    this.btxtHinC6.Text = dtShohin.Rows[0]["Ｃ６"].ToString().Trim();

        //    //品名（Ｃ１~Ｃ６）（ベーステキスト）
        //    this.btxtHinC1Hinban.Text = this.btxtHinC1.Text +
        //                                " " +
        //                                this.btxtHinC2.Text +
        //                                " " +
        //                                this.btxtHinC3.Text +
        //                                " " +
        //                                this.btxtHinC4.Text +
        //                                " " +
        //                                this.btxtHinC5.Text +
        //                                " " +
        //                                this.btxtHinC6.Text;

        //    //品名（中分類名 + Ｃ１~Ｃ６）（グレイラベル）
        //    this.lblGrayHinChuHinban.Text = lsChubunrui.ValueLabelText.Trim() +
        //                                       " " +
        //                                       this.btxtHinC1.Text +
        //                                       " " +
        //                                       this.btxtHinC2.Text +
        //                                       " " +
        //                                       this.btxtHinC3.Text +
        //                                       " " +
        //                                       this.btxtHinC4.Text +
        //                                       " " +
        //                                       this.btxtHinC5.Text +
        //                                       " " +
        //                                       this.btxtHinC6.Text;

        //    //品名（（メーカー名 + Ｃ１~Ｃ６）（グレイラベル）
        //    this.lblGrayHinMakerHinban.Text = lsMaker.ValueLabelText.Trim() +
        //                                      " " +
        //                                      this.btxtHinC1.Text +
        //                                      " " +
        //                                      this.btxtHinC2.Text +
        //                                      " " +
        //                                      this.btxtHinC3.Text +
        //                                      " " +
        //                                      this.btxtHinC4.Text +
        //                                      " " +
        //                                      this.btxtHinC5.Text +
        //                                      " " +
        //                                      this.btxtHinC6.Text;

        //    //品名（（メーカー名 + 中分類名 + Ｃ１~Ｃ６）（グレイラベル）
        //    this.lblGrayHinMakerChuHinban.Text = lsMaker.ValueLabelText.Trim() +
        //                                            " " +
        //                                            lsChubunrui.ValueLabelText.Trim() +
        //                                            " " +
        //                                            this.btxtHinC1.Text +
        //                                            " " +
        //                                            this.btxtHinC2.Text +
        //                                             " " +
        //                                            this.btxtHinC3.Text +
        //                                            " " +
        //                                            this.btxtHinC4.Text +
        //                                            " " +
        //                                            this.btxtHinC5.Text +
        //                                            " " +
        //                                            this.btxtHinC6.Text;

        //    //品名（（メーカー名 + 大分類コード + 中分類コード + Ｃ１~Ｃ６）（グレイラベル）
        //    this.lblGrayHinMakerDaiCdChuCdHinban.Text = lsMaker.ValueLabelText.Trim() +
        //                                            " " +
        //                                            lsDaibunrui.CodeTxtText +
        //                                            " " +
        //                                            lsChubunrui.CodeTxtText +
        //                                            " " +
        //                                            this.btxtHinC1.Text +
        //                                            " " +
        //                                            this.btxtHinC2.Text +
        //                                             " " +
        //                                            this.btxtHinC3.Text +
        //                                            " " +
        //                                            this.btxtHinC4.Text +
        //                                            " " +
        //                                            this.btxtHinC5.Text +
        //                                            " " +
        //                                            this.btxtHinC6.Text;

        //    //棚番本社（ラベルセット）
        //    this.lsTanabanH.CodeTxtText = dtShohin.Rows[0]["棚番本社"].ToString();

        //    //棚番岐阜（ラベルセット）
        //    this.lsTanabanG.CodeTxtText = dtShohin.Rows[0]["棚番岐阜"].ToString();

        //    //棚番本社（ベーステキスト）
        //    this.btxtTanabanH.Text = dtShohin.Rows[0]["棚番本社"].ToString();

        //    //棚番岐阜（ベーステキスト）
        //    this.btxtTanabanG.Text = dtShohin.Rows[0]["棚番岐阜"].ToString();

        //    //棚番本社（グレイラベル）
        //    this.lblGrayTanabanH.Text = dtShohin.Rows[0]["棚番本社"].ToString();

        //    //棚番岐阜（グレイラベル）
        //    this.lblGrayTanabanG.Text = dtShohin.Rows[0]["棚番岐阜"].ToString();

        //    //年月（グレイラベル）
        //    this.lblGrayYM.Text = ((DateTime)dtShohin.Rows[0]["登録日時"]).ToString("yyyy/MM/dd");

        //    //標準売価（ベーステキストマネー）
        //    this.bmtxtHyojunBaika.Text = dtShohin.Rows[0]["標準売価"].ToString();
        //    this.bmtxtHyojunBaika.updPriceMethod();

        //    //仕入単価（ベーステキストマネー）
        //    this.bmtxtShireTanka.Text = dtShohin.Rows[0]["仕入単価"].ToString();
        //    this.bmtxtShireTanka.updPriceMethod();

        //    //定価（ベーステキストマネー）
        //    this.bmtxtTeika.Text = dtShohin.Rows[0]["定価"].ToString();
        //    this.bmtxtTeika.updPriceMethod();

        //    //評価単価（ベーステキストマネー）
        //    this.bmtxtHyokaTanka.Text = dtShohin.Rows[0]["評価単価"].ToString();
        //    this.bmtxtHyokaTanka.updPriceMethod();

        //    //建値仕入単価（ベーステキストマネー）
        //    this.bmtxtTateneShire.Text = dtShohin.Rows[0]["建値仕入単価"].ToString();
        //    this.bmtxtTateneShire.updPriceMethod();

        //    //箱入数初期値（ベーステキストマネー）
        //    this.bmtxtHakosu.Text = dtShohin.Rows[0]["箱入数"].ToString();
        //    this.bmtxtHakosu.updPriceMethod();

        //    //在庫管理区分（ベーステキストマネー）
        //    this.btxtZaikokbn.Text = dtShohin.Rows[0]["在庫管理区分"].ToString();

        //    //メモ（ベーステキストマネー）
        //    this.btxtMemo.Text = dtShohin.Rows[0]["メモ"].ToString();

        //    //コメント（ベーステキストマネー）
        //    this.btxtComment.Text = dtShohin.Rows[0]["コメント"].ToString();

        //    //仕入単価（コンボボックス
        //    this.cbShireTanka.Text = dtShohin.Rows[0]["仕入単価"].ToString();
        //}

        /////<summary>
        /////setTextData
        /////前画面のデータを記入
        /////</summary>
        //private void setTextData()
        //{
        //    if (lsDaibunrui.CodeTxtText.ToString().Length >= 1)
        //    {
        //        labelSet_Daibunrui.CodeTxtText = lsDaibunrui.CodeTxtText.ToString();

        //        //leaveの処理をする
        //        labelSet_Daibunrui.setTxtDaibunruiLeave();
        //        intDBjud = 1;
        //        setLabel(intDBjud);
        //    }
        //    if (lsChubunrui.CodeTxtText.ToString().Length >= 1)
        //    {
        //        labelSet_Chubunrui.CodeTxtText = lsChubunrui.CodeTxtText.ToString();

        //        //leaveの処理をする
        //        labelSet_Chubunrui.setTxtChubunruiLeave();
        //        intDBjud = 2;
        //        setLabel(intDBjud);
        //    }
        //    if (lsMaker.CodeTxtText.ToString().Length >= 1)
        //    {
        //        labelSet_Maker.CodeTxtText = lsMaker.CodeTxtText.ToString();
        //        intDBjud = 3;
        //        setLabel(intDBjud);
        //    }
        //    txtKensaku.Text = btxtKensaku.Text;
        //}
        
        ///<summary>
        ///btnEndClick
        ///戻るボタンを押したとき
        ///</summary>
        private void btnEndClick(object sender, EventArgs e)
        {
            setEndAction();
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///</summary>
        private void setEndAction()
        {
            logger.Info(LogUtil.getMessage(this._Title, "戻る実行"));

            //画面を隠す
            this.Hide();

            //D0910_ShohinKensaku_B shohinlistB = new D0910_ShohinKensaku_B();
            //try
            //{
            //    shohinlistB.FormMove(intFrmKind);
            //}
            //catch (Exception ex)
            //{
            //    new CommonException(ex);
            //    //例外発生メッセージ（OK）
            //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
            //    basemessagebox.ShowDialog();
            //    return;
            //}
        }
        
        ///<summary>
        ///btnKensakuClick
        ///検索ボタンを押したとき
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            gridTorihiki.Columns.Clear();

            //DataGridViewの初期設定
            setupGrid();

            setShohinView();
        }


        ///<summary>
        ///setShohinView
        ///検索データを記入
        ///</summary>
        public void setShohinView()
        {
            //グリッド内の削除
            gridTorihiki.DataSource = "";

            logger.Info(LogUtil.getMessage(this._Title, "検索実行"));

            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();
            List<Boolean> lstBoolean = new List<Boolean>();

            gridTorihiki.Enabled = true;
            gridTorihiki.DataSource = null;
            DataTable dtView = new DataTable();

            //数値チェックに使う
            double dblKensaku = 0;

            //数値チェック後に確保用
            string strUkata = "";
            string strUkataHuku = "";

            //検索文字列がある場合の処理
            if (txtKensaku.blIsEmpty())
            {
                //数値チェック
                if (!double.TryParse(txtKensaku.Text, out dblKensaku))
                {
                    //そのまま確保
                    strUkata = txtKensaku.Text;
                }
                else
                {
                    //空白削除
                    strUkata = txtKensaku.Text.Trim();
                }

                //英字を大文字に
                strUkata = strUkata.ToUpper();

                strUkata = strUkata.Replace(" ", "");
            }

            //副番がある場合の処理
            if (txtKensakuHuku.blIsEmpty())
            {
                //数値チェック
                if (!double.TryParse(txtKensakuHuku.Text, out dblKensaku))
                {
                    //そのまま確保
                    strUkataHuku = txtKensakuHuku.Text;
                }
                else
                {
                    //空白削除
                    strUkataHuku = txtKensakuHuku.Text.Trim();
                }

                //英字を大文字に
                strUkata = strUkata.ToUpper();

                strUkata = strUkata.Replace(" ", "");
            }

            //データ渡し用
            lstInt.Add(intFrmKind);
            lstInt.Add(0);

            lstString.Add(labelSet_Daibunrui.CodeTxtText);      //大分類コード
            lstString.Add(labelSet_Chubunrui.CodeTxtText);      //中分類コード
            lstString.Add(labelSet_Maker.CodeTxtText);          //メーカーコード
            lstString.Add(strUkata);                            //型番
            lstString.Add(strUkataHuku);                        //副番
            lstString.Add(DateTime.Now.ToString("yyyy/MM/dd")); //今日のYMD

            lstBoolean.Add(chkNotToroku.Checked);               //登録棚判定
            lstBoolean.Add(radSet_2btn_Kensaku.radbtn0.Checked);//部分一致判定
            lstBoolean.Add(radSet_2btn_Toroku.radbtn0.Checked); //本登録判定

            D0910_ShohinKensaku_B shohinlistB = new D0910_ShohinKensaku_B();
            try
            {
                dtView = shohinlistB.getShohinView(lstInt, lstString, lstBoolean, blnZaikoKensaku);

                //在庫数の小数点以下を削除
                DataColumnCollection columns = dtView.Columns;

                //指定日在庫、棚卸数量の小数点切り下げ
                for (int cnt = 0; cnt < dtView.Rows.Count; cnt++)
                {
                    //本社在庫が空でない場合
                    if (dtView.Rows[cnt]["本社在庫"].ToString() != "")
                    {
                        dtView.Rows[cnt]["本社在庫"] = dtView.Rows[cnt]["本社在庫"].ToString();
                    }

                    //本社ﾌﾘｰが空でない場合
                    if (dtView.Rows[cnt]["本社ﾌﾘｰ"].ToString() != "")
                    {
                        dtView.Rows[cnt]["本社ﾌﾘｰ"] = dtView.Rows[cnt]["本社ﾌﾘｰ"].ToString();
                    }

                    //岐阜在庫が空でない場合
                    if (dtView.Rows[cnt]["岐阜在庫"].ToString() != "")
                    {
                        dtView.Rows[cnt]["岐阜在庫"] = dtView.Rows[cnt]["岐阜在庫"].ToString();
                    }

                    //岐阜ﾌﾘｰが空でない場合
                    if (dtView.Rows[cnt]["岐阜ﾌﾘｰ"].ToString() != "")
                    {
                        dtView.Rows[cnt]["岐阜ﾌﾘｰ"] = dtView.Rows[cnt]["岐阜ﾌﾘｰ"].ToString();
                    }
                }

                gridTorihiki.DataSource = dtView;
                this.gridTorihiki.Columns["商品コード"].Visible = false;

                lblRecords.Text = "該当件数(" + gridTorihiki.RowCount.ToString() + "件)";

                ////本検索フラグがある場合
                //if (radSet_2btn_Toroku.radbtn0.Checked)
                //{
                //    blHontorokuDataSub = true;
                //}
                //else
                //{
                //    blHontorokuDataSub = false;
                //}

                gridTorihiki.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        /////<summary>
        /////setLabel
        /////textboxのデータをlabelに記入
        /////</summary>
        //private void setLabel(int intDBjud)
        //{
        //    //データ渡し用
        //    List<string> lstString = new List<string>();
        //    List<int> lstInt = new List<int>();

        //    DataTable dtSetData = new DataTable();

        //    //データ渡し用
        //    lstString.Add(labelSet_Daibunrui.CodeTxtText);
        //    lstString.Add(labelSet_Chubunrui.CodeTxtText);
        //    lstString.Add(labelSet_Maker.CodeTxtText);

        //    lstInt.Add(intDBjud);

        //    D0910_ShohinKensaku_B shohinlistB = new D0910_ShohinKensaku_B();
        //    try
        //    {
        //        dtSetData = shohinlistB.getLabel(lstString, lstInt);

        //        //テキストボックスが空白のままの場合
        //        if (dtSetData == null)
        //        {
        //            return;
        //        }

        //        if (dtSetData.Rows.Count != 0)
        //        {
        //            switch (intDBjud)
        //            {
        //                case 1://大分類
        //                    labelSet_Daibunrui.CodeTxtText = dtSetData.Rows[0]["大分類コード"].ToString();
        //                    labelSet_Daibunrui.ValueLabelText = dtSetData.Rows[0]["大分類名"].ToString();
        //                    break;
        //                case 2://中分類
        //                    labelSet_Chubunrui.CodeTxtText = dtSetData.Rows[0]["中分類コード"].ToString();
        //                    labelSet_Chubunrui.ValueLabelText = dtSetData.Rows[0]["中分類名"].ToString();
        //                    break;
        //                case 3://メーカー
        //                    labelSet_Maker.CodeTxtText = dtSetData.Rows[0]["メーカーコード"].ToString();
        //                    labelSet_Maker.ValueLabelText = dtSetData.Rows[0]["メーカー名"].ToString();
        //                    break;
        //                default:
        //                    return;
        //            }
        //            //初期化
        //            intDBjud = 0;
        //        }
        //        else
        //        {
        //            //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
        //            BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
        //            basemessagebox.ShowDialog();

        //            switch (intDBjud)
        //            {
        //                case 1://大分類
        //                    labelSet_Daibunrui.CodeTxtText = "";
        //                    labelSet_Daibunrui.Focus();
        //                    break;
        //                case 2://中分類
        //                    labelSet_Chubunrui.CodeTxtText = "";
        //                    labelSet_Chubunrui.Focus();
        //                    break;
        //                case 3://メーカー
        //                    labelSet_Maker.CodeTxtText = "";
        //                    labelSet_Maker.Focus();
        //                    break;
        //                default:
        //                    return;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        new CommonException(ex);
        //        //例外発生メッセージ（OK）
        //        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
        //        basemessagebox.ShowDialog();
        //        return;
        //    }
        //}

        ///<summary>
        ///setDaibunrui
        ///取り出したデータをテキストボックスに配置（大分類）
        ///</summary>
        public void setDaibunrui(DataTable dtSelectData)
        {
            labelSet_Daibunrui.CodeTxtText = dtSelectData.Rows[0]["大分類コード"].ToString();
            labelSet_Daibunrui.ValueLabelText = dtSelectData.Rows[0]["大分類名"].ToString();
        }

        ///<summary>
        ///setCyubunrui
        ///取り出したデータをテキストボックスに配置（中分類）
        ///</summary>
        public void setChubunrui(DataTable dtSelectData)
        {
            labelSet_Chubunrui.CodeTxtText = dtSelectData.Rows[0]["中分類コード"].ToString();
            labelSet_Chubunrui.ValueLabelText = dtSelectData.Rows[0]["中分類名"].ToString();
        }

        ///<summary>
        ///setMakerCode
        ///取り出したデータをテキストボックスに配置（メーカー）
        ///</summary>
        public void setMakerCode(DataTable dtSelectData)
        {
            labelSet_Maker.CodeTxtText = dtSelectData.Rows[0]["メーカーコード"].ToString();
            labelSet_Maker.ValueLabelText = dtSelectData.Rows[0]["メーカー名"].ToString();
        }

        ///<summary>
        ///setDaibunruiListClose
        ///DaibunruiiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void CloseDaibunruiList()
        {
            labelSet_Daibunrui.Focus();
        }

        ///<summary>
        ///setChubunruiListClose
        ///ChubunruiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setChubunruiListClose()
        {
            labelSet_Chubunrui.Focus();
        }

        ///<summary>
        ///setMakerListClose
        ///MakerListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setMakerListClose()
        {
            labelSet_Maker.Focus();
        }

        ///<summary>
        ///setChubun
        ///中分類のチェック
        ///</summary>
        public void setChubun()
        {
            labelSet_Chubunrui.setTxtChubunruiLeave();
        }

        ///<summary>
        ///form_KeyPress
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
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
