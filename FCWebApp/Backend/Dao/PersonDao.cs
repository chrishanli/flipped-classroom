using FCBackend.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCBackend.Dao
{
    class PersonDao
    {
        static ulong id = 0;
        // Temporarily using a list to store persons
        static List<Person> persons = new List<Person>();

        static public ulong InsertTeacher(
            string teacherID, string password, string alias, string email)
        {
            // TODO - insert; fetch auto-increment ids
            persons.Add(new Teacher(++id, teacherID, alias, password, null, email));
            return id;
        }

        static public bool ChangePersonInfo(ulong id, string username, string email, string phone, string alias)
        {
            // TODO - change person info in db
            if (id <= 0 || id > (ulong)persons.Count)
            {
                return false;
            }
            // change
            Person person = persons[(int)id];
            person.Alias = alias;
            person.Email = email;
            person.Phone = phone;
            person.Username = username;
            return true;
        }

        static public bool ChangePersonPassword(ulong id, string password)
        {
            // TODO - change person pw in db
            if (id <= 0 || id > (ulong)persons.Count)
            {
                return false;
            }
            // change
            Person person = persons[(int)id];
            person.Password = password;
            return true;
        }

        static public bool DeletePerson(ulong id)
        {
            // delete user;
            return true;
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
