using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Database
{
    public class DBUtils
    {
        static public readonly string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connStr);
            return conn;
        }
    }
}