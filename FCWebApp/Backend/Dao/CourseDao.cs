using FCWebApp.Backend.Database;
using FCWebApp.Backend.Model.Vo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Dao
{
    public class CourseDao
    {
        
        public static List<DiscussSimpleVo> getDiscussByCourseId(Int64 courseId)
        {
            List<DiscussSimpleVo> lcp = new List<DiscussSimpleVo>();
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT dis.id, topic, serial_num, attend_start, attend_end, contents FROM fc_discuss dis, fc_course WHERE fc_course.id={0} AND fc_course.id=dis.course_id;"
                , courseId);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader reader = comm.ExecuteReader();

            // perform reading
            if (reader.Read())
            {
                // 构造 Vo 对象
                DiscussSimpleVo vo = new DiscussSimpleVo();
                vo.id = reader.GetInt64(0);
                vo.topic = reader.GetString(1);
                vo.sn = reader.IsDBNull(2) ? -1 : reader.GetInt32(2);
                // 报名开始、结束时间
                DateTime startTime = reader.GetDateTime(3);
                DateTime endTime = reader.GetDateTime(4);
                vo.signinStartTime = startTime.ToString("dd/MM/yyyy HH:mm:ss");
                vo.signinEndTime = endTime.ToString("dd/MM/yyyy HH:mm:ss");
                vo.contents = reader.GetString(5);
                // 判断还可不可以报名
                DateTime now = DateTime.Now;
                if (now < startTime)
                {
                    vo.signinStatus = "not";
                } else if (now < endTime)
                {
                    vo.signinStatus = "ing";
                } else
                {
                    vo.signinStatus = "exp";
                }
                // 插入序列
                lcp.Add(vo);
            }

            // close connection
            conn.Close();
            return lcp;
        }

        public static String getCourseName(Int64 courseId)
        {
            // connect to mysql
            MySqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = String.Format("SELECT name FROM fc_course WHERE id={0};"
                , courseId);
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