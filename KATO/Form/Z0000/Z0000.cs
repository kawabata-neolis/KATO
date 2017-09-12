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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Permissions;
using KATO.Common.Ctl;
using KATO.Common.Util;
using KATO.Business.Z0000_MainMenu_B;

namespace KATO.Form.Z0000
{
    ///<summary>
    ///Z0000
    ///メインメニューフォーム
    ///作成者：大河内
    ///作成日：2017/2/2
    ///更新者：大河内
    ///更新日：2017/2/2
    ///カラム論理名
    ///</summary>
    public partial class Z0000 : BaseForm
    {
        ///<summary>
        ///Z0000
        ///フォームの初期設定
        ///</summary>
        public Z0000()
        {
            InitializeComponent();
        }

        ///<summary>
        ///Z0000_Load
        ///画面レイアウト設定
        ///</summary>
        private void Z0000_Load(object sender, EventArgs e)
        {
            this.btnF12.Text = STR_FUNC_F12;

            //フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            //TabControlをオーナードローする
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            //DrawItemイベントハンドラを追加
            tabControl1.DrawItem += new DrawItemEventHandler(TabControl1_DrawItem);
        }

        ///<summary>
        ///TabControl1_DrawItem
        ///DrawItemイベントハンドラを追加
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
        ///judFuncBtnClick
        ///ファンクションボタンの反応
        ///</summary>
        private void judFuncBtnClick(object sender, EventArgs e)
        {
            //ボタン入力情報によって動作を変える
            switch (((System.Windows.Forms.Button)sender).Name)
            {
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///judKeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void judKeyDown(object sender, KeyEventArgs e)
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
                    this.Close();
                    break;

                default:
                    break;
            }

            //同時押しの場合
            if (e.KeyCode == Keys.A && e.Shift == true)
            {
                if (TestButton1.Visible == true)
                {
                    TestButton1.Visible = false;
                    TestButton2.Visible = false;
                    TestButton3.Visible = false;
                    TestButton4.Visible = false;
                    TestButton5.Visible = false;
                }
                else
                {
                    TestButton1.Visible = true;
                    TestButton2.Visible = true;
                    TestButton3.Visible = true;
                    TestButton4.Visible = true;
                    TestButton5.Visible = true;
                }
            }
        }

        //
        // テスト用
        // 印刷テスト
        private void baseMenuButton1_Click(object sender, EventArgs e)
        {
            //Common.Form.PrintForm pf = new Common.Form.PrintForm(this, @"G:\aaa.pdf", CommonTeisu.SIZE_A4, CommonTeisu.YOKO);
            Common.Form.PrintForm pf = new Common.Form.PrintForm(this, "", CommonTeisu.SIZE_A4, CommonTeisu.YOKO);

            try
            {
                pf.ShowDialog(this);
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    pf.execPreview(@"G:\aaa.pdf");
                    pf.ShowDialog(this);
                } else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    pf.execPrint(null, @"G:\aaa.pdf", CommonTeisu.SIZE_A4, CommonTeisu.YOKO, true);
                }
            }
            catch (Exception ex)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, ex.Message + "\r\n" + ex.StackTrace, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
            pf.Dispose();
        }

        ///<summary>
        ///btnClick
        ///ボタンの反応
        ///</summary>
        private void btnClick(object sender, EventArgs e)
        {
            // このフォームで現在アクティブなコントロールを取得する
            Control cControl = this.ActiveControl;

            switch (cControl.Text)
            {
                case "受注入力":
                    A0010_JuchuInput.A0010_JuchuInput juchuinput = new A0010_JuchuInput.A0010_JuchuInput(this);
                    juchuinput.ShowDialog();
                    break;

                case "売上入力":
                    A0020_UriageInput.A0020_UriageInput uriageinput = new A0020_UriageInput.A0020_UriageInput(this);
                    uriageinput.ShowDialog();
                    break;

                case "仕入入力":
                    A0030_ShireInput.A0030_ShireInput shireinput = new A0030_ShireInput.A0030_ShireInput(this);
                    shireinput.ShowDialog();
                    break;

                case "入金入力":
                    B0040_NyukinInput.B0040_NyukinInput nyukininput = new B0040_NyukinInput.B0040_NyukinInput(this);
                    nyukininput.ShowDialog();
                    break;

                case "入金データチェックリスト":
                    B0050_NyukinCheckPrint.B0050_NyukinCheckPrint nyukincheck = new B0050_NyukinCheckPrint.B0050_NyukinCheckPrint(this);
                    nyukincheck.ShowDialog();
                    break;

                case "仕入データチェックリスト":
                    A0090_SiireCheckPrint.A0090_SiireCheckPrint shirecheck = new A0090_SiireCheckPrint.A0090_SiireCheckPrint(this);
                    shirecheck.ShowDialog();
                    break;

                case "発注入力":
                    A0100_HachuInput.A0100_HachuInput hachuinput = new A0100_HachuInput.A0100_HachuInput(this);
                    hachuinput.ShowDialog();
                    break;

                case "担当者別売上管理表":
                    C0130_TantouUriageArariPrint.C0130_TantouUriageArariPrint tantouriarari = new C0130_TantouUriageArariPrint.C0130_TantouUriageArariPrint(this);
                    tantouriarari.ShowDialog();
                    break;

                case "棚卸入力":
                    F0140_TanaorosiInput.F0140_TanaorosiInput tanainput = new F0140_TanaorosiInput.F0140_TanaorosiInput(this);
                    tanainput.ShowDialog();
                    break;

                case "売上チェックリスト":
                    A0150_UriageCheckPrint.A0150_UriageCheckPrint uriagecheck = new A0150_UriageCheckPrint.A0150_UriageCheckPrint(this);
                    uriagecheck.ShowDialog();
                    break;

                case "出庫依頼入力":

                    break;

                case "出庫承認入力":

                    break;

                case "見積書入力":
                    //作成中
                    break;

                case "ＭＯ入力":
                    //作成中
                    break;

                case "ＭＯ入力確定":
                    
                    break;

                case "倉庫移動確認":
                    
                    break;

                case "客先別倉庫数":

                    break;

                case "在庫一覧確認":
                    D0300_ZaikoIchiranKakunin.D0300_ZaikoIchiranKakunin zaikokakunin = new D0300_ZaikoIchiranKakunin.D0300_ZaikoIchiranKakunin(this);
                    zaikokakunin.ShowDialog();
                    break;

                case "売上実績確認":
                    D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin uriagekakunin = new D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, 0, "", "");
                    uriagekakunin.ShowDialog();
                    break;

                case "仕入実績確認":
                    D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin shirejissekikakunin = new D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin(this);
                    shirejissekikakunin.ShowDialog();
                    break;

                case "得意先元帳確認":
                    E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin tokuimotochokakunin = new E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin(this, 0, "");
                    tokuimotochokakunin.ShowDialog();
                    break;

                case "仕入先元帳確認":
                    E0340_SiiresakiMotochouKakunin.E0340_SiiresakiMotochouKakunin shiremotochokakunin = new E0340_SiiresakiMotochouKakunin.E0340_SiiresakiMotochouKakunin(this);
                    shiremotochokakunin.ShowDialog();
                    break;

                case "受注残確認":
                    D0360_JuchuzanKakunin.D0360_JuchuzanKakunin juchuzankakunin = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this);
                    juchuzankakunin.ShowDialog();
                    break;

                case "商品元帳確認":
                    D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin shohinmotochokakunin = new D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin(this);
                    shohinmotochokakunin.ShowDialog();
                    break;

                case "請求一覧表":
                    B0410_SeikyuItiranPrint.B0410_SeikyuItiranPrint seikyuitiran = new B0410_SeikyuItiranPrint.B0410_SeikyuItiranPrint(this);
                    seikyuitiran.ShowDialog();
                    break;

                case "請求明細書":
                    B0420_SeikyuMeisaishoPrint.B0420_SeikyuMeisaishoPrint seikyumesai = new B0420_SeikyuMeisaishoPrint.B0420_SeikyuMeisaishoPrint(this);
                    seikyumesai.ShowDialog();
                    break;

                case "発注数変更":
                    A0470_Hachusuhenko.A0470_Hachusuhenko hachusuhenko = new A0470_Hachusuhenko.A0470_Hachusuhenko(this);
                    hachusuhenko.ShowDialog();
                    break;

                case "分類別仕入推移表":
                    C0480_SiireSuiiHyo.C0480_SiireSuiiHyo shiresuiihyo = new C0480_SiireSuiiHyo.C0480_SiireSuiiHyo(this);
                    shiresuiihyo.ShowDialog();
                    break;

                case "分類別売上推移表":
                    C0490_UriageSuiiHyo.C0490_UriageSuiiHyo uriagesuiihyo = new C0490_UriageSuiiHyo.C0490_UriageSuiiHyo(this);
                    uriagesuiihyo.ShowDialog();
                    break;

                case "得意先別売上粗利推移表":
                    C0530_UriageArariSuiihyoPrint.C0530_UriageArariSuiihyoPrint uriageararisuii = new C0530_UriageArariSuiihyoPrint.C0530_UriageArariSuiihyoPrint(this);
                    uriageararisuii.ShowDialog();
                    break;

                case "棚卸プレシート":
                    F0570_TanaorosiKinyuhyoPrint.F0570_TanaorosiKinyuhyoPrint tanaoroshikinyu = new F0570_TanaorosiKinyuhyoPrint.F0570_TanaorosiKinyuhyoPrint(this);
                    tanaoroshikinyu.ShowDialog();
                    break;

                case "封書宛名印刷":
                    M0620_HushoAtenaInsatsu.M0620_HushoAtenaInsatsu hushoatena = new M0620_HushoAtenaInsatsu.M0620_HushoAtenaInsatsu(this);
                    hushoatena.ShowDialog();
                    break;

                case "得意先別売上管理表":
                    C0630_TokuisakiUriageArariPrint.C0630_TokuisakiUriageArariPrint tokuisakiuriagearari = new C0630_TokuisakiUriageArariPrint.C0630_TokuisakiUriageArariPrint(this);
                    tokuisakiuriagearari.ShowDialog();
                    break;

                case "商品群別売上仕入管理表":
                    C0650_SyohingunUriageSiirePrint.C0650_SyohingunUriageSiirePrint shohingunuriagesire = new C0650_SyohingunUriageSiirePrint.C0650_SyohingunUriageSiirePrint(this);
                    shohingunuriagesire.ShowDialog();
                    break;

                case "得意先別売上検収入力＆確認":
                    //作成中
                    break;

                case "売上実績確認（AS400）":
                    D0680_UriageJissekiKakuninAS400.D0680_UriageJissekiKakuninAS400 uriagejissekias400 = new D0680_UriageJissekiKakuninAS400.D0680_UriageJissekiKakuninAS400(this);
                    uriagejissekias400.ShowDialog();
                    break;

                case "仕入実績確認（AS400）":
                    D0690_SiireJissekiKakuninAS400.D0690_SiireJissekiKakuninAS400 shirejissekias400 = new D0690_SiireJissekiKakuninAS400.D0690_SiireJissekiKakuninAS400(this);
                    shirejissekias400.ShowDialog();
                    break;

                case "日付制限":
                    G0920_HidukeSeigen.G0920_HidukeSeigen hidukeseigen = new G0920_HidukeSeigen.G0920_HidukeSeigen(this);
                    hidukeseigen.ShowDialog();
                    break;

                case "会社条件":
                    M1000_Kaishajyoken.M1000_Kaishajyoken kaisyajoken = new M1000_Kaishajyoken.M1000_Kaishajyoken(this);
                    kaisyajoken.ShowDialog();
                    break;

                case "大分類 ":
                    M1010_Daibunrui.M1010_Daibunrui daibunrui = new M1010_Daibunrui.M1010_Daibunrui(this);
                    daibunrui.ShowDialog();
                    break;

                case "メーカー":
                    M1020_Maker.M1020_Maker maker = new M1020_Maker.M1020_Maker(this);
                    maker.ShowDialog();
                    break;

                case "商品":
                    M1030_Shohin.M1030_Shohin shohin = new M1030_Shohin.M1030_Shohin(this);
                    shohin.ShowDialog();
                    break;

                case "取引区分":
                    M1040_Torihikikbn.M1040_Torihikikbn torihikikbn = new M1040_Torihikikbn.M1040_Torihikikbn(this);
                    torihikikbn.ShowDialog();
                    break;

                case "担当者":
                    M1050_Tantousha.M1050_Tantousha tantosha = new M1050_Tantousha.M1050_Tantousha(this);
                    tantosha.ShowDialog();
                    break;

                case "業種":
                    M1060_Gyoushu.M1060_Gyoshu gyoshu = new M1060_Gyoushu.M1060_Gyoshu(this);
                    gyoshu.ShowDialog();
                    break;

                case "取引先":
                    M1070_Torihikisaki.M1070_Torihikisaki torihikisaki = new M1070_Torihikisaki.M1070_Torihikisaki(this);
                    torihikisaki.ShowDialog();
                    break;

                case "営業所":
                    M1090_Eigyosho.M1090_Eigyosho eigyosho = new M1090_Eigyosho.M1090_Eigyosho(this);
                    eigyosho.ShowDialog();
                    break;

                case "直送先":
                    M1100_Chokusosaki.M1100_Chokusosaki chokusosaki = new M1100_Chokusosaki.M1100_Chokusosaki(this);
                    chokusosaki.ShowDialog();
                    break;

                case "中分類":
                    M1110_Chubunrui.M1110_Chubunrui chubunrui = new M1110_Chubunrui.M1110_Chubunrui(this);
                    chubunrui.ShowDialog();
                    break;

                case "棚番":
                    M1120_Tanaban.M1120_Tanaban tanaban = new M1120_Tanaban.M1120_Tanaban(this);
                    tanaban.ShowDialog();
                    break;

                case "消費税率":
                    M1130_Shohizeiritsu.M1130_Shohizeiritsu shohizeiritsu = new M1130_Shohizeiritsu.M1130_Shohizeiritsu(this);
                    shohizeiritsu.ShowDialog();
                    break;

                case "商品マスタ単価一括更新":
                    M1150_ShohinTankaIkkatsuUpdate.M1150_ShohinTankaIkkatsuUpdate shohintankaupdate = new M1150_ShohinTankaIkkatsuUpdate.M1150_ShohinTankaIkkatsuUpdate(this);
                    shohintankaupdate.ShowDialog();
                    break;

                case "特定向先単価マスタ":
                    M1160_TokuteimukesakiTanka.M1160_TokuteimukesakiTanka tokuteitankamaster = new M1160_TokuteimukesakiTanka.M1160_TokuteimukesakiTanka(this);
                    tokuteitankamaster.ShowDialog();
                    break;

                case "グループマスタ":
                    M1200_Group.M1200_Group group = new M1200_Group.M1200_Group(this);
                    group.ShowDialog();
                    break;

                case "商品分類別利益率設定":
                    M1210_ShohinbetsuRiekiritsuSettei.M1210_ShohinbetsuRiekiritsuSettei shohinbunruirieki = new M1210_ShohinbetsuRiekiritsuSettei.M1210_ShohinbetsuRiekiritsuSettei(this);
                    shohinbunruirieki.ShowDialog();
                    break;

                case "商品別利益率設定":
                    M1220_SyohinBunruiRiekiritsu.M1220_SyohinBunruiRiekiritsu shohinbeturieki = new M1220_SyohinBunruiRiekiritsu.M1220_SyohinBunruiRiekiritsu(this);
                    shohinbeturieki.ShowDialog();
                    break;

                case "担当者別伝票処理件数":
                    C6000_TantoshabetuDenpyoCount.C6000_TantoshabetuDenpyoCount tantoshabetusyori = new C6000_TantoshabetuDenpyoCount.C6000_TantoshabetuDenpyoCount(this);
                    tantoshabetusyori.ShowDialog();
                    break;

                case "商品仕入単価推移表2" :
                    M1240_ShohinSiireKakakuSuii2.M1240_ShohinSiireKakakuSuii2 shohintankasuii2 = new M1240_ShohinSiireKakakuSuii2.M1240_ShohinSiireKakakuSuii2(this);
                    shohintankasuii2.ShowDialog();
                    break;
            }
            txtShoriNo.Text = "";
            txtShoriNo.Focus();
        }

        ///<summary>
        ///txtShoriNo_Leave
        ///処理Noテキストから離れた時
        ///</summary>
        private void txtShoriNo_Leave(object sender, EventArgs e)
        {
            //担当者コードの出力先
            string strTantoshaCd = "";

            //権限があるかどうか
            string strKengen = "";

            //検索該当Controlの確保
            Control cSearch = new Control();

            //数字のみ可動化の判定
            bool blnGood;

            //空文字判定
            if (txtShoriNo.blIsEmpty() == false)
            {
                return;
            }

            //前後の空白を取り除く
            txtShoriNo.Text = txtShoriNo.Text.Trim();

            //数字のみを許可する
            blnGood = StringUtl.JudBanSelect(this.txtShoriNo.Text, CommonTeisu.NUMBER_ONLY);

            if (blnGood == false)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "指定のPG番号はマイメニューに設定されていません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            
            Z0000_MainMenu_B mainmenuB = new Z0000_MainMenu_B();
            try
            {
                //担当者コードの取得
                strTantoshaCd = mainmenuB.getTantoshaCd(SystemInformation.UserName);

                strKengen = mainmenuB.getKengen(strTantoshaCd, txtShoriNo.Text);

                if (strKengen == "N")
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, "入力", "指定のPG番号は現在使用中止されています。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                    txtShoriNo.Focus();
                    return;
                }

                switch (txtShoriNo.Text)
                {
                    case "1":
                        A0010_JuchuInput.A0010_JuchuInput juchuinput = new A0010_JuchuInput.A0010_JuchuInput(this);
                        juchuinput.ShowDialog();
                        break;

                    case "2":
                        A0020_UriageInput.A0020_UriageInput uriageinput = new A0020_UriageInput.A0020_UriageInput(this);
                        uriageinput.ShowDialog();
                        break;

                    case "3":
                        A0030_ShireInput.A0030_ShireInput shireinput = new A0030_ShireInput.A0030_ShireInput(this);
                        shireinput.ShowDialog();
                        break;

                    case "4":
                        B0040_NyukinInput.B0040_NyukinInput nyukininput = new B0040_NyukinInput.B0040_NyukinInput(this);
                        nyukininput.ShowDialog();
                        break;

                    case "5":
                        B0050_NyukinCheckPrint.B0050_NyukinCheckPrint nyukincheck = new B0050_NyukinCheckPrint.B0050_NyukinCheckPrint(this);
                        nyukincheck.ShowDialog();
                        break;

                    case "7":
                        A0090_SiireCheckPrint.A0090_SiireCheckPrint shirecheck = new A0090_SiireCheckPrint.A0090_SiireCheckPrint(this);
                        shirecheck.ShowDialog();
                        break;

                    case "10":
                        A0100_HachuInput.A0100_HachuInput hachuinput = new A0100_HachuInput.A0100_HachuInput(this);
                        hachuinput.ShowDialog();
                        break;

                    case "13":
                        C0130_TantouUriageArariPrint.C0130_TantouUriageArariPrint tantouriarari = new C0130_TantouUriageArariPrint.C0130_TantouUriageArariPrint(this);
                        tantouriarari.ShowDialog();
                        break;

                    case "14":
                        F0140_TanaorosiInput.F0140_TanaorosiInput tanainput = new F0140_TanaorosiInput.F0140_TanaorosiInput(this);
                        tanainput.ShowDialog();
                        break;

                    case "15":
                        A0150_UriageCheckPrint.A0150_UriageCheckPrint uriagecheck = new A0150_UriageCheckPrint.A0150_UriageCheckPrint(this);
                        uriagecheck.ShowDialog();
                        break;

                    case "16":
                        //出庫依頼入力
                        break;

                    case "17":
                        //出庫承認入力
                        break;

                    case "21":
                        //見積書入力
                        break;

                    case "25":
                        //ＭＯ入力
                        break;

                    case "26":
                        //ＭＯ入力確定
                        break;

                    case "28":
                        //倉庫移動確認
                        break;

                    case "29":
                        //客先別在庫表
                        break;
                        
                    case "30":
                        //在庫一覧確認
                        D0300_ZaikoIchiranKakunin.D0300_ZaikoIchiranKakunin zaikokakunin = new D0300_ZaikoIchiranKakunin.D0300_ZaikoIchiranKakunin(this);
                        zaikokakunin.ShowDialog();
                        break;

                    case "31":
                        //売上実績確認
                        D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin uriagekakunin = new D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, 0, "", "");
                        uriagekakunin.ShowDialog();
                        break;

                    case "32":
                        //仕入実績確認
                        D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin shirejissekikakunin = new D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin(this);
                        shirejissekikakunin.ShowDialog();
                        break;

                    case "33":
                        //得意先元帳確認
                        E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin tokuimotochokakunin = new E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin(this, 0, "");
                        tokuimotochokakunin.ShowDialog();
                        break;

                    case "34":
                        //仕入先元帳確認
                        E0340_SiiresakiMotochouKakunin.E0340_SiiresakiMotochouKakunin shiremotochokakunin = new E0340_SiiresakiMotochouKakunin.E0340_SiiresakiMotochouKakunin(this);
                        shiremotochokakunin.ShowDialog();
                        break;

                    case "36":
                        //受注残確認
                        D0360_JuchuzanKakunin.D0360_JuchuzanKakunin juchuzankakunin = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this);
                        juchuzankakunin.ShowDialog();
                        break;

                    case "38":
                        //商品元帳確認
                        D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin shohinmotochokakunin = new D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin(this);
                        shohinmotochokakunin.ShowDialog();
                        break;

                    case "41":
                        //請求一覧表
                        B0410_SeikyuItiranPrint.B0410_SeikyuItiranPrint seikyuitiran = new B0410_SeikyuItiranPrint.B0410_SeikyuItiranPrint(this);
                        seikyuitiran.ShowDialog();
                        break;

                    case "42":
                        //請求明細書
                        B0420_SeikyuMeisaishoPrint.B0420_SeikyuMeisaishoPrint seikyumesai = new B0420_SeikyuMeisaishoPrint.B0420_SeikyuMeisaishoPrint(this);
                        seikyumesai.ShowDialog();
                        break;

                    case "47":
                        //発注数変更
                        A0470_Hachusuhenko.A0470_Hachusuhenko hachusuhenko = new A0470_Hachusuhenko.A0470_Hachusuhenko(this);
                        hachusuhenko.ShowDialog();
                        break;

                    case "48":
                        //分類別仕入推移表
                        C0480_SiireSuiiHyo.C0480_SiireSuiiHyo shiresuiihyo = new C0480_SiireSuiiHyo.C0480_SiireSuiiHyo(this);
                        shiresuiihyo.ShowDialog();
                        break;

                    case "49":
                        //分類別売上推移表
                        C0490_UriageSuiiHyo.C0490_UriageSuiiHyo uriagesuiihyo = new C0490_UriageSuiiHyo.C0490_UriageSuiiHyo(this);
                        uriagesuiihyo.ShowDialog();
                        break;

                    case "53":
                        //得意先別売上粗利推移表
                        C0530_UriageArariSuiihyoPrint.C0530_UriageArariSuiihyoPrint uriageararisuii = new C0530_UriageArariSuiihyoPrint.C0530_UriageArariSuiihyoPrint(this);
                        uriageararisuii.ShowDialog();
                        break;

                    case "57":
                        //棚卸プレシート
                        F0570_TanaorosiKinyuhyoPrint.F0570_TanaorosiKinyuhyoPrint tanaoroshikinyu = new F0570_TanaorosiKinyuhyoPrint.F0570_TanaorosiKinyuhyoPrint(this);
                        tanaoroshikinyu.ShowDialog();
                        break;

                    case "62":
                        //封書宛名印刷
                        M0620_HushoAtenaInsatsu.M0620_HushoAtenaInsatsu hushoatena = new M0620_HushoAtenaInsatsu.M0620_HushoAtenaInsatsu(this);
                        hushoatena.ShowDialog();
                        break;

                    case "63":
                        //得意先別売上管理表
                        C0630_TokuisakiUriageArariPrint.C0630_TokuisakiUriageArariPrint tokuisakiuriagearari = new C0630_TokuisakiUriageArariPrint.C0630_TokuisakiUriageArariPrint(this);
                        tokuisakiuriagearari.ShowDialog();
                        break;

                    case "65":
                        //商品群別売上仕入管理表
                        C0650_SyohingunUriageSiirePrint.C0650_SyohingunUriageSiirePrint shohingunuriagesire = new C0650_SyohingunUriageSiirePrint.C0650_SyohingunUriageSiirePrint(this);
                        shohingunuriagesire.ShowDialog();
                        break;

                    case "66":
                        //得意先別売上検収入力＆確認
                        break;

                    case "68":
                        //売上実績確認（AS400）
                        D0680_UriageJissekiKakuninAS400.D0680_UriageJissekiKakuninAS400 uriagejissekias400 = new D0680_UriageJissekiKakuninAS400.D0680_UriageJissekiKakuninAS400(this);
                        uriagejissekias400.ShowDialog();
                        break;

                    case "69":
                        //仕入実績確認（AS400）
                        D0690_SiireJissekiKakuninAS400.D0690_SiireJissekiKakuninAS400 shirejissekias400 = new D0690_SiireJissekiKakuninAS400.D0690_SiireJissekiKakuninAS400(this);
                        shirejissekias400.ShowDialog();
                        break;

                    case "92":
                        //日付制限
                        G0920_HidukeSeigen.G0920_HidukeSeigen hidukeseigen = new G0920_HidukeSeigen.G0920_HidukeSeigen(this);
                        hidukeseigen.ShowDialog();
                        break;

                    case "100":
                        //会社条件
                        M1000_Kaishajyoken.M1000_Kaishajyoken kaisyajoken = new M1000_Kaishajyoken.M1000_Kaishajyoken(this);
                        kaisyajoken.ShowDialog();
                        break;

                    case "101 ":
                        //大分類
                        M1010_Daibunrui.M1010_Daibunrui daibunrui = new M1010_Daibunrui.M1010_Daibunrui(this);
                        daibunrui.ShowDialog();
                        break;

                    case "102":
                        //メーカー
                        M1020_Maker.M1020_Maker maker = new M1020_Maker.M1020_Maker(this);
                        maker.ShowDialog();
                        break;

                    case "103":
                        //商品
                        M1030_Shohin.M1030_Shohin shohin = new M1030_Shohin.M1030_Shohin(this);
                        shohin.ShowDialog();
                        break;

                    case "104":
                        //取引区分
                        M1040_Torihikikbn.M1040_Torihikikbn torihikikbn = new M1040_Torihikikbn.M1040_Torihikikbn(this);
                        torihikikbn.ShowDialog();
                        break;

                    case "105":
                        //担当者
                        M1050_Tantousha.M1050_Tantousha tantosha = new M1050_Tantousha.M1050_Tantousha(this);
                        tantosha.ShowDialog();
                        break;

                    case "106":
                        //業種
                        M1060_Gyoushu.M1060_Gyoshu gyoshu = new M1060_Gyoushu.M1060_Gyoshu(this);
                        gyoshu.ShowDialog();
                        break;

                    case "107":
                        //取引先
                        M1070_Torihikisaki.M1070_Torihikisaki torihikisaki = new M1070_Torihikisaki.M1070_Torihikisaki(this);
                        torihikisaki.ShowDialog();
                        break;

                    case "109":
                        //営業所
                        M1090_Eigyosho.M1090_Eigyosho eigyosho = new M1090_Eigyosho.M1090_Eigyosho(this);
                        eigyosho.ShowDialog();
                        break;

                    case "110":
                        //直送先
                        M1100_Chokusosaki.M1100_Chokusosaki chokusosaki = new M1100_Chokusosaki.M1100_Chokusosaki(this);
                        chokusosaki.ShowDialog();
                        break;

                    case "111":
                        //中分類
                        M1110_Chubunrui.M1110_Chubunrui chubunrui = new M1110_Chubunrui.M1110_Chubunrui(this);
                        chubunrui.ShowDialog();
                        break;

                    case "112":
                        //棚番
                        M1120_Tanaban.M1120_Tanaban tanaban = new M1120_Tanaban.M1120_Tanaban(this);
                        tanaban.ShowDialog();
                        break;

                    case "113":
                        //消費税率
                        M1130_Shohizeiritsu.M1130_Shohizeiritsu shohizeiritsu = new M1130_Shohizeiritsu.M1130_Shohizeiritsu(this);
                        shohizeiritsu.ShowDialog();
                        break;

                    case "115":
                        //商品マスタ単価一括更新
                        M1150_ShohinTankaIkkatsuUpdate.M1150_ShohinTankaIkkatsuUpdate shohintankaupdate = new M1150_ShohinTankaIkkatsuUpdate.M1150_ShohinTankaIkkatsuUpdate(this);
                        shohintankaupdate.ShowDialog();
                        break;

                    case "116":
                        //特定向先単価マスタ
                        M1160_TokuteimukesakiTanka.M1160_TokuteimukesakiTanka tokuteitankamaster = new M1160_TokuteimukesakiTanka.M1160_TokuteimukesakiTanka(this);
                        tokuteitankamaster.ShowDialog();
                        break;

                    case "120":
                        //グループマスタ
                        M1200_Group.M1200_Group group = new M1200_Group.M1200_Group(this);
                        group.ShowDialog();
                        break;

                    case "121":
                        //商品分類別利益率設定
                        M1210_ShohinbetsuRiekiritsuSettei.M1210_ShohinbetsuRiekiritsuSettei shohinbunruirieki = new M1210_ShohinbetsuRiekiritsuSettei.M1210_ShohinbetsuRiekiritsuSettei(this);
                        shohinbunruirieki.ShowDialog();
                        break;

                    case "122":
                        //商品別利益率設定
                        M1220_SyohinBunruiRiekiritsu.M1220_SyohinBunruiRiekiritsu shohinbeturieki = new M1220_SyohinBunruiRiekiritsu.M1220_SyohinBunruiRiekiritsu(this);
                        shohinbeturieki.ShowDialog();
                        break;

                    case "600":
                        //担当者別伝票処理件数
                        C6000_TantoshabetuDenpyoCount.C6000_TantoshabetuDenpyoCount tantoshabetusyori = new C6000_TantoshabetuDenpyoCount.C6000_TantoshabetuDenpyoCount(this);
                        tantoshabetusyori.ShowDialog();
                        break;

                    case "124":
                        //商品仕入単価推移表2
                        M1240_ShohinSiireKakakuSuii2.M1240_ShohinSiireKakakuSuii2 shohintankasuii2 = new M1240_ShohinSiireKakakuSuii2.M1240_ShohinSiireKakakuSuii2(this);
                        shohintankasuii2.ShowDialog();
                        break;

                    default:
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "指定のPG番号はマイメニューに設定されていません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        break;
                }

                //空白にする
                txtShoriNo.Text = "";
                txtShoriNo.Focus();
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
}
