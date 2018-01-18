﻿using ClosedXML.Excel;
using KATO.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace KATO.Business.A1520_Uriageshonin_B
{
    ///<summary>
    ///A1520_Uriageshonin_B
    ///売上承認のビジネス層
    ///作成者：大河内
    ///作成日：2017/5/1
    ///更新者：大河内
    ///更新日：2017/5/1
    ///カラム論理名
    ///</summary>
    class A1520_Uriageshonin_B
    {
        ///<summary>
        ///getViewGridHenpin
        ///返品値引分売上承認入力データの取得
        ///</summary>
        public DataTable getViewGridHenpin(int intShonin)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //分岐WHERE分用
            string strShonin = "";

            //表示範囲によって分岐
            if (intShonin == 0)
            {
                strShonin = "";
            }
            else if (intShonin == 1)
            {
                strShonin = "AND dbo.f_get返品値引売上承認フラグ(受注番号)=0";
            }
            else
            {
                strShonin = "AND dbo.f_get返品値引売上承認フラグ(受注番号)=1";
            }

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A1520_Uriageshonin");
            lstSQL.Add("Uriageshonin_Henpinnebiki_Grid_SELECT");

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
                strSQLInput = string.Format(strSQLInput, strShonin);

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
        ///getViewGridRireki
        ///利益率承認データの取得
        ///</summary>
        public DataTable getViewGridRireki(int intShonin)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //分岐WHERE分用
            string strShonin = "";

            //表示範囲によって分岐
            if (intShonin == 0)
            {
                strShonin = "";
            }
            else if (intShonin == 1)
            {
                strShonin = "AND 承認フラグ = 0 ";
            }
            else
            {
                strShonin = "AND 承認フラグ = 1 ";
            }

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A1520_Uriageshonin");
            lstSQL.Add("Uriageshonin_Riekiritsu_SELECT");

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
                strSQLInput = string.Format(strSQLInput, strShonin);

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
        ///getViewGridUriage
        ///売上削除承認入力データの取得
        ///</summary>
        public DataTable getViewGridUriage(List<string> lstViewGrid)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //分岐WHERE分用
            string strShonin = "";

            //表示範囲によって分岐
            if (lstViewGrid[0] == "0")
            {
                strShonin = "";
            }
            else if (lstViewGrid[0] == "1")
            {
                strShonin = "AND e.承認 = 'N'";
            }
            else
            {
                strShonin = "AND e.承認 = 'Y'";
            }

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("A1520_Uriageshonin");
            lstSQL.Add("Uriageshonin_Uriagesakujo_Grid_SELECT");

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
                strSQLInput = string.Format(strSQLInput, lstViewGrid[1], lstViewGrid[2], strShonin);

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
        ///updHenpinNebiki
        ///売上削除承認入力データの取得
        ///</summary>
        public void updHenpinNebiki(List<string> lstGrid)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQLSelect = new List<string>();
            List<string> lstSQLInsert = new List<string>();
            List<string> lstSQLUpdate = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQLSelect.Add("A1520_Uriageshonin");
            lstSQLSelect.Add("Uriageshonin_Henpinnebiki_SELECT");

            lstSQLInsert.Add("A1520_Uriageshonin");
            lstSQLInsert.Add("Uriageshonin_Henpinnebiki_INSERT");

            lstSQLUpdate.Add("A1520_Uriageshonin");
            lstSQLUpdate.Add("Uriageshonin_Henpinnebiki_UPDATE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQLSelect);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstGrid[0]);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //データがなければ
                if (dtSetCd_B.Rows.Count == 0)
                {
                    //INSERT
                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQLInsert);

                    //パスがなければ返す
                    if (strSQLInput == "")
                    {
                        return;
                    }

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput, lstGrid[0],    //受注番号
                                                             lstGrid[1],    //承認フラグ
                                                             lstGrid[2],    //登録日時
                                                             lstGrid[3],    //登録ユーザー名
                                                             lstGrid[2],    //更新日時
                                                             lstGrid[3]);   //更新ユーザー名

                    //SQL接続後、該当データを追加
                    dbconnective.RunSql(strSQLInput);

                }
                else
                {
                    //UPDATE
                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQLUpdate);

                    //パスがなければ返す
                    if (strSQLInput == "")
                    {
                        return;
                    }

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput, lstGrid[0],    //受注番号
                                                             lstGrid[1],    //承認フラグ
                                                             lstGrid[2],    //更新日時
                                                             lstGrid[3]);   //更新ユーザー名

                    //SQL接続後、該当データを更新
                    dbconnective.RunSql(strSQLInput);

                }


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
        ///updUriagesakujo
        ///売上削除承認入力データの取得
        ///</summary>
        public void updUriagesakujo(List<string> lstGrid)
        {
            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQLSelect = new List<string>();
            List<string> lstSQLUpdate = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //SQLファイルのパスとファイル名を追加
            lstSQLSelect.Add("A1520_Uriageshonin");
            lstSQLSelect.Add("Uriageshonin_Uriagesakujo_SELECT");

            lstSQLUpdate.Add("A1520_Uriageshonin");
            lstSQLUpdate.Add("Uriageshonin_Uriagesakujo_UPDATE");

            //SQL実行時に取り出したデータを入れる用
            DataTable dtSetCd_B = new DataTable();

            //SQL接続
            OpenSQL opensql = new OpenSQL();

            //接続用クラスのインスタンス作成
            DBConnective dbconnective = new DBConnective();
            try
            {
                //SQLファイルのパス取得
                strSQLInput = opensql.setOpenSQL(lstSQLSelect);

                //パスがなければ返す
                if (strSQLInput == "")
                {
                    return;
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput, lstGrid[0]);

                //SQL接続後、該当データを取得
                dtSetCd_B = dbconnective.ReadSql(strSQLInput);

                //データがなければ(売上削除承認テーブルにデータがないものは表示していないため起きない)
                if (dtSetCd_B.Rows.Count == 0)
                {
                    return;
                }
                else
                {
                    //UPDATE
                    //SQLファイルのパス取得
                    strSQLInput = opensql.setOpenSQL(lstSQLUpdate);

                    //パスがなければ返す
                    if (strSQLInput == "")
                    {
                        return;
                    }

                    //SQLファイルと該当コードでフォーマット
                    strSQLInput = string.Format(strSQLInput, lstGrid[0],    //受注番号
                                                             lstGrid[1],    //承認フラグ
                                                             lstGrid[2],    //更新日時
                                                             lstGrid[3]);   //更新ユーザー名

                    //SQL接続後、該当データを更新
                    dbconnective.RunSql(strSQLInput);

                }
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
    }
}
