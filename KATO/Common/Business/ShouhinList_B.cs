using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Util;
using KATO.Form.F0140_TanaorosiInput;
using KATO.Form.M1030_Shohin;
using KATO.Form.D0380_ShohinMotochoKakunin;
using KATO.Form.A0010_JuchuInput;
using KATO.Form.A0100_HachuInput;
using KATO.Form.M1210_ShohinbetsuRiekiritsuSettei;
using KATO.Form.M1160_TokuteimukesakiTanka;
using KATO.Business.M1020_Maker_B;
using KATO.Business.M1010_Daibunrui;
using KATO.Business.M1110_Chubunrui;

namespace KATO.Common.Business
{
    ///<summary>
    ///ShouhinList_B
    ///商品リストフォーム
    ///作成者：大河内
    ///作成日：2017/3/23
    ///更新者：大河内
    ///更新日：2017/4/7
    ///カラム論理名
    ///</summary>
    class ShouhinList_B
    {
        string strSQLName = null;

        ///<summary>
        ///getShohinView
        ///検索データを記入
        ///</summary>
        public DataTable getShohinView(List<int> lstInt, List<string> lstString, List<Boolean> lstBoolean, Boolean blnZaikoKensaku)
        {
            string strWhere = "";

            strWhere = "WHERE a.削除 = 'N'";

            if (lstString[0] != "")
            {
                strWhere = strWhere + " AND a.大分類コード='" + lstString[0] + "'";
            }
            if (lstString[1] != "")
            {
                strWhere = strWhere + " AND a.中分類コード='" + lstString[1] + "'";
            }
            if (lstString[2] != "")
            {
                strWhere = strWhere + " AND a.メーカーコード='" + lstString[2] + "'";
            }
            //検索文字列があり、部分検索の場合
            if (lstString[3] != "" && lstBoolean[1] == true)
            {
                strWhere = strWhere + " AND REPLACE(( ISNULL(a.Ｃ１,'') + ISNULL(a.Ｃ２,'') + ISNULL(a.Ｃ３,'') + ISNULL(a.Ｃ４,'') + ISNULL(a.Ｃ５,'') + ISNULL(a.Ｃ６,'') ),' ' ,'') LIKE '%" + lstString[3] + "%'";
            }
            //検索文字列があり、完全一致検索の場合
            else if(lstString[3] != "" && lstBoolean[1] == false)
            {
                strWhere = strWhere + " AND REPLACE(( ISNULL(a.Ｃ１,'') + ISNULL(a.Ｃ２,'') + ISNULL(a.Ｃ３,'') + ISNULL(a.Ｃ４,'') + ISNULL(a.Ｃ５,'') + ISNULL(a.Ｃ６,'') ),' ' ,'') LIKE '" + lstString[3] + "'";
            }

            if (lstString[4] == "" && lstString[5] == "" && blnZaikoKensaku == true)
            {
                lstInt[1] = 0;
            }
            else if (lstString[5] == "" && blnZaikoKensaku == true)
            {
                lstInt[1] = 1;
            }
            else if (lstString[4] == "" && blnZaikoKensaku == true)
            {
                lstInt[1] = 2;
            }
            else
            {
                lstInt[1] = 3;
            }

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();

            //商品テーブルから取り出すデータ
            DataTable dtShohin = new DataTable();

            try
            {
                string strSELECT = "SELECT 商品.商品コード,大分類.大分類名,中分類.中分類名,メーカー.メーカー名 AS メーカー,ISNULL(商品.Ｃ１, '') + ' ' + ISNULL(商品.Ｃ２, '') + ' ' + ISNULL(商品.Ｃ３, '') + ' ' +ISNULL(商品.Ｃ４, '') + ' ' +ISNULL(商品.Ｃ５, '') + ' ' +ISNULL(商品.Ｃ６, '') AS 品名,本社在庫.在庫数 AS 本社在庫, 本社在庫.フリー在庫数 AS 本社ﾌﾘｰ, 岐阜在庫.在庫数 AS 岐阜在庫, 岐阜在庫.フリー在庫数 AS 岐阜ﾌﾘｰ, 商品.メモ,商品.定価,商品.仕入単価,商品.コメント";
                strSELECT = strSELECT + " FROM 大分類,中分類,メーカー,商品 LEFT OUTER JOIN 在庫数 AS 本社在庫 ON 商品.商品コード = 本社在庫.商品コード and 本社在庫.営業所コード = '0001' LEFT OUTER JOIN 在庫数 AS 岐阜在庫 ON 商品.商品コード = 岐阜在庫.商品コード and 岐阜在庫.営業所コード = '0002'";
                strSELECT = strSELECT + " WHERE 商品.大分類コード = 大分類.大分類コード AND 商品.大分類コード = 中分類.大分類コード AND 商品.中分類コード = 中分類.中分類コード AND 商品.メーカーコード = メーカー.メーカーコード AND 商品.メーカーコード = メーカー.メーカーコード";

                //大分類あり
                if (lstString[0] != "")
                {
                    strSELECT = strSELECT + " AND 商品.大分類コード = " + lstString[0];
                }

                //大分類と中分類共に記入されている場合
                if (lstString[0] != "" && lstString[1] != "")
                {
                    strSELECT = strSELECT + " AND 商品.中分類コード = " + lstString[1];
                }

                //メーカーと大分類あり
                if (lstString[2] != "")
                {
                    strSELECT = strSELECT + " AND 商品.メーカーコード = " + lstString[2];
                }

            //表示するデータ
            DataTable dtView = new DataTable();

            try
            {
                switch (lstInt[1])
                {
                    //通常表示
                    case 0:
                        dtShohin = dbConnective.ReadSql("SELECT a.商品コード AS コード,dbo.f_getメーカー名(a.メーカーコード) AS メーカー,dbo.f_get大分類名(a.大分類コード) AS 大分類名,dbo.f_get中分類名(a.大分類コード, a.中分類コード) AS 中分類名, ISNULL(a.Ｃ１,'')+' ' +ISNULL(a.Ｃ２,'')+' ' +ISNULL(a.Ｃ３,'')+' ' +ISNULL(a.Ｃ４,'')+' ' +ISNULL(a.Ｃ５,'')+' ' +ISNULL(a.Ｃ６,'') AS 品名, a.メモ AS メモ, 大分類コード, 中分類コード, メーカーコード , 定価, 仕入単価 FROM 商品 AS a " + strWhere + " ORDER BY 大分類コード,中分類コード,メーカーコード,Ｃ１,Ｃ２,Ｃ３,Ｃ４,Ｃ５,Ｃ６ ");
                        break;
                    //本社在庫の表示
                    case 1:
                        dtShohin = dbConnective.ReadSql("SELECT a.商品コード AS コード,dbo.f_getメーカー名(a.メーカーコード) AS メーカー,dbo.f_get大分類名(a.大分類コード) AS 大分類名,dbo.f_get中分類名(a.大分類コード,a.中分類コード) AS 中分類名, ISNULL(a.Ｃ１,'')+' ' +ISNULL(a.Ｃ２,'')+' ' +ISNULL(a.Ｃ３,'')+' ' +ISNULL(a.Ｃ４,'')+' ' +ISNULL(a.Ｃ５,'')+' ' +ISNULL(a.Ｃ６,'') AS 品名,a.メモ AS メモ, dbo.f_get指定日のフリー在庫数Ｂ('0001', a.商品コード, '2050/12/31'), 大分類コード, 中分類コード, メーカーコード, 定価, 仕入単価 AS 本社在庫 , '' AS 岐阜在庫 FROM 商品 AS a " + strWhere + " ORDER BY 大分類コード,中分類コード,メーカーコード,Ｃ１,Ｃ２,Ｃ３,Ｃ４,Ｃ５,Ｃ６ ");
                        break;
                    //岐阜在庫の表示
                    case 2:
                        dtShohin = dbConnective.ReadSql("SELECT a.商品コード AS コード,dbo.f_getメーカー名(a.メーカーコード) AS メーカー,dbo.f_get大分類名(a.大分類コード) AS 大分類名,dbo.f_get中分類名(a.大分類コード,a.中分類コード) AS 中分類名, ISNULL(a.Ｃ１,'')+' ' +ISNULL(a.Ｃ２,'')+' ' +ISNULL(a.Ｃ３,'')+' ' +ISNULL(a.Ｃ４,'')+' ' +ISNULL(a.Ｃ５,'')+' ' +ISNULL(a.Ｃ６,'') AS 品名,a.メモ AS メモ, '' AS 本社在庫 , dbo.f_get指定日のフリー在庫数Ｂ('0002',a.商品コード,'2050/12/31') AS 岐阜在庫, 大分類コード, 中分類コード, メーカーコード, 定価, 仕入単価 FROM 商品 AS a " + strWhere + " ORDER BY 大分類コード,中分類コード,メーカーコード,Ｃ１,Ｃ２,Ｃ３,Ｃ４,Ｃ５,Ｃ６ ");
                        break;
                    //棚番の表示
                    case 3:
                        dtShohin = dbConnective.ReadSql("SELECT a.商品コード AS コード,dbo.f_getメーカー名(a.メーカーコード) AS メーカー,dbo.f_get大分類名(a.大分類コード) AS 大分類名,dbo.f_get中分類名(a.大分類コード,a.中分類コード) AS 中分類名, ISNULL(a.Ｃ１,'')+' ' +ISNULL(a.Ｃ２,'')+' ' +ISNULL(a.Ｃ３,'')+' ' +ISNULL(a.Ｃ４,'')+' ' +ISNULL(a.Ｃ５,'')+' ' +ISNULL(a.Ｃ６,'') AS 品名,a.メモ AS メモ, a.棚番本社 AS 棚番本社, a.棚番岐阜 AS 棚番岐阜, 大分類コード, 中分類コード, メーカーコード, 定価, 仕入単価 FROM 商品 AS a " + strWhere + " ORDER BY 大分類コード,中分類コード,メーカーコード,Ｃ１,Ｃ２,Ｃ３,Ｃ４,Ｃ５,Ｃ６ ");
                        break;
                }

                //データがあった場合
                if (dtShohin.Rows.Count > 0)
                {
                    //掛け率のカラム追加
                    dtShohin.Columns.Add("掛率", Type.GetType("System.String"));
                    DataRow drInsert = dtShohin.NewRow();
                    drInsert["掛率"] = "";

                    for (int intShohinCnt = 0; intShohinCnt < dtShohin.Rows.Count; intShohinCnt++)
                    {
                        //商品コードを挿入
                        dtView.Rows[intShohinCnt]["商品コード"] = dtShohin.Rows[intShohinCnt]["コード"].ToString();

                        //メーカー名の取得
                        M1020_Maker_B makerB = new M1020_Maker_B();
                        dtMaker = makerB.getTxtMakerTextLeave(dtShohin.Rows[intShohinCnt]["メーカーコード"].ToString());

                        //メーカー名を挿入
                        dtView.Rows[intShohinCnt]["メーカー"] = dtMaker.Rows[0]["メーカー名"].ToString();

                        //大分類名の取得
                        M1010_Daibunrui_B daibunB = new M1010_Daibunrui_B();
                        dtDaibun = daibunB.getTxtDaibunruiLeave(dtShohin.Rows[intShohinCnt]["大分類コード"].ToString());

                        //大分類名を挿入
                        dtView.Rows[intShohinCnt]["大分類名"] = dtDaibun.Rows[0]["大分類名"].ToString();

                        //中分類名の取得
                        M1110_Chubunrui_B chubunB = new M1110_Chubunrui_B();
                        dtChubun = chubunB.getTxtChubunruiLeave(dtShohin.Rows[intShohinCnt]["大分類コード"].ToString(), dtShohin.Rows[intShohinCnt]["中分類コード"].ToString());

                        //中分類名を挿入
                        dtView.Rows[intShohinCnt]["中分類名"] = dtChubun.Rows[0]["中分類名"].ToString();

                        //商品名を挿入
                        dtView.Rows[intShohinCnt]["品名"] = dtShohin.Rows[intShohinCnt]["品名"].ToString();

                        //定価を取り出す
                        string strTeika = string.Format("{0:#,0}", decimal.Parse(dtShohin.Rows[intShohinCnt]["定価"].ToString()));
                        //仕入単価を取り出す
                        string strShireTanka = string.Format("{0:#,0.00}", decimal.Parse(dtShohin.Rows[intShohinCnt]["仕入単価"].ToString()));

                        //仕入単価と定価が同じになる場合
                        if (strShireTanka == "0.00" || strTeika == "0")
                        {
                            //掛率を挿入
                            dtShohin.Rows[intShohinCnt]["掛率"] = "0";
                        }
                        else
                        {
                            //掛率を挿入
                            dtShohin.Rows[intShohinCnt]["掛率"] = ((decimal)(decimal.Parse(strShireTanka) / decimal.Parse(strTeika)) * 100).ToString("#.0");
                        }

                        //定価を挿入
                        dtShohin.Rows[intShohinCnt]["定価"] = strTeika;

                        //仕入単価を挿入
                        dtShohin.Rows[intShohinCnt]["仕入単価"] = strShireTanka;

                        //メモ挿入
                        dtView.Rows[intShohinCnt]["メモ"] = dtShohin.Rows[intShohinCnt]["メモ"].ToString();
                        
                        //SQLファイルのパスとファイル名を入れる用
                        List<string> lstSQL = new List<string>();

                        //データ渡し用
                        lstSQL.Add("Common");
                        lstSQL.Add("C_LIST_Shohin_SELECT_Zaikosu");

                        //SQL発行
                        OpenSQL opensql = new OpenSQL();

                        //SQLファイルのパス取得
                        string strSQLInput = opensql.setOpenSQL(lstSQL);

                        //パスがなければ返す
                        if (strSQLInput == "")
                        {
                            return (dtShohin);
                        }

                        //SQLファイルと該当コードでフォーマット
                        strSQLInput = string.Format(strSQLInput, dtShohin.Rows[intShohinCnt]["コード"].ToString());

                        //検索データを表示
                        dtZaiko = dbConnective.ReadSql(strSQLInput);

                        //在庫数データにある場合
                        if (dtZaiko.Rows.Count > 0)
                        {
                            //在庫数各行チェック
                            for (int intZaikoCnt = 0; intZaikoCnt < dtZaiko.Rows.Count; intZaikoCnt++)
                            {
                                //在庫数テーブル内の商品コードと商品テーブルの商品コードが一致した場合
                                if (dtView.Rows[intShohinCnt]["商品コード"].ToString() == dtZaiko.Rows[intZaikoCnt]["商品コード"].ToString())
                                {
                                    //営業所コードが0001の場合
                                    if (dtZaiko.Rows[intZaikoCnt]["営業所コード"].ToString() == "0001")
                                    {
                                        //在庫数（本社）を挿入
                                        dtView.Rows[intShohinCnt]["本社在庫"] = string.Format("{0:#,0}", Math.Floor(decimal.Parse(dtZaiko.Rows[intZaikoCnt]["在庫数"].ToString())));
                                        dtView.Rows[intShohinCnt]["本社ﾌﾘｰ"] = string.Format("{0:#,0}", Math.Floor(decimal.Parse(dtZaiko.Rows[intZaikoCnt]["フリー在庫数"].ToString())));
                                    }
                                    //0002の場合
                                    else
                                    {
                                        dtView.Rows[intShohinCnt]["岐阜在庫"] = string.Format("{0:#,0}", Math.Floor(decimal.Parse(dtZaiko.Rows[intZaikoCnt]["在庫数"].ToString())));
                                        dtView.Rows[intShohinCnt]["岐阜ﾌﾘｰ"] = string.Format("{0:#,0}", Math.Floor(decimal.Parse(dtZaiko.Rows[intZaikoCnt]["フリー在庫数"].ToString())));
                                    }

                                    //２つデータがあって且つ初回の場合
                                    if (dtZaiko.Rows.Count == 2 && blFirst == true)
                                    {
                                        blFirst = false;
                                    }
                                }
                            }

                            //初期化
                            blFirst = true;
                        }

                        //記入箇所を次の行へ移動
                        intViewCnt = intViewCnt + 1;

                        //空白行の作成
                        drInsert = dtView.NewRow();
                        drInsert["商品コード"] = "";
                        drInsert["メーカー"] = "";
                        drInsert["中分類名"] = "";
                        drInsert["品名"] = "";
                        drInsert["本社在庫"] = "";
                        drInsert["本社ﾌﾘｰ"] = "";
                        drInsert["岐阜在庫"] = "";
                        drInsert["岐阜ﾌﾘｰ"] = "";
                        drInsert["定価"] = "";
                        drInsert["掛率"] = "";
                        drInsert["仕入単価"] = "";
                        drInsert["メモ"] = "";

                        dtView.Rows.Add(drInsert);
                    }
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            return (dtShohin);
        }
                
        ///<summary>
        ///getLabel
        ///textboxのデータをlabelに記入
        ///</summary>
        public DataTable getLabel(List<string> lstString, List<int> lstint)
        {
            //SQL出力後のデータテーブル
            DataTable dtSetData = null;

            //テキストボックスのデータを確保
            string strTextCase = "";

            //データ渡し用
            List<string> lstStringSQL = new List<string>();
            OpenSQL opensql = new OpenSQL();

            //どこのDBを参照するか
            switch (lstint[0])
            {
                case CommonTeisu.FRM_DAIBUNRUI://大分類

                    if (lstString[0] == "")
                    {
                        lstString[0] = "";
                        return (dtSetData);
                    }
                    else if (lstString[0].Length == 1)
                    {
                        lstString[0] = lstString[0].ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        strTextCase = lstString[0];
                    }

                    strSQLName = "C_LIST_Daibun_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add("Common");
                    lstStringSQL.Add(strSQLName);

                    string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    string[] aryStr = { lstString[0] };

                    strSQLInput = string.Format(strSQLInput, aryStr);

                    //SQLのインスタンス作成
                    DBConnective dbconnective = new DBConnective();

                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSetData = dbconnective.ReadSql(strSQLInput);
                    break;
                case CommonTeisu.FRM_CHUBUNRUI://中分類
                    if (lstString[1] == "")
                    {
                        lstString[1] = "";
                        return (dtSetData);
                    }
                    else if (lstString[1].Length == 1)
                    {
                        strTextCase = lstString[1].ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        strTextCase = lstString[1];
                    }

                    strSQLName = "C_LIST_Chubun_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add("Common");
                    lstStringSQL.Add(strSQLName);

                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    aryStr = new string[] { lstString[0], strTextCase };

                    strSQLInput = string.Format(strSQLInput, aryStr);

                    //SQLのインスタンス作成
                    dbconnective = new DBConnective();

                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSetData = dbconnective.ReadSql(strSQLInput);
                    break;
                case CommonTeisu.FRM_MAKER://メーカー
                    if (lstString[2] == "")
                    {
                        lstString[2] = "";
                        return (dtSetData);
                    }
                    else if (lstString[2].Length <= 2)
                    {
                        strTextCase = lstString[2].ToString().PadLeft(3, '0');
                    }
                    else
                    {
                        strTextCase = lstString[2];
                    }

                    strSQLName = "M1020_Maker_SELECT_LEAVE";

                    //データ渡し用
                    lstStringSQL.Add("Common");
                    lstStringSQL.Add(strSQLName);

                    strSQLInput = opensql.setOpenSQL(lstStringSQL);

                    //配列設定
                    aryStr = new string[] { strTextCase };

                    strSQLInput = string.Format(strSQLInput, aryStr);

                    //SQLのインスタンス作成
                    dbconnective = new DBConnective();

                    //SQL文を直書き（＋戻り値を受け取る)
                    dtSetData = dbconnective.ReadSql(strSQLInput);
                    break;
                default:
                    return (dtSetData);
            }
            return (dtSetData);
        }

        ///<summary>
        ///getSelectItem
        ///各画面へのデータ渡し
        ///</summary>
        public void getSelectItem(List<int> lstInt, List<string> lstString)
        {
            List<string> lstStringItem = new List<string>();

            List<DataTable> lstDTTana = new List<DataTable>();

            DataTable dtMaker = new DataTable();
            DataTable dtDaibun = new DataTable();
            DataTable dtChubun = new DataTable();
            DataTable dtShohin = new DataTable();

            DataTable dtShohinTanaID = new DataTable();
            DataTable dtShohinTanaIDMAX = new DataTable();
            DataTable dtShohinTanaName = new DataTable();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLNameM = null;
            string strSQLNameD = null;
            string strSQLNameC = null;
            string strSQLNameS = null;

            strSQLNameM = "C_LIST_Maker_SELECT_LEAVE_NAME";
            strSQLNameD = "C_LIST_Daibun_SELECT_LEAVE_NAME";
            strSQLNameC = "C_LIST_Chubun_SELECT_LEAVE_NAME";
            strSQLNameS = "C_LIST_Shohin_SELECT_LEAVE";

            //配列設定
            string[] aryStr = { lstString[3] };

            //Makerの処理
            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLNameM);

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                OpenSQL opensql = new OpenSQL();
                string strSQLInput = opensql.setOpenSQL(lstStringSQL);

                strSQLInput = string.Format(strSQLInput, aryStr);

                dtMaker = dbconnective.ReadSql(strSQLInput);

                //大分類の処理
                lstStringSQL = new List<string>();

                string[] aryStrD = { lstString[4] };

                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLNameD);

                strSQLInput = null;

                opensql = new OpenSQL();
                strSQLInput = opensql.setOpenSQL(lstStringSQL);

                strSQLInput = string.Format(strSQLInput, aryStrD);

                dtDaibun = dbconnective.ReadSql(strSQLInput);

                //中分類の処理
                lstStringSQL = new List<string>();

                string[] aryStrC = { lstString[5] };

                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLNameC);

                strSQLInput = null;

                strSQLInput = opensql.setOpenSQL(lstStringSQL);
                strSQLInput = string.Format(strSQLInput, aryStrC);

                dtChubun = dbconnective.ReadSql(strSQLInput);

                //商品の処理
                lstStringSQL = new List<string>();

                string[] aryStrS = { lstString[2] };

                lstStringSQL.Add("Common");
                lstStringSQL.Add(strSQLNameS);

                strSQLInput = null;

                strSQLInput = opensql.setOpenSQL(lstStringSQL);
                strSQLInput = string.Format(strSQLInput, aryStrS);

                dtShohin = dbconnective.ReadSql(strSQLInput);

                //加工
                //指定日在庫、棚卸数量の小数点切りすて
                for (int cnt = 0; cnt < dtShohin.Rows.Count; cnt++)
                {
                    decimal decTyoubosuu = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["標準売価"].ToString()));
                    dtShohin.Rows[cnt]["標準売価"] = decTyoubosuu.ToString();
                    decimal decTanasuu = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["仕入単価"].ToString()));
                    dtShohin.Rows[cnt]["仕入単価"] = decTanasuu.ToString();
                    decimal decHyoka = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["評価単価"].ToString()));
                    dtShohin.Rows[cnt]["評価単価"] = decHyoka.ToString();
                    decimal decTeka = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["定価"].ToString()));
                    dtShohin.Rows[cnt]["定価"] = decTeka.ToString();
                    decimal decHako = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["箱入数"].ToString()));
                    dtShohin.Rows[cnt]["箱入数"] = decHako.ToString();
                    decimal decTatene = Math.Floor(decimal.Parse(dtShohin.Rows[cnt]["建値仕入単価"].ToString()));
                    dtShohin.Rows[cnt]["建値仕入単価"] = decTatene.ToString();
                }


                switch (lstInt[0])
                {
                    //棚卸入力
                    case CommonTeisu.FRM_TANAOROSHI:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "F0140_TanaorosiInput")
                            {
                                //データを連れてくるため、newをしないこと
                                F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                                tanaorosiinput.setShouhin(dtShohin);
                                break;
                            }
                        }
                        break;
                    case CommonTeisu.FRM_SHOHIN:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "M1030_Shohin")
                            {
                                //データを連れてくるため、newをしないこと
                                M1030_Shohin shohin = (M1030_Shohin)frm;
                                shohin.setShouhin(dtShohin);
                                break;
                            }
                        }
                        break;
                    case CommonTeisu.FRM_SHOHINMOTOCHOKAKUNIN:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "D0380_ShohinMotochoKakunin")
                            {
                                //データを連れてくるため、newをしないこと
                                D0380_ShohinMotochoKakunin shohinmotochokakunin = (D0380_ShohinMotochoKakunin)frm;
                                shohinmotochokakunin.setShouhin(dtShohin);
                                break;
                            }
                        }
                        break;
                    case CommonTeisu.FRM_JUCHUINPUT:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "A0010_JuchuInput")
                            {
                                //データを連れてくるため、newをしないこと
                                A0010_JuchuInput juchuInput = (A0010_JuchuInput)frm;
                                juchuInput.setShouhin(dtShohin);
                                break;
                            }
                        }
                        break;
                    case CommonTeisu.FRM_HACHUINPUT:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "A0100_HachuInput")
                            {
                                //データを連れてくるため、newをしないこと
                                A0100_HachuInput hachuinput = (A0100_HachuInput)frm;
                                hachuinput.setShouhin(dtShohin);
                                break;
                            }
                        }
                        break;
                    case CommonTeisu.FRM_SHOHINBETSURIEKIRITSUSETTEI:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "M1210_ShohinbetsuRiekiritsuSettei")
                            {
                                //データを連れてくるため、newをしないこと
                                M1210_ShohinbetsuRiekiritsuSettei shohinbetsuriekiritsusettei = (M1210_ShohinbetsuRiekiritsuSettei)frm;
                                shohinbetsuriekiritsusettei.setShouhin(dtShohin);
                                break;
                            }
                        }
                        break;
                    case CommonTeisu.FRM_TOKUTEIMUKESAKITANKA:
                        //全てのフォームの中から
                        foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                        {
                            //目的のフォームを探す
                            if (frm.Name == "M1160_TokuteimukesakiTanka")
                            {
                                //データを連れてくるため、newをしないこと
                                M1160_TokuteimukesakiTanka tokuteimukesakitanka = (M1160_TokuteimukesakiTanka)frm;
                                tokuteimukesakitanka.setShouhin(dtShohin);
                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///FormMove
        ///戻るボタンの処理
        ///カラム論理名
        ///</summary>
        public void FormMove(int intFrmKind)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //棚卸入力フォームを探す
                if (intFrmKind == CommonTeisu.FRM_TANAOROSHI && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setShohinClose();
                    break;
                }
                //商品フォームを探す
                else if (intFrmKind == CommonTeisu.FRM_SHOHIN && frm.Name == "M1030_Shohin")
                {
                    //データを連れてくるため、newをしないこと
                    M1030_Shohin shohin = (M1030_Shohin)frm;
                    shohin.closeShohinList();
                    break;
                }
                //商品元帳確認フォームを探す
                else if (intFrmKind == CommonTeisu.FRM_SHOHINMOTOCHOKAKUNIN && frm.Name == "D0380_ShohinMotochoKakunin")
                {
                    //データを連れてくるため、newをしないこと
                    D0380_ShohinMotochoKakunin shohinmotochokakunin = (D0380_ShohinMotochoKakunin)frm;
                    shohinmotochokakunin.setShohinClose();
                    break;
                }
                //受注入力のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_JUCHUINPUT && frm.Name == "A0010_JuchuInput")
                {
                    //データを連れてくるため、newをしないこと
                    A0010_JuchuInput juchuInput = (A0010_JuchuInput)frm;
                    juchuInput.setShohinClose();
                    break;
                }
                //発注入力のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_HACHUINPUT && frm.Name == "A0100_HachuInput")
                {
                    //データを連れてくるため、newをしないこと
                    A0100_HachuInput hachuinput = (A0100_HachuInput)frm;
                    hachuinput.closeShohinList();
                    break;
                }
                //目的のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_SHOHINBETSURIEKIRITSUSETTEI && frm.Name == "M1210_ShohinbetsuRiekiritsuSettei")
                {
                    //データを連れてくるため、newをしないこと
                    M1210_ShohinbetsuRiekiritsuSettei shohinbetsuriekiritsusettei = (M1210_ShohinbetsuRiekiritsuSettei)frm;
                    shohinbetsuriekiritsusettei.setShohinClose();
                    break;
                }
                //特定向け先単価のフォームを探す
                else if (intFrmKind == CommonTeisu.FRM_TOKUTEIMUKESAKITANKA && frm.Name == "M1160_TokuteimukesakiTanka")
                {
                    //データを連れてくるため、newをしないこと
                    M1160_TokuteimukesakiTanka tokuteimukesakitanka = (M1160_TokuteimukesakiTanka)frm;
                    tokuteimukesakitanka.setShohinClose();
                    break;
                }
            }
        }
    }
}
