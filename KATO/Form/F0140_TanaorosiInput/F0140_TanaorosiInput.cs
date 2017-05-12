using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Common.Ctl;
using KATO.Common.Util;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.F0140_TanaorosiInput_B;

namespace KATO.Form.F0140_TanaorosiInput
{

    ///<summary>
    ///F0140_TanaorosiInput
    ///棚卸入力
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    public partial class F0140_TanaorosiInput : BaseForm
    {
        //大分類コードの確保(text上のを使うと書き換えていた場合に異なるデータを参照するから)
        string strDaibunruiCD;

        //編集中かどうかのフラグ
        Boolean blnEditting = false;


        ///<summary>
        ///F0140_TanaorosiInput
        ///棚卸入力（画面設定）
        ///</summary>
        public F0140_TanaorosiInput(Control c)
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
            labelSet_Daibunrui.LsSubchubundata = labelSet_Chubunrui_Edit;
        }

        ///<summary>
        ///TanaorosiInput_Load
        ///棚卸入力（初回読み込み）
        ///</summary>
        private void TanaorosiInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "棚卸入力";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            radBase4.Checked = true;

            //DataGridViewの初期設定
            SetUpGrid();

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            DataTable dtYMD = new DataTable();

            try
            {
                //処理部に移動
                F0140_TanaorosiInput_B tanaorosiinputB = new F0140_TanaorosiInput_B();
                dtYMD = tanaorosiinputB.setYMD();

                if (dtYMD.Rows.Count != 0)
                {
                    string strYMD = dtYMD.Rows[0]["最新棚卸年月日"].ToString();

                    txtYMD.Text = strYMD.Substring(0, 10);

                    this.txtYMD.ReadOnly = true;
                    this.txtYMD.Enabled = false;

                    this.txtTyoubosuu.Enabled = false;

                    this.btnF01.Text = STR_FUNC_F1;
                    this.btnF04.Text = STR_FUNC_F4;
                    this.btnF12.Text = STR_FUNC_F12;
                }
                else
                {
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this.Parent, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                    basemessagebox.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridRireki.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn tanaban = new DataGridViewTextBoxColumn();
            tanaban.DataPropertyName = "棚番";
            tanaban.Name = "棚番";
            tanaban.HeaderText = "棚番";

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー名";
            maker.Name = "メーカー名";
            maker.HeaderText = "メーカー";

            DataGridViewTextBoxColumn hinmei = new DataGridViewTextBoxColumn();
            hinmei.DataPropertyName = "品名型番";
            hinmei.Name = "品名型番";
            hinmei.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn tyoubo = new DataGridViewTextBoxColumn();
            tyoubo.DataPropertyName = "指定日在庫";
            tyoubo.Name = "指定日在庫";
            tyoubo.HeaderText = "帳簿在庫数";

            DataGridViewTextBoxColumn tana = new DataGridViewTextBoxColumn();
            tana.DataPropertyName = "棚卸数量";
            tana.Name = "棚卸数量";
            tana.HeaderText = "棚卸数";

            DataGridViewTextBoxColumn koushin = new DataGridViewTextBoxColumn();
            koushin.DataPropertyName = "更新区分";
            koushin.Name = "更新区分";
            koushin.HeaderText = "更新";

            DataGridViewTextBoxColumn gyousyoCD = new DataGridViewTextBoxColumn();
            gyousyoCD.DataPropertyName = "営業所コード";
            gyousyoCD.Name = "営業所コード";
            gyousyoCD.HeaderText = "業所コード";

            DataGridViewTextBoxColumn syouhinCD = new DataGridViewTextBoxColumn();
            syouhinCD.DataPropertyName = "商品コード";
            syouhinCD.Name = "商品コード";
            syouhinCD.HeaderText = "商品コード";

            //バインドしたデータを追加
            gridRireki.Columns.Add(tanaban);
            gridRireki.Columns.Add(maker);
            gridRireki.Columns.Add(hinmei);
            gridRireki.Columns.Add(tyoubo);
            gridRireki.Columns.Add(tana);
            gridRireki.Columns.Add(koushin);
            gridRireki.Columns.Add(gyousyoCD);
            gridRireki.Columns.Add(syouhinCD);

            //個々の幅、文章の寄せ
            gridRireki.Columns["棚番"].Width = 70;
            gridRireki.Columns["棚番"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRireki.Columns["棚番"].HeaderCell.Style.Alignment =DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["メーカー名"].Width = 130;
            gridRireki.Columns["メーカー名"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRireki.Columns["メーカー名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["品名型番"].Width = 300;
            gridRireki.Columns["品名型番"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRireki.Columns["品名型番"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["指定日在庫"].Width = 120;
            gridRireki.Columns["指定日在庫"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridRireki.Columns["指定日在庫"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["棚卸数量"].Width = 100;
            gridRireki.Columns["棚卸数量"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridRireki.Columns["棚卸数量"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["更新区分"].Width = 70;
            gridRireki.Columns["更新区分"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridRireki.Columns["更新区分"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["営業所コード"].Width = 120;
            gridRireki.Columns["営業所コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRireki.Columns["営業所コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridRireki.Columns["商品コード"].Width = 120;
            gridRireki.Columns["商品コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRireki.Columns["商品コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        ///<summary>
        ///judTanaorosiKeyDown
        ///キー入力判定
        ///</summary>
        private void judTanaorosiKeyDown(object sender, KeyEventArgs e)
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
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    this.addTanaorosi();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
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
                    //印刷
                    //PrintReport();
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    //クローズの前にデータ変更の破棄確認メッセージ
                    if(blnEditting == true)
                    {
                        // どのボタンを選択したかを判断する
                        if (MessageBox.Show("データが変更されています。破棄してもよろしいですか？", "終了確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///judBtnClick
        ///ボタンの判定
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    this.addTanaorosi();
                    break;
                case STR_BTN_F04: // 取り消し
                    this.delText();
                    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///judRirekiKeyDown
        ///キー入力判定
        ///</summary>
        private void judRirekiKeyDown(object sender, KeyEventArgs e)
        {
            //エンターキーが押されたか調べる
            if (e.KeyData == Keys.Enter)
            {
                setSelectItem();
            }
        }

        ///<summary>
        ///addTanaorosi
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        private void addTanaorosi()
        {
            if(blnAddDataCheck() != true)
            {
                return;
            }

            //データ渡し用
            List<string> lstString = new List<string>();
            
            //データ渡し用
            lstString.Add(txtYMD.Text);
            lstString.Add(labelSet_Eigyousho.CodeTxtText);
            lstString.Add(txtShouhinCD.Text);
            lstString.Add(txtTanasuu.Text);
            lstString.Add(labelSet_Tanaban_Edit.CodeTxtText);

            try
            {
                F0140_TanaorosiInput_B tanaorosiinputB = new F0140_TanaorosiInput_B();
                tanaorosiinputB.addTanaoroshi(lstString);

                setViewGrid();

                txtTanasuu.Text = "";
                labelSet_Chubunrui_Edit.CodeTxtText = "";
                labelSet_Chubunrui_Edit.ValueLabelText = "";
                labelSet_Maker_Edit.CodeTxtText = "";
                labelSet_Maker_Edit.ValueLabelText = "";
                labelSet_Tanaban_Edit.CodeTxtText = "";
                labelSet_Tanaban_Edit.ValueLabelText = "";
                lblDspShouhin.Text = "";

                labelSet_Eigyousho.Focus();

            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///blnDataCheckAdd
        ///DB追加前のチェック工程
        ///</summary>
        private bool blnAddDataCheck()
        {
            bool good = true;
            if(good)
            {
                good = txtYMD.blIsEmpty();
            }
            if (good)
            {
                good = StringUtl.blIsEmpty(labelSet_Eigyousho.CodeTxtText);
            }
            if (good)
            {                
                good = StringUtl.blIsEmpty(labelSet_Daibunrui.CodeTxtText);
            }
            if (good)
            {
                good = StringUtl.blIsEmpty(labelSet_Chubunrui_Edit.CodeTxtText);            }
            if (good)
            {
                good = StringUtl.blIsEmpty(labelSet_Maker_Edit.CodeTxtText);
            }
            if (good)
            {
                good = txtTanasuu.blIsEmpty();
            }
            if (good)
            {
                good = StringUtl.blIsEmpty(labelSet_Tanaban_Edit.CodeTxtText);
            }
            if (good)
            {
                good = txtShouhinCD.blIsEmpty();
            }
            if (good)
            {
                if (btnF01.Enabled == false)
                {
                    good = false;
                }
            }

            return good;            
        }


        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除
        ///</summary>
        private void delText()
        {
            //残したいデータの確保
            string strTxtYMD = "";

            string strEigyouID = "";

            string strEigyouName = "";

            strTxtYMD = txtYMD.Text;

            strEigyouID = labelSet_Eigyousho.CodeTxtText;

            strEigyouName = labelSet_Eigyousho.ValueLabelText;

            //フォーム上のデータを白紙
            this.delFormClear(this, gridRireki);

            //データ復旧
            txtYMD.Text = strTxtYMD;

            labelSet_Eigyousho.CodeTxtText = strEigyouID;

            labelSet_Eigyousho.ValueLabelText = strEigyouName;

            //ﾗｼﾞｵﾎﾞﾀﾝのチェックを初期値
            radBase4.Checked = true;

            labelSet_Eigyousho.Focus();
        }

        ///<summary>
        ///setShouhin
        ///取り出したデータをテキストボックスに配置（商品リスト）
        ///</summary>
        public void setShouhin(List<string> lstStringTana, List<DataTable> lstDTtana)
        {
            if (StringUtl.blIsEmpty(labelSet_Eigyousho.CodeTxtText) == false)
            {
                return;
            }

            labelSet_Daibunrui.CodeTxtText = lstDTtana[0].Rows[0]["大分類コード"].ToString();
            labelSet_Daibunrui.ValueLabelText = lstDTtana[0].Rows[0]["大分類名"].ToString();
            labelSet_Chubunrui_Edit.CodeTxtText = lstDTtana[1].Rows[0]["中分類コード"].ToString();
            labelSet_Chubunrui_Edit.ValueLabelText = lstDTtana[1].Rows[0]["中分類名"].ToString();
            labelSet_Maker_Edit.CodeTxtText = lstDTtana[2].Rows[0]["メーカーコード"].ToString();
            labelSet_Maker_Edit.ValueLabelText = lstDTtana[2].Rows[0]["メーカー名"].ToString();
            labelSet_Tanaban_Edit.CodeTxtText = lstDTtana[3].Rows[0]["棚番"].ToString();
            labelSet_Tanaban_Edit.ValueLabelText = lstDTtana[4].Rows[0]["棚番名"].ToString();
            txtTanasuu.Text = lstDTtana[3].Rows[0]["棚卸数量"].ToString();
            txtTyoubosuu.Text = lstDTtana[3].Rows[0]["指定日在庫"].ToString();
            lblDspShouhin.Text = lstStringTana[1].ToString();
        }

        ///<summary>
        ///btnView
        ///Gridを表示させる（ボタン使用）
        ///</summary>
        private void btnView(object sender, EventArgs e)
        {
            setViewGrid();
        }

        ///<summary>
        ///setViewGrid
        ///Gridを表示させる
        ///</summary>
        private void setViewGrid()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            strDaibunruiCD = null;

            strDaibunruiCD = labelSet_Daibunrui.CodeTxtText;

            DataTable dtView = new DataTable();

            gridRireki.Enabled = true;

            string strBtnJud = "0";

            if (radBase1.Checked == true)
            {
                strBtnJud = "1";
            }
            else if (radBase2.Checked == true)
            {
                strBtnJud = "2";
            }
            else if (radBase3.Checked == true)
            {
                strBtnJud = "3";
            }
            else if (radBase4.Checked == true)
            {
                strBtnJud = "4";
            }

            //データ渡し用
            lstString.Add(txtYMD.Text);
            lstString.Add(labelSet_Eigyousho.CodeTxtText);
            lstString.Add(labelSet_Daibunrui.CodeTxtText);
            lstString.Add(labelSet_Chubunrui.CodeTxtText);
            lstString.Add(labelSet_Maker.CodeTxtText);
            lstString.Add(labelSet_Tanaban.CodeTxtText);
            lstString.Add(strBtnJud);

            try
            {
                //処理部に移動
                F0140_TanaorosiInput_B tanaorosiinputB = new F0140_TanaorosiInput_B();
                //戻り値のDatatableを取り込む
                dtView = tanaorosiinputB.setViewGrid(lstString);

                //指定日在庫、棚卸数量の小数点切り下げ
                for (int cnt = 0; cnt < dtView.Rows.Count; cnt++)
                {
                    decimal decTyoubosuu = Math.Floor(decimal.Parse(dtView.Rows[cnt]["棚卸数量"].ToString()));
                    dtView.Rows[cnt]["棚卸数量"] = decTyoubosuu.ToString();
                    decimal decTanasuu = Math.Floor(decimal.Parse(dtView.Rows[cnt]["指定日在庫"].ToString()));
                    dtView.Rows[cnt]["指定日在庫"] = decTanasuu.ToString();
                }

                gridRireki.DataSource = dtView;

                if (gridRireki.RowCount > 0)
                {
                    gridRireki.Focus();
                }
                else
                {
                    btnViewGrid.Focus();
                }
                lblRecords.Text = "該当件数：" + gridRireki.RowCount.ToString();

                txtShouhinCD.Text = "";

                txtTanasuu.Text = "";
                labelSet_Tanaban_Edit.CodeTxtText = "";
                labelSet_Tanaban_Edit.ValueLabelText = "";
                blnEditting = false;

            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }

        ///<summary>
        ///setSelectItem
        ///データグリッドビューの処理
        ///</summary>
        private void setSelectItem()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSelect = null;

            //選択行の商品コード取得
            string strSelectSyouhinCD = (string)gridRireki.CurrentRow.Cells["商品コード"].Value;

            //データ渡し用
            lstString.Add(txtYMD.Text);
            lstString.Add(strSelectSyouhinCD);

            try
            {
                //処理部に移動
                F0140_TanaorosiInput_B tanaorosiinputB = new F0140_TanaorosiInput_B();
                //戻り値のDatatableを取り込む
                dtSelect = tanaorosiinputB.setSelectItem(lstString);

                //各ラベル,テキストボックスに記入
                txtShouhinCD.Text = strSelectSyouhinCD;
                labelSet_Chubunrui_Edit.CodeTxtText = dtSelect.Rows[0]["中分類コード"].ToString();
                labelSet_Tanaban_Edit.CodeTxtText = dtSelect.Rows[0]["棚番"].ToString();
                labelSet_Maker_Edit.CodeTxtText = dtSelect.Rows[0]["メーカーコード"].ToString();
                lblDspShouhin.Text = dtSelect.Rows[0]["品名型番"].ToString();


                //文字列をDecimal型に変換、小数点以下を削除
                decimal decElemTanasu = Math.Floor(decimal.Parse(dtSelect.Rows[0]["棚卸数量"].ToString()));
                decimal decElemShitei = Math.Floor(decimal.Parse(dtSelect.Rows[0]["指定日在庫"].ToString()));
                //各テキストボックスに記入
                txtTanasuu.Text = decElemTanasu.ToString();
                txtTyoubosuu.Text = decElemShitei.ToString();

                txtTanasuu.Focus();

            }
            catch (Exception ex)
            {
                new CommonException(ex);
            }
        }


        ///<summary>
        ///setGridSeihinDbl
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///</summary>
        private void setGridSeihinDbl(object sender, DataGridViewCellEventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///setEigyoushoListClose
        ///EigyoushoListCloseが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setEigyoushoListClose()
        {
            labelSet_Eigyousho.Focus();
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
        ///setTanabanListClose
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setTanabanListClose()
        {
            labelSet_Tanaban.Focus();
        }

        ///<summary>
        ///setChubunListCloseEdit
        ///ChubunruiListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setChubunListCloseEdit()
        {
            labelSet_Chubunrui_Edit.Focus();
        }

        ///<summary>
        ///setMakerListCloseEdit
        ///MakerListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setMakerListCloseEdit()
        {
            labelSet_Maker_Edit.Focus();
        }

        ///<summary>
        ///setTanaListCloseEdit
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///</summary>
        public void setTanaListCloseEdit()
        {
            labelSet_Tanaban_Edit.Focus();
        }

        ///<summary>
        ///updTxtKensakuLeave
        //検索ウィンドウか別テキストボックスに移動
        ///</summary>
        public void updTxtKensakuLeave(object sender, EventArgs e)
        {
            if(txtKensaku.TextLength > 0)
            {
                try
                {
                    ShouhinList shouhinlist = new ShouhinList(this);
                    shouhinlist.intFrmKind = CommonTeisu.FRM_TANAOROSHI;
                    shouhinlist.strYMD = txtYMD.Text;
                    shouhinlist.strEigyoushoCode = labelSet_Eigyousho.CodeTxtText;
                    shouhinlist.strDaibunruiCode = labelSet_Daibunrui.CodeTxtText;
                    shouhinlist.strChubunruiCode = labelSet_Chubunrui.CodeTxtText;
                    shouhinlist.strMakerCode = labelSet_Maker.CodeTxtText;
                    shouhinlist.strKensaku = txtKensaku.Text;
                    shouhinlist.Show();

                }
                catch (Exception ex)
                {
                    new CommonException(ex);
                }
            }
        }

        ///<summary>
        ///judGridCellChanged
        ///データグリッドビューに直接変更があった場合
        ///</summary>
        private void judGridCellChanged(object sender, DataGridViewCellEventArgs e)
        {
            blnEditting = true;
        }
    }
}
