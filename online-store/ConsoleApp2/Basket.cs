using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop
{
    public class Basket
    {
        public void AddProduct()
        {
            Product product = new Product();
            int id;
            int quantity;

            while (true)
            {
                int numberMenu;
                product.ShowProduct();
                Console.WriteLine("Would you like to add a product?");
                Console.WriteLine("1.Yes\n2.No");
                numberMenu = GetNumber(count: 2);
                if (numberMenu == 2)
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Enter ID");
                    id = GetNumber(Storage.Products.Count + 1);
                    Console.WriteLine("Enter quantity");
                    quantity = GetQuantityProduct();

                    if (Storage.Basket is null)
                    {
                        Storage.Basket = new List<Product>();
                    }

                    for (int i = 0; i < Storage.Products.Count; i++)
                    {
                        if (id == Storage.Products[i].ID)
                        {
                            var productBasket = Storage.Products[i];
                            Storage.Products[i].Quantity -= quantity;
                            Storage.Basket.Add(productBasket);
                            File.Write(Storage.Products);
                            Storage.Basket[i].Quantity = quantity;
                            File.WriteBasket(Storage.Basket);
                        }
                    }

                    Console.Clear();
                }
            }          
        }

        private int GetNumber(int count)
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number) || number > count || number <= 0)
            {
                Console.WriteLine("Error.Id is missing");
            }

            return number;
        }

        public void ShowBasket()
        {
            for (int i = 0; i < Storage.Basket.Count; i++)
            {
                Console.WriteLine($"{Storage.Basket[i].ID}\t {Storage.Basket[i].Name}\t {Storage.Basket[i].Price}\t {Storage.Products[i].Quantity}\t  {Storage.Products[i].Description}\t");
            }
        }

        private int GetQuantityProduct()
        {
            int quantity;

            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Erorr");
            }

            return quantity;
        }
    }
}
