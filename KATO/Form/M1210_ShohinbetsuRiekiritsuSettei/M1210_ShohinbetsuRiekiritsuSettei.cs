using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
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
using KATO.Business.M1210_ShohinbetsuRiekiritsuSettei;

namespace KATO.Form.M1210_ShohinbetsuRiekiritsuSettei
{
    ///<summary>
    ///M1210_ShohinbetsuRiekiritsuSettei
    ///商品別利益率設定
    ///作成者：TMSOL太田
    ///作成日：2017/06/28
    ///更新者：
    ///更新日：
    ///</summary>
    public partial class M1210_ShohinbetsuRiekiritsuSettei : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// M1210_ShohinbetsuRiekiritsuSettei
        /// フォーム関係の設定
        /// </summary>
        /// <param name="c"></param>
        public M1210_ShohinbetsuRiekiritsuSettei(Control c)
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

        private void M1210_ShohinbetsuRiekiritsuSettei_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "商品別利益率承認設定";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            
            this.btnF06.Text = "F6:売上実績確認";
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            this.btnF09.Enabled = false;

            //DataGridViewの初期設定
            SetUpGrid();
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {

            //列自動生成禁止
            gridShohinbetsuRiekiritsu.AutoGenerateColumns = false;

            //データをバインド
            DataGridViewTextBoxColumn Code = new DataGridViewTextBoxColumn();
            Code.DataPropertyName = "得意先コード";
            Code.Name = "得意先コード";
            Code.HeaderText = "コード";

            DataGridViewTextBoxColumn TokuisakiName = new DataGridViewTextBoxColumn();
            TokuisakiName.DataPropertyName = "得意先名";
            TokuisakiName.Name = "得意先名";
            TokuisakiName.HeaderText = "得意先名";

            DataGridViewTextBoxColumn Shinamei_kataban = new DataGridViewTextBoxColumn();
            Shinamei_kataban.DataPropertyName = "品名型式";
            Shinamei_kataban.Name = "品名型式";
            Shinamei_kataban.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn Riekiritsu = new DataGridViewTextBoxColumn();
            Riekiritsu.DataPropertyName = "利益率";
            Riekiritsu.Name = "利益率";
            Riekiritsu.HeaderText = "掛率";

            DataGridViewTextBoxColumn Tanka = new DataGridViewTextBoxColumn();
            Tanka.DataPropertyName = "単価";
            Tanka.Name = "単価";
            Tanka.HeaderText = "単価";

            DataGridViewTextBoxColumn SetteiOrKaijo = new DataGridViewTextBoxColumn();
            SetteiOrKaijo.DataPropertyName = "設定";
            SetteiOrKaijo.Name = "設定";
            SetteiOrKaijo.HeaderText = "設定:1/解除:0";

            DataGridViewTextBoxColumn ShohinCd = new DataGridViewTextBoxColumn();
            ShohinCd.DataPropertyName = "商品コード";
            ShohinCd.Name = "商品コード";
            ShohinCd.HeaderText = "商品コード";

            DataGridViewTextBoxColumn DaibunruiCd = new DataGridViewTextBoxColumn();
            DaibunruiCd.DataPropertyName = "大分類コード";
            DaibunruiCd.Name = "大分類コード";
            DaibunruiCd.HeaderText = "大分類コード";

            DataGridViewTextBoxColumn TyubunruiCd = new DataGridViewTextBoxColumn();
            TyubunruiCd.DataPropertyName = "中分類コード";
            TyubunruiCd.Name = "中分類コード";
            TyubunruiCd.HeaderText = "中分類コード";

            DataGridViewTextBoxColumn MakerCd = new DataGridViewTextBoxColumn();
            MakerCd.DataPropertyName = "メーカーコード";
            MakerCd.Name = "メーカーコード";
            MakerCd.HeaderText = "メーカーコード";


            //個々の幅、文章の寄せ
            setColumn(Code, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 80);
            setColumn(TokuisakiName, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 330);
            setColumn(Shinamei_kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 330);
            setColumn(Riekiritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0.0", 100);
            setColumn(Tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(SetteiOrKaijo, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(ShohinCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(DaibunruiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(TyubunruiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(MakerCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);

            //商品コードは表示しない
            gridShohinbetsuRiekiritsu.Columns[6].Visible = false;
            gridShohinbetsuRiekiritsu.Columns[7].Visible = false;
            gridShohinbetsuRiekiritsu.Columns[8].Visible = false;
            gridShohinbetsuRiekiritsu.Columns[9].Visible = false;

        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridShohinbetsuRiekiritsu.Columns.Add(col);
            if (gridShohinbetsuRiekiritsu.Columns[col.Name] != null)
            {
                gridShohinbetsuRiekiritsu.Columns[col.Name].Width = intLen;
                gridShohinbetsuRiekiritsu.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridShohinbetsuRiekiritsu.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridShohinbetsuRiekiritsu.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        ///<summary>
        ///PutIsNull
        ///値がNULLの場合、差し替え文字を挿入する。
        ///</summary>
        private String PutIsNull(string CheckColumn,String ChangeValue)
        {
            if (CheckColumn == null || CheckColumn =="")
            {
                //値の差し替え
                CheckColumn = ChangeValue;
                return CheckColumn;
            }
            return CheckColumn;
        }

        //商品CDテキストボックスのフォーカスが外れた場合
        private void txtShohinCd_Leave(object sender, EventArgs e)
        {
            ChangetxtShohinCd();
        }

        ///<summary>
        ///ChangetxtShohinCd
        ///商品CDが変わった場合の処理
        ///</summary>
        private void ChangetxtShohinCd()
        {
            if (txtShohinCd.Text == "")
            {
                return;
            }

            txtTanka.Text = "";
            txtRiekiritsu.Text = "";

            //データ検索用
            List<string> lstShohinbetsuRiekiritsuLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //ビジネス層のインスタンス生成
            M1210_ShohinbetsuRiekiritsuSettei_B shohinbetsuriekiritsuB = new M1210_ShohinbetsuRiekiritsuSettei_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                /*[0]得意先コード*/
                lstShohinbetsuRiekiritsuLoad.Add(txtShohinCd.Text);
                
                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = shohinbetsuriekiritsuB.getShohinData(lstShohinbetsuRiekiritsuLoad);
                

                if (dtSetView.Rows.Count > 0)
                {
                    txtKataban.Text = dtSetView.Rows[0]["Ｃ１"].ToString();
                    txtKataban.Text += " "+ PutIsNull(dtSetView.Rows[0]["Ｃ２"].ToString(),"");
                    txtKataban.Text += " " + PutIsNull(dtSetView.Rows[0]["Ｃ３"].ToString(), "");
                    txtKataban.Text += " " + PutIsNull(dtSetView.Rows[0]["Ｃ４"].ToString(), "");
                    txtKataban.Text += " " + PutIsNull(dtSetView.Rows[0]["Ｃ５"].ToString(), "");
                    txtKataban.Text += " " + PutIsNull(dtSetView.Rows[0]["Ｃ６"].ToString(), "");

                    txtTeika.Text = decimal.Parse(dtSetView.Rows[0]["定価"].ToString()).ToString("#,0");

                }

            }
            catch (Exception ex)
            {
                //エラーロギング
                gridShohinbetsuRiekiritsu.Visible = true;
                new CommonException(ex);
                return;
            }
        }

        //掛率テキストボックスのフォーカスが外れた場合
        private void txtRiekiritsu_Leave(object sender, EventArgs e)
        {
            ChangetxtRiekiritsu();
        }

        ///<summary>
        ///ChangetxtRiekiritsu
        ///掛率が変わった場合の処理
        ///</summary>
        private void ChangetxtRiekiritsu()
        {
            if (txtRiekiritsu.Text == "")
            {
                return;
            }
            else if(txtTeika.Text == "")
            {
                return;
            }
            else if (txtTeika.Text == "0")
            {
                return;
            }

            txtTanka.Text = "";
            txtTanka.Text = (decimal.Parse(txtTeika.Text) * decimal.Parse(txtRiekiritsu.Text) / 100).ToString("#,0");

        }

        //単価テキストボックスのフォーカスが外れた場合
        private void txtTanka_Leave(object sender, EventArgs e)
        {
            ChangetxtTanka();
        }

        ///<summary>
        ///ChangetxtTanka
        ///単価が変わった場合の処理
        ///</summary>
        private void ChangetxtTanka()
        {
            if (txtTanka.Text == "")
            {
                return;
            }
            else if (txtTeika.Text == "")
            {
                return;
            }
            else if (txtTeika.Text == "0")
            {
                return;
            }

            txtRiekiritsu.Text = "";
            txtRiekiritsu.Text = (decimal.Parse(txtTanka.Text) / decimal.Parse(txtTeika.Text) * 100).ToString("0.0");
        }
        
        /// <summary>
        /// M1210_ShohinbetsuRiekiritsuSettei
        /// キー入力判定
        /// </summary>
        private void M1210_ShohinbetsuRiekiritsuSettei_KeyDown(object sender, KeyEventArgs e)
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
                    logger.Info(LogUtil.getMessage(this._Title, "追加実行"));
                    this.addRiekiritsu();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delRiekiritsu();
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    logger.Info(LogUtil.getMessage(this._Title, "売上実績確認実行"));
                    //売上実績確認フォームへ
                    showUriageJissekiKakunin();
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

        /// <summary>
        /// judBtnClick
        /// ボタンの反応
        /// </summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 追加
                    logger.Info(LogUtil.getMessage(this._Title, "追加実行"));
                    this.addRiekiritsu();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delRiekiritsu();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F06: // 売上実績確認
                    logger.Info(LogUtil.getMessage(this._Title, "売上実績確認実行"));
                    //売上実績フォームへ
                    showUriageJissekiKakunin();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        ///<summary>
        ///txtBox_KeyDown
        ///キー入力判定（無機能テキストボックス_BaseText）
        ///</summary>
        private void txtBox_KeyDown(object sender, KeyEventArgs e)
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
        /// <summary>
        /// showUriageJissekiKakunin
        /// 売上実績確認フォームを開く処理
        /// </summary>
        private void showUriageJissekiKakunin()
        {
            if (gridShohinbetsuRiekiritsu.Rows.Count <= 0)
            {
                return;
            }

            string sstr = "";
            string tokuisakicd = "";
            string sinamei_kataban = "";

            //選択行の得意先コードを取得する。
            tokuisakicd = gridShohinbetsuRiekiritsu.CurrentRow.Cells[0].Value.ToString();

            //選択行の品名・型番を取得する。
            sinamei_kataban = gridShohinbetsuRiekiritsu.CurrentRow.Cells[2].Value.ToString();

            //品名・型番からメーカー名を省く
            //sstr = txtKataban.Text.Substring(txtKataban.Text.IndexOf(" "));
            sstr = sinamei_kataban.Substring(sinamei_kataban.IndexOf(" "));
            sstr.Replace(" ", "");

            //売上実績フォームを開く処理
            int intFrmKind = 1210;

            D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin uriagejissekikakunin =
                new D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this, intFrmKind, tokuisakicd, sstr);
            uriagejissekikakunin.ShowDialog();
        }

        /// <summary>
        /// addRiekiritsu
        /// マスタデータを追加
        /// </summary>
        private void addRiekiritsu()
        {
            // データ更新用
            List<string> lstItem = new List<string>();

            // データチェック処理
            if (!dataCheack())
            {
                return;
            }

            // 空文字判定（掛率、単価）
            if (txtRiekiritsu.Text.Equals("") && txtTanka.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, "掛率、単価はいずれかを指定してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

            // 掛率にフォーカスがある場合
            if (txtRiekiritsu.Focused)
            {
                // 単価を再計算
                ChangetxtRiekiritsu();
            }

            // 単価にフォーカスがある場合
            if (txtTanka.Focused)
            {
                // 掛率を再計算
                ChangetxtTanka();
            }

            // ビジネス層のインスタンス生成
            M1210_ShohinbetsuRiekiritsuSettei_B riekiritsuB = new M1210_ShohinbetsuRiekiritsuSettei_B();
            try
            {
                // 追加するデータをリストに格納
                lstItem.Add(labelSet_Tokuisaki.CodeTxtText);
                lstItem.Add(txtShohinCd.Text);
                lstItem.Add(txtRiekiritsu.Text);
                lstItem.Add(txtTanka.Text);
                
                if (razioSettei.judCheckBtn().Equals(0))
                {
                    lstItem.Add("1");
                }
                else
                {
                    lstItem.Add("0");
                }
                lstItem.Add(Environment.UserName);

                // 更新実行
                riekiritsuB.addRiekiritsu(lstItem);

                // メッセージボックスの処理、追加成功の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                // 検索条件を格納
                string strBfTokuisakiS = labelSet_TokuisakiS.CodeTxtText;
                string strBfTantoushaS = labelSet_TantoushaS.CodeTxtText;
                string strBfSinamei_Kataban = txtSinamei_KatabanS.Text;

                // テキストボックス内の文字を削除
                delText();

                labelSet_TokuisakiS.CodeTxtText = strBfTokuisakiS;
                labelSet_TantoushaS.CodeTxtText = strBfTantoushaS;
                txtSinamei_KatabanS.Text = strBfSinamei_Kataban;

                // データグリッドビューにデータを表示
                setViewGrid();
            }
            catch (Exception ex)
            {
                // メッセージボックスの処理、追加失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                // エラーロギング
                new CommonException(ex);
                return;
            }
            return;
        }

        /// <summary>
        /// dataCheack
        /// データチェック処理
        /// </summary>
        private Boolean dataCheack()
        {
            // 空文字判定（得意先）
            if (labelSet_Tokuisaki.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tokuisaki.Focus();
                return false;
            }
            // 存在チェック（得意先）
            if (labelSet_Tokuisaki.chkTxtTorihikisaki())
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_MISS, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tokuisaki.Focus();
                return false;
            }

            // 空文字判定（商品CD）
            if (txtShohinCd.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tokuisaki.Focus();
                return false;
            }


            return true;
            
        }

        /// <summary>
        /// delRiekiritsu
        /// マスタデータ削除処理
        /// </summary>
        private void delRiekiritsu()
        {
            // データチェック処理
            if (!dataCheack())
            {
                return;
            }

            M1210_ShohinbetsuRiekiritsuSettei_B riekiritsuB = new M1210_ShohinbetsuRiekiritsuSettei_B();
            try
            {
                List<string> lstDeleteItem = new List<string>();

                // メッセージボックスの処理、の場合のウィンドウ（YES,NO）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "表示中のレコードを削除します。よろしいですか。", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);

                // NOが押された場合
                if (basemessagebox.ShowDialog() == DialogResult.No)
                {
                    return;
                }

                lstDeleteItem.Add(labelSet_Tokuisaki.CodeTxtText);
                lstDeleteItem.Add(txtShohinCd.Text);
                lstDeleteItem.Add(Environment.UserName);

                // 表示中のマスタデータの削除処理
                riekiritsuB.delRiekiritsu(lstDeleteItem);

                // メッセージボックスの処理、削除成功の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                // テキストボックス内の文字を削除
                delText();

                // データグリッドビューにデータを表示
                setViewGrid();

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、削除失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, "削除が失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

            }
            return;
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            

            //画面の項目内を白紙にする
            delFormClear(this, gridShohinbetsuRiekiritsu);

        }

        /// <summary>
        /// txtKensaku_KeyDown
        /// 検索文字列用キー入力判定
        /// </summary>
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
                    // 検索文字列に値が入っている場合、商品検索を呼び出す
                    if (txtKensakuS.Text != "")
                    {
                        //入力文字で商品検索
                        this.setShohinList();
                    }
                    else
                    {
                        //TABボタンと同じ効果
                        SendKeys.Send("{TAB}");
                    }
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
                    //商品フォームを開く
                    this.setShohinList();
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
        ///setShohinList
        ///商品リストに移動
        ///</summary>
        private void setShohinList()
        {
            ShouhinList shouhinlist = new ShouhinList(this);
            try
            {
                //検索項目に一つでも記入がある場合
                if (labelSet_Daibunrui.codeTxt.blIsEmpty() == false &&
                    labelSet_Chubunrui.codeTxt.blIsEmpty() == false &&
                    labelSet_Maker.codeTxt.blIsEmpty() == false &&
                    txtKensakuS.blIsEmpty() == false)
                {
                    shouhinlist.blKensaku = false;
                }
                else
                {
                    shouhinlist.blKensaku = true;
                }

                //商品リストの表示、画面IDを渡す
                shouhinlist.intFrmKind = CommonTeisu.FRM_SHOHINBETSURIEKIRITSUSETTEI;
                shouhinlist.lsDaibunrui = labelSet_Daibunrui;
                shouhinlist.lsChubunrui = labelSet_Chubunrui;
                shouhinlist.lsMaker = labelSet_Maker;
                shouhinlist.btxtKensaku = txtKensakuS;
                shouhinlist.btxtShohinCd = txtShohinCd;
                shouhinlist.bmtxtTeika = txtTeika;
                shouhinlist.btxtHinC1Hinban = txtKataban;
                shouhinlist.ShowDialog();
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
        ///setShouhinListClose
        ///setShouhinListCloseが閉じたら文字列検索にフォーカス
        ///</summary>
        public void setShohinClose()
        {
            txtKensakuS.Focus();
        }

        //検索ボタン押下時処理
        private void baseButton_kensaku_Click(object sender, EventArgs e)
        {
            //グリッドビュー表示処理へ
            setViewGrid();
        }

        /// <summary>
        /// setViewGrid
        /// データグリッドビューにデータを表示
        /// </summary>
        private void setViewGrid()
        {
            //データ検索用
            List<string> lstShohinbetsuRiekiritsuLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //ビジネス層のインスタンス生成
            M1210_ShohinbetsuRiekiritsuSettei_B shohinbetsuriekiritsuB = new M1210_ShohinbetsuRiekiritsuSettei_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                /*[0]得意先コード*/
                lstShohinbetsuRiekiritsuLoad.Add(labelSet_TokuisakiS.CodeTxtText);
                /*[1]担当者コード*/
                lstShohinbetsuRiekiritsuLoad.Add(labelSet_TantoushaS.CodeTxtText);
                /*[2]品名・型番*/
                lstShohinbetsuRiekiritsuLoad.Add(txtSinamei_KatabanS.Text);
                /*[3]ラジオボタン１（得意先・品名・掛率・単価）*/
                lstShohinbetsuRiekiritsuLoad.Add(razioOrderS1.judCheckBtn().ToString());
                /*[4]ラジオボタン２（Ａ－Ｚ・Ｚ－Ａ）*/
                lstShohinbetsuRiekiritsuLoad.Add(razioOrderS2.judCheckBtn().ToString());

                gridShohinbetsuRiekiritsu.Visible = false;

                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = shohinbetsuriekiritsuB.getShohinbetsuRiekiritsu(lstShohinbetsuRiekiritsuLoad);

                //データを配置（datagridview)
                gridShohinbetsuRiekiritsu.DataSource = dtSetView;


                gridShohinbetsuRiekiritsu.Visible = true;
            }
            catch (Exception ex)
            {
                //エラーロギング
                gridShohinbetsuRiekiritsu.Visible = true;
                new CommonException(ex);
                return;
            }
            return;
        }

        //グリッドビューのセルをダブルクリックした場合の処理
        private void gridShohinbetsuRiekiritsu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridShohinbetsuRiekiritsu.Rows.Count == 0)
            {
                return;
            }

            //選択行をテキストボックスに設定（カラム順：コード、得意先名、品名・型番、掛率、単価、設定・解除、商品コード）
            labelSet_Tokuisaki.CodeTxtText = gridShohinbetsuRiekiritsu.CurrentRow.Cells[0].Value.ToString();
            txtShohinCd.Text = gridShohinbetsuRiekiritsu.CurrentRow.Cells[6].Value.ToString();

            ChangetxtShohinCd();

            txtKataban.Text = gridShohinbetsuRiekiritsu.CurrentRow.Cells[2].Value.ToString();

            //掛率が空白ではない場合
            if (gridShohinbetsuRiekiritsu.CurrentRow.Cells[3].Value.ToString() != "")
            {
                txtRiekiritsu.Text = decimal.Parse(gridShohinbetsuRiekiritsu.CurrentRow.Cells[3].Value.ToString()).ToString("0.0");
            }
            ChangetxtRiekiritsu();

            txtTanka.Text = decimal.Parse(gridShohinbetsuRiekiritsu.CurrentRow.Cells[4].Value.ToString()).ToString("#,0");

            //追加仕様、大分類、中分類、メーカーを表示
            labelSet_Daibunrui.CodeTxtText = gridShohinbetsuRiekiritsu.CurrentRow.Cells[7].Value.ToString();
            labelSet_Chubunrui.CodeTxtText = gridShohinbetsuRiekiritsu.CurrentRow.Cells[8].Value.ToString();
            labelSet_Maker.CodeTxtText = gridShohinbetsuRiekiritsu.CurrentRow.Cells[9].Value.ToString();


            //掛率算出
            if (txtTeika.Text != "")
            {
                if (txtTeika.Text != "0")
                {
                    txtRiekiritsu.Text = (decimal.Parse(txtTanka.Text) / decimal.Parse(txtTeika.Text) * 100).ToString("0.0");
                }
            }
            // 大分類名ラベル取得
            labelSet_Daibunrui.chkTxtDaibunrui();

            // 中分類名ラベル取得
            labelSet_Chubunrui.chkTxtChubunrui(labelSet_Daibunrui.CodeTxtText);

            //ラジオボタン設定
            if (gridShohinbetsuRiekiritsu.CurrentRow.Cells[5].Value.ToString() == "  1")
            {
                razioSettei.radbtn0.Checked = true;
            }
            else
            {
                razioSettei.radbtn1.Checked = true;
            }
        }
    }
}
