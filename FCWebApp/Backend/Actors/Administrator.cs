using System;
using System.Collections.Generic;
using System.Text;
using FCBackend.Dao;
using FCBackend.Utils;

namespace FCBackend.Actors
{
    class Administrator: Person
    {
        public Administrator(ulong id, string alias, string username, string password, string email)
            : base(id, alias, username, password, email)
        { }

        static public bool CreateTeacher(string teacherID, string password, string alias, string email)
        {
            // TODO - validate
            if (!Validators.ValidateUsername(teacherID) ||
                !Validators.ValidatePassword(teacherID))
            {
                return false;
            }

            if (PersonDao.InsertTeacher(teacherID, password, alias, email))
            {
                return true;
            }

            return false;
        }
    }
}
