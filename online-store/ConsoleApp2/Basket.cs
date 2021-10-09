using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop
{
    public class Basket
    {
        public void AddProduct()
        {
            File.ReadProduct();

            int id = GetID();

            if (Storage.Basket is null)
            {
                Storage.Basket = new List<Product>();
            }

            for (int i = 0; i < Storage.Products.Count; i++)
            {
                if (id - 1 == Storage.Products[i].ID)
                {
                    var product = Storage.Products[id];
                    Storage.Basket.Add(product);
                    File.WriteBasket(Storage.Basket);
                }
            }
        }

        private int GetID()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number) || number > Storage.Products.Count + 1 || number <= 0)
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
    }
}
