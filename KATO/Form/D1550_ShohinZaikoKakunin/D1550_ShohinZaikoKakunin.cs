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
using KATO.Common.Form;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.D1550_ShohinZaikoKakunin
{
    ///<summary>
    ///D1550_ShohinZaikoKakunin
    ///商品在庫確認
    ///作成者：大河内
    ///作成日：2018/03/XX
    ///更新者：大河内
    ///更新日：2018/03/XX
    ///</summary>
    public partial class D1550_ShohinZaikoKakunin : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ///<summary>
        ///D1550_ShohinZaikoKakunin
        ///フォームの初期設定
        ///</summary>
        public D1550_ShohinZaikoKakunin(Control c)
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
        }

        ///<summary>
        ///D1550_ShohinZaikoKakunin_Load
        ///画面レイアウト設定
        ///</summary>
        private void D1550_ShohinZaikoKakunin_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品在庫確認";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = STR_FUNC_F12;

            //商品グリッドのセットアップ
            SetUpGridShohin();

            //商品グリッド入れる用(テスト)
            DataTable dtshohin = new DataTable();
            dtshohin.Columns.Add("メーカー", Type.GetType("System.String"));
            dtshohin.Columns.Add("中分類", Type.GetType("System.String"));
            dtshohin.Columns.Add("品名", Type.GetType("System.String"));
            dtshohin.Columns.Add("本社在庫", Type.GetType("System.String"));
            dtshohin.Columns.Add("本社ﾌﾘｰ", Type.GetType("System.String"));
            dtshohin.Columns.Add("岐阜在庫", Type.GetType("System.String"));
            dtshohin.Columns.Add("岐阜ﾌﾘｰ", Type.GetType("System.String"));
            dtshohin.Columns.Add("定価", Type.GetType("System.String"));
            dtshohin.Columns.Add("仕入単価", Type.GetType("System.String"));

            DataRow row1st = dtshohin.NewRow();
            row1st["メーカー"] = "KOYO";
            row1st["中分類"] = "深溝玉";
            row1st["品名"] = "6000 ZZCMGSR";
            row1st["本社在庫"] = "1,135";
            row1st["本社ﾌﾘｰ"] = "1,113";
            row1st["岐阜在庫"] = "";
            row1st["岐阜ﾌﾘｰ"] = "";
            row1st["定価"] = "620";
            row1st["仕入単価"] = "143";
            dtshohin.Rows.Add(row1st);

            DataRow row2nd = dtshohin.NewRow();
            row2nd["メーカー"] = "123456789A123456789B";
            row2nd["中分類"] = "123456789A";
            row2nd["品名"] = "6000 ZZCMGSR";
            row2nd["本社在庫"] = "1,135";
            row2nd["本社ﾌﾘｰ"] = "1,113";
            row2nd["岐阜在庫"] = "";
            row2nd["岐阜ﾌﾘｰ"] = "";
            row2nd["定価"] = "620";
            row2nd["仕入単価"] = "143";
            dtshohin.Rows.Add(row2nd);

            DataRow row3 = dtshohin.NewRow();
            row3["メーカー"] = "123456789A123456789B";
            row3["中分類"] = "深溝玉";
            row3["品名"] = "6000 ZZCMGSR";
            row3["本社在庫"] = "1,135";
            row3["本社ﾌﾘｰ"] = "1,113";
            row3["岐阜在庫"] = "";
            row3["岐阜ﾌﾘｰ"] = "";
            row3["定価"] = "620";
            row3["仕入単価"] = "143";
            dtshohin.Rows.Add(row3);

            DataRow row4 = dtshohin.NewRow();
            row4["メーカー"] = "123456789A123456789B";
            row4["中分類"] = "123456789A123456789B";
            row4["品名"] = "123456789A123456789B123456789C123456789D";
            row4["本社在庫"] = "10,000";
            row4["本社ﾌﾘｰ"] = "10,000";
            row4["岐阜在庫"] = "10,000";
            row4["岐阜ﾌﾘｰ"] = "10,000";
            row4["定価"] = "10,000,000";
            row4["仕入単価"] = "10,000,000";
            dtshohin.Rows.Add(row4);

            gridShohin.DataSource = dtshohin;

            
            //商品グリッドのセットアップ
            SetUpGridUriage();

            //商品グリッド入れる用(テスト)
            DataTable dtUriage = new DataTable();
            dtUriage.Columns.Add("日付", Type.GetType("System.String"));
            dtUriage.Columns.Add("得意先", Type.GetType("System.String"));
            dtUriage.Columns.Add("個数", Type.GetType("System.String"));
            dtUriage.Columns.Add("単価", Type.GetType("System.String"));

            DataRow row1u = dtUriage.NewRow();
            row1u["日付"] = "18/03/19";
            row1u["得意先"] = "123456789A123456789B123456789C";
            row1u["個数"] = "10,000";
            row1u["単価"] = "10,000,000";
            dtUriage.Rows.Add(row1u);

            DataRow row2u = dtUriage.NewRow();
            row2u["日付"] = "18/03/31";
            row2u["得意先"] = "(株)青山製作所 製造本部 大口工場";
            row2u["個数"] = "4";
            row2u["単価"] = "155";
            dtUriage.Rows.Add(row2u);

            gridUriage.DataSource = dtUriage;

            //商品グリッド入れる用(テスト)
            DataTable dtGetubetuU = new DataTable();
            dtGetubetuU.Columns.Add("年月", Type.GetType("System.String"));
            dtGetubetuU.Columns.Add("個数", Type.GetType("System.String"));
            dtGetubetuU.Columns.Add("平均単価", Type.GetType("System.String"));

            DataRow row1gu = dtGetubetuU.NewRow();
            row1gu["年月"] = "18/03";
            row1gu["個数"] = "10,000";
            row1gu["平均単価"] = "10,000,000";
            dtGetubetuU.Rows.Add(row1gu);

            gridGetubetuUriage.DataSource = dtGetubetuU;

            SetUpGridJuchuzan();
            SetUpGridHachuzan();
            SetUpGridShohinMotocho();
            SetUpGridShire();
            SetUpGridGetubetuUriage();


            SetUpGridGetubetuShire();
            SetUpGridShohinBetuTanka();

            lblsetHonTana.CodeTxtText = "A1A171";
            lblsetHonTana.chkTxtTanaban();
            lblsetGifuTana.CodeTxtText = "B1B000";
            lblsetGifuTana.chkTxtTanaban();

        }

        ///<summary>
        ///SetUpGridShohin
        ///DataGridView初期設定(商品)
        ///</summary>
        private void SetUpGridShohin()
        {
            //データをバインド
            DataGridViewTextBoxColumn Maker = new DataGridViewTextBoxColumn();
            Maker.DataPropertyName = "メーカー";
            Maker.Name = "メーカー";
            Maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn Chubun = new DataGridViewTextBoxColumn();
            Chubun.DataPropertyName = "中分類";
            Chubun.Name = "中分類";
            Chubun.HeaderText = "中分類";

            DataGridViewTextBoxColumn Hin = new DataGridViewTextBoxColumn();
            Hin.DataPropertyName = "品名";
            Hin.Name = "品名";
            Hin.HeaderText = "品名";

            DataGridViewTextBoxColumn HonZaiko = new DataGridViewTextBoxColumn();
            HonZaiko.DataPropertyName = "本社在庫";
            HonZaiko.Name = "本社在庫";
            HonZaiko.HeaderText = "本社在庫";

            DataGridViewTextBoxColumn HonFree = new DataGridViewTextBoxColumn();
            HonFree.DataPropertyName = "本社ﾌﾘｰ";
            HonFree.Name = "本社ﾌﾘｰ";
            HonFree.HeaderText = "本社ﾌﾘｰ";

            DataGridViewTextBoxColumn GifuZaiko = new DataGridViewTextBoxColumn();
            GifuZaiko.DataPropertyName = "岐阜在庫";
            GifuZaiko.Name = "岐阜在庫";
            GifuZaiko.HeaderText = "岐阜在庫";

            DataGridViewTextBoxColumn GifuFree = new DataGridViewTextBoxColumn();
            GifuFree.DataPropertyName = "岐阜ﾌﾘｰ";
            GifuFree.Name = "岐阜ﾌﾘｰ";
            GifuFree.HeaderText = "岐阜ﾌﾘｰ";

            DataGridViewTextBoxColumn Teka = new DataGridViewTextBoxColumn();
            Teka.DataPropertyName = "定価";
            Teka.Name = "定価";
            Teka.HeaderText = "定価";

            DataGridViewTextBoxColumn ShireTanka = new DataGridViewTextBoxColumn();
            ShireTanka.DataPropertyName = "仕入単価";
            ShireTanka.Name = "仕入単価";
            ShireTanka.HeaderText = "仕入単価";

            //個々の幅、文章の寄せ
            setColumngridShohin(Maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 180);
            setColumngridShohin(Chubun, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 180);
            setColumngridShohin(Hin, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 340);
            setColumngridShohin(HonZaiko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
            setColumngridShohin(HonFree, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
            setColumngridShohin(GifuZaiko, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
            setColumngridShohin(GifuFree, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
            setColumngridShohin(Teka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumngridShohin(ShireTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 100);
        }

        ///<summary>
        ///setColumngridShohin
        ///DataGridViewの内部設定(商品)
        ///</summary>
        private void setColumngridShohin(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridShohin.Columns.Add(col);
            if (gridShohin.Columns[col.Name] != null)
            {
                gridShohin.Columns[col.Name].Width = intLen;
                gridShohin.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridShohin.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridShohin.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///SetUpGridUriage
        ///DataGridView初期設定(売上)
        ///</summary>
        private void SetUpGridUriage()
        {
            //データをバインド
            DataGridViewTextBoxColumn Hiduke = new DataGridViewTextBoxColumn();
            Hiduke.DataPropertyName = "日付";
            Hiduke.Name = "日付";
            Hiduke.HeaderText = "日付";

            DataGridViewTextBoxColumn Tokuisaki = new DataGridViewTextBoxColumn();
            Tokuisaki.DataPropertyName = "得意先";
            Tokuisaki.Name = "得意先";
            Tokuisaki.HeaderText = "得意先";

            DataGridViewTextBoxColumn Kosu = new DataGridViewTextBoxColumn();
            Kosu.DataPropertyName = "個数";
            Kosu.Name = "個数";
            Kosu.HeaderText = "個数";

            DataGridViewTextBoxColumn Tanka = new DataGridViewTextBoxColumn();
            Tanka.DataPropertyName = "単価";
            Tanka.Name = "単価";
            Tanka.HeaderText = "単価";

            //個々の幅、文章の寄せ
            setColumngridUriage(Hiduke, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumngridUriage(Tokuisaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 320);
            setColumngridUriage(Kosu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
            setColumngridUriage(Tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
        }

        ///<summary>
        ///setColumngridUriage
        ///DataGridViewの内部設定(売上)
        ///</summary>
        private void setColumngridUriage(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridUriage.Columns.Add(col);
            if (gridUriage.Columns[col.Name] != null)
            {
                gridUriage.Columns[col.Name].Width = intLen;
                gridUriage.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridUriage.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridUriage.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///SetUpGridJuchuzan
        ///DataGridView初期設定(受注残)
        ///</summary>
        private void SetUpGridJuchuzan()
        {
            //データをバインド
            DataGridViewTextBoxColumn Juchubi = new DataGridViewTextBoxColumn();
            Juchubi.DataPropertyName = "受注日";
            Juchubi.Name = "受注日";
            Juchubi.HeaderText = "受注日";

            DataGridViewTextBoxColumn Noki = new DataGridViewTextBoxColumn();
            Noki.DataPropertyName = "納期";
            Noki.Name = "納期";
            Noki.HeaderText = "納期";

            DataGridViewTextBoxColumn Torihikisaki = new DataGridViewTextBoxColumn();
            Torihikisaki.DataPropertyName = "取引先";
            Torihikisaki.Name = "取引先";
            Torihikisaki.HeaderText = "取引先";

            DataGridViewTextBoxColumn Kosu = new DataGridViewTextBoxColumn();
            Kosu.DataPropertyName = "個数";
            Kosu.Name = "個数";
            Kosu.HeaderText = "個数";

            DataGridViewTextBoxColumn Tanka = new DataGridViewTextBoxColumn();
            Tanka.DataPropertyName = "単価";
            Tanka.Name = "単価";
            Tanka.HeaderText = "単価";

            //個々の幅、文章の寄せ
            setColumngridJuchuzan(Juchubi, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumngridJuchuzan(Noki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumngridJuchuzan(Torihikisaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 320);
            setColumngridJuchuzan(Kosu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
            setColumngridJuchuzan(Tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
        }

        ///<summary>
        ///setColumngridJuchuzan
        ///DataGridViewの内部設定(受注残)
        ///</summary>
        private void setColumngridJuchuzan(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridJuchuZan.Columns.Add(col);
            if (gridJuchuZan.Columns[col.Name] != null)
            {
                gridJuchuZan.Columns[col.Name].Width = intLen;
                gridJuchuZan.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridJuchuZan.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridJuchuZan.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///SetUpGridHachuzan
        ///DataGridView初期設定(受注残)
        ///</summary>
        private void SetUpGridHachuzan()
        {
            //データをバインド
            DataGridViewTextBoxColumn Juchubi = new DataGridViewTextBoxColumn();
            Juchubi.DataPropertyName = "受注日";
            Juchubi.Name = "受注日";
            Juchubi.HeaderText = "受注日";

            DataGridViewTextBoxColumn Noki = new DataGridViewTextBoxColumn();
            Noki.DataPropertyName = "納期";
            Noki.Name = "納期";
            Noki.HeaderText = "納期";

            DataGridViewTextBoxColumn Torihikisaki = new DataGridViewTextBoxColumn();
            Torihikisaki.DataPropertyName = "取引先";
            Torihikisaki.Name = "取引先";
            Torihikisaki.HeaderText = "取引先";

            DataGridViewTextBoxColumn Kosu = new DataGridViewTextBoxColumn();
            Kosu.DataPropertyName = "個数";
            Kosu.Name = "個数";
            Kosu.HeaderText = "個数";

            DataGridViewTextBoxColumn Tanka = new DataGridViewTextBoxColumn();
            Tanka.DataPropertyName = "単価";
            Tanka.Name = "単価";
            Tanka.HeaderText = "単価";

            //個々の幅、文章の寄せ
            setColumngridHachuzan(Juchubi, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumngridHachuzan(Noki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumngridHachuzan(Torihikisaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 320);
            setColumngridHachuzan(Kosu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
            setColumngridHachuzan(Tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
        }

        ///<summary>
        ///setColumngridJuchuzan
        ///DataGridViewの内部設定(受注残)
        ///</summary>
        private void setColumngridHachuzan(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridHachuZan.Columns.Add(col);
            if (gridHachuZan.Columns[col.Name] != null)
            {
                gridHachuZan.Columns[col.Name].Width = intLen;
                gridHachuZan.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridHachuZan.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridHachuZan.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///SetUpGridShohinMotocho
        ///DataGridView初期設定(商品元帳)
        ///</summary>
        private void SetUpGridShohinMotocho()
        {
            //データをバインド
            DataGridViewTextBoxColumn Hiduke = new DataGridViewTextBoxColumn();
            Hiduke.DataPropertyName = "日付";
            Hiduke.Name = "日付";
            Hiduke.HeaderText = "日付";

            DataGridViewTextBoxColumn kubun = new DataGridViewTextBoxColumn();
            kubun.DataPropertyName = "区分";
            kubun.Name = "区分";
            kubun.HeaderText = "区分";

            DataGridViewTextBoxColumn Basho = new DataGridViewTextBoxColumn();
            Basho.DataPropertyName = "場所";
            Basho.Name = "場所";
            Basho.HeaderText = "場所";

            DataGridViewTextBoxColumn Kosu = new DataGridViewTextBoxColumn();
            Kosu.DataPropertyName = "個数";
            Kosu.Name = "個数";
            Kosu.HeaderText = "個数";

            //個々の幅、文章の寄せ
            setColumngridShohinMotocho(Hiduke, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumngridShohinMotocho(kubun, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumngridShohinMotocho(Basho, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 320);
            setColumngridShohinMotocho(Kosu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
        }

        ///<summary>
        ///setColumngridShohinMotocho
        ///DataGridViewの内部設定(商品元帳)
        ///</summary>
        private void setColumngridShohinMotocho(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridShohinMotocho.Columns.Add(col);
            if (gridShohinMotocho.Columns[col.Name] != null)
            {
                gridShohinMotocho.Columns[col.Name].Width = intLen;
                gridShohinMotocho.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridShohinMotocho.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridShohinMotocho.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///SetUpGridShire
        ///DataGridView初期設定(仕入)
        ///</summary>
        private void SetUpGridShire()
        {
            //データをバインド
            DataGridViewTextBoxColumn Hiduke = new DataGridViewTextBoxColumn();
            Hiduke.DataPropertyName = "日付";
            Hiduke.Name = "日付";
            Hiduke.HeaderText = "日付";

            DataGridViewTextBoxColumn Shiresaki = new DataGridViewTextBoxColumn();
            Shiresaki.DataPropertyName = "仕入先";
            Shiresaki.Name = "仕入先";
            Shiresaki.HeaderText = "仕入先";

            DataGridViewTextBoxColumn Kosu = new DataGridViewTextBoxColumn();
            Kosu.DataPropertyName = "個数";
            Kosu.Name = "個数";
            Kosu.HeaderText = "個数";

            DataGridViewTextBoxColumn Tanka = new DataGridViewTextBoxColumn();
            Tanka.DataPropertyName = "単価";
            Tanka.Name = "単価";
            Tanka.HeaderText = "単価";

            //個々の幅、文章の寄せ
            setColumngridShire(Hiduke, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumngridShire(Shiresaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 320);
            setColumngridShire(Kosu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
            setColumngridShire(Tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
        }

        ///<summary>
        ///setColumngridShohinMotocho
        ///DataGridViewの内部設定(仕入)
        ///</summary>
        private void setColumngridShire(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridShire.Columns.Add(col);
            if (gridShire.Columns[col.Name] != null)
            {
                gridShire.Columns[col.Name].Width = intLen;
                gridShire.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridShire.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridShire.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///SetUpGridGetubetuUriage
        ///DataGridView初期設定(別月売上)
        ///</summary>
        private void SetUpGridGetubetuUriage()
        {
            //データをバインド
            DataGridViewTextBoxColumn YM = new DataGridViewTextBoxColumn();
            YM.DataPropertyName = "年月";
            YM.Name = "年月";
            YM.HeaderText = "年月";

            DataGridViewTextBoxColumn Kosu = new DataGridViewTextBoxColumn();
            Kosu.DataPropertyName = "個数";
            Kosu.Name = "個数";
            Kosu.HeaderText = "個数";

            DataGridViewTextBoxColumn HeikinTanka = new DataGridViewTextBoxColumn();
            HeikinTanka.DataPropertyName = "平均単価";
            HeikinTanka.Name = "平均単価";
            HeikinTanka.HeaderText = "平均単価";

            //個々の幅、文章の寄せ
            setColumngridGetubetuUriage(YM, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 65);
            setColumngridGetubetuUriage(Kosu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
            setColumngridGetubetuUriage(HeikinTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
        }

        ///<summary>
        ///setColumngridShohinMotocho
        ///DataGridViewの内部設定(別月売上)
        ///</summary>
        private void setColumngridGetubetuUriage(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridGetubetuUriage.Columns.Add(col);
            if (gridGetubetuUriage.Columns[col.Name] != null)
            {
                gridGetubetuUriage.Columns[col.Name].Width = intLen;
                gridGetubetuUriage.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridGetubetuUriage.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridGetubetuUriage.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///SetUpGridGetubetuUriage
        ///DataGridView初期設定(別月仕入)
        ///</summary>
        private void SetUpGridGetubetuShire()
        {
            //データをバインド
            DataGridViewTextBoxColumn YM = new DataGridViewTextBoxColumn();
            YM.DataPropertyName = "年月";
            YM.Name = "年月";
            YM.HeaderText = "年月";

            DataGridViewTextBoxColumn Kosu = new DataGridViewTextBoxColumn();
            Kosu.DataPropertyName = "個数";
            Kosu.Name = "個数";
            Kosu.HeaderText = "個数";

            DataGridViewTextBoxColumn HeikinTanka = new DataGridViewTextBoxColumn();
            HeikinTanka.DataPropertyName = "平均単価";
            HeikinTanka.Name = "平均単価";
            HeikinTanka.HeaderText = "平均単価";

            //個々の幅、文章の寄せ
            setColumngridGetubetuShire(YM, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 65);
            setColumngridGetubetuShire(Kosu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
            setColumngridGetubetuShire(HeikinTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
        }

        ///<summary>
        ///setColumngridGetubetuShire
        ///DataGridViewの内部設定(別月仕入)
        ///</summary>
        private void setColumngridGetubetuShire(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridGetubetuShire.Columns.Add(col);
            if (gridGetubetuShire.Columns[col.Name] != null)
            {
                gridGetubetuShire.Columns[col.Name].Width = intLen;
                gridGetubetuShire.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridGetubetuShire.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridGetubetuShire.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///SetUpGridShohinBetuTanka
        ///DataGridView初期設定(商品別単価)
        ///</summary>
        private void SetUpGridShohinBetuTanka()
        {
            //データをバインド
            DataGridViewTextBoxColumn Torihikisaki = new DataGridViewTextBoxColumn();
            Torihikisaki.DataPropertyName = "取引先";
            Torihikisaki.Name = "取引先";
            Torihikisaki.HeaderText = "取引先";

            DataGridViewTextBoxColumn Tanka = new DataGridViewTextBoxColumn();
            Tanka.DataPropertyName = "単価";
            Tanka.Name = "単価";
            Tanka.HeaderText = "単価";

            //個々の幅、文章の寄せ
            setColumngridShohinbetuTanka(Torihikisaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 320);
            setColumngridShohinbetuTanka(Tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 96);
        }

        ///<summary>
        ///setColumngridShohinbetuTanka
        ///DataGridViewの内部設定(商品別単価)
        ///</summary>
        private void setColumngridShohinbetuTanka(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridShohinbetuTanka.Columns.Add(col);
            if (gridShohinbetuTanka.Columns[col.Name] != null)
            {
                gridShohinbetuTanka.Columns[col.Name].Width = intLen;
                gridShohinbetuTanka.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridShohinbetuTanka.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridShohinbetuTanka.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///D1550_ShohinZaikoKakunin_KeyDown
        ///キー入力判定（画面全般）
        ///</summary>
        private void D1550_ShohinZaikoKakunin_KeyDown(object sender, KeyEventArgs e)
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


    }
}