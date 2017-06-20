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

        ////#execSProcR() --- ストアドプロシージャをパラメータ付きで実行する（カーソル無し＆戻り値付き）
        ////UPGRADE_WARNING: ParamArray param が ByRef から ByVal に変更されました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93C6A0DC-8C99-429A-8696-35FC4DCEFCCC"' をクリックしてください。
        //public int execSProcR(string strSpName, short outputNO, object outputVal, params object[] param)
        //{
        //    // ERROR: Not supported in C#: OnErrorStatement

        //    //ADODB.Command gCmd;
        //    //ADODB.Parameter prm;
        //    short paraCount;
        //    short i;

        //    //gLog.writeLog("SQL: execSProcR Start... [Timer=" + VB.Timer() + "])");

        //    //gCmd = new ADODB.Command();
        //    //gCmd.let_ActiveConnection(gCon);
        //    //gCmd.CommandText = strSpName;
        //    //gCmd.CommandType = ADODB.CommandTypeEnum.adCmdStoredProc;
        //    //gCmd.CommandTimeout = 0;

        //    paraCount = short.Parse(param.ToString());

        //    if (paraCount >= 0)
        //    {

        //        for (i = 0; i <= paraCount; i++)
        //        {

        //            //prm = new ADODB.Parameter();
        //            if (i == outputNO)
        //            {
        //                prm.Direction = ADODB.ParameterDirectionEnum.adParamReturnValue;
        //            }
        //            else
        //            {
        //                prm.Direction = ADODB.ParameterDirectionEnum.adParamInput;
        //            }

        //            //UPGRADE_WARNING: TypeName に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        //            if (TypeName(param(i)) == "Long" | TypeName(param(i)) == "Integer")
        //            {
        //                // Integer
        //                prm.Type = ADODB.DataTypeEnum.adInteger;
        //                //UPGRADE_WARNING: オブジェクト param() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        //                prm.Value = param(i);
        //                //UPGRADE_WARNING: TypeName に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        //            }
        //            else if (TypeName(param(i)) == "Number" | TypeName(param(i)) == "Double")
        //            {
        //                // Double
        //                prm.Type = ADODB.DataTypeEnum.adDouble;
        //                //UPGRADE_WARNING: オブジェクト param() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        //                prm.Value = param(i);
        //                //UPGRADE_WARNING: TypeName に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        //            }
        //            else if (TypeName(param(i)) == "Date")
        //            {
        //                // Date
        //                prm.Type = ADODB.DataTypeEnum.adDate;
        //                //UPGRADE_WARNING: オブジェクト param() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        //                prm.Value = param(i);
        //                //UPGRADE_WARNING: TypeName に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        //            }
        //            else if (TypeName(param(i)) == "Currency")
        //            {
        //                // Currency
        //                prm.Type = ADODB.DataTypeEnum.adCurrency;
        //                //UPGRADE_WARNING: オブジェクト param() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        //                prm.Value = param(i);
        //            }
        //            else
        //            {
        //                // Others ( String etc... )
        //                prm.Type = ADODB.DataTypeEnum.adChar;
        //                //UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        //                if (IsDbNull(param(i)))
        //                {
        //                    prm.SIZE = 1;
        //                    //UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        //                    prm.Value = System.DBNull.Value;
        //                }
        //                else
        //                {
        //                    //UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        //                    prm.SIZE = LenB(param(i));
        //                    //UPGRADE_WARNING: オブジェクト param() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        //                    prm.Value = param(i);
        //                }
        //            }

        //            gCmd.Parameters.Append(prm);

        //        }
        //    }

        //    gCmd.Execute(, , ADODB.CommandTypeEnum.adCmdStoredProc);

        //    if (gCon.Errors.Count > 0)
        //        goto Err_Proc;


        //    //UPGRADE_WARNING: オブジェクト outputVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        //    outputVal = gCmd.Parameters(outputNO).Value;
        //    execSProcR = 0;

        //    gLog.writeLog("SQL: execSProcR Finish...[Timer=" + VB.Timer() + "])");

        //    return;

        //Err_Proc:
        //    //    On Error Resume Next
        //    if (Err.Number > 0)
        //    {
        //        msgError("execSProc Error");
        //        gLog.writeLog("execSProc Error!!" + Err.Number + " : " + Err.Description);
        //        execSProcR = Err.Number;
        //    }
        //    if (gCon.Errors.Count > 0)
        //    {
        //        msgError("execSProc Error");
        //        gLog.writeLog("execSProc Error!!(Conn)" + gCon.Errors.Item(0).Number + " : " + gCon.Errors.Item(0).Description);
        //        execSProcR = gCon.Errors.Item(0).Number;
        //    }


        //}

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
