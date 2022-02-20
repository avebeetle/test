using System;
using System.Collections.Generic;
using System.Text;
using WebDriverTest.Model;

namespace WebDriverTest.Service
{
    class UserBuilder
    {
        public static string email = "svyatik.svyaaatik@mail.ru";
        public static string password = "polina123";

        public static User WithCredentialsFromProperty()
        {
            return new User(email, password);
        }

        public static User WithEmptyEmail()
        {
            return new User("", password);
        }

        public static User WithEmptyPassword()
        {
            return new User(email, "");
        }


    }
}
