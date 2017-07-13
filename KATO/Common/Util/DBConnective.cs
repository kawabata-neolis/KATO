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
using static KATO.Common.Util.CommonTeisu;

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
            CM.CommandTimeout = 240;
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

        /// <summary>
        /// SQLクエリを実行します。(PROC用(戻り値無し))
        /// </summary>
        /// <param name="sqlStr">SQLクエリ</param>
        /// <param name="cmdType">コマンドタイプ</param>
        public void RunSql(string sqlStr, CommandType cmdType, List<string> lstTableName, List<string> lstDataName)
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

            //各該当データをPROCに適用
            for(int cnt = 0; cnt < lstTableName.Count; cnt++)
            {
                CM.Parameters.AddWithValue(lstDataName[cnt], lstTableName[cnt]);
            }

            CM.ExecuteNonQuery();

            if (isConnect)
            {
                this.DB_Disconnect();
            }
        }

        /// <summary>
        /// SQLクエリを実行します。(PROC用(戻り値あり))
        /// </summary>
        /// <param name="sqlStr">SQLクエリ</param>
        /// <param name="cmdType">コマンドタイプ</param>
        public string RunSqlRe(string sqlStr, CommandType cmdType, List<string> lstTableName, List<string> lstDataName)
        {
            Boolean isConnect = false;

            string strResult = null;

            if ((CON == null) || (CON.State != ConnectionState.Open))
            {
                this.DB_Connect();
                isConnect = true;
            }

            //UPDATE INSERT DELETE 用            
            CM.CommandType = cmdType;
            CM.CommandText = sqlStr;

            //各該当データをPROCに適用
            for (int cnt = 0; cnt < lstTableName.Count; cnt++)
            {
                CM.Parameters.AddWithValue(lstDataName[cnt], lstTableName[cnt]);
            }
            CM.Parameters.Add("@RetValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            CM.ExecuteNonQuery();

            strResult = CM.Parameters["@RetValue"].Value.ToString();

            if (isConnect)
            {
                this.DB_Disconnect();
            }

            return (strResult);
        }

        /// <summary>
        /// SQLクエリを実行します。(PROC用(戻り値あり))
        /// </summary>
        /// <param name="sqlStr">SQLクエリ</param>
        /// <param name="cmdType">コマンドタイプ</param>
        public string RunSqlRe(string sqlStr, CommandType cmdType, List<string> lstTableName, List<string> lstDataName, String strRet)
        {
            Boolean isConnect = false;

            string strResult = null;

            if ((CON == null) || (CON.State != ConnectionState.Open))
            {
                this.DB_Connect();
                isConnect = true;
            }

            //UPDATE INSERT DELETE 用            
            CM.CommandType = cmdType;
            CM.CommandText = sqlStr;

            //各該当データをPROCに適用
            for (int cnt = 0; cnt < lstTableName.Count; cnt++)
            {
                CM.Parameters.AddWithValue(lstDataName[cnt], lstTableName[cnt]);
            }
            CM.Parameters.Add(strRet.Substring(1), SqlDbType.Int).Direction = ParameterDirection.Output;

            //using (var sdr = CM.ExecuteReader())
            //{
            //    if (sdr.HasRows)
            //    {
            //        while (sdr.Read()) {
            //            strResult = (sdr[strRet.Substring(1)]).ToString();
            //        }
            //    }
            //}
            SqlDataReader sdr = CM.ExecuteReader();
            sdr.Close();

            strResult = CM.Parameters[strRet.Substring(1)].Value.ToString();

            if (isConnect)
            {
                this.DB_Disconnect();
            }

            return (strResult);
        }

        public DataTable RunSqlReDT(string sqlStr, CommandType cmdType, List<string> lstTableName, List<string> lstDataName, String strRet)
        {
            Boolean isConnect = false;

            DataTable dtResult = null;

            if ((CON == null) || (CON.State != ConnectionState.Open))
            {
                this.DB_Connect();
                isConnect = true;
            }

            //UPDATE INSERT DELETE 用            
            CM.CommandType = cmdType;
            CM.CommandText = sqlStr;

            //各該当データをPROCに適用
            for (int cnt = 0; cnt < lstTableName.Count; cnt++)
            {
                CM.Parameters.AddWithValue(lstDataName[cnt], lstTableName[cnt]);
            }
            if (strRet != null && string.IsNullOrWhiteSpace(strRet)) {
                CM.Parameters.Add(strRet.Substring(1), SqlDbType.Int).Direction = ParameterDirection.Output;
            }

            //using (var sdr = CM.ExecuteReader())
            //{
            //    if (sdr.HasRows)
            //    {
            //        while (sdr.Read()) {
            //            strResult = (sdr[strRet.Substring(1)]).ToString();
            //        }
            //    }
            //}
            //SqlDataReader sdr = CM.ExecuteReader();

            //strResult.Load(sdr);

            //sdr.Close();

            DataSet dataSet = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(CM))
            {
                adapter.Fill(dataSet);
            }

            dtResult = dataSet.Tables[0];

            if (isConnect)
            {
                this.DB_Disconnect();
            }

            return (dtResult);
        }

        public void RunSqlCommon(String strSqlName, String[] prms)
        {
            Boolean isConnect = false;

            if ((CON == null) || (CON.State != ConnectionState.Open))
            {
                this.DB_Connect();
                isConnect = true;
            }

            List<string> lstStringSQL = new List<string>();

            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSqlName);

            OpenSQL opensql = new OpenSQL();
            string sqlStr = opensql.setOpenSQL(lstStringSQL);

            SqlDbType[] types = CommonTeisu.paramDic[strSqlName];

            //UPDATE INSERT DELETE 用            
            CM.CommandType = CommandType.Text;
            CM.CommandText = sqlStr;
            CM.Parameters.Clear();

            for (int intPrmCnt = 0; intPrmCnt < prms.Count(); intPrmCnt++)
            {
                SetSqlParam("@p" + intPrmCnt.ToString(), types[intPrmCnt], prms[intPrmCnt]);
            }

            CM.ExecuteNonQuery();


            if (isConnect)
            {
                this.DB_Disconnect();
            }
        }

        public void SetSqlParam(string ParameterName, SqlDbType type, Object value)
        {
            SqlParameter param = CM.CreateParameter();
            param.ParameterName = ParameterName;
            param.SqlDbType = type;
            param.Direction = ParameterDirection.Input;
            param.Value = value;
            CM.Parameters.Add(param);
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
