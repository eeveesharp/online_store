﻿using System;

namespace Online_Shop
{
    public class Menu
    {
        public void ShowMainMenu()
        {
            while (true)
            {
                int menu;
                Basket basket = new Basket();
                Product product = new Product();
                Console.WriteLine("1.Show catalog\n2.Show basket\n3.Product search by name\n4.Show history buy\n5.Exit");
                menu = GetCorrectNumber();
                File.ReadHistoryBuy(Storage.CurrentUser.Login);
                File.ReadProduct("products");

                switch (menu)
                {
                    case 1:
                        {
                            //product.GetProduct();
                            basket.AddProduct();
                            break;
                        }
                    case 2:
                        {
                            //basket.ShowBasket();
                            basket.BuyProduct();
                            break;
                        }
                    case 3:
                        {
                            basket.FindProduct();
                            break;
                        }
                    case 4:
                        {
                            basket.ShowHistoryBuy();
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
        }

        private int GetCorrectNumber()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.WriteLine("Error");
            }

            return number;
        }
    }
}
