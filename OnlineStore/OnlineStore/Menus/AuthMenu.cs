using OnlineStore.Services;
using System;

namespace OnlineStore.Menus
{
    public class AuthMenu
    {
        public void ShowMenu()
        {
            int menu;

            SignUp singUp = new SignUp();

            SignIn singIn = new SignIn();

            Console.WriteLine("1.Sign in\n2.Sign up");

            menu = GetCorrectNumber();

            switch (menu)
            {
                case 1:
                    {
                        singIn.SignInMenu();

                        break;
                    }

                case 2:
                    {
                        singUp.SignUpMenu();

                        break;
                    }
                default:
                    break;
            }

        }

        private int GetCorrectNumber()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number) ||
                number <= 0)
            {
                Console.WriteLine("Error");
            }

            Console.Clear();

            return number;
        }
    }
}
