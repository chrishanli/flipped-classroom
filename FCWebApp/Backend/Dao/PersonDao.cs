using FCWebApp.Backend.Database;
using FCWebApp.Backend.Model;
using FCWebApp.Backend.Model.Po;
using FCWebApp.Backend.Model.Vo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml;

namespace FCBackend.Dao
{
    class PersonDao
    {
        public static List<CourseSimpleVo> getCoursesByStuId(Int64 stuId)
        {
            List<CourseSimpleVo> lcp = new List<CourseSimpleVo>();
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT course_id, class_num, name, description, status FROM fc_select, fc_course WHERE fc_select.stu_id={0} AND fc_course.id=fc_select.course_id;"
                , stuId);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            while (reader.Read())
            {
                // 构造 Vo 对象
                CourseSimpleVo vo = new CourseSimpleVo();
                vo.id = reader.GetInt64(0);
                vo.classNum = reader.GetInt64(1);
                vo.name = reader.GetString(2);
                vo.description = reader.GetString(3);
                vo.status = reader.GetString(4);
                // 插入序列
                lcp.Add(vo);
            }

            // close connection
            conn.Close();
            return lcp;
        }

        public static PersonPo getUser(string username, string password)
        {
            // 查找数据库有没有这个人，有就返回
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT id, type, username, alias, email, status FROM fc_user WHERE username='{0}' AND password='{1}';"
                , username, password);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            PersonPo po = null;
            if (reader.Read())
            {
                po = new PersonPo();
                po.id = reader.GetInt64(0);
                po.type = reader.GetString(1);
                po.username = reader.GetString(2);
                po.alias = reader.GetString(3);
                po.email = reader.GetString(4);
                po.status = reader.GetString(5);
            }
            return po;
        }

        public static DiscussSigninVo getSignedInRecord(Int64 stuId, Int64 discussId)
        {
            DiscussSigninVo vo = new DiscussSigninVo();
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT id, discuss_id, stu_id, signin_time FROM fc_discuss_signin WHERE stu_id={0} AND discuss_id={1};"
                , stuId, discussId);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            if (reader.Read())
            {
                // 构造 Vo 对象
                vo.id = reader.GetInt64(0);
                vo.discussId = reader.GetInt64(1);
                vo.stuId = reader.GetInt64(2);
                vo.signInTime = reader.GetMySqlDateTime(3).GetDateTime().ToString("dd/MM/yyyy HH:mm:ss");
            }

            // close connection
            conn.Close();
            return vo;
        }
    }
}
