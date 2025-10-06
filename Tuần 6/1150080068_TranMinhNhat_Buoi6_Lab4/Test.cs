using System;
using System.Configuration;
using Oracle.ManagedDataAccess.Client; 

namespace _1150080068_TranMinhNhat_Buoi6_Lab4
{

    public sealed class Test : IDisposable
    {
        private readonly string _connStr;
        private OracleConnection _conn;

        public Test()
        {
            _connStr = ConfigurationManager.ConnectionStrings["OracleDb"]?.ConnectionString
                       ?? "User Id=app;Password=app123;Data Source=localhost:1521/xepdb1;";
            _conn = new OracleConnection(_connStr);
        }

       
        public void Open()
        {
            if (_conn == null) _conn = new OracleConnection(_connStr);
            if (_conn.State != System.Data.ConnectionState.Open)
                _conn.Open();
        }

        
        public void Close()
        {
            if (_conn != null && _conn.State != System.Data.ConnectionState.Closed)
                _conn.Close();
        }

       
        public int TestConnection()
        {
            try
            {
                Open();
                using (var cmd = new OracleCommand("SELECT 1 FROM dual", _conn))
                {
                    var result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result; 
                }
            }
            finally
            {
               
                Close();
            }
        }

   
        public object ExecuteScalar(string sql)
        {
            if (_conn == null || _conn.State != System.Data.ConnectionState.Open)
                Open();

            using (var cmd = new OracleCommand(sql, _conn))
            {
                return cmd.ExecuteScalar();
            }
        }

       
        public void Dispose()
        {
            try { Close(); } catch { /* */ }
            _conn?.Dispose();
            _conn = null;
        }
    }
}
