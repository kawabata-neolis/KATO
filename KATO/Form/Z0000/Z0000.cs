﻿using System;
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
            M1050_Tantousha.M1050_Tantousha tori = new M1050_Tantousha.M1050_Tantousha(this);
            tori.ShowDialog();
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

        private void btnZanKakunin_Click(object sender, EventArgs e)
        {
            D0360_JuchuzanKakunin.D0360_JuchuzanKakunin zan = new D0360_JuchuzanKakunin.D0360_JuchuzanKakunin(this);
            zan.ShowDialog();
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

    }
}