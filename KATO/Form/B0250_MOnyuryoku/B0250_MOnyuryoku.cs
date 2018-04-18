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
using System.IO;

namespace KATO.Form.B0250_MOnyuryoku
{
    ///<summary>
    ///MOnyuryoku
    ///MO入力フォーム
    ///作成者：大河内
    ///作成日：2017/1/15
    ///更新者：大河内
    ///更新日：2017/1/23
    ///カラム論理名
    ///</summary>
    public partial class B0250_MOnyuryoku : BaseForm
    {
        //ロギングの設定
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //履歴表示用
        DataTable dtRireki = new DataTable();

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
            this.Left = c.Left;
            this.Top = c.Top;

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
            this.btnF02.Text = "F2:確定";
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF06.Text = "F6:再計算";

            //閲覧権限がある場合
            if (("1").Equals(etsuranFlg))
            {
                this.btnF07.Text = "F7:ＣＳＶ";
                this.btnF07.Enabled = true;
            }
            else
            {
                this.btnF07.Enabled = false;
            }

            this.btnF08.Text = "F8:特値";
            this.btnF10.Text = "F10:ｴｸｾﾙ取込";
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            //DataGridViewの初期設定
            SetUpGrid();

            radSet_2btn_PrintCheck.radbtn1.Checked = true;
            txtYM.setUp(3);
            txtZaikoYMD.setUp(0);
            txtHachuYMD.setUp(0);
        }

        ///<summary>
        ///SetUpGrid
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
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
            KHachuNo2.DataPropertyName = "発注番号2";
            KHachuNo2.Name = "発注番号2";
            KHachuNo2.HeaderText = "発注番号2";

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

            DataGridViewTextBoxColumn KHachuTantoshaCd = new DataGridViewTextBoxColumn();
            KHachuTantoshaCd.DataPropertyName = "発注担当者コード";
            KHachuTantoshaCd.Name = "発注担当者コード";
            KHachuTantoshaCd.HeaderText = "発注担当者コード";


            //個々の幅、文章の寄せ
            setColumnKataban(KKataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 330);
            setColumnKataban(KFreezaiko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 90);
            setColumnKataban(KUriagesu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnKataban(KShiresu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnKataban(KHachuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);

            setColumnKataban(KJuchuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnKataban(KHachusu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnKataban(KTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 115);
            setColumnKataban(KKingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 115);

            setColumnKataban(KNoki, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 0);

            setColumnKataban(KCode, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 65);

            setColumnKataban(KShimukesakiname, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#,0", 200);
            setColumnKataban(KHachuNo1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumnKataban(KHachuNo2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);

            setColumnKataban(KShohinCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 0);
            setColumnKataban(KC1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 0);
            setColumnKataban(KC2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 0);
            setColumnKataban(KC3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 0);
            setColumnKataban(KC4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 0);
            setColumnKataban(KC5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 0);
            setColumnKataban(KC6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 0);
            setColumnKataban(KHachuTantoshaCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);

            //対象列を非表示
            gridKataban.Columns["納期"].Visible = false;
            gridKataban.Columns["商品コード"].Visible = false;
            gridKataban.Columns["Ｃ１"].Visible = false;
            gridKataban.Columns["Ｃ２"].Visible = false;
            gridKataban.Columns["Ｃ３"].Visible = false;
            gridKataban.Columns["Ｃ４"].Visible = false;
            gridKataban.Columns["Ｃ５"].Visible = false;
            gridKataban.Columns["Ｃ６"].Visible = false;
            gridKataban.Columns["発注担当者コード"].Visible = false;

            //データをバインド
            DataGridViewTextBoxColumn K2Kataban = new DataGridViewTextBoxColumn();
            K2Kataban.DataPropertyName = "型番";
            K2Kataban.Name = "型番";
            K2Kataban.HeaderText = "型番";

            DataGridViewTextBoxColumn K2Freezaiko = new DataGridViewTextBoxColumn();
            K2Freezaiko.DataPropertyName = "ﾌﾘ在庫";
            K2Freezaiko.Name = "ﾌﾘ在庫";
            K2Freezaiko.HeaderText = "ﾌﾘ-在庫";

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

            DataGridViewTextBoxColumn K2ShimukesakiName = new DataGridViewTextBoxColumn();
            K2ShimukesakiName.DataPropertyName = "仕向け先名";
            K2ShimukesakiName.Name = "仕向け先名";
            K2ShimukesakiName.HeaderText = "仕向け先名";

            DataGridViewTextBoxColumn K2HachuTantoCd = new DataGridViewTextBoxColumn();
            K2HachuTantoCd.DataPropertyName = "発注担当者コード";
            K2HachuTantoCd.Name = "発注担当者コード";
            K2HachuTantoCd.HeaderText = "発注担当者コード";

            DataGridViewTextBoxColumn K2HachuTantoName = new DataGridViewTextBoxColumn();
            K2HachuTantoName.DataPropertyName = "発注担当者";
            K2HachuTantoName.Name = "発注担当者";
            K2HachuTantoName.HeaderText = "発注担当者";

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

            //個々の幅、文章の寄せ
            setColumnKataban2(K2Kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 330);
            setColumnKataban2(K2Freezaiko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 90);
            setColumnKataban2(K2Uriagesu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnKataban2(K2Shiresu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnKataban2(K2Hachuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);

            setColumnKataban2(K2Juchuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnKataban2(K2Hachushi, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnKataban2(K2Hachusu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnKataban2(K2Tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.00", 115);
            setColumnKataban2(K2Kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 115);

            setColumnKataban2(K2Noki, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumnKataban2(K2Code, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 65);
            setColumnKataban2(K2ShimukesakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumnKataban2(K2HachuTantoCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnKataban2(K2HachuTantoName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumnKataban2(K2HachuNo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);

            setColumnKataban2(K2HachuNo2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 0);

            setColumnKataban2(K2ShohinCd, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnKataban2(K2C1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnKataban2(K2C2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnKataban2(K2C3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnKataban2(K2C4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnKataban2(K2C5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnKataban2(K2C6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumnKataban2(K2Hakosu, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "#,0", 100);
            setColumnKataban2(K2Saishushire, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 120);

            //対象列を非表示
            gridKataban2.Columns["商品コード"].Visible = false;
            gridKataban2.Columns["Ｃ１"].Visible = false;
            gridKataban2.Columns["Ｃ２"].Visible = false;
            gridKataban2.Columns["Ｃ３"].Visible = false;
            gridKataban2.Columns["Ｃ４"].Visible = false;
            gridKataban2.Columns["Ｃ５"].Visible = false;
            gridKataban2.Columns["Ｃ６"].Visible = false;
            gridKataban2.Columns["発注番号2"].Visible = false;
            gridKataban2.Columns["発注担当者コード"].Visible = false;

            //データをバインド
            DataGridViewTextBoxColumn RirekiYM = new DataGridViewTextBoxColumn();
            RirekiYM.DataPropertyName = "年月";
            RirekiYM.Name = "年月";
            RirekiYM.HeaderText = "年月";

            DataGridViewTextBoxColumn RirekiUriage = new DataGridViewTextBoxColumn();
            RirekiUriage.DataPropertyName = "売上";
            RirekiUriage.Name = "売上";
            RirekiUriage.HeaderText = "売上";

            DataGridViewTextBoxColumn RirekiShuko = new DataGridViewTextBoxColumn();
            RirekiShuko.DataPropertyName = "出庫";
            RirekiShuko.Name = "出庫";
            RirekiShuko.HeaderText = "出庫";

            DataGridViewTextBoxColumn RirekiShire = new DataGridViewTextBoxColumn();
            RirekiShire.DataPropertyName = "仕入";
            RirekiShire.Name = "仕入";
            RirekiShire.HeaderText = "仕入";

            DataGridViewTextBoxColumn RirekiNyuko = new DataGridViewTextBoxColumn();
            RirekiNyuko.DataPropertyName = "入庫";
            RirekiNyuko.Name = "入庫";
            RirekiNyuko.HeaderText = "入庫";

            DataGridViewTextBoxColumn RirekiHachuzan = new DataGridViewTextBoxColumn();
            RirekiHachuzan.DataPropertyName = "発注残";
            RirekiHachuzan.Name = "発注残";
            RirekiHachuzan.HeaderText = "発注残";

            DataGridViewTextBoxColumn RirekiJuchuzan = new DataGridViewTextBoxColumn();
            RirekiJuchuzan.DataPropertyName = "受注残";
            RirekiJuchuzan.Name = "受注残";
            RirekiJuchuzan.HeaderText = "受注残";

            //個々の幅、文章の寄せ
            setColumnRireki(RirekiYM, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 70);
            setColumnRireki(RirekiUriage, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnRireki(RirekiShuko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnRireki(RirekiShire, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnRireki(RirekiNyuko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnRireki(RirekiHachuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumnRireki(RirekiJuchuzan, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);

        }

        ///<summary>
        ///setColumnKataban
        ///DataGridViewの内部設定（上段）
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
        ///DataGridViewの内部設定（下段）
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
        ///setColumnRireki
        ///DataGridViewの内部設定（履歴）
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
                    logger.Info(LogUtil.getMessage(this._Title, "確定実行"));
                    this.addMOKakutei();
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
                    updSaikesan();
                    break;
                case Keys.F7:
                    // ファンクションボタン制御
                    if (this.btnF07.Enabled)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "ＣＳＶ発行"));
                        saveCSV();
                    }
                    break;
                case Keys.F8:
                    logger.Info(LogUtil.getMessage(this._Title, "特値実行"));
                    showTokune();
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    logger.Info(LogUtil.getMessage(this._Title, "ｴｸｾﾙ取込実行"));
                    setExcelData();
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
        ///MOnyuryokuTxt_KeyDown
        ///キー入力判定（テキストボックス）
        ///</summary>
        private void MOnyuryokuTxt_KeyDown(object sender, KeyEventArgs e)
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
        ///txtKensaku_KeyDown
        ///キー入力判定（検索文字テキストボックス）
        ///</summary>
        private void txtKensaku_KeyDown(object sender, KeyEventArgs e)
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
                    setKensaku();
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
                case STR_BTN_F01: //登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    this.addMO();
                    break;
                case STR_BTN_F02: //確定
                    logger.Info(LogUtil.getMessage(this._Title, "確定実行"));
                    this.addMOKakutei();
                    break;
                case STR_BTN_F03: //削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delMO();
                    break;
                case STR_BTN_F04: //取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F06: //再計算
                    logger.Info(LogUtil.getMessage(this._Title, "再計算実行"));
                    this.updSaikesan();
                    break;
                case STR_BTN_F07: //ＣＳＶ
                    //閲覧権限がある場合
                    if (("1").Equals(this.etsuranFlg))
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "ＣＳＶ発行"));
                        this.saveCSV();
                    }
                    break;
                case STR_BTN_F08: //特値
                    logger.Info(LogUtil.getMessage(this._Title, "特値実行"));
                    this.showTokune();
                    break;
                case STR_BTN_F10: //ｴｸｾﾙ取込
                    logger.Info(LogUtil.getMessage(this._Title, "ｴｸｾﾙ取込実行"));
                    this.setExcelData();
                    break;
                case STR_BTN_F11: //印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printMO();
                    break;
                case STR_BTN_F12: //終了
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
            string strYM = string.Format("yyyy/MM", txtYM); //年月度
            string strSijisU = "";                          //指示数
            decimal decSu = 0;                              //数量
            decimal decTanka = 0;                           //単価
            string strNouki = "";                           //納期
            string strTorihiki = "";                        //取引先コード
            string strCode = "";                            //商品コード
            int intDenNo = 0;                               //伝票番号

            //データのチェック
            //年月度
            if (txtYM.blIsEmpty() == false)
            {
                //記入漏れ発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYM.Focus();
                return;
            }

            //集計月数
            if (txtShukeiM.blIsEmpty() == false)
            {
                //記入漏れ発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtShukeiM.Focus();
                return;
            }

            //大分類
            if (lblSetDaibunrui.CodeTxtText == "")
            {
                //記入漏れ発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n文字を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                lblSetDaibunrui.Focus();
                return;
            }

            ////中分類
            //if (lblSetChubunrui.CodeTxtText == "")
            //{
            //    //記入漏れ発生メッセージ（OK）
            //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
            //    basemessagebox.ShowDialog();

            //    lblSetChubunrui.Focus();
            //    return;
            //}

            //メーカー
            if (lblSetMaker.CodeTxtText == "")
            {
                //記入漏れ発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                lblSetMaker.Focus();
                return;
            }

            //仕入先コード
            if (lblSetShiresaki.CodeTxtText == "")
            {
                return;
            }

            DBConnective dbconnective = new DBConnective();
            try
            {
                //型番グリッドビューに中身がある場合
                for (int intCnt = 0; intCnt < gridKataban2.Rows.Count; intCnt++)
                {
                    //発注数の小数点以下切り捨て
                    string strHachusu = Math.Floor(decimal.Parse(gridKataban2.Rows[intCnt].Cells["発注数"].Value.ToString())).ToString();

                    //発注数が空白もしくは0、且つ発注番号が空白の場合
                    if ((
                            StringUtl.blIsEmpty(strHachusu) == false ||
                            strHachusu == "0"
                        )
                        &&
                        StringUtl.blIsEmpty(gridKataban2.Rows[intCnt].Cells["発注番号"].Value.ToString()) == false
                        )
                    {
                        //何もなし
                    }
                    //発注指が空白もしくは0の場合
                    else if (StringUtl.blIsEmpty(gridKataban2.Rows[intCnt].Cells["発注指"].Value.ToString()) == false ||
                            decimal.Parse(gridKataban2.Rows[intCnt].Cells["発注指"].Value.ToString()) == 0)
                    {
                        //発注数が空白もしくは0の場合
                        if (StringUtl.blIsEmpty(strHachusu) == false ||
                            strHachusu == "0")
                        {
                            decSu = 0;
                            decTanka = Math.Floor(decimal.Parse(gridKataban2.Rows[intCnt].Cells["単価"].Value.ToString()));
                            strNouki = "";
                            strTorihiki = gridKataban2.Rows[intCnt].Cells["ｺｰﾄﾞ"].Value.ToString();
                            strCode = gridKataban2.Rows[intCnt].Cells["商品コード"].Value.ToString();
                        }
                        else
                        {
                            decSu = decimal.Parse(strHachusu);
                            decTanka = Math.Floor(decimal.Parse(gridKataban2.Rows[intCnt].Cells["単価"].Value.ToString()));
                            strNouki = gridKataban2.Rows[intCnt].Cells["納期"].Value.ToString().Substring(0, 10);
                            strTorihiki = gridKataban2.Rows[intCnt].Cells["ｺｰﾄﾞ"].Value.ToString();
                            strCode = gridKataban2.Rows[intCnt].Cells["商品コード"].Value.ToString();
                        }

                        //発注指が空白もしくは0の場合
                        if (StringUtl.blIsEmpty(gridKataban2.Rows[intCnt].Cells["発注指"].Value.ToString()) == false ||
                            decimal.Parse(gridKataban2.Rows[intCnt].Cells["発注指"].Value.ToString()) == 0)
                        {
                            strSijisU = gridKataban2.Rows[intCnt].Cells["発注指"].Value.ToString();
                        }
                        else
                        {
                            strSijisU = "";
                        }

                        //発注番号が空白の場合
                        if (StringUtl.blIsEmpty(gridKataban2.Rows[intCnt].Cells["発注番号2"].Value.ToString()) == false)
                        {
                            //伝票番号テーブルから発注番号を得る
                            Business.A0020_UriageInput.A0020_UriageInput_B uriageB = new Business.A0020_UriageInput.A0020_UriageInput_B();
                            intDenNo = int.Parse(uriageB.getDenpyoNo("発注番号").ToString());
                        }
                        else
                        {
                            intDenNo = int.Parse(gridKataban2.Rows[intCnt].Cells["発注番号2"].Value.ToString());
                        }

                        Business.B0250_MOnyuryoku.B0250_MOnyuryoku_B monyuB = new B0250_MOnyuryoku_B();

                        //戻り値は、エラーかどうか。既にエクセプションで受け取っているため不使用
                        monyuB.updMO(txtYM.Text, strCode, strSijisU, decSu, decTanka, strNouki, strTorihiki, intDenNo, SystemInformation.UserName, gridKataban2.Rows[intCnt].Cells["発注担当者コード"].Value.ToString());
                    }
                    else
                    {
                        //単価が空白もしくは0
                        if (StringUtl.blIsEmpty(gridKataban2.Rows[intCnt].Cells["単価"].Value.ToString()) == false ||
                            gridKataban2.Rows[intCnt].Cells["単価"].Value.ToString() == "0")
                        {
                            decSu = 0;
                            decTanka = decimal.Parse(gridKataban2.Rows[intCnt].Cells["単価"].Value.ToString());
                            strNouki = "";
                            strTorihiki = gridKataban2.Rows[intCnt].Cells["ｺｰﾄﾞ"].Value.ToString();

                            strCode = gridKataban2.Rows[intCnt].Cells["商品コード"].Value.ToString();
                        }
                        else
                        {
                            decSu = decimal.Parse(strHachusu);
                            decTanka = decimal.Parse(gridKataban2.Rows[intCnt].Cells["単価"].Value.ToString());
                            strNouki = gridKataban2.Rows[intCnt].Cells["納期"].Value.ToString().Substring(0, 10);
                            strTorihiki = gridKataban2.Rows[intCnt].Cells["ｺｰﾄﾞ"].Value.ToString();

                            strCode = gridKataban2.Rows[intCnt].Cells["商品コード"].Value.ToString();
                        }

                        //発注指が空白もしくは0
                        if (StringUtl.blIsEmpty(gridKataban2.Rows[intCnt].Cells["発注指"].Value.ToString()) == false ||
                            decimal.Parse(gridKataban2.Rows[intCnt].Cells["発注指"].Value.ToString()) == 0)
                        {
                            strSijisU = "";
                        }
                        else
                        {
                            strSijisU = gridKataban2.Rows[intCnt].Cells["発注指"].Value.ToString();
                        }

                        //発注番号が空の場合
                        if (StringUtl.blIsEmpty(gridKataban2.Rows[intCnt].Cells["発注番号2"].Value.ToString()) == false)
                        {
                            //伝票番号テーブルから発注番号を得る
                            Business.A0020_UriageInput.A0020_UriageInput_B uriageB = new Business.A0020_UriageInput.A0020_UriageInput_B();
                            intDenNo = int.Parse(uriageB.getDenpyoNo("発注番号").ToString());
                        }
                        else
                        {
                            intDenNo = int.Parse(gridKataban2.Rows[intCnt].Cells["発注番号2"].Value.ToString());
                        }

                        Business.B0250_MOnyuryoku.B0250_MOnyuryoku_B monyuB = new B0250_MOnyuryoku_B();

                        //戻り値は、エラーかどうか。既にエクセプションで受け取っているため不使用
                        monyuB.updMO(txtYM.Text, strCode, strSijisU, decSu, decTanka, strNouki, strTorihiki, intDenNo, SystemInformation.UserName, gridKataban2.Rows[intCnt].Cells["発注担当者コード"].Value.ToString());
                    }
                }

                //メッセージボックスの処理、登録完了のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //下段入力項目の白紙
                txtShohinCd.Clear();
                txtHachusu.Clear();
                txtTanka.Clear();
                txtNoki.Clear();
                lblSetShimukesaki.codeTxt.Clear();
                lblSetShimukesaki.ValueLabelText = "";

                //初期フォーカス位置に移動
                lblSetDaibunrui.Focus();

                //グリッドの初期化
                gridKataban.DataSource = "";
                gridKataban2.DataSource = "";

                //中段グリッドの表示
                showGridKataban2();

                //上段グリッドの表示
                showGridKataban1();
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
        ///addMOKakutei
        ///画面データの確定機能
        ///</summary>
        private void addMOKakutei()
        {
            string strShiresakiCd;  //仕入先コード
            string strHachuYMD;     //発注年月日
            decimal decSu;
            decimal decTanka;
            decimal decKin = 0;
            string strNouki;
            string strShohinCd;

            string strC1;
            string strC2;
            string strC3;
            string strC4;
            string strC5;
            string strC6;

            decimal decHasu;
            string strChuban;
            string strHachuTanto;
            int intDenNo;
            string strShimuke;

            //明細行円以下計算区分データの確保用
            DataTable dtMesaikbn = new DataTable();

            //発注更新をするデータ
            List<string> lstStringHachukoshin = new List<string>();

            //ＭＯ確定をするデータ
            List<string> lstStringMOkakutei = new List<string>();

            //上段グリッドの存在確認
            if (gridKataban.Rows.Count <= 0)
            {
                return;
            }

            //上段入力項目チェック
            if (chkTxtData() == false)
            {
                return;
            }

            //メッセージボックスの処理、ＭＯ入力確定するか否かのウィンドウ(YES,NO)
            BaseMessageBox basemessagebox = new BaseMessageBox(this, "ＭＯ入力確定", "ＭＯ入力データを確定しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
            //NOが押された場合
            if (basemessagebox.ShowDialog() == DialogResult.No)
            {
                return;
            }

            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                //上段グリッドのループ
                for (int intCnt = 0; intCnt < gridKataban.Rows.Count; intCnt++)
                {
                    //商品コードの取得
                    strShohinCd = gridKataban.Rows[intCnt].Cells["商品コード"].Value.ToString();

                    //発注数が空もしくは
                    if (StringUtl.blIsEmpty(gridKataban.Rows[intCnt].Cells["発注数"].Value.ToString()) == false ||
                        Math.Floor(double.Parse(gridKataban.Rows[intCnt].Cells["発注数"].Value.ToString())) == 0)
                    {
                        //スルー
                    }
                    else
                    {
                        //発注更新をするデータを初期化
                        lstStringHachukoshin.Clear();

                        //ＭＯ確定をするデータを初期化
                        lstStringMOkakutei.Clear();

                        //仕入先コード
                        strShiresakiCd = lblSetShiresaki.CodeTxtText;

                        //発注年月日
                        strHachuYMD = txtHachuYMD.Text;

                        //発注番号2の取得
                        intDenNo = int.Parse(gridKataban.Rows[intCnt].Cells["発注番号2"].Value.ToString());

                        //発注担当者コード
                        strHachuTanto = gridKataban.Rows[intCnt].Cells["発注担当者コード"].Value.ToString();

                        //発注数
                        decSu = decimal.Parse(gridKataban.Rows[intCnt].Cells["発注数"].Value.ToString());
                        //発注数が空の場合
                        if (StringUtl.blIsEmpty(decSu.ToString()) == false)
                        {
                            decSu = 0;
                        }

                        //単価
                        decTanka = decimal.Parse(gridKataban.Rows[intCnt].Cells["単価"].Value.ToString());
                        //発注数が空の場合
                        if (StringUtl.blIsEmpty(decTanka.ToString()) == false)
                        {
                            decTanka = 0;
                        }

                        //納期
                        strNouki = gridKataban.Rows[intCnt].Cells["納期"].Value.ToString();

                        //Ｃ１
                        strC1 = gridKataban.Rows[intCnt].Cells["Ｃ１"].Value.ToString();
                        //Ｃ２
                        strC2 = gridKataban.Rows[intCnt].Cells["Ｃ２"].Value.ToString();
                        //Ｃ３
                        strC3 = gridKataban.Rows[intCnt].Cells["Ｃ３"].Value.ToString();
                        //Ｃ４
                        strC4 = gridKataban.Rows[intCnt].Cells["Ｃ４"].Value.ToString();
                        //Ｃ５
                        strC5 = gridKataban.Rows[intCnt].Cells["Ｃ５"].Value.ToString();
                        //Ｃ６
                        strC6 = gridKataban.Rows[intCnt].Cells["Ｃ６"].Value.ToString();

                        //仕向け先
                        strShimuke = gridKataban.Rows[intCnt].Cells["仕向け先名"].Value.ToString();

                        //注番
                        strChuban = "MO" + DateTime.Parse(txtYM.Text).ToString("yyyyMM") + " " + strShimuke;
                        dtMesaikbn = monyuryokuB.getTorihikiHasu(lblSetShiresaki.CodeTxtText);

                        //データがある場合
                        if (dtMesaikbn.Rows.Count > 0)
                        {
                            //端数
                            decHasu = decimal.Parse(dtMesaikbn.Rows[0][0].ToString());

                            if (decHasu == 2)
                            {
                                //金額(切り上げ)
                                decKin = decimal.Parse(StringUtl.updKiriage((decSu * decTanka).ToString()));
                            }
                            else if (decHasu == 0)
                            {
                                //金額(切り捨て)
                                decKin = decimal.Parse(StringUtl.updKirisute((decSu * decTanka).ToString()));
                            }
                            else
                            {
                                //金額(四捨五入)
                                decKin = decimal.Parse(StringUtl.updShishagonyu((decSu * decTanka).ToString(), 0));
                            }
                        }

                        //発注更新処理をするデータを入れる
                        lstStringHachukoshin.Add(strShiresakiCd);                   //仕入先コード
                        lstStringHachukoshin.Add(strHachuYMD);                      //発注年月日
                        lstStringHachukoshin.Add(intDenNo.ToString());              //発注番号
                        lstStringHachukoshin.Add(strHachuTanto);                    //発注者コード
                        lstStringHachukoshin.Add("0001");                           //営業所コード
                        lstStringHachukoshin.Add(strHachuTanto);                    //担当者コード
                        lstStringHachukoshin.Add("0");                              //受注番号
                        lstStringHachukoshin.Add("0");                              //出庫番号
                        lstStringHachukoshin.Add("0");                              //行番号
                        lstStringHachukoshin.Add(strShohinCd);                      //商品コード
                        lstStringHachukoshin.Add(lblSetMaker.CodeTxtText);          //メーカーコード
                        lstStringHachukoshin.Add(lblSetDaibunrui.CodeTxtText);      //大分類コード
                        lstStringHachukoshin.Add(lblSetChubunrui.CodeTxtText);      //中分類コード
                        lstStringHachukoshin.Add(strC1);                            //Ｃ１
                        lstStringHachukoshin.Add(strC2);                            //Ｃ２
                        lstStringHachukoshin.Add(strC3);                            //Ｃ３
                        lstStringHachukoshin.Add(strC4);                            //Ｃ４
                        lstStringHachukoshin.Add(strC5);                            //Ｃ５
                        lstStringHachukoshin.Add(strC6);                            //Ｃ６
                        lstStringHachukoshin.Add(decSu.ToString());                 //発注数量
                        lstStringHachukoshin.Add(decTanka.ToString());              //発注単価
                        lstStringHachukoshin.Add(decKin.ToString());                //発注金額
                        lstStringHachukoshin.Add(strNouki);                         //納期
                        lstStringHachukoshin.Add("0");                              //発注フラグ
                        lstStringHachukoshin.Add(strChuban);                        //注番
                        lstStringHachukoshin.Add("0");                              //加工区分
                        lstStringHachukoshin.Add(lblSetShiresaki.ValueLabelText);   //仕入先名称
                        lstStringHachukoshin.Add(SystemInformation.UserName);       //ユーザー名

                        //発注更新処理
                        monyuryokuB.updHachukoshin(lstStringHachukoshin);

                    }
                }

                //中段グリッドのループ
                for (int intCnt = 0; intCnt < gridKataban2.Rows.Count; intCnt++)
                {
                    lstStringMOkakutei.Clear();

                    //ＭＯ確定処理をするデータを入れる
                    lstStringMOkakutei.Add(DateTime.Parse(txtYM.Text).ToString("yyyy/MM"));                  //年月度
                    lstStringMOkakutei.Add(gridKataban2.Rows[intCnt].Cells["商品コード"].Value.ToString());  //商品コード                                   //商品コード
                    lstStringMOkakutei.Add(SystemInformation.UserName);                                      //ユーザー名

                    //ＭＯデータ確定処理
                    monyuryokuB.updMOdataKakutei(lstStringMOkakutei);
                }

                //取り消しの挙動
                delText();
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        ///<summary>
        ///lblSetShiresaki_Validated
        ///上段仕入先コードから離れた時
        ///</summary>
        private void lblSetShiresaki_Validated(object sender, EventArgs e)
        {
            //年月度
            if (txtYM.blIsEmpty() == false)
            {
                //記入漏れ発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYM.Focus();
                return;
            }

            //集計月数
            if (txtShukeiM.blIsEmpty() == false)
            {
                //記入漏れ発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtShukeiM.Focus();
                return;
            }

            //大分類
            if (lblSetDaibunrui.CodeTxtText == "")
            {
                //記入漏れ発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n文字を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                lblSetDaibunrui.Focus();
                return;
            }

            ////中分類
            //if (lblSetChubunrui.CodeTxtText == "")
            //{
            //    //記入漏れ発生メッセージ（OK）
            //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
            //    basemessagebox.ShowDialog();

            //    lblSetChubunrui.Focus();
            //    return;
            //}

            //メーカー
            if (lblSetMaker.CodeTxtText == "")
            {
                //記入漏れ発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                lblSetMaker.Focus();
                return;
            }

            //仕入先コード
            if (lblSetShiresaki.CodeTxtText == "")
            {
                return;
            }

            //ＭＯ作成、中段グリッド表示を押したときの処理
            setShiresakiEnterKey();
        }


        ///<summary>
        ///setShiresakiEnterKey
        ///ＭＯ作成、中段グリッド表示を押したときの処理
        ///</summary>
        public void setShiresakiEnterKey()
        {
            //データのカウント処理
            if (chkDataCount() == true)
            {
                //ＭＯデータ商品マスタチェック_PROCの実行
                updMOMasterCheck();
            }
            else
            {

                //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
                BaseMessageBox basemessageboxMo = new BaseMessageBox(this, "ＭＯ入力", "ＭＯデータを作成しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessageboxMo.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                //メッセージボックスを閉じる
                basemessageboxMo.Close();

                //年月度
                if (txtYM.blIsEmpty() == false)
                {
                    //記入漏れ発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtYM.Focus();
                    return;
                }

                //集計月数
                if (txtShukeiM.blIsEmpty() == false)
                {
                    //記入漏れ発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtShukeiM.Focus();
                    return;
                }

                //大分類
                if (lblSetDaibunrui.CodeTxtText == "")
                {
                    //記入漏れ発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n文字を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    lblSetDaibunrui.Focus();
                    return;
                }

                ////中分類
                //if (lblSetChubunrui.CodeTxtText == "")
                //{
                //    //記入漏れ発生メッセージ（OK）
                //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                //    basemessagebox.ShowDialog();

                //    lblSetChubunrui.Focus();
                //    return;
                //}

                //メーカー
                if (lblSetMaker.CodeTxtText == "")
                {
                    //記入漏れ発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    lblSetMaker.Focus();
                    return;
                }

                //仕入先コード
                if (lblSetShiresaki.CodeTxtText == "")
                {
                    return;
                }

                //待機状態
                Cursor.Current = Cursors.WaitCursor;

                //ＭＯデータ作成_PROCの実行
                insertMOdata();

                //元に戻す
                Cursor.Current = Cursors.Default;
            }

            //グリッドの初期化
            gridKataban.DataSource = "";
            gridKataban2.DataSource = "";
            gridRireki.DataSource = "";

            //中段グリッドの表示
            if (!showGridKataban2())
            {
                return;
            }

            //上段グリッドの表示
            showGridKataban1();

            //履歴情報確保
            getRIrekiData();

            return;
        }

        ///<summary>
        ///chkDataCount
        ///データカウント検索
        ///引数　：なし
        ///戻り値：データがある【true】
        ///</summary>
        private bool chkDataCount()
        {
            Boolean blDataCountTrue = true;

            //取得したデータの編集を行う用
            DataTable dtView = new DataTable();

            //データ渡し用(データカウント検索、ＭＯデータ作成兼用)
            List<string> lstString = new List<string>();

            //データカウント検索、ＭＯデータ商品マスタチェック_PROCの兼用
            lstString.Add(txtYM.Text);                    //年月度
            lstString.Add(lblSetMaker.CodeTxtText);       //メーカーコード
            lstString.Add(lblSetDaibunrui.CodeTxtText);   //大分類コード
            lstString.Add(lblSetChubunrui.CodeTxtText);   //中分類コード

            //ビジネス層のインスタンス生成
            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                //検索データを取得
                dtView = monyuryokuB.getDataCount(lstString);

                //チェック結果が0の場合
                if (dtView.Rows[0][0].ToString() == "0")
                {
                    blDataCountTrue = false;
                }
                else
                {
                    blDataCountTrue = true;
                }
            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return (blDataCountTrue);
            }
            return (blDataCountTrue);
        }

        ///<summary>
        ///updMOMasterCheck
        ///ＭＯデータ商品マスタチェック_PROCの実行
        ///引数　：なし
        ///戻り値：なし
        ///</summary>
        private void updMOMasterCheck()
        {
            //データ渡し用(ＭＯデータ作成兼用)
            List<string> lstString = new List<string>();

            lstString.Add(txtYM.Text);                    //年月度
            lstString.Add(lblSetMaker.CodeTxtText);       //メーカーコード
            lstString.Add(lblSetDaibunrui.CodeTxtText);   //大分類コード
            lstString.Add(lblSetChubunrui.CodeTxtText);   //中分類コード
            lstString.Add(SystemInformation.UserName);    //ユーザー名

            //ビジネス層のインスタンス生成
            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                //ＭＯデータ商品マスタチェック_PROCを実行
                monyuryokuB.updMOMasterCheck(lstString);
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
            return;
        }

        ///<summary>
        ///insertMOdata
        ///ＭＯデータ作成_PROC
        ///引数　：なし
        ///戻り値：なし
        ///</summary>
        private void insertMOdata()
        {
            List<string> lstStringMOdata = new List<string>();

            lstStringMOdata.Add(txtZaikoYMD.Text);            //在庫年月日
            lstStringMOdata.Add(txtYM.Text);                  //年月度
            lstStringMOdata.Add(txtShukeiM.Text);             //集計月数
            lstStringMOdata.Add(lblSetMaker.CodeTxtText);     //メーカーコード
            lstStringMOdata.Add(lblSetDaibunrui.CodeTxtText); //大分類コード
            lstStringMOdata.Add(lblSetChubunrui.CodeTxtText); //中分類コード
            lstStringMOdata.Add(lblSetShiresaki.CodeTxtText); //仕入先コード
            lstStringMOdata.Add(SystemInformation.UserName);  //ユーザー名

            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                monyuryokuB.updMOdata(lstStringMOdata);
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
        }

        ///<summary>
        ///showGridKataban2
        ///型番グリッド2の表示
        ///</summary>
        private bool showGridKataban2()
        {
            //表示できたかどうか
            bool blGrid2VIew = false;

            //YMD判定
            bool blGood = txtYM.updCalendarLeave(txtYM.Text);

            //グリッドに入れる用のデータテーブル
            DataTable dtGridViewKataban = new DataTable();

            //YMDに変換できる場合
            if (blGood == true)
            {

                List<string> lstStringViewData = new List<string>();

                lstStringViewData.Add(txtYM.Text);                  //年月度
                lstStringViewData.Add(lblSetMaker.CodeTxtText);     //メーカーコード
                lstStringViewData.Add(lblSetDaibunrui.CodeTxtText); //大分類コード
                lstStringViewData.Add(lblSetChubunrui.CodeTxtText); //中分類コード

                //マイナスの型番にチェックがある場合
                if (radSet_2btn_PrintCheck.radbtn0.Checked == true)
                {
                    lstStringViewData.Add("Minus");                 //マイナス判定
                }
                else
                {
                    lstStringViewData.Add("ALL");                   //ALL判定
                }

                lstStringViewData.Add(txtShukeiM.Text);             //集計月数

                B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
                try
                {
                    dtGridViewKataban = monyuryokuB.setGridKataban2(lstStringViewData);

                    //テーブルがある場合
                    if (dtGridViewKataban.Rows.Count > 0)
                    {
                        //グリッドビューの表示
                        gridKataban2.DataSource = dtGridViewKataban;

                        //グリッドの文字色指定
                        setGridColor();

                        //表示成功
                        blGrid2VIew = true;
                    }
                    else
                    {
                        //例外発生メッセージ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, "ＭＯ入力", "全て確定されています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        //グリッド部分のみ初期化
                        gridKataban.DataSource = "";
                        gridKataban2.DataSource = "";
                        gridRireki.DataSource = "";
                    }
                }
                catch (Exception ex)
                {
                    //データロギング
                    new CommonException(ex);
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return (blGrid2VIew);
                }
            }
            return (blGrid2VIew);
        }

        ///<summary>
        ///showGridKataban1
        ///型番グリッド1の表示
        ///</summary>
        private void showGridKataban1()
        {
            DataTable dtGridViewKataban = new DataTable();

            List<string> lstStringViewData = new List<string>();

            lstStringViewData.Add(txtYM.Text);                  //年月度
            lstStringViewData.Add(lblSetMaker.CodeTxtText);     //メーカーコード
            lstStringViewData.Add(lblSetDaibunrui.CodeTxtText); //大分類コード
            lstStringViewData.Add(lblSetChubunrui.CodeTxtText); //中分類コード

            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                dtGridViewKataban = monyuryokuB.setGridKataban1(lstStringViewData);

                //テーブルがある場合
                if (dtGridViewKataban.Rows.Count > 0)
                {
                    //グリッドビューの表示
                    gridKataban.DataSource = dtGridViewKataban;
                }
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
        ///delText
        ///テキストボックス等の入力情報を白紙にする
        ///</summary>
        private void delText()
        {
            //年月度確保
            string strYM = txtYM.Text;

            //表示テキスト、ラジオボタン部分
            txtShukeiM.Clear();
            lblSetDaibunrui.codeTxt.Clear();
            lblSetDaibunrui.chkTxtDaibunrui();
            lblSetChubunrui.codeTxt.Clear();
            lblSetChubunrui.chkTxtChubunrui("");
            lblSetMaker.codeTxt.Clear();
            lblSetMaker.chkTxtMaker();
            lblSetShiresaki.codeTxt.Clear();
            lblSetShiresaki.chkTxtTorihikisaki();
            txtKensaku.Clear();
            txtHachusu.Clear();
            txtTanka.Clear();
            txtNoki.Clear();
            lblSetShimukesaki.codeTxt.Clear();
            lblSetShimukesaki.chkTxtTorihikisaki();
            txtZaikoYMD.setUp(0);
            txtHachuYMD.setUp(0);
            radSet_2btn_PrintCheck.radbtn1.Checked = true;

            //グリッド部分
            gridKataban.DataSource = "";
            gridKataban2.DataSource = "";
            gridRireki.DataSource = "";

            //非表示部分
            txtKingaku.Clear();
            txtShohinCd.Clear();

            //年月度を戻す
            txtYM.Text = strYM;

            //集計月数にフォーカス
            txtShukeiM.Focus();
        }

        ///<summary>
        ///delMO
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delMO()
        {
            //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "表示中のMOデータを削除します。" + Environment.NewLine + "よろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
            //NOが押された場合
            if (basemessagebox.ShowDialog() == DialogResult.No)
            {
                return;
            }

            //中段グリッドにデータがない場合
            if (gridKataban2.RowCount == 0)
            {
                //データがないの発生メッセージ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;

            }

            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                //中段グリッド内のループ
                for (int intCnt = 0; intCnt < gridKataban2.Rows.Count; intCnt++)
                {
                    monyuryokuB.delMO(txtYM.Text, gridKataban2.Rows[intCnt].Cells["商品コード"].Value.ToString());
                }

                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                //テキストボックスを白紙にする
                delText();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        ///<summary>
        ///judtxtMOKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///</summary>
        private void judtxtMOKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }

        ///<summary>
        ///showTokune
        ///特定向け先単価リストの表示
        ///</summary>
        private void showTokune()
        {
            //予め宣言する
            TokuteimukesakiTankaList tokumukesakitankalist;

            //kataban2グリッド内にデータがない場合
            if (gridKataban2.Rows.Count < 1)
            {
                //特定向け先単価リストのインスタンス生成
                tokumukesakitankalist = new TokuteimukesakiTankaList(this,
                                                                    "",
                                                                    ""
                                                                    );
            }
            else
            {
                //特定向け先単価リストのインスタンス生成
                tokumukesakitankalist = new TokuteimukesakiTankaList(this,
                                                                    (String)gridKataban2.CurrentRow.Cells["型番"].Value,
                                                                    (String)gridKataban2.CurrentRow.Cells["商品コード"].Value
                                                                    );

            }

            try
            {
                //特定向け先単価リストのテキストと連携させる
                tokumukesakitankalist.btxtShohinCd = txtShohinCd;
                tokumukesakitankalist.lsShimuke = lblSetShimukesaki;
                tokumukesakitankalist.btmTanka = txtTanka;

                //サブディスプレイに表示する処理
                Screen s = null;
                Screen[] argScreen = Screen.AllScreens;
                if (argScreen.Length > 1)
                {
                    s = argScreen[1];
                }
                else
                {
                    s = argScreen[0];
                }

                tokumukesakitankalist.StartPosition = FormStartPosition.Manual;
                tokumukesakitankalist.Location = s.Bounds.Location;

                tokumukesakitankalist.ShowDialog();

                //集計月数にフォーカス移動
                txtShukeiM.Focus();

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
        ///updSaikesan
        ///再計算
        ///</summary>
        private void updSaikesan()
        {
            Control cActiveBefore = this.ActiveControl;

            List<string> lstString = new List<string>();

            //下段グリッドのデータがない場合
            if (gridKataban2.Rows.Count < 1)
            {
                //メッセージボックスの処理、データがありません。（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "データがありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                return;
            }

            //上段入力項目チェック
            if (chkTxtData() == false)
            {
                return;
            }

            //メッセージボックスの処理、再計算するか否かのウィンドウ(YES,NO)
            BaseMessageBox basemessageboxSai = new BaseMessageBox(this, "ＭＯ再計算", "ＭＯデータの再計算をしますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
            //NOが押された場合
            if (basemessageboxSai.ShowDialog() == DialogResult.No)
            {
                return;
            }

            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                lstString.Add(txtZaikoYMD.Text);            //在庫年月日
                lstString.Add(txtYM.Text);                  //年月度
                lstString.Add(txtShukeiM.Text);             //集計月数
                lstString.Add(lblSetMaker.CodeTxtText);     //メーカーコード
                lstString.Add(lblSetDaibunrui.CodeTxtText); //大分類コード
                lstString.Add(lblSetChubunrui.CodeTxtText); //中分類コード
                lstString.Add(lblSetShiresaki.CodeTxtText); //仕入先コード
                lstString.Add(SystemInformation.UserName);  //ユーザー名


                //データの数量確認とＭＯデータ初期更新_PROCの実行
                monyuryokuB.setMOshoki(lstString);

                //中段グリッド表示
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
        ///setGridColor
        ///グリッドの文字色指定
        ///</summary>
        private void setGridColor()
        {
            //グリッド内にデータがある場合
            if (gridKataban2.Rows.Count > 0)
            {
                //グリッドの行数分ループ
                for (int intRowCnt = 0; intRowCnt < gridKataban2.Rows.Count; intRowCnt++)
                {
                    //発注数が0以外の場合
                    if (Math.Floor(double.Parse(gridKataban2.Rows[intRowCnt].Cells["発注数"].Value.ToString())) != 0)
                    {
                        //文字を赤色
                        gridKataban2.Rows[intRowCnt].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        ///<summary>
        ///getRIrekiData
        ///履歴情報の確保
        ///</summary>
        private void getRIrekiData()
        {
            //仕入先ラベルセットが空の場合
            if (lblSetShiresaki.CodeTxtText == "")
            {
                return;
            }

            List<string> lstString = new List<string>();

            //開始年月日（初期値）
            DateTime dateOpenYMD = DateTime.Parse("2000/01/01");
            //終了年月日（初期値）
            DateTime dateEndYMD = DateTime.Parse("2000/01/01");

            //txtYMをdatetime型に変換できるか（終了年月日の確保も兼ねる）
            if (DateTime.TryParse(txtYM.Text + "/01", out dateEndYMD))
            {
                //開始年月日の確保
                dateOpenYMD = dateEndYMD;

                //その月の最終日を求める
                dateEndYMD = dateEndYMD.AddMonths(1);
                dateEndYMD = dateEndYMD.AddDays(-1);

                //開始年月日の確保
                dateOpenYMD = dateOpenYMD.AddMonths(-int.Parse(txtShukeiM.Text));
            }
            else
            {
                return;
            }

            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                lstString.Add((dateOpenYMD.Year + "/" + dateOpenYMD.Month + "/" + dateOpenYMD.Day).ToString());
                lstString.Add((dateEndYMD.Year + "/" + dateEndYMD.Month + "/" + dateEndYMD.Day).ToString());
                lstString.Add(DateTime.Now.ToString());
                lstString.Add(SystemInformation.UserName);

                //履歴データの削除と保存
                monyuryokuB.setRirekiData(lstString);
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
        ///gridKataban2_SelectionChanged
        ///下段のデータのどこかが選択された時
        ///</summary>
        private void gridKataban2_SelectionChanged(object sender, EventArgs e)
        {
            //下入力項目の初期化
            txtHachusu.Clear();
            txtTanka.Clear();
            txtKingaku.Clear();
            txtNoki.Clear();
            lblSetShimukesaki.CodeTxtText = "";
            lblSetShimukesaki.ValueLabelText = "";
            lblSetHachuTantousha.CodeTxtText = "";
            lblSetHachuTantousha.ValueLabelText = "";

            //データがない場合
            if (gridKataban2.Rows.Count <= 1)
            {
                return;
            }

            //履歴datatableの初期化（カラム残し）
            dtRireki.Clear();

            //カラムを残してデータのみを消す
            gridRireki.DataSource = dtRireki;

            //選択行が空の場合
            if (gridKataban2.CurrentRow.Index == 0)
            {
                return;
            }

            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                //履歴データの取得(商品コードを渡す)
                dtRireki = monyuryokuB.getRirekiData((String)gridKataban2.CurrentRow.Cells["商品コード"].Value);

                //履歴データにある場合
                if (dtRireki.Rows.Count > 0)
                {
                    gridRireki.DataSource = dtRireki;
                }
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
        ///gridKataban2_CellDoubleClick
        ///中段データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void gridKataban2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setNyuryokuData();
        }

        ///<summary>
        ///gridKataban2_KeyDown
        ///中段データグリッドビュー内でキーを押したとき(KeyDown)
        ///</summary>
        private void gridKataban2_KeyDown(object sender, KeyEventArgs e)
        {
            //エンターキーが押されたか調べる
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                setNyuryokuData();
            }
        }

        ///<summary>
        ///setNyuryokuData
        ///入力項目に記載
        ///</summary>
        private void setNyuryokuData()
        {
            //納期入力項目に月末処理をするのに使う
            DateTime dateYMD;
            string strMonth;

            //中段にデータがない場合
            if (gridKataban2.Rows.Count <= 0)
            {
                return;
            }

            //選択行の発注数取得
            if (Math.Floor(double.Parse(gridKataban2.CurrentRow.Cells["発注数"].Value.ToString())) == 0)
            {
                txtHachusu.Text = "";
            }
            else
            {
                txtHachusu.Text = decimal.Parse(gridKataban2.CurrentRow.Cells["発注数"].Value.ToString()).ToString();
            }

            //選択行の単価取得
            txtTanka.Text = decimal.Parse(gridKataban2.CurrentRow.Cells["単価"].Value.ToString()).ToString();
            txtTanka.setMoneyData(txtTanka.Text, 2);

            //選択行の金額選択
            txtKingaku.Text = decimal.Parse(gridKataban2.CurrentRow.Cells["金額"].Value.ToString()).ToString();
            txtKingaku.setMoneyData(txtKingaku.Text, 2);

            //選択行の納期取得
            if (gridKataban2.CurrentRow.Cells["納期"].Value.ToString() == "")
            {
                dateYMD = DateTime.Parse(txtYM.Text);

                //月が一桁の場合
                if (dateYMD.Month.ToString().Length == 1)
                {
                    strMonth = "0" + dateYMD.Month.ToString();
                }
                else
                {
                    strMonth = dateYMD.Month.ToString();
                }

                //納期
                txtNoki.Text = dateYMD.Year.ToString() + " " + strMonth + " " + DateTime.DaysInMonth(dateYMD.Year, dateYMD.Month);

            }
            else
            {
                txtNoki.Text = gridKataban2.CurrentRow.Cells["納期"].Value.ToString();
            }

            //仕向け先コードが「....」の場合
            if ((string)gridKataban2.CurrentRow.Cells["ｺｰﾄﾞ"].Value.ToString() == "....")
            {
                //空白を追加
                lblSetShimukesaki.CodeTxtText = "";
                lblSetShimukesaki.ValueLabelText = "";
            }
            else
            {
                //選択行の仕向先取得
                lblSetShimukesaki.CodeTxtText = (string)gridKataban2.CurrentRow.Cells["ｺｰﾄﾞ"].Value.ToString();
                lblSetShimukesaki.ValueLabelText = (string)gridKataban2.CurrentRow.Cells["仕向け先名"].Value.ToString();
            }

            //選択行の商品コード取得
            txtShohinCd.Text = (string)gridKataban2.CurrentRow.Cells["商品コード"].Value.ToString();

            //選択行の担当者取得
            lblSetHachuTantousha.CodeTxtText = (string)gridKataban2.CurrentRow.Cells["発注担当者コード"].Value.ToString();
            //共通部品修正後に

            //納期が記入された場合
            if (txtNoki.Text != "")
            {
                //その月の月末を確保
                txtNoki.setUp(2);
            }

            //発注数テキストボックスにフォーカス
            txtHachusu.Focus();
        }

        ///<summary>
        ///txtKensaku_Leave
        ///中段グリッド内検索（型番先頭文字から）
        ///</summary>
        private void setKensaku()
        {
            //中段グリッドの中身がない場合
            if (gridKataban2.Rows.Count <= 0)
            {
                return;
            }

            //検索テキストの中身がない場合
            if (!txtKensaku.blIsEmpty())
            {
                return;
            }

            //数値チェックに使う
            double dblKensaku = 0;

            //数値チェック後に確保用
            string strUkata = "";

            //中段グリッド型番確保用
            string strKataban = "";

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

            //中段グリッドの中身分ループ
            for (int intCnt = 0; intCnt < gridKataban2.Rows.Count; intCnt++)
            {
                //型番を確保
                strKataban = gridKataban2.Rows[intCnt].Cells["型番"].Value.ToString();

                //空白を除去
                strKataban = strKataban.Replace(" ", "");

                //型番先頭文字列が検索文字と一致する場合
                if (strKataban.StartsWith(strUkata))
                {
                    gridKataban2.CurrentCell = gridKataban2.Rows[intCnt].Cells["型番"];
                    txtKensaku.Text = "";
                    break;
                }
            }
        }

        ///<summary>
        ///setNyuryoku
        ///入力ボタンを押した場合
        ///</summary>
        private void setNyuryoku(object sender, EventArgs e)
        {
            int intR1;
            int intR2;
            int intRow;
            bool blShimukeAri;

            //中段グリッドにデータがない場合
            if (gridKataban2.Rows.Count <= 0)
            {
                return;
            }

            //発注数テキストにデータがない場合
            if (!txtHachusu.blIsEmpty())
            {
                txtHachusu.Focus();
                return;
            }

            //単価テキストにデータがない場合
            if (!txtTanka.blIsEmpty())
            {
                txtTanka.Focus();
                return;
            }

            //納期テキストにデータがない場合
            if (!txtNoki.blIsEmpty())
            {
                txtNoki.Focus();
                return;
            }

            //仕向けテキストにデータがない場合        
            if (!StringUtl.blIsEmpty(lblSetShimukesaki.CodeTxtText))
            {
                lblSetShimukesaki.Focus();
                return;
            }

            //仕向け先コード名が"...."の場合
            if (lblSetShimukesaki.CodeTxtText == "....")
            {
                lblSetShimukesaki.Focus();
                return;
            }

            //担当者コードテキストにデータがない場合        
            if (!StringUtl.blIsEmpty(lblSetHachuTantousha.CodeTxtText))
            {
                lblSetHachuTantousha.Focus();
                return;
            }

            //中段グリッドの中身の行数分ループ
            for (intR1 = 0; intR1 <= gridKataban2.Rows.Count; intR1++)
            {
                //商品コードが中段グリッドと一致した場合
                if (gridKataban2.Rows[intR1].Cells["商品コード"].Value.ToString() == txtShohinCd.Text)
                {
                    break;
                }
            }

            blShimukeAri = false;

            //中段グリッドの中身の行数分ループ
            for (intR2 = intR1; intR2 < gridKataban2.Rows.Count; intR2++)
            {
                //該当の商品コードがあった場合
                if (gridKataban2.Rows[intR2].Cells["商品コード"].Value.ToString() == txtShohinCd.Text)
                {
                    //仕向け先コードがあった場合
                    if (gridKataban2.Rows[intR2].Cells["ｺｰﾄﾞ"].Value.ToString() == lblSetShimukesaki.CodeTxtText)
                    {
                        //仕向けがある
                        blShimukeAri = true;
                        break;
                    }
                }
            }

            //仕向けがあった場合
            if (blShimukeAri)
            {
                intRow = intR2;
            }
            else
            {
                intRow = intR1;
            }

            //intRow値が1以上の場合
            if (intRow >= 0)
            {
                //発注数がある場合
                if (txtHachusu.blIsEmpty())
                {
                    //箱入数を発注数で割った時0以外の場合
                    if (int.Parse(txtHachusu.Text) % Math.Floor(double.Parse(gridKataban2.Rows[intRow].Cells["箱入数"].Value.ToString())) != 0)
                    {
                        //発注数を含む場合のウィンドウ（OK）
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "発注数は箱入数の倍数を入力してください。箱入数：" + (Math.Floor(double.Parse(gridKataban2.Rows[intRow].Cells["箱入数"].Value.ToString()))).ToString(), CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        txtHachusu.Focus();
                        return;
                    }
                    gridKataban2.Rows[intRow].Cells["発注数"].Value = txtHachusu.Text;
                }

                //単価がある場合
                if (txtTanka.blIsEmpty())
                {
                    //「,]があった場合一度取り除く
                    if (txtTanka.Text.Contains(','))
                    {
                        txtTanka.Text = txtTanka.Text.Replace(",", "");
                    }

                    gridKataban2.Rows[intRow].Cells["単価"].Value = txtTanka.Text;
                }

                //金額がある場合
                if (txtKingaku.blIsEmpty())
                {
                    gridKataban2.Rows[intRow].Cells["金額"].Value = (decimal.Parse(gridKataban2.Rows[intRow].Cells["単価"].Value.ToString())) * (decimal.Parse(gridKataban2.Rows[intRow].Cells["発注数"].Value.ToString()));
                }

                //納期がある場合
                if (txtNoki.blIsEmpty())
                {
                    gridKataban2.Rows[intRow].Cells["納期"].Value = txtNoki.Text;
                }

                //仕向先がある場合
                if (StringUtl.blIsEmpty(lblSetShimukesaki.CodeTxtText))
                {
                    gridKataban2.Rows[intRow].Cells["ｺｰﾄﾞ"].Value = lblSetShimukesaki.CodeTxtText.ToString();
                    gridKataban2.Rows[intRow].Cells["仕向け先名"].Value = lblSetShimukesaki.ValueLabelText;
                }

                //担当者コードがある場合
                if (StringUtl.blIsEmpty(lblSetHachuTantousha.CodeTxtText))
                {
                    gridKataban2.Rows[intRow].Cells["発注担当者コード"].Value = lblSetHachuTantousha.CodeTxtText.ToString();
                    gridKataban2.Rows[intRow].Cells["発注担当者"].Value = lblSetHachuTantousha.ValueLabelText.ToString();
                }
            }
        }

        ///<summary>
        ///chkTxtData
        ///上段テキストデータ存在チェック
        ///引数　：なし
        ///戻り値：エラー発生【false】
        ///</summary>
        private bool chkTxtData()
        {
            //戻り値用
            Boolean blnGood = true;

            //年月度
            if (txtYM.blIsEmpty() == false)
            {
                blnGood = false;

                //記入漏れ発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                txtYM.Focus();
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //集計月数
                if (txtShukeiM.blIsEmpty() == false)
                {
                    blnGood = false;

                    //記入漏れ発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n数値を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtShukeiM.Focus();
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //在庫年月度
                if (txtZaikoYMD.blIsEmpty() == false)
                {
                    blnGood = false;

                    //記入漏れ発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtZaikoYMD.Focus();
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //発注年月度
                if (txtHachuYMD.blIsEmpty() == false)
                {
                    blnGood = false;

                    //記入漏れ発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    txtHachuYMD.Focus();
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //大分類
                if (lblSetDaibunrui.CodeTxtText == "")
                {
                    blnGood = false;

                    //記入漏れ発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n文字を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    lblSetDaibunrui.Focus();
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //中分類
                if (lblSetChubunrui.CodeTxtText == "")
                {
                    blnGood = false;

                    //記入漏れ発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    lblSetChubunrui.Focus();
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //メーカー
                if (lblSetMaker.CodeTxtText == "")
                {
                    blnGood = false;

                    //記入漏れ発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    lblSetMaker.Focus();
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //仕入先コード
                if (lblSetShiresaki.CodeTxtText == "")
                {
                    blnGood = false;

                    //記入漏れ発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力項目が空です。\r\n日付を入力してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    lblSetShiresaki.Focus();
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                // 年月日の日付フォーマットチェック
                string datedata = txtYM.chkDateYMDataFormat(txtYM.Text);
                if ("".Equals(datedata))
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    blnGood = false;
                }
                else
                {
                    txtYM.Text = datedata;
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //文字列チェック（大分類コード）
                if (lblSetDaibunrui.chkTxtDaibunrui())
                {
                    blnGood = false;
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //文字列チェック（中分類コード）
                if (lblSetChubunrui.chkTxtChubunrui(lblSetDaibunrui.CodeTxtText))
                {
                    blnGood = false;
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //文字列チェック（メーカーコード）
                if (lblSetMaker.chkTxtMaker())
                {
                    blnGood = false;
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //文字列チェック（仕入先コード）
                if (lblSetShiresaki.chkTxtTorihikisaki())
                {
                    blnGood = false;
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //データがある場合
                if (txtShukeiM.blIsEmpty())
                {
                    //集計月数
                    if (txtShukeiM.chkMoneyText() == false)
                    {
                        blnGood = false;
                    }
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //データがある場合
                if (txtHachuYMD.blIsEmpty())
                {
                    // 発注年月日の日付フォーマットチェック
                    string datedata = txtHachuYMD.chkDateDataFormat(txtHachuYMD.Text);
                    if ("".Equals(datedata))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        blnGood = false;
                    }
                    else
                    {
                        txtHachuYMD.Text = datedata;
                    }
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //データがある場合
                if (txtHachusu.blIsEmpty())
                {
                    //発注数
                    if (txtHachusu.chkMoneyText() == false)
                    {
                        blnGood = false;
                    }
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //データがある場合
                if (txtTanka.blIsEmpty())
                {
                    //単価
                    if (txtTanka.chkMoneyText() == false)
                    {
                        blnGood = false;
                    }
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //データがある場合
                if (txtNoki.blIsEmpty())
                {
                    // 納期の日付フォーマットチェック
                    string datedata = txtNoki.chkDateDataFormat(txtNoki.Text);
                    if ("".Equals(datedata))
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();

                        blnGood = false;
                    }
                    else
                    {
                        txtNoki.Text = datedata;
                    }
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //仕向先
                if (lblSetShimukesaki.chkTxtTorihikisaki())
                {
                    blnGood = false;
                }
            }

            //エラーになってない場合
            if (blnGood == true)
            {
                //担当者コード
                if (lblSetHachuTantousha.chkTxtTantosha())
                {
                    blnGood = false;
                }
            }

            return (blnGood);
        }

        ///<summary>
        ///btnChancel_Click
        ///下段入力項目の修正を取り消して中段グリッドにも反映する
        ///引数　：画面情報、イベント情報
        ///戻り値：なし
        ///</summary>
        private void btnChancel_Click(object sender, EventArgs e)
        {
            int intRow;
            int intR1;
            int intR2;
            bool blShimukeAri;

            //取り消し項目更新実行用
            List<string> lstStringTorikeshi = new List<string>();

            //中段グリッドにデータがない場合
            if (gridKataban2.Rows.Count <= 0)
            {
                return;
            }

            //中段グリッド行数分ループ
            for (intR1 = 0; intR1 < gridKataban2.Rows.Count; intR1++)
            {
                //商品コードが一致している場合
                if ((String)gridKataban2.Rows[intR1].Cells["商品コード"].Value == txtShohinCd.Text)
                {
                    break;
                }
            }

            blShimukeAri = false;

            //中段グリッド行数分ループ
            for (intR2 = intR1; intR2 < gridKataban2.Rows.Count; intR2++)
            {
                //商品コードが一致している場合
                if ((String)gridKataban2.Rows[intR2].Cells["商品コード"].Value == txtShohinCd.Text)
                {
                    //仕向け先コードが一致する場合
                    if ((String)gridKataban2.Rows[intR2].Cells["ｺｰﾄﾞ"].Value == lblSetShimukesaki.CodeTxtText)
                    {
                        blShimukeAri = true;
                        break;
                    }
                }
            }

            //仕向けありの場合
            if (blShimukeAri == true)
            {
                intRow = intR2;
            }
            else
            {
                intRow = intR1;
            }

            //最後までなかった場合
            if (intRow == gridKataban2.Rows.Count)
            {
                return;
            }

            //発注登録済みの場合
            if (StringUtl.blIsEmpty(gridKataban2.Rows[intRow].Cells["発注番号2"].Value.ToString()) == true)
            {
                //メッセージボックスの処理、削除するか否かのウィンドウ(YES,NO)
                BaseMessageBox basemessagebox = new BaseMessageBox(this, "取り消し", "発注登録済みですが、取り消しますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
                //NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
                try
                {
                    //DBに取り消しを実行
                    monyuryokuB.updTorikeshi(txtYM.Text, gridKataban2.Rows[intR2].Cells["発注番号2"].Value.ToString());

                    //中段グリッド再表示
                    showGridKataban2();

                    //上段グリッド再表示
                    showGridKataban1();
                }
                catch (Exception ex)
                {
                    //データロギング
                    new CommonException(ex);
                    //例外発生メッセージ（OK）
                    basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }
            }

            //修正データがある場合
            if (intRow > 0)
            {
                gridKataban2.Rows[intRow].Cells["発注数"].Value = "0";
                gridKataban2.Rows[intRow].Cells["金額"].Value = "0";
                gridKataban2.Rows[intRow].Cells["納期"].Value = "";
                gridKataban2.Rows[intRow].Cells["ｺｰﾄﾞ"].Value = "....";
                gridKataban2.Rows[intRow].Cells["仕向け先名"].Value = "";
                gridKataban2.Rows[intRow].Cells["発注担当者"].Value = "";

                //取り消しした項目文字列を黒に戻す
                setGridColor();

                //下段入力項目の初期化
                txtHachusu.Text = "";
                txtNoki.Text = "";
                lblSetShimukesaki.codeTxt.Clear();
                lblSetShimukesaki.ValueLabelText = "";
                lblSetHachuTantousha.codeTxt.Clear();
                lblSetHachuTantousha.ValueLabelText = "";
                txtShohinCd.Clear();
                txtTanka.Clear();
            }
        }

        ///<summary>
        ///saveCSV
        ///ＣＳＶで保存
        ///引数　：なし
        ///戻り値：なし
        ///</summary>
        private void saveCSV()
        {
            //保存時のファイル名初期表示
            string strText;

            //SQL実行時に取り出したデータを入れる用
            DataTable dtPrintData = new DataTable();

            //印刷用データを入れる用
            List<string> lstPrintData = new List<string>();

            //印刷用データを入れる
            lstPrintData.Add(txtYM.Text);
            lstPrintData.Add(lblSetMaker.CodeTxtText);
            lstPrintData.Add(lblSetDaibunrui.CodeTxtText);
            lstPrintData.Add(lblSetChubunrui.CodeTxtText);

            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                //SaveFileDialogクラスのインスタンスを作成
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                //ダイアログタイトル
                saveFileDialog.Title = "ファイルの保存";

                //ダイアログ状でフォルダ変更して閉じた際に、元に戻す→true、戻さない→false
                saveFileDialog.RestoreDirectory = true;

                //CSVデータのみを選択できるようにする,|すべてのファイル|*.*|*.*
                saveFileDialog.Filter = "CSVファイル|*.csv";

                //ファイル名初期値の（"/"," ",":"を空にする）
                strText = "ＭＯ入力" + (DateTime.Now).ToString().Replace("/", "");
                strText = strText.Replace(" ", "");
                strText = strText.Replace(":", "");

                saveFileDialog.FileName = strText;

                //ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //印刷データの取得(各データを渡す)
                    dtPrintData = monyuryokuB.getPrintData(lstPrintData);

                    //印刷データにない場合
                    if (dtPrintData.Rows.Count == 0)
                    {
                        //データ存在なしメッセージ（OK）
                        BaseMessageBox basemessagebox_Nodata = new BaseMessageBox(this, "", "該当データはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox_Nodata.ShowDialog();
                        return;
                    }

                    //CSV化するdatatableの列数
                    int intRows = dtPrintData.Rows.Count;
                    //CSV化するdatatableの行数
                    int intCols = dtPrintData.Columns.Count;

                    //行数カウント用
                    int intRowsCnt;
                    //列数カウント用
                    int intColsCnt;
                    //最終行
                    int lastColIndex = intCols - 1;

                    //ヘッダ取得用
                    string strHeader = "";
                    //データ取得用
                    string strData = "";

                    //書き込み用
                    StreamWriter swKakikomi = null;

                    //CSVファイルに書き込むときに使うEncoding
                    Encoding enc = Encoding.GetEncoding("Shift_JIS");

                    //DataTable内の値を確保、CSVで扱えるように加工
                    for (intRowsCnt = 0; intRowsCnt < intRows; intRowsCnt++)
                    {

                        for (intColsCnt = 0; intColsCnt < intCols; intColsCnt++)
                        {
                            //一行目の場合
                            if (intRowsCnt == 0)
                            {
                                strHeader += "\"";
                                strData += "\"";

                                //ヘッダの取得
                                strHeader += dtPrintData.Columns[intColsCnt].Caption.Replace(" ", "");
                                strHeader += "\"";

                                //納期の場合
                                if (intColsCnt == 3)
                                {
                                    //YMDのみに変換してデータの取得
                                    strData += DateTime.Parse(dtPrintData.Rows[intRowsCnt][intColsCnt].ToString()).ToString("yyyy/MM/dd").Replace(" ", "");
                                }
                                else
                                {
                                    //データの取得
                                    strData += dtPrintData.Rows[intRowsCnt][intColsCnt].ToString().Replace(" ", "");
                                }
                                strData += "\"";

                                //最後以外カンマを書き込む
                                if (lastColIndex > intColsCnt)
                                {
                                    strHeader += ",";
                                    strData += ",";
                                }
                                //最後まで行ったら
                                else
                                {
                                    //書き込む場所と名前を指定
                                    swKakikomi = new StreamWriter(saveFileDialog.FileName, true, enc);

                                    //記入,改行
                                    swKakikomi.WriteLine(strHeader);
                                    swKakikomi.WriteLine(strData);

                                    //閉じる
                                    swKakikomi.Close();

                                    //初期化
                                    strHeader = "";
                                    strData = "";
                                }
                            }
                            //２行目以降の場合
                            else
                            {
                                strData += "\"";
                                //データの取得
                                if (string.IsNullOrWhiteSpace(dtPrintData.Rows[intRowsCnt][intColsCnt].ToString()))
                                {
                                    strData += "";
                                }
                                else
                                {
                                    //納期の場合
                                    if (intColsCnt == 3)
                                    {
                                        //YMDのみに変換してデータの取得
                                        strData += DateTime.Parse(dtPrintData.Rows[intRowsCnt][intColsCnt].ToString()).ToString("yyyy/MM/dd").Replace(" ", "");
                                    }
                                    else
                                    {
                                        //データの取得
                                        strData += dtPrintData.Rows[intRowsCnt][intColsCnt].ToString().Replace(" ", "");
                                    }
                                }
                                strData += "\"";

                                //最後以外カンマを書き込む
                                if (lastColIndex > intColsCnt)
                                {
                                    strData += ",";
                                }
                                //最後まで行ったら
                                else if (lastColIndex == intColsCnt)
                                {
                                    //書き込む場所と名前を指定
                                    swKakikomi = new StreamWriter(saveFileDialog.FileName, true, enc);

                                    //記入,改行
                                    swKakikomi.WriteLine(strData);

                                    //閉じる
                                    swKakikomi.Close();

                                    //初期化
                                    strData = "";
                                }//ヘッダーかデータかの判断
                            }//行数ループ
                        }//列数ループ
                    }//書き込み終了

                    //CSVファイル作成完了メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, "", "CSVファイルを作成しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    return;
                }
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
        ///printMO
        ///印刷ダイアログ
        ///</summary>
        private void printMO()
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtPrintData = new DataTable();

            //PDF作成後の入れ物
            string strFile = "";

            //上段入力項目チェック
            if (chkTxtData() == false)
            {
                return;
            }

            //印刷用データを入れる用
            List<string> lstPrintData = new List<string>();

            //印刷用データを入れる
            lstPrintData.Add(txtYM.Text);
            lstPrintData.Add(lblSetMaker.CodeTxtText);
            lstPrintData.Add(lblSetDaibunrui.CodeTxtText);
            lstPrintData.Add(lblSetChubunrui.CodeTxtText);

            //印刷ヘッダーに記載する用
            List<string> lstPrintHeader = new List<string>();

            DateTime dateYM = DateTime.Parse(txtYM.Text);

            //印刷ヘッダーに記載する
            lstPrintHeader.Add(dateYM.Year + "年" + dateYM.Month + "月度");
            lstPrintHeader.Add(lblSetShiresaki.ValueLabelText);

            B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
            try
            {
                //印刷データの取得(各データを渡す)
                dtPrintData = monyuryokuB.getPrintData(lstPrintData);

                //印刷データにない場合
                if (dtPrintData.Rows.Count == 0)
                {
                    //データ存在なしメッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, "", "該当データはありません。。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    return;
                }

                //初期値
                Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, YOKO);

                pf.ShowDialog(this);

                //プレビューの場合
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    //結果セットをレコードセットに
                    strFile = monyuryokuB.dbToPdf(dtPrintData, lstPrintHeader);

                    // プレビュー
                    pf.execPreview(strFile);
                }
                // 一括印刷の場合
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    // PDF作成
                    strFile = monyuryokuB.dbToPdf(dtPrintData, lstPrintHeader);

                    // 一括印刷
                    pf.execPrint(null, strFile, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
                }

                pf.Dispose();
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
        ///getExelData
        ///エクセル取込
        ///引数　：なし
        ///戻り値：なし
        ///</summary>
        private void setExcelData()
        {
            //エクセルデータを入れる用
            DataTable dtExcelData = new DataTable();

            //ファイルパス用
            string strFilePath = "";

            //ディレクトリパス用
            string strDirectoryPath = "";

            //ファイル拡張子用
            string strKakucho = "";

            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //ダイアログタイトル
            openFileDialog.Title = "ファイルを開く";

            //ダイアログ状でフォルダ変更して閉じた際に、元に戻す→true、戻さない→false
            openFileDialog.RestoreDirectory = true;

            //xlsデータのみを選択できるようにする
            openFileDialog.Filter = "Excelファイル|*.xls";

            //ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //ファイルパスを取得
                strFilePath = openFileDialog.FileName;

                //ディレクトリパスを取得
                strDirectoryPath = Path.GetDirectoryName(strFilePath);

                //拡張子を取得
                strKakucho = Path.GetExtension(strFilePath);

                //ＭＯ入力のビジネス層
                B0250_MOnyuryoku_B monyuryokuB = new B0250_MOnyuryoku_B();
                //PDF作成層
                CreatePdf createpdf = new CreatePdf();
                try
                {
                    //エクセルデータをデータテーブルで取得する
                    dtExcelData = createpdf.exceltoDataTable(strFilePath, strKakucho);

                    int intIDCol;
                    intIDCol = 3;
                    int intSuCol;
                    intSuCol = 6;

                    string Kataban;

                    int i;
                    int r;
                    int IDRow;
                    bool ari;
                    string NasiKataban;
                    NasiKataban = "";

                    IDRow = 2;

                    for (i = IDRow; i < dtExcelData.Rows.Count; i++)
                    {
                        if (dtExcelData.Rows[i][intIDCol].ToString().Trim() == "")
                        {
                            break;
                        }

                        //空白を削除
                        Kataban = dtExcelData.Rows[i][intIDCol].ToString().Trim();

                        ari = false;

                        for (r = 0; r < this.gridKataban2.RowCount; r++)
                        {
                            //該当の型番の場合
                            if (gridKataban2.Rows[r].Cells["型番"].Value.ToString().Trim() == Kataban)
                            {
                                gridKataban2.Rows[r].Cells["発注指"].Value = dtExcelData.Rows[i][intSuCol].ToString();
                                ari = true;
                                break;
                            }
                        }

                        //型番なしの場合
                        if (ari == false)
                        {
                            NasiKataban = NasiKataban + Kataban + "\t" + "\t" + "\t" + dtExcelData.Rows[i][intSuCol].ToString() + "\r\n";
                        }
                    }

                    //型番がある場合
                    if (NasiKataban != "")
                    {
                        //メモ帳に書き込みとファイルを開く
                        monyuryokuB.setExcelData(strDirectoryPath, NasiKataban);
                    }
                }
                catch (Exception ex)
                {
                    //データロギング
                    new CommonException(ex);
                    //例外発生メッセージ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
            }
        }

        ///<summary>
        ///gridKataban2_Sorted
        ///ソートをした場合に文字色指定
        ///引数　：画面情報、イベント情報
        ///戻り値：なし
        ///</summary>
        private void gridKataban2_Sorted(object sender, EventArgs e)
        {
            //グリッドの文字色指定
            setGridColor();
        }

        ///<summary>
        ///txtHachusu_Leave
        ///数量の文字数チェック
        ///</summary>
        private void txtHachusu_Leave(object sender, EventArgs e)
        {
            //文字数が7を超える場合
            if (txtHachusu.Text.Length > 7)
            {
                SendKeys.Send("+{TAB}");
                return;
            }
        }
    }
}
