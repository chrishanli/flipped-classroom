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

        public Teacher(ulong id, string teacherID, string alias, string password, string email)
            : base(id, alias, teacherID, password, email)
        { }

        public static ulong GetIdByTeacherId(string teacherId)
        {
            return PersonDao.SelectIdByUsername(teacherId);
        }
    }
}
