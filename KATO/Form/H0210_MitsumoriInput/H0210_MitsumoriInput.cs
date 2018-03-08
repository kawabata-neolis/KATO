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
using KATO.Common.Ctl;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.H0210_MitsumoriInput;
using ClosedXML.Excel;
using KATO.Common.Form;

namespace KATO.Form.H0210_MitsumoriInput
{
    public partial class H0210_MitsumoriInput : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string strPdfPath = System.Configuration.ConfigurationManager.AppSettings["pdfpath"];

        private Boolean bFirst = true;
        private Boolean bCdflg = true;

        string oldHinmei = "";

        private DataTable dt = new DataTable();

        private int intRowIdx = 0;
        public int IntRowIdx
        {
            get
            {
                return intRowIdx;
            }
            set
            {
                intRowIdx = value;
            }

        }

        private string strHinmei = "";
        public string StrHinmei
        {
            get
            {
                return strHinmei;
            }
            set
            {
                strHinmei = value;
            }

        }

        private string strDaibunrui = "";
        public string StrDaibunrui
        {
            get
            {
                return strDaibunrui;
            }
            set
            {
                strDaibunrui = value;
            }

        }

        private string strChubunrui = "";
        public string StrChubunrui
        {
            get
            {
                return strChubunrui;
            }
            set
            {
                strChubunrui = value;
            }

        }

        private string strMaker = "";
        public string StrMaker
        {
            get
            {
                return strMaker;
            }
            set
            {
                strMaker = value;
            }

        }

        private Boolean updFlg = false;
        public Boolean UpdFlg
        {
            get
            {
                return updFlg;
            }
            set
            {
                updFlg = value;
            }
        }

        public int intPrint = 0;

        int RowIndex = 0;
        int ColIndex = 0;
        int intZai1Num = 0;
        int intZai2Num = 0;

        bool keyFlgF9 = true;
        bool editFlg = true;
        string defUser = "";
        string defEigyo = "";
        string oldNum = "";

        D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin uriKakunin = null;

        public H0210_MitsumoriInput(Control c)
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

            txtIdx.Text = "0";

            txtMode.Focus();
        }

        private void H0210_MitsumoriInput_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "見積書入力";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            btnF01.Text = STR_FUNC_F1;
            btnF02.Text = "受注入力";
            btnF03.Text = STR_FUNC_F3;
            btnF04.Text = STR_FUNC_F4;
            //btnF05.Text = "選択";
            btnF06.Text = "F6:行削除";
            btnF07.Text = "F7:行挿入";
            //btnF08.Text = "終わり";
            btnF09.Text = STR_FUNC_F9;
            btnF10.Text = "仕入詳細";
            btnF11.Text = STR_FUNC_F11;
            btnF12.Text = STR_FUNC_F12;

            H0210_MitsumoriInput_B inputB = new H0210_MitsumoriInput_B();
            try
            {
                DataTable dt = inputB.getUserInfo(Environment.UserName);

                if (dt != null && dt.Rows.Count > 0)
                {
                    defUser = dt.Rows[0]["担当者コード"].ToString();
                    defEigyo = dt.Rows[0]["営業所コード"].ToString();
                }
                lsTantousha.CodeTxtText = defUser;
                lsTantousha.chkTxtTantosha();
                lsEigyosho.CodeTxtText = defEigyo;
                lsEigyosho.chkTxtEigyousho();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

            txtMYMD.Text = DateTime.Now.ToString("yyyy/MM/dd");

            gridMitsmori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            gridMitsmori.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            gridMitsmori.ColumnHeadersHeight = 36;
            gridMitsmori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            SetUpGrid();

            for (int i = 0; i < 200; i++)
            {
                dt.Rows.InsertAt(dt.NewRow(), 0);
            }
            gridMitsmori.DataSource = dt;
            for (int i = 0; i < 200; i++)
            {
                gridMitsmori[0, i].Value = (i + 1).ToString();
                gridMitsmori[1, i].Value = "1";
            }
            gridMitsmori.CurrentCell = gridMitsmori[0, 0];
        }

        // メニューボタン・Fキー操作
        private void Form7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                btnF01.Focus();
                updMitsumori();
            }
            else if (e.KeyData == Keys.F2)
            {
                openJuchu();
            }
            else if (e.KeyData == Keys.F3)
            {
                delMitsumori();
            }
            else if (e.KeyData == Keys.F4)
            {
                clearInput();
            }
            else if (e.KeyData == Keys.F6)
            {
                delRow();
            }
            else if (e.KeyData == Keys.F7)
            {
                addRow();
            }
            else if (e.KeyData == Keys.F8)
            {
            }
            else if (e.KeyData == Keys.F9)
            {
                if (keyFlgF9 == true)
                {
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    if (this.ActiveControl != null && this.ActiveControl.Name.Equals("txtMNum"))
                    {
                        return;
                    }
                    oldNum = txtMNum.Text;
                    getMitsumoriInfo();
                    txtMYMD.Focus();
                }
                else
                {
                    keyFlgF9 = true;
                }
            }
            else if (e.KeyData == Keys.F10)
            {
                if (editFlg == false)
                {
                    logger.Info(LogUtil.getMessage(this._Title, "仕入詳細印刷実行"));
                    printDetail(strPdfPath + "_" + txtMNum.Text + "_M.pdf");
                }
                else
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "登録してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                }
            }
            else if (e.KeyData == Keys.F11)
            {
                if (editFlg == false)
                {
                    logger.Info(LogUtil.getMessage(this._Title, "見積書印刷実行"));
                    printMitsumori(strPdfPath + "_" + txtMNum.Text + "_H.pdf");
                }
                else
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "登録してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                }
            }
            else if (e.KeyData == Keys.F12)
            {
                this.Close();
            }
            else if (e.KeyData == Keys.Enter)
            {
                //this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void btnFKeys_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    logger.Info(LogUtil.getMessage(this._Title, "登録実行"));
                    updMitsumori();
                    break;
                case STR_BTN_F02: // 受注入力
                    logger.Info(LogUtil.getMessage(this._Title, "受注入力"));
                    openJuchu();
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    delMitsumori();
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    clearInput();
                    break;
                case STR_BTN_F06: // 行削除
                    logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                    delRow();
                    break;
                case STR_BTN_F07: // 行挿入
                    logger.Info(LogUtil.getMessage(this._Title, "行挿入実行"));
                    addRow();
                    break;
                case STR_BTN_F08: // 終わり
                    break;
                case STR_BTN_F09: // 検索
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    if (this.ActiveControl != null && this.ActiveControl.Name.Equals("txtMNum"))
                    {
                        break;
                    }
                    oldNum = txtMNum.Text;
                    getMitsumoriInfo();
                    txtMYMD.Focus();
                    break;
                case STR_BTN_F10:
                    if (editFlg == false)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "仕入詳細印刷実行"));
                        printDetail(strPdfPath + "_" + txtMNum.Text + "_M.pdf");
                    }
                    else
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "登録してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                    }
                    break;
                case STR_BTN_F11: // 印刷
                    if (editFlg == false)
                    {
                        logger.Info(LogUtil.getMessage(this._Title, "見積書印刷実行"));
                        printMitsumori(strPdfPath + "_" + txtMNum.Text + "_H.pdf");
                    }
                    else
                    {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "登録してください。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                        basemessagebox.ShowDialog();
                    }
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        // Grid設定
        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            gridMitsmori.AutoGenerateColumns = false;

            //データをバインド

            #region
            #region
            DataGridViewTextBoxColumn txtRowNum = new DataGridViewTextBoxColumn(); // 0
            txtRowNum.DataPropertyName = "行番号";
            txtRowNum.Name = "行番号";
            txtRowNum.HeaderText = "No.";
            txtRowNum.ReadOnly = true;

            DataGridViewCheckBoxColumn cbRow = new DataGridViewCheckBoxColumn(); // 1
            cbRow.DataPropertyName = "印";
            cbRow.Name = "印";
            cbRow.HeaderText = "印";
            cbRow.TrueValue = "1";
            cbRow.FalseValue = "0";
            cbRow.Width = 26;
            cbRow.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cbRow.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cbRow.SortMode = DataGridViewColumnSortMode.NotSortable;


            DataGridViewTextBoxColumn hinmei = new DataGridViewTextBoxColumn(); // 2
            hinmei.DataPropertyName = "品名型式";
            hinmei.Name = "品名型式";
            hinmei.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn suryo = new DataGridViewTextBoxColumn(); // 3
            suryo.DataPropertyName = "数量";
            suryo.Name = "数量";
            suryo.HeaderText = "数量";

            DataGridViewTextBoxColumn teika = new DataGridViewTextBoxColumn(); // 4
            teika.DataPropertyName = "定価";
            teika.Name = "定価";
            teika.HeaderText = "定価";

            DataGridViewTextBoxColumn mitsumoriTanka = new DataGridViewTextBoxColumn(); // 5
            mitsumoriTanka.DataPropertyName = "見積単価";
            mitsumoriTanka.Name = "見積単価";
            mitsumoriTanka.HeaderText = "見積単価";

            DataGridViewTextBoxColumn kakeritsu = new DataGridViewTextBoxColumn(); // 6
            kakeritsu.DataPropertyName = "掛率";
            kakeritsu.Name = "掛率";
            kakeritsu.HeaderText = "掛率";
            kakeritsu.ReadOnly = true;

            DataGridViewTextBoxColumn kingaku = new DataGridViewTextBoxColumn(); // 7
            kingaku.DataPropertyName = "金額";
            kingaku.Name = "金額";
            kingaku.HeaderText = "金額";
            kingaku.ReadOnly = true;

            DataGridViewTextBoxColumn shiireTanka = new DataGridViewTextBoxColumn(); // 8
            shiireTanka.DataPropertyName = "仕入単価";
            shiireTanka.Name = "仕入単価";
            shiireTanka.HeaderText = "仕入単価";
            shiireTanka.ReadOnly = true;

            DataGridViewTextBoxColumn arari = new DataGridViewTextBoxColumn(); // 9
            arari.DataPropertyName = "粗利金額";
            arari.Name = "粗利金額";
            arari.HeaderText = "粗利";
            arari.ReadOnly = true;

            DataGridViewTextBoxColumn arariritsu = new DataGridViewTextBoxColumn(); // 10
            arariritsu.DataPropertyName = "率";
            arariritsu.Name = "率";
            arariritsu.HeaderText = "率";
            arariritsu.ReadOnly = true;

            DataGridViewTextBoxColumn biko = new DataGridViewTextBoxColumn(); // 11
            biko.DataPropertyName = "備考";
            biko.Name = "備考";
            biko.HeaderText = "備考";

            DataGridViewTextBoxColumn shiiresaki = new DataGridViewTextBoxColumn(); // 12
            shiiresaki.DataPropertyName = "仕入先名";
            shiiresaki.Name = "仕入先名";
            shiiresaki.HeaderText = "仕入先";
            shiiresaki.ReadOnly = true;

            DataGridViewTextBoxColumn insatsu = new DataGridViewTextBoxColumn(); // 13
            insatsu.DataPropertyName = "印刷フラグ";
            insatsu.Name = "印刷フラグ";
            insatsu.HeaderText = "印刷";
            #endregion

            #region
            DataGridViewTextBoxColumn shiireCd1 = new DataGridViewTextBoxColumn(); // 14
            shiireCd1.DataPropertyName = "仕入先コード１";
            shiireCd1.Name = "仕入先コード１";
            shiireCd1.HeaderText = "";
            shiireCd1.ReadOnly = true;
            shiireCd1.Visible = false;

            DataGridViewTextBoxColumn shiireName1 = new DataGridViewTextBoxColumn(); // 15
            shiireName1.DataPropertyName = "仕入先名１";
            shiireName1.Name = "仕入先名１";
            shiireName1.HeaderText = "材料１\r\n仕入先名１";
            shiireName1.ReadOnly = true;

            DataGridViewTextBoxColumn shiireTanka1 = new DataGridViewTextBoxColumn(); // 16
            shiireTanka1.DataPropertyName = "仕入単価１";
            shiireTanka1.Name = "仕入単価１";
            shiireTanka1.HeaderText = "材料１\r\n仕入単価１";
            shiireTanka1.ReadOnly = true;

            DataGridViewTextBoxColumn shiireKin1 = new DataGridViewTextBoxColumn(); // 17
            shiireKin1.DataPropertyName = "仕入金額１";
            shiireKin1.Name = "仕入金額１";
            shiireKin1.HeaderText = "材料１\r\n仕入金額１";
            shiireKin1.ReadOnly = true;

            DataGridViewTextBoxColumn arari1 = new DataGridViewTextBoxColumn(); // 18
            arari1.DataPropertyName = "粗利１";
            arari1.Name = "粗利１";
            arari1.HeaderText = "材料１\r\n粗利１";
            arari1.ReadOnly = true;

            DataGridViewTextBoxColumn arariritsu1 = new DataGridViewTextBoxColumn(); // 19
            arariritsu1.DataPropertyName = "粗利率１";
            arariritsu1.Name = "粗利率１";
            arariritsu1.HeaderText = "材料１\r\n率１";
            arariritsu1.ReadOnly = true;

            DataGridViewTextBoxColumn shiireCd2 = new DataGridViewTextBoxColumn(); // 20
            shiireCd2.DataPropertyName = "仕入先コード２";
            shiireCd2.Name = "仕入先コード２";
            shiireCd2.HeaderText = "";
            shiireCd2.ReadOnly = true;
            shiireCd2.Visible = false;

            DataGridViewTextBoxColumn shiireName2 = new DataGridViewTextBoxColumn(); // 21
            shiireName2.DataPropertyName = "仕入先名２";
            shiireName2.Name = "仕入先名２";
            shiireName2.HeaderText = "材料１\r\n仕入先名２";
            shiireName2.ReadOnly = true;

            DataGridViewTextBoxColumn shiireTanka2 = new DataGridViewTextBoxColumn(); // 22
            shiireTanka2.DataPropertyName = "仕入単価２";
            shiireTanka2.Name = "仕入単価２";
            shiireTanka2.HeaderText = "材料１\r\n仕入単価２";
            shiireTanka2.ReadOnly = true;

            DataGridViewTextBoxColumn shiireKin2 = new DataGridViewTextBoxColumn(); // 23
            shiireKin2.DataPropertyName = "仕入金額２";
            shiireKin2.Name = "仕入金額２";
            shiireKin2.HeaderText = "材料１\r\n仕入金額２";
            shiireKin2.ReadOnly = true;

            DataGridViewTextBoxColumn arari2 = new DataGridViewTextBoxColumn(); // 24
            arari2.DataPropertyName = "粗利２";
            arari2.Name = "粗利２";
            arari2.HeaderText = "材料１\r\n粗利２";
            arari2.ReadOnly = true;

            DataGridViewTextBoxColumn arariritsu2 = new DataGridViewTextBoxColumn(); // 25
            arariritsu2.DataPropertyName = "粗利率２";
            arariritsu2.Name = "粗利率２";
            arariritsu2.HeaderText = "材料１\r\n率２";
            arariritsu2.ReadOnly = true;

            DataGridViewTextBoxColumn shiireCd3 = new DataGridViewTextBoxColumn(); // 26
            shiireCd3.DataPropertyName = "仕入先コード３";
            shiireCd3.Name = "仕入先コード３";
            shiireCd3.HeaderText = "";
            shiireCd3.ReadOnly = true;
            shiireCd3.Visible = false;

            DataGridViewTextBoxColumn shiireName3 = new DataGridViewTextBoxColumn(); // 27
            shiireName3.DataPropertyName = "仕入先名３";
            shiireName3.Name = "仕入先名３";
            shiireName3.HeaderText = "材料１\r\n仕入先名３";
            shiireName3.ReadOnly = true;

            DataGridViewTextBoxColumn shiireTanka3 = new DataGridViewTextBoxColumn(); // 28
            shiireTanka3.DataPropertyName = "仕入単価３";
            shiireTanka3.Name = "仕入単価３";
            shiireTanka3.HeaderText = "材料１\r\n仕入単価３";
            shiireTanka3.ReadOnly = true;

            DataGridViewTextBoxColumn shiireKin3 = new DataGridViewTextBoxColumn(); // 29
            shiireKin3.DataPropertyName = "仕入金額３";
            shiireKin3.Name = "仕入金額３";
            shiireKin3.HeaderText = "材料１\r\n仕入金額３";
            shiireKin3.ReadOnly = true;

            DataGridViewTextBoxColumn arari3 = new DataGridViewTextBoxColumn(); // 30
            arari3.DataPropertyName = "粗利３";
            arari3.Name = "粗利３";
            arari3.HeaderText = "材料１\r\n粗利３";
            arari3.ReadOnly = true;

            DataGridViewTextBoxColumn arariritsu3 = new DataGridViewTextBoxColumn(); // 31
            arariritsu3.DataPropertyName = "粗利率３";
            arariritsu3.Name = "粗利率３";
            arariritsu3.HeaderText = "材料１\r\n率３";
            arariritsu3.ReadOnly = true;
            #endregion

            #region
            DataGridViewTextBoxColumn shiireCd4 = new DataGridViewTextBoxColumn(); // 32
            shiireCd4.DataPropertyName = "仕入先コード４";
            shiireCd4.Name = "仕入先コード４";
            shiireCd4.HeaderText = "仕入先コード４";
            shiireCd4.Visible = false;
            shiireCd4.ReadOnly = true;

            DataGridViewTextBoxColumn shiireName4 = new DataGridViewTextBoxColumn(); // 33
            shiireName4.DataPropertyName = "仕入先名４";
            shiireName4.Name = "仕入先名４";
            shiireName4.HeaderText = "材料２\r\n仕入先名１";
            shiireName4.ReadOnly = true;

            DataGridViewTextBoxColumn shiireTanka4 = new DataGridViewTextBoxColumn(); // 34
            shiireTanka4.DataPropertyName = "仕入単価４";
            shiireTanka4.Name = "仕入単価４";
            shiireTanka4.HeaderText = "材料２\r\n仕入単価１";
            shiireTanka4.ReadOnly = true;

            DataGridViewTextBoxColumn shiireKin4 = new DataGridViewTextBoxColumn(); // 35
            shiireKin4.DataPropertyName = "仕入金額４";
            shiireKin4.Name = "仕入金額４";
            shiireKin4.HeaderText = "材料２\r\n仕入金額１";
            shiireKin4.ReadOnly = true;

            DataGridViewTextBoxColumn arari4 = new DataGridViewTextBoxColumn(); // 36
            arari4.DataPropertyName = "粗利４";
            arari4.Name = "粗利４";
            arari4.HeaderText = "材料２\r\n粗利１";
            arari4.ReadOnly = true;

            DataGridViewTextBoxColumn arariritsu4 = new DataGridViewTextBoxColumn(); // 37
            arariritsu4.DataPropertyName = "粗利率４";
            arariritsu4.Name = "粗利率４";
            arariritsu4.HeaderText = "材料２\r\n率１";
            arariritsu4.ReadOnly = true;

            DataGridViewTextBoxColumn shiireCd5 = new DataGridViewTextBoxColumn(); // 38
            shiireCd5.DataPropertyName = "仕入先コード５";
            shiireCd5.Name = "仕入先コード５";
            shiireCd5.HeaderText = "仕入先コード５";
            shiireCd5.Visible = false;
            shiireCd5.ReadOnly = true;

            DataGridViewTextBoxColumn shiireName5 = new DataGridViewTextBoxColumn(); // 39
            shiireName5.DataPropertyName = "仕入先名５";
            shiireName5.Name = "仕入先名５";
            shiireName5.HeaderText = "材料２\r\n仕入先名２";
            shiireName5.ReadOnly = true;

            DataGridViewTextBoxColumn shiireTanka5 = new DataGridViewTextBoxColumn(); // 40
            shiireTanka5.DataPropertyName = "仕入単価５";
            shiireTanka5.Name = "仕入単価５";
            shiireTanka5.HeaderText = "材料２\r\n仕入単価２";
            shiireTanka5.ReadOnly = true;

            DataGridViewTextBoxColumn shiireKin5 = new DataGridViewTextBoxColumn(); // 41
            shiireKin5.DataPropertyName = "仕入金額５";
            shiireKin5.Name = "仕入金額５";
            shiireKin5.HeaderText = "材料２\r\n仕入金額２";
            shiireKin5.ReadOnly = true;

            DataGridViewTextBoxColumn arari5 = new DataGridViewTextBoxColumn(); // 42
            arari5.DataPropertyName = "粗利５";
            arari5.Name = "粗利５";
            arari5.HeaderText = "材料２\r\n粗利２";
            arari5.ReadOnly = true;

            DataGridViewTextBoxColumn arariritsu5 = new DataGridViewTextBoxColumn(); // 43
            arariritsu5.DataPropertyName = "粗利率５";
            arariritsu5.Name = "粗利率５";
            arariritsu5.HeaderText = "材料２\r\n率２";
            arariritsu5.ReadOnly = true;

            DataGridViewTextBoxColumn shiireCd6 = new DataGridViewTextBoxColumn(); // 44
            shiireCd6.DataPropertyName = "仕入先コード６";
            shiireCd6.Name = "仕入先コード６";
            shiireCd6.HeaderText = "仕入先コード６";
            shiireCd6.Visible = false;
            shiireCd6.ReadOnly = true;

            DataGridViewTextBoxColumn shiireName6 = new DataGridViewTextBoxColumn(); // 45
            shiireName6.DataPropertyName = "仕入先名６";
            shiireName6.Name = "仕入先名６";
            shiireName6.HeaderText = "材料２\r\n仕入先名３";
            shiireName6.ReadOnly = true;

            DataGridViewTextBoxColumn shiireTanka6 = new DataGridViewTextBoxColumn(); // 46
            shiireTanka6.DataPropertyName = "仕入単価６";
            shiireTanka6.Name = "仕入単価６";
            shiireTanka6.HeaderText = "材料２\r\n仕入単価３";
            shiireTanka6.ReadOnly = true;

            DataGridViewTextBoxColumn shiireKin6 = new DataGridViewTextBoxColumn(); // 47
            shiireKin6.DataPropertyName = "仕入金額６";
            shiireKin6.Name = "仕入金額６";
            shiireKin6.HeaderText = "材料２\r\n仕入金額３";
            shiireKin6.ReadOnly = true;

            DataGridViewTextBoxColumn arari6 = new DataGridViewTextBoxColumn(); // 48
            arari6.DataPropertyName = "粗利６";
            arari6.Name = "粗利６";
            arari6.HeaderText = "材料２\r\n粗利３";
            arari6.ReadOnly = true;

            DataGridViewTextBoxColumn arariritsu6 = new DataGridViewTextBoxColumn(); // 49
            arariritsu6.DataPropertyName = "粗利率６";
            arariritsu6.Name = "粗利率６";
            arariritsu6.HeaderText = "材料２\r\n率３";
            arariritsu6.ReadOnly = true;
            #endregion

            #region
            DataGridViewTextBoxColumn kakoShiireCd1 = new DataGridViewTextBoxColumn(); // 50
            kakoShiireCd1.DataPropertyName = "加工仕入先コード１";
            kakoShiireCd1.Name = "加工仕入先コード１";
            kakoShiireCd1.HeaderText = "加工仕入先コード１";
            kakoShiireCd1.Visible = false;
            kakoShiireCd1.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireName1 = new DataGridViewTextBoxColumn(); // 51
            kakoShiireName1.DataPropertyName = "加工仕入先名１";
            kakoShiireName1.Name = "加工仕入先名１";
            kakoShiireName1.HeaderText = "加工１\r\n仕入先名１";
            kakoShiireName1.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireTanka1 = new DataGridViewTextBoxColumn(); // 52
            kakoShiireTanka1.DataPropertyName = "加工仕入単価１";
            kakoShiireTanka1.Name = "加工仕入単価１";
            kakoShiireTanka1.HeaderText = "加工１\r\n仕入単価１";
            kakoShiireTanka1.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireKin1 = new DataGridViewTextBoxColumn(); // 53
            kakoShiireKin1.DataPropertyName = "加工仕入金額１";
            kakoShiireKin1.Name = "加工仕入金額１";
            kakoShiireKin1.HeaderText = "加工１\r\n仕入金額１";
            kakoShiireKin1.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArari1 = new DataGridViewTextBoxColumn(); // 54
            kakoShiireArari1.DataPropertyName = "加工粗利１";
            kakoShiireArari1.Name = "加工粗利１";
            kakoShiireArari1.HeaderText = "加工１\r\n粗利１";
            kakoShiireArari1.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArariritsu1 = new DataGridViewTextBoxColumn(); // 55
            kakoShiireArariritsu1.DataPropertyName = "加工粗利率１";
            kakoShiireArariritsu1.Name = "加工粗利率１";
            kakoShiireArariritsu1.HeaderText = "加工１\r\n率１";
            kakoShiireArariritsu1.Visible = false;
            kakoShiireArariritsu1.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireCd2 = new DataGridViewTextBoxColumn(); // 56
            kakoShiireCd2.DataPropertyName = "加工仕入先コード２";
            kakoShiireCd2.Name = "加工仕入先コード２";
            kakoShiireCd2.HeaderText = "加工仕入先コード２";
            kakoShiireCd2.Visible = false;
            kakoShiireCd2.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireName2 = new DataGridViewTextBoxColumn(); // 57
            kakoShiireName2.DataPropertyName = "加工仕入先名２";
            kakoShiireName2.Name = "加工仕入先名２";
            kakoShiireName2.HeaderText = "加工１\r\n仕入先名２";
            kakoShiireName2.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireTanka2 = new DataGridViewTextBoxColumn(); // 58
            kakoShiireTanka2.DataPropertyName = "加工仕入単価２";
            kakoShiireTanka2.Name = "加工仕入単価２";
            kakoShiireTanka2.HeaderText = "加工１\r\n仕入単価２";
            kakoShiireTanka2.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireKin2 = new DataGridViewTextBoxColumn(); // 59
            kakoShiireKin2.DataPropertyName = "加工仕入金額２";
            kakoShiireKin2.Name = "加工仕入金額２";
            kakoShiireKin2.HeaderText = "加工１\r\n仕入金額２";
            kakoShiireKin2.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArari2 = new DataGridViewTextBoxColumn(); // 60
            kakoShiireArari2.DataPropertyName = "加工粗利２";
            kakoShiireArari2.Name = "加工粗利２";
            kakoShiireArari2.HeaderText = "加工１\r\n粗利２";
            kakoShiireArari2.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArariritsu2 = new DataGridViewTextBoxColumn(); // 61
            kakoShiireArariritsu2.DataPropertyName = "加工粗利率２";
            kakoShiireArariritsu2.Name = "加工粗利率２";
            kakoShiireArariritsu2.HeaderText = "加工１\r\n率２";
            kakoShiireArariritsu2.Visible = false;
            kakoShiireArariritsu2.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireCd3 = new DataGridViewTextBoxColumn(); // 62
            kakoShiireCd3.DataPropertyName = "加工仕入先コード３";
            kakoShiireCd3.Name = "加工仕入先コード３";
            kakoShiireCd3.HeaderText = "加工仕入先コード３";
            kakoShiireCd3.Visible = false;
            kakoShiireCd3.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireName3 = new DataGridViewTextBoxColumn(); // 63
            kakoShiireName3.DataPropertyName = "加工仕入先名３";
            kakoShiireName3.Name = "加工仕入先名３";
            kakoShiireName3.HeaderText = "加工１\r\n仕入先名３";
            kakoShiireName3.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireTanka3 = new DataGridViewTextBoxColumn(); // 64
            kakoShiireTanka3.DataPropertyName = "加工仕入単価３";
            kakoShiireTanka3.Name = "加工仕入単価３";
            kakoShiireTanka3.HeaderText = "加工１\r\n仕入単価３";
            kakoShiireTanka3.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireKin3 = new DataGridViewTextBoxColumn(); // 65
            kakoShiireKin3.DataPropertyName = "加工仕入金額３";
            kakoShiireKin3.Name = "加工仕入金額３";
            kakoShiireKin3.HeaderText = "加工１\r\n仕入金額３";
            kakoShiireKin3.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArari3 = new DataGridViewTextBoxColumn(); // 66
            kakoShiireArari3.DataPropertyName = "加工粗利３";
            kakoShiireArari3.Name = "加工粗利３";
            kakoShiireArari3.HeaderText = "加工１\r\n粗利３";
            kakoShiireArari3.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArariritsu3 = new DataGridViewTextBoxColumn(); //67 
            kakoShiireArariritsu3.DataPropertyName = "加工粗利率３";
            kakoShiireArariritsu3.Name = "加工粗利率３";
            kakoShiireArariritsu3.HeaderText = "加工１\r\n率３";
            kakoShiireArariritsu3.Visible = false;
            kakoShiireArariritsu3.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireCd4 = new DataGridViewTextBoxColumn(); // 68
            kakoShiireCd4.DataPropertyName = "加工仕入先コード４";
            kakoShiireCd4.Name = "加工仕入先コード４";
            kakoShiireCd4.HeaderText = "加工仕入先コード４";
            kakoShiireCd4.Visible = false;
            kakoShiireCd4.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireName4 = new DataGridViewTextBoxColumn(); // 69
            kakoShiireName4.DataPropertyName = "加工仕入先名４";
            kakoShiireName4.Name = "加工仕入先名４";
            kakoShiireName4.HeaderText = "加工２\r\n仕入先名１";
            kakoShiireName4.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireTanka4 = new DataGridViewTextBoxColumn(); // 70
            kakoShiireTanka4.DataPropertyName = "加工仕入単価４";
            kakoShiireTanka4.Name = "加工仕入単価４";
            kakoShiireTanka4.HeaderText = "加工２\r\n仕入単価１";
            kakoShiireTanka4.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireKin4 = new DataGridViewTextBoxColumn(); // 71
            kakoShiireKin4.DataPropertyName = "加工仕入金額４";
            kakoShiireKin4.Name = "加工仕入金額４";
            kakoShiireKin4.HeaderText = "加工２\r\n仕入金額１";
            kakoShiireKin4.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArari4 = new DataGridViewTextBoxColumn(); // 72
            kakoShiireArari4.DataPropertyName = "加工粗利４";
            kakoShiireArari4.Name = "加工粗利４";
            kakoShiireArari4.HeaderText = "加工２\r\n粗利１";
            kakoShiireArari4.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArariritsu4 = new DataGridViewTextBoxColumn(); // 73
            kakoShiireArariritsu4.DataPropertyName = "加工粗利率４";
            kakoShiireArariritsu4.Name = "加工粗利率４";
            kakoShiireArariritsu4.HeaderText = "加工２\r\n率１";
            kakoShiireArariritsu4.Visible = false;
            kakoShiireArariritsu4.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireCd5 = new DataGridViewTextBoxColumn(); // 74
            kakoShiireCd5.DataPropertyName = "加工仕入先コード５";
            kakoShiireCd5.Name = "加工仕入先コード５";
            kakoShiireCd5.HeaderText = "加工仕入先コード５";
            kakoShiireCd5.Visible = false;
            kakoShiireCd5.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireName5 = new DataGridViewTextBoxColumn(); // 75
            kakoShiireName5.DataPropertyName = "加工仕入先名５";
            kakoShiireName5.Name = "加工仕入先名５";
            kakoShiireName5.HeaderText = "加工２\r\n仕入先名２";
            kakoShiireName5.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireTanka5 = new DataGridViewTextBoxColumn(); // 76
            kakoShiireTanka5.DataPropertyName = "加工仕入単価５";
            kakoShiireTanka5.Name = "加工仕入単価５";
            kakoShiireTanka5.HeaderText = "加工２\r\n仕入単価２";
            kakoShiireTanka5.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireKin5 = new DataGridViewTextBoxColumn(); // 77
            kakoShiireKin5.DataPropertyName = "加工仕入金額５";
            kakoShiireKin5.Name = "加工仕入金額５";
            kakoShiireKin5.HeaderText = "加工２\r\n仕入金額２";
            kakoShiireKin5.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArari5 = new DataGridViewTextBoxColumn(); // 78
            kakoShiireArari5.DataPropertyName = "加工粗利５";
            kakoShiireArari5.Name = "加工粗利５";
            kakoShiireArari5.HeaderText = "加工２\r\n粗利２";
            kakoShiireArari5.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArariritsu5 = new DataGridViewTextBoxColumn(); // 79
            kakoShiireArariritsu5.DataPropertyName = "加工粗利率５";
            kakoShiireArariritsu5.Name = "加工粗利率５";
            kakoShiireArariritsu5.HeaderText = "加工２\r\n率２";
            kakoShiireArariritsu5.Visible = false;
            kakoShiireArariritsu5.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireCd6 = new DataGridViewTextBoxColumn(); // 80
            kakoShiireCd6.DataPropertyName = "加工仕入先コード６";
            kakoShiireCd6.Name = "加工仕入先コード６";
            kakoShiireCd6.HeaderText = "加工仕入先コード６";
            kakoShiireCd6.Visible = false;
            kakoShiireCd6.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireName6 = new DataGridViewTextBoxColumn(); // 81
            kakoShiireName6.DataPropertyName = "加工仕入先名６";
            kakoShiireName6.Name = "加工仕入先名６";
            kakoShiireName6.HeaderText = "加工２\r\n仕入先名３";
            kakoShiireName6.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireTanka6 = new DataGridViewTextBoxColumn(); // 82
            kakoShiireTanka6.DataPropertyName = "加工仕入単価６";
            kakoShiireTanka6.Name = "加工仕入単価６";
            kakoShiireTanka6.HeaderText = "加工２\r\n仕入単価３";
            kakoShiireTanka6.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireKin6 = new DataGridViewTextBoxColumn(); // 83
            kakoShiireKin6.DataPropertyName = "加工仕入金額６";
            kakoShiireKin6.Name = "加工仕入金額６";
            kakoShiireKin6.HeaderText = "加工２\r\n仕入金額３";
            kakoShiireKin6.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArari6 = new DataGridViewTextBoxColumn(); // 84
            kakoShiireArari6.DataPropertyName = "加工粗利６";
            kakoShiireArari6.Name = "加工粗利６";
            kakoShiireArari6.HeaderText = "加工２\r\n粗利３";
            kakoShiireArari6.ReadOnly = true;

            DataGridViewTextBoxColumn kakoShiireArariritsu6 = new DataGridViewTextBoxColumn(); // 85
            kakoShiireArariritsu6.DataPropertyName = "加工粗利率６";
            kakoShiireArariritsu6.Name = "加工粗利率６";
            kakoShiireArariritsu6.HeaderText = "加工粗利加工２\r\n率３";
            kakoShiireArariritsu6.Visible = false;
            kakoShiireArariritsu6.ReadOnly = true;
            #endregion

            #region
            DataGridViewTextBoxColumn shohin = new DataGridViewTextBoxColumn(); // 86
            shohin.DataPropertyName = "商品コード";
            shohin.Name = "商品コード";
            shohin.HeaderText = "商品コード";
            shohin.Visible = false;

            DataGridViewTextBoxColumn daibunrui = new DataGridViewTextBoxColumn(); // 87
            daibunrui.DataPropertyName = "大分類コード";
            daibunrui.Name = "大分類コード";
            daibunrui.HeaderText = "大分類";
            daibunrui.Visible = false;

            DataGridViewTextBoxColumn chubunrui = new DataGridViewTextBoxColumn(); // 88
            chubunrui.DataPropertyName = "中分類コード";
            chubunrui.Name = "中分類コード";
            chubunrui.HeaderText = "中分類";
            chubunrui.Visible = false;

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn(); // 89
            maker.DataPropertyName = "メーカーコード";
            maker.Name = "メーカーコード";
            maker.HeaderText = "メーカー";
            maker.Visible = false;

            DataGridViewTextBoxColumn teika1 = new DataGridViewTextBoxColumn(); // 90
            teika1.DataPropertyName = "定価1";
            teika1.Name = "定価1";
            teika1.HeaderText = "定価1";
            teika1.ReadOnly = true;
            teika1.Visible = false;

            DataGridViewTextBoxColumn teika2 = new DataGridViewTextBoxColumn(); // 91
            teika2.DataPropertyName = "定価2";
            teika2.Name = "定価2";
            teika2.HeaderText = "定価2";
            teika2.ReadOnly = true;
            teika2.Visible = false;

            DataGridViewTextBoxColumn teika3 = new DataGridViewTextBoxColumn(); // 92
            teika3.DataPropertyName = "定価3";
            teika3.Name = "定価3";
            teika3.HeaderText = "定価3";
            teika3.ReadOnly = true;
            teika3.Visible = false;

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn(); // 93
            c1.DataPropertyName = "Ｃ１";
            c1.Name = "Ｃ１";
            c1.HeaderText = "Ｃ１";
            c1.Visible = false;

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn(); // 94
            c2.DataPropertyName = "Ｃ２";
            c2.Name = "Ｃ２";
            c2.HeaderText = "Ｃ２";
            c2.Visible = false;
            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn(); // 95
            c3.DataPropertyName = "Ｃ３";
            c3.Name = "Ｃ３";
            c3.HeaderText = "Ｃ３";
            c3.Visible = false;
            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn(); // 96
            c4.DataPropertyName = "Ｃ４";
            c4.Name = "Ｃ４";
            c4.HeaderText = "Ｃ４";
            c4.Visible = false;
            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn(); // 97
            c5.DataPropertyName = "Ｃ５";
            c5.Name = "Ｃ５";
            c5.HeaderText = "Ｃ５";
            c5.Visible = false;
            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn(); // 98
            c6.DataPropertyName = "Ｃ６";
            c6.Name = "Ｃ６";
            c6.HeaderText = "Ｃ６";
            c6.Visible = false;
            DataGridViewTextBoxColumn shiireMeiZai2 = new DataGridViewTextBoxColumn(); // 99
            shiireMeiZai2.DataPropertyName = "仕入先名材料２";
            shiireMeiZai2.Name = "仕入先名材料２";
            shiireMeiZai2.HeaderText = "仕入先名材料２";
            shiireMeiZai2.Visible = false;
            #endregion
            #endregion

            //バインド、個々の幅、文章の寄せの設定
            #region
            setColumn(gridMitsmori, txtRowNum, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 36);
            gridMitsmori.Columns.Add(cbRow);
            setColumn(gridMitsmori, hinmei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 330);
            setColumn(gridMitsmori, suryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(gridMitsmori, teika, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, mitsumoriTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, kakeritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 50);
            setColumn(gridMitsmori, kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, shiireTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, arari, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arariritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 50);
            setColumn(gridMitsmori, biko, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, shiiresaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, insatsu, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, 26);
            setColumn(gridMitsmori, shiireCd1, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 40);
            setColumn(gridMitsmori, shiireName1, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, shiireTanka1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, shiireKin1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arari1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arariritsu1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, shiireCd2, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 40);
            setColumn(gridMitsmori, shiireName2, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, shiireTanka2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, shiireKin2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arari2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arariritsu2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, shiireCd3, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 40);
            setColumn(gridMitsmori, shiireName3, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, shiireTanka3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, shiireKin3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arari3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arariritsu3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, shiireCd4);
            setColumn(gridMitsmori, shiireName4, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, shiireTanka4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, shiireKin4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arari4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arariritsu4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, shiireCd5);
            setColumn(gridMitsmori, shiireName5, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, shiireTanka5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, shiireKin5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arari5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arariritsu5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, shiireCd6);
            setColumn(gridMitsmori, shiireName6, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, shiireTanka6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, shiireKin6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arari6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, arariritsu6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, kakoShiireCd1);
            setColumn(gridMitsmori, kakoShiireName1, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, kakoShiireTanka1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, kakoShiireKin1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArari1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArariritsu1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, kakoShiireCd2);
            setColumn(gridMitsmori, kakoShiireName2, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, kakoShiireTanka2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, kakoShiireKin2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArari2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArariritsu2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, kakoShiireCd3);
            setColumn(gridMitsmori, kakoShiireName3, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, kakoShiireTanka3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, kakoShiireKin3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArari3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArariritsu3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, kakoShiireCd4);
            setColumn(gridMitsmori, kakoShiireName4, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, kakoShiireTanka4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, kakoShiireKin4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArari4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArariritsu4, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, kakoShiireCd5);
            setColumn(gridMitsmori, kakoShiireName5, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, kakoShiireTanka5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, kakoShiireKin5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArari5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArariritsu5, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, kakoShiireCd6);
            setColumn(gridMitsmori, kakoShiireName6, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, kakoShiireTanka6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 120);
            setColumn(gridMitsmori, kakoShiireKin6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArari6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, kakoShiireArariritsu6, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.0", 68);
            setColumn(gridMitsmori, shohin);
            setColumn(gridMitsmori, daibunrui);
            setColumn(gridMitsmori, chubunrui);
            setColumn(gridMitsmori, maker);
            setColumn(gridMitsmori, teika1);
            setColumn(gridMitsmori, teika2);
            setColumn(gridMitsmori, teika3);
            setColumn(gridMitsmori, c1);
            setColumn(gridMitsmori, c2);
            setColumn(gridMitsmori, c3);
            setColumn(gridMitsmori, c4);
            setColumn(gridMitsmori, c5);
            setColumn(gridMitsmori, c6);
            setColumn(gridMitsmori, shiireMeiZai2);
            #endregion
        }

        ///<summary>
        ///setColumn
        ///Grid列設定
        ///</summary>
        private void setColumn(Common.Ctl.BaseDataGridViewEdit gr, DataGridViewTextBoxColumn col, DataGridViewContentAlignment aliStyleDef, DataGridViewContentAlignment aliStyleHeader, string fmt, int intLen)
        {
            gr.Columns.Add(col);
            if (gr.Columns[col.Name] != null)
            {
                gr.Columns[col.Name].Width = intLen;
                gr.Columns[col.Name].DefaultCellStyle.Alignment = aliStyleDef;
                gr.Columns[col.Name].HeaderCell.Style.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                gr.Columns[col.Name].HeaderCell.Style.Alignment = aliStyleHeader;
                gr.Columns[col.Name].SortMode = DataGridViewColumnSortMode.NotSortable;


                if (fmt != null)
                {
                    gr.Columns[col.Name].DefaultCellStyle.Format = fmt;
                }
            }
        }
        private void setColumn(Common.Ctl.BaseDataGridViewEdit gr, DataGridViewTextBoxColumn col)
        {
            gr.Columns.Add(col);
        }

        private void setText(int idx)
        {
            try
            {
                int rowIdx = idx;
                txtIdx.Text = rowIdx.ToString();

                txtZaiTeika1.Text = getCellValue(gridMitsmori[4, rowIdx], false);
                txtZaiCd1.Text = getCellValue(gridMitsmori[14, rowIdx], false);
                txtZaiMei1.Text = getCellValue(gridMitsmori[15, rowIdx], false);
                txtZaiTnk1.Text = getCellValue(gridMitsmori[16, rowIdx], false);
                txtKakCd1.Text = getCellValue(gridMitsmori[50, rowIdx], false);
                txtKakMei1.Text = getCellValue(gridMitsmori[51, rowIdx], false);
                txtKakTnk1.Text = getCellValue(gridMitsmori[52, rowIdx], false);

                txtZaiTeika2.Text = getCellValue(gridMitsmori[4, rowIdx], false);
                txtZaiCd2.Text = getCellValue(gridMitsmori[20, rowIdx], false);
                txtZaiMei2.Text = getCellValue(gridMitsmori[21, rowIdx], false);
                txtZaiTnk2.Text = getCellValue(gridMitsmori[22, rowIdx], false);
                txtKakCd2.Text = getCellValue(gridMitsmori[56, rowIdx], false);
                txtKakMei2.Text = getCellValue(gridMitsmori[57, rowIdx], false);
                txtKakTnk2.Text = getCellValue(gridMitsmori[58, rowIdx], false);

                txtZaiTeika3.Text = getCellValue(gridMitsmori[4, rowIdx], false);
                txtZaiCd3.Text = getCellValue(gridMitsmori[26, rowIdx], false);
                txtZaiMei3.Text = getCellValue(gridMitsmori[27, rowIdx], false);
                txtZaiTnk3.Text = getCellValue(gridMitsmori[28, rowIdx], false);
                txtKakCd3.Text = getCellValue(gridMitsmori[62, rowIdx], false);
                txtKakMei3.Text = getCellValue(gridMitsmori[63, rowIdx], false);
                txtKakTnk3.Text = getCellValue(gridMitsmori[64, rowIdx], false);

                txtZaiTeika4.Text = getCellValue(gridMitsmori[4, rowIdx], false);
                txtZaiCd4.Text = getCellValue(gridMitsmori[32, rowIdx], false);
                txtZaiMei4.Text = getCellValue(gridMitsmori[33, rowIdx], false);
                txtZaiTnk4.Text = getCellValue(gridMitsmori[34, rowIdx], false);
                txtKakCd4.Text = getCellValue(gridMitsmori[68, rowIdx], false);
                txtKakMei4.Text = getCellValue(gridMitsmori[69, rowIdx], false);
                txtKakTnk4.Text = getCellValue(gridMitsmori[70, rowIdx], false);

                txtZaiTeika5.Text = getCellValue(gridMitsmori[4, rowIdx], false);
                txtZaiCd5.Text = getCellValue(gridMitsmori[38, rowIdx], false);
                txtZaiMei5.Text = getCellValue(gridMitsmori[39, rowIdx], false);
                txtZaiTnk5.Text = getCellValue(gridMitsmori[40, rowIdx], false);
                txtKakCd5.Text = getCellValue(gridMitsmori[74, rowIdx], false);
                txtKakMei5.Text = getCellValue(gridMitsmori[75, rowIdx], false);
                txtKakTnk5.Text = getCellValue(gridMitsmori[76, rowIdx], false);

                txtZaiTeika6.Text = getCellValue(gridMitsmori[4, rowIdx], false);
                txtZaiCd6.Text = getCellValue(gridMitsmori[44, rowIdx], false);
                txtZaiMei6.Text = getCellValue(gridMitsmori[45, rowIdx], false);
                txtZaiTnk6.Text = getCellValue(gridMitsmori[46, rowIdx], false);
                txtKakCd6.Text = getCellValue(gridMitsmori[80, rowIdx], false);
                txtKakMei6.Text = getCellValue(gridMitsmori[81, rowIdx], false);
                txtKakTnk6.Text = getCellValue(gridMitsmori[82, rowIdx], false);

                #region
                if (cellValueChecker(12, rowIdx))
                {
                    if (gridMitsmori[12, rowIdx].Value.ToString().Equals(txtZaiMei1.Text))
                    {
                        setRowBGColor1(Color.FromArgb(0x66, 0xFF, 0x66));
                        setRowBGColor2(Color.White);
                        setRowBGColor3(Color.White);
                        intZai1Num = 1;
                    }
                    else if (gridMitsmori[12, rowIdx].Value.ToString().Equals(txtZaiMei2.Text))
                    {
                        setRowBGColor1(Color.White);
                        setRowBGColor2(Color.FromArgb(0x66, 0xFF, 0x66));
                        setRowBGColor3(Color.White);
                        intZai1Num = 2;
                    }
                    else if (gridMitsmori[12, rowIdx].Value.ToString().Equals(txtZaiMei3.Text))
                    {
                        setRowBGColor1(Color.White);
                        setRowBGColor2(Color.White);
                        setRowBGColor3(Color.FromArgb(0x66, 0xFF, 0x66));
                        intZai1Num = 3;
                    }
                    if (cellValueChecker(99, rowIdx))
                    {
                        if (gridMitsmori[99, rowIdx].Value.ToString().Equals(txtZaiMei4.Text))
                        {
                            setRowBGColor4(Color.FromArgb(0x66, 0xFF, 0x66));
                            setRowBGColor5(Color.White);
                            setRowBGColor6(Color.White);
                            intZai2Num = 4;
                        }
                        else if (gridMitsmori[99, rowIdx].Value.ToString().Equals(txtZaiMei5.Text))
                        {
                            setRowBGColor4(Color.White);
                            setRowBGColor5(Color.FromArgb(0x66, 0xFF, 0x66));
                            setRowBGColor6(Color.White);
                            intZai2Num = 5;
                        }
                        else if (gridMitsmori[99, rowIdx].Value.ToString().Equals(txtZaiMei6.Text))
                        {
                            setRowBGColor4(Color.White);
                            setRowBGColor5(Color.White);
                            setRowBGColor6(Color.FromArgb(0x66, 0xFF, 0x66));
                            intZai2Num = 6;
                        }
                    }
                }
                #endregion

                calc(1, intZai2Num);
                calc(2, intZai2Num);
                calc(3, intZai2Num);
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void setRowBGColor1(Color bgc)
        {
            txtZaiCd1.BackColor = bgc;
            txtZaiMei1.BackColor = bgc;
            txtZaiTeika1.BackColor = bgc;
            txtZaiTnk1.BackColor = bgc;
            txtZaiRit1.BackColor = bgc;
            txtKakCd1.BackColor = bgc;
            txtKakMei1.BackColor = bgc;
            txtKakTnk1.BackColor = bgc;
            //txtKakRit1.BackColor = bgc;
            txtArr1.BackColor = bgc;
            txtSrrt1.BackColor = bgc;
        }
        private void setRowBGColor2(Color bgc)
        {
            txtZaiCd2.BackColor = bgc;
            txtZaiMei2.BackColor = bgc;
            txtZaiTeika2.BackColor = bgc;
            txtZaiTnk2.BackColor = bgc;
            txtZaiRit2.BackColor = bgc;
            txtKakCd2.BackColor = bgc;
            txtKakMei2.BackColor = bgc;
            txtKakTnk2.BackColor = bgc;
            //txtKakRit2.BackColor = bgc;
            txtArr2.BackColor = bgc;
            txtSrrt2.BackColor = bgc;
        }
        private void setRowBGColor3(Color bgc)
        {
            txtZaiCd3.BackColor = bgc;
            txtZaiMei3.BackColor = bgc;
            txtZaiTeika3.BackColor = bgc;
            txtZaiTnk3.BackColor = bgc;
            txtZaiRit3.BackColor = bgc;
            txtKakCd3.BackColor = bgc;
            txtKakMei3.BackColor = bgc;
            txtKakTnk3.BackColor = bgc;
            //txtKakRit3.BackColor = bgc;
            txtArr3.BackColor = bgc;
            txtSrrt3.BackColor = bgc;
        }
        private void setRowBGColor4(Color bgc)
        {
            txtZaiCd4.BackColor = bgc;
            txtZaiMei4.BackColor = bgc;
            txtZaiTeika4.BackColor = bgc;
            txtZaiTnk4.BackColor = bgc;
            txtZaiRit4.BackColor = bgc;
            txtKakCd4.BackColor = bgc;
            txtKakMei4.BackColor = bgc;
            txtKakTnk4.BackColor = bgc;
            //txtKakRit4.BackColor = bgc;
            txtArr4.BackColor = bgc;
            txtSrrt4.BackColor = bgc;
        }
        private void setRowBGColor5(Color bgc)
        {
            txtZaiCd5.BackColor = bgc;
            txtZaiMei5.BackColor = bgc;
            txtZaiTeika5.BackColor = bgc;
            txtZaiTnk5.BackColor = bgc;
            txtZaiRit5.BackColor = bgc;
            txtKakCd5.BackColor = bgc;
            txtKakMei5.BackColor = bgc;
            txtKakTnk5.BackColor = bgc;
            //txtKakRit5.BackColor = bgc;
            txtArr5.BackColor = bgc;
            txtSrrt5.BackColor = bgc;
        }
        private void setRowBGColor6(Color bgc)
        {
            txtZaiCd6.BackColor = bgc;
            txtZaiMei6.BackColor = bgc;
            txtZaiTeika6.BackColor = bgc;
            txtZaiTnk6.BackColor = bgc;
            txtZaiRit6.BackColor = bgc;
            txtKakCd6.BackColor = bgc;
            txtKakMei6.BackColor = bgc;
            txtKakTnk6.BackColor = bgc;
            //txtKakRit6.BackColor = bgc;
            txtArr6.BackColor = bgc;
            txtSrrt6.BackColor = bgc;
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;
            ColIndex = e.ColumnIndex;
            setText(e.RowIndex);

            if (e.ColumnIndex == 2 || e.ColumnIndex == 11)
            {
                gridMitsmori.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            }
            else
            {
                gridMitsmori.ImeMode = System.Windows.Forms.ImeMode.Disable;
            }
        }

        private void dataGridView2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            keyFlgF9 = false;
            if (ColIndex == 2 && e.KeyCode == Keys.F9)
            {
                LabelSet_Daibunrui lDai = new LabelSet_Daibunrui();
                LabelSet_Chubunrui lChu = new LabelSet_Chubunrui();
                LabelSet_Maker lMak = new LabelSet_Maker();
                BaseText tSho = new BaseText();
                BaseText tKata = new BaseText();
                BaseText tC1 = new BaseText();
                BaseText tC2 = new BaseText();
                BaseText tC3 = new BaseText();
                BaseText tC4 = new BaseText();
                BaseText tC5 = new BaseText();
                BaseText tC6 = new BaseText();
                BaseTextMoney tTeikka = new BaseTextMoney();

                ShouhinList sl = new ShouhinList(this);
                sl.lsDaibunrui = lDai;
                sl.lsChubunrui = lChu;
                sl.lsMaker = lMak;
                sl.btxtShohinCd = tSho;
                sl.btxtHinC1Hinban = tKata;
                sl.btxtHinC1 = tC1;
                sl.btxtHinC2 = tC2;
                sl.btxtHinC3 = tC3;
                sl.btxtHinC4 = tC4;
                sl.btxtHinC5 = tC5;
                sl.btxtHinC6 = tC6;
                sl.intFrmKind = 1;
                sl.bmtxtTeika = tTeikka;

                sl.ShowDialog();

                int intRow = RowIndex;
                gridMitsmori[2, intRow].Value = tKata.Text;
                gridMitsmori[87, intRow].Value = lDai.CodeTxtText;
                gridMitsmori[88, intRow].Value = lChu.CodeTxtText;
                gridMitsmori[89, intRow].Value = lMak.CodeTxtText;
                gridMitsmori[86, intRow].Value = tSho.Text;
                gridMitsmori[93, intRow].Value = tC1.Text;
                gridMitsmori[94, intRow].Value = tC2.Text;
                gridMitsmori[95, intRow].Value = tC3.Text;
                gridMitsmori[96, intRow].Value = tC4.Text;
                gridMitsmori[97, intRow].Value = tC5.Text;
                gridMitsmori[98, intRow].Value = tC6.Text;
                gridMitsmori[4, intRow].Value = tTeikka.Text;
                gridMitsmori.EndEdit();
                editFlg = true;
                oldHinmei = tKata.Text;
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            editGrid(e);
        }

        // gird 更新
        private void editGrid(DataGridViewCellEventArgs e)
        {
            //// 品名・型番がある時は印刷チェックを入れる
            //if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[2, e.RowIndex], false)))
            //{
            //    gridMitsmori[1, e.RowIndex].Value = "1";
            //}
            //else
            //{
            //    gridMitsmori[1, e.RowIndex].Value = "0";
            //}

            // 品名・型番に対して直接編集で値を変えた場合
            if (e.ColumnIndex == 2) {
                if (!oldHinmei.Equals(getCellValue(gridMitsmori[2, e.RowIndex], false))) {
                    gridMitsmori[87, e.RowIndex].Value = "";
                    gridMitsmori[88, e.RowIndex].Value = "";
                    gridMitsmori[89, e.RowIndex].Value = "";
                    gridMitsmori[86, e.RowIndex].Value = "";
                    gridMitsmori[93, e.RowIndex].Value = "";
                    gridMitsmori[94, e.RowIndex].Value = "";
                    gridMitsmori[95, e.RowIndex].Value = "";
                    gridMitsmori[96, e.RowIndex].Value = "";
                    gridMitsmori[97, e.RowIndex].Value = "";
                    gridMitsmori[98, e.RowIndex].Value = "";
                    gridMitsmori[4, e.RowIndex].Value = DBNull.Value;
                }
                oldHinmei = getCellValue(gridMitsmori[2, e.RowIndex], false);
            }
            // 見積単価・数量・定価のいずれかが変更された場合
            else if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                decimal dSuryo = 0;
                decimal dTeika = 0;
                decimal dTanka = 0;

                decimal dRitsu = 0;
                decimal dKin = 0;

                dSuryo = Decimal.Parse(getCellValue(gridMitsmori[3, e.RowIndex], true));
                dTeika = Decimal.Parse(getCellValue(gridMitsmori[4, e.RowIndex], true));
                dTanka = Decimal.Parse(getCellValue(gridMitsmori[5, e.RowIndex], true));

                if (!dTeika.Equals(0))
                {
                    dRitsu = Decimal.Round((dTanka / dTeika) * 100, 1);
                }

                dKin = Decimal.Round(dTanka * dSuryo, 0);

                if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[4, e.RowIndex], false)) && !string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[5, e.RowIndex], false)))
                {
                    gridMitsmori[6, e.RowIndex].Value = (Decimal.Round(dRitsu, 1)).ToString("#,0");
                }
                if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[3, e.RowIndex], false)) && !string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[5, e.RowIndex], false)))
                {
                    gridMitsmori[7, e.RowIndex].Value = (Decimal.Round(dKin, 0)).ToString("#,0");
                }

                gridMitsmori.EndEdit();

                setText(e.RowIndex);
                calc(1, intZai2Num);
                calc(2, intZai2Num);
                calc(3, intZai2Num);
                changeTotal();
            }
            editFlg = true;
        }

        private void txtZaiTnk1_Leave(object sender, EventArgs e)
        {
            calc(1, 1);
            calc(1, intZai2Num);
            changeTotal();
        }

        private void txtZaiTnk2_Leave(object sender, EventArgs e)
        {
            calc(2, 2);
            calc(2, intZai2Num);
            changeTotal();
        }

        private void txtZaiTnk3_Leave(object sender, EventArgs e)
        {
            calc(3, 3);
            calc(3, intZai2Num);
            changeTotal();
        }

        // 下部編集部計算
        private void calc(int rowNum, int zaiNum)
        {
            decimal dSuryo = 0;
            decimal dTeika = 0;
            decimal dMitsuTanka = 0;
            
            decimal dShiireTanka1 = 0;
            decimal dShiireTanka2 = 0;
            decimal dKakoTanka1 = 0;
            decimal dKakoTanka2 = 0;
            decimal dArariM = 0;
            decimal dArariRitsuM = 0;
            decimal dKakeritsu1 = 0;
            decimal dKakeritsu2 = 0;
            decimal dShiireKin1 = 0;
            decimal dShiireKin2 = 0;
            decimal dKakoKin1 = 0;
            decimal dKakoKin2 = 0;

            #region
            DataGridViewCell cellShiireTanka1 = null;
            DataGridViewCell cellShiireKin1 = null;
            DataGridViewCell cellShiireArari1 = null;
            DataGridViewCell cellShiireArariRitsu1 = null;
            DataGridViewCell cellShiireTanka2 = null;
            DataGridViewCell cellShiireKin2 = null;
            DataGridViewCell cellKakoTanka1 = null;
            DataGridViewCell cellKakoKin1 = null;
            DataGridViewCell cellKakoTanka2 = null;
            DataGridViewCell cellKakoKin2 = null;
            #endregion

            #region
            BaseText txtShiireCd1 = null;
            BaseText txtShiireName1 = null;
            BaseTextMoney txtShiireTeika1 = null;
            BaseTextMoney txtShiireTanka1 = null;
            BaseTextMoney txtKakeritsu1 = null;
            BaseText txtKakoCd1 = null;
            BaseText txtKakoName1 = null;
            BaseTextMoney txtKakoTanka1 = null;
            BaseTextMoney txtShiireTanka2 = null;
            BaseTextMoney txtKakoTanka2 = null;
            BaseTextMoney txtKakeritsu2 = null;
            BaseTextMoney txtArari = null;
            BaseTextMoney txtArariRitsu = null;
            #endregion

            Color color = Color.Black;
            int rowIdx = gridMitsmori.CurrentCell.RowIndex;

            try
            {
                #region
                if (rowNum == 1)
                {
                    txtShiireCd1 = txtZaiCd1;
                    txtShiireName1 = txtZaiMei1;
                    txtShiireTeika1 = txtZaiTeika1;
                    txtShiireTanka1 = txtZaiTnk1;
                    txtKakeritsu1 = txtZaiRit1;
                    txtKakoCd1 = txtKakCd1;
                    txtKakoName1 = txtKakMei1;
                    txtKakoTanka1 = txtKakTnk1;
                    txtArari = txtArr1;
                    txtArariRitsu = txtSrrt1;

                    cellShiireTanka1 = gridMitsmori[16, rowIdx];
                    cellShiireKin1 = gridMitsmori[17, rowIdx];
                    cellShiireArari1 = gridMitsmori[18, rowIdx];
                    cellShiireArariRitsu1 = gridMitsmori[19, rowIdx];

                    cellKakoTanka1 = gridMitsmori[52, rowIdx];
                    cellKakoKin1 = gridMitsmori[53, rowIdx];
                }
                else if (rowNum == 2)
                {
                    txtShiireCd1 = txtZaiCd2;
                    txtShiireName1 = txtZaiMei2;
                    txtShiireTeika1 = txtZaiTeika2;
                    txtShiireTanka1 = txtZaiTnk2;
                    txtKakeritsu1 = txtZaiRit2;
                    txtKakoCd1 = txtKakCd2;
                    txtKakoName1 = txtKakMei2;
                    txtKakoTanka1 = txtKakTnk2;
                    txtArari = txtArr2;
                    txtArariRitsu = txtSrrt2;

                    cellShiireTanka1 = gridMitsmori[22, rowIdx];
                    cellShiireKin1 = gridMitsmori[23, rowIdx];
                    cellShiireArari1 = gridMitsmori[24, rowIdx];
                    cellShiireArariRitsu1 = gridMitsmori[25, rowIdx];
                    
                    cellKakoTanka1 = gridMitsmori[58, rowIdx];
                    cellKakoKin1 = gridMitsmori[59, rowIdx];
                }
                else if (rowNum == 3)
                {
                    txtShiireCd1 = txtZaiCd3;
                    txtShiireName1 = txtZaiMei3;
                    txtShiireTeika1 = txtZaiTeika3;
                    txtShiireTanka1 = txtZaiTnk3;
                    txtKakeritsu1 = txtZaiRit3;
                    txtKakoCd1 = txtKakCd3;
                    txtKakoName1 = txtKakMei3;
                    txtKakoTanka1 = txtKakTnk3;
                    txtArari = txtArr3;
                    txtArariRitsu = txtSrrt3;

                    cellShiireTanka1 = gridMitsmori[28, rowIdx];
                    cellShiireKin1 = gridMitsmori[29, rowIdx];
                    cellShiireArari1 = gridMitsmori[30, rowIdx];
                    cellShiireArariRitsu1 = gridMitsmori[31, rowIdx];

                    cellKakoTanka1 = gridMitsmori[64, rowIdx];
                    cellKakoKin1 = gridMitsmori[65, rowIdx];
                }
                else
                {
                    return;
                }

                if (zaiNum == 1 || zaiNum == 4)
                {
                    txtShiireTanka2 = txtZaiTnk4;
                    txtKakeritsu2 = txtZaiRit4;
                    txtKakoTanka2 = txtKakTnk4;

                    cellShiireTanka2 = gridMitsmori[34, rowIdx];
                    cellShiireKin2 = gridMitsmori[35, rowIdx];

                    cellKakoTanka2 = gridMitsmori[70, rowIdx];
                    cellKakoKin2 = gridMitsmori[71, rowIdx];
                }
                else if (zaiNum == 2 || zaiNum == 5)
                {
                    txtShiireTanka2 = txtZaiTnk5;
                    txtKakeritsu2 = txtZaiRit5;
                    txtKakoTanka2 = txtKakTnk5;

                    cellShiireTanka2 = gridMitsmori[40, rowIdx];
                    cellShiireKin2 = gridMitsmori[41, rowIdx];

                    cellKakoTanka2 = gridMitsmori[76, rowIdx];
                    cellKakoKin2 = gridMitsmori[77, rowIdx];
                }
                else if (zaiNum == 3 || zaiNum == 6)
                {
                    txtShiireTanka2 = txtZaiTnk6;
                    txtKakeritsu2 = txtZaiRit6;
                    txtKakoTanka2 = txtKakTnk6;

                    cellShiireTanka2 = gridMitsmori[46, rowIdx];
                    cellShiireKin2 = gridMitsmori[47, rowIdx];

                    cellKakoTanka2 = gridMitsmori[82, rowIdx];
                    cellKakoKin2 = gridMitsmori[83, rowIdx];
                }
                #endregion

                dSuryo = decimal.Parse(getCellValue(gridMitsmori[3, rowIdx], true));
                dTeika = decimal.Parse(getCellValue(gridMitsmori[4, rowIdx], true));
                dMitsuTanka = decimal.Parse(getCellValue(gridMitsmori[5, rowIdx], true));

                dShiireTanka1 = getDecValue(txtShiireTanka1.Text);
                dKakoTanka1 = getDecValue(txtKakoTanka1.Text);
                if (zaiNum != 0) {
                    dShiireTanka2 = getDecValue(txtShiireTanka2.Text);
                    dKakoTanka2 = getDecValue(txtKakoTanka2.Text);
                }

                // 掛率
                if (!dTeika.Equals(0))
                {
                    dKakeritsu1 = Decimal.Round((dShiireTanka1 / dTeika) * 100, 1);
                    dKakeritsu2 = Decimal.Round((dShiireTanka2 / dTeika) * 100, 1);
                }
                txtKakeritsu1.Text = dKakeritsu1.ToString();
                if (zaiNum != 0)
                {
                    txtKakeritsu2.Text = dKakeritsu2.ToString();
                }

                // 粗利
                dShiireKin1 = dShiireTanka1 * dSuryo;
                dShiireKin2 = dShiireTanka2 * dSuryo;
                dKakoKin1 = dKakoTanka1 * dSuryo;
                dKakoKin2 = dKakoTanka2 * dSuryo;
                dArariM = Decimal.Round((dMitsuTanka * dSuryo) - (dShiireKin1 + dKakoKin1 + dShiireKin2 + dKakoKin2), 0);

                txtArari.Text = dArariM.ToString("#,0");

                // 粗利率
                if (!(dMitsuTanka * dSuryo).Equals(0))
                {
                    dArariRitsuM = decimal.Round((dArariM / (dMitsuTanka * dSuryo)) * 100, 1);
                }
                txtArariRitsu.Text = dArariRitsuM.ToString();

                //gridに反映
                if (!dShiireTanka1.Equals(0)) {
                    cellShiireTanka1.Value = dShiireTanka1.ToString("#,0.00");
                    cellShiireKin1.Value = dShiireKin1.ToString("#,0");
                    cellShiireArari1.Value = dArariM.ToString("#,0");
                    cellShiireArariRitsu1.Value = dArariRitsuM.ToString();

                    cellKakoTanka1.Value = dKakoTanka1.ToString("#,0");
                    cellKakoKin1.Value = dKakoKin1.ToString("#,0");

                    if (zaiNum != 0) {
                        cellShiireTanka2.Value = dShiireTanka2.ToString("#,0.00");
                        cellShiireKin2.Value = dShiireKin2.ToString("#,0");

                        cellKakoTanka2.Value = dKakoTanka2.ToString("#,0");
                        cellKakoKin2.Value = dKakoKin2.ToString("#,0");
                    }
                }

                gridMitsmori.EndEdit();
                editFlg = true;

                // 粗利率が閾値未満の場合、フォントカラーを変更
                if (dArariRitsuM < 15)
                {
                    color = Color.Red;
                }
                txtShiireCd1.ForeColor = color;
                txtShiireName1.ForeColor = color;
                txtShiireTeika1.ForeColor = color;
                txtShiireTanka1.ForeColor = color;
                txtKakeritsu1.ForeColor = color;
                txtKakoCd1.ForeColor = color;
                txtKakoName1.ForeColor = color;
                txtKakoTanka1.ForeColor = color;
                txtArari.ForeColor = color;
                txtArariRitsu.ForeColor = color;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        // 合計値計算
        private void changeTotal()
        {
            decimal dShiireTotal = 0;
            decimal dMitsuTotal = 0;
            decimal dArariTotal = 0;
            decimal dArariRitsu = 0;
            decimal dSuryo = 0;
            decimal dTeika = 0;
            decimal dTanka = 0;
            decimal dKin = 0;

            try
            {
                // 粗利、粗利率を更新
                #region
                for (int i = 0; i < gridMitsmori.RowCount; i++)
                {
                    dSuryo = Decimal.Parse(getCellValue(gridMitsmori[3, i], true));
                    dTeika = Decimal.Parse(getCellValue(gridMitsmori[4, i], true));
                    dTanka = Decimal.Parse(getCellValue(gridMitsmori[5, i], true));
                    dKin = Decimal.Parse(getCellValue(gridMitsmori[7, i], true));

                    gridMitsmori[9, i].Value = DBNull.Value;
                    gridMitsmori[10, i].Value = DBNull.Value;
                    //gridMitsmori[10, i].Value = gridMitsmori[19, i].Value;
                    if (string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[12, i], false)))
                    {
                        gridMitsmori[9, i].Value = gridMitsmori[18, i].Value;
                        gridMitsmori[10, i].Value = gridMitsmori[19, i].Value;
                    }
                    else
                    {
                        if ((getCellValue(gridMitsmori[12, i], false)).Equals((getCellValue(gridMitsmori[15, i], false))))
                        {
                            gridMitsmori[9, i].Value = gridMitsmori[18, i].Value;
                            gridMitsmori[10, i].Value = gridMitsmori[19, i].Value;

                        }
                        else if ((getCellValue(gridMitsmori[12, i], false)).Equals((getCellValue(gridMitsmori[21, i], false))))
                        {
                            gridMitsmori[9, i].Value = gridMitsmori[24, i].Value;
                            gridMitsmori[10, i].Value = gridMitsmori[25, i].Value;
                        }
                        else if ((getCellValue(gridMitsmori[12, i], false)).Equals((getCellValue(gridMitsmori[27, i], false))))
                        {
                            gridMitsmori[9, i].Value = gridMitsmori[30, i].Value;
                            gridMitsmori[10, i].Value = gridMitsmori[31, i].Value;
                        }
                    }

                    // 入力可能項目に値が無い場合、空行とみなす
                    if (string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[2, i], false))
                        && string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[3, i], false))
                        && string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[4, i], false))
                        && string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[5, i], false))
                        && string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[11, i], false)))
                    {
                        gridMitsmori[9, i].Value = DBNull.Value;
                        gridMitsmori[10, i].Value = DBNull.Value;
                    }

                    // グリッドの表示情報の桁を整理
                    #region
                    setNumString(gridMitsmori[3, i], "#,0");
                    setNumString(gridMitsmori[4, i], "#,0");
                    setNumString(gridMitsmori[5, i], "#,0");
                    setNumString(gridMitsmori[6, i], "0.0");
                    setNumString(gridMitsmori[7, i], "#,0");
                    setNumString(gridMitsmori[8, i], "#,0.00");


                    setNumString(gridMitsmori[9, i], "#,0");
                    setPerString(gridMitsmori[10, i]);

                    setNumString(gridMitsmori[16, i], "#,0.00");
                    setNumString(gridMitsmori[17, i], "#,0");
                    setNumString(gridMitsmori[18, i], "#,0");
                    setPerString(gridMitsmori[19, i]);

                    setNumString(gridMitsmori[22, i], "#,0.00");
                    setNumString(gridMitsmori[23, i], "#,0");
                    setNumString(gridMitsmori[24, i], "#,0");
                    setPerString(gridMitsmori[25, i]);

                    setNumString(gridMitsmori[28, i], "#,0.00");
                    setNumString(gridMitsmori[29, i], "#,0");
                    setNumString(gridMitsmori[30, i], "#,0");
                    setPerString(gridMitsmori[31, i]);

                    setNumString(gridMitsmori[34, i], "#,0.00");
                    setNumString(gridMitsmori[35, i], "#,0");
                    setNumString(gridMitsmori[36, i], "#,0");
                    setPerString(gridMitsmori[37, i]);

                    setNumString(gridMitsmori[40, i], "#,0.00");
                    setNumString(gridMitsmori[41, i], "#,0");
                    setNumString(gridMitsmori[42, i], "#,0");
                    setPerString(gridMitsmori[43, i]);

                    setNumString(gridMitsmori[46, i], "#,0.00");
                    setNumString(gridMitsmori[47, i], "#,0");
                    setNumString(gridMitsmori[48, i], "#,0");
                    setPerString(gridMitsmori[49, i]);

                    setNumString(gridMitsmori[52, i], "#,0.00");
                    setNumString(gridMitsmori[53, i], "#,0");
                    setNumString(gridMitsmori[54, i], "#,0");
                    setPerString(gridMitsmori[55, i]);

                    setNumString(gridMitsmori[58, i], "#,0.00");
                    setNumString(gridMitsmori[59, i], "#,0");
                    setNumString(gridMitsmori[60, i], "#,0");
                    setPerString(gridMitsmori[61, i]);

                    setNumString(gridMitsmori[64, i], "#,0.00");
                    setNumString(gridMitsmori[65, i], "#,0");
                    setNumString(gridMitsmori[66, i], "#,0");
                    setPerString(gridMitsmori[67, i]);

                    setNumString(gridMitsmori[70, i], "#,0.00");
                    setNumString(gridMitsmori[71, i], "#,0");
                    setNumString(gridMitsmori[72, i], "#,0");
                    setPerString(gridMitsmori[73, i]);

                    setNumString(gridMitsmori[76, i], "#,0.00");
                    setNumString(gridMitsmori[77, i], "#,0");
                    setNumString(gridMitsmori[78, i], "#,0");
                    setPerString(gridMitsmori[79, i]);

                    setNumString(gridMitsmori[82, i], "#,0.00");
                    setNumString(gridMitsmori[83, i], "#,0");
                    setNumString(gridMitsmori[84, i], "#,0");
                    setPerString(gridMitsmori[85, i]);
                    #endregion

                    gridMitsmori.EndEdit();
                    editFlg = true;
                }
                #endregion

                // 仕入合計、売上(見積)合計
                for (int i = 0; i < gridMitsmori.RowCount; i++)
                {
                    dShiireTotal += getDecValue(getCellValue(gridMitsmori[8, i], true)) * getDecValue(getCellValue(gridMitsmori[3, i], true));
                    dMitsuTotal += getDecValue(getCellValue(gridMitsmori[5, i], true)) * getDecValue(getCellValue(gridMitsmori[3, i], true));
                }
                txtSiireTotal.Text = (Decimal.Round(dShiireTotal, 0)).ToString("#,0");
                txtUriTotal.Text = (Decimal.Round(dMitsuTotal, 0)).ToString("#,0");

                // 粗利・粗利率
                dArariTotal = dMitsuTotal - dShiireTotal;
                txtArariTotal.Text = (Decimal.Round(dArariTotal, 0)).ToString("#,0");

                if (!dMitsuTotal.Equals(0))
                {
                    dArariRitsu = (dArariTotal / dMitsuTotal) * 100;
                }
                txtArariRitsu.Text = (Decimal.Round(dArariRitsu, 1)).ToString();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void addRow()
        {
            if (gridMitsmori.CurrentCell == null)
            {
                return;
            }
            int rNum = gridMitsmori.CurrentCell.RowIndex;
            dt.Rows.InsertAt(dt.NewRow(), rNum);
            gridMitsmori[1, rNum].Value = "1";

            for (int i = 0; i < gridMitsmori.RowCount; i++)
            {
                gridMitsmori[0, i].Value = (i + 1).ToString();
            }
        }

        private void delRow()
        {
            if (gridMitsmori.CurrentCell == null)
            {
                return;
            }
            int rNum = gridMitsmori.CurrentCell.RowIndex;
            dt.Rows.RemoveAt(rNum);

            for (int i = 0; i < gridMitsmori.RowCount; i++)
            {
                gridMitsmori[0, i].Value = (i + 1).ToString();
            }
        }

        // 見積検索
        private void txtMNum_Leave(object sender, EventArgs e)
        {
            if (!txtMNum.Text.Equals(oldNum)) {
                oldNum = txtMNum.Text;
                getMitsumoriInfo();
            }
        }

        private void txtMNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                oldNum = txtMNum.Text;
                Form8_2 f = new Form8_2(txtMNum);
                openChildForm(f);
                if (!txtMNum.Text.Equals(oldNum))
                {
                    oldNum = txtMNum.Text;
                    getMitsumoriInfo();
                }
                txtMYMD.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            
        }

        private void getMitsumoriInfo()
        {
            if (string.IsNullOrWhiteSpace(txtMNum.Text))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtMode.Text) && txtMode.Text.Equals("1"))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "見積データをコピーします。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
            }

            intZai1Num = 0;
            intZai2Num = 0;

            H0210_MitsumoriInput_B mInputB = new H0210_MitsumoriInput_B();
            try
            {
                DataTable dtInfo = mInputB.getMitsumoriInfo(txtMNum.Text);

                if (dtInfo == null || dtInfo.Rows.Count == 0)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "見積データがありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
                    txtMNum.Text = "";
                    return;
                }

                txtMYMD.Text = dtInfo.Rows[0]["見積年月日"].ToString();
                txtKenmei.Text = dtInfo.Rows[0]["標題"].ToString();

                txtTanto.Text = dtInfo.Rows[0]["担当者名"].ToString();
                cbNoki.Text = dtInfo.Rows[0]["納期"].ToString();
                cbJoken.Text = dtInfo.Rows[0]["支払条件"].ToString();
                cbKigen.Text = dtInfo.Rows[0]["有効期限"].ToString();
                txtBiko.Text = dtInfo.Rows[0]["備考"].ToString();
                tsTokuisaki.CodeTxtText = dtInfo.Rows[0]["得意先コード"].ToString();
                tsTokuisaki.valueTextText = dtInfo.Rows[0]["得意先名称"].ToString();
                lsTantousha.CodeTxtText = dtInfo.Rows[0]["担当者コード"].ToString();
                lsTantousha.chkTxtTantosha();
                lsEigyosho.CodeTxtText = dtInfo.Rows[0]["営業所コード"].ToString();
                lsEigyosho.chkTxtEigyousho();
                tsNonyusaki.CodeTxtText = dtInfo.Rows[0]["納入先コード"].ToString();
                tsNonyusaki.valueTextText = dtInfo.Rows[0]["納入先名称"].ToString();
                txtMemo.Text = dtInfo.Rows[0]["社内メモ"].ToString();

                dt = mInputB.getMitsumoriDetail(txtMNum.Text);
                int intTrueRows = dt.Rows.Count;

                for (int i = dt.Rows.Count; i < 200; i++)
                {
                    dt.Rows.InsertAt(dt.NewRow(), 999);
                }

                gridMitsmori.DataSource = dt;

                for (int i = 0; i < 200; i++)
                {
                    gridMitsmori[0, i].Value = (i + 1).ToString();
                    gridMitsmori[1, i].Value = "1";

                    decimal dTeika = 0;
                    decimal dTanka = 0;

                    decimal dRitsu = 0;

                    if (getDecValue(getCellValue(gridMitsmori[3, i], true)).Equals(0)
                        && getDecValue(getCellValue(gridMitsmori[4, i], true)).Equals(0)
                        && getDecValue(getCellValue(gridMitsmori[5, i], true)).Equals(0))
                    {
                        gridMitsmori[3, i].Value = DBNull.Value;
                        gridMitsmori[4, i].Value = DBNull.Value;
                        gridMitsmori[5, i].Value = DBNull.Value;
                        gridMitsmori[6, i].Value = DBNull.Value;
                        gridMitsmori[7, i].Value = DBNull.Value;
                        gridMitsmori[8, i].Value = DBNull.Value;
                        gridMitsmori[9, i].Value = DBNull.Value;
                        gridMitsmori[10, i].Value = DBNull.Value;
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[4, i], false)) && !string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[5, i], false))) {
                        dTeika = Decimal.Parse(getCellValue(gridMitsmori[4, i], true));
                        dTanka = Decimal.Parse(getCellValue(gridMitsmori[5, i], true));

                        if (!dTeika.Equals(0))
                        {
                            dRitsu = Decimal.Round((dTanka / dTeika) * 100, 1);
                        }

                        gridMitsmori[6, i].Value = (Decimal.Round(dRitsu, 1)).ToString();
                    }
                }
                //for (int i = 0; i < intTrueRows; i++)
                //{
                //    gridMitsmori[1, i].Value = "1";
                //}
                //if (intTrueRows < 200) {
                //    gridMitsmori[2, intTrueRows].Value = "以下余白";
                //}

                gridMitsmori.EndEdit();
                editFlg = false;

                setText(0);
                changeTotal();
                // 変更時、検索直後は未編集のため、印刷可能とする。
                if (!string.IsNullOrWhiteSpace(txtMode.Text) && txtMode.Text.Equals("2"))
                {
                    editFlg = false;
                }
                if (!string.IsNullOrWhiteSpace(txtMode.Text) && txtMode.Text.Equals("1"))
                {
                    txtMNum.Text = "";
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        // 見積更新
        private void updMitsumori()
        {
            if (!chkData())
            {
                return;
            }
            H0210_MitsumoriInput_B inputB = new H0210_MitsumoriInput_B();
            try
            {
                string strMNum = "";
                inputB.beginTrance();
                if (string.IsNullOrWhiteSpace(txtMNum.Text))
                {
                    strMNum = inputB.getDenpyoNo("見積");
                    txtMNum.Text = strMNum;
                }
                else
                {
                    strMNum = txtMNum.Text;
                }

                changeTotal();

                Form11 f = new Form11();
                Screen s = null;
                Screen[] argScreen = Screen.AllScreens;
                if (argScreen.Length > 1)
                {
                    s = argScreen[1];
                }
                else
                {
                    s = argScreen[0];
                }

                f.StartPosition = FormStartPosition.Manual;
                f.Location = s.Bounds.Location;

                int intMaxLine = 0;
                for (int i = gridMitsmori.RowCount - 1; i >= 0; i--)
                {
                    if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[2, i], false)))
                    {
                        intMaxLine = i + 1;
                        break;
                    }
                }

                for (int i = 0; i < intMaxLine; i++)
                {
                    // 数量、見積単価の両方に値が無いものはコメント行として扱う（分類入力の対象外）
                    if (getCellValue(gridMitsmori[3, i], false).Equals("") && getCellValue(gridMitsmori[5, i], false).Equals(""))
                    {
                        continue;
                    }

                    // 大分類・中分類・メーカー全てに登録のある場合は入力不要のため、分類入力の対象外にする
                    if (!getCellValue(gridMitsmori[87, i], false).Equals("") && !getCellValue(gridMitsmori[88, i], false).Equals("") && !getCellValue(gridMitsmori[89, i], false).Equals(""))
                    {
                        continue;
                    }

                    UserControl2 uc = new UserControl2(gridMitsmori[2, i], gridMitsmori[87, i], gridMitsmori[88, i], gridMitsmori[89, i]);
                    uc.Name = "uc" + i.ToString();
                    f.tableLayoutPanel1.Controls.Add(uc);
                }

                // 分類入力の必要がある場合のみ分類入力を表示
                if (f.tableLayoutPanel1.Controls.Count > 0) {
                    f.FrmParent = this;
                    f.ShowDialog();
                    f.Dispose();
                }
                else
                {
                    UpdFlg = true;
                }

                if (UpdFlg)
                {
                    this.Cursor = Cursors.WaitCursor;

                    //見積ヘッダ登録
                    #region
                    List<String> aryPrm = new List<string>();

                    aryPrm.Add(strMNum);
                    aryPrm.Add(txtMYMD.Text);
                    aryPrm.Add(txtKenmei.Text);
                    aryPrm.Add(txtTanto.Text);
                    aryPrm.Add(cbNoki.Text);
                    aryPrm.Add(cbJoken.Text);
                    aryPrm.Add(cbKigen.Text);
                    aryPrm.Add(txtBiko.Text);
                    aryPrm.Add(tsTokuisaki.CodeTxtText);
                    aryPrm.Add(tsTokuisaki.valueTextText);
                    aryPrm.Add(lsTantousha.CodeTxtText);
                    aryPrm.Add(lsEigyosho.CodeTxtText);
                    aryPrm.Add(txtUriTotal.Text);
                    aryPrm.Add(txtArariTotal.Text);
                    aryPrm.Add(tsNonyusaki.CodeTxtText);
                    aryPrm.Add(tsNonyusaki.valueTextText);
                    aryPrm.Add(txtMemo.Text);
                    aryPrm.Add(Environment.UserName);

                    inputB.updMitsumoriH(aryPrm);
                    #endregion
                    // 見積明細 洗い替え
                    #region
                    inputB.delMitsumoriM(strMNum, Environment.UserName);

                    for (int i = 0; i < intMaxLine; i++)
                    {
                        //if (getCellValue(gridMitsmori[2, i], false).Equals("以下余白"))
                        //{
                        //    break;
                        //}

                        // 商品コードが無い場合は商品登録
                        if (getCellValue(gridMitsmori[86, i], false).Equals(""))
                        {
                            if (getCellValue(gridMitsmori[3, i], false).Equals("") && getCellValue(gridMitsmori[5, i], false).Equals(""))
                            {
                                // コメント行扱いの行は商品登録なし
                            }
                            else
                            {
                                aryPrm = new List<string>();

                                aryPrm.Add("");
                                aryPrm.Add(getCellValue(gridMitsmori[89, i], false));
                                aryPrm.Add(getCellValue(gridMitsmori[87, i], false));
                                aryPrm.Add(getCellValue(gridMitsmori[88, i], false));
                                //aryPrm.Add(getCellValue(gridMitsmori[93, i], false));
                                aryPrm.Add(getCellValue(gridMitsmori[2, i], false));
                                aryPrm.Add(getCellValue(gridMitsmori[94, i], false));
                                aryPrm.Add(getCellValue(gridMitsmori[95, i], false));
                                aryPrm.Add(getCellValue(gridMitsmori[96, i], false));
                                aryPrm.Add(getCellValue(gridMitsmori[97, i], false));
                                aryPrm.Add(getCellValue(gridMitsmori[98, i], false));
                                aryPrm.Add("Y");
                                aryPrm.Add("0");
                                aryPrm.Add(getCellValue(gridMitsmori[8, i], true));
                                aryPrm.Add("0");
                                //aryPrm.Add(null);
                                //aryPrm.Add(null);
                                //aryPrm.Add(null);
                                aryPrm.Add("");
                                aryPrm.Add("");
                                aryPrm.Add("");
                                aryPrm.Add("0");
                                aryPrm.Add(getCellValue(gridMitsmori[4, i], true));
                                aryPrm.Add("0");
                                aryPrm.Add("0");
                                //.Add(null);
                                aryPrm.Add("");

                                //ユーザー名
                                aryPrm.Add(Environment.UserName);

                                string strNewShohin = inputB.updShohinNew(aryPrm, true);
                                gridMitsmori[86, i].Value = strNewShohin;
                            }
                        }

                        aryPrm = new List<string>();
                        aryPrm.Add(strMNum);
                        aryPrm.Add(getCellValue(gridMitsmori[0, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[86, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[89, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[87, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[88, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[93, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[94, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[95, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[96, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[97, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[98, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[2, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[3, i], false));
                        aryPrm.Add(getCellValue(null, true));
                        aryPrm.Add(getCellValue(gridMitsmori[5, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[7, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[8, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[9, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[10, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[11, i], false));

                        if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[14, i], false)) && getCellValue(gridMitsmori[14, i], false).Equals(getCellValue(gridMitsmori[12, i], false)))
                        {
                            aryPrm.Add(getCellValue(gridMitsmori[14, i], false));
                        }
                        else if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[20, i], false)) && getCellValue(gridMitsmori[20, i], false).Equals(getCellValue(gridMitsmori[12, i], false)))
                        {
                            aryPrm.Add(getCellValue(gridMitsmori[20, i], false));
                        }
                        else if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[26, i], false)) && getCellValue(gridMitsmori[26, i], false).Equals(getCellValue(gridMitsmori[12, i], false)))
                        {
                            aryPrm.Add(getCellValue(gridMitsmori[26, i], false));
                        }
                        else
                        {
                            aryPrm.Add("");
                        }

                        aryPrm.Add(getCellValue(gridMitsmori[12, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[13, i], false));

                        aryPrm.Add(getCellValue(gridMitsmori[14, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[15, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[16, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[17, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[18, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[19, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[20, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[21, i], false));

                        aryPrm.Add(getCellValue(gridMitsmori[22, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[23, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[24, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[25, i], false));

                        aryPrm.Add(getCellValue(gridMitsmori[26, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[27, i], false));

                        aryPrm.Add(getCellValue(gridMitsmori[28, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[29, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[30, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[31, i], false));

                        aryPrm.Add(getCellValue(gridMitsmori[32, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[33, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[34, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[35, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[36, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[37, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[38, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[39, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[40, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[41, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[42, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[43, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[44, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[45, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[46, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[47, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[48, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[49, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[50, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[51, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[52, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[53, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[54, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[55, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[56, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[57, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[58, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[59, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[60, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[61, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[62, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[63, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[64, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[65, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[66, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[67, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[68, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[69, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[70, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[71, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[72, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[73, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[74, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[75, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[76, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[77, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[78, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[79, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[80, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[81, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[82, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[83, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[84, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[85, i], false));
                        aryPrm.Add(getCellValue(gridMitsmori[99, i], false));

                        aryPrm.Add(Environment.UserName);

                        inputB.updMitsumoriM(aryPrm);
                    }
                    #endregion

                    inputB.commit();

                    string stMitsumori;
                    string stMeisai;
                    stMitsumori = dbToPdf(gridMitsmori);

                    editFlg = false;
                    this.Cursor = Cursors.Default;

                    PrintDialog pf = new PrintDialog(this);
                    pf.StartPosition = FormStartPosition.CenterScreen;
                    pf.Location = s.Bounds.Location;
                    pf.ShowDialog();
                    pf.Dispose();

                    // 見積書印刷、または見積書＋見積明細印刷時    
                    if (intPrint > 0)
                    {
                        printMitsumori(stMitsumori);
                    }
                    // 見積書＋見積明細印刷時
                    if (intPrint == 2)
                    {
                        stMeisai = dbToPdfMeisai(gridMitsmori);
                        printDetail(stMeisai);
                    }

                    intPrint = 0;
                }
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                inputB.rollback();
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                UpdFlg = false;
            }
        }

        private bool chkData()
        {
            if (string.IsNullOrWhiteSpace(txtMode.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。値を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }
            if (!txtMode.Text.Equals("1") && !txtMode.Text.Equals("2"))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "入力された数値が正しくありません", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMYMD.Text))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。値を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }
            if (string.IsNullOrWhiteSpace(tsTokuisaki.CodeTxtText))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。値を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }
            if (string.IsNullOrWhiteSpace(lsEigyosho.CodeTxtText))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。値を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }
            if (gridMitsmori.RowCount == 0)
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。値を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }

            if (gridMitsmori.RowCount == 0 || !gridMitsmori[0, 0].Value.ToString().Equals("1"))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。値を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }

            //if (string.IsNullOrWhiteSpace(gridMitsmori[2, 0].Value.ToString()))
            //{
            //    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。値を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
            //    basemessagebox.ShowDialog();
            //    return false;
            //}

            return true;
        }

        // 見積削除
        private void delMitsumori()
        {
            BaseMessageBox basemessageboxSa = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_BEFORE, CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_QUESTION);
            //NOが押された場合
            if (basemessageboxSa.ShowDialog() == DialogResult.No)
            {
                return;
            }

            H0210_MitsumoriInput_B inputB = new H0210_MitsumoriInput_B();
            try
            {
                inputB.beginTrance();

                inputB.delMitsumoriM(txtMNum.Text, Environment.UserName);
                inputB.delMitsumoriH(txtMNum.Text, Environment.UserName);

                inputB.commit();

                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_DEL, CommonTeisu.LABEL_DEL_AFTER, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                clearInput();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                inputB.rollback();
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        // 入力欄クリア
        private void clearInput()
        {
            dt = new DataTable();

            for (int i = 0; i < 200; i++)
            {
                dt.Rows.InsertAt(dt.NewRow(), 0);
            }
            gridMitsmori.DataSource = dt;
            for (int i = 0; i < 200; i++)
            {
                gridMitsmori[0, i].Value = (i + 1).ToString();
                gridMitsmori[1, i].Value = "1";
            }

            txtMode.Text = "1";
            txtMNum.Text = "";
            tsTokuisaki.CodeTxtText = "";
            tsTokuisaki.valueTextText = "";
            tsNonyusaki.CodeTxtText = "";
            tsNonyusaki.valueTextText = "";
            txtTanto.Text = "";
            txtKenmei.Text = "";
            cbNoki.SelectedIndex = 0;
            cbKigen.SelectedIndex = 0;
            cbJoken.SelectedIndex = 0;
            cbNoki.Text = "";
            cbKigen.Text = "";
            cbJoken.Text = "";
            txtBiko.Text = "";
            txtMemo.Text = "";
            rd2.Checked = false;
            rd1.Checked = true;
            cbMaker.Checked = true;
            cbChubun.Checked = false;

            txtUriTotal.Text = "";
            txtSiireTotal.Text = "";
            txtArariTotal.Text = "";
            txtArariRitsu.Text = "";

            txtMYMD.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lsTantousha.CodeTxtText = defUser;
            lsTantousha.chkTxtTantosha();
            lsEigyosho.CodeTxtText = defEigyo;
            lsEigyosho.chkTxtEigyousho();

            txtZaiCd1.Text = "";
            txtZaiMei1.Text = "";
            txtZaiTeika1.Text = "";
            txtZaiTnk1.Text = "";
            txtZaiRit1.Text = "";
            txtKakCd1.Text = "";
            txtKakMei1.Text = "";
            txtKakTnk1.Text = "";
            txtArr1.Text = "";
            txtSrrt1.Text = "";

            txtZaiCd2.Text = "";
            txtZaiMei2.Text = "";
            txtZaiTeika2.Text = "";
            txtZaiTnk2.Text = "";
            txtZaiRit2.Text = "";
            txtKakCd2.Text = "";
            txtKakMei2.Text = "";
            txtKakTnk2.Text = "";
            txtArr2.Text = "";
            txtSrrt2.Text = "";

            txtZaiCd3.Text = "";
            txtZaiMei3.Text = "";
            txtZaiTeika3.Text = "";
            txtZaiTnk3.Text = "";
            txtZaiRit3.Text = "";
            txtKakCd3.Text = "";
            txtKakMei3.Text = "";
            txtKakTnk3.Text = "";
            txtArr3.Text = "";
            txtSrrt3.Text = "";

            txtZaiCd4.Text = "";
            txtZaiMei4.Text = "";
            txtZaiTeika4.Text = "";
            txtZaiTnk4.Text = "";
            txtZaiRit4.Text = "";
            txtKakCd4.Text = "";
            txtKakMei4.Text = "";
            txtKakTnk4.Text = "";
            txtArr4.Text = "";
            txtSrrt4.Text = "";

            txtZaiCd5.Text = "";
            txtZaiMei5.Text = "";
            txtZaiTeika5.Text = "";
            txtZaiTnk5.Text = "";
            txtZaiRit5.Text = "";
            txtKakCd5.Text = "";
            txtKakMei5.Text = "";
            txtKakTnk5.Text = "";
            txtArr5.Text = "";
            txtSrrt5.Text = "";

            txtZaiCd6.Text = "";
            txtZaiMei6.Text = "";
            txtZaiTeika6.Text = "";
            txtZaiTnk6.Text = "";
            txtZaiRit6.Text = "";
            txtKakCd6.Text = "";
            txtKakMei6.Text = "";
            txtKakTnk6.Text = "";
            txtArr6.Text = "";
            txtSrrt6.Text = "";
            oldHinmei = "";
            oldNum = "";

            gridMitsmori.CurrentCell = gridMitsmori[0, 0];
            RowIndex = 0;
            ColIndex = 0;
            txtMode.Focus();
        }
        
        // 見積印刷
        private void printMitsumori(string st)
        {
            //string st = null;
            try
            {
                //st = dbToPdf(gridMitsmori);

                //PDFPreviewM pp = new PDFPreviewM(this, st);
                //pp.ShowDialog();
                PrintForm pf = new PrintForm(this, st, Common.Util.CommonTeisu.SIZE_A4, true);
                pf.ShowDialog(this);
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    pf.execPreview(st);
                    //pf.ShowDialog(this);
                    //pf.Close();
                }
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    pf.execPrint(null, st, CommonTeisu.SIZE_A4, CommonTeisu.TATE, false);
                    //pf.Close();
                }
                pf.Dispose();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        public string dbToPdf(BaseDataGridViewEdit dt)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/H0210_MitsumorishoPrint.xlsx";
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                this.Cursor = Cursors.WaitCursor;
                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);

                IXLWorksheet templatesheet1 = workbook.Worksheet(1);   // テンプレートシート
                IXLWorksheet templatesheet2 = workbook.Worksheet(2);   // テンプレートシート（明細行のみ）
                IXLWorksheet currentsheet = null;  // 処理中シート

                int pageCnt = 0;    // ページ(シート枚数)カウント
                int xlsRowCnt = 25;  // Excel出力行カウント（開始は出力行）

                templatesheet1.CopyTo("Page" + pageCnt.ToString());
                currentsheet = workbook.Worksheet(workbook.Worksheets.Count);

                currentsheet.Cell(5, "O").Value = txtMNum.Text;
                //currentsheet.Cell(6, "N").Value = txtMYMD.Text;
                //string stD = txtMYMD.Text;
                //currentsheet.Cell(6, "N").Value = stD.Substring(0, 4) + "年" + stD.Substring(5, 2) + "月" + stD.Substring(8) + "日";
                currentsheet.Cell(6, "O").Value = "'" + (DateTime.Parse(txtMYMD.Text)).ToString("yyyy年MM月dd日");

                if (rd1.Checked)
                {
                    currentsheet.Cell(6, "A").Value = tsTokuisaki.valueTextText;
                }
                else
                {
                    currentsheet.Cell(6, "A").Value = tsNonyusaki.valueTextText;
                }
                currentsheet.Cell(7, "A").Value = txtTanto.Text;
                currentsheet.Cell(9, "B").Value = txtKenmei.Text;
                currentsheet.Cell(12, "C").Value = txtUriTotal.Text;
                currentsheet.Cell(14, "C").Value = cbNoki.Text;
                currentsheet.Cell(16, "C").Value = cbKigen.Text;
                currentsheet.Cell(18, "C").Value = cbJoken.Text;
                currentsheet.Cell(20, "C").Value = txtBiko.Text;

                int intMaxLine = 0;
                for (int i = gridMitsmori.RowCount - 1; i >= 0; i--)
                {
                    if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[2, i], false)))
                    {
                        intMaxLine = i + 1;
                        break;
                    }
                }

                // ClosedXMLで1行ずつExcelに出力
                LabelSet_Chubunrui lc = new LabelSet_Chubunrui();
                LabelSet_Maker lm = new LabelSet_Maker();
                for (int i = 0; i < intMaxLine; i++)
                {
                    if (gridMitsmori[1, i].Value == null || !gridMitsmori[1, i].Value.ToString().Equals("1"))
                    {
                        continue;
                    }
                    if (xlsRowCnt == 55)
                    {
                        pageCnt++;
                        xlsRowCnt = 7;

                        // テンプレートシート（明細行のみ）からコピー
                        templatesheet2.CopyTo("Page" + pageCnt.ToString());
                        currentsheet = workbook.Worksheet(workbook.Worksheets.Count);
                    }
                    string stKata = "";

                    if (!cbMaker.Checked)
                    {
                        lm.strDaibunCd = getCellValue(gridMitsmori[87, i], false);
                        lm.CodeTxtText = getCellValue(gridMitsmori[89, i], false);
                        lm.chkTxtMaker();

                        stKata += lm.ValueLabelText;
                        if (!string.IsNullOrWhiteSpace(stKata))
                        {
                            stKata += " ";
                        }
                    }
                    if (!cbChubun.Checked)
                    {
                        lc.strDaibunCd = getCellValue(gridMitsmori[87, i], false);
                        lc.CodeTxtText = getCellValue(gridMitsmori[88, i], false);
                        lc.chkTxtChubunrui(getCellValue(gridMitsmori[87, i], false));

                        stKata += lc.ValueLabelText;
                        if (!string.IsNullOrWhiteSpace(stKata))
                        {
                            stKata += " ";
                        }
                    }
                    stKata += getCellValue(gridMitsmori[2, i], false);

                    currentsheet.Cell(xlsRowCnt, "A").Value = stKata;
                    currentsheet.Cell(xlsRowCnt, "E").Value = zeroToBlank(getCellValue(gridMitsmori[3, i], false));
                    currentsheet.Cell(xlsRowCnt, "I").Value = zeroToBlank(getCellValue(gridMitsmori[5, i], false));
                    currentsheet.Cell(xlsRowCnt, "L").Value = zeroToBlank(getCellValue(gridMitsmori[7, i], false));
                    currentsheet.Cell(xlsRowCnt, "O").Value = getCellValue(gridMitsmori[11, i], false);

                    xlsRowCnt++;
                }

                // テンプレートシート削除
                templatesheet1.Delete();
                templatesheet2.Delete();

                // ページ数設定
                for (pageCnt = 1; pageCnt <= workbook.Worksheets.Count; pageCnt++)
                {
                    string s = "'" + pageCnt.ToString() + "/" + (workbook.Worksheets.Count).ToString();
                    workbook.Worksheet(pageCnt).Cell("P56").Value = s;      // No.
                    //workbook.Worksheet(pageCnt).Cell("N56").Value = pageCnt.ToString();
                    //workbook.Worksheet(pageCnt).Cell("P56").Value = (workbook.Worksheets.Count).ToString();
                }

                // workbookを保存
                //string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                string strOutXlsFile = strWorkPath + "_" + txtMNum.Text + "_H.xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // ロゴ貼り付け処理
                CreatePdf pdf = new CreatePdf();
                int[] topRow = { 9 };
                int[] leftColumn = { 9 };
                pdf.logoPasteOnlyTopPage(strOutXlsFile, topRow, leftColumn, 50, 400, 70);

                // PDF化の処理
                //return pdf.createPdf(strOutXlsFile, strDateTime, 0);
                return pdf.createPdf(strOutXlsFile, "_" + txtMNum.Text + "_H", 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                // Workフォルダの全ファイルを取得
                string[] files = System.IO.Directory.GetFiles(strWorkPath, "*", System.IO.SearchOption.AllDirectories);
                // Workフォルダ内のファイル削除
                foreach (string filepath in files)
                {
                    //File.Delete(filepath);
                }
                this.Cursor = Cursors.Default;
            }

        }

        // 仕入詳細印刷
        private void printDetail(string st)
        {
            //string st = null;
            try
            {
                //st = dbToPdfMeisai(gridMitsmori);

                //PDFPreviewM pp = new PDFPreviewM(this, st);
                //pp.ShowDialog();
                PrintForm pf = new PrintForm(this, st, CommonTeisu.SIZE_A4, CommonTeisu.YOKO);
                pf.ShowDialog(this);
                if (this.printFlg == CommonTeisu.ACTION_PREVIEW)
                {
                    pf.execPreview(st);
                    //pf.ShowDialog(this);
                    //pf.Close();
                }
                else if (this.printFlg == CommonTeisu.ACTION_PRINT)
                {
                    pf.execPrint(null, st, CommonTeisu.SIZE_A4, CommonTeisu.YOKO, false);
                    //pf.Close();
                }
                pf.Dispose();
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);
                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        public string dbToPdfMeisai(BaseDataGridViewEdit dt)
        {
            string strWorkPath = System.Configuration.ConfigurationManager.AppSettings["workpath"];
            string strFilePath = "./Template/H0210_ShiireDetail.xlsx";
            string strDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                this.Cursor = Cursors.WaitCursor;
                // excelのインスタンス生成
                XLWorkbook workbook = new XLWorkbook(strFilePath, XLEventTracking.Disabled);

                IXLWorksheet templatesheet1 = workbook.Worksheet(1);   // テンプレートシート
                IXLWorksheet templatesheet2 = workbook.Worksheet(2);   // テンプレートシート（明細行のみ）
                IXLWorksheet currentsheet = null;  // 処理中シート

                int pageCnt = 0;    // ページ(シート枚数)カウント
                int xlsRowCnt = 16;  // Excel出力行カウント（開始は出力行）

                templatesheet1.CopyTo("Page" + pageCnt.ToString());
                currentsheet = workbook.Worksheet(workbook.Worksheets.Count);

                currentsheet.Cell(5, "B").Value = tsTokuisaki.valueTextText;
                currentsheet.Cell(6, "B").Value = txtTanto.Text;
                currentsheet.Cell(7, "B").Value = txtKenmei.Text;
                currentsheet.Cell(8, "B").Value = txtUriTotal.Text;
                currentsheet.Cell(9, "B").Value = cbNoki.Text;
                currentsheet.Cell(10, "B").Value = txtMNum.Text;
                currentsheet.Cell(11, "B").Value = txtMYMD.Text;
                currentsheet.Cell(12, "B").Value = lsTantousha.ValueLabelText;
                currentsheet.Cell(13, "B").Value = txtBiko.Text;

                int intMaxLine = 0;
                for (int i = gridMitsmori.RowCount - 1; i >= 0; i--)
                {
                    if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[2, i], false)))
                    {
                        intMaxLine = i + 1;
                        break;
                    }
                }

                // ClosedXMLで1行ずつExcelに出力
                for (int i = 0; i < intMaxLine; i++)
                {
                    if (gridMitsmori[1, i].Value == null || !gridMitsmori[1, i].Value.ToString().Equals("1"))
                    {
                        continue;
                    }
                    if (xlsRowCnt == 49)
                    {
                        pageCnt++;
                        xlsRowCnt = 3;

                        // テンプレートシート（明細行のみ）からコピー
                        templatesheet2.CopyTo("Page" + pageCnt.ToString());
                        currentsheet = workbook.Worksheet(workbook.Worksheets.Count);
                    }
                    string stKata = "";

                    stKata += getCellValue(gridMitsmori[89, i], false);
                    if (!string.IsNullOrWhiteSpace(stKata))
                    {
                        stKata += " ";
                    }
                    stKata += getCellValue(gridMitsmori[88, i], false);
                    if (!string.IsNullOrWhiteSpace(stKata))
                    {
                        stKata += " ";
                    }
                    stKata += getCellValue(gridMitsmori[2, i], false);

                    currentsheet.Cell(xlsRowCnt, "A").Value = stKata;
                    currentsheet.Cell(xlsRowCnt, "C").Value = zeroToBlank(getCellValue(gridMitsmori[3, i], false)); // 数量
                    //currentsheet.Cell(xlsRowCnt, "D").Value = "";
                    currentsheet.Cell(xlsRowCnt, "D").Value = zeroToBlank(getCellValue(gridMitsmori[5, i], false)); // 見積単価
                    currentsheet.Cell(xlsRowCnt, "E").Value = zeroToBlank(getCellValue(gridMitsmori[7, i], false)); // 金額
                    currentsheet.Cell(xlsRowCnt, "F").Value = getCellValue(gridMitsmori[11, i], false);


                    

                    string stShiiresaki = "";
                    string compShiiresaki = "";
                    string stSep = "";
                    decimal decMTanka = 0;
                    decimal decSu = 0;
                    decimal decTanka = 0;
                    decimal decRitsu = 0;

                    decSu = decimal.Parse(getCellValue(gridMitsmori[3, i], true));
                    decMTanka = decimal.Parse(getCellValue(gridMitsmori[5, i], true));

                    if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[12, i], false)))
                    {
                        compShiiresaki = getCellValue(gridMitsmori[12, i], false);

                        if (compShiiresaki.Equals(getCellValue(gridMitsmori[15, i], false)))
                        {
                            stShiiresaki = getCellValue(gridMitsmori[15, i], false).TrimEnd();
                            decTanka += decimal.Parse(getCellValue(gridMitsmori[16, i], true));

                            if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[51, i], false)))
                            {
                                stShiiresaki += "、" + getCellValue(gridMitsmori[51, i], false).TrimEnd();
                                decTanka += decimal.Parse(getCellValue(gridMitsmori[52, i], true));
                            }
                        }
                        else if (compShiiresaki.Equals(getCellValue(gridMitsmori[21, i], false)))
                        {
                            stShiiresaki = getCellValue(gridMitsmori[21, i], false).TrimEnd();
                            decTanka += decimal.Parse(getCellValue(gridMitsmori[22, i], true));

                            if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[57, i], false)))
                            {
                                stShiiresaki += "、" + getCellValue(gridMitsmori[57, i], false).TrimEnd();
                                decTanka += decimal.Parse(getCellValue(gridMitsmori[58, i], true));
                            }
                        }
                        else if (compShiiresaki.Equals(getCellValue(gridMitsmori[27, i], false)))
                        {
                            stShiiresaki = getCellValue(gridMitsmori[27, i], false).TrimEnd();
                            decTanka += decimal.Parse(getCellValue(gridMitsmori[28, i], true));

                            if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[63, i], false)))
                            {
                                stShiiresaki += "、" + getCellValue(gridMitsmori[63, i], false).TrimEnd();
                                decTanka += decimal.Parse(getCellValue(gridMitsmori[64, i], true));
                            }
                        }
                        stSep = "、";
                    }

                    if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[99, i], false)))
                    {
                        compShiiresaki = getCellValue(gridMitsmori[99, i], false);

                        if (compShiiresaki.Equals(getCellValue(gridMitsmori[33, i], false)))
                        {
                            stShiiresaki += stSep + getCellValue(gridMitsmori[33, i], false).TrimEnd();
                            decTanka += decimal.Parse(getCellValue(gridMitsmori[34, i], true));

                            if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[69, i], false)))
                            {
                                stShiiresaki += "、" + getCellValue(gridMitsmori[69, i], false).TrimEnd();
                                decTanka += decimal.Parse(getCellValue(gridMitsmori[70, i], true));
                            }
                        }
                        else if (compShiiresaki.Equals(getCellValue(gridMitsmori[39, i], false)))
                        {
                            stShiiresaki += stSep + getCellValue(gridMitsmori[39, i], false).TrimEnd();
                            decTanka += decimal.Parse(getCellValue(gridMitsmori[40, i], true));

                            if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[75, i], false)))
                            {
                                stShiiresaki += "、" + getCellValue(gridMitsmori[75, i], false).TrimEnd();
                                decTanka += decimal.Parse(getCellValue(gridMitsmori[76, i], true));
                            }
                        }
                        else if (compShiiresaki.Equals(getCellValue(gridMitsmori[45, i], false)))
                        {
                            stShiiresaki += stSep + getCellValue(gridMitsmori[45, i], false).TrimEnd();
                            decTanka += decimal.Parse(getCellValue(gridMitsmori[46, i], true));

                            if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[81, i], false)))
                            {
                                stShiiresaki += "、" + getCellValue(gridMitsmori[81, i], false).TrimEnd();
                                decTanka += decimal.Parse(getCellValue(gridMitsmori[82, i], true));
                            }
                        }
                    }

                    currentsheet.Cell(xlsRowCnt, "G").Value = zeroToBlank(decimal.Round(decTanka, 0).ToString("#,0"));
                    currentsheet.Cell(xlsRowCnt, "H").Value = zeroToBlank(decimal.Round(decTanka * decSu, 0).ToString("#,0"));

                    if (decMTanka.CompareTo(0) != 0)
                    {
                        currentsheet.Cell(xlsRowCnt, "I").Value = zeroToBlank(decimal.Round(((decMTanka - decTanka) / decMTanka) * 100, 1).ToString("#,0.0"));
                    }

                    currentsheet.Cell(xlsRowCnt, "J").Value = stShiiresaki;

                    //currentsheet.Cell(xlsRowCnt, "H").Value = getCellValue(gridMitsmori[15, i], false); // 名称
                    //currentsheet.Cell(xlsRowCnt, "I").Value = zeroToBlank(getCellValue(gridMitsmori[16, i], false)); // 単価
                    //currentsheet.Cell(xlsRowCnt, "J").Value = zeroToBlank(getCellValue(gridMitsmori[19, i], false)); // 率

                    //currentsheet.Cell(xlsRowCnt, "K").Value = getCellValue(gridMitsmori[21, i], false);
                    //currentsheet.Cell(xlsRowCnt, "L").Value = zeroToBlank(getCellValue(gridMitsmori[22, i], false));
                    //currentsheet.Cell(xlsRowCnt, "M").Value = zeroToBlank(getCellValue(gridMitsmori[25, i], false));

                    //currentsheet.Cell(xlsRowCnt, "N").Value = getCellValue(gridMitsmori[27, i], false);
                    //currentsheet.Cell(xlsRowCnt, "O").Value = zeroToBlank(getCellValue(gridMitsmori[28, i], false));
                    //currentsheet.Cell(xlsRowCnt, "P").Value = zeroToBlank(getCellValue(gridMitsmori[31, i], false));

                    //currentsheet.Cell(xlsRowCnt, "Q").Value = getCellValue(gridMitsmori[33, i], false);
                    //currentsheet.Cell(xlsRowCnt, "R").Value = zeroToBlank(getCellValue(gridMitsmori[34, i], false));
                    //currentsheet.Cell(xlsRowCnt, "S").Value = zeroToBlank(getCellValue(gridMitsmori[37, i], false));

                    //currentsheet.Cell(xlsRowCnt, "T").Value = getCellValue(gridMitsmori[39, i], false);
                    //currentsheet.Cell(xlsRowCnt, "U").Value = zeroToBlank(getCellValue(gridMitsmori[40, i], false));
                    //currentsheet.Cell(xlsRowCnt, "V").Value = zeroToBlank(getCellValue(gridMitsmori[43, i], false));

                    //currentsheet.Cell(xlsRowCnt, "W").Value = getCellValue(gridMitsmori[45, i], false);
                    //currentsheet.Cell(xlsRowCnt, "X").Value = zeroToBlank(getCellValue(gridMitsmori[46, i], false));
                    //currentsheet.Cell(xlsRowCnt, "Y").Value = zeroToBlank(getCellValue(gridMitsmori[49, i], false));


                    //currentsheet.Cell(xlsRowCnt, "Z").Value = getCellValue(gridMitsmori[51, i], false);
                    //currentsheet.Cell(xlsRowCnt, "AA").Value = zeroToBlank(getCellValue(gridMitsmori[52, i], false));
                    //currentsheet.Cell(xlsRowCnt, "AB").Value = zeroToBlank(getCellValue(gridMitsmori[55, i], false));

                    //currentsheet.Cell(xlsRowCnt, "AC").Value = getCellValue(gridMitsmori[57, i], false);
                    //currentsheet.Cell(xlsRowCnt, "AD").Value = zeroToBlank(getCellValue(gridMitsmori[58, i], false));
                    //currentsheet.Cell(xlsRowCnt, "AE").Value = zeroToBlank(getCellValue(gridMitsmori[61, i], false));

                    //currentsheet.Cell(xlsRowCnt, "AF").Value = getCellValue(gridMitsmori[63, i], false);
                    //currentsheet.Cell(xlsRowCnt, "AG").Value = zeroToBlank(getCellValue(gridMitsmori[64, i], false));
                    //currentsheet.Cell(xlsRowCnt, "AH").Value = zeroToBlank(getCellValue(gridMitsmori[67, i], false));

                    //currentsheet.Cell(xlsRowCnt, "AI").Value = getCellValue(gridMitsmori[69, i], false);
                    //currentsheet.Cell(xlsRowCnt, "AJ").Value = zeroToBlank(getCellValue(gridMitsmori[70, i], false));
                    //currentsheet.Cell(xlsRowCnt, "AK").Value = zeroToBlank(getCellValue(gridMitsmori[73, i], false));

                    //currentsheet.Cell(xlsRowCnt, "AL").Value = getCellValue(gridMitsmori[75, i], false);
                    //currentsheet.Cell(xlsRowCnt, "AM").Value = zeroToBlank(getCellValue(gridMitsmori[76, i], false));
                    //currentsheet.Cell(xlsRowCnt, "AN").Value = zeroToBlank(getCellValue(gridMitsmori[79, i], false));

                    //currentsheet.Cell(xlsRowCnt, "AO").Value = getCellValue(gridMitsmori[81, i], false);
                    //currentsheet.Cell(xlsRowCnt, "AP").Value = zeroToBlank(getCellValue(gridMitsmori[82, i], false));
                    //currentsheet.Cell(xlsRowCnt, "AQ").Value = zeroToBlank(getCellValue(gridMitsmori[85, i], false));

                    xlsRowCnt++;
                }

                // テンプレートシート削除
                templatesheet1.Delete();
                templatesheet2.Delete();

                // ページ数設定
                for (pageCnt = 1; pageCnt <= workbook.Worksheets.Count; pageCnt++)
                {
                    workbook.Worksheet(pageCnt).Cell("J49").Value = "'" + pageCnt.ToString() + "/" + (workbook.Worksheets.Count).ToString("0");      // No.
                }

                // workbookを保存
                //string strOutXlsFile = strWorkPath + strDateTime + ".xlsx";
                string strOutXlsFile = strWorkPath + "_" + txtMNum.Text + "_M.xlsx";
                workbook.SaveAs(strOutXlsFile);

                // workbookを解放
                workbook.Dispose();

                // PDF化の処理
                //return pdf.createPdf(strOutXlsFile, strDateTime, 0);
                CreatePdf pdf = new CreatePdf();
                return pdf.createPdf(strOutXlsFile, "_" + txtMNum.Text + "_M", 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                // Workフォルダの全ファイルを取得
                string[] files = System.IO.Directory.GetFiles(strWorkPath, "*", System.IO.SearchOption.AllDirectories);
                // Workフォルダ内のファイル削除
                foreach (string filepath in files)
                {
                    //File.Delete(filepath);
                }
                this.Cursor = Cursors.Default;
            }
        }

        // 仕入先
        private void txtZaiCd1_Leave(object sender, EventArgs e)
        {
            setShiiresaki((BaseText)sender, true);
        }

        private void txtZaiCd1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            keyFlgF9 = false;
            if (e.KeyCode == Keys.F9)
            {
                //setShiiresaki((BaseText)sender, true);
                LabelSet_Torihikisaki ls = new LabelSet_Torihikisaki();
                TorihikisakiList tl = new TorihikisakiList(this, ls);
                tl.ShowDialog();

                if (((BaseText)sender).Name.Equals("txtZaiCd1"))
                {
                    txtZaiCd1.Text = ls.CodeTxtText;
                    txtZaiMei1.Text = ls.ValueLabelText;
                    gridMitsmori[14, gridMitsmori.CurrentCell.RowIndex].Value = ls.CodeTxtText;
                    gridMitsmori[15, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
                else if (((BaseText)sender).Name.Equals("txtZaiCd2"))
                {
                    txtZaiCd2.Text = ls.CodeTxtText;
                    txtZaiMei2.Text = ls.ValueLabelText;
                    gridMitsmori[20, gridMitsmori.CurrentCell.RowIndex].Value = null;
                    gridMitsmori[21, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
                else if (((BaseText)sender).Name.Equals("txtZaiCd3"))
                {
                    txtZaiCd3.Text = ls.CodeTxtText;
                    txtZaiMei3.Text = ls.ValueLabelText;
                    gridMitsmori[26, gridMitsmori.CurrentCell.RowIndex].Value = null;
                    gridMitsmori[27, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
                else if (((BaseText)sender).Name.Equals("txtZaiCd4"))
                {
                    txtZaiCd4.Text = ls.CodeTxtText;
                    txtZaiMei4.Text = ls.ValueLabelText;
                    gridMitsmori[32, gridMitsmori.CurrentCell.RowIndex].Value = null;
                    gridMitsmori[33, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
                else if (((BaseText)sender).Name.Equals("txtZaiCd5"))
                {
                    txtZaiCd5.Text = ls.CodeTxtText;
                    txtZaiMei5.Text = ls.ValueLabelText;
                    gridMitsmori[38, gridMitsmori.CurrentCell.RowIndex].Value = null;
                    gridMitsmori[39, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
                else if (((BaseText)sender).Name.Equals("txtZaiCd6"))
                {
                    txtZaiCd6.Text = ls.CodeTxtText;
                    txtZaiMei6.Text = ls.ValueLabelText;
                    gridMitsmori[44, gridMitsmori.CurrentCell.RowIndex].Value = null;
                    gridMitsmori[45, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
                else if (((BaseText)sender).Name.Equals("txtKakCd1"))
                {
                    txtKakCd1.Text = ls.CodeTxtText;
                    txtKakMei1.Text = ls.ValueLabelText;
                    gridMitsmori[50, gridMitsmori.CurrentCell.RowIndex].Value = null;
                    gridMitsmori[51, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
                else if (((BaseText)sender).Name.Equals("txtKakCd2"))
                {
                    txtKakCd2.Text = ls.CodeTxtText;
                    txtKakMei2.Text = ls.ValueLabelText;
                    gridMitsmori[56, gridMitsmori.CurrentCell.RowIndex].Value = null;
                    gridMitsmori[57, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
                else if (((BaseText)sender).Name.Equals("txtKakCd3"))
                {
                    txtKakCd3.Text = ls.CodeTxtText;
                    txtKakMei3.Text = ls.ValueLabelText;
                    gridMitsmori[62, gridMitsmori.CurrentCell.RowIndex].Value = null;
                    gridMitsmori[63, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
                else if (((BaseText)sender).Name.Equals("txtKakCd4"))
                {
                    txtKakCd4.Text = ls.CodeTxtText;
                    txtKakMei4.Text = ls.ValueLabelText;
                    gridMitsmori[68, gridMitsmori.CurrentCell.RowIndex].Value = null;
                    gridMitsmori[69, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
                else if (((BaseText)sender).Name.Equals("txtKakCd5"))
                {
                    txtKakCd5.Text = ls.CodeTxtText;
                    txtKakMei5.Text = ls.ValueLabelText;
                    gridMitsmori[74, gridMitsmori.CurrentCell.RowIndex].Value = null;
                    gridMitsmori[75, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
                else if (((BaseText)sender).Name.Equals("txtKakCd6"))
                {
                    txtKakCd6.Text = ls.CodeTxtText;
                    txtKakMei6.Text = ls.ValueLabelText;
                    gridMitsmori[80, gridMitsmori.CurrentCell.RowIndex].Value = null;
                    gridMitsmori[81, gridMitsmori.CurrentCell.RowIndex].Value = ls.ValueLabelText;
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                //SendKeys.Send("{Tab}");
                //setShiiresaki((BaseText)sender, true);
            }
        }

        private void setShiiresaki(BaseText sender, bool b) {
            if (string.IsNullOrWhiteSpace(sender.Text))
            {
                return;
            }

            sender.Text = sender.Text.Trim();
            if (sender.Text.Length < 4)
            {
                sender.Text = sender.Text.PadLeft(4, '0');
            }

            List<string> lstStringSQL = new List<string>();

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_Torihikisaki_SELECT_LEAVE");

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                if (string.IsNullOrWhiteSpace(strSQLInput))
                {
                    return;
                }

                strSQLInput = string.Format(strSQLInput, sender.Text);

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                DataTable dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count != 0)
                {
                    sender.Text = dtSetCd.Rows[0]["取引先コード"].ToString();
                    
                    if (sender.Name.Equals("txtZaiCd1"))
                    {
                        txtZaiMei1.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[14, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[15, gridMitsmori.CurrentCell.RowIndex].Value = txtZaiMei1.Text;
                        txtZaiTnk1.Focus();
                    }
                    else if (sender.Name.Equals("txtZaiCd2"))
                    {
                        txtZaiMei2.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[20, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[21, gridMitsmori.CurrentCell.RowIndex].Value = txtZaiMei2.Text;
                        txtZaiTnk2.Focus();
                    }
                    else if (sender.Name.Equals("txtZaiCd3"))
                    {
                        txtZaiMei3.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[26, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[27, gridMitsmori.CurrentCell.RowIndex].Value = txtZaiMei3.Text;
                        txtZaiTnk3.Focus();
                    }
                    else if (sender.Name.Equals("txtZaiCd4"))
                    {
                        txtZaiMei4.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[32, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[33, gridMitsmori.CurrentCell.RowIndex].Value = txtZaiMei4.Text;
                        txtZaiTnk4.Focus();
                    }
                    else if (sender.Name.Equals("txtZaiCd5"))
                    {
                        txtZaiMei5.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[38, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[39, gridMitsmori.CurrentCell.RowIndex].Value = txtZaiMei5.Text;
                        txtZaiTnk5.Focus();
                    }
                    else if (sender.Name.Equals("txtZaiCd6"))
                    {
                        txtZaiMei6.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[44, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[45, gridMitsmori.CurrentCell.RowIndex].Value = txtZaiMei6.Text;
                        txtZaiTnk6.Focus();
                    }
                    else if (sender.Name.Equals("txtKakCd1"))
                    {
                        txtKakMei1.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[50, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[51, gridMitsmori.CurrentCell.RowIndex].Value = txtKakMei1.Text;
                    }
                    else if (sender.Name.Equals("txtKakCd2"))
                    {
                        txtKakMei2.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[56, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[57, gridMitsmori.CurrentCell.RowIndex].Value = txtKakMei2.Text;
                    }
                    else if (sender.Name.Equals("txtKakCd3"))
                    {
                        txtKakMei3.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[62, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[63, gridMitsmori.CurrentCell.RowIndex].Value = txtKakMei3.Text;
                    }
                    else if (sender.Name.Equals("txtKakCd4"))
                    {
                        txtKakMei4.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[68, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[69, gridMitsmori.CurrentCell.RowIndex].Value = txtKakMei4.Text;
                    }
                    else if (sender.Name.Equals("txtKakCd5"))
                    {
                        txtKakMei5.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[74, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[75, gridMitsmori.CurrentCell.RowIndex].Value = txtKakMei5.Text;
                    }
                    else if (sender.Name.Equals("txtKakCd6"))
                    {
                        txtKakMei6.Text = dtSetCd.Rows[0]["取引先名称"].ToString();
                        gridMitsmori[80, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[81, gridMitsmori.CurrentCell.RowIndex].Value = txtKakMei6.Text;
                    }
                    gridMitsmori.EndEdit();
                    editFlg = false;
                }
                else
                {
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    if (b == true) {
                        if (bCdflg) {
                            BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                            basemessagebox.ShowDialog();
                            bCdflg = false;
                        }
                        else
                        {
                            bCdflg = true;
                        }
                    }

                    if (sender.Name.Equals("txtZaiCd1"))
                    {
                        gridMitsmori[14, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[15, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtZaiMei1.Text = "";
                        txtZaiCd1.Focus();
                    }
                    else if (sender.Name.Equals("txtZaiCd2"))
                    {
                        gridMitsmori[20, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[21, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtZaiMei2.Text = "";
                        txtZaiCd2.Focus();
                    }
                    else if (sender.Name.Equals("txtZaiCd3"))
                    {
                        gridMitsmori[26, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[27, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtZaiMei3.Text = "";
                        txtZaiCd3.Focus();
                    }
                    else if (sender.Name.Equals("txtZaiCd4"))
                    {
                        gridMitsmori[32, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[33, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtZaiCd4.Text = "";
                        txtZaiCd4.Focus();
                    }
                    else if (sender.Name.Equals("txtZaiCd5"))
                    {
                        gridMitsmori[38, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[39, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtZaiCd5.Text = "";
                        txtZaiCd5.Focus();
                    }
                    else if (sender.Name.Equals("txtZaiCd6"))
                    {
                        gridMitsmori[44, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[45, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtZaiCd6.Text = "";
                        txtZaiCd6.Focus();
                    }
                    else if (sender.Name.Equals("txtKakCd1"))
                    {
                        gridMitsmori[50, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[51, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtKakMei1.Text = "";
                        txtKakCd1.Focus();
                    }
                    else if (sender.Name.Equals("txtKakCd2"))
                    {
                        gridMitsmori[56, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[57, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtKakMei2.Text = "";
                        txtKakCd2.Focus();
                    }
                    else if (sender.Name.Equals("txtKakCd3"))
                    {
                        gridMitsmori[62, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[63, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtKakMei3.Text = "";
                        txtKakCd3.Focus();
                    }
                    else if (sender.Name.Equals("txtKakCd4"))
                    {
                        gridMitsmori[68, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[69, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtKakMei4.Text = "";
                        txtKakCd4.Focus();
                    }
                    else if (sender.Name.Equals("txtKakCd5"))
                    {
                        gridMitsmori[74, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[75, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtKakMei5.Text = "";
                        txtKakCd5.Focus();
                    }
                    else if (sender.Name.Equals("txtKakCd6"))
                    {
                        gridMitsmori[80, gridMitsmori.CurrentCell.RowIndex].Value = sender.Text;
                        gridMitsmori[81, gridMitsmori.CurrentCell.RowIndex].Value = "";
                        txtKakMei6.Text = "";
                        txtKakCd6.Focus();
                    }
                    gridMitsmori.EndEdit();
                    editFlg = false;

                    return;
                }
                return;
            }
            catch (Exception ex)
            {
                //データロギング
                new CommonException(ex);

                //例外発生メッセージ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        // 編集部項目入れ替え
        private void button2_Click(object sender, EventArgs e)
        {
            changeEditItem(txtZaiCd4, txtZaiMei4, txtZaiTnk4, txtZaiCd5, txtZaiMei5, txtZaiTnk5,
               gridMitsmori[32, RowIndex], gridMitsmori[33, RowIndex],
               gridMitsmori[38, RowIndex], gridMitsmori[39, RowIndex]);

            calc(1, intZai2Num);
            calc(2, intZai2Num);
            calc(3, intZai2Num);
            changeTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeEditItem(txtZaiCd4, txtZaiMei4, txtZaiTnk4, txtZaiCd5, txtZaiMei5, txtZaiTnk5,
                gridMitsmori[38, RowIndex], gridMitsmori[39, RowIndex],
                gridMitsmori[44, RowIndex], gridMitsmori[45, RowIndex]);

            calc(1, intZai2Num);
            calc(2, intZai2Num);
            calc(3, intZai2Num);
            changeTotal();

        }

        private void button25_Click(object sender, EventArgs e)
        {
            changeEditItem(txtKakCd1, txtKakMei1, txtKakTnk1, txtKakCd2, txtKakMei2, txtKakTnk2,
                gridMitsmori[50, RowIndex], gridMitsmori[51, RowIndex],
                gridMitsmori[56, RowIndex], gridMitsmori[57, RowIndex]);

            calc(1, intZai2Num);
            calc(2, intZai2Num);
            calc(3, intZai2Num);
            changeTotal();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            changeEditItem(txtKakCd2, txtKakMei2, txtKakTnk2, txtKakCd3, txtKakMei3, txtKakTnk3,
                gridMitsmori[56, RowIndex], gridMitsmori[57, RowIndex],
                gridMitsmori[62, RowIndex], gridMitsmori[63, RowIndex]);

            calc(1, intZai2Num);
            calc(2, intZai2Num);
            calc(3, intZai2Num);
            changeTotal();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            changeEditItem(txtKakCd4, txtKakMei4, txtKakTnk4, txtKakCd5, txtKakMei5, txtKakTnk5,
               gridMitsmori[68, RowIndex], gridMitsmori[69, RowIndex],
               gridMitsmori[74, RowIndex], gridMitsmori[75, RowIndex]);

            calc(1, intZai2Num);
            calc(2, intZai2Num);
            calc(3, intZai2Num);
            changeTotal();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            changeEditItem(txtKakCd5, txtKakMei5, txtKakTnk5, txtKakCd6, txtKakMei6, txtKakTnk6,
               gridMitsmori[74, RowIndex], gridMitsmori[75, RowIndex],
               gridMitsmori[80, RowIndex], gridMitsmori[81, RowIndex]);

            calc(1, intZai2Num);
            calc(2, intZai2Num);
            calc(3, intZai2Num);
            changeTotal();
        }

        private void changeEditItem(BaseText cd1, BaseText nm1, BaseTextMoney tan1,
            BaseText cd2, BaseText nm2, BaseTextMoney tan2,
            DataGridViewCell cCd1, DataGridViewCell cNm1, DataGridViewCell cCd2, DataGridViewCell cNm2)
        {
            string tmpCd = cd1.Text;
            string tmpNm = nm1.Text;
            string tmpTan = tan1.Text;

            cd1.Text = cd2.Text;
            nm1.Text = nm2.Text;
            tan1.Text = tan2.Text;

            cd2.Text = tmpCd;
            nm2.Text = tmpNm;
            tan2.Text = tmpTan;

            cCd1.Value = cd1.Text;
            cNm1.Value = nm1.Text;
            cCd2.Value = cd2.Text;
            cNm2.Value = nm2.Text;
            gridMitsmori.EndEdit();
            editFlg = false;

        }

        // 編集部仕入先選択
        private void button13_Click(object sender, EventArgs e)
        {
            setRowBGColor1(Color.FromArgb(0x66, 0xFF, 0x66));
            setRowBGColor2(Color.White);
            setRowBGColor3(Color.White);

            intZai1Num = 1;
            selectEditItem(1, intZai2Num);
            changeTotal();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            setRowBGColor1(Color.White);
            setRowBGColor2(Color.FromArgb(0x66, 0xFF, 0x66));
            setRowBGColor3(Color.White);

            intZai1Num = 2;
            selectEditItem(2, intZai2Num);
            changeTotal();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            setRowBGColor1(Color.White);
            setRowBGColor2(Color.White);
            setRowBGColor3(Color.FromArgb(0x66, 0xFF, 0x66));

            intZai1Num = 3;
            selectEditItem(3, intZai2Num);
            changeTotal();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            setRowBGColor4(Color.FromArgb(0x66, 0xFF, 0x66));
            setRowBGColor5(Color.White);
            setRowBGColor6(Color.White);

            intZai2Num = 4;
            selectEditItem(intZai1Num, 4);
            calc(1, intZai2Num);
            calc(2, intZai2Num);
            calc(3, intZai2Num);
            changeTotal();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            setRowBGColor4(Color.White);
            setRowBGColor5(Color.FromArgb(0x66, 0xFF, 0x66));
            setRowBGColor6(Color.White);

            intZai2Num = 5;
            selectEditItem(intZai1Num, 5);
            calc(1, intZai2Num);
            calc(2, intZai2Num);
            calc(3, intZai2Num);
            changeTotal();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            setRowBGColor4(Color.White);
            setRowBGColor5(Color.White);
            setRowBGColor6(Color.FromArgb(0x66, 0xFF, 0x66));

            intZai2Num = 6;
            selectEditItem(intZai1Num, 6);
            calc(1, intZai2Num);
            calc(2, intZai2Num);
            calc(3, intZai2Num);
            changeTotal();
        }

        private void selectEditItem(int numZai1, int numZai2)
        {
            decimal dZai1 = 0;
            decimal dKak1 = 0;
            decimal dZai2 = 0;
            decimal dKak2 = 0;

            if (numZai1 == 1)
            {
                dZai1 = decimal.Parse(getCellValue(gridMitsmori[16, RowIndex], true));
                dKak1 = decimal.Parse(getCellValue(gridMitsmori[52, RowIndex], true));

                gridMitsmori[12, RowIndex].Value = gridMitsmori[15, RowIndex].Value;
            }
            else if (numZai1 == 2)
            {
                dZai1 = decimal.Parse(getCellValue(gridMitsmori[22, RowIndex], true));
                dKak1 = decimal.Parse(getCellValue(gridMitsmori[58, RowIndex], true));

                gridMitsmori[12, RowIndex].Value = gridMitsmori[21, RowIndex].Value;
            }
            else if (numZai1 == 3)
            {
                dZai1 = decimal.Parse(getCellValue(gridMitsmori[28, RowIndex], true));
                dKak1 = decimal.Parse(getCellValue(gridMitsmori[64, RowIndex], true));

                gridMitsmori[12, RowIndex].Value = gridMitsmori[27, RowIndex].Value;
            }

            if (numZai2 == 4)
            {
                dZai2 = decimal.Parse(getCellValue(gridMitsmori[34, RowIndex], true));
                dKak2 = decimal.Parse(getCellValue(gridMitsmori[70, RowIndex], true));

                gridMitsmori[99, RowIndex].Value = gridMitsmori[33, RowIndex].Value;
            }
            else if (numZai2 == 5)
            {
                dZai2 = decimal.Parse(getCellValue(gridMitsmori[40, RowIndex], true));
                dKak2 = decimal.Parse(getCellValue(gridMitsmori[76, RowIndex], true));

                gridMitsmori[99, RowIndex].Value = gridMitsmori[39, RowIndex].Value;
            }
            else if (numZai2 == 6)
            {
                dZai2 = decimal.Parse(getCellValue(gridMitsmori[46, RowIndex], true));
                dKak2 = decimal.Parse(getCellValue(gridMitsmori[82, RowIndex], true));

                gridMitsmori[99, RowIndex].Value = gridMitsmori[45, RowIndex].Value;
            }
            if (numZai1 > 0 || numZai2 > 0)
            {
                gridMitsmori[8, RowIndex].Value = (decimal.Round(dZai1 + dKak1 + dZai2 + dKak2, 0)).ToString();
            }

            gridMitsmori.EndEdit();
            editFlg = false;

        }

        // util系
        public decimal getDecValue(string s)
        {
            decimal d = 0;

            if (!string.IsNullOrWhiteSpace(s))
            {
                try
                {
                    d = decimal.Parse(s);
                }
                catch (Exception e)
                {
                }
            }

            return d;
        }
        private string getCellValue(DataGridViewCell c, bool zero)
        {
            string ret = "";
            if (zero)
            {
                ret = "0";
            }

            if (c != null && c.Value != null && !string.IsNullOrWhiteSpace(c.Value.ToString()))
            {
                ret = c.Value.ToString();
            }
            return ret;
        }
        private string getCellValueDBNull(DataGridViewCell c, bool zero)
        {
            string ret = "";
            if (zero)
            {
                ret = "0";
            }

            if (c != null && c.Value != null && !string.IsNullOrWhiteSpace(c.Value.ToString()))
            {
                ret = c.Value.ToString();
            }
            return ret;
        }
        private Boolean cellValueChecker(int col, int row)
        {
            Boolean flg = false;

            DataGridViewCell nowCell = gridMitsmori[col, row];
            if (nowCell != null)
            {
                if (nowCell.Value != null)
                {
                    flg = true;
                }
            }

            return flg;
        }
        private Boolean cellValueCheckerN(int col, int row)
        {
            Boolean flg = false;

            DataGridViewCell nowCell = gridMitsmori[col, row];
            if (nowCell != null)
            {
                if (nowCell.Value != null)
                {
                    if (!string.IsNullOrWhiteSpace(nowCell.Value.ToString()))
                    {
                        flg = true;
                    }
                }
            }

            return flg;
        }
        private string zeroToBlank(String s)
        {
            string ret = "";
            decimal d = 0;

            if (!string.IsNullOrEmpty(s))
            {
                try
                {
                    d = decimal.Parse(s);
                }
                catch (Exception e)
                {
                    // 数値以外の値なのでそのまま返す
                    return s;
                }
            }
            if (!d.Equals(0))
            {
                ret = s;
            }
            return ret;
            
        }
        private void openChildForm(Form8_2 f)
        {
            Screen s = null;
            Screen[] argScreen = Screen.AllScreens;
            if (argScreen.Length > 1)
            {
                s = argScreen[1];
            }
            else
            {
                s = argScreen[0];
            }

            f.StartPosition = FormStartPosition.Manual;
            f.Location = s.Bounds.Location;
            f.lsTanto.CodeTxtText = lsTantousha.CodeTxtText;
            if (!string.IsNullOrWhiteSpace(tsTokuisaki.CodeTxtText) && !string.IsNullOrWhiteSpace(tsTokuisaki.valueTextText))
            {
                f.lsTokui.CodeTxtText = tsTokuisaki.CodeTxtText;
            }

            f.ShowDialog(this);
            f.Dispose();
        }

        private void txtTanto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void cmbSubWinShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubWinShow.SelectedIndex == 0)
            {
                uriKakunin = new D0310_UriageJissekiKakunin.D0310_UriageJissekiKakunin(this);
                
                Screen s = null;
                Screen[] argScreen = Screen.AllScreens;
                if (argScreen.Length > 1)
                {
                    s = argScreen[1];
                }
                else
                {
                    s = argScreen[0];
                }

                uriKakunin.StartPosition = FormStartPosition.Manual;
                uriKakunin.Location = s.Bounds.Location;

                uriKakunin.ShowDialog();
                uriKakunin.Dispose();
            }
        }

        private void openJuchu()
        {
            BaseMessageBox bb = new BaseMessageBox(this, CommonTeisu.TEXT_TOUROKU, "受注入力を行いますか？", CommonTeisu.BTN_YESNO, CommonTeisu.DIAG_INFOMATION);
            if (bb.ShowDialog() == DialogResult.Yes)
            {
                A0010_JuchuInput.A0010_JuchuInput jInput = new A0010_JuchuInput.A0010_JuchuInput(this);

                jInput.tsTokuisaki.CodeTxtText = tsTokuisaki.CodeTxtText;

                for (int i = 0; i < gridMitsmori.RowCount; i++)
                {
                    if (!string.IsNullOrWhiteSpace(getCellValue(gridMitsmori[86, i], false)))
                    {
                        jInput.txtShohinCd.Text = getCellValue(gridMitsmori[86, i], false);
                        jInput.lsDaibunrui.CodeTxtText = getCellValue(gridMitsmori[87, i], false);
                        jInput.lsDaibunrui.chkTxtDaibunrui();
                        jInput.lsChubunrui.CodeTxtText = getCellValue(gridMitsmori[88, i], false);
                        jInput.lsChubunrui.chkTxtChubunrui(jInput.lsDaibunrui.CodeTxtText);
                        jInput.lsMaker.CodeTxtText = getCellValue(gridMitsmori[89, i], false);
                        jInput.lsMaker.chkTxtMaker();
                        jInput.txtHinmei.Text = getCellValue(gridMitsmori[2, i], false);
                        jInput.txtJuchuSuryo.Text = decimal.Round(getDecValue(getCellValue(gridMitsmori[3, i], false)), 0).ToString("#,0");
                        jInput.txtTeika.Text = decimal.Round(getDecValue(getCellValue(gridMitsmori[4, i], false)),0).ToString("#,0");
                        jInput.cbJuchuTanka.Text = decimal.Round(getDecValue(getCellValue(gridMitsmori[5, i], false)), 0).ToString("#");
                        jInput.cbSiireTanka.Text = decimal.Round(getDecValue(getCellValue(gridMitsmori[8, i], false)), 0).ToString("0.00");
                        jInput.txtC1.Text = getCellValue(gridMitsmori[93, i], false);
                        jInput.txtC2.Text = getCellValue(gridMitsmori[94, i], false);
                        jInput.txtC3.Text = getCellValue(gridMitsmori[95, i], false);
                        jInput.txtC4.Text = getCellValue(gridMitsmori[96, i], false);
                        jInput.txtC5.Text = getCellValue(gridMitsmori[97, i], false);
                        jInput.txtC6.Text = getCellValue(gridMitsmori[98, i], false);
                        break;
                    }
                }
                jInput.Show();
            }
        }

        private void txtBiko_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (gridMitsmori.RowCount > 0)
                {
                    gridMitsmori.CurrentCell = gridMitsmori[2, 0];
                    gridMitsmori.Focus();
                }
                else
                {
                    txtMemo.Focus();
                }
            }
        }

        private void txtMode_Leave(object sender, EventArgs e)
        {
            oldNum = "";
            oldHinmei = "";
        }

        private void setNumString(DataGridViewCell c, string s)
        {
            decimal d = 0;

            if (string.IsNullOrWhiteSpace((getCellValue(c, false))))
            {
                return;
            }

            d = Decimal.Parse(getCellValue(c, true));
            c.Value = (decimal.Round(d, 0)).ToString(s);
        }
        private void setPerString(DataGridViewCell c)
        {
            decimal d = 0;

            if (string.IsNullOrWhiteSpace((getCellValue(c, false))))
            {
                return;
            }

            d = Decimal.Parse(getCellValue(c, true));
            c.Value = (decimal.Round(d, 0)).ToString("0.0");
        }

        
    }

}
