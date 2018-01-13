using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Data;

namespace KATO.Business.B1510_SeikyuRireki_B
{
    /// <summary>
    /// B1510_SeikyuRireki_B
    /// 請求履歴ビジネス層
    /// 作成者：大河内
    /// 作成日：2017/06/26
    /// 更新者：
    /// 更新日：
    /// カラム論理名
    class B1510_SeikyuRireki_B
    {
        ///<summary>
        ///getGridRirekiTokui
        ///請求履歴を取得（得意先コードからの場合）
        ///引数　：検索データ
        ///戻り値：検索結果（DataTable）
        ///</summary>
        public DataTable getGridRirekiTokui(List<string> lstSeikyuRireki)
        {
            DataTable dtSeikyuRireki = new DataTable();

            //SQLファイルのパスとファイル名を入れる用
            List<string> lstSQL = new List<string>();

            //SQLファイルのパス用（フォーマット後）
            string strSQLInput = "";

            //WHERE分を入れる用
            List<string> lstStringSQL = new List<string>();

            //リスト内データにデータがあるかどうか
            Boolean blListDataNull = true;

            //リスト分ループ
            for (int intCnt = 0; intCnt < lstSeikyuRireki.Count; intCnt++)
            {
                //空でない場合
                if (lstSeikyuRireki[intCnt] != "")
                {
                    //空ではない判定
                    blListDataNull = false;
                    break;
                }
            }

            //リスト内が空でない場合
            if (blListDataNull == false)
            {
                lstStringSQL.Add("WHERE ");

                //伝票年月日（開始）がある場合
                if (lstSeikyuRireki[0] != "")
                {
                    lstStringSQL.Add("請求年月日 >= '" + lstSeikyuRireki[0] + "' ");
                }
                else
                {
                    lstStringSQL.Add("");
                }

                //伝票年月日（終了）がある場合
                if (lstSeikyuRireki[1] != "")
                {
                    //伝票年月日（開始）がある場合
                    if (lstSeikyuRireki[0] != "")
                    {
                        lstStringSQL.Add("AND 請求年月日 <= '" + lstSeikyuRireki[1] + "' ");
                    }
                    else
                    {
                        lstStringSQL.Add("請求年月日 <= '" + lstSeikyuRireki[1] + "' ");
                    }
                }
                else
                {
                    lstStringSQL.Add("");
                }

                //得意先コードがある場合
                if (lstSeikyuRireki[2] != "")
                {
                    //伝票年月日（開始）か伝票年月日（開始）がある場合
                    if (lstSeikyuRireki[0] != "" || lstSeikyuRireki[1] != "")
                    {
                        lstStringSQL.Add("AND 得意先コード = '" + lstSeikyuRireki[2] + "' ");
                    }
                    else
                    {
                        lstStringSQL.Add("得意先コード = '" + lstSeikyuRireki[2] + "' ");
                    }

                }
                else
                {
                    lstStringSQL.Add("");
                }
            }
            else
            {
                lstStringSQL.Add("");   //[0]
                lstStringSQL.Add("");   //[1]
                lstStringSQL.Add("");   //[2]
                lstStringSQL.Add("");   //[3]
            }

            //SQLファイルのパスとファイル名を追加
            lstSQL.Add("B1510_SeikyuRireki");
            lstSQL.Add("SeikyuRireki_SELECT_SetDataGridView");

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
                    return (dtSeikyuRireki);
                }

                //SQLファイルと該当コードでフォーマット
                strSQLInput = string.Format(strSQLInput,
                                            lstStringSQL[0],   //WHERE
                                            lstStringSQL[1],   //伝票年月日（開始）
                                            lstStringSQL[2],   //伝票年月日（終了）
                                            lstStringSQL[3]    //得意先コード
                                            );
                //データ取得（ここから取得）
                dtSeikyuRireki = dbconnective.ReadSql(strSQLInput);
            }
            catch (Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
            finally
            {
                //トランザクション終了
                dbconnective.DB_Disconnect();
            }
            return (dtSeikyuRireki);
        }
    }
}
