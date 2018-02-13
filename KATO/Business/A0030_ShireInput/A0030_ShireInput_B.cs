using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Form.A0030_ShireInput;

namespace KATO.Business.A0030_ShireInput
{
    ///<summary>
    ///A0030_ShireInput_B
    ///仕入入力のビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class A0030_ShireInput_B
    {
        ///<summary>
        ///delShireInput
        ///仕入入力情報の削除
        ///</summary>
        public void delShireInput(string strDenpyoNo, string strUserID)
        {
            string strSQL = null;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //トランザクション開始
            dbconnective.BeginTrans();
            try
            {
                strSQL = "仕入ヘッダ削除_PROC '" + strDenpyoNo + "','" + strUserID + "'";
                dbconnective.ReadSql(strSQL);

                strSQL = "発注_仕入数_戻し更新_PROC '" + strDenpyoNo + "','" + strUserID + "'";
                dbconnective.ReadSql(strSQL);

                strSQL = "仕入明細削除_PROC '" + strDenpyoNo + "','" + strUserID + "'";
                dbconnective.ReadSql(strSQL);

                strSQL = "運賃消去_PROC '" + strDenpyoNo + "'";
                dbconnective.ReadSql(strSQL);

                //コミット開始
                dbconnective.Commit();

                return;
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw (ex);
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getShireHeader
        ///仕入ヘッダテーブル上のデータを確保
        ///</summary>
        public DataTable getShireHeader(string strDenpyoNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_ShireHeader_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strDenpyoNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getKenshuShire
        ///仕入ヘッダテーブル上のデータを確保
        ///</summary>
        public DataTable getKenshuShire(string strDenpyoNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_KenshuzumiShire_SELECT_COUNT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strDenpyoNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getShireMesai
        ///仕入ヘッダテーブル上のデータを確保
        ///</summary>
        public DataTable getShireMesai(string strDenpyoNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_Shiremeisai_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strDenpyoNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///strJuchuNo
        ///受注番号から得意先名を取得
        ///</summary>
        public DataTable getJuchuTokusaikimei(string strJuchuNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_JuchuTokusaikimei_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strJuchuNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getHachuJuchu
        ///発注受注データを記入
        ///</summary>
        public DataTable getHachuJuchu(string strHNo)
        {
            DataTable dtHachuJuchu;

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                dtHachuJuchu = dbconnective.ReadSql("SELECT dbo.f_get発注番号_受注番号FROM発注('" + strHNo + "')");

                return dtHachuJuchu;
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
        ///getJuchuTanka
        ///受注単価データを記入
        ///</summary>
        public DataTable getJuchuTanka(string strJuchuNo)
        {
            DataTable dtHachuJuchu;

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                dtHachuJuchu = dbconnective.ReadSql("SELECT dbo.f_get受注番号から受注単価('" + strJuchuNo + "')");

                return dtHachuJuchu;
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
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_ShohinCdMAX_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //伝票番号取得用（名前）
            List<String> lstGetDenpyoNoName = new List<string>();

            //伝票番号取得用（データ）
            List<string> lstSearchData = new List<string>();

            lstGetDenpyoNoName.Add("@テーブル名");
            //lstGetDenpyoNoName.Add("@番号");

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

                strCdHEAD =  dtSetCd_B.Rows[0][0].ToString().Substring(0,1);

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

        ///<summary>
        ///getDenpyoNo
        ///伝票番号の取得
        ///</summary>
        public int getDenpyoNo(string strTableName)
        {
            //出力するデータ用
            int intDenpyoNo = 0;

            List<string> lstGetData = new List<string>();
            lstGetData.Add(strTableName);
            
            List<string> lstGateDataName = new List<string>();
            lstGateDataName.Add("テーブル名");

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                intDenpyoNo = int.Parse(dbconnective.RunSqlRe("get伝票番号_PROC", CommandType.StoredProcedure, lstGetData, lstGateDataName, "@番号"));

                return intDenpyoNo;
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
        ///addShire
        ///仕入入力データ登録
        ///</summary>
        public void addShire(List<string> lstSaveData)
        {
            //仕入ヘッダ更新用（名前）
            List<String> lstSaveDataName = new List<string>();

            lstSaveDataName.Add("@伝票番号");
            lstSaveDataName.Add("@伝票年月日");
            lstSaveDataName.Add("@仕入先コード");
            lstSaveDataName.Add("@仕入先名");
            lstSaveDataName.Add("@郵便番号");
            lstSaveDataName.Add("@住所１");
            lstSaveDataName.Add("@住所２");
            lstSaveDataName.Add("@取引区分");
            lstSaveDataName.Add("@担当者コード");
            lstSaveDataName.Add("@営業所コード");
            lstSaveDataName.Add("@摘要コード");
            lstSaveDataName.Add("@摘要欄");
            lstSaveDataName.Add("@運賃");
            lstSaveDataName.Add("@税抜合計金額");
            lstSaveDataName.Add("@消費税");
            lstSaveDataName.Add("@税込合計金額");
            lstSaveDataName.Add("@直送先コード");
            lstSaveDataName.Add("@直送先名");
            lstSaveDataName.Add("@直送先郵便番号");
            lstSaveDataName.Add("@直送先住所１");
            lstSaveDataName.Add("@直送先住所２");
            lstSaveDataName.Add("@ユーザー名");

            //発注_仕入数_戻し更新用（名前）
            List<String> lstSaveDataNameHachu = new List<string>();
            lstSaveDataNameHachu.Add("@伝票番号");
            lstSaveDataNameHachu.Add("@ユーザー名");

            //発注_仕入数_戻し更新用（データ）
            List<String> lstSaveDataHachu = new List<string>();
            //伝票番号
            lstSaveDataHachu.Add(lstSaveData[0]);
            //ユーザー名
            lstSaveDataHachu.Add(lstSaveData[21]);

            //仕入明細消去（名前）
            List<String> lstSaveDataNameShokyo = new List<string>();
            lstSaveDataNameShokyo.Add("@伝票番号");

            //仕入明細消去（データ）
            List<String> lstSaveDataShokyo = new List<string>();
            //伝票番号
            lstSaveDataShokyo.Add(lstSaveData[0]);
            try
            {
                DBConnective dbconnective = new DBConnective();
                //仕入ヘッダ更新
                dbconnective.RunSql("仕入ヘッダ更新_PROC", CommandType.StoredProcedure, lstSaveData, lstSaveDataName);

                //発注_仕入数_戻し更新
                dbconnective.RunSql("発注_仕入数_戻し更新_PROC", CommandType.StoredProcedure, lstSaveDataHachu, lstSaveDataNameHachu);

                //仕入明細消去_PROC
                dbconnective.RunSql("仕入明細消去_PROC", CommandType.StoredProcedure, lstSaveDataShokyo, lstSaveDataNameShokyo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///addMasterKoshin
        ///商品マスタ更新
        ///</summary>
        public void addMasterKoshin(List<string> lstMasterKoshin)
        {
            //商品マスタ更新用（名前）
            List<String> lstMasterKoshinName = new List<string>();

            lstMasterKoshinName.Add("@商品コード");
            lstMasterKoshinName.Add("@メーカーコード");
            lstMasterKoshinName.Add("@大分類コード");
            lstMasterKoshinName.Add("@中分類コード");
            lstMasterKoshinName.Add("@Ｃ１");
            lstMasterKoshinName.Add("@Ｃ２");
            lstMasterKoshinName.Add("@Ｃ３");
            lstMasterKoshinName.Add("@Ｃ４");
            lstMasterKoshinName.Add("@Ｃ５");
            lstMasterKoshinName.Add("@Ｃ６");
            lstMasterKoshinName.Add("@発注区分");
            lstMasterKoshinName.Add("@標準売価");
            lstMasterKoshinName.Add("@仕入単価");
            lstMasterKoshinName.Add("@在庫管理区分");
            lstMasterKoshinName.Add("@棚番本社");
            lstMasterKoshinName.Add("@棚番岐阜");
            lstMasterKoshinName.Add("@メモ");
            lstMasterKoshinName.Add("@評価単価");
            lstMasterKoshinName.Add("@定価");
            lstMasterKoshinName.Add("@箱入数");
            lstMasterKoshinName.Add("@建値仕入単価");
            lstMasterKoshinName.Add("@コメント");
            lstMasterKoshinName.Add("@ユーザー名");

            try
            {
                DBConnective dbCon = new DBConnective();
                //仕入ヘッダ更新
                dbCon.RunSql("商品マスタ更新_PROC", CommandType.StoredProcedure, lstMasterKoshin, lstMasterKoshinName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///addShireMesaiKoshin
        ///仕入明細更新
        ///</summary>
        public void addShireMesaiKoshin(List<string> lstShireMesaiKoshin)
        {
            //商品マスタ更新用（名前）
            List<String> lstMesaiKoshinName = new List<string>();

            lstMesaiKoshinName.Add("@伝票番号");
            lstMesaiKoshinName.Add("@行番号");
            lstMesaiKoshinName.Add("@発注番号");
            lstMesaiKoshinName.Add("@商品コード");
            lstMesaiKoshinName.Add("@メーカーコード");
            lstMesaiKoshinName.Add("@大分類コード");
            lstMesaiKoshinName.Add("@中分類コード");
            lstMesaiKoshinName.Add("@Ｃ１");
            lstMesaiKoshinName.Add("@Ｃ２");
            lstMesaiKoshinName.Add("@Ｃ３");
            lstMesaiKoshinName.Add("@Ｃ４");
            lstMesaiKoshinName.Add("@Ｃ５");
            lstMesaiKoshinName.Add("@Ｃ６");
            lstMesaiKoshinName.Add("@数量");
            lstMesaiKoshinName.Add("@仕入単価");
            lstMesaiKoshinName.Add("@仕入金額");
            lstMesaiKoshinName.Add("@備考");
            lstMesaiKoshinName.Add("@入庫倉庫");
            lstMesaiKoshinName.Add("@ユーザー名");

            try
            {
                DBConnective dbCon = new DBConnective();
                //仕入明細更新
                dbCon.RunSql("仕入明細更新_PROC", CommandType.StoredProcedure, lstShireMesaiKoshin, lstMesaiKoshinName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///addHachuTankaKoshin
        ///発注データの発注単価更新
        ///</summary>
        public void addHachuTankaKoshin(List<string> lstHachutankaKoshin)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_HachuTanka_UPDATE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstHachutankaKoshin[0], lstHachutankaKoshin[1], lstHachutankaKoshin[2]);

                //SQL接続後、該当データを取得
                dbconnective.RunSql(strSQLInput);
                
                return;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///addHachuKinKoshin
        ///発注データの発注金額更新
        ///</summary>
        public void addHachuKinKoshin(string strHachuNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_HachuKin_UPDATE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strHachuNo);

                //SQL接続後、該当データを取得
                dbconnective.RunSql(strSQLInput);

                return;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getHachuData
        ///発注データの仕入単価更新の前、データの存在確認(発注データのデータ確保)
        ///</summary>
        public DataTable getHachuData(string strHachuNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Hachu_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strHachuNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getTorihikisaki
        ///取引先データの取得
        ///</summary>
        public DataTable getTorihikisaki(string strHachuNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("Common");
            lstSQL.Add("C_LIST_Torihikisaki_SELECT_LEAVE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strHachuNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getShohinCd
        ///取引先データの取得
        ///</summary>
        public DataTable getShohinCdB(List<string> lstSetShohinData)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_ShohinCd_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstSetShohinData);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getJuchuDataCnt
        ///受注データのカウントの取得
        ///</summary>
        public DataTable getJuchuDataCnt(string strHachuNo)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_JuchuDataCnt_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strHachuNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///addShiretanka
        ///受注データの仕入単価の更新
        ///</summary>
        public void addShiretanka(List<string> lstShireTanka)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_JuchuShireTanka_UPDATE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstShireTanka[0], lstShireTanka[1]);

                //SQL接続後、該当データを取得
                dbconnective.RunSql(strSQLInput);

                return;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getKakoShireTanka
        ///取引先データの取得
        ///</summary>
        public decimal getKakoShireTanka(string strHachuNo)
        {
            //SQLファイルのパスとファイル名を入れる用(加工発注のみ用)
            List<string> lstSQLSUMKako = new List<string>();
            //SQLファイルのパスとファイル名を入れる用(出庫のみ用)
            List<string> lstSQLSUMSshuko = new List<string>();
            //SQLファイルのパスとファイル名を入れる用(入庫のみ用)
            List<string> lstSQLSUMNyuko = new List<string>();
            //SQLファイルのパスとファイル名を入れる用(受注数量のみ用)
            List<string> lstSQLJuchuSu = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //合計値を入れる用
            int intGokei = 0;

            //受注数量を入れる用
            int intJuchuSu = 0;

            //出力するデータ用
            decimal decKakohinShireTanka = 0;

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパスとファイル名を追加(加工発注SUM用)
                lstSQLSUMKako.Add("A0030_ShireInput");
                lstSQLSUMKako.Add("ShireInput_KakoShireTanka_KakoHachu_SELECT");

                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQLSUMKako);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (decKakohinShireTanka);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strHachuNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //加工発注SUMデータが一件以上ある場合
                if (dtSetCd_B.Rows.Count > 0)
                {
                    //中身がない場合
                    if (dtSetCd_B.Rows[0][0].ToString() == "")
                    {
                        dtSetCd_B.Rows[0][0] = "0";
                    }

                    //合計値に追加
                    intGokei = intGokei + int.Parse(dtSetCd_B.Rows[0][0].ToString());
                }


                //出庫分（出庫テーブル）からは取引区分４１，４３のみ
                //SQLファイルのパスとファイル名を追加(出庫SUM用)
                lstSQLSUMSshuko.Add("A0030_ShireInput");
                lstSQLSUMSshuko.Add("ShireInput_KakoShireTanka_KakoHachu_SELECT");

                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQLSUMSshuko);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (decKakohinShireTanka);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strHachuNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //出庫SUMデータが一件以上ある場合
                if (dtSetCd_B.Rows.Count > 0)
                {
                    //中身がない場合
                    if (dtSetCd_B.Rows[0][0].ToString() == "")
                    {
                        dtSetCd_B.Rows[0][0] = "0";
                    }

                    //合計値に追加
                    intGokei = intGokei + int.Parse(dtSetCd_B.Rows[0][0].ToString());
                }


                //入庫分（出庫テーブル）からは取引区分４２のみ・・・マイナスで計算
                //SQLファイルのパスとファイル名を追加(入庫SUM用)
                lstSQLSUMNyuko.Add("A0030_ShireInput");
                lstSQLSUMNyuko.Add("ShireInput_KakoShireTanka_KakoNyuko_SELECT");

                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQLSUMNyuko);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (decKakohinShireTanka);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strHachuNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //出庫SUMデータが一件以上ある場合
                if (dtSetCd_B.Rows.Count > 0)
                {
                    //中身がない場合
                    if (dtSetCd_B.Rows[0][0].ToString() == "")
                    {
                        dtSetCd_B.Rows[0][0] = "0";
                    }

                    //合計値に追加
                    intGokei = intGokei - int.Parse(dtSetCd_B.Rows[0][0].ToString());
                }


                //受注数量は
                //SQLファイルのパスとファイル名を追加(受注数量用)
                lstSQLJuchuSu.Add("Common");
                lstSQLJuchuSu.Add("C_LIST_Juchu_SELECT_LEAVE");

                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQLJuchuSu);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (decKakohinShireTanka);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strHachuNo);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //出庫SUMデータが一件以上ある場合
                if (dtSetCd_B.Rows.Count > 0)
                {
                    intJuchuSu = int.Parse(dtSetCd_B.Rows[0][0].ToString());
                }

                //Round計算式へ飛ばす
                BaseViewDataGroup bvDataGroup = new BaseViewDataGroup();

                //合計、受注数共に0以外の場合
                if (intGokei != 0 && intJuchuSu != 0)
                {
                    decKakohinShireTanka = decimal.Parse((bvDataGroup.setRound(intGokei / intJuchuSu, 0, 1)).ToString());
                }

                return (decKakohinShireTanka);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///addJuchuShohinCd
        ///受注データの商品コードの更新
        ///</summary>
        public void addJuchuShohinCd(List<string> lstJuchuShohinCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_JuchuShohinCd_UPDATE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstJuchuShohinCd[0], lstJuchuShohinCd[1], lstJuchuShohinCd[2]);

                //SQL接続後、該当データを取得
                dbconnective.RunSql(strSQLInput);

                return;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getJuchuDataCntNO
        ///受注データのカウントの取得（加工受注をしないとき用）
        ///</summary>
        public DataTable getJuchuDataCntNO(List<string> lstJuchuNoCnt)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_JuchuDataCnt_NOKako_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtSetCd_B);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstJuchuNoCnt[0], lstJuchuNoCnt[1]);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                return (dtSetCd_B);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///addJuchuShireShohin
        ///受注データの商品コードの更新
        ///</summary>
        public void addJuchuShireShohin(List<string> lstJuchuShohinCd)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_JuchuShireTankaShohinCd_UPDATE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstJuchuShohinCd[0], lstJuchuShohinCd[1], lstJuchuShohinCd[2]);

                //SQL接続後、該当データを取得
                dbconnective.RunSql(strSQLInput);

                return;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///addUnchinShokyo
        ///運賃消去
        ///</summary>
        public void addUnchinShokyo(string strDenpyoNo)
        {
            List<string> lstGetData = new List<string>();
            lstGetData.Add(strDenpyoNo);

            List<string> lstGateDataName = new List<string>();
            lstGateDataName.Add("伝票番号");

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                dbconnective.RunSqlRe("運賃消去_PROC", CommandType.StoredProcedure, lstGetData, lstGateDataName);

                return;
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
        ///addUnchinKoshin
        ///運賃更新
        ///</summary>
        public void addUnchinKoshin(List<string> lstUnchinKoshin)
        {
            List<string> lstUnchinKoshinName = new List<string>();
            lstUnchinKoshinName.Add("伝票番号");
            lstUnchinKoshinName.Add("受注番号");
            lstUnchinKoshinName.Add("運賃");
            lstUnchinKoshinName.Add("ユーザー名");

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                dbconnective.RunSqlRe("運賃更新_PROC", CommandType.StoredProcedure, lstUnchinKoshin, lstUnchinKoshinName);

                return;
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
        ///addShireUnchinKoshin
        ///運賃を仕入明細に追加
        ///</summary>
        public void addShireUnchinKoshin(List<string> lstUnchinKoshin)
        {
            List<string> lstUnchinKoshinName = new List<string>();
            lstUnchinKoshinName.Add("伝票番号");
            lstUnchinKoshinName.Add("行番号");
            lstUnchinKoshinName.Add("発注番号");
            lstUnchinKoshinName.Add("商品コード");
            lstUnchinKoshinName.Add("メーカーコード");
            lstUnchinKoshinName.Add("大分類コード");
            lstUnchinKoshinName.Add("中分類コード");
            lstUnchinKoshinName.Add("Ｃ１");
            lstUnchinKoshinName.Add("Ｃ２");
            lstUnchinKoshinName.Add("Ｃ３");
            lstUnchinKoshinName.Add("Ｃ４");
            lstUnchinKoshinName.Add("Ｃ５");
            lstUnchinKoshinName.Add("Ｃ６");
            lstUnchinKoshinName.Add("数量");
            lstUnchinKoshinName.Add("仕入単価");
            lstUnchinKoshinName.Add("仕入金額");
            lstUnchinKoshinName.Add("備考");
            lstUnchinKoshinName.Add("入庫倉庫");
            lstUnchinKoshinName.Add("ユーザー名");

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();
            try
            {
                dbconnective.RunSqlRe("仕入明細更新_PROC", CommandType.StoredProcedure, lstUnchinKoshin, lstUnchinKoshinName);
                
                //コミット開始
                dbconnective.Commit();

                return;
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
        ///getHachusu
        ///発注数の取得
        ///</summary>
        public DataTable getHachusu(string strChumonNo)
        {            
            //商品テーブルから取り出すデータ
            DataTable dtHachusu = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_HachusuCnt_SELECT");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtHachusu);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, strChumonNo);

                //SQL接続後、該当データを取得
                dtHachusu = dbconnective.ReadSql(strSQLInput);

                return (dtHachusu);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
        }

        ///<summary>
        ///getTantoshaCd
        ///担当者データの取得
        ///</summary>
        public DataTable getTantoshaCd(string strUserID)
        {
            //SQL実行時に取り出したデータを入れる用
            DataTable dtTantoshaCd = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A0030_ShireInput");
            lstSQL.Add("ShireInput_Tantosha_SELECT");

            //SQL発行
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQL);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return (dtTantoshaCd);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput,
                                            strUserID   //ログインＩＤ
                                            );

                //データ取得（ここから取得）
                dtTantoshaCd = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                //ロールバック開始
                dbconnective.Rollback();
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
            return (dtTantoshaCd);
        }
    }
}
