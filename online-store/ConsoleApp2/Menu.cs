using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Menu
    {
        public void MainMenu()
        {
            Console.WriteLine("1.Show catalog\n2.Show basket\n3.Product search by name\n4.Show history buy");
            int menu = GetCorrectNumber();

            switch (menu)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
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

            return number;
        }
    }
}
