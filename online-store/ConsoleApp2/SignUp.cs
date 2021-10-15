using System;

namespace Online_Shop
{
    public class SignUp
    {
        public void SignUpMenu()
        {
            File.Read("users");
            User user = new User(GetName(),
                            GetLastName(),
                            GetLogin(),
                            GetPassword());

            while (!IsCheckSignUp(user.Login))
            {
                Console.WriteLine("User is existed");

                user = new User(GetName(),
                            GetLastName(),
                            GetLogin(),
                            GetPassword());
            }
            Storage.Users.Add(user);
            File.Write(Storage.Users, "users");

            Storage.CurrentUser = user;
        }

        private bool IsCheckSignUp(string login)
        {
            for (int i = 0; i < Storage.Users.Count; i++)
            {
                if (login == Storage.Users[i].Login)
                {
                    return false;
                }
            }

            return true;
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
