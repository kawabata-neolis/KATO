﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Form.F0140_TanaorosiInput;
using KATO.Common.Util;
using KATO.Common.Business;
using static KATO.Common.Util.CommonTeisu;
using KATO.Common.Ctl;

namespace KATO.Common.Form
{
    ///<summary>
    ///ShouhinList
    ///商品リストフォーム
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class ShouhinList : System.Windows.Forms.Form
    {
        //他画面からという判断データ
        int mode = 0;

        int gmode = 0;

        //前画面からメーカーコードを取り出す枠（大分類コード初期値）
        public string strYMD = "";

        public string strEigyoushoCode = "";

        public string strDaibunruiCode = "";

        public string strChubunruiCode = "";

        public string strMakerCode = "";

        public string strKensaku = "";
        
        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        //DB参照の場所を判断（テキストボックスから）
        int intDBjud = 0;

        /// <summary>
        /// ShouhinList
        /// フォーム関係の設定（通常のテキストボックスから）
        /// </summary>
        public ShouhinList(Control c)
        {
            if (c == null)
            {
                return;
            }
            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF11.Text = "F11:検索";
            this.btnF12.Text = "F12:戻る";

            //ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            //親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2 - 200;
            this.Top = c.Top;
        }

        /// <summary>
        /// _Title
        /// タイトルの設定
        /// </summary>
        public string _Title
        {
            set
            {
                String[] aryTitle = new string[] { value };
                this.Text = string.Format(STR_TITLE, aryTitle);
            }
        }

        /// <summary>
        /// MakerList_Load
        /// 読み込み時
        /// </summary>
        private void ShouhinList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品リスト";

            List<int> lstInt = new List<int>();

            setTextData();

            //DataGridViewの初期設定
            dgvSetUp();

            //modeで判定して項目を追加
            setStart();

            //データ渡し用
            lstInt.Add(0);

            setShohinView(lstInt);

            gmode = mode;

            //未登録棚番を使用する場合
            check1.Checked = false;
        }

        ///<summary>
        ///dgvSetUp
        ///DataGridView初期設定
        ///</summary>
        private void dgvSetUp()
        {
            //列自動生成禁止
            dgvTorihiki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn code = new DataGridViewTextBoxColumn();
            code.DataPropertyName = "コード";
            code.Name = "コード";
            code.HeaderText = "コード";

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

            DataGridViewTextBoxColumn memo = new DataGridViewTextBoxColumn();
            memo.DataPropertyName = "メモ";
            memo.Name = "メモ";
            memo.HeaderText = "メモ";

            //バインドしたデータを追加
            dgvTorihiki.Columns.Add(code);
            dgvTorihiki.Columns.Add(maker);
            dgvTorihiki.Columns.Add(daibunrui);
            dgvTorihiki.Columns.Add(chubunrui);
            dgvTorihiki.Columns.Add(hinmei);
            dgvTorihiki.Columns.Add(memo);

            dgvTorihiki.AutoGenerateColumns = false;

            //個々の幅、文章の寄せ
            dgvTorihiki.Columns["コード"].Width = 0;
            dgvTorihiki.Columns["コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTorihiki.Columns["コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTorihiki.Columns["メーカー"].Width = 100;
            dgvTorihiki.Columns["メーカー"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTorihiki.Columns["メーカー"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTorihiki.Columns["大分類名"].Width = 0;
            dgvTorihiki.Columns["大分類名"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTorihiki.Columns["大分類名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTorihiki.Columns["中分類名"].Width = 110;
            dgvTorihiki.Columns["中分類名"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTorihiki.Columns["中分類名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTorihiki.Columns["品名"].Width = 300;
            dgvTorihiki.Columns["品名"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTorihiki.Columns["品名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTorihiki.Columns["メモ"].Width = 110;
            dgvTorihiki.Columns["メモ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTorihiki.Columns["メモ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

        }

        ///<summary>
        ///setStart
        ///DataGridView初期設定続き
        ///</summary>
        private void setStart()
        {
            if (mode == 9)
            {
                DataGridViewTextBoxColumn tanaHonsha = new DataGridViewTextBoxColumn();
                tanaHonsha.DataPropertyName = "本社在庫";
                tanaHonsha.Name = "本社在庫";
                tanaHonsha.HeaderText = "本社在庫";

                DataGridViewTextBoxColumn tanaGifu = new DataGridViewTextBoxColumn();
                tanaGifu.DataPropertyName = "岐阜在庫";
                tanaGifu.Name = "岐阜在庫";
                tanaGifu.HeaderText = "岐阜在庫";

                dgvTorihiki.Columns.Add(tanaHonsha);
                dgvTorihiki.Columns.Add(tanaGifu);

                dgvTorihiki.Columns["棚番本社"].Width = 110;
                dgvTorihiki.Columns["棚番本社"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTorihiki.Columns["棚番本社"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvTorihiki.Columns["棚番岐阜"].Width = 110;
                dgvTorihiki.Columns["棚番岐阜"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTorihiki.Columns["棚番岐阜"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                DataGridViewTextBoxColumn zaikoHonsha = new DataGridViewTextBoxColumn();
                zaikoHonsha.DataPropertyName = "本社在庫";
                zaikoHonsha.Name = "本社在庫";
                zaikoHonsha.HeaderText = "本社在庫";

                DataGridViewTextBoxColumn zaikoGifu = new DataGridViewTextBoxColumn();
                zaikoGifu.DataPropertyName = "岐阜在庫";
                zaikoGifu.Name = "岐阜在庫";
                zaikoGifu.HeaderText = "岐阜在庫";

                dgvTorihiki.Columns.Add(zaikoHonsha);
                dgvTorihiki.Columns.Add(zaikoGifu);

                dgvTorihiki.Columns["本社在庫"].Width = 110;
                dgvTorihiki.Columns["本社在庫"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvTorihiki.Columns["本社在庫"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvTorihiki.Columns["岐阜在庫"].Width = 110;
                dgvTorihiki.Columns["岐阜在庫"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvTorihiki.Columns["岐阜在庫"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                    this.btnKensakuClick(sender, e);
                    break;
                case Keys.F12:
                    //戻るボタン
                    this.btnEndClick(sender, e);
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///setMoveOrder
        ///form内のエンターによるタブオーダー機能
        ///</summary>
        private void setMoveOrder(object sender, KeyEventArgs e)
        {
            //F1キーが押されたか調べる
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        ///<summary>
        ///judDgvToriKeyDown
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///</summary>        
        private void judDgvToriKeyDown(object sender, KeyEventArgs e)
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
                    //ダブルクリックと同じ効果
                    setSelectItem();
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
                    this.btnKensakuClick(sender, e);
                    break;
                case Keys.F12:
                    //戻るボタン
                    this.btnEndClick(sender, e);
                    break;

                default:
                    break;
            }
        }
        
        ///<summary>
        ///setTorihikiDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void dgvTorihiki_DoubleClick(object sender, EventArgs e)
        {
            setSelectItem();
        }
        
        ///<summary>
        ///setSelectItem
        ///データグリッドビュー内のデータ選択後の処理
        ///</summary>
        private void setSelectItem()
        {
            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();

            if (intFrmKind == 0)
            {
                return;
            }

            //選択行のcode取得
            string strSelectid = (string)dgvTorihiki.CurrentRow.Cells[4].Value;
            //選択行の商品コード取得
            string strSelectShohinCD = (string)dgvTorihiki.CurrentRow.Cells["コード"].Value;
            //選択行のメーカーコード取得
            string strSelectMakerCD = (string)dgvTorihiki.CurrentRow.Cells["メーカー"].Value;
            //選択行の大分類名取得
            string strSelectDaibunName = (string)dgvTorihiki.CurrentRow.Cells["大分類名"].Value;
            //選択行の中分類名取得
            string strSelectChubunName = (string)dgvTorihiki.CurrentRow.Cells["中分類名"].Value;

            //データ渡し用
            lstInt.Add(intFrmKind);

            lstString.Add(strYMD);
            lstString.Add(strEigyoushoCode);
            lstString.Add(strSelectShohinCD);
            lstString.Add(strSelectMakerCD);
            lstString.Add(strSelectDaibunName);
            lstString.Add(strSelectChubunName);
            lstString.Add(strSelectid);

            ShouhinList_B shohinlistB = new ShouhinList_B();
            try
            {
                shohinlistB.setSelectItem(lstInt, lstString);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
            setEndAction();
        }
        
        ///<summary>
        ///setTextData
        ///前画面のデータを記入
        ///</summary>
        private void setTextData()
        {
            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            if (strDaibunruiCode.Length >= 1)
            {
                labelSet_Daibunrui.CodeTxtText = strDaibunruiCode;
                intDBjud = 1;
                setLabel(intDBjud);
            }
            if (strChubunruiCode.Length >= 1)
            {
                labelSet_Chubunrui.CodeTxtText = strChubunruiCode;
                intDBjud = 2;
                setLabel(intDBjud);
            }
            if (strMakerCode.Length >= 1)
            {
                labelSet_Maker.CodeTxtText = strMakerCode;
                intDBjud = 3;
                setLabel(intDBjud);
            }
            txtKensaku.Text = strKensaku;
        }
        
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
            this.Close();

            ShouhinList_B shohinlistB = new ShouhinList_B();
            try
            {
                shohinlistB.setEndAction(intFrmKind);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }


        ///<summary>
        ///btnKensakuClick
        ///検索ボタンを押したとき
        ///</summary>
        private void btnKensakuClick(object sender, EventArgs e)
        {
            List<int> lstInt = new List<int>();

            txtHon.Text = "";
            txtGifu.Text = "";

            dgvTorihiki.Columns.Clear();

            //DataGridViewの初期設定
            dgvSetUp();

            //modeで判定して項目を追加
            setStart();

            //データ渡し用
            lstInt.Add(0);

            setShohinView(lstInt);
        }


        ///<summary>
        ///setShohinView
        ///検索データを記入
        ///</summary>
        private void setShohinView(List<int> lstIntMode)
        {
            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();
            List<Boolean> lstBoolean = new List<Boolean>();

            dgvTorihiki.Enabled = true;
            dgvTorihiki.DataSource = null;
            DataTable dtView = new DataTable();

            //データ渡し用
            lstInt.Add(gmode);
            lstInt.Add(lstIntMode[0]);

            lstString.Add(labelSet_Daibunrui.CodeTxtText);
            lstString.Add(labelSet_Chubunrui.CodeTxtText);
            lstString.Add(labelSet_Maker.CodeTxtText);
            lstString.Add(txtKensaku.Text);
            lstString.Add(txtHon.Text);
            lstString.Add(txtGifu.Text);

            lstBoolean.Add(check1.Checked);

            ShouhinList_B shohinlistB = new ShouhinList_B();
            try
            {
                dtView = shohinlistB.setShohinView(lstInt, lstString, lstBoolean);

                dgvTorihiki.DataSource = dtView;
                this.dgvTorihiki.Columns["コード"].Visible = false;
                this.dgvTorihiki.Columns["大分類名"].Visible = false;

                lblRecords.Text = "該当件数(" + dgvTorihiki.RowCount.ToString() + "件)";
                dgvTorihiki.Focus();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///setLabel
        ///textboxのデータをlabelに記入
        ///</summary>
        private void setLabel(int intDBjud)
        {
            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();

            DataTable dtSetData = new DataTable();

            //データ渡し用
            lstString.Add(labelSet_Daibunrui.CodeTxtText);
            lstString.Add(labelSet_Chubunrui.CodeTxtText);
            lstString.Add(labelSet_Maker.CodeTxtText);

            lstInt.Add(intDBjud);

            ShouhinList_B shohinlistB = new ShouhinList_B();
            try
            {
                dtSetData = shohinlistB.setLabel(lstString, lstInt);

                //テキストボックスが空白のままの場合
                if (dtSetData == null)
                {
                    return;
                }

                if (dtSetData.Rows.Count != 0)
                {
                    switch (intDBjud)
                    {
                        case 1://大分類
                            labelSet_Daibunrui.CodeTxtText = dtSetData.Rows[0]["大分類コード"].ToString();
                            labelSet_Daibunrui.ValueLabelText = dtSetData.Rows[0]["大分類名"].ToString();
                            break;
                        case 2://中分類
                            labelSet_Chubunrui.CodeTxtText = dtSetData.Rows[0]["中分類コード"].ToString();
                            labelSet_Chubunrui.ValueLabelText = dtSetData.Rows[0]["中分類名"].ToString();
                            break;
                        case 3://メーカー
                            labelSet_Maker.CodeTxtText = dtSetData.Rows[0]["メーカーコード"].ToString();
                            labelSet_Maker.ValueLabelText = dtSetData.Rows[0]["メーカー名"].ToString();
                            break;
                        default:
                            return;
                    }
                    //初期化
                    intDBjud = 0;
                }
                else
                {
                    //メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();

                    switch (intDBjud)
                    {
                        case 1://大分類
                            labelSet_Daibunrui.CodeTxtText = "";
                            labelSet_Daibunrui.Focus();
                            break;
                        case 2://中分類
                            labelSet_Chubunrui.CodeTxtText = "";
                            labelSet_Chubunrui.Focus();
                            break;
                        case 3://メーカー
                            labelSet_Maker.CodeTxtText = "";
                            labelSet_Maker.Focus();
                            break;
                        default:
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///btnHonshaZaikoClick
        ///本社在庫ボタン
        ///</summary>
        private void btnHonshaZaikoClick(object sender, EventArgs e)
        {
            //データ渡し用
            List<int> lstInt = new List<int>();

            txtHon.Text = "1";

            //データ渡し用
            lstInt.Add(1);

            setShohinView(lstInt);

            ////処理部に移動
            //ShouhinList_B shohinlistB = new ShouhinList_B();
            ////戻り値のDatatableを取り込む
            //shohinlistB.ZaikoClick(lstString);

            //dgvTorihiki.Columns.Clear();

            ////DataGridViewの初期設定
            //dgvSetUp();

            ////modeで判定して項目を追加
            //setStart();

            //setShohinView(0);

            //txtHon.Text = "";
        }

        ///<summary>
        ///btnGifuZaikoClick
        ///岐阜在庫ボタン
        ///</summary>
        private void btnGifuZaikoClick(object sender, EventArgs e)
        {
            //データ渡し用
            List<int> lstInt = new List<int>();

            txtGifu.Text = "1";

            //データ渡し用
            lstInt.Add(2);

            setShohinView(lstInt);

            ////処理部に移動
            //ShouhinList_B shohinlistB = new ShouhinList_B();
            ////戻り値のDatatableを取り込む
            //shohinlistB.ZaikoClick(lstString);
        }

        ///<summary>
        ///ZaikoClick
        ///岐阜在庫ボタン
        ///</summary>
        private void ZaikoClick(string mode)
        {
            string strWhere;

        }

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
        public void setCyubunrui(DataTable dtSelectData)
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
        public void setDaibunruiListClose()
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
        ///txtDaibunruiLieave
        ///code入力箇所からフォーカスが外れた時(大分類)
        ///</summary>
        private void judDaibunruiLieave(object sender, EventArgs e)
        {
            intDBjud = 1;
            labelSet_Daibunrui.ValueLabelText = "";
            setLabel(intDBjud);
        }

        ///<summary>
        ///txtCyubunruiLieave
        ///code入力箇所からフォーカスが外れた時(中分類)
        ///</summary>
        private void judCyubunruiLieave(object sender, EventArgs e)
        {
            intDBjud = 2;
            labelSet_Chubunrui.ValueLabelText = "";
            setLabel(intDBjud);
        }

        ///<summary>
        ///txtMakerLieave
        ///code入力箇所からフォーカスが外れた時(メーカー)
        ///</summary>
        private void judMakerLieave(object sender, EventArgs e)
        {
            intDBjud = 3;
            labelSet_Maker.ValueLabelText = "";
            setLabel(intDBjud);
        }
    }
}
