using FCWebApp.Backend.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Dao
{
    public class DiscussDao
    {
        public static Int64 getCourseIdByDiscussId(Int64 discussId)
        {
            Int64 courseId = -1;
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT course_id FROM fc_discuss WHERE id={0};"
                , discussId);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            while (reader.Read())
            {
                courseId = reader.GetInt64(0);
            }

            // close connection
            conn.Close();
            return courseId;
        }
    }
}