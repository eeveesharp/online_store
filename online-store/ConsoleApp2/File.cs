using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Online_Shop
{
    public static class File
    {
        public static void Write(List<User> users)
        {
            using (FileStream fstream = new FileStream($"users.json", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(JsonConvert.SerializeObject(users));
                fstream.Write(array, 0, array.Length);
            }
        }

        public static void Write(List<Product> products)
        {
            using (FileStream fstream = new FileStream($"products.json", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(JsonConvert.SerializeObject(products));
                fstream.Write(array, 0, array.Length);
            }
        }

        public static void WriteBasket(List<Product> baskets)
        {
            using (FileStream fstream = new FileStream($"{Storage.CurrentUser.Login}.json", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(JsonConvert.SerializeObject(baskets));
                fstream.Write(array, 0, array.Length);
            }
        }

        public static void Read()
        {
            Storage.Users = new List<User>();
            string fileContent = string.Empty;

            try
            {
                using (FileStream fstream = System.IO.File.OpenRead("users.json"))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    fileContent = System.Text.Encoding.Default.GetString(array);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Storage.Users = JsonConvert.DeserializeObject<List<User>>(fileContent);

            if (Storage.Users is null)
            {
                Storage.Users = new List<User>();
            }
        }

        public static void ReadProduct()
        {
            Storage.Products = new List<Product>();
            string fileContent = string.Empty;

            try
            {
                using (FileStream fstream = System.IO.File.OpenRead("products.json"))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    fileContent = System.Text.Encoding.Default.GetString(array);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Storage.Products = JsonConvert.DeserializeObject<List<Product>>(fileContent);

            if (Storage.Products is null)
            {
                Storage.Products = new List<Product>();
            }
        }

        public static void ReadBasket()
        {
            Storage.Basket = new List<Product>();
            string fileContent = string.Empty;

            try
            {
                using (FileStream fstream = System.IO.File.OpenRead($"{Storage.CurrentUser.Login}.json"))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    fileContent = System.Text.Encoding.Default.GetString(array);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Storage.Basket = JsonConvert.DeserializeObject<List<Product>>(fileContent);

            if (Storage.Basket is null)
            {
                Storage.Basket = new List<Product>();
            }
        }
    }
}

