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
using KATO.Business.M1160_TokuteimukesakiTanka;

namespace KATO.Form.M1160_TokuteimukesakiTanka
{
    ///<summary>
    ///M1160_TokuteimukesakiTanka
    ///特定向先単価マスタ
    ///作成者：太田
    ///作成日：2017/06/30
    ///更新者：
    ///更新日：
    ///</summary>
    public partial class M1160_TokuteimukesakiTanka : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // 検索文字列の検索前格納
        private string strBfKensa = "";

        // 検索フラグ
        private bool blSelectFlag = false;

        /// <summary>
        /// M1160_TokuteimukesakiTanka
        /// フォーム関係の設定
        /// </summary>
        /// <param name="c"></param>
        public M1160_TokuteimukesakiTanka(Control c)
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
        }

        private void M1160_TokuteimukesakiTanka_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "CBC単価マスタ";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;

            this.btnF06.Text = "F6:表示";
            this.btnF12.Text = STR_FUNC_F12;

            //DataGridViewの初期設定
            SetUpGrid();
            labelSet_Tokuisaki.Focus();
            blSelectFlag = false;
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {

            //列自動生成禁止
            gridTokuteimukesakiTanka.AutoGenerateColumns = false;

            //データをバインド
            
            DataGridViewTextBoxColumn Simukesaki = new DataGridViewTextBoxColumn();
            Simukesaki.DataPropertyName = "仕向先";
            Simukesaki.Name = "仕向先";
            Simukesaki.HeaderText = "仕向先";

            DataGridViewTextBoxColumn Maker = new DataGridViewTextBoxColumn();
            Maker.DataPropertyName = "ﾒｰｶｰ";
            Maker.Name = "ﾒｰｶｰ";
            Maker.HeaderText = "ﾒｰｶｰ";

            DataGridViewTextBoxColumn Kataban = new DataGridViewTextBoxColumn();
            Kataban.DataPropertyName = "型番";
            Kataban.Name = "型番";
            Kataban.HeaderText = "型番";

            DataGridViewTextBoxColumn Tanka = new DataGridViewTextBoxColumn();
            Tanka.DataPropertyName = "単価";
            Tanka.Name = "単価";
            Tanka.HeaderText = "単価";

            DataGridViewTextBoxColumn SaisyuSiireYMD = new DataGridViewTextBoxColumn();
            SaisyuSiireYMD.DataPropertyName = "最終仕入日";
            SaisyuSiireYMD.Name = "最終仕入日";
            SaisyuSiireYMD.HeaderText = "最終仕入日";

            DataGridViewTextBoxColumn SiiresakiCd = new DataGridViewTextBoxColumn();
            SiiresakiCd.DataPropertyName = "仕入先コード";
            SiiresakiCd.Name = "仕入先コード";
            SiiresakiCd.HeaderText = "仕入先コード";

            DataGridViewTextBoxColumn TokuisakiCd = new DataGridViewTextBoxColumn();
            TokuisakiCd.DataPropertyName = "得意先コード";
            TokuisakiCd.Name = "得意先コード";
            TokuisakiCd.HeaderText = "得意先コード";

            DataGridViewTextBoxColumn ShohinCd = new DataGridViewTextBoxColumn();
            ShohinCd.DataPropertyName = "商品コード";
            ShohinCd.Name = "商品コード";
            ShohinCd.HeaderText = "商品コード";


            //個々の幅、文章の寄せ
            setColumn(Simukesaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(Maker, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(Kataban, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 300);
            setColumn(Tanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "0.00", 120);
            setColumn(SaisyuSiireYMD, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter,"yyyy/MM/dd", 150);
            setColumn(SiiresakiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(TokuisakiCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);
            setColumn(ShohinCd, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 150);

            //以下は表示しない
            gridTokuteimukesakiTanka.Columns[5].Visible = false;
            gridTokuteimukesakiTanka.Columns[6].Visible = false;
            gridTokuteimukesakiTanka.Columns[7].Visible = false;


            labelSet_Siiresaki.CodeTxtText = "1800";

        }

        ///<summary>
        ///setColumn
        ///DataGridViewの内部設定
        ///</summary>
        private void setColumn(DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gridTokuteimukesakiTanka.Columns.Add(col);
            if (gridTokuteimukesakiTanka.Columns[col.Name] != null)
            {
                gridTokuteimukesakiTanka.Columns[col.Name].Width = intLen;
                gridTokuteimukesakiTanka.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gridTokuteimukesakiTanka.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;

                if (fmt != null)
                {
                    gridTokuteimukesakiTanka.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }

        /// <summary>
        /// M1160_TokuteimukesakiTanka_KeyDown
        /// キー入力判定
        /// </summary>
        private void M1160_TokuteimukesakiTanka_KeyDown(object sender, KeyEventArgs e)
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
                    this.addTokuteimukesakiTanka();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delTokuteimukesakiTanka();
                    break;
                case Keys.F4:
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.CheckMaster();
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
                    this.addTokuteimukesakiTanka();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    this.delTokuteimukesakiTanka();
                    break;
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F06: // 表示
                    logger.Info(LogUtil.getMessage(this._Title, "表示実行"));
                    this.CheckMaster();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// addTokuteimukesakiTanka
        /// マスタデータを追加
        /// </summary>
        private void addTokuteimukesakiTanka()
        {
            // データ更新用
            List<string> lstItem = new List<string>();

            // データチェック処理
            if (!dataCheack())
            {
                return;
            }

            // ビジネス層のインスタンス生成
            M1160_TokuteimukesakiTanka_B tokuteimukesakitankaB = new M1160_TokuteimukesakiTanka_B();
            try
            {
                // 追加するデータをリストに格納
                lstItem.Add(labelSet_Siiresaki.CodeTxtText);
                lstItem.Add(labelSet_Tokuisaki.CodeTxtText);
                lstItem.Add(txtShohinCd.Text);
                lstItem.Add(txtKataban.Text.Trim());
                //単価のカンマを省く
                txtTanka.Text = txtTanka.Text.Replace(",", "");
                lstItem.Add(txtTanka.Text);
                lstItem.Add(Environment.UserName);

                // 更新実行
                tokuteimukesakitankaB.addTokuteimukesakiTanka(lstItem);

                // メッセージボックスの処理、追加成功の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, CommonTeisu.LABEL_TOUROKU, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                String tmpT = "";
                tmpT = labelSet_Tokuisaki.CodeTxtText;
                
                // テキストボックス内の文字を削除
                delText();
                
                labelSet_Tokuisaki.CodeTxtText = tmpT;
                
                txtKensakuS.Focus();

                //グリッドビュー表示
                CheckMaster();

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
        /// delTokuteimukesakiTanka
        /// マスタデータ削除処理
        /// </summary>
        private void delTokuteimukesakiTanka()
        {
            
            // 空文字判定（得意先）
            if (labelSet_Tokuisaki.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Tokuisaki.Focus();
                return;
            }

            // 得意先コードチェック
            if (labelSet_Tokuisaki.chkTxtTorihikisaki())
            {
                return;
            }

            M1160_TokuteimukesakiTanka_B tokuteimukesakitankaB = new M1160_TokuteimukesakiTanka_B();
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

                lstDeleteItem.Add(labelSet_Siiresaki.CodeTxtText);
                lstDeleteItem.Add(labelSet_Tokuisaki.CodeTxtText);
                lstDeleteItem.Add(txtShohinCd.Text);
                lstDeleteItem.Add(Environment.UserName);

                // 表示中のマスタデータの削除処理
                tokuteimukesakitankaB.delTokuteimukesakiTanka(lstDeleteItem);

                // メッセージボックスの処理、削除成功の場合のウィンドウ（OK）
                basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();

                String tmpT = "";
                tmpT = labelSet_Tokuisaki.CodeTxtText;

                // テキストボックス内の文字を削除
                delText();

                labelSet_Tokuisaki.CodeTxtText = tmpT;

                txtKensakuS.Focus();

                //グリッドビュー表示
                CheckMaster();

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
        /// dataCheack
        /// データチェック処理(グリッドビュー表示)
        /// </summary>
        private Boolean dataCheack()
        {
            // 空文字判定（仕入先）
            if (labelSet_Siiresaki.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                labelSet_Siiresaki.Focus();
                return false;
            }
            // フォーマットチェック（仕入先）
            if (labelSet_Siiresaki.chkTxtTorihikisaki())
            {
                return false;
            }
            // 空文字判定（得意先）
            if (labelSet_Tokuisaki.CodeTxtText.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }
            // フォーマットチェック（得意先）
            if (labelSet_Tokuisaki.chkTxtTorihikisaki())
            {
                return false;
            }
            // 空文字判定（型番）
            if (txtKataban.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }

            // 空文字判定（商品CD）
            if (txtShohinCd.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }

            // 空文字判定（単価）
            if (txtTanka.Text.Equals(""))
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return false;
            }
            //　型チェック（単価）
            if(txtTanka.chkMoneyText())
            {
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            String tmp = "";

            tmp = labelSet_Siiresaki.CodeTxtText;

            //画面の項目内を白紙にする
            delFormClear(this, gridTokuteimukesakiTanka);

            labelSet_Siiresaki.CodeTxtText = tmp;
        }

        /// <summary>
        /// txtKensakuS_KeyDown
        /// 検索文字列用キー入力判定
        /// </summary>
        private void txtKensakuS_KeyDown(object sender, KeyEventArgs e)
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
                    //入力文字で商品検索
                    this.setShohinList();
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
            if(blSelectFlag == false)
            {
                ShouhinList shouhinlist = new ShouhinList(this);
                try
                {
                    //検索項目がある場合
                    if (txtKensakuS.blIsEmpty() == false)
                    {
                        shouhinlist.blKensaku = false;
                    }
                    else
                    {
                        shouhinlist.blKensaku = true;

                    }

                    //商品リストの表示、画面IDを渡す
                    shouhinlist.intFrmKind = CommonTeisu.FRM_TOKUTEIMUKESAKITANKA;
                    shouhinlist.btxtKensaku = txtKensakuS;
                    shouhinlist.btxtShohinCd = txtShohinCd;
                    shouhinlist.btxtHinC1Hinban = txtKataban;
                    shouhinlist.ShowDialog();
                    strBfKensa = txtKensakuS.Text;
                    blSelectFlag = true;
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
            else
            {
                // 検索前の検索文字列がブランク、又は、検索前と検索文字列が違っていた場合
                if (strBfKensa == "" || strBfKensa != txtKensakuS.Text)
                {
                    ShouhinList shouhinlist = new ShouhinList(this);
                    try
                    {
                        //検索項目がある場合
                        if (txtKensakuS.blIsEmpty() == false)
                        {
                            shouhinlist.blKensaku = false;
                        }
                        else
                        {
                            shouhinlist.blKensaku = true;
                        }

                        //商品リストの表示、画面IDを渡す
                        shouhinlist.intFrmKind = CommonTeisu.FRM_TOKUTEIMUKESAKITANKA;
                        shouhinlist.btxtKensaku = txtKensakuS;
                        shouhinlist.btxtShohinCd = txtShohinCd;
                        shouhinlist.btxtHinC1Hinban = txtKataban;
                        shouhinlist.ShowDialog();
                        strBfKensa = txtKensakuS.Text;
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
            }

        }


        ///<summary>
        ///PutIsNull
        ///値がNULLの場合、差し替え文字を挿入する。
        ///</summary>
        private String PutIsNull(string CheckColumn, String ChangeValue)
        {
            if (CheckColumn == null || CheckColumn == "")
            {
                //値の差し替え
                CheckColumn = ChangeValue;
                return CheckColumn;
            }
            return CheckColumn;
        }

        ///<summary>
        ///setShouhinListClose
        ///setShouhinListCloseが閉じたら文字列検索にフォーカス
        ///</summary>
        public void setShohinClose()
        {
            txtKensakuS.Focus();
        }

        /// <summary>
        /// F6:CheckMaster
        /// データグリッドビューにデータを表示
        /// </summary>
        private void CheckMaster()
        {
            //データ検索用
            List<string> lstShohinbetsuRiekiritsuLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //ビジネス層のインスタンス生成
            M1160_TokuteimukesakiTanka_B tokuteimukesakitankaB = new M1160_TokuteimukesakiTanka_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                /*[0]仕入先コード*/
                lstShohinbetsuRiekiritsuLoad.Add(labelSet_Siiresaki.CodeTxtText);
                /*[1]得意先コード*/
                lstShohinbetsuRiekiritsuLoad.Add(labelSet_Tokuisaki.CodeTxtText);
                /*[2]商品コード*/
                lstShohinbetsuRiekiritsuLoad.Add(txtShohinCd.Text);

                gridTokuteimukesakiTanka.Visible = false;

                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = tokuteimukesakitankaB.getMaster(lstShohinbetsuRiekiritsuLoad);

                //データを配置（datagridview)
                gridTokuteimukesakiTanka.DataSource = dtSetView;


                gridTokuteimukesakiTanka.Visible = true;

            }
            catch (Exception ex)
            {
                //エラーロギング
                gridTokuteimukesakiTanka.Visible = true;
                new CommonException(ex);
                return;
            }
            return;
        }

        //グリッドビューのセルをダブルクリックした場合の処理
        private void gridTokuteimukesakiTanka_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridTokuteimukesakiTanka.Rows.Count == 0)
            {
                return;
            }

            //選択行をテキストボックスに設定（カラム順：仕向先、ﾒｰｶｰ、型番、単価、最終仕入日、仕入先コード、得意先コード、商品コード）
            labelSet_Siiresaki.CodeTxtText = gridTokuteimukesakiTanka.CurrentRow.Cells[5].Value.ToString();
            labelSet_Tokuisaki.CodeTxtText = gridTokuteimukesakiTanka.CurrentRow.Cells[6].Value.ToString();
            txtKataban.Text = gridTokuteimukesakiTanka.CurrentRow.Cells[2].Value.ToString();
            txtShohinCd.Text = gridTokuteimukesakiTanka.CurrentRow.Cells[7].Value.ToString();
            txtTanka.Text = decimal.Parse(gridTokuteimukesakiTanka.CurrentRow.Cells[3].Value.ToString()).ToString("#,0");
            
        }

        //商品CDのフォーカスが外れた場合
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

            //データ検索用
            List<string> lstShohinbetsuRiekiritsuLoad = new List<string>();

            //検索時のデータ取り出し先
            DataTable dtSetView;

            //ビジネス層のインスタンス生成
            M1160_TokuteimukesakiTanka_B tokuteimukesakitankaB = new M1160_TokuteimukesakiTanka_B();
            try
            {
                //データの存在確認を検索する情報を入れる
                /*[0]商品コード*/
                lstShohinbetsuRiekiritsuLoad.Add(txtShohinCd.Text);

                //ビジネス層、データグリッドビュー表示用ロジックに移動
                dtSetView = tokuteimukesakitankaB.getShohinData(lstShohinbetsuRiekiritsuLoad);


                if (dtSetView.Rows.Count > 0)
                {
                    txtKataban.Text = dtSetView.Rows[0]["Ｃ１"].ToString();
                    txtKataban.Text += " " + PutIsNull(dtSetView.Rows[0]["Ｃ２"].ToString(), "");
                    txtKataban.Text += " " + PutIsNull(dtSetView.Rows[0]["Ｃ３"].ToString(), "");
                    txtKataban.Text += " " + PutIsNull(dtSetView.Rows[0]["Ｃ４"].ToString(), "");
                    txtKataban.Text += " " + PutIsNull(dtSetView.Rows[0]["Ｃ５"].ToString(), "");
                    txtKataban.Text += " " + PutIsNull(dtSetView.Rows[0]["Ｃ６"].ToString(), "");
                    
                }

            }
            catch (Exception ex)
            {
                //エラーロギング
                new CommonException(ex);
                return;
            }
        }

        //得意先コードのフォーカスが外れた場合の処理
        private void labelSet_Tokuisaki_Leave(object sender, EventArgs e)
        {
            //マスターチェックメソッドへ
            CheckMaster();
        }
    }
}
