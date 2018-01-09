using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Data;

namespace KATO.Business.M1490_Menukengen2
{
    class M1490_Menukengen2_B
    {
        public Tuple<string, DataTable> getKengen(string pgno)
        {
            string menuName = "";
            DataTable dtkengen = new DataTable();

            try
            {
                // DBコネクションのインスタンス生成
                DBConnective dbconnective = new DBConnective();
                // SQLのパス指定用List
                List<string> listSqlPath = new List<string>();
                listSqlPath.Add("M1490_Menukengen2");
                listSqlPath.Add("M1490_Menukengen2_SELECT");

                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = string.Format(strSqltxt, pgno);

                dtkengen = dbconnective.ReadSql(sql);

                if (dtkengen.Rows.Count != 0)
                {
                    // メニュー名取得
                    var mName = dtkengen.AsEnumerable()
                        .GroupBy(m => m["ＰＧ名"])
                        .Select(m => m.Key).ToList();

                    menuName = mName[0].ToString();

                    // メニュー名を取得できたら、dtkengenからPG名カラムを削除
                    dtkengen.Columns.Remove("ＰＧ名");
                }

            }
            catch(Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }

            return Tuple.Create(menuName, dtkengen);


        }

        public void updateKengen(DataTable dt, string pgno)
        {
            try
            {
                // DBコネクションのインスタンス生成
                DBConnective dbconnective = new DBConnective();
                // SQLのパス指定用List
                List<string> listSqlPath = new List<string>();
                listSqlPath.Add("M1490_Menukengen2");
                listSqlPath.Add("M1490_Menukengen2_UPDATE");

                OpenSQL opensql = new OpenSQL();
                // sqlファイルからSQL文を取得
                string strSqltxt = opensql.setOpenSQL(listSqlPath);
                string sql = "";

                for(int cntRow = 0; cntRow < dt.Rows.Count; cntRow++)
                {
                    string tcode = dt.Rows[cntRow]["担当者コード"].ToString();
                    string kengen = dt.Rows[cntRow]["権限"].ToString();

                    sql += string.Format(strSqltxt, kengen, tcode, pgno);
                    sql += "\n";

                    // 100行毎にコミット
                    if ((cntRow + 1) % 100 == 0)
                    {
                        dbconnective.RunSql(sql);
                        sql = "";
                    }
                }
                // 残りをコミット
                dbconnective.RunSql(sql);
            }
            catch(Exception ex)
            {
                new CommonException(ex);
                throw (ex);
            }
        }
    }
}
