using System;
using System.Collections.Generic;
using System.Text;
using FCBackend.Utils;

namespace FCBackend.Actors
{
    class Administrator: Person
    {
        public Administrator(ulong id, string alias, string username, string password, string phone, string email)
            : base(id, alias, username, password, phone, email)
        { }

        public Teacher CreateTeacher(string teacherID, string password, string alias, string email)
        {
            if (!Validators.ValidateUsername(teacherID) ||
                !Validators.ValidatePassword(teacherID))
            {
                return null;
            }

            // try create teacher
            Teacher teacher = Teacher.Create(alias, teacherID, password, email);
            // TODO - duplicate teachers
            if (teacher == null)
            {
                return null;
            }

            return teacher;
        }

        public bool ChangePersonInfo(ulong id, string alias, string username, string phone, string email)
        {
            if (!Validators.ValidateUsername(username) ||
                !Validators.ValidatePhone(phone) ||
                !Validators.ValidateEmail(email))
            {
                return false;
            }

            // change info
            return ChangeInfoById(id, username, phone, email, alias);
        }

        public bool ChangePersonPassword(ulong id, string password)
        {
            if (!Validators.ValidatePassword(password))
            {
                return false;
            }

            // change info
            return ChangePasswordById(id, password);
        }

        public bool DeletePerson(ulong id)
        {
            return DeletePersonById(id);
        }
    }
}
