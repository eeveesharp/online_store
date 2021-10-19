using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Online_Shop
{
    public class Product
    {
        public int ID { get; private set; }

        public string Name { get; private set; }

        public double Price { get; private set; }

        public int Quantity { get; set; }

        public string Description { get; private set; }

        public DateTime Date { get; set; }

        [JsonConstructor]
        public Product(int id, string name,
            double price,
            int quantity,
            string description)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Description = description;
        }

        public Product()
        {

        }

        public void ShowProduct()
        {
            for (int i = 0; i < Storage.Products.Count; i++)
            {
                Console.WriteLine($"ID:{Storage.Products[i].ID}\n NAME:{Storage.Products[i].Name}\n PRICE:{Storage.Products[i].Price}\n QUANTITY:{Storage.Products[i].Quantity}\n DESCRIPTION:\n{Storage.Products[i].Description}");
                Line();
            }
        }

        public void Line()
        {
            Console.WriteLine("_________________________________________________________________________________________________________________________");
        }
    }
}
