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
using KATO.Business.A0100_HachuInput_B;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.A0100_HachuInput
{
    ///<summary>
    ///A0100_HachuInput
    ///商品フォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class A0100_HachuInput : BaseForm
    {
        /// <summary>
        /// A0100_HachuInput
        /// フォーム関係の設定
        /// </summary>
        public A0100_HachuInput(Control c)
        {
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

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;

            //中分類setデータを読めるようにする
            labelSet_Daibunrui.Lschubundata = labelSet_Chubunrui;
        }

        /// <summary>
        /// A0100_HachuInput_Load
        /// 読み込み時
        /// </summary>
        private void A0100_HachuInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品マスター";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF08.Text = STR_FUNC_F8_RIREKI;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            txtHachuYMD.Text = DateTime.Today.ToString();

            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridHachu.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn hachuban = new DataGridViewTextBoxColumn();
            hachuban.DataPropertyName = "発注番号";
            hachuban.Name = "発注番号";
            hachuban.HeaderText = "発注番号";

            DataGridViewTextBoxColumn chuban = new DataGridViewTextBoxColumn();
            chuban.DataPropertyName = "注番";
            chuban.Name = "注番";
            chuban.HeaderText = "注番";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー";
            maker.Name = "メーカー";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn chubun = new DataGridViewTextBoxColumn();
            chubun.DataPropertyName = "中分類";
            chubun.Name = "中分類";
            chubun.HeaderText = "中分類";

            DataGridViewTextBoxColumn kataban = new DataGridViewTextBoxColumn();
            kataban.DataPropertyName = "型番";
            kataban.Name = "型番";
            kataban.HeaderText = "型　　番";

            DataGridViewTextBoxColumn hachusu = new DataGridViewTextBoxColumn();
            hachusu.DataPropertyName = "発注数量";
            hachusu.Name = "発注数量";
            hachusu.HeaderText = "発注数量";

            DataGridViewTextBoxColumn noki = new DataGridViewTextBoxColumn();
            noki.DataPropertyName = "納期";
            noki.Name = "納期";
            noki.HeaderText = "納期";

            //個々の幅、文章の寄せ
            setColumn(hachuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 0);
            setColumn(chuban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(chubun, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 100);
            setColumn(kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 600);
            setColumn(hachusu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0.#", 150);
            setColumn(noki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);

        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridHachu.Columns.Add(col);
            if (gridHachu.Columns[col.Name] != null)
            {
                gridHachu.Columns[col.Name].Width = intLen;
                gridHachu.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridHachu.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridHachu.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// A0100_HachuInput_KeyDown
        /// キー入力判定
        /// </summary>
        private void A0100_HachuInput_KeyDown(object sender, KeyEventArgs e)
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
                    this.addHachu();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    this.delHachu();
                    break;
                case Keys.F4:
                    this.delText();
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
                    this.setRireki();
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
        }

        /// <summary>
        /// judBtnClick
        /// ボタンの反応
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    this.addHachu();
                    break;
                case STR_BTN_F03: // 削除
                    this.delHachu();
                    break;
                case STR_BTN_F04: // 取り消し
                    this.delText();
                    break;
                case STR_BTN_F08: // 履歴
                    this.setRireki();
                    break;
                //case STR_BTN_F11: //印刷
                //    this.XX();
                //    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// addHachu
        /// テキストボックス内のデータをDBに登録
        /// </summary>
        private void addHachu()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //文字判定
            if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false)
            {
                //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Daibunrui.Focus();
                return;
            }

        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            delFormClear(this,gridHachu);


        }

        /// <summary>
        /// delHachu
        /// テキストボックス内のデータをDBから削除
        /// </summary>
        public void delHachu()
        {

        }

        /// <summary>
        /// setRireki
        /// 仕入実績確認を表示
        /// </summary>
        public void setRireki()
        {

        }

        /// <summary>
        /// textSet_Tokuisaki_Leave
        /// 得意先コードから離れた場合
        /// </summary>
        private void textSet_Tokuisaki_Leave(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSetCd;

            if (textSet_Tokuisaki.CodeTxtText == "")
            {
                return;
            }

            //前後の空白を取り除く
            textSet_Tokuisaki.CodeTxtText = textSet_Tokuisaki.CodeTxtText.Trim();

            //データ渡し用
            lstString.Add(textSet_Tokuisaki.CodeTxtText);

            //処理部に移動
            A0100_HachuInput_B hachuB = new A0100_HachuInput_B();

            try
            {
                //戻り値のDatatableを取り込む
                dtSetCd = hachuB.textSet_Tokuisaki_Leave(lstString);

                if (dtSetCd.Rows.Count != 0)
                {
                    gridHachu.DataSource = dtSetCd;
                }

            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        /// <summary>
        /// judtxtDaibunruiKeyUp
        /// 入力項目上でのキー判定と文字数判定
        /// </summary>
        private void judtxtHachuKeyUp(object sender, KeyEventArgs e)
        {
            Control cActiveBefore = this.ActiveControl;

            BaseText basetext = new BaseText();
            basetext.judKeyUp(cActiveBefore, e);
        }
    }
}