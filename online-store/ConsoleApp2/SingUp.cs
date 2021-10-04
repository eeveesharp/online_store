using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class SingUp
    {
        public void SingUpMenu()
        {
            User user = new User();
            user.Name = GetName();
            user.LastName = GetLastName();
            user.Login = GetLogin();
            user.Password = GetPassword();          
        }

        private string GetPassword()
        {
            Console.WriteLine("Enter password");
            string password;
            password = Console.ReadLine();
            Console.Clear();

            return password;
        }

        private string GetLogin()
        {
            Console.WriteLine("Enter login");
            string login;
            login = Console.ReadLine();
            Console.Clear();

            return login;
        }

        private string GetName()
        {
            Console.WriteLine("Enter name");
            string name;
            name = Console.ReadLine();
            Console.Clear();

            return name;
        }

        private string GetLastName()
        {
            Console.WriteLine("Enter lastName");
            string lastName;
            lastName = Console.ReadLine();
            Console.Clear();

            return lastName;
        }
    }
}
