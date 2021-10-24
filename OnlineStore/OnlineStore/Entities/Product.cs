using Newtonsoft.Json;
using OnlineStore.Storages;
using System;
using System.Collections.Generic;

namespace OnlineStore.Entities
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
    }
}
