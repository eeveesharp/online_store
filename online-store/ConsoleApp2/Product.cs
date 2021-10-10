using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop
{
    public class Product
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public double Price { get; private set; }

        public int Quantity { get; set; }

        public string Description { get; private set; }

        public DateTime Data { get; set; }

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
        public void GetProduct()
        {
            Storage.Products.Add(new Product { ID = 1, Name = "Телевизор LG 49UM7020 49", Price = 1225.99, Quantity = 40, Description = "" });
            Storage.Products.Add(new Product { ID = 2, Name = "Смартфон Apple iPhone 11 128GB", Price = 1799.99, Quantity = 20, Description = "" });
            Storage.Products.Add(new Product { ID = 3, Name = "Смартфон Apple iPhone 11 64GB", Price = 1499.99, Quantity = 52, Description = "" });
            Storage.Products.Add(new Product { ID = 4, Name = "Смартфон Apple iPhone 12 128GB ", Price = 3899.99, Quantity = 62, Description = "" });
            Storage.Products.Add(new Product { ID = 5, Name = "Смартфон Apple iPhone 12 64GB", Price = 2544.99, Quantity = 32, Description = "" });
            Storage.Products.Add(new Product { ID = 6, Name = "Смартфон Apple iPhone 13 128 ГБ", Price = 4250.99, Quantity = 12, Description = "" });
            Storage.Products.Add(new Product { ID = 7, Name = "Стиральная машина с сушкой LG ", Price = 1343.99, Quantity = 22, Description = "" });
            Storage.Products.Add(new Product { ID = 8, Name = "Стиральная машина с сушкой Weissgauff", Price = 1599.99, Quantity = 37, Description = "" });
            Storage.Products.Add(new Product { ID = 9, Name = "Стиральная машина с сушкой Samsung", Price = 1543.99, Quantity = 46, Description = "" });
            Storage.Products.Add(new Product { ID = 10, Name = "Холодильник Hotpoint-Ariston HTR 4180 M", Price = 1543.99, Quantity = 34, Description = "" });
            Storage.Products.Add(new Product { ID = 11, Name = "Видеокарта GIGABYTE GeForce RTX 3060 ", Price = 3100, Quantity = 15, Description = "" });
            Storage.Products.Add(new Product { ID = 12, Name = "Видеокарта AFOX Radeon RX 560 4GB", Price = 699.99, Quantity = 35, Description = "" });
            Storage.Products.Add(new Product { ID = 13, Name = "Ноутбук Apple MacBook Air 13 Late", Price = 2744.99, Quantity = 98, Description = "" });
            Storage.Products.Add(new Product { ID = 14, Name = "Ноутбук Lenovo IdeaPad 3 15ADA05", Price = 810, Quantity = 75, Description = "" });
            Storage.Products.Add(new Product { ID = 15, Name = "Умный браслет Xiaomi Mi Smart Band 6", Price = 89.99, Quantity = 13, Description = "" });
            Storage.Products.Add(new Product { ID = 16, Name = "Умные часы Apple Watch Series 6 ", Price = 999.99, Quantity = 68, Description = "" });

            if (Storage.Products is null)
            {
                Storage.Products = new List<Product>();
            }        

            File.Write(Storage.Products);
        }

        public void ShowProduct()
        {
            for (int i = 0; i < Storage.Products.Count; i++)
            {
                Console.WriteLine($"{Storage.Products[i].ID}\t {Storage.Products[i].Name}\t {Storage.Products[i].Price}\t {Storage.Products[i].Quantity}\t  {Storage.Products[i].Description}");
            }
        }
    }
}
