﻿using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.M1030_Shohin
{
    ///<summary>
    ///M1030_Shohin_B
    ///商品フォーム
    ///作成者：大河内
    ///作成日：2017/05/01
    ///更新者：大河内
    ///更新日：2018/01/24
    ///カラム論理名
    ///</summary>
    class M1030_Shohin_B
    {
        ///<summary>
        ///addShohin
        ///テキストボックス内のデータをDBに登録
        ///</summary>
        public void addShohin(List<string> lstString, Boolean blnKanri)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] {
                    lstString[0],                    //商品コード
                    lstString[1],                    //メーカーコード
                    lstString[2],                    //大分類コード
                    lstString[3],                    //中分類コード
                    lstString[4],                    //Ｃ１
                    lstString[5],                    //Ｃ２
                    lstString[6],                    //Ｃ３
                    lstString[7],                    //Ｃ４
                    lstString[8],                    //Ｃ５
                    lstString[9],                    //Ｃ６
                    "",                              //発注区分
                    lstString[10],                   //標準売価
                    lstString[11],                   //仕入単価
                    lstString[12],                   //在庫管理区分
                    lstString[13],                   //棚番本社
                    lstString[14],                   //棚番岐阜
                    lstString[15],                   //メモ
                    lstString[16],                   //評価単価
                    lstString[17],                   //定価
                    lstString[18],                   //箱入数
                    lstString[19],                   //建値仕入単価
                    lstString[20],                   //コメント
                    "N",                             //削除
                    DateTime.Now.ToString(),         //登録日時
                    lstString[21],                   //登録ユーザー名
                    DateTime.Now.ToString(),         //更新日時
                    lstString[21]                    //更新ユーザー名
                };

                //マスタ権限の場合
                if (blnKanri == true)
                {
                    dbconnective.RunSqlCommon(CommonTeisu.C_SQL_SHOHIN_UPD, aryStr);

                    //SQL実行時に取り出したデータを入れる用
                    DataTable dtTantoshaCd = new DataTable();

                    //SQLファイルのパスとファイル名を入れる用
                    List<string> lstSQL = new List<string>();

                    //SQLファイルのパス用（フォーマット後）
                    string strSQLInput = "";

                    //SQLファイルのパスとファイル名を追加
                    lstSQL.Add("M1030_Shohin");
                    lstSQL.Add("Shohin_KariToroku_UPDATE");

                    //SQL発行
                    OpenSQL opensql = new OpenSQL();

                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQL);

                    //パスがなければ返す
                    if (strSQLInput == "")
                    {
                        return;
                    }

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput,
                                                lstString[0]   //商品コード
                                                );

                    //仮商品データ更新（削除フラグを立てる）
                    dbconnective.RunSql(strSQLInput);
                }
                else
                {
                    dbconnective.RunSqlCommon(CommonTeisu.C_SQL_SHOHIN_KARI_UPD, aryStr);
                }

                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();

                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///delShohin
        ///テキストボックス内のデータをDBから削除
        ///</summary>
        public void delShohin(List<string> lstString , Boolean blHontorokuData)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                string[] aryStr = new string[] {
                    lstString[0],                     //商品コード
                    lstString[1],                     //メーカーコード
                    lstString[2],                     //大分類コード
                    lstString[3],                     //中分類コード
                    lstString[4],                     //Ｃ１
                    lstString[5],                     //Ｃ２
                    lstString[6],                     //Ｃ３
                    lstString[7],                     //Ｃ４
                    lstString[8],                     //Ｃ５
                    lstString[9],                     //Ｃ６
                    "",                               //発注区分
                    lstString[10],                    //標準売価
                    lstString[11],                    //仕入単価
                    lstString[12],                    //在庫管理区分
                    lstString[13],                    //棚番本社
                    lstString[14],                    //棚番岐阜
                    lstString[15],                    //メモ
                    lstString[16],                    //評価単価
                    lstString[17],                    //定価
                    lstString[18],                    //箱入数
                    lstString[19],                    //建値仕入単価
                    lstString[20],                    //コメント
                    "Y",                              //削除
                    DateTime.Now.ToString(),          //登録日時
                    lstString[21],                    //登録ユーザー名
                    DateTime.Now.ToString(),          //更新日時
                    lstString[21]                     //更新ユーザー名
                };

                //本登録データの場合
                if (blHontorokuData)
                {
                    dbconnective.RunSqlCommon(CommonTeisu.C_SQL_SHOHIN_UPD, aryStr);
                }
                else
                {
                    dbconnective.RunSqlCommon(CommonTeisu.C_SQL_SHOHIN_KARI_UPD, aryStr);
                }

                dbconnective.Commit();
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();

                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getShohin
        ///商品コードから商品データを取得（編集登録メッセージ表示用）
        ///</summary>
        public DataTable getShohin(string strShohinCd, Boolean blHontorokuData)
        {
            DataTable dtShohin = new DataTable();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            //商品の処理
            lstStringSQL = new List<string>();

            lstStringSQL.Add("M1030_Shohin");

            //本登録データの場合
            if (blHontorokuData)
            {
                lstStringSQL.Add("Shohin_Data_SELECT");
            }
            else
            {
                lstStringSQL.Add("Shohin_DataKari_SELECT");
            }

            OpenSQL opensql = new OpenSQL();

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                string strSQLSelect = opensql.setOpenSQL(lstStringSQL);

                //パスがなければ返す
                if (strSQLSelect == "")
                {
                    return (dtShohin);
                }

                strSQLSelect = string.Format(strSQLSelect, strShohinCd); //商品コード

                dtShohin = dbconnective.ReadSql(strSQLSelect);

                return (dtShohin);
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
        ///getNewShohinNo
        ///商品番号の取得
        ///</summary>
        public string getNewShohinNo()
        {
            //伝票番号取得用のPROC用
            object objDummy = 0;
            object objReturnval = "";

            //新規商品コードを入れる用
            string strCdHEAD = "";
            string strCdHEAD2 = "";
            //新規伝票番号を入れる用
            string strDenNo = "";
            string strDenNo2 = "";

            //伝票番号PROCより確保した頭文字以外の伝票番号
            int intGetNo = 0;

            //出力する伝票番号
            string strGetDenpyo = "";

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("M1030_Shohin");
            lstSQL.Add("Shohin_CdMAX_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //伝票番号取得用（名前）
            List<String> lstGetDenpyoNoName = new List<string>();

            //伝票番号取得用（データ）
            List<string> lstSearchData = new List<string>();

            lstGetDenpyoNoName.Add("@テーブル名");

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (strGetDenpyo);
                }

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //データの中身がない場合
                if (dtSetCd_B.Rows[0][0].ToString() == "")
                {
                    return strGetDenpyo;
                }
                
                strCdHEAD = dtSetCd_B.Rows[0][0].ToString().Substring(0, 1);

                //頭文字によって動作を変える
                switch (strCdHEAD)
                {
                    case "A":
                        strCdHEAD2 = "B";
                        strDenNo = "商品コード２";
                        strDenNo2 = "商品コード３";
                        break;
                    case "B":
                        strCdHEAD2 = "C";
                        strDenNo = "商品コード３";
                        strDenNo2 = "商品コード４";
                        break;
                    case "C":
                        strCdHEAD2 = "D";
                        strDenNo = "商品コード４";
                        strDenNo2 = "商品コード５";
                        break;
                    case "D":
                        strCdHEAD2 = "E";
                        strDenNo = "商品コード５";
                        strDenNo2 = "商品コード６";
                        break;
                    case "E":
                        strCdHEAD2 = "F";
                        strDenNo = "商品コード６";
                        strDenNo2 = "商品コード７";
                        break;
                    case "F":
                        strCdHEAD2 = "G";
                        strDenNo = "商品コード７";
                        strDenNo2 = "商品コード８";
                        break;
                    case "G":
                        strCdHEAD2 = "H";
                        strDenNo = "商品コード８";
                        strDenNo2 = "商品コード９";
                        break;
                    case "H":
                        strCdHEAD2 = "I";
                        strDenNo = "商品コード９";
                        strDenNo2 = "商品コード１０";
                        break;
                    case "I":
                        strCdHEAD2 = "J";
                        strDenNo = "商品コード１０";
                        strDenNo2 = "商品コード１１";
                        break;
                    case "J":
                        strCdHEAD2 = "K";
                        strDenNo = "商品コード１１";
                        strDenNo2 = "商品コード１２";
                        break;
                    case "K":
                        strCdHEAD2 = "L";
                        strDenNo = "商品コード１２";
                        strDenNo2 = "商品コード１３";
                        break;
                    case "L":
                        strCdHEAD2 = "M";
                        strDenNo = "商品コード１３";
                        strDenNo2 = "商品コード１４";
                        break;
                    case "M":
                        strCdHEAD2 = "N";
                        strDenNo = "商品コード１４";
                        strDenNo2 = "商品コード１５";
                        break;
                    case "N":
                        strCdHEAD2 = "O";
                        strDenNo = "商品コード１５";
                        strDenNo2 = "商品コード１６";
                        break;
                    case "O":
                        strCdHEAD2 = "P";
                        strDenNo = "商品コード１６";
                        strDenNo2 = "商品コード１７";
                        break;
                    case "P":
                        strCdHEAD2 = "Q";
                        strDenNo = "商品コード１７";
                        strDenNo2 = "商品コード１８";
                        break;
                    case "Q":
                        strCdHEAD2 = "R";
                        strDenNo = "商品コード１８";
                        strDenNo2 = "商品コード１９";
                        break;
                    case "R":
                        strCdHEAD2 = "S";
                        strDenNo = "商品コード１９";
                        strDenNo2 = "商品コード２０";
                        break;
                    case "S":
                        strCdHEAD2 = "T";
                        strDenNo = "商品コード２０";
                        strDenNo2 = "商品コード２１";
                        break;
                    case "T":
                        strCdHEAD2 = "U";
                        strDenNo = "商品コード２１";
                        strDenNo2 = "商品コード２２";
                        break;
                    case "U":
                        strCdHEAD2 = "V";
                        strDenNo = "商品コード２２";
                        strDenNo2 = "商品コード２３";
                        break;
                    case "V":
                        strCdHEAD2 = "W";
                        strDenNo = "商品コード２３";
                        strDenNo2 = "商品コード２４";
                        break;
                    case "W":
                        strCdHEAD2 = "X";
                        strDenNo = "商品コード２４";
                        strDenNo2 = "商品コード２５";
                        break;
                    case "X":
                        strCdHEAD2 = "B";
                        strDenNo = "商品コード２５";
                        strDenNo2 = "商品コード２６";
                        break;
                    case "Y":
                        strCdHEAD2 = "B";
                        strDenNo = "商品コード２６";
                        strDenNo2 = "商品コード２７";
                        break;
                    case "Z":
                        strGetDenpyo = "0";
                        break;
                }

                //頭文字がZの場合
                if (strGetDenpyo == "0")
                {
                    return strGetDenpyo;
                }

                //頭文字以降の数値が9999以上の場合
                if (int.Parse(dtSetCd_B.Rows[0][0].ToString().Substring(1)) >= 9999)
                {
                    strCdHEAD = strCdHEAD2;
                    strDenNo = strDenNo2;
                }

                lstSearchData.Add(strDenNo);

                //伝票番号の最新を取得
                intGetNo = int.Parse(dbconnective.RunSqlRe("get伝票番号_PROC", CommandType.StoredProcedure, lstSearchData, lstGetDenpyoNoName, "@番号"));

                //0パディングと頭文字を追加
                strGetDenpyo = strCdHEAD + string.Format("{0:0000}", intGetNo);

                return strGetDenpyo;
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
    }
}
