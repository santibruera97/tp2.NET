using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; 
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        const string consKeyDefaultCnnString = "ConnStringExpress";
        private SqlConnection _sqlConn;
        public SqlConnection  sqlConn { get { return _sqlConn; } set { _sqlConn = value; } }

        protected void OpenConnection()
        {
           
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString);
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
