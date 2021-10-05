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
    }
}

