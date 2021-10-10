using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop
{
    public class Basket
    {
        public void AddProduct()
        {
            DateTime date = new DateTime();
            Product product = new Product();
            int id;
            int quantity;

            while (true)
            {
                Console.Clear();
                File.ReadProduct();
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

                    if (Storage.HistoryBuy is null)
                    {
                        Storage.HistoryBuy = new List<Product>();
                    }

                    for (int i = 0; i < Storage.Products.Count; i++)
                    {
                        if (id == Storage.Products[i].ID)
                        {
                            var productBasket = Storage.Products[i];
                            Storage.Products[i].Quantity -= quantity;
                            File.Write(Storage.Products);
                            productBasket.Quantity = quantity;
                            productBasket.Data = DateTime.Now;
                            Storage.HistoryBuy.Add(productBasket);
                            Storage.Basket.Add(productBasket);                           
                            File.WriteHistoryBuy(Storage.HistoryBuy);
                        }
                    }                   
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
            if (Storage.Basket is null)
            {
                Console.WriteLine("The basket is empty");
            }
            else
            {
                for (int i = 0; i < Storage.Basket.Count; i++)
                {
                    Console.WriteLine($"{Storage.Basket[i].ID}\t {Storage.Basket[i].Name}\t {Storage.Basket[i].Price}\t {Storage.Basket[i].Quantity}");
                }
            }          
        }

        public void ShowHistoryBuy()
        {
            File.ReadHistoryBuy();

            for (int i = 0; i < Storage.HistoryBuy.Count; i++)
            {
                Console.WriteLine($"{Storage.HistoryBuy[i].ID}\t {Storage.HistoryBuy[i].Name}\t {Storage.HistoryBuy[i].Price}\t {Storage.HistoryBuy[i].Quantity}\t\t {Storage.HistoryBuy[i].Data}");
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
