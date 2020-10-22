using System;
using System.Collections.Generic;
using System.Text;
using FCBackend.Dao;

namespace FCBackend.Actors
{
    class Teacher : Person
    {
        public string TeacherID
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

        public Teacher(ulong id, string teacherID, string alias, string password, string phone, string email)
            : base(id, alias, teacherID, password, phone, email)
        { }

        public static Teacher Create(string alias, string teacherID, string password, string email)
        {
            // database manipulations
            ulong id = PersonDao.InsertTeacher(teacherID, password, alias, email);
            if (id == 0)
            {
                return null;
            }

            // new Teacher instance
            return new Teacher(id, alias, teacherID, password, null, email);
        }

        public static ulong GetIdByTeacherId(string teacherId)
        {
            return PersonDao.SelectIdByUsername(teacherId);
        }
    }
}
