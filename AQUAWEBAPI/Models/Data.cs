using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading;
using System.IO;

/// <summary>
/// Summary description for Data
/// </summary>
/// 
namespace AQUA
{
    enum SPCommand
    {
        Update, Insert, SelectMany, SelectScalar
    }
    internal class Data : IDisposable
    {
        private bool disposed;
        private SqlConnection con = null;
        private SqlCommand comm = null;
        private SqlConnection sqlImportConnection = null;
        private SqlCommand sqlImportCom = null;
        private SqlDataAdapter adap = null;
        public string strConnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        //private string strImportCon = null;
        private static Data instance = null;


        public static Data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Data();
                }
                return instance;
            }
        }

        public Data()
        {
            disposed = false;
            strConnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(strConnection);
            comm = new SqlCommand();
            comm.Connection = con;
            comm.Connection.Open();
            sqlImportCom = new SqlCommand();
            adap = new SqlDataAdapter();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                if (comm != null && comm.Connection.State == ConnectionState.Open)
                {
                    comm.Connection.Close();
                }
                instance = null;
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public DataSet GetDataset(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                using (con = new SqlConnection(strConnection))
                {
                    using (var da = new SqlDataAdapter(query, con))
                    {
                        da.Fill(ds);
                    }

                }
                //comm.CommandText = query;
                //adap.SelectCommand = comm;
                //adap.Fill(ds);
            }
            catch (Exception ex)
            {
                var logtxt = DateTime.Now.ToString() + ":::" + query + "::" + ex.Message.ToString();
                writeLog(logtxt);
            }
            return ds;
        }

        public DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(strConnection))
                {
                    using (var da = new SqlDataAdapter(query, con))
                    {
                        da.Fill(dt);
                    }

                }

            }
            catch (Exception ex)
            {
                var logtxt = DateTime.Now.ToString() + ":::" + query + "::" + ex.Message.ToString();
                writeLog(logtxt);
            }

            return dt;
        }


        public bool ExecuteNonQuery(string query)
        {
            bool res = false;
            try
            {

                //comm.CommandText = query;
                //int x = comm.ExecuteNonQuery();
                //res = x == 1;
                using (con = new SqlConnection(strConnection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        int x = cmd.ExecuteNonQuery();
                        res = x == 1;
                    }
                    //comm.CommandText = query;
                    //int x = comm.ExecuteNonQuery();
                    //res = x == 1;

                }

            }
            catch (Exception ex)
            {
                var logtxt = DateTime.Now.ToString() + ":::" + query + "::" + ex.Message.ToString();
                writeLog(logtxt);
            }
            return res;
        }

        public object ExecuteScalar(string query)
        {
            object x = null;
            try
            {
                //comm.CommandText = query;
                //x = comm.ExecuteScalar();
                using (con = new SqlConnection(strConnection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        x = cmd.ExecuteScalar();
                    }

                }

            }
            catch (Exception ex)
            {
                var logtxt = DateTime.Now.ToString() + ":::" + query + "::" + ex.Message.ToString();
                writeLog(logtxt);
            }
            return x;
        }

        public bool Transaction(List<string> qryCollection)
        {
            bool res = false;
            string qryfl = "";
            try
            {
                using (con = new SqlConnection(strConnection))
                {
                    con.Open();
                    foreach (string qry in qryCollection)
                    {
                        //comm.CommandText = qry;
                        //int x = comm.ExecuteNonQuery();
                        //res = x == 1;                    
                        using (SqlCommand cmd = new SqlCommand(qry, con))
                        {
                            int x = cmd.ExecuteNonQuery();
                            res = x == 1;
                        }

                    }
                }
                res = true;
            }
            catch (Exception ex)
            {
                var logtxt = DateTime.Now.ToString() + ":::" + qryfl + "::" + ex.Message.ToString();
                writeLog(logtxt);
            }
            return res;
        }

        public bool ExecuteSPInsert(List<SqlParameter> parameters, string spName, SPCommand spCommand)
        {
            //bool res = false;
            int x = 0;
            try
            {
                comm.CommandText = spName;
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Clear();
                foreach (SqlParameter pm2 in parameters)
                {
                    comm.Parameters.Add(pm2);
                }
                switch (spCommand)
                {
                    case SPCommand.Insert:
                        x = comm.ExecuteNonQuery();
                        break;
                    case SPCommand.Update:
                        x = comm.ExecuteNonQuery();
                        break;
                }

                return x == 1;
            }
            catch (InvalidOperationException ex)
            {
                string s = "<<Message>> " + ex.Message;
                s = s + "<<SPNAME>> " + spName;
                foreach (SqlParameter pm in parameters)
                {
                    s = string.Concat(s, "[parameter] <NAME : ", pm.ParameterName, "> <VALUE : ", pm.Value, " >");
                }
                throw new Exception(s);
            }

        }

        public T ExecuteSP<T>(List<SqlParameter> parameters, string spName)
        {
            object obj = null;
            try
            {
                using (sqlImportCom = new SqlCommand())
                {
                    sqlImportCom.Connection = sqlImportConnection;
                    sqlImportCom.CommandText = spName;
                    sqlImportCom.CommandType = CommandType.StoredProcedure;
                    sqlImportCom.Parameters.Clear();
                    foreach (SqlParameter pm2 in parameters)
                    {
                        sqlImportCom.Parameters.Add(pm2);
                    }
                    IAsyncResult aRes = null;
                    aRes = sqlImportCom.BeginExecuteNonQuery();
                    WaitHandle wHandle = aRes.AsyncWaitHandle;
                    wHandle.WaitOne();
                    obj = sqlImportCom.EndExecuteNonQuery(aRes);
                    obj = true;
                }
            }
            catch (InvalidOperationException ex)
            {
                string s = "<<Message>> " + ex.Message;
                s = s + "<<SPNAME>> " + spName;
                foreach (SqlParameter pm in parameters)
                {
                    s = string.Concat(s, "[parameter] <NAME : ", pm.ParameterName, "> <VALUE : ", pm.Value, " >");
                }
                throw new Exception(s);
            }

            return (T)Convert.ChangeType(obj, typeof(T));
        }

        public bool ExecuteSP_new(List<SqlParameter> parameters, string spName)
        {
            bool obj = false;
            try
            {
                using (comm = new SqlCommand())
                {
                    comm.Connection = con;
                    comm.CommandText = spName;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Clear();
                    foreach (SqlParameter pm2 in parameters)
                    {
                        comm.Parameters.Add(pm2);
                    }
                    IAsyncResult aRes = null;
                    aRes = comm.BeginExecuteNonQuery();
                    WaitHandle wHandle = aRes.AsyncWaitHandle;
                    wHandle.WaitOne();
                    int a = comm.EndExecuteNonQuery(aRes);
                    obj = true;
                }
            }
            catch (InvalidOperationException ex)
            {
                string s = "<<Message>> " + ex.Message;
                s = s + "<<SPNAME>> " + spName;
                foreach (SqlParameter pm in parameters)
                {
                    s = string.Concat(s, "[parameter] <NAME : ", pm.ParameterName, "> <VALUE : ", pm.Value, " >");
                }
                return false;
            }

            return true;
        }

        public DataTable ExecuteSP(List<SqlParameter> parameters, string spName)
        {
            DataTable dt = new DataTable();
            try
            {
                comm.CommandText = spName;
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Clear();
                foreach (SqlParameter pm in parameters)
                {
                    SqlDbType typ = SqlDbType.VarChar;
                    switch (pm.SqlDbType)
                    {
                        case SqlDbType.DateTime:
                            typ = SqlDbType.DateTime;
                            break;
                        case SqlDbType.Int:
                            typ = SqlDbType.Int;
                            break;
                        case SqlDbType.Bit:
                            typ = SqlDbType.Bit;
                            break;
                    }
                    string pName = "@" + pm.ParameterName;
                    comm.Parameters.Add(new SqlParameter(pName, typ));
                    comm.Parameters[pName].Value = pm.Value;
                }
                adap.SelectCommand = comm;
                adap.Fill(dt);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message + " SPNAME " + spName);
            }

            return dt;
        }

        public bool UpdateUsingExecuteNonQueryList(List<string> strQuery)
        {
            bool b = false;
            string qryfl = "";
            SqlTransaction objTrans;
            using (SqlConnection objConn = new SqlConnection(strConnection))
            {
                objConn.Open();
                objTrans = objConn.BeginTransaction();
                try
                {
                    foreach (string qry in strQuery)
                    {
                        qryfl = qry;
                        SqlCommand objCmd1 = new SqlCommand(qry, objConn, objTrans);
                        objCmd1.ExecuteNonQuery();

                    }
                    objTrans.Commit();
                    b = true;
                }
                catch (Exception ex)
                {
                    b = false;
                    var logtxt = DateTime.Now.ToString() + ":::" + qryfl + "::" + ex.Message.ToString();
                    writeLog(logtxt);
                    objTrans.Rollback();

                }

            }
            return b;
        }

        public void writeLog(string strValue)
        {
            try
            {
                //Logfile
                string path = ConfigurationManager.AppSettings["datalogpath"];
                StreamWriter sw;

                if (!File.Exists(path))
                { sw = File.CreateText(path); }
                else
                { sw = File.AppendText(path); }

                LogWrite(strValue, sw);

                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {

            }
        }

        private static void LogWrite(string logMessage, StreamWriter w)
        {
            w.WriteLine("{0}", logMessage);
            w.WriteLine("----------------------------------------");
        }
    }

}