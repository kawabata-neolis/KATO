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
using KATO.Business.H0210_MitsumoriInput_B;

namespace KATO.Form.H0210_MitsumoriInput
{
    public partial class H0210_MitsumoriInput : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Boolean bFirst = true;
        private Boolean bCdflg = true;

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

        private Boolean printFlg = false;
        public Boolean PrintFlg
        {
            get
            {
                return printFlg;
            }
            set
            {
                printFlg = value;
            }
        }

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

            this.btnF01.Text = STR_FUNC_F1;
            this.btnF03.Text = STR_FUNC_F3;
            this.btnF04.Text = STR_FUNC_F4;
            this.btnF08.Text = STR_FUNC_F8_RIREKI;
            this.btnF09.Text = STR_FUNC_F9;
            this.btnF12.Text = STR_FUNC_F12;

            SetUpGrid();
            gridMitsmori.DataSource = dt;
            dt.Rows.InsertAt(dt.NewRow(), 0);
        }

        private void Form7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
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

                for (int i = 0; i < gridMitsmori.RowCount; i++)
                {
                    if (gridMitsmori[85, i].Value == null || ((gridMitsmori[85, i].Value).ToString()).Equals(""))
                    {
                        if (gridMitsmori[2, i].Value != null && !((gridMitsmori[2, i].Value).ToString()).Equals("")
                             && gridMitsmori[3, i].Value != null && !((gridMitsmori[3, i].Value).ToString()).Equals(""))
                        {
                            UserControl2 uc = new UserControl2();
                            uc.Name = "uc" + i.ToString();
                            if (gridMitsmori[2, i].Value != null)
                            {
                                uc.textBox30.Text = (gridMitsmori[2, i].Value).ToString();
                            }
                            else
                            {
                                uc.textBox30.Text = "";
                            }
                            f.tableLayoutPanel1.Controls.Add(uc);
                        }
                    }
                }

                f.FrmParent = this;
                f.ShowDialog();
                f.Dispose();

                if (printFlg)
                {
                    //PrintDialog pf = new PrintDialog();
                    //pf.StartPosition = FormStartPosition.CenterScreen;
                    //pf.Location = s.Bounds.Location;
                    //pf.ShowDialog();
                    //pf.Dispose();
                    //PrintFlg = false;
                }
            }
            else if (e.KeyData == Keys.F6)
            {
                delRow();
            }
            else if (e.KeyData == Keys.F7)
            {
                addRow();
            }
            else if (e.KeyData == Keys.F9)
            {
                getMitsumoriInfo();
            }
            else if (e.KeyData == Keys.F12)
            {
                this.Close();
            }
        }

        private void btnFKeys_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 一覧表示
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    break;
                case STR_BTN_F03: // 削除
                    logger.Info(LogUtil.getMessage(this._Title, "削除実行"));
                    break;
                case STR_BTN_F04: // 取り消し
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    break;
                case STR_BTN_F06: // 行削除
                    logger.Info(LogUtil.getMessage(this._Title, "行削除実行"));
                    delRow();
                    break;
                case STR_BTN_F07: // 行挿入
                    logger.Info(LogUtil.getMessage(this._Title, "行挿入実行"));
                    addRow();
                    break;
                case STR_BTN_F09: // 検索
                    logger.Info(LogUtil.getMessage(this._Title, "検索実行"));
                    getMitsumoriInfo();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    //this.PrintReport();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

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
            DataGridViewTextBoxColumn txtRowNum = new DataGridViewTextBoxColumn(); // 0
            txtRowNum.DataPropertyName = "行番号";
            txtRowNum.Name = "行番号";
            txtRowNum.HeaderText = "No.";
            txtRowNum.ReadOnly = true;

            DataGridViewCheckBoxColumn cbRow = new DataGridViewCheckBoxColumn(); // 1
            cbRow.DataPropertyName = "印";
            cbRow.Name = "印";
            cbRow.HeaderText = "印";

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

            DataGridViewTextBoxColumn kingaku = new DataGridViewTextBoxColumn(); // 7
            kingaku.DataPropertyName = "金額";
            kingaku.Name = "金額";
            kingaku.HeaderText = "金額";

            DataGridViewTextBoxColumn shiireTanka = new DataGridViewTextBoxColumn(); // 8
            shiireTanka.DataPropertyName = "仕入単価";
            shiireTanka.Name = "仕入単価";
            shiireTanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn arari = new DataGridViewTextBoxColumn(); // 9
            arari.DataPropertyName = "粗利金額";
            arari.Name = "粗利金額";
            arari.HeaderText = "粗利";

            DataGridViewTextBoxColumn arariritsu = new DataGridViewTextBoxColumn(); // 10
            arariritsu.DataPropertyName = "率";
            arariritsu.Name = "率";
            arariritsu.HeaderText = "粗利率";

            DataGridViewTextBoxColumn biko = new DataGridViewTextBoxColumn(); // 11
            biko.DataPropertyName = "備考";
            biko.Name = "備考";
            biko.HeaderText = "備考";

            DataGridViewTextBoxColumn shiiresaki = new DataGridViewTextBoxColumn(); // 12
            shiiresaki.DataPropertyName = "仕入先名";
            shiiresaki.Name = "仕入先名";
            shiiresaki.HeaderText = "仕入先";

            DataGridViewTextBoxColumn insatsu = new DataGridViewTextBoxColumn(); // 13
            insatsu.DataPropertyName = "印刷フラグ";
            insatsu.Name = "印刷フラグ";
            insatsu.HeaderText = "印刷";

            #region
            DataGridViewTextBoxColumn shiireCd1 = new DataGridViewTextBoxColumn(); // 14
            shiireCd1.DataPropertyName = "仕入先コード１";
            shiireCd1.Name = "仕入先コード１";
            shiireCd1.HeaderText = "仕入先コード１";

            DataGridViewTextBoxColumn shiireName1 = new DataGridViewTextBoxColumn(); // 15
            shiireName1.DataPropertyName = "仕入先名１";
            shiireName1.Name = "仕入先名１";
            shiireName1.HeaderText = "仕入先名１";

            DataGridViewTextBoxColumn shiireTanka1 = new DataGridViewTextBoxColumn(); // 16
            shiireTanka1.DataPropertyName = "仕入単価１";
            shiireTanka1.Name = "仕入単価１";
            shiireTanka1.HeaderText = "仕入単価１";

            DataGridViewTextBoxColumn shiireKin1 = new DataGridViewTextBoxColumn(); // 17
            shiireKin1.DataPropertyName = "仕入金額１";
            shiireKin1.Name = "仕入金額１";
            shiireKin1.HeaderText = "仕入金額１";

            DataGridViewTextBoxColumn arari1 = new DataGridViewTextBoxColumn(); // 18
            arari1.DataPropertyName = "粗利１";
            arari1.Name = "粗利１";
            arari1.HeaderText = "粗利１";

            DataGridViewTextBoxColumn arariritsu1 = new DataGridViewTextBoxColumn(); // 19
            arariritsu1.DataPropertyName = "粗利率１";
            arariritsu1.Name = "粗利率１";
            arariritsu1.HeaderText = "粗利率１";

            DataGridViewTextBoxColumn shiireCd2 = new DataGridViewTextBoxColumn(); // 20
            shiireCd2.DataPropertyName = "仕入先コード２";
            shiireCd2.Name = "仕入先コード２";
            shiireCd2.HeaderText = "仕入先コード２";

            DataGridViewTextBoxColumn shiireName2 = new DataGridViewTextBoxColumn(); // 21
            shiireName2.DataPropertyName = "仕入先名２";
            shiireName2.Name = "仕入先名２";
            shiireName2.HeaderText = "仕入先名２";

            DataGridViewTextBoxColumn shiireTanka2 = new DataGridViewTextBoxColumn(); // 22
            shiireTanka2.DataPropertyName = "仕入単価２";
            shiireTanka2.Name = "仕入単価２";
            shiireTanka2.HeaderText = "仕入単価２";

            DataGridViewTextBoxColumn shiireKin2 = new DataGridViewTextBoxColumn(); // 23
            shiireKin2.DataPropertyName = "仕入金額２";
            shiireKin2.Name = "仕入金額２";
            shiireKin2.HeaderText = "仕入金額２";

            DataGridViewTextBoxColumn arari2 = new DataGridViewTextBoxColumn(); // 24
            arari2.DataPropertyName = "粗利２";
            arari2.Name = "粗利２";
            arari2.HeaderText = "粗利２";

            DataGridViewTextBoxColumn arariritsu2 = new DataGridViewTextBoxColumn(); // 25
            arariritsu2.DataPropertyName = "粗利率２";
            arariritsu2.Name = "粗利率２";
            arariritsu2.HeaderText = "粗利率２";

            DataGridViewTextBoxColumn shiireCd3 = new DataGridViewTextBoxColumn(); // 26
            shiireCd3.DataPropertyName = "仕入先コード３";
            shiireCd3.Name = "仕入先コード３";
            shiireCd3.HeaderText = "仕入先コード３";

            DataGridViewTextBoxColumn shiireName3 = new DataGridViewTextBoxColumn(); // 27
            shiireName3.DataPropertyName = "仕入先名３";
            shiireName3.Name = "仕入先名３";
            shiireName3.HeaderText = "仕入先名３";

            DataGridViewTextBoxColumn shiireTanka3 = new DataGridViewTextBoxColumn(); // 28
            shiireTanka3.DataPropertyName = "仕入単価３";
            shiireTanka3.Name = "仕入単価３";
            shiireTanka3.HeaderText = "仕入単価３";

            DataGridViewTextBoxColumn shiireKin3 = new DataGridViewTextBoxColumn(); // 29
            shiireKin3.DataPropertyName = "仕入金額３";
            shiireKin3.Name = "仕入金額３";
            shiireKin3.HeaderText = "仕入金額３";

            DataGridViewTextBoxColumn arari3 = new DataGridViewTextBoxColumn(); // 30
            arari3.DataPropertyName = "粗利３";
            arari3.Name = "粗利３";
            arari3.HeaderText = "粗利３";

            DataGridViewTextBoxColumn arariritsu3 = new DataGridViewTextBoxColumn(); // 31
            arariritsu3.DataPropertyName = "粗利率３";
            arariritsu3.Name = "粗利率３";
            arariritsu3.HeaderText = "粗利率３";
            #endregion

            #region
            DataGridViewTextBoxColumn shiireCd4 = new DataGridViewTextBoxColumn(); // 32
            shiireCd4.DataPropertyName = "仕入先コード４";
            shiireCd4.Name = "仕入先コード４";
            shiireCd4.HeaderText = "仕入先コード４";
            shiireCd4.Visible = false;

            DataGridViewTextBoxColumn shiireName4 = new DataGridViewTextBoxColumn(); // 33
            shiireName4.DataPropertyName = "仕入先名４";
            shiireName4.Name = "仕入先名４";
            shiireName4.HeaderText = "仕入先名４";
            shiireName4.Visible = false;

            DataGridViewTextBoxColumn shiireTanka4 = new DataGridViewTextBoxColumn(); // 34
            shiireTanka4.DataPropertyName = "仕入単価４";
            shiireTanka4.Name = "仕入単価４";
            shiireTanka4.HeaderText = "仕入単価４";
            shiireTanka4.Visible = false;

            DataGridViewTextBoxColumn shiireKin4 = new DataGridViewTextBoxColumn(); // 35
            shiireKin4.DataPropertyName = "仕入金額４";
            shiireKin4.Name = "仕入金額４";
            shiireKin4.HeaderText = "仕入金額４";
            shiireKin4.Visible = false;

            DataGridViewTextBoxColumn arari4 = new DataGridViewTextBoxColumn(); // 36
            arari4.DataPropertyName = "粗利４";
            arari4.Name = "粗利４";
            arari4.HeaderText = "粗利４";
            arari4.Visible = false;

            DataGridViewTextBoxColumn arariritsu4 = new DataGridViewTextBoxColumn(); // 37
            arariritsu4.DataPropertyName = "粗利率４";
            arariritsu4.Name = "粗利率４";
            arariritsu4.HeaderText = "粗利率４";
            arariritsu4.Visible = false;

            DataGridViewTextBoxColumn shiireCd5 = new DataGridViewTextBoxColumn(); // 38
            shiireCd5.DataPropertyName = "仕入先コード５";
            shiireCd5.Name = "仕入先コード５";
            shiireCd5.HeaderText = "仕入先コード５";
            shiireCd5.Visible = false;

            DataGridViewTextBoxColumn shiireName5 = new DataGridViewTextBoxColumn(); // 39
            shiireName5.DataPropertyName = "仕入先名５";
            shiireName5.Name = "仕入先名５";
            shiireName5.HeaderText = "仕入先名５";
            shiireName5.Visible = false;

            DataGridViewTextBoxColumn shiireTanka5 = new DataGridViewTextBoxColumn(); // 40
            shiireTanka5.DataPropertyName = "仕入単価５";
            shiireTanka5.Name = "仕入単価５";
            shiireTanka5.HeaderText = "仕入単価５";
            shiireTanka5.Visible = false;

            DataGridViewTextBoxColumn shiireKin5 = new DataGridViewTextBoxColumn(); // 41
            shiireKin5.DataPropertyName = "仕入金額５";
            shiireKin5.Name = "仕入金額５";
            shiireKin5.HeaderText = "仕入金額５";
            shiireKin5.Visible = false;

            DataGridViewTextBoxColumn arari5 = new DataGridViewTextBoxColumn(); // 42
            arari5.DataPropertyName = "粗利５";
            arari5.Name = "粗利５";
            arari5.HeaderText = "粗利５";
            arari5.Visible = false;

            DataGridViewTextBoxColumn arariritsu5 = new DataGridViewTextBoxColumn(); // 43
            arariritsu5.DataPropertyName = "粗利率５";
            arariritsu5.Name = "粗利率５";
            arariritsu5.HeaderText = "粗利率５";
            arariritsu5.Visible = false;

            DataGridViewTextBoxColumn shiireCd6 = new DataGridViewTextBoxColumn(); // 44
            shiireCd6.DataPropertyName = "仕入先コード６";
            shiireCd6.Name = "仕入先コード６";
            shiireCd6.HeaderText = "仕入先コード６";
            shiireCd6.Visible = false;

            DataGridViewTextBoxColumn shiireName6 = new DataGridViewTextBoxColumn(); // 45
            shiireName6.DataPropertyName = "仕入先名６";
            shiireName6.Name = "仕入先名６";
            shiireName6.HeaderText = "仕入先名６";
            shiireName6.Visible = false;

            DataGridViewTextBoxColumn shiireTanka6 = new DataGridViewTextBoxColumn(); // 46
            shiireTanka6.DataPropertyName = "仕入単価６";
            shiireTanka6.Name = "仕入単価６";
            shiireTanka6.HeaderText = "仕入単価６";
            shiireTanka6.Visible = false;

            DataGridViewTextBoxColumn shiireKin6 = new DataGridViewTextBoxColumn(); // 47
            shiireKin6.DataPropertyName = "仕入金額６";
            shiireKin6.Name = "仕入金額６";
            shiireKin6.HeaderText = "仕入金額６";
            shiireKin6.Visible = false;

            DataGridViewTextBoxColumn arari6 = new DataGridViewTextBoxColumn(); // 48
            arari6.DataPropertyName = "粗利６";
            arari6.Name = "粗利６";
            arari6.HeaderText = "粗利６";
            arari6.Visible = false;

            DataGridViewTextBoxColumn arariritsu6 = new DataGridViewTextBoxColumn(); // 49
            arariritsu6.DataPropertyName = "粗利率６";
            arariritsu6.Name = "粗利率６";
            arariritsu6.HeaderText = "粗利率６";
            arariritsu6.Visible = false;
            #endregion

            #region
            DataGridViewTextBoxColumn kakoShiireCd1 = new DataGridViewTextBoxColumn(); // 50
            kakoShiireCd1.DataPropertyName = "加工仕入先コード１";
            kakoShiireCd1.Name = "加工仕入先コード１";
            kakoShiireCd1.HeaderText = "加工仕入先コード１";
            kakoShiireCd1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName1 = new DataGridViewTextBoxColumn(); // 51
            kakoShiireName1.DataPropertyName = "加工仕入先名１";
            kakoShiireName1.Name = "加工仕入先名１";
            kakoShiireName1.HeaderText = "加工仕入先名１";
            kakoShiireName1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka1 = new DataGridViewTextBoxColumn(); // 52
            kakoShiireTanka1.DataPropertyName = "加工仕入単価１";
            kakoShiireTanka1.Name = "加工仕入単価１";
            kakoShiireTanka1.HeaderText = "加工仕入単価１";
            kakoShiireTanka1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin1 = new DataGridViewTextBoxColumn(); // 53
            kakoShiireKin1.DataPropertyName = "加工仕入金額１";
            kakoShiireKin1.Name = "加工仕入金額１";
            kakoShiireKin1.HeaderText = "加工仕入金額１";
            kakoShiireKin1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari1 = new DataGridViewTextBoxColumn(); // 54
            kakoShiireArari1.DataPropertyName = "加工粗利１";
            kakoShiireArari1.Name = "加工粗利１";
            kakoShiireArari1.HeaderText = "加工粗利１";
            kakoShiireArari1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu1 = new DataGridViewTextBoxColumn(); // 55
            kakoShiireArariritsu1.DataPropertyName = "加工粗利率１";
            kakoShiireArariritsu1.Name = "加工粗利率１";
            kakoShiireArariritsu1.HeaderText = "加工粗利率１";
            kakoShiireArariritsu1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireCd2 = new DataGridViewTextBoxColumn(); // 56
            kakoShiireCd2.DataPropertyName = "加工仕入先コード２";
            kakoShiireCd2.Name = "加工仕入先コード２";
            kakoShiireCd2.HeaderText = "加工仕入先コード２";
            kakoShiireCd2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName2 = new DataGridViewTextBoxColumn(); // 57
            kakoShiireName2.DataPropertyName = "加工仕入先名２";
            kakoShiireName2.Name = "加工仕入先名２";
            kakoShiireName2.HeaderText = "加工仕入先名２";
            kakoShiireName2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka2 = new DataGridViewTextBoxColumn(); // 58
            kakoShiireTanka2.DataPropertyName = "加工仕入単価２";
            kakoShiireTanka2.Name = "加工仕入単価２";
            kakoShiireTanka2.HeaderText = "加工仕入単価２";
            kakoShiireTanka2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin2 = new DataGridViewTextBoxColumn(); // 59
            kakoShiireKin2.DataPropertyName = "加工仕入金額２";
            kakoShiireKin2.Name = "加工仕入金額２";
            kakoShiireKin2.HeaderText = "加工仕入金額２";
            kakoShiireKin2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari2 = new DataGridViewTextBoxColumn(); // 60
            kakoShiireArari2.DataPropertyName = "加工粗利２";
            kakoShiireArari2.Name = "加工粗利２";
            kakoShiireArari2.HeaderText = "加工粗利２";
            kakoShiireArari2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu2 = new DataGridViewTextBoxColumn(); // 61
            kakoShiireArariritsu2.DataPropertyName = "加工粗利率２";
            kakoShiireArariritsu2.Name = "加工粗利率２";
            kakoShiireArariritsu2.HeaderText = "加工粗利率２";
            kakoShiireArariritsu2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireCd3 = new DataGridViewTextBoxColumn(); // 62
            kakoShiireCd3.DataPropertyName = "加工仕入先コード３";
            kakoShiireCd3.Name = "加工仕入先コード３";
            kakoShiireCd3.HeaderText = "加工仕入先コード３";
            kakoShiireCd3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName3 = new DataGridViewTextBoxColumn(); // 63
            kakoShiireName3.DataPropertyName = "加工仕入先名３";
            kakoShiireName3.Name = "加工仕入先名３";
            kakoShiireName3.HeaderText = "加工仕入先名３";
            kakoShiireName3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka3 = new DataGridViewTextBoxColumn(); // 64
            kakoShiireTanka3.DataPropertyName = "加工仕入単価３";
            kakoShiireTanka3.Name = "加工仕入単価３";
            kakoShiireTanka3.HeaderText = "加工仕入単価３";
            kakoShiireTanka3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin3 = new DataGridViewTextBoxColumn(); // 65
            kakoShiireKin3.DataPropertyName = "加工仕入金額３";
            kakoShiireKin3.Name = "加工仕入金額３";
            kakoShiireKin3.HeaderText = "加工仕入金額３";
            kakoShiireKin3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari3 = new DataGridViewTextBoxColumn(); // 66
            kakoShiireArari3.DataPropertyName = "加工粗利３";
            kakoShiireArari3.Name = "加工粗利３";
            kakoShiireArari3.HeaderText = "加工粗利３";
            kakoShiireArari3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu3 = new DataGridViewTextBoxColumn(); //67 
            kakoShiireArariritsu3.DataPropertyName = "加工粗利率３";
            kakoShiireArariritsu3.Name = "加工粗利率３";
            kakoShiireArariritsu3.HeaderText = "加工粗利率３";
            kakoShiireArariritsu3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireCd4 = new DataGridViewTextBoxColumn(); // 68
            kakoShiireCd4.DataPropertyName = "加工仕入先コード４";
            kakoShiireCd4.Name = "加工仕入先コード４";
            kakoShiireCd4.HeaderText = "加工仕入先コード４";
            kakoShiireCd4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName4 = new DataGridViewTextBoxColumn(); // 69
            kakoShiireName4.DataPropertyName = "加工仕入先名４";
            kakoShiireName4.Name = "加工仕入先名４";
            kakoShiireName4.HeaderText = "加工仕入先名４";
            kakoShiireName4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka4 = new DataGridViewTextBoxColumn(); // 70
            kakoShiireTanka4.DataPropertyName = "加工仕入単価４";
            kakoShiireTanka4.Name = "加工仕入単価４";
            kakoShiireTanka4.HeaderText = "加工仕入単価４";
            kakoShiireTanka4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin4 = new DataGridViewTextBoxColumn(); // 71
            kakoShiireKin4.DataPropertyName = "加工仕入金額４";
            kakoShiireKin4.Name = "加工仕入金額４";
            kakoShiireKin4.HeaderText = "加工仕入金額４";
            kakoShiireKin4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari4 = new DataGridViewTextBoxColumn(); // 72
            kakoShiireArari4.DataPropertyName = "加工粗利４";
            kakoShiireArari4.Name = "加工粗利４";
            kakoShiireArari4.HeaderText = "加工粗利４";
            kakoShiireArari4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu4 = new DataGridViewTextBoxColumn(); // 73
            kakoShiireArariritsu4.DataPropertyName = "加工粗利率４";
            kakoShiireArariritsu4.Name = "加工粗利率４";
            kakoShiireArariritsu4.HeaderText = "加工粗利率４";
            kakoShiireArariritsu4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireCd5 = new DataGridViewTextBoxColumn(); // 74
            kakoShiireCd5.DataPropertyName = "加工仕入先コード５";
            kakoShiireCd5.Name = "加工仕入先コード５";
            kakoShiireCd5.HeaderText = "加工仕入先コード５";
            kakoShiireCd5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName5 = new DataGridViewTextBoxColumn(); // 75
            kakoShiireName5.DataPropertyName = "加工仕入先名５";
            kakoShiireName5.Name = "加工仕入先名５";
            kakoShiireName5.HeaderText = "加工仕入先名５";
            kakoShiireName5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka5 = new DataGridViewTextBoxColumn(); // 76
            kakoShiireTanka5.DataPropertyName = "加工仕入単価５";
            kakoShiireTanka5.Name = "加工仕入単価５";
            kakoShiireTanka5.HeaderText = "加工仕入単価５";
            kakoShiireTanka5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin5 = new DataGridViewTextBoxColumn(); // 77
            kakoShiireKin5.DataPropertyName = "加工仕入金額５";
            kakoShiireKin5.Name = "加工仕入金額５";
            kakoShiireKin5.HeaderText = "加工仕入金額５";
            kakoShiireKin5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari5 = new DataGridViewTextBoxColumn(); // 78
            kakoShiireArari5.DataPropertyName = "加工粗利５";
            kakoShiireArari5.Name = "加工粗利５";
            kakoShiireArari5.HeaderText = "加工粗利５";
            kakoShiireArari5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu5 = new DataGridViewTextBoxColumn(); // 79
            kakoShiireArariritsu5.DataPropertyName = "加工粗利率５";
            kakoShiireArariritsu5.Name = "加工粗利率５";
            kakoShiireArariritsu5.HeaderText = "加工粗利率５";
            kakoShiireArariritsu5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireCd6 = new DataGridViewTextBoxColumn(); // 80
            kakoShiireCd6.DataPropertyName = "加工仕入先コード６";
            kakoShiireCd6.Name = "加工仕入先コード６";
            kakoShiireCd6.HeaderText = "加工仕入先コード６";
            kakoShiireCd6.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName6 = new DataGridViewTextBoxColumn(); // 81
            kakoShiireName6.DataPropertyName = "加工仕入先名６";
            kakoShiireName6.Name = "加工仕入先名６";
            kakoShiireName6.HeaderText = "加工仕入先名６";
            kakoShiireName6.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka6 = new DataGridViewTextBoxColumn(); // 82
            kakoShiireTanka6.DataPropertyName = "加工仕入単価６";
            kakoShiireTanka6.Name = "加工仕入単価６";
            kakoShiireTanka6.HeaderText = "加工仕入単価６";
            kakoShiireTanka6.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin6 = new DataGridViewTextBoxColumn(); // 83
            kakoShiireKin6.DataPropertyName = "加工仕入金額６";
            kakoShiireKin6.Name = "加工仕入金額６";
            kakoShiireKin6.HeaderText = "加工仕入金額６";
            kakoShiireKin6.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari6 = new DataGridViewTextBoxColumn(); // 84
            kakoShiireArari6.DataPropertyName = "加工粗利６";
            kakoShiireArari6.Name = "加工粗利６";
            kakoShiireArari6.HeaderText = "加工粗利６";
            kakoShiireArari6.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu6 = new DataGridViewTextBoxColumn(); // 85
            kakoShiireArariritsu6.DataPropertyName = "加工粗利率６";
            kakoShiireArariritsu6.Name = "加工粗利率６";
            kakoShiireArariritsu6.HeaderText = "加工粗利率６";
            kakoShiireArariritsu6.Visible = false;
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

            DataGridViewTextBoxColumn teika2 = new DataGridViewTextBoxColumn(); // 91
            teika2.DataPropertyName = "定価2";
            teika2.Name = "定価2";
            teika2.HeaderText = "定価2";
            teika2.ReadOnly = true;

            DataGridViewTextBoxColumn teika3 = new DataGridViewTextBoxColumn(); // 92
            teika3.DataPropertyName = "定価3";
            teika3.Name = "定価3";
            teika3.HeaderText = "定価3";
            teika3.ReadOnly = true;

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
            #endregion


            #endregion

            //バインド、個々の幅、文章の寄せの設定
            #region
            setColumn(gridMitsmori, txtRowNum, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 36);
            gridMitsmori.Columns.Add(cbRow);
            setColumn(gridMitsmori, hinmei, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 330);
            setColumn(gridMitsmori, suryo, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 80);
            setColumn(gridMitsmori, teika, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0", 97);
            setColumn(gridMitsmori, mitsumoriTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 120);
            setColumn(gridMitsmori, kakeritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 50);
            setColumn(gridMitsmori, kingaku, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 97);
            setColumn(gridMitsmori, shiireTanka, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 120);
            setColumn(gridMitsmori, arari, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 97);
            setColumn(gridMitsmori, arariritsu, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 50);
            setColumn(gridMitsmori, biko, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, shiiresaki, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, insatsu, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, 20);
            setColumn(gridMitsmori, shiireCd1, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 40);
            setColumn(gridMitsmori, shiireName1, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, shiireTanka1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 120);
            setColumn(gridMitsmori, shiireKin1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 97);
            setColumn(gridMitsmori, arari1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 97);
            setColumn(gridMitsmori, arariritsu1, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 50);
            setColumn(gridMitsmori, shiireCd2, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 40);
            setColumn(gridMitsmori, shiireName2, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, shiireTanka2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 120);
            setColumn(gridMitsmori, shiireKin2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 97);
            setColumn(gridMitsmori, arari2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 97);
            setColumn(gridMitsmori, arariritsu2, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 50);
            setColumn(gridMitsmori, shiireCd3, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 40);
            setColumn(gridMitsmori, shiireName3, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, 200);
            setColumn(gridMitsmori, shiireTanka3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 120);
            setColumn(gridMitsmori, shiireKin3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 97);
            setColumn(gridMitsmori, arari3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 97);
            setColumn(gridMitsmori, arariritsu3, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, "#,0.##", 50);
            setColumn(gridMitsmori, shiireCd4);
            setColumn(gridMitsmori, shiireName4);
            setColumn(gridMitsmori, shiireTanka4);
            setColumn(gridMitsmori, shiireKin4);
            setColumn(gridMitsmori, arari4);
            setColumn(gridMitsmori, arariritsu4);
            setColumn(gridMitsmori, shiireCd5);
            setColumn(gridMitsmori, shiireName5);
            setColumn(gridMitsmori, shiireTanka5);
            setColumn(gridMitsmori, shiireKin5);
            setColumn(gridMitsmori, arari5);
            setColumn(gridMitsmori, arariritsu5);
            setColumn(gridMitsmori, shiireCd6);
            setColumn(gridMitsmori, shiireName6);
            setColumn(gridMitsmori, shiireTanka6);
            setColumn(gridMitsmori, shiireKin6);
            setColumn(gridMitsmori, arari6);
            setColumn(gridMitsmori, arariritsu6);
            setColumn(gridMitsmori, kakoShiireCd1);
            setColumn(gridMitsmori, kakoShiireName1);
            setColumn(gridMitsmori, kakoShiireTanka1);
            setColumn(gridMitsmori, kakoShiireKin1);
            setColumn(gridMitsmori, kakoShiireArari1);
            setColumn(gridMitsmori, kakoShiireArariritsu1);
            setColumn(gridMitsmori, kakoShiireCd2);
            setColumn(gridMitsmori, kakoShiireName2);
            setColumn(gridMitsmori, kakoShiireTanka2);
            setColumn(gridMitsmori, kakoShiireKin2);
            setColumn(gridMitsmori, kakoShiireArari2);
            setColumn(gridMitsmori, kakoShiireArariritsu2);
            setColumn(gridMitsmori, kakoShiireCd3);
            setColumn(gridMitsmori, kakoShiireName3);
            setColumn(gridMitsmori, kakoShiireTanka3);
            setColumn(gridMitsmori, kakoShiireKin3);
            setColumn(gridMitsmori, kakoShiireArari3);
            setColumn(gridMitsmori, kakoShiireArariritsu3);
            setColumn(gridMitsmori, kakoShiireCd4);
            setColumn(gridMitsmori, kakoShiireName4);
            setColumn(gridMitsmori, kakoShiireTanka4);
            setColumn(gridMitsmori, kakoShiireKin4);
            setColumn(gridMitsmori, kakoShiireArari4);
            setColumn(gridMitsmori, kakoShiireArariritsu4);
            setColumn(gridMitsmori, kakoShiireCd5);
            setColumn(gridMitsmori, kakoShiireName5);
            setColumn(gridMitsmori, kakoShiireTanka5);
            setColumn(gridMitsmori, kakoShiireKin5);
            setColumn(gridMitsmori, kakoShiireArari5);
            setColumn(gridMitsmori, kakoShiireArariritsu5);
            setColumn(gridMitsmori, kakoShiireCd6);
            setColumn(gridMitsmori, kakoShiireName6);
            setColumn(gridMitsmori, kakoShiireTanka6);
            setColumn(gridMitsmori, kakoShiireKin6);
            setColumn(gridMitsmori, kakoShiireArari6);
            setColumn(gridMitsmori, kakoShiireArariritsu6);
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

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            setText(e.RowIndex);
        }

        private void setText(int idx)
        {
            int rowIdx = idx;
            txtIdx.Text = rowIdx.ToString();

            if (cellValueChecker(14, rowIdx)) {
                txtZaiCd1.Text = gridMitsmori[14, rowIdx].Value.ToString();
            } else
            {
                txtZaiCd1.Text = "";
            }

            if (cellValueChecker(15, rowIdx))
            {
                txtZaiMei1.Text = gridMitsmori[15, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiMei1.Text = "";
            }

            if (cellValueChecker(16, rowIdx))
            {
                txtZaiTnk1.Text = gridMitsmori[16, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTnk1.Text = "";
            }

            //
            if (cellValueChecker(20, rowIdx))
            {
                txtZaiCd2.Text = gridMitsmori[20, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiCd2.Text = "";
            }

            if (cellValueChecker(21, rowIdx))
            {
                txtZaiMei2.Text = gridMitsmori[21, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiMei2.Text = "";
            }

            if (cellValueChecker(22, rowIdx))
            {
                txtZaiTnk2.Text = gridMitsmori[22, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTnk2.Text = "";
            }

            //
            if (cellValueChecker(26, rowIdx))
            {
                txtZaiCd3.Text = gridMitsmori[26, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiCd3.Text = "";
            }

            if (cellValueChecker(27, rowIdx))
            {
                txtZaiMei3.Text = gridMitsmori[27, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiMei3.Text = "";
            }

            if (cellValueChecker(28, rowIdx))
            {
                txtZaiTnk3.Text = gridMitsmori[28, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTnk3.Text = "";
            }

            //
            if (cellValueChecker(32, rowIdx))
            {
                txtZaiCd4.Text = gridMitsmori[32, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiCd4.Text = "";
            }

            if (cellValueChecker(33, rowIdx))
            {
                txtZaiMei4.Text = gridMitsmori[33, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiMei4.Text = "";
            }

            if (cellValueChecker(34, rowIdx))
            {
                txtZaiTnk4.Text = gridMitsmori[34, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTnk4.Text = "";
            }

            //
            if (cellValueChecker(38, rowIdx))
            {
                txtZaiCd5.Text = gridMitsmori[38, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiCd5.Text = "";
            }

            if (cellValueChecker(39, rowIdx))
            {
                txtZaiMei5.Text = gridMitsmori[39, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiMei5.Text = "";
            }

            if (cellValueChecker(40, rowIdx))
            {
                txtZaiTnk5.Text = gridMitsmori[40, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTnk5.Text = "";
            }

            //
            if (cellValueChecker(44, rowIdx))
            {
                txtZaiCd6.Text = gridMitsmori[44, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiCd6.Text = "";
            }

            if (cellValueChecker(45, rowIdx))
            {
                txtZaiMei6.Text = gridMitsmori[45, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiMei6.Text = "";
            }

            if (cellValueChecker(46, rowIdx))
            {
                txtZaiTnk6.Text = gridMitsmori[46, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTnk6.Text = "";
            }

            //
            if (cellValueChecker(50, rowIdx))
            {
                txtKakCd1.Text = gridMitsmori[50, rowIdx].Value.ToString();
            }
            else
            {
                txtKakCd1.Text = "";
            }

            if (cellValueChecker(51, rowIdx))
            {
                txtKakMei1.Text = gridMitsmori[51, rowIdx].Value.ToString();
            }
            else
            {
                txtKakMei1.Text = "";
            }

            if (cellValueChecker(52, rowIdx))
            {
                txtKakTnk1.Text = gridMitsmori[52, rowIdx].Value.ToString();
            }
            else
            {
                txtKakTnk1.Text = "";
            }

            calc1(rowIdx);

            //
            if (cellValueChecker(56, rowIdx))
            {
                txtKakCd2.Text = gridMitsmori[56, rowIdx].Value.ToString();
            }
            else
            {
                txtKakCd2.Text = "";
            }

            if (cellValueChecker(57, rowIdx))
            {
                txtKakMei2.Text = gridMitsmori[57, rowIdx].Value.ToString();
            }
            else
            {
                txtKakMei2.Text = "";
            }

            if (cellValueChecker(58, rowIdx))
            {
                txtKakTnk2.Text = gridMitsmori[58, rowIdx].Value.ToString();
            }
            else
            {
                txtKakTnk2.Text = "";
            }

            calc2(rowIdx);

            //
            if (cellValueChecker(62, rowIdx))
            {
                txtKakCd3.Text = gridMitsmori[62, rowIdx].Value.ToString();
            }
            else
            {
                txtKakCd3.Text = "";
            }

            if (cellValueChecker(63, rowIdx))
            {
                txtKakMei3.Text = gridMitsmori[63, rowIdx].Value.ToString();
            }
            else
            {
                txtKakMei3.Text = "";
            }

            if (cellValueChecker(64, rowIdx))
            {
                txtKakTnk3.Text = gridMitsmori[64, rowIdx].Value.ToString();
            }
            else
            {
                txtKakTnk3.Text = "";
            }

            calc3(rowIdx);

            if (cellValueChecker(90, rowIdx))
            {
                txtZaiTeika1.Text = gridMitsmori[90, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTeika1.Text = "";
            }
            if (cellValueChecker(91, rowIdx))
            {
                txtZaiTeika2.Text = gridMitsmori[91, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTeika2.Text = "";
            }
            if (cellValueChecker(92, rowIdx))
            {
                txtZaiTeika3.Text = gridMitsmori[92, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTeika3.Text = "";
            }

            if (cellValueChecker(12, rowIdx))
            {
                if (gridMitsmori[12, rowIdx].Value.ToString().Equals(txtZaiMei1.Text))
                {
                    setRowBGColor1(Color.FromArgb(0x66, 0xFF, 0x66));
                    setRowBGColor2(Color.White);
                    setRowBGColor3(Color.White);
                    setRowBGColor4(Color.White);
                    setRowBGColor5(Color.White);
                    setRowBGColor6(Color.White);
                }
                else if (gridMitsmori[12, rowIdx].Value.ToString().Equals(txtZaiMei2.Text))
                {
                    setRowBGColor1(Color.White);
                    setRowBGColor2(Color.FromArgb(0x66, 0xFF, 0x66));
                    setRowBGColor3(Color.White);
                    setRowBGColor4(Color.White);
                    setRowBGColor5(Color.White);
                    setRowBGColor6(Color.White);
                }
                else if (gridMitsmori[12, rowIdx].Value.ToString().Equals(txtZaiMei3.Text))
                {
                    setRowBGColor1(Color.White);
                    setRowBGColor2(Color.White);
                    setRowBGColor3(Color.FromArgb(0x66, 0xFF, 0x66));
                    setRowBGColor4(Color.White);
                    setRowBGColor5(Color.White);
                    setRowBGColor6(Color.White);
                }
                else if (gridMitsmori[12, rowIdx].Value.ToString().Equals(txtZaiMei4.Text))
                {
                    setRowBGColor1(Color.White);
                    setRowBGColor2(Color.White);
                    setRowBGColor3(Color.White);
                    setRowBGColor4(Color.FromArgb(0x66, 0xFF, 0x66));
                    setRowBGColor5(Color.White);
                    setRowBGColor6(Color.White);
                }
                else if (gridMitsmori[12, rowIdx].Value.ToString().Equals(txtZaiMei5.Text))
                {
                    setRowBGColor1(Color.White);
                    setRowBGColor2(Color.White);
                    setRowBGColor3(Color.White);
                    setRowBGColor4(Color.White);
                    setRowBGColor5(Color.FromArgb(0x66, 0xFF, 0x66));
                    setRowBGColor6(Color.White);
                }
                else if (gridMitsmori[12, rowIdx].Value.ToString().Equals(txtZaiMei6.Text))
                {
                    setRowBGColor1(Color.White);
                    setRowBGColor2(Color.White);
                    setRowBGColor3(Color.White);
                    setRowBGColor4(Color.White);
                    setRowBGColor5(Color.White);
                    setRowBGColor6(Color.FromArgb(0x66, 0xFF, 0x66));
                }
            }
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

        private void dataGridView2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                txtZaiCd1.Focus();
            }
        }

        private void textBox25_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F8)
            {
                setTxtVal2();
            }
        }
        private void setTxtVal2()
        {
            int rowIdx = gridMitsmori.CurrentCell.RowIndex;

            if (isNotNullBlank(txtZaiTeika2.Text) && isNotNullBlank(txtZaiTnk2.Text) && isNotNullBlank(txtArr2.Text) && isNotNullBlank(txtSrrt2.Text) && isNotNullBlank(txtZaiMei2.Text))
            {
                decimal d = decimal.Parse(txtZaiTeika2.Text, System.Globalization.NumberStyles.Number);
                txtZaiTeika2.Text = d.ToString();

                //dataGridView2[6, rowIdx].Value = textBox22.Text;
                gridMitsmori[8, rowIdx].Value = txtZaiTnk2.Text;
                gridMitsmori[9, rowIdx].Value = txtArr2.Text;
                gridMitsmori[10, rowIdx].Value = txtSrrt2.Text;
                gridMitsmori[12, rowIdx].Value = txtZaiMei2.Text;

                gridMitsmori[20, rowIdx].Value = txtZaiCd2.Text;
                gridMitsmori[21, rowIdx].Value = txtZaiMei2.Text;
                if (!string.IsNullOrWhiteSpace(txtZaiTnk2.Text)) {
                    gridMitsmori[22, rowIdx].Value = txtZaiTnk2.Text;
                    if (gridMitsmori[3, rowIdx].Value != null)
                    {
                        gridMitsmori[23, rowIdx].Value = (changeDigit(txtZaiTnk2.Text) * changeDigit(gridMitsmori[3, rowIdx].Value.ToString())).ToString();
                    }
                }
                if (!string.IsNullOrWhiteSpace(txtArr2.Text))
                {
                    gridMitsmori[24, rowIdx].Value = txtArr2.Text;
                }
                if (!string.IsNullOrWhiteSpace(txtSrrt2.Text))
                {
                    gridMitsmori[25, rowIdx].Value = txtSrrt2.Text;
                }

                if (!string.IsNullOrWhiteSpace(txtZaiTeika2.Text))
                {
                    gridMitsmori[91, rowIdx].Value = txtZaiTeika2.Text;
                }

                setKak(rowIdx);
                calc1(rowIdx);
                calc2(rowIdx);
                calc3(rowIdx);

                changeTotal();
            }

            gridMitsmori.Focus();
        }

        private void textBox13_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F8)
            {
                setTxtVal1();
            }
        }

        private void setTxtVal1()
        {
            int rowIdx = gridMitsmori.CurrentCell.RowIndex;

            if (isNotNullBlank(txtZaiTeika1.Text) && isNotNullBlank(txtZaiTnk1.Text) && isNotNullBlank(txtArr1.Text) && isNotNullBlank(txtSrrt1.Text) && isNotNullBlank(txtZaiMei1.Text))
            {
                decimal d = decimal.Parse(txtZaiTeika1.Text, System.Globalization.NumberStyles.Number);
                txtZaiTeika1.Text = d.ToString();

                //dataGridView2[6, rowIdx].Value = textBox17.Text;
                gridMitsmori[8, rowIdx].Value = txtZaiTnk1.Text;
                gridMitsmori[9, rowIdx].Value = txtArr1.Text;
                gridMitsmori[10, rowIdx].Value = txtSrrt1.Text;
                gridMitsmori[12, rowIdx].Value = txtZaiMei1.Text;

                gridMitsmori[14, rowIdx].Value = txtZaiCd1.Text;
                gridMitsmori[15, rowIdx].Value = txtZaiMei1.Text;
                if (!string.IsNullOrWhiteSpace(txtZaiTnk1.Text))
                {
                    gridMitsmori[16, rowIdx].Value = txtZaiTnk1.Text;
                    if (gridMitsmori[3, rowIdx].Value != null)
                    {
                        gridMitsmori[17, rowIdx].Value = (changeDigit(txtZaiTnk1.Text) * changeDigit(gridMitsmori[3, rowIdx].Value.ToString())).ToString();
                    }
                }
                if (!string.IsNullOrWhiteSpace(txtArr1.Text))
                {
                    gridMitsmori[18, rowIdx].Value = txtArr1.Text;
                }
                if (!string.IsNullOrWhiteSpace(txtSrrt1.Text))
                {
                    gridMitsmori[19, rowIdx].Value = txtSrrt1.Text;
                }

                if (!string.IsNullOrWhiteSpace(txtZaiTeika1.Text))
                {
                    gridMitsmori[90, rowIdx].Value = txtZaiTeika1.Text;
                }
                gridMitsmori[4, rowIdx].Value = txtZaiTeika1.Text;

                setKak(rowIdx);
                calc1(rowIdx);
                calc2(rowIdx);
                calc3(rowIdx);

                changeTotal();
            }

            gridMitsmori.Focus();
        }

        private void textBox32_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F8)
            {
                setTxtVal3();
            }
        }

        private void setTxtVal3()
        {
            int rowIdx = gridMitsmori.CurrentCell.RowIndex;

            if (isNotNullBlank(txtZaiTeika3.Text) && isNotNullBlank(txtZaiTnk3.Text) && isNotNullBlank(txtArr3.Text) && isNotNullBlank(txtSrrt3.Text) && isNotNullBlank(txtZaiMei3.Text))
            {
                decimal d = decimal.Parse(txtZaiTeika3.Text, System.Globalization.NumberStyles.Number);
                txtZaiTeika3.Text = d.ToString();

                //dataGridView2[6, rowIdx].Value = textBox29.Text;
                gridMitsmori[8, rowIdx].Value = txtZaiTnk3.Text;
                gridMitsmori[9, rowIdx].Value = txtArr3.Text;
                gridMitsmori[10, rowIdx].Value = txtSrrt3.Text;
                gridMitsmori[12, rowIdx].Value = txtZaiMei3.Text;

                gridMitsmori[26, rowIdx].Value = txtZaiCd3.Text;
                gridMitsmori[27, rowIdx].Value = txtZaiMei3.Text;
                if (!string.IsNullOrWhiteSpace(txtZaiTnk2.Text))
                {
                    gridMitsmori[28, rowIdx].Value = txtZaiTnk3.Text;
                    if (gridMitsmori[3, rowIdx].Value != null)
                    {
                        gridMitsmori[29, rowIdx].Value = (changeDigit(txtZaiTnk3.Text) * changeDigit(gridMitsmori[3, rowIdx].Value.ToString())).ToString();
                    }
                }
                if (!string.IsNullOrWhiteSpace(txtArr3.Text))
                {
                    gridMitsmori[30, rowIdx].Value = txtArr3.Text;
                }
                if (!string.IsNullOrWhiteSpace(txtSrrt3.Text))
                {
                    gridMitsmori[31, rowIdx].Value = txtSrrt3.Text;
                }

                if (!string.IsNullOrWhiteSpace(txtZaiTeika3.Text))
                {
                    gridMitsmori[92, rowIdx].Value = txtZaiTeika3.Text;
                }

                gridMitsmori[4, rowIdx].Value = txtZaiTeika3.Text;

                setKak(rowIdx);
                calc1(rowIdx);
                calc2(rowIdx);
                calc3(rowIdx);

                changeTotal();
            }

            gridMitsmori.Focus();
        }

        private void changeTotal()
        {
            Decimal d = 0;
            Decimal d1 = 0;

            for (int i = 0; i < gridMitsmori.RowCount; i++)
            {
                if (gridMitsmori[8, i].Value != null) {
                    d1 += changeDigit(gridMitsmori[8, i].Value.ToString()) * changeDigit(gridMitsmori[3, i].Value.ToString());
                }
            }
            textBox34.Text = String.Format("{0:#,0}", d1);

            Decimal d2 = 0;
            for (int i = 0; i < gridMitsmori.RowCount; i++)
            {
                if (gridMitsmori[5, i].Value != null)
                {
                    d2 += changeDigit(gridMitsmori[5, i].Value.ToString()) * changeDigit(gridMitsmori[3, i].Value.ToString());
                }
            }
            textBox35.Text = String.Format("{0:#,0}", d2);

            d = d2 - d1;
            textBox36.Text = String.Format("{0:#,0}", d);

            Decimal d3 = 0;
            if (d2 != 0) {
                d3 = Decimal.Round((d / d2) * 100, 2, MidpointRounding.AwayFromZero);
            }
            textBox37.Text = String.Format("{0:#,0}", d3);
        }

        private Boolean isNotNullBlank(String s)
        {
            Boolean ret = false;

            if (s != null)
            {
                if (!s.Equals(""))
                {
                    ret = true;
                }
            }

            return ret;
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            //Form8   frm8   = null;
            //Form8_2 frm8_2 = null;

            if (e.KeyData == Keys.F2)
            {
                
                //if (frm8 == null || frm8.IsDisposed)
                //{
                //    frm8 = null;
                //    frm8 = new Form8();

                //    openChildForm(frm8, false);
                //}
                //else
                //{
                //    MessageBox.Show("見積書検索画面は\r\n既に開かれています。",
                //        "Info",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information);
                //}
            }
            else if (e.KeyData == Keys.F9)
            {
                //if (frm8_2 == null || frm8_2.IsDisposed)
                //{
                //    frm8_2 = null;
                //    frm8_2 = new Form8_2();

                //    openChildForm(frm8_2, false);
                //}
                //else
                //{
                //    MessageBox.Show("見積書検索画面は\r\n既に開かれています。",
                //        "Info",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information);
                //}
            }
        }

        //private void openChildForm(Form f, Boolean flg)
        //{
        //    Screen s = null;
        //    Screen[] argScreen = Screen.AllScreens;
        //    if (argScreen.Length > 1)
        //    {
        //        s = argScreen[1];
        //    }
        //    else
        //    {
        //        s = argScreen[0];
        //    }

        //    f.StartPosition = FormStartPosition.Manual;
        //    f.Location = s.Bounds.Location;

        //    f.ShowDialog();
        //    f.Dispose();
        //}

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

        private void button1_Click(object sender, EventArgs e)
        {
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

            for (int i = 0; i < gridMitsmori.RowCount; i++)
            {
                if (gridMitsmori[85, i].Value == null || ((gridMitsmori[85, i].Value).ToString()).Equals(""))
                {
                    if (gridMitsmori[2, i].Value != null && !((gridMitsmori[2, i].Value).ToString()).Equals("")
                         && gridMitsmori[3, i].Value != null && !((gridMitsmori[3, i].Value).ToString()).Equals("")) {
                        UserControl2 uc = new UserControl2();
                        uc.Name = "uc" + i.ToString();
                        if (gridMitsmori[2, i].Value != null)
                        {
                            uc.textBox30.Text = (gridMitsmori[2, i].Value).ToString();
                        }
                        else
                        {
                            uc.textBox30.Text = "";
                        }
                        f.tableLayoutPanel1.Controls.Add(uc);
                    }
                }
            }

            f.FrmParent = this;
            f.ShowDialog();
            f.Dispose();

            if (printFlg) {
                //PrintDialog pf = new PrintDialog();
                //pf.StartPosition = FormStartPosition.CenterScreen;
                //pf.Location = s.Bounds.Location;
                //pf.ShowDialog();
                //pf.Dispose();
                //PrintFlg = false;
            }
        }

        private void calc1(int rowIdx)
        {
            if (!string.IsNullOrWhiteSpace(txtZaiTnk1.Text))
            {
                gridMitsmori[16, rowIdx].Value = txtZaiTnk1.Text;
            }

            if (cellValueCheckerN(90, rowIdx))
            {
                Decimal d1 = decimal.Parse(gridMitsmori[90, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                Decimal d2 = 0;

                if (isNotNullBlank(txtZaiTnk1.Text))
                {
                    d2 = decimal.Parse(txtZaiTnk1.Text, System.Globalization.NumberStyles.Number);
                }

                if (d1 != 0) {
                    txtZaiRit1.Text = (Decimal.Round(decimal.Divide(d2, d1) * 100, 1)).ToString();
                }

                d2 = 0;
            }

            if (cellValueCheckerN(3, rowIdx))
            {
                decimal d1 = 0;
                decimal d2 = 0;
                decimal d3 = 0;
                decimal d4 = 0;
                decimal dt = 0;
                bool calcFlg = false;
                d4 = Decimal.Parse(gridMitsmori[3, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);

                if (!string.IsNullOrWhiteSpace(txtZaiTnk1.Text))
                {
                    d1 = decimal.Parse(txtZaiTnk1.Text, System.Globalization.NumberStyles.Number);
                    gridMitsmori[17, rowIdx].Value = Decimal.Multiply(d1, d4).ToString();
                    calcFlg = true;
                }
                if (!string.IsNullOrWhiteSpace(txtKakTnk1.Text))
                {
                    d2 = decimal.Parse(txtKakTnk1.Text, System.Globalization.NumberStyles.Number);
                    calcFlg = true;
                }

                if (cellValueCheckerN(5, rowIdx))
                {
                    if (calcFlg) {
                        d3 = Decimal.Parse(gridMitsmori[5, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                        dt = Decimal.Multiply(d3, d4) - (Decimal.Multiply(d1, d4) + Decimal.Multiply(d2, d4));
                        txtArr1.Text = dt.ToString();
                        gridMitsmori[18, rowIdx].Value = txtArr1.Text;
                    }
                    else
                    {
                        txtArr1.Text = "";
                    }
                }
                else
                {
                    txtArr1.Text = "";
                }
            }
            else
            {
                txtArr1.Text = "";
            }

            if (!string.IsNullOrWhiteSpace(txtArr1.Text))
            {
                if (cellValueCheckerN(5, rowIdx))
                {
                    decimal d1 = changeDigit(txtArr1.Text);
                    decimal d2 = changeDigit(gridMitsmori[3, rowIdx].Value.ToString());
                    decimal d3 = 0;
                    d3 = changeDigit(gridMitsmori[5, rowIdx].Value.ToString());
                    decimal dx = 0;
                    if ((d2 * d3) != 0) {
                        dx = Decimal.Round(decimal.Divide(d1, (d2 * d3)) * 100, 1);
                    }
                    if (Decimal.Compare(dx, 15) > 0)
                    {
                        txtZaiCd1.ForeColor = Color.Black;
                        txtZaiMei1.ForeColor = Color.Black;
                        txtZaiTeika1.ForeColor = Color.Black;
                        txtZaiTnk1.ForeColor = Color.Black;
                        txtZaiCd1.ForeColor = Color.Black;
                        txtZaiRit1.ForeColor = Color.Black;
                        txtKakCd1.ForeColor = Color.Black;
                        txtKakMei1.ForeColor = Color.Black;
                        txtKakTnk1.ForeColor = Color.Black;
                        txtArr1.ForeColor = Color.Black;
                        txtSrrt1.ForeColor = Color.Black;
                    }
                    else
                    {
                        txtZaiCd1.ForeColor = Color.Red;
                        txtZaiMei1.ForeColor = Color.Red;
                        txtZaiTeika1.ForeColor = Color.Red;
                        txtZaiTnk1.ForeColor = Color.Red;
                        txtZaiCd1.ForeColor = Color.Red;
                        txtZaiRit1.ForeColor = Color.Red;
                        txtKakCd1.ForeColor = Color.Red;
                        txtKakMei1.ForeColor = Color.Red;
                        txtKakTnk1.ForeColor = Color.Red;
                        txtArr1.ForeColor = Color.Red;
                        txtSrrt1.ForeColor = Color.Red;
                    }
                    txtSrrt1.Text = dx.ToString();
                    gridMitsmori[19, rowIdx].Value = txtSrrt1.Text;
                }
                else
                {
                    txtSrrt1.Text = "";
                }
            }
            else
            {
                txtSrrt1.Text = "";
            }
        }

        private void calc2(int rowIdx)
        {
            if (!string.IsNullOrWhiteSpace(txtZaiTnk2.Text))
            {
                gridMitsmori[22, rowIdx].Value = txtZaiTnk2.Text;
            }

            if (cellValueCheckerN(91, rowIdx))
            {
                Decimal d1 = decimal.Parse(gridMitsmori[91, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                Decimal d2 = 0;

                if (isNotNullBlank(txtZaiTnk2.Text))
                {
                    d2 = decimal.Parse(txtZaiTnk2.Text, System.Globalization.NumberStyles.Number);
                }

                if (d1 != 0) {
                    txtZaiRit2.Text = (Decimal.Round(decimal.Divide(d2, d1) * 100, 1)).ToString();
                }

                d2 = 0;
            }

            if (cellValueCheckerN(3, rowIdx))
            {
                decimal d1 = 0;
                decimal d2 = 0;
                decimal d3 = 0;
                decimal d4 = 0;
                decimal dt = 0;
                bool calcFlg = false;
                d4 = Decimal.Parse(gridMitsmori[3, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);

                if (!string.IsNullOrWhiteSpace(txtZaiTnk2.Text))
                {
                    d1 = decimal.Parse(txtZaiTnk2.Text, System.Globalization.NumberStyles.Number);
                    gridMitsmori[23, rowIdx].Value = Decimal.Multiply(d1, d4).ToString();
                    calcFlg = true;
                }
                if (!string.IsNullOrWhiteSpace(txtKakTnk2.Text))
                {
                    d2 = decimal.Parse(txtKakTnk2.Text, System.Globalization.NumberStyles.Number);
                    calcFlg = true;
                }

                if (cellValueCheckerN(5, rowIdx))
                {
                    if (calcFlg) {
                        d3 = Decimal.Parse(gridMitsmori[5, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                        dt = Decimal.Multiply(d3, d4) - (Decimal.Multiply(d1, d4) + Decimal.Multiply(d2, d4));
                        txtArr2.Text = dt.ToString();
                        gridMitsmori[24, rowIdx].Value = txtArr2.Text;
                    }
                    else
                    {
                        txtArr2.Text = "";
                    }
                }
                else
                {
                    txtArr2.Text = "";
                }
            }
            else
            {
                txtArr2.Text = "";
            }

            if (!string.IsNullOrWhiteSpace(txtArr2.Text))
            {
                if (cellValueCheckerN(5, rowIdx))
                {
                    decimal d1 = decimal.Parse(txtArr2.Text, System.Globalization.NumberStyles.Number);
                    decimal d2 = decimal.Parse(gridMitsmori[3, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    decimal d3 = 0;
                    d3 = decimal.Parse(gridMitsmori[5, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    decimal dx = 0;
                    if ((d2 * d3) != 0)
                    {
                        dx = Decimal.Round(decimal.Divide(d1, (d2 * d3)) * 100, 1);
                    }
                    if (Decimal.Compare(dx, 15) > 0)
                    {
                        txtZaiCd2.ForeColor = Color.Black;
                        txtZaiMei2.ForeColor = Color.Black;
                        txtZaiTeika2.ForeColor = Color.Black;
                        txtZaiTnk2.ForeColor = Color.Black;
                        txtZaiCd2.ForeColor = Color.Black;
                        txtZaiRit2.ForeColor = Color.Black;
                        txtKakCd2.ForeColor = Color.Black;
                        txtKakMei2.ForeColor = Color.Black;
                        txtKakTnk2.ForeColor = Color.Black;
                        txtArr2.ForeColor = Color.Black;
                        txtSrrt2.ForeColor = Color.Black;
                    }
                    else
                    {
                        txtZaiCd2.ForeColor = Color.Red;
                        txtZaiMei2.ForeColor = Color.Red;
                        txtZaiTeika2.ForeColor = Color.Red;
                        txtZaiTnk2.ForeColor = Color.Red;
                        txtZaiCd2.ForeColor = Color.Red;
                        txtZaiRit2.ForeColor = Color.Red;
                        txtKakCd2.ForeColor = Color.Red;
                        txtKakMei2.ForeColor = Color.Red;
                        txtKakTnk2.ForeColor = Color.Red;
                        txtArr2.ForeColor = Color.Red;
                        txtSrrt2.ForeColor = Color.Red;
                    }
                    txtSrrt2.Text = dx.ToString();
                    gridMitsmori[25, rowIdx].Value = txtSrrt2.Text;
                }
                else
                {
                    txtSrrt2.Text = "";
                }
            }
            else
            {
                txtSrrt2.Text = "";
            }
        }

        private void calc3(int rowIdx)
        {
            if (!string.IsNullOrWhiteSpace(txtZaiTnk3.Text))
            {
                gridMitsmori[28, rowIdx].Value = txtZaiTnk3.Text;
            }

            if (cellValueCheckerN(92, rowIdx))
            {
                Decimal d1 = decimal.Parse(gridMitsmori[92, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                Decimal d2 = 0;

                if (isNotNullBlank(txtZaiTnk3.Text))
                {
                    d2 = decimal.Parse(txtZaiTnk3.Text, System.Globalization.NumberStyles.Number);
                }

                if (d1 != 0) {
                    txtZaiRit3.Text = (Decimal.Round(decimal.Divide(d2, d1) * 100, 1)).ToString();
                }

                d2 = 0;
            }
            if (cellValueCheckerN(3, rowIdx))
            {
                decimal d1 = 0;
                decimal d2 = 0;
                decimal d3 = 0;
                decimal d4 = 0;
                decimal dt = 0;
                bool calcFlg = false;
                d4 = Decimal.Parse(gridMitsmori[3, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);

                if (!string.IsNullOrWhiteSpace(txtZaiTnk3.Text))
                {
                    d1 = decimal.Parse(txtZaiTnk3.Text, System.Globalization.NumberStyles.Number);
                    gridMitsmori[29, rowIdx].Value = Decimal.Multiply(d1, d4).ToString();
                    calcFlg = true;
                }
                if (!string.IsNullOrWhiteSpace(txtKakTnk3.Text))
                {
                    d2 = decimal.Parse(txtKakTnk3.Text, System.Globalization.NumberStyles.Number);
                    calcFlg = true;
                }

                if (cellValueCheckerN(5, rowIdx))
                {
                    if (calcFlg) {
                        d3 = Decimal.Parse(gridMitsmori[5, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                        dt = Decimal.Multiply(d3, d4) - (Decimal.Multiply(d1, d4) + Decimal.Multiply(d2, d4));
                        txtArr3.Text = dt.ToString();
                        gridMitsmori[30, rowIdx].Value = txtArr3.Text;
                    }
                    else
                    {
                        txtArr3.Text = "";
                    }
                }
                else
                {
                    txtArr3.Text = "";
                }
            }
            else
            {
                txtArr3.Text = "";
            }

            if (!string.IsNullOrWhiteSpace(txtArr3.Text))
            {
                if (cellValueCheckerN(5, rowIdx))
                {
                    decimal d1 = decimal.Parse(txtArr3.Text, System.Globalization.NumberStyles.Number);
                    decimal d2 = decimal.Parse(gridMitsmori[3, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    decimal d3 = 0;
                    d3 = decimal.Parse(gridMitsmori[5, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    decimal dx = 0;
                    if ((d2 * d3) != 0)
                    {
                        dx = Decimal.Round(decimal.Divide(d1, (d2 * d3)) * 100, 1);
                    }
                    if (Decimal.Compare(dx, 15) > 0)
                    {
                        txtZaiCd3.ForeColor = Color.Black;
                        txtZaiMei3.ForeColor = Color.Black;
                        txtZaiTeika3.ForeColor = Color.Black;
                        txtZaiTnk3.ForeColor = Color.Black;
                        txtZaiCd3.ForeColor = Color.Black;
                        txtZaiRit3.ForeColor = Color.Black;
                        txtKakCd3.ForeColor = Color.Black;
                        txtKakMei3.ForeColor = Color.Black;
                        txtKakTnk3.ForeColor = Color.Black;
                        txtArr3.ForeColor = Color.Black;
                        txtSrrt3.ForeColor = Color.Black;
                    }
                    else
                    {
                        txtZaiCd3.ForeColor = Color.Red;
                        txtZaiMei3.ForeColor = Color.Red;
                        txtZaiTeika3.ForeColor = Color.Red;
                        txtZaiTnk3.ForeColor = Color.Red;
                        txtZaiCd3.ForeColor = Color.Red;
                        txtZaiRit3.ForeColor = Color.Red;
                        txtKakCd3.ForeColor = Color.Red;
                        txtKakMei3.ForeColor = Color.Red;
                        txtKakTnk3.ForeColor = Color.Red;
                        txtArr3.ForeColor = Color.Red;
                        txtSrrt3.ForeColor = Color.Red;
                    }
                    txtSrrt3.Text = dx.ToString();
                    gridMitsmori[31, rowIdx].Value = txtSrrt3.Text;
                }
                else
                {
                    txtSrrt3.Text = "";
                }
            }
            else
            {
                txtSrrt3.Text = "";
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            String tmpCd;
            String tmpMei;
            String tmpTnk;

            tmpCd = txtKakCd1.Text;
            tmpMei = txtKakMei1.Text;
            tmpTnk = txtKakTnk1.Text;

            txtKakCd1.Text = txtKakCd2.Text;
            txtKakMei1.Text = txtKakMei2.Text;
            txtKakTnk1.Text = txtKakTnk2.Text;

            txtKakCd2.Text = tmpCd;
            txtKakMei2.Text = tmpMei;
            txtKakTnk2.Text = tmpTnk;

            calc1(int.Parse(txtIdx.Text, System.Globalization.NumberStyles.Number));
            calc2(int.Parse(txtIdx.Text, System.Globalization.NumberStyles.Number));
        }

        private void button26_Click(object sender, EventArgs e)
        {
            String tmpCd;
            String tmpMei;
            String tmpTnk;

            tmpCd = txtKakCd2.Text;
            tmpMei = txtKakMei2.Text;
            tmpTnk = txtKakTnk2.Text;

            txtKakCd2.Text = txtKakCd3.Text;
            txtKakMei2.Text = txtKakMei3.Text;
            txtKakTnk2.Text = txtKakTnk3.Text;

            txtKakCd3.Text = tmpCd;
            txtKakMei3.Text = tmpMei;
            txtKakTnk3.Text = tmpTnk;

            calc2(int.Parse(txtIdx.Text, System.Globalization.NumberStyles.Number));
            calc3(int.Parse(txtIdx.Text, System.Globalization.NumberStyles.Number));
        }

        private void setKak(int rowIdx)
        {
            gridMitsmori[50, rowIdx].Value = txtKakCd1.Text;
            gridMitsmori[51, rowIdx].Value = txtKakMei1.Text;
            gridMitsmori[52, rowIdx].Value = txtKakTnk1.Text;

            gridMitsmori[56, rowIdx].Value = txtKakCd2.Text;
            gridMitsmori[57, rowIdx].Value = txtKakMei2.Text;
            gridMitsmori[58, rowIdx].Value = txtKakTnk2.Text;

            gridMitsmori[62, rowIdx].Value = txtKakCd3.Text;
            gridMitsmori[63, rowIdx].Value = txtKakMei3.Text;
            gridMitsmori[64, rowIdx].Value = txtKakTnk3.Text;
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridMitsmori.CurrentCell.ColumnIndex == 2 && e.KeyCode == Keys.F9)
            {
                Form12 f = new Form12();
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
                f.IntRowIdx = gridMitsmori.CurrentCell.RowIndex;
                f.FrmParent = this;

                f.ShowDialog();
                f.Dispose();
                if (StrHinmei != null && !StrHinmei.Equals("")) {
                    gridMitsmori.CurrentCell = gridMitsmori[2, IntRowIdx];
                    gridMitsmori.CurrentCell.Value = StrHinmei;
                    gridMitsmori[85, IntRowIdx].Value = StrDaibunrui;
                    gridMitsmori[86, IntRowIdx].Value = StrChubunrui;
                    gridMitsmori[87, IntRowIdx].Value = StrMaker;
                }
            }
        }

        private void txtZaiTeika1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtZaiTeika2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtZaiTeika3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtZaiTeika1_Leave(object sender, EventArgs e)
        {
            if (isNotNullBlank(txtZaiTeika1.Text)) {
                decimal d = decimal.Parse(txtZaiTeika1.Text, System.Globalization.NumberStyles.Number);
                txtZaiTeika1.Text = d.ToString();
                gridMitsmori[90, int.Parse(txtIdx.Text)].Value = txtZaiTeika1.Text;
                calc1(int.Parse(txtIdx.Text));
            }
        }

        private void txtZaiTeika2_Leave(object sender, EventArgs e)
        {
            if (isNotNullBlank(txtZaiTeika2.Text))
            {
                decimal d = decimal.Parse(txtZaiTeika2.Text, System.Globalization.NumberStyles.Number);
                txtZaiTeika2.Text = d.ToString();
                gridMitsmori[91, int.Parse(txtIdx.Text)].Value = txtZaiTeika2.Text;
                calc2(int.Parse(txtIdx.Text));
            }
        }

        private void txtZaiTeika3_Leave(object sender, EventArgs e)
        {
            if (isNotNullBlank(txtZaiTeika3.Text))
            {
                decimal d = decimal.Parse(txtZaiTeika3.Text, System.Globalization.NumberStyles.Number);
                txtZaiTeika3.Text = d.ToString();
                gridMitsmori[92, int.Parse(txtIdx.Text)].Value = txtZaiTeika3.Text;
                calc3(int.Parse(txtIdx.Text));
            }
        }

        private void txtZaiTnk1_Leave(object sender, EventArgs e)
        {
            if (isNotNullBlank(txtZaiTnk1.Text))
            {
                decimal d = decimal.Parse(txtZaiTnk1.Text, System.Globalization.NumberStyles.Number);
                txtZaiTnk1.Text = d.ToString();
                gridMitsmori[16, int.Parse(txtIdx.Text)].Value = txtZaiTnk1.Text;
                calc1(int.Parse(txtIdx.Text));
            }
        }

        private void txtZaiTnk2_Leave(object sender, EventArgs e)
        {
            if (isNotNullBlank(txtZaiTnk2.Text))
            {
                decimal d = decimal.Parse(txtZaiTnk2.Text, System.Globalization.NumberStyles.Number);
                txtZaiTnk2.Text = d.ToString();
                gridMitsmori[22, int.Parse(txtIdx.Text)].Value = txtZaiTnk2.Text;
                calc2(int.Parse(txtIdx.Text));
            }
        }

        private void txtZaiTnk3_Leave(object sender, EventArgs e)
        {
            if (isNotNullBlank(txtZaiTnk3.Text))
            {
                decimal d = decimal.Parse(txtZaiTnk3.Text, System.Globalization.NumberStyles.Number);
                txtZaiTnk3.Text = d.ToString();
                gridMitsmori[28, int.Parse(txtIdx.Text)].Value = txtZaiTnk3.Text;
                calc3(int.Parse(txtIdx.Text));
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //editGrid(e);
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            editGrid(e);
        }

        private void editGrid(DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 5)
            {
                if (cellValueCheckerN(4, e.RowIndex) && cellValueCheckerN(5, e.RowIndex))
                {
                    if (decimal.Parse((gridMitsmori[4, e.RowIndex].Value).ToString(), System.Globalization.NumberStyles.Number) != 0)
                    {
                        decimal d1 = decimal.Parse((gridMitsmori[5, e.RowIndex].Value).ToString(), System.Globalization.NumberStyles.Number);
                        decimal d2 = decimal.Parse((gridMitsmori[4, e.RowIndex].Value).ToString(), System.Globalization.NumberStyles.Number);
                        gridMitsmori[6, e.RowIndex].Value = (Decimal.Round(decimal.Divide(d1, d2) * 100, 1)).ToString();
                        calc1(e.RowIndex);
                        calc2(e.RowIndex);
                        calc3(e.RowIndex);
                    }
                }
            }

            if (e.ColumnIndex == 2 && e.RowIndex >= 0 && cellValueChecker(2, e.RowIndex))
            {
                String val = (gridMitsmori[2, e.RowIndex].Value).ToString();
                if (val != null && !val.Equals(""))
                {
                    gridMitsmori[1, e.RowIndex].Value = true;
                }
                else
                {
                    gridMitsmori[1, e.RowIndex].Value = false;
                }
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

            if (string.IsNullOrWhiteSpace(gridMitsmori[2, 0].Value.ToString()))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "項目が空です。値を入力してください", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                basemessagebox.ShowDialog();
                return false;
            }

            return true;
        }

        private void addRow()
        {
            if (gridMitsmori.CurrentCell == null)
            {
                return;
            }
            int rNum = gridMitsmori.CurrentCell.RowIndex;
            dt.Rows.InsertAt(dt.NewRow(), rNum);

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

        private void getMitsumoriInfo()
        {
            if (string.IsNullOrWhiteSpace(txtMNum.Text))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtMode.Text) && txtMode.Text.Equals("2"))
            {
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "見積データをコピーします。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
            }

            H0210_MitsumoriInput_B mInputB = new H0210_MitsumoriInput_B();
            try
            {
                DataTable dtInfo = mInputB.getMitsumoriInfo(txtMNum.Text);

                if (dtInfo == null || dtInfo.Rows.Count == 0)
                {
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, "見積データがありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_EXCLAMATION);
                    basemessagebox.ShowDialog();
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
                lsEigyosho.CodeTxtText = dtInfo.Rows[0]["営業所コード"].ToString();
                txtNonyuCd.Text = dtInfo.Rows[0]["納入先コード"].ToString();
                txtNonyuName.Text = dtInfo.Rows[0]["納入先名称"].ToString();

                dt = mInputB.getMitsumoriDetail(txtMNum.Text);

                gridMitsmori.DataSource = dt;

                setText(0);
                changeTotal();
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_ERROR, CommonTeisu.LABEL_ERROR_MESSAGE, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }
        }

        private void txtZaiCd1_Leave(object sender, EventArgs e)
        {
            setShiiresaki(sender);
        }

        private void setShiiresaki(object sender) {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                return;
            }

            ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();
            if (((TextBox)sender).Text.Length < 4)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.PadLeft(4, '0');
            }

            List<string> lstStringSQL = new List<string>();

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("C_LIST_ShiresakiAS400_SELECT_LEAVE");

            OpenSQL opensql = new OpenSQL();
            try
            {
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                if (string.IsNullOrWhiteSpace(strSQLInput))
                {
                    return;
                }

                strSQLInput = string.Format(strSQLInput, ((TextBox)sender).Text);

                //SQLのインスタンス作成
                DBConnective dbconnective = new DBConnective();

                //SQL文を直書き（＋戻り値を受け取る)
                DataTable dtSetCd = dbconnective.ReadSql(strSQLInput);

                if (dtSetCd.Rows.Count != 0)
                {
                    ((TextBox)sender).Text = dtSetCd.Rows[0]["仕入先コード"].ToString();
                    
                    if (((TextBox)sender).Name.Equals("txtZaiCd1"))
                    {
                        txtZaiMei1.Text = dtSetCd.Rows[0]["仕入先名"].ToString();
                        gridMitsmori[14, gridMitsmori.CurrentCell.RowIndex].Value = ((TextBox)sender).Text;
                        gridMitsmori[15, gridMitsmori.CurrentCell.RowIndex].Value = txtZaiMei1.Text;
                    }
                    else if (((TextBox)sender).Name.Equals("txtZaiCd2"))
                    {
                        txtZaiMei2.Text = dtSetCd.Rows[0]["仕入先名"].ToString();
                        gridMitsmori[20, gridMitsmori.CurrentCell.RowIndex].Value = ((TextBox)sender).Text;
                        gridMitsmori[21, gridMitsmori.CurrentCell.RowIndex].Value = txtZaiMei2.Text;
                    }
                    else if (((TextBox)sender).Name.Equals("txtZaiCd3"))
                    {
                        txtZaiMei3.Text = dtSetCd.Rows[0]["仕入先名"].ToString();
                        gridMitsmori[26, gridMitsmori.CurrentCell.RowIndex].Value = ((TextBox)sender).Text;
                        gridMitsmori[27, gridMitsmori.CurrentCell.RowIndex].Value = txtZaiMei3.Text;
                    }
                }
                else
                {
                    //メッセージボックスの処理、項目のデータがない場合のウィンドウ（OK）
                    if (bCdflg) {
                        BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, CommonTeisu.LABEL_NOTDATA, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                        basemessagebox.ShowDialog();
                        bCdflg = false;
                    }
                    else
                    {
                        bCdflg = true;
                    }

                    if (((TextBox)sender).Name.Equals("txtZaiCd1"))
                    {
                        gridMitsmori[14, gridMitsmori.CurrentCell.RowIndex].Value = ((TextBox)sender).Text;
                        txtZaiMei1.Text = "";
                        txtZaiCd1.Focus();
                    }
                    else if (((TextBox)sender).Name.Equals("txtZaiCd2"))
                    {
                        gridMitsmori[20, gridMitsmori.CurrentCell.RowIndex].Value = ((TextBox)sender).Text;
                        txtZaiMei2.Text = "";
                        txtZaiCd2.Focus();
                    }
                    else if (((TextBox)sender).Name.Equals("txtZaiCd3"))
                    {
                        gridMitsmori[26, gridMitsmori.CurrentCell.RowIndex].Value = ((TextBox)sender).Text;
                        txtZaiMei3.Text = "";
                        txtZaiCd3.Focus();
                    }

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

        private Decimal changeDigit(string s)
        {
            Decimal d = 0;

            try
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    if (Decimal.TryParse(s, out d))
                    {
                        d = Decimal.Parse(s, System.Globalization.NumberStyles.Number);
                    }
                }
            }
            catch (Exception ex) { }

            return d;
        }

        private void txtMNum_Leave(object sender, EventArgs e)
        {
            getMitsumoriInfo();
        }

        private void txtMNum_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }



    }
}
