using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Online_Shop
{
    public static class File
    {
        public static void Write(IEnumerable<object> items, string fileName)
        {
            using (FileStream fstream = new FileStream($"{fileName}.json", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(JsonConvert.SerializeObject(items));
                fstream.Write(array, 0, array.Length);
            }
        }

        public static void Read(string fileName)
        {
            Storage.Users = new List<User>();
            Storage.Users = JsonConvert.DeserializeObject<List<User>>(ReadTextFromFile(fileName));

            if (Storage.Users is null)
            {
                Storage.Users = new List<User>();
            }
        }

        public static void ReadProduct(string fileName)
        {
            Storage.Products = new List<Product>();
            Storage.Products = JsonConvert.DeserializeObject<List<Product>>(ReadTextFromFile(fileName));

            if (Storage.Products is null)
            {
                Storage.Products = new List<Product>();
            }
        }

        public static void ReadHistoryBuy(string fileName)
        {
            Storage.HistoryBuy = new List<Product>();
            Storage.HistoryBuy = JsonConvert.DeserializeObject<List<Product>>(ReadTextFromFile(fileName));

            if (Storage.HistoryBuy is null)
            {
                Storage.HistoryBuy = new List<Product>();
            }
        }

        private static string ReadTextFromFile(string filename)
        {
            string fileContent = string.Empty;

            try
            {
                using (FileStream fstream = System.IO.File.OpenRead($"{filename}.json"))
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

            return fileContent;
        }
    }
}

