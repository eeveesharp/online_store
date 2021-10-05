using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public SingUp SingUp { get; set; }

        public User(string name,string lastName,string login,string password)
        {
            Name = name;
            LastName = lastName;
            Login = login;
            Password = password;
        }
    }
}
