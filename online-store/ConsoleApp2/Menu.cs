using System;

namespace Online_Shop
{
    public class Menu
    {
        public void ShowMainMenu()
        {           
            int menu;
            Product product = new Product();
            Basket basket = new Basket();
            Console.WriteLine("1.Show catalog\n2.Show basket\n3.Product search by name\n4.Show history buy\n5.Exit");
            menu = GetCorrectNumber();
            File.ReadProduct();

            switch (menu)
            {
                case 1:
                    {
                        //product.GetProduct();
                        product.ShowProduct();
                        basket.AddProduct();
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
                        basket.ShowBasket();
                        break;
                    }
                case 5:
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    break;
            }
        }

        private int GetCorrectNumber()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Error");
            }

            return number;
        }
    }
}
