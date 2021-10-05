using System;

namespace Online_Shop
{
    public class SignIn
    {
        public void SignInMenu()
        {
            File.Read();

            User user = new User(
                GetLogin(),
                GetPassword());

            while (!IsCheckSignIn(user.Login))
            {
                Console.WriteLine("User is not registered");

                user = new User(
                    GetLogin(),
                    GetPassword());
            }

            Storage.CurrentUser = user;
        }

        private bool IsCheckSignIn(string login)
        {
            for (int i = 0; i < Storage.Users.Count; i++)
            {
                if (login == Storage.Users[i].Login)
                {
                    return true;
                }
            }

            return false;
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
