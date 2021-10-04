using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class LogMenu
    {
        public void Menu()
        {
            Console.WriteLine("1.Sign in\n2.Sign up");
            int menu = GetCorrectNumber();
            SingUp singUp = new SingUp();

            switch (menu)
            {
                case 1:
                    {
                        
                        break;
                    }

                case 2:
                    {
                        singUp.SingUpMenu();
                        break;
                    }
                default:
                    break;
            }

        }

        private int GetCorrectNumber()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(),out number))
            {
                Console.WriteLine("Error");
            }

            Console.Clear();

            return number;
        }
    }
}
