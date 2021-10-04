using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class SingUp
    {
        private string login;
        private string password;

        public void SingUpMenu()
        {
            GetLogin();
            GetPassword();
        }

        private string GetPassword()
        {
            Console.WriteLine("Enter password");
            password = Console.ReadLine();
            Console.Clear();

            return password;
        }

        private string GetLogin()
        {
            Console.WriteLine("Enter login");
            login = Console.ReadLine();
            Console.Clear();

            return login;
        }
    }
}
