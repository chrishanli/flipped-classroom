using FCBackend.Actors;
using System;
using System.Collections.Generic;
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
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(@"E:\Han\Git Repositories\flipped-classroom\FCWebApp\Data\PersonList.xml");
            doc.Load(reader);
            // to fetch the root node
            XmlNode rn = doc.SelectSingleNode("persons");
            // to fetch all children of the root node
            XmlNodeList xnl = rn.ChildNodes;
            foreach (XmlNode personNode in xnl)
            {
                XmlNodeList childs = personNode.ChildNodes;
                string type = ((XmlElement)personNode).GetAttribute("type").ToString();
                string username = childs.Item(0).InnerText;
                string alias = childs.Item(1).InnerText;
                string password = childs.Item(2).InnerText;
                string email = childs.Item(3).InnerText;
                string status = childs.Item(4).InnerText; // TODO
                switch (type)
                {
                    case "teacher":
                        Teacher teacher = new Teacher(++id, username, alias, password, email);
                        persons.Add(teacher);
                        break;
                    case "student":
                        Student stu = new Student(++id, username, alias, password, email);
                        persons.Add(stu);
                        break;
                }
            }
            return true;
        }

        static public ulong InsertTeacher(
            string teacherID, string password, string alias, string email)
        {
            // TODO - insert; fetch auto-increment ids
            persons.Add(new Teacher(++id, teacherID, alias, password, email));
            return id;
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
            // TODO - change person info in db
            if (id <= 0 || id > (ulong)persons.Count)
            {
                return false;
            }
            // change
            Person person = persons[(int)id];
            person.Alias = alias;
            person.Email = email;
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
