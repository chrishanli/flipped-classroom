using FCWebApp.Backend.Database;
using FCWebApp.Backend.Model;
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
            string sql = String.Format("SELECT course_id, class_num, group_id, name, description, status FROM fc_select, fc_course WHERE fc_select.stu_id={0} AND fc_course.id=fc_select.course_id;"
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
                vo.groupId = reader.IsDBNull(2) ? -1 : reader.GetInt64(2);
                vo.name = reader.GetString(3);
                vo.description = reader.GetString(4);
                vo.status = reader.GetString(5);
                // 插入序列
                lcp.Add(vo);
            }

            // close connection
            conn.Close();
            return lcp;
        }

        public static GroupVo getCourseGroupByStuId(Int64 stuId, Int64 courseId)
        {
            GroupVo vo = new GroupVo();
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT id, name, course_id, class_num, status FROM fc_group, fc_group_attend WHERE stu_id={0} AND course_id={1};"
                , stuId, courseId);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            while (reader.Read())
            {
                // 构造 Vo 对象
                vo.id = reader.GetInt64(0);
                vo.name = reader.GetString(1);
                vo.courseId = reader.GetInt64(2);
                vo.classNum = reader.GetInt16(3);
                vo.Status = reader.GetString(4);
            }

            // close connection
            conn.Close();
            return vo;
        }

        public static String getStudentName(Int64 stuId)
        {
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT alias FROM fc_user WHERE id={0} AND type='ST';"
                , stuId);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            string name = "";
            while (reader.Read())
            {
                name = reader.GetString(0);
            }
            return name;
        }
    }
}
