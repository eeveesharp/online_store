using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class SingIn
    {
        public void SingInMenu()
        {
            GetPassword();
            GetLogin();
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
    }
}
