using FCWebApp.Backend.Database;
using FCWebApp.Backend.Model.Vo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Dao
{
    public class GroupDao
    {
        public static DiscussSigninVo getSignedInRecord(Int64 groupId, Int64 discussId)
        {
            DiscussSigninVo vo = new DiscussSigninVo();
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT discuss_id, group_id, signin_time FROM fc_discuss_signin WHERE group_id={0} AND discuss_id={1};"
                , groupId, discussId);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            while (reader.Read())
            {
                // 构造 Vo 对象
                vo.discussId = reader.GetInt64(0);
                vo.groupId = reader.GetInt64(1);
                vo.signInTime = reader.GetInt64(2);
            }

            // close connection
            conn.Close();
            return vo;
        }

        public static DiscussSigninVo getSignedInRecord(Int64 attendId)
        {
            DiscussSigninVo vo = new DiscussSigninVo();
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT discuss_id, group_id, signin_time FROM fc_discuss_signin WHERE id={0};"
                , attendId);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            while (reader.Read())
            {
                // 构造 Vo 对象
                vo.discussId = reader.GetInt64(0);
                vo.groupId = reader.GetInt64(1);
                vo.signInTime = reader.GetInt64(2);
            }

            // close connection
            conn.Close();
            return vo;
        }
    }
}