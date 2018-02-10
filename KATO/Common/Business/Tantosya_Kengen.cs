using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KATO.Common.Util;

namespace KATO.Common.Business
{
    class Tantosya_Kengen
    {
        /// <summary>
        ///     マスタ権限フラグ
        ///     0:権限なし
        ///     1:権限あり
        /// </summary>
        public string master { get; set; }
        /// <summary>
        ///     閲覧権限フラグ
        ///     0:権限なし
        ///     1:権限あり
        /// </summary>
        public string etsuran { get; set; }
        /// <summary>
        ///     利益率権限フラグ
        ///     0:権限なし
        ///     1:権限あり
        /// </summary>
        public string riekiritsu { get; set; }
        /// <summary>
        ///     開発者用フラグ(App.configにて設定)
        ///     0:権限なし
        ///     1:権限あり
        /// </summary>
        public string admin = System.Configuration.ConfigurationManager.AppSettings["adminflg"];

        // 2018/02/05 Add
        // 営業所コード、グループコード追加
        /// <summary>
        ///     営業所コード
        /// </summary>
        public string eigyocd { get; set; }
        /// <summary>
        ///     グループコード
        /// </summary>
        public string groupcd { get; set; }

        // コンストラクタ内で処理
        public Tantosya_Kengen(string loginId)
        {
            DataTable dtKengen = new DataTable();

            // SQLのパス指定用List
            List<string> listSqlPath = new List<string>();
            listSqlPath.Add("Common");
            listSqlPath.Add("C_TantoshaKengen_Select");

            DBConnective dbconnective = new DBConnective();

            try
            {
                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, loginId);

                // SELECT結果をDataTableへ
                dtKengen = dbconnective.ReadSql(sql);

                if (dtKengen.Rows.Count != 0)
                {
                    master = dtKengen.Rows[0]["マスタ権限"].ToString();
                    etsuran = dtKengen.Rows[0]["閲覧権限"].ToString();
                    riekiritsu = dtKengen.Rows[0]["利益率権限"].ToString();
                    eigyocd = dtKengen.Rows[0]["営業所コード"].ToString();
                    groupcd = dtKengen.Rows[0]["グループコード"].ToString();
                }
                else
                {
                    master = "0";
                    etsuran = "0";
                    riekiritsu = "0";
                    eigyocd = "0000";
                    groupcd = "0000";

                }

            }
            catch
            {
                throw;
            }
            finally
            {
                dbconnective.DB_Disconnect();
            }
        }

    }
} 


