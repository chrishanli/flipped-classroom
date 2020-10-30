using FCBackend.Actors;
using FCWebApp.Backend.Database;
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
        static ulong id = 0;
        // Temporarily using a list to store persons
        static List<Person> persons = new List<Person>();

        static public List<Person> PersonList
        {
            get { return persons; }
        }

        static public bool InsertTeacher(
            string teacherID, string password, string alias, string email)
        {
            // connect to sql server
            MySql.Data.MySqlClient.MySqlConnection conn = DBUtils.GetConnection();
            string sql = String.Format(
                "INSERT INTO fc_user (type, username, password, alias, email, status) VALUES" +
                "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')"
                , "TC", teacherID, password, alias, email, "NM"
            );

            // try perform insert
            try
            {
                conn.Open();
                MySql.Data.MySqlClient.MySqlCommand comm = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                if (comm.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return false;
        }

        static public ulong InsertStudent(
            string stuID, string password, string alias, string email)
        {
            // TODO - insert; fetch auto-increment ids
            persons.Add(new Student(++id, stuID, alias, password, email));
            return id;
        }

        static public string SelectUsername(ulong id)
        {
            // TODO
            return "";
        }

        static public ulong SelectIdByUsername(string username)
        {
            // TODO
            return id;
        }
    }
}
