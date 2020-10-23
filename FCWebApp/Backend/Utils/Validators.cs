using System;
using System.Collections.Generic;
using System.Text;

namespace FCBackend.Utils
{
    class Validators
    {
        public static bool ValidateUsername(string username)
        {
            // TODO - username validation
            return username.Length >= 3;
        }

        public static bool ValidatePassword(string password)
        {
            // TODO - password validation
            return password.Length >= 5;
        }

        public static bool ValidateEmail(string email)
        {
            // TODO - email validation
            return email.Length >= 5;
        }
    }
}
