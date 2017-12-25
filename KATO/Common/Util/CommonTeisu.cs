using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace KATO.Common.Util
{
    class CommonTeisu
    {
        // 全画面共通 タイトル
        public const String STR_TITLE = "{0}";
        //ファンクションキーボタン判定
        public const String STR_FUNC_F1 = "F1:登録";
        public const String STR_FUNC_F2 = "";
        public const String STR_FUNC_F3 = "F3:削除";
        public const String STR_FUNC_F4 = "F4:取消";
        public const String STR_FUNC_F5 = "";
        public const String STR_FUNC_F6 = "";
        public const String STR_FUNC_F7 = "";
        public const String STR_FUNC_F8 = "";
        public const String STR_FUNC_F9 = "F9:検索";
        public const String STR_FUNC_F10 = "";
        public const String STR_FUNC_F11 = "F11:印刷";
        public const String STR_FUNC_F12 = "F12:終了";

        public const String STR_FUNC_F1_KARITOROKU = "F1:仮登録";
        public const String STR_FUNC_F1_HYOJII = "F1:表示";
        public const String STR_FUNC_F8_KARABAN = "F8:空番";
        public const String STR_FUNC_F8_RIREKI = "F8:履歴";
        public const String STR_FUNC_F10_SHOHIN = "F10:棚番無";

        public const String STR_BTN_F01 = "btnF01";
        public const String STR_BTN_F02 = "btnF02";
        public const String STR_BTN_F03 = "btnF03";
        public const String STR_BTN_F04 = "btnF04";
        public const String STR_BTN_F05 = "btnF05";
        public const String STR_BTN_F06 = "btnF06";
        public const String STR_BTN_F07 = "btnF07";
        public const String STR_BTN_F08 = "btnF08";
        public const String STR_BTN_F09 = "btnF09";
        public const String STR_BTN_F10 = "btnF10";
        public const String STR_BTN_F11 = "btnF11";
        public const String STR_BTN_F12 = "btnF12";

        //ウィンドウ判定
        public const int FRM_SHOHINMOTOCHOKAKUNIN = 0380;
        public const int FRM_DAIBUNRUI = 1010;
        public const int FRM_MAKER = 1020;
        public const int FRM_SHOHIN = 1030;
        public const int FRM_SHOHIN_TANA = 10301;
        public const int FRM_SHOUHINLIST = 1031;
        public const int FRM_TORIHIKIKBN = 1040;
        public const int FRM_TANTOUSHA = 1050;
        public const int FRM_GYOSHU = 1060;
        public const int FRM_TORIHIKISAKI = 1070;
        public const int FRM_TOKUISAKI = 10701;
        public const int FRM_EIGYOSHO = 1090;
        public const int FRM_CHOKUSOSAKI = 1100;
        public const int FRM_TANABAN = 1120;
        public const int FRM_SHOHIZEIRITSU = 1130;
        public const int FRM_TANAOROSHI = 0140;
        public const int FRM_TANAOROSHI_EDIT = 01401;
        public const int FRM_CHUBUNRUI = 1110;
        public const int FRM_GROUP = 1200;
        public const int FRM_JUCHUINPUT = 0010;
        public const int FRM_HACHUINPUT = 0100;
        public const int FRM_SHOHINBETSURIEKIRITSUSETTEI = 1210;
        public const int FRM_TOKUTEIMUKESAKITANKA = 1160;
        public const int FRM_SHIREINPUT = 0030;
        public const int FRM_URIAGEINPUT = 0020;
        public const int FRM_TANTOSHABETUDENPYOCOUNT = 6000;
        public const int FRM_MENU = 1500;

        public const int FRM_TEST = 9999;

        //メッセージボックスアイコン
        public const int DIAG_INFOMATION = 0;
        public const int DIAG_ERROR = 1;
        public const int DIAG_EXCLAMATION = 2;
        public const int DIAG_QUESTION = 3;

        //メッセージボックスボタン数
        public const int BTN_ZERO = 0;
        public const int BTN_OK = 1;
        public const int BTN_YESNO = 2;
        public const int BTN_YESNOCANCEL = 3;

        // グループ(ラジオボタン選択値)
        public const int GROUP_RADIO_ALL = 0;
        public const int GROUP_RADIO_KYOUTSU = 1;
        public const int GROUP_RADIO_1 = 2;
        public const int GROUP_RADIO_2 = 3;
        public const int GROUP_RADIO_3 = 4;

        // 印刷
        public const int ACTION_PRINT = 0;
        public const int ACTION_PREVIEW = 1;
        public const int ACTION_CANCEL = 2;
        public const string SIZE_A4 = "a4";
        public const string SIZE_B4 = "b4";
        public const string SIZE_B5 = "b5";
        public const string SIZE_A3 = "a3";
        public const string SIZE_NAGA4 = "naga4";
        public const string SIZE_NAGA3 = "naga3";
        //public static readonly string[] PARAM_A4 = { "297", "210" };
        public static readonly string[] PARAM_A4 = { "842", "595" };
        public static readonly string[] PARAM_B4 = { "1032", "729" };
        public static readonly string[] PARAM_B5 = { "729", "516" };
        public static readonly string[] PARAM_A3 = { "1191", "842" };
        public static readonly string[] PARAM_NAGA4 = { "581", "255" };
        public static readonly string[] PARAM_NAGA3 = { "666", "340" };
        public static Dictionary<String, string[]> paramSize = new Dictionary<string, string[]>()
        {
            {SIZE_A4, PARAM_A4}
           ,{SIZE_B4, PARAM_B4}
           ,{SIZE_B5, PARAM_B5}
           ,{SIZE_A3, PARAM_A3}
           ,{SIZE_NAGA4, PARAM_NAGA4}
           ,{SIZE_NAGA3, PARAM_NAGA3}

        };
        public static bool TATE = true;
        public static bool YOKO = false;
        public static Dictionary<bool, string> muki = new Dictionary<bool, string>()
        {
            {TATE, "縦"}
           ,{YOKO, "横"}
        };



        public static readonly string[] LIST_GROUP =
        {
             ""
            ,"0000"
            ,"0001"
            ,"0002"
            ,"0003"
        };

        //メッセージボックス題名
        public const string TEXT_TOUROKU = "登録";
        public const string TEXT_INPUT = "入力項目";
        public const string TEXT_DEL = "削除";
        public const string TEXT_VIEW = "表示";
        public const string TEXT_TEST = "テスト";
        public const string TEXT_ERROR = "エラー";

        //メッセージボックス内容物
        public const string LABEL_TOUROKU = "正常に登録されました";
        public const string LABEL_TOUROKU_MISS = "登録失敗";
        public const string LABEL_NULL = "項目が空です。文字を入力してください。";
        public const string LABEL_MISS = "入力された文字列が正しくありません。";
        public const string LABEL_MISSNUM = "入力された数値が正しくありません。";
        public const string LABEL_DEL_BEFORE = "表示中のレコードを削除します。よろしいですか。";
        public const string LABEL_DEL_AFTER = "正常に削除されました。";
        public const string LABEL_DATE_ALERT = "入力された日付が正しくありません。";
        public const string LABEL_NOTDATA = "データが見つかりません。";
        public const string LABEL_ZEROORONE = "０か１で指定してください。";
        public const string LABEL_TOUROKU_UWAGAKi = "に上書きしますか？";
        public const string LABEL_HACHU_JUCHUNO_SHUSEI = "受注伝票があります。受注入力で修正してください。";
        public const string LABEL_HACHU_JUCHUNO_JUCHUDEL = "受注伝票より削除処理してください。";
        public const string LABEL_HACHU_JUCHUNO_NOTDEL = "すでに仕入済みです。削除できません。";
        public const string LABEL_HACHU_JUCHURENKEI = "(発注数量＋在庫使用数) が受注数量を超えています。";
        public const string LABEL_HACHU_1111 = "仕入先コード（１１１１）の場合は返品は不可です。";
        public const string LABEL_HACHU_2222 = "仕入先コード（２２２２）の場合は返品は不可です。";

        public const string LABEL_ERROR_MESSAGE = "システムエラーが起きました。管理者に連絡してください。";
        public const string LABEL_TEST_ALERT = "未完成のため表示できません。（テスト）";

        //カレンダーの初期値
        public const int CALENDER_TODAY = 0;
        public const int CALENDER_MONTH_FIRST = 1;
        public const int CALENDER_MONTH_END = 2;

        //禁止文字の選択欄
        public const string NUMBER_ONLY = @"^[0-9]+$";
        public const string az_ONLY = @"^[a-z]+$";
        public const string AZ_ONLY = @"^[A-Z]+$";

        #region テーブル対応のSQLファイル
        // 大分類
        public const string C_SQL_DAIBUNRUI_UPD = "C_SQL_DAIBUNRUI_UPD";
        public const string C_SQL_DAIBUNRUI_DEL = "C_SQL_DAIBUNRUI_DEL";
        // 中分類                                           
        public const string C_SQL_CHUBUNRUI_UPD = "C_SQL_CHUBUNRUI_UPD";
        public const string C_SQL_CHUBUNRUI_DEL = "C_SQL_CHUBUNRUI_DEL";
        // メーカー                                         
        public const string C_SQL_MAKER_UPD = "C_SQL_MAKER_UPD";
        public const string C_SQL_MAKER_DEL = "C_SQL_MAKER_DEL";
        // 商品                                             
        public const string C_SQL_SHOHIN_UPD = "C_SQL_SHOHIN_UPD";
        public const string C_SQL_SHOHIN_DEL = "C_SQL_SHOHIN_DEL";
        // 商品                                             
        public const string C_SQL_SHOHIN_KARI_UPD = "C_SQL_SHOHIN_KARI_UPD";
        // 会社条件                                         
        public const string C_SQL_KAISHAJOKEN_UPD = "C_SQL_KAISHAJOKEN_UPD";
        public const string C_SQL_KAISHAJOKEN_DEL = "C_SQL_KAISHAJOKEN_DEL";
        // 取引区分                                         
        public const string C_SQL_TORIHIKIKBN_UPD = "C_SQL_TORIHIKIKBN_UPD";
        public const string C_SQL_TORIHIKIKBN_DEL = "C_SQL_TORIHIKIKBN_DEL";
        // 担当者                                           
        public const string C_SQL_TANTOSHA_UPD = "C_SQL_TANTOSHA_UPD";
        public const string C_SQL_TANTOSHA_DEL = "C_SQL_TANTOSHA_DEL";
        // 業種                                             
        public const string C_SQL_GYOSHU_UPD = "C_SQL_GYOSHU_UPD";
        public const string C_SQL_GYOSHU_DEL = "C_SQL_GYOSHU_DEL";
        // 取引先                                           
        public const string C_SQL_TORIHIKISAKI_UPD = "C_SQL_TORIHIKISAKI_UPD";
        public const string C_SQL_TORIHIKISAKI_DEL = "C_SQL_TORIHIKISAKI_DEL";
        // 営業所                                           
        public const string C_SQL_EIGYOSHO_UPD = "C_SQL_EIGYOSHO_UPD";
        public const string C_SQL_EIGYOSHO_DEL = "C_SQL_EIGYOSHO_DEL";
        // 直送先                                           
        public const string C_SQL_CHOKUSOSAKI_UPD = "C_SQL_CHOKUSOSAKI_UPD";
        public const string C_SQL_CHOKUSOSAKI_DEL = "C_SQL_CHOKUSOSAKI_DEL";
        // 棚番                                             
        public const string C_SQL_TANABAN_UPD = "C_SQL_TANABAN_UPD";
        public const string C_SQL_TANABAN_DEL = "C_SQL_TANABAN_DEL";
        // 消費税率                                         
        public const string C_SQL_SHOHIZEIRITSU_UPD = "C_SQL_SHOHIZEIRITSU_UPD";
        public const string C_SQL_SHOHIZEIRITSU_DEL = "C_SQL_SHOHIZEIRITSU_DEL";
        // 特定向先単価                                     
        public const string C_SQL_TOKUTEIMUKESAKITANKA_UPD = "C_SQL_TOKUTEIMUKESAKITANKA_UPD";
        public const string C_SQL_TOKUTEIMUKESAKITANKA_DEL = "C_SQL_TOKUTEIMUKESAKITANKA_DEL";
        // グループ                                         
        public const string C_SQL_GROUP_UPD = "C_SQL_GROUP_UPD";
        public const string C_SQL_GROUP_DEL = "C_SQL_GROUP_DEL";
        // MO                                               
        public const string C_SQL_MO_UPD = "C_SQL_MO_UPD";
        public const string C_SQL_MO_DEL = "C_SQL_MO_DEL";
        // カレンダー                                       
        public const string C_SQL_CALENDAR_UPD = "C_SQL_CALENDAR_UPD";
        public const string C_SQL_CALENDAR_DEL = "C_SQL_CALENDAR_DEL";
        // マイメニュー                                     
        public const string C_SQL_MYMENU_UPD = "C_SQL_MYMENU_UPD";
        public const string C_SQL_MYMENU_DEL = "C_SQL_MYMENU_DEL";
        // メニュー                                         
        public const string C_SQL_MENU_UPD = "C_SQL_MENU_UPD";
        public const string C_SQL_MENU_DEL = "C_SQL_MENU_DEL";
        // メニュー権限                                     
        public const string C_SQL_MENUKENGEN_UPD = "C_SQL_MENUKENGEN_UPD";
        public const string C_SQL_MENUKENGEN_DEL = "C_SQL_MENUKENGEN_DEL";
        // 印刷設定                                         
        public const string C_SQL_INSATSUSETTEI_UPD = "C_SQL_INSATSUSETTEI_UPD";
        public const string C_SQL_INSATSUSETTEI_DEL = "C_SQL_INSATSUSETTEI_DEL";
        // 運賃                                             
        public const string C_SQL_UNCHIN_UPD = "C_SQL_UNCHIN_UPD";
        public const string C_SQL_UNCHIN_DEL = "C_SQL_UNCHIN_DEL";
        // 仮加工                                           
        public const string C_SQL_KARIKAKO_UPD = "C_SQL_KARIKAKO_UPD";
        public const string C_SQL_KARIKAKO_DEL = "C_SQL_KARIKAKO_DEL";
        // 検収済仕入明細                                   
        public const string C_SQL_KENSHUZUMISIIREMEISAI_UPD = "C_SQL_KENSHUZUMISIIREMEISAI_UPD";
        public const string C_SQL_KENSHUZUMISIIREMEISAI_DEL = "C_SQL_KENSHUZUMISIIREMEISAI_DEL";
        // 検収済売上明細
        public const string C_SQL_KENSHUZUMIURIAGEMEISAI_UPD = "C_SQL_KENSHUZUMIURIAGEMEISAI_UPD";
        public const string C_SQL_KENSHUZUMIURIAGEMEISAI_DEL = "C_SQL_KENSHUZUMIURIAGEMEISAI_DEL";
        // 見積ヘッド
        public const string C_SQL_MITSUMORIHEAD_UPD = "C_SQL_MITSUMORIHEAD_UPD";
        public const string C_SQL_MITSUMORIHEAD_DEL = "C_SQL_MITSUMORIHEAD_DEL";
        // 見積明細
        public const string C_SQL_MITSUMORIMEISAI_UPD = "C_SQL_MITSUMORIMEISAI_UPD";
        public const string C_SQL_MITSUMORIMEISAI_DEL = "C_SQL_MITSUMORIMEISAI_DEL";
        // 見積明細カラオケ
        public const string C_SQL_MITSUMORIMEISAIKARAOKE_UPD = "C_SQL_MITSUMORIMEISAIKARAOKE_UPD";
        public const string C_SQL_MITSUMORIMEISAIKARAOKE_DEL = "C_SQL_MITSUMORIMEISAIKARAOKE_DEL";
        // 在庫
        public const string C_SQL_ZAIKO_UPD = "C_SQL_ZAIKO_UPD";
        public const string C_SQL_ZAIKO_DEL = "C_SQL_ZAIKO_DEL";
        // 在庫一覧_移動出数
        public const string C_SQL_ZAIKOIDOUDESU_UPD = "C_SQL_ZAIKOIDOUDESU_UPD";
        public const string C_SQL_ZAIKOIDOUDESU_DEL = "C_SQL_ZAIKOIDOUDESU_DEL";
        // 在庫一覧_移動入数
        public const string C_SQL_ZAIKOIDOUIRISU_UPD = "C_SQL_ZAIKOIDOUIRISU_UPD";
        public const string C_SQL_ZAIKOIDOUIRISU_DEL = "C_SQL_ZAIKOIDOUIRISU_DEL";
        // 在庫一覧_仕入
        public const string C_SQL_ZAIKOSHIRE_UPD = "C_SQL_ZAIKOSHIRE_UPD";
        public const string C_SQL_ZAIKOSHIRE_DEL = "C_SQL_ZAIKOSHIRE_DEL";
        // 在庫一覧_出庫                                  
        public const string C_SQL_ZAIKOSHUKKO_UPD = "C_SQL_ZAIKOSHUKKO_UPD";
        public const string C_SQL_ZAIKOSHUKKO_DEL = "C_SQL_ZAIKOSHUKKO_DEL";
        // 在庫一覧_棚卸調整                              
        public const string C_SQL_ZAIKOTANAOROSHI_UPD = "C_SQL_ZAIKOTANAOROSHI_UPD";
        public const string C_SQL_ZAIKOTANAOROSHI_DEL = "C_SQL_ZAIKOTANAOROSHI_DEL";
        // 在庫一覧_入庫                                  
        public const string C_SQL_ZAIKONYUKO_UPD = "C_SQL_ZAIKONYUKO_UPD";
        public const string C_SQL_ZAIKONYUKO_DEL = "C_SQL_ZAIKONYUKO_DEL";
        // 在庫一覧_売上                                  
        public const string C_SQL_ZAIKOURIAGE_UPD = "C_SQL_ZAIKOURIAGE_UPD";
        public const string C_SQL_ZAIKOURIAGE_DEL = "C_SQL_ZAIKOURIAGE_DEL";
        // 在庫一覧データ
        public const string C_SQL_ZAIKODATA_UPD = "C_SQL_ZAIKODATA_UPD";
        public const string C_SQL_ZAIKODATA_DEL = "C_SQL_ZAIKODATA_DEL";
        // 仕入ヘッダ
        public const string C_SQL_SHIIREHEAD_UPD = "C_SQL_SHIIREHEAD_UPD";
        public const string C_SQL_SHIIREHEAD_DEL = "C_SQL_SHIIREHEAD_DEL";
        // 仕入先
        public const string C_SQL_SHIIRESAKI_UPD = "C_SQL_SHIIRESAKI_UPD";
        public const string C_SQL_SHIIRESAKI_DEL = "C_SQL_SHIIRESAKI_DEL";
        // 仕入明細
        public const string C_SQL_SHIIREMEISAI_UPD = "C_SQL_SHIIREMEISAI_UPD";
        public const string C_SQL_SHIIREMEISAI_DEL = "C_SQL_SHIIREMEISAI_DEL";
        // 支払
        public const string C_SQL_SHIHARAI_UPD = "C_SQL_SHIHARAI_UPD";
        public const string C_SQL_SHIHARAI_DEL = "C_SQL_SHIHARAI_DEL";
        // 取引先コード検索
        public const string C_SQL_TORIHIKISEARCH_UPD = "C_SQL_TORIHIKISEARCH_UPD";
        public const string C_SQL_TORIHIKISEARCH_DEL = "C_SQL_TORIHIKISEARCH_DEL";
        // 取引先経理情報
        public const string C_SQL_TORIHIKISAKIKEIRI_UPD = "C_SQL_TORIHIKISAKIKEIRI_UPD";
        public const string C_SQL_TORIHIKISAKIKEIRI_DEL = "C_SQL_TORIHIKISAKIKEIRI_DEL";
        // 受注
        public const string C_SQL_JUCHU_UPD = "C_SQL_JUCHU_UPD";
        public const string C_SQL_JUCHU_DEL = "C_SQL_JUCHU_DEL";
        // 受注0
        public const string C_SQL_JUCHU0_UPD = "C_SQL_JUCHU0_UPD";
        public const string C_SQL_JUCHU0_DEL = "C_SQL_JUCHU0_DEL";
        // 受注キャンセル
        public const string C_SQL_JUCHUCANCEL_UPD = "C_SQL_JUCHUCANCEL_UPD";
        public const string C_SQL_JUCHUCANCEL_DEL = "C_SQL_JUCHUCANCEL_DEL";
        // 出庫ヘッダ
        public const string C_SQL_SHUKKOHEAD_UPD = "C_SQL_SHUKKOHEAD_UPD";
        public const string C_SQL_SHUKKOHEAD_DEL = "C_SQL_SHUKKOHEAD_DEL";
        // 出庫依頼
        public const string C_SQL_SHUKKOIRAI_UPD = "C_SQL_SHUKKOIRAI_UPD";
        public const string C_SQL_SHUKKOIRAI_DEL = "C_SQL_SHUKKOIRAI_DEL";
        // 出庫明細
        public const string C_SQL_SHUKKOMEISAI_UPD = "C_SQL_SHUKKOMEISAI_UPD";
        public const string C_SQL_SHUKKOMEISAI_DEL = "C_SQL_SHUKKOMEISAI_DEL";
        // 初期設定
        public const string C_SQL_SHOKISETTEI_UPD = "C_SQL_SHOKISETTEI_UPD";
        public const string C_SQL_SHOKISETTEI_DEL = "C_SQL_SHOKISETTEI_DEL";
        // 商品仕入単価履歴
        public const string C_SQL_SHOHINTANKARIREKI_UPD = "C_SQL_SHOHINTANKARIREKI_UPD";
        public const string C_SQL_SHOHINTANKARIREKI_DEL = "C_SQL_SHOHINTANKARIREKI_DEL";
        // 商品仕入単価履歴TMP
        public const string C_SQL_SHOHINTANKARIREKITMP_UPD = "C_SQL_SHOHINTANKARIREKITMP_UPD";
        public const string C_SQL_SHOHINTANKARIREKITMP_DEL = "C_SQL_SHOHINTANKARIREKITMP_DEL";
        // 商品仕入単価履歴TMP2
        public const string C_SQL_SHOHINTANKARIREKITMP2_UPD = "C_SQL_SHOHINTANKARIREKITMP2_UPD";
        public const string C_SQL_SHOHINTANKARIREKITMP2_DEL = "C_SQL_SHOHINTANKARIREKITMP2_DEL";
        // 商品仕入履歴TMP
        public const string C_SQL_SHOHINSHIIRERIREKITMP_UPD = "C_SQL_SHOHINSHIIRERIREKITMP_UPD";
        public const string C_SQL_SHOHINSHIIRERIREKITMP_DEL = "C_SQL_SHOHINSHIIRERIREKITMP_DEL";
        // 商品売上履歴TMP
        public const string C_SQL_SHOHINURIAGERIREKITMP_UPD = "C_SQL_SHOHINURIAGERIREKITMP_UPD";
        public const string C_SQL_SHOHINURIAGERIREKITMP_DEL = "C_SQL_SHOHINURIAGERIREKITMP_DEL";
        // 商品評価単価履歴
        public const string C_SQL_SHOHINHYOKATANKARIREKI_UPD = "C_SQL_SHOHINHYOKATANKARIREKI_UPD";
        public const string C_SQL_SHOHINHYOKATANKARIREKI_DEL = "C_SQL_SHOHINHYOKATANKARIREKI_DEL";
        // 商品分類別利益率
        public const string C_SQL_SHOHINBUNRUIRIEKIRITSU_UPD = "C_SQL_SHOHINBUNRUIRIEKIRITSU_UPD";
        public const string C_SQL_SHOHINBUNRUIRIEKIRITSU_DEL = "C_SQL_SHOHINBUNRUIRIEKIRITSU_DEL";
        // 商品別利益率
        public const string C_SQL_SHOHINBETSURIEKIRITSU_UPD = "C_SQL_SHOHINBETSURIEKIRITSU_UPD";
        public const string C_SQL_SHOHINBETSURIEKIRITSU_DEL = "C_SQL_SHOHINBETSURIEKIRITSU_DEL";
        // 請求履歴
        public const string C_SQL_SEIKYURIREKI_UPD = "C_SQL_SEIKYURIREKI_UPD";
        public const string C_SQL_SEIKYURIREKI_DEL = "C_SQL_SEIKYURIREKI_DEL";
        // 前年仕入実績
        public const string C_SQL_ZENNENSHIIREJISSEKI_UPD = "C_SQL_ZENNENSHIIREJISSEKI_UPD";
        public const string C_SQL_ZENNENSHIIREJISSEKI_DEL = "C_SQL_ZENNENSHIIREJISSEKI_DEL";
        // 前年粗利実績
        public const string C_SQL_ZENNENARARIJISSEKI_UPD = "C_SQL_ZENNENARARIJISSEKI_UPD";
        public const string C_SQL_ZENNENARARIJISSEKI_DEL = "C_SQL_ZENNENARARIJISSEKI_DEL";
        // 前年売上実績
        public const string C_SQL_ZENNENURIAGEJISSEKI_UPD = "C_SQL_ZENNENURIAGEJISSEKI_UPD";
        public const string C_SQL_ZENNENURIAGEJISSEKI_DEL = "C_SQL_ZENNENURIAGEJISSEKI_DEL";
        // 倉庫間移動
        public const string C_SQL_SOKOKANIDOU_UPD = "C_SQL_SOKOKANIDOU_UPD";
        public const string C_SQL_SOKOKANIDOU_DEL = "C_SQL_SOKOKANIDOU_DEL";
        // 棚卸記入表
        public const string C_SQL_TANAOROSHIKINYU_UPD = "C_SQL_TANAOROSHIKINYU_UPD";
        public const string C_SQL_TANAOROSHIKINYU_DEL = "C_SQL_TANAOROSHIKINYU_DEL";
        // 棚卸計算_移動出数
        public const string C_SQL_TANAOROSHIKEISANDESU_UPD = "C_SQL_TANAOROSHIKEISANDESU_UPD";
        public const string C_SQL_TANAOROSHIKEISANDESU_DEL = "C_SQL_TANAOROSHIKEISANDESU_DEL";
        // 棚卸計算_移動入数
        public const string C_SQL_TANAOROSHIKEISANIRISU_UPD = "C_SQL_TANAOROSHIKEISANIRISU_UPD";
        public const string C_SQL_TANAOROSHIKEISANIRISU_DEL = "C_SQL_TANAOROSHIKEISANIRISU_DEL";
        // 棚卸計算_仕入
        public const string C_SQL_TANAOROSHIKEISANSHIIRE_UPD = "C_SQL_TANAOROSHIKEISANSHIIRE_UPD";
        public const string C_SQL_TANAOROSHIKEISANSHIIRE_DEL = "C_SQL_TANAOROSHIKEISANSHIIRE_DEL";
        // 棚卸計算_出庫
        public const string C_SQL_TANAOROSHIKEISANSHUKKO_UPD = "C_SQL_TANAOROSHIKEISANSHUKKO_UPD";
        public const string C_SQL_TANAOROSHIKEISANSHUKKO_DEL = "C_SQL_TANAOROSHIKEISANSHUKKO_DEL";
        // 棚卸計算_棚卸調整
        public const string C_SQL_TANAOROSHIKEISANCHOSEI_UPD = "C_SQL_TANAOROSHIKEISANCHOSEI_UPD";
        public const string C_SQL_TANAOROSHIKEISANCHOSEI_DEL = "C_SQL_TANAOROSHIKEISANCHOSEI_DEL";
        // 棚卸計算_入庫
        public const string C_SQL_TANAOROSHIKEISANNYUKO_UPD = "C_SQL_TANAOROSHIKEISANNYUKO_UPD";
        public const string C_SQL_TANAOROSHIKEISANNYUKO_DEL = "C_SQL_TANAOROSHIKEISANNYUKO_DEL";
        // 棚卸計算_売上
        public const string C_SQL_TANAOROSHIKEISANURIAGE_UPD = "C_SQL_TANAOROSHIKEISANURIAGE_UPD";
        public const string C_SQL_TANAOROSHIKEISANURIAGE_DEL = "C_SQL_TANAOROSHIKEISANURIAGE_DEL";
        // 棚卸調整
        public const string C_SQL_TANAOROSHICHOSEI_UPD = "C_SQL_TANAOROSHICHOSEI_UPD";
        public const string C_SQL_TANAOROSHICHOSEI_DEL = "C_SQL_TANAOROSHICHOSEI_DEL";
        // 伝票番号
        public const string C_SQL_DENPYONO_UPD = "C_SQL_DENPYONO_UPD";
        public const string C_SQL_DENPYONO_DEL = "C_SQL_DENPYONO_DEL";
        // 日付制限
        public const string C_SQL_HIDUKESEIGEN_UPD = "C_SQL_HIDUKESEIGEN_UPD";
        public const string C_SQL_HIDUKESEIGEN_DEL = "C_SQL_HIDUKESEIGEN_DEL";
        // 入金
        public const string C_SQL_NYUKIN_UPD = "C_SQL_NYUKIN_UPD";
        public const string C_SQL_NYUKIN_DEL = "C_SQL_NYUKIN_DEL";
        // 売上ヘッダ
        public const string C_SQL_URIAGEHEAD_UPD = "C_SQL_URIAGEHEAD_UPD";
        public const string C_SQL_URIAGEHEAD_DEL = "C_SQL_URIAGEHEAD_DEL";
        // 売上削除承認
        public const string C_SQL_URIAGEDELSHONIN_UPD = "C_SQL_URIAGEDELSHONIN_UPD";
        public const string C_SQL_URIAGEDELSHONIN_DEL = "C_SQL_URIAGEDELSHONIN_DEL";
        // 売上明細
        public const string C_SQL_URIAGEMEISAI_UPD = "C_SQL_URIAGEMEISAI_UPD";
        public const string C_SQL_URIAGEMEISAI_DEL = "C_SQL_URIAGEMEISAI_DEL";
        // 発注
        public const string C_SQL_HACHU_UPD = "C_SQL_HACHU_UPD";
        public const string C_SQL_HACHU_DEL = "C_SQL_HACHU_DEL";
        // 返品値引売上承認
        public const string C_SQL_HENPINNEBIKIURISHONIN_UPD = "C_SQL_HENPINNEBIKIURISHONIN_UPD";
        public const string C_SQL_HENPINNEBIKIURISHONIN_DEL = "C_SQL_HENPINNEBIKIURISHONIN_DEL";
        #endregion

        // テーブル型定義
        #region
        #region 大分類
        public static readonly SqlDbType[] P_C_SQL_DAIBUNRUI_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_DAIBUNRUI_DEL =
        {
            SqlDbType.Char
        };
        # endregion

        #region 中分類
        public static readonly SqlDbType[] P_C_SQL_CHUBUNRUI_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_CHUBUNRUI_DEL =
        {
            SqlDbType.Char
            ,SqlDbType.Char
        };
        # endregion

        #region メーカー
        public static readonly SqlDbType[] P_C_SQL_MAKER_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_MAKER_DEL =
        {
            SqlDbType.Char
        };
        # endregion

        #region 商品
        public static readonly SqlDbType[] P_C_SQL_SHOHIN_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_SHOHIN_DEL =
        {
            SqlDbType.Char
        };
        #endregion

        #region 仮商品
        public static readonly SqlDbType[] P_C_SQL_SHOHIN_KARI_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        #endregion

        #region 会社処理条件
        public static readonly SqlDbType[] P_C_SQL_KAISHAJOKEN_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.SmallInt
            ,SqlDbType.DateTime
            ,SqlDbType.DateTime
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_KAISHAJOKEN_DEL =
        {
            SqlDbType.Char
        };
        #endregion

        #region 取引区分
        public static readonly SqlDbType[] P_C_SQL_TORIHIKIKBN_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_TORIHIKIKBN_DEL =
        {
            SqlDbType.Char
        };
        # endregion

        #region 担当者
        public static readonly SqlDbType[] P_C_SQL_TANTOSHA_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Money
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_TANTOSHA_DEL =
        {
            SqlDbType.Char
        };
        #endregion

        #region 業種
        public static readonly SqlDbType[] P_C_SQL_GYOSHU_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_GYOSHU_DEL =
        {
            SqlDbType.Char
        };
        # endregion

        #region 取引先
        public static readonly SqlDbType[] P_C_SQL_TORIHIKISAKI_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.SmallInt
            ,SqlDbType.SmallInt
            ,SqlDbType.SmallInt
            ,SqlDbType.NChar
            ,SqlDbType.SmallInt
            ,SqlDbType.SmallInt
            ,SqlDbType.SmallInt
            ,SqlDbType.SmallInt
            ,SqlDbType.SmallInt
            ,SqlDbType.SmallInt
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Money
            ,SqlDbType.NChar
            ,SqlDbType.Int
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_TORIHIKISAKI_DEL =
        {
            SqlDbType.Char
        };
        # endregion

        #region 営業所
        public static readonly SqlDbType[] P_C_SQL_EIGYOSHO_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_EIGYOSHO_DEL =
        {
            SqlDbType.Char
        };
        # endregion

        #region 直送先
        public static readonly SqlDbType[] P_C_SQL_CHOKUSOSAKI_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_CHOKUSOSAKI_DEL =
        {
            SqlDbType.Char
            ,SqlDbType.Char
        };
        # endregion

        #region 棚番
        public static readonly SqlDbType[] P_C_SQL_TANABAN_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_TANABAN_DEL =
        {
            SqlDbType.Char
        };
        # endregion

        #region 消費税率
        public static readonly SqlDbType[] P_C_SQL_SHOHIZEIRITSU_UPD =
        {
            SqlDbType.DateTime
            ,SqlDbType.Money
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_SHOHIZEIRITSU_DEL =
        {
            SqlDbType.DateTime
        };
        #endregion

        #region 特定向先単価
        public static readonly SqlDbType[] P_C_SQL_TOKUTEIMUKESAKITANKA_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Money
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_TOKUTEIMUKESAKITANKA_DEL =
        {
            SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
        };
        #endregion

        #region グループ
        public static readonly SqlDbType[] P_C_SQL_GROUP_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_GROUP_DEL =
        {
            SqlDbType.Char
        };
        #endregion

        #region MO
        public static readonly SqlDbType[] P_C_SQL_MO_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.Money
            ,SqlDbType.SmallDateTime
            ,SqlDbType.Char
            ,SqlDbType.Int
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_MO_DEL =
        {
            SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
        };
        #endregion

        #region カレンダー
        public static readonly SqlDbType[] P_C_SQL_CALENDAR_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Date
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_CALENDAR_DEL =
        {
            SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
        };
        #endregion

        #region マイメニュー
        public static readonly SqlDbType[] P_C_SQL_MYMENU_UPD =
        {
            SqlDbType.NChar
            ,SqlDbType.Int
            ,SqlDbType.Int
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_MYMENU_DEL =
        {
            SqlDbType.NChar
            ,SqlDbType.Int
        };
        #endregion

        #region メニュー
        public static readonly SqlDbType[] P_C_SQL_MENU_UPD =
        {
            SqlDbType.Int
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_MENU_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region メニュー権限
        public static readonly SqlDbType[] P_C_SQL_MENUKENGEN_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.Int
            ,SqlDbType.NChar
            ,SqlDbType.Char
        };
        public static readonly SqlDbType[] P_C_SQL_MENUKENGEN_DEL =
        {
            SqlDbType.Char
            ,SqlDbType.Int
        };
        #endregion

        #region 印刷設定
        public static readonly SqlDbType[] P_C_SQL_INSATSUSETTEI_UPD =
        {
            SqlDbType.NChar
            ,SqlDbType.Int
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.Char
            ,SqlDbType.Char
        };
        public static readonly SqlDbType[] P_C_SQL_INSATSUSETTEI_DEL =
        {
            SqlDbType.NChar
            ,SqlDbType.Int
        };
        #endregion

        #region 運賃
        public static readonly SqlDbType[] P_C_SQL_UNCHIN_UPD =
        {
            SqlDbType.Int
            ,SqlDbType.Int
            ,SqlDbType.Money
            ,SqlDbType.Char
            ,SqlDbType.SmallDateTime
            ,SqlDbType.NChar
            ,SqlDbType.SmallDateTime
            ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_UNCHIN_DEL =
        {
            SqlDbType.Int
            ,SqlDbType.Int
        };
        #endregion

        #region 仮加工
        public static readonly SqlDbType[] P_C_SQL_KARIKAKO_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Int
           ,SqlDbType.Int
           ,SqlDbType.SmallInt
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.SmallInt
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_KARIKAKO_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 検収済仕入明細
        public static readonly SqlDbType[] P_C_SQL_KENSHUZUMISIIREMEISAI_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_KENSHUZUMISIIREMEISAI_DEL =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
        };
        #endregion

        #region 検収済売上明細
        public static readonly SqlDbType[] P_C_SQL_KENSHUZUMIURIAGEMEISAI_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_KENSHUZUMIURIAGEMEISAI_DEL =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
        };
        #endregion

        #region 見積ヘッド
        public static readonly SqlDbType[] P_C_SQL_MITSUMORIHEAD_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.DateTime
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.DateTime
           ,SqlDbType.NChar
           ,SqlDbType.DateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_MITSUMORIHEAD_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 見積明細
        public static readonly SqlDbType[] P_C_SQL_MITSUMORIMEISAI_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_MITSUMORIMEISAI_DEL =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
        };
        #endregion

        #region 見積明細カラオケ
        public static readonly SqlDbType[] P_C_SQL_MITSUMORIMEISAIKARAOKE_UPD =
        {
            SqlDbType.SmallInt
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_MITSUMORIMEISAIKARAOKE_DEL =
        {
            SqlDbType.SmallInt
        };
        #endregion

        #region 在庫
        public static readonly SqlDbType[] P_C_SQL_ZAIKO_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_ZAIKO_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 在庫一覧_移動出数
        public static readonly SqlDbType[] P_C_SQL_ZAIKOIDOUDESU_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_ZAIKOIDOUDESU_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 在庫一覧_移動入数
        public static readonly SqlDbType[] P_C_SQL_ZAIKOIDOUIRISU_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_ZAIKOIDOUIRISU_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 在庫一覧_仕入
        public static readonly SqlDbType[] P_C_SQL_ZAIKOSHIRE_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_ZAIKOSHIRE_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 在庫一覧_出庫
        public static readonly SqlDbType[] P_C_SQL_ZAIKOSHUKKO_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_ZAIKOSHUKKO_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 在庫一覧_棚卸調整
        public static readonly SqlDbType[] P_C_SQL_ZAIKOTANAOROSHI_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_ZAIKOTANAOROSHI_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 在庫一覧_入庫
        public static readonly SqlDbType[] P_C_SQL_ZAIKONYUKO_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_ZAIKONYUKO_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 在庫一覧_売上
        public static readonly SqlDbType[] P_C_SQL_ZAIKOURIAGE_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_ZAIKOURIAGE_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 在庫一覧データ
        public static readonly SqlDbType[] P_C_SQL_ZAIKODATA_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
        };
        public static readonly SqlDbType[] P_C_SQL_ZAIKODATA_DEL =
        {
            SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 仕入ヘッダ
        public static readonly SqlDbType[] P_C_SQL_SHIIREHEAD_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar

        };
        public static readonly SqlDbType[] P_C_SQL_SHIIREHEAD_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 仕入先
        public static readonly SqlDbType[] P_C_SQL_SHIIRESAKI_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallInt
           ,SqlDbType.Char
           ,SqlDbType.DateTime
           ,SqlDbType.NChar
           ,SqlDbType.DateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_SHIIRESAKI_DEL =
        {
            SqlDbType.Char
        };
        #endregion

        #region 仕入明細
        public static readonly SqlDbType[] P_C_SQL_SHIIREMEISAI_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
           ,SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_SHIIREMEISAI_DEL =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
        };
        #endregion

        #region 支払
        public static readonly SqlDbType[] P_C_SQL_SHIHARAI_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_SHIHARAI_DEL =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
        };
        #endregion

        #region 取引先コード検索
        public static readonly SqlDbType[] P_C_SQL_TORIHIKISEARCH_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar

        };
        public static readonly SqlDbType[] P_C_SQL_TORIHIKISEARCH_DEL =
        {
            SqlDbType.Char
        };
        #endregion

        #region 取引先経理情報
        public static readonly SqlDbType[] P_C_SQL_TORIHIKISAKIKEIRI_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.DateTime
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.DateTime
           ,SqlDbType.NChar
           ,SqlDbType.DateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_TORIHIKISAKIKEIRI_DEL =
        {
            SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.DateTime
        };
        #endregion

        #region 受注
        public static readonly SqlDbType[] P_C_SQL_JUCHU_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallInt
           ,SqlDbType.NChar
           ,SqlDbType.SmallInt
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_JUCHU_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 受注0
        public static readonly SqlDbType[] P_C_SQL_JUCHU0_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallInt
           ,SqlDbType.NChar
           ,SqlDbType.SmallInt
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_JUCHU0_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 受注キャンセル
        public static readonly SqlDbType[] P_C_SQL_JUCHUCANCEL_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Int
           ,SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_JUCHUCANCEL_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 出庫ヘッダ
        public static readonly SqlDbType[] P_C_SQL_SHUKKOHEAD_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_SHUKKOHEAD_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 出庫依頼
        public static readonly SqlDbType[] P_C_SQL_SHUKKOIRAI_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_SHUKKOIRAI_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 出庫明細
        public static readonly SqlDbType[] P_C_SQL_SHUKKOMEISAI_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.Int
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_SHUKKOMEISAI_DEL =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
        };
        #endregion

        #region 初期設定
        public static readonly SqlDbType[] P_C_SQL_SHOKISETTEI_UPD =
        {
            SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_SHOKISETTEI_DEL =
        {
            SqlDbType.NChar
        };
        #endregion

        #region 商品仕入単価履歴
        public static readonly SqlDbType[] P_C_SQL_SHOHINTANKARIREKI_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
        };
        public static readonly SqlDbType[] P_C_SQL_SHOHINTANKARIREKI_DEL =
        {
            SqlDbType.Char
           ,SqlDbType.SmallDateTime
        };
        #endregion

        #region 商品仕入単価履歴TMP
        public static readonly SqlDbType[] P_C_SQL_SHOHINTANKARIREKITMP_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.SmallDateTime
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
        };
        public static readonly SqlDbType[] P_C_SQL_SHOHINTANKARIREKITMP_DEL =
        {
            SqlDbType.Char
        };
        #endregion

        #region 商品仕入単価履歴TMP2
        public static readonly SqlDbType[] P_C_SQL_SHOHINTANKARIREKITMP2_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Float
           ,SqlDbType.Money
           ,SqlDbType.Float
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Money
           ,SqlDbType.Float
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Money
           ,SqlDbType.Float
           ,SqlDbType.Money

        };
        public static readonly SqlDbType[] P_C_SQL_SHOHINTANKARIREKITMP2_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
        };
        #endregion

        #region 商品仕入履歴TMP
        public static readonly SqlDbType[] P_C_SQL_SHOHINSHIIRERIREKITMP_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
        };
        public static readonly SqlDbType[] P_C_SQL_SHOHINSHIIRERIREKITMP_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 商品売上履歴TMP
        public static readonly SqlDbType[] P_C_SQL_SHOHINURIAGERIREKITMP_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
        };
        public static readonly SqlDbType[] P_C_SQL_SHOHINURIAGERIREKITMP_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 商品評価単価履歴
        public static readonly SqlDbType[] P_C_SQL_SHOHINHYOKATANKARIREKI_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
        };
        public static readonly SqlDbType[] P_C_SQL_SHOHINHYOKATANKARIREKI_DEL =
        {
            SqlDbType.Char
           ,SqlDbType.SmallDateTime
        };
        #endregion

        #region 商品分類別利益率
        public static readonly SqlDbType[] P_C_SQL_SHOHINBUNRUIRIEKIRITSU_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar

        };
        public static readonly SqlDbType[] P_C_SQL_SHOHINBUNRUIRIEKIRITSU_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 商品別利益率
        public static readonly SqlDbType[] P_C_SQL_SHOHINBETSURIEKIRITSU_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar


        };
        public static readonly SqlDbType[] P_C_SQL_SHOHINBETSURIEKIRITSU_DEL =
        {
            SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 請求履歴
        public static readonly SqlDbType[] P_C_SQL_SEIKYURIREKI_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_SEIKYURIREKI_DEL =
        {
            SqlDbType.Char
           ,SqlDbType.SmallDateTime
        };
        #endregion

        #region 前年仕入実績
        public static readonly SqlDbType[] P_C_SQL_ZENNENSHIIREJISSEKI_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money

        };
        public static readonly SqlDbType[] P_C_SQL_ZENNENSHIIREJISSEKI_DEL =
        {
            SqlDbType.Char
        };
        #endregion

        #region 前年粗利実績
        public static readonly SqlDbType[] P_C_SQL_ZENNENARARIJISSEKI_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money

        };
        public static readonly SqlDbType[] P_C_SQL_ZENNENARARIJISSEKI_DEL =
        {
            SqlDbType.Char
        };
        #endregion

        #region 前年売上実績
        public static readonly SqlDbType[] P_C_SQL_ZENNENURIAGEJISSEKI_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money

        };
        public static readonly SqlDbType[] P_C_SQL_ZENNENURIAGEJISSEKI_DEL =
        {
            SqlDbType.Char
        };
        #endregion

        #region 倉庫間移動
        public static readonly SqlDbType[] P_C_SQL_SOKOKANIDOU_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Int
           ,SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar


        };
        public static readonly SqlDbType[] P_C_SQL_SOKOKANIDOU_DEL =
        {
            SqlDbType.Int
           ,SqlDbType.Int
           ,SqlDbType.Char
        };
        #endregion

        #region 棚卸記入表
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKINYU_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKINYU_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 棚卸計算_移動出数
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANDESU_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANDESU_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 棚卸計算_移動入数
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANIRISU_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANIRISU_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 棚卸計算_仕入
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANSHIIRE_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANSHIIRE_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 棚卸計算_出庫
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANSHUKKO_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANSHUKKO_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 棚卸計算_棚卸調整
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANCHOSEI_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANCHOSEI_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 棚卸計算_入庫
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANNYUKO_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANNYUKO_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 棚卸計算_売上
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANURIAGE_UPD =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
        };
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHIKEISANURIAGE_DEL =
        {
            SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
        };
        #endregion

        #region 棚卸調整
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHICHOSEI_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar

        };
        public static readonly SqlDbType[] P_C_SQL_TANAOROSHICHOSEI_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 伝票番号
        public static readonly SqlDbType[] P_C_SQL_DENPYONO_UPD =
        {
            SqlDbType.NChar
           ,SqlDbType.Int
           ,SqlDbType.DateTime
        };
        public static readonly SqlDbType[] P_C_SQL_DENPYONO_DEL =
        {
            SqlDbType.NChar
        };
        #endregion

        #region 日付制限
        public static readonly SqlDbType[] P_C_SQL_HIDUKESEIGEN_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.DateTime
           ,SqlDbType.DateTime
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_HIDUKESEIGEN_DEL =
        {
            SqlDbType.Int
           ,SqlDbType.Char
        };
        #endregion

        #region 入金
        public static readonly SqlDbType[] P_C_SQL_NYUKIN_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_NYUKIN_DEL =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
        };
        #endregion

        #region 売上ヘッダ
        public static readonly SqlDbType[] P_C_SQL_URIAGEHEAD_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_URIAGEHEAD_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 売上削除承認
        public static readonly SqlDbType[] P_C_SQL_URIAGEDELSHONIN_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_URIAGEDELSHONIN_DEL =
        {
            SqlDbType.Int
        };
        #endregion

        #region 売上明細
        public static readonly SqlDbType[] P_C_SQL_URIAGEMEISAI_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
           ,SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_URIAGEMEISAI_DEL =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
        };
        #endregion

        #region 発注
        public static readonly SqlDbType[] P_C_SQL_HACHU_UPD =
        {
            SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.Int
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Int
           ,SqlDbType.Int
           ,SqlDbType.SmallInt
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.Money
           ,SqlDbType.SmallDateTime
           ,SqlDbType.SmallInt
           ,SqlDbType.NChar
           ,SqlDbType.Money
           ,SqlDbType.Char
           ,SqlDbType.Char
           ,SqlDbType.NChar
           ,SqlDbType.Char
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_HACHU_DEL =
        {
            SqlDbType.Char
        };
        #endregion

        #region 返品値引売上承認
        public static readonly SqlDbType[] P_C_SQL_HENPINNEBIKIURISHONIN_UPD =
        {
            SqlDbType.Int
           ,SqlDbType.SmallInt
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
           ,SqlDbType.SmallDateTime
           ,SqlDbType.NChar
        };
        public static readonly SqlDbType[] P_C_SQL_HENPINNEBIKIURISHONIN_DEL =
        {
            SqlDbType.Int
        };
        #endregion
        #endregion

        #region テーブル - 型定義の定義対応
        public static Dictionary<String, SqlDbType[]> paramDic = new Dictionary<string, SqlDbType[]>()
        {
            { C_SQL_DAIBUNRUI_UPD,              P_C_SQL_DAIBUNRUI_UPD }
           ,{ C_SQL_DAIBUNRUI_DEL,              P_C_SQL_DAIBUNRUI_DEL }
           ,{ C_SQL_CHUBUNRUI_UPD,              P_C_SQL_CHUBUNRUI_UPD }
           ,{ C_SQL_CHUBUNRUI_DEL,              P_C_SQL_CHUBUNRUI_DEL }
           ,{ C_SQL_MAKER_UPD,                  P_C_SQL_MAKER_UPD }
           ,{ C_SQL_MAKER_DEL,                  P_C_SQL_MAKER_DEL }
           ,{ C_SQL_SHOHIN_UPD,                 P_C_SQL_SHOHIN_UPD }
           ,{ C_SQL_SHOHIN_KARI_UPD,            P_C_SQL_SHOHIN_KARI_UPD}
           ,{ C_SQL_SHOHIN_DEL,                 P_C_SQL_SHOHIN_DEL }
           ,{ C_SQL_KAISHAJOKEN_UPD,            P_C_SQL_KAISHAJOKEN_UPD }
           ,{ C_SQL_KAISHAJOKEN_DEL,            P_C_SQL_KAISHAJOKEN_DEL }
           ,{ C_SQL_TORIHIKIKBN_UPD,            P_C_SQL_TORIHIKIKBN_UPD }
           ,{ C_SQL_TORIHIKIKBN_DEL,            P_C_SQL_TORIHIKIKBN_DEL }
           ,{ C_SQL_TANTOSHA_UPD,               P_C_SQL_TANTOSHA_UPD }
           ,{ C_SQL_TANTOSHA_DEL,               P_C_SQL_TANTOSHA_DEL }
           ,{ C_SQL_GYOSHU_UPD,                 P_C_SQL_GYOSHU_UPD }
           ,{ C_SQL_GYOSHU_DEL,                 P_C_SQL_GYOSHU_DEL }
           ,{ C_SQL_TORIHIKISAKI_UPD,           P_C_SQL_TORIHIKISAKI_UPD }
           ,{ C_SQL_TORIHIKISAKI_DEL,           P_C_SQL_TORIHIKISAKI_DEL }
           ,{ C_SQL_EIGYOSHO_UPD,               P_C_SQL_EIGYOSHO_UPD }
           ,{ C_SQL_EIGYOSHO_DEL,               P_C_SQL_EIGYOSHO_DEL }
           ,{ C_SQL_CHOKUSOSAKI_UPD,            P_C_SQL_CHOKUSOSAKI_UPD }
           ,{ C_SQL_CHOKUSOSAKI_DEL,            P_C_SQL_CHOKUSOSAKI_DEL }
           ,{ C_SQL_TANABAN_UPD,                P_C_SQL_TANABAN_UPD }
           ,{ C_SQL_TANABAN_DEL,                P_C_SQL_TANABAN_DEL }
           ,{ C_SQL_SHOHIZEIRITSU_UPD,          P_C_SQL_SHOHIZEIRITSU_UPD }
           ,{ C_SQL_SHOHIZEIRITSU_DEL,          P_C_SQL_SHOHIZEIRITSU_DEL }
           ,{ C_SQL_TOKUTEIMUKESAKITANKA_UPD,   P_C_SQL_TOKUTEIMUKESAKITANKA_UPD }
           ,{ C_SQL_TOKUTEIMUKESAKITANKA_DEL,   P_C_SQL_TOKUTEIMUKESAKITANKA_DEL }
           ,{ C_SQL_GROUP_UPD,                  P_C_SQL_GROUP_UPD }
           ,{ C_SQL_GROUP_DEL,                  P_C_SQL_GROUP_DEL }
           ,{ C_SQL_MO_UPD,                     P_C_SQL_MO_UPD }
           ,{ C_SQL_MO_DEL,                     P_C_SQL_MO_DEL }
           ,{ C_SQL_CALENDAR_UPD,               P_C_SQL_CALENDAR_UPD }
           ,{ C_SQL_CALENDAR_DEL,               P_C_SQL_CALENDAR_DEL }
           ,{ C_SQL_MYMENU_UPD,                 P_C_SQL_MYMENU_UPD }
           ,{ C_SQL_MYMENU_DEL,                 P_C_SQL_MYMENU_DEL }
           ,{ C_SQL_MENU_UPD,                   P_C_SQL_MENU_UPD }
           ,{ C_SQL_MENU_DEL,                   P_C_SQL_MENU_DEL }
           ,{ C_SQL_MENUKENGEN_UPD,             P_C_SQL_MENUKENGEN_UPD }
           ,{ C_SQL_MENUKENGEN_DEL,             P_C_SQL_MENUKENGEN_DEL }
           ,{ C_SQL_INSATSUSETTEI_UPD,          P_C_SQL_INSATSUSETTEI_UPD }
           ,{ C_SQL_INSATSUSETTEI_DEL,          P_C_SQL_INSATSUSETTEI_DEL }
           ,{ C_SQL_UNCHIN_UPD,                 P_C_SQL_UNCHIN_UPD }
           ,{ C_SQL_UNCHIN_DEL,                 P_C_SQL_UNCHIN_DEL }
           ,{ C_SQL_KARIKAKO_UPD,               P_C_SQL_KARIKAKO_UPD }
           ,{ C_SQL_KARIKAKO_DEL,               P_C_SQL_KARIKAKO_DEL }
           ,{ C_SQL_KENSHUZUMISIIREMEISAI_UPD,  P_C_SQL_KENSHUZUMISIIREMEISAI_UPD }
           ,{ C_SQL_KENSHUZUMISIIREMEISAI_DEL,  P_C_SQL_KENSHUZUMISIIREMEISAI_DEL }
           ,{ C_SQL_KENSHUZUMIURIAGEMEISAI_UPD, P_C_SQL_KENSHUZUMIURIAGEMEISAI_UPD }
           ,{ C_SQL_KENSHUZUMIURIAGEMEISAI_DEL, P_C_SQL_KENSHUZUMIURIAGEMEISAI_DEL }
           ,{ C_SQL_MITSUMORIHEAD_UPD,          P_C_SQL_MITSUMORIHEAD_UPD }
           ,{ C_SQL_MITSUMORIHEAD_DEL,          P_C_SQL_MITSUMORIHEAD_DEL }
           ,{ C_SQL_MITSUMORIMEISAI_UPD,        P_C_SQL_MITSUMORIMEISAI_UPD }
           ,{ C_SQL_MITSUMORIMEISAI_DEL,        P_C_SQL_MITSUMORIMEISAI_DEL }
           ,{ C_SQL_MITSUMORIMEISAIKARAOKE_UPD, P_C_SQL_MITSUMORIMEISAIKARAOKE_UPD }
           ,{ C_SQL_MITSUMORIMEISAIKARAOKE_DEL, P_C_SQL_MITSUMORIMEISAIKARAOKE_DEL }
           ,{ C_SQL_ZAIKO_UPD,                  P_C_SQL_ZAIKO_UPD }
           ,{ C_SQL_ZAIKO_DEL,                  P_C_SQL_ZAIKO_DEL }
           ,{ C_SQL_ZAIKOIDOUDESU_UPD,          P_C_SQL_ZAIKOIDOUDESU_UPD }
           ,{ C_SQL_ZAIKOIDOUDESU_DEL,          P_C_SQL_ZAIKOIDOUDESU_DEL }
           ,{ C_SQL_ZAIKOIDOUIRISU_UPD,         P_C_SQL_ZAIKOIDOUIRISU_UPD }
           ,{ C_SQL_ZAIKOIDOUIRISU_DEL,         P_C_SQL_ZAIKOIDOUIRISU_DEL }
           ,{ C_SQL_ZAIKOSHIRE_UPD,             P_C_SQL_ZAIKOSHIRE_UPD }
           ,{ C_SQL_ZAIKOSHIRE_DEL,             P_C_SQL_ZAIKOSHIRE_DEL }
           ,{ C_SQL_ZAIKOSHUKKO_UPD,            P_C_SQL_ZAIKOSHUKKO_UPD }
           ,{ C_SQL_ZAIKOSHUKKO_DEL,            P_C_SQL_ZAIKOSHUKKO_DEL }
           ,{ C_SQL_ZAIKOTANAOROSHI_UPD,        P_C_SQL_ZAIKOTANAOROSHI_UPD }
           ,{ C_SQL_ZAIKOTANAOROSHI_DEL,        P_C_SQL_ZAIKOTANAOROSHI_DEL }
           ,{ C_SQL_ZAIKONYUKO_UPD,             P_C_SQL_ZAIKONYUKO_UPD }
           ,{ C_SQL_ZAIKONYUKO_DEL,             P_C_SQL_ZAIKONYUKO_DEL }
           ,{ C_SQL_ZAIKOURIAGE_UPD,            P_C_SQL_ZAIKOURIAGE_UPD }
           ,{ C_SQL_ZAIKOURIAGE_DEL,            P_C_SQL_ZAIKOURIAGE_DEL }
           ,{ C_SQL_ZAIKODATA_UPD,              P_C_SQL_ZAIKODATA_UPD }
           ,{ C_SQL_ZAIKODATA_DEL,              P_C_SQL_ZAIKODATA_DEL }
           ,{ C_SQL_SHIIREHEAD_UPD,             P_C_SQL_SHIIREHEAD_UPD }
           ,{ C_SQL_SHIIREHEAD_DEL,             P_C_SQL_SHIIREHEAD_DEL }
           ,{ C_SQL_SHIIRESAKI_UPD,             P_C_SQL_SHIIRESAKI_UPD }
           ,{ C_SQL_SHIIRESAKI_DEL,             P_C_SQL_SHIIRESAKI_DEL }
           ,{ C_SQL_SHIIREMEISAI_UPD,           P_C_SQL_SHIIREMEISAI_UPD }
           ,{ C_SQL_SHIIREMEISAI_DEL,           P_C_SQL_SHIIREMEISAI_DEL }
           ,{ C_SQL_SHIHARAI_UPD,               P_C_SQL_SHIHARAI_UPD }
           ,{ C_SQL_SHIHARAI_DEL,               P_C_SQL_SHIHARAI_DEL }
           ,{ C_SQL_TORIHIKISEARCH_UPD,         P_C_SQL_TORIHIKISEARCH_UPD }
           ,{ C_SQL_TORIHIKISEARCH_DEL,         P_C_SQL_TORIHIKISEARCH_DEL }
           ,{ C_SQL_TORIHIKISAKIKEIRI_UPD,      P_C_SQL_TORIHIKISAKIKEIRI_UPD }
           ,{ C_SQL_TORIHIKISAKIKEIRI_DEL,      P_C_SQL_TORIHIKISAKIKEIRI_DEL }
           ,{ C_SQL_JUCHU_UPD,                  P_C_SQL_JUCHU_UPD }
           ,{ C_SQL_JUCHU_DEL,                  P_C_SQL_JUCHU_DEL }
           ,{ C_SQL_JUCHU0_UPD,                 P_C_SQL_JUCHU0_UPD }
           ,{ C_SQL_JUCHU0_DEL,                 P_C_SQL_JUCHU0_DEL }
           ,{ C_SQL_JUCHUCANCEL_UPD,            P_C_SQL_JUCHUCANCEL_UPD }
           ,{ C_SQL_JUCHUCANCEL_DEL,            P_C_SQL_JUCHUCANCEL_DEL }
           ,{ C_SQL_SHUKKOHEAD_UPD,             P_C_SQL_SHUKKOHEAD_UPD }
           ,{ C_SQL_SHUKKOHEAD_DEL,             P_C_SQL_SHUKKOHEAD_DEL }
           ,{ C_SQL_SHUKKOIRAI_UPD,             P_C_SQL_SHUKKOIRAI_UPD }
           ,{ C_SQL_SHUKKOIRAI_DEL,             P_C_SQL_SHUKKOIRAI_DEL }
           ,{ C_SQL_SHUKKOMEISAI_UPD,           P_C_SQL_SHUKKOMEISAI_UPD }
           ,{ C_SQL_SHUKKOMEISAI_DEL,           P_C_SQL_SHUKKOMEISAI_DEL }
           ,{ C_SQL_SHOKISETTEI_UPD,            P_C_SQL_SHOKISETTEI_UPD }
           ,{ C_SQL_SHOKISETTEI_DEL,            P_C_SQL_SHOKISETTEI_DEL }
           ,{ C_SQL_SHOHINTANKARIREKI_UPD,      P_C_SQL_SHOHINTANKARIREKI_UPD }
           ,{ C_SQL_SHOHINTANKARIREKI_DEL,      P_C_SQL_SHOHINTANKARIREKI_DEL }
           ,{ C_SQL_SHOHINTANKARIREKITMP_UPD,   P_C_SQL_SHOHINTANKARIREKITMP_UPD }
           ,{ C_SQL_SHOHINTANKARIREKITMP_DEL,   P_C_SQL_SHOHINTANKARIREKITMP_DEL }
           ,{ C_SQL_SHOHINTANKARIREKITMP2_UPD,  P_C_SQL_SHOHINTANKARIREKITMP2_UPD }
           ,{ C_SQL_SHOHINTANKARIREKITMP2_DEL,  P_C_SQL_SHOHINTANKARIREKITMP2_DEL }
           ,{ C_SQL_SHOHINSHIIRERIREKITMP_UPD,  P_C_SQL_SHOHINSHIIRERIREKITMP_UPD }
           ,{ C_SQL_SHOHINSHIIRERIREKITMP_DEL,  P_C_SQL_SHOHINSHIIRERIREKITMP_DEL }
           ,{ C_SQL_SHOHINURIAGERIREKITMP_UPD,  P_C_SQL_SHOHINURIAGERIREKITMP_UPD }
           ,{ C_SQL_SHOHINURIAGERIREKITMP_DEL,  P_C_SQL_SHOHINURIAGERIREKITMP_DEL }
           ,{ C_SQL_SHOHINHYOKATANKARIREKI_UPD, P_C_SQL_SHOHINHYOKATANKARIREKI_UPD }
           ,{ C_SQL_SHOHINHYOKATANKARIREKI_DEL, P_C_SQL_SHOHINHYOKATANKARIREKI_DEL }
           ,{ C_SQL_SHOHINBUNRUIRIEKIRITSU_UPD, P_C_SQL_SHOHINBUNRUIRIEKIRITSU_UPD }
           ,{ C_SQL_SHOHINBUNRUIRIEKIRITSU_DEL, P_C_SQL_SHOHINBUNRUIRIEKIRITSU_DEL }
           ,{ C_SQL_SHOHINBETSURIEKIRITSU_UPD,  P_C_SQL_SHOHINBETSURIEKIRITSU_UPD }
           ,{ C_SQL_SHOHINBETSURIEKIRITSU_DEL,  P_C_SQL_SHOHINBETSURIEKIRITSU_DEL }
           ,{ C_SQL_SEIKYURIREKI_UPD,           P_C_SQL_SEIKYURIREKI_UPD }
           ,{ C_SQL_SEIKYURIREKI_DEL,           P_C_SQL_SEIKYURIREKI_DEL }
           ,{ C_SQL_ZENNENSHIIREJISSEKI_UPD,    P_C_SQL_ZENNENSHIIREJISSEKI_UPD }
           ,{ C_SQL_ZENNENSHIIREJISSEKI_DEL,    P_C_SQL_ZENNENSHIIREJISSEKI_DEL }
           ,{ C_SQL_ZENNENARARIJISSEKI_UPD,     P_C_SQL_ZENNENARARIJISSEKI_UPD }
           ,{ C_SQL_ZENNENARARIJISSEKI_DEL,     P_C_SQL_ZENNENARARIJISSEKI_DEL }
           ,{ C_SQL_ZENNENURIAGEJISSEKI_UPD,    P_C_SQL_ZENNENURIAGEJISSEKI_UPD }
           ,{ C_SQL_ZENNENURIAGEJISSEKI_DEL,    P_C_SQL_ZENNENURIAGEJISSEKI_DEL }
           ,{ C_SQL_SOKOKANIDOU_UPD,            P_C_SQL_SOKOKANIDOU_UPD }
           ,{ C_SQL_SOKOKANIDOU_DEL,            P_C_SQL_SOKOKANIDOU_DEL }
           ,{ C_SQL_TANAOROSHIKINYU_UPD,        P_C_SQL_TANAOROSHIKINYU_UPD }
           ,{ C_SQL_TANAOROSHIKINYU_DEL,        P_C_SQL_TANAOROSHIKINYU_DEL }
           ,{ C_SQL_TANAOROSHIKEISANDESU_UPD,   P_C_SQL_TANAOROSHIKEISANDESU_UPD }
           ,{ C_SQL_TANAOROSHIKEISANDESU_DEL,   P_C_SQL_TANAOROSHIKEISANDESU_DEL }
           ,{ C_SQL_TANAOROSHIKEISANIRISU_UPD,  P_C_SQL_TANAOROSHIKEISANIRISU_UPD }
           ,{ C_SQL_TANAOROSHIKEISANIRISU_DEL,  P_C_SQL_TANAOROSHIKEISANIRISU_DEL }
           ,{ C_SQL_TANAOROSHIKEISANSHIIRE_UPD, P_C_SQL_TANAOROSHIKEISANSHIIRE_UPD }
           ,{ C_SQL_TANAOROSHIKEISANSHIIRE_DEL, P_C_SQL_TANAOROSHIKEISANSHIIRE_DEL }
           ,{ C_SQL_TANAOROSHIKEISANSHUKKO_UPD, P_C_SQL_TANAOROSHIKEISANSHUKKO_UPD }
           ,{ C_SQL_TANAOROSHIKEISANSHUKKO_DEL, P_C_SQL_TANAOROSHIKEISANSHUKKO_DEL }
           ,{ C_SQL_TANAOROSHIKEISANCHOSEI_UPD, P_C_SQL_TANAOROSHIKEISANCHOSEI_UPD }
           ,{ C_SQL_TANAOROSHIKEISANCHOSEI_DEL, P_C_SQL_TANAOROSHIKEISANCHOSEI_DEL }
           ,{ C_SQL_TANAOROSHIKEISANNYUKO_UPD,  P_C_SQL_TANAOROSHIKEISANNYUKO_UPD }
           ,{ C_SQL_TANAOROSHIKEISANNYUKO_DEL,  P_C_SQL_TANAOROSHIKEISANNYUKO_DEL }
           ,{ C_SQL_TANAOROSHIKEISANURIAGE_UPD, P_C_SQL_TANAOROSHIKEISANURIAGE_UPD }
           ,{ C_SQL_TANAOROSHIKEISANURIAGE_DEL, P_C_SQL_TANAOROSHIKEISANURIAGE_DEL }
           ,{ C_SQL_TANAOROSHICHOSEI_UPD,       P_C_SQL_TANAOROSHICHOSEI_UPD }
           ,{ C_SQL_TANAOROSHICHOSEI_DEL,       P_C_SQL_TANAOROSHICHOSEI_DEL }
           ,{ C_SQL_DENPYONO_UPD,               P_C_SQL_DENPYONO_UPD }
           ,{ C_SQL_DENPYONO_DEL,               P_C_SQL_DENPYONO_DEL }
           ,{ C_SQL_HIDUKESEIGEN_UPD,           P_C_SQL_HIDUKESEIGEN_UPD }
           ,{ C_SQL_HIDUKESEIGEN_DEL,           P_C_SQL_HIDUKESEIGEN_DEL }
           ,{ C_SQL_NYUKIN_UPD,                 P_C_SQL_NYUKIN_UPD }
           ,{ C_SQL_NYUKIN_DEL,                 P_C_SQL_NYUKIN_DEL }
           ,{ C_SQL_URIAGEHEAD_UPD,             P_C_SQL_URIAGEHEAD_UPD }
           ,{ C_SQL_URIAGEHEAD_DEL,             P_C_SQL_URIAGEHEAD_DEL }
           ,{ C_SQL_URIAGEDELSHONIN_UPD,        P_C_SQL_URIAGEDELSHONIN_UPD }
           ,{ C_SQL_URIAGEDELSHONIN_DEL,        P_C_SQL_URIAGEDELSHONIN_DEL }
           ,{ C_SQL_URIAGEMEISAI_UPD,           P_C_SQL_URIAGEMEISAI_UPD }
           ,{ C_SQL_URIAGEMEISAI_DEL,           P_C_SQL_URIAGEMEISAI_DEL }
           ,{ C_SQL_HACHU_UPD,                  P_C_SQL_HACHU_UPD }
           ,{ C_SQL_HACHU_DEL,                  P_C_SQL_HACHU_DEL }
           ,{ C_SQL_HENPINNEBIKIURISHONIN_UPD,  P_C_SQL_HENPINNEBIKIURISHONIN_UPD }
           ,{ C_SQL_HENPINNEBIKIURISHONIN_DEL,  P_C_SQL_HENPINNEBIKIURISHONIN_DEL }
        };
        #endregion

    }
}
