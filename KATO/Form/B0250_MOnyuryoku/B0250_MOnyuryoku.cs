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
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Business.B0250_MOnyuryoku;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.B0250_MOnyuryoku
{
    ///<summary>
    ///MOnyuryoku
    ///MO入力フォーム
    ///作成者：大河内
    ///作成日：2017/2/2
    ///更新者：大河内
    ///更新日：2017/2/2
    ///カラム論理名
    ///</summary>
    public partial class B0250_MOnyuryoku : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///MOnyuryoku
        ///フォームの初期設定
        ///</summary>
        public B0250_MOnyuryoku(Control c)
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

            //中分類setデータを読めるようにする
            lblSetDaibunrui.Lschubundata = lblSetChubunrui;
        }

        ///<summary>
        ///MOnyuryoku_Load
        ///画面レイアウト設定
        ///</summary>
        private void MOnyuryoku_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "ＭＯ入力";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF06.Text = "F6:再計算";
            this.btnF08.Text = "F8:得値";
            this.btnF10.Text = "F10:ｴｸｾﾙ取込";
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            //DataGridViewの初期設定
            SetUpGrid();

            radSet_2btn_PrintCheck.radbtn1.Checked = true;
            txtYM.setUp(3);
            txtZaikoYMD.setUp(0);
        }

        ///<summary>
        ///SetUpGrid
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            System.DateTime dateStartYMD;

            //列自動生成禁止
            gridKataban.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn KKataban = new DataGridViewTextBoxColumn();
            KKataban.DataPropertyName = "型番";
            KKataban.Name = "型番";
            KKataban.HeaderText = "型番";

            DataGridViewTextBoxColumn KFreezaiko = new DataGridViewTextBoxColumn();
            KFreezaiko.DataPropertyName = "ﾌﾘｰ在庫";
            KFreezaiko.Name = "ﾌﾘｰ在庫";
            KFreezaiko.HeaderText = "ﾌﾘｰ在庫";
            
            DataGridViewTextBoxColumn KUriagesu = new DataGridViewTextBoxColumn();
            KUriagesu.DataPropertyName = "売上数";
            KUriagesu.Name = "売上数";
            KUriagesu.HeaderText = "売上数";

            DataGridViewTextBoxColumn KShiresu = new DataGridViewTextBoxColumn();
            KShiresu.DataPropertyName = "仕入数";
            KShiresu.Name = "仕入数";
            KShiresu.HeaderText = "仕入数";

            DataGridViewTextBoxColumn KHachuzan = new DataGridViewTextBoxColumn();
            KHachuzan.DataPropertyName = "発注残";
            KHachuzan.Name = "発注残";
            KHachuzan.HeaderText = "発注残";

            DataGridViewTextBoxColumn KJuchuzan = new DataGridViewTextBoxColumn();
            KJuchuzan.DataPropertyName = "受注残";
            KJuchuzan.Name = "受注残";
            KJuchuzan.HeaderText = "受注残";

            DataGridViewTextBoxColumn KHachusu = new DataGridViewTextBoxColumn();
            KHachusu.DataPropertyName = "発注数";
            KHachusu.Name = "発注数";
            KHachusu.HeaderText = "発注数";

            DataGridViewTextBoxColumn KTanka = new DataGridViewTextBoxColumn();
            KTanka.DataPropertyName = "単価";
            KTanka.Name = "単価";
            KTanka.HeaderText = "単価";

            DataGridViewTextBoxColumn KKingaku = new DataGridViewTextBoxColumn();
            KKingaku.DataPropertyName = "金額";
            KKingaku.Name = "金額";
            KKingaku.HeaderText = "金額";

            DataGridViewTextBoxColumn KNoki = new DataGridViewTextBoxColumn();
            KNoki.DataPropertyName = "納期";
            KNoki.Name = "納期";
            KNoki.HeaderText = "納期";

            DataGridViewTextBoxColumn KCode = new DataGridViewTextBoxColumn();
            KCode.DataPropertyName = "ｺｰﾄﾞ";
            KCode.Name = "ｺｰﾄﾞ";
            KCode.HeaderText = "ｺｰﾄﾞ";

            DataGridViewTextBoxColumn KShimukesakiname = new DataGridViewTextBoxColumn();
            KShimukesakiname.DataPropertyName = "仕向け先名";
            KShimukesakiname.Name = "仕向け先名";
            KShimukesakiname.HeaderText = "仕向け先名";

            DataGridViewTextBoxColumn KHachuNo1 = new DataGridViewTextBoxColumn();
            KHachuNo1.DataPropertyName = "発注番号";
            KHachuNo1.Name = "発注番号";
            KHachuNo1.HeaderText = "発注番号";

            DataGridViewTextBoxColumn KHachuNo2 = new DataGridViewTextBoxColumn();
            KHachuNo2.DataPropertyName = "発注番号";
            KHachuNo2.Name = "発注番号";
            KHachuNo2.HeaderText = "発注番号";

            DataGridViewTextBoxColumn KShohinCd = new DataGridViewTextBoxColumn();
            KShohinCd.DataPropertyName = "商品コード";
            KShohinCd.Name = "商品コード";
            KShohinCd.HeaderText = "商品コード";

            DataGridViewTextBoxColumn KC1 = new DataGridViewTextBoxColumn();
            KC1.DataPropertyName = "Ｃ１";
            KC1.Name = "Ｃ１";
            KC1.HeaderText = "Ｃ１";

            DataGridViewTextBoxColumn KC2 = new DataGridViewTextBoxColumn();
            KC2.DataPropertyName = "Ｃ２";
            KC2.Name = "Ｃ２";
            KC2.HeaderText = "Ｃ２";

            DataGridViewTextBoxColumn KC3 = new DataGridViewTextBoxColumn();
            KC3.DataPropertyName = "Ｃ３";
            KC3.Name = "Ｃ３";
            KC3.HeaderText = "Ｃ３";

            DataGridViewTextBoxColumn KC4 = new DataGridViewTextBoxColumn();
            KC4.DataPropertyName = "Ｃ４";
            KC4.Name = "Ｃ４";
            KC4.HeaderText = "Ｃ４";

            DataGridViewTextBoxColumn KC5 = new DataGridViewTextBoxColumn();
            KC5.DataPropertyName = "Ｃ５";
            KC5.Name = "Ｃ５";
            KC5.HeaderText = "Ｃ５";

            DataGridViewTextBoxColumn KC6 = new DataGridViewTextBoxColumn();
            KC6.DataPropertyName = "Ｃ６";
            KC6.Name = "Ｃ６";
            KC6.HeaderText = "Ｃ６";

            DataGridViewTextBoxColumn KHakorisu = new DataGridViewTextBoxColumn();
            KHakorisu.DataPropertyName = "箱入数";
            KHakorisu.Name = "箱入数";
            KHakorisu.HeaderText = "箱入数";

            DataGridViewTextBoxColumn KSaishushirebi = new DataGridViewTextBoxColumn();
            KSaishushirebi.DataPropertyName = "最終仕入日";
            KSaishushirebi.Name = "最終仕入日";
            KSaishushirebi.HeaderText = "最終仕入日";



            //個々の幅、文章の寄せ（納期非表示）
            setColumnKataban(KKataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumnKataban(KFreezaiko, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumnKataban(KUriagesu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            setColumnKataban(KShiresu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumnKataban(KHachuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);

            setColumnKataban(KJuchuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumnKataban(KHachusu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumnKataban(KTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            setColumnKataban(KKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);

            //非表示
            setColumnKataban(KNoki, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);

            setColumnKataban(KCode, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);

            setColumnKataban(KShimukesakiname, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            setColumnKataban(KHachuNo1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            setColumnKataban(KHachuNo2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);

            setColumnKataban(KShohinCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban(KC1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban(KC2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban(KC3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban(KC4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban(KC5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban(KC6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);

            //対象列を非表示
            gridKataban.Columns["納期"].Visible = false;
            gridKataban.Columns["商品コード"].Visible = false;
            gridKataban.Columns["Ｃ１"].Visible = false;
            gridKataban.Columns["Ｃ２"].Visible = false;
            gridKataban.Columns["Ｃ３"].Visible = false;
            gridKataban.Columns["Ｃ４"].Visible = false;
            gridKataban.Columns["Ｃ５"].Visible = false;
            gridKataban.Columns["Ｃ６"].Visible = false;


            //データをバインド
            DataGridViewTextBoxColumn K2Kataban = new DataGridViewTextBoxColumn();
            K2Kataban.DataPropertyName = "型番";
            K2Kataban.Name = "型番";
            K2Kataban.HeaderText = "型番";

            DataGridViewTextBoxColumn K2Freezaiko = new DataGridViewTextBoxColumn();
            K2Freezaiko.DataPropertyName = "ﾌﾘｰ在庫";
            K2Freezaiko.Name = "ﾌﾘｰ在庫";
            K2Freezaiko.HeaderText = "ﾌﾘｰ在庫";

            DataGridViewTextBoxColumn K2Shiresu = new DataGridViewTextBoxColumn();
            K2Shiresu.DataPropertyName = "仕入数";
            K2Shiresu.Name = "仕入数";
            K2Shiresu.HeaderText = "仕入数";

            DataGridViewTextBoxColumn K2Hachuzan = new DataGridViewTextBoxColumn();
            K2Hachuzan.DataPropertyName = "発注残";
            K2Hachuzan.Name = "発注残";
            K2Hachuzan.HeaderText = "発注残";

            DataGridViewTextBoxColumn K2Juchuzan = new DataGridViewTextBoxColumn();
            K2Juchuzan.DataPropertyName = "受注残";
            K2Juchuzan.Name = "受注残";
            K2Juchuzan.HeaderText = "受注残";

            DataGridViewTextBoxColumn K2Hachushi = new DataGridViewTextBoxColumn();
            K2Hachushi.DataPropertyName = "発注指";
            K2Hachushi.Name = "発注指";
            K2Hachushi.HeaderText = "発注指";

            DataGridViewTextBoxColumn K2Uriagesu = new DataGridViewTextBoxColumn();
            K2Uriagesu.DataPropertyName = "売上数";
            K2Uriagesu.Name = "売上数";
            K2Uriagesu.HeaderText = "売上数";

            DataGridViewTextBoxColumn K2Hachusu = new DataGridViewTextBoxColumn();
            K2Hachusu.DataPropertyName = "発注数";
            K2Hachusu.Name = "発注数";
            K2Hachusu.HeaderText = "発注数";

            DataGridViewTextBoxColumn K2Tanka = new DataGridViewTextBoxColumn();
            K2Tanka.DataPropertyName = "単価";
            K2Tanka.Name = "単価";
            K2Tanka.HeaderText = "単価";

            DataGridViewTextBoxColumn K2Kingaku = new DataGridViewTextBoxColumn();
            K2Kingaku.DataPropertyName = "金額";
            K2Kingaku.Name = "金額";
            K2Kingaku.HeaderText = "金額";

            DataGridViewTextBoxColumn K2Noki = new DataGridViewTextBoxColumn();
            K2Noki.DataPropertyName = "納期";
            K2Noki.Name = "納期";
            K2Noki.HeaderText = "納期";

            DataGridViewTextBoxColumn K2Code = new DataGridViewTextBoxColumn();
            K2Code.DataPropertyName = "ｺｰﾄﾞ";
            K2Code.Name = "ｺｰﾄﾞ";
            K2Code.HeaderText = "ｺｰﾄﾞ";

            DataGridViewTextBoxColumn K2Shimukesakiname = new DataGridViewTextBoxColumn();
            K2Shimukesakiname.DataPropertyName = "仕向け先名";
            K2Shimukesakiname.Name = "仕向け先名";
            K2Shimukesakiname.HeaderText = "仕向け先名";

            DataGridViewTextBoxColumn K2HachuNo = new DataGridViewTextBoxColumn();
            K2HachuNo.DataPropertyName = "発注番号";
            K2HachuNo.Name = "発注番号";
            K2HachuNo.HeaderText = "発注番号";

            DataGridViewTextBoxColumn K2HachuNo2 = new DataGridViewTextBoxColumn();
            K2HachuNo2.DataPropertyName = "発注番号2";
            K2HachuNo2.Name = "発注番号2";
            K2HachuNo2.HeaderText = "発注番号";

            DataGridViewTextBoxColumn K2ShohinCd = new DataGridViewTextBoxColumn();
            K2ShohinCd.DataPropertyName = "商品コード";
            K2ShohinCd.Name = "商品コード";
            K2ShohinCd.HeaderText = "商品コード";

            DataGridViewTextBoxColumn K2C1 = new DataGridViewTextBoxColumn();
            K2C1.DataPropertyName = "Ｃ１";
            K2C1.Name = "Ｃ１";
            K2C1.HeaderText = "Ｃ１";

            DataGridViewTextBoxColumn K2C2 = new DataGridViewTextBoxColumn();
            K2C2.DataPropertyName = "Ｃ２";
            K2C2.Name = "Ｃ２";
            K2C2.HeaderText = "Ｃ２";

            DataGridViewTextBoxColumn K2C3 = new DataGridViewTextBoxColumn();
            K2C3.DataPropertyName = "Ｃ３";
            K2C3.Name = "Ｃ３";
            K2C3.HeaderText = "Ｃ３";

            DataGridViewTextBoxColumn K2C4 = new DataGridViewTextBoxColumn();
            K2C4.DataPropertyName = "Ｃ４";
            K2C4.Name = "Ｃ４";
            K2C4.HeaderText = "Ｃ４";

            DataGridViewTextBoxColumn K2C5 = new DataGridViewTextBoxColumn();
            K2C5.DataPropertyName = "Ｃ５";
            K2C5.Name = "Ｃ５";
            K2C5.HeaderText = "Ｃ５";

            DataGridViewTextBoxColumn K2C6 = new DataGridViewTextBoxColumn();
            K2C6.DataPropertyName = "Ｃ６";
            K2C6.Name = "Ｃ６";
            K2C6.HeaderText = "Ｃ６";

            DataGridViewTextBoxColumn K2Hakosu = new DataGridViewTextBoxColumn();
            K2Hakosu.DataPropertyName = "箱入数";
            K2Hakosu.Name = "箱入数";
            K2Hakosu.HeaderText = "箱入数";

            DataGridViewTextBoxColumn K2Saishushire = new DataGridViewTextBoxColumn();
            K2Saishushire.DataPropertyName = "最終仕入日";
            K2Saishushire.Name = "最終仕入日";
            K2Saishushire.HeaderText = "最終仕入日";
            
            //個々の幅、文章の寄せ（売上数非表示）
            setColumnKataban2(K2Kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumnKataban2(K2Freezaiko, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 120);
            setColumnKataban2(K2Uriagesu, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnKataban2(K2Shiresu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumnKataban2(K2Hachuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);

            setColumnKataban2(K2Juchuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumnKataban2(K2Hachushi, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumnKataban2(K2Hachusu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 100);
            setColumnKataban2(K2Tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            setColumnKataban2(K2Kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);

            setColumnKataban2(K2Noki, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            setColumnKataban2(K2Code, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            setColumnKataban2(K2Shimukesakiname, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            setColumnKataban2(K2HachuNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            setColumnKataban2(K2HachuNo2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);

            setColumnKataban2(K2ShohinCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban2(K2C1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban2(K2C2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban2(K2C3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban2(K2C4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban2(K2C5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban2(K2C6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 0);
            setColumnKataban2(K2Hakosu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);
            setColumnKataban2(K2Saishushire, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, "#,0", 120);

            //対象列を非表示
            gridKataban2.Columns["売上数"].Visible = false;
            gridKataban2.Columns["商品コード"].Visible = false;
            gridKataban2.Columns["Ｃ１"].Visible = false;
            gridKataban2.Columns["Ｃ２"].Visible = false;
            gridKataban2.Columns["Ｃ３"].Visible = false;
            gridKataban2.Columns["Ｃ４"].Visible = false;
            gridKataban2.Columns["Ｃ５"].Visible = false;
            gridKataban2.Columns["Ｃ６"].Visible = false;
        }

        ///<summary>
        ///setColumnKataban
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumnKataban(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridKataban.Columns.Add(col);
            if (gridKataban.Columns[col.Name] != null)
            {
                gridKataban.Columns[col.Name].Width = intLen;
                gridKataban.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridKataban.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridKataban.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }       
        }

        ///<summary>
        ///setColumnKataban2
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumnKataban2(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridKataban2.Columns.Add(col);
            if (gridKataban2.Columns[col.Name] != null)
            {
                gridKataban2.Columns[col.Name].Width = intLen;
                gridKataban2.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridKataban2.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridKataban2.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///MOnyuryoku_KeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void MOnyuryoku_KeyDown(object sender, KeyEventArgs e)
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
                    this.addMO();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delMO();
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    logger.Info(LogUtil.getMessage(this._Title, "再計算実行"));
                    showKoushin();
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    logger.Info(LogUtil.getMessage(this._Title, "得値実行"));

                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    logger.Info(LogUtil.getMessage(this._Title, "ｴｸｾﾙ取込実行"));

                    break;
                case Keys.F11:
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    printMO();
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
        ///judFuncBtnClick
        ///ファンクションボタンの反応
        ///</summary>
        private void judFuncBtnClick(object sender, EventArgs e)
        {
            //ボタン入力情報によって動作を変える
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addMO();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delMO();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F06: // 再計算
                    logger.Info(LogUtil.getMessage(this._Title, "再計算実行"));
                    this.showKoushin();
                    break;
                case STR_BTN_F08: // 得値
                    logger.Info(LogUtil.getMessage(this._Title, "得値実行"));
                    this.delText();
                    break;
                case STR_BTN_F10: // ｴｸｾﾙ取込
                    logger.Info(LogUtil.getMessage(this._Title, "ｴｸｾﾙ取込実行"));
                    this.delText();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printMO();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///addMO
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addMO()
        {
            int intTheErr;
            DateTime dtYMD;
            object objSijisU;

            decimal decSu = 0;
            decimal decTanka = 0;
            object objNouki = null;
            object objTorihiki = null;
            string strCode = null;

            //データのチェック
            if(blCheckData() == false)
            {
                return;
            }

            int intDenNo = 0;
            string strChuban;
            short shtHasuu;
            string strTantou;
            decimal decKingaku;

            //砂時計表示処理
            //libMessage/waitCursor

            try
            {
                //型番グリッドビューに中身がある場合
                for (int intCnt = 1; intCnt <= gridKataban.Rows.Count; intCnt++)
                {
                    string str = gridKataban.Rows[intCnt].Cells[8].Value.ToString();
                    string str02 = gridKataban.Rows[intCnt].Cells[14].Value.ToString();

                    //単価が空白でないもしくは0、且つ発注番号が空白でない場合
                    if (StringUtl.blIsEmpty(gridKataban.Rows[intCnt].Cells[8].Value.ToString()) == false ||
                        gridKataban.Rows[intCnt].Cells[8].Value.ToString() == "0" &&
                        StringUtl.blIsEmpty(gridKataban.Rows[intCnt].Cells[14].Value.ToString()) == false
                        )
                    {

                    }
                    //発注数が空白でないもしくは0の場合
                    else if (StringUtl.blIsEmpty(gridKataban.Rows[intCnt].Cells[7].Value.ToString()) == false ||
                             gridKataban.Rows[intCnt].Cells[7].Value.ToString() == "0")
                    {
                        //単価が空白でないもしくは0
                        if (StringUtl.blIsEmpty(gridKataban.Rows[intCnt].Cells[8].Value.ToString()) == false ||
                            gridKataban.Rows[intCnt].Cells[8].Value.ToString() == "0")
                        {
                            decSu = 0;
                            decTanka = decimal.Parse(gridKataban.Rows[intCnt].Cells[9].Value.ToString());
                            objNouki = null;
                            objTorihiki = gridKataban.Rows[intCnt].Cells[12].Value;

                            strCode = gridKataban.Rows[intCnt].Cells[16].Value.ToString();
                        }
                        else
                        {
                            decSu = decimal.Parse(gridKataban.Rows[intCnt].Cells[8].Value.ToString());
                            decTanka = decimal.Parse(gridKataban.Rows[intCnt].Cells[9].Value.ToString());
                            objNouki = gridKataban.Rows[intCnt].Cells[11].Value;
                            objTorihiki = gridKataban.Rows[intCnt].Cells[12].Value;

                        }

                        //発注指が空白でないもしくは0
                        if (StringUtl.blIsEmpty(gridKataban.Rows[intCnt].Cells[7].Value.ToString()) == false ||
                            gridKataban.Rows[intCnt].Cells[7].Value.ToString() == "0")
                        {
                            objSijisU = null;
                        }
                        else
                        {
                            objSijisU = gridKataban.Rows[intCnt].Cells[7].Value;
                        }

                        //
                        if (StringUtl.blIsEmpty(gridKataban.Rows[intCnt].Cells[15].Value.ToString()) == false)
                        {
                            //ビジネス層
                            Business.A0020_UriageInput.A0020_UriageInput_B uriageB = new Business.A0020_UriageInput.A0020_UriageInput_B();
                            intDenNo = int.Parse(uriageB.getDenpyoNo("発注番号").ToString());
                        }
                        else
                        {
                            intDenNo = int.Parse(gridKataban.Rows[intCnt].Cells[15].Value.ToString());
                        }

                        Business.B0250_MOnyuryoku.B0250_MOnyuryoku_B monyuB = new B0250_MOnyuryoku_B();
                        intTheErr = monyuB.getExecSProc(txtYM.Text, strCode, objSijisU, decSu, decTanka, objNouki, objTorihiki, intDenNo, SystemInformation.UserName);
                    }
                    else
                    {
                        //単価が空白でないもしくは0
                        if (StringUtl.blIsEmpty(gridKataban.Rows[intCnt].Cells[8].Value.ToString()) == false ||
                            gridKataban.Rows[intCnt].Cells[8].Value.ToString() == "0")
                        {
                            decSu = 0;
                            decTanka = decimal.Parse(gridKataban.Rows[intCnt].Cells[9].Value.ToString());
                            objNouki = null;
                            objTorihiki = gridKataban.Rows[intCnt].Cells[12].Value;

                            strCode = gridKataban.Rows[intCnt].Cells[16].Value.ToString();
                        }
                        else
                        {
                            decSu = decimal.Parse(gridKataban.Rows[intCnt].Cells[8].Value.ToString());
                            decTanka = decimal.Parse(gridKataban.Rows[intCnt].Cells[9].Value.ToString());
                            objNouki = gridKataban.Rows[intCnt].Cells[11].Value;
                            objTorihiki = gridKataban.Rows[intCnt].Cells[12].Value;

                            strCode = gridKataban.Rows[intCnt].Cells[16].Value.ToString();
                        }

                        //発注指が空白でないもしくは0
                        if (StringUtl.blIsEmpty(gridKataban.Rows[intCnt].Cells[7].Value.ToString()) == false ||
                            gridKataban.Rows[intCnt].Cells[7].Value.ToString() == "0")
                        {
                            objSijisU = null;
                        }
                        else
                        {
                            objSijisU = gridKataban.Rows[intCnt].Cells[7].Value;
                        }

                        //
                        if (StringUtl.blIsEmpty(gridKataban.Rows[intCnt].Cells[15].Value.ToString()) == false)
                        {
                            //ビジネス層
                            Business.A0020_UriageInput.A0020_UriageInput_B uriageB = new Business.A0020_UriageInput.A0020_UriageInput_B();
                            intDenNo = int.Parse(uriageB.getDenpyoNo("発注番号").ToString());
                        }
                        else
                        {
                            intDenNo = int.Parse(gridKataban.Rows[intCnt].Cells[15].Value.ToString());
                        }

                        Business.B0250_MOnyuryoku.B0250_MOnyuryoku_B monyuB = new B0250_MOnyuryoku_B();
                        intTheErr = monyuB.getExecSProc(txtYM.Text, strCode, objSijisU, decSu, decTanka, objNouki, objTorihiki, intDenNo, SystemInformation.UserName);
                    }
                }

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                lblSetShohin.CodeTxtText = "";
                txtHasseisu.Text = "";
                txtTanka.Text = "";
                txtNoki.Text = "";
                lblSetShimukesaki.CodeTxtText = "";
                lblSetShimukesaki.ValueLabelText = "";

                lblSetDaibunrui.Focus();

                //上段グリッドビューの行数確保
                int intRow;
                intRow = gridKataban.Rows.Count;

                showGridKataban2();
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
        }

        ///<summary>
        ///setShiresakiEnterKey
        ///仕入先でエンターを押したときの処理
        ///</summary>
        public void setShiresakiEnterKey()
        {
            bool blSet = false;

            //MOデータの作成
            if (!setDataCreate())
            {
                return;
            }

            //下段の表示
            showGridKataban2();

            //if (grdSeihin.rowCount > 0)
            //{
            //    grdSeihin.cellEditFocus(7, 1);
            //}

            return;
        }

        ///<summary>
        ///setDataCreate
        ///MOデータ作成
        ///</summary>
        private bool setDataCreate()
        {
            bool blDataCreate = true;

            //取得したデータの編集を行う用
            DataTable dtView = new DataTable();

            //データ渡し用(データカウント検索用)
            List<string> lstStringKensaku = new List<string>();

            //データ渡し用(ＭＯデータ作成用)
            List<string> lstStringMOdata= new List<string>();

            //データチェック
            if (blCheckData() == false)
            {
                return(blDataCreate);
            }

            //データカウント検索用
            lstStringKensaku.Add(txtYM.Text);
            lstStringKensaku.Add(lblSetMaker.CodeTxtText);
            lstStringKensaku.Add(lblSetDaibunrui.CodeTxtText);
            lstStringKensaku.Add(lblSetChubunrui.CodeTxtText);
            lstStringKensaku.Add(SystemInformation.UserName);

            //ＭＯデータ作成用
            lstStringMOdata.Add(txtZaikoYMD.Text);
            lstStringMOdata.Add(txtYM.Text);
            lstStringMOdata.Add(txtShukeiM.Text);
            lstStringMOdata.Add(lblSetMaker.CodeTxtText);
            lstStringMOdata.Add(lblSetDaibunrui.CodeTxtText);
            lstStringMOdata.Add(lblSetChubunrui.CodeTxtText);
            lstStringMOdata.Add(lblSetShiresaki.CodeTxtText);
            lstStringMOdata.Add(SystemInformation.UserName);
            
            //ビジネス層のインスタンス生成
            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                //検索データを取得
                dtView = monyuryokuB.getDataCnt(lstStringKensaku);

                //チェック結果が0でない場合
                if (dtView.Rows[0][0].ToString() != "0")
                {
                    //goto Err_Proc;

                    //waitCursor(false);

                    return(blDataCreate);
                }
                else
                {
                    //後日作成

                    ////メッセージボックスの処理、MO作成するか否かのウィンドウ(YES,NO)
                    //BaseMessageBox basemessagebox = new BaseMessageBox(this, "ＭＯ入力", "ＭＯデータを作成しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                    ////NOが押された場合
                    //if (basemessagebox.ShowDialog() == DialogResult.No)
                    //{
                    //    txtShukeiM.Focus();
                    //    blDataCreate = false;
                    //    return (blDataCreate);
                    //}
                    ////YESが押された場合
                    //else
                    //{
                    //    //waitCursor(true);

                    //    //MOデータ作成
                    //    monyuryokuB.updMOdata(lstStringMOdata);


                    //}
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return (blDataCreate);
            }

            return (blDataCreate);
        }

        ///<summary>
        ///showGridKataban2
        ///型番グリッド2の表示
        ///</summary>
        private void showGridKataban2()
        {
            //YMD判定
            bool blGood = txtYM.updCalendarLeave(txtYM.Text);

            //グリッドに入れる用のデータテーブル
            DataTable dtGridViewKataban = new DataTable();

            //YMDに変換できる場合
            if (blGood == true)
            {

                List<string> lstStringViewData = new List<string>();
                
                lstStringViewData.Add(txtYM.Text);                  //0
                lstStringViewData.Add(lblSetMaker.CodeTxtText);     //1
                lstStringViewData.Add(lblSetDaibunrui.CodeTxtText); //2
                lstStringViewData.Add(lblSetChubunrui.CodeTxtText); //3

                //マイナスの型番にチェックがある場合
                if (radSet_2btn_PrintCheck.radbtn0.Checked == true)
                {
                    lstStringViewData.Add("Minus");                 //4
                }
                else
                {
                    lstStringViewData.Add("ALL");                   //4
                }

                lstStringViewData.Add(txtShukeiM.Text);             //5
                
                B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
                try
                {
                    dtGridViewKataban = monyuryokuB.setGridKataban2(lstStringViewData);

                    //グリッドビューの表示
                    gridKataban2.DataSource = dtGridViewKataban;

                    //グリッドの色指定
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
            }
        }

        ///<summary>
        ///delText
        ///テキストボックス等の入力情報を白紙にする
        ///</summary>
        private void delText()
        {
            //画面の項目内を白紙にする
            delFormClear(this);
            txtShukeiM.Focus();
        }

        ///<summary>
        ///delMO
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delMO()
        {

        }

        ///<summary>
        ///judtxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtDaibunruiKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///printMO
        ///印刷ダイアログ
        ///</summary>
        private void printMO()
        {

        }

        ///<summary>
        ///blCheckData
        ///データのチェック
        ///</summary>
        private bool blCheckData()
        {
            bool blGood = true;

            //空文字判定(上段入力項目)
            if (txtZaikoYMD.blIsEmpty() == false ||
                txtYM.blIsEmpty() == false ||
                txtShukeiM.blIsEmpty() == false ||
                lblSetDaibunrui.codeTxt.blIsEmpty() == false ||
                lblSetChubunrui.codeTxt.blIsEmpty() == false ||
                lblSetMaker.codeTxt.blIsEmpty() == false ||
                lblSetShiresaki.codeTxt.blIsEmpty() == false ||
                lblSetTantousha.codeTxt.blIsEmpty() == false
                )
            {
                blGood = false;
            }
            return blGood;
        }

        ///<summary>
        ///showKoushin
        ///データ更新
        ///</summary>
        private void showKoushin()
        {
            Control cActiveBefore = this.ActiveControl;

            //一度フォーカスを外してテキスト処理を逃さない
            btnF06.Focus();

            bool blGood = false;

            //下段グリッドのデータがない場合
            if (gridKataban2.Rows.Count < 1)
            {
                //メッセージボックスの処理、データがありません。（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "データがありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                cActiveBefore.Focus();
                return;
            }

//カウントのＳＱＬ発行、ビジネスも修正すること


            //データチェック
            blGood = blCheckData();

            if (blGood == false)
            {
                //メッセージボックスの処理、項目が空です。（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                return;
            }


        }

        ///<summary>
        ///setGridColor
        ///グリッドの色指定
        ///</summary>
        private void setGridColor()
        {
            //グリッド内にデータがある場合
            if (gridKataban2.Rows.Count > 0)
            {
                //グリッドの行数分ループ
                for (int intRowCnt = 0; intRowCnt <= gridKataban2.Rows.Count; intRowCnt++)
                {
                    //単価部分
                    if (gridKataban2.Rows[intRowCnt].Cells[8].ToString() != "0")
                    {
                        //グリッドの列数分ループ
                        for (int intColCnt = 0; intColCnt <= gridKataban2.ColumnCount; intColCnt++)
                        {
                            //文字を赤色
                            gridKataban2[intRowCnt, intColCnt].Style.ForeColor = Color.Red;

                        }
                    }
                }
            }
        }
    }
}
