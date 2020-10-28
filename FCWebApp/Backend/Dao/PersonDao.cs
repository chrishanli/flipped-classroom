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

        static public bool FetchAllPerson()
        {
            persons.Clear();
            // connect to sql
            SqlConnection conn = DBUtils.GetConnection();
            conn.Open();
            string sql = "SELECT [type], [id], [username], [alias], [email], [status] FROM [fc_user]";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader reader = comm.ExecuteReader();

            // perform reading
            while (reader.Read())
            {
                string type = reader[0].ToString();
                ulong id = UInt64.Parse(reader[1].ToString());
                string username = reader[2].ToString();
                string alias = reader[3].ToString();
                string email = reader[4].ToString();
                string status = reader[5].ToString(); // TODO
                switch (type)
                {
                    case "TC":
                        Teacher teacher = new Teacher(id, username, alias, null, email);
                        persons.Add(teacher);
                        break;
                    case "ST":
                        Student stu = new Student(id, username, alias, null, email);
                        persons.Add(stu);
                        break;
                }
            }

            // close connection
            conn.Close();
            return true;
        }

        static public bool InsertTeacher(
            string teacherID, string password, string alias, string email)
        {
            // connect to sql server
            SqlConnection conn = DBUtils.GetConnection();
            string sql = String.Format(
                "INSERT INTO [fc_user] ([type], [username], [password], [alias], [email], [status]) VALUES" +
                "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')"
                , "TC", teacherID, password, alias, email, "NM"
            );

            // try perform insert
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
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

        static public bool ChangePersonInfo(ulong id, string username, string email, string alias)
        {
            // connect to sql server
            SqlConnection conn = DBUtils.GetConnection();
            string sql = String.Format(
                "UPDATE TABLE [fc_user] SET [username]='{0}', [alias]='{1}', [email]='{2}' WHERE id={3}"
                , username, alias, email, id
            );

            // try perform insert
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
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

        static public bool ChangePersonPassword(ulong id, string password)
        {
            // connect to sql server
            SqlConnection conn = DBUtils.GetConnection();
            string sql = String.Format(
                "UPDATE TABLE [fc_user] SET [password]='{0}' WHERE id={1}"
                , password, id
            );

            // try perform insert
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
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

        static public bool DeletePerson(ulong id)
        {
            // connect to sql server
            SqlConnection conn = DBUtils.GetConnection();
            string sql = String.Format(
                "DELETE FROM [fc_user] WHERE id={0}", id
            );

            // try perform insert
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
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
