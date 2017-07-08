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
using KATO.Common.Util;
using KATO.Common.Form;
using static KATO.Common.Util.CommonTeisu;
using KATO.Business.A0090_SiireCheakPrint;

namespace KATO.Form.A0090_SiireCheakPrint
{
    /// <summary>
    /// A0090_SiireCheakPrint
    /// 仕入チェックリストフォーム
    /// 作成者：多田
    /// 作成日：2017/7/1
    /// 更新者：多田
    /// 更新日：2017/7/1
    /// カラム論理名
    /// </summary>
    public partial class A0090_SiireCheakPrint : BaseForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// A0090_SiireCheakPrint
        /// フォーム関係の設定
        /// </summary>
        public A0090_SiireCheakPrint(Control c)
        {
            if (c == null)
            {
                return;
            }

            int intWindowWidth = c.Width;
            int intWindowHeight = c.Height;

            InitializeComponent();

            // フォームが最大化されないようにする
            this.MaximizeBox = false;
            // フォームが最小化されないようにする
            this.MinimizeBox = false;

            // 最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            // ウィンドウ位置をマニュアル
            this.StartPosition = FormStartPosition.Manual;
            // 親画面の中央を指定
            this.Left = c.Left + (intWindowWidth - this.Width) / 2;
            this.Top = c.Top + (intWindowHeight - this.Height) / 2;
        }

        /// <summary>
        /// A0090_SiireCheakPrint_Load
        /// 読み込み時
        /// </summary>
        private void A0090_SiireCheakPrint_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "仕入チェックリスト";

            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;

            this.btnF04.Text = STR_FUNC_F4;
            this.btnF11.Text = STR_FUNC_F11;
            this.btnF12.Text = STR_FUNC_F12;

            // 初期表示
            txtUserId.Focus();

            // ユーザーIDの設定
            txtUserId.Text = Environment.UserName;

            // 入力年月日の設定
            txtInputYMDStart.setUp(0);
            txtInputYMDEnd.setUp(0);

            // 伝票年月日の設定
            txtDenpyoYMDStart.setUp(1);
            txtDenpyoYMDEnd.setUp(2);

            //Option3(1).Value = True

        }

        /// <summary>
        /// A0090_SiireCheakPrint_KeyDown
        /// キー入力判定
        /// </summary>
        private void A0090_SiireCheakPrint_KeyDown(object sender, KeyEventArgs e)
        {
            // キー入力情報によって動作を変える
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
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
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
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printReport();
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
                case STR_BTN_F04: // 取消
                    logger.Info(LogUtil.getMessage(this._Title, "取消実行"));
                    this.delText();
                    break;
                case STR_BTN_F11: // 印刷
                    logger.Info(LogUtil.getMessage(this._Title, "印刷実行"));
                    this.printReport();
                    break;
                case STR_BTN_F12: // 終了
                    logger.Info(LogUtil.getMessage(this._Title, "終了実行"));
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// delText
        /// テキストボックス内の文字を削除
        /// </summary>
        private void delText()
        {
            // 入力年月日の設定
            txtInputYMDStart.setUp(0);
            txtInputYMDEnd.setUp(0);

            // 伝票年月日の設定
            txtDenpyoYMDStart.setUp(0);
            txtDenpyoYMDEnd.setUp(0);

            labelSet_SiiresakiCdFrom.CodeTxtText = "";
            labelSet_SiiresakiCdTo.CodeTxtText = "";

            txtInputYMDStart.Focus();
        }


        /// <summary>
        /// printReport
        /// PDFを出力する
        /// </summary>
        private void printReport()
        {

            // 【印刷用ダイアログ】

            // データ検索用
            List<string> lstSearchItem = new List<string>();

            // 空文字判定（入力年月日（開始・終了）、伝票年月日（開始・終了））
            if (txtInputYMDStart.blIsEmpty() == false || txtInputYMDEnd.blIsEmpty() == false ||
                txtDenpyoYMDStart.blIsEmpty() == false || txtDenpyoYMDEnd.blIsEmpty() == false)
            {
                // メッセージボックスの処理、項目が空の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_NULL, CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();
                return;
            }

            // ビジネス層のインスタンス生成
            A0090_SiireCheakPrint_B cheakPrintB = new A0090_SiireCheakPrint_B();
            try
            {
                // 検索するデータをリストに格納
                lstSearchItem.Add(txtInputYMDStart.Text);
                lstSearchItem.Add(txtInputYMDEnd.Text);
                lstSearchItem.Add(txtDenpyoYMDStart.Text);
                lstSearchItem.Add(txtDenpyoYMDEnd.Text);
                lstSearchItem.Add(txtUserId.Text);
                lstSearchItem.Add(labelSet_SiiresakiCdFrom.CodeTxtText);
                lstSearchItem.Add(labelSet_SiiresakiCdTo.CodeTxtText);

                // 検索実行
                DataTable dtSiireCheakList = cheakPrintB.getSiireCheakList(lstSearchItem);
                
                if (dtSiireCheakList.Rows.Count > 0)
                {
                    // PDF作成
                    cheakPrintB.dbToPdf(dtSiireCheakList, lstSearchItem);

                    // PDF出力完了メッセージ
                    MessageBox.Show(this, "PDF出力完了");
                }
                else
                {
                    // メッセージボックスの処理、対象データがない場合のウィンドウ（OK）
                    BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "対象のデータはありません。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                    basemessagebox.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                // エラーロギング
                new CommonException(ex);

                // メッセージボックスの処理、PDF作成失敗の場合のウィンドウ（OK）
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_VIEW, "印刷が失敗しました。", CommonTeisu.BTN_OK, CommonTeisu.DIAG_ERROR);
                basemessagebox.ShowDialog();

                return;
            }

        }

    }
}
