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

            this.btnF12.Text = STR_FUNC_F12;
        }

        private void Z0000_Load(object sender, EventArgs e)
        {
            this.btnDaibunrui.Focus();

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

        //大分類表示
        private void btnDaibunrui_Click(object sender, EventArgs e)
        {
            M1010_Daibunrui.M1010_Daibunrui daibun = new M1010_Daibunrui.M1010_Daibunrui(this);
            daibun.ShowDialog();
        }

        //中分類表示
        private void btnChubunrui_Click(object sender, EventArgs e)
        {
            M1110_Chubunrui.M1110_Chubunrui chubun = new M1110_Chubunrui.M1110_Chubunrui(this);
            chubun.ShowDialog();
        }

        //メーカー表示
        private void btnMaker_Click(object sender, EventArgs e)
        {
            M1020_Maker.M1020_Maker maker = new M1020_Maker.M1020_Maker(this);
            maker.ShowDialog();
        }

        //棚卸入力表示
        private void btnTanaInput_Click(object sender, EventArgs e)
        {
            F0140_TanaorosiInput.F0140_TanaorosiInput tana = new F0140_TanaorosiInput.F0140_TanaorosiInput(this);
            tana.ShowDialog();
        }

        //取引区分表示
        private void btnTorihikikubun_Click(object sender, EventArgs e)
        {
            M1040_Torihikikbn.M1040_Torihikikbn tori = new M1040_Torihikikbn.M1040_Torihikikbn(this);
            tori.ShowDialog();
        }

        //担当者表示
        private void btnTantousha_Click(object sender, EventArgs e)
        {
            M1050_Tantousha.M1050_Tantousha tantou = new M1050_Tantousha.M1050_Tantousha(this);
            tantou.ShowDialog();
        }

        //業種表示
        private void btnGyoushu_Click(object sender, EventArgs e)
        {
            M1060_Gyoushu.M1060_Gyoshu gyoushu = new M1060_Gyoushu.M1060_Gyoshu(this);
            gyoushu.ShowDialog();
        }

        //商品表示
        private void btnShohin_Click(object sender, EventArgs e)
        {
            M1030_Shohin.M1030_Shohin shohin = new M1030_Shohin.M1030_Shohin(this);
            shohin.ShowDialog();
        }

        //取引先表示
        private void btnTorihikisaki_Click(object sender, EventArgs e)
        {
            M1070_Torihikisaki.M1070_Torihikisaki torihiki = new M1070_Torihikisaki.M1070_Torihikisaki(this);
            torihiki.ShowDialog();
        }

        //営業所表示
        private void btnEigyosho_Click(object sender, EventArgs e)
        {
            M1090_Eigyosho.M1090_Eigyosho eigyosho = new M1090_Eigyosho.M1090_Eigyosho(this);
            eigyosho.ShowDialog();
        }

        //直送先表示
        private void btnChokusosaki_Click(object sender, EventArgs e)
        {
            M1100_Chokusosaki.M1100_Chokusosaki chokusosaki = new M1100_Chokusosaki.M1100_Chokusosaki(this);
            chokusosaki.ShowDialog();
        }

        //棚番表示
        private void btnTanaban_Click(object sender, EventArgs e)
        {
            M1120_Tanaban.M1120_Tanaban tanaban = new M1120_Tanaban.M1120_Tanaban(this);
            tanaban.ShowDialog();
        }

        //消費税率表示
        private void btnShohizeiritu_Click(object sender, EventArgs e)
        {
            M1130_Shohizeiritsu.M1130_Shohizeiritsu shohizeiritu = new M1130_Shohizeiritsu.M1130_Shohizeiritsu(this);
            shohizeiritu.ShowDialog();
        }

        //グループマスタ表示
        private void btnGroup_Click(object sender, EventArgs e)
        {
            M1200_Group.M1200_Group group = new M1200_Group.M1200_Group(this);
            group.ShowDialog();
        }

        //受注入力（共通部品テスト用）表示
        private void baseMenuButton6_Click(object sender, EventArgs e)
        {
            JuchuInput.JuchuInput_Test juchu = new JuchuInput.JuchuInput_Test(this);

            //メニュー非表示関係の残り（参考）
            //juchu.AddOwnedForm(this);

            juchu.ShowDialog();

            //メニュー非表示関係の残り（参考）
            //juchu.Show();
            //this.Hide();
        }

        //商品元帳確認
        private void btnShohinMotochoKakunin_Click(object sender, EventArgs e)
        {
            D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin shohinmotoshokakunin = new D0380_ShohinMotochoKakunin.D0380_ShohinMotochoKakunin(this);
            shohinmotoshokakunin.ShowDialog();
        }

        //発注入力
        private void btnHachuInput_Click(object sender, EventArgs e)
        {
            A0100_HachuInput.A0100_HachuInput hachuinput = new A0100_HachuInput.A0100_HachuInput(this);
            hachuinput.ShowDialog();
        }

        private void btnZanKakunin_Click(object sender, EventArgs e)
        {
            D0360_JuchuzanKakunin.D0360_JuchuzanKakunin zan = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this);
            zan.ShowDialog();
        }

        private void btnJuchuInput_Click(object sender, EventArgs e)
        {
            A0010_JuchuInput.A0010_JuchuInput juchuinput = new A0010_JuchuInput.A0010_JuchuInput(this);
            juchuinput.ShowDialog();
        }

        // 分類別仕入推移表
        private void btnSiireSuiiHyo_Click(object sender, EventArgs e)
        {
            C0480_SiireSuiiHyo.C0480_SiireSuiiHyo siireHyo = new C0480_SiireSuiiHyo.C0480_SiireSuiiHyo(this);
            siireHyo.ShowDialog();
        }

        // 分類別売上推移表
        private void btnUriageSuiiHyo_Click(object sender, EventArgs e)
        {
            C0490_UriageSuiiHyo.C0490_UriageSuiiHyo uriHyo = new C0490_UriageSuiiHyo.C0490_UriageSuiiHyo(this);
            uriHyo.ShowDialog();
        }

        // 発注数変更
        private void btnHachusuhenko_Click(object sender, EventArgs e)
        {
            A0470_Hachusuhenko.A0470_Hachusuhenko hachusuhenko = new A0470_Hachusuhenko.A0470_Hachusuhenko(this);
            hachusuhenko.ShowDialog();
        }

        // 発注数変更
        private void btnShireInput_Click(object sender, EventArgs e)
        {
            A0030_ShireInput.A0030_ShireInput shireinput = new A0030_ShireInput.A0030_ShireInput(this);
            shireinput.ShowDialog();
        }

        //  会社条件
        private void btnKaishajoken_Click(object sender, EventArgs e)
        {
            M1000_Kaishajyoken.M1000_Kaishajyoken kaishajoken = new M1000_Kaishajyoken.M1000_Kaishajyoken(this);
            kaishajoken.ShowDialog();
        }

        // 封書宛名印刷
        private void btnHushoAtena_Click(object sender, EventArgs e)
        {
            M0620_HushoAtenaInsatsu.M0620_HushoAtenaInsatsu hushoatena = new M0620_HushoAtenaInsatsu.M0620_HushoAtenaInsatsu(this);
            hushoatena.ShowDialog();
        }


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
            Common.Form.PrintForm pf = new Common.Form.PrintForm(this, @"G:\aaa.pdf", CommonTeisu.SIZE_A4, CommonTeisu.YOKO);
            try
            {
                pf.ShowDialog();
            }
            catch (Exception ex)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, ex.Message + "\r\n" + ex.StackTrace, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
            }
            pf.Dispose();
        }

        private void baseMenuButton2_Click(object sender, EventArgs e)
        {
            D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin siire = new D0320_SiireJissekiKakunin.D0320_SiireJissekiKakunin(this);
            siire.ShowDialog();
        }

        private void baseMenuButton3_Click(object sender, EventArgs e)
        {
            A0090_SiireCheakPrint.A0090_SiireCheakPrint siirecheak = new A0090_SiireCheakPrint.A0090_SiireCheakPrint(this);
            siirecheak.ShowDialog();
        }

        private void baseMenuButton4_Click(object sender, EventArgs e)
        {
            M1150_ShohinTankaIkkatsuUpdate.M1150_ShohinTankaIkkatsuUpdate shohin = new M1150_ShohinTankaIkkatsuUpdate.M1150_ShohinTankaIkkatsuUpdate(this);
            shohin.ShowDialog();
        }

        private void baseMenuButton5_Click(object sender, EventArgs e)
        {
            B0060_ShiharaiInput.B0060_ShiharaiInput shiharai = new B0060_ShiharaiInput.B0060_ShiharaiInput(this);
            shiharai.ShowDialog();
        }

        private void baseMenuButton6_Click_1(object sender, EventArgs e)
        {
            M1220_SyohinBunruiRiekiritsu.M1220_SyohinBunruiRiekiritsu shohin = new M1220_SyohinBunruiRiekiritsu.M1220_SyohinBunruiRiekiritsu(this);
            shohin.ShowDialog();
        }

        private void baseMenuButton7_Click(object sender, EventArgs e)
        {
            G0920_HidukeSeigen.G0920_HidukeSeigen hiduke = new G0920_HidukeSeigen.G0920_HidukeSeigen(this);
            hiduke.ShowDialog();
        }

        private void baseMenuButton8_Click(object sender, EventArgs e)
        {
            D0690_SiireJissekiKakuninAS400.D0690_SiireJissekiKakuninAS400 siire = new D0690_SiireJissekiKakuninAS400.D0690_SiireJissekiKakuninAS400(this);
            siire.ShowDialog();
        }

        private void baseMenuButton3_Click_1(object sender, EventArgs e)
        {
            A0090_SiireCheakPrint.A0090_SiireCheakPrint siire = new A0090_SiireCheakPrint.A0090_SiireCheakPrint(this);
            siire.ShowDialog();
        }

        private void baseMenuButton9_Click(object sender, EventArgs e)
        {
            E0340_SiiresakiMotochouKakunin.E0340_SiiresakiMotochouKakunin siire = new E0340_SiiresakiMotochouKakunin.E0340_SiiresakiMotochouKakunin(this);
            siire.ShowDialog();
        }

        private void baseMenuButton10_Click(object sender, EventArgs e)
        {
            A0150_UriageCheckPrint.A0150_UriageCheckPrint uriage = new A0150_UriageCheckPrint.A0150_UriageCheckPrint(this);
            uriage.ShowDialog();
        }

        private void baseMenuButton11_Click(object sender, EventArgs e)
        {
            D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin uriage = new D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, 0 , "", "");
            uriage.ShowDialog();
        }

        private void baseMenuButton12_Click(object sender, EventArgs e)
        {
            D0300_ZaikoIchiranKakunin.D0300_ZaikoIchiranKakunin zaiko = new D0300_ZaikoIchiranKakunin.D0300_ZaikoIchiranKakunin(this);
            zaiko.ShowDialog();
        }

        private void baseMenuButton13_Click(object sender, EventArgs e)
        {
            C0530_UriageArariSuiihyoPrint.C0530_UriageArariSuiihyoPrint uriage = new C0530_UriageArariSuiihyoPrint.C0530_UriageArariSuiihyoPrint(this);
            uriage.ShowDialog();
        }

        private void baseMenuButton14_Click(object sender, EventArgs e)
        {
            B0050_NyukinCheakPrint.B0050_NyukinCheakPrint nyukin = new B0050_NyukinCheakPrint.B0050_NyukinCheakPrint(this);
            nyukin.ShowDialog();
        }

        private void baseMenuButton15_Click(object sender, EventArgs e)
        {
            B0070_ShiharaiCheakPrint.B0070_ShiharaiCheakPrint shiharai = new B0070_ShiharaiCheakPrint.B0070_ShiharaiCheakPrint(this);
            shiharai.ShowDialog();
        }

        private void baseMenuButton16_Click(object sender, EventArgs e)
        {
            B0420_SeikyuMeisaishoPrint.B0420_SeikyuMeisaishoPrint seikyu = new B0420_SeikyuMeisaishoPrint.B0420_SeikyuMeisaishoPrint(this);
            seikyu.ShowDialog();
        }

        private void baseMenuButton17_Click(object sender, EventArgs e)
        {
            B0410_SeikyuItiranPrint.B0410_SeikyuItiranPrint seikyuu = new B0410_SeikyuItiranPrint.B0410_SeikyuItiranPrint(this);
            seikyuu.ShowDialog();
        }

        private void baseMenuButton18_Click(object sender, EventArgs e)
        {
            E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin tokuisakimototyoukakunin = new E0330_TokuisakiMotocyoKakunin.E0330_TokuisakiMotocyoKakunin(this, 0, "");
            tokuisakimototyoukakunin.ShowDialog();
        }

        private void baseMenuButton19_Click(object sender, EventArgs e)
        {
            C0650_SyohingunUriageSiirePrint.C0650_SyohingunUriageSiirePrint uriageriekiritu = new C0650_SyohingunUriageSiirePrint.C0650_SyohingunUriageSiirePrint(this);
            uriageriekiritu.ShowDialog();
        }

        private void baseMenuButton21_Click(object sender, EventArgs e)
        {
            M1210_ShohinbetsuRiekiritsuSettei.M1210_ShohinbetsuRiekiritsuSettei uriageriekiritu = new M1210_ShohinbetsuRiekiritsuSettei.M1210_ShohinbetsuRiekiritsuSettei(this);
            uriageriekiritu.ShowDialog();
        }

        private void baseMenuButton22_Click(object sender, EventArgs e)
        {
            M1160_TokuteimukesakiTanka.M1160_TokuteimukesakiTanka tokuteimukesakitankamasuta = new M1160_TokuteimukesakiTanka.M1160_TokuteimukesakiTanka(this);
            tokuteimukesakitankamasuta.ShowDialog();
        }

        private void baseMenuButton23_Click(object sender, EventArgs e)
        {
            D0680_UriageJissekiKakuninAS400.D0680_UriageJissekiKakuninAS400 uriageAS400 = new D0680_UriageJissekiKakuninAS400.D0680_UriageJissekiKakuninAS400(this);
            uriageAS400.ShowDialog();
        }

        private void baseMenuButton24_Click(object sender, EventArgs e)
        {
            C0130_TantouUriageArariPrint.C0130_TantouUriageArariPrint uriage = new C0130_TantouUriageArariPrint.C0130_TantouUriageArariPrint(this);
            uriage.ShowDialog();
        }

        private void baseMenuButton20_Click(object sender, EventArgs e)
        {
            B0040_NyukinInput.B0040_NyukinInput nyukin = new B0040_NyukinInput.B0040_NyukinInput(this);
            nyukin.ShowDialog();
        }

        private void baseMenuButton25_Click(object sender, EventArgs e)
        {
            F0570_TanaorosiKinyuhyoPrint.F0570_TanaorosiKinyuhyoPrint preSheet = new F0570_TanaorosiKinyuhyoPrint.F0570_TanaorosiKinyuhyoPrint(this);
            preSheet.ShowDialog();
        }
    }
}
