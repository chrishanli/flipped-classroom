using FCWebApp.Backend.Database;
using FCWebApp.Backend.Model.Po;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Dao
{
    public class DiscussDao
    {
        public static String getDiscussTopic(Int64 discussId)
        {
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT topic FROM fc_discuss WHERE id={0};"
                , discussId);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            string topic = "";
            while (reader.Read())
            {
                topic = reader.GetString(0);
            }
            return topic;
        }

        public static bool isAttended(Int64 did, Int64 sid)
        {
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT count(*) FROM fc_discuss_attend WHERE id={0} AND stu_id={0};"
                , did, sid);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            int count = 0;
            if (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            return count == 1;
        }

        public static bool attend(Int64 did, Int64 sid)
        {
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("INSERT INTO fc_discuss_attend(discuss_id, stu_id) VALUES({0}, {1});"
                , did, sid);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            int affected = comm.ExecuteNonQuery();

            // perform reading
            if (affected <= 0)
            {
                return false;
            }
            return true;
        }

        public static DiscussAttendPo getDiscussAttendInfo(Int64 discussId, Int64 stuId)
        {
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT id, discuss_id, stu_id, signin_time FROM fc_discuss_attend WHERE discuss_id={0}"
                , discussId);
            if (stuId != -1)
            {
                sql += string.Format(" AND stu_id={0}", stuId);
            }
            sql += ";";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            DiscussAttendPo po = null;
            if (reader.Read())
            {
                po = new DiscussAttendPo();
                po.id = reader.GetInt64(0);
                po.discussId = reader.GetInt64(1);
                po.stuId = reader.GetInt64(2);
                po.signinTime = reader.GetDateTime(3);

            }
            return po;
        }
    }
}