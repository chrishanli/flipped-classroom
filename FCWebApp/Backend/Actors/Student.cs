using System;
using System.Collections.Generic;
using System.Text;
using FCBackend.Dao;

namespace FCBackend.Actors
{
    class Student : Person
    {
        public string StudentID
        {
            get
            {
                return this.Username;
            }
            set
            {
                Username = value;
            }
        }

        public Student(ulong id, string stuId, string alias, string password, string email)
            : base(id, alias, stuId, password, email)
        { }

        public static Student Create(string alias, string stuID, string password, string email)
        {
            // database manipulations
            ulong id = PersonDao.InsertStudent(stuID, password, alias, email);
            if (id == 0)
            {
                return null;
            }

            // new Teacher instance
            return new Student(id, alias, stuID, password, email);
        }

        public static ulong GetIdByStuId(string stuId)
        {
            return PersonDao.SelectIdByUsername(stuId);
        }
    }
}
