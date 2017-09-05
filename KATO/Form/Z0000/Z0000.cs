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
using KATO.Common.Util;
using KATO.Form;
using static KATO.Common.Util.CommonTeisu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Permissions;

namespace KATO.Form.Z0000
{

    public partial class Z0000 : BaseForm
    {
        public Z0000()
        {
            InitializeComponent();
        }

        private void Z0000_Load(object sender, EventArgs e)
        {
            this.btnF12.Text = STR_FUNC_F12;

            //TabControlをオーナードローする
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            //DrawItemイベントハンドラを追加
            tabControl1.DrawItem += new DrawItemEventHandler(TabControl1_DrawItem);
        }

        //TabControl1のDrawItemイベントハンドラ
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

        ////大分類表示
        //private void btnDaibunrui_Click(object sender, EventArgs e)
        //{
        //    M1010_Daibunrui.M1010_Daibunrui daibun = new M1010_Daibunrui.M1010_Daibunrui(this);
        //    daibun.ShowDialog();
        //}

        ////中分類表示
        //private void btnChubunrui_Click(object sender, EventArgs e)
        //{
        //    M1110_Chubunrui.M1110_Chubunrui chubun = new M1110_Chubunrui.M1110_Chubunrui(this);
        //    chubun.ShowDialog();
        //}

        ////メーカー表示
        //private void btnMaker_Click(object sender, EventArgs e)
        //{
        //    M1020_Maker.M1020_Maker maker = new M1020_Maker.M1020_Maker(this);
        //    maker.ShowDialog();
        //}

        ////棚卸入力表示
        //private void btnTanaInput_Click(object sender, EventArgs e)
        //{
        //    F0140_TanaorosiInput.F0140_TanaorosiInput tana = new F0140_TanaorosiInput.F0140_TanaorosiInput(this);
        //    tana.ShowDialog();
        //}

        ////取引区分表示
        //private void btnTorihikikubun_Click(object sender, EventArgs e)
        //{
        //    M1040_Torihikikbn.M1040_Torihikikbn tori = new M1040_Torihikikbn.M1040_Torihikikbn(this);
        //    tori.ShowDialog();
        //}

        ////担当者表示
        //private void btnTantousha_Click(object sender, EventArgs e)
        //{
        //    M1050_Tantousha.M1050_Tantousha tantou = new M1050_Tantousha.M1050_Tantousha(this);
        //    tantou.ShowDialog();
        //}

        ////業種表示
        //private void btnGyoushu_Click(object sender, EventArgs e)
        //{
        //    M1060_Gyoushu.M1060_Gyoshu gyoushu = new M1060_Gyoushu.M1060_Gyoshu(this);
        //    gyoushu.ShowDialog();
        //}

        ////商品表示
        //private void btnShohin_Click(object sender, EventArgs e)
        //{
        //    M1030_Shohin.M1030_Shohin shohin = new M1030_Shohin.M1030_Shohin(this);
        //    shohin.ShowDialog();
        //}

        ////取引先表示
        //private void btnTorihikisaki_Click(object sender, EventArgs e)
        //{
        //    M1070_Torihikisaki.M1070_Torihikisaki torihiki = new M1070_Torihikisaki.M1070_Torihikisaki(this);
        //    torihiki.ShowDialog();
        //}

        ////営業所表示
        //private void btnEigyosho_Click(object sender, EventArgs e)
        //{
        //    M1090_Eigyosho.M1090_Eigyosho eigyosho = new M1090_Eigyosho.M1090_Eigyosho(this);
        //    eigyosho.ShowDialog();
        //}

        ////直送先表示
        //private void btnChokusosaki_Click(object sender, EventArgs e)
        //{
        //    M1100_Chokusosaki.M1100_Chokusosaki chokusosaki = new M1100_Chokusosaki.M1100_Chokusosaki(this);
        //    chokusosaki.ShowDialog();
        //}

        ////棚番表示
        //private void btnTanaban_Click(object sender, EventArgs e)
        //{
        //    M1120_Tanaban.M1120_Tanaban tanaban = new M1120_Tanaban.M1120_Tanaban(this);
        //    tanaban.ShowDialog();
        //}

        ////消費税率表示
        //private void btnShohizeiritu_Click(object sender, EventArgs e)
        //{
        //    M1130_Shohizeiritsu.M1130_Shohizeiritsu shohizeiritu = new M1130_Shohizeiritsu.M1130_Shohizeiritsu(this);
        //    shohizeiritu.ShowDialog();
        //}

        ////グループマスタ表示
        //private void btnGroup_Click(object sender, EventArgs e)
        //{
        //    M1200_Group.M1200_Group group = new M1200_Group.M1200_Group(this);
        //    group.ShowDialog();
        //}

        ////受注入力（共通部品テスト用）表示
        //private void baseMenuButton6_Click(object sender, EventArgs e)
        //{
        //    JuchuInput.JuchuInput_Test juchu = new JuchuInput.JuchuInput_Test(this);

        //    //メニュー非表示関係の残り（参考）
        //    //juchu.AddOwnedForm(this);

        //    juchu.ShowDialog();

        //    //メニュー非表示関係の残り（参考）
        //    //juchu.Show();
        //    //this.Hide();
        //}

        ////商品元帳確認
        //private void btnShohinMotochoKakunin_Click(object sender, EventArgs e)
        //{
        //    D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin shohinmotoshokakunin = new D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin(this);
        //    shohinmotoshokakunin.ShowDialog();
        //}

        ////発注入力
        //private void btnHachuInput_Click(object sender, EventArgs e)
        //{
        //    A0100_HachuInput.A0100_HachuInput hachuinput = new A0100_HachuInput.A0100_HachuInput(this);
        //    hachuinput.ShowDialog();
        //}

        //private void btnZanKakunin_Click(object sender, EventArgs e)
        //{
        //    D0360_JuchuzanKakunin.D0360_JuchuzanKakunin zan = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this);
        //    zan.ShowDialog();
        //}

        //private void btnJuchuInput_Click(object sender, EventArgs e)
        //{
        //}

        //// 分類別仕入推移表
        //private void btnSiireSuiiHyo_Click(object sender, EventArgs e)
        //{
        //    C0480_SiireSuiiHyo.C0480_SiireSuiiHyo siireHyo = new C0480_SiireSuiiHyo.C0480_SiireSuiiHyo(this);
        //    siireHyo.ShowDialog();
        //}

        //// 分類別売上推移表
        //private void btnUriageSuiiHyo_Click(object sender, EventArgs e)
        //{
        //    C0490_UriageSuiiHyo.C0490_UriageSuiiHyo uriHyo = new C0490_UriageSuiiHyo.C0490_UriageSuiiHyo(this);
        //    uriHyo.ShowDialog();
        //}

        //// 発注数変更
        //private void btnHachusuhenko_Click(object sender, EventArgs e)
        //{
        //    A0470_Hachusuhenko.A0470_Hachusuhenko hachusuhenko = new A0470_Hachusuhenko.A0470_Hachusuhenko(this);
        //    hachusuhenko.ShowDialog();
        //}

        //// 発注数変更
        //private void btnShireInput_Click(object sender, EventArgs e)
        //{
        //    A0030_ShireInput.A0030_ShireInput shireinput = new A0030_ShireInput.A0030_ShireInput(this);
        //    shireinput.ShowDialog();
        //}

        ////  会社条件
        //private void btnKaishajoken_Click(object sender, EventArgs e)
        //{
        //    M1000_Kaishajyoken.M1000_Kaishajyoken kaishajoken = new M1000_Kaishajyoken.M1000_Kaishajyoken(this);
        //    kaishajoken.ShowDialog();
        //}

        //// 封書宛名印刷
        //private void btnHushoAtena_Click(object sender, EventArgs e)
        //{
        //    M0620_HushoAtenaInsatsu.M0620_HushoAtenaInsatsu hushoatena = new M0620_HushoAtenaInsatsu.M0620_HushoAtenaInsatsu(this);
        //    hushoatena.ShowDialog();
        //}

        //// 担当者別伝票処理件数
        //private void btnTantoshabetudenpyo_Click(object sender, EventArgs e)
        //{
        //    C6000_TantoshabetuDenpyoCount.C6000_TantoshabetuDenpyoCount tantoshabetudenpyo = new C6000_TantoshabetuDenpyoCount.C6000_TantoshabetuDenpyoCount(this);
        //    tantoshabetudenpyo.ShowDialog();
        //}


        //F12が押されたら
        private void judF12Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //キーが押されたら
        private void judKeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.F12:
                    this.Close();
                    break;
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

        //private void baseMenuButton2_Click(object sender, EventArgs e)
        //{
        //    D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin siire = new D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin(this);
        //    siire.ShowDialog();
        //}

        //private void baseMenuButton3_Click(object sender, EventArgs e)
        //{
        //}

        //private void baseMenuButton4_Click(object sender, EventArgs e)
        //{
        //    M1150_ShohinTankaIkkatsuUpdate.M1150_ShohinTankaIkkatsuUpdate shohin = new M1150_ShohinTankaIkkatsuUpdate.M1150_ShohinTankaIkkatsuUpdate(this);
        //    shohin.ShowDialog();
        //}

        //private void baseMenuButton5_Click(object sender, EventArgs e)
        //{
        //    B0060_ShiharaiInput.B0060_ShiharaiInput shiharai = new B0060_ShiharaiInput.B0060_ShiharaiInput(this);
        //    shiharai.ShowDialog();
        //}

        //private void baseMenuButton6_Click_1(object sender, EventArgs e)
        //{
        //    M1220_SyohinBunruiRiekiritsu.M1220_SyohinBunruiRiekiritsu shohin = new M1220_SyohinBunruiRiekiritsu.M1220_SyohinBunruiRiekiritsu(this);
        //    shohin.ShowDialog();
        //}

        //private void baseMenuButton7_Click(object sender, EventArgs e)
        //{
        //    G0920_HidukeSeigen.G0920_HidukeSeigen hiduke = new G0920_HidukeSeigen.G0920_HidukeSeigen(this);
        //    hiduke.ShowDialog();
        //}

        //private void baseMenuButton8_Click(object sender, EventArgs e)
        //{
        //    D0690_SiireJissekiKakuninAS400.D0690_SiireJissekiKakuninAS400 siire = new D0690_SiireJissekiKakuninAS400.D0690_SiireJissekiKakuninAS400(this);
        //    siire.ShowDialog();
        //}

        //private void baseMenuButton3_Click_1(object sender, EventArgs e)
        //{
        //}

        //private void baseMenuButton9_Click(object sender, EventArgs e)
        //{
        //    E0340_SiiresakiMotochouKakunin.E0340_SiiresakiMotochouKakunin siire = new E0340_SiiresakiMotochouKakunin.E0340_SiiresakiMotochouKakunin(this);
        //    siire.ShowDialog();
        //}

        //private void baseMenuButton10_Click(object sender, EventArgs e)
        //{
        //    A0150_UriageCheckPrint.A0150_UriageCheckPrint uriage = new A0150_UriageCheckPrint.A0150_UriageCheckPrint(this);
        //    uriage.ShowDialog();
        //}

        //private void baseMenuButton11_Click(object sender, EventArgs e)
        //{
        //    D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin uriage = new D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, 0 , "", "");
        //    uriage.ShowDialog();
        //}

        //private void baseMenuButton12_Click(object sender, EventArgs e)
        //{
        //    D0300_ZaikoIchiranKakunin.D0300_ZaikoIchiranKakunin zaiko = new D0300_ZaikoIchiranKakunin.D0300_ZaikoIchiranKakunin(this);
        //    zaiko.ShowDialog();
        //}

        //private void baseMenuButton13_Click(object sender, EventArgs e)
        //{
        //    C0530_UriageArariSuiihyoPrint.C0530_UriageArariSuiihyoPrint uriage = new C0530_UriageArariSuiihyoPrint.C0530_UriageArariSuiihyoPrint(this);
        //    uriage.ShowDialog();
        //}

        //private void baseMenuButton14_Click(object sender, EventArgs e)
        //{
        //}

        //private void baseMenuButton15_Click(object sender, EventArgs e)
        //{
        //    B0070_ShiharaiCheakPrint.B0070_ShiharaiCheakPrint shiharai = new B0070_ShiharaiCheakPrint.B0070_ShiharaiCheakPrint(this);
        //    shiharai.ShowDialog();
        //}

        //private void baseMenuButton16_Click(object sender, EventArgs e)
        //{
        //    B0420_SeikyuMeisaishoPrint.B0420_SeikyuMeisaishoPrint seikyu = new B0420_SeikyuMeisaishoPrint.B0420_SeikyuMeisaishoPrint(this);
        //    seikyu.ShowDialog();
        //}

        //private void baseMenuButton17_Click(object sender, EventArgs e)
        //{
        //    B0410_SeikyuItiranPrint.B0410_SeikyuItiranPrint seikyuu = new B0410_SeikyuItiranPrint.B0410_SeikyuItiranPrint(this);
        //    seikyuu.ShowDialog();
        //}

        //private void baseMenuButton18_Click(object sender, EventArgs e)
        //{
        //    E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin tokuisakimototyoukakunin = new E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin(this, 0, "");
        //    tokuisakimototyoukakunin.ShowDialog();
        //}

        //private void baseMenuButton19_Click(object sender, EventArgs e)
        //{
        //    C0650_SyohingunUriageSiirePrint.C0650_SyohingunUriageSiirePrint uriageriekiritu = new C0650_SyohingunUriageSiirePrint.C0650_SyohingunUriageSiirePrint(this);
        //    uriageriekiritu.ShowDialog();
        //}

        //private void baseMenuButton21_Click(object sender, EventArgs e)
        //{
        //    M1210_ShohinbetsuRiekiritsuSettei.M1210_ShohinbetsuRiekiritsuSettei uriageriekiritu = new M1210_ShohinbetsuRiekiritsuSettei.M1210_ShohinbetsuRiekiritsuSettei(this);
        //    uriageriekiritu.ShowDialog();
        //}

        //private void baseMenuButton22_Click(object sender, EventArgs e)
        //{
        //    M1160_TokuteimukesakiTanka.M1160_TokuteimukesakiTanka tokuteimukesakitankamasuta = new M1160_TokuteimukesakiTanka.M1160_TokuteimukesakiTanka(this);
        //    tokuteimukesakitankamasuta.ShowDialog();
        //}

        //private void baseMenuButton23_Click(object sender, EventArgs e)
        //{
        //    D0680_UriageJissekiKakuninAS400.D0680_UriageJissekiKakuninAS400 uriageAS400 = new D0680_UriageJissekiKakuninAS400.D0680_UriageJissekiKakuninAS400(this);
        //    uriageAS400.ShowDialog();
        //}

        //private void baseMenuButton24_Click(object sender, EventArgs e)
        //{
        //    C0130_TantouUriageArariPrint.C0130_TantouUriageArariPrint uriage = new C0130_TantouUriageArariPrint.C0130_TantouUriageArariPrint(this);
        //    uriage.ShowDialog();
        //}

        //private void baseMenuButton20_Click(object sender, EventArgs e)
        //{
        //    B0040_NyukinInput.B0040_NyukinInput nyukin = new B0040_NyukinInput.B0040_NyukinInput(this);
        //    nyukin.ShowDialog();
        //}

        //private void baseMenuButton25_Click(object sender, EventArgs e)
        //{
        //    F0570_TanaorosiKinyuhyoPrint.F0570_TanaorosiKinyuhyoPrint preSheet = new F0570_TanaorosiKinyuhyoPrint.F0570_TanaorosiKinyuhyoPrint(this);
        //    preSheet.ShowDialog();
        //}

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

                case "マイメニュー":
                    Z1500_MyMenuSet.Z1500_MyMenuSet mymenu = new Z1500_MyMenuSet.Z1500_MyMenuSet(this);
                    mymenu.ShowDialog();
                    break;
            }
        }
    }
}
