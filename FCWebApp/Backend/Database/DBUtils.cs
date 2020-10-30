using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace FCWebApp.Backend.Database
{
    public class DBUtils
    {
        static public readonly string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["hanPublicMySQLConnectionString"].ConnectionString;
        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
    }
}