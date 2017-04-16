using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Util
{
    public partial class DBConnective : Control
    {
        #region クラス変数

        private SqlConnection CON;
        private SqlCommand CM;
        private SqlDataAdapter adapter;
        private SqlTransaction tran;

        private string ConnectStr = "";

        #endregion

        public DBConnective()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        #region DB接続/切断

        /// <summary>
        /// DBに接続する
        /// </summary>
        public void DB_Connect()
        {
            ConnectStr = System.Configuration.ConfigurationManager.AppSettings["DBConnection"];

            //READ用

            CON = new SqlConnection(ConnectStr);
            CON.Open();
            CM = CON.CreateCommand();
            CM.Connection = CON;
            adapter = new SqlDataAdapter();
        }

        /// <summary>
        /// DBから切断する
        /// </summary>
        public void DB_Disconnect()
        {
            if (CON != null)
            {
                if (CON.State == ConnectionState.Open)
                {
                    CON.Close();
                }
                CON.Dispose();
                CON = null;
            }

        }

        #endregion

        #region SQL読込/実行

        /// <summary>
        /// SQLクエリを読み込み、結果に読み込んだデータを返します。(SELECT文用)
        /// </summary>
        /// <param name="sqlStr">SQLクエリ</param>
        /// <returns>取得したデータ(DataTable)</returns>
        public DataTable ReadSql(string sqlStr)
        {
            //DataTable retDt = null;
            DataTable retDt = new DataTable();
            Boolean isConnect = false;

            if ((CON == null) || (CON.State != ConnectionState.Open))
            {
                this.DB_Connect();
                isConnect = true;
            }

            if (tran == null)
            {
                adapter.SelectCommand = new SqlCommand(sqlStr, CON);
            }
            else
            {
                adapter.SelectCommand = new SqlCommand(sqlStr, CON, tran);
            }
            adapter.Fill(retDt);

            if (isConnect)
            {
                this.DB_Disconnect();
            }

            return retDt;
        }

        /// <summary>
        /// SQLクエリを実行します。(INSERT,UPDATE,DELETE用)
        /// </summary>
        /// <param name="sqlStr">SQLクエリ</param>
        public void RunSql(string sqlStr)
        {
            RunSql(sqlStr, CommandType.Text);
        }

        /// <summary>
        /// SQLクエリを実行します。(INSERT,UPDATE,DELETE用)
        /// </summary>
        /// <param name="sqlStr">SQLクエリ</param>
        /// <param name="cmdType">コマンドタイプ</param>
        public void RunSql(string sqlStr, CommandType cmdType)
        {
            Boolean isConnect = false;

            if ((CON == null) || (CON.State != ConnectionState.Open))
            {
                this.DB_Connect();
                isConnect = true;
            }

            //UPDATE INSERT DELETE 用            
            CM.CommandType = cmdType;
            CM.CommandText = sqlStr;
            CM.ExecuteNonQuery();

            if (isConnect)
            {
                this.DB_Disconnect();
            }
        }

        #endregion

        #region トランザクション

        /// <summary>
        /// トランザクションを開始します。
        /// </summary>
        public void BeginTrans()
        {
            if ((CON == null) || (CON.State != ConnectionState.Open))
            {
                this.DB_Connect();
            }
            try
            {
                tran = CON.BeginTransaction();
                CM.Transaction = tran;
            }
            catch (Exception ex)
            {
                tran = null;
                throw ex;
            }
        }

        /// <summary>
        /// ロールバックします。
        /// </summary>
        public void Rollback()
        {
            if (tran == null)
            {
                return;
            }

            try
            {
                tran.Rollback();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tran = null;
            }

        }

        /// <summary>
        /// コミットします。
        /// </summary>
        public void Commit()
        {
            if (tran == null)
            {
                return;
            }

            try
            {
                tran.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        #endregion


    }
}
