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

namespace KATO.Form.H0210_MitsumoriInput
{
    public partial class H0210_MitsumoriInput : BaseForm
    {
        private Boolean bFirst = true;

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


            gridMitsmori.RowCount = 30;

            // 行番号
            gridMitsmori.CurrentCell = gridMitsmori[0, 0];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[0, 1];
            gridMitsmori.CurrentCell.Value = "2";
            gridMitsmori.CurrentCell = gridMitsmori[0, 2];
            gridMitsmori.CurrentCell.Value = "3";
            gridMitsmori.CurrentCell = gridMitsmori[0, 3];
            gridMitsmori.CurrentCell.Value = "4";
            gridMitsmori.CurrentCell = gridMitsmori[0, 4];
            gridMitsmori.CurrentCell.Value = "5";
            gridMitsmori.CurrentCell = gridMitsmori[0, 5];
            gridMitsmori.CurrentCell.Value = "6";
            gridMitsmori.CurrentCell = gridMitsmori[0, 6];
            gridMitsmori.CurrentCell.Value = "7";
            gridMitsmori.CurrentCell = gridMitsmori[0, 7];
            gridMitsmori.CurrentCell.Value = "8";
            gridMitsmori.CurrentCell = gridMitsmori[0, 8];
            gridMitsmori.CurrentCell.Value = "9";
            gridMitsmori.CurrentCell = gridMitsmori[0, 9];
            gridMitsmori.CurrentCell.Value = "10";
            gridMitsmori.CurrentCell = gridMitsmori[0, 10];
            gridMitsmori.CurrentCell.Value = "11";
            gridMitsmori.CurrentCell = gridMitsmori[0, 11];
            gridMitsmori.CurrentCell.Value = "12";
            gridMitsmori.CurrentCell = gridMitsmori[0, 12];
            gridMitsmori.CurrentCell.Value = "13";
            gridMitsmori.CurrentCell = gridMitsmori[0, 13];
            gridMitsmori.CurrentCell.Value = "14";
            gridMitsmori.CurrentCell = gridMitsmori[0, 14];
            gridMitsmori.CurrentCell.Value = "15";
            gridMitsmori.CurrentCell = gridMitsmori[0, 15];
            gridMitsmori.CurrentCell.Value = "16";
            gridMitsmori.CurrentCell = gridMitsmori[0, 16];
            gridMitsmori.CurrentCell.Value = "17";
            gridMitsmori.CurrentCell = gridMitsmori[0, 17];
            gridMitsmori.CurrentCell.Value = "18";
            gridMitsmori.CurrentCell = gridMitsmori[0, 18];
            gridMitsmori.CurrentCell.Value = "19";
            gridMitsmori.CurrentCell = gridMitsmori[0, 19];
            gridMitsmori.CurrentCell.Value = "20";
            gridMitsmori.CurrentCell = gridMitsmori[0, 20];
            gridMitsmori.CurrentCell.Value = "21";
            gridMitsmori.CurrentCell = gridMitsmori[0, 21];
            gridMitsmori.CurrentCell.Value = "22";
            gridMitsmori.CurrentCell = gridMitsmori[0, 22];
            gridMitsmori.CurrentCell.Value = "23";
            gridMitsmori.CurrentCell = gridMitsmori[0, 23];
            gridMitsmori.CurrentCell.Value = "24";
            gridMitsmori.CurrentCell = gridMitsmori[0, 24];
            gridMitsmori.CurrentCell.Value = "25";
            gridMitsmori.CurrentCell = gridMitsmori[0, 25];
            gridMitsmori.CurrentCell.Value = "26";
            gridMitsmori.CurrentCell = gridMitsmori[0, 26];
            gridMitsmori.CurrentCell.Value = "27";
            gridMitsmori.CurrentCell = gridMitsmori[0, 27];
            gridMitsmori.CurrentCell.Value = "28";
            gridMitsmori.CurrentCell = gridMitsmori[0, 28];
            gridMitsmori.CurrentCell.Value = "29";
            gridMitsmori.CurrentCell = gridMitsmori[0, 29];
            gridMitsmori.CurrentCell.Value = "30";

            gridMitsmori.CurrentCell = gridMitsmori[2, 0];
            gridMitsmori.CurrentCell.Value = "ﾛｰﾗｰ(ﾌﾟｰﾘ) JUC-320-60 (ｽﾀﾝﾄﾞﾒｯｷ)";
            gridMitsmori.CurrentCell = gridMitsmori[3, 0];
            gridMitsmori.CurrentCell.Value = "15";
            gridMitsmori.CurrentCell = gridMitsmori[4, 0];
            gridMitsmori.CurrentCell.Value = "16,000";
            gridMitsmori.CurrentCell = gridMitsmori[5, 0];
            gridMitsmori.CurrentCell.Value = "13,600";
            gridMitsmori.CurrentCell = gridMitsmori[6, 0];
            gridMitsmori.CurrentCell.Value = "85";
            gridMitsmori.CurrentCell = gridMitsmori[7, 0];
            gridMitsmori.CurrentCell.Value = "204,000";
            gridMitsmori.CurrentCell = gridMitsmori[8, 0];
            gridMitsmori.CurrentCell.Value = "6,800.0";
            gridMitsmori.CurrentCell = gridMitsmori[9, 0];
            gridMitsmori.CurrentCell.Value = "102,000";
            gridMitsmori.CurrentCell = gridMitsmori[10, 0];
            gridMitsmori.CurrentCell.Value = "50";
            gridMitsmori.CurrentCell = gridMitsmori[11, 0];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[12, 0];
            gridMitsmori.CurrentCell.Value = "スナダ技研工業（株）";
            gridMitsmori.CurrentCell = gridMitsmori[13, 0];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[14, 0];
            gridMitsmori.CurrentCell.Value = "0366";                       // 仕入先コード
            gridMitsmori.CurrentCell = gridMitsmori[15, 0];
            gridMitsmori.CurrentCell.Value = "東海精密エンジニアリング㈱"; // 仕入先名
            gridMitsmori.CurrentCell = gridMitsmori[16, 0];
            gridMitsmori.CurrentCell.Value = "12,240.4";                  // 仕入単価
            gridMitsmori.CurrentCell = gridMitsmori[17, 0];
            gridMitsmori.CurrentCell.Value = "183,600";                    // 仕入金額
            gridMitsmori.CurrentCell = gridMitsmori[18, 0];
            gridMitsmori.CurrentCell.Value = "20,400";                     // 粗利
            gridMitsmori.CurrentCell = gridMitsmori[19, 0];
            gridMitsmori.CurrentCell.Value = "10";                      // 粗利率
            gridMitsmori.CurrentCell = gridMitsmori[20, 0];
            gridMitsmori.CurrentCell.Value = "2881";
            gridMitsmori.CurrentCell = gridMitsmori[21, 0];
            gridMitsmori.CurrentCell.Value = "スナダ技研工業（株）";
            gridMitsmori.CurrentCell = gridMitsmori[22, 0];
            gridMitsmori.CurrentCell.Value = "6,800.0";
            gridMitsmori.CurrentCell = gridMitsmori[23, 0];
            gridMitsmori.CurrentCell.Value = "102,000";
            gridMitsmori.CurrentCell = gridMitsmori[24, 0];
            gridMitsmori.CurrentCell.Value = "102,000";
            gridMitsmori.CurrentCell = gridMitsmori[25, 0];
            gridMitsmori.CurrentCell.Value = "50";
            gridMitsmori.CurrentCell = gridMitsmori[26, 0];
            gridMitsmori.CurrentCell.Value = "2857";
            gridMitsmori.CurrentCell = gridMitsmori[27, 0];
            gridMitsmori.CurrentCell.Value = "（有）柴田製作所";
            gridMitsmori.CurrentCell = gridMitsmori[28, 0];
            gridMitsmori.CurrentCell.Value = "10,880.0";
            gridMitsmori.CurrentCell = gridMitsmori[29, 0];
            gridMitsmori.CurrentCell.Value = "163,200";
            gridMitsmori.CurrentCell = gridMitsmori[30, 0];
            gridMitsmori.CurrentCell.Value = "40,800";
            gridMitsmori.CurrentCell = gridMitsmori[31, 0];
            gridMitsmori.CurrentCell.Value = "20";
            
            gridMitsmori.CurrentCell = gridMitsmori[2, 1];
            gridMitsmori.CurrentCell.Value = "ﾛｰﾗｰ(ﾌﾟｰﾘ) M-JUAC-320-60 (ｽﾀﾝﾄﾞﾒｯｷ)旋回部ｳﾚﾀﾝ付";
            gridMitsmori.CurrentCell = gridMitsmori[3, 1];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[4, 1];
            gridMitsmori.CurrentCell.Value = "50,000";
            gridMitsmori.CurrentCell = gridMitsmori[5, 1];
            gridMitsmori.CurrentCell.Value = "47,000";
            gridMitsmori.CurrentCell = gridMitsmori[6, 1];
            gridMitsmori.CurrentCell.Value = "94";
            gridMitsmori.CurrentCell = gridMitsmori[7, 1];
            gridMitsmori.CurrentCell.Value = "47,000";
            gridMitsmori.CurrentCell = gridMitsmori[8, 1];
            gridMitsmori.CurrentCell.Value = "37,600.0";
            gridMitsmori.CurrentCell = gridMitsmori[9, 1];
            gridMitsmori.CurrentCell.Value = "9,400";
            gridMitsmori.CurrentCell = gridMitsmori[10, 1];
            gridMitsmori.CurrentCell.Value = "20";
            gridMitsmori.CurrentCell = gridMitsmori[11, 1];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[12, 1];
            gridMitsmori.CurrentCell.Value = "東海精密エンジニアリング㈱";
            gridMitsmori.CurrentCell = gridMitsmori[13, 1];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[14, 1];
            gridMitsmori.CurrentCell.Value = "0366";                       // 仕入先コード
            gridMitsmori.CurrentCell = gridMitsmori[15, 1];
            gridMitsmori.CurrentCell.Value = "東海精密エンジニアリング㈱"; // 仕入先名
            gridMitsmori.CurrentCell = gridMitsmori[16, 1];
            gridMitsmori.CurrentCell.Value = "37,600.0";                  // 仕入単価
            gridMitsmori.CurrentCell = gridMitsmori[17, 1];
            gridMitsmori.CurrentCell.Value = "37,600";                    // 仕入金額
            gridMitsmori.CurrentCell = gridMitsmori[18, 1];
            gridMitsmori.CurrentCell.Value = "9,400";                     // 粗利
            gridMitsmori.CurrentCell = gridMitsmori[19, 1];
            gridMitsmori.CurrentCell.Value = "20";                      // 粗利率
            gridMitsmori.CurrentCell = gridMitsmori[20, 1];
            gridMitsmori.CurrentCell.Value = "2881";
            gridMitsmori.CurrentCell = gridMitsmori[21, 1];
            gridMitsmori.CurrentCell.Value = "スナダ技研工業（株）";
            gridMitsmori.CurrentCell = gridMitsmori[22, 1];
            gridMitsmori.CurrentCell.Value = "42,300.0";
            gridMitsmori.CurrentCell = gridMitsmori[23, 1];
            gridMitsmori.CurrentCell.Value = "42,300";
            gridMitsmori.CurrentCell = gridMitsmori[24, 1];
            gridMitsmori.CurrentCell.Value = "4,700";
            gridMitsmori.CurrentCell = gridMitsmori[25, 1];
            gridMitsmori.CurrentCell.Value = "10";
            gridMitsmori.CurrentCell = gridMitsmori[26, 1];
            gridMitsmori.CurrentCell.Value = "2857";
            gridMitsmori.CurrentCell = gridMitsmori[27, 1];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[28, 1];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[29, 1];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[30, 1];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[31, 1];
            gridMitsmori.CurrentCell.Value = "";

            gridMitsmori.CurrentCell = gridMitsmori[2, 2];
            gridMitsmori.CurrentCell.Value = "ﾛｰﾗｰ(ﾌﾟｰﾘ) JUR-600 (ｽﾀﾝﾄﾞﾒｯｷ)";
            gridMitsmori.CurrentCell = gridMitsmori[3, 2];
            gridMitsmori.CurrentCell.Value = "4";
            gridMitsmori.CurrentCell = gridMitsmori[4, 2];
            gridMitsmori.CurrentCell.Value = "10,000";
            gridMitsmori.CurrentCell = gridMitsmori[5, 2];
            gridMitsmori.CurrentCell.Value = "8,000";
            gridMitsmori.CurrentCell = gridMitsmori[6, 2];
            gridMitsmori.CurrentCell.Value = "80";
            gridMitsmori.CurrentCell = gridMitsmori[7, 2];
            gridMitsmori.CurrentCell.Value = "32,000";
            gridMitsmori.CurrentCell = gridMitsmori[8, 2];
            gridMitsmori.CurrentCell.Value = "5,600.0";
            gridMitsmori.CurrentCell = gridMitsmori[9, 2];
            gridMitsmori.CurrentCell.Value = "9,600";
            gridMitsmori.CurrentCell = gridMitsmori[10, 2];
            gridMitsmori.CurrentCell.Value = "30";
            gridMitsmori.CurrentCell = gridMitsmori[11, 2];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[12, 2];
            gridMitsmori.CurrentCell.Value = "（有）柴田製作所";
            gridMitsmori.CurrentCell = gridMitsmori[13, 2];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[14, 2];
            gridMitsmori.CurrentCell.Value = "0366";                       // 仕入先コード
            gridMitsmori.CurrentCell = gridMitsmori[15, 2];
            gridMitsmori.CurrentCell.Value = "東海精密エンジニアリング㈱"; // 仕入先名
            gridMitsmori.CurrentCell = gridMitsmori[16, 2];
            gridMitsmori.CurrentCell.Value = "6,400.0";                  // 仕入単価
            gridMitsmori.CurrentCell = gridMitsmori[17, 2];
            gridMitsmori.CurrentCell.Value = "25,600";                    // 仕入金額
            gridMitsmori.CurrentCell = gridMitsmori[18, 2];
            gridMitsmori.CurrentCell.Value = "6,400";                     // 粗利
            gridMitsmori.CurrentCell = gridMitsmori[19, 2];
            gridMitsmori.CurrentCell.Value = "20";                      // 粗利率
            gridMitsmori.CurrentCell = gridMitsmori[20, 2];
            gridMitsmori.CurrentCell.Value = "2881";
            gridMitsmori.CurrentCell = gridMitsmori[21, 2];
            gridMitsmori.CurrentCell.Value = "スナダ技研工業（株）";
            gridMitsmori.CurrentCell = gridMitsmori[22, 2];
            gridMitsmori.CurrentCell.Value = "6,400.0";
            gridMitsmori.CurrentCell = gridMitsmori[23, 2];
            gridMitsmori.CurrentCell.Value = "25,600";
            gridMitsmori.CurrentCell = gridMitsmori[24, 2];
            gridMitsmori.CurrentCell.Value = "6,400";
            gridMitsmori.CurrentCell = gridMitsmori[25, 2];
            gridMitsmori.CurrentCell.Value = "20";
            gridMitsmori.CurrentCell = gridMitsmori[26, 2];
            gridMitsmori.CurrentCell.Value = "2857";
            gridMitsmori.CurrentCell = gridMitsmori[27, 2];
            gridMitsmori.CurrentCell.Value = "（有）柴田製作所";
            gridMitsmori.CurrentCell = gridMitsmori[28, 2];
            gridMitsmori.CurrentCell.Value = "5,600.0";
            gridMitsmori.CurrentCell = gridMitsmori[29, 2];
            gridMitsmori.CurrentCell.Value = "22,400";
            gridMitsmori.CurrentCell = gridMitsmori[30, 2];
            gridMitsmori.CurrentCell.Value = "9,600";
            gridMitsmori.CurrentCell = gridMitsmori[31, 2];
            gridMitsmori.CurrentCell.Value = "30";

            gridMitsmori.CurrentCell = gridMitsmori[2, 3];
            gridMitsmori.CurrentCell.Value = "ﾛｰﾗｰ(ﾌﾟｰﾘ) JURP-600K (ｽﾀﾝﾄﾞﾒｯｷ)";
            gridMitsmori.CurrentCell = gridMitsmori[3, 3];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[4, 3];
            gridMitsmori.CurrentCell.Value = "15,000";
            gridMitsmori.CurrentCell = gridMitsmori[5, 3];
            gridMitsmori.CurrentCell.Value = "10,500";
            gridMitsmori.CurrentCell = gridMitsmori[6, 3];
            gridMitsmori.CurrentCell.Value = "70";
            gridMitsmori.CurrentCell = gridMitsmori[7, 3];
            gridMitsmori.CurrentCell.Value = "10,500";
            gridMitsmori.CurrentCell = gridMitsmori[8, 3];
            gridMitsmori.CurrentCell.Value = "8,400.0";
            gridMitsmori.CurrentCell = gridMitsmori[9, 3];
            gridMitsmori.CurrentCell.Value = "2,100";
            gridMitsmori.CurrentCell = gridMitsmori[10, 3];
            gridMitsmori.CurrentCell.Value = "20";
            gridMitsmori.CurrentCell = gridMitsmori[11, 3];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[12, 3];
            gridMitsmori.CurrentCell.Value = "（有）柴田製作所";
            gridMitsmori.CurrentCell = gridMitsmori[13, 3];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[14, 3];
            gridMitsmori.CurrentCell.Value = "0366";                       // 仕入先コード
            gridMitsmori.CurrentCell = gridMitsmori[15, 3];
            gridMitsmori.CurrentCell.Value = "東海精密エンジニアリング㈱"; // 仕入先名
            gridMitsmori.CurrentCell = gridMitsmori[16, 3];
            gridMitsmori.CurrentCell.Value = "9,450.0";                  // 仕入単価
            gridMitsmori.CurrentCell = gridMitsmori[17, 3];
            gridMitsmori.CurrentCell.Value = "9,450";                    // 仕入金額
            gridMitsmori.CurrentCell = gridMitsmori[18, 3];
            gridMitsmori.CurrentCell.Value = "1,050";                     // 粗利
            gridMitsmori.CurrentCell = gridMitsmori[19, 3];
            gridMitsmori.CurrentCell.Value = "10";                      // 粗利率
            gridMitsmori.CurrentCell = gridMitsmori[20, 3];
            gridMitsmori.CurrentCell.Value = "2881";
            gridMitsmori.CurrentCell = gridMitsmori[21, 3];
            gridMitsmori.CurrentCell.Value = "スナダ技研工業（株）";
            gridMitsmori.CurrentCell = gridMitsmori[22, 3];
            gridMitsmori.CurrentCell.Value = "9,450.0";
            gridMitsmori.CurrentCell = gridMitsmori[23, 3];
            gridMitsmori.CurrentCell.Value = "9,450";
            gridMitsmori.CurrentCell = gridMitsmori[24, 3];
            gridMitsmori.CurrentCell.Value = "1,050";
            gridMitsmori.CurrentCell = gridMitsmori[25, 3];
            gridMitsmori.CurrentCell.Value = "10";
            gridMitsmori.CurrentCell = gridMitsmori[26, 3];
            gridMitsmori.CurrentCell.Value = "2857";
            gridMitsmori.CurrentCell = gridMitsmori[27, 3];
            gridMitsmori.CurrentCell.Value = "（有）柴田製作所";
            gridMitsmori.CurrentCell = gridMitsmori[28, 3];
            gridMitsmori.CurrentCell.Value = "8,400.0";
            gridMitsmori.CurrentCell = gridMitsmori[29, 3];
            gridMitsmori.CurrentCell.Value = "8,400";
            gridMitsmori.CurrentCell = gridMitsmori[30, 3];
            gridMitsmori.CurrentCell.Value = "2,100";
            gridMitsmori.CurrentCell = gridMitsmori[31, 3];
            gridMitsmori.CurrentCell.Value = "20";

            gridMitsmori.CurrentCell = gridMitsmori[2, 4];
            gridMitsmori.CurrentCell.Value = "ﾛｰﾗｰ(ﾌﾟｰﾘ) M-JUAR-600 (ｽﾀﾝﾄﾞﾒｯｷ)旋回部ｳﾚﾀﾝ付";
            gridMitsmori.CurrentCell = gridMitsmori[3, 4];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[4, 4];
            gridMitsmori.CurrentCell.Value = "50,000";
            gridMitsmori.CurrentCell = gridMitsmori[5, 4];
            gridMitsmori.CurrentCell.Value = "41,000";
            gridMitsmori.CurrentCell = gridMitsmori[6, 4];
            gridMitsmori.CurrentCell.Value = "82";
            gridMitsmori.CurrentCell = gridMitsmori[7, 4];
            gridMitsmori.CurrentCell.Value = "41,000";
            gridMitsmori.CurrentCell = gridMitsmori[8, 4];
            gridMitsmori.CurrentCell.Value = "26,650.0";
            gridMitsmori.CurrentCell = gridMitsmori[9, 4];
            gridMitsmori.CurrentCell.Value = "14,350";
            gridMitsmori.CurrentCell = gridMitsmori[10, 4];
            gridMitsmori.CurrentCell.Value = "35";
            gridMitsmori.CurrentCell = gridMitsmori[11, 4];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[12, 4];
            gridMitsmori.CurrentCell.Value = "東海精密エンジニアリング㈱";
            gridMitsmori.CurrentCell = gridMitsmori[13, 4];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[14, 4];
            gridMitsmori.CurrentCell.Value = "0366";                       // 仕入先コード
            gridMitsmori.CurrentCell = gridMitsmori[15, 4];
            gridMitsmori.CurrentCell.Value = "東海精密エンジニアリング㈱"; // 仕入先名
            gridMitsmori.CurrentCell = gridMitsmori[16, 4];
            gridMitsmori.CurrentCell.Value = "26,650.0";                  // 仕入単価
            gridMitsmori.CurrentCell = gridMitsmori[17, 4];
            gridMitsmori.CurrentCell.Value = "26,650";                    // 仕入金額
            gridMitsmori.CurrentCell = gridMitsmori[18, 4];
            gridMitsmori.CurrentCell.Value = "14,350";                     // 粗利
            gridMitsmori.CurrentCell = gridMitsmori[19, 4];
            gridMitsmori.CurrentCell.Value = "35";                      // 粗利率
            gridMitsmori.CurrentCell = gridMitsmori[20, 4];
            gridMitsmori.CurrentCell.Value = "2881";
            gridMitsmori.CurrentCell = gridMitsmori[21, 4];
            gridMitsmori.CurrentCell.Value = "スナダ技研工業（株）";
            gridMitsmori.CurrentCell = gridMitsmori[22, 4];
            gridMitsmori.CurrentCell.Value = "30,750.0";
            gridMitsmori.CurrentCell = gridMitsmori[23, 4];
            gridMitsmori.CurrentCell.Value = "30,750";
            gridMitsmori.CurrentCell = gridMitsmori[24, 4];
            gridMitsmori.CurrentCell.Value = "10,250";
            gridMitsmori.CurrentCell = gridMitsmori[25, 4];
            gridMitsmori.CurrentCell.Value = "25";
            gridMitsmori.CurrentCell = gridMitsmori[26, 4];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[27, 4];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[28, 4];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[29, 4];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[30, 4];
            gridMitsmori.CurrentCell.Value = "";
            gridMitsmori.CurrentCell = gridMitsmori[31, 4];
            gridMitsmori.CurrentCell.Value = "";

            gridMitsmori.CurrentCell = gridMitsmori[2, 5];
            gridMitsmori.CurrentCell.Value = " ※ｽﾀﾝﾄﾞ:Znﾒｯｷ　ﾛｰﾗ:黒色塗装";
            gridMitsmori.CurrentCell = gridMitsmori[13, 5];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[2, 6];
            gridMitsmori.CurrentCell.Value = " 1月12日手配で最短2月20日頃となります。";
            gridMitsmori.CurrentCell = gridMitsmori[13, 6];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[2, 7];
            gridMitsmori.CurrentCell.Value = " 恐れ入りますが納期調整お願い出来ませんでしょうか。";
            gridMitsmori.CurrentCell = gridMitsmori[13, 7];
            gridMitsmori.CurrentCell.Value = "1";
            gridMitsmori.CurrentCell = gridMitsmori[2, 8];
            gridMitsmori.CurrentCell.Value = " 現在手配保留中です。";
            gridMitsmori.CurrentCell = gridMitsmori[13, 8];
            gridMitsmori.CurrentCell.Value = "1";

            gridMitsmori[50, 0].Value = "999";
            gridMitsmori[56, 0].Value = "987";
            gridMitsmori[62, 0].Value = "654";

            gridMitsmori[51, 0].Value = "テスト９９９";
            gridMitsmori[57, 0].Value = "テスト９８７";
            gridMitsmori[63, 0].Value = "テスト６５４";

            gridMitsmori[52, 0].Value = "100.0";
            gridMitsmori[58, 0].Value = "500.0";
            gridMitsmori[64, 0].Value = "1,000.0";

            gridMitsmori[50, 1].Value = "123";
            gridMitsmori[56, 1].Value = "456";
            gridMitsmori[62, 1].Value = "789";

            gridMitsmori[51, 1].Value = "テスト１２３";
            gridMitsmori[57, 1].Value = "テスト４５６";
            gridMitsmori[63, 1].Value = "テスト７８９";

            gridMitsmori[52, 1].Value = "150.0";
            gridMitsmori[58, 1].Value = "550.0";
            gridMitsmori[64, 1].Value = "1,500.0";

            gridMitsmori[88, 0].Value = "16,000";
            gridMitsmori[89, 0].Value = "16,000";
            gridMitsmori[90, 0].Value = "16,000";
            gridMitsmori[88, 1].Value = "50,000";
            gridMitsmori[89, 1].Value = "50,000";
            gridMitsmori[90, 1].Value = "50,000";
            gridMitsmori[88, 2].Value = "10,000";
            gridMitsmori[89, 2].Value = "10,000";
            gridMitsmori[90, 2].Value = "10,000";



            gridMitsmori.CurrentCell = gridMitsmori[1, 0];

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
        }

        ///<summary>
        ///GridSetUp
        ///DataGridView初期設定
        ///</summary>
        private void SetUpGrid()
        {
            //列自動生成禁止
            //gridZanList.AutoGenerateColumns = false;

            //データをバインド

            #region
            DataGridViewTextBoxColumn txtRowNum = new DataGridViewTextBoxColumn();
            txtRowNum.DataPropertyName = "No";
            txtRowNum.Name = "No";
            txtRowNum.HeaderText = "No.";

            DataGridViewCheckBoxColumn cbRow = new DataGridViewCheckBoxColumn();
            cbRow.DataPropertyName = "印";
            cbRow.Name = "印";
            cbRow.HeaderText = "印";

            DataGridViewTextBoxColumn hinmei = new DataGridViewTextBoxColumn();
            hinmei.DataPropertyName = "品名・型番";
            hinmei.Name = "品名・型番";
            hinmei.HeaderText = "品名・型番";

            DataGridViewTextBoxColumn suryo = new DataGridViewTextBoxColumn();
            suryo.DataPropertyName = "数量";
            suryo.Name = "数量";
            suryo.HeaderText = "数量";

            DataGridViewTextBoxColumn teika = new DataGridViewTextBoxColumn();
            teika.DataPropertyName = "定価";
            teika.Name = "定価";
            teika.HeaderText = "定価";

            DataGridViewTextBoxColumn mitsumoriTanka = new DataGridViewTextBoxColumn();
            mitsumoriTanka.DataPropertyName = "見積単価";
            mitsumoriTanka.Name = "見積単価";
            mitsumoriTanka.HeaderText = "見積単価";

            DataGridViewTextBoxColumn kakeritsu = new DataGridViewTextBoxColumn();
            kakeritsu.DataPropertyName = "掛率";
            kakeritsu.Name = "掛率";
            kakeritsu.HeaderText = "掛率";

            DataGridViewTextBoxColumn kingaku = new DataGridViewTextBoxColumn();
            kingaku.DataPropertyName = "金額";
            kingaku.Name = "金額";
            kingaku.HeaderText = "金額";

            DataGridViewTextBoxColumn shiireTanka = new DataGridViewTextBoxColumn();
            shiireTanka.DataPropertyName = "仕入単価";
            shiireTanka.Name = "仕入単価";
            shiireTanka.HeaderText = "仕入単価";

            DataGridViewTextBoxColumn arari = new DataGridViewTextBoxColumn();
            arari.DataPropertyName = "粗利";
            arari.Name = "粗利";
            arari.HeaderText = "粗利";

            DataGridViewTextBoxColumn arariritsu = new DataGridViewTextBoxColumn();
            arariritsu.DataPropertyName = "粗利率";
            arariritsu.Name = "粗利率";
            arariritsu.HeaderText = "粗利率";

            DataGridViewTextBoxColumn biko = new DataGridViewTextBoxColumn();
            biko.DataPropertyName = "備考";
            biko.Name = "備考";
            biko.HeaderText = "備考";

            DataGridViewTextBoxColumn shiiresaki = new DataGridViewTextBoxColumn();
            shiiresaki.DataPropertyName = "仕入先";
            shiiresaki.Name = "仕入先";
            shiiresaki.HeaderText = "仕入先";

            DataGridViewTextBoxColumn insatsu = new DataGridViewTextBoxColumn();
            insatsu.DataPropertyName = "印刷";
            insatsu.Name = "印刷";
            insatsu.HeaderText = "印刷";

            #region
            DataGridViewTextBoxColumn shiireCd1 = new DataGridViewTextBoxColumn();
            shiireCd1.DataPropertyName = "仕入先コード１";
            shiireCd1.Name = "仕入先コード１";
            shiireCd1.HeaderText = "仕入先コード１";

            DataGridViewTextBoxColumn shiireName1 = new DataGridViewTextBoxColumn();
            shiireName1.DataPropertyName = "仕入先名１";
            shiireName1.Name = "仕入先名１";
            shiireName1.HeaderText = "仕入先名１";

            DataGridViewTextBoxColumn shiireTanka1 = new DataGridViewTextBoxColumn();
            shiireTanka1.DataPropertyName = "仕入単価１";
            shiireTanka1.Name = "仕入単価１";
            shiireTanka1.HeaderText = "仕入単価１";

            DataGridViewTextBoxColumn shiireKin1 = new DataGridViewTextBoxColumn();
            shiireKin1.DataPropertyName = "仕入金額１";
            shiireKin1.Name = "仕入金額１";
            shiireKin1.HeaderText = "仕入金額１";

            DataGridViewTextBoxColumn arari1 = new DataGridViewTextBoxColumn();
            arari1.DataPropertyName = "粗利１";
            arari1.Name = "粗利１";
            arari1.HeaderText = "粗利１";

            DataGridViewTextBoxColumn arariritsu1 = new DataGridViewTextBoxColumn();
            arariritsu1.DataPropertyName = "粗利率１";
            arariritsu1.Name = "粗利率１";
            arariritsu1.HeaderText = "粗利率１";

            DataGridViewTextBoxColumn shiireCd2 = new DataGridViewTextBoxColumn();
            shiireCd2.DataPropertyName = "仕入先コード２";
            shiireCd2.Name = "仕入先コード２";
            shiireCd2.HeaderText = "仕入先コード２";

            DataGridViewTextBoxColumn shiireName2 = new DataGridViewTextBoxColumn();
            shiireName2.DataPropertyName = "仕入先名２";
            shiireName2.Name = "仕入先名２";
            shiireName2.HeaderText = "仕入先名２";

            DataGridViewTextBoxColumn shiireTanka2 = new DataGridViewTextBoxColumn();
            shiireTanka2.DataPropertyName = "仕入単価２";
            shiireTanka2.Name = "仕入単価２";
            shiireTanka2.HeaderText = "仕入単価２";

            DataGridViewTextBoxColumn shiireKin2 = new DataGridViewTextBoxColumn();
            shiireKin2.DataPropertyName = "仕入金額２";
            shiireKin2.Name = "仕入金額２";
            shiireKin2.HeaderText = "仕入金額２";

            DataGridViewTextBoxColumn arari2 = new DataGridViewTextBoxColumn();
            arari2.DataPropertyName = "粗利２";
            arari2.Name = "粗利２";
            arari2.HeaderText = "粗利２";

            DataGridViewTextBoxColumn arariritsu2 = new DataGridViewTextBoxColumn();
            arariritsu2.DataPropertyName = "粗利率２";
            arariritsu2.Name = "粗利率２";
            arariritsu2.HeaderText = "粗利率２";

            DataGridViewTextBoxColumn shiireCd3 = new DataGridViewTextBoxColumn();
            shiireCd3.DataPropertyName = "仕入先コード３";
            shiireCd3.Name = "仕入先コード３";
            shiireCd3.HeaderText = "仕入先コード３";

            DataGridViewTextBoxColumn shiireName3 = new DataGridViewTextBoxColumn();
            shiireName3.DataPropertyName = "仕入先名３";
            shiireName3.Name = "仕入先名３";
            shiireName3.HeaderText = "仕入先名３";

            DataGridViewTextBoxColumn shiireTanka3 = new DataGridViewTextBoxColumn();
            shiireTanka3.DataPropertyName = "仕入単価３";
            shiireTanka3.Name = "仕入単価３";
            shiireTanka3.HeaderText = "仕入単価３";

            DataGridViewTextBoxColumn shiireKin3 = new DataGridViewTextBoxColumn();
            shiireKin3.DataPropertyName = "仕入金額３";
            shiireKin3.Name = "仕入金額３";
            shiireKin3.HeaderText = "仕入金額３";

            DataGridViewTextBoxColumn arari3 = new DataGridViewTextBoxColumn();
            arari3.DataPropertyName = "粗利３";
            arari3.Name = "粗利３";
            arari3.HeaderText = "粗利３";

            DataGridViewTextBoxColumn arariritsu3 = new DataGridViewTextBoxColumn();
            arariritsu3.DataPropertyName = "粗利率３";
            arariritsu3.Name = "粗利率３";
            arariritsu3.HeaderText = "粗利率３";
            #endregion

            #region
            DataGridViewTextBoxColumn shiireCd4 = new DataGridViewTextBoxColumn();
            shiireCd4.DataPropertyName = "仕入先コード４";
            shiireCd4.Name = "仕入先コード４";
            shiireCd4.HeaderText = "仕入先コード４";
            shiireCd4.Visible = false;

            DataGridViewTextBoxColumn shiireName4 = new DataGridViewTextBoxColumn();
            shiireName4.DataPropertyName = "仕入先名４";
            shiireName4.Name = "仕入先名４";
            shiireName4.HeaderText = "仕入先名４";
            shiireName4.Visible = false;

            DataGridViewTextBoxColumn shiireTanka4 = new DataGridViewTextBoxColumn();
            shiireTanka4.DataPropertyName = "仕入単価４";
            shiireTanka4.Name = "仕入単価４";
            shiireTanka4.HeaderText = "仕入単価４";
            shiireTanka4.Visible = false;

            DataGridViewTextBoxColumn shiireKin4 = new DataGridViewTextBoxColumn();
            shiireKin4.DataPropertyName = "仕入金額４";
            shiireKin4.Name = "仕入金額４";
            shiireKin4.HeaderText = "仕入金額４";
            shiireKin4.Visible = false;

            DataGridViewTextBoxColumn arari4 = new DataGridViewTextBoxColumn();
            arari4.DataPropertyName = "粗利４";
            arari4.Name = "粗利４";
            arari4.HeaderText = "粗利４";
            arari4.Visible = false;

            DataGridViewTextBoxColumn arariritsu4 = new DataGridViewTextBoxColumn();
            arariritsu4.DataPropertyName = "粗利率４";
            arariritsu4.Name = "粗利率４";
            arariritsu4.HeaderText = "粗利率４";
            arariritsu4.Visible = false;

            DataGridViewTextBoxColumn shiireCd5 = new DataGridViewTextBoxColumn();
            shiireCd5.DataPropertyName = "仕入先コード５";
            shiireCd5.Name = "仕入先コード５";
            shiireCd5.HeaderText = "仕入先コード５";
            shiireCd5.Visible = false;

            DataGridViewTextBoxColumn shiireName5 = new DataGridViewTextBoxColumn();
            shiireName5.DataPropertyName = "仕入先名５";
            shiireName5.Name = "仕入先名５";
            shiireName5.HeaderText = "仕入先名５";
            shiireName5.Visible = false;

            DataGridViewTextBoxColumn shiireTanka5 = new DataGridViewTextBoxColumn();
            shiireTanka5.DataPropertyName = "仕入単価５";
            shiireTanka5.Name = "仕入単価５";
            shiireTanka5.HeaderText = "仕入単価５";
            shiireTanka5.Visible = false;

            DataGridViewTextBoxColumn shiireKin5 = new DataGridViewTextBoxColumn();
            shiireKin5.DataPropertyName = "仕入金額５";
            shiireKin5.Name = "仕入金額５";
            shiireKin5.HeaderText = "仕入金額５";
            shiireKin5.Visible = false;

            DataGridViewTextBoxColumn arari5 = new DataGridViewTextBoxColumn();
            arari5.DataPropertyName = "粗利５";
            arari5.Name = "粗利５";
            arari5.HeaderText = "粗利５";
            arari5.Visible = false;

            DataGridViewTextBoxColumn arariritsu5 = new DataGridViewTextBoxColumn();
            arariritsu5.DataPropertyName = "粗利率５";
            arariritsu5.Name = "粗利率５";
            arariritsu5.HeaderText = "粗利率５";
            arariritsu5.Visible = false;

            DataGridViewTextBoxColumn shiireCd6 = new DataGridViewTextBoxColumn();
            shiireCd6.DataPropertyName = "仕入先コード６";
            shiireCd6.Name = "仕入先コード６";
            shiireCd6.HeaderText = "仕入先コード６";
            shiireCd6.Visible = false;

            DataGridViewTextBoxColumn shiireName6 = new DataGridViewTextBoxColumn();
            shiireName6.DataPropertyName = "仕入先名６";
            shiireName6.Name = "仕入先名６";
            shiireName6.HeaderText = "仕入先名６";
            shiireName6.Visible = false;

            DataGridViewTextBoxColumn shiireTanka6 = new DataGridViewTextBoxColumn();
            shiireTanka6.DataPropertyName = "仕入単価６";
            shiireTanka6.Name = "仕入単価６";
            shiireTanka6.HeaderText = "仕入単価６";
            shiireTanka6.Visible = false;

            DataGridViewTextBoxColumn shiireKin6 = new DataGridViewTextBoxColumn();
            shiireKin6.DataPropertyName = "仕入金額６";
            shiireKin6.Name = "仕入金額６";
            shiireKin6.HeaderText = "仕入金額６";
            shiireKin6.Visible = false;

            DataGridViewTextBoxColumn arari6 = new DataGridViewTextBoxColumn();
            arari6.DataPropertyName = "粗利６";
            arari6.Name = "粗利６";
            arari6.HeaderText = "粗利６";
            arari6.Visible = false;

            DataGridViewTextBoxColumn arariritsu6 = new DataGridViewTextBoxColumn();
            arariritsu6.DataPropertyName = "粗利率６";
            arariritsu6.Name = "粗利率６";
            arariritsu6.HeaderText = "粗利率６";
            arariritsu6.Visible = false;
            #endregion

            #region
            DataGridViewTextBoxColumn kakoShiireCd1 = new DataGridViewTextBoxColumn();
            kakoShiireCd1.DataPropertyName = "加工仕入先コード１";
            kakoShiireCd1.Name = "加工仕入先コード１";
            kakoShiireCd1.HeaderText = "加工仕入先コード１";
            kakoShiireCd1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName1 = new DataGridViewTextBoxColumn();
            kakoShiireName1.DataPropertyName = "加工仕入先名１";
            kakoShiireName1.Name = "加工仕入先名１";
            kakoShiireName1.HeaderText = "加工仕入先名１";
            kakoShiireName1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka1 = new DataGridViewTextBoxColumn();
            kakoShiireTanka1.DataPropertyName = "加工仕入単価１";
            kakoShiireTanka1.Name = "加工仕入単価１";
            kakoShiireTanka1.HeaderText = "加工仕入単価１";
            kakoShiireTanka1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin1 = new DataGridViewTextBoxColumn();
            kakoShiireKin1.DataPropertyName = "加工仕入金額１";
            kakoShiireKin1.Name = "加工仕入金額１";
            kakoShiireKin1.HeaderText = "加工仕入金額１";
            kakoShiireKin1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari1 = new DataGridViewTextBoxColumn();
            kakoShiireArari1.DataPropertyName = "加工粗利１";
            kakoShiireArari1.Name = "加工粗利１";
            kakoShiireArari1.HeaderText = "加工粗利１";
            kakoShiireArari1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu1 = new DataGridViewTextBoxColumn();
            kakoShiireArariritsu1.DataPropertyName = "加工粗利率１";
            kakoShiireArariritsu1.Name = "加工粗利率１";
            kakoShiireArariritsu1.HeaderText = "加工粗利率１";
            kakoShiireArariritsu1.Visible = false;

            DataGridViewTextBoxColumn kakoShiireCd2 = new DataGridViewTextBoxColumn();
            kakoShiireCd2.DataPropertyName = "加工仕入先コード２";
            kakoShiireCd2.Name = "加工仕入先コード２";
            kakoShiireCd2.HeaderText = "加工仕入先コード２";
            kakoShiireCd2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName2 = new DataGridViewTextBoxColumn();
            kakoShiireName2.DataPropertyName = "加工仕入先名２";
            kakoShiireName2.Name = "加工仕入先名２";
            kakoShiireName2.HeaderText = "加工仕入先名２";
            kakoShiireName2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka2 = new DataGridViewTextBoxColumn();
            kakoShiireTanka2.DataPropertyName = "加工仕入単価２";
            kakoShiireTanka2.Name = "加工仕入単価２";
            kakoShiireTanka2.HeaderText = "加工仕入単価２";
            kakoShiireTanka2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin2 = new DataGridViewTextBoxColumn();
            kakoShiireKin2.DataPropertyName = "加工仕入金額２";
            kakoShiireKin2.Name = "加工仕入金額２";
            kakoShiireKin2.HeaderText = "加工仕入金額２";
            kakoShiireKin2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari2 = new DataGridViewTextBoxColumn();
            kakoShiireArari2.DataPropertyName = "加工粗利２";
            kakoShiireArari2.Name = "加工粗利２";
            kakoShiireArari2.HeaderText = "加工粗利２";
            kakoShiireArari2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu2 = new DataGridViewTextBoxColumn();
            kakoShiireArariritsu2.DataPropertyName = "加工粗利率２";
            kakoShiireArariritsu2.Name = "加工粗利率２";
            kakoShiireArariritsu2.HeaderText = "加工粗利率２";
            kakoShiireArariritsu2.Visible = false;

            DataGridViewTextBoxColumn kakoShiireCd3 = new DataGridViewTextBoxColumn();
            kakoShiireCd3.DataPropertyName = "加工仕入先コード３";
            kakoShiireCd3.Name = "加工仕入先コード３";
            kakoShiireCd3.HeaderText = "加工仕入先コード３";
            kakoShiireCd3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName3 = new DataGridViewTextBoxColumn();
            kakoShiireName3.DataPropertyName = "加工仕入先名３";
            kakoShiireName3.Name = "加工仕入先名３";
            kakoShiireName3.HeaderText = "加工仕入先名３";
            kakoShiireName3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka3 = new DataGridViewTextBoxColumn();
            kakoShiireTanka3.DataPropertyName = "加工仕入単価３";
            kakoShiireTanka3.Name = "加工仕入単価３";
            kakoShiireTanka3.HeaderText = "加工仕入単価３";
            kakoShiireTanka3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin3 = new DataGridViewTextBoxColumn();
            kakoShiireKin3.DataPropertyName = "加工仕入金額３";
            kakoShiireKin3.Name = "加工仕入金額３";
            kakoShiireKin3.HeaderText = "加工仕入金額３";
            kakoShiireKin3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari3 = new DataGridViewTextBoxColumn();
            kakoShiireArari3.DataPropertyName = "加工粗利３";
            kakoShiireArari3.Name = "加工粗利３";
            kakoShiireArari3.HeaderText = "加工粗利３";
            kakoShiireArari3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu3 = new DataGridViewTextBoxColumn();
            kakoShiireArariritsu3.DataPropertyName = "加工粗利率３";
            kakoShiireArariritsu3.Name = "加工粗利率３";
            kakoShiireArariritsu3.HeaderText = "加工粗利率３";
            kakoShiireArariritsu3.Visible = false;

            DataGridViewTextBoxColumn kakoShiireCd4 = new DataGridViewTextBoxColumn();
            kakoShiireCd4.DataPropertyName = "加工仕入先コード４";
            kakoShiireCd4.Name = "加工仕入先コード４";
            kakoShiireCd4.HeaderText = "加工仕入先コード４";
            kakoShiireCd4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName4 = new DataGridViewTextBoxColumn();
            kakoShiireName4.DataPropertyName = "加工仕入先名４";
            kakoShiireName4.Name = "加工仕入先名４";
            kakoShiireName4.HeaderText = "加工仕入先名４";
            kakoShiireName4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka4 = new DataGridViewTextBoxColumn();
            kakoShiireTanka4.DataPropertyName = "加工仕入単価４";
            kakoShiireTanka4.Name = "加工仕入単価４";
            kakoShiireTanka4.HeaderText = "加工仕入単価４";
            kakoShiireTanka4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin4 = new DataGridViewTextBoxColumn();
            kakoShiireKin4.DataPropertyName = "加工仕入金額４";
            kakoShiireKin4.Name = "加工仕入金額４";
            kakoShiireKin4.HeaderText = "加工仕入金額４";
            kakoShiireKin4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari4 = new DataGridViewTextBoxColumn();
            kakoShiireArari4.DataPropertyName = "加工粗利４";
            kakoShiireArari4.Name = "加工粗利４";
            kakoShiireArari4.HeaderText = "加工粗利４";
            kakoShiireArari4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu4 = new DataGridViewTextBoxColumn();
            kakoShiireArariritsu4.DataPropertyName = "加工粗利率４";
            kakoShiireArariritsu4.Name = "加工粗利率４";
            kakoShiireArariritsu4.HeaderText = "加工粗利率４";
            kakoShiireArariritsu4.Visible = false;

            DataGridViewTextBoxColumn kakoShiireCd5 = new DataGridViewTextBoxColumn();
            kakoShiireCd5.DataPropertyName = "加工仕入先コード５";
            kakoShiireCd5.Name = "加工仕入先コード５";
            kakoShiireCd5.HeaderText = "加工仕入先コード５";
            kakoShiireCd5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName5 = new DataGridViewTextBoxColumn();
            kakoShiireName5.DataPropertyName = "加工仕入先名５";
            kakoShiireName5.Name = "加工仕入先名５";
            kakoShiireName5.HeaderText = "加工仕入先名５";
            kakoShiireName5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka5 = new DataGridViewTextBoxColumn();
            kakoShiireTanka5.DataPropertyName = "加工仕入単価５";
            kakoShiireTanka5.Name = "加工仕入単価５";
            kakoShiireTanka5.HeaderText = "加工仕入単価５";
            kakoShiireTanka5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin5 = new DataGridViewTextBoxColumn();
            kakoShiireKin5.DataPropertyName = "加工仕入金額５";
            kakoShiireKin5.Name = "加工仕入金額５";
            kakoShiireKin5.HeaderText = "加工仕入金額５";
            kakoShiireKin5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari5 = new DataGridViewTextBoxColumn();
            kakoShiireArari5.DataPropertyName = "加工粗利５";
            kakoShiireArari5.Name = "加工粗利５";
            kakoShiireArari5.HeaderText = "加工粗利５";
            kakoShiireArari5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu5 = new DataGridViewTextBoxColumn();
            kakoShiireArariritsu5.DataPropertyName = "加工粗利率５";
            kakoShiireArariritsu5.Name = "加工粗利率５";
            kakoShiireArariritsu5.HeaderText = "加工粗利率５";
            kakoShiireArariritsu5.Visible = false;

            DataGridViewTextBoxColumn kakoShiireCd6 = new DataGridViewTextBoxColumn();
            kakoShiireCd6.DataPropertyName = "加工仕入先コード６";
            kakoShiireCd6.Name = "加工仕入先コード６";
            kakoShiireCd6.HeaderText = "加工仕入先コード６";
            kakoShiireCd6.Visible = false;

            DataGridViewTextBoxColumn kakoShiireName6 = new DataGridViewTextBoxColumn();
            kakoShiireName6.DataPropertyName = "加工仕入先名６";
            kakoShiireName6.Name = "加工仕入先名６";
            kakoShiireName6.HeaderText = "加工仕入先名６";
            kakoShiireName6.Visible = false;

            DataGridViewTextBoxColumn kakoShiireTanka6 = new DataGridViewTextBoxColumn();
            kakoShiireTanka6.DataPropertyName = "加工仕入単価６";
            kakoShiireTanka6.Name = "加工仕入単価６";
            kakoShiireTanka6.HeaderText = "加工仕入単価６";
            kakoShiireTanka6.Visible = false;

            DataGridViewTextBoxColumn kakoShiireKin6 = new DataGridViewTextBoxColumn();
            kakoShiireKin6.DataPropertyName = "加工仕入金額６";
            kakoShiireKin6.Name = "加工仕入金額６";
            kakoShiireKin6.HeaderText = "加工仕入金額６";
            kakoShiireKin6.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArari6 = new DataGridViewTextBoxColumn();
            kakoShiireArari6.DataPropertyName = "加工粗利６";
            kakoShiireArari6.Name = "加工粗利６";
            kakoShiireArari6.HeaderText = "加工粗利６";
            kakoShiireArari6.Visible = false;

            DataGridViewTextBoxColumn kakoShiireArariritsu6 = new DataGridViewTextBoxColumn();
            kakoShiireArariritsu6.DataPropertyName = "加工粗利率６";
            kakoShiireArariritsu6.Name = "加工粗利率６";
            kakoShiireArariritsu6.HeaderText = "加工粗利率６";
            kakoShiireArariritsu6.Visible = false;
            #endregion

            #region
            DataGridViewTextBoxColumn daibunrui = new DataGridViewTextBoxColumn();
            daibunrui.DataPropertyName = "大分類";
            daibunrui.Name = "大分類";
            daibunrui.HeaderText = "大分類";
            daibunrui.Visible = false;

            DataGridViewTextBoxColumn chubunrui = new DataGridViewTextBoxColumn();
            chubunrui.DataPropertyName = "中分類";
            chubunrui.Name = "中分類";
            chubunrui.HeaderText = "中分類";
            chubunrui.Visible = false;

            DataGridViewTextBoxColumn maker = new DataGridViewTextBoxColumn();
            maker.DataPropertyName = "メーカー";
            maker.Name = "メーカー";
            maker.HeaderText = "メーカー";
            maker.Visible = false;

            DataGridViewTextBoxColumn teika1 = new DataGridViewTextBoxColumn();
            teika1.DataPropertyName = "定価1";
            teika1.Name = "定価1";
            teika1.HeaderText = "定価1";
            teika1.ReadOnly = true;

            DataGridViewTextBoxColumn teika2 = new DataGridViewTextBoxColumn();
            teika2.DataPropertyName = "定価2";
            teika2.Name = "定価2";
            teika2.HeaderText = "定価2";
            teika2.ReadOnly = true;

            DataGridViewTextBoxColumn teika3 = new DataGridViewTextBoxColumn();
            teika3.DataPropertyName = "定価3";
            teika3.Name = "定価3";
            teika3.HeaderText = "定価3";
            teika3.ReadOnly = true;
            #endregion


            #endregion

            //バインド、個々の幅、文章の寄せの設定
            #region
            setColumn(gridMitsmori, txtRowNum, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, null, 36);
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

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIdx = e.RowIndex;
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

            if (cellValueChecker(88, rowIdx))
            {
                txtZaiTeika1.Text = gridMitsmori[88, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTeika1.Text = "";
            }
            if (cellValueChecker(89, rowIdx))
            {
                txtZaiTeika2.Text = gridMitsmori[89, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTeika2.Text = "";
            }
            if (cellValueChecker(90, rowIdx))
            {
                txtZaiTeika3.Text = gridMitsmori[90, rowIdx].Value.ToString();
            }
            else
            {
                txtZaiTeika3.Text = "";
            }

            //if (cellValueChecker(4, rowIdx))
            //{
            //    if (isNotNullBlank(txtZaiCd1.Text)) {
            //        txtZaiTeika1.Text = dataGridView2[4, rowIdx].Value.ToString();
            //    } else
            //    {
            //        txtZaiTeika1.Text = "";
            //    }
            //    if (isNotNullBlank(txtZaiCd2.Text))
            //    {
            //        txtZaiTeika2.Text = dataGridView2[4, rowIdx].Value.ToString();
            //    }
            //    else
            //    {
            //        txtZaiTeika2.Text = "";
            //    }
            //    if (isNotNullBlank(txtZaiCd3.Text))
            //    {
            //        txtZaiTeika3.Text = dataGridView2[4, rowIdx].Value.ToString();
            //    }
            //    else
            //    {
            //        txtZaiTeika3.Text = "";
            //    }
            //    if (isNotNullBlank(txtZaiCd4.Text))
            //    {
            //        txtZaiTeika4.Text = dataGridView2[4, rowIdx].Value.ToString();
            //    }
            //    else
            //    {
            //        txtZaiTeika4.Text = "";
            //    }
            //    if (isNotNullBlank(txtZaiCd5.Text))
            //    {
            //        txtZaiTeika5.Text = dataGridView2[4, rowIdx].Value.ToString();
            //    }
            //    else
            //    {
            //        txtZaiTeika5.Text = "";
            //    }
            //    if (isNotNullBlank(txtZaiCd6.Text))
            //    {
            //        txtZaiTeika6.Text = dataGridView2[4, rowIdx].Value.ToString();
            //    }
            //    else
            //    {
            //        txtZaiTeika6.Text = "";
            //    }
            //}
            //else
            //{
            //    txtZaiTeika1.Text = "";
            //    txtZaiTeika2.Text = "";
            //    txtZaiTeika3.Text = "";
            //    txtZaiTeika4.Text = "";
            //    txtZaiTeika5.Text = "";
            //    txtZaiTeika6.Text = "";
            //}

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

        private void dataGridView2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                txtZaiCd1.Focus();
            }
        }

        private void textBox25_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                int rowIdx = gridMitsmori.CurrentCell.RowIndex;

                if (isNotNullBlank(txtZaiTeika2.Text) && isNotNullBlank(txtZaiTnk2.Text) && isNotNullBlank(txtArr2.Text) && isNotNullBlank(txtSrrt2.Text) && isNotNullBlank(txtZaiMei2.Text))
                {
                    decimal d = decimal.Parse(txtZaiTeika2.Text);
                    txtZaiTeika2.Text = d.ToString("#,0");

                    //dataGridView2[6, rowIdx].Value = textBox22.Text;
                    gridMitsmori[8, rowIdx].Value = txtZaiTnk2.Text;
                    gridMitsmori[9, rowIdx].Value = txtArr2.Text;
                    gridMitsmori[10, rowIdx].Value = txtSrrt2.Text;
                    gridMitsmori[12, rowIdx].Value = txtZaiMei2.Text;

                    gridMitsmori[88, rowIdx].Value = txtZaiTeika1.Text;
                    gridMitsmori[89, rowIdx].Value = txtZaiTeika2.Text;
                    gridMitsmori[90, rowIdx].Value = txtZaiTeika3.Text;
                    gridMitsmori[4, rowIdx].Value = txtZaiTeika2.Text;

                    setKak(rowIdx);

                    changeTotal();
                }

                gridMitsmori.Focus();

            }

        }

        private void textBox13_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                int rowIdx = gridMitsmori.CurrentCell.RowIndex;

                if (isNotNullBlank(txtZaiTeika1.Text) && isNotNullBlank(txtZaiTnk1.Text) && isNotNullBlank(txtArr1.Text) && isNotNullBlank(txtSrrt1.Text) && isNotNullBlank(txtZaiMei1.Text))
                {
                    decimal d = decimal.Parse(txtZaiTeika1.Text);
                    txtZaiTeika1.Text = d.ToString("#,0");

                    //dataGridView2[6, rowIdx].Value = textBox17.Text;
                    gridMitsmori[8, rowIdx].Value = txtZaiTnk1.Text;
                    gridMitsmori[9, rowIdx].Value = txtArr1.Text;
                    gridMitsmori[10, rowIdx].Value = txtSrrt1.Text;
                    gridMitsmori[12, rowIdx].Value = txtZaiMei1.Text;

                    gridMitsmori[88, rowIdx].Value = txtZaiTeika1.Text;
                    gridMitsmori[89, rowIdx].Value = txtZaiTeika2.Text;
                    gridMitsmori[90, rowIdx].Value = txtZaiTeika3.Text;
                    gridMitsmori[4, rowIdx].Value = txtZaiTeika1.Text;

                    setKak(rowIdx);

                    changeTotal();
                }

                gridMitsmori.Focus();
            }
        }

        private void textBox32_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                int rowIdx = gridMitsmori.CurrentCell.RowIndex;

                if (isNotNullBlank(txtZaiTeika3.Text) && isNotNullBlank(txtZaiTnk3.Text) && isNotNullBlank(txtArr3.Text) && isNotNullBlank(txtSrrt3.Text) && isNotNullBlank(txtZaiMei3.Text))
                {
                    decimal d = decimal.Parse(txtZaiTeika3.Text);
                    txtZaiTeika3.Text = d.ToString("#,0");

                    //dataGridView2[6, rowIdx].Value = textBox29.Text;
                    gridMitsmori[8, rowIdx].Value = txtZaiTnk3.Text;
                    gridMitsmori[9, rowIdx].Value = txtArr3.Text;
                    gridMitsmori[10, rowIdx].Value = txtSrrt3.Text;
                    gridMitsmori[12, rowIdx].Value = txtZaiMei3.Text;

                    gridMitsmori[88, rowIdx].Value = txtZaiTeika1.Text;
                    gridMitsmori[89, rowIdx].Value = txtZaiTeika2.Text;
                    gridMitsmori[90, rowIdx].Value = txtZaiTeika3.Text;
                    gridMitsmori[4, rowIdx].Value = txtZaiTeika3.Text;

                    setKak(rowIdx);

                    changeTotal();
                }

                gridMitsmori.Focus();
            }
        }

        private void changeTotal()
        {
            //int i = int.Parse(dataGridView2[6, 0].Value.ToString(), System.Globalization.NumberStyles.AllowThousands)
            //    + int.Parse(dataGridView2[6, 1].Value.ToString(), System.Globalization.NumberStyles.AllowThousands)
            //    + int.Parse(dataGridView2[6, 2].Value.ToString(), System.Globalization.NumberStyles.AllowThousands)
            //    + int.Parse(dataGridView2[6, 3].Value.ToString(), System.Globalization.NumberStyles.AllowThousands)
            //    + int.Parse(dataGridView2[6, 4].Value.ToString(), System.Globalization.NumberStyles.AllowThousands);
            //textBox34.Text = String.Format("{0:#,0}", i);
            Decimal d = decimal.Parse(gridMitsmori[8, 0].Value.ToString(), System.Globalization.NumberStyles.Number) * decimal.Parse(gridMitsmori[3, 0].Value.ToString(), System.Globalization.NumberStyles.Number)
                    + decimal.Parse(gridMitsmori[8, 1].Value.ToString(), System.Globalization.NumberStyles.Number) * decimal.Parse(gridMitsmori[3, 1].Value.ToString(), System.Globalization.NumberStyles.Number)
                    + decimal.Parse(gridMitsmori[8, 2].Value.ToString(), System.Globalization.NumberStyles.Number) * decimal.Parse(gridMitsmori[3, 2].Value.ToString(), System.Globalization.NumberStyles.Number)
                    + decimal.Parse(gridMitsmori[8, 3].Value.ToString(), System.Globalization.NumberStyles.Number) * decimal.Parse(gridMitsmori[3, 3].Value.ToString(), System.Globalization.NumberStyles.Number)
                    + decimal.Parse(gridMitsmori[8, 4].Value.ToString(), System.Globalization.NumberStyles.Number) * decimal.Parse(gridMitsmori[3, 4].Value.ToString(), System.Globalization.NumberStyles.Number);
            textBox34.Text = String.Format("{0:#,0}", d);

            d = decimal.Parse(textBox35.Text, System.Globalization.NumberStyles.Number)
                - decimal.Parse(textBox34.Text, System.Globalization.NumberStyles.Number);
            textBox36.Text = String.Format("{0:#,0}", d);

            d = Decimal.Round(decimal.Parse(textBox36.Text, System.Globalization.NumberStyles.AllowThousands)
               / decimal.Parse(textBox35.Text, System.Globalization.NumberStyles.AllowThousands) * 100, 2, MidpointRounding.AwayFromZero);
            textBox37.Text = String.Format("{0:#,0}", d);


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
        }

        private void calc1(int rowIdx)
        {
            if (cellValueChecker(88, rowIdx))
            {
                Decimal d1 = decimal.Parse(gridMitsmori[88, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                Decimal d2 = 0;

                if (isNotNullBlank(txtZaiTnk1.Text))
                {
                    d2 = decimal.Parse(txtZaiTnk1.Text, System.Globalization.NumberStyles.Number);
                }

                txtZaiRit1.Text = (Decimal.Round(decimal.Divide(d2, d1) * 100, 1)).ToString();

                d2 = 0;

                //if (isNotNullBlank(txtKakTnk1.Text))
                //{
                //    d2 = decimal.Parse(txtKakTnk1.Text, System.Globalization.NumberStyles.Number);
                //}

                //txtKakRit1.Text = (Decimal.Round(decimal.Divide(d2, d1) * 100, 1)).ToString();

            }
            else
            {
                //txtKakRit1.Text = "";
            }

            if (cellValueChecker(3, rowIdx))
            {
                decimal d1 = 0;
                decimal d2 = 0;
                decimal d3 = 0;
                decimal d4 = 0;
                decimal dt = 0;
                if (cellValueChecker(5, rowIdx))
                {
                    if (txtZaiTnk1.Text != null && txtZaiTnk1.Text != "")
                    {
                        d1 = decimal.Parse(txtZaiTnk1.Text, System.Globalization.NumberStyles.Number);
                    }
                    if (txtKakTnk1.Text != null && txtKakTnk1.Text != "")
                    {
                        d2 = decimal.Parse(txtKakTnk1.Text, System.Globalization.NumberStyles.Number);
                    }

                    d3 = Decimal.Parse(gridMitsmori[5, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    d4 = Decimal.Parse(gridMitsmori[3, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    dt = Decimal.Multiply(d3, d4) - (Decimal.Multiply(d1, d4) + Decimal.Multiply(d2, d4));
                    txtArr1.Text = dt.ToString("#,0");
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

            if (txtArr1.Text != "")
            {
                if (cellValueChecker(5, rowIdx))
                {
                    decimal d1 = decimal.Parse(txtArr1.Text, System.Globalization.NumberStyles.Number);
                    decimal d2 = decimal.Parse(gridMitsmori[3, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    decimal d3 = 0;
                    d3 = decimal.Parse(gridMitsmori[5, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    decimal dx = Decimal.Round(decimal.Divide(d1, (d2 * d3)) * 100, 1);
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
            if (cellValueChecker(89, rowIdx))
            {
                Decimal d1 = decimal.Parse(gridMitsmori[89, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                Decimal d2 = 0;

                if (isNotNullBlank(txtZaiTnk2.Text))
                {
                    d2 = decimal.Parse(txtZaiTnk2.Text, System.Globalization.NumberStyles.Number);
                }

                txtZaiRit2.Text = (Decimal.Round(decimal.Divide(d2, d1) * 100, 1)).ToString();

                d2 = 0;
            }
            else
            {
                //txtKakRit2.Text = "";
            }

            if (cellValueChecker(3, rowIdx))
            {
                decimal d1 = 0;
                decimal d2 = 0;
                decimal d3 = 0;
                decimal d4 = 0;
                decimal dt = 0;
                if (cellValueChecker(5, rowIdx))
                {
                    if (txtZaiTnk2.Text != null && txtZaiTnk2.Text != "")
                    {
                        d1 = decimal.Parse(txtZaiTnk2.Text, System.Globalization.NumberStyles.Number);
                    }
                    if (txtKakTnk2.Text != null && txtKakTnk2.Text != "")
                    {
                        d2 = decimal.Parse(txtKakTnk2.Text, System.Globalization.NumberStyles.Number);
                    }

                    d3 = Decimal.Parse(gridMitsmori[5, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    d4 = Decimal.Parse(gridMitsmori[3, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    dt = Decimal.Multiply(d3, d4) - (Decimal.Multiply(d1, d4) + Decimal.Multiply(d2, d4));
                    txtArr2.Text = dt.ToString("#,0");
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

            if (txtArr2.Text != "")
            {
                if (cellValueChecker(5, rowIdx))
                {
                    decimal d1 = decimal.Parse(txtArr2.Text, System.Globalization.NumberStyles.Number);
                    decimal d2 = decimal.Parse(gridMitsmori[3, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    decimal d3 = 0;
                    d3 = decimal.Parse(gridMitsmori[5, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    decimal dx = Decimal.Round(decimal.Divide(d1, (d2 * d3)) * 100, 1);
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
            if (cellValueChecker(90, rowIdx))
            {
                Decimal d1 = decimal.Parse(gridMitsmori[90, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                Decimal d2 = 0;

                if (isNotNullBlank(txtZaiTnk3.Text))
                {
                    d2 = decimal.Parse(txtZaiTnk3.Text, System.Globalization.NumberStyles.Number);
                }

                txtZaiRit3.Text = (Decimal.Round(decimal.Divide(d2, d1) * 100, 1)).ToString();

                d2 = 0;

                //if (isNotNullBlank(txtKakTnk3.Text))
                //{
                //    d2 = decimal.Parse(txtKakTnk3.Text, System.Globalization.NumberStyles.Number);
                //}

                //txtKakRit3.Text = (Decimal.Round(decimal.Divide(d2, d1) * 100, 1)).ToString();

            }
            else
            {
                //txtKakRit3.Text = "";
            }

            if (cellValueChecker(3, rowIdx))
            {
                decimal d1 = 0;
                decimal d2 = 0;
                decimal d3 = 0;
                decimal d4 = 0;
                decimal dt = 0;
                if (cellValueChecker(5, rowIdx))
                {
                    if (txtZaiTnk3.Text != null && txtZaiTnk3.Text != "")
                    {
                        d1 = decimal.Parse(txtZaiTnk3.Text, System.Globalization.NumberStyles.Number);
                    }
                    if (txtKakTnk3.Text != null && txtKakTnk3.Text != "")
                    {
                        d2 = decimal.Parse(txtKakTnk3.Text, System.Globalization.NumberStyles.Number);
                    }

                    d3 = Decimal.Parse(gridMitsmori[5, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    d4 = Decimal.Parse(gridMitsmori[3, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    dt = Decimal.Multiply(d3, d4) - (Decimal.Multiply(d1, d4) + Decimal.Multiply(d2, d4));
                    txtArr3.Text = dt.ToString("#,0");
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

            if (txtArr3.Text != "")
            {
                if (cellValueChecker(5, rowIdx))
                {
                    decimal d1 = decimal.Parse(txtArr3.Text, System.Globalization.NumberStyles.Number);
                    decimal d2 = decimal.Parse(gridMitsmori[3, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    decimal d3 = 0;
                    d3 = decimal.Parse(gridMitsmori[5, rowIdx].Value.ToString(), System.Globalization.NumberStyles.Number);
                    decimal dx = Decimal.Round(decimal.Divide(d1, (d2 * d3)) * 100, 1);
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

            calc1(int.Parse(txtIdx.Text));
            calc2(int.Parse(txtIdx.Text));
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

            calc2(int.Parse(txtIdx.Text));
            calc3(int.Parse(txtIdx.Text));
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
                decimal d = decimal.Parse(txtZaiTeika1.Text);
                txtZaiTeika1.Text = d.ToString("#,0");
                gridMitsmori[88, int.Parse(txtIdx.Text)].Value = txtZaiTeika1.Text;
                calc1(int.Parse(txtIdx.Text));
            }
        }

        private void txtZaiTeika2_Leave(object sender, EventArgs e)
        {
            if (isNotNullBlank(txtZaiTeika2.Text))
            {
                decimal d = decimal.Parse(txtZaiTeika2.Text);
                txtZaiTeika2.Text = d.ToString("#,0");
                gridMitsmori[89, int.Parse(txtIdx.Text)].Value = txtZaiTeika2.Text;
                calc2(int.Parse(txtIdx.Text));
            }
        }

        private void txtZaiTeika3_Leave(object sender, EventArgs e)
        {
            if (isNotNullBlank(txtZaiTeika3.Text))
            {
                decimal d = decimal.Parse(txtZaiTeika3.Text);
                txtZaiTeika3.Text = d.ToString("#,0");
                gridMitsmori[90, int.Parse(txtIdx.Text)].Value = txtZaiTeika3.Text;
                calc3(int.Parse(txtIdx.Text));
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
            {
                return;
            }
            if (e.RowIndex >= 0 && cellValueChecker(2, e.RowIndex))
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

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
            {
                return;
            }
            if (e.RowIndex >= 0 && cellValueChecker(2, e.RowIndex))
            {
                String val = (gridMitsmori[2, e.RowIndex].Value).ToString();
                if (val == null || val.Equals(""))
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

            return true;
        }
    }
}
