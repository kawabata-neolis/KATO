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
using KATO.Business.TanaorosiInput;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.TanaorosiInput
{
    public partial class TanaorosiInput : BaseForm
    {
        //大分類コードの確保(text上のを使うと書き換えていた場合に異なるデータを参照するから)
        string strDaibunruiCD;

        //DB参照の場所を判断（テキストボックスから）
        int intDBjud = 0;

        //SQL文の確保
        string strSQL = null;

        //編集中かどうかのフラグ
        Boolean blnEditting = false;

        public TanaorosiInput()
        {
            InitializeComponent();
        }

        private void TanaorosiInput_Load(object sender, EventArgs e)
        {
            //delText();

            this.Show();
            this._Title = "棚卸入力";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            radioButton4.Checked = true;

            lblDspEigyousyo.TextAlign = ContentAlignment.MiddleLeft;
            lblDspDaibunrui.TextAlign = ContentAlignment.MiddleLeft;
            lblDspChubunrui.TextAlign = ContentAlignment.MiddleLeft;
            lblDspMaker.TextAlign = ContentAlignment.MiddleLeft;
            lblDspTanaban.TextAlign = ContentAlignment.MiddleLeft;
            lblDspShouhin.TextAlign = ContentAlignment.MiddleLeft;
            lblDspTanabanEdit.TextAlign = ContentAlignment.MiddleLeft;
            lblDspChubunEdit.TextAlign = ContentAlignment.MiddleLeft;
            lblDspMakerEdit.TextAlign = ContentAlignment.MiddleLeft;
            txtTanasuu.TextAlign = HorizontalAlignment.Right;
            txtTyoubosuu.TextAlign = HorizontalAlignment.Right;

            //DataGridViewの初期設定
            dgvSetUp();

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            DataTable dtYMD = new DataTable();

            //処理部に移動
            TanaorosiInput_B tanaorosiinputB = new TanaorosiInput_B();
            dtYMD = tanaorosiinputB.setYMD();

            string strYMD = dtYMD.Rows[0]["最新棚卸年月日"].ToString();

            txtYMD.Text = strYMD.Substring(0, 10);

            this.txtYMD.ReadOnly = true;
            this.txtYMD.Enabled = false;

            this.txtTyoubosuu.Enabled = false;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF12.Text = STR_FUNC_F12;

        }

        ///<summary>
        ///dgvSetUp
        ///DataGridView初期設定
        ///作成者：大河内
        ///作成日：2017/3/10
        ///更新者：大河内
        ///更新日：2017/3/13
        ///カラム論理名
        ///</summary>
        private void dgvSetUp()
        {
            //列自動生成禁止
            dgvRireki.AutoGenerateColumns = false;

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
            dgvRireki.Columns.Add(tanaban);
            dgvRireki.Columns.Add(maker);
            dgvRireki.Columns.Add(hinmei);
            dgvRireki.Columns.Add(tyoubo);
            dgvRireki.Columns.Add(tana);
            dgvRireki.Columns.Add(koushin);
            dgvRireki.Columns.Add(gyousyoCD);
            dgvRireki.Columns.Add(syouhinCD);

            //個々の幅、文章の寄せ
            dgvRireki.Columns["棚番"].Width = 70;
            dgvRireki.Columns["棚番"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRireki.Columns["棚番"].HeaderCell.Style.Alignment =DataGridViewContentAlignment.MiddleCenter;

            dgvRireki.Columns["メーカー名"].Width = 130;
            dgvRireki.Columns["メーカー名"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRireki.Columns["メーカー名"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRireki.Columns["品名型番"].Width = 300;
            dgvRireki.Columns["品名型番"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRireki.Columns["品名型番"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRireki.Columns["指定日在庫"].Width = 120;
            dgvRireki.Columns["指定日在庫"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRireki.Columns["指定日在庫"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRireki.Columns["棚卸数量"].Width = 100;
            dgvRireki.Columns["棚卸数量"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRireki.Columns["棚卸数量"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRireki.Columns["更新区分"].Width = 50;
            dgvRireki.Columns["更新区分"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRireki.Columns["更新区分"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRireki.Columns["営業所コード"].Width = 100;
            dgvRireki.Columns["営業所コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRireki.Columns["営業所コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRireki.Columns["商品コード"].Width = 100;
            dgvRireki.Columns["商品コード"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRireki.Columns["商品コード"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }


        ///<summary>
        ///judTanaorosiKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/3/10
        ///更新者：大河内
        ///更新日：2017/3/10
        ///カラム論理名
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
                    break;
                case Keys.F1:
                    this.addTanaoroshi();
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
                        else
                        {
                            return;
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
        ///ボタンの反応
        ///作成者：大河内
        ///作成日：2017/3/16
        ///更新者：大河内
        ///更新日：2017/3/16
        ///カラム論理名
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    this.addTanaoroshi();
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
        ///setMoveOrder
        ///form内のエンターによるタブオーダー機能
        ///作成者：大河内
        ///作成日：2017/3/15
        ///更新者：大河内
        ///更新日：2017/3/15
        ///カラム論理名
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
        ///judRirekiKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/3/15
        ///更新者：大河内
        ///更新日：2017/3/15
        ///カラム論理名
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
        ///addTanaoroshi
        ///テキストボックス内のデータをDBに登録
        ///作成者：大河内
        ///作成日：2017/3/10
        ///更新者：大河内
        ///更新日：2017/3/22
        ///カラム論理名
        ///</summary>
        private void addTanaoroshi()
        {
            if(blnDataCheckAdd() != true)
            {
                return;
            }

            TanaorosiInput_B tanaorosiinputB = new TanaorosiInput_B();
            tanaorosiinputB.addTanaoroshi(txtYMD.Text,txtEigyousyo.Text,txtShouhinCD.Text,txtTanasuu.Text,txtTanabanEdit.Text);

            setViewGrid();

            txtTanasuu.Text = "";
            txtTanabanEdit.Text = "";
            lblDspTanabanEdit.Text = "";
            txtChubunruiEdit.Text = "";
            lblDspChubunEdit.Text = "";
            txtMakerEdit.Text = "";
            lblDspMakerEdit.Text = "";
            lblDspShouhin.Text = "";
            
            //MessageBox.Show("正常に登録されました。", "登録", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtEigyousyo.Focus();

        }

        ///<summary>
        ///blnDataCheckAdd
        ///DB追加前のチェック工程
        ///作成者：大河内
        ///作成日：2017/3/10
        ///更新者：大河内
        ///更新日：2017/3/10
        ///カラム論理名
        ///</summary>
        private bool blnDataCheckAdd()
        {
            bool good = true;
            if(good)
            {
                good = txtYMD.blIsEmpty();
            }
            if (good)
            {
                good = txtEigyousyo.blIsEmpty();
            }
            if (good)
            {
                good = txtDaibunrui.blIsEmpty();
            }
            if (good)
            {
                good = txtChubunrui.blIsEmpty();
            }
            if (good)
            {
                good = txtMakerEdit.blIsEmpty();
            }
            if (good)
            {
                good = txtTanasuu.blIsEmpty();
            }
            if (good)
            {
                good = txtTanabanEdit.blIsEmpty();
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
        ///作成者：大河内
        ///作成日：2017/3/10
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void delText()
        {
            BaseForm formreset = new BaseForm();
            formreset.delFormClear(this, dgvRireki);

            txtEigyousyo.Focus();
        }

        ///<summary>
        ///delTexClear
        ///テキストボックス内の文字を削除
        ///作成者：大河内
        ///作成日：2017/3/10
        ///更新者：大河内
        ///更新日：2017/3/15
        ///カラム論理名
        ///</summary>
        private void delTexClear()
        {
            txtDaibunrui.Clear();
            txtChubunrui.Clear();
            txtMaker.Clear();
            txtTanaban.Clear();
            txtKensaku.Clear();
            txtTanasuu.Clear();
            txtTanabanEdit.Clear();
            txtChubunruiEdit.Clear();
            txtMakerEdit.Clear();
            txtTyoubosuu.Clear();
            lblDspDaibunrui.Text = "";
            lblDspChubunrui.Text = "";
            lblDspShouhin.Text = "";
            lblDspMaker.Text = "";
            lblDspTanaban.Text = "";
            lblDspChubunEdit.Text = "";
            lblDspMakerEdit.Text = "";
            lblDspTanabanEdit.Text = "";

//rowのみを削除したい
            //dgvRireki.Columns.Clear();

        }

        ///<summary>
        ///setEigyousho
        ///取り出したデータをテキストボックスに配置（営業所）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void setEigyousho(DataTable dtSelectData)
        {
            txtEigyousyo.Text = dtSelectData.Rows[0]["営業所コード"].ToString();
            lblDspEigyousyo.Text = dtSelectData.Rows[0]["営業所名"].ToString();
        }

        ///<summary>
        ///setDaibunrui
        ///取り出したデータをテキストボックスに配置（大分類）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void setDaibunrui(DataTable dtSelectData)
        {
            txtDaibunrui.Text = dtSelectData.Rows[0]["大分類コード"].ToString();
            lblDspDaibunrui.Text = dtSelectData.Rows[0]["大分類名"].ToString();
        }

        ///<summary>
        ///setCyubunrui
        ///取り出したデータをテキストボックスに配置（中分類）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void setCyubunrui(DataTable dtSelectData)
        {
            txtChubunrui.Text = dtSelectData.Rows[0]["中分類コード"].ToString();
            lblDspChubunrui.Text = dtSelectData.Rows[0]["中分類名"].ToString();
        }

        ///<summary>
        ///setMakerCode
        ///取り出したデータをテキストボックスに配置（メーカー）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void setMakerCode(DataTable dtSelectData)
        {
            txtMaker.Text = dtSelectData.Rows[0]["メーカーコード"].ToString();
            lblDspMaker.Text = dtSelectData.Rows[0]["メーカー名"].ToString();
        }

        ///<summary>
        ///setTanabanCode
        ///取り出したデータをテキストボックスに配置（棚番）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void setTanabanCode(DataTable dtSelectData)
        {
            txtTanaban.Text = dtSelectData.Rows[0]["棚番"].ToString();
            lblDspTanaban.Text = dtSelectData.Rows[0]["棚番名"].ToString();
        }


        ///<summary>
        ///setChubunEdit
        ///取り出したデータをテキストボックスに配置（編集中分類）
        ///作成者：大河内
        ///作成日：2017/3/16
        ///更新者：大河内
        ///更新日：2017/3/16
        ///カラム論理名
        ///</summary>
        public void setChubunEdit(DataTable dtSelectData)
        {
            txtChubunruiEdit.Text = dtSelectData.Rows[0]["中分類コード"].ToString();
            lblDspChubunEdit.Text = dtSelectData.Rows[0]["中分類名"].ToString();
        }

        ///<summary>
        ///setMakerEdit
        ///取り出したデータをテキストボックスに配置（編集メーカー）
        ///作成者：大河内
        ///作成日：2017/3/16
        ///更新者：大河内
        ///更新日：2017/3/16
        ///カラム論理名
        ///</summary>
        public void setMakerEdit(DataTable dtSelectData)
        {
            txtMakerEdit.Text = dtSelectData.Rows[0]["メーカーコード"].ToString();
            lblDspMakerEdit.Text = dtSelectData.Rows[0]["メーカー名"].ToString();
        }

        ///<summary>
        ///setTanabanEdit
        ///取り出したデータをテキストボックスに配置（編集棚番）
        ///作成者：大河内
        ///作成日：2017/3/16
        ///更新者：大河内
        ///更新日：2017/3/16
        ///カラム論理名
        ///</summary>
        public void setTanabanEdit(DataTable dtSelectData)
        {
            txtTanabanEdit.Text = dtSelectData.Rows[0]["棚番"].ToString();
            lblDspTanabanEdit.Text = dtSelectData.Rows[0]["棚番名"].ToString();
        }

        ///<summary>
        ///setShouhin
        ///取り出したデータをテキストボックスに配置（商品リスト）
        ///作成者：大河内
        ///作成日：2017/3/17
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public void setShouhin(List<string> lstStringTana, List<DataTable> lstDTtana)
        {
            if(String.IsNullOrWhiteSpace(txtEigyousyo.Text).Equals(true))
            {
                return;
            }

            txtDaibunrui.Text = lstDTtana[0].Rows[0]["大分類コード"].ToString();
            lblDspDaibunrui.Text = lstDTtana[0].Rows[0]["大分類名"].ToString();
            txtChubunruiEdit.Text = lstDTtana[1].Rows[0]["中分類コード"].ToString();
            lblDspChubunEdit.Text = lstDTtana[1].Rows[0]["中分類名"].ToString();
            txtMakerEdit.Text = lstDTtana[2].Rows[0]["メーカーコード"].ToString();
            lblDspMakerEdit.Text = lstDTtana[2].Rows[0]["メーカー名"].ToString();
            txtTanabanEdit.Text = lstDTtana[3].Rows[0]["棚番"].ToString();
            txtTanasuu.Text = lstDTtana[3].Rows[0]["棚卸数量"].ToString();
            txtTyoubosuu.Text = lstDTtana[3].Rows[0]["指定日在庫"].ToString();
            lblDspTanabanEdit.Text = lstDTtana[4].Rows[0]["棚番名"].ToString();
            lblDspShouhin.Text = lstStringTana[1].ToString();
        }


        ///<summary>
        ///judEigyousyoKeyDown
        ///コード入力項目でのキー入力判定（営業所）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judEigyousyoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                EigyoushoList eigyoushoList = new EigyoushoList();
                eigyoushoList.Left = 100;
                eigyoushoList.StartPosition = FormStartPosition.Manual;
                eigyoushoList.intFrmKind = CommonTeisu.FRM_TANAOROSHI;
                eigyoushoList.Show();
            }
            else
            {
                setMoveOrder(sender, e);
            }
        }

        ///<summary>
        ///judDaibunruiKeyDown
        ///コード入力項目でのキー入力判定（大分類）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judDaibunruiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                DaibunruiList daibunruiList = new DaibunruiList();
                daibunruiList.Left = 100;
                daibunruiList.StartPosition = FormStartPosition.Manual;
                daibunruiList.intFrmKind = CommonTeisu.FRM_TANAOROSHI;
                daibunruiList.Show();
            }
            else
            {
                setMoveOrder(sender, e);
            }
        }

        ///<summary>
        ///judtxtCyubunruiKeyDown
        ///コード入力項目でのキー入力判定（中分類）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judChubunruiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (String.IsNullOrWhiteSpace(txtDaibunrui.Text).Equals(true))
                {
                    return;
                }
                ChubunruiList cyokusousakilist = new ChubunruiList();
                cyokusousakilist.Left = 100;
                cyokusousakilist.StartPosition = FormStartPosition.Manual;
                cyokusousakilist.intFrmKind = CommonTeisu.FRM_TANAOROSHI;
                cyokusousakilist.strDaibunruiCode = txtDaibunrui.Text;
                cyokusousakilist.Show();
            }
            else
            {
                setMoveOrder(sender, e);
            }
        }

        ///<summary>
        ///judtxtMakerKeyDown
        ///コード入力項目でのキー入力判定（メーカー）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judMakerKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (String.IsNullOrWhiteSpace(txtDaibunrui.Text).Equals(true))
                {
                    return;
                }
                MakerList makerlist = new MakerList();
                makerlist.Left = 100;
                makerlist.StartPosition = FormStartPosition.Manual;
                makerlist.intFrmKind = CommonTeisu.FRM_TANAOROSHI;
                makerlist.strDaibunruiCode = txtDaibunrui.Text;
                makerlist.Show();
            }
            else
            {
                setMoveOrder(sender, e);
            }
        }

        ///<summary>
        ///judtxtMakerKeyDown
        ///コード入力項目でのキー入力判定（棚番）
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judTanabanKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                TanabanList tanabanlist = new TanabanList();
                tanabanlist.Left = 100;
                tanabanlist.StartPosition = FormStartPosition.Manual;
                tanabanlist.intFrmKind = CommonTeisu.FRM_TANAOROSHI;
                tanabanlist.Show();
            }
            else
            {
                setMoveOrder(sender, e);
            }
        }

        ///<summary>
        ///judChubunEditKeyDown
        ///コード入力項目でのキー入力判定(編集中分類）
        ///作成者：大河内
        ///作成日：2017/3/16
        ///更新者：大河内
        ///更新日：2017/3/16
        ///カラム論理名
        ///</summary>
        private void judChubunEditKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (String.IsNullOrWhiteSpace(txtDaibunrui.Text).Equals(true))
                {
                    return;
                }
                ChubunruiList chubunruilist = new ChubunruiList();
                chubunruilist.Left = 100;
                chubunruilist.StartPosition = FormStartPosition.Manual;
                chubunruilist.intFrmKind = CommonTeisu.FRM_TANAOROSHI_EDIT;
                chubunruilist.strDaibunruiCode = txtDaibunrui.Text;
                chubunruilist.Show();
            }
            else
            {
                setMoveOrder(sender, e);
            }
        }

        ///<summary>
        ///judMakerEditKeyDown
        ///コード入力項目でのキー入力判定(編集メーカー）
        ///作成者：大河内
        ///作成日：2017/3/16
        ///更新者：大河内
        ///更新日：2017/3/16
        ///カラム論理名
        ///</summary>
        private void judMakerEditKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (String.IsNullOrWhiteSpace(txtDaibunrui.Text).Equals(true))
                {
                    return;
                }
                MakerList makerlist = new MakerList();
                makerlist.Left = 100;
                makerlist.StartPosition = FormStartPosition.Manual;
                makerlist.intFrmKind = CommonTeisu.FRM_TANAOROSHI_EDIT;
                makerlist.strDaibunruiCode = txtDaibunrui.Text;
                makerlist.Show();
            }
            else
            {
                setMoveOrder(sender, e);
            }
        }

        ///<summary>
        ///judTanaEditKeyDown
        ///コード入力項目でのキー入力判定(編集棚番）
        ///作成者：大河内
        ///作成日：2017/3/16
        ///更新者：大河内
        ///更新日：2017/3/16
        ///カラム論理名
        ///</summary>
        private void judTanaEditKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                TanabanList tanabanlist = new TanabanList();
                tanabanlist.Left = 100;
                tanabanlist.StartPosition = FormStartPosition.Manual;
                tanabanlist.intFrmKind = CommonTeisu.FRM_TANAOROSHI_EDIT;
                tanabanlist.Show();
            }
            else
            {
                setMoveOrder(sender, e);
            }
        }


        ///<summary>
        ///btnView
        ///Gridを表示させる
        ///作成者：大河内
        ///作成日：2017/3/10
        ///更新者：大河内
        ///更新日：2017/3/13
        ///カラム論理名
        ///</summary>
        private void btnView(object sender, EventArgs e)
        {
            setViewGrid();
        }

        ///<summary>
        ///setViewGrid
        ///Gridを表示させる
        ///作成者：大河内
        ///作成日：2017/3/10
        ///更新者：大河内
        ///更新日：2017/4/6
        ///カラム論理名
        ///</summary>
        private void setViewGrid()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            strDaibunruiCD = null;

            strDaibunruiCD = txtDaibunrui.Text;

            DataTable dtView = new DataTable();

            dgvRireki.Enabled = true;

            string strBtnJud = "0";

            if (radioButton1.Checked == true)
            {
                strBtnJud = "1";
            }
            else if (radioButton2.Checked == true)
            {
                strBtnJud = "2";
            }
            else if (radioButton3.Checked == true)
            {
                strBtnJud = "3";
            }
            else if (radioButton4.Checked == true)
            {
                strBtnJud = "4";
            }

            //データ渡し用
            lstString.Add(txtYMD.Text);
            lstString.Add(txtEigyousyo.Text);
            lstString.Add(txtDaibunrui.Text);
            lstString.Add(txtChubunrui.Text);
            lstString.Add(txtMaker.Text);
            lstString.Add(txtTanaban.Text);
            lstString.Add(strBtnJud);

            //処理部に移動
            TanaorosiInput_B tanaorosiinputB = new TanaorosiInput_B();
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

            dgvRireki.DataSource = dtView;

            if (dgvRireki.RowCount > 0)
            {
                dgvRireki.Focus();
            }
            else
            {
                btnViewGrid.Focus();
            }
            lblRecords.Text = "該当件数：" + dgvRireki.RowCount.ToString();

            txtShouhinCD.Text = "";

            txtTanasuu.Text = "";
            txtTanabanEdit.Text = "";
            lblDspTanabanEdit.Text = "";

            blnEditting = false;
        }

        ///<summary>
        ///setSelectItem
        ///データグリッドビューの処理
        ///作成者：大河内
        ///作成日：2017/3/15
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        private void setSelectItem()
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            DataTable dtSelect = null;

            //選択行の商品コード取得
            string strSelectSyouhinCD = (string)dgvRireki.CurrentRow.Cells["商品コード"].Value;

            //データ渡し用
            lstString.Add(txtYMD.Text);
            lstString.Add(strSelectSyouhinCD);

            //処理部に移動
            TanaorosiInput_B tanaorosiinputB = new TanaorosiInput_B();
            //戻り値のDatatableを取り込む
            dtSelect = tanaorosiinputB.setSelectItem(lstString);

            //各ラベル,テキストボックスに記入
            txtShouhinCD.Text = strSelectSyouhinCD;
            txtChubunruiEdit.Text = dtSelect.Rows[0]["中分類コード"].ToString();
            txtTanabanEdit.Text = dtSelect.Rows[0]["棚番"].ToString();
            txtMakerEdit.Text = dtSelect.Rows[0]["メーカーコード"].ToString();
            lblDspShouhin.Text = dtSelect.Rows[0]["品名型番"].ToString();


            //文字列をDecimal型に変換、小数点以下を削除
            decimal decElemTanasu = Math.Floor(decimal.Parse(dtSelect.Rows[0]["棚卸数量"].ToString()));
            decimal decElemShitei = Math.Floor(decimal.Parse(dtSelect.Rows[0]["指定日在庫"].ToString()));
            //各テキストボックスに記入
            txtTanasuu.Text = decElemTanasu.ToString();
            txtTyoubosuu.Text = decElemShitei.ToString();

            txtTanabanEdit.Focus();
            txtChubunruiEdit.Focus();
            txtMakerEdit.Focus();
            txtKensaku.Focus();
            txtTanasuu.Focus();
        }


        ///<summary>
        ///setdgvSeihinDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///作成者：大河内
        ///作成日：2017/3/10
        ///更新者：大河内
        ///更新日：2017/3/15
        ///カラム論理名
        ///</summary>
        private void setdgvSeihinDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setSelectItem();
        }

        ///judTxtEigyousyoKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judEigyousyoKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtEigyousyo.TextLength == 4)
            {
                judEigyousyoLeave(sender, e);
            }
        }

        ///judTxtDaibunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judDaibunruiKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtDaibunrui.TextLength == 2)
            {
                judDaibunruiLieave(sender, e);
            }
        }


        ///judtxtChubunruiKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judChubunruiKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtChubunrui.TextLength == 2)
            {
                judCyubunruiLieave(sender, e);
            }
        }


        ///judMakerKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judMakerKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtMaker.TextLength == 3)
            {
                judMakerLieave(sender, e);
            }
        }

        ///judTanabanKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judTanabanKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtTanaban.TextLength == 6)
            {
                judTanabanLieave(sender, e);
            }
        }

        ///judChubunruiEditKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judChubunruiEditKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtChubunruiEdit.TextLength == 2)
            {
                judCyubunruiEditLieave(sender, e);
            }
        }

        ///judMakerEditKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judMakerEditKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtMakerEdit.TextLength == 3)
            {
                judMakerEditLieave(sender, e);
            }
        }

        ///judTanabanEditKeyUp
        ///入力項目上でのキー判定と文字数判定
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/3/29
        ///カラム論理名
        ///</summary>
        private void judTanabanEditKeyUp(object sender, KeyEventArgs e)
        {
            //シフトタブ 2つ
            if (e.KeyCode == Keys.Tab && e.Shift == true)
            {
                return;
            }
            //左右のシフトキー 4つ
            else if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
            {
                return;
            }

            if (txtTanabanEdit.TextLength == 6)
            {
                txtTanabanEditLieave(sender, e);
            }
        }


        ///<summary>
        ///txtEigyousyoLeave
        ///code入力箇所からフォーカスが外れた時(営業所)
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judEigyousyoLeave(object sender, EventArgs e)
        {
            intDBjud = 1;
            lblDspEigyousyo.Text = "";
            txtGridViewLieave(sender, e, intDBjud);
        }

        ///<summary>
        ///txtDaibunruiLieave
        ///code入力箇所からフォーカスが外れた時(大分類)
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judDaibunruiLieave(object sender, EventArgs e)
        {
            intDBjud = 2;
            lblDspDaibunrui.Text = "";
            txtGridViewLieave(sender, e, intDBjud);
        }

        ///<summary>
        ///txtCyubunruiLieave
        ///code入力箇所からフォーカスが外れた時(中分類)
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judCyubunruiLieave(object sender, EventArgs e)
        {
            intDBjud = 3;
            lblDspChubunrui.Text = "";
            txtGridViewLieave(sender, e, intDBjud);
        }

        ///<summary>
        ///txtMakerLieave
        ///code入力箇所からフォーカスが外れた時(メーカー)
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judMakerLieave(object sender, EventArgs e)
        {
            intDBjud = 4;
            lblDspMaker.Text = "";
            txtGridViewLieave(sender, e, intDBjud);
        }

        ///<summary>
        ///txtTanabanLieave
        ///code入力箇所からフォーカスが外れた時(棚番)
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        private void judTanabanLieave(object sender, EventArgs e)
        {
            intDBjud = 5;
            lblDspTanaban.Text = "";
            txtGridViewLieave(sender, e, intDBjud);
        }

        ///<summary>
        ///txtCyubunruiEditLieave
        ///code入力箇所からフォーカスが外れた時(編集中分類)
        ///作成者：大河内
        ///作成日：2017/3/16
        ///更新者：大河内
        ///更新日：2017/3/16
        ///カラム論理名
        ///</summary>
        private void judCyubunruiEditLieave(object sender, EventArgs e)
        {
            intDBjud = 6;
            lblDspChubunEdit.Text = "";
            txtGridViewLieave(sender, e, intDBjud);
        }

        ///<summary>
        ///txtMakerEditLieave
        ///code入力箇所からフォーカスが外れた時(編集メーカー)
        ///作成者：大河内
        ///作成日：2017/3/16
        ///更新者：大河内
        ///更新日：2017/3/16
        ///カラム論理名
        ///</summary>
        private void judMakerEditLieave(object sender, EventArgs e)
        {
            intDBjud = 7;
            lblDspMakerEdit.Text = "";
            txtGridViewLieave(sender, e, intDBjud);
        }

        ///<summary>
        ///txtTanabanEditLieave
        ///code入力箇所からフォーカスが外れた時(編集棚番)
        ///作成者：大河内
        ///作成日：2017/3/16
        ///更新者：大河内
        ///更新日：2017/3/16
        ///カラム論理名
        ///</summary>
        private void txtTanabanEditLieave(object sender, EventArgs e)
        {
            intDBjud = 8;
            lblDspTanabanEdit.Text = "";
            txtGridViewLieave(sender, e, intDBjud);
        }


        ///<summary>
        ///txtGridViewLieave
        ///code入力箇所からフォーカスが外れた時(Grid表示関係)
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/4/6
        ///カラム論理名
        ///</summary>
        private void txtGridViewLieave(object sender, EventArgs e, int intDBjud)
        {
            //データ渡し用
            List<string> lstString = new List<string>();

            //初期化
            strSQL = "";

            //SQL出力後のデータテーブル
            DataTable dtSetData = null;

            //フォーカス時に空白の場合そのままスルー
            if (txtEigyousyo.Text == "" && intDBjud == 1)
            {
                return;
            }
            else if (txtDaibunrui.Text == "" && intDBjud == 2)
            {
                return;
            }
            else if (txtChubunrui.Text == "" && intDBjud == 3)
            {
                return;
            }
            else if (txtMaker.Text == "" && intDBjud == 4)
            {
                return;
            }
            else if (txtTanaban.Text == "" && intDBjud == 5)
            {
                return;
            }
            else if (txtChubunruiEdit.Text == "" && intDBjud == 6)
            {
                return;
            }
            else if (txtMakerEdit.Text == "" && intDBjud == 7)
            {
                return;
            }
            else if (txtTanabanEdit.Text == "" && intDBjud == 8)
            {
                return;
            }

            //データ渡し用
            lstString.Add(txtEigyousyo.Text);
            lstString.Add(txtDaibunrui.Text);
            lstString.Add(txtChubunrui.Text);
            lstString.Add(txtMaker.Text);
            lstString.Add(txtTanaban.Text);
            lstString.Add(txtChubunruiEdit.Text);
            lstString.Add(txtMakerEdit.Text);
            lstString.Add(txtTanabanEdit.Text);

            //処理部に移動
            TanaorosiInput_B tanaorosiinputB = new TanaorosiInput_B();
            //戻り値のDatatableを取り込む
            dtSetData = tanaorosiinputB.txtGridViewLieave(intDBjud, lstString);

            if (dtSetData.Rows.Count != 0)
            {
                switch (intDBjud)
                {
                    case 1://営業所
                        txtEigyousyo.Text = dtSetData.Rows[0]["営業所コード"].ToString();
                        lblDspEigyousyo.Text = dtSetData.Rows[0]["営業所名"].ToString();
                        txtDaibunrui.Focus();
                        break;
                    case 2://大分類
                        txtDaibunrui.Text = dtSetData.Rows[0]["大分類コード"].ToString();
                        lblDspDaibunrui.Text = dtSetData.Rows[0]["大分類名"].ToString();
                        txtChubunrui.Focus();
                        break;
                    case 3://中分類
                        txtChubunrui.Text = dtSetData.Rows[0]["中分類コード"].ToString();
                        lblDspChubunrui.Text = dtSetData.Rows[0]["中分類名"].ToString();
                        txtMaker.Focus();
                        break;
                    case 4://メーカー
                        txtMaker.Text = dtSetData.Rows[0]["メーカーコード"].ToString();
                        lblDspMaker.Text = dtSetData.Rows[0]["メーカー名"].ToString();
                        txtTanaban.Focus();
                        break;
                    case 5://棚番
                        txtTanaban.Text = dtSetData.Rows[0]["棚番"].ToString();
                        lblDspTanaban.Text = dtSetData.Rows[0]["棚番名"].ToString();
                        txtKensaku.Focus();
                        break;
                    case 6://編集中分類
                        txtChubunruiEdit.Text = dtSetData.Rows[0]["中分類コード"].ToString();
                        lblDspChubunEdit.Text = dtSetData.Rows[0]["中分類名"].ToString();
                        txtMakerEdit.Focus();
                        break;
                    case 7://編集メーカー
                        txtMakerEdit.Text = dtSetData.Rows[0]["メーカーコード"].ToString();
                        lblDspMakerEdit.Text = dtSetData.Rows[0]["メーカー名"].ToString();
                        btnF01.Focus();
                        break;
                    case 8://編集棚番
                        txtTanabanEdit.Text = dtSetData.Rows[0]["棚番"].ToString();
                        lblDspTanabanEdit.Text = dtSetData.Rows[0]["棚番名"].ToString();
                        txtChubunruiEdit.Focus();
                        break;
                    default:
                        return;
                }
                //初期化
                intDBjud = 0;
                //SendKeys.Send("{TAB}");
            }
            else
            {
                switch (intDBjud)
                {
                    case 1://営業所
                        lblDspEigyousyo.Text = "";
                        txtEigyousyo.Focus();
                        break;
                    case 2://大分類
                        lblDspDaibunrui.Text = "";
                        txtDaibunrui.Focus();
                        break;
                    case 3://中分類
                        lblDspChubunrui.Text = "";
                        txtChubunrui.Focus();
                        break;
                    case 4://メーカー
                        lblDspMaker.Text = "";
                        txtMaker.Focus();
                        break;
                    case 5://棚番
                        lblDspTanaban.Text = "";
                        return;
                    case 6://編集中分類
                        lblDspChubunEdit.Text = "";
                        txtChubunruiEdit.Focus();
                        break;
                    case 7://編集メーカー
                        lblDspMakerEdit.Text = "";
                        txtMakerEdit.Focus();
                        break;
                    case 8://編集棚番
                        lblDspTanabanEdit.Text = "";
                        txtTanabanEdit.Focus();
                        break;
                    default:
                        return;
                }

                MessageBox.Show("入力された文字列が正しくありません。", "入力項目", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        ///<summary>
        ///setEigyoushoListClose
        ///EigyoushoListCloseが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void setEigyoushoListClose()
        {
            txtEigyousyo.Focus();
        }

        ///<summary>
        ///setDaibunruiListClose
        ///DaibunruiiListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void setDaibunruiListClose()
        {
            txtDaibunrui.Focus();
        }

        ///<summary>
        ///setChubunruiListClose
        ///ChubunruiListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void setChubunruiListClose()
        {
            txtChubunrui.Focus();
        }

        ///<summary>
        ///setMakerListClose
        ///MakerListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void setMakerListClose()
        {
            txtMaker.Focus();
        }

        ///<summary>
        ///setTanabanListClose
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/14
        ///更新者：大河内
        ///更新日：2017/3/14
        ///カラム論理名
        ///</summary>
        public void setTanabanListClose()
        {
            txtTanaban.Focus();
        }

        ///<summary>
        ///setChubunListCloseEdit
        ///ChubunruiListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/15
        ///更新者：大河内
        ///更新日：2017/3/15
        ///カラム論理名
        ///</summary>
        public void setChubunListCloseEdit()
        {
            txtChubunruiEdit.Focus();
        }

        ///<summary>
        ///setMakerListCloseEdit
        ///MakerListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/15
        ///更新者：大河内
        ///更新日：2017/3/15
        ///カラム論理名
        ///</summary>
        public void setMakerListCloseEdit()
        {
            txtMakerEdit.Focus();
        }

        ///<summary>
        ///setTanaListCloseEdit
        ///TanabanListが閉じたらコード記入欄にフォーカス
        ///作成者：大河内
        ///作成日：2017/3/15
        ///更新者：大河内
        ///更新日：2017/3/15
        ///カラム論理名
        ///</summary>
        public void setTanaListCloseEdit()
        {
            txtTanabanEdit.Focus();
        }

        ///<summary>
        ///txtKensakuLeave
        //検索ウィンドウか別テキストボックスに移動
        ///作成者：大河内
        ///作成日：2017/3/15
        ///更新者：大河内
        ///更新日：2017/3/15
        ///カラム論理名
        ///</summary>
        public void txtKensakuLeave(object sender, EventArgs e)
        {
            if(txtKensaku.TextLength > 0)
            {
                ShouhinList shouhinlist = new ShouhinList();
                shouhinlist.Left = 100;
                shouhinlist.StartPosition = FormStartPosition.Manual;
                shouhinlist.intFrmKind = CommonTeisu.FRM_TANAOROSHI;
                shouhinlist.strYMD = txtYMD.Text;
                shouhinlist.strEigyoushoCode = txtEigyousyo.Text;
                shouhinlist.strDaibunruiCode = txtDaibunrui.Text;
                shouhinlist.strChubunruiCode = txtChubunrui.Text;
                shouhinlist.strMakerCode = txtMaker.Text;
                shouhinlist.strKensaku = txtKensaku.Text;
                shouhinlist.Show();
            }
        }

        ///<summary>
        ///txtKensakuLeave
        ///データグリッドビューに直接変更があった場合
        ///作成者：大河内
        ///作成日：2017/3/17
        ///更新者：大河内
        ///更新日：2017/3/17
        ///カラム論理名
        ///</summary>
        private void judDGVCellChanged(object sender, DataGridViewCellEventArgs e)
        {
            blnEditting = true;
        }

    }
}
