using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBUtility
{
    public class SQLHelper
    {
        private readonly string connString;
        private SqlConnection sqlConn;
        private SqlCommand sqlCmd;
        private SqlDataAdapter sqlAdapter;
        public SQLHelper()
        {
            connString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            sqlConn = new SqlConnection(connString);
            sqlCmd = new SqlCommand();
            sqlAdapter = new SqlDataAdapter();
        }
        public string ConnString {
            get { return connString; }
        }
        public DataSet TdataSet(string QueryString)
        {
            sqlAdapter.SelectCommand = new SqlCommand(QueryString, sqlConn);
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds, "temp");
            return ds;
        }
        public  DataTable TdataTable(string QueryString)
        {
            sqlAdapter.SelectCommand = new SqlCommand(QueryString, sqlConn);
            DataTable dt=new DataTable();
            sqlAdapter.Fill(dt);
            return dt;
        }
        public static readonly string connStr = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        
        public static int ExecuteNonQuery(string connStr, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 300;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return result;
            }
        }

        public static int ExecuteNonQuery(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);
            int result = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return result;
        }

        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParameters);
            int result = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return result;
        }

        public static SqlDataReader ExecuteReader(string connStr, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataReader dr = null;
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                conn.Close();
                throw;
            }
            return dr;
        }

        public static object ExecuteScalar(string connStr, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);
                object result = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return result;
            }
        }

        public static object ExecuteScalar(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);
            object result = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return result;
        }

        private static void PrepareCommand(SqlCommand cmd,SqlConnection conn,SqlTransaction trans,CommandType cmdType,string cmdText,SqlParameter[] cmdParameters)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParameters != null)
            {               
                cmd.Parameters.AddRange(cmdParameters);
            }
        }
    }
}
