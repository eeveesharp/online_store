using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop
{
    public class Product
    {
        private string Name { get; set; }

        private double Price { get; set; }

        private int Quantity { get; set; }

        private string Description { get; set; }

        public Product(string name,
            double price,
            int quantity,
            string description)
        {
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
            List<Product> products = new List<Product>();
            products.Add(new Product { Name = "Телевизор Samsung UE55TU7090U 55", Price = 1539, Quantity = 30, Description = "" });
            products.Add(new Product { Name = "Телевизор LG 49UM7020 49", Price = 1225.99, Quantity = 40, Description = "" });
            products.Add(new Product { Name = "Смартфон Apple iPhone 11 128GB", Price = 1799.99, Quantity = 20, Description = "" });
            products.Add(new Product { Name = "Смартфон Apple iPhone 11 64GB", Price = 1499.99, Quantity = 52, Description = "" });
            products.Add(new Product { Name = "Смартфон Apple iPhone 12 Pro 128GB RU", Price = 3899.99, Quantity = 62, Description = "" });
            products.Add(new Product { Name = "Смартфон Apple iPhone 12 64GB, красный", Price = 2544.99, Quantity = 32, Description = "" });
            products.Add(new Product { Name = "Смартфон Apple iPhone 13 Pro Max 128 ГБ", Price = 4250.99, Quantity = 12, Description = "" });
            products.Add(new Product { Name = "Стиральная машина с сушкой LG F2V5NG0W", Price = 1343.99, Quantity = 22, Description = "" });
            products.Add(new Product { Name = "Стиральная машина с сушкой Weissgauff WMD 4748 DC", Price = 1599.99, Quantity = 37, Description = "" });
            products.Add(new Product { Name = "Стиральная машина с сушкой Samsung WD70T4047CE/LP", Price = 1543.99, Quantity = 46, Description = "" });
            products.Add(new Product { Name = "Холодильник Hotpoint-Ariston HTR 4180 M", Price = 1543.99, Quantity = 34, Description = "" });
            products.Add(new Product { Name = "Видеокарта GIGABYTE GeForce RTX 3060 GAMING OC 12G", Price = 3100, Quantity = 15, Description = "" });
            products.Add(new Product { Name = "Видеокарта AFOX Radeon RX 560 4GB", Price = 699.99, Quantity = 35, Description = "" });
            products.Add(new Product { Name = "Ноутбук Apple MacBook Air 13 Late", Price = 2744.99, Quantity = 98, Description = "" });
            products.Add(new Product { Name = "Ноутбук Lenovo IdeaPad 3 15ADA05", Price = 810, Quantity = 75, Description = "" });
            products.Add(new Product { Name = "Умный браслет Xiaomi Mi Smart Band 6", Price = 89.99, Quantity = 13, Description = "" });
            products.Add(new Product { Name = "Умные часы Apple Watch Series 6 GPS 40мм", Price = 999.99, Quantity = 68, Description = "" });

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{products[i].Name}\t {products[i].Price}\t {products[i].Quantity}\t  {products[i].Description}\t");
            }
        }
    }
}
